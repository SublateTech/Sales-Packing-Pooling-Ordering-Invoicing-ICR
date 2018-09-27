namespace Signature.Forms
{
    partial class frmCallsAssignUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCallsAssignUser));
            this.panel1 = new Signature.Windows.Forms.VistaPanel();
            this.vistaLabel1 = new Signature.Windows.Forms.VistaLabel();
            this.button2 = new Signature.Windows.Forms.Button();
            this.button1 = new Signature.Windows.Forms.Button();
            this.cbUsers = new Signature.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.vistaLabel1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbUsers);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 122);
            this.panel1.TabIndex = 5;
            this.panel1.TransparencyLevel = ((byte)(240));
            // 
            // vistaLabel1
            // 
            this.vistaLabel1.AutoSize = true;
            this.vistaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.vistaLabel1.Blur = new System.Drawing.Size(1, 4);
            this.vistaLabel1.BlurColor = System.Drawing.Color.Black;
            this.vistaLabel1.ForeColor = System.Drawing.Color.Black;
            this.vistaLabel1.Location = new System.Drawing.Point(55, 37);
            this.vistaLabel1.Name = "vistaLabel1";
            this.vistaLabel1.Size = new System.Drawing.Size(49, 13);
            this.vistaLabel1.TabIndex = 9;
            this.vistaLabel1.Text = "User ID :";
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(184, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "Apply";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(39, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbUsers
            // 
            this.cbUsers.AllowDrop = true;
            this.cbUsers.BackColor = System.Drawing.Color.White;
            this.cbUsers.CueBannerText = "Select User";
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUsers.ForeColor = System.Drawing.Color.Black;
            this.cbUsers.Location = new System.Drawing.Point(141, 32);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(135, 21);
            this.cbUsers.TabIndex = 5;
            // 
            // frmCallsAssignUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(324, 164);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCallsAssignUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Signature.Windows.Forms.VistaPanel panel1;
        private Signature.Windows.Forms.Button button2;
        private Signature.Windows.Forms.Button button1;
        public Signature.Windows.Forms.ComboBox cbUsers;
        private Signature.Windows.Forms.VistaLabel vistaLabel1;
    }
}