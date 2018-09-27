using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;


namespace Signature
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmScanning : frmBase
	{
		#region declarations		
		private Signature.Windows.Forms.GroupBox groupBox1;
		private Signature.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Signature.Windows.Forms.GroupBox groupBox3;
        private Signature.Windows.Forms.GroupBox groupBox4;
		
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Label lbCompany;
        private Label label11;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label3;
        private Label txtBox;
        private Label txtMessage;
		#endregion

        Scanning oOrder;
        Scanning oOrder1;
        Customer oCustomer;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private Signature.Windows.Forms.MaskedEdit txtPallets;
        private Signature.Windows.Forms.MaskedEdit txtOrderID;
        private Signature.Windows.Forms.BoundListView Grid;
        private System.Windows.Forms.ColumnHeader Teacher;
        private System.Windows.Forms.ColumnHeader Student;
        private System.Windows.Forms.ColumnHeader Packed;
        private System.Windows.Forms.ColumnHeader Scanned;
        private Label txtName;
        
        private frmTimerMessage ofrmMessage;


        public frmScanning()
        {
            InitializeComponent();
            oOrder = new Scanning(base.CompanyID);
            oOrder1 = new Scanning(base.CompanyID);
        }
        
        
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.lbCompany = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.Label();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Signature.Windows.Forms.BoundListView();
            this.Teacher = new System.Windows.Forms.ColumnHeader();
            this.Student = new System.Windows.Forms.ColumnHeader();
            this.Packed = new System.Windows.Forms.ColumnHeader();
            this.Scanned = new System.Windows.Forms.ColumnHeader();
            this.txtBox = new System.Windows.Forms.Label();
            this.groupBox4 = new Signature.Windows.Forms.GroupBox();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEdit();
            this.txtPallets = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCompany);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(755, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 54);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lbCompany
            // 
            this.lbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompany.Location = new System.Drawing.Point(78, 22);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(33, 19);
            this.lbCompany.TabIndex = 13;
            this.lbCompany.Text = "F07";
            this.lbCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "Company:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtCustomerID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 54);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Info";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(187, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(532, 22);
            this.txtName.TabIndex = 15;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(90, 18);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(83, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Customer ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(99, 41);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(390, 21);
            this.txtStudent.TabIndex = 2;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(99, 17);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(390, 21);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(33, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Order ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.Controls.Add(this.txtBox);
            this.groupBox3.Controls.Add(this.txtStudent);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTeacher);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 491);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Orders Left";
            // 
            // Grid
            // 
            this.Grid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Teacher,
            this.Student,
            this.Packed,
            this.Scanned});
            this.Grid.FullRowSelect = true;
            this.Grid.HideSelection = false;
            this.Grid.LabelEdit = true;
            this.Grid.Location = new System.Drawing.Point(26, 79);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(694, 393);
            this.Grid.TabIndex = 10;
            this.Grid.Tag = "";
            this.Grid.UseCompatibleStateImageBehavior = false;
            this.Grid.View = System.Windows.Forms.View.Details;
            // 
            // Teacher
            // 
            this.Teacher.Text = "Teacher";
            this.Teacher.Width = 281;
            // 
            // Student
            // 
            this.Student.Text = "Student";
            this.Student.Width = 276;
            // 
            // Packed
            // 
            this.Packed.Text = "Packed";
            this.Packed.Width = 52;
            // 
            // Scanned
            // 
            this.Scanned.Text = "Scanned";
            // 
            // txtBox
            // 
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox.ForeColor = System.Drawing.Color.Red;
            this.txtBox.Location = new System.Drawing.Point(507, 22);
            this.txtBox.Name = "txtBox";
            this.txtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBox.Size = new System.Drawing.Size(201, 36);
            this.txtBox.TabIndex = 9;
            this.txtBox.Text = "Box X of Y";
            this.txtBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtOrderID);
            this.groupBox4.Controls.Add(this.txtPallets);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtEntryDate);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(753, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 491);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            this.txtOrderID.Location = new System.Drawing.Point(12, 100);
            this.txtOrderID.Name = "txtCustomerID";
            this.txtOrderID.Size = new System.Drawing.Size(106, 20);
            this.txtOrderID.TabIndex = 0;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPallets
            // 
            this.txtPallets.AllowDrop = true;
            this.txtPallets.Location = new System.Drawing.Point(30, 311);
            this.txtPallets.Name = "txtCustomerID";
            this.txtPallets.Size = new System.Drawing.Size(83, 20);
            this.txtPallets.TabIndex = 1;
            this.txtPallets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(36, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "No Pallets:";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance2;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(19, 410);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 28;
            this.txtEntryDate.Text = "//";
            this.txtEntryDate.Visible = false;
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(59, 565);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(0, 31);
            this.txtMessage.TabIndex = 4;
            // 
            // frmScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(883, 644);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmScanning";
            this.ShowInTaskbar = false;
            this.Text = "Scanning ";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScanning_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.txtMessage, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region  Events	
        
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            this.lbCompany.Text = this.CompanyID;
            this.txtStudent.Enabled = false;
            this.txtTeacher.Enabled = false;
            txtPallets.Enabled = false;
            this.txtCustomerID.Focus();

            oCustomer = new Customer(CompanyID);

            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            if (!Global.IsRunningOnMono())
            {
                myTimer.Interval = 2 * 1000;
                myTimer.Start();
            }
		}

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (oCustomer.ID != null)
            {
                myTimer.Stop();
                oOrder.LoadOrders();
                //MessageBox.Show(oCustomer.ID);
                Grid.DataSource = oOrder.ScanItems;
                Grid.DataBind();
                myTimer.Enabled = true;
            }
        }

        
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{


            #region txtCustomerID
            
            
            if (sender == txtCustomerID)
            {
                Boolean IsF2 = false;
                
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {
                        this.txtCustomerID.Text = oCustomer.ID;
                        this.txtTeacher.Focus();
                    }
                    else
                    {
                        this.txtCustomerID.Clear();
                        this.txtCustomerID.Focus();
                        return;
                    }
                    IsF2 = true;
                    this.txtName.Text = oCustomer.Name;
                    oOrder.CustomerID = txtCustomerID.Text;
                    
                    /*txtCustomerID.Enabled = false;
                    oOrder.LoadOrders();
                    Grid.DataSource = oOrder.ScanItems;
                    Grid.DataBind();
                    txtOrderID.Focus();
                    return;*/

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!this.get_customer())
                    {
                        this.txtCustomerID.Focus();
                        return;
                    }
                    //MessageBox.Show(oCustomer.Scanned +"-"+ oOrder.OrdersScanned.ToString() +"-"+oOrder.OrdersEntered.ToString());
                    
                    if ((oCustomer.Scanned  || oOrder.OrdersScanned == oOrder.OrdersEntered))
                    {
                        //MessageBox.Show("This is already Done");
                        txtCustomerID.Enabled = false;
                        txtPallets.Enabled = true;
                        txtPallets.Text = oCustomer.NumberPallets.ToString();
                        txtPallets.Focus();
                        return;
                    }

                    oOrder.CustomerID = txtCustomerID.Text;
                    if (oOrder.OrdersEntered == 0)
                    {
                        MessageBox.Show("This customer doesnt have any Order...");
                        txtCustomerID.Clear();
                        txtCustomerID.Focus();
                        return;
                    }
                    
                    oOrder.LoadOrders();
                    

                    txtCustomerID.Enabled = false;
                    oOrder.CustomerID = txtCustomerID.Text;
                    
                    Grid.DataSource = oOrder.ScanItems;
                    Grid.DataBind();
                    txtOrderID.Focus();
                    return;

                }

            }
            #endregion
            #region txtOrderID
            if (sender==txtOrderID)	
			{
                if (e.KeyCode == Keys.F12)
                {
                    Grid.Focus();
                    return;
                }
                
                if (e.KeyCode == Keys.F2)
                {
                    if (oOrder.View())
                        txtOrderID.Text = oOrder.ID;
                    return;
                }

                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    if (txtOrderID.Text.Trim() == "")
                    {
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }
                    if (txtCustomerID.Text != oOrder.CustomerID)
                    {
                        Global.playSimpleSound(1);
                        return;
                    }


                    txtOrderID.Text = Convert.ToUInt32(txtOrderID.Text).ToString();

                    if (oOrder.FindHeader(Convert.ToInt32(txtOrderID.Text)))
                    {
                        if (oOrder.BoxesPacked ==0)
                        {
                            ActiveRow(false);
                            Global.playSimpleSound(2);
                            txtMessage.Text = "Order Not Packed Yet";
                            txtMessage.ForeColor = Color.Red;

                            ShowMessage("Order Not Packed Yet", Color.Red);
                            
                            return;
                        }
                        if (oOrder.CustomerID != txtCustomerID.Text)
                            {
                                Global.playSimpleSound(3);
                                txtTeacher.Text = oOrder.Teacher;
                                txtStudent.Text = oOrder.Student;
                                txtMessage.Text = "Different School";
                                txtMessage.ForeColor = Color.Red;

                                ShowMessage("Different School", Color.Red);
                                return;
                            }

                         if(oOrder.BoxesPacked > 0 && oOrder.BoxesPacked==oOrder.BoxesScanned) //  (oOrder.Packed)
                            {
                                //oOrder.UpdateOrderScanned(oOrder.ID);
                                //oOrder.LoadOrders();
                                Global.playSimpleSound(1);
                                txtTeacher.Text = oOrder.Teacher;
                                txtStudent.Text = oOrder.Student;
                                txtBox.Text = String.Format("Boxes {0}", oOrder.BoxesScanned);
                                txtMessage.Text = "Order Already Scanned";
                                txtMessage.ForeColor = Color.Red;

                                ShowMessage("Order Already Scanned", Color.Red);
                                return;
                                
                            }
                        if (oOrder.BoxesPacked < oOrder.BoxesScanned)
                        {
                            ActiveRow(false);
                            Global.playSimpleSound(2);
                            ShowMessage("Something wrong, Modify number of boxes!!! ", Color.Red);
                            return;
                        }
                        Boolean IsPacked = false;
                        if (oOrder.BoxesPacked == oOrder.BoxesScanned)
                        {
                            
                            Global.playSimpleSound(2);
                            ShowMessage("Order Already Packed ", Color.Red);
                            IsPacked = true;
                        }

                        
                        txtTeacher.Text = oOrder.Teacher;
                        txtStudent.Text = oOrder.Student;
                        
                        if (!IsPacked)
                            oOrder.BoxesScanned += 1;

                        txtBox.Text = String.Format("Box {0} of {1}", oOrder.BoxesScanned , oOrder.BoxesPacked);
                        oOrder.UpdateScanned(oOrder.ID, oOrder.BoxesScanned);

                        if (oOrder.BoxesScanned == oOrder.BoxesPacked)
                        {
                            //oOrder.ScanItems.Remove(txtOrderID.Text);
                            oOrder.UpdateOrderScanned(oOrder.ID);
                            ActiveRow(true);

                        }
                        else
                        {
                            ActiveRow(false);
                            Grid.DataBind();
                        }
                        
                        if (!IsPacked)
                        {
                            txtMessage.Text = "GOOD!";
                            txtMessage.ForeColor = Color.Green; 
                            ShowMessage(txtBox.Text, Color.Green);
                        }
                        
                        if (oOrder.OrdersScanned == oOrder.OrdersEntered) //oOrder.ScanItems.Count == 0)
                        {
                                txtPallets.Enabled = true;
                                txtPallets.Focus();
                                return;
                        }
                        this.Focus();
                        txtOrderID.Focus();
                        txtOrderID.Clear();
                        return;

                    } 
                    else
                        {
                            Global.playSimpleSound(0);
                            
                        }
                        txtOrderID.Clear();
                        return;
             	}

            }
            #endregion
            #region txtPallets
            if (sender==txtPallets)	
			{
				
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtPallets.Text == "")
                    {
                        txtPallets.Focus();
                        return;
                    }
                    if (Convert.ToInt32(txtPallets.Text) > 100)
                    {
                        txtPallets.Clear();
                        txtPallets.Focus();
                        return;
                    }

                    //oOrder.BoxesScanned = Convert.ToInt16(txtPallets.Text);
                    //oOrder.UpdatePacked();

                    oOrder.NumberPallets = Convert.ToInt32(txtPallets.Text);
                    oOrder.UpdateCustomerScanned();
                    PrinPalletLabels();
                    Clear();
                    txtCustomerID.Enabled = true;
                    txtPallets.Enabled = false;
                    txtOrderID.Enabled = false;
                    txtCustomerID.Focus();
                    this.Close();
                    return;
                }					

            }
            #endregion
            #region txtGrid
             if (sender==this.Grid)	
			{
                
                 if (e.KeyValue >= 48 && e.KeyValue <= 57) 
                 {
                     txtOrderID.Focus(); 
                     //SendKeys.Send("{TAB}");
    
        //             SendKeys.Send(c.ToString());
                 }

                if (e.KeyCode == Keys.F12)
                {
                    txtOrderID.Focus();
                    return;
                }
                 if (e.KeyCode.ToString()=="F8")
				{
					
					return;
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                {
                    
                    //return;
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
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					//this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    //this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    break;
                case Keys.PageDown:
                    
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        #endregion


        private void ShowMessage(String Message, Color _Color)
        {
            if (_Color == Color.Green)
                Global.playSimpleSound(6);

            ofrmMessage = new frmTimerMessage();
            ofrmMessage.Message.Text = Message;
            ofrmMessage.MsgColor = _Color;
            ofrmMessage.Show();
            this.Focus();
        }

        private void PrinPalletLabels()
        {   
            if (oCustomer.Find(txtCustomerID.Text))
            {
                if (!Global.IsRunningOnMono())
                {
                    frmViewReport oViewReport = new frmViewReport();
                    oViewReport.Parameter_1 = oCustomer.NumberPallets;
                    oViewReport.SetReport((int)Report.PalletLabels, CompanyID, oCustomer.ID, false);
                }
                else
                {
                    PrintSample oSample = new PrintSample();
                    oSample.RunSample();
                }
            }
            
        }

        private void ActiveRow(bool DeleteIt)
        {
            Grid.Select();

            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (ListViewItem item in Grid.Items)
            {
                if (item.Text == oOrder.ID)
                {
                    //Grid.ActiveRow = aUGRow;
                    item.SubItems[4].Text = oOrder.BoxesScanned.ToString();

                    if (DeleteIt)
                    {
                        //Grid.ActiveRow.Delete();
                        item.BackColor = System.Drawing.Color.Gray;


                        //listView.DataBind();

                    }
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    if (!DeleteIt)
                    {
                        //  item.BackColor = System.Drawing.Color.WhiteSmoke;

                    }
                    item.Focused = true;
                    item.Selected = true;
                    break;
                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
            txtOrderID.Focus();
        }

       
        #region  Methods
        private bool get_customer()
        {


            if (this.txtCustomerID.Text == "")
                return false;

            oOrder.CustomerID = this.txtCustomerID.Text;
            if (!oCustomer.Find(txtCustomerID.Text))
            {
                this.txtCustomerID.Clear();
                this.txtCustomerID.Focus();
                this.txtName.Text = oCustomer.Name;
                return false;
            }

            this.txtName.Text = oCustomer.Name;
            return true;

        }
        public bool ShowOrder()
        {
            this.ShowHeader();
            return true;
        }
        public void Clear()
        {
            txtName.Text = "";
            txtOrderID.Clear();
            txtTeacher.Clear();
            txtStudent.Clear();
          //  oOrder.ScanItems.Clear();
            txtOrderID.Clear();
          //  Grid.DataBind();
            txtMessage.Text = "";          
            txtEntryDate.Text = DateTime.Now.Date.ToString();
        }
        private bool ShowHeader()
        {
            //Header
            //this.Clear();

            txtName.Text = oCustomer.Name;
            lbCompany.Text = CompanyID;
            return true;
        }
        
        public void Save()
        {
            oOrder.CompanyID    = CompanyID;
            oOrder.CustomerID   = txtOrderID.Text;
            txtStudent.Clear();
            
        }
        
	
		#endregion

        private void frmScanning_FormClosed(object sender, FormClosedEventArgs e)
        {
            myTimer.Dispose();
        }

        private void txtOrderID_Enter(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
            
        }

        private void Grid_Enter(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
        }
	}
}
