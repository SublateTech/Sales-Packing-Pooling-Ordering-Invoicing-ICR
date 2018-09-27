namespace Signature.Forms
{
    partial class frmBase
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.txtStatus = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            appearance1.AlphaLevel = ((short)(250));
            this.txtStatus.Appearance = appearance1;
            this.txtStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtStatus.BorderStylePanel = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtStatus.Location = new System.Drawing.Point(0, 396);
            this.txtStatus.Name = "txtStatus";
            appearance2.TextHAlignAsString = "Right";
            ultraStatusPanel2.Appearance = appearance2;
            ultraStatusPanel2.KeyStateInfo.Key = Infragistics.Win.UltraWinStatusBar.KeyState.CapsLock;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState;
            ultraStatusPanel2.Width = 40;
            appearance3.TextHAlignAsString = "Right";
            ultraStatusPanel3.Appearance = appearance3;
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState;
            ultraStatusPanel3.Width = 40;
            ultraStatusPanel5.Width = 150;
            this.txtStatus.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStatus.Size = new System.Drawing.Size(528, 29);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(528, 425);
            this.Controls.Add(this.txtStatus);
            this.FadeOnClose = false;
            this.FadeOnShow = false;
            this.FadeRate = 10;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signature Base Form";
            this.Shown += new System.EventHandler(this.frmBase_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinStatusBar.UltraStatusBar txtStatus;
     

    }
}