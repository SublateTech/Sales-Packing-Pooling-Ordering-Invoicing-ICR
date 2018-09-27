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
    public partial class frmCustomerDate: frmBase
    {
        Customer oCustomer;
        Brochure oBrochure;

        public frmCustomerDate()
        {
            InitializeComponent();
            
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            oBrochure = new Brochure(base.CompanyID);
            txtDateFrom.Value = null;
            txtDateTo.Value = null;

            if (this.CompanyID.Substring(0, 2) == "GA")
            {
                txtType.Items.Add("All");

                txtType.Items[3].DisplayText = "Payment Due";
                txtType.Items[3].DataValue = "Pickup";
                txtType.Items[4].DisplayText = "Promo Ship";
                txtType.Items[4].DataValue = "Ship";
                txtType.Items[5].DisplayText = "Prod Ship";
                txtType.Items[5].DataValue = "Delivery";
                txtType.Items[6].DisplayText = "Prod Return";
                txtType.Items[6].DisplayText = "ParentPickUpDate";
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
                        oCustomer.Find(txtCustomerID.Text);
                        //txtName.Text = oCustomer.Name;
                        

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
                        //txtName.Text = oCustomer.Name;
                        

                    }
                    



                }

            }
            #endregion
            #region txtBrochureID
            if (sender == txtBrochureID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {
                        txtBrochureID.Text = oBrochure.ID;
                        ctrBrochureName.Text = oBrochure.Description;
                    }
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBrochureID.Text != "")
                    {
                        if (oBrochure.Find(txtBrochureID.Text))
                        {
                            txtBrochureID.Text = oBrochure.ID;
                            ctrBrochureName.Text = oBrochure.Description;
                        }
                        else
                            return;
                    }


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
                    oCustomer.PrintCustomerDate(txtDateFrom.Value,txtDateTo.Value,txtType.CheckedItem.DataValue.ToString(),cbLetterAprovalDone.Checked, cbNotChecked.Checked,cbCompleted.Checked,this.txtBrochureID.Text);
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

            if (txtByPage.Checked || txtCustomerID.Text.Trim() != "")
            {
                String PrinterName = Global.OpenPrintDialog();
                if (PrinterName != "")
                    oCustomer.PrintCustomerDateByPage(txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString(), PrinterName, cbLetterAprovalDone.Checked, cbNotChecked.Checked,cbCompleted.Checked);
            }
            else
                oCustomer.PrintCustomerDate(txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString(),cbLetterAprovalDone.Checked, cbNotChecked.Checked,cbCompleted.Checked,this.txtBrochureID.Text);
            this.Dispose();
        }

        
    }
}