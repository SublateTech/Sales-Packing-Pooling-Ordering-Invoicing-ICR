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
	public sealed class frmCharges : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Label label2;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label3;
        private ComboBox ctrType;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        private Signature.Windows.Forms.MaskedEditNumeric txtAmount;
        private Label label4;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtChargeID;
        private Label label5;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDate;
        internal Label label22;
        #endregion

        
        Charge oPayment;
        private CheckBox txtChanges;
        private Signature.Windows.Forms.MaskedEditNumeric txtAmountDue;
        internal Label lAmountDue;
        Customer oCustomer;

        public frmCharges()
		{
			InitializeComponent();
            
            oCustomer = new Customer(this.CompanyID);
		}
        
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharges));
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtAmountDue = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lAmountDue = new System.Windows.Forms.Label();
            this.txtChanges = new System.Windows.Forms.CheckBox();
            this.txtDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label22 = new System.Windows.Forms.Label();
            this.txtChargeID = new Signature.Windows.Forms.MaskedEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ctrType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 345);
            this.txtStatus.Size = new System.Drawing.Size(539, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtAmountDue);
            this.ultraGroupBox1.Controls.Add(this.lAmountDue);
            this.ultraGroupBox1.Controls.Add(this.txtChanges);
            this.ultraGroupBox1.Controls.Add(this.txtDate);
            this.ultraGroupBox1.Controls.Add(this.label22);
            this.ultraGroupBox1.Controls.Add(this.txtChargeID);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtAmount);
            this.ultraGroupBox1.Controls.Add(this.txtComment);
            this.ultraGroupBox1.Controls.Add(this.ctrType);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(539, 345);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.AllowDrop = true;
            appearance39.TextHAlignAsString = "Right";
            this.txtAmountDue.Appearance = appearance39;
            this.txtAmountDue.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAmountDue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtAmountDue.FormatString = "###,###.##";
            this.txtAmountDue.InputMask = "{LOC}-nnnnnnnnnn.nn";
            this.txtAmountDue.Location = new System.Drawing.Point(119, 137);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.ReadOnly = true;
            this.txtAmountDue.Size = new System.Drawing.Size(64, 20);
            this.txtAmountDue.TabIndex = 273;
            this.txtAmountDue.Text = "0.00";
            // 
            // lAmountDue
            // 
            this.lAmountDue.BackColor = System.Drawing.Color.Transparent;
            this.lAmountDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAmountDue.Location = new System.Drawing.Point(30, 137);
            this.lAmountDue.Name = "lAmountDue";
            this.lAmountDue.Size = new System.Drawing.Size(77, 18);
            this.lAmountDue.TabIndex = 274;
            this.lAmountDue.Text = "Amount Due :";
            this.lAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChanges
            // 
            this.txtChanges.AutoSize = true;
            this.txtChanges.BackColor = System.Drawing.Color.Transparent;
            this.txtChanges.Location = new System.Drawing.Point(333, 113);
            this.txtChanges.Name = "txtChanges";
            this.txtChanges.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtChanges.Size = new System.Drawing.Size(148, 17);
            this.txtChanges.TabIndex = 272;
            this.txtChanges.Text = "Show in Rep Charges List";
            this.txtChanges.UseVisualStyleBackColor = false;
            // 
            // txtDate
            // 
            this.txtDate.DateTime = new System.DateTime(2007, 12, 13, 0, 0, 0, 0);
            this.txtDate.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.txtDate.Location = new System.Drawing.Point(390, 81);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(91, 21);
            this.txtDate.TabIndex = 4;
            this.txtDate.Value = new System.DateTime(2007, 12, 13, 0, 0, 0, 0);
            this.txtDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(333, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 18);
            this.label22.TabIndex = 271;
            this.label22.Text = "Date:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChargeID
            // 
            this.txtChargeID.AllowDrop = true;
            this.txtChargeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtChargeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChargeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChargeID.Location = new System.Drawing.Point(390, 24);
            this.txtChargeID.Name = "txtCustomerID";
            this.txtChargeID.Size = new System.Drawing.Size(80, 20);
            this.txtChargeID.TabIndex = 5;
            this.txtChargeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(322, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 269;
            this.label5.Text = "Charge ID:";
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance2.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance2;
            this.txtName.Location = new System.Drawing.Point(38, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(452, 25);
            this.txtName.TabIndex = 5;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(35, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 267;
            this.label4.Text = "Comment:";
            // 
            // txtAmount
            // 
            this.txtAmount.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtAmount.Appearance = appearance3;
            this.txtAmount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAmount.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtAmount.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Currency;
            this.txtAmount.FormatString = "###,###.##";
            this.txtAmount.InputMask = "{LOC}$ -n,nnn,nnn.nn";
            this.txtAmount.Location = new System.Drawing.Point(119, 110);
            this.txtAmount.Name = "txtAmountDue";
            this.txtAmount.Size = new System.Drawing.Size(109, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtComment
            // 
            this.txtComment.AlwaysInEditMode = true;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacterWithLineLimit;
            this.txtComment.Appearance = appearance4;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(119, 163);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(371, 149);
            this.txtComment.TabIndex = 3;
            this.txtComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ctrType
            // 
            this.ctrType.FormattingEnabled = true;
            this.ctrType.Items.AddRange(new object[] {
            "Payment",
            "Adjustment",
            "Invoice"});
            this.ctrType.Location = new System.Drawing.Point(119, 80);
            this.ctrType.Name = "ctrType";
            this.ctrType.Size = new System.Drawing.Size(109, 21);
            this.ctrType.TabIndex = 1;
            this.ctrType.Text = "Payment";
            this.ctrType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(35, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Type Charge:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(119, 24);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(80, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(35, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Customer ID:";
            // 
            // frmCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 374);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCharges";
            this.ShowInTaskbar = false;
            this.Text = "Customer Charges";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oPayment = new Charge(this.CompanyID);
            txtDate.Value = DateTime.Now;
            this.txtCustomerID.Focus();
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtCustomerID
            if (sender==txtCustomerID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oCustomer.View())
                    {
                        oPayment.CustomerID = oCustomer.ID;
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        txtAmountDue.Enabled = false;
                        txtAmountDue.Text = oCustomer.StatementAmountDue.ToString();
                        ctrType.Focus();
                        //txtAmount.Focus();
                        
                    }
                    return; 
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtCustomerID.Focus();
                    }
                    
                    if (oCustomer.Find(txtCustomerID.Text))
                    {
                        oPayment.CustomerID = oCustomer.ID;
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        txtAmountDue.Enabled = false;
                        txtAmountDue.Text = oCustomer.StatementAmountDue.ToString();
                        //txtAmount.Focus();
                        ctrType.Focus();
                        return;
                      
                    } else
                    {
                        Clear();
                        
                    }


                    
                }					

            }
            #endregion
            #region txtChargeID
            if (sender == txtChargeID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oPayment.View())
                    {
                        
                        Display();
                        txtChargeID.Text = oPayment.ID;
                        

                    }
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (oPayment.Find(txtChargeID.Text))
                    {
                        Display();
                        txtChargeID.Text = oPayment.ID;

                    }
                    return;

                }
            }
            #endregion
            #region txtAmount
            if (sender == txtAmount)
            {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtAmount.Number != 0.00)
                    {
                        txtComment.Focus();    
                     }

                    return;
                }
            }
            #endregion
            #region txtText
            if (sender == txtComment)
            {
                if (e.KeyCode != Keys.PageDown)
                    return;

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
                        if (txtChargeID.Text.Trim() != String.Empty)
                        {

                            if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                MessageBox.Show("Operation Cancelled");
                                return;
                            }
                            else
                            {   
                                oPayment.Delete();
                                oCustomer.GetPayments();
                                oCustomer.UpdateCurrentTotals();
                                oCustomer.HasChanged = true;
                                Clear();
                                txtCustomerID.Focus();
                            }
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:

                    oPayment.ID = txtChargeID.Text;
                    oPayment.Date = (DateTime) txtDate.Value;
                    
                    oPayment.Comment = txtComment.Text;
                    switch (ctrType.Text)
                    {
                        case "Payment":
                            oPayment.Type = "P";
                            oPayment.Amount = txtAmount.Number*-1;
                            break;
                        case "Adjustment":
                            oPayment.Type = "A";
                            oPayment.Amount = txtAmount.Number;
                            break;
                        case "Invoice":
                            oPayment.Type = "I";
                           // if (txtAmount.Number < 0)
                                oPayment.Amount = txtAmount.Number;
                            break;
                        default:
                            oPayment.Amount = txtAmount.Number;
                            break;
                    }


                    if (txtChargeID.Text == "")
                    {
                        oPayment.Insert();
                        if (oPayment.Type == "P" && oCustomer.StatementAmountDue != 0)
                            oCustomer.PrintStatement(null, PrinterDevice.Printer);
                    }
                    else
                        oPayment.Save();
                    oCustomer.GetPayments();
                    oCustomer.UpdateCurrentTotals();
                    oCustomer.HasChanged = true;
                    Clear();
                    //txtCustomerID.Clear();        
                    txtCustomerID.Focus();
                    break;

            }
            #endregion

        }
        #endregion
        
        #region  Methods
        public bool Display()
        {
            Clear();
            
            txtCustomerID.Text = oPayment.CustomerID;
            txtAmount.Value = oPayment.Amount;
            txtComment.Value = oPayment.Comment;
            txtDate.Value = oPayment.Date;
            switch (oPayment.Type)
            {
                case "P":
                    ctrType.Text = "Payment";
                    break;
                case "A":
                    ctrType.Text = "Adjustment";
                    break;
                case "I":
                    ctrType.Text = "Invoice";
                    break;
            }

            return true;
        }
        public void Clear()
        {
            txtDate.Value = DateTime.Now;
            txtAmount.Clear();
            txtComment.Clear();
            txtChargeID.Clear();
            txtAmountDue.Clear();
        }
      
		#endregion

	}
}
