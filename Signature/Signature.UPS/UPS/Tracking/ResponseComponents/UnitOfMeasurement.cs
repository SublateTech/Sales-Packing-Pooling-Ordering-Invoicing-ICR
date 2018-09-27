using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class UnitOfMeasurement
	{
		[XmlElement("Code")]
		public string Code;

		public UnitOfMeasurement()
		{
			
		}
	}
}
