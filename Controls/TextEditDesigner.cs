using System;

namespace MaskedEdit
{
	/// <summary>
	/// Summary description for DividerPanelDesigner.
	/// </summary>
	public class TextEditDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		public TextEditDesigner()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			//properties.Remove("BorderStyle");
		}

	}
}
