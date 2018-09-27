using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Signature.Windows.Forms
{
    [ToolboxBitmap(typeof(TextBox))]
    public class VistaTextBox : System.Windows.Forms.TextBox
    {
        
        private Brush brush;
        private Bitmap tempBitmap;

        public VistaTextBox() {

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            
            brush = new SolidBrush(Color.FromArgb(250, base.BackColor));
            base.BorderStyle = BorderStyle.Fixed3D;
        }
        
        private string cueBannerText_ = string.Empty;
        [Description("Gets or sets the cue text that is displayed on a TextBox control."), Category("Appearance"), DefaultValue("")]
        public string CueBannerText
        {
            get {
                return cueBannerText_;
            }
            set {
                cueBannerText_ = value;
                this.SetCueText();
            }
        }

        private void SetCueText()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETCUEBANNER, IntPtr.Zero, cueBannerText_);
        }

        private System.Windows.Forms.BorderStyle borderStyle;
        public new System.Windows.Forms.BorderStyle BorderStyle
        {
            get { return this.borderStyle; }
            set
            {
                this.borderStyle = value;
                this.Invalidate();
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            CreateBrush();
            this.Invalidate();
        }

        protected  void PaintBorder()
        {
            Control c = Control.FromHandle(this.Handle);
            Graphics e = c.CreateGraphics();
            Image img = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            e.DrawImageUnscaled(img, Point.Empty);
            img.Dispose();

            Rectangle rect = this.ClientRectangle;
            rect.Width--;
            rect.Height--;
            switch (this.BorderStyle)
            {
                case System.Windows.Forms.BorderStyle.Fixed3D:
                    e.DrawRectangle(SystemPens.ControlDarkDark, rect);
                    rect.Inflate(-1, -1);
                    e.DrawRectangle(SystemPens.ControlDark, rect);
                    break;
                case System.Windows.Forms.BorderStyle.FixedSingle:
                    e.DrawRectangle(SystemPens.ControlDarkDark, rect);
                    break;
                case System.Windows.Forms.BorderStyle.None:
                    break;
                default:
                    break;
            }
        }

        private void CreateBrush()
        {
            this.brush = new SolidBrush(Color.FromArgb(250, this.BackColor));
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            switch (m.Msg)
            {
                case (int)NativeMethods.WM_RBUTTONDOWN:
                case (int)NativeMethods.WM_LBUTTONDOWN:
                //case (int)NativeMethods.WM_MOUSEMOVE:
                case (int)NativeMethods.WM_PAINT:
                case (int)NativeMethods.WM_KEYDOWN:
                case (int)NativeMethods.WM_CHAR:
                     CaptureTextBoxBitmap(m.HWnd);
                    //PaintBorder();
                    break;
            }
           if (this.Visible)
                borderDrawer.DrawBorder(ref m, this.Width, this.Height);

        }
        

        public void RedrawControlAsBitmap(IntPtr hwnd)
        {

            Control c = Control.FromHandle(hwnd);

            using (Bitmap bm = new Bitmap(c.Width, c.Height))
            {
                c.DrawToBitmap(bm, c.ClientRectangle);

                using (Graphics g = c.CreateGraphics())
                    g.DrawImage(bm, new Point(-1, -1));

            }


            c = null;


        } //Optional ROutine
        
        private void CaptureTextBoxBitmap(IntPtr handle)
        {
            Control c = Control.FromHandle(handle);
            if (tempBitmap == null || tempBitmap.Size != c.Size)
            {
                tempBitmap = new Bitmap(c.Width, c.Height);
            }
            c.DrawToBitmap(tempBitmap, c.ClientRectangle);
            using (Graphics g = c.CreateGraphics())
            {
                g.DrawImage(tempBitmap, new Point(-1, -1));
            }
            c = null;
        }

        private BorderDrawer borderDrawer = new BorderDrawer();

        public Color BorderColor
        {
            get { return borderDrawer.BorderColor; }
            set
            {
                borderDrawer.BorderColor = value;
                Invalidate();
            }
        }

    }
}
