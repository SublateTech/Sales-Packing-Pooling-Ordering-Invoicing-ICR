using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Maf.Windows.Forms.DWM.Providers;

namespace Maf.Windows.Forms.DWM.RendererProviders
{
    public class MonthCalendarRendererProvider : BaseRendererProvider
    {
        private Bitmap tempBitmap;
        private Control attachedControl;

        public override string Name
        {
            get { return "MonthCalendarRendererProvider"; }
        }

        public override Type Type
        {
            get { return typeof(System.Windows.Forms.MonthCalendar); }
        }

        public override void Dispose()
        {
            if (this.tempBitmap != null) {
                this.tempBitmap.Dispose();
            }
        }

        public override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg) { 
                case (int)WindowsMessage.WM_MOUSEMOVE:
                case (int)WindowsMessage.WM_PAINT:
                    this.CaptureBitmap(m.HWnd);
                    break;

            }
        }

        private void CaptureBitmap(IntPtr handle) {
            Control c = Control.FromHandle(handle);
            if (tempBitmap == null || tempBitmap.Size != c.Size) {
                tempBitmap = new Bitmap(c.Width, c.Height);
            }

            c.DrawToBitmap(tempBitmap, c.ClientRectangle);
            using (Graphics g = c.CreateGraphics()) {
                g.DrawImage(tempBitmap, new Point(-1, -1));
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
