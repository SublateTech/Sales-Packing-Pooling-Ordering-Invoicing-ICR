using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace Signature.Twain
{


public class Gdip
	{
	private static ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

	private static bool GetCodecClsid( string filename, out Guid clsid )
		{
		clsid = Guid.Empty;
		string ext = Path.GetExtension( filename );
		if( ext == null )
			return false;
		ext = "*" + ext.ToUpper();
		foreach( ImageCodecInfo codec in codecs )
			{
			if( codec.FilenameExtension.IndexOf( ext ) >= 0 )
				{
				clsid = codec.Clsid;
				return true;
				}
			}
		return false;
		}


	public static bool SaveDIBAs( string picname, IntPtr bminfo, IntPtr pixdat )
		{
		SaveFileDialog sd = new SaveFileDialog();

		sd.FileName = picname;
		sd.Title = "Save bitmap as...";
		sd.Filter = "Bitmap file (*.bmp)|*.bmp|TIFF file (*.tif)|*.tif|JPEG file (*.jpg)|*.jpg|PNG file (*.png)|*.png|GIF file (*.gif)|*.gif|All files (*.*)|*.*";
		sd.FilterIndex = 1;
		if( sd.ShowDialog() != DialogResult.OK )
			return false;

		Guid clsid;
		if( ! GetCodecClsid( sd.FileName, out clsid ) )
			{
			MessageBox.Show( "Unknown picture format for extension " + Path.GetExtension( sd.FileName ),
							"Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information );
			return false;
			}
		
		IntPtr img = IntPtr.Zero;
		int st = GdipCreateBitmapFromGdiDib( bminfo, pixdat, ref img );
		if( (st != 0) || (img == IntPtr.Zero) )
			return false;

		st = GdipSaveImageToFile( img, sd.FileName, ref clsid, IntPtr.Zero );
		GdipDisposeImage( img );
		return st == 0;
		}

    public static bool SavePicToFile(string FileName, IntPtr bminfo, IntPtr pixdat)
    {
        
        Guid clsid;
        if (!GetCodecClsid(FileName, out clsid))
        {
            MessageBox.Show("Unknown picture format for extension " + Path.GetExtension(FileName),
                            "Image Codec", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        IntPtr img = IntPtr.Zero;
        int st = GdipCreateBitmapFromGdiDib(bminfo, pixdat, ref img);
        if ((st != 0) || (img == IntPtr.Zero))
            return false;

        st = GdipSaveImageToFile(img, FileName, ref clsid, IntPtr.Zero);
        GdipDisposeImage(img);
        return st == 0;
    }

    protected static IntPtr GetPixelInfo(IntPtr bmpptr)
    {

        bmprect = new Rectangle(0, 0, 0, 0);
        bmi = new BITMAPINFOHEADER();
        Marshal.PtrToStructure(bmpptr, bmi);

        bmprect.X = bmprect.Y = 0;
        bmprect.Width = bmi.biWidth;
        bmprect.Height = bmi.biHeight;

        if (bmi.biSizeImage == 0)
            bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

        int p = bmi.biClrUsed;
        if ((p == 0) && (bmi.biBitCount <= 8))
            p = 1 << bmi.biBitCount;
        p = (p * 4) + bmi.biSize + (int)bmpptr;
        return (IntPtr)p;
    }

    static BITMAPINFOHEADER bmi;
    static Rectangle bmprect;
    

	[DllImport("gdiplus.dll", ExactSpelling=true)]
	internal static extern int GdipCreateBitmapFromGdiDib( IntPtr bminfo, IntPtr pixdat, ref IntPtr image );

	[DllImport("gdiplus.dll", ExactSpelling=true, CharSet=CharSet.Unicode)]
	internal static extern int GdipSaveImageToFile( IntPtr image, string filename, [In] ref Guid clsid, IntPtr encparams );

	[DllImport("gdiplus.dll", ExactSpelling=true)]
	internal static extern int GdipDisposeImage( IntPtr image );

	}
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public class BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    }

} // namespace GdiPlusLib
