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
    public class Voicemail:Company
    {
        internal new SqlBuilder oBuild; //Reuqired
        internal new String TableName = "Rep";
        
        public new String  ID;
        public Int32  RepID;
        
       
        public Voicemail(String CompanyID):base(CompanyID)
        {
            
        }

        private void Clear()
        {
            ID="";
            RepID=0;
        
        }

        public new bool Find(String  VoicemailID)
        {
            //this.CallID = String.Empty;

            if (VoicemailID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow(String.Format("Select * From {0} Where RepID='{1}' And CompanyID='{2}'", TableName, VoicemailID,this.CompanyID), "tmp");

            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.ID           =  Row["RepID"].ToString();
            this.RepID        = (Int32) Row["ID"];
   
            
            return true;

        }

        public bool FindByRep(Int32 RepID)
        {
            //this.CallID = String.Empty;

            if (RepID == 0)
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow(String.Format("Select * From {0} Where RepID='{1}'", TableName,RepID),"tmp");

            if (Row == null)
            {
                Clear();
                return false;
            }

            return this.Find(Row["ID"].ToString());
        }

        public new void Save()
        {
            
            if (Exists() && this.ID != "")
                Update();
            else
                Insert();

            
        }
        public new void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update(String.Format("Where RepID='"+this.ID+"' And CompanyID='{0}'",this.CompanyID)));
        }
        public new void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert()).ToString();

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "ID",
                "RepID",
                "CompanyID", 
                
                },
                new Object[] {
                    this.RepID,
                    this.ID,
                    this.CompanyID,
                    
                    });
        }
        public new bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where RepID='{1}' And CompanyID='{2}'",TableName,this.ID,this.CompanyID)) == 0))
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = String.Format("Delete From {0} Where RepID='{1}' And CompanyID='{2}'",this.TableName,this.ID,this.CompanyID);
            oMySql.exec_sql(Sql);
        }

        public void DeleteBy(Int32 RepID)
        {
            String Sql = "Delete From OrderTicket Where RepID='" + RepID + "'";
            oMySql.exec_sql(Sql);
        }

        public override bool View()
        {
            frmVoicemailsView oView = new frmVoicemailsView(CompanyID);
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
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer c Left Join Orders o On c.CustomerID=o.CustomerID And c.CompanyID=o.CompanyID  Where o.ID='{0}'", this.RepID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From OrderTicket Where ID='{0}'", ID), "Ticket"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From OrderTicketDetail Where TicketID='{0}'", ID), "TicketDetail"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Orders Where ID='{0}'", this.RepID), "Orders"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Product Where ProductID='{0}'", this.ProductID), "Product"));


            TicketReport oRpt = new TicketReport();
            //ds.WriteXml("PrintTicket1.xml", XmlWriteMode.WriteSchema);
            
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();
            //oViewReport.cReport.PrintReport();
        }
    }
}
