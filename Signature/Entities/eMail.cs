using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature;
using Signature.Reports;

namespace Signature.Classes
{
    public class eMail
    {
        internal  SqlBuilder oBuild; //Reuqired
        
        public Int32  ID;
        public Int32  RepID;
        public String Password;
        public _Lines Items;
        public String User;
        public Int32 DomainID;
        public String old_password;
       
        public eMail()
        {
            Items = new _Lines();
        }

        private void Clear()
        {
            ID=0;
            
            Password=  "";
            
            Items.Clear();
            Items.SetColumns();
            User    = "";
            Password = "";
            DomainID = 0;
        }

        public bool Find(String User)
        {
            //this.CallID = String.Empty;

            if (User == "")
            {
                Clear();
                return false;
            }

            DataRow Row = Global.oMySql.GetDataRow(String.Format("Select * From mailserver.virtual_users Where domain_id='{0}' And user='{1}'",this.DomainID, User), "Users");

            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.ID             = (Int32) Row["ID"];
            
            this.Password       = "*****";
            this.User           = Row["User"].ToString();
            this.old_password   = Row["Password"].ToString(); 


            this.Items.Load(this.DomainID, this.User);
            return true;

        }
        public  void Save()
        {
            if (Exists())
                Update();
            else
                Insert();
            this.Items.DomainID = DomainID;
            this.Items.User = this.User;
            this.Items.Save();
        }
        public  void Update()
        {
            FillFields();
            Global.oMySql.exec_sql(oBuild.Update(String.Format("Where domain_id = '{0}' And user='{1}'",this.DomainID,this.User)));
        }
        public  void UpdatePrinted()
        {
            Global.oMySql.exec_sql(String.Format("Update OrderTicket Set Printed='{0}',DatePrinted=NOW() Where ID='{1}'","1",this.ID));
        }
        public  void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert());

        }
        internal  void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("mailserver.virtual_users", new String[] { 
                "user",
                "domain_id",
                "password",
                "RepID"
                },
                new Object[] {
                    this.User,
                    this.DomainID,
                    (this.Password!="*****")?"MD5('"+this.Password+"')":old_password,
                    this.RepID
                    });
        }
        public  bool Exists()
        {
            if ((Global.oMySql.exec_sql_no("Select count(*) from mailserver.virtual_users Where domain_id='" + this.DomainID + "' And user='"+this.User+"'")) == 0)
                return false;
            else
                return true;
        }

        public Int32 GetDomainID(String Name)
        {
            DataRow row = Global.oMySql.GetDataRow(String.Format("Select id FROM mailserver.virtual_domains Where name='{0}' ",Name), "Tmp");
            if (row == null)
            {
                return 0;
            }
            else
            {
                return (Int32) row["id"];
            }
        }
        public  void Delete()
        {
            String Sql = String.Format("Delete From mailserver.virtual_users Where domain_id = '{0}' And user='{1}'",this.DomainID,this.User);
            Global.oMySql.exec_sql(Sql);
            this.Items.DomainID = DomainID;
            this.Items.User = this.User;
            this.Items.DeleteAll();
        }

        public void DeleteByOrder(Int32 OrderID)
        {
            String Sql = "Delete From OrderTicket Where OrderID='" + OrderID + "'";
            Global.oMySql.exec_sql(Sql);
        }

        public  bool View(Int32 DomainID)
        {
            frmVieweMails oView = new frmVieweMails(DomainID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            
            return false;
        }

        public void Print()
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From OrderTicket Where ID='{0}'", ID), "Ticket"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From OrderTicketDetail Where TicketID='{0}'", ID), "TicketDetail"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Product Where Password='{0}'", this.Password), "Product"));


            TicketReport oRpt = new TicketReport();
            //ds.WriteXml("PrintTicket1.xml", XmlWriteMode.WriteSchema);
            
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();
            //oViewReport.cReport.PrintReport();
        }

        public class Line  
        {
            protected SqlBuilder oBuild;

            public Int32 ID = 0;
            public Int32 DomainID = 0;
            public String User = "";
            public Boolean Reserved;

            public String _Destination;
            public String Destination
            {
                get { return _Destination; }
                set { _Destination = value; }

            }

            private void Clear()
            {
                DomainID = 0;
                User = "";
                Destination = "";
                Reserved = false;
            }
            public bool Find(String User, Int32 DomainID)
            {
                DataRow rRow = Global.oMySql.GetDataRow("Select * From mailserver.virtual_aliases Where source='" + User + "' And domain_id='"+DomainID.ToString()+"'", "Tmp");

                if (rRow == null)
                {
                    Clear();
                    return false;
                }

                this.ID         = (Int32)rRow["ID"]; 
                this.DomainID   = (Int32)rRow["domain_id"];
                this.User       = rRow["source"].ToString();
                this.Destination = rRow["destination"].ToString();
                return true;

            }
            public void DeleteAll(Int32 OrderID)
            {
                String Sql = "Delete from mailserver.virtual_aliases Where domain_id='" + DomainID + "' And UserPacked='0'";
                Global.oMySql.exec_sql(Sql);
            }

            public  void Save()
            {

                if (Exists())
                    Update();
                else
                    Insert();
            }
            public  void Update()
            {
                FillFields();
                Global.oMySql.exec_sql(oBuild.Update(String.Format("Where source='{0}' And destination='{1}'",this.User,this.Destination)));
            }
            public  void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                FillFields();
                this.ID = Global.oMySql.exec_sql_id(oBuild.Insert());

            }

            private void FillFields()
            {
                oBuild = new SqlBuilder();

                oBuild.AddRange("mailserver.virtual_aliases", new String[] { 
                    "domain_id",
                    "source",
                    "destination",
                    "reserved"
                    
                },
                new Object[] {
                    this.DomainID,
                    this.User,
                    this.Destination,
                    (this.Reserved?"1":"0")
                });

            }
            public bool Exists()
            {
                if (Global.oMySql.exec_sql_no(String.Format("Select count(*) from mailserver.virtual_aliases Where domain_id='{0}' And source='{1}' And destination = '{2}'",this.DomainID,this.User,this.Destination)) == 0)
                    return false;
                else
                    return true;
            }
            public void Delete()
            {
                String Sql = "Delete From OrderByBrochure Where OrderID='" + this.DomainID + "'";
                Global.oMySql.exec_sql(Sql);
            }
        }
        public class _Lines : Hashlist
        {
            public DataTable dt;
            public Int32 DomainID;
            public String User;
            
            public _Lines() { }
            public void Load(Int32 DomainID, String User)
            {
                this.Clear();
                dt = oMySql.GetDataTable(String.Format("SELECT id, domain_id, source, destination FROM mailserver.virtual_aliases Where domain_id='{0}' and source='{1}'", DomainID,User));
                if (dt == null)
                {
                    this.SetColumns();
                }
                
                this.DomainID = DomainID;
                this.User = User;
               
            }



            public new void Save()
            {
                Line oLine = new Line();
                MarkRecords();
                dt.AcceptChanges();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["destination"].ToString() != "")
                    {
                        oLine.DomainID = DomainID;
                        oLine.Destination = row["destination"].ToString();
                        oLine.User = this.User;
                        oLine.Reserved = false;
                        oLine.Save();
                    }
                }
                DeleteRecords();
            }
            private void MarkRecords()
            {
                Global.oMySql.exec_sql(String.Format("Update mailserver.virtual_aliases Set reserved='1' Where source='{0}' And domain_id='{1}'",User,DomainID));
            }

            private void DeleteRecords()
            {
                Global.oMySql.exec_sql(String.Format("Delete from mailserver.virtual_aliases  Where source='{0}' And domain_id='{1}' And reserved='1'", User, DomainID));
            }

            public void DeleteAll()
            {
                MarkRecords();
                DeleteRecords();
            }
            public void AddEmpty()
            {
                DataRow Detail = dt.NewRow();

                Detail["destination"] = "";
                Detail["source"] = "";
                Detail["domain_id"] = 0;

                dt.Rows.Add(Detail);
            }

            public void SetColumns()
            {
                dt = new DataTable();

                DataColumn colWork = new DataColumn("id", Type.GetType("System.Int32"));
                // colWork.Unique = true;
                
                colWork.Caption = "id";
                colWork.ReadOnly = false;
                this.dt.Columns.Add(colWork);


                colWork = new DataColumn("domain_id", Type.GetType("System.Int32"));
                colWork.Caption = "domain_id";
                dt.Columns.Add(colWork);

                
                colWork = new DataColumn("source", Type.GetType("System.String"));
                colWork.Caption = "source";
                dt.Columns.Add(colWork);

                colWork = new DataColumn("destination", Type.GetType("System.String"));
                colWork.MaxLength = 200;
                dt.Columns.Add(colWork);

                return;
            }
            /* Hash List Support */
            public new Line this[string Key]
            {
                get { return (Line)base[Key]; }

            }
            public new Line this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Line)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new _LinesEnumerator(this);
            }

        }
        public class _LinesEnumerator : IEnumerator
        {
            public _LinesEnumerator(_Lines ar)
            {
                _ar = ar;
                _currIndex = -1;
            }
            public object Current
            {
                get
                {
                    return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                }
            }
            public bool MoveNext()
            {
                _currIndex++;
                if (_currIndex == _ar.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _currIndex = -1;
            }

            // The index of the item this enumerator applies to.
            protected int _currIndex;
            // A reference to this enumerator's associative array.
            protected _Lines _ar;


        }
    }
}
