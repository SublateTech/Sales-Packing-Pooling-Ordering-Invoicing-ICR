using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Signature.Classes;
using Signature.Data;
using System.Data;

namespace Signature.Classes
{
	
	public class Deamon:IDisposable
	{
		#region variables
		
		public string hostname;				// idem
		
		private bool run;					// switch listener on/off
		public int msec = 1000*5;			// poll time tcp port in millisec
        
		#endregion variables
		
		#region public
		
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

        #region Events
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Tick;
        public virtual void OnTick()
        {
            if (Tick != null)
            {
                EventArgs Event = new EventArgs();
                Tick(this, Event);
            }
        }
        #endregion
		
		#region Deamon
		private void StartDeamon()
		{
			hostname = Dns.GetHostName();
			IPAddress [] IPA = Dns.GetHostAddresses(hostname);
			IPAddress localAddr = IPAddress.Parse(IPA[0].ToString());
			
		    Console.Out.WriteLine("Started Deamon on " + hostname );
			

			while (run)
            {
                Thread.Sleep(msec);
                OnTick();
   			} // end while
			
			this.Stop();

            Console.Out.WriteLine("Stopped Deamon.");
		}
        
		#endregion

        void  System.IDisposable.Dispose()
        {
            Stop();

        }
        
	}
}
