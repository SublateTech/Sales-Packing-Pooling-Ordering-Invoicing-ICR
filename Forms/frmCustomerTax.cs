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
    public partial class frmCustomerTax: frmBase
    {
        Customer oCustomer;
        
        public frmCustomerTax()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            txtDateFrom.Value = null;
            txtDateTo.Value = null;
            DataTable table = new DataTable();
            table = Global.oMySql.GetDataTable("Select * from States", "States");

            ctrState.DataSource = table;
            ctrState.DisplayMember = "Name";
            ctrState.ValueMember = "StateID";
            ctrState.Text = "";
            
            
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            
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
                    String PrinterName = ""; // Global.OpenPrintDialog();
                   // if (PrinterName != "")
                    {
                        if (txtDateFrom.Value == null || txtDateTo.Value == null)
                            return;

                        if (!cbFood.Checked)
                            oCustomer.PrintCustomerTax(txtDateFrom.Value, txtDateTo.Value, PrinterName, ctrState.SelectedIndex == 0 ? "" : ctrState.SelectedValue.ToString());
                        else
                            oCustomer.PrintCustomerTaxFood(txtDateFrom.Value, txtDateTo.Value, PrinterName, ctrState.SelectedIndex == 0 ? "" : ctrState.SelectedValue.ToString());
                    }
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
            if (!this.IsGiftAvenue)
                if (txtDateFrom.Value == null || txtDateTo.Value == null)
                    return;

            String PrinterName = ""; // Global.OpenPrintDialog();
               // if (PrinterName != "")
                {
                    
                    //oCustomer.PrintCustomerTax(txtDateFrom.Value, txtDateTo.Value, PrinterName, ctrState.SelectedIndex == 0 ? "" : ctrState.SelectedValue.ToString().Trim());
                    if (!cbFood.Checked)
                        oCustomer.PrintCustomerTax(txtDateFrom.Value, txtDateTo.Value, PrinterName, ctrState.SelectedIndex == 0 ? "" : ctrState.SelectedValue.ToString());
                    else
                        oCustomer.PrintCustomerTaxFood(txtDateFrom.Value, txtDateTo.Value, PrinterName, ctrState.SelectedIndex == 0 ? "" : ctrState.SelectedValue.ToString());
                }
                this.Dispose();
        }

        
    }
}