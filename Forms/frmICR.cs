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
    public class frmICR : System.Windows.Forms.Form, IMessageFilter
    {
        private IContainer components;

        private Button btProcessImage;
        private Button bNextImage;
        
        private PICImagXpress imgXField;
        private PICImagXpress img;
        
        
        private Button btSetupSchool;

        private String _CompanyID;
        private String _CustomerID;
        private String _Batch;
        private String _Teacher;

        private FileInfo[] files;
        public int curImage = -1;
        private Button txtAdquire;
        private ICRProcessor icrProcessor = new ICRProcessor();
        private ScannedImage oBatch = new ScannedImage();

        
        private bool msgfilter;
        private CTwain tw;
        private int picnumber = 0;
        static BITMAPINFOHEADER bmi;
        static Rectangle bmprect;
           

        public frmICR()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            GetGlobalParameters();
            img.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;

            tw = new CTwain();
            tw.Init(this.Handle);
        }  //Constructor

        
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btProcessImage = new System.Windows.Forms.Button();
            this.img = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.bNextImage = new System.Windows.Forms.Button();
            this.imgXField = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.btSetupSchool = new System.Windows.Forms.Button();
            this.txtAdquire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btProcessImage
            // 
            this.btProcessImage.Location = new System.Drawing.Point(261, 13);
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
            this.img.Location = new System.Drawing.Point(12, 49);
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
            this.img.Size = new System.Drawing.Size(756, 584);
            this.img.SN = "PEXPL700AL-28EWFI88YN1";
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
            // bNextImage
            // 
            this.bNextImage.Location = new System.Drawing.Point(370, 13);
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
            this.imgXField.Location = new System.Drawing.Point(8, 651);
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
            this.imgXField.Size = new System.Drawing.Size(756, 133);
            this.imgXField.SN = "PEXPL700AL-28EWFI88YN1";
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
            // txtAdquire
            // 
            this.txtAdquire.Location = new System.Drawing.Point(127, 12);
            this.txtAdquire.Name = "txtAdquire";
            this.txtAdquire.Size = new System.Drawing.Size(109, 30);
            this.txtAdquire.TabIndex = 42;
            this.txtAdquire.Text = "Adquire";
            this.txtAdquire.UseVisualStyleBackColor = true;
            this.txtAdquire.Click += new System.EventHandler(this.txtAdquire_Click);
            // 
            // frmICR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 796);
            this.Controls.Add(this.txtAdquire);
            this.Controls.Add(this.btSetupSchool);
            this.Controls.Add(this.imgXField);
            this.Controls.Add(this.bNextImage);
            this.Controls.Add(this.img);
            this.Controls.Add(this.btProcessImage);
            this.MinimizeBox = false;
            this.Name = "frmICR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forms Matching";
            this.Load += new System.EventHandler(this.frmICR_Load);
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
            GetGlobalParameters();

            this.LoadImageFiles();
            this.Left = 20;

            icrProcessor.PictureChanged += new ICRProcessor.EventHandler(icrProcessor_PictureChanged);
        }        
        private void btProcessImage_Click(object sender, EventArgs e)
        {
            Run();
        }
        private void bNextImage_Click(object sender, EventArgs e)
        {
            if (NextImage())
                Run();
        }
        private void btSetupSchool_Click(object sender, EventArgs e)
        {
            Signature.Twain.frmSetupCustomer frm = new Signature.Twain.frmSetupCustomer();
             frm.ShowDialog();
            GetGlobalParameters();
            LoadImageFiles();
            curImage = -1;
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
                            MessageBox.Show(ex.Message);
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
                            MessageBox.Show(ex.Message);
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
                            MessageBox.Show(ex.Message);
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
        private void txtAdquire_Click(object sender, EventArgs e)
        {

            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Acquire((short)0, (short)1);

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
        public bool Run()
        {
            if (!(files.Length == 0) && curImage != -1)
            {
                Text = "Image - " + files[curImage].FullName;
                if (!icrProcessor.ProcessImage(files[curImage].FullName))
                    return false;
                this.CreateOrder();
            }
            else
            {
                MessageBox.Show("There is no images to process");
                return false;

            }
            return true;

        }
        private void CreateOrder()
            {

                
                Order oOrder = new Order(_CompanyID); 
            
                //Saving Order to SQL Server

                oOrder.CompanyID = _CompanyID;
                oOrder.CustomerID = _CustomerID;
                oOrder.Teacher = _Teacher;

                oOrder.Student = icrProcessor.Fields["LastName"].Result + ", " + icrProcessor.Fields["FirstName"].Result;

            
                Application.DoEvents();
                
                String Code, Quantity;

                for (int i = 1; i <= 30; i++)
                {

                    Code = icrProcessor.Fields["Code" + i.ToString()].GetResult();
                    Quantity = icrProcessor.Fields["Quantity" + i.ToString()].GetResult();

                    Code = Code.Trim();
                    Quantity = Quantity.Trim();
                    //oOrder.oProduct.CompanyID = _CompanyID;

                    oOrder.oCustomer.Find(_CustomerID);

                    if (Code != "" && Code.Length == 4)
                    {
                        if (oOrder.oProduct.Find(Code) && Quantity != "")
                        {
                            Order.Item Item = new Order.Item();
                            Item.ProductID = oOrder.oProduct.ID;
                            Item.Quantity = Convert.ToInt32(Quantity.Trim());
                            Item.Description = oOrder.oProduct.Description;
                            Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                            oOrder.Items.Add(oOrder.oProduct.ID, Item);
                            oOrder.GetTotals();

                        }
                    }

                }

                frmOrder ofrmOrder = new frmOrder(oOrder);
                ofrmOrder._OrderProcess = (int)OrderProcess.Discrepancy;
                ofrmOrder.ShowDialog();

               
        }
        private bool IsDetail(String Field)
            {
                if (Field.Substring(0, 4) == "Code" || (Field.Length > 8 && Field.Substring(0, 8) == "Quantity"))
                    return true;
                else
                    return false;
            }
        public String GetControlResultValues(String Panel)         //Panel is the field
            {
                String ResultStr = "";

                if (!this.IsDetail(Panel))
                {

                    for (int i = 1; i <=  Controls["Pan" + Panel].Controls.Count; i++)
                    {
                        
                        ResultStr +=  Controls["Pan" + Panel].Controls[i.ToString()].Text;

                    }
                }
                else
                {    
                    if ( Controls["PanDetail"].Controls["Pan"+ Panel] != null)
                        {
                           for (int i = 1; i <=  Controls["PanDetail"].Controls["Pan" + Panel].Controls.Count; i++)
                             {
                               ResultStr +=  Controls["PanDetail"].Controls["Pan" + Panel].Controls[i.ToString()].Text;
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


                //MessageBox.Show("Order-" +  _CompanyID.PadLeft(2, '0') +  _CustomerID.PadLeft(4, '0') +  _Batch.PadLeft(3, '0') + "*.tif");
                // Examine all contained files.
                files = directory.GetFiles("Order-" +  _CompanyID.PadLeft(2, '0') +  _CustomerID.PadLeft(4, '0') +  _Batch.PadLeft(3, '0') + "*.tif*");

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
                        int ImgNumber = 0;

                        ArrayList pics = tw.TransferPictures();
                        EndingScan();
                        tw.CloseSrc();
                        picnumber++;

                        if (oBatch.Find(_CompanyID, _CustomerID, _Teacher))
                            {
                                //ImgNumber = oBatch._ImageFinal;
                            }

                        //    oBatch._ImageInitial = 1;
                            oBatch.CompanyID = _CompanyID;
                        //    oBatch.CustomerID = _CustomerID;


                        int i;
                        for (i = 0; i < pics.Count; i++)
                        {

                            IntPtr img = (IntPtr)pics[i];

                            {

                                bmprect = new Rectangle(0, 0, 0, 0);
                                bmpptr = GlobalLock(img);
                                pixptr = GetPixelInfo(bmpptr);
                                int picnum = ImgNumber + i + 1;

                                //Gdip.SavePicToFile("ScanPass" + picnum.ToString() + ".tiff", bmpptr, pixptr);
                                Gdip.SavePicToFile("Images/Order-" + _CompanyID.PadLeft(2, '0') + _CustomerID.PadLeft(4, '0') + _Batch.PadLeft(3, '0') + picnum.ToString().PadLeft(4, '0') + ".tif", bmpptr, pixptr);
                            }

                        }
                        
                            //Save Batch Here

                            //oBatch._ImageFinal = ImgNumber + i;
                            //oBatch._NumberImages += i;
                            //oBatch.Teacher = _Teacher;
                            oBatch.Save();

                        

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

    }

}