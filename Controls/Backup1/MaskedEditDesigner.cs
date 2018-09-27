using System;

namespace Signature.Windows.Forms
{
	public class MaskedEditDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		public MaskedEditDesigner()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
		//	properties.Remove("BorderStyle");
		}

	}

	public class CalendarBoxDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		public CalendarBoxDesigner()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			//	properties.Remove("BorderStyle");
		}

	}
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
    public class MaskedLabelDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
    {
        public MaskedLabelDesigner()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            //	properties.Remove("BorderStyle");
        }

    }


}
