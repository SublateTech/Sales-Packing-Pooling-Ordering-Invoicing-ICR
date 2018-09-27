using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Maf.Windows.Forms.DWM.Providers;

namespace Maf.Windows.Forms.DWM.RendererProviders
{
    public class DateTimePickerRendererProvider : BaseRendererProvider
    {
        private Bitmap tempBitmap;
        private Control attachedControl;

        public override string Name
        {
            get { return "DateTimePickerRendererProvider"; }
        }

        public override Type Type
        {
            get { return typeof(System.Windows.Forms.DateTimePicker); }
        }

        public override void Dispose()
        {
            if (this.tempBitmap != null) {
                this.tempBitmap.Dispose();
            }
        }

        public override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg) { 
                case (int)WindowsMessage.WM_PAINT:
                case (int)WindowsMessage.WM_KEYDOWN:
                case (int)WindowsMessage.WM_CHAR:
                case (int)WindowsMessage.WM_MOUSEMOVE:
                    CaptureBitmap(m.HWnd);
                    break;
            }
        }

        private void CaptureBitmap(IntPtr handle) {
            Control c = Control.FromHandle(handle);
            if (this.tempBitmap == null || tempBitmap.Size != c.Size) {
                tempBitmap = new Bitmap(c.Width, c.Height);
            }

            c.DrawToBitmap(tempBitmap, c.ClientRectangle);
            using (Graphics g = c.CreateGraphics()) {
                g.DrawImage(tempBitmap, new Point(0, 0));
            }
            c = null;
        }

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
