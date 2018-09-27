using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	/// <summary>
	/// Summary description for ShipTo.
	/// </summary>
	public class ShipTo
	{
		[XmlElement("Address")]
		public Address DestAddress;

		public ShipTo()
		{
		}
	}
}
