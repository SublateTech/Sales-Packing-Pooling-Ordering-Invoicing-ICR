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
    public partial class frmCustomerSignedDate: frmBase
    {
        Customer oCustomer;
        Brochure oBrochure;
        Prize oPrize;
        
        public frmCustomerSignedDate()
        {
            InitializeComponent();
            
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            oBrochure = new Brochure(base.CompanyID);
            oPrize = new Prize(base.CompanyID);

            txtDateFrom.Value = null;
            txtDateTo.Value = null;

            
            
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            #region txtBrochureID
            if (sender == txtBrochureID)
            {

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {
                        txtBrochureID.Text = oBrochure.ID;
                        txtBrochureDescription.Text = oBrochure.Description;
                    }

                    if (txtBrochureID.Text == "")
                        return;

                    
                    return;

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID.Text.Trim().Length == 0)
                    {
                    
                        txtBrochureID.Focus();
                    }

                    if (oBrochure.Find(txtBrochureID.Text))
                    {

                        txtBrochureID.Text = oBrochure.ID;
                        txtBrochureDescription.Text = oBrochure.Description;
                    }
                    return;



                }

            }
            #endregion
            #region txtPrizeID
            if (sender == txtPrizeID)
            {

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


                if (e.KeyCode.ToString() == "F2")
                {
                    if (oPrize.View())
                    {
                        txtPrizeID.Text = oPrize.ID;
                        txtPrizeDescription.Text = oPrize.Description;
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtPrizeID.Text.Trim().Length == 0)
                    {
                      
                        txtPrizeID.Focus();
                    }

                    if (oPrize.Find(txtPrizeID.Text))
                    {
                        txtPrizeID.Text = oPrize.ID;
                        txtPrizeDescription.Text = oPrize.Description;

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
                    //oCustomer.PrintCustomerDate(txtDateFrom.Value,txtDateTo.Value,txtType.CheckedItem.DataValue.ToString(),cbLetterAprovalDone.Checked, cbNotChecked.Checked);
                    this.Dispose();
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            oCustomer.PrintCustomerSignedDate(txtDateFrom.Value, txtDateTo.Value, txtBrochureID.Text, txtPrizeID.Text);
            this.Dispose();
        }

        
    }
}