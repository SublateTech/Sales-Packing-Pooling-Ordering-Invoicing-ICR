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
using XPTable;
using XPTable.Editors;
using XPTable.Models;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmOrder : frmBase
	{
		#region declarations		
        private Panel panel1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label2;
        private Label label1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedLabel txtRetailTax;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoItems;
        private Label label5;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Label label6;
        private Label label7;
        private Signature.Windows.Forms.MaskedEditNumeric txtCollected;
        private Signature.Windows.Forms.MaskedEditNumeric txtDiff;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label8;
        private Label label4;
        private Label label3;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Label lbCompany;
        private Label label11;
        private Label label12;
        private Signature.Windows.Forms.MaskedEditNumeric txtPackedDate;
        private Label lPackedDate;
        private Signature.Windows.Forms.MaskedEditNumeric txtBoxes;
        private Label label10;
        private Label label13;
        private Signature.Windows.Forms.MaskedEditNumeric txtOrderID;
        private Label lPhone;
        private Signature.Windows.Forms.MaskedEditNumeric txtPhone;
        private ToolStrip tStrip;
        private ToolStripButton toolStripViewImage;
        private ToolStripButton toolStripPrint;
        private ToolStripButton toolStripViewInternet;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private Signature.Windows.Forms.MaskedEditNumeric txtQuantity;

        #endregion
        
		public  Order oOrder;
        private Order.Item IDetail;
        public  OrderProcess _OrderProcess = OrderProcess.Enter;
        private Boolean IsDiff = false;
        private Boolean IsCookieDough = false;
        private NetSpell.SpellChecker.Dictionary.WordDictionary wordDictionary;
        private IContainer components;
        private NetSpell.SpellChecker.Spelling spelling;
       
        internal RichTextBox txtStudent;
        private XPTable.Models.Table table;
        
        public Boolean IsSaved = false;
        

        public frmOrder()
		{
			InitializeComponent();
            oOrder = new Order(base.CompanyID);
            oOrder.Type = OrderType.Regular;
            this.toolStripViewImage.Enabled = false;
            this.toolStripViewInternet.Enabled = false;
		}
        public frmOrder(String CustomerID, String Teacher, String Student)
        {
            InitializeComponent();
            oOrder = new Order(base.CompanyID);
            txtCustomerID.Text = CustomerID;
            txtCustomerID.Enabled = false;
            txtTeacher.Text = Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = Student;
            txtStudent.Enabled = false;
            
            this.toolStripViewImage.Enabled = false;
            this.toolStripViewInternet.Enabled = false;

            if (oOrder.Find(this.txtTeacher.Text, this.txtStudent.Text))
                ShowOrder();
            else
                MessageBox.Show("This Order doen't exist...");
            this.txtProductID.Focus();
            
        }
        public frmOrder(ref Discrepancy _oOrder)
        {
            InitializeComponent();
            oOrder = _oOrder;
            //this.CompanyID = Global.GetParameter("CurrentCompany");
            this.CompanyID = oOrder.CompanyID;
            txtCustomerID.Text = oOrder.CustomerID;
            txtCustomerID.Enabled = false;
            txtTeacher.Text = oOrder.Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = oOrder.Student;
            txtStudent.Enabled = false;
            txtOrderID.Enabled = false;
            
            //MessageBox.Show(oOrder.Teacher+ oOrder.Student + oOrder.CustomerID);

            this.ShowHeader();
            this.ShowDetail();
     
            this.txtProductID.Focus();

        }

        public frmOrder(Order _oOrder) //FixedCellSeparatorUIElement Scanning
        {
            InitializeComponent();
            oOrder = _oOrder;
            
            oOrder.oCustomer.Brochures.Load(oOrder.CompanyID, oOrder.CustomerID);
            
            this.CompanyID          = oOrder.CompanyID;
            txtCustomerID.Text      = oOrder.CustomerID;
            txtCustomerID.Enabled   = false;
            txtTeacher.Text         = oOrder.Teacher;
            txtTeacher.Enabled      = false;
            txtStudent.Text         = oOrder.Student;
            //txtStudent.Enabled = false;
            txtOrderID.Enabled      = false;

            this.ShowHeader();
            this.ShowDetail();
            txtCollected.Focus();

            this.txtProductID.Focus();

           

        }
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(621);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-7);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtStudent = new System.Windows.Forms.RichTextBox();
            this.txtPhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lPhone = new System.Windows.Forms.Label();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtBoxes = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPackedDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lPackedDate = new System.Windows.Forms.Label();
            this.txtRetailTax = new Signature.Windows.Forms.MaskedLabel();
            this.txtNoItems = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCollected = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDiff = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.table = new XPTable.Models.Table();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.lbCompany = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripViewInternet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripViewImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.wordDictionary = new NetSpell.SpellChecker.Dictionary.WordDictionary(this.components);
            this.spelling = new NetSpell.SpellChecker.Spelling(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Signature.Forms.Properties.Resources.background1;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ultraGroupBox2);
            this.panel1.Controls.Add(this.ultraGroupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 608);
            this.panel1.TabIndex = 0;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.txtStudent);
            this.ultraGroupBox2.Controls.Add(this.txtPhone);
            this.ultraGroupBox2.Controls.Add(this.lPhone);
            this.ultraGroupBox2.Controls.Add(this.txtOrderID);
            this.ultraGroupBox2.Controls.Add(this.label13);
            this.ultraGroupBox2.Controls.Add(this.txtName);
            this.ultraGroupBox2.Controls.Add(this.txtTeacher);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.label2);
            this.ultraGroupBox2.Controls.Add(this.label1);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(3, 39);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(637, 106);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtStudent
            // 
            this.txtStudent.AcceptsTab = true;
            this.txtStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudent.AutoWordSelection = true;
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(90, 71);
            this.txtStudent.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtStudent.MaxLength = 40;
            this.txtStudent.Multiline = false;
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(402, 27);
            this.txtStudent.TabIndex = 2;
            this.txtStudent.Text = "";
            this.txtStudent.WordWrap = false;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPhone
            // 
            this.txtPhone.AllowDrop = true;
            appearance1.TextHAlignAsString = "Right";
            this.txtPhone.Appearance = appearance1;
            this.txtPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhone.InputMask = "(###) ###-####";
            this.txtPhone.Location = new System.Drawing.Point(546, 72);
            this.txtPhone.Name = "txtRetail";
            this.txtPhone.PromptChar = ' ';
            this.txtPhone.Size = new System.Drawing.Size(80, 20);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.Text = "() -";
            this.txtPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lPhone
            // 
            this.lPhone.BackColor = System.Drawing.Color.Transparent;
            this.lPhone.Location = new System.Drawing.Point(498, 73);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(42, 16);
            this.lPhone.TabIndex = 3;
            this.lPhone.Text = "Phone:";
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtOrderID.Appearance = appearance2;
            this.txtOrderID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOrderID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtOrderID.InputMask = "nnnnnnnnnn";
            this.txtOrderID.Location = new System.Drawing.Point(542, 44);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.PromptChar = ' ';
            this.txtOrderID.Size = new System.Drawing.Size(83, 20);
            this.txtOrderID.TabIndex = 5;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(473, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Order ID:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance3;
            this.txtName.Location = new System.Drawing.Point(156, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(471, 19);
            this.txtName.TabIndex = 19;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(90, 39);
            this.txtTeacher.MaxLength = 30;
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(361, 26);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(90, 14);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(33, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid;
            this.ultraGroupBox1.Controls.Add(this.txtQuantity);
            this.ultraGroupBox1.Controls.Add(this.txtBoxes);
            this.ultraGroupBox1.Controls.Add(this.label10);
            this.ultraGroupBox1.Controls.Add(this.label12);
            this.ultraGroupBox1.Controls.Add(this.txtPackedDate);
            this.ultraGroupBox1.Controls.Add(this.lPackedDate);
            this.ultraGroupBox1.Controls.Add(this.txtRetailTax);
            this.ultraGroupBox1.Controls.Add(this.txtNoItems);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtEntryDate);
            this.ultraGroupBox1.Controls.Add(this.label6);
            this.ultraGroupBox1.Controls.Add(this.label7);
            this.ultraGroupBox1.Controls.Add(this.txtCollected);
            this.ultraGroupBox1.Controls.Add(this.txtDiff);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.txtRetail);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label8);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(646, 145);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(140, 451);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.TextHAlignAsString = "Right";
            this.txtQuantity.Appearance = appearance4;
            this.txtQuantity.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtQuantity.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtQuantity.FormatString = "###";
            this.txtQuantity.InputMask = "nnnn";
            this.txtQuantity.Location = new System.Drawing.Point(76, 28);
            this.txtQuantity.Name = "txtRetail";
            this.txtQuantity.PromptChar = ' ';
            this.txtQuantity.Size = new System.Drawing.Size(50, 20);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtBoxes
            // 
            this.txtBoxes.AllowDrop = true;
            appearance5.TextHAlignAsString = "Right";
            this.txtBoxes.Appearance = appearance5;
            this.txtBoxes.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBoxes.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBoxes.FormatString = "###,###";
            this.txtBoxes.InputMask = "nnnnnnnnn";
            this.txtBoxes.Location = new System.Drawing.Point(22, 407);
            this.txtBoxes.Name = "txtRetail";
            this.txtBoxes.ReadOnly = true;
            this.txtBoxes.Size = new System.Drawing.Size(68, 20);
            this.txtBoxes.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(19, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 48;
            this.label10.Text = "Boxes:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(19, 304);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 47;
            this.label12.Text = "Entry Date:";
            // 
            // txtPackedDate
            // 
            this.txtPackedDate.AllowDrop = true;
            appearance6.TextHAlignAsString = "Right";
            this.txtPackedDate.Appearance = appearance6;
            this.txtPackedDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPackedDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtPackedDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtPackedDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtPackedDate.Location = new System.Drawing.Point(22, 365);
            this.txtPackedDate.Name = "txtRetail";
            this.txtPackedDate.ReadOnly = true;
            this.txtPackedDate.Size = new System.Drawing.Size(73, 20);
            this.txtPackedDate.TabIndex = 46;
            this.txtPackedDate.Text = "//";
            // 
            // lPackedDate
            // 
            this.lPackedDate.BackColor = System.Drawing.Color.Transparent;
            this.lPackedDate.Enabled = false;
            this.lPackedDate.Location = new System.Drawing.Point(19, 346);
            this.lPackedDate.Name = "lPackedDate";
            this.lPackedDate.Size = new System.Drawing.Size(76, 16);
            this.lPackedDate.TabIndex = 45;
            this.lPackedDate.Text = "Packed Date:";
            // 
            // txtRetailTax
            // 
            this.txtRetailTax.AllowDrop = true;
            appearance7.FontData.BoldAsString = "True";
            this.txtRetailTax.Appearance = appearance7;
            this.txtRetailTax.Location = new System.Drawing.Point(4, 200);
            this.txtRetailTax.Name = "txtDescription";
            this.txtRetailTax.Size = new System.Drawing.Size(125, 21);
            this.txtRetailTax.TabIndex = 40;
            this.txtRetailTax.TabStop = true;
            this.txtRetailTax.Value = null;
            // 
            // txtNoItems
            // 
            this.txtNoItems.AllowDrop = true;
            appearance8.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance8;
            this.txtNoItems.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNoItems.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoItems.FormatString = "###,###";
            this.txtNoItems.InputMask = "nnnnnnnnn";
            this.txtNoItems.Location = new System.Drawing.Point(58, 123);
            this.txtNoItems.Name = "txtRetail";
            this.txtNoItems.ReadOnly = true;
            this.txtNoItems.Size = new System.Drawing.Size(68, 20);
            this.txtNoItems.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(5, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Items:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            this.txtEntryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance9;
            this.txtEntryDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(22, 323);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 44;
            this.txtEntryDate.Text = "//";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Retail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(12, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Diff:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCollected
            // 
            this.txtCollected.AllowDrop = true;
            this.txtCollected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.TextHAlignAsString = "Right";
            this.txtCollected.Appearance = appearance10;
            this.txtCollected.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCollected.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCollected.FormatString = "###,###.##";
            this.txtCollected.InputMask = "{LOC}nnnnnnn.nn";
            this.txtCollected.Location = new System.Drawing.Point(22, 264);
            this.txtCollected.Name = "txtRetail";
            this.txtCollected.PromptChar = ' ';
            this.txtCollected.Size = new System.Drawing.Size(85, 20);
            this.txtCollected.TabIndex = 2;
            this.txtCollected.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDiff
            // 
            this.txtDiff.AllowDrop = true;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.txtDiff.Appearance = appearance11;
            this.txtDiff.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDiff.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtDiff.InputMask = "{double:-6.4}";
            this.txtDiff.Location = new System.Drawing.Point(58, 174);
            this.txtDiff.Name = "txtRetail";
            this.txtDiff.PromptChar = ' ';
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(68, 20);
            this.txtDiff.TabIndex = 42;
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
            appearance12.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance12;
            this.txtRetail.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(58, 149);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(68, 20);
            this.txtRetail.TabIndex = 41;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(12, 28);
            this.txtProductID.MaxLength = 10;
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(52, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(19, 245);
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
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.table);
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(2, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 451);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = " Order Detail ";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // table
            // 
            this.table.AlternatingRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.table.EnableToolTips = true;
            this.table.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.GridColor = System.Drawing.SystemColors.ControlDark;
            this.table.GridLines = XPTable.Models.GridLines.Both;
            this.table.GridLineStyle = XPTable.Models.GridLineStyle.Dot;
            this.table.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.table.Location = new System.Drawing.Point(5, 64);
            this.table.MultiSelect = true;
            this.table.Name = "table";
            this.table.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.table.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.table.Size = new System.Drawing.Size(622, 381);
            this.table.SortedColumnBackColor = System.Drawing.Color.Transparent;
            this.table.TabIndex = 10;
            this.table.UnfocusedSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.table.UnfocusedSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "Item#";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MinLength = 35;
            ultraGridColumn2.MinWidth = 200;
            ultraGridColumn2.Width = 409;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance13.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance13;
            ultraGridColumn3.Format = "$####.00";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nn";
            ultraGridColumn3.Width = 57;
            appearance14.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance14;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.Width = 61;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            this.Grid.Location = new System.Drawing.Point(8, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(623, 39);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.Grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.lbCompany);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(646, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 108);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lbCompany
            // 
            this.lbCompany.BackColor = System.Drawing.Color.Transparent;
            this.lbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompany.Location = new System.Drawing.Point(74, 16);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(33, 19);
            this.lbCompany.TabIndex = 13;
            this.lbCompany.Text = "F07";
            this.lbCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(5, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "Company:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripViewInternet,
            this.toolStripSeparator2,
            this.toolStripViewImage,
            this.toolStripSeparator1,
            this.toolStripPrint});
            this.tStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Padding = new System.Windows.Forms.Padding(0);
            this.tStrip.Size = new System.Drawing.Size(791, 25);
            this.tStrip.TabIndex = 53;
            this.tStrip.Text = "toolStrip1";
            // 
            // toolStripViewInternet
            // 
            this.toolStripViewInternet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripViewInternet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripViewInternet.Image")));
            this.toolStripViewInternet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripViewInternet.Name = "toolStripViewInternet";
            this.toolStripViewInternet.Size = new System.Drawing.Size(80, 22);
            this.toolStripViewInternet.Text = "View Internet";
            this.toolStripViewInternet.Click += new System.EventHandler(this.toolStripViewInternet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripViewImage
            // 
            this.toolStripViewImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripViewImage.Name = "toolStripViewImage";
            this.toolStripViewImage.Size = new System.Drawing.Size(72, 22);
            this.toolStripViewImage.Text = "View Image";
            this.toolStripViewImage.Click += new System.EventHandler(this.bPrintImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripPrint
            // 
            this.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPrint.Image")));
            this.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrint.Name = "toolStripPrint";
            this.toolStripPrint.Size = new System.Drawing.Size(36, 22);
            this.toolStripPrint.Text = "Print";
            this.toolStripPrint.Click += new System.EventHandler(this.bPrint_Click_1);
            // 
            // wordDictionary
            // 
            this.wordDictionary.DictionaryFile = "FirstNames.dic";
            this.wordDictionary.DictionaryFolder = "I:\\Dictionary";
            // 
            // spelling
            // 
            this.spelling.AlertComplete = false;
            this.spelling.Dictionary = this.wordDictionary;
            this.spelling.IgnoreAllCapsWords = false;
            this.spelling.IgnoreWordsWithDigits = true;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(791, 637);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmOrder";
            this.ShowIcon = true;
            this.Text = "Enter Orders";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Shown += new System.EventHandler(this.frmOrder_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region  Events	
  		private void frmOrder_Load(object sender, System.EventArgs e)
		{

            
            this.txtPhone.Visible = false;
            this.lPhone.Visible = false;

            this.Text += " - " + this.CompanyID;
            this.lbCompany.Text = this.CompanyID;
            this.txtCustomerID.Focus();

            IDetail = new Order.Item();

            if (_OrderProcess == OrderProcess.Discrepancy)
               toolStripPrint.Enabled = false;

            if (_OrderProcess == OrderProcess.ScanFixing)
            {
                Screen[] screens = Screen.AllScreens;
                this.Left = screens[0].Bounds.Width - this.Width - 20;
            }

            tStrip.Renderer = new Signature.Windows.Forms.WindowsVistaRenderer();

            this.spelling.EndOfText += new NetSpell.SpellChecker.Spelling.EndOfTextEventHandler(this.spelling_EndOfText);
            this.spelling.DeletedWord += new NetSpell.SpellChecker.Spelling.DeletedWordEventHandler(this.spelling_DeletedWord);
            this.spelling.ReplacedWord += new NetSpell.SpellChecker.Spelling.ReplacedWordEventHandler(this.spelling_ReplacedWord);
            this.LoadTable();


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

            #region txtOrderID
            if (sender == txtOrderID)
            {

                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtOrderID.Text.Trim() == "")
                    {
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }

                    if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
                    {
                        if (CompanyID != oOrder.CompanyID)
                        {
                            MessageBox.Show("Different Order's Company/Season");
                            txtOrderID.Clear();
                            txtOrderID.Focus();
                            return;
                        }

                        txtCustomerID.Text = oOrder.CustomerID;
                        txtTeacher.Text = oOrder.Teacher;
                        txtStudent.Text = oOrder.Student;
                        txtName.Text = oOrder.oCustomer.Name;
                        ShowOrder();

                      
                        txtProductID.Focus();
                        return;
                    }
                    else if (oOrder.Deleter(txtOrderID.Text) != "")
                    {
                        MessageBox.Show("Order deleted by " + oOrder.Deleter(txtOrderID.Text));
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Order not found...");
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }

                }

            }
            #endregion
            #region txtCustomerID
            if (sender==txtCustomerID)	
			{
                Boolean IsF2 = false;
                
                if (e.KeyCode.ToString()=="F2")
				{
                    if (oOrder.oCustomer.View())
                    {
                        IsF2 = true;
                        this.txtCustomerID.Text = oOrder.oCustomer.ID;
                        this.txtTeacher.Focus();
                     }
                    this.txtName.Text = oOrder.oCustomer.Name;
                    oOrder.oCustomer.Brochures.Load(CompanyID, txtCustomerID.Text);
                    this.IsCookieDough = oOrder.oCustomer.IsCookieDough;
                    return;
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
				{
                    IsF2 = false;
                    if (!this.get_customer())
					{
					    this.txtCustomerID.Focus();
						return;
					}
                    oOrder.oCustomer.Brochures.Load(CompanyID, txtCustomerID.Text);
                    this.IsCookieDough = oOrder.oCustomer.IsCookieDough;
                    Clear();
                    this.txtTeacher.Focus();
                    return;
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
                        //this.txtTeacher.Clear();
                        this.txtStudent.Clear();
                        this.txtStudent.Focus();
                        return;
                    }
                    else
                    {
                        if ((MessageBox.Show("This a duplicated teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                this.txtTeacher.Clear();
                                return; 
                                
                            }
                        
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



                    if (oOrder.View(txtCustomerID.Text, txtTeacher.Text))
                    {
                            txtCustomerID.Text = oOrder.CustomerID;
                            txtTeacher.Text = oOrder.Teacher;
                            this.txtStudent.Text = oOrder.Student;
                            txtName.Text = oOrder.oCustomer.Name;
                            
                            ShowOrder();
                            if (IsCookieDough)
                            {
                                this.txtPhone.Visible = true;
                                this.lPhone.Visible = true;
                                this.txtPhone.Focus();
                            }
                            else
                            {
                                this.txtPhone.Visible = false;
                                this.lPhone.Visible = false;
                                this.txtProductID.Focus();
                            }
                            return;
                        
                    }
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    oOrder.oStudent.ID = txtStudent.Text;
                    if (oOrder.oStudent.ID != "")
                    {
                        if (_OrderProcess == OrderProcess.Enter)
                        {

                            this.Clear();
                            oOrder.Clear();
                            if (oOrder.Find(txtTeacher.Text, txtStudent.Text))
                                ShowOrder();
                            
                            if (IsCookieDough)
                            {
                                this.txtPhone.Visible = true;
                                this.lPhone.Visible = true;
                                this.txtPhone.Focus();
                            }
                            else
                            {
                                this.txtPhone.Visible = false;
                                this.lPhone.Visible = false;
                                this.txtProductID.Focus();
                            }
                            return;
                        }
                        else
                        {
                            this.txtProductID.Focus();
                        }

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

					if (oOrder.oProduct.View(oOrder.oCustomer))
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
                        this.IDetail.Price          = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);    //oOrder.oCustomer.PriceListID=="1"?oOrder.oProduct.Price_2:oOrder.oProduct.Price;
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
                        Global.playSimpleSound();   
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
                    if (!oOrder.oProduct.Find(txtProductID.Text))
                    {
                        txtProductID.Text = "";
                        txtProductID.Focus();
                        return;
                    }
                    
                    if (this.txtQuantity.Text != "" )
					{
                        this.AddItem();
//                        ActiveRow();
                        this.txtQuantity.Text = "";
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
                if (txtCustomerID.Text.Trim() == "")
                {
                    MessageBox.Show("No customer entered");
                    return;
                }

                
                if (oOrder.Collected != txtCollected.Number)
                {
                    oOrder.Collected = txtCollected.Number;
                    getTotals();
                }
                
                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Return)
                {
                    if (!oOrder.oCustomer.Find(txtCustomerID.Text))
                    {
                        MessageBox.Show("Please enter a valid Customer ID/School ID ");
                        txtCustomerID.Focus();
                        return;
                    }
                    
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

                    if (_OrderProcess != OrderProcess.Enter)
                    {
                        this.IsSaved = true;
                        this.Close();
                    }
                    Clear();
                    txtStudent.Clear();
                    txtStudent.Focus();

                    return;
                 }

             }
            #endregion
            #region txtPhone
             if (sender == this.txtPhone)
             {
                 if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                 {
                     oOrder.Phone = txtPhone.Value.ToString();
                     txtProductID.Focus();
                     return;
                 }

             }
             #endregion
            #region Grid
             if (sender==this.Grid)	
			{
				if (e.KeyCode.ToString()=="Delete")
				{
					this.DeleteItem(false);
					return;
				}
                if (e.KeyCode.ToString() == "F8" || e.KeyCode == Keys.PageDown)
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
                    if (sender == txtStudent && oOrder.Type == OrderType.Regular)
                        txtTeacher.Text = "";
                    else
                        return;
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    this.Grid.Focus();
                    break;
                case Keys.F5:
                    {
                        Clear();
                        txtTeacher.Clear();
                        txtStudent.Clear();
                        txtStudent.Focus();
                       
                    }

                    break;
                case Keys.F3:
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    this.txtCollected.Focus();
                    break;
                case Keys.PageUp:
                    if (oOrder.ID == "0")
                    {
                        if ((MessageBox.Show("Save this order first?", "New Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            getTotals();
                            oOrder.CompanyID = CompanyID;
                            oOrder.CustomerID = txtCustomerID.Text;
                            oOrder.Teacher = txtTeacher.Text;
                            oOrder.Student = txtStudent.Text;
                            oOrder.Collected = Convert.ToDouble(txtCollected.Text);

                            oOrder.Save(OrderType.Regular);
                            Shortage();
                            return;

                        }
                    }else
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
            
            if (Convert.ToInt32(Grid.ActiveRow.Cells["Quantity"].Value.ToString()) == 0)
                this.DeleteItem(false);
            getTotals();
        }
        private void txtProductID_Enter(object sender, EventArgs e)
        {
            txtQuantity.Enabled = false;
        }
        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                if (oOrder.oCustomer.Find(txtCustomerID.Text))
                {
                    if (oOrder.oCustomer.HasChanged)
                        oOrder.oCustomer.GetCurrentTotalsByBrochure();
                }
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

        private void spelling_DeletedWord(object sender, NetSpell.SpellChecker.SpellingEventArgs e)
        {
            int start = this.txtStudent.SelectionStart;
            int length = this.txtStudent.SelectionLength;

            this.txtStudent.Select(e.TextIndex, e.Word.Length);
            this.txtStudent.SelectedText = "";

            if (start > this.txtStudent.Text.Length)
                start = this.txtStudent.Text.Length;

            if ((start + length) > this.txtStudent.Text.Length)
                length = 0;

            this.txtStudent.Select(start, length);
        }

        private void spelling_ReplacedWord(object sender, NetSpell.SpellChecker.ReplaceWordEventArgs e)
        {
            int start = this.txtStudent.SelectionStart;
            int length = this.txtStudent.SelectionLength;

            this.txtStudent.Select(e.TextIndex, e.Word.Length);
            this.txtStudent.SelectedText = e.ReplacementWord;

            if (start > this.txtStudent.Text.Length)
                start = this.txtStudent.Text.Length;

            if ((start + length) > this.txtStudent.Text.Length)
                length = 0;

            this.txtStudent.Select(start, length);
            //this.txtStudent.Text = txtStudent.Text.ToUpper();
        }

        private void spelling_EndOfText(object sender, System.EventArgs e)
        {
            Console.WriteLine("EndOfText");
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
        private bool get_customer()
		{	  
            if (this.txtCustomerID.Text=="")
				return false;

            oOrder.CustomerID = this.txtCustomerID.Text;
            if (!oOrder.oCustomer.Find(oOrder.CustomerID)) 
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
            txtEntryDate.Enabled = false;
            txtEntryDate.Text = DateTime.Now.Date.ToString();
            txtCollected.Clear();
            txtPackedDate.Clear();
            txtPackedDate.Enabled = false;
            lPackedDate.Enabled = false;
            txtBoxes.Clear();
            txtBoxes.Enabled = false;
            txtRetailTax.Text = "";
            txtOrderID.Text = "";
            txtPhone.Text = "";
            for (int x = Grid.Rows.Count; x != 0; x--)
            {
                Grid.Rows[0].Delete(false);
            }
            txtStudent.Visible = true;

        }
        private bool ShowHeader()
        {
            //Header
            txtOrderID.Text = oOrder.ID;
            txtRetail.Text = oOrder.Retail.ToString();
            txtNoItems.Text = oOrder.NoItems.ToString();
            txtCollected.Text = oOrder.Collected.ToString();
            txtDiff.Text = oOrder.Diff.ToString();
            txtEntryDate.Text = oOrder.Date.ToString();
            if (oOrder.Tax >0 )
                txtRetailTax.Text = "R/Tax : " + (oOrder.Retail + oOrder.Tax).ToString();
            if (oOrder.PackedDate != Global.DNull)
            {
                txtPackedDate.Text = oOrder.PackedDate.ToString();
                txtBoxes.Text = oOrder.BoxesPacked.ToString();
            }
            if (IsCookieDough)
            {
                txtPhone.Visible = true;
                lPhone.Visible = true;
                txtPhone.Text = oOrder.Phone;
            }
            else
            {
                txtPhone.Visible = false;
                lPhone.Visible = false;
            }

            
            if (oOrder.oImage.ID != 0)
               toolStripViewImage.Enabled = true;
            else
               toolStripViewImage.Enabled = false;

           if (oOrder.IOrderID != 0)
               toolStripViewInternet.Enabled = true;
           else
               toolStripViewInternet.Enabled = false;

            //if (this._OrderProcess == OrderProcess.ScanFixing)

           
           /*
           Student oStudent = new Student(this.CompanyID);
           
           this.spelling.Text = oStudent.GetFirstName(oOrder.Student.ToLower());
           if (this.spelling.SpellCheck())
           {
               txtFirstName.Visible = true;
               txtStudent.Visible = false;

               //    txtLastName.Visible = true;
               
               this.spelling.Suggest();

               txtFirstName.Items.Clear();
               txtFirstName.Text = oStudent.GetFirstName(oOrder.Student);
               foreach (String suggestion in this.spelling.Suggestions)
               {
                   txtFirstName.Items.Add(suggestion.ToUpper());
               }
           }
            */
          
           return true;
        }
        private bool ShowDetail()
        {
            
            this.table.TableModel = new TableModel();
            table.TableModel.Rows.Clear();
            foreach (Order.Item  row in oOrder.Items)
            {
                this.table.TableModel.Rows.Add(new Row(new Cell[] {new Cell(row.ProductID),
																   new Cell(row.Description),
                                                                   new Cell(row.Price.ToString()),
                                                                   new Cell(row.Quantity.ToString())
																  })
                                                                   );

            }
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

                this.table.TableModel.Rows.Add(new Row(new Cell[] {new Cell(item.ProductID),
																   new Cell(item.Description),
                                                                   new Cell(item.Price.ToString()),
                                                                   new Cell(item.Quantity.ToString())
																  })
                                                               );

            
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
            oOrder.CustomerID   = txtCustomerID.Text;
            oOrder.Teacher      = txtTeacher.Text;
            oOrder.Student      = txtStudent.Text;
            oOrder.Collected    = Convert.ToDouble(txtCollected.Text);
            oOrder.Phone        = txtPhone.Value.ToString();

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
            txtStudent.Clear();
            txtStudent.Focus();
            return;
        }
        private void Shortage()
        {
            frmShortage frm = new frmShortage(oOrder);
           
            frm.ShowDialog();
        }


		#endregion

        private void LoadTable()
        {
            // get the sample images resource
            System.Reflection.Assembly myAssembly;
            myAssembly = this.GetType().Assembly;
            //ResourceManager myManager = new ResourceManager("MediaPlayerStyle.Images", myAssembly);

            this.table.BeginUpdate();


            TextColumn ProductIDColumn = new TextColumn();
            ProductIDColumn.Text = "Item #";
            ProductIDColumn.ToolTipText = "Product ID";
            ProductIDColumn.Width = 100;
            ProductIDColumn.Editable = false;

            TextColumn NameColumn = new TextColumn();
            NameColumn.Text = "Description";
            NameColumn.ToolTipText = "Product Name";
            NameColumn.Width = 300;
            NameColumn.Editable = false;

            TextColumn PriceColumn = new TextColumn();
            PriceColumn.Text = "Price";
            PriceColumn.ToolTipText = "Product Price";
            PriceColumn.Width = 100;
            PriceColumn.Format = "$####.99";
            PriceColumn.Editable = false;
            PriceColumn.Alignment = ColumnAlignment.Center;

            TextColumn QuantityColumn = new TextColumn();
            QuantityColumn.Text = "Quantity";
            QuantityColumn.ToolTipText = "Quantity";
            QuantityColumn.Width = 100;
            QuantityColumn.Editable = true;
            
            
            /*
            ComboBoxColumn UserIDColumn = new ComboBoxColumn();
            UserIDColumn.Text = "User ID";
            UserIDColumn.ToolTipText = "User ID";
            UserIDColumn.Width = 100;
            UserIDColumn.Editable = true;
            UserIDColumn.Editor = GetActiveUsers();
            */
                        
            this.table.ColumnModel = new ColumnModel(new Column[] {ProductIDColumn,
																	  NameColumn,
																	  PriceColumn,
																	  QuantityColumn});



            this.table.HeaderRenderer = new XPTable.Renderers.GradientHeaderRenderer();

            this.table.FullRowSelect = true;

            this.table.EndUpdate();

        }

        private void toolStripViewInternet_Click(object sender, EventArgs e)
        {
            if (Global.CurrentUser == "SCOTT" || Global.CurrentUser == "ALVARO" || Global.CurrentUser == "RUSS" || Global.CurrentUser == "VICTORIA")
            {
                String myTargetURL = "http://www.sigfund.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                System.Diagnostics.Process.Start(myTargetURL);
            }
        }

        private void frmOrder_Shown(object sender, EventArgs e)
        {
            if (_OrderProcess == OrderProcess.ScanFixing)
            {
                txtStudent.Text = oOrder.Student;
                this.spelling.Text = this.txtStudent.Text;
                this.spelling.SpellCheck();
            }
        }

	}
}
