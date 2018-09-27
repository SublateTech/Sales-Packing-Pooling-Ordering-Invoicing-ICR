using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Maf.Drawing.Drawing2D
{
    public class AdvanceDrawing
    {
        /// <summary>
        /// Draw text with blur
        /// </summary>
        /// <param name="text">Text to draw</param>
        /// <param name="font">Font </param>
        /// <param name="foreColor">Text color</param>
        /// <param name="backColor">Blur color</param>
        /// <param name="blurWidth"></param>
        /// <returns>Bitmap</returns>
        public static Image DrawBlurryText(string text, Font font, Color foreColor, Color backColor, int blurWidth) {
            return DrawBlurryText(text, font, foreColor, backColor, new Size(blurWidth, blurWidth));
        }

        public static Image DrawBlurryText(string text, Font font, Color foreColor, Color backColor, Size blurSize) {
            Bitmap retBitmap = null;

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero)) {
                SizeF sz = g.MeasureString(text, font);
                using (Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height))
                using (Graphics gBmp = Graphics.FromImage(bmp))
                using (SolidBrush brBack = new SolidBrush(Color.FromArgb(16, backColor.R, backColor.G, backColor.B)))
                using (SolidBrush brFore = new SolidBrush(foreColor))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    gBmp.DrawString(text, font, brBack, 0, 0);

                    // make bitmap we will return.
                    retBitmap = new Bitmap(bmp.Width + blurSize.Width, bmp.Height + blurSize.Height);
                    using (Graphics gBmpOut = Graphics.FromImage(retBitmap))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        // smear image of background of text about to make blurred background "halo"
                        for (int x = 0; x <= blurSize.Width; x++)
                            for (int y = 0; y <= blurSize.Height; y++)
                                gBmpOut.DrawImageUnscaled(bmp, x, y);

                        // draw actual text
                        gBmpOut.DrawString(text, font, brFore, blurSize.Width / 2, blurSize.Height / 2);
                    }
                }
            }

            return retBitmap;
        }

        public static void DrawBlurryTextAndImage(
            Graphics g,
            Rectangle rect,
            string text,
            Font font,
            Color foreColor,
            Color backColor,
            ContentAlignment textAlign,
            int blurWidth,
            Image image,
            ContentAlignment imageAlign)
        {

               DrawBlurryTextAndImage(g, rect, text, font, foreColor, backColor, textAlign, 
                    new Size(blurWidth, blurWidth), image, imageAlign);
        }

        public static void DrawBlurryTextAndImage(
            Graphics g,
            Rectangle rect,
            string text,
            Font font,
            Color foreColor,
            Color backColor,
            ContentAlignment textAlign,
            Size blurSize,
            Image image,
            ContentAlignment imageAlign) {

                Point ptText = Point.Empty;
                Point ptImage = Point.Empty;
                Image imgText = null;

                if (!string.IsNullOrEmpty(text))
                    imgText = DrawBlurryText(text, font, foreColor, backColor, blurSize);

                #region Place l'image si elle existe
                if (image != null)
                {

                    switch (imageAlign)
                    {
                        case ContentAlignment.BottomCenter:
                            ptImage = new Point((rect.Width - image.Width) / 2, rect.Height - image.Height - 6);
                            break;
                        case ContentAlignment.BottomLeft:
                            ptImage = new Point(0, rect.Height - image.Height - 6);
                            break;
                        case ContentAlignment.BottomRight:
                            ptImage = new Point(rect.Width - image.Width - 6, rect.Height - image.Height - 6);
                            break;
                        case ContentAlignment.MiddleCenter:
                            ptImage = new Point((rect.Width - image.Width) / 2, (rect.Height - image.Height) / 2);
                            break;
                        case ContentAlignment.MiddleLeft:
                            ptImage = new Point(0, (rect.Height - image.Height) / 2);
                            break;
                        case ContentAlignment.MiddleRight:
                            ptImage = new Point(rect.Width - image.Width - 6, (rect.Height - image.Height) / 2);
                            break;
                        case ContentAlignment.TopCenter:
                            ptImage = new Point((rect.Width - image.Width) / 2, 0);
                            break;
                        default:
                        case ContentAlignment.TopLeft:
                            ptImage = new Point(0, 0);
                            break;
                        case ContentAlignment.TopRight:
                            ptImage = new Point(rect.Width - image.Width - 6, 0);
                            break;
                    }

                }
                #endregion

                #region Place le texte
                if (!string.IsNullOrEmpty(text))
                {
                        switch (textAlign)
                        {
                            case ContentAlignment.BottomCenter:
                                ptText = new Point((rect.Width - imgText.Width) / 2, rect.Height - imgText.Height);
                                break;
                            case ContentAlignment.BottomLeft:
                                ptText = new Point(0, rect.Height - imgText.Height);
                                break;
                            case ContentAlignment.BottomRight:
                                ptText = new Point(rect.Width - imgText.Width, rect.Height - imgText.Height);
                                break;
                            case ContentAlignment.MiddleCenter:
                                ptText = new Point((rect.Width - imgText.Width) / 2, (rect.Height - imgText.Height) / 2);
                                break;
                            case ContentAlignment.MiddleLeft:
                                ptText = new Point(0, (rect.Height - imgText.Height) / 2);
                                break;
                            case ContentAlignment.MiddleRight:
                                ptText = new Point(rect.Width - imgText.Width, (rect.Height - imgText.Height) / 2);
                                break;
                            case ContentAlignment.TopCenter:
                                ptText = new Point((rect.Width - imgText.Width) / 2, 0);
                                break;
                            default:
                            case ContentAlignment.TopLeft:
                                ptText = new Point(0, 0);
                                break;
                            case ContentAlignment.TopRight:
                                ptText = new Point(rect.Width - imgText.Width, 0);
                                break;
                        }
                }
                #endregion

                // Evite que l'image et le texte se chevauche
                if (imageAlign == textAlign &&
                    image != null &&
                    imgText != null)
                {
                    switch (imageAlign)
                    {
                        case ContentAlignment.BottomCenter:
                            ptImage.Offset(0, -(imgText.Height));
                            break;
                        case ContentAlignment.BottomLeft:
                            ptText.Offset(image.Width + 3, 0);
                            break;
                        case ContentAlignment.BottomRight:
                            ptText.Offset(-(image.Width + 9), 0);
                            break;
                        case ContentAlignment.MiddleCenter:
                            ptText.Offset(0, image.Height / 2);
                            ptImage.Offset(0, -(imgText.Height / 2));
                            break;
                        case ContentAlignment.MiddleLeft:
                            ptText.Offset(image.Width + 3, 0);
                            break;
                        case ContentAlignment.MiddleRight:
                            ptText.Offset(-(image.Width + 9), 0);
                            break;
                        case ContentAlignment.TopCenter:
                            ptText.Offset(0, image.Height);
                            break;
                        default:
                        case ContentAlignment.TopLeft:
                            ptText.Offset(image.Width + 3, 0);
                            break;
                        case ContentAlignment.TopRight:
                            ptText.Offset(-(image.Width + 9), 0);
                            break;
                    }
                }

                if (imgText != null)
                {
                    g.DrawImageUnscaled(imgText, ptText);
                    imgText.Dispose();
                }

                if (image != null) {
                    Rectangle imageRectangle = new Rectangle(ptImage, image.Size);
                    g.DrawImage(image, imageRectangle);
                }
        }

        public static void DrawTextAndImage(
            Graphics g,
            Rectangle rect,
            string text,
            Font font,
            Color foreColor,
            Color backColor,
            ContentAlignment textAlign,
            Image image,
            ContentAlignment imageAlign,
            bool enable)
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bilinear;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Point ptText = Point.Empty;
            Point ptImage = Point.Empty;
            Size textSize = g.MeasureString(text, font).ToSize();

            #region Dessin l'image si elle existe
            if (image != null)
            {

                switch (imageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        ptImage = new Point((rect.Width - image.Width) / 2, rect.Height - image.Height - 6);
                        break;
                    case ContentAlignment.BottomLeft:
                        ptImage = new Point(rect.Left, rect.Height - image.Height - 6);
                        break;
                    case ContentAlignment.BottomRight:
                        ptImage = new Point(rect.Width - image.Width - 6, rect.Height - image.Height - 6);
                        break;
                    case ContentAlignment.MiddleCenter:
                        ptImage = new Point((rect.Width - image.Width) / 2, (rect.Height - image.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        ptImage = new Point(rect.Left, (rect.Height - image.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        ptImage = new Point(rect.Width - image.Width - 6, (rect.Height - image.Height) / 2);
                        break;
                    case ContentAlignment.TopCenter:
                        ptImage = new Point((rect.Width - image.Width) / 2, rect.Top);
                        break;
                    default:
                    case ContentAlignment.TopLeft:
                        ptImage = new Point(rect.Left, rect.Top);
                        break;
                    case ContentAlignment.TopRight:
                        ptImage = new Point(rect.Width - image.Width - 6, rect.Top);
                        break;
                }

            }
            #endregion

            #region Dessine le texte
            if (!string.IsNullOrEmpty(text))
            {
                switch (textAlign)
                {
                    case ContentAlignment.BottomCenter:
                        ptText = new Point((rect.Width - textSize.Width) / 2, rect.Height - textSize.Height);
                        break;
                    case ContentAlignment.BottomLeft:
                        ptText = new Point(rect.Left, rect.Height - textSize.Height);
                        break;
                    case ContentAlignment.BottomRight:
                        ptText = new Point(rect.Width - textSize.Width, rect.Height - textSize.Height);
                        break;
                    case ContentAlignment.MiddleCenter:
                        ptText = new Point((rect.Width - textSize.Width) / 2, (rect.Height - textSize.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        ptText = new Point(rect.Left, (rect.Height - textSize.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        ptText = new Point(rect.Width - textSize.Width, (rect.Height - textSize.Height) / 2);
                        break;
                    case ContentAlignment.TopCenter:
                        ptText = new Point((rect.Width - textSize.Width) / 2, rect.Top + 2);
                        break;
                    default:
                    case ContentAlignment.TopLeft:
                        ptText = new Point(rect.Left, rect.Top + 2);
                        break;
                    case ContentAlignment.TopRight:
                        ptText = new Point(rect.Width - textSize.Width, rect.Top + 2);
                        break;
                }
            }
            #endregion

            // Evite que l'image et le texte se chevauche
            if (imageAlign == textAlign &&
                image != null &&
                !string.IsNullOrEmpty(text))
            {
                switch (imageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        ptImage.Offset(0, -(textSize.Height));
                        break;
                    case ContentAlignment.BottomLeft:
                        ptText.Offset(image.Width + 3, 0);
                        break;
                    case ContentAlignment.BottomRight:
                        ptText.Offset(-(image.Width + 9), 0);
                        break;
                    case ContentAlignment.MiddleCenter:
                        ptText.Offset(0, image.Height / 2);
                        ptImage.Offset(0, -(textSize.Height / 2));
                        break;
                    case ContentAlignment.MiddleLeft:
                        ptText.Offset(image.Width + 3, 0);
                        break;
                    case ContentAlignment.MiddleRight:
                        ptText.Offset(-(image.Width + 9), 0);
                        break;
                    case ContentAlignment.TopCenter:
                        ptText.Offset(0, image.Height);
                        break;
                    default:
                    case ContentAlignment.TopLeft:
                        ptText.Offset(image.Width + 3, 0);
                        break;
                    case ContentAlignment.TopRight:
                        ptText.Offset(-(image.Width + 9), 0);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                if (enable)
                {
                    g.DrawString(text, font, new SolidBrush(foreColor), ptText);
                }
                else { 
                    //Rectangle textRectangle = new Rectangle(ptText, textSize);
                    //ControlPaint.DrawStringDisabled(g, text, font, foreColor, textRectangle, TextFormatFlags.Default);
                    g.DrawString(text, font, new SolidBrush(SystemColors.GrayText), ptText);
                }
            }

            if (image != null)
            {
                if (!enable)
                {
                    ControlPaint.DrawImageDisabled(g, image, ptImage.X, ptImage.Y, backColor);
                }
                else
                {
                    Rectangle imageRectangle = new Rectangle(ptImage, image.Size);
                    g.DrawImage(image, imageRectangle);
                }
            }
        
        }

        public static void DrawTextAndImage(
            Graphics g,
            Rectangle rect,
            string text,
            Font font,
            Color foreColor,
            Color backColor,
            ContentAlignment textAlign,
            Image image,
            ContentAlignment imageAlign)
        {
            DrawTextAndImage(g, rect, text, font, foreColor, backColor, textAlign, image, imageAlign, true);
        }

        public static void DrawDisabledTextAndImage(
            Graphics g,
            Rectangle rect,
            string text,
            Font font,
            Color foreColor,
            Color backColor,
            ContentAlignment textAlign,
            Image image,
            ContentAlignment imageAlign) {
                DrawTextAndImage(g, rect, text, font, foreColor, backColor, textAlign, image, imageAlign, false);
        }
    }
}
