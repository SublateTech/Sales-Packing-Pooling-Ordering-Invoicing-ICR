using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature.Reports;
using MySql.Data.MySqlClient;


namespace Signature.Classes
{
    public class PaymentProvider:Company
    {
        
        
        // Properties
        public String _ID;
        
        public String PurchaseID;
        public Double Amount;
        public String Comment;
        public String Type;
        public String Seq;
        public DateTime Date;

        //Methods

        public PaymentProvider(String CompanyID, String PurchaseID)
        {
            this.CompanyID  = CompanyID;
            this.PurchaseID = PurchaseID;
        } //Constructor

        public PaymentProvider(String CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        public override bool Find(String PaymentID)
        {
            if (PaymentID == "")
                return false;

            DataRow row = oMySql.GetDataRow("Select * From PaymentProvider Where PaymentID='" + PaymentID + "'", "PaymentProvider");
            if (row == null)
            {
                 ID = String.Empty;
                return false;
            }
            ID              = row["PaymentID"].ToString();
            Amount          = (Double) row["Amount"];
            Date            = (DateTime) row["Date"];
            Type            = row["Type"].ToString();
            Comment         = row["Comment"].ToString();

            return true;
        
        }
        public bool View(String PurchaseID)
        {
            frmViewPaymentProvider oView = new frmViewPaymentProvider(this.CompanyID, PurchaseID);
            
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                Find(ID);
                return true;

            }
            return false;
        }
        public override void Update()
        {

            String Sql = String.Format("Update PaymentProvider Set PaymentID='{0}', PurchaseID='{1}', Amount='{2}',Comment=\"{3}\",CompanyID='{4}',Type='{5}',Date='{6}'    Where PaymentID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.ID, this.PurchaseID, this.Amount, this.Comment, this.CompanyID, this.Type, this.Date.ToString("yyyy-MM-dd"));
            
            oMySql.exec_sql(Sql);

        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into PaymentProvider (PurchaseID, Amount, Comment, CompanyID, Date, Type  )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}')",
                        this.PurchaseID, this.Amount, this.Comment, this.CompanyID, this.Date.ToString("yyyy-MM-dd hh:mm:ss"), this.Type);
            Console.WriteLine(Sql);
            oMySql.exec_sql(Sql);
        }
        public  bool IfExist()
        {

            if (oMySql.exec_sql_no("Select count(*) from PaymentProvider Where PaymentID='" + this.ID + "'") == 0)
                return false;
            else
                return true;
        }
        public override void Save()
        {
           if (IfExist())
                Update();
            else
                Insert();
        }
        public override void Delete()
        {
            String Sql = "Delete From PaymentProvider Where PaymentID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        public Boolean FindByDate(DateTime Date, String PurchaseID, String Type)
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM PaymentProvider Where CompanyID='{0}' And Type='" + Type + "' And Date(Date) = '{1}' And PurchaseID='{2}'",CompanyID,Date.ToString("MM/dd/yyyy"),PurchaseID), "PaymentProvider");
            if (row == null)
            {
                ID = String.Empty;
                return false;
            }
            ID = row["PaymentID"].ToString();
            Find(ID);
            return true;
        }
        public PaymentProvider GetFirstInvoice()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM PaymentProvider Where CompanyID='{0}' And PurchaseID='{1}' And Type='I' And Amount > 0 Order By Date Asc Limit 1", CompanyID, PurchaseID), "Invoice");
            if (row == null)
            {
                return null;
            }
            ID = row["PaymentID"].ToString();
            Find(ID);
            return this;
        }
        public PaymentProvider GetLastInvoice()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM PaymentProvider Where CompanyID='{0}' And PurchaseID='{1}' And Type='I' And Amount > 0 Order By Date Desc Limit 1", CompanyID, PurchaseID), "Invoice");
            if (row == null)
            {
                return null;
            }
            ID = row["PaymentID"].ToString();
            Find(ID);
            return this;
        }
        public new String ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }

        
    
    }

}
