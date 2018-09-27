using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmUser : frmBase
	{
		#region declarations		
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtUser;
        private Label label3;
        
        #endregion


        Rep oRep;
        User oUser;
        private Signature.Windows.Forms.MaskedEditNumeric txtRepID;
        private Label txtPnoneExt;
        private Signature.Windows.Forms.MaskedEdit txtPassword;
        private Label label1;
        private Signature.Windows.Forms.MaskedEditNumeric txtUserID;
        private Label label2;
        private Signature.Windows.Forms.Button butNew;
        private Infragistics.Win.Misc.UltraLabel txtName;
        
        
        public frmUser()
		{
			InitializeComponent();
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.butNew = new Signature.Windows.Forms.Button();
            this.txtUserID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtRepID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPnoneExt = new System.Windows.Forms.Label();
            this.txtUser = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 220);
            this.txtStatus.Size = new System.Drawing.Size(452, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.butNew);
            this.ultraGroupBox1.Controls.Add(this.txtUserID);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtPassword);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtRepID);
            this.ultraGroupBox1.Controls.Add(this.txtPnoneExt);
            this.ultraGroupBox1.Controls.Add(this.txtUser);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(452, 220);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // butNew
            // 
            this.butNew.AllowDrop = true;
            this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butNew.BackColor = System.Drawing.Color.LightSteelBlue;
            this.butNew.ForeColor = System.Drawing.Color.Black;
            this.butNew.Location = new System.Drawing.Point(300, 172);
            this.butNew.Name = "ultraButton1";
            this.butNew.Size = new System.Drawing.Size(113, 25);
            this.butNew.TabIndex = 302;
            this.butNew.Text = "&New";
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.AllowDrop = true;
            appearance1.TextHAlignAsString = "Right";
            this.txtUserID.Appearance = appearance1;
            this.txtUserID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUserID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUserID.FormatString = "###,###.##";
            this.txtUserID.InputMask = "nnnnnnnnn";
            this.txtUserID.Location = new System.Drawing.Point(99, 39);
            this.txtUserID.Name = "txtAmountDue";
            this.txtUserID.Size = new System.Drawing.Size(64, 20);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.Text = "0";
            this.txtUserID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 301;
            this.label2.Text = "ID:";
            // 
            // txtPassword
            // 
            this.txtPassword.AllowDrop = true;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(99, 112);
            this.txtPassword.Name = "txtCustomerID";
            this.txtPassword.Size = new System.Drawing.Size(80, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(23, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 299;
            this.label1.Text = "Password :";
            // 
            // txtName
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance2;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(169, 151);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 20);
            this.txtName.TabIndex = 297;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            appearance3.TextHAlignAsString = "Right";
            this.txtRepID.Appearance = appearance3;
            this.txtRepID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRepID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRepID.FormatString = "###,###.##";
            this.txtRepID.InputMask = "nnnnnnnnn";
            this.txtRepID.Location = new System.Drawing.Point(99, 149);
            this.txtRepID.Name = "txtAmountDue";
            this.txtRepID.Size = new System.Drawing.Size(64, 20);
            this.txtRepID.TabIndex = 3;
            this.txtRepID.Text = "0";
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPnoneExt
            // 
            this.txtPnoneExt.BackColor = System.Drawing.Color.Transparent;
            this.txtPnoneExt.Location = new System.Drawing.Point(23, 149);
            this.txtPnoneExt.Name = "txtPnoneExt";
            this.txtPnoneExt.Size = new System.Drawing.Size(62, 20);
            this.txtPnoneExt.TabIndex = 296;
            this.txtPnoneExt.Text = "Rep ID:";
            // 
            // txtUser
            // 
            this.txtUser.AllowDrop = true;
            this.txtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Location = new System.Drawing.Point(99, 75);
            this.txtUser.Name = "txtCustomerID";
            this.txtUser.Size = new System.Drawing.Size(80, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(23, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "User :";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(452, 249);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUser";
            this.ShowInTaskbar = false;
            this.Text = "User Maintenance";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
    	private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oRep = new Rep(this.CompanyID);
            oUser = new User();

            Activate(false);
            this.txtUserID.Focus();
		}

       
        
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtUserID
            if (sender == txtUserID)
            {
                if (e.KeyCode == Keys.F3)
                {
                    return;
                }


                if (e.KeyCode.ToString() == "F2")
                {
                    if (oUser.View())
                    {
                        txtUserID.Text = oUser.ID.ToString();
                        txtUser.Text = oUser.UserID;
                        txtPassword.Text = oUser.Password;
                        txtRepID.Text = oUser.RepID.ToString();
                        if (oRep.Find(oUser.RepID))
                            txtName.Text = oRep.Name;
                        Activate(true);
                        txtUser.Focus();
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtUser.Text.Trim().Length == 0)
                    {
                        Clear();

                    }

                    if (oUser.Find(txtUser.Text, ""))
                    {

                        txtUser.Text = oUser.UserID;
                        txtPassword.Text = oUser.Password;
                        txtRepID.Text = oUser.RepID.ToString();
                        if (oRep.Find(oUser.RepID))
                            txtName.Text = oRep.Name;
                        Activate(true);
                        txtUser.Focus();
                        return;


                    }
                    else
                    {
                        Clear();

                    }

                }

                
            }
            #endregion
            #region txtPassword
            if (sender == txtPassword)
            {
                if (e.KeyCode == Keys.F3)
                {
                    return;
                }



                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtUser.Text.Trim().Length == 0)
                    {
                        Clear();
                        
                    }

                    if (oUser.Find(txtUser.Text,""))
                    {

                        txtUser.Text = oUser.UserID;
                        txtRepID.Text = oUser.RepID.ToString();
                        if (oRep.Find(oUser.RepID))
                            txtName.Text = oRep.Name;
                        txtRepID.Focus();
                        return;


                    }
                    else
                    {
                        Clear();

                    }

                }

            }
            #endregion
            #region txtRepID
            if (sender==txtRepID)	
			{

				if (e.KeyCode.ToString()=="F2")
				{
                    if (oRep.ViewByID())
                    {
                        txtRepID.Text = oRep.ID.ToString();
                        txtName.Text = oRep.Name;
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtRepID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtUser.Focus();
                    }
                    
                    if (oRep.Find(txtRepID.Text))
                    {
                        txtName.Text = oRep.Name;
                        
                        return;
                    
                    } else
                    {
                        Clear();
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
                    this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    {
                        if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            MessageBox.Show("Operation Cancelled");
                            return;
                        }
                        else
                        {
                            oUser.Delete();
                            Clear();
                            txtUser.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    Clear();
                    txtUserID.Focus();
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        #endregion
        
        #region  Methods
        public void Save()
        {
            oUser.RepID = Convert.ToInt32(txtRepID.Text);
            oUser.UserID = txtUser.Text;
            oUser.Password = txtPassword.Text;

            oUser.Save();
            Clear();
            txtUserID.Clear();
            txtUserID.Enabled = true;
            txtUserID.Focus();
            Activate(false);
        }
        
        public bool ShowBox()
        {
            Clear();
            return true;
        }
        public void Clear()
        {
            txtRepID.Clear();
            txtName.Text = "";
            txtUserID.Clear();
            txtPassword.Clear();
            txtUser.Text = "";
        }
        public void Activate(Boolean YesNo)
        {
            txtUser.Enabled = YesNo;
            txtPassword.Enabled = YesNo;
            txtRepID.Enabled = YesNo;
        }
		#endregion

        private void butNew_Click(object sender, EventArgs e)
        {
            txtUserID.Enabled = false;
            Clear();
            Activate(true);
            txtUser.Focus();
        }

	}
}
