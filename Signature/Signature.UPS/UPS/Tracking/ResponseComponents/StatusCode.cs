using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class StatusCode
	{
		[XmlElement("Code")]
		public string Code;

		public StatusCode()
		{
		}
	}
}
