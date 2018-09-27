using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Classes;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmUPCA : frmBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private UpcA upc = null;

		private System.Windows.Forms.Button butDraw;
		private System.Windows.Forms.Button butPrint;
		private System.Windows.Forms.PictureBox picBarcode;
		private System.Windows.Forms.TextBox txtManufacturerCode;
		private System.Windows.Forms.TextBox txtProductCode;
		private System.Windows.Forms.ComboBox cboProductType;
		private System.Windows.Forms.TextBox txtChecksumDigit;
		private System.Windows.Forms.ComboBox cboScale;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private Label label6;
        private TextBox txtHeight;
        private Label label7;
        private TextBox txtDescription;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label8;
		private System.Windows.Forms.Button butCreateBitmap;
        private Signature.Windows.Forms.MaskedEdit txtProduct;

        private Product oProduct = new Product(Global.GetParameter("CurrentCompany"));

		public frmUPCA()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			cboProductType.SelectedIndex = 0;
			cboScale.SelectedIndex = 2;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.butDraw = new System.Windows.Forms.Button();
            this.butPrint = new System.Windows.Forms.Button();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.txtManufacturerCode = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.txtChecksumDigit = new System.Windows.Forms.TextBox();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butCreateBitmap = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProduct = new Signature.Windows.Forms.MaskedEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 577);
            this.txtStatus.Size = new System.Drawing.Size(455, 29);
            // 
            // butDraw
            // 
            this.butDraw.Location = new System.Drawing.Point(215, 53);
            this.butDraw.Name = "butDraw";
            this.butDraw.Size = new System.Drawing.Size(100, 23);
            this.butDraw.TabIndex = 0;
            this.butDraw.Text = "Draw Barcode";
            this.butDraw.Click += new System.EventHandler(this.butDraw_Click);
            // 
            // butPrint
            // 
            this.butPrint.Location = new System.Drawing.Point(215, 96);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(100, 23);
            this.butPrint.TabIndex = 1;
            this.butPrint.Text = "Print Barcode";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(47, 305);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(324, 249);
            this.picBarcode.TabIndex = 2;
            this.picBarcode.TabStop = false;
            // 
            // txtManufacturerCode
            // 
            this.txtManufacturerCode.Location = new System.Drawing.Point(48, 132);
            this.txtManufacturerCode.Name = "txtManufacturerCode";
            this.txtManufacturerCode.Size = new System.Drawing.Size(121, 20);
            this.txtManufacturerCode.TabIndex = 3;
            this.txtManufacturerCode.Text = "10709";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(48, 180);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(121, 20);
            this.txtProductCode.TabIndex = 4;
            this.txtProductCode.Text = "01001";
            // 
            // cboProductType
            // 
            this.cboProductType.Items.AddRange(new object[] {
            "0",
            "2",
            "3",
            "4",
            "5",
            "7",
            "8"});
            this.cboProductType.Location = new System.Drawing.Point(48, 84);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(121, 21);
            this.cboProductType.TabIndex = 5;
            // 
            // txtChecksumDigit
            // 
            this.txtChecksumDigit.Location = new System.Drawing.Point(48, 226);
            this.txtChecksumDigit.Name = "txtChecksumDigit";
            this.txtChecksumDigit.Size = new System.Drawing.Size(121, 20);
            this.txtChecksumDigit.TabIndex = 6;
            // 
            // cboScale
            // 
            this.cboScale.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2.0"});
            this.cboScale.Location = new System.Drawing.Point(215, 194);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(100, 21);
            this.cboScale.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(48, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product Type :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(48, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Manufacturer Code :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(48, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Product Code :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(48, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Checksum Digit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(215, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Scale Factor";
            // 
            // butCreateBitmap
            // 
            this.butCreateBitmap.Location = new System.Drawing.Point(215, 139);
            this.butCreateBitmap.Name = "butCreateBitmap";
            this.butCreateBitmap.Size = new System.Drawing.Size(100, 23);
            this.butCreateBitmap.TabIndex = 13;
            this.butCreateBitmap.Text = "Create Bitmap";
            this.butCreateBitmap.Click += new System.EventHandler(this.butCreateBitmap_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(215, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Height";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(215, 236);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(78, 20);
            this.txtHeight.TabIndex = 14;
            this.txtHeight.Text = "0.5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(48, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(48, 278);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(257, 20);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.Text = "01001-Shower Gel";
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(54, 23);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(80, 20);
            this.txtProductID.TabIndex = 18;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Item:";
            // 
            // txtProduct
            // 
            this.txtProduct.AllowDrop = true;
            this.txtProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduct.Location = new System.Drawing.Point(157, 24);
            this.txtProduct.Name = "txtCustomerID";
            this.txtProduct.Size = new System.Drawing.Size(289, 20);
            this.txtProduct.TabIndex = 20;
            // 
            // frmUPCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(455, 606);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.butCreateBitmap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.txtChecksumDigit);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtManufacturerCode);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.butDraw);
            this.Name = "frmUPCA";
            this.Text = "Barcode Printing";
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.butDraw, 0);
            this.Controls.SetChildIndex(this.butPrint, 0);
            this.Controls.SetChildIndex(this.picBarcode, 0);
            this.Controls.SetChildIndex(this.txtManufacturerCode, 0);
            this.Controls.SetChildIndex(this.txtProductCode, 0);
            this.Controls.SetChildIndex(this.cboProductType, 0);
            this.Controls.SetChildIndex(this.txtChecksumDigit, 0);
            this.Controls.SetChildIndex(this.cboScale, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.butCreateBitmap, 0);
            this.Controls.SetChildIndex(this.txtHeight, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtProductID, 0);
            this.Controls.SetChildIndex(this.txtProduct, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmUPCA());
		}

		private void CreateUPC( )
		{
			upc = new UpcA( );
			upc.ProductType = cboProductType.Items [cboProductType.SelectedIndex].ToString( );
			upc.ManufacturerCode = txtManufacturerCode.Text;
			upc.ProductCode = txtProductCode.Text;
            upc._Description = txtDescription.Text;
            upc._fHeight = (float)Convert.ToDouble(txtHeight.Text);

			if( txtChecksumDigit.Text.Length > 0 )
				upc.ChecksumDigit = txtChecksumDigit.Text;
		}

		private void butDraw_Click(object sender, EventArgs e)
		{
			System.Drawing.Graphics g = this.picBarcode.CreateGraphics( );
			
			g.FillRectangle( new System.Drawing.SolidBrush( System.Drawing.SystemColors.Control ),
				new Rectangle( 0, 0, picBarcode.Width, picBarcode.Height ) );

			CreateUPC( );
            
            upc.Scale = (float)Convert.ToDecimal( cboScale.Items [cboScale.SelectedIndex] );
            
         //   if (txtChecksumDigit.Text.Length >  0)
		//	    upc.ChecksumDigit = txtChecksumDigit.Text;
                
            upc.DrawUpcaBarcode(g, new System.Drawing.Point(0, 0));

            txtChecksumDigit.Text = upc.ChecksumDigit;

			g.Dispose( );
		}

		private void butPrint_Click(object sender, EventArgs e)
		{
			System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument( );
			pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler( this.pd_PrintPage );
			pd.Print( );
		}

		private void pd_PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs ev)
		{
			CreateUPC( );
			upc.Scale = ( float )Convert.ToDecimal( cboScale.Items [cboScale.SelectedIndex] );
            float x = (float)0.8;
            float y = (float)0.5;

            //String Description = "1615-Double-Sided Tape Applicator";
            for (int i=0; i <10;i++)
            {
                upc.DrawUpcaBarcode(ev.Graphics, new System.Drawing.PointF(0+x, i + y));
                upc.DrawUpcaBarcode(ev.Graphics, new System.Drawing.PointF((float)2.5+x, i + y));
                upc.DrawUpcaBarcode(ev.Graphics, new System.Drawing.PointF((float)5.0+x, i + y));
            }
            txtChecksumDigit.Text = upc.ChecksumDigit;

			// Add Code here to print other information.
            
			ev.Graphics.Dispose( );
		}

		private void butCreateBitmap_Click(object sender, EventArgs e)
		{
			CreateUPC( );
			upc.Scale = ( float )Convert.ToDecimal( cboScale.Items [cboScale.SelectedIndex] );

			System.Drawing.Bitmap bmp = upc.CreateBitmap( );

			txtChecksumDigit.Text = upc.ChecksumDigit;

			this.picBarcode.Image = bmp;
		}

        private void txtProductID_KeyUp(object sender, KeyEventArgs e)
        {
            #region txtProductID
            if (sender == txtProductID)
            {

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


                if (e.KeyCode.ToString() == "F2")
                {
                    if (oProduct.View())
                    {
                        if (oProduct.BarCode.Trim().Length < 11)
                        {
                            Global.ShowNotifier("Please check Barcode");
                            return;
                        }
                        
                        //ShowProduct();
                        txtProductID.Text = oProduct.ID;
                        txtProduct.Text = oProduct.BarCode + "-" + oProduct.Description;
                        txtDescription.Focus();
                        cboProductType.Text = oProduct.BarCode.Substring(0, 1);
                        txtManufacturerCode.Text = oProduct.BarCode.Substring(1, 5);
                        txtProductCode.Text = oProduct.BarCode.Substring(6, 5);
                        txtChecksumDigit.Text = oProduct.BarCode.Substring(11, 1);
                        txtDescription.Text = oProduct.ID + "-" + oProduct.Description;
                        cboScale.Text = "1.0";
                        txtHeight.Text = "0.6";
                    }

                }


                


                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductID.Text.Trim().Length == 0)
                    {
                        //Clear();
                        txtProductID.Focus();
                        
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {
                        //ShowProduct();
                        txtDescription.Focus();
                        
                        txtProductID.Text = oProduct.ID;
                        if (oProduct.BarCode == "")
                        {
                            MessageBox.Show("No barcode entered");
                            txtProductID.Focus();
                            return;
                        }
                        txtProduct.Text = oProduct.BarCode+"-"+oProduct.Description;
                        txtDescription.Focus();
                        cboProductType.Text = oProduct.BarCode.Substring(0, 1);
                        txtManufacturerCode.Text = oProduct.BarCode.Substring(1, 5);
                        txtProductCode.Text = oProduct.BarCode.Substring(6, 5);
                        txtChecksumDigit.Text = oProduct.BarCode.Substring(11, 1);
                        txtDescription.Text = oProduct.ID + "-" + oProduct.Description;
                        cboScale.Text = "1.0";
                        txtHeight.Text = "0.6";

                    }
                    else
                    {
                        //Clear();

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
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
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
                            oProduct.Delete();
                            //Clear();
                            txtProductID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    //Save();
                    txtProductID.Focus();
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion
        }

        
	}
}
