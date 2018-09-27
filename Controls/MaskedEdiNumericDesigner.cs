using System;

namespace MaskedEdit
{
	/// <summary>
	/// Summary description for DividerPanelDesigner.
	/// </summary>
	public class MaskedEditNumericDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		public MaskedEditNumericDesigner()
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
