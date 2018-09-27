using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using vbAccelerator.Components.Win32;

namespace MDIClientPainter
{
	/// <summary>
	/// Form demonstrating how to use the MDIClientWindow class
	/// to draw a custom image onto the MDI Client area.
	/// </summary>
	public class mfrmMDIClientPaint : 
		System.Windows.Forms.Form, 
		IMDIClientNotify
	{

		#region Private Structures
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;

			public override string ToString()
			{
				string ret = String.Format(
					"left = {0}, top = {1}, right = {2}, bottom = {3}",
					left, top, right, bottom);
				return ret;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		private struct PAINTSTRUCT
		{
			public IntPtr hdc;
			public int fErase;
			public RECT rcPaint;
			public int fRestore;
			public int fIncUpdate;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]  public byte[] rgbReserved;

			public override string ToString()
			{
				string ret = String.Format(
					"hdc = {0} , fErase = {1}, rcPaint = {2}, fRestore = {3}, fIncUpdate = {4}",
					hdc, fErase, rcPaint.ToString(), fRestore, fIncUpdate);
				return ret;
			}
		}

		#endregion
		
		#region UnManagedMethods
		private class UnManagedMethods
		{
			[DllImport("user32")]
			public extern static int GetClientRect(
				IntPtr hwnd, 
				ref RECT lpRect);
			[DllImport("user32")]
			public extern static int BeginPaint(
				IntPtr hwnd,
				ref PAINTSTRUCT lpPaint);
			[DllImport("user32")]
			public extern static int EndPaint(
				IntPtr hwnd,
				ref PAINTSTRUCT lpPaint);
			[DllImport("user32", CharSet = CharSet.Auto)]
			public extern static uint SetClassLong (
				IntPtr hwnd, 
				int nIndex , 
				uint dwNewLong);
			[DllImport("user32")]
			public extern static int InvalidateRect (
				IntPtr hwnd, 
				ref RECT lpRect, 
				int bErase);

			public const int WM_PAINT = 0xF;
			public const int WM_ERASEBKGND = 0x14;
			public const int WM_SIZE = 0x5;

			public const int GCL_HBRBACKGROUND = (-10);

		}
		#endregion

		#region Member Variables
		/// <summary>
		/// Class to hold the MDI Client
		/// </summary>
		private MDIClientWindow mdiClient = null;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuWindow;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.StatusBar sbrMain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor, Dispose
		public mfrmMDIClientPaint()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(mfrmMDIClientPaint));
			this.sbrMain = new System.Windows.Forms.StatusBar();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuWindow = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// sbrMain
			// 
			this.sbrMain.Location = new System.Drawing.Point(0, 412);
			this.sbrMain.Name = "sbrMain";
			this.sbrMain.Size = new System.Drawing.Size(556, 22);
			this.sbrMain.TabIndex = 1;
			this.sbrMain.Text = " vbAccelerator MDI Client Area Paint Demonstration";
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuWindow});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNew,
																					this.menuItem2,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.mnuNew.Text = "&New...";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "E&xit";
			// 
			// mnuWindow
			// 
			this.mnuWindow.Index = 1;
			this.mnuWindow.MdiList = true;
			this.mnuWindow.Text = "&Window";
			// 
			// mfrmMDIClientPaint
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(556, 434);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sbrMain});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mnuMain;
			this.Name = "mfrmMDIClientPaint";
			this.Text = "MDIClient Area Paint Demonstration";
			this.Load += new System.EventHandler(this.mfrmMDIClientPaint_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Application Entry Point
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new mfrmMDIClientPaint());
		}
		#endregion

		#region MDI Background Painting
		public void WndProc(ref Message m, ref bool doDefault)
		{
			// Don't need to do anything if the form is minimized:
			if (this.WindowState != FormWindowState.Minimized)
			{

				if (m.Msg == UnManagedMethods.WM_PAINT)
				{
					//
					// Here we draw a logo on the "right" hand side 
					// of the form (depends on RTL)
					//
					PAINTSTRUCT ps = new PAINTSTRUCT();
					UnManagedMethods.BeginPaint(m.HWnd, ref ps);
					RECT rc = new RECT();
					UnManagedMethods.GetClientRect(m.HWnd, ref rc);

					// Convert to managed code world				
					Graphics gfx = Graphics.FromHdc(ps.hdc);
					RectangleF rcClient = new RectangleF(
						rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
					Rectangle rcPaint = new Rectangle(
						ps.rcPaint.left, 
						ps.rcPaint.top,
						ps.rcPaint.right - ps.rcPaint.left,
						ps.rcPaint.bottom - ps.rcPaint.top);

					// Draw the logo bottom right:
					SolidBrush brText = new SolidBrush(Color.White);
					StringFormat strFormat = new StringFormat();
					strFormat.Alignment = StringAlignment.Far;
					strFormat.FormatFlags = StringFormatFlags.DirectionVertical |
						StringFormatFlags.NoWrap;
					strFormat.LineAlignment = StringAlignment.Far;					
					Font logoFont = new Font(this.Font.FontFamily, 20, FontStyle.Bold);
					gfx.DrawString("SigFund.com", logoFont, brText, rcClient, strFormat);
					logoFont.Dispose();
					strFormat.Dispose();
					brText.Dispose();

					gfx.Dispose();
					UnManagedMethods.EndPaint(m.HWnd, ref ps);
				}
				else if (m.Msg == UnManagedMethods.WM_ERASEBKGND)
				{
					//
					// Fill the background:
					//

					RECT rc = new RECT();
					UnManagedMethods.GetClientRect(m.HWnd, ref rc);

					// Convert to managed code world
					Graphics gfx = Graphics.FromHdc(m.WParam);
					Rectangle rcClient = new Rectangle(
						rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top);
					
					int angle = 45;
					LinearGradientBrush linGrBrush = new LinearGradientBrush(
						rcClient,
						Color.FromArgb(255, 230, 242, 255),// pale blue
						Color.FromArgb(255, 0, 72, 160),   // deep blue
						angle);  

					gfx.FillRectangle(linGrBrush, rcClient);
					
					linGrBrush.Dispose();
					gfx.Dispose();

					// Tell Windows we've filled the background:
					m.Result = (IntPtr)1;
					
					// Don't call the default procedure:
					doDefault = false;

				}
				else if (m.Msg == UnManagedMethods.WM_SIZE)
				{
					// If your background is a tiled image then
					// you don't need to do this.  This is only required
					// when the entire background needs to be updated 
					// in response to the size of the object changing.
					RECT rect = new RECT();
					rect.left = 0;
					rect.top = 0;
					rect.right = ((int)m.LParam) & 0xFFFF;
					rect.bottom = (int)(((uint)(m.LParam) & 0xFFFF0000) >> 16);
					//Console.WriteLine("WM_SIZE {0}", rect.ToString());
					UnManagedMethods.InvalidateRect(m.HWnd, ref rect, 1);
				}
			}
		}
		#endregion

		#region Events
		private void mfrmMDIClientPaint_Load(object sender, System.EventArgs e)
		{
			// Start processing for MDIClient window messages:
			mdiClient = new MDIClientWindow(this, this.Handle);			
			// Stop the default window proc from drawing the MDI background
			// with the brush:
			UnManagedMethods.SetClassLong(
				mdiClient.Handle, 
				UnManagedMethods.GCL_HBRBACKGROUND, 
				0);

			// Load a sample child form:
			frmChild f = new frmChild();
			f.MdiParent = this;
			f.Show();

			// Attach to menu events:
			this.mnuNew.Click += new System.EventHandler(this.mnu_Click);
			this.mnuExit.Click += new System.EventHandler(this.mnu_Click);
		}

		private void mnu_Click(object sender, System.EventArgs e)
		{
			if (sender == mnuNew)
			{
				frmChild f = new frmChild();
				f.MdiParent = this;
				f.Show();
			}
			else if (sender == mnuExit)
			{
				this.Close();
			}
		}
		#endregion


	}
}
