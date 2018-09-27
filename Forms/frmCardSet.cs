using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmCardSet : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtRangeStart;
        private Label label9;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Button bCancel;
        private Button bSubmit;
        private Signature.Windows.Forms.MaskedEdit txtCardSetID;
        private Label label1;
        private Label label3;
        private Signature.Windows.Forms.MaskedEdit txtRangeEnd;
        private Signature.Windows.Forms.MaskedEdit txtAmount;
        private Label label2;
		#endregion
        
        private     Vendor      oVendor;
        private     CardSet     oCardSet;
        private     UltraGrid   Grid;
        private     UltraGrid   GridDetail;
        private     Product     oProduct;
        
        

        public frmCardSet()
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CardNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCredit", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsedCredit", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OverAmount", 2);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reference");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Date", 2, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 3);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRangeEnd = new Signature.Windows.Forms.MaskedEdit();
            this.txtAmount = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardSetID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRangeStart = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.GridDetail = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 694);
            this.txtStatus.Size = new System.Drawing.Size(633, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtRangeEnd);
            this.ultraGroupBox1.Controls.Add(this.txtAmount);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtCardSetID);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtRangeStart);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 1);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(621, 95);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(465, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRangeEnd
            // 
            this.txtRangeEnd.AllowDrop = true;
            this.txtRangeEnd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtRangeEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRangeEnd.Location = new System.Drawing.Point(500, 58);
            this.txtRangeEnd.Name = "txtCustomerID";
            this.txtRangeEnd.Size = new System.Drawing.Size(102, 20);
            this.txtRangeEnd.TabIndex = 14;
            // 
            // txtAmount
            // 
            this.txtAmount.AllowDrop = true;
            this.txtAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(129, 58);
            this.txtAmount.Name = "txtCustomerID";
            this.txtAmount.Size = new System.Drawing.Size(102, 20);
            this.txtAmount.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(49, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Amount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCardSetID
            // 
            this.txtCardSetID.AllowDrop = true;
            this.txtCardSetID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCardSetID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardSetID.Location = new System.Drawing.Point(129, 25);
            this.txtCardSetID.Name = "txtCustomerID";
            this.txtCardSetID.Size = new System.Drawing.Size(102, 20);
            this.txtCardSetID.TabIndex = 0;
            this.txtCardSetID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Card Set #:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRangeStart
            // 
            this.txtRangeStart.AllowDrop = true;
            this.txtRangeStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtRangeStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRangeStart.Location = new System.Drawing.Point(357, 58);
            this.txtRangeStart.Name = "txtCustomerID";
            this.txtRangeStart.Size = new System.Drawing.Size(102, 20);
            this.txtRangeStart.TabIndex = 1;
            this.txtRangeStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(277, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Range:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.Grid);
            this.ultraGroupBox2.Controls.Add(this.bSubmit);
            this.ultraGroupBox2.Controls.Add(this.bCancel);
            this.ultraGroupBox2.Controls.Add(this.GridDetail);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 102);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(621, 583);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.Header.Caption = "Card Number";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn1.Width = 141;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn2.MaskInput = "{LOC}nnnnnnn.nnn";
            ultraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn2.Width = 153;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Format = "";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nnn";
            ultraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn3.Width = 156;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn4.MaskInput = "{LOC}nnnnnnn.nnn";
            ultraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn4.Width = 142;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance5;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "Arial";
            appearance6.FontData.SizeInPoints = 10F;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance7;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(6, 10);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(609, 379);
            this.Grid.TabIndex = 16;
            this.Grid.Enter += new System.EventHandler(this.Grid_Enter);
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Grid_MouseUp);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // bSubmit
            // 
            this.bSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.bSubmit.Location = new System.Drawing.Point(399, 545);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Visible = false;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancel.Location = new System.Drawing.Point(215, 545);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // GridDetail
            // 
            appearance9.BackColor = System.Drawing.Color.White;
            this.GridDetail.DisplayLayout.Appearance = appearance9;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 103;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "Item ID";
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridColumn6.Width = 92;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Format = "";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.MaskInput = "";
            ultraGridColumn7.Width = 83;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Width = 135;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 1;
            ultraGridColumn9.Width = 321;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.GridDetail.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.GridDetail.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.GridDetail.DisplayLayout.GroupByBox.Hidden = true;
            this.GridDetail.DisplayLayout.MaxColScrollRegions = 1;
            this.GridDetail.DisplayLayout.MaxRowScrollRegions = 1;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.GridDetail.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.GridDetail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.FontData.BoldAsString = "True";
            appearance11.FontData.Name = "Arial";
            appearance11.FontData.SizeInPoints = 10F;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.GridDetail.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.GridDetail.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.GridDetail.DisplayLayout.Override.RowSelectorAppearance = appearance12;
            this.GridDetail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.GridDetail.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.GridDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.GridDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.GridDetail.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.GridDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridDetail.Location = new System.Drawing.Point(6, 395);
            this.GridDetail.Name = "GridDetail";
            this.GridDetail.Size = new System.Drawing.Size(609, 132);
            this.GridDetail.TabIndex = 17;
            // 
            // frmCardSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(633, 723);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCardSet";
            this.ShowInTaskbar = false;
            this.Text = "Card Set WLOT";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetail)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		
		private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{

            oVendor = new Vendor(CompanyID);
            oCardSet = new CardSet(CompanyID);
            oProduct = new Product(CompanyID);
            
            this.Text += " - " + this.CompanyID;
            this.txtCardSetID.Text = "";
           // this.txtCardSetID.Text = oCardSet.GetNextNumber();
            this.txtCardSetID.Focus();
                        
            txtRangeStart.Enabled = false;
            Grid.Height = 529;
            

            //oVendor.ReOrders.SetColumns();
            //Grid.DataSource = oVendor.ReOrders.GetDataTable();
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //MessageBox.Show(e.KeyCode.ToString());
            #region Grid
            if (sender == Grid )
            {
                if (e.KeyCode == Keys.F3)
                {
                    deleteOrder();
                    Clear();
                    txtCardSetID.Enabled = true;
                    txtCardSetID.Focus();
                    return;
                }
                
                if (Grid.ActiveRow != null)
                {
                    if (e.KeyCode == Keys.Delete)
                        if (e.Shift && Grid.GetRow(ChildRow.Last) != Grid.ActiveRow)
                        {
                            Grid.ActiveRow.Delete();
                            MoveLast();
                            return;
                        }
                                


                    switch (Grid.ActiveCell.Column.Key)
                    {
                        case "ProductID":
                            {
                                if (e.KeyCode == Keys.F2)
                                {
                                    if (oProduct.View())
                                    {
                                        Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                        Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                        Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                        Grid.ActiveRow.Cells["Price"].Value = oProduct.Cost;
                                        Grid.ActiveRow.Cells["Cases"].Activate();
                                        Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    }

                                }
                                if (e.KeyCode == Keys.Return)
                                {
                                    if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text)) //(!oCardSet.Items.Contains(Grid.ActiveRow.Cells["ProductID"].Text))
                                    {

                                        if (oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                                        {
                                            Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                            Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                            Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                            Grid.ActiveRow.Cells["Price"].Value = oProduct.Cost;

                                            Grid.ActiveRow.Cells["Cases"].Activate();
                                            Grid.ActiveCell = Grid.ActiveRow.Cells["Cases"];
                                            Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                        }

                                    }
                                    else
                                    {
                                        
                                        MessageBox.Show("Item already entered");
                                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                        return;
                                    }
                                }
                                if (e.KeyCode == Keys.Down)
                                {
                                    Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Up)
                                {
                                    
                                    Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Right)
                                {

                                    Grid.PerformAction(UltraGridAction.NextCellByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["Cases"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }

                            }

                            break;
                        case "Cases":

                            if (e.KeyCode == Keys.Return)
                            {

                                Grid.ActiveRow.Cells["Units"].Activate();
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Right)
                            {

                                Grid.PerformAction(UltraGridAction.NextCellByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Units"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Left)
                            {

                                Grid.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            break;
                        case "Units":
                            if (e.KeyCode == Keys.Return)
                            {
                                if (Grid.ActiveRow.Cells["ProductID"].Text != "" && !Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {
                                                                        
                                    if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                                    {
                                       // oCardSet.Items.AddEmpty();
                                        Grid.DataBind();
                                        MoveLast();
                                        //Grid.PerformAction(UltraGridAction.LastRowInBand, false, false);
                                    }
                                    else
                                    {
                                        Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                        Grid.ActiveRow.Cells["ProductID"].Activate();
                                        Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    }



                                }
                                else
                                {
                                    Grid.ActiveRow.Cells["ProductID"].Activate();
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    Grid.ActiveRow.Cells["Units"].Value = 0;
                                }
                                return;
                            }
                            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                            {
                                Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Units"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Up)
                            {
                                Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Units"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Left)
                            {

                                Grid.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Cases"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            break;
                        default:
                            {
                                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                                {
                                    Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                    //Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Up)
                                {
                                    Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                    //Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }

                                

                               
                            }
                            break;
                    }
                }
                return;
            }
            #endregion

            #region txtCardSetID
            if (sender == txtCardSetID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oCardSet.View())
                    {


                        txtCardSetID.Text = oCardSet.CardsetID;
                        txtRangeStart.Text = oCardSet.RangeStart.ToString();
                        txtRangeEnd.Text = oCardSet.RangeEnd.ToString();
                        txtAmount.Text = oCardSet.TotalCredit.ToString();
                        
                        Grid.DataSource = oCardSet.Items;
                        Grid.DataBind();
                        GridDetail.DataSource = GetDetail();
                        return;
                        

                    }else
                        Grid.Height = 529;
                    
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtCardSetID.Text.Trim() == "")
                    {
                        txtCardSetID.Clear();
                        txtCardSetID.Focus();
                        return;
                    }

                    if (oCardSet.Find(txtCardSetID.Text))
                    {


                        txtCardSetID.Text = oCardSet.CardsetID;
                        txtRangeStart.Text = oCardSet.RangeStart.ToString();
                        txtRangeEnd.Text = oCardSet.RangeEnd.ToString();
                        txtAmount.Text = oCardSet.TotalCredit.ToString();

                        Grid.DataSource = oCardSet.Items;
                       // Grid.DataSource = oCardSet.Items.dtItems; //oCardSet.Items;
                      //  MoveLast();

                        txtCardSetID.Enabled = false;
                        return;
                    }
                    else
                    {
                        Grid.Height = 529;
                        txtRangeStart.Enabled = true;
                        txtRangeStart.Focus();
                        
                        return;
                    }

                }

            }
            #endregion

            #region txtRangeStart
            if (sender==txtRangeStart)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    if (oVendor.View())
                    {
                        this.txtRangeStart.Text = oVendor.ID;
                        if (!oVendor.Find(txtRangeStart.Text))
                        {

                            this.txtRangeStart.Focus();
                            return;
                        }
                        
                       // oCardSet.Items.Load(CompanyID, txtCardSetID.Text);
                       // Grid.DataSource = oCardSet.Items.dtItems;
                        Grid.Focus();
                        return;
                        
                     }
                    
                    
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!oVendor.Find(txtRangeStart.Text))
					{
                        
                        this.txtRangeStart.Focus();
						return;
					}
                   

                   // oCardSet.Items.Load(CompanyID, txtCardSetID.Text);
                   // Grid.DataSource = oCardSet.Items.dtItems;
                    Grid.Focus();
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
                case Keys.F3:
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    break;
                case Keys.Delete:
                    if (!e.Control)
                        Grid.ActiveRow.Delete();
                    break; 


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        private void bPrint_Click(object sender, EventArgs e)
        {

            frmViewReport oViewReport = new frmViewReport();
            oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtRangeStart.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
           // oCardSet.ID = txtCardSetID.Text;
           // oCardSet.VendID = txtRangeStart.Text;
            oCardSet.Save();
            Clear();
           // txtCardSetID.Text = oCardSet.GetNextNumber();
            txtCardSetID.Enabled = true;
            txtCardSetID.Focus();
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
                
                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }

                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Up)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }

                //SendKeys.Send("{TAB}");
            }
            
        }

        #endregion

        #region  Methods
        public void Clear()
        {
            txtCardSetID.Clear();
            txtRangeStart.Clear();
            Grid.Rows.Dispose();
            
            
        }
        public DataTable GetDetail()
        {
          return oMySql.GetDataTable(String.Format("SELECT r.Reference, pd.ProductID, p.Description,  rd.Quantity, r.Date FROM ReceiveDetail pd  Left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Left Join ReceiveDetail rd on pd.CompanyID=rd.CompanyID and pd.ProductID=rd.ProductID  Left Join Receive r on rd.CompanyID=r.CompanyID and rd.PurchaseID=r.PurchaseID  and rd.ReceiveID=r.ReceiveID Where pd.CompanyID='"+CompanyID+"' And pd.Quantity is not null and pd.PurchaseID='{0}' Order By  pd.ProductID", txtCardSetID.Text), "tmp");
        }
        public void deleteOrder()
        {

            if (MessageBox.Show("Do you really want to Delete this Purchase Order?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Operation Cancelled");
                return;
            }
            oCardSet.Delete();

            return;
        }
        public void MoveLast()
        {
            return;
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.Rows[0];
            gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Last);
            if (gridRow != null)
            {

                gridRow.Activate();
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }


        }
		#endregion


        private void Grid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /*
            //' declare objects to get value from cell and display
            Infragistics.Win.UIElement mouseupUIElement;
            Infragistics.Win.UltraWinGrid.UltraGridCell mouseupCell;

            //' retrieve the UIElement from the location of the MouseUp
            mouseupUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
            if (mouseupUIElement == null)
                return;

            //' retrieve the Cell from the UIElement
            mouseupCell = mouseupUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell))
                as Infragistics.Win.UltraWinGrid.UltraGridCell; ;

            //' if there is a cell object reference, set to active cell and edit
            if ((mouseupCell == null))
                return;


            //MessageBox.Show();
            if (Grid.ActiveRow != null)
            {
                mouseupCell.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
            }   
            */

        }
        private void Grid_MouseUp1(object sender, MouseEventArgs e)
        {

            
            //' declare and retrieve a reference to the UIElement
            Infragistics.Win.UIElement aUIElement;

               aUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = aUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow)) as Infragistics.Win.UltraWinGrid.UltraGridRow;
            

            if (gridRow != null)
            {
                gridRow.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
            }
            

        }
        private void Grid_AfterCellActivate(object sender, EventArgs e)
        {
            //' declare and retrieve a reference to the UIElement
            

            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.ActiveRow;

            if (gridRow != null)
            {
                //gridRow.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }
        }
        private void Grid_Enter(object sender, EventArgs e)
        {
            /*
            if (Grid.Rows.Count > 0)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.Rows[0];
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }
            else
                txtRangeStart.Focus();
            */
        }

        private Boolean Contain(String Text)
        {

            UltraGridRow Row = Grid.ActiveRow;

            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
          //      MessageBox.Show(aUGRow.Cells["ProductID"].Text + Text);
                if (aUGRow.Cells["ProductID"].Text == Text)
                {

                    if (Row == aUGRow)
                        return false;
                    else
                        return true;
                }     
            }

            return false;
        }

	}


}
