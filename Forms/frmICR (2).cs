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

namespace Signature
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmICR1 : System.Windows.Forms.Form
    {
        private IContainer components;

        
        private System.Windows.Forms.Label statusLabel;
        private PegasusImaging.WinForms.SSXICR4.PICSSXICR picssxicr1;
        private Button btProcessImage;
        private Panel PanDetail;
        private Button bNextImage;
        
        private PICImagXpress imgXField;
        private PICImagXpress img;
        private Signature.Windows.Forms.MaskedLabel maskedLabel3;
        private Signature.Windows.Forms.MaskedLabel maskedLabel4;
        private Signature.Windows.Forms.MaskedLabel maskedLabel5;
        private Signature.Windows.Forms.MaskedLabel maskedLabel6;
        private Signature.Windows.Forms.MaskedLabel maskedLabel7;
        private Signature.Windows.Forms.MaskedLabel maskedLabel8;
        private Signature.Windows.Forms.MaskedLabel maskedLabel10;
        private Signature.Windows.Forms.MaskedLabel maskedLabel12;
        private Signature.Windows.Forms.MaskedLabel maskedLabel14;
        private Panel PanLastName;
        private Signature.Windows.Forms.MaskedLabel maskedLabel15;
        private Panel PanFirstName;
        private Signature.Windows.Forms.MaskedLabel maskedLabel16;
        private Panel PanParentAddress;
        private Panel PanCity;
        private Panel PanState;
        private Panel PanZipCode;
        private Panel PanDayPhone;
        private Panel PanCellPhone;
        private Panel PanTeacher;
        private Panel PanSchoolName;
        private Panel PanSchoolUse;
        private Button btSetupSchool;

        private String _CompanyID;
        private String _CustomerID;
        private String _Batch;
        private String _Teacher;


        private ICRProcessor1 pImg;
        private Button btCalculate;
        private Panel PanSUDecimal;

        private Order oOrder; 

        public frmICR1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            pImg = new ICRProcessor1(this);
            GetGlobalParameters();
            oOrder = new Order(_CompanyID);
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusLabel = new System.Windows.Forms.Label();
            this.picssxicr1 = new PegasusImaging.WinForms.SSXICR4.PICSSXICR();
            this.btProcessImage = new System.Windows.Forms.Button();
            this.img = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.PanDetail = new System.Windows.Forms.Panel();
            this.bNextImage = new System.Windows.Forms.Button();
            this.imgXField = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.maskedLabel3 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel4 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel5 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel6 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel7 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel8 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel10 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel12 = new Signature.Windows.Forms.MaskedLabel();
            this.maskedLabel14 = new Signature.Windows.Forms.MaskedLabel();
            this.PanLastName = new System.Windows.Forms.Panel();
            this.maskedLabel15 = new Signature.Windows.Forms.MaskedLabel();
            this.PanFirstName = new System.Windows.Forms.Panel();
            this.maskedLabel16 = new Signature.Windows.Forms.MaskedLabel();
            this.PanParentAddress = new System.Windows.Forms.Panel();
            this.PanCity = new System.Windows.Forms.Panel();
            this.PanState = new System.Windows.Forms.Panel();
            this.PanZipCode = new System.Windows.Forms.Panel();
            this.PanDayPhone = new System.Windows.Forms.Panel();
            this.PanCellPhone = new System.Windows.Forms.Panel();
            this.PanTeacher = new System.Windows.Forms.Panel();
            this.PanSchoolName = new System.Windows.Forms.Panel();
            this.PanSchoolUse = new System.Windows.Forms.Panel();
            this.btSetupSchool = new System.Windows.Forms.Button();
            this.btCalculate = new System.Windows.Forms.Button();
            this.PanSUDecimal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(5, 906);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(608, 30);
            this.statusLabel.TabIndex = 12;
            // 
            // picssxicr1
            // 
            this.picssxicr1.ClassifierPath = "";
            this.picssxicr1.DisplayError = false;
            this.picssxicr1.Enabled = true;
            this.picssxicr1.EvalMode = PegasusImaging.WinForms.SSXICR4.peEvaluationMode.EVAL_Automatic;
            this.picssxicr1.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
            this.picssxicr1.InkColor = PegasusImaging.WinForms.SSXICR4.peInkColor.INKCOLOR_Black;
            this.picssxicr1.LicenseMode = PegasusImaging.WinForms.SSXICR4.peLicenseMode.LICENSEMODE_ICR_OCR_OMR;
            this.picssxicr1.OwnDIB = true;
            this.picssxicr1.Picture = null;
            this.picssxicr1.RaiseExceptions = false;
            this.picssxicr1.SN = "PSIPP400BS-PEG0N002FNN";
            this.picssxicr1.SSEdition = PegasusImaging.WinForms.SSXICR4.peSSEdition.SS_EDITION_Professional;
            // 
            // btProcessImage
            // 
            this.btProcessImage.Location = new System.Drawing.Point(127, 12);
            this.btProcessImage.Name = "btProcessImage";
            this.btProcessImage.Size = new System.Drawing.Size(103, 30);
            this.btProcessImage.TabIndex = 26;
            this.btProcessImage.Text = "Re-ProcessImage";
            this.btProcessImage.UseVisualStyleBackColor = true;
            this.btProcessImage.Click += new System.EventHandler(this.btProcessImage_Click);
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
            this.img.BorderType = PegasusImaging.WinForms.ImagXpress7.enumBorderType.BORD_InsetThickResizer;
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
            this.img.Location = new System.Drawing.Point(8, 49);
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
            this.img.Size = new System.Drawing.Size(505, 718);
            this.img.SN = "PEXPS700U3-AJNYECS5XP3";
            this.img.SpecialTIFFHandling = false;
            this.img.TabIndex = 27;
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
            // PanDetail
            // 
            this.PanDetail.AutoScroll = true;
            this.PanDetail.BackColor = System.Drawing.SystemColors.Window;
            this.PanDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanDetail.Location = new System.Drawing.Point(541, 272);
            this.PanDetail.Name = "PanDetail";
            this.PanDetail.Size = new System.Drawing.Size(989, 561);
            this.PanDetail.TabIndex = 35;
            // 
            // bNextImage
            // 
            this.bNextImage.Location = new System.Drawing.Point(236, 12);
            this.bNextImage.Name = "bNextImage";
            this.bNextImage.Size = new System.Drawing.Size(120, 30);
            this.bNextImage.TabIndex = 37;
            this.bNextImage.Text = "Next Page >>";
            this.bNextImage.UseVisualStyleBackColor = true;
            this.bNextImage.Click += new System.EventHandler(this.bNextImage_Click);
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
            this.imgXField.Location = new System.Drawing.Point(12, 773);
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
            this.imgXField.Size = new System.Drawing.Size(505, 86);
            this.imgXField.SN = "PEXPS700U3-AJNYECS5XP3";
            this.imgXField.SpecialTIFFHandling = false;
            this.imgXField.TabIndex = 39;
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
            // maskedLabel3
            // 
            this.maskedLabel3.AllowDrop = true;
            this.maskedLabel3.Location = new System.Drawing.Point(543, 118);
            this.maskedLabel3.Name = "maskedLabel1";
            this.maskedLabel3.Size = new System.Drawing.Size(178, 15);
            this.maskedLabel3.TabIndex = 14;
            this.maskedLabel3.TabStop = true;
            this.maskedLabel3.Value = "Parent Address";
            this.maskedLabel3.Visible = false;
            // 
            // maskedLabel4
            // 
            this.maskedLabel4.AllowDrop = true;
            this.maskedLabel4.Location = new System.Drawing.Point(543, 186);
            this.maskedLabel4.Name = "maskedLabel1";
            this.maskedLabel4.Size = new System.Drawing.Size(282, 15);
            this.maskedLabel4.TabIndex = 14;
            this.maskedLabel4.TabStop = true;
            this.maskedLabel4.Value = "City";
            this.maskedLabel4.Visible = false;
            // 
            // maskedLabel5
            // 
            this.maskedLabel5.AllowDrop = true;
            this.maskedLabel5.Location = new System.Drawing.Point(1026, 186);
            this.maskedLabel5.Name = "maskedLabel1";
            this.maskedLabel5.Size = new System.Drawing.Size(38, 15);
            this.maskedLabel5.TabIndex = 16;
            this.maskedLabel5.TabStop = true;
            this.maskedLabel5.Value = "State";
            this.maskedLabel5.Visible = false;
            // 
            // maskedLabel6
            // 
            this.maskedLabel6.AllowDrop = true;
            this.maskedLabel6.Location = new System.Drawing.Point(1096, 188);
            this.maskedLabel6.Name = "maskedLabel1";
            this.maskedLabel6.Size = new System.Drawing.Size(90, 15);
            this.maskedLabel6.TabIndex = 18;
            this.maskedLabel6.TabStop = true;
            this.maskedLabel6.Value = "Zip Code";
            this.maskedLabel6.Visible = false;
            // 
            // maskedLabel7
            // 
            this.maskedLabel7.AllowDrop = true;
            this.maskedLabel7.Location = new System.Drawing.Point(543, 256);
            this.maskedLabel7.Name = "maskedLabel1";
            this.maskedLabel7.Size = new System.Drawing.Size(126, 13);
            this.maskedLabel7.TabIndex = 16;
            this.maskedLabel7.TabStop = true;
            this.maskedLabel7.Value = "Day Phone";
            this.maskedLabel7.Visible = false;
            // 
            // maskedLabel8
            // 
            this.maskedLabel8.AllowDrop = true;
            this.maskedLabel8.Location = new System.Drawing.Point(1026, 256);
            this.maskedLabel8.Name = "maskedLabel1";
            this.maskedLabel8.Size = new System.Drawing.Size(126, 13);
            this.maskedLabel8.TabIndex = 18;
            this.maskedLabel8.TabStop = true;
            this.maskedLabel8.Value = "Cell Phone";
            this.maskedLabel8.Visible = false;
            // 
            // maskedLabel10
            // 
            this.maskedLabel10.AllowDrop = true;
            this.maskedLabel10.Location = new System.Drawing.Point(541, 184);
            this.maskedLabel10.Name = "maskedLabel1";
            this.maskedLabel10.Size = new System.Drawing.Size(164, 13);
            this.maskedLabel10.TabIndex = 18;
            this.maskedLabel10.TabStop = true;
            this.maskedLabel10.Value = "Teacher";
            // 
            // maskedLabel12
            // 
            this.maskedLabel12.AllowDrop = true;
            this.maskedLabel12.Location = new System.Drawing.Point(541, 114);
            this.maskedLabel12.Name = "maskedLabel1";
            this.maskedLabel12.Size = new System.Drawing.Size(164, 13);
            this.maskedLabel12.TabIndex = 20;
            this.maskedLabel12.TabStop = true;
            this.maskedLabel12.Value = "School";
            // 
            // maskedLabel14
            // 
            this.maskedLabel14.AllowDrop = true;
            this.maskedLabel14.Location = new System.Drawing.Point(1221, 185);
            this.maskedLabel14.Name = "maskedLabel1";
            this.maskedLabel14.Size = new System.Drawing.Size(111, 13);
            this.maskedLabel14.TabIndex = 20;
            this.maskedLabel14.TabStop = true;
            this.maskedLabel14.Value = "School Use";
            // 
            // PanLastName
            // 
            this.PanLastName.AutoScroll = true;
            this.PanLastName.BackColor = System.Drawing.Color.White;
            this.PanLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanLastName.Location = new System.Drawing.Point(542, 65);
            this.PanLastName.Name = "PanLastName";
            this.PanLastName.Size = new System.Drawing.Size(477, 40);
            this.PanLastName.TabIndex = 29;
            // 
            // maskedLabel15
            // 
            this.maskedLabel15.AllowDrop = true;
            this.maskedLabel15.Location = new System.Drawing.Point(541, 49);
            this.maskedLabel15.Name = "maskedLabel1";
            this.maskedLabel15.Size = new System.Drawing.Size(282, 15);
            this.maskedLabel15.TabIndex = 1;
            this.maskedLabel15.TabStop = true;
            this.maskedLabel15.Value = "Last Name";
            // 
            // PanFirstName
            // 
            this.PanFirstName.AutoScroll = true;
            this.PanFirstName.BackColor = System.Drawing.Color.White;
            this.PanFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanFirstName.Location = new System.Drawing.Point(1025, 65);
            this.PanFirstName.Name = "PanFirstName";
            this.PanFirstName.Size = new System.Drawing.Size(505, 40);
            this.PanFirstName.TabIndex = 30;
            // 
            // maskedLabel16
            // 
            this.maskedLabel16.AllowDrop = true;
            this.maskedLabel16.Location = new System.Drawing.Point(1025, 49);
            this.maskedLabel16.Name = "maskedLabel1";
            this.maskedLabel16.Size = new System.Drawing.Size(282, 15);
            this.maskedLabel16.TabIndex = 17;
            this.maskedLabel16.TabStop = true;
            this.maskedLabel16.Value = "First Name";
            // 
            // PanParentAddress
            // 
            this.PanParentAddress.AutoScroll = true;
            this.PanParentAddress.BackColor = System.Drawing.Color.White;
            this.PanParentAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanParentAddress.Location = new System.Drawing.Point(543, 133);
            this.PanParentAddress.Name = "PanParentAddress";
            this.PanParentAddress.Size = new System.Drawing.Size(987, 36);
            this.PanParentAddress.TabIndex = 30;
            this.PanParentAddress.Visible = false;
            // 
            // PanCity
            // 
            this.PanCity.AutoScroll = true;
            this.PanCity.BackColor = System.Drawing.Color.White;
            this.PanCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanCity.Location = new System.Drawing.Point(543, 202);
            this.PanCity.Name = "PanCity";
            this.PanCity.Size = new System.Drawing.Size(476, 48);
            this.PanCity.TabIndex = 31;
            this.PanCity.Visible = false;
            // 
            // PanState
            // 
            this.PanState.AutoScroll = true;
            this.PanState.BackColor = System.Drawing.Color.White;
            this.PanState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanState.Location = new System.Drawing.Point(1025, 202);
            this.PanState.Name = "PanState";
            this.PanState.Size = new System.Drawing.Size(65, 47);
            this.PanState.TabIndex = 32;
            this.PanState.Visible = false;
            // 
            // PanZipCode
            // 
            this.PanZipCode.AutoScroll = true;
            this.PanZipCode.BackColor = System.Drawing.Color.White;
            this.PanZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanZipCode.Location = new System.Drawing.Point(1096, 202);
            this.PanZipCode.Name = "PanZipCode";
            this.PanZipCode.Size = new System.Drawing.Size(158, 47);
            this.PanZipCode.TabIndex = 33;
            this.PanZipCode.Visible = false;
            // 
            // PanDayPhone
            // 
            this.PanDayPhone.AutoScroll = true;
            this.PanDayPhone.BackColor = System.Drawing.Color.White;
            this.PanDayPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanDayPhone.Location = new System.Drawing.Point(543, 272);
            this.PanDayPhone.Name = "PanDayPhone";
            this.PanDayPhone.Size = new System.Drawing.Size(476, 48);
            this.PanDayPhone.TabIndex = 32;
            this.PanDayPhone.Visible = false;
            // 
            // PanCellPhone
            // 
            this.PanCellPhone.AutoScroll = true;
            this.PanCellPhone.BackColor = System.Drawing.Color.White;
            this.PanCellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanCellPhone.Location = new System.Drawing.Point(1026, 272);
            this.PanCellPhone.Name = "PanCellPhone";
            this.PanCellPhone.Size = new System.Drawing.Size(417, 47);
            this.PanCellPhone.TabIndex = 33;
            this.PanCellPhone.Visible = false;
            // 
            // PanTeacher
            // 
            this.PanTeacher.AutoScroll = true;
            this.PanTeacher.BackColor = System.Drawing.Color.White;
            this.PanTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTeacher.Location = new System.Drawing.Point(541, 202);
            this.PanTeacher.Name = "PanTeacher";
            this.PanTeacher.Size = new System.Drawing.Size(674, 40);
            this.PanTeacher.TabIndex = 33;
            // 
            // PanSchoolName
            // 
            this.PanSchoolName.AutoScroll = true;
            this.PanSchoolName.BackColor = System.Drawing.Color.White;
            this.PanSchoolName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSchoolName.Location = new System.Drawing.Point(541, 133);
            this.PanSchoolName.Name = "PanSchoolName";
            this.PanSchoolName.Size = new System.Drawing.Size(761, 40);
            this.PanSchoolName.TabIndex = 34;
            // 
            // PanSchoolUse
            // 
            this.PanSchoolUse.AutoScroll = true;
            this.PanSchoolUse.BackColor = System.Drawing.Color.White;
            this.PanSchoolUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSchoolUse.Location = new System.Drawing.Point(1221, 202);
            this.PanSchoolUse.Name = "PanSchoolUse";
            this.PanSchoolUse.Size = new System.Drawing.Size(130, 40);
            this.PanSchoolUse.TabIndex = 34;
            // 
            // btSetupSchool
            // 
            this.btSetupSchool.Location = new System.Drawing.Point(12, 12);
            this.btSetupSchool.Name = "btSetupSchool";
            this.btSetupSchool.Size = new System.Drawing.Size(109, 30);
            this.btSetupSchool.TabIndex = 40;
            this.btSetupSchool.Text = "Setup School";
            this.btSetupSchool.UseVisualStyleBackColor = true;
            this.btSetupSchool.Click += new System.EventHandler(this.btSetupSchool_Click);
            // 
            // btCalculate
            // 
            this.btCalculate.Location = new System.Drawing.Point(362, 12);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Size = new System.Drawing.Size(120, 30);
            this.btCalculate.TabIndex = 41;
            this.btCalculate.Text = "Save";
            this.btCalculate.UseVisualStyleBackColor = true;
            this.btCalculate.Click += new System.EventHandler(this.btCalculate_Click);
            // 
            // PanSUDecimal
            // 
            this.PanSUDecimal.AutoScroll = true;
            this.PanSUDecimal.BackColor = System.Drawing.Color.White;
            this.PanSUDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSUDecimal.Location = new System.Drawing.Point(1351, 202);
            this.PanSUDecimal.Name = "PanSUDecimal";
            this.PanSUDecimal.Size = new System.Drawing.Size(34, 40);
            this.PanSUDecimal.TabIndex = 35;
            // 
            // frmICR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1684, 861);
            this.Controls.Add(this.PanSUDecimal);
            this.Controls.Add(this.btCalculate);
            this.Controls.Add(this.btSetupSchool);
            this.Controls.Add(this.imgXField);
            this.Controls.Add(this.bNextImage);
            this.Controls.Add(this.PanDetail);
            this.Controls.Add(this.PanSchoolUse);
            this.Controls.Add(this.PanSchoolName);
            this.Controls.Add(this.PanTeacher);
            this.Controls.Add(this.PanCellPhone);
            this.Controls.Add(this.PanDayPhone);
            this.Controls.Add(this.PanZipCode);
            this.Controls.Add(this.PanState);
            this.Controls.Add(this.PanCity);
            this.Controls.Add(this.PanParentAddress);
            this.Controls.Add(this.maskedLabel16);
            this.Controls.Add(this.PanFirstName);
            this.Controls.Add(this.maskedLabel15);
            this.Controls.Add(this.PanLastName);
            this.Controls.Add(this.img);
            this.Controls.Add(this.btProcessImage);
            this.Controls.Add(this.maskedLabel14);
            this.Controls.Add(this.maskedLabel12);
            this.Controls.Add(this.maskedLabel10);
            this.Controls.Add(this.maskedLabel3);
            this.Controls.Add(this.maskedLabel4);
            this.Controls.Add(this.maskedLabel5);
            this.Controls.Add(this.maskedLabel6);
            this.Controls.Add(this.maskedLabel7);
            this.Controls.Add(this.maskedLabel8);
            this.Controls.Add(this.statusLabel);
            this.Name = "frmICR";
            this.Text = "Forms Matching";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
        #endregion

        #region Events
                
                
        private void btProcessImage_Click(object sender, EventArgs e)
        {
            pImg.Run();
        }
        private void bNextImage_Click(object sender, EventArgs e)
        {
            if (pImg.NextImage())
                pImg.Run();
        }
        private void btSetupSchool_Click(object sender, EventArgs e)
        {
            Signature.Twain.frmSetupCustomer frm = new Signature.Twain.frmSetupCustomer();
            frm.ShowDialog();
            GetGlobalParameters();
            pImg.LoadImageFiles();
            pImg.curImage = -1;
        }
        private void btCalculate_Click(object sender, EventArgs e)
        {

            oOrder.CompanyID = _CompanyID;
            oOrder.CustomerID = _CustomerID;
            oOrder.Teacher = _Teacher;

            String strCollected = pImg.GetControlResultValues("SchoolUse");
            oOrder.Collected = Convert.ToDouble((strCollected.Trim() == "") ? "0.0" : strCollected);

            oOrder.Phone = pImg.GetControlResultValues("DayPhone");
            oOrder.Student = pImg.GetControlResultValues("LastName") + ", " + pImg.GetControlResultValues("FirstName");
            oOrder.Date = DateTime.Now;
            oOrder.Tax = 0;
            oOrder.Teacher = pImg.GetControlResultValues("Teacher");
            oOrder.Items.Clear();

            oOrder.Items.Clear();
            for (int Index = 0; Index < 40; Index++)
            {
                Order.Item oItem = new Order.Item();

                oItem.ProductID = pImg.GetControlResultValues("Code" + (Index + 1).ToString());
                String strQuantity = pImg.GetControlResultValues("Quantity" + (Index + 1).ToString());

                if (oItem.ProductID != "" && strQuantity != "")
                {
                    oItem.CompanyID = oOrder.CompanyID;
                    oItem.CustomerID = oOrder.CustomerID;

                    oItem.Quantity = Convert.ToInt16((strQuantity == "") ? "0" : strQuantity);
                    if (oOrder.oProduct.Find(oItem.ProductID))
                        oItem._Price = oOrder.oProduct.Price;
                    oOrder.Items.Add(pImg.GetControlResultValues("Code" + (Index + 1).ToString()), oItem);
                }


            }
            oOrder.GetTotals();
            oOrder.Save(OrderType.Scanned);
            MessageBox.Show("Order Saved!!!");


        }

        #endregion
        #region Methods
        private void GetGlobalParameters()
        {
            
            _CompanyID = Global.GetParameter("CurrentCompany");
            _CustomerID = Global.GetParameter("CurrentCustomer");
            _Batch = Global.GetParameter("CurrentBatch");
            _Teacher = Global.GetParameter("CurrentTeacher");

        }
        #endregion
        #region Classes
        public class ICRProcessor1
        {
            //private String formName = Application.StartupPath + "\\..\\..\\Images\\SigForm.tif";
            private String formName = Application.StartupPath + "\\Templates\\SigFormTemplateBlank.tif";
            public PICSSXICR _icrProcessor;
            private PICImagXpress img;
            private String matchedForm;
            private frmICR1 frm;
            private int LastPos = 0;
            private FileInfo[] files;
            public int curImage = -1;

            private int TempWidth = 0;
            private int TempHeight = 0;

            private int WidthBox = 0;
            private int HeightBox = 0;

            private Product oProduct;
            
            private ICR4 oICR;
            
            
            //Methods            
            public ICRProcessor1(frmICR1 frm)
            {
                this.frm = frm;

                frm.GetGlobalParameters();

                this.LoadImageFiles();

                // Initialize the _icrProcessor object
                _icrProcessor = new PICSSXICR(); ;
                img = new PICImagXpress();

                _icrProcessor.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
                _icrProcessor.OwnDIB = true;

                this.SetGeneralParameters(); //For ICR
              //  this.LoadTemplate(formName, formName.Substring(formName.LastIndexOf("\\") + 1));

                oProduct = new Product(frm._CompanyID);

                oICR = new ICR4();
    
            }
            public bool Run()
            {
                if (!(files.Length == 0) && curImage != -1)
                {
                    frm.Text = "Image - " + files[curImage].FullName;
                    this.Clear_Form();
                    oICR.ProcessImage(files[curImage].FullName);
                }
                else
                {
                    MessageBox.Show("There is no images to process");
                    return false;

                }
                return true;
                
            }

            #region ICR Processor Related Methods
            
            private void LoadTemplate1(String FormName, String TemplateName)
            {
               oICR.SetGeneralImageActions();

                img.FileName = FormName;                    //Template Form
                _icrProcessor.hDIB = img.CopyDIB();

                frm.img.hDIB = img.CopyDIB();

                //Clean Up the Master
                // _icrProcessor.PreprocessImage();

                // frm.img.hDIB = _icrProcessor.GetPreprocessImagehDIB();


                _icrProcessor.AddTemplateImage(TemplateName);

                _icrProcessor.SetRegistrationTemplate(peRegistrationMarkType.REGMARKTYPE_ANGLE);

                //Create Templates
                //For processing fields

                //_icrProcessor.ClassifierPath = Application.StartupPath + "\\..\\..\\Classifiers\\Data";

                _icrProcessor.ClassifierPath = Application.StartupPath + "\\Classifiers\\Data";

                //' MUST CREATE A FORM TO START WITH
                _icrProcessor.CreateForm("SigForm.fdl");
                _icrProcessor.SetFormBounds(0, 0, img.IWidth - 1, img.IHeight - 1);

                this.TempWidth = 1710; // img.IWidth;
                this.TempHeight = img.IHeight;

            }
            private void Clear_Form()
            {
                frm.PanLastName.Controls.Clear();
                frm.PanLastName.BackColor = SystemColors.Control;
                frm.PanFirstName.Controls.Clear();
                frm.PanFirstName.BackColor = SystemColors.Control;
                frm.PanParentAddress.Controls.Clear();
                frm.PanParentAddress.BackColor = SystemColors.Control;
                frm.PanCity.Controls.Clear();
                frm.PanCity.BackColor = SystemColors.Control;
                frm.PanState.Controls.Clear();
                frm.PanState.BackColor = SystemColors.Control;
                frm.PanZipCode.Controls.Clear();
                frm.PanZipCode.BackColor = SystemColors.Control;
                frm.PanDayPhone.Controls.Clear();
                frm.PanDayPhone.BackColor = SystemColors.Control;
                frm.PanCellPhone.Controls.Clear();
                frm.PanCellPhone.BackColor = SystemColors.Control;
                frm.PanTeacher.Controls.Clear();
                frm.PanTeacher.BackColor = SystemColors.Control;
                frm.PanSchoolName.Controls.Clear();
                frm.PanSchoolName.BackColor = SystemColors.Control;
                frm.PanSchoolUse.Controls.Clear();
                frm.PanSchoolUse.BackColor = SystemColors.Control;
                frm.PanSUDecimal.Controls.Clear();
                frm.PanSUDecimal.BackColor = SystemColors.Control;
                frm.PanDetail.Controls.Clear();
                frm.PanDetail.BackColor = SystemColors.Control;

                Application.DoEvents();


            }
            private void SetGeneralParameters()
            {

                // SET RECOGNITION PARAMETERS
                _icrProcessor.FieldRecLanguage = (int)peLanguage.LANGTYPE_SS_English;
                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_CUT_CONFIDENCE__LONG, 60);
                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_HORIZONTAL_THRESHOLD__LONG, 1);
                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_VERTICAL_THRESHOLD__LONG, 1);
                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_MIN_LINE_HEIGHT__LONG, 2);
                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_MIN_BLANK_WIDTH__LONG, 1);
                // _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_MIN_LINE_SEPARATION__LONG, 200);

                _icrProcessor.SetFieldSegProperty_Long(peSegmentationProperties_Long.SEG_MAX_SPECK_HEIGHT__LONG, 12);



            }
         
            #endregion

            #region Form And Field Text Related Methods
            
            private void AddProductLabel(String ProductID, int Index)
            {
                bool bFound;
                
                    if (bFound = oProduct.Find(ProductID))
                    {
                        this.AddFieldDescription("Description", Index, oProduct.Description.PadRight(30).Substring(0, 30),bFound);
                        this.AddFieldDescription("Price", Index, oProduct.Price.ToString("##00.00"), bFound);
                    }
                    else
                    {
                        this.AddFieldDescription("Description", Index, "".PadRight(30).Substring(0,30),bFound) ;
                        this.AddFieldDescription("Price", Index, "".ToString(), bFound);
                    }

            }
            public void ProcessFields()
            {

                //Saving Order to SQL Server

                frm.oOrder.CompanyID = frm._CompanyID;
                frm.oOrder.CustomerID = frm._CustomerID;
                frm.oOrder.Teacher = frm._Teacher;

                SwitchControlText("Teacher", frm.oOrder.Teacher);

                frm.oOrder.oCustomer.Find(frm._CustomerID);
                SwitchControlText("SchoolName", frm.oOrder.oCustomer.Name);


                oICR.InitFormProcessing();



                oICR.GetFieldResult("LastName");

                oICR.GetFieldResult("FirstName");
                /*  this.GetFieldResult("ParentAddress");
                  this.GetFieldResult("City");
                  this.GetFieldResult("State");
                  this.GetFieldResult("ZipCode");
                  this.GetFieldResult("DayPhone");
                  this.GetFieldResult("CellPhone");
                  this.GetFieldResult("Teacher");
                  this.GetFieldResult("SchoolName");*/
                oICR.GetFieldResult("SchoolUse");
                oICR.GetFieldResult("SUDecimal");


                Application.DoEvents();

                String Code, Quantity;


                for (int i = 1; i <= 40; i++)
                {

                    Code = oICR.GetFieldResult("Code" + i.ToString());
                    //  MessageBox.Show(Code);
                    Quantity = oICR.GetFieldResult("Quantity" + i.ToString());

                    //  if (Code != "")
                    //  {
                    //MessageBox.Show(Code + "--" + Quantity);


                    Code = Code.Replace(" ", "");
                    Quantity = Quantity.Replace(" ", "");

                    AddProductLabel(Code, i);


                }

                _icrProcessor.DeletePreprocessImage();

            }
            public void SwitchControlText(String Field, String Value)
            {
                if (IsDetail(Field))
                    frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Clear();
                else
                    frm.Controls["Pan" + Field].Controls.Clear();

                for (int i = 0; i < Value.Length; i++)
                {
                    AddControlText(Field, Value.Substring(i, 1), 100, i + 1);

                }
                this.CompleteFieldSize(Field, Value);
                this.ChangeFieldColor(Field, System.Drawing.Color.Blue);
            }
            private void ChangeFieldColor(String Field, System.Drawing.Color FColor)
            {
                if (!IsDetail(Field))
                    frm.Controls["Pan" + Field].BackColor = FColor;
                else
                    frm.Controls["PanDetail"].Controls["Pan" + Field].BackColor = FColor;
            }
            private bool IsDetail(String Field)
            {
                if (Field.Substring(0, 4) == "Code" || (Field.Length > 8 && Field.Substring(0, 8) == "Quantity"))
                    return true;
                else
                    return false;
            }
            private int GetFieldSize(String Field)
            {
                int size = 0;
                switch (Field)
                {
                    case "LastName":
                        size = 14;
                        break;
                    case "FirstName":
                        size = 14;
                        break;
                    case "ParentAddress":
                        size = 30;
                        break;
                    case "City":
                        size = 14;
                        break;
                    case "State":
                        size = 2;
                        break;
                    case "ZipCode":
                        size = 5;
                        break;
                    case "DayPhone":
                        size = 10;
                        break;
                    case "CellPhone":
                        size = 10;
                        break;
                    case "Teacher":
                        size = 20;
                        break;
                    case "SchoolName":
                        size = 32;
                        break;
                    case "SchoolUse":
                        size = 4;
                        break;
                    case "SUDecimal":
                        size = 4;
                        break;

                    default:
                        {
                            if (Field.Substring(0, 4) == "Code" || (Field.Length >= 8 && Field.Substring(0, 8) == "Quantity"))
                            {
                                size = 4;

                            }
                            break;
                        }

                }

                return size;
            }
            private void CompleteFieldSize(String Field, String Result)
            {
                //MessageBox.Show(Result.Length.ToString());
                int size = GetFieldSize(Field);
                
                if (Result.Length > size)
                {
                    Result = Result.Substring(0, size);
                    
                }
                
                size = size - Result.Length;
                    

                for (int i = 0; i < size; i++)
                {
                    AddControlText(Field, "", 80, Result.Length + i + 1);

                }

                if (!this.IsDetail(Field))
                {

                    frm.Controls["Pan" + Field].Width = this.LastPos + 10;
                }
                else
                {
                    frm.Controls["PanDetail"].Controls["Pan" + Field].Width = this.LastPos + 10;
                }
            }
            private void AddControlText(String Field, String Text, int Percent, int Index)
            {
                TextBox CharStr = new TextBox();
                WidthBox = 30;
                HeightBox = 8;


                if (Index == 1)
                    this.LastPos = 0;


                CharStr.Name = Index.ToString();
                CharStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CharStr.Size = new System.Drawing.Size(WidthBox, HeightBox);
                CharStr.TabIndex = 0;
                CharStr.Location = new System.Drawing.Point(3 + this.LastPos, 3);
                CharStr.MaxLength = 1;
                CharStr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
                CharStr.TextChanged += new System.EventHandler(this.txtControl_TextChanged);

                this.LastPos += WidthBox;

                if (Percent <= 60)
                    CharStr.ForeColor = System.Drawing.Color.Red;
                else if (Percent <= 80)
                    CharStr.ForeColor = System.Drawing.Color.Green;
                else
                    CharStr.ForeColor = System.Drawing.Color.Black;
                CharStr.Text = Text;

                if (!this.IsDetail(Field))
                {

                    frm.Controls["Pan" + Field].Controls.Add(CharStr);
                }
                else
                {

                    if (frm.PanDetail.Controls["Pan" + Field] == null)
                    { //Create Panel for each item
                        System.Windows.Forms.Panel Panel = new System.Windows.Forms.Panel();

                        String sField = Field;
                        if (sField.Substring(0, 4) == "Code")
                        {
                            sField = sField.Remove(0, 4);
                            Panel.Location = new Point(9, 12 + (Convert.ToInt32(sField) - 1) * 43);
                            Panel.Size = new Size(156, 40);

                        }
                        else
                        {
                            sField = sField.Remove(0, 8);
                            Panel.Location = new Point(834, 12 + (Convert.ToInt32(sField) - 1) * 43);
                            Panel.Size = new Size(120, 40);
                        }
                        //MessageBox.Show("Pan"+Field);

                        Panel.BorderStyle = BorderStyle.FixedSingle;
                        Panel.Name = "Pan" + Field;

                        frm.Controls["PanDetail"].Controls.Add(Panel);

                    }

                    //if (Index == 1)
                    // frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Clear();

                    /*  if (Percent < 80)
                          frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Add(ComboStr);
                      else*/
                    frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Add(CharStr);
                }
            }
            private void txtControl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                TextBox tmp = (TextBox)sender;
              
                if (this.IsDetail(tmp.Parent.Name.Replace("Pan", "")))
                {
                    if (tmp.Parent.Name.Replace("Pan", "").Substring(0, 4) == "Code")
                    {

                        if (e.KeyCode.ToString() == "F8")
                        {

                        }

                        if (e.KeyCode.ToString() == "F2")
                        {
                            //this.ViewProduct();
                            frmProductView oView = new frmProductView(frm._CompanyID);
                            oView.ShowDialog();
                            if (oView.sSelectedID != "")
                            {
                                Product oProduct = new Product(frm._CompanyID);
                                oProduct.Find(oView.sSelectedID);
                                this.AddProductLabel(oView.sSelectedID, Convert.ToInt16(tmp.Parent.Name.Replace("PanCode", "")));
                                this.SwitchControlText(tmp.Parent.Name.Replace("Pan", ""), oView.sSelectedID);

                            }

                        }
                        if (e.KeyCode == Keys.Return)
                        {

                        }

                    }

                }



                //Default option
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        //this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                    case Keys.Down:
                        //this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                    case Keys.Up:
                        //this.SelectNextControl(this.ActiveControl, false, true, true, true);
                        break;
                    case Keys.F8:
                        //this.listView.Focus();
                        break;
                    case Keys.F3:
                        //oOrder.deleteOrder();
                        break;
                    case Keys.PageDown:
                        //this.txtCollected.Focus();
                        break;


                    //case Keys.<some key>: 
                    // ......; 
                    // break; 
                }
            }
            private void txtControl_TextChanged(object sender, EventArgs e)
            {
                return;
                TextBox tmp = (TextBox)sender;
                if (this.IsDetail(tmp.Parent.Name.Replace("Pan", "")))
                {
                    if (tmp.Parent.Name.Replace("Pan", "").Substring(0, 4) == "Code")
                    {
                                          
                                Product oProduct = new Product(frm._CompanyID);
                                oProduct.Find(tmp.Text);
                                this.AddProductLabel(oProduct.ID, Convert.ToInt16(tmp.Parent.Name.Replace("PanCode", "")));
                                this.SwitchControlText(tmp.Parent.Name.Replace("Pan", ""),oProduct.ID);
                    }

                }

            }
            private void AddFieldDescription(String Field, int Index, String Description, bool bFound)
            {
                if (frm.PanDetail.Controls[Field + Index.ToString()] == null)
                {
                    Label CharStr = new Label();
                    CharStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    CharStr.Size = new System.Drawing.Size(400, 35);
                    CharStr.TabIndex = 0;
                    if (bFound)
                        CharStr.ForeColor = System.Drawing.Color.Black;
                    else
                        CharStr.ForeColor = System.Drawing.Color.Red;

                    switch (Field)
                    {
                        case "Description":
                            CharStr.Location = new Point(140, 16 + (Index - 1) * 43);
                            break;
                        case "Price":
                            CharStr.Location = new Point(700, 16 + (Index - 1) * 43);
                            break;
                    }

                    
                    CharStr.Name = Field + Index.ToString();
                    frm.Controls["PanDetail"].Controls.Add(CharStr);
                }

                frm.PanDetail.Controls[Field + Index.ToString()].Text = Description;

            }
            public String GetControlResultValues(String Panel)         //Panel is the field
            {
                String ResultStr = "";

                if (!this.IsDetail(Panel))
                {

                    for (int i = 1; i <= frm.Controls["Pan" + Panel].Controls.Count; i++)
                    {
                        
                        ResultStr += frm.Controls["Pan" + Panel].Controls[i.ToString()].Text;

                    }
                }
                else
                {    
                    if (frm.Controls["PanDetail"].Controls["Pan"+ Panel] != null)
                        {
                           for (int i = 1; i <= frm.Controls["PanDetail"].Controls["Pan" + Panel].Controls.Count; i++)
                             {
                               ResultStr += frm.Controls["PanDetail"].Controls["Pan" + Panel].Controls[i.ToString()].Text;
                             }
                         }
                }


                return ResultStr;

            }
            public bool NextImage()
            {
                if (curImage == files.Length - 1)
                {
                    MessageBox.Show("No More images for processing..");
                    return false;
                }
                        
                
                if (curImage < files.Length - 1)
                    this.curImage++;

                return true;

            }
            public void LoadImageFiles()
            {
                //DirectoryInfo directory = new DirectoryInfo(Application.StartupPath + "\\..\\..\\Images\\");

                DirectoryInfo directory = new DirectoryInfo(Application.StartupPath + "\\Images\\");
                //MessageBox.Show(Application.StartupPath + "\\Images\\");
                //"Order-" + _CompanyID.PadLeft(2,'0') + _CustomerID.PadLeft(4,'0') + _Batch.PadLeft(3,'0') +  picnum.ToString().PadLeft(4,'0') + ".tiff"


                //MessageBox.Show("Order-" + frm._CompanyID.PadLeft(2, '0') + frm._CustomerID.PadLeft(4, '0') + frm._Batch.PadLeft(3, '0') + "*.tif");
                // Examine all contained files.
                files = directory.GetFiles("Order-" + frm._CompanyID.PadLeft(2, '0') + frm._CustomerID.PadLeft(4, '0') + frm._Batch.PadLeft(3, '0') + "*.tif*");

                //MessageBox.Show(files.Length.ToString());

                /*  for (int nfiles = 0; nfiles <= files.Length -1; nfiles++)
                   {
                      MessageBox.Show(files[nfiles].Name);
                   }   
                  */

                /* foreach (FileInfo file in files) {
                     if (file.Extension.ToUpper() == ".TIF")
                        if (file.Name.Length >11 && file.Name.Substring(0, 11) == "SigFormData")
                             MessageBox.Show(file.Name);
             }*/


            }
            #endregion
        }


        public class ICR
        {
            PICSSXICR _icrProcessor;
            frmICR1 frm;
            private PICImagXpress img;
            private int TempWidth = 0;
            private int TempHeight = 0;
            public String formName = Application.StartupPath + "\\Templates\\ICRTemplate.tif";
            private String matchedForm;

            private int LastPos = 0;

            private int WidthBox = 0;
            private int HeightBox = 0;

            private String ImageName;
            private Boolean IsTemplateLoaded = false;


            public ICR(frmICR1 _frm, ICRProcessor1 ICRp)
            {
                this._icrProcessor = ICRp._icrProcessor;
                this.frm            = _frm;
                this.img            = frm.img;

            }
            
            public bool ProcessImage(String Image)
            {
                this.ImageName = Image;
                if (!IsTemplateLoaded)
                    LoadTemplate(formName, formName.Substring(formName.LastIndexOf("\\") + 1));
                MatchForms();

                CreateForm();
                CreateFields();
                LoadImage(Image);
                ProcessFields();
                return true;

            }

            public void LoadImage(String Image)
            {
                img.FileName = Image;
                _icrProcessor.hDIB = img.CopyDIB();
                _icrProcessor.PreprocessImage();                    //Preprocess the image 
                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();

                frm.img.hDIB = img.CopyDIB();                       //Show it

                _icrProcessor.hDIB = img.CopyDIB();
                _icrProcessor.RegisterImage();


                SetSpecialImageActions();
                _icrProcessor.PreprocessImage();                    //Preprocess the image 

                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();
                frm.img.hDIB = img.CopyDIB();                       //Show It





            }
            public void LoadTemplate(String FormName, String TemplateName)
            {
                this.SetGeneralImageActions();

                img.FileName = FormName;                    //Template Form
                _icrProcessor.hDIB = img.CopyDIB();

                frm.img.hDIB = img.CopyDIB();

                //Clean Up the Master
                // _icrProcessor.PreprocessImage();

                // frm.img.hDIB = _icrProcessor.GetPreprocessImagehDIB();


                _icrProcessor.AddTemplateImage(TemplateName);

              //  _icrProcessor.SetRegistrationTemplate(peRegistrationMarkType.REGMARKTYPE_ANGLE);

                IsTemplateLoaded = true;
                

            }
            public void CreateForm()
            {
                //Create Templates
                //For processing fields
                _icrProcessor.ClassifierPath = Application.StartupPath + "\\Classifiers\\Data";

                //' MUST CREATE A FORM TO START WITH
                _icrProcessor.CreateForm("SigForm.fdl");
                _icrProcessor.SetFormBounds(0, 0, img.IWidth - 1, img.IHeight - 1);

                this.TempWidth = 1710; // img.IWidth;
                this.TempHeight = img.IHeight;
            }
            public void SetGeneralImageActions()
            {
                // THESE IMAGE-LEVEL OPERATIONS WILL BE AVAILABLE

                // TO ALL IMAGES LOADED INTO THE SMARTSCAN CONTROL

                _icrProcessor.RemoveAllPreprocessImageActions();

                //Set Intelligent Image Operations

                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESKEW, "");
                //  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "2,1");
                //  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");


                // Set Standard Image Operations
                /*  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_HORIZ_LEFT, "");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_HORIZ_RIGHT, "");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "1");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "1");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "1,15");
                  */

            }
            private bool MatchForms()
            {
                
                // LOAD A FILLED IN 1-BIT FORM IMAGES AND CLEAN IT UP
                img.FileName = ImageName;
                


                //PASS THE IMAGE TO THE SmartScan CONTROL FOR PROCESSING
                _icrProcessor.hDIB = img.CopyDIB();


                // CLEAN UP THE IMAGE
                SetGeneralImageActions();
                _icrProcessor.PreprocessImage();                    //Preprocess the image 


                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();
                


                // SEARCH THE TEMPLATE DATA BASE FOR A MATCH

                int minConfidence = 60;
                int lMatchedConfidence = 0;
                int sensitivity = 50;
                matchedForm = _icrProcessor.MatchTemplate(false, false, minConfidence, sensitivity, ref lMatchedConfidence);

                if (matchedForm.Trim() == "")
                {
                    MessageBox.Show("Form doesn't match ---" + matchedForm);
                    return false;
                }


                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();
                _icrProcessor.hDIB = img.CopyDIB();
                


                //  this.SetSpecialImageActions();
                //  _icrProcessor.PreprocessImage();  //Preprocess the image 
                //  img.hDIB = _icrProcessor.GetPreprocessImagehDIB();




                return true;

            }
            private void RegisterTemplate1(String FormName, String TemplateName)
            {
                SetGeneralImageActions();

                img.FileName = FormName;                    //Template Form
                _icrProcessor.hDIB = img.CopyDIB();

                frm.img.hDIB = img.CopyDIB();

                //Clean Up the Master
                // _icrProcessor.PreprocessImage();

                // frm.img.hDIB = _icrProcessor.GetPreprocessImagehDIB();


                _icrProcessor.AddTemplateImage(TemplateName);

                _icrProcessor.SetRegistrationTemplate(peRegistrationMarkType.REGMARKTYPE_ANGLE);

                //Create Templates
                //For processing fields

                _icrProcessor.ClassifierPath = Application.StartupPath + "\\..\\..\\Classifiers\\Data";


                //' MUST CREATE A FORM TO START WITH
                _icrProcessor.CreateForm("SigForm.fdl");
                _icrProcessor.SetFormBounds(0, 0, img.IWidth - 1, img.IHeight - 1);

                this.TempWidth = 1710; // img.IWidth;
                this.TempHeight = img.IHeight;

            }
            public void CreateFields()
            {

                int Top;
                int Height;
                int Left;
                int Width;


                do
                {
                    _icrProcessor.RemoveFieldPreprocessImageAction(1);

                } while (_icrProcessor.SSError == 0);


                //' ADD A FIELD TO THE FORM
                //Left,Top,Width,Height

                // if (img.IWidth.ToString() != this.TempWidth.ToString())
                //          MessageBox.Show(img.IWidth.ToString() + "--" + this.TempWidth.ToString());

                int MarginErr = this.TempWidth - img.IWidth;
                if (MarginErr < 0)
                    MarginErr = 0;

                this.AddField("LastName", 55 - MarginErr, 153, 436, 63, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha); //+ (int)peCharacterSet.CHARSET_SS_LowerCaseAlpha
                this.AddField("FirstName", 535 - MarginErr, 154, 445, 64, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha); //+ (int)peCharacterSet.CHARSET_SS_LowerCaseAlpha
                this.AddField("ParentAddress", 53 - MarginErr, 245, 923, 63, (int)(peCharacterSet.CHARSET_SS_UpperCaseAlpha + (int)peCharacterSet.CHARSET_SS_Digits));
                this.AddField("City", 53 - MarginErr, 332, 589, 62, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("State", 685 - MarginErr, 332, 92, 62, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("ZipCode", 815 - MarginErr, 332, 174, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("DayPhone", 53 - MarginErr, 413, 344, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("CellPhone", 547 - MarginErr, 416, 343, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("Teacher", 53 - MarginErr, 502, 619, 67, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("SchoolName", 683 - MarginErr, 502, 992, 67, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("SchoolUse", 756 - MarginErr, 2025, 200, 73, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("SUDecimal", 958 - MarginErr, 2025, 86, 75, (int)peCharacterSet.CHARSET_SS_Digits);


                // Codes Fields
                Int16 GenTop = 596;

                Top = GenTop;
                Height = 54 + 12;
                Left = 400;
                Width = 160;

                for (int i = 1; i <= 40; i++)
                {
                    if (i == 21)
                    {
                        Left += 645;
                        Top = GenTop;
                    }

                    this.AddField("Code" + i.ToString(), Left - MarginErr, Top, Width, Height, (int)peCharacterSet.CHARSET_SS_Digits);
                    Top = Top + Height;
                }

                // Quantities Codes Fields

                Top = GenTop;
                Height = 54 + 12;
                Left = 570;
                Width = 85;

                for (int i = 1; i <= 40; i++)
                {
                    if (i == 21)
                    {
                        Left += 635;
                        Top = GenTop;
                    }

                    this.AddField("Quantity" + i.ToString(), Left - MarginErr, Top, Width, Height, (int)peCharacterSet.CHARSET_SS_Digits);
                    Top = Top + Height;

                }

            }
            private void AddField(String Name, int Left, int Top, int Width, int Height, int CharSet)
            {

                _icrProcessor.RemoveFormField(Name);
                _icrProcessor.AddFormField(Name);
                _icrProcessor.SetFieldBounds(Left, Top, Width, Height);
                _icrProcessor.FieldRecCharacterSet = CharSet;
                this.SetGeneralActionsFields();

            }
            private void SetGeneralActionsFields()
            {
                _icrProcessor.FieldType = peFieldType.FIELDTYPE_ICR;


                //Set Intelligent Image Operations

                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESKEW, "");
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "1,1");
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");


                /*  // Set Standard Image Operations
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_HORIZ_LEFT, "");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_HORIZ_RIGHT, "");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "2");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "2,2");
                  */

                // pePreprocessImageAction.
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_BLACK, "2");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_VERT_UP, "");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_VERT_UP, "");
                //_icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_BLACK, "1");
                //_icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_BLACK, "1");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "1");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "1,15");


                /* _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_VERT_UP, "");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "3");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "3,15");
                 */

                _icrProcessor.FormFieldRetainImage = true;
            }
            public void SetSpecialImageActions()
            {
                _icrProcessor.RemoveAllPreprocessImageActions();

                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "2,2");
                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");
                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "");

            }
            public void InitFormProcessing()
            {
                // Go on with the processing:
                _icrProcessor.SelectForm(matchedForm);
                _icrProcessor.StartFormProcessing();
            }
            public String GetFieldResult(String Field)
            {

                _icrProcessor.FormFieldDefaultType = peFieldType.FIELDTYPE_ICR;
                _icrProcessor.SelectFormField(Field);   //All this preprocess is applied to the current field


                //    MessageBox.Show("Form : " + _icrProcessor.GetFormName() + " Field: " + _icrProcessor.GetFieldName() + " \r\n" +
                //                 "Error : " + _icrProcessor.FieldError.ToString() + "  " + _icrProcessor.FieldErrorString + " \r\n" +
                //                 "Result: " + _icrProcessor.FieldResultStr);


                //Reading Fields
                int pLeft = 0, pTop = 0, pWidth = 0, pHeight = 0;
                Color[] mColor = new Color[] { Color.Red, Color.Green, Color.Blue };
                String charResult = "";

                if (_icrProcessor.FieldError != 0)
                {
                    MessageBox.Show(_icrProcessor.FieldError.ToString());
                }

                _icrProcessor.GetFieldBounds(ref pLeft, ref pTop, ref pWidth, ref pHeight);

                //draw where the fields are on the image, for illustration purposes only
                // frm.img.ColorDepth(24, PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized, PegasusImaging.WinForms.ImagXpress7.enumDithered.DI_None);
                frm.img.DrawWidth = 4;

                //Process Multi Fields

                frm.imgXField.hDIB = _icrProcessor.FieldResultImagehDIB;
                //  MessageBox.Show("Wait...");
                Application.DoEvents();

                if (_icrProcessor.FieldError == 0)
                {
                    for (int i = 1; _icrProcessor.FieldResultNumLines + 1 != i; i++)
                    {
                        _icrProcessor.FieldResultLine = i;

                        charResult = "";
                        int ControlIndex = 1;
                        for (int charIndex = 1; _icrProcessor.FieldResultLineNumChars + 1 != charIndex; charIndex++)
                        {
                            _icrProcessor.FieldResultLineChar = charIndex;
                            _icrProcessor.FieldResultChar(0);

                            if (_icrProcessor.FieldResultChar(0) == " " && IsDetail(Field))
                            {
                                continue;
                            }

                            if (GetFieldSize(Field) <= charResult.Trim().Length)
                            {
                                break;
                            }


                            charResult = charResult + _icrProcessor.FieldResultChar(0);
                            AddControlText(Field, _icrProcessor.FieldResultChar(0), _icrProcessor.FieldResultCharConfidence, ControlIndex);
                            ControlIndex++;

                        }

                        if (_icrProcessor.FieldResultLineConfidence <= 60)
                        {
                            frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Red);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Red);
                        }
                        else if (_icrProcessor.FieldResultLineConfidence <= 80)
                        {
                            frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Green);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Green);
                        }
                        else
                        {
                            frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Black);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Black);

                        }

                    }

                    this.CompleteFieldSize(Field, charResult);


                }

                return charResult;

            } //Compbined Procedure with form
            private int GetFieldSize(String Field)
            {
                int size = 0;
                switch (Field)
                {
                    case "LastName":
                        size = 14;
                        break;
                    case "FirstName":
                        size = 14;
                        break;
                    case "ParentAddress":
                        size = 30;
                        break;
                    case "City":
                        size = 14;
                        break;
                    case "State":
                        size = 2;
                        break;
                    case "ZipCode":
                        size = 5;
                        break;
                    case "DayPhone":
                        size = 10;
                        break;
                    case "CellPhone":
                        size = 10;
                        break;
                    case "Teacher":
                        size = 20;
                        break;
                    case "SchoolName":
                        size = 32;
                        break;
                    case "SchoolUse":
                        size = 4;
                        break;
                    case "SUDecimal":
                        size = 4;
                        break;

                    default:
                        {
                            if (Field.Substring(0, 4) == "Code" || (Field.Length >= 8 && Field.Substring(0, 8) == "Quantity"))
                            {
                                size = 4;

                            }
                            break;
                        }

                }

                return size;
            }
            private bool IsDetail(String Field)
            {
                if (Field.Substring(0, 4) == "Code" || (Field.Length > 8 && Field.Substring(0, 8) == "Quantity"))
                    return true;
                else
                    return false;
            }
            private void AddControlText(String Field, String Text, int Percent, int Index)
            {
                TextBox CharStr = new TextBox();
                WidthBox = 30;
                HeightBox = 8;


                if (Index == 1)
                    this.LastPos = 0;


                CharStr.Name = Index.ToString();
                CharStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CharStr.Size = new System.Drawing.Size(WidthBox, HeightBox);
                CharStr.TabIndex = 0;
                CharStr.Location = new System.Drawing.Point(3 + this.LastPos, 3);
                CharStr.MaxLength = 1;
              //  CharStr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
              //  CharStr.TextChanged += new System.EventHandler(this.txtControl_TextChanged);

                this.LastPos += WidthBox;

                if (Percent <= 60)
                    CharStr.ForeColor = System.Drawing.Color.Red;
                else if (Percent <= 80)
                    CharStr.ForeColor = System.Drawing.Color.Green;
                else
                    CharStr.ForeColor = System.Drawing.Color.Black;
                CharStr.Text = Text;

                if (!this.IsDetail(Field))
                {

                    frm.Controls["Pan" + Field].Controls.Add(CharStr);
                }
                else
                {

                    if (frm.PanDetail.Controls["Pan" + Field] == null)
                    { //Create Panel for each item
                        System.Windows.Forms.Panel Panel = new System.Windows.Forms.Panel();

                        String sField = Field;
                        if (sField.Substring(0, 4) == "Code")
                        {
                            sField = sField.Remove(0, 4);
                            Panel.Location = new Point(9, 12 + (Convert.ToInt32(sField) - 1) * 43);
                            Panel.Size = new Size(156, 40);

                        }
                        else
                        {
                            sField = sField.Remove(0, 8);
                            Panel.Location = new Point(834, 12 + (Convert.ToInt32(sField) - 1) * 43);
                            Panel.Size = new Size(120, 40);
                        }
                        //MessageBox.Show("Pan"+Field);

                        Panel.BorderStyle = BorderStyle.FixedSingle;
                        Panel.Name = "Pan" + Field;

                        frm.Controls["PanDetail"].Controls.Add(Panel);

                    }

                    //if (Index == 1)
                    // frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Clear();

                    /*  if (Percent < 80)
                          frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Add(ComboStr);
                      else*/
                    frm.Controls["PanDetail"].Controls["Pan" + Field].Controls.Add(CharStr);
                }
            }
            private void ChangeFieldColor(String Field, System.Drawing.Color FColor)
            {
                if (!IsDetail(Field))
                    frm.Controls["Pan" + Field].BackColor = FColor;
                else
                    frm.Controls["PanDetail"].Controls["Pan" + Field].BackColor = FColor;
            }
            private void CompleteFieldSize(String Field, String Result)
            {
                //MessageBox.Show(Result.Length.ToString());
                int size = GetFieldSize(Field);

                if (Result.Length > size)
                {
                    Result = Result.Substring(0, size);

                }

                size = size - Result.Length;


                for (int i = 0; i < size; i++)
                {
                    AddControlText(Field, "", 80, Result.Length + i + 1);

                }

                if (!this.IsDetail(Field))
                {

                    frm.Controls["Pan" + Field].Width = this.LastPos + 10;
                }
                else
                {
                    frm.Controls["PanDetail"].Controls["Pan" + Field].Width = this.LastPos + 10;
                }
            }
            public void ProcessFields()
            {
                InitFormProcessing();
                GetFieldResult("LastName");
                _icrProcessor.DeletePreprocessImage();

            }
        }

        public class ICR4
        {
            PICSSXICR _icrProcessor = new PICSSXICR();
            
            private PICImagXpress img = new PICImagXpress();
            public String TemplateName = Application.StartupPath + "\\Templates\\ICRTemplate.tif";
            private String matchedForm;
            private String ImageName;
            private Boolean IsTemplateLoaded = false;

                      
            public bool ProcessImage(String Image)
            {
                this.ImageName = Image;
                if (!IsTemplateLoaded)
                    LoadTemplate();

                LoadImage(Image);
                MatchForms();

                CreateForm();
                CreateFields();
                
                ProcessFields();
                return true;

            }

            public void LoadImage(String Image)
            {
                img.FileName = Image;
                _icrProcessor.hDIB = img.CopyDIB();
                _icrProcessor.PreprocessImage();                    //Preprocess the image 
                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();

               //>> frm.img.hDIB = img.CopyDIB();                       //Show it

                _icrProcessor.hDIB = img.CopyDIB();
                _icrProcessor.RegisterImage();


                SetSpecialImageActions();
                _icrProcessor.PreprocessImage();                    //Preprocess the image 

                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();
              //>>  frm.img.hDIB = img.CopyDIB();                       //Show It





            }
            public void LoadTemplate()
            {
                
                
                this.SetGeneralImageActions();

                img.FileName = TemplateName;                    //Template Form
                _icrProcessor.hDIB = img.CopyDIB();

                //>>frm.img.hDIB = img.CopyDIB();

                //Clean Up the Master
                // _icrProcessor.PreprocessImage();

                // frm.img.hDIB = _icrProcessor.GetPreprocessImagehDIB();


                _icrProcessor.AddTemplateImage(TemplateName.Substring(TemplateName.LastIndexOf("\\") + 1));

                //  _icrProcessor.SetRegistrationTemplate(peRegistrationMarkType.REGMARKTYPE_ANGLE);

                IsTemplateLoaded = true;


            }
            public void CreateForm()
            {
                //Create Templates
                //For processing fields
                _icrProcessor.ClassifierPath = Application.StartupPath + "\\Classifiers\\Data";

                //' MUST CREATE A FORM TO START WITH
                _icrProcessor.CreateForm("SigForm.fdl");
                _icrProcessor.SetFormBounds(0, 0, img.IWidth - 1, img.IHeight - 1);

            }
            public void SetGeneralImageActions()
            {
                // THESE IMAGE-LEVEL OPERATIONS WILL BE AVAILABLE

                // TO ALL IMAGES LOADED INTO THE SMARTSCAN CONTROL

                _icrProcessor.RemoveAllPreprocessImageActions();

                //Set Intelligent Image Operations

                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESKEW, "");
                //  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "2,1");
                //  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");


                // Set Standard Image Operations
                /*  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_HORIZ_LEFT, "");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_HORIZ_RIGHT, "");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "1");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "1");
                  _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "1,15");
                  */

            }
            private bool MatchForms()
            {


                // SEARCH THE TEMPLATE DATA BASE FOR A MATCH

                int minConfidence = 60;
                int lMatchedConfidence = 0;
                int sensitivity = 50;
                matchedForm = _icrProcessor.MatchTemplate(false, false, minConfidence, sensitivity, ref lMatchedConfidence);

                if (matchedForm.Trim() == "")
                {
                    MessageBox.Show("Form doesn't match ---" + matchedForm);
                    return false;
                }


                img.hDIB = _icrProcessor.GetPreprocessImagehDIB();
                _icrProcessor.hDIB = img.CopyDIB();



                //  this.SetSpecialImageActions();
                //  _icrProcessor.PreprocessImage();  //Preprocess the image 
                //  img.hDIB = _icrProcessor.GetPreprocessImagehDIB();




                return true;

            }
            public void CreateFields()
            {

                int Top;
                int Height;
                int Left;
                int Width;


                do
                {
                    _icrProcessor.RemoveFieldPreprocessImageAction(1);

                } while (_icrProcessor.SSError == 0);


                //' ADD A FIELD TO THE FORM
                //Left,Top,Width,Height

                // if (img.IWidth.ToString() != this.TempWidth.ToString())
                //          MessageBox.Show(img.IWidth.ToString() + "--" + this.TempWidth.ToString());

                int MarginErr = 1710 - img.IWidth;
                if (MarginErr < 0)
                    MarginErr = 0;

                this.AddField("LastName", 55 - MarginErr, 153, 436, 63, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha); //+ (int)peCharacterSet.CHARSET_SS_LowerCaseAlpha
                this.AddField("FirstName", 535 - MarginErr, 154, 445, 64, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha); //+ (int)peCharacterSet.CHARSET_SS_LowerCaseAlpha
                this.AddField("ParentAddress", 53 - MarginErr, 245, 923, 63, (int)(peCharacterSet.CHARSET_SS_UpperCaseAlpha + (int)peCharacterSet.CHARSET_SS_Digits));
                this.AddField("City", 53 - MarginErr, 332, 589, 62, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("State", 685 - MarginErr, 332, 92, 62, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("ZipCode", 815 - MarginErr, 332, 174, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("DayPhone", 53 - MarginErr, 413, 344, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("CellPhone", 547 - MarginErr, 416, 343, 62, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("Teacher", 53 - MarginErr, 502, 619, 67, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("SchoolName", 683 - MarginErr, 502, 992, 67, (int)peCharacterSet.CHARSET_SS_UpperCaseAlpha);
                this.AddField("SchoolUse", 756 - MarginErr, 2025, 200, 73, (int)peCharacterSet.CHARSET_SS_Digits);
                this.AddField("SUDecimal", 958 - MarginErr, 2025, 86, 75, (int)peCharacterSet.CHARSET_SS_Digits);


                // Codes Fields
                Int16 GenTop = 596;

                Top = GenTop;
                Height = 54 + 12;
                Left = 400;
                Width = 160;

                for (int i = 1; i <= 40; i++)
                {
                    if (i == 21)
                    {
                        Left += 645;
                        Top = GenTop;
                    }

                    this.AddField("Code" + i.ToString(), Left - MarginErr, Top, Width, Height, (int)peCharacterSet.CHARSET_SS_Digits);
                    Top = Top + Height;
                }

                // Quantities Codes Fields

                Top = GenTop;
                Height = 54 + 12;
                Left = 570;
                Width = 85;

                for (int i = 1; i <= 40; i++)
                {
                    if (i == 21)
                    {
                        Left += 635;
                        Top = GenTop;
                    }

                    this.AddField("Quantity" + i.ToString(), Left - MarginErr, Top, Width, Height, (int)peCharacterSet.CHARSET_SS_Digits);
                    Top = Top + Height;

                }

            }
            private void AddField(String Name, int Left, int Top, int Width, int Height, int CharSet)
            {

                _icrProcessor.RemoveFormField(Name);
                _icrProcessor.AddFormField(Name);
                _icrProcessor.SetFieldBounds(Left, Top, Width, Height);
                _icrProcessor.FieldRecCharacterSet = CharSet;
                this.SetGeneralActionsFields();

            }
            private void SetGeneralActionsFields()
            {
                _icrProcessor.FieldType = peFieldType.FIELDTYPE_ICR;


                //Set Intelligent Image Operations

                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESKEW, "");
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "1,1");
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");


                /*  // Set Standard Image Operations
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_HORIZ_LEFT, "");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_HORIZ_RIGHT, "");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "2");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                  _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "2,2");
                  */

                // pePreprocessImageAction.
                // _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_BLACK, "2");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_ERODE_VERT_UP, "");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_VERT_UP, "");
                //_icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_BLACK, "1");
                //_icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_BLACK, "1");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "1");
                _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "1,15");


                /* _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DILATE_VERT_UP, "");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "3");
                 _icrProcessor.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "3,15");
                 */

                _icrProcessor.FormFieldRetainImage = true;
            }
            public void SetSpecialImageActions()
            {
                _icrProcessor.RemoveAllPreprocessImageActions();

                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DESPECKLE, "2,2");
                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_DELETE_BLACK_BORDER, "");
                _icrProcessor.AddPreprocessImageAction(-1, pePreprocessImageAction.PP_REMOVE_LINES, "");

            }
            public void InitFormProcessing()
            {
                // Go on with the processing:
                _icrProcessor.SelectForm(matchedForm);
                _icrProcessor.StartFormProcessing();
            }
            public String GetFieldResult(String Field)
            {

                _icrProcessor.FormFieldDefaultType = peFieldType.FIELDTYPE_ICR;
                _icrProcessor.SelectFormField(Field);   //All this preprocess is applied to the current field


                //    MessageBox.Show("Form : " + _icrProcessor.GetFormName() + " Field: " + _icrProcessor.GetFieldName() + " \r\n" +
                //                 "Error : " + _icrProcessor.FieldError.ToString() + "  " + _icrProcessor.FieldErrorString + " \r\n" +
                //                 "Result: " + _icrProcessor.FieldResultStr);


                //Reading Fields
                int pLeft = 0, pTop = 0, pWidth = 0, pHeight = 0;
                Color[] mColor = new Color[] { Color.Red, Color.Green, Color.Blue };
                String charResult = "";

                if (_icrProcessor.FieldError != 0)
                {
                    MessageBox.Show(_icrProcessor.FieldError.ToString());
                }

                _icrProcessor.GetFieldBounds(ref pLeft, ref pTop, ref pWidth, ref pHeight);

                //draw where the fields are on the image, for illustration purposes only
                // frm.img.ColorDepth(24, PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized, PegasusImaging.WinForms.ImagXpress7.enumDithered.DI_None);
                //>>frm.img.DrawWidth = 4;

                //Process Multi Fields

                //>>frm.imgXField.hDIB = _icrProcessor.FieldResultImagehDIB;
                //  MessageBox.Show("Wait...");
                Application.DoEvents();

                if (_icrProcessor.FieldError == 0)
                {
                    for (int i = 1; _icrProcessor.FieldResultNumLines + 1 != i; i++)
                    {
                        _icrProcessor.FieldResultLine = i;

                        charResult = "";
                        int ControlIndex = 1;
                        for (int charIndex = 1; _icrProcessor.FieldResultLineNumChars + 1 != charIndex; charIndex++)
                        {
                            _icrProcessor.FieldResultLineChar = charIndex;
                            _icrProcessor.FieldResultChar(0);

                            if (_icrProcessor.FieldResultChar(0) == " " && IsDetail(Field))
                            {
                                continue;
                            }

                            if (GetFieldSize(Field) <= charResult.Trim().Length)
                            {
                                break;
                            }


                            charResult = charResult + _icrProcessor.FieldResultChar(0);
                          //>>  AddControlText(Field, _icrProcessor.FieldResultChar(0), _icrProcessor.FieldResultCharConfidence, ControlIndex);
                            ControlIndex++;

                        }

                        if (_icrProcessor.FieldResultLineConfidence <= 60)
                        {
                            //>>frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Red);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Red);
                        }
                        else if (_icrProcessor.FieldResultLineConfidence <= 80)
                        {
                            //>>frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Green);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Green);
                        }
                        else
                        {
                            //>>frm.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.Black);
                            this.ChangeFieldColor(Field, System.Drawing.Color.Black);

                        }

                    }

                    


                }

                return charResult;

            } //Compbined Procedure with form
            private int GetFieldSize(String Field)
            {
                int size = 0;
                switch (Field)
                {
                    case "LastName":
                        size = 14;
                        break;
                    case "FirstName":
                        size = 14;
                        break;
                    case "ParentAddress":
                        size = 30;
                        break;
                    case "City":
                        size = 14;
                        break;
                    case "State":
                        size = 2;
                        break;
                    case "ZipCode":
                        size = 5;
                        break;
                    case "DayPhone":
                        size = 10;
                        break;
                    case "CellPhone":
                        size = 10;
                        break;
                    case "Teacher":
                        size = 20;
                        break;
                    case "SchoolName":
                        size = 32;
                        break;
                    case "SchoolUse":
                        size = 4;
                        break;
                    case "SUDecimal":
                        size = 4;
                        break;

                    default:
                        {
                            if (Field.Substring(0, 4) == "Code" || (Field.Length >= 8 && Field.Substring(0, 8) == "Quantity"))
                            {
                                size = 4;

                            }
                            break;
                        }

                }

                return size;
            }
            private bool IsDetail(String Field)
            {
                if (Field.Substring(0, 4) == "Code" || (Field.Length > 8 && Field.Substring(0, 8) == "Quantity"))
                    return true;
                else
                    return false;
            }
            
            private void ChangeFieldColor(String Field, System.Drawing.Color FColor)
            {
           
            }
            
            public void ProcessFields()
            {
                InitFormProcessing();
                MessageBox.Show(GetFieldResult("LastName"));
                _icrProcessor.DeletePreprocessImage();

            }


        }
        #endregion

        

        

        

        

    }

}