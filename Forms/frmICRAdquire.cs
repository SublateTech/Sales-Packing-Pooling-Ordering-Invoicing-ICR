using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Signature.Classes;
using Signature.Twain;



namespace Signature.Forms
{
    public class frmTwain : System.Windows.Forms.Form, IMessageFilter
    {
        private System.Windows.Forms.MenuItem menuMainFile;
        private System.Windows.Forms.MenuItem menuItemScan;
        private System.Windows.Forms.MenuItem menuItemSelSrc;
        private System.Windows.Forms.MenuItem menuMainWindow;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemSepr;
        private System.Windows.Forms.MainMenu mainFrameMenu;
        private MenuItem mnSetup;
        private MenuItem mnShowUI;
        private MenuItem mnShowImages;
        private MenuItem menuItem1;
        private IContainer components;

        private String _CompanyID;
        private String _CustomerID;
        private String _Batch;
        private String _Teacher;
        private ScannedImages oImages = new ScannedImages();

        public frmTwain()
        {
            InitializeComponent();
            tw = new CTwain();
            tw.Init(this.Handle);
            GetGlobalParameters();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tw.Finish();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTwain));
            this.menuMainFile = new System.Windows.Forms.MenuItem();
            this.menuItemSelSrc = new System.Windows.Forms.MenuItem();
            this.menuItemScan = new System.Windows.Forms.MenuItem();
            this.mnSetup = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnShowUI = new System.Windows.Forms.MenuItem();
            this.mnShowImages = new System.Windows.Forms.MenuItem();
            this.menuItemSepr = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.mainFrameMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuMainWindow = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // menuMainFile
            // 
            this.menuMainFile.Index = 0;
            this.menuMainFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSelSrc,
            this.menuItemScan,
            this.mnSetup,
            this.menuItem1,
            this.mnShowUI,
            this.mnShowImages,
            this.menuItemSepr,
            this.menuItemExit});
            this.menuMainFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuMainFile.Text = "&File";
            // 
            // menuItemSelSrc
            // 
            this.menuItemSelSrc.Index = 0;
            this.menuItemSelSrc.MergeOrder = 11;
            this.menuItemSelSrc.Text = "&Select Source...";
            this.menuItemSelSrc.Click += new System.EventHandler(this.menuItemSelSrc_Click);
            // 
            // menuItemScan
            // 
            this.menuItemScan.Index = 1;
            this.menuItemScan.MergeOrder = 12;
            this.menuItemScan.Text = "&Acquire...";
            this.menuItemScan.Click += new System.EventHandler(this.menuItemScan_Click);
            // 
            // mnSetup
            // 
            this.mnSetup.Index = 2;
            this.mnSetup.Text = "Setup Scanner";
            this.mnSetup.Click += new System.EventHandler(this.mnSetup_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // mnShowUI
            // 
            this.mnShowUI.Index = 4;
            this.mnShowUI.Text = "Show UI";
            this.mnShowUI.Click += new System.EventHandler(this.mnShowUI_Click);
            // 
            // mnShowImages
            // 
            this.mnShowImages.Index = 5;
            this.mnShowImages.Text = "Show Images";
            this.mnShowImages.Click += new System.EventHandler(this.mnShowImages_Click);
            // 
            // menuItemSepr
            // 
            this.menuItemSepr.Index = 6;
            this.menuItemSepr.MergeOrder = 19;
            this.menuItemSepr.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 7;
            this.menuItemExit.MergeOrder = 21;
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // mainFrameMenu
            // 
            this.mainFrameMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuMainFile,
            this.menuMainWindow});
            // 
            // menuMainWindow
            // 
            this.menuMainWindow.Index = 1;
            this.menuMainWindow.MdiList = true;
            this.menuMainWindow.Text = "&Window";
            // 
            // frmTwain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1315, 609);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainFrameMenu;
            this.Name = "frmTwain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner Setup";
            this.Load += new System.EventHandler(this.frmTwain_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void menuItemScan_Click(object sender, System.EventArgs e)
        {
            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Acquire(mnShowUI.Checked ? (short)1 : (short)0, (short)1);
        }

        private void menuItemSelSrc_Click(object sender, System.EventArgs e)
        {
            tw.Select();
        }

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

                        if (!this.mnShowImages.Checked)
                        {
                            if (oImages.Find(_CompanyID, _CustomerID, _Teacher))
                            {
                              //  ImgNumber = oImages._ImageFinal;
                            }

                           // oImages._ImageInitial = 1;
                            oImages.CompanyID = _CompanyID;
                            oImages.CustomerID = _CustomerID;


                        }



                        int i;
                        for (i = 0; i < pics.Count; i++)
                        {

                            IntPtr img = (IntPtr)pics[i];

                            if (this.mnShowImages.Checked)
                            {
                                PicForm newpic = new PicForm(img);
                                newpic.MdiParent = this;
                                //Panel.Controls.Add((Control)newpic);

                                int picnum = ImgNumber + i + 1;
                                //newpic.Text = "ScanPass" + picnumber.ToString() + "_Pic" + picnum.ToString();
                                newpic.Text = "Order" + picnumber.ToString() + "_Pic" + picnum.ToString();
                                newpic.Show();
                            }
                            else
                            {

                                bmprect = new Rectangle(0, 0, 0, 0);
                                bmpptr = GlobalLock(img);
                                pixptr = GetPixelInfo(bmpptr);
                                int picnum = ImgNumber + i + 1;

                                //Gdip.SavePicToFile("ScanPass" + picnum.ToString() + ".tiff", bmpptr, pixptr);
                                Gdip.SavePicToFile("Images/Order-" + _CompanyID.PadLeft(2, '0') + _CustomerID.PadLeft(4, '0') + _Batch.PadLeft(3, '0') + picnum.ToString().PadLeft(4, '0') + ".tif", bmpptr, pixptr);
                            }

                        }
                        if (!this.mnShowImages.Checked)
                        {
                            //Save Batch Here

                         //   oImages._ImageFinal = ImgNumber + i;
                            //oImages._NumberImages += i;
                            oImages.Teacher = _Teacher;
                            oImages.Save();

                        }

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

        private bool msgfilter;
        private CTwain tw;
        private int picnumber = 0;
        static BITMAPINFOHEADER bmi;
        static Rectangle bmprect;



        private void mnSetup_Click(object sender, EventArgs e)
        {
            if (!msgfilter)
            {
                this.Enabled = false;
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Setup();

        }
        private void mnShowUI_Click(object sender, EventArgs e)
        {
            if (!mnShowUI.Checked)
                mnShowUI.Checked = true;
            else
                mnShowUI.Checked = false;
        }
        private void mnShowImages_Click(object sender, EventArgs e)
        {
            if (!mnShowImages.Checked)
                mnShowImages.Checked = true;
            else
                mnShowImages.Checked = false;
        }
        private void ultraToolbarsTwain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key.ToString())
            {
                case "Adquire":
                    if (!msgfilter)
                    {
                        this.Enabled = false;
                        msgfilter = true;
                        Application.AddMessageFilter(this);
                    }
                    tw.Acquire(mnShowUI.Checked ? (short)1 : (short)0, (short)1);
                    break;

            }


        }

        private void GetGlobalParameters()
        {

            _CompanyID = Global.GetParameter("CurrentCompany");
            _CustomerID = Global.GetParameter("CurrentCustomer");
            _Batch = Global.GetParameter("CurrentBatch");
            _Teacher = Global.GetParameter("CurrentTeacher");

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

        private void frmTwain_Load(object sender, EventArgs e)
        {
            this.GetGlobalParameters();
        }

    }
} 
