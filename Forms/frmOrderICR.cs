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
using System.Runtime.InteropServices;
using Signature.Windows.Forms;

namespace Signature.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmOrderICR : frmBase
    {
        private IContainer components;

        private ICRSignature icrProcessor = new ICRSignature(Global.CurrrentCompany);
       
        #region declrations
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Label label1;
        private Signature.Windows.Forms.GroupBox groupBox1;
        private PICImagXpress img;
        private PICImagXpress imgXField;
        #endregion

        private Order oOrder;
        private ToolStrip tStrip;
        private ToolStripButton tooStripProccessImage;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripNext;
        private ToolStripButton toolStripAll;
        private ToolStripButton toolStripTeacher;
        private ToolStripSeparator toolStripSeparator1;
        private ScannedCustomer oCustomer;
        
          

        public frmOrderICR()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;

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
            System.Windows.Forms.ToolStripButton toolStripBack;
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderICR));
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new Signature.Windows.Forms.GroupBox();
            this.imgXField = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.img = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.tStrip = new System.Windows.Forms.ToolStrip();
            this.tooStripProccessImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTeacher = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAll = new System.Windows.Forms.ToolStripButton();
            toolStripBack = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.imgXField);
            this.groupBox1.Controls.Add(this.img);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(13, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 502);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.Text = "Image Processing";
            this.groupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // imgXField
            // 
            this.imgXField.AddOnBehavior = PegasusImaging.WinForms.ImagXpress7.enumAddOnBehavior.ADDONBEHAVIOR_ShowEval;
            this.imgXField.AlignH = PegasusImaging.WinForms.ImagXpress7.enumAlignH.ALIGNH_Center;
            this.imgXField.AlignV = PegasusImaging.WinForms.ImagXpress7.enumAlignV.ALIGNV_Center;
            this.imgXField.AspectX = 1;
            this.imgXField.AspectY = 1;
            this.imgXField.Async = false;
            this.imgXField.AsyncCancelOnClose = false;
            this.imgXField.AsyncMaxThreads = 4;
            this.imgXField.AsyncPriority = PegasusImaging.WinForms.ImagXpress7.enumAsyncPriority.ASYNC_Normal;
            this.imgXField.AutoClose = true;
            this.imgXField.AutoInvalidate = true;
            this.imgXField.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_CropImage;
            this.imgXField.BackColor = System.Drawing.Color.White;
            this.imgXField.BorderType = PegasusImaging.WinForms.ImagXpress7.enumBorderType.BORD_Inset;
            this.imgXField.CancelLoad = false;
            this.imgXField.CancelMode = PegasusImaging.WinForms.ImagXpress7.enumCancelMode.CM_None;
            this.imgXField.CancelRemove = false;
            this.imgXField.CompressInMemory = PegasusImaging.WinForms.ImagXpress7.enumCompressInMemory.CMEM_NONE;
            this.imgXField.CropX = 0;
            this.imgXField.CropY = 0;
            this.imgXField.DIBXPos = -1;
            this.imgXField.DIBYPos = -1;
            this.imgXField.DisplayError = false;
            this.imgXField.DisplayMode = PegasusImaging.WinForms.ImagXpress7.enumPicDisplayMode.DM_TrueColor;
            this.imgXField.DrawFillColor = System.Drawing.Color.Black;
            this.imgXField.DrawFillStyle = PegasusImaging.WinForms.ImagXpress7.enumFillStyle.FILL_Transparent;
            this.imgXField.DrawMode = PegasusImaging.WinForms.ImagXpress7.enumDrawMode.PEN_CopyPen;
            this.imgXField.DrawStyle = PegasusImaging.WinForms.ImagXpress7.enumBorderStyle.STYLE_Solid;
            this.imgXField.DrawWidth = 1;
            this.imgXField.Edition = PegasusImaging.WinForms.ImagXpress7.enumEdition.EDITION_Prof;
            this.imgXField.EvalMode = PegasusImaging.WinForms.ImagXpress7.enumEvaluationMode.EVAL_Automatic;
            this.imgXField.FileName = "";
            this.imgXField.FileOffsetUse = PegasusImaging.WinForms.ImagXpress7.enumFileOffsetUse.FO_IMAGE;
            this.imgXField.FileTimeout = 10000;
            this.imgXField.FTPMode = PegasusImaging.WinForms.ImagXpress7.enumFTPMode.FTP_ACTIVE;
            this.imgXField.FTPPassword = "";
            this.imgXField.FTPUserName = "";
            this.imgXField.IResUnits = PegasusImaging.WinForms.ImagXpress7.enumIRes.IRes_Inch;
            this.imgXField.IResX = 0;
            this.imgXField.IResY = 0;
            this.imgXField.JPEGCosited = false;
            this.imgXField.JPEGEnhDecomp = true;
            this.imgXField.LoadCropEnabled = false;
            this.imgXField.LoadCropHeight = 0;
            this.imgXField.LoadCropWidth = 0;
            this.imgXField.LoadCropX = 0;
            this.imgXField.LoadCropY = 0;
            this.imgXField.LoadResizeEnabled = false;
            this.imgXField.LoadResizeHeight = 0;
            this.imgXField.LoadResizeMaintainAspectRatio = true;
            this.imgXField.LoadResizeWidth = 0;
            this.imgXField.LoadRotated = PegasusImaging.WinForms.ImagXpress7.enumLoadRotated.LR_NONE;
            this.imgXField.LoadThumbnail = PegasusImaging.WinForms.ImagXpress7.enumLoadThumbnail.THUMBNAIL_None;
            this.imgXField.Location = new System.Drawing.Point(14, 408);
            this.imgXField.LZWPassword = "";
            this.imgXField.ManagePalette = true;
            this.imgXField.MaxHeight = 0;
            this.imgXField.MaxWidth = 0;
            this.imgXField.MinHeight = 1;
            this.imgXField.MinWidth = 1;
            this.imgXField.MousePointer = PegasusImaging.WinForms.ImagXpress7.enumMousePointer.MP_Default;
            this.imgXField.Multitask = false;
            this.imgXField.Name = "imgXField";
            this.imgXField.Notify = false;
            this.imgXField.NotifyDelay = 0;
            this.imgXField.OLEDropMode = PegasusImaging.WinForms.ImagXpress7.enumOLEDropMode.OLEDROP_NONE;
            this.imgXField.OwnDIB = true;
            this.imgXField.PageNbr = 0;
            this.imgXField.Pages = 0;
            this.imgXField.Palette = PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized;
            this.imgXField.PDFSwapBlackandWhite = false;
            this.imgXField.Persistence = true;
            this.imgXField.PFileName = "";
            this.imgXField.PICPassword = "";
            this.imgXField.Picture = null;
            this.imgXField.PictureEnabled = true;
            this.imgXField.PrinterBanding = false;
            this.imgXField.ProgressEnabled = false;
            this.imgXField.ProgressPct = 10;
            this.imgXField.ProxyServer = "";
            this.imgXField.RaiseExceptions = false;
            this.imgXField.SaveCompressSize = 0;
            this.imgXField.SaveEXIFThumbnailSize = ((short)(0));
            this.imgXField.SaveFileName = "";
            this.imgXField.SaveFileType = PegasusImaging.WinForms.ImagXpress7.enumSaveFileType.FT_DEFAULT;
            this.imgXField.SaveGIFInterlaced = false;
            this.imgXField.SaveGIFType = PegasusImaging.WinForms.ImagXpress7.enumGIFType.GIF89a;
            this.imgXField.SaveJLSInterLeave = 0;
            this.imgXField.SaveJLSMaxValue = 0;
            this.imgXField.SaveJLSNear = 0;
            this.imgXField.SaveJLSPoint = 0;
            this.imgXField.SaveJP2Order = PegasusImaging.WinForms.ImagXpress7.enumProgressionOrder.PO_DEFAULT;
            this.imgXField.SaveJP2Type = PegasusImaging.WinForms.ImagXpress7.enumJP2Type.JP2_LOSSY;
            this.imgXField.SaveJPEGChromFactor = ((short)(10));
            this.imgXField.SaveJPEGCosited = false;
            this.imgXField.SaveJPEGGrayscale = false;
            this.imgXField.SaveJPEGLumFactor = ((short)(10));
            this.imgXField.SaveJPEGProgressive = false;
            this.imgXField.SaveJPEGSubSampling = PegasusImaging.WinForms.ImagXpress7.enumSaveJPEGSubSampling.SS_411;
            this.imgXField.SaveLJPCompMethod = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompMethod.LJPMETHOD_JPEG;
            this.imgXField.SaveLJPCompType = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompType.LJPTYPE_RGB;
            this.imgXField.SaveLJPPrediction = ((short)(1));
            this.imgXField.SaveMultiPage = false;
            this.imgXField.SavePBMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.imgXField.SavePDFCompression = PegasusImaging.WinForms.ImagXpress7.enumSavePDFCompression.PDF_Compress_Default;
            this.imgXField.SavePDFSwapBlackandWhite = false;
            this.imgXField.SavePGMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.imgXField.SavePNGInterlaced = false;
            this.imgXField.SavePPMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.imgXField.SaveTIFFByteOrder = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFByteOrder.TIFF_INTEL;
            this.imgXField.SaveTIFFCompression = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFCompression.TIFF_Uncompressed;
            this.imgXField.SaveTIFFRowsPerStrip = 0;
            this.imgXField.SaveTileHeight = 0;
            this.imgXField.SaveTileWidth = 0;
            this.imgXField.SaveToBuffer = false;
            this.imgXField.SaveTransparencyColor = System.Drawing.Color.Black;
            this.imgXField.SaveTransparent = PegasusImaging.WinForms.ImagXpress7.enumTransparencyMatch.TRANSPARENT_None;
            this.imgXField.SaveWSQBlack = ((short)(0));
            this.imgXField.SaveWSQQuant = 1;
            this.imgXField.SaveWSQWhite = ((short)(255));
            this.imgXField.ScaleResizeToGray = false;
            this.imgXField.ScrollBarLargeChangeH = 10;
            this.imgXField.ScrollBarLargeChangeV = 10;
            this.imgXField.ScrollBars = PegasusImaging.WinForms.ImagXpress7.enumScrollBars.SB_None;
            this.imgXField.ScrollBarSmallChangeH = 1;
            this.imgXField.ScrollBarSmallChangeV = 1;
            this.imgXField.ShowHourglass = false;
            this.imgXField.Size = new System.Drawing.Size(519, 88);
            this.imgXField.SN = "PEXPL700AL-28EWFI88YN1";
            this.imgXField.SpecialTIFFHandling = false;
            this.imgXField.TabIndex = 46;
            this.imgXField.TIFFIFDOffset = 0;
            this.imgXField.Timer = 0;
            this.imgXField.TWAINManufacturer = "";
            this.imgXField.TWAINProductFamily = "";
            this.imgXField.TWAINProductName = "";
            this.imgXField.TWAINVersionInfo = "";
            this.imgXField.UndoEnabled = false;
            this.imgXField.ViewAntialias = true;
            this.imgXField.ViewBrightness = ((short)(0));
            this.imgXField.ViewContrast = ((short)(0));
            this.imgXField.ViewDithered = true;
            this.imgXField.ViewGrayMode = PegasusImaging.WinForms.ImagXpress7.enumGrayMode.GRAY_Standard;
            this.imgXField.ViewProgressive = false;
            this.imgXField.ViewSmoothing = true;
            this.imgXField.ViewUpdate = true;
            this.imgXField.WMFConvert = false;
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
            this.img.Size = new System.Drawing.Size(518, 371);
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
            // frmOrderICR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 687);
            this.Controls.Add(this.tStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.MinimizeBox = false;
            this.Name = "frmOrderICR";
            this.Text = "Order Scan Processing";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmICR_Load);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
            icrProcessor.PictureChanged += new ICRProcessor.EventHandler(icrProcessor_PictureChanged);
            tStrip.Renderer = new WindowsVistaRenderer();
        }        
        private void btProcessImage_Click(object sender, EventArgs e)
        {
          icrProcessor.Run();
            
            /*
            PICImagXpress img = new PICImagXpress();
            img.Edition = enumEdition.EDITION_Prof;
            img.FileName        = "I:\\Images\\Order-0000000120.TIFF";
            img.SaveFileName = "I:\\Images\\Order-0000000120";
            img.SaveFileType    = enumSaveFileType.FT_JPEG;
            img.SaveFile();
            */

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
        void icrProcessor_PictureChanged(object sender, ICRProcessor.ImageEvenArgs e)
        {
            switch (e.type)
            {
                case ICRProcessor.ICRType.Field:
                case ICRProcessor.ICRType.FieldProcessed:
                    {
                        try
                        {
                            imgXField.hDIB = e.img.CopyDIB();
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
                    if (oCustomer.View())
                    {
                        IsF2 = true;
                        this.txtCustomerID.Text = oCustomer.CustomerID;
                        this.txtTeacher.Focus();
                    }
                    this.txtName.Text       = oCustomer.Name;
                    icrProcessor.CustomerID = oCustomer.CustomerID;
                    oOrder.oCustomer.Find(oCustomer.CustomerID);
                    return;
                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab" || IsF2)
                {
                    IsF2 = false;
                    if (!oCustomer.Find(txtCustomerID.Text))
                    {
                        
                        this.txtCustomerID.Focus();
                        return;
                    }

                    txtName.Text            = txtName.Text;
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
            
            this.RunAllCustomer();
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
            icrProcessor.RunAllCustomer();
        }

        public void RunAllCustomer()
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
                    //  MessageBox.Show(oImage.FilePath);
                    oImage.Teacher = oTeacher.Name;
                    this.icrProcessor.IsProcessAll = true;
                    this.icrProcessor.Teacher = oTeacher.Name;
                   // this.icrProcessor.ProcessOrder(oImage);
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

        

    }

}