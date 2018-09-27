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
    public partial class frmCustomerInvoiceConvert : frmBase

    {
        Invoice oInvoice;
        Company oCompany;
        Customer oCustomer;
        Order    oOrder;

        public frmCustomerInvoiceConvert()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oInvoice = new Invoice(base.CompanyID);
            oCompany = new Company(this.CompanyID);
            groupBox1.Focus();
            txtCustomerID.Focus();
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
                        txtName.Text = oInvoice.Name;
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        
                        txtCustomerID.Focus();
                    }

                    if (oInvoice.Find(txtCustomerID.Text))
                    {
                        txtName.Text = oInvoice.Name;
                    }
                }

            }
            #endregion
            #region txtCustomerID_to
            if (sender == txtCustomerID_to)
            {
                if (txtCompanyID.Text.Trim() == "")
                    return;
                
                oCustomer = new Customer(txtCompanyID.Text);
                
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {
                        txtCustomerID_to.Text = oCustomer.ID;
                        txtName_to.Text = oCustomer.Name;
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID_to.Text.Trim().Length == 0)
                    {
                        txtCustomerID_to.Focus();
                    }

                    if (oCustomer.Find(txtCustomerID_to.Text))
                    {
                        txtName_to.Text = oCustomer.Name;
                    }
                }
            }
            #endregion
            #region txtCompanyID
            if (sender == txtCompanyID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCompany.ViewAll())
                    {
                        txtCompanyID.Text = oCompany.ID;
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCompanyID.Text.Trim().Length == 0)
                    {

                        txtCompanyID.Focus();
                    }

                    if (oCompany.Find(txtCompanyID.Text))
                    {
                        
                    }
                   



                }

            }
            #endregion
            #region txtName_to
            if (sender == txtName_to)
            {
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtName_to.Text.Trim().Length == 0)
                    {
                        txtName_to.Focus();
                    }
                    bAdd.Focus();
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
            

            lvCustomers.Items[lvCustomers.Items.Count-1].SubItems[0].Value = txtCompanyID.Text;
            lvCustomers.Items[lvCustomers.Items.Count - 1].SubItems[1].Value = txtStudent.Text;
            lvCustomers.Items[lvCustomers.Items.Count - 1].SubItems[2].Value = txtName_to.Text;
            lvCustomers.Items[lvCustomers.Items.Count - 1].SubItems[2].Tag = txtCustomerID_to.Text;
            
            
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
                        if (oInvoice.Find(Item.Tag.ToString())) // Set the source CustomerID
                            oInvoice.ConvertInvoiceToOrder(Item.SubItems[0].Text, Item.SubItems[2].Tag.ToString(), Item.SubItems[1].Text);
                    }
                }

            this.Dispose();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }
    }
}