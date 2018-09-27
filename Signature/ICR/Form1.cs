using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PegasusImaging.WinForms.SSXICR4;

namespace Signature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            introductionLabel.Text = "This sample demonstrates the following functionality:" + 
                      "Using the ICR recognition capabilities to retrieve results from 3 defined fields within an .FDL file." + 
        "The results are returned as a string by the FieldResultStr method indicating the recognized data for each field.";

        PicImagXpress1.RaiseExceptions = true;
        Picssxicr1.RaiseExceptions = true;

            
        PicImagXpress1.AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;
        PicImagXpress1.FileName = Application.StartupPath + "\\..\\..\\Images\\SigFormataData.tif";

        //MessageBox.Show(Application.StartupPath + "\\..\\..\\Images\\SignatureForm 005.tif");
        PicImagXpress1.Deskew(PegasusImaging.WinForms.ImagXpress7.enumDeskewType.DESKEW_Normal);

        Picssxicr1.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
        Picssxicr1.hDIB = PicImagXpress1.hDIB;
        //set the classifier path here
        Picssxicr1.ClassifierPath = Application.StartupPath + "\\..\\..\\Classifiers\\Data";
        Picssxicr1.LoadForm(Application.StartupPath + "\\..\\..\\FDL\\SigFormata.fdl");
        }

        private void ProcessICRFields_Click(object sender, EventArgs e)
        {
            
        
        Int16  index;
        int pLeft=0, pTop=0, pWidth=0, pHeight=0;
        Color[] mColor = new Color[] { Color.Red, Color.Green, Color.Blue };

        int  mColorIndex  = 0;

        PicImagXpress1.ColorDepth(24, PegasusImaging.WinForms.ImagXpress7.enumPalette.IPAL_Optimized, PegasusImaging.WinForms.ImagXpress7.enumDithered.DI_None);
        PicImagXpress1.DrawWidth = 8;

        Picssxicr1.StartFormProcessing();
        //Picssxicr1.AddFieldPreprocessImageAction(-1,pePreprocessImageAction.PP_DESPECKLE ,  "1,1");
        //Picssxicr1.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
        //Picssxicr1.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_VERT_WHITE, "2");
        //Picssxicr1.PreprocessImage();

        //Picssxicr1.AddFieldPreprocessImageAction(-1, pePreprocessImageAction.PP_FILL_LINE_HORIZ_WHITE, "2");
        //Picssxicr1.FormFieldRetainImage

        for ( index = 1 ; index != Picssxicr1.GetFormNumFields()+1; index++)
            {
            Picssxicr1.SelectFormFieldIndex(index);
            Picssxicr1.GetFieldBounds(ref pLeft, ref pTop, ref pWidth, ref pHeight);

            //draw where the fields are on the image, for illustration purposes only
            PicImagXpress1.DrawRoundRect(pLeft, pTop, pLeft + pWidth, pTop + pHeight, 0, 0, mColor[mColorIndex]);

            mColorIndex = mColorIndex + 1;
            if (mColorIndex > mColor.GetUpperBound(0))  mColorIndex = 0;

            if (Picssxicr1.FieldError != 0) 
            {
                // if error on this field display error in list
                /* resultsList.Items.Add(New ListViewItem( new String() {index.ToString(), 
                                    Picssxicr1.GetFieldName(), 
                                    Picssxicr1.FieldErrorString, 
                                    ""})); */
            }
            else
            {
               // demonstrates reading each character of result
                MessageBox.Show(Picssxicr1.FieldResultStr);
                
               /* charResult = "";
                for (charIndex = 1;  Picssxicr1.FieldResultChars != charIndex; charIndex++)
                {
                    Picssxicr1.FieldResultLineChar = charIndex;
                    charResult = charResult + Picssxicr1.FieldResultChar(1);
                    
                }*/

               /* resultsList.Items.Add(New ListViewItem( 
                    New String() {index.ToString(), 
                                    Picssxicr1.GetFieldName(), 
                                    Picssxicr1.FieldResultStr, 
                                    charResult}));*/

            }

            }

        }

        }
    }
