using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;


namespace Signature.Classes
{
    public class ScannedImages
    {
        private Signature.Data.MySQL oMySql = new Signature.Data.MySQL();

        public clsBatches Batches = new clsBatches();  //Customer Contains several batches
        
        

        // Properties
        public String ID;
        private String _CompanyID;
        private String _CustomerID;
        
        
        public Customer oCustomer;
        public Company oCompany = new Company();

        //Methods

        public ScannedImages()
        {
            oCustomer =  new Customer(oCompany.ID);
            _CompanyID = oCompany.ID;

        } //Constructor

        public bool Find(String CompanyID, String CustomerID, String Teacher)
        {
            
            this._CompanyID = CompanyID;
            this._CustomerID = CustomerID;


            if (CompanyID == "" || CustomerID == "")
                return false;

                        
            DataView Rows = this.oMySql.GetDataView("Select * From scanned_images Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' And Teacher='" + Teacher + "'", "scanned");
            

            if (Rows == null)
            {
                return false;
            }
            
            foreach(DataRow Row in Batches)
            {
                
            }
            
            //Batches.Add(Rows["BatchNumber"].ToString(), 

            

            return true;
        
        }
        public bool Find(String BatchID)
        {
            this.ID = "";
            

            if (_CompanyID == "" || _CustomerID == "")
                return false;


            DataView Rows = this.oMySql.GetDataView("Select * From scanned_images Where CompanyID='" + _CompanyID + "' and CustomerID='" + _CustomerID + "' And BatchID='"+BatchID+"'", "scanned");


            if (Rows == null)
            {
                
                this.ID = "";

                return false;
            }
            
            
            return true;

        }
        public bool View(String CompanyID, String CustomerID, String Teacher)
        {
            frmViewScannedImages oView = new frmViewScannedImages(CompanyID, CustomerID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                this.ID = oView.sSelectedID;
                return true;
            }
            return false;

        }
        public void Save()
        {
        }
       
        public void Fill(System.Windows.Forms.ComboBox Combo)
        {

        }

    }
    public class Batch //Each batch contains several images
    {
        private Signature.Data.MySQL oMySql = new Signature.Data.MySQL();

        public int _ID;
        private String _CompanyID;
        private String _CustomerID;
        public int _ImageInitial;
        public int _ImageFinal;
        public int _NumberImages;
        public DateTime _StartDate;
        public DateTime _EndDate;
        private String _Teacher;



        public bool Find(String CompanyID, String CustomerID, String Teacher)
        {

            this._CompanyID = CompanyID;
            this._CustomerID = CustomerID;
            

            if (CompanyID == "" || CustomerID == "")
                return false;

            //MessageBox.Show("Select * From scanned_images Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and BatchID='" + BatchNumber + "'");
            DataRow Row = oMySql.GetDataRow("Select * From scanned_images Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and Teacher='" + Teacher + "'", "scanned");

            if (Row == null)
            {
                
                if (MessageBox.Show("Is this a new teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {

                    this._ID = 0;
                    return false;
                }
                else
                {
                    
                    String Sql = String.Format("Insert into scanned_images (CompanyID, CustomerID, Teacher) Values (\"{0}\",\"{1}\",\"{2}\")",
				            CompanyID,CustomerID,Teacher);
                    
                    _ID = oMySql.exec_sql_id(Sql);
                    _CompanyID = CompanyID;
                    _CustomerID = CustomerID;
                    _Teacher = Teacher;
                    return true;
                }

            }

            _ID = (int)Row["BatchID"];
            _CompanyID = Row["CompanyID"].ToString();
            _CustomerID = Row["CustomerID"].ToString();
            _ImageInitial =  Convert.ToInt32(Row["StartImage"].ToString());
            _ImageFinal = Convert.ToInt32(Row["EndImage"].ToString());
            _NumberImages = Convert.ToInt32(Row["NumberImages"].ToString());
            _Teacher = Row["Teacher"].ToString();

            //_StartDate      =
            //_EndDate        =

            return true;

        }

        public bool Find(String CompanyID, String CustomerID, int BatchNumber)
        {

            this._CompanyID = CompanyID;
            this._CustomerID = CustomerID;


            if (CompanyID == "" || CustomerID == "")
                return false;

            //MessageBox.Show("Select * From scanned_images Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and BatchID='" + BatchNumber + "'");
            DataRow Row = oMySql.GetDataRow("Select * From scanned_images Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and BatchID='" + BatchNumber + "'", "scanned");


            if (Row == null)
            {
                _ID = 0;
                return false;
            
            }

            _ID             = (int)Row["BatchID"];
            _CompanyID      = Row["CompanyID"].ToString();
            _CustomerID     = Row["CustomerID"].ToString();
            _ImageInitial   = (int)Row["StartImage"];
            _ImageFinal     = (int)Row["EndImage"];
            _NumberImages   = (int)Row["NumberImages"];
            _Teacher        = Row["Teacher"].ToString();

            //_StartDate      =
            //_EndDate        =

            return true;

        }
        public bool Find(String BatchID)
        {
            this._ID = 0;


            if (_CompanyID == "" || _CustomerID == "")
                return false;


            DataRow Row = this.oMySql.GetDataRow("Select * From scanned_images Where BatchID='" + BatchID + "'", "scanned");

            if (Row == null)
            {
                
                this._ID = 0;

                return false;
            }
            
            
            _ID = (int) Row["BatchID"];
            _CompanyID = Row["CompanyID"].ToString();
            _CustomerID = Row["CustomerID"].ToString();
            _ImageInitial = (int)Row["StartImage"];
            _ImageFinal = (int)Row["EndImage"];
            _NumberImages = (int)Row["NumberImages"];
            _Teacher = Row["Teacher"].ToString();

            return true;

        }
        public bool View(String CompanyID, String CustomerID)
        {
            frmViewScannedImages oView = new frmViewScannedImages(CompanyID, CustomerID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;

        }
        public void Save()
        {

            int i = 0;
            String Sql = "";

            //if (!this.exist_record("Select count(*) from Customer Where CustomerID='"+arrValues.GetValue(0)+"' And CompanyID='"+sCompanyID+"'"))

            if ((i = oMySql.exec_sql_no("Select count(*) from scanned_images Where CustomerID='" + _CustomerID + "' And CompanyID='" + _CompanyID + "' And BatchID='" + _ID + "'")) == 0)
            {

                Sql = String.Format("Insert into scanned_images (CompanyID, CustomerID, StartImage, EndImage , StartDate, EndDate, NumberImages, Teacher) Values ('{0}',\"{1}\",\"{2}\",\"{3}\",{4},{5},{6},\"{7}\")",
                    _CompanyID, _CustomerID, _ImageInitial.ToString(), _ImageFinal.ToString(), "NOW() ", "NOW() ", _NumberImages.ToString(), _Teacher);
                oMySql.exec_sql(Sql);
            }
            else
            {

                Sql = String.Format("Update scanned_images  Set CompanyID='{0}', CustomerID='{1}', StartImage='{2}', EndImage='{3}' , EndDate='{4}', NumberImages='{5}', Teacher='{6}' Where CompanyID='" + _CompanyID + "' And CustomerID='" + _CustomerID + "' And BatchID='" + _ID + "'",
                    _CompanyID, _CustomerID, _ImageInitial.ToString(), _ImageFinal.ToString(), _EndDate.ToString("yyyy-MM-dd hh:mm:ss"), _NumberImages.ToString(), Teacher);
                //  MessageBox.Show(Sql);
                oMySql.exec_sql(Sql);

            }

        }
        public String CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }
        public String CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public String Teacher
        {
            get { return _Teacher; }
            set { _Teacher = value; }
        }

        public class Images : Hashlist
        {
            public String Directory;


           /* public class Image
            {
                
                String Processed;

            }*/

            public new Image this[string Key]
            {
                get { return (Image)base[Key]; }

            }
            public new Image this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Image)oTemp;
                }
            }
            new public IEnumerator GetEnumerator()
            {
                return new ImagesEnumerator(this);
            }

        }
        public class ImagesEnumerator : IEnumerator
        {
            public ImagesEnumerator(Images ar)
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
            protected Images _ar;


        }




    }

    public class clsBatches : Hashlist
    {
        public clsBatches()
        {

        }
        public new Batch this[string Key]
        {
            get { return (Batch)base[Key]; }

        }
        public new Batch this[int index]
        {
            get
            {
                object oTemp = base[index];
                return (Batch)oTemp;
            }
        }


        // Expose the enumerator for the associative array.
        public new IEnumerator GetEnumerator()
        {
            return new BatchesEnumerator(this);
        }
    }  //Customer contains Several Batches.

    public class BatchesEnumerator : IEnumerator
    {
        public BatchesEnumerator(clsBatches ar)
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
        protected clsBatches _ar;


    }
}
