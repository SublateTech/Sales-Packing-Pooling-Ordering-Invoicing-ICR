using System;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using System.Text;
using System.Data;

namespace Signature.UPS.Tracking
{
	[XmlRoot("TrackRequest")]
	public class TrackingRequest
	{
		RequestComponents.Request _req;
		string _trackingNumber;

		/// <summary>
		/// The URL that should be used during development.  It works exactly the same as the production URL.
		/// </summary>
		public const string DEV_URL = "https://wwwcie.ups.com/ups.app/xml/Track";
		/// <summary>
		/// The URL that should be used in a production environment.
		/// </summary>
		public const string PRODUCTION_URL = "https://www.ups.com/ups.app/xml/Track";

		/// <summary>
		/// Creates a new instance of the TrackingRequest without a tracking
		/// number and transaction key.
		/// </summary>
		public TrackingRequest()
		{
		}

		/// <summary>
		/// Creates a new instance of the TrackingRequest with the specified
		/// tracking number and transaction key.
		/// </summary>
		/// <param name="trackingNumber"></param>
		/// <param name="transactionKey">
		///	A key used to distinguish the correct response from a list of
		///	multiple responses.
		/// </param>
		public TrackingRequest(string trackingNumber, string transactionKey)
		{
			_req = new RequestComponents.Request(transactionKey);
			_trackingNumber = trackingNumber;
		}

		[XmlElement("Request")]
		public RequestComponents.Request Request
		{
			get
			{
				return _req;
			}
			set
			{
				_req = value;
			}
		}

		/// <summary>
		/// The tracking number that tracking information
		/// will be retrieved for.
		/// </summary>
		[XmlElement("TrackingNumber")]
		public string TrackingNumber
		{
			get
			{
				return _trackingNumber;
			}
			set
			{
				_trackingNumber = value;
			}
		}

		/// <summary>
		/// Makes a request to the UPS Production server.
		/// </summary>
		/// <param name="ar"></param>
		/// <returns></returns>
		public TrackingResponse MakeRequest(AccessRequest ar)
		{
			return MakeRequest(PRODUCTION_URL, ar);
		}

		/// <summary>
		/// Makes a request to the UPS server using the
		/// specified URL.  For the URL, you should use the
		/// DEV_URL or PRODUCTION_URL constant.
		/// </summary>
		/// <param name="serverUrl"></param>
		/// <param name="ar"></param>
		/// <returns></returns>
		public TrackingResponse MakeRequest(string serverUrl, AccessRequest ar)
		{
			string postString;
			byte[] postData;
			HttpWebRequest req;
			Stream requestStream;
			string responseXml;
			WebResponse response;
			Stream responseStream;
			StreamReader sr;

			//The request has two xml documents combined.  It has
			//the serialized access request, and then the actual
			//tracking request.
			postString = ar.Serialize();
			postString += Serialize();

			//Convert the xml to bytes
			postData = System.Text.Encoding.UTF8.GetBytes(postString);

			//Set up the request
			req = (HttpWebRequest)WebRequest.Create("https://www.ups.com/ups.app/xml/Track");
			req.Method = "POST";
			req.ContentType="application/x-www-form-urlencoded";
			req.ContentLength = postData.Length;
			requestStream = req.GetRequestStream();

			// Send the data.
			requestStream.Write(postData, 0, postData.Length);
			requestStream.Close();

			//Get the response
			response = req.GetResponse();
			responseStream = response.GetResponseStream();
          /*  
            DataSet ds = new DataSet();
            ds.ReadXml(responseStream);
            ds.WriteXml("TrackingNumber.xml");
            sr = new StreamReader("TrackingNumber.xml");
            */
            sr = new StreamReader(responseStream);
			responseXml = sr.ReadToEnd();
            
            
            
            //Console.WriteLine(responseXml.ToString());

			//Deserialize the response and return it
			return TrackingResponse.DeserializeTrackingResponse(responseXml);
		}

		/// <summary>
		/// Serializes this tracking request.
		/// </summary>
		/// <returns></returns>
		public string Serialize()
		{
			XmlSerializer ser;
			StringWriter writer;
			
			StringBuilder sb;
			
			ser = new XmlSerializer(typeof(TrackingRequest));
			sb = new StringBuilder();
			writer = new System.IO.StringWriter(sb);
			
			ser.Serialize(writer, this);
			writer.Close();

			return sb.ToString();
		}
	}
}
