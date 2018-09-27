using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Reports;



namespace Signature.Classes
{
    public class TaxByState:Company
    {
        
        // Properties
        public new String ID;
        
        
        public String ProductID;
        public String StateID;
        public String Taxable;
        public Double Tax;
        
        //Methods
        public TaxByState(String CompanyID, String ProductID)
        {
            this.CompanyID = CompanyID;
            this.ProductID = ProductID;
            
        } //Constructor
        public TaxByState(String CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        public bool Find(String ProductID, String StateID)
        {
            this.ProductID = ProductID;
            return Find(StateID);
        }

        public new bool Find(String StateID)
        {
            if (StateID == "" || StateID == null)
            {
                Clear();
                return false;
            }

            DataRow row = this.oMySql.GetDataRow("Select * From Tax_By_State Where CompanyID='"+CompanyID+"' And ProductID='"+ProductID+"' And  StateID='" + StateID + "'", "TaxByState");
            if (row == null)
            {
                this.ID = "";
                this.Taxable = "";
                this.StateID = "";
                this.ProductID = "";
                this.Tax = 0.00;
                return false;
            }

            
            this.ID = row["ID"].ToString();
            this.CompanyID = row["CompanyID"].ToString();
            this.ProductID = row["ProductID"].ToString();
            this.StateID = row["StateID"].ToString();
            this.Taxable = row["Taxable"].ToString();
            this.Tax = (Double) row["Tax"]; 
         
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
            String Sql = String.Format("Update Tax_By_State Set StateID='{0}', Taxable='{1}', Tax='{2}' Where ID='" + this.ID + "'",
                this.StateID,this.Taxable,this.Tax);
            
            oMySql.exec_sql(Sql);
            
        }
        public new void Insert()
        {
            String Sql = String.Format("Insert into Tax_By_State (CompanyID, ProductID, StateID, Taxable, Tax)  Values ('{0}','{1}','{2}','{3}','{4}')",
                        this.CompanyID,this.ProductID,this.StateID,this.Taxable,this.Tax);
            oMySql.exec_sql(Sql);
        }
        private bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Tax_By_State Where CompanyID='"+CompanyID+"' And ProductID='"+ProductID+"' And StateID='"+StateID+"'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From Tax_By_State Where ID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        private void Clear()
        {
            this.ID = "";
            this.StateID = "";
            this.Taxable = "";
            this.ProductID = "";
        }
        public void Print()
        {
            frmViewReport oViewReport = new frmViewReport();


            

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable("Select * From States ", "States"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Tax_By_State Where CompanyID='{0}'", CompanyID), "TaxByState"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Product Where CompanyID='{0}'", CompanyID), "Product"));
           // ds.WriteXml("dataset124.xml", XmlWriteMode.WriteSchema);
            ItemTaxByStateReport  oRpt = new ItemTaxByStateReport();

            oRpt.SetDataSource(ds);
            Boolean isToPrinter = false;
            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName = "\\\\srv1\\Plain";
                //oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, false, 0, 0);
                //oViewReport.cReport.ReportSource = oRpt;
                //oViewReport.cReport.PrintReport();

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
        }

    }
}
