namespace Signature.Forms
{
    partial class frmCustomerDrawingTickets
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtBreakAmount = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFor = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.txtRepName = new Infragistics.Win.Misc.UltraLabel();
            this.txtName_2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtBreakAmount);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtFor);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtType);
            this.ultraGroupBox1.Controls.Add(this.txtRepName);
            this.ultraGroupBox1.Controls.Add(this.txtName_2);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(562, 185);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtBreakAmount
            // 
            this.txtBreakAmount.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtBreakAmount.Appearance = appearance2;
            this.txtBreakAmount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtBreakAmount.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBreakAmount.FormatString = "###,###.##";
            this.txtBreakAmount.InputMask = "{LOC}nnnnnnn.nn";
            this.txtBreakAmount.Location = new System.Drawing.Point(122, 144);
            this.txtBreakAmount.Name = "txtAmountDue";
            this.txtBreakAmount.Size = new System.Drawing.Size(88, 20);
            this.txtBreakAmount.TabIndex = 256;
            this.txtBreakAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 255;
            this.label3.Text = "Break Amount :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFor
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.txtFor.Appearance = appearance3;
            this.txtFor.BackColor = System.Drawing.Color.Transparent;
            this.txtFor.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtFor.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            valueListItem1.Appearance = appearance4;
            valueListItem1.DataValue = 0F;
            valueListItem1.DisplayText = "Minumum";
            appearance5.BackColor = System.Drawing.Color.Transparent;
            valueListItem2.Appearance = appearance5;
            valueListItem2.DataValue = 1F;
            valueListItem2.DisplayText = "Every";
            this.txtFor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.txtFor.Location = new System.Drawing.Point(122, 109);
            this.txtFor.Name = "txtFor";
            this.txtFor.Size = new System.Drawing.Size(122, 16);
            this.txtFor.TabIndex = 254;
            this.txtFor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(14, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 253;
            this.label2.Text = "Print For:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 252;
            this.label1.Text = "Print Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtType
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.BorderColor = System.Drawing.Color.White;
            this.txtType.Appearance = appearance6;
            this.txtType.BackColor = System.Drawing.Color.Transparent;
            this.txtType.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtType.CheckedIndex = 0;
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.BorderColor = System.Drawing.Color.White;
            appearance7.ForeColor = System.Drawing.Color.Black;
            valueListItem3.Appearance = appearance7;
            valueListItem3.DataValue = 0F;
            valueListItem3.DisplayText = "Units";
            appearance8.BackColor = System.Drawing.Color.Transparent;
            valueListItem4.Appearance = appearance8;
            valueListItem4.DataValue = 1F;
            valueListItem4.DisplayText = "Retail";
            valueListItem5.DataValue = "Label";
            valueListItem5.DisplayText = "Label";
            this.txtType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.txtType.Location = new System.Drawing.Point(122, 80);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(150, 16);
            this.txtType.TabIndex = 251;
            this.txtType.Text = "Units";
            this.txtType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtRepName
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.txtRepName.Appearance = appearance9;
            this.txtRepName.Location = new System.Drawing.Point(210, 247);
            this.txtRepName.Name = "txtRepName";
            this.txtRepName.Size = new System.Drawing.Size(327, 19);
            this.txtRepName.TabIndex = 250;
            // 
            // txtName_2
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.BackColor2 = System.Drawing.Color.Black;
            this.txtName_2.Appearance = appearance10;
            this.txtName_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName_2.Location = new System.Drawing.Point(210, 49);
            this.txtName_2.Name = "txtName_2";
            this.txtName_2.Size = new System.Drawing.Size(327, 25);
            this.txtName_2.TabIndex = 18;
            this.txtName_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
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
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance11;
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
            this.label9.Location = new System.Drawing.Point(37, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "School ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerDrawingTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 214);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerDrawingTickets";
            this.Text = "Drawing Tickets Criteria";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private System.Windows.Forms.Label label9;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Infragistics.Win.Misc.UltraLabel txtName_2;
        private Infragistics.Win.Misc.UltraLabel txtRepName;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtType;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtFor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEditNumeric txtBreakAmount;

    }
}