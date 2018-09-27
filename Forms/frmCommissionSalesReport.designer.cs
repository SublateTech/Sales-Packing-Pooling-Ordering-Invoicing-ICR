namespace Signature.Forms
{
    partial class frmCommissionSalesReport
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
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSummary = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lbRepName_2 = new System.Windows.Forms.Label();
            this.lbRepName = new System.Windows.Forms.Label();
            this.txtRepID_2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 122);
            this.txtStatus.Size = new System.Drawing.Size(562, 29);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbSummary);
            this.panel1.Controls.Add(this.lbRepName_2);
            this.panel1.Controls.Add(this.lbRepName);
            this.panel1.Controls.Add(this.txtRepID_2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRepID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 122);
            this.panel1.TabIndex = 0;
            // 
            // cbSummary
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            appearance27.BackColor2 = System.Drawing.Color.Transparent;
            appearance27.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.White;
            this.cbSummary.Appearance = appearance27;
            this.cbSummary.BackColor = System.Drawing.Color.Transparent;
            this.cbSummary.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbSummary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSummary.Location = new System.Drawing.Point(31, 83);
            this.cbSummary.Name = "cbSummary";
            this.cbSummary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSummary.Size = new System.Drawing.Size(159, 19);
            this.cbSummary.TabIndex = 245;
            this.cbSummary.Text = "Summary :";
            this.cbSummary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRepID_KeyUp);
            // 
            // lbRepName_2
            // 
            this.lbRepName_2.AutoSize = true;
            this.lbRepName_2.Location = new System.Drawing.Point(210, 56);
            this.lbRepName_2.Name = "lbRepName_2";
            this.lbRepName_2.Size = new System.Drawing.Size(0, 13);
            this.lbRepName_2.TabIndex = 5;
            // 
            // lbRepName
            // 
            this.lbRepName.AutoSize = true;
            this.lbRepName.Location = new System.Drawing.Point(210, 27);
            this.lbRepName.Name = "lbRepName";
            this.lbRepName.Size = new System.Drawing.Size(0, 13);
            this.lbRepName.TabIndex = 4;
            // 
            // txtRepID_2
            // 
            this.txtRepID_2.Location = new System.Drawing.Point(110, 53);
            this.txtRepID_2.Name = "txtRepID_2";
            this.txtRepID_2.Size = new System.Drawing.Size(80, 20);
            this.txtRepID_2.TabIndex = 3;
            this.txtRepID_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRepID_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rep ID:";
            // 
            // txtRepID
            // 
            this.txtRepID.Location = new System.Drawing.Point(110, 25);
            this.txtRepID.Name = "txtRepID";
            this.txtRepID.Size = new System.Drawing.Size(80, 20);
            this.txtRepID.TabIndex = 1;
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRepID_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rep ID:";
            // 
            // frmCommissionSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 151);
            this.Controls.Add(this.panel1);
            this.Name = "frmCommissionSalesReport";
            this.Text = "Commission Sales Report";
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRepID_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRepID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRepName_2;
        private System.Windows.Forms.Label lbRepName;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbSummary;
    }
}