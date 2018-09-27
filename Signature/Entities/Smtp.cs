using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Mail;
using System.Net;
//using System.Web.Mail;
using System.Collections;
using System.Windows.Forms;


namespace Signature.Classes {

	public class Smtp {

        public System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        public String Error = "";
        private NetworkCredential _Credentials = null;
        
        public String To
        {
           // get { return mail.To; }
            set { mail.To.Add(new MailAddress(value)); }
        }
        public String From
        {
           // get { return mail.From; }
            set { mail.From = new MailAddress(value); }
        }

        public String BCC
        {
            // get { return mail.From; }
            set { mail.Bcc.Add(new MailAddress(value)); }
        }

        

        public String CC
        {
            // get { return mail.From; }
            set { mail.CC.Add(new MailAddress(value)); }
        }
        public String Subject 
        {
            get { return mail.Subject; }
            set { mail.Subject = value; }
        }
        public String Body 
        {
            get { return mail.Body; }
            set { mail.Body = value; }
        }
        public String Attachment
        {
            set { mail.Attachments.Add(new Attachment(value)); }
        }

        public NetworkCredential Credentials
        {
            set { _Credentials = value; }
            get { return _Credentials; }
        }
        
        public Boolean Send()
        {
            try 
            {

                System.Net.Mail.SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "mail.signaturefundraising.com";
                if (Credentials != null)
                    SmtpServer.Credentials = Credentials;
                else
                    SmtpServer.Credentials = new NetworkCredential("info@sigfund.com", "sigfund007");

                SmtpServer.Send(mail);
                
			}
			catch(Exception ex)
			{
			    Console.WriteLine("Error  :"+ex.ToString());
                //Error = ex.ToString();
                return false;
			}
            return true;
        }
        public void Test()
        {
            To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
            From = "\"Jane Doe\" <me@mycompny.com>";
            Subject = "this is a test email.";
            Body = "this is my test email body";
            System.Net.Mail.SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "mail.signaturefundraising.com";
            SmtpServer.Send(mail);

        }
	}
}


