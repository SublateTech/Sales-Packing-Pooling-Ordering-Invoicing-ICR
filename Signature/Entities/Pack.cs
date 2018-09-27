using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature;

namespace Signature.Classes
{
    public class Pack:Company
    {
        private new SqlBuilder oBuild; //Reuqired
        public String  _ID;
        public new String CompanyID;
        public Int32 _NoCopies;
        
        
        // public delegate void EventHandler (object sender, EventArgs e);
        // Define an Event based on the above Delegate
        public event EventHandler AskForPhoneChanged;
        
        // By Default, create an OnXXXX Method, to call the Event
        protected virtual void OnAskForPhoneChange(string message)
        {
            if (AskForPhoneChanged != null)
            {
                EventArgs e = new EventArgs();
                AskForPhoneChanged(this,e);
            }
        }
        
        //Properties
        #region Properties
        
        private String _Description;
        public new String ID { get { return _ID; } set { _ID = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        public Int32 NoCopies { get { return _NoCopies; } set { _NoCopies = value; } }
        #endregion

        public Pack(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
        }

        private void Clear()
        {
            ID="";
            Description = "";
            NoCopies = 0;
                
        }
        public new bool Find(String PackID)
        {
            //this.CallID = String.Empty;

            if (PackID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From Pack Where ID='" + PackID +"' And CompanyID='"+this.CompanyID+"'", "Ticket");
            
            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.ID             = Row["ID"].ToString();
            this.Description    = Row["Description"].ToString();
            this.NoCopies = (Int32)Row["NoCopies"];
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
            oMySql.exec_sql(oBuild.Update("Where ID='"+this.ID+"' And CompanyID='"+this.CompanyID+"'"));
        }
        public new void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("Pack", new String[] { 
                "CompanyID",
                "ID",
                "Description",
                "NoCopies"
                },
                new Object[] {
                    this.CompanyID,
                    this.ID,
                    this.Description,
                    this.NoCopies
                    });
        }
        public bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Pack Where ID='" + this.ID + "' And CompanyID='"+this.CompanyID+"'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From Pack Where ID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        public new virtual bool View()
        {   
            frmProductTypesView oView = new frmProductTypesView(CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
    }
}
