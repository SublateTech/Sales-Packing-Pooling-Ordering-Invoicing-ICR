using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;

namespace Signature
{
	/// <summary>
	/// Summary description for CustomerView.
	/// </summary>
	public class frmProductView : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.DataGrid DataGrid;
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.Label Label1;
		internal Signature.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.Label Label23;
		public System.Windows.Forms.ListView lstView;
		internal System.Windows.Forms.ProgressBar pbar;
		private System.ComponentModel.IContainer components;

		private DataView dt;
		public String sSelectedID = "";
		private String sCompanyID = "";
        private Customer oCustomer;
		
		public frmProductView(String sCompanyID)
		{
			//
			// Required for Windows Form Designer support
			//
			
			this.sCompanyID = sCompanyID;
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


        public frmProductView(Customer oCustomer)
        {
            this.oCustomer = oCustomer;
            this.sCompanyID = oCustomer.CompanyID;
            InitializeComponent();
         
        }
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.components = new System.ComponentModel.Container();
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.pbar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.DataMember = "";
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(4, 80);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsVisible = false;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.Size = new System.Drawing.Size(380, 328);
            this.DataGrid.TabIndex = 81;
            this.DataGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
            this.DataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.DataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGrid_KeyUp);
            this.DataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.DataGrid_Navigate);
            this.DataGrid.Click += new System.EventHandler(this.DataGrid_DoubleClick);
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(15, 15);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label1.Location = new System.Drawing.Point(0, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(392, 6);
            this.Label1.TabIndex = 79;
            // 
            // GroupBox1
            // 
            this.GroupBox1.AllowDrop = true;
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(4, 16);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(380, 42);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(279, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(301, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 24);
            this.btnClose.TabIndex = 67;
            this.btnClose.Tag = "";
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label23
            // 
            this.Label23.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label23.Location = new System.Drawing.Point(0, 0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(392, 10);
            this.Label23.TabIndex = 75;
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstView
            // 
            this.lstView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.FullRowSelect = true;
            this.lstView.GridLines = true;
            this.lstView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstView.HideSelection = false;
            this.lstView.LargeImageList = this.ImageList1;
            this.lstView.Location = new System.Drawing.Point(-160, 428);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(121, 24);
            this.lstView.SmallImageList = this.ImageList1;
            this.lstView.TabIndex = 74;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(0, 64);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(384, 10);
            this.pbar.TabIndex = 78;
            // 
            // frmProductView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 414);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.lstView);
            this.Name = "frmProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomerView";
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		
		private void frmCustomerView_Load(object sender, System.EventArgs e)
		{

            MySQL oMySql = Global.oMySql;
            String Sql = String.Empty;

            if (oCustomer != null)
            {
               // oCustomer.Brochures.Load(oCustomer.CompanyID, oCustomer.ID);
                if (oCustomer.Brochures.Count > 0)
                {
                    Sql = " And (";
                    int x = 0;
                    foreach (BrochureByCustomer bc in oCustomer.Brochures)
                    {
                        if (x >= 1)
                            Sql += " OR ";
                        Sql += "BrochureID='" + bc.BrochureID + "'";
                        x++;
                    }
                    Sql += ")";
                }
                //MessageBox.Show(Sql);
                dt = oMySql.GetDataView("Select p.ProductID,p.Description, p.VendorItem  from Product p left Join BrochureDetail bd on bd.CompanyID=p.CompanyID And bd.ProductID=p.ProductID  Where p.CompanyID='" + sCompanyID + "'"+Sql + " Group By p.ProductID","Products");
                //Console.WriteLine("Select p.ProductID,p.Description  from Product p left Join BrochureDetail bd on bd.CompanyID=p.CompanyID And bd.ProductID=p.ProductID  Where p.CompanyID='" + sCompanyID + "'" + Sql + " Group By p.ProductID");
            }else
			    dt = oMySql.GetDataView("Select d.ProductID,d.Description, d.VendorItem from Product d Where CompanyID='"+sCompanyID+"'","Products");
            this.Text = "Product View";
			//
			//
			DataGridTableStyle TbStyle = new DataGridTableStyle();
            
            TbStyle.MappingName = "Products";
            TbStyle.RowHeadersVisible = false;
            TbStyle.GridLineColor = System.Drawing.Color.Black;
            TbStyle.AllowSorting = false;
            TbStyle.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            
			DataGridTextBoxColumn Col_01 = new DataGridTextBoxColumn();
             
            Col_01.HeaderText = "Product ID";
            Col_01.MappingName = "ProductID";
            Col_01.Width = 45;
            Col_01.NullText = "";
            Col_01.ReadOnly = true;
			Col_01.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            
            DataGridTextBoxColumn Col_02 = new DataGridTextBoxColumn();
            
            Col_02.HeaderText = "Description";
            Col_02.MappingName = "Description";
            Col_02.Width = 225;
            Col_02.NullText = "";
            Col_02.ReadOnly = true;
            
           DataGridTextBoxColumn Col_03 = new DataGridTextBoxColumn();
             
            Col_03.HeaderText = "VendorItem";
            Col_03.MappingName = "VendorItem";
            Col_03.Width = 60;
            Col_03.NullText = "";
            Col_03.ReadOnly = true;


            TbStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] { Col_01, Col_02, Col_03 });
            DataGrid.TableStyles.Add(TbStyle);
            
			DataGrid.DataSource = dt;
            //DataGrid.Focus();
			this.txtSearch.Focus();
			//oMySql.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtSearch_TextChanged_1(object sender, System.EventArgs e)
		{

            String fld = String.Empty;
            String fld1 = String.Empty;
            String fld2 = String.Empty;

			fld = "ProductID";
			fld1 = "Description";
            fld2 = "VendorItem";

            dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or "+fld1 + " like '*" + txtSearch.Text  + "*' or "+fld2 + " like '*" + txtSearch.Text  + "*'";
			DataGrid.DataSource = dt;

		
		}

		private void DataGrid_DoubleClick(object sender, System.EventArgs e)
		{
				sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
				this.Close();
			
		}

		private void DataGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
			this.Close();
		
		}

		private void DataGrid_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void DataGrid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}
	}
}
