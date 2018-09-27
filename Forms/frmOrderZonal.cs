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
using Signature.Zonal;


namespace Signature.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmOrderZonal: frmBase
    {
        private IContainer components;

        private ZonalSignature icrProcessor = new ZonalSignature(Global.CurrrentCompany);
       
        #region declrations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Order oOrder;
        private ToolStrip tStrip;
        private ToolStripButton tooStripProccessImage;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripNext;
        private ToolStripButton toolStripAll;
        private ToolStripButton toolStripTeacher;
        private ToolStripSeparator toolStripSeparator1;
        private PegasusImaging.WinForms.ImagXpress9.ImagXpress imagXpress1;
        private Panel panel2;
        private PegasusImaging.WinForms.ImagXpress9.ImageXView img;
        private Panel panel3;
        private PegasusImaging.WinForms.ImagXpress9.ImageXView imgXField;
        #endregion

        
        private ScannedCustomer oCustomer;
        
          

        public frmOrderZonal()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
           // img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;

            oOrder = new Order(Global.CurrrentCompany);
            oCustomer = new ScannedCustomer(CompanyID);
        }  //Constructor
                
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripButton toolStripBack;
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderZonal));
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgXField = new PegasusImaging.WinForms.ImagXpress9.ImageXView(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.img = new PegasusImaging.WinForms.ImagXpress9.ImageXView(this.components);
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.tooStripProccessImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTeacher = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAll = new System.Windows.Forms.ToolStripButton();
            this.imagXpress1 = new PegasusImaging.WinForms.ImagXpress9.ImagXpress(this.components);
            toolStripBack = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 707);
            this.txtStatus.Size = new System.Drawing.Size(578, 29);
            // 
            // toolStripBack
            // 
            toolStripBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripBack.Name = "toolStripBack";
            toolStripBack.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            toolStripBack.Size = new System.Drawing.Size(76, 22);
            toolStripBack.Text = "Back";
            toolStripBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance1;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.txtName);
            this.ultraGroupBox2.Controls.Add(this.txtTeacher);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.label1);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 35);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(552, 106);
            this.ultraGroupBox2.TabIndex = 43;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance2;
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
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Appearance = appearance3;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(13, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 551);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.Text = "Image Processing";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.imgXField);
            this.panel3.Location = new System.Drawing.Point(3, 445);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(545, 100);
            this.panel3.TabIndex = 50;
            // 
            // imgXField
            // 
            this.imgXField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imgXField.Location = new System.Drawing.Point(0, 0);
            this.imgXField.MouseWheelCapture = false;
            this.imgXField.Name = "imgXField";
            this.imgXField.Size = new System.Drawing.Size(545, 100);
            this.imgXField.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.img);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 430);
            this.panel2.TabIndex = 49;
            // 
            // img
            // 
            this.img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.MouseWheelCapture = false;
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(545, 430);
            this.img.TabIndex = 48;
            // 
            // tStrip
            // 
            this.tStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooStripProccessImage,
            toolStripBack,
            this.toolStripNext,
            this.toolStripSeparator3,
            this.toolStripTeacher,
            this.toolStripSeparator1,
            this.toolStripAll});
            this.tStrip.Location = new System.Drawing.Point(0, 0);
            this.tStrip.Name = "tStrip";
            this.tStrip.Size = new System.Drawing.Size(578, 25);
            this.tStrip.TabIndex = 55;
            this.tStrip.Text = "toolStrip1";
            // 
            // tooStripProccessImage
            // 
            this.tooStripProccessImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tooStripProccessImage.Image = ((System.Drawing.Image)(resources.GetObject("tooStripProccessImage.Image")));
            this.tooStripProccessImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooStripProccessImage.Name = "tooStripProccessImage";
            this.tooStripProccessImage.Size = new System.Drawing.Size(87, 22);
            this.tooStripProccessImage.Text = "Process Image";
            this.tooStripProccessImage.Click += new System.EventHandler(this.btProcessImage_Click);
            // 
            // toolStripNext
            // 
            this.toolStripNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNext.Image")));
            this.toolStripNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(35, 22);
            this.toolStripNext.Text = "Next";
            this.toolStripNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripNext.Click += new System.EventHandler(this.bNextImage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTeacher
            // 
            this.toolStripTeacher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripTeacher.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTeacher.Image")));
            this.toolStripTeacher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTeacher.Name = "toolStripTeacher";
            this.toolStripTeacher.Size = new System.Drawing.Size(96, 22);
            this.toolStripTeacher.Text = "Process Teacher";
            this.toolStripTeacher.ToolTipText = "toolStripTeacher";
            this.toolStripTeacher.Click += new System.EventHandler(this.toolStripTeacher_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripAll
            // 
            this.toolStripAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAll.Image")));
            this.toolStripAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAll.Name = "toolStripAll";
            this.toolStripAll.Size = new System.Drawing.Size(90, 22);
            this.toolStripAll.Text = "Process School";
            this.toolStripAll.ToolTipText = "Process All";
            this.toolStripAll.Click += new System.EventHandler(this.cAll_Click);
            // 
            // frmOrderZonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 736);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.MinimizeBox = false;
            this.Name = "frmOrderZonal";
            this.Text = "Order Scan Processing";
            this.Load += new System.EventHandler(this.frmICR_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
            img.AutoResize = PegasusImaging.WinForms.ImagXpress9.AutoResizeType.BestFit;
            
            this.Left = 10;
            icrProcessor.PictureChanged += new ZonalProcessor.EventHandler(ZonalProcessor_PictureChanged);
            tStrip.Renderer = new WindowsVistaRenderer();
        }        
        private void btProcessImage_Click(object sender, EventArgs e)
        {
          icrProcessor.Run();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!icrProcessor.BackImage())
                MessageBox.Show("No more images");
        }
        private void bNextImage_Click(object sender, EventArgs e)
        {
            if (!icrProcessor.NextImage())
                MessageBox.Show("No more images");
        }
        void ZonalProcessor_PictureChanged(object sender, ZonalProcessor.ImageEvenArgs e)
        {
            switch (e.type)
            {
                case ZonalProcessor.ICRType.Field:
                case ZonalProcessor.ICRType.FieldProcessed:
                    {
                        try
                        {
                            imgXField.Image = icrProcessor.OutputFieldImg.Image.Copy();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }

                        break;
                    }
                case ZonalProcessor.ICRType.Image:
                case ZonalProcessor.ICRType.ImageMatched:
                case ZonalProcessor.ICRType.ImageProcessed:
                case ZonalProcessor.ICRType.Template:
                case ZonalProcessor.ICRType.TemplateProcessed:
                case ZonalProcessor.ICRType.ImageMarked:
                    {
                        try
                        {
                            img.Image = icrProcessor.OutputImg.Image.Copy();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }

                        break;

                    }
            }

            switch (e.type)
            {
                case ZonalProcessor.ICRType.FieldProcessed:
                    {
                    //    MessageBox.Show("Field Processed");
                        break;
                    }
                case ZonalProcessor.ICRType.TemplateProcessed:
                    {
                    //    MessageBox.Show("TemplateProcessed");
                        break;
                    }
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
                    if (oCustomer.View())
                    {
                        IsF2 = true;
                        this.txtCustomerID.Text = oCustomer.CustomerID;
                        this.txtTeacher.Focus();
                    }
                    this.txtName.Text       = oCustomer.Name;
                    icrProcessor.CustomerID = oCustomer.CustomerID;
                    oOrder.oCustomer.Find(oCustomer.CustomerID);
                    
                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        this.txtCustomerID.Focus();
                        return;
                    }

                    txtName.Text            = oCustomer.Name;
                    icrProcessor.CustomerID = txtCustomerID.Text;
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

                    icrProcessor.oTeacher.CustomerID = txtCustomerID.Text;
                    icrProcessor.oTeacher.View();

                   if (icrProcessor.oTeacher.Name != "")
                    {
                        this.txtTeacher.Text = icrProcessor.oTeacher.Name;
                        icrProcessor.Teacher = icrProcessor.oTeacher.Name;
                        this.LoadImageFiles(txtTeacher.Text);
                        return;
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode.ToString() == "Tab")
                {
                    if (txtCustomerID.Text.Trim() != "")
                    {
                        if (icrProcessor.oTeacher.Find(oOrder.CompanyID, oOrder.oCustomer.ID, txtTeacher.Text))
                        {
                            this.txtTeacher.Text = icrProcessor.oTeacher.Name;
                            icrProcessor.Teacher = txtTeacher.Text;
                            this.LoadImageFiles(txtTeacher.Text);
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
        private void cAll_Click(object sender, EventArgs e)
        {
            String CustomerID = txtCustomerID.Text;
            ScannedCustomer oCustomer = new ScannedCustomer(this.CompanyID);
            oCustomer.Find(CustomerID);
            oCustomer.Teachers.Load(CustomerID);
            foreach (ScannedTeacher oTeacher in oCustomer.Teachers)
            {
                //MessageBox.Show(oTeacher.Name);
                txtTeacher.Text = oTeacher.Name;
                oTeacher.Images.CompanyID = CompanyID;
                oTeacher.Images.CustomerID = CustomerID;
                oTeacher.Images.Teacher = oTeacher.Name;
                oTeacher.Images.Load(ScannedOrderStatus.JustScanned);
                foreach (ScannedImage oImage in oTeacher.Images)
                {
                    // MessageBox.Show(oImage.FilePath);
                    oImage.Teacher = oTeacher.Name;
                    //this.icrProcessor.CustomerID = CustomerID;
                    this.icrProcessor.IsProcessAll = false;
                    this.icrProcessor.Teacher = oTeacher.Name;
                    this.icrProcessor.ProcessOrder(oImage);
                    this.Text = oImage.FilePath;
                    //if (this.icrProcessor.ProcessImage(oImage.FilePath))
                    //    this.icrProcessor.CreateOrder();
                }
            }




            /*
            this.IsProcessAll = true;
            this.LoadImageFiles("");
            while (this.NextImage())
            {
            }
            */
            MessageBox.Show("No more images");
            
        }
        #endregion
        
        #region Methods
        
        public void LoadImageFiles(String Teacher)
        {
            icrProcessor.LoadImageFiles(Teacher);

        }
        #endregion

        private void toolStripTeacher_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(oTeacher.Name);
            ScannedTeacher oTeacher = new ScannedTeacher(this.CompanyID);
            oTeacher.CustomerID = txtCustomerID.Text;
            if (oTeacher.Find(txtTeacher.Text))
            {
                oTeacher.Images.CompanyID   = CompanyID;
                oTeacher.Images.CustomerID  = txtCustomerID.Text;
                oTeacher.Images.Teacher     = oTeacher.Name;
                oTeacher.Images.Load(ScannedOrderStatus.JustScanned);
                foreach (ScannedImage oImage in oTeacher.Images)
                {
                   // MessageBox.Show(oImage.FilePath);
                    oImage.Teacher = oTeacher.Name;
                    this.icrProcessor.IsProcessAll = true;
                    this.icrProcessor.Teacher = oTeacher.Name;
                    //this.icrProcessor.ProcessImage(oImage.FilePath);
                    this.icrProcessor.ProcessOrder(oImage);
                }
            }
            
        }
                       

    }

}