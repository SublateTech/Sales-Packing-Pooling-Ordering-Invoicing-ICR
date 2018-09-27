using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmProductExtra : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Button bCancel;
        private Button bSubmit;
        public Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtEnglish;
        private Label label3;
        private Label label2;
        private Signature.Windows.Forms.MaskedEdit txtSpanish;
        private Infragistics.Win.Misc.UltraLabel txtDescription;
		#endregion

        private Product oProduct;
        
       
        

        public frmProductExtra()
		{
			InitializeComponent();
            //if (txtProductID.Text.Trim() != "")
                //Grid.Focus();
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
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpanish = new Signature.Windows.Forms.MaskedEdit();
            this.txtEnglish = new Signature.Windows.Forms.MaskedEdit();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 689);
            this.txtStatus.Size = new System.Drawing.Size(580, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 1);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(563, 95);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(129, 25);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(102, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Item #:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance2;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(129, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(395, 20);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.label3);
            this.ultraGroupBox2.Controls.Add(this.label2);
            this.ultraGroupBox2.Controls.Add(this.txtSpanish);
            this.ultraGroupBox2.Controls.Add(this.txtEnglish);
            this.ultraGroupBox2.Controls.Add(this.bSubmit);
            this.ultraGroupBox2.Controls.Add(this.bCancel);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 102);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(563, 583);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Spanish Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "English Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpanish
            // 
            this.txtSpanish.AllowDrop = true;
            this.txtSpanish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtSpanish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpanish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpanish.Location = new System.Drawing.Point(13, 312);
            this.txtSpanish.Multiline = true;
            this.txtSpanish.Name = "txtText";
            this.txtSpanish.Size = new System.Drawing.Size(536, 208);
            this.txtSpanish.TabIndex = 19;
            this.txtSpanish.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtEnglish
            // 
            this.txtEnglish.AllowDrop = true;
            this.txtEnglish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnglish.Location = new System.Drawing.Point(13, 42);
            this.txtEnglish.Multiline = true;
            this.txtEnglish.Name = "txtText";
            this.txtEnglish.Size = new System.Drawing.Size(536, 208);
            this.txtEnglish.TabIndex = 18;
            this.txtEnglish.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(328, 545);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(116, 545);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frmProductExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(580, 718);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmProductExtra";
            this.ShowInTaskbar = false;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
	    private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            oProduct = new Product(CompanyID);
            
            this.Text += " - " + this.CompanyID;
            oProduct.Find(txtProductID.Text);
            txtDescription.Text = oProduct.Description;
            oProduct.Items.Load();
           // Grid.DataSource = oProduct.Items.dtItems; //oProduct.Items;
            
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //MessageBox.Show(e.KeyCode.ToString());
            #region Grid
            if (sender == txtEnglish )
            {   
            }
            #endregion

            #region txtOrderID
            if (sender == txtProductID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oProduct.View())
                    {

                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        
                     
                        return;
                        

                    }
                    //this.txtDescription.Text = 
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtProductID.Text.Trim() == "")
                    {
                        txtProductID.Clear();
                        txtProductID.Focus();
                        return;
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {


                        txtProductID.Text = oProduct.ID;
                        txtDescription.Text = oProduct.Description;
                        
                     
                        return;
                    }
                    else
                    {
                        
                        return;
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
                case Keys.F3:
                    
                    break;
                case Keys.PageDown:
                    Save();
                    Clear();
                    txtProductID.Clear();
                    txtProductID.Focus();
                    txtProductID.Enabled = true;
                    return;
                    
                case Keys.Delete:
                    
                    break; 


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        private void bPrint_Click(object sender, EventArgs e)
        {

           // frmViewReport oViewReport = new frmViewReport();
           // oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtVendorID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
            this.Save();
            Clear();
            txtProductID.Enabled = true;
            txtProductID.Clear();
            txtProductID.Focus();
            
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                
            }
            if (e.KeyCode == Keys.Up)
            {
                
                //SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region  Methods
        public void Clear()
        {
            txtEnglish.Clear();
            txtSpanish.Clear();
        }

        public void Save()
        {
            
            oProduct.Save();
        }

		#endregion

	}
}
