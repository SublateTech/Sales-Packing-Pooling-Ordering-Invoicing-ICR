using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PegasusImaging.WinForms.SSXICR4;
using PegasusImaging.WinForms.ImagXpress7;
using System.IO;
using Signature.Classes;
using Signature.Twain;
using System.Runtime.InteropServices;

namespace Signature.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmOrderZonalAdquire : frmBase, IMessageFilter
    {
        private IContainer components;

        
       
        #region declrations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;
        #endregion

        private bool msgfilter;
        private CTwain tw;
        private int picnumber = 0;
        static BITMAPINFOHEADER bmi;
        static Rectangle bmprect;
        ScannedCustomer oCustomer;
        ScannedTeacher oTeacher;
        ScannedImage oImage;
        private ToolStrip tStrip;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        
        
        public frmOrderZonalAdquire()
        {
            InitializeComponent();

            tw = new CTwain();
            tw.Init(this.Handle);

            
            oCustomer   = new ScannedCustomer(Global.CurrrentCompany);
            oTeacher    = new ScannedTeacher(Global.CurrrentCompany);
            oImage      = new ScannedImage();

        }  //Constructor
        
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderICRAdquire));
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
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
            this.toolStripButton1,
            this.toolStripButton2});
            this.tStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Padding = new System.Windows.Forms.Padding(160, 0, 0, 0);
            this.tStrip.Size = new System.Drawing.Size(577, 25);
            this.tStrip.TabIndex = 52;
            this.tStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton1.Text = "Setup Scanner";
            this.toolStripButton1.Click += new System.EventHandler(this.txtSetup_Click);
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tw.Finish();
                
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        private void txtAdquire_Click(object sender, EventArgs e)
        {
            if (oTeacher.Find(txtTeacher.Text))
            {
                if (!msgfilter)
                {
                    this.Enabled = false;
                    msgfilter = true;
                    Application.AddMessageFilter(this);
                }
                tw.Acquire((short)0, (short)1);
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
                    this.txtCustomerID.Text = oCustomer.CustomerID;
                    this.txtName.Text = oCustomer.Name;

                    IsF2 = false;
                    oCustomer.CustomerID = oCustomer.ID;
                    oCustomer.Teachers.Load(oCustomer.ID);
                    if (this.SetNextTeacher())
                        txtTeacher.Text = oTeacher.Name;
                    else
                    {
                        txtTeacher.Clear();
                        txtTeacher.Focus();
                    }
                    this.txtTeacher.Focus();
                    
                    return;
                }
                if (e.KeyCode == Keys.Down)
                {
                    txtTeacher.Clear();
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
                        if (oTeacher.Scanned)
                        {
                            if ((MessageBox.Show("Add more ?", "Add Forms...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                            {
                                txtTeacher.Clear();
                                return;
                            }
                        }
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
        private void txtSetup_Click(object sender, EventArgs e)
        {
            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Setup();
        }
        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region SaveImages Method
        private void SaveImages()
        {
            int ImgNumber = 0;

                        ArrayList pics = tw.TransferPictures();
                        EndingScan();
                        tw.CloseSrc();
                        picnumber++;

                        oImage.CompanyID = CompanyID;
                        oImage.CustomerID = oCustomer.CustomerID;
                        oImage.Teacher = txtTeacher.Text;
                        oImage.BatchID = oTeacher.ID;
                        oImage.Teacher = oTeacher.Name;

                        int i;
                        for (i = 0; i < pics.Count; i++)
                        {
                            IntPtr img = (IntPtr)pics[i];
                            {
                                bmprect = new Rectangle(0, 0, 0, 0);
                                bmpptr = GlobalLock(img);
                                pixptr = GetPixelInfo(bmpptr);
                                int picnum = ImgNumber + i + 1;

                                //Saving in Images Table
                                
                                oImage.Date = DateTime.Now;
                                oImage.Insert();

                                Gdip.SavePicToFile(oImage.FilePath, bmpptr, pixptr);
                            }

                        }
                        if (pics.Count > 0)
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
        #endregion

        #region Twain Interface

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Not)
                return false;

            switch (cmd)
            {
                case TwainCommand.CloseRequest:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.CloseOk:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.DeviceEvent:
                    {
                        break;
                    }
                case TwainCommand.TransferReady:
                    {

                        this.SaveImages();
                        break;
                    }
                default:
                    {
                        return false;

                    }
            }

            return true;
        }
        private void EndingScan()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                this.Enabled = true;
                this.Activate();
                this.txtTeacher.Text = "";
            }
        }
        protected IntPtr GetPixelInfo(IntPtr bmpptr)
        {

            bmprect = new Rectangle(0, 0, 0, 0);
            bmi = new BITMAPINFOHEADER();
            Marshal.PtrToStructure(bmpptr, bmi);

            bmprect.X = bmprect.Y = 0;
            bmprect.Width = bmi.biWidth;
            bmprect.Height = bmi.biHeight;

            if (bmi.biSizeImage == 0)
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

            int p = bmi.biClrUsed;
            if ((p == 0) && (bmi.biBitCount <= 8))
                p = 1 << bmi.biBitCount;
            p = (p * 4) + bmi.biSize + (int)bmpptr;
            return (IntPtr)p;
        }

        IntPtr bmpptr;
        IntPtr pixptr;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);
        #endregion

        private void frmOrderICRAdquire_Load(object sender, EventArgs e)
        {
            tStrip.Renderer = new Signature.Windows.Forms.WindowsVistaRenderer();
        }

        

    }

}