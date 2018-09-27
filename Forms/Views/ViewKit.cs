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
	public class frmKitView : System.Windows.Forms.Form
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
		
		public frmKitView(String sCompanyID)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCustomerView));
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
			this.DataGrid.Size = new System.Drawing.Size(292, 328);
			this.DataGrid.TabIndex = 81;
			this.DataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGrid_KeyUp);
			this.DataGrid.Click += new System.EventHandler(this.DataGrid_DoubleClick);
			this.DataGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
			this.DataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
			this.DataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.DataGrid_Navigate);
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
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label1.Location = new System.Drawing.Point(0, 10);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(304, 6);
			this.Label1.TabIndex = 79;
			// 
			// GroupBox1
			// 
			this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.GroupBox1.Controls.Add(this.txtSearch);
			this.GroupBox1.Controls.Add(this.btnClose);
			this.GroupBox1.Location = new System.Drawing.Point(4, 16);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(292, 42);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Location = new System.Drawing.Point(16, 14);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 21);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.Text = "";
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.DimGray;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(224, 12);
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
			this.Label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.Label23.Location = new System.Drawing.Point(0, 0);
			this.Label23.Name = "Label23";
			this.Label23.Size = new System.Drawing.Size(304, 10);
			this.Label23.TabIndex = 75;
			this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstView
			// 
			this.lstView.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lstView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstView.FullRowSelect = true;
			this.lstView.GridLines = true;
			this.lstView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstView.HideSelection = false;
			this.lstView.LargeImageList = this.ImageList1;
			this.lstView.Location = new System.Drawing.Point(-204, 428);
			this.lstView.MultiSelect = false;
			this.lstView.Name = "lstView";
			this.lstView.Size = new System.Drawing.Size(121, 24);
			this.lstView.SmallImageList = this.ImageList1;
			this.lstView.TabIndex = 74;
			// 
			// pbar
			// 
			this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pbar.Location = new System.Drawing.Point(0, 64);
			this.pbar.Name = "pbar";
			this.pbar.Size = new System.Drawing.Size(296, 10);
			this.pbar.TabIndex = 78;
			// 
			// frmCustomerView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 414);
			this.Controls.Add(this.DataGrid);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Label23);
			this.Controls.Add(this.pbar);
			this.Controls.Add(this.lstView);
			this.Name = "frmCustomerView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CustomerView";
			this.Load += new System.EventHandler(this.frmCustomerView_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
			
		
		
		private void frmCustomerView_Load(object sender, System.EventArgs e)
		{

            Signature.Data.MySQL oMySql = Global.oMySql;

			dt = oMySql.GetDataView("Select ID,Name from ga_kit d Where CompanyID='"+sCompanyID+"'","Kits");
            this.Text = "Kit View";
			//
			 
       /*     //'.Items.Insert(0, "School ID")
            cboTraineeFields.Items.Insert(0, "Name");
            cboTraineeFields.Items.Insert(1, "Address");
            //'.Items.Insert(3, "ChairPerson")
            cboTraineeFields.SelectedIndex = 0;
		*/	
			//
			DataGridTableStyle TbStyle = new DataGridTableStyle();
            
            TbStyle.MappingName = "Kits";
            TbStyle.RowHeadersVisible = false;
            TbStyle.GridLineColor = System.Drawing.Color.Black;
            TbStyle.AllowSorting = false;
            TbStyle.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            
			DataGridTextBoxColumn Col_01 = new DataGridTextBoxColumn();
             
            Col_01.HeaderText = "Kit ID";
            Col_01.MappingName = "ID";
            Col_01.Width = 90;
            Col_01.NullText = "";
            Col_01.ReadOnly = true;
			Col_01.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            
            DataGridTextBoxColumn Col_02 = new DataGridTextBoxColumn();
            
            Col_02.HeaderText = "Description";
            Col_02.MappingName = "Name";
            Col_02.Width = 225;
            Col_02.NullText = "";
            Col_02.ReadOnly = true;
            
           /* DataGridTextBoxColumn Col_03 = new DataGridTextBoxColumn();
             
            Col_03.HeaderText = "Address";
            Col_03.MappingName = "Address";
            Col_03.Width = 225;
            Col_03.NullText = "";
            Col_03.ReadOnly = true;
*/

			TbStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] {Col_01, Col_02});
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
		
			String  fld= new string(' ',100);
			String  fld1= new string(' ',100);
			fld = "ID";
			fld1 = "Name";
			dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or "+fld1 + " like '*" + txtSearch.Text  + "*'";
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
			MessageBox.Show("Ok");
		}
	}
}
