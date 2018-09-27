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
    public partial class frmCookieDoughLabels 
    {
        Customer oCustomer = new Customer();
        public Boolean isAccepted;
        
        public frmCookieDoughLabels()
        {
            InitializeComponent();
            isAccepted = false;
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender == txtCustomerID)
            {
                
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {

                        txtCustomerID.Text = oCustomer.ID;
                        oCustomer.Find(txtCustomerID.Text);
                        oCustomer.PrintCustomerCheckIn("");
                        oCustomer.oCustomerExtra.isReceivedOrders = true;
                        oCustomer.oCustomerExtra.Save();
                        // Close();
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                    }

                }
                if (e.KeyCode == Keys.Return)
                {

                    if (oCustomer.Find(txtCustomerID.Text.ToUpper()))
                    {
                        oCustomer.PrintCustomerCheckIn("");
                        oCustomer.oCustomerExtra.isReceivedOrders = true;
                        oCustomer.oCustomerExtra.Save();
                        // Close();
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                    }

                }
            }
            if (e.KeyCode == Keys.Cancel)
                this.Close();
        }

        private void bCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.Activate();
            
            this.txtCustomerID.Focus();
        }
    }
}