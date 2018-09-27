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
    public class VistaTextEditor : Infragistics.Win.UltraWinEditors.UltraTextEditor
    {
        private Brush brush;
        private Bitmap tempBitmap;

        public VistaTextEditor() {
            brush = new SolidBrush(Color.FromArgb(250, base.BackColor));
        }
        
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            CreateBrush();
            this.Invalidate();
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
                case (int)NativeMethods.WM_MOUSEMOVE:
                case (int)NativeMethods.WM_PAINT:
                case (int)NativeMethods.WM_KEYDOWN:
                case (int)NativeMethods.WM_CHAR:
                     CaptureTextBoxBitmap(m.HWnd);
                    break;
            }

        }

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

    }
}
