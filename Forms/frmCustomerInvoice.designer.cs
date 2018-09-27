namespace Signature.Forms
{
    partial class frmCustomerInvoice
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
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.isPDF = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtDateTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDateFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.cbPreInvoice = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.lvCustomers = new Infragistics.Win.UltraWinListView.UltraListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.cbInvoiceNotes = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.Label35 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInvoiceNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 534);
            this.txtStatus.Size = new System.Drawing.Size(498, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(108, 12);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(1));
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.isPDF);
            this.ultraGroupBox1.Controls.Add(this.groupBox1);
            this.ultraGroupBox1.Controls.Add(this.cbPreInvoice);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.lvCustomers);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Controls.Add(this.cbInvoiceNotes);
            this.ultraGroupBox1.Controls.Add(this.Label35);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(498, 534);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // isPDF
            // 
            this.isPDF.BackColor = System.Drawing.Color.Transparent;
            this.isPDF.BackColorInternal = System.Drawing.Color.Transparent;
            this.isPDF.Location = new System.Drawing.Point(96, 459);
            this.isPDF.Name = "isPDF";
            this.isPDF.Size = new System.Drawing.Size(79, 20);
            this.isPDF.TabIndex = 274;
            this.isPDF.Text = "Pdf";
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance2.AlphaLevel = ((short)(95));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance2;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(15, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 128);
            this.groupBox1.TabIndex = 273;
            this.groupBox1.Text = "Group Criteria";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(109, 52);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(91, 21);
            this.txtDateTo.TabIndex = 262;
            this.txtDateTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(109, 28);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(91, 21);
            this.txtDateFrom.TabIndex = 261;
            this.txtDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(20, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 18);
            this.label21.TabIndex = 266;
            this.label21.Text = "Date To :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 18);
            this.label22.TabIndex = 265;
            this.label22.Text = "Date From :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 264;
            this.label1.Text = "Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtType
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.txtType.Appearance = appearance3;
            this.txtType.BackColor = System.Drawing.Color.Transparent;
            this.txtType.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtType.CheckedIndex = 0;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            valueListItem1.Appearance = appearance4;
            valueListItem1.DataValue = "Signed";
            valueListItem1.DisplayText = "Signed";
            appearance5.BackColor = System.Drawing.Color.Transparent;
            valueListItem2.Appearance = appearance5;
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
            this.txtType.Location = new System.Drawing.Point(109, 94);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(355, 16);
            this.txtType.TabIndex = 263;
            this.txtType.Text = "Signed";
            this.txtType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // cbPreInvoice
            // 
            this.cbPreInvoice.BackColor = System.Drawing.Color.Transparent;
            this.cbPreInvoice.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbPreInvoice.Location = new System.Drawing.Point(305, 459);
            this.cbPreInvoice.Name = "cbPreInvoice";
            this.cbPreInvoice.Size = new System.Drawing.Size(17, 20);
            this.cbPreInvoice.TabIndex = 272;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(313, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 271;
            this.label3.Text = "Pre Invoice ?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Appearance = appearance6;
            this.txtName.Location = new System.Drawing.Point(22, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(457, 30);
            this.txtName.TabIndex = 270;
            // 
            // lvCustomers
            // 
            appearance7.Image = global::Signature.Forms.Properties.Resources.office_building;
            this.lvCustomers.Appearance = appearance7;
            this.lvCustomers.Location = new System.Drawing.Point(15, 258);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(471, 187);
            this.lvCustomers.TabIndex = 269;
            this.lvCustomers.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 268;
            this.label2.Text = "Invoice Note:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(84, 490);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "&Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(305, 489);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "&Print";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // cbInvoiceNotes
            // 
            this.cbInvoiceNotes.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            valueListItem8.DataValue = "0";
            valueListItem8.DisplayText = "PLEASE REMIT ENTIRE WHITE COPIES WITH PAYMENT";
            valueListItem9.DataValue = "1";
            valueListItem9.DisplayText = "ADDED TO INVOICE FOR LATE ORDERS DATED:";
            valueListItem10.DataValue = "2";
            valueListItem10.DisplayText = "Adjustment for avercharging on taxable items";
            valueListItem11.DataValue = "3";
            valueListItem11.DisplayText = "Invoice due to Customer overage correction";
            valueListItem12.DataValue = "4";
            valueListItem12.DisplayText = "PAYMENT DUE NO LATER THAN";
            valueListItem13.DataValue = "5";
            valueListItem13.DisplayText = "Thank you for your business. Please make payment within 15 days of invoice.";
            this.cbInvoiceNotes.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13});
            this.cbInvoiceNotes.Location = new System.Drawing.Point(15, 231);
            this.cbInvoiceNotes.Name = "cbInvoiceNotes";
            this.cbInvoiceNotes.Size = new System.Drawing.Size(471, 21);
            this.cbInvoiceNotes.TabIndex = 267;
            this.cbInvoiceNotes.Text = "PLEASE REMIT ENTIRE WHITE COPIES WITH PAYMENT";
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(19, 13);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 563);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerInvoice";
            this.Text = "Invoice Report Criteria";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbInvoiceNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbInvoiceNotes;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinListView.UltraListView lvCustomers;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbPreInvoice;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateFrom;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtType;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor isPDF;


    }
}