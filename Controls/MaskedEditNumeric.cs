using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.Common;
using Janus.Windows.GridEX.EditControls;


namespace MaskedEdit
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(MaskedEditNumeric))]
	[DesignerAttribute(typeof(MaskedEditDesigner))]
	public class MaskedEditNumeric :  Janus.Windows.GridEX.EditControls.NumericEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaskedEditNumeric()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			
		/*	switch(keyData)
			{
				case Keys.Up:
					SendKeys.Send("+{Tab}");
					break;
				case Keys.Down:
					SendKeys.Send("{Tab}");
					break;
			//	case Keys.Enter:
			//		SendKeys.Send("{Tab}");
			//		break;
									
			}
*/
			return base.ProcessCmdKey(ref msg, keyData);
		}
		
		// event handlers
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
		/*	MessageBox.Show("Ok");
			
			if(e.KeyChar == (char) 13)
			{
				
				e.Handled=true;
			}
		*/	
			base.OnKeyPress(e);
			return;
		}
	
	}
}
