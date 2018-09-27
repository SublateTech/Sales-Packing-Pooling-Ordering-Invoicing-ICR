using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Signature.Classes
{
    public class Vendor:Company
    {
        
        // Properties
        public new String ID;
        private String _Name;
        private String _CompanyID;
        public String Address_1;
        public String Address_2;
        public String Address_3;
        public new String City;
        public new String State;
        public new String ZipCode;
        public String Contact;
        public new String Phone;
        public new String Fax;
        public String eMail;
        
        //Methods

        public Vendor()
        {
            this._CompanyID = base.ID;
            this.ID = "";
            
        }

        public Vendor(String CompanyID)
        {
            this._CompanyID = CompanyID;
            this.ID = "";

        } //Constructor

        public override bool Find(String VendorID)
        {
            this.ID = "";
            this._Name = "";
            
                     
            if (VendorID == "")
                return false;

            

            //MessageBox.Show("Select * From Product Where ProductID='" + ProductID + "'");
            DataRow rProduct = this.oMySql.GetDataRow("Select * From Vendor Where VendorID='"+VendorID+"' And CompanyID='" + _CompanyID + "'", "Company");
            

            if (rProduct == null)
            {

                this._Name = "No company found!";
                return false;
            }

            this.ID                 = rProduct["VendorID"].ToString();
            this._Name              = rProduct["Name"].ToString();
            this.Address_1          = rProduct["Address_1"].ToString();
            this.Address_2          = rProduct["Address_2"].ToString();
            this.Address_3          = rProduct["Address_3"].ToString();
            this.City               = rProduct["City"].ToString();
            this.ZipCode            = rProduct["ZipCode"].ToString();
            this.State              = rProduct["State"].ToString();
            this.Contact            = rProduct["Contact"].ToString();
            this.Phone              = rProduct["Phone"].ToString();
            this.Fax                = rProduct["Fax"].ToString();
            this.eMail              = rProduct["eMail"].ToString();
            return true;
        
        }
        public override bool View()
        {
            frmViewVendors oView = new frmViewVendors(_CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
        public override void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
        }
        public override void Update()
        {
            String Sql = String.Format("Update Vendor Set CompanyID='{0}', VendorID=\"{1}\", Name=\"{2}\", Address_1='{3}', City=\"{4}\", State=\"{5}\",  ZipCode='{6}', Contact=\"{7}\", Phone='{8}', Fax='{9}', eMail='{10}'   Where VendorID='" + this.ID + "' And CompanyID='" + this._CompanyID + "'",
            this._CompanyID, this.ID, this.Name, this.Address_1, this.City, this.State, this.ZipCode, this.Contact, this.Phone, this.Fax,this.eMail);
            oMySql.exec_sql(Sql);
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Vendor (CompanyID, VendorID, Name, Address_1, City, State, ZipCode, Contact, Phone, Fax, eMail)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}',\"{7}\",'{8}','{9}','{10}')",
                        this._CompanyID, this.ID, this.Name, this.Address_1, this.City, this.State, this.ZipCode, this.Contact, this.Phone, this.Fax,this.eMail);
            oMySql.exec_sql(Sql);
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Vendor Where VendorID='" + this.ID + "' And CompanyID='" + this._CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Delete()
        {
            String Sql = "Delete From Vendor Where VendorID='" + this.ID + "' And CompanyID='" + this._CompanyID + "'";
            oMySql.exec_sql(Sql);
        }

        
        public new String Name
        {
            get { return _Name; }
            set { _Name = value;  }
        }
    
    }
}
