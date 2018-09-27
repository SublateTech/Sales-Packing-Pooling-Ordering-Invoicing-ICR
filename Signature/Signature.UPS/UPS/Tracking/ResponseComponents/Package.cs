using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	/// <summary>
	/// Summary description for Package.
	/// </summary>
	public class Package
	{
            DateTime _timestamp;
        
            [XmlElement("TrackingNumber")]
			public string TrackingNumber;
    
			//[XmlArray, XmlArrayItem("Activity", typeof(PackageActivity))]

            [XmlElement("RescheduledDeliveryDate")]
            public string RescheduledDeliveryDate
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

            [XmlElement("Activity")]
			public PackageActivity[] Activity;
    
			[XmlElement("Message")]
			public PackageMessage Message;
    
			[XmlElement("PackageWeight")]
			public PackageWeight PackageWeight;

            [XmlElement("ReferenceNumber")]
            public ReferenceNumber[] MyReferenceNumbers;
    
		
	}
}
