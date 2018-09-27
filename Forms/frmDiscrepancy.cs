using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;
using System.IO;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmDiscrepancy : frmBase
	{
        #region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private Signature.Windows.Forms.GroupBox groupBox3;
		
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.Button bNext;
        private Signature.Windows.Forms.Button bEdit;
        private Label lbDiff;
        private Signature.Windows.Forms.MaskedEdit txtText;
        private Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculatorDropDown ultraCalculatorDropDown1;
        private Label label3;
        private Signature.Windows.Forms.Button bPrint;
        private CheckBox txtSchoolUseOnly;
        private Signature.Windows.Forms.Button bPrintImage;         //
		#endregion

        Discrepancy.DiscrepancyActivity curActivity = Discrepancy.DiscrepancyActivity.NoAction;

        Discrepancy oOrder;
        
        public frmDiscrepancy()
		{
			InitializeComponent();
            oOrder = new Discrepancy(base.CompanyID);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscrepancy));
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtSchoolUseOnly = new System.Windows.Forms.CheckBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.bPrint = new Signature.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ultraCalculatorDropDown1 = new Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculatorDropDown();
            this.txtText = new Signature.Windows.Forms.MaskedEdit();
            this.lbDiff = new System.Windows.Forms.Label();
            this.bNext = new Signature.Windows.Forms.Button();
            this.bEdit = new Signature.Windows.Forms.Button();
            this.bPrintImage = new Signature.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalculatorDropDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 565);
            this.txtStatus.Size = new System.Drawing.Size(792, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtSchoolUseOnly);
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
            this.groupBox2.Size = new System.Drawing.Size(775, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = " Order Header ";
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtSchoolUseOnly
            // 
            this.txtSchoolUseOnly.AutoSize = true;
            this.txtSchoolUseOnly.Location = new System.Drawing.Point(508, 108);
            this.txtSchoolUseOnly.Name = "txtSchoolUseOnly";
            this.txtSchoolUseOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSchoolUseOnly.Size = new System.Drawing.Size(90, 17);
            this.txtSchoolUseOnly.TabIndex = 264;
            this.txtSchoolUseOnly.Text = "Use Only Box";
            this.txtSchoolUseOnly.UseVisualStyleBackColor = true;
            this.txtSchoolUseOnly.CheckedChanged += new System.EventHandler(this.txtSchoolUseOnly_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance2.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance2;
            this.txtName.Location = new System.Drawing.Point(175, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(423, 19);
            this.txtName.TabIndex = 12;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Location = new System.Drawing.Point(106, 105);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(320, 20);
            this.txtStudent.TabIndex = 3;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.Location = new System.Drawing.Point(106, 79);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(320, 20);
            this.txtTeacher.TabIndex = 2;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(106, 35);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(44, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance3;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.bPrint);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.ultraCalculatorDropDown1);
            this.groupBox3.Controls.Add(this.txtText);
            this.groupBox3.Controls.Add(this.lbDiff);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 398);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Text = "Text";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // bPrint
            // 
            this.bPrint.AllowDrop = true;
            this.bPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bPrint.ForeColor = System.Drawing.Color.Black;
            this.bPrint.Location = new System.Drawing.Point(669, 360);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(57, 23);
            this.bPrint.TabIndex = 14;
            this.bPrint.Text = "Print";
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(401, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Calculator:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraCalculatorDropDown1
            // 
            this.ultraCalculatorDropDown1.Location = new System.Drawing.Point(538, 22);
            this.ultraCalculatorDropDown1.Name = "ultraCalculatorDropDown1";
            this.ultraCalculatorDropDown1.Size = new System.Drawing.Size(231, 21);
            this.ultraCalculatorDropDown1.TabIndex = 18;
            // 
            // txtText
            // 
            this.txtText.AllowDrop = true;
            this.txtText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(47, 57);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(679, 297);
            this.txtText.TabIndex = 17;
            this.txtText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.txtText.Enter += new System.EventHandler(this.txtText_Enter);
            // 
            // lbDiff
            // 
            this.lbDiff.AutoEllipsis = true;
            this.lbDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiff.Location = new System.Drawing.Point(292, 22);
            this.lbDiff.Name = "lbDiff";
            this.lbDiff.Size = new System.Drawing.Size(33, 19);
            this.lbDiff.TabIndex = 15;
            this.lbDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDiff.Visible = false;
            // 
            // bNext
            // 
            this.bNext.AllowDrop = true;
            this.bNext.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bNext.ForeColor = System.Drawing.Color.Black;
            this.bNext.Location = new System.Drawing.Point(646, 109);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(57, 23);
            this.bNext.TabIndex = 12;
            this.bNext.Text = "Next";
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bEdit
            // 
            this.bEdit.AllowDrop = true;
            this.bEdit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bEdit.ForeColor = System.Drawing.Color.Black;
            this.bEdit.Location = new System.Drawing.Point(713, 110);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(56, 23);
            this.bEdit.TabIndex = 13;
            this.bEdit.Text = "Edit";
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bPrintImage
            // 
            this.bPrintImage.AllowDrop = true;
            this.bPrintImage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bPrintImage.ForeColor = System.Drawing.Color.Black;
            this.bPrintImage.Location = new System.Drawing.Point(689, 39);
            this.bPrintImage.Name = "bPrint";
            this.bPrintImage.Size = new System.Drawing.Size(78, 21);
            this.bPrintImage.TabIndex = 15;
            this.bPrintImage.Text = "View Image";
            this.bPrintImage.Click += new System.EventHandler(this.bPrintImage_Click_1);
            // 
            // frmDiscrepancy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(792, 594);
            this.Controls.Add(this.bPrintImage);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiscrepancy";
            this.ShowInTaskbar = false;
            this.Text = "Discrepancy";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.bNext, 0);
            this.Controls.SetChildIndex(this.bEdit, 0);
            this.Controls.SetChildIndex(this.bPrintImage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalculatorDropDown1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
      
		
		private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
        private void bNext_Click(object sender, EventArgs e)
        {
            if (curActivity == Discrepancy.DiscrepancyActivity.Busy)
            {
                oOrder.SetStatus(Discrepancy.DiscrepancyActivity.NoAction);
            }
            if (oOrder.GetNextOrder(txtCustomerID.Text) != 0)
            {
                oOrder.Find(oOrder.GetNextOrder(txtCustomerID.Text));
                txtStudent.Text = oOrder.Student;
                txtTeacher.Text = oOrder.Teacher;

                if (oOrder.FindText(Convert.ToInt32(oOrder.ID)))
                    txtText.Text = oOrder.LetterText;
                else
                {
                    txtText.Text = "";
                    lbDiff.Text = oOrder.Diff.ToString();
                }

                if (oOrder.oImage.OrderID != 0)
                    bPrintImage.Visible = true;
                else
                    bPrintImage.Visible = false;

//                oOrder.SetStatus(Discrepancy.DiscrepancyActivity.Busy);
                //groupBox3.Focus();
                //txtText.Text = "";
                txtText.Focus();
            }
            else
            {
                MessageBox.Show("Discrepancy done with this school");
                txtCustomerID.Focus();
            }

        }

        
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            this.txtCustomerID.Focus();

            this.bPrintImage.Visible = false;
            
		}
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtCustomerID
            if (sender==txtCustomerID)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    if (oOrder.oCustomer.View())
                    {
                        this.txtCustomerID.Text = oOrder.oCustomer.ID;
                        this.txtSchoolUseOnly.Checked = oOrder.oCustomer.SchoolUseOnly;
                        this.txtTeacher.Focus();
                     }
                    this.txtName.Text = oOrder.oCustomer.Name;
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!this.get_customer())
					{
						this.txtCustomerID.Focus();
						return;
					}

				}

            }
            #endregion
            #region txtTeacher
            if (sender==txtTeacher)	
			{
                if (e.KeyCode.ToString() == "F2")
                {

                    oOrder.oTeacher.View(txtCustomerID.Text);

                    if (oOrder.oTeacher.ID != "")
                    {
                        this.txtTeacher.Text = oOrder.oTeacher.ID;
                        this.txtStudent.Focus();
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    oOrder.oTeacher.ID = txtTeacher.Text;

                    if (!oOrder.oTeacher.Find(txtCustomerID.Text, txtTeacher.Text))
                    {
                        this.txtTeacher.Clear();
                        return;
                    }
                    else
                    {
                        this.txtTeacher.Text = oOrder.oTeacher.ID;
                        this.txtStudent.Focus();
                        return;
                    }


                }
                if (e.KeyCode == Keys.PageDown)
                {
                    oOrder.oTeacher.ID = txtTeacher.Text;
                    bNext_Click(null, null);
                    txtText.Focus();
                    return;

                }

            }
            #endregion
            #region txtStudent
            if (sender==txtStudent)	
			{
	    		if (e.KeyCode.ToString()=="F2")
				{
                    
                    oOrder.oStudent.View(txtCustomerID.Text, txtTeacher.Text);
                    
                    if (oOrder.oStudent.ID != "")
                    {
                        txtTeacher.Text = oOrder.oStudent.Teacher;
                        this.txtStudent.Text = oOrder.oStudent.ID;
                        this.oOrder.oCustomer.Find(this.txtCustomerID.Text);
                        oOrder.CustomerID = this.txtCustomerID.Text;
                        txtName.Text = oOrder.oCustomer.Name;
                        //get(this.txtTeacher.Text, this.txtStudent.Text);
                        if (!oOrder.Find(this.txtTeacher.Text, this.txtStudent.Text))
                            MessageBox.Show("This Order doesn't exist");

                        if (oOrder.oImage.OrderID != 0)
                            bPrintImage.Visible = true;
                        else
                            bPrintImage.Visible = false;

                        if (oOrder.FindText(Convert.ToInt32(oOrder.ID)))
                            txtText.Text = oOrder.LetterText;
                        else
                        {
                            txtText.Text = "";
                            lbDiff.Text = oOrder.Diff.ToString();
                        }
                        
                        this.txtText.Focus();
                    }

                    return;
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                       // oOrder.oStudent.ID = txtStudent.Text;

                        if (oOrder.Student != this.txtStudent.Text)
                        {

                            this.txtStudent.Text = oOrder.oStudent.ID;
                            this.txtStudent.Text = oOrder.oStudent.ID;
                            if (!oOrder.Find(this.txtTeacher.Text, this.txtStudent.Text))
                                MessageBox.Show("This Order doesn't exist");
                            else
                            {
                                if (oOrder.oImage.OrderID != 0)
                                    bPrintImage.Visible = true;
                                else
                                    bPrintImage.Visible = false;

                                txtText.Text = "";
                                lbDiff.Text = oOrder.Diff.ToString();
                            }

                            if (oOrder.FindText(Convert.ToInt32(oOrder.ID)))
                                txtText.Text = oOrder.LetterText;
                        } 
                        this.txtText.Focus();

                        return;
                    
                }
                if (e.KeyCode == Keys.PageDown)
                {
                    oOrder.oTeacher.ID = txtTeacher.Text;
                    bNext_Click(null, null);
                    txtText.Focus();
                    
                    return;

                }

            }
            #endregion
            #region txtText
            if (sender == txtText)
            {
                if (e.KeyCode.ToString() == "F8")
                {
                    bEdit_Click(null, null);
                    
                    return;
                    
                }

                if (e.KeyCode == Keys.F2)
                {
                    frmDiscrepancyOptions frmOptions = new frmDiscrepancyOptions();
                    frmOptions.ShowDialog();
                    txtText.Text += frmOptions.sSelectedID;
                    return;

                }

                if (e.KeyCode == Keys.PageDown)
                {
                    if (txtStudent.Text == "")
                        return;
                    
                    if (MessageBox.Show("Done with this order ?", "Discrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        if (txtText.Text == null)
                        {
                            MessageBox.Show("Warning! This discrepancy has no text...");

                        }
                        return ;
                    }
                    else
                    {

                        this.Save();
                        txtText.Text = "";
                        txtStudent.Clear();
                        txtStudent.Focus();
                        return;
                    }
                    

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
                    if (sender != txtText)
					    this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
                case Keys.Down:
                    {
                        if (sender != txtText)
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                    }
                case Keys.Up:
                    {
                     if (sender != txtText)
                        this.SelectNextControl(this.ActiveControl, false, true, true, true);
                        break;
                    }
                case Keys.F3:
                    //deleteOrder();
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

        #region  Methods

        private void Save()
        {
            oOrder.Student = txtStudent.Text;
            oOrder.Teacher = txtTeacher.Text;
            oOrder.LetterText = txtText.Text;
            oOrder.Save();
            oOrder.UpdateDiscrepancy();
        }
		
        private bool get_customer()
		{
			
            
            if (this.txtCustomerID.Text=="")
				return false;

            oOrder.CustomerID = this.txtCustomerID.Text;
            if (!oOrder.oCustomer.Find(oOrder.CustomerID)) 
            
			{
				this.txtCustomerID.Clear();
				this.txtCustomerID.Focus();
                this.txtName.Text = oOrder.oCustomer.Name;
                this.txtSchoolUseOnly.Checked = oOrder.oCustomer.SchoolUseOnly;
				return false;
			}
			
            this.txtName.Text = oOrder.oCustomer.Name;
			return true;
		
		}
     
        public void Clear()
        {
            
            
        }
		#endregion

        private void bEdit_Click(object sender, EventArgs e)
        {
            oOrder.Student = txtStudent.Text;
            oOrder.Teacher = txtTeacher.Text;
            
            frmOrder ofrmOrder = new frmOrder(ref oOrder);
            ofrmOrder._OrderProcess = OrderProcess.Discrepancy;
            ofrmOrder.ShowDialog();
            oOrder.Find(Convert.ToInt32(oOrder.ID));
            txtText.Focus();
            return;
        }

        private void txtText_Enter(object sender, EventArgs e)
        {
            if (txtStudent.Text != oOrder.Student)
                txtStudent.Focus();

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            this.Save();
            oOrder.oCustomer.PrintDiscrepancyLetters(Convert.ToInt32(oOrder.ID));
        }

        private void txtSchoolUseOnly_CheckedChanged(object sender, EventArgs e)
        {
            oOrder.oCustomer.SchoolUseOnly = ((CheckBox) sender).Checked;
        }

        private void bPrintImage_Click_1(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;
            this.Left = screens[0].Bounds.Width - this.Width - 20;

            //MessageBox.Show(oOrder.oImage.FilePath);
            oOrder.oImage.FileType = "JPEG";
            if (!File.Exists(oOrder.oImage.FilePath))
            {
                oOrder.oImage.FileType = "TIFF";
            }
            Global.ClosePhotoGallery(oOrder.oImage.FilePath);
            //System.Diagnostics.Process.Start(@"C:\Program Files\Windows Photo Gallery\WindowsPhotoGallery.exe ",oOrder.oImage.FilePath);
            System.Diagnostics.Process.Start(oOrder.oImage.FilePath, "");
        }

	}
}
