namespace Signature.Forms
{
    partial class frmCallsManager
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
            this.callList1 = new Signature.Forms.CallList();
            this.SuspendLayout();
            // 
            // callList1
            // 
            this.callList1.BackColor = System.Drawing.Color.Transparent;
            this.callList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callList1.Location = new System.Drawing.Point(0, 0);
            this.callList1.Name = "callList1";
            this.callList1.Size = new System.Drawing.Size(685, 480);
            this.callList1.TabIndex = 0;
            // 
            // frmCallsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Signature.Forms.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(685, 480);
            this.Controls.Add(this.callList1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCallsManager";
            this.ShowIcon = false;
            this.Text = "School Calls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCallsManager_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private CallList callList1;
    }
}