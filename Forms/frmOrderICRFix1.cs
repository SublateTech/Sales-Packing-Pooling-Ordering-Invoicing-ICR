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
    public class frmOrderICRFix1 : frmBase
    {
        private IContainer components;

        
       
        #region declrations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private Button bNextImage;
        private PICImagXpress img;
        #endregion

        private Order oOrder;
        private ScannedCustomer oCustomer;
        private Button bStart;
        private ScannedTeacher oTeacher;
          

        public frmOrderICRFix1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;

            oOrder = new Order(Global.CurrrentCompany);
            oCustomer = new ScannedCustomer(Global.CurrrentCompany);

        }  //Constructor
                
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bNextImage = new System.Windows.Forms.Button();
            this.img = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(888, 106);
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
            this.txtTeacher.Size = new System.Drawing.Size(424, 26);
            this.txtTeacher.TabIndex = 1;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
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
            // groupBox1
            // 
            this.groupBox1.AllowDrop = true;
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.bStart);
            this.groupBox1.Controls.Add(this.bNextImage);
            this.groupBox1.Controls.Add(this.img);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(13, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 744);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.Text = "Image Processing";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(641, 708);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(96, 30);
            this.bStart.TabIndex = 51;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bNextImage
            // 
            this.bNextImage.Location = new System.Drawing.Point(760, 708);
            this.bNextImage.Name = "bNextImage";
            this.bNextImage.Size = new System.Drawing.Size(108, 30);
            this.bNextImage.TabIndex = 45;
            this.bNextImage.Text = "Next  Teacher >>";
            this.bNextImage.UseVisualStyleBackColor = true;
            this.bNextImage.Click += new System.EventHandler(this.bNextImage_Click);
            // 
            // img
            // 
            this.img.AddOnBehavior = PegasusImaging.WinForms.ImagXpress7.enumAddOnBehavior.ADDONBEHAVIOR_ShowEval;
            this.img.AlignH = PegasusImaging.WinForms.ImagXpress7.enumAlignH.ALIGNH_Center;
            this.img.AlignV = PegasusImaging.WinForms.ImagXpress7.enumAlignV.ALIGNV_Center;
            this.img.AspectX = 1;
            this.img.AspectY = 1;
            this.img.Async = false;
            this.img.AsyncCancelOnClose = false;
            this.img.AsyncMaxThreads = 4;
            this.img.AsyncPriority = PegasusImaging.WinForms.ImagXpress7.enumAsyncPriority.ASYNC_Normal;
            this.img.AutoClose = true;
            this.img.AutoInvalidate = true;
            this.img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;
            this.img.BackColor = System.Drawing.Color.Black;
            this.img.BorderType = PegasusImaging.WinForms.ImagXpress7.enumBorderType.BORD_Flat;
            this.img.CancelLoad = false;
            this.img.CancelMode = PegasusImaging.WinForms.ImagXpress7.enumCancelMode.CM_None;
            this.img.CancelRemove = false;
            this.img.CompressInMemory = PegasusImaging.WinForms.ImagXpress7.enumCompressInMemory.CMEM_NONE;
            this.img.CropX = 0;
            this.img.CropY = 0;
            this.img.DIBXPos = -1;
            this.img.DIBYPos = -1;
            this.img.DisplayError = false;
            this.img.DisplayMode = PegasusImaging.WinForms.ImagXpress7.enumPicDisplayMode.DM_TrueColor;
            this.img.DrawFillColor = System.Drawing.Color.Black;
            this.img.DrawFillStyle = PegasusImaging.WinForms.ImagXpress7.enumFillStyle.FILL_Transparent;
            this.img.DrawMode = PegasusImaging.WinForms.ImagXpress7.enumDrawMode.PEN_CopyPen;
            this.img.DrawStyle = PegasusImaging.WinForms.ImagXpress7.enumBorderStyle.STYLE_Solid;
            this.img.DrawWidth = 1;
            this.img.Edition = PegasusImaging.WinForms.ImagXpress7.enumEdition.EDITION_Prof;
            this.img.EvalMode = PegasusImaging.WinForms.ImagXpress7.enumEvaluationMode.EVAL_Automatic;
            this.img.FileName = "";
            this.img.FileOffsetUse = PegasusImaging.WinForms.ImagXpress7.enumFileOffsetUse.FO_IMAGE;
            this.img.FileTimeout = 10000;
            this.img.FTPMode = PegasusImaging.WinForms.ImagXpress7.enumFTPMode.FTP_ACTIVE;
            this.img.FTPPassword = "";
            this.img.FTPUserName = "";
            this.img.IResUnits = PegasusImaging.WinForms.ImagXpress7.enumIRes.IRes_Inch;
            this.img.IResX = 0;
            this.img.IResY = 0;
            this.img.JPEGCosited = false;
            this.img.JPEGEnhDecomp = true;
            this.img.LoadCropEnabled = false;
            this.img.LoadCropHeight = 0;
            this.img.LoadCropWidth = 0;
            this.img.LoadCropX = 0;
            this.img.LoadCropY = 0;
            this.img.LoadResizeEnabled = false;
            this.img.LoadResizeHeight = 0;
            this.img.LoadResizeMaintainAspectRatio = true;
            this.img.LoadResizeWidth = 0;
            this.img.LoadRotated = PegasusImaging.WinForms.ImagXpress7.enumLoadRotated.LR_NONE;
            this.img.LoadThumbnail = PegasusImaging.WinForms.ImagXpress7.enumLoadThumbnail.THUMBNAIL_None;
            this.img.Location = new System.Drawing.Point(14, 31);
            this.img.LZWPassword = "";
            this.img.ManagePalette = true;
            this.img.MaxHeight = 0;
            this.img.MaxWidth = 0;
            this.img.MinHeight = 1;
            this.img.MinWidth = 1;
            this.img.MousePointer = PegasusImaging.WinForms.ImagXpress7.enumMousePointer.MP_Default;
            this.img.Multitask = false;
            this.img.Name = "img";
            this.img.Notify = false;
            this.img.NotifyDelay = 0;
            this.img.OLEDropMode = PegasusImaging.WinForms.ImagXpress7.enumOLEDropMode.OLEDROP_NONE;
            this.img.OwnDIB = true;
            this.img.PageNbr = 0;
            this.img.Pages = 0;
            this.img.Palette = PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized;
            this.img.PDFSwapBlackandWhite = false;
            this.img.Persistence = true;
            this.img.PFileName = "";
            this.img.PICPassword = "";
            this.img.Picture = null;
            this.img.PictureEnabled = true;
            this.img.PrinterBanding = false;
            this.img.ProgressEnabled = false;
            this.img.ProgressPct = 10;
            this.img.ProxyServer = "";
            this.img.RaiseExceptions = false;
            this.img.SaveCompressSize = 0;
            this.img.SaveEXIFThumbnailSize = ((short)(0));
            this.img.SaveFileName = "";
            this.img.SaveFileType = PegasusImaging.WinForms.ImagXpress7.enumSaveFileType.FT_DEFAULT;
            this.img.SaveGIFInterlaced = false;
            this.img.SaveGIFType = PegasusImaging.WinForms.ImagXpress7.enumGIFType.GIF89a;
            this.img.SaveJLSInterLeave = 0;
            this.img.SaveJLSMaxValue = 0;
            this.img.SaveJLSNear = 0;
            this.img.SaveJLSPoint = 0;
            this.img.SaveJP2Order = PegasusImaging.WinForms.ImagXpress7.enumProgressionOrder.PO_DEFAULT;
            this.img.SaveJP2Type = PegasusImaging.WinForms.ImagXpress7.enumJP2Type.JP2_LOSSY;
            this.img.SaveJPEGChromFactor = ((short)(10));
            this.img.SaveJPEGCosited = false;
            this.img.SaveJPEGGrayscale = false;
            this.img.SaveJPEGLumFactor = ((short)(10));
            this.img.SaveJPEGProgressive = false;
            this.img.SaveJPEGSubSampling = PegasusImaging.WinForms.ImagXpress7.enumSaveJPEGSubSampling.SS_411;
            this.img.SaveLJPCompMethod = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompMethod.LJPMETHOD_JPEG;
            this.img.SaveLJPCompType = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompType.LJPTYPE_RGB;
            this.img.SaveLJPPrediction = ((short)(1));
            this.img.SaveMultiPage = false;
            this.img.SavePBMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.img.SavePDFCompression = PegasusImaging.WinForms.ImagXpress7.enumSavePDFCompression.PDF_Compress_Default;
            this.img.SavePDFSwapBlackandWhite = false;
            this.img.SavePGMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.img.SavePNGInterlaced = false;
            this.img.SavePPMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.img.SaveTIFFByteOrder = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFByteOrder.TIFF_INTEL;
            this.img.SaveTIFFCompression = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFCompression.TIFF_Uncompressed;
            this.img.SaveTIFFRowsPerStrip = 0;
            this.img.SaveTileHeight = 0;
            this.img.SaveTileWidth = 0;
            this.img.SaveToBuffer = false;
            this.img.SaveTransparencyColor = System.Drawing.Color.Black;
            this.img.SaveTransparent = PegasusImaging.WinForms.ImagXpress7.enumTransparencyMatch.TRANSPARENT_None;
            this.img.SaveWSQBlack = ((short)(0));
            this.img.SaveWSQQuant = 1;
            this.img.SaveWSQWhite = ((short)(255));
            this.img.ScaleResizeToGray = false;
            this.img.ScrollBarLargeChangeH = 10;
            this.img.ScrollBarLargeChangeV = 10;
            this.img.ScrollBars = PegasusImaging.WinForms.ImagXpress7.enumScrollBars.SB_None;
            this.img.ScrollBarSmallChangeH = 1;
            this.img.ScrollBarSmallChangeV = 1;
            this.img.ShowHourglass = false;
            this.img.Size = new System.Drawing.Size(854, 671);
            this.img.SN = "PEXPL700AL-28EWFI88YN1";
            this.img.SpecialTIFFHandling = false;
            this.img.TabIndex = 44;
            this.img.Text = "img";
            this.img.TIFFIFDOffset = 0;
            this.img.Timer = 0;
            this.img.TWAINManufacturer = "";
            this.img.TWAINProductFamily = "";
            this.img.TWAINProductName = "";
            this.img.TWAINVersionInfo = "";
            this.img.UndoEnabled = false;
            this.img.ViewAntialias = true;
            this.img.ViewBrightness = ((short)(0));
            this.img.ViewContrast = ((short)(0));
            this.img.ViewDithered = true;
            this.img.ViewGrayMode = PegasusImaging.WinForms.ImagXpress7.enumGrayMode.GRAY_Standard;
            this.img.ViewProgressive = false;
            this.img.ViewSmoothing = true;
            this.img.ViewUpdate = true;
            this.img.WMFConvert = false;
            // 
            // frmOrderICRFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 906);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.MinimizeBox = false;
            this.Name = "frmOrderICRFix";
            this.Text = "Order Scan Processing";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmICR_Load);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        }        
        private void bNextImage_Click(object sender, EventArgs e)
        {
            
        }
        void icrProcessor_PictureChanged(object sender, ICRProcessor.ImageEvenArgs e)
        {
            switch (e.type)
            {
                case ICRProcessor.ICRType.Field:
                case ICRProcessor.ICRType.FieldProcessed:
                    {
                        try
                        {
                            //imgXField.hDIB = e.img.CopyDIB();
                        }
                        catch (Exception ex)
                        {
                            
                            break;
                        }

                        break;
                    }
                case ICRProcessor.ICRType.Image:
                    {

                        try
                        {
                            img.hDIB = e.img.CopyDIB();
                        }
                        catch (Exception ex)
                        {
                            
                            break;
                        }

                        break;
                    }
                case ICRProcessor.ICRType.ImageMatched:
                case ICRProcessor.ICRType.ImageProcessed:
                case ICRProcessor.ICRType.Template:
                case ICRProcessor.ICRType.TemplateProcessed:
                case ICRProcessor.ICRType.ImageMarked:
                    {
                        try
                        {
                            img.hDIB = e.img.CopyDIB();
                            //pictureBox1.Image = Image.FromHbitmap((IntPtr)e.img.hBMP);
                        }
                        catch (Exception ex)
                        {
                            break;
                        }

                        break;

                    }
            }

            switch (e.type)
            {
                case ICRProcessor.ICRType.FieldProcessed:
                    {
                    //    MessageBox.Show("Field Processed");
                        break;
                    }
                case ICRProcessor.ICRType.TemplateProcessed:
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
                    if (oOrder.oCustomer.View())
                    {
                        IsF2 = true;
                        this.txtCustomerID.Text = oOrder.oCustomer.ID;
                        this.txtTeacher.Focus();
                    }
                    this.txtName.Text       = oOrder.oCustomer.Name;
                    
                    
                    
                    return;
                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!oOrder.oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        this.txtCustomerID.Focus();
                        return;
                    }

                    txtName.Text            = txtName.Text;
                    
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
        #endregion
        
        #region Methods
        #endregion

        private void bStart_Click(object sender, EventArgs e)
        {
            if (oTeacher.Images.Next())
            {
                ScannedImage oImage = oTeacher.Images[oTeacher.Images.Index];
                oImage.FileType = "JPEG";
                img.FileName = oImage.FilePath;
                
                if (oOrder.Find(oImage.OrderID))
                {
                    frmOrder ofrmOrder = new frmOrder(oOrder);
                    ofrmOrder._OrderProcess = (int)OrderProcess.Scanning;
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
                this.bStart_Click(null, null);
            }
            else
                MessageBox.Show("No more Images");
        }

        private void bZoomIn_Click(object sender, EventArgs e)
        {
            img.Zoom(1);
        }

        

    }

}