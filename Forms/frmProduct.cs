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
	public sealed class frmProduct : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
		private Signature.Windows.Forms.GroupBox groupBox3;
        private Signature.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Signature.Windows.Forms.MaskedEdit txtDescription;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtInvCode;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtTaxable;
        private Label label8;
        private Signature.Windows.Forms.MaskedEdit txtBarCode;
        private Label label7;
        private Signature.Windows.Forms.MaskedEdit txtVendorItem;
        private Label label6;
        private Signature.Windows.Forms.MaskedEdit txtVendorID;
        private Label label5;
        private Label label14;
        private Signature.Windows.Forms.MaskedEdit txtSold;
        private Label label13;
        private Signature.Windows.Forms.MaskedEdit txtONPO;
        private Label label12;
        private Signature.Windows.Forms.MaskedEdit txtCommited;
        private Label label10;
        private Label label9;
        private Signature.Windows.Forms.MaskedEdit txtEstimated;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Signature.Windows.Forms.MaskedEditNumeric txtHeight;
        private Signature.Windows.Forms.MaskedEditNumeric txtWidth;
        private Signature.Windows.Forms.MaskedEditNumeric txtLength;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Signature.Windows.Forms.MaskedEditNumeric txtCost;
        private Signature.Windows.Forms.MaskedEditNumeric txtPrice;
        private Label labCost;
        private Label label19;
        private Signature.Windows.Forms.MaskedEditNumeric txtSize;
        private Signature.Windows.Forms.GroupBox groupBox5;
        private UltraGrid Grid;
        private Signature.Windows.Forms.MaskedEditNumeric txtOnHand;
        private Signature.Windows.Forms.MaskedEdit txtAvailable;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtBarCode_2;
        private Label label20;
        private Signature.Windows.Forms.MaskedEdit txtBarCode_3;
        private Label label21;
        private Signature.Windows.Forms.MaskedEdit txtReceived;
        private Label label22;
        private Signature.Windows.Forms.Button btAdjustment;
        private Label label23;
        private Signature.Windows.Forms.MaskedEditNumeric txtAdjProfitPercent;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtCompound;
        private Signature.Windows.Forms.Button txtItems;
        private Signature.Windows.Forms.MaskedEditNumeric txtCode;
        private Label label24;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfit_00;
        private Label label27;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfit_20;
        private Label label26;
        private Signature.Windows.Forms.MaskedEditNumeric txtProfit_10;
        private Label label25;
        private Button b_Percentage;
        private Signature.Windows.Forms.MaskedEditNumeric txtAbsoluteProfitPercent;
        private Label label29;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtCustomized;
        private Signature.Windows.Forms.MaskedEditNumeric txtUnitCost;
        private Label labUnitCost;
        private Signature.Windows.Forms.MaskedEditNumeric txtBoxCount;
        private Label lBoxCount;
        private Signature.Windows.Forms.ComboBox txtPackaging;
        private Label label11;
        private Signature.Windows.Forms.MaskedEditNumeric txtUpperRange;
        private Label label28;
        private Signature.Windows.Forms.MaskedEditNumeric txtImprintingFee;
        private Label label30;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtLandedCost;
        private Signature.Windows.Forms.MaskedEditNumeric txtSection;
        private Label label31;
        #endregion
        
        Product oProduct;
        private Signature.Windows.Forms.GroupBox groupBox6;
        private UltraGrid PGrid;
        Vendor oVendor;
        
        public frmProduct()
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
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StateID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Taxable", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", 1);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StateID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PurchaseID", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtSection = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label31 = new System.Windows.Forms.Label();
            this.txtPackaging = new Signature.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxCount = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lBoxCount = new System.Windows.Forms.Label();
            this.txtCustomized = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtCode = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label24 = new System.Windows.Forms.Label();
            this.txtItems = new Signature.Windows.Forms.Button();
            this.txtCompound = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtBarCode_3 = new Signature.Windows.Forms.MaskedEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBarCode_2 = new Signature.Windows.Forms.MaskedEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSize = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtTaxable = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBarCode = new Signature.Windows.Forms.MaskedEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVendorItem = new Signature.Windows.Forms.MaskedEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorID = new Signature.Windows.Forms.MaskedEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvCode = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.b_Percentage = new System.Windows.Forms.Button();
            this.btAdjustment = new Signature.Windows.Forms.Button();
            this.txtReceived = new Signature.Windows.Forms.MaskedEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.txtAvailable = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOnHand = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtEstimated = new Signature.Windows.Forms.MaskedEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSold = new Signature.Windows.Forms.MaskedEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtONPO = new Signature.Windows.Forms.MaskedEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCommited = new Signature.Windows.Forms.MaskedEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new Signature.Windows.Forms.GroupBox();
            this.txtHeight = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtWidth = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtLength = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtLandedCost = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtImprintingFee = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label30 = new System.Windows.Forms.Label();
            this.txtUpperRange = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label28 = new System.Windows.Forms.Label();
            this.txtUnitCost = new Signature.Windows.Forms.MaskedEditNumeric();
            this.labUnitCost = new System.Windows.Forms.Label();
            this.txtAbsoluteProfitPercent = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label29 = new System.Windows.Forms.Label();
            this.txtProfit_00 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProfit_20 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label26 = new System.Windows.Forms.Label();
            this.txtProfit_10 = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label25 = new System.Windows.Forms.Label();
            this.txtAdjProfitPercent = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCost = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPrice = new Signature.Windows.Forms.MaskedEditNumeric();
            this.labCost = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox5 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox6 = new Signature.Windows.Forms.GroupBox();
            this.PGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox5)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox6)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 661);
            this.txtStatus.Size = new System.Drawing.Size(657, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtSection);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtPackaging);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtBoxCount);
            this.groupBox2.Controls.Add(this.lBoxCount);
            this.groupBox2.Controls.Add(this.txtCustomized);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtItems);
            this.groupBox2.Controls.Add(this.txtCompound);
            this.groupBox2.Controls.Add(this.txtBarCode_3);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txtBarCode_2);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtSize);
            this.groupBox2.Controls.Add(this.txtTaxable);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtBarCode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtVendorItem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtVendorID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtInvCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtProductID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 232);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.Text = " Order Header ";
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtSection
            // 
            this.txtSection.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtSection.Appearance = appearance3;
            this.txtSection.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSection.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtSection.InputMask = "nnnn";
            this.txtSection.Location = new System.Drawing.Point(474, 208);
            this.txtSection.Name = "txtRetail";
            this.txtSection.PromptChar = ' ';
            this.txtSection.Size = new System.Drawing.Size(63, 20);
            this.txtSection.TabIndex = 254;
            this.txtSection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Location = new System.Drawing.Point(382, 209);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(60, 19);
            this.label31.TabIndex = 253;
            this.label31.Text = "Section:";
            // 
            // txtPackaging
            // 
            this.txtPackaging.AllowDrop = true;
            this.txtPackaging.AutoCompleteCustomSource.AddRange(new string[] {
            "YES",
            "NO"});
            this.txtPackaging.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPackaging.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPackaging.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtPackaging.FormattingEnabled = true;
            this.txtPackaging.Items.AddRange(new object[] {
            "Poly Bag",
            "Color Box",
            "None"});
            this.txtPackaging.Location = new System.Drawing.Point(476, 181);
            this.txtPackaging.Name = "cbSpanish";
            this.txtPackaging.Size = new System.Drawing.Size(96, 21);
            this.txtPackaging.TabIndex = 253;
            this.txtPackaging.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(382, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 19);
            this.label11.TabIndex = 254;
            this.label11.Text = "Packaging:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.AllowDrop = true;
            appearance31.TextHAlignAsString = "Right";
            this.txtBoxCount.Appearance = appearance31;
            this.txtBoxCount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBoxCount.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtBoxCount.InputMask = "nnnn";
            this.txtBoxCount.Location = new System.Drawing.Point(527, 27);
            this.txtBoxCount.Name = "txtRetail";
            this.txtBoxCount.PromptChar = ' ';
            this.txtBoxCount.Size = new System.Drawing.Size(63, 20);
            this.txtBoxCount.TabIndex = 252;
            this.txtBoxCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lBoxCount
            // 
            this.lBoxCount.BackColor = System.Drawing.Color.Transparent;
            this.lBoxCount.Location = new System.Drawing.Point(449, 28);
            this.lBoxCount.Name = "lBoxCount";
            this.lBoxCount.Size = new System.Drawing.Size(60, 19);
            this.lBoxCount.TabIndex = 251;
            this.lBoxCount.Text = "Box Count:";
            // 
            // txtCustomized
            // 
            appearance30.BackColor = System.Drawing.Color.Transparent;
            appearance30.BackColor2 = System.Drawing.Color.Transparent;
            appearance30.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCustomized.Appearance = appearance30;
            this.txtCustomized.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomized.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtCustomized.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCustomized.Location = new System.Drawing.Point(20, 185);
            this.txtCustomized.Name = "txtCustomized";
            this.txtCustomized.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomized.Size = new System.Drawing.Size(139, 19);
            this.txtCustomized.TabIndex = 250;
            this.txtCustomized.Text = "Customized(Cards)";
            this.txtCustomized.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCode
            // 
            this.txtCode.AllowDrop = true;
            appearance27.TextHAlignAsString = "Right";
            this.txtCode.Appearance = appearance27;
            this.txtCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCode.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtCode.InputMask = "nnnn";
            this.txtCode.Location = new System.Drawing.Point(527, 53);
            this.txtCode.Name = "txtRetail";
            this.txtCode.PromptChar = ' ';
            this.txtCode.Size = new System.Drawing.Size(63, 20);
            this.txtCode.TabIndex = 248;
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(474, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 21);
            this.label24.TabIndex = 247;
            this.label24.Text = "Code:";
            // 
            // txtItems
            // 
            this.txtItems.AllowDrop = true;
            this.txtItems.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtItems.ForeColor = System.Drawing.Color.Black;
            this.txtItems.Location = new System.Drawing.Point(180, 160);
            this.txtItems.Name = "btAdjustment";
            this.txtItems.Size = new System.Drawing.Size(71, 20);
            this.txtItems.TabIndex = 30;
            this.txtItems.Text = "&Items";
            this.txtItems.Click += new System.EventHandler(this.txtItems_Click);
            this.txtItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCompound
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BackColor2 = System.Drawing.Color.Transparent;
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCompound.Appearance = appearance4;
            this.txtCompound.BackColor = System.Drawing.Color.Transparent;
            this.txtCompound.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtCompound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCompound.Location = new System.Drawing.Point(20, 160);
            this.txtCompound.Name = "txtCompound";
            this.txtCompound.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompound.Size = new System.Drawing.Size(139, 19);
            this.txtCompound.TabIndex = 246;
            this.txtCompound.Text = "Compound";
            this.txtCompound.CheckedChanged += new System.EventHandler(this.txtCompound_CheckedChanged);
            this.txtCompound.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtBarCode_3
            // 
            this.txtBarCode_3.AllowDrop = true;
            this.txtBarCode_3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBarCode_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode_3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode_3.Location = new System.Drawing.Point(474, 155);
            this.txtBarCode_3.Name = "txtCustomerID";
            this.txtBarCode_3.Size = new System.Drawing.Size(116, 20);
            this.txtBarCode_3.TabIndex = 8;
            this.txtBarCode_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(382, 153);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 20);
            this.label21.TabIndex = 30;
            this.label21.Text = "Barcode 3:";
            // 
            // txtBarCode_2
            // 
            this.txtBarCode_2.AllowDrop = true;
            this.txtBarCode_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBarCode_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode_2.Location = new System.Drawing.Point(474, 130);
            this.txtBarCode_2.Name = "txtCustomerID";
            this.txtBarCode_2.Size = new System.Drawing.Size(116, 20);
            this.txtBarCode_2.TabIndex = 7;
            this.txtBarCode_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(382, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 20);
            this.label20.TabIndex = 28;
            this.label20.Text = "Barcode 2:";
            // 
            // txtSize
            // 
            this.txtSize.AllowDrop = true;
            appearance5.TextHAlignAsString = "Right";
            this.txtSize.Appearance = appearance5;
            this.txtSize.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSize.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtSize.FormatString = "###,###.##";
            this.txtSize.InputMask = "nnnnnnnnn";
            this.txtSize.Location = new System.Drawing.Point(295, 134);
            this.txtSize.Name = "txtRetail";
            this.txtSize.PromptChar = ' ';
            this.txtSize.Size = new System.Drawing.Size(63, 20);
            this.txtSize.TabIndex = 26;
            this.txtSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTaxable
            // 
            this.txtTaxable.AllowDrop = true;
            this.txtTaxable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTaxable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxable.Location = new System.Drawing.Point(147, 131);
            this.txtTaxable.Name = "txtCustomerID";
            this.txtTaxable.Size = new System.Drawing.Size(26, 20);
            this.txtTaxable.TabIndex = 4;
            this.txtTaxable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(17, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Taxable Item?(Y/N):";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(256, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 23;
            this.label14.Text = "Size:";
            // 
            // txtBarCode
            // 
            this.txtBarCode.AllowDrop = true;
            this.txtBarCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode.Location = new System.Drawing.Point(474, 105);
            this.txtBarCode.Name = "txtCustomerID";
            this.txtBarCode.Size = new System.Drawing.Size(116, 20);
            this.txtBarCode.TabIndex = 6;
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(382, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Barcode:";
            // 
            // txtVendorItem
            // 
            this.txtVendorItem.AllowDrop = true;
            this.txtVendorItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtVendorItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendorItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendorItem.Location = new System.Drawing.Point(474, 79);
            this.txtVendorItem.Name = "txtCustomerID";
            this.txtVendorItem.Size = new System.Drawing.Size(116, 20);
            this.txtVendorItem.TabIndex = 5;
            this.txtVendorItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(382, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "VENDOR ITEM:";
            // 
            // txtVendorID
            // 
            this.txtVendorID.AllowDrop = true;
            this.txtVendorID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendorID.Location = new System.Drawing.Point(147, 105);
            this.txtVendorID.Name = "txtCustomerID";
            this.txtVendorID.Size = new System.Drawing.Size(116, 20);
            this.txtVendorID.TabIndex = 3;
            this.txtVendorID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(17, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Main Vendor:";
            // 
            // txtInvCode
            // 
            this.txtInvCode.AllowDrop = true;
            this.txtInvCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtInvCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvCode.Location = new System.Drawing.Point(147, 79);
            this.txtInvCode.Name = "txtCustomerID";
            this.txtInvCode.Size = new System.Drawing.Size(116, 20);
            this.txtInvCode.TabIndex = 2;
            this.txtInvCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Inventory Code:";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Location = new System.Drawing.Point(147, 49);
            this.txtDescription.Name = "txtCustomerID";
            this.txtDescription.Size = new System.Drawing.Size(289, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Description:";
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(147, 16);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Item:";
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance6.AlphaLevel = ((short)(95));
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance6;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.b_Percentage);
            this.groupBox3.Controls.Add(this.btAdjustment);
            this.groupBox3.Controls.Add(this.txtReceived);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtAvailable);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtOnHand);
            this.groupBox3.Controls.Add(this.txtEstimated);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtSold);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtONPO);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtCommited);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(337, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 265);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.Text = "Inventory Detail:";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // b_Percentage
            // 
            this.b_Percentage.Location = new System.Drawing.Point(30, 222);
            this.b_Percentage.Name = "b_Percentage";
            this.b_Percentage.Size = new System.Drawing.Size(124, 25);
            this.b_Percentage.TabIndex = 30;
            this.b_Percentage.Text = "Percentage";
            this.b_Percentage.UseVisualStyleBackColor = true;
            this.b_Percentage.Visible = false;
            this.b_Percentage.Click += new System.EventHandler(this.b_Percentage_Click);
            // 
            // btAdjustment
            // 
            this.btAdjustment.AllowDrop = true;
            this.btAdjustment.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btAdjustment.ForeColor = System.Drawing.Color.Black;
            this.btAdjustment.Location = new System.Drawing.Point(169, 222);
            this.btAdjustment.Name = "btAdjustment";
            this.btAdjustment.Size = new System.Drawing.Size(120, 26);
            this.btAdjustment.TabIndex = 29;
            this.btAdjustment.Text = "&Adjustment";
            this.btAdjustment.Click += new System.EventHandler(this.btAdjustment_Click);
            // 
            // txtReceived
            // 
            this.txtReceived.AllowDrop = true;
            this.txtReceived.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceived.Location = new System.Drawing.Point(158, 47);
            this.txtReceived.Name = "txtCustomerID";
            this.txtReceived.Size = new System.Drawing.Size(119, 20);
            this.txtReceived.TabIndex = 27;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(51, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 18);
            this.label22.TabIndex = 28;
            this.label22.Text = "Received:";
            // 
            // txtAvailable
            // 
            this.txtAvailable.AllowDrop = true;
            this.txtAvailable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvailable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAvailable.Location = new System.Drawing.Point(158, 131);
            this.txtAvailable.Name = "txtCustomerID";
            this.txtAvailable.Size = new System.Drawing.Size(119, 20);
            this.txtAvailable.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(51, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Available:";
            // 
            // txtOnHand
            // 
            this.txtOnHand.AllowDrop = true;
            appearance7.TextHAlignAsString = "Right";
            this.txtOnHand.Appearance = appearance7;
            this.txtOnHand.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOnHand.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtOnHand.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtOnHand.InputMask = "-nnnnnnnnn";
            this.txtOnHand.Location = new System.Drawing.Point(158, 75);
            this.txtOnHand.Name = "txtAmountDue";
            this.txtOnHand.PromptChar = ' ';
            this.txtOnHand.Size = new System.Drawing.Size(120, 20);
            this.txtOnHand.TabIndex = 26;
            this.txtOnHand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtEstimated
            // 
            this.txtEstimated.AllowDrop = true;
            this.txtEstimated.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEstimated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstimated.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstimated.Location = new System.Drawing.Point(158, 187);
            this.txtEstimated.Name = "txtCustomerID";
            this.txtEstimated.Size = new System.Drawing.Size(119, 20);
            this.txtEstimated.TabIndex = 5;
            this.txtEstimated.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(51, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Total Est Need:";
            // 
            // txtSold
            // 
            this.txtSold.AllowDrop = true;
            this.txtSold.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSold.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSold.Location = new System.Drawing.Point(158, 159);
            this.txtSold.Name = "txtCustomerID";
            this.txtSold.Size = new System.Drawing.Size(119, 20);
            this.txtSold.TabIndex = 3;
            this.txtSold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(51, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 21;
            this.label13.Text = "Qty Sold:";
            // 
            // txtONPO
            // 
            this.txtONPO.AllowDrop = true;
            this.txtONPO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtONPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtONPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtONPO.Location = new System.Drawing.Point(158, 21);
            this.txtONPO.Name = "txtCustomerID";
            this.txtONPO.Size = new System.Drawing.Size(119, 20);
            this.txtONPO.TabIndex = 2;
            this.txtONPO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(51, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "Qty ONPO:";
            // 
            // txtCommited
            // 
            this.txtCommited.AllowDrop = true;
            this.txtCommited.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCommited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommited.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCommited.Location = new System.Drawing.Point(158, 104);
            this.txtCommited.Name = "txtCustomerID";
            this.txtCommited.Size = new System.Drawing.Size(119, 20);
            this.txtCommited.TabIndex = 1;
            this.txtCommited.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(51, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "Commited:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(51, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Qty OnHand :";
            // 
            // groupBox4
            // 
            this.groupBox4.AllowDrop = true;
            appearance8.AlphaLevel = ((short)(95));
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Appearance = appearance8;
            this.groupBox4.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.txtHeight);
            this.groupBox4.Controls.Add(this.txtWidth);
            this.groupBox4.Controls.Add(this.txtLength);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(5, 415);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 92);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.Text = "Dimensions:";
            this.groupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowDrop = true;
            appearance9.TextHAlignAsString = "Right";
            this.txtHeight.Appearance = appearance9;
            this.txtHeight.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtHeight.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtHeight.FormatString = "###,###.00";
            this.txtHeight.InputMask = "{LOC}nnnnnnn.nn";
            this.txtHeight.Location = new System.Drawing.Point(147, 65);
            this.txtHeight.Name = "txtRetail";
            this.txtHeight.PromptChar = ' ';
            this.txtHeight.Size = new System.Drawing.Size(63, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtWidth
            // 
            this.txtWidth.AllowDrop = true;
            appearance10.TextHAlignAsString = "Right";
            this.txtWidth.Appearance = appearance10;
            this.txtWidth.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtWidth.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtWidth.FormatString = "###,###.00";
            this.txtWidth.InputMask = "{LOC}nnnnnnn.nn";
            this.txtWidth.Location = new System.Drawing.Point(147, 39);
            this.txtWidth.Name = "txtRetail";
            this.txtWidth.PromptChar = ' ';
            this.txtWidth.Size = new System.Drawing.Size(63, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtLength
            // 
            this.txtLength.AllowDrop = true;
            appearance11.TextHAlignAsString = "Right";
            this.txtLength.Appearance = appearance11;
            this.txtLength.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLength.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtLength.FormatString = "###,###.00";
            this.txtLength.InputMask = "{LOC}nnnnnnn.nn";
            this.txtLength.Location = new System.Drawing.Point(147, 13);
            this.txtLength.Name = "txtRetail";
            this.txtLength.PromptChar = ' ';
            this.txtLength.Size = new System.Drawing.Size(63, 20);
            this.txtLength.TabIndex = 0;
            this.txtLength.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(17, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 27;
            this.label16.Text = "Height:";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(17, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 20);
            this.label17.TabIndex = 25;
            this.label17.Text = "Width:";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(17, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 16);
            this.label18.TabIndex = 23;
            this.label18.Text = "Length:";
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance12.AlphaLevel = ((short)(95));
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance12;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtLandedCost);
            this.groupBox1.Controls.Add(this.txtImprintingFee);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.txtUpperRange);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.txtUnitCost);
            this.groupBox1.Controls.Add(this.labUnitCost);
            this.groupBox1.Controls.Add(this.txtAbsoluteProfitPercent);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtProfit_00);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.txtProfit_20);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.txtProfit_10);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtAdjProfitPercent);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.labCost);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(5, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtLandedCost
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.White;
            this.txtLandedCost.Appearance = appearance2;
            this.txtLandedCost.BackColor = System.Drawing.Color.Transparent;
            this.txtLandedCost.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtLandedCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtLandedCost.Location = new System.Drawing.Point(204, 136);
            this.txtLandedCost.Name = "txtLandedCost";
            this.txtLandedCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLandedCost.Size = new System.Drawing.Size(106, 19);
            this.txtLandedCost.TabIndex = 251;
            this.txtLandedCost.Text = "Landed Cost";
            this.txtLandedCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtImprintingFee
            // 
            this.txtImprintingFee.AllowDrop = true;
            appearance20.TextHAlignAsString = "Right";
            this.txtImprintingFee.Appearance = appearance20;
            this.txtImprintingFee.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtImprintingFee.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtImprintingFee.FormatString = "###,###.00";
            this.txtImprintingFee.InputMask = "{LOC}nnnnnnn.nn";
            this.txtImprintingFee.Location = new System.Drawing.Point(144, 133);
            this.txtImprintingFee.Name = "txtRetail";
            this.txtImprintingFee.PromptChar = ' ';
            this.txtImprintingFee.Size = new System.Drawing.Size(42, 20);
            this.txtImprintingFee.TabIndex = 41;
            this.txtImprintingFee.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Location = new System.Drawing.Point(20, 134);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(119, 21);
            this.label30.TabIndex = 42;
            this.label30.Text = "Imprinting Fee:";
            // 
            // txtUpperRange
            // 
            this.txtUpperRange.AllowDrop = true;
            appearance29.TextHAlignAsString = "Right";
            this.txtUpperRange.Appearance = appearance29;
            this.txtUpperRange.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUpperRange.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtUpperRange.FormatString = "###,###.00";
            this.txtUpperRange.InputMask = "{LOC}nnnnnnn.nn";
            this.txtUpperRange.Location = new System.Drawing.Point(268, 8);
            this.txtUpperRange.Name = "txtRetail";
            this.txtUpperRange.PromptChar = ' ';
            this.txtUpperRange.Size = new System.Drawing.Size(42, 20);
            this.txtUpperRange.TabIndex = 39;
            this.txtUpperRange.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(201, 5);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 27);
            this.label28.TabIndex = 40;
            this.label28.Text = "Upper Range:";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.AllowDrop = true;
            appearance13.TextHAlignAsString = "Right";
            this.txtUnitCost.Appearance = appearance13;
            this.txtUnitCost.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUnitCost.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtUnitCost.FormatString = "###,###.0000";
            this.txtUnitCost.InputMask = "{LOC}nnnnnnn.nnnn";
            this.txtUnitCost.Location = new System.Drawing.Point(133, 59);
            this.txtUnitCost.Name = "txtRetail";
            this.txtUnitCost.PromptChar = ' ';
            this.txtUnitCost.Size = new System.Drawing.Size(53, 20);
            this.txtUnitCost.TabIndex = 2;
            this.txtUnitCost.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.txtUnitCost_MaskChanged);
            this.txtUnitCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // labUnitCost
            // 
            this.labUnitCost.BackColor = System.Drawing.Color.Transparent;
            this.labUnitCost.Location = new System.Drawing.Point(17, 62);
            this.labUnitCost.Name = "labUnitCost";
            this.labUnitCost.Size = new System.Drawing.Size(86, 19);
            this.labUnitCost.TabIndex = 38;
            this.labUnitCost.Text = "Landed Cost:";
            // 
            // txtAbsoluteProfitPercent
            // 
            this.txtAbsoluteProfitPercent.AllowDrop = true;
            appearance14.ForeColorDisabled = System.Drawing.Color.White;
            this.txtAbsoluteProfitPercent.Appearance = appearance14;
            this.txtAbsoluteProfitPercent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAbsoluteProfitPercent.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtAbsoluteProfitPercent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtAbsoluteProfitPercent.FormatString = "###.##";
            this.txtAbsoluteProfitPercent.InputMask = "nnn.nn%";
            this.txtAbsoluteProfitPercent.Location = new System.Drawing.Point(144, 109);
            this.txtAbsoluteProfitPercent.Name = "txtProfitPercent";
            this.txtAbsoluteProfitPercent.PromptChar = ' ';
            this.txtAbsoluteProfitPercent.Size = new System.Drawing.Size(42, 20);
            this.txtAbsoluteProfitPercent.TabIndex = 4;
            this.txtAbsoluteProfitPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(17, 112);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(128, 18);
            this.label29.TabIndex = 35;
            this.label29.Text = "Absolute Profit Percent:";
            // 
            // txtProfit_00
            // 
            this.txtProfit_00.AllowDrop = true;
            appearance15.TextHAlignAsString = "Right";
            this.txtProfit_00.Appearance = appearance15;
            this.txtProfit_00.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfit_00.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtProfit_00.FormatString = "#,###.00";
            this.txtProfit_00.InputMask = "{LOC}nnnn.nn";
            this.txtProfit_00.Location = new System.Drawing.Point(268, 57);
            this.txtProfit_00.Name = "txtRetail";
            this.txtProfit_00.PromptChar = ' ';
            this.txtProfit_00.Size = new System.Drawing.Size(42, 20);
            this.txtProfit_00.TabIndex = 7;
            this.txtProfit_00.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(201, 65);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 14);
            this.label27.TabIndex = 34;
            this.label27.Text = "Price 00%:";
            // 
            // txtProfit_20
            // 
            this.txtProfit_20.AllowDrop = true;
            appearance16.TextHAlignAsString = "Right";
            this.txtProfit_20.Appearance = appearance16;
            this.txtProfit_20.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfit_20.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtProfit_20.FormatString = "#,###.00";
            this.txtProfit_20.InputMask = "{LOC}nnnn.nn";
            this.txtProfit_20.Location = new System.Drawing.Point(268, 110);
            this.txtProfit_20.Name = "txtRetail";
            this.txtProfit_20.PromptChar = ' ';
            this.txtProfit_20.Size = new System.Drawing.Size(42, 20);
            this.txtProfit_20.TabIndex = 6;
            this.txtProfit_20.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(201, 116);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 14);
            this.label26.TabIndex = 32;
            this.label26.Text = "Price 20%:";
            // 
            // txtProfit_10
            // 
            this.txtProfit_10.AllowDrop = true;
            appearance17.TextHAlignAsString = "Right";
            this.txtProfit_10.Appearance = appearance17;
            this.txtProfit_10.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtProfit_10.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtProfit_10.FormatString = "#,###.00";
            this.txtProfit_10.InputMask = "{LOC}nnnn.nn";
            this.txtProfit_10.Location = new System.Drawing.Point(268, 83);
            this.txtProfit_10.Name = "txtRetail";
            this.txtProfit_10.PromptChar = ' ';
            this.txtProfit_10.Size = new System.Drawing.Size(42, 20);
            this.txtProfit_10.TabIndex = 5;
            this.txtProfit_10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(201, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 14);
            this.label25.TabIndex = 30;
            this.label25.Text = "Price 10%:";
            // 
            // txtAdjProfitPercent
            // 
            this.txtAdjProfitPercent.AllowDrop = true;
            appearance18.ForeColorDisabled = System.Drawing.Color.White;
            this.txtAdjProfitPercent.Appearance = appearance18;
            this.txtAdjProfitPercent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtAdjProfitPercent.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtAdjProfitPercent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtAdjProfitPercent.FormatString = "###.##";
            this.txtAdjProfitPercent.InputMask = "nnn.nn%";
            this.txtAdjProfitPercent.Location = new System.Drawing.Point(144, 85);
            this.txtAdjProfitPercent.Name = "txtProfitPercent";
            this.txtAdjProfitPercent.PromptChar = ' ';
            this.txtAdjProfitPercent.Size = new System.Drawing.Size(42, 20);
            this.txtAdjProfitPercent.TabIndex = 3;
            this.txtAdjProfitPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(17, 87);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 18);
            this.label23.TabIndex = 27;
            this.label23.Text = "Relative Profit Percent:";
            // 
            // txtCost
            // 
            this.txtCost.AllowDrop = true;
            appearance19.TextHAlignAsString = "Right";
            this.txtCost.Appearance = appearance19;
            this.txtCost.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCost.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtCost.FormatString = "###,###.0000";
            this.txtCost.InputMask = "{LOC}nnnnnnn.nnnn";
            this.txtCost.Location = new System.Drawing.Point(133, 34);
            this.txtCost.Name = "txtRetail";
            this.txtCost.PromptChar = ' ';
            this.txtCost.Size = new System.Drawing.Size(53, 20);
            this.txtCost.TabIndex = 1;
            this.txtCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPrice
            // 
            this.txtPrice.AllowDrop = true;
            appearance28.TextHAlignAsString = "Right";
            this.txtPrice.Appearance = appearance28;
            this.txtPrice.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPrice.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtPrice.FormatString = "###,###.00";
            this.txtPrice.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPrice.Location = new System.Drawing.Point(144, 8);
            this.txtPrice.Name = "txtRetail";
            this.txtPrice.PromptChar = ' ';
            this.txtPrice.Size = new System.Drawing.Size(42, 20);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // labCost
            // 
            this.labCost.BackColor = System.Drawing.Color.Transparent;
            this.labCost.Location = new System.Drawing.Point(17, 38);
            this.labCost.Name = "labCost";
            this.labCost.Size = new System.Drawing.Size(44, 16);
            this.labCost.TabIndex = 25;
            this.labCost.Text = "Cost:";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(17, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 14);
            this.label19.TabIndex = 23;
            this.label19.Text = "Price:";
            // 
            // groupBox5
            // 
            this.groupBox5.AllowDrop = true;
            appearance32.AlphaLevel = ((short)(95));
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Appearance = appearance32;
            this.groupBox5.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.Grid);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Location = new System.Drawing.Point(331, 514);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 141);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.Text = "Taxes by State";
            this.groupBox5.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance33.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance33;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "State";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn1.Width = 46;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 59;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 191;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance34;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 3;
            appearance35.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance35;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance36.BorderColor = System.Drawing.Color.LightGray;
            appearance36.TextVAlignAsString = "Middle";
            this.Grid.DisplayLayout.Override.RowAppearance = appearance36;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance37.BorderColor = System.Drawing.Color.Black;
            appearance37.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance37;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(7, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(313, 117);
            this.Grid.TabIndex = 186;
            // 
            // groupBox6
            // 
            this.groupBox6.AllowDrop = true;
            appearance21.AlphaLevel = ((short)(95));
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Appearance = appearance21;
            this.groupBox6.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox6.Controls.Add(this.PGrid);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Location = new System.Drawing.Point(6, 514);
            this.groupBox6.Name = "groupBox5";
            this.groupBox6.Size = new System.Drawing.Size(326, 141);
            this.groupBox6.TabIndex = 187;
            this.groupBox6.Text = "Open Purchase Orders";
            this.groupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // PGrid
            // 
            appearance22.BackColor = System.Drawing.Color.White;
            this.PGrid.DisplayLayout.Appearance = appearance22;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Caption = "State";
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;
            ultraGridColumn4.Width = 46;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Width = 150;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn5});
            this.PGrid.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.PGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.PGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.PGrid.DisplayLayout.MaxRowScrollRegions = 1;
            this.PGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance23.BackColor = System.Drawing.Color.Transparent;
            this.PGrid.DisplayLayout.Override.CardAreaAppearance = appearance23;
            this.PGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.PGrid.DisplayLayout.Override.CellPadding = 3;
            appearance24.TextHAlignAsString = "Left";
            this.PGrid.DisplayLayout.Override.HeaderAppearance = appearance24;
            this.PGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance25.BorderColor = System.Drawing.Color.LightGray;
            appearance25.TextVAlignAsString = "Middle";
            this.PGrid.DisplayLayout.Override.RowAppearance = appearance25;
            this.PGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance26.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance26.BorderColor = System.Drawing.Color.Black;
            appearance26.ForeColor = System.Drawing.Color.Black;
            this.PGrid.DisplayLayout.Override.SelectedRowAppearance = appearance26;
            this.PGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.PGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.PGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.PGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.PGrid.Location = new System.Drawing.Point(7, 19);
            this.PGrid.Name = "PGrid";
            this.PGrid.Size = new System.Drawing.Size(313, 117);
            this.PGrid.TabIndex = 186;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(657, 690);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmProduct";
            this.ShowInTaskbar = false;
            this.Text = "Product Maintenance";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox5)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox6)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PGrid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
   		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oVendor = new Vendor(this.CompanyID);
            oProduct = new Product(this.CompanyID);

            this.txtProductID.Focus();

         //   txtAvailable.Enabled = false;
            txtONPO.Enabled = false;
            txtSold.Enabled = false;
            txtCommited.Enabled = false;
            txtEstimated.Enabled = false;
            txtAvailable.Enabled = false;
            txtReceived.Enabled = false;
            txtOnHand.Enabled = false;
            txtItems.Visible = false;

            if (IsGiftAvenue)
            {
                txtCode.Visible = true;
                txtBoxCount.Visible = true;
            }
            else
            {
                txtCode.Visible = false;
                txtBoxCount.Visible = true;
            }
            
         /*   Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            
            rc.SetCustomizedString("DeleteSingleRowPrompt", "");
            Grid.EventManager.AllEventsEnabled = false;
            Grid.EventManager.SetEnabled(EventGroups.AllEvents, false);*/
            
            if (Global.HasAccess("FRMPRODUCTCOST"))
            {
                txtCost.Visible = true;
                labCost.Visible = true;
            }
            else
            {
                txtCost.Visible = false;
                labCost.Visible = false;
            }

            txtCustomized.Enabled = false;

            txtPackaging.Text = "Poly Bag";
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
                        ShowProduct();
                        txtDescription.Focus();
                        labCost.Visible = true;
                        txtCost.Visible = true;
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
                        ShowProduct();
                        txtDescription.Focus();
                        labCost.Visible = true;
                        txtCost.Visible = true;
                    
                    } else
                    {
                        labCost.Visible = true;
                        txtCost.Visible = true;
                        Clear();
                        
                    }


                    
                }					

            }
            #endregion
            #region txtVendorID
            if (sender == txtVendorID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oVendor.View())
                    {
                        txtVendorID.Text = oVendor.ID;
                        
                    }

                }

                /*if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtVendorID.Text.Trim().Length == 0)
                    {
                        //txtVendorID.Focus();
                    }

                }*/

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
                            oProduct.Delete();
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
            
            //oProduct.Clear();
            oProduct.ID = txtProductID.Text;
            oProduct.Description = txtDescription.Text;
            oProduct.InvCode = txtInvCode.Text  ;
            oProduct.Length = (txtLength.Value == DBNull.Value) ? 0: Convert.ToDouble(txtLength.Value);
            oProduct.Height = (txtHeight.Value == DBNull.Value) ? 0 : Convert.ToDouble(txtHeight.Value);
            oProduct.Width = (txtWidth.Value == DBNull.Value) ? 0 : Convert.ToDouble(txtWidth.Value);
            oProduct.Size = (txtSize.Value == DBNull.Value) ? 0 : (int) Convert.ToInt16(txtSize.Text);

            oProduct.Price = (txtPrice.Value == DBNull.Value) ? 0 : Convert.ToDouble(txtPrice.Value);
            oProduct.Cost = (txtCost.Value == DBNull.Value) ? 0 : Convert.ToDouble(txtCost.Value);
            oProduct.UnitCost = txtUnitCost.Number;

            oProduct.Taxable    = txtTaxable.Text ;
            oProduct.BarCode    = txtBarCode.Text;
            oProduct.BarCode_2  = txtBarCode_2.Text;
            oProduct.BarCode_3  = txtBarCode_3.Text;

            oProduct.VendorID = txtVendorID.Text ;
            oProduct.VendorItem = txtVendorItem.Text;

            oProduct.AdjustProfitPercent    = txtAdjProfitPercent.Number; //(txtAdjProfitPercent.Value == DBNull.Value) ? 0 : Convert.ToDouble(txtAdjProfitPercent.Value);
            oProduct.AbsoluteProfitPercent  = txtAbsoluteProfitPercent.Number;

            oProduct.IsCompound = txtCompound.Checked;
            //oProduct.OnHand = (Int32) txtOnHand.Number;

            oProduct.Code = (Int32) txtCode.Number;
            oProduct.BoxCount = (Int32)txtBoxCount.Number;

            oProduct.Profit_10 = txtProfit_10.Number;
            oProduct.Profit_20 = txtProfit_20.Number;
            oProduct.Profit_00 = txtProfit_00.Number;

            oProduct.Packaging = txtPackaging.Text == "Poly Bag" ? "PB" : (txtPackaging.Text == "Color Box" ? "CBX" : "Non"); //"Poly Bag" ? "PB" : "CBX";

            oProduct.UpperRange = txtUpperRange.Number;

            oProduct.ImprintingFee = txtImprintingFee.Number;
            oProduct.IsLandedCost = txtLandedCost.Checked;

            oProduct.Section = (Int32) txtSection.Value;

            oProduct.Save();
            Clear();
            txtProductID.Clear();

        }
        
        public bool ShowProduct()
        {
            Clear();
            txtDescription.Text = oProduct.Description;
            txtProductID.Text = oProduct.ID;
            txtInvCode.Text = oProduct.InvCode;
            txtLength.Text = oProduct.Length.ToString();
            txtHeight.Text = oProduct.Height.ToString();
            txtWidth.Text = oProduct.Width.ToString();
            txtSize.Text = oProduct.Size.ToString();

            txtPrice.Text = oProduct.Price.ToString();
            

            txtCost.Text = oProduct.Cost.ToString();
            txtUnitCost.Text = oProduct.UnitCost.ToString();
            txtTaxable.Text = oProduct.Taxable;
            txtBarCode.Text = oProduct.BarCode;
            txtBarCode_2.Text = oProduct.BarCode_2;
            txtBarCode_3.Text = oProduct.BarCode_3;

            txtAvailable.Text = (oProduct.OnHand - oProduct.Committed).ToString();

            txtONPO.Text = oProduct.ONPO.ToString();
            txtSold.Text = oProduct.Sold.ToString();
            txtOnHand.Text = oProduct.OnHand.ToString();
            txtCommited.Text = oProduct.Committed.ToString();
            txtVendorID.Text = oProduct.VendorID;
            txtVendorItem.Text = oProduct.VendorItem;
            txtReceived.Text = oProduct.Received.ToString();

            txtAdjProfitPercent.Text = oProduct.AdjustProfitPercent.ToString();
            txtAbsoluteProfitPercent.Text = oProduct.AbsoluteProfitPercent.ToString();
            txtCompound.Checked = oProduct.IsCompound;
            if (oProduct.IsCompound)
                txtItems.Visible = true;

            if (!this.IsGiftAvenue)
            {
                txtProfit_10.Visible = false;
                txtProfit_20.Visible = false;
                txtProfit_00.Visible = false;

            }
            else
            {
                txtProfit_10.Value = oProduct.Profit_10;
                txtProfit_20.Value = oProduct.Profit_20;
                txtProfit_00.Value = oProduct.Profit_00;
            }
            DataTable dt = oMySql.GetDataTable(String.Format("Select t.StateID,s.Name,t.Taxable From Tax_By_State t Left Join States s on t.StateID=s.StateID Where CompanyID='{0}' And ProductID='{1}'", CompanyID, oProduct.ID),"Tax_By_State");
            Grid.DataSource = dt;

            DataTable dtPurchases = oMySql.GetDataTable(String.Format("SELECT pd.PurchaseID as PurchaseID,   pd.cases*p.size+pd.units as Ordered, sum(IF(rd.Quantity is Null,0,rd.Quantity)) as Received FROM PurchaseDetail pd  Left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Left Join ReceiveDetail rd on pd.CompanyID=rd.CompanyID and pd.ProductID=rd.ProductID and pd.PurchaseID=rd.PurchaseID Where pd.CompanyID = '{0}' And pd.ProductID= '{1}' Group by pd.PurchaseID, pd.ProductID,rd.ProductID HAVING Ordered > Received", CompanyID, oProduct.ID), "OpenPurchases");
            PGrid.DataSource = dtPurchases;

            txtCode.Value = oProduct.Code;
            txtBoxCount.Value = oProduct.BoxCount;
            txtCustomized.Checked = oProduct.IsCustomized;

            txtPackaging.Text = oProduct.Packaging == "PB" ? "Poly Bag" : (oProduct.Packaging == "CBX" ? "Color Box" : "None");
            txtUpperRange.Value = oProduct.UpperRange;
            txtImprintingFee.Value = oProduct.ImprintingFee;
            txtLandedCost.Checked = oProduct.IsLandedCost;
            txtSection.Value = oProduct.Section;

            return true;
        }
        public void Clear()
        {
            txtDescription.Clear();
           
            txtInvCode.Clear();
            txtLength.Clear();
            txtHeight.Clear();
            txtWidth.Clear();
            txtSize.Clear();

            txtTaxable.Clear();
            txtBarCode.Clear();
            txtBarCode_2.Clear();
            txtBarCode_3.Clear();

            txtPrice.Clear();
            txtCost.Clear();
            txtUnitCost.Clear();

            txtONPO.Clear();
            txtSold.Clear();
            txtOnHand.Clear();
            txtCommited.Clear();
            txtReceived.Clear();
            txtVendorID.Clear();
            txtVendorItem.Clear();
            txtAdjProfitPercent.Clear();
            txtAbsoluteProfitPercent.Clear();
            txtCompound.Checked = false;
            txtItems.Visible = false;

            txtCode.Value = 0;
            txtBoxCount.Value = 0;

            txtProfit_10.Clear();
            txtProfit_20.Clear();
            txtProfit_00.Clear();

            txtUpperRange.Clear();

            txtImprintingFee.Clear();

            txtCustomized.Checked = false;

            txtLandedCost.Checked = false;

            txtSection.Clear();
        }
      
		#endregion

        private void btAdjustment_Click(object sender, EventArgs e)
        {
            frmItemAdjustment oAdj = new frmItemAdjustment(CompanyID,oProduct);
            oAdj.ShowDialog();
            this.ShowProduct();
        }

        private void txtCompound_CheckedChanged(object sender, EventArgs e)
        {
            if (txtCompound.Checked)
                txtItems.Visible = true;
            else
                txtItems.Visible = false;
        }

        private void txtItems_Click(object sender, EventArgs e)
        {
            frmProductCompound frmCompound = new frmProductCompound();
            frmCompound.txtProductID.Text = oProduct.ID;
            frmCompound.txtProductID.Enabled = false;
            frmCompound.ShowDialog();
        }

        private void b_Percentage_Click(object sender, EventArgs e)
        {
           // oProduct.GA_CalculatePorcentages();
        }

        private void txtUnitCost_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
        {

        }

	}
}
