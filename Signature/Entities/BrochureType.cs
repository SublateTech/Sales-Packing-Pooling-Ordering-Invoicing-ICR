using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature;

namespace Signature.Classes
{
    public class BrochureType:Customer
    {
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
        internal String _ID;
        public new String ID { get { return _ID; } set { _ID = value; } }

        private  Boolean _AskForPhone;
        public Boolean AskForPhone { get { return _AskForPhone; } set { _AskForPhone = value; } }

        private Int32 _NumberOfPrints;
        public Int32 NumberOfPrints    {   get { return _NumberOfPrints; }  set { _NumberOfPrints = value; } }

        private String _Description;
        public String Description { get { return _Description; } set { _Description = value; } }

        private new SqlBuilder oBuild;


        #endregion

        public BrochureType(String CompanyID):base(CompanyID)
        {
            
        }

        private void Clear()
        {
         
                
        }
        public new bool Find(String BrochureTypeID)
        {
            //this.CallID = String.Empty;

            if (BrochureTypeID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From BrochureType Where BrochureTypeID='" + BrochureTypeID + "' And CompanyID='" + CompanyID + "'", "BrochureType");

            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.ID = Row["BrochureTypeID"].ToString();
            this.AskForPhone = (Boolean) Row["AskForPhone"];
            this.NumberOfPrints   = (Int32) Row["NoPrint"];
            this.Description = (String)Row["Description"];
            
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
            oMySql.exec_sql(oBuild.Update("Where BrochureTypeID='"+this.ID+"'"));
        }
        public new void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("BrochureType", new String[] { 
                "CompanyID",
                "Description",
                "BrochureTypeID", 
                "AskForPhone",
                "NoPrint"
                },
                new Object[] {
                    this.CompanyID,
                    this.Description,
                    this.ID,
                    this.AskForPhone?'1':'0',
                    this.NumberOfPrints});
        }
        public bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from BrochureType Where BrochureTypeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From BrochureType Where BrochureTypeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
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
