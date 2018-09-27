using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OSAS
{
	/// <summary>
	/// Summary description for frmOrderStatus.
	/// </summary>
	public class frmOrderStatus : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtCustomerID;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtTeacher;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtStudent;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox txtProduct;
		public System.Windows.Forms.StatusBar st;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox txtCompanyID;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox txtInserted;
		public System.Windows.Forms.TextBox txtDeleted;
		public System.Windows.Forms.TextBox txtUpdated;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOrderStatus()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCompanyID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtProduct = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtStudent = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTeacher = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCustomerID = new System.Windows.Forms.TextBox();
			this.st = new System.Windows.Forms.StatusBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtInserted = new System.Windows.Forms.TextBox();
			this.txtDeleted = new System.Windows.Forms.TextBox();
			this.txtUpdated = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtCompanyID);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtProduct);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtStudent);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTeacher);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtCustomerID);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 184);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tranfering ...";
			// 
			// label5
			// 
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(24, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "CompanyID:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCompanyID
			// 
			this.txtCompanyID.AcceptsReturn = true;
			this.txtCompanyID.AcceptsTab = true;
			this.txtCompanyID.Location = new System.Drawing.Point(120, 25);
			this.txtCompanyID.Name = "txtCompanyID";
			this.txtCompanyID.ReadOnly = true;
			this.txtCompanyID.Size = new System.Drawing.Size(56, 20);
			this.txtCompanyID.TabIndex = 14;
			this.txtCompanyID.Text = "";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(24, 157);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Product:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProduct
			// 
			this.txtProduct.AcceptsReturn = true;
			this.txtProduct.AcceptsTab = true;
			this.txtProduct.Location = new System.Drawing.Point(120, 149);
			this.txtProduct.Name = "txtProduct";
			this.txtProduct.ReadOnly = true;
			this.txtProduct.Size = new System.Drawing.Size(72, 20);
			this.txtProduct.TabIndex = 12;
			this.txtProduct.Text = "";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(20, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Student:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStudent
			// 
			this.txtStudent.AcceptsReturn = true;
			this.txtStudent.AcceptsTab = true;
			this.txtStudent.Location = new System.Drawing.Point(120, 118);
			this.txtStudent.Name = "txtStudent";
			this.txtStudent.ReadOnly = true;
			this.txtStudent.Size = new System.Drawing.Size(194, 20);
			this.txtStudent.TabIndex = 10;
			this.txtStudent.Text = "";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(16, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Teacher:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTeacher
			// 
			this.txtTeacher.AcceptsReturn = true;
			this.txtTeacher.AcceptsTab = true;
			this.txtTeacher.Location = new System.Drawing.Point(120, 87);
			this.txtTeacher.Name = "txtTeacher";
			this.txtTeacher.ReadOnly = true;
			this.txtTeacher.Size = new System.Drawing.Size(192, 20);
			this.txtTeacher.TabIndex = 8;
			this.txtTeacher.Text = "";
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(24, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "CustomerID:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCustomerID
			// 
			this.txtCustomerID.AcceptsReturn = true;
			this.txtCustomerID.AcceptsTab = true;
			this.txtCustomerID.Location = new System.Drawing.Point(120, 56);
			this.txtCustomerID.Name = "txtCustomerID";
			this.txtCustomerID.ReadOnly = true;
			this.txtCustomerID.Size = new System.Drawing.Size(72, 20);
			this.txtCustomerID.TabIndex = 6;
			this.txtCustomerID.Text = "";
			// 
			// st
			// 
			this.st.Location = new System.Drawing.Point(0, 320);
			this.st.Name = "st";
			this.st.Size = new System.Drawing.Size(344, 22);
			this.st.TabIndex = 7;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtUpdated);
			this.groupBox2.Controls.Add(this.txtDeleted);
			this.groupBox2.Controls.Add(this.txtInserted);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(8, 200);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 112);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Statistics";
			// 
			// label6
			// 
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(32, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Inserted Rows:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Location = new System.Drawing.Point(32, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 17;
			this.label7.Text = "Deleted Rows:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(24, 86);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 18;
			this.label8.Text = "Updated Rows:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtInserted
			// 
			this.txtInserted.AcceptsReturn = true;
			this.txtInserted.AcceptsTab = true;
			this.txtInserted.Location = new System.Drawing.Point(128, 24);
			this.txtInserted.Name = "txtInserted";
			this.txtInserted.ReadOnly = true;
			this.txtInserted.Size = new System.Drawing.Size(72, 20);
			this.txtInserted.TabIndex = 19;
			this.txtInserted.Text = "";
			// 
			// txtDeleted
			// 
			this.txtDeleted.AcceptsReturn = true;
			this.txtDeleted.AcceptsTab = true;
			this.txtDeleted.Location = new System.Drawing.Point(128, 52);
			this.txtDeleted.Name = "txtDeleted";
			this.txtDeleted.ReadOnly = true;
			this.txtDeleted.Size = new System.Drawing.Size(72, 20);
			this.txtDeleted.TabIndex = 20;
			this.txtDeleted.Text = "";
			// 
			// txtUpdated
			// 
			this.txtUpdated.AcceptsReturn = true;
			this.txtUpdated.AcceptsTab = true;
			this.txtUpdated.Location = new System.Drawing.Point(128, 80);
			this.txtUpdated.Name = "txtUpdated";
			this.txtUpdated.ReadOnly = true;
			this.txtUpdated.Size = new System.Drawing.Size(72, 20);
			this.txtUpdated.TabIndex = 21;
			this.txtUpdated.Text = "";
			// 
			// frmOrderStatus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 342);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.st);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmOrderStatus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transfering ...";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
