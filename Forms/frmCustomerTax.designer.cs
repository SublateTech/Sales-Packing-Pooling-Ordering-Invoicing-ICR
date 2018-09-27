namespace Signature.Forms
{
    partial class frmCustomerTax
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
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDateFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDateTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.cbFood = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ctrState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 204);
            this.txtStatus.Size = new System.Drawing.Size(482, 29);
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
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 30);
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
            this.label21.Location = new System.Drawing.Point(36, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 18);
            this.label21.TabIndex = 260;
            this.label21.Text = "Date To :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(112, 27);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(91, 21);
            this.txtDateFrom.TabIndex = 0;
            this.txtDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(112, 51);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(91, 21);
            this.txtDateTo.TabIndex = 1;
            this.txtDateTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.cbFood);
            this.ultraGroupBox1.Controls.Add(this.ctrState);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtDateTo);
            this.ultraGroupBox1.Controls.Add(this.txtDateFrom);
            this.ultraGroupBox1.Controls.Add(this.label21);
            this.ultraGroupBox1.Controls.Add(this.label22);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(482, 204);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbFood
            // 
            appearance118.BackColor = System.Drawing.Color.Transparent;
            appearance118.BackColor2 = System.Drawing.Color.Transparent;
            appearance118.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance118.ForeColor = System.Drawing.Color.Black;
            appearance118.ForeColorDisabled = System.Drawing.Color.White;
            this.cbFood.Appearance = appearance118;
            this.cbFood.BackColor = System.Drawing.Color.Transparent;
            this.cbFood.BackColorInternal = System.Drawing.Color.Transparent;
            this.cbFood.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFood.Location = new System.Drawing.Point(354, 115);
            this.cbFood.Name = "cbFood";
            this.cbFood.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbFood.Size = new System.Drawing.Size(84, 19);
            this.cbFood.TabIndex = 269;
            this.cbFood.Text = "By Food";
            // 
            // ctrState
            // 
            this.ctrState.FormattingEnabled = true;
            this.ctrState.Location = new System.Drawing.Point(112, 112);
            this.ctrState.Name = "ctrState";
            this.ctrState.Size = new System.Drawing.Size(153, 21);
            this.ctrState.TabIndex = 268;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(51, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 267;
            this.label1.Text = "State:";
            // 
            // frmCustomerTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 233);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmCustomerTax";
            this.Text = "Customer Tax Report";
            this.Load += new System.EventHandler(this.frmCustomerListing_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.btPrint, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.Button btPrint;
        private Signature.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateFrom;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateTo;
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private System.Windows.Forms.ComboBox ctrState;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbFood;


    }
}