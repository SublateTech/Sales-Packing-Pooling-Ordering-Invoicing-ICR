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
	public sealed class frmCardByProduct : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        public Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label1;
        private Infragistics.Win.Misc.UltraLabel txtDescription;
        private ToolStrip tStrip;
        private ToolStripSeparator toolStripSeparator3;
        private Signature.Card.CardPrinter CardPrinter;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private MaskedEditNumeric txtTemplateID;
        internal Label LabelTemplateID;
        private Infragistics.Win.Misc.UltraLabel txtTDescription;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbAsTemplate;
        private MaskedEditNumeric txtPointX;
        internal Label LabelPointX;
        private MaskedEditNumeric txtPointY;
        internal Label LabelPointY;
        private System.Windows.Forms.Button butOpen;
        private Panel panel1;
        public MaskedEdit txtFilePath;
		#endregion
     
        private Product oProduct;
        private Signature.Classes.Card oCard;
        private Signature.Classes.CardTemplate oCardTemplate;
        private PictureBox picBarcode;
        private Infragistics.Win.Misc.UltraLabel txtEDescription;
        private MaskedEditNumeric txtEnvTemplateID;
        internal Label label2;
        private ToolStripButton toolPrintEnvelope;
        private Bitmap bitmap;

        public frmCardByProduct()
		{
			InitializeComponent();
            //if (txtProductID.Text.Trim() != "")
                //Grid.Focus();

            oCardTemplate = new CardTemplate();
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardByProduct));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtFilePath = new Signature.Windows.Forms.MaskedEdit();
            this.butOpen = new System.Windows.Forms.Button();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrintEnvelope = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtEDescription = new Infragistics.Win.Misc.UltraLabel();
            this.txtEnvTemplateID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPointY = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelPointY = new System.Windows.Forms.Label();
            this.txtPointX = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelPointX = new System.Windows.Forms.Label();
            this.txtTDescription = new Infragistics.Win.Misc.UltraLabel();
            this.cbAsTemplate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtTemplateID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelTemplateID = new System.Windows.Forms.Label();
            toolStripPrint = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.tStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 706);
            this.txtStatus.Size = new System.Drawing.Size(600, 29);
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
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtFilePath);
            this.ultraGroupBox1.Controls.Add(this.butOpen);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(10, 43);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(576, 95);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Location = new System.Drawing.Point(95, 62);
            this.txtFilePath.Name = "txtCustomerID";
            this.txtFilePath.Size = new System.Drawing.Size(392, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // butOpen
            // 
            this.butOpen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOpen.Location = new System.Drawing.Point(493, 61);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(62, 23);
            this.butOpen.TabIndex = 17;
            this.butOpen.Text = "Open ...";
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(95, 25);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(110, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Item #:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance2;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(216, 25);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(348, 20);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.panel1);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(6, 275);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(582, 406);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picBarcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 403);
            this.panel1.TabIndex = 0;
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(3, 4);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(562, 334);
            this.picBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBarcode.TabIndex = 0;
            this.picBarcode.TabStop = false;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripPrint,
            this.toolStripSeparator3,
            this.toolPrintEnvelope});
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Size = new System.Drawing.Size(600, 25);
            this.tStrip.TabIndex = 56;
            this.tStrip.Text = "toolStrip1";
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
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance4.AlphaLevel = ((short)(95));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance4;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtEDescription);
            this.groupBox1.Controls.Add(this.txtEnvTemplateID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPointY);
            this.groupBox1.Controls.Add(this.LabelPointY);
            this.groupBox1.Controls.Add(this.txtPointX);
            this.groupBox1.Controls.Add(this.LabelPointX);
            this.groupBox1.Controls.Add(this.txtTDescription);
            this.groupBox1.Controls.Add(this.cbAsTemplate);
            this.groupBox1.Controls.Add(this.txtTemplateID);
            this.groupBox1.Controls.Add(this.LabelTemplateID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 144);
            this.groupBox1.Name = "ultraGroupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 125);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtEDescription
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.BackColor2 = System.Drawing.Color.Black;
            this.txtEDescription.Appearance = appearance7;
            this.txtEDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEDescription.Location = new System.Drawing.Point(218, 42);
            this.txtEDescription.Name = "txtEDescription";
            this.txtEDescription.Size = new System.Drawing.Size(340, 20);
            this.txtEDescription.TabIndex = 253;
            this.txtEDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtEnvTemplateID
            // 
            this.txtEnvTemplateID.AllowDrop = true;
            appearance9.TextHAlignAsString = "Right";
            this.txtEnvTemplateID.Appearance = appearance9;
            this.txtEnvTemplateID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEnvTemplateID.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtEnvTemplateID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtEnvTemplateID.InputMask = "nnnnnnnnn";
            this.txtEnvTemplateID.Location = new System.Drawing.Point(127, 42);
            this.txtEnvTemplateID.Name = "txtRetail";
            this.txtEnvTemplateID.PromptChar = ' ';
            this.txtEnvTemplateID.Size = new System.Drawing.Size(80, 20);
            this.txtEnvTemplateID.TabIndex = 251;
            this.txtEnvTemplateID.Text = "() -";
            this.txtEnvTemplateID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 252;
            this.label2.Text = "Env. Template ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPointY
            // 
            this.txtPointY.AllowDrop = true;
            appearance5.TextHAlignAsString = "Right";
            this.txtPointY.Appearance = appearance5;
            this.txtPointY.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPointY.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPointY.FormatString = "###,###.##";
            this.txtPointY.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPointY.Location = new System.Drawing.Point(394, 96);
            this.txtPointY.Name = "txtAmountDue";
            this.txtPointY.Size = new System.Drawing.Size(64, 20);
            this.txtPointY.TabIndex = 249;
            this.txtPointY.Text = "0";
            // 
            // LabelPointY
            // 
            this.LabelPointY.BackColor = System.Drawing.Color.Transparent;
            this.LabelPointY.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPointY.Location = new System.Drawing.Point(304, 96);
            this.LabelPointY.Name = "LabelPointY";
            this.LabelPointY.Size = new System.Drawing.Size(82, 18);
            this.LabelPointY.TabIndex = 250;
            this.LabelPointY.Text = "PointY :";
            this.LabelPointY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPointX
            // 
            this.txtPointX.AllowDrop = true;
            appearance6.TextHAlignAsString = "Right";
            this.txtPointX.Appearance = appearance6;
            this.txtPointX.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPointX.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPointX.FormatString = "###,###.##";
            this.txtPointX.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPointX.Location = new System.Drawing.Point(394, 70);
            this.txtPointX.Name = "txtAmountDue";
            this.txtPointX.Size = new System.Drawing.Size(64, 20);
            this.txtPointX.TabIndex = 247;
            this.txtPointX.Text = "0";
            // 
            // LabelPointX
            // 
            this.LabelPointX.BackColor = System.Drawing.Color.Transparent;
            this.LabelPointX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPointX.Location = new System.Drawing.Point(304, 70);
            this.LabelPointX.Name = "LabelPointX";
            this.LabelPointX.Size = new System.Drawing.Size(82, 18);
            this.LabelPointX.TabIndex = 248;
            this.LabelPointX.Text = "PointX :";
            this.LabelPointX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTDescription
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.BackColor2 = System.Drawing.Color.Black;
            this.txtTDescription.Appearance = appearance10;
            this.txtTDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDescription.Location = new System.Drawing.Point(218, 17);
            this.txtTDescription.Name = "txtTDescription";
            this.txtTDescription.Size = new System.Drawing.Size(326, 20);
            this.txtTDescription.TabIndex = 246;
            this.txtTDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // cbAsTemplate
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.BackColor2 = System.Drawing.Color.Transparent;
            appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.White;
            this.cbAsTemplate.Appearance = appearance8;
            this.cbAsTemplate.BackColor = System.Drawing.Color.Transparent;
            this.cbAsTemplate.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbAsTemplate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAsTemplate.Checked = true;
            this.cbAsTemplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAsTemplate.Location = new System.Drawing.Point(13, 74);
            this.cbAsTemplate.Name = "cbAsTemplate";
            this.cbAsTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAsTemplate.Size = new System.Drawing.Size(164, 19);
            this.cbAsTemplate.TabIndex = 245;
            this.cbAsTemplate.Text = "Use Template Settings :";
            this.cbAsTemplate.CheckedChanged += new System.EventHandler(this.cbAsTemplate_CheckedChanged);
            // 
            // txtTemplateID
            // 
            this.txtTemplateID.AllowDrop = true;
            appearance11.TextHAlignAsString = "Right";
            this.txtTemplateID.Appearance = appearance11;
            this.txtTemplateID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTemplateID.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTemplateID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtTemplateID.InputMask = "nnnnnnnnn";
            this.txtTemplateID.Location = new System.Drawing.Point(126, 17);
            this.txtTemplateID.Name = "txtRetail";
            this.txtTemplateID.PromptChar = ' ';
            this.txtTemplateID.Size = new System.Drawing.Size(80, 20);
            this.txtTemplateID.TabIndex = 235;
            this.txtTemplateID.Text = "() -";
            this.txtTemplateID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // LabelTemplateID
            // 
            this.LabelTemplateID.BackColor = System.Drawing.Color.Transparent;
            this.LabelTemplateID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTemplateID.Location = new System.Drawing.Point(13, 17);
            this.LabelTemplateID.Name = "LabelTemplateID";
            this.LabelTemplateID.Size = new System.Drawing.Size(107, 20);
            this.LabelTemplateID.TabIndex = 236;
            this.LabelTemplateID.Text = "Card Template ID :";
            this.LabelTemplateID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCardByProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(600, 735);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCardByProduct";
            this.ShowInTaskbar = false;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            oProduct = new Product(CompanyID);
            oCard = new Signature.Classes.Card(CompanyID);
            oCardTemplate = new CardTemplate();
            
            this.Text += " - " + this.CompanyID;
            
            tStrip.Renderer = new WindowsVistaRenderer();
            
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
            #region txtTemplateID
            if (sender == txtTemplateID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oCardTemplate.View())
                    {

                        txtTemplateID.Text = oCardTemplate.ID;
                        txtTDescription.Text = oCardTemplate.Description;
                        DisplayCard();

                        return;


                    }
                    //this.txtDescription.Text = 
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtTemplateID.Text.Trim() == "")
                    {
                        txtTemplateID.Clear();
                        txtTemplateID.Focus();
                        return;
                    }

                    if (oCardTemplate.Find(Convert.ToInt32(txtTemplateID.Text)))
                    {
                        txtTemplateID.Text = oCardTemplate.ID;
                        txtTDescription.Text = oCardTemplate.Description;
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
            #region txtEnvTemplateID
            if (sender == txtEnvTemplateID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oCardTemplate.View())
                    {

                        txtEnvTemplateID.Text = oCardTemplate.ID;
                        txtEDescription.Text = oCardTemplate.Description;
                        DisplayCard();

                        return;


                    }
                    //this.txtDescription.Text = 
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtProductID.Text.Trim() == "")
                    {
                        txtEnvTemplateID.Clear();
                        txtEnvTemplateID.Focus();
                        return;
                    }

                    if (oCardTemplate.Find(Convert.ToInt32(txtEnvTemplateID.Text)))
                    {
                        txtEnvTemplateID.Text = oCardTemplate.ID;
                        txtEDescription.Text = oCardTemplate.Description;
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
                    
                    break;
                case Keys.PageDown:
                    Save();
                    Clear();
                    txtProductID.Clear();
                    txtProductID.Focus();
                    txtProductID.Enabled = true;
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
            txtTemplateID.Text="";
            txtEnvTemplateID.Text = "";
            txtPointX.Text = "";
            txtPointY.Text = "";
            cbAsTemplate.Checked = false;
            txtFilePath.Text = "";
            txtEDescription.Text = "";
            txtEnvTemplateID.Text = "";
            txtTDescription.Text = "";
        }

        public void Save()
        {
            if (txtTemplateID.Text.Trim() != "")
            {
                oCard.CompanyID = this.CompanyID;
                oCard.ProductID = oProduct.ID;
                oCard.CardTemplateID = (Int32) txtTemplateID.Number;
                oCard.EnvTemplateID = (Int32)txtEnvTemplateID.Number;
                oCard.AsTemplate = cbAsTemplate.Checked;
                oCard.FilePath = txtFilePath.Text;

                oCard.AsTemplate = cbAsTemplate.Checked;
                if (!cbAsTemplate.Checked)
                {
                    oCard.PointX = txtPointX.Number;
                    oCard.PointY = txtPointY.Number;
                }
                oCard.Save();
            }
            else
            {
                MessageBox.Show("Please enter CardTemplateID");
            }
        }

        public void Display()
        {
            Clear();
            txtProductID.Text = oProduct.ID;
            txtDescription.Text = oProduct.Description;

            if (oCard.Find(txtProductID.Text))
            {
                txtTemplateID.Text = oCard.CardTemplateID.ToString();
                txtEnvTemplateID.Text = oCard.EnvTemplateID.ToString();
                cbAsTemplate.Checked = oCard.AsTemplate;
                DisplayCard();
            
            }
            else
            {
                this.Clear();
            }
            
            cbAsTemplate_CheckedChanged(null, EventArgs.Empty);
        }
		#endregion

        private void DisplayCard()
        {
            if (txtEnvTemplateID.Text != "")
            {
                oCardTemplate.Find(Convert.ToInt32(txtEnvTemplateID.Text));
                txtEDescription.Text = oCardTemplate.Description;
            }
            if (txtTemplateID.Text == "")
            {
                return;
            }

            oCardTemplate.Find(Convert.ToInt32(txtTemplateID.Text));
            txtTDescription.Text = oCardTemplate.Description;

            

            if (!cbAsTemplate.Checked)
            {
                txtPointX.Text = oCard.PointX.ToString();
                txtPointY.Text = oCard.PointY.ToString();
            }
            else
            {
                txtPointX.Text = oCardTemplate.PointX.ToString();
                txtPointY.Text = oCardTemplate.PointY.ToString();
            }

            txtFilePath.Text = oCard.FilePath;
            DisplayImage();
        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {

            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (txtTemplateID.Text.Trim() != "" && txtProductID.Text.Trim() != "" && oProduct.ID != null)
            {

                if (!oCardTemplate.Find(Convert.ToInt32(txtTemplateID.Text)))
                {
                    MessageBox.Show("No template found: " + oCard.CardTemplateID.ToString());
                    return;
                }
                
                
                
                CardPrinter = new Signature.Card.CardPrinter();
                CardPrinter.Clear();
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");
             
                
                CardPrinter.PaperSize = oCardTemplate.PaperSize;
                CardPrinter.Copies = 1;
                CardPrinter.UpperCase = true;
                if (cbAsTemplate.Checked)
                    CardPrinter.Point = oCardTemplate.Point;
                else
                    CardPrinter.Point = new PointF((float)(txtPointX.Number * 100), (float)(txtPointY.Number * 100));
                CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                CardPrinter.TestMode = true;
                
                CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                CardPrinter.Print();
            }
        }
        private void toolPrintEnvelope_Click(object sender, EventArgs e)
        {
            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (txtEnvTemplateID.Text.Trim() != "" && txtProductID.Text.Trim() != "" && oProduct.ID != null)
            {
                CardPrinter = new Signature.Card.CardPrinter();
                CardPrinter.Clear();
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");
                CardPrinter.Add("01234567890123456789001234567890");



                if (!oCardTemplate.Find(Convert.ToInt32(txtEnvTemplateID.Text)))
                {
                    MessageBox.Show("No template found: " + oCard.EnvTemplateID.ToString());
                    return;
                }

                CardPrinter.PaperSize = oCardTemplate.PaperSize;
                CardPrinter.Copies = 1;
                CardPrinter.UpperCase = true;
                
                CardPrinter.Point = oCardTemplate.Point;
                
                CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                CardPrinter.TestMode = true;

                CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                CardPrinter.Print();
            }
        }

        private void cbAsTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAsTemplate.Checked)
            {
                LabelPointX.Visible = false;
                LabelPointY.Visible = false;
                txtPointX.Visible = false;
                txtPointY.Visible = false;

            }
            else
            {
                LabelPointX.Visible = true;
                LabelPointY.Visible = true;
                txtPointX.Visible = true;
                txtPointY.Visible = true;
            }
        }

        private void tooStripDraw_Click(object sender, EventArgs e)
        {
            
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
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                //g.FillRectangle(Brushes.White, new Rectangle(0, 0,               b.Width, b.Height));

                //g.DrawString(text, font, Brushes.Black, 50, 60);
            }

            picBarcode.Image = bitmap;
           // picBarcode.Size = new Size(oCardTemplate.PaperSize.Height/2, oCardTemplate.PaperSize.Width/2);
            

            if (bitmap.Width < bitmap.Height)
            {
                picBarcode.Image.RotateFlip(RotateFlipType.Rotate270FlipXY); //= bitmap;
                picBarcode.Invalidate();
            }
        }

        
	}
}
