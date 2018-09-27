namespace Signature.Forms
{
    partial class frmCustomerStatement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.lvCustomers = new Infragistics.Win.UltraWinListView.UltraListView();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.txtPercent = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.cbZero = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.cbFinance = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNegative = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 498);
            this.txtStatus.Size = new System.Drawing.Size(482, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(112, 25);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.cbNegative);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.lvCustomers);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Controls.Add(this.txtPercent);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.cbZero);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.Label35);
            this.ultraGroupBox1.Controls.Add(this.cbFinance);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(482, 498);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lvCustomers
            // 
            appearance2.Image = global::Signature.Forms.Properties.Resources.office_building;
            this.lvCustomers.Appearance = appearance2;
            this.lvCustomers.Location = new System.Drawing.Point(26, 188);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(435, 250);
            this.lvCustomers.TabIndex = 273;
            this.lvCustomers.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 272;
            this.label4.Text = "Schools:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(75, 459);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "&Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance3.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance3;
            this.txtName.Location = new System.Drawing.Point(112, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(358, 19);
            this.txtName.TabIndex = 271;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(296, 458);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "&Print";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // txtPercent
            // 
            this.txtPercent.AllowDrop = true;
            appearance4.ForeColorDisabled = System.Drawing.Color.White;
            this.txtPercent.Appearance = appearance4;
            this.txtPercent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPercent.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPercent.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPercent.InputMask = "nn.nnn%";
            this.txtPercent.Location = new System.Drawing.Point(187, 130);
            this.txtPercent.Name = "txtSigned";
            this.txtPercent.PromptChar = ' ';
            this.txtPercent.Size = new System.Drawing.Size(48, 20);
            this.txtPercent.TabIndex = 270;
            this.txtPercent.Text = "1.5";
            this.txtPercent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(33, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 269;
            this.label3.Text = "Finance Charges %:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbZero
            // 
            this.cbZero.BackColor = System.Drawing.Color.Transparent;
            this.cbZero.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbZero.Location = new System.Drawing.Point(218, 74);
            this.cbZero.Name = "cbZero";
            this.cbZero.Size = new System.Drawing.Size(17, 20);
            this.cbZero.TabIndex = 268;
            this.cbZero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 267;
            this.label1.Text = "Print Zero Statements:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(23, 26);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFinance
            // 
            this.cbFinance.BackColor = System.Drawing.Color.Transparent;
            this.cbFinance.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbFinance.Location = new System.Drawing.Point(218, 100);
            this.cbFinance.Name = "cbFinance";
            this.cbFinance.Size = new System.Drawing.Size(17, 20);
            this.cbFinance.TabIndex = 264;
            this.cbFinance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(33, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 263;
            this.label2.Text = "Calc Finance Charges:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbNegative
            // 
            this.cbNegative.BackColor = System.Drawing.Color.Transparent;
            this.cbNegative.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbNegative.Location = new System.Drawing.Point(432, 74);
            this.cbNegative.Name = "cbNegative";
            this.cbNegative.Size = new System.Drawing.Size(17, 20);
            this.cbNegative.TabIndex = 275;
            this.cbNegative.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(269, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 30);
            this.label5.TabIndex = 274;
            this.label5.Text = "Print Only Negative Amounts:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 527);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerStatement";
            this.Text = "Customer Statement Report Criteria";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbFinance;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbZero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEditNumeric txtPercent;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Infragistics.Win.UltraWinListView.UltraListView lvCustomers;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbNegative;
        private System.Windows.Forms.Label label5;


    }
}