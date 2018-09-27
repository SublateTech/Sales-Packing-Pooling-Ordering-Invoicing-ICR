namespace Signature.Forms
{
    partial class frmInventoryRealTime

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
            this.table = new XPTable.Models.Table();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 278);
            this.txtStatus.Size = new System.Drawing.Size(595, 29);
            // 
            // table
            // 
            this.table.AlternatingRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.table.EnableToolTips = true;
            this.table.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.GridColor = System.Drawing.SystemColors.ControlDark;
            this.table.GridLines = XPTable.Models.GridLines.Both;
            this.table.GridLineStyle = XPTable.Models.GridLineStyle.Dot;
            this.table.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.table.Location = new System.Drawing.Point(11, 10);
            this.table.MultiSelect = true;
            this.table.Name = "table";
            this.table.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.table.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.table.Size = new System.Drawing.Size(572, 262);
            this.table.SortedColumnBackColor = System.Drawing.Color.Transparent;
            this.table.TabIndex = 9;
            this.table.UnfocusedSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.table.UnfocusedSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.KeyUp += new System.Windows.Forms.KeyEventHandler(this.table_KeyUp);
            // 
            // frmInventoryRealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Signature.Forms.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(595, 307);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmInventoryRealTime";
            this.Text = "Inventory Real Time";
            this.Load += new System.EventHandler(this.frmCallsAssignment_Load);
            this.Shown += new System.EventHandler(this.frmInventoryRealTime_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryRealTime_FormClosed);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.table, 0);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XPTable.Models.Table table;

    }
}