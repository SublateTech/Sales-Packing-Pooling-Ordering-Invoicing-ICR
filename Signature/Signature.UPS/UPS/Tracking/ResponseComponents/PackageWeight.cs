using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class PackageWeight
	{
		[XmlElement("Weight")]
		public double Weight;
    
		[XmlElement("UnitOfMeasurement")]
		public UnitOfMeasurement MyUnitOfMeasurement;

	}
}
