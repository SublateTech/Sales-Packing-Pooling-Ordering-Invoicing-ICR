namespace Signature.Forms
{
    partial class frmShortage_
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.tvShortages = new System.Windows.Forms.TreeView();
            this.pShortage = new System.Windows.Forms.Panel();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer.Panel1.Controls.Add(this.tvShortages);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer.Panel2.Controls.Add(this.pShortage);
            this.SplitContainer.Size = new System.Drawing.Size(1093, 242);
            this.SplitContainer.SplitterDistance = 271;
            this.SplitContainer.TabIndex = 0;
            // 
            // tvShortages
            // 
            this.tvShortages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvShortages.Location = new System.Drawing.Point(0, 0);
            this.tvShortages.Name = "tvShortages";
            this.tvShortages.Size = new System.Drawing.Size(271, 242);
            this.tvShortages.TabIndex = 0;
            // 
            // pShortage
            // 
            this.pShortage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pShortage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pShortage.Location = new System.Drawing.Point(0, 0);
            this.pShortage.Name = "pShortage";
            this.pShortage.Size = new System.Drawing.Size(818, 242);
            this.pShortage.TabIndex = 0;
            // 
            // frmShortage_
            // 
            this.ClientSize = new System.Drawing.Size(1093, 242);
            this.Controls.Add(this.SplitContainer);
            this.Name = "frmShortage_";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.TreeView tvShortages;
        private System.Windows.Forms.Panel pShortage;

    }
}
