using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Reports;
using Signature.Classes;
using Signature.Forms;
using Signature.Data;
using Signature;
using Signature.Vista;
using Signature.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Drawing.Drawing2D;


namespace Signature.Forms
{

    public partial class frmMain : TransparentForm, IMDIClientNotify
    {
        
        Timer SystemTimer;
       // UserActivityHook actHook;
        Color ColorBackGround = new Color();
        private MDIClientWindow mdiClient = null;
        
        public frmMain()
        {
            
            InitializeComponent();
            Global.SetVolume(10);
            if (Global.IsVista)
            {
                Printer oPrinter = new Printer();
                oPrinter.CkeckPrintronixs();
            }
            SystemTimer = new Timer();
            SystemTimer.Interval = 60000*10;
            SystemTimer.Tick += new EventHandler(SystemTimer_Tick);
            SystemTimer.Start();
            
            //Hook Keyboard
 //           actHook = new UserActivityHook(); // crate an instance with global hooks
            // hang on events
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            //actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
   //         actHook.KeyUp += new KeyEventHandler(MyKeyUp);

           // this.Show();

            MyKeyUp(null, null);

            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    this.ColorBackGround = c.BackColor;
                    
                }
            }
            
        }
        
        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            //Global.oMySql.exec_sql("Update user Set ComputerName='"+Dns.GetHostName()+ "',DateTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',IP='"+Dns.GetHostAddresses("localhost").ToString()+"' Where User='" + Global.CurrentUser + "'");
            User oUser = new User();
            oUser.Find(Global.CurrentUser);
            oUser.UserID = Global.CurrentUser;
            oUser.dateTime = DateTime.Now;
            oUser.ComputerName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostByName(oUser.ComputerName);
            IPAddress[] Ip = ipEntry.AddressList;
           
            
            oUser.IP = Ip[0].ToString();
            oUser.Save();

        }
        
        void SystemTimer_Tick(object sender, EventArgs e)
        {

            SystemTimer.Stop();
            /*
            if (!MySQL.connection.Ping())
            {
                MySQL.connection = null;
                Global.oMySql.Open();
            }
            SystemTimer.Start();
            */
        }

        private bool  isActive(String frmName)
        {
            
            foreach (Form frm in this.MdiChildren)
                if (frm.Name == frmName)
                {
                    //frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    //frm.Focus();
                   return true;
                }
            return false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            SystemTimer.Stop();
            //actHook.Stop();
            //MessageBox.Show("The method or operation is not implemented.");
            e.Cancel = false;
        }

        private void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
   
            //MessageBox.Show(e.Tool.Key.ToString());
        //    Console.WriteLine(e.Tool.Key.ToString());
            switch (e.Tool.Key.ToString())
            {

                case "UPS Labels":
                    {

                        if (!isActive("frmCustomerUPSLabels"))
                        {
                            frmCustomerUPSLabels frm = new frmCustomerUPSLabels();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }   
                case "Commssion Rep":
                    {

                        if (!isActive("frmCommissionSalesReport"))
                        {
                            frmCommissionSalesReport frm = new frmCommissionSalesReport();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }   

                case "Tax Report":
                    {

                        if (!isActive("frmCustomerTax"))
                        {
                            frmCustomerTax frm = new frmCustomerTax();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }
                case "GA Reports":
                    {

                        if (!isActive("frmGAReports"))
                        {
                            frmGAReports frm = new frmGAReports();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }

                case "Enter Teachers":
                    {
                        if (!isActive("frmOrderICRTeacher"))
                        {
                            frmOrderICRTeacher frm = new frmOrderICRTeacher();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }   
                case "LookForButton":
                    {
                        
                       // MessageBox.Show(this.ToolBarManager.Toolbars["SearchTool"].Tools["LookFor"].InstanceDisplaysText.ToString());

                        break;

                    }
                    


                case "Pine Valley":
                    {
                        if (!isActive("frmCustomerPineValley"))
                        {
                            frmCustomerPineValley frm = new frmCustomerPineValley();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Blue Ribbon":
                    {
                        if (!isActive("frmCustomerBlueRibbon"))
                        {
                            frmCustomerBlueRibbon frm = new frmCustomerBlueRibbon();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Coversheet Setup":
                    {
                        if (!isActive("frmCoversheet"))
                        {
                            frmCoverSheet frm = new frmCoverSheet();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }

                case "Empty Fields":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintEmptyFieldsReport();
                        break;
                    }

                case "Non-Checked Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintCheckedCustomers();
                        break;
                    }

                case "Blue Dog Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintBlueDogCustomers();
                        break;
                    }

                case "KK":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintKKCustomers();
                        break;
                    }

                case "Non-Assigned Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintAssignedCustomers();
                        break;
                    }

                case "Non-Promo Shipped Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintPromoShippedCustomers();
                        break;
                    }

                case "EnrollmentForm Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintEnrollmentForm();
                        break;
                    }



                case "Customer AddedAmount Listing":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintAddedAmountListing();
                        break;
                    }
                case "Non-ProductOrdered Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintProductOrderedCustomers();
                        break;
                    }

                case "Prize Summary Report":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintPrizeSummary();
                        }
                        
                        break;
                    }
                case "Frank Report":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintFrankReport();
                            oCustomer.PrintFrankReportByClass();
                        }

                        break;
                    }
                case "Overage Report":
                    {
                        Invoice oCustomer = new Invoice(Global.CurrrentCompany);
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintOverageReport();
                        }

                        break;
                    }

                case "Acknowledgement":
                    {
                        Invoice oCustomer = new Invoice(Global.CurrrentCompany);
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintAcknowledgement();
                        }

                        break;
                    }
                case "Bill Of Lading":
                    {
                        if (!isActive("frmCustomerBillOfLading"))
                        {
                            frmCustomerBillOfLading frm = new frmCustomerBillOfLading();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }

                case "Shortage":
                    {

                        if (!isActive("frmShortage"))
                        {
                            frmShortage frm = new frmShortage(); 
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }
                case "Tracking Number":
                    {

                        if (!isActive("frmTracking"))
                        {
                            frmTracking frm = new frmTracking(false);
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }   
                case "Print Barcodes":
                    {

                        if (!isActive("frmUPCA"))
                        {
                            frmUPCA frm = new frmUPCA();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }   
                case "InvoiceDiscrepancy":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintInvoiceList();
                        //oCompany.
                        break;

                    }



                case "SalesRepSummaryReport":
                    {

                        Company oCompany = new Company();
                        oCompany.PrintRepRankingReport();
                        break;

                    }
                case "RankingByUser":
                    {
                        
                        frmRankingByUser frm = new frmRankingByUser();
                        frm.MdiParent = this;
                        frm.Show();
                        break;

                    }

                case "DateReport":
                    {
                        if (!isActive("frmCustomerDate"))
                        {
                            frmCustomerDate frm = new frmCustomerDate();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Students Signed By Date":
                    {
                        if (!isActive("frmCustomerSignedDate"))
                        {
                            frmCustomerSignedDate frm = new frmCustomerSignedDate();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                    
                
                case "CustomerCharges":
                    {
                        if (!isActive("frmCharges"))
                        {
                            frmCharges frm = new frmCharges();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }

                case "BrochureSummaryReport":
                    {
                        Brochure oBrochure = new Brochure(Global.GetParameter("CurrentCompany"));
                        oBrochure.PrintSummaryReport();
                        break;

                    }

                case "TaxByState":
                    {
                        TaxByState oTaxByState = new TaxByState(Global.GetParameter("CurrentCompany"));
                        oTaxByState.Print();
                        break;

                    }

                    
                case "End Labels":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintEndLabels();
                        }
                        break;

                    }
                case "Brochure Box Labels":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintBrochureBox();
                        }
                        break;

                    }
                case "ClassTeamReport":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintClassTeamReport("",false);
                        }
                        break;

                    }

                case "Class Team Report Detailed":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintClassTeamReportGPIDetailed("", false);
                        }
                        break;

                    }
                    
                case "BrochureListing":
                    {
                        Brochure oBrochure = new Brochure(Global.GetParameter("CurrentCompany"));
                        if (!oBrochure.View())
                            return;
                        else
                        {
                            oBrochure.Print();
                        }
                        break;

                    }

                case "BrochureListing2":
                    {

                        if (!isActive("frmBrochureListing"))
                        {
                            frmBrochureListing frm = new frmBrochureListing();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }

                case "Brochure Item Measures":
                    {
                        Brochure oBrochure = new Brochure(Global.GetParameter("CurrentCompany"));
                        if (!oBrochure.View())
                            return;
                        else
                        {
                            oBrochure.PrintProductSizes();
                        }
                        break;

                    }

                case "Brochure Listing w/Cost":
                    {
                        Brochure oBrochure = new Brochure(Global.GetParameter("CurrentCompany"));
                        if (!oBrochure.View())
                            return;
                        else
                        {
                            oBrochure.PrintBrochureListingCost();
                        }
                        break;

                    }
                    

                case "CustomerListing":
                    {
                        if (!isActive("frmCustomerListing"))
                        {
                            frmCustomerListing frm = new frmCustomerListing();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    }
                case "CustomerDrawingTickets":
                    {
                        if (!isActive("frmCustomerDrawingTickets"))
                        {
                            frmCustomerDrawingTickets frm = new frmCustomerDrawingTickets();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    }
                case "SummaryReport":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintSummaryReport("",false);
                        }
                        break;

                    }

                case "ClassTeam  Summary Report":
                    if (!isActive("frmCustomerDate"))
                    {
                        frmCustomerClassSummary frm = new frmCustomerClassSummary();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }

                    break;

                case "Invoice Report":
                    if (!isActive("frmCustomerInvoice"))
                    {
                        frmCustomerInvoice frm = new frmCustomerInvoice();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }

                    break;

                case "GA Tally/Inventory":
                    if (!isActive("frmCustomerInventory"))
                    {
                        frmCustomerInventory frm = new frmCustomerInventory();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }

                    break;
                
                case "ItemStateTaxSetup":
                    {
                        if (!isActive("frmStateTax"))
                        {
                            frmStateTax frm = new frmStateTax();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }

                case "ItemListing":
                    {
                     
                        if (!isActive("frmProductListing"))
                        {
                            frmProductListing frm = new frmProductListing();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    
                    }
                case "Brochure Projected":
                    {

                        if (!isActive("frmBrochureProjected"))
                        {
                            frmBrochureProjected frm = new frmBrochureProjected();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;


                    }
                case "UpdatePO":
                    {
                        Purchase oPurchase = new Purchase(Global.GetParameter("CurrentCompany"));
                        if (!oPurchase.View())
                            return;
                        else
                        {
                            oPurchase.UpdateInventory();
                        }

                        break;
                    }
                case "UpdatePurchaseOrder":
                    {
                        Purchase oPurchase = new Purchase(Global.GetParameter("CurrentCompany"));
                        if (!oPurchase.View())
                            return;
                        else
                        {
                            oPurchase.UpdateReceiveInventory();
                        }

                    break;
                    }
                
                case "POReceipt": //Print
                    {
                        Purchase oPurchase = new Purchase(Global.GetParameter("CurrentCompany"));
                        if (!oPurchase.View())
                        {
                            return;
                        }
                        else
                        {
                            Receive oReceive = new Receive(Global.GetParameter("CurrentCompany"));
                            oReceive.PurchaseID = oPurchase.ID;
                            oReceive.PrintLog();
                        }

                    }
                    break;
                case "PurchaseOrder": //Print
                    {
                        /*
                        Purchase oPurchase = new Purchase(Global.GetParameter("CurrentCompany"));
                        if (!oPurchase.View())
                            return;
                        else
                        {
                            oPurchase.Print();
                        }
                        */
                        if (!isActive("frmPurchasePrint"))
                        {
                            frmPurchasePrint frm = new frmPurchasePrint();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                    }
                    break;

                case "ReceiveDocument":
                    {
                        /*
                        Receive oReceive = new Receive(Global.GetParameter("CurrentCompany"));
                        if (!oReceive.View())
                            return;
                        else
                        {
                            frmViewReport oViewReport = new frmViewReport();
                            oViewReport.sParameter_1 = oReceive.ID;
                            oViewReport.SetReport((int)Report.POReceive, Global.GetParameter("CurrentCompany"), "", true);
                        }
                        */
                        if (!isActive("frmPurchaseReceivePrint"))
                        {
                            frmPurchaseReceivePrint frm = new frmPurchaseReceivePrint();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                    }
                    break;
                case "Receive Purchase Orders":
                    {
                        
                        if (!isActive("frmReceive"))
                        {
                            frmReceive frm = new frmReceive();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                
                case "CreateEditPurchaseOrders":
                    {
                       
                        if (!isActive("frmPurchase"))
                        {
                            frmPurchase frm = new frmPurchase();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }

                case "RepSalesMaintenance":
                    {
                        if (!isActive("frmRep"))
                        {
                            frmRep frm = new frmRep();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Box Size Maintenance":
                    {
                        if (!isActive("frmBox"))
                        {
                            frmBox frm = new frmBox();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Brochure Type":
                    {
                        if (!isActive("frmBrochureType"))
                        {
                            frmProductType frm = new frmProductType();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "Prize Maintenance":
                    {
                        if (!isActive("frmPrize"))
                        {
                            frmPrize frm = new frmPrize();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                case "ScanPalletLoading":
                    {
                        if (!isActive("frmScanning"))
                        {
                            frmScanning frm = new frmScanning();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }   
                
                case "Recalculate":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.Recalculate();
                        }
                        break;

                    }
                case "Brochure Item Setup":
                    {
                        if (!isActive("frmBrochure"))
                        {
                            frmBrochure frm = new frmBrochure();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                
                case "Vendor Setup":
                    {

                        if (!isActive("frmVendor"))
                        {
                            frmVendor frm = new frmVendor();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;

                    }
                
                case "Inventory Maintenance":
                    {

                    if (Global.HasAccess("frmProduct"))
                        if (!isActive("frmProduct"))
                        {
                            frmProduct frm = new frmProduct();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        
                        break;

                    }

                case "Rep Charges":
                    {   
                        if (Global.HasAccess("frmRepCharges"))
                            if (!isActive("frmRepCharges"))
                            {
                                frmRepCharges frm = new frmRepCharges();
                                frm.MdiParent = this;
                                frm.Show();
                                frm.Focus();
                            }

                        break;

                    }
      
                case "Scan Student Orders":
                    {
                        if (!isActive("frmPacking"))
                        {
                            frmPacking frm = new frmPacking();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    }

                case "Pack Orders By Sections":
                    {
                        if (!isActive("frmPackingSections_Old"))
                        {
                            frmPackingSections_Old frm = new frmPackingSections_Old();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    }


                case "Test":
                    {
                      //  Smtp oSmtp = new Smtp();
                      //  oSmtp.Test();
                        frmScanning frm1 = new frmScanning();

                        //frm1.MdiParent = this;
                        frm1.Show();
                        
                         }
                    break;

                case "Calls Assignment":
                    {
                        frmCallsAssignment frm1 = new frmCallsAssignment();

                        frm1.MdiParent = this;
                        frm1.Show();
                    }
                    break;

                case "Calls View":
                    {
                        foreach (Form frm in this.MdiChildren)
                            if (frm.Name == "frmCallsManager")
                            {
                                if (frm.WindowState == FormWindowState.Minimized || !frm.Visible)
                                {
                                    frm.WindowState = FormWindowState.Normal;
                                    frm.Show();
                                    return;
                                }
                                else
                                {
                                    frm.Hide();
                                    return;
                                }
                            }

                        frmCallsManager frm1 = new frmCallsManager();
                        frm1.MdiParent = this;
                        frm1.Show();
                    }
                    break;

                case "Pick Sheets":
                    {
                        if (!isActive("frmCustomerPickSheet"))
                        {
                            frmCustomerPickSheet frm = new frmCustomerPickSheet();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                    }
                    break;

                case "Invoice":
                    {
                        /*PrintTest oPrint = new PrintTest();
                        oPrint.Run();*/


                        Invoice oInvoice = new Invoice(Global.GetParameter("CurrentCompany"));

                        if (!oInvoice.View())
                            return;
                        else
                        {
                            String PrinterName = Global.OpenPrintDialog();
                            if (PrinterName != "")
                                oInvoice.Print(PrintTo.Printer, PrinterName, "PLEASE REMIT ENTIRE WHITE COPIES WITH PAYMENTS", true);
                        }

                    }
                    break;

                
                case "Statement":
                    {
                         if (!isActive("frmCustomerStatement"))
                            {
                                frmCustomerStatement frm = new frmCustomerStatement();
                                frm.MdiParent = this;
                                frm.Show();
                                frm.Focus();
                            }

                    }
                    break;


                case "Statement List":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintStatementList();
                    }
                    break;

                case "StatementPList":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintAllPurchaseStatemets();
                    }
                    break;
                
                case "GA Payment List":
                    {
                        Company oCompany = new Company();

                        DialogResult result;
                        result = MessageBox.Show("Sort by Rep?", "Ga Payment List", MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            oCompany.PrintGAPaymentList(true,false);
                        }
                        if (result == DialogResult.Yes)
                        {
                            oCompany.PrintGAPaymentList(true,true);
                        }
                        
                    }
                    break;

                case "GA Rep Commission":
                    {
                        Rep oRep = new Rep();
                        oRep.PrintGACommissionReport();
                    }
                    break;

                case "Discrepancy List":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {

                            oCustomer.PrintDiscrepancyList();
                            
                        }

                    }
                    break;

                case "Discrepancy Letters":
                    {
                    
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));

                        if (!oCustomer.View())
                            return;
                        else
                        {
                            oCustomer.PrintDiscrepancyLetters();
                            
                        }

                    }
                    break;
                
                case "Order/Re-Order":

                    if (!isActive("frmGAOrder"))
                    {
                        frmGAOrder frm = new frmGAOrder();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }
                    break;
            
                case "Kit Setup":

                    if (!isActive("frmKits"))
                    {
                        frmKitSetup frm = new frmKitSetup();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }
                    break;
                
                case "EditDiscrepancies":

                    if (!isActive("frmDiscrepancy"))
                    {
                        frmDiscrepancy frm = new frmDiscrepancy();
                        //frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }
                    break;
                case "Adquire Images":
                    {
                        //frmTwain mf = new frmTwain();
                       // mf.Show();
                        //mf.MdiParent = this;
                        break;
                    }

                case "Scan Images":
                    {
                        if (Global.HasAccess("frmOrderICRAdquire"))
                        {
                            frmOrderICRAdquire mf = new frmOrderICRAdquire();
                            mf.Show();
                        }
                        //mf.MdiParent = this;
                        break;
                    }
                
                case "Fix Orders":

                    frmOrderICRFix frmOSAS = new frmOrderICRFix();
                    frmOSAS.Show();
                    //mf.MdiParent = this;
                    break;
                case "Sales Rep By Brochure":
                    {
                       // frmViewReport oViewReport = new frmViewReport();
                       // oViewReport.SetReport((int)Report.summary_reps_sales, Global.GetParameter("CurrentCompany"), "0123", true);
                        Rep oRep = new Rep(Global.GetParameter("CurrentCompany"));
                        oRep.PrintRepSalesByBrochureReport();
                    }
                    break;    

                case "SalesRepReport":
                    {
                       // frmViewReport oViewReport = new frmViewReport();
                       // oViewReport.SetReport((int)Report.summary_reps_sales, Global.GetParameter("CurrentCompany"), "0123", true);
                        Rep oRep = new Rep(Global.GetParameter("CurrentCompany"));
                        oRep.PrintRepSalesReport();
                    }
                    break;

                case "Summary by Class":
                    {
                        Customer oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
                        if (!oCustomer.View())
                            return;
                        else
                        {
                            frmViewReport oViewReport = new frmViewReport();
                            oViewReport.SetReport((int)Report.summary_by_classes, Global.GetParameter("CurrentCompany"), oCustomer.ID, true);    
                        }
                        
                    }
                    break;

                case "Final Bill Tally Sheet":
                    {
                        frmViewReport oViewReport = new frmViewReport();
                        oViewReport.SetReport(8, Global.GetParameter("CurrentCompany"), "0123", true);
                    }
                    break;
                    
                
                case "Exit":
                    this.Dispose();
                    Application.Exit();
                    break;

                case "ChangeCompany":
                    frmViewCompanies oView = new frmViewCompanies();
                    oView.ShowDialog();
                    if (oView.sSelectedID != "")
                    {   
                        Global.SetParameter("CurrentCompany", oView.sSelectedID);
                        Status.Panels[0].Text = "Company: " + oView.sSelectedID;
                    }
                    break;
                
                case "ScannedOrders":
                    {
                       // if (Global.HasAccess("frmOrderZonal"))
                        if (!isActive("frmOrderZonal"))
                        {
                            frmOrderZonal frm = new frmOrderZonal();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                      /*
                        //if (Global.HasAccess("frmOrderZonal"))
                        if (!isActive("frmOrderZonal"))
                        {
                            frmOrderZonal frm = new frmOrderZonal();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                        */
                    }
 
                case "EnterOrders":
                    {
                     //if (!isActive("frmOrder"))
                     //   {
                        if (Global.IsGPI)
                        {
                            frmOrderGPI frm = new frmOrderGPI();
                            frm.Show();
                            frm.Focus();
                        }
                        else
                        {
                            frmOrder frm = new frmOrder();
                            // frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                       // }
                       break;
                    }
                
                case "CustomerMaintenance":
                    {
                        //if (!isActive("frmCustomer"))
                        //{
                            frmCustomer frm = new frmCustomer();
                            //frm.MdiParent = this;
                            //frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                            frm.Focus();
                        //}
                        break;
                    }

                case "Process All Inventory":
                    {
                        Company oCompany = new Company();
                        oCompany.ProcessInventory();
                        break;
                    }

                case "GA Reordered Product":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintGAProductReorded();
                        break;
                    }

                case "Internet Checks":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintInternetChecks();
                        break;
                    }

                case "NGL Pastors Screening":
                    {
                        Company oCompany = new Company();
                        oCompany.PrintAllOrders();
                        break;
                    }
                case "Product Description":
                    {
                     //if (!isActive("frmOrder"))
                     //   {
                            frmProductExtra frm = new frmProductExtra();
                            // frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                       // }
                       break;
                    }
                case "Product Card":
                    {
                        //if (!isActive("frmOrder"))
                        //   {
                        frmCardByProduct frm = new frmCardByProduct();
                        // frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                        // }
                        break;
                    }

                case "Imprint Orders":
                    {
                        //if (!isActive("frmOrder"))
                        //   {
                        frmImprinting frm = new frmImprinting();
                        // frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                        // }
                        break;
                    }

                case "Ticket":
                    {
                        if (!isActive("frmTicket"))
                        {
                            frmTicket frm = new frmTicket();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }

                case "Voicemail":
                    {
                        if (!isActive("frmVoicemail"))
                        {
                            frmVoicemail frm = new frmVoicemail();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }
                case "Company":
                    {
                        if (!isActive("frmCompany"))
                        {
                            frmCompany frm = new frmCompany();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }

                case "User":
                    {
                        if (!isActive("frmUser"))
                        {
                            frmUser frm = new frmUser();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }
                case "Template Card":
                    {
                        //if (!isActive("frmOrder"))
                        //   {
                        frmCardTemplate frm = new frmCardTemplate();
                        // frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                        // }
                        break;
                    }
                case "eMail":
                    {
                        //if (!isActive("frmOrder"))
                        //   {
                        frmeMail frm = new frmeMail();
                        // frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                        // }
                        break;
                    }

                case "Create Customer Side Company":
                    {
                        if (Global.HasAccess("ClientSideCompany"))
                        {
                            Company oCompany = new Company();
                            oCompany.CreateClientSideCompany();
                            
                        }

                    }
                    break;


                case "WLOT Card Set":
                    {
                        if (!isActive("frmOrder"))
                           {
                               frmCardSet frm = new frmCardSet();
                            
                                // frm.MdiParent = this;
                               frm.Show();
                               frm.Focus();
                           }
                        break;
                    }

                
                case "Custom Report":
                    {
                        Company oCompany = new Company();
                      //  oCompany.PrintAllRepCommissionReport();
                        //oCompany.PrintAllCAStatements();
                        //oCompany.PrintAllInvoices();
                        //oCompany.CalculateAllCustomerTotals();
                        //oCompany.CalculateAllCustomerTotalsByBrochure();
                        //oCompany.UpdateBrochureOrderDetail();
                        //oCompany.CalculateAllCustomerTeacherStudent();
                        oCompany.PrintCustomersGrouped();
                        break;
                    }
                //Custom Report By Customer
                case "Custom Report By Customer":
                    {
                        Company oCompany = new Company();
                        //  oCompany.PrintAllRepCommissionReport();
                        //oCompany.PrintAllCAStatements();
                        //oCompany.PrintAllInvoices();
                        //oCompany.CalculateAllCustomerTotals();
                        //oCompany.CalculateAllCustomerTotalsByBrochure();
                        //oCompany.UpdateBrochureOrderDetail();
                        //oCompany.CalculateAllCustomerTeacherStudent();
                        oCompany.PrintCustomersGroupedByCustomer();
                        break;
                    }

                //Custom Report By Customer
                case "Packing Slips By Item":
                    {
                        //oCompany.PrintAllOrdersByItem();

                        if (!isActive("frmCheckIn"))
                        {
                            frmPackingSlipByItemPrint frm = new frmPackingSlipByItemPrint();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        
                        break;
                    }
                    

                case "GA Cash Registers":
                    {
                        Company oCompany = new Company();
                      //  oCompany.PrintAllRepCommissionReport();
                        oCompany.PrintGACashRegister();
                        break;
                    }

                case "Commission/Charges":
                    {
                        Rep oRep = new Rep();
                        oRep.PrintCommissionChargesReport("",PrinterDevice.Screen);
                        break;
                    }

                case "Order Check In":
                    if (!isActive("frmCheckIn"))
                    {
                        frmCookieDoughLabels frm = new frmCookieDoughLabels();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }

                    break;
                
                case "Product By Rep":
                    if (!isActive("frmProductByRep"))
                    {
                        frmProductByRep frm = new frmProductByRep();
                        frm.MdiParent = this;
                        frm.Show();
                        frm.Focus();
                    }

                    break;

                case "Grouped Customers":
                    {
                        Customer oCustomer = new Customer(Global.CurrrentCompany);
                        oCustomer.PrintListingGroupedCustomers();
                        break;
                    }

                case "Landed Cost Box List":
                    {
                        Product oProduct = new Product();
                        oProduct.PrintLandedChecked();
                        break;
                    }

                case "Provider Payments":
                    {
                        if (!isActive("frmPaymentProvider"))
                        {
                            frmPaymentProvider  frm = new frmPaymentProvider();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }

                        break;
                    }

                case "Statements":
                    {
                        if (!isActive("frmPurchaseStatement"))
                        {   
                            frmPurchaseStatement frm = new frmPurchaseStatement();
                            frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;
                    }

                case "Print Cookie Dough XML Labels":
                    {
                        PineValley oPineValley = new PineValley();
                        oPineValley.PrintXMLLabels();
                        break;
                    }

                case "Invoice Conversion":
                    {
                        if (!isActive("frmCustomerInvoiceConversion"))
                        {
                            frmCustomerInvoiceConvert frm = new frmCustomerInvoiceConvert();
                            //frm.MdiParent = this;
                            frm.Show();
                            frm.Focus();
                        }
                        break;

                    }



                case "Generate Invoice XLS":
                    {   
                        {
                            Invoice oInvoice = new Invoice(Global.CurrrentCompany);
                            if (!oInvoice.View())
                                return;
                            else
                            {
                                oInvoice.GenerateInvoiceXLSFile();
                                Global.Message = "File Created...";
                            }
                            
                            

                            
                            
                        }
                        break;

                    }

            }

            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is MdiClient)
                    {   
                        c.BackColor = this.ColorBackGround; 

                    }
                }
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                if (Global.IsVista && !this.DesignMode)
                {
                    if (ApiVista.IsCompositionEnable())
                    {
                        foreach (Control c in this.Controls)
                        {
                            if (c is MdiClient)
                            {
                                c.BackColor = Color.Black;

                            }
                        }
                    }
                }
            }
            base.OnPaintBackground(e);
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            
            this.Status.Panels[0].Text = "Company : " + Global.GetParameter("CurrentCompany");
            this.Status.Panels[3].Text = "User : " + Global.CurrentUser;
            /*
            Live live1 = new Live();
            live1.BackColor = System.Drawing.Color.Transparent;
            live1.Location = new System.Drawing.Point(10, 125);
            live1.Name = "live1";
            live1.Size = new System.Drawing.Size(48, 48);
            live1.TabIndex = 20;
            live1.Text = "live1";
            this.Controls.Add(live1);
            */
            
          // frm.Visible = false;

            Global._frmMain = this;

            ResumeLayout();

            
            // Start processing for MDIClient window messages:
            mdiClient = new MDIClientWindow(this, this.Handle);
            
            // Stop the default window proc from drawing the MDI background
            // with the brush:
            UnManagedMethods.SetClassLong(
                mdiClient.Handle,
                UnManagedMethods.GCL_HBRBACKGROUND,
                0);

            if (!Global.HasAccess("frmProduct"))
            {
                ToolBarManager.Toolbars["Toolbar"].Tools["Purchasing/Inventory"].InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False;
                ToolBarManager.Toolbars["Toolbar"].Tools["Purchasing"].InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False;
            }
         }

        private  void Status_Click(object sender, EventArgs e)
        {
            
            frmViewCompanies oView = new frmViewCompanies();
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                
                Global.SetParameter("CurrentCompany", oView.sSelectedID);
                this.Status.Panels[0].Text = "Company: " + oView.sSelectedID;
            }
            

        }

        #region Private Structures
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public override string ToString()
            {
                string ret = String.Format(
                    "left = {0}, top = {1}, right = {2}, bottom = {3}",
                    left, top, right, bottom);
                return ret;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public int fErase;
            public RECT rcPaint;
            public int fRestore;
            public int fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;

            public override string ToString()
            {
                string ret = String.Format(
                    "hdc = {0} , fErase = {1}, rcPaint = {2}, fRestore = {3}, fIncUpdate = {4}",
                    hdc, fErase, rcPaint.ToString(), fRestore, fIncUpdate);
                return ret;
            }
        }

        #endregion

        #region UnManagedMethods
        private class UnManagedMethods
        {
            [DllImport("user32")]
            public extern static int GetClientRect(
                IntPtr hwnd,
                ref RECT lpRect);
            [DllImport("user32")]
            public extern static int BeginPaint(
                IntPtr hwnd,
                ref PAINTSTRUCT lpPaint);
            [DllImport("user32")]
            public extern static int EndPaint(
                IntPtr hwnd,
                ref PAINTSTRUCT lpPaint);
            [DllImport("user32", CharSet = CharSet.Auto)]
            public extern static uint SetClassLong(
                IntPtr hwnd,
                int nIndex,
                uint dwNewLong);
            [DllImport("user32")]
            public extern static int InvalidateRect(
                IntPtr hwnd,
                ref RECT lpRect,
                int bErase);

            public const int WM_PAINT = 0xF;
            public const int WM_ERASEBKGND = 0x14;
            public const int WM_SIZE = 0x5;

            public const int GCL_HBRBACKGROUND = (-10);

        }
        #endregion

        #region MDI Background Painting
        public void WndProc(ref Message m, ref bool doDefault)
        {
            // Don't need to do anything if the form is minimized:
            if (this.WindowState != FormWindowState.Minimized)
            {

                if (m.Msg == UnManagedMethods.WM_PAINT && this.WindowState == FormWindowState.Maximized)
                {
                    //
                    // Here we draw a logo on the "right" hand side 
                    // of the form (depends on RTL)
                    //
                    PAINTSTRUCT ps = new PAINTSTRUCT();
                    UnManagedMethods.BeginPaint(m.HWnd, ref ps);
                    RECT rc = new RECT();
                    UnManagedMethods.GetClientRect(m.HWnd, ref rc);

                    // Convert to managed code world				
                    Graphics gfx = Graphics.FromHdc(ps.hdc);
                    RectangleF rcClient = new RectangleF(
                        rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
                    Rectangle rcPaint = new Rectangle(
                        ps.rcPaint.left,
                        ps.rcPaint.top,
                        ps.rcPaint.right - ps.rcPaint.left,
                        ps.rcPaint.bottom - ps.rcPaint.top);

                    // Draw the logo bottom right:
                    SolidBrush brText = new SolidBrush(Color.White);
                    StringFormat strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Far;
                    strFormat.FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
                    strFormat.LineAlignment = StringAlignment.Far;
                    Font logoFont = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
                    gfx.DrawString("", logoFont, brText, rcClient, strFormat);
                    logoFont.Dispose();
                    strFormat.Dispose();
                    brText.Dispose();

                    gfx.Dispose();
                    UnManagedMethods.EndPaint(m.HWnd, ref ps);
                }
                else if (m.Msg == UnManagedMethods.WM_ERASEBKGND)
                {
                    //
                    // Fill the background:
                    //
                        RECT rc = new RECT();
                        UnManagedMethods.GetClientRect(m.HWnd, ref rc);
                        if (this.WindowState == FormWindowState.Maximized)
                        {

                            // Convert to managed code world
                            Graphics gfx = Graphics.FromHdc(m.WParam);
                            Rectangle rcClient = new Rectangle(
                                rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
                            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
                            {
                                int angle = 90 + 55;
                                LinearGradientBrush linGrBrush = new LinearGradientBrush(
                                    rcClient,
                                    Color.FromArgb(255, 214, 232, 255), // pale blue
                                    Color.FromArgb(255, 59, 65, 81),   // deep blue 
                                    angle);
                                //  gfx.FillRectangle(Brushes.Black, rcClient);
                                gfx.FillRectangle(linGrBrush, rcClient);

                                linGrBrush.Dispose();
                            }
                            else
                            {
                                gfx.FillRectangle(Brushes.Gray, rcClient);
                            }
                            gfx.Dispose();


                            // Tell Windows we've filled the background:
                            m.Result = (IntPtr)1;

                            // Don't call the default procedure:
                            doDefault = false;
                        }
                        else
                        {
                            RECT rc1 = new RECT();
                            UnManagedMethods.GetClientRect(this.Handle, ref rc1);
                            UnManagedMethods.InvalidateRect(this.Handle, ref rc1, 1);
                        }
                }
                else if (m.Msg == UnManagedMethods.WM_SIZE)
                {
                    // If your background is a tiled image then
                    // you don't need to do this.  This is only required
                    // when the entire background needs to be updated 
                    // in response to the size of the object changing.
                    RECT rect = new RECT();
                    rect.left = 0;
                    rect.top = 0;
                    rect.right = ((int)m.LParam) & 0xFFFF;
                    rect.bottom = (int)(((uint)(m.LParam) & 0xFFFF0000) >> 16);
                    //Console.WriteLine("WM_SIZE {0}", rect.ToString());
                    UnManagedMethods.InvalidateRect(m.HWnd, ref rect, 1);
                }
            }
        }
        #endregion

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.F12)
            {
                //frmScanning1 frm1 = new frmScanning1(); 
                //frmOrderZonal frm1 = new frmOrderZonal();
                //frm1.MdiParent = this;
                //    frm1.Show();

                Company oCompany = new Company();
               // oCompany.PrintAllInvoices();
                //oCompany.PrintAllStatemets();
                //oCompany.PrintAllCAInvoices();
               // oCompany.PrintAllCAStatements();
               // frmTest frm1 = new frmTest();
               // frm1.MdiParent = this;
               // frm1.Show();
                MessageBox.Show("F12");    
                //oCompany.PrintAllRepCommissionReport();

                
            }
        }

        private void F09_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "F09");
            this.Status.Panels[0].Text = "Company: " + "F09";
        }

        private void S10_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "S10");
            this.Status.Panels[0].Text = "Company: " + "S10";
        }

        private void GA9_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GA11");
            this.Status.Panels[0].Text = "Company: " + "GA11";
        }

        private void F10_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "F10");
            this.Status.Panels[0].Text = "Company: " + "F10";
        }

        private void G10_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GA10");
            this.Status.Panels[0].Text = "Company: " + "GA10";
        }

        private void txtGPI13_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GPI13");
            this.Status.Panels[0].Text = "Company: " + "GPI13";
        }

        private void txtReps_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "REP");
            this.Status.Panels[0].Text = "Company: " + "REP";
        }

        private void txtGPI11_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GPI11");
            this.Status.Panels[0].Text = "Company: " + "GPI11";
        }

        private void txtS13_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "S13");
            this.Status.Panels[0].Text = "Company: " + "S13";
        }

        private void F11_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "F11");
            this.Status.Panels[0].Text = "Company: " + "F11";
        }

        private void txtS10_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "S10");
            this.Status.Panels[0].Text = "Company: " + "S10";

        }

        private void txtS12_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "S12");
            this.Status.Panels[0].Text = "Company: " + "S12";
        }

        private void txtF12_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "F12");
            this.Status.Panels[0].Text = "Company: " + "F12";
        }

        private void txtGPI12_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GPI12");
            this.Status.Panels[0].Text = "Company: " + "GPI12";
        }

        private void GA12_Click(object sender, EventArgs e)
        {
            Global.SetParameter("CurrentCompany", "GA12");
            this.Status.Panels[0].Text = "Company: " + "GA12";
        }

        

        
    }
}