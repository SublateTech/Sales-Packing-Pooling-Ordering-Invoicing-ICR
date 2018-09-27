using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using System.Net;


namespace Signature.Forms
{
    public partial class frmDevice : frmBase
    {

        public String eMail = "";
        public String File = "";
        public PrinterDevice PrintDevice;

        
        public frmDevice()
        {
            InitializeComponent();
            l_eMail.Visible = false;
            txteMail.Visible = false;

        }


        private void txtType_ValueChanged(object sender, EventArgs e)
        {
            switch (txtDevice.Items[txtDevice.CheckedIndex].DataValue.ToString())
            {
                case "Printer":
                    break;
                case "eMail":
                    l_eMail.Visible = true;
                    txteMail.Visible = true;
                    break;
                case "PDF":
                    break;
                case "Preview":
                    break;
                default:
                    l_eMail.Visible = false;
                    txteMail.Visible = false;
                    break;
            
            }
        }

        private void txtSave_Click(object sender, EventArgs e)
        {
            switch (txtDevice.Items[txtDevice.CheckedIndex].DataValue.ToString())
            {
                case "Printer":
                    this.PrintDevice = PrinterDevice.Printer;
                    break;
                case "eMail":
                    this.eMail = txteMail.Text;
                    this.PrintDevice = PrinterDevice.eMail;
                    break;
                case "PDF":
                    this.PrintDevice = PrinterDevice.File;
                    break;
                case "Preview":
                    this.PrintDevice = PrinterDevice.Screen;
                    break;
            }
            this.Close();
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.PrintDevice = PrinterDevice.None;
            Close();
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            txteMail.Text = this.eMail;
        }

        
    }
}