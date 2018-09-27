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
    public partial class frmCustomerInventory : frmBase

    {
        Invoice oInvoice;

        public frmCustomerInventory()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oInvoice = new Invoice(base.CompanyID);
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
                    if (oInvoice.View())
                    {
                        
                        txtCustomerID.Text = oInvoice.ID;
                        if (oInvoice.Find(txtCustomerID.Text))
                        {
                            txtName.Text = oInvoice.Name;
                            AddItem();
                            txtCustomerID.Clear();
                            txtCustomerID.Focus();
                            return;
                        }

                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        
                        txtCustomerID.Focus();
                    }

                    if (oInvoice.Find(txtCustomerID.Text))
                    {
                        
                        txtCustomerID.Text = oInvoice.ID;
                        txtName.Text = oInvoice.Name;
                        AddItem();
                        txtCustomerID.Clear();
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
                    btPrint_Click(null, null);
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion

        }

        private void AddItem()
        {
            Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
            Item.Tag = oInvoice.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oInvoice.ID+"-"+oInvoice.Name;

            lvCustomers.Items.Add(Item);
        }
        
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

                if (lvCustomers.Items.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvCustomers.Items)
                    {
                        oInvoice.PrintInventoryByDate("", Item.Tag.ToString(), txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString(), "", false);
                    }
                }else
                    oInvoice.PrintInventoryByDate("",txtCustomerID.Text, txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString(), "", false);

            this.Dispose();
        }
    }
}