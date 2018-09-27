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
using Signature.Card;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmCardTemplate : frmBase
	{
		#region declarations		

        private ToolStrip tStrip;
        private Signature.Card.CardPrinter CardPrinter;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private MaskedEditNumeric txtTemplateID;
        internal Label LabelTemplateID;
        private Signature.Windows.Forms.MaskedEdit txtTDescription;
        private Signature.Classes.CardTemplate oCardTemplate;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private MaskedEditNumeric txtWidth;
        internal Label label6;
        private MaskedEditNumeric txtHeight;
        internal Label label7;
        private Signature.Windows.Forms.GroupBox groupBox2;
        private MaskedEditNumeric txtPointY;
        internal Label label1;
        private MaskedEditNumeric txtPointX;
        internal Label label5;
        private Signature.Windows.Forms.GroupBox ultraGroupBox4;
        private MaskedEditNumeric txtPaperSizeWidth;
        internal Label label2;
        private MaskedEditNumeric txtPaperSizeHeight;
        internal Label label3;
        private Signature.Windows.Forms.GroupBox groupBox4;
        public MaskedEdit txtFontName;
        private Label label4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbBold;
        private MaskedEditNumeric txtFontSize;
        internal Label label8;
        private MaskedEditNumeric txtRotation;
        private ToolStripButton toolDraw;
        internal Label label9;
		#endregion
       
        

        public frmCardTemplate()
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardTemplate));
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.groupBox4 = new Signature.Windows.Forms.GroupBox();
            this.txtFontSize = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFontName = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBold = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.txtWidth = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtRotation = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPointY = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPointX = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label5 = new System.Windows.Forms.Label();
            this.ultraGroupBox4 = new Signature.Windows.Forms.GroupBox();
            this.txtPaperSizeWidth = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaperSizeHeight = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTDescription = new Signature.Windows.Forms.MaskedEdit();
            this.txtTemplateID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.LabelTemplateID = new System.Windows.Forms.Label();
            this.toolDraw = new System.Windows.Forms.ToolStripButton();
            toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.tStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 307);
            this.txtStatus.Size = new System.Drawing.Size(596, 29);
            // 
            // toolStripPrint
            // 
            toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripPrint.Name = "toolStripPrint";
            toolStripPrint.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            toolStripPrint.Size = new System.Drawing.Size(76, 22);
            toolStripPrint.Text = "Print";
            toolStripPrint.Click += new System.EventHandler(this.toolStripPrint_Click);
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripPrint,
            this.toolDraw});
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Size = new System.Drawing.Size(596, 25);
            this.tStrip.TabIndex = 56;
            this.tStrip.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance1;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ultraGroupBox4);
            this.groupBox1.Controls.Add(this.txtTDescription);
            this.groupBox1.Controls.Add(this.txtTemplateID);
            this.groupBox1.Controls.Add(this.LabelTemplateID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "ultraGroupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 282);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // groupBox4
            // 
            this.groupBox4.AllowDrop = true;
            appearance2.AlphaLevel = ((short)(250));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Appearance = appearance2;
            this.groupBox4.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.txtFontSize);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtFontName);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbBold);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(226, 145);
            this.groupBox4.Name = "ultraGroupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 90);
            this.groupBox4.TabIndex = 261;
            this.groupBox4.Text = "Characters";
            this.groupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtFontSize
            // 
            this.txtFontSize.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtFontSize.Appearance = appearance3;
            this.txtFontSize.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFontSize.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtFontSize.FormatString = "###,###.##";
            this.txtFontSize.InputMask = "{LOC}nnn";
            this.txtFontSize.Location = new System.Drawing.Point(58, 64);
            this.txtFontSize.Name = "txtAmountDue";
            this.txtFontSize.Size = new System.Drawing.Size(48, 20);
            this.txtFontSize.TabIndex = 259;
            this.txtFontSize.Text = "0";
            this.txtFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 260;
            this.label8.Text = "Size :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFontName
            // 
            this.txtFontName.AllowDrop = true;
            this.txtFontName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtFontName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFontName.Location = new System.Drawing.Point(58, 39);
            this.txtFontName.Name = "txtCustomerID";
            this.txtFontName.Size = new System.Drawing.Size(245, 20);
            this.txtFontName.TabIndex = 257;
            this.txtFontName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 258;
            this.label4.Text = "Font :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBold
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BackColor2 = System.Drawing.Color.Transparent;
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.White;
            this.cbBold.Appearance = appearance4;
            this.cbBold.BackColor = System.Drawing.Color.Transparent;
            this.cbBold.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbBold.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBold.Checked = true;
            this.cbBold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBold.Location = new System.Drawing.Point(19, 19);
            this.cbBold.Name = "cbBold";
            this.cbBold.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbBold.Size = new System.Drawing.Size(52, 19);
            this.cbBold.TabIndex = 246;
            this.cbBold.Text = "Bold :";
            this.cbBold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance5.AlphaLevel = ((short)(250));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance5;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.txtWidth);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtHeight);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(12, 49);
            this.groupBox3.Name = "ultraGroupBox4";
            this.groupBox3.Size = new System.Drawing.Size(204, 90);
            this.groupBox3.TabIndex = 260;
            this.groupBox3.Text = "Canvas";
            this.groupBox3.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowDrop = true;
            appearance6.TextHAlignAsString = "Right";
            this.txtWidth.Appearance = appearance6;
            this.txtWidth.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtWidth.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtWidth.FormatString = "###,###.##";
            this.txtWidth.InputMask = "{LOC}nnnnnnn.nn";
            this.txtWidth.Location = new System.Drawing.Point(106, 54);
            this.txtWidth.Name = "txtAmountDue";
            this.txtWidth.Size = new System.Drawing.Size(64, 20);
            this.txtWidth.TabIndex = 257;
            this.txtWidth.Text = "0";
            this.txtWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 258;
            this.label6.Text = "Width :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowDrop = true;
            appearance7.TextHAlignAsString = "Right";
            this.txtHeight.Appearance = appearance7;
            this.txtHeight.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtHeight.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtHeight.FormatString = "###,###.##";
            this.txtHeight.InputMask = "{LOC}nnnnnnn.nn";
            this.txtHeight.Location = new System.Drawing.Point(106, 28);
            this.txtHeight.Name = "txtAmountDue";
            this.txtHeight.Size = new System.Drawing.Size(64, 20);
            this.txtHeight.TabIndex = 255;
            this.txtHeight.Text = "0";
            this.txtHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 256;
            this.label7.Text = "Height :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance8.AlphaLevel = ((short)(250));
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance8;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtRotation);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPointY);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPointX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(226, 49);
            this.groupBox2.Name = "ultraGroupBox4";
            this.groupBox2.Size = new System.Drawing.Size(331, 90);
            this.groupBox2.TabIndex = 259;
            this.groupBox2.Text = "Point";
            this.groupBox2.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtRotation
            // 
            this.txtRotation.AllowDrop = true;
            appearance9.TextHAlignAsString = "Right";
            this.txtRotation.Appearance = appearance9;
            this.txtRotation.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRotation.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRotation.FormatString = "###";
            this.txtRotation.InputMask = "{LOC}nnn";
            this.txtRotation.Location = new System.Drawing.Point(239, 28);
            this.txtRotation.Name = "txtAmountDue";
            this.txtRotation.Size = new System.Drawing.Size(47, 20);
            this.txtRotation.TabIndex = 259;
            this.txtRotation.Text = "0";
            this.txtRotation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(172, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 18);
            this.label9.TabIndex = 260;
            this.label9.Text = "Rotation :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPointY
            // 
            this.txtPointY.AllowDrop = true;
            appearance10.TextHAlignAsString = "Right";
            this.txtPointY.Appearance = appearance10;
            this.txtPointY.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPointY.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPointY.FormatString = "###,###.##";
            this.txtPointY.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPointY.Location = new System.Drawing.Point(78, 54);
            this.txtPointY.Name = "txtAmountDue";
            this.txtPointY.Size = new System.Drawing.Size(64, 20);
            this.txtPointY.TabIndex = 257;
            this.txtPointY.Text = "0";
            this.txtPointY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 258;
            this.label1.Text = "PointY :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPointX
            // 
            this.txtPointX.AllowDrop = true;
            appearance11.TextHAlignAsString = "Right";
            this.txtPointX.Appearance = appearance11;
            this.txtPointX.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPointX.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPointX.FormatString = "###,###.##";
            this.txtPointX.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPointX.Location = new System.Drawing.Point(78, 28);
            this.txtPointX.Name = "txtAmountDue";
            this.txtPointX.Size = new System.Drawing.Size(64, 20);
            this.txtPointX.TabIndex = 255;
            this.txtPointX.Text = "0";
            this.txtPointX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 256;
            this.label5.Text = "PointX :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.AllowDrop = true;
            appearance12.AlphaLevel = ((short)(250));
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox4.Appearance = appearance12;
            this.ultraGroupBox4.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox4.Controls.Add(this.txtPaperSizeWidth);
            this.ultraGroupBox4.Controls.Add(this.label2);
            this.ultraGroupBox4.Controls.Add(this.txtPaperSizeHeight);
            this.ultraGroupBox4.Controls.Add(this.label3);
            this.ultraGroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox4.Location = new System.Drawing.Point(12, 145);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(204, 90);
            this.ultraGroupBox4.TabIndex = 257;
            this.ultraGroupBox4.Text = "Paper Size";
            this.ultraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtPaperSizeWidth
            // 
            this.txtPaperSizeWidth.AllowDrop = true;
            appearance13.TextHAlignAsString = "Right";
            this.txtPaperSizeWidth.Appearance = appearance13;
            this.txtPaperSizeWidth.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPaperSizeWidth.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPaperSizeWidth.FormatString = "###,###.##";
            this.txtPaperSizeWidth.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPaperSizeWidth.Location = new System.Drawing.Point(106, 54);
            this.txtPaperSizeWidth.Name = "txtAmountDue";
            this.txtPaperSizeWidth.Size = new System.Drawing.Size(64, 20);
            this.txtPaperSizeWidth.TabIndex = 257;
            this.txtPaperSizeWidth.Text = "0";
            this.txtPaperSizeWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 258;
            this.label2.Text = "Width :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaperSizeHeight
            // 
            this.txtPaperSizeHeight.AllowDrop = true;
            appearance14.TextHAlignAsString = "Right";
            this.txtPaperSizeHeight.Appearance = appearance14;
            this.txtPaperSizeHeight.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPaperSizeHeight.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPaperSizeHeight.FormatString = "###,###.##";
            this.txtPaperSizeHeight.InputMask = "{LOC}nnnnnnn.nn";
            this.txtPaperSizeHeight.Location = new System.Drawing.Point(106, 28);
            this.txtPaperSizeHeight.Name = "txtAmountDue";
            this.txtPaperSizeHeight.Size = new System.Drawing.Size(64, 20);
            this.txtPaperSizeHeight.TabIndex = 255;
            this.txtPaperSizeHeight.Text = "0";
            this.txtPaperSizeHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 256;
            this.label3.Text = "Height :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTDescription
            // 
            this.txtTDescription.AllowDrop = true;
            this.txtTDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDescription.Location = new System.Drawing.Point(183, 16);
            this.txtTDescription.Name = "txtTDescription";
            this.txtTDescription.Size = new System.Drawing.Size(374, 20);
            this.txtTDescription.TabIndex = 246;
            this.txtTDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTemplateID
            // 
            this.txtTemplateID.AllowDrop = true;
            appearance16.TextHAlignAsString = "Right";
            this.txtTemplateID.Appearance = appearance16;
            this.txtTemplateID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtTemplateID.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTemplateID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtTemplateID.InputMask = "nnnnnnnnn";
            this.txtTemplateID.Location = new System.Drawing.Point(97, 16);
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
            this.LabelTemplateID.Location = new System.Drawing.Point(13, 16);
            this.LabelTemplateID.Name = "LabelTemplateID";
            this.LabelTemplateID.Size = new System.Drawing.Size(78, 20);
            this.LabelTemplateID.TabIndex = 236;
            this.LabelTemplateID.Text = "Template ID :";
            this.LabelTemplateID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolDraw
            // 
            this.toolDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDraw.Image = ((System.Drawing.Image)(resources.GetObject("toolDraw.Image")));
            this.toolDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDraw.Name = "toolDraw";
            this.toolDraw.Size = new System.Drawing.Size(38, 22);
            this.toolDraw.Text = "Draw";
            this.toolDraw.Click += new System.EventHandler(this.toolDraw_Click);
            // 
            // frmCardTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(596, 336);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tStrip);
            this.Name = "frmCardTemplate";
            this.ShowInTaskbar = false;
            this.Text = "Card Template";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
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
            
            oCardTemplate = new CardTemplate();
            
            this.Text += " - " + this.CompanyID;
            
            tStrip.Renderer = new WindowsVistaRenderer();
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //MessageBox.Show(e.KeyCode.ToString());

            
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
                    if (txtTemplateID.Text.Trim() != "")
                    {
                        if (oCardTemplate.Find(Convert.ToInt32(txtTemplateID.Text)))
                        {
                            txtTemplateID.Text = oCardTemplate.ID;
                            txtTDescription.Text = oCardTemplate.Description;
                            DisplayCard();

                            return;
                        }

                    }
                    else
                    {

                        txtTemplateID.Clear();
                        txtTemplateID.Focus();
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
                    txtTemplateID.Focus();
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
            txtTemplateID.Focus();
            
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
            txtPointX.Text = "";
            txtPointY.Text = "";
            cbBold.Checked = false;
            txtFontSize.Clear();
            txtHeight.Clear();
            txtWidth.Clear();
            txtRotation.Clear();
            txtFontName.Clear();
            txtPaperSizeHeight.Clear();
            txtPaperSizeWidth.Clear();
            txtTDescription.Clear();
        }

        public void Save()
        {
            if (txtTemplateID.Text.Trim() != "")
            {
                oCardTemplate.ID = txtTemplateID.Text;
                oCardTemplate.Description = txtTDescription.Text;
                oCardTemplate.Bold = cbBold.Checked;
                oCardTemplate.PointX = txtPointX.Number;
                oCardTemplate.PointY = txtPointY.Number;
                oCardTemplate.PaperSizeHeight = txtPaperSizeHeight.Number;
                oCardTemplate.PaperSizeWidth = txtPaperSizeWidth.Number;
                oCardTemplate.Width = txtWidth.Number;
                oCardTemplate.Height = txtHeight.Number;
                oCardTemplate.FontName = txtFontName.Text;
                oCardTemplate.FontSize = (Int32) txtFontSize.Number;
                oCardTemplate.Rotation = (Int32)txtRotation.Number;
                oCardTemplate.Save();
            }
            else
            {
                MessageBox.Show("Please enter CardTemplateID");
            }
        }

        public void Display()
        {
            Clear();
            /*
            if (oCard.Find(txtProductID.Text))
            {
                txtTemplateID.Text = oCard.CardTemplateID.ToString();
                cbBold.Checked = oCard.AsTemplate;
                DisplayCard();
            
            }
            else
            {
                this.Clear();
            }
            */
            cbAsTemplate_CheckedChanged(null, EventArgs.Empty);
        }
		#endregion

        private void DisplayCard()
        {
            
            oCardTemplate.Find(Convert.ToInt32(txtTemplateID.Text));
            txtPointX.Text = oCardTemplate.PointX.ToString();
            txtPointY.Text = oCardTemplate.PointY.ToString();
            txtFontName.Text = oCardTemplate.FontName;
            txtHeight.Text = oCardTemplate.Height.ToString();
            txtWidth.Text = oCardTemplate.Width.ToString();
            txtPaperSizeHeight.Text = oCardTemplate.PaperSizeHeight.ToString();
            txtPaperSizeWidth.Text = oCardTemplate.PaperSizeWidth.ToString();
            txtRotation.Text = oCardTemplate.Rotation.ToString();
            txtFontSize.Text = oCardTemplate.FontSize.ToString();
            cbBold.Checked = oCardTemplate.Bold;
        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {

            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (txtTemplateID.Text.Trim() != "" )
            {
                CardPrinter = new Signature.Card.CardPrinter();
                CardPrinter.Clear();
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");
                

                CardPrinter.PaperSize = oCardTemplate.PaperSize;
                CardPrinter.Copies = 1;
                CardPrinter.UpperCase = true;
                
               // if (cbBold.Checked)
                 CardPrinter.Point = oCardTemplate.Point;
               // else
               // CardPrinter.Point = new PointF((float)(txtPointX.Number * 100), (float)(txtPointY.Number * 100));
                CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                CardPrinter.TestMode = true;

                CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                CardPrinter.PrintType = Signature.Card.CardPrintType.Text;
                CardPrinter.Print();
            }
        }

        private void cbAsTemplate_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tooStripDraw_Click(object sender, EventArgs e)
        {
            
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            
        }

        private void toolDraw_Click(object sender, EventArgs e)
        {
            if (txtTemplateID.Text.Trim() != "")
            {
                CardPrinter = new Signature.Card.CardPrinter();
                CardPrinter.Clear();
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");
                CardPrinter.Add("ABCDEFGHIJKLMNOPQRSTUWXYZ01234");


                CardPrinter.PaperSize = oCardTemplate.PaperSize;
                CardPrinter.Copies = 1;
                CardPrinter.UpperCase = true;

                // if (cbBold.Checked)
                CardPrinter.Point = oCardTemplate.Point;
                // else
                // CardPrinter.Point = new PointF((float)(txtPointX.Number * 100), (float)(txtPointY.Number * 100));
                CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                CardPrinter.TestMode = true;

                CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                CardPrinter.PrintType = Signature.Card.CardPrintType.Image;
                CardPrinter.Print();
            }
        }

        

        
	}
}
