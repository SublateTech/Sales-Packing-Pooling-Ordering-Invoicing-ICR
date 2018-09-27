using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PegasusImaging.WinForms.TwainPro5;
using System.IO;
using Signature.Classes;
using System.Runtime.InteropServices;

namespace Signature.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmOrderICRAdquire : frmBase
    {
        private IContainer components;

        
       
        #region declrations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;


        private PegasusImaging.WinForms.ImagXpress9.ImagXpress imagXpress1;
        public PegasusImaging.WinForms.ImagXpress9.ImageXView OutputImg;
        private PegasusImaging.WinForms.TwainPro5.TwainDevice twainDevice;
      //  private PegasusImaging.WinForms.TwainPro5.Capability capability;
      //  private PegasusImaging.WinForms.TwainPro5.CapabilityContainer capcontainer;

        #endregion

        
        private int picnumber = 0;
        
        ScannedCustomer oCustomer;
        ScannedTeacher oTeacher;
        Signature.Classes.ScannedImage oImage;
        private ToolStrip tStrip;
        private PegasusImaging.WinForms.TwainPro5.TwainPro twainPro1;
        private ToolStripButton toolStripButton2;
        

        public frmOrderICRAdquire()
        {
            InitializeComponent();

            oCustomer   = new ScannedCustomer(Global.CurrrentCompany);
            oTeacher    = new ScannedTeacher(Global.CurrrentCompany);
            oImage      = new Signature.Classes.ScannedImage();
            imagXpress1 = new PegasusImaging.WinForms.ImagXpress9.ImagXpress(components);
            OutputImg = new PegasusImaging.WinForms.ImagXpress9.ImageXView(imagXpress1);

        }  //Constructor



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (twainDevice != null)
                {
                    twainDevice.Dispose();
                    twainDevice = null;
                }
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderICRAdquire));
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.twainPro1 = new PegasusImaging.WinForms.TwainPro5.TwainPro(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 157);
            this.txtStatus.Size = new System.Drawing.Size(577, 29);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            appearance2.AlphaLevel = ((short)(95));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance2;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.txtName);
            this.ultraGroupBox2.Controls.Add(this.txtTeacher);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.label1);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 40);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(552, 106);
            this.ultraGroupBox2.TabIndex = 43;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance1;
            this.txtName.Location = new System.Drawing.Point(177, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(357, 29);
            this.txtName.TabIndex = 19;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(110, 57);
            this.txtTeacher.MaxLength = 30;
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(424, 26);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(110, 24);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(37, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.tStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Padding = new System.Windows.Forms.Padding(160, 0, 0, 0);
            this.tStrip.Size = new System.Drawing.Size(577, 25);
            this.tStrip.TabIndex = 52;
            this.tStrip.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(94, 22);
            this.toolStripButton2.Text = "Adquire Images";
            this.toolStripButton2.Click += new System.EventHandler(this.txtAdquire_Click);
            // 
            // frmOrderICRAdquire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 186);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.ultraGroupBox2);
            this.MinimizeBox = false;
            this.Name = "frmOrderICRAdquire";
            this.Text = "Adquire Images";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrderICRAdquire_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            this.tStrip.ResumeLayout(false);
            this.tStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        
        #endregion

        #region Events
        private void txtAdquire_Click(object sender, EventArgs e)
        {
            if (oTeacher.Find(txtTeacher.Text))
            {
                
                if (oTeacher.Scanned)
                {
                    if ((MessageBox.Show("Add more images?", "Add Forms...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                    {
                        txtTeacher.Clear();
                        return;
                    }
                }
                
                try
                {
                 
                    picnumber = 0;
                    twainDevice.ShowUserInterface = false;
                    twainDevice.StartSession();
                    twainDevice.CloseSession();
                 
                    if (picnumber > 0)
                    {
                        oCustomer.Teachers[oCustomer.Teachers.Index].Scanned = true;

                        oTeacher.Scanned = true;
                        oTeacher.UpdateStatus();
                        if (this.SetNextTeacher())
                        {
                            txtTeacher.Text = oTeacher.Name;
                        }
                        else
                        {
                            txtTeacher.Clear();
                            txtTeacher.Focus();
                        }

                    }
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    GetError();
                }    
            }
            else
            {
               MessageBox.Show("This teacher doesn't exist");
            }

        }
        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {

            #region txtCustomerID
            if (sender == txtCustomerID)
            {
                Boolean IsF2 = false;

                if (e.KeyCode.ToString() == "F2")
                {
                    if (!oCustomer.View())
                    {
                        this.txtTeacher.Focus();
                        return;
                    }
                    IsF2 = true;
                    
                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    if (!IsF2)
                    {
                        if (!oCustomer.Find(txtCustomerID.Text))
                        {
                            this.txtCustomerID.Focus();
                            return;
                        }
                    }
                    this.txtCustomerID.Text = oCustomer.ID;
                    this.txtName.Text = oCustomer.Name;

                    IsF2 = false;
                    
                    oCustomer.Teachers.Load(oCustomer.ID);
                    if (this.SetNextTeacher())
                    {
                        txtTeacher.Text = oTeacher.Name;
                    }
                    else
                    {
                        txtTeacher.Clear();
                        txtTeacher.Focus();
                    }
                    this.txtTeacher.Focus();
                    
                    return;
                }
            }
            #endregion
            #region txtTeacher
            if (sender == txtTeacher)
            {
                if (e.KeyCode.ToString() == "F2")
                {

                    oTeacher.CustomerID = txtCustomerID.Text;
                    oTeacher.View();

                   if (oTeacher.Name != "")
                    {
                        
                        this.txtTeacher.Text = oTeacher.Name;
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        if (oTeacher.Find(this.CompanyID, oCustomer.CustomerID, txtTeacher.Text))
                        {
                            this.txtTeacher.Text = oTeacher.Name;
                            
                            return;
                        }
                        else
                        {
                            txtTeacher.Clear();
                            txtTeacher.Focus();
                            return;
                        }
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    txtTeacher.Clear();
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
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    break;
                case Keys.F8:
                    break;
                
                case Keys.F7:
                    this.Close();
                    break;
                

                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
            #endregion
        }
        
        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

   
        private bool SetNextTeacher()
        {
            if (oCustomer.Teachers.Next())
            {
                oTeacher = (ScannedTeacher)oCustomer.Teachers[oCustomer.Teachers.Index];
                if (oTeacher.Scanned)
                    SetNextTeacher();

                return true;
            }
            else
            {
                Global.ShowNotifier("No more teachers");
                return false;
            }

        }

        private void frmOrderICRAdquire_Load(object sender, EventArgs e)
        {

            this.imagXpress1    = new PegasusImaging.WinForms.ImagXpress9.ImagXpress(this.components);
            

            tStrip.Renderer = new Signature.Windows.Forms.WindowsVistaRenderer();

            try
            {

                //***Must call the UnlockRuntime method to unlock the control
                //twainPro1.Licensing.UnlockRuntime(1234, 1234, 1234, 1234);

                twainDevice = new TwainDevice(twainPro1);

                // Set Debug to true to write information to a debug log file
                //twainPro1.Debug = true;
                //twainPro1.ErrorLevel = ErrorLevel.Detailed;

                twainDevice.Scanned += new PegasusImaging.WinForms.TwainPro5.ScannedEventHandler(twainDevice_Scanned);

            }
            catch (PegasusImaging.WinForms.TwainPro5.TwainProException ex)
            {
               MessageBox.Show(ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void twainDevice_Scanned(object sender, PegasusImaging.WinForms.TwainPro5.ScannedEventArgs e)
        {
            try
            {
              //  string strCurrentDir = System.IO.Directory.GetCurrentDirectory();
              //  string strPath = System.IO.Path.Combine(strCurrentDir, "image-" + this.picnumber.ToString() + ".tif");

                PegasusImaging.WinForms.ImagXpress9.SaveOptions so = new PegasusImaging.WinForms.ImagXpress9.SaveOptions();
                so.Format = PegasusImaging.WinForms.ImagXpress9.ImageXFormat.Tiff;
                so.Tiff.Compression = PegasusImaging.WinForms.ImagXpress9.Compression.Group4;

                int hImage = e.ScannedImage.ToHbitmap().ToInt32();
                if (hImage != 0)
                {
                    OutputImg.Image = PegasusImaging.WinForms.ImagXpress9.ImageX.FromHbitmap(imagXpress1,(System.IntPtr)hImage);
                    //GlobalFree(hImage);
                }
                
                PegasusImaging.WinForms.ImagXpress9.Processor prc = new PegasusImaging.WinForms.ImagXpress9.Processor(imagXpress1, OutputImg.Image);
                
                prc.Rotate(270);

                OutputImg.Image = prc.Image.Copy();
                
                
                oImage.CompanyID = CompanyID;
                oImage.CustomerID = txtCustomerID.Text;
                oImage.Teacher = txtTeacher.Text;
                oImage.BatchID = oTeacher.ID;
                oImage.Teacher = oTeacher.Name;
                                
                oImage.Date = DateTime.Now;
                oImage.Insert();

               // OutputImg.Image.Save(strPath, so);
                OutputImg.Image.Save(oImage.FilePath, so);

                this.picnumber++;
            }
            catch (PegasusImaging.WinForms.TwainPro5.TwainProException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        //  Update the status bar with the current error code and description
        private void GetError()
        {
            if ((twainPro1.ErrorLevel != 0))
            {
                MessageBox.Show("Data Source Error " + twainPro1.ErrorLevel);
            }
        }
        

    }

}