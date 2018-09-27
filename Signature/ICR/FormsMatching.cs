using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Signature
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormsMatching : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button LoadTemplateForms;
		private System.Windows.Forms.Button MatchCompletedForms;
		private System.Windows.Forms.TabControl FilledFormsTabControl;
		private System.Windows.Forms.TabControl BlankFormsTabControl;
		private PegasusImaging.WinForms.ImagXpress7.PICImagXpress[] IXblank;
		private PegasusImaging.WinForms.ImagXpress7.PICImagXpress[] IXfilled;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string[] filledForms = new string[]{
																Application.StartupPath + "\\..\\..\\Images\\SigFormataData.tif",
																Application.StartupPath + "\\..\\..\\Images\\irsFilled.tif",
																Application.StartupPath + "\\..\\..\\Images\\voterFilled.tif" };
		private string[] blankForms = new string[]{
																Application.StartupPath + "\\..\\..\\Images\\voterBlank.tif",
																Application.StartupPath + "\\..\\..\\Images\\irsBlank.tif",
																Application.StartupPath + "\\..\\..\\Images\\SigFormata.tif"
																 };
		
		private System.Windows.Forms.Label statusLabel;
        private PegasusImaging.WinForms.SSXICR4.PICSSXICR picssxicr1;
		private System.Windows.Forms.Label label1;
		
		private string[] matchedtemplate = new string[3];

		public FormsMatching()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		/*	introductionLabel.Text = "This sample demonstrates the forms matching capability of SmartScan.\n" +
				"1) Select \"Load Template Forms\" which loads the blank form images into the template database.\n" +
				"2) Select \"Match Completed Forms\" which loads a filled in version of each blank form " + 
				"and attempts to match it with one of the blank forms in the template database.\n" +
				"3) The MatchTemplate method returns the name of the matched form if successful.\n";
            */
			IXblank = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress[3];
			IXfilled = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress[3];
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label2 = new System.Windows.Forms.Label();
            this.FilledFormsTabControl = new System.Windows.Forms.TabControl();
            this.BlankFormsTabControl = new System.Windows.Forms.TabControl();
            this.LoadTemplateForms = new System.Windows.Forms.Button();
            this.MatchCompletedForms = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.picssxicr1 = new PegasusImaging.WinForms.SSXICR4.PICSSXICR();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 730);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filled in Forms:";
            // 
            // FilledFormsTabControl
            // 
            this.FilledFormsTabControl.Location = new System.Drawing.Point(388, 176);
            this.FilledFormsTabControl.Name = "FilledFormsTabControl";
            this.FilledFormsTabControl.SelectedIndex = 0;
            this.FilledFormsTabControl.Size = new System.Drawing.Size(346, 528);
            this.FilledFormsTabControl.TabIndex = 7;
            this.FilledFormsTabControl.SelectedIndexChanged += new System.EventHandler(this.FilledFormsTabControl_SelectedIndexChanged);
            // 
            // BlankFormsTabControl
            // 
            this.BlankFormsTabControl.Location = new System.Drawing.Point(8, 176);
            this.BlankFormsTabControl.Name = "BlankFormsTabControl";
            this.BlankFormsTabControl.SelectedIndex = 0;
            this.BlankFormsTabControl.Size = new System.Drawing.Size(365, 528);
            this.BlankFormsTabControl.TabIndex = 8;
            this.BlankFormsTabControl.SelectedIndexChanged += new System.EventHandler(this.BlankFormsTabControl_SelectedIndexChanged);
            // 
            // LoadTemplateForms
            // 
            this.LoadTemplateForms.Location = new System.Drawing.Point(456, 16);
            this.LoadTemplateForms.Name = "LoadTemplateForms";
            this.LoadTemplateForms.Size = new System.Drawing.Size(160, 32);
            this.LoadTemplateForms.TabIndex = 10;
            this.LoadTemplateForms.Text = "Load Template Forms";
            this.LoadTemplateForms.Click += new System.EventHandler(this.LoadTemplateForms_Click);
            // 
            // MatchCompletedForms
            // 
            this.MatchCompletedForms.Enabled = false;
            this.MatchCompletedForms.Location = new System.Drawing.Point(456, 72);
            this.MatchCompletedForms.Name = "MatchCompletedForms";
            this.MatchCompletedForms.Size = new System.Drawing.Size(160, 32);
            this.MatchCompletedForms.TabIndex = 11;
            this.MatchCompletedForms.Text = "Match Completed Forms";
            this.MatchCompletedForms.Click += new System.EventHandler(this.MatchCompletedForms_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(5, 743);
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
            this.picssxicr1.SN = "PSIPU400QJ-TKEKJ98XAYW";
            this.picssxicr1.SSEdition = PegasusImaging.WinForms.SSXICR4.peSSEdition.SS_EDITION_Professional;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 730);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Blank Forms:";
            // 
            // FormsMatching
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(746, 787);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.MatchCompletedForms);
            this.Controls.Add(this.LoadTemplateForms);
            this.Controls.Add(this.BlankFormsTabControl);
            this.Controls.Add(this.FilledFormsTabControl);
            this.Controls.Add(this.label2);
            this.Name = "FormsMatching";
            this.Text = "Forms Matching";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	/*	/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormsMatching());
		}*/

		private void LoadTemplateForms_Click(object sender, System.EventArgs e)
		{		
			System.Windows.Forms.TabPage newtabpage;

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			picssxicr1.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
			picssxicr1.OwnDIB = true;			

			string newtabName;
			for(int i=0; i<3; i++ )
			{
				//create new tab and add to tabcontrol. 
				//create new IX7 control and place it on new tab
				newtabName = blankForms[i].Substring(blankForms[i].LastIndexOf("\\")+1);
				newtabpage = new System.Windows.Forms.TabPage();
				newtabpage.Text = newtabName;
				newtabpage.TabIndex = i;
				BlankFormsTabControl.Controls.Add(newtabpage);
				BlankFormsTabControl.SelectedIndex = i;
				IXblank[i] = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
				IXblank[i].Parent = newtabpage;
				IXblank[i].Left = IXblank[i].Top = 0;
				IXblank[i].Width = newtabpage.Width;
				IXblank[i].Height = newtabpage.Height;
				newtabpage.Controls.Add( IXblank[i] );
                
				IXblank[i].AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;
				IXblank[i].FileName = blankForms[i];
				statusLabel.Text = blankForms[i] + " is being added to template database";
				Application.DoEvents();
				picssxicr1.hDIB = IXblank[i].CopyDIB();
				picssxicr1.AddTemplateImage( newtabName );				
			}

			statusLabel.Text = "Template Forms Added To Database";
			MatchCompletedForms.Enabled = true;
			LoadTemplateForms.Enabled = false;

			this.Cursor = System.Windows.Forms.Cursors.Default;
		
		}

		private void MatchCompletedForms_Click(object sender, System.EventArgs e)
		{
			
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusLabel.Text = "Form Matching In Progress ... Please Wait";	
			Application.DoEvents();
			System.Windows.Forms.TabPage newtabpage;
			string newtabName;
			int minConfidence = 80;
			int lMatchedConfidence =  0;
			int sensitivity = 60;

			picssxicr1.ImageSource = PegasusImaging.WinForms.SSXICR4.peImageSource.IMGSRC_DIB;
			picssxicr1.OwnDIB = true;					
			
			
			for(int i=0; i<3; i++ )
			{
				//create new tab and add to tabcontrol. 
				//create new IX7 control and place it on new tab
                //MessageBox.Show(filledForms[i]);
                newtabName = filledForms[i].Substring(filledForms[i].LastIndexOf("\\")+1);
				newtabpage = new System.Windows.Forms.TabPage(newtabName);				
				newtabpage.TabIndex = i;
				FilledFormsTabControl.Controls.Add(newtabpage);				
				IXfilled[i] = new PegasusImaging.WinForms.ImagXpress7.PICImagXpress();
				IXfilled[i].Parent = newtabpage;
				IXfilled[i].Left = IXfilled[i].Top = 0;
				IXfilled[i].Width = newtabpage.Width;
				IXfilled[i].Height = newtabpage.Height;
				newtabpage.Controls.Add( IXfilled[i] );

				IXfilled[i].AutoSize = PegasusImaging.WinForms.ImagXpress7.enumAutoSize.ISIZE_BestFit;
				IXfilled[i].FileName = filledForms[i];				
				picssxicr1.hDIB = IXfilled[i].CopyDIB();

				matchedtemplate[i] = picssxicr1.MatchTemplate(true,false, minConfidence, sensitivity, ref lMatchedConfidence);
				IXfilled[i].hDIB = picssxicr1.GetPreprocessImagehDIB();			
			    picssxicr1.DeletePreprocessImage();

				FilledFormsTabControl.SelectedIndex = i;				
			}

			
			statusLabel.Text = "Form Matching Complete";

			MatchCompletedForms.Enabled = false;
			LoadTemplateForms.Enabled = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void FilledFormsTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			for(int i=0; i<BlankFormsTabControl.Controls.Count; i++)											
				if (BlankFormsTabControl.Controls[i].Text == matchedtemplate[FilledFormsTabControl.SelectedIndex])					
					BlankFormsTabControl.SelectedIndex = i;		
		}

		private void BlankFormsTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  for(int i=0; i<3; i++)			
				if (BlankFormsTabControl.SelectedTab.Text == matchedtemplate[i])
					FilledFormsTabControl.SelectedIndex = i;			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
