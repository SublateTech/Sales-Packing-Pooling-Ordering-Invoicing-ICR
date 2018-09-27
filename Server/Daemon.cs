using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Signature.Classes;
using Signature.Data;
using System.Data;

namespace SignatureServer
{
	
	public class Deamon
	{
		#region variables
		
		public string hostname;				// idem
		
		private bool run;					// switch listener on/off
		
		private int msec = 1000*5;			// poll time tcp port in millisec
        public bool logging;
        
        
				
		#endregion variables
		
		#region public

        private Boolean _ForceInternetProcess = false;
        private Boolean _ForceUpdateRemote = false;
        private Boolean _GaProcessing = false;
        public Boolean _ForceSendStatement = false;
        public String _TimeForStatement = "0300";

        public void Force()
        {
            // TODO: if app.config could be reread one should call Config.init() here
            // Config.init();
            if (!run)
            {  
                run = true;
                Thread th = new Thread(new ThreadStart(StartDeamon));
                th.Start();
            }
            _ForceInternetProcess = true;
            _ForceUpdateRemote = true;
        }
        
        /// <summary>
		/// Start listening
		/// </summary>
		public void Start()
		{
			// TODO: if app.config could be reread one should call Config.init() here
			// Config.init();
			if (!run)
			{
				run = true;
				Thread th = new Thread(new ThreadStart(StartDeamon));
	   			th.Start();
			}
		}
	
		/// <summary>
		/// Stop listening
		/// </summary>
		public void Stop()
		{
			run = false;
		//	Thread.Sleep(3000);	//wait three seconds to close all 
		}
		
		/// <summary>
		/// Simple implementation of pause; not really the same but works
		/// </summary>
		public void Pause()
		{
			Stop();
		}
		
		/// <summary>
		/// Simple implementation of Resume; see Pause();
		/// </summary>
		public void Resume()
		{
			Start();
		}
		
		/// <summary>
		/// Simple implementation of Restart
		/// </summary>
		public void Restart()
		{
			Stop();
			Start();
		}
		#endregion public
		
		#region Deamon
		
		/// <summary>
		
		/// </summary>
		private void StartDeamon()
		{
			hostname = Dns.GetHostName();
			IPAddress [] IPA = Dns.GetHostAddresses(hostname);
			IPAddress localAddr = IPAddress.Parse(IPA[0].ToString());
			
		    Console.Out.WriteLine("Started Deamon on " + hostname );
			
			while (run)
            {
               // MySQL.conn = null;
                InternetOrders oIOrders = new InternetOrders();
                GA_InternetOrders oGAOrders = new GA_InternetOrders("GA11");
                Company oCompany = new Company("S12");
                

               // Customer oCustomer = new Customer("F09");
                if (DateTime.Now.Hour.ToString().Trim().PadLeft(2, '0') + DateTime.Now.Minute.ToString().Trim().PadLeft(2, '0') == _TimeForStatement || _ForceSendStatement)
                {
                    _ForceSendStatement = true;
                }
                if (_ForceSendStatement)
                {
                    _ForceSendStatement = false;
                    Console.WriteLine("Start  - " + DateTime.Now.ToString());
                    Delayer oDelayer = new Delayer(1000 * 65);
                    
                    
                    Console.WriteLine("Start Sending Statements S10 - " + DateTime.Now.ToString());
                    oCompany = new Company("S10");
                    oCompany.PrintAllStatementsByEmail();
                    Console.WriteLine("End  Sending Statements S10 - " + DateTime.Now.ToString());
                    
                    
                    Console.WriteLine("Start Sending Statements F09 - " + DateTime.Now.ToString());
                    Company oCompanyF09 = new Company("F09");
                    oCompanyF09.PrintAllStatementsByEmail();
                    Console.WriteLine("End  Sending Statements F09 - " + DateTime.Now.ToString());

                    
                    
                    Console.WriteLine("Start Sending Statements F10 - " + DateTime.Now.ToString());
                    Company oCompanyF10 = new Company("F10");
                    oCompanyF10.PrintAllStatementsByEmail();
                    Console.WriteLine("End  Sending Statements F10 - " + DateTime.Now.ToString());

                    Console.WriteLine("Start Sending Statements S11 - " + DateTime.Now.ToString());
                    Company oCompanyS11 = new Company("S11");
                    oCompanyS11.PrintAllStatementsByEmail();
                    Console.WriteLine("End  Sending Statements S11 - " + DateTime.Now.ToString());


                    Console.WriteLine("Start Sending Statements S12 - " + DateTime.Now.ToString());
                    oCompanyS11 = new Company("S12");
                    oCompanyS11.PrintAllStatementsByEmail();
                    Console.WriteLine("End  Sending Statements S12 - " + DateTime.Now.ToString());

                    while (!oDelayer.isTimeOut) ;
                    Console.WriteLine("End  - " + DateTime.Now.ToString());
                }


                if (DateTime.Now.Hour.ToString().Trim().PadLeft(2, '0') + DateTime.Now.Minute.ToString().Trim().PadLeft(2, '0') == "0000" || _ForceInternetProcess)
                {   
                    _ForceUpdateRemote = true;
                }


                if (!_GaProcessing)
                {
                    _GaProcessing = true;
                    oGAOrders.ImportOrders();
                    _GaProcessing = false;
                }
                
                if (DateTime.Now.Hour.ToString().Trim().PadLeft(2, '0') + DateTime.Now.Minute.ToString().Trim().PadLeft(2, '0') == "0600" || _ForceInternetProcess)
                {
                    _ForceInternetProcess = true;
                }

                if (_ForceInternetProcess)
                {
                    _ForceInternetProcess = false;
                    Console.WriteLine("Start "+DateTime.Now.ToString());
                    oIOrders.ImportOrders("SigWeb",ShoppingType.SigFund,"F12","00022");
                    oIOrders.ImportOrders("SigChristian", ShoppingType.ChristianCollection, "F12", "00022");
                    oIOrders.ImportOrders("WLOT", ShoppingType.WLOT,"WLOT","2011");
                    oIOrders.ImportOrders("SigTOUCH", ShoppingType.PersonalTouchCollection,"GPI11","TOUCH");
                    oIOrders.ImportOrders("SigChoco", ShoppingType.ChocolateWithACause, "CHC12", "00001");
                    Console.WriteLine("End " + DateTime.Now.ToString());
                    
                }//else
                    //Console.Out.Write(DateTime.Now.Hour.ToString().Trim().PadLeft(2, '0') + DateTime.Now.Minute.ToString().Trim().PadLeft(2, '0'));
                   // Console.Out.Write(".");

                if (_ForceUpdateRemote)
                {
                    _ForceUpdateRemote = false;
                    Company oCompanyF11 = new Company("F12");
                    oCompanyF11.CreateClientSideCompany();
                    Console.WriteLine("Mirror Web Company "+oCompanyF11.CompanyID+" Created... " + DateTime.Now.ToString());
                }
                

                Thread.Sleep(msec);

   			} // end while
			
			//server.Stop();

            Console.Out.WriteLine("Stopped Deamon.");
		}

        class Delayer
        {
            DateTime Start;
            Int32 Millisecs = 0;
            
            public Delayer(Int32 Millisecs)
            {
                this.Millisecs = Millisecs;
                Start = DateTime.Now;
            }

            public Boolean isTimeOut
            {
                get
                {
                   // Console.WriteLine((DateTime.Now.Ticks - Start.Ticks) / TimeSpan.TicksPerMillisecond);
                    if ((DateTime.Now.Ticks - Start.Ticks)/TimeSpan.TicksPerMillisecond >= this.Millisecs)
                        return true;
                    else
                        return false;
                }

            }
        }

		#endregion
		
	}
}
