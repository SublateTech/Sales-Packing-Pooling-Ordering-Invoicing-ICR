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
	public sealed class frmVoicemail : frmBase
	{
		#region declarations		
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtVoicemailID;
        private Label label3;
        
        #endregion


        Rep oRep;
        Voicemail oVoicemail;
        private Signature.Windows.Forms.MaskedEditNumeric txtRepID;
        private Label txtPnoneExt;
        private Infragistics.Win.Misc.UltraLabel txtName;
        
        
        public frmVoicemail()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoicemail));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtRepID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtPnoneExt = new System.Windows.Forms.Label();
            this.txtVoicemailID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 104);
            this.txtStatus.Size = new System.Drawing.Size(445, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtRepID);
            this.ultraGroupBox1.Controls.Add(this.txtPnoneExt);
            this.ultraGroupBox1.Controls.Add(this.txtVoicemailID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(445, 104);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance1;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(215, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 20);
            this.txtName.TabIndex = 297;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            appearance2.TextHAlignAsString = "Right";
            this.txtRepID.Appearance = appearance2;
            this.txtRepID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRepID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRepID.FormatString = "###,###.##";
            this.txtRepID.InputMask = "nnnnnnnnn";
            this.txtRepID.Location = new System.Drawing.Point(130, 70);
            this.txtRepID.Name = "txtAmountDue";
            this.txtRepID.Size = new System.Drawing.Size(64, 20);
            this.txtRepID.TabIndex = 295;
            this.txtRepID.Text = "0";
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtPnoneExt
            // 
            this.txtPnoneExt.BackColor = System.Drawing.Color.Transparent;
            this.txtPnoneExt.Location = new System.Drawing.Point(42, 70);
            this.txtPnoneExt.Name = "txtPnoneExt";
            this.txtPnoneExt.Size = new System.Drawing.Size(62, 20);
            this.txtPnoneExt.TabIndex = 296;
            this.txtPnoneExt.Text = "Rep ID:";
            // 
            // txtVoicemailID
            // 
            this.txtVoicemailID.AllowDrop = true;
            this.txtVoicemailID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtVoicemailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoicemailID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVoicemailID.Location = new System.Drawing.Point(130, 26);
            this.txtVoicemailID.Name = "txtCustomerID";
            this.txtVoicemailID.Size = new System.Drawing.Size(80, 20);
            this.txtVoicemailID.TabIndex = 20;
            this.txtVoicemailID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Voicemail  ID:";
            // 
            // frmVoicemail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 133);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVoicemail";
            this.ShowInTaskbar = false;
            this.Text = "Voicemail Maintenance";
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
            oVoicemail = new Voicemail(this.CompanyID);
            
            this.txtVoicemailID.Focus();
		}

       
        
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtVoicemail
            if (sender == txtVoicemailID)
            {
                if (e.KeyCode == Keys.F3)
                {
                    return;
                }


                if (e.KeyCode.ToString() == "F2")
                {
                    if (oVoicemail.View())
                    {
                        txtVoicemailID.Text = oVoicemail.ID;
                        txtRepID.Text = oVoicemail.RepID.ToString();
                        if (oRep.Find(oVoicemail.RepID))
                            txtName.Text = oRep.Name;
                        txtRepID.Focus();
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtVoicemailID.Text.Trim().Length == 0)
                    {
                        Clear();
                        
                    }

                    if (oVoicemail.Find(txtVoicemailID.Text))
                    {

                        txtVoicemailID.Text = oVoicemail.ID;
                        txtRepID.Text = oVoicemail.RepID.ToString();
                        if (oRep.Find(oVoicemail.RepID))
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
                        txtVoicemailID.Focus();
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
                            oVoicemail.Delete();
                            Clear();
                            txtVoicemailID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.PageDown:
                    Save();
                    Clear();
                    txtVoicemailID.Focus();
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
            oVoicemail.RepID = Convert.ToInt32(txtRepID.Text);
            oVoicemail.CompanyID = this.CompanyID;
            oVoicemail.ID = txtVoicemailID.Text;
            oVoicemail.Save();
            Clear();
            txtVoicemailID.Clear();
            txtVoicemailID.Focus();
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
        }
      
		#endregion

        

	}
}
