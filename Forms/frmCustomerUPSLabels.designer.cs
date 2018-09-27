namespace Signature.Forms
{
    partial class frmCustomerUPSLabels
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.gbShippingOptions = new Signature.Windows.Forms.GroupBox();
            this.opLabel = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCopies = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtWeight = new Signature.Windows.Forms.MaskedEditNumeric();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtDateTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDateFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.cbServiceType = new Signature.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.lvCustomers = new Infragistics.Win.UltraWinListView.UltraListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.Label35 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbShippingOptions)).BeginInit();
            this.gbShippingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 575);
            this.txtStatus.Size = new System.Drawing.Size(482, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(99, 35);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance9.AlphaLevel = ((short)(95));
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance9;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.gbShippingOptions);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtCopies);
            this.ultraGroupBox1.Controls.Add(this.txtWeight);
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Controls.Add(this.cbServiceType);
            this.ultraGroupBox1.Controls.Add(this.label16);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.lvCustomers);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Controls.Add(this.Label35);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(482, 575);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // gbShippingOptions
            // 
            this.gbShippingOptions.AllowDrop = true;
            this.gbShippingOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance70.AlphaLevel = ((short)(95));
            appearance70.BackColor = System.Drawing.Color.Transparent;
            this.gbShippingOptions.Appearance = appearance70;
            this.gbShippingOptions.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbShippingOptions.Controls.Add(this.opLabel);
            this.gbShippingOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbShippingOptions.Location = new System.Drawing.Point(23, 224);
            this.gbShippingOptions.Name = "gbShippingOptions";
            this.gbShippingOptions.Size = new System.Drawing.Size(445, 48);
            this.gbShippingOptions.TabIndex = 280;
            this.gbShippingOptions.Text = "Labels";
            this.gbShippingOptions.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // opLabel
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.Color.White;
            this.opLabel.Appearance = appearance4;
            this.opLabel.BackColor = System.Drawing.Color.Transparent;
            this.opLabel.BackColorInternal = System.Drawing.Color.DimGray;
            this.opLabel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.opLabel.CheckedIndex = 0;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BorderColor = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.Black;
            valueListItem8.Appearance = appearance5;
            valueListItem8.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem8.DataValue = "UPS";
            valueListItem8.DisplayText = "UPS";
            appearance6.BackColor = System.Drawing.Color.Transparent;
            valueListItem9.Appearance = appearance6;
            valueListItem9.DataValue = "Fedex";
            valueListItem9.DisplayText = "Fedex";
            this.opLabel.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.opLabel.Location = new System.Drawing.Point(45, 16);
            this.opLabel.Name = "opLabel";
            this.opLabel.Size = new System.Drawing.Size(355, 16);
            this.opLabel.TabIndex = 276;
            this.opLabel.Text = "UPS";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(340, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 279;
            this.label4.Text = "Copies:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(218, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 277;
            this.label3.Text = "Weight:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCopies
            // 
            this.txtCopies.AllowDrop = true;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            this.txtCopies.Appearance = appearance1;
            this.txtCopies.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCopies.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCopies.FormatString = "####";
            this.txtCopies.InputMask = "nnnnn";
            this.txtCopies.Location = new System.Drawing.Point(391, 66);
            this.txtCopies.Name = "txtAmountDue";
            this.txtCopies.PromptChar = ' ';
            this.txtCopies.Size = new System.Drawing.Size(59, 20);
            this.txtCopies.TabIndex = 278;
            this.txtCopies.Text = "1";
            // 
            // txtWeight
            // 
            this.txtWeight.AllowDrop = true;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Right";
            this.txtWeight.Appearance = appearance2;
            this.txtWeight.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtWeight.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtWeight.FormatString = "####.##";
            this.txtWeight.InputMask = "{LOC}nnnnnnn.nn";
            this.txtWeight.Location = new System.Drawing.Point(269, 67);
            this.txtWeight.Name = "txtAmountDue";
            this.txtWeight.PromptChar = ' ';
            this.txtWeight.Size = new System.Drawing.Size(59, 20);
            this.txtWeight.TabIndex = 276;
            this.txtWeight.Text = "1";
            // 
            // ultraGroupBox2
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.Controls.Add(this.txtDateTo);
            this.ultraGroupBox2.Controls.Add(this.txtDateFrom);
            this.ultraGroupBox2.Controls.Add(this.label21);
            this.ultraGroupBox2.Controls.Add(this.label22);
            this.ultraGroupBox2.Controls.Add(this.label1);
            this.ultraGroupBox2.Controls.Add(this.txtType);
            this.ultraGroupBox2.Location = new System.Drawing.Point(23, 101);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(447, 117);
            this.ultraGroupBox2.TabIndex = 275;
            this.ultraGroupBox2.Text = "Date Selection";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(336, 31);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(91, 21);
            this.txtDateTo.TabIndex = 278;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(108, 31);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(91, 21);
            this.txtDateFrom.TabIndex = 277;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(264, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 18);
            this.label21.TabIndex = 280;
            this.label21.Text = "Date To :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 18);
            this.label22.TabIndex = 279;
            this.label22.Text = "Date From :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 276;
            this.label1.Text = "Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtType
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.BorderColor = System.Drawing.Color.White;
            this.txtType.Appearance = appearance10;
            this.txtType.BackColor = System.Drawing.Color.Transparent;
            this.txtType.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtType.CheckedIndex = 0;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.BorderColor = System.Drawing.Color.White;
            appearance11.ForeColor = System.Drawing.Color.Black;
            valueListItem3.Appearance = appearance11;
            valueListItem3.DataValue = "Signed";
            valueListItem3.DisplayText = "Signed";
            appearance12.BackColor = System.Drawing.Color.Transparent;
            valueListItem4.Appearance = appearance12;
            valueListItem4.DataValue = "Start";
            valueListItem4.DisplayText = "Start";
            valueListItem12.DataValue = "End";
            valueListItem12.DisplayText = "End";
            valueListItem13.DataValue = "Pickup";
            valueListItem13.DisplayText = "Pickup";
            valueListItem14.DataValue = "Delivery";
            valueListItem14.DisplayText = "Delivery";
            valueListItem15.DataValue = "Ship";
            valueListItem15.DisplayText = "Ship";
            valueListItem16.DataValue = "All";
            valueListItem16.DisplayText = "All";
            this.txtType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.txtType.Location = new System.Drawing.Point(90, 83);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(355, 16);
            this.txtType.TabIndex = 275;
            this.txtType.Text = "Signed";
            // 
            // cbServiceType
            // 
            this.cbServiceType.AllowDrop = true;
            this.cbServiceType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbServiceType.Items.AddRange(new object[] {
            "GROUND",
            "2ND DAY AIR"});
            this.cbServiceType.Location = new System.Drawing.Point(99, 67);
            this.cbServiceType.Name = "cbSpanish";
            this.cbServiceType.Size = new System.Drawing.Size(114, 21);
            this.cbServiceType.TabIndex = 271;
            this.cbServiceType.Text = "GROUND";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(27, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 19);
            this.label16.TabIndex = 272;
            this.label16.Text = "Service Type:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Appearance = appearance7;
            this.txtName.Location = new System.Drawing.Point(196, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 27);
            this.txtName.TabIndex = 270;
            // 
            // lvCustomers
            // 
            appearance8.Image = global::Signature.Forms.Properties.Resources.office_building;
            this.lvCustomers.Appearance = appearance8;
            this.lvCustomers.Location = new System.Drawing.Point(23, 278);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(435, 250);
            this.lvCustomers.TabIndex = 269;
            this.lvCustomers.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 268;
            this.label2.Text = "Schools:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(61, 535);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "&Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(282, 534);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "&Generate";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(19, 35);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerUPSLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 604);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerUPSLabels";
            this.Text = "UPS/Fedex Labels Generation";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbShippingOptions)).EndInit();
            this.gbShippingOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinListView.UltraListView lvCustomers;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Signature.Windows.Forms.ComboBox cbServiceType;
        private System.Windows.Forms.Label label16;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateFrom;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtType;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEditNumeric txtWeight;
        private System.Windows.Forms.Label label4;
        private Signature.Windows.Forms.MaskedEditNumeric txtCopies;
        private Signature.Windows.Forms.GroupBox gbShippingOptions;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet opLabel;


    }
}