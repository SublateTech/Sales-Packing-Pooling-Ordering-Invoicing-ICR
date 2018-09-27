namespace Signature.Forms
{
    partial class frmDevice 
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevice));
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtCancel = new Signature.Windows.Forms.GlassButton();
            this.txtSave = new Signature.Windows.Forms.GlassButton();
            this.l_eMail = new System.Windows.Forms.Label();
            this.txteMail = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDevice = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 217);
            this.txtStatus.Size = new System.Drawing.Size(426, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D;
            this.ultraGroupBox1.Controls.Add(this.txtCancel);
            this.ultraGroupBox1.Controls.Add(this.txtSave);
            this.ultraGroupBox1.Controls.Add(this.l_eMail);
            this.ultraGroupBox1.Controls.Add(this.txteMail);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtDevice);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(426, 217);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtCancel
            // 
            this.txtCancel.Location = new System.Drawing.Point(52, 165);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(124, 33);
            this.txtCancel.TabIndex = 270;
            this.txtCancel.Text = "Cancel";
            this.txtCancel.Click += new System.EventHandler(this.txtCancel_Click);
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(249, 165);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(117, 33);
            this.txtSave.TabIndex = 269;
            this.txtSave.Text = "OK";
            this.txtSave.Click += new System.EventHandler(this.txtSave_Click);
            // 
            // l_eMail
            // 
            this.l_eMail.BackColor = System.Drawing.Color.Transparent;
            this.l_eMail.Location = new System.Drawing.Point(21, 126);
            this.l_eMail.Name = "l_eMail";
            this.l_eMail.Size = new System.Drawing.Size(60, 19);
            this.l_eMail.TabIndex = 268;
            this.l_eMail.Text = "eMail:";
            this.l_eMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txteMail
            // 
            this.txteMail.AllowDrop = true;
            this.txteMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txteMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txteMail.Location = new System.Drawing.Point(121, 125);
            this.txteMail.Name = "txtCustomerID";
            this.txteMail.Size = new System.Drawing.Size(293, 20);
            this.txteMail.TabIndex = 267;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 266;
            this.label1.Text = "Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDevice
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BorderColor = System.Drawing.Color.White;
            this.txtDevice.Appearance = appearance2;
            this.txtDevice.BackColor = System.Drawing.Color.Transparent;
            this.txtDevice.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtDevice.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtDevice.CheckedIndex = 0;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.White;
            appearance3.ForeColor = System.Drawing.Color.Black;
            valueListItem1.Appearance = appearance3;
            valueListItem1.DataValue = "Printer";
            valueListItem1.DisplayText = "Printer";
            appearance4.BackColor = System.Drawing.Color.Transparent;
            valueListItem2.Appearance = appearance4;
            valueListItem2.DataValue = "eMail";
            valueListItem2.DisplayText = "eMail";
            valueListItem3.DataValue = "Preview";
            valueListItem3.DisplayText = "Preview";
            this.txtDevice.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.txtDevice.ItemSpacingVertical = 20;
            this.txtDevice.Location = new System.Drawing.Point(121, 13);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(91, 104);
            this.txtDevice.TabIndex = 265;
            this.txtDevice.Text = "Printer";
            this.txtDevice.ValueChanged += new System.EventHandler(this.txtType_ValueChanged);
            // 
            // frmDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 246);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDevice";
            this.Text = "Device";
            this.Load += new System.EventHandler(this.frmDevice_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtDevice;
        private System.Windows.Forms.Label l_eMail;
        private Signature.Windows.Forms.MaskedEdit txteMail;
        private Signature.Windows.Forms.GlassButton txtCancel;
        private Signature.Windows.Forms.GlassButton txtSave;








    }
}