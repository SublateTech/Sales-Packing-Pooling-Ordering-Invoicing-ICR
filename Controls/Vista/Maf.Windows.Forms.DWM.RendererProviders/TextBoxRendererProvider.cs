using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Maf.Windows.Forms.DWM.Providers;

namespace Maf.Windows.Forms.DWM.RendererProviders
{
    public class TextBoxRendererProvider : BaseRendererProvider
    {
        private Bitmap tempBitmap;
        public override string Name
        {
            get { return "TextBoxRendererProvider"; }
        }

        public override Type Type
        {
            get { return typeof(TextBox); }
        }

        public override void Dispose()
        {
            if (tempBitmap != null)
            {
                tempBitmap.Dispose();
            }
        }

        public override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg) {
                case (int)WindowsMessage.WM_MOUSEMOVE:
                case (int)WindowsMessage.WM_PAINT:
                case (int)WindowsMessage.WM_KEYDOWN:
                case (int)WindowsMessage.WM_CHAR:
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


        private Control attachedControl;
        public override Control AttachedControl
        {
            get
            {
                return this.attachedControl;
            }
            set
            {
                this.attachedControl = value;
            }
        }
    }
}
