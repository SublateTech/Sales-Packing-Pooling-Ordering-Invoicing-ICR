using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

using PegasusImaging.WinForms.FormFix3;
using PegasusImaging.WinForms.ImagXpress9;
using PegasusImaging.WinForms.NotateXpress9;
using PegasusImaging.WinForms.SmartZone2;
using PegasusImaging.WinForms.ScanFix5;
using Signature.Data;
using Signature.Classes;



namespace Signature.Zonal
{
    public class ZonalProcessor
    {

        #region Properties
        //Zonal Version
        private PegasusImaging.WinForms.NotateXpress9.NotateXpress notateXpress1;

        private PegasusImaging.WinForms.FormFix3.FormFix    formFix1;
        private PegasusImaging.WinForms.FormFix3.FormImage  frmTemplateImage;
        private PegasusImaging.WinForms.FormFix3.FormImage  frmFilledImage;
        private PegasusImaging.WinForms.FormFix3.FormImage  frmAlignedImage;
        private PegasusImaging.WinForms.FormFix3.RegistrationProcessor regProcessor;
        private PegasusImaging.WinForms.FormFix3.RegistrationResult regResult;

        

        private Layer currentLayer;

        private PegasusImaging.WinForms.SmartZone2.SmartZone SmartZone2;

        private PegasusImaging.WinForms.ImagXpress9.ImagXpress imagXpress1;
        private PegasusImaging.WinForms.ImagXpress9.ImageXView InputImg;
        public  PegasusImaging.WinForms.ImagXpress9.ImageXView OutputImg;
        public PegasusImaging.WinForms.ImagXpress9.ImageXView  OutputFieldImg;
       

        private PegasusImaging.WinForms.SmartZone2.TextBlockResult myTextBlockRes;
        private PegasusImaging.WinForms.SmartZone2.TextLineResult LineResult;
        

        private PegasusImaging.WinForms.ScanFix5.ScanFix scanFix1;
        
        private PegasusImaging.WinForms.ScanFix5.CombRemovalOptions comb;
        private PegasusImaging.WinForms.ScanFix5.DotShadingRemovalOptions dot;
        private PegasusImaging.WinForms.ScanFix5.InverseTextOptions text;
        private PegasusImaging.WinForms.ScanFix5.NegativeCorrectionOptions neg;
        private PegasusImaging.WinForms.ScanFix5.BlobRemovalOptions blob;
        private PegasusImaging.WinForms.ScanFix5.BorderRemovalOptions border;

        private System.ComponentModel.IContainer components;



        public String TemplateFile = @"I:\Templates\Order_Template.tif"; //Application.StartupPath + "\\Templates\\ICRTemplate1.tif";
        
        
        public _ICRFields Fields;
        public String  ErrorMsg="";
        private Boolean IsTemplateLoaded = false;
        private Boolean IsFilledAligned = false;
        #endregion

        #region Events 
        public delegate void EventHandler (object sender, ZonalProcessor.ImageEvenArgs e);
        public event EventHandler PictureChanged;
        public virtual void OnPictureChanged(ICRType icrType)
        {
            if (PictureChanged != null)
            {
                ImageEvenArgs Event = new ImageEvenArgs();
                
                Event.type = icrType;

                switch (icrType)
                {
                    case ZonalProcessor.ICRType.Field:
                    case ZonalProcessor.ICRType.FieldProcessed:
                        {
                        //    Event.img.Image = this.Fields.img.Image.Copy();
                            break;
                        }
                    case ZonalProcessor.ICRType.Image:
                    case ZonalProcessor.ICRType.ImageMatched:
                    case ZonalProcessor.ICRType.ImageProcessed:
                    case ZonalProcessor.ICRType.Template:
                    case ZonalProcessor.ICRType.TemplateProcessed:
                    case ZonalProcessor.ICRType.ImageMarked:
                        {

                          //  Event.img.Image = this.Fields.img.Image.Copy();
                            break;
                        }
                }
                
                PictureChanged(this, Event);
            }
        }
        #endregion

        #region Constructor
        public ZonalProcessor()
        {

            this.InitializeComponent();

            Fields = new _ICRFields();
            this.SetGeneralParameters();

            notateXpress1.ClientWindow = OutputImg.Handle;
            currentLayer = new Layer();
            notateXpress1.Layers.Add(currentLayer);

        }
        #endregion

        #region Methods
        private void InitializeComponent()
        {


            this.components = new System.ComponentModel.Container();

            this.formFix1 = new FormFix(this.components);
            this.formFix1.Debug = false;
            this.formFix1.DebugLogFile = "C:\\Documents and Settings\\jargento.JPG.COM\\My Documents\\FormFix3.log";
            this.formFix1.ErrorLevel = PegasusImaging.WinForms.FormFix3.ErrorLevel.Production;



            this.SmartZone2 = new SmartZone();
            this.SmartZone2.Reader.Classifier = Classifier.HandPrint;
            this.SmartZone2.Reader.CharacterSet.Language = Language.English;
            this.SmartZone2.Licensing.LicenseEdition = PegasusImaging.WinForms.SmartZone2.LicenseEditionType.IcrOcrProfessionalEdition;


            this.imagXpress1 = new ImagXpress(this.components);
            this.InputImg = new ImageXView(this.components);
            this.OutputImg = new ImageXView(this.components);
            this.OutputFieldImg = new ImageXView(this.components);
            this.notateXpress1 = new NotateXpress(this.components);

            this.scanFix1 = new ScanFix(this.components);

            scanFix1.License.LicenseEdition = PegasusImaging.WinForms.ScanFix5.License.LicenseChoice.BitonalEdition;


            //****Must call the UnlockRuntime function *****
            this.imagXpress1.Licensing.UnlockRuntime(1908209139, 373711808, 1340714821, 15519);

            this.scanFix1.License.UnlockRuntime(192088888, 871219288, 1837565222, 12308);


            this.SmartZone2.Licensing.LicenseEdition = PegasusImaging.WinForms.SmartZone2.LicenseEditionType.IcrOcrProfessionalEdition;
            this.SmartZone2.Licensing.UnlockRunTime(192088888, 871219288, 1837565222, 12308);

            this.formFix1.Licensing.UnlockRuntime(1288805975, 1989022510, 780270913, 19622);
            this.formFix1.Licensing.LicenseEdition = PegasusImaging.WinForms.FormFix3.LicenseEditionType.Professional;
            
            
            
            
            
        }
        public void Test()
        {
            #region Load Template
            try
            {
                InputImg.Image = ImageX.FromFile(imagXpress1, @"I:\Templates\ICRTemplate.tif");
                frmTemplateImage = FormImage.FromHdib(InputImg.Image.ToHdib(false), true, formFix1);

                InputImg.Image = ImageX.FromHdib(imagXpress1, (System.IntPtr)0, true);
                OutputImg.Image = ImageX.FromHdib(imagXpress1, (System.IntPtr)0, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Load Image
            String ImageName = @"I:\Images\Order-0000000153.TIFF";
            try
            {
                InputImg.Image  = ImageX.FromFile(imagXpress1, ImageName);
                frmFilledImage  = FormImage.FromHdib(InputImg.Image.ToHdib(false), true, formFix1);

                OutputImg.Image = ImageX.FromHdib(imagXpress1, (System.IntPtr)0, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //it's all looking good, so we load our image into an ImageX object
            //imageXView1.Image = ImageX.FromFile(imagXpress1, strFileName);
            Processor prc = new Processor(imagXpress1, InputImg.Image);

            if (InputImg.Image.ImageXData.BitsPerPixel != 1)
            {
                prc.ColorDepth(1, PaletteType.Optimized, DitherType.NoDither);
                InputImg.Image = prc.Image;
            }

            
            
            





            #endregion

            #region Register Image
            try
            {
                regProcessor = new RegistrationProcessor(formFix1);

                regResult = regProcessor.RegisterToImage(frmFilledImage, frmTemplateImage);

                frmAlignedImage = regResult.AlignImage(frmFilledImage);

                InputImg.Image = ImageX.FromHdib(imagXpress1, frmAlignedImage.ToHdib(false), true);


                OutputImg.Image = InputImg.Image.Copy();
                OnPictureChanged(ICRType.ImageMatched);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Preprocessing Image
            Processor proc = new Processor(imagXpress1, InputImg.Image);

            if (InputImg.Image.ImageXData.BitsPerPixel != 0)
            {
                proc.ColorDepth(1, 0, 0);
            }

            scanFix1.FromHdib(InputImg.Image.ToHdib(false));

            
            //Remove Lines
            LineRemovalOptions LineOpts = new LineRemovalOptions();
            LineOpts.MinimumLength = 20;
            scanFix1.RemoveLines(LineOpts);
            
            //Despeckle
            DespeckleOptions DespeckOpts = new DespeckleOptions();
            DespeckOpts.SpeckWidth = 10;
            DespeckOpts.SpeckHeight = 14;
            scanFix1.Despeckle(DespeckOpts);

            //Deskew
            scanFix1.Deskew();
            
            //Comb options
            /*
            comb = new PegasusImaging.WinForms.ScanFix5.CombRemovalOptions();

            comb.Area = new System.Drawing.Rectangle(AreaXBar.Value, AreaYBar.Value, AreaWBar.Value, AreaHBar.Value);
            comb.CombHeight = CombHBar.Value;
            comb.CombSpacing = SpaceBar.Value;
            comb.HorizontalLineThickness = HBar.Value;
            comb.VerticalLineThickness = VBar.Value;
            comb.MinimumCombLength = LengthBar.Value;
            comb.MinimumConfidence = ConfidenceBar.Value;

            scanFix1.RemoveCombs(comb);
            */

            //Smooth Options
            //scanFix1.SmoothObjects(SmoothBar.Value);

            
            //Blob Options
            /*
            blob = new PegasusImaging.WinForms.ScanFix5.BlobRemovalOptions();

            blob.Area = new System.Drawing.Rectangle(BlobAreaXBar.Value, BlobAreaYBar.Value, AreaWidthBar.Value, AreaHeightBar.Value);
            blob.MaximumPixelCount = MaxCountBar.Value;
            blob.MinimumPixelCount = MinCountBar.Value;
            blob.MinimumDensity = DensityBar.Value;

            scanFix1.RemoveBlobs(blob);
            */

            //Remove Dot Shading 
            /*
            dot = new PegasusImaging.WinForms.ScanFix5.DotShadingRemovalOptions();

            dot.DensityAdjustment = DotDensityBar.Value;
            dot.MaximumDotSize = DotSizeBar.Value;
            dot.HorizontalSizeAdjustment = HAdjBar.Value;
            dot.VerticalSizeAdjustment = VAdjBar.Value;
            dot.MinimumAreaHeight = DotHBar.Value;
            dot.MinimumAreaWidth = DotWBar.Value;

            scanFix1.RemoveDotShading(dot);
            */

            
            //Remove Border Options
            /*
            border = new PegasusImaging.WinForms.ScanFix5.BorderRemovalOptions();

            border.BorderSpeckSize = BSpeckBar.Value;
            border.CropBorder = chkcrop.Checked;
            border.DeskewBorder = chkdeskew.Checked;
            border.MaximumPageHeight = MaxHeightBar.Value;
            border.MaximumPageWidth = MaxWidthBar.Value;
            border.MinimumConfidence = MinConBar.Value;
            border.MinimumPageHeight = MinHeightBar.Value;
            border.MinimumPageWidth = SpeckWidthBar.Value;
            border.PageSpeckSize = PSpeckBar.Value;
            border.Quality = SpeckQualityBar.Value;
            border.ReplaceBorder = chkreplace.Checked;

            if (true)
            {
                border.PadColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            else
            {
                border.PadColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            scanFix1.RemoveBorder(border);
            */
            #endregion

            #region Read Fields

            InputImg.Image = ImageX.FromHdib(imagXpress1, scanFix1.ToHdib(false));


            // Set area and analyze field DIB
            SmartZone2.Reader.CharacterSet = CharacterSet.AllAlphas;
            Rectangle currentArea = new Rectangle(85,170,603,79);
            SmartZone2.Reader.Area = currentArea;
            myTextBlockRes = SmartZone2.Reader.AnalyzeField(InputImg.Image.ToHdib(false));

           
            if (myTextBlockRes.NumberTextLines > 0)
            {
                Boolean hasResult = true;

                LineResult = myTextBlockRes.TextLine(0);

             //   showBlockResult();
             //   showLineResult(0);
             //   showCharacterResult(0);
            }
            else
            {
                Boolean hasResult = false;
                
            }

            MessageBox.Show(myTextBlockRes.TextLine(0).Text);
            #endregion

            return;
        }

        #region Images
        public Boolean ProcessImage(ICRImage oImage)
        {

            return this.ProcessImage(oImage.FilePath);
        }
        public Boolean ProcessImage(String ImagePath)
        {
            this.ErrorMsg = "";
            if (!IsTemplateLoaded)
                this.LoadTemplate(this.TemplateFile);

            if (!this.LoadImage(ImagePath))
                return false;

            if (!this.RegisterImage())
                return false;

            this.ProcessFields();

            return true;
        }
        private ImageX PreprocessTemplate(ImageX Image)
        {
            scanFix1.FromHdib(Image.ToHdib(false));

            //Remove Lines
            /*          LineRemovalOptions LineOpts = new LineRemovalOptions();
                      LineOpts.MinimumLength = 10;
                      scanFix1.RemoveLines(LineOpts);
          */
            

            
            //Comb options
            /*
            comb = new PegasusImaging.WinForms.ScanFix5.CombRemovalOptions();

            comb.Area = new System.Drawing.Rectangle(AreaXBar.Value, AreaYBar.Value, AreaWBar.Value, AreaHBar.Value);
            comb.CombHeight = CombHBar.Value;
            comb.CombSpacing = SpaceBar.Value;
            comb.HorizontalLineThickness = HBar.Value;
            comb.VerticalLineThickness = VBar.Value;
            comb.MinimumCombLength = LengthBar.Value;
            comb.MinimumConfidence = ConfidenceBar.Value;

            scanFix1.RemoveCombs(comb);
            */

            //Smooth Options
            //scanFix1.SmoothObjects(10);

            /*
            DilateOptions dilate = new DilateOptions();
            dilate.Amount = 1;
            dilate.Direction = EnhancementDirections.All;

            scanFix1.Dilate(dilate);
            */
            //Blob Options
            /*
            blob = new PegasusImaging.WinForms.ScanFix5.BlobRemovalOptions();

            blob.Area = new System.Drawing.Rectangle(BlobAreaXBar.Value, BlobAreaYBar.Value, AreaWidthBar.Value, AreaHeightBar.Value);
            blob.MaximumPixelCount = MaxCountBar.Value;
            blob.MinimumPixelCount = MinCountBar.Value;
            blob.MinimumDensity = DensityBar.Value;

            scanFix1.RemoveBlobs(blob);
            */

            //Remove Dot Shading 
            /*
            dot = new PegasusImaging.WinForms.ScanFix5.DotShadingRemovalOptions();

            dot.DensityAdjustment = DotDensityBar.Value;
            dot.MaximumDotSize = DotSizeBar.Value;
            dot.HorizontalSizeAdjustment = HAdjBar.Value;
            dot.VerticalSizeAdjustment = VAdjBar.Value;
            dot.MinimumAreaHeight = DotHBar.Value;
            dot.MinimumAreaWidth = DotWBar.Value;

            scanFix1.RemoveDotShading(dot);
            */


            //Remove Border Options
            
            border = new PegasusImaging.WinForms.ScanFix5.BorderRemovalOptions();

            border.PadColor = Color.White;
            border.BorderSpeckSize = 4;
            border.CropBorder = true;
            border.DeskewBorder = true;
            border.MaximumPageHeight = 0;
            border.MaximumPageWidth = 0;
            border.MinimumConfidence = 50;
            border.MinimumPageHeight = 0;
            border.MinimumPageWidth = 0;
            border.PageSpeckSize = 2;
            border.Quality = 80;
            border.ReplaceBorder = true;

            scanFix1.RemoveBorder(border);
            
            //Despeckle
            
            DespeckleOptions DespeckOpts = new DespeckleOptions();
            DespeckOpts.SpeckWidth = 10;
            DespeckOpts.SpeckHeight = 10;
            scanFix1.Despeckle(DespeckOpts);
            

            //Deskew
            scanFix1.Deskew();

            Image = ImageX.FromHdib(imagXpress1, scanFix1.ToHdib(true));

            return Image;
        }
        private ImageX PreprocessImage(ImageX Image)
        {
            scanFix1.FromHdib(Image.ToHdib(false));

            //Remove Lines
            /*          LineRemovalOptions LineOpts = new LineRemovalOptions();
                      LineOpts.MinimumLength = 10;
                      scanFix1.RemoveLines(LineOpts);
          */
            

            //Dilate



            //Comb options
            /*
            comb = new PegasusImaging.WinForms.ScanFix5.CombRemovalOptions();

            comb.Area = new System.Drawing.Rectangle(AreaXBar.Value, AreaYBar.Value, AreaWBar.Value, AreaHBar.Value);
            comb.CombHeight = CombHBar.Value;
            comb.CombSpacing = SpaceBar.Value;
            comb.HorizontalLineThickness = HBar.Value;
            comb.VerticalLineThickness = VBar.Value;
            comb.MinimumCombLength = LengthBar.Value;
            comb.MinimumConfidence = ConfidenceBar.Value;

            scanFix1.RemoveCombs(comb);
            */

            //Smooth Options
            //scanFix1.SmoothObjects(10);

            /*
            DilateOptions dilate = new DilateOptions();
            dilate.Amount = 1;
            dilate.Direction = EnhancementDirections.All;

            scanFix1.Dilate(dilate);
            */
            //Blob Options
            /*
            blob = new PegasusImaging.WinForms.ScanFix5.BlobRemovalOptions();

            blob.Area = new System.Drawing.Rectangle(BlobAreaXBar.Value, BlobAreaYBar.Value, AreaWidthBar.Value, AreaHeightBar.Value);
            blob.MaximumPixelCount = MaxCountBar.Value;
            blob.MinimumPixelCount = MinCountBar.Value;
            blob.MinimumDensity = DensityBar.Value;

            scanFix1.RemoveBlobs(blob);
            */

            //Remove Dot Shading 
            /*
            dot = new PegasusImaging.WinForms.ScanFix5.DotShadingRemovalOptions();

            dot.DensityAdjustment = DotDensityBar.Value;
            dot.MaximumDotSize = DotSizeBar.Value;
            dot.HorizontalSizeAdjustment = HAdjBar.Value;
            dot.VerticalSizeAdjustment = VAdjBar.Value;
            dot.MinimumAreaHeight = DotHBar.Value;
            dot.MinimumAreaWidth = DotWBar.Value;

            scanFix1.RemoveDotShading(dot);
            */


            //Remove Border Options
            
            border = new PegasusImaging.WinForms.ScanFix5.BorderRemovalOptions();

            border.PadColor             = Color.White;
            border.BorderSpeckSize      = 4;
            border.CropBorder           = true;
            border.DeskewBorder         = true;
            border.MaximumPageHeight    = 0;
            border.MaximumPageWidth     = 0;
            border.MinimumConfidence    = 50;
            border.MinimumPageHeight    = 0;
            border.MinimumPageWidth     = 0;
            border.PageSpeckSize        = 2;
            border.Quality              = 80;
            border.ReplaceBorder        = true;
           
            scanFix1.RemoveBorder(border);

            
            //Despeckle
            DespeckleOptions DespeckOpts = new DespeckleOptions();
            DespeckOpts.SpeckWidth = 14;
            DespeckOpts.SpeckHeight = 14;
            scanFix1.Despeckle(DespeckOpts);
            
            //Deskew
            scanFix1.Deskew();
            

            Image = ImageX.FromHdib(imagXpress1, scanFix1.ToHdib(true));

            return Image;
        }
        private Boolean LoadTemplate(String TemplateImageName)
        {
            String TemplateName = TemplateImageName.Substring(TemplateImageName.LastIndexOf("\\") + 1).ToUpper().Replace(".TIF", "");

            if (!File.Exists(TemplateImageName))
                MessageBox.Show("This Template Doecn't Exist!! : " + TemplateImageName);

            // Zonal 
            try
            {

                InputImg.Image = ImageX.FromFile(imagXpress1, this.TemplateFile);
                /*
                Processor prc = new PegasusImaging.WinForms.ImagXpress9.Processor(imagXpress1, InputImg.Image);
                prc.Rotate(270);
                InputImg.Image = prc.Image.Copy();
                */

                InputImg.Image = this.PreprocessTemplate(InputImg.Image);

                frmTemplateImage = FormImage.FromHdib(InputImg.Image.ToHdib(false), true, formFix1);

                OutputImg.Image = ImageX.FromHdib(imagXpress1, frmTemplateImage.ToHdib(false), true);   //InputImg.Image.Copy();
                OnPictureChanged(ICRType.Template);

              //  MessageBox.Show("Load Template");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsTemplateLoaded = false;
                return false;
            }

            IsTemplateLoaded = true;
            return true;
        }
        private Boolean LoadImage(String ImageName)
        {
            if (!File.Exists(ImageName))
            {
                MessageBox.Show("Image Doesn't exist : " + ImageName);
                return false;
            }

            //Zonal 2
            try
            {
                currentLayer.Elements.Clear();

                InputImg.Image = ImageX.FromFile(imagXpress1, ImageName);
                /*
                Processor prc = new PegasusImaging.WinForms.ImagXpress9.Processor(imagXpress1, InputImg.Image);
                if (InputImg.Image.ImageXData.BitsPerPixel != 1)
                {
                    prc.ColorDepth(1, PaletteType.Optimized, DitherType.NoDither);
                    //InputImg.Image = prc.Image;
                }

                //    prc.Rotate(270);
                prc.DocumentDeskew(0, 10, Color.White, true, 99);
                prc.DocumentDespeckle(10, 10);
                InputImg.Image = prc.Image.Copy();
                */


                InputImg.Image = this.PreprocessImage(this.InputImg.Image);

                frmFilledImage = FormImage.FromHdib(InputImg.Image.ToHdib(false), formFix1);

                OutputImg.Image = ImageX.FromHdib(imagXpress1, frmFilledImage.ToHdib(false), true);   //InputImg.Image.Copy();

                OnPictureChanged(ICRType.Image);
              //  MessageBox.Show("Load Image");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool RegisterImage()
        {

            //Zonal 2
            try
            {
                IsFilledAligned = false;

                regProcessor = new RegistrationProcessor(formFix1);

                
                regResult = regProcessor.RegisterToImage(frmFilledImage, frmTemplateImage);

                //if (regResult.State == RegistrationState.Failure)
                //    MessageBox.Show(regResult.State.ToString());

                frmAlignedImage = regResult.AlignImage(frmFilledImage);

                //InputImg.Image = ImageX.FromHdib(imagXpress1, oDropOutResult.Image.ToHdib(true), true); //ImageX.FromHdib(imagXpress1, frmAlignedImage.ToHdib(false), true);
                InputImg.Image = ImageX.FromHdib(imagXpress1, frmAlignedImage.ToHdib(false), true);
                // oDrop.Dispose();

                if (this.IsAligned(InputImg.Image))
                {
                    if (regResult.State == RegistrationState.Success)
                    {
                        InputImg.Image = ImageX.FromHdib(imagXpress1, frmAlignedImage.ToHdib(false), true);
                        IsFilledAligned = true;
                        //  MessageBox.Show("Ok");
                    }
                    else
                    {
                        //  MessageBox.Show("BAD");
                        InputImg.Image = ImageX.FromHdib(imagXpress1, frmFilledImage.ToHdib(false), true);
                    }
                }
                else
                {
                    InputImg.Image = ImageX.FromHdib(imagXpress1, frmFilledImage.ToHdib(false), true);
                    if (this.IsAligned(InputImg.Image))
                    {
                        InputImg.Image = ImageX.FromHdib(imagXpress1, frmFilledImage.ToHdib(false), true);
                    }
                    else
                    {
                        MessageBox.Show("Image Not Processable");
                        return false;
                    }
                }

                OutputImg.Image = InputImg.Image.Copy();
                OnPictureChanged(ICRType.ImageMatched);

                

                regProcessor.Dispose();
              //    MessageBox.Show("Aligned Image");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;



        }
        #endregion
        #region field
        private Boolean IsAligned(ImageX Image)
        {
           // ICRField oField = new ICRField("IsAligned", 305, 85, 130, 70, CharacterSet.AllAlphas, 20);

            ICRField oField = new ICRField("IsAligned", 1830, 211, 82, 65, CharacterSet.AllAlphas, 20);
            this.DrawRectangle(oField);


            Rectangle currentArea = new Rectangle(oField.Left, oField.Top, oField.Width, oField.Height);
                SmartZone2.Reader.Area = currentArea;
                SmartZone2.Reader.CharacterSet = CharacterSet.AllAlphas;
                myTextBlockRes = SmartZone2.Reader.AnalyzeField(Image.ToHdib(true));

                OutputFieldImg.Image = Image.Copy();
                OnPictureChanged(ICRType.FieldProcessed);

              //  MessageBox.Show("Is Asigned");
                Application.DoEvents();

                if (myTextBlockRes.NumberTextLines > 0)
                {
                    //if (myTextBlockRes.TextLine(0).Text.ToUpper().Contains("US"))
                    if (myTextBlockRes.TextLine(0).Text.ToUpper().Contains("PEN"))
                    {
                        return true;
                    }
                    else
                    {
                      //  MessageBox.Show(myTextBlockRes.TextLine(0).Text);
                    }
                }
                return false;
        }

        private ImageX PreprocessField(ImageX Image)
        {
            scanFix1.FromHdib(Image.ToHdib(false));

            //Remove Lines
            /*          LineRemovalOptions LineOpts = new LineRemovalOptions();
                      LineOpts.MinimumLength = 10;
                      scanFix1.RemoveLines(LineOpts);
          */
            //Despeckle

            DespeckleOptions DespeckOpts = new DespeckleOptions();
            DespeckOpts.SpeckWidth = 14;
            DespeckOpts.SpeckHeight = 14;
            scanFix1.Despeckle(DespeckOpts);

            //Deskew
            //scanFix1.Deskew();

            //Dilate



            //Comb options
            /*
            comb = new PegasusImaging.WinForms.ScanFix5.CombRemovalOptions();

            comb.Area = new System.Drawing.Rectangle(AreaXBar.Value, AreaYBar.Value, AreaWBar.Value, AreaHBar.Value);
            comb.CombHeight = CombHBar.Value;
            comb.CombSpacing = SpaceBar.Value;
            comb.HorizontalLineThickness = HBar.Value;
            comb.VerticalLineThickness = VBar.Value;
            comb.MinimumCombLength = LengthBar.Value;
            comb.MinimumConfidence = ConfidenceBar.Value;

            scanFix1.RemoveCombs(comb);
            */

            //Smooth Options
            scanFix1.SmoothObjects(10);

            /*
            DilateOptions dilate = new DilateOptions();
            dilate.Amount = 1;
            dilate.Direction = EnhancementDirections.All;

            scanFix1.Dilate(dilate);
            */
            //Blob Options
            /*
            blob = new PegasusImaging.WinForms.ScanFix5.BlobRemovalOptions();

            blob.Area = new System.Drawing.Rectangle(BlobAreaXBar.Value, BlobAreaYBar.Value, AreaWidthBar.Value, AreaHeightBar.Value);
            blob.MaximumPixelCount = MaxCountBar.Value;
            blob.MinimumPixelCount = MinCountBar.Value;
            blob.MinimumDensity = DensityBar.Value;

            scanFix1.RemoveBlobs(blob);
            */

            //Remove Dot Shading 
            /*
            dot = new PegasusImaging.WinForms.ScanFix5.DotShadingRemovalOptions();

            dot.DensityAdjustment = DotDensityBar.Value;
            dot.MaximumDotSize = DotSizeBar.Value;
            dot.HorizontalSizeAdjustment = HAdjBar.Value;
            dot.VerticalSizeAdjustment = VAdjBar.Value;
            dot.MinimumAreaHeight = DotHBar.Value;
            dot.MinimumAreaWidth = DotWBar.Value;

            scanFix1.RemoveDotShading(dot);
            */


            //Remove Border Options
            /*
            border = new PegasusImaging.WinForms.ScanFix5.BorderRemovalOptions();

            border.BorderSpeckSize = BSpeckBar.Value;
            border.CropBorder = chkcrop.Checked;
            border.DeskewBorder = chkdeskew.Checked;
            border.MaximumPageHeight = MaxHeightBar.Value;
            border.MaximumPageWidth = MaxWidthBar.Value;
            border.MinimumConfidence = MinConBar.Value;
            border.MinimumPageHeight = MinHeightBar.Value;
            border.MinimumPageWidth = SpeckWidthBar.Value;
            border.PageSpeckSize = PSpeckBar.Value;
            border.Quality = SpeckQualityBar.Value;
            border.ReplaceBorder = chkreplace.Checked;

            if (true)
            {
                border.PadColor = System.Drawing.Color.FromArgb(0, 0, 0);
            }
            else
            {
                border.PadColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            scanFix1.RemoveBorder(border);
            */

            Image = ImageX.FromHdib(imagXpress1, scanFix1.ToHdib(false));

            return Image;
        }
        public void ProcessFields()
        {
            foreach (ICRField Field in this.Fields)
            {

                ImageX FieldImage = new ImageX(imagXpress1);
                if (IsFilledAligned)
                {
                    DropOutProcessor oDrop = new DropOutProcessor(formFix1);
                    oDrop.DropOutMethod = DropOutMethod.DropOut;
                    oDrop.PerformReconstruction = false;
                    oDrop.Area = new Rectangle(Field.Left, Field.Top, Field.Width, Field.Height);
                    DropOutResult oDropOutResult = oDrop.CreateImageOfField(frmFilledImage, regResult);
                    FieldImage = ImageX.FromHdib(imagXpress1, oDropOutResult.Image.ToHdib(true), true);
                    oDrop.Dispose();
                }
                else
                {
                    scanFix1.FromHdib(frmFilledImage.ToHdib(false));
                    scanFix1.GetRectangle(new Rectangle(Field.Left, Field.Top, Field.Width, Field.Height));
                    FieldImage = ImageX.FromHdib(imagXpress1, scanFix1.ToHdib(true));
                }

                OutputFieldImg.Image = FieldImage.Copy();
                OnPictureChanged(ICRType.Field);
                // MessageBox.Show("Field Loaded");
                Application.DoEvents();

                // Set area and analyze field DIB
                SmartZone2.Reader.CharacterSet = Field.CharSet;
                SmartZone2.Reader.Segmentation.SplitMergedChars = true;
                SmartZone2.Reader.Segmentation.SplitOverlappingChars = true;

                FieldImage = this.PreprocessField(FieldImage);
                
                OutputFieldImg.Image = FieldImage.Copy();
                OnPictureChanged(ICRType.FieldProcessed);
               // MessageBox.Show("Field Processed");
                Application.DoEvents();
                
                Rectangle currentArea = new Rectangle(0, 0, Field.Width, Field.Height); //FieldImage.ImageXData.Width, FieldImage.ImageXData.Height); // Field.Width, Field.Height);
                SmartZone2.Reader.Area = currentArea;
                myTextBlockRes = SmartZone2.Reader.AnalyzeField(FieldImage.ToHdib(true));


                if (myTextBlockRes.NumberTextLines > 0)
                {

                    // MessageBox.Show(myTextBlockRes.TextLine(0).Text);

                    //Chars.Clear();
                    Field.Chars.Clear();
                    for (int i = 1; myTextBlockRes.NumberTextLines + 1 != i; i++)
                    {
                        LineResult = myTextBlockRes.TextLine(0);

                        String charResult = "";
                        int ControlIndex = 1;
                        for (int charIndex = 0; LineResult.NumberCharacters != charIndex; charIndex++)
                        {
                            CharacterResult characterResult = LineResult.Character(charIndex);
                            ICRChar oChar = new ICRChar(characterResult.Text, characterResult.Confidence);
                            for (int x = 0; x < characterResult.NumberResults; x++)
                            {
                                oChar.Results.Add(new ICRChar(characterResult.AlternateText(x), characterResult.AlternateConfidence(x)));
                            }

                            oChar.Area = characterResult.Area;
                            oChar.NumberResults = characterResult.NumberResults;
                            Field.Chars.Add(oChar);

                            charResult = charResult + characterResult.Text;
                            ControlIndex++;
                        }
                        Field.Result = charResult;
                        // MessageBox.Show(Field.Result);
                    }
                }
                else
                {
                    Field.Result = "";
                }
            }
        }
        private void SetGeneralParameters()
        {
            //Zonal 2
            // **The UnlockRuntime function must be called to distribute the runtime**	
            //imagXpress1.License.UnlockRuntime(1234, 1234, 1234, 1234);
            //SmartZone2.Licensing.UnlockRuntime(1234, 1234, 1234, 1234);

            //set some defaults
            SmartZone2.Licensing.LicenseEdition = PegasusImaging.WinForms.SmartZone2.LicenseEditionType.IcrOcrProfessionalEdition;
            SmartZone2.Reader.Classifier = Classifier.HandPrint;
            SmartZone2.Reader.CharacterSet.Language = Language.English;

            // Set Rejection character
            SmartZone2.Reader.RejectionCharacter = '~';
            SmartZone2.Reader.MinimumCharacterConfidence = 0; //0-100%

            // Set segemntation parameters

            SmartZone2.Reader.Segmentation.DetectSpaces = true;
            SmartZone2.Reader.Segmentation.MultipleTextLines = true;
            SmartZone2.Reader.Segmentation.SplitMergedChars = false;
            SmartZone2.Reader.Segmentation.SplitOverlappingChars = true;
            // SmartZone2.Reader.Segmentation.MaximumBlobSize = Convert.ToInt32(numericUpDownMaxBlobSize.Value);
            // SmartZone2.Reader.Segmentation.MinimumTextLineHeight = Convert.ToInt32(numericUpDownMinLineHeight.Value);


        }
        public void DrawRectangle(ICRField Field)
        {
            RectangleTool currentElement = new RectangleTool();
            // currentLayer.Elements.Clear();
            currentElement.PenWidth = 2;
            currentElement.PenColor = Color.Red;
            currentElement.BackStyle = BackStyle.Transparent;
            currentElement.BoundingRectangle = new Rectangle(Field.Left, Field.Top, Field.Width, Field.Height); //myTextBlockRes.TextLine(0).Area;
            currentLayer.Elements.Add(currentElement);

            try
            {
                notateXpress1.Layers.Brand(4);
            }
            catch
            {
            }
            /*
            // OutputImg.Image = InputImg.Image.Copy();
            Graphics g = OutputImg.CreateGraphics();
            g.DrawRectangle(new Pen(Brushes.Blue, 2), new Rectangle(Field.Left, Field.Top, Field.Width, Field.Height));
            g.Dispose();
            */
            OnPictureChanged(ICRType.Image);
        }
        #endregion
        
        #endregion

        #region Classes
        
        public class ICRChar
        {
            public String Char;
            public Int32 Confidence;
            public Int32 NumberResults = 0;
            public Rectangle Area = new Rectangle();
            public ArrayList Results = new ArrayList();
            public ICRChar(String Character, Int32 Confidence)
            {
                this.Char = Character;
                this.Confidence = Confidence;
            }
        }
        public class ICRField
            {
            private PegasusImaging.WinForms.SmartZone2.TextBlockResult  myTextBlockRes;
            private PegasusImaging.WinForms.SmartZone2.TextLineResult   myTextLineRes;
            public PegasusImaging.WinForms.ImagXpress9.ImageXView       InputImage;
            public PegasusImaging.WinForms.ImagXpress9.ImagXpress       ImageExpress;
            

            public String Name;
            public int Top;
            public int Height;
            public int Left;
            public int Width;
            public CharacterSet CharSet;
            

            public String Result;
            public Int32 Confidence;

            public Int32 Lenght;

            private SmartZone SmartZone2 = new SmartZone();
            
            
            public ArrayList Chars = new ArrayList();


            public event EventHandler FieldPictureChanged;
            public virtual void OnFieldPictureChanged(ICRType Type)
            {
                if (FieldPictureChanged != null)
                {
                    ImageEvenArgs Event = new ImageEvenArgs();
                    Event.type = Type;
                    FieldPictureChanged(this, Event);
                }
            }


            public ICRField()
                {
                    this.Result = "";
                    this.Confidence = 0;
                    this.ImageExpress = new ImagXpress();
                    this.InputImage = new ImageXView(ImageExpress);
                }
            public ICRField(String Name, int Left, int Top, int Width, int Height, CharacterSet CharSet, Int32 Lenght)
                {
                    this.Name = Name;
                    this.Left = Left;
                    this.Top = Top;
                    this.Width = Width;
                    this.Height = Height;
                    this.Lenght = Lenght;
                    this.CharSet = CharSet;
                    this.CharSet.Language = Language.English;
                    
                }
            public String GetResult()
                {
                    
                    //Reading Fields
                    String charResult = "";

                    
                    // Set area and analyze field DIB
                    SmartZone2.Reader.CharacterSet = this.CharSet;
                    Rectangle currentArea = new Rectangle(this.Left,this.Top, this.Width,this.Height);
                    SmartZone2.Reader.Area = currentArea;
                    myTextBlockRes = SmartZone2.Reader.AnalyzeField(this.InputImage.Image.ToHdib(false));
                
                    System.Drawing.Graphics g = InputImage.Image.GetGraphics();
                    g.DrawRectangle(new Pen(Brushes.AliceBlue, 5), currentArea);
                    InputImage.Image.ReleaseGraphics(false);
                    
                

                    if (myTextBlockRes.NumberTextLines > 0)
                    {
                        Boolean hasResult = true;

                        myTextLineRes = myTextBlockRes.TextLine(0);
                        MessageBox.Show(myTextBlockRes.TextLine(0).Text);

                        //   showBlockResult();
                        //   showLineResult(0);
                        //   showCharacterResult(0);
                    }
                    else
                    {
                        Boolean hasResult = false;

                    }
                
                
                // ICRprocessor._icrProcessor.FormFieldDefaultType = peFieldType.FIELDTYPE_ICR;
                   // ICRprocessor._icrProcessor.SelectFormField(Name);                                   //All this preprocess is applied to the current field
                /*
                    if (ICRprocessor._icrProcessor.FieldError != 0)
                    {
                        MessageBox.Show("Form : " + ICRprocessor._icrProcessor.GetFormName() + " Field: " + ICRprocessor._icrProcessor.GetFieldName() + " \r\n" +
                                        "Error : " + ICRprocessor._icrProcessor.FieldError.ToString() + "  " + ICRprocessor._icrProcessor.FieldErrorString + " \r\n" + 
                                        "Result: " + ICRprocessor._icrProcessor.FieldResultStr);
                        
                    }

                    ICRprocessor._icrProcessor.GetFieldBounds(ref pLeft, ref pTop, ref pWidth, ref pHeight);
                */
                    //ICRprocessor.img.ColorDepth(8, PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Fixed, PegasusImaging.WinForms.ImagXpress7.enumDithered.DI_None);
                    
                   // ICRprocessor.img.DrawWidth = 4;
    
                /*
                    //Process Multi Fields
                    this.img.hDIB = ICRprocessor._icrProcessor.FieldResultImagehDIB;
                    Application.DoEvents();
                */
                    

                    //ICRprocessor.img.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, Color.LightGray);
                    //ICRprocessor.OnPictureChanged(ICRType.ImageMarked);
                    //Application.DoEvents();

                    Chars.Clear();
                /*
                    if (ICRprocessor._icrProcessor.FieldError == 0)
                    {
                        for (int i = 1; ICRprocessor._icrProcessor.FieldResultNumLines + 1 != i; i++)
                        {
                            ICRprocessor._icrProcessor.FieldResultLine = i;

                            charResult = "";
                            int ControlIndex = 1;
                            for (int charIndex = 1; ICRprocessor._icrProcessor.FieldResultLineNumChars + 1 != charIndex; charIndex++)
                            {
                                ICRprocessor._icrProcessor.FieldResultLineChar = charIndex;
                                ICRprocessor._icrProcessor.FieldResultChar(0);

                                if (this.Lenght <= charResult.Trim().Length)
                                {
                                    break;
                                }

                                Chars.Add(new ICRChar(ICRprocessor._icrProcessor.FieldResultChar(0), ICRprocessor._icrProcessor.FieldResultCharConfidence));          
                                charResult = charResult + ICRprocessor._icrProcessor.FieldResultChar(0);
                                ControlIndex++;
                            }
                        }
                        this.Confidence = ICRprocessor._icrProcessor.FieldResultLineConfidence; //Its Confidence by Character .FieldResultConfidence; //
                    }
                */
                    return charResult;

                }
            
            public void DrawRectangle(Color Color)
            {
                // ICRprocessor.img.ColorDepth(24, PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized, PegasusImaging.WinForms.ImagXpress7.enumDithered.DI_None);
                // ICRprocessor.img.DrawRoundRect(Left, Top, Left + Width, Top + Height, 0, 0, Color);
                 //ICRprocessor.OnPictureChanged(ICRType.ImageMarked);
                 Application.DoEvents();
            }
            
            }
        public class _ICRFields : Hashlist
            {
                public PegasusImaging.WinForms.ImagXpress9.ImageXView img;

                public _ICRFields()
                {
                    
                }

                public  void Add(String Name, int Left, int Top, int Width, int Height, CharacterSet CharSet, int Lenght)
                {
                    this.Add(new ICRField(Name,Left,Top,Width,Height,CharSet, Lenght));

                }

                
                public void Add(ICRField _Field)
                 {
                     this.Add(_Field.Name, _Field);
                 }
              
                public void Process(ref ImageXView InputImage)
                {
                    
                    
                    // Go on with the processing:
                    //_icrProcessor._icrProcessor.SelectForm(MatchedForm);
                    //_icrProcessor._icrProcessor.StartFormProcessing();
                    
                    foreach (ICRField Field in this)
                        {
                            Field.InputImage = InputImage;
                            //Field.FieldPictureChanged += new EventHandler(Field_FieldPictureChanged);
                            Field.Result = Field.GetResult();
                            //this.img.hDIB = Field.img.CopyDIB();
                            //Field.OnFieldPictureChanged(ICRType.FieldProcessed);
                            Application.DoEvents();
                            //Field.FieldPictureChanged -= new EventHandler(Field_FieldPictureChanged);
                         //   MessageBox.Show("Ok");
                        }
                    //_icrProcessor.DeletePreprocessImage();
                }

                void Field_FieldPictureChanged(object sender, ImageEvenArgs e)
                {
                 //   _icrProcessor.OnPictureChanged(ICRType.FieldProcessed);
                }

                /* Hash List Support */
                public new ICRField this[string Key]
                {
                    get { return (ICRField)base[Key]; }

                }
                public new ICRField this[int index]
                {
                    get
                    {
                        object oTemp = base[index];
                        return (ICRField)oTemp;
                    }
                }

                // Expose the enumerator for the associative array.
                new public IEnumerator GetEnumerator()
                {
                    return new _ICRFieldsEnumerator(this);
                }

            }
        public class _ICRFieldsEnumerator : IEnumerator
            {
                public _ICRFieldsEnumerator(_ICRFields ar)
                {
                    _ar = ar;
                    _currIndex = -1;
                }
                public object Current
                {
                    get
                    {
                        return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                    }
                }
                public bool MoveNext()
                {
                    _currIndex++;
                    if (_currIndex == _ar.Length)
                        return false;
                    else
                        return true;
                }
                public void Reset()
                {
                    _currIndex = -1;
                }

                // The index of the item this enumerator applies to.
                protected int _currIndex;
                // A reference to this enumerator's associative array.
                protected _ICRFields _ar;


            }

        public class ImageEvenArgs : EventArgs
        {
            public ICRType type;
        }
        public enum ICRType
        {
            Field = 0,
            Image = 1,
            Template = 2,
            TemplateProcessed = 3,
            ImageProcessed = 4,
            FieldProcessed = 5,
            ImageMatched   = 6,
            ImageMarked    = 7
        }
        public class ICRPicture
        {
            private Pen p;
            private SolidBrush b, bT = new SolidBrush(Color.Black);
            private string path = "ICRTemplate1.tif";
            private Image im;
            private Font f;
            private Graphics g;
            private Bitmap bm;

            public Image Image;

            private int Left = 0;
            private int Top = 0;
            private int Height = 0;
            private int Width = 0;

            public int AdjHeight = 0;
            public int AdjWidth = 0;

            public ICRPicture(int Width, int Height)
            {
                this.AdjWidth = Width;
                this.AdjHeight = Height;

                p = new Pen(Color.Red, 6);
                b = new SolidBrush(Color.LightGray);
                f = new Font(new FontFamily("Times New Roman"), 10);
                //Create a Image Object From File
                im = Image.FromFile("ICRTemplate.tif");
                this.Top = 0;
                this.Left = 0;
                this.Height = im.Height;
                this.Width = im.Width;

                // Create a Virtual Bitmap
                bm = new Bitmap(this.Width, this.Height);

                //Create a Graphics Object from Bitmap
                g = Graphics.FromImage(bm);
                g.FillRectangle(b, 0, 0, this.Width, this.Height);
                g.DrawImage(im, 0, 0, this.AdjWidth, this.AdjHeight);
                g.Dispose();

            }

            public void DrawString(int left, int top, String text)
            {
                g = Graphics.FromImage(bm);
                g.DrawString(text, f, bT, left, top);
                g.Dispose();
                Image = Image.FromHbitmap(bm.GetHbitmap());
            }

            public void DrawRectangle(int Left, int Top, int Height, int Width, Pen pen)
            {
                g = Graphics.FromImage(bm);
                g.DrawRectangle(pen, Left, Top, Height, Width);
                g.Dispose();
                Image = Image.FromHbitmap(bm.GetHbitmap());
            }

        }

        public class ICRImage
        {
            public String FileType = "TIFF";
            public String FilePath = "";

            public ICRImage(String FilePath)
            {
                this.FilePath = FilePath;
            }
        }
        #endregion
    }

    public class ZonalTest : ZonalProcessor
    {

        public ZonalTest()
        {
            this.AddFields();
        }

        public void AddFields()
        {
            int Top;
            int Height;
            int Left;
            int Width;


            #region Header Fields
            this.Fields.Add("LastName", 100, 435, 1600, 142, CharacterSet.AllAlphas, 35);
            this.Fields.Add("FirstName", 1753, 435, 1400, 142, CharacterSet.AllAlphas, 35);
            this.Fields.Add("DayPhone", 3244, 435, 1100, 142, CharacterSet.Digits, 10);

            this.Fields.Add("ParentAddress", 100, 615, 1950, 142, CharacterSet.AlphaNumeric, 30);
            this.Fields.Add("City", 2145, 615, 1200, 142, CharacterSet.AllAlphas, 14);
            this.Fields.Add("State", 3500, 615, 250, 142, CharacterSet.AllAlphas, 2);
            this.Fields.Add("ZipCode",3795, 615, 550, 142, CharacterSet.Digits, 5);
            
            this.Fields.Add("Teacher", 100, 795, 1950, 142, CharacterSet.AllAlphas, 20);
            this.Fields.Add("SchoolName", 2340, 795, 2005, 142, CharacterSet.AllAlphas, 32);
            
            this.Fields.Add("SchoolUse", 2468, 3165, 380, 142, CharacterSet.Digits, 6);
            this.Fields.Add("SUDecimal", 2870, 3165, 231, 142, CharacterSet.Digits, 4);
            #endregion

            #region Detail Fields


            // Codes Fields
            Int16 GenTop = 980;

            Top = GenTop;
            Height = 135 + 1;
            Left = 865;
            Width = 410;

            for (int i = 1; i <= 30; i++)
            {
                if (i == 16)
                {
                    Left += 1570;
                    Top = GenTop;
                }

                this.Fields.Add("Code" + i.ToString(), Left, Top, Width, Height, CharacterSet.Digits, 4);
                Top = Top + Height;
            }


            // Quantities Codes Fields

            Top = GenTop;
            Height = 135 + 1;
            Left = 865 + 420 + 2;
            Width = 190;

            for (int i = 1; i <= 30; i++)
            {
                if (i == 16)
                {
                    Left += 1570;
                    Top = GenTop;
                }

                this.Fields.Add("Quantity" + i.ToString(), Left, Top, Width, Height, CharacterSet.Digits, 4);
                Top = Top + Height;

            }

            #endregion
        }

        public void AnalizeFields()
        {
            Product oProduct = new Product("F08");

            foreach (ICRField Field in this.Fields)
            {
               // this.DrawRectangle(Field);
                /*
                if (Field.Name == "FirstName" || Field.Name == "LastName")
                {
                    //MessageBox.Show(Field.Result);
                    SpellWord oWord = new SpellWord();
                    if (oWord.GetResult(Field))
                        MessageBox.Show("OK: " + oWord.Result);
                    else
                        MessageBox.Show("Bad: " + oWord.Result.ToUpper());
                }
                bool bFound = false;
                
                if (Field.Name.Substring(0,4) == "Code" && Field.Result.Trim().Length>=4)
                {
                    if (!oProduct.Find(Field.Result))
                    {
                        SpellWord oWord = new SpellWord();
                        ArrayList oCodes = oWord.getChars(Field);
                        foreach (String Code in oCodes)
                        {
                            if (oProduct.Find(Code))
                            {
                                MessageBox.Show(Code);
                                bFound = true;
                                break;
                            }
                        }
                        if (!bFound)
                            MessageBox.Show("Not Found!:"+Field.Result);
                    }
                    else
                    {
                        MessageBox.Show("Ok:" + Field.Result);
                    }

                }
                */
            }
        }
    }

    public class SpellWord
    {

        public enum Level
        {
            Exact    = 0,
            Speller  = 1,
            Database = 2
        }

        public Level TypeResult;
        public Boolean bFound = false;
        public String Result = "";

        private int LD(string s, string t)
        {

            int n = s.Length; //length of s

            int m = t.Length; //length of t

            int[,] d = new int[n + 1, m + 1]; // matrix

            int cost; // cost

            // Step 1

            if (n == 0) return m;

            if (m == 0) return n;

            // Step 2

            for (int i = 0; i <= n; d[i, 0] = i++) ;

            for (int j = 0; j <= m; d[0, j] = j++) ;

            // Step 3

            for (int i = 1; i <= n; i++)
            {

                //Step 4

                for (int j = 1; j <= m; j++)
                {

                    // Step 5

                    cost = (t.Substring(j - 1, 1) == s.Substring(i - 1, 1) ? 0 : 1);

                    // Step 6

                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                              d[i - 1, j - 1] + cost);

                }

            }


            // Step 7


            return d[n, m];

        }

        private int ComputeDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1]; // matrix

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public Boolean GetResult(ZonalProcessor.ICRField Field)
        {
            bFound = false;
            String ReturnResult = "";
            if (Field.Result == "")
            {
                Result = "";
                return false;
            }
            if (!this.FindName(Field.Result, Field.Name))
            {
                Signature.SpellChecker.Dictionary.WordDictionary wordDictionary;
                Signature.SpellChecker.Spelling spelling;
                spelling = new Signature.SpellChecker.Spelling();
                wordDictionary = new Signature.SpellChecker.Dictionary.WordDictionary();

                spelling.Dictionary = wordDictionary;
                spelling.ShowDialog = false;
                spelling.IgnoreWordsWithDigits = true;
                spelling.IgnoreAllCapsWords = false;
                spelling.SuggestionMode = Signature.SpellChecker.Spelling.SuggestionEnum.NearMiss;

                wordDictionary.DictionaryFolder = @"D:\ICR\ICR\";
                wordDictionary.DictionaryFile = "FirstNames.dic";
                wordDictionary.UserFile = "User.dic";


                ArrayList Result = this.getChars(Field);
                bFound = false;
                if (Result.Count < 3 && Result.Count > 0)
                {
                    ReturnResult = Result[0].ToString();
                    bFound = true;
                    TypeResult = Level.Exact;
                }
                foreach (String Name in Result)
                {
                    if (this.FindName(Name, Field.Name))
                    {
                        // MessageBox.Show("Bingo: " + Name);
                        TypeResult = Level.Database;
                        ReturnResult = Name;
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    //   MessageBox.Show("Sorry: " + Field.Result.Replace(" ", ""));
                    foreach (String Test in Result)
                    {
                        //MessageBox.Show("Test:" + Test);
                        if (spelling.SpellCheck(Test.ToUpper()))
                        {
                            spelling.Suggest(Test.ToUpper());
                            foreach (String Suggestion in spelling.Suggestions)
                            {
                                // MessageBox.Show("Sugestion:" + Suggestion.ToUpper() + " Distance: " + LD(Test.ToUpper(), Suggestion.ToUpper().Replace(" ", "")).ToString());
                                if (spelling.EditDistance(Test.ToUpper(), Suggestion.ToUpper().Replace(" ", "")) == 1)
                                {
                                    //         MessageBox.Show("This could be : " + Suggestion.ToUpper());
                                    TypeResult = Level.Speller;
                                    ReturnResult = Suggestion.ToUpper();
                                    bFound = true;
                                    break;
                                }
                            }
                            if (bFound)
                                break;
                         
                        }
                        else
                        {
                            //   MessageBox.Show("Bingo Speller: " + Test);
                            bFound = true;
                            TypeResult = Level.Speller;
                            ReturnResult = Test;
                        }
                    }
                }
                spelling.Dispose();
                wordDictionary.Dispose();
            }
            else
            {
                bFound = true;
                TypeResult = Level.Exact;
                ReturnResult = Field.Result;
            }
            if (bFound)
                this.Result = ReturnResult.ToUpper();
            else
                this.Result = Field.Result.ToUpper();

            return bFound;
        }

        public ArrayList getChars(ZonalProcessor.ICRField oChar)
        {
            ArrayList Lines = new ArrayList();
            ArrayList LastLines = new ArrayList();


            for (int x = oChar.Chars.Count - 1; x != -1; x--)
            {
                if (x >= 15)
                    continue;

                ZonalProcessor.ICRChar _Char = (ZonalProcessor.ICRChar)oChar.Chars[x];
                Lines.Clear();
                if (_Char.Char == " ")
                    continue;

                if (_Char.Results.Count == 0)
                {
                    if (LastLines.Count == 0)
                    {
                        if (!Lines.Contains(_Char.Char.ToUpper()))
                            Lines.Add(_Char.Char.ToUpper());
                    }
                    else
                    {

                        foreach (String _Line in LastLines)
                        {
                            if (!Lines.Contains(_Char.Char.ToUpper() + _Line))
                                Lines.Add(_Char.Char.ToUpper() + _Line);

                        }
                    }
                }
                else
                {

                    foreach (ZonalProcessor.ICRChar __Char in _Char.Results)
                    {
                        if (__Char.Confidence >= 30)
                        {
                            if (LastLines.Count == 0)
                            {
                                if (!Lines.Contains(__Char.Char.ToUpper()))
                                    Lines.Add(__Char.Char.ToUpper());
                            }
                            else
                            {
                                foreach (String _Line in LastLines)
                                {
                                    if (!Lines.Contains(__Char.Char.ToUpper() + _Line))
                                        Lines.Add(__Char.Char.ToUpper() + _Line);
                                }
                            }
                        }
                    }

                }
                LastLines = (ArrayList)Lines.Clone();

            }
         //   Lines.Sort();
            LastLines.Clear();


            return Lines;
        }

        private  bool FindName(String Name, String FieldName)
        {
            MySQL oMySql = new MySQL();
            DataRow row;

            if (Name == "")
                return false;

            if (FieldName == "FirstName")
                row = oMySql.GetDataRow("Select * From FirstNames Where Name='" + Name + "'", "Names");
            else
                row = oMySql.GetDataRow("Select * From LastNames Where Name='" + Name + "'", "Names");


            if (row == null)
            {
                return false;
            }
            return true;

        }

        

    }

   
}
