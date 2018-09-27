using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using Signature.Communications;
using Signature.Classes;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;


namespace Signature.AutoUpdate
{
    public class AutoUpdate
    {
        // Fields
        private  string m_ErrorMessage ;
        private  string m_RemotePath;
        private  string m_UpdateFileName;

        // Methods
        // static AutoUpdate();
        // private static string GetVersion(string Version);
        // public static bool UpdateFiles([Optional, DefaultParameterValue("")] string RemotePath);

        // Properties
        public string ErrorMessage { get { return m_ErrorMessage; } set { m_ErrorMessage = value; } }
        public  string RemotePath { get {return m_ErrorMessage;} set {m_RemotePath=value;} }
        public  string UpdateFileName { get{return m_UpdateFileName;} set{m_UpdateFileName=value;} }

        public AutoUpdate()
        {
            m_RemotePath = "";
            m_UpdateFileName = "SigData.txt";
            m_ErrorMessage = "There was a problem running the Auto Update.";
        }
        private  string GetVersion(string Version)
        {
            //string[] x = String.Split(Version, ".", -1, CompareMethod.Binary);
            //return string.Format("{0:00000}{1:00000}{2:00000}{3:00000}", new object[] { RuntimeHelpers.GetObjectValue(Conversion.Int(x[0])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[1])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[2])), RuntimeHelpers.GetObjectValue(Conversion.Int(x[3])) });
            return "";
        }
        /*
        public  bool UpdateFiles([Optional, DefaultParameterValue("")] string RemotePath)
        {
            
            if (RemotePath == "")
            {
                RemotePath = m_RemotePath;
            }
            else
            {
                m_RemotePath = RemotePath;
            }
            bool Ret = false;
            string AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            string ToDeleteExtension = ".ToDelete";
            string RemoteUri = RemotePath + AssemblyName + "/";
            WebClient MyWebClient = new  WebClient();
            try
            {
                for (string s = FileSystem.Dir(Application.StartupPath + @"\*" + ToDeleteExtension, FileAttribute.Normal); s != ""; s = FileSystem.Dir())
                {
                    try
                    {
                        File.Delete(Application.StartupPath + @"\" + s);
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception ex = exception1;
                        ProjectData.ClearProjectError();
                    }
                }
                string[] FileList = Strings.Split(Strings.Replace(MyWebClient.DownloadString(RemoteUri + UpdateFileName), "\n", "", 1, -1, CompareMethod.Binary), "\r", -1, CompareMethod.Binary);
                string Contents = "";
                foreach (string F in FileList)
                {
                    if (Strings.InStr(F, "'", CompareMethod.Binary) != 0)
                    {
                        F = Strings.Left(F, Strings.InStr(F, "'", CompareMethod.Binary) - 1);
                    }
                    if (F.Trim() != "")
                    {
                        if (Contents != "")
                        {
                            Contents = Contents + "\r";
                        }
                        Contents = Contents + F.Trim();
                    }
                }
                FileList = Strings.Split(Contents, "\r", -1, CompareMethod.Binary);
                string[] Info = Strings.Split(FileList[0], ";", -1, CompareMethod.Binary);
                if (((((Application.StartupPath.ToLower() + @"\" + Info[0].ToLower()) == Application.ExecutablePath.ToLower()) && (Operators.CompareString(GetVersion(Info[1]), GetVersion(Application.ProductVersion), false) > 0)) ? 1 : 0) == 0)
                {
                    return Ret;
                }
                foreach (string F in FileList)
                {
                    Info = Strings.Split(F, ";", -1, CompareMethod.Binary);
                    bool isToDelete = false;
                    bool isToUpgrade = false;
                    string TempFileName = Application.StartupPath + @"\" + Conversions.ToString(DateAndTime.Now.TimeOfDay.TotalMilliseconds);
                    string FileName = Application.StartupPath + @"\" + Info[0].Trim();
                    bool FileExists = File.Exists(FileName);
                    if (Info.Length == 1)
                    {
                        isToUpgrade = true;
                        isToDelete = FileExists;
                    }
                    else if (Info[1].Trim() == "delete")
                    {
                        isToDelete = FileExists;
                    }
                    else if (Info[1].Trim() == "?")
                    {
                        isToUpgrade = !FileExists;
                    }
                    else if (FileExists)
                    {
                        FileVersionInfo fv = FileVersionInfo.GetVersionInfo(FileName);
                        isToUpgrade = Operators.CompareString(GetVersion(Info[1].Trim()), GetVersion(Conversions.ToString(fv.FileMajorPart) + "." + Conversions.ToString(fv.FileMinorPart) + "." + Conversions.ToString(fv.FileBuildPart) + "." + Conversions.ToString(fv.FilePrivatePart)), false) > 0;
                        isToDelete = isToUpgrade;
                    }
                    else
                    {
                        isToUpgrade = true;
                    }
                    Debug.Print(TempFileName);
                    if (isToUpgrade)
                    {
                        MyWebClient.DownloadFile(RemoteUri + Info[0], TempFileName);
                    }
                    if (isToDelete)
                    {
                        File.Move(FileName, TempFileName + ToDeleteExtension);
                    }
                    if (isToUpgrade)
                    {
                        File.Move(TempFileName, FileName);
                    }
                }
                Process.Start(Application.ExecutablePath, Interaction.Command());
                Ret = true;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception ex = exception2;
                Ret = true;
                Interaction.MsgBox(m_ErrorMessage + "\r" + ex.Message + "\rAssembly: " + AssemblyName, MsgBoxStyle.Critical, Application.ProductName);
                ProjectData.ClearProjectError();
            }
            return Ret;
        }
        */
        public  void SendFile(String File)
        {
            frmProgress ofrm = new frmProgress();
            ofrm.Show();
            
            FTP.FTPPlumbing.Timeout = 50000;
            FTP.FTPPlumbing.PassiveMode = true;

            FTP oFTP = new FTP();
            oFTP.Connect("192.168.254.65", "alvaro", "michelle"); //mail.giftcoinc.com

            oFTP.ChangeDirectory(".");
            oFTP.Files.Upload("File");
            while (!oFTP.Files.UploadComplete)
            {
                //MessageBox.Show("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
                ofrm.txtBar.Value = oFTP.Files.PercentComplete;
                ofrm.Update();
            }
            //MessageBox.Show("Upload Complete: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
            ofrm.txtBar.Value = oFTP.Files.PercentComplete;
            ofrm.Update();


            oFTP.Disconnect();

            return;
        }
        public  static void GetFile(String File)
        {
            FTP.FTPPlumbing.Timeout = 50000;
            FTP.FTPPlumbing.PassiveMode = true;

            FTP oFTP = new FTP();
            oFTP.Connect("192.168.254.65", "alvaro", "michelle"); //mail.giftcoinc.com

            oFTP.ChangeDirectory(".");
            oFTP.Files.Download("File");
            while (!oFTP.Files.DownloadComplete)
            {
                MessageBox.Show("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
            }

            MessageBox.Show("Upload Complete: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());


            oFTP.Disconnect();

            return;
        }
    }
}
