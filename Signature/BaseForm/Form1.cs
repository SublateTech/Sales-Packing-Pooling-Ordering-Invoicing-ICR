using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace Kobush.Windows.Forms
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

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
            this.components = new System.ComponentModel.Container();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.labelResize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFile
            // 
            this.labelFile.BackColor = System.Drawing.Color.Transparent;
            this.labelFile.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelFile.Location = new System.Drawing.Point(8, 24);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(32, 19);
            this.labelFile.TabIndex = 0;
            this.labelFile.Text = "File";
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFile.MouseLeave += new System.EventHandler(this.labelFile_MouseLeave);
            this.labelFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelFile_MouseUp);
            this.labelFile.MouseEnter += new System.EventHandler(this.labelFile_MouseEnter);
            // 
            // labelHelp
            // 
            this.labelHelp.BackColor = System.Drawing.Color.Transparent;
            this.labelHelp.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelHelp.Location = new System.Drawing.Point(64, 24);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(32, 19);
            this.labelHelp.TabIndex = 1;
            this.labelHelp.Text = "Help";
            this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHelp.MouseLeave += new System.EventHandler(this.labelHelp_MouseLeave);
            this.labelHelp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelHelp_MouseUp);
            this.labelHelp.MouseEnter += new System.EventHandler(this.labelHelp_MouseEnter);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuExit});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "menuItem1";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 2;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // labelResize
            // 
            this.labelResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResize.AutoSize = true;
            this.labelResize.BackColor = System.Drawing.Color.Transparent;
            this.labelResize.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelResize.Location = new System.Drawing.Point(506, 361);
            this.labelResize.Name = "labelResize";
            this.labelResize.Size = new System.Drawing.Size(17, 11);
            this.labelResize.TabIndex = 2;
            this.labelResize.Text = "o";
            this.labelResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelResize_MouseMove);
            this.labelResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelResize_MouseDown);
            this.labelResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelResize_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 375);
            this.Controls.Add(this.labelResize);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Shaped Form Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /*
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

*/
        private Region TitleBar
        {
            get { return new Region(new Rectangle(0, 0, Width, 26)); }
        }


        private GraphicsPath CloseButton
        {
            get
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(new Rectangle(Width - 26, 3, 18, 18));
                return gp;
            }
        }


        private GraphicsPath MinButton
        {
            get
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(new Rectangle(Width - 49, 3, 18, 18));
                return gp;
            }
        }


        private GraphicsPath FormShape
        {
            get
            {
                GraphicsPath gp = new GraphicsPath();
                Rectangle r = ClientRectangle;
                int radius = 12;

                gp.AddArc(r.Left, r.Top + 24, radius, radius, 180, 90);
                gp.AddArc(r.Left + 80 - radius, r.Top + 24 - radius, radius, radius, -270, -90);
                gp.AddArc(r.Left + 80, r.Top, radius, radius, 180, 90);
                gp.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
                gp.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                gp.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
                gp.CloseFigure();

                return gp;
            }
        }


        private bool ClosePress = false;
        private bool MinPress = false;
        private bool FormDrag = false;
        private bool FileActive = false;
        private bool HelpActive = false;
        private bool FileHot = false;
        private bool HelpHot = false;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.Label labelResize;
        private const int HT_CAPTION = 0x2;

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int WS_CLIPCHILDREN = 0x2000000;
                const int WS_MINIMIZEBOX = 0x20000;
                //const int WS_MAXIMIZEBOX = 0x10000;
                const int WS_SYSMENU = 0x80000;

                const int CS_DBLCLKS = 0x8;
                const int CS_DROPSHADOW = 0x20000;

                int ClassFlags = CS_DBLCLKS;
                int OSVER = Environment.OSVersion.Version.Major * 10;
                OSVER += Environment.OSVersion.Version.Minor;
                if (OSVER >= 51) ClassFlags = CS_DBLCLKS | CS_DROPSHADOW;

                cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU; //| WS_MAXIMIZEBOX
                cp.ClassStyle = ClassFlags;

                return cp;
            }
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.labelFile.Location = new Point(2, 26);
            this.labelHelp.Location = new Point(labelFile.Right, 26);
            this.labelFile.Font = SystemInformation.MenuFont;
            this.labelHelp.Font = SystemInformation.MenuFont;
            this.Region = new Region(FormShape);
        }


        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRegion(Brushes.Green, TitleBar);
            e.Graphics.FillRectangle(SystemBrushes.Menu, new Rectangle(0, 26, Width, 19));

            if (FileHot) e.Graphics.FillRectangle(SystemBrushes.Highlight, labelFile.Bounds);
            if (HelpHot) e.Graphics.FillRectangle(SystemBrushes.Highlight, labelHelp.Bounds);

            Pen BorderPen = new Pen(Color.Green, 2);
            BorderPen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawPath(BorderPen, FormShape);
            BorderPen.Dispose();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            sf.Trimming = StringTrimming.EllipsisCharacter;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(this.Text, Control.DefaultFont, Brushes.White, RectangleF.FromLTRB(84, 0, MinButton.GetBounds().X, 24), sf);

            if (ClosePress)
                e.Graphics.FillPath(Brushes.Blue, CloseButton);
            else
                e.Graphics.FillPath(Brushes.Red, CloseButton);

            if (MinPress)
                e.Graphics.FillPath(Brushes.Red, MinButton);
            else
                e.Graphics.FillPath(Brushes.Yellow, MinButton);

            Font GlyphFont = new Font("marlett", Font.SizeInPoints, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("0", GlyphFont, Brushes.Black, MinButton.GetBounds(), sf);
            e.Graphics.DrawString("r", GlyphFont, Brushes.Black, CloseButton.GetBounds(), sf);
            GlyphFont.Dispose();

        }


        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ClosePress = CloseButton.IsVisible(e.X, e.Y) && e.Button == MouseButtons.Left;
            MinPress = MinButton.IsVisible(e.X, e.Y) && e.Button == MouseButtons.Left;
            FormDrag = TitleBar.IsVisible(e.X, e.Y) &&
            e.Button == MouseButtons.Left &&
                ClosePress == false && MinPress == false;

            if (FormDrag)
            {
                this.Capture = false;
                Message msg = Message.Create(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
                WndProc(ref msg);
            }

            Invalidate();

        }


        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool OverClose, OverMin;
            OverClose = CloseButton.IsVisible(e.X, e.Y);
            OverMin = MinButton.IsVisible(e.X, e.Y);
            ClosePress = OverClose && e.Button == MouseButtons.Left;
            MinPress = OverMin && e.Button == MouseButtons.Left;

            if (OverClose && ClosePress == false)
                toolTip1.SetToolTip(this, "Close");
            else if (OverMin && MinPress == false)
                toolTip1.SetToolTip(this, "Minimize");
            else
                toolTip1.SetToolTip(this, "");

            Invalidate();

        }


        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool OverClose, OverMin;
            OverClose = CloseButton.IsVisible(e.X, e.Y);
            OverMin = MinButton.IsVisible(e.X, e.Y);

            if (OverClose && ClosePress && e.Button == MouseButtons.Left)
                this.Close();
            if (OverMin && MinPress && e.Button == MouseButtons.Left)
                this.WindowState = FormWindowState.Minimized;

            if (e.Button == MouseButtons.Right && TitleBar.IsVisible(e.X, e.Y))
            {
                if (OverClose == false && OverMin == false)
                {
                    const int WM_GETSYSMENU = 0x313;
                    if (e.Button == MouseButtons.Right)
                    {
                        Point pos = this.PointToScreen(new Point(e.X, e.Y));
                        IntPtr hPos = (IntPtr)((int)((pos.Y * 0x10000) | (pos.X & 0xFFFF)));
                        Message msg = Message.Create(this.Handle, WM_GETSYSMENU, IntPtr.Zero, hPos);
                        WndProc(ref msg);
                    }
                }
            }

            ClosePress = false;
            MinPress = false;
            FormDrag = false;

            Invalidate();

        }


        private void menuAbout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Shaped Form Example!\nBy Mick Doherty (http://dotnetrix.co.uk)", "About...", MessageBoxButtons.OK);
        }


        private void menuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }


        private void labelHelp_MouseEnter(object sender, System.EventArgs e)
        {
            HelpHot = true;
            labelHelp.ForeColor = SystemColors.HighlightText;
            Invalidate();
        }


        private void labelHelp_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HelpActive = true;
            contextMenu2.Show(labelHelp, new Point(0, labelHelp.Height));
            HelpActive = false;
            labelHelp.ForeColor = SystemColors.MenuText;
            Invalidate();
        }


        private void labelHelp_MouseLeave(object sender, System.EventArgs e)
        {
            if (HelpActive == false)
            {
                HelpHot = false;
                labelHelp.ForeColor = SystemColors.MenuText;
            }
            Invalidate();
        }


        private void labelFile_MouseEnter(object sender, System.EventArgs e)
        {
            FileHot = true;
            labelFile.ForeColor = SystemColors.HighlightText;
            Invalidate();
        }


        private void labelFile_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            FileActive = true;
            contextMenu1.Show(labelFile, new Point(0, labelFile.Height));
            FileActive = false;
            labelFile.ForeColor = SystemColors.MenuText;
            Invalidate();
        }


        private void labelFile_MouseLeave(object sender, System.EventArgs e)
        {
            if (FileActive == false)
            {
                FileHot = false;
                labelFile.ForeColor = SystemColors.MenuText;
            }
            Invalidate();
        }


        private bool Sizing = false;
        private Point SizeOffset = Point.Empty;

        private void labelResize_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Sizing = true;
            SizeOffset = new Point(this.Right - Cursor.Position.X, this.Bottom - Cursor.Position.Y);
        }


        private void labelResize_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Sizing)
            {
                //Clip cursor to dissallow sizing of form below 250x100
                Rectangle ClipRectangle = RectangleToScreen(new Rectangle(250, 100, Width, Height));
                ClipRectangle.Offset(SizeOffset);
                Cursor.Clip = ClipRectangle;
                this.Size = new Size(Cursor.Position.X + SizeOffset.X - Location.X, Cursor.Position.Y + SizeOffset.Y - Location.Y);
            }
        }


        private void labelResize_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Sizing = false;
            Cursor.Clip = Rectangle.Empty;
        }


        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            this.Region = new Region(FormShape);
        }


    }
}
