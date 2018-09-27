using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Microsoft.Office.Interop.Outlook;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public class frmCustomer : frmBase
	{
		#region Declarations
		internal Signature.Windows.Forms.TabControl tCustomer;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.TabPage TabPage3;
        private Signature.Windows.Forms.ComboBox comboBox1;
        //private Signature.Windows.Forms.MaskedEditNumeric NoItems;
        private Infragistics.Win.UltraWinGrid.UltraGrid OrdersGrid;
        private Infragistics.Win.UltraWinGrid.UltraGrid RGrid;
        private Signature.Windows.Forms.GroupBox gbDates;
        internal Label lDeliveryDate;
        internal Label lShipdate;
        internal Label lPickUpDate;
        internal Label label18;
        internal Label label21;
        internal Label label22;
        Signature.Windows.Forms.GroupBox gbBrochures;
        private Signature.Windows.Forms.MaskedEditNumeric txtSalesTax;
        internal Label label26;
        private Infragistics.Win.Misc.UltraLabel ctrPrizeName;
        private Infragistics.Win.Misc.UltraLabel ctrBrochureName;
        private Infragistics.Win.Misc.UltraLabel ctrRepName;
        private Signature.Windows.Forms.MaskedEdit txtPrizeID;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID;
        private Signature.Windows.Forms.MaskedEditNumeric txtCODE1;
        private Signature.Windows.Forms.MaskedEditNumeric txtSigned;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfitPercent;
        internal Label label23;
        internal Label lPrize;
        internal Label label3;
        internal Label label41;
        internal Label lBrochure_1;
        internal Label label44;
        private Signature.Windows.Forms.GroupBox gbChairperson;
        private Signature.Windows.Forms.MaskedEditNumeric txtPhoneNumber;
        private Signature.Windows.Forms.MaskedEdit txteMail;
        private Signature.Windows.Forms.MaskedEdit txtChairperson;
        internal Label label2;
        internal Label Label5;
        internal Label Label20;
        private Signature.Windows.Forms.GroupBox gbGeneralInfoGroup;
        private Signature.Windows.Forms.MaskedEditNumeric txtFax;
        private Signature.Windows.Forms.MaskedEditNumeric txtHeadPhone;
        private Signature.Windows.Forms.MaskedEditNumeric txtZipCode;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.MaskedEdit txtState;
        private Signature.Windows.Forms.MaskedEdit txtCity;
        private Signature.Windows.Forms.MaskedEdit txtAddress;
        private Signature.Windows.Forms.MaskedEdit txtName;
        internal Label Label8;
        internal Label Label7;
        internal Label Label15;
        internal Label Label17;
        internal Label Label6;
        internal Label Label35;
        internal Label Label16;
        internal Label Label19;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID_2;
        internal Label lBrochure2;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfitPercent_2;
        internal Label label33;
        private Signature.Windows.Forms.MaskedEditNumeric txtCODE2;
        internal Label label36;
        private ComboBox cShipVia;
        private Label label40;
        private Infragistics.Win.Misc.UltraLabel ctrBrochureName_2;
        internal Label label37;
        private Signature.Windows.Forms.MaskedEdit txtSignedNote;
        internal Label lCounty;
        private Signature.Windows.Forms.MaskedEditNumeric txtHeadPhoneExt;
        internal Label lPhone;
        private Signature.Windows.Forms.MaskedEditNumeric txtFaxExt;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtLetterAproval;
        private Signature.Windows.Forms.MaskedEditNumeric txtPhoneNumberExt;
        internal Label lHeadPhone;
        private TabPage tabPage4;
        internal Label label25;
        internal Label label39;
        internal Label label11;
        internal Label label10;
        internal Label label9;
        internal Label label4;
        internal Label label12;
        private Signature.Windows.Forms.GroupBox gCurrentStatus;
        internal Label lTax;
        internal Label lRetail;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfit;
        internal Label lProfit;
        private Signature.Windows.Forms.MaskedEditNumeric txtInvoiced;
        internal Label lInvoiced;
        private Signature.Windows.Forms.MaskedEditNumeric txtPrevRetail;
        internal Label label49;
        internal Label lPPickupDate;
        private Signature.Windows.Forms.MaskedEdit txtParentPickUpNote;
        private Signature.Windows.Forms.MaskedEdit txtDeliveryNote;
        private Signature.Windows.Forms.MaskedEdit txtShipNote;
        private Signature.Windows.Forms.MaskedEdit txtPickUpNote;
        private Signature.Windows.Forms.MaskedEdit txtEndNote;
        private Signature.Windows.Forms.MaskedEdit txtStartNote;
        private Signature.Windows.Forms.CalendarBox txtSignedDate;
        private Signature.Windows.Forms.CalendarBox txtStartDate;
        private Signature.Windows.Forms.CalendarBox txtPPickupDate;
        private Signature.Windows.Forms.CalendarBox txtDeliveryDate;
        private Signature.Windows.Forms.CalendarBox txtShipDate;
        private Signature.Windows.Forms.CalendarBox txtPickUpDate;
        private Signature.Windows.Forms.CalendarBox txtEndDate;
        internal Label lCollectTax;
        private Signature.Windows.Forms.ComboBox txtCollectTax;
        internal Label label55;
        private Signature.Windows.Forms.ComboBox txtApplyTax;
        private Signature.Windows.Forms.MaskedEdit txtGrid;
        internal Label lGrid;
        private Signature.Windows.Forms.MaskedEdit txtPage;
        internal Label lPage;
        private Signature.Windows.Forms.MaskedEditNumeric txtPayments;
        private Signature.Windows.Forms.MaskedEditNumeric txtAmountDue;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoItems;
        internal Label lAmountDue;
        internal Label lItems;
        internal Label lPayments;
        internal Label lLastInvoice;
        private Signature.Windows.Forms.Button btRefresh;
        private Signature.Windows.Forms.MaskedEditNumeric txtLastInvoiced;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.MaskedEditNumeric txtAdded;
        internal Label lAdded;
        private Signature.Windows.Forms.GroupBox ultraGroupBox6;
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;
        private Signature.Windows.Forms.MaskedEditNumeric txtDiscDate;
        internal Label lDiscrepancyDate;
        private Signature.Windows.Forms.MaskedEditNumeric txtNumberPallets;
        internal Label lNumberPallets;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoSellers;
        internal Label lSellers;
        private Signature.Windows.Forms.MaskedEditNumeric txtCharges;
        internal Label lCharges;
        private Signature.Windows.Forms.GroupBox gbShippingOptions;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet OpShipOption;
        private Signature.Windows.Forms.MaskedEditNumeric txtBOLTraking;
        internal Label lBOL;
        private Signature.Windows.Forms.Button ultraButton1;
        internal Label lPostPay;
        private Signature.Windows.Forms.MaskedEdit txtPayableTo;
        internal Label lbPayableTo;
        private CheckBox txtPostPay;
        private Signature.Windows.Forms.CalendarBox txtDatePayable;
        internal Label lbDatePayable;
        private Signature.Windows.Forms.GroupBox gbLetterAproval;
        private Signature.Windows.Forms.CalendarBox txtDateDeadLine;
        internal Label label61;
        private Signature.Windows.Forms.Button button2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtSchoolUseOnly;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbChecked;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbPrinted;
        private Signature.Windows.Forms.GroupBox gbGAOptions;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbOneDaySale;
        private Signature.Windows.Forms.MaskedEditNumeric txtCashRegisters;
        internal Label label1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbAssigned;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbTreasureChest;
        private Signature.Windows.Forms.GroupBox gbGiftAvenue;
        private Signature.Windows.Forms.MaskedEditNumeric txtSFull;
        internal Label lbS2Full;
        private Signature.Windows.Forms.MaskedEditNumeric txtLETX;
        internal Label label42;
        private Signature.Windows.Forms.MaskedEditNumeric txtLE5;
        internal Label lbLE5;
        private Signature.Windows.Forms.MaskedEditNumeric txtLE4;
        internal Label lbLE4;
        private Signature.Windows.Forms.MaskedEditNumeric txtLE3;
        internal Label lbLE3;
        private Signature.Windows.Forms.MaskedEditNumeric txtLE2;
        internal Label lbLE2;
        private Signature.Windows.Forms.MaskedEditNumeric txtLE1;
        internal Label label29;
        private Signature.Windows.Forms.MaskedEditNumeric txtTBin;
        internal Label lbTBin;
        private Signature.Windows.Forms.MaskedEditNumeric txtSLow;
        internal Label lbS2Low;
        private Signature.Windows.Forms.MaskedEditNumeric txtSHalf;
        internal Label lbS2Half;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor bKitAssigned;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbProductOrdered;
        private Signature.Windows.Forms.MaskedEditNumeric txtDS;
        internal Label lbDS;
        private Infragistics.Win.Misc.UltraLabel ctrBrochureName_3;
        private Signature.Windows.Forms.MaskedEditNumeric txtCODE3;
        internal Label lCode_3;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfitPercent_3;
        internal Label lProfit_3;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID_3;
        internal Label lBrochure_3;
        private ToolStrip tStrip;
        private ToolStripButton toolPrint;
        private ToolStripButton toolPrintSheet;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolOrder;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolPayments;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbProductReturned;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbRegisterReturned;
        private Signature.Windows.Forms.CalendarBox txtProductReturnedDate;
        private Signature.Windows.Forms.MaskedEditNumeric txtBoxes;
        internal Label lBoxes;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbWDS;
        private TabPage tabPage5;
        private Signature.Windows.Forms.MaskedEdit txtText;
        private Signature.Windows.Forms.MaskedEditNumeric txtRepID;
        private Signature.Windows.Forms.GlassButton b_SaveNote;
        private Signature.Windows.Forms.MaskedEditNumeric txtGoal;
        internal Label labGoal;
        private Signature.Windows.Forms.ComboBox txtCounty;
        private Signature.Windows.Forms.MaskedEditNumeric txtFormerLastInvoicedAmount;
        internal Label lFormerLastInvoicedAmount;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbEnrollmentForm;
        private Signature.Windows.Forms.MaskedEditNumeric txtMUG;
        internal Label lMUG;
        private Signature.Windows.Forms.MaskedEditNumeric txtBBS;
        internal Label lbBBS;
        private Signature.Windows.Forms.MaskedEditNumeric txtBBL;
        internal Label lbBBL;
        private Signature.Windows.Forms.MaskedEditNumeric txtS1Half;
        internal Label lbS1Half;
        private Signature.Windows.Forms.MaskedEditNumeric txtS1Full;
        internal Label lbS1Full;
        private Signature.Windows.Forms.MaskedEditNumeric txtLEMUG;
        internal Label lbLEMOG;
        private Signature.Windows.Forms.MaskedEditNumeric txtPROREG;
        internal Label lbPROREG;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cb20062008;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtPineValley;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton toolPreInvoice;
        private ToolStripMenuItem sendToPrinterToolStripMenuItem;
        private ToolStripMenuItem sendByEmailPDFToolStripMenuItem;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtOld;
        private Signature.Windows.Forms.MaskedEdit txtEmailSecondary;
        internal Label label51;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtShowXBash;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtSignedYN;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtChecked;
        private Signature.Windows.Forms.MaskedEditNumeric txtBoxCount;
        internal Label label52;
        private ToolStripButton ParentLetterPDF;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtCompleted;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtReceivedOrders;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtProfitChanged;
        private Signature.Windows.Forms.MaskedEditNumeric txtOverage;
        internal Label lblOverage;
        private Signature.Windows.Forms.GroupBox gbBOLTracking;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbProductShipped;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbPromoShipped;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbGrouped;
        private Signature.Windows.Forms.MaskedEditNumeric txtLKit1;
        internal Label label53;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbAMDelivery;
        private Signature.Windows.Forms.MaskedEditNumeric txtTax;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbKastleKreation;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbBlueDogContract;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbBlueDog;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbKK;
		#endregion


        Customer             oCustomer;
        Rep                  oRep;
        Voicemail            oVoicemail;
        Brochure             oBrochure;
        ParseWordDocument    oDoc;
        Prize                oPrize;
        frmInventoryRealTime frmInventory;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tPackingSlip;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbCoupon;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tProductSlip;
        private Infragistics.Win.Misc.UltraLabel ctrBrochureName_4;
        private Signature.Windows.Forms.MaskedEditNumeric txtCODE4;
        internal Label label13;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfitPercent_4;
        internal Label label14;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID_4;
        internal Label label24;
        
        
        
        
        Timer SystemTimer;

        
		public frmCustomer()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            oCustomer = new Customer(base.CompanyID);

            this.Text   += " - " + oCustomer.CompanyID;
            oRep        = new Rep(oCustomer.CompanyID);
            oVoicemail  = new Voicemail(oCustomer.CompanyID);
            oBrochure   = new Brochure(oCustomer.CompanyID);
            oPrize      = new Prize(oCustomer.CompanyID);
            txtCustomerID.Focus();

            SystemTimer = new Timer();
            SystemTimer.Interval =30000;
          //  SystemTimer.Tick += new EventHandler(SystemTimer_Tick);
          //  SystemTimer.Start();

   
        }  //Constructor

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BrochureID", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProfitPercent", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CODE", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Retail", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoSellers", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoItems", 6);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProfitAmount", 7);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InvoiceAmount", 8);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaxAmount", 9);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CompanyID", 10);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CustomerID", 11);
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Date", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount", 1);
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OrderID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Teacher", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Student", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Retail", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NumberItems", 3);
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.tCustomer = new Signature.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.gbGiftAvenue = new Signature.Windows.Forms.GroupBox();
            this.txtLKit1 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label53 = new System.Windows.Forms.Label();
            this.cbPromoShipped = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbProductShipped = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtPROREG = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbPROREG = new System.Windows.Forms.Label();
            this.txtLEMUG = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbLEMOG = new System.Windows.Forms.Label();
            this.txtMUG = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lMUG = new System.Windows.Forms.Label();
            this.txtBBS = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbBBS = new System.Windows.Forms.Label();
            this.txtBBL = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbBBL = new System.Windows.Forms.Label();
            this.txtS1Half = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbS1Half = new System.Windows.Forms.Label();
            this.txtS1Full = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbS1Full = new System.Windows.Forms.Label();
            this.txtBoxes = new Signature.Windows.Forms.MaskedEditNumeric();
            this.cbWDS = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lBoxes = new System.Windows.Forms.Label();
            this.txtDS = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtProductReturnedDate = new Signature.Windows.Forms.CalendarBox();
            this.cbRegisterReturned = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lbDS = new System.Windows.Forms.Label();
            this.cbProductOrdered = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbProductReturned = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbChecked = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.bKitAssigned = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtLETX = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label42 = new System.Windows.Forms.Label();
            this.txtLE5 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbLE5 = new System.Windows.Forms.Label();
            this.txtLE4 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbLE4 = new System.Windows.Forms.Label();
            this.txtLE3 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbLE3 = new System.Windows.Forms.Label();
            this.txtLE2 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbLE2 = new System.Windows.Forms.Label();
            this.txtLE1 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label29 = new System.Windows.Forms.Label();
            this.txtTBin = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbTBin = new System.Windows.Forms.Label();
            this.txtSLow = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbS2Low = new System.Windows.Forms.Label();
            this.txtSHalf = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbS2Half = new System.Windows.Forms.Label();
            this.txtSFull = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbS2Full = new System.Windows.Forms.Label();
            this.gbBOLTracking = new Signature.Windows.Forms.GroupBox();
            this.txtBOLTraking = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lBOL = new System.Windows.Forms.Label();
            this.ultraButton1 = new Signature.Windows.Forms.Button();
            this.gbGAOptions = new Signature.Windows.Forms.GroupBox();
            this.cbCoupon = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbTreasureChest = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbAssigned = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbOneDaySale = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtCashRegisters = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLetterAproval = new Signature.Windows.Forms.GroupBox();
            this.cbKastleKreation = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.button2 = new Signature.Windows.Forms.Button();
            this.txtDateDeadLine = new Signature.Windows.Forms.CalendarBox();
            this.label61 = new System.Windows.Forms.Label();
            this.gCurrentStatus = new Signature.Windows.Forms.GroupBox();
            this.cbBlueDogContract = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbBlueDog = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtTax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.cbGrouped = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtOverage = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lblOverage = new System.Windows.Forms.Label();
            this.txtProfitChanged = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtReceivedOrders = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtCompleted = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtBoxCount = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label52 = new System.Windows.Forms.Label();
            this.txtChecked = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtSignedYN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtShowXBash = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtOld = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtPineValley = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cb20062008 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbEnrollmentForm = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtFormerLastInvoicedAmount = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lFormerLastInvoicedAmount = new System.Windows.Forms.Label();
            this.cbPrinted = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtSchoolUseOnly = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtCharges = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lCharges = new System.Windows.Forms.Label();
            this.txtDiscDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lDiscrepancyDate = new System.Windows.Forms.Label();
            this.txtNumberPallets = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lNumberPallets = new System.Windows.Forms.Label();
            this.txtNoSellers = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lSellers = new System.Windows.Forms.Label();
            this.txtLastInvoiced = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtAdded = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lAdded = new System.Windows.Forms.Label();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtLetterAproval = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lTax = new System.Windows.Forms.Label();
            this.txtAmountDue = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lLastInvoice = new System.Windows.Forms.Label();
            this.txtPayments = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lRetail = new System.Windows.Forms.Label();
            this.txtProfit = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lAmountDue = new System.Windows.Forms.Label();
            this.txtNoItems = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lProfit = new System.Windows.Forms.Label();
            this.txtInvoiced = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lPayments = new System.Windows.Forms.Label();
            this.lItems = new System.Windows.Forms.Label();
            this.lInvoiced = new System.Windows.Forms.Label();
            this.gbGeneralInfoGroup = new Signature.Windows.Forms.GroupBox();
            this.txtCounty = new Signature.Windows.Forms.ComboBox();
            this.txtGoal = new Signature.Windows.Forms.MaskedEditNumeric();
            this.labGoal = new System.Windows.Forms.Label();
            this.txtRepID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbDatePayable = new System.Windows.Forms.Label();
            this.txtPayableTo = new Signature.Windows.Forms.MaskedEdit();
            this.lbPayableTo = new System.Windows.Forms.Label();
            this.txtPostPay = new System.Windows.Forms.CheckBox();
            this.lPostPay = new System.Windows.Forms.Label();
            this.txtGrid = new Signature.Windows.Forms.MaskedEdit();
            this.lGrid = new System.Windows.Forms.Label();
            this.txtPage = new Signature.Windows.Forms.MaskedEdit();
            this.lPage = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.txtApplyTax = new Signature.Windows.Forms.ComboBox();
            this.lCollectTax = new System.Windows.Forms.Label();
            this.txtCollectTax = new Signature.Windows.Forms.ComboBox();
            this.txtPrevRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label49 = new System.Windows.Forms.Label();
            this.txtHeadPhoneExt = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lPhone = new System.Windows.Forms.Label();
            this.lCounty = new System.Windows.Forms.Label();
            this.txtFax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtHeadPhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.ctrRepName = new Infragistics.Win.Misc.UltraLabel();
            this.txtZipCode = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtState = new Signature.Windows.Forms.MaskedEdit();
            this.txtCity = new Signature.Windows.Forms.MaskedEdit();
            this.txtAddress = new Signature.Windows.Forms.MaskedEdit();
            this.txtName = new Signature.Windows.Forms.MaskedEdit();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtSalesTax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label26 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtSigned = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDatePayable = new Signature.Windows.Forms.CalendarBox();
            this.txtFaxExt = new Signature.Windows.Forms.MaskedEditNumeric();
            this.gbChairperson = new Signature.Windows.Forms.GroupBox();
            this.txtEmailSecondary = new Signature.Windows.Forms.MaskedEdit();
            this.label51 = new System.Windows.Forms.Label();
            this.txtPhoneNumberExt = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lHeadPhone = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txteMail = new Signature.Windows.Forms.MaskedEdit();
            this.txtChairperson = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.gbBrochures = new Signature.Windows.Forms.GroupBox();
            this.ctrBrochureName_4 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCODE4 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProfitPercent_4 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBrochureID_4 = new Signature.Windows.Forms.MaskedEdit();
            this.label24 = new System.Windows.Forms.Label();
            this.ctrBrochureName_3 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCODE3 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lCode_3 = new System.Windows.Forms.Label();
            this.txtProfitPercent_3 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lProfit_3 = new System.Windows.Forms.Label();
            this.txtBrochureID_3 = new Signature.Windows.Forms.MaskedEdit();
            this.lBrochure_3 = new System.Windows.Forms.Label();
            this.ctrBrochureName_2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCODE2 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label36 = new System.Windows.Forms.Label();
            this.txtProfitPercent_2 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label33 = new System.Windows.Forms.Label();
            this.txtBrochureID_2 = new Signature.Windows.Forms.MaskedEdit();
            this.lBrochure2 = new System.Windows.Forms.Label();
            this.ctrBrochureName = new Infragistics.Win.Misc.UltraLabel();
            this.txtBrochureID = new Signature.Windows.Forms.MaskedEdit();
            this.txtCODE1 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtProfitPercent = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.ctrPrizeName = new Infragistics.Win.Misc.UltraLabel();
            this.lBrochure_1 = new System.Windows.Forms.Label();
            this.lPrize = new System.Windows.Forms.Label();
            this.txtPrizeID = new Signature.Windows.Forms.MaskedEdit();
            this.gbDates = new Signature.Windows.Forms.GroupBox();
            this.txtEndDate = new Signature.Windows.Forms.CalendarBox();
            this.txtPPickupDate = new Signature.Windows.Forms.CalendarBox();
            this.txtDeliveryDate = new Signature.Windows.Forms.CalendarBox();
            this.txtShipDate = new Signature.Windows.Forms.CalendarBox();
            this.txtPickUpDate = new Signature.Windows.Forms.CalendarBox();
            this.txtStartDate = new Signature.Windows.Forms.CalendarBox();
            this.txtSignedDate = new Signature.Windows.Forms.CalendarBox();
            this.txtParentPickUpNote = new Signature.Windows.Forms.MaskedEdit();
            this.txtDeliveryNote = new Signature.Windows.Forms.MaskedEdit();
            this.txtShipNote = new Signature.Windows.Forms.MaskedEdit();
            this.txtPickUpNote = new Signature.Windows.Forms.MaskedEdit();
            this.txtEndNote = new Signature.Windows.Forms.MaskedEdit();
            this.txtStartNote = new Signature.Windows.Forms.MaskedEdit();
            this.lPPickupDate = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.cShipVia = new System.Windows.Forms.ComboBox();
            this.txtSignedNote = new Signature.Windows.Forms.MaskedEdit();
            this.label40 = new System.Windows.Forms.Label();
            this.lDeliveryDate = new System.Windows.Forms.Label();
            this.lShipdate = new System.Windows.Forms.Label();
            this.lPickUpDate = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.gbShippingOptions = new Signature.Windows.Forms.GroupBox();
            this.cbKK = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cbAMDelivery = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.OpShipOption = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.btRefresh = new Signature.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ultraGroupBox6 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.RGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.OrdersGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.b_SaveNote = new Signature.Windows.Forms.GlassButton();
            this.txtText = new Signature.Windows.Forms.MaskedEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new Signature.Windows.Forms.ComboBox();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolPrintSheet = new System.Windows.Forms.ToolStripButton();
            this.toolPayments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPreInvoice = new System.Windows.Forms.ToolStripSplitButton();
            this.sendToPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendByEmailPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParentLetterPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tPackingSlip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tProductSlip = new System.Windows.Forms.ToolStripButton();
            this.tCustomer.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGiftAvenue)).BeginInit();
            this.gbGiftAvenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductReturnedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbBOLTracking)).BeginInit();
            this.gbBOLTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGAOptions)).BeginInit();
            this.gbGAOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLetterAproval)).BeginInit();
            this.gbLetterAproval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDeadLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCurrentStatus)).BeginInit();
            this.gCurrentStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGeneralInfoGroup)).BeginInit();
            this.gbGeneralInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatePayable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbChairperson)).BeginInit();
            this.gbChairperson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBrochures)).BeginInit();
            this.gbBrochures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDates)).BeginInit();
            this.gbDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPickupDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbShippingOptions)).BeginInit();
            this.gbShippingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpShipOption)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGrid)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGrid)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 876);
            this.txtStatus.Size = new System.Drawing.Size(968, 29);
            // 
            // tCustomer
            // 
            this.tCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tCustomer.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tCustomer.Controls.Add(this.TabPage1);
            this.tCustomer.Controls.Add(this.tabPage4);
            this.tCustomer.Controls.Add(this.TabPage2);
            this.tCustomer.Controls.Add(this.TabPage3);
            this.tCustomer.Controls.Add(this.tabPage5);
            this.tCustomer.ItemSize = new System.Drawing.Size(0, 15);
            this.tCustomer.Location = new System.Drawing.Point(7, 36);
            this.tCustomer.Name = "tCustomer";
            this.tCustomer.SelectedIndex = 0;
            this.tCustomer.Size = new System.Drawing.Size(947, 834);
            this.tCustomer.TabIndex = 0;
            this.tCustomer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tCustomer_Selected);
            this.tCustomer.Enter += new System.EventHandler(this.tCustomer_Enter);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.Color.Transparent;
            this.TabPage1.Controls.Add(this.gbGiftAvenue);
            this.TabPage1.Controls.Add(this.gbBOLTracking);
            this.TabPage1.Controls.Add(this.gbGAOptions);
            this.TabPage1.Controls.Add(this.gbLetterAproval);
            this.TabPage1.Controls.Add(this.gCurrentStatus);
            this.TabPage1.Controls.Add(this.gbGeneralInfoGroup);
            this.TabPage1.Controls.Add(this.gbChairperson);
            this.TabPage1.Controls.Add(this.gbBrochures);
            this.TabPage1.Controls.Add(this.gbDates);
            this.TabPage1.Controls.Add(this.gbShippingOptions);
            this.TabPage1.Controls.Add(this.btRefresh);
            this.TabPage1.ForeColor = System.Drawing.Color.Black;
            this.TabPage1.ImageKey = "(none)";
            this.TabPage1.Location = new System.Drawing.Point(4, 19);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(939, 811);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "General Information";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // gbGiftAvenue
            // 
            this.gbGiftAvenue.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.gbGiftAvenue.Appearance = appearance1;
            this.gbGiftAvenue.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbGiftAvenue.Controls.Add(this.txtLKit1);
            this.gbGiftAvenue.Controls.Add(this.label53);
            this.gbGiftAvenue.Controls.Add(this.cbPromoShipped);
            this.gbGiftAvenue.Controls.Add(this.cbProductShipped);
            this.gbGiftAvenue.Controls.Add(this.txtPROREG);
            this.gbGiftAvenue.Controls.Add(this.lbPROREG);
            this.gbGiftAvenue.Controls.Add(this.txtLEMUG);
            this.gbGiftAvenue.Controls.Add(this.lbLEMOG);
            this.gbGiftAvenue.Controls.Add(this.txtMUG);
            this.gbGiftAvenue.Controls.Add(this.lMUG);
            this.gbGiftAvenue.Controls.Add(this.txtBBS);
            this.gbGiftAvenue.Controls.Add(this.lbBBS);
            this.gbGiftAvenue.Controls.Add(this.txtBBL);
            this.gbGiftAvenue.Controls.Add(this.lbBBL);
            this.gbGiftAvenue.Controls.Add(this.txtS1Half);
            this.gbGiftAvenue.Controls.Add(this.lbS1Half);
            this.gbGiftAvenue.Controls.Add(this.txtS1Full);
            this.gbGiftAvenue.Controls.Add(this.lbS1Full);
            this.gbGiftAvenue.Controls.Add(this.txtBoxes);
            this.gbGiftAvenue.Controls.Add(this.cbWDS);
            this.gbGiftAvenue.Controls.Add(this.lBoxes);
            this.gbGiftAvenue.Controls.Add(this.txtDS);
            this.gbGiftAvenue.Controls.Add(this.txtProductReturnedDate);
            this.gbGiftAvenue.Controls.Add(this.cbRegisterReturned);
            this.gbGiftAvenue.Controls.Add(this.lbDS);
            this.gbGiftAvenue.Controls.Add(this.cbProductOrdered);
            this.gbGiftAvenue.Controls.Add(this.cbProductReturned);
            this.gbGiftAvenue.Controls.Add(this.cbChecked);
            this.gbGiftAvenue.Controls.Add(this.bKitAssigned);
            this.gbGiftAvenue.Controls.Add(this.txtLETX);
            this.gbGiftAvenue.Controls.Add(this.label42);
            this.gbGiftAvenue.Controls.Add(this.txtLE5);
            this.gbGiftAvenue.Controls.Add(this.lbLE5);
            this.gbGiftAvenue.Controls.Add(this.txtLE4);
            this.gbGiftAvenue.Controls.Add(this.lbLE4);
            this.gbGiftAvenue.Controls.Add(this.txtLE3);
            this.gbGiftAvenue.Controls.Add(this.lbLE3);
            this.gbGiftAvenue.Controls.Add(this.txtLE2);
            this.gbGiftAvenue.Controls.Add(this.lbLE2);
            this.gbGiftAvenue.Controls.Add(this.txtLE1);
            this.gbGiftAvenue.Controls.Add(this.label29);
            this.gbGiftAvenue.Controls.Add(this.txtTBin);
            this.gbGiftAvenue.Controls.Add(this.lbTBin);
            this.gbGiftAvenue.Controls.Add(this.txtSLow);
            this.gbGiftAvenue.Controls.Add(this.lbS2Low);
            this.gbGiftAvenue.Controls.Add(this.txtSHalf);
            this.gbGiftAvenue.Controls.Add(this.lbS2Half);
            this.gbGiftAvenue.Controls.Add(this.txtSFull);
            this.gbGiftAvenue.Controls.Add(this.lbS2Full);
            this.gbGiftAvenue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbGiftAvenue.Location = new System.Drawing.Point(8, 676);
            this.gbGiftAvenue.Name = "gbShippingOptions";
            this.gbGiftAvenue.Size = new System.Drawing.Size(685, 180);
            this.gbGiftAvenue.TabIndex = 11;
            this.gbGiftAvenue.Text = "Gift Avenue";
            this.gbGiftAvenue.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtLKit1
            // 
            this.txtLKit1.AllowDrop = true;
            appearance3.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLKit1.Appearance = appearance3;
            this.txtLKit1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLKit1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLKit1.InputMask = "nn";
            this.txtLKit1.Location = new System.Drawing.Point(296, 51);
            this.txtLKit1.Name = "txtZipCode";
            this.txtLKit1.PromptChar = ' ';
            this.txtLKit1.Size = new System.Drawing.Size(39, 20);
            this.txtLKit1.TabIndex = 252;
            this.txtLKit1.Text = "0";
            this.txtLKit1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(229, 53);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(63, 18);
            this.label53.TabIndex = 251;
            this.label53.Text = "LKit 1:";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPromoShipped
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BackColor2 = System.Drawing.Color.Transparent;
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.White;
            this.cbPromoShipped.Appearance = appearance4;
            this.cbPromoShipped.BackColor = System.Drawing.Color.Transparent;
            this.cbPromoShipped.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbPromoShipped.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPromoShipped.Location = new System.Drawing.Point(21, 146);
            this.cbPromoShipped.Name = "cbPromoShipped";
            this.cbPromoShipped.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbPromoShipped.Size = new System.Drawing.Size(112, 19);
            this.cbPromoShipped.TabIndex = 38;
            this.cbPromoShipped.Text = "Promo Shipped";
            this.cbPromoShipped.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbProductShipped
            // 
            appearance111.BackColor = System.Drawing.Color.Transparent;
            appearance111.BackColor2 = System.Drawing.Color.Transparent;
            appearance111.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance111.ForeColor = System.Drawing.Color.Black;
            appearance111.ForeColorDisabled = System.Drawing.Color.White;
            this.cbProductShipped.Appearance = appearance111;
            this.cbProductShipped.BackColor = System.Drawing.Color.Transparent;
            this.cbProductShipped.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbProductShipped.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbProductShipped.Location = new System.Drawing.Point(22, 127);
            this.cbProductShipped.Name = "cbProductShipped";
            this.cbProductShipped.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbProductShipped.Size = new System.Drawing.Size(112, 19);
            this.cbProductShipped.TabIndex = 37;
            this.cbProductShipped.Text = "Product Shipped";
            this.cbProductShipped.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPROREG
            // 
            this.txtPROREG.AllowDrop = true;
            appearance6.ForeColorDisabled = System.Drawing.Color.White;
            this.txtPROREG.Appearance = appearance6;
            this.txtPROREG.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPROREG.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPROREG.InputMask = "nn";
            this.txtPROREG.Location = new System.Drawing.Point(633, 107);
            this.txtPROREG.Name = "txtZipCode";
            this.txtPROREG.PromptChar = ' ';
            this.txtPROREG.Size = new System.Drawing.Size(39, 20);
            this.txtPROREG.TabIndex = 36;
            this.txtPROREG.Text = "0";
            this.txtPROREG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbPROREG
            // 
            this.lbPROREG.BackColor = System.Drawing.Color.Transparent;
            this.lbPROREG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPROREG.Location = new System.Drawing.Point(574, 107);
            this.lbPROREG.Name = "lbPROREG";
            this.lbPROREG.Size = new System.Drawing.Size(55, 18);
            this.lbPROREG.TabIndex = 35;
            this.lbPROREG.Text = "PROREG:";
            this.lbPROREG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLEMUG
            // 
            this.txtLEMUG.AllowDrop = true;
            appearance92.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLEMUG.Appearance = appearance92;
            this.txtLEMUG.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLEMUG.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLEMUG.InputMask = "nn";
            this.txtLEMUG.Location = new System.Drawing.Point(518, 77);
            this.txtLEMUG.Name = "txtZipCode";
            this.txtLEMUG.PromptChar = ' ';
            this.txtLEMUG.Size = new System.Drawing.Size(39, 20);
            this.txtLEMUG.TabIndex = 34;
            this.txtLEMUG.Text = "0";
            this.txtLEMUG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbLEMOG
            // 
            this.lbLEMOG.BackColor = System.Drawing.Color.Transparent;
            this.lbLEMOG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLEMOG.Location = new System.Drawing.Point(435, 77);
            this.lbLEMOG.Name = "lbLEMOG";
            this.lbLEMOG.Size = new System.Drawing.Size(79, 18);
            this.lbLEMOG.TabIndex = 33;
            this.lbLEMOG.Text = "LE MUG:";
            this.lbLEMOG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMUG
            // 
            this.txtMUG.AllowDrop = true;
            appearance97.ForeColorDisabled = System.Drawing.Color.White;
            this.txtMUG.Appearance = appearance97;
            this.txtMUG.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtMUG.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtMUG.InputMask = "nn";
            this.txtMUG.Location = new System.Drawing.Point(633, 77);
            this.txtMUG.Name = "txtZipCode";
            this.txtMUG.PromptChar = ' ';
            this.txtMUG.Size = new System.Drawing.Size(39, 20);
            this.txtMUG.TabIndex = 30;
            this.txtMUG.Text = "0";
            this.txtMUG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lMUG
            // 
            this.lMUG.BackColor = System.Drawing.Color.Transparent;
            this.lMUG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMUG.Location = new System.Drawing.Point(563, 77);
            this.lMUG.Name = "lMUG";
            this.lMUG.Size = new System.Drawing.Size(66, 18);
            this.lMUG.TabIndex = 28;
            this.lMUG.Text = "MUG:";
            this.lMUG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBBS
            // 
            this.txtBBS.AllowDrop = true;
            appearance7.ForeColorDisabled = System.Drawing.Color.White;
            this.txtBBS.Appearance = appearance7;
            this.txtBBS.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBBS.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBBS.InputMask = "nn";
            this.txtBBS.Location = new System.Drawing.Point(633, 51);
            this.txtBBS.Name = "txtZipCode";
            this.txtBBS.PromptChar = ' ';
            this.txtBBS.Size = new System.Drawing.Size(39, 20);
            this.txtBBS.TabIndex = 32;
            this.txtBBS.Text = "0";
            this.txtBBS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbBBS
            // 
            this.lbBBS.BackColor = System.Drawing.Color.Transparent;
            this.lbBBS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBBS.Location = new System.Drawing.Point(563, 51);
            this.lbBBS.Name = "lbBBS";
            this.lbBBS.Size = new System.Drawing.Size(66, 18);
            this.lbBBS.TabIndex = 27;
            this.lbBBS.Text = "BBS :";
            this.lbBBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBBL
            // 
            this.txtBBL.AllowDrop = true;
            appearance8.ForeColorDisabled = System.Drawing.Color.White;
            this.txtBBL.Appearance = appearance8;
            this.txtBBL.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBBL.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBBL.InputMask = "nn";
            this.txtBBL.Location = new System.Drawing.Point(633, 25);
            this.txtBBL.Name = "txtZipCode";
            this.txtBBL.PromptChar = ' ';
            this.txtBBL.Size = new System.Drawing.Size(39, 20);
            this.txtBBL.TabIndex = 31;
            this.txtBBL.Text = "0";
            this.txtBBL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbBBL
            // 
            this.lbBBL.BackColor = System.Drawing.Color.Transparent;
            this.lbBBL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBBL.Location = new System.Drawing.Point(562, 25);
            this.lbBBL.Name = "lbBBL";
            this.lbBBL.Size = new System.Drawing.Size(67, 18);
            this.lbBBL.TabIndex = 29;
            this.lbBBL.Text = "BBL:";
            this.lbBBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtS1Half
            // 
            this.txtS1Half.AllowDrop = true;
            appearance14.ForeColorDisabled = System.Drawing.Color.White;
            this.txtS1Half.Appearance = appearance14;
            this.txtS1Half.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtS1Half.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtS1Half.InputMask = "nn";
            this.txtS1Half.Location = new System.Drawing.Point(181, 53);
            this.txtS1Half.Name = "txtZipCode";
            this.txtS1Half.PromptChar = ' ';
            this.txtS1Half.Size = new System.Drawing.Size(39, 20);
            this.txtS1Half.TabIndex = 26;
            this.txtS1Half.Text = "0";
            this.txtS1Half.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbS1Half
            // 
            this.lbS1Half.BackColor = System.Drawing.Color.Transparent;
            this.lbS1Half.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS1Half.Location = new System.Drawing.Point(110, 53);
            this.lbS1Half.Name = "lbS1Half";
            this.lbS1Half.Size = new System.Drawing.Size(67, 18);
            this.lbS1Half.TabIndex = 25;
            this.lbS1Half.Text = "S1 Half:";
            this.lbS1Half.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtS1Full
            // 
            this.txtS1Full.AllowDrop = true;
            appearance15.ForeColorDisabled = System.Drawing.Color.White;
            this.txtS1Full.Appearance = appearance15;
            this.txtS1Full.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtS1Full.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtS1Full.InputMask = "nn";
            this.txtS1Full.Location = new System.Drawing.Point(181, 27);
            this.txtS1Full.Name = "txtZipCode";
            this.txtS1Full.PromptChar = ' ';
            this.txtS1Full.Size = new System.Drawing.Size(39, 20);
            this.txtS1Full.TabIndex = 24;
            this.txtS1Full.Text = "0";
            this.txtS1Full.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbS1Full
            // 
            this.lbS1Full.BackColor = System.Drawing.Color.Transparent;
            this.lbS1Full.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS1Full.Location = new System.Drawing.Point(110, 27);
            this.lbS1Full.Name = "lbS1Full";
            this.lbS1Full.Size = new System.Drawing.Size(67, 18);
            this.lbS1Full.TabIndex = 23;
            this.lbS1Full.Text = "S1 Full:";
            this.lbS1Full.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxes
            // 
            this.txtBoxes.AllowDrop = true;
            appearance23.TextHAlignAsString = "Right";
            this.txtBoxes.Appearance = appearance23;
            this.txtBoxes.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBoxes.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBoxes.FormatString = "###,###.##";
            this.txtBoxes.InputMask = "nn,nnn,nnn";
            this.txtBoxes.Location = new System.Drawing.Point(486, 145);
            this.txtBoxes.Name = "txtNoItems";
            this.txtBoxes.Size = new System.Drawing.Size(45, 20);
            this.txtBoxes.TabIndex = 249;
            this.txtBoxes.Text = "0";
            this.txtBoxes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbWDS
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.White;
            this.cbWDS.Appearance = appearance2;
            this.cbWDS.BackColor = System.Drawing.Color.Transparent;
            this.cbWDS.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbWDS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbWDS.Location = new System.Drawing.Point(249, 82);
            this.cbWDS.Name = "cbWDS";
            this.cbWDS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbWDS.Size = new System.Drawing.Size(80, 19);
            this.cbWDS.TabIndex = 22;
            this.cbWDS.Text = "WDS:";
            this.cbWDS.Visible = false;
            this.cbWDS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lBoxes
            // 
            this.lBoxes.BackColor = System.Drawing.Color.Transparent;
            this.lBoxes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBoxes.Location = new System.Drawing.Point(434, 145);
            this.lBoxes.Name = "lBoxes";
            this.lBoxes.Size = new System.Drawing.Size(45, 18);
            this.lBoxes.TabIndex = 250;
            this.lBoxes.Text = "Boxes :";
            this.lBoxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDS
            // 
            this.txtDS.AllowDrop = true;
            appearance113.ForeColorDisabled = System.Drawing.Color.White;
            this.txtDS.Appearance = appearance113;
            this.txtDS.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDS.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtDS.InputMask = "nn";
            this.txtDS.Location = new System.Drawing.Point(296, 27);
            this.txtDS.Name = "txtZipCode";
            this.txtDS.PromptChar = ' ';
            this.txtDS.Size = new System.Drawing.Size(39, 20);
            this.txtDS.TabIndex = 21;
            this.txtDS.Text = "0";
            this.txtDS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtProductReturnedDate
            // 
            this.txtProductReturnedDate.AllowDrop = true;
            this.txtProductReturnedDate.Location = new System.Drawing.Point(328, 144);
            this.txtProductReturnedDate.Name = "txtSignedDate";
            this.txtProductReturnedDate.Size = new System.Drawing.Size(90, 21);
            this.txtProductReturnedDate.TabIndex = 248;
            this.txtProductReturnedDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbRegisterReturned
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.BackColor2 = System.Drawing.Color.Transparent;
            appearance24.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.White;
            this.cbRegisterReturned.Appearance = appearance24;
            this.cbRegisterReturned.BackColor = System.Drawing.Color.Transparent;
            this.cbRegisterReturned.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbRegisterReturned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRegisterReturned.Location = new System.Drawing.Point(165, 126);
            this.cbRegisterReturned.Name = "cbRegisterReturned";
            this.cbRegisterReturned.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbRegisterReturned.Size = new System.Drawing.Size(130, 22);
            this.cbRegisterReturned.TabIndex = 247;
            this.cbRegisterReturned.Text = "Register Returned :";
            this.cbRegisterReturned.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbDS
            // 
            this.lbDS.BackColor = System.Drawing.Color.Transparent;
            this.lbDS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDS.Location = new System.Drawing.Point(226, 29);
            this.lbDS.Name = "lbDS";
            this.lbDS.Size = new System.Drawing.Size(66, 18);
            this.lbDS.TabIndex = 20;
            this.lbDS.Text = "DS:";
            this.lbDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbProductOrdered
            // 
            appearance110.BackColor = System.Drawing.Color.Transparent;
            appearance110.BackColor2 = System.Drawing.Color.Transparent;
            appearance110.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance110.ForeColor = System.Drawing.Color.Black;
            appearance110.ForeColorDisabled = System.Drawing.Color.White;
            this.cbProductOrdered.Appearance = appearance110;
            this.cbProductOrdered.BackColor = System.Drawing.Color.Transparent;
            this.cbProductOrdered.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbProductOrdered.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbProductOrdered.Location = new System.Drawing.Point(22, 108);
            this.cbProductOrdered.Name = "cbProductOrdered";
            this.cbProductOrdered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbProductOrdered.Size = new System.Drawing.Size(112, 19);
            this.cbProductOrdered.TabIndex = 19;
            this.cbProductOrdered.Text = "Product Ordered";
            this.cbProductOrdered.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbProductReturned
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            appearance25.BackColor2 = System.Drawing.Color.Transparent;
            appearance25.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.White;
            this.cbProductReturned.Appearance = appearance25;
            this.cbProductReturned.BackColor = System.Drawing.Color.Transparent;
            this.cbProductReturned.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbProductReturned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbProductReturned.Location = new System.Drawing.Point(179, 144);
            this.cbProductReturned.Name = "cbProductReturned";
            this.cbProductReturned.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbProductReturned.Size = new System.Drawing.Size(116, 22);
            this.cbProductReturned.TabIndex = 246;
            this.cbProductReturned.Text = "Product Returned :";
            this.cbProductReturned.CheckedChanged += new System.EventHandler(this.cbProductReturned_CheckedChanged);
            this.cbProductReturned.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbChecked
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            appearance27.BackColor2 = System.Drawing.Color.Transparent;
            appearance27.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.White;
            this.cbChecked.Appearance = appearance27;
            this.cbChecked.BackColor = System.Drawing.Color.Transparent;
            this.cbChecked.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbChecked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbChecked.Location = new System.Drawing.Point(209, 110);
            this.cbChecked.Name = "cbChecked";
            this.cbChecked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbChecked.Size = new System.Drawing.Size(86, 19);
            this.cbChecked.TabIndex = 244;
            this.cbChecked.Text = "Checked :";
            this.cbChecked.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // bKitAssigned
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BackColor2 = System.Drawing.Color.Transparent;
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.White;
            this.bKitAssigned.Appearance = appearance5;
            this.bKitAssigned.BackColor = System.Drawing.Color.Transparent;
            this.bKitAssigned.BackColorInternal = System.Drawing.Color.Transparent;
            this.bKitAssigned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bKitAssigned.Location = new System.Drawing.Point(378, 110);
            this.bKitAssigned.Name = "bKitAssigned";
            this.bKitAssigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bKitAssigned.Size = new System.Drawing.Size(87, 19);
            this.bKitAssigned.TabIndex = 18;
            this.bKitAssigned.Text = "Kit Assigned";
            this.bKitAssigned.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtLETX
            // 
            this.txtLETX.AllowDrop = true;
            appearance91.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLETX.Appearance = appearance91;
            this.txtLETX.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLETX.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLETX.InputMask = "nn";
            this.txtLETX.Location = new System.Drawing.Point(623, 109);
            this.txtLETX.Name = "txtZipCode";
            this.txtLETX.PromptChar = ' ';
            this.txtLETX.Size = new System.Drawing.Size(39, 20);
            this.txtLETX.TabIndex = 17;
            this.txtLETX.Text = "0";
            this.txtLETX.Visible = false;
            this.txtLETX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(582, 109);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 18);
            this.label42.TabIndex = 16;
            this.label42.Text = "LETX:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label42.Visible = false;
            // 
            // txtLE5
            // 
            this.txtLE5.AllowDrop = true;
            appearance96.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLE5.Appearance = appearance96;
            this.txtLE5.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLE5.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLE5.InputMask = "nn";
            this.txtLE5.Location = new System.Drawing.Point(518, 51);
            this.txtLE5.Name = "txtZipCode";
            this.txtLE5.PromptChar = ' ';
            this.txtLE5.Size = new System.Drawing.Size(39, 20);
            this.txtLE5.TabIndex = 17;
            this.txtLE5.Text = "0";
            this.txtLE5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbLE5
            // 
            this.lbLE5.BackColor = System.Drawing.Color.Transparent;
            this.lbLE5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLE5.Location = new System.Drawing.Point(467, 51);
            this.lbLE5.Name = "lbLE5";
            this.lbLE5.Size = new System.Drawing.Size(47, 18);
            this.lbLE5.TabIndex = 16;
            this.lbLE5.Text = "LE 5:";
            this.lbLE5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLE4
            // 
            this.txtLE4.AllowDrop = true;
            appearance93.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLE4.Appearance = appearance93;
            this.txtLE4.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLE4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLE4.InputMask = "nn";
            this.txtLE4.Location = new System.Drawing.Point(633, 101);
            this.txtLE4.Name = "txtZipCode";
            this.txtLE4.PromptChar = ' ';
            this.txtLE4.Size = new System.Drawing.Size(39, 20);
            this.txtLE4.TabIndex = 17;
            this.txtLE4.Text = "0";
            this.txtLE4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbLE4
            // 
            this.lbLE4.BackColor = System.Drawing.Color.Transparent;
            this.lbLE4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLE4.Location = new System.Drawing.Point(552, 101);
            this.lbLE4.Name = "lbLE4";
            this.lbLE4.Size = new System.Drawing.Size(79, 18);
            this.lbLE4.TabIndex = 16;
            this.lbLE4.Text = "LE 4:";
            this.lbLE4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLE3
            // 
            this.txtLE3.AllowDrop = true;
            appearance9.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLE3.Appearance = appearance9;
            this.txtLE3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLE3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLE3.InputMask = "nn";
            this.txtLE3.Location = new System.Drawing.Point(396, 77);
            this.txtLE3.Name = "txtZipCode";
            this.txtLE3.PromptChar = ' ';
            this.txtLE3.Size = new System.Drawing.Size(39, 20);
            this.txtLE3.TabIndex = 17;
            this.txtLE3.Text = "0";
            this.txtLE3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbLE3
            // 
            this.lbLE3.BackColor = System.Drawing.Color.Transparent;
            this.lbLE3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLE3.Location = new System.Drawing.Point(345, 77);
            this.lbLE3.Name = "lbLE3";
            this.lbLE3.Size = new System.Drawing.Size(47, 18);
            this.lbLE3.TabIndex = 16;
            this.lbLE3.Text = "LE 3:";
            this.lbLE3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLE2
            // 
            this.txtLE2.AllowDrop = true;
            appearance10.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLE2.Appearance = appearance10;
            this.txtLE2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLE2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLE2.InputMask = "nn";
            this.txtLE2.Location = new System.Drawing.Point(396, 51);
            this.txtLE2.Name = "txtZipCode";
            this.txtLE2.PromptChar = ' ';
            this.txtLE2.Size = new System.Drawing.Size(39, 20);
            this.txtLE2.TabIndex = 17;
            this.txtLE2.Text = "0";
            this.txtLE2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbLE2
            // 
            this.lbLE2.BackColor = System.Drawing.Color.Transparent;
            this.lbLE2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLE2.Location = new System.Drawing.Point(345, 51);
            this.lbLE2.Name = "lbLE2";
            this.lbLE2.Size = new System.Drawing.Size(47, 18);
            this.lbLE2.TabIndex = 16;
            this.lbLE2.Text = "LE 2:";
            this.lbLE2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLE1
            // 
            this.txtLE1.AllowDrop = true;
            appearance11.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLE1.Appearance = appearance11;
            this.txtLE1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLE1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLE1.InputMask = "nn";
            this.txtLE1.Location = new System.Drawing.Point(396, 25);
            this.txtLE1.Name = "txtZipCode";
            this.txtLE1.PromptChar = ' ';
            this.txtLE1.Size = new System.Drawing.Size(39, 20);
            this.txtLE1.TabIndex = 15;
            this.txtLE1.Text = "0";
            this.txtLE1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(345, 25);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 18);
            this.label29.TabIndex = 14;
            this.label29.Text = "LE 1:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTBin
            // 
            this.txtTBin.AllowDrop = true;
            appearance12.ForeColorDisabled = System.Drawing.Color.White;
            this.txtTBin.Appearance = appearance12;
            this.txtTBin.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTBin.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtTBin.InputMask = "nn";
            this.txtTBin.Location = new System.Drawing.Point(181, 79);
            this.txtTBin.Name = "txtZipCode";
            this.txtTBin.PromptChar = ' ';
            this.txtTBin.Size = new System.Drawing.Size(39, 20);
            this.txtTBin.TabIndex = 13;
            this.txtTBin.Text = "0";
            this.txtTBin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbTBin
            // 
            this.lbTBin.BackColor = System.Drawing.Color.Transparent;
            this.lbTBin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTBin.Location = new System.Drawing.Point(110, 83);
            this.lbTBin.Name = "lbTBin";
            this.lbTBin.Size = new System.Drawing.Size(65, 18);
            this.lbTBin.TabIndex = 12;
            this.lbTBin.Text = "T Bin:";
            this.lbTBin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSLow
            // 
            this.txtSLow.AllowDrop = true;
            appearance13.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSLow.Appearance = appearance13;
            this.txtSLow.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSLow.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSLow.InputMask = "nn";
            this.txtSLow.Location = new System.Drawing.Point(65, 77);
            this.txtSLow.Name = "txtZipCode";
            this.txtSLow.PromptChar = ' ';
            this.txtSLow.Size = new System.Drawing.Size(39, 20);
            this.txtSLow.TabIndex = 11;
            this.txtSLow.Text = "0";
            this.txtSLow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbS2Low
            // 
            this.lbS2Low.BackColor = System.Drawing.Color.Transparent;
            this.lbS2Low.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS2Low.Location = new System.Drawing.Point(6, 77);
            this.lbS2Low.Name = "lbS2Low";
            this.lbS2Low.Size = new System.Drawing.Size(55, 18);
            this.lbS2Low.TabIndex = 10;
            this.lbS2Low.Text = "S2 Low:";
            this.lbS2Low.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSHalf
            // 
            this.txtSHalf.AllowDrop = true;
            appearance94.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSHalf.Appearance = appearance94;
            this.txtSHalf.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSHalf.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSHalf.InputMask = "nn";
            this.txtSHalf.Location = new System.Drawing.Point(65, 51);
            this.txtSHalf.Name = "txtZipCode";
            this.txtSHalf.PromptChar = ' ';
            this.txtSHalf.Size = new System.Drawing.Size(39, 20);
            this.txtSHalf.TabIndex = 9;
            this.txtSHalf.Text = "0";
            this.txtSHalf.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbS2Half
            // 
            this.lbS2Half.BackColor = System.Drawing.Color.Transparent;
            this.lbS2Half.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS2Half.Location = new System.Drawing.Point(-4, 51);
            this.lbS2Half.Name = "lbS2Half";
            this.lbS2Half.Size = new System.Drawing.Size(66, 18);
            this.lbS2Half.TabIndex = 8;
            this.lbS2Half.Text = "S2 Half:";
            this.lbS2Half.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSFull
            // 
            this.txtSFull.AllowDrop = true;
            appearance95.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSFull.Appearance = appearance95;
            this.txtSFull.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSFull.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSFull.InputMask = "nn";
            this.txtSFull.Location = new System.Drawing.Point(65, 25);
            this.txtSFull.Name = "txtZipCode";
            this.txtSFull.PromptChar = ' ';
            this.txtSFull.Size = new System.Drawing.Size(39, 20);
            this.txtSFull.TabIndex = 7;
            this.txtSFull.Text = "0";
            this.txtSFull.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbS2Full
            // 
            this.lbS2Full.BackColor = System.Drawing.Color.Transparent;
            this.lbS2Full.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS2Full.Location = new System.Drawing.Point(0, 25);
            this.lbS2Full.Name = "lbS2Full";
            this.lbS2Full.Size = new System.Drawing.Size(62, 18);
            this.lbS2Full.TabIndex = 6;
            this.lbS2Full.Text = "S2 Full:";
            this.lbS2Full.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBOLTracking
            // 
            this.gbBOLTracking.AllowDrop = true;
            appearance21.AlphaLevel = ((short)(95));
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.gbBOLTracking.Appearance = appearance21;
            this.gbBOLTracking.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBOLTracking.Controls.Add(this.txtBOLTraking);
            this.gbBOLTracking.Controls.Add(this.lBOL);
            this.gbBOLTracking.Controls.Add(this.ultraButton1);
            this.gbBOLTracking.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbBOLTracking.Location = new System.Drawing.Point(5, 626);
            this.gbBOLTracking.Name = "gbLetterAproval";
            this.gbBOLTracking.Size = new System.Drawing.Size(529, 47);
            this.gbBOLTracking.TabIndex = 229;
            this.gbBOLTracking.Text = "BOL Tracking";
            this.gbBOLTracking.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtBOLTraking
            // 
            this.txtBOLTraking.AllowDrop = true;
            this.txtBOLTraking.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance29.TextHAlignAsString = "Right";
            this.txtBOLTraking.Appearance = appearance29;
            this.txtBOLTraking.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBOLTraking.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.String;
            this.txtBOLTraking.Location = new System.Drawing.Point(92, 20);
            this.txtBOLTraking.Name = "txtAmountDue";
            this.txtBOLTraking.PromptChar = ' ';
            this.txtBOLTraking.ReadOnly = true;
            this.txtBOLTraking.Size = new System.Drawing.Size(138, 20);
            this.txtBOLTraking.TabIndex = 240;
            // 
            // lBOL
            // 
            this.lBOL.BackColor = System.Drawing.Color.Transparent;
            this.lBOL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBOL.Location = new System.Drawing.Point(9, 22);
            this.lBOL.Name = "lBOL";
            this.lBOL.Size = new System.Drawing.Size(77, 18);
            this.lBOL.TabIndex = 241;
            this.lBOL.Text = "BOL Traking :";
            this.lBOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraButton1
            // 
            this.ultraButton1.AllowDrop = true;
            this.ultraButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ultraButton1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ultraButton1.ForeColor = System.Drawing.Color.Black;
            this.ultraButton1.Location = new System.Drawing.Point(246, 19);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(64, 20);
            this.ultraButton1.TabIndex = 242;
            this.ultraButton1.Text = "&Track";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // gbGAOptions
            // 
            this.gbGAOptions.AllowDrop = true;
            this.gbGAOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.AlphaLevel = ((short)(95));
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.gbGAOptions.Appearance = appearance16;
            this.gbGAOptions.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbGAOptions.Controls.Add(this.cbCoupon);
            this.gbGAOptions.Controls.Add(this.cbTreasureChest);
            this.gbGAOptions.Controls.Add(this.cbAssigned);
            this.gbGAOptions.Controls.Add(this.cbOneDaySale);
            this.gbGAOptions.Controls.Add(this.txtCashRegisters);
            this.gbGAOptions.Controls.Add(this.label1);
            this.gbGAOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbGAOptions.Location = new System.Drawing.Point(542, 699);
            this.gbGAOptions.Name = "gbShippingOptions";
            this.gbGAOptions.Size = new System.Drawing.Size(390, 81);
            this.gbGAOptions.TabIndex = 4;
            this.gbGAOptions.Text = "Options";
            this.gbGAOptions.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbCoupon
            // 
            this.cbCoupon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance38.BackColor = System.Drawing.Color.Transparent;
            appearance38.BackColor2 = System.Drawing.Color.Transparent;
            appearance38.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.White;
            this.cbCoupon.Appearance = appearance38;
            this.cbCoupon.BackColor = System.Drawing.Color.Transparent;
            this.cbCoupon.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbCoupon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCoupon.Location = new System.Drawing.Point(265, 20);
            this.cbCoupon.Name = "cbCoupon";
            this.cbCoupon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCoupon.Size = new System.Drawing.Size(105, 19);
            this.cbCoupon.TabIndex = 21;
            this.cbCoupon.Text = "Coupon:";
            this.cbCoupon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbTreasureChest
            // 
            this.cbTreasureChest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.BackColor2 = System.Drawing.Color.Transparent;
            appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.White;
            this.cbTreasureChest.Appearance = appearance17;
            this.cbTreasureChest.BackColor = System.Drawing.Color.Transparent;
            this.cbTreasureChest.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbTreasureChest.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbTreasureChest.Location = new System.Drawing.Point(136, 43);
            this.cbTreasureChest.Name = "cbTreasureChest";
            this.cbTreasureChest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTreasureChest.Size = new System.Drawing.Size(105, 19);
            this.cbTreasureChest.TabIndex = 20;
            this.cbTreasureChest.Text = "Treasure Chest:";
            this.cbTreasureChest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbAssigned
            // 
            this.cbAssigned.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance116.BackColor = System.Drawing.Color.Transparent;
            appearance116.BackColor2 = System.Drawing.Color.Transparent;
            appearance116.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance116.ForeColor = System.Drawing.Color.Black;
            appearance116.ForeColorDisabled = System.Drawing.Color.White;
            this.cbAssigned.Appearance = appearance116;
            this.cbAssigned.BackColor = System.Drawing.Color.Transparent;
            this.cbAssigned.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbAssigned.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAssigned.Location = new System.Drawing.Point(136, 18);
            this.cbAssigned.Name = "cbAssigned";
            this.cbAssigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAssigned.Size = new System.Drawing.Size(105, 19);
            this.cbAssigned.TabIndex = 19;
            this.cbAssigned.Text = "Stocking:";
            this.cbAssigned.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbOneDaySale
            // 
            this.cbOneDaySale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance19.BackColor = System.Drawing.Color.Transparent;
            appearance19.BackColor2 = System.Drawing.Color.Transparent;
            appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.White;
            this.cbOneDaySale.Appearance = appearance19;
            this.cbOneDaySale.BackColor = System.Drawing.Color.Transparent;
            this.cbOneDaySale.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbOneDaySale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbOneDaySale.Location = new System.Drawing.Point(12, 44);
            this.cbOneDaySale.Name = "cbOneDaySale";
            this.cbOneDaySale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbOneDaySale.Size = new System.Drawing.Size(105, 19);
            this.cbOneDaySale.TabIndex = 18;
            this.cbOneDaySale.Text = "One Day Sale:";
            this.cbOneDaySale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCashRegisters
            // 
            this.txtCashRegisters.AllowDrop = true;
            this.txtCashRegisters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance20.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCashRegisters.Appearance = appearance20;
            this.txtCashRegisters.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCashRegisters.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCashRegisters.InputMask = "nn";
            this.txtCashRegisters.Location = new System.Drawing.Point(78, 19);
            this.txtCashRegisters.Name = "txtZipCode";
            this.txtCashRegisters.PromptChar = ' ';
            this.txtCashRegisters.Size = new System.Drawing.Size(39, 20);
            this.txtCashRegisters.TabIndex = 7;
            this.txtCashRegisters.Text = "0";
            this.txtCashRegisters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cash Reg :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbLetterAproval
            // 
            this.gbLetterAproval.AllowDrop = true;
            appearance109.AlphaLevel = ((short)(95));
            appearance109.BackColor = System.Drawing.Color.Transparent;
            this.gbLetterAproval.Appearance = appearance109;
            this.gbLetterAproval.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbLetterAproval.Controls.Add(this.cbKastleKreation);
            this.gbLetterAproval.Controls.Add(this.button2);
            this.gbLetterAproval.Controls.Add(this.txtDateDeadLine);
            this.gbLetterAproval.Controls.Add(this.label61);
            this.gbLetterAproval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbLetterAproval.Location = new System.Drawing.Point(5, 578);
            this.gbLetterAproval.Name = "gbLetterAproval";
            this.gbLetterAproval.Size = new System.Drawing.Size(529, 47);
            this.gbLetterAproval.TabIndex = 5;
            this.gbLetterAproval.Text = "Letter Approval";
            this.gbLetterAproval.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbKastleKreation
            // 
            this.cbKastleKreation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.BackColor2 = System.Drawing.Color.Transparent;
            appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.White;
            this.cbKastleKreation.Appearance = appearance18;
            this.cbKastleKreation.BackColor = System.Drawing.Color.Transparent;
            this.cbKastleKreation.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbKastleKreation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbKastleKreation.Location = new System.Drawing.Point(356, 16);
            this.cbKastleKreation.Name = "cbKastleKreation";
            this.cbKastleKreation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbKastleKreation.Size = new System.Drawing.Size(105, 19);
            this.cbKastleKreation.TabIndex = 229;
            this.cbKastleKreation.Text = "Kastle Kreation";
            this.cbKastleKreation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(215, 16);
            this.button2.Name = "txtPrint";
            this.button2.Size = new System.Drawing.Size(84, 20);
            this.button2.TabIndex = 228;
            this.button2.Text = "&eMail";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDateDeadLine
            // 
            this.txtDateDeadLine.AllowDrop = true;
            this.txtDateDeadLine.DateTime = new System.DateTime(2008, 12, 9, 15, 3, 6, 738);
            this.txtDateDeadLine.Location = new System.Drawing.Point(90, 15);
            this.txtDateDeadLine.Name = "txtSignedDate";
            this.txtDateDeadLine.Size = new System.Drawing.Size(90, 21);
            this.txtDateDeadLine.TabIndex = 226;
            this.txtDateDeadLine.Value = new System.DateTime(2008, 12, 9, 15, 3, 6, 738);
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(11, 20);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(66, 18);
            this.label61.TabIndex = 225;
            this.label61.Text = "Deadline  :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gCurrentStatus
            // 
            this.gCurrentStatus.AllowDrop = true;
            this.gCurrentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance22.AlphaLevel = ((short)(95));
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.gCurrentStatus.Appearance = appearance22;
            this.gCurrentStatus.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gCurrentStatus.Controls.Add(this.cbBlueDogContract);
            this.gCurrentStatus.Controls.Add(this.cbBlueDog);
            this.gCurrentStatus.Controls.Add(this.txtTax);
            this.gCurrentStatus.Controls.Add(this.cbGrouped);
            this.gCurrentStatus.Controls.Add(this.txtOverage);
            this.gCurrentStatus.Controls.Add(this.lblOverage);
            this.gCurrentStatus.Controls.Add(this.txtProfitChanged);
            this.gCurrentStatus.Controls.Add(this.txtReceivedOrders);
            this.gCurrentStatus.Controls.Add(this.txtCompleted);
            this.gCurrentStatus.Controls.Add(this.txtBoxCount);
            this.gCurrentStatus.Controls.Add(this.label52);
            this.gCurrentStatus.Controls.Add(this.txtChecked);
            this.gCurrentStatus.Controls.Add(this.txtSignedYN);
            this.gCurrentStatus.Controls.Add(this.txtShowXBash);
            this.gCurrentStatus.Controls.Add(this.txtOld);
            this.gCurrentStatus.Controls.Add(this.txtPineValley);
            this.gCurrentStatus.Controls.Add(this.cb20062008);
            this.gCurrentStatus.Controls.Add(this.cbEnrollmentForm);
            this.gCurrentStatus.Controls.Add(this.txtFormerLastInvoicedAmount);
            this.gCurrentStatus.Controls.Add(this.lFormerLastInvoicedAmount);
            this.gCurrentStatus.Controls.Add(this.cbPrinted);
            this.gCurrentStatus.Controls.Add(this.txtSchoolUseOnly);
            this.gCurrentStatus.Controls.Add(this.txtCharges);
            this.gCurrentStatus.Controls.Add(this.lCharges);
            this.gCurrentStatus.Controls.Add(this.txtDiscDate);
            this.gCurrentStatus.Controls.Add(this.lDiscrepancyDate);
            this.gCurrentStatus.Controls.Add(this.txtNumberPallets);
            this.gCurrentStatus.Controls.Add(this.lNumberPallets);
            this.gCurrentStatus.Controls.Add(this.txtNoSellers);
            this.gCurrentStatus.Controls.Add(this.lSellers);
            this.gCurrentStatus.Controls.Add(this.txtLastInvoiced);
            this.gCurrentStatus.Controls.Add(this.txtAdded);
            this.gCurrentStatus.Controls.Add(this.lAdded);
            this.gCurrentStatus.Controls.Add(this.txtRetail);
            this.gCurrentStatus.Controls.Add(this.txtLetterAproval);
            this.gCurrentStatus.Controls.Add(this.lTax);
            this.gCurrentStatus.Controls.Add(this.txtAmountDue);
            this.gCurrentStatus.Controls.Add(this.lLastInvoice);
            this.gCurrentStatus.Controls.Add(this.txtPayments);
            this.gCurrentStatus.Controls.Add(this.lRetail);
            this.gCurrentStatus.Controls.Add(this.txtProfit);
            this.gCurrentStatus.Controls.Add(this.lAmountDue);
            this.gCurrentStatus.Controls.Add(this.txtNoItems);
            this.gCurrentStatus.Controls.Add(this.lProfit);
            this.gCurrentStatus.Controls.Add(this.txtInvoiced);
            this.gCurrentStatus.Controls.Add(this.lPayments);
            this.gCurrentStatus.Controls.Add(this.lItems);
            this.gCurrentStatus.Controls.Add(this.lInvoiced);
            this.gCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gCurrentStatus.Location = new System.Drawing.Point(542, 339);
            this.gCurrentStatus.Name = "ultraGroupBox1";
            this.gCurrentStatus.Size = new System.Drawing.Size(390, 367);
            this.gCurrentStatus.TabIndex = 7;
            this.gCurrentStatus.Text = "Current Status";
            this.gCurrentStatus.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbBlueDogContract
            // 
            appearance106.BackColor = System.Drawing.Color.Transparent;
            appearance106.BackColor2 = System.Drawing.Color.Transparent;
            appearance106.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance106.ForeColor = System.Drawing.Color.Black;
            appearance106.ForeColorDisabled = System.Drawing.Color.White;
            this.cbBlueDogContract.Appearance = appearance106;
            this.cbBlueDogContract.BackColor = System.Drawing.Color.Transparent;
            this.cbBlueDogContract.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbBlueDogContract.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBlueDogContract.Location = new System.Drawing.Point(47, 342);
            this.cbBlueDogContract.Name = "cbBlueDogContract";
            this.cbBlueDogContract.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbBlueDogContract.Size = new System.Drawing.Size(133, 19);
            this.cbBlueDogContract.TabIndex = 269;
            this.cbBlueDogContract.Text = "Blue Dog Contract";
            this.cbBlueDogContract.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbBlueDog
            // 
            appearance117.BackColor = System.Drawing.Color.Transparent;
            appearance117.BackColor2 = System.Drawing.Color.Transparent;
            appearance117.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance117.ForeColor = System.Drawing.Color.Black;
            appearance117.ForeColorDisabled = System.Drawing.Color.White;
            this.cbBlueDog.Appearance = appearance117;
            this.cbBlueDog.BackColor = System.Drawing.Color.Transparent;
            this.cbBlueDog.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbBlueDog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBlueDog.Location = new System.Drawing.Point(47, 326);
            this.cbBlueDog.Name = "cbBlueDog";
            this.cbBlueDog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbBlueDog.Size = new System.Drawing.Size(133, 19);
            this.cbBlueDog.TabIndex = 268;
            this.cbBlueDog.Text = "Blue Dog";
            this.cbBlueDog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtTax
            // 
            this.txtTax.AllowDrop = true;
            appearance35.TextHAlignAsString = "Right";
            this.txtTax.Appearance = appearance35;
            this.txtTax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtTax.FormatString = "###,###.##";
            this.txtTax.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtTax.Location = new System.Drawing.Point(116, 132);
            this.txtTax.Name = "txtAmountDue";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(64, 20);
            this.txtTax.TabIndex = 231;
            this.txtTax.Text = "0.00";
            // 
            // cbGrouped
            // 
            appearance118.BackColor = System.Drawing.Color.Transparent;
            appearance118.BackColor2 = System.Drawing.Color.Transparent;
            appearance118.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance118.ForeColor = System.Drawing.Color.Black;
            appearance118.ForeColorDisabled = System.Drawing.Color.White;
            this.cbGrouped.Appearance = appearance118;
            this.cbGrouped.BackColor = System.Drawing.Color.Transparent;
            this.cbGrouped.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbGrouped.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbGrouped.Location = new System.Drawing.Point(211, 304);
            this.cbGrouped.Name = "cbGrouped";
            this.cbGrouped.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbGrouped.Size = new System.Drawing.Size(139, 19);
            this.cbGrouped.TabIndex = 267;
            this.cbGrouped.Text = "Grouped";
            this.cbGrouped.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtOverage
            // 
            this.txtOverage.AllowDrop = true;
            appearance39.TextHAlignAsString = "Right";
            this.txtOverage.Appearance = appearance39;
            this.txtOverage.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOverage.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtOverage.FormatString = "###,###.##";
            this.txtOverage.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtOverage.Location = new System.Drawing.Point(286, 109);
            this.txtOverage.Name = "txtAmountDue";
            this.txtOverage.ReadOnly = true;
            this.txtOverage.Size = new System.Drawing.Size(64, 20);
            this.txtOverage.TabIndex = 265;
            this.txtOverage.Text = "0.00";
            // 
            // lblOverage
            // 
            this.lblOverage.BackColor = System.Drawing.Color.Transparent;
            this.lblOverage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverage.Location = new System.Drawing.Point(201, 109);
            this.lblOverage.Name = "lblOverage";
            this.lblOverage.Size = new System.Drawing.Size(77, 18);
            this.lblOverage.TabIndex = 266;
            this.lblOverage.Text = "Overage :";
            this.lblOverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfitChanged
            // 
            appearance119.BackColor = System.Drawing.Color.Transparent;
            appearance119.BackColor2 = System.Drawing.Color.Transparent;
            appearance119.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance119.ForeColor = System.Drawing.Color.Black;
            appearance119.ForeColorDisabled = System.Drawing.Color.White;
            this.txtProfitChanged.Appearance = appearance119;
            this.txtProfitChanged.BackColor = System.Drawing.Color.Transparent;
            this.txtProfitChanged.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtProfitChanged.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtProfitChanged.Location = new System.Drawing.Point(47, 304);
            this.txtProfitChanged.Name = "txtProfitChanged";
            this.txtProfitChanged.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProfitChanged.Size = new System.Drawing.Size(133, 19);
            this.txtProfitChanged.TabIndex = 264;
            this.txtProfitChanged.Text = "Profit Changed";
            this.txtProfitChanged.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtReceivedOrders
            // 
            appearance114.BackColor = System.Drawing.Color.Transparent;
            appearance114.BackColor2 = System.Drawing.Color.Transparent;
            appearance114.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance114.ForeColor = System.Drawing.Color.Black;
            appearance114.ForeColorDisabled = System.Drawing.Color.White;
            this.txtReceivedOrders.Appearance = appearance114;
            this.txtReceivedOrders.BackColor = System.Drawing.Color.Transparent;
            this.txtReceivedOrders.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtReceivedOrders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtReceivedOrders.Location = new System.Drawing.Point(44, 269);
            this.txtReceivedOrders.Name = "txtReceivedOrders";
            this.txtReceivedOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReceivedOrders.Size = new System.Drawing.Size(136, 19);
            this.txtReceivedOrders.TabIndex = 263;
            this.txtReceivedOrders.Text = "Received Orders";
            this.txtReceivedOrders.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCompleted
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            appearance26.BackColor2 = System.Drawing.Color.Transparent;
            appearance26.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCompleted.Appearance = appearance26;
            this.txtCompleted.BackColor = System.Drawing.Color.Transparent;
            this.txtCompleted.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtCompleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCompleted.Location = new System.Drawing.Point(211, 186);
            this.txtCompleted.Name = "txtCompleted";
            this.txtCompleted.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompleted.Size = new System.Drawing.Size(139, 19);
            this.txtCompleted.TabIndex = 262;
            this.txtCompleted.Text = "Completed";
            this.txtCompleted.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.AllowDrop = true;
            appearance32.TextHAlignAsString = "Right";
            this.txtBoxCount.Appearance = appearance32;
            this.txtBoxCount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBoxCount.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBoxCount.FormatString = "###,###.##";
            this.txtBoxCount.InputMask = "nnnnnnnnn";
            this.txtBoxCount.Location = new System.Drawing.Point(286, 64);
            this.txtBoxCount.Name = "txtAmountDue";
            this.txtBoxCount.ReadOnly = true;
            this.txtBoxCount.Size = new System.Drawing.Size(64, 20);
            this.txtBoxCount.TabIndex = 260;
            this.txtBoxCount.Text = "0";
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(187, 65);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(91, 18);
            this.label52.TabIndex = 261;
            this.label52.Text = "Number Boxes :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChecked
            // 
            appearance112.BackColor = System.Drawing.Color.Transparent;
            appearance112.BackColor2 = System.Drawing.Color.Transparent;
            appearance112.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance112.ForeColor = System.Drawing.Color.Black;
            appearance112.ForeColorDisabled = System.Drawing.Color.White;
            this.txtChecked.Appearance = appearance112;
            this.txtChecked.BackColor = System.Drawing.Color.Transparent;
            this.txtChecked.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtChecked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtChecked.Location = new System.Drawing.Point(211, 287);
            this.txtChecked.Name = "txtChecked";
            this.txtChecked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChecked.Size = new System.Drawing.Size(139, 19);
            this.txtChecked.TabIndex = 259;
            this.txtChecked.Text = "Checked";
            this.txtChecked.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtSignedYN
            // 
            appearance103.BackColor = System.Drawing.Color.Transparent;
            appearance103.BackColor2 = System.Drawing.Color.Transparent;
            appearance103.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance103.ForeColor = System.Drawing.Color.Black;
            appearance103.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSignedYN.Appearance = appearance103;
            this.txtSignedYN.BackColor = System.Drawing.Color.Transparent;
            this.txtSignedYN.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtSignedYN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSignedYN.Location = new System.Drawing.Point(211, 269);
            this.txtSignedYN.Name = "txtSignedYN";
            this.txtSignedYN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSignedYN.Size = new System.Drawing.Size(139, 19);
            this.txtSignedYN.TabIndex = 258;
            this.txtSignedYN.Text = "Signed";
            this.txtSignedYN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtShowXBash
            // 
            appearance102.BackColor = System.Drawing.Color.Transparent;
            appearance102.BackColor2 = System.Drawing.Color.Transparent;
            appearance102.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance102.ForeColor = System.Drawing.Color.Black;
            appearance102.ForeColorDisabled = System.Drawing.Color.White;
            this.txtShowXBash.Appearance = appearance102;
            this.txtShowXBash.BackColor = System.Drawing.Color.Transparent;
            this.txtShowXBash.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtShowXBash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtShowXBash.Location = new System.Drawing.Point(211, 252);
            this.txtShowXBash.Name = "txtShowXBash";
            this.txtShowXBash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtShowXBash.Size = new System.Drawing.Size(139, 19);
            this.txtShowXBash.TabIndex = 257;
            this.txtShowXBash.Text = "Show XBash";
            this.txtShowXBash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtOld
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            appearance37.BackColor2 = System.Drawing.Color.Transparent;
            appearance37.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.White;
            this.txtOld.Appearance = appearance37;
            this.txtOld.BackColor = System.Drawing.Color.Transparent;
            this.txtOld.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtOld.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtOld.Location = new System.Drawing.Point(211, 236);
            this.txtOld.Name = "txtOld";
            this.txtOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOld.Size = new System.Drawing.Size(139, 19);
            this.txtOld.TabIndex = 256;
            this.txtOld.Text = "OLD";
            this.txtOld.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPineValley
            // 
            appearance100.BackColor = System.Drawing.Color.Transparent;
            appearance100.BackColor2 = System.Drawing.Color.Transparent;
            appearance100.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance100.ForeColor = System.Drawing.Color.Black;
            appearance100.ForeColorDisabled = System.Drawing.Color.White;
            this.txtPineValley.Appearance = appearance100;
            this.txtPineValley.BackColor = System.Drawing.Color.Transparent;
            this.txtPineValley.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtPineValley.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtPineValley.Location = new System.Drawing.Point(211, 220);
            this.txtPineValley.Name = "txtPineValley";
            this.txtPineValley.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPineValley.Size = new System.Drawing.Size(139, 19);
            this.txtPineValley.TabIndex = 255;
            this.txtPineValley.Text = "PineValley";
            this.txtPineValley.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cb20062008
            // 
            appearance99.BackColor = System.Drawing.Color.Transparent;
            appearance99.BackColor2 = System.Drawing.Color.Transparent;
            appearance99.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance99.ForeColor = System.Drawing.Color.Black;
            appearance99.ForeColorDisabled = System.Drawing.Color.White;
            this.cb20062008.Appearance = appearance99;
            this.cb20062008.BackColor = System.Drawing.Color.Transparent;
            this.cb20062008.BackColorInternal = System.Drawing.Color.Transparent;
            this.cb20062008.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb20062008.Location = new System.Drawing.Point(211, 204);
            this.cb20062008.Name = "cb20062008";
            this.cb20062008.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cb20062008.Size = new System.Drawing.Size(139, 19);
            this.cb20062008.TabIndex = 254;
            this.cb20062008.Text = "2006-2008";
            this.cb20062008.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbEnrollmentForm
            // 
            appearance98.BackColor = System.Drawing.Color.Transparent;
            appearance98.BackColor2 = System.Drawing.Color.Transparent;
            appearance98.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance98.ForeColor = System.Drawing.Color.Black;
            appearance98.ForeColorDisabled = System.Drawing.Color.White;
            this.cbEnrollmentForm.Appearance = appearance98;
            this.cbEnrollmentForm.BackColor = System.Drawing.Color.Transparent;
            this.cbEnrollmentForm.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbEnrollmentForm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbEnrollmentForm.Location = new System.Drawing.Point(211, 152);
            this.cbEnrollmentForm.Name = "cbEnrollmentForm";
            this.cbEnrollmentForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbEnrollmentForm.Size = new System.Drawing.Size(139, 19);
            this.cbEnrollmentForm.TabIndex = 253;
            this.cbEnrollmentForm.Text = "Enrollment Form";
            // 
            // txtFormerLastInvoicedAmount
            // 
            this.txtFormerLastInvoicedAmount.AllowDrop = true;
            appearance34.TextHAlignAsString = "Right";
            this.txtFormerLastInvoicedAmount.Appearance = appearance34;
            this.txtFormerLastInvoicedAmount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFormerLastInvoicedAmount.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtFormerLastInvoicedAmount.FormatString = "###,###.##";
            this.txtFormerLastInvoicedAmount.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtFormerLastInvoicedAmount.Location = new System.Drawing.Point(116, 248);
            this.txtFormerLastInvoicedAmount.Name = "txtAmountDue";
            this.txtFormerLastInvoicedAmount.ReadOnly = true;
            this.txtFormerLastInvoicedAmount.Size = new System.Drawing.Size(64, 20);
            this.txtFormerLastInvoicedAmount.TabIndex = 252;
            this.txtFormerLastInvoicedAmount.Text = "0.00";
            this.txtFormerLastInvoicedAmount.Visible = false;
            // 
            // lFormerLastInvoicedAmount
            // 
            this.lFormerLastInvoicedAmount.BackColor = System.Drawing.Color.Transparent;
            this.lFormerLastInvoicedAmount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFormerLastInvoicedAmount.Location = new System.Drawing.Point(5, 249);
            this.lFormerLastInvoicedAmount.Name = "lFormerLastInvoicedAmount";
            this.lFormerLastInvoicedAmount.Size = new System.Drawing.Size(105, 18);
            this.lFormerLastInvoicedAmount.TabIndex = 251;
            this.lFormerLastInvoicedAmount.Text = "FormerLastInvoice :";
            this.lFormerLastInvoicedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lFormerLastInvoicedAmount.Visible = false;
            // 
            // cbPrinted
            // 
            appearance101.BackColor = System.Drawing.Color.Transparent;
            appearance101.BackColor2 = System.Drawing.Color.Transparent;
            appearance101.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance101.ForeColor = System.Drawing.Color.Black;
            appearance101.ForeColorDisabled = System.Drawing.Color.White;
            this.cbPrinted.Appearance = appearance101;
            this.cbPrinted.BackColor = System.Drawing.Color.Transparent;
            this.cbPrinted.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbPrinted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPrinted.Enabled = false;
            this.cbPrinted.Location = new System.Drawing.Point(46, 287);
            this.cbPrinted.Name = "cbPrinted";
            this.cbPrinted.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbPrinted.Size = new System.Drawing.Size(134, 19);
            this.cbPrinted.TabIndex = 245;
            this.cbPrinted.Text = "Printed";
            // 
            // txtSchoolUseOnly
            // 
            appearance28.BackColor = System.Drawing.Color.Transparent;
            appearance28.BackColor2 = System.Drawing.Color.Transparent;
            appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSchoolUseOnly.Appearance = appearance28;
            this.txtSchoolUseOnly.BackColor = System.Drawing.Color.Transparent;
            this.txtSchoolUseOnly.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtSchoolUseOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSchoolUseOnly.Enabled = false;
            this.txtSchoolUseOnly.Location = new System.Drawing.Point(211, 136);
            this.txtSchoolUseOnly.Name = "txtSchoolUseOnly";
            this.txtSchoolUseOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSchoolUseOnly.Size = new System.Drawing.Size(139, 19);
            this.txtSchoolUseOnly.TabIndex = 243;
            this.txtSchoolUseOnly.Text = "Use Only Box";
            // 
            // txtCharges
            // 
            this.txtCharges.AllowDrop = true;
            appearance30.TextHAlignAsString = "Right";
            this.txtCharges.Appearance = appearance30;
            this.txtCharges.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCharges.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCharges.FormatString = "###,###.##";
            this.txtCharges.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtCharges.Location = new System.Drawing.Point(116, 178);
            this.txtCharges.Name = "txtAmountDue";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(64, 20);
            this.txtCharges.TabIndex = 238;
            this.txtCharges.Text = "0.00";
            // 
            // lCharges
            // 
            this.lCharges.BackColor = System.Drawing.Color.Transparent;
            this.lCharges.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCharges.Location = new System.Drawing.Point(31, 178);
            this.lCharges.Name = "lCharges";
            this.lCharges.Size = new System.Drawing.Size(77, 18);
            this.lCharges.TabIndex = 239;
            this.lCharges.Text = "Charges :";
            this.lCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscDate
            // 
            this.txtDiscDate.AllowDrop = true;
            appearance31.TextHAlignAsString = "Right";
            this.txtDiscDate.Appearance = appearance31;
            this.txtDiscDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDiscDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDiscDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtDiscDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtDiscDate.Location = new System.Drawing.Point(286, 86);
            this.txtDiscDate.Name = "txtRetail";
            this.txtDiscDate.ReadOnly = true;
            this.txtDiscDate.Size = new System.Drawing.Size(65, 20);
            this.txtDiscDate.TabIndex = 237;
            this.txtDiscDate.Text = "//";
            // 
            // lDiscrepancyDate
            // 
            this.lDiscrepancyDate.BackColor = System.Drawing.Color.Transparent;
            this.lDiscrepancyDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDiscrepancyDate.Location = new System.Drawing.Point(184, 78);
            this.lDiscrepancyDate.Name = "lDiscrepancyDate";
            this.lDiscrepancyDate.Size = new System.Drawing.Size(94, 32);
            this.lDiscrepancyDate.TabIndex = 236;
            this.lDiscrepancyDate.Text = "Paperwork Done:";
            this.lDiscrepancyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberPallets
            // 
            this.txtNumberPallets.AllowDrop = true;
            appearance104.TextHAlignAsString = "Right";
            this.txtNumberPallets.Appearance = appearance104;
            this.txtNumberPallets.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNumberPallets.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNumberPallets.FormatString = "###,###.##";
            this.txtNumberPallets.InputMask = "nnnnnnnnn";
            this.txtNumberPallets.Location = new System.Drawing.Point(286, 41);
            this.txtNumberPallets.Name = "txtAmountDue";
            this.txtNumberPallets.ReadOnly = true;
            this.txtNumberPallets.Size = new System.Drawing.Size(64, 20);
            this.txtNumberPallets.TabIndex = 233;
            this.txtNumberPallets.Text = "0";
            // 
            // lNumberPallets
            // 
            this.lNumberPallets.BackColor = System.Drawing.Color.Transparent;
            this.lNumberPallets.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNumberPallets.Location = new System.Drawing.Point(184, 42);
            this.lNumberPallets.Name = "lNumberPallets";
            this.lNumberPallets.Size = new System.Drawing.Size(94, 18);
            this.lNumberPallets.TabIndex = 235;
            this.lNumberPallets.Text = "Number Pallets :";
            this.lNumberPallets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoSellers
            // 
            this.txtNoSellers.AllowDrop = true;
            appearance33.TextHAlignAsString = "Right";
            this.txtNoSellers.Appearance = appearance33;
            this.txtNoSellers.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNoSellers.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoSellers.FormatString = "###,###";
            this.txtNoSellers.InputMask = "nnnnnnnnn";
            this.txtNoSellers.Location = new System.Drawing.Point(286, 18);
            this.txtNoSellers.Name = "txtNoSellers";
            this.txtNoSellers.ReadOnly = true;
            this.txtNoSellers.Size = new System.Drawing.Size(64, 20);
            this.txtNoSellers.TabIndex = 232;
            this.txtNoSellers.Text = "0";
            // 
            // lSellers
            // 
            this.lSellers.BackColor = System.Drawing.Color.Transparent;
            this.lSellers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSellers.Location = new System.Drawing.Point(214, 22);
            this.lSellers.Name = "lSellers";
            this.lSellers.Size = new System.Drawing.Size(64, 18);
            this.lSellers.TabIndex = 234;
            this.lSellers.Text = "Sellers :";
            this.lSellers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastInvoiced
            // 
            this.txtLastInvoiced.AllowDrop = true;
            appearance89.TextHAlignAsString = "Right";
            this.txtLastInvoiced.Appearance = appearance89;
            this.txtLastInvoiced.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLastInvoiced.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtLastInvoiced.FormatString = "###,###.##";
            this.txtLastInvoiced.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtLastInvoiced.Location = new System.Drawing.Point(116, 19);
            this.txtLastInvoiced.Name = "txtAmountDue";
            this.txtLastInvoiced.ReadOnly = true;
            this.txtLastInvoiced.Size = new System.Drawing.Size(64, 20);
            this.txtLastInvoiced.TabIndex = 228;
            this.txtLastInvoiced.Text = "0.00";
            // 
            // txtAdded
            // 
            this.txtAdded.AllowDrop = true;
            appearance115.TextHAlignAsString = "Right";
            this.txtAdded.Appearance = appearance115;
            this.txtAdded.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAdded.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtAdded.FormatString = "###,###.##";
            this.txtAdded.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtAdded.Location = new System.Drawing.Point(116, 202);
            this.txtAdded.Name = "txtAmountDue";
            this.txtAdded.ReadOnly = true;
            this.txtAdded.Size = new System.Drawing.Size(64, 20);
            this.txtAdded.TabIndex = 230;
            this.txtAdded.Text = "0.00";
            // 
            // lAdded
            // 
            this.lAdded.BackColor = System.Drawing.Color.Transparent;
            this.lAdded.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdded.Location = new System.Drawing.Point(7, 202);
            this.lAdded.Name = "lAdded";
            this.lAdded.Size = new System.Drawing.Size(103, 20);
            this.lAdded.TabIndex = 231;
            this.lAdded.Text = "Added :";
            this.lAdded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRetail
            // 
            this.txtRetail.AllowDrop = true;
            appearance36.BackColorDisabled = System.Drawing.Color.White;
            appearance36.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance36;
            this.txtRetail.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(116, 65);
            this.txtRetail.Name = "txtAmountDue";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(64, 20);
            this.txtRetail.TabIndex = 229;
            this.txtRetail.Text = "0";
            // 
            // txtLetterAproval
            // 
            appearance90.BackColor = System.Drawing.Color.Transparent;
            appearance90.BackColor2 = System.Drawing.Color.Transparent;
            appearance90.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance90.ForeColor = System.Drawing.Color.Black;
            appearance90.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLetterAproval.Appearance = appearance90;
            this.txtLetterAproval.BackColor = System.Drawing.Color.Transparent;
            this.txtLetterAproval.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtLetterAproval.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtLetterAproval.Location = new System.Drawing.Point(211, 168);
            this.txtLetterAproval.Name = "txtLetterAproval";
            this.txtLetterAproval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLetterAproval.Size = new System.Drawing.Size(139, 19);
            this.txtLetterAproval.TabIndex = 17;
            this.txtLetterAproval.Text = "Letter Aproval Done";
            this.txtLetterAproval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lTax
            // 
            this.lTax.BackColor = System.Drawing.Color.Transparent;
            this.lTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTax.Location = new System.Drawing.Point(56, 132);
            this.lTax.Name = "lTax";
            this.lTax.Size = new System.Drawing.Size(52, 18);
            this.lTax.TabIndex = 225;
            this.lTax.Text = "Tax :";
            this.lTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.AllowDrop = true;
            appearance108.TextHAlignAsString = "Right";
            this.txtAmountDue.Appearance = appearance108;
            this.txtAmountDue.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAmountDue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtAmountDue.FormatString = "###,###.##";
            this.txtAmountDue.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtAmountDue.Location = new System.Drawing.Point(116, 226);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.ReadOnly = true;
            this.txtAmountDue.Size = new System.Drawing.Size(64, 20);
            this.txtAmountDue.TabIndex = 4;
            this.txtAmountDue.Text = "0.00";
            // 
            // lLastInvoice
            // 
            this.lLastInvoice.BackColor = System.Drawing.Color.Transparent;
            this.lLastInvoice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLastInvoice.Location = new System.Drawing.Point(11, 22);
            this.lLastInvoice.Name = "lLastInvoice";
            this.lLastInvoice.Size = new System.Drawing.Size(97, 18);
            this.lLastInvoice.TabIndex = 220;
            this.lLastInvoice.Text = "LastInvoice :";
            this.lLastInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPayments
            // 
            this.txtPayments.AllowDrop = true;
            appearance40.TextHAlignAsString = "Right";
            this.txtPayments.Appearance = appearance40;
            this.txtPayments.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPayments.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPayments.FormatString = "###,###.##";
            this.txtPayments.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPayments.Location = new System.Drawing.Point(116, 155);
            this.txtPayments.Name = "txtAmountDue";
            this.txtPayments.ReadOnly = true;
            this.txtPayments.Size = new System.Drawing.Size(64, 20);
            this.txtPayments.TabIndex = 1;
            this.txtPayments.Text = "0.00";
            // 
            // lRetail
            // 
            this.lRetail.BackColor = System.Drawing.Color.Transparent;
            this.lRetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRetail.Location = new System.Drawing.Point(58, 65);
            this.lRetail.Name = "lRetail";
            this.lRetail.Size = new System.Drawing.Size(50, 18);
            this.lRetail.TabIndex = 221;
            this.lRetail.Text = "Retail :";
            this.lRetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfit
            // 
            this.txtProfit.AllowDrop = true;
            appearance41.TextHAlignAsString = "Right";
            this.txtProfit.Appearance = appearance41;
            this.txtProfit.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfit.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtProfit.FormatString = "###,###.##";
            this.txtProfit.InputMask = "{LOC}nnnnnnn.nn";
            this.txtProfit.Location = new System.Drawing.Point(116, 87);
            this.txtProfit.Name = "txtAmountDue";
            this.txtProfit.ReadOnly = true;
            this.txtProfit.Size = new System.Drawing.Size(64, 20);
            this.txtProfit.TabIndex = 2;
            this.txtProfit.Text = "0";
            this.txtProfit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lAmountDue
            // 
            this.lAmountDue.BackColor = System.Drawing.Color.Transparent;
            this.lAmountDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAmountDue.Location = new System.Drawing.Point(31, 226);
            this.lAmountDue.Name = "lAmountDue";
            this.lAmountDue.Size = new System.Drawing.Size(77, 18);
            this.lAmountDue.TabIndex = 224;
            this.lAmountDue.Text = "Amount Due :";
            this.lAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoItems
            // 
            this.txtNoItems.AllowDrop = true;
            appearance42.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance42;
            this.txtNoItems.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNoItems.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoItems.FormatString = "###,###.##";
            this.txtNoItems.InputMask = "nn,nnn,nnn";
            this.txtNoItems.Location = new System.Drawing.Point(116, 42);
            this.txtNoItems.Name = "txtNoItems";
            this.txtNoItems.ReadOnly = true;
            this.txtNoItems.Size = new System.Drawing.Size(64, 20);
            this.txtNoItems.TabIndex = 2;
            this.txtNoItems.Text = "0";
            // 
            // lProfit
            // 
            this.lProfit.BackColor = System.Drawing.Color.Transparent;
            this.lProfit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProfit.Location = new System.Drawing.Point(56, 87);
            this.lProfit.Name = "lProfit";
            this.lProfit.Size = new System.Drawing.Size(52, 18);
            this.lProfit.TabIndex = 219;
            this.lProfit.Text = "Profit :";
            this.lProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiced
            // 
            this.txtInvoiced.AllowDrop = true;
            appearance43.TextHAlignAsString = "Right";
            this.txtInvoiced.Appearance = appearance43;
            this.txtInvoiced.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtInvoiced.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtInvoiced.FormatString = "###,###.##";
            this.txtInvoiced.InputMask = "{LOC}nnnnnnn.nn";
            this.txtInvoiced.Location = new System.Drawing.Point(116, 109);
            this.txtInvoiced.Name = "txtAmountDue";
            this.txtInvoiced.ReadOnly = true;
            this.txtInvoiced.Size = new System.Drawing.Size(64, 20);
            this.txtInvoiced.TabIndex = 3;
            this.txtInvoiced.Text = "0";
            this.txtInvoiced.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lPayments
            // 
            this.lPayments.BackColor = System.Drawing.Color.Transparent;
            this.lPayments.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPayments.Location = new System.Drawing.Point(44, 156);
            this.lPayments.Name = "lPayments";
            this.lPayments.Size = new System.Drawing.Size(64, 18);
            this.lPayments.TabIndex = 221;
            this.lPayments.Text = "Payments :";
            this.lPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lItems
            // 
            this.lItems.BackColor = System.Drawing.Color.Transparent;
            this.lItems.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lItems.Location = new System.Drawing.Point(44, 42);
            this.lItems.Name = "lItems";
            this.lItems.Size = new System.Drawing.Size(64, 18);
            this.lItems.TabIndex = 222;
            this.lItems.Text = "Items :";
            this.lItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lInvoiced
            // 
            this.lInvoiced.BackColor = System.Drawing.Color.Transparent;
            this.lInvoiced.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInvoiced.Location = new System.Drawing.Point(30, 109);
            this.lInvoiced.Name = "lInvoiced";
            this.lInvoiced.Size = new System.Drawing.Size(78, 18);
            this.lInvoiced.TabIndex = 217;
            this.lInvoiced.Text = "Invoiced :";
            this.lInvoiced.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbGeneralInfoGroup
            // 
            this.gbGeneralInfoGroup.AllowDrop = true;
            appearance44.AlphaLevel = ((short)(95));
            appearance44.BackColor = System.Drawing.Color.Transparent;
            this.gbGeneralInfoGroup.Appearance = appearance44;
            this.gbGeneralInfoGroup.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbGeneralInfoGroup.Controls.Add(this.txtCounty);
            this.gbGeneralInfoGroup.Controls.Add(this.txtGoal);
            this.gbGeneralInfoGroup.Controls.Add(this.labGoal);
            this.gbGeneralInfoGroup.Controls.Add(this.txtRepID);
            this.gbGeneralInfoGroup.Controls.Add(this.lbDatePayable);
            this.gbGeneralInfoGroup.Controls.Add(this.txtPayableTo);
            this.gbGeneralInfoGroup.Controls.Add(this.lbPayableTo);
            this.gbGeneralInfoGroup.Controls.Add(this.txtPostPay);
            this.gbGeneralInfoGroup.Controls.Add(this.lPostPay);
            this.gbGeneralInfoGroup.Controls.Add(this.txtGrid);
            this.gbGeneralInfoGroup.Controls.Add(this.lGrid);
            this.gbGeneralInfoGroup.Controls.Add(this.txtPage);
            this.gbGeneralInfoGroup.Controls.Add(this.lPage);
            this.gbGeneralInfoGroup.Controls.Add(this.label55);
            this.gbGeneralInfoGroup.Controls.Add(this.txtApplyTax);
            this.gbGeneralInfoGroup.Controls.Add(this.lCollectTax);
            this.gbGeneralInfoGroup.Controls.Add(this.txtCollectTax);
            this.gbGeneralInfoGroup.Controls.Add(this.txtPrevRetail);
            this.gbGeneralInfoGroup.Controls.Add(this.label49);
            this.gbGeneralInfoGroup.Controls.Add(this.txtHeadPhoneExt);
            this.gbGeneralInfoGroup.Controls.Add(this.lPhone);
            this.gbGeneralInfoGroup.Controls.Add(this.lCounty);
            this.gbGeneralInfoGroup.Controls.Add(this.txtFax);
            this.gbGeneralInfoGroup.Controls.Add(this.txtHeadPhone);
            this.gbGeneralInfoGroup.Controls.Add(this.ctrRepName);
            this.gbGeneralInfoGroup.Controls.Add(this.txtZipCode);
            this.gbGeneralInfoGroup.Controls.Add(this.txtCustomerID);
            this.gbGeneralInfoGroup.Controls.Add(this.txtState);
            this.gbGeneralInfoGroup.Controls.Add(this.txtCity);
            this.gbGeneralInfoGroup.Controls.Add(this.txtAddress);
            this.gbGeneralInfoGroup.Controls.Add(this.txtName);
            this.gbGeneralInfoGroup.Controls.Add(this.Label8);
            this.gbGeneralInfoGroup.Controls.Add(this.Label7);
            this.gbGeneralInfoGroup.Controls.Add(this.txtSalesTax);
            this.gbGeneralInfoGroup.Controls.Add(this.label26);
            this.gbGeneralInfoGroup.Controls.Add(this.Label15);
            this.gbGeneralInfoGroup.Controls.Add(this.Label17);
            this.gbGeneralInfoGroup.Controls.Add(this.Label6);
            this.gbGeneralInfoGroup.Controls.Add(this.Label35);
            this.gbGeneralInfoGroup.Controls.Add(this.Label16);
            this.gbGeneralInfoGroup.Controls.Add(this.Label19);
            this.gbGeneralInfoGroup.Controls.Add(this.label44);
            this.gbGeneralInfoGroup.Controls.Add(this.txtSigned);
            this.gbGeneralInfoGroup.Controls.Add(this.label23);
            this.gbGeneralInfoGroup.Controls.Add(this.txtDatePayable);
            this.gbGeneralInfoGroup.Controls.Add(this.txtFaxExt);
            this.gbGeneralInfoGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbGeneralInfoGroup.Location = new System.Drawing.Point(5, 11);
            this.gbGeneralInfoGroup.Name = "ultraGroupBox5";
            this.gbGeneralInfoGroup.Size = new System.Drawing.Size(529, 259);
            this.gbGeneralInfoGroup.TabIndex = 0;
            this.gbGeneralInfoGroup.Text = "General Information";
            this.gbGeneralInfoGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtCounty
            // 
            this.txtCounty.AllowDrop = true;
            this.txtCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtCounty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounty.ItemHeight = 13;
            this.txtCounty.Location = new System.Drawing.Point(78, 110);
            this.txtCounty.Name = "txtCollect";
            this.txtCounty.Size = new System.Drawing.Size(172, 21);
            this.txtCounty.TabIndex = 6;
            this.txtCounty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtGoal
            // 
            this.txtGoal.AllowDrop = true;
            appearance54.ForeColorDisabled = System.Drawing.Color.White;
            this.txtGoal.Appearance = appearance54;
            this.txtGoal.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtGoal.Location = new System.Drawing.Point(78, 229);
            this.txtGoal.Name = "txtSigned";
            this.txtGoal.PromptChar = ' ';
            this.txtGoal.Size = new System.Drawing.Size(48, 20);
            this.txtGoal.TabIndex = 267;
            this.txtGoal.Text = "0";
            this.txtGoal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // labGoal
            // 
            this.labGoal.BackColor = System.Drawing.Color.Transparent;
            this.labGoal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGoal.Location = new System.Drawing.Point(25, 229);
            this.labGoal.Name = "labGoal";
            this.labGoal.Size = new System.Drawing.Size(48, 18);
            this.labGoal.TabIndex = 268;
            this.labGoal.Text = "Goal:";
            this.labGoal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            appearance45.TextHAlignAsString = "Right";
            this.txtRepID.Appearance = appearance45;
            this.txtRepID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRepID.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtRepID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRepID.InputMask = "nnnnn";
            this.txtRepID.Location = new System.Drawing.Point(78, 135);
            this.txtRepID.Name = "txtRetail";
            this.txtRepID.PromptChar = ' ';
            this.txtRepID.Size = new System.Drawing.Size(48, 20);
            this.txtRepID.TabIndex = 7;
            this.txtRepID.Text = "() -";
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbDatePayable
            // 
            this.lbDatePayable.BackColor = System.Drawing.Color.Transparent;
            this.lbDatePayable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatePayable.Location = new System.Drawing.Point(390, 209);
            this.lbDatePayable.Name = "lbDatePayable";
            this.lbDatePayable.Size = new System.Drawing.Size(36, 18);
            this.lbDatePayable.TabIndex = 266;
            this.lbDatePayable.Text = "Date:";
            this.lbDatePayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDatePayable.Visible = false;
            // 
            // txtPayableTo
            // 
            this.txtPayableTo.AllowDrop = true;
            this.txtPayableTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPayableTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPayableTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayableTo.Location = new System.Drawing.Point(162, 209);
            this.txtPayableTo.Name = "txtName";
            this.txtPayableTo.Size = new System.Drawing.Size(231, 20);
            this.txtPayableTo.TabIndex = 28;
            this.txtPayableTo.Visible = false;
            this.txtPayableTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lbPayableTo
            // 
            this.lbPayableTo.BackColor = System.Drawing.Color.Transparent;
            this.lbPayableTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPayableTo.Location = new System.Drawing.Point(98, 208);
            this.lbPayableTo.Name = "lbPayableTo";
            this.lbPayableTo.Size = new System.Drawing.Size(66, 18);
            this.lbPayableTo.TabIndex = 264;
            this.lbPayableTo.Text = "Payable to:";
            this.lbPayableTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbPayableTo.Visible = false;
            // 
            // txtPostPay
            // 
            this.txtPostPay.AutoSize = true;
            this.txtPostPay.Location = new System.Drawing.Point(82, 211);
            this.txtPostPay.Name = "txtPostPay";
            this.txtPostPay.Size = new System.Drawing.Size(15, 14);
            this.txtPostPay.TabIndex = 263;
            this.txtPostPay.UseVisualStyleBackColor = true;
            this.txtPostPay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            this.txtPostPay.CheckedChanged += new System.EventHandler(this.txtPostPay_CheckedChanged);
            // 
            // lPostPay
            // 
            this.lPostPay.BackColor = System.Drawing.Color.Transparent;
            this.lPostPay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPostPay.Location = new System.Drawing.Point(13, 208);
            this.lPostPay.Name = "lPostPay";
            this.lPostPay.Size = new System.Drawing.Size(60, 18);
            this.lPostPay.TabIndex = 262;
            this.lPostPay.Text = "Post Pay :";
            this.lPostPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGrid
            // 
            this.txtGrid.AllowDrop = true;
            this.txtGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrid.Location = new System.Drawing.Point(78, 185);
            this.txtGrid.Name = "txtCustomerID";
            this.txtGrid.Size = new System.Drawing.Size(48, 20);
            this.txtGrid.TabIndex = 15;
            this.txtGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lGrid
            // 
            this.lGrid.BackColor = System.Drawing.Color.Transparent;
            this.lGrid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGrid.Location = new System.Drawing.Point(13, 182);
            this.lGrid.Name = "lGrid";
            this.lGrid.Size = new System.Drawing.Size(60, 18);
            this.lGrid.TabIndex = 239;
            this.lGrid.Text = "Grid :";
            this.lGrid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPage
            // 
            this.txtPage.AllowDrop = true;
            this.txtPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPage.Location = new System.Drawing.Point(78, 160);
            this.txtPage.Name = "txtCustomerID";
            this.txtPage.Size = new System.Drawing.Size(48, 20);
            this.txtPage.TabIndex = 14;
            this.txtPage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lPage
            // 
            this.lPage.BackColor = System.Drawing.Color.Transparent;
            this.lPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPage.Location = new System.Drawing.Point(13, 157);
            this.lPage.Name = "lPage";
            this.lPage.Size = new System.Drawing.Size(60, 18);
            this.lPage.TabIndex = 260;
            this.lPage.Text = "Page:";
            this.lPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(225, 161);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(74, 16);
            this.label55.TabIndex = 258;
            this.label55.Text = "Apply Tax?:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApplyTax
            // 
            this.txtApplyTax.AllowDrop = true;
            this.txtApplyTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtApplyTax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtApplyTax.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Retail"});
            this.txtApplyTax.Location = new System.Drawing.Point(304, 156);
            this.txtApplyTax.Name = "txtCollect";
            this.txtApplyTax.Size = new System.Drawing.Size(62, 21);
            this.txtApplyTax.TabIndex = 16;
            this.txtApplyTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lCollectTax
            // 
            this.lCollectTax.BackColor = System.Drawing.Color.Transparent;
            this.lCollectTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCollectTax.Location = new System.Drawing.Point(225, 187);
            this.lCollectTax.Name = "lCollectTax";
            this.lCollectTax.Size = new System.Drawing.Size(74, 16);
            this.lCollectTax.TabIndex = 256;
            this.lCollectTax.Text = "Collect Tax?:";
            this.lCollectTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCollectTax
            // 
            this.txtCollectTax.AllowDrop = true;
            this.txtCollectTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCollectTax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtCollectTax.Items.AddRange(new object[] {
            "No",
            "Retail",
            "Wholesale"});
            this.txtCollectTax.Location = new System.Drawing.Point(304, 182);
            this.txtCollectTax.Name = "txtCollectTax";
            this.txtCollectTax.Size = new System.Drawing.Size(62, 21);
            this.txtCollectTax.TabIndex = 17;
            this.txtCollectTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPrevRetail
            // 
            this.txtPrevRetail.AllowDrop = true;
            appearance46.TextHAlignAsString = "Right";
            this.txtPrevRetail.Appearance = appearance46;
            this.txtPrevRetail.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPrevRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPrevRetail.FormatString = "###,###.##";
            this.txtPrevRetail.InputMask = "nnnnnnnnn";
            this.txtPrevRetail.Location = new System.Drawing.Point(434, 131);
            this.txtPrevRetail.Name = "txtAmountDue";
            this.txtPrevRetail.Size = new System.Drawing.Size(64, 20);
            this.txtPrevRetail.TabIndex = 13;
            this.txtPrevRetail.Text = "0";
            this.txtPrevRetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(339, 131);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(87, 18);
            this.label49.TabIndex = 254;
            this.label49.Text = "Previous Retail :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHeadPhoneExt
            // 
            this.txtHeadPhoneExt.AllowDrop = true;
            appearance48.TextHAlignAsString = "Right";
            this.txtHeadPhoneExt.Appearance = appearance48;
            this.txtHeadPhoneExt.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtHeadPhoneExt.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHeadPhoneExt.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtHeadPhoneExt.InputMask = "nnnnnnnnn";
            this.txtHeadPhoneExt.Location = new System.Drawing.Point(433, 63);
            this.txtHeadPhoneExt.Name = "txtRetail";
            this.txtHeadPhoneExt.PromptChar = ' ';
            this.txtHeadPhoneExt.Size = new System.Drawing.Size(63, 20);
            this.txtHeadPhoneExt.TabIndex = 10;
            this.txtHeadPhoneExt.Text = "() -";
            this.txtHeadPhoneExt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lPhone
            // 
            this.lPhone.BackColor = System.Drawing.Color.Transparent;
            this.lPhone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPhone.Location = new System.Drawing.Point(371, 65);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(56, 16);
            this.lPhone.TabIndex = 234;
            this.lPhone.Text = "Ext. :";
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCounty
            // 
            this.lCounty.BackColor = System.Drawing.Color.Transparent;
            this.lCounty.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCounty.Location = new System.Drawing.Point(19, 109);
            this.lCounty.Name = "lCounty";
            this.lCounty.Size = new System.Drawing.Size(54, 18);
            this.lCounty.TabIndex = 232;
            this.lCounty.Text = "County :";
            this.lCounty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFax
            // 
            this.txtFax.AllowDrop = true;
            appearance49.TextHAlignAsString = "Right";
            this.txtFax.Appearance = appearance49;
            this.txtFax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFax.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtFax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtFax.InputMask = "(###) ###-####";
            this.txtFax.Location = new System.Drawing.Point(432, 86);
            this.txtFax.Name = "txtRetail";
            this.txtFax.Size = new System.Drawing.Size(80, 20);
            this.txtFax.TabIndex = 11;
            this.txtFax.Text = "() -";
            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtHeadPhone
            // 
            this.txtHeadPhone.AllowDrop = true;
            appearance50.TextHAlignAsString = "Right";
            this.txtHeadPhone.Appearance = appearance50;
            this.txtHeadPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtHeadPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHeadPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtHeadPhone.InputMask = "(###) ###-####";
            this.txtHeadPhone.Location = new System.Drawing.Point(433, 41);
            this.txtHeadPhone.Name = "txtRetail";
            this.txtHeadPhone.Size = new System.Drawing.Size(80, 20);
            this.txtHeadPhone.TabIndex = 9;
            this.txtHeadPhone.Text = "() -";
            this.txtHeadPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // ctrRepName
            // 
            appearance51.BackColor = System.Drawing.Color.Transparent;
            this.ctrRepName.Appearance = appearance51;
            this.ctrRepName.Location = new System.Drawing.Point(133, 136);
            this.ctrRepName.Name = "ctrRepName";
            this.ctrRepName.Size = new System.Drawing.Size(210, 19);
            this.ctrRepName.TabIndex = 8;
            // 
            // txtZipCode
            // 
            this.txtZipCode.AllowDrop = true;
            appearance52.ForeColorDisabled = System.Drawing.Color.White;
            this.txtZipCode.Appearance = appearance52;
            this.txtZipCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtZipCode.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.String;
            this.txtZipCode.Location = new System.Drawing.Point(310, 87);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.PromptChar = ' ';
            this.txtZipCode.Size = new System.Drawing.Size(54, 20);
            this.txtZipCode.TabIndex = 5;
            this.txtZipCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(78, 19);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(80, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.Text = " ";
            this.txtCustomerID.Leave += new System.EventHandler(this.txtCustomerID_Leave);
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtState
            // 
            this.txtState.AllowDrop = true;
            this.txtState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtState.Location = new System.Drawing.Point(226, 87);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(24, 20);
            this.txtState.TabIndex = 4;
            this.txtState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCity
            // 
            this.txtCity.AllowDrop = true;
            this.txtCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.Location = new System.Drawing.Point(78, 87);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(108, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtAddress
            // 
            this.txtAddress.AllowDrop = true;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Location = new System.Drawing.Point(78, 64);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(272, 20);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(78, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(272, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(186, 87);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 18);
            this.Label8.TabIndex = 230;
            this.Label8.Text = "State :";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(19, 84);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(54, 18);
            this.Label7.TabIndex = 229;
            this.Label7.Text = "City :";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSalesTax
            // 
            this.txtSalesTax.AllowDrop = true;
            appearance53.ForeColorDisabled = System.Drawing.Color.White;
            this.txtSalesTax.Appearance = appearance53;
            this.txtSalesTax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSalesTax.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtSalesTax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSalesTax.InputMask = "nn.nnn%";
            this.txtSalesTax.Location = new System.Drawing.Point(435, 179);
            this.txtSalesTax.Name = "txtSigned";
            this.txtSalesTax.PromptChar = ' ';
            this.txtSalesTax.Size = new System.Drawing.Size(48, 20);
            this.txtSalesTax.TabIndex = 19;
            this.txtSalesTax.Text = "%";
            this.txtSalesTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(353, 179);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 18);
            this.label26.TabIndex = 252;
            this.label26.Text = "Sales Tax:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(363, 39);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(64, 18);
            this.Label15.TabIndex = 228;
            this.Label15.Text = "Phone No. :";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label17
            // 
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(246, 88);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(64, 18);
            this.Label17.TabIndex = 4;
            this.Label17.Text = "Zip Code :";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(17, 38);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(56, 18);
            this.Label6.TabIndex = 226;
            this.Label6.Text = "Name :";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(1, 20);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 225;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label16
            // 
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(17, 61);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(56, 18);
            this.Label16.TabIndex = 224;
            this.Label16.Text = "Address  :";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label19
            // 
            this.Label19.BackColor = System.Drawing.Color.Transparent;
            this.Label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(370, 88);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(56, 16);
            this.Label19.TabIndex = 223;
            this.Label19.Text = "Fax No. :";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(13, 132);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(60, 18);
            this.label44.TabIndex = 237;
            this.label44.Text = "Rep :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSigned
            // 
            this.txtSigned.AllowDrop = true;
            appearance88.ForeColorDisabled = System.Drawing.Color.Gainsboro;
            this.txtSigned.Appearance = appearance88;
            this.txtSigned.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSigned.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSigned.InputMask = "nnnnn";
            this.txtSigned.Location = new System.Drawing.Point(435, 155);
            this.txtSigned.Name = "txtSigned";
            this.txtSigned.PromptChar = ' ';
            this.txtSigned.Size = new System.Drawing.Size(48, 20);
            this.txtSigned.TabIndex = 18;
            this.txtSigned.Text = "0";
            this.txtSigned.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(379, 155);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 18);
            this.label23.TabIndex = 243;
            this.label23.Text = "Signed:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatePayable
            // 
            this.txtDatePayable.AllowDrop = true;
            this.txtDatePayable.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtDatePayable.Location = new System.Drawing.Point(432, 208);
            this.txtDatePayable.Name = "txtSignedDate";
            this.txtDatePayable.Size = new System.Drawing.Size(91, 21);
            this.txtDatePayable.TabIndex = 265;
            this.txtDatePayable.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtDatePayable.Visible = false;
            // 
            // txtFaxExt
            // 
            this.txtFaxExt.AllowDrop = true;
            appearance47.ForeColorDisabled = System.Drawing.Color.White;
            this.txtFaxExt.Appearance = appearance47;
            this.txtFaxExt.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFaxExt.Location = new System.Drawing.Point(413, 110);
            this.txtFaxExt.Name = "txtFaxExt";
            this.txtFaxExt.TabIndex = 261;
            this.txtFaxExt.Visible = false;
            // 
            // gbChairperson
            // 
            this.gbChairperson.AllowDrop = true;
            appearance55.AlphaLevel = ((short)(95));
            appearance55.BackColor = System.Drawing.Color.Transparent;
            this.gbChairperson.Appearance = appearance55;
            this.gbChairperson.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbChairperson.Controls.Add(this.txtEmailSecondary);
            this.gbChairperson.Controls.Add(this.label51);
            this.gbChairperson.Controls.Add(this.txtPhoneNumberExt);
            this.gbChairperson.Controls.Add(this.lHeadPhone);
            this.gbChairperson.Controls.Add(this.txtPhoneNumber);
            this.gbChairperson.Controls.Add(this.txteMail);
            this.gbChairperson.Controls.Add(this.txtChairperson);
            this.gbChairperson.Controls.Add(this.label2);
            this.gbChairperson.Controls.Add(this.Label5);
            this.gbChairperson.Controls.Add(this.Label20);
            this.gbChairperson.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbChairperson.Location = new System.Drawing.Point(5, 272);
            this.gbChairperson.Name = "ultraGroupBox4";
            this.gbChairperson.Size = new System.Drawing.Size(529, 95);
            this.gbChairperson.TabIndex = 1;
            this.gbChairperson.Text = "Chairperson";
            this.gbChairperson.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtEmailSecondary
            // 
            this.txtEmailSecondary.AllowDrop = true;
            this.txtEmailSecondary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEmailSecondary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmailSecondary.Location = new System.Drawing.Point(78, 67);
            this.txtEmailSecondary.Name = "txteMail";
            this.txtEmailSecondary.Size = new System.Drawing.Size(272, 20);
            this.txtEmailSecondary.TabIndex = 239;
            this.txtEmailSecondary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(6, 59);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(64, 32);
            this.label51.TabIndex = 240;
            this.label51.Text = "Secondary E-mail :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhoneNumberExt
            // 
            this.txtPhoneNumberExt.AllowDrop = true;
            appearance56.TextHAlignAsString = "Right";
            this.txtPhoneNumberExt.Appearance = appearance56;
            this.txtPhoneNumberExt.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhoneNumberExt.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhoneNumberExt.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhoneNumberExt.InputMask = "nnnnnnnnn";
            this.txtPhoneNumberExt.Location = new System.Drawing.Point(432, 49);
            this.txtPhoneNumberExt.Name = "txtRetail";
            this.txtPhoneNumberExt.Size = new System.Drawing.Size(63, 20);
            this.txtPhoneNumberExt.TabIndex = 3;
            this.txtPhoneNumberExt.Text = "() -";
            this.txtPhoneNumberExt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lHeadPhone
            // 
            this.lHeadPhone.BackColor = System.Drawing.Color.Transparent;
            this.lHeadPhone.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHeadPhone.Location = new System.Drawing.Point(370, 51);
            this.lHeadPhone.Name = "lHeadPhone";
            this.lHeadPhone.Size = new System.Drawing.Size(56, 16);
            this.lHeadPhone.TabIndex = 238;
            this.lHeadPhone.Text = "Ext. :";
            this.lHeadPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.AllowDrop = true;
            appearance57.TextHAlignAsString = "Right";
            this.txtPhoneNumber.Appearance = appearance57;
            this.txtPhoneNumber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhoneNumber.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhoneNumber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhoneNumber.InputMask = "(###) ###-####";
            this.txtPhoneNumber.Location = new System.Drawing.Point(432, 23);
            this.txtPhoneNumber.Name = "txtRetail";
            this.txtPhoneNumber.Size = new System.Drawing.Size(80, 20);
            this.txtPhoneNumber.TabIndex = 2;
            this.txtPhoneNumber.Text = "() -";
            this.txtPhoneNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txteMail
            // 
            this.txteMail.AllowDrop = true;
            this.txteMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txteMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txteMail.Location = new System.Drawing.Point(78, 43);
            this.txteMail.Name = "txteMail";
            this.txteMail.Size = new System.Drawing.Size(272, 20);
            this.txteMail.TabIndex = 1;
            this.txteMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtChairperson
            // 
            this.txtChairperson.AllowDrop = true;
            this.txtChairperson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtChairperson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChairperson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChairperson.Location = new System.Drawing.Point(78, 19);
            this.txtChairperson.Name = "txtChairperson";
            this.txtChairperson.Size = new System.Drawing.Size(272, 20);
            this.txtChairperson.TabIndex = 0;
            this.txtChairperson.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 220;
            this.label2.Text = "Phone No. :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(22, 23);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(48, 18);
            this.Label5.TabIndex = 219;
            this.Label5.Text = "Name :";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label20
            // 
            this.Label20.BackColor = System.Drawing.Color.Transparent;
            this.Label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(22, 43);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(48, 18);
            this.Label20.TabIndex = 218;
            this.Label20.Text = "E-mail :";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBrochures
            // 
            this.gbBrochures.AllowDrop = true;
            this.gbBrochures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance58.AlphaLevel = ((short)(95));
            appearance58.BackColor = System.Drawing.Color.Transparent;
            this.gbBrochures.Appearance = appearance58;
            this.gbBrochures.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBrochures.Controls.Add(this.ctrBrochureName_4);
            this.gbBrochures.Controls.Add(this.txtCODE4);
            this.gbBrochures.Controls.Add(this.label13);
            this.gbBrochures.Controls.Add(this.txtProfitPercent_4);
            this.gbBrochures.Controls.Add(this.label14);
            this.gbBrochures.Controls.Add(this.txtBrochureID_4);
            this.gbBrochures.Controls.Add(this.label24);
            this.gbBrochures.Controls.Add(this.ctrBrochureName_3);
            this.gbBrochures.Controls.Add(this.txtCODE3);
            this.gbBrochures.Controls.Add(this.lCode_3);
            this.gbBrochures.Controls.Add(this.txtProfitPercent_3);
            this.gbBrochures.Controls.Add(this.lProfit_3);
            this.gbBrochures.Controls.Add(this.txtBrochureID_3);
            this.gbBrochures.Controls.Add(this.lBrochure_3);
            this.gbBrochures.Controls.Add(this.ctrBrochureName_2);
            this.gbBrochures.Controls.Add(this.txtCODE2);
            this.gbBrochures.Controls.Add(this.label36);
            this.gbBrochures.Controls.Add(this.txtProfitPercent_2);
            this.gbBrochures.Controls.Add(this.label33);
            this.gbBrochures.Controls.Add(this.txtBrochureID_2);
            this.gbBrochures.Controls.Add(this.lBrochure2);
            this.gbBrochures.Controls.Add(this.ctrBrochureName);
            this.gbBrochures.Controls.Add(this.txtBrochureID);
            this.gbBrochures.Controls.Add(this.txtCODE1);
            this.gbBrochures.Controls.Add(this.txtProfitPercent);
            this.gbBrochures.Controls.Add(this.label3);
            this.gbBrochures.Controls.Add(this.label41);
            this.gbBrochures.Controls.Add(this.ctrPrizeName);
            this.gbBrochures.Controls.Add(this.lBrochure_1);
            this.gbBrochures.Controls.Add(this.lPrize);
            this.gbBrochures.Controls.Add(this.txtPrizeID);
            this.gbBrochures.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbBrochures.Location = new System.Drawing.Point(540, 11);
            this.gbBrochures.Name = "ultraGroupBox3";
            this.gbBrochures.Size = new System.Drawing.Size(392, 249);
            this.gbBrochures.TabIndex = 2;
            this.gbBrochures.Text = "Brochures";
            this.gbBrochures.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ctrBrochureName_4
            // 
            this.ctrBrochureName_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance59.BackColor = System.Drawing.Color.Transparent;
            this.ctrBrochureName_4.Appearance = appearance59;
            this.ctrBrochureName_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrBrochureName_4.Location = new System.Drawing.Point(17, 190);
            this.ctrBrochureName_4.Name = "ctrBrochureName_4";
            this.ctrBrochureName_4.Size = new System.Drawing.Size(236, 20);
            this.ctrBrochureName_4.TabIndex = 279;
            // 
            // txtCODE4
            // 
            this.txtCODE4.AllowDrop = true;
            this.txtCODE4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance60.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCODE4.Appearance = appearance60;
            this.txtCODE4.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCODE4.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtCODE4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCODE4.InputMask = "nnn.nn%";
            this.txtCODE4.Location = new System.Drawing.Point(312, 190);
            this.txtCODE4.Name = "txtCODE1";
            this.txtCODE4.PromptChar = ' ';
            this.txtCODE4.Size = new System.Drawing.Size(48, 20);
            this.txtCODE4.TabIndex = 275;
            this.txtCODE4.Text = "0.00";
            this.txtCODE4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(250, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 18);
            this.label13.TabIndex = 278;
            this.label13.Text = "CODE 4 :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfitPercent_4
            // 
            this.txtProfitPercent_4.AllowDrop = true;
            this.txtProfitPercent_4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance61.ForeColorDisabled = System.Drawing.Color.White;
            this.txtProfitPercent_4.Appearance = appearance61;
            this.txtProfitPercent_4.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfitPercent_4.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtProfitPercent_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtProfitPercent_4.InputMask = "nn.nn%";
            this.txtProfitPercent_4.Location = new System.Drawing.Point(312, 166);
            this.txtProfitPercent_4.Name = "txtProfitPercent";
            this.txtProfitPercent_4.PromptChar = ' ';
            this.txtProfitPercent_4.Size = new System.Drawing.Size(48, 20);
            this.txtProfitPercent_4.TabIndex = 274;
            this.txtProfitPercent_4.Text = "0.00";
            this.txtProfitPercent_4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(253, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 18);
            this.label14.TabIndex = 277;
            this.label14.Text = "Profit 4 :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBrochureID_4
            // 
            this.txtBrochureID_4.AllowDrop = true;
            this.txtBrochureID_4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBrochureID_4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrochureID_4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureID_4.Location = new System.Drawing.Point(82, 166);
            this.txtBrochureID_4.Name = "txtCustomerID";
            this.txtBrochureID_4.Size = new System.Drawing.Size(48, 20);
            this.txtBrochureID_4.TabIndex = 273;
            this.txtBrochureID_4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 169);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 15);
            this.label24.TabIndex = 276;
            this.label24.Text = "Brochure 4 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrBrochureName_3
            // 
            this.ctrBrochureName_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance120.BackColor = System.Drawing.Color.Transparent;
            this.ctrBrochureName_3.Appearance = appearance120;
            this.ctrBrochureName_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrBrochureName_3.Location = new System.Drawing.Point(17, 140);
            this.ctrBrochureName_3.Name = "ctrBrochureName_3";
            this.ctrBrochureName_3.Size = new System.Drawing.Size(236, 20);
            this.ctrBrochureName_3.TabIndex = 272;
            // 
            // txtCODE3
            // 
            this.txtCODE3.AllowDrop = true;
            this.txtCODE3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance121.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCODE3.Appearance = appearance121;
            this.txtCODE3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCODE3.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtCODE3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCODE3.InputMask = "nnn.nn%";
            this.txtCODE3.Location = new System.Drawing.Point(312, 140);
            this.txtCODE3.Name = "txtCODE1";
            this.txtCODE3.PromptChar = ' ';
            this.txtCODE3.Size = new System.Drawing.Size(48, 20);
            this.txtCODE3.TabIndex = 8;
            this.txtCODE3.Text = "0.00";
            this.txtCODE3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lCode_3
            // 
            this.lCode_3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lCode_3.BackColor = System.Drawing.Color.Transparent;
            this.lCode_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCode_3.Location = new System.Drawing.Point(250, 140);
            this.lCode_3.Name = "lCode_3";
            this.lCode_3.Size = new System.Drawing.Size(54, 18);
            this.lCode_3.TabIndex = 271;
            this.lCode_3.Text = "CODE 3 :";
            this.lCode_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfitPercent_3
            // 
            this.txtProfitPercent_3.AllowDrop = true;
            this.txtProfitPercent_3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance122.ForeColorDisabled = System.Drawing.Color.White;
            this.txtProfitPercent_3.Appearance = appearance122;
            this.txtProfitPercent_3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfitPercent_3.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtProfitPercent_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtProfitPercent_3.InputMask = "nn.nn%";
            this.txtProfitPercent_3.Location = new System.Drawing.Point(312, 116);
            this.txtProfitPercent_3.Name = "txtProfitPercent";
            this.txtProfitPercent_3.PromptChar = ' ';
            this.txtProfitPercent_3.Size = new System.Drawing.Size(48, 20);
            this.txtProfitPercent_3.TabIndex = 7;
            this.txtProfitPercent_3.Text = "0.00";
            this.txtProfitPercent_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lProfit_3
            // 
            this.lProfit_3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lProfit_3.BackColor = System.Drawing.Color.Transparent;
            this.lProfit_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProfit_3.Location = new System.Drawing.Point(253, 114);
            this.lProfit_3.Name = "lProfit_3";
            this.lProfit_3.Size = new System.Drawing.Size(51, 18);
            this.lProfit_3.TabIndex = 270;
            this.lProfit_3.Text = "Profit 3 :";
            this.lProfit_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBrochureID_3
            // 
            this.txtBrochureID_3.AllowDrop = true;
            this.txtBrochureID_3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBrochureID_3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrochureID_3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureID_3.Location = new System.Drawing.Point(82, 116);
            this.txtBrochureID_3.Name = "txtCustomerID";
            this.txtBrochureID_3.Size = new System.Drawing.Size(48, 20);
            this.txtBrochureID_3.TabIndex = 6;
            this.txtBrochureID_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lBrochure_3
            // 
            this.lBrochure_3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBrochure_3.BackColor = System.Drawing.Color.Transparent;
            this.lBrochure_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBrochure_3.Location = new System.Drawing.Point(9, 119);
            this.lBrochure_3.Name = "lBrochure_3";
            this.lBrochure_3.Size = new System.Drawing.Size(67, 15);
            this.lBrochure_3.TabIndex = 269;
            this.lBrochure_3.Text = "Brochure 3 :";
            this.lBrochure_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrBrochureName_2
            // 
            this.ctrBrochureName_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance62.BackColor = System.Drawing.Color.Transparent;
            this.ctrBrochureName_2.Appearance = appearance62;
            this.ctrBrochureName_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrBrochureName_2.Location = new System.Drawing.Point(15, 91);
            this.ctrBrochureName_2.Name = "ctrBrochureName_2";
            this.ctrBrochureName_2.Size = new System.Drawing.Size(236, 20);
            this.ctrBrochureName_2.TabIndex = 265;
            // 
            // txtCODE2
            // 
            this.txtCODE2.AllowDrop = true;
            this.txtCODE2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance63.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCODE2.Appearance = appearance63;
            this.txtCODE2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCODE2.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtCODE2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCODE2.InputMask = "nnn.nn%";
            this.txtCODE2.Location = new System.Drawing.Point(312, 89);
            this.txtCODE2.Name = "txtCODE1";
            this.txtCODE2.PromptChar = ' ';
            this.txtCODE2.Size = new System.Drawing.Size(48, 20);
            this.txtCODE2.TabIndex = 5;
            this.txtCODE2.Text = "%";
            this.txtCODE2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(250, 87);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(54, 18);
            this.label36.TabIndex = 261;
            this.label36.Text = "CODE 2 :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfitPercent_2
            // 
            this.txtProfitPercent_2.AllowDrop = true;
            this.txtProfitPercent_2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance64.ForeColorDisabled = System.Drawing.Color.White;
            this.txtProfitPercent_2.Appearance = appearance64;
            this.txtProfitPercent_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfitPercent_2.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtProfitPercent_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtProfitPercent_2.InputMask = "nn.nn%";
            this.txtProfitPercent_2.Location = new System.Drawing.Point(312, 65);
            this.txtProfitPercent_2.Name = "txtProfitPercent";
            this.txtProfitPercent_2.PromptChar = ' ';
            this.txtProfitPercent_2.Size = new System.Drawing.Size(48, 20);
            this.txtProfitPercent_2.TabIndex = 4;
            this.txtProfitPercent_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(253, 63);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(51, 18);
            this.label33.TabIndex = 257;
            this.label33.Text = "Profit 2 :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBrochureID_2
            // 
            this.txtBrochureID_2.AllowDrop = true;
            this.txtBrochureID_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBrochureID_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrochureID_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureID_2.Location = new System.Drawing.Point(82, 65);
            this.txtBrochureID_2.Name = "txtCustomerID";
            this.txtBrochureID_2.Size = new System.Drawing.Size(48, 20);
            this.txtBrochureID_2.TabIndex = 3;
            this.txtBrochureID_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lBrochure2
            // 
            this.lBrochure2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBrochure2.BackColor = System.Drawing.Color.Transparent;
            this.lBrochure2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBrochure2.Location = new System.Drawing.Point(9, 70);
            this.lBrochure2.Name = "lBrochure2";
            this.lBrochure2.Size = new System.Drawing.Size(67, 15);
            this.lBrochure2.TabIndex = 253;
            this.lBrochure2.Text = "Brochure 2 :";
            this.lBrochure2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrBrochureName
            // 
            this.ctrBrochureName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance65.BackColor = System.Drawing.Color.Transparent;
            this.ctrBrochureName.Appearance = appearance65;
            this.ctrBrochureName.Location = new System.Drawing.Point(17, 38);
            this.ctrBrochureName.Name = "ctrBrochureName";
            this.ctrBrochureName.Size = new System.Drawing.Size(232, 19);
            this.ctrBrochureName.TabIndex = 248;
            // 
            // txtBrochureID
            // 
            this.txtBrochureID.AllowDrop = true;
            this.txtBrochureID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBrochureID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrochureID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureID.Location = new System.Drawing.Point(82, 11);
            this.txtBrochureID.Name = "txtCustomerID";
            this.txtBrochureID.Size = new System.Drawing.Size(48, 20);
            this.txtBrochureID.TabIndex = 0;
            this.txtBrochureID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCODE1
            // 
            this.txtCODE1.AllowDrop = true;
            this.txtCODE1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance66.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCODE1.Appearance = appearance66;
            this.txtCODE1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCODE1.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtCODE1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCODE1.InputMask = "nnn.nn%";
            this.txtCODE1.Location = new System.Drawing.Point(312, 37);
            this.txtCODE1.Name = "txtCODE1";
            this.txtCODE1.PromptChar = ' ';
            this.txtCODE1.Size = new System.Drawing.Size(48, 20);
            this.txtCODE1.TabIndex = 2;
            this.txtCODE1.Text = "%";
            this.txtCODE1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtProfitPercent
            // 
            this.txtProfitPercent.AllowDrop = true;
            this.txtProfitPercent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance67.ForeColorDisabled = System.Drawing.Color.White;
            this.txtProfitPercent.Appearance = appearance67;
            this.txtProfitPercent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfitPercent.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtProfitPercent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtProfitPercent.InputMask = "nn.nn%";
            this.txtProfitPercent.Location = new System.Drawing.Point(312, 13);
            this.txtProfitPercent.Name = "txtProfitPercent";
            this.txtProfitPercent.PromptChar = ' ';
            this.txtProfitPercent.Size = new System.Drawing.Size(48, 20);
            this.txtProfitPercent.TabIndex = 1;
            this.txtProfitPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(249, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 241;
            this.label3.Text = "Profit 1 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(250, 37);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(54, 18);
            this.label41.TabIndex = 239;
            this.label41.Text = "CODE1 :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrPrizeName
            // 
            this.ctrPrizeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance68.BackColor = System.Drawing.Color.Transparent;
            this.ctrPrizeName.Appearance = appearance68;
            this.ctrPrizeName.Location = new System.Drawing.Point(137, 219);
            this.ctrPrizeName.Name = "ctrPrizeName";
            this.ctrPrizeName.Size = new System.Drawing.Size(210, 20);
            this.ctrPrizeName.TabIndex = 10;
            // 
            // lBrochure_1
            // 
            this.lBrochure_1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBrochure_1.BackColor = System.Drawing.Color.Transparent;
            this.lBrochure_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBrochure_1.Location = new System.Drawing.Point(6, 13);
            this.lBrochure_1.Name = "lBrochure_1";
            this.lBrochure_1.Size = new System.Drawing.Size(68, 16);
            this.lBrochure_1.TabIndex = 238;
            this.lBrochure_1.Text = "Brochure 1 :";
            this.lBrochure_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPrize
            // 
            this.lPrize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lPrize.BackColor = System.Drawing.Color.Transparent;
            this.lPrize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPrize.Location = new System.Drawing.Point(38, 221);
            this.lPrize.Name = "lPrize";
            this.lPrize.Size = new System.Drawing.Size(38, 16);
            this.lPrize.TabIndex = 242;
            this.lPrize.Text = "Prize :";
            this.lPrize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrizeID
            // 
            this.txtPrizeID.AllowDrop = true;
            this.txtPrizeID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrizeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPrizeID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrizeID.Location = new System.Drawing.Point(82, 217);
            this.txtPrizeID.Name = "txtCustomerID";
            this.txtPrizeID.Size = new System.Drawing.Size(48, 20);
            this.txtPrizeID.TabIndex = 9;
            this.txtPrizeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // gbDates
            // 
            this.gbDates.AllowDrop = true;
            appearance69.AlphaLevel = ((short)(95));
            appearance69.BackColor = System.Drawing.Color.Transparent;
            this.gbDates.Appearance = appearance69;
            this.gbDates.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbDates.Controls.Add(this.txtEndDate);
            this.gbDates.Controls.Add(this.txtPPickupDate);
            this.gbDates.Controls.Add(this.txtDeliveryDate);
            this.gbDates.Controls.Add(this.txtShipDate);
            this.gbDates.Controls.Add(this.txtPickUpDate);
            this.gbDates.Controls.Add(this.txtStartDate);
            this.gbDates.Controls.Add(this.txtSignedDate);
            this.gbDates.Controls.Add(this.txtParentPickUpNote);
            this.gbDates.Controls.Add(this.txtDeliveryNote);
            this.gbDates.Controls.Add(this.txtShipNote);
            this.gbDates.Controls.Add(this.txtPickUpNote);
            this.gbDates.Controls.Add(this.txtEndNote);
            this.gbDates.Controls.Add(this.txtStartNote);
            this.gbDates.Controls.Add(this.lPPickupDate);
            this.gbDates.Controls.Add(this.label37);
            this.gbDates.Controls.Add(this.cShipVia);
            this.gbDates.Controls.Add(this.txtSignedNote);
            this.gbDates.Controls.Add(this.label40);
            this.gbDates.Controls.Add(this.lDeliveryDate);
            this.gbDates.Controls.Add(this.lShipdate);
            this.gbDates.Controls.Add(this.lPickUpDate);
            this.gbDates.Controls.Add(this.label18);
            this.gbDates.Controls.Add(this.label21);
            this.gbDates.Controls.Add(this.label22);
            this.gbDates.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbDates.Location = new System.Drawing.Point(5, 367);
            this.gbDates.Name = "ultraGroupBox2";
            this.gbDates.Size = new System.Drawing.Size(529, 207);
            this.gbDates.TabIndex = 3;
            this.gbDates.Text = "Dates";
            this.gbDates.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtEndDate
            // 
            this.txtEndDate.AllowDrop = true;
            this.txtEndDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtEndDate.Location = new System.Drawing.Point(89, 78);
            this.txtEndDate.Name = "txtSignedDate";
            this.txtEndDate.Size = new System.Drawing.Size(90, 21);
            this.txtEndDate.TabIndex = 2;
            this.txtEndDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtEndDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPPickupDate
            // 
            this.txtPPickupDate.AllowDrop = true;
            this.txtPPickupDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtPPickupDate.Location = new System.Drawing.Point(89, 172);
            this.txtPPickupDate.Name = "txtSignedDate";
            this.txtPPickupDate.Size = new System.Drawing.Size(90, 21);
            this.txtPPickupDate.TabIndex = 6;
            this.txtPPickupDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtPPickupDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.AllowDrop = true;
            this.txtDeliveryDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtDeliveryDate.Location = new System.Drawing.Point(89, 149);
            this.txtDeliveryDate.Name = "txtSignedDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(90, 21);
            this.txtDeliveryDate.TabIndex = 5;
            this.txtDeliveryDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtDeliveryDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtShipDate
            // 
            this.txtShipDate.AllowDrop = true;
            this.txtShipDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtShipDate.Location = new System.Drawing.Point(89, 126);
            this.txtShipDate.Name = "txtSignedDate";
            this.txtShipDate.Size = new System.Drawing.Size(90, 21);
            this.txtShipDate.TabIndex = 4;
            this.txtShipDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtShipDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPickUpDate
            // 
            this.txtPickUpDate.AllowDrop = true;
            this.txtPickUpDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtPickUpDate.Location = new System.Drawing.Point(90, 103);
            this.txtPickUpDate.Name = "txtSignedDate";
            this.txtPickUpDate.Size = new System.Drawing.Size(90, 21);
            this.txtPickUpDate.TabIndex = 3;
            this.txtPickUpDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtPickUpDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtStartDate
            // 
            this.txtStartDate.AllowDrop = true;
            this.txtStartDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtStartDate.Location = new System.Drawing.Point(89, 55);
            this.txtStartDate.Name = "txtSignedDate";
            this.txtStartDate.Size = new System.Drawing.Size(90, 21);
            this.txtStartDate.TabIndex = 1;
            this.txtStartDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtStartDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtSignedDate
            // 
            this.txtSignedDate.AllowDrop = true;
            this.txtSignedDate.DateTime = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtSignedDate.Location = new System.Drawing.Point(89, 31);
            this.txtSignedDate.Name = "txtSignedDate";
            this.txtSignedDate.Size = new System.Drawing.Size(90, 21);
            this.txtSignedDate.TabIndex = 0;
            this.txtSignedDate.Value = new System.DateTime(2008, 10, 30, 0, 0, 0, 0);
            this.txtSignedDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtParentPickUpNote
            // 
            this.txtParentPickUpNote.AllowDrop = true;
            this.txtParentPickUpNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtParentPickUpNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParentPickUpNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParentPickUpNote.Location = new System.Drawing.Point(190, 172);
            this.txtParentPickUpNote.Name = "txtParentPickUpNote";
            this.txtParentPickUpNote.Size = new System.Drawing.Size(323, 22);
            this.txtParentPickUpNote.TabIndex = 13;
            this.txtParentPickUpNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtDeliveryNote
            // 
            this.txtDeliveryNote.AllowDrop = true;
            this.txtDeliveryNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDeliveryNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliveryNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryNote.Location = new System.Drawing.Point(190, 149);
            this.txtDeliveryNote.Name = "txtDeliveryNote";
            this.txtDeliveryNote.Size = new System.Drawing.Size(323, 22);
            this.txtDeliveryNote.TabIndex = 12;
            this.txtDeliveryNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtShipNote
            // 
            this.txtShipNote.AllowDrop = true;
            this.txtShipNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtShipNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShipNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipNote.Location = new System.Drawing.Point(190, 126);
            this.txtShipNote.Name = "txtShipNote";
            this.txtShipNote.Size = new System.Drawing.Size(323, 22);
            this.txtShipNote.TabIndex = 11;
            this.txtShipNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtPickUpNote
            // 
            this.txtPickUpNote.AllowDrop = true;
            this.txtPickUpNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPickUpNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPickUpNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPickUpNote.Location = new System.Drawing.Point(190, 103);
            this.txtPickUpNote.Name = "txtPickUpNote";
            this.txtPickUpNote.Size = new System.Drawing.Size(323, 22);
            this.txtPickUpNote.TabIndex = 10;
            this.txtPickUpNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtEndNote
            // 
            this.txtEndNote.AllowDrop = true;
            this.txtEndNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEndNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndNote.Location = new System.Drawing.Point(190, 80);
            this.txtEndNote.Name = "txtEndNote";
            this.txtEndNote.Size = new System.Drawing.Size(323, 22);
            this.txtEndNote.TabIndex = 9;
            this.txtEndNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtStartNote
            // 
            this.txtStartNote.AllowDrop = true;
            this.txtStartNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtStartNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartNote.Location = new System.Drawing.Point(190, 57);
            this.txtStartNote.Name = "txtStartNote";
            this.txtStartNote.Size = new System.Drawing.Size(323, 22);
            this.txtStartNote.TabIndex = 8;
            this.txtStartNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // lPPickupDate
            // 
            this.lPPickupDate.BackColor = System.Drawing.Color.Transparent;
            this.lPPickupDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPPickupDate.Location = new System.Drawing.Point(10, 174);
            this.lPPickupDate.Name = "lPPickupDate";
            this.lPPickupDate.Size = new System.Drawing.Size(72, 18);
            this.lPPickupDate.TabIndex = 269;
            this.lPPickupDate.Text = "P Pickup :";
            this.lPPickupDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(186, 14);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(44, 18);
            this.label37.TabIndex = 267;
            this.label37.Text = "Notes:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cShipVia
            // 
            this.cShipVia.FormattingEnabled = true;
            this.cShipVia.Items.AddRange(new object[] {
            "UPS",
            "Fedex Freight",
            "Fedex NAT"});
            this.cShipVia.Location = new System.Drawing.Point(87, 282);
            this.cShipVia.Name = "cShipVia";
            this.cShipVia.Size = new System.Drawing.Size(108, 21);
            this.cShipVia.TabIndex = 15;
            this.cShipVia.Text = "UPS Ground";
            this.cShipVia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtSignedNote
            // 
            this.txtSignedNote.AllowDrop = true;
            this.txtSignedNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtSignedNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSignedNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignedNote.Location = new System.Drawing.Point(190, 34);
            this.txtSignedNote.Name = "txtSignedNote";
            this.txtSignedNote.Size = new System.Drawing.Size(323, 22);
            this.txtSignedNote.TabIndex = 7;
            this.txtSignedNote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Location = new System.Drawing.Point(22, 284);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(57, 19);
            this.label40.TabIndex = 263;
            this.label40.Text = "Ship Via:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lDeliveryDate
            // 
            this.lDeliveryDate.BackColor = System.Drawing.Color.Transparent;
            this.lDeliveryDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDeliveryDate.Location = new System.Drawing.Point(0, 150);
            this.lDeliveryDate.Name = "lDeliveryDate";
            this.lDeliveryDate.Size = new System.Drawing.Size(83, 18);
            this.lDeliveryDate.TabIndex = 160;
            this.lDeliveryDate.Text = "Delivery :";
            this.lDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lShipdate
            // 
            this.lShipdate.BackColor = System.Drawing.Color.Transparent;
            this.lShipdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lShipdate.Location = new System.Drawing.Point(0, 126);
            this.lShipdate.Name = "lShipdate";
            this.lShipdate.Size = new System.Drawing.Size(83, 18);
            this.lShipdate.TabIndex = 159;
            this.lShipdate.Text = "Ship :";
            this.lShipdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPickUpDate
            // 
            this.lPickUpDate.BackColor = System.Drawing.Color.Transparent;
            this.lPickUpDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPickUpDate.Location = new System.Drawing.Point(0, 103);
            this.lPickUpDate.Name = "lPickUpDate";
            this.lPickUpDate.Size = new System.Drawing.Size(83, 18);
            this.lPickUpDate.TabIndex = 158;
            this.lPickUpDate.Text = "PickUp :";
            this.lPickUpDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(51, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 18);
            this.label18.TabIndex = 157;
            this.label18.Text = "End :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(43, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 18);
            this.label21.TabIndex = 156;
            this.label21.Text = "Start :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(35, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 18);
            this.label22.TabIndex = 155;
            this.label22.Text = "Signed :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbShippingOptions
            // 
            this.gbShippingOptions.AllowDrop = true;
            this.gbShippingOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance70.AlphaLevel = ((short)(95));
            appearance70.BackColor = System.Drawing.Color.Transparent;
            this.gbShippingOptions.Appearance = appearance70;
            this.gbShippingOptions.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbShippingOptions.Controls.Add(this.cbKK);
            this.gbShippingOptions.Controls.Add(this.cbAMDelivery);
            this.gbShippingOptions.Controls.Add(this.OpShipOption);
            this.gbShippingOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbShippingOptions.Location = new System.Drawing.Point(542, 264);
            this.gbShippingOptions.Name = "gbShippingOptions";
            this.gbShippingOptions.Size = new System.Drawing.Size(390, 70);
            this.gbShippingOptions.TabIndex = 4;
            this.gbShippingOptions.Text = "Shipping Options";
            this.gbShippingOptions.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbKK
            // 
            appearance107.BackColor = System.Drawing.Color.Transparent;
            appearance107.BackColor2 = System.Drawing.Color.Transparent;
            appearance107.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance107.ForeColor = System.Drawing.Color.Black;
            appearance107.ForeColorDisabled = System.Drawing.Color.White;
            this.cbKK.Appearance = appearance107;
            this.cbKK.BackColor = System.Drawing.Color.Transparent;
            this.cbKK.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbKK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbKK.Location = new System.Drawing.Point(177, 40);
            this.cbKK.Name = "cbKK";
            this.cbKK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbKK.Size = new System.Drawing.Size(64, 19);
            this.cbKK.TabIndex = 265;
            this.cbKK.Text = "KK";
            this.cbKK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // cbAMDelivery
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            appearance105.BackColor2 = System.Drawing.Color.Transparent;
            appearance105.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance105.ForeColor = System.Drawing.Color.Black;
            appearance105.ForeColorDisabled = System.Drawing.Color.White;
            this.cbAMDelivery.Appearance = appearance105;
            this.cbAMDelivery.BackColor = System.Drawing.Color.Transparent;
            this.cbAMDelivery.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbAMDelivery.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAMDelivery.Location = new System.Drawing.Point(9, 40);
            this.cbAMDelivery.Name = "cbAMDelivery";
            this.cbAMDelivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAMDelivery.Size = new System.Drawing.Size(101, 19);
            this.cbAMDelivery.TabIndex = 264;
            this.cbAMDelivery.Text = "AM Delivery";
            this.cbAMDelivery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // OpShipOption
            // 
            this.OpShipOption.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "Economy";
            valueListItem2.DataValue = "2";
            valueListItem2.DisplayText = "Priority";
            valueListItem3.DataValue = "3";
            valueListItem3.DisplayText = "Sig Freight";
            valueListItem4.DataValue = "4";
            valueListItem4.DisplayText = "UPS Ground";
            this.OpShipOption.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.OpShipOption.Location = new System.Drawing.Point(8, 21);
            this.OpShipOption.Name = "OpShipOption";
            this.OpShipOption.Size = new System.Drawing.Size(350, 21);
            this.OpShipOption.TabIndex = 0;
            this.OpShipOption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // btRefresh
            // 
            this.btRefresh.AllowDrop = true;
            this.btRefresh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRefresh.ForeColor = System.Drawing.Color.Black;
            this.btRefresh.Location = new System.Drawing.Point(592, 565);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(102, 20);
            this.btRefresh.TabIndex = 10;
            this.btRefresh.Text = "&Refresh Totals";
            this.btRefresh.Visible = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ultraGroupBox6);
            this.tabPage4.Location = new System.Drawing.Point(4, 19);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(939, 811);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Brochures";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.AllowDrop = true;
            appearance71.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox6.Appearance = appearance71;
            this.ultraGroupBox6.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox6.Controls.Add(this.Grid);
            this.ultraGroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox6.Location = new System.Drawing.Point(4, 4);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(918, 560);
            this.ultraGroupBox6.TabIndex = 0;
            this.ultraGroupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance72.BackColor = System.Drawing.Color.Gainsboro;
            appearance72.BackColor2 = System.Drawing.Color.DarkGray;
            appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.Grid.DisplayLayout.Appearance = appearance72;
            ultraGridBand1.CardView = true;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn1.Width = 82;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.MaxLength = 200;
            ultraGridColumn2.MinLength = 200;
            ultraGridColumn2.MinWidth = 250;
            ultraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn2.Width = 300;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Format = "";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn3.MaskInput = "";
            ultraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn3.Width = 63;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn4.Width = 63;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "";
            ultraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn5.Width = 66;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn6.Width = 115;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 105;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Width = 120;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Width = 126;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.InterBandSpacing = 10;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.Grid.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance73.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance73;
            appearance74.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance74.ForeColor = System.Drawing.Color.Navy;
            this.Grid.DisplayLayout.Override.CellAppearance = appearance74;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance75.BackColor = System.Drawing.Color.DarkGray;
            appearance75.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance75.FontData.Name = "Tahoma";
            appearance75.FontData.SizeInPoints = 9F;
            appearance75.ForeColor = System.Drawing.Color.Navy;
            appearance75.TextHAlignAsString = "Left";
            appearance75.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance75;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance76.BackColor = System.Drawing.Color.DarkGray;
            appearance76.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance76.ForeColor = System.Drawing.Color.Navy;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance76;
            this.Grid.DisplayLayout.Override.RowSelectorWidth = 20;
            this.Grid.DisplayLayout.Override.RowSpacingAfter = 1;
            this.Grid.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance77.BackColor = System.Drawing.Color.Navy;
            appearance77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance77;
            this.Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.Gray;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(3, 0);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(912, 557);
            this.Grid.TabIndex = 17;
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TabPage2.Controls.Add(this.RGrid);
            this.TabPage2.Location = new System.Drawing.Point(4, 19);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Size = new System.Drawing.Size(939, 811);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Account Receivable";
            this.TabPage2.UseVisualStyleBackColor = true;
            this.TabPage2.Visible = false;
            // 
            // RGrid
            // 
            appearance78.BackColor = System.Drawing.Color.White;
            this.RGrid.DisplayLayout.Appearance = appearance78;
            ultraGridColumn14.Header.VisiblePosition = 1;
            ultraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn14.Width = 405;
            ultraGridColumn15.Header.VisiblePosition = 0;
            ultraGridColumn15.Width = 189;
            ultraGridColumn16.DataType = typeof(decimal);
            ultraGridColumn16.Format = "####,###.00";
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn16.Width = 147;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            this.RGrid.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.RGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.RGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.RGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.RGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance79.BackColor = System.Drawing.Color.Transparent;
            this.RGrid.DisplayLayout.Override.CardAreaAppearance = appearance79;
            this.RGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance80.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance80.FontData.BoldAsString = "True";
            appearance80.FontData.Name = "Arial";
            appearance80.FontData.SizeInPoints = 10F;
            appearance80.ForeColor = System.Drawing.Color.White;
            appearance80.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.RGrid.DisplayLayout.Override.HeaderAppearance = appearance80;
            this.RGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance81.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.RGrid.DisplayLayout.Override.RowSelectorAppearance = appearance81;
            this.RGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance82.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance82.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.RGrid.DisplayLayout.Override.SelectedRowAppearance = appearance82;
            this.RGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.RGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.RGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.RGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RGrid.Location = new System.Drawing.Point(8, 3);
            this.RGrid.Name = "RGrid";
            this.RGrid.Size = new System.Drawing.Size(908, 522);
            this.RGrid.TabIndex = 185;
            // 
            // TabPage3
            // 
            this.TabPage3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TabPage3.Controls.Add(this.OrdersGrid);
            this.TabPage3.Location = new System.Drawing.Point(4, 19);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(939, 811);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Order/Re-Order";
            this.TabPage3.UseVisualStyleBackColor = true;
            this.TabPage3.Visible = false;
            // 
            // OrdersGrid
            // 
            appearance83.BackColor = System.Drawing.Color.White;
            this.OrdersGrid.DisplayLayout.Appearance = appearance83;
            ultraGridColumn17.Header.Caption = "ItemID";
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn17.Width = 78;
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn18.Width = 209;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn19.Width = 262;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridColumn20.Width = 110;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn21.Width = 100;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21});
            this.OrdersGrid.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.OrdersGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.OrdersGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.OrdersGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.OrdersGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance84.BackColor = System.Drawing.Color.Transparent;
            this.OrdersGrid.DisplayLayout.Override.CardAreaAppearance = appearance84;
            this.OrdersGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance85.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance85.FontData.BoldAsString = "True";
            appearance85.FontData.Name = "Arial";
            appearance85.FontData.SizeInPoints = 10F;
            appearance85.ForeColor = System.Drawing.Color.White;
            appearance85.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.OrdersGrid.DisplayLayout.Override.HeaderAppearance = appearance85;
            this.OrdersGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance86.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.OrdersGrid.DisplayLayout.Override.RowSelectorAppearance = appearance86;
            this.OrdersGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance87.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.OrdersGrid.DisplayLayout.Override.SelectedRowAppearance = appearance87;
            this.OrdersGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.OrdersGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.OrdersGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.OrdersGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersGrid.Location = new System.Drawing.Point(3, 3);
            this.OrdersGrid.Name = "OrdersGrid";
            this.OrdersGrid.Size = new System.Drawing.Size(907, 522);
            this.OrdersGrid.TabIndex = 17;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.b_SaveNote);
            this.tabPage5.Controls.Add(this.txtText);
            this.tabPage5.Location = new System.Drawing.Point(4, 19);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(939, 811);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Notes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // b_SaveNote
            // 
            this.b_SaveNote.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.b_SaveNote.Location = new System.Drawing.Point(3, 71);
            this.b_SaveNote.Name = "b_SaveNote";
            this.b_SaveNote.Size = new System.Drawing.Size(163, 36);
            this.b_SaveNote.TabIndex = 19;
            this.b_SaveNote.Text = "Save Note";
            this.b_SaveNote.Click += new System.EventHandler(this.b_SaveNote_Click);
            // 
            // txtText
            // 
            this.txtText.AllowDrop = true;
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(0, 181);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(909, 606);
            this.txtText.TabIndex = 18;
            this.txtText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(19, 169);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 18);
            this.label25.TabIndex = 227;
            this.label25.Text = "Number Pallets :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(25, 141);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(87, 18);
            this.label39.TabIndex = 225;
            this.label39.Text = "Previous Retail :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 224;
            this.label11.Text = "Amount Due :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(49, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 223;
            this.label10.Text = "Sellers :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(49, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 222;
            this.label9.Text = "Items :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 221;
            this.label4.Text = "Payments :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 18);
            this.label12.TabIndex = 220;
            this.label12.Text = "Retail :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Location = new System.Drawing.Point(264, 116);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 224;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPrint,
            this.toolStripButton1,
            this.toolPrintSheet,
            this.toolPayments,
            this.toolStripSeparator3,
            this.toolOrder,
            this.toolStripSeparator1,
            this.toolPreInvoice,
            this.ParentLetterPDF,
            this.toolStripSeparator2,
            this.tPackingSlip,
            this.toolStripSeparator4,
            this.tProductSlip});
            this.tStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Padding = new System.Windows.Forms.Padding(0);
            this.tStrip.Size = new System.Drawing.Size(968, 25);
            this.tStrip.TabIndex = 54;
            this.tStrip.Text = "toolStrip1";
            // 
            // toolPrint
            // 
            this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(36, 22);
            this.toolPrint.Text = "Print";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(113, 22);
            this.toolStripButton1.Text = "Print Letter Aproval";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolPrintSheet
            // 
            this.toolPrintSheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintSheet.Name = "toolPrintSheet";
            this.toolPrintSheet.Size = new System.Drawing.Size(68, 22);
            this.toolPrintSheet.Text = "Print Sheet";
            this.toolPrintSheet.Click += new System.EventHandler(this.tooPrintSheet_Click);
            // 
            // toolPayments
            // 
            this.toolPayments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPayments.Image = ((System.Drawing.Image)(resources.GetObject("toolPayments.Image")));
            this.toolPayments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPayments.Name = "toolPayments";
            this.toolPayments.Size = new System.Drawing.Size(91, 22);
            this.toolPayments.Text = "Print Payments";
            this.toolPayments.Click += new System.EventHandler(this.toolPayments_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolOrder
            // 
            this.toolOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolOrder.Image")));
            this.toolOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOrder.Name = "toolOrder";
            this.toolOrder.Size = new System.Drawing.Size(41, 22);
            this.toolOrder.Text = "Order";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPreInvoice
            // 
            this.toolPreInvoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToPrinterToolStripMenuItem,
            this.sendByEmailPDFToolStripMenuItem});
            this.toolPreInvoice.Name = "toolPreInvoice";
            this.toolPreInvoice.Size = new System.Drawing.Size(83, 22);
            this.toolPreInvoice.Text = "Pre-Invoice";
            this.toolPreInvoice.ButtonClick += new System.EventHandler(this.toolPreInvoice_ButtonClick_1);
            // 
            // sendToPrinterToolStripMenuItem
            // 
            this.sendToPrinterToolStripMenuItem.Name = "sendToPrinterToolStripMenuItem";
            this.sendToPrinterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendToPrinterToolStripMenuItem.Text = "Send To Printer";
            this.sendToPrinterToolStripMenuItem.Click += new System.EventHandler(this.sendToPrinterToolStripMenuItem_Click);
            // 
            // sendByEmailPDFToolStripMenuItem
            // 
            this.sendByEmailPDFToolStripMenuItem.Name = "sendByEmailPDFToolStripMenuItem";
            this.sendByEmailPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendByEmailPDFToolStripMenuItem.Text = "Send by Email (PDF)";
            this.sendByEmailPDFToolStripMenuItem.Click += new System.EventHandler(this.sendByEmailPDFToolStripMenuItem_Click_1);
            // 
            // ParentLetterPDF
            // 
            this.ParentLetterPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ParentLetterPDF.Image = ((System.Drawing.Image)(resources.GetObject("ParentLetterPDF.Image")));
            this.ParentLetterPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParentLetterPDF.Name = "ParentLetterPDF";
            this.ParentLetterPDF.Size = new System.Drawing.Size(78, 22);
            this.ParentLetterPDF.Text = "Parent Letter";
            this.ParentLetterPDF.Click += new System.EventHandler(this.ParentLetterPDF_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tPackingSlip
            // 
            this.tPackingSlip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tPackingSlip.Image = ((System.Drawing.Image)(resources.GetObject("tPackingSlip.Image")));
            this.tPackingSlip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tPackingSlip.Name = "tPackingSlip";
            this.tPackingSlip.Size = new System.Drawing.Size(54, 22);
            this.tPackingSlip.Text = "PROMO";
            this.tPackingSlip.Visible = false;
            this.tPackingSlip.Click += new System.EventHandler(this.tPackingSlip_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tProductSlip
            // 
            this.tProductSlip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tProductSlip.Image = ((System.Drawing.Image)(resources.GetObject("tProductSlip.Image")));
            this.tProductSlip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tProductSlip.Name = "tProductSlip";
            this.tProductSlip.Size = new System.Drawing.Size(65, 22);
            this.tProductSlip.Text = "PRODUCT";
            this.tProductSlip.Visible = false;
            this.tProductSlip.Click += new System.EventHandler(this.tProductSlip_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(968, 905);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.tCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCustomer";
            this.ShowIcon = true;
            this.Text = "Customer Maintenance";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.Shown += new System.EventHandler(this.frmCustomer_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomer_FormClosing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.tCustomer, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.tCustomer.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbGiftAvenue)).EndInit();
            this.gbGiftAvenue.ResumeLayout(false);
            this.gbGiftAvenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductReturnedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbBOLTracking)).EndInit();
            this.gbBOLTracking.ResumeLayout(false);
            this.gbBOLTracking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGAOptions)).EndInit();
            this.gbGAOptions.ResumeLayout(false);
            this.gbGAOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLetterAproval)).EndInit();
            this.gbLetterAproval.ResumeLayout(false);
            this.gbLetterAproval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDeadLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCurrentStatus)).EndInit();
            this.gCurrentStatus.ResumeLayout(false);
            this.gCurrentStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGeneralInfoGroup)).EndInit();
            this.gbGeneralInfoGroup.ResumeLayout(false);
            this.gbGeneralInfoGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatePayable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbChairperson)).EndInit();
            this.gbChairperson.ResumeLayout(false);
            this.gbChairperson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBrochures)).EndInit();
            this.gbBrochures.ResumeLayout(false);
            this.gbBrochures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDates)).EndInit();
            this.gbDates.ResumeLayout(false);
            this.gbDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPickupDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbShippingOptions)).EndInit();
            this.gbShippingOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OpShipOption)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RGrid)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGrid)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
        #region Events

        void SystemTimer_Tick(object sender, EventArgs e)
        {
             SystemTimer.Stop();
             if (oCustomer.ID.Trim() != "")
             {
               //  if (oCustomer.HasChanged)
               //      btRefresh_Click(null, EventArgs.Empty);
             }
             //SystemTimer.Start();
             SystemTimer.Enabled = true;
           
        }
        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemTimer.Stop();
            SystemTimer.Dispose();
            e.Cancel = false;
        }

        private new void KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) 
		{   
                    #region txtText
            if (sender == txtText)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    return;
                }
            }
            #endregion
                    #region txtCustomerID
            if (sender == txtCustomerID)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtCustomerID.Text.Trim() == "")
                            {
                                txtCustomerID.Focus();
                                return;
                            }
                            txtCustomerID.Text = txtCustomerID.Text.Trim();
                            if (oCustomer.Find(txtCustomerID.Text))
                            {
                                txtCustomerID.Text = oCustomer.ID;
                                if (!Global.HasAccess("frmCustomer"))
                                    DisplayDisable();
                                Display();
                                return;
                            }
                            else
                                Clear();

                            
                        }
                    
                        if (e.KeyCode == Keys.F2 || ((e.Modifiers & Keys.Control) == Keys.Control) && e.KeyCode==Keys.F)
                        {
                            if (oCustomer.View())
                            {
                                txtCustomerID.Text = oCustomer.ID;
                                if (!Global.HasAccess("frmCustomer"))
                                    DisplayDisable();
                                Display();
                                
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.PageUp)
                        {
                          
                            frmShortage oShortage = new frmShortage(oCustomer);
                            if (txtCustomerID.Text.Trim() != "")
                            {
                             
                                oShortage.Show();
                            }

                            return;
                        }

                    }
            #endregion
                    #region txtRepID
                    if (sender == txtRepID)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oVoicemail.View())
                            {
                                txtRepID.Text = oVoicemail.ID;
                                if (oRep.Find(oVoicemail.RepID))
                                {
                                ctrRepName.Text = oRep.Name;
                                }
                            }

                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {

                            if (oVoicemail.Find(txtRepID.Text))
                            {
                                txtRepID.Text = oVoicemail.ID;
                                if (oRep.Find(oVoicemail.RepID))
                                {
                                    ctrRepName.Text = oRep.Name;
                                }
                            }
                            else
                                return;

                            
                        }

                    }
                    #endregion
                    #region txtPrizeID
                    if (sender == txtPrizeID)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oPrize.View())
                            {
                                txtPrizeID.Text = oPrize.ID;
                                ctrPrizeName.Text = oPrize.Description;
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtPrizeID.Text != "")
                            {
                                if (oPrize.Find(txtPrizeID.Text))
                                {
                                    txtPrizeID.Text = oPrize.ID;
                                    ctrPrizeName.Text = oPrize.Description;
                                }
                                else
                                    return;
                            }
                        }

                    }
                    #endregion
                    #region txtBrochureID
                    if (sender == txtBrochureID)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oBrochure.View())
                            {
                                txtBrochureID.Text = oBrochure.ID;
                                ctrBrochureName.Text = oBrochure.Description;
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtBrochureID.Text != "")
                            {
                                if (oBrochure.Find(txtBrochureID.Text))
                                {
                                    txtBrochureID.Text = oBrochure.ID;
                                    ctrBrochureName.Text = oBrochure.Description;
                                }
                                else
                                    return;
                            }

                            
                        }

                    }
                    #endregion
                    #region txtBrochureID_2
                    if (sender == txtBrochureID_2)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oBrochure.View())
                            {
                                txtBrochureID_2.Text = oBrochure.ID;
                                ctrBrochureName_2.Text = oBrochure.Description;
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtBrochureID_2.Text != "")
                            {
                                if (oBrochure.Find(txtBrochureID_2.Text))
                                {
                                    txtBrochureID_2.Text = oBrochure.ID;
                                    ctrBrochureName_2.Text = oBrochure.Description;
                                }
                                else
                                    return;
                            }
                        }

                    }
                    #endregion
                    #region txtBrochureID_3
                    if (sender == txtBrochureID_3)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oBrochure.View())
                            {
                                txtBrochureID_3.Text = oBrochure.ID;
                                ctrBrochureName_3.Text = oBrochure.Description;
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtBrochureID_3.Text != "")
                            {
                                if (oBrochure.Find(txtBrochureID_3.Text))
                                {
                                    txtBrochureID_3.Text = oBrochure.ID;
                                    ctrBrochureName_3.Text = oBrochure.Description;
                                }
                                else
                                    return;
                            }
                        }

                    }
                    #endregion
                    #region txtBrochureID_4
                    if (sender == txtBrochureID_4)
                    {
                        if (e.KeyCode.ToString() == "F2")
                        {
                            if (oBrochure.View())
                            {
                                txtBrochureID_4.Text = oBrochure.ID;
                                ctrBrochureName_4.Text = oBrochure.Description;
                            }
                            return;
                        }
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtBrochureID_4.Text != "")
                            {
                                if (oBrochure.Find(txtBrochureID_4.Text))
                                {
                                    txtBrochureID_4.Text = oBrochure.ID;
                                    ctrBrochureName_4.Text = oBrochure.Description;
                                }
                                else
                                    return;
                            }
                        }

                    }
                    #endregion

                    #region txtState
                    if (sender == txtState)
                    {
                        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab )
                        {
                            if (txtState.Text.ToUpper() == "CA")
                            {
                                this.LoadCounties();
                                this.SetTaxRate();
                            }
                            else
                                txtCounty.DropDownStyle = ComboBoxStyle.Simple;
                            
                        }
                    }
                    #endregion

                    #region txtCity
                    if (sender == txtCity)
                    {
                        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                        {
                            if (txtState.Text.ToUpper() == "CA")
                            {
                                this.SetTaxRate();
                            }
                        }
                    }
                    #endregion

                    #region txtSalesTax
                    if (sender == txtSalesTax)
                    {
                        if (e.KeyCode ==  Keys.F6)
                        {
                            if (txtState.Text.ToUpper() == "CA")
                            {
                                this.SetTaxRate();
                                return;
                            }
                        }
                    }
                    #endregion
                    
                    #region Default Option
                    //Default option
                    switch (e.KeyCode)
                    {
                        case Keys.Tab:
                            if (!e.Shift)
                                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                            break;
                        case Keys.Enter:
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                            break;
                        case Keys.Down:
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                            break;
                        case Keys.Up:
                            this.SelectNextControl(this.ActiveControl, false, true, true, true);
                            break;
                        case Keys.F8:
                            break;
                        case Keys.F3:
                            {
                                if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    MessageBox.Show("Operation Cancelled");
                                    return;
                                }
                                else
                                {
                                    if (oCustomer.NoSellers > 0)
                                    {
                                        MessageBox.Show("We can't delete this customer, because It has orders","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    CoverSheet oCover = new CoverSheet(CompanyID);
                                    if (oCover.Find(oCustomer.ID))
                                    {
                                        Inventory oInventory = new Inventory(CompanyID);
                                        oInventory.Update(oCover, Inventory.InventoryType.RollBack);
                                    }
                                    oCustomer.Delete();
                                    Clear();
                                    txtCustomerID.Focus();
                                }
                            }
                            break;
                        case Keys.F5:
                            Clear();
                            txtCustomerID.Focus();
                            break;
                        case Keys.F7:
                            this.Close();
                            break;
                        case Keys.S:
                        if ((e.Modifiers & Keys.Control) == Keys.Control)
                            if (txtCustomerID.Text.Trim() != "")
                            {
                                Save();
                                if (MessageBox.Show("Do you want to print?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    txtPrint_Click(null, null);
                                }
                                Clear();
                                txtCustomerID.Text = "";
                                txtCustomerID.Focus();

                            }
                            break;
                        case Keys.PageDown :
                            if (txtCustomerID.Text.Trim() != "")
                            {
                                Save();
                                oCustomer.GetCurrentTotalsByBrochure();
                                if (MessageBox.Show("Do you want to print?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    txtPrint_Click(null, null);
                                }
                                Clear();
                                txtCustomerID.Text = "";
                                txtCustomerID.Focus();

                            }
                            break;
                       

                        //case Keys.<some key>: 
                        // ......; 
                        // break; 
                    }
                    #endregion
                    e.Handled = true;
                    return;
		}
        private void tCustomer_Selected(object sender, TabControlEventArgs e)
        {
            switch (tCustomer.SelectedTab.Text)
            {
                case "General Information":
                    txtCustomerID.Focus();
                    break;
                case "Account Receivable":
                    {
                        if (txtCustomerID.Text != "")
                        {
                            RGrid.DataSource = oCustomer.GetPayments();
                        }
                    }
                    break;
                case "Order/Re-Order":
                    {
                        if (txtCustomerID.Text != "")
                        {
                            OrdersGrid.DataSource = oCustomer.GetOrders();
                        }
                    }
                    break;
                case "Brochures":
                    {
                        
                        if (txtCustomerID.Text != "")
                        {
                            if(oCustomer.HasChanged)
                                oCustomer.GetCurrentTotalsByBrochure();
                            //oCustomer.Brochures.Clear();
                            oCustomer.Brochures.Load(oCustomer.CompanyID, oCustomer.ID);
                            Grid.DataSource = oCustomer.Brochures.dtBrochures;
                            
                        }
                    }
                    break;
                case "Notes":
                    {

                        if (txtCustomerID.Text != "")
                        {
                            txtText.Focus();
                        }
                    }
                    break;

            }

        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            tStrip.Renderer = new Signature.Windows.Forms.WindowsVistaRenderer();
            if (!IsWebCustomer)
            {
                labGoal.Visible = false;
                txtGoal.Visible = false;
            }

            if (Global.HasAccess("frmCustomerDisc"))
            {
                lblOverage.Visible = true;
                txtOverage.Visible = true;
            }
            else
            {
                lblOverage.Visible = false;
                txtOverage.Visible = false;
            }


            if (IsGiftAvenue)
            {
                gbShippingOptions.Visible = false;
                gbLetterAproval.Visible = false;
                gbBOLTracking.Visible = true;
                gbGAOptions.Visible = true;
                gbGiftAvenue.Visible = true;

                gbGAOptions.Top = gbBrochures.Top + gbBrochures.Height + 3;
                gCurrentStatus.Top = gbGAOptions.Top + gbGAOptions.Height + 3;

                gCurrentStatus.Height = 233;

                gbGeneralInfoGroup.Height = gbGeneralInfoGroup.Height - 50;
                gbChairperson.Top = gbGeneralInfoGroup.Top + gbGeneralInfoGroup.Height + 3;
                gbDates.Top = gbChairperson.Top + gbChairperson.Height + 3;
                gbGiftAvenue.Top = gbDates.Top + gbDates.Height + 3;

                gbBOLTracking.Top = gbGiftAvenue.Top + gbGiftAvenue.Height + 3;
                
                lPickUpDate.Text = "Payment Due:";
                lShipdate.Text = "Prod Ship:";
                lDeliveryDate.Text = "Prod Del:";
                lPPickupDate.Text = "Prod Return:";
                

                               

                lRetail.Text = "Value:";
                txtPhoneNumberExt.Visible = false;

                lProfit.Visible = false;
                txtProfit.Visible = false;

                lAdded.Visible = false;
                txtAdded.Visible = false;
                lCharges.Visible = false;
                txtCharges.Visible = false;

                lFormerLastInvoicedAmount.Visible = false;
                txtFormerLastInvoicedAmount.Visible = false;
                cbEnrollmentForm.Visible = false;
                cb20062008.Visible = false;
                txtParentPickUpNote.Visible = true;
                txtLetterAproval.Visible = false;
                txtLastInvoiced.Visible = false;
                txtNoItems.Visible = false;
                txtNoSellers.Visible = false;
                txtNumberPallets.Visible = false;
                txtDiscDate.Visible = false;
                //txtCounty.Visible = false;
                txtPage.Visible = false;
                txtGrid.Visible = false;
                txtPostPay.Visible = false;
                txtHeadPhoneExt.Visible = false;
                txtCollectTax.Visible = false;
                txtFaxExt.Visible = false;
               // lCounty.Visible = false;
                lPage.Visible = false;
                lGrid.Visible = false;
                lPostPay.Visible = false;
                lCollectTax.Visible = false;
                lPhone.Visible = false;
                lLastInvoice.Visible = false;
                lItems.Visible = false;
                lSellers.Visible = false;
                lNumberPallets.Visible = false;
                lDiscrepancyDate.Visible = false;
                lHeadPhone.Visible = false;
                lPrize.Visible = false;
                txtPrizeID.Visible = false;
                txtInvoiced.Visible = false;
                lInvoiced.Visible = false;
                //lBOL.Visible = false;
                //txtBOLTraking.Visible = false;
                cbPrinted.Visible = false;
                txtPineValley.Visible = false;
                txtReceivedOrders.Visible = false;
                

                txtLetterAproval.Visible = false;
                txtSchoolUseOnly.Visible = false;
              //  cbChecked.Visible = false;
                lBrochure2.Text = "KIT:";

                txtShowXBash.Visible = false;
                txtSignedYN.Visible = false;
                txtProfitChanged.Visible = false;
                txtCompleted.Visible = false;
                txtChecked.Visible = false;
                txtOld.Visible = false;
                cbPrinted.Visible = false;

                frmInventory = new frmInventoryRealTime(this.CompanyID);
              //  txtBrochureID_3.Visible = false;
              //  ctrBrochureName_3.Visible = false;
             //   txtCODE3.Visible = false;
             //   txtProfitPercent_3.Visible = false;
             //   lBrochure_3.Visible = false;
             //   lCode_3.Visible = false;
             //   lProfit_3.Visible = false;
                

                txtRetail.Top = 15;
                lRetail.Top = 15;
                lTax.Top = 40;
                txtTax.Top = 40;
              //  lPayments.Top = 65;
              //  txtPayments.Top = 65;
                lAmountDue.Top = 90;
                txtAmountDue.Top = 90;
               

                lBoxes.Visible = false;
                txtBoxes.Visible = false;
                txtProductReturnedDate.Visible = false;

                

               // this.Height = 820;
                txtText.Text = oCustomer.oCustomerExtra.Note;

                
                if (this.CompanyID == "GA11")
                {
                    lbS2Full.Text = "F KIT 1";
                    lbS2Half.Text = "TB KIT 1";

                    lbS1Full.Text = "F KIT 2";
                    lbS1Half.Text = "H KIT 2";
                    lbTBin.Text   = "L KIT 2";


                    lbDS.Text = "TB F KIT 2";
                    label53.Text = "TB H KIT 2";


                    lbS2Low.Width = 62;
                    lbS2Low.Top = 82;
                    lbS2Low.Left = 229;
                    lbS2Low.Text = "TB L KIT 2";
                    txtSLow.Left = 296;
                    
                    
                    
                    

                    lbBBL.Text = "BAG BOX";
                    lMUG.Text = "MUG BOX 1";

                    //lbDS.Visible = false;
                    //txtDS.Visible = false;

                    

                    lbLE3.Visible = false;
                    txtLE3.Visible = false;

                    //lbLE3.Text = "STOCK:";

                    lbLE4.Text = "MUG BOX 2";
                    //lbLE4.Visible = false;
                    //txtLE4.Visible = false;

                    lbLE5.Visible = false;
                    txtLE5.Visible = false;

                    lbBBS.Visible = false;
                    txtBBS.Visible = false;

                    lbLEMOG.Visible = false;
                    txtLEMUG.Visible = false;

                    lbPROREG.Visible = false;
                    txtPROREG.Visible = false;

                    tPackingSlip.Visible = true;
                    tProductSlip.Visible = true;

                    //
                    gbGAOptions.Top = gbShippingOptions.Top + gbShippingOptions.Height + 3;
                    gbShippingOptions.Top = gbBrochures.Top + gbBrochures.Height + 3;
                    gbShippingOptions.Visible = true;
                    gCurrentStatus.Top = gbGAOptions.Top + gbGAOptions.Height + 3;
                    gCurrentStatus.Height = gCurrentStatus.Height - 75;
                    lPayments.Top = lPayments.Top - 30;
                    txtPayments.Top = txtPayments.Top - 30;
                }

                if (this.CompanyID == "GA10")
                {
                    lbS2Full.Text = "KIT2:";
                    lbS2Half.Text = "TBKIT2:";
                    lbS2Low.Text = "TBLKIT1:";
                    lbS1Full.Text = "FKIT1:";
                    lbS1Half.Text = "HKIT1:";
                    lbTBin.Text = "TBFKIT1:";
                    lbBBL.Text = "BAGBOX:";

                    //lbDS.Visible = false;
                    //txtDS.Visible = false;

                    lbDS.Text = "TBHKIT1:";

                    lbLE2.Visible = false;
                    txtLE2.Visible = false;

                    //lbLE3.Visible = false;
                    //txtLE3.Visible = false;

                    lbLE3.Text = "STOCK:";

                    lbLE4.Visible = false;
                    txtLE4.Visible = false;

                    lbLE5.Visible = false;
                    txtLE5.Visible = false;

                    lbBBS.Visible = false;
                    txtBBS.Visible = false;

                    lbLEMOG.Visible = false;
                    txtLEMUG.Visible = false;

                    lbPROREG.Visible = false;
                    txtPROREG.Visible = false;
                }
                


            }
            else
            {

                lFormerLastInvoicedAmount.Visible = false;
                txtFormerLastInvoicedAmount.Visible = false;
                
                cbRegisterReturned.Visible = false;
                cbProductReturned.Visible = false;
                gbGiftAvenue.Visible = false;
                gbGAOptions.Visible = false;
                toolOrder.Visible = false;
                toolPrintSheet.Visible = false;
                toolPayments.Visible = false;
               
                
                txtProductReturnedDate.Visible = false;
               // gCurrentStatus.Height = 340;
                //tCustomer.Height -= gbGiftAvenue.Height ;
                //Height = gbGiftAvenue.Height + 20;
                
            }

           // tCustomer.Height = this.Height - (this.tCustomer.Top + this.txtStatus.Height + 5);
            txtCustomerID.Focus();
            Clear();
        }
        private void tCustomer_Enter(object sender, EventArgs e)
        {
            txtCustomerID.Focus();
        }
        private void txtPrint_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
                oCustomer.Print();
                //oCustomer.PrintCustomerDateByPage();
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            oCustomer.GetCurrentTotalsByBrochure();
            ShowCurrentTotals();
        }
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            String myTargetURL;
            if (OpShipOption.CheckedIndex > -1)

                switch (Convert.ToInt16(OpShipOption.Items[OpShipOption.CheckedIndex].DataValue))
                {

                    case 0:
                        myTargetURL = "http://www.fedexnational.fedex.com/us/OnlineTools/ShipmentTracking/default.asp";
                        System.Diagnostics.Process.Start(myTargetURL);
                        break;
                    case 1:
                        myTargetURL = "http://www.fedexfreight.fedex.com/track.jsp?link=1&lid=//Track//FDF+Track+PRO";
                        System.Diagnostics.Process.Start(myTargetURL);
                        break;
                }

            else
                oCustomer.ShipOption = 0;
        }
        private void txtPostPay_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                lbPayableTo.Visible = true;
                txtPayableTo.Visible = true;

                lbDatePayable.Visible = true;
                txtDatePayable.Visible = true;
            }
            else
            {
                lbPayableTo.Visible = false;
                txtPayableTo.Visible = false;

                lbDatePayable.Visible = false;
                txtDatePayable.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                oDoc = new ParseWordDocument();
                oDoc.Open("ABC.dot");

                oDoc.AddRange(new String[,] { { "CODE", oCustomer.ID.Trim() + " " + oCustomer.State + " " + oCustomer.StartDate.ToString("MM.dd")}, 
                                { "REP", ctrRepName.Text }, 
                                { "CHAIRPERSON", txtChairperson.Text }, 
                                { "FAX", (txtFax.Text=="")?" ":Global.FormatPhone(txtFax.Text) }, 
                                { "SCHOOLNAME", txtName.Text },
                                { "EMAIL",(txteMail.Text=="")?" ":txteMail.Text},
                                { "ENDDATE",((DateTime)txtDateDeadLine.Value).ToLongDateString()},
                                { "STARTDATE",((DateTime)txtStartDate.Value).ToLongDateString()}
                                });
                oDoc.Parse();
                oDoc.Print();
                oDoc.Save();
                oDoc.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                oDoc = new ParseWordDocument();
                if (oCustomer.oCustomerExtra.isKastleKreation)
                    oDoc.Open("KastleKreation.dot");
                else
                    oDoc.Open("ABC.dot");

                oDoc.AddRange(new String[,] { { "CODE", oCustomer.ID.Trim() + " " + oCustomer.State + " " + oCustomer.StartDate.ToString("MM.dd")}, 
                                { "REP", ctrRepName.Text }, 
                                { "CHAIRPERSON", txtChairperson.Text }, 
                                { "FAX", (txtFax.Text=="")?" ":Global.FormatPhone(txtFax.Text) }, 
                                { "SCHOOLNAME", txtName.Text },
                                { "EMAIL",(txteMail.Text=="")?" ":txteMail.Text},
                                { "ENDDATE",((DateTime)txtDateDeadLine.Value).ToLongDateString()},
                                { "STARTDATE",((DateTime)txtStartDate.Value).ToLongDateString()}
                                });
                oDoc.Parse();
                oDoc.Print();
                oDoc.Save();
                oDoc.Close();

                ApplicationClass objOutlook = new ApplicationClass();
                MailItem objMail = (MailItem)objOutlook.CreateItem(OlItemType.olMailItem);
                objMail.To = txteMail.Text;
                if (oCustomer.oCustomerExtra.isKastleKreation)
                    objMail.Subject = "Kastle Kreations – Signature Letter Approval for "+ oCustomer.Name;
                else
                    objMail.Subject = oCustomer.Name + "  " + oCustomer.ID.Trim() + " " + oCustomer.State + " " + oCustomer.StartDate.ToString("MM.dd");

                objMail.Body = "Please review the attached sheets regarding your upcoming Fundraiser.\r\n" +
                                "Please respond no later than the noted date so we can revise your Parent letter as needed.\r\n" +
                                "If you have any questions or comments, please feel free to contact me.\r\n\r\n" +
                                "Thank You,\r\n\r\n" +
                                "Myrna Factuar\r\n" +
                                "Customer Service/Letter Dept.\r\n" +
                                "Signature Fundraising\r\n" +
                                "800-645-3863 ext. 137\r\n" +
                                "800-898-7702 Fax\r\n" +
                                "myrna@sigfund.com\r\n";

                //objMail.Save();     
                //objMail.Send();

                objMail.Attachments.Add(oDoc.destination.ToString(), OlAttachmentType.olByValue, 2, "MyAttachment");

                NameSpace objNS = objOutlook.GetNamespace("MAPI");
                objNS.Logon(null, null, false, true);
                object True = true;
                objMail.Display(True);
                objNS.Logoff();
            }

        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim().Length > 0)
            {
                if (oCustomer.Find(txtCustomerID.Text))
                {
                    txtCustomerID.Text = oCustomer.ID;
                    if (!Global.HasAccess("frmCustomer"))
                        DisplayDisable();
                    Display();
                    return;
                }

            }
        }

        private void frmCustomer_Shown(object sender, EventArgs e)
        {
            if (IsGiftAvenue)
                gbGAOptions.Visible = true;
        }

        private void ShowOrder()
        {
            Order oOrder = new Order(this.CompanyID);
            oOrder.CustomerID = this.oCustomer.ID;

            frmOrder ofrmOrder = new frmOrder(oOrder);
            ofrmOrder._OrderProcess = OrderProcess.GiftAvenue;
            ofrmOrder.Show();

        }

        private void bOrder_Click(object sender, EventArgs e)
        {
            if (this.IsGiftAvenue)
            {
                this.ShowOrder();
            }

        }

        private void bPrintSheet_Click(object sender, EventArgs e)
        {
            frmDevice ofrm = new frmDevice();
            ofrm.eMail = txteMail.Text;
            ofrm.ShowDialog();

            if (ofrm.PrintDevice != PrinterDevice.None)
            {
                if (oCustomer.PrintFinalBillTally(ofrm.PrintDevice, ofrm.eMail) && oCustomer.PrintInventoryBox(ofrm.PrintDevice, ofrm.eMail) && ofrm.PrintDevice == PrinterDevice.eMail)
                    MessageBox.Show("Your emails have been sent!");
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
                oCustomer.Print();
        }

        private void toolOrder_Click(object sender, EventArgs e)
        {
            if (this.IsGiftAvenue)
            {
                this.ShowOrder();
            }
        }

        private void tooPrintSheet_Click(object sender, EventArgs e)
        {
            frmDevice ofrm = new frmDevice();
            ofrm.eMail = txteMail.Text;
            ofrm.ShowDialog();

            if (ofrm.PrintDevice != PrinterDevice.None)
            {
                if (oCustomer.PrintFinalBillTally(ofrm.PrintDevice, ofrm.eMail) && oCustomer.PrintInventoryBox(ofrm.PrintDevice, ofrm.eMail) && ofrm.PrintDevice == PrinterDevice.eMail)
                    MessageBox.Show("Your emails have been sent!");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                oDoc = new ParseWordDocument();
                oDoc.Open("ABC.dot");

                oDoc.AddRange(new String[,] { { "CODE", oCustomer.ID.Trim() + " " + oCustomer.State + " " + oCustomer.StartDate.ToString("MM.dd")}, 
                                { "REP", ctrRepName.Text }, 
                                { "CHAIRPERSON", txtChairperson.Text }, 
                                { "FAX", (txtFax.Text=="")?" ":Global.FormatPhone(txtFax.Text) }, 
                                { "SCHOOLNAME", txtName.Text },
                                { "EMAIL",(txteMail.Text=="")?" ":txteMail.Text},
                                { "ENDDATE",((DateTime)txtDateDeadLine.Value).ToLongDateString()},
                                { "STARTDATE",((DateTime)txtStartDate.Value).ToLongDateString()}
                                });
                oDoc.Parse();
                oDoc.Print();
                oDoc.Save();
                oDoc.Close();
            }
        }

        private void toolPayments_Click(object sender, EventArgs e)
        {
            Company oCompany = new Company();
            oCompany.PrintGAPaymentList(true,false);
        }

        private void cbProductReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbProductReturned.Checked)
            {
                lBoxes.Visible = false;
                txtBoxes.Visible = false;
                txtProductReturnedDate.Visible = false;
            }
            else
            {
                lBoxes.Visible = true;
                txtBoxes.Visible = true;
                txtProductReturnedDate.Visible = true;
            }

        }

        private void b_SaveNote_Click(object sender, EventArgs e)
        {
            oCustomer.oCustomerExtra.Note = txtText.Text;
            oCustomer.oCustomerExtra.Save();
            MessageBox.Show("Note Saved!");
        }

        private void sendToPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String PrinterName = Global.OpenPrintDialog();
            if (PrinterName != "")
            {
                Invoice oInvoice = new Invoice(this.CompanyID);
                oInvoice.Find(oCustomer.ID);
                oInvoice.Print(PrintTo.Printer, PrinterName, "", true);
            }
        }

        private void sendByEmailPDFToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Invoice oInvoice = new Invoice(this.CompanyID);
            oInvoice.Find(oCustomer.ID);
            oInvoice.Print(PrintTo.File, "PDF", "", true);
        }

        private void toolPreInvoice_ButtonClick_1(object sender, EventArgs e)
        {
            Invoice oInvoice = new Invoice(this.CompanyID);
            oInvoice.Find(oCustomer.ID);
            oInvoice.Print(PrintTo.Viewer, "", "", true);
        }

        private void ParentLetterPDF_Click(object sender, EventArgs e)
        {
            oCustomer.PrintAttentionParents("", PrinterDevice.eMail);
            oCustomer.oCustomerExtra.Save();
        }

        #endregion

        #region Methods
        private void ShowCurrentTotals()
        {
            txtRetail.Text = oCustomer.Retail.ToString();
            txtBoxCount.Text = oCustomer.NoBoxes.ToString();
            txtNoItems.Text = oCustomer.NoItems.ToString();
            txtNoSellers.Text = oCustomer.NoSellers.ToString();
            txtInvoiced.Text = oCustomer.InvoicedAmount.ToString();
            txtProfit.Text = oCustomer.ProfitAmount.ToString();
            txtAmountDue.Text = oCustomer.AmountDue.ToString();
            txtAdded.Text = oCustomer.AddedAmount.ToString();
            txtLastInvoiced.Text = oCustomer.LastInvoicedAmount.ToString();
            txtTax.Text = oCustomer.TaxAmount.ToString();
            txtPayments.Text = oCustomer.GetPaymentsAmount().ToString();
            txtCharges.Text = oCustomer.ChargesAmount.ToString();
            
            /*
            if (oCustomer.FormerLastInvoicedAmount > 0)
            {
                lFormerLastInvoicedAmount.Visible = true;
                txtFormerLastInvoicedAmount.Visible = true;
            }
            else
            {
                lFormerLastInvoicedAmount.Visible = false;
                txtFormerLastInvoicedAmount.Visible = false;
            }
            */
            txtFormerLastInvoicedAmount.Text = oCustomer.FormerLastInvoicedAmount.ToString();
            txtOverage.Text = oCustomer.GetTotalOverageAmount().ToString();

        }
        public void DisplayDisable()
        {


            txtName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtZipCode.ReadOnly = true;
           // txtCounty.ReadOnly = true;

            
            txteMail.ReadOnly = true;
            txtChairperson.ReadOnly = true;
            //frm.this.Info.RepID
            txtPhoneNumber.ReadOnly = true;
            txtHeadPhoneExt.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtFaxExt.Enabled = false;
            txtHeadPhone.ReadOnly = true;
            txtPhoneNumberExt.ReadOnly = true;


            txtStartDate.ReadOnly = true;
            txtEndDate.ReadOnly = true;
            txtPickUpDate.ReadOnly = true;
            txtPPickupDate.ReadOnly = true;
            txtShipDate.ReadOnly = true;
            txtSignedDate.ReadOnly = true;
            txtDeliveryDate.ReadOnly = true;

            txtCODE1.ReadOnly = true;

            txtCODE2.ReadOnly = true;
            txtProfitPercent.ReadOnly = true;
            txtProfitPercent_2.ReadOnly = true;
            txtRetail.ReadOnly = true;
            txtPrevRetail.ReadOnly = true;
            txtPayments.ReadOnly = true;
            txtAmountDue.ReadOnly = true;
            txtNoItems.ReadOnly = true;
            txtNoSellers.ReadOnly = true;
            txtSigned.ReadOnly = true;


            txtPrizeID.ReadOnly = true;

            ctrPrizeName.Enabled = false;

            txtNumberPallets.ReadOnly = true;

            txtRepID.ReadOnly = true;

            ctrRepName.Enabled = false;

            txtBrochureID.ReadOnly = true;

            ctrBrochureName.Enabled = false;

            txtBrochureID_2.ReadOnly = true;

            ctrBrochureName_2.Enabled = false;

                //Invoiced Amounts

            txtInvoiced.ReadOnly = true;
            txtSalesTax.ReadOnly = true;
            txtTax.ReadOnly = true;

            txtRetail.ReadOnly = true;

            txtSignedNote.ReadOnly = true;
            txtStartNote.ReadOnly = true;
            txtEndNote.ReadOnly = true;
            txtPickUpNote.ReadOnly = true;
            txtShipNote.ReadOnly = true;
            txtDeliveryNote.ReadOnly = true;
            txtParentPickUpNote.ReadOnly = true;

            txtApplyTax.Enabled = false;

            txtCollectTax.Enabled = false;

            txtPage.ReadOnly = true;
            txtGrid.ReadOnly = true;
            txtCharges.ReadOnly = true;

            txtDiscDate.Enabled = false;
            // txtProfitPercent_2.Value = oCustomer.ProfitPercent_2;

            cbChecked.Enabled = false;

            lblOverage.Visible = false;
            txtOverage.Visible = false;

            
        }
        public void Display()
        {

            Clear();
            DateTime DNull = new DateTime(1900, 01, 01);
            txtName.Text = this.oCustomer.Name;
            txtAddress.Text = this.oCustomer.Address;
            txtCity.Text = this.oCustomer.City;
            txtState.Text = this.oCustomer.State;
            txtZipCode.Text = this.oCustomer.ZipCode;
            txtCounty.Text = this.oCustomer.County;

            txteMail.Text = this.oCustomer.eMail;
            txtChairperson.Text = this.oCustomer.Chairperson;
            txtPhoneNumber.Text = this.oCustomer.PhoneNumber;       //Chairperson
            txtPhoneNumberExt.Text = oCustomer.PhoneNumberExt;
            txtFax.Text = this.oCustomer.FaxNumber;
            
            txtHeadPhone.Text = this.oCustomer.HeadPhone;
            txtHeadPhoneExt.Text = oCustomer.HeadPhoneExt;
            
            
            //frm.this.Info.PrizeID=rCustomer["PrizeID"].ToString();

            if (oCustomer.StartDate == DNull)
                txtStartDate.Value = null;
            else
                txtStartDate.Value = oCustomer.StartDate;

            if (oCustomer.EndDate == DNull)
                txtEndDate.Value = null;
            else
                txtEndDate.Value = oCustomer.EndDate;
            if (oCustomer.PickUpDate == DNull)
                txtPickUpDate.Value = null;
            else
                txtPickUpDate.Value = oCustomer.PickUpDate;

            if (oCustomer.ParentPickUpDate == DNull)
                txtPPickupDate.Value = null;
            else
                txtPPickupDate.Value = oCustomer.ParentPickUpDate;

            if (oCustomer.ShipDate == DNull)
                txtShipDate.Value = null;
            else
                txtShipDate.Value = oCustomer.ShipDate;
            if (oCustomer.SignedDate == DNull)
                txtSignedDate.Value = null;
            else
                txtSignedDate.Value = oCustomer.SignedDate;
            if (oCustomer.DeliveryDate == DNull)
                txtDeliveryDate.Value = null;
            else
                txtDeliveryDate.Value = oCustomer.DeliveryDate;

            if (oCustomer.DiscrepancyDate == DNull)
                txtDiscDate.Value = null;
            else
                txtDiscDate.Value = oCustomer.DiscrepancyDate;
            
            
            txtCODE1.Value = this.oCustomer.CODE1;
            txtCODE2.Value = this.oCustomer.CODE2;
            txtCODE3.Value = this.oCustomer.CODE3;
            txtCODE4.Value = this.oCustomer.CODE4;

            txtProfitPercent.Text = this.oCustomer.ProfitPercent.ToString();
            txtProfitPercent_2.Text = this.oCustomer.ProfitPercent_2.ToString();
            txtProfitPercent_3.Text = this.oCustomer.ProfitPercent_3.ToString();
            txtProfitPercent_4.Text = this.oCustomer.ProfitPercent_4.ToString();

            txtPrevRetail.Text = this.oCustomer.PreviousRetail.ToString();
            txtSigned.Value = this.oCustomer.Signed;
            txtPrizeID.Text = oCustomer.PrizeID;
            oPrize.Find(oCustomer.PrizeID);
            ctrPrizeName.Text = oPrize.Description;
            txtNumberPallets.Value = oCustomer.NumberPallets;


            if (oVoicemail.Find(oCustomer.Rep_Ext))
            {
                txtRepID.Text = oVoicemail.ID;
                if (oRep.Find(oVoicemail.RepID))
                {
                    ctrRepName.Text = oRep.Name;
                }
            }

            ctrRepName.Text = oRep.Name;

            txtBrochureID.Text = oCustomer.BrochureID;
            oBrochure.Find(oCustomer.BrochureID);
            ctrBrochureName.Text = oBrochure.Description;

            txtBrochureID_2.Text = oCustomer.BrochureID_2;
            txtBrochureID_3.Text = oCustomer.BrochureID_3;
            txtBrochureID_4.Text = oCustomer.BrochureID_4;
            
            oBrochure.Find(oCustomer.BrochureID_2);
            ctrBrochureName_2.Text = oBrochure.Description;

            oBrochure.Find(oCustomer.BrochureID_3);
            ctrBrochureName_3.Text = oBrochure.Description;

            oBrochure.Find(oCustomer.BrochureID_4);
            ctrBrochureName_4.Text = oBrochure.Description;
            
            txtSignedNote.Text = oCustomer.SignedNote;
            txtStartNote.Text = oCustomer.StartNote;
            txtEndNote.Text = oCustomer.EndNote;
            txtPickUpNote.Text = oCustomer.PickUpNote;
            txtShipNote.Text = oCustomer.ShipNote;
            txtDeliveryNote.Text = oCustomer.DeliveryNote;
            txtParentPickUpNote.Text = oCustomer.ParentPickUpNote;
            txtSalesTax.Value = oCustomer.SalesTax;

            switch (oCustomer.ApplyTax)
            {
                case "N":
                    txtApplyTax.Text = "No";
                    break;
                case "Y":
                    txtApplyTax.Text = "Yes";
                    break;
                case "R":
                    txtApplyTax.Text = "Retail";
                    break;
                default:
                    txtApplyTax.Text = "No";
                    break;

            }

            switch (oCustomer.CollectTax)
            {
                case "N":
                    txtCollectTax.Text = "No";
                    break;
                case "R":
                    txtCollectTax.Text = "Retail";
                    break;
                case "W":
                    txtCollectTax.Text = "Wholesale";
                    break;
                default:
                    txtCollectTax.Text = "No";
                    break;

            }

            txtPage.Text = oCustomer.Page;
            txtGrid.Text = oCustomer.Grid;
            txtLetterAproval.Checked = oCustomer.IsLetterAprovalDone;

            if (oCustomer.HasChanged)
            {
                //oCustomer.GetCurrentTotals();
                Double DropPercentageCustomer = 0.00;
                Double DropPercentageItem = 0.00;
                if (oCustomer.Retail < 2500 && !this.IsGiftAvenue)
                {
                    DataTable dtInv = oCustomer.GetCurrentTotalsByBrochure();
                    if (dtInv != null)
                    {
                        if (oCustomer.LastInvoicedAmount == 0 && oCustomer.Retail < 2500 && oCustomer.Retail > 0)
                        {   
                            DropPercentageCustomer = -5.00;
                        }
                        DropPercentageItem = -5.00;
                    }
                    else
                        return;
                }
                oCustomer.GetCurrentTotalsByBrochure(DropPercentageCustomer, DropPercentageItem);
                oCustomer.HasChanged = false;
            }

            //Invoiced Amounts
            ShowCurrentTotals();


            OpShipOption.CheckedIndex = oCustomer.ShipOption - 1;
            txtBOLTraking.Text = oCustomer.BOLTraking;

            txtPayableTo.Text = oCustomer.PayableTo;
            txtPostPay.Checked = oCustomer.IsPostPay;
            if (oCustomer.DatePayable == DNull)
                txtDatePayable.Value = null;
            else
                txtDatePayable.Value = oCustomer.DatePayable;

            if (oCustomer.IsPostPay)
            {
                lbPayableTo.Visible = true;
                txtPayableTo.Visible = true;
                lbDatePayable.Visible = true;
                txtDatePayable.Visible = true;
            }
            txtSchoolUseOnly.Checked = oCustomer.SchoolUseOnly;
            cbChecked.Checked = oCustomer.Checked;
            cbPrinted.Checked = oCustomer.Printed;

            cbOneDaySale.Checked = oCustomer.IsOneDaySale;
            txtCashRegisters.Value = oCustomer.CashRegisters;
            cbTreasureChest.Checked = oCustomer.IsTreasureChest;
            cbAssigned.Checked = oCustomer.IsAssigned;


            txtText.Text = oCustomer.oCustomerExtra.Note;
            cbEnrollmentForm.Checked = oCustomer.oCustomerExtra.isEnrollmentForm;
            cb20062008.Checked = oCustomer.oCustomerExtra.is20062008;
            txtPineValley.Checked = oCustomer.oCustomerExtra.isPineValley;
            txtOld.Checked = oCustomer.oCustomerExtra.isOld;
            txtEmailSecondary.Text = oCustomer.oCustomerExtra.eMail;
            txtShowXBash.Checked = oCustomer.oCustomerExtra.isShowXBash;
            txtSignedYN.Checked = oCustomer.oCustomerExtra.isSigned;
            txtChecked.Checked = oCustomer.oCustomerExtra.isChecked;
            txtCompleted.Checked = oCustomer.oCustomerExtra.isCompleted;
            txtReceivedOrders.Checked = oCustomer.oCustomerExtra.isReceivedOrders;
            txtProfitChanged.Checked = oCustomer.oCustomerExtra.isProfitChanged;
            cbGrouped.Checked = oCustomer.oCustomerExtra.isGrouped;
            cbAMDelivery.Checked = oCustomer.oCustomerExtra.isAMDelivery;
            cbKastleKreation.Checked = oCustomer.oCustomerExtra.isKastleKreation;
            cbBlueDog.Checked = oCustomer.oCustomerExtra.isBlueDog;
            cbBlueDogContract.Checked = oCustomer.oCustomerExtra.isBlueDogContract;
            cbKK.Checked = oCustomer.oCustomerExtra.isKK;

            if (oCustomer.State.Trim() == "CA")
            {
                
                this.LoadCounties();
            }
            else
                txtCounty.DropDownStyle = ComboBoxStyle.Simple;
            
            //Gift Avenue Specific Features
            if (IsGiftAvenue)
            {
                
                
                txtTax.Value = Math.Round(oCustomer.GetPaymentsAmount() * (oCustomer.ApplyTax=="Y"?oCustomer.SalesTax/100:0),2);
                
                txtSFull.Text       = oCustomer.oGiftAvenue.SFull.ToString();
                txtSHalf.Text       = oCustomer.oGiftAvenue.SHalf.ToString();
                txtSLow.Text        = oCustomer.oGiftAvenue.SLow.ToString();
                txtTBin.Text        = oCustomer.oGiftAvenue.TBin.ToString();
                txtLE1.Text         = oCustomer.oGiftAvenue.LE1.ToString();
                txtLE2.Text         = oCustomer.oGiftAvenue.LE2.ToString();
                txtLE3.Text         = oCustomer.oGiftAvenue.LE3.ToString();
                txtLE4.Text         = oCustomer.oGiftAvenue.LE4.ToString();
                txtLE5.Text         = oCustomer.oGiftAvenue.LE5.ToString();
                txtLETX.Text        = oCustomer.oGiftAvenue.LETX.ToString();
                txtDS.Text          = oCustomer.oGiftAvenue.DS.ToString();
                bKitAssigned.Checked= oCustomer.oGiftAvenue.KitAssigned;
                cbWDS.Checked       = oCustomer.oGiftAvenue.WDS;

                txtS1Full.Text = oCustomer.oGiftAvenue.S1Full.ToString();
                txtS1Half.Text = oCustomer.oGiftAvenue.S1Half.ToString();
                txtBBL.Text    = oCustomer.oGiftAvenue.BBL.ToString();
                txtBBS.Text    = oCustomer.oGiftAvenue.BBS.ToString();
                txtMUG.Text    = oCustomer.oGiftAvenue.MUG.ToString();
                txtLEMUG.Text = oCustomer.oGiftAvenue.LEMUG.ToString();
                txtPROREG.Text = oCustomer.oGiftAvenue.PROREG.ToString();
                txtLKit1.Text = oCustomer.oGiftAvenue.LowKit1.ToString();

                cbEnrollmentForm.Visible = false;
                cb20062008.Visible = false;
                cbProductOrdered.Checked = oCustomer.oGiftAvenue.IsProductOrdered;
                cbPromoShipped.Checked = oCustomer.oGiftAvenue.PromoShipped;
                cbProductShipped.Checked = oCustomer.oGiftAvenue.ProductShipped;
                cbCoupon.Checked = oCustomer.oGiftAvenue.IsCoupon;
                

                if (cbProductReturned.Checked)
                {
                    cbProductReturned.Visible = true;
                    txtBoxes.Visible = true;
                    txtProductReturnedDate.Visible = true;
                }
                cbRegisterReturned.Checked = oCustomer.oGiftAvenue.IsRegisterReturned;
                cbProductReturned.Checked = oCustomer.oGiftAvenue.IsProductReturned;
                txtBoxes.Value = oCustomer.oGiftAvenue.BoxesReturned;
                if (oCustomer.oGiftAvenue.ProductReturnedDate == DNull)
                    txtProductReturnedDate.Value = null;
                else
                    txtProductReturnedDate.Value = oCustomer.oGiftAvenue.ProductReturnedDate;


                if (CompanyID == "GPI11")
                {
                    
                }

                if (frmInventory.IsDisposed)
                    frmInventory = new frmInventoryRealTime(this.CompanyID);
                
                frmInventory._Top = this.Top;
                frmInventory._Left = this.Left + this.Width + 20;
                frmInventory.Invalidate();
                frmInventory.Show();
                this.Activate();
                
            }
            
        }
        private void LoadCounties()
        {
            txtCounty.DropDownStyle = ComboBoxStyle.DropDown;
            txtCounty.Items.Add("Fresno".ToUpper());
            txtCounty.Items.Add("Imperial".ToUpper());
            txtCounty.Items.Add("Kern".ToUpper());
            txtCounty.Items.Add("Los Angeles".ToUpper());
            txtCounty.Items.Add("Modesto".ToUpper());
            txtCounty.Items.Add("Orange".ToUpper());
            txtCounty.Items.Add("Riverside".ToUpper());
            txtCounty.Items.Add("Sacramento".ToUpper());
            txtCounty.Items.Add("San Bernardino".ToUpper());
            txtCounty.Items.Add("San Diego".ToUpper());
            txtCounty.Items.Add("San Joaquin".ToUpper());
            txtCounty.Items.Add("San Luis Obispo".ToUpper());
            txtCounty.Items.Add("Santa Barbara".ToUpper());
            txtCounty.Items.Add("Stanislaus".ToUpper());
            txtCounty.Items.Add("Tulare".ToUpper());
            txtCounty.Items.Add("Ventura".ToUpper());
            //txtCounty.Invalidate();
        }
        private void SetTaxRate()
        {
           txtSalesTax.Text = oCustomer.GetTaxRate(txtCity.Text).ToString();
        }
        private void Clear()
        {
//            txtCustomerID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZipCode.Clear();
            txtCounty.Text = "";
            txteMail.Clear();
            txtChairperson.Clear();
            txtRepID.Clear();
            //txtPrize
            txtPhoneNumber.Clear();
            txtPhoneNumberExt.Clear();

            txtFax.Clear();
            txtFaxExt.Clear();
            txtHeadPhone.Clear();
            txtHeadPhoneExt.Clear();
            txtStartDate.Value = null;
            txtEndDate.Value = null;
            txtShipDate.Value = null;
            txtSignedDate.Value = null;
            txtPickUpDate.Value = null;
            txtPPickupDate.Value = null;
            txtDeliveryDate.Value = null;
            //txtCashier
            //txtKITS.Clear();
            txtCODE1.Clear();
            txtCODE3.Clear();
            txtCODE2.Clear();
            txtCODE4.Clear();

            txtBrochureID.Clear();
            txtBrochureID_2.Clear();
            txtBrochureID_3.Clear();
            txtBrochureID_4.Clear();

            txtProfitPercent.Clear();
            txtProfitPercent_2.Clear();
            txtProfitPercent_3.Clear();
            txtProfitPercent_4.Clear();

            txtSigned.Clear();
            txtSignedNote.Clear();
            txtStartNote.Clear();
            txtEndNote.Clear();
            txtPickUpNote.Clear();
            txtShipNote.Clear();
            txtDeliveryNote.Clear();
            txtParentPickUpNote.Clear();
            txtPrevRetail.Clear();
            ctrBrochureName.Text = "";
            ctrBrochureName_2.Text = "";
            ctrBrochureName_3.Text = "";
            ctrRepName.Text = "";
            txtPrizeID.Clear();
            ctrPrizeName.Text = "";
            txtSalesTax.Clear();
            txtApplyTax.Text = "";
            txtCollectTax.Text = "";
            txtPage.Clear();
            txtGrid.Clear();

            txtCharges.Text = "";
            txtAmountDue.Text = "";
            txtAdded.Text = "";
            txtProfit.Text = "";
            txtNoItems.Clear();
            txtNoSellers.Clear();
            txtBoxCount.Clear();
            txtInvoiced.Clear();

            txtDiscDate.Clear();
            txtLetterAproval.Checked = false;

            OpShipOption.CheckedIndex = -1;
            txtBOLTraking.Text = "";

            txtPayableTo.Text = "";
            txtPostPay.Checked = false;

            txtSchoolUseOnly.Checked = false;
            cbChecked.Checked = false;
            cbPrinted.Checked = false;

            txtCashRegisters.Value = 0;
            cbOneDaySale.Checked = false;
            cbAssigned.Checked = false;
            cbTreasureChest.Checked = false;
            txtDateDeadLine.Value = DateTime.Now;
            txtGoal.Clear();
            cbEnrollmentForm.Checked = false;
            cb20062008.Checked = false;
            txtPineValley.Checked = false;
            txtOld.Checked = false;
            txtEmailSecondary.Clear();
            txtCounty.Items.Clear();
            txtDatePayable.Value = DateTime.Today;
            txtShowXBash.Checked = false;
            txtSignedYN.Checked = false;
            txtChecked.Checked = false;
            txtCompleted.Checked = false;
            txtReceivedOrders.Checked = false;
            txtProfitChanged.Checked = false;
            cbGrouped.Checked = false;

            //Gift Avenue Specific Features
            if (IsGiftAvenue)
            {
                txtSFull.Text = "";
                txtSHalf.Text = "";
                txtSLow.Text = "";
                txtTBin.Text = "";
                txtLE1.Text = "";
                txtLE2.Text = "";
                txtLE3.Text = "";
                txtLE4.Text = "";
                txtLE5.Text = "";
                txtLETX.Text = "";
                txtDS.Text = "";
                bKitAssigned.Checked = false;
                cbProductOrdered.Checked = false;

                cbProductReturned.Checked = false;
                txtBoxes.Value = 0;
                txtProductReturnedDate.Value = null;
                cbRegisterReturned.Checked = false;
                cbWDS.Checked = false;

                txtS1Full.Text  = "";
                txtS1Half.Text  = "";
                txtBBS.Text     = "";
                txtBBL.Text     = "";
                txtMUG.Text     = "";
                txtLEMUG.Text   = "";
                txtLKit1.Text = "";

                                cbProductShipped.Checked = false;
                cbPromoShipped.Checked = false;
                cbCoupon.Checked = false;
            }
            txtText.Text = "";
            txtOverage.Clear();
            cbAMDelivery.Checked = false;
            cbKastleKreation.Checked = false;
            cbBlueDog.Checked = false;
            cbBlueDogContract.Checked = false;
            cbKK.Checked = false;
            return;
            
        }
        private void Save()
        {
            
            SystemTimer.Stop();
            SystemTimer.Enabled = false;

            DateTime DNull = new DateTime(1900, 01, 01);

            oCustomer.ID = txtCustomerID.Text;
            oCustomer.Name = txtName.Text;
            oCustomer.Address = txtAddress.Text;
            oCustomer.City = txtCity.Text;
            oCustomer.State = txtState.Text;
            oCustomer.ZipCode = txtZipCode.Value.ToString();
            oCustomer.County = txtCounty.Text;        


            oCustomer.eMail = txteMail.Text;
            oCustomer.Chairperson = txtChairperson.Text;
            oRep.Find(txtRepID.Text);
            oCustomer.RepID = oVoicemail.RepID;
            oCustomer.Rep_Ext = oVoicemail.ID;
            oCustomer.PrizeID = txtPrizeID.Text;

            oCustomer.PhoneNumber = txtPhoneNumber.Value.ToString();
            oCustomer.PhoneNumberExt = txtPhoneNumberExt.Text;

            oCustomer.FaxNumber = txtFax.Value.ToString();
            oCustomer.HeadPhone = txtHeadPhone.Value.ToString();
            oCustomer.HeadPhoneExt = txtHeadPhoneExt.Text;
            oCustomer.StartDate = (txtStartDate.Value == null) ? DNull : (DateTime) txtStartDate.Value;
            oCustomer.EndDate = (txtEndDate.Value == null) ? DNull : (DateTime)txtEndDate.Value;
            oCustomer.PickUpDate = (txtPickUpDate.Value == null) ? DNull : (DateTime)txtPickUpDate.Value;
            oCustomer.ShipDate = (txtShipDate.Value == null) ? DNull : (DateTime)txtShipDate.Value;
            oCustomer.SignedDate = (txtSignedDate.Value == null) ? DNull : (DateTime)txtSignedDate.Value;
            oCustomer.DeliveryDate = (txtDeliveryDate.Value == null) ? DNull : (DateTime)txtDeliveryDate.Value;
            oCustomer.ParentPickUpDate = (txtPPickupDate.Value == null) ? DNull : (DateTime)txtPPickupDate.Value;
            //oCustomer.CashRegister = txtCashier.en
            oCustomer.KITS = "0"; //Depricated
            oCustomer.CODE1 = (Double)txtCODE1.Number;
            oCustomer.CODE3 = (Double)txtCODE3.Number;
            oCustomer.CODE2 = (Double)txtCODE2.Number;
            oCustomer.CODE4 = (Double)txtCODE4.Number;
            
            oCustomer.ProfitPercent = Convert.ToDouble(txtProfitPercent.Number);
            oCustomer.ProfitPercent_2 = Convert.ToDouble(txtProfitPercent_2.Number);
            oCustomer.ProfitPercent_3 = Convert.ToDouble(txtProfitPercent_3.Number);
            oCustomer.ProfitPercent_4 = Convert.ToDouble(txtProfitPercent_3.Number);

            oCustomer.SignedNote = txtSignedNote.Text;
            oCustomer.StartNote = txtStartNote.Text;
            oCustomer.EndNote = txtEndNote.Text;
            oCustomer.PickUpNote = txtPickUpNote.Text;
            oCustomer.ShipNote = txtShipNote.Text;
            oCustomer.DeliveryNote = txtDeliveryNote.Text;
            oCustomer.ParentPickUpNote = txtParentPickUpNote.Text;


            oCustomer.PreviousRetail = txtPrevRetail.Number;

            oCustomer.BrochureID = txtBrochureID.Text;
            oCustomer.BrochureID_2 = txtBrochureID_2.Text;
            oCustomer.BrochureID_3 = txtBrochureID_3.Text;
            oCustomer.BrochureID_4 = txtBrochureID_4.Text;

            //oCustomer.Retail = txtRetail.Text;
            //oCustomer.AmountPayments = txtAmoun
            //oCustomer.NoItems = txtNoItems.Text;
            //oCustomer.NoSellers = txtNoSellers.text;


            //oCustomer.PriceListID
            switch (txtApplyTax.Text)
            {
                case "No":
                    oCustomer.ApplyTax = "N";
                    break;
                case "Yes":
                    oCustomer.ApplyTax = "Y";
                    break;
                case "Retail":
                    oCustomer.ApplyTax = "R";
                    break;
                default:
                    oCustomer.ApplyTax = "N";
                    break;

            }

            switch (txtCollectTax.Text)
            {
                case "No":
                    oCustomer.CollectTax = "N";
                    break;
                case "Retail":
                    oCustomer.CollectTax = "R";
                    break;
                case "Wholesale":
                    oCustomer.CollectTax = "W";
                    break;
                default:
                    oCustomer.CollectTax = "N";
                    break;

            }


            oCustomer.Signed = (Int32) txtSigned.Number;
            oCustomer.SalesTax = (Double)txtSalesTax.Number;

            oCustomer.Page = txtPage.Text;
            oCustomer.Grid = txtGrid.Text;

            oCustomer.PriceListID = "0";

            oCustomer.IsLetterAprovalDone = txtLetterAproval.Checked ? true : false;


            if (OpShipOption.CheckedIndex > -1)
                oCustomer.ShipOption = Convert.ToInt16(OpShipOption.Items[OpShipOption.CheckedIndex].DataValue);
            else
                oCustomer.ShipOption = 0;

            oCustomer.IsPostPay = txtPostPay.Checked;
            oCustomer.PayableTo = txtPayableTo.Text;

            oCustomer.DatePayable = (txtDatePayable.Value == null) ? DNull : (DateTime)txtDatePayable.Value;

            oCustomer.Checked = cbChecked.Checked;

            oCustomer.CashRegisters = (Int32) txtCashRegisters.Number;
            oCustomer.IsOneDaySale = cbOneDaySale.Checked;
            oCustomer.IsAssigned = cbAssigned.Checked;
            oCustomer.IsTreasureChest = cbTreasureChest.Checked;
            

            //Gift Avenue Specific Features
            if (IsGiftAvenue)
            {
                oCustomer.oGiftAvenue.CompanyID = this.CompanyID;
                oCustomer.oGiftAvenue.CustomerID = this.oCustomer.ID;
                oCustomer.oGiftAvenue.SFull = (Int32) txtSFull.Number;
                oCustomer.oGiftAvenue.SHalf = (Int32)txtSHalf.Number;
                oCustomer.oGiftAvenue.SLow = (Int32)txtSLow.Number;
                oCustomer.oGiftAvenue.TBin = (Int32)txtTBin.Number;
                oCustomer.oGiftAvenue.LE1 = (Int32)txtLE1.Number;
                oCustomer.oGiftAvenue.LE2 = (Int32)txtLE2.Number;
                oCustomer.oGiftAvenue.LE3 = (Int32)txtLE3.Number;
                oCustomer.oGiftAvenue.LE4 = (Int32)txtLE4.Number;
                oCustomer.oGiftAvenue.LE5 = (Int32)txtLE5.Number;
                oCustomer.oGiftAvenue.LETX = (Int32)txtLETX.Number;
                oCustomer.oGiftAvenue.DS = (Int32)txtDS.Number;
                oCustomer.oGiftAvenue.LowKit1 = (Int32) txtLKit1.Number;

                oCustomer.oGiftAvenue.KitAssigned = bKitAssigned.Checked;
                oCustomer.oGiftAvenue.IsProductOrdered = cbProductOrdered.Checked;
                oCustomer.oGiftAvenue.IsRegisterReturned = cbRegisterReturned.Checked;
                oCustomer.oGiftAvenue.IsProductReturned = cbProductReturned.Checked;
                oCustomer.oGiftAvenue.BoxesReturned = (Int32)txtBoxes.Number;
                oCustomer.oGiftAvenue.ProductReturnedDate = (txtProductReturnedDate.Value == null) ? DNull : (DateTime)txtProductReturnedDate.Value;
                oCustomer.oGiftAvenue.WDS = cbWDS.Checked;

                oCustomer.oGiftAvenue.S1Full = (Int32)txtS1Full.Number;
                oCustomer.oGiftAvenue.S1Half = (Int32)txtS1Half.Number;
                oCustomer.oGiftAvenue.BBL    = (Int32)txtBBL.Number;
                oCustomer.oGiftAvenue.BBS    = (Int32)txtBBS.Number;
                oCustomer.oGiftAvenue.MUG    = (Int32)txtMUG.Number;
                oCustomer.oGiftAvenue.LEMUG = (Int32)txtLEMUG.Number;
                oCustomer.oGiftAvenue.PROREG = (Int32)txtPROREG.Number;
                oCustomer.oGiftAvenue.ProductShipped = cbProductShipped.Checked;
                oCustomer.oGiftAvenue.PromoShipped = cbPromoShipped.Checked;
                oCustomer.oGiftAvenue.IsCoupon = cbCoupon.Checked;
            }
            oCustomer.oCustomerExtra.Note = txtText.Text;
            oCustomer.oCustomerExtra.isEnrollmentForm = cbEnrollmentForm.Checked;
            oCustomer.oCustomerExtra.is20062008 = cb20062008.Checked;
            oCustomer.oCustomerExtra.isPineValley = txtPineValley.Checked;
            oCustomer.oCustomerExtra.isOld = txtOld.Checked;
            oCustomer.oCustomerExtra.eMail = txtEmailSecondary.Text;
            oCustomer.oCustomerExtra.isShowXBash = txtShowXBash.Checked;
            oCustomer.oCustomerExtra.isSigned = txtSignedYN.Checked;
            oCustomer.oCustomerExtra.isChecked = txtChecked.Checked;
            oCustomer.oCustomerExtra.isCompleted = txtCompleted.Checked;
            oCustomer.oCustomerExtra.isReceivedOrders = txtReceivedOrders.Checked;
            oCustomer.oCustomerExtra.isProfitChanged = txtProfitChanged.Checked;
            oCustomer.oCustomerExtra.isGrouped = cbGrouped.Checked;
            oCustomer.oCustomerExtra.isAMDelivery = cbAMDelivery.Checked;
            oCustomer.oCustomerExtra.isKastleKreation = cbKastleKreation.Checked;
            oCustomer.oCustomerExtra.isBlueDog = cbBlueDog.Checked;
            oCustomer.oCustomerExtra.isBlueDogContract = cbBlueDogContract.Checked;
            oCustomer.oCustomerExtra.isKK = cbKK.Checked;
            oCustomer.Save();
            oCustomer.HasChanged = true;

            SystemTimer.Enabled = true;
        }
        #endregion

        private Int32 Round(Int32 Number, Double Percentage, Int32 Round)
        {
            Int32 Result = Convert.ToInt32(Number * (1+Percentage/100));

            int result = 0;
            Math.DivRem(Result, Round, out result);
            if (result > 0)
            {
                Result += (Round-result);
            }

            return Result;
        }

        private void tPackingSlip_Click(object sender, EventArgs e)
        {
            if (oCustomer.ID  != "" && txtCustomerID.Text.Trim() != "")
            {
                Order oOrder = new Order(this.CompanyID);
                oOrder.CustomerID   = oCustomer.ID;
                oOrder.Teacher      = "PROMOTIONAL MATERIAL";
                oOrder.Student      = oCustomer.Chairperson;
                oOrder.Items.Clear();

                Order.Item Item;

                if (oOrder.oProduct.Find("LET"))
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = this.Round(oCustomer.Signed, 5, 5);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("THB"))
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = this.Round(oCustomer.Signed, -30, 50);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("ENV"))
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = this.Round(oCustomer.Signed, 5, 5);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("POS"))
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = 6;
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("SG"))
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = 1;
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.Items.Count > 0)
                {
                    oOrder.GetTotals();
                    oOrder.Collected = oOrder.Retail;
                    oOrder.Save(OrderType.Regular);

                    oOrder.Print();
                }

                //MessageBox.Show(Item.Quantity.ToString());

            }
        }

        private void tProductSlip_Click(object sender, EventArgs e)
        {
            if (oCustomer.ID != "" && txtCustomerID.Text.Trim() != "")
            {
                Order oOrder = new Order(this.CompanyID);
                oOrder.CustomerID = oCustomer.ID;
                oOrder.Teacher = "ORDER";
                oOrder.Student = "Gift Avenue Kit";
                oOrder.Items.Clear();

                Order.Item Item;

                if (oOrder.oProduct.Find("BB") && txtBBL.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtBBL.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("F KIT 1") && txtSFull.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtSFull.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("TB KIT 1") &&  txtSHalf.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtSHalf.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }
                
                if (oOrder.oProduct.Find("F KIT 2") &&  txtS1Full.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtS1Full.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("H KIT 2") && txtS1Half.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtS1Half.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("L KIT 2") && txtTBin.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtTBin.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("TB L KIT 2") &&  txtSLow.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtSLow.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("BAG BOX") && txtBBL.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtBBL.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("MUG 2") && txtLE4.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtLE4.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("MUG 1") && txtMUG.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtMUG.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("LE1") && txtLE1.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtLE1.Number); 
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("LE2") && txtLE2.Number > 0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtLE2.Number); ; ;
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("STOCK") && cbAssigned.Checked)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = 1;
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }

                if (oOrder.oProduct.Find("REG") && txtCashRegisters.Number>0)
                {
                    Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(txtCashRegisters.Number);
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                    Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                    oOrder.Items.Add(oOrder.oProduct.ID, Item);
                }
                
                if (oOrder.Items.Count > 0)
                {
                    oOrder.GetTotals();
                    oOrder.Collected = oOrder.Retail;
                    oOrder.Save(OrderType.Regular);

                    oOrder.Print();
                }

                //MessageBox.Show(Item.Quantity.ToString());

            }
        }

	}
}
