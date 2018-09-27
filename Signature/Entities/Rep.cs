using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Signature.Reports;
using CrystalDecisions.Web;
using System.Collections;






namespace Signature.Classes
{
    public class Rep:Company
    {
        // Properties
        public Int32 RepID;
        public new Int32 ID;
        private String _Name;
        public new String Address;
        public new String City;
        public new String State;
        public new String ZipCode;
        public String Contact;
        public new String Phone;
        public new String Fax;
        public Boolean IsChargesListed;
        public Boolean IsCompetitorsBrochure;
        public Boolean IsNotShowCommission;

        

        private String _eMail;
        public String eMail
        {
            get { return _eMail; }
            set { _eMail = value; }

        }

        public _Items Items;

        //Methods
        public Rep():base()
        {   
            this.CompanyID = base.ID;
            this.Items = new _Items(this.CompanyID);
        } //Constructor

        public Rep(String CompanyID):base(CompanyID)
        {
            
            this.ID = 0;
            this.CompanyID = CompanyID;
            this.Items = new _Items(this.CompanyID);

        } //Constructor

        public bool Find(int ID)
        {
            Clear();

            if (ID == 0)
                return false;

            DataRow rProduct = this.oMySql.GetDataRow("Select * From Reps Where ID='" + ID.ToString() + "'", "Rep");


            if (rProduct == null)
            {

                this._Name = "No rep found!";
                return false;
            }

            
            this.RepID              = (Int32)rProduct["ID"];
            this._Name              = rProduct["Name"].ToString();
            this.Address            = rProduct["Address"].ToString();
            this.Phone              = rProduct["PhoneNumber"].ToString();
            this.Fax                = rProduct["FaxNumber"].ToString();
            this.eMail              = rProduct["eMail"].ToString();
            this.State              = rProduct["State"].ToString();
            this.City               = rProduct["City"].ToString();
            this.ZipCode            = rProduct["ZipCode"].ToString();
            this.Contact            = rProduct["Contact"].ToString();
            this.IsChargesListed    = (Boolean)rProduct["ViewList"];
            this.IsCompetitorsBrochure = (Boolean)rProduct["ViewBrochures"];
            this.IsNotShowCommission    = (Boolean)rProduct["NotShowCommission"];
            this.ID                 = (Int32)rProduct["ID"];

            this.GetRepBySeason();
            
            return true;

        }

        public bool GetRepBySeason()
        {
            if (RepID == 0)
                return false;

            DataRow rProduct = this.oMySql.GetDataRow("Select * From Rep Where ID='" + RepID + "' And CompanyID='" + CompanyID + "'", "Company");


            if (rProduct == null)
            {

                
                return false;
            }

            return true;
        }
        
        public override bool View()
        {
            frmViewReps oView = new frmViewReps(CompanyID,true);
            oView.ShowDialog();
            if (oView.sSelectedID != 0)
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
        public  bool ViewByID()
        {
            frmViewRepsByID oView = new frmViewRepsByID();
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(Convert.ToInt32(oView.sSelectedID));
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
            String Sql = String.Format("Update Reps Set Name=\"{0}\", PhoneNumber='{1}', FaxNumber='{2}', eMail=\"{3}\", ViewList=\"{4}\", Address=\"{5}\", ViewBrochures=\"{6}\", NotShowCommission='{7}', State=\"{8}\", Contact=\"{9}\", City=\"{10}\", ZipCode=\"{11}\"   Where ID='" + this.RepID + "'",
                this.Name, this.Phone, this.Fax, this.eMail, this.IsChargesListed ? "1" : "0", this.Address, this.IsCompetitorsBrochure ? "1" : "0", this.IsNotShowCommission ? "1":"0",this.State,this.Contact,this.City,this.ZipCode);
            oMySql.exec_sql(Sql);
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Reps (Name, PhoneNumber, FaxNumber, eMail,ViewList,Address, ViewBrochures, NotShowCommission, State, Contact, City, ZipCode)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}',\"{5}\",'{6}','{7}',\"{8}\",\"{9}\",\"{10}\",\"{11}\")",
                this.Name, this.Phone, this.Fax, this.eMail, this.IsChargesListed ? "1" : "0", this.Address, this.IsCompetitorsBrochure ? "1" : "0", this.IsNotShowCommission ? "1":"0",this.State,this.Contact,this.City,this.ZipCode);
            this.RepID = oMySql.exec_sql_id(Sql);
        }
   

        public bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Reps Where ID='" + this.RepID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Delete()
        {
            String Sql = "Delete From Reps Where ID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        public void Clear()
        {
                ID=0;
                _Name=String.Empty;
                Address=String.Empty;
                City = String.Empty;
                State = String.Empty;
                ZipCode = String.Empty;
                Contact = String.Empty;
                Phone = String.Empty;
                Fax = String.Empty;
                
                IsChargesListed = false;
                RepID = 0;
        }

        
        public new String Name
        {
            get { return _Name; }
            set { _Name = value;  }
        }

        public void PrintCommissionChargesReport(String PrinterName, PrinterDevice Device)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT c.Rep_ID, c.RepID, rs.Name FROM Customer c Left Join Reps rs On rs.ID=c.Rep_ID  Where c.CompanyID='{0}' And Rep_ID>0 Group By c.Rep_ID Order By rs.Name", this.CompanyID), "Rep"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT Rep_ID, sum(Charge) as Charge FROM rep_charges r Where Rep_ID > 0 Group By Rep_ID"), "Charge"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT c.CustomerID, bc.BrochureID, r.ID as Rep_ID, rs.Name, sum(bc.InvoiceAmount) as InvoiceAmount, sum(bc.TaxAmount) as TaxAmount,sum(bc.TaxAmount) as TaxAmount,if(c.Retail>=2500,sum(bc.InvoiceAmount - bc.TaxAmount),sum(bc.InvoiceAmount*(100-(bc.ProfitPercent+5))/(100-bc.ProfitPercent) -bc.TaxAmount)) as InvoiceableAmount, sum(if(c.Retail>=2500,(bc.InvoiceAmount - bc.TaxAmount),(bc.InvoiceAmount*(100-(bc.ProfitPercent+5))/(100-bc.ProfitPercent) -bc.TaxAmount))*bc.CODE/100) as Commission FROM Rep r  Left Join Reps rs On r.ID=rs.ID Left Join Customer c On r.ID=c.Rep_ID  and r.CompanyID=c.CompanyID Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID and c.CustomerID=bc.CustomerID Where r.CompanyID='{0}' And rs.Name is not Null Group By c.Rep_ID Order By rs.ID", this.CompanyID), "Commission"));
            
            CommissionChargesRep oRpt = new CommissionChargesRep();

            oRpt.SetDataSource(ds);

           // ds.WriteXml("CommissionChargesReport1.xml", XmlWriteMode.WriteSchema);


            if (Device == PrinterDevice.Printer)
            {
                //oRpt.PrintOptions.PrinterName = "\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
                //oViewReport.cReport.ReportSource = oRpt;
                //oViewReport.cReport.PrintReport();
            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }

        }
        public void PrintCommissionReport(String Rep_From, String Rep_To, String PrinterName, Boolean isToPrinter)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();



            if (Rep_From.Trim() == "" && Rep_To.Trim() == "")
            {
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Rep  r  Left Join Reps rs On rs.ID=r.ID Where CompanyID='{0}'", this.CompanyID), "Rep"));
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT * FROM Customer Where CompanyID='{0}' And LastInvoiceAmount > 0 ", CompanyID), "Customer"));
            }
            else
            {
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Rep r  Left Join Reps rs On rs.ID=r.ID Where r.CompanyID='{0}' And RepID >= '{1}' And RepID <='{2}'", this.CompanyID, Rep_From, Rep_To), "Rep"));
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT * FROM Customer Where CompanyID='{0}' And LastInvoiceAmount > 0 And RepID >= '{1}' And RepID<='{2}'", CompanyID, Rep_From, Rep_To), "Customer"));
            }
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from BrochureByCustomer Where CompanyID='{0}'",CompanyID),"BrochureByCustomer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Brochure Where CompanyID='{0}'", CompanyID), "Brochure"));

            foreach (DataRow row in ds.Tables["Customer"].Rows)
            {
                if ((Double)row["FormerLastInvoicedAmount"] > 0)
                    row["LastInvoiceAmount"] = row["FormerLastInvoicedAmount"];
            }
            ds.Tables["Customer"].AcceptChanges();

           // ds.WriteXml("PrintCommissionReport.xml", XmlWriteMode.WriteSchema);

            CommissionSalesRep oRpt = new CommissionSalesRep();

            oRpt.SetDataSource(ds);

           // oRpt.PrintOptions.PrinterName = "";
           // oRpt.PrintToPrinter(1, false, 0, 0);
          
            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();

            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName = "\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
                //oViewReport.cReport.ReportSource = oRpt;
                //oViewReport.cReport.PrintReport();
            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }


        }
        public void PrintCommissionSummaryReport(String Rep_From, String Rep_To)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();



            if (Rep_From.Trim() == "" && Rep_To.Trim() == "")
            {
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Rep  r  Left Join Reps rs On rs.ID=r.ID Where CompanyID='{0}'", this.CompanyID), "Rep"));
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT * FROM Customer Where CompanyID='{0}' And LastInvoiceAmount > 0 ", CompanyID), "Customer"));
            }
            else
            {
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Rep r  Left Join Reps rs On rs.ID=r.ID Where r.CompanyID='{0}' And RepID >= '{1}' And RepID <='{2}'", this.CompanyID, Rep_From, Rep_To), "Rep"));
                ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("SELECT * FROM Customer Where CompanyID='{0}' And LastInvoiceAmount > 0 And RepID >= '{1}' And RepID<='{2}'", CompanyID, Rep_From, Rep_To), "Customer"));
            }
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from BrochureByCustomer Where CompanyID='{0}'", CompanyID), "BrochureByCustomer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Brochure Where CompanyID='{0}'", CompanyID), "Brochure"));

            foreach (DataRow row in ds.Tables["Customer"].Rows)
            {
                if ((Double)row["FormerLastInvoicedAmount"] > 0)
                    row["LastInvoiceAmount"] = row["FormerLastInvoicedAmount"];
            }
            ds.Tables["Customer"].AcceptChanges();


            //ds.WriteXml("PrintCommissionSummaryReport.xml", XmlWriteMode.WriteSchema);
            CommissionSalesSummaryRep oRpt = new CommissionSalesSummaryRep();

            oRpt.SetDataSource(ds);

            // oRpt.PrintOptions.PrinterName = "";
            // oRpt.PrintToPrinter(1, false, 0, 0);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

        }
        public void PrintGACommissionReport()
        {

           // DataSet ds = Global.oMySql.GetDataset(String.Format("CALL GARepCommissions('{0}');", this.CompanyID));

            DataSet ds = new DataSet();
            
            DataTable table = Global.oMySql.GetDataTable(String.Format(@"Select c.RepID, r.Name as RepName, c.CustomerID, c.Name, c.SalesTax, sum(bc.Amount)*-1 aS TotalPayment, sum(bc.Amount)*-1*(1-c.SalesTax/100) as TotalNoTax,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)<=1000,0,if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=1001 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<25000 ,10,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=25000 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<75000 ,15,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=75000 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<125000 ,17,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=12500 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<250000 ,20,22
))))) as CommPercent,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)<=1000,0,if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=1001 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<25000 ,10,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=25000 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<75000 ,15,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=75000 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<125000 ,17,
if(sum(bc.Amount)*-1*(1-c.SalesTax/100)>=12500 And sum(bc.Amount)*-1*(1-c.SalesTax/100)<250000 ,20,22
)))))/100*sum(bc.Amount)*-1*(1-c.SalesTax/100) as Commission

from Customer c
Left Join Reps r On c.Rep_ID=r.ID
Left Join Payment bc On  c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And bc.Type='P' Group By c.RepID, c.CustomerID", this.CompanyID),"Commissions");

            ds.Tables.Add(table);

            frmViewReport oViewReport = new frmViewReport();
            ds.WriteXml("GARepCommissionsReport.xml", XmlWriteMode.WriteSchema);

            GARepCommissions oRpt = new GARepCommissions();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();

        }
        public void PrintGACommissionReport(CrystalReportViewer oViewer)
        {

            DataSet ds = Global.oMySql.GetDataset(String.Format("CALL GARepCommissions('{0}');", this.CompanyID));



            ds.Tables[0].TableName = "Customer";
            ds.Tables[1].TableName = "Reps";
            ds.Tables[2].TableName = "Payments";

            //frmViewReport oViewReport = new frmViewReport();
            //ds.WriteXml("GARepCommissions1.xml", XmlWriteMode.WriteSchema);

            GARepCommissions oRpt = new GARepCommissions();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();

            oViewer.ReportSource = oRpt;
            

            //ds.Dispose();
            //oRpt.Dispose();
            //oViewReport.Dispose();

        }
        public void PrintRepSalesReport()
        {

            frmViewReport oViewReport = new frmViewReport();
            //DataSet ds = oMySql.get_summary_reps_sales(this.CompanyID);

            
            DataSet ds = new DataSet();
            
            Boolean nView = true;
            /*
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *, c.Retail/c.NoSellers as Avg_Retail, c.NoItems/c.NoSellers as Av_Units FROM Customer c Where c.CompanyID='{0}'", this.CompanyID), "Summary"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * from  BrochureByCustomer  Where CompanyID='{0}' ", this.CompanyID), "BrochureByCustomer"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT *  FROM Brochure Where CompanyID ='" + this.CompanyID + "' ", "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT *  FROM Prizes   Where CompanyID ='" + this.CompanyID + "' ", "Prize"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Rep r Left Join Reps rs On r.ID = rs.ID  Where r.CompanyID ='{0}' and rs.Name is not null Order By rs.Name", this.CompanyID), "Reps"));
            */
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *, c.Retail/c.NoSellers as Avg_Retail, c.NoItems/c.NoSellers as Av_Units FROM Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID AND c.CustomerID=bc.CustomerID Left Join Reps r On c.Rep_ID=r.ID Where c.CompanyID='{0}' ORDER BY r.Name,c.CustomerID", this.CompanyID), "Summary"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT *  FROM Brochure Where CompanyID ='" + this.CompanyID + "' ", "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT *  FROM Prizes   Where CompanyID ='" + this.CompanyID + "' ", "Prize"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT r.*,rs.*,sum(c.Retail) as Retail, sum(Signed) as Signed, sum(NoSellers) as NoSellers, sum(NoItems) as NoItems, count(c.CustomerID) as NoCustomers FROM Rep r Left Join Customer c On c.CompanyID=r.CompanyID And r.ID=c.Rep_ID Left Join Reps rs On r.ID = rs.ID  Where r.CompanyID ='{0}' Group By c.Rep_ID", this.CompanyID), "Reps"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT c.Rep_ID, c.RepID, bc.BrochureID, Avg(bc.Retail/c.Signed) as Retail FROM BrochureByCustomer bc Left Join Customer c On bc.CompanyID=c.CompanyID And bc.CustomerID=c.CustomerID Where bc.CompanyID='{0}' And Rep_ID > 0 Group By c.Rep_ID, bc.BrochureID", this.CompanyID), "Average"));
            
            summary_reps_sales oRpt7 = new summary_reps_sales();
           

            oRpt7.SetDataSource(ds);

          //  ds.WriteXml("RepSalesReport300.xml", XmlWriteMode.WriteSchema);
            if (nView)
            {
                oViewReport.cReport.ReportSource = oRpt7;
                oViewReport.ShowDialog();                
            }
            else
                oRpt7.PrintToPrinter(1, true, 1, 100);
        }
        public void PrintRepSalesByBrochureReport()
        {

            frmViewReport oViewReport = new frmViewReport();
            //DataSet ds = oMySql.get_summary_reps_sales(this.CompanyID);


            DataSet ds = new DataSet();

            Boolean nView = true;
            
            ds.Tables.Add(oMySql.GetDataTable("SELECT *  FROM Brochure Where CompanyID ='" + this.CompanyID + "' ", "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT c.Rep_ID, c.RepID, r.Name, Avg(bc.Retail/c.Signed) as Average FROM BrochureByCustomer bc  Left Join Customer c On bc.CompanyID=c.CompanyID And bc.CustomerID=c.CustomerID Left Join Reps r On c.Rep_ID=r.ID Where bc.CompanyID='{0}' And Rep_ID > 0 Group By c.Rep_ID", this.CompanyID), "Reps"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT c.Rep_ID, c.RepID, bc.BrochureID, Avg(bc.Retail/c.Signed) as Retail,c.Signed FROM BrochureByCustomer bc Left Join Customer c On bc.CompanyID=c.CompanyID And bc.CustomerID=c.CustomerID Where bc.CompanyID='{0}' And Rep_ID > 0 Group By c.Rep_ID, bc.BrochureID", this.CompanyID), "Average"));

            RepSalesByBrochure oRpt7 = new RepSalesByBrochure();

            oRpt7.SetDataSource(ds);

          //  ds.WriteXml("RepSalesByBrochure3.xml", XmlWriteMode.WriteSchema);
            if (nView)
            {
                oViewReport.cReport.ReportSource = oRpt7;
                oViewReport.ShowDialog();
            }
            else
                oRpt7.PrintToPrinter(1, true, 1, 100);
        }

        #region Classes & Enumerators
        public class _Items : Hashlist //, IList
        {

            public DataTable dtItems = new DataTable("Detail");
            public _Items()
            {
                SetColumns();
            }
            public _Items(String CompanyID)
                : base(CompanyID)
            {
                SetColumns();
            }
            public void SetColumns()
            {
                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
                // colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Item ID";
                colWork.ReadOnly = false;
                this.dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Description", Type.GetType("System.String"));
                colWork.Caption = "Description";
                colWork.MaxLength = 200;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);


                //colWork = new DataColumn("InvCode", Type.GetType("System.String"));
                //dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Price", Type.GetType("System.Double"));
                colWork.Caption = "Price";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Cost", Type.GetType("System.Double"));
                colWork.Caption = "Cost";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("HTS_Number", Type.GetType("System.String"));
                colWork.Caption = "HTS Number";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("HTS_Rate", Type.GetType("System.Double"));
                colWork.Caption = "HTS Rate";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("HTS_Price", Type.GetType("System.Double"));
                colWork.Caption = "HTS Price";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Country", Type.GetType("System.String"));
                colWork.Caption = "Country";
                colWork.MaxLength = 150;
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                return;
            }
            public void AddEmpty1()
            {
                Item _Item = new Item();
                _Item.Description = "";
                _Item.ProductID = "";

                this.Add("ZZZZZ", _Item);
            }
            public void AddEmpty()
            {
                DataRow Detail = dtItems.NewRow();

                Detail["Description"] = "";
                Detail["ProductID"] = "";
                //Detail["InvCode"] = "";
                
                dtItems.Rows.Add(Detail);
            }
            public void Load(String CompanyID, Int32 RepID)
            {
                
                if (dtItems.Rows.Count > 0)
                    dtItems.Rows.Clear();

                DataView tDetail;
                tDetail = oMySql.GetDataView(String.Format("SELECT pb.RepID, pb.ProductID, p.Description, p.InvCode, pb.Retail as Price, pb.Cost, pb.HTS_Number, pb.HTS_Rate, pb.HTS_Price, pb.Country FROM ProductByRep pb left join Product p on pb.CompanyID=p.CompanyID And pb.ProductID=p.ProductID Where pb.CompanyID='{0}' And RepID='{1}'", CompanyID, RepID), "PB");
                
                foreach (DataRow Row in tDetail.Table.Rows)
                {
                    DataRow Detail = dtItems.NewRow();

                    Detail["Description"] = Row["Description"].ToString();
                    Detail["ProductID"] = Row["ProductID"].ToString();
                    //Detail["InvCode"] = Row["InvCode"].ToString();
                    Detail["Price"] = Row["Price"] == DBNull.Value ? 0.0 : (Double)Row["Price"];
                    Detail["Cost"] = Row["Cost"] == DBNull.Value ? 0.0 : (Double)Row["Cost"];
                    Detail["HTS_Number"] = Row["HTS_Number"].ToString();
                    Detail["HTS_Rate"] = Row["HTS_Rate"] == DBNull.Value ? 0.0 : (Double)Row["HTS_Rate"];
                    Detail["HTS_Price"] = Row["HTS_Price"] == DBNull.Value ? 0.0 : (Double)Row["HTS_Price"];
                    Detail["Country"] = Row["Country"].ToString();

                    dtItems.Rows.Add(Detail);

                }

                AddEmpty();
            }
            public void Save(String CompanyID, Int32 RepID)
            {

                this.Delete(CompanyID, RepID);
                foreach (DataRow _Row in dtItems.Rows)
                {
                    Item _Item = new Item();
                    if (_Row["ProductID"].ToString() == "")
                        continue;
                    _Item.RepID = RepID;
                    _Item.CompanyID = CompanyID;
                    _Item.ProductID = _Row["ProductID"].ToString();
                    _Item.Price = _Row["Price"] == DBNull.Value ? 0 : (Double)_Row["Price"];
                    _Item.Cost = _Row["Cost"] == DBNull.Value ? 0 : (Double)_Row["Cost"];
                    _Item.HTS_Number = _Row["HTS_Number"].ToString();
                    _Item.HTS_Rate = (Double)_Row["HTS_Rate"] ;
                    _Item.HTS_Price = (Double)_Row["HTS_Price"];
                    _Item.Country = _Row["Country"].ToString();
                    _Item.Insert();
                }
                dtItems.Rows.Clear();
            }
            public void Delete(String CompanyID, Int32 RepID)
            {
                String Sql = "Delete from ProductByRep where CompanyID='" + CompanyID + "' And RepID = '" + RepID + "'";
                oMySql.exec_sql(Sql);
            }


            /* Hash List Support */
            public new Item this[string Key]
            {
                get { return (Item)base[Key]; }

            }
            public new Item this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Item)oTemp;
                }
            }


            // Expose the enumerator for the associative array.
            public new IEnumerator GetEnumerator()
            {
                return new ItemsEnumerator(this);
            }
        }
        public class Item               //Single instance of detail
        {

            public String CompanyID;
            public String CustomerID;
            private String _Description;
            private String _ProductID;
            private String _InvCode;
            public Int32 RepID;
            public Double Price;
            public Double Cost;
            public String HTS_Number;
            public Double HTS_Rate;
            public Double HTS_Price;
            public String Country;


            Signature.Data.MySQL oMySql = Global.oMySql;

            public Item()
            {
                CompanyID = "";
                CustomerID = "";
                Description = "";
                ProductID = "";
                Price = 0.00;
                Cost = 0.00;
                HTS_Number= "";
                HTS_Rate = 0.00;
                HTS_Price = 0.00;
                Country = "";

            }
            public void Save()
            {
                if (if_exist())
                    Update();
                else
                    Insert();

            }
            public void Update()
            {

                /*  String Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID={5}" + " Where CompanyID=\"" + this.CompanyID + "\"" + " And CustomerID=\"" + this.CustomerID + "\"" + " And ProductID=\"" + this.ProductID + "\"",
                      this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.OrderID);
                  oMySql.exec_sql_afected(Sql);
                  */
            }
            public void Insert()
            {
                String Sql = String.Format("Insert into ProductByRep (CompanyID, RepID, ProductID, Retail,Cost,HTS_Number,HTS_Rate,HTS_Price, Country)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}',\"{5}\",'{6}','{7}',\"{8}\")",
                    this.CompanyID, this.RepID, this.ProductID, this.Price,this.Cost,HTS_Number,HTS_Rate,HTS_Price,this.Country);
                oMySql.exec_sql_afected(Sql);

            }
            public void Delete()
            {
                String Sql = "Delete from BrochureDetail where CompanyID='" + CompanyID + "' And  And ProductID = '" + ProductID + "'";
                oMySql.exec_sql(Sql);
            }
            public bool if_exist()
            {
                /* if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where OrderID=" + this.OrderID + " And ProductID='" + this.ProductID + "'") == 0)
                 {
                     return false;
                 }*/
                return true;
            }



            public String Description
            {
                get { return _Description; }


                set
                {
                    _Description = value;
                }
            }
            public String ProductID
            {
                get { return _ProductID; }


                set
                {
                    _ProductID = value;
                }
            }
            public String InvCode
            {
                get { return _InvCode; }


                set
                {
                    _InvCode = value;
                }
            }

        }
        public class ItemsEnumerator : IEnumerator
        {
            public ItemsEnumerator(_Items ar)
            {
                _ar = ar;
                _currIndex = -1;
            }
            public object Current
            {
                get
                {
                    return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                }
            }
            public bool MoveNext()
            {
                _currIndex++;
                if (_currIndex == _ar.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _currIndex = -1;
            }

            // The index of the item this enumerator applies to.
            protected int _currIndex;
            // A reference to this enumerator's associative array.
            protected _Items _ar;


        }


        #endregion
    }
}
