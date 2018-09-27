using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using System.Media;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmCashRegister : frmBase
	{
		#region declarations		
        private Panel panel1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoItems;
        private Label label5;
        private Label label6;
        private Label label7;
        private Signature.Windows.Forms.MaskedEditNumeric txtCollected;
        private Signature.Windows.Forms.MaskedEditNumeric txtDiff;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label8;
        private Label label3;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;

        #endregion
        
		public  Order oOrder;
        private Order.Item IDetail;
        public  OrderProcess _OrderProcess = OrderProcess.Enter;
        private Boolean IsDiff = false;
     //   private Boolean IsCookieDough = false;
     //   private IContainer components;
        
        public Boolean IsSaved = false;

        public String CustomerID = "TEST";

        public frmCashRegister()
		{
			InitializeComponent();
            oOrder = new Order(base.CompanyID);
            oOrder.Type = OrderType.Regular;
         
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashRegister));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoItems = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCollected = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDiff = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ultraGroupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 847);
            this.panel1.TabIndex = 0;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.label7);
            this.ultraGroupBox1.Controls.Add(this.label6);
            this.ultraGroupBox1.Controls.Add(this.txtNoItems);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtCollected);
            this.ultraGroupBox1.Controls.Add(this.txtDiff);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.txtRetail);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label8);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(7, 11);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(987, 133);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(728, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 36);
            this.label7.TabIndex = 36;
            this.label7.Text = "Change:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 36);
            this.label6.TabIndex = 35;
            this.label6.Text = "Retail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoItems
            // 
            this.txtNoItems.AllowDrop = true;
            appearance2.FontData.SizeInPoints = 20F;
            appearance2.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance2;
            this.txtNoItems.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNoItems.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoItems.FormatString = "###,###";
            this.txtNoItems.InputMask = "nnnnnnnnn";
            this.txtNoItems.Location = new System.Drawing.Point(434, 65);
            this.txtNoItems.Name = "txtRetail";
            this.txtNoItems.ReadOnly = true;
            this.txtNoItems.Size = new System.Drawing.Size(73, 38);
            this.txtNoItems.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(344, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 36);
            this.label5.TabIndex = 34;
            this.label5.Text = "Items:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCollected
            // 
            this.txtCollected.AllowDrop = true;
            this.txtCollected.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance3.FontData.SizeInPoints = 20F;
            appearance3.TextHAlignAsString = "Right";
            this.txtCollected.Appearance = appearance3;
            this.txtCollected.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCollected.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCollected.FormatString = "###,###.##";
            this.txtCollected.InputMask = "{LOC}nnnnnnn.nn";
            this.txtCollected.Location = new System.Drawing.Point(162, 65);
            this.txtCollected.Name = "txtRetail";
            this.txtCollected.PromptChar = ' ';
            this.txtCollected.Size = new System.Drawing.Size(176, 38);
            this.txtCollected.TabIndex = 2;
            this.txtCollected.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDiff
            // 
            this.txtDiff.AllowDrop = true;
            appearance4.FontData.SizeInPoints = 20F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            this.txtDiff.Appearance = appearance4;
            this.txtDiff.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDiff.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtDiff.InputMask = "{double:-6.4}";
            this.txtDiff.Location = new System.Drawing.Point(854, 65);
            this.txtDiff.Name = "txtRetail";
            this.txtDiff.PromptChar = ' ';
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(109, 38);
            this.txtDiff.TabIndex = 42;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            appearance5.FontData.SizeInPoints = 20F;
            this.txtDescription.Appearance = appearance5;
            this.txtDescription.Location = new System.Drawing.Point(344, 13);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(629, 38);
            this.txtDescription.TabIndex = 39;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtRetail
            // 
            this.txtRetail.AllowDrop = true;
            appearance6.FontData.SizeInPoints = 20F;
            appearance6.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance6;
            this.txtRetail.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(604, 65);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(118, 38);
            this.txtRetail.TabIndex = 41;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.Location = new System.Drawing.Point(116, 13);
            this.txtProductID.MaxLength = 12;
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(222, 38);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 38);
            this.label8.TabIndex = 37;
            this.label8.Text = "Received:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item:";
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance7.AlphaLevel = ((short)(95));
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance7;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(7, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(987, 690);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = " Order Detail ";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            this.Grid.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Appearance = appearance8;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance9.FontData.SizeInPoints = 20F;
            ultraGridColumn1.CellAppearance = appearance9;
            ultraGridColumn1.Header.Caption = "Item#";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 100;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance10.FontData.SizeInPoints = 20F;
            ultraGridColumn2.CellAppearance = appearance10;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MinLength = 35;
            ultraGridColumn2.MinWidth = 200;
            ultraGridColumn2.Width = 600;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance11.FontData.SizeInPoints = 20F;
            appearance11.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance11;
            ultraGridColumn3.Format = "$####.00";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nn";
            ultraGridColumn3.Width = 103;
            appearance12.FontData.SizeInPoints = 20F;
            appearance12.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance12;
            ultraGridColumn4.Header.Caption = "Qty";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.PromptChar = ' ';
            ultraGridColumn4.Width = 98;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid.DisplayLayout.Override.RowAlternateAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.DarkGray;
            appearance14.FontData.SizeInPoints = 15F;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance14;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(17, 32);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(957, 643);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.Grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            // 
            // frmCashRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1004, 876);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCashRegister";
            this.ShowIcon = true;
            this.Text = "Enter Orders";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
  		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            IDetail = new Order.Item();
            txtCollected.Enabled = false;
            oOrder.CustomerID = this.CustomerID;
            if (!oOrder.oCustomer.Find(this.CustomerID))
            {
                MessageBox.Show("Customer not found");
                Close();
            }
            oOrder.oCustomer.Brochures.Load(this.CompanyID, this.CustomerID);
		}
        private void bPrint_Click_1(object sender, EventArgs e)
        {
            

            String PrinterName = Global.OpenPrintDialog();
            if (PrinterName != "")
            {
                
                switch (PrinterName.ToUpper())
                {
                    case "\\\\SRV1\\PACKING":
                        {
                            oOrder.OpenPrinter(0);
                            break;
                        }
                    case "\\\\SRV1\\PACKING_2":
                        {
                            oOrder.OpenPrinter(1);
                            break;
                        }
                    case "\\\\SRV1\\PACKING_3":
                        {
                            oOrder.OpenPrinter(2);
                            break;
                        }
                    case "\\\\SRV1\\PACKING_4":
                        {
                            oOrder.OpenPrinter(3);
                            break;
                        }
                    case "\\\\SRV1\\WH_P5205":
                        {
                            oOrder.OpenPrinter(4);
                            break;
                        }
                    case "\\\\SRV1\\PLAIN":
                        {
                            oOrder.OpenPrinter(5);
                            break;
                        }
                    default:
                        MessageBox.Show("We can't print on this Printer!");
                        return;
                }
                this.Save();
                oOrder.Find(Convert.ToInt32(oOrder.ID));
                oOrder.Print();
                oOrder.ClosePrinter();    
                
            }
            
        }
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{ 
           
            #region txtProductID
            if (sender==txtProductID)	
			{
				
				if (e.KeyCode.ToString()=="F8")
				{
					this.Grid.Focus();
				}

				if (e.KeyCode.ToString()=="F2")
				{

					if (oOrder.oProduct.View(oOrder.oCustomer))
                    {
                        this.txtProductID.Text = oOrder.oProduct.ID;
                        return;
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text == "DONE")
                    {
                        txtProductID.Clear();
                        txtCollected.Enabled = true;
                        txtCollected.Focus();
                        return;
                    }
                    
                    
                    if ((txtProductID.Text.Length == 12 && oOrder.oProduct.FindByBarcode(txtProductID.Text)) || oOrder.oProduct.Find(txtProductID.Text))
                    {

                        Boolean HasBrochure = false;
                        foreach (BrochureByCustomer bc in oOrder.oCustomer.Brochures)
                        {
                            if (oOrder.oProduct.IsInBrochure(bc.BrochureID))
                            {
                                HasBrochure = true;
                                break;
                            }

                        }
                        if (!HasBrochure)
                        {
                            Global.playSimpleSound();
                            txtDescription.Text = "This Product Belongs to Other Brochure";
                            return;
                        }
                        
                        
                        this.IDetail.ProductID      = oOrder.oProduct.ID;
                        this.IDetail.Price          = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);    
                        this.IDetail.Description    = oOrder.oProduct.Description.ToString();
                        this.IDetail.Length         = oOrder.oProduct.Length;
                        this.IDetail.Width          = oOrder.oProduct.Width;
                        this.IDetail.Height         = oOrder.oProduct.Height;

                        this.txtProductID.Text = oOrder.oProduct.ID;
                        this.txtDescription.Text = oOrder.oProduct.Description;
                        

                        
                        AddItem();
                        ActiveRow();
                        txtProductID.Focus();
                    }
                    else
                    {
                        Global.playSimpleSound();   
                    }
                    this.txtProductID.Focus();
                    this.txtProductID.Clear();
                    return;
                }					

            }
            #endregion
            
            #region txtCollected
            if (sender == this.txtCollected)
            {
                
                if (oOrder.Collected != txtCollected.Number)
                {
                    oOrder.Collected = txtCollected.Number;
                    getTotals();
                }
                
                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Return)
                {
                    if (!oOrder.oCustomer.Find(CustomerID))
                    {
                        MessageBox.Show("Please enter a valid Customer ID/School ID ");
                        return;
                    }
                    
                    if (Math.Abs(oOrder.Diff) > 0 && !IsDiff)
                    {
                        Global.playSimpleSound();
                        IsDiff = true;
                        
                    }
                    else
                        IsDiff = false;

                    Save();
                    Clear();
                    txtCollected.Enabled = false;
                    txtProductID.Focus();
                    return;
                 }



             }
            #endregion
            
            #region Grid
             if (sender==this.Grid)	
			{
                if (e.KeyCode == Keys.Enter)
                {
                    if (Grid.ActiveRow != null)
                    {
                        if (Grid.ActiveCell != null)
                        {
                            if (!Grid.ActiveCell.IsInEditMode)
                            {
                                //' set ActiveCell
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                return;
                            }
                            else
                            {
                                Grid.PerformAction(UltraGridAction.ExitEditMode, true, true);
                                return;
                            }
                        }
                        else
                        {
                            Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                            Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            return;
                        }
                    }
                }

                if (e.KeyCode == Keys.Down)
                {
                    Grid.PerformAction(UltraGridAction.BelowRow, false, false);
                    return;
                }
                if (e.KeyCode == Keys.Up)
                {
                    Grid.PerformAction(UltraGridAction.AboveRow, false, false);
                    return;
                }


                 /*
                 if (e.KeyCode.ToString()=="Delete")
				{
					this.DeleteItem(false);
					return;
				}*/
                if (e.KeyCode.ToString() == "F8" )
				{
					this.txtProductID.Focus();
					return;
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
                    this.Grid.Focus();
                    break;
                case Keys.F5:
                    {
                        Clear();
                        txtProductID.Focus();
                    }

                    break;

                case Keys.F12:
                    {
                        oOrder.Find(oOrder.GetLastID());
                        ShowOrder();
                    }

                    break;
                case Keys.F3:
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    this.Save();
                    txtProductID.Clear();
                    txtCollected.Enabled = true;
                    txtCollected.Focus();
                    return;

					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        private void Grid_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            
            if (Convert.ToInt32(Grid.ActiveRow.Cells["Quantity"].Value.ToString()) == 0)
                this.DeleteItem(false);
            getTotals();
        }
        
        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (oOrder.oCustomer.Find(CustomerID))
                {
                    if (oOrder.oCustomer.HasChanged)
                        oOrder.oCustomer.GetCurrentTotalsByBrochure();
                }
            
        }
        private void bPrintImage_Click(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;
            this.Left = screens[0].Bounds.Width - this.Width - 20;

            //MessageBox.Show(oOrder.oImage.FilePath);
            Global.ClosePhotoGallery(oOrder.oImage.FilePath);
            //System.Diagnostics.Process.Start(@"C:\Program Files\Windows Photo Gallery\WindowsPhotoGallery.exe ",oOrder.oImage.FilePath);
            oOrder.oImage.FileType = "TIFF";
            System.Diagnostics.Process.Start(oOrder.oImage.FilePath,"");
        }
        #endregion

        #region  Methods
        private void ActiveRow()
        {
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {

                if (aUGRow.Cells["ProductID"].Value.ToString() == txtProductID.Text)
                {
                    Grid.ActiveRow = aUGRow;
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    
                    //Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.Blue;

                    break;
                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }
        private bool ShowOrder()
        {
            //if (oOrder.Find(Convert.ToInt32(oOrder.ID)))
            //    return false;

            this.ShowHeader();
            this.ShowDetail();
            return true;
        }
        
        private void Clear()
        {
          
            txtRetail.Clear();
            txtNoItems.Clear();
            txtDiff.Clear();
            txtCollected.Clear();
            
            
            if (Grid.Rows != null)
            {
                for (int x = Grid.Rows.Count; x != 0; x--)
                {
                    Grid.Rows[0].Delete(false);
                }
            }
            oOrder.Clear();
            oOrder.CustomerID = this.CustomerID; 
            oOrder.oCustomer.Find(this.CustomerID);
            oOrder.oCustomer.Brochures.Load(this.CompanyID, this.CustomerID);

        }
        private bool ShowHeader()
        {
            //Header
            
            txtRetail.Text = oOrder.Retail.ToString();
            txtNoItems.Text = oOrder.NoItems.ToString();
            txtCollected.Text = oOrder.Collected.ToString();
            txtDiff.Text = oOrder.Diff.ToString();
          
           return true;
        }
        private bool ShowDetail()
        {
            
            Grid.DataSource = oOrder.Items;
            Grid.DataBind();
            return true;
        }
        private void DeleteItem(Boolean IsAsk)
        {
            if (Grid.ActiveRow != null)
            {
                Grid.ActiveRow.Delete(IsAsk);
                this.getTotals();
            }
            return;
        }
        private bool IfExist()
        {
            bool Exist = false;
            if (oOrder.Items.ContainsKey(this.IDetail.ProductID))
                  Exist = true;
            return Exist;
        }
        private void AddItem()
        {

            this.IDetail.Quantity = 1;

                Order.Item item = new Order.Item();
                item.ProductID = this.IDetail.ProductID;
                item.Description = this.IDetail.Description;
                item.Price = this.IDetail.Price;
              
                    
                item.Length = this.IDetail.Length;
                item.Width = this.IDetail.Width;
                item.Height = this.IDetail.Height;

                if (!IfExist())
                {
                    item.Quantity = this.IDetail.Quantity;
                    oOrder.Items.Add(this.IDetail.ProductID, item);
                }
                else
                {
                    oOrder.Items[this.IDetail.ProductID].Quantity += this.IDetail.Quantity;
                }
                
                ShowDetail();
                this.getTotals();
                ActiveRow();
                txtProductID.Focus();
                

            return;
        }
        private void Save()
        {

            getTotals();
            oOrder.CompanyID    = CompanyID;
            oOrder.CustomerID   = CustomerID;
            oOrder.Teacher      = oMySql.SqlDate(DateTime.Now);
            oOrder.Student      = oMySql.SqlTimeDate(DateTime.Now);
            oOrder.Collected    = oOrder.Retail;
            

            oOrder.Save();
            
        }
        private void getTotals()
        {
            
            oOrder.GetTotals();
            ShowHeader();
     
            return;
        }
        private void deleteOrder()
        {

            if (MessageBox.Show("Do you really want to Delete this Order?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Operation Cancelled");
                return;
            }

            oOrder.Delete();
            oOrder.DeleteItems();
            Clear();
            
            return;
        }
        private void Shortage()
        {
            frmShortage frm = new frmShortage(oOrder);
           
            frm.ShowDialog();
        }


		#endregion

        

        

	}
}
