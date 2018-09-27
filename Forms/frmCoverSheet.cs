using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Data;
using Signature.Classes;

namespace Signature.Forms
{
    
    public partial class frmCoverSheet : frmBase
    {

        Customer oCustomer;
        CoverSheet oCover;
        private Int32 PreviousNoLetters = 0;

        public frmCoverSheet()
        {
            InitializeComponent();

            oCustomer = new Customer(this.CompanyID);
            oCover = new CoverSheet(this.CompanyID);
        }

        #region Events
        new private void KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtCustomerID
            if (sender == txtCustomerID)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomerID.Text = txtCustomerID.Text.Trim();
                    if (oCustomer.Find(txtCustomerID.Text))
                    {
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;

                        if (oCover.Find(oCustomer.ID))
                            Display();
                        else
                            Clear();
                        if (txtNoLetters.Number == 0)
                            txtNoLetters.Text = oCustomer.Signed.ToString();
                        txtNoLetters.Focus();
                        return;
                    }
                    else
                    {
                        Clear();
                        txtCustomerID.Focus();
                    }
                }

                if (e.KeyCode == Keys.F2)
                {
                    if (oCustomer.View())
                    {
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        if (oCover.Find(oCustomer.ID))
                            Display();
                        else
                            Clear();
                        if (txtNoLetters.Number == 0)
                            txtNoLetters.Text = oCustomer.Signed.ToString();
                        txtNoLetters.Focus();
                        
                    }
                    return;
                }
                

            }
            #endregion
            #region txtNoLetters
            if (sender == txtNoLetters)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNoLetters.Number == 0)
                    {
                        txtNoLetters.Text = oCustomer.Signed.ToString();
                        txtNoLetters.Focus();
                        return;
                    }
                    
                }


            }
            #endregion
            #region txtNoTeachers
            if (sender == txtNoTeachers )
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //LET XX=X; IF X=0 THEN LET XX=ROUND(COVER[1]/20,0); GOTO 1310
                    //1341 IF XX<>INT(XX/5)*5 THEN LET XX=5+INT(XX/5)*5; GOTO 1310
                    if (txtNoTeachers.Number == 0)
                    {
                        txtNoTeachers.Text = Math.Round(txtNoLetters.Number / 20).ToString();
                        return;
                    }

                    if (txtNoTeachers.Number != Math.Round(txtNoTeachers.Number/5)*5)
                        txtNoTeachers.Text = (Math.Round(txtNoTeachers.Number/5)*5 + 5).ToString();

                }

            }
            #endregion
            #region txtNoLetters
            if (sender == txtNoLetters)
            {
                if (e.KeyCode == Keys.Enter)
                {
                   

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
                    if (sender != txtDetail)
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
                    {
                        if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            MessageBox.Show("Operation Cancelled");
                            return;
                        }
                        else
                        {
                            //oCover.Delete();
                            //Clear();
                            txtCustomerID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        Save();
                        if (MessageBox.Show("Do you want to print?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //txtPrint_Click(null, null);
                            oCustomer.PrintCoversheet();
                            Inventory oInventory = new Inventory(CompanyID);
                            oInventory.Update(oCover, Inventory.InventoryType.RollBack);
                            oInventory.Update(oCover, Inventory.InventoryType.Commit);
                        }
                        Clear();
                        txtCustomerID.Text = "";
                        txtCustomerID.Focus();

                    }
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion
            e.Handled = true;
            return;
        }
        #endregion

        #region Methods

        public void Display()
        {

            PreviousNoLetters = oCover.N_Letters;
            txtNoLetters.Text = oCover.N_Letters.ToString();
            txtNoTeachers.Text = oCover.N_TeacherEnvelopes.ToString();
            cbSpanish.Text = oCover.Spanish=="1"  ? "YES" : "NO";
            cbAdditionalPiece1.Text = oCover.AdditionalPiece1 == "1" ? "YES" : "NO";
            cbAdditionalPiece2.Text = oCover.AdditionalPiece2 == "1" ? "YES" : "NO";
            cbSigDirectBooklet.Text = oCover.SigDirectBooklet == "1" ? "YES" : "NO";
            cbEScooterSample.Text = oCover.eScooterSample == "1" ? "YES" : "NO";
            cbSalesRepBooklet.Text = oCover.SalesRepBooklet == "1" ? "No-Check" : "Regular";
            cbUPSReturnBox.Text = oCover.UPSReturnBox == "1" ? "YES" : "NO";
            txtKickOffVideos.Text = oCover.KickOffVideos.ToString();
            cbPosters.Text = oCover.Posters == "1" ? "YES" : "NO";
            cbDisplayKit.Text = oCover.DisplayKit == "1" ? "YES" : "NO";
            cbSigProduct.Text = oCover.SigProduct == "1" ? "YES" : "NO";
            txtTeacherGifts.Text = oCover.TeacherGifts.ToString();
            txtDetail.Text = oCover.Notes;
            if (oCover.IsReady == "1")
            {
                rdReady.Checked = true;
                txtReadyDate.Value = oCover.ReadyDate;
            }
            else
            {
                rdShip.Checked = true;
                txtShipDate.Value = oCover.ReadyDate;
            }

           cb15ItemFlier.Text = oCover.B15ItemFlier? "YES" : "NO";
           cbPriceADay.Text = oCover.PriceADay ? "YES" : "NO";
           cbCustomUPSRS.Text = oCover.CustomUPSRS ? "YES" : "NO";

        }
        public void Save()
        {
            oCover.CustomerID = txtCustomerID.Text;
            oCover.N_Letters = (Int32) txtNoLetters.Number;
            oCover.N_TeacherEnvelopes = (Int32) txtNoTeachers.Number;
            oCover.Spanish = cbSpanish.Text == "YES" ? "1" : "0";
            oCover.AdditionalPiece1 = cbAdditionalPiece1.Text == "YES" ?  "1" : "0";
            oCover.AdditionalPiece2 = cbAdditionalPiece2.Text == "YES" ? "1" : "0";
            oCover.SigDirectBooklet = cbSigDirectBooklet.Text == "YES" ? "1" : "0";
            oCover.SalesRepBooklet = cbSalesRepBooklet.Text == "No-Check" ? "1" : "0";
            oCover.UPSReturnBox = cbUPSReturnBox.Text == "YES" ? "1" : "0";
            oCover.KickOffVideos = (Int32) txtKickOffVideos.Number;
            oCover.Posters = cbPosters.Text == "YES" ? "1" : "0";
            oCover.DisplayKit = cbDisplayKit.Text == "YES" ? "1" : "0";
            oCover.Notes = txtDetail.Text;
            oCover.TeacherGifts = (Int32)txtTeacherGifts.Number;
            oCover.SigProduct = cbSigProduct.Text == "YES" ? "1" : "0";
            oCover.eScooterSample = cbEScooterSample.Text == "YES" ? "1" : "0";

            if (rdReady.Checked)
            {
                oCover.IsReady = "1";
                oCover.ReadyDate = (DateTime)txtReadyDate.Value;
            }
            else
            {
                oCover.IsReady = "0";
                oCover.ReadyDate = (DateTime)txtShipDate.Value;
            }

            oCover.B15ItemFlier = cb15ItemFlier.Text == "YES" ? true : false;
            oCover.PriceADay = cbCustomUPSRS.Text == "YES" ? true : false;
            oCover.CustomUPSRS = cbCustomUPSRS.Text == "YES" ? true : false;

            oCover.Save();
        }
        public void Clear()
        {
            txtNoLetters.Clear();
            txtNoTeachers.Clear();
            cbSpanish.Text = "NO";
            cbAdditionalPiece1.Text = "NO";
            cbAdditionalPiece2.Text = "NO";
            cbSigDirectBooklet.Text = "NO";
            cbSalesRepBooklet.Text = "Regular";
            cbUPSReturnBox.Text = "NO";
            cbEScooterSample.Text = "NO";
            cbPosters.Text = "NO";
            cbSigProduct.Text = "NO";
            txtTeacherGifts.Text = "";
            cbDisplayKit.Text = "NO";
            txtDetail.Text = "";
            rdShip.Checked = false;
            rdReady.Checked = false;

            cb15ItemFlier.Text =  "NO";
            cbPriceADay.Text = "NO";
            cbCustomUPSRS.Text = "NO";

        }

        #endregion

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                Save();
                if (MessageBox.Show("Do you want to print?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //txtPrint_Click(null, null);
                    oCustomer.PrintCoversheet();
                    Inventory oInventory = new Inventory(CompanyID);
                    oInventory.Update(oCover, Inventory.InventoryType.RollBack);
                    oInventory.Update(oCover, Inventory.InventoryType.Commit);
                }
                Clear();
                txtCustomerID.Text = "";
                txtCustomerID.Focus();

            }
        }

        private void rdReady_CheckedChanged(object sender, EventArgs e)
        {
            
            txtShipDate.Enabled = false;
            txtReadyDate.Enabled = true;
        }

        private void rdShip_CheckedChanged(object sender, EventArgs e)
        {
            
            txtShipDate.Enabled = true;
            txtReadyDate.Enabled = false;;
        }


    }
}