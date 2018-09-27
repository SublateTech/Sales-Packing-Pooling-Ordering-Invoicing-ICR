using System;
using System.Collections;
using System.Text;
using Signature.Data;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Signature.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic;


namespace Signature.Classes
{
    public class Invoice : Customer
    {
        private String _Company = null;
        public DateTime Date;
        public Int32 OrderID;
        public LinePrint oPrint;
        public int CurPage = 0;
        private String Note;

 
        public Invoice(String CompanyID)
            : base(CompanyID)
        {
            _Company = CompanyID;
        }
        
        public void UpdateInvoicedAmount(Double _Amount)
        {
            Charge oCharge = new Charge(CompanyID);
            oCharge.Amount = _Amount;
            oCharge.Comment = Note; // "PLEASE REMIT ENTIRE WHITE COPIES WITH PAYMENT";
            oCharge.Type = "I";
            oCharge.CustomerID = ID;
            oCharge.Date = DateTime.Today;
            oCharge.Insert();
        }

        public Boolean GenerateFinanceCharges(Double Percent)
        {
          
            DateTime FromDate;
            DateTime ToDate;
            FromDate = this.DeliveryDate;
            ToDate = DateTime.Now;

            if (this.DeliveryDate == Global.DNull)
            {
                Global.ShowNotifier("No delivery date to calculate from");
                return false;
            }
            if (this.StatementAmountDue <= 0)
                return false;
            
            Int32 PassedMonths = (Int32) DateAndTime.DateDiff(DateInterval.Month, FromDate, ToDate, FirstDayOfWeek.System, FirstWeekOfYear.System);
            
          
            Int32 ChargesNumber = GetFinanceChargesNumber();
            Double Amount = AmountDue - GetFinanceChargesAmount();
            Boolean Changed = false;
           // MessageBox.Show(Amount.ToString());
            for (int i = 0; i < PassedMonths - ChargesNumber; i++)
            {
                Charge oCharge = new Charge(CompanyID);
                
                oCharge.Comment = "FINANCE CHARGES";
                oCharge.Type = "F";
                oCharge.CustomerID = ID;
                oCharge.Date = this.DeliveryDate.AddMonths(ChargesNumber+i+1);
                if (DateTime.Now >= oCharge.Date && i >= 0)
                {

                    if (Amount * Percent / 100 > 0.00)
                    {
                        if (oCharge.FindByDate(oCharge.Date, ID, "F"))
                        {
                            oCharge.Amount = Amount * Percent / 100;
                            oCharge.Update();
                            Changed = true;
                        }
                        else
                        {
                            oCharge.Date = this.DeliveryDate.AddMonths(ChargesNumber + i + 1);
                            oCharge.Amount = Amount * Percent / 100;
                            oCharge.Insert();
                            Changed = true;
                        }
                    }
                }
            }
            return Changed;

        }
        public Int32   GetFinanceChargesNumber()
        {
            DataRow rCharges = oMySql.GetDataRow(String.Format("SELECT count(*) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Type='F'", CompanyID, ID), "Tmp");

            /*
            I = Invoice
            F = Finance Charges  
            S = Late Orders
            A = Adjustments
            */
            if (rCharges == null)
                return 0;
            else
                return rCharges["Payments"] == DBNull.Value ? 0 : Convert.ToInt32(rCharges["Payments"].ToString());

        }
        public Charge  GetFirstInvoice()
        {
            Charge oCharge = new Charge(CompanyID, ID);
            return oCharge.GetFirstInvoice();
        }
        public Charge  GetLastInvoice()
        {
            Charge oCharge = new Charge(CompanyID, ID);
            return oCharge.GetLastInvoice();
        }
        public DataTable GetOverageTable()
        {
            Charge oCharge = GetLastInvoice();
            if (oCharge == null)
            {
                
                return null;
            }
            return oMySql.GetDataTable(String.Format("Select * from OrderOverage  Where CompanyID='{0}' And  CustomerID='{1}' And Date > Date('{2}') Order By OrderID", CompanyID, this.ID, oCharge.Date.ToString("yyyy-MM-dd hh:mm:ss")),"Overage");
        }
        public Double   GetCustomerOverageAmount()
        {

            Charge oCharge = GetLastInvoice();
            if (oCharge == null)
            {
                return 0;
            }

            DataRow rOverage = oMySql.GetDataRow(String.Format("Select o.*, sum(p.Price*o.Quantity) as Total  from OrderOverage o Left Join Product p on o.CompanyID=p.CompanyID And o.ProductID=p.ProductID Where o.CompanyID='{0}' And CustomerID='{1}' And Date > Date('{2}') Group By o.CustomerID", CompanyID, ID, oCharge.Date.ToString("yyyy-MM-dd hh:mm:ss")), "Tmp");
            
            if (rOverage == null)
                return 0;
            else
                return rOverage["Total"] == DBNull.Value ? 0 : (Double) Convert.ToDouble(rOverage["Total"]);

        }
        public Double   GetOrderOverageAmount(String OrderID)
        {
            Charge oCharge = GetLastInvoice();
            if (oCharge == null)
            {
                return 0;
            }

            DataRow rOverage = oMySql.GetDataRow(String.Format("Select o.*, sum(p.Price*o.Quantity) as Total  from OrderOverage o Left Join Product p on o.CompanyID=p.CompanyID And o.ProductID=p.ProductID Where o.OrderID='{0}' And Date > '{1}' Group By o.ProductID", OrderID, oCharge.Date.ToString("yyyy-MM-dd hh:mm:ss")), "Tmp");
            if (rOverage == null)
                return 0;
            else
                return rOverage["Total"] == DBNull.Value ? 0 : (Double)Convert.ToDouble(rOverage["Total"]);

        }
        public String   GetStringOverageInvoice()
        {
            String sOverage = "";
            if (GetCustomerOverageAmount() != 0)
            {
                Charge oCharge = GetLastInvoice();
                if (oCharge == null)
                {
                    return "";
                }

                DataTable tOverage = oMySql.GetDataTable(String.Format("Select distinct(OrderID), o.Student  from OrderOverage oo Left Join Orders o on o.ID=oo.OrderID Where oo.CompanyID='{0}' And oo.CustomerID='{1}' And oo.Date > '{2}' Group By oo.OrderID", CompanyID, ID, oCharge.Date.ToString("yyyy-MM-dd hh:mm:ss")), "Tmp");
                foreach (DataRow row in tOverage.Rows)
                {
                    if (GetOrderOverageAmount(row["OrderID"].ToString()) != 0)
                        sOverage += row["Student"].ToString() + "\n";
                }
            }
           // MessageBox.Show(sOverage);
            return sOverage;
        }
        
        #region Print
        public void Print(PrintTo ToPrint, String PrinterName, String InvoiceNote, Boolean IsPreInvoice)
        {
            if (this.IsGPI)
            {
                PrintGPI(ToPrint, PrinterName, InvoiceNote, IsPreInvoice);
                return;
            }
            
            Double AllPositive = this.GetPositiveAmount();
            Double AllNegative = this.GetNegativeAmount();
            Double DropPercentageCustomer = 0.00;
            Double DropPercentageItem = 0.00;
            if (Retail < 2500 && !this.IsGiftAvenue && !this.IsGPI)
            {
                DataTable dtInv = GetCurrentTotalsByBrochure();
                if ( dtInv != null)
                {
                    if (LastInvoicedAmount == 0 && Retail < 2500 && Retail > 0 )
                    {
                        if (!IsPreInvoice)
                        {
                            SubtractBrochureProfitPercent(InvoicedAmount,dtInv);
                        }
                        else
                        {
                            DropPercentageCustomer = -5.00;
                    
                        }
                        
                    }
                    DropPercentageItem = -5.00;
                }
                else
                    return;
            }

            this.Note = InvoiceNote;
            this.Note += "\n" + GetStringOverageInvoice();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            DataTable dvInv = new DataTable();
            dvInv = GetTotalDataTable("ProductID", DropPercentageCustomer, DropPercentageItem );
            ds.Tables.Add(CreateDetailTable(dvInv)); //Detail


            DataTable dtTotals = GetCurrentTotals(DropPercentageCustomer, DropPercentageItem); //GetTotalDataTable("CustomerID");
            
            //GetCurrentTotalsByBrochure();
            if (dtTotals != null)
            {
                ds.Tables.Add(dtTotals); //Detail

                

                frmViewReport oViewReport = new frmViewReport();
                //ds.WriteXml("Invoice.xml", XmlWriteMode.WriteSchema);
                InvoiceHeaderDetail oRpt = new InvoiceHeaderDetail();
                oRpt.SetDataSource(ds);
                oRpt.SetParameterValue("PrevInvoice",AllPositive ); //LastInvoicedAmount);
                oRpt.SetParameterValue("Payments",AllNegative ); //PaymentsAmount+Charges);
                oRpt.SetParameterValue("AddedAmount", AddedAmount);
                oRpt.SetParameterValue("BalanceDue", AllPositive + AllNegative + AddedAmount); //AmountDue);
                oRpt.SetParameterValue("InvoiceNote", this.Note);
                
                Company oCompany = new Company(this.CompanyID);
                oRpt.SetParameterValue("CompanyName",oCompany.Name);

                if (this.BrochureID == "C" ||this.BrochureID_2 == "C" || this.BrochureID_3 == "C")
                    oRpt.SetParameterValue("txtFee", "E Card Ship Fee".ToUpper());
                else
                    oRpt.SetParameterValue("txtFee", "IMPRINT FEE");

                if (this.IsPostPay)
                    oRpt.SetParameterValue("Terms", "");
                else
                    oRpt.SetParameterValue("Terms", "TERMS: NET DUE UPON DELIVERY");

                if (ToPrint == PrintTo.File)
                {
                    PDF oPDF = new PDF();
                    oPDF.FileName = Application.StartupPath + "\\" + this.Name + ".pdf";
                    oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.Name);

                    Smtp oSmtp = new Smtp();
                    oSmtp.Subject = "Invoice for "+ this.Name + "   "+ DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                    if (PrinterName != "PDF")
                        oSmtp.To = "<" + PrinterName + ">"; //this.eMail + ">";
                    else
                        oSmtp.To = "<" + "scott@sigfund.com" + ">"; //this.eMail + ">";
                    oSmtp.From = "\"Signature Fundraising Customer Service\" <info@sigfund.com>";

                    String strTitle = "Invoice\n\r";

                    oSmtp.Body = strTitle;
                    oSmtp.Attachment = oPDF.FileName;
                    if (!oSmtp.Send())
                        return;
                }
                else if (ToPrint== PrintTo.Printer)
                {
                    oRpt.PrintOptions.PrinterName = PrinterName;
                    oRpt.PrintToPrinter(1, true, 1, 100);
                }
                else if (ToPrint== PrintTo.Viewer)
                {
                    oViewReport.cReport.ReportSource = oRpt;
                    oViewReport.ShowDialog();
                    //oViewReport.cReport.PrintReport();
                }


                if (!IsPreInvoice)
                {
                    UpdateInventory();

                    //Update Statement
                    if (LastInvoicedAmount != InvoicedAmount)
                    {
                        UpdateInvoicedAmount(InvoicedAmount - LastInvoicedAmount); //Adding Line ,,,,
                        AddedAmount = 0.00;
                    }
                }

                
                this.UpdateCurrentTotals();
                ds.Dispose();
                oRpt.Dispose();
            }
            return;
        }
        public void PrintGPI(PrintTo ToPrint, String PrinterName, String InvoiceNote, Boolean IsPreInvoice)
        {
            Double AllPositive = this.GetPositiveAmount();
            Double AllNegative = this.GetNegativeAmount();
            Double DropPercentageCustomer = 0.00;
            Double DropPercentageItem = 0.00;
            if (Retail < 2500 && !this.IsGiftAvenue && !this.IsGPI)
            {
                DataTable dtInv = GetCurrentTotalsByBrochure();
                if (dtInv != null)
                {
                    if (LastInvoicedAmount == 0 && Retail < 2500 && Retail > 0)
                    {
                        if (!IsPreInvoice)
                        {
                            SubtractBrochureProfitPercent(InvoicedAmount, dtInv);
                        }
                        else
                        {
                            DropPercentageCustomer = -5.00;

                        }

                    }
                    DropPercentageItem = -5.00;
                }
                else
                    return;
            }

            this.Note = InvoiceNote;
            this.Note += "\n" + GetStringOverageInvoice();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            DataTable dvInv = new DataTable();
            dvInv = GetTotalDataTableGPI("ProductID", DropPercentageCustomer, DropPercentageItem);
            ds.Tables.Add(CreateDetailTable(dvInv)); //Detail


            DataTable dtTotals = GetCurrentTotalsGPI(DropPercentageCustomer, DropPercentageItem); //GetTotalDataTable("CustomerID");

            //GetCurrentTotalsByBrochure();
            if (dtTotals != null)
            {
                ds.Tables.Add(dtTotals); //Detail



                frmViewReport oViewReport = new frmViewReport();
                //ds.WriteXml("Invoice.xml", XmlWriteMode.WriteSchema);
                InvoiceHeaderDetailGPI oRpt = new InvoiceHeaderDetailGPI();
                oRpt.SetDataSource(ds);
                oRpt.SetParameterValue("PrevInvoice", AllPositive); //LastInvoicedAmount);
                oRpt.SetParameterValue("Payments", AllNegative); //PaymentsAmount+Charges);
                oRpt.SetParameterValue("AddedAmount", AddedAmount);
                oRpt.SetParameterValue("BalanceDue", AllPositive + AllNegative + AddedAmount); //AmountDue);
                oRpt.SetParameterValue("InvoiceNote", this.Note);

                Company oCompany = new Company(this.CompanyID);
                oRpt.SetParameterValue("CompanyName", oCompany.Name);

                if (this.BrochureID == "C" || this.BrochureID_2 == "C" || this.BrochureID_3 == "C")
                    oRpt.SetParameterValue("txtFee", "E Card Ship Fee".ToUpper());
                else
                    oRpt.SetParameterValue("txtFee", "IMPRINT FEE");

                if (this.IsPostPay)
                    oRpt.SetParameterValue("Terms", "");
                else
                    oRpt.SetParameterValue("Terms", "TERMS: NET DUE UPON DELIVERY");

                if (ToPrint == PrintTo.File)
                {
                    PDF oPDF = new PDF();
                    oPDF.FileName = Application.StartupPath + "\\" + this.Name + ".pdf";
                    oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.Name);

                    Smtp oSmtp = new Smtp();
                    oSmtp.Subject = "Invoice for " + this.Name + "   " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                    oSmtp.To = "<" + "scotte@sigfund.com" + ">"; //this.eMail + ">";
                    oSmtp.From = "\"Signature Fundraising Customer Service\" <support@sigfund.com>";

                    String strTitle = "Invoice\n\r";

                    oSmtp.Body = strTitle;
                    oSmtp.Attachment = oPDF.FileName;
                    if (!oSmtp.Send())
                        return;
                }
                else if (ToPrint == PrintTo.Printer)
                {
                    oRpt.PrintOptions.PrinterName = PrinterName;
                    oRpt.PrintToPrinter(1, true, 1, 100);
                }
                else if (ToPrint == PrintTo.Viewer)
                {
                    oViewReport.cReport.ReportSource = oRpt;
                    oViewReport.ShowDialog();
                    //oViewReport.cReport.PrintReport();
                }


                if (!IsPreInvoice)
                {
                    UpdateInventory();

                    //Update Statement
                    if (LastInvoicedAmount != InvoicedAmount)
                    {
                        UpdateInvoicedAmount(InvoicedAmount - LastInvoicedAmount); //Adding Line ,,,,
                        AddedAmount = 0.00;
                    }
                }
                

                this.UpdateCurrentTotals();
                ds.Dispose();
                oRpt.Dispose();
            }
            return;
        }
        public void PrintAcknowledgement()
        {
            String InvoiceNote = "";
            Double AllPositive = this.GetPositiveAmount();
            Double AllNegative = this.GetNegativeAmount();
            Double DropPercentageCustomer = 0.00;
            Double DropPercentageItem = 0.00;


            this.Note = InvoiceNote;
            this.Note += "\n" + GetStringOverageInvoice();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            DataTable dvInv = new DataTable();
            dvInv = GetTotalDataTableGPI("ProductID", DropPercentageCustomer, DropPercentageItem);
            ds.Tables.Add(CreateDetailTableGPI(dvInv)); //Detail


            //DataTable dtTotals = GetTotalDataTableGPI("CustomerID", DropPercentageCustomer, DropPercentageItem);

            frmViewReport oViewReport = new frmViewReport();

            //GetCurrentTotalsByBrochure();
           // if (dtTotals != null)
            {
              //  ds.Tables.Add(dtTotals); //Detail


         //       ds.WriteXml("InvoiceGPI_1.xml", XmlWriteMode.WriteSchema);

                InvoiceDetailGPI oRpt = new InvoiceDetailGPI();
                oRpt.SetDataSource(ds);
                
                Company oCompany = new Company(this.CompanyID);
                oRpt.SetParameterValue("CompanyName", oCompany.Name);


                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();

                ds.Dispose();
                oRpt.Dispose();
            }
            return;
        }
        private Boolean SubtractBrochureProfitPercent(Double BeforeDropedInvoicedAmount, DataTable table)
        {
            Boolean returnFlg = false;
            this.SetFormerLastInvoicedAmount(BeforeDropedInvoicedAmount); //Customer
            
            BrochureByCustomer oBrochure = new BrochureByCustomer(CompanyID,ID);
            DataTable dt = oMySql.GetDataTable(String.Format("Select * from BrochureByCustomer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Tmp");
            if (dt != null)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if (oBrochure.Find(row["BrochureID"].ToString()))
                    {
                        oBrochure.ProfitPercent-=5;
                        oBrochure.Save();
                        //return true;
                    }
                }
                
                returnFlg = true;
            }
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (oBrochure.Find(row["BrochureID"].ToString()))
                    {
                        oBrochure.FormerInvoiceAmount = (Double)row["Total"];
                        //oBrochure.ProfitPercent -= 5;
                        oBrochure.Save();
                        //return true;
                    }
                }
                
                returnFlg = true;
            }
            return false;
        }
        private void UpdateInventory()
        {
            Inventory oInventory = new Inventory(CompanyID);
            oInventory.Update(this, Inventory.InventoryType.Commit);
        }
        private DataTable CreateDetailTable(DataTable dvInv)
        {
            //DataTable dvInv = new DataTable();

            //dvInv = GetTotalDataTable("ProductID");
            //

            DataTable dtItems = new DataTable("Detail");

            DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("CustomerID", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Description", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Quantity", Type.GetType("System.Int32"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Price", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Tax", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Total", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            colWork = new DataColumn("ProductID_2", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Description_2", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Quantity_2", Type.GetType("System.Int32"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Price_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            colWork = new DataColumn("Tax_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Total_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            int Couples = 0;
            DataRow row = dtItems.NewRow();
            foreach (DataRow dvRow in dvInv.Rows)
            {
                //this.Retail += (Double) dvRow["RetailNoTax"];
                //this.Tax += (Double)dvRow["Tax"];

                if (Couples == 0)
                {
                    row = dtItems.NewRow();
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["ProductID"] = dvRow["ProductID"];
                    row["Description"] = dvRow["Description"];
                    row["Quantity"] = dvRow["Quantity"];
                    row["Price"] = dvRow["Cost"];
                    row["Tax"] = dvRow["Tax"];
                    row["Total"] = dvRow["Total"];
                    //dtItems.Rows.Add(row);

                    Couples = 1;
                }
                else
                {
                    //DataRow row = dtItems.NewRow();
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["ProductID_2"] = dvRow["ProductID"];
                    row["Description_2"] = dvRow["Description"];
                    row["Quantity_2"] = dvRow["Quantity"];
                    row["Price_2"] = dvRow["Cost"];
                    row["Tax_2"] = dvRow["Tax"];
                    row["Total_2"] = dvRow["Total"];
                    dtItems.Rows.Add(row);

                    Couples = 0;
                }
            }
            if (Couples == 1)
            {
                row["Total_2"] = 0;
                row["Quantity_2"] = 0;
                dtItems.Rows.Add(row);
            }

            return dtItems;
        }
        private DataTable CreateDetailTableGPI(DataTable dvInv)
        {
            //DataTable dvInv = new DataTable();

            //dvInv = GetTotalDataTable("ProductID");


            DataTable dtItems = new DataTable("Detail");

            DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("CustomerID", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Description", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Quantity", Type.GetType("System.Int32"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Price", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("PriceDist", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Total", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("TotalDist", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            colWork = new DataColumn("ProductID_2", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Description_2", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Quantity_2", Type.GetType("System.Int32"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Price_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            colWork = new DataColumn("PriceDist_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Total_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("TotalDist_2", Type.GetType("System.Double"));
            dtItems.Columns.Add(colWork);


            int Couples = 0;
            DataRow row = dtItems.NewRow();
            foreach (DataRow dvRow in dvInv.Rows)
            {
                //this.Retail += (Double) dvRow["RetailNoTax"];
                //this.Tax += (Double)dvRow["Tax"];

                if (Couples == 0)
                {
                    row = dtItems.NewRow();
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["ProductID"] = dvRow["ProductID"];
                    row["Description"] = dvRow["Description"];
                    row["Quantity"] = dvRow["Quantity"];
                    row["Price"] = dvRow["dPrice"];
                    row["PriceDist"] = dvRow["rPrice"];
                    row["Total"] = dvRow["rTotal"];
                    row["TotalDist"] = dvRow["dTotal"];
                    //dtItems.Rows.Add(row);

                    Couples = 1;
                }
                else
                {
                    //DataRow row = dtItems.NewRow();
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["ProductID_2"] = dvRow["ProductID"];
                    row["Description_2"] = dvRow["Description"];
                    row["Quantity_2"] = dvRow["Quantity"];
                    row["Price_2"] = dvRow["dPrice"];
                    row["PriceDist_2"] = dvRow["rPrice"];
                    row["Total_2"] = dvRow["rTotal"];
                    row["TotalDist_2"] = dvRow["dTotal"];
                    dtItems.Rows.Add(row);

                    Couples = 0;
                }
            }
            if (Couples == 1)
            {
                row["Total_2"] = 0;
                row["TotalDist_2"] = 0;
                row["Quantity_2"] = 0;
                dtItems.Rows.Add(row);
            }

            return dtItems;
        }

        public void GenerateInvoiceXLSFile()
        {

            DataSet ds = new DataSet();
            DataTable dvInv = new DataTable();
            String Sql = String.Format("SELECT od.OrderID, o.Teacher, o.Student , s.Attention, s.Address,s.City, s.State, s.ZipCode, s.DayPhone,  t.TrackingNumber, od.ProductID,p.Description, od.Quantity,p.Price FROM OrderDetail od Left Join Shortage s On od.OrderID=s.OrderID Left Join Orders o On o.ID=od.OrderID Left Join UPS_TrakingNumber t On s.ShortageID=t.ShortageID Left Join  Product p On od.CompanyID=p.CompanyID and od.ProductID=p.ProductID Where od.CompanyID='{0}' And od.CustomerID='{1}' Group By od.CustomerID, o.Teacher, o.Student, od.ProductID Order By od.CustomerID, o.Teacher, o.Student, od.ProductID", this.CompanyID, this.ID);
            dvInv = oMySql.GetDataTable(String.Format("SELECT o.CustomerID, od.OrderID, o.Teacher, o.Student , s.Attention, s.Address,s.City, s.State, s.ZipCode, s.DayPhone,  t.TrackingNumber, od.ProductID,p.Description, od.Quantity,p.Price FROM OrderDetail od Left Join Shortage s On od.OrderID=s.OrderID Left Join Orders o On o.ID=od.OrderID Left Join UPS_TrakingNumber t On s.ShortageID=t.ShortageID Left Join  Product p On od.CompanyID=p.CompanyID and od.ProductID=p.ProductID Where od.CompanyID='{0}' And od.CustomerID='{1}' Group By od.CustomerID, o.Teacher, o.Student, od.ProductID Order By od.CustomerID, o.Teacher, o.Student, od.ProductID", this.CompanyID, this.ID), "InvoiceDetail");
            ds.Tables.Add(CreateInvoiceGPITable(dvInv)); //Detail

            frmViewReport oViewReport = new frmViewReport();
            //ds.WriteXml("Invoice.xml", XmlWriteMode.WriteSchema);
            CustomerInvoiceXLSFile oRpt = new CustomerInvoiceXLSFile();
            oRpt.SetDataSource(ds);
            //ds.WriteXml("InvoiceXLSFile.xml", XmlWriteMode.WriteSchema);

            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();


            try
            {
                ExportOptions CrExportOptions;

                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "Invoice-"+this.ID+".xls";
                CrExportOptions = oRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.Excel;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                oRpt.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            ds.Dispose();
            oRpt.Dispose();
        }
        
        private DataTable CreateInvoiceGPITable(DataTable dvInv)
        {
            //DataTable dvInv = new DataTable();

            //dvInv = GetTotalDataTable("ProductID");
            //Teacher	Student	Shortage ATTN/CHILD	Shortage Address	Shortage Owensboro	Shortage State	Shortage ZipCode	Shortage Day Phone	Shortage Tracking Number	
            //Item#1	Description#1	Price#1


            DataTable dtItems = new DataTable("Detail");

            DataColumn colWork;

            colWork = new DataColumn("CustomerID", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Teacher", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Student", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageATTN", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageAddress", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageCity", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageState", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageZipCode", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageDayPhone", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("ShortageTrackingNumber", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            
            Int32 x=1;
            for (x = 1; x < 20; x++)
            {
                colWork = new DataColumn("ProductID_" + x.ToString(), Type.GetType("System.String"));
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Description_" + x.ToString(), Type.GetType("System.String"));
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Quantity_"+x.ToString(), Type.GetType("System.Int32"));
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Price_" + x.ToString(), Type.GetType("System.Double"));
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Total_" + x.ToString(), Type.GetType("System.Double"));
                dtItems.Columns.Add(colWork);
            }

            //od.OrderID, o.Teacher, o.Student , s.Attention, s.Address,s.City, s.State, s.ZipCode, s.DayPhone,  t.TrackingNumber, od.ProductID,p.Description, od.Quantity,p.Price

            Int32 OrderID = 0;
            DataRow row = dtItems.NewRow();
            Int32 RecSeq = 0;
            foreach (DataRow dvRow in dvInv.Rows)
            {

                if (OrderID != (Int32)dvRow["OrderID"])
                {
                    if (RecSeq != 0)
                        dtItems.Rows.Add(row);
                    
                    OrderID = (Int32)dvRow["OrderID"];

                    row = dtItems.NewRow();
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["Teacher"] = dvRow["Teacher"];
                    row["Student"] = dvRow["Student"];
                    row["ShortageATTN"] = dvRow["Attention"];
                    row["ShortageAddress"] = dvRow["Address"];
                    row["ShortageCity"] = dvRow["City"];
                    row["ShortageState"] = dvRow["State"];
                    row["ShortageZipCode"] = dvRow["ZipCode"];
                    row["ShortageDayPhone"] = dvRow["DayPhone"];
                    row["ShortageTrackingNumber"] = dvRow["TrackingNumber"];


                    RecSeq = 1;
                    row["ProductID_"+RecSeq.ToString()] = dvRow["ProductID"];
                    row["Description_" + RecSeq.ToString()] = dvRow["Description"];
                    row["Quantity_" + RecSeq.ToString()] = dvRow["Quantity"];
                    row["Price_" + RecSeq.ToString()] = dvRow["Price"];
                }
                else
                {
                    RecSeq++;
                    row["ProductID_" + RecSeq.ToString()] = dvRow["ProductID"];
                    row["Description_" + RecSeq.ToString()] = dvRow["Description"];
                    row["Quantity_" + RecSeq.ToString()] = dvRow["Quantity"];
                    row["Price_" + RecSeq.ToString()] = dvRow["Price"];
                }
                
            }


            return dtItems;
        }
        public void PrintInvoiceByDate(String PrintName, String _CustomerID_, Object DFrom, Object DTo, String DateType, String InvoiceNote, Boolean IsPreInvoice)
        {

            if (_CustomerID_.Trim() != "")
            {
                if (this.Find(_CustomerID_))
                {
                    if (PrintName == "PDF")
                        this.Print(PrintTo.File, PrintName, InvoiceNote, IsPreInvoice);
                    else
                        this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                }
                return;
            }


            String DateSql = "";
            String DateFrom = "";
            String DateTo = "";
            if (DFrom != null)
            {
                DateTime Date_From = (DateTime)DFrom;
                DateFrom = Date_From.ToString("yyyy-MM-dd");
            }
            if (DTo != null)
            {
                DateTime Date_To = (DateTime)DTo;
                DateTo = Date_To.ToString("yyyy-MM-dd");
            }


            DataSet ds = new DataSet();
            String Sql = "";

            switch (DateType)
            {
                case "All":
                    DateSql = "";
                    break;
                default:
                    DateSql = " And " + DateType + "Date";
                    break;

            }
            if (DateType != "") //Thus All
            {
                if (DateFrom.Trim().Length > 0)
                    Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

                if (DateTo.Trim().Length > 0)
                    Sql += String.Format(DateSql + " <= '{0}'", DateTo);
            }

            DataTable dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} Order By Date,Name", CompanyID, Sql), "Tmp");


            foreach (DataRow row in dt.Rows)
            {
                if (DateType == "Delivery")
                {
                    if (row["ShipDate"] == DBNull.Value)
                    {
                        if (this.Find(row["CustomerID"].ToString()))
                        {
                            if (PrintName == "PDF")
                                this.Print(PrintTo.File, PrintName, InvoiceNote, IsPreInvoice);
                            else
                                this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                            

                        }
                    }
                }
                else
                {
                    if (this.Find(row["CustomerID"].ToString()))
                    {
                        if (PrintName == "PDF")
                            this.Print(PrintTo.File, PrintName, InvoiceNote, IsPreInvoice);
                        else
                            this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                            
                        

                    }
                }

            }


        }
        public void PrintOverageReport()
        {
            DataTable tOverage = GetOverageTable();
            
            if ( tOverage == null || tOverage.Rows.Count == 0 )
            {
                MessageBox.Show("This Customer doesn't have an Invoice");
                return;
            }

            DataSet ds = new DataSet();
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from OrderOverage  Where CompanyID='{0}' And  CustomerID='{1}' And Date > Date('{2}')", CompanyID, this.ID, oCharge.Date.ToString("yyyy-MM-dd hh:mm:ss")), "Overage"));
            ds.Tables.Add(tOverage);
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Orders Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Orders"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CustomerID='{0}' And CompanyID='{1}'", ID, CompanyID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Product Where CompanyID='{0}'", CompanyID), "Product"));

            
          //  ds.WriteXml("Overage2.xml");
          
            
            frmViewReport oViewReport = new frmViewReport();

            OverageReport oRpt = new OverageReport();
            oRpt.SetDataSource(ds);

            
            //oRpt.PrintToPrinter(1, false, 0, 0);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public void ConvertInvoiceToOrder(String CompanyID, String CustomerID, String Teacher)
        {
            Double DropPercentageCustomer = 0.00;
            Double DropPercentageItem = 0.00;

            DataTable dvInv = new DataTable();
            dvInv = GetTotalDataTable("ProductID", DropPercentageCustomer, DropPercentageItem);
            if (dvInv.Rows.Count == 0)
            {
                MessageBox.Show("No Invoice Available for : " + CustomerID);
                return;
            }

            Order oOrder = new Order(CompanyID);

            oOrder.CustomerID = CustomerID;
            oOrder.oCustomer.Find(oOrder.CustomerID);
            oOrder.oCustomer.Brochures.Load(CompanyID, oOrder.CustomerID);
            oOrder.Teacher = Teacher;


            oOrder.Items.Clear();

            Boolean firtTime = true;
            foreach (DataRow dvRow in dvInv.Rows)
            {
                if (firtTime)
                {
                    oOrder.Student = dvRow["Student"].ToString();
                    firtTime = false;
                }


          //      if (oOrder.oProduct.Find(dvRow["ProductID"].ToString()))
                {
                    // Console.Out.WriteLine("Price: " + oOrder.oProduct.Price.ToString());

                    Order.Item Item = new Order.Item();
                    Item.ProductID = dvRow["ProductID"].ToString();
                    Item.Quantity = Convert.ToInt32(dvRow["Quantity"].ToString());
                    Item.Description = dvRow["Description"].ToString();
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    /*
                    row["CustomerID"] = dvRow["CustomerID"];
                    row["ProductID"] = 
                    row["Description"] = ;
                    row["Quantity"] = ;
                    row["Price"] = dvRow["Cost"];
                    row["Tax"] = dvRow["Tax"];
                    row["Total"] = dvRow["Total"];
                */

                    //oOrder.Items.Add(oOrder.oProduct.ID, Item);
                    oOrder.Items.Add(dvRow["ProductID"].ToString(), Item);
                }
            }
            oOrder.GetTotals();
            oOrder.Collected = oOrder.Retail;
            oOrder.Save();




        }

        #endregion
        

    }

}
