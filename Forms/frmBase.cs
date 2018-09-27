using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Data;
using Signature.Vista;
using Signature.Windows.Forms;


namespace Signature.Forms
{
    public partial class frmBase : GradientForm
    {
        public String CompanyID;
        private Company oCompany = new Company();
        public MySQL oMySql = Global.oMySql;
        

        public frmBase()
        {
            
            InitializeComponent();
            this.CompanyID = oCompany.ID;
            this.Text = this.CompanyID + " - ";


        }
        public frmBase(String CompanyID)
        {
            InitializeComponent();
            this.CompanyID = CompanyID;
            this.Text = this.CompanyID + " - ";
            oCompany.Find(CompanyID);
        }
        private void frmBase_Shown(object sender, EventArgs e)
        {

            //this.Height += txtStatus.Height;
            //this.panel1.SendToBack();
            this.txtStatus.Panels[0].Text = "Company [" + this.CompanyID+"]";
            if (!Global.InDesignMode())
            {
                this.txtStatus.Panels[3].Text = "User [" + Global.CurrentUser + "]";
                this.txtStatus.Panels[4].Text = "Database [" + MySQL.Database + "]";
            }
            this.Update();
            
        }
        public void SetStatus(String Message)
        {
            txtStatus.Text = Message;
        }

        public Boolean IsGiftAvenue
        {
            get
            {
                if (this.CompanyID.Substring(0, 2) == "GA")
                    return true;
                else
                    return false;
            }
        }
        public Boolean IsWebCustomer
        {
            get
            {
                if (Global.CurrrentCompany.Substring(0, 2) == "__")
                    return true;
                else
                    return false;
            }
        }
    }
    

}