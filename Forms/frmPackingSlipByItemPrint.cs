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
    public partial class frmPackingSlipByItemPrint: frmBase
    {
        Product oProduct;
        Customer oInvoice;

        public frmPackingSlipByItemPrint()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oProduct = new Product(base.CompanyID);
            oInvoice = new Customer(base.CompanyID);
            txtCustomerID.Focus();
            
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtProductID
            if (sender == txtProductID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {
                        
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;

                        AddItem();
                        txtProductID.Clear();
                        txtProductID.Focus();
                    
                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        
                        txtProductID.Focus();
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {
                        
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        AddItem();
                        txtProductID.Clear();
                        txtProductID.Focus();
                        return;
                    
                    }
                    



                }

            }
            #endregion
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
                            AddCustomer();
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
                        AddCustomer();
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

        private void btPrint_Click(object sender, EventArgs e)
        {
            //if (txtProductID.Text.Trim() != "")
            {
                Company oCompany = new Company();
                
                

                if (lvCustomers.Items.Count > 0 && lvItems.Items.Count > 0)
                {
                    List<String> Items = new List<string>();
                    foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvItems.Items)
                    {
                        Items.Add(Item.Tag.ToString());
                    }

                    
                    foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvCustomers.Items)
                    {
                        oCompany.PrintAllOrdersByItem(Items,Item.Tag.ToString());
                        //MessageBox.Show(Item.Tag.ToString());
                    }
                }

            }
            this.Dispose();
        }

        private void AddCustomer()
        {
            Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
            Item.Tag = oInvoice.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oInvoice.ID + "-" + oInvoice.Name;

            lvCustomers.Items.Add(Item);
        }
        private void AddItem()
        {
            Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
            Item.Tag = oProduct.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oProduct.ID + "-" + oProduct.Description;

            lvItems.Items.Add(Item);
        }
        
    }
}