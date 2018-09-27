using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Reports;
using Signature.Classes;

namespace Signature
{
	/// <summary>
	/// Summary description for CustomerView.
	/// </summary>
	public class frmViewNoScanned : System.Windows.Forms.Form
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
		internal System.Windows.Forms.ProgressBar pbar;
		private System.ComponentModel.IContainer components;

		private DataView dt;
        
		public String sSelectedID = "";
		private String sCompanyID = "";
        private Button btPrint;
		private String sCustomerID = "";
		
		public frmViewNoScanned(String sCompanyID, String CustomerID)
		{
			//
			// Required for Windows Form Designer support
			//
			
			this.sCompanyID = sCompanyID;
			this.sCustomerID = CustomerID;
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
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.btPrint = new System.Windows.Forms.Button();
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
            this.DataGrid.Location = new System.Drawing.Point(7, 136);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsVisible = false;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.Size = new System.Drawing.Size(476, 322);
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
            this.Label1.Location = new System.Drawing.Point(0, 62);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(491, 6);
            this.Label1.TabIndex = 79;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Haettenschweiler", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(491, 52);
            this.Label2.TabIndex = 80;
            this.Label2.Text = "           Not Scanned Order List";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.Location = new System.Drawing.Point(8, 72);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(475, 42);
            this.GroupBox1.TabIndex = 77;
            this.GroupBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(8, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(353, 21);
            this.txtSearch.TabIndex = 61;
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
            this.btnClose.Location = new System.Drawing.Point(411, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 24);
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
            this.Label23.Location = new System.Drawing.Point(0, 52);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(491, 10);
            this.Label23.TabIndex = 75;
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(8, 118);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(475, 8);
            this.pbar.TabIndex = 78;
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(333, 466);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(149, 25);
            this.btPrint.TabIndex = 82;
            this.btPrint.Text = "&Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // frmViewNoScanned
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(491, 495);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.Label2);
            this.Name = "frmViewNoScanned";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Not Scanned Order View";
            this.Load += new System.EventHandler(this.frmViewTeacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
			
		
	
		private void frmViewTeacher_Load(object sender, System.EventArgs e)
		{


            Signature.Data.MySQL oMySql = Global.oMySql;

            //dt = oMySql.GetDataView("SELECT ID, Teacher, Student, Scanned, Packed FROM Orders Where CompanyID='"+sCompanyID+ "' And  CustomerID='"+sCustomerID+"' And (BoxesPacked!=0 And BoxesPacked!=BoxesScanned)","Tmp");
            dt = oMySql.GetDataView(String.Format("SELECT o.ID, o.Teacher,o.Student,ol.Scanned, ol.Packed FROM Orders o Left Join  OrderByLine ol On o.ID=ol.OrderID  Where o.CompanyID='{0}' And CustomerID='{1}' And ol.PackID='{2}'  And (ol.Packed<>'1' Or ol.Scanned <>'1')  And o.Teacher NOT Like '%A INTERNET%'", Global.CurrrentCompany, this.sCustomerID, Global.CurrrentLine), "Tmp");
			     
            //cboTraineeFields.Items.Insert(0, "Teacher");
            //cboTraineeFields.Items.Insert(1, "Students");
            
            //cboTraineeFields.SelectedIndex = 0;
			
			//
			DataGridTableStyle TbStyle = new DataGridTableStyle();
            
            TbStyle.MappingName = "Tmp";
            TbStyle.RowHeadersVisible = false;
            TbStyle.GridLineColor = System.Drawing.Color.Black;
            TbStyle.AllowSorting = false;
            TbStyle.AlternatingBackColor = System.Drawing.Color.AliceBlue;


            DataGridTextBoxColumn Col_01 = new DataGridTextBoxColumn();

            Col_01.HeaderText = "Order ID";
            Col_01.MappingName = "ID";
            Col_01.Width = 50;
            Col_01.NullText = "";
            Col_01.ReadOnly = true;

            DataGridTextBoxColumn Col_02 = new DataGridTextBoxColumn();
             
            Col_02.HeaderText = "Teacher Name";
            Col_02.MappingName = "Teacher";
            Col_02.Width = 150;
            Col_02.NullText = "";
            Col_02.ReadOnly = true;
            
            DataGridTextBoxColumn Col_03 = new DataGridTextBoxColumn();
            
            Col_03.HeaderText = "Student Name";
            Col_03.MappingName = "Student";
            Col_03.Width = 150;
            Col_03.NullText = "";
            Col_03.ReadOnly = true;

            DataGridTextBoxColumn Col_04 = new DataGridTextBoxColumn();

            Col_04.HeaderText = "Packed";
            Col_04.MappingName = "Packed";
            Col_04.Width = 50;
            Col_04.NullText = "";
            Col_04.ReadOnly = true;

            DataGridTextBoxColumn Col_05 = new DataGridTextBoxColumn();

            Col_05.HeaderText = "Scanned";
            Col_05.MappingName = "Scanned";
            Col_05.Width = 50;
            Col_05.NullText = "";
            Col_05.ReadOnly = true;

            TbStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] { Col_01, Col_02, Col_03, Col_04, Col_05 });
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

            String fld = new string(' ', 100);
            String fld1 = new string(' ', 100);
            fld = "Teacher";
            fld1 = "Student";
            dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or " + fld1 + " like '*" + txtSearch.Text + "*'";
            DataGrid.DataSource = dt;

		
		}

		private void DataGrid_DoubleClick(object sender, System.EventArgs e)
		{
			sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
			this.Close();
		}

		private void DataGrid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//MessageBox.Show(e.KeyCode.ToString());
			if (e.KeyCode.ToString()=="Enter")
			{
				//sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
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

        private void btPrint_Click(object sender, EventArgs e)
        {
            MySQL oMySql = Global.oMySql;
            //frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            //ds.Tables.Add(oMySql.GetDataTable("SELECT ID, CustomerID, Teacher, Student, Scanned, Packed FROM Orders Where CompanyID='" + sCompanyID + "' And  CustomerID='" + sCustomerID + "' And (Packed<>'1' Or Scanned <>'1')", "NoScanned"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT o.ID, o.Teacher,o.Student,ol.BoxesPacked,ol.BoxesScanned,ol.Scanned,ol.Packed FROM Orders o Left Join  OrderByLine ol On o.ID=ol.OrderID  Where o.CompanyID='{0}' And CustomerID='{1}' And ol.PackID='{2}'  And (ol.Packed<>'1' Or ol.Scanned <>'1')  And o.Teacher NOT Like '%A INTERNET%'",Global.CurrrentCompany,this.sCustomerID,Global.CurrrentLine), "NoScanned"));
            ds.Tables.Add(oMySql.GetDataTable("SELECT * From Customer Where CompanyID='" + sCompanyID + "' And CustomerID='" + sCustomerID + "'", "Customer"));            
            //ds.WriteXml("dataset91.xml", XmlWriteMode.WriteSchema);
            ScanningLeftOrders oRpt = new ScanningLeftOrders();

            oRpt.SetDataSource(ds);
            oRpt.PrintToPrinter(1, true, 1, 100);
            this.Close();
            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();
        }
		
	}
}
