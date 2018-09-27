namespace Signature.Forms
{
    partial class frmProductListing
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
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtChecked = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtProductID_2 = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription_2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 127);
            this.txtStatus.Size = new System.Drawing.Size(562, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtChecked);
            this.ultraGroupBox1.Controls.Add(this.txtProductID_2);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtDescription_2);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(562, 127);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtChecked
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            appearance26.BackColor2 = System.Drawing.Color.Transparent;
            appearance26.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.White;
            this.txtChecked.Appearance = appearance26;
            this.txtChecked.BackColor = System.Drawing.Color.Transparent;
            this.txtChecked.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtChecked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtChecked.Location = new System.Drawing.Point(27, 86);
            this.txtChecked.Name = "txtChecked";
            this.txtChecked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChecked.Size = new System.Drawing.Size(162, 21);
            this.txtChecked.TabIndex = 263;
            this.txtChecked.Text = "Landed Cost :";
            this.txtChecked.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtProductID_2
            // 
            this.txtProductID_2.AllowDrop = true;
            this.txtProductID_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID_2.Location = new System.Drawing.Point(122, 56);
            this.txtProductID_2.Name = "txtCustomerID";
            this.txtProductID_2.Size = new System.Drawing.Size(67, 20);
            this.txtProductID_2.TabIndex = 261;
            this.txtProductID_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(37, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 262;
            this.label4.Text = "Product To:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription_2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription_2.Appearance = appearance2;
            this.txtDescription_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription_2.Location = new System.Drawing.Point(210, 54);
            this.txtDescription_2.Name = "txtDescription_2";
            this.txtDescription_2.Size = new System.Drawing.Size(327, 25);
            this.txtDescription_2.TabIndex = 18;
            this.txtDescription_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(122, 28);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(67, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance3;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(210, 23);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(327, 25);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(24, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Product From:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProductListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 156);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmProductListing";
            this.Text = "Item Listing Criteria";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel txtDescription;
        private System.Windows.Forms.Label label9;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Infragistics.Win.Misc.UltraLabel txtDescription_2;
        private Signature.Windows.Forms.MaskedEdit txtProductID_2;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtChecked;

    }
}