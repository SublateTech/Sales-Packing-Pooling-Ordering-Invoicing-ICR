using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;


namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmEditRepCharges.
	/// </summary>
	public class frmEditRepCharges : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button butCancel;
		internal System.Windows.Forms.Button butSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public String ActionType = new string(' ',20);
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.TextBox txtCharge;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtDesc_3;
		internal System.Windows.Forms.TextBox txtDesc_2;
		internal System.Windows.Forms.TextBox txtDesc_1;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TextBox txtRepID;
		internal System.Windows.Forms.TextBox txtName;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label35;
		internal System.Windows.Forms.DateTimePicker Date;

		public class RepCharge
		{
			public String ChargeID;
			public String CompanyID;
			public Int32 RepID;
			public String Name;
			public String Description_1;
			public String Description_2;
			public String Description_3;
			public double Charge;
			public DateTime Date;
		};

		public RepCharge Rep = new RepCharge();
        public Rep oRep = new Rep();

		public frmEditRepCharges()
		{
			//
			// Required for Windows Form Designer support
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEditRepCharges));
			this.butCancel = new System.Windows.Forms.Button();
			this.butSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Date = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCharge = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDesc_3 = new System.Windows.Forms.TextBox();
			this.txtDesc_2 = new System.Windows.Forms.TextBox();
			this.txtDesc_1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtRepID = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label35 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// butCancel
			// 
			this.butCancel.BackColor = System.Drawing.SystemColors.Control;
			this.butCancel.CausesValidation = false;
			this.butCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butCancel.ForeColor = System.Drawing.Color.DimGray;
			this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCancel.Location = new System.Drawing.Point(352, 296);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(96, 24);
			this.butCancel.TabIndex = 180;
			this.butCancel.Tag = "";
			this.butCancel.Text = "Cancel";
			// 
			// butSave
			// 
			this.butSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butSave.ForeColor = System.Drawing.Color.DimGray;
			this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
			this.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSave.Location = new System.Drawing.Point(352, 264);
			this.butSave.Name = "butSave";
			this.butSave.Size = new System.Drawing.Size(96, 24);
			this.butSave.TabIndex = 181;
			this.butSave.Tag = "";
			this.butSave.Text = "Save";
			this.butSave.Click += new System.EventHandler(this.butSave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Date);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtCharge);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDesc_3);
			this.groupBox1.Controls.Add(this.txtDesc_2);
			this.groupBox1.Controls.Add(this.txtDesc_1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 200);
			this.groupBox1.TabIndex = 184;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Charge";
			// 
			// Date
			// 
			this.Date.Checked = false;
			this.Date.Location = new System.Drawing.Point(112, 40);
			this.Date.Name = "Date";
			this.Date.Size = new System.Drawing.Size(204, 20);
			this.Date.TabIndex = 205;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 18);
			this.label5.TabIndex = 192;
			this.label5.Text = "Date:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCharge
			// 
			this.txtCharge.AcceptsReturn = true;
			this.txtCharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCharge.Location = new System.Drawing.Point(112, 168);
			this.txtCharge.MaxLength = 10;
			this.txtCharge.Name = "txtCharge";
			this.txtCharge.Size = new System.Drawing.Size(120, 21);
			this.txtCharge.TabIndex = 191;
			this.txtCharge.Text = "";
			this.txtCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCharge_KeyPress);
			this.txtCharge.Validating += new System.ComponentModel.CancelEventHandler(this.txtCharge_Validating);
			this.txtCharge.Validated += new System.EventHandler(this.txtCharge_Validated);
			
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 18);
			this.label4.TabIndex = 190;
			this.label4.Text = "Charge :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDesc_3
			// 
			this.txtDesc_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDesc_3.Location = new System.Drawing.Point(112, 136);
			this.txtDesc_3.MaxLength = 50;
			this.txtDesc_3.Name = "txtDesc_3";
			this.txtDesc_3.Size = new System.Drawing.Size(216, 21);
			this.txtDesc_3.TabIndex = 189;
			this.txtDesc_3.Text = "";
			// 
			// txtDesc_2
			// 
			this.txtDesc_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDesc_2.Location = new System.Drawing.Point(112, 104);
			this.txtDesc_2.MaxLength = 50;
			this.txtDesc_2.Name = "txtDesc_2";
			this.txtDesc_2.Size = new System.Drawing.Size(216, 21);
			this.txtDesc_2.TabIndex = 188;
			this.txtDesc_2.Text = "";
			// 
			// txtDesc_1
			// 
			this.txtDesc_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDesc_1.Location = new System.Drawing.Point(112, 72);
			this.txtDesc_1.MaxLength = 50;
			this.txtDesc_1.Name = "txtDesc_1";
			this.txtDesc_1.Size = new System.Drawing.Size(216, 21);
			this.txtDesc_1.TabIndex = 187;
			this.txtDesc_1.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 18);
			this.label3.TabIndex = 186;
			this.label3.Text = "Description 3 :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 18);
			this.label2.TabIndex = 185;
			this.label2.Text = "Description 2 :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 18);
			this.label1.TabIndex = 184;
			this.label1.Text = "Description 1 :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtRepID);
			this.groupBox2.Controls.Add(this.txtName);
			this.groupBox2.Controls.Add(this.Label6);
			this.groupBox2.Controls.Add(this.Label35);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(336, 96);
			this.groupBox2.TabIndex = 185;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rep Info";
			// 
			// txtRepID
			// 
			this.txtRepID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtRepID.Location = new System.Drawing.Point(88, 22);
			this.txtRepID.MaxLength = 50;
			this.txtRepID.Name = "txtRepID";
			this.txtRepID.ReadOnly = true;
			this.txtRepID.Size = new System.Drawing.Size(91, 21);
			this.txtRepID.TabIndex = 177;
			this.txtRepID.Text = "";
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtName.Location = new System.Drawing.Point(88, 54);
			this.txtName.MaxLength = 50;
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(224, 21);
			this.txtName.TabIndex = 176;
			this.txtName.Text = "";
			// 
			// Label6
			// 
			this.Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label6.Location = new System.Drawing.Point(40, 54);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(48, 18);
			this.Label6.TabIndex = 175;
			this.Label6.Text = "Name :";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label35
			// 
			this.Label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label35.Location = new System.Drawing.Point(32, 22);
			this.Label35.Name = "Label35";
			this.Label35.Size = new System.Drawing.Size(56, 19);
			this.Label35.TabIndex = 174;
			this.Label35.Text = "Rep ID  :";
			this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmEditRepCharges
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 334);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.butSave);
			this.Controls.Add(this.butCancel);
			this.Name = "frmEditRepCharges";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmEditRepCharges";
			this.Load += new System.EventHandler(this.frmEditRepCharges_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmEditRepCharges_Load(object sender, System.EventArgs e) 
		{
			this.txtRepID.Text = this.Rep.RepID.ToString();

			if (this.ActionType=="Edit")
			{
				this.txtRepID.Text = this.Rep.RepID.ToString();
				this.txtName.Text = this.Rep.Name;
				this.txtDesc_1.Text = this.Rep.Description_1;
				this.txtDesc_2.Text = this.Rep.Description_2;
				this.txtDesc_3.Text = this.Rep.Description_3;
				this.txtCharge.Text = this.Rep.Charge.ToString();
				this.Date.Value = this.Rep.Date;
				
				

			}
		}

		private void butSave_Click(object sender, System.EventArgs e)
		{
			if (this.txtCharge.Text.Length==0)
				this.txtCharge.Text = "0.00";

		//	if (Convert.ToDouble(this.txtCharge.Text)==0)
		//		MessageBox.Show("Charge Value should be other than 0");
		//	else
		//	{
				oRep.Find(Rep.RepID);
                if (this.ActionType=="Edit")			
				{
					
					String Sql = new string(' ',200);
                    Sql = String.Format("Update rep_charges Set Description = \"{0}\", Description_1 = \"{1}\", Description_2 =\"{2}\", Charge=\"{3}\", Date=\"{4}\", Rep_ID='{5}'" + " Where ChargeID='" + Rep.ChargeID + "'",
						this.txtDesc_1.Text, this.txtDesc_2.Text, this.txtDesc_3.Text, this.txtCharge.Text, this.Date.Value.ToString("yyyy-MM-dd"),oRep.RepID);
					Global.oMySql.exec_sql(Sql);	
					this.Dispose(true);
				}
				else
				{
					txtCharge_Validating(null,null);
					
					String Sql = new string(' ',200);
                    Sql = String.Format("Insert into rep_charges (CompanyID, RepID, Description,Description_1,Description_2,Charge, Date, Rep_ID)  Values(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\")",
                        this.Rep.CompanyID, oRep.RepID, this.txtDesc_1.Text, this.txtDesc_2.Text, this.txtDesc_3.Text, this.txtCharge.Text, this.Date.Value.ToString("yyyy-MM-dd"), oRep.RepID);
					Global.oMySql.exec_sql(Sql);	
					this.Dispose(true);
				}
		//	}
			}

		private void txtCharge_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//MessageBox.Show(this.txtCharge.Text.Length.ToString());
		/*	if (this.txtCharge.Text.Length == 0)
			{
				MessageBox.Show("Charge Value should be other than 0");
				e.Cancel = true;
				this.txtCharge.Select(0, this.txtCharge.Text.Length);
				
			}
			if (Convert.ToDouble(this.txtCharge.Text)==0)
			{
				MessageBox.Show("Charge Value should be other than 0");

				e.Cancel = true;
				this.txtCharge.Select(0, this.txtCharge.Text.Length);
			}
	*/
		}
		
		private bool OnlyCharacter(int key ) 
		{
			if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || key == 8 )
				return false;
			else
				return true;	
		}

		private bool OnlyNumeric(int  Key ) 
		{
			//MessageBox.Show(Key.ToString());
			if ((Key >= 48 && Key <= 57) || Key == 8 || Key == 46 || Key == 45 )
			   return false;
			else
				return true;
		}

		
		private void txtCharge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=OnlyNumeric(e.KeyChar ); 
		}

		private void txtCharge_Validated(object sender, System.EventArgs e)
		{
			//MessageBox.Show("................");
		}
		

	
											
	}
}
