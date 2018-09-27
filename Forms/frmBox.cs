using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmBox : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtHeight;
        private Label label5;
        private Signature.Windows.Forms.MaskedEdit txtWidth;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtLength;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtBoxID;
        private Label label3;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label4;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        
        #endregion


        Box oBox;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtCookieDough;
        Product oProduct;
        
        public frmBox()
		{
			InitializeComponent();
        
		}
     
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBox));
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtCookieDough = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeight = new Signature.Windows.Forms.MaskedEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWidth = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLength = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 211);
            this.txtStatus.Size = new System.Drawing.Size(431, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtCookieDough);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtHeight);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtWidth);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtLength);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtBoxID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(431, 211);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtCookieDough
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.White;
            this.txtCookieDough.Appearance = appearance2;
            this.txtCookieDough.BackColor = System.Drawing.Color.Transparent;
            this.txtCookieDough.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtCookieDough.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCookieDough.Location = new System.Drawing.Point(259, 27);
            this.txtCookieDough.Name = "txtCookieDough";
            this.txtCookieDough.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCookieDough.Size = new System.Drawing.Size(110, 19);
            this.txtCookieDough.TabIndex = 41;
            this.txtCookieDough.Text = "Cookie Dough:";
            this.txtCookieDough.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Appearance = appearance3;
            this.txtDescription.Location = new System.Drawing.Point(104, 93);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(315, 23);
            this.txtDescription.TabIndex = 40;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(104, 68);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 28;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(21, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Product ID:";
            // 
            // txtHeight
            // 
            this.txtHeight.AllowDrop = true;
            this.txtHeight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHeight.Location = new System.Drawing.Point(104, 178);
            this.txtHeight.Name = "txtCustomerID";
            this.txtHeight.Size = new System.Drawing.Size(80, 20);
            this.txtHeight.TabIndex = 23;
            this.txtHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(21, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.AllowDrop = true;
            this.txtWidth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWidth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWidth.Location = new System.Drawing.Point(104, 151);
            this.txtWidth.Name = "txtCustomerID";
            this.txtWidth.Size = new System.Drawing.Size(80, 20);
            this.txtWidth.TabIndex = 22;
            this.txtWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Width:";
            // 
            // txtLength
            // 
            this.txtLength.AllowDrop = true;
            this.txtLength.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLength.Location = new System.Drawing.Point(104, 122);
            this.txtLength.Name = "txtCustomerID";
            this.txtLength.Size = new System.Drawing.Size(80, 20);
            this.txtLength.TabIndex = 21;
            this.txtLength.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Length:";
            // 
            // txtBoxID
            // 
            this.txtBoxID.AllowDrop = true;
            this.txtBoxID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBoxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxID.Location = new System.Drawing.Point(104, 26);
            this.txtBoxID.Name = "txtCustomerID";
            this.txtBoxID.Size = new System.Drawing.Size(80, 20);
            this.txtBoxID.TabIndex = 20;
            this.txtBoxID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Box ID:";
            // 
            // frmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 240);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBox";
            this.ShowInTaskbar = false;
            this.Text = "Box Size Maintenance";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
    	private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oBox = new Box(this.CompanyID);
            oProduct = new Product(CompanyID);
            
            this.txtBoxID.Focus();
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtBoxID
            if (sender==txtBoxID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oBox.View())
                    {
                        ShowBox();
                        txtProductID.Focus();
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBoxID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtBoxID.Focus();
                    }
                    
                    if (oBox.Find(txtBoxID.Text))
                    {
                        ShowBox();
                        txtProductID.Focus();
                        
                    
                    } else
                    {
                        Clear();
                        
                    }


                    
                }					

            }
            #endregion
            #region txtProductID
            if (sender == txtProductID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        txtLength.Focus();
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        txtProductID.Focus();
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        txtLength.Focus();
                    }
                    
                }

            }
           #endregion
            
            
            #region Default Option
            //Default option
			switch (e.KeyCode) 
			{
                case Keys.Tab:
                    if (!e.Shift)
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break; 
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    {
                        if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            MessageBox.Show("Operation Cancelled");
                            return;
                        }
                        else
                        {
                            oBox.Delete();
                            Clear();
                            txtBoxID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    txtBoxID.Focus();
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        #endregion
        
        #region  Methods
        public void Save()
        {
            oBox.ID             = txtBoxID.Text;
            oBox.Length         = Convert.ToDouble(txtLength.Text);
            oBox.Width          = Convert.ToDouble(txtWidth.Text)  ;
            oBox.Height         = Convert.ToDouble(txtHeight.Text);
            oBox.ProductID      = txtProductID.Text;
            oBox.IsCookieDough = txtCookieDough.Checked;
            
            
            oBox.Save();
            Clear();
            txtBoxID.Clear();

        }
        
        public bool ShowBox()
        {
            Clear();
            txtLength.Text = oBox.Length.ToString();
            txtBoxID.Text = oBox.ID;
            txtWidth.Text = oBox.Width.ToString();
            txtHeight.Text    = oBox.Height.ToString();
            txtProductID.Text = oBox.ProductID;
            txtCookieDough.Checked = oBox.IsCookieDough;
            return true;
        }
        public void Clear()
        {
           
            txtWidth.Clear();
            txtHeight.Clear();
            txtLength.Clear();
            txtProductID.Clear();
            txtCookieDough.Checked = false;

        }
      
		#endregion

	}
}
