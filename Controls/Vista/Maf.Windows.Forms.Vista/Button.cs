using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using Maf.Drawing.Drawing2D;

namespace Maf.Windows.Forms.DWM
{
    public class Button : System.Windows.Forms.Button
    {
        private PushButtonState buttonState = PushButtonState.Normal;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (DWMNativeMethods.IsCompositionEnable())
            {
                Rectangle clientRectangle = new Rectangle(0, 0, this.Width, this.Height);
                ButtonRenderer.DrawParentBackground(pevent.Graphics, this.Bounds, this.Parent);

                ButtonRenderer.DrawButton(pevent.Graphics, clientRectangle, this.buttonState);

                //Image imgText = AdvanceDrawing.DrawBlurryText(this.Text, this.Font, this.ForeColor, this.BackColor, 1);
                //Point ptText = new Point((this.Width - imgText.Width) / 2, (this.Height - imgText.Height) / 2);
                //pevent.Graphics.DrawImageUnscaled(imgText, ptText);

                //imgText.Dispose();
                Rectangle rect = this.ClientRectangle;
                rect.Inflate(-Margin.Horizontal, -Margin.Vertical);
                //rect.Offset(-Margin.Left, -Margin.Top);

                if (this.Enabled)
                {
                    AdvanceDrawing.DrawTextAndImage(
                        pevent.Graphics,
                        rect,
                        this.Text,
                        this.Font,
                        this.ForeColor,
                        this.BackColor,
                        this.TextAlign,
                        this.Image,
                        this.ImageAlign);
                }
                else {
                    AdvanceDrawing.DrawDisabledTextAndImage(
                        pevent.Graphics,
                        rect,
                        this.Text,
                        this.Font,
                        this.ForeColor,
                        this.BackColor,
                        this.TextAlign,
                        this.Image,
                        this.ImageAlign);
                }
            }
            else {
                base.OnPaint(pevent);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (DWMNativeMethods.IsCompositionEnable()) {
                pevent.Graphics.Clear(Color.Black);
            }
            else
            {
                base.OnPaintBackground(pevent);
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.buttonState = PushButtonState.Pressed;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.buttonState = PushButtonState.Hot;
            this.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.buttonState = PushButtonState.Hot;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.buttonState = PushButtonState.Default;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.buttonState = PushButtonState.Default;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.buttonState = PushButtonState.Normal;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!this.Enabled)
            {
                this.buttonState = PushButtonState.Disabled;
            }
        }
    }
}
