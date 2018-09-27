using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Reports;

namespace Signature.Forms
{
    public partial class frmPurchaseStatement: frmBase
    {
        Purchase oPurchase;
        Vendor oVendor;

        public frmPurchaseStatement()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oPurchase = new Purchase(Global.GetParameter("CurrentCompany"));
            oVendor = new Vendor(Global.GetParameter("CurrentCompany"));
            
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtPurchaseID
            if (sender == txtPurchaseID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oPurchase.View())
                    {
                        
                        txtPurchaseID.Text = oPurchase.ID;
                        oPurchase.Find(txtPurchaseID.Text);
                        oVendor.Find(oPurchase.VendID);
                        txtName.Text = oVendor.Name;

                        AddItem();
                        txtPurchaseID.Clear();
                        txtPurchaseID.Focus();
                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtPurchaseID.Text.Trim().Length == 0)
                    {
                        txtName.Text = "";
                        return;
                        //txtCustomerID.Focus();
                    }

                    if (oPurchase.Find(txtPurchaseID.Text))
                    {
                        
                        txtPurchaseID.Text = oPurchase.ID;
                        oPurchase.Find(txtPurchaseID.Text);
                        oVendor.Find(oPurchase.VendID);
                        txtName.Text = oVendor.Name;
                        AddItem();
                        txtPurchaseID.Clear();
                        txtPurchaseID.Focus();
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
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btPrint_Click(object sender, EventArgs e)
        {

            if (lvCustomers.Items.Count > 0)
            {
                String PrinterName;
                if (lvCustomers.Items.Count > 1 )
                    PrinterName = Global.OpenPrintDialog();
                else
                    PrinterName = ".";

                if (PrinterName != "")
                {
                    foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvCustomers.Items)
                    {
                        
                        if (lvCustomers.Items.Count==1)
                        {   
                            oPurchase.Find(Item.Tag.ToString());

                             if (lvCustomers.Items.Count == 1)
                                   oPurchase.PrintStatement(PrinterName, PrinterDevice.Screen);
                             else
                                   oPurchase.PrintStatement(PrinterName, PrinterDevice.Printer);

                            
                        }
                            
                    }
                }
            }
            else
            {
                String PrinterName = Global.OpenPrintDialog();
                if (PrinterName != "")
                {

                    DataTable dt = Global.oMySql.GetDataTable(String.Format("Select CustomerID From Customer Where CompanyID='{0}'", Global.CurrrentCompany), "Customer");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (!oPurchase.Find(row["CustomerID"].ToString()))
                            MessageBox.Show("Please report this error...customer not found()");
                        else
                        {   
                                if (cbZero.Checked || oPurchase.GetTotal()- oPurchase.GetPayments() != 0)
                                    oPurchase.PrintStatement(PrinterName,PrinterDevice.Printer);
                            
                        }

                    }
                }
            }
            this.Dispose();
        }
        private void AddItem()
        {
            Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
            Item.Tag = oPurchase.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oPurchase.ID + "-" + oVendor.Name;

            lvCustomers.Items.Add(Item);
        }
        
    }
}