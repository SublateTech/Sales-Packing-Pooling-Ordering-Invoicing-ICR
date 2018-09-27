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
using Signature.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmTicket : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox Group_1;
        private Signature.Windows.Forms.GroupBox gbLines;
        public Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label1;
        public Infragistics.Win.Misc.UltraLabel txtDescription;
        private ToolStrip tStrip;
        private ToolStripSeparator toolStripSeparator3;
        
        public MaskedEditNumeric txtOrderID;
        public Label LabelOrderID;
        private Label label2;
        public Signature.Windows.Forms.MaskedEdit txtLine_1;
        public Signature.Windows.Forms.MaskedEdit txtLine_3;
        private Label label4;
        public Signature.Windows.Forms.MaskedEdit txtLine_2;
        private Label label3;
        public MaskedEditNumeric txtTicketID;
        public Label LabelTicketID;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        public Infragistics.Win.Misc.UltraLabel txtStudent;
        private Label label5;
        public MaskedEditNumeric txtQuantity;
        public Label label6;
        public Signature.Windows.Forms.MaskedEdit txtLine_5;
        private Label lLine5;
        public Signature.Windows.Forms.MaskedEdit txtLine_4;
        private Label lLine4;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor cbBussines;
        public Signature.Windows.Forms.GroupBox gEnvelope;
        public Signature.Windows.Forms.MaskedEdit txtEnvLine_3;
        private Label lEnvLine_3;
        public Signature.Windows.Forms.MaskedEdit txtEnvLine_2;
        private Label lEnvLine_2;
        public Signature.Windows.Forms.MaskedEdit txtEnvLine_1;
        private Label lEnvLine_1;
        private ToolStripButton toolPrintEnvelope;
		#endregion

        public enum TicketProcess
        {
            New         = 1,
            OrderEdit   = 2
        }

        private Signature.Card.CardPrinter CardPrinter;
        private Product oProduct;
        private Signature.Classes.Card oCard; //Card By Product
        private Signature.Classes.CardTemplate oCardTemplate; //Template
        private Ticket oTicket; 
        private Order oOrder;
        public Boolean IsPrinted = false;
        public OrderProcess Process = OrderProcess.Ticket;
        public Ticket.ImprintType TicketType;
        public Boolean isModified = false;
        public MaskedEditNumeric txtImprintFee;
        public Label lbImprintFee;
        public Signature.Windows.Forms.GroupBox groupBox1;
        private Label label7;
        public MaskedEdit txtFilePath;
        private System.Windows.Forms.Button butOpen;
        private PictureBox picBarcode;
        public TicketProcess ticketProcess = TicketProcess.New;
        private Bitmap bitmap;


        public frmTicket()
		{
			InitializeComponent();
            LoadObjects();
            TicketType = Ticket.ImprintType.Card;
            gEnvelope.Visible = false;

		}

        public frmTicket(Ticket oTicket)
        {
            InitializeComponent();
            LoadObjects();

            this.oTicket = oTicket;

            //this.txtOrderID.Text = oTicket.OrderID.ToString();
            //this.txtProductID.Text = oTicket.ProductID;
            this.txtTicketID.Text = oTicket.ID.ToString();
            //this.txtLine_1.Text = oTicket.Lines.Count > 0? oTicket.Lines[0].Text:"";
            //this.txtLine_2.Text = oTicket.Lines.Count > 1? oTicket.Lines[1].Text:"";
            //this.txtLine_3.Text = oTicket.Lines.Count > 2? oTicket.Lines[2].Text:"";

            
            txtImprintFee.Visible = oTicket.IsBussines;
            lbImprintFee.Visible = oTicket.IsBussines;
            this.DisplayCard();
        }

        public Boolean Print()
        {
            IsPrinted =  this.PrintCard();
            if (IsPrinted)
            {
                oTicket.IsPrinted = IsPrinted;
                oTicket.UpdatePrinted();
            }

            if (oTicket.IsBussines && (MessageBox.Show("do you want to print Envelopes?", "Print Envelope", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.PrintEnvelope();
            }
            
            
            return IsPrinted;
        }

        private void LoadObjects()
        {
            oTicket = new Ticket(this.CompanyID);
            oOrder = new Order(this.CompanyID);
            oProduct = new Product(this.CompanyID);
            CardPrinter = new Signature.Card.CardPrinter();
            oCardTemplate = new CardTemplate();
            oCard = new Signature.Classes.Card(this.CompanyID);
        }
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.ToolStripButton toolStripPrint;
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTicket));
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.Group_1 = new Signature.Windows.Forms.GroupBox();
            this.txtImprintFee = new Signature.Windows.Forms.MaskedEditNumeric();
            this.lbImprintFee = new System.Windows.Forms.Label();
            this.cbBussines = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStudent = new Infragistics.Win.Misc.UltraLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTicketID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelTicketID = new System.Windows.Forms.Label();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelOrderID = new System.Windows.Forms.Label();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
            this.gbLines = new Signature.Windows.Forms.GroupBox();
            this.txtLine_5 = new Signature.Windows.Forms.MaskedEdit();
            this.lLine5 = new System.Windows.Forms.Label();
            this.lLine4 = new System.Windows.Forms.Label();
            this.txtLine_3 = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLine_2 = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine_1 = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLine_4 = new Signature.Windows.Forms.MaskedEdit();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrintEnvelope = new System.Windows.Forms.ToolStripButton();
            this.gEnvelope = new Signature.Windows.Forms.GroupBox();
            this.txtEnvLine_3 = new Signature.Windows.Forms.MaskedEdit();
            this.lEnvLine_3 = new System.Windows.Forms.Label();
            this.txtEnvLine_2 = new Signature.Windows.Forms.MaskedEdit();
            this.lEnvLine_2 = new System.Windows.Forms.Label();
            this.txtEnvLine_1 = new Signature.Windows.Forms.MaskedEdit();
            this.lEnvLine_1 = new System.Windows.Forms.Label();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtFilePath = new Signature.Windows.Forms.MaskedEdit();
            this.butOpen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            toolStripPrint = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.Group_1)).BeginInit();
            this.Group_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLines)).BeginInit();
            this.gbLines.SuspendLayout();
            this.tStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEnvelope)).BeginInit();
            this.gEnvelope.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 737);
            this.txtStatus.Size = new System.Drawing.Size(598, 29);
            // 
            // toolStripPrint
            // 
            toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripPrint.Name = "toolStripPrint";
            toolStripPrint.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            toolStripPrint.Size = new System.Drawing.Size(104, 22);
            toolStripPrint.Text = "Print Card";
            toolStripPrint.Click += new System.EventHandler(this.toolStripPrint_Click);
            // 
            // Group_1
            // 
            this.Group_1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.Group_1.Appearance = appearance1;
            this.Group_1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Group_1.Controls.Add(this.txtImprintFee);
            this.Group_1.Controls.Add(this.lbImprintFee);
            this.Group_1.Controls.Add(this.cbBussines);
            this.Group_1.Controls.Add(this.txtQuantity);
            this.Group_1.Controls.Add(this.label6);
            this.Group_1.Controls.Add(this.txtStudent);
            this.Group_1.Controls.Add(this.label5);
            this.Group_1.Controls.Add(this.txtTicketID);
            this.Group_1.Controls.Add(this.LabelTicketID);
            this.Group_1.Controls.Add(this.txtOrderID);
            this.Group_1.Controls.Add(this.LabelOrderID);
            this.Group_1.Controls.Add(this.txtProductID);
            this.Group_1.Controls.Add(this.label1);
            this.Group_1.Controls.Add(this.txtDescription);
            this.Group_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Group_1.Location = new System.Drawing.Point(10, 43);
            this.Group_1.Name = "ultraGroupBox1";
            this.Group_1.Size = new System.Drawing.Size(578, 110);
            this.Group_1.TabIndex = 0;
            this.Group_1.Text = "Ticket Info";
            this.Group_1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtImprintFee
            // 
            this.txtImprintFee.AllowDrop = true;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtImprintFee.Appearance = appearance2;
            this.txtImprintFee.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtImprintFee.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.txtImprintFee.InputMask = "{LOC}-nnnn.nn";
            this.txtImprintFee.Location = new System.Drawing.Point(513, 79);
            this.txtImprintFee.Name = "txtOrderID";
            this.txtImprintFee.PromptChar = ' ';
            this.txtImprintFee.Size = new System.Drawing.Size(53, 20);
            this.txtImprintFee.TabIndex = 28;
            this.txtImprintFee.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lbImprintFee
            // 
            this.lbImprintFee.BackColor = System.Drawing.Color.Transparent;
            this.lbImprintFee.Location = new System.Drawing.Point(445, 79);
            this.lbImprintFee.Name = "lbImprintFee";
            this.lbImprintFee.Size = new System.Drawing.Size(62, 19);
            this.lbImprintFee.TabIndex = 29;
            this.lbImprintFee.Text = "Fee:";
            this.lbImprintFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBussines
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.BackColor2 = System.Drawing.Color.Transparent;
            appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.White;
            this.cbBussines.Appearance = appearance9;
            this.cbBussines.BackColor = System.Drawing.Color.Transparent;
            this.cbBussines.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbBussines.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBussines.Location = new System.Drawing.Point(463, 22);
            this.cbBussines.Name = "cbBussines";
            this.cbBussines.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbBussines.Size = new System.Drawing.Size(100, 19);
            this.cbBussines.TabIndex = 5;
            this.cbBussines.Text = "Bussines Card";
            this.cbBussines.CheckedChanged += new System.EventHandler(this.cbBussines_CheckedChanged);
            this.cbBussines.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            appearance10.BackColorDisabled = System.Drawing.Color.White;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtQuantity.Appearance = appearance10;
            this.txtQuantity.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtQuantity.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtQuantity.InputMask = "nnn";
            this.txtQuantity.Location = new System.Drawing.Point(513, 54);
            this.txtQuantity.Name = "txtOrderID";
            this.txtQuantity.PromptChar = ' ';
            this.txtQuantity.Size = new System.Drawing.Size(53, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(454, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 19);
            this.label6.TabIndex = 27;
            this.label6.Text = "Quantity:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStudent
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BackColor2 = System.Drawing.Color.Black;
            this.txtStudent.Appearance = appearance3;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(77, 78);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(368, 20);
            this.txtStudent.TabIndex = 26;
            this.txtStudent.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(5, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Student:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTicketID
            // 
            this.txtTicketID.AllowDrop = true;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTicketID.Appearance = appearance4;
            this.txtTicketID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTicketID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtTicketID.InputMask = "nnnnnnnnnn";
            this.txtTicketID.Location = new System.Drawing.Point(77, 20);
            this.txtTicketID.Name = "txtOrderID";
            this.txtTicketID.PromptChar = ' ';
            this.txtTicketID.Size = new System.Drawing.Size(83, 20);
            this.txtTicketID.TabIndex = 0;
            this.txtTicketID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // LabelTicketID
            // 
            this.LabelTicketID.BackColor = System.Drawing.Color.Transparent;
            this.LabelTicketID.Location = new System.Drawing.Point(-2, 24);
            this.LabelTicketID.Name = "LabelTicketID";
            this.LabelTicketID.Size = new System.Drawing.Size(66, 16);
            this.LabelTicketID.TabIndex = 24;
            this.LabelTicketID.Text = "Ticket ID:";
            this.LabelTicketID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            appearance5.BackColorDisabled = System.Drawing.Color.White;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtOrderID.Appearance = appearance5;
            this.txtOrderID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOrderID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtOrderID.InputMask = "nnnnnnnnnn";
            this.txtOrderID.Location = new System.Drawing.Point(364, 20);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.PromptChar = ' ';
            this.txtOrderID.Size = new System.Drawing.Size(83, 20);
            this.txtOrderID.TabIndex = 2;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // LabelOrderID
            // 
            this.LabelOrderID.BackColor = System.Drawing.Color.Transparent;
            this.LabelOrderID.Location = new System.Drawing.Point(295, 22);
            this.LabelOrderID.Name = "LabelOrderID";
            this.LabelOrderID.Size = new System.Drawing.Size(66, 16);
            this.LabelOrderID.TabIndex = 22;
            this.LabelOrderID.Text = "Order ID:";
            this.LabelOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(77, 46);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(83, 20);
            this.txtProductID.TabIndex = 1;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(-3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Product ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance6;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(166, 46);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(291, 20);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // gbLines
            // 
            this.gbLines.AllowDrop = true;
            appearance8.AlphaLevel = ((short)(95));
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.gbLines.Appearance = appearance8;
            this.gbLines.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbLines.Controls.Add(this.txtLine_5);
            this.gbLines.Controls.Add(this.lLine5);
            this.gbLines.Controls.Add(this.lLine4);
            this.gbLines.Controls.Add(this.txtLine_3);
            this.gbLines.Controls.Add(this.label4);
            this.gbLines.Controls.Add(this.txtLine_2);
            this.gbLines.Controls.Add(this.label3);
            this.gbLines.Controls.Add(this.txtLine_1);
            this.gbLines.Controls.Add(this.label2);
            this.gbLines.Controls.Add(this.txtLine_4);
            this.gbLines.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbLines.Location = new System.Drawing.Point(10, 159);
            this.gbLines.Name = "ultraGroupBox2";
            this.gbLines.Size = new System.Drawing.Size(578, 177);
            this.gbLines.TabIndex = 1;
            this.gbLines.Text = "Card Personalization";
            this.gbLines.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtLine_5
            // 
            this.txtLine_5.AcceptsTab = true;
            this.txtLine_5.AllowDrop = true;
            this.txtLine_5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine_5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLine_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine_5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine_5.Location = new System.Drawing.Point(73, 138);
            this.txtLine_5.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtLine_5.MaxLength = 40;
            this.txtLine_5.Name = "txtStudent";
            this.txtLine_5.Size = new System.Drawing.Size(471, 26);
            this.txtLine_5.TabIndex = 29;
            this.txtLine_5.Visible = false;
            this.txtLine_5.WordWrap = false;
            this.txtLine_5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lLine5
            // 
            this.lLine5.BackColor = System.Drawing.Color.Transparent;
            this.lLine5.Location = new System.Drawing.Point(-2, 138);
            this.lLine5.Name = "lLine5";
            this.lLine5.Size = new System.Drawing.Size(66, 16);
            this.lLine5.TabIndex = 31;
            this.lLine5.Text = "Line 5:";
            this.lLine5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLine5.Visible = false;
            // 
            // lLine4
            // 
            this.lLine4.BackColor = System.Drawing.Color.Transparent;
            this.lLine4.Location = new System.Drawing.Point(-2, 109);
            this.lLine4.Name = "lLine4";
            this.lLine4.Size = new System.Drawing.Size(66, 16);
            this.lLine4.TabIndex = 30;
            this.lLine4.Text = "Line 4:";
            this.lLine4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLine4.Visible = false;
            // 
            // txtLine_3
            // 
            this.txtLine_3.AcceptsTab = true;
            this.txtLine_3.AllowDrop = true;
            this.txtLine_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine_3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLine_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine_3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine_3.Location = new System.Drawing.Point(73, 82);
            this.txtLine_3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtLine_3.MaxLength = 40;
            this.txtLine_3.Name = "txtStudent";
            this.txtLine_3.Size = new System.Drawing.Size(471, 26);
            this.txtLine_3.TabIndex = 2;
            this.txtLine_3.WordWrap = false;
            this.txtLine_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(-2, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Line 3:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLine_2
            // 
            this.txtLine_2.AcceptsTab = true;
            this.txtLine_2.AllowDrop = true;
            this.txtLine_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLine_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine_2.Location = new System.Drawing.Point(73, 53);
            this.txtLine_2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtLine_2.MaxLength = 40;
            this.txtLine_2.Name = "txtStudent";
            this.txtLine_2.Size = new System.Drawing.Size(471, 26);
            this.txtLine_2.TabIndex = 1;
            this.txtLine_2.WordWrap = false;
            this.txtLine_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(-2, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Line 2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLine_1
            // 
            this.txtLine_1.AcceptsTab = true;
            this.txtLine_1.AllowDrop = true;
            this.txtLine_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLine_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine_1.Location = new System.Drawing.Point(73, 24);
            this.txtLine_1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtLine_1.MaxLength = 40;
            this.txtLine_1.Name = "txtStudent";
            this.txtLine_1.Size = new System.Drawing.Size(471, 26);
            this.txtLine_1.TabIndex = 0;
            this.txtLine_1.WordWrap = false;
            this.txtLine_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(-2, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Line 1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLine_4
            // 
            this.txtLine_4.AcceptsTab = true;
            this.txtLine_4.AllowDrop = true;
            this.txtLine_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine_4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLine_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLine_4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine_4.Location = new System.Drawing.Point(73, 109);
            this.txtLine_4.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtLine_4.MaxLength = 40;
            this.txtLine_4.Name = "txtStudent";
            this.txtLine_4.Size = new System.Drawing.Size(471, 26);
            this.txtLine_4.TabIndex = 28;
            this.txtLine_4.Visible = false;
            this.txtLine_4.WordWrap = false;
            this.txtLine_4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            toolStripPrint,
            this.toolStripSeparator3,
            this.toolPrintEnvelope});
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Size = new System.Drawing.Size(598, 25);
            this.tStrip.TabIndex = 56;
            this.tStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton1.Text = "Print All";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPrintEnvelope
            // 
            this.toolPrintEnvelope.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrintEnvelope.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintEnvelope.Image")));
            this.toolPrintEnvelope.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintEnvelope.Name = "toolPrintEnvelope";
            this.toolPrintEnvelope.Size = new System.Drawing.Size(87, 22);
            this.toolPrintEnvelope.Text = "Print Envelope";
            this.toolPrintEnvelope.Click += new System.EventHandler(this.toolPrintEnvelope_Click);
            // 
            // gEnvelope
            // 
            this.gEnvelope.AllowDrop = true;
            appearance11.AlphaLevel = ((short)(95));
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.gEnvelope.Appearance = appearance11;
            this.gEnvelope.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gEnvelope.Controls.Add(this.txtEnvLine_3);
            this.gEnvelope.Controls.Add(this.lEnvLine_3);
            this.gEnvelope.Controls.Add(this.txtEnvLine_2);
            this.gEnvelope.Controls.Add(this.lEnvLine_2);
            this.gEnvelope.Controls.Add(this.txtEnvLine_1);
            this.gEnvelope.Controls.Add(this.lEnvLine_1);
            this.gEnvelope.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gEnvelope.Location = new System.Drawing.Point(12, 342);
            this.gEnvelope.Name = "ultraGroupBox2";
            this.gEnvelope.Size = new System.Drawing.Size(578, 125);
            this.gEnvelope.TabIndex = 2;
            this.gEnvelope.Text = " Envelope ";
            this.gEnvelope.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtEnvLine_3
            // 
            this.txtEnvLine_3.AcceptsTab = true;
            this.txtEnvLine_3.AllowDrop = true;
            this.txtEnvLine_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvLine_3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEnvLine_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnvLine_3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvLine_3.Location = new System.Drawing.Point(73, 82);
            this.txtEnvLine_3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtEnvLine_3.MaxLength = 40;
            this.txtEnvLine_3.Name = "txtStudent";
            this.txtEnvLine_3.Size = new System.Drawing.Size(471, 26);
            this.txtEnvLine_3.TabIndex = 2;
            this.txtEnvLine_3.WordWrap = false;
            this.txtEnvLine_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lEnvLine_3
            // 
            this.lEnvLine_3.BackColor = System.Drawing.Color.Transparent;
            this.lEnvLine_3.Location = new System.Drawing.Point(-2, 82);
            this.lEnvLine_3.Name = "lEnvLine_3";
            this.lEnvLine_3.Size = new System.Drawing.Size(66, 16);
            this.lEnvLine_3.TabIndex = 27;
            this.lEnvLine_3.Text = "Line 3:";
            this.lEnvLine_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnvLine_2
            // 
            this.txtEnvLine_2.AcceptsTab = true;
            this.txtEnvLine_2.AllowDrop = true;
            this.txtEnvLine_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvLine_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEnvLine_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnvLine_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvLine_2.Location = new System.Drawing.Point(73, 53);
            this.txtEnvLine_2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtEnvLine_2.MaxLength = 40;
            this.txtEnvLine_2.Name = "txtStudent";
            this.txtEnvLine_2.Size = new System.Drawing.Size(471, 26);
            this.txtEnvLine_2.TabIndex = 1;
            this.txtEnvLine_2.WordWrap = false;
            this.txtEnvLine_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lEnvLine_2
            // 
            this.lEnvLine_2.BackColor = System.Drawing.Color.Transparent;
            this.lEnvLine_2.Location = new System.Drawing.Point(-2, 53);
            this.lEnvLine_2.Name = "lEnvLine_2";
            this.lEnvLine_2.Size = new System.Drawing.Size(66, 16);
            this.lEnvLine_2.TabIndex = 25;
            this.lEnvLine_2.Text = "Line 2:";
            this.lEnvLine_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnvLine_1
            // 
            this.txtEnvLine_1.AcceptsTab = true;
            this.txtEnvLine_1.AllowDrop = true;
            this.txtEnvLine_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvLine_1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEnvLine_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnvLine_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvLine_1.Location = new System.Drawing.Point(73, 24);
            this.txtEnvLine_1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtEnvLine_1.MaxLength = 40;
            this.txtEnvLine_1.Name = "txtStudent";
            this.txtEnvLine_1.Size = new System.Drawing.Size(471, 26);
            this.txtEnvLine_1.TabIndex = 0;
            this.txtEnvLine_1.WordWrap = false;
            this.txtEnvLine_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lEnvLine_1
            // 
            this.lEnvLine_1.BackColor = System.Drawing.Color.Transparent;
            this.lEnvLine_1.Location = new System.Drawing.Point(-2, 24);
            this.lEnvLine_1.Name = "lEnvLine_1";
            this.lEnvLine_1.Size = new System.Drawing.Size(66, 16);
            this.lEnvLine_1.TabIndex = 23;
            this.lEnvLine_1.Text = "Line 1:";
            this.lEnvLine_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance7.AlphaLevel = ((short)(95));
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance7;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.picBarcode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.butOpen);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(13, 473);
            this.groupBox1.Name = "ultraGroupBox2";
            this.groupBox1.Size = new System.Drawing.Size(578, 246);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.Text = "Picture";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Location = new System.Drawing.Point(73, 19);
            this.txtFilePath.Name = "txtCustomerID";
            this.txtFilePath.Size = new System.Drawing.Size(392, 20);
            this.txtFilePath.TabIndex = 18;
            this.txtFilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // butOpen
            // 
            this.butOpen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOpen.Location = new System.Drawing.Point(471, 18);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(62, 23);
            this.butOpen.TabIndex = 19;
            this.butOpen.Text = "Open ...";
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "Picture :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(16, 63);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(544, 160);
            this.picBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBarcode.TabIndex = 27;
            this.picBarcode.TabStop = false;
            // 
            // frmTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(598, 766);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gEnvelope);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.gbLines);
            this.Controls.Add(this.Group_1);
            this.Name = "frmTicket";
            this.ShowInTaskbar = false;
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Shown += new System.EventHandler(this.frmTicket_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.Group_1, 0);
            this.Controls.SetChildIndex(this.gbLines, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.Controls.SetChildIndex(this.gEnvelope, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Group_1)).EndInit();
            this.Group_1.ResumeLayout(false);
            this.Group_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLines)).EndInit();
            this.gbLines.ResumeLayout(false);
            this.gbLines.PerformLayout();
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEnvelope)).EndInit();
            this.gEnvelope.ResumeLayout(false);
            this.gEnvelope.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region  Events	
        
	    private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            
            this.Text += " - " + this.CompanyID;

            cbBussines_CheckedChanged(null, null);   

            tStrip.Renderer = new WindowsVistaRenderer();
            if (Process == OrderProcess.CustomOrder || ticketProcess== TicketProcess.OrderEdit)
            {
                txtQuantity.Enabled = true;
                gbLines.Focus();
                txtLine_1.Focus();
            }

            if (!Global.HasAccess("frmTicket"))
            {
                txtLine_1.CharacterCasing = CharacterCasing.Upper;
                txtLine_2.CharacterCasing = CharacterCasing.Upper;
                txtLine_3.CharacterCasing = CharacterCasing.Upper;
                txtLine_4.CharacterCasing = CharacterCasing.Upper;
                txtLine_5.CharacterCasing = CharacterCasing.Upper;
                txtEnvLine_1.CharacterCasing = CharacterCasing.Upper;
                txtEnvLine_2.CharacterCasing = CharacterCasing.Upper;
                txtEnvLine_3.CharacterCasing = CharacterCasing.Upper;
            }
            txtImprintFee.Visible = false;
            lbImprintFee.Visible = false;
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //MessageBox.Show(e.KeyCode.ToString());


            #region txtProductID
            if (sender == txtProductID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oProduct.View())
                    {
                        this.Display();
                        
                        return;
                    }
                    txtProductID.Clear();
                    txtProductID.Focus();
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtProductID.Text.Trim() == "")
                    {
                        txtProductID.Clear();
                        txtProductID.Focus();
                        return;
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {
                        this.Display();
                        return;
                    }
                    else
                    {   
                        return;
                    }
                }

            }
            #endregion
            #region txtQuantity
            if (sender == txtQuantity)
            {
                
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtQuantity.Text.Trim() == "")
                    {
                        txtQuantity.Clear();
                        txtQuantity.Focus();
                        return;
                    }
                    txtLine_1.Focus();
                    return;
                }

            }
            #endregion
            #region txtTicketID
            if (sender == txtTicketID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oTicket.View())
                    {
                        txtTicketID.Text = oTicket.ID.ToString();
                        DisplayCard();
                        return;
                    }
                    //this.txtDescription.Text = 
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtTicketID.Text.Trim() == "")
                    {
                        txtTicketID.Clear();
                        txtTicketID.Focus();
                        return;
                    }

                    if (oTicket.Find(Convert.ToInt32(txtTicketID.Text)))
                    {
                        this.DisplayCard();
                        return;
                    }
                    else
                    {
                        return;
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
                    if (txtTicketID.Text.Length > 0)
                    {
                        oTicket.Delete();
                        this.isModified = true;
                    }
                    if (Process == OrderProcess.CustomOrder)
                    {
                        this.Close();
                        return;
                    }
                    Clear();
                    txtTicketID.Focus();
                    return;
                case Keys.PageDown:
                    if (Process == OrderProcess.CustomOrder)
                    {
                        this.Close();
                        return;
                    }
                    Save();
                    Clear();
                    txtTicketID.Focus();
                    return;
                    
                case Keys.Delete:
                    
                    break; 


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        private void bPrint_Click(object sender, EventArgs e)
        {

           // frmViewReport oViewReport = new frmViewReport();
           // oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtVendorID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
            this.Save();
            Clear();
            txtProductID.Enabled = true;
            txtProductID.Clear();
            txtProductID.Focus();
            
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                
            }
            if (e.KeyCode == Keys.Up)
            {
                
                //SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region  Methods
        public void Clear()
        {
            txtProductID.Text="";
          //  txtTicketID.Text = "";
            txtOrderID.Text = "";
            txtDescription.Text = "";
            txtLine_1.Text = "";
            txtLine_2.Text = "";
            txtLine_3.Text = "";
            txtLine_4.Text = "";
            txtLine_5.Text = "";
            cbBussines.Checked = false;
            txtImprintFee.Value = 0;
            txtFilePath.Clear();
            picBarcode.Image = null;
            picBarcode.Invalidate();
        }   

        public void Save()
        {
            if (Process == OrderProcess.CustomOrder)
                return;

            if (txtProductID.Text.Trim() != "" )
            {
                /*
                oCard.CompanyID = this.CompanyID;
                oCard.ProductID = oProduct.ID;
                
            
                oCard.Save();
                */
                oTicket.ProductID = txtProductID.Text;
                oTicket.ImprintFee = txtImprintFee.Number;
                oTicket.Lines.Clear();
                for (int n = 0; n < 5; n++)
                {
                    String text = "";
                    switch (n + 1)
                    {
                        case 1:
                            text = txtLine_1.Text;
                            break;
                        case 2:
                            text = txtLine_2.Text;
                            break;
                        case 3:
                            text = txtLine_3.Text;
                            break;
                        case 4:
                            if (cbBussines.Checked)
                                text = txtLine_4.Text;
                            else
                                continue;
                            break;
                        case 5:
                            if (cbBussines.Checked)
                                text = txtLine_5.Text;
                            else
                                continue;
                            break;


                    }
                //    if (text.Trim().Length > 0)
                    {
                        Ticket.Line oLine = new Ticket.Line();
                        oLine.TicketID = oTicket.ID;
                        oLine.Text = text;
                        oLine.Type = Ticket.ImprintType.Card;
                        oTicket.Lines.Add((n + 1).ToString(), oLine);
                    }
                }
                oTicket.LinesEnvelope.Clear();
                for (int n = 0; n < 3; n++)
                {
                    String text = "";
                    switch (n + 1)
                    {
                        case 1:
                            text = txtEnvLine_1.Text;
                            break;
                        case 2:
                            text = txtEnvLine_2.Text;
                            break;
                        case 3:
                            text = txtEnvLine_3.Text;
                            break;
                    }
                    if (text.Trim().Length > 0)
                    {
                        Ticket.Line oLine = new Ticket.Line();
                        oLine.TicketID = oTicket.ID;
                        oLine.Text = text;
                        oLine.Type = Ticket.ImprintType.Envelope;
                        oTicket.LinesEnvelope.Add((n + 1).ToString(), oLine);
                    }
                }

                
                //oTicket.PictureFileName = open

                oTicket.Quantity = (Int32) txtQuantity.Number;
                oTicket.IsBussines = cbBussines.Checked;
                
                oTicket.Save();
                System.Drawing.Image image = this.picBarcode.Image;
                
                oTicket.SaveFileName(txtFilePath.Text, image);
                this.isModified = true;
            }
            else
            {
                MessageBox.Show("Please enter ProductID");
            }
            if (txtTicketID.Number == 0)
                this.Close();
        }
        
        public void Display()
        {
            
            txtProductID.Text = oProduct.ID;
            txtDescription.Text = oProduct.Description;

            if (oCard.Find(txtProductID.Text))
            {
              //  txtProductID.Text = oCard.CardTemplateID.ToString();

                if (ticketProcess != TicketProcess.New)
                    DisplayCard();
                else
                    txtQuantity.Focus();
            
            }
            else
            {
                this.Clear();
            }
        }
		#endregion

        private void DisplayCard()
        {
            Clear();
            txtProductID.Text = oTicket.ProductID;
            txtOrderID.Text = oTicket.OrderID.ToString();
            
            oProduct.Find(oTicket.ProductID);
            txtDescription.Text = oProduct.Description;

            oOrder.Find(oTicket.OrderID);
            txtStudent.Text = oOrder.Student;

            oCard.Find(oTicket.ProductID);

            oCardTemplate.Find(oCard.CardTemplateID);

            txtLine_1.Text = "";
            txtLine_2.Text = "";
            txtLine_3.Text = "";
            txtLine_4.Text = "";
            txtLine_5.Text = "";

            txtQuantity.Text = oTicket.Quantity.ToString();

            for (int x = 0; x < oTicket.Lines.Count; x++)
            {
                if (x == 0)
                    txtLine_1.Text = ((Ticket.Line) oTicket.Lines[x]).Text;
                if (x == 1)
                    txtLine_2.Text = ((Ticket.Line)oTicket.Lines[x]).Text;
                if (x == 2)
                    txtLine_3.Text = ((Ticket.Line)oTicket.Lines[x]).Text;
                if (x == 3)
                    txtLine_4.Text = ((Ticket.Line)oTicket.Lines[x]).Text;
                if (x == 4)
                    txtLine_5.Text = ((Ticket.Line)oTicket.Lines[x]).Text;

            }

            txtEnvLine_1.Text = "";
            txtEnvLine_2.Text = "";
            txtEnvLine_3.Text = "";
            
            for (int x = 0; x < oTicket.LinesEnvelope.Count; x++)
            {
                if (x == 0)
                    txtEnvLine_1.Text = ((Ticket.Line)oTicket.LinesEnvelope[x]).Text;
                if (x == 1)
                    txtEnvLine_2.Text = ((Ticket.Line)oTicket.LinesEnvelope[x]).Text;
                if (x == 2)
                    txtEnvLine_3.Text = ((Ticket.Line)oTicket.LinesEnvelope[x]).Text;
                

            }

            cbBussines.Checked = oTicket.IsBussines;
            txtImprintFee.Value = oTicket.ImprintFee;
            if (oTicket.PictureFileName != null && oTicket.PictureFileName != String.Empty)
            {
                txtFilePath.Text = Global.ImageDirectory + oTicket.PictureFileName;
                this.DisplayImage();
            }
            cbBussines_CheckedChanged(null, null);

        }

        private Boolean PrintCard()
        {
            Boolean _Printed = false;
            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (txtProductID.Text.Trim() != "" && txtTicketID.Text.Trim() != "" )
            {

                oTicket.Lines.Clear();

                Ticket.Line oLine;

                oLine = new Ticket.Line();
                oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                oLine.Text = txtLine_1.Text;
                oTicket.Lines.Add("1",oLine);

                if (txtLine_2.Text.Length > 0 || txtLine_3.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtLine_2.Text;
                    oTicket.Lines.Add("2", oLine);
                }
                if (txtLine_3.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtLine_3.Text;
                    oTicket.Lines.Add("3", oLine);
                }

                if (txtLine_4.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtLine_4.Text;
                    oTicket.Lines.Add("4", oLine);
                }

                if (txtLine_5.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtLine_5.Text;
                    oTicket.Lines.Add("5", oLine);
                }

                
                _Printed = oTicket.Print(false);

             }
            return _Printed;
            
        }

        private Boolean PrintEnvelope()
        {
            Boolean _Printed = false;
            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (txtProductID.Text.Trim() != "" && txtTicketID.Text.Trim() != "")
            {

                oTicket.LinesEnvelope.Clear();

                Ticket.Line oLine;

                oLine = new Ticket.Line();

                if (txtEnvLine_1.Text.Length > 0)
                {
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtEnvLine_1.Text;
                    oTicket.LinesEnvelope.Add("1", oLine);
                }
                if (txtEnvLine_2.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtEnvLine_2.Text;
                    oTicket.LinesEnvelope.Add("2", oLine);
                }
                if (txtEnvLine_3.Text.Length > 0)
                {
                    oLine = new Ticket.Line();
                    oLine.TicketID = Convert.ToInt32(txtTicketID.Text);
                    oLine.Text = txtEnvLine_3.Text;
                    oTicket.LinesEnvelope.Add("3", oLine);
                }
                
                _Printed = oTicket.PrintEnvelope(false);

            }
            return _Printed;

        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {
            this.PrintCard();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (oTicket.ID != 0)
            //    oTicket.Print();
            this.Print();
        }

        private void cbBussines_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBussines.Checked)
            {
                txtLine_4.Visible = true;
                txtLine_5.Visible = true;
                lLine4.Visible = true;
                lLine5.Visible = true;
                gEnvelope.Visible = true;
                //this.Height += gEnvelope.Height;
                txtImprintFee.Visible = true;
                lbImprintFee.Visible = true;
            }
            else
            {
                txtLine_4.Visible = false;
                txtLine_5.Visible = false;
                lLine4.Visible = false;
                lLine5.Visible = false;
                gEnvelope.Visible = false;
                //this.Height -= gEnvelope.Height;
                txtImprintFee.Visible = false;
                lbImprintFee.Visible = false;
            }
        }


        private void toolPrintEnvelope_Click(object sender, EventArgs e)
        {
            this.PrintEnvelope();
        }

        private void frmTicket_Shown(object sender, EventArgs e)
        {
            if (Process == OrderProcess.CustomOrder || ticketProcess == TicketProcess.OrderEdit)
            {
                txtQuantity.Enabled = true;
                gbLines.Focus();
                txtLine_1.Focus();
            }
            
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            if (OpenFile())
                DisplayImage();
            txtFilePath.Focus();
        }

        private bool OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Open Image File";
            openFileDialog1.Filter = "Bitmap Files|*.bmp" +
                "|Enhanced Windows MetaFile|*.emf" +
                "|Exchangeable Image File|*.exif" +
                "|Gif Files|*.gif|Icons|*.ico|JPEG Files|*.jpg" +
                "|PNG Files|*.png|TIFF Files|*.tif|Windows MetaFile|*.wmf";

            openFileDialog1.FilterIndex = 6;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "")
                return false;

            txtFilePath.Text = openFileDialog1.FileName;

            return true;
        }

        private void DisplayImage()
        {
            if (txtFilePath.Text.Trim() == "")
            {
                picBarcode.Image = null;
                return;
            }
            // set the extended picturebox control's
            // image to the open file dialog's filename

            bitmap = (Bitmap)Bitmap.FromFile(@txtFilePath.Text);


            //Bitmap b =  (Bitmap) Bitmap.FromFile(@"D:\Cards F09\Snowman_Ins copy.jpg");
            //bitmap = (Bitmap)Bitmap.FromFile(@"D:\Cards F09\TreeCard_Ins copy.jpg");
            //bitmap = (Bitmap)Bitmap.FromFile(@"D:\Cards F09\MouseCard_InsHoriz copy.jpg");
            /*
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                //g.FillRectangle(Brushes.White, new Rectangle(0, 0,               b.Width, b.Height));

                //g.DrawString(text, font, Brushes.Black, 50, 60);
            }
            */
            picBarcode.Image = bitmap;
            // picBarcode.Size = new Size(oCardTemplate.PaperSize.Height/2, oCardTemplate.PaperSize.Width/2);

            
            if (bitmap.Width < bitmap.Height)
            {
                picBarcode.Image.RotateFlip(RotateFlipType.Rotate270FlipXY); //= bitmap;
                picBarcode.Invalidate();
            }

         //   bitmap.Dispose();
        }


	}
}
