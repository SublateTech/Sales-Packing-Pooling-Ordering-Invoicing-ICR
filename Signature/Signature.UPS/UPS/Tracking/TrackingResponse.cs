using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Windows.Forms;

using Signature.UPS.Tracking.ResponseComponents;

namespace Signature.UPS.Tracking
{
	/// <summary>
	/// This class processes the response returned from
	/// the UPS server.
	/// </summary>
	[XmlRoot("TrackResponse")]
	public class TrackingResponse
	{
		Response _response;
		Shipment _shipment;

		/// <summary>
		/// The default constructor for the TrackingResponse object.
		/// This is required for deserialization.
		/// </summary>
		public TrackingResponse()
		{
		}

		/// <summary>
		/// Deserializes the tracking response from the specified xml
		/// string.
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static TrackingResponse DeserializeTrackingResponse(string xml)
		{
			XmlSerializer xs;
			System.IO.StringReader sr;
			object obj;

			xs = new XmlSerializer(typeof(TrackingResponse));
			sr  = new System.IO.StringReader(xml);
			obj = xs.Deserialize(sr);

      return (TrackingResponse)obj;
		}

		/// <summary>
		/// Gets a datatable that contains the steps that
		/// the package has taken.
		/// </summary>
		/// <returns></returns>
		public DataTable GetTrackingInfo()
		{
			PackageActivity[] activities = null;
			DataTable infoTable;
			object[] objs;
			DateTime currTime;
			string location;
			string statusDesc;
			string htmlDesc;
			
			infoTable = createInfoTable();

			if(_shipment == null)
				return infoTable;

			activities = _shipment.MyPackage.Activity;
            
            //if (_shipment.MyShipTo.DestAddress != null)
            //    MessageBox.Show(_shipment.MyShipTo.DestAddress.City);
            

			foreach(PackageActivity currActivity in activities)
			{
				currTime = currActivity.Timestamp;
				location = currActivity.Location.MyAddress.City;
				statusDesc = currActivity.Status.MyStatusType.Description;
				htmlDesc = getHtmlDescription(currActivity);

				objs = new object[]{currTime, location, statusDesc, htmlDesc};
				infoTable.Rows.Add(objs);
			}

			return infoTable;
		}

		/// <summary>
		/// Creates an HTML description of the activity.  This is
		/// primarily for turning the tracking into an RSS feed or
		/// email notification.
		/// </summary>
		/// <param name="activity"></param>
		/// <returns></returns>
		private string getHtmlDescription(PackageActivity activity)
		{
			StringBuilder desc;

			desc = new StringBuilder();
			desc.Append("Date/Time: " + activity.Timestamp.ToString() + "<br />");
			desc.Append("Location: " + activity.Location.MyAddress.ToString() + "<br />");
			desc.Append("Status Type: " + activity.Status.MyStatusType.Description);

			return desc.ToString();
		}

		private DataTable createInfoTable()
		{
			DataTable dt;

			dt = new DataTable();
			dt.Columns.Add("Timestamp", typeof(DateTime));
			dt.Columns.Add("Location", typeof(string));
			dt.Columns.Add("Activity", typeof(string));
			dt.Columns.Add("HtmlDescription", typeof(string));

			return dt;
		}

		[XmlElement("Response")]
		public Response MyResponse
		{
			get{	return _response;	}
			set{	_response = value;	}
		}

		[XmlElement("Shipment")]
		public Shipment MyShipment
		{
			get{	return _shipment;	}
			set{	_shipment = value;	}
		}
	}
}
