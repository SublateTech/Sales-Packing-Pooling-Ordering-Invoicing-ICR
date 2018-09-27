using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Data;

namespace Signature
{
    public partial class frmBase : Form
    {
        public String CompanyID;
        private Company oCompany = new Company();
        public MySQL oMySql = Global.oMySql;

        public frmBase()
        {
            InitializeComponent();
            this.CompanyID = oCompany.ID;
            //this.Text = this.CompanyID + " - ";
        }

        private void frmBase_Shown(object sender, EventArgs e)
        {
            this.panel1.SendToBack();
            this.txtStatus.Items[0].Text = "Company [" + this.CompanyID+"]";
            this.txtStatus.Items[1].Text = "User [" + Global.CurrentUser+"]";
            this.Update();
        }

        public void SetStatus(String Message)
        {
            //txtStatus.Text = Message;
        }

    }
    

}