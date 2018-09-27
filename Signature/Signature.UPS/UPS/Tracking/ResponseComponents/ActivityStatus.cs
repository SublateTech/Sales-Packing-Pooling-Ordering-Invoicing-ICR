using System;
using System.Xml.Serialization;

namespace Signature.UPS.Tracking.ResponseComponents
{
	public class ActivityStatus
	{
		[XmlElement("StatusType")]
		public StatusType MyStatusType;
		[XmlElement("StatusCode")]
		public StatusCode MyStatusCode;

		public ActivityStatus()
		{
		}
	}
}
