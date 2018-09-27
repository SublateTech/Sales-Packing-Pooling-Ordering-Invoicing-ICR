using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;


namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmOrderScan : System.Windows.Forms.Form
	{
		#region declarations		
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
		private System.ComponentModel.IContainer components;
		#endregion
		MySQL oMySql = new MySQL();
		private Signature.Windows.Forms.MaskedEdit txtCustomerID;
		private Signature.Windows.Forms.MaskedEdit txtTeacher;
		private Signature.Windows.Forms.MaskedEdit txtStudent;
		private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Signature.Windows.Forms.MaskedEdit txtQuantity;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.MaskedEditNumeric txtDiff;
        private Signature.Windows.Forms.MaskedEditNumeric txtCollected;
        private Signature.Windows.Forms.MaskedEditNumeric txtNoItems;
        private Label label10;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private ListView listView;
        private ColumnHeader columnHeaderString;
        private ColumnHeader columnHeaderNoCase;
        private ColumnHeader columnHeaderInt32;
        private ColumnHeader columnHeader1;
		
        Order oOrder = new Order();
        String CompanyID = new string(' ', 10);

		public frmOrderScan()
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderScan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderString = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNoCase = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderInt32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoItems = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtCollected = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDiff = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEdit();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(432, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtStudent);
            this.groupBox2.Controls.Add(this.txtTeacher);
            this.groupBox2.Controls.Add(this.txtCustomerID);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Order Header ";
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.Location = new System.Drawing.Point(144, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 19);
            this.txtName.TabIndex = 12;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.Location = new System.Drawing.Point(92, 68);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(320, 20);
            this.txtStudent.TabIndex = 3;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.Location = new System.Drawing.Point(92, 44);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(320, 20);
            this.txtTeacher.TabIndex = 2;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(92, 20);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(30, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.listView);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 344);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Order Detail ";
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.BackColor = System.Drawing.SystemColors.Window;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderString,
            this.columnHeaderNoCase,
            this.columnHeaderInt32,
            this.columnHeader1});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(8, 17);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(408, 320);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // columnHeaderString
            // 
            this.columnHeaderString.Text = "ProductID";
            this.columnHeaderString.Width = 71;
            // 
            // columnHeaderNoCase
            // 
            this.columnHeaderNoCase.Text = "Description";
            this.columnHeaderNoCase.Width = 211;
            // 
            // columnHeaderInt32
            // 
            this.columnHeaderInt32.Text = "Precio";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Quantity";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Controls.Add(this.txtEntryDate);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtNoItems);
            this.groupBox4.Controls.Add(this.txtCollected);
            this.groupBox4.Controls.Add(this.txtDiff);
            this.groupBox4.Controls.Add(this.txtRetail);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.txtQuantity);
            this.groupBox4.Controls.Add(this.txtProductID);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(433, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 344);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance1.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance1;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtEntryDate.Location = new System.Drawing.Point(51, 308);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(19, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Items:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoItems
            // 
            this.txtNoItems.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtNoItems.Appearance = appearance2;
            this.txtNoItems.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtNoItems.FormatString = "###,###";
            this.txtNoItems.InputMask = "nnnnnnnnn";
            this.txtNoItems.Location = new System.Drawing.Point(68, 162);
            this.txtNoItems.Name = "txtRetail";
            this.txtNoItems.ReadOnly = true;
            this.txtNoItems.Size = new System.Drawing.Size(59, 20);
            this.txtNoItems.TabIndex = 23;
            this.txtNoItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCollected
            // 
            this.txtCollected.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtCollected.Appearance = appearance3;
            this.txtCollected.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtCollected.FormatString = "###,###.##";
            this.txtCollected.InputMask = "{LOC}nnnnnnn.nn";
            this.txtCollected.Location = new System.Drawing.Point(27, 279);
            this.txtCollected.Name = "txtRetail";
            this.txtCollected.PromptChar = ' ';
            this.txtCollected.Size = new System.Drawing.Size(85, 20);
            this.txtCollected.TabIndex = 6;
            this.txtCollected.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDiff
            // 
            this.txtDiff.AllowDrop = true;
            appearance4.TextHAlignAsString = "Right";
            this.txtDiff.Appearance = appearance4;
            this.txtDiff.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtDiff.FormatString = "###,###.##";
            this.txtDiff.InputMask = "{LOC}nnnnnnn.nn";
            this.txtDiff.Location = new System.Drawing.Point(68, 213);
            this.txtDiff.Name = "txtRetail";
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(59, 20);
            this.txtDiff.TabIndex = 26;
            this.txtDiff.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtRetail
            // 
            this.txtRetail.AllowDrop = true;
            appearance5.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance5;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(68, 188);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(59, 20);
            this.txtRetail.TabIndex = 25;
            this.txtRetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.Location = new System.Drawing.Point(12, 109);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(115, 36);
            this.txtDescription.TabIndex = 24;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            this.txtQuantity.Location = new System.Drawing.Point(76, 82);
            this.txtQuantity.Name = "txtCustomerID";
            this.txtQuantity.Size = new System.Drawing.Size(52, 20);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.Location = new System.Drawing.Point(12, 82);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(52, 20);
            this.txtProductID.TabIndex = 4;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(24, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Amount Collected:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Diff:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Retail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(16, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Items:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(74, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Item:";
            // 
            // frmOrderScan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(579, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderScan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Orders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
		private void SelectNextControl(object sender, System.Windows.Forms.KeyEventArgs e) 
		{ 
			switch (e.KeyCode) 
			{ 
				case Keys.Return: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 

					//case Keys.<some key>: 
					// ......; 
					// break; 
			} 
		}
		private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}

		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.CompanyID = "S07";
            this.txtCustomerID.Focus();
            //oOrder.set(this);
		}

		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{


           // if (sender == lvExt.TextBox)
            //    oOrder.getTotals();
                //MessageBox.Show(sender.ToString());
            
            if (sender==txtCustomerID)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
					this.ViewCustomer();
				}
				if (e.KeyCode.ToString()=="Return")
				{
					if (!this.get_customer())
					{
						this.txtCustomerID.Focus();
						return;
					}

				}
		
			}

			if (sender==txtTeacher)	
			{
				//MessageBox.Show(e.KeyCode.ToString());
				if (e.KeyCode.ToString()=="F2")
				{
					this.ViewTeacher();
				}
                if (e.KeyCode == Keys.Enter)
                {
                    //MessageBox.Show("Check Teacher");
                    if (!this.get_teacher())
                    {
                        this.txtTeacher.Clear();
                        this.txtTeacher.Focus();
                        return;
                    }
                    
                }
		
			}
			if (sender==txtStudent)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
					this.ViewStudent();
				}
                if (e.KeyCode == Keys.Enter)
                {
                    if (!this.get_student())
                    {
                        this.txtStudent.Clear();
                        this.txtStudent.Focus();
                        return;
                    }

                }
		
			}
			if (sender==txtProductID)	
			{
				
				if (e.KeyCode.ToString()=="F8")
				{
					this.listView.Focus();
				}

				if (e.KeyCode.ToString()=="F2")
				{
					this.ViewProduct();
				}
                if (e.KeyCode == Keys.Return )
				{	
					if (!this.get_product())
					{
						this.txtProductID.Clear();
						this.txtProductID.Focus();
						return;
					}
					else
					{
						this.txtQuantity.Clear();
						this.txtQuantity.Focus();
						return;
					}
				}
		
			}
			
			
			if (sender==this.txtQuantity)	
			{
                //MessageBox.Show(e.KeyCode.ToString());
				if (e.KeyCode == Keys.Return)
				{

                    
                    if (this.txtQuantity.Text != "")
					{
                        this.oOrder.AddItem();
						this.txtProductID.Focus();
						return;
					}
					else
					{
						this.txtQuantity.Focus();
						return;
					}

				}

			}

            if (sender == this.txtCollected)
            {
                //MessageBox.Show(e.KeyCode.ToString());
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.PageDown)
                {
                    //MessageBox.Show("Ending...");
                    oOrder.Save();
                }

            }

            if (sender==this.listView)	
			{
			//	MessageBox.Show(e.KeyCode.ToString());
				if (e.KeyCode.ToString()=="Delete")
				{
					this.oOrder.DeleteItem();
					return;
				}
				if (e.KeyCode.ToString()=="F8")
				{
					this.txtProductID.Focus();
					return;
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                {
                    
                    return;
                }

		
			}

			//Default option
			switch (e.KeyCode) 
			{ 
				case Keys.Enter: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    this.listView.Focus();
                    break;
                case Keys.F3:
                    oOrder.deleteOrder();
                    break;
                case Keys.PageDown:
                    this.txtCollected.Focus();
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
			}

		
		}
		private void ViewCustomer()
		{
			frmCustomerView oView = new frmCustomerView("S07");
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				this.txtCustomerID.Text = oView.sSelectedID;
				this.get_customer();
				this.txtTeacher.Focus();
			}
		}

		private void ViewProduct()
		{
			frmProductView oView = new frmProductView("S07");
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				this.txtProductID.Text = oView.sSelectedID;
				
			}
		}

		private void ViewTeacher()
		{
			frmViewTeacher oView = new frmViewTeacher("S07",this.txtCustomerID.Text);
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				this.txtTeacher.Text = oView.sSelectedID;
				this.txtStudent.Focus();
				//this.get_customer();
				
			}
		}
		
		private void ViewStudent()
		{
			frmViewStudent oView = new frmViewStudent(this.CompanyID,this.txtCustomerID.Text, this.txtTeacher.Text);
			oView.ShowDialog();
            if (oView.SelectedID!="")
			{
				this.Update();
				this.txtStudent.Text = oView.SelectedID;
				//Order oOrder = new Order();
				//oOrder.set(this);
				oOrder.get(this.txtTeacher.Text, this.txtStudent.Text);
				this.txtProductID.Focus();
			}
		}

		private bool get_customer()
		{
			
			if (this.txtCustomerID.Text=="")
				return false;
			
			DataRow rCustomer = oMySql.GetDataRow("Select * From Customer Where CompanyID='S07' And CustomerID='"+this.txtCustomerID.Text+"'","Customer");
			if (rCustomer==null)
			{
				this.txtCustomerID.Clear();
				this.txtCustomerID.Focus();
				return false;
			}
			
			this.txtName.Text= rCustomer["Name"].ToString();
			//this.txtTeacher.Focus();
			return true;
		
		}

        private bool get_teacher()
        {

            if (this.txtTeacher.Text == "")
                return false;

            DataRow r = oMySql.GetDataRow("Select * From Orders Where CompanyID='S07' And CustomerID='" + this.txtCustomerID.Text + "' And Teacher=\"" + this.txtTeacher.Text + "\"", "Teacher");
            if (r == null)
            {
                if (MessageBox.Show("Is this a new teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {

                    this.txtTeacher.Clear();
                    this.txtTeacher.Focus();
                    return false;
                }
                else
                {
                    this.txtStudent.Clear();
                    oOrder.Clear();
                }
                
                return true;
            }

            this.txtTeacher.Text = r["Teacher"].ToString();
            //this.txtTeacher.Focus();
            return true;

        }
        
        private bool get_student()
        {

            if (this.txtStudent.Text == "")
                return false;

            DataRow r = oMySql.GetDataRow("Select * From Orders Where CompanyID='S07' And CustomerID=\"" + this.txtCustomerID.Text + "\" And Teacher=\"" + this.txtTeacher.Text + "\" And Student=\"" + this.txtStudent.Text + "\"", "Student");
            if (r == null)
            {
                if (MessageBox.Show("Is this a new student?", "Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {

                    this.txtStudent.Clear();
                    this.txtStudent.Focus();
                    return false;
                }
                else
                {
                    oOrder.Clear();
                    return true;
                }
            }

            this.txtStudent.Text = r["Student"].ToString();
            //this.txtTeacher.Focus();
            return true;

        }
		
		private bool get_product()
		{
			
			if (this.txtProductID.Text=="")
				return false;
			
			DataRow rProduct = oMySql.GetDataRow("Select * From Product Where CompanyID='S07' And ProductID='"+this.txtProductID.Text+"'","Product");
			if (rProduct==null)
			{
				return false;
			}
			
			this.oOrder.IDetail.Item = this.txtProductID.Text;
			this.oOrder.IDetail.Quantity= this.txtQuantity.Text;
			this.oOrder.IDetail.Price=rProduct["Price"].ToString();
			this.oOrder.IDetail.Description=rProduct["Description"].ToString();

			this.txtDescription.Text= rProduct["Description"].ToString();
			return true;
		
		}
        		
		#endregion

		private void txtCustomerID_Leave(object sender, System.EventArgs e)
		{
		/*	if (sender == this.txtCustomerID)
				if (!this.get_customer())
					this.txtCustomerID.Focus();*/
			
	/*		if (sender == this.txtProductID)
				if (!this.get_product())
					this.txtProductID.Focus();*/

            //if (sender == this.lvExt.TextBox)
           //     oOrder.getTotals();
		}

		// The focusedControl holds the control in focus in the current
		// control collections.
		private Control focusedControl = null;

		// This recursive call finds the control that has the focus.
		// Note: the recursion is necessary since the controls on the
		private void GetFocusedControl(Control control) 
		{
			if (control.Focused) 
			{
				focusedControl = control;
			} 
			else 
			{
				foreach (Control c in control.Controls) 
				{
					GetFocusedControl(c);
				}
			}
		}



        #region classes		
		class Order 
		{
			private frmOrder frm;
			private MySQL oMySql;
			
		    public 	struct Header
			{
			//	public String ID;
				public String CompanyID;
				public String CustomerID;
				public String Teacher;
				public String Student;
				public String PrizeID;
				public String NoItems;
				public String Retail;
				public String Collected;
				public String Tax;
				public String Printed;
				public String Date;
				public String Phone;
			}

		    public struct Detail
			{
				public String Description;
				public String Item;
				public String Quantity;
				public String Tax;
				public String Price;  
			}
			public  Detail IDetail;
			
			public  Header	IHeader;


			public Order()
			{
				this.oMySql = new MySQL() ; // Sql Open
                IHeader.CustomerID = "";
                IHeader.PrizeID = "";
                IHeader.Collected = "";
                IHeader.Teacher = "";
                IHeader.Student = "";
                IHeader.Tax = "";
                IHeader.Printed = "";
                IHeader.Phone = "";
                IDetail.Tax = "";

				
			}
			
			public void set(frmOrder frm)
			{
				this.frm = frm;
			}
			public bool get(String Teacher, String Student)
			{
				if (!this.get_header(Teacher, Student))
					return false;
				this.get_detail(Teacher, Student);
				return true;
			}
			
			private bool get_header(String Teacher, String Student)
			{
				//Header
				DataRow rOrder = this.oMySql.GetDataRow("Select * From Orders Where Teacher=\""+Teacher+"\" And Student=\""+Student+"\"","Orders");
				if (rOrder==null)
				{
					return false;
				}
                this.Clear();
                /*
                frm.txtRetail.Text = rOrder["Retail"].ToString();
				frm.txtNoItems.Text=rOrder["Nro_Items"].ToString();
				frm.txtCollected.Text=rOrder["Collected"].ToString();
				frm.txtDiff.Text = Convert.ToString((double) rOrder["Retail"] - (double) rOrder["Collected"]);
                frm.txtEntryDate.Text = rOrder["Date"].ToString();
                  */             

				return true;
			}

			private bool get_detail(String Teacher, String Student)
			{
				//Detail
				DataView tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description, p.Price  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Where Teacher=\""+Teacher+"\" And Student=\""+Student+"\"","Detail");
				foreach (DataRow Row in tDetail.Table.Rows)
				{
					//frm.listView.Items.Add(Row["ProductID"].ToString()).SubItems.AddRange(new string[]{Row["Description"].ToString(), Row["Price"].ToString(), Row["Quantity"].ToString()});
					
				}
				return true;
			}
				
			public void AddItem()
			{
				
			/*	this.IDetail.Quantity=frm.txtQuantity.Text;

				if (!IfExist())
				{
					frm.listView.Items.Add(this.IDetail.Item).SubItems.AddRange(new string[]{this.IDetail.Description, this.IDetail.Price, this.IDetail.Quantity});
                    this.getTotals();
                    frm.txtProductID.Focus();
				}else
					MessageBox.Show("This product already exists..");
                */
				return;
			}

			private bool IfExist()
			{
				bool Exist = false;
		//		int i=0;
			/*	for(i=0;i!=frm.listView.Items.Count;i++)
					if (frm.listView.Items[i].SubItems[0].Text == this.IDetail.Item)
					{
						Exist  = true;
						break;
					}*/
				return Exist;
			}

			public void DeleteItem()
			{
               /* if (frm.listView.SelectedItems.Count > 0)
                {
                    frm.listView.Items.RemoveAt(frm.listView.SelectedItems[0].Index);
                    this.getTotals();
                    frm.txtRetail.Text = this.IHeader.Retail;
                }*/
				return;
			}

			public void LoadDetail()
			{
				//int i=0;
			//	for(i=0;i!=frm.listView.Items.Count;i++)
			//		MessageBox.Show(frm.listView.Items[i].SubItems[0].Text);

			}

            public void deleteOrder()
            {

                if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    MessageBox.Show("Operation Cancelled");
                    return;
                }
                return;
            }
            
            public void  getTotals()
            {
                //double subtotal=0.00;
                //int NoItems = 0;
                //int Tax=0;
                
                //int i = 0;
               /* for (i = 0; i != frm.listView.Items.Count; i++)

                //MessageBox.Show(frm.listView.Items[i].SubItems[0].Text);
                {
                    subtotal += Convert.ToDouble(frm.listView.Items[i].SubItems[2].Text) * Convert.ToDouble(frm.listView.Items[i].SubItems[3].Text);
                    NoItems += Convert.ToInt16(frm.listView.Items[i].SubItems[3].Text);
                    Tax += 0;
                    
                }

                this.IHeader.NoItems = NoItems.ToString();
                this.IHeader.Retail = subtotal.ToString();
                
                
                frm.txtNoItems.Text = this.IHeader.NoItems;
                frm.txtRetail.Text = this.IHeader.Retail;
//                frm.txtDiff.Text = (subtotal - Convert.ToDouble(frm.txtCollected.Text)).ToString();
                */

                return;
            }

            public void Clear()
            {
                //frm.txtCustomerID.Clear();
                //frm.txtTeacher.Clear();
                //frm.txtStudent.Clear();
                //frm.listView.Clear();
                                
               /* int i = 0;
                for (i = frm.listView.Items.Count; i != 0; i--)
                     frm.listView.Items.RemoveAt(i - 1);
                
                frm.txtRetail.Clear();
                frm.txtNoItems.Clear();
                frm.txtDiff.Clear();
                frm.txtCollected.Clear();
                frm.txtEntryDate.Text = DateTime.Now.Date.ToString();*/
            }

            public void Save()
            {
                double subtotal=0.00;
                int NoItems = 0;
                //int Tax=0;
                
                //
                this.IHeader.CompanyID = frm.CompanyID;
               /* this.IHeader.CustomerID = frm.txtCustomerID.Text;
                this.IHeader.Teacher = frm.txtTeacher.Text;
                this.IHeader.Student = frm.txtStudent.Text;*/

                
               /* 
                int i = 0;
                for (i = 0; i != frm.listView.Items.Count; i++)

                
                //MessageBox.Show(frm.listView.Items[i].SubItems[0].Text);
                {
                    subtotal += Convert.ToDouble(frm.listView.Items[i].SubItems[2].Text) * Convert.ToDouble(frm.listView.Items[i].SubItems[3].Text);
                    NoItems += Convert.ToInt16(frm.listView.Items[i].SubItems[3].Text);
                    Tax += 0;

                    this.IDetail.Item = frm.listView.Items[i].SubItems[0].Text;
                    this.IDetail.Quantity = frm.listView.Items[i].SubItems[3].Text;
                    this.IDetail.Tax = "0.00";
                    this.IDetail.Price = frm.listView.Items[i].SubItems[2].Text;


                    String Sql = new String(' ', 250);    
                    Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID, Reserved )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','0')",
                    this.IHeader.Teacher, this.IHeader.Student, "000", this.IDetail.Item, this.IDetail.Quantity, this.IDetail.Tax, "0", this.IHeader.CustomerID, this.IHeader.CompanyID);

                    //MessageBox.Show(Sql);
                    oMySql.exec_sql_afected(Sql);	
                    
                }*/

                //
                this.IHeader.NoItems = NoItems.ToString();
                this.IHeader.Retail = subtotal.ToString();
                this.IHeader.Date = DateTime.Today.ToShortDateString();
                //this.IHeader.Collected = frm.txtCollected.Text;

                String Sql1 = new String(' ', 250);
                Sql1 = String.Format("Insert into Orders (CustomerID, Teacher, Student, Prize, Nro_Items, Retail,Collected, Tax, Printed,Date,Phone,CompanyID,Reserved )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','0')", this.IHeader.CustomerID,
                this.IHeader.Teacher, this.IHeader.Student, this.IHeader.PrizeID, this.IHeader.NoItems, this.IHeader.Retail, this.IHeader.Collected, this.IHeader.Tax, this.IHeader.Printed, this.IHeader.Date, this.IHeader.Phone, this.IHeader.CompanyID);
                oMySql.exec_sql(Sql1);	

                //MessageBox.Show(Sql1);
                
                //Save new order


            }
		}
			#endregion	
		

	}
}
