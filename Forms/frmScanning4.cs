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
	public sealed class frmScanning4 : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Signature.Windows.Forms.GroupBox groupBox3;
        private Signature.Windows.Forms.GroupBox groupBox4;
		
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Label label4;
        private Signature.Windows.Forms.MaskedEditNumeric txtPallets;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label3;
        private Label txtBox;
        private Label txtMessage;
        private Signature.Windows.Forms.MaskedEdit txtOrderID;
        internal Label lBrochure;
        private Signature.Windows.Forms.ComboBox txtBrochure;
		#endregion

        Scanning oOrder;
        Scanning oOrder1;
        Customer oCustomer;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
     
        private String          BrochureID = "";
        private Button          button1;
        private frmTimerMessage ofrmMessage;
        private BackDeamon      oDeamon = new BackDeamon();
        public frmScanning4()
        {
            InitializeComponent();
            oOrder = new Scanning(base.CompanyID);
            oOrder1 = new Scanning(base.CompanyID);
            txtBrochure.Visible = false;
            lBrochure.Visible = false;
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Teacher");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Student", 0);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packed", 1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Scanned", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OrderID", 3);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
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
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.lBrochure = new System.Windows.Forms.Label();
            this.txtBrochure = new Signature.Windows.Forms.ComboBox();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.txtBox = new System.Windows.Forms.Label();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox4 = new Signature.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEdit();
            this.txtPallets = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 661);
            this.txtStatus.Size = new System.Drawing.Size(889, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.lBrochure);
            this.groupBox2.Controls.Add(this.txtBrochure);
            this.groupBox2.Controls.Add(this.txtCustomerID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(876, 73);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.Text = "Customer Info";
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lBrochure
            // 
            this.lBrochure.BackColor = System.Drawing.Color.Transparent;
            this.lBrochure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBrochure.Location = new System.Drawing.Point(11, 49);
            this.lBrochure.Name = "lBrochure";
            this.lBrochure.Size = new System.Drawing.Size(74, 16);
            this.lBrochure.TabIndex = 260;
            this.lBrochure.Text = "Brochure :";
            this.lBrochure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBrochure
            // 
            this.txtBrochure.AllowDrop = true;
            this.txtBrochure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBrochure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtBrochure.Location = new System.Drawing.Point(90, 44);
            this.txtBrochure.Name = "txtCollect";
            this.txtBrochure.Size = new System.Drawing.Size(202, 21);
            this.txtBrochure.TabIndex = 259;
            this.txtBrochure.SelectedIndexChanged += new System.EventHandler(this.txtBrochure_SelectedIndexChanged);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(90, 18);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(83, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Customer ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.SizeInPoints = 15F;
            this.txtName.Appearance = appearance2;
            this.txtName.Location = new System.Drawing.Point(193, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(440, 22);
            this.txtName.TabIndex = 12;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(99, 41);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(390, 21);
            this.txtStudent.TabIndex = 2;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(99, 17);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(390, 21);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(33, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Order ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(90));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance3;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.txtBox);
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.Controls.Add(this.txtStudent);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTeacher);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 491);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = " Orders Left";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtBox
            // 
            this.txtBox.BackColor = System.Drawing.Color.Transparent;
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox.ForeColor = System.Drawing.Color.Red;
            this.txtBox.Location = new System.Drawing.Point(507, 22);
            this.txtBox.Name = "txtBox";
            this.txtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBox.Size = new System.Drawing.Size(201, 36);
            this.txtBox.TabIndex = 9;
            this.txtBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.Grid.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance5.FontData.SizeInPoints = 12F;
            ultraGridColumn1.CellAppearance = appearance5;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(242, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn1.Width = 190;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance6.FontData.SizeInPoints = 12F;
            ultraGridColumn2.CellAppearance = appearance6;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MaskInput = "";
            ultraGridColumn2.MaxLength = 30;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(251, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn2.Width = 190;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance7.FontData.SizeInPoints = 12F;
            ultraGridColumn3.CellAppearance = appearance7;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "nnnnnnnnn";
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 9;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(112, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Width = 50;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            appearance8.FontData.SizeInPoints = 20F;
            ultraGridBand1.Header.Appearance = appearance8;
            ultraGridBand1.UseRowLayout = true;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.GroupByBox.Appearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance10;
            this.Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance11.BackColor2 = System.Drawing.SystemColors.Control;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance11;
            this.Grid.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Grid.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Grid.DisplayLayout.Override.CellAppearance = appearance14;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 0;
            appearance15.BackColor = System.Drawing.SystemColors.Control;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.GroupByRowAppearance = appearance15;
            appearance16.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(7, 67);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(715, 418);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.Grid.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.Grid_BeforeRowsDeleted);
            this.Grid.Enter += new System.EventHandler(this.Grid_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.AllowDrop = true;
            appearance18.AlphaLevel = ((short)(95));
            appearance18.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Appearance = appearance18;
            this.groupBox4.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtOrderID);
            this.groupBox4.Controls.Add(this.txtPallets);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtEntryDate);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(753, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 491);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Tick";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            this.txtOrderID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderID.Location = new System.Drawing.Point(12, 89);
            this.txtOrderID.Name = "txtCustomerID";
            this.txtOrderID.Size = new System.Drawing.Size(110, 20);
            this.txtOrderID.TabIndex = 31;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.txtOrderID.Enter += new System.EventHandler(this.txtOrderID_Enter);
            // 
            // txtPallets
            // 
            this.txtPallets.AllowDrop = true;
            appearance19.FontData.SizeInPoints = 12F;
            appearance19.TextHAlignAsString = "Right";
            this.txtPallets.Appearance = appearance19;
            this.txtPallets.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPallets.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPallets.FormatString = "###";
            this.txtPallets.InputMask = "nnn";
            this.txtPallets.Location = new System.Drawing.Point(36, 311);
            this.txtPallets.Name = "txtRetail";
            this.txtPallets.PromptChar = ' ';
            this.txtPallets.Size = new System.Drawing.Size(59, 26);
            this.txtPallets.TabIndex = 1;
            this.txtPallets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(36, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "No Pallets:";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance20.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance20;
            this.txtEntryDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(19, 410);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 28;
            this.txtEntryDate.Text = "//";
            this.txtEntryDate.Visible = false;
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(59, 605);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(0, 31);
            this.txtMessage.TabIndex = 4;
            // 
            // frmScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(889, 690);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmScanning";
            this.ShowInTaskbar = false;
            this.Text = "Scanning ";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScanning_FormClosed);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.txtMessage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region  Events	
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            this.txtStudent.Enabled = false;
            this.txtTeacher.Enabled = false;
            txtPallets.Enabled = false;
            this.txtCustomerID.Focus();
            
            oCustomer = new Customer(CompanyID);
            oOrder = new Scanning(this.CompanyID);
            oOrder1 = new Scanning(this.CompanyID); 

            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 2 * 1000;
            myTimer.Start();
            myTimer.Enabled = false;
            
		}
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
         //   if (oCustomer.ID != null)
            {
                myTimer.Stop();
                if (txtCustomerID.Text != "")
                {
                    oOrder.LoadOrders(this.BrochureID, txtCustomerID.Text);
                    //MessageBox.Show(oCustomer.ID);
                    Grid.DataSource = oOrder.ScanItems;
                    Grid.DataBind();
                    this.ActiveLeft();
                }
                myTimer.Enabled = true;
            }
        }
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtCustomerID
            
            
            if (sender == txtCustomerID)
            {
                Boolean IsF2 = false;
                
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {
                        this.txtCustomerID.Text = oCustomer.ID;
                        this.txtTeacher.Focus();
                    }
                    else
                    {
                        this.txtCustomerID.Clear();
                        this.txtCustomerID.Focus();
                        return;
                    }
                    IsF2 = true;
                    this.txtName.Text = oCustomer.Name;
                    oOrder.CustomerID = txtCustomerID.Text;
                   

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!this.get_customer())
                    {
                        this.txtCustomerID.Focus();
                        return;
                    }
                    //MessageBox.Show(oCustomer.Scanned +"-"+ oOrder.OrdersScanned.ToString() +"-"+oOrder.OrdersEntered.ToString());

                    if (oCustomer.IsCombo)
                    {
                        lBrochure.Visible = true;
                        txtBrochure.Visible = true;
                         
                            myTimer.Stop();
                            Brochure oBrochure = new Brochure(this.CompanyID);
                            foreach (BrochureByCustomer oBC in oCustomer.Brochures)
                            {
                                if (oBrochure.Find(oBC.BrochureID))
                                {
                                    txtBrochure.Items.Add(oBC.BrochureID);
                                }
                            }
                        if (this.BrochureID.Trim() == "")
                        {
                        
                            txtBrochure.Focus();
                            return;
                        }
                        else
                        {
                            txtBrochure.Text = this.BrochureID;
                         //   txtBrochure_SelectedIndexChanged(null, EventArgs.Empty);
                        }
                    }
                    else
                        this.BrochureID = "";

                    if ((oOrder.OrdersScanned == oOrder.OrdersEntered)) //oCustomer.Scanned  && 
                    {
                        //MessageBox.Show("This is already Done");
                        txtCustomerID.Enabled = false;
                        txtPallets.Enabled = true;
                        txtPallets.Text = oCustomer.NumberPallets.ToString();
                        txtPallets.Focus();
                        return;
                    }
                    else if (oCustomer.Scanned)
                    {
                        if ((MessageBox.Show("School already closed! \n\r continue packing this School?", "Scanning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                        {
                            txtCustomerID.Enabled = false;
                            txtPallets.Enabled = true;
                            txtPallets.Text = oCustomer.NumberPallets.ToString();
                            txtPallets.Focus();
                            return;
                        }
                    }

                    oOrder.CustomerID = txtCustomerID.Text;
                    if (oOrder.OrdersEntered == 0)
                    {
                        MessageBox.Show("This customer doesnt have any Order...");
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                        return;
                    }

                    
                    
                    oOrder.LoadOrders(this.BrochureID, txtCustomerID.Text);
                    

                    txtCustomerID.Enabled = false;
                    
                    oOrder.CustomerID = txtCustomerID.Text;

                    myTimer.Enabled = true;
                    Grid.DataSource = oOrder.ScanItems;
                    Grid.DataBind();
                    txtOrderID.Enabled = true;
                    txtOrderID.Focus();
                    return;

                }

            }
            #endregion
            #region txtOrderID
            if (sender==txtOrderID)	
			{
                if (e.KeyCode == Keys.F12)
                {
                    Grid.Focus();
                    return;
                }
                
                if (e.KeyCode == Keys.F2)
                {
                    if (oOrder.View())
                        txtOrderID.Text = oOrder.ID;
                    return;
                }

                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    if (txtOrderID.Text.Trim() == "")
                    {
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }

                    
                    int split = txtOrderID.Text.IndexOf('.');
                    if (split > -1)
                    {
                        if (this.BrochureID == "" && txtCustomerID.Text.Trim()=="" )
                        {
                            this.BrochureID = txtOrderID.Text.Substring(split + 1);
                        }
                        else if (this.BrochureID != txtOrderID.Text.Substring(split + 1))
                        {
                            Global.playSimpleSound(2);
                            ShowMessage("Different Brochure !!! " + txtOrderID.Text.Substring(split + 1), Color.Red);
                            txtOrderID.Clear();
                            return;
                        }

                        txtOrderID.Text = txtOrderID.Text.Substring(0, split).Trim();
                        // MessageBox.Show(this.BrochureID);
                        //return;
                    }
                    else if (this.BrochureID != "")
                    {
                        Global.playSimpleSound(2);
                        ShowMessage("Different Brochure !!! ", Color.Red);
                        txtOrderID.Clear();
                        return;
                    }

    
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
                        {
                            txtOrderID.Clear();
                            txtCustomerID.Text = oOrder.CustomerID;
                            txtName.Text = oOrder.oCustomer.Name;
                            txtBrochure.Text = this.BrochureID;
                            txtCustomerID.Focus();
                            // SendKeys.Send("{END}");
                            SendKeys.Send("{ENTER}");
                            return;
                        }
                        else
                        {
                            Global.playSimpleSound(2);
                            ShowMessage("This Order doesn't exist: " + txtOrderID.Text, Color.Red);
                            txtOrderID.Clear();
                            return;
                        }
                    }
                    /*
                    if (txtCustomerID.Text != oOrder.CustomerID)
                    {
                        Global.playSimpleSound(1);
                        return;
                    }
       
                    */
                    /*
                    if (!oOrder.oCustomer.IsCookieDough && oOrder.GetNumberOfBrochures() == 1 )
                    {
                        this.BrochureID = "";
                    }
                    */

                    //this.BrochureID = "";
                   // oOrder.BrochureID = this.BrochureID;

                    
                    //If the order is in this list
                    txtOrderID.Text = Convert.ToUInt32(txtOrderID.Text).ToString();
                    if (oOrder.ScanItems.Contains(txtOrderID.Text))
                    {
                        
                        if (oOrder.ScanItems[txtOrderID.Text].Packed ==0)
                        {
                            ActiveRow(false);
                            Global.playSimpleSound(2);
                            txtMessage.Text = "Order Not Packed Yet";
                            txtMessage.ForeColor = Color.Red;

                            ShowMessage("Order Not Packed Yet", Color.Red);
                            txtOrderID.Clear();
                            return;
                        }

                        if (oOrder.ScanItems[txtOrderID.Text].Packed < oOrder.ScanItems[txtOrderID.Text].Scanned)
                        {
                            ActiveRow(false);
                            Global.playSimpleSound(2);
                            ShowMessage("Something wrong, Modify number of boxes!!! ", Color.Red);
                            txtOrderID.Clear();
                            return;
                        }
                        
                        
                        Boolean IsPacked = false;
                        if (oOrder.ScanItems[txtOrderID.Text].Packed == oOrder.ScanItems[txtOrderID.Text].Scanned)
                        {
                            
                            Global.playSimpleSound(1);
                            ShowMessage("Order Already Scanned " + oOrder.ScanItems[txtOrderID.Text].Scanned.ToString() + " box(s)", Color.Red);
                            IsPacked = true;
                            txtBox.Text = oOrder.ScanItems[txtOrderID.Text].Scanned.ToString() + " box(s)";
                            txtOrderID.Clear();
                            return;
                        }

                        
                        txtTeacher.Text = oOrder.ScanItems[txtOrderID.Text].Teacher;
                        txtStudent.Text = oOrder.ScanItems[txtOrderID.Text].Student;
                        
                        if (!IsPacked)
                            oOrder.ScanItems[txtOrderID.Text].Scanned += 1;

                        txtBox.Text = String.Format("Box {0} of {1}", oOrder.ScanItems[txtOrderID.Text].Scanned , oOrder.ScanItems[txtOrderID.Text].Packed);
                        oOrder.UpdateScanned(oOrder.ScanItems[txtOrderID.Text].OrderID, oOrder.ScanItems[txtOrderID.Text].Scanned, oOrder.ScanItems[txtOrderID.Text].Packed,this.BrochureID);
                        if (oOrder.ScanItems[txtOrderID.Text].Scanned == oOrder.ScanItems[txtOrderID.Text].Packed)
                        {
                            //oOrder.ScanItems.Remove(txtOrderID.Text);
                           // oOrder.UpdateOrderScanned(oOrder.ScanItems[txtOrderID.Text].OrderID,this.BrochureID);
                            ActiveRow(true);
                            
                        }
                        else
                            ActiveRow(false);

                        
                        if (!IsPacked)
                        {
                            txtMessage.Text = "GOOD!";
                            txtMessage.ForeColor = Color.Green; 
                            ShowMessage(txtBox.Text, Color.Green);
                        }

                        Grid.DataBind();

                        if (oOrder.ScanItems.Count == 0)
                        {
                            //MessageBox.Show(oOrder.OrdersScanned.ToString() + oOrder.OrdersEntered.ToString());
                            if (oOrder.OrdersScanned == oOrder.OrdersEntered) //oOrder.ScanItems.Count == 0)
                            {
                                txtOrderID.Clear();
                                txtPallets.Clear();
                                txtPallets.Enabled = true;
                                txtPallets.Focus();
                                return;
                            }
                        }
                        txtOrderID.Clear();
                        return;
                    }
                    else
                    {
                        if (oOrder1.FindHeader(Convert.ToInt32(txtOrderID.Text)))
                        {
                            if (oOrder1.CustomerID != txtCustomerID.Text)
                            {
                                Global.playSimpleSound(7);
                                txtTeacher.Text = oOrder1.Teacher;
                                txtStudent.Text = oOrder1.Student;
                                txtMessage.Text = "Different School :"+oOrder1.oCustomer.Name;
                                txtMessage.ForeColor = Color.Red;

                                ShowMessage("Different School", Color.Red);
                                txtOrderID.Clear();
                                return;
                                
                            }
                            if (this.BrochureID == "")
                            {
                                if (!oOrder1.Packed)
                                {
                                    Global.playSimpleSound(2);
                                    txtMessage.Text = "Order Not Packed Yet";
                                    txtMessage.ForeColor = Color.Red;

                                    ShowMessage("Order Not Packed Yet", Color.Red);
                                    txtOrderID.Clear();
                                    return;
                                }
                                if (oOrder1.BoxesPacked < oOrder1.BoxesScanned)
                                {
                                    Global.playSimpleSound(2);
                                    ShowMessage("Something wrong, Modify number of boxes!!! ", Color.Red);
                                    txtOrderID.Clear();
                                    return;
                                }

                                if (oOrder1.BoxesPacked > 0 && oOrder1.BoxesPacked == oOrder1.BoxesScanned) //  (oOrder.Packed)
                                {
                                    //oOrder.UpdateOrderScanned(oOrder.ID);
                                    //oOrder.LoadOrders();
                                    Global.playSimpleSound(1);
                                    txtTeacher.Text = oOrder1.Teacher;
                                    txtStudent.Text = oOrder1.Student;
                                    txtBox.Text = String.Format("Boxes {0}", oOrder1.BoxesScanned);
                                    txtMessage.Text = "Order Already Scanned " + oOrder1.BoxesScanned.ToString() + " box(s)";
                                    txtMessage.ForeColor = Color.Red;

                                    ShowMessage("Order Already Scanned " + oOrder1.BoxesScanned.ToString() + " box(s)", Color.Red);
                                    //txtBox.Text = oOrder1.BoxesScanned.ToString() + " box(s)";
                                    txtOrderID.Clear();
                                    return;
                                }
                                txtBox.Text = String.Format("Box {0} of {1}", ++oOrder1.BoxesScanned, oOrder1.BoxesPacked);
                                oOrder1.UpdateScanned(oOrder1.ID, oOrder1.BoxesScanned, oOrder1.BoxesPacked, this.BrochureID);


                                txtMessage.Text = "GOOD!";
                                txtMessage.ForeColor = Color.Green;
                                ShowMessage(txtBox.Text, Color.Green);
                            }
                            else
                            {
                                Order.PackByOrder oOB = new Order.PackByOrder();
                                if (oOB.Find(Convert.ToInt32(txtOrderID.Text),this.BrochureID))
                                {
                                    if (!oOB.Packed)
                                    {
                                        Global.playSimpleSound(2);
                                        txtMessage.Text = "Order Not Packed Yet";
                                        txtMessage.ForeColor = Color.Red;

                                        ShowMessage("Order Not Packed Yet", Color.Red);
                                        txtOrderID.Clear();
                                        return;
                                    }
                                    if (oOB.BoxesPacked > 0 && oOB.BoxesPacked == oOB.BoxesScanned) //  (oOrder.Packed)
                                        {
                                    //oOrder.UpdateOrderScanned(oOrder.ID);
                                    //oOrder.LoadOrders();
                                    Global.playSimpleSound(1);
                                    txtTeacher.Text = oOrder1.Teacher;
                                    txtStudent.Text = oOrder1.Student;
                                    txtBox.Text = String.Format("Boxes {0}", oOB.BoxesScanned);
                                    txtMessage.Text = "Order Already Scanned " + oOB.BoxesScanned.ToString() + " box(s)";
                                    txtMessage.ForeColor = Color.Red;

                                    ShowMessage("Order Already Scanned " + oOB.BoxesScanned.ToString() + " box(s)", Color.Red);
                                    //txtBox.Text = oOrder1.BoxesScanned.ToString() + " box(s)";
                                    txtOrderID.Clear();
                                    return;
                                    }
                                    
                                    txtBox.Text = String.Format("Box {0} of {1}", ++oOB.BoxesScanned, oOB.BoxesPacked);
                                    oOrder1.UpdateScanned(oOrder1.ID, oOB.BoxesScanned, oOB.BoxesPacked, this.BrochureID);


                                    txtMessage.Text = "GOOD!";
                                    txtMessage.ForeColor = Color.Green;
                                    ShowMessage(txtBox.Text, Color.Green);
                                    
                                }

                            }


                            if (oOrder1.Teacher.Contains("A INTERNET") && oOrder1.CustomerID == txtCustomerID.Text)
                            {
                                txtBox.Text = String.Format("Box {0} of {1}", oOrder1.BoxesScanned++, oOrder1.BoxesPacked);
                                oOrder1.UpdateScanned(oOrder1.ID, oOrder1.BoxesScanned,oOrder1.BoxesPacked,this.BrochureID);
                                
                                txtMessage.Text = "GOOD!";
                                txtMessage.ForeColor = Color.Green;
                                ShowMessage(txtBox.Text, Color.Green);
                                txtOrderID.Clear();
                            }

                        }
                        else
                        {
                            Global.playSimpleSound(0);
                            
                        }
                        txtOrderID.Clear();
                        return;
                    }

                   
                    
				}

            }
            #endregion
            #region txtPallets
            if (sender==txtPallets)	
			{
				
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtPallets.Text == "")
                    {
                        txtPallets.Focus();
                        return;
                    }
                    if (Convert.ToInt32(txtPallets.Text) > 100)
                    {
                        txtPallets.Clear();
                        txtPallets.Focus();
                        return;
                    }

                    //oOrder.BoxesScanned = Convert.ToInt16(txtPallets.Text);
                    //oOrder.UpdatePacked();

                    oOrder.NumberPallets = Convert.ToInt32(txtPallets.Text);
                    oOrder.UpdateCustomerScanned();
                    PrinPalletLabels();
                    Clear();
                    this.BrochureID = "";
                    txtCustomerID.Enabled = true;
                    txtPallets.Enabled = false;
                    txtBrochure.Visible = false;
                    txtCustomerID.Clear();
                    txtCustomerID.Focus();
                    //this.Close();
                    return;
                }					

            }
            #endregion
            #region txtGrid
             if (sender==this.Grid)	
			{

                if (Char.IsDigit(Convert.ToChar(e.KeyValue)))
                {

                    txtOrderID.Focus();
                    txtOrderID.Text += Convert.ToChar(e.KeyValue).ToString();
              //      MessageBox.Show(txtOrderID.Text);
                    SendKeys.Send("{END}");
                    return;
                }

                if (e.KeyCode == Keys.F12)
                {
                    txtOrderID.Focus();
                    return;
                }
                 if (e.KeyCode.ToString()=="F8")
				{
					
					return;
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                {
                    
                    //return;
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
					//this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    //this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    break;
                case Keys.PageDown:
                    
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        #endregion

        #region  Methods
        private bool get_customer()
        {
            if (this.txtCustomerID.Text == "")
                return false;

            oOrder.CustomerID = this.txtCustomerID.Text;
            if (!oCustomer.Find(txtCustomerID.Text))
            {
                this.txtCustomerID.Clear();
                this.txtCustomerID.Focus();
                this.txtName.Text = oCustomer.Name;
                return false;
            }

            this.txtName.Text = oCustomer.Name;
            return true;

        }
        
        public void Clear()
        {
            txtName.Clear();
            txtOrderID.Clear();
            txtTeacher.Clear();
            txtStudent.Clear();
          //  oOrder.ScanItems.Clear();
            txtOrderID.Clear();
          //  Grid.DataBind();
            txtMessage.Text = "";          
            txtEntryDate.Text = DateTime.Now.Date.ToString();
        }
        private bool ShowHeader()
        {
            //Header
            //this.Clear();

            txtName.Text = oCustomer.Name;
            return true;
        }
        private bool ShowDetail()
        {
            Grid.Rows.Dispose();
           
            Grid.DataSource = oOrder.ScanItems;
            Grid.DataBind();
            //lbTest.DisplayMember = "Description";
            return true;
        }
        private void ShowMessage(String Message, Color _Color)
        {
            if (_Color == Color.Green)
                Global.playSimpleSound(6);

            ofrmMessage = new frmTimerMessage();
            ofrmMessage.Message = Message;
            ofrmMessage.MsgColor = _Color;
            ofrmMessage.Show();

        }
        private void PrinPalletLabels()
        {
            if (oCustomer.Find(txtCustomerID.Text))
            {/*
                frmViewReport oViewReport = new frmViewReport();
                oViewReport.Parameter_1 = oCustomer.NumberPallets;
                oViewReport.SetReport((int)Report.PalletLabels, CompanyID, oCustomer.ID, false);
                */
                oCustomer.PrintPalletsLabel();
            }

            

        }
        private void ActiveRow(bool DeleteIt)
        {
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {

                if (aUGRow.Cells["OrderID"].Value.ToString() == oOrder.ScanItems[txtOrderID.Text].OrderID)
                {
                    Grid.ActiveRow = aUGRow;
                    if (DeleteIt)
                        Grid.ActiveRow.Delete();
                    else
                        Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.LightBlue; //.White;
                    break;
                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }
        private void DeleteRow()
        {

            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                if (aUGRow.Cells["OrderID"].Value.ToString() == oOrder.ScanItems[txtOrderID.Text].OrderID)
                {
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveRow.Delete();
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    //Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.White;
                    break;
                }

                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }
        private void ActiveLeft()
        {   //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                if ((int)aUGRow.Cells["Scanned"].Value > 0)//(int) aUGRow.Cells["Packed"].Value > (int) aUGRow.Cells["Scanned"].Value)
                {
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.LightBlue;
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")


                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }
		#endregion

        private void Grid_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void frmScanning_FormClosed(object sender, FormClosedEventArgs e)
        {
            myTimer.Dispose();
            oDeamon.Stop();
        }

        private void txtOrderID_Enter(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
            
        }

        private void Grid_Enter(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
        }

        private void txtBrochure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBrochure.Text != "")
            {
                this.BrochureID = txtBrochure.Text;
                //oOrder.BrochureID = this.BrochureID;
                myTimer.Start();
                myTimer.Enabled = true;
                txtBrochure.Enabled = false;
                txtCustomerID.Enabled = false;
                txtOrderID.Focus();

                oOrder.LoadOrders(this.BrochureID, txtCustomerID.Text);


                txtCustomerID.Enabled = false;
                myTimer.Enabled = true;

                oOrder.CustomerID = txtCustomerID.Text;

                Grid.DataSource = oOrder.ScanItems;
                Grid.DataBind();
                txtOrderID.Enabled = true;
                txtOrderID.Focus();


                if ((oOrder.OrdersScanned == oOrder.OrdersEntered)) //oCustomer.Scanned  && 
                {
                    //MessageBox.Show("This is already Done");
                    txtCustomerID.Enabled = false;
                    txtPallets.Enabled = true;
                    txtPallets.Text = oCustomer.NumberPallets.ToString();
                    txtPallets.Focus();
                    return;
                }
                else if (oCustomer.Scanned)
                {
                    if ((MessageBox.Show("School already closed! \n\r continue packing this School?", "Scanning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                    {
                        txtCustomerID.Enabled = false;
                        txtPallets.Enabled = true;
                        txtPallets.Text = oCustomer.NumberPallets.ToString();
                        txtPallets.Focus();
                        return;
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   String TempFile = System.IO.Path.GetTempFileName();


            oDeamon.BrochureID = this.BrochureID;
            oDeamon.CompanyID = this.CompanyID;
            oDeamon.CustomerID = txtCustomerID.Text;
            
            //oDeamon.Tick += new BackDeamon.EventHandler(oDeamon_Tick);
            oDeamon.Start();
        }

        void oDeamon_Tick(object sender, EventArgs e)
        {
            //    throw new Exception("The method or operation is not implemented.");
         //   MessageBox.Show("Ok...");
        }


        private class BackDeamon:Deamon
        {
            public String CompanyID;
            public String CustomerID;
            public String BrochureID;
            public String _TmpFile;

            public String TmpFile
            {
                get 
                {
                    _TmpFile = CompanyID + CustomerID + BrochureID;
                    return _TmpFile;
                }
            }

            public  BackDeamon()
            {
                CompanyID = "";
                CustomerID = "";
                BrochureID = "";
                _TmpFile = "";
                this.Tick += new EventHandler(BackDeamon_Tick);
            }

            void BackDeamon_Tick(object sender, EventArgs e)
            {
                //Global.oMySql.exec_sql("call sp

            }
        }


	}
}
