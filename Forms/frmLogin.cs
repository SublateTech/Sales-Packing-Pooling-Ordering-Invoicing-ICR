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
    public partial class frmLogin : Form
    {
        User oUser = new User();
        public Boolean isAccepted;
        
        public frmLogin()
        {
            InitializeComponent();
            isAccepted = false;
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                if (sender == txtPassword)
                {
                    if (oUser.Find(txtUserID.Text.ToUpper(), txtPassword.Text))
                    {
                        Global.CurrentUser = txtUserID.Text.ToUpper();
                        Global.oMySql.exec_sql("Update user Set ComputerName='" + Dns.GetHostName() + "',DateTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' Where User='" + Global.CurrentUser + "'");
                        isAccepted = true;
                        Close();
                    }
                }
                if (sender == txtUserID)
                    txtPassword.Focus();


            }
        }

        
        private void bLogin_Click_1(object sender, EventArgs e)
        {
            if (oUser.Find(txtUserID.Text.ToUpper(), txtPassword.Text))
            {
                Global.CurrentUser = txtUserID.Text.ToUpper();
                isAccepted = true;
                Close();
            }
        }

        private void bCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}