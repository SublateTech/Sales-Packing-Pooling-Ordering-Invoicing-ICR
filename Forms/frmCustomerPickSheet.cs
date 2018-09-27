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
    public partial class frmCustomerPickSheet: frmBase
    {
        Customer oCustomer;

        public frmCustomerPickSheet()
        {
            InitializeComponent();
        }

        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Customer(base.CompanyID);
            
            
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
                        this.AddItem();
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
                        this.AddItem();
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("This School doesn't exit, try again");
                        txtCustomerID.Focus();
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
                    //oCustomer.PrintCustomerDate(txtDateFrom.Value,txtDateTo.Value,txtType.CheckedItem.DataValue.ToString());
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        oCustomer.Orders.Print(txtType.CheckedItem.DataValue.ToString() == "Unprinted" ? false : true,txtPrinter.SelectedIndex, txtReAssign.Checked);
                        this.Dispose();
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

            //if (txtCustomerID.Text.Trim() != "" && oCustomer.ID != "")
            {
                if (lvCustomers.Items.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvCustomers.Items)
                    {
                        if (oCustomer.Find(Item.Tag.ToString()))
                        {
                            oCustomer.Orders.Print(txtType.CheckedItem.DataValue.ToString() == "Unprinted" ? false : true, txtPrinter.SelectedIndex, txtReAssign.Checked);
                            oCustomer.Printed = true;
                        }
                    }
                }
                
                this.Dispose();
            }
            
        }

        private void AddItem()
        {
            Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
            Item.Tag = oCustomer.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oCustomer.ID + "-" + oCustomer.Name;

            lvCustomers.Items.Add(Item);
        }
 

    }
}