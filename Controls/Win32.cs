using System;
using System.Runtime.InteropServices;


namespace Win32
{

	#region enums

	/// <summary>
	/// from '.\PlatformSDK\Include\WinUser.h'
	/// </summary>
	internal enum WM : int
	{
		NULL                   = 0x0000,
		CREATE                 = 0x0001,
		DESTROY                = 0x0002,
		MOVE                   = 0x0003,
		SIZE                   = 0x0005,
		ACTIVATE               = 0x0006,
		SETFOCUS               = 0x0007,
		KILLFOCUS              = 0x0008,
		ENABLE                 = 0x000A,
		SETREDRAW              = 0x000B,
		SETTEXT                = 0x000C,
		GETTEXT                = 0x000D,
		GETTEXTLENGTH          = 0x000E,
		PAINT                  = 0x000F,
		CLOSE                  = 0x0010,
		QUERYENDSESSION        = 0x0011,
		QUIT                   = 0x0012,
		QUERYOPEN              = 0x0013,
		ERASEBKGND             = 0x0014,
		SYSCOLORCHANGE         = 0x0015,
		ENDSESSION             = 0x0016,
		SHOWWINDOW             = 0x0018,
		CTLCOLOR               = 0x0019,
		WININICHANGE           = 0x001A,
		SETTINGCHANGE          = 0x001A,
		DEVMODECHANGE          = 0x001B,
		ACTIVATEAPP            = 0x001C,
		FONTCHANGE             = 0x001D,
		TIMECHANGE             = 0x001E,
		CANCELMODE             = 0x001F,
		SETCURSOR              = 0x0020,
		MOUSEACTIVATE          = 0x0021,
		CHILDACTIVATE          = 0x0022,
		QUEUESYNC              = 0x0023,
		GETMINMAXINFO          = 0x0024,
		PAINTICON              = 0x0026,
		ICONERASEBKGND         = 0x0027,
		NEXTDLGCTL             = 0x0028,
		SPOOLERSTATUS          = 0x002A,
		DRAWITEM               = 0x002B,
		MEASUREITEM            = 0x002C,
		DELETEITEM             = 0x002D,
		VKEYTOITEM             = 0x002E,
		CHARTOITEM             = 0x002F,
		SETFONT                = 0x0030,
		GETFONT                = 0x0031,
		SETHOTKEY              = 0x0032,
		GETHOTKEY              = 0x0033,
		QUERYDRAGICON          = 0x0037,
		COMPAREITEM            = 0x0039,
		GETOBJECT              = 0x003D,
		COMPACTING             = 0x0041,
		COMMNOTIFY             = 0x0044,
		WINDOWPOSCHANGING      = 0x0046,
		WINDOWPOSCHANGED       = 0x0047,
		POWER                  = 0x0048,
		COPYDATA               = 0x004A,
		CANCELJOURNAL          = 0x004B,
		NOTIFY                 = 0x004E,
		INPUTLANGCHANGEREQUEST = 0x0050,
		INPUTLANGCHANGE        = 0x0051,
		TCARD                  = 0x0052,
		HELP                   = 0x0053,
		USERCHANGED            = 0x0054,
		NOTIFYFORMAT           = 0x0055,
		CONTEXTMENU            = 0x007B,
		STYLECHANGING          = 0x007C,
		STYLECHANGED           = 0x007D,
		DISPLAYCHANGE          = 0x007E,
		GETICON                = 0x007F,
		SETICON                = 0x0080,
		NCCREATE               = 0x0081,
		NCDESTROY              = 0x0082,
		NCCALCSIZE             = 0x0083,
		NCHITTEST              = 0x0084,
		NCPAINT                = 0x0085,
		NCACTIVATE             = 0x0086,
		GETDLGCODE             = 0x0087,
		SYNCPAINT              = 0x0088,
		NCMOUSEMOVE            = 0x00A0,
		NCLBUTTONDOWN          = 0x00A1,
		NCLBUTTONUP            = 0x00A2,
		NCLBUTTONDBLCLK        = 0x00A3,
		NCRBUTTONDOWN          = 0x00A4,
		NCRBUTTONUP            = 0x00A5,
		NCRBUTTONDBLCLK        = 0x00A6,
		NCMBUTTONDOWN          = 0x00A7,
		NCMBUTTONUP            = 0x00A8,
		NCMBUTTONDBLCLK        = 0x00A9,
		KEYDOWN                = 0x0100,
		KEYUP                  = 0x0101,
		CHAR                   = 0x0102,
		DEADCHAR               = 0x0103,
		SYSKEYDOWN             = 0x0104,
		SYSKEYUP               = 0x0105,
		SYSCHAR                = 0x0106,
		SYSDEADCHAR            = 0x0107,
		KEYLAST                = 0x0108,
		IME_STARTCOMPOSITION   = 0x010D,
		IME_ENDCOMPOSITION     = 0x010E,
		IME_COMPOSITION        = 0x010F,
		IME_KEYLAST            = 0x010F,
		INITDIALOG             = 0x0110,
		COMMAND                = 0x0111,
		SYSCOMMAND             = 0x0112,
		TIMER                  = 0x0113,
		HSCROLL                = 0x0114,
		VSCROLL                = 0x0115,
		INITMENU               = 0x0116,
		INITMENUPOPUP          = 0x0117,
		MENUSELECT             = 0x011F,
		MENUCHAR               = 0x0120,
		ENTERIDLE              = 0x0121,
		MENURBUTTONUP          = 0x0122,
		MENUDRAG               = 0x0123,
		MENUGETOBJECT          = 0x0124,
		UNINITMENUPOPUP        = 0x0125,
		MENUCOMMAND            = 0x0126,
		CHANGEUISTATE          = 0x0127,
		UPDATEUISTATE          = 0x0128,
		QUERYUISTATE           = 0x0129,
		CTLCOLORMSGBOX         = 0x0132,
		CTLCOLOREDIT           = 0x0133,
		CTLCOLORLISTBOX        = 0x0134,
		CTLCOLORBTN            = 0x0135,
		CTLCOLORDLG            = 0x0136,
		CTLCOLORSCROLLBAR      = 0x0137,
		CTLCOLORSTATIC         = 0x0138,
		MOUSEMOVE              = 0x0200,
		LBUTTONDOWN            = 0x0201,
		LBUTTONUP              = 0x0202,
		LBUTTONDBLCLK          = 0x0203,
		RBUTTONDOWN            = 0x0204,
		RBUTTONUP              = 0x0205,
		RBUTTONDBLCLK          = 0x0206,
		MBUTTONDOWN            = 0x0207,
		MBUTTONUP              = 0x0208,
		MBUTTONDBLCLK          = 0x0209,
		MOUSEWHEEL             = 0x020A,
		PARENTNOTIFY           = 0x0210,
		ENTERMENULOOP          = 0x0211,
		EXITMENULOOP           = 0x0212,
		NEXTMENU               = 0x0213,
		SIZING                 = 0x0214,
		CAPTURECHANGED         = 0x0215,
		MOVING                 = 0x0216,
		DEVICECHANGE           = 0x0219,
		MDICREATE              = 0x0220,
		MDIDESTROY             = 0x0221,
		MDIACTIVATE            = 0x0222,
		MDIRESTORE             = 0x0223,
		MDINEXT                = 0x0224,
		MDIMAXIMIZE            = 0x0225,
		MDITILE                = 0x0226,
		MDICASCADE             = 0x0227,
		MDIICONARRANGE         = 0x0228,
		MDIGETACTIVE           = 0x0229,
		MDISETMENU             = 0x0230,
		ENTERSIZEMOVE          = 0x0231,
		EXITSIZEMOVE           = 0x0232,
		DROPFILES              = 0x0233,
		MDIREFRESHMENU         = 0x0234,
		IME_SETCONTEXT         = 0x0281,
		IME_NOTIFY             = 0x0282,
		IME_CONTROL            = 0x0283,
		IME_COMPOSITIONFULL    = 0x0284,
		IME_SELECT             = 0x0285,
		IME_CHAR               = 0x0286,
		IME_REQUEST            = 0x0288,
		IME_KEYDOWN            = 0x0290,
		IME_KEYUP              = 0x0291,
		MOUSEHOVER             = 0x02A1,
		MOUSELEAVE             = 0x02A3,
		CUT                    = 0x0300,
		COPY                   = 0x0301,
		PASTE                  = 0x0302,
		CLEAR                  = 0x0303,
		UNDO                   = 0x0304,
		RENDERFORMAT           = 0x0305,
		RENDERALLFORMATS       = 0x0306,
		DESTROYCLIPBOARD       = 0x0307,
		DRAWCLIPBOARD          = 0x0308,
		PAINTCLIPBOARD         = 0x0309,
		VSCROLLCLIPBOARD       = 0x030A,
		SIZECLIPBOARD          = 0x030B,
		ASKCBFORMATNAME        = 0x030C,
		CHANGECBCHAIN          = 0x030D,
		HSCROLLCLIPBOARD       = 0x030E,
		QUERYNEWPALETTE        = 0x030F,
		PALETTEISCHANGING      = 0x0310,
		PALETTECHANGED         = 0x0311,
		HOTKEY                 = 0x0312,
		PRINT                  = 0x0317,
		PRINTCLIENT            = 0x0318,
		HANDHELDFIRST          = 0x0358,
		HANDHELDLAST           = 0x035F,
		AFXFIRST               = 0x0360,
		AFXLAST                = 0x037F,
		PENWINFIRST            = 0x0380,
		PENWINLAST             = 0x038F,
		APP                    = 0x8000,
		USER                   = 0x0400,
		REFLECT                = WM.USER + 0x1c00,
	}



	/// <summary>
	/// from '.\PlatformSDK\Include\OleCtl.h'
	/// </summary>
	internal enum OCM : int
	{
		BASE				= WM.REFLECT,
		COMMAND				= BASE + WM.COMMAND,
		CTLCOLORBTN			= BASE + WM.CTLCOLORBTN,
		CTLCOLOREDIT		= BASE + WM.CTLCOLOREDIT,
		CTLCOLORDLG			= BASE + WM.CTLCOLORDLG,
		CTLCOLORLISTBOX		= BASE + WM.CTLCOLORLISTBOX,
		CTLCOLORMSGBOX		= BASE + WM.CTLCOLORMSGBOX,
		CTLCOLORSCROLLBAR	= BASE + WM.CTLCOLORSCROLLBAR,
		CTLCOLORSTATIC		= BASE + WM.CTLCOLORSTATIC,
		CTLCOLOR		    = BASE + WM.CTLCOLOR,
		DRAWITEM			= BASE + WM.DRAWITEM,
		MEASUREITEM			= BASE + WM.MEASUREITEM,
		DELETEITEM			= BASE + WM.DELETEITEM,
		VKEYTOITEM			= BASE + WM.VKEYTOITEM,
		CHARTOITEM			= BASE + WM.CHARTOITEM,
		COMPAREITEM			= BASE + WM.COMPAREITEM,
		HSCROLL				= BASE + WM.HSCROLL,
		VSCROLL				= BASE + WM.VSCROLL,
		PARENTNOTIFY		= BASE + WM.PARENTNOTIFY,
		NOTIFY				= BASE + WM.NOTIFY,
	}



	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum Base : int
	{
		LVM = 0x1000,
		TV  = 0x1100,
		HDM = 0x1200,
		TCM = 0x1300,
		PGM = 0x1400,
		ECM = 0x1500,
		BCM = 0x1600,
		CBM = 0x1700,
		CCM = 0x2000,
		NM  = 0x0000,
		LVN = NM - 100,
		HDN = NM - 300,
		EM  = 0x400,
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum NM : int
	{
		FIRST           = Base.NM,
		OUTOFMEMORY     = FIRST - 1,
		CLICK           = FIRST - 2,
		DBLCLK          = FIRST - 3,
		RETURN          = FIRST - 4,
		RCLICK          = FIRST - 5,
		RDBLCLK         = FIRST - 6,
		SETFOCUS        = FIRST - 7,
		KILLFOCUS       = FIRST - 8,
		CUSTOMDRAW      = FIRST - 12,
		HOVER           = FIRST - 13,
		NCHITTEST       = FIRST - 14,
		KEYDOWN         = FIRST - 15,
		RELEASEDCAPTURE = FIRST - 16,
		SETCURSOR       = FIRST - 17,
		CHAR            = FIRST - 18,
		TOOLTIPSCREATED = FIRST - 19,
		LDOWN           = FIRST - 20,
		RDOWN           = FIRST - 21,
		THEMECHANGED    = FIRST - 22,
	}



	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum HDM : int
	{
		FIRST                  = Base.HDM,
		GETITEMCOUNT           = FIRST + 0,
		INSERTITEMA            = FIRST + 1,
		DELETEITEM             = FIRST + 2,
		GETITEMA               = FIRST + 3,
		SETITEMA               = FIRST + 4,
		LAYOUT                 = FIRST + 5,
		HITTEST                = FIRST + 6,
		GETITEMRECT            = FIRST + 7,
		SETIMAGELIST           = FIRST + 8,
		GETIMAGELIST           = FIRST + 9,
		INSERTITEMW            = FIRST + 10,
		GETITEMW               = FIRST + 11,
		SETITEMW               = FIRST + 12,
		ORDERTOINDEX           = FIRST + 15,
		CREATEDRAGIMAGE        = FIRST + 16,
		GETORDERARRAY          = FIRST + 17,
		SETORDERARRAY          = FIRST + 18,
		SETHOTDIVIDER          = FIRST + 19,
		SETBITMAPMARGIN        = FIRST + 20,
		GETBITMAPMARGIN        = FIRST + 21,
		SETFILTERCHANGETIMEOUT = FIRST + 22,
		EDITFILTER             = FIRST + 23,
		CLEARFILTER            = FIRST + 24,
	}
	
	/// <summary>
	/// from '.\PlatformSDK\Include\Richedit.h'
	/// </summary>
	internal enum EM : int
	{
		FIRST				= Base.EM,
		GETLIMITTEXT		= FIRST + 37,
		POSFROMCHAR			= FIRST + 38,
		CHARFROMPOS			= FIRST + 39,
		SCROLLCARET			= FIRST + 49,
		CANPASTE			= FIRST + 50,
		DISPLAYBAND			= FIRST + 51,
		EXGETSEL			= FIRST + 52,
		EXLIMITTEXT			= FIRST + 53,
		EXLINEFROMCHAR		= FIRST + 54,
		EXSETSEL			= FIRST + 55,
		FINDTEXT			= FIRST + 56,
		FORMATRANGE			= FIRST + 57,
		GETCHARFORMAT		= FIRST + 58,
		GETEVENTMASK		= FIRST + 59,
		GETOLEINTERFACE		= FIRST + 60,
		GETPARAFORMAT		= FIRST + 61,
		GETSELTEXT			= FIRST + 62,
		HIDESELECTION		= FIRST + 63,
		PASTESPECIAL		= FIRST + 64,
		REQUESTRESIZE		= FIRST + 65,
		SELECTIONTYPE		= FIRST + 66,
		SETBKGNDCOLOR		= FIRST + 67,
		SETCHARFORMAT		= FIRST + 68,
		SETEVENTMASK		= FIRST + 69,
		SETOLECALLBACK		= FIRST + 70,
		SETPARAFORMAT		= FIRST + 71,
		SETTARGETDEVICE		= FIRST + 72,
		STREAMIN			= FIRST + 73,
		STREAMOUT			= FIRST + 74,
		GETTEXTRANGE		= FIRST + 75,
		FINDWORDBREAK		= FIRST + 76,
		SETOPTIONS			= FIRST + 77,
		GETOPTIONS			= FIRST + 78,
		FINDTEXTEX			= FIRST + 79,
		GETWORDBREAKPROCEX	= FIRST + 80,
		SETWORDBREAKPROCEX	= FIRST + 81,
		// RichEdit 2.0 messages
		SETUNDOLIMIT		= FIRST + 82,
		REDO				= FIRST + 84,
		CANREDO				= FIRST + 85,
		GETUNDONAME			= FIRST + 86,
		GETREDONAME			= FIRST + 87,
		STOPGROUPTYPING		= FIRST + 88,
		SETTEXTMODE			= FIRST + 89,
		GETTEXTMODE			= FIRST + 90,
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum HDN : int
	{
		FIRST            = Base.HDN,
		ITEMCHANGINGA    = FIRST - 0,
		ITEMCHANGINGW    = FIRST - 20,
		ITEMCHANGEDA     = FIRST - 1,
		ITEMCHANGEDW     = FIRST - 21,
		ITEMCLICKA       = FIRST - 2,
		ITEMCLICKW       = FIRST - 22,
		ITEMDBLCLICKA    = FIRST - 3,
		ITEMDBLCLICKW    = FIRST - 23,
		DIVIDERDBLCLICKA = FIRST - 5,
		DIVIDERDBLCLICKW = FIRST - 25,
		BEGINTRACKA      = FIRST - 6,
		BEGINTRACKW      = FIRST - 26,
		ENDTRACKA        = FIRST - 7,
		ENDTRACKW        = FIRST - 27,
		TRACKA           = FIRST - 8,
		TRACKW           = FIRST - 28,
		GETDISPINFOA     = FIRST - 9,
		GETDISPINFOW     = FIRST - 29,
		BEGINDRAG        = FIRST - 10,
		ENDDRAG          = FIRST - 11,
		FILTERCHANGE     = FIRST - 12,
		FILTERBTNCLICK   = FIRST - 13,
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum LVM : int
	{
		FIRST                    = Base.LVM,
		GETBKCOLOR               = FIRST + 0,
		SETBKCOLOR               = FIRST + 1,
		GETIMAGELIST             = FIRST + 2,
		SETIMAGELIST             = FIRST + 3,
		GETITEMCOUNT             = FIRST + 4,
		GETITEMA                 = FIRST + 5,
		GETITEMW                 = FIRST + 75,
		SETITEMA                 = FIRST + 6,
		SETITEMW                 = FIRST + 76,
		INSERTITEMA              = FIRST + 7,
		INSERTITEMW              = FIRST + 77,
		DELETEITEM               = FIRST + 8,
		DELETEALLITEMS           = FIRST + 9,
		GETCALLBACKMASK          = FIRST + 10,
		SETCALLBACKMASK          = FIRST + 11,
		GETNEXTITEM              = FIRST + 12,
		FINDITEMA                = FIRST + 13,
		FINDITEMW                = FIRST + 83,
		GETITEMRECT              = FIRST + 14,
		SETITEMPOSITION          = FIRST + 15,
		GETITEMPOSITION          = FIRST + 16,
		GETSTRINGWIDTHA          = FIRST + 17,
		GETSTRINGWIDTHW          = FIRST + 87,
		HITTEST                  = FIRST + 18,
		ENSUREVISIBLE            = FIRST + 19,
		SCROLL                   = FIRST + 20,
		REDRAWITEMS              = FIRST + 21,
		ARRANGE                  = FIRST + 22,
		EDITLABELA               = FIRST + 23,
		EDITLABELW               = FIRST + 118,
		GETEDITCONTROL           = FIRST + 24,
		GETCOLUMNA               = FIRST + 25,
		GETCOLUMNW               = FIRST + 95,
		SETCOLUMNA               = FIRST + 26,
		SETCOLUMNW               = FIRST + 96,
		INSERTCOLUMNA            = FIRST + 27,
		INSERTCOLUMNW            = FIRST + 97,
		DELETECOLUMN             = FIRST + 28,
		GETCOLUMNWIDTH           = FIRST + 29,
		SETCOLUMNWIDTH           = FIRST + 30,
		GETHEADER                = FIRST + 31,
		CREATEDRAGIMAGE          = FIRST + 33,
		GETVIEWRECT              = FIRST + 34,
		GETTEXTCOLOR             = FIRST + 35,
		SETTEXTCOLOR             = FIRST + 36,
		GETTEXTBKCOLOR           = FIRST + 37,
		SETTEXTBKCOLOR           = FIRST + 38,
		GETTOPINDEX              = FIRST + 39,
		GETCOUNTPERPAGE          = FIRST + 40,
		GETORIGIN                = FIRST + 41,
		UPDATE                   = FIRST + 42,
		SETITEMSTATE             = FIRST + 43,
		GETITEMSTATE             = FIRST + 44,
		GETITEMTEXTA             = FIRST + 45,
		GETITEMTEXTW             = FIRST + 115,
		SETITEMTEXTA             = FIRST + 46,
		SETITEMTEXTW             = FIRST + 116,
		SETITEMCOUNT             = FIRST + 47,
		SORTITEMS                = FIRST + 48,
		SETITEMPOSITION32        = FIRST + 49,
		GETSELECTEDCOUNT         = FIRST + 50,
		GETITEMSPACING           = FIRST + 51,
		GETISEARCHSTRINGA        = FIRST + 52,
		GETISEARCHSTRINGW        = FIRST + 117,
		SETICONSPACING           = FIRST + 53,
		SETEXTENDEDLISTVIEWSTYLE = FIRST + 54,
		GETEXTENDEDLISTVIEWSTYLE = FIRST + 55,
		GETSUBITEMRECT           = FIRST + 56,
		SUBITEMHITTEST           = FIRST + 57,
		SETCOLUMNORDERARRAY      = FIRST + 58,
		GETCOLUMNORDERARRAY      = FIRST + 59,
		SETHOTITEM               = FIRST + 60,
		GETHOTITEM               = FIRST + 61,
		SETHOTCURSOR             = FIRST + 62,
		GETHOTCURSOR             = FIRST + 63,
		APPROXIMATEVIEWRECT      = FIRST + 64,
		SETWORKAREAS             = FIRST + 65,
		GETWORKAREAS             = FIRST + 70,
		GETNUMBEROFWORKAREAS     = FIRST + 73,
		GETSELECTIONMARK         = FIRST + 66,
		SETSELECTIONMARK         = FIRST + 67,
		SETHOVERTIME             = FIRST + 71,
		GETHOVERTIME             = FIRST + 72,
		SETTOOLTIPS              = FIRST + 74,
		GETTOOLTIPS              = FIRST + 78,
		SORTITEMSEX              = FIRST + 81,
		SETBKIMAGEA              = FIRST + 68,
		SETBKIMAGEW              = FIRST + 138,
		GETBKIMAGEA              = FIRST + 69,
		GETBKIMAGEW              = FIRST + 139,
		SETSELECTEDCOLUMN        = FIRST + 140,
		SETTILEWIDTH             = FIRST + 141,
		SETVIEW                  = FIRST + 142,
		GETVIEW                  = FIRST + 143,
		INSERTGROUP              = FIRST + 145,
		SETGROUPINFO             = FIRST + 147,
		GETGROUPINFO             = FIRST + 149,
		REMOVEGROUP              = FIRST + 150,
		MOVEGROUP                = FIRST + 151,
		MOVEITEMTOGROUP          = FIRST + 154,
		SETGROUPMETRICS          = FIRST + 155,
		GETGROUPMETRICS          = FIRST + 156,
		ENABLEGROUPVIEW          = FIRST + 157,
		SORTGROUPS               = FIRST + 158,
		INSERTGROUPSORTED        = FIRST + 159,
		REMOVEALLGROUPS          = FIRST + 160,
		HASGROUP                 = FIRST + 161,
		SETTILEVIEWINFO          = FIRST + 162,
		GETTILEVIEWINFO          = FIRST + 163,
		SETTILEINFO              = FIRST + 164,
		GETTILEINFO              = FIRST + 165,
		SETINSERTMARK            = FIRST + 166,
		GETINSERTMARK            = FIRST + 167,
		INSERTMARKHITTEST        = FIRST + 168,
		GETINSERTMARKRECT        = FIRST + 169,
		SETINSERTMARKCOLOR       = FIRST + 170,
		GETINSERTMARKCOLOR       = FIRST + 171,
		SETINFOTIP               = FIRST + 173,
		GETSELECTEDCOLUMN        = FIRST + 174,
		ISGROUPVIEWENABLED       = FIRST + 175,
		GETOUTLINECOLOR          = FIRST + 176,
		SETOUTLINECOLOR          = FIRST + 177,
		CANCELEDITLABEL          = FIRST + 179,
		MAPINDEXTOID             = FIRST + 180,
		MAPIDTOINDEX             = FIRST + 181,
	}




	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum HDF : int
	{
		LEFT            = 0x0000,
		RIGHT           = 0x0001,
		CENTER          = 0x0002,
		JUSTIFYMASK     = 0x0003,
		NOJUSTIFY       = 0xFFFC,
		RTLREADING      = 0x0004,
		SORTDOWN        = 0x0200,
		SORTUP          = 0x0400,
		SORTED          = 0x0600,
		NOSORT          = 0xF1FF,
		IMAGE           = 0x0800,
		BITMAP_ON_RIGHT = 0x1000,
		BITMAP          = 0x2000,
		STRING          = 0x4000,
		OWNERDRAW       = 0x8000
	}

	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum HDI : int
	{
		WIDTH      = 0x0001,
		HEIGHT     = WIDTH,
		TEXT       = 0x0002,
		FORMAT     = 0x0004,
		LPARAM     = 0x0008,
		BITMAP     = 0x0010,
		IMAGE      = 0x0020,
		DI_SETITEM = 0x0040,
		ORDER      = 0x0080,
		FILTER     = 0x0100
	}

	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum CDRF : int
	{
		DODEFAULT          = 0x0000,
		NEWFONT            = 0x0002,
		SKIPDEFAULT        = 0x0004,
		NOTIFYPOSTPAINT    = 0x0010,
		NOTIFYITEMDRAW     = 0x0020,
		NOTIFYSUBITEMDRAW  = 0x0020,
		NOTIFYPOSTERASE    = 0x0040
	}

	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum CDDS : int
	{
		PREPAINT         = 0x00000001,
		POSTPAINT        = 0x00000002,
		PREERASE         = 0x00000003,
		POSTERASE        = 0x00000004,
		ITEM             = 0x00010000,
		ITEMPREPAINT     = ITEM | PREPAINT,
		ITEMPOSTPAINT    = ITEM | POSTPAINT,
		ITEMPREERASE     = ITEM | PREERASE,
		ITEMPOSTERASE    = ITEM | POSTERASE,
		SUBITEM          = 0x00020000,
		SUBITEMPREPAINT  = SUBITEM | ITEMPREPAINT,
		SUBITEMPOSTPAINT = SUBITEM | ITEMPOSTPAINT,
		SUBITEMPREERASE  = SUBITEM | ITEMPREERASE,
		SUBITEMPOSTERASE = SUBITEM | ITEMPOSTERASE,
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum LVHT : int
	{
		NOWHERE          =  0x0001,
		ONITEMICON       =  0x0002,
		ONITEMLABEL      =  0x0004,
		ONITEMSTATEICON  =  0x0008,
		ONITEM           =  (ONITEMICON | ONITEMLABEL | ONITEMSTATEICON),
	}

	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	internal enum LVIR : int
	{
		BOUNDS         = 0,
		ICON           = 1,
		LABEL          = 2,
		SELECTBOUNDS   = 3,
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\Richedit.h'
	/// </summary>
	internal enum SCF : int
	{
		SELECTION		= 0x0001,
		WORD			= 0x0002,
		DEFAULT			= 0x0000,	// Set default charformat or paraformat
		ALL				= 0x0004,	// Not valid with SCF_SELECTION or SCF_WORD
		USEUIRULES		= 0x0008,	// Modifier for SCF_SELECTION; says that
									//  format came from a toolbar, etc., and
									//  hence UI formatting rules should be
									//  used instead of literal formatting
		ASSOCIATEFONT	= 0x0010,	// Associate fontname with bCharSet (one
									//  possible for each of Western, ME, FE,
									//  Thai)
		NOKBUPDATE		= 0x0020,	// Do not update KB layput for this change
									//  even if autokeyboard is on
		ASSOCIATEFONT2	= 0x0040,	// Associate plane-2 (surrogate) font
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\Richedit.h'
	/// </summary>
	internal enum CFM : uint
	{
		BOLD			= 0x00000001,
		ITALIC			= 0x00000002,
		UNDERLINE		= 0x00000004,
		STRIKEOUT		= 0x00000008,
		PROTECTED		= 0x00000010,
		LINK			= 0x00000020,		// Exchange hyperlink extension
		SIZE			= 0x80000000,
		COLOR			= 0x40000000,
		FACE			= 0x20000000,
		OFFSET			= 0x10000000,
		CHARSET			= 0x08000000,

		// CHARFORMAT effects
		//#define CFE_BOLD		0x0001
		//#define CFE_ITALIC	0x0002
		//#define CFE_UNDERLINE	0x0004
		//#define CFE_STRIKEOUT	0x0008
		//#define CFE_PROTECTED	0x0010
		//#define CFE_LINK		0x0020
		//#define CFE_AUTOCOLOR	0x40000000	// NOTE: this corresponds to
											// CFM_COLOR, which controls it
											// Masks and effects defined for CHARFORMAT2 -- an (*) indicates
											// that the data is stored by RichEdit 2.0/3.0, but not displayed

		SMALLCAPS		= 0x0040,			// (*)	
		ALLCAPS			= 0x0080,			// Displayed by 3.0	
		HIDDEN			= 0x0100,			// Hidden by 3.0
		OUTLINE			= 0x0200,			// (*)	
		SHADOW			= 0x0400,			// (*)	
		EMBOSS			= 0x0800,			// (*)	
		IMPRINT			= 0x1000,			// (*)	
		DISABLED		= 0x2000,
		REVISED			= 0x4000,
		//
		BACKCOLOR		= 0x04000000,
		LCID			= 0x02000000,
		UNDERLINETYPE	= 0x00800000,		// Many displayed by 3.0
		WEIGHT			= 0x00400000,	
		SPACING			= 0x00200000,  		// Displayed by 3.0	
		KERNING			= 0x00100000,  		// (*)	
		STYLE			= 0x00080000,  		// (*)	
		ANIMATION		= 0x00040000,  		// (*)	
		REVAUTHOR		= 0x00008000,

		CFE_SUBSCRIPT		= 0x00010000,	// Superscript and subscript are
		CFE_SUPERSCRIPT		= 0x00020000,	//  mutually exclusive			

		SUBSCRIPT		= CFE_SUBSCRIPT | CFE_SUPERSCRIPT,
		SUPERSCRIPT		= SUBSCRIPT,
		//
		//	CHARFORMAT "ALL" masks
		EFFECTS  = (BOLD | ITALIC | UNDERLINE | COLOR | STRIKEOUT | /* CFE_*/ PROTECTED | LINK),
		ALL      = (EFFECTS | SIZE | FACE | OFFSET | CHARSET),
		EFFECTS2 = (EFFECTS | DISABLED | SMALLCAPS | ALLCAPS | HIDDEN  | OUTLINE | SHADOW | EMBOSS | IMPRINT | DISABLED | REVISED | SUBSCRIPT | SUPERSCRIPT | BACKCOLOR),
		ALL2     = (ALL | EFFECTS2 | BACKCOLOR | LCID | UNDERLINETYPE | WEIGHT | REVAUTHOR | SPACING | KERNING | STYLE | ANIMATION),
	}

	#endregion

	#region structs

	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT
	{
		internal int x;
		internal int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RECT
	{
		internal int left;
		internal int top;
		internal int right;
		internal int bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct NMHDR
	{
		internal IntPtr hwndFrom;
		internal int    idFrom;
		internal int    code;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct NMHEADER
	{
		internal NMHDR  hdr;
		internal int    iItem;
		internal int    iButton;
		internal IntPtr pitem;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct HDITEM
	{
		internal HDI     mask;
		internal int     cxy;
		internal String  pszText;
		internal IntPtr  hbm;
		internal int     cchTextMax;
		internal HDF     fmt;
		internal int     lParam;
		internal int     iImage;
		internal int     iOrder;
		internal uint    type;
		internal IntPtr  pvFilter;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct NMCUSTOMDRAW
	{
		internal NMHDR  hdr;
		internal int    dwDrawStage;
		internal IntPtr hdc;
		internal RECT   rc;
		internal int    dwItemSpec;
		internal int    uItemState;
		internal IntPtr lItemlParam;
	}	

	[StructLayout(LayoutKind.Sequential)]
	internal struct NMLVCUSTOMDRAW
	{
		internal NMCUSTOMDRAW nmcd;
		internal int          clrText;
		internal int          clrTextBk;
		internal int          iSubItem;
		internal uint         dwItemType;
		internal int          clrFace;
		internal int          iIconEffect;
		internal int          iIconPhase;
		internal int          iPartId;
		internal int          iStateId;
		internal RECT         rcText;
		internal uint         uAlign;
	}

	/// <summary>
	/// from '.\PlatformSDK\Include\CommCtrl.h'
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct LVHITTESTINFO
	{
		internal POINT pt;
		internal LVHT flags;
		internal int iItem;
		internal int iSubItem;
	}


	/// <summary>
	/// from '.\PlatformSDK\Include\Richedit.h'
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=4, CharSet=CharSet.Auto)]
	internal struct CHARFORMAT2
	{
		private const int LF_FACESIZE = 32;       // Max size of a font name

		internal int cbSize;
		internal CFM dwMask;
		internal UInt32 dwEffects;
		internal UInt32 yHeight;
		internal UInt32 yOffset;
		internal UInt32 crTextColor;
		internal Byte   bCharSet;
		internal Byte   bPitchAndFamily;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=LF_FACESIZE)]
		internal String szFaceName;
		internal UInt16 wWeight;
		internal UInt16 sSpacing;
		internal int crBackColor;
		internal UInt32 lcid;
		internal UInt32 dwReserved;
		internal UInt16 sStyle;
		internal UInt16 wKerning;
		internal Byte bUnderlineType;
		internal Byte bAnimation;
		internal Byte bRevAuthor;
		internal Byte bReserved1;
	}

	/// <summary>
	/// CHARFORMAT2 parameterless constructor wrapper
	/// to autoinitialize the 'cbSize' field.
	/// use like:
	///    Win32.CHARFORMAT2 fmt=new Win32.CharFormat2();
	/// </summary>
	internal class CharFormat2
	{
		internal CharFormat2 ()
		{
			this.fmt=new CHARFORMAT2();
			this.fmt.cbSize = Marshal.SizeOf(fmt);
		}

		public static implicit operator CHARFORMAT2(CharFormat2 fmt)
		{
			return fmt.fmt;
		}

		internal CHARFORMAT2 fmt;
	}

	#endregion

	internal class User32
	{
		[DllImport("user32.dll")]
		internal static extern IntPtr GetDlgItem(IntPtr hDlg, int nControlID);


		#region SendMessage overloads

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, WM msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, HDM msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, HDM msg, int wParam, ref HDITEM hditem);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, LVM msg, int wParam, ref RECT rect);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, LVM msg, int wParam, ref LVHITTESTINFO hitTestInfo);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, HDM msg, int wParam, ref RECT rect);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, EM msg, SCF wParam, ref CHARFORMAT2 fmt);

		#endregion
	}
}