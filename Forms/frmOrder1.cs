using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.OSAS;
using Signature.Classes;
using System.Media;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmOrder1 : System.Windows.Forms.Form
	{
		#region declarations		
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Label lbCompany;
        private Label label11;
        private Button bPrint;
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedLabel txtRetailTax;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoItems;
        private Label label5;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Label label6;
        private Label label10;
        private Label label7;
        private Signature.Windows.Forms.MaskedEditNumeric txtCollected;
        private Signature.Windows.Forms.MaskedEditNumeric txtDiff;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.MaskedEdit txtQuantity;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label8;
        private Label label4;
        private Label label3;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label2;
        private Label label1;
		#endregion
		Signature.Data.MySQL oMySql = new Signature.Data.MySQL();
		public String CompanyID = null;
        private Order oOrder;
        private Order.Item IDetail;
        
        public int _OrderProcess = (int )OrderProcess.Enter;

        private Boolean IsDiff = false;


        public frmOrder1()
		{
			InitializeComponent();
            oOrder = new Order(Global.GetParameter("CurrentCompany"));
            this.CompanyID = Global.GetParameter("CurrentCompany");
		}
        public frmOrder1(String CustomerID, String Teacher, String Student)
        {
            InitializeComponent();
            oOrder = new Order(Global.GetParameter("CurrentCompany"));
            this.CompanyID = Global.GetParameter("CurrentCompany");
            txtCustomerID.Text = CustomerID;
            txtCustomerID.Enabled = false;
            txtTeacher.Text = Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = Student;
            txtStudent.Enabled = false;
            if (oOrder.Find(this.txtTeacher.Text, this.txtStudent.Text))
                ShowOrder();
            else
                MessageBox.Show("This Order doen't exist...");
            this.txtProductID.Focus();
            
        }
        public frmOrder1(ref Discrepancy _oOrder)
        {
            InitializeComponent();
            oOrder = _oOrder;
            this.CompanyID = Global.GetParameter("CurrentCompany");
            txtCustomerID.Text = oOrder.CustomerID;
            txtCustomerID.Enabled = false;
            txtTeacher.Text = oOrder.Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = oOrder.Student;
            txtStudent.Enabled = false;

            //MessageBox.Show(oOrder.Teacher+ oOrder.Student + oOrder.CustomerID);

            if (!ShowOrder())
            {
                MessageBox.Show("This Order doen't exist...");
                this.Dispose();
            }   
            this.txtProductID.Focus();

        }
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCompany = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtRetailTax = new Signature.Windows.Forms.MaskedLabel();
            this.txtNoItems = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCollected = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDiff = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEdit();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.lbCompany);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.bPrint);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(649, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 108);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lbCompany
            // 
            this.lbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompany.Location = new System.Drawing.Point(78, 22);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(33, 19);
            this.lbCompany.TabIndex = 13;
            this.lbCompany.Text = "F07";
            this.lbCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "Company:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bPrint
            // 
            this.bPrint.Location = new System.Drawing.Point(77, 75);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(54, 21);
            this.bPrint.TabIndex = 12;
            this.bPrint.Text = "Print";
            this.bPrint.UseVisualStyleBackColor = true;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 451);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Order Detail ";
            // 
            // Grid
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.Grid.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 422;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Format = "$####.00";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nn";
            ultraGridColumn3.Width = 57;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.Width = 54;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.Grid.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Grid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grid.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Grid.DisplayLayout.Override.CellAppearance = appearance8;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance11;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(8, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(613, 417);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.Grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid;
            this.ultraGroupBox1.Controls.Add(this.txtRetailTax);
            this.ultraGroupBox1.Controls.Add(this.txtNoItems);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtEntryDate);
            this.ultraGroupBox1.Controls.Add(this.label6);
            this.ultraGroupBox1.Controls.Add(this.label10);
            this.ultraGroupBox1.Controls.Add(this.label7);
            this.ultraGroupBox1.Controls.Add(this.txtCollected);
            this.ultraGroupBox1.Controls.Add(this.txtDiff);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.txtRetail);
            this.ultraGroupBox1.Controls.Add(this.txtQuantity);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label8);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Location = new System.Drawing.Point(649, 120);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(140, 434);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtRetailTax
            // 
            this.txtRetailTax.AllowDrop = true;
            appearance13.FontData.BoldAsString = "True";
            this.txtRetailTax.Appearance = appearance13;
            this.txtRetailTax.Location = new System.Drawing.Point(10, 401);
            this.txtRetailTax.Name = "txtDescription";
            this.txtRetailTax.Size = new System.Drawing.Size(125, 21);
            this.txtRetailTax.TabIndex = 40;
            this.txtRetailTax.TabStop = true;
            this.txtRetailTax.Value = null;
            // 
            // txtNoItems
            // 
            this.txtNoItems.AllowDrop = true;
            appearance14.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance14;
            this.txtNoItems.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoItems.FormatString = "###,###";
            this.txtNoItems.InputMask = "nnnnnnnnn";
            this.txtNoItems.Location = new System.Drawing.Point(58, 123);
            this.txtNoItems.Name = "txtRetail";
            this.txtNoItems.ReadOnly = true;
            this.txtNoItems.Size = new System.Drawing.Size(68, 20);
            this.txtNoItems.TabIndex = 38;
            this.txtNoItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(5, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Items:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance15.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance15;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(33, 375);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 44;
            this.txtEntryDate.Text = "//";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(2, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Retail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(37, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Entry Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(1, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Diff:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCollected
            // 
            this.txtCollected.AllowDrop = true;
            appearance16.TextHAlignAsString = "Right";
            this.txtCollected.Appearance = appearance16;
            this.txtCollected.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCollected.FormatString = "###,###.##";
            this.txtCollected.InputMask = "{LOC}nnnnnnn.nn";
            this.txtCollected.Location = new System.Drawing.Point(21, 274);
            this.txtCollected.Name = "txtRetail";
            this.txtCollected.PromptChar = ' ';
            this.txtCollected.Size = new System.Drawing.Size(85, 20);
            this.txtCollected.TabIndex = 2;
            this.txtCollected.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDiff
            // 
            this.txtDiff.AllowDrop = true;
            appearance17.TextHAlignAsString = "Right";
            this.txtDiff.Appearance = appearance17;
            this.txtDiff.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtDiff.InputMask = "{double:-6.4}";
            this.txtDiff.Location = new System.Drawing.Point(58, 174);
            this.txtDiff.Name = "txtRetail";
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(68, 20);
            this.txtDiff.TabIndex = 42;
            this.txtDiff.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.Location = new System.Drawing.Point(13, 54);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(115, 59);
            this.txtDescription.TabIndex = 39;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtRetail
            // 
            this.txtRetail.AllowDrop = true;
            appearance18.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance18;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(58, 149);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(68, 20);
            this.txtRetail.TabIndex = 41;
            this.txtRetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            this.txtQuantity.Location = new System.Drawing.Point(76, 28);
            this.txtQuantity.Name = "txtCustomerID";
            this.txtQuantity.Size = new System.Drawing.Size(52, 20);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.Location = new System.Drawing.Point(12, 28);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(52, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(18, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 37;
            this.label8.Text = "Amount Collected:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(74, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item:";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Parallel3D;
            this.ultraGroupBox2.Controls.Add(this.txtName);
            this.ultraGroupBox2.Controls.Add(this.txtStudent);
            this.ultraGroupBox2.Controls.Add(this.txtTeacher);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.label2);
            this.ultraGroupBox2.Controls.Add(this.label1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(6, 6);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(637, 106);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.Location = new System.Drawing.Point(156, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(471, 19);
            this.txtName.TabIndex = 19;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.Location = new System.Drawing.Point(98, 72);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(529, 20);
            this.txtStudent.TabIndex = 2;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.Location = new System.Drawing.Point(98, 48);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(529, 20);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(98, 24);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(36, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            this.lbCompany.Text = this.CompanyID;
            this.txtCustomerID.Focus();

            IDetail = new Order.Item();

            if (_OrderProcess == (int)OrderProcess.Discrepancy)
                bPrint.Visible = false;
		}
        private void bPrint_Click(object sender, EventArgs e)
        {
            oOrder.OpenPrinter(1);
            oOrder.Print();
            oOrder.ClosePrinter();
        }
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{

            #region txtCustomerID
            if (sender==txtCustomerID)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    if (oOrder.oCustomer.View())
                    {
                        this.txtCustomerID.Text = oOrder.oCustomer.ID;
                        this.txtTeacher.Focus();
                     }
                    this.txtName.Text = oOrder.oCustomer.Name;
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!this.get_customer())
					{
						this.txtCustomerID.Focus();
						return;
					}

				}

            }
            #endregion
            #region txtTeacher
            if (sender==txtTeacher)	
			{
                if (e.KeyCode.ToString() == "F2")
                {

                    oOrder.oTeacher.View(txtCustomerID.Text);

                    if (oOrder.oTeacher.ID != "")
                    {
                        this.txtCustomerID.Text = oOrder.oTeacher.CustomerID;
                        this.oOrder.oCustomer.Find(this.txtCustomerID.Text);
                        oOrder.CustomerID = this.txtCustomerID.Text;
                        txtName.Text = oOrder.oCustomer.Name;
                        this.txtTeacher.Text = oOrder.oTeacher.ID;
                        this.txtStudent.Focus();
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    oOrder.oTeacher.ID = txtTeacher.Text;

                    if (!oOrder.oTeacher.Find(txtCustomerID.Text, txtTeacher.Text))
                    {
                        this.txtTeacher.Clear();
                        return;
                    }
                    else
                    {
                        this.txtTeacher.Text = oOrder.oTeacher.ID;
                        this.txtStudent.Focus();
                        return;
                    }


                }

            }
            #endregion
            #region txtStudent
            if (sender==txtStudent)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    
                    oOrder.oStudent.View(txtCustomerID.Text, txtTeacher.Text);
                    
                    if (oOrder.oStudent.ID != "")
                    {
                            txtCustomerID.Text = oOrder.oStudent.CustomerID;

                            txtTeacher.Text = oOrder.oStudent.Teacher;
                            this.txtStudent.Text = oOrder.oStudent.ID;
                            this.oOrder.oCustomer.Find(this.txtCustomerID.Text);
                            oOrder.CustomerID = this.txtCustomerID.Text;
                            txtName.Text = oOrder.oCustomer.Name;
                            ShowOrder();
                            this.txtProductID.Focus();
                            return;
                        
                    }
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    oOrder.oStudent.ID = txtStudent.Text;
                    if (oOrder.oStudent.ID != "")
                    {

                        /*    if (!oOrder.oStudent.Find(txtCustomerID.Text,txtStudent.Text))
                            {
                                this.txtStudent.Text = null;
                                this.txtStudent.Focus();
                                return;
                            }
                            else
                            {*/
                        oOrder.Items.Clear();
                        Grid.DataBind();
                        ShowOrder();
                        this.txtProductID.Focus();
                        return;
                        // }
                    }
                    return;
                }

            }
            #endregion
            #region txtProductID
            if (sender==txtProductID)	
			{
				
				if (e.KeyCode.ToString()=="F8")
				{
					this.Grid.Focus();
				}

				if (e.KeyCode.ToString()=="F2")
				{

					if (oOrder.oProduct.View())
                    {
                        this.txtProductID.Text = oOrder.oProduct.ID;
                        this.txtQuantity.Clear();
                        return;
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (oOrder.oProduct.Find(txtProductID.Text))
                    {
                        this.IDetail.ProductID      = oOrder.oProduct.ID;
                        this.IDetail.Price          = oOrder.oCustomer.PriceListID=="1"?oOrder.oProduct.Price_2:oOrder.oProduct.Price;
                        this.IDetail.Description    = oOrder.oProduct.Description.ToString();
                        this.IDetail.Length         = oOrder.oProduct.Length;
                        this.IDetail.Width          = oOrder.oProduct.Width;
                        this.IDetail.Height         = oOrder.oProduct.Height;

                        this.txtProductID.Text = oOrder.oProduct.ID;
                        this.txtDescription.Text = oOrder.oProduct.Description;
                        this.txtQuantity.Text = "1";

                        if (e.KeyCode == Keys.Return)
                        {
                            txtQuantity.Enabled = true;
                            this.txtQuantity.Focus();
                        }
                        else
                        {
                            AddItem();
                            ActiveRow();
                            txtProductID.Focus();

                        }
                            
                        
                        return;

                    }
                    else
                    {
                        playSimpleSound();   
                        this.txtProductID.Clear();
                        this.txtProductID.Focus();
                        return;
                    }
                }					

            }
            #endregion
            #region txtQuantity
            if (sender==this.txtQuantity)	
			{
                //MessageBox.Show(e.KeyCode.ToString());
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
				{
     
                    if (this.txtQuantity.Text != "" )
					{
                        this.AddItem();
                        ActiveRow();
                        this.txtProductID.Text = "";
                        this.txtProductID.Focus();
						return;
					}
					else
					{
						this.txtQuantity.Focus();
						return;
					}
                    
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

                    if (Math.Abs(oOrder.Diff) > 0 && !IsDiff)
                    {
                        Global.playSimpleSound();
                        IsDiff = true;
                        txtCollected.Focus();
                        return;

                    }
                    else
                        IsDiff = false;

                    Save();
                    if (_OrderProcess == (int)OrderProcess.Discrepancy)
                        Close();
                    Clear();
                    txtStudent.Clear();
                    Grid.Rows.Dispose();
                    txtStudent.Focus();

                    return;
                 }

             }
            #endregion
            #region Grid
             if (sender==this.Grid)	
			{
			//	MessageBox.Show(e.KeyCode.ToString());
				if (e.KeyCode.ToString()=="Delete")
				{
					this.DeleteItem();
					return;
				}
                if (e.KeyCode.ToString() == "F8" || e.KeyCode == Keys.PageDown)
				{
					this.txtProductID.Focus();
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
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    this.Grid.Focus();
                    break;
                case Keys.F3:
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    this.txtCollected.Focus();
                    break;
                case Keys.PageUp:
                    Shortage();
                    return;
                    


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        private void Grid_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            getTotals();
        }
        private void txtProductID_Enter(object sender, EventArgs e)
        {
            txtQuantity.Enabled = false;
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
        private void playSimpleSound()
        {
            //SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            //simpleSound.Play();
            SystemSounds.Hand.Play();
        }
        private bool ShowOrder()
        {
            
            if (!oOrder.Find(txtTeacher.Text, txtStudent.Text))
            {
                return false;
            }
            this.ShowHeader();
            this.ShowDetail();
            return true;
        }
        private bool get_customer()
		{
			
            
            if (this.txtCustomerID.Text=="")
				return false;

            oOrder.CustomerID = this.txtCustomerID.Text;
            if (!oOrder.oCustomer.IfExist()) 
            
			{
				this.txtCustomerID.Clear();
				this.txtCustomerID.Focus();
                this.txtName.Text = oOrder.oCustomer.Name;
				return false;
			}
			
            this.txtName.Text = oOrder.oCustomer.Name;
			return true;
		
		}
        private void Clear()
        {
            //frm.txtCustomerID.Clear();
            //frm.txtTeacher.Clear();
            //frm.txtStudent.Clear();
            //frm.listView.Clear();
            
            
            //txtStudent.Clear();
            txtRetail.Clear();
            txtNoItems.Clear();
            txtDiff.Clear();
            txtCollected.Clear();
            txtEntryDate.Text = DateTime.Now.Date.ToString();
            txtCollected.Clear();

        }
        private bool ShowHeader()
        {
            //Header
            this.Clear();

            txtRetail.Text = oOrder.Retail.ToString();
            txtNoItems.Text = oOrder.NoItems.ToString();
            txtCollected.Text = oOrder.Collected.ToString();
            txtDiff.Text = Convert.ToString(oOrder.Retail - oOrder.Collected);
            txtEntryDate.Text = oOrder.Date.ToString();
            if (oOrder.oCustomer.ApplyTax == "R" || oOrder.oCustomer.CollectTax == "R")
                txtRetailTax.Text = "R/Tax : " + (oOrder.Retail + oOrder.Tax).ToString();

            
            return true;
        }
        private bool ShowDetail()
        {
            //Grid.Rows.Dispose();
            //Grid.DataSource = "";
           
            Grid.DataSource = oOrder.Items;
            Grid.DataBind();
            //lbTest.DisplayMember = "Description";
            return true;
        }
        private void DeleteItem()
        {
            if (Grid.ActiveRow != null)
            {
                Grid.ActiveRow.Delete();
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

            this.IDetail.Quantity = Convert.ToInt16(txtQuantity.Text);

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
                txtProductID.Focus();
                

            return;
        }
        private void Save()
        {

            getTotals();
            oOrder.CompanyID    = CompanyID;
            oOrder.CustomerID   = txtCustomerID.Text;
            oOrder.Teacher      = txtTeacher.Text;
            oOrder.Student      = txtStudent.Text;
            oOrder.Collected    = Convert.ToDouble(txtCollected.Text);
            
            oOrder.Save(OrderType.Regular);
            oOrder.Items.Clear();
            Grid.DataBind();
            Clear();
            txtStudent.Clear();
            txtStudent.Focus();

            
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
            oOrder.Items.Clear();
            Grid.DataBind();
            Clear();
            txtStudent.Focus();
            return;
        }
        private void Shortage()
        {
            frmShortage frm = new frmShortage();
            frm.CompanyID = this.CompanyID;
            frm.txtOrderID.Text = oOrder.ID;
            frm.txtCustomerID.Text = oOrder.oCustomer.ID;
            frm.txtChild.Text = oOrder.Student;
            frm.txtParent.Text = "";
            frm.txtTeacher.Text = oOrder.Teacher;
            frm.txtName.Text = oOrder.oCustomer.Name;
            frm.txtAddress.Text = oOrder.oCustomer.Address;
            frm.txtCity.Text = oOrder.oCustomer.City;
            frm.txtZipCode.Text = oOrder.oCustomer.ZipCode;
            frm.txtState.Text = oOrder.oCustomer.State;
           // frm.txtName.Enabled = false;
            frm.ShowDialog();
        }

		#endregion

        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                if (oOrder.oCustomer.Find(txtCustomerID.Text))
                {
                    oOrder.oCustomer.GetCurrentTotalsByBrochure();
                }
            }
        }

        
	}
}
