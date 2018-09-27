using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Maf.Drawing.Drawing2D;
using System.ComponentModel;

namespace Maf.Windows.Forms.DWM
{
    public class Label : System.Windows.Forms.Label
    {
        private Size blur = new Size(6, 4);

        [DefaultValue("6; 4")]
        [Category("Appearance")]
        public Size Blur
        {
            get { return blur; }
            set { 
                blur = value;
                this.Invalidate();
            }
        }

        private Color blurColor = Color.Black;

        [DefaultValue("Black")]
        [Category("Appearance")]
        public Color BlurColor
        {
            get { return blurColor; }
            set { 
                blurColor = value;
                this.Invalidate();
            }
        }

	
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            AdvanceDrawing.DrawBlurryTextAndImage(
                e.Graphics,
                this.ClientRectangle,
                this.Text,
                this.Font,
                this.ForeColor,
                this.blurColor,
                this.TextAlign,
                this.blur,
                this.Image,
                this.ImageAlign);
        }
    }
}
