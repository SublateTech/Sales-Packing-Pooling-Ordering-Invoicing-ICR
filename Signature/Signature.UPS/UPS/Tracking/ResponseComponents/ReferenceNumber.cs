using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class ReferenceNumber
	{
		[XmlElement("Code")]
		public int Code;
		[XmlElement("Value")]
		public string Value;

		public ReferenceNumber()
		{
		}
	}
}
