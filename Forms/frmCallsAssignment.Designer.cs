namespace Signature.Forms
{
    partial class frmCallsAssignment

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
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtDateTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDateFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPickUpCalls = new System.Windows.Forms.RadioButton();
            this.rbEndCalls = new System.Windows.Forms.RadioButton();
            this.btSave = new Signature.Windows.Forms.Button();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.table = new XPTable.Models.Table();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 440);
            this.txtStatus.Size = new System.Drawing.Size(766, 29);
            // 
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance1;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtDateTo);
            this.groupBox1.Controls.Add(this.txtDateFrom);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbPickUpCalls);
            this.groupBox1.Controls.Add(this.rbEndCalls);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.Text = "Calls";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtDateTo
            // 
            this.txtDateTo.Location = new System.Drawing.Point(247, 31);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(91, 21);
            this.txtDateTo.TabIndex = 262;
            this.txtDateTo.ValueChanged += new System.EventHandler(this.txtDateTo_ValueChanged);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Location = new System.Drawing.Point(78, 31);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(91, 21);
            this.txtDateFrom.TabIndex = 261;
            this.txtDateFrom.ValueChanged += new System.EventHandler(this.txtDateTo_ValueChanged);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(244, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 18);
            this.label21.TabIndex = 266;
            this.label21.Text = "Date To :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(75, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 18);
            this.label22.TabIndex = 265;
            this.label22.Text = "Date From :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(475, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 264;
            this.label1.Text = "Selection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPickUpCalls
            // 
            this.rbPickUpCalls.AutoSize = true;
            this.rbPickUpCalls.BackColor = System.Drawing.Color.Transparent;
            this.rbPickUpCalls.Location = new System.Drawing.Point(564, 33);
            this.rbPickUpCalls.Name = "rbPickUpCalls";
            this.rbPickUpCalls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbPickUpCalls.Size = new System.Drawing.Size(85, 17);
            this.rbPickUpCalls.TabIndex = 1;
            this.rbPickUpCalls.Text = "PickUp Calls";
            this.rbPickUpCalls.UseVisualStyleBackColor = false;
            this.rbPickUpCalls.CheckedChanged += new System.EventHandler(this.txtDateTo_ValueChanged);
            // 
            // rbEndCalls
            // 
            this.rbEndCalls.AutoSize = true;
            this.rbEndCalls.BackColor = System.Drawing.Color.Transparent;
            this.rbEndCalls.Checked = true;
            this.rbEndCalls.Location = new System.Drawing.Point(478, 33);
            this.rbEndCalls.Name = "rbEndCalls";
            this.rbEndCalls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbEndCalls.Size = new System.Drawing.Size(69, 17);
            this.rbEndCalls.TabIndex = 0;
            this.rbEndCalls.TabStop = true;
            this.rbEndCalls.Text = "End Calls";
            this.rbEndCalls.UseVisualStyleBackColor = false;
            this.rbEndCalls.CheckedChanged += new System.EventHandler(this.txtDateTo_ValueChanged);
            // 
            // btSave
            // 
            this.btSave.AllowDrop = true;
            this.btSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btSave.ForeColor = System.Drawing.Color.Black;
            this.btSave.Location = new System.Drawing.Point(474, 406);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(137, 27);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(149, 406);
            this.btCancel.Name = "button1";
            this.btCancel.Size = new System.Drawing.Size(137, 27);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.table.Location = new System.Drawing.Point(12, 77);
            this.table.MultiSelect = true;
            this.table.Name = "table";
            this.table.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.table.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.table.Size = new System.Drawing.Size(742, 323);
            this.table.SortedColumnBackColor = System.Drawing.Color.Transparent;
            this.table.TabIndex = 9;
            this.table.UnfocusedSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.table.UnfocusedSelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(66)))), ((int)(((byte)(121)))));
            this.table.KeyUp += new System.Windows.Forms.KeyEventHandler(this.table_KeyUp);
            // 
            // frmCallsAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Signature.Forms.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(766, 469);
            this.Controls.Add(this.table);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCallsAssignment";
            this.Text = "School Calls Assignment";
            this.Load += new System.EventHandler(this.frmCallsAssignment_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btSave, 0);
            this.Controls.SetChildIndex(this.btCancel, 0);
            this.Controls.SetChildIndex(this.table, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPickUpCalls;
        private System.Windows.Forms.RadioButton rbEndCalls;
        private Signature.Windows.Forms.Button btSave;
        private Signature.Windows.Forms.Button btCancel;
        private XPTable.Models.Table table;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDateFrom;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;

    }
}