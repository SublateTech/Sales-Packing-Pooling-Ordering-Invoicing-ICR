using System;
using System.Collections.Generic;
using System.Text;

namespace Maf.Windows.Forms.DWM
{
    public enum WindowsMessage : int
    {
        WM_PAINT = 0xf,
        WM_CHAR = 0x100,
        WM_KEYDOWN = 0x102,
        WM_PRINT = 0x314,
        WM_MOUSEMOVE = 0x200,
    }
}
