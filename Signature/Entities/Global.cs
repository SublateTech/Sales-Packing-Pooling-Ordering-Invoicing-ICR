using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using Signature.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Media;
using System.Drawing.Printing;
using Infragistics.Shared;
using Infragistics.Win;
using System.ServiceProcess;
using Signature.Forms;
using System.ComponentModel;
using System.Diagnostics;


namespace Signature.Classes
{
    public static class Global
    {

        public static frmMain _frmMain = null;
        internal static NotifyIcon _NotifyIcon=null;
        
        
        private static String _CurrentUser;
        
        public static DateTime DNull = new DateTime(1900, 01, 01);

        public static MySQL oMySql = new MySQL();

        private static RegistryKey root;

        private static String _CompanyID;


        private static String _SectionID;

        private static Boolean IsRemoteConnection
        {
            get {
                return System.Windows.Forms.SystemInformation.TerminalServerSession;
                }
        }

        
        public static String CurrentUser
        {
            get { return _CurrentUser; }
            set {
                _CurrentUser = value;
                if (!InDesignMode())
                {
                    User oUser = new User();
                    oUser.UserID = value;
                    if (!oUser.ExistUser())
                    {
                     //   oUser.Insert();
                    }
                }
                }
        }

        public static bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        static Global()
        {
            CurrentUser = System.Environment.UserName.ToUpper();
          
        }

        public static void ShowNotifier(String Message, String Title, Int32 Timer, ToolTipIcon TipIcon)
        {
           // Signature.Forms.frmMain frm = Signature.Forms.frmMain.ActiveForm as Signature.Forms.frmMain;
            
            if (_frmMain != null)
            {
                if (Message.Trim() == "")
                    return;
                _frmMain.NotifyIcon.ShowBalloonTip(Timer, Title, Message, TipIcon);
                Application.DoEvents();
                return;
            }
            
            if (_NotifyIcon == null)
            {
                Application.EnableVisualStyles();
                
                _NotifyIcon = new NotifyIcon();
                _NotifyIcon.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Signature.Classes.Resources.logo.ico"));
                _NotifyIcon.Text = "Signature Fundraising Application";
                _NotifyIcon.Visible = true;
                _NotifyIcon.Click += new EventHandler(_NotifyIcon_Click);

            }
            if (_NotifyIcon != null)
            {
                _NotifyIcon.ShowBalloonTip(Timer, Title, Message, TipIcon);
            }
            Application.DoEvents();
            
        }

        static void _NotifyIcon_Click(object sender, EventArgs e)
        {
           // Application.Exit();
        }

        public static void ShowNotifier(String Message)
        {
            ShowNotifier(Message, "Signature App", 500,ToolTipIcon.Info);
        }

        public static void SetParameter(String sKey, String Value)
        {
            root = Registry.CurrentUser.CreateSubKey("Software\\Signature Fundraising");
            RegistryKey SKey = root.CreateSubKey("SigData");
            SKey.SetValue(sKey, Value);
        }

        public static String GetParameter(String sKey)
        {
            String StrKey;

            try
            {
                root = Registry.CurrentUser.CreateSubKey("Software\\Signature Fundraising");
                RegistryKey SKey = root.CreateSubKey("SigData");

                StrKey = SKey.GetValue(sKey, " ").ToString();
            }
            catch
            {
                StrKey = " ";
            }


            if (sKey == "CurrentCompany" && StrKey == " ")
            {
                return "F09";
            }
            
            if (sKey == "CurrentLine" && StrKey == " ")
            {
                return "1";
            }

            if (sKey == "CurrentSection" && StrKey == " ")
            {
                return "1";
            }
            return StrKey;
        }

        public static String ByteToString(byte[] byteBLOBData)
        {
            return System.Text.Encoding.UTF8.GetString(byteBLOBData);
        }

        public static Boolean HasAccess(String Module)
        {
            
            //MySQL oMySql = new MySQL();
            DataRow row = oMySql.GetDataRow(String.Format("Select * From UserRights Where UserID='{0}' And ModuleID='{1}'", Global.CurrentUser.ToUpper(), Module.ToUpper()),"tmp");
            if (row == null)
            {
                return false;
            }
            return true;
        }
        
        public static String UserType()
        {
            return System.Environment.UserName.ToUpper();
        }

        public static string OpenPrintDialog()
        {
            PrintDialog dlg = new PrintDialog();

            //dlg.Document = this;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.PrinterSettings.PrinterName;
            }
            return "";
        }

        public static void SetVolume(int Value)
        {
            // Calculate the volume that's being set
            int NewVolume = ((ushort.MaxValue / 10) * Value);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        public static void playSimpleSound()
        {
            playSimpleSound(4);
        }

        public static void playSimpleSound(int Index)
        {
            String Path = "G:\\Sounds\\";
            if (Global.IsRunningOnMono())
                Path = "Sounds/";

            SoundPlayer simpleSound;
            switch (Index)
            {
                case 0:
                    //SystemSounds.Hand.Play();        
                    simpleSound = new SoundPlayer(@Path +"meep1.wav"); 
                    
                    break;
                case 1:
                    //SystemSounds.Asterisk.Play();        
                    simpleSound = new SoundPlayer(@Path + "brkglass.wav"); 
                    break;
                case 2:
                    //SystemSounds.Beep.Play();        
                    simpleSound = new SoundPlayer(@Path + "meep.wav"); 
                    break;
                case 3:
                    //SystemSounds.Exclamation.Play();
                    simpleSound = new SoundPlayer(@Path + "ouch2.wav"); 
                    break;
                case 4:
                    SystemSounds.Hand.Play();
                    return;
                    
                case 5:
                    simpleSound = new SoundPlayer(@Path + "brkglss2.wav"); 
                    break;

                case 6:
                    simpleSound = new SoundPlayer(@Path + "digital_blip.wav"); 
                    break;

                case 7:
                    simpleSound = new SoundPlayer(@Path + "guitwail.wav");
                    break;

                default:
                    //SystemSounds.Question.Play();
                    simpleSound = new SoundPlayer(@Path + "brkglss2.wav"); //@"c:\Windows\Media\chimes.wav");
                    break;

            }


            try
            {
                simpleSound.Play();
            }
            catch(Exception e)
            {
                Global.ShowNotifier(e.Message);
            }
            
            //SoundPlayer simpleSound = new SoundPlayer(System.Environment.GetEnvironmentVariable("windir") + @"\Media\HeyHey.wav"); //@"c:\Windows\Media\chimes.wav");
            //SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath + @"\HeyHey.wav"); //@"c:\Windows\Media\chimes.wav");
            //simpleSound.Play();


            
            
        }
       
        public static Int32 FedexNationalNumber
        {
            get {
                DataRow row = oMySql.GetDataRow("Select FedexNationalNumber From Global LIMIT 1", "Global");
                if (row == null)
                    return 0;
                else
                {
                    return (Int32)row["FedexNationalNumber"];
                }

            }
            set {

                oMySql.exec_sql(String.Format("Update Global Set FedexNationalNumber='{0}'",value));
                
            }
        
        }

        public static String Database
        {
            get
            {
                DataRow row = oMySql.GetDataRow("Select Database From Global LIMIT 1", "Global");
                if (row == null)
                    return "";
                else
                {
                    return row["Database"].ToString();
                }

            }
            set
            {

                oMySql.exec_sql(String.Format("Update Global Set Database='{0}'", value));

            }

        }

        public static String Company
        {
            get
            {
                DataRow row = oMySql.GetDataRow("Select CompanyID From Global LIMIT 1", "Global");
                if (row == null)
                    return "";
                else
                {
                    return row["CompanyID"].ToString();
                }

            }
            set
            {

                oMySql.exec_sql(String.Format("Update Global Set CompanyID='{0}'", value));

            }

        }

        public static String ICustomer
        {
            get
            {
                DataRow row = oMySql.GetDataRow("Select ICustomerID From Global LIMIT 1", "Global");
                if (row == null)
                    return "";
                else
                {
                    return row["ICustomerID"].ToString();
                }

            }
            set
            {

                oMySql.exec_sql(String.Format("Update Global Set ICustomerID='{0}'", value));

            }

        }

        public static String ImageDirectory
        {
            get
            {
                DataRow row = oMySql.GetDataRow("Select ImageDirectory From Global LIMIT 1", "Global");
                if (row == null)
                    return "";
                else
                {
                    return row["ImageDirectory"].ToString();
                }

            }
            set
            {

                oMySql.exec_sql(String.Format("Update Global Set ImageDirectory=´'{0}'", value));

            }

        }

        public static Int32 FedexFreightNumber
        {
            get
            {
                DataRow row = oMySql.GetDataRow("Select FedexFreightNumber From Global LIMIT 1", "Global");
                if (row == null)
                    return 0;
                else
                    return (Int32)row["FedexFreightNumber"];

            }
            set
            {

                oMySql.exec_sql(String.Format("Update Global Set FedexFreightNumber='{0}'", value));

            }

        }
        public static String Message
        {
            set
            {
           //     Signature.Forms.frmMain frm = Signature.Forms.frmMain.ActiveForm as Signature.Forms.frmMain;
                if (_frmMain != null)
                {
                    _frmMain.Status.Panels["Message"].Text = value;
                    _frmMain.Status.Invalidate();
                    _frmMain.Status.Update();
                }
            }
        }
        public static void SetProgressBar(Int32 Maximun, Int32 Value)
        {
            if (_frmMain != null)
            {
                    if (Maximun == 0)
                        _frmMain.Status.Panels["ProgressBar"].Visible = false;
                    else
                        _frmMain.Status.Panels["ProgressBar"].Visible = true;

                    if (Value <= Maximun)
                    {
                        _frmMain.Status.Panels["ProgressBar"].ProgressBarInfo.Maximum = Maximun;
                        _frmMain.Status.Panels["ProgressBar"].ProgressBarInfo.Value = Value;
                    }
                    else
                        Message = "Please check number in progress bar...";

                    _frmMain.Status.Update();
                    Application.DoEvents();
            }
            
         }

        
        public static Form GetActiveForm(String Name)
        {
            Signature.Forms.frmMain frm = Signature.Forms.frmMain.ActiveForm as Signature.Forms.frmMain;
            if (frm != null)
            {
                foreach (Form Cfrm in frm.MdiChildren)
                    if (Cfrm.Name == Name)
                    {
                        return Cfrm;
                    }
            }
            return null;
        }

        public static void IsPrinter(String PrinterName)
        {

            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                MessageBox.Show(printer.ToString());
                
            }

        }

        public static void RestartService()
        {

            ServiceController controller = new ServiceController();
            controller.MachineName = "."; 
            controller.ServiceName = "SLsvc";
            controller.Stop();
            string status = controller.Status.ToString(); 
            MessageBox.Show(status);
            controller.Start();
            status = controller.Status.ToString(); 
            MessageBox.Show(status);

        }
      
        public static bool IsGPI
        {
            get { return CurrrentCompany.Length < 3 ? false : (CurrrentCompany.Substring(0, 3) == "GPI") ? true : false; }
        }
        
        public static String CurrrentCompany
        {
            get {
                _CompanyID = GetParameter("CurrentCompany");
                return _CompanyID;
                }
                set
                {
                    _CompanyID = value;
                }
        }
        public static String CurrrentLine
        {
            get
            {
                _CompanyID = GetParameter("CurrentLine");
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }

        public static String CurrrentSection
        {
            get
            {
                _SectionID = GetParameter("CurrentSection");
                return _SectionID;
            }
            set
            {
                _SectionID = value;
            }
        }

        public static String FormatPhone(String Phone)
        {
            if (Phone == String.Empty)
                return "";
            else if (Phone.Length == 10)
                return "(" + Phone.Substring(0, 3) + ") " + Phone.Substring(3, 3) + "-" + Phone.Substring(6, 4);
            else if (Phone.Length == 7)
                return Phone.Substring(0, 3) + "-" + Phone.Substring(3, 3);
            else
                return Phone;
        }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        /// <summary>
        /// Library function useful when loading enum-typed properties from database.
        /// </summary>
        /// <param name="typeValue">The type value.</param>
        /// <returns>Enum</returns>
        public static T ToEnum<T>(int typeValue)
        {
            return (T)Enum.ToObject(typeof(T), typeValue);
        }

        public static String getState(String sState)
        {
            sState = sState.Replace(".", "").Trim().ToUpper();
            if (sState.Length == 2)
                return sState;

            DataRow row = oMySql.GetDataRow(String.Format("Select StateID FROM States Where Name='{0}' And Country='US'", sState), "tmp");
            if (row == null)
            {
                return sState;
            }
            else
            {
                return row["StateID"] == DBNull.Value ? sState : row["StateID"].ToString();
            }

        }

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><typeparam name="T"></typeparam></returns>
        public static T ParseEnum<T>(string value) where T : struct
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static void ClosePhotoGallery(String Program)
        {
            Process[] pArry = Process.GetProcesses();
            foreach (Process p in pArry)
            {
              //  MessageBox.Show(p.MainWindowTitle.Contains("Photo Gallery").ToString() + " -- " + p.MainWindowTitle.Contains(Program).ToString());
                if (p.MainWindowTitle.Contains("Photo Gallery")) // && p.MainWindowTitle.Contains(Program))
                    p.CloseMainWindow(); //.Kill();
            }

        }
        public static int GetProcessID(String Program)
        {
            Process[] pArry = Process.GetProcesses();

            foreach (Process p in pArry)
            {
                //if(p.ProcessName != "")
                //    MessageBox.Show(p.ProcessName);
                string s = p.ProcessName.Trim();
                
                s = s.ToLower();
                if (s.ToUpper() == Program.ToUpper())
                {
                    return p.Id;
                }
            }
            return 0;
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static Boolean IsVista
        {
            get { return Environment.OSVersion.Version.Major >= 6 ? true : false; }
        }

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

    }
}

