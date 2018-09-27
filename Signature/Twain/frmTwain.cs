using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Signature.TwainGui;
using Signature.Classes;
using TwainLib;
using GdiPlusLib;

namespace Signature.TwainGui
{
public class frmTwain : System.Windows.Forms.Form, IMessageFilter
{
	private System.Windows.Forms.MenuItem menuMainFile;
	private System.Windows.Forms.MenuItem menuItemScan;
	private System.Windows.Forms.MenuItem menuItemSelSrc;
	private System.Windows.Forms.MenuItem menuMainWindow;
	private System.Windows.Forms.MenuItem menuItemExit;
	private System.Windows.Forms.MenuItem menuItemSepr;
    private System.Windows.Forms.MainMenu mainFrameMenu;
    private MenuItem mnSetup;
    private MenuItem mnShowUI;
    private MenuItem mnShowImages;
    private MenuItem menuItem1;
    private MenuItem menuItem2;
    private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsTwain;
    private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmTwain_Toolbars_Dock_Area_Left;
    private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmTwain_Toolbars_Dock_Area_Right;
    private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmTwain_Toolbars_Dock_Area_Top;
    private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmTwain_Toolbars_Dock_Area_Bottom;
    private IContainer components;

    private String _CompanyID;
    private String _CustomerID;
    private String _Batch;
    private String _Teacher;
    private Batch oBatch = new Batch();


	public frmTwain()
		{
		InitializeComponent();
		tw = new Twain();
		tw.Init( this.Handle );
        GetGlobalParameters();
		}

	protected override void Dispose( bool disposing )
		{
		if( disposing )
			{
			tw.Finish();
			if (components != null) 
				{
				components.Dispose();
				}
			}
		base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Standard");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetupSchool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Adquire");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetupSchool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("School");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Adquire");
            this.menuMainFile = new System.Windows.Forms.MenuItem();
            this.menuItemSelSrc = new System.Windows.Forms.MenuItem();
            this.menuItemScan = new System.Windows.Forms.MenuItem();
            this.mnSetup = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnShowUI = new System.Windows.Forms.MenuItem();
            this.mnShowImages = new System.Windows.Forms.MenuItem();
            this.menuItemSepr = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.mainFrameMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuMainWindow = new System.Windows.Forms.MenuItem();
            this._frmTwain_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsTwain = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmTwain_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmTwain_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmTwain_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsTwain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMainFile
            // 
            this.menuMainFile.Index = 0;
            this.menuMainFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSelSrc,
            this.menuItemScan,
            this.mnSetup,
            this.menuItem2,
            this.menuItem1,
            this.mnShowUI,
            this.mnShowImages,
            this.menuItemSepr,
            this.menuItemExit});
            this.menuMainFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuMainFile.Text = "&File";
            // 
            // menuItemSelSrc
            // 
            this.menuItemSelSrc.Index = 0;
            this.menuItemSelSrc.MergeOrder = 11;
            this.menuItemSelSrc.Text = "&Select Source...";
            this.menuItemSelSrc.Click += new System.EventHandler(this.menuItemSelSrc_Click);
            // 
            // menuItemScan
            // 
            this.menuItemScan.Index = 1;
            this.menuItemScan.MergeOrder = 12;
            this.menuItemScan.Text = "&Acquire...";
            this.menuItemScan.Click += new System.EventHandler(this.menuItemScan_Click);
            // 
            // mnSetup
            // 
            this.mnSetup.Index = 2;
            this.mnSetup.Text = "Setup Scanner";
            this.mnSetup.Click += new System.EventHandler(this.mnSetup_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "Setup School";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // mnShowUI
            // 
            this.mnShowUI.Index = 5;
            this.mnShowUI.Text = "Show UI";
            this.mnShowUI.Click += new System.EventHandler(this.mnShowUI_Click);
            // 
            // mnShowImages
            // 
            this.mnShowImages.Index = 6;
            this.mnShowImages.Text = "Show Images";
            this.mnShowImages.Click += new System.EventHandler(this.mnShowImages_Click);
            // 
            // menuItemSepr
            // 
            this.menuItemSepr.Index = 7;
            this.menuItemSepr.MergeOrder = 19;
            this.menuItemSepr.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 8;
            this.menuItemExit.MergeOrder = 21;
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // mainFrameMenu
            // 
            this.mainFrameMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuMainFile,
            this.menuMainWindow});
            // 
            // menuMainWindow
            // 
            this.menuMainWindow.Index = 1;
            this.menuMainWindow.MdiList = true;
            this.menuMainWindow.Text = "&Window";
            // 
            // _frmTwain_Toolbars_Dock_Area_Left
            // 
            this._frmTwain_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmTwain_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmTwain_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmTwain_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmTwain_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._frmTwain_Toolbars_Dock_Area_Left.Name = "_frmTwain_Toolbars_Dock_Area_Left";
            this._frmTwain_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 496);
            this._frmTwain_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsTwain;
            // 
            // ultraToolbarsTwain
            // 
            this.ultraToolbarsTwain.DesignerFlags = 1;
            this.ultraToolbarsTwain.DockWithinContainer = this;
            this.ultraToolbarsTwain.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsTwain.ShowFullMenusDelay = 500;
            this.ultraToolbarsTwain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
            ultraToolbar1.Text = "Standard";
            this.ultraToolbarsTwain.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool3.SharedProps.Caption = "Setup School";
            buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool4.SharedProps.Caption = "School";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool5.SharedProps.Caption = "Adquire";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            this.ultraToolbarsTwain.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4,
            buttonTool5});
            this.ultraToolbarsTwain.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsTwain.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsTwain_ToolClick);
            // 
            // _frmTwain_Toolbars_Dock_Area_Right
            // 
            this._frmTwain_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmTwain_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmTwain_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmTwain_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmTwain_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(782, 26);
            this._frmTwain_Toolbars_Dock_Area_Right.Name = "_frmTwain_Toolbars_Dock_Area_Right";
            this._frmTwain_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 496);
            this._frmTwain_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsTwain;
            // 
            // _frmTwain_Toolbars_Dock_Area_Top
            // 
            this._frmTwain_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmTwain_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmTwain_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmTwain_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmTwain_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmTwain_Toolbars_Dock_Area_Top.Name = "_frmTwain_Toolbars_Dock_Area_Top";
            this._frmTwain_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(782, 26);
            this._frmTwain_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsTwain;
            // 
            // _frmTwain_Toolbars_Dock_Area_Bottom
            // 
            this._frmTwain_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmTwain_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmTwain_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmTwain_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmTwain_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 522);
            this._frmTwain_Toolbars_Dock_Area_Bottom.Name = "_frmTwain_Toolbars_Dock_Area_Bottom";
            this._frmTwain_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(782, 0);
            this._frmTwain_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsTwain;
            // 
            // frmTwain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(782, 522);
            this.Controls.Add(this._frmTwain_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmTwain_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmTwain_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._frmTwain_Toolbars_Dock_Area_Bottom);
            this.IsMdiContainer = true;
            this.Menu = this.mainFrameMenu;
            this.Name = "frmTwain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adquire Images";
            this.Load += new System.EventHandler(this.frmTwain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsTwain)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



	private void menuItemExit_Click(object sender, System.EventArgs e)
		{
		Close();
		}

	private void menuItemScan_Click(object sender, System.EventArgs e)
		{
		if( ! msgfilter )
			{
			this.Enabled = false;
			msgfilter = true;
			Application.AddMessageFilter( this );
			}
            tw.Acquire(mnShowUI.Checked ? (short)1 : (short)0, (short)1);
		}

	private void menuItemSelSrc_Click(object sender, System.EventArgs e)
		{
		tw.Select();
		}


	bool IMessageFilter.PreFilterMessage( ref Message m )
		{
		TwainCommand cmd = tw.PassMessage( ref m );
		if( cmd == TwainCommand.Not )
			return false;

		switch( cmd )
			{
			case TwainCommand.CloseRequest:
				{
				EndingScan();
				tw.CloseSrc();
				break;
				}
			case TwainCommand.CloseOk:
				{
				EndingScan();
				tw.CloseSrc();
				break;
				}
			case TwainCommand.DeviceEvent:
				{
				break;
				}
			case TwainCommand.TransferReady:
				{
                int ImgNumber = 0;
                    
                ArrayList pics = tw.TransferPictures();
				EndingScan();
				tw.CloseSrc();
				picnumber++;
                
                if (!this.mnShowImages.Checked)
                {   
                    if (oBatch.Find(_CompanyID, _CustomerID, _Teacher))
                    {
                        ImgNumber = oBatch._ImageFinal;
                    }

                    oBatch._ImageInitial = 1;
                    oBatch.CompanyID = _CompanyID;
                    oBatch.CustomerID = _CustomerID;
                    
                    
                }

                    

				int i;
                for( i = 0; i < pics.Count; i++ )
					{
                        
                        IntPtr img = (IntPtr) pics[ i ];

                    if (this.mnShowImages.Checked)
                    {
                        PicForm newpic = new PicForm(img);
                        newpic.MdiParent = this;
                        //Panel.Controls.Add((Control)newpic);
                        
                        int picnum = ImgNumber + i + 1;
                        //newpic.Text = "ScanPass" + picnumber.ToString() + "_Pic" + picnum.ToString();
                        newpic.Text = "Order" + picnumber.ToString() + "_Pic" + picnum.ToString();
                        newpic.Show();
                    }
                    else
                    {

                        bmprect = new Rectangle(0, 0, 0, 0);
                        bmpptr = GlobalLock(img);
                        pixptr = GetPixelInfo(bmpptr);
                        int picnum = ImgNumber + i + 1;

                        //Gdip.SavePicToFile("ScanPass" + picnum.ToString() + ".tiff", bmpptr, pixptr);
                        Gdip.SavePicToFile("Images/Order-" + _CompanyID.PadLeft(2,'0') + _CustomerID.PadLeft(4,'0') + _Batch.PadLeft(3,'0') +  picnum.ToString().PadLeft(4,'0') + ".tif", bmpptr, pixptr);
                    }
                    
                    }
                    if (!this.mnShowImages.Checked)
                    { 
                        //Save Batch Here

                        oBatch._ImageFinal = ImgNumber + i;
                        oBatch._NumberImages += i;
                        oBatch.Teacher = _Teacher;
                        oBatch.Save();

                    }

				break;
				}
            default:
                {
                    return false;
                    
                }
			}

		return true;
		}

	private void EndingScan()
		{
		if( msgfilter )
			{
			Application.RemoveMessageFilter( this );
			msgfilter = false;
			this.Enabled = true;
			this.Activate();
			}
		}

	private bool	msgfilter;
	private Twain	tw;
	private int		picnumber = 0;
    static BITMAPINFOHEADER bmi;
    static Rectangle bmprect;
                    

    private void mnSetup_Click(object sender, EventArgs e)
    {
        if( ! msgfilter )
			{
			this.Enabled = false;
			msgfilter = true;
			Application.AddMessageFilter( this );
			}
		tw.Setup();
		
    }
    private void mnShowUI_Click(object sender, EventArgs e)
    {
        if (!mnShowUI.Checked)
            mnShowUI.Checked = true;
        else
            mnShowUI.Checked = false;
    }
    private void mnShowImages_Click(object sender, EventArgs e)
    {
        if (!mnShowImages.Checked)
            mnShowImages.Checked = true;
        else
            mnShowImages.Checked = false;
    }
    private void ultraToolbarsTwain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
    {

        switch (e.Tool.Key.ToString())
        {
            case "Adquire":
                if (!msgfilter)
                {
                    this.Enabled = false;
                    msgfilter = true;
                    Application.AddMessageFilter(this);
                }
                tw.Acquire(mnShowUI.Checked ? (short)1 : (short)0, (short)1); 
                break;
            
            case "SetupSchool":
                frmSetupCustomer frm = new frmSetupCustomer();
                frm.ShowDialog();
                GetGlobalParameters();
                break;
          }
        

    }

    private void GetGlobalParameters()
    {
        
        _CompanyID = Global.GetParameter("CurrentCompany");
        _CustomerID = Global.GetParameter("CurrentCustomer");
        _Batch = Global.GetParameter("CurrentBatch");
        _Teacher = Global.GetParameter("CurrentTeacher");

    }
    
    protected  IntPtr GetPixelInfo(IntPtr bmpptr)
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

    IntPtr bmpptr;
    IntPtr pixptr;

    [DllImport("kernel32.dll", ExactSpelling = true)]
    internal static extern IntPtr GlobalLock(IntPtr handle);
    [DllImport("kernel32.dll", ExactSpelling = true)]
    internal static extern IntPtr GlobalFree(IntPtr handle);

    private void frmTwain_Load(object sender, EventArgs e)
    {
        this.GetGlobalParameters();
    }

    

    

    
/*
	[STAThread]
	static void Main() 
		{
		if( Twain.ScreenBitDepth < 15 )
			{
			MessageBox.Show( "Need high/true-color video mode!", "Screen Bit Depth", MessageBoxButtons.OK, MessageBoxIcon.Information );
			return;
			}

		MainFrame mf = new MainFrame();
		Application.Run( mf );
		}
*/
	} // class MainFrame

} // namespace TwainGui
