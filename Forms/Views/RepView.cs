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
	public class frmRepView : Signature.Forms.frmBase
	{
		internal System.Windows.Forms.DataGrid DataGrid;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.ComboBox cboTraineeFields;
		internal System.Windows.Forms.Label Label23;
		public System.Windows.Forms.ListView lstView;
		internal System.Windows.Forms.ProgressBar pbar;
		private System.ComponentModel.IContainer components;

		private DataView dt;
		public String sSelectedID = "";
		private String sCompanyID = "";
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox pictureBox2;
		public String sName = "";
		
		public frmRepView(String sCompanyID)
		{
			//
			// Required for Windows Form Designer support
			//
			
			this.sCompanyID = sCompanyID;
			InitializeComponent();

            this.CompanyID = sCompanyID;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepView));
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cboTraineeFields = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 629);
            this.txtStatus.Size = new System.Drawing.Size(512, 29);
            // 
            // DataGrid
            // 
            this.DataGrid.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.CaptionText = "Product List";
            this.DataGrid.DataMember = "";
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(4, 136);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsVisible = false;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.Size = new System.Drawing.Size(500, 487);
            this.DataGrid.TabIndex = 81;
            this.DataGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
            this.DataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.DataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.DataGrid_Navigate);
            this.DataGrid.Click += new System.EventHandler(this.DataGrid_DoubleClick);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label1.Location = new System.Drawing.Point(0, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(512, 6);
            this.Label1.TabIndex = 79;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(8, 16);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(32, 24);
            this.PictureBox1.TabIndex = 76;
            this.PictureBox1.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.cboTraineeFields);
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.Location = new System.Drawing.Point(4, 72);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(500, 42);
            this.GroupBox1.TabIndex = 77;
            this.GroupBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(216, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(168, 21);
            this.txtSearch.TabIndex = 61;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(8, 16);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 18);
            this.Label5.TabIndex = 60;
            this.Label5.Text = "Search  :";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTraineeFields
            // 
            this.cboTraineeFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTraineeFields.Location = new System.Drawing.Point(72, 16);
            this.cboTraineeFields.Name = "cboTraineeFields";
            this.cboTraineeFields.Size = new System.Drawing.Size(140, 21);
            this.cboTraineeFields.TabIndex = 63;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(392, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 24);
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
            this.Label23.Size = new System.Drawing.Size(512, 10);
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
            this.lstView.Location = new System.Drawing.Point(106, 559);
            this.lstView.MultiSelect = false;
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(120, 24);
            this.lstView.TabIndex = 74;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(0, 118);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(504, 14);
            this.pbar.TabIndex = 78;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "");
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Haettenschweiler", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label2.Location = new System.Drawing.Point(0, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(512, 52);
            this.Label2.TabIndex = 82;
            this.Label2.Text = "        Rep Information Listing";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 24);
            this.pictureBox2.TabIndex = 83;
            this.pictureBox2.TabStop = false;
            // 
            // frmRepView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(512, 658);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.lstView);
            this.Name = "frmRepView";
            this.Text = "CustomerView";
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            this.Controls.SetChildIndex(this.lstView, 0);
            this.Controls.SetChildIndex(this.pbar, 0);
            this.Controls.SetChildIndex(this.Label23, 0);
            this.Controls.SetChildIndex(this.GroupBox1, 0);
            this.Controls.SetChildIndex(this.PictureBox1, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.DataGrid, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
			
		private void txtSearch_TextChanged(object sender, System.EventArgs e)
		{
		String  fld= new string(' ',100);
        //'dt.RowFilter = "Address" & " Like '" & txtSearch.Text & " * '"
        if (cboTraineeFields.SelectedIndex == 0)
            fld = "Name";
        else if (cboTraineeFields.SelectedIndex == 1 )
            fld = "Address";
           // ' ElseIf cboTraineeFields.SelectedIndex = 0 Then
           // '     fld = "CustomerID"
        
        dt.RowFilter = fld + " like '*" + txtSearch.Text + "*'";
		MessageBox.Show(fld + " like '*" + txtSearch.Text + "*'");
        DataGrid.DataSource = dt;

		}

		
		private void frmCustomerView_Load(object sender, System.EventArgs e)
		{


            dt = oMySql.GetDataView("SELECT r.RepID, rs.Name  FROM Rep r Left Join Reps rs On rs.ID=r.ID Where CompanyID='" + CompanyID + "' order by rs.Name", "Reps");
			
			//
			 
            //'.Items.Insert(0, "School ID")
            cboTraineeFields.Items.Insert(0, "Name");
            //cboTraineeFields.Items.Insert(1, "Address");
            //'.Items.Insert(3, "ChairPerson")
            cboTraineeFields.SelectedIndex = 0;
			
			//
			DataGridTableStyle TbStyle = new DataGridTableStyle();
            
            TbStyle.MappingName = "Reps";
            TbStyle.RowHeadersVisible = false;
            TbStyle.GridLineColor = System.Drawing.Color.Black;
            TbStyle.AllowSorting = false;
            TbStyle.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            
			DataGridTextBoxColumn Col_01 = new DataGridTextBoxColumn();
             
            Col_01.HeaderText = "Rep ID";
            Col_01.MappingName = "RepID";
            Col_01.Width = 125;
            Col_01.NullText = "";
            Col_01.ReadOnly = true;
            
            DataGridTextBoxColumn Col_02 = new DataGridTextBoxColumn();
            
            Col_02.HeaderText = "Name ";
            Col_02.MappingName = "Name";
            Col_02.Width = 225;
            Col_02.NullText = "";
            Col_02.ReadOnly = true;
            
            
			TbStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] {Col_01, Col_02});
            DataGrid.TableStyles.Add(TbStyle);
            
			DataGrid.DataSource = dt;
            DataGrid.Focus();
			//Global.oMySql.close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtSearch_TextChanged_1(object sender, System.EventArgs e)
		{
		
			String  fld= new string(' ',100);
			//'dt.RowFilter = "Address" & " Like '" & txtSearch.Text & " * '"
			if (cboTraineeFields.SelectedIndex == 0)
				fld = "Name";
			else if (cboTraineeFields.SelectedIndex == 1 )
				fld = "Address";
			// ' ElseIf cboTraineeFields.SelectedIndex = 0 Then
			// '     fld = "CustomerID"
        
			dt.RowFilter = fld + " like '*" + txtSearch.Text + "*'";
			DataGrid.DataSource = dt;

		
		}

		private void DataGrid_DoubleClick(object sender, System.EventArgs e)
		{
			
		
		}

		private void DataGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
			sName = DataGrid[DataGrid.CurrentRowIndex, 1].ToString();
			this.Close();
		
		}

		private void DataGrid_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}
	}
}
