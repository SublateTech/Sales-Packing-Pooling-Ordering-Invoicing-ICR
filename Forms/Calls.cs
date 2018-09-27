using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Signature.Classes;


namespace Signature.Forms
{
    public partial class Calls : System.Windows.Forms.Control
    {

        Timer oTimer = new Timer();

        

        public Calls()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            if (!InDesignMode())
            {
                oTimer.Tick += new EventHandler(oTimer_Tick);
                oTimer.Interval = 3000;
                oTimer.Start();
            }

            //Context Menu
            ContextMenu contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();

            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2});
            menuItem1.Index = 0;
            menuItem1.Text = "Open";
            menuItem2.Index = 1;
            menuItem2.Text = "Close";
            
            menuItem1.Click += new EventHandler(this.menuitem_Click);
            menuItem2.Click += new EventHandler(this.menuitem_Click);
            

            this.ContextMenu = contextMenu1;
        }
        
        private void menuitem_Click(object sender, System.EventArgs e)
        {
               // MessageBox.Show("Hey!!");.e.ToString();
            switch(((System.Windows.Forms.MenuItem) sender).Index)
            {
                case 0:
                    Global.ShowNotifier("Option 1");
                    break;
                case 1:
                    Global.ShowNotifier("Option 2");
                    break;
            }
        } 
        
        void oTimer_Tick(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            oTimer.Stop();
           // MessageBox.Show("Hey!!");
            if (!InDesignMode())
            {
              //  Global.ShowNotifier("Good");
            }
           // Global.Message = InDesignMode().ToString();
            oTimer.Start();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(e);
            //Graphics gph = e.Graphics; //this.CreateGraphics();
            this.Height = Signature.Forms.Properties.Resources.customer.Height;
            this.Width = Signature.Forms.Properties.Resources.customer.Width;

            
            /*
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(e.Graphics);
            */
            e.Graphics.DrawImage(Signature.Forms.Properties.Resources.office_building, new Point(0, 0));
            DrawBackgroundShadows(e.Graphics);
            DrawOuterStroke(e.Graphics);
            DrawText(e.Graphics);
            e.Dispose();
        }

        private void DrawText(Graphics g)
        {

            Rectangle r = new Rectangle(4, this.Height - 14, this.Width - 4, this.Height - 4);
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), r,StringFormat.GenericDefault);
        }	

        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }
        private void DrawBackground(Graphics g)
        {
            Rectangle r = this.ClientRectangle; r.Width--; r.Height--;
            GraphicsPath rr = RoundRect(r, 2, 2, 2, 2);
            g.FillPath(new SolidBrush(this.BackgroundColor), rr);
        }
        private void DrawBackgroundShadows(Graphics g)
        {
            Rectangle lr = new Rectangle(2, 2, 10, this.Height - 5);
            LinearGradientBrush lg = new LinearGradientBrush(lr, Color.FromArgb(30, 0, 0, 0),
                                                             Color.Transparent,
                                                             LinearGradientMode.Horizontal);
            lr.X--;
            g.FillRectangle(lg, lr);

            Rectangle rr = new Rectangle(this.Width - 12, 2, 10, this.Height - 5);
            LinearGradientBrush rg = new LinearGradientBrush(rr, Color.Transparent,
                                                             Color.FromArgb(20, 0, 0, 0),
                                                             LinearGradientMode.Horizontal);
            g.FillRectangle(rg, rr);
        }
        private void DrawOuterStroke(Graphics g)
        {
            Rectangle r = this.ClientRectangle; r.Width--; r.Height--;
            GraphicsPath rr = RoundRect(r, 2, 2, 2, 2);
            g.DrawPath(new Pen(Color.FromArgb(178, 178, 178)), rr);
        }
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }

        private Color mBackgroundColor = Color.FromArgb(201, 201, 201);
        /// <summary>
        /// The color of the background.
        /// </summary>
        [Category("Highlights and Glows"),
        DefaultValue(typeof(Color), "201,201,201"),
        Description("The color of the background.")]
        public Color BackgroundColor
        {
            get { return mBackgroundColor; }
            set { mBackgroundColor = value; this.Invalidate(); }
        }
    }
}
