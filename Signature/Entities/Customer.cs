using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Signature.Classes;
using Signature.Data;
using Signature.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using CrystalDecisions.Web;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Signature.Classes
{
    [Serializable()]
    public class Customer:Company
    {
        #region Properties
        // Properties
        public new  String ID;
        
        public new String Name;
        public new String Address;
        public new String City;
        public new String State;
        public new String ZipCode;
        public String County;
        public String Chairperson;
        public String HeadPhone;
        public String HeadPhoneExt;
        public String PhoneNumber;
        public String FaxNumber;
        public String PhoneNumberExt;
        public DateTime StartDate;
        public DateTime ShipDate;
        public DateTime EndDate;
        public DateTime PickUpDate;
        public DateTime ParentPickUpDate;
        public DateTime SignedDate;
        public DateTime DeliveryDate;
        public DateTime EarlyBirdDate;
        public Boolean CashRegister;
        public String KITS;
        public String eMail;
        public String Rep_Ext;
        public Int32  RepID;
        public String PrizeID;
        public Int32 Signed;
        public String ApplyTax;
        public Double SalesTax;
        public String CollectTax;
        public String PriceListID;
        public Boolean Scanned;
        public Boolean Packed;
        public Boolean Invoiced;
        public Int32 NumberPallets;
        public Double PreviousRetail;
        public Int16 ShipOption;
        

        public Double CODE1;
        public Double CODE2;
        public Double CODE3;
        public Double CODE4;

        public String BrochureID = String.Empty;
        public Double ProfitPercent;
        public String BrochureID_2 = String.Empty;
        public Double ProfitPercent_2;
        public String BrochureID_3 = String.Empty;
        public Double ProfitPercent_3;
        public String BrochureID_4  =   String.Empty;
        public Double ProfitPercent_4;
        

        public String SignedNote;
        public String StartNote;
        public String EndNote;
        public String PickUpNote;
        public String ShipNote;
        public String DeliveryNote;
        public String ParentPickUpNote;


        public String Page;
        public String Grid;


        // Invoice Amounts
        public Double Retail;
        public Double ProfitAmount;
        public Double AmountDue;
        public Int32 NoItems;
        public Int32 NoSellers;
        public Double LastInvoicedAmount;
        public Double FormerLastInvoicedAmount=0;
        public Double TaxAmount;
        public Double InvoicedAmount;
        public Double RetailFeeAmount = 0;
        public Double AddedAmount = 0;
        public Double PaymentsAmount = 0;
        public Double ChargesAmount = 0;
        public Boolean IsLetterAprovalDone;
        public Boolean IsPostPay;
        public String PayableTo;
        public DateTime DatePayable;
        public Boolean Checked;
        

       
        //Invoice Variables
        
        private DateTime DNull = new DateTime(1900, 01, 01);
        private String _BOLTraking;

        public _Kits  Kits = new _Kits();              // GiftA AVenue
        public _ReOrders ReOrders = new _ReOrders();  //Gift Avenue

        public _Payments PaymentsDetail;
        public _Orders Orders;
        public _Brochures Brochures;

        //GA Options

        public Int32 CashRegisters  = 0;
        public Boolean IsOneDaySale = false;
        public Boolean IsAssigned   = false;
        public Boolean IsTreasureChest = false;
        public GiftAvenue oGiftAvenue;
        public CustomerExtra oCustomerExtra; 


        //Properties
        public Int32 NoBoxes
        {
            get
            {
                return GetNoBoxes();
            }
        }
        public Int32 NoClasses
        {
            get
            {
                return GetNoClasses();
            }
        }
        public Boolean IsCombo
        {
            get
            {


                if (oMySql.exec_sql_no(String.Format("SELECT count(distinct(b.PackID)) FROM BrochureByCustomer bc Left Join Brochure b On bc.BrochureID = b.BrochureID And bc.CompanyID=b.CompanyID Where bc.CompanyID='{0}' And CustomerID='{1}' Group By bc.CustomerID", this.CompanyID, this.ID)) > 1)   
                    return true;
                else
                    return false;

            }
        }
        public Double StatementAmountDue
        {
            get
            {
                DataRow rPayment = oMySql.GetDataRow(String.Format("Select sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Tmp");
                if (rPayment == null)
                {
                    return 0;
                }
                else
                {
                    return rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
                }
            }
        }
        public Double GetTaxRate(String City)
        {
                DataRow rPayment = oMySql.GetDataRow(String.Format("Select TaxRate as Tax FROM Tax Where Upper(City)='{0}'", City), "Tmp");
                if (rPayment == null)
                {
                    return 0;
                }
                else
                {
                    return rPayment["Tax"] == DBNull.Value ? 0 : (Double)rPayment["Tax"];
                }
            
        }
       

        #endregion
        #region Methods
        public Customer():base()
        {
            this.CompanyID = base.ID;
            Brochures = new _Brochures(CompanyID);
            if (IsGiftAvenue)
                oGiftAvenue = new GiftAvenue(this.CompanyID);
            oCustomerExtra = new CustomerExtra(this.CompanyID);

        } //Constructor
        public Customer(String _CompanyID):base(_CompanyID) 
        {
            this.CompanyID = _CompanyID;
            Brochures = new _Brochures(CompanyID);
            if (IsGiftAvenue)
                oGiftAvenue = new GiftAvenue(this.CompanyID);
            oCustomerExtra = new CustomerExtra(this.CompanyID);
            
        } //Constructor
        public bool Find(String CustomerID)
        {
            if (CustomerID == "")
            {
                ID = "";
                this.Name = "";
                return false;
            }
            
            this.ID = CustomerID;
            DataRow rCustomer = oMySql.GetDataRow("Select * From Customer Where CompanyID='"+this.CompanyID+"' And CustomerID='" + this.ID + "'", "Customer");
            
            if (rCustomer == null)
            {
                this.ID = "";
                this.Name = "";
                
                return false;
            }
            else
            {
                this.ID = rCustomer["CustomerID"].ToString();
                this.Name = rCustomer["Name"].ToString();
                this.Address = rCustomer["Address"].ToString();
                this.City = rCustomer["City"].ToString();
                this.State = rCustomer["State"].ToString();
                this.ZipCode = rCustomer["ZipCode"].ToString();
                this.County = rCustomer["County"].ToString();
                this.eMail = rCustomer["eMail"].ToString();
                this.Chairperson = rCustomer["Chairperson"].ToString();
                this.Rep_Ext = rCustomer["RepID"].ToString();
                this.RepID = (Int32) rCustomer["Rep_ID"];
                this.PrizeID = rCustomer["PrizeID"].ToString();
                this.PhoneNumber = rCustomer["PhoneNumber"].ToString();
                this.PhoneNumberExt = rCustomer["PhoneNumberExt"].ToString();
                this.FaxNumber = rCustomer["FaxNumber"].ToString();
                this.HeadPhone = rCustomer["HeadPhone"].ToString();
                this.HeadPhoneExt = rCustomer["HeadPhoneExt"].ToString();
                this.StartDate = (rCustomer["StartDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["StartDate"];
                this.EndDate = (rCustomer["EndDate"] == DBNull.Value) ? DNull : (DateTime) rCustomer["EndDate"];
                this.PickUpDate = (rCustomer["PickUpDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["PickUpDate"];
                this.ShipDate = (rCustomer["ShipDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["ShipDate"];
                this.SignedDate = (rCustomer["SignedDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["SignedDate"];
                this.DeliveryDate = (rCustomer["DeliveryDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["DeliveryDate"];
                this.ParentPickUpDate = (rCustomer["ParentPickUpDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["ParentPickUpDate"];
                this.EarlyBirdDate = (rCustomer["EarlyBirdDate"] == DBNull.Value) ? DNull : (DateTime)rCustomer["EarlyBirdDate"];
                this.CashRegister = (Boolean)rCustomer["CashRegister"];
                this.KITS = rCustomer["KITS"].ToString();
                this.Signed = (Int32) rCustomer["Signed"];
                this.ApplyTax = rCustomer["ApplyTax"].ToString();
                this.CollectTax = rCustomer["CollectTax"].ToString();
                this.PriceListID = rCustomer["PriceListID"].ToString();
                this.Scanned = (Boolean) rCustomer["Scanned"];
                this.Packed  = (Boolean) rCustomer["Packed"];
                this.Invoiced = (Boolean)rCustomer["Invoiced"];
                this.NumberPallets = (int) rCustomer["NumberPallets"];
                this.SalesTax = (rCustomer["SalesTax"] == DBNull.Value) ? 0.00 : (Double)rCustomer["SalesTax"];
                this.SignedNote = rCustomer["SignedNote"].ToString();
                this.StartNote = rCustomer["StartNote"].ToString();
                this.EndNote = rCustomer["EndNote"].ToString();
                this.PickUpNote = rCustomer["PickUpNote"].ToString();
                this.ShipNote = rCustomer["ShipNote"].ToString();
                this.DeliveryNote = rCustomer["DeliveryNote"].ToString();
                this.ParentPickUpNote = rCustomer["ParentPickUpNote"].ToString();
                this.Page = rCustomer["Page"].ToString();
                this.Grid = rCustomer["Grid"].ToString();
                this.PreviousRetail = (Double)rCustomer["PreviousRetail"];
                this.IsLetterAprovalDone = (Boolean)rCustomer["IsLetterAprovalDone"];
                this.ShipOption = (Int16)rCustomer["ShipOption"];
                this.IsPostPay = (Boolean)rCustomer["PostPay"];
                this.PayableTo = rCustomer["PayableTo"].ToString();
                this.Checked = (Boolean)rCustomer["Checked"];
                
                //Invoice Amounts
                this.NoSellers = (Int32)rCustomer["NoSellers"];
                this.NoItems = (Int32)rCustomer["NoItems"];
                this.Retail = (Double)rCustomer["Retail"];
                this.ProfitAmount = (Double)rCustomer["ProfitAmount"];
                this.InvoicedAmount = (rCustomer["InvoicedAmount"] == DBNull.Value) ? 0 : (Double)rCustomer["InvoicedAmount"];
                this.TaxAmount = (rCustomer["TaxInvoiced"] == DBNull.Value) ? 0 : (Double)rCustomer["TaxInvoiced"];
                this.AddedAmount = (Double)rCustomer["AddedAmount"];
                this.AmountDue = (Double)rCustomer["AmountDue"];
                this.PaymentsAmount = (Double) rCustomer["Payments"];
                this.ChargesAmount = (Double)rCustomer["ChargesAmount"];
                this.LastInvoicedAmount = (Double)rCustomer["LastInvoiceAmount"];
                this.FormerLastInvoicedAmount = (Double)rCustomer["FormerLastInvoicedAmount"];
                this._BOLTraking   = rCustomer["BOLTracking"].ToString();

                this.DatePayable   = (rCustomer["DatePayable"] == DBNull.Value) ? DNull : (DateTime)rCustomer["DatePayable"];

                this.Printed       = (Boolean)rCustomer["Printed"];

                this.IsOneDaySale  = (Boolean)rCustomer["OneDaySale"];
                this.CashRegisters = (Int32)rCustomer["CashRegisters"];
                this.IsAssigned      = (Boolean)rCustomer["Assigned"];
                this.IsTreasureChest = (Boolean)rCustomer["TreasureChest"];
                

                this.Brochures.Load(this.CompanyID,this.ID);
                this.LoadBrochuresInfo();

                Orders = null;
                Orders = new _Orders(CompanyID, ID);

                if (IsGiftAvenue)
                {
                    if (oGiftAvenue != null)
                        oGiftAvenue.Find(this.ID);
                }

                oCustomerExtra.Find(this.ID);
            }

            return true;
        
        }
        public void LoadBrochuresInfo()
        {
            this.BrochureID = "";
            this.ProfitPercent = 0;
            this.CODE1 = 0;
            
            this.BrochureID_2 = "";
            this.ProfitPercent_2 = 0;
            this.CODE2 = 0;
            
            this.BrochureID_3 = "";
            this.ProfitPercent_3 = 0;
            this.CODE3 = 0;

            this.BrochureID_4 = "";
            this.ProfitPercent_4 = 0;
            this.CODE4 = 0;
            
            Int32 i = 1;
            foreach (BrochureByCustomer oBC in Brochures)
            {
                if (i == 1)
                {
                    BrochureID = oBC.BrochureID;
                    ProfitPercent = oBC.ProfitPercent;
                    CODE1 = oBC.Code;
                }
                if (i == 2)
                {
                    BrochureID_2 = oBC.BrochureID;
                    ProfitPercent_2 = oBC.ProfitPercent;
                    CODE2 = oBC.Code;
                }
                if (i == 3)
                {
                    BrochureID_3 = oBC.BrochureID;
                    ProfitPercent_3 = oBC.ProfitPercent;
                    CODE3 = oBC.Code;
                }
                if (i == 4)
                {
                    BrochureID_4 = oBC.BrochureID;
                    ProfitPercent_4 = oBC.ProfitPercent;
                    CODE4 = oBC.Code;
                }

                i++;
            }
        }
        public void LoadBrochuresInfo1()
        {
            this.BrochureID = "";
            
            this.ProfitPercent = 0;
            this.CODE1 = 0;
            this.BrochureID_2 = "";
            
            this.ProfitPercent_2 = 0;
            this.CODE2 = 0;
            this.BrochureID_3 = "";
            
            this.ProfitPercent_3 = 0;
            this.CODE3 = 0;

            this.ProfitPercent_4 = 0;
            this.CODE4 = 0;

            DataTable dt = oMySql.GetDataTable(String.Format("Select * From BrochureByCustomer Where CompanyID='{0}' And CustomerID='{1}' Order By ID", CompanyID, ID), "BrochureByCustomer");
            if (dt != null && dt.Rows.Count > 0)
            {
                this.BrochureID = dt.Rows[0]["BrochureID"].ToString();
            //    this._BrochureID = dt.Rows[0]["BrochureID"].ToString();
                this.ProfitPercent = (Double)dt.Rows[0]["ProfitPercent"];
                this.CODE1 = (dt.Rows[0]["CODE"] == DBNull.Value) ? 0 : (Double)dt.Rows[0]["CODE"];
                if (dt.Rows.Count > 1)
                {
                    this.BrochureID_2 = dt.Rows[1]["BrochureID"].ToString();
              //      this._BrochureID_2 = dt.Rows[1]["BrochureID"].ToString();
                    this.ProfitPercent_2 = (Double)dt.Rows[1]["ProfitPercent"];
                    this.CODE2 = (dt.Rows[1]["CODE"] == DBNull.Value) ? 0 : (Double)dt.Rows[1]["CODE"];
                }
                if (dt.Rows.Count > 2)
                {
                    this.BrochureID_3 = dt.Rows[2]["BrochureID"].ToString();
                //    this._BrochureID_3 = dt.Rows[2]["BrochureID"].ToString();
                    this.ProfitPercent_3 = (Double)dt.Rows[2]["ProfitPercent"];
                    this.CODE3 = (dt.Rows[2]["CODE"] == DBNull.Value) ? 0 : (Double)dt.Rows[2]["CODE"];
                }
                if (dt.Rows.Count > 3)
                {
                    this.BrochureID_4 = dt.Rows[3]["BrochureID"].ToString();
                    //    this._BrochureID_3 = dt.Rows[2]["BrochureID"].ToString();
                    this.ProfitPercent_4 = (Double)dt.Rows[3]["ProfitPercent"];
                    this.CODE4 = (dt.Rows[3]["CODE"] == DBNull.Value) ? 0 : (Double)dt.Rows[3]["CODE"];
                }
            }
        }
        public bool View(String CompanyID)
        {
            this.CompanyID = CompanyID;
            return this.View();
        }
        public override bool View()
        {
            frmCustomerView oView = new frmCustomerView(this.CompanyID);
			oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.ID = oView.sSelectedID;
                this.Find(oView.sSelectedID);
                
                return true;
            }
            return false;
        }
        public override void Delete()
        {
            String Sql = "Delete From Customer Where CustomerID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);

            if (IsGiftAvenue)
            {
                oGiftAvenue.Delete();
            }

        }
        public new bool  Save()
        {
            if (this.ID.Trim() == "")
            {
                MessageBox.Show("Empty ID ");
                return false;
            }
            
            if (IfExist())
                Update();
            else
                Insert();

            Brochures.CustomerID = this.ID;
            UpdateBrochures();
     
            //GiftAvenue
            if (IsGiftAvenue)
            {
                oGiftAvenue.Save();
            }
            oCustomerExtra.Save();
            this.HasChanged = true;
            return true;
        }
        private void UpdateBrochures()
        {
            this.Brochures.Clear();
            this.Brochures.MarkDeleted();

            BrochureByCustomer oBC ;

            if (this.BrochureID != "")
            {
                oBC = new BrochureByCustomer(this.CompanyID, this.ID);
                oBC.BrochureID = this.BrochureID;
                oBC.ProfitPercent = this.ProfitPercent;
                oBC.Code = this.CODE1;
                oBC.Seq = 1;
                oBC.Save();
                this.Brochures.Add(oBC.BrochureID,oBC);

            }
            if (this.BrochureID_2 != "")
            {
                oBC = new BrochureByCustomer(this.CompanyID, this.ID);
                oBC.BrochureID = this.BrochureID_2;
                oBC.ProfitPercent = this.ProfitPercent_2;
                oBC.Code = this.CODE2;
                oBC.Seq = 2;
                oBC.Save();
                this.Brochures.Add(oBC.BrochureID,oBC);
            }
            if (this.BrochureID_3 != "")
            {
                oBC = new BrochureByCustomer(this.CompanyID, this.ID);
                oBC.BrochureID = this.BrochureID_3;
                oBC.ProfitPercent = this.ProfitPercent_3;
                oBC.Code = this.CODE3;
                oBC.Seq = 3;
                oBC.Save();
                this.Brochures.Add(oBC.BrochureID,oBC);
            }
            if (this.BrochureID_4 != "")
            {
                oBC = new BrochureByCustomer(this.CompanyID, this.ID);
                oBC.BrochureID = this.BrochureID_4;
                oBC.ProfitPercent = this.ProfitPercent_4;
                oBC.Code = this.CODE4;
                oBC.Seq = 4;
                oBC.Save();
                this.Brochures.Add(oBC.BrochureID, oBC);
            }
            this.Brochures.DeleteAll();

        }
        public void UpdateCurrentTotals()
        {
            oMySql.exec_sql(String.Format("Update Customer Set Retail='{0}', TaxInvoiced={1},LastInvoiceAmount='{2}',AmountDue='{3}',NoItems='{4}',NoSellers='{5}',Payments='{6}',AddedAmount='{7}',ChargesAmount='{8}',InvoicedAmount='{9}',ProfitAmount='{10}',ImprintingFee='{11}' Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'",
                            this.Retail, this.TaxAmount, this.LastInvoicedAmount, this.AmountDue, this.NoItems, this.NoSellers, this.PaymentsAmount, this.AddedAmount, this.ChargesAmount, this.InvoicedAmount, this.ProfitAmount, this.RetailFeeAmount));
        }
        public override void Update()
        {
            String Sql = String.Format("Update Customer Set CustomerID='{0}',Name=\"{1}\",Address = \"{2}\",City= '{3}',State= '{4}',ZipCode = '{5}',eMail   = '{6}',Chairperson = \"{7}\",RepID = '{8}',PrizeID = '{9}',PhoneNumber = '{10}',FaxNumber= '{11}',HeadPhone= '{12}',StartDate= {13},EndDate= {14},PickUpDate={15},ShipDate = {16},SignedDate= {17},DeliveryDate= {18},CashRegister= '{19}',KITS= '{20}',Signed='{21}',ApplyTax='{22}',SalesTax='{23}',CollectTax ='{24}',PriceListID = '{25}',StartNote = \"{26}\",HeadPhoneExt = '{27}',PhoneNumberExt = '{28}',PreviousRetail = '{29}',ParentPickUpDate={30},SignedNote=\"{31}\",EndNote=\"{32}\",PickUpNote=\"{33}\",ShipNote=\"{34}\",DeliveryNote=\"{35}\",ParentPickUpNote=\"{36}\",County=\"{37}\",Page=\"{38}\",Grid=\"{39}\",IsLetterAprovalDone='{40}',ShipOption='{41}',CompanyID = '{42}',PostPay = '{43}',PayableTo = \"{44}\" ,DatePayable = {45},Checked = '{46}',CashRegisters = '{47}',OneDaySale = '{48}',Assigned = '{49}',TreasureChest = '{50}', Rep_ID = '{51}',  FormerLastInvoicedAmount = '{52}', EarlyBirdDate = {53} Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'",
            this.ID, this.Name, this.Address, this.City, this.State, this.ZipCode,this.eMail, this.Chairperson, this.Rep_Ext, this.PrizeID, this.PhoneNumber,
            this.FaxNumber,this.HeadPhone,cv_date(this.StartDate),cv_date(this.EndDate),cv_date(this.PickUpDate),cv_date(this.ShipDate),cv_date(this.SignedDate),cv_date(this.DeliveryDate), 
            this.CashRegister ? "1" : "0", this.KITS, this.Signed, this.ApplyTax, this.SalesTax, this.CollectTax, this.PriceListID, this.StartNote, this.HeadPhoneExt,this.PhoneNumberExt,
            this.PreviousRetail,cv_date(this.ParentPickUpDate),this.SignedNote,this.EndNote,this.PickUpNote,this.ShipNote,this.DeliveryNote,this.ParentPickUpNote,this.County, 
            this.Page, this.Grid, this.IsLetterAprovalDone?"1":"0",this.ShipOption,this.CompanyID,this.IsPostPay?"1":"0",this.PayableTo, cv_date(this.DatePayable), 
            this.Checked ? "1" : "0", this.CashRegisters, this.IsOneDaySale ? "1" : "0", this.IsAssigned ? "1" : "0", this.IsTreasureChest ? "1" : "0",this.RepID,
            this.FormerLastInvoicedAmount,cv_date(this.EarlyBirdDate));
            
            oMySql.exec_sql(Sql);
        }
        public override void Insert()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 //'{0}',\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}',\"{7}\",'{8}','{9}','{10}','{11}','{12}',{13},{14},{15},{16},{17},{18},'{19}','{20}','{21}','{22}','{23}','{24}','{25}',\"{26}\",'{27}','{28}','{29}',{30},\"{31}\",\"{32}\",\"{33}\",\"{34}\",\"{35}\",\"{36}\",\"{37}\",\"{38}\",\"{39}\",'{40}','{41}','{42}','{43}',\"{44}\" ,{45},'{46}','{47}','{48}','{49}','{50}', '{51}', '{52}', {53}
            String Sql = String.Format("Insert Into Customer (CustomerID,Name,Address,City,State,ZipCode,eMail,Chairperson,RepID,PrizeID,PhoneNumber,FaxNumber,HeadPhone,StartDate,EndDate,PickUpDate,ShipDate,SignedDate,DeliveryDate,CashRegister,KITS,Signed,ApplyTax,SalesTax,CollectTax,PriceListID,StartNote,HeadPhoneExt,PhoneNumberExt,PreviousRetail,ParentPickUpDate,SignedNote,EndNote,PickUpNote,ShipNote,DeliveryNote,ParentPickUpNote,County,Page,Grid,IsLetterAprovalDone,ShipOption,CompanyID,PostPay,PayableTo,DatePayable,Checked,CashRegisters,OneDaySale,Assigned,TreasureChest,Rep_ID, FormerLastInvoicedAmount, EarlyBirdDate) Values('{0}',\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}',\"{7}\",'{8}','{9}','{10}','{11}','{12}',{13},{14},{15},{16},{17},{18},'{19}','{20}','{21}','{22}','{23}','{24}','{25}',\"{26}\",'{27}','{28}','{29}',{30},\"{31}\",\"{32}\",\"{33}\",\"{34}\",\"{35}\",\"{36}\",\"{37}\",\"{38}\",\"{39}\",'{40}','{41}','{42}','{43}',\"{44}\", {45},'{46}','{47}','{48}','{49}','{50}', '{51}', '{52}', {53})",
            this.ID,this.Name,this.Address,this.City,this.State,this.ZipCode,this.eMail,this.Chairperson,this.Rep_Ext,this.PrizeID, this.PhoneNumber,
            this.FaxNumber,this.HeadPhone,cv_date(this.StartDate), cv_date(this.EndDate), cv_date(this.PickUpDate), cv_date(this.ShipDate),cv_date(this.SignedDate), cv_date(this.DeliveryDate),
            this.CashRegister ? "1" : "0", this.KITS, this.Signed, this.ApplyTax, this.SalesTax, this.CollectTax, this.PriceListID, this.StartNote, this.HeadPhoneExt, this.PhoneNumberExt, 
            this.PreviousRetail,cv_date(this.ParentPickUpDate),this.SignedNote,this.EndNote, this.PickUpNote,this.ShipNote,this.DeliveryNote,this.ParentPickUpNote,this.County,
            this.Page,this.Grid,this.IsLetterAprovalDone?"1":"0",this.ShipOption,this.CompanyID,this.IsPostPay?"1":"0",this.PayableTo,cv_date(this.DatePayable),
            this.Checked ? "1" : "0", this.CashRegisters,this.IsOneDaySale ? "1" : "0",this.IsAssigned ? "1" : "0",this.IsTreasureChest ? "1" : "0",this.RepID,
            this.FormerLastInvoicedAmount,cv_date(this.EarlyBirdDate));
            Console.WriteLine(Sql);
            oMySql.exec_sql(Sql);

        }
        private String cv_date(DateTime Date)
        {
            DateTime DNull = new DateTime(1900, 01, 01);
            String sStr = null;
            if (Date != DNull)
            {
                sStr = "'" + Date.ToString("yyyy-MM-dd")+ "'";
            }
            else
                sStr = "null";

            return sStr;

        }
        private bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Customer Where CustomerID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public void Recalculate()
        {

            DataView dvOrders = oMySql.GetDataView(String.Format("Select ID, Teacher, Student From Orders Where CompanyID='{0}' And CustomerID='{1}' Order By Teacher, Student", CompanyID, ID), "tmp");
            Order oOrder = new Order(CompanyID);
            int i = 0;
   
            foreach (DataRowView Row in dvOrders)
            {
                Global.SetProgressBar(dvOrders.Count, ++i);
                oOrder.Find((Int32) Row["ID"]);
                oOrder.Save();

            }
            Global.SetProgressBar(0, 0);
            this.HasChanged = true;
            this.RecalculateTeachersAndStudents();
        }
        public void RecalculateTeachersAndStudents()
        {
            
            DataView dvOrders = oMySql.GetDataView(String.Format("SELECT ID FROM Orders  where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "tmp");
            Order oOrder = new Order(CompanyID);
            int i = 0;

            foreach (DataRowView Row in dvOrders)
            {
                Global.SetProgressBar(dvOrders.Count, ++i);
                
                if (oOrder.FindHeader(Convert.ToInt32(Row["ID"].ToString())) && (oOrder.TeacherID == 0 || oOrder.StudentID == 0))
                {
                    oOrder.oTeacher.CustomerID = oOrder.CustomerID;
                    oOrder.TeacherID = oOrder.oTeacher.FindOrCreate(oOrder.Teacher);
                    /*
                    oOrder.oStudent.CustomerID = oOrder.CustomerID;
                    oOrder.oStudent.OrderID = Convert.ToInt32(oOrder.ID);
                    oOrder.StudentID = oOrder.oStudent.FindOrCreate(oOrder.Student, oOrder.TeacherID);
                     */ 
                    oOrder.UpdateTeacherStudent(oOrder.TeacherID, oOrder.StudentID);
                }

            }
            Global.SetProgressBar(0, 0);
            
        }
        public void LoadPayments()
        {
            PaymentsDetail = new _Payments(CompanyID,this.ID);
            PaymentsDetail.Load();
        }
        public DataTable GetOrders()
        {
            return oMySql.GetDataTable(String.Format("Select * from Orders Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Orders");
        }
        public DataTable GetPayments()
        {
            return oMySql.GetDataTable(String.Format("Select Date,Comment as Description,Amount, Type from Payment Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Orders");
        }
        public Double GetTotalInvoicedAmount()
        {
            DataRow rPayment = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Type='I'", this.CompanyID, this.ID), "Tmp");
            
            if (rPayment == null)
            {
                return 0;
            }
            else
            {
                return rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
            }

        }
        public Double GetPaymentsAmount()
        {
                DataRow rPayment = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Type='P'", this.CompanyID, this.ID), "Tmp");
                if (rPayment == null)
                {
                    PaymentsAmount = 0;
                    return 0;
                }
                else
                {
                    PaymentsAmount = rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
                    //return PaymentsAmount < 0 ? PaymentsAmount * -1 : PaymentsAmount;
                    return PaymentsAmount * -1;
                }
            
        }
        public Double GetChargesAmount()
        {
                DataRow rCharges = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Type<>'P' And Type<>'I'", CompanyID, ID), "Tmp");

                /*
                I = Invoice
                F = Finance Charges
                S = Late Orders
                A = Adjusttments
                */
                if (rCharges == null)
                    return 0;
                else
                    return rCharges["Payments"] == DBNull.Value ? 0 : (Double)rCharges["Payments"];
            
        }
        public Double GetFinanceChargesAmount()
        {
            DataRow rCharges = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Type='F'", CompanyID, ID), "Tmp");

            /*
            I = Invoice
            F = Finance Charges  <--
            S = Late Orders
            A = Adjusttments
            */
            if (rCharges == null)
                return 0;
            else
                return rCharges["Payments"] == DBNull.Value ? 0 : (Double)rCharges["Payments"];

        }
        public Int32 GetNoSellers()
        {
            DataRow row = oMySql.GetDataRow("SELECT count(distinct(Student)) as NoSellers FROM Orders Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "' Order By Student ", "Tmp");
            if (row == null)
            {
                
                return 0;
            }
            else
            {
                Int32 No = row["NoSellers"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoSellers"].ToString());
                return No;
            }

        }
        public Int32 GetNoClasses()
        {
            DataRow row = oMySql.GetDataRow("SELECT count(distinct(Teacher)) as NoClasses FROM Orders Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "' Order By Teacher", "Tmp");
            if (row == null)
            {

                return 0;
            }
            else
            {
                Int32 NoClasses = row["NoClasses"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoClasses"].ToString());
                return NoClasses;
            }

        }
        public Int32 GetNoStudents() //New Schema for Campaign Software
        {
            DataRow row = oMySql.GetDataRow("SELECT count(*) as NoStudents FROM Student s Left Join Teacher t on s.TeacherID=t.TeacherID  Where s.CompanyID='" + CompanyID + "' And s.CustomerID='" + ID + "' And t.TeacherID is not null", "Tmp");
            if (row == null)
            {

                return 0;
            }
            else
            {
                Int32 NoStudents = row["NoStudents"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoStudents"].ToString());
                return NoStudents;
            }
        }
        public Int32 GetNoBoxes()
        {
            DataRow row = oMySql.GetDataRow("SELECT sum(ol.BoxesPacked) as NoBoxes FROM OrderByLine ol Left join Orders o On ol.OrderID=o.ID Where ol.CompanyID='"+CompanyID+"' And o.CustomerID='"+ID+"'", "Tmp");
            if (row == null)
            {

                return 0;
            }
            else
            {
                Int32 No = row["NoBoxes"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoBoxes"].ToString());
                return No;
            }

        }
        public Double GetTotalOverageAmount()
        {
            DataRow rCharges = oMySql.GetDataRow(String.Format("Select sum((o.Collected - (o.Retail+o.Tax))) as Disc_Amount From Orders o Where o.CustomerID='{0}' And o.CompanyID='{1}' And  o.Collected - (o.Retail+o.Tax) > 0 Group By o.CustomerID", ID, CompanyID), "Tmp");

            if (rCharges == null)
                return 0;
            else
                return rCharges["Disc_Amount"] == DBNull.Value ? 0 : (Double)rCharges["Disc_Amount"];

        }

        public DataTable GetCurrentTotals()
        {
            return GetTotalDataTable("CustomerID", 0.00, 0.00);
        }
        public DataTable GetCurrentTotalsGPI()
        {
            return GetTotalDataTableGPI("CustomerID", 0.00, 0.00);
        }
        public DataTable GetCurrentTotals(Double UpdatedPercentCustomer, Double UpdatedPercentItem)
        {
            DataTable dtInv;
             
                dtInv = GetTotalDataTable("CustomerID",UpdatedPercentCustomer, UpdatedPercentItem);
                AddedAmount = 0;
                AmountDue = 0;
                ProfitAmount = 0;
                InvoicedAmount = 0;
                TaxAmount = 0;
                Retail = 0;
                NoItems = 0;

                Double AllPositive = this.GetPositiveAmount();
                Double AllNegative = this.GetNegativeAmount();
                //PaymentsAmount = GetPaymentsAmount();
                PaymentsAmount = this.GetNegativeAmount();
   
                ChargesAmount       = GetChargesAmount();
                LastInvoicedAmount  = GetTotalInvoicedAmount();
                NoSellers = GetNoSellers();


                if (dtInv.Rows.Count > 0)
                {
                    NoItems = Convert.ToInt32(dtInv.Rows[0]["Quantity"].ToString());

                    TaxAmount = Math.Round(dtInv.Rows[0]["Tax"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Tax"],2);
                    Retail = Math.Round(dtInv.Rows[0]["Retail"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Retail"],2);
                    InvoicedAmount = Math.Round(dtInv.Rows[0]["Total"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Total"],2);


                    ProfitAmount = Retail - InvoicedAmount; // -TaxAmount;
                    AddedAmount = InvoicedAmount - LastInvoicedAmount;
                    
                    // this.AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount,2);
                    this.AmountDue = Math.Round(AllPositive + AllNegative + AddedAmount, 2);
                    // AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount + GetFinanceChargesAmount(), 2);
                }
                else
                {
                    dtInv = null;
                    
                }
            UpdateCurrentTotals();
            return dtInv;
        }
        public DataTable GetCurrentTotalsGPI(Double UpdatedPercentCustomer, Double UpdatedPercentItem)
        {
            DataTable dtInv;

            dtInv = GetTotalDataTableGPI("CustomerID", UpdatedPercentCustomer, UpdatedPercentItem);
            AddedAmount = 0;
            AmountDue = 0;
            ProfitAmount = 0;
            InvoicedAmount = 0;
            TaxAmount = 0;
            Retail = 0;
            NoItems = 0;

            Double AllPositive = this.GetPositiveAmount();
            Double AllNegative = this.GetNegativeAmount();
            //PaymentsAmount = GetPaymentsAmount();
            PaymentsAmount = this.GetNegativeAmount();

            ChargesAmount = GetChargesAmount();
            LastInvoicedAmount = GetTotalInvoicedAmount();
            NoSellers = GetNoSellers();


            if (dtInv.Rows.Count > 0)
            {
                NoItems = Convert.ToInt32(dtInv.Rows[0]["Quantity"].ToString());

                TaxAmount = Math.Round(dtInv.Rows[0]["Tax"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Tax"], 2);
                Retail = Math.Round(dtInv.Rows[0]["Retail"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Retail"], 2);
                InvoicedAmount = Math.Round(dtInv.Rows[0]["Total"] == DBNull.Value ? 0 : (Double)dtInv.Rows[0]["Total"], 2);


                ProfitAmount = Retail - InvoicedAmount; // -TaxAmount;
                AddedAmount = InvoicedAmount - LastInvoicedAmount;

                // this.AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount,2);
                this.AmountDue = Math.Round(AllPositive + AllNegative + AddedAmount, 2);
                // AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount + GetFinanceChargesAmount(), 2);
            }
            else
            {
                dtInv = null;

            }
            UpdateCurrentTotals();
            return dtInv;
        }
        public DataTable GetCurrentTotalsByBrochure()
        {
            DataTable dt =  GetCurrentTotalsByBrochure(0.00, 0.00);
            return dt;
        }
        public DataTable GetCurrentTotalsByBrochure(Double UpdatedPercentCustomer,Double UpdatedPercentItem )
        {
               DataTable dtInv = new DataTable();
               BrochureByCustomer oBC = new BrochureByCustomer(CompanyID, ID);

                dtInv = GetTotalDataTable("BrochureID",UpdatedPercentCustomer,UpdatedPercentItem);

                this.NoItems = 0;
                this.TaxAmount = 0;
                this.Retail = 0;
                this.InvoicedAmount = 0;
                this.RetailFeeAmount = 0;

                Double AllPositive = this.GetPositiveAmount();
                Double AllNegative = this.GetNegativeAmount();
                //PaymentsAmount = GetPaymentsAmount();
                PaymentsAmount = this.GetNegativeAmount();
                ChargesAmount = GetChargesAmount();
                LastInvoicedAmount = GetTotalInvoicedAmount();
                NoSellers = GetNoSellers();
                if (dtInv == null || dtInv.Rows.Count == 0)
                {
                    //Make sure Quantities are 0
                    this.Brochures.Load(CompanyID,ID);
                    foreach (BrochureByCustomer _oBC in Brochures)
                    {
                        _oBC.Items = 0;
                        _oBC.TaxAmount = 0;
                        _oBC.Retail = 0;
                        _oBC.InvoiceAmount = 0;
                        _oBC.Sellers = 0;
                        _oBC.ProfitAmount = 0;
                        _oBC.RetailFee = 0;
                        _oBC.Save();
                    }
                    this.LastInvoicedAmount = 0;
                    this.Save();

                }
                else
                {
                    foreach (DataRow row in dtInv.Rows)
                    {
                        if (!oBC.Find(row["BrochureID"].ToString()))
                        {
                            MessageBox.Show("Current Invoice didn't find BrochureID:" + row["BrochureID"].ToString());
                            continue;
                        }

                        oBC.Items = Convert.ToInt32(row["Quantity"].ToString());
                        oBC.TaxAmount = row["Tax"] == DBNull.Value ? 0 : (Double)row["Tax"];
                        oBC.Retail = row["Retail"] == DBNull.Value ? 0 : (Double)row["Retail"];
                        if (this.IsGiftAvenue)
                            oBC.InvoiceAmount = oBC.Retail;
                        else
                            oBC.InvoiceAmount = row["Total"] == DBNull.Value ? 0 : (Double)row["Total"];

                        oBC.Sellers = Convert.ToInt32(row["Sellers"].ToString());
                        oBC.ProfitAmount = oBC.Retail - oBC.InvoiceAmount; //Retail - curInvoice - Tax;
                        oBC.RetailFee = (Double)row["RetailFee"];
                        oBC.Save();
                        NoItems += oBC.Items;
                        TaxAmount += oBC.TaxAmount;
                        Retail += oBC.Retail;
                        InvoicedAmount += oBC.InvoiceAmount;
                        RetailFeeAmount += (Double)row["RetailFee"];
                    }
                }
                this.Retail = Math.Round(Retail, 2);
                this.TaxAmount = Math.Round(TaxAmount, 2);
                this.InvoicedAmount = Math.Round(InvoicedAmount, 2);  //Math.Round(InvoicedAmount + RetailFeeAmount, 2);
                this.RetailFeeAmount = Math.Round(RetailFeeAmount, 2);

                this.ProfitAmount = Retail - InvoicedAmount; // -TaxAmount;
                this.AddedAmount = InvoicedAmount - LastInvoicedAmount;
               // this.AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount,2);
                this.AmountDue = Math.Round(AllPositive + AllNegative + AddedAmount, 2);
               // AmountDue = Math.Round(LastInvoicedAmount + AddedAmount - PaymentsAmount + ChargesAmount + GetFinanceChargesAmount(), 2);
                UpdateCurrentTotals();
               
            return dtInv;
        }
        public DataTable GetTotalDataTable(String By, Double UpdatedPercentCustomer, Double UpdatedPercentItem)
        {
            String BySql = "";
            String ByOrder = "";
            switch (By)
            {
                case "CustomerID":
                    BySql = "od.CustomerID";
                    ByOrder = "od.CustomerID";
                    break;
                case "ProductID":
                    BySql = "od.ProductID";
                    ByOrder = "od.ProductID";
                    break;
                case "BrochureID":
                    BySql = "bc.BrochureID";
                    ByOrder = "bc.BrochureID,o.Student";
                    break;
                case "Student":
                    BySql = "o.Student";
                    ByOrder = "o.Teacher, o.Student";
                    break;
                case "Student,ProductID":
                    BySql = "o.Student,od.ProductID";
                    ByOrder = "o.Teacher, o.Student,od.ProductID";
                    break;

            }

            DataTable dtInv = new DataTable();
           // Console.WriteLine(String.Format("Call " + base.InvoiceStoreProcdure + "('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem));
            
            //dtInv = oMySql.GetDataTable(String.Format("Call InvoiceTotals25('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem), "Header");
            dtInv = oMySql.GetDataTable(String.Format("Call "+base.InvoiceStoreProcdure+"('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem), "Header");            

            return dtInv;
        }
        
        public DataTable GetTotalDataTableGPI(String By, Double UpdatedPercentCustomer, Double UpdatedPercentItem)
        {
            String BySql = "";
            String ByOrder = "";
            switch (By)
            {
                case "CustomerID":
                    BySql = "od.CustomerID";
                    ByOrder = "od.CustomerID";
                    break;
                case "ProductID":
                    BySql = "od.ProductID";
                    ByOrder = "od.ProductID";
                    break;
                case "BrochureID":
                    BySql = "bc.BrochureID";
                    ByOrder = "bc.BrochureID,o.Student";
                    break;
                case "Student":
                    BySql = "o.Student";
                    ByOrder = "o.Teacher, o.Student";
                    break;
                case "Student,ProductID":
                    BySql = "o.Student,od.ProductID";
                    ByOrder = "o.Teacher, o.Student,od.ProductID";
                    break;

            }

            DataTable dtInv = new DataTable();
            // Console.WriteLine(String.Format("Call InvoiceTotals18('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem));
            dtInv = oMySql.GetDataTable(String.Format("Call InvoiceTotalsGPI12('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem), "Header");
            //dtInv = oMySql.GetDataTable(String.Format("Call " + base.InvoiceStoreProcdure + "('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, BySql, ByOrder, UpdatedPercentCustomer, UpdatedPercentItem), "Header");


            return dtInv;
        }
        
        public Double GetProfitByBrochure(String BrochureID)
        {
            DataRow row = this.oMySql.GetDataRow("Select * From BrochureByCustomer Where CompanyID='" + CompanyID + "' And  CustomerID='" + ID + "' And  BrochureID='" + BrochureID+"'", "BrochureByCustomer");

            if (row == null)
            {
                return 0.00;
            }
            else
                return (Double) row["ProfitPercent"];
        }
        public Double GetPositiveAmount()
        {

            DataRow rPayment = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Amount>0", this.CompanyID, this.ID), "Tmp");

            if (rPayment == null)
            {
                return 0;
            }
            else
            {
                return rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
            }
        }
        public Double GetNegativeAmount()
        {
            DataRow rPayment = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM Payment P Where CompanyID='{0}' And CustomerID='{1}' And Amount<0", this.CompanyID, this.ID), "Tmp");

            if (rPayment == null)
            {
                return 0;
            }
            else
            {
                return rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
            }
        }

        public Boolean SchoolUseOnly
        {
            get
            {
                DataRow row = oMySql.GetDataRow(String.Format("SELECT SchoolUseOnly From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Tmp");
                if (row == null)
                    return false;
                else
                    return row["SchoolUseOnly"] == DBNull.Value ? false : (Boolean)row["SchoolUseOnly"];
            }
            set
            {
                oMySql.exec_sql(String.Format("Update Customer Set SchoolUseOnly='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value == true ? "1" : "0", CompanyID, ID));
            }

        }
        public Boolean HasChanged
        {
            get 
            {
                DataRow row = oMySql.GetDataRow(String.Format("SELECT CashRegister From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Tmp");
                if (row == null)
                    return false;
                else
                    return row["CashRegister"] == DBNull.Value ? false : (Boolean)row["CashRegister"];
            }
            set 
            {
                oMySql.exec_sql(String.Format("Update Customer Set CashRegister='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value==true?"1":"0",CompanyID, ID));
            }

        }
        public Boolean Printed
        {
            get
            {
                DataRow row = oMySql.GetDataRow(String.Format("SELECT Printed From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Tmp");
                if (row == null)
                    return false;
                else
                    return row["Printed"] == DBNull.Value ? false : (Boolean)row["Printed"];
            }
            set
            {
                oMySql.exec_sql(String.Format("Update Customer Set Printed='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value == true ? "1" : "0", CompanyID, ID));
            }

        }
        public String BOLTraking
        {
         
            set
            {
                oMySql.exec_sql(String.Format("Update Customer Set BOLTracking='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value, CompanyID, ID));
                _BOLTraking = value;
            }
            get
            {
                return _BOLTraking;
            }

        }
        public DateTime DiscrepancyDate
        {
            get
            {
                DataRow row = oMySql.GetDataRow(String.Format("SELECT Max(Date) as Date FROM Disc_Letter Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID),"tmp");
                if (row == null)
                    return Global.DNull;
                else
                {
                    return row["Date"]==DBNull.Value?Global.DNull:(DateTime)row["Date"];
                }
            }
        }
        public void SetGoal(Int32 value)
        {
          oMySql.exec_sql(String.Format("Update Customer Set Goal='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value, CompanyID, ID));
        }
        public void SetEarlyBirdDate(DateTime value)
        {
          //  MessageBox.Show(String.Format("Update Customer Set EarlyBirdDate={0} Where CompanyID='{1}' And CustomerID='{2}'", this.cv_date(value), CompanyID, ID));
            oMySql.exec_sql(String.Format("Update Customer Set EarlyBirdDate={0} Where CompanyID='{1}' And CustomerID='{2}'", this.cv_date(value), CompanyID, ID));
        }
        public void SetFormerLastInvoicedAmount(Double value)
        {
            this.FormerLastInvoicedAmount = value;
            oMySql.exec_sql(String.Format("Update Customer Set FormerLastInvoicedAmount='{0}' Where CompanyID='{1}' And CustomerID='{2}'", value, CompanyID, ID));
        }

        public String GetSchool(String sSchool, String Addres)
        {
            if (sSchool.Contains("RIO"))
            {
///                Console.WriteLine("dEBUGING...");
            }
            
            String City = "";
            String State = "";
            String SchoolCity = Addres.Replace("  ", " ").Replace("'", " ");
            String[] Words = SchoolCity.Split(new char[] { ',', ' ' });
            Addres = Addres.Replace("'", " ");

            if (Words.Length > 1)
            {
                City = Words[0].Trim().Replace(".", "");
                State = Words[1].Trim().Replace(".", "");
                State = Global.getState(State);
            }
            else if (Words.Length == 1)
            {
                City = Words[0].Trim().Replace(".", "");
                State = "";
            }

            return this.GetSchool(sSchool, City, State);
        }
        public String GetSchool(String sSchool, String City, String State)
        {
            sSchool = sSchool.ToUpper().Replace("SCHOOL", "").Replace("ELEMENTRY", "").Replace("ELEMENTARY", "").Replace("MIDDLE", "").Replace("PTA", "").Replace("PRESCHOOL", "").Replace("  ", " ").Replace("  ", " ").Replace(".", "").Replace("'", " ").Trim();
            /*
            sSchool = sSchool.ToUpper();
            sSchool = sSchool.ToUpper().Replace("ELEMENTARY", "");
            sSchool = sSchool.ToUpper().Replace("SCHOOL", "");
             */
            if (sSchool.Contains("ULRICH"))
            {
                //Console.WriteLine("dEBUGING...");
            }
            
            String[] Names = sSchool.Split(' ');
            DataTable dt = new DataTable();
            String Result="";

            if (Names.Length == 1)
            {
                Result = SearchBySpecific(ref dt,  sSchool, City, State);
                return Result;
            }
            
            if (Names.Length == 2)
            {
                Result = SearchBySpecific(ref dt,  sSchool, City, State);
                if (Result == "")
                {
                    Result = SearchByElement(ref dt, Names, City, State);
                    if (Result == "")
                        return sSchool;
                    else
                        return Result;
                }
                else
                    return Result;
            }
            if (Names.Length > 2)
            {
                Result = SearchBySpecific(ref dt, sSchool, City, State);
                if (Result == "")
                {
                    Result = SearchBySpecific(ref dt, Names[0] + " " + Names[1], City, State);
                    if (Result == "")
                    {
                        Result = SearchByElement(ref dt, Names, City, State);
                        if (Result == "")
                            return sSchool;
                        else
                            return Result;
                    }
                    else
                        return Result;
                }else
                    return Result;
            }

            return sSchool;
        }
        String SearchBySpecific(ref DataTable dt, String Key, String City, String State)
        {
            if (Key.Contains("RIO"))
            {
             //  Console.WriteLine("dEBUGING...");
            }
            City = City.ToUpper().Trim().Replace(".", "");
            State= State.ToUpper().Trim().Replace(".", "");
            if (State == "" && City!="")
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And City like '%{2}%'", Key, CompanyID,City));
            else if (City != "" && State != "" )
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And City like '%{2}%' And State='{3}'", Key, CompanyID, City, State));
            if (dt != null && dt.Rows.Count > 0 )
            {
                return dt.Rows[0]["CustomerID"].ToString();
            }

            dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And State='{2}'", Key, CompanyID, State));
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt.Rows[0]["CustomerID"].ToString();
            }
            
            //if (State == "" && City != "")
            dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}'", Key, CompanyID));
            
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt.Rows[0]["CustomerID"].ToString();
            }

            return "";
        }
        String SearchByElement(ref DataTable dt, String[] Names, String City, String State)
        {
            for (int x = 0; x < Names.Length; x++)
            {
              //  if (Names[x]=="BROWN")
               //     Console.WriteLine("dEBUGING...");

                if (Names[x].Trim() != "" && Names[x].Length > 2)
                {
                    if (State == "")
                        dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And City LIKE '%{2}%'", Names[x], CompanyID, City));
                    else if (City != ""  && State != "")
                        dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And City like '%{2}%' And State='{3}'", Names[x], CompanyID, City, State));

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        return dt.Rows[0]["CustomerID"].ToString();
                    }
                    //if (State == "" && City == "")
                    dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}'", Names[x], CompanyID));

                    if (dt != null && dt.Rows.Count == 1)
                    {
                        return dt.Rows[0]["CustomerID"].ToString();
                    }

                    dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,City, State From Customer Where  Name LIKE \"%{0}%\" And CompanyID='{1}' And State='{2}'", Names[x], CompanyID, State));
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        return dt.Rows[0]["CustomerID"].ToString();
                    }

                }
            }

            return "";
        }

        public  bool FindByChairperson(String Name, String Password)
        {
            String FName =  String.Empty;
            String LastName =  String.Empty;
            String Sql = String.Empty;
      
            if (Name == "")
            {   
                return false;
            }

            
            String[] Names = Name.Trim().ToUpper().Split(' ');
            if (Names.Length == 1)
                Sql = String.Format(" Chairperson like '%{0}%'", Names[0]);
            else if (Names.Length == 2)
                Sql = String.Format(" Chairperson like '%{0}%' And Chairperson like '%{1}%'", Names[0],Names[1]);
            else  if (Names.Length == 3)
                Sql = String.Format(" Chairperson like '%{0}%' And Chairperson like '%{1}%' And Chairperson like '%{2}%'", Names[0], Names[1], Names[2]);
            else
                return false;

            DataRow rCustomer = oMySql.GetDataRow(String.Format("Select * From Customer Where CompanyID='{0}' And {1} And ZipCode='{2}'",this.CompanyID,Sql,Password), "Customer");

            if (rCustomer == null)
            {
                return false;
            }

            this.Find(rCustomer["CustomerID"].ToString());
            return true;

        }

        #endregion
        #region Print
        public void PrintSummaryReport(String PrinterName, Boolean isToPrinter)
        {
            if (this.IsGPI)
            {
                PrintSummaryReportGPI(PrinterName, isToPrinter);
                return;
            }
            
            
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds =  new DataSet();
            
            ds.Tables.Add(CreateDetailTableSummaryReport());
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Rep r Left Join Reps rs On r.ID=rs.ID   Where CompanyID='{0}'", CompanyID), "Rep"));


            //ds.WriteXml("dataset120.xml", XmlWriteMode.WriteSchema);

            SummaryReport oRpt = new SummaryReport();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("NoClasses", NoClasses);

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
            oRpt.Dispose();
            oViewReport.Dispose();
            ds.Dispose();
        }
        public void PrintSummaryReportGPI(String PrinterName, Boolean isToPrinter)
        {
            
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds =  new DataSet();
            
            ds.Tables.Add(CreateDetailTableSummaryReport());
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Rep r Left Join Reps rs On r.ID=rs.ID   Where CompanyID='{0}'", CompanyID), "Rep"));


            //ds.WriteXml("dataset120.xml", XmlWriteMode.WriteSchema);

            SummaryReportGPI oRpt = new SummaryReportGPI();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("NoClasses", NoClasses);

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
            oRpt.Dispose();
            oViewReport.Dispose();
            ds.Dispose();
        }
        public void UpdateOrdersByInvoiceCalculation()
        {
            Order oOrder = new Order(this.CompanyID);
            DataTable _Orders = this.GetTotalDataTable("Student", 0, 0);
            foreach (DataRow row in _Orders.Rows)
            {
                if (oOrder.FindHeader((Int32)row["OrderID"]))
                {
                oOrder.NoItems = (Int32)row["Quantity"];
                oOrder.Tax = (Double)row["Tax"];
                oOrder.Retail = (Double) row["Retail"];

                oOrder.Save();
                }
                
            }
        } //Never USed
        
        
        public void PrintClassTeamReport(String PrinterName, Boolean isToPrinter)
        {
            Double DropPercentageCustomer = 0.00;
            Double DropPercentageItem = 0.00;

            if (base.IsGPI)
            {
                PrintClassTeamReportGPI(PrinterName, isToPrinter);
                return;
            }
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds =  new DataSet();

            ds.Tables.Add(oMySql.GetDataTable("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, '' as R_PhoneNumber, Signed, count(distinct o.Teacher) as n_teachers, count(distinct o.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products  From OrderDetail as d LEFT JOIN Orders o On o.ID=d.OrderID LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Reps r ON  c.Rep_ID=r.ID  Where  d.CompanyID='" + CompanyID + "' And  d.CustomerID='" + ID + "' GROUP BY d.CustomerID","Customer"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT DISTINCT o.CustomerID, o.Teacher, o.Student, o.Prize, Nro_Items as Qty, o.Tax,  o.Retail, 'Profit', 'Invoice', o.Collected FROM Orders o LEFT JOIN Customer c ON c.CompanyID=o.CompanyID And c.CustomerID = o.CustomerID  Where  o.CompanyID='XXXXXX' And  o.CustomerID='XXXXXX' GROUP BY o.CustomerID, o.Teacher, o.Student", "Summary"));


            if (Retail < 2500)
            {
                DataTable dtInv = GetCurrentTotalsByBrochure();
                if (dtInv != null)
                {
                    if (LastInvoicedAmount == 0 && Retail < 2500 && Retail > 0)
                    {
                            DropPercentageCustomer = -5.00;

             

                    }
                    DropPercentageItem = -5.00;
                }
                else
                    return;
            }


            ds.Tables.Add(this.GetTotalDataTable("Student", DropPercentageCustomer, DropPercentageItem));
            ds.Tables[2].TableName = "Student";

            

            foreach (DataRow row in ds.Tables[2].Rows)
            {

                DataRow _row = ds.Tables["Summary"].NewRow();

                _row["CustomerID"] = this.ID;
                _row["Teacher"] = row["Teacher"];
                _row["Student"] = row["Student"];
                _row["Prize"] = row["Prize"];
                _row["Qty"] = row["Quantity"];
                _row["Tax"] =  row["Tax"];
                _row["Retail"] =  row["Retail"];
                _row["Collected"] = row["Collected"];
                ds.Tables["Summary"].Rows.Add(_row);
            }
            ds.AcceptChanges();

          //  ds.WriteXml("PrintClassTeamReport_2.xml");
            ClassTeamReport oRpt = new ClassTeamReport();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);

            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName ="\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
              //  oViewReport.cReport.ReportSource = oRpt;
              //  oViewReport.cReport.PrintReport();
                
            }
            else
            {
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
            }
            //oRpt.Close();
            oRpt.Dispose();
            oViewReport.Dispose();
            ds.Dispose();
        }
        public void PrintClassTeamReportGPI(String PrinterName, Boolean isToPrinter)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, '' as R_PhoneNumber, Signed, count(distinct o.Teacher) as n_teachers, count(distinct o.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products  From OrderDetail as d LEFT JOIN Orders o On o.ID=d.OrderID LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Reps r ON  c.Rep_ID=r.ID  Where  d.CompanyID='" + CompanyID + "' And  d.CustomerID='" + ID + "' GROUP BY d.CustomerID", "Customer"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT DISTINCT o.CustomerID, o.Teacher, o.Student, o.Prize, Nro_Items as Qty, o.Tax,  o.Retail, 'Profit', 'Invoice', o.Collected FROM Orders o LEFT JOIN Customer c ON c.CompanyID=o.CompanyID And c.CustomerID = o.CustomerID  Where  o.CompanyID='XXXXXX' And  o.CustomerID='XXXXXX' GROUP BY o.CustomerID, o.Teacher, o.Student", "Summary"));
            ds.Tables.Add(this.GetTotalDataTable("Student", 0, 0));
            ds.Tables[2].TableName = "Student";



            foreach (DataRow row in ds.Tables[2].Rows)
            {

                DataRow _row = ds.Tables["Summary"].NewRow();

                _row["CustomerID"] = this.ID;
                _row["Teacher"] = row["Teacher"];
                _row["Student"] = row["Student"];
                _row["Prize"] = row["Prize"];
                _row["Qty"] = row["Quantity"];
                _row["Tax"] = row["Tax"];
                _row["Retail"] = row["Retail"];
                _row["Collected"] = row["Collected"];
                ds.Tables["Summary"].Rows.Add(_row);
            }
            ds.AcceptChanges();

            ds.WriteXml("PrintClassTeamReport_2.xml");
            ClassTeamReportGPI oRpt = new ClassTeamReportGPI();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);

            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName ="\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
                //  oViewReport.cReport.ReportSource = oRpt;
                //  oViewReport.cReport.PrintReport();

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
            //oRpt.Close();
            oRpt.Dispose();
            oViewReport.Dispose();
            ds.Dispose();
        }
        public void PrintClassTeamReportGPIDetailed(String PrinterName, Boolean isToPrinter)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, '' as R_PhoneNumber, Signed, count(distinct o.Teacher) as n_teachers, count(distinct o.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products  From OrderDetail as d LEFT JOIN Orders o On o.ID=d.OrderID LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Reps r ON  c.Rep_ID=r.ID  Where  d.CompanyID='" + CompanyID + "' And  d.CustomerID='" + ID + "' GROUP BY d.CustomerID", "Customer"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT DISTINCT o.CustomerID, o.Teacher, o.Student, o.Prize, Nro_Items as Qty, o.Tax,  o.Retail, 'Profit', 'Invoice', o.Collected FROM Orders o LEFT JOIN Customer c ON c.CompanyID=o.CompanyID And c.CustomerID = o.CustomerID  Where  o.CompanyID='XXXXXX' And  o.CustomerID='XXXXXX' GROUP BY o.CustomerID, o.Teacher, o.Student", "Summary"));
            ds.Tables.Add(this.GetTotalDataTable("Student", 0, 0));
            ds.Tables[2].TableName = "Student";
            ds.Tables.Add(this.GetTotalDataTable("Student,ProductID", 0, 0));
            ds.Tables[3].TableName = "Detail";



            foreach (DataRow row in ds.Tables[2].Rows)
            {

                DataRow _row = ds.Tables["Summary"].NewRow();

                _row["CustomerID"] = this.ID;
                _row["Teacher"] = row["Teacher"];
                _row["Student"] = row["Student"];
                _row["Prize"] = row["Prize"];
                _row["Qty"] = row["Quantity"];
                _row["Tax"] = row["Tax"];
                _row["Retail"] = row["Retail"];
                _row["Collected"] = row["Collected"];
                ds.Tables["Summary"].Rows.Add(_row);
            }
            ds.AcceptChanges();

            ds.WriteXml("PrintClassTeamReport_4.xml");
            ClassTeamReportGPIDetailed oRpt = new ClassTeamReportGPIDetailed();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);

            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName ="\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
                //  oViewReport.cReport.ReportSource = oRpt;
                //  oViewReport.cReport.PrintReport();

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
            //oRpt.Close();
            oRpt.Dispose();
            oViewReport.Dispose();
            ds.Dispose();
        }
        public void PrintCustomerListing(String CustomerFrom, String CustomerTo, String RepID, Boolean Zero, Boolean Registers)
        {
            ParameterDiscreteValue crParameterDiscreteValue;
            ParameterField crParameterField;
            ParameterFields crParameterFields;
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            String Sql="";
            if (CustomerFrom.Trim().Length > 0)
            {
                Sql = String.Format("CustomerID >= '{0}'", CustomerFrom);
                if (CustomerTo.Trim().Length > 0)
                    Sql += String.Format(" And CustomerID <= '{0}'", CustomerTo);
            }
            if (RepID.Trim().Length > 0)
            {
                if (Sql.Length > 0)
                    Sql += " And ";

                Sql += String.Format("RepID= '{0}'", RepID);

            }
            
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*,concat(concat(concat(concat(concat('(',concat(Substr(PhoneNumber,1,3),')')),' '),Substr(PhoneNumber,4,3)),'-'),Substr(PhoneNumber,8,3)) as Phone, bc.ProfitPercent From Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And bc.BrochureID <> '' {1} Group By c.CustomerID", CompanyID,Sql.Length>0? ("And " + Sql) : ""), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select bc.* From Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And bc.BrochureID <> '' {1}", CompanyID, Sql.Length > 0 ? ("And " + Sql) : ""), "BrochureByCustomer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.CustomerID, c.Name, c.CashRegisters, bc.BrochureID, bc1.ProfitPercent From Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID And bc.BrochureID='STANDARD' Left Join BrochureByCustomer bc1 On c.CompanyID=bc1.CompanyID And c.CustomerID=bc1.CustomerID And bc1.BrochureID='GA' Where c.CompanyID='{0}' {1}", CompanyID, Sql.Length > 0 ? ("And " + Sql) : ""), "BrochureByCustomer"));

           //ds.WriteXml("CustomerListing.xml", XmlWriteMode.WriteSchema);
            /*
            foreach (DataRow row in ds.Tables["Customer"].Rows)
            {
                row["NumberPallets"] = row["ProfitPercent"];
            }
            */
            ds.AcceptChanges();
            
            
            CustomerListing oRpt = new CustomerListing();
            CustomerRegisters oRpt1 = null;
            if (Registers)
            {
                oRpt1 = new CustomerRegisters();
                oRpt1.SetDataSource(ds);
            }

            //Pass Parameters
            //Define the parameter field to pass the parameter values to
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "CompanyName";


            //Create a new instance of discrete value object to set the second 
            //value for the parameter
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = "Signature Fundrasing, Inc. ";
            //Pass the second value to the discrete parameter
            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            //Destroy the current instance of the discrete value
            crParameterDiscreteValue = null;

            //Create an instance of the parameter fields collection, and 
            //pass the discrete parameter with the two discrete values to the
            //collection of parameter fields
            crParameterFields = new ParameterFields();
            crParameterFields.Add(crParameterField);

            oRpt.SetDataSource(ds);


            //Passing Parameters
            oViewReport.cReport.ParameterFieldInfo = crParameterFields;
            oViewReport.cReport.ReportSource = oRpt;
            if (Registers)
            {
                oRpt1.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
                oViewReport.cReport.ReportSource = oRpt1;
            }
            oViewReport.ShowDialog();
        }
        public void PrintDrawingTicketsReport(String Type, String PrintFor,Double NoItems)
        {
            frmViewReport oViewReport = new frmViewReport();
            
            CustomerDrawingTickets oRpt = new CustomerDrawingTickets();


            String Sql = "";
            if (Type == "Units")
            {
                
                if (NoItems > 0)
                    Sql = String.Format(" And Nro_Items >= '{0}'", NoItems);
                Sql += " Order By Nro_Items Desc";
                
            }
            else
            {
                if (NoItems > 0)
                    Sql = String.Format(" And Retail >= '{0}'", NoItems);
                Sql += " Order By Retail Desc";

            }

            DataSet ds = new DataSet();

            //Console.WriteLine("Select * From Customer Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'");
            ds.Tables.Add(oMySql.GetDataTable("Select * From Customer Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'", "Customer"));
           // Console.WriteLine("Select * From Orders Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'" + Sql);
            ds.Tables.Add(oMySql.GetDataTable("Select * From Orders Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'" + Sql, "Orders"));
            
           // ds.WriteXml("dataset61.xml", XmlWriteMode.WriteSchema);

            oRpt.SetDataSource(ds);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            
        }
        public void PrintCustomerClassTeamDate(String PrinterName,String _CustomerID_, Object DFrom, Object DTo, String DateType)
        {

            if (_CustomerID_.Trim() != "")
            {
                if (this.Find(_CustomerID_))
                {
                    this.PrintClassTeamReport(PrinterName,true);
                    this.PrintSummaryReport(PrinterName,true);
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
                
                int Index=0;
                foreach (DataRow row in dt.Rows)
                {
                   // Global.SetProgressBar(dt.Rows.Count, Index);
                        if (DateType == "Delivery")
                        {
                            if (row["ShipDate"] == DBNull.Value)
                            {
                                if (this.Find(row["CustomerID"].ToString()))
                                {

                                    this.PrintClassTeamReport(PrinterName,true);
                                    this.PrintSummaryReport(PrinterName, true);

                                }
                            }
                        }
                        else
                        {
                            if (this.Find(row["CustomerID"].ToString()))
                            {

                                this.PrintClassTeamReport(PrinterName, true);
                                this.PrintSummaryReport(PrinterName, true);

                            }
                        }
                    Index++;
                }
                //Global.SetProgressBar(0, 0);
            
        }
        public void PrintBillOfLading(String PrinterName, Boolean isToPrinter)
        {

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}' Order By ShipDate,Name", CompanyID, ID), "Customer"));
            //ds.WriteXml("dataset122.xml", XmlWriteMode.WriteSchema);
            CustomerBillOfLading oRpt = new CustomerBillOfLading();

            oRpt.SetDataSource(ds);

            
            switch (ShipOption)
            {
                case 1:
                   // if (BOLTraking == "")
                    {
                       // BOLTraking = "BAK-" + Global.FedexNationalNumber.ToString().PadLeft(6, '0');  // Change made in January, 31 2010 for S11
                       // Global.FedexNationalNumber++;
                        BOLTraking = GetFedexFreightNumber();
                    }
                    oRpt.SetParameterValue("BarCode",BOLTraking );
                  //  oRpt.SetParameterValue("Text_1", "FxNL\nGuarantee\nExact");
                  //  oRpt.SetParameterValue("Text_2", "DELIVER @ 10 AM - FXNL GUARANTEED EXACT");
                    oRpt.SetParameterValue("Text_1", "ECONOMY " + (this.oCustomerExtra.isAMDelivery?"\n Guaranteed 10:30am":""))  ;
                    oRpt.SetParameterValue("Text_2", (this.oCustomerExtra.isAMDelivery ? "DELIVERY TIME BEFORE 10:30am" : "DELIVERY TIME BEFORE NOON!"));
                    break;
                case 2:
                   // if (BOLTraking == "")
                    {
                        BOLTraking = GetFedexFreightNumber();
                        //Global.FedexFreightNumber++;
                    }
                    oRpt.SetParameterValue("BarCode", BOLTraking);
                    //oRpt.SetParameterValue("Text_1", "FXF");
                    oRpt.SetParameterValue("Text_1", "PRIORITY " + (this.oCustomerExtra.isAMDelivery ? "\n Guaranteed 10:30am" : ""));
                    oRpt.SetParameterValue("Text_2", (this.oCustomerExtra.isAMDelivery ? "DELIVERY TIME BEFORE 10:30am" : "DELIVERY TIME BEFORE NOON!"));
                    //oRpt.SetParameterValue("Text_2", "DELIVERY TIME BEFORE NOON!");
                    //oRpt.SetParameterValue("Text_2", "");
                    //oRpt.SetParameterValue("Text_1", "");
                    //oRpt.SetParameterValue("Text_2", "DELIVER BETWEEN 8 AM - 12 AM");
                    break;
                default:
                    
                    oRpt.SetParameterValue("Text_1", "");
                    oRpt.SetParameterValue("Text_2", "");
                    oRpt.SetParameterValue("BarCode", "001");
                    break;
            }

            if (isToPrinter)
            {
                //oRpt.PrintOptions.PrinterName = "\\\\srv1\\Plain";
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, false, 0, 0);
                //oViewReport.cReport.ReportSource = oRpt;
                //oViewReport.cReport.PrintReport();
                
                
                switch (ShipOption)
                {
                    case 1:
                        //Global.FedexNationalNumber++;
                        Global.FedexFreightNumber++;
                        break;
                    case 2:
                        Global.FedexFreightNumber++;
                        break;
                    default:
                        break;
                }
                

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }

            oRpt.Dispose();
            ds.Dispose();
            oViewReport.Dispose();
        }
        private String GetFedexFreightNumber()
        {
                Int32 Check=0,FedexNumber=Global.FedexFreightNumber;
                //Math.DivRem(FedexNumber, 7, out Check);
                Check = FedexNumber / 7;
                Check *= 7;
                Check = FedexNumber - Check;

                return FedexNumber.ToString().PadLeft(9,'0')+Check.ToString();
                
        }
        public void PrintCustomerBillOfLading(String PrinterName, String _CustomerID_, Object DFrom, Object DTo, String DateType)
        {

            if (_CustomerID_.Trim() != "")
            {
                if (this.Find(_CustomerID_))
                {
                    this.PrintBillOfLading(PrinterName, true);
                    
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
                  if (this.Find(row["CustomerID"].ToString()))
                    {
                      this.PrintBillOfLading(PrinterName, true);

                    }
               
            }


        }
        public void PrintCustomerDate(Object DFrom, Object DTo, String DateType, Boolean ExcludeLetterAprovalDone, Boolean NotChecked, Boolean Completed, String BrochureID )
        {

            Boolean WithRetail = false;

            if (DateType == "Delivery w/Retail")
            {
                DateType = "Delivery";
                WithRetail = true;
            }

            if (DateType == "Ship w/Retail")
            {
                DateType = "Ship";
                WithRetail = true;
            }

            ParameterDiscreteValue crParameterDiscreteValue;
            ParameterField crParameterField;
            ParameterFields crParameterFields;

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

            frmViewReport oViewReport = new frmViewReport();

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
                String BrochureSql = "";
                if (BrochureID != "")
                {
                        BrochureSql = " And BrochureID='" + BrochureID+"'";

                }

                if (DateType != "") //Thus All
                {
                    if (DateFrom.Trim().Length > 0)
                        Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

                    if (DateTo.Trim().Length > 0)
                        Sql += String.Format(DateSql + " <= '{0}'", DateTo);
                }

                if (DateType == "Start"  && Completed)
                {
                    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Left Join CustomerExtra ce on c.CompanyID=ce.CompanyID And c.CustomerID=ce.CustomerID  Where c.CompanyID='{0}' {1} {2}  And ce.isCompleted=0 Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }
                else if (DateType == "Start" && ExcludeLetterAprovalDone && NotChecked)
                {
                    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} And IsLetterAprovalDone=0 And Checked=0 Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }
                else if (DateType == "Start" && ExcludeLetterAprovalDone)
                {
                    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} And IsLetterAprovalDone=0 Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }
                else if (DateType == "Start" && NotChecked)
                {
                    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2}  And Checked=0 Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }

                else if (DateType == "Ship")
                {
                    if (!this.IsGiftAvenue)
                    {
                        if (WithRetail)
                        {
                            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} And  c.Retail >0 Group by c.CustomerID Order By Date,c.Name ", CompanyID, Sql, BrochureSql), "Customer"));
                            //Console.WriteLine(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} And  c.Retail >0 Group by c.CustomerID Order By Date,c.Name ", CompanyID, Sql));
                            //MessageBox.Show(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} And  c.Retail >0 Order By Date,c.Name", CompanyID, Sql));
                        }
                        else
                            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                    }
                    else
                        ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }
                else if (DateType == "Delivery")
                {
                    if (!this.IsGiftAvenue)
                    {
                        if (WithRetail)
                            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} And ShipDate is null And c.Retail >0 Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                        else
                            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} And ShipDate is null Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                    }else
                        ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                }
                else
                {
                    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} {2} Order By Date,c.Name", CompanyID, Sql, BrochureSql), "Customer"));
                    //Console.WriteLine(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer");
                }

                
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Brochure Where CompanyID='{0}' ", CompanyID), "Brochure"));

            
            //ds.WriteXml("dataset05.xml", XmlWriteMode.WriteSchema);

            
            
            CustomerDate oRpt = new CustomerDate();
            CustomerDateNotes oRpt1 = new CustomerDateNotes();
            CustomerDateShip oRpt2 = new CustomerDateShip();

            oRpt.SetDataSource(ds);
            oRpt1.SetDataSource(ds);
            oRpt2.SetDataSource(ds);

            //Passing Parameters
            
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "CompanyName";

            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = "Signature Fundraising, Inc.";

            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            crParameterDiscreteValue = null;

            crParameterFields = new ParameterFields();
            crParameterFields.Add(crParameterField);

            //Second Parameter
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "From";
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateFrom;
            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            crParameterDiscreteValue = null;
            crParameterFields.Add(crParameterField);

            //Third Parameter
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "To";
            crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTo;
            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            crParameterFields.Add(crParameterField);

            //Fourth Parameter
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "Selection";
            crParameterDiscreteValue = new ParameterDiscreteValue();
            if (WithRetail)
            {
                DateType = DateType + " w/Retail";
            }
            crParameterDiscreteValue.Value = DateType;
            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            crParameterFields.Add(crParameterField);

            //Fifth Parameter
            crParameterField = new ParameterField();
            crParameterField.ParameterFieldName = "Count";
            crParameterDiscreteValue = new ParameterDiscreteValue();
            String Par = "";
            if (WithRetail)
            {
                Par = "Count";
            }
            else
            {
                Par = " ";
            }
            crParameterDiscreteValue.Value = Par;
            crParameterField.CurrentValues.Add(crParameterDiscreteValue);
            crParameterFields.Add(crParameterField);


            oViewReport.cReport.ParameterFieldInfo = crParameterFields; //CrystalSetParameter("CompanyName", "Signature Fundraising, Inc.");
            if (DateType == "Ship w/Retail")
                oViewReport.cReport.ReportSource = oRpt2;
            else if (DateType != "Start")
                oViewReport.cReport.ReportSource = oRpt;
            else
                oViewReport.cReport.ReportSource = oRpt1;
            oViewReport.ShowDialog();
        }
        public void PrintCustomerSignedDate(Object DFrom, Object DTo, String BrochureID, String PrizeID)
        {
           String DateType = "";

            String DateSql = "SignedDate";
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

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            String Sql = "";

            
            
            if (DateFrom.Trim().Length > 0)
                Sql = "And " + String.Format(DateSql + " >= '{0}'", DateFrom);

            if (DateTo.Trim().Length > 0)
                Sql += "And " + String.Format(DateSql + " <= '{0}'", DateTo);

            if (BrochureID.Length > 0)
                Sql += "And " + String.Format("bc.BrochureID='{0}'", BrochureID);
            if (PrizeID.Length > 0)
                Sql += "And " + String.Format("c.PrizeID='{0}'", PrizeID);


            ds.Tables.Add(oMySql.GetDataTable(
                String.Format("Select c.*,bc.*,r.Name From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Left Join Reps r On c.Rep_ID=r.ID Where c.CompanyID='{0}' {1} Group By bc.CustomerID Order By SignedDate,c.Name",
                CompanyID, Sql), "Customer"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Brochure Where CompanyID='{0}' ", CompanyID), "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Prizes Where CompanyID='{0}' ", CompanyID), "Prize"));


           // ds.WriteXml("CustomerSignedDate3.xml", XmlWriteMode.WriteSchema);



            CustomerSignedDate oRpt = new CustomerSignedDate();
            

            oRpt.SetDataSource(ds);
            
            oRpt.SetParameterValue("CompanyName","Signature Fundraising, Inc.");
            oRpt.SetParameterValue("From",DateFrom);
            oRpt.SetParameterValue("To", DateTo);
            oRpt.SetParameterValue("Selection", DateType);
            
            oViewReport.cReport.ReportSource = oRpt;

            
            oViewReport.ShowDialog();
        }
        public void PrintCustomerTax(Object DFrom, Object DTo, String Printer,String State)
        {
          
            String DateSql = "Date";
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

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            String Sql = "";
            String SqlState = "";
            
               if (DateFrom.Trim().Length > 0)
                    Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

                if (DateTo.Trim().Length > 0)
                    Sql += " And "+String.Format(DateSql + " <= '{0}'", DateTo);

                
                if (State != "")
                    SqlState = " And " + String.Format(" State= '{0}'", State);


            if (this.IsGiftAvenue)
                {
                    if ((MessageBox.Show("Recalculate Payments?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        DataTable table = Global.oMySql.GetDataTable(String.Format("Select * from Customer where CompanyID='{0}'", this.CompanyID));
                        foreach (DataRow row in table.Rows)
                        {
                            if (this.Find(row["CustomerID"].ToString()))
                            {
                                this.GetCurrentTotalsByBrochure();
                                this.HasChanged = false;
                            }
                        }
                    }   
                }



            //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID And p.Type='I' Where c.CompanyID='{0}' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID));
            if (this.IsGiftAvenue)
            {
                //" Group By p.CustomerID Order  By c.CustomerID"
                //String _Sql = String.Format("Select c.*, Min(p.Date) as Date, Payments*-1 as SumPayments From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='P' And Payments <> 0 " + (Sql.Length > 0 ? " And " : "") + Sql + " Group By c.CustomerID Order By CustomerID", CompanyID);
                String _Sql = String.Format("SELECT sum(Amount)  as Payments, c.Payments*-1 as SumPayments,   c.* FROM Customer c Left Join Payment p On p.CompanyID=p.CompanyID And p.CustomerID=c.CustomerID Where c.CompanyID='{0}' And Type='P' And c.ApplyTax='Y'" + (Sql.Length > 0 ? " And " : "") + Sql + " Group By p.CustomerID Order By c.CustomerID", CompanyID);
                ds.Tables.Add(oMySql.GetDataTable(_Sql, "Customer"));
                
            }
            else
            {
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID), "Customer"));
                //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));
                //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join TaxByState ts On c.CompanyID=ts.CompanyID And c.State=ts.State Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID), "Customer"));
                //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join TaxByState ts On c.CompanyID=ts.CompanyID And c.State=ts.State Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ",CompanyID));
                //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID));
            }
                //ds.WriteXml("dataset105.xml", XmlWriteMode.WriteSchema);

            if (this.IsGiftAvenue)
            {
                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    row["InvoicedAmount"] = (Double)row["SumPayments"];
                    row["TaxInvoiced"] = (Double)row["SumPayments"] * (row["ApplyTax"].ToString()=="Y"?(Double)row["SalesTax"]/100:0);
                }
                ds.Tables["Customer"].AcceptChanges();
            }

            CustomerTaxReport oRpt = new CustomerTaxReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.SetParameterValue("From", DateFrom);
            oRpt.SetParameterValue("To", DateTo);
            oRpt.SetParameterValue("Selection", "");

            //Passing Parameters
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public void PrintCustomerTaxFood(Object DFrom, Object DTo, String Printer, String State)
        {

            String DateSql = "Date";
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

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            String Sql = "";
            String SqlState = "";

            if (DateFrom.Trim().Length > 0)
                Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

            if (DateTo.Trim().Length > 0)
                Sql += " And " + String.Format(DateSql + " <= '{0}'", DateTo);


            if (State != "")
                SqlState = " And " + String.Format(" State= '{0}'", State);


            if (this.IsGiftAvenue)
            {
                if ((MessageBox.Show("Recalculate Payments?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    DataTable table = Global.oMySql.GetDataTable(String.Format("Select * from Customer where CompanyID='{0}'", this.CompanyID));
                    foreach (DataRow row in table.Rows)
                    {
                        if (this.Find(row["CustomerID"].ToString()))
                        {
                            this.GetCurrentTotalsByBrochure();
                            this.HasChanged = false;
                        }
                    }
                }
            }



            //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID And p.Type='I' Where c.CompanyID='{0}' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID));
            if (this.IsGiftAvenue)
            {
                //" Group By p.CustomerID Order  By c.CustomerID"
                //String _Sql = String.Format("Select c.*, Min(p.Date) as Date, Payments*-1 as SumPayments From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='P' And Payments <> 0 " + (Sql.Length > 0 ? " And " : "") + Sql + " Group By c.CustomerID Order By CustomerID", CompanyID);
                String _Sql = String.Format("SELECT sum(Amount)  as Payments, c.Payments*-1 as SumPayments,   c.* FROM Customer c Left Join Payment p On p.CompanyID=p.CompanyID And p.CustomerID=c.CustomerID Where c.CompanyID='{0}' And Type='P' And c.ApplyTax='Y'" + (Sql.Length > 0 ? " And " : "") + Sql + " Group By p.CustomerID Order By c.CustomerID", CompanyID);
                ds.Tables.Add(oMySql.GetDataTable(_Sql, "Customer"));

            }
            else
            {
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID), "Customer"));
                //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));
                //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join TaxByState ts On c.CompanyID=ts.CompanyID And c.State=ts.State Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID), "Customer"));
                //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join TaxByState ts On c.CompanyID=ts.CompanyID And c.State=ts.State Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ",CompanyID));
                //Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID Where c.CompanyID='{0}' And p.Type='I' And LastInvoiceAmount > 0 " + (SqlState.Length > 0 ? SqlState : "") + " Group By c.CustomerID " + (Sql.Length > 0 ? " Having " : "") + Sql + " Order By CustomerID ", CompanyID));
            }
            //ds.WriteXml("dataset105.xml", XmlWriteMode.WriteSchema);


            if (ds.Tables["Customer"].Rows.Count > 0)
            {
                String SqlCustomer = "";
                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    SqlCustomer += (SqlCustomer != "" ? " Or " : "") + "o.CustomerID='"+row["CustomerID"].ToString()+"'";
                }
                SqlCustomer = "(" + SqlCustomer + ")";

                DataTable dtInv = new DataTable();
           //     Console.WriteLine(String.Format("Call InvoiceTotals_F11_Many('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, SqlCustomer, "o.CustomerID,if(ts.Tax=1.5,1,0)", "o.CustomerID", 0, 0));
                dtInv = oMySql.GetDataTable(String.Format("Call InvoiceTotals_F11_Many('{0}',\"{1}\",'{2}','{3}','{4}','{5}')", CompanyID, SqlCustomer, "o.CustomerID,if(ts.Tax=1.5,1,0)", "o.CustomerID", 0, 0), "Invoice");
                
                ds.Tables.Add(dtInv);
            }

            ds.WriteXml("CustomerTaxReportFood1.xml");

            if (this.IsGiftAvenue)
            {
                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    row["InvoicedAmount"] = (Double)row["SumPayments"];
                    row["TaxInvoiced"] = (Double)row["SumPayments"] * (row["ApplyTax"].ToString() == "Y" ? (Double)row["SalesTax"] / 100 : 0);
                }
                ds.Tables["Customer"].AcceptChanges();
            }

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables ;

            
            

            CustomerTaxReportFood oRpt = new CustomerTaxReportFood();
            oRpt.SetDataSource(ds);

            ////
            ///crConnectionInfo.ServerName = "YOUR SERVER NAME";
            crConnectionInfo.DatabaseName = "SigData";
            crConnectionInfo.UserID = "SigData";
            crConnectionInfo.Password = "SigData009";

            CrTables = oRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            ////



            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.SetParameterValue("From", DateFrom);
            oRpt.SetParameterValue("To", DateTo);
            oRpt.SetParameterValue("Selection", "");

            //Passing Parameters
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        
        public void PrintBalanceDue(Object DFrom, Object DTo, String Printer, String State)
        {


            String DateSql = "p.Date";
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

            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            String Sql = "";


            if (DateFrom.Trim().Length > 0)
                Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

            if (DateTo.Trim().Length > 0)
                Sql += " And " + String.Format(DateSql + " <= '{0}'", DateTo);


            if (State != "")
                Sql += " And " + String.Format(" State= '{0}'", State);

            // Console.WriteLine(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID And p.Type='I' Where c.CompanyID='{0}' And LastInvoiceAmount > 0  And " + Sql + " Group By c.CustomerID Order By CustomerID", CompanyID));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*, Min(p.Date) as Date From Customer c Left Join Payment p On c.CompanyID=p.CompanyID And c.CustomerID=p.CustomerID And p.Type='I' Where c.CompanyID='{0}' And LastInvoiceAmount > 0  And " + Sql + " Group By c.CustomerID Order By CustomerID", CompanyID), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateType + "Date as Date From Customer c  Left Join BrochureByCustomer bc on c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));


            //ds.WriteXml("dataset105.xml", XmlWriteMode.WriteSchema);

            CustomerTaxReport oRpt = new CustomerTaxReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.SetParameterValue("From", DateFrom);
            oRpt.SetParameterValue("To", DateTo);
            oRpt.SetParameterValue("Selection", "");

            //Passing Parameters
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public void PrintCustomerDateByPage(Object DFrom, Object DTo, String DateType, String Printer, Boolean ExcludeLetterAprovalDone, Boolean NotChecked, Boolean Completed)
        {


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

            frmViewReport oViewReport = new frmViewReport();

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
            
            DataTable dt;
            if (DateType == "Start" && ExcludeLetterAprovalDone && NotChecked)
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} And IsLetterAprovalDone=0 And Ckecked=0 Order By Date,Name", CompanyID, Sql), "Tmp");
            else if (DateType == "Start" && Completed)
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer c Left Join CustomerExtra ce on c.CompanyID=ce.CompanyID And c.CustomerID=ce.CustomerID  Where CompanyID='{0}' {1} And ce.isCompleted=0 Order By Date,Name", CompanyID, Sql), "Tmp");
            else if (DateType == "Start" && NotChecked )
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} And Checked=0 Order By Date,Name", CompanyID, Sql), "Tmp");
            else if (DateType == "Start" && ExcludeLetterAprovalDone)
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} And IsLetterAprovalDone=0 Order By Date,Name", CompanyID, Sql), "Tmp");
            else if (DateType == "Delivery")
                dt = oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} And ShipDate is null  Order By Date,Name", CompanyID, Sql), "Tmp");
            else
                 dt=oMySql.GetDataTable(String.Format("Select CustomerID,ShipDate," + DateType + "Date as Date From Customer  Where CompanyID='{0}' {1} Order By Date,Name", CompanyID, Sql), "Tmp");
             int Index = 0;
                foreach (DataRow row in dt.Rows)
                {
                       this.Find(row["CustomerID"].ToString());
                        this.Print(Printer);
                        Index++;
                //        Global.SetProgressBar(dt.Rows.Count, Index++);
                }
              //  Global.SetProgressBar(0, 0);
        }
        public void Print()
        {
            Print("");
        }
        public void Print(String Printer)
        {

            GetCurrentTotalsByBrochure();
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Customer  Where CompanyID='{0}' And CustomerID='{1}' ", CompanyID,ID), "Customer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Brochure Where CompanyID='{0}' ", CompanyID), "Brochure"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select r.*, rs.Name From Rep r Left Join Reps rs On r.ID=rs.ID Where CompanyID='{0}' ", CompanyID), "Rep"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Prizes Where CompanyID='{0}' ", CompanyID), "Prize"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From BrochureByCustomer Where CompanyID='{0}' And CustomerID='{1}' Order By ID", CompanyID, ID), "BrochureByCustomer"));

            //ds.WriteXml("dataset81.xml", XmlWriteMode.WriteSchema);
            Int32 Sellers = NoSellers;

            CustomerDateByPage oRpt = new CustomerDateByPage();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("NoSellers", Sellers);

            //Passing Parameters
            if (Printer != "")
                oRpt.PrintOptions.PrinterName = Printer;

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.PrintToPrinter(1, false, 1, 100);
            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();
            oViewReport.Dispose();
            oRpt.Dispose();
            ds.Dispose();

        }
        public void PrintCustomerCheckIn(String Printer)
        {

            GetCurrentTotalsByBrochure();
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Customer  Where CompanyID='{0}' And CustomerID='{1}' ", CompanyID, ID), "Customer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Brochure Where CompanyID='{0}' ", CompanyID), "Brochure"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select r.*, rs.Name From Rep r Left Join Reps rs On r.ID=rs.ID Where CompanyID='{0}' ", CompanyID), "Rep"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From Prizes Where CompanyID='{0}' ", CompanyID), "Prize"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * From BrochureByCustomer Where CompanyID='{0}' And CustomerID='{1}' Order By ID", CompanyID, ID), "BrochureByCustomer"));

            //ds.WriteXml("dataset81.xml", XmlWriteMode.WriteSchema);
            Int32 Sellers = NoSellers;

            CustomerDateCheckIn oRpt = new CustomerDateCheckIn();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("NoSellers", Sellers);

            //Passing Parameters
            if (Printer != "")
                oRpt.PrintOptions.PrinterName = Printer;

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            Brochure oBrochure = new Brochure(this.CompanyID);
            oBrochure.Find(BrochureID);
            oRpt.SetParameterValue("Brochure_1",oBrochure.Description.ToString());
            oBrochure.Find(BrochureID_2);
            oRpt.SetParameterValue("Brochure_2",oBrochure.Description.ToString());
            oBrochure.Find(BrochureID_3);
            oRpt.SetParameterValue("Brochure_3", oBrochure.Description.ToString());

            oRpt.PrintToPrinter(1, false, 1, 100);
            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();
            oViewReport.Dispose();
            oRpt.Dispose();
            ds.Dispose();

        }
        public void PrintEndLabels()
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            CustomerEndLabels oRpt = new CustomerEndLabels();
            //ds.WriteXml("dataset74.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("BarCode",  "*" + ID + "*" );

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();
            //oViewReport.cReport.PrintReport();
        }
        public void PrintBrochureBox()
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            Rep oRep = new Rep(this.CompanyID);
            oRep.Find(this.RepID);

            CustomerBrochureBoxLabels oRpt = new CustomerBrochureBoxLabels();
            //ds.WriteXml("dataset74.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("RepName",oRep.Name );

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();
            //oViewReport.cReport.PrintReport();
        }
        public void PrintCoversheet()
        {

            DataSet ds = new DataSet();

            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Brochure Where CompanyID='{0}'", CompanyID), "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CustomerID='{0}' And CompanyID='{1}'", ID, CompanyID), "Customer")); 
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Prizes Where CompanyID='{0}'", CompanyID), "Prize"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Rep r Left Join Reps rs On rs.ID=r.ID Where CompanyID='{0}'", CompanyID), "Rep"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From BrochureByCustomer Where CustomerID='{0}' And CompanyID='{1}' Order By ID", ID, CompanyID), "BrochureByCustomer"));
            DataTable dt = oMySql.GetDataTable(String.Format("Select * From Coversheet Where CustomerID='{0}' And CompanyID='{1}'", ID, CompanyID), "Coversheet");
            ds.Tables.Add(dt);

            
            String Notes = "";
            String IsReady = "";
            Int32 NoLetters = 0;
            String DisplayKit = "";
            foreach (DataRow row in dt.Rows)
            {
                Notes = row["Notes"].ToString();
                IsReady = row["IsReady"].ToString();
                NoLetters = (Int32) row["NoLetters"];
                DisplayKit = row["DisplayKit"].ToString()=="1"?"YES":"NO";
            }


            frmViewReport oViewReport = new frmViewReport();

            CustomerCoversheet oRpt = new CustomerCoversheet();
            ds.WriteXml("PrintCoversheet1.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.SetParameterValue("Notes", Notes);
            oRpt.SetParameterValue("IsReady", IsReady);
            oRpt.SetParameterValue("DisplayKit", DisplayKit);
            oRpt.SetParameterValue("TeacherGift", "");
            
//            oViewReport.cReport.ReportSource = oRpt;
//            oViewReport.cReport.PrintReport();

//            oViewReport.ShowDialog();
            
            //oRpt.PrintOptions.PrinterName = PrinterName;
            oRpt.PrintToPrinter(1, false, 0, 0);
            //UpdateInventory((Int32)(NoLetters*1.15));
            
        }
        public void PrintDiscrepancyList()
        {
           // frmViewReport oViewReport = new frmViewReport();
            //oViewReport.SetReport((int)Report.DiscrepancyList, CompanyID, ID, true);
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds1 = GetDiscrepancyDataSet();
            if (ds1 == null)
                MessageBox.Show("Please check the database");
            DiscrepancyList oRpt = new DiscrepancyList();
            oRpt.SetDataSource(ds1);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            
       
            
        }
        public void PrintAddedAmountListing()
        {
            // frmViewReport oViewReport = new frmViewReport();
            //oViewReport.SetReport((int)Report.DiscrepancyList, CompanyID, ID, true);
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.*,concat(concat(concat(concat(concat('(',concat(Substr(PhoneNumber,1,3),')')),' '),Substr(PhoneNumber,4,3)),'-'),Substr(PhoneNumber,8,3)) as Phone, bc.ProfitPercent From Customer c Left Join BrochureByCustomer bc On c.CompanyID=bc.CompanyID And c.CustomerID=bc.CustomerID Where c.CompanyID='{0}' And c.AddedAmount > 0 Group By c.CustomerID", CompanyID), "Customer"));
            
            
            CustomerAddedAmount oRpt = new CustomerAddedAmount();
           // ds.WriteXml("CustomerAddedAmountListing.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

        }
        public void PrintDiscrepancyLetters()
        {
            PrintDiscrepancyLetters(0);
            
        }
        public Boolean PrintStatement(String PrinterName, PrinterDevice Device)
        {
            frmViewReport oViewReport = new frmViewReport();
            //DataSet ds1 = oMySql.GetCustomerStatement(CompanyID, ID);

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Payment  Where CompanyID='{0}' And CustomerID='{1}' Order by Date", CompanyID, ID), "Statement"));
            
            
            Statement oRpt = new Statement();
            //ds1.WriteXml("dataset26.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);
           
            oRpt.SetParameterValue("CompanyName", base.Name);


            if (Device == PrinterDevice.Printer)
            {
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
            }
            else if (Device == PrinterDevice.eMail)
            {

                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\" + this.ID + ".pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.ID);

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = base.ID + " - Statement " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() + "(" + this.ID + " - " + this.Name + ")";


                if (PrinterName != "")
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + PrinterName + ">"; //this.eMail + ">";
                else if (this.isEmail(this.eMail) && File.Exists(oPDF.FileName))
                {
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + this.eMail + ">";
                    if (this.isEmail(this.oCustomerExtra.eMail))
                    {
                        oSmtp.To = "\"" + this.Chairperson + "\" <" + this.oCustomerExtra.eMail + ">";
                    }
                    oSmtp.BCC = "\"" + "Scott Elsbree" + "\" <" + "scotte@sigfund.com" + ">"; //this.eMail + ">";
                }
                else
                {
                    oSmtp.To = "\"" + "Scott Elsbree" + "\" <" + "scotte@sigfund.com" + ">"; //this.eMail + ">";
                    
                }

                oSmtp.From = "\"Signature Fundraising Customer Service\" <info@signaturefundraising.com>";

                String strTitle = "\n\r";
                      


                strTitle += "Thank you for choosing Signature Fundraising.  As of today we have not received complete payment for your account.\n\r";
                strTitle += "We have attached a copy of your most recent statement showing the balance due.  Please remember that  according to\n\r";
                strTitle += "the agreement we have with your organization interest will accrue on any unpaid balance after 20 days of delivery.\n\r";
                strTitle += "We have also attached a check by fax form that will enable you to send payment to us right away.  If you have any \n\r";
                strTitle += "questions, you may reply to this e-mail or call us at 1-800-645-3863.\n\r";

                strTitle += "\n\nThank you.\n\r";
                strTitle += "Signature Fundraising\n\r";


                //String strTitle = "This statement amount due is for a total of :\n\r  $ " + this.StatementAmountDue.ToString() + " \n\r" ;
                //This invoice is for a total of ::invoice amount::, of which ::payment amount:: has already been received.
                if (PrinterName == "" && !this.isEmail(this.eMail))
                    strTitle += " WRONG EMAIL ADDRESS: " + this.eMail + " of " + this.ID + " : " + this.Name ;

                if (PrinterName == "" && !File.Exists(oPDF.FileName))
                    strTitle += " NO PDF FILE : " + this.eMail + " of " + this.ID + " : " + this.Name;
                else
                    oSmtp.Attachment = oPDF.FileName;

                oSmtp.Body = strTitle;
                oSmtp.Attachment = "Check by Fax Form.pdf";
               // oSmtp.Credentials =  new System.Net.NetworkCredential("info@signaturefundraising.com", "Sigfund007");
               // oSmtp.BCC = "scotte@sigfund.com";
                
                if (!oSmtp.Send())
                {
                    Console.WriteLine(oSmtp.Error);
                    oRpt.Dispose();
                    oViewReport.Dispose();
                    return false;
                }
                //while (File.GetAttributes(oPDF.FileName) == FileAttributes.ReadOnly) ;
                /*
                ReadFile:
                try
                {
                    if (File.Exists(oPDF.FileName))
                        File.Delete(oPDF.FileName);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto ReadFile;
                }
                */
               
            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }

            oRpt.Dispose();
            oViewReport.Dispose();
            
            return true;
        }
        public void PrintEmptyFieldsReport()
        {
            DataTable dt = oMySql.GetDataTable(String.Format("Select CustomerID,Name,'Fields' From Customer Where CompanyID='{0}'", CompanyID), "Customer");

            foreach (DataRow row in dt.Rows)
            {
                Find(row["CustomerID"].ToString());
                
                String Fields = String.Empty;

                row["Fields"] = String.Empty;
                if (this.Name.Trim() == String.Empty)
                    Fields = "Name/";
                if (this.Address.Trim() == String.Empty)
                    Fields = "Address/";
                if (this.City.Trim() == String.Empty)
                    Fields += "City/";
                if (this.State.Trim() == String.Empty)
                    Fields += "State/";
                if (this.ZipCode.Trim() == String.Empty)
                    Fields = "ZipCode/";
                if (this.County.Trim() == String.Empty)
                    Fields += "County/";
                if (this.Chairperson.Trim() == String.Empty)
                    Fields += "Chairperson/";
                if (this.HeadPhone.Trim() == String.Empty)
                    Fields += "HeadPhone/";
                if (this.PhoneNumber.Trim() == String.Empty)
                    Fields += "HeadPhone/";
                if (this.FaxNumber.Trim() == String.Empty)
                    Fields += "FaxNumber/";
                if (this.RepID == 0)
                    Fields += "RepID/";
                if (this.PrizeID.Trim() == String.Empty)
                    Fields += "PrizeID/";
                if (this.Signed == 0)
                    Fields += "Signed/";
                if (this.SignedDate == Global.DNull)
                    Fields += "SignedDate/";
                if (this.StartDate == Global.DNull)
                    Fields += "StartDate/";
                if (this.EndDate == Global.DNull)
                    Fields += "EndDate/";
                if (this.PickUpDate == Global.DNull)
                    Fields += "PickUpDate/";
              //  if (this.ParentPickUpDate == Global.DNull)
              //      Fields += "ParentPickUpDate/";
                if (this.DeliveryDate == Global.DNull)
                    Fields += "DeliveryDate/";
                if (this.PreviousRetail == 0)
                    Fields += "PreviousRetail/";

                //Check Brochures

                Brochures.Load(CompanyID,ID);
                foreach (BrochureByCustomer oBC in Brochures)
                {
                    if (oBC.Code == 0)
                        Fields += oBC.BrochureID+"-CODE%/";
                    if (oBC.ProfitPercent <= 0)
                        Fields += oBC.BrochureID + "-Profit%/";

                }

                if (Fields != String.Empty)
                    row["Fields"] = Fields;
                else
                    row.Delete();
                
            }
            dt.AcceptChanges();

            frmViewReport oViewReport = new frmViewReport();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            //ds.WriteXmlSchema("DataSet 00002.xml");
            CustomerEmptyFields oRpt = new CustomerEmptyFields();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            ds.Dispose();
            oRpt.Dispose();

        }
        public void PrintDiscrepancyLetters(Int32 OrderID)
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds1 = GetDiscrepancyDataSet(OrderID);
            if (ds1 == null)
                MessageBox.Show("Please check the database");
            DiscrepancyLetters oRpt = new DiscrepancyLetters();
            oRpt.SetDataSource(ds1);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            if (OrderID == 0)
            {
                //Create Shortage
                Shortage oShortage = new Shortage(this.CompanyID);
                //oShortage.oOrder = oOrder;
                //oShortage.OrderID = 0;
                if (!oShortage.FindByCustomer(this.ID, "Y"))
                {
                    oShortage.oCustomer = this;
                    oShortage.CustomerID = this.ID;
                    oShortage.SchoolName = this.Name;
                    oShortage.DayPhone = this.PhoneNumber;
                    oShortage.EvePhone = this.HeadPhone;
                    oShortage.TeacherName = "";
                    oShortage.Attention = this.Chairperson;
                    oShortage.StudentName = "";
                    oShortage.Address = this.Address;
                    oShortage.City = this.City;
                    oShortage.ZipCode = this.ZipCode;
                    oShortage.State = this.State;
                    oShortage.Type = "Y";
                    oShortage.Detail = "Discrepancy Report" + "\n\r" + "\n\r";
                    oShortage.eMail = this.eMail;
                    oShortage.Save();
                    oShortage.Print(false);

                    if (this.eMail.Trim() != "")
                    {
                        /*
                        PDF oPDF = new PDF();
                        oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", "Discrepancy Report");

                        Smtp oSmtp = new Smtp();
                        oSmtp.Subject = "Discrepancy Letter " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                        oSmtp.To = "\"" + this.Chairperson + "\" <" + this.eMail + ">";
                        oSmtp.From = "\"Signature Fundraising Customer Service\" <support@sigfund.com>";

                        String strTitle = "Discrepancy Report\n\r";

                        oSmtp.Body = strTitle;
                        oSmtp.Attachment = Application.StartupPath + "\\Discrepancy Report.pdf";
                        oSmtp.Send();
                        */
                    }

                   
                }
            }

        }
        public void PrintPrizeSummary()
        {

            DataSet ds = new DataSet();

            
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT distinct(Prize), pr.Description as ProductDescription, p.PrizeID, p.Description  as PrizeDescription, count(*) FROM Orders o Left Join PrizeDetail pd On o.Prize=pd.ProductID And o.CompanyID=pd.CompanyID Left Join Prizes p On pd.PrizeID=p.PrizeID And pd.CompanyID=p.CompanyID Left Join Product pr On pd.ProductID=pr.ProductID And pd.CompanyID=p.CompanyID Where o.CompanyID='{0}' And CustomerID='{1}' Group By p.PrizeID",CompanyID,ID),"PrizeTotal"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT distinct(Prize), pr.Description as ProductDescription, p.PrizeID, p.Description  as PrizeDescription, count(*) as Total, count(*) as Summary FROM Orders o Left Join PrizeDetail pd On o.Prize=pd.ProductID And o.CompanyID=pd.CompanyID Left Join Prizes p On pd.PrizeID=p.PrizeID And pd.CompanyID=p.CompanyID Left Join Product pr On pd.ProductID=pr.ProductID And pd.CompanyID=pr.CompanyID Where o.CompanyID='{0}' And CustomerID='{1}' Group By o.Prize  Order By Prize Desc", CompanyID, ID), "PrizeSummary"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CustomerID='{0}' And CompanyID='{1}'", ID, CompanyID), "Customer"));

            
            foreach (DataRow row in ds.Tables["PrizeTotal"].Rows)
            {
                if (row["Prize"].ToString() == "")
                    continue;
                //MessageBox.Show(row["PrizeDescription"].ToString());
                Int32 TotalApplied = 0;
                foreach (DataRow _row in ds.Tables["PrizeSummary"].Rows)
                {
                    Int32 Quantity =  Convert.ToInt32(_row["Summary"].ToString()) + TotalApplied;
                    _row["Summary"] = (object)Quantity;
                    TotalApplied = Convert.ToInt32(_row["Summary"].ToString());
                }
            }

            //ds.WriteXml("PrizeSummary.xml");
          
            
            frmViewReport oViewReport = new frmViewReport();

            PrizeSummaryReport oRpt = new PrizeSummaryReport();
            oRpt.SetDataSource(ds);

            
            //oRpt.PrintToPrinter(1, false, 0, 0);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
            

        }
        public void PrintCheckedCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.* From Customer c Left Join CustomerExtra ce On c.CompanyID=ce.CompanyID And c.CustomerID=ce.CustomerID Where c.CompanyID='{0}' And ce.isChecked = 0 Order By Name", CompanyID), "Customer"));

            //ds.WriteXmlSchema("PrintCheckedCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingChecked oRpt = new CustomerListingChecked(); 
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            

             oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintAssignedCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And (cg.KitAssigned='0' OR cg.KitAssigned is null) Order By c.DeliveryDate, c.Name", CompanyID), "Customer"));

           // ds.WriteXmlSchema("PrintAssignedCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingAssigned oRpt = new CustomerListingAssigned();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintBlueDogCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerExtra cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And cg.isBlueDog=1 And cg.isBlueDogContract  = 0 Order By  c.Name", CompanyID), "Customer"));

           // ds.WriteXmlSchema("PrintBlueDogCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingBlueDog oRpt = new CustomerListingBlueDog();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintKKCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerExtra cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And cg.isKK='1'  Order By  c.ShipDate", CompanyID), "Customer"));

            //ds.WriteXmlSchema("PrintKKCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingKK oRpt = new CustomerListingKK();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintListingGroupedCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT *  FROM Customer c Left Join CustomerExtra ce On c.CompanyID=ce.CompanyID And c.CustomerID=ce.CustomerID Where c.CompanyID='{0}' And ce.isGrouped=1 Order By c.StartDate, c.Name", CompanyID), "Customer"));

            //ds.WriteXmlSchema("PrintGroupedCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingGrouped oRpt = new CustomerListingGrouped();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", base.Name);


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintPromoShippedCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And (cg.PromoShipped='0' OR cg.PromoShipped is null) Order By c.StartDate, c.Name", CompanyID), "Customer"));

            //ds.WriteXmlSchema("PrintPromoShippedCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            
            CustomerListingPromoShipped oRpt = new CustomerListingPromoShipped();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintEnrollmentForm()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerExtra cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Left Join BrochureByCustomer bc On c.CustomerID=bc.CustomerID And c.CompanyID=bc.CompanyID And bc.BrochureID='CC'  Where c.CompanyID='{0}' And (cg.EnrollForm='0' And cg.EnrollForm is not null) And bc.BrochureID is not null Order By c.DeliveryDate", CompanyID), "Customer"));

         //   ds.WriteXmlSchema("PrintEnrollmentForm.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerEnrollmentForm oRpt = new CustomerEnrollmentForm();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintProductOrderedCustomers()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT * FROM Customer c Left Join CustomerGA cg On c.CompanyID=cg.CompanyID  And c.CustomerID=cg.CustomerID  Where c.CompanyID='{0}' And (ProductOrdered='0' OR ProductOrdered is null) Order By c.StartDate, c.Name", CompanyID), "Customer"));

        //    ds.WriteXmlSchema("PrintProductOrderedCustomers.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerListingProductOrdered oRpt = new CustomerListingProductOrdered();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.ShowDialog();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintFrankReport()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT CustomerID, Nro_Items, Student, '' as  Room, Teacher, '' as Grade, Retail   FROM Orders O Where CustomerID='{0}' And CompanyID='{1}' Order By Retail DESC", ID, CompanyID), "Customer"));

           // ds.WriteXmlSchema("PrintFrankReport.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerFrankReport oRpt = new CustomerFrankReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.Show();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public void PrintFrankReportByClass()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT distinct(Teacher), CustomerID, sum(Nro_Items),  '' as  Room, Teacher, '' as Grade, sum(Retail) as Amount , count(*) as Participants   FROM Orders O Where CustomerID='{0}' And CompanyID='{1}' Group By Teacher Order By sum(Retail) Desc", ID, CompanyID), "Customer"));

            //ds.WriteXmlSchema("PrintFrankReportByClass.xml");

            frmViewReport oViewReport = new frmViewReport();

            CustomerFrankByClassReport oRpt = new CustomerFrankByClassReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");


            oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.cReport.PrintReport();

            oViewReport.Show();
            //oRpt.PrintOptions.PrinterName = PrinterName;
            //oRpt.PrintToPrinter(1, false, 0, 0);
        }
        public bool PrintInventoryBox(PrinterDevice Device, String eMail)
        {
            
            DataSet ds = new DataSet();

            DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID,this.ID), "Customer");
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT p.ProductID , p.Description, pc.CProductID as KitID, pc.ProductID as pcProductID, od.Quantity*pc.Quantity as TotalQuantity, od.Quantity as PQuantity, pc.Quantity ,p.Price  FROM OrderDetail od Left Join ProductCompound pc On od.CompanyID=pc.CompanyID And od.ProductID=pc.CProductID  Left Join Product p On p.CompanyID=pc.CompanyID And p.ProductID=pc.ProductID Where od.CompanyID='{0}' And od.CustomerID='{1}' And CProductID is not Null", this.CompanyID, ID), "Detail");

            String ProfitField = this.ProfitPercent.ToString().PadLeft(2, '0');
            ProfitField = "p.Profit_" + ProfitField.Substring(ProfitField.Length - 2, 2); 
                        
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT p.ProductID, p.Description, pc.CProductID as KitiD, pc.ProductID as pcProductID, sum(od.Quantity*pc.Quantity) as PQuantity, sum(od.Quantity) as TotalQuantity, p.BoxCount as Quantity, p.Price, p.Code, "+ProfitField+" as  Profit_10  FROM OrderDetail od Left Join Orders o On o.ID=od.OrderID Left Join ProductCompound pc On od.CompanyID=pc.CompanyID And od.ProductID=pc.CProductID  Left Join Product p On p.CompanyID=pc.CompanyID And p.ProductID=pc.ProductID Where od.CustomerID='{1}' And CProductID is not Null Group By ProductID Order By p.CODE, p.Description", this.CompanyID, ID), "Detail");

            /*
            foreach (DataRow row in dtStatements.Rows)
            {
                row["Quantity"] = row["Code"];
            }
            */
            dtStatements.AcceptChanges();

            ds.Tables.Add(dtCustomers);
            ds.Tables.Add(dtStatements);

   
            frmViewReport oViewReport = new frmViewReport();
            //ds.WriteXml("InventoryBox.xml", XmlWriteMode.WriteSchema);

            GAInventoryBox oRpt = new GAInventoryBox();

            oRpt.SetDataSource(ds);
            //oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            if (Device == PrinterDevice.Printer)
                oRpt.PrintToPrinter(1, false, 0, 0);
            else if (Device == PrinterDevice.Screen)
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
            else if (Device == PrinterDevice.eMail)
            {
                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\InventoryBox.pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", "InventoryBox");

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = "Inventory Box " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                oSmtp.To = "\"" + this.Chairperson + "\" <" + eMail + ">";
                oSmtp.From = "\"Signature Fundraising Customer Service\" <support@sigfund.com>";

                String strTitle = "Inventory Box  Report\n\r";

                oSmtp.Body = strTitle;
                oSmtp.Attachment = oPDF.FileName;
                if (!oSmtp.Send())
                    return false;
            }
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
            return true;
        }
        public bool PrintFinalBillTally(PrinterDevice Device, String eMail)
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();

            DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer");
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT p.ProductID , p.Description, pc.CProductID as KitID, pc.ProductID as pcProductID, od.Quantity*pc.Quantity as TotalQuantity, od.Quantity as PQuantity, pc.Quantity ,p.Price, sum(p.Price*od.Quantity*pc.Quantity) as SubTotal FROM OrderDetail od Left Join ProductCompound pc On od.CompanyID=pc.CompanyID And od.ProductID=pc.CProductID  Left Join Product p On p.CompanyID=pc.CompanyID And p.ProductID=pc.ProductID Where od.CompanyID='{0}' And od.CustomerID='{1}' And CProductID is not Null Group By KitID", this.CompanyID, ID), "Detail");
            //DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT od.ProductID , p.Description, od.ProductID as KitID, pc.ProductID as pcProductID, od.Quantity*pc.Quantity as TotalQuantity, od.Quantity as PQuantity, pc.Quantity  as Quantity, p.Price, sum(p.Price*od.Quantity) as SubTotal FROM OrderDetail od Left Join ProductCompound pc On od.CompanyID=pc.CompanyID And od.ProductID=pc.CProductID  Left Join Product p On p.CompanyID=od.CompanyID And p.ProductID=od.ProductID Where od.CompanyID='{0}' And od.CustomerID='{1}' and p.NoShow='0'  Group By od.ProductID", this.CompanyID, ID), "Detail");
            DataTable dtStatements = oMySql.GetDataTable(String.Format("SELECT od.ProductID , p.Description, od.ProductID as KitID,  od.Quantity as PQuantity,  p.Price, p.BoxCount as Quantity, p.Price*od.Quantity as SubTotal FROM OrderDetail od Left Join Orders o On o.ID=od.OrderID Left Join Product p On p.CompanyID=od.CompanyID And p.ProductID=od.ProductID Where  o.Teacher <> 'RE-ORDER' and od.CompanyID='{0}' And od.CompanyID='{0}' And od.CustomerID='{1}' and p.NoShow='0'", this.CompanyID, ID), "Detail");
            ds.Tables.Add(dtCustomers);
            ds.Tables.Add(dtStatements);

           // frmViewReport oViewReport = new frmViewReport();
           // ds.WriteXml("FinalBillTally.xml", XmlWriteMode.WriteSchema);

            FinalBillTally oRpt = new FinalBillTally();
            Double SubTotal = 0;
            foreach (DataRow row in dtStatements.Rows)
            {
                SubTotal += (Double)row["SubTotal"];
            }


            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("SubTotal", SubTotal);
            if (Device == PrinterDevice.Printer)
                oRpt.PrintToPrinter(1, false, 0, 0);
            else if (Device == PrinterDevice.Screen)
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
            else if (Device == PrinterDevice.eMail)
            {
                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\FinalBillTally.pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", "FinalBillTally");

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = "FinalBillTally " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                oSmtp.To = "\"" + this.Chairperson + "\" <" + eMail + ">";
                oSmtp.From = "\"Signature Fundraising Customer Service\" <support@sigfund.com>";

                String strTitle = "FinalBillTally Report\n\r";

                oSmtp.Body = strTitle;
                oSmtp.Attachment = oPDF.FileName;
                if (!oSmtp.Send())
                    return false;

            }

            ds.Dispose();
            oRpt.Dispose();
            return true;
        }
        public void PrintInventoryByDate(String PrintName, String _CustomerID_, Object DFrom, Object DTo, String DateType, String InvoiceNote, Boolean IsPreInvoice)
        {

            if (_CustomerID_.Trim() != "")
            {
                if (this.Find(_CustomerID_))
                {
                    //this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                    this.Print();
                    this.PrintFinalBillTally(PrinterDevice.Printer,"");
                    this.PrintInventoryBox(PrinterDevice.Printer,"");
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
                            this.Print();
                      //      this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                            this.PrintFinalBillTally(PrinterDevice.Printer,"");
                            this.PrintInventoryBox(PrinterDevice.Printer,"");
                            

                        }
                    }
                }
                else
                {
                    if (this.Find(row["CustomerID"].ToString()))
                    {
                        this.Print();
                       // this.Print(PrintTo.Printer, PrintName, InvoiceNote, IsPreInvoice);
                        this.PrintFinalBillTally(PrinterDevice.Printer,"");
                        this.PrintInventoryBox(PrinterDevice.Printer,"");
                    }
                }

            }


        }
        public void PrintPalletsLabel()
        {
            
            for (int x = 0; x < this.NumberPallets; x++)
            {
                    String strPallet = String.Format("{0} OF {1} PALLETS", x + 1, this.NumberPallets);

                    Pallet oPallet = new Pallet();
                    oPallet.Copies = 2;

                    Pallet.Area Area1 = new Pallet.Area();

                    Area1 = new Pallet.Area();
                    Area1.Text = this.ID + (this.IsCombo?" - (Combo)":"");
                    Area1.MaxLines = 1;
                    Area1.Justify = Pallet.LineJustify.Center;
                    Area1.Rectangle = new RectangleF(0, 0, 0, 50);
                    oPallet.Areas.Add(Area1);


                    Area1 = new Pallet.Area();
                    Area1.Rectangle = new RectangleF(0, 50, 0, 500);
                    Area1.Text = this.Name.Trim();

                    Area1.Font = new System.Drawing.Font("Arial Narrow", 1);
                    oPallet.Areas.Add(Area1);

                    Area1 = new Pallet.Area();
                    Area1.Text = Address;
                    Area1.MaxLines = 1;
                    Area1.Rectangle = new RectangleF(0, 550, 0, 50);
                    oPallet.Areas.Add(Area1);

                    Area1 = new Pallet.Area();
                    Area1.Text = City + ", " + State + " " + ZipCode;
                    Area1.MaxLines = 1;
                    Area1.Rectangle = new RectangleF(0, 600, 0, 50);
                    oPallet.Areas.Add(Area1);

                    Area1 = new Pallet.Area();
                    Area1.Text = "Attn: "+Chairperson;
                    Area1.MaxLines = 1;
                    Area1.Rectangle = new RectangleF(0, 650, 0, 50);
                    oPallet.Areas.Add(Area1);
                    if (!oCustomerExtra.isKK)
                    {
                        Area1 = new Pallet.Area();
                        Area1.Text = this.ShipDate != DNull ? "LIFT GATE & INSIDE DELIVERY. ALL ACCESSORIAL CHARGES PREPAID BY SHIPPER." : "";
                        Area1.MaxLines = 2;
                        Area1.Rectangle = new RectangleF(0, 700, 0, 80);
                        oPallet.Areas.Add(Area1);
                        
                        Area1 = new Pallet.Area();
                        Area1.Text = "SHIP: " + (this.ShipDate != DNull ? this.ShipDate.ToString("MM/dd/yyyy") : "");
                        Area1.MaxLines = 1;
                        Area1.Rectangle = new RectangleF(0, 780, 0, 110);
                        oPallet.Areas.Add(Area1);

                        Area1 = new Pallet.Area();
                        Area1.Text = "DEL: " + (this.DeliveryDate != DNull ? this.DeliveryDate.ToString("MM/dd/yyyy") : "");
                        Area1.MaxLines = 1;
                        Area1.Rectangle = new RectangleF(0, 890, 0, 110);
                        oPallet.Areas.Add(Area1);
                    }
                    else
                    {
                        Area1 = new Pallet.Area();
                        Area1.Text = "KK " ;
                        Area1.Font = new System.Drawing.Font(new FontFamily("Arial"), 12, FontStyle.Bold);
                        Area1.MaxLines = 1;
                        Area1.Rectangle = new RectangleF(0, 780, 0, 110);
                        oPallet.Areas.Add(Area1);
                    }
                    
                    Area1 = new Pallet.Area();
                    Area1.Text = strPallet;
                    Area1.MaxLines = 1;
                    Area1.Rectangle = new RectangleF(0, 1010, 0, 50);
                    Area1.Justify = Pallet.LineJustify.Center;
                    oPallet.Areas.Add(Area1);

                    
                    oPallet.Print();

            
            }

            
        }
       
        public void PrintGoalPercentage(CrystalReportViewer oViewer)
        {
            DataSet ds = new DataSet();
            
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select cs.*, c.CustomerID, c.Name, c.Address, c.ZipCode, c.State from Customer c Left Join CustomerCS cs on cs.CompanyID=c.CompanyID and cs.CustomerID=c.CustomerID  Where c.CompanyID='{0}' And c.CustomerID='{1}'", this.CompanyID, this.ID),"Customer"));
            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Call InvoiceTotals13('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, "o.Teacher", "o.Teacher", 0.00, 0.00), "Teacher"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.Name, sum(Nro_Items) as Quantity, sum(Retail) as Total, t.NoStudents From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Where o.CompanyID='{0}' And o.CustomerID='{1}' Group By t.Name", CompanyID, ID) , "Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.CustomerID, t.Name as Teacher, if(sum(o.Nro_Items) is null,0,sum(o.Nro_Items)) as Quantity, sum(o.Retail) as Total, t.NoStudents From Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Where t.CompanyID='{0}' And t.CustomerID='{1}' Group By t.Name", CompanyID, ID), "Teacher"));                        
            
           //ds.WriteXml("D:\\PrinGoalPercentage4.xml", XmlWriteMode.WriteSchema);

            GoalPercentageReport oRpt = new GoalPercentageReport();

            oRpt.SetDataSource(ds);
            //oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
            
            //ds.Dispose();
            //oRpt.Dispose();
            //oViewReport.Dispose();
        }
        public void PrintGoalTeacherStudent(CrystalReportViewer oViewer)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Call InvoiceTotals13('{0}','{1}','{2}','{3}','{4}','{5}')", CompanyID, ID, "o.Student", "o.Student", 0.00, 0.00), "Teacher"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select t.Name as Teacher, s.Name as Student,sum(Nro_Items) as Quantity, sum(Retail) as Retail From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}' Group By t.Name, s.Name", CompanyID, ID), "Teacher"));

            //ds.WriteXml("D:\\PrinGoalPercentage2.xml", XmlWriteMode.WriteSchema);

            GoalTeacherStudent oRpt = new GoalTeacherStudent();

            oRpt.SetDataSource(ds);
            
            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;

            
        }
        public void PrintWackyWearables(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher",Global.oMySql.SqlDate(CutDate),this.CompanyID), "Teacher"));

            //ds.WriteXml("D:\\WackyWearebles1.xml", XmlWriteMode.WriteSchema);

            WackyWearables oRpt = new WackyWearables();

            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintEarlyBird(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(*) as Students, sum(Nro_Items) as Items from Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where Date <= Date('{0}') And o.CompanyID='{1}' Group By t.Name, s.Name", oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Items from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where Date(o.Date) <= Date('{0}') And o.CompanyID='{1}' And o.CustomerID='{2}' Group By t.Name, s.Name", oMySql.SqlDate(CutDate), this.CompanyID,this.ID), "Teacher"));
            //ds.WriteXml("D:\\EarlyBird1.xml", XmlWriteMode.WriteSchema);

            EarlyBird oRpt = new EarlyBird();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("EarlyBirdDate", CutDate);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintSchoolClassTotals(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.Name as Teacher, sum(Nro_Items) as Quantity, sum(Retail) as Retail From Orders o Right Join Teacher t On o.TeacherID=t.TeacherID  Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name", CompanyID, ID, Global.oMySql.SqlDate(CutDate)), "Teacher"));

           // ds.WriteXml("D:\\SchoolClassTotals3.xml", XmlWriteMode.WriteSchema);
            //MessageBox.Show(String.Format("Select t.Name as Teacher, s.Name as Student,sum(Nro_Items) as Quantity, sum(Retail) as Retail From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}' And Date <= Date('{0}') Group By t.Name", CompanyID, ID, Global.oMySql.SqlDate(CutDate)));
            
            CS_SchoolClassTotalReport oRpt = new CS_SchoolClassTotalReport();

            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintDailyStudentTotals(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where CompanyID='{0}' Group By Teacher",  this.CompanyID), "Teacher"));
        //    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.Name as Teacher, s.Name as Student,sum(Nro_Items) as Quantity, sum(Retail) as Retail, Date(Date) as Date From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name, s.Name, Date", CompanyID, ID),"Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where Date <= Date('{0}') And o.CompanyID='{1}' And o.CustomerID='{2}' Group By t.Name, s.Name", oMySql.SqlDate(CutDate), this.CompanyID, this.ID), "Teacher"));  

          //  ds.WriteXml("D:\\DailyStudentTotals1.xml", XmlWriteMode.WriteSchema);

            CS_DailyStudentTotalsReport oRpt = new CS_DailyStudentTotalsReport();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("Date", CutDate);
            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintDailyStudentEntriesReport(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));
            
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail, sum(o.Collected) as Collected, Date from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where  o.CompanyID='{0}' And o.CustomerID='{1}' Group By  t.Name, s.Name, o.ID", this.CompanyID, this.ID), "Teacher"));  

            //ds.WriteXml("D:\\DailyStudentEntriesReport1.xml", XmlWriteMode.WriteSchema);

            
            CS_DailyStudentEntriesReport oRpt = new CS_DailyStudentEntriesReport();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void Print10toWinQualifiersReport(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name, s.Name Having Quantity >= 10", this.CompanyID,  ID), "Teacher"));

      //      ds.WriteXml("D:\\DailyStudentEntriesReport.xml", XmlWriteMode.WriteSchema);


            CS_10toWinQualifiersReport oRpt = new CS_10toWinQualifiersReport();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintTopSelllersReport(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
          //  ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name, s.Name Order By Quantity desc ", this.CompanyID, ID), "Teacher"));

     //       ds.WriteXml("D:\\PrintTopSelllersReport.xml", XmlWriteMode.WriteSchema);


            CS_TopSelllersReport oRpt = new CS_TopSelllersReport();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintTeacherBonusReport(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            //ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
           // ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select cs.*, c.CustomerID, c.Name, c.Address, c.ZipCode, c.State from Customer c Left Join CustomerCS cs on cs.CompanyID=c.CompanyID and cs.CustomerID=c.CustomerID  Where c.CompanyID='{0}' And c.CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select c.Goal, t.CustomerID, t.Name as Teacher, if(sum(o.Nro_Items) is null,0,sum(o.Nro_Items)) as Quantity, sum(o.Retail) as Total, t.NoStudents From Teacher t Left Join Orders o On o.TeacherID=t.TeacherID  Left Join CustomerCS c On c.CustomerID=t.CustomerID Where t.CompanyID='{0}' And t.CustomerID='{1}' Group By t.Name   ", CompanyID, ID), "Teacher"));                        

      //      ds.WriteXml("D:\\TeacherBonusReport.xml", XmlWriteMode.WriteSchema);

            foreach (DataRow row in ds.Tables["Teacher"].Rows)
            {
                Int32 Quantity = row["Quantity"] ==  DBNull.Value?0:Convert.ToInt32(row["Quantity"].ToString());
                Int32 NoStudents = row["NoStudents"] == DBNull.Value ? 0 : Convert.ToInt32(row["NoStudents"].ToString());
                Int32 Goal = row["Goal"] == DBNull.Value ? 0 : Convert.ToInt32(row["Goal"].ToString());
                String Student = row["Teacher"].ToString();

                Int32 ClassGoal = NoStudents < 10 ? 100 : NoStudents * Goal;

                
                if (ClassGoal == 0)
                    row.Delete();
                else if (Quantity / ClassGoal*100 < 100)
                {
                    row.Delete();
                }

            }



            /*
             * Class Goal
            if ({Teacher.NoStudents} < 10) then
                    100
            else
                {Teacher.NoStudents}*{Customer.Goal}
            
             //Goal
                if ({@ClassGoal} = 0) then
                    0   
                else
                    {Teacher.Quantity}/{@ClassGoal}*100
             
             */





            ds.Tables["Teacher"].AcceptChanges();


            CS_TeacherBonusReport oRpt = new CS_TeacherBonusReport();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintClassCollectionSheet(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

   //         ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
   //         ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where CompanyID='{0}' Group By Teacher",  this.CompanyID), "Teacher"));
            //    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.Name as Teacher, s.Name as Student,sum(Nro_Items) as Quantity, sum(Retail) as Retail, Date(Date) as Date From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name, s.Name, Date", CompanyID, ID),"Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail, sum(o.Collected) as Collected from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where  o.CompanyID='{0}' And o.CustomerID='{1}' Group By t.Name, s.Name",  this.CompanyID, this.ID), "Teacher"));  

        //    ds.WriteXml("D:\\ClassCollectionSheet2.xml", XmlWriteMode.WriteSchema);


            CS_ClassCollectionSheet oRpt = new CS_ClassCollectionSheet();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("Date", CutDate);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintClassCollectionSheetByDate(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            //         ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //         ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            //ds.Tables.Add(oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where CompanyID='{0}' Group By Teacher",  this.CompanyID), "Teacher"));
            //    ds.Tables.Add(oMySql.GetDataTable(String.Format("Select t.Name as Teacher, s.Name as Student,sum(Nro_Items) as Quantity, sum(Retail) as Retail, Date(Date) as Date From Orders o Left Join Teacher t On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where o.CompanyID='{0}' And o.CustomerID='{1}'  Group By t.Name, s.Name, Date", CompanyID, ID),"Teacher"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select o.CustomerID, t.Name as Teacher, s.Name as Student, count(s.Name) as Students, sum(o.Nro_Items) as Quantity, sum(o.Retail) as Retail, sum(o.Collected) as Collected from Teacher t Left Join Orders o On o.TeacherID=t.TeacherID Left Join Student s On o.StudentID=s.StudentID Where  o.CompanyID='{0}' And o.CustomerID='{1}' And Date(o.Date) = Date('{2}') Group By t.Name, s.Name", this.CompanyID, this.ID, Global.oMySql.SqlDate(CutDate)), "Teacher"));

            //    ds.WriteXml("D:\\ClassCollectionSheet2.xml", XmlWriteMode.WriteSchema);


            CS_ClassCollectionSheet oRpt = new CS_ClassCollectionSheet();
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("Date", CutDate);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintDailyDeposits(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));

    //        ds.WriteXml("D:\\DailyDeposits.xml", XmlWriteMode.WriteSchema);


            CS_DailyDeposits oRpt = new CS_DailyDeposits();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public void PrintStudentDonationReport(CrystalReportViewer oViewer, DateTime CutDate)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select * from Customer Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer"));
            ds.Tables.Add(Global.oMySql.GetDataTable(String.Format("Select CustomerID, Teacher, Student, count(distinct(Student)) as Students, sum(Nro_Items) as Items from Orders Where Date <= Date('{0}') And CompanyID='{1}' Group By Teacher", Global.oMySql.SqlDate(CutDate), this.CompanyID), "Teacher"));

   //         ds.WriteXml("D:\\StudentDonationReport.xml", XmlWriteMode.WriteSchema);


            CS_StudentDonationReport oRpt = new CS_StudentDonationReport();
            oRpt.SetDataSource(ds);

            oViewer.ReportSource = oRpt;
            oViewer.DisplayGroupTree = false;
        }
        public Boolean PrintAttentionParents(String PrinterName, PrinterDevice Device)
        {
            frmViewReport oViewReport = new frmViewReport();
            //DataSet ds1 = oMySql.GetCustomerStatement(CompanyID, ID);

            DataSet ds1 = new DataSet();

            ds1.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, ID), "Customer"));


            CustomerPDF oRpt = new CustomerPDF(); 
            
            //ds1.WriteXml("dataset26.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds1);
            oRpt.SetParameterValue("Line_1", "All Money and Orders will be due on: "+this.EndDate.ToLongDateString()); //LastInvoicedAmount);
            oRpt.SetParameterValue("Line_2", "Please make checks payable to: " + this.PayableTo); //LastInvoicedAmount);
            oRpt.SetParameterValue("Line_3", "Products will be available to pickup on: " +this.PickUpDate.ToLongDateString()); //LastInvoicedAmount);

            if (Device == PrinterDevice.Printer)
            {
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
            }
            else if (Device == PrinterDevice.eMail)
            {

                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\" + this.ID + ".pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.ID);

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = base.ID + " - Attention Parent Letter " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() + "(" + this.ID + " - " + this.Name + ")";

                /*
                if (PrinterName != "")
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + PrinterName + ">"; //this.eMail + ">";
                else if (this.isEmail(this.eMail) || !File.Exists(oPDF.FileName))
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + this.eMail + ">";
                else
                    */
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + "scott@sigfund.com" + ">"; //this.eMail + ">";

                oSmtp.From = "\"Signature Fundraising Customer Service\" <info@sigfund.com>";

                String strTitle = "\n\r";
                strTitle += "\n\nThank you.\n\r";
                strTitle += "Signature Fundraising\n\r";

                

                oSmtp.Body = strTitle;
               // oSmtp.Attachment = oPDF.FileName;
                oSmtp.Credentials = new System.Net.NetworkCredential("info@sigfund.com", "sigrep");
                // oSmtp.BCC = "scotte@sigfund.com";

                

                MemoryStream strm = new MemoryStream();
                PdfReader pdfReader = new PdfReader(oPDF.FileName);
                PdfStamper stamp = new PdfStamper(pdfReader, new FileStream(Application.StartupPath + "\\~"+this.ID+".pdf", System.IO.FileMode.Create));

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\Border Paper.jpg");
                img.SetAbsolutePosition(0, +55);
                img.ScalePercent(pdfReader.GetPageSize(1).Width * 100 / img.Width);
                img.Alignment = iTextSharp.text.Image.ALIGN_JUSTIFIED_ALL;
                
                PdfContentByte waterMark = stamp.GetUnderContent(1); //Page 1
                waterMark.AddImage(img, true);
                //waterMark.AddImage(img);
                stamp.FormFlattening = true;
                stamp.Close();

                if (PrinterName == "" && !this.isEmail(this.eMail))
                    strTitle += " WRONG EMAIL ADDRESS: " + this.eMail + " of " + this.ID + " : " + this.Name;

                if (PrinterName == "" && !File.Exists(oPDF.FileName))
                    strTitle += " NO PDF FILE : " + this.eMail + " of " + this.ID + " : " + this.Name;
                else
                    oSmtp.Attachment = Application.StartupPath + "\\~" + this.ID + ".pdf";


                if (!oSmtp.Send())
                {
                    Console.WriteLine(oSmtp.Error);
                    oRpt.Dispose();
                    oViewReport.Dispose();
                    File.Delete(oPDF.FileName);
                    return false;
                }
                //while (File.GetAttributes(oPDF.FileName) == FileAttributes.ReadOnly) ;
                /*
                ReadFile:
                try
                {
                    if (File.Exists(oPDF.FileName))
                        File.Delete(oPDF.FileName);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto ReadFile;
                }
                */

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }

            oRpt.Dispose();
            oViewReport.Dispose();

            return true;
        }
        
        public void PrintOrdersDrawing(Int32 NoItems)
        {

            DataSet ds = new DataSet();

            DataTable dtCustomers = oMySql.GetDataTable(String.Format("Select * From Customer  Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Customer");
            DataTable dtOrders = oMySql.GetDataTable(String.Format("Select * From Orders  Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Order1");
            DataTable dtDrawing = oMySql.GetDataTable(String.Format("Select * From Orders  Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.ID), "Order");

            dtDrawing.Rows.Clear();
            dtDrawing.Columns.Add(new DataColumn("Teacher1",  Type.GetType("System.String")));
            dtDrawing.Columns.Add(new DataColumn("Student1", Type.GetType("System.String")));
            Boolean Left = true;
            Int16 Recs = 0;
            DataRow _row = null;
            foreach (DataRow row in dtOrders.Rows)
            {
                Recs++;
                Int32 Times = Convert.ToInt32(((Int32)row["Nro_Items"] / NoItems));
                
                for (int x = 0; x < Times; x++)
                {
                    
                    
                    if (Left)
                    {
                         _row = dtDrawing.NewRow();
                        _row["Teacher"] = row["Teacher"];
                        _row["Student"] = row["Student"];
                        Left = false;
                        
                    }
                    else
                    {
                        _row["Teacher1"] = row["Teacher"];
                        _row["Student1"] = row["Student"];
                        Left = true;
                        dtDrawing.Rows.Add(_row);
                    }
                    
                }
                if (Recs++ == dtOrders.Rows.Count && !Left)
                {
                    dtDrawing.Rows.Add(_row);
                }
            }
            
            dtDrawing.AcceptChanges();

            ds.Tables.Add(dtCustomers);
            ds.Tables.Add(dtDrawing);




            frmViewReport oViewReport = new frmViewReport();
            //ds.WriteXml("PrintOrderDrawing1.xml", XmlWriteMode.WriteSchema);

            CustomerOrderDrawing oRpt = new CustomerOrderDrawing();

            oRpt.SetDataSource(ds);
            //oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            //oRpt.PrintToPrinter(1, false, 0, 0);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();

        }
        
        
        
        private DataSet GetDiscrepancyDataSet()
        {
            return GetDiscrepancyDataSet(0);
        }
        private DataSet GetDiscrepancyDataSet(Int32 OrderID )
        {
            DataSet ds = new DataSet();

            
               ds.Tables.Add(oMySql.GetDataTable("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID,  c.ChairPerson, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct o.Teacher) as n_teachers, count(distinct o.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products   From OrderDetail as d LEFT JOIN Orders o On o.ID=d.OrderID LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Reps r ON c.Rep_ID=r.ID   Where  d.CompanyID='" + CompanyID + "' And  d.CustomerID='" + ID + "' GROUP BY d.CustomerID", "Customer"));
            if (OrderID == 0)   
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Orders Where CompanyID='{0}' And CustomerID = '{1}' And ABS(Collected - (Retail+Tax)) >= 1.5   Order by Teacher, Student",CompanyID,ID),"D_Orders"));
            else
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Orders Where ID='{0}' And ABS(Collected - (Retail+Tax)) >= 1.5",OrderID), "D_Orders"));

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select OrderID,o.Teacher, o.Student, dl.Date, Text as Text1, 'Text', o.CustomerID, o.CompanyID  From Disc_Letter dl LEFT JOIN Orders o ON o.ID=dl.OrderID  Where o.CustomerID='{0}' And o.CompanyID='{1}'", ID, CompanyID), "Letters"));

            foreach (DataRow row in ds.Tables["Letters"].Rows)
            {
                byte[] byteBLOBData = (Byte[])(row["Text1"]);
                String Text = System.Text.Encoding.UTF8.GetString(byteBLOBData);
                row["Text"] = Text;
            }

            return ds;

        }
        private DataTable CreateDetailTableSummaryReport()
        {
            
            DataSet ds = new DataSet();
            
            //Teachers
            ds.Tables.Add(oMySql.GetDataTable(String.Format("select distinct(o.Teacher), count(distinct o.Student) as Sellers, sum(quantity) as Items,  sum(quantity*p.Price) as Sale , sum(d.Tax) as Tax,  d.CustomerID from OrderDetail d  LEFT JOIN Orders o On d.OrderID=o.ID LEFT JOIN Product p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID  where  d.CompanyID='{0}' And  d.CustomerID='{1}'  Group by o.Teacher Order by Items desc limit 5", CompanyID, ID), "Teachers"));
            
            //Students
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT distinct(Student), SUM(o.Nro_Items) as Items, Retail, Teacher, CustomerID FROM Orders o Where  o.CompanyID='{0}' And   o.CustomerID='{1}'  Group by o.Student Order by SUM(o.Nro_Items) Desc LIMIT 10", CompanyID, ID), "Students"));
            
            
            DataTable  dt = new DataTable("Detail");
            dt.Columns.Add("CustomerID", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Teacher", typeof(String));
			dt.Columns.Add("Items", typeof(Int32));
			dt.Columns.Add("Amount", typeof(Double));
            dt.Columns.Add("Name_2", typeof(String));
            dt.Columns.Add("Items_2", typeof(Int32));
            dt.Columns.Add("Amount_2", typeof(Double));
            

            DataRow row = dt.NewRow();
            foreach (DataRow dvRow in ds.Tables["Students"].Rows)
            {
                    row = dt.NewRow();
                    row["CustomerID"] = ID;
                    row["Name"] = dvRow["Student"];
                    row["Teacher"] = dvRow["Teacher"];
                    row["Items"] = dvRow["Items"];
                    row["Amount"] = dvRow["Retail"];
                    dt.Rows.Add(row);
            }

            int Seq = 0;
            foreach (DataRow dvRow in ds.Tables["Teachers"].Rows)
            {   
                
                dt.Rows[Seq]["Name_2"] = dvRow["Teacher"];
                dt.Rows[Seq]["Items_2"] = dvRow["Items"];
                dt.Rows[Seq]["Amount_2"] = dvRow["Sale"];
                Seq++;
                //MessageBox.Show(dvRow["Teacher"].ToString());
            }

            return dt;
        }
        public DataTable GetCustomerRange(Object DFrom, Object DTo, String DateName)
        {
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

            switch (DateName)
            {
                case "All":
                    DateSql = "";
                    break;
                default:
                    DateSql = " And " + DateName + "Date";
                    break;

            }
            if (DateName != "") //Thus All
            {
                if (DateFrom.Trim().Length > 0)
                    Sql = String.Format(DateSql + " >= '{0}'", DateFrom);

                if (DateTo.Trim().Length > 0)
                    Sql += String.Format(DateSql + " <= '{0}'", DateTo);
            }


            if (DateName == "Delivery")
            {
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateName + "Date as Date From Customer c  Where c.CompanyID='{0}' {1} And ShipDate is null Order By Date,c.Name", CompanyID, Sql), "Customer"));
            }
            else
            {
                ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *," + DateName + "Date as Date From Customer c  Where c.CompanyID='{0}' {1} Order By Date,c.Name", CompanyID, Sql), "Customer"));
            }


            return ds.Tables["Customer"];
        }

        public  bool isEmail(string inputEmail)
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
        #endregion
        #region Classes & Enumerators
        public class _Kits
        {
            private MySQL oMySql = Global.oMySql;
            public DataTable dtKits = new DataTable("CustomerKits");

       
            public void SetColumns1()
            {
                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("KitID", Type.GetType("System.String"));
                colWork.Caption = "Kit ID";
                colWork.ColumnMapping = MappingType.Attribute;
                colWork.MaxLength = 10;
                colWork.ReadOnly = true;
                dtKits.Columns.Add(colWork);

                colWork = new DataColumn("Name", Type.GetType("System.String"));
                colWork.ReadOnly = true;
                dtKits.Columns.Add(colWork);


                //' add CustomerID column to key array and bind to DataTable
                DataColumn[] Keys = new DataColumn[1];
                Keys[0] = dtKits.Columns["KitID"];
                dtKits.PrimaryKey = Keys;

                colWork = new DataColumn("Quantity", Type.GetType("System.Int16"));
                //  colWork.MaxLength = 10;
                dtKits.Columns.Add(colWork);

            /*    // add a row
                DataRow row = dtKits.NewRow();
                row["CustomerID"] = "2268";
                row["KitID"] = "KT7022";

                dtKits.Rows.Add(row);*/

                return;
            }
            public DataTable GetDataTable(Customer oCustomer)
            {
                dtKits.Clear();
                dtKits = oMySql.GetDataTable("SELECT ks.KitID, k.Name,  Quantity FROM ga_kitbyschool ks Left Join ga_kit k on ks.KitID=k.ID And ks.CompanyID=k.CompanyID  Where CustomerID='"+oCustomer.ID+"'", "Kits");
                return dtKits;
            }
            public void RemoveAt(int Index)
            {
                if (dtKits.Rows.Count > Index)
                    dtKits.Rows.RemoveAt(Index);
            }
            public void Save(Customer oCustomer)
            {

                String Sql = String.Format("Delete From ga_kitbyschool Where CompanyID = '{0}' And CustomerID = '{1}'",
                                                    oCustomer.CompanyID, oCustomer.ID);
                oMySql.exec_sql(Sql);
                dtKits.AcceptChanges();
                foreach (DataRow drow in dtKits.Rows)
                {
                    int Qty = 0;
                    if (drow["Quantity"] == DBNull.Value)
                        Qty = 0;
                    else
                        Qty = Convert.ToInt16(drow["Quantity"].ToString());

                    if (Qty > 0 && drow["KitID"].ToString().Substring(0, 2) == "KT")
                    {

                        Sql = String.Format("Insert Into ga_kitbyschool (CompanyID, CustomerID, KitID, Quantity) Values ('{0}','{1}','{2}','{3}')",
                                                   oCustomer.CompanyID, oCustomer.ID, drow["KitID"].ToString(), drow["Quantity"].ToString());
                        oMySql.exec_sql(Sql);

                    }

                }
            }

            public void Save(Customer oCustomer, _ReOrders oReOrders)
            {

                String Sql = String.Format("Delete From ga_kitbyschool Where CompanyID = '{0}' And CustomerID = '{1}'",
                                                    oCustomer.CompanyID, oCustomer.ID);
                oMySql.exec_sql(Sql);
                foreach (DataRow drow in oReOrders.dtReOrders.Rows)
                {
                    int Qty = 0;
                    if (drow["Quantity"] == DBNull.Value)
                        Qty = 0;
                    else
                        Qty = Convert.ToInt16(drow["Quantity"].ToString());

                    if (Qty > 0 && drow["ProductID"].ToString().Substring(0,2)=="KT")
                    {
                        
                         Sql = String.Format("Insert Into ga_kitbyschool (CompanyID, CustomerID, KitID, Quantity) Values ('{0}','{1}','{2}','{3}')",
                                                    oCustomer.CompanyID, oCustomer.ID, drow["ProductID"].ToString(),drow["Quantity"].ToString());
                        oMySql.exec_sql(Sql);

                    }

                }
            }
            public void SetColumns(int gType)
            {

                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("KitID", Type.GetType("System.String"));
                colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Kit ID";
                colWork.ReadOnly = true;
                this.dtKits.Columns.Add(colWork);

                if (gType == 0)
                {
                    colWork = new DataColumn("CustomerID", Type.GetType("System.String"));
                    colWork.Caption = "CustomerID";
                    colWork.ReadOnly = true;
                    dtKits.Columns.Add(colWork);
                }
                else
                {
                    colWork = new DataColumn("Name", Type.GetType("System.String"));
                    colWork.Caption = "Name";
                    colWork.ReadOnly = true;
                    dtKits.Columns.Add(colWork);
                }

                
                DataColumn[] Keys = new DataColumn[1];
                Keys[0] = dtKits.Columns["KitID"]; //colWork;
                dtKits.PrimaryKey = Keys;

                
                colWork = new DataColumn("Quantity", Type.GetType("System.Int16"));
                //  colWork.MaxLength = 10;
                dtKits.Columns.Add(colWork);

              
                
                /*  // add a row
                DataRow row = dtKits.NewRow();
                row["CustomerID"] = "2268";
                row["KitID"] = "KT7022";

                dtKits.Rows.Add(row);
                */
                return;
            }
        }
        public class _ReOrders
        {
            private MySQL oMySql = Global.oMySql;
            public DataTable dtReOrders = new DataTable("CustomerReorders");


            public String ShipVia;
            public String Rush = "N";
            public DateTime _ShipDate = new DateTime();
            public DateTime _DeliveryDate = new DateTime();
            public String _CustomerPONumber = null;
            public int NumberOfItems = 0;

            GA_Giftco oGiftco = new GA_Giftco("");
            String OrderID = null;
            String _FileName = null;

            public void SetColumns()
            {
                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
                colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Product ID";
                colWork.ReadOnly = true;
                this.dtReOrders.Columns.Add(colWork);



                colWork = new DataColumn("Description", Type.GetType("System.String"));
                colWork.Caption = "Description";
                colWork.MaxLength = 200;
                colWork.ReadOnly = true;
                dtReOrders.Columns.Add(colWork);

                //' add CustomerID column to key array and bind to DataTable
                DataColumn[] Keys = new DataColumn[1];
                Keys[0] = dtReOrders.Columns["ProductID"]; //colWork;
                dtReOrders.PrimaryKey = Keys;

                colWork = new DataColumn("Price", Type.GetType("System.String"));
                colWork.Caption = "Price";
                colWork.ReadOnly = true;
                dtReOrders.Columns.Add(colWork);

                colWork = new DataColumn("Quantity", Type.GetType("System.Int16"));
                //  colWork.MaxLength = 10;
                dtReOrders.Columns.Add(colWork);

              /*  // add a row
                DataRow row = dtKits.NewRow();
                row["CustomerID"] = "2268";
                row["KitID"] = "KT7022";

                dtKits.Rows.Add(row);
                */
                return;
            }
            public DataTable GetDataTable(Customer oCustomer)
            {
                //DataTable dTable = oMySql.GetDataTable("SELECT ks.KitID as ProductID, k.Name as Description, '0.00' as Price FROM ga_kitbyschool ks Left Join ga_kit k on ks.KitID=k.ID And ks.CompanyID=k.CompanyID", "XX");
                DataTable dTable = oMySql.GetDataTable("SELECT k.ID as ProductID, k.Name as Description, '0.00' as Price FROM ga_kit k", "XX");

                dtReOrders.Rows.Clear();
                foreach (DataRow drow in dTable.Rows)
                {
                    DataRow row = dtReOrders.NewRow();
                    row["ProductID"] = drow["ProductID"];
                    row["Description"] = drow["Description"];
                    row["Price"] = drow["Price"];

                    dtReOrders.Rows.Add(row);
                }
                
                dTable = oMySql.GetDataTable("SELECT distinct(pb.ProductID), p.Description, p.Price, '' as Quantity FROM ga_kitbyschool ks Left Join ga_kit k on ks.KitID=k.ID And ks.CompanyID=k.CompanyID right Join ga_box b on ks.KitID=b.KitID And ks.CompanyID=b.CompanyID Left Join ga_productbybox pb on b.ID=pb.BoxID And ks.CompanyID=pb.CompanyID Left Join Product p on pb.ProductID=p.ProductID And ks.CompanyID=p.CompanyID Where CustomerID='"+oCustomer.ID+"' Order By pb.ProductID", "ProductKit");
                foreach (DataRow drow in dTable.Rows)
                {
                    DataRow row = dtReOrders.NewRow();
                    row["ProductID"] = drow["ProductID"];
                    row["Description"] = drow["Description"];
                    row["Price"] = drow["Price"];

                    dtReOrders.Rows.Add(row);
                }
                
                return dtReOrders;
            }
            public void SubmitOrder(Customer oCustomer)
            {

                _CustomerPONumber = oCustomer.ID + "-" + (GetNumOrders(oCustomer)+1).ToString();
                _FileName = "SF"+_CustomerPONumber + ".txt";
                Rep oRep = new Rep(oCustomer.CompanyID);
                oRep.Find(oCustomer.RepID);



                oGiftco._ID                 = OrderID;
                oGiftco._SFOrder            = OrderID;
                oGiftco._RecordType         = "010";
                oGiftco._SFSalesRepNumber   = oCustomer.RepID.ToString();
                oGiftco._SFSalesRepName     = oRep.Name;
                oGiftco._SFAccountNumber    = "R49221";
                oGiftco._CustomerPONumber   = oCustomer.ID + "-" + (GetNumOrders(oCustomer) + 1).ToString(); //_CustomerPONumber;
                oGiftco._OrderDate          = DateTime.Now;
                oGiftco._RequestedShipDate  = _ShipDate;
                oGiftco._CancelDeliveryDate = _DeliveryDate;
                oGiftco._OrderType          = "";
                oGiftco._ProgramName        = "GiftAvenue";
                oGiftco._ShipVia            = ShipVia;
                oGiftco._ShipToName         = oCustomer.Name;
                oGiftco._ShipToAddress1     = oCustomer.Chairperson;
                oGiftco._ShipToAddress2     = oCustomer.Address;
                oGiftco._ShipToCity         = oCustomer.City;
                oGiftco._ShipToState        = oCustomer.State;
                oGiftco._ShipToZipCode      = oCustomer.ZipCode; 
                oGiftco._HotRush            = Rush;

                NumberOfItems = 0;

                foreach (DataRow drow in dtReOrders.Rows)
                {
                    int Qty = 0;
                    if (drow["Quantity"] == DBNull.Value)
                        Qty = 0;
                    else
                        Qty = Convert.ToInt16(drow["Quantity"].ToString());

                    if (Qty > 0)
                    {
                        GA_Giftco._Item Item = new GA_Giftco._Item();
                        Item.SFOrder = OrderID;
                        Item.RecordType = "020";
                        Item.ProductID = "";
                        Item.Giftco_ItemNumber = drow["ProductID"].ToString();
                        Item.Price = drow["Price"].ToString();
                        Item.Quantity = drow["Quantity"].ToString();
                        Item.SpecialInstructions = "";

                        oGiftco.Items.Add(drow["ProductID"].ToString(), Item);
                        this.NumberOfItems ++;
                    }

                    
                }


            }
            public bool SendFTPFile(Customer oCustomer)
            {

                if (this.NumberOfItems > 0)
                {
                    
                    while (true)
                    {

                        try
                        {
                            oGiftco.CreateTransmissionFile(_FileName);
                            oGiftco.SendFTPFile(_FileName);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            String Msg = ex.Message;
                            if (MessageBox.Show("Giftco FTP Server is delaying too long to reponde, please try again?", "FTP Transmission", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }

                            
                        }
                    }
                }
                return true;
            }
            public int GetNumOrders(Customer oCustomer)
            {
                String Sql = String.Format("Select  count(*) From {0} Where CustomerID = '{1}'",
				                    "Orders",oCustomer.ID);

                return oMySql.exec_sql_no(Sql);
            }
            public void Save(Customer oCustomer)
            {
                Order oOrder = new Order(oCustomer.CompanyID);

                oOrder.CompanyID = oCustomer.CompanyID;
                oOrder.CustomerID = oCustomer.ID;
                oOrder.Teacher = DateTime.Now.ToString();
                oOrder.Student = DateTime.Now.ToString();
                oOrder.Collected = 0D;
                oOrder.Phone = oCustomer.PhoneNumber;
                oOrder.Date = DateTime.Now;
                oOrder.Tax = 0;
                oOrder.Items.Clear();

                oOrder.Items.Clear();
                foreach (DataRow drow in dtReOrders.Rows)
                {
                    int Qty = 0;
                    if (drow["Quantity"] == DBNull.Value)
                        Qty = 0;
                    else
                        Qty = Convert.ToInt16(drow["Quantity"].ToString());

                    if (Qty > 0)
                    {
                        Order.Item oItem = new Order.Item();

                        oItem.ProductID = drow["ProductID"].ToString();
                        oItem.CompanyID = oOrder.CompanyID;
                        oItem.CustomerID = oOrder.CustomerID;
                        

                        oItem.Quantity = Qty;
                        
                        oItem._Price = (drow["Price"] == DBNull.Value)? 0.00D: Convert.ToDouble(drow["Price"].ToString());
                        oOrder.Items.Add(drow["ProductID"].ToString(), oItem);
                    }

                }
                oOrder.GetTotals();
                oOrder.Save(OrderType.Giftco);
                OrderID = oOrder.ID;        //Autogenerated ID
           
            }
            

            public void SaveAsKits(Customer oCustomer)
            {
                _Kits oKits = new _Kits();
                oKits.Save(oCustomer,this);

            }
        }
        public class _Orders : Hashlist 
        {
            
            private String _CompanyID = null;
            private String _CustomerID = null;

            public _Orders(String CompanyID, String CustomerID)
            {
                _CompanyID = CompanyID;
                _CustomerID = CustomerID;
            }

            public void Print(Boolean IsAll, int Printer, Boolean ReOrder)
            {

                Customer oCustomer = new Customer(_CompanyID);
                oCustomer.Find(_CustomerID);
                if (!oCustomer.Printed || ReOrder)
                {
                    Teacher oTeacher = new Teacher(_CompanyID);
                    oTeacher.AssignSequence(_CustomerID);
                }

                if (ReOrder)
                {
                    oMySql.exec_sql(String.Format("Update Orders Set TeacherSeq=0, StudentSeq=0 Where CompanyID='{0}' And CustomerID='{1}'", _CompanyID, _CustomerID));
                }
                

                DataView dvOrders;
                if (IsAll)
                    dvOrders = oMySql.GetDataView(String.Format("Select ID, Teacher, Student From Orders Where CompanyID='{0}' And CustomerID='{1}' Order By Teacher, Student", _CompanyID, _CustomerID),"tmp");
                else
                    dvOrders = oMySql.GetDataView(String.Format("Select ID, Teacher, Student From Orders Where CompanyID='{0}' And CustomerID='{1}' And Printed = '0'  Order By Teacher, Student", _CompanyID, _CustomerID),"tmp");

                Order oOrder = new Order(_CompanyID);
                
                if (dvOrders != null && dvOrders.Count > 0)
                {
                    oOrder.OpenPrinter(Printer);
                    int i = 0;
                    foreach (DataRowView Row in dvOrders)
                    {   
                        Global.SetProgressBar(dvOrders.Count, ++i);
                        if (oOrder.Find((Int32)Row["ID"]))
                        {
                             oOrder.Print();
                        }
                        else
                            MessageBox.Show("What's going on with this order? Please call Administrator before this autodestruct itself...");

                        // if (i == 3)
                        //     break;
                    }
                    Global.SetProgressBar(0, 0);
                    oOrder.ClosePrinter();
                }
                else
                    MessageBox.Show("Nothing to Print!!");
            }

            public void PineValley(Boolean SendFTP)
            {

                DataView dvOrders;
                
                dvOrders = oMySql.GetDataView(String.Format("Select ID, Teacher, Student From Orders Where CompanyID='{0}' And CustomerID='{1}' Order By Teacher, Student", _CompanyID, _CustomerID), "tmp");

                PineValley oPine = new PineValley(_CompanyID,_CustomerID);
                Order oOrder = new Order(_CompanyID);
                Product oProduct = new Product(_CompanyID);

                Boolean IsHeader = false;

                if (dvOrders != null && dvOrders.Count > 0)
                {
                    //int i = 0;
                    foreach (DataRowView Row in dvOrders)
                    {

                        // Global.SetProgressBar(dvOrders.Count, ++i);

                        //MessageBox.Show(Row["Student"].ToString());
                        if (oOrder.Find((Int32)Row["ID"]))
                        {
                            if (!IsHeader)
                            {
                                oPine.Open("PO " + _CustomerID + " " + oOrder.oCustomer.Name+".CSV");

                                //oPine.Open("PO " + _CustomerID  + ".CSV");
                                oPine.Header.CustomerPO = "PO" + _CustomerID;
                                oPine.Header.ArrivalWeek = oOrder.oCustomer.DeliveryDate.ToString("MM/dd/yyyy");
                                oPine.Header.ShipToID = _CustomerID;
                                oPine.Header.ShipToName = oOrder.oCustomer.Name;
                                oPine.Header.ShipToAttention = oOrder.oCustomer.Chairperson;
                                oPine.Header.ShipToAddress1 = oOrder.oCustomer.Address;
                                oPine.Header.ShipToAddress2 = "";
                                oPine.Header.ShipToCity = oOrder.oCustomer.City;
                                oPine.Header.ShipToState = oOrder.oCustomer.State;
                                oPine.Header.ShipToZip = oOrder.oCustomer.ZipCode;
                                oPine.Header.ShipToPhone = oOrder.oCustomer.HeadPhone;

                                oPine.Header.AddLine();
                                IsHeader = true;

                            }
                            foreach (Order.Item Item in oOrder.Items)
                            {
                                
                                oPine.Detail.TeacherName = oOrder.Teacher;
                                oPine.Detail.StudentName = oOrder.Student;
                                //oPine.Detail.ItemNumber = Item..ProductID;
                                oProduct.Find(Item.ProductID);
                                oPine.Detail.ItemNumber = oProduct.VendorItem;
                                oPine.Detail.Quantity = Item.Quantity.ToString();
                                oPine.Detail.CustomerPO = "PO" + oOrder.CustomerID;
                                oPine.Detail.AddLine();
                            }
                            
                        }
                        else
                            MessageBox.Show("What's going on with this order? Please call Administrator before this destruct itself...");

                    }
                    oPine.Close();
                    if (SendFTP)
                      oPine.SendFTPFile();
                    
                }
                else
                    MessageBox.Show("Nothing to Export!!");
            }
            public void BlueRibbon(Boolean SendFTP)
            {

                DataView dvOrders;

                dvOrders = oMySql.GetDataView(String.Format("Select ID, Teacher, Student From Orders Where CompanyID='{0}' And CustomerID='{1}' Order By Teacher, Student", _CompanyID, _CustomerID), "tmp");

                BlueRibbon oPine = new BlueRibbon(_CompanyID, _CustomerID);
                Order oOrder = new Order(_CompanyID);
                Product oProduct = new Product(_CompanyID);

                Boolean IsHeader = false;

                if (dvOrders != null && dvOrders.Count > 0)
                {
                    //int i = 0;
                    foreach (DataRowView Row in dvOrders)
                    {

                        // Global.SetProgressBar(dvOrders.Count, ++i);

                        //MessageBox.Show(Row["Student"].ToString());
                        if (oOrder.Find((Int32)Row["ID"]))
                        {
                            if (!IsHeader)
                            {
                                oPine.Open("PO " + _CustomerID + " " + oOrder.oCustomer.Name + ".CSV");

                                //oPine.Open("PO " + _CustomerID  + ".CSV");
                                oPine.Header.SchoolID       = _CustomerID;
                                oPine.Header.StudentName    = oOrder.Student;
                                oPine.Header.CustomerName   = oOrder.oCustomer.Name;
                                oPine.Header.Address1       = oOrder.oCustomer.Address;
                                oPine.Header.Address2       = "";
                                oPine.Header.City           = oOrder.oCustomer.City;
                                oPine.Header.State          = oOrder.oCustomer.State;
                                oPine.Header.ZipCode        = oOrder.oCustomer.ZipCode;
                                oPine.Header.Phone          = oOrder.oCustomer.HeadPhone;
                                oPine.Header.CustomerEmail  = oOrder.oCustomer.eMail;
                                oPine.Header.HomeRoom       = oOrder.Teacher;
                                oPine.Header.OrderCode      = oOrder.ID.ToString();
                                oPine.Header.eMail          = "scott@sigfund.com";
                                oPine.Header.AddLine();
                                IsHeader = true;

                            }
                            foreach (Order.Item Item in oOrder.Items)
                            {
                                oPine.Detail.RecordType     = "D";
                                oPine.Detail.ProductID      = Item.ProductID;
                                oPine.Detail.Quantity       = Item.Quantity.ToString();
                                oPine.Detail.UnitPrice      = Item.Price.ToString();
                                oPine.Detail.AddLine();
                            }

                        }
                        else
                            MessageBox.Show("What's going on with this order? Please call Administrator before this destruct itself...");

                    }
                    oPine.Close();
                    if (SendFTP)
                        oPine.SendFTPFile();

                }
                else
                    MessageBox.Show("Nothing to Export!!");
            }

            /* Hash List Support */
            public new Order this[string Key]
            {
                get { return (Order)base[Key]; }

            }
            public new Order this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Order)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new OrdersEnumerator(this);
            }

        }
        public class OrdersEnumerator : IEnumerator
        {
            public OrdersEnumerator(_Orders ar)
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
            protected _Orders _ar;


        }
        public class _Payments : Hashlist
        {
            
            private String _CompanyID = null;
            public String CustomerID = null;

            public _Payments(String CompanyID, String _CustomerID):base(CompanyID)
            {
                _CompanyID = CompanyID;
                CustomerID = _CustomerID;
            }

            public void Load()
            {
            }
            
            /* Hash List Support */
            public new Charge this[string Key]
            {
                get { return (Charge)base[Key]; }

            }
            public new Charge this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Charge)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new _PaymentsEnumerator(this);
            }

        }
        public class _PaymentsEnumerator : IEnumerator
        {
            public _PaymentsEnumerator(_Payments ar)
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
            protected _Payments _ar;


        }
        public class _Brochures : Hashlist
        {
            public _Brochures(String CompanyID) : base(CompanyID) { }
            public DataTable dtBrochures;
            public String CustomerID;
            
            public void Load(String CompanyID, String CustomerID)
            {
                this.CustomerID = CustomerID;
                Clear(); 
                dtBrochures = oMySql.GetDataTable("select * from BrochureByCustomer bc  Where bc.CompanyID='" + CompanyID + "' And CustomerID='" + CustomerID + "' Order By bc.Seq, bc.ID ASC ", "BrochureByCustomer");
                foreach (DataRow row in dtBrochures.Rows)
                {
                    BrochureByCustomer oBC = new BrochureByCustomer(CompanyID, CustomerID);
                    if (oBC.Find(row["BrochureID"].ToString()))
                    {
                        Add(row["BrochureID"].ToString(), oBC);
                    }
                    else
                        MessageBox.Show("Brochure for this customer not found: " + row["BrochureID"].ToString());
                }
            }

            public Boolean IsCookieDough
            {
                get 
                {
                    Boolean Yes = false;
                    Brochure oBrochure = new Brochure(this.CompanyID);
                    foreach (BrochureByCustomer oBC in this)
                    {
                        oBrochure.CompanyID = oBC.CompanyID;
                        oBrochure.Find(oBC.BrochureID);
                        if (oBrochure.IsCookieDough)
                        {
                            Yes = true;
                            break;
                        }
                    }
                    return Yes;
                }
            }

            public new void Update()
            {
                this.DeleteAll();
                foreach (BrochureByCustomer oBC in this)
                {
                    oBC.Save();
                }
            }

            public void DeleteAll()
            {
                oMySql.exec_sql(String.Format("Delete From BrochureByCustomer Where CompanyID='{0}' And CustomerID='{1}' And Deleted='1'",  CompanyID, CustomerID));
            }

            public void MarkDeleted()
            {
                oMySql.exec_sql(String.Format("Update BrochureByCustomer Set Deleted='1' Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, CustomerID));
            }
            
            /* Hash List Support */
            public new BrochureByCustomer this[string Key]
            {
                get { return (BrochureByCustomer)base[Key]; }

            }
            public new BrochureByCustomer this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (BrochureByCustomer)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new _BrochuresEnumerator(this);
            }

        }
        public class _BrochuresEnumerator : IEnumerator
        {
            public _BrochuresEnumerator(_Brochures ar)
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
            protected _Brochures _ar;


        }
        public class GiftAvenue 
        {
            internal String  TableName = "CustomerGA";
            internal SqlBuilder oBuild;
            
            
            public String CompanyID = "";
            public String CustomerID = "";
            public Int32 SFull = 0;
            public Int32 SHalf = 0;
            public Int32 SLow = 0;
            public Int32 TBin = 0;
            public Int32 LE1 = 0;
            public Int32 LE2 = 0;
            public Int32 LE3 = 0;
            public Int32 LE4 = 0;
            public Int32 LE5 = 0;
            public Int32 LETX = 0;
            public Int32 DS = 0;
            public Boolean KitAssigned = false;
            public Boolean IsProductOrdered = false;
            public Boolean IsProductReturned = false;
            public Boolean IsRegisterReturned = false;
            public Int32   BoxesReturned = 0;
            public DateTime ProductReturnedDate = Global.DNull;
            public Boolean WDS = false;
            public Int32 S1Full = 0;
            public Int32 S1Half = 0;
            public Int32 LEMUG = 0;
            public Int32 MUG = 0;
            public Int32 BBL = 0;
            public Int32 BBS = 0;
            public Int32 PROREG = 0;
            public Boolean ProductShipped = false;
            public Boolean PromoShipped = false;
            public Int32 LowKit1 = 0;
            public Boolean IsCoupon = false;
            
            public GiftAvenue(String CompanyID)
               
            {
                this.CompanyID = CompanyID;
            }

            private void Clear()
            {
                    SFull = 0;
                    SHalf = 0;
                    SLow = 0;
                    TBin = 0;
                    LE1 = 0;
                    LE2 = 0;
                    LE3 = 0;
                    LE4 = 0;
                    LE5 = 0;
                    LETX = 0;
                    KitAssigned = false;
                    IsProductOrdered = false;
                    DS = 0;
                    IsProductReturned = false;
                    IsRegisterReturned = false;
                    BoxesReturned = 0;
                    S1Full = 0;
                    S1Half = 0;
                    MUG = 0;
                    BBL = 0;
                    BBS = 0;
                    LEMUG = 0;
                    PromoShipped = false;
                    ProductShipped = false;
                    LowKit1 = 0;
                
            }

            public bool Find(String CustomerID)
            {
                return Find(CustomerID, this.CompanyID);

            }

            public bool Find(String CustomerID, String CompanyID)
            {
                if (CustomerID == "")
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = CustomerID;
                DataRow row = Global.oMySql.GetDataRow(String.Format("Select * From {0} Where CompanyID='{1}' And CustomerID='{2}'",this.TableName,CompanyID,CustomerID), "Company");


                if (row == null)
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = row["CustomerID"].ToString();
                this.SFull = (Int32)row["SFull"];
                this.SHalf = (Int32)row["SHalf"];
                this.SLow = (Int32)row["SLow"];
                this.TBin = (Int32)row["TBin"];
                this.LE1 = (Int32)row["LE1"];
                this.LE2 = (Int32)row["LE2"];
                this.LE3 = (Int32)row["LE3"];
                this.LE4 = (Int32)row["LE4"];
                this.LE5 = (Int32)row["LE5"];
                this.LETX = (Int32)row["LETX"];
                this.KitAssigned = (Boolean)row["KitAssigned"];
                this.IsProductOrdered =(Boolean)row["ProductOrdered"];
                this.DS = (Int32)row["DS"];
                this.IsProductReturned = (Boolean)row["ProductReturned"];
                this.IsRegisterReturned = (Boolean)row["RegisterReturned"];
                this.BoxesReturned = (Int32)row["BoxesReturned"];
                this.ProductReturnedDate = (row["ProductReturnedDate"] == DBNull.Value) ? Global.DNull : (DateTime)row["ProductReturnedDate"];
                this.WDS = (Boolean)row["WDS"];
                this.S1Full = (Int32)row["S1Full"];
                this.S1Half = (Int32)row["S1Half"];
                this.BBL = (Int32)row["BBL"];
                this.BBS = (Int32)row["BBS"];
                this.MUG = (Int32)row["MUG"];
                this.LEMUG = (Int32)row["LEMUG"];
                this.PROREG = (Int32)row["PROREG"];
                this.ProductShipped = (Boolean)row["ProductShipped"];
                this.PromoShipped = (Boolean)row["PromoShipped"];
                this.LowKit1 = (Int32)row["LowKit1"];
                this.IsCoupon = (Boolean)row["Coupon"];
   
                return true;

            }

            public void Save()
            {
                FillFields();
                if (Exists())
                    Update();
                else
                    Insert();
            }
            public void Update()
            {
                // MessageBox.Show(oBuild.Update("Where CallID='" + this.CallID + "'"));
                Global.oMySql.exec_sql(oBuild.Update("Where CompanyID='" + this.CompanyID + "' And CustomerID='"+this.CustomerID+"'"));
            }
            public void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                Global.oMySql.exec_sql(oBuild.Insert());
            }
            private void FillFields()
            {
                oBuild = new SqlBuilder();

                oBuild.AddRange(this.TableName, new String[] { 
                    "CompanyID", 
                    "CustomerID",
                    "SFull",
                    "SHalf",
                    "SLow",
                    "TBin",
                    "LE1",
                    "LE2",
                    "LE3",
                    "LE4",
                    "LE5",
                    "LETX",
                    "DS",
                    "KitAssigned",
                    "ProductOrdered",
                    "ProductReturned",
                    "BoxesReturned",
                    "RegisterReturned",
                    "ProductReturnedDate",
                    "WDS",
                    "S1Full",
                    "S1Half",
                    "BBL",
                    "BBS",
                    "MUG",
                    "LEMUG",
                    "PROREG",
                    "PromoShipped",
                    "ProductShipped",
                    "LowKit1",
                    "Coupon"
                    
                },
                new Object[] {
                    this.CompanyID,
                    this.CustomerID,
                    this.SFull,
                    this.SHalf,
                    this.SLow,
                    this.TBin,
                    this.LE1,
                    this.LE2,
                    this.LE3,
                    this.LE4,
                    this.LE5,
                    this.LETX,
                    this.DS,
                    this.KitAssigned?'1':'0',
                    this.IsProductOrdered?'1':'0',
                    this.IsProductReturned?'1':'0',
                    this.BoxesReturned,
                    this.IsRegisterReturned?'1':'0',
                    this.ProductReturnedDate,
                    this.WDS?'1':'0',
                    this.S1Full,
                    this.S1Half,
                    this.BBL,
                    this.BBS,
                    this.MUG,
                    this.LEMUG,
                    this.PROREG,
                    this.PromoShipped?'1':'0',
                    this.ProductShipped?'1':'0',
                    this.LowKit1,
                    this.IsCoupon
                });

            }
            public bool Exists()
            {
                if ((Global.oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CompanyID='{1}' And CustomerID='{2}'",this.TableName,this.CompanyID,CustomerID))) == 0)
                    return false;
                else
                    return true;
            }
            public void Delete()
            {
                String Sql = String.Format("Delete From {0} Where CompanyID='{1}' And CustomerID='{2}'",this.TableName,this.CompanyID,this.CustomerID);
                Global.oMySql.exec_sql(Sql);
            }
        }
        public class CustomerExtra : Company
        {
            internal new String TableName = "CustomerExtra";
            internal new SqlBuilder oBuild;

            public new String CompanyID = "";
            public String CustomerID = "";
            public String Note = "";
            public Boolean isEnrollmentForm = false;
            public Boolean is20062008 = false;
            public Boolean isPineValley = false;
            public Boolean isShowXBash = false;
            public Boolean isOld = false;
            public String eMail = string.Empty;
            public Boolean isSigned = false;
            public Boolean isChecked = false;
            public Boolean isCompleted = false;
            public Boolean isReceivedOrders = false;
            public Boolean isProfitChanged = false;
            public Boolean isGrouped = false;
            public Boolean isAMDelivery = false;
            public Boolean isKastleKreation = false;
            public Boolean isBlueDog = false;
            public Boolean isBlueDogContract = false;
            public Boolean isKK = false;

            public CustomerExtra(String CompanyID) : base(CompanyID)
            {
                this.CompanyID = CompanyID;
            }

            private void Clear()
            {
                this.Note = "";
                this.is20062008 = false;
                this.isPineValley = false;
                this.isOld = false;
                this.eMail = "";
                this.isShowXBash = false;
                this.isSigned = false;
                this.isChecked = false;
                this.isReceivedOrders = false;
                this.isProfitChanged = false;
                this.isGrouped = false;
                this.isKastleKreation = false;
                this.isBlueDog = false;
                this.isBlueDogContract = false;
                this.isKK = false;
            }

            public new bool Find(String CustomerID)
            {
                return Find(CustomerID, this.CompanyID);

            }

            public bool Find(String CustomerID, String CompanyID)
            {
                if (CustomerID == "")
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = CustomerID;
                DataRow row = this.oMySql.GetDataRow(String.Format("Select * From {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, CompanyID, CustomerID), "Company");


                if (row == null)
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = row["CustomerID"].ToString();
                this.Note = row["Note"]==DBNull.Value?"":Global.ByteToString((byte[]) row["Note"]);
                this.isEnrollmentForm = (Boolean) row["EnrollForm"];
                this.is20062008 = (Boolean)row["is20062008"];
                this.isPineValley = (Boolean)row["isPineValley"];
                this.isOld = (Boolean)row["isOld"];
                this.eMail = row["eMail"].ToString();
                this.isShowXBash = (Boolean)row["isShowXBash"];
                this.isSigned = (Boolean)row["isSigned"];
                this.isChecked = (Boolean)row["isChecked"];
                this.isCompleted = (Boolean)row["isCompleted"];
                this.isReceivedOrders = (Boolean)row["isReceivedOrders"];
                this.isProfitChanged = (Boolean)row["isProfitChanged"];
                this.isGrouped = (Boolean)row["isGrouped"];
                this.isAMDelivery = (Boolean)row["isAMDelivery"];
                this.isKastleKreation = (Boolean)row["isKastleKreation"];
                this.isBlueDog = (Boolean)row["isBlueDog"];
                this.isBlueDogContract = (Boolean)row["isBlueDogContract"];
                this.isKK = (Boolean)row["isKK"];

                return true;

            }

            public new void Save()
            {
                FillFields();
                if (Exists())
                    Update();
                else
                    Insert();
            }
            public new void Update()
            {   
                Global.oMySql.exec_sql(oBuild.Update("Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "'"));
            }
            public new void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                Global.oMySql.exec_sql(oBuild.Insert());
            }
            private new void FillFields()
            {
                oBuild = new SqlBuilder();

                oBuild.AddRange(this.TableName, new String[] { 
                    "CompanyID", 
                    "CustomerID",
                    "Note",
                    "EnrollForm",
                    "is20062008",
                    "isPineValley",
                    "isOld",
                    "eMail",
                    "isShowXBash",
                    "isSigned",
                    "isChecked",
                    "isCompleted",
                    "isReceivedOrders",
                    "isProfitChanged",
                    "isGrouped",
                    "isAMDelivery",
                    "isKastleKreation",
                    "isBlueDog",
                    "isBlueDogContract",
                    "isKK"
                },
                new Object[] {
                    this.CompanyID,
                    this.CustomerID,
                    this.Note,
                    this.isEnrollmentForm,
                    this.is20062008,
                    this.isPineValley,
                    this.isOld,
                    this.eMail,
                    this.isShowXBash,
                    this.isSigned,
                    this.isChecked,
                    this.isCompleted,
                    this.isReceivedOrders,
                    this.isProfitChanged,
                    this.isGrouped,
                    this.isAMDelivery,
                    this.isKastleKreation,
                    this.isBlueDog,
                    this.isBlueDogContract,
                    this.isKK
                });

            }
            public new bool Exists()
            {
                if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, this.CompanyID, CustomerID))) == 0)
                    return false;
                else
                    return true;
            }
            public new void Delete()
            {
                String Sql = String.Format("Delete From {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, this.CompanyID, this.CustomerID);
                oMySql.exec_sql(Sql);
            }
        }
        public class CustomerCS : Company   
        {
            internal new String TableName = "CustomerCS";
            internal new SqlBuilder oBuild;

            public new String CompanyID = "";
            public String CustomerID = "";
            public Int32 Goal;
            public DateTime EarlyBirdDate;

            public CustomerCS(String CompanyID)
                : base(CompanyID)
            {
                this.CompanyID = CompanyID;
            }

            private void Clear()
            {
                this.Goal = 0;
                this.EarlyBirdDate = Global.DNull;

            }

            public new bool Find(String CustomerID)
            {
                return Find(CustomerID, this.CompanyID);

            }

            public bool Find(String CustomerID, String CompanyID)
            {
                if (CustomerID == "")
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = CustomerID;
                DataRow row = this.oMySql.GetDataRow(String.Format("Select * From {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, CompanyID, CustomerID), "Company");


                if (row == null)
                {
                    this.Clear();
                    return false;
                }

                this.CustomerID = row["CustomerID"].ToString();
                this.Goal = (Int32) row["Goal"];
                this.EarlyBirdDate = (row["EarlyBirdDate"] == DBNull.Value) ? Global.DNull : (DateTime)row["EarlyBirdDate"];
                return true;

            }

            public new void Save()
            {
                FillFields();
                if (Exists())
                    Update();
                else
                    Insert();
            }
            public new void Update()
            {
                Global.oMySql.exec_sql(oBuild.Update("Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "'"));
            }
            public new void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                Global.oMySql.exec_sql(oBuild.Insert());
            }
            private new void FillFields()
            {
                oBuild = new SqlBuilder();

                oBuild.AddRange(this.TableName, new String[] { 
                    "CompanyID", 
                    "CustomerID",
                    "Goal",
                    "EarlyBirdDate"
                },
                new Object[] {
                    this.CompanyID,
                    this.CustomerID,
                    this.Goal,
                    this.EarlyBirdDate
                });

            }
            public new bool Exists()
            {
                if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, this.CompanyID, CustomerID))) == 0)
                    return false;
                else
                    return true;
            }
            public new void Delete()
            {
                String Sql = String.Format("Delete From {0} Where CompanyID='{1}' And CustomerID='{2}'", this.TableName, this.CompanyID, this.CustomerID);
                oMySql.exec_sql(Sql);
            }
        }
        #endregion
    }
}
