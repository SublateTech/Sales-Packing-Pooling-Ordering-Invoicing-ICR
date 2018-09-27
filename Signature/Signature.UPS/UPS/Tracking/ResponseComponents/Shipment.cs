using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	/// <summary>
	/// Summary description for Shipment.
	/// </summary>
	public class Shipment
	{
        DateTime _timestamp;

        [XmlElement("Shipper")]
		public Shipper MyShipper;
		[XmlElement("ShipTo")]
		public ShipTo MyShipTo;
		[XmlElement("Service")]
		public Service MyService;
		[XmlElement("ShipmentIdentificationNumber")]
		public string ShipmentIdentificationNumber;
		[XmlElement("PickupDate")]
		public string PickupDate;
		[XmlElement("ScheduledDeliveryDate")]
        public string ScheduledDeliveryDate
        {
            get
            {
                //throw new NotImplementedException("");
                return _timestamp.ToShortDateString();
            }
            set
            {
                DateTime newDate;

                newDate = UpsFormatConversions.parseUpsDate(value);
                _timestamp = new DateTime(newDate.Year, newDate.Month, newDate.Day, _timestamp.Hour,
                _timestamp.Minute, _timestamp.Second, _timestamp.Millisecond);

            }
        }
		[XmlElement("Package")]
		public Package MyPackage;
        [XmlElement("ReferenceNumber")]
        public ReferenceNumber[] MyReferenceNumbers;

		public Shipment()
		{

		}
	}
}
