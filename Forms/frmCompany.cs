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
	public sealed class frmCompany : frmBase
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
        private Signature.Windows.Forms.MaskedEditNumeric txtFax;
        private Signature.Windows.Forms.MaskedEditNumeric txtPhone;
      
        #endregion

        private Label txtPnoneExt;
        private Signature.Windows.Forms.MaskedEdit txtCompanyID;
        private CheckBox cbIsExternal;
        
        
        Company oCompany;
        public frmCompany()
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
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.cbIsExternal = new System.Windows.Forms.CheckBox();
            this.txtCompanyID = new Signature.Windows.Forms.MaskedEdit();
            this.txtPnoneExt = new System.Windows.Forms.Label();
            this.txtFax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPhone = new Signature.Windows.Forms.MaskedEditNumeric();
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
            this.txtStatus.Location = new System.Drawing.Point(0, 386);
            this.txtStatus.Size = new System.Drawing.Size(426, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.cbIsExternal);
            this.groupBox2.Controls.Add(this.txtCompanyID);
            this.groupBox2.Controls.Add(this.txtPnoneExt);
            this.groupBox2.Controls.Add(this.txtFax);
            this.groupBox2.Controls.Add(this.txtPhone);
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
            this.groupBox2.Size = new System.Drawing.Size(416, 379);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbIsExternal
            // 
            this.cbIsExternal.AutoSize = true;
            this.cbIsExternal.BackColor = System.Drawing.Color.Transparent;
            this.cbIsExternal.Location = new System.Drawing.Point(99, 312);
            this.cbIsExternal.Name = "cbIsExternal";
            this.cbIsExternal.Size = new System.Drawing.Size(75, 17);
            this.cbIsExternal.TabIndex = 299;
            this.cbIsExternal.Text = "Is External";
            this.cbIsExternal.UseVisualStyleBackColor = false;
            this.cbIsExternal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.AllowDrop = true;
            this.txtCompanyID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCompanyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyID.Location = new System.Drawing.Point(99, 17);
            this.txtCompanyID.Name = "txtCustomerID";
            this.txtCompanyID.Size = new System.Drawing.Size(80, 20);
            this.txtCompanyID.TabIndex = 0;
            this.txtCompanyID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPnoneExt
            // 
            this.txtPnoneExt.BackColor = System.Drawing.Color.Transparent;
            this.txtPnoneExt.Location = new System.Drawing.Point(11, 17);
            this.txtPnoneExt.Name = "txtPnoneExt";
            this.txtPnoneExt.Size = new System.Drawing.Size(71, 20);
            this.txtPnoneExt.TabIndex = 276;
            this.txtPnoneExt.Text = "Company ID:";
            // 
            // txtFax
            // 
            this.txtFax.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtFax.Appearance = appearance2;
            this.txtFax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFax.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtFax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtFax.InputMask = "(###) ###-####";
            this.txtFax.Location = new System.Drawing.Point(99, 264);
            this.txtFax.Name = "txtRetail";
            this.txtFax.PromptChar = ' ';
            this.txtFax.Size = new System.Drawing.Size(80, 20);
            this.txtFax.TabIndex = 7;
            this.txtFax.Text = "() -";
            this.txtFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPhone
            // 
            this.txtPhone.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtPhone.Appearance = appearance3;
            this.txtPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhone.InputMask = "(###) ###-####";
            this.txtPhone.Location = new System.Drawing.Point(99, 238);
            this.txtPhone.Name = "txtRetail";
            this.txtPhone.PromptChar = ' ';
            this.txtPhone.Size = new System.Drawing.Size(80, 20);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
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
            this.txtZipCode.TabIndex = 5;
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
            this.txtState.TabIndex = 4;
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
            this.txtCity.TabIndex = 3;
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
            this.txtAddress.TabIndex = 2;
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
            this.txtName.Location = new System.Drawing.Point(99, 81);
            this.txtName.Name = "txtCustomerID";
            this.txtName.Size = new System.Drawing.Size(289, 20);
            this.txtName.TabIndex = 1;
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
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(426, 415);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCompany";
            this.ShowInTaskbar = false;
            this.Text = "Company Maintenance";
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
            oCompany = new Company(this.CompanyID);
            
            this.txtCompanyID.Focus();
            
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtCompanyID
            if (sender == txtCompanyID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCompany.ViewAll())
                    {
                        txtCompanyID.Text = oCompany.ID;
                        ShowRep();
                        txtName.Focus();
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCompanyID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtName.Focus();
                    }

                    if (oCompany.Find(txtCompanyID.Text))
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
                            oCompany.Delete();
                            Clear();
                            txtCompanyID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    txtCompanyID.Focus();
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
            oCompany.ID = txtCompanyID.Text;
            oCompany.Name        = txtName.Text;
            oCompany.Address     = txtAddress.Text  ;
            oCompany.City        = txtCity.Text;
            oCompany.State       = txtState.Text;
            oCompany.ZipCode     = txtZipCode.Text;
            oCompany.Phone       = txtPhone.Value.ToString();
            oCompany.IsExternal = cbIsExternal.Checked;
            oCompany.Save();
            Clear();
            txtCompanyID.Clear();
            

        }
        
        public bool ShowRep()
        {
            Clear();
            txtName.Text = oCompany.Name;
            txtAddress.Text = oCompany.Address;
            txtCity.Text    = oCompany.City;
            txtState.Text = oCompany.State;
            txtZipCode.Text = oCompany.ZipCode;
            txtPhone.Text = oCompany.Phone;
            txtFax.Text = oCompany.Fax;
            cbIsExternal.Checked = oCompany.IsExternal;
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
            txtName.Clear();
            cbIsExternal.Checked = false;
            
        }
      
		#endregion

        

	}
}
