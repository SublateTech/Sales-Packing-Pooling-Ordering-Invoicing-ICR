using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Data;


namespace Signature.Classes
{
    public class UPSLabel:Customer
    {
        public String ServiceType;
        public Double Weight = 1;
       
        //Methods
        public UPSLabel(String CompanyID):base(CompanyID)
        {
            this.ServiceType = "GROUND";
            this.CompanyID = CompanyID;
            
        } 


        public new void  Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
            
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into UPS_Label (CustomerID, Name, Address, City, State, ZipCode, Chairperson, PackageDescription, PackageWeight, ServiceType, ReturnServiceOption, BillingOption, PackageType )  Values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\")",
                         this.ID, this.Name, this.Address,this.City,this.State,this.ZipCode,this.Chairperson,"GIFTITEM",Weight,ServiceType,"Y","PREPAID","PACKAGE");
            oMySql.exec_sql(Sql);
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Prizes Where PrizeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public void DeleteAll()
        {
            String Sql = "Delete From UPS_Label";
            oMySql.exec_sql(Sql);
            
        }

    }
}
