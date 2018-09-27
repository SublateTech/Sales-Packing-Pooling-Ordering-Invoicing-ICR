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
	public sealed class frmOrderGPI : frmBase
	{
		#region declarations		
        private Panel panel1;
        private Signature.Windows.Forms.GroupBox gHeaderOrder;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label lStudent;
        private Label lTeacher;
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
        internal Signature.Windows.Forms.RichTextBox txtStudent;
        private Signature.Windows.Forms.ComboBox txtTeacher;

        #endregion
        
		public  Order oOrder;
        private Order.Item IDetail;
        public  OrderProcess _OrderProcess = OrderProcess.Enter;
        private Boolean IsDiff = false;
        private Boolean IsCookieDough = false;
        private Signature.SpellChecker.Dictionary.WordDictionary wordDictionary;
        private IContainer components;
        private Signature.SpellChecker.Spelling spelling;
        public Boolean IsSaved = false;
        public Ticket oTicket;

        public frmOrderGPI()
		{
			InitializeComponent();
            oOrder = new Order(base.CompanyID);
            oTicket = new Ticket(base.CompanyID);
            oOrder.Type = OrderType.Regular;
            this.toolStripViewImage.Enabled = false;
            this.toolStripViewInternet.Enabled = false;
		}
        public frmOrderGPI(String CustomerID, String Teacher, String Student)
        {
            InitializeComponent();
            oOrder = new Order(base.CompanyID);
            oTicket = new Ticket(base.CompanyID);
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
        public frmOrderGPI(ref Discrepancy _oOrder)
        {
            InitializeComponent();
            oTicket = new Ticket(base.CompanyID);
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

        public frmOrderGPI(Order _oOrder) //FixedCellSeparatorUIElement Scanning
        {
            InitializeComponent();
            oOrder = _oOrder;
            
            oOrder.oCustomer.Brochures.Load(oOrder.CompanyID, oOrder.CustomerID);
            
            this.CompanyID          = oOrder.CompanyID;
            txtCustomerID.Text      = oOrder.CustomerID;
            oOrder.oCustomer.Find(oOrder.CustomerID);
            txtName.Text = oOrder.oCustomer.Name;
            txtTeacher.Text         = oOrder.Teacher;
            txtStudent.Text         = oOrder.Student;
            //txtStudent.Enabled = false;
            txtCustomerID.Enabled = false;
            if (!this.IsGiftAvenue)
            {
                
                txtTeacher.Enabled = false;
                txtOrderID.Enabled = false;
            }
            
            this.ShowHeader();
            this.ShowDetail();

            if (!this.IsGiftAvenue)
                this.txtProductID.Focus();
            else
            {
                this.gHeaderOrder.Focus();
                txtTeacher.Focus();
            }

           

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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TicketID", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Customized", 4);
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(625);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-5);
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderGPI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gHeaderOrder = new Signature.Windows.Forms.GroupBox();
            this.txtTeacher = new Signature.Windows.Forms.ComboBox();
            this.txtStudent = new Signature.Windows.Forms.RichTextBox();
            this.txtPhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lPhone = new System.Windows.Forms.Label();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.lStudent = new System.Windows.Forms.Label();
            this.lTeacher = new System.Windows.Forms.Label();
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
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripViewInternet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripViewImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.wordDictionary = new Signature.SpellChecker.Dictionary.WordDictionary(this.components);
            this.spelling = new Signature.SpellChecker.Spelling(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gHeaderOrder)).BeginInit();
            this.gHeaderOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 612);
            this.txtStatus.Size = new System.Drawing.Size(791, 29);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gHeaderOrder);
            this.panel1.Controls.Add(this.ultraGroupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 612);
            this.panel1.TabIndex = 0;
            // 
            // gHeaderOrder
            // 
            this.gHeaderOrder.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.gHeaderOrder.Appearance = appearance1;
            this.gHeaderOrder.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gHeaderOrder.Controls.Add(this.txtTeacher);
            this.gHeaderOrder.Controls.Add(this.txtStudent);
            this.gHeaderOrder.Controls.Add(this.txtPhone);
            this.gHeaderOrder.Controls.Add(this.lPhone);
            this.gHeaderOrder.Controls.Add(this.txtOrderID);
            this.gHeaderOrder.Controls.Add(this.label13);
            this.gHeaderOrder.Controls.Add(this.txtName);
            this.gHeaderOrder.Controls.Add(this.txtCustomerID);
            this.gHeaderOrder.Controls.Add(this.label9);
            this.gHeaderOrder.Controls.Add(this.lStudent);
            this.gHeaderOrder.Controls.Add(this.lTeacher);
            this.gHeaderOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gHeaderOrder.Location = new System.Drawing.Point(3, 37);
            this.gHeaderOrder.Name = "ultraGroupBox2";
            this.gHeaderOrder.Size = new System.Drawing.Size(783, 108);
            this.gHeaderOrder.TabIndex = 0;
            this.gHeaderOrder.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtTeacher.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(100, 39);
            this.txtTeacher.Name = "txtCollect";
            this.txtTeacher.Size = new System.Drawing.Size(360, 26);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtStudent
            // 
            this.txtStudent.AcceptsTab = true;
            this.txtStudent.AllowDrop = true;
            this.txtStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStudent.AutoWordSelection = true;
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(100, 71);
            this.txtStudent.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtStudent.MaxLength = 40;
            this.txtStudent.Multiline = false;
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(402, 29);
            this.txtStudent.TabIndex = 2;
            this.txtStudent.WordWrap = false;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPhone
            // 
            this.txtPhone.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtPhone.Appearance = appearance2;
            this.txtPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPhone.InputMask = "(###) ###-####";
            this.txtPhone.Location = new System.Drawing.Point(598, 76);
            this.txtPhone.Name = "txtRetail";
            this.txtPhone.PromptChar = ' ';
            this.txtPhone.Size = new System.Drawing.Size(80, 20);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "() -";
            this.txtPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lPhone
            // 
            this.lPhone.BackColor = System.Drawing.Color.Transparent;
            this.lPhone.Location = new System.Drawing.Point(546, 77);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(42, 16);
            this.lPhone.TabIndex = 3;
            this.lPhone.Text = "Phone:";
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtOrderID.Appearance = appearance3;
            this.txtOrderID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOrderID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtOrderID.InputMask = "nnnnnnnnnn";
            this.txtOrderID.Location = new System.Drawing.Point(595, 45);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.PromptChar = ' ';
            this.txtOrderID.Size = new System.Drawing.Size(83, 20);
            this.txtOrderID.TabIndex = 4;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(522, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Order ID:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance4;
            this.txtName.Location = new System.Drawing.Point(162, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(471, 19);
            this.txtName.TabIndex = 19;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(100, 14);
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
            this.label9.TabIndex = 0;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lStudent
            // 
            this.lStudent.BackColor = System.Drawing.Color.Transparent;
            this.lStudent.Location = new System.Drawing.Point(7, 76);
            this.lStudent.Name = "lStudent";
            this.lStudent.Size = new System.Drawing.Size(80, 16);
            this.lStudent.TabIndex = 0;
            this.lStudent.Text = "Student/Seller:";
            this.lStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTeacher
            // 
            this.lTeacher.BackColor = System.Drawing.Color.Transparent;
            this.lTeacher.Location = new System.Drawing.Point(7, 45);
            this.lTeacher.Name = "lTeacher";
            this.lTeacher.Size = new System.Drawing.Size(80, 16);
            this.lTeacher.TabIndex = 0;
            this.lTeacher.Text = "Teacher/Class:";
            this.lTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance5.AlphaLevel = ((short)(95));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance5;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.ultraGroupBox1.Location = new System.Drawing.Point(646, 153);
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
            appearance6.TextHAlignAsString = "Right";
            this.txtQuantity.Appearance = appearance6;
            this.txtQuantity.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtQuantity.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtQuantity.FormatString = "######";
            this.txtQuantity.InputMask = "nnnnnn";
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
            appearance7.TextHAlignAsString = "Right";
            this.txtBoxes.Appearance = appearance7;
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
            appearance8.TextHAlignAsString = "Right";
            this.txtPackedDate.Appearance = appearance8;
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
            appearance9.FontData.BoldAsString = "True";
            this.txtRetailTax.Appearance = appearance9;
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
            appearance10.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance10;
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
            appearance11.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance11;
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
            appearance12.TextHAlignAsString = "Right";
            this.txtCollected.Appearance = appearance12;
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
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.txtDiff.Appearance = appearance13;
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
            appearance14.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance14;
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
            appearance15.AlphaLevel = ((short)(95));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance15;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(2, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 451);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = " Order Detail ";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Appearance = appearance16;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "Item#";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MinLength = 35;
            ultraGridColumn2.MinWidth = 200;
            ultraGridColumn2.Width = 394;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance17.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance17;
            ultraGridColumn3.Format = "$####.000";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nnn";
            ultraGridColumn3.Width = 61;
            appearance18.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance18;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.PromptChar = ' ';
            ultraGridColumn4.Width = 61;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance21.Image = global::Signature.Forms.Properties.Resources.index_preferences;
            ultraGridColumn6.CellButtonAppearance = appearance21;
            ultraGridColumn6.DataType = typeof(bool);
            ultraGridColumn6.Header.Caption = "*";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn6.Width = 24;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid.DisplayLayout.Override.RowAlternateAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.DarkGray;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance20;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(5, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(627, 426);
            this.Grid.TabIndex = 0;
            this.Grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            this.Grid.AfterCellActivate += new System.EventHandler(this.Grid_AfterCellActivate);
            this.Grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
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
            // frmOrderGPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(791, 641);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmOrderGPI";
            this.ShowIcon = true;
            this.Text = "Enter Orders";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Shown += new System.EventHandler(this.frmOrder_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gHeaderOrder)).EndInit();
            this.gHeaderOrder.ResumeLayout(false);
            this.gHeaderOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region  Events	
  		private void frmOrder_Load(object sender, System.EventArgs e)
		{
           // Grid.DisplayLayout.Bands[0].Columns[0]..Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            

            this.txtPhone.Visible = false;
            this.lPhone.Visible = false;

            this.Text += " - " + this.CompanyID;
          
            this.txtCustomerID.Focus();

            IDetail = new Order.Item();

            if (_OrderProcess == OrderProcess.Discrepancy)
               toolStripPrint.Enabled = false;

            if (_OrderProcess == OrderProcess.ScanFixing || _OrderProcess== OrderProcess.GiftAvenue)
            {
                Screen[] screens = Screen.AllScreens;
                this.Left = screens[0].Bounds.Width - this.Width - 20;
            }

            tStrip.Renderer = new Signature.Windows.Forms.WindowsVistaRenderer();

            this.spelling.EndOfText += new Signature.SpellChecker.Spelling.EndOfTextEventHandler(this.spelling_EndOfText);
            this.spelling.DeletedWord += new Signature.SpellChecker.Spelling.DeletedWordEventHandler(this.spelling_DeletedWord);
            this.spelling.ReplacedWord += new Signature.SpellChecker.Spelling.ReplacedWordEventHandler(this.spelling_ReplacedWord);

            if (this.CompanyID.Substring(0, 2) == "GA")
            {

                txtTeacher.Items.Add("ORDER");
                txtTeacher.Items.Add("RE-ORDER");
                lTeacher.Text = "Order Type:";
                lStudent.Text = "Reference:";
                txtTeacher.DropDownStyle = ComboBoxStyle.DropDown;
            }
            


		}
        private void bPrint_Click_1(object sender, EventArgs e)
        {
            if (txtOrderID.Text.Trim() == "")
                return;


            String PrinterName = Global.OpenPrintDialog();
            if (PrinterName != "")
            {
                
                switch (PrinterName.ToUpper())
                {
                    case "\\\\SRV1\\PACKING_1":
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
                    case "\\\\SRV1\\PACKING_5":
                        {
                            oOrder.OpenPrinter(4);
                            break;
                        }
                    case "\\\\SRV1\\WH_P5205":
                        {
                            oOrder.OpenPrinter(5);
                            break;
                        }
                    case "\\\\SRV1\\PLAIN":
                        {
                            oOrder.OpenPrinter(6);
                            break;
                        }
                    case "PACKING_5":
                        {
                            oOrder.OpenPrinter(7);
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
                    else if (oOrder.FindByIOrderID(Convert.ToInt32(txtOrderID.Text)) != 0)
                    {
                        txtOrderID.Text = oOrder.FindByIOrderID(Convert.ToInt32(txtOrderID.Text)).ToString();
                        SendKeys.Send("{ENTER}");
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
                    this.IsCookieDough = oOrder.oCustomer.Brochures.IsCookieDough;
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
                    this.IsCookieDough = oOrder.oCustomer.Brochures.IsCookieDough;
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
                        oOrder.TeacherID = 0;
                        //this.txtTeacher.Clear();
                        this.txtStudent.Clear();
                        this.txtStudent.Focus();
                        return;
                    }
                    else
                    {
                        if ((MessageBox.Show("This a duplicated teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                            {
                                this.txtTeacher.Text = "";
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

                        if (oOrder.IsBrochureControl)
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
                        }
                        this.IDetail.ProductID      = oOrder.oProduct.ID;
                        this.IDetail.Price          = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);    //oOrder.oCustomer.PriceListID=="1"?oOrder.oProduct.Price_2:oOrder.oProduct.Price;
                        this.IDetail.Description    = oOrder.oProduct.Description.ToString();
                        this.IDetail.Length         = oOrder.oProduct.Length;
                        this.IDetail.Width          = oOrder.oProduct.Width;
                        this.IDetail.Height         = oOrder.oProduct.Height;
                        this.IDetail.PackID         = oOrder.oProduct.PackID(oOrder.oCustomer);

                        this.txtProductID.Text = oOrder.oProduct.ID;
                        this.txtDescription.Text = oOrder.oProduct.Description;
                        this.txtQuantity.Text = "1";

                        
                        if (e.KeyCode == Keys.Return || oOrder.oProduct.IsCustomized)
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
                        if (Convert.ToInt32(txtQuantity.Text) > 25)
                        {
                            Global.playSimpleSound();
                            if ((MessageBox.Show("Do you want to add " + txtQuantity.Text + " items to this Order?", "Item's Quantity", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No))
                            {
                                this.txtQuantity.Clear();
                                this.txtQuantity.Focus();
                                return;
                            }
                        }

                        oTicket = null;
                        if (oOrder.oProduct.IsCustomized)
                            {
                                if (!AskForCustomItem())
                                {
                                    this.txtQuantity.Clear();
                                    this.txtQuantity.Focus();
                                    return;
                                }
                            }

                        this.AddItem();
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
                        txtTeacher.Text="";
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
            if (!(Boolean)Grid.ActiveRow.Cells["Customized"].Value)
            {
                if (Convert.ToInt32(Grid.ActiveRow.Cells["Quantity"].Value.ToString()) == 0)
                    this.DeleteItem(false);
                getTotals();
            }
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
        private void frmOrder_Shown(object sender, EventArgs e)
        {
            if (_OrderProcess == OrderProcess.ScanFixing)
            {
                txtStudent.Text = oOrder.Student;
                this.spelling.Text = this.txtStudent.Text;
                this.spelling.SpellCheck();
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
        private void toolStripViewInternet_Click(object sender, EventArgs e)
        {
            if (Global.CurrentUser == "SCOTT" || Global.CurrentUser == "ALVARO" || Global.CurrentUser == "RUSS" || Global.CurrentUser == "VICTORIA")
            {
                String myTargetURL = "";

                if (this.oOrder.ShoppingCart == ShoppingType.SigFund)
                    myTargetURL = "http://www.sigfund.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                else if (this.oOrder.ShoppingCart == ShoppingType.ChristianCollection)
                    myTargetURL = "http://www.christiancollection.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                else if (this.oOrder.ShoppingCart == ShoppingType.WLOT)
                    myTargetURL = "http://www.weloveourteachers.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                else if (this.oOrder.ShoppingCart == ShoppingType.PersonalTouchCollection)
                    myTargetURL = "http://www.personaltouchcollection.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                else
                    myTargetURL = "http://www.sigfund.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
                System.Diagnostics.Process.Start(myTargetURL);
            }
        }
        private void Grid_AfterCellActivate(object sender, EventArgs e)
        {
            if (Grid.ActiveCell == Grid.ActiveRow.Cells["Customized"] &&(Boolean)Grid.ActiveRow.Cells["Customized"].Value)
            {

                //oOrder.oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Value.ToString());
                //if (oOrder.oProduct.IsCustomized)
                {
                    //MessageBox.Show(Grid.ActiveRow.Cells["Quantity"].Value.ToString());
                    //MessageBox.Show(Grid.ActiveCell.GetUIElement()..ToString());

                    frmViewTicketsByOrder frmViewTickets = new frmViewTicketsByOrder(this.oOrder, Grid.ActiveRow.Cells["ProductID"].Value.ToString());
                    frmViewTickets.Type = OrderProcess.CustomOrder;
                    frmViewTickets.ShowDialog();
                    //    this.oOrder.Items[Grid.ActiveRow.Cells["ProductID"].Value.ToString()].Tickets.Load(this.oOrder, Grid.ActiveRow.Cells["ProductID"].Value.ToString());
                    frmViewTickets.Dispose();
                    if (oOrder.Items[Grid.ActiveRow.Cells["ProductID"].Value.ToString()].Tickets.Count > 0)
                        Grid.ActiveRow.Cells["Quantity"].Value = oOrder.Items[Grid.ActiveRow.Cells["ProductID"].Value.ToString()].Tickets.Quantity;

                }
                
            }
        }
        private void spelling_DeletedWord(object sender, Signature.SpellChecker.SpellingEventArgs e)
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
        private void spelling_ReplacedWord(object sender, Signature.SpellChecker.ReplaceWordEventArgs e)
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
            if (Grid.Rows != null)
            {
                for (int x = Grid.Rows.Count; x != 0; x--)
                {
                    Grid.Rows[0].Delete(false);
                }
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
            return oOrder.Items.ContainsKey(this.IDetail.ProductID);
        }
        private void AddItem()
        {
            this.IDetail.Quantity = Convert.ToInt32(txtQuantity.Text);

            Order.Item item     = new Order.Item();
            item.ProductID      = this.IDetail.ProductID;
            item.Description    = this.IDetail.Description;
            item.Price          = this.IDetail.Price;
            item.Length         = this.IDetail.Length;
            item.Width          = this.IDetail.Width;
            item.Height         = this.IDetail.Height;
            item.PackID         = this.IDetail.PackID;
            item.Customized     = oOrder.oProduct.IsCustomized;

            if (oOrder.oProduct.IsCustomized)
            {
                if (oTicket != null && oTicket.Lines.Count > 0)
                {

                    this.oTicket.ProductID = this.IDetail.ProductID;
                    this.oTicket.Quantity = this.IDetail.Quantity;
                    this.oTicket.OrderID = Convert.ToInt32(oOrder.ID);
                    this.oTicket.CompanyID = this.CompanyID;
                    
            //        oOrder.Tickets.Add(oOrder.TicketsSeq, this.oTicket);
                }
                else
                {
                    MessageBox.Show("Please enter customization for Item " + this.IDetail.ProductID);
                }
            }

            if (!IfExist())
            {   
                item.Quantity = this.IDetail.Quantity;
                oOrder.Items.Add(this.IDetail.ProductID, item); //+ this.oTicket==null?"":oOrder.Sequence.ToString()
            }
            else
            {
                oOrder.Items[this.IDetail.ProductID].Quantity += this.IDetail.Quantity;
            }

            if (oOrder.oProduct.IsCustomized)
            {

                oOrder.Items[this.IDetail.ProductID].Tickets.Add(oOrder.TicketsSeq, this.oTicket);
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
            oOrder.CustomerID   = txtCustomerID.Text;
            oOrder.Teacher      = txtTeacher.Text;
            oOrder.Student      = txtStudent.Text;
            oOrder.Collected    = Convert.ToDouble(txtCollected.Text);
            oOrder.Phone        = txtPhone.Value.ToString();

            oOrder.Save();


            if (Global.CurrrentCompany.Substring(0, 2) == "GA" && oOrder.ShortageID == 0)
            {
                //Create Shortage
                Shortage oShortage = new Shortage(this.CompanyID);
                //oShortage.oOrder = oOrder;
                oShortage.OrderID = oOrder.ID;
                oShortage.oCustomer = oOrder.oCustomer;
                oShortage.CustomerID = oOrder.CustomerID;
                oShortage.SchoolName = oOrder.oCustomer.Name;
                oShortage.DayPhone = oOrder.oCustomer.PhoneNumber;
                oShortage.TeacherName = oOrder.Teacher;
                oShortage.StudentName = oOrder.Student;
                oShortage.Address = oOrder.oCustomer.Address;
                oShortage.City = oOrder.oCustomer.City;
                oShortage.ZipCode = oOrder.oCustomer.ZipCode;
                oShortage.State = oOrder.oCustomer.State;
                oShortage.Attention = oOrder.oCustomer.Chairperson;
                oShortage.Type = "M";
                oShortage.Detail = oOrder.Student + "\n\r" + "\n\r";
                oShortage.Detail += oOrder.NoItems.ToString() + " Item(s)" + "\n\r" + "\n\r";
                oShortage.Detail += "OrderID      : " + oOrder.ID.ToString() + "\n\r";
                oShortage.eMail = oOrder.oCustomer.eMail;
                oShortage.Save();
              //  oShortage.Print(false);

                oOrder.ShortageID = Convert.ToInt32(oShortage.ID);
            }

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
        private Boolean AskForCustomItem()
        {
            frmTicket frmTicket = new frmTicket();
            //oTicket.txtOrderID.Text = oOrder.ID;
            frmTicket.Process = OrderProcess.CustomOrder;
            frmTicket.txtProductID.Text = txtProductID.Text;
            frmTicket.LabelOrderID.Visible = false;
            frmTicket.LabelTicketID.Visible = false;
            frmTicket.txtOrderID.Visible = false;
            frmTicket.txtTicketID.Visible = false;
            frmTicket.txtProductID.Enabled = false;
            frmTicket.txtDescription.Text = oOrder.oProduct.Description;
            frmTicket.txtQuantity.Text = txtQuantity.Text;
            frmTicket.txtStudent.Text = txtStudent.Text;
            frmTicket.ShowDialog();
            

            oTicket = new Ticket(this.CompanyID);

            oTicket.IsBussines = frmTicket.cbBussines.Checked;

            Ticket.Line oLine;
            
            if (frmTicket.txtLine_1.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Text = frmTicket.txtLine_1.Text;
                oLine.Type = Ticket.ImprintType.Card;
                oTicket.Lines.Add("1", oLine);
            }

            if (frmTicket.txtLine_2.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Card;
                oLine.Text = frmTicket.txtLine_2.Text;
                oTicket.Lines.Add("2",oLine );
            }
            if (frmTicket.txtLine_3.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Card;
                oLine.Text = frmTicket.txtLine_3.Text;
                oTicket.Lines.Add("3", oLine);
            }
            if (frmTicket.txtLine_4.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Card;
                oLine.Text = frmTicket.txtLine_4.Text;
                oTicket.Lines.Add("4", oLine);
            }
            if (frmTicket.txtLine_5.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Card;
                oLine.Text = frmTicket.txtLine_5.Text;
                oTicket.Lines.Add("5", oLine);
            }

            if (frmTicket.txtEnvLine_1.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Envelope;
                oLine.Text = frmTicket.txtEnvLine_1.Text;
                oTicket.LinesEnvelope.Add("1", oLine);
            }
            if (frmTicket.txtEnvLine_2.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Envelope;
                oLine.Text = frmTicket.txtEnvLine_2.Text;
                oTicket.LinesEnvelope.Add("2", oLine);
            }
            if (frmTicket.txtEnvLine_3.Text.Trim() != "")
            {
                oLine = new Ticket.Line();
                oLine.Type = Ticket.ImprintType.Envelope;
                oLine.Text = frmTicket.txtEnvLine_3.Text;
                oTicket.LinesEnvelope.Add("3", oLine);
            }

          //  oTicket.Save();
            return true;
        }

		#endregion

        

        

       
        

	}
}
