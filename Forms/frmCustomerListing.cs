using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;

namespace Signature.Forms
{
    public partial class frmCustomerListing : frmBase
    {
        Customer oCustomer;
        Rep oRep;
        public frmCustomerListing()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            oRep = new Rep(base.CompanyID);
            if (!oCustomer.IsGiftAvenue)
            {
                bRegisters.Visible = false;
            }
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtCustomerID
            if (sender == txtCustomerID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {
                        
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        

                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        
                        txtCustomerID.Focus();
                    }

                    if (oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        

                    }
                    



                }

            }
            #endregion
            #region txtCustomerID_2
            if (sender == txtCustomerID_2)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {

                        txtCustomerID_2.Text = oCustomer.ID;
                        txtName_2.Text = oCustomer.Name;


                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID_2.Text.Trim().Length == 0)
                    {

                        txtCustomerID_2.Focus();
                    }

                    if (oCustomer.Find(txtCustomerID_2.Text))
                    {

                        txtCustomerID_2.Text = oCustomer.ID;
                        txtName_2.Text = oCustomer.Name;
                    }
                }

            }
            #endregion
            #region txtRepID
            if (sender == txtRepID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oRep.View())
                    {
                        txtRepID.Text = oRep.ID.ToString();
                        txtRepName.Text = oRep.Name;
                    }

                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (oRep.Find(txtRepID.Text))
                    {
                        txtRepID.Text = oRep.ID.ToString();
                        txtRepName.Text = oRep.Name;
                    }

                    return;
                }

            }
            #endregion
            

            #region Default Option
            //Default option
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (!e.Shift)
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    oCustomer.PrintCustomerListing(txtCustomerID.Text, txtCustomerID_2.Text, txtRepID.Text, txtZero.Checked,bRegisters.Checked);
                    this.Dispose();
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion

        }

        
    }
}