using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;

namespace Signature.Windows.Forms
{
	/// <summary>
	/// Description of CustomTabControl.
	/// </summary>
	[ToolboxBitmap(typeof(TabControl))]
	public class TabControl : System.Windows.Forms.TabControl
	{
		
		public TabControl() : base()
		{
			if (this._DisplayManager.Equals(TabControlDisplayManager.Custom)) {
				this.SetStyle(ControlStyles.UserPaint, true);
				this.ItemSize = new Size(0, 15);
			}
			
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.ResizeRedraw = true;
		}
		
		TabControlDisplayManager _DisplayManager = TabControlDisplayManager.Custom;
	
		[System.ComponentModel.DefaultValue(typeof(TabControlDisplayManager), "Custom")]
		public TabControlDisplayManager DisplayManager {
			get {
            	return this._DisplayManager;
			}
			set {
				if (this._DisplayManager != value) {
					if (this._DisplayManager.Equals(TabControlDisplayManager.Custom)) {
						this.SetStyle(ControlStyles.UserPaint, true);
						this.ItemSize = new Size(0, 15);
					} else {
						this.SetStyle(ControlStyles.UserPaint, false);
						this.ItemSize = new Size(0, 0);
					}
				}
			}
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (this.DesignMode == true) 
            {
				LinearGradientBrush backBrush = new LinearGradientBrush(
                	this.Bounds,
                	SystemColors.ControlLightLight,
                	SystemColors.ControlLight,
                	LinearGradientMode.Vertical);
				pevent.Graphics.FillRectangle(backBrush, this.Bounds);
            	backBrush.Dispose();
			} else {
	            this.InvokePaintBackground(this.Parent, pevent);
	            this.InvokePaint(this.Parent, pevent);
			}
		}
		 
		protected override void OnPaint(PaintEventArgs e)
		{
			 this.PaintAllTheTabs(e);
			 this.PaintTheTabPageBorder(e);
			 this.PaintTheSelectedTab(e);
		}

		private void PaintAllTheTabs(System.Windows.Forms.PaintEventArgs e)
        {
			if (this.TabCount > 0) {
				for (int index = 0; index < this.TabCount ; index++){
					this.PaintTab(e, index);
				}
			}
		}
		
		private void PaintTab(System.Windows.Forms.PaintEventArgs e, int index) 
        {
			GraphicsPath path = this.GetPath(index);
	        this.PaintTabBackground(e.Graphics, index, path);
	        this.PaintTabBorder(e.Graphics, index, path);
	        this.PaintTabText(e.Graphics, index);
		}

		private void PaintTabBackground(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path){
			Rectangle rect = this.GetTabRect(index);
	        System.Drawing.Brush buttonBrush =
	            new System.Drawing.Drawing2D.LinearGradientBrush(
	                rect,
	                SystemColors.ControlLightLight,
	                SystemColors.ControlLight,
	                LinearGradientMode.Vertical);
	        
	        if (index == this.SelectedIndex) {
	        	buttonBrush = new System.Drawing.SolidBrush(SystemColors.ControlLightLight);
	        }

	        graph.FillPath(buttonBrush, path);
        	buttonBrush.Dispose();
		}

		private void PaintTabBorder(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path){
			Pen borderPen = new Pen(SystemColors.ControlDark);

			if (index == this.SelectedIndex) {
	        	 borderPen = new Pen(ThemedColors.ToolBorder);
	        }
			graph.DrawPath(borderPen, path);
        	borderPen.Dispose();
		}

		private void PaintTabText(System.Drawing.Graphics graph, int index) {
			Rectangle rect = this.GetTabRect(index);
	        Rectangle rect2 = new Rectangle(rect.Left + rect.Height + 2, rect.Top, rect.Width - rect.Height, rect.Height);

	        if (index > 0){
	        	rect2 = new Rectangle(rect.Left + 8, rect.Top, rect.Width - 6, rect.Height);
	        }
	        string tabtext = this.TabPages[index].Text;
	       	System.Drawing.StringFormat format = new System.Drawing.StringFormat();

	       	format.Alignment = StringAlignment.Near;
        	format.LineAlignment = StringAlignment.Center;
        	format.Trimming = StringTrimming.EllipsisCharacter;

        	SolidBrush forebrush = new SolidBrush(this.ForeColor);
        	graph.DrawString(tabtext, this.Font, forebrush, rect2, format);
        	forebrush.Dispose();
		}

		private void PaintTheTabPageBorder(System.Windows.Forms.PaintEventArgs e) {
			if (this.TabCount > 0) {
				Rectangle borderRect= this.TabPages[0].Bounds;
            	borderRect.Inflate(1, 1);
            	ControlPaint.DrawBorder(e.Graphics, borderRect, ThemedColors.ToolBorder, ButtonBorderStyle.Solid);
			}
		}

		private void PaintTheSelectedTab(System.Windows.Forms.PaintEventArgs e) {
			Rectangle selrect;
			int selrectRight = 0;
			
			switch(this.SelectedIndex) {
				case -1:
					break;
				case 0:
	                selrect = this.GetTabRect(this.SelectedIndex);
	                selrectRight = selrect.Right;
	                e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
					break;
				default:
	                selrect = this.GetTabRect(this.SelectedIndex);
	                selrectRight = selrect.Right;
	                e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
					break;
			}
		}

		private System.Drawing.Drawing2D.GraphicsPath GetPath(int index) {
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.Reset();
			
			Rectangle rect = this.GetTabRect(index);

			if (index == 0){
	            path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
	            path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
	            path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
			} else {
				if (index == this.SelectedIndex) {
	                path.AddLine(rect.Left + 1, rect.Top + 5, rect.Left + 4, rect.Top + 2);
	                path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
	                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
	                path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left + 1, rect.Bottom + 1);
				} else {
	                path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
	                path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
	                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
	                path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
				}
				
			}
	        return path;
		}

	   	public enum TabControlDisplayManager {
        	Default,
        	Custom
		}
	
	}
}
