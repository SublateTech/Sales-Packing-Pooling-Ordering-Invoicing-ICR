using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Data;
using Signature;
using Signature.Classes;
using Signature.Data;



namespace Signature
{
    public class Program
    {

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
/*
            if (true) //Global.CurrentUser == "PACKER" || Global.CurrentUser == "ALVARO1" || Global.CurrentUser == "DISC" || Global.CurrentUser == "DATA"  || Global.CurrentUser != "ALVARO")
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                if (!frm.isAccepted)
                    return;
            }
  */     

            System.Windows.Forms.Application.Run(new Signature.frmScanning());
         }
        
     
    }
}