using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;

namespace Signature.Classes
{
    public class CustomerCall:Customer
    {
        //Properties
        #region Properties
        public String CallID;
        public Boolean _End1;
        public Boolean End1 { get { return _End1; } set { _End1 = value; } }
        public Boolean _End2;
        public Boolean End2 { get { return _End2; } set { _End2 = value; } }
        public Boolean _End3;
        public Boolean End3 { get { return _End3; } set { _End3 = value; } }
        public Boolean _End4;
        public Boolean End4 { get { return _End4; } set { _End4 = value; } }
        public Boolean _End5;
        public Boolean End5 { get { return _End5; } set { _End5 = value; } }
        public Boolean _End6;
        public Boolean End6 { get { return _End6; } set { _End6 = value; } }
        public Boolean _End7;
        public Boolean End7 { get { return _End7; } set { _End7 = value; } }
        public Boolean _PickUp1;
        public Boolean PickUp1 { get { return _PickUp1; } set { _PickUp1 = value; } }
        public Boolean _PickUp2;
        public Boolean PickUp2 { get { return _PickUp2; } set { _PickUp2 = value; } }
        public Boolean _PickUp3;
        public Boolean PickUp3 { get { return _PickUp3; } set { _PickUp3 = value; } }

        public String _Notes;
        public String Notes { get { return _Notes; } set { _Notes = value; } }

        public Boolean _EndCompleted;
        public Boolean EndCompleted { get { return _EndCompleted; } set { _EndCompleted = value; } }
        public Boolean _PickUpCompleted;
        public Boolean PickUpCompleted { get { return _PickUpCompleted; } set { _PickUpCompleted = value; } }

        public Boolean _eMailRep;
        public Boolean eMailRep { get { return _eMailRep; } set { _eMailRep = value; } }

        public Int16 _EndAttempt1;
        public Int16 EndAttempt1 { get { return _EndAttempt1; } set { _EndAttempt1 = value; } }
        public Int16 _EndAttempt2;
        public Int16 EndAttempt2 { get { return _EndAttempt2; } set { _EndAttempt2 = value; } }
        public Int16 _EndAttempt3;
        public Int16 EndAttempt3 { get { return _EndAttempt3; } set { _EndAttempt3 = value; } }
        public Int16 _EndAttempt4;
        public Int16 EndAttempt4 { get { return _EndAttempt4; } set { _EndAttempt4 = value; } }

        public Int16 _PUAttempt1;
        public Int16 PUAttempt1 { get { return _PUAttempt1; } set { _PUAttempt1 = value; } }
        public Int16 _PUAttempt2;
        public Int16 PUAttempt2 { get { return _PUAttempt2; } set { _PUAttempt2 = value; } }
        public Int16 _PUAttempt3;
        public Int16 PUAttempt3 { get { return _PUAttempt3; } set { _PUAttempt3 = value; } }
        public Int16 _PUAttempt4;
        public Int16 PUAttempt4 { get { return _PUAttempt4; } set { _PUAttempt4 = value; } }

        public String _UserID;
        public String UserID { get { return _UserID;} set { _UserID = value; }}

        private DateTime _EndDateCompleted = DateTime.Now;
        public DateTime EndDateCompleted { get { return _EndDateCompleted;} set {_EndDateCompleted = value;}}

        private DateTime _PickUpDateCompleted = DateTime.Now;
        public DateTime PickUpDateCompleted { get { return _PickUpDateCompleted; } set { _PickUpDateCompleted = value; } }

        private new SqlBuilder oBuild;
        #endregion

        public CustomerCall(String CompanyID):base(CompanyID)
        {
            
        }

        private void Clear()
        {
            End1 = false;
            End2 = false;
            End3 = false;
            End4 = false;
            End5 = false;
            End6 = false;
            End7 = false;

            eMailRep = false;

            
            PickUp1 = false;
            PickUp2 = false;
            PickUp3 = false;
            Notes = "";
            EndCompleted= false;
            PickUpCompleted= false;
            EndAttempt1 = -1;
            EndAttempt2 = -1;
            EndAttempt3 = -1;
            EndAttempt4 = -1; 
            PUAttempt1 = -1;
            PUAttempt2 = -1;
            PUAttempt3 = -1;
            PUAttempt4 = -1;
            UserID = "";
                
        }
        public bool FindCall(String CustomerID)
        {
            this.CallID = String.Empty;

            if (CustomerID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From CustomerCalls Where CustomerID='" + CustomerID + "' And CompanyID='" + CompanyID + "'", "CustomerCalls");

            if (Row == null)
            {
                Clear();
                return false;
            }

            this.CallID = Row["CallID"].ToString();

            base.Find(CustomerID);
            
            this.End1 = (Boolean)Row["End1"];
            this.End2 = (Boolean)Row["End2"];
            this.End3 = (Boolean)Row["End3"];
            this.End4 = (Boolean)Row["End4"];
            this.End5 = (Boolean)Row["End5"];
            this.End6 = (Boolean)Row["End6"];
            this.End7 = (Boolean)Row["End7"];

            this.PickUp1 = (Boolean)Row["PickUp1"];
            this.PickUp2 = (Boolean)Row["PickUp2"];
            this.PickUp3 = (Boolean)Row["PickUp3"];

            this.Notes = Row["Notes"].ToString();

            this.EndCompleted = (Boolean)Row["EndCompleted"];
            this.PickUpCompleted = (Boolean)Row["PickUpCompleted"];
            
            this.EndAttempt1 = Convert.ToInt16(Row["EndAttempt1"].ToString());
            this.EndAttempt2 = Convert.ToInt16(Row["EndAttempt2"].ToString());
            this.EndAttempt3 = Convert.ToInt16(Row["EndAttempt3"].ToString());
            this.EndAttempt4 = Convert.ToInt16(Row["EndAttempt4"].ToString());

            this.PUAttempt1 = Convert.ToInt16(Row["PUAttempt1"].ToString());
            this.PUAttempt2 = Convert.ToInt16(Row["PUAttempt2"].ToString());
            this.PUAttempt3 = Convert.ToInt16(Row["PUAttempt3"].ToString());
            this.PUAttempt4 = Convert.ToInt16(Row["PUAttempt4"].ToString());

            this.UserID = Row["UserID"].ToString();

            this.EndDateCompleted = Row["EndDateCompleted"]==DBNull.Value? DateTime.Now:(DateTime)Row["EndDateCompleted"];
            this.PickUpDateCompleted = Row["PickUpDateCompleted"] == DBNull.Value ? DateTime.Now : (DateTime)Row["PickUpDateCompleted"];

            this.eMailRep = (Boolean)Row["eMailRep"];

            return true;

        }
       
        public new void Save()
        {
            FillFields();
            if (IfExist())
                Update();
            else
                Insert();
        }
        public new void Update()
        {
           // MessageBox.Show(oBuild.Update("Where CallID='" + this.CallID + "'"));
            Global.oMySql.exec_sql(oBuild.Update("Where CallID='"+this.CallID+"'"));
        }
        public new void Insert()
        {
         //   MessageBox.Show(oBuild.Insert());
            Global.oMySql.exec_sql(oBuild.Insert());

        }

        private new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("CustomerCalls", new String[] { 
                "CompanyID", 
                "CustomerID",
                "End1","End2","End3","End4","End5","End6","End7",
                "PickUp1","PickUp2","PickUp3",
                "Notes","EndCompleted","PickUpCompleted",
                "EndAttempt1","EndAttempt2","EndAttempt3","EndAttempt4",
                "PUAttempt1","PUAttempt2","PUAttempt3","PUAttempt4",
                "UserID","eMailRep","EndDateCompleted","PickUpDateCompleted"},
                new Object[] {this.CompanyID,
                base.ID,
                End1, End2, End3, End4, End5, End6, End7, 
                PickUp1, PickUp2, PickUp3, 
                Notes, EndCompleted, PickUpCompleted,
                EndAttempt1, EndAttempt2, EndAttempt3, EndAttempt4, 
                PUAttempt1, PUAttempt2, PUAttempt3, PUAttempt4, 
                UserID,eMailRep,EndDateCompleted,PickUpDateCompleted});
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from CustomerCalls Where CallID='" + this.CallID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From CustomerCalls Where CallID='" + this.CallID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
        }



    }
}
