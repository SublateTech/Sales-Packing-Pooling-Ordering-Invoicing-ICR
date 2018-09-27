    using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using dSERVE2;


namespace Signature.OSAS
{
	/// <summary>
	/// Summary description for OSAS_Orders.
	/// </summary>
	public class File
	{ 
		public String Error = null;
        public String sCustomerID=""; 
		public String sCompanyID="";

        private String fTemplate = new string(' ', 300);

        int err = 0;
        short channel=30;
		string sKey=new string(' ',100);
				
		public System.Array arrValues= new System.String[20];
		System.Array arrCustomers= new System.String[20];
		
		dSERVEClass oFile;
		String sFile= new string(' ',8);
		private String dServe="192.168.254.02";


		public File()
		{
            this.Connect();
		}
        public File(String sFile, String CompanyID)
        {

            this.Connect();
            this.Open(sFile, CompanyID);

        }
        public void SetTemplate(String str)
        {
            this.fTemplate = str;
            return;
        }
        public bool Connect()
		{
			
			oFile = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oFile.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				Error ="Not Connected!!";
				return false;
			}
            return true;
		}
        public bool Open(String File, String CompanyID)
		{
         String strTemp = new string(' ', 500);
            String sFile = File;
            int err = 0;

            if (CompanyID.Length > 0)
                sFile = File + "." + CompanyID;

            if ((err = oFile.dsOpen(sFile, ref channel)) == 30)  //Open our file to migrate
                this.Error = "This file wasn't open!!!";

            if (err == 13 || err == 12 || err == 11)
            {
                this.Error ="Couldn't open files,Please Contact to the server administrator error:" + err.ToString();
                return false;
            }

            
                switch (File)
                {

                    case "INTAX":
                        this.fTemplate = FileTemplate.INTAX;
                        oFile.dsTmpl(this.channel, fTemplate);
                        break;
                    case "INBROCH":
                        this.fTemplate = FileTemplate.INBROCH;
                        oFile.dsTmpl(this.channel, fTemplate);
                        break;
                    case "ARINV":
                        this.fTemplate = FileTemplate.ARINV;
                        oFile.dsTmpl(this.channel, fTemplate);
                        break;
                    case "INVEND":
                        this.fTemplate = FileTemplate.INVEND;
                        oFile.dsTmpl(this.channel, fTemplate);
                        break;
                    case "INMAST":
                        this.fTemplate = FileTemplate.INMAST;
                        oFile.dsTmpl(this.channel, fTemplate);
                        break;
                    case "ARMAST":
                        this.fTemplate = FileTemplate.ARMAST;
                        oFile.dsTmpl(this.channel, fTemplate);
                         break;
                    case "ARCUSTEX":
                         this.fTemplate = FileTemplate.ARCUSTEX;
                         oFile.dsTmpl(this.channel, fTemplate);
                         break;
                     case "OSST":
                         {   
                             this.fTemplate = FileTemplate.OSST;
                             oFile.dsTmpl(this.channel, fTemplate);
                             break;
                         }
                    case "WSCUST":
                         {
                             this.fTemplate = FileTemplate.WSCUST;
                             oFile.dsTmpl(this.channel, fTemplate);
                             break;
                         }
                    case "OPDISC":
                        strTemp = "id:c(10),teacher:c(30),student:c(30),Reserved:c(29),";
                        strTemp += "comment_1:c(50),comment_2:c(50),comment_3:c(50),comment_4:c(50),comment_5:c(50),";
                        strTemp += "comment_6:c(50),comment_7:c(50),comment_8:c(50),comment_9:c(50),comment_10:c(50*),";
                        strTemp += "n_1:n(10*),n_2:n(10*),n_3:n(10*),n_4:n(10*),n_5:n(10*),";
                        strTemp += "n_6:n(10*),n_7:n(10*),n_8:n(10*),n_9:n(10*),n_10:n(10)";
                        oFile.dsTmpl(this.channel, strTemp);
                        break;
                    case "WPSCAN":
                        strTemp = "number:c(10),id:c(10),teacher:c(30),student:c(30),Reserved:c(19),";
                        strTemp += "access_code:c(12),reserved_1:c(188*),";
                        strTemp += "no_items:n(10*),no_boxes:n(10*),n_2:n(10*),n_3:n(10*),n_4:n(10*),n_5:n(10*),";
                        strTemp += "date:n(10*):date=jul:,time:n(10*),n_8:n(10*),n_9:n(10*),n_10:n(10)"; ;
                        oFile.dsTmpl(this.channel, strTemp);
                        break;
                    case "INBOXSZ":
                        strTemp = "BoxNumber:c(2*),Length:n(10*),Width:n(10*),Height:n(10*),Reserved:n(10*)"; 
                        oFile.dsTmpl(this.channel, strTemp);
                        break;
                    case "INPRIZ":
                        strTemp = "brochure_id:c(10*),product_id:c(10*),break_level:n(10*),break_level_d:n(10*)";
                        oFile.dsTmpl(this.channel, strTemp);
                        break;
                    case "ORDER":
                        break;
                    case "":
                        strTemp = "id:c(10*),product_id:c(10*)";
                        oFile.dsTmpl(this.channel, strTemp);
                        break;
                        
                }
				//Start at first record
				oFile.dsReadFld(channel,"", 0,"",ref arrValues);
				return true;
			


		}
        public void goStart()
		{
			this.oFile.dsReadFld(this.channel,"", 0,"",ref arrValues);
		}
        public bool Read(String Key, String sFields)
        {
            this.sKey = Key;
            
            String[] Fields = sFields.Split(',');
            System.Array arrValues = new System.String[Fields.GetLength(0) + 2];

            this.err = oFile.dsReadFld(this.channel, this.sKey, 0, sFields, ref arrValues);
            if (this.err == 11)
            {
                this.Error = this.err.ToString();
                return false;
            }

            this.arrValues = arrValues;
            return true;
            
        }
        public bool Write(String Key, String sFields, String sValues)
        {
            String Record = new string(' ', 1000);
            String[] Fields = sFields.Split(',');
            String[] Values = sValues.Split('|');
            System.Array arrValues = new System.String[Fields.GetLength(0) + 1];

            
            this.sKey = Key;

            
            int i=0;
            foreach (String f in Fields)
            {
                arrValues.SetValue(Values.GetValue(i).ToString(), i);
                i++;
            }

            

            err = oFile.dsExtractRec(this.channel, this.sKey, 0, ref Record);
            if (err != -1)
            {
                if (err == 11)
                    Record = "";
                else
                {
                    this.Error = err.ToString();
                    return false;
                }

            }

            err = oFile.dsWriteFld(this.channel, this.sKey, Record, sFields, ref arrValues);
            if (err != -1)
            {   
                this.Error ="err=" + err.ToString() + "  Lenght: " + Record.Length.ToString();
                return false;
            }

            return true;
        }
        public bool ReadNext(String sFields)
		{
            String[] Fields = sFields.Split(',');
            System.Array arrValues = new System.String[Fields.GetLength(0)+2];
         
            
            do
            {
                this.err = oFile.dsReadFldNext(this.channel, sFields, ref this.sKey, ref arrValues);
            }
            while (this.err == 0);

            if (this.err == 2)
                return false;
            
            if (this.err != -1)
            {
                this.Error = this.err.ToString();
                return false;
            }
            this.arrValues = arrValues;
			return true;
		}
        public String GetValue(short  i)
        {
            return this.arrValues.GetValue(i).ToString();
        }
        public void SetKey(String str)
		{
			this.sKey = str;
			return;
		}
        public String GetKey()
		{
			return this.sKey ;
		}
        public bool isEOF()
		{
			//oFile.dsGetKey(channel,ref sKey);
			//if (sKey == null)
            if (this.err == 2)
				return true;
			return false;
		}
		public void Close()
		{
			oFile.dsClose(channel);
		}
		public String read_record()
		{
			String Record = new string(' ',200);
			int err = oFile.dsReadRec(channel,sKey,0,ref Record);
			if (err!=-1)
			{	
				if (err==11)
					return "";
				else
				{
                    this.Error = err.ToString(); 
					return "";
				}
			}
			return Record;
		}
        public bool Remove(String Key)
        {
            this.sKey = Key;
            return this.Remove();
        }
		public bool Remove()
		{
            int err = oFile.dsRemoveRec(this.channel,this.sKey);
			if (err==11)
				return false;
			else
				return true;
			
		}
		public void Disconnect()
		{
			// Closing connections
				oFile.dsDisconnect();
				return;

		}


		private String cv_string(String sStr)
		{
		
			//sStr = sStr.Replace("'","\'");
			sStr = sStr.Replace("\"","'");
			sStr = sStr.Replace("\\","\\\\");
			return(sStr);
		}
		private String cv_date(String sStr)
		{
			
			if (sStr.Length > 5)
			{	
				DateTime d_ship;
				d_ship =new DateTime(2000+Convert.ToInt16(sStr.Substring(6,2)),Convert.ToInt16(sStr.Substring(0,2)),Convert.ToInt16(sStr.Substring(3,2)));
				sStr = "'"+d_ship.ToString("yyyy-MM-dd")+"'";
			}
			else
				sStr = "null";
			
			return sStr;

		}

        public String Template
        {
            get { return fTemplate; }


        }
	


	}

}
