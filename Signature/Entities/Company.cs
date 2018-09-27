using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Signature.Reports;
using Signature.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;

using CrystalDecisions.Shared;

using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

using System.Text.RegularExpressions;


namespace Signature.Classes
{
    public enum PrintTo
    {
        Nothing = 0,
        Printer = 1,
        Viewer  = 2,
        File    = 3
    }
    
    public class Company //:BaseObject
    {

        internal SqlBuilder oBuild; //Reuqired
        internal String TableName = "Company";

        #region  Properties
        public MySQL oMySql = Global.oMySql;
        private String  _ID;
        public  String  CompanyID;
        public String  Name;
        /*
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        */
        public String InvoiceStoreProcdure;
        public String Address;
        public String City;
        public String ZipCode;
        public String State;
        public String Phone;
        public String Fax;
        public Boolean IsBrochureControl = false;
        public Boolean IsExternal = false;
        public Boolean IsGPI = false;
        public String ID
        {
            get { return _ID; }
            set { _ID = value; CompanyID = value; }
        }
        #endregion

        #region Methods
        //Methods
        public Company(Company oCompany)
        {
            this.ID = oCompany.ID;
            this.Name = oCompany.Name;
            this.oMySql = oCompany.oMySql;

        }
        public Company()
        {
            this.ID = Global.GetParameter("CurrentCompany");
            this.Find(ID);

        } //Constructor
        public Company(String CompanyID)
        {
            this.ID = CompanyID;
            this.Find(ID);

        } //Constructor
        public bool IsGiftAvenue
        {
            get { return this.CompanyID.Length==0? false: (this.CompanyID.Substring(0, 2) == "GA") ? true : false; }
        }
        public bool IsWebCustomer
        {
            get { return this.CompanyID.Substring(0, 2) == "__" ? true : false; }
        }

        public virtual bool Find(String CompanyID)
        {
            this.ID = "";
            this.Name = "";
                     
            if (CompanyID == "")
                return false;

            //MessageBox.Show("Select * From Product Where ProductID='" + ProductID + "'");
            DataRow rProduct = this.oMySql.GetDataRow("Select * From Company Where CompanyID='" + CompanyID + "'", "Company");

            if (rProduct == null)
            {
                this.Name  = "No company found!";
                return false;
            }

            this.ID         = rProduct["CompanyID"].ToString();
            this.Name       = rProduct["Name"].ToString();
            this.Address    = rProduct["Address"].ToString();
            this.IsExternal = (Boolean)rProduct["IsExternal"];
            this.IsGPI      = (Boolean)rProduct["IsGPI"];
            this.InvoiceStoreProcdure = rProduct["InvoiceStoreProcedure"].ToString();
         //   this.IsBrochureControl = (Boolean)rProduct["IsBrochureControl"];

            return true;
        }
        public virtual bool View()
        {
            frmViewCompanies oView = new frmViewCompanies();
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
        public virtual bool ViewAll()
        {
            frmViewCompanies oView = new frmViewCompanies(true);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
        public virtual void Save()
        {

            if (Exists() && this.ID != "")
                Update();
            else
                Insert();


        }
        public virtual void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update(String.Format("Where CompanyID='{0}'", this.ID)));
        }
        public virtual void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert()).ToString();

        }
        internal void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "CompanyID",
                "Name",
                "Address",
                "IsExternal",
                "IsGPI"
                },
                new Object[] {
                    this.ID,
                    this.Name,
                    this.Address,
                    this.IsExternal ? "1":"0",
                    this.IsGPI ? "1":"0"
                    });
        }
        public bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CompanyID='{1}'", TableName, this.ID)) == 0))
                return false;
            else
                return true;
        }
        public virtual void Delete()
        {
          //  String Sql = String.Format("Delete From {0} Where CompanyID='{1}'", this.TableName, this.ID);
          //  oMySql.exec_sql(Sql);
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CompanyID='{1}'", "Orders", this.ID)) > 0))
                MessageBox.Show("You cannot delete this company, because it still has some orders");
            else
                //MessageBox.Show(String.Format("CALL SDExport('{0}','{0}','D')", this.ID));
                oMySql.exec_sql(String.Format("CALL SDExport('{0}','{0}','D')", this.ID));
        }
        public void SplitBrochures()
        {
            DataTable dt = oMySql.GetDataTable("Select * from Customer Where CompanyID='"+ID+"'", "Tmp");
            //DataTable dt = oMySql.GetDataTable("Select CompanyID,CustomerID,BrochureID,BrochureID_2,Retail,RetailBrochure_2,ProfitPercent,ProfitBrochure_2,CODE1,CODE3,NoSellers,NoItems, ParentPickUpDate,PickUpDate, StartDate, EndDate,SignedDate,DeliveryDate,ReturnedProductDate,ShipDate from Customer Where CompanyID='" + ID + "'", "Tmp");

            foreach (DataRow row in dt.Rows)
            {   
                if (row["BrochureID"].ToString() != "")
                {
                    if (oMySql.exec_sql_no(String.Format("Select count(*) from BrochureByCustomer Where BrochureID='{0}' And CompanyID='{1}' And CustomerID='{2}'", row["BrochureID"].ToString(), row["CompanyID"].ToString(), row["CustomerID"].ToString())) == 0)
                    {
                        oMySql.exec_sql(String.Format("Insert into BrochureByCustomer (BrochureID, CustomerID, CompanyID, Retail, ProfitPercent,CODE,NoSellers,NoItems)  Values ('{0}',\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}')",
                        row["BrochureID"].ToString(), row["CustomerID"].ToString(), row["CompanyID"].ToString(), ((Double)row["Retail"] - (Double)row["RetailBrochure_2"]).ToString(), row["ProfitPercent"].ToString(), row["CODE1"].ToString(), row["NoSellers"].ToString(), row["NoItems"].ToString()));
                    }
                    else
                    {

                        oMySql.exec_sql(String.Format("Update BrochureByCustomer Set  Retail='{0}',ProfitPercent='{1}',CODE='{2}',NoSellers='{3}',NoItems='{4}'  Where CompanyID='" + ID + "' And BrochureID='" + row["BrochureID"].ToString() + "' And CustomerID='" + row["CustomerID"].ToString() + "'",
                                                                                ((Double)row["Retail"] - (Double)row["RetailBrochure_2"]).ToString(), row["ProfitPercent"].ToString(), row["CODE1"].ToString(), row["NoSellers"].ToString(), row["NoItems"].ToString()));

                    }

                }
                if (row["BrochureID_2"].ToString() != "")
                {
                    if (oMySql.exec_sql_no(String.Format("Select count(*) from BrochureByCustomer Where BrochureID='{0}' And CompanyID='{1}' And CustomerID='{2}'", row["BrochureID_2"].ToString(), row["CompanyID"].ToString(), row["CustomerID"].ToString())) == 0)
                    {
                        oMySql.exec_sql(String.Format("Insert into BrochureByCustomer (BrochureID, CustomerID, CompanyID, Retail, ProfitPercent,CODE)  Values ('{0}',\"{1}\",\"{2}\",'{3}','{4}','{5}')",
                        row["BrochureID_2"].ToString(), row["CustomerID"].ToString(), row["CompanyID"].ToString(), row["RetailBrochure_2"].ToString(), row["ProfitBrochure_2"].ToString(), row["CODE3"].ToString()));
                    }
                    else
                    {

                        oMySql.exec_sql(String.Format("Update BrochureByCustomer Set  Retail='{0}',ProfitPercent='{1}',CODE='{2}'  Where CompanyID='" + ID + "' And BrochureID='" + row["BrochureID_2"].ToString() + "' And CustomerID='" + row["CustomerID"].ToString() + "'",
                                                                                row["RetailBrochure_2"].ToString(), row["ProfitBrochure_2"].ToString(), row["CODE3"].ToString()));

                    }

                }

            }

        }
        public void UpdateCommitedAmount()
        {
             DataTable dt = oMySql.GetDataTable("SELECT distinct(ProductID), sum(Quantity) as Quantity FROM OrderDetail Where CompanyID='"+ID+"' Group By ProductID", "Tmp");

             Product oProduct = new Product(ID);
             foreach (DataRow row in dt.Rows)
             {
                 if (oProduct.Find(row["ProductID"].ToString()))
                 {
                     
                     oProduct.Committed = Convert.ToInt32(row["Quantity"].ToString());
                     oProduct.UpdateInventory();
                 }

             }
        }
        private DataTable CreateHeaderTable()
        {
            DataTable dtHeader = new DataTable("Invoices");

            DataColumn colWork = new DataColumn("CustomerID", Type.GetType("System.String"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("PreviousInvoice", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Added", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Payments", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Tax", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Due", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Retail", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("NetProfit", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Charges", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            colWork = new DataColumn("Items", Type.GetType("System.Double"));
            dtHeader.Columns.Add(colWork);

            return dtHeader;
        }
        public void CreateClientSideCompany()
        {
            Global.oMySql.exec_sql(String.Format("CALL SDExport('{0}','__{0}','I');", this.ID));
            //Global.oMySql.exec_sql(String.Format("CALL SDExport('{0}','__{0}','I');", Global.CurrrentCompany));
            //MessageBox.Show(String.Format("CALL SDExport('{0}','__{0}','I')", Global.CurrrentCompany));
            Global.ShowNotifier("Client Side Company has been created");
        }
        #endregion

        #region Print
        public void PrintInvoiceList()
        {
            DataSet ds = new DataSet();

            Invoice oInvoice = new Invoice(ID);
            DataTable dtCustomers =  oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}'",ID),"Customer");

            ds.Tables.Add(dtCustomers);

            DataTable dtReport = CreateHeaderTable();
            DataRow row = dtReport.NewRow();
            int i = 0;
            foreach(DataRow dvrow in dtCustomers.Rows)
            {
                if (dvrow["CustomerID"].ToString() == "00012")
                    continue;
                oInvoice.Find(dvrow["CustomerID"].ToString());
                row = dtReport.NewRow();
                if (oInvoice.GetCurrentTotalsByBrochure() != null)
                {
                    row["CustomerID"] = oInvoice.ID;
                    row["PreviousInvoice"] = oInvoice.LastInvoicedAmount;
                    row["Added"] = oInvoice.AddedAmount - oInvoice.ChargesAmount;
                    row["Payments"] = oInvoice.PaymentsAmount;
                    row["Tax"] = oInvoice.TaxAmount;
                    row["NetProfit"] = oInvoice.ProfitAmount;
                    row["Charges"] = oInvoice.ChargesAmount;
                    row["Items"] = oInvoice.NoItems;
                    row["Due"] = oInvoice.AmountDue;
                    row["Retail"] = oInvoice.Retail;

                }
                else
                {
                    row["CustomerID"] = oInvoice.ID;
                    row["PreviousInvoice"] = 0;
                    row["Added"] = 0;
                    row["Payments"] = 0;
                    row["Tax"] = 0;
                    row["NetProfit"] = 0;
                    row["Charges"] = 0;
                    row["Items"] = 0;
                    row["Due"] = 0;
                }
                    
                dtReport.Rows.Add(row);
                i++;
                //if (i == 250)
                //    break;
            }

            ds.Tables.Add(dtReport); //Detail

            

            frmViewReport oViewReport = new frmViewReport();
            //ds.WriteXml("dataset68.xml", XmlWriteMode.WriteSchema);
            //InvoiceDiscrepancy_ oRpt= new InvoiceDiscrepancy_();
            InvoiceDiscrepancyDetail_ oRpt = new InvoiceDiscrepancyDetail_();
            oRpt.SetDataSource(ds);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            

        }
        public void PrintStatementList()
        {

            DataSet ds = new DataSet();

            Invoice oInvoice = new Invoice(ID);
            DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}'", ID), "Customer");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("Select CustomerID, Min(Date), Max(Date), Sum(Amount)  FROM Payment  Where CompanyID='{0}' Group By CustomerID  HAVING Sum(Amount)<>0", ID), "Statements");

            ds.Tables.Add(dtCustomers);
            ds.Tables.Add(dtStatements);

            frmViewReport oViewReport = new frmViewReport();
       //     ds.WriteXml("StatementList2.xml", XmlWriteMode.WriteSchema);
            
            
            
            CompanyStatementList oRpt = new CompanyStatementList();
         
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();


        }
        public void PrintGAPaymentList(Boolean Paid, Boolean byRep)
        {
            DataTable dt = Global.oMySql.GetDataTable(String.Format("SELECT  c.CustomerID , c.CompanyID, sum(p.Amount)*-1 as Total from Customer c Left Join Payment p On c.CompanyID=p.CompanyID And p.CustomerID=c.CustomerID  And p.Type='P' Where c.CompanyID='{0}'  Group By c.CustomerID Having Total is null",this.ID),"NoPaid");
            DataSet ds = Global.oMySql.GetDataset(String.Format("CALL get_ga_tables1('{0}','{1}');", this.ID,Paid?"1":"0"));

            ds.Tables[0].TableName = "Customer";
            ds.Tables[1].TableName = "Orders";
            ds.Tables[2].TableName = "Re-Orders";
            ds.Tables[3].TableName = "Payments";
            ds.Tables[4].TableName = "Rep";
            
            
            frmViewReport oViewReport = new frmViewReport();
            ds.WriteXml("GAPaymentList5.xml", XmlWriteMode.WriteSchema);

            GA_CompanyPaymentsList oRpt = new GA_CompanyPaymentsList();
            GA_CompanyPaymentsListByRep oRpt1 = new GA_CompanyPaymentsListByRep();
            /*
            int x = 0;
            foreach (DataRow row in ds.Tables["Payments"].Rows)
            {

                if (row["Total"] == null)
                    x++;
                else if (Convert.ToDecimal(row["Total"].ToString()) == 0)
                    x++;
                
            }
            */

            Int32 x = dt.Rows.Count;

            if (!byRep)
            {
                oRpt.SetDataSource(ds);
                oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
                oRpt.SetParameterValue("NoPaid", x);
                oViewReport.cReport.ReportSource = oRpt;
            }
            else
            {
                oRpt1.SetDataSource(ds);
                oRpt1.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
                oRpt1.SetParameterValue("NoPaid", x);
                oViewReport.cReport.ReportSource = oRpt1;
            }
            
            oViewReport.ShowDialog();
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintGAProductReorded()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Product Where CompanyID='{0}'", this.ID), "Product"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT ProductID, sum(Quantity) FROM OrderDetail od  Left Join Orders o On o.ID=od.OrderID Where od.CompanyID='{0}' And Teacher like '%RE-ORDER%' Group By ProductID", this.ID), "Re-orders"));

//            ds.WriteXmlSchema("PrintGAProductReorded.xml");

            frmViewReport oViewReport = new frmViewReport();

            GAReordedItems oRpt = new GAReordedItems();

            oRpt.SetDataSource(ds);

           // oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintGACashRegister()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT CustomerID, Name, Address, City, State, ZipCode, CashRegisters FROM Customer Where CompanyID='{0}' And CashRegisters >0", this.ID), "Customers"));

            //ds.WriteXmlSchema("PrintGACashRegister.xml");

            frmViewReport oViewReport = new frmViewReport();

            GACashRegister oRpt = new GACashRegister();

            oRpt.SetDataSource(ds);

            // oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintProductReturned()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *,cg.* FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And cg.ProductReturned='0' Order By c.DeliveryDate", this.ID), "Customer"));

          //  ds.WriteXmlSchema("PrintProductReturned.xml");

            frmViewReport oViewReport = new frmViewReport();

            GAProductReturnedReport oRpt = new GAProductReturnedReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintGACoupon()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *,cg.* FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And cg.Coupon='1' Order By c.DeliveryDate", this.ID), "Customer"));

            //ds.WriteXmlSchema("PrintGACoupon.xml");

            frmViewReport oViewReport = new frmViewReport();

            GACouponReport oRpt = new GACouponReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintRegisterReturned()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *,cg.* FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And cg.RegisterReturned='0' And c.CashRegisters > 0 Order By c.DeliveryDate", this.ID), "Customer"));

        //   ds.WriteXmlSchema("PrintRegisterReturned.xml");

            frmViewReport oViewReport = new frmViewReport();

            GARegisterReturnedReport oRpt = new GARegisterReturnedReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintUserRankingReport(String Process, DateTime Date )
        {

            DataSet ds = new DataSet();
            //DataTable dt = oMySql.GetDataTable(String.Format("SELECT User, Count(OrderID) as Orders, Sum(Items) as Items, sum(Boxes) as Boxes FROM OrderActivity Where Date(Date)=Date({0}) And Process=process1 And CompanyID=company  Group By User",Date.ToString("yyyy-mm-dd"),Process,ID,"Ranking");
            DataTable dt = oMySql.GetDataTable(String.Format("Call RankingByUser('{0}','{1}',Date('{2}'))", ID,Process,Date.ToString("yyyy-MM-dd")), "Ranking");
//            Console.WriteLine(String.Format("Call RankingByUser('{0}','{1}',Date('{2}'))", ID, Process, Date.ToString("yyyy-MM-dd")));

            ds.Tables.Add(dt);

            frmViewReport oViewReport = new frmViewReport();
           // ds.WriteXml("PrintUserRankingReport.xml", XmlWriteMode.WriteSchema);


            UserRankingReport oRpt = new UserRankingReport();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            
            



            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();



        }
        public void PrintRepRankingReport()
        {

            DataSet ds = new DataSet();
            DataTable dt = oMySql.GetDataTable(String.Format("SELECT c.RepID, r.Name, Sum(Retail) as Retail, sum(NoSellers) as NoSellers, count(*) as Contracts, sum(InvoicedAmount) as Invoiced, Sum(Signed) as TotalSigned,  Sum( if(Retail > 0, Signed,0)) as Signed  FROM Customer c Left Join Reps r On c.Rep_ID=r.ID  Where c.CompanyID='{0}' Group By c.RepID Order By r.Name", ID), "Ranking");

            DataColumn colWork = new DataColumn("Participation", System.Type.GetType("System.Double"));
            dt.Columns.Add(colWork);

            Double Total = 0;
            Int32 RepsNoZero = 0;
            foreach (DataRow row in dt.Rows)
            {
                Total += (Double)row["Retail"];
                if ((Double)row["Retail"] > 0)
                    RepsNoZero++;
            }
            ds.Tables.Add(dt);

            frmViewReport oViewReport = new frmViewReport();
            ds.WriteXml("PrintRepRankingReport2.xml", XmlWriteMode.WriteSchema);


            RepRankingReport oRpt = new RepRankingReport();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TotalRetail", Total);
            oRpt.SetParameterValue("RepsNoZero", RepsNoZero);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();



        }
        public void PrintAllInvoices()
        {
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And AddedAmount <> 0", ID), "Customer");
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Where c.CompanyID='{0}'", this.CompanyID), "Customer");
            DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT c.CustomerID, Name, Min(Date(p.Date)) as FirstDate FROM Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID  Where c.CompanyID='{0}' And p.Type = 'I' Group by c.CustomerID", this.CompanyID), "Customer");
            Invoice oCustomer = new Invoice(this.CompanyID);
            int x = 0;
            foreach (DataRow row in dtCustomers.Rows)
            {   
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    Global.ShowNotifier("Processing Invoice for :\r\n" + oCustomer.Name + "\r\n" + x.ToString() + " of " + dtCustomers.Rows.Count.ToString());
                    oCustomer.GetCurrentTotalsByBrochure();
                   // if (oCustomer.AmountDue > 5.00)
                    {
                        oCustomer.Print(PrintTo.Nothing, "\\\\srv1\\Plain", "PLEASE REMIT ENTIRE WHITE COPIES WITH PAYMENT", false);
                    }
                    x++;
                    //if (x == 2)
                    //    break;
                }
            }
            MessageBox.Show("Done!");
        }
        public void PrintAllStatemets()
        {   
            DataTable dtStatements = oMySql.GetDataTable(String.Format("Select CustomerID, Min(Date), Max(Date), Sum(Amount) as Amount  FROM Payment  Where CompanyID='{0}' Group By CustomerID  HAVING Sum(Amount)<0", ID), "Statements");
            Customer oCustomer = new Customer(this.CompanyID);
            foreach (DataRow row in dtStatements.Rows)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    Global.ShowNotifier("Processing:\r\n" + oCustomer.Name);
                    oCustomer.PrintStatement("\\\\srv1\\Plain",PrinterDevice.Printer);
                }
            }
            MessageBox.Show("Done!");
        }
        public void PrintAllRepCommissionReport()
        {
            DataTable dtStatements = oMySql.GetDataTable(String.Format("Select Rep_ID, RepID, r.Name from Customer c Left Join Reps r On c.Rep_ID=r.ID Where CompanyID='{0}' And Rep_ID >0 Group By RepID Order By r.Name", ID), "Reps");
            Rep oRep = new Rep(this.ID);
            foreach (DataRow row in dtStatements.Rows)
            {
                if (oRep.Find((Int32) row["Rep_ID"]))
                {
                    Global.ShowNotifier("Processing:\r\n" + oRep.Name);
                    oRep.PrintCommissionReport(row["RepID"].ToString(),row["RepID"].ToString(),"\\\\srv1\\Plain",true);
                }
                break;
            }
            MessageBox.Show("Done!");
        }
        public void PrintAllPurchaseStatemets()
        {
            

            DataSet ds = new DataSet();


            DataTable dtPurchases = oMySql.GetDataTable(String.Format("SELECT p.PurchaseID,  if (sum((pd.Cases*pr.Size + pd.Units)*pr.Cost) is null, 0,sum((pd.Cases*pr.Size + pd.Units)*pr.Cost) ) as Total FROM Purchase p Left Join PurchaseDetail pd On p.CompanyID=pd.CompanyID And p.PurchaseID=pd.PurchaseID Left Join Product pr On pr.CompanyID=pd.CompanyID And pr.ProductID=pd.ProductID  Where p.CompanyID='{0}' Group By p.PurchaseID", ID), "Purchase");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT p.PurchaseID,  if (Sum(pp.Amount) is null,0, Sum(pp.Amount)*-1) as Payments FROM Purchase p Left Join PaymentProvider pp On p.CompanyID=pp.CompanyID And p.PurchaseID=pp.PurchaseID Where p.CompanyID='{0}' Group By p.PurchaseID", ID), "Statements");

            ds.Tables.Add(dtPurchases);
            ds.Tables.Add(dtStatements);

            frmViewReport oViewReport = new frmViewReport();
            ds.WriteXml("PurchaseStatements1.xml", XmlWriteMode.WriteSchema);

            CompanyPurchaseStatementList oRpt = new CompanyPurchaseStatementList();
            

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", Name);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        
        public void PrintAllCAStatements()
        {
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("Select CustomerID, Min(Date), Max(Date), Sum(Amount) as Amount  FROM Payment  Where CompanyID='{0}' Group By CustomerID  HAVING Sum(Amount)>5", ID), "Statements");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And c.State='CA' And bc.BrochureID='S'", this.CompanyID), "Statements");
            Customer oCustomer = new Customer(this.CompanyID);
            foreach (DataRow row in dtStatements.Rows)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    Global.ShowNotifier("Processing:\r\n" + oCustomer.Name);
                    oCustomer.PrintStatement("scotte@sigfund.com",PrinterDevice.eMail);
                    break;
                }
            }
            MessageBox.Show("Done!");
        }

        public void PrintAllOrders()
        {
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("Select CustomerID, Min(Date), Max(Date), Sum(Amount) as Amount  FROM Payment  Where CompanyID='{0}' Group By CustomerID  HAVING Sum(Amount)>5", ID), "Statements");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT OrderID FROM _Orders Where CompanyID='{0}'", this.CompanyID), "Orders");
            Order oOrder = new Order(this.CompanyID);
            oOrder.OpenPrinter(1);
           // MessageBox.Show(dtStatements.Rows.Count.ToString());
            foreach (DataRow row in dtStatements.Rows)
            {
                if (oOrder.Find((Int32)row["OrderID"]))
                {
                    Global.ShowNotifier("Processing:\r\n" + oOrder.Student);
                    
                    oOrder.Print();
                 //   break;
                }
            }
            oOrder.ClosePrinter();
            MessageBox.Show("Done!");
        }

        public void PrintAllOrdersByItem(List<String> Items, String CustomerID)
        {
            String SqlCustomer = "";
            foreach (String row in Items)
            {
                SqlCustomer += (SqlCustomer != "" ? " Or " : "") + "ProductID='" + row + "'";
            }
            SqlCustomer = "(" + SqlCustomer + ")";
            
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("Select CustomerID, Min(Date), Max(Date), Sum(Amount) as Amount  FROM Payment  Where CompanyID='{0}' Group By CustomerID  HAVING Sum(Amount)>5", ID), "Statements");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT OrderID FROM OrderDetail Where CompanyID='{0}' And {1} And CustomerID='{2}' Group By OrderID", this.CompanyID,SqlCustomer,CustomerID), "Orders");
            Order oOrder = new Order(this.CompanyID);

            if (dtStatements != null && dtStatements.Rows.Count > 0)
            {
                oOrder.OpenPrinter(4); //\\\\srv1\\Packing_5
                // MessageBox.Show(dtStatements.Rows.Count.ToString());
                foreach (DataRow row in dtStatements.Rows)
                {
                    if (oOrder.Find((Int32)row["OrderID"]))
                    {
                        Global.ShowNotifier("Processing:\r\n" + oOrder.Student);

                        oOrder.Print(Items);
                        //   break;
                    }
                }
                oOrder.ClosePrinter();
            }
            MessageBox.Show("Done!");
        }
        public void PrintAllStatementsByEmail()
        {
            DataTable dtStatements = oMySql.GetDataTable(String.Format("Select p.CustomerID,  Sum(Amount) as Amount, c.DeliveryDate, DateDiff(Now(),c.DeliveryDate) as Days, DateDiff(Now(),c.DeliveryDate)-21 as SevenDays, Mod(DateDiff(Now(),c.DeliveryDate) - 21, 7) FROM Payment p Left Join Customer c On p.CompanyID=c.CompanyID And p.CustomerID=c.CustomerID Where p.CompanyID='{0}' And DateDiff(Now(),c.DeliveryDate)-21 >= 0  And Mod(DateDiff(Now(),c.DeliveryDate) - 21, 7) = 0 Group By p.CustomerID  HAVING Sum(Amount) >= 21", ID), "Statements");
            
            Customer oCustomer = new Customer(this.CompanyID);
           // int x = 0;
            foreach (DataRow row in dtStatements.Rows)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                            //Global.ShowNotifier("Processing:\r\n" + oCustomer.Name);

                            if (oCustomer.PrintStatement("", PrinterDevice.eMail))
                                Console.WriteLine(oCustomer.ID + " : " + oCustomer.Name + " sent");
                            else
                                Console.WriteLine(oCustomer.ID + " : " + oCustomer.Name + " didn´t send (" + oCustomer.eMail + ")");

                            /*
                            if (x==2)
                                break;
                            x++;
                            */
                    
                }
            }
           // MessageBox.Show("Done!");
        }
        public void PrintInternetChecks()
        {


            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}'", ID), "Customer"));

            DataTable dt = oMySql.GetDataTable(String.Format("Select Teacher, sum(Retail) as Retail, sum(Retail)*.40 as Amount From  Orders Where CompanyID='{0}' And CustomerID='"+Global.ICustomer+"' Group by Teacher", this.ID),"Checks");

            dt.Columns.Add(new DataColumn("CustomerID", Type.GetType("System.String")));

            foreach (DataRow row in dt.Rows)
            {
                if (row["Teacher"].ToString().Length >= 5)
                    row["CustomerID"] = row["Teacher"].ToString().Trim().Substring(row["Teacher"].ToString().Trim().Length - 5, 5);
            }
            dt.AcceptChanges();
            ds.Tables.Add(dt);
            
           // ds.WriteXml("CustomerInternetChecks1.xml", XmlWriteMode.WriteSchema);

            CustomerInternetChecks oRpt = new CustomerInternetChecks();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();

        }
        public void PrintAllCAInvoices()
        {
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And AddedAmount <> 0", ID), "Customer");
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Where c.CompanyID='{0}'", this.CompanyID), "Customer");

            DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And c.State='CA' And bc.BrochureID='S'", this.CompanyID), "Customer");
            Invoice oCustomer = new Invoice(this.CompanyID);
            int x = 0;
            foreach (DataRow row in dtCustomers.Rows)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    Global.ShowNotifier("Processing Invoice for :\r\n" + oCustomer.Name);
                    oCustomer.GetCurrentTotalsByBrochure();
                    // if (oCustomer.AmountDue > 5.00)
                    {
                        oCustomer.Print(PrintTo.Nothing, "\\\\srv1\\Plain", "Tax previously excluded from items 1807, 9310, 9312, 9314 and 9316. SE", false);
                    }
                    x++;
                    //if (x == 2)
                    //    break;
                }
            }
            MessageBox.Show("Done!");
        }

        public void PrintAllItemsInvoices()
        {
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And AddedAmount <> 0", ID), "Customer");
            //DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Where c.CompanyID='{0}'", this.CompanyID), "Customer");

            DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And c.State='CA' And bc.BrochureID='S'", this.CompanyID), "Customer");
            Invoice oCustomer = new Invoice(this.CompanyID);
            int x = 0;
            foreach (DataRow row in dtCustomers.Rows)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    Global.ShowNotifier("Processing Invoice for :\r\n" + oCustomer.Name);
                    oCustomer.GetCurrentTotalsByBrochure();
                    // if (oCustomer.AmountDue > 5.00)
                    {
                        oCustomer.Print(PrintTo.Nothing, "\\\\srv1\\Plain", "Tax previously excluded from items 1807, 9310, 9312, 9314 and 9316. SE", false);
                    }
                    x++;
                    //if (x == 2)
                    //    break;
                }
            }
            MessageBox.Show("Done!");
        }

        public void PrintCustomersGrouped()
        {

            

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            
            


            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT od.ProductID, p.Description, Sum(od.Quantity) as Quantity, cu.Rep_ID, pr.HTS_Number, pr.HTS_Price, pr.Retail,pr.Country FROM OrderDetail od   Left Join Customer cu On od.CompanyID=cu.CompanyID And od.CustomerID=cu.CustomerID Left Join ProductByRep pr On cu.CompanyID=pr.CompanyID And cu.Rep_ID=pr.RepID And od.ProductID = pr.ProductID Left Join Product p On od.CompanyID=p.CompanyID And od.ProductID=p.ProductID Left Join CustomerExtra c On c.CompanyID=od.CompanyID And c.CustomerID=od.CustomerID Where c.CompanyID='{0}' And c.IsGrouped=1 Group By od.ProductID", this.CompanyID), "Product"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));

          //  ds.WriteXml("PrintCustomerGrouped.xml", XmlWriteMode.WriteSchema);

            CustomerGroupedReport oRpt = new CustomerGroupedReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", this.Name);

            //Passing Parameters
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }

        public void PrintCustomersGroupedByCustomer()
        {



            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();



            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *  from Customer cu  Left Join CustomerExtra c On c.CompanyID=cu.CompanyID And c.CustomerID=cu.CustomerID Where c.CompanyID='{0}' And c.IsGrouped=1", this.CompanyID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT od.CustomerID, od.ProductID, p.Description, Sum(od.Quantity) as Quantity, cu.Rep_ID, pr.HTS_Number, pr.HTS_Price, pr.Retail,pr.Country FROM OrderDetail od   Left Join Customer cu On od.CompanyID=cu.CompanyID And od.CustomerID=cu.CustomerID Left Join ProductByRep pr On cu.CompanyID=pr.CompanyID And cu.Rep_ID=pr.RepID And od.ProductID = pr.ProductID Left Join Product p On od.CompanyID=p.CompanyID And od.ProductID=p.ProductID Left Join CustomerExtra c On c.CompanyID=od.CompanyID And c.CustomerID=od.CustomerID Where c.CompanyID='{0}' And c.IsGrouped=1 Group By od.CustomerID, od.ProductID", this.CompanyID), "Product"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));

             ds.WriteXml("PrintCustomerGroupedByCustomer.xml", XmlWriteMode.WriteSchema);

            CustomerGroupedByCustomerReport oRpt = new CustomerGroupedByCustomerReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", this.Name);

            //Passing Parameters
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }

        #endregion

        public void ProcessInventory()
        {
            DataSet ds = new DataSet();

           
            Global.Message = "Processing...."; 
            
            
            oMySql.exec_sql("Update Product Set ONPO=0,Commited=0,Sold=0,OnHand=0,Received=0 Where CompanyID='"+ID+"'");
            Global.SetProgressBar(7, 1);
            //oMySql.exec_sql(String.Format("Update OrderDetail od, Customer c Set od.QuantityInvoiced = od.Quantity   Where od.CompanyID='{0}'  And od.CompanyID=c.CompanyID And od.CustomerID=c.CustomerID And c.LastInvoiceAmount >0",ID));
            
            ds.Tables.Add(oMySql.GetDataTable("SELECT distinct(pd.ProductID),sum(Cases*p.Size+Units) as Quantity FROM PurchaseDetail pd Left Join Product p On pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='"+ID+"' Group By pd.ProductID", "Purchase"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT distinct(pd.ProductID),sum(Quantity) as Quantity FROM ReceiveDetail pd Left Join Product p On pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='" + ID + "' Group By pd.ProductID", "Receive"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT distinct(pd.ProductID),sum(Quantity) as Quantity FROM OrderDetail pd left Join CustomerExtra ce On pd.CompanyID=ce.CompanyID And pd.CustomerID=ce.CustomerID Left Join Product p On pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='"+ID+"'  And QuantityInvoiced=0 And ce.IsPineValley != 1 Group By pd.ProductID", "Order"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT distinct(pd.ProductID),sum(QuantityInvoiced) as Quantity FROM OrderDetail pd Left Join Product p On pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='"+ID+"' And QuantityInvoiced >0 Group By pd.ProductID","Invoice"));
            //ds.Tables.Add(oMySql.GetDataTable("Select distinct(Prize) as ProductID, pd.PrizeID, count(*) as Quantity, pd.BreakLevel  From Orders o Left join PrizeDetail pd On o.Prize=pd.ProductID  And o.CompanyID=pd.CompanyID Where o.CompanyID='" + ID + "' Group By Prize", "OrderPrize"));
           // ds.Tables.Add(oMySql.GetDataTable("Select o.Invoiced, c.PrizeID, Prize as ProductID,  count(o.Prize) as Quantity, pd.BreakLevel  From Orders o  Left Join Customer c On o.CompanyID=c.CompanyID And o.CustomerID=c.CustomerID Left Join PrizeDetail pd On o.CompanyID=pd.CompanyID And c.PrizeID=pd.PrizeID And o.Prize=ProductID Where o.CompanyID='"+ID+"' And BreakLevel is not null Group By o.Prize,o.Invoiced", "OrderPrize"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT c.PrizeID, Prize as ProductID, if(pd.BreakLevel is null,1,pd.BreakLevel) as BreakLevel, count(Prize) as Quantity, o.Invoiced FROM Orders o Left Join Customer c On o.CompanyID=c.CompanyID And o.CustomerID=c.CustomerID Left Join PrizeDetail pd On o.CompanyID=pd.CompanyID and c.PrizeID=pd.PrizeID and o.Prize=pd.ProductID Where o.CompanyID='"+ID+"' and Prize != '' And c.PrizeID is not null Group By c.PrizeID, Prize,o.Invoiced", "OrderPrize"));
            
            //ds.Tables.Add(oMySql.GetDataTable("SELECT ProductID, sum(Quantity)as Quantity, Type FROM ProductMisc Where CompanyID='" + ID + "' Group By ProductID,Type", "Misc"));
            //Console.WriteLine("Select distinct(Prize) as ProductID, pd.PrizeID, count(*) as Quantity, pd.BreakLevel  From Orders o Left join PrizeDetail pd On o.Prize=pd.ProductID  And o.CompanyID=pd.CompanyID Where o.CompanyID='" + ID + "' Group By Prize");
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT ob.ProductID, sum(ob.Quantity) as Quantity, o.Invoiced FROM OrderBoxes ob Left Join Orders o On o.ID=ob.OrderID Where o.CompanyID='{0}' Group By o.Invoiced,ob.ProductID", this.ID), "OrderBox"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT ProductID, sum(Quantity) as Quantity, Type FROM ProductMisc  Where CompanyID='{0}' Group By Type, ProductID", this.ID), "Misc"));

            Product oProduct = new Product(ID);
            


            Global.SetProgressBar(7, 2);
            //Purchased Product
            foreach (DataRow row in ds.Tables["Purchase"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {

                    oProduct.ONPO = Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.UpdateInventory();
                }

            }
            Global.SetProgressBar(7, 3);
            //Received product
            foreach (DataRow row in ds.Tables["Receive"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {
                    oProduct.ONPO -= Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.Received = Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.UpdateInventory();
                }

            }
            Global.SetProgressBar(7, 4);
            //Ordered Product
            foreach (DataRow row in ds.Tables["Order"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {
                    oProduct.Committed = Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.UpdateInventory();
                }

            }

            Global.SetProgressBar(7, 5);
            //Ordered Product
            foreach (DataRow row in ds.Tables["OrderBox"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {
                    if ((Boolean) row["Invoiced"])
                        oProduct.Sold += Convert.ToInt32(row["Quantity"].ToString());
                    else
                        oProduct.Committed += Convert.ToInt32(row["Quantity"].ToString());

                    oProduct.UpdateInventory();
                }

            }
            
            Global.SetProgressBar(7, 6);
             //Ordered Prizes
            Prize oPrize = new Prize(ID);
            foreach (DataRow row in ds.Tables["OrderPrize"].Rows)
            {
                //if (row["BreakLevel"] != DBNull.Value)
                {

                   // if (oProduct.Find(row["ProductID"].ToString()))
                    {
                     //   oPrize.Find(row["PrizeID"].ToString());

                        DataView oPrizes = oPrize.GetItems(row["PrizeID"].ToString(), Convert.ToInt32(row["BreakLevel"].ToString()));
                        foreach (DataRowView drow in oPrizes)
                        {
                            if (oProduct.Find(drow["ProductID"].ToString()))
                            {
                               // MessageBox.Show(drow["ProductID"].ToString() + "--" + row["Quantity"].ToString());
                                if ((Boolean)row["Invoiced"])
                                    oProduct.Sold += Convert.ToInt32(row["Quantity"].ToString()); // * Convert.ToInt32(drow["Quantity"].ToString());
                                else
                                    oProduct.Committed += Convert.ToInt32(row["Quantity"].ToString()); // *Convert.ToInt32(drow["Quantity"].ToString());
                                oProduct.UpdateInventory();
                            }
                        }

                    }
                }            
            }
            
            Global.SetProgressBar(7, 7);
            //Invoiced Product
            foreach (DataRow row in ds.Tables["Invoice"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {
            //        oProduct.Committed -= Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.Sold = Convert.ToInt32(row["Quantity"].ToString());
                    oProduct.UpdateInventory();
                }
            }

            Global.SetProgressBar(7, 7);
            //Invoiced Product
            
            foreach (DataRow row in ds.Tables["Misc"].Rows)
            {
                if (oProduct.Find(row["ProductID"].ToString()))
                {
                    switch (row["Type"].ToString())
                    {
                        case "OnHand":
                            oProduct.OnHand += Convert.ToInt32(row["Quantity"].ToString());
                            break;
                        case "Received":
                            oProduct.Received += Convert.ToInt32(row["Quantity"].ToString());
                            break;
                        case "Sold":
                            oProduct.Sold += Convert.ToInt32(row["Quantity"].ToString());
                            break;
                        case "Commited":
                            oProduct.Committed += Convert.ToInt32(row["Quantity"].ToString());
                            break;

                        default:
                            break;
                    }
                    oProduct.UpdateInventory();
                }
            }
            

            Global.SetProgressBar(7, 7);
            Global.SetProgressBar(0, 0);
            Global.Message = "Done!"; 

        }

        public void CalculateAllCustomerTeacherStudent()
        {
            DataView dv = oMySql.GetDataView(String.Format("SELECT CustomerID FROM Orders  where CompanyID='{0}' And (TeacherID=0 or StudentID=0) Group By CustomerID", ID), "tmp");
            Customer oCustomer = new Customer(ID);
            foreach (DataRowView row in dv)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    oCustomer.RecalculateTeachersAndStudents();
                }
            }
        }

        public void CalculateAllCustomerTotals()
        {
            DataView dv = oMySql.GetDataView("Select distinct(CustomerID) From Orders Where CompanyID='"+ID+"' And Retail>0","tmp");
            Customer oCustomer = new Customer(ID);
            foreach(DataRowView row in dv)
            {
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {
                    if (oCustomer.HasChanged)
                        oCustomer.GetCurrentTotalsByBrochure();

                }
            }
        }
        public void CalculateAllCustomerTotalsByBrochure()
        {
            DataView dv = oMySql.GetDataView("Select distinct(CustomerID) From Orders Where CompanyID='" + ID + "' And Retail>0", "tmp");
            Customer oCustomer = new Customer(ID);
            int i=0;
            foreach (DataRowView row in dv)
            {
                i++;
                if (oCustomer.Find(row["CustomerID"].ToString()))
                {

                    if (oCustomer.HasChanged)
                    {
                        Global.ShowNotifier("Processing :\r\n" + oCustomer.Name + " " +dv.Count.ToString()+"/"+ i.ToString());
                        //oCustomer.GetCurrentTotals();
                        oCustomer.GetCurrentTotalsByBrochure();
                        oCustomer.HasChanged = false;
                    }

                }
            }
            MessageBox.Show("Done!");
        }

        public void UpdateBrochureOrderDetail()
        {
            DataTable dt = oMySql.GetDataTable("SELECT OrderID, ProductID, CustomerID FROM OrderDetail Where CompanyID='" + ID + "'", "Tmp");

            Order.Item oItem = new Order.Item();
            oItem.CompanyID = this.ID;
            
            Product oProduct = new Product(ID);
            foreach (DataRow row in dt.Rows)
            {
                oItem.OrderID = row["OrderID"].ToString();
                oItem.ProductID = row["ProductID"].ToString();

                if (oProduct.Find(row["ProductID"].ToString()))
                {
                    oItem.UpdateBrochure(oProduct.GetBrochure(row["CustomerID"].ToString()));
                }
            }
        }

       /* public virtual object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, this);
            ms.Position = 0;

            object obj = bf.Deserialize(ms);
            ms.Close();

            return obj;
        }*/

        public void SendMassEmail()
        {
            DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM eMails Where isUnsubscribed=0 And isSent=0", this.CompanyID), "eMail");
            foreach (DataRow row in dtCustomers.Rows)
            {
                Smtp oSmtp = new Smtp();
                oSmtp.mail.IsBodyHtml = true;
                
                oSmtp.Subject = "Test Mass eMail";



                oSmtp.To = "\"" + "Alvaro Medina" + "\" <" + row["eMail"].ToString() + ">"; 
            //    oSmtp.BCC = "\"" + "Scott Elsbree" + "\" <" + "scotte@sigfund.com" + ">"; 
                oSmtp.From = "\"Signature Fundraising Customer Service\" <info@signaturefundraising.com>";

                String strTitle = @"<html>
<head>
<title>sigfund email2</title>
<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>
</head>
<body bgcolor='#FFFFFF' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>
<!-- ImageReady Slices (sigfund email2.psd) -->
<table id='Table_01' width='601' border='0' cellpadding='0' cellspacing='0'>
	<tr>
        
		<td colspan='18'>
            <img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_01.jpg' width='600' height='13' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='13' alt=''></td>
	</tr>
	<tr>
		<td colspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_02.jpg' width='108' height='58' alt=''></td>
		<td colspan='10'>
			<a href='http://www.signaturefundraising.com/'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_03.jpg' alt='' width='353' height='58' border='0'></a></td>
<td colspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_04.jpg' width='139' height='58' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='58' alt=''></td>
	</tr>
	<tr>
		<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_05.jpg' width='14' height='16' alt=''></td>
		<td rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=1'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_06.jpg' alt='' width='79' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_07.jpg' width='15' height='16' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=2'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_08.jpg' alt='' width='45' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_09.jpg' width='18' height='16' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=4'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_10.jpg' alt='' width='56' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_11.jpg' width='18' height='16' alt=''></td>
		<td colspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=6'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_12.jpg' alt='' width='63' height='11' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_13.jpg' width='20' height='16' alt=''></td>
		<td rowspan='4'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=7'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_14.jpg' alt='' width='94' height='14' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_15.jpg' width='21' height='16' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=9'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_16.jpg' alt='' width='52' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_17.jpg' width='21' height='16' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=13'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_18.jpg' alt='' width='64' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_19.jpg' width='20' height='16' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='11' alt=''></td>
	</tr>
	<tr>
		<td colspan='2' rowspan='4'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_20.jpg' width='63' height='5' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_21.jpg' width='45' height='4' alt=''></td>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_22.jpg' width='56' height='4' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_23.jpg' width='79' height='3' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_24.jpg' width='52' height='3' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_25.jpg' width='64' height='3' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_26.jpg' width='94' height='2' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='2' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_27.jpg' width='600' height='141' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='141' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_28.jpg' width='600' height='118' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='118' alt=''></td>
	</tr>
	<tr>
		<td colspan='8'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=All'>
            <img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_29.jpg' width='300' height='56' alt=''></a>
        </td>
		<td colspan='8'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_30.jpg' alt='' width='268' height='56' border='0'></td>
<td colspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_31.jpg' width='32' height='56' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='56' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_32.jpg' width='600' height='82' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='82' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_33.jpg' width='600' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_34.jpg' width='600' height='153' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='153' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_35.jpg' width='600' height='178' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='178' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_36.jpg' width='600' height='200' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='200' alt=''></td>
	</tr>
	
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='14' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='79' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='15' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='45' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='56' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='55' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='8' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='94' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='34' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='52' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='12' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td></td>
	</tr>
    <tr>
        <td colspan='18'>
            This is a promotional email message from Signature Fundraising, Inc. If you do not wish to receive these types of messages from Signature Fundraising, Inc. in the future, please <a href='http://www.signaturefundraising.com/email-ad/unsubscribe.php?email=" + row["eMail"].ToString() + @"'>click here</a>. <br>

©2012 Signature Fundraising Inc. Privacy Policy

        </td>
</tr>
</table>
<!-- End ImageReady Slices -->
</body>
</html>";
                strTitle = @"<html>
<head>
<title>sigfund email2</title>
<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>
</head>
<body bgcolor='#FFFFFF' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>
<!-- ImageReady Slices (sigfund email2.psd) -->
<table id='Table_01' width='601' border='0' cellpadding='0' cellspacing='0'>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_01.jpg' width='600' height='13' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='13' alt=''></td>
	</tr>
	<tr>
		<td colspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_02.jpg' width='108' height='58' alt=''></td>
		<td colspan='10'>
			<a href='http://www.signaturefundraising.com/'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_03.jpg' alt='' width='353' height='58' border='0'></a></td>
<td colspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_04.jpg' width='139' height='58' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='58' alt=''></td>
	</tr>
	<tr>
		<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_05.jpg' width='14' height='16' alt=''></td>
		<td rowspan='3'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=1'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_06.jpg' alt='' width='79' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_07.jpg' width='15' height='16' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=2'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_08.jpg' alt='' width='45' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_09.jpg' width='18' height='16' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=4'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_10.jpg' alt='' width='56' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_11.jpg' width='18' height='16' alt=''></td>
		<td colspan='2'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=6'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_12.jpg' alt='' width='63' height='11' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_13.jpg' width='20' height='16' alt=''></td>
		<td rowspan='4'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=7'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_14.jpg' alt='' width='94' height='14' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_15.jpg' width='21' height='16' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=9'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_16.jpg' alt='' width='52' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_17.jpg' width='21' height='16' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=13'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_18.jpg' alt='' width='64' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_19.jpg' width='20' height='16' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='11' alt=''></td>
	</tr>
	<tr>
		<td colspan='2' rowspan='4'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_20.jpg' width='63' height='5' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_21.jpg' width='45' height='4' alt=''></td>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_22.jpg' width='56' height='4' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_23.jpg' width='79' height='3' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_24.jpg' width='52' height='3' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_25.jpg' width='64' height='3' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_26.jpg' width='94' height='2' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='2' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_27.jpg' width='600' height='141' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='141' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_28.jpg' width='600' height='118' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='118' alt=''></td>
	</tr>
	<tr>
		<td colspan='8'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_29.jpg' width='300' height='56' alt=''></td>
		<td colspan='8'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?category=All'><img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_30.jpg' alt='' width='268' height='56' border='0'></a></td>
<td colspan='2'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_31.jpg' width='32' height='56' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='56' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_32.jpg' width='600' height='82' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='82' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_33.jpg' width='600' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_34.jpg' width='600' height='153' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='153' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_35.jpg' width='600' height='178' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='178' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/email-ad/images/sigfund-email_36.jpg' width='600' height='200' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='1' height='200' alt=''></td>
	</tr>
	
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='14' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='79' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='15' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='45' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='56' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='55' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='8' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='94' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='34' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='52' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='12' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td></td>
	</tr>
     <tr>
        <td colspan='18'>
            This is a promotional email message from Signature Fundraising, Inc. If you do not wish to receive these types of messages from Signature Fundraising, Inc. in the future, please <a href='http://www.signaturefundraising.com/email-ad/unsubscribe.php?email=" + row["eMail"].ToString() + @"'>click here</a>. <br>

©2012 Signature Fundraising Inc. Privacy Policy

        </td>
     
</tr>

</table>
<!-- End ImageReady Slices -->
</body>
</html>";
                strTitle = @"<html>
<head>
<title>sigfund email free gifts1</title>
<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>
</head>
<body bgcolor='#FFFFFF' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>
<!-- ImageReady Slices (sigfund email free gifts1.psd) -->
<table id='Table_01' width='601' height='456' border='0' cellpadding='0' cellspacing='0'>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_01.jpg' width='600' height='13' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='13' alt=''></td>
	</tr>
	<tr>
		<td colspan='3'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_02.jpg' width='108' height='58' alt=''></td>
		<td colspan='10'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_03.jpg' width='353' height='58' alt=''></td>
		<td colspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_04.jpg' width='139' height='58' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='58' alt=''></td>
	</tr>
	<tr>
		<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_05.jpg' width='14' height='24' alt=''></td>
		<td rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=1'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_06.jpg' alt='' width='79' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_07.jpg' width='15' height='24' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=2'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_08.jpg' alt='' width='45' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_09.jpg' width='18' height='24' alt=''></td>
		<td rowspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=4'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_10.jpg' alt='' width='56' height='12' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_11.jpg' width='18' height='24' alt=''></td>
		<td colspan='2'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=6'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_12.jpg' alt='' width='63' height='11' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_13.jpg' width='20' height='24' alt=''></td>
		<td rowspan='4'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=7'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_14.jpg' alt='' width='94' height='14' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_15.jpg' width='21' height='24' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=9'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_16.jpg' alt='' width='52' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_17.jpg' width='21' height='24' alt=''></td>
		<td colspan='2' rowspan='3'>
			<a href='http://www.signaturefundraising.com/db_cart_main.php?category=13'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_18.jpg' alt='' width='64' height='13' border='0'></a></td>
<td rowspan='5'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_19.jpg' width='20' height='24' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='11' alt=''></td>
	</tr>
	<tr>
		<td colspan='2' rowspan='4'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_20.jpg' width='63' height='13' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_21.jpg' width='45' height='12' alt=''></td>
		<td rowspan='3'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_22.jpg' width='56' height='12' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td rowspan='2'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_23.jpg' width='79' height='11' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_24.jpg' width='52' height='11' alt=''></td>
		<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_25.jpg' width='64' height='11' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='1' alt=''></td>
	</tr>
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_26.jpg' width='94' height='10' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='10' alt=''></td>
	</tr>
	<tr>
		<td colspan='18'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_27.jpg' width='600' height='209' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='209' alt=''></td>
	</tr>
	<tr>
		<td colspan='8' rowspan='2'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_28.jpg' width='300' height='151' alt=''></td>
		<td colspan='8'>
			<a href='http://www.signaturefundraising.com/Online/db_cart_main.php?Brochure=1'><img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_29.jpg' alt='' width='268' height='79' border='0'></a></td>
<td colspan='2' rowspan='2'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_30.jpg' width='32' height='151' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='79' alt=''></td>
	</tr>
	<tr>
		<td colspan='8'>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/email-ad_31.jpg' width='268' height='72' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='1' height='72' alt=''></td>
	</tr>
	<tr>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='14' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='79' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='15' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='45' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='56' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='55' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='8' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='94' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='18' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='34' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='21' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='52' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='12' height='1' alt=''></td>
		<td>
			<img src='http://www.signaturefundraising.com/Online/email-ad/images/spacer.gif' width='20' height='1' alt=''></td>
		<td></td>
	</tr>
</table>
<!-- End ImageReady Slices -->
</body>
</html>";

                /*
                strTitle += "<html>";
                strTitle += "<body>";

                strTitle += "<h1>Title</h1>";
                
                strTitle += "<p>We can include an entire design as part of the message; you can click on the image, links, etc...</p>";
                strTitle += "<a href='http://www.SignatureFundraising.com'><img src='http://www.SignatureFundraising.com/images/front_ad_1.gif' width='300' height='142' /></a>";
                strTitle += "<br>Thank you.<br>";
                strTitle += "<a href='http://www.SignatureFundraising.com'>Signature Fundraising</a>";
                
                strTitle += "</body>";
                strTitle += "</html>";
                */
                if (!this.isEmail(row["eMail"].ToString()))
                {
                    Console.WriteLine("Wrong email:" + row["eMail"].ToString());
                    continue;
                }
                
                //oSmtp.Attachment = oPDF.FileName;

                oSmtp.Body = strTitle;
                //oSmtp.Attachment = "Check by Fax Form.pdf";
                oSmtp.Credentials = new System.Net.NetworkCredential("info@signaturefundraising.com", "sigfund");
                // oSmtp.BCC = "scotte@sigfund.com";

                if (!oSmtp.Send())
                {
                    Console.WriteLine(oSmtp.Error);
                }
                else
                {
                    Console.WriteLine("Sent : " + row["eMail"].ToString());
                    String Sql = "Update eMails Set isSent=1 Where email=\"" + row["eMail"].ToString() + "\"";
                    oMySql.exec_sql(Sql);
                }
            }
            Console.WriteLine("Total: " + dtCustomers.Rows.Count.ToString());
        }
        public bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail.ToString();
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}
