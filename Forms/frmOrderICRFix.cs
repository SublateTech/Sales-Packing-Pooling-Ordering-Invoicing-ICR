using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Signature.Classes;
using System.Runtime.InteropServices;
using Signature.Windows.Forms;

namespace Signature.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmOrderICRFix : frmBase
    {
        private IContainer components;
       
        #region declarations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;
        private ToolStrip tStrip;
        private ToolStripButton Start;
        private ToolStripButton NextTeacher;
        private ToolStripSeparator toolStripSeparator3;
        #endregion

        private Order oOrder;
        private ScannedCustomer oCustomer;
        private ScannedTeacher oTeacher;
        
        ScannedImage oImage = new ScannedImage();

        public frmOrderICRFix()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;

            oOrder = new Order(Global.CurrrentCompany);
            oCustomer = new ScannedCustomer(Global.CurrrentCompany);
            components = null;

        }  //Constructor
                
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderICRFix));
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.NextTeacher = new System.Windows.Forms.ToolStripButton();
            this.Start = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 44);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(567, 106);
            this.ultraGroupBox2.TabIndex = 43;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance1;
            this.txtName.Location = new System.Drawing.Point(192, 24);
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
            this.txtTeacher.Location = new System.Drawing.Point(125, 62);
            this.txtTeacher.MaxLength = 30;
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.ReadOnly = true;
            this.txtTeacher.Size = new System.Drawing.Size(424, 26);
            this.txtTeacher.TabIndex = 1;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(125, 29);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(52, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(26, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NextTeacher,
            this.Start,
            this.toolStripSeparator3});
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Size = new System.Drawing.Size(592, 25);
            this.tStrip.TabIndex = 54;
            this.tStrip.Text = "toolStrip1";
            // 
            // NextTeacher
            // 
            this.NextTeacher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NextTeacher.Image = ((System.Drawing.Image)(resources.GetObject("NextTeacher.Image")));
            this.NextTeacher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextTeacher.Name = "NextTeacher";
            this.NextTeacher.Size = new System.Drawing.Size(99, 22);
            this.NextTeacher.Text = "Next Teacher >>";
            // 
            // Start
            // 
            this.Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Start.Name = "Start";
            this.Start.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.Start.Size = new System.Drawing.Size(118, 22);
            this.Start.Text = "Start Process";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // frmOrderICRFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 202);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.ultraGroupBox2);
            this.MinimizeBox = false;
            this.Name = "frmOrderICRFix";
            this.Text = "Order Scan Processing";
            this.Load += new System.EventHandler(this.frmICR_Load);
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        private void frmICR_Load(object sender, EventArgs e)
        {
            this.Left = 10;
            oTeacher = new ScannedTeacher(Global.CurrrentCompany);

            tStrip.Renderer = new WindowsVistaRenderer();
            //mnuStrip.Renderer = new WindowsVistaRenderer();
        }        
        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            #region txtCustomerID
            if (sender == txtCustomerID)
            {
                Boolean IsF2 = false;

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View())
                    {
                        IsF2 = true;
                        this.txtCustomerID.Text = oCustomer.ID;
                        this.txtTeacher.Focus();
                    }
                    this.txtName.Text       = oCustomer.Name;
                    
                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        this.txtCustomerID.Focus();
                        return;
                    }

                    txtName.Text = oCustomer.Name;
                    
                    oCustomer.Teachers.Load(oCustomer.ID);
                    
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


                    if (oTeacher.View())
                    {
                        this.txtTeacher.Text = oTeacher.Name;
                        oTeacher.LoadImages(ScannedOrderStatus.ProcessedWithErrors);
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        if (oTeacher.Find(oOrder.CompanyID, oOrder.oCustomer.ID, txtTeacher.Text))
                        {
                            this.txtTeacher.Text = oTeacher.Name;
                            oTeacher.LoadImages(ScannedOrderStatus.ProcessedWithErrors);
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
        
            }
            #endregion

        }
        private void Start_Click(object sender, EventArgs e)
        {
            foreach (ScannedTeacher oTeacher in oCustomer.Teachers)
            {
                txtTeacher.Text = oTeacher.Name;
                oTeacher.Images.Load(this.CompanyID, oCustomer.ID, oTeacher.Name, ScannedOrderStatus.ProcessedWithErrors);
                foreach (ScannedImage oImage in oTeacher.Images)
                {
                    //   if (oTeacher.Images.Next())
                    //   {
                    //oImage = oTeacher.Images[oTeacher.Images.Index];
                    oImage.FileType = "JPEG";
                    //img.FileName = oImage.FilePath;
                    //MessageBox.Show(oImage.FilePath);

                    Screen[] screens = Screen.AllScreens;
                    this.Left = screens[0].Bounds.Width - this.Width - 20;
                    Global.ClosePhotoGallery(oImage.FilePath);
                    if (!File.Exists(oImage.FilePath))
                        oImage.FileType = "TIFF";
                    
                    System.Diagnostics.Process.Start(oImage.FilePath, "");


                    if (oOrder.Find(oImage.OrderID))
                    {
                        frmOrder ofrmOrder = new frmOrder(oOrder);
                        ofrmOrder._OrderProcess = OrderProcess.ScanFixing;
                        ofrmOrder.ShowDialog();
                        if (ofrmOrder.IsSaved)
                        {
                            oImage.OrderID = Convert.ToInt32(ofrmOrder.oOrder.ID);
                            oImage.Message = "Saved and Corrected";
                            oImage.Status = ScannedOrderStatus.ProcessedAndCorrected;
                            oImage.UpdateStatus();
                        }
                        ofrmOrder.Dispose();
                    }

                    // }
                }
                // this.Start_Click(null, null);
            }
            Global.ClosePhotoGallery("");
            MessageBox.Show("No more Images");

        }
        #endregion
        
        
        
             
             
        
               
    }

}