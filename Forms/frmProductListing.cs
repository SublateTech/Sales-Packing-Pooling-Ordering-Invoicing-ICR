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
    public partial class frmProductListing: frmBase
    {
        Product oProduct;

        public frmProductListing()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oProduct = new Product(base.CompanyID);
            
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
                    
                    }
                    



                }

            }
            #endregion
            #region txtProductID_2
            if (sender == txtProductID_2)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {

                        txtProductID_2.Text = oProduct.ID;
                        txtDescription_2.Text = oProduct.Description;


                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID_2.Text.Trim().Length == 0)
                    {

                        txtProductID_2.Focus();
                    }

                    if (oProduct.Find(txtProductID_2.Text))
                    {

                        txtProductID_2.Text = oProduct.ID;
                        txtDescription_2.Text = oProduct.Description;


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
                    oProduct.Print(txtProductID.Text,txtProductID_2.Text, txtChecked.Checked);
                    this.Dispose();
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion

        }

        
    }
}