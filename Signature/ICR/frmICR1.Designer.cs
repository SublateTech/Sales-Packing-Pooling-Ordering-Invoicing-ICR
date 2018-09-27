namespace Signature
{
    partial class frmICR1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.PicImagXpress1 = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
            this.introductionLabel = new System.Windows.Forms.Label();
            this.ProcessICRFields = new System.Windows.Forms.Button();
            this.Picssxicr1 = new PegasusImaging.WinForms.SSXICR4.PICSSXICR();
            this.resultsList = new System.Windows.Forms.ListView();
            this.FieldIndex = new System.Windows.Forms.ColumnHeader();
            this.FieldName = new System.Windows.Forms.ColumnHeader();
            this.FieldResult = new System.Windows.Forms.ColumnHeader();
            this.CharacterResults = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // PicImagXpress1
            // 
            this.PicImagXpress1.AddOnBehavior = PegasusImaging.WinForms.ImagXpress7.enumAddOnBehavior.ADDONBEHAVIOR_ShowEval;
            this.PicImagXpress1.AlignH = PegasusImaging.WinForms.ImagXpress7.enumAlignH.ALIGNH_Center;
            this.PicImagXpress1.AlignV = PegasusImaging.WinForms.ImagXpress7.enumAlignV.ALIGNV_Center;
            this.PicImagXpress1.AspectX = 1;
            this.PicImagXpress1.AspectY = 1;
            this.PicImagXpress1.Async = false;
            this.PicImagXpress1.AsyncCancelOnClose = false;
            this.PicImagXpress1.AsyncMaxThreads = 4;
            this.PicImagXpress1.AsyncPriority = PegasusImaging.WinForms.ImagXpress7.enumAsyncPriority.ASYNC_Normal;
            this.PicImagXpress1.AutoClose = true;
            this.PicImagXpress1.AutoInvalidate = true;
            this.PicImagXpress1.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_CropImage;
            this.PicImagXpress1.BorderType = PegasusImaging.WinForms.ImagXpress7.enumBorderType.BORD_Inset;
            this.PicImagXpress1.CancelLoad = false;
            this.PicImagXpress1.CancelMode = PegasusImaging.WinForms.ImagXpress7.enumCancelMode.CM_None;
            this.PicImagXpress1.CancelRemove = false;
            this.PicImagXpress1.CompressInMemory = PegasusImaging.WinForms.ImagXpress7.enumCompressInMemory.CMEM_NONE;
            this.PicImagXpress1.CropX = 0;
            this.PicImagXpress1.CropY = 0;
            this.PicImagXpress1.DIBXPos = -1;
            this.PicImagXpress1.DIBYPos = -1;
            this.PicImagXpress1.DisplayError = false;
            this.PicImagXpress1.DisplayMode = PegasusImaging.WinForms.ImagXpress7.enumPicDisplayMode.DM_TrueColor;
            this.PicImagXpress1.DrawFillColor = System.Drawing.Color.Black;
            this.PicImagXpress1.DrawFillStyle = PegasusImaging.WinForms.ImagXpress7.enumFillStyle.FILL_Transparent;
            this.PicImagXpress1.DrawMode = PegasusImaging.WinForms.ImagXpress7.enumDrawMode.PEN_CopyPen;
            this.PicImagXpress1.DrawStyle = PegasusImaging.WinForms.ImagXpress7.enumBorderStyle.STYLE_Solid;
            this.PicImagXpress1.DrawWidth = 1;
            this.PicImagXpress1.Edition = PegasusImaging.WinForms.ImagXpress7.enumEdition.EDITION_Prof;
            this.PicImagXpress1.EvalMode = PegasusImaging.WinForms.ImagXpress7.enumEvaluationMode.EVAL_Automatic;
            this.PicImagXpress1.FileName = "";
            this.PicImagXpress1.FileOffsetUse = PegasusImaging.WinForms.ImagXpress7.enumFileOffsetUse.FO_IMAGE;
            this.PicImagXpress1.FileTimeout = 10000;
            this.PicImagXpress1.FTPMode = PegasusImaging.WinForms.ImagXpress7.enumFTPMode.FTP_ACTIVE;
            this.PicImagXpress1.FTPPassword = "";
            this.PicImagXpress1.FTPUserName = "";
            this.PicImagXpress1.IResUnits = PegasusImaging.WinForms.ImagXpress7.enumIRes.IRes_NA;
            this.PicImagXpress1.IResX = 0;
            this.PicImagXpress1.IResY = 0;
            this.PicImagXpress1.JPEGCosited = false;
            this.PicImagXpress1.JPEGEnhDecomp = true;
            this.PicImagXpress1.LoadCropEnabled = false;
            this.PicImagXpress1.LoadCropHeight = 0;
            this.PicImagXpress1.LoadCropWidth = 0;
            this.PicImagXpress1.LoadCropX = 0;
            this.PicImagXpress1.LoadCropY = 0;
            this.PicImagXpress1.LoadResizeEnabled = false;
            this.PicImagXpress1.LoadResizeHeight = 0;
            this.PicImagXpress1.LoadResizeMaintainAspectRatio = true;
            this.PicImagXpress1.LoadResizeWidth = 0;
            this.PicImagXpress1.LoadRotated = PegasusImaging.WinForms.ImagXpress7.enumLoadRotated.LR_NONE;
            this.PicImagXpress1.LoadThumbnail = PegasusImaging.WinForms.ImagXpress7.enumLoadThumbnail.THUMBNAIL_None;
            this.PicImagXpress1.Location = new System.Drawing.Point(12, 35);
            this.PicImagXpress1.LZWPassword = "";
            this.PicImagXpress1.ManagePalette = true;
            this.PicImagXpress1.MaxHeight = 0;
            this.PicImagXpress1.MaxWidth = 0;
            this.PicImagXpress1.MinHeight = 1;
            this.PicImagXpress1.MinWidth = 1;
            this.PicImagXpress1.MousePointer = PegasusImaging.WinForms.ImagXpress7.enumMousePointer.MP_Default;
            this.PicImagXpress1.Multitask = false;
            this.PicImagXpress1.Name = "PicImagXpress1";
            this.PicImagXpress1.Notify = false;
            this.PicImagXpress1.NotifyDelay = 0;
            this.PicImagXpress1.OLEDropMode = PegasusImaging.WinForms.ImagXpress7.enumOLEDropMode.OLEDROP_NONE;
            this.PicImagXpress1.OwnDIB = true;
            this.PicImagXpress1.PageNbr = 0;
            this.PicImagXpress1.Pages = 0;
            this.PicImagXpress1.Palette = PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized;
            this.PicImagXpress1.PDFSwapBlackandWhite = false;
            this.PicImagXpress1.Persistence = true;
            this.PicImagXpress1.PFileName = "";
            this.PicImagXpress1.PICPassword = "";
            this.PicImagXpress1.Picture = null;
            this.PicImagXpress1.PictureEnabled = true;
            this.PicImagXpress1.PrinterBanding = false;
            this.PicImagXpress1.ProgressEnabled = false;
            this.PicImagXpress1.ProgressPct = 10;
            this.PicImagXpress1.ProxyServer = "";
            this.PicImagXpress1.RaiseExceptions = false;
            this.PicImagXpress1.SaveCompressSize = 0;
            this.PicImagXpress1.SaveEXIFThumbnailSize = ((short)(0));
            this.PicImagXpress1.SaveFileName = "";
            this.PicImagXpress1.SaveFileType = PegasusImaging.WinForms.ImagXpress7.enumSaveFileType.FT_DEFAULT;
            this.PicImagXpress1.SaveGIFInterlaced = false;
            this.PicImagXpress1.SaveGIFType = PegasusImaging.WinForms.ImagXpress7.enumGIFType.GIF89a;
            this.PicImagXpress1.SaveJLSInterLeave = 0;
            this.PicImagXpress1.SaveJLSMaxValue = 0;
            this.PicImagXpress1.SaveJLSNear = 0;
            this.PicImagXpress1.SaveJLSPoint = 0;
            this.PicImagXpress1.SaveJP2Order = PegasusImaging.WinForms.ImagXpress7.enumProgressionOrder.PO_DEFAULT;
            this.PicImagXpress1.SaveJP2Type = PegasusImaging.WinForms.ImagXpress7.enumJP2Type.JP2_LOSSY;
            this.PicImagXpress1.SaveJPEGChromFactor = ((short)(10));
            this.PicImagXpress1.SaveJPEGCosited = false;
            this.PicImagXpress1.SaveJPEGGrayscale = false;
            this.PicImagXpress1.SaveJPEGLumFactor = ((short)(10));
            this.PicImagXpress1.SaveJPEGProgressive = false;
            this.PicImagXpress1.SaveJPEGSubSampling = PegasusImaging.WinForms.ImagXpress7.enumSaveJPEGSubSampling.SS_411;
            this.PicImagXpress1.SaveLJPCompMethod = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompMethod.LJPMETHOD_JPEG;
            this.PicImagXpress1.SaveLJPCompType = PegasusImaging.WinForms.ImagXpress7.enumSaveLJPCompType.LJPTYPE_RGB;
            this.PicImagXpress1.SaveLJPPrediction = ((short)(1));
            this.PicImagXpress1.SaveMultiPage = false;
            this.PicImagXpress1.SavePBMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.PicImagXpress1.SavePDFCompression = PegasusImaging.WinForms.ImagXpress7.enumSavePDFCompression.PDF_Uncompressed;
            this.PicImagXpress1.SavePDFSwapBlackandWhite = false;
            this.PicImagXpress1.SavePGMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.PicImagXpress1.SavePNGInterlaced = false;
            this.PicImagXpress1.SavePPMType = PegasusImaging.WinForms.ImagXpress7.enumPortableType.PT_Binary;
            this.PicImagXpress1.SaveTIFFByteOrder = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFByteOrder.TIFF_INTEL;
            this.PicImagXpress1.SaveTIFFCompression = PegasusImaging.WinForms.ImagXpress7.enumSaveTIFFCompression.TIFF_Uncompressed;
            this.PicImagXpress1.SaveTIFFRowsPerStrip = 0;
            this.PicImagXpress1.SaveTileHeight = 0;
            this.PicImagXpress1.SaveTileWidth = 0;
            this.PicImagXpress1.SaveToBuffer = false;
            this.PicImagXpress1.SaveTransparencyColor = System.Drawing.Color.Black;
            this.PicImagXpress1.SaveTransparent = PegasusImaging.WinForms.ImagXpress7.enumTransparencyMatch.TRANSPARENT_None;
            this.PicImagXpress1.SaveWSQBlack = ((short)(0));
            this.PicImagXpress1.SaveWSQQuant = 1;
            this.PicImagXpress1.SaveWSQWhite = ((short)(255));
            this.PicImagXpress1.ScaleResizeToGray = false;
            this.PicImagXpress1.ScrollBarLargeChangeH = 10;
            this.PicImagXpress1.ScrollBarLargeChangeV = 10;
            this.PicImagXpress1.ScrollBars = PegasusImaging.WinForms.ImagXpress7.enumScrollBars.SB_None;
            this.PicImagXpress1.ScrollBarSmallChangeH = 1;
            this.PicImagXpress1.ScrollBarSmallChangeV = 1;
            this.PicImagXpress1.ShowHourglass = false;
            this.PicImagXpress1.Size = new System.Drawing.Size(691, 641);
            this.PicImagXpress1.SN = "PEXPS700U3-AJNYECS5XP3";
            this.PicImagXpress1.SpecialTIFFHandling = false;
            this.PicImagXpress1.TabIndex = 5;
            this.PicImagXpress1.Text = "PicImagXpress1";
            this.PicImagXpress1.TIFFIFDOffset = 0;
            this.PicImagXpress1.Timer = 0;
            this.PicImagXpress1.TWAINManufacturer = "";
            this.PicImagXpress1.TWAINProductFamily = "";
            this.PicImagXpress1.TWAINProductName = "";
            this.PicImagXpress1.TWAINVersionInfo = "";
            this.PicImagXpress1.UndoEnabled = false;
            this.PicImagXpress1.ViewAntialias = true;
            this.PicImagXpress1.ViewBrightness = ((short)(0));
            this.PicImagXpress1.ViewContrast = ((short)(0));
            this.PicImagXpress1.ViewDithered = true;
            this.PicImagXpress1.ViewGrayMode = PegasusImaging.WinForms.ImagXpress7.enumGrayMode.GRAY_Standard;
            this.PicImagXpress1.ViewProgressive = false;
            this.PicImagXpress1.ViewSmoothing = true;
            this.PicImagXpress1.ViewUpdate = true;
            this.PicImagXpress1.WMFConvert = false;
            // 
            // introductionLabel
            // 
            this.introductionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.introductionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introductionLabel.Location = new System.Drawing.Point(819, 20);
            this.introductionLabel.Name = "introductionLabel";
            this.introductionLabel.Size = new System.Drawing.Size(427, 49);
            this.introductionLabel.TabIndex = 7;
            // 
            // ProcessICRFields
            // 
            this.ProcessICRFields.Location = new System.Drawing.Point(1086, 628);
            this.ProcessICRFields.Name = "ProcessICRFields";
            this.ProcessICRFields.Size = new System.Drawing.Size(160, 48);
            this.ProcessICRFields.TabIndex = 6;
            this.ProcessICRFields.Text = "Process ICR Fields";
            this.ProcessICRFields.Click += new System.EventHandler(this.ProcessICRFields_Click);
            // 
            // Picssxicr1
            // 
            this.Picssxicr1.ClassifierPath = "";
            this.Picssxicr1.DisplayError = false;
            this.Picssxicr1.Enabled = true;
            this.Picssxicr1.EvalMode = PegasusImaging.WinForms.SSXICR4.peEvaluationMode.EVAL_Automatic;
            this.Picssxicr1.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
            this.Picssxicr1.InkColor = PegasusImaging.WinForms.SSXICR4.peInkColor.INKCOLOR_Black;
            this.Picssxicr1.LicenseMode = PegasusImaging.WinForms.SSXICR4.peLicenseMode.LICENSEMODE_ICR_OCR_OMR;
            this.Picssxicr1.OwnDIB = true;
            this.Picssxicr1.Picture = null;
            this.Picssxicr1.RaiseExceptions = false;
            this.Picssxicr1.SN = "PSIPU400QJ-TKEKJ98XAYW";
            this.Picssxicr1.SSEdition = PegasusImaging.WinForms.SSXICR4.peSSEdition.SS_EDITION_Professional;
            // 
            // resultsList
            // 
            this.resultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FieldIndex,
            this.FieldName,
            this.FieldResult,
            this.CharacterResults});
            this.resultsList.Location = new System.Drawing.Point(12, 682);
            this.resultsList.Name = "resultsList";
            this.resultsList.Size = new System.Drawing.Size(592, 96);
            this.resultsList.TabIndex = 8;
            this.resultsList.UseCompatibleStateImageBehavior = false;
            this.resultsList.View = System.Windows.Forms.View.Details;
            // 
            // FieldIndex
            // 
            this.FieldIndex.Text = "Field Index";
            this.FieldIndex.Width = 70;
            // 
            // FieldName
            // 
            this.FieldName.Text = "Field Name";
            this.FieldName.Width = 120;
            // 
            // FieldResult
            // 
            this.FieldResult.Text = "Field Result";
            this.FieldResult.Width = 190;
            // 
            // CharacterResults
            // 
            this.CharacterResults.Text = "Character Results";
            this.CharacterResults.Width = 190;
            // 
            // frmICR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 790);
            this.Controls.Add(this.resultsList);
            this.Controls.Add(this.introductionLabel);
            this.Controls.Add(this.ProcessICRFields);
            this.Controls.Add(this.PicImagXpress1);
            this.Name = "frmICR";
            this.Text = "frmICR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmICR_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal PegasusImaging.WinForms.ImagXpress7.PICImagXpress PicImagXpress1;
        internal System.Windows.Forms.Label introductionLabel;
        internal System.Windows.Forms.Button ProcessICRFields;
        internal PegasusImaging.WinForms.SSXICR4.PICSSXICR Picssxicr1;
        internal System.Windows.Forms.ListView resultsList;
        internal System.Windows.Forms.ColumnHeader FieldIndex;
        internal System.Windows.Forms.ColumnHeader FieldName;
        internal System.Windows.Forms.ColumnHeader FieldResult;
        internal System.Windows.Forms.ColumnHeader CharacterResults;
    }
}