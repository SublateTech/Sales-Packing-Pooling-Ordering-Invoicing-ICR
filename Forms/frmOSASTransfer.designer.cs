namespace Signature
{
    partial class frmOSASTransfer
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtBatchID = new Signature.Windows.Forms.MaskedEdit();
            this.txtSchoolName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.txtCompanyID = new Signature.Windows.Forms.MaskedEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.btCancel = new Infragistics.Win.Misc.UltraButton();
            this.btApply = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtTeacher);
            this.ultraGroupBox1.Controls.Add(this.txtBatchID);
            this.ultraGroupBox1.Controls.Add(this.txtSchoolName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel5);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.txtCompanyID);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Location = new System.Drawing.Point(13, 12);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(578, 177);
            this.ultraGroupBox1.TabIndex = 0;
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.Location = new System.Drawing.Point(143, 92);
            this.txtTeacher.Name = "maskedEdit2";
            this.txtTeacher.Size = new System.Drawing.Size(408, 20);
            this.txtTeacher.TabIndex = 6;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtBatchID
            // 
            this.txtBatchID.AllowDrop = true;
            this.txtBatchID.Location = new System.Drawing.Point(143, 118);
            this.txtBatchID.Name = "maskedEdit2";
            this.txtBatchID.Size = new System.Drawing.Size(78, 20);
            this.txtBatchID.TabIndex = 5;
            this.txtBatchID.Visible = false;
            this.txtBatchID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.txtSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolName.Location = new System.Drawing.Point(143, 67);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(408, 19);
            this.txtSchoolName.TabIndex = 8;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(60, 67);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(77, 19);
            this.ultraLabel5.TabIndex = 7;
            this.ultraLabel5.Text = "School Name:";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(83, 93);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(63, 19);
            this.ultraLabel4.TabIndex = 6;
            this.ultraLabel4.Text = "Teacher :";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(143, 41);
            this.txtCustomerID.Name = "maskedEdit2";
            this.txtCustomerID.Size = new System.Drawing.Size(78, 20);
            this.txtCustomerID.TabIndex = 4;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.AllowDrop = true;
            this.txtCompanyID.Location = new System.Drawing.Point(143, 16);
            this.txtCompanyID.Name = "maskedEdit1";
            this.txtCompanyID.Size = new System.Drawing.Size(78, 20);
            this.txtCompanyID.TabIndex = 3;
            this.txtCompanyID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(76, 42);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(61, 19);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "School ID:";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(66, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(71, 19);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "Company ID:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(21, 118);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(125, 19);
            this.ultraLabel3.TabIndex = 5;
            this.ultraLabel3.Text = "Current Batch Number:";
            this.ultraLabel3.Visible = false;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(77, 207);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(168, 27);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(371, 207);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(165, 27);
            this.btApply.TabIndex = 2;
            this.btApply.Text = "Transfer";
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // frmOSASTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(603, 259);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmOSASTransfer";
            this.Text = "OSAS Tranfering";
            this.Load += new System.EventHandler(this.frmSetupCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.MaskedEdit txtCompanyID;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel txtSchoolName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Signature.Windows.Forms.MaskedEdit txtBatchID;
        private Infragistics.Win.Misc.UltraButton btCancel;
        private Infragistics.Win.Misc.UltraButton btApply;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;

    }
}