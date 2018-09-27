using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Maf.Windows.Forms.DWM
{
    public class Panel : System.Windows.Forms.Panel
    {
        private Brush brush;

        public Panel() {
            brush = new SolidBrush(Color.FromArgb(128, base.BackColor));
            base.BorderStyle = BorderStyle.None;
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

        private byte transparencyLevel;

        [DefaultValue(128)]
        public byte TransparencyLevel
        {
            get { return transparencyLevel; }
            set
            {
                transparencyLevel = value;
                CreateBrush();
                this.Invalidate();
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            CreateBrush();
            this.Invalidate();
        }
	

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Image img = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(img)) {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            e.Graphics.DrawImageUnscaled(img, Point.Empty);
            img.Dispose();

            Rectangle rect = this.ClientRectangle;
            rect.Width--;
            rect.Height--;
            switch (this.BorderStyle)
            {
                case System.Windows.Forms.BorderStyle.Fixed3D:
                    e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, rect);
                    rect.Inflate(-1, -1);
                    e.Graphics.DrawRectangle(SystemPens.ControlDark, rect);
                    break;
                case System.Windows.Forms.BorderStyle.FixedSingle:
                    e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, rect);
                    break;
                case System.Windows.Forms.BorderStyle.None:
                    break;
                default:
                    break;
            }
        }

        private void CreateBrush() {
            this.brush = new SolidBrush(Color.FromArgb(this.transparencyLevel, this.BackColor));
        }
    }
}
