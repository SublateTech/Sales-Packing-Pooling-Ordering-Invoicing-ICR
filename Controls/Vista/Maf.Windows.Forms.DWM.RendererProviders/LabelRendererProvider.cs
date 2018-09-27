using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Maf.Drawing.Drawing2D;
using Maf.Windows.Forms.DWM.Providers;

namespace Maf.Windows.Forms.DWM.RendererProviders
{
    public class LabelRendererProvider : BaseRendererProvider
    {
        public LabelRendererProvider() : base() { }

        public Color BlurColor
        {
            get
            {
                if (base.NativeWindow != null && base.NativeWindow.Properties.ContainsKey("BlurColor") && base.NativeWindow.Properties["BlurColor"] is Color)
                {
                    return (Color)base.NativeWindow.Properties["BlurColor"];
                }
                return Color.Empty;
            }
            set {
                if (!base.NativeWindow.Properties.ContainsKey("BlurColor")) {
                    base.NativeWindow.Properties.Add("BlurColor", Color.Empty);
                }
                base.NativeWindow.Properties["BlurColor"] = value; 
            }
        }

        public Size BlurSize
        {
            get
            {
                if (base.NativeWindow != null && base.NativeWindow.Properties.ContainsKey("BlurSize") && base.NativeWindow.Properties["BlurSize"] is Size)
                {
                    return (Size)base.NativeWindow.Properties["BlurSize"];
                }
                return Size.Empty;
            }
            set
            {
                if (!base.NativeWindow.Properties.ContainsKey("BlurSize"))
                {
                    base.NativeWindow.Properties.Add("BlurSize", Size.Empty);
                }
                base.NativeWindow.Properties["BlurSize"] = value;
            }
        }

        public override string Name
        {
            get { return "LabelRendererProvider"; }
        }

        public override Type Type
        {
            get
            {
                return typeof(System.Windows.Forms.Label);
            }
        }

        public override void Dispose()
        {
        }

        private Control attachedControl;
        public override System.Windows.Forms.Control AttachedControl
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

        public override void WndProc(ref Message m)
        {

            switch (m.Msg) { 
                case (int)WindowsMessage.WM_PRINT:
                case (int)WindowsMessage.WM_PAINT:
                    DrawLabel(m.HWnd);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void DrawLabel(IntPtr handle)
        {
            System.Windows.Forms.Label label = Control.FromHandle(handle) as System.Windows.Forms.Label;
            if (label == null)
                return;

            using (Graphics g = label.CreateGraphics())
            {
                AdvanceDrawing.DrawBlurryTextAndImage(
                    g,
                    label.ClientRectangle,
                    label.Text,
                    label.Font,
                    label.ForeColor,
                    this.BlurColor,
                    label.TextAlign,
                    this.BlurSize,
                    label.Image,
                    label.ImageAlign);
            }
        }

    }
}
