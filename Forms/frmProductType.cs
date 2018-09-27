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
	public sealed class frmProductType : frmBase
	{
		#region declarations		
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtBrochureTypeID;
        private Label label3;
        
        #endregion


        Pack oPack;
        private Signature.Windows.Forms.MaskedEditNumeric txtNumberOfPrints;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtDescription;
        private Label label1;
        Product oProduct;
        
        public frmProductType()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductType));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtDescription = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberOfPrints = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrochureTypeID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 111);
            this.txtStatus.Size = new System.Drawing.Size(488, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtNumberOfPrints);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtBrochureTypeID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(488, 111);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(130, 52);
            this.txtDescription.Name = "txtCustomerID";
            this.txtDescription.Size = new System.Drawing.Size(304, 20);
            this.txtDescription.TabIndex = 293;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 294;
            this.label1.Text = "Description:";
            // 
            // txtNumberOfPrints
            // 
            this.txtNumberOfPrints.AllowDrop = true;
            appearance1.TextHAlignAsString = "Right";
            this.txtNumberOfPrints.Appearance = appearance1;
            this.txtNumberOfPrints.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNumberOfPrints.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNumberOfPrints.FormatString = "###,###.##";
            this.txtNumberOfPrints.InputMask = "nnnnnnnnn";
            this.txtNumberOfPrints.Location = new System.Drawing.Point(130, 78);
            this.txtNumberOfPrints.Name = "txtAmountDue";
            this.txtNumberOfPrints.Size = new System.Drawing.Size(64, 20);
            this.txtNumberOfPrints.TabIndex = 43;
            this.txtNumberOfPrints.Text = "0";
            this.txtNumberOfPrints.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(21, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 30);
            this.label4.TabIndex = 29;
            this.label4.Text = "Number Of Prints:";
            // 
            // txtBrochureTypeID
            // 
            this.txtBrochureTypeID.AllowDrop = true;
            this.txtBrochureTypeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBrochureTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrochureTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrochureTypeID.Location = new System.Drawing.Point(130, 26);
            this.txtBrochureTypeID.Name = "txtCustomerID";
            this.txtBrochureTypeID.Size = new System.Drawing.Size(80, 20);
            this.txtBrochureTypeID.TabIndex = 20;
            this.txtBrochureTypeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Type ID:";
            // 
            // frmProductType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 140);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductType";
            this.ShowInTaskbar = false;
            this.Text = "Product Type Maintenance";
            this.TransparencyKey = System.Drawing.Color.Empty;
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
            oPack = new Pack(this.CompanyID);
            oProduct = new Product(CompanyID);
            
            this.txtBrochureTypeID.Focus();
		}

       
        
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtBoxID
            if (sender==txtBrochureTypeID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oPack.View())
                    {
                        ShowBox();
                        txtNumberOfPrints.Focus();
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBrochureTypeID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtBrochureTypeID.Focus();
                    }
                    
                    if (oPack.Find(txtBrochureTypeID.Text))
                    {
                        ShowBox();
                        txtDescription.Focus();
                        return;
                    
                    } else
                    {
                        Clear();
                        txtDescription.Focus();
                        return;
                    }


                    
                }					

            }
            #endregion
            #region txtProductID
            if (sender == txtNumberOfPrints)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {
                        txtNumberOfPrints.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        //txtLength.Focus();
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtNumberOfPrints.Text.Trim().Length == 0)
                    {
                        txtNumberOfPrints.Focus();
                    }

                    if (oProduct.Find(txtNumberOfPrints.Text))
                    {
                        txtNumberOfPrints.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        //txtLength.Focus();
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
                            oPack.Delete();
                            Clear();
                            txtBrochureTypeID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    Clear();
                    txtBrochureTypeID.Focus();
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
            oPack.NoCopies = (Int32) txtNumberOfPrints.Number;
            oPack.Description = txtDescription.Text;
            oPack.ID = txtBrochureTypeID.Text;
            
            oPack.Save();
            Clear();
            txtBrochureTypeID.Clear();
        }
        
        public bool ShowBox()
        {
            Clear();
            txtBrochureTypeID.DataBindings.Add("Text", oPack, "ID");
            txtNumberOfPrints.DataBindings.Add("Text", oPack, "NoCopies");
            txtDescription.DataBindings.Add("Text", oPack, "Description");
             
            return true;
        }
        public void Clear()
        {
            //txtAskForPhone.Checked = false;
            
            txtBrochureTypeID.DataBindings.Clear();
            txtNumberOfPrints.DataBindings.Clear();
            
            txtDescription.DataBindings.Clear();

            txtNumberOfPrints.Text = "0";
            txtDescription.Clear();
            

            
        }
      
		#endregion

        

	}
}
