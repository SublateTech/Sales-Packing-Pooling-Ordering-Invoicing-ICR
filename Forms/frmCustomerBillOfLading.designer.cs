namespace Signature.Forms
{
    partial class frmCustomerBillOfLading
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDateFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDateTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.Label35 = new System.Windows.Forms.Label();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.btCancel = new Signature.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 197);
            this.txtStatus.Size = new System.Drawing.Size(482, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(336, 13);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtType
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.White;
            this.txtType.Appearance = appearance1;
            this.txtType.BackColor = System.Drawing.Color.Transparent;
            this.txtType.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtType.CheckedIndex = 0;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BorderColor = System.Drawing.Color.White;
            appearance2.ForeColor = System.Drawing.Color.Black;
            valueListItem1.Appearance = appearance2;
            valueListItem1.DataValue = "Signed";
            valueListItem1.DisplayText = "Signed";
            appearance3.BackColor = System.Drawing.Color.Transparent;
            valueListItem2.Appearance = appearance3;
            valueListItem2.DataValue = "Start";
            valueListItem2.DisplayText = "Start";
            valueListItem3.DataValue = "End";
            valueListItem3.DisplayText = "End";
            valueListItem4.DataValue = "Pickup";
            valueListItem4.DisplayText = "Pickup";
            valueListItem5.DataValue = "Delivery";
            valueListItem5.DisplayText = "Delivery";
            valueListItem6.DataValue = "Ship";
            valueListItem6.DisplayText = "Ship";
            valueListItem7.DataValue = "All";
            valueListItem7.DisplayText = "All";
            this.txtType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.txtType.Location = new System.Drawing.Point(112, 93);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(355, 16);
            this.txtType.TabIndex = 2;
            this.txtType.Text = "Signed";
            this.txtType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(30, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 252;
            this.label1.Text = "Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 18);
            this.label22.TabIndex = 259;
            this.label22.Text = "Date From :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(36, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 18);
            this.label21.TabIndex = 260;
            this.label21.Text = "Date To :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(112, 12);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(91, 21);
            this.txtDateFrom.TabIndex = 0;
            this.txtDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(112, 36);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(91, 21);
            this.txtDateTo.TabIndex = 1;
            this.txtDateTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance5.AlphaLevel = ((short)(95));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance5;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.Label35);
            this.ultraGroupBox1.Controls.Add(this.txtDateTo);
            this.ultraGroupBox1.Controls.Add(this.txtDateFrom);
            this.ultraGroupBox1.Controls.Add(this.label21);
            this.ultraGroupBox1.Controls.Add(this.label22);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtType);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(482, 197);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Appearance = appearance4;
            this.txtName.Location = new System.Drawing.Point(262, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(214, 42);
            this.txtName.TabIndex = 267;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(247, 14);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(300, 163);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "&Print";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(79, 164);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "&Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmCustomerBillOfLading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 226);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerBillOfLading";
            this.Text = "Straight Bill Of Lading Report Criteria";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.btPrint, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtType;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateFrom;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateTo;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private Signature.Windows.Forms.MaskedLabel txtName;


    }
}