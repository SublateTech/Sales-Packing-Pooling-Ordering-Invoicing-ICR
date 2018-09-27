using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Signature;
using Signature.Forms;
using Signature.Classes;



namespace Signature
{
    public class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
             
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            
            //oMain = new frmMain();

            if (Global.CurrentUser == "SPACKER" || Global.CurrentUser == "PACKER" || Global.CurrentUser == "SCANNER" || Global.CurrentUser == "DISC" || Global.CurrentUser == "DATA") //  || Global.CurrentUser == "ALVARO")
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                if (!frm.isAccepted)
                    return;
            }
            if (Global.CurrentUser == "FRANCISCO" || Global.CurrentUser == "ALVARO" || Global.CurrentUser == "SCOTT" || Global.CurrentUser == "MIKE" || Global.CurrentUser == "RUSS" || Global.CurrentUser == "SANDRA")
                Application.Run(new frmMain());
            else if (Global.UserType() == "IMPRINTER") // || Global.CurrentUser == "ALVARO")
                Application.Run(new frmImprinting());
            else if (Global.UserType() == "PACKER")
                Application.Run(new frmPacking());
            else if (Global.UserType() == "SPACKER")
                Application.Run(new frmPackingSections_Old());
            else if (Global.UserType() == "SCANNER")
                Application.Run(new frmScanning());
            else if (Global.UserType() == "CASH")
                Application.Run(new frmCashRegister());
            else
                Application.Run(new frmMain());
            
        }
     
    }
}