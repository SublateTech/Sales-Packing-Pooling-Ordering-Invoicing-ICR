using System;
using System.Collections;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using Signature.Communications;


namespace Signature.Classes
{
    public class GA_Giftco
    {
        private Signature.Data.MySQL oMySql = Global.oMySql;
        
        // Properties
        public String _ID;
        public  String _SFOrder;
        public String _RecordType;
        public String _SFSalesRepNumber;
        public String _SFSalesRepName;
        public String _SFAccountNumber;
        public String _CustomerPONumber;
        public DateTime _OrderDate;
        public DateTime _RequestedShipDate;
        public DateTime _CancelDeliveryDate;
        public String _OrderType;
        public String _ProgramName;
        public String _ShipVia;
        public String _ShipToName;
        public String _ShipToAddress1;
        public String _ShipToAddress2; 
        public String _ShipToCity;
        public String _ShipToState;
        public String _ShipToZipCode;
        public String _HotRush;

        //Detail

        public struct _Item
        {
            public String SFOrder;
            public String RecordType;
            public String ProductID;
            public String Giftco_ItemNumber;
            public String Price;
            public String Quantity;
            public String SpecialInstructions;

        }

        /*struct _Commnent
        {
            public String SFOrder;
            public String RecordType;
            public String Comment;
        }*/

     /*   struct _Student
        {
            public String SFOrder;
            public String RecordType;
            public String ClassroomCode;
            public String ClassroomName;
            public String ClassroomLeaderName;
            public String StudentNumber;
            public String StudentName;
            public String ItemNumber;
            public String GiftcoItemNumber;
            public String Quantity;

        }*/


        public _Items Items;
        public String CompanyID;
        public String _KitID;


        //Methods

        public GA_Giftco(String CompanyID)
        {
            Items = new _Items();
            this.CompanyID = CompanyID;
        } //Constructor

        public void CreateTransmissionFile(String FileName)
        {
            string path = FileName; //Path.GetTempFileName();
            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            
            String  Header_Record  = FormatField(_SFOrder,6);
            Header_Record += FormatField(_RecordType,6);
            Header_Record += FormatField(_SFAccountNumber,8);
            Header_Record += FormatField(_SFSalesRepNumber, 3);
            Header_Record += FormatField(_SFSalesRepName,25);
            Header_Record += FormatField(_CustomerPONumber, 11);
            Header_Record += FormatField(_OrderDate.ToString("MM/dd/yy"), 8);
            Header_Record += FormatField(_RequestedShipDate.ToString("MM/dd/yy"), 8);
            Header_Record += FormatField(_CancelDeliveryDate.ToString("MM/dd/yy"), 8);
            Header_Record += FormatField(_OrderType, 15);
            Header_Record += FormatField(_ProgramName, 15);
            Header_Record += FormatField(_ShipVia, 15);
            Header_Record += FormatField(_ShipToName, 25);
            Header_Record += FormatField(_ShipToAddress1, 25);
            Header_Record += FormatField(_ShipToAddress2, 25);
            Header_Record += FormatField(_ShipToCity, 20);
            Header_Record += FormatField(_ShipToState, 2);
            Header_Record += FormatField(_ShipToZipCode, 10);
            Header_Record += FormatField(_HotRush, 1);
            Header_Record += FormatField("637977", 8); //_RequestedShipDate.ToString(), 8);
            Header_Record += "\r\n";

            Byte[] info = new UTF8Encoding(true).GetBytes(Header_Record);

            fs.Write(info, 0, info.Length);

            foreach(_Item Item in Items)
            {
                String Detail_Record = "";
                Detail_Record += FormatField(Item.SFOrder,6);
                Detail_Record += FormatField(Item.RecordType, 3);
                Detail_Record += FormatField(Item.ProductID,10);
                Detail_Record += FormatField(Item.Giftco_ItemNumber, 8);
                Detail_Record += FormatField(Item.Price, 8);
                Detail_Record += FormatField(Item.Quantity, 8);
                Detail_Record += FormatField(Item.SpecialInstructions, 35);
                Detail_Record += "\r\n";

                info = new UTF8Encoding(true).GetBytes(Detail_Record);

                fs.Write(info, 0, info.Length);
            }

            fs.Close();
        }
        public void SendFTPFile(String FileName)
        {
            

            FTP.FTPPlumbing.Timeout = 30000;
            
            FTP oFTP = new Signature.Communications.FTP();
            oFTP.Connect("69.214.67.194", "sigfund", "sigfund1"); //mail.giftcoinc.com
            
            oFTP.Files.Upload(FileName);
            while (!oFTP.Files.UploadComplete)
                {
                Console.WriteLine("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
                }

            Console.WriteLine("Upload Complete: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());

            
            oFTP.Disconnect();
            
            
        }

        public String FormatField(String Field, int Len)
        {
            return Field.PadRight(Len).Substring(0,Len)+"\t";

        }
        
        public bool Find(String BoxID)
        {
            //Header

            DataRow rBox = this.oMySql.GetDataRow("Select * From ga_box Where ID='" + BoxID + "'", "box");

            if (rBox == null)
            {
                return false;
            }

            //this.Clear();

            //Header
            
            //this._CompanyID = rBox["CompanyID"].ToString();
            //this._Description = rBox["Description"].ToString();

            //Items.Clear();

           /* //DataView tDetail = oMySql.GetDataView("Select ProductID, Description, Price  From Product  Where CompanyID=." + _CompanyID + "'", "TMP");
            foreach (DataRow Row in tDetail.Table.Rows)
            {
                Product _Item = new Product(_CompanyID);

                _Item.ID = Row["ProductID"].ToString();
                _Item.Price = (Double)Row["Price"];
                _Item.Description = Row["Description"].ToString();

                Items.Add(Row["ProductID"].ToString(), _Item);

            }*/

            return true;
        }
        public bool View()
        {
        	frmProductView oView = new frmProductView(this.CompanyID);
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				return true;
				
			}
            return false;
		
        }
        public void Save()
        {
        }
        public void Update()
        {
        }
        
        
        #region Classes & Enumerators
        public class _Items : Hashlist //, IList
        {
           /* Hash List Support */
            public new _Item this[string Key]
            {
                get { return (_Item)base[Key]; }

            }
            public new _Item this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (_Item)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            public new IEnumerator GetEnumerator()
            {
                return new ItemsEnumerator(this);
            }
        }
        public class ItemsEnumerator : IEnumerator
        {
            public ItemsEnumerator(_Items ar)
            {
                _ar = ar;
                _currIndex = -1;
            }
            public object Current
            {
                get
                {
                    return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                }
            }
            public bool MoveNext()
            {
                _currIndex++;
                if (_currIndex == _ar.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _currIndex = -1;
            }

            // The index of the item this enumerator applies to.
            protected int _currIndex;
            // A reference to this enumerator's associative array.
            protected _Items _ar;


        }
        #endregion

    }

}
