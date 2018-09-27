using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.ComponentModel;

namespace Signature.Windows.Forms
{
    public class RegionMaker
    {
        public enum TransparencyMode
        {
            /// <summary>
            /// the color key is used to define the transparent region of the bitmap
            /// </summary>
            ColorKeyTransparent,
            /// <summary>
            /// the color key is used to define the area that should _not_ be transparent
            /// </summary>
            ColorKeyOpaque
        }

        private Color _transparentColor = Color.Empty;
        private Bitmap _bmpSource;

        public BackgroundWorker graphicsPathWorker;

        public RegionMaker()
        {
            graphicsPathWorker = new BackgroundWorker();
            graphicsPathWorker.DoWork += new DoWorkEventHandler(graphicsPathWorker_DoWork);
        }

        public RegionMaker(Image source) : this()
        {
            if (source != null)
                ImageSource = source;
        }

        public Image ImageSource
        {
            get
            {
                return _bmpSource;
            }

            set
            {
                if (!graphicsPathWorker.IsBusy)
                {
                    _bmpSource = new Bitmap(value);
                    TransparentColor = _bmpSource.GetPixel(1, 1);
                }
            }
        }

        public void Start()
        {
            if (!graphicsPathWorker.IsBusy)
            {
                graphicsPathWorker.WorkerReportsProgress = true;
                graphicsPathWorker.RunWorkerAsync();
            }
        }

        public Color TransparentColor
        {
            get
            {
                return _transparentColor;
            }
            set
            {
                _transparentColor = value;
            }
        }

        private void graphicsPathWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            
            // Create GraphicsPath for our bitmap calculation
            GraphicsPath graphicsPath = new GraphicsPath();

            //flag = true means the color key represents the opaque color
            bool modeFlag = false; //TransparencyMode.ColorKeyOpaque;

            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = _bmpSource.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.Left, (int)boundsF.Top,
                (int)boundsF.Width, (int)boundsF.Height);

            uint key = (uint)((_transparentColor.A << 24) |
                      (_transparentColor.R << 16) |
                      (_transparentColor.G << 8) |
                      (_transparentColor.B << 0));

            //get access to the raw bits of the image
            BitmapData bitmapData = _bmpSource.LockBits(bounds, ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            unsafe
            {

                uint* pixelPtr = (uint*)bitmapData.Scan0.ToPointer();

                //avoid property accessors in the for
                int yMax = (int)boundsF.Height;
                int xMax = (int)boundsF.Width;

                for (int y = 0; y < yMax; y++)
                {

                    int percent = (int)(((double)y / (double)_bmpSource.Height) * 100);
                    graphicsPathWorker.ReportProgress(percent);

                    //store the pointer so we can offset the stride directly
                    //from it later to get to the next line
                    byte* basePos = (byte*)pixelPtr;

                    for (int x = 0; x < xMax; x++, pixelPtr++)
                    {

                        //is this transparent? if yes, just go on with the loop
                        if (modeFlag ^ (*pixelPtr == key))
                            continue;

                        //store where the scan starts
                        int x0 = x;

                        //not transparent - scan until we find the next
                        //transparent byte
                        while (x < xMax && !(modeFlag ^ (*pixelPtr == key)))
                        {
                            ++x;
                            pixelPtr++;
                        }

                        //add the rectangle we have found to the path
                        graphicsPath.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                    }

                    //jump to the next line
                    pixelPtr = (uint*)(basePos + bitmapData.Stride);
                }
            }

            _bmpSource.UnlockBits(bitmapData);

            e.Result = new Region(graphicsPath);
        }
    }
  }
