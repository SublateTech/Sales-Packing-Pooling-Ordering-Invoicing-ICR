using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class PackageMessage
	{
		[XmlElement("Code")]
		public string Code;
    
		[XmlElement("Description")]
		public string Description;
	}
}
