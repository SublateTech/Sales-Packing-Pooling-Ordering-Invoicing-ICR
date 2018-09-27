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
    public partial class frmCustomerBillOfLading : frmBase
    {
        Customer oCustomer;

        public frmCustomerBillOfLading()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(Global.GetParameter("CurrentCompany"));
            txtDateFrom.Value = null;
            txtDateTo.Value = null;
            
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
                    btPrint_Click(null, null);
                    
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

            String PrinterName = Global.OpenPrintDialog();
            if (PrinterName != "")
                oCustomer.PrintCustomerBillOfLading(PrinterName, txtCustomerID.Text,txtDateFrom.Value, txtDateTo.Value,txtType.CheckedItem.DataValue.ToString());
            
            this.Dispose();
        }
    }
}