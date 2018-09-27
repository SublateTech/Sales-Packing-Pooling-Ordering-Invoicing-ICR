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
    public partial class frmBrochureListing: frmBase
    {
        Brochure oBrochure;

        public frmBrochureListing()
        {
            InitializeComponent();
        }
        private void frmCustomerListing_Load(object sender, EventArgs e)
        {
            oBrochure = new Brochure(base.CompanyID);
            
        }
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtBrochureID
            if (sender == txtBrochureID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {
                        
                        txtBrochureID.Text = oBrochure.ID;
                        txtDescription.Text = oBrochure.Description;
                    
                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID.Text.Trim().Length == 0)
                    {
                        
                        txtBrochureID.Focus();
                    }

                    if (oBrochure.Find(txtBrochureID.Text))
                    {
                        
                        txtBrochureID.Text = oBrochure.ID;
                        txtDescription.Text = oBrochure.Description;
                    
                    }
                    



                }

            }
            #endregion
            #region txtBrochureID_2
            if (sender == txtBrochureID_2)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBrochure.View())
                    {

                        txtBrochureID_2.Text = oBrochure.ID;
                        txtDescription_2.Text = oBrochure.Description;

                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID_2.Text.Trim().Length == 0)
                    {

                        txtBrochureID_2.Focus();
                    }

                    if (oBrochure.Find(txtBrochureID_2.Text))
                    {

                        txtBrochureID_2.Text = oBrochure.ID;
                        txtDescription_2.Text = oBrochure.Description;

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
                    if (txtBrochureID.Text.Length > 0 && txtBrochureID_2.Text.Length > 0)
                        oBrochure.Print2Brochures(txtBrochureID.Text,txtBrochureID_2.Text);
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