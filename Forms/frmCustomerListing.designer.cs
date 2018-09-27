namespace Signature.Forms
{
    partial class frmCustomerListing
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.bRegisters = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtRepName = new Infragistics.Win.Misc.UltraLabel();
            this.txtRepID = new Signature.Windows.Forms.MaskedEdit();
            this.label44 = new System.Windows.Forms.Label();
            this.txtZero = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtName_2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID_2 = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            appearance1.AlphaLevel = ((short)(50));
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.bRegisters);
            this.ultraGroupBox1.Controls.Add(this.txtRepName);
            this.ultraGroupBox1.Controls.Add(this.txtRepID);
            this.ultraGroupBox1.Controls.Add(this.label44);
            this.ultraGroupBox1.Controls.Add(this.txtZero);
            this.ultraGroupBox1.Controls.Add(this.txtName_2);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID_2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(562, 196);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // bRegisters
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.White;
            this.bRegisters.Appearance = appearance2;
            this.bRegisters.BackColor = System.Drawing.Color.Transparent;
            this.bRegisters.BackColorInternal = System.Drawing.Color.Transparent;
            this.bRegisters.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bRegisters.Location = new System.Drawing.Point(255, 147);
            this.bRegisters.Name = "bRegisters";
            this.bRegisters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bRegisters.Size = new System.Drawing.Size(144, 19);
            this.bRegisters.TabIndex = 251;
            this.bRegisters.Text = "Cash Registers";
            this.bRegisters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtRepName
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.txtRepName.Appearance = appearance3;
            this.txtRepName.Location = new System.Drawing.Point(210, 151);
            this.txtRepName.Name = "txtRepName";
            this.txtRepName.Size = new System.Drawing.Size(327, 19);
            this.txtRepName.TabIndex = 250;
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            this.txtRepID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtRepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepID.Location = new System.Drawing.Point(122, 148);
            this.txtRepID.Name = "txtCustomerID";
            this.txtRepID.Size = new System.Drawing.Size(48, 20);
            this.txtRepID.TabIndex = 3;
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(37, 148);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(60, 18);
            this.label44.TabIndex = 249;
            this.label44.Text = "Rep ID :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZero
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BackColor2 = System.Drawing.Color.Transparent;
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.White;
            this.txtZero.Appearance = appearance4;
            this.txtZero.BackColor = System.Drawing.Color.Transparent;
            this.txtZero.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtZero.Location = new System.Drawing.Point(45, 92);
            this.txtZero.Name = "txtZero";
            this.txtZero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtZero.Size = new System.Drawing.Size(144, 19);
            this.txtZero.TabIndex = 2;
            this.txtZero.Text = "Print Zero Stataments?";
            this.txtZero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtName_2
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BackColor2 = System.Drawing.Color.Black;
            this.txtName_2.Appearance = appearance5;
            this.txtName_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName_2.Location = new System.Drawing.Point(210, 49);
            this.txtName_2.Name = "txtName_2";
            this.txtName_2.Size = new System.Drawing.Size(327, 25);
            this.txtName_2.TabIndex = 18;
            this.txtName_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtCustomerID_2
            // 
            this.txtCustomerID_2.AllowDrop = true;
            this.txtCustomerID_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID_2.Location = new System.Drawing.Point(122, 54);
            this.txtCustomerID_2.Name = "txtCustomerID";
            this.txtCustomerID_2.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID_2.TabIndex = 1;
            this.txtCustomerID_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "School ID To:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(122, 28);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtName
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance6;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(210, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(327, 25);
            this.txtName.TabIndex = 14;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(11, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "School ID From:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 225);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerListing";
            this.Text = "Customer Listing Criteria";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private System.Windows.Forms.Label label9;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID_2;
        private System.Windows.Forms.Label label1;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Infragistics.Win.Misc.UltraLabel txtName_2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtZero;
        private Infragistics.Win.Misc.UltraLabel txtRepName;
        private Signature.Windows.Forms.MaskedEdit txtRepID;
        internal System.Windows.Forms.Label label44;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor bRegisters;

    }
}