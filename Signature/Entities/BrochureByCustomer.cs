using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Reports;



namespace Signature.Classes
{
    public class BrochureByCustomer:Company
    {
        
        
        // Properties
        public new String ID;
        
        
        private String CustomerID;
        public String BrochureID;
        public Double ProfitPercent;
        public Double Code;
        public Double Retail;
        public Int32 Sellers;
        public Double TaxAmount;
        public Double InvoiceAmount;
        public Double FormerInvoiceAmount;
        public Double ProfitAmount;
        public Int32 Items;
        public Boolean Packed;
        public Boolean Scanned;
        public Int32 NumberPallets;
        public Double RetailFee;
        public Int32 Seq;

        //Methods
        public BrochureByCustomer(String CustomerID)
        {
            this.CompanyID = base.ID;
            this.CustomerID = CustomerID;

        }
        public BrochureByCustomer(String CompanyID, String CustomerID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;
            
        } //Constructor
        public new bool Find(String BrochureID)
        {
            if (BrochureID == "" || BrochureID == null)
            {
                Clear();
                return false;
            }

            DataRow row = this.oMySql.GetDataRow("Select * From BrochureByCustomer Where CompanyID='"+CompanyID+"' And CustomerID='"+CustomerID+"' And  BrochureID='" + BrochureID + "'", "BrochureByCustomer");
            if (row == null)
            {
                this.ID = "";
                return false;
            }

            
            this.ID = row["ID"].ToString();
            this.CompanyID = row["CompanyID"].ToString();
            this.CustomerID = row["CustomerID"].ToString();
            this.BrochureID = row["BrochureID"].ToString();
            this.ProfitPercent = (Double) row["ProfitPercent"];
            this.Code = (Double)row["Code"];
            this.Retail = (Double)row["Retail"];
            this.Sellers = (Int32)row["NoSellers"];
            this.TaxAmount = (Double)row["TaxAmount"];
            this.InvoiceAmount = (Double)row["InvoiceAmount"];
            this.ProfitAmount = (Double)row["ProfitAmount"];
            this.Items = (Int32)row["NoItems"];
            this.NumberPallets = (Int32)row["NumberPallets"];
            this.Packed = (Boolean)row["Packed"];
            this.Scanned = (Boolean)row["Scanned"];
            this.Seq = (Int32)row["Seq"];
         
            return true;
        
        }
        public new void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
            
        }
        public new void Update()
        {
            String Sql = String.Format("Update BrochureByCustomer Set ProfitPercent='{0}', CODE='{1}',Retail='{2}',NoSellers='{3}',TaxAmount='{4}',InvoiceAmount='{5}',NoItems='{6}',ProfitAmount='{7}',FormerInvoiceAmount='{8}',Deleted='0', ImprintingFee='{9}', Seq='{10}' Where CompanyID='" + this.CompanyID + "' And CustomerID='"+this.CustomerID+"' And BrochureID='"+this.BrochureID+"'",
            this.ProfitPercent, this.Code, this.Retail, this.Sellers,this.TaxAmount,this.InvoiceAmount,this.Items,this.ProfitAmount,this.FormerInvoiceAmount,this.RetailFee,this.Seq);
            
            oMySql.exec_sql(Sql);
            
        }
        public new void Insert()
        {
            String Sql = String.Format("Insert into BrochureByCustomer (CompanyID, CustomerID, BrochureID, ProfitPercent,CODE,Retail,NoSellers,TaxAmount,InvoiceAmount,NoItems,ProfitAmount, FormerInvoiceAmount, ImprintingFee, Seq)  Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
                        this.CompanyID, this.CustomerID, this.BrochureID,this.ProfitPercent,this.Code,this.Retail,this.Sellers,this.TaxAmount,this.InvoiceAmount,this.Items,this.ProfitAmount,this.FormerInvoiceAmount,this.RetailFee,this.Seq);
            oMySql.exec_sql(Sql);
        }
        private bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from BrochureByCustomer Where CompanyID='" + this.CompanyID + "' And CustomerID='"+this.CustomerID+"' And BrochureID='"+this.BrochureID+"'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From BrochureByCustomer Where ID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        private void Clear()
        {
            this.ID = "";
            this.ProfitPercent = 0;
            this.Code = 0;
            this.Retail = 0;
            this.Sellers = 0;
            this.TaxAmount = 0;
            this.InvoiceAmount = 0;
            this.FormerInvoiceAmount = 0;
            this.Items = 0;
            this.RetailFee = 0;
            this.Seq = 0;
        }

    }
}
