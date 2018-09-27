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
    public partial class frmCustomerUPSLabels : frmBase
    {
        UPSLabel oUPS;
        FedexLabel oFedex;

        public frmCustomerUPSLabels()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oUPS = new UPSLabel(base.CompanyID);
            oFedex = new FedexLabel(base.CompanyID);
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
                    if (oUPS.View())
                    {
                        
                        txtCustomerID.Text = oUPS.ID;
                        if (oUPS.Find(txtCustomerID.Text))
                        {
                            txtName.Text = oUPS.Name;
                            AddItem();
                            txtCustomerID.Clear();
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

                    if (oUPS.Find(txtCustomerID.Text))
                    {
                        
                        txtCustomerID.Text = oUPS.ID;
                        txtName.Text = oUPS.Name;
                        AddItem();
                        txtCustomerID.Clear();
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
            Item.Tag = oUPS.ID;
            Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

            Item.Value = oUPS.ID+"-"+oUPS.Name;

            lvCustomers.Items.Add(Item);
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btPrint_Click(object sender, EventArgs e)
        {

            if (txtDateFrom.Value != null && txtDateTo.Value != null)
            {
                DataTable oHash = oUPS.GetCustomerRange(txtDateFrom.Value, txtDateTo.Value, txtType.CheckedItem.DataValue.ToString());
                foreach (DataRow _CustomerID in oHash.Rows)
                {
                    //MessageBox.Show(_CustomerID["CustomerID"].ToString());
                    Infragistics.Win.UltraWinListView.UltraListViewItem Item = new Infragistics.Win.UltraWinListView.UltraListViewItem();
                    Item.Tag = _CustomerID["CustomerID"].ToString();
                    Item.Appearance.Image = global::Signature.Forms.Properties.Resources.office_building;

                    Item.Value = _CustomerID["CustomerID"].ToString() + "-" + _CustomerID["Name"].ToString();

                    lvCustomers.Items.Add(Item);
                    lvCustomers.Update();
                }

             
            }
            oUPS.DeleteAll();
            foreach (Infragistics.Win.UltraWinListView.UltraListViewItem Item in lvCustomers.Items)
             {
                 for (int x = 0; x < (Int32)txtCopies.Number; x++)
                 {
                     if (opLabel.CheckedItem.DataValue == "UPS")
                     {
                         oUPS.Weight = txtWeight.Number;
                         oUPS.ServiceType = cbServiceType.Text;
                         oUPS.Find(Item.Tag.ToString());
                         oUPS.Save();
                     }
                     if (opLabel.CheckedItem.DataValue == "Fedex")
                     {
                         oFedex.Weight = txtWeight.Number;
                         oFedex.ServiceType = cbServiceType.Text;
                         oFedex.Find(Item.Tag.ToString());
                         oFedex.Save();
                     }
                     
                 }

             }
            
            this.Dispose();
        }
    }
}