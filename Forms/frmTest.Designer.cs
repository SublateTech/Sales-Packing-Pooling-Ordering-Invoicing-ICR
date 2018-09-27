namespace Signature.Forms
{
    partial class frmTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.vistaComboBox1 = new Signature.Windows.Forms.VistaComboBox();
            this.button1 = new Signature.Windows.Forms.Button();
            this.calls2 = new Signature.Forms.Calls();
            this.calls1 = new Signature.Forms.Calls();
            this.glassButton1 = new Signature.Windows.Forms.GlassButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(25, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 61);
            this.panel1.TabIndex = 0;
            // 
            // vistaComboBox1
            // 
            this.vistaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vistaComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vistaComboBox1.FormattingEnabled = true;
            this.vistaComboBox1.Location = new System.Drawing.Point(115, 239);
            this.vistaComboBox1.Name = "vistaComboBox1";
            this.vistaComboBox1.Size = new System.Drawing.Size(178, 21);
            this.vistaComboBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(60, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // calls2
            // 
            this.calls2.BackColor = System.Drawing.Color.Transparent;
            this.calls2.Location = new System.Drawing.Point(25, 167);
            this.calls2.Name = "calls2";
            this.calls2.Size = new System.Drawing.Size(48, 48);
            this.calls2.TabIndex = 3;
            this.calls2.Text = "calls2";
            // 
            // calls1
            // 
            this.calls1.BackColor = System.Drawing.Color.Transparent;
            this.calls1.Location = new System.Drawing.Point(25, 100);
            this.calls1.Name = "calls1";
            this.calls1.Size = new System.Drawing.Size(48, 48);
            this.calls1.TabIndex = 2;
            this.calls1.Text = "calls1";
            // 
            // glassButton1
            // 
            this.glassButton1.Location = new System.Drawing.Point(63, 339);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(158, 34);
            this.glassButton1.TabIndex = 7;
            this.glassButton1.Text = "glassButton1";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 404);
            this.Controls.Add(this.glassButton1);
            this.Controls.Add(this.vistaComboBox1);
            this.Controls.Add(this.calls2);
            this.Controls.Add(this.calls1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Signature.Windows.Forms.Button button1;
        private Calls calls1;
        private Calls calls2;
        private Signature.Windows.Forms.VistaComboBox vistaComboBox1;
        private Signature.Windows.Forms.GlassButton glassButton1;
        
        
    }
}