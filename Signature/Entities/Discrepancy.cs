using System;
using System.Collections;
using System.Text;
using Signature.Data;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;


namespace Signature.Classes
{
    public class Discrepancy : Order
    {
        private String _Company = null;
        public  String LetterText = null;
        new public DateTime Date;
        
        public LinePrint oPrint;
        public int CurPage = 0;

        public enum DiscrepancyActivity
        {
            NoAction = 0,
            Checked = 1,
            Busy = 2
        }

        public Discrepancy(String CompanyID) : base(CompanyID)
        {
            _Company = CompanyID;
        }

        public  bool FindText(Int32 OrderID)
        {
            //Clear();
            DataRow rOrder = this.oMySql.GetDataRow("Select * From Disc_Letter Where OrderID=" + OrderID , "Orders");

            if (rOrder == null)
            {
                return false;
            }

           // this.OrderID = (Int32)rOrder["OrderID"];
           // this.Teacher = rOrder["Teacher"].ToString();
           // this.Student = rOrder["Student"].ToString();
            this.Date           = (DateTime)rOrder["Date"];
            byte[] byteBLOBData = (Byte[])(rOrder["Text"]);
            this.LetterText     = System.Text.Encoding.UTF8.GetString(byteBLOBData); 
            return true;
        }

        new public void Clear()
        {
            //this.OrderID = 0;
            this.Teacher = null;
            this.Student = null;
            this.Date = DateTime.Now;
            this.LetterText = null;
        }

        public Int32 GetStatus(String CustomerID, DiscrepancyActivity dActivity)
        {
            String Sql = String.Format("Select count(*) From Orders Where CompanyID='{0}' And CustomerID = '{1}' And Discrepancy = '{2}')", _Company, CustomerID, (int) dActivity);
            return oMySql.exec_sql_no(Sql);
        }
        public Int32 GetNextOrder(String CustomerID)
        {
            String Sql = String.Format("Select ID From Orders Where CompanyID='{0}' And CustomerID = '{1}' And ABS(round(Collected - (Retail+Tax),2)) > 0 And Discrepancy = '0' Order by Teacher, Student LIMIT 1", _Company, CustomerID);
          // Console.WriteLine(Sql);
            DataRow Row = oMySql.GetDataRow(Sql, "Tmp");
            if (Row != null)
            {
                ID = Row["ID"].ToString();
                
                return (Int32)Row["ID"];
            }
            else
                return 0;
        }


        public void SetStatus(DiscrepancyActivity dActivity)
        {

           oMySql.exec_sql(String.Format("Update Orders Set Discrepancy='{0}' Where ID={1}",(int)dActivity, ID.ToString()));

        }
        

        private String cv_phone( String phone)
	{
		if (phone.Length==10)
			{
			phone = "("+phone.Substring(0,3)+") "+phone.Substring(3,3)+"-"+phone.Substring(6,4);
					
			}
		if (phone.Trim().Length==7)
			{
			phone = phone.Substring(0,3)+"-"+phone.Substring(3,4);
			}

		return phone;
	
	}
        new public void Save()
        {
            this.SetStatus(DiscrepancyActivity.Checked);
            if (IfExist())
                Update();
            else
                Insert();
        }
        public  bool IfExist()
        {
            if (oMySql.exec_sql_no(String.Format("Select count(*) from Disc_Letter Where OrderID={0}",this.ID)) == 0)
            {
                return false;
            }
            return true;
        }
        new private void Update()
        {
            this.LetterText = this.LetterText.Replace("\"", "\\\"");
            this.LetterText = this.LetterText.Replace("'", "\\'");
            String Sql = String.Format("Update Disc_Letter  Set  Date=NOW(), Text=\"{0}\" Where OrderID={1}",
                   this.LetterText, this.ID);
            oMySql.exec_sql_afected(Sql);
        }
        new private void Insert()
        {
            this.LetterText = this.LetterText.Replace("\"","\\\"");
            this.LetterText = this.LetterText.Replace("'", "\\'");
            String Sql = String.Format("Insert into Disc_Letter (OrderID, Date, Text, CustomerID, CompanyID)  Values (\"{0}\",NOW(),'{1}','{2}','{3}')",
                    ID, this.LetterText, this.CustomerID, this.CompanyID);
            oMySql.exec_sql_afected(Sql);
        }
    }
    
}
