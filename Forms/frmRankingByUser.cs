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
    public partial class frmRankingByUser: frmBase
    {
        Customer oCustomer;

        public frmRankingByUser()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            
            
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
                    //oCustomer.PrintCustomerDate(txtDateFrom.Value,txtDateTo.Value,txtType.CheckedItem.DataValue.ToString());
                    /*
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        oCustomer.Orders.Print(txtType.CheckedItem.DataValue.ToString() == "Unprinted" ? false : true,txtPrinter.SelectedIndex);
                        this.Dispose();
                    }*/
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
            /*
            if (txtCustomerID.Text.Trim() != "" && oCustomer.ID != "")
            {
                oCustomer.Orders.Print(txtType.CheckedItem.DataValue.ToString() == "Unprinted" ? false : true,txtPrinter.SelectedIndex);
                this.Dispose();
            }
            */
            if (txtProcess.Text == "DataEntry")
                txtProcess.Text = "Enter";
            Company oCompany = new Company();
            oCompany.PrintUserRankingReport(txtProcess.Text, (DateTime)txtDateFrom.Value);
        }

        
    }
}