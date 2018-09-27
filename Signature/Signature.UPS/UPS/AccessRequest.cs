using System;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using System.Text;


namespace Signature.UPS.Tracking
{
	/// <summary>
	/// Summary description for AccessRequest.
	/// </summary>
	public class AccessRequest
	{
		string _licenseNumber;
		string _userName;
		string _password;

		public AccessRequest()
		{
		}
        public AccessRequest(string licenseNumber, string userName, string password)
		{
			_licenseNumber = licenseNumber;
			_userName = userName;
			_password = password;

		}

		[XmlElement("AccessLicenseNumber")]
		public string LicenseNumber
		{
			get
			{
				return _licenseNumber;
			}
			set
			{
				_licenseNumber = value;
			}
		}

		[XmlElement("UserId")]
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}

		[XmlElement("Password")]
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}

		public string Serialize()
		{
            XmlSerializer ser;
            StringWriter writer;

            StringBuilder sb;

            ser = new XmlSerializer(typeof(AccessRequest));
            sb = new StringBuilder();
            writer = new System.IO.StringWriter(sb);

            ser.Serialize(writer, this);
            writer.Close();

            return sb.ToString();
		}
	}
}
