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
	public sealed class frmStateTax : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label3;
        private Label label1;
        private ComboBox ctrState;
        private Label txtDescription;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ctrTaxable;
        private Signature.Windows.Forms.MaskedEditNumeric txtTax;
        internal Label label26;
        #endregion

        Product oProduct;
        
        TaxByState oTaxState;
        
        public frmStateTax()
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtTax = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label26 = new System.Windows.Forms.Label();
            this.ctrTaxable = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.txtDescription = new System.Windows.Forms.Label();
            this.ctrState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrTaxable)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 146);
            this.txtStatus.Size = new System.Drawing.Size(481, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtTax);
            this.ultraGroupBox1.Controls.Add(this.label26);
            this.ultraGroupBox1.Controls.Add(this.ctrTaxable);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.ctrState);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(481, 146);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtTax
            // 
            this.txtTax.AllowDrop = true;
            appearance2.ForeColorDisabled = System.Drawing.Color.White;
            this.txtTax.Appearance = appearance2;
            this.txtTax.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTax.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtTax.InputMask = "nn.nnn%";
            this.txtTax.Location = new System.Drawing.Point(106, 113);
            this.txtTax.Name = "txtSigned";
            this.txtTax.PromptChar = ' ';
            this.txtTax.Size = new System.Drawing.Size(48, 20);
            this.txtTax.TabIndex = 253;
            this.txtTax.Text = "%";
            this.txtTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 113);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 18);
            this.label26.TabIndex = 254;
            this.label26.Text = "Sales Tax:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrTaxable
            // 
            this.ctrTaxable.BackColor = System.Drawing.Color.Transparent;
            this.ctrTaxable.BackColorInternal = System.Drawing.Color.Transparent;
            this.ctrTaxable.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "Y";
            valueListItem1.DisplayText = "Yes";
            valueListItem2.DataValue = "N";
            valueListItem2.DisplayText = "No";
            this.ctrTaxable.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ctrTaxable.Location = new System.Drawing.Point(106, 86);
            this.ctrTaxable.Name = "ctrTaxable";
            this.ctrTaxable.Size = new System.Drawing.Size(91, 22);
            this.ctrTaxable.TabIndex = 32;
            this.ctrTaxable.ValueChanged += new System.EventHandler(this.ctrTaxable_ValueChanged);
            this.ctrTaxable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Location = new System.Drawing.Point(190, 26);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 20);
            this.txtDescription.TabIndex = 31;
            // 
            // ctrState
            // 
            this.ctrState.FormattingEnabled = true;
            this.ctrState.Location = new System.Drawing.Point(106, 58);
            this.ctrState.Name = "ctrState";
            this.ctrState.Size = new System.Drawing.Size(127, 21);
            this.ctrState.TabIndex = 30;
            this.ctrState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.ctrState.SelectedValueChanged += new System.EventHandler(this.ctrState_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "State:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Taxable:";
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(106, 26);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 20;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product ID:";
            // 
            // frmStateTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 175);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmStateTax";
            this.ShowInTaskbar = false;
            this.Text = "Special Item/State Tax Setup";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrTaxable)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
    	private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oProduct = new Product(this.CompanyID);
            oTaxState = new TaxByState(CompanyID);
            this.txtProductID.Focus();
            //Load Brochures
            
            DataTable table = new DataTable();
            table = oMySql.GetDataTable("Select * from States", "States");

            ctrState.DataSource = table;
            ctrState.DisplayMember = "Name";
            ctrState.ValueMember = "StateID";
            ctrState.Text = "";


		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtProductID
            if (sender==txtProductID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oProduct.View())
                    {
                        Clear();
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                     
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtProductID.Focus();
                    }
                    
                    if (oProduct.Find(txtProductID.Text))
                    {
                        Clear();
                        txtDescription.Text = oProduct.Description;
                        
                    } else
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
                            oTaxState.Delete();
                            Clear();
                            txtProductID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    txtProductID.Focus();
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
            oTaxState.ProductID = txtProductID.Text;
            oTaxState.StateID = ctrState.SelectedValue.ToString();
            if (ctrTaxable.CheckedIndex > -1)
            {
                oTaxState.Taxable = ctrTaxable.CheckedItem.DataValue.ToString();
                oTaxState.Tax = txtTax.Number;
                oTaxState.Save();
            
            Clear();
            txtProductID.Clear();
        }

        }
        public void Display()
        {
            //Clear();
            //txtLength.Text = oProduct.Length.ToString();
          // txtProductID.Text = oProduct.ID;
            if (oTaxState.Taxable == "Y")
            {
                ctrTaxable.CheckedIndex = 0;
                txtTax.Visible = true;
                txtTax.Value = oTaxState.Tax;
            }
            else if (oTaxState.Taxable == "N")
            {
                ctrTaxable.CheckedIndex = 1;
                txtTax.Visible = false;
                txtTax.Value = oTaxState.Tax;
            }
            else
            {
                ctrTaxable.CheckedIndex = -1;
                txtTax.Visible = false;
                txtTax.Value = oTaxState.Tax;
            }
            
            
        }
        public void Clear()
        {
            ctrState.Text = "";
            ctrTaxable.CheckedIndex = -1;
            txtTax.Value = 0.00;
            
        }
 		#endregion

        private void ctrState_SelectedValueChanged(object sender, EventArgs e)
        {
            oTaxState.ProductID = txtProductID.Text;

            oTaxState.Find(ctrState.SelectedValue.ToString());
                
            Display();
            
        }

        private void ctrTaxable_ValueChanged(object sender, EventArgs e)
        {
            if (ctrTaxable.CheckedIndex == 0)
            {
                txtTax.Visible = true;
            }
            else
            {
                txtTax.Visible = false;
            }

        }

	}
}
