namespace Signature.Forms
{
    partial class frmBrochureProjected
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.bProcess = new Signature.Windows.Forms.Button();
            this.gbBrochures = new System.Windows.Forms.Panel();
            this.txtDescription_2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtBrochureID_2 = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitsProjected = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrochureID = new Signature.Windows.Forms.MaskedEdit();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 365);
            this.txtStatus.Size = new System.Drawing.Size(481, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance2.AlphaLevel = ((short)(95));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance2;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.bProcess);
            this.ultraGroupBox1.Controls.Add(this.gbBrochures);
            this.ultraGroupBox1.Controls.Add(this.txtDescription_2);
            this.ultraGroupBox1.Controls.Add(this.txtBrochureID_2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtUnitsProjected);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtBrochureID);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(481, 365);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // bProcess
            // 
            this.bProcess.AllowDrop = true;
            this.bProcess.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bProcess.ForeColor = System.Drawing.Color.Black;
            this.bProcess.Location = new System.Drawing.Point(163, 307);
            this.bProcess.Name = "txtPrint";
            this.bProcess.Size = new System.Drawing.Size(124, 31);
            this.bProcess.TabIndex = 268;
            this.bProcess.Text = "Process";
            this.bProcess.Click += new System.EventHandler(this.bProcess_Click);
            // 
            // gbBrochures
            // 
            this.gbBrochures.AutoScroll = true;
            this.gbBrochures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gbBrochures.Location = new System.Drawing.Point(14, 75);
            this.gbBrochures.Name = "gbBrochures";
            this.gbBrochures.Size = new System.Drawing.Size(447, 214);
            this.gbBrochures.TabIndex = 267;
            // 
            // txtDescription_2
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription_2.Appearance = appearance1;
            this.txtDescription_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription_2.Location = new System.Drawing.Point(205, 50);
            this.txtDescription_2.Name = "txtDescription_2";
            this.txtDescription_2.Size = new System.Drawing.Size(256, 19);
            this.txtDescription_2.TabIndex = 265;
            this.txtDescription_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtBrochureID_2
            // 
            this.txtBrochureID_2.AllowDrop = true;
            this.txtBrochureID_2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrochureID_2.Location = new System.Drawing.Point(132, 50);
            this.txtBrochureID_2.Name = "txtCustomerID";
            this.txtBrochureID_2.Size = new System.Drawing.Size(67, 20);
            this.txtBrochureID_2.TabIndex = 263;
            this.txtBrochureID_2.Visible = false;
            this.txtBrochureID_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 264;
            this.label1.Text = "Brochure ID 2:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // txtUnitsProjected
            // 
            this.txtUnitsProjected.AllowDrop = true;
            this.txtUnitsProjected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtUnitsProjected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitsProjected.Location = new System.Drawing.Point(141, 29);
            this.txtUnitsProjected.Name = "txtCustomerID";
            this.txtUnitsProjected.Size = new System.Drawing.Size(86, 20);
            this.txtUnitsProjected.TabIndex = 261;
            this.txtUnitsProjected.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(22, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 262;
            this.label4.Text = "Total Unit Projected:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBrochureID
            // 
            this.txtBrochureID.AllowDrop = true;
            this.txtBrochureID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrochureID.Location = new System.Drawing.Point(132, 28);
            this.txtBrochureID.Name = "txtCustomerID";
            this.txtBrochureID.Size = new System.Drawing.Size(67, 20);
            this.txtBrochureID.TabIndex = 0;
            this.txtBrochureID.Visible = false;
            this.txtBrochureID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance3;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(205, 29);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 19);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(24, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Brochure ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Visible = false;
            // 
            // frmBrochureProjected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 394);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmBrochureProjected";
            this.Text = "Brochure Projected";
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
        private Signature.Windows.Forms.MaskedEdit txtBrochureID;
        private Signature.Windows.Forms.MaskedEdit txtUnitsProjected;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraLabel txtDescription_2;
        private Signature.Windows.Forms.MaskedEdit txtBrochureID_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gbBrochures;
        private Signature.Windows.Forms.Button bProcess;

    }
}