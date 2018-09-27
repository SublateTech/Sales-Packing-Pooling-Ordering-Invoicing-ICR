using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Data;
using System.Data;

namespace SignatureServer
{
	public class App
	{
		static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
		
		// Define the system tray icon control.
		private NotifyIcon appIcon = new NotifyIcon();
				
		// Define the menu.
		private ContextMenu sysTrayMenu = new ContextMenu();
		private MenuItem ImagesItem = new MenuItem("Start ...");
        private MenuItem TestItem = new MenuItem("Force ...");
        private MenuItem GetNamesItem = new MenuItem("Stop ...");
        private MenuItem exitApp = new MenuItem("Exit");
        private MenuItem Statement = new MenuItem("Force Statement ...");
        private MenuItem InvoiceXLS = new MenuItem("Send Mass Emails  ...");

        private Deamon oDeamon = new Deamon();

		// This is the method to run when the timer is raised.
		private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs) 
		{
    		        myTimer.Stop();
 			        
			        myTimer.Enabled = true;
    	}

 		public void Start()
		{
			// Configure the system tray icon.
			Icon ico = new Icon("logo.ico");
			appIcon.Icon = ico;
			appIcon.Text = "Signature Fundraising Server";


		   // Place the menu items in the menu.
			sysTrayMenu.MenuItems.Add(ImagesItem);
            sysTrayMenu.MenuItems.Add(TestItem);
            sysTrayMenu.MenuItems.Add(GetNamesItem);
            sysTrayMenu.MenuItems.Add(Statement);
            sysTrayMenu.MenuItems.Add(InvoiceXLS);
            sysTrayMenu.MenuItems.Add(exitApp);
		
            appIcon.ContextMenu = sysTrayMenu;

			// Show the system tray icon.
			appIcon.Visible = true;

			// Attach event handlers.
           // TestItem.Click += new EventHandler(TestProcess);
            TestItem.Click += new EventHandler(ImagesProcess);
			ImagesItem.Click += new EventHandler(ImagesProcess);
            GetNamesItem.Click += new EventHandler(ImagesProcess);
            Statement.Click += new EventHandler(ImagesProcess);
            InvoiceXLS.Click += new EventHandler(GenerateInvoiceXLS);
			exitApp.Click += new EventHandler(ExitApp);
			

		}

        private void GenerateInvoiceXLS(object sender, System.EventArgs e)
        {
            /*
            Invoice oInvoice = new Invoice("GPI12");

            oInvoice.GenerateInvoiceXLSFile();
            Console.Out.WriteLine("File Created...");
            
            Company oCompany = new Company();
            oCompany.SendMassEmail();
            */
            
            Console.WriteLine("Start Sending Statements F10 - " + DateTime.Now.ToString());
            Company oCompanyF10 = new Company("F10");
            oCompanyF10.PrintAllStatementsByEmail();
            Console.WriteLine("End  Sending Statements F10 - " + DateTime.Now.ToString());
             
            /*
            Smtp oSmtp = new Smtp();

            oSmtp.Subject = "Emails processed " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() ;
            
            oSmtp.To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
            oSmtp.CC = "\"Alvaro Medina\" <alvaro@familiamedina.net>";
            oSmtp.BCC = "\"Alvaro Medina\" <amedinag@sublate.com>";
                
            
            oSmtp.From = "\"Signature Server\" <shopping@sigfund.com>";

            String strTitle = "Order ID[Internet]   Teacher           Student         Items   City  State Ship/Del Packed\n\r";
            strTitle += "------------------------------------------------------------------------------------------\n\r";
            

            oSmtp.Body = strTitle;
            oSmtp.Send();
            Console.WriteLine("Sent "+ DateTime.Now.ToString());
            */
        }
        
        private void TestProcess(object sender, System.EventArgs e)
        {
            
            MySQL oMySql = new MySQL();
            DataTable oDt = oMySql.GetDataTable("Select * From Orders Where CustomerID='74025' And CompanyID='F08'"); 
            Order oOrder =  new Order("F08");

            foreach (DataRow row in oDt.Rows)
            {
                if (oOrder.Find((Int32)row["ID"]))
                {
                 //   MessageBox.Show(oOrder.oCustomer.Name);
                    Console.Out.WriteLine(oOrder.Student);
                    oOrder.Delete();
                }
            }
        }

        private void TestSchools1(object sender, System.EventArgs e)
        {
            MySQL.connection = null;
            MySQL oRemoteMysql = new MySQL("mysql", "signatv9_signature", "signatv9_sa", "sa");
            if (!oRemoteMysql.IsConnected)
                return;
            DataTable oDt  = oRemoteMysql.GetDataTable("Select * from cart_students Order By order_id desc limit 300");
            oRemoteMysql.Close();

            MySQL.connection = null;
            
            Customer oCustomer = new Customer("F08");
            foreach (DataRow row in oDt.Rows)
            {

                String Result = oCustomer.GetSchool(row["school_name"].ToString(), row["school_city"].ToString());
                if (!oCustomer.Find(Result))
                    Console.Out.WriteLine(row["school_name"].ToString() + "  " + Result );
                else
                    Console.Out.WriteLine("(" + oCustomer.ID + ")" + row["school_name"].ToString() + "  " + oCustomer.Name);
                
            }

        }

        private void NamesProcess(object sender, System.EventArgs e)
        {
            DataTable oDt = Global.oMySql.GetDataTable("SELECT distinct(Student) from Orders Where Student like '%,%' Order By Student");
            
            Student  oStudent = new Student("F08");
            foreach (DataRow row in oDt.Rows)
            {

                if (!oStudent.FindName(oStudent.GetFirstName(row["Student"].ToString())))
                {
                    String Result = oStudent.GetFirstName(row["Student"].ToString());
                        oStudent.InsertName(Result);
                    Console.Out.WriteLine(Result);
                }
            }

            foreach (DataRow row in oDt.Rows)
            {

                if (!oStudent.FindLastName(oStudent.GetLastName(row["Student"].ToString())))
                {
                    String Result = oStudent.GetLastName(row["Student"].ToString());
                    oStudent.InsertLastName(Result);
                    Console.Out.WriteLine(Result);
                }
            }



        }

		private void ImagesProcess(object sender, System.EventArgs e)
		{
            if (((MenuItem)sender).Text == "Start ...")
            {
                oDeamon.Start();
            }
            else if (((MenuItem)sender).Text == "Stop ...")
            {
                oDeamon.Stop();
            }
            else if (((MenuItem)sender).Text == "Force ...")
            {
                oDeamon.Force();
                
            }
            else if (((MenuItem)sender) == Statement )
            {
                oDeamon.Start();
                oDeamon._ForceSendStatement = true;

            }
		}
        

        private void ExitApp(object sender, System.EventArgs e)
		{
			appIcon.Visible = false;
			myTimer.Stop();
            oDeamon.Stop();
			Application.Exit();
		}

        public static void Main(string[] args)
		{
			App app = new App();
			app.Start();
			
			myTimer.Tick += new EventHandler(TimerEventProcessor);
 
			// Sets the timer interval to 15 minutes.
			myTimer.Interval = 1000*60*15;
			myTimer.Start();
			// Because no forms are being displayed, you need this 
			// statement to stop the application from automatically ending.
			Application.Run();

			
		}

	}
}
