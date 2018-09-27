using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;



namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmRepCharges.
	/// </summary>
	public class frmRepCharges : frmBase
	{
		internal System.Windows.Forms.Label Label21;
		internal System.Windows.Forms.Label lblTraineeInformation;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label35;
		internal Signature.Windows.Forms.Button butEdit;
		internal Signature.Windows.Forms.Button butDelete;
		internal Signature.Windows.Forms.Button butCancel;
		internal Signature.Windows.Forms.Button butNew;
		internal Signature.Windows.Forms.Button btnSearchNow;
		internal System.Windows.Forms.TextBox txtRepID;
		internal System.Windows.Forms.TextBox txtName;
		internal System.Windows.Forms.ListView listCharges;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtDue;
		internal Signature.Windows.Forms.Button PrintFrm;
        internal Signature.Windows.Forms.Button button1;
        internal Signature.Windows.Forms.Button txtProcess;

        private Rep oRep = new Rep();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		


		public frmRepCharges()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.CompanyID = "S09";
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepCharges));
            this.Label21 = new System.Windows.Forms.Label();
            this.lblTraineeInformation = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRepID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.butEdit = new Signature.Windows.Forms.Button();
            this.butDelete = new Signature.Windows.Forms.Button();
            this.butCancel = new Signature.Windows.Forms.Button();
            this.butNew = new Signature.Windows.Forms.Button();
            this.btnSearchNow = new Signature.Windows.Forms.Button();
            this.listCharges = new System.Windows.Forms.ListView();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintFrm = new Signature.Windows.Forms.Button();
            this.button1 = new Signature.Windows.Forms.Button();
            this.txtProcess = new Signature.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 543);
            this.txtStatus.Size = new System.Drawing.Size(728, 29);
            // 
            // Label21
            // 
            this.Label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label21.BackColor = System.Drawing.Color.Gray;
            this.Label21.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label21.Location = new System.Drawing.Point(0, 40);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(728, 28);
            this.Label21.TabIndex = 121;
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTraineeInformation
            // 
            this.lblTraineeInformation.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTraineeInformation.Font = new System.Drawing.Font("Haettenschweiler", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraineeInformation.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTraineeInformation.Location = new System.Drawing.Point(0, 0);
            this.lblTraineeInformation.Name = "lblTraineeInformation";
            this.lblTraineeInformation.Size = new System.Drawing.Size(728, 38);
            this.lblTraineeInformation.TabIndex = 120;
            this.lblTraineeInformation.Text = "         Rep Charges";
            this.lblTraineeInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(8, 8);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(32, 24);
            this.PictureBox1.TabIndex = 122;
            this.PictureBox1.TabStop = false;
            // 
            // txtRepID
            // 
            this.txtRepID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepID.Location = new System.Drawing.Point(104, 73);
            this.txtRepID.MaxLength = 50;
            this.txtRepID.Name = "txtRepID";
            this.txtRepID.Size = new System.Drawing.Size(91, 21);
            this.txtRepID.TabIndex = 1;
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRepID_KeyUp);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(104, 102);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(296, 21);
            this.txtName.TabIndex = 168;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(5, 104);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(92, 18);
            this.Label6.TabIndex = 167;
            this.Label6.Text = "Name :";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(8, 72);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(92, 19);
            this.Label35.TabIndex = 166;
            this.Label35.Text = "Rep ID  :";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butEdit
            // 
            this.butEdit.AllowDrop = true;
            this.butEdit.BackColor = System.Drawing.SystemColors.Control;
            this.butEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butEdit.ForeColor = System.Drawing.Color.DimGray;
            this.butEdit.Image = ((System.Drawing.Image)(resources.GetObject("butEdit.Image")));
            this.butEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEdit.Location = new System.Drawing.Point(637, 167);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(80, 24);
            this.butEdit.TabIndex = 173;
            this.butEdit.Tag = "";
            this.butEdit.Text = "&Edit";
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butDelete
            // 
            this.butDelete.AllowDrop = true;
            this.butDelete.BackColor = System.Drawing.SystemColors.Control;
            this.butDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.ForeColor = System.Drawing.Color.DimGray;
            this.butDelete.Image = ((System.Drawing.Image)(resources.GetObject("butDelete.Image")));
            this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDelete.Location = new System.Drawing.Point(637, 199);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(80, 24);
            this.butDelete.TabIndex = 172;
            this.butDelete.Tag = "";
            this.butDelete.Text = "&Delete";
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.AllowDrop = true;
            this.butCancel.BackColor = System.Drawing.SystemColors.Control;
            this.butCancel.CausesValidation = false;
            this.butCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ForeColor = System.Drawing.Color.DimGray;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(637, 440);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(80, 24);
            this.butCancel.TabIndex = 171;
            this.butCancel.Tag = "";
            this.butCancel.Text = "Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butNew
            // 
            this.butNew.AllowDrop = true;
            this.butNew.BackColor = System.Drawing.SystemColors.Control;
            this.butNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNew.ForeColor = System.Drawing.Color.DimGray;
            this.butNew.Image = ((System.Drawing.Image)(resources.GetObject("butNew.Image")));
            this.butNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNew.Location = new System.Drawing.Point(637, 135);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(80, 24);
            this.butNew.TabIndex = 170;
            this.butNew.Tag = "";
            this.butNew.Text = "&New";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // btnSearchNow
            // 
            this.btnSearchNow.AllowDrop = true;
            this.btnSearchNow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearchNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchNow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchNow.ForeColor = System.Drawing.Color.DimGray;
            this.btnSearchNow.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchNow.Image")));
            this.btnSearchNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchNow.Location = new System.Drawing.Point(216, 72);
            this.btnSearchNow.Name = "btnSearchNow";
            this.btnSearchNow.Size = new System.Drawing.Size(104, 24);
            this.btnSearchNow.TabIndex = 193;
            this.btnSearchNow.Tag = "";
            this.btnSearchNow.Text = "Search";
            this.btnSearchNow.Click += new System.EventHandler(this.btnSearchNow_Click);
            // 
            // listCharges
            // 
            this.listCharges.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listCharges.AllowColumnReorder = true;
            this.listCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listCharges.FullRowSelect = true;
            this.listCharges.GridLines = true;
            this.listCharges.HoverSelection = true;
            this.listCharges.Location = new System.Drawing.Point(8, 136);
            this.listCharges.Name = "listCharges";
            this.listCharges.Size = new System.Drawing.Size(624, 392);
            this.listCharges.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listCharges.TabIndex = 194;
            this.listCharges.UseCompatibleStateImageBehavior = false;
            this.listCharges.DoubleClick += new System.EventHandler(this.listCharges_DoubleClick);
            // 
            // txtDue
            // 
            this.txtDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.Location = new System.Drawing.Point(504, 104);
            this.txtDue.MaxLength = 50;
            this.txtDue.Name = "txtDue";
            this.txtDue.ReadOnly = true;
            this.txtDue.Size = new System.Drawing.Size(104, 21);
            this.txtDue.TabIndex = 196;
            this.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 195;
            this.label1.Text = "Due :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PrintFrm
            // 
            this.PrintFrm.AllowDrop = true;
            this.PrintFrm.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PrintFrm.CausesValidation = false;
            this.PrintFrm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintFrm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PrintFrm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintFrm.ForeColor = System.Drawing.Color.DimGray;
            this.PrintFrm.Image = ((System.Drawing.Image)(resources.GetObject("PrintFrm.Image")));
            this.PrintFrm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintFrm.Location = new System.Drawing.Point(504, 72);
            this.PrintFrm.Name = "PrintFrm";
            this.PrintFrm.Size = new System.Drawing.Size(104, 24);
            this.PrintFrm.TabIndex = 197;
            this.PrintFrm.Tag = "";
            this.PrintFrm.Text = "Print All";
            this.PrintFrm.Click += new System.EventHandler(this.PrintFrm_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.CausesValidation = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(637, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 198;
            this.button1.Tag = "";
            this.button1.Text = "Print";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProcess
            // 
            this.txtProcess.AllowDrop = true;
            this.txtProcess.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtProcess.CausesValidation = false;
            this.txtProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtProcess.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.txtProcess.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcess.ForeColor = System.Drawing.Color.DimGray;
            this.txtProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtProcess.Location = new System.Drawing.Point(637, 504);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(80, 24);
            this.txtProcess.TabIndex = 199;
            this.txtProcess.Tag = "";
            this.txtProcess.Text = "Process";
            this.txtProcess.Click += new System.EventHandler(this.txtProcess_Click);
            // 
            // frmRepCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(728, 572);
            this.Controls.Add(this.txtProcess);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PrintFrm);
            this.Controls.Add(this.txtDue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listCharges);
            this.Controls.Add(this.btnSearchNow);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.txtRepID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label35);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.lblTraineeInformation);
            this.Name = "frmRepCharges";
            this.Text = "frmRepCharges";
            this.Load += new System.EventHandler(this.frmRepCharges_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.lblTraineeInformation, 0);
            this.Controls.SetChildIndex(this.Label21, 0);
            this.Controls.SetChildIndex(this.PictureBox1, 0);
            this.Controls.SetChildIndex(this.Label35, 0);
            this.Controls.SetChildIndex(this.Label6, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtRepID, 0);
            this.Controls.SetChildIndex(this.butNew, 0);
            this.Controls.SetChildIndex(this.butCancel, 0);
            this.Controls.SetChildIndex(this.butDelete, 0);
            this.Controls.SetChildIndex(this.butEdit, 0);
            this.Controls.SetChildIndex(this.btnSearchNow, 0);
            this.Controls.SetChildIndex(this.listCharges, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDue, 0);
            this.Controls.SetChildIndex(this.PrintFrm, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.txtProcess, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmRepCharges_Load(object sender, System.EventArgs e)
		{
			//MySql oMySql = new MySql();
						
			// Add column headers for Details view.
			listCharges.Columns.Add("ChargeID",0, HorizontalAlignment.Left);
			listCharges.Columns.Add("Date", 80, HorizontalAlignment.Left);
			listCharges.Columns.Add("Description", 90, HorizontalAlignment.Left);
			listCharges.Columns.Add("", 170, HorizontalAlignment.Left);
			listCharges.Columns.Add("",160, HorizontalAlignment.Left);
			listCharges.Columns.Add("Charge", 90, HorizontalAlignment.Right);

			listCharges.Sorting = SortOrder.None;
			listCharges.AllowColumnReorder = true;
			


			//cmdFillList_Click(this.CompanyID, this.txtRepID.Text);
			listCharges.View = View.Details;

			this.txtRepID.Focus();
			this.txtRepID.Focus();
		
		}

		private void LoadCharges()
		{
            
		//	DataTable  dtr = oMySql.get_rep_total(CompanyID, oRep.RepID.ToString()).Tables["total"];


         
          DataTable dtr = oMySql.GetDataTable("SELECT  sum(c.Charge) as Due FROM rep_charges c  Where c.Rep_Id='"+oRep.RepID.ToString()+"' Group By c.CompanyID, c.Rep_ID Order by c.ChargeID asc", "tmp");
          

			if (dtr.Rows.Count == 0)
			{
				this.txtDue.Text = "0.00";
			}
			else
			{
				this.txtDue.Text = dtr.Rows[0]["Due"].ToString();
				
			}

          //  DataTable dt = oMySql.get_rep_charges(CompanyID, oRep.RepID.ToString()).Tables[0];
			//this.DataGrid.DataSource = dsCharges.Tables[0];

            //if (sRepID == "*")
             //   da = new MySqlDataAdapter("Select ch.RepID, r.Name, ChargeID, Date, Description, Description_1, Description_2, Charge  from rep_charges ch LEFT JOIN Rep r On ch.RepID=r.RepID And ch.CompanyID=r.CompanyID Where ch.CompanyID ='" + sCompanyID + "'  ORDER BY ch.CompanyID,ch.RepID,Date", MySQL.conn);
            

             DataTable dt = oMySql.GetDataTable("Select ch.RepID, ChargeID, Date, Description, Description_1, Description_2, Charge  from rep_charges ch  Where ch.Rep_Id='" + oRep.RepID.ToString() + "' ORDER BY Date DESC", "tmp");


			listCharges.Items.Clear();
			
			// Suspending automatic refreshes as items are added/removed.
			listCharges.BeginUpdate();

			//listCharges.SmallImageList = imagesSmall;
			//listCharges.LargeImageList = imagesLarge;
			String Index = new string(' ',20);
			foreach (DataRow dr in dt.Rows)
			{
				Index = "0000000000"+dr["ChargeID"].ToString();
				Index = Index.Substring(Index.Length - 10, 10);
				//MessageBox.Show(Index);
				
				ListViewItem listItem = new ListViewItem(Index);
				
				//(dr["ChargeID"].ToString());
				listItem.ImageIndex = 0;
				
				//MessageBox.Show(dr["Date"].ToString());
				// Add sub-items for Details view.
				//listItem.SubItems.Add(dr["ChargeID"].ToString());

                listItem.SubItems.Add(((DateTime)dr["Date"]).ToString("MM/dd/yy"));
				listItem.SubItems.Add(dr["Description"].ToString());
				listItem.SubItems.Add(dr["Description_1"].ToString());
				listItem.SubItems.Add(dr["Description_2"].ToString());
				listItem.SubItems.Add(dr["Charge"].ToString());

				listCharges.Items.Add(listItem);

				

			}

			
			
			// Re-enable the display.
			listCharges.EndUpdate();
			listCharges.Sorting = SortOrder.None;
			listCharges.Sort();
			this.txtRepID.Focus();

		}

		private void butEdit_Click(object sender, System.EventArgs e)
		{
			
			if ( listCharges.SelectedItems.Count != 0 )
			{
				frmEditRepCharges frmCharges = new frmEditRepCharges();
				frmCharges.ActionType = "Edit";
				frmCharges.Rep.RepID = Convert.ToInt32(this.txtRepID.Text);
				frmCharges.Rep.Name = this.txtName.Text;
				frmCharges.Rep.ChargeID = listCharges.SelectedItems[0].SubItems[0].Text;
				frmCharges.Rep.Date = listCharges.SelectedItems[0].SubItems[1].Text==""?Convert.ToDateTime(null):Convert.ToDateTime(listCharges.SelectedItems[0].SubItems[1].Text);
				frmCharges.Rep.Description_1 = listCharges.SelectedItems[0].SubItems[2].Text;
				frmCharges.Rep.Description_2 = listCharges.SelectedItems[0].SubItems[3].Text;
				frmCharges.Rep.Description_3 = listCharges.SelectedItems[0].SubItems[4].Text;
				frmCharges.Rep.Charge = Convert.ToDouble(listCharges.SelectedItems[0].SubItems[5].Text);

				frmCharges.ShowDialog();
			
				//this.load_rep_charges(this.CompanyID,this.txtRepID.Text);
                LoadCharges();
	
			}
		}


		private void listCharges_DoubleClick(object sender, System.EventArgs e)
		{
				
			//MessageBox.Show(listCharges.SelectedItems[0].SubItems[1].Text);
			butEdit_Click(null,null);
			
		}

		private void butNew_Click(object sender, System.EventArgs e)
		{
			if (this.txtName.Text != "")
			{
			
				frmEditRepCharges frmCharges = new frmEditRepCharges();
				frmCharges.ActionType = "New";
			
				frmCharges.Rep.CompanyID = this.CompanyID;
				frmCharges.Rep.RepID = Convert.ToInt32(this.txtRepID.Text);

				frmCharges.ShowDialog();
			
			
				//this.load_rep_charges(this.CompanyID,this.txtRepID.Text);
                LoadCharges();
			}
		
		}

		private void butDelete_Click(object sender, System.EventArgs e)
		{
			if ( listCharges.SelectedItems.Count != 0 )
			{
				//MessageBox.Show(listCharges.SelectedItems[0].SubItems[0].Text);
				
				if(MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo,  MessageBoxIcon.Warning) == DialogResult.No) 
				{
					MessageBox.Show("Operation Cancelled");
					return;
				}
				
				String Sql = new string(' ',200);
				Sql = String.Format("Delete  from rep_charges  Where ChargeID='"+listCharges.SelectedItems[0].SubItems[0].Text+"'");
				Global.oMySql.exec_sql(Sql);	
				//this.load_rep_charges(this.CompanyID,this.txtRepID.Text);
                LoadCharges();
			}
			
		return;
		}

		private String cv_date(String sStr)
		{
			
			if (sStr.Length > 5)
			{	
				DateTime d_ship;
				d_ship =new DateTime(2000+Convert.ToInt16(sStr.Substring(6,2)),Convert.ToInt16(sStr.Substring(0,2)),Convert.ToInt16(sStr.Substring(3,2)));
				sStr = "'"+d_ship.ToString("yyyy-MM-dd")+"'";
			}
			else
				sStr = "null";
			
			return sStr;

		}

		private void btnSearchNow_Click(object sender, System.EventArgs e)
		{
            if (oRep.View())
            {
                this.txtRepID.Text = oRep.RepID.ToString();
                this.txtName.Text = oRep.Name;
                //this.load_rep_charges(this.CompanyID, this.txtRepID.Text);
                LoadCharges();
            }

		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			//Application.Exit();
			this.Close();
		}

		
		private void txtRepID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode.ToString()=="F2")
			{
				btnSearchNow_Click(null,null);
			}
			if (e.KeyCode.ToString()=="Enter")
			{
				//cmdFillList_Click(null, null);
                if (txtRepID.Text != "")
                {
                    if (oRep.Find(Convert.ToInt32(txtRepID.Text)))
                    {
                        txtName.Text = oRep.Name;

                    }
                }

			}

		}

		private void PrintFrm_Click(object sender, System.EventArgs e)
		{
        //"Select ch.RepID, r.Name, ChargeID, Date, Description, Description_1, Description_2, Charge  from rep_charges ch LEFT JOIN Rep r On ch.RepID=r.RepID And ch.CompanyID=r.CompanyID Where ch.CompanyID ='" + sCompanyID + "'  ORDER BY ch.CompanyID,ch.RepID,Date"
            
                frmViewReport oViewReport = new frmViewReport();
                Boolean nView = true;
                DataSet ds1;

                //ds1 = oMySql.get_rep_charges(this.CompanyID, txtRepID.Text);
                ds1 = Global.oMySql.GetDataset(String.Format("Select ch.RepID, rs.Name, ChargeID, Date, Description, Description_1, Description_2, Charge  from rep_charges ch left join Reps rs On rs.ID=ch.Rep_ID LEFT JOIN Rep r On ch.RepID=r.RepID And ch.CompanyID=r.CompanyID Where ch.CompanyID ='{0}'  ORDER BY ch.CompanyID,ch.RepID,Date", this.CompanyID), "tmp");

                detail_rep_charges_summary oRpt1 = new detail_rep_charges_summary();

                oRpt1.SetDataSource(ds1);
                //ds1.WriteXml("..\\Reports\\dataset1.xml", XmlWriteMode.WriteSchema);
                if (nView)
                {
                    this.Text = "Summary Rep Charges";
                    oViewReport.cReport.ReportSource = oRpt1;
                    oViewReport.Show();
                }

                //    oRpt1.PrintToPrinter(1, true, 1, 100);

            



		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.txtName.Text != "")
			{
                frmViewReport oViewReport = new frmViewReport();
			    Boolean nView = true;
                DataSet ds1;
            
                //ds1 = oMySql.get_rep_charges(this.CompanyID, txtRepID.Text);
                ds1 = Global.oMySql.GetDataset(String.Format("Select r.Name, ch.RepID, ChargeID, Date, Description, Description_1, Description_2, Charge  from rep_charges ch  left Join Reps r On r.ID=ch.Rep_ID Where ch.Rep_Id='{0}' ORDER BY Date DESC",oRep.RepID), "tmp");

                        detail_rep_charges oRpt1 = new detail_rep_charges();

                        oRpt1.SetDataSource(ds1);
                        //ds1.WriteXml("..\\Reports\\dataset1.xml", XmlWriteMode.WriteSchema);
                        if (nView)
                        {
                            this.Text = "Detail Rep Charges";
                            oViewReport.cReport.ReportSource = oRpt1;
                            oViewReport.Show();
                        }
                        
                        //    oRpt1.PrintToPrinter(1, true, 1, 100);
                
			}
		}

        private void txtProcess_Click(object sender, EventArgs e)
        {
            

            //oMySql.exec_sql();
            //oMySql.
        }

		
		
		

	
	}
}
