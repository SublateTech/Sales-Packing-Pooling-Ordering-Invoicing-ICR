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
    public partial class frmCustomerStatement: frmBase
    {
        Invoice oCustomer;

        public frmCustomerStatement()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oCustomer = new Invoice(Global.GetParameter("CurrentCompany"));
            
            
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

                        AddItem();
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        txtName.Text = "";
                        return;
                        //txtCustomerID.Focus();
                    }

                    if (oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
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
                        if (oCustomer.Find(Item.Tag.ToString()))
                        {
                            if (oCustomer.Retail > 0 || lvCustomers.Items.Count == 1)
                            {
                                if (oCustomer.Retail == 0)
                                    Global.ShowNotifier("This School : " + oCustomer.Name + "\r\n" +
                                                    "has no Retail Amount");



                                if (cbFinance.Checked)
                                {
                                    if (oCustomer.GenerateFinanceCharges((Double)txtPercent.Number))
                                        oCustomer.HasChanged = true;
                                }
                                if (cbNegative.Checked)
                                {
                                    if (oCustomer.StatementAmountDue < 0)
                                    {
                                        if (lvCustomers.Items.Count == 1)
                                            oCustomer.PrintStatement(PrinterName, PrinterDevice.Screen);
                                        else
                                            oCustomer.PrintStatement(PrinterName, PrinterDevice.Printer);
                                    }
                                }
                                else if (cbZero.Checked || oCustomer.StatementAmountDue != 0)
                                {
                                    if (lvCustomers.Items.Count == 1)
                                        oCustomer.PrintStatement(PrinterName, PrinterDevice.Screen);
                                    else
                                        oCustomer.PrintStatement(PrinterName, PrinterDevice.Printer);
                                }
                            }
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
                        if (!oCustomer.Find(row["CustomerID"].ToString()))
                            MessageBox.Show("Please report this error...customer not found()");
                        else
                        {
                            if (oCustomer.Retail > 0)
                            {
                                if (oCustomer.HasChanged)
                                    oCustomer.GetCurrentTotalsByBrochure();

                                if (cbFinance.Checked)
                                    if (oCustomer.GenerateFinanceCharges((Double)txtPercent.Number))
                                        oCustomer.HasChanged = true;
                                if (cbNegative.Checked)
                                {
                                    if (oCustomer.StatementAmountDue < 0)
                                    {
                                        
                                            oCustomer.PrintStatement(PrinterName, PrinterDevice.Printer);
                                    }
                                }
                                else if (cbZero.Checked || oCustomer.StatementAmountDue != 0)
                                    oCustomer.PrintStatement(PrinterName,PrinterDevice.Printer);
                                
                            }
                        }

                    }
                }
            }

            //if (txtByPage.Checked || txtCustomerID.Text.Trim() != "")
           // {
            //    String PrinterName = Global.OpenPrintDialog();
                //if (PrinterName != "") 
                    //oCustomer.PrintCustomerDateByPage(txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString(),PrinterName);
           // }
          //  else ;
                //oCustomer.PrintCustomerDate(txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString());
            this.Dispose();
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