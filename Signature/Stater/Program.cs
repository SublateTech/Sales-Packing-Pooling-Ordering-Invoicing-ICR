using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Text.RegularExpressions;


namespace Signature
{
    
    static class Program
    {
        private static String SourcePath = "G:\\SigData\\";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] Params )
        {
            if (IsThere("SigData")  || IsThere("Signature Fundraising") )
            {
                MessageBox.Show("There is another process already running...please wait");
                Application.Exit();
                return;
            }
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            frmPresentation ofrm = new frmPresentation();
            ofrm.Show();
            ofrm.Update();

            AutoUpdate oAuto = new AutoUpdate(ofrm);

            if (Params.Length > 0 && Params[0] == "Update")
                oAuto.PublishFiles();
            else
            {
                if (Params.Length > 0 && Params[0] == "All")
                    oAuto.IsAll = true;
                oAuto.UpdateFiles();
            }
            ofrm.txtMessage.Text = "Loading Main Module  ...";
            ofrm.Update();



            String Program;

            if (Params.Length > 0 && Params[0] == "Packing")
                Program ="Packing.exe";
            else if (Params.Length > 0 && Params[0] == "Scanning")
                Program = "Scanning.exe";
            else
                Program = "SigData.exe";

            if (!oAuto.IsAll)
            {

                System.Diagnostics.Process.Start(((Type.GetType("Mono.Runtime") != null) ? "mono " : "") + Application.StartupPath + "/" + Program, "");
                do
                {
                } while (!IsThere((Type.GetType("Mono.Runtime") != null) ? "mono" : Program));
            }
            Application.Exit();

            return;

        }
        
        private static Boolean IsThere(String Program)
        {
            Process[] Processes = System.Diagnostics.Process.GetProcesses();
            foreach (Process _Process in Processes)
            {
                try
                {
                    //MessageBox.Show(_Process.MainModule.ModuleName);
                    if (_Process.MainModule.ModuleName.ToUpper() == Program.ToUpper())
                        return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("SigData.exe was not loaded..."+ex.Message);
                    return true; ;
                    
                }
            }
            return false;
        }
        
    }

    internal class AutoUpdate
    {
        //FTP Client
        FTP oFTP = new FTP();
        
        //File Managment
        private FileInfo t;
        private StreamWriter tw;
        private String FileName;

        //File List 
        private ArrayList Files = new ArrayList();
        private String[] FileList;

        // Fields
        private string m_ErrorMessage;
        private string m_RemotePath;
        private string m_UpdateFileName;
        private string m_Server="lserver";

        public Boolean IsAll = false;

        private frmPresentation ofrm;

        public AutoUpdate(frmPresentation _ofrm)
        {
            ofrm = _ofrm;
        }


        // Properties
        public string ErrorMessage { get { return m_ErrorMessage; } set { m_ErrorMessage = value; } }
        public string RemotePath { get { return m_ErrorMessage; } set { m_RemotePath = value; } }
        public string UpdateFileName { get { return m_UpdateFileName; } set { m_UpdateFileName = value; } }

        public AutoUpdate()
        {
            m_RemotePath = "";
            m_UpdateFileName = "SigData.txt";
            m_ErrorMessage = "There was a problem running the Auto Update.";
        }
        private string GetVersion(string Version)
        {
            //string[] x = String.Split(Version, ".", -1, CompareMethod.Binary);
            //return string.Format("{0:00000}{1:00000}{2:00000}{3:00000}", new object[] { RuntimeHelpers.GetObjectValue(Conversion.Int(x[0])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[1])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[2])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[3])) });
            return "";
        }
       

        public void SendFile(String File)
        {
            frmProgress ofrm = new frmProgress();
            ofrm.Show();

            FTP.FTPPlumbing.Timeout = 50000;
            FTP.FTPPlumbing.PassiveMode = true;

            FTP oFTP = new FTP();
            oFTP.Connect("192.168.254.65", "alvaro", "michelle"); //mail.giftcoinc.com

            oFTP.ChangeDirectory("SigData");
            
            
            oFTP.Files.Upload(File);
            while (!oFTP.Files.UploadComplete)
            {
                //MessageBox.Show("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
                ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                ofrm.txtBar.Update();
                ofrm.Update();
                Application.DoEvents();
            }
            //MessageBox.Show("Upload Complete: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
            ofrm.txtBar.Value = oFTP.Files.PercentComplete;
            ofrm.Update();
            Application.DoEvents();

            oFTP.Disconnect();

            return;
        }
        public void SendFiles()
        {
            
            Application.DoEvents();

            if (Connect())
            {

                foreach (FTP.File File in Files)
                {
                    ofrm.txtBar.Value = 0;
                    ofrm.txtMessage.Text = "Uploading ... " +File.FileName;
                    Application.DoEvents();
                    oFTP.Files.Upload(File.FileName);
                    while (!oFTP.Files.UploadComplete)
                    {
                        ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                        ofrm.txtBar.Update();
                        ofrm.Update();
                        Application.DoEvents();
                    }
                    ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                    ofrm.Update();
                    Application.DoEvents();
                }
                
            }
            return;
        }
        public void GetFile(String File)
        {
            frmProgress ofrm = new frmProgress();
            ofrm.Show();
            
            FTP.FTPPlumbing.Timeout = 50000;
            FTP.FTPPlumbing.PassiveMode = true;

            FTP oFTP = new FTP();
            oFTP.Connect("lserver", "SigData", "SigData009"); //mail.giftcoinc.com
            //oFTP.ChangeDirectory("SigData");
            ofrm.txtFileName.Text = File;
            oFTP.Files.Download(File);
            while (!oFTP.Files.DownloadComplete)
            {
                //MessageBox.Show("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
                ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                ofrm.txtBar.Update();
                ofrm.Update();
                Application.DoEvents();
            }

            ofrm.txtBar.Value = oFTP.Files.PercentComplete;
            ofrm.Update();
            Application.DoEvents();

            ofrm.Dispose();
            oFTP.Disconnect();

            return;
        }
        public void GetFiles()
        {
            Application.DoEvents();

            if (Connect())
            {
                foreach (FTP.File File in Files)
                {
                 //   MessageBox.Show(File);
                    ofrm.txtBar.Value = 0;
                    ofrm.txtMessage.Text = "Downloading ... "+ File.FileName;
                    Application.DoEvents();
                    oFTP.Files.Download(File);
                    while (!oFTP.Files.DownloadComplete)
                    {
                        ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                        ofrm.txtBar.Update();
                        ofrm.Update();
                        Application.DoEvents();
                    }
                    ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                    ofrm.Update();
                    Application.DoEvents();

                }
                Clear();
                
            }
            return;
        }
        public void Add(String FileName)
        {
            Files.Add(new FTP.File(FileName));
        }
        public void Add(FTP.File File)
        {
            Files.Add(File);
        }
        public void Clear()
        {
            Files.Clear();
        }
        private void ReadConfigFile()
        {
            FileList = File.ReadAllText(Application.StartupPath + "/" + "SigData.txt").Replace("\x0A", "").Split('\x0D');
            return;
        }
        private void ReadUpdateFile()
        {
            FileList = File.ReadAllText(Application.StartupPath + "/" + "SigData.Upd").Replace("\x0A", "").Split('\x0D');
            return;
        }
        public void PublishFiles()
        {
            this.ReadConfigFile();
            //Copy
            Clear();
            Open("SigData.Upd");

            foreach (String _FileName in FileList)
            {
                if (_FileName.Trim().Length > 0)
                {
                    String[] Info = _FileName.Split(';');
                    AddLine(Info[0] + ";" + File.GetLastWriteTime(Application.StartupPath + "/" + Info[0]).Ticks.ToString() + ";"); //("MM/dd/yyyy hh:mm")
                    Add(Info[0]);
                }
            }
            Close();
            Add("SigData.Upd");
            SendFiles();
            Disconnect();
        }
        public void UpdateFiles()
        {
            //Copy
            Clear();
            Add("SigData.Upd");
            GetFiles();
            this.ReadUpdateFile();

            foreach (String _FileName in FileList)
            {
                if (_FileName.Trim().Length > 0)
                {
                    String[] Info = _FileName.Split(';');
                    //Copy Operation
                    if (Convert.ToInt64((new DateTime(Convert.ToInt64(Info[1]))).ToString("yyyyMMddhhmmss")) > Convert.ToInt64(File.GetLastWriteTime(Application.StartupPath + "/" + Info[0]).ToString("yyyyMMddhhmmss")) || IsAll)
                    {
                        Add(new FTP.File(Info[0], new DateTime(Convert.ToInt64(Info[1]))));
                        //MessageBox.Show(Info[0] + " " + Convert.ToInt64(Info[1]).ToString() + " -- " + File.GetLastWriteTime(Application.StartupPath + "/" + Info[0]).Ticks.ToString());
                    }

                }
            }
            if (Files.Count > 0)
                GetFiles();

        }

        public void Open(String _FileName)
        {
            this.FileName = _FileName;

            t = new FileInfo(FileName);
            tw = t.CreateText();
       
        }
        public void Close()
        {
            tw.Close();
        }
        public void AddLine(String Line)
        {
            tw.WriteLine(Line);
        }

        private Boolean Connect()
        {

            if (!FTP.FTPPlumbing.IsConnected)
            {
                FTP.FTPPlumbing.Timeout = 2000;
                FTP.FTPPlumbing.PassiveMode = false;

                oFTP.Connect(m_Server, "alvaro", "michelle"); //mail.giftcoinc.com
                if (FTP.FTPPlumbing.IsConnected)
                    oFTP.ChangeDirectory("SigData");    
            }
            return FTP.FTPPlumbing.IsConnected;
        }
        private void Disconnect()
        {
            oFTP.Disconnect();
        }


    }
	public class FTP
	{
		// JAC - Directories and Files are Collections now
		public DirectoryCollection Directories = new DirectoryCollection();
		public FileCollection Files = new FileCollection();

		#region Properties

		public string ServerIP
		{
			get { return FTPPlumbing.ServerIP; }
		}
		public string UserName
		{
			get { return FTPPlumbing.UserName; }
		}
		public string PassWord
		{
			get { return FTPPlumbing.PassWord; }
		}
		public int Port
		{
			get { return FTPPlumbing.Port; }
		}
		public long TotalBytes
		{
			get { return lTotalBytes; }
			set { lTotalBytes = value; }
		}
		public long FileSize
		{
			get { return lFileSize; }
			set { lFileSize = value; }
		}
		public bool MessagesAvailable
		{
			get { return (FTPPlumbing.Messages.Length > 0); }
		}


		#endregion Properties

		#region Private Variables

		private long lTotalBytes = 0;	// upload/download info if the user wants it.
		private long lFileSize;			// gets set when an upload or download takes place

		#endregion

		#region Constructors

		public void FTP_local()
		{
		}
		public void FTP_local(string sServer, string sUsername, string sPassword)
		{
			FTPPlumbing.ServerIP = sServer;
			FTPPlumbing.UserName = sUsername;
			FTPPlumbing.PassWord = sPassword;
		}
		public void FTP_local(string sServer, int iPort, string sUsername, string sPassword)
		{
			FTPPlumbing.ServerIP = sServer;
			FTPPlumbing.UserName = sUsername;
			FTPPlumbing.PassWord = sPassword;
			FTPPlumbing.Port = iPort;
		}


		#endregion

		/// <summary>
		/// Establish a Connection to the Server
		/// </summary>
		public void Connect()
		{
			Connect(ServerIP, Port, UserName, PassWord);
		}
		/// <summary>
		/// Establish a Connection to the Server
		/// </summary>
		/// <param name="sServer">Server Address for Connection</param>
		/// <param name="sUsername">Username for Connection</param>
		/// <param name="sPassword">Password for Connection</param>
		public void Connect(string sServer, string sUsername, string sPassword)
		{
			Connect(sServer, Port, sUsername, sPassword);
		}
		/// <summary>
		/// Establish a Connection to the Server
		/// </summary>
		/// <param name="sServer">Server Address for Connection</param>
		/// <param name="iPort">Specified Port for Connection</param>
		/// <param name="sUsername">Username for Connection</param>
		/// <param name="sPassword">Password for Connection</param>
		public void Connect(string sServer, int iPort, string sUsername, string sPassword)
		{
			FTPPlumbing.Connect(sServer, iPort, sUsername, sPassword);
		}

		/// <summary>
		/// Closes all connections to the ftp server
		/// </summary>
		public void Disconnect() // Closes all connections to the ftp server
		{
			FTPPlumbing.Disconnect();
		}

		/// <summary>
		/// Change the Current Directory
		/// </summary>
		/// <param name="sPath">Name of Directory (no back slashes)</param>
		public void ChangeDirectory(string sPath)
		{
			if (FTPPlumbing.IsConnected)
			{
				FTPPlumbing.SendCommand("CWD " + sPath);

				if (FTPPlumbing.ResponseCode == FTPPlumbing.FTPResponseCode.FileActionCompleted) // 250 = Requested file action okay, completed
				{
					RebuildDirectoryList();
				}
				else
				{
#if (FTP_DEBUG)
					Console.Write("\r" + ResponseString);
#endif

					throw new Exception(FTPPlumbing.ResponseString);
				}
			}
			else
			{
				throw new Exception("FTP Not Connected - Unable to Change Directory");
			}
		}
		/// <summary>
		/// Re-build the Directory List after a Directory Change
		/// </summary>
		public void RebuildDirectoryList()
		{
			StringBuilder sbDirectoryList = FTPPlumbing.GetDirectoryList();

			Directories.Clear();
			Files.Clear();

			foreach (string f in sbDirectoryList.ToString().Split('\n'))
			{
				if (f.Length > 0 && !Regex.Match(f, "^total").Success)
				{
					//FILIPE MADUREIRA
					//In Windows servers it is identified by <DIR>
					if ((f[0] == 'd') || (f.ToUpper().IndexOf("<DIR>") >= 0))
					{
						Directories.Add(f);
					}
					else
					{
						Files.Add(f);
					}
				}
			}
		}


		public class FTPPlumbing
		{
			#region Private Members

			static private FTPResponseCode eResponseCode;
			static private string sResponse;		// server response if the user wants it.
			static private string sMessages = "";	// server messages
			static private string sServerIP = "";
			static private string sUsername = "";
			static private string sPassword = "";
			static private int iPort = 21;
			static private string sBucket = "";
			static private int iTimeout = 10000;	// 1000 = 1 Second
			static private bool bPassiveMode = true;

			#endregion Private Members

			#region Internal Members

			static internal Socket main_sock;
			static internal Socket listening_sock;
			static internal Socket data_sock;
			static internal IPEndPoint main_ipEndPoint;
			static internal IPEndPoint data_ipEndPoint;
			static internal FileStream file;

			#endregion Internal Members

			#region Public Properties

			/// <summary>
			/// Enumerated FTP Response Codes
			/// </summary>
			public enum FTPResponseCode
			{
				DataConnectionAlreadyOpen = 125,
				FileStatusOK = 150,
				CommandOK = 200,
				FileStatus = 213,
				ReadyForNewUser = 220,
				RequestSuccessful = 226,
				EnteringPassiveMode = 227,
				UserLoggedIn = 230,
				FileActionCompleted = 250,
				PathCreated = 257,
				UserOKNeedPassword = 331,
				FileActionPended = 350
			}


			/// <summary>
			/// Current FTP Response Code
			/// </summary>
			static public FTPResponseCode ResponseCode
			{
				get { return eResponseCode; }
				set { eResponseCode = value; }
			}
			
			/// <summary>
			/// Server IP Address for Connection
			/// </summary>
			static public string ServerIP
			{
				get { return sServerIP; }
				set { sServerIP = value; }
			}
			
			/// <summary>
			/// User Specified Username for Connection
			/// </summary>
			static public string UserName
			{
				get { return sUsername; }
				set { sUsername = value; }
			}
			
			/// <summary>
			/// User Specified Password for Connection
			/// </summary>
			static public string PassWord
			{
				get { return sPassword; }
				set { sPassword = value; }
			}
			
			/// <summary>
			/// Response String, Contains Details of the FTP Response
			/// </summary>
			static public string ResponseString
			{
				get { return sResponse; }
				set { sResponse = value; }
			}
			
			/// <summary>
			/// Messages from the Server
			/// </summary>
			static public string Messages
			{
				get
				{
					string tmp = sMessages;
					sMessages = "";
					return tmp;
				}
			}
			
			/// <summary>
			/// User Specified FTP Timeout: Defaults to 10000 (10 seconds)
			/// </summary>
			static public int Timeout
			{
				get { return iTimeout; }
				set { iTimeout = value; }
			}
			
			/// <summary>
			/// User Specified Port: Defaults to 21
			/// </summary>
			static public int Port
			{
				get { return iPort; }
				set { iPort = value; }
			}
			
			/// <summary>
			/// PassiveMode: Defaults to True
			/// </summary>
			static public bool PassiveMode
			{
				get { return bPassiveMode; }
				set { bPassiveMode = value; }
			}
			
			/// <summary>
			/// Indicates if FTP is Connected
			/// </summary>
			static public bool IsConnected
			{
				get { return ((main_sock != null) ? main_sock.Connected : false); }
			}


			#endregion Public Properties

			internal static void Fail()
			{
				Fail(new Exception(ResponseString));
			}
			internal static void Fail(Exception e)
			{
				Disconnect();
				throw e;
			}

			internal static void Connect()
			{
				Connect(ServerIP, Port, UserName, PassWord);
			}
			internal static void Connect(string sServer, int iPort, string sUser, string sPass)
			{
				ServerIP = sServer;
				UserName = sUser;
				PassWord = sPass;
				Port = iPort;

				if (ServerIP.Length == 0)
				{
					throw new Exception("Unable to Connect - No Server Specified.");
				}

				if (UserName.Length == 0)
				{
					throw new Exception("Unable to Connect - No Username Specified.");
				}

				if (main_sock != null)
				{
					if (main_sock.Connected)
					{
						return;
					}
				}

				main_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				main_ipEndPoint = new IPEndPoint(Dns.GetHostEntry(ServerIP).AddressList[0], Port);

				try
				{
					main_sock.Connect(main_ipEndPoint);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				ReadResponse();

				if (ResponseCode != FTPResponseCode.ReadyForNewUser)
				{
					Fail();
				}

				SendCommand("USER " + UserName);

				switch (ResponseCode)
				{
					case FTPResponseCode.UserOKNeedPassword: // 331 = User name okay, need password
						if (PassWord == null)
						{
							Fail(new Exception("No password has been set."));
						}

						SendCommand("PASS " + PassWord);

						if (ResponseCode != FTPResponseCode.UserLoggedIn) // 230 = User logged in, proceed
						{
							Fail();
						}
						break;

					case FTPResponseCode.UserLoggedIn: // 230 = User logged in, proceed
						break;
				}

				return;
			}

			internal static void Disconnect() // Closes all connections to the ftp server
			{
				if (file != null)
				{
					file.Close();
				}

				CloseDataSocket();

				if (main_sock != null)
				{
					if (main_sock.Connected)
					{
						SendCommand("QUIT");
						main_sock.Close();
					}

					main_sock = null;
				}

				main_ipEndPoint = null;
				file = null;
			}


			// if you add code that needs a data socket, i.e. a PASV or PORT command required,
			// call this function to do the dirty work. It sends the PASV or PORT command,
			// parses out the port and ip info and opens the appropriate data socket
			// for you. The socket variable is private Socket data_socket. Once you
			// are done with it, be sure to call CloseDataSocket()
			internal static void OpenDataSocket()
			{
				if (PassiveMode)
				{
					string[] pasv;
					string sServer;
					int iPort;

					Connect();
					SendCommand("PASV");

					if (ResponseCode != FTPResponseCode.EnteringPassiveMode) 
					{
						Fail();
					}

					try
					{
						int i1, i2;

						i1 = ResponseString.IndexOf('(') + 1;
						i2 = ResponseString.IndexOf(')') - i1;
						pasv = ResponseString.Substring(i1, i2).Split(',');
					}
					catch (Exception)
					{
						Fail(new Exception("Malformed PASV response: " + ResponseString));
						throw new Exception("Malformed PASV response: " + ResponseString);
					}

					if (pasv.Length < 6)
					{
						Fail(new Exception("Malformed PASV response: " + ResponseString));
					}

					sServer = String.Format("{0}.{1}.{2}.{3}", pasv[0], pasv[1], pasv[2], pasv[3]);
					iPort = (int.Parse(pasv[4]) << 8) + int.Parse(pasv[5]);

					try
					{
#if (FTP_DEBUG)
					Console.WriteLine("Data socket: {0}:{1}", server, port);
#endif

						CloseDataSocket();

#if (FTP_DEBUG)
					Console.WriteLine("Creating socket...");
#endif

						data_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

#if (FTP_DEBUG)
					Console.WriteLine("Resolving host");
#endif

						data_ipEndPoint = new IPEndPoint(Dns.GetHostEntry(ServerIP).AddressList[0], iPort);


#if (FTP_DEBUG)
					Console.WriteLine("Connecting..");
#endif

						data_sock.Connect(data_ipEndPoint);

#if (FTP_DEBUG)
					Console.WriteLine("Connected.");
#endif
					}
					catch (Exception e)
					{
						throw new Exception("Failed to connect for data transfer: " + e.Message);
					}
				}
				else
				{
					Connect();

					try
					{
#if (FTP_DEBUG)
					Console.WriteLine("Data socket (active mode)");
#endif

						CloseDataSocket();

#if (FTP_DEBUG)
					Console.WriteLine("Creating listening socket...");
#endif

						listening_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

#if (FTP_DEBUG)
					Console.WriteLine("Binding it to local address/port");
#endif

						// for the PORT command we need to send our IP address; let's extract it
						// from the LocalEndPoint of the main socket, that's already connected
						string sLocAddr = main_sock.LocalEndPoint.ToString();
						int ix = sLocAddr.IndexOf(':');

						if (ix < 0)
						{
							throw new Exception("Failed to parse the local address: " + sLocAddr);
						}

						string sIPAddr = sLocAddr.Substring(0, ix);
						// let the system automatically assign a port number (setting port = 0)
						System.Net.IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(sIPAddr), 0);

						listening_sock.Bind(localEP);
						sLocAddr = listening_sock.LocalEndPoint.ToString();
						ix = sLocAddr.IndexOf(':');

						if (ix < 0)
						{
							throw new Exception("Failed to parse the local address: " + sLocAddr);
						}

						int nPort = int.Parse(sLocAddr.Substring(ix + 1));

#if (FTP_DEBUG)
					Console.WriteLine("Listening on {0}:{1}", sIPAddr, nPort);
#endif

						// start to listen for a connection request from the host 
						// (note that listening is not blocking) and send the PORT command
						listening_sock.Listen(1);
						string sPortCmd = string.Format("PORT {0},{1},{2}",
							sIPAddr.Replace('.', ','),
							nPort / 256, nPort % 256);
						SendCommand(sPortCmd);

						if (ResponseCode != FTPResponseCode.CommandOK) // 200 = Command okay
						{
							Fail();
						}
					}
					catch (Exception e)
					{
						throw new Exception("Failed to connect for data transfer: " + e.Message);
					}
				}
			}
			internal static void ConnectDataSocket()
			{
				if (data_sock != null)		// already connected (always so if passive mode)
					return;

				try
				{
#if (FTP_DEBUG)
				Console.WriteLine("Accepting the data connection.");
#endif

					data_sock = listening_sock.Accept();	// Accept is blocking
					listening_sock.Close();
					listening_sock = null;

					if (data_sock == null)
					{
						throw new Exception("Winsock error: " +
							Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()));
					}

#if (FTP_DEBUG)
				Console.WriteLine("Connected.");
#endif
				}
				catch (Exception ex)
				{
					throw new Exception("Failed to connect for data transfer: " + ex.Message);
				}
			}
			internal static void CloseDataSocket()
			{
#if (FTP_DEBUG)
			Console.WriteLine("Attempting to close data channel socket...");
#endif

				if (data_sock != null)
				{
					if (data_sock.Connected)
					{
#if (FTP_DEBUG)
					Console.WriteLine("Closing data channel socket!");
#endif

						data_sock.Close();

#if (FTP_DEBUG)
					Console.WriteLine("Data channel socket closed!");
#endif
					}

					data_sock = null;
				}

				data_ipEndPoint = null;
			}


			// Any time a command is sent, use ReadResponse() to get the response
			// from the server. The variable responseStr holds the entire string and
			// the variable response holds the response number.
			internal static void ReadResponse()
			{
				string sBuffer;
				sMessages = "";

				while (true)
				{
					sBuffer = GetLineFromBucket();

#if (FTP_DEBUG)
				Console.WriteLine(sBuffer);
#endif

					if (Regex.Match(sBuffer, "^[0-9]+ ").Success)
					{
						ResponseString = sBuffer;
						ResponseCode = (FTPResponseCode)int.Parse(sBuffer.Substring(0, 3));
						break;
					}
					else
					{
						sMessages += Regex.Replace(sBuffer, "^[0-9]+-", "") + "\n";
					}
				}
			}
			internal static void SetBinaryMode(bool bMode)
			{
				SendCommand("TYPE " + ((bMode) ? "I" : "A"));

				switch (ResponseCode)
				{
					case FTPResponseCode.RequestSuccessful:
					case FTPResponseCode.CommandOK:
						break;

					default:
						Fail();
						break;
				}
			}
			internal static void SendCommand(string sCommand)
			{
				Connect();

				Byte[] byCommand = Encoding.ASCII.GetBytes((sCommand + "\r\n").ToCharArray());

#if (FTP_DEBUG)
							if (sCommand.Length > 3 && sCommand.Substring(0, 4) == "PASS")
								Console.WriteLine("\rPASS xxx");
							else
								Console.WriteLine("\r" + sCommand);
#endif

				main_sock.Send(byCommand, byCommand.Length, 0);
				ReadResponse();
			}
			internal static void FillBucket()
			{
				Byte[] bytes = new Byte[512];
				long lBytesRecieved;
				int iMilliSecondsPassed = 0;

				while (main_sock.Available < 1)
				{
					System.Threading.Thread.Sleep(50);
					iMilliSecondsPassed += 50;

					if (iMilliSecondsPassed > Timeout) // Prevents infinite loop
					{
						Fail(new Exception("Timed out waiting on server to respond."));
					}
				}

				while (main_sock.Available > 0)
				{
					// gives any further data not yet received, a small chance to arrive
					lBytesRecieved = main_sock.Receive(bytes, 512, 0);
					sBucket += Encoding.ASCII.GetString(bytes, 0, (int)lBytesRecieved);
					System.Threading.Thread.Sleep(50);
				}
			}
			internal static string GetLineFromBucket()
			{
				string sBuffer = "";
				int i = sBucket.IndexOf('\n');

				while (i < 0)
				{
					FillBucket();
					i = sBucket.IndexOf('\n');
				}

				sBuffer = sBucket.Substring(0, i);
				sBucket = sBucket.Substring(i + 1);

				return sBuffer;
			}
			internal static StringBuilder GetDirectoryList()
			{
				Byte[] bytes = new Byte[512];
				StringBuilder sbDirectoryList = new StringBuilder();
				long lBytesReceived = 0;
				int iMilliSecondsPassed = 0;

				if (FTPPlumbing.IsConnected)
				{
					#region Connection

					FTPPlumbing.OpenDataSocket();
					FTPPlumbing.SendCommand("LIST");

					//FILIPE MADUREIRA.
					//Added response 125
					switch (FTPPlumbing.ResponseCode)
					{
						case FTPPlumbing.FTPResponseCode.DataConnectionAlreadyOpen: // 125 = Data connection already open; transfer starting
						case FTPPlumbing.FTPResponseCode.FileStatusOK: // 150 = File status okay; about to open data connection
							break;

						default:
							FTPPlumbing.CloseDataSocket();
							throw new Exception(FTPPlumbing.ResponseString);
					}

					FTPPlumbing.ConnectDataSocket();

					while (FTPPlumbing.data_sock.Available < 1)
					{
						System.Threading.Thread.Sleep(50);
						iMilliSecondsPassed += 50;
						// this code is just a fail safe option 
						// so the code doesn't hang if there is 
						// no data comming.
						if (iMilliSecondsPassed > (FTPPlumbing.Timeout / 10))
						{
							//FILIPE MADUREIRA.
							//If there are no files to list it gives timeout.
							//So I wait less time and if no data is received, means that there are no files
							break; //Maybe there are no files
						}
					}

					#endregion Connection

					while (FTPPlumbing.data_sock.Available > 0)
					{
						lBytesReceived = FTPPlumbing.data_sock.Receive(bytes, bytes.Length, 0);
						sbDirectoryList.Append(Encoding.ASCII.GetString(bytes, 0, (int)lBytesReceived));
						System.Threading.Thread.Sleep(50); // *shrug*, sometimes there is data comming but it isn't there yet.
					}

					FTPPlumbing.CloseDataSocket();
					FTPPlumbing.ReadResponse();

					if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.RequestSuccessful) // 226 = Closing data connection. Requested file action successful
					{
						throw new Exception(FTPPlumbing.ResponseString);
					}
				}
				else
				{
					throw new Exception("FTP Not Connected - Unable to List Directories and Files");
				}

				return sbDirectoryList;
			}
		}

		/// <summary>
		/// Contains a Collection of Directory Entries for the Current Directory
		/// </summary>
		public class DirectoryCollection : System.Collections.CollectionBase
		{
			// JAC
			// Directory Collection

			/// <summary>
			/// Reference to a Directory Object
			/// </summary>
			public Directory this[int iIndex]
			{
				get { return (Directory)List[iIndex]; }
			}

			public DirectoryCollection() { }
			public DirectoryCollection(string sDirectoryName, DateTime dtDirectoryDate)
			{
				List.Add(new Directory(sDirectoryName, dtDirectoryDate));
			}

			/// <summary>
			/// Parse and Add a New Directory to the Collection
			/// </summary>
			/// <param name="sUnparsedDirectory">Unparsed Directory Entry String from the FTP Server</param>
			public void Add(string sUnparsedDirectory)
			{
				string sDirectoryName = sUnparsedDirectory.Substring(39).Trim().Replace("\r", "");
                DateTime dtDirectoryDate = new DateTime(DateTime.Now.Year, GetMonthNumber(sUnparsedDirectory.Substring(43, 3)), Convert.ToInt32(sUnparsedDirectory.Substring(47, 2)), Convert.ToInt32(sUnparsedDirectory.Substring(50, 2)), Convert.ToInt32(sUnparsedDirectory.Substring(53, 2)), 0);

				Add(sDirectoryName, dtDirectoryDate);
			}
            public int GetMonthNumber(String Month)
            {
                //Delcaring MonthNames in the Array
                String[] MonthNames ={ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                for (int x = 0; MonthNames.Length > x; x++)
                {
                    if (Month == MonthNames[x].Substring(0, 3))
                        return x + 1;
                }
                return -1;
            }
			/// <summary>
			/// Add a New Directory to the Collection
			/// </summary>
			/// <param name="sDirectoryName">Name of Directory to Add</param>
			/// <param name="dtDirectoryDate">Date of Directory to Add</param>
			public void Add(string sDirectoryName, DateTime dtDirectoryDate)
			{
				List.Add(new Directory(sDirectoryName, dtDirectoryDate));
			}
			/// <summary>
			/// Rebuilds the Directory Collection
			/// </summary>
			public void RebuildDirectoryList()
			{
				StringBuilder sbDirectoryList = FTPPlumbing.GetDirectoryList();
				this.Clear();

				foreach (string f in sbDirectoryList.ToString().Split('\n'))
				{
					if (f.Length > 0 && !Regex.Match(f, "^total").Success)
					{
						//FILIPE MADUREIRA
						//In Windows servers it is identified by <DIR>
						if ((f[0] == 'd') || (f.ToUpper().IndexOf("<DIR>") >= 0))
						{
							this.Add(f);
						}
					}
				}
			}

			/// <summary>
			/// Creates a New Directory
			/// </summary>
			/// <param name="sDirectory"></param>
			public void MakeDirectory(string sDirectory)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SendCommand("MKD " + sDirectory);

					switch (FTPPlumbing.ResponseCode)
					{
						case FTPPlumbing.FTPResponseCode.PathCreated: 
						case FTPPlumbing.FTPResponseCode.FileActionCompleted:
							RebuildDirectoryList();
							break;

						default:
#if (FTP_DEBUG)
                    Console.Write("\r" + ResponseString);
#endif

							throw new Exception(FTPPlumbing.ResponseString);
					}
				}
				else
				{
					throw new Exception("FTP Not Connected - Unable to Make Directory");
				}
			}
			public void RemoveDirectory(string sDirectory)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SendCommand("RMD " + sDirectory);

					if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionCompleted)
					{
#if (FTP_DEBUG)
						Console.Write("\r" + ResponseString);
#endif

						throw new Exception(FTPPlumbing.ResponseString);
					}
					else
					{
						RebuildDirectoryList();
					}
				}
				else
				{
					throw new Exception("FTP Not Connected - Unable to Remove Directory");
				}
			}
			/// <summary>
			/// Get Current Working Directory
			/// </summary>
			/// <returns>Returns a String Containing the Name of the Current Working Directory</returns>
			public string GetWorkingDirectory()
			{
				string sWorkingDirectory = "";

				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SendCommand("PWD"); //PWD = Print wErking Directory

					if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.PathCreated)
					{
						throw new Exception(FTPPlumbing.ResponseString);
					}

					try
					{
						sWorkingDirectory = FTPPlumbing.ResponseString.Substring(FTPPlumbing.ResponseString.IndexOf("\"", 0) + 1);
						sWorkingDirectory = sWorkingDirectory.Substring(0, sWorkingDirectory.LastIndexOf("\""));
						sWorkingDirectory = sWorkingDirectory.Replace("\"\"", "\""); // directories with quotes in the name come out as "" from the server
					}
					catch (Exception ex)
					{
						throw new Exception("Uhandled PWD response: " + ex.Message);
					}
				}
				else
				{
					throw new Exception("FTP Not Connected - Print Working Directory");
				}

				return sWorkingDirectory;
			}
		}

		public class Directory
		{
			// JAC
			// Directory Objects in the Collection

			private string sDirectoryName = "";
			private DateTime dtDirectoryDate;

			/// <summary>
			/// Name of Directory
			/// </summary>
			public string DirectoryName
			{
				get { return sDirectoryName; }
				set { sDirectoryName = value; }
			}

			/// <summary>
			/// Creation Date of Directory
			/// </summary>
			public DateTime DirectoryDate
			{
				get { return dtDirectoryDate; }
				set { dtDirectoryDate = value; }
			}

			public Directory(string sDirectoryName, DateTime dtDirectoryDate)
			{
				DirectoryName = sDirectoryName;
				DirectoryDate = dtDirectoryDate;
			}
		}

		public class FileCollection : System.Collections.CollectionBase
		{
			// JAC
			// File Collection

			#region Private Members

			private Byte[] bytes = new Byte[512];
			private long lBytesReceived;
			private long lTotalBytes = 0;
			private long lFileSize = 0;
			private int iPercentComplete = 0;
			private int iIndexFound = -1;
			private int i = 0;
			private bool bComplete = false;
            private DateTime SelectedFileDate;
            private String SelectedFileName;

			private long SelectedFileSize
			{
				get { return lFileSize; }
				set { lFileSize = value; }
			}


			#endregion Private Members

			/// <summary>
			/// The total number of bytes sent/recieved in a transfer
			/// </summary>
			public long TotalBytes
			{
				get { return lTotalBytes; }
				set { lTotalBytes = value; }
			}
			/// <summary>
			/// Indicates if the Current Upload Operation has Completed
			/// </summary>
			public bool UploadComplete
			{
				get
				{
					try
					{
						lBytesReceived = FTPPlumbing.file.Read(bytes, 0, bytes.Length);
						bComplete = false;

						if (lBytesReceived > 0)
						{
							FTPPlumbing.data_sock.Send(bytes, (int)lBytesReceived, 0);
							TotalBytes += lBytesReceived;

							PercentComplete = (int)(((TotalBytes) * 100) / SelectedFileSize); ;

							if (PercentComplete >= 100)
							{
								bComplete = true;
							}
						}
						else
						{
							bComplete = true;
						}

						#region Upload Complete?

						if (bComplete) // Upload Complete or an Error Occured
						{
							
							FTPPlumbing.file.Close();
							FTPPlumbing.file = null;

							FTPPlumbing.CloseDataSocket();
							FTPPlumbing.ReadResponse();

							switch (FTPPlumbing.ResponseCode)
							{
								case FTPPlumbing.FTPResponseCode.RequestSuccessful: 
								case FTPPlumbing.FTPResponseCode.FileActionCompleted:
									RebuildFileList();
									break;

								default:
									throw new Exception(FTPPlumbing.ResponseString);
									
							}

							FTPPlumbing.SetBinaryMode(false);
						}

						#endregion Upload Complete?
					}
					catch (Exception e)
					{
						FTPPlumbing.file.Close();
						FTPPlumbing.file = null;
						FTPPlumbing.CloseDataSocket();
						FTPPlumbing.ReadResponse();
						FTPPlumbing.SetBinaryMode(false);
						throw e;
					}

					return bComplete;
				}
			}
			/// <summary>
			/// Indicates if the Current Download Operation has Completed
			/// </summary>
			public bool DownloadComplete
			{
				get
				{
					try
					{
						lBytesReceived = FTPPlumbing.data_sock.Receive(bytes, bytes.Length, 0);
						bComplete = false;

						if (lBytesReceived > 0)
						{
							FTPPlumbing.file.Write(bytes, 0, (int)lBytesReceived);
							TotalBytes += lBytesReceived;

							PercentComplete = (int)(((TotalBytes) * 100) / SelectedFileSize); ;

							if (PercentComplete >= 100)
							{
								bComplete = true;
							}
						}
						else
						{
							bComplete = true;
						}

						#region Download Complete?

						if (bComplete) // Download Complete or an Error Occured
						{

							FTPPlumbing.CloseDataSocket();
							FTPPlumbing.file.Close();
							FTPPlumbing.file = null;
                            try
                            {
                                System.IO.File.SetLastWriteTime(SelectedFileName, SelectedFileDate);
                                //System.IO.File.SetLastAccessTime(SelectedFileName, SelectedFileDate);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }

							FTPPlumbing.ReadResponse();
/*
							switch (FTPPlumbing.ResponseCode)
							{
								case FTPPlumbing.FTPResponseCode.RequestSuccessful:
								case FTPPlumbing.FTPResponseCode.FileActionCompleted:
									RebuildFileList();
									break;

								default:
									throw new Exception(FTPPlumbing.ResponseString);
									
							}

							FTPPlumbing.SetBinaryMode(false);*/
						}

						#endregion Download Complete?
					}
					catch (Exception e)
					{
						FTPPlumbing.CloseDataSocket();
						FTPPlumbing.file.Close();
						FTPPlumbing.file = null;
						FTPPlumbing.ReadResponse();
						FTPPlumbing.SetBinaryMode(false);
						throw e;
					}

					return bComplete;
				}
			}
			/// <summary>
			/// Indicates Percentage Complete of Current Upload or Download Operation
			/// </summary>
			public int PercentComplete
			{
				get { return iPercentComplete; }
				set { iPercentComplete = value; }
			}

			/// <summary>
			///  Represents a File in the Collection
			/// </summary>
			public File this[int iIndex]
			{
				get { return (File)List[iIndex]; }
			}
			/// <summary>
			///  Represents a File in the Collection
			/// </summary>
			public File this[string sIndex]
			{
				get 
				{
					iIndexFound = -1;

					for (i = 0; i < this.Count; i++)
					{
                        if (((File)List[i]).FileName == sIndex)
						{
							iIndexFound = i;
							break;
						}
					}

					if (iIndexFound < 0)
					{
						throw new Exception("Unable to Find Requested File");
					}

					return (File)List[iIndexFound]; 
				}
			}

			public FileCollection() { }
			public FileCollection(string sFileName, int iFileSize, DateTime dtFileDate)
			{
				List.Add(new File(sFileName, iFileSize, dtFileDate));
			}

			/// <summary>
			/// Parse and Add a New File to the Collection
			/// </summary>
			/// <param name="sUnparsedDirectory">Unparsed File Entry String from the FTP Server</param>
			public void Add(string sUnparsedFile)
			{
                
                string sFileName = sUnparsedFile.Substring(55).Trim().Replace("\r", "");
                
                long lFileSize = Convert.ToUInt32(sUnparsedFile.Substring(30, 12).Trim());

                
                DateTime dtFileDate = new DateTime(DateTime.Now.Year, GetMonthNumber(sUnparsedFile.Substring(43, 3)),Convert.ToInt32(sUnparsedFile.Substring(47, 2)),Convert.ToInt32(sUnparsedFile.Substring(50, 2)),Convert.ToInt32(sUnparsedFile.Substring(53, 2)),0);

              //  MessageBox.Show(Convert.ToInt32(sUnparsedFile.Substring(50, 2)).ToString() + "-" +Convert.ToInt32(sUnparsedFile.Substring(53, 2).ToString()));
				Add(sFileName, lFileSize, dtFileDate);
			}

            public int GetMonthNumber(String Month)
            {
                //Delcaring MonthNames in the Array
                String[] MonthNames ={ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                for (int x=0; MonthNames.Length > x; x++)
                {
                    if (Month == MonthNames[x].Substring(0,3))
                        return x+1;
                }
                return -1;
            }

            
			/// <summary>
			/// Add a New File to the Collection
			/// </summary>
			/// <param name="sDirectoryName">Name of File to Add</param>
			/// <param name="lFileSize">Size of File to Add</param>
			/// <param name="dtDirectoryDate">Date of File to Add</param>
			public void Add(string sFileName, long lFileSize, DateTime dtFileDate)
			{
				List.Add(new File(sFileName, lFileSize, dtFileDate));
			}
			/// <summary>
			/// Rebuild the List of Files in the Collection
			/// </summary>
			public void RebuildFileList()
			{
				StringBuilder sbDirectoryList = FTPPlumbing.GetDirectoryList();
				this.Clear();

				foreach (string f in sbDirectoryList.ToString().Split('\n'))
				{
					if (f.Length > 0 && !Regex.Match(f, "^total").Success)
					{
						//FILIPE MADUREIRA
						//In Windows servers it is identified by <DIR>
						if ((f[0] != 'd') && (f.ToUpper().IndexOf("<DIR>") == 0))
						{
							this.Add(f);
						}
					}
				}
			}

			/// <summary>
			/// Upload a File to the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Upload</param>
			public void Upload(string sRemoteFilename)
			{
				Upload(sRemoteFilename, sRemoteFilename, false);
			}
			/// <summary>
			/// Upload a File to the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Store on the Server</param>
			/// <param name="bResume">Resume on Failure</param>
			public void Upload(string sRemoteFilename, bool bResume)
			{
				Upload(sRemoteFilename, sRemoteFilename, bResume);
			}
			/// <summary>
			/// Upload a File to the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Store on the Server</param>
			/// <param name="sLocalFilename">Name of File to Upload</param>
			public void Upload(string sRemoteFilename, string sLocalFilename)
			{
				Upload(sRemoteFilename, sLocalFilename, false);
			}
			/// <summary>
			/// Upload a File to the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Store on the Server</param>
			/// <param name="sLocalFilename">Name of File to Upload</param>
			/// <param name="bResume">Resume on Failure</param>
			public void Upload(string sRemoteFilename, string sLocalFilename, bool bResume)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.OpenDataSocket();
					FTPPlumbing.SetBinaryMode(true);
					TotalBytes = 0;
					PercentComplete = 0;

					#region Setup File

					try
					{
						FTPPlumbing.file = new FileStream(sLocalFilename, FileMode.Open);
					}
					catch (Exception e)
					{
						FTPPlumbing.file = null;
						throw e;
					}

					SelectedFileSize = FTPPlumbing.file.Length;

					if (bResume)
					{
						FTPPlumbing.SendCommand("REST " + this[sRemoteFilename].FileSize);

						if (FTPPlumbing.ResponseCode == FTPPlumbing.FTPResponseCode.FileActionPended)
						{
							FTPPlumbing.file.Seek(this[sRemoteFilename].FileSize, SeekOrigin.Begin);
						}
					}

					#endregion Setup File

					#region Connect Socket 

					FTPPlumbing.SendCommand("STOR " + sRemoteFilename);

					switch (FTPPlumbing.ResponseCode)
					{
						case FTPPlumbing.FTPResponseCode.DataConnectionAlreadyOpen:
						case FTPPlumbing.FTPResponseCode.FileStatusOK:
							break;

						default:
							FTPPlumbing.file.Close();
							FTPPlumbing.file = null;
							throw new Exception(FTPPlumbing.ResponseString);
					}

					FTPPlumbing.ConnectDataSocket();
				
					#endregion Connect Socket
				}
				else
				{
					throw new Exception("FTP Not Connected - Download Cannot Begin");
				}
			}
			/// <summary>
			/// Download a File from the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Download</param>
			public void Download(string sRemoteFilename)
			{
				Download(sRemoteFilename, sRemoteFilename, false);
			}
			/// <summary>
			/// Download a File from the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Download</param>
			/// <param name="bResume">Resume on Failure</param>
			public void Download(string sRemoteFilename, bool bResume)
			{
				Download(sRemoteFilename, sRemoteFilename, bResume);
			}
			/// <summary>
			/// Download a File from the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Download</param>
			/// <param name="sLocalFilename">Name to Save File as Locally</param>
			public void Download(string sRemoteFilename, string sLocalFilename)
			{
				Download(sRemoteFilename, sLocalFilename, false);
			}
			/// <summary>
			/// Download a File from the Server
			/// </summary>
			/// <param name="sRemoteFilename">Name of File to Download</param>
			/// <param name="sLocalFilename">Name to Save File as Locally</param>
			/// <param name="bResume">Resume on Failure</param>
			public void Download(string sRemoteFilename, string sLocalFilename, bool bResume)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SetBinaryMode(true);
					SelectedFileSize = this[sRemoteFilename].FileSize;
                    SelectedFileDate = this[sRemoteFilename].FileDate;
                    SelectedFileName = this[sRemoteFilename].FileName;
					TotalBytes = 0;
					PercentComplete = 0;

					#region Setup File 

					if (bResume && System.IO.File.Exists(sLocalFilename))
					{
						#region Setup File to Resume

						try
						{
							FTPPlumbing.file = new FileStream(sLocalFilename, FileMode.Open);
						}
						catch (Exception e)
						{
							FTPPlumbing.file = null;
							throw e;
						}

						FTPPlumbing.SendCommand("REST " + FTPPlumbing.file.Length);

						if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionPended)
						{
							throw new Exception(FTPPlumbing.ResponseString);
						}

						FTPPlumbing.file.Seek(FTPPlumbing.file.Length, SeekOrigin.Begin);
						TotalBytes = FTPPlumbing.file.Length;

						#endregion Setup File to Resume
					}
					else
					{
						#region Setup File for Initial Download

						try
						{
							FTPPlumbing.file = new FileStream(sLocalFilename, FileMode.Create);

						}
						catch (Exception e)
						{
							FTPPlumbing.file = null;
							throw e;
						}

						#endregion Setup File for Initial Download
					}

					#endregion Setup File

					#region Connect Socket

					FTPPlumbing.OpenDataSocket();
					FTPPlumbing.SendCommand("RETR " + sRemoteFilename);

					switch (FTPPlumbing.ResponseCode)
					{
						case FTPPlumbing.FTPResponseCode.DataConnectionAlreadyOpen: 
						case FTPPlumbing.FTPResponseCode.FileStatusOK:
                            break;

						default:
							FTPPlumbing.file.Close();
							FTPPlumbing.file = null;
							throw new Exception(FTPPlumbing.ResponseString);
					}

					FTPPlumbing.ConnectDataSocket();

					#endregion Connect Socket
				}
				else
				{
					throw new Exception("FTP Not Connected - Download Cannot Begin");
				}
			}
            
            public void Download(FTP.File File)
            {
                if (FTPPlumbing.IsConnected)
                {
                    FTPPlumbing.SetBinaryMode(true);
                    SelectedFileSize = this[File.FileName].FileSize;
                    SelectedFileDate = File.FileDate==DateTime.MinValue?this[File.FileName].FileDate:File.FileDate;
                    SelectedFileName = File.FileName;
                    String sLocalFilename = File.FileName;
                    Boolean bResume = false;

                    TotalBytes = 0;
                    PercentComplete = 0;

                    #region Setup File

                    if (bResume && System.IO.File.Exists(sLocalFilename))
                    {
                        #region Setup File to Resume

                        try
                        {
                            FTPPlumbing.file = new FileStream(sLocalFilename, FileMode.Open);
                        }
                        catch (Exception e)
                        {
                            FTPPlumbing.file = null;
                            throw e;
                        }

                        FTPPlumbing.SendCommand("REST " + FTPPlumbing.file.Length);

                        if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionPended)
                        {
                            throw new Exception(FTPPlumbing.ResponseString);
                        }

                        FTPPlumbing.file.Seek(FTPPlumbing.file.Length, SeekOrigin.Begin);
                        TotalBytes = FTPPlumbing.file.Length;

                        #endregion Setup File to Resume
                    }
                    else
                    {
                        #region Setup File for Initial Download

                        try
                        {
                            FTPPlumbing.file = new FileStream(sLocalFilename, FileMode.Create);

                        }
                        catch (Exception e)
                        {
                            FTPPlumbing.file = null;
                            throw e;
                        }

                        #endregion Setup File for Initial Download
                    }

                    #endregion Setup File

                    #region Connect Socket

                    FTPPlumbing.OpenDataSocket();
                    FTPPlumbing.SendCommand("RETR " + sLocalFilename);

                    switch (FTPPlumbing.ResponseCode)
                    {
                        case FTPPlumbing.FTPResponseCode.DataConnectionAlreadyOpen:
                        case FTPPlumbing.FTPResponseCode.FileStatusOK:
                            break;

                        default:
                            FTPPlumbing.file.Close();
                            FTPPlumbing.file = null;
                            throw new Exception(FTPPlumbing.ResponseString);
                    }

                    FTPPlumbing.ConnectDataSocket();

                    #endregion Connect Socket
                }
                else
                {
                    throw new Exception("FTP Not Connected - Download Cannot Begin");
                }
            }


			/// <summary>
			/// Delete a File on the Server
			/// </summary>
			/// <param name="sFilename">Name of File to Delete</param>
			public void RemoveFile(string sFilename)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SendCommand("DELE " + sFilename);

					if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionCompleted) // 250 = Requested file action okay, completed
					{
#if (FTP_DEBUG)
						Console.Write("\r" + responseStr);
#endif

						throw new Exception(FTPPlumbing.ResponseString);
					}
					else
					{
						RebuildFileList();
					}
				}
			}
			/// <summary>
			/// Rename a File on the Server
			/// </summary>
			/// <param name="sOldFilename">Current File Name to Rename</param>
			/// <param name="sNewFilename">New File Name</param>
			public void RenameFile(string sOldFilename, string sNewFilename)
			{
				if (FTPPlumbing.IsConnected)
				{
					FTPPlumbing.SendCommand("RNFR " + sOldFilename);

					if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionPended) // 350 = Requested file action pending further information
					{
#if (FTP_DEBUG)
						Console.Write("\r" + responseStr);
#endif

						throw new Exception(FTPPlumbing.ResponseString);
					}
					else
					{
						FTPPlumbing.SendCommand("RNTO " + sNewFilename);

						if (FTPPlumbing.ResponseCode != FTPPlumbing.FTPResponseCode.FileActionCompleted) // 250 = Requested file action okay, completed
						{
#if (FTP_DEBUG)
							Console.Write("\r" + responseStr);
#endif

							throw new Exception(FTPPlumbing.ResponseString);
						}
						else
						{
							RebuildFileList();
						}
					}
				}
			}
		}

		public class File
		{
			// JAC
			// File Objects in the Collection

			private string sFileName = "";
			private long lFileSize = 0;
			private DateTime dtFileDate=DateTime.MinValue;

			/// <summary>
			/// Name of File
			/// </summary>
			public string FileName
			{
				get { return sFileName; }
				set { sFileName = value; }
			}
			/// <summary>
			/// Size of File
			/// </summary>
			public long FileSize
			{
				get { return lFileSize; }
				set { lFileSize = value; }
			}
			/// <summary>
			/// Creation DateTime of File
			/// </summary>
			public DateTime FileDate
			{
				get { return dtFileDate; }
				set { dtFileDate = value; }
			}

			public File(string sFileName, long lFileSize, DateTime dtFileDate)
			{
				FileName = sFileName;
				FileSize = lFileSize;
				FileDate = dtFileDate;
			}
            public File(string sFileName, DateTime dtFileDate)
            {
                FileName = sFileName;
                FileSize = 0;
                FileDate = dtFileDate;
            }
            public File(string sFileName)
            {
                FileName = sFileName;
                FileSize = 0;
            }
		}
        
	}

}