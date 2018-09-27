using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Signature.Vista
{
    public static class ApiVista
    {
        //[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        //public extern static int DwmIsCompositionEnabled(ref int en);

        //[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        //public extern static int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margin margin); 

        public static Color ConvertFromWin32Color( int color )
        {
            int r = color & 0X000000FF;
            int g = ( color & 0X0000FF00 ) >> 8;
            int b = ( color & 0X00FF0000 ) >> 16;
            return Color.FromArgb( r, g, b );
        }

        #region API, P/Invoke
        #region Méthodes
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margin pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmEnableComposition(bool fEnable);

        [DllImport("dwmapi.dll")]
        private static extern int DwmEnableMMCSS(bool fEnable);

        [DllImport("dwmapi.dll")]
        private static extern int DwmGetColorizationColor(out int pcrColorization, out bool pfOpaqueBlend);

        [DllImport("dwmapi.dll")]
        private static extern int DwmDefWindowProc(IntPtr hwnd, UInt16 msg, long wParam, long lParam, out int plResult);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref BlurBehind blurBehind);

        [DllImport("dwmapi.dll")]
        private static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, out TimingInfo pTimingInfo);

        [DllImport("dwmapi.dll")]
        private static extern int DwmGetWindowAttribute(IntPtr hwnd, long dwAttribute, out object pvAttribute, long cbAttribute);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool pfEnabled);

        [DllImport("dwmapi.dll")]
        private static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, Int16 cRefreshes, bool fRelative);

        //[DllImport("dwmapi.dll")]
        //private static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, Size pSize);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmRegisterThumbnail(int hwndDestination, int hwndSource, IntPtr pReserved, IntPtr phThumbnailId);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern int DwmSetDxFrameDuration(IntPtr hwnd, Int16 cRefreshes);

        //[DllImport("dwmapi.dll", PreserveSig=false)]
        //private static extern int DwmSetPresentParameters(IntPtr hwnd, DWM_PRESENT_PARAMETERS *pPresentParams);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, WindowAttribute dwAttribute, ref object pvAttribute, int pvAttributeSize);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmUpdateThumbnailProperties(int hThumbnailId, IntPtr ptnProperties);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct BlurBehind
        {
            public BlurBehindEnum Flags;
            public bool Enable;
            public IntPtr RgnBlur;
            public bool TransitionOnMaximized;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TimingInfo { }

        [StructLayout(LayoutKind.Sequential)]
        public struct ThumbnailProperties
        {
            long dwFlags;
            RECT rcDestination;
            RECT rcSource;
            byte opacity;
            bool fVisible;
            bool fSourceClientAreaOnly;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            //public RECT(int left, int top, int width, int height) : this(left, top, left + width, top + height) {}

            public RECT(Rectangle rect) : this(rect.Left, rect.Top, rect.Right, rect.Bottom) { }

            public Rectangle ToRectangle()
            {
                return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
            }

        }

        #endregion

        public enum WindowAttribute : long
        {
            DWMWA_NCRENDERING_ENABLED = 1,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_LAST
        }


        [Flags]
        public enum BlurBehindEnum : uint
        {
            DWM_BB_ENABLE = 0x00000001,
            DWM_BB_BLURREGION = 0x00000002,
            DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004
        }
        #endregion

        public static bool ExtendFrameIntoClientArea(IntPtr handle, ref Margin margins)
        {
            if (!IsCompositionEnable())
            {
                return false;
            }

            return DwmExtendFrameIntoClientArea(handle, ref margins) == 0;
        }

        public static bool ExtendFrameIntoClientArea(Form form, ref Margin margins)
        {
            if (!IsCompositionEnable())
            {
                return false;
            }

            return ExtendFrameIntoClientArea(form.Handle, ref margins);
        }

        public static void EnableBlurBehindWindow(Form form)
        {
            EnableBlurBehindWindow(form, Rectangle.Empty);
        }

        public static void EnableBlurBehindWindow(Form form, Rectangle rect)
        {
            if (!IsCompositionEnable())
            {
                return;
            }

            BlurBehind blurStr = new BlurBehind();
            blurStr.Enable = true;
            blurStr.Flags = BlurBehindEnum.DWM_BB_ENABLE | BlurBehindEnum.DWM_BB_TRANSITIONONMAXIMIZED | BlurBehindEnum.DWM_BB_BLURREGION;
            blurStr.RgnBlur = CreateRegionFromRectangle(rect);
            blurStr.TransitionOnMaximized = false;
            EnableBlurBehindWindow(form, ref blurStr);
        }

        private static void EnableBlurBehindWindow(Form form, ref BlurBehind blurStr)
        {
            if (!IsCompositionEnable())
            {
                return;
            }

            EnableBlurBehindWindow(form.Handle, ref blurStr);
        }

        private static void EnableBlurBehindWindow(IntPtr handle, ref BlurBehind blurStr)
        {
            if (!IsCompositionEnable())
            {
                return;
            }

            DwmEnableBlurBehindWindow(handle, ref blurStr);
        }

        public static IntPtr CreateRegionFromRectangle(Rectangle rect)
        {
            return CreateRectRgn(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        public static bool IsCompositionEnable()
        {
            bool isEnable;
            DwmIsCompositionEnabled(out isEnable);

            return isEnable;
        }
    }

}
