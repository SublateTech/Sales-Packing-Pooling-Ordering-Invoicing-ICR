using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	/// <summary>
	/// Summary description for Shipper.
	/// </summary>
	public class Shipper
	{
		[XmlElement("ShipperNumber")]
		public string ShipperNumber;
		[XmlElement("Address")]
		public Address SourceAddress;

		public Shipper()
		{
		}
	}
}
