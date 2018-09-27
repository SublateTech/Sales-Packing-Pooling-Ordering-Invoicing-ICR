using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using OSAS;




namespace WEBGateWay
{
	public class App
	{
		static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
		
		// Define the system tray icon control.
		private NotifyIcon appIcon = new NotifyIcon();
				
		// Define the menu.
		private ContextMenu sysTrayMenu = new ContextMenu();
		private MenuItem Write_Access = new MenuItem("Test write access");
		private MenuItem displayFiles = new MenuItem("Run Rep Sales Update Process");
		private MenuItem run_reps_charges = new MenuItem("Run Rep Charges Update Process");
		private MenuItem run_order_process = new MenuItem("Run Orders Processing");
		private MenuItem run_all_processes = new MenuItem("All Processes");
		private MenuItem exitApp = new MenuItem("Exit");

		// This is the method to run when the timer is raised.
		private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs) 
		{
			myTimer.Stop();
 			process_sql();
			myTimer.Enabled = true;
		}
 
		public void Start()
		{
			
			
			// Configure the system tray icon.
			Icon ico = new Icon("logo.ico");
			appIcon.Icon = ico;
			appIcon.Text = "Signature Fundraising WEB GateWay";


		   // Place the menu items in the menu.
			sysTrayMenu.MenuItems.Add(Write_Access);
			sysTrayMenu.MenuItems.Add(displayFiles);
			sysTrayMenu.MenuItems.Add(run_reps_charges);
			sysTrayMenu.MenuItems.Add(run_order_process);
			sysTrayMenu.MenuItems.Add(run_all_processes);
			sysTrayMenu.MenuItems.Add(exitApp);
			appIcon.ContextMenu = sysTrayMenu;

			// Show the system tray icon.
			appIcon.Visible = true;

			// Attach event handlers.
			
			Write_Access.Click += new EventHandler(writeaccess);
			run_all_processes.Click += new EventHandler(All_Processes);
			run_reps_charges.Click += new EventHandler(Reps_Charges);
			displayFiles.Click += new EventHandler(DisplayFiles);
			run_order_process.Click+= new EventHandler(Order_Process);
			exitApp.Click += new EventHandler(ExitApp);
			

		}
		private void writeaccess(object sender, System.EventArgs e)
		{
			
			OSAS.OSAS oTest = new OSAS.OSAS();

			//oTest.test_header_order();
			//oTest.test_detail_order();
			//oTest.create_keyed_file();
			oTest.migrate_taxes_by_product("S05");
			return; 
			
			//OSAS.OSAS  oOSAS = new OSAS.OSAS();
			
			OSAS.OSAS_Orders oOrders  = new OSAS.OSAS_Orders("","T01");

			oOrders.open_OSAS_orders();

			// Writing Order Headers.
			oOrders.Header.Teacher = "TEACHER 003";
			oOrders.Header.Student = "STUDENT 001";
			oOrders.Header.Type = "000";
			oOrders.Header.Prize = "0123456789";
			oOrders.Header.No_Items = "20";
			oOrders.Header.Retail = "10.58";
			oOrders.Header.Collected = "10.58";
			oOrders.Header.Tax = "2.35";
			oOrders.Header.Printed = "0";
			oOrders.Header.Disc_Printed = "0";
			oOrders.Header.Box = "5";
			oOrders.Header.Date = "2454291";
			oOrders.Header.Phone = "6619461674";

			oOrders.write_header_order();

			// Writing Order Detail...
			oOrders.Detail.Teacher = oOrders.Header.Teacher;
			oOrders.Detail.Student = oOrders.Header.Student;
			oOrders.Detail.Seq = "001";
			oOrders.Detail.Item = "002";
			oOrders.Detail.No_Items = "10";
			oOrders.Detail.Tax = "0.00";
			oOrders.Detail.No_Invoiced = "0";

			oOrders.write_detail_order();
 
			oOrders.Detail.Teacher = oOrders.Header.Teacher;
			oOrders.Detail.Student = oOrders.Header.Student;
			oOrders.Detail.Seq = "002";
			oOrders.Detail.Item = "ABC";
			oOrders.Detail.No_Items = "15";
			oOrders.Detail.Tax = "0.00";
			oOrders.Detail.No_Invoiced = "0";

			oOrders.write_detail_order();

			if (!oOrders.RemoveRecord("000"))
				MessageBox.Show("BAD");

			
			
			// Go through order rows.
			
			oOrders.goStart();
			int err=0;
			do
			{
				if (oOrders.isEOF())
					break;
							
				if (oOrders.isHeader())			
				{
								
					oOrders.read_header_order();
					//oOrders.write_header_order();
					//MessageBox.Show(oOrders.read_record());			
					MessageBox.Show(oOrders.Header.Teacher+oOrders.Header.Student);
								
					while (oOrders.same_order())
					{
												
						oOrders.read_detail_order();
						//MessageBox.Show(oOrders.read_record());
						MessageBox.Show(oOrders.Detail.CompanyID + oOrders.Detail.CustomerID + oOrders.Detail.Teacher + oOrders.Detail.Item);
									
					}
								
				}
				else
				{
					oOrders.read_detail_order();

				}
							
						
			}while (err!=2);
			
			

			oOrders.close_orders();
		
		}


		private void All_Processes(object sender, System.EventArgs e)
		{
			process_sql();
		}

		private void Order_Process(object sender, System.EventArgs e)
		{
			OSAS.OSAS  oOSAS = new OSAS.OSAS();
			oOSAS.update_OSAS_orders("*");
		}

		private void Reps_Charges(object sender, System.EventArgs e)
		 {
			OSAS.OSAS  oOSAS = new OSAS.OSAS();
			//oOSAS.copy_rep_charges("S07");
			oOSAS.migrate_reps("S07",true);
			//oOSAS.migrate_reps("F07",true);
			
         }
		
		private void ExitApp(object sender, System.EventArgs e)
		{
			appIcon.Visible = false;
			myTimer.Stop();
			Application.Exit();
		}

		private void DisplayFiles(object sender, System.EventArgs e)
		{
			MessageBox.Show("Inicio");
			process_sql();
			MessageBox.Show("Fin");
		}
		
		static void  process_sql()
			{
			
			OSAS.OSAS  oOSAS = new OSAS.OSAS();
			oOSAS.migrate_taxes_by_product("F07");
			
			oOSAS.migrate_prizes("F07");
			oOSAS.migrate_brochures("F07"); 
			oOSAS.update_products("F07");
			
			oOSAS.migrate_prizes("S07");
			oOSAS.migrate_brochures("S07"); 
			oOSAS.update_products("S07");
			
			//oOSAS.update_customers("T07");
			oOSAS.update_customers("S07");
			oOSAS.update_customers("F07");
			//oOSAS.update_customers("F06");
			
			//oOSAS.migrate_reps("F06",true);
			oOSAS.migrate_reps("S07",true);
			oOSAS.migrate_reps("F07",true);
			
			oOSAS.update_OSAS_orders("*");
			
			return;
			}		
		public static void Main(string[] args)
		{
			App app = new App();
			app.Start();
			
			if (args.Length > 0)
			{
				switch (args[0])
				{
					case "/RCH":
						
						app.appIcon.Visible = false;
						Application.Exit();
						break;
					case "/CUS":
						//process_sql();
						app.appIcon.Visible = false;
						Application.Exit();
						break;
					case "/ORD":
						//app.Order_Process(null,null);
						app.appIcon.Visible = false;
						Application.Exit();
						break;
				}
				
			}

			
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
