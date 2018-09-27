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
	
	public class frmViewVendors : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.DataGrid DataGrid;
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal Signature.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.Label Label23;
        public System.Windows.Forms.ListView lstView;
		private System.ComponentModel.IContainer components;

		private DataView dt;
		public String sSelectedID = "";
		
		
        private String _CompanyID = null;
		
		public frmViewVendors(String CompanyID)
		{
			//
			// Required for Windows Form Designer support
			//
            _CompanyID = CompanyID;
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
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AlternatingBackColor = System.Drawing.SystemColors.ScrollBar;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.DataMember = "";
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(7, 107);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsVisible = false;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.Size = new System.Drawing.Size(252, 325);
            this.DataGrid.TabIndex = 81;
            this.DataGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
            this.DataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.DataGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGrid_KeyPress);
            this.DataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGrid_KeyUp);
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
            this.Label1.Location = new System.Drawing.Point(0, 50);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(264, 6);
            this.Label1.TabIndex = 79;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Haettenschweiler", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(264, 40);
            this.Label2.TabIndex = 80;
            this.Label2.Text = "        Vendor List";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(8, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(25, 24);
            this.PictureBox1.TabIndex = 76;
            this.PictureBox1.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.Location = new System.Drawing.Point(8, 59);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(248, 42);
            this.GroupBox1.TabIndex = 77;
            this.GroupBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 21);
            this.txtSearch.TabIndex = 61;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(184, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 24);
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
            this.Label23.Location = new System.Drawing.Point(0, 40);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(264, 10);
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
            this.lstView.Location = new System.Drawing.Point(-224, 440);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(122, 24);
            this.lstView.SmallImageList = this.ImageList1;
            this.lstView.TabIndex = 74;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // frmViewVendors
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(264, 438);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lstView);
            this.Name = "frmViewVendors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vendor View";
            this.Load += new System.EventHandler(this.frmViewTeacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
			
		private void txtSearch_TextChanged(object sender, System.EventArgs e)
		{
		String  fld= new string(' ',100);
        //'dt.RowFilter = "Address" & " Like '" & txtSearch.Text & " * '"
        
        fld = "Name";
        
           // ' ElseIf cboTraineeFields.SelectedIndex = 0 Then
           // '     fld = "CustomerID"
        
        dt.RowFilter = fld + " like '*" + txtSearch.Text + "*'";
		MessageBox.Show(fld + " like '*" + txtSearch.Text + "*'");
        DataGrid.DataSource = dt;

		}

		
		private void frmViewTeacher_Load(object sender, System.EventArgs e)
		{

            Signature.Data.MySQL oMySql = Global.oMySql;
			
			
			dt = oMySql.GetDataView("SELECT VendorID, Name  FROM Vendor Where CompanyID='"+_CompanyID+"'", "Vendor");
			
			     
            //cboTraineeFields.Items.Insert(0, "Teacher");
            //cboTraineeFields.Items.Insert(1, "Students");
            
            //cboTraineeFields.SelectedIndex = 0;
			
			//
			DataGridTableStyle TbStyle = new DataGridTableStyle();
            
            TbStyle.MappingName = "Vendor";
            TbStyle.RowHeadersVisible = false;
            TbStyle.GridLineColor = System.Drawing.Color.Black;
            TbStyle.AllowSorting = false;
            TbStyle.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            
			DataGridTextBoxColumn Col_01 = new DataGridTextBoxColumn();
             
            Col_01.HeaderText = "Vendor ID";
            Col_01.MappingName = "VendorID";
            Col_01.Width = 80;
            Col_01.NullText = "";
            Col_01.ReadOnly = true;
            
            DataGridTextBoxColumn Col_02 = new DataGridTextBoxColumn();
            
            Col_02.HeaderText = "Name";
            Col_02.MappingName = "Name";
            Col_02.Width = 200;
            Col_02.NullText = "";
            Col_02.ReadOnly = true;
            
            TbStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] {Col_01, Col_02});
            DataGrid.TableStyles.Add(TbStyle);
            
			DataGrid.DataSource = dt;
            DataGrid.Focus();
			//oMySql.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtSearch_TextChanged_1(object sender, System.EventArgs e)
		{
		
			String  fld= new string(' ',100);
			//'dt.RowFilter = "Address" & " Like '" & txtSearch.Text & " * '"
			fld = "Name";
			
			// ' ElseIf cboTraineeFields.SelectedIndex = 0 Then
			// '     fld = "CustomerID"
        
			dt.RowFilter = fld + " like '*" + txtSearch.Text + "*'";
			DataGrid.DataSource = dt;

		
		}

		private void DataGrid_DoubleClick(object sender, System.EventArgs e)
		{
			sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
			this.Close();
		}

		private void DataGrid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode.ToString()=="Enter")
			{
				sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
				this.Close();
			}
		}

		private void DataGrid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//MessageBox.Show(e.KeyChar.ToString());
		}

		private void DataGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
			this.Close();
		
		}

		
		

		
	}
}
