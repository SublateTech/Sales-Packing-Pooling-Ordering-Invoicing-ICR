using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class ActivityLocation
	{
		 
        [XmlElement("Code")]
		public String Code;

        [XmlElement("Description")]
		public String Description;
        
        [XmlElement("SignedForByName")]
		public String SignedFor;

        [XmlElement("Address")]
        public Address MyAddress;


		public ActivityLocation()
		{
		}
	}
}
