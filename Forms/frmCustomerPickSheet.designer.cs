namespace Signature.Forms
{
    partial class frmCustomerPickSheet

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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtReAssign = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lvCustomers = new Infragistics.Win.UltraWinListView.UltraListView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrinter = new System.Windows.Forms.ComboBox();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.Label35 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 448);
            this.txtStatus.Size = new System.Drawing.Size(482, 29);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(130, 20);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(67, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtType
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BorderColor = System.Drawing.Color.White;
            this.txtType.Appearance = appearance5;
            this.txtType.BackColor = System.Drawing.Color.Transparent;
            this.txtType.BackColorInternal = System.Drawing.Color.DimGray;
            this.txtType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtType.CheckedIndex = 0;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.BorderColor = System.Drawing.Color.White;
            appearance6.ForeColor = System.Drawing.Color.Black;
            valueListItem3.Appearance = appearance6;
            valueListItem3.DataValue = "Unprinted";
            valueListItem3.DisplayText = "Unprinted or Changed";
            valueListItem4.DataValue = "All";
            valueListItem4.DisplayText = "All";
            this.txtType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.txtType.Location = new System.Drawing.Point(130, 69);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(179, 16);
            this.txtType.TabIndex = 2;
            this.txtType.Text = "Unprinted or Changed";
            this.txtType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(44, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 252;
            this.label1.Text = "Selection :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtReAssign);
            this.ultraGroupBox1.Controls.Add(this.lvCustomers);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtPrinter);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Controls.Add(this.Label35);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtType);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(482, 448);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtReAssign
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.BackColor2 = System.Drawing.Color.Transparent;
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.White;
            this.txtReAssign.Appearance = appearance7;
            this.txtReAssign.BackColor = System.Drawing.Color.Transparent;
            this.txtReAssign.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtReAssign.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtReAssign.Location = new System.Drawing.Point(66, 148);
            this.txtReAssign.Name = "txtReAssign";
            this.txtReAssign.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReAssign.Size = new System.Drawing.Size(139, 19);
            this.txtReAssign.TabIndex = 271;
            this.txtReAssign.Text = "Re-Assign Numbers";
            // 
            // lvCustomers
            // 
            appearance8.Image = global::Signature.Forms.Properties.Resources.office_building;
            this.lvCustomers.Appearance = appearance8;
            this.lvCustomers.Location = new System.Drawing.Point(4, 189);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(471, 187);
            this.lvCustomers.TabIndex = 270;
            this.lvCustomers.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(44, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 269;
            this.label2.Text = "Printer :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrinter
            // 
            this.txtPrinter.FormattingEnabled = true;
            this.txtPrinter.Items.AddRange(new object[] {
            "Packing Slips Printer 1",
            "Packing Slips Printer 2",
            "Packing Slips Printer 3",
            "Packing Slips Printer 4 ",
            "Packing Slips Printer 5",
            "Warehouse Printer",
            "Plain Paper Printer",
            ""});
            this.txtPrinter.Location = new System.Drawing.Point(130, 103);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(247, 21);
            this.txtPrinter.TabIndex = 268;
            this.txtPrinter.Text = "Packing Slips Printer";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(203, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 19);
            this.txtName.TabIndex = 267;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(66, 398);
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
            this.btPrint.Location = new System.Drawing.Point(287, 397);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "&Print";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(41, 21);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(72, 19);
            this.Label35.TabIndex = 266;
            this.Label35.Text = "School ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCustomerPickSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 477);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerPickSheet";
            this.Text = "Print Packing Slips";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet txtType;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label Label35;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtPrinter;
        private Infragistics.Win.UltraWinListView.UltraListView lvCustomers;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtReAssign;


    }
}