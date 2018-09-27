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
	public sealed class frmItemAdjustment : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label3;
        private Label label1;
        private ComboBox ctrType;
        #endregion

        Product oProduct;
        private Signature.Windows.Forms.MaskedEditNumeric txtQuantity;
        private Label label9;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtAdjDescription;
        private Signature.Windows.Forms.Button btCancel;
        private Signature.Windows.Forms.Button btPrint;
        private Label txtDescription;


        public frmItemAdjustment(String CompanyID, Product oProduct):base(CompanyID)
		{
			InitializeComponent();
            this.oProduct = oProduct;
            txtProductID.Text = oProduct.ID;
            txtDescription.Text = oProduct.Description;
		}
        
        
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.btCancel = new Signature.Windows.Forms.Button();
            this.btPrint = new Signature.Windows.Forms.Button();
            this.txtAdjDescription = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.ctrType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btCancel);
            this.ultraGroupBox1.Controls.Add(this.btPrint);
            this.ultraGroupBox1.Controls.Add(this.txtAdjDescription);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtQuantity);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.ctrType);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(354, 232);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btCancel
            // 
            this.btCancel.AllowDrop = true;
            this.btCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCancel.ForeColor = System.Drawing.Color.Black;
            this.btCancel.Location = new System.Drawing.Point(36, 191);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 26);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "&Cancel";
            // 
            // btPrint
            // 
            this.btPrint.AllowDrop = true;
            this.btPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.Location = new System.Drawing.Point(208, 191);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(115, 26);
            this.btPrint.TabIndex = 5;
            this.btPrint.Text = "&Apply";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // txtAdjDescription
            // 
            this.txtAdjDescription.AllowDrop = true;
            this.txtAdjDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAdjDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjDescription.Location = new System.Drawing.Point(104, 156);
            this.txtAdjDescription.Name = "txtCustomerID";
            this.txtAdjDescription.Size = new System.Drawing.Size(239, 20);
            this.txtAdjDescription.TabIndex = 3;
            this.txtAdjDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(22, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Description :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            appearance1.TextHAlignAsString = "Right";
            this.txtQuantity.Appearance = appearance1;
            this.txtQuantity.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtQuantity.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtQuantity.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtQuantity.InputMask = "-nnnnnnnnn";
            this.txtQuantity.Location = new System.Drawing.Point(104, 120);
            this.txtQuantity.Name = "txtAmountDue";
            this.txtQuantity.PromptChar = ' ';
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(21, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Quantity :";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Location = new System.Drawing.Point(101, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(241, 20);
            this.txtDescription.TabIndex = 31;
            // 
            // ctrType
            // 
            this.ctrType.FormattingEnabled = true;
            this.ctrType.Items.AddRange(new object[] {
            "ONPO",
            "Received",
            "Committed",
            "Sold"});
            this.ctrType.Location = new System.Drawing.Point(104, 84);
            this.ctrType.Name = "ctrType";
            this.ctrType.Size = new System.Drawing.Size(127, 21);
            this.ctrType.TabIndex = 1;
            this.ctrType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.ctrType.SelectedValueChanged += new System.EventHandler(this.ctrState_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Type:";
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(104, 26);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product ID:";
            // 
            // frmItemAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(354, 261);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmItemAdjustment";
            this.ShowInTaskbar = false;
            this.Text = "Product Inventory Adjustment";
            this.Load += new System.EventHandler(this.frmOrder_Load);
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
           // oProduct = new Product(this.CompanyID);
            this.txtProductID.Focus();
            //Load Brochures

		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtProductID
            if (sender==txtProductID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oProduct.View())
                    {
                        Clear();
                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtProductID.Focus();
                    }
                    
                    if (oProduct.Find(txtProductID.Text))
                    {
                        Clear();
                        txtDescription.Text = oProduct.Description;
                        
                    } else
                    {
                        Clear();
                        
                    }


                    
                }					

            }
            #endregion

            #region txtQuanity
            if (sender == txtQuantity)
            {
               if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtQuantity.Focus();
                    } 
                   Int32 Quantity = (Int32) txtQuantity.Value;
                   if (Quantity == 0)
                   {
                       txtQuantity.Focus();
                       return;
                   }
                   txtAdjDescription.Focus();
                   return;
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
                            
                            Clear();
                            txtProductID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    txtProductID.Focus();
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
            
            Clear();
            txtProductID.Clear();
            
        }
        
        public void Display()
        {
            //Clear();
            //txtLength.Text = oProduct.Length.ToString();
          // txtProductID.Text = oProduct.ID;
            
            
            
        }
        public void Clear()
        {
            ctrType.Text = "";
            
            
        }
      
		#endregion

        private void ctrState_SelectedValueChanged(object sender, EventArgs e)
        {
            Display();
            
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            Int32 Quantity = (Int32) txtQuantity.Value;           
                    switch (ctrType.Text)
                       {
                           case "ONPO":
                               oProduct.ONPO += Quantity;
                               break;
                           case "Received":
                               oProduct.Received += Quantity;
                               break;
                           case "OnHand":
                               oProduct.OnHand += Quantity;
                               break;
                           case "Committed":
                               oProduct.Committed += Quantity;
                               break;
                           case "Sold":
                               oProduct.Sold += Quantity;
                               break;
                           
                       }
                       oProduct.InsertMisc(Quantity, txtAdjDescription.Text, ctrType.Text);
                       oProduct.Save();
                       Close();
            
        }

	}
}
