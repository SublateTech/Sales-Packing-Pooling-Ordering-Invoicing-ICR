namespace Signature.Forms
{
    partial class frmCustomerInvoiceConvert
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn1 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("CompanyID");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn2 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("Teacher");
            Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn ultraListViewSubItemColumn3 = new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn("SubItemColumn 2");
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtName_to = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID_to = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.bAdd = new Signature.Windows.Forms.Button();
            this.txtStudent = new Signature.Windows.Forms.RichTextBox();
            this.lStudent = new System.Windows.Forms.Label();
            this.txtCompanyID = new Signature.Windows.Forms.MaskedEdit();
            this.txtPnoneExt = new System.Windows.Forms.Label();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.Label35 = new System.Windows.Forms.Label();
            this.lvCustomers = new Infragistics.Win.UltraWinListView.UltraListView();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.btPrint = new Signature.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 533);
            this.txtStatus.Size = new System.Drawing.Size(889, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(92, 19);
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
            this.ultraGroupBox1.Controls.Add(this.groupBox1);
            this.ultraGroupBox1.Controls.Add(this.lvCustomers);
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(889, 533);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance2.AlphaLevel = ((short)(95));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance2;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtName_to);
            this.groupBox1.Controls.Add(this.txtCustomerID_to);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bAdd);
            this.groupBox1.Controls.Add(this.txtStudent);
            this.groupBox1.Controls.Add(this.lStudent);
            this.groupBox1.Controls.Add(this.txtCompanyID);
            this.groupBox1.Controls.Add(this.txtPnoneExt);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCustomerID);
            this.groupBox1.Controls.Add(this.Label35);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Criteria";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName_to
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.txtName_to.Appearance = appearance6;
            this.txtName_to.Location = new System.Drawing.Point(434, 56);
            this.txtName_to.Name = "txtName_to";
            this.txtName_to.Size = new System.Drawing.Size(375, 18);
            this.txtName_to.TabIndex = 283;
            // 
            // txtCustomerID_to
            // 
            this.txtCustomerID_to.AllowDrop = true;
            this.txtCustomerID_to.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID_to.Location = new System.Drawing.Point(359, 55);
            this.txtCustomerID_to.Name = "txtCustomerID";
            this.txtCustomerID_to.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID_to.TabIndex = 2;
            this.txtCustomerID_to.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 282;
            this.label1.Text = "To School:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bAdd
            // 
            this.bAdd.AllowDrop = true;
            this.bAdd.BackColor = System.Drawing.SystemColors.Control;
            this.bAdd.ForeColor = System.Drawing.Color.Black;
            this.bAdd.Location = new System.Drawing.Point(350, 135);
            this.bAdd.Name = "btPrint";
            this.bAdd.Size = new System.Drawing.Size(115, 26);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "&Add";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // txtStudent
            // 
            this.txtStudent.AcceptsTab = true;
            this.txtStudent.AllowDrop = true;
            this.txtStudent.AutoWordSelection = true;
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(92, 91);
            this.txtStudent.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.txtStudent.MaxLength = 40;
            this.txtStudent.Multiline = false;
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(373, 23);
            this.txtStudent.TabIndex = 3;
            this.txtStudent.WordWrap = false;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // lStudent
            // 
            this.lStudent.BackColor = System.Drawing.Color.Transparent;
            this.lStudent.Location = new System.Drawing.Point(2, 96);
            this.lStudent.Name = "lStudent";
            this.lStudent.Size = new System.Drawing.Size(80, 17);
            this.lStudent.TabIndex = 279;
            this.lStudent.Text = "To Teacher:";
            this.lStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.AllowDrop = true;
            this.txtCompanyID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCompanyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyID.Location = new System.Drawing.Point(92, 55);
            this.txtCompanyID.Name = "txtCustomerID";
            this.txtCompanyID.Size = new System.Drawing.Size(80, 20);
            this.txtCompanyID.TabIndex = 1;
            this.txtCompanyID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPnoneExt
            // 
            this.txtPnoneExt.BackColor = System.Drawing.Color.Transparent;
            this.txtPnoneExt.Location = new System.Drawing.Point(6, 55);
            this.txtPnoneExt.Name = "txtPnoneExt";
            this.txtPnoneExt.Size = new System.Drawing.Size(81, 20);
            this.txtPnoneExt.TabIndex = 278;
            this.txtPnoneExt.Text = "To Company:";
            // 
            // txtName
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Appearance = appearance3;
            this.txtName.Location = new System.Drawing.Point(165, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(467, 18);
            this.txtName.TabIndex = 270;
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(9, 20);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(78, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "From School:";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvCustomers
            // 
            appearance7.Image = global::Signature.Forms.Properties.Resources.office_building;
            this.lvCustomers.Appearance = appearance7;
            this.lvCustomers.Location = new System.Drawing.Point(12, 205);
            this.lvCustomers.MainColumn.Text = "From Invoice";
            this.lvCustomers.MainColumn.Width = 270;
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(840, 262);
            ultraListViewSubItemColumn1.Key = "CompanyID";
            ultraListViewSubItemColumn1.Width = 60;
            ultraListViewSubItemColumn2.Key = "Teacher";
            ultraListViewSubItemColumn2.Width = 160;
            ultraListViewSubItemColumn3.Key = "SubItemColumn 2";
            ultraListViewSubItemColumn3.Text = "To School";
            ultraListViewSubItemColumn3.Width = 300;
            this.lvCustomers.SubItemColumns.AddRange(new Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn[] {
            ultraListViewSubItemColumn1,
            ultraListViewSubItemColumn2,
            ultraListViewSubItemColumn3});
            this.lvCustomers.TabIndex = 269;
            this.lvCustomers.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(267, 490);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 300;
            this.btCancel.Text = "&Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(544, 491);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 301;
            this.btPrint.Text = "&Convert";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // frmCustomerInvoiceConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 562);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerInvoiceConvert";
            this.Text = "Invoice Report Conversion";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private Infragistics.Win.UltraWinListView.UltraListView lvCustomers;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Signature.Windows.Forms.MaskedEdit txtCompanyID;
        private System.Windows.Forms.Label txtPnoneExt;
        internal Signature.Windows.Forms.RichTextBox txtStudent;
        private System.Windows.Forms.Label lStudent;
        private Signature.Windows.Forms.Button bAdd;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID_to;
        internal System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraLabel txtName_to;


    }
}