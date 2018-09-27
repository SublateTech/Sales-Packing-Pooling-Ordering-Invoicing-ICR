namespace Starter
{
    partial class frmPresentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresentation));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.Picture = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.txtMessage = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.BorderShadowColor = System.Drawing.Color.Empty;
            this.Picture.Image = ((object)(resources.GetObject("Picture.Image")));
            this.Picture.ImageTransparentColor = System.Drawing.Color.White;
            this.Picture.Location = new System.Drawing.Point(36, 2);
            this.Picture.Name = "Picture";
            this.Picture.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.Picture.Size = new System.Drawing.Size(251, 315);
            this.Picture.TabIndex = 0;
            // 
            // txtMessage
            // 
            appearance1.FontData.ItalicAsString = "True";
            appearance1.TextHAlignAsString = "Center";
            this.txtMessage.Appearance = appearance1;
            this.txtMessage.Location = new System.Drawing.Point(12, 332);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(302, 26);
            this.txtMessage.TabIndex = 1;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(91, 369);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(148, 25);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "Signature Fundraising, Inc.  All Rights Reserved.";
            // 
            // frmPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(326, 406);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPresentation";
            this.Opacity = 0.5;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPresentation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraPictureBox Picture;
        public Infragistics.Win.Misc.UltraLabel txtMessage;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;

    }
}