using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Starter
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
            if (IsLoad())
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
            
            String Contents = ReadConfigFile().Replace("\x0A", "");
            String[] FileList  = Contents.Split('\x0D');

            foreach (String FileName in FileList)
            {
                if (FileName.Trim().Length > 0)
                {
                    String[] Info = FileName.Split(';');
                    ofrm.txtMessage.Text = "Processing " + Info[0] + " ...";
                    ofrm.Update();
                    if (Params.Length == 1 && Params[0] == "Update")
                    {
                        CopyFile(Info[0]);
                        //MessageBox.Show(Info[0]);
                    }
                    else
                        UpdateFile(Info[0]);
                }
            }

            /*
            System.Diagnostics.Process.Start(Application.StartupPath+"\\SigData.exe", "");
            do
            {
                ofrm.txtMessage.Text = "Loading Main Module  ...";
                ofrm.Update();
            } while (!IsThere());
            */



            String Program;

            if (Params.Length > 0 && Params[0] == "Packing")
                Program = "Packing.exe";
            else if (Params.Length > 0 && Params[0] == "Scanning")
                Program = "Scanning.exe";
            else if (Params.Length > 0 && Params[0] == "Server")
                Program = "Signature.Server.exe";
            else
                Program = "SigData.exe";

            
                System.Diagnostics.Process.Start(((Type.GetType("Mono.Runtime") != null) ? "mono " : "") + Application.StartupPath + "/" + Program, "");
                do
                {
                } while (!IsThere((Type.GetType("Mono.Runtime") != null) ? "mono" : Program));
            
            Application.Exit();

        }
        private static void CopyFile(String File)
        {
            String DevPath = "D:\\Signature.com\\SigData\\";
            try
            {
                System.IO.File.Copy(DevPath + File, SourcePath + File, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message:" + ex.Message, "File.Move");
            }
        }
        private static Boolean UpdateFile(String File)
        {
            
            if (CompareFile(File))
            {
                try
                {
                    System.IO.File.Copy(SourcePath + File, Application.StartupPath + "\\" + File,true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Message:" + ex.Message, "File.Move");
                }
                return true;
            }
            return false;
        }
        private static Boolean CompareFile(String FileName)
        {
            
            if (File.GetLastWriteTime(Application.StartupPath + "\\" + FileName).Ticks < File.GetLastWriteTime(SourcePath + FileName).Ticks)
            {
                //if (GetFileVersion(Application.StartupPath + "\\" + FileName) < GetFileVersion(SourcePath + "\\" + FileName))
                
                return true;
            }
            else
                return false;
        }
        private static String GetVersion(String Version)
        {
            String[] x = Version.Split(new Char[] { '.' });
            return String.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), Convert.ToInt32(x[2]), Convert.ToInt32(x[3]));
        }
        private static Int32 GetFileVersion(String FileName)
        {
            FileVersionInfo fv = FileVersionInfo.GetVersionInfo(FileName);
            String Version = fv.FileMajorPart + "." + fv.FileMinorPart + "." + fv.FileBuildPart + "." + fv.FilePrivatePart;
            String[] x = Version.Split(new Char[] { '.' });
            return Convert.ToInt32(x[0])*1000 + Convert.ToInt32(x[1])*100 + Convert.ToInt32(x[2])*10 + Convert.ToInt32(x[3])*1;
        }
        private static String ReadConfigFile()
        {
            return File.ReadAllText(SourcePath + "SigData.txt");
        }
        private static Boolean IsLoad()
        {
            Process[] Processes = System.Diagnostics.Process.GetProcesses();
            foreach (Process _Process in Processes)
            {
                try
                {
                    //MessageBox.Show(_Process.MainModule.ModuleName);
                    if (_Process.MainModule.ModuleName.ToUpper() == "SIGDATA.EXE")
                        return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("SigData.exe was not loaded..."+ex.Message);
                    return false; ;
                    
                }
            }
            return false;
        }
        private static Boolean IsThere(String Program)
        {
            Process[] Processes = System.Diagnostics.Process.GetProcesses();
            foreach (Process _Process in Processes)
            {
                try
                {

                    if (_Process.MainModule.ModuleName.ToUpper() == Program.ToUpper())
                    {
                        //MessageBox.Show(_Process.MainModule.ModuleName);
                        return true;
                    }
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
}