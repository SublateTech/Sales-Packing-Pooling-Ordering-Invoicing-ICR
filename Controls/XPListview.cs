using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization; 



//*************************************************************
//
//	Thanks to Michael Dobler for the idea on using standard 
//	Windows API calls to provide listview grouping support
//
//*************************************************************
namespace Signature.Classes
{
	public class XPListView : System.Windows.Forms.ListView 
	{
		private ColumnHeader _autoGroupCol = null;
		private ArrayList _autoGroupList = new ArrayList();
		private XPListViewItemCollection _items;
		private XPListViewGroupCollection _groups; 
		private bool _showInGroups = false;
		private bool _autoGroup = false;
		private string _emptyAutoGroupText = "";
		private IntPtr _apiRetVal;

		public XPListView() {
			_items = new XPListViewItemCollection(this);
			_groups = new XPListViewGroupCollection(this);
		}


		#region Designer Properties
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Description("the items collection of this view"),
		Editor(typeof(XPListViewItemCollectionEditor), typeof(System.Drawing.Design.UITypeEditor)),
		Category("Behavior")]
		public new XPListViewItemCollection Items{
			get{ return _items; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Description("collection of available groups (manually added)"), 
		Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor)), 
		Category("Grouping")]
		public XPListViewGroupCollection Groups{
			get{ return _groups; }
		}

		[Category("Grouping"), 
		Description("flag if the grouping view is active"), 
		DefaultValue(false)]
		public bool ShowInGroups{
			get{ return _showInGroups; }
			set{
				if(_showInGroups != value){
					_showInGroups = value;
					if( _autoGroup && value == false ){
						_autoGroup = false;
						_autoGroupCol = null;
						_autoGroupList.Clear();
					}
		
					int param = 0;
					int wParam = System.Convert.ToInt32(value);
					ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_ENABLEGROUPVIEW, wParam, ref param);
				}
			}
		}

		[Category("Grouping"),
		Description("flag if the autogroup mode is active"),
		DefaultValue(false)]
		public bool AutoGroupMode{
			get{ return _autoGroup; }
			set{
				_autoGroup = value;
				if(_autoGroupCol != null){
					AutoGroupByColumn(_autoGroupCol.Index);
				}
			}
		}
		[Category("Grouping"), 
		Description("column by with values the listiew is automatically grouped"), 
		DefaultValue(typeof(ColumnHeader), ""), 
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public ColumnHeader AutoGroupColumn{
			get{ return _autoGroupCol; }
			set{
				_autoGroupCol = value;

				if( _autoGroupCol != null){
					AutoGroupByColumn(_autoGroupCol.Index);
				}
			}
		}
		[Category("Grouping"), 
		Description("the text that is displayed instead of an empty auto group text"), 
		DefaultValue("")]
		public string EmptyAutoGroupText{
			get{ return _emptyAutoGroupText; }
			set{
				_emptyAutoGroupText = value;

				if ( _autoGroupCol != null){
					AutoGroupByColumn(_autoGroupCol.Index);
				}
			}
		}

		[Browsable(false), 
		Description("readonly array of all automatically created groups"), 
		Category("Grouping")]
		public Array Autogroups{
			get{ return _autoGroupList.ToArray(typeof(String)); }
		}
		#endregion

		public void ShowTiles(int[] columns){
			ListViewAPI.LVTILEVIEWINFO apiTileView;
			ListViewAPI.LVTILEINFO apiTile;

			IntPtr lpcol = Marshal.AllocHGlobal(columns.Length * 4);
			Marshal.Copy(columns, 0, lpcol, columns.Length);

			int param = 0;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETVIEW, ListViewAPI.LV_VIEW_TILE, ref param);

			apiTileView = new ListViewAPI.LVTILEVIEWINFO();
			apiTileView.cbSize = Marshal.SizeOf(typeof(ListViewAPI.LVTILEVIEWINFO));
			apiTileView.dwMask = ListViewAPI.LVTVIM_COLUMNS | ListViewAPI.LVTVIM_TILESIZE;
			apiTileView.dwFlags = ListViewAPI.LVTVIF_AUTOSIZE;
			apiTileView.cLines = columns.Length;

			
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETTILEVIEWINFO, 0, ref apiTileView);

			foreach(XPListViewItem itm in this.Items){
				apiTile = new ListViewAPI.LVTILEINFO();
				apiTile.cbSize = Marshal.SizeOf(typeof(ListViewAPI.LVTILEINFO));
				apiTile.iItem = itm.Index;
				apiTile.cColumns = columns.Length;
				apiTile.puColumns = (int)lpcol;
					
				_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETTILEINFO, 0, ref apiTile);
			}

			//columns = null;
			Marshal.FreeHGlobal(lpcol);
		}


		public void SetTileSize(Size size){
			ListViewAPI.LVTILEVIEWINFO apiTileView; 
			ListViewAPI.INTEROP_SIZE apiSize;

			this.SuspendLayout();

			int param = 0;
			_apiRetVal = ListViewAPI.SendMessage((System.IntPtr)this.Handle, ListViewAPI.LVM_GETVIEW, ListViewAPI.LV_VIEW_TILE, ref param);
			if((int)_apiRetVal != ListViewAPI.LV_VIEW_TILE){
				return;
			}

			apiSize = new ListViewAPI.INTEROP_SIZE();
			apiSize.cx = size.Width;
			apiSize.cy = size.Height;

			apiTileView = new ListViewAPI.LVTILEVIEWINFO();
			apiTileView.cbSize = Marshal.SizeOf(typeof(ListViewAPI.LVTILEVIEWINFO));
			apiTileView.dwMask = ListViewAPI.LVTVIM_TILESIZE | ListViewAPI.LVTVIM_LABELMARGIN;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_GETTILEVIEWINFO, 0, ref apiTileView);
			apiTileView.dwFlags = ListViewAPI.LVTVIF_FIXEDSIZE;
			apiTileView.sizeTile = apiSize;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETTILEVIEWINFO, 0, ref apiTileView);

			this.ResumeLayout();
		}


		public void SetTileWidth(int width ){
			ListViewAPI.LVTILEVIEWINFO apiTileView;

			this.SuspendLayout();

			int param = 0;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_GETVIEW, ListViewAPI.LV_VIEW_TILE, ref param);
			if( (int)_apiRetVal != ListViewAPI.LV_VIEW_TILE){
				return;
			}

			apiTileView = new ListViewAPI.LVTILEVIEWINFO();
			apiTileView.cbSize = Marshal.SizeOf(typeof(ListViewAPI.LVTILEVIEWINFO));
			apiTileView.dwMask = ListViewAPI.LVTVIM_TILESIZE | ListViewAPI.LVTVIM_LABELMARGIN;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_GETTILEVIEWINFO, 0, ref apiTileView);
			apiTileView.dwFlags = ListViewAPI.LVTVIF_FIXEDWIDTH;
			apiTileView.sizeTile.cx = width;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETTILEVIEWINFO, 0, ref apiTileView);

			this.ResumeLayout();
		}


		public void SetTileHeight(int height){
			ListViewAPI.LVTILEVIEWINFO apiTileView; 

			this.SuspendLayout();

			int param = 0;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_GETVIEW, ListViewAPI.LV_VIEW_TILE, ref param);
			if((int)_apiRetVal != ListViewAPI.LV_VIEW_TILE){
				return;
			}


			apiTileView = new ListViewAPI.LVTILEVIEWINFO();

			apiTileView.cbSize = Marshal.SizeOf(typeof(ListViewAPI.LVTILEVIEWINFO));
			apiTileView.dwMask = ListViewAPI.LVTVIM_TILESIZE | ListViewAPI.LVTVIM_LABELMARGIN;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_GETTILEVIEWINFO, 0, ref apiTileView);
			apiTileView.dwFlags = ListViewAPI.LVTVIF_FIXEDHEIGHT;
			apiTileView.sizeTile.cy = height;
			_apiRetVal = ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_SETTILEVIEWINFO, 0, ref apiTileView);


			this.ResumeLayout();
		}


		public bool AutoGroupByColumn(int columnID){
			if( columnID >= this.Columns.Count || columnID < 0 ){ return false; }

			try{
				_autoGroupList.Clear();
				foreach(XPListViewItem itm in this.Items){
					if ( !_autoGroupList.Contains(itm.SubItems[columnID].Text == "" ? _emptyAutoGroupText : itm.SubItems[columnID].Text)) {
	
						_autoGroupList.Add(itm.SubItems[columnID].Text == "" ? EmptyAutoGroupText : itm.SubItems[columnID].Text);
					}
				}

				_autoGroupList.Sort();

				ListViewAPI.ClearListViewGroup(this);
				foreach(string text in _autoGroupList){
					ListViewAPI.AddListViewGroup(this, text, _autoGroupList.IndexOf(text));
				}

				foreach(XPListViewItem itm in this.Items){
					ListViewAPI.AddItemToGroup(this, itm.Index, _autoGroupList.IndexOf(itm.SubItems[columnID].Text == "" ? _emptyAutoGroupText : itm.SubItems[columnID].Text));
				}

				int param = 0;
				ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_ENABLEGROUPVIEW, 1, ref param);
				_showInGroups = true;
				_autoGroup = true;
				_autoGroupCol = this.Columns[columnID];

				this.Refresh();

				return true;
			}
			catch(Exception ex){
				throw new SystemException("Error in XPListView.AutoGroupByColumn: " + ex.Message);
			}
		}


		public bool Regroup(){
			try{
				ListViewAPI.ClearListViewGroup(this);
				foreach(XPListViewGroup grp in this.Groups){
					ListViewAPI.AddListViewGroup(this, grp.GroupText, grp.GroupIndex);
				}

				foreach(XPListViewItem itm in this.Items){
					ListViewAPI.AddItemToGroup(this, itm.Index, itm.GroupIndex);
				}

				int param = 0;
				ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_ENABLEGROUPVIEW, 1, ref param);
				_showInGroups = true;
				_autoGroup = false;
				_autoGroupCol = null;
				_autoGroupList.Clear();

				return true;
			}
			catch(Exception ex){
				throw new SystemException("Error in XPListView.Regroup: " + ex.Message);
			}
		}


		public void RedrawItems(){
			ListViewAPI.RedrawItems(this, true);
			this.ArrangeIcons();
		}

		
		public void UpdateItems(){
			ListViewAPI.UpdateItems(this);
		}

					
		public void SetColumnStyle(int column, Font font, Color foreColor, Color backColor){
			this.SuspendLayout();

			foreach(XPListViewItem itm in this.Items){
				if( itm.SubItems.Count > column){
					itm.SubItems[column].Font = font;
					itm.SubItems[column].BackColor = backColor;
					itm.SubItems[column].ForeColor = foreColor;					
				}
			}

			this.ResumeLayout();
		}


		public void SetColumnStyle(int column, Font font,Color foreColor){
			SetColumnStyle(column, font, foreColor, this.BackColor);
		}


		public void SetColumnStyle(int column, Font font){
			SetColumnStyle(column, font, this.ForeColor, this.BackColor);
		}


		public void ResetColumnStyle(int column){
			this.SuspendLayout();

			foreach(XPListViewItem itm in this.Items){
				if( itm.SubItems.Count > column){
					itm.SubItems[column].ResetStyle();
				}
			}

			this.ResumeLayout();
		}


		public void SetBackgroundImage(string ImagePath, ImagePosition Position){
			ListViewAPI.SetListViewImage(this, ImagePath, Position);
		}

		
		private void _items_ItemAdded(object sender, ListViewItemEventArgs e) { 
			string text; 
			if (_autoGroup) { 
				text = e.Item.SubItems[_autoGroupCol.Index].Text; 
				if (!_autoGroupList.Contains(text)) { 
					_autoGroupList.Add(text); 
					ListViewAPI.AddListViewGroup(this, text, _autoGroupList.IndexOf(text)); 
				} 
				ListViewAPI.AddItemToGroup(this, e.Item.Index, _autoGroupList.IndexOf(text)); 
			} 
		}


		protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e) { 
			base.OnColumnClick(e); 
			this.SuspendLayout(); 
			if (_showInGroups) { 
				int param = 0;
				ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_ENABLEGROUPVIEW, 0, ref param); 
			} 
			this.ListViewItemSorter = new XPListViewItemComparer(e.Column); 
			if (this.Sorting == SortOrder.Descending) { 
				this.Sorting = SortOrder.Ascending; 
			} else { 
				this.Sorting = SortOrder.Descending; 
			} 
			this.Sort(); 
			if (_showInGroups) { 
				int param = 0;
				ListViewAPI.SendMessage(this.Handle, ListViewAPI.LVM_ENABLEGROUPVIEW, 1, ref param); 
				if (_autoGroup == true) { 
					AutoGroupByColumn(_autoGroupCol.Index); 
				} else { 
					Regroup(); 
				} 
			} 
			this.ResumeLayout(); 
		}
	}


	/// <summary>
	/// Only basic support for sorting in this sample - would need to be updated for asc/desc support
	/// </summary>
	public class XPListViewItemComparer : IComparer { 
		private int col; 

		public XPListViewItemComparer() { 
			col = 0; 
		} 

		public XPListViewItemComparer(int column) { 
			col = column; 
		} 

		public int Compare(object x, object y) { 
			return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text); 
		} 
	}
    [TypeConverter(typeof(XPListViewGroupConverter))]
    public class XPListViewGroup
    {
        private string _text;
        private int _index;

        public XPListViewGroup()
        {
        }

        public XPListViewGroup(string text, int index)
        {
            _text = text;
            _index = index;
        }

        public XPListViewGroup(string text)
        {
            _text = text;
        }

        public string GroupText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public int GroupIndex
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        public override string ToString()
        {
            return _text;
        }
    }

    //ListViewApi
    public enum ImagePosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        CenterRight,
        AbsoluteMiddle,
        BottomLeft,
        BottomCenter,
        BottomRight,
    }


    public class ListViewAPI
    {
        #region Constants for Listview-Messages
        public const int LVM_FIRST = 4096;
        public const int HDM_SETIMAGELIST = 4616;
        public const int LVM_ARRANGE = (LVM_FIRST + 22);
        public const int LVM_DELETEALLITEMS = (LVM_FIRST + 9);
        public const int LVM_DELETECOLUMN = (LVM_FIRST + 28);
        public const int LVM_DELETEITEM = (LVM_FIRST + 8);
        public const int LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157);
        public const int LVM_GETCOLUMN = (LVM_FIRST + 25);
        public const int LVM_GETCOLUMNW = (LVM_FIRST + 95);
        public const int LVM_GETGROUPINFO = (LVM_FIRST + 149);
        public const int LVM_GETGROUPMETRICS = (LVM_FIRST + 156);
        public const int LVM_GETHEADER = (LVM_FIRST + 31);
        public const int LVM_GETITEM = (LVM_FIRST + 5);
        public const int LVM_GETTILEINFO = (LVM_FIRST + 165);
        public const int LVM_GETTILEVIEWINFO = (LVM_FIRST + 163);
        public const int LVM_GETTOOLTIPS = (LVM_FIRST + 78);
        public const int LVM_GETVIEW = (LVM_FIRST + 143);
        public const int LVM_HASGROUP = (LVM_FIRST + 161);
        public const int LVM_INSERTCOLUMN = (LVM_FIRST + 27);
        public const int LVM_INSERTGROUP = (LVM_FIRST + 145);
        public const int LVM_INSERTGROUPSORTED = (LVM_FIRST + 159);
        public const int LVM_INSERTITEM = (LVM_FIRST + 7);
        public const int LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175);
        public const int LVM_MOVEGROUP = (LVM_FIRST + 151);
        public const int LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154);
        public const int LVM_REDRAWITEMS = (LVM_FIRST + 21);
        public const int LVM_REMOVEALLGROUPS = (LVM_FIRST + 160);
        public const int LVM_REMOVEGROUP = (LVM_FIRST + 150);
        public const int LVM_SETCOLUMN = (LVM_FIRST + 26);
        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54);
        public const int LVM_SETGROUPINFO = (LVM_FIRST + 147);
        public const int LVM_SETGROUPMETRICS = (LVM_FIRST + 155);
        public const int LVM_SETINFOTIP = (LVM_FIRST + 173);
        public const int LVM_SETITEM = (LVM_FIRST + 6);
        public const int LVM_SETTILEINFO = (LVM_FIRST + 164);
        public const int LVM_SETTILEVIEWINFO = (LVM_FIRST + 162);
        public const int LVM_SETTILEWIDTH = (LVM_FIRST + 141);
        public const int LVM_SETTOOLTIPS = (LVM_FIRST + 74);
        public const int LVM_SETVIEW = (LVM_FIRST + 142);
        public const int LVM_SORTGROUPS = (LVM_FIRST + 158);
        public const int LVM_SORTITEMS = (LVM_FIRST + 48);
        public const int LVM_UPDATE = (LVM_FIRST + 42);
        public const int LVBKIF_STYLE_NORMAL = 0;
        public const int LVBKIF_SOURCE_URL = 2;
        public const int LVBKIF_STYLE_TILE = 16;
        public const int LVBKIF_FLAG_TILEOFFSET = 0x00000100;
        public const int LVM_SETBKIMAGE = (LVM_FIRST + 68);
        public const int LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38);
        public const int CLR_NONE = -1;
        #endregion

        #region Constants for LVCOLUMN.mask
        public const int LVCF_FMT = 1;
        public const int LVCF_IMAGE = 16;
        public const int LVCF_ORDER = 23;
        public const int LVCF_SUBITEM = 8;
        public const int LVCF_TEXT = 4;
        public const int LVCF_WIDTH = 2;
        #endregion

        #region Constants for LVCOLUMN.fmt
        public const int LVCFMT_BITMAP_ON_RIGHT = 4096;
        public const int LVCFMT_CENTER = 2;
        public const int LVCFMT_COL_HAS_IMAGES = 32768;
        public const int LVCFMT_IMAGE = 2048;
        public const int LVCFMT_JUSTIFYMASK = 3;
        public const int LVCFMT_LEFT = 0;
        public const int LVCFMT_RIGHT = 1;
        #endregion

        #region Constants for LVGROUP.mask
        public const int LVGF_ALIGN = 8;
        public const int LVGF_FOOTER = 2;
        public const int LVGF_GROUPID = 16;
        public const int LVGF_HEADER = 1;
        public const int LVGF_NONE = 0;
        public const int LVGF_STATE = 4;
        #endregion

        #region Constants for LVGROUP.uAlign
        public const int LVGA_FOOTER_CENTER = 16;
        public const int LVGA_FOOTER_LEFT = 8;
        public const int LVGA_FOOTER_RIGHT = 23;
        public const int LVGA_HEADER_CENTER = 2;
        public const int LVGA_HEADER_LEFT = 1;
        public const int LVGA_HEADER_RIGHT = 4;
        #endregion

        #region Constants for LVGROUP.state
        public const int LVGS_COLLAPSED = 1;
        public const int LVGS_HIDDEN = 2;
        public const int LVGS_NORMAL = 0;
        #endregion

        #region Constants for LVTILEVIEWINFO.dwMask
        public const int LVTVIM_COLUMNS = 2;
        public const int LVTVIM_TILESIZE = 1;
        public const int LVTVIM_LABELMARGIN = 4;
        #endregion

        #region Constants for LVTILEVIEWINFO.dwFlags
        public const int LVTVIF_AUTOSIZE = 0;
        public const int LVTVIF_FIXEDHEIGHT = 2;
        public const int LVTVIF_FIXEDSIZE = 3;
        public const int LVTVIF_FIXEDWIDTH = 1;
        #endregion

        #region Constants for LVM_SETVIEW Message
        public const int LV_VIEW_DETAILS = 1;
        public const int LV_VIEW_ICON = 0;
        public const int LV_VIEW_LIST = 3;
        public const int LV_VIEW_MAX = 4;
        public const int LV_VIEW_SMALLICON = 2;
        public const int LV_VIEW_TILE = 4;
        #endregion

        #region Constants for LVITEM.mask
        public const int LVIF_COLUMNS = 512;
        public const int LVIF_DI_SETITEM = 4096;
        public const int LVIF_GROUPID = 256;
        public const int LVIF_IMAGE = 2;
        public const int LVIF_INDENT = 16;
        public const int LVIF_NORECOMPUTE = 2048;
        public const int LVIF_PARAM = 4;
        public const int LVIF_STATE = 8;
        public const int LVIF_TEXT = 1;
        #endregion

        #region Structs for Interop
        public struct INTEROP_SIZE
        {
            public int cx;
            public int cy;
        }

        public struct INTEROP_RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion

        #region Structs for ListView API
        [StructLayout(LayoutKind.Sequential)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public int lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public int puColumns;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LVCOLUMN
        {
            public int mask;
            public int fmt;
            public int cx;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LVGROUP
        {
            public int cbSize;
            public int mask;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszHeader;
            public int cchHeader;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszFooter;
            public int cchFooter;
            public int iGroupId;
            public int stateMask;
            public int state;
            public int uAlign;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LVTILEVIEWINFO
        {
            public int cbSize;
            public int dwMask;
            public int dwFlags;
            public INTEROP_SIZE sizeTile;
            public int cLines;
            public INTEROP_SIZE rcLabelMargin;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LVTILEINFO
        {
            public int cbSize;
            public int iItem;
            public int cColumns;
            public int puColumns;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LVBKIMAGE
        {
            public int ulFlags;
            public int hbm;			// Not used according to MSDN
            public string pszImage;
            public int cchImageMax;
            public int xOffsetPercent;
            public int yOffsetPercent;
        }
        #endregion

        #region Overloaded SendMessage Methods
        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref int lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVCOLUMN lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVTILEINFO lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVTILEVIEWINFO lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVGROUP lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVBKIMAGE lParam);
        #endregion

        #region Static Methods
        public static int AddItemToGroup(XPListView lst, int index, int groupID)
        {
            LVITEM apiItem;
            int ptrRetVal;

            try
            {
                if (lst == null) { return 0; }

                apiItem = new LVITEM();
                apiItem.mask = LVIF_GROUPID;
                apiItem.iItem = index;
                apiItem.iGroupId = groupID;

                ptrRetVal = (int)SendMessage(lst.Handle, ListViewAPI.LVM_SETITEM, 0, ref apiItem);

                return ptrRetVal;
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.AddItemToGroup occured: " + ex.Message);
            }
        }


        public static int AddListViewGroup(XPListView lst, string text, int index)
        {
            LVGROUP apiGroup;
            int ptrRetVal;

            try
            {
                if (lst == null) { return -1; }

                apiGroup = new LVGROUP();
                apiGroup.mask = LVGF_GROUPID | LVGF_HEADER | LVGF_STATE;
                apiGroup.pszHeader = text;
                apiGroup.cchHeader = apiGroup.pszHeader.Length;
                apiGroup.iGroupId = index;
                apiGroup.stateMask = LVGS_NORMAL;
                apiGroup.state = LVGS_NORMAL;
                apiGroup.cbSize = Marshal.SizeOf(typeof(LVGROUP));

                ptrRetVal = (int)SendMessage(lst.Handle, ListViewAPI.LVM_INSERTGROUP, -1, ref apiGroup);
                return ptrRetVal;
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.AddListViewGroup occured: " + ex.Message);
            }

        }


        public static int RemoveListViewGroup(XPListView lst, int index)
        {
            int ptrRetVal;

            try
            {
                if (lst != null) { return -1; }

                int param = 0;
                ptrRetVal = (int)SendMessage(lst.Handle, LVM_REMOVEGROUP, index, ref param);

                return ptrRetVal;
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.RemoveListViewGroup occured: " + ex.Message);
            }
        }


        public static void ClearListViewGroup(XPListView lst)
        {
            int ptrRetVal;

            try
            {
                if (lst == null) { return; }

                int param = 0;
                ptrRetVal = (int)SendMessage(lst.Handle, LVM_REMOVEALLGROUPS, 0, ref param);
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.ClearListViewGroup occured: " + ex.Message);
            }
        }


        public static void RedrawItems(XPListView lst, bool update)
        {
            int ptrRetVal;

            try
            {
                if (lst != null) { return; }

                int param = lst.Items.Count - 1;
                ptrRetVal = (int)SendMessage(lst.Handle, LVM_REDRAWITEMS, 0, ref param);

                if (update) { UpdateItems(lst); }

                lst.Refresh();
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.RedrawItems occured: " + ex.Message);
            }
        }


        public static void UpdateItems(XPListView lst)
        {
            int ptrRetVal;

            try
            {
                if (lst != null) { return; }

                for (int i = 0; i < lst.Items.Count - 1; i++)
                {
                    int param = 0;
                    ptrRetVal = (int)SendMessage(lst.Handle, LVM_UPDATE, i, ref param);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.UpdateItems occured: " + ex.Message);
            }
        }


        public static void SetListViewImage(XPListView lst, string ImagePath, ImagePosition Position)
        {
            int x = 0;
            int y = 0;

            GetImageLocation(Position, ref x, ref y);

            try
            {
                LVBKIMAGE apiItem = new LVBKIMAGE();
                apiItem.pszImage = ImagePath + Convert.ToChar(0);
                apiItem.cchImageMax = ImagePath.Length;
                apiItem.ulFlags = LVBKIF_SOURCE_URL | LVBKIF_STYLE_NORMAL;
                apiItem.xOffsetPercent = x;
                apiItem.yOffsetPercent = y;

                // Set the background colour of the ListView to 0XFFFFFFFF (-1) so it will be transparent
                int clear = CLR_NONE;
                SendMessage(lst.Handle, LVM_SETTEXTBKCOLOR, 0, ref clear);

                SendMessage(lst.Handle, LVM_SETBKIMAGE, 0, ref apiItem);
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.SetListViewImage occured: " + ex.Message);
            }

        }

        public static void SetListViewImage(XPListView lst, string ImagePath, int XTileOffsetPercent, int YTileOffsetPercent)
        {
            try
            {
                LVBKIMAGE apiItem = new LVBKIMAGE();
                apiItem.pszImage = ImagePath + Convert.ToChar(0);
                apiItem.cchImageMax = ImagePath.Length;
                apiItem.ulFlags = LVBKIF_SOURCE_URL | LVBKIF_STYLE_TILE;
                apiItem.xOffsetPercent = XTileOffsetPercent;
                apiItem.yOffsetPercent = YTileOffsetPercent;

                // Set the background colour of the ListView to 0XFFFFFFFF (-1) so it will be transparent
                int clear = CLR_NONE;
                SendMessage(lst.Handle, LVM_SETTEXTBKCOLOR, 0, ref clear);

                SendMessage(lst.Handle, LVM_SETBKIMAGE, 0, ref apiItem);
            }
            catch (Exception ex)
            {
                throw new System.Exception("An exception in ListViewAPI.SetListViewImage occured: " + ex.Message);
            }

        }


        private static void GetImageLocation(ImagePosition Position, ref int XOffset, ref int YOffset)
        {
            switch (Position)
            {
                case ImagePosition.TopLeft:
                    XOffset = YOffset = 0;
                    break;
                case ImagePosition.TopCenter:
                    XOffset = 50;
                    YOffset = 0;
                    break;
                case ImagePosition.TopRight:
                    XOffset = 100;
                    YOffset = 0;
                    break;
                case ImagePosition.CenterLeft:
                    XOffset = 0;
                    YOffset = 50;
                    break;
                case ImagePosition.CenterRight:
                    XOffset = 100;
                    YOffset = 50;
                    break;
                case ImagePosition.AbsoluteMiddle:
                    XOffset = YOffset = 50;
                    break;
                case ImagePosition.BottomLeft:
                    XOffset = 0;
                    YOffset = 100;
                    break;
                case ImagePosition.BottomCenter:
                    XOffset = 50;
                    YOffset = 100;
                    break;
                case ImagePosition.BottomRight:
                    XOffset = 100;
                    YOffset = 100;
                    break;
            }
        }
        #endregion
    }

    #region Disigner
    internal class XPListViewItemCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {

        public XPListViewItemCollectionEditor()
            : base(typeof(XPListViewItemCollection))
        {
        }

        protected override object CreateInstance(System.Type itemType)
        {
            return new XPListViewItem();
        }

        protected override System.Type CreateCollectionItemType()
        {
            return typeof(XPListViewItem);
        }
    }
    internal class XPListViewItemConverter : ExpandableObjectConverter
    {

        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                Type[] signature = { typeof(XPListViewItem.ListViewSubItem[]), typeof(int), typeof(int) };
                XPListViewItem itm = ((XPListViewItem)value);
                object[] args = { itm.SubItemsArray, itm.ImageIndex, itm.GroupIndex };
                return new InstanceDescriptor(typeof(XPListViewItem).GetConstructor(signature), args, false);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    internal class XPListViewGroupConverter : ExpandableObjectConverter
    {

        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                Type[] signature = { typeof(string), typeof(int) };
                XPListViewGroup itm = ((XPListViewGroup)value);
                object[] args = { itm.GroupText, itm.GroupIndex };
                return new InstanceDescriptor(typeof(XPListViewGroup).GetConstructor(signature), args, false);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion

    
    public class XPListViewGroupCollection : System.Collections.CollectionBase
    {
        public delegate void GroupAddedEventHandler(object sender, ListViewGroupEventArgs e);
        public delegate void GroupRemovedEventHandler(object sender, ListViewGroupEventArgs e);
        public event GroupAddedEventHandler GroupAdded;
        public event GroupRemovedEventHandler GroupRemoved;
        private XPListView _owner;

        public XPListViewGroup this[int index]
        {
            get
            {
                return ((XPListViewGroup)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public XPListViewGroupCollection(XPListView owner)
        {
            _owner = owner;
        }

        public int Add(XPListViewGroup value)
        {
            ListViewAPI.AddListViewGroup(_owner, value.GroupText, value.GroupIndex);
            if (GroupAdded != null)
            {
                GroupAdded(this, new ListViewGroupEventArgs(value));
            }
            return List.Add(value);
        }

        public int Add(string text, int index)
        {
            XPListViewGroup itm = new XPListViewGroup(text, index);
            ListViewAPI.AddListViewGroup(_owner, text, index);
            if (GroupAdded != null)
            {
                GroupAdded(this, new ListViewGroupEventArgs(itm));
            }
            return List.Add(itm);
        }

        public int IndexOf(XPListViewGroup value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, XPListViewGroup value)
        {
            List.Insert(index, value);
        }

        public void Remove(XPListViewGroup value)
        {
            ListViewAPI.RemoveListViewGroup(_owner, value.GroupIndex);
            if (GroupRemoved != null)
            {
                GroupRemoved(this, new ListViewGroupEventArgs(value));
            }
            List.Remove(value);
        }

        public bool Contains(XPListViewGroup value)
        {
            return List.Contains(value);
        }

        public new void Clear()
        {
            ListViewAPI.ClearListViewGroup(_owner);
            List.Clear();
        }

        public void CopyTo(XPListViewGroup[] array, int index)
        {
            List.CopyTo(array, index);
        }
    }
    public class ListViewGroupEventArgs : EventArgs
    {

        public ListViewGroupEventArgs(XPListViewGroup item)
        {
            mItem = item;
        }

        public XPListViewGroup Item
        {
            get
            {
                return mItem;
            }
            set
            {
                mItem = value;
            }
        }
        private XPListViewGroup mItem;
    }
 
    [TypeConverter(typeof(XPListViewItemConverter))]
    public class XPListViewItem : System.Windows.Forms.ListViewItem
    {
        private int _groupIndex;

        public XPListViewItem()
            : base()
        {
        }

        public XPListViewItem(string text)
            : base(text)
        {

        }

        public XPListViewItem(string text, int imageIndex)
            : base(text, imageIndex)
        {
        }

        public XPListViewItem(string[] items)
            : base(items)
        {
        }

        public XPListViewItem(string[] items, int imageIndex)
            : base(items, imageIndex)
        {
        }

        public XPListViewItem(XPListViewItem.ListViewSubItem[] subItems, int imageIndex)
            : base(subItems, imageIndex)
        {
        }

        public XPListViewItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font)
            : base(items, imageIndex, foreColor, backColor, font)
        {
        }

        public XPListViewItem(string text, int imageIndex, int groupIndex)
            : base(text, imageIndex)
        {
            _groupIndex = groupIndex;
        }

        public XPListViewItem(string[] items, int imageIndex, int groupIndex)
            : base(items, imageIndex)
        {
            this.GroupIndex = groupIndex;
        }

        public XPListViewItem(XPListViewItem.ListViewSubItem[] subItems, int imageIndex, int groupIndex)
            : base(subItems, imageIndex)
        {
            this.GroupIndex = groupIndex;
        }

        public XPListViewItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font, int groupIndex)
            : base(items, imageIndex, foreColor, backColor, font)
        {
            this.GroupIndex = groupIndex;
        }

        [Browsable(true), Category("Info")]
        public int GroupIndex
        {
            get
            {
                return _groupIndex;
            }
            set
            {
                _groupIndex = value;
                ListViewAPI.AddItemToGroup(((XPListView)base.ListView), base.Index, _groupIndex);
            }
        }

        [Browsable(false)]
        internal string[] SubItemsArray
        {
            get
            {
                if (this.SubItems.Count == 0)
                {
                    return null;
                }

                string[] a = new string[this.SubItems.Count - 1];

                for (int i = 0; i <= this.SubItems.Count - 1; i++)
                {
                    a[i] = this.SubItems[i].Text;
                }
                return a;
            }
        }
    }

    public class XPListViewItemCollection : System.Windows.Forms.ListView.ListViewItemCollection
    {

        public delegate void ItemAddedEventHandler(object sender, ListViewItemEventArgs e);
        public delegate void ItemRemovedEventHandler(object sender, ListViewItemEventArgs e);
        public event ItemAddedEventHandler ItemAdded;
        public event ItemRemovedEventHandler ItemRemoved;

        public XPListViewItemCollection(XPListView owner)
            : base(((ListView)owner))
        {
        }

        public XPListViewItem Add(XPListViewItem item)
        {
            XPListViewItem itm;
            itm = ((XPListViewItem)base.Add(item));
            ListViewAPI.AddItemToGroup(((XPListView)itm.ListView), itm.Index, itm.GroupIndex);
            if (ItemAdded != null)
            {
                ItemAdded(this, new ListViewItemEventArgs(itm));
            }
            return itm;
        }

        public new XPListViewItem Add(string text)
        {
            XPListViewItem itm = new XPListViewItem(text);
            return Add(itm);
        }

        public XPListViewItem Add(string text, int imageIndex, int groupindex)
        {
            XPListViewItem itm = new XPListViewItem(text, imageIndex, groupindex);
            return Add(itm);
        }

        public void AddRange(XPListViewItem[] values)
        {
            base.AddRange(values);
            foreach (XPListViewItem itm in values)
            {
                ListViewAPI.AddItemToGroup(((XPListView)itm.ListView), itm.Index, itm.GroupIndex);
                if (ItemAdded != null)
                {
                    ItemAdded(this, new ListViewItemEventArgs(itm));
                }
            }
        }

        public bool Contains(XPListViewItem item)
        {
            return base.Contains(item);
        }

        public int IndexOf(XPListViewItem item)
        {
            return base.IndexOf(item);
        }

        public XPListViewItem Insert(int index, XPListViewItem item)
        {
            return ((XPListViewItem)base.Insert(index, item));
        }

        public XPListViewItem this[int displayIndex]
        {
            get
            {
                return ((XPListViewItem)this[displayIndex]);  //((XPListViewItem)this[displayIndex])
            }
            set
            {
                this[displayIndex] = value;
            }
        }

        public void Remove(XPListViewItem item)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, new ListViewItemEventArgs(item));
            }
            base.Remove(item);
        }

        public void CopyTo(XPListViewItem[] array, int index)
        {
            base.CopyTo(array, index);
        }
    }
    public class ListViewItemEventArgs : EventArgs
    {
        private XPListViewItem mItem = new XPListViewItem();

        public ListViewItemEventArgs(XPListViewItem item)
        {
            mItem = item;
        }

        public XPListViewItem Item
        {
            get
            {
                return mItem;
            }
            set
            {
                mItem = value;
            }
        }
    } 


}
