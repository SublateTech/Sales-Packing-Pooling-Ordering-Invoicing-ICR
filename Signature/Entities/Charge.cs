using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;

using MySql.Data.MySqlClient;


namespace Signature.Classes
{
    public class Charge:Company
    {
        
        
        // Properties
        public String _ID;
        
        public String CustomerID;
        public Double Amount;
        public String Comment;
        public String Type;
        public String Seq;
        public DateTime Date;

        //Methods

        public Charge(String CompanyID, String CustomerID)
        {
            this.CompanyID  = CompanyID;
            this.CustomerID = CustomerID;
        } //Constructor

        public Charge(String CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        public override bool Find(String ChargeID)
        {
            if (ChargeID == "")
                return false;

            DataRow row = oMySql.GetDataRow("Select * From Payment Where ChargeID='" + ChargeID + "'", "Payment");
            if (row == null)
            {
                 ID = String.Empty;
                return false;
            }
            ID              = row["ChargeID"].ToString();
            Amount          = (Double) row["Amount"];
            Date            = (DateTime) row["Date"];
            Type            = row["Type"].ToString();
            Comment         = row["Comment"].ToString();

            return true;
        
        }
        public override bool View()
        {
            frmChargesView oView = new frmChargesView(this.CompanyID, CustomerID);
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

            String Sql = String.Format("Update Payment Set ChargeID='{0}', CustomerID='{1}', Amount='{2}',Comment=\"{3}\",CompanyID='{4}',Type='{5}',Date='{6}'    Where ChargeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.ID, this.CustomerID, this.Amount, this.Comment, this.CompanyID, this.Type, this.Date.ToString("yyyy-MM-dd"));
            
            oMySql.exec_sql(Sql);

        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Payment (CustomerID, Amount, Comment, CompanyID, Date, Type  )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}')",
                        this.CustomerID, this.Amount, this.Comment, this.CompanyID, this.Date.ToString("yyyy-MM-dd hh:mm:ss"), this.Type);
            Console.WriteLine(Sql);
            oMySql.exec_sql(Sql);
        }
        public  bool IfExist()
        {

            if (oMySql.exec_sql_no("Select count(*) from Payment Where ChargeID='" + this.ID + "'") == 0)
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
            String Sql = "Delete From Payment Where ChargeID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        public Boolean FindByDate(DateTime Date, String CustomerID, String Type)
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM Payment Where CompanyID='{0}' And Type='" + Type + "' And Date(Date) = '{1}' And CustomerID='{2}'",CompanyID,Date.ToString("MM/dd/yyyy"),CustomerID), "Payment");
            if (row == null)
            {
                ID = String.Empty;
                return false;
            }
            ID = row["ChargeID"].ToString();
            Find(ID);
            return true;
        }
        public Charge GetFirstInvoice()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM Payment Where CompanyID='{0}' And CustomerID='{1}' And Type='I' And Amount > 0 Order By Date Asc Limit 1", CompanyID, CustomerID), "Invoice");
            if (row == null)
            {
                return null;
            }
            ID = row["ChargeID"].ToString();
            Find(ID);
            return this;
        }
        public Charge GetLastInvoice()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT * FROM Payment Where CompanyID='{0}' And CustomerID='{1}' And Type='I' And Amount > 0 Order By Date Desc Limit 1", CompanyID, CustomerID), "Invoice");
            if (row == null)
            {
                return null;
            }
            ID = row["ChargeID"].ToString();
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

    public class RepCharge : Company
    {
        internal new String TableName = "RepCharges";
        internal new SqlBuilder oBuild;

        public Int32    ChargeID;
        public Double   Amount;
        public String   Description;
        public DateTime Date;
        public Int32    RepID;


        public RepCharge(String CompanyID)
            : base(CompanyID)
        {
            this.CompanyID = CompanyID;
        }

        private void Clear()
        {
            Amount = 0.00;
            Description = "";
            Date = DateTime.Now;
            RepID = 0;
        }


        public bool Find(Int32 ChargeID)
        {
            if (ChargeID == 0)
            {
                this.Clear();
                return false;
            }

            this.ChargeID = ChargeID;
            DataRow row = this.oMySql.GetDataRow(String.Format("Select * From {0} Where ChargeID='{1}'", this.TableName,this.ChargeID), "Company");


            if (row == null)
            {
                this.Clear();
                return false;
            }

            this.Amount         = (Double) row["Charge"];
            this.Description    = row["Description"].ToString();
            this.RepID          = (Int32)row["Charge"];
            this.CompanyID      = row["CompanyID"].ToString();
            
            return true;

        }

        public new void Save()
        {
            
            if (Exists())

                Update();
            else
                Insert();
        }
        public new void Update()
        {
            FillFields();
            Global.oMySql.exec_sql(oBuild.Update("Where ChargeID='" + this.ChargeID + "'"));
        }
        public new void Insert()
        {
            //   MessageBox.Show(oBuild.Insert());
            FillFields();
            this.ChargeID = Global.oMySql.exec_sql_id(oBuild.Insert());
        }
        private new void FillFields()
        {
            oBuild = new SqlBuilder();

            oBuild.AddRange(this.TableName, new String[] { 
                    "CompanyID", 
                    "RepID",
                    "Charge",
                    "Description",
                    "Date"
                },
            new Object[] {
                    this.CompanyID,
                    this.RepID,
                    this.Amount,
                    this.Description,
                    this.Date
                });

        }
        public new bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where ChargeID='{1}'", this.TableName, this.ChargeID))) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = String.Format("Delete From {0} Where ChargeID='{1}'", this.TableName, this.ChargeID);
            oMySql.exec_sql(Sql);
        }
    }
}
