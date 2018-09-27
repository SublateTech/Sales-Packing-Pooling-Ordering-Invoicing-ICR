using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmRep : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
        private Signature.Windows.Forms.MaskedEdit txtName;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtAddress;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtState;
        private Label label8;
        private Signature.Windows.Forms.MaskedEdit txtCity;
        private Label label5;
        private Signature.Windows.Forms.MaskedEdit txtZipCode;
        private Label label4;
        private Label label7;
        private Label label6;
        private Signature.Windows.Forms.MaskedEdit txtContact;
        private Label label9;
        private Signature.Windows.Forms.MaskedEditNumeric txtFax;
        private Signature.Windows.Forms.MaskedEditNumeric txtPhone;
      
        #endregion
        private Signature.Windows.Forms.MaskedEdit txteMail;
        private Label label10;
        private CheckBox txtRepChargesList;
        private Label txtPnoneExt;
        private Signature.Windows.Forms.MaskedEditNumeric txtRepID;
        private CheckBox cbCompetitors;
        private CheckBox cbShowCommission;
        
        
        Rep oRep;
        public frmRep()
		{
			InitializeComponent();
            
		}
 	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.cbShowCommission = new System.Windows.Forms.CheckBox();
            this.cbCompetitors = new System.Windows.Forms.CheckBox();
            this.txtRepID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPnoneExt = new System.Windows.Forms.Label();
            this.txtRepChargesList = new System.Windows.Forms.CheckBox();
            this.txteMail = new Signature.Windows.Forms.MaskedEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtContact = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZipCode = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtState = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new Signature.Windows.Forms.MaskedEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 412);
            this.txtStatus.Size = new System.Drawing.Size(427, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.cbShowCommission);
            this.groupBox2.Controls.Add(this.cbCompetitors);
            this.groupBox2.Controls.Add(this.txtRepID);
            this.groupBox2.Controls.Add(this.txtPnoneExt);
            this.groupBox2.Controls.Add(this.txtRepChargesList);
            this.groupBox2.Controls.Add(this.txteMail);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtFax);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtZipCode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 402);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbShowCommission
            // 
            this.cbShowCommission.AutoSize = true;
            this.cbShowCommission.BackColor = System.Drawing.Color.Transparent;
            this.cbShowCommission.Location = new System.Drawing.Point(104, 366);
            this.cbShowCommission.Name = "cbShowCommission";
            this.cbShowCommission.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbShowCommission.Size = new System.Drawing.Size(143, 17);
            this.cbShowCommission.TabIndex = 278;
            this.cbShowCommission.Text = "Do not show commission";
            this.cbShowCommission.UseVisualStyleBackColor = false;
            this.cbShowCommission.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // cbCompetitors
            // 
            this.cbCompetitors.AutoSize = true;
            this.cbCompetitors.BackColor = System.Drawing.Color.Transparent;
            this.cbCompetitors.Location = new System.Drawing.Point(113, 343);
            this.cbCompetitors.Name = "cbCompetitors";
            this.cbCompetitors.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCompetitors.Size = new System.Drawing.Size(134, 17);
            this.cbCompetitors.TabIndex = 277;
            this.cbCompetitors.Text = "Competitor\'s Brochures";
            this.cbCompetitors.UseVisualStyleBackColor = false;
            this.cbCompetitors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtRepID.Appearance = appearance2;
            this.txtRepID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRepID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRepID.FormatString = "###,###.##";
            this.txtRepID.InputMask = "nnnnnnnnn";
            this.txtRepID.Location = new System.Drawing.Point(99, 17);
            this.txtRepID.Name = "txtAmountDue";
            this.txtRepID.Size = new System.Drawing.Size(64, 20);
            this.txtRepID.TabIndex = 0;
            this.txtRepID.Text = "0";
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPnoneExt
            // 
            this.txtPnoneExt.BackColor = System.Drawing.Color.Transparent;
            this.txtPnoneExt.Location = new System.Drawing.Point(11, 17);
            this.txtPnoneExt.Name = "txtPnoneExt";
            this.txtPnoneExt.Size = new System.Drawing.Size(62, 20);
            this.txtPnoneExt.TabIndex = 276;
            this.txtPnoneExt.Text = "Rep ID:";
            // 
            // txtRepChargesList
            // 
            this.txtRepChargesList.AutoSize = true;
            this.txtRepChargesList.BackColor = System.Drawing.Color.Transparent;
            this.txtRepChargesList.Location = new System.Drawing.Point(99, 320);
            this.txtRepChargesList.Name = "txtRepChargesList";
            this.txtRepChargesList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRepChargesList.Size = new System.Drawing.Size(148, 17);
            this.txtRepChargesList.TabIndex = 11;
            this.txtRepChargesList.Text = "Show in Rep Charges List";
            this.txtRepChargesList.UseVisualStyleBackColor = false;
            this.txtRepChargesList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txteMail
            // 
            this.txteMail.AllowDrop = true;
            this.txteMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txteMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txteMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txteMail.Location = new System.Drawing.Point(99, 290);
            this.txteMail.Name = "txtCustomerID";
            this.txteMail.Size = new System.Drawing.Size(289, 20);
            this.txteMail.TabIndex = 10;
            this.txteMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(11, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "eMail:";
            // 
            // txtFax
            // 
            this.txtFax.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtFax.Appearance = appearance3;
            this.txtFax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFax.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtFax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtFax.InputMask = "(###) ###-####";
            this.txtFax.Location = new System.Drawing.Point(99, 264);
            this.txtFax.Name = "txtRetail";
            this.txtFax.PromptChar = ' ';
            this.txtFax.Size = new System.Drawing.Size(80, 20);
            this.txtFax.TabIndex = 9;
            this.txtFax.Text = "() -";
            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPhone
            // 
            this.txtPhone.AllowDrop = true;
            appearance4.TextHAlignAsString = "Right";
            this.txtPhone.Appearance = appearance4;
            this.txtPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhone.InputMask = "(###) ###-####";
            this.txtPhone.Location = new System.Drawing.Point(99, 238);
            this.txtPhone.Name = "txtRetail";
            this.txtPhone.PromptChar = ' ';
            this.txtPhone.Size = new System.Drawing.Size(80, 20);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtContact
            // 
            this.txtContact.AllowDrop = true;
            this.txtContact.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.Location = new System.Drawing.Point(99, 211);
            this.txtContact.Name = "txtCustomerID";
            this.txtContact.Size = new System.Drawing.Size(289, 20);
            this.txtContact.TabIndex = 7;
            this.txtContact.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(11, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Contact:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(11, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Fax Number:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(11, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Phone Number:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.AllowDrop = true;
            this.txtZipCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZipCode.Location = new System.Drawing.Point(99, 185);
            this.txtZipCode.Name = "txtCustomerID";
            this.txtZipCode.Size = new System.Drawing.Size(77, 20);
            this.txtZipCode.TabIndex = 6;
            this.txtZipCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "ZipCode :";
            // 
            // txtState
            // 
            this.txtState.AllowDrop = true;
            this.txtState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtState.Location = new System.Drawing.Point(99, 159);
            this.txtState.Name = "txtCustomerID";
            this.txtState.Size = new System.Drawing.Size(37, 20);
            this.txtState.TabIndex = 5;
            this.txtState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(11, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.AllowDrop = true;
            this.txtCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.Location = new System.Drawing.Point(99, 133);
            this.txtCity.Name = "txtCustomerID";
            this.txtCity.Size = new System.Drawing.Size(116, 20);
            this.txtCity.TabIndex = 4;
            this.txtCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(11, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "City:";
            // 
            // txtAddress
            // 
            this.txtAddress.AllowDrop = true;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Location = new System.Drawing.Point(99, 107);
            this.txtAddress.Name = "txtCustomerID";
            this.txtAddress.Size = new System.Drawing.Size(289, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Address:";
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(99, 81);
            this.txtName.Name = "txtCustomerID";
            this.txtName.Size = new System.Drawing.Size(289, 20);
            this.txtName.TabIndex = 2;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name:";
            // 
            // frmRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(427, 441);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmRep";
            this.ShowInTaskbar = false;
            this.Text = "Rep Maintenance";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oRep = new Rep(this.CompanyID);
            
            this.txtRepID.Focus();

            
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtRepID
            if (sender == txtRepID)
            {
                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oRep.ViewByID())
                    {
                        ShowRep();
                        txtName.Focus();
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtRepID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtName.Focus();
                    }

                    if (oRep.Find(Convert.ToInt32(txtRepID.Text)))
                    {
                        ShowRep();
                        txtName.Focus();


                    }
                    else
                    {
                        Clear();

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
                    if (sender == txtFax)
                        return;
                    this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
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
                            oRep.Delete();
                            Clear();
                            txtRepID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    txtRepID.Focus();
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        #endregion
        
        #region  Methods
        public void Save()
        {
            oRep.Name        = txtName.Text;
            oRep.Address     = txtAddress.Text  ;
            oRep.City        = txtCity.Text;
            oRep.State       = txtState.Text;
            oRep.Contact     = txtContact.Text;
            oRep.ZipCode     = txtZipCode.Text;
            oRep.Phone       = txtPhone.Value.ToString();
            oRep.Fax         = txtFax.Value.ToString();
            oRep.eMail       = txteMail.Text;
            oRep.RepID       = (int) txtRepID.Number;
            oRep.IsChargesListed = txtRepChargesList.Checked;
            oRep.IsCompetitorsBrochure = cbCompetitors.Checked;
            oRep.IsNotShowCommission = cbShowCommission.Checked;
            oRep.Save();
            Clear();
            txtRepID.Clear();
            

        }
        
        public bool ShowRep()
        {
            Clear();
            txtName.Text = oRep.Name;
            txtRepID.Text = oRep.RepID.ToString();
            txtAddress.Text = oRep.Address;
            txtCity.Text    = oRep.City;
            txtState.Text = oRep.State;
            txtZipCode.Text = oRep.ZipCode;
            txtContact.Text = oRep.Contact;
            txtPhone.Text = oRep.Phone;
            txtFax.Text = oRep.Fax;
            txteMail.Text = oRep.eMail;
            cbCompetitors.Checked = oRep.IsCompetitorsBrochure;
            txtRepChargesList.Checked = oRep.IsChargesListed;
            cbShowCommission.Checked = oRep.IsNotShowCommission;

            return true;
        }
        public void Clear()
        {
           
            txtAddress.Clear();
            txtState.Clear();
            txtCity.Clear();
            txtZipCode.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtContact.Clear();
            txtName.Clear();
            txteMail.Clear();
            txtRepChargesList.Checked = false;
            cbCompetitors.Checked = false;
            cbShowCommission.Checked = false;
        }
      
		#endregion

        private void bSubmit_Click(object sender, EventArgs e)
        {
            frmProductByRep oPrdRep = new frmProductByRep();
            oPrdRep.ShowDialog();
        }

        

	}
}
