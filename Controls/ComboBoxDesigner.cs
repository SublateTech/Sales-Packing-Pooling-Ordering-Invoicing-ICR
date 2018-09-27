using System;

namespace MaskedEdit
{
	/// <summary>
	/// Summary description for DividerPanelDesigner.
	/// </summary>
	public class ComboBoxDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		public ComboBoxDesigner()
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
