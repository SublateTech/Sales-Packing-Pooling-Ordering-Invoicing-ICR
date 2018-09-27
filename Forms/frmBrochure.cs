

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
	public sealed class frmBrochure : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID;
        private Signature.Windows.Forms.MaskedEdit txtDescription;
        private Label label1;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private UltraGrid Grid;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label4;
        private Signature.Windows.Forms.MaskedLabel txtPDescription;
        #endregion

        
        Brochure  oBrochure;
        private Signature.Windows.Forms.MaskedEdit txtProductTypeID;
        private Label label2;
        Product oProduct;
        private Signature.Windows.Forms.MaskedLabel txtPTDescription;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbAskForPhone;
        Pack oPack;

        
        public frmBrochure()
		{
			InitializeComponent();
            Global.ShowNotifier("To Delete an item please \r\n"+
                                "press Ctl+Delete keys");
        
		}
        
  	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InvCode", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Forecast", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Excluded", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PriceDist", 5);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(822);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-7);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrochure));
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.cbAskForPhone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtPTDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductTypeID = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrochureID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 699);
            this.txtStatus.Size = new System.Drawing.Size(850, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.cbAskForPhone);
            this.groupBox2.Controls.Add(this.txtPTDescription);
            this.groupBox2.Controls.Add(this.txtProductTypeID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPDescription);
            this.groupBox2.Controls.Add(this.txtProductID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtBrochureID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 157);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbAskForPhone
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            appearance27.BackColor2 = System.Drawing.Color.Transparent;
            appearance27.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.White;
            this.cbAskForPhone.Appearance = appearance27;
            this.cbAskForPhone.BackColor = System.Drawing.Color.Transparent;
            this.cbAskForPhone.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbAskForPhone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAskForPhone.Location = new System.Drawing.Point(19, 119);
            this.cbAskForPhone.Name = "cbAskForPhone";
            this.cbAskForPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAskForPhone.Size = new System.Drawing.Size(190, 19);
            this.cbAskForPhone.TabIndex = 245;
            this.cbAskForPhone.Text = "Ask For Phone:";
            this.cbAskForPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPTDescription
            // 
            this.txtPTDescription.AllowDrop = true;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.txtPTDescription.Appearance = appearance2;
            this.txtPTDescription.Location = new System.Drawing.Point(233, 68);
            this.txtPTDescription.Name = "txtDescription";
            this.txtPTDescription.Size = new System.Drawing.Size(315, 23);
            this.txtPTDescription.TabIndex = 42;
            this.txtPTDescription.TabStop = true;
            this.txtPTDescription.Value = null;
            // 
            // txtProductTypeID
            // 
            this.txtProductTypeID.AllowDrop = true;
            this.txtProductTypeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductTypeID.Location = new System.Drawing.Point(129, 66);
            this.txtProductTypeID.Name = "txtCustomerID";
            this.txtProductTypeID.Size = new System.Drawing.Size(80, 20);
            this.txtProductTypeID.TabIndex = 42;
            this.txtProductTypeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Product Type ID:";
            // 
            // txtPDescription
            // 
            this.txtPDescription.AllowDrop = true;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.txtPDescription.Appearance = appearance3;
            this.txtPDescription.Location = new System.Drawing.Point(230, 92);
            this.txtPDescription.Name = "txtDescription";
            this.txtPDescription.Size = new System.Drawing.Size(315, 23);
            this.txtPDescription.TabIndex = 41;
            this.txtPDescription.TabStop = true;
            this.txtPDescription.Value = null;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(129, 92);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 30;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(16, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Product ID:";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Location = new System.Drawing.Point(305, 28);
            this.txtDescription.Name = "txtCustomerID";
            this.txtDescription.Size = new System.Drawing.Size(304, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(227, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Description:";
            // 
            // txtBrochureID
            // 
            this.txtBrochureID.AllowDrop = true;
            this.txtBrochureID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrochureID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureID.Location = new System.Drawing.Point(129, 28);
            this.txtBrochureID.Name = "txtCustomerID";
            this.txtBrochureID.Size = new System.Drawing.Size(80, 20);
            this.txtBrochureID.TabIndex = 0;
            this.txtBrochureID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Brochure ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance4.AlphaLevel = ((short)(95));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance4;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(833, 512);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.Text = "Brochure Detail";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.Grid.DisplayLayout.AddNewBox.Appearance = appearance5;
            this.Grid.DisplayLayout.AddNewBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance6.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            appearance6.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance6.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.AddNewBox.ButtonAppearance = appearance6;
            this.Grid.DisplayLayout.AddNewBox.ButtonConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.Grid.DisplayLayout.AddNewBox.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance7.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance7;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 66;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 77;
            ultraGridColumn3.DataType = typeof(double);
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.MaskInput = "{double:6.2}";
            ultraGridColumn3.Width = 71;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.Width = 280;
            ultraGridColumn5.DataType = typeof(double);
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.MaskInput = "{double:6.3}";
            ultraGridColumn5.Width = 94;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.DataType = typeof(double);
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn7.MaskInput = "{double:6.3}";
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand1.Header.Caption = "";
            ultraGridBand1.Header.Enabled = false;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance8.FontData.Name = "Trebuchet MS";
            appearance8.FontData.SizeInPoints = 9F;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Right";
            this.Grid.DisplayLayout.CaptionAppearance = appearance8;
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            this.Grid.DisplayLayout.FixedHeaderOffImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedHeaderOffImage")));
            this.Grid.DisplayLayout.FixedHeaderOnImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedHeaderOnImage")));
            this.Grid.DisplayLayout.FixedRowOffImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedRowOffImage")));
            this.Grid.DisplayLayout.FixedRowOnImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedRowOnImage")));
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Trebuchet MS";
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(127)))), ((int)(((byte)(177)))));
            appearance9.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 3);
            appearance9.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.GroupByBox.Appearance = appearance9;
            this.Grid.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Transparent;
            appearance11.FontData.Name = "Verdana";
            this.Grid.DisplayLayout.Override.CellAppearance = appearance11;
            appearance12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance12.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance12.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.Override.CellButtonAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.Grid.DisplayLayout.Override.FilterCellAppearance = appearance13;
            appearance14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance14.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            this.Grid.DisplayLayout.Override.FilterClearButtonAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            appearance15.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.Grid.DisplayLayout.Override.FilterRowPromptAppearance = appearance15;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance16.FontData.BoldAsString = "True";
            appearance16.FontData.Name = "Trebuchet MS";
            appearance16.FontData.SizeInPoints = 10F;
            appearance16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance16.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance16.TextHAlignAsString = "Left";
            appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance17.BorderColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            appearance19.BorderColor = System.Drawing.Color.Transparent;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedCellAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Transparent;
            appearance20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance20.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4);
            appearance20.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance21.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 4, 2, 4);
            appearance21.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.Appearance = appearance21;
            appearance22.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance22.ImageBackground")));
            appearance22.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(3, 2, 3, 2);
            scrollBarLook1.AppearanceHorizontal = appearance22;
            appearance23.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance23.ImageBackground")));
            appearance23.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 3, 2, 3);
            appearance23.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.AppearanceVertical = appearance23;
            appearance24.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance24.ImageBackground")));
            appearance24.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 1);
            scrollBarLook1.TrackAppearanceHorizontal = appearance24;
            appearance25.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 0, 1, 0);
            appearance25.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.TrackAppearanceVertical = appearance25;
            this.Grid.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Grid.Location = new System.Drawing.Point(3, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(824, 487);
            this.Grid.TabIndex = 31;
            this.Grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Grid_MouseUp);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // frmBrochure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(850, 728);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBrochure";
            this.ShowInTaskbar = false;
            this.Text = "Brochure/Item Maintenance";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		private void SelectNextControl(object sender, System.Windows.Forms.KeyEventArgs e) 
		{
            switch (e.KeyCode) 
			{ 
				case Keys.Return: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 

					//case Keys.<some key>: 
					// ......; 
					// break; 
			} 
		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oBrochure = new Brochure(this.CompanyID);
            oProduct = new Product(this.CompanyID);
            oPack = new Pack(this.CompanyID);
            this.txtBrochureID.Focus();
           
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtBrochureID
            if (sender==txtBrochureID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oBrochure.View())
                    {
                        ShowVendor();
                    }

                    if (txtBrochureID.Text == "")
                        return;
                    
                    txtDescription.Focus();
                    Grid.DataSource = oBrochure.Items.dtItems;
                    Grid.DataBind();
                        Grid.Focus();
                        MoveLast();
                        return;
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtBrochureID.Focus();
                    }

                    if (oBrochure.Find(txtBrochureID.Text))
                    {
                        ShowVendor();
                        Grid.DataSource = oBrochure.Items.dtItems;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();

                    }
                    else
                    {
                        Clear();
                        oBrochure.ID = txtBrochureID.Text;
                        oBrochure.Items.AddEmpty();
                        Grid.DataSource = oBrochure.Items.dtItems;
                        Grid.DataBind();
                        txtDescription.Focus();
                    }
                    
                        
                        return;
                    
                    

                }					

            }
            #endregion
            #region txtDescription
            if (sender==txtDescription)	
			{
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    oBrochure.Description = txtDescription.Text;
                    Grid.Focus();
                    MoveLast();
                    return;
                }
            }
            #endregion
            #region Grid

            if (sender ==Grid)
            {

                
                if (e.KeyCode == Keys.F2)
                {
                    UltraGridRow gridRow;
                    gridRow = Grid.ActiveRow;
                    if (gridRow != null)
                    {
                        if (Grid.ActiveRow.Cells["ProductID"] == Grid.ActiveCell)
                        {
                            if (oProduct.View())
                            {
                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {

                                    Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                    Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                    Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                    Grid.ActiveRow.Cells["Price"].Activate();
                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Item already entered");
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                    return;
                                }
                            }
                        }
                    }
                }
                
                
                if (e.KeyCode == Keys.Delete)
                {
                }


                if (e.KeyCode == Keys.Enter)
                {
                            if (Grid.ActiveRow.Cells["ProductID"].Text != "" && !Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {
                                     if (Grid.ActiveRow.Cells["ProductID"] == Grid.ActiveCell)
                                        {
                                            if (oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                                            {
                                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                                {

                                                    Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                                    Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                                    Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                                    Grid.ActiveRow.Cells["Price"].Activate();
                                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                                    return;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Item already entered");
                                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                                    return;
                                                }
                                            }
                                        }
                                     else if (Grid.ActiveRow.Cells["Price"] == Grid.ActiveCell)
                                     {
                                         Grid.ActiveRow.Cells["PriceDist"].Activate();
                                         Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                         return;
                                     }
                                     
                                        else if (Grid.ActiveRow.Cells["PriceDist"] == Grid.ActiveCell)
                                        {
                                            Grid.ActiveRow.Cells["Forecast"].Activate();
                                            Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                            return;
                                        }
                                                                         
                                        if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                                        {

                                            oBrochure.Items.AddEmpty();
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
                                    Grid.ActiveRow.Cells["Price"].Value = 0;
                                }
                                return;
                    
                    
                    
                }
                
                if (e.KeyCode == Keys.Down )
                {

                    MoveDown();
                    return;
        
                    
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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                    //SendKeys.Send("{TAB}");
                }
                

            }
            #endregion
            #region txtProductID
            if (sender == txtProductID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {
                        txtProductID.Text = oProduct.ID;
                        txtPDescription.Text = oProduct.Description;
                        
                    }

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
                        txtPDescription.Text = oProduct.Description;
                        
                    }

                }

            }
            #endregion
            #region txtProductTypeID
            if (sender == txtProductTypeID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oPack.View())
                    {
                        txtProductTypeID.Text = oPack.ID;
                        txtPTDescription.Text = oPack.Description;

                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductTypeID.Text.Trim().Length == 0)
                    {
                        txtProductTypeID.Focus();
                    }

                    if (oPack.Find(txtProductTypeID.Text))
                    {
                        txtProductTypeID.Text = oPack.ID;
                        txtPTDescription.Text = oPack.Description;

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
                case Keys.F3:
                    if (MessageBox.Show("Do you really want to Delete this Brochure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        MessageBox.Show("Operation Cancelled");
                        return;
                    }
                    oBrochure.Delete();
                    Grid.DataBind();
                    Clear();
                    txtBrochureID.Clear();
                    txtBrochureID.Focus();

                    break;
                case Keys.PageDown:
                    this.Save();
                    Grid.DataBind();
                    Clear();
                    txtBrochureID.Clear();
                    txtBrochureID.Focus();
                    break;
                case Keys.Delete:
                    if (e.Control)
                        DeleteItem();
                    break;
					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        
        
        private void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.None;
            /*e.Layout.Bands(0).Columns("CurrencyValue").Format = "$#,##0.00"
            e.Layout.Bands(0).Columns("DateValue1").Format = "d" ' this line works
            e.Layout.Bands(0).Columns("DateValue2").Format = "hh:mm:ss"*/
        }
        private void Grid_MouseUp(object sender, MouseEventArgs e)
        {
            //' declare objects to get value from cell and display
            Infragistics.Win.UIElement mouseupUIElement;
            Infragistics.Win.UltraWinGrid.UltraGridCell mouseupCell;

            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {

                //' retrieve the UIElement from the location of the MouseUp
                mouseupUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

                //' retrieve the Cell from the UIElement
                mouseupCell = mouseupUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell))
                    as Infragistics.Win.UltraWinGrid.UltraGridCell; ;

                //' if there is a cell object reference, set to active cell and edit
                if (!(mouseupCell == null))
                {
                    UltraGridRow aUGRow;
                    Grid.ActiveCell = mouseupCell;

                    aUGRow = Grid.ActiveCell.Row;
                    Grid.ActiveRow = aUGRow;

                    if (Grid.ActiveCell == aUGRow.Cells["Excluded"])
                        MoveDown();
                    
                   // Grid.ActiveCell = aUGRow.Cells["Quantity"];

                    

                  //  Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                }

            }

        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow aUGRow;
            if (Grid.ActiveCell != null)
            {
                aUGRow = Grid.ActiveCell.Row;
                Grid.ActiveCell.Row.Delete();
            }

        }

        #endregion
        
        #region  Methods
        public void MoveDown()
        {
                   Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = Grid.ActiveRow;
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                    if (gridRow != null)
                    {
                        gridRow.Activate();
                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }


        }
        public void Save()
        {
            oBrochure.ID          = txtBrochureID.Text;
            oBrochure.Description = txtDescription.Text;
            oBrochure.ProductID   = txtProductID.Text;
            oBrochure.PackID      = txtProductTypeID.Text;
            oBrochure.IsCookieDough = cbAskForPhone.Checked;

            oBrochure.Save();
            Clear();
            txtBrochureID.Clear();

        }
        public bool ShowVendor()
        {
            Clear();
            txtDescription.Text = oBrochure.Description;
            txtBrochureID.Text = oBrochure.ID;
            txtProductID.Text = oBrochure.ProductID;
            txtProductTypeID.Text = oBrochure.PackID;
            cbAskForPhone.Checked = oBrochure.IsCookieDough;
            if (oProduct.Find(oBrochure.ProductID))
                txtPDescription.Text = oProduct.Description;
            if (oPack.Find(oBrochure.PackID))
                txtPTDescription.Text = oPack.Description;
            return true;
        }
        public void Clear()
        {
            //Grid.Rows.Dispose();
            txtDescription.Clear();
            txtProductID.Text = String.Empty;
            txtPDescription.Text = String.Empty;
            txtProductTypeID.Text = String.Empty;
            txtPTDescription.Text = String.Empty;
            cbAskForPhone.Checked = false;

            //oBrochure.Items.dtItems.Rows.Clear();
            //Grid.DataBind();

        }
        public void MoveLast()
        {
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
        private void DeleteItem()
        {
            UltraGridRow aUGRow;
            if (Grid.ActiveCell != null)
            {
                aUGRow = Grid.ActiveCell.Row;
                Grid.ActiveCell.Row.Delete();
            }

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
		#endregion

	}
}
