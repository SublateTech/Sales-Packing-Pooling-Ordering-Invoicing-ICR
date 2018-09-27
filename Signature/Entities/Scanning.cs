using System;
using System.Collections;
using System.Text;
using Signature.Data;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using Signature.Reports;



namespace Signature.Classes
{
    public class Scanning:Order 
    {
       
        public int NumberPallets = 0;
        public _ScanItems ScanItems = new _ScanItems();
        public DataView tOrders = new DataView();
        public new Int32 BoxesScanned = 0;
        public Boolean isScanned = false;
        
        public Scanning(String CompanyID):base(CompanyID) 
        {
            this.CompanyID = CompanyID;
        }

        new public bool View()
        {
            frmViewNoScanned oView = new frmViewNoScanned(CompanyID,CustomerID);
            
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                FindHeader(Convert.ToInt32(ID));
                return true;
            }
            return false;
        }
        
        

        public void UpdateScanned(String ID, int BoxesScanned, int BoxesPacked, String PackID)
        {
            if (BoxesScanned == BoxesPacked)
                isScanned = true;
            else
                isScanned = false;

            oMySql.exec_sql(String.Format("Update OrderByLine Set BoxesScanned='{0}', Scanned='{1}' Where OrderID='{2}' And PackID='{3}'", BoxesScanned, isScanned ? '1' : '0', ID.ToString(), PackID));
                

            if (Lines.Count == 1)
            {

                UpdateScanned(ID, BoxesScanned,isScanned);
                return;
            }
            else
            {
                Lines.Load(this);
                isScanned = true;
                this.BoxesScanned = 0;
                foreach (Order.PackByOrder oOB_1 in Lines)
                {
                    this.BoxesScanned += oOB_1.BoxesScanned;
                    if (!oOB_1.Scanned)
                        isScanned = false;
                }
                UpdateScanned(ID, BoxesScanned, isScanned);
                return;

            }
            
            
        }

        public void UpdateScanned(String ID, int BoxesScanned, Boolean isScanned)
        {
            oMySql.exec_sql(String.Format("Update Orders Set BoxesScanned='{0}', Scanned='{1}' Where ID={2}", BoxesScanned, isScanned ? "1" : "0", ID.ToString()));
        }

        

    
        public void UpdateCustomerScanned()
        {
            oMySql.exec_sql(String.Format("Update Customer  Set Scanned='{0}', NumberPallets='{1}' Where CustomerID='{2}'", 1, NumberPallets, CustomerID));
        }

        

        public new bool FindHeader(Int32 OrderID)
        {
            DataRow rOrder = this.oMySql.GetDataRow("Select * From Orders Where ID='" + OrderID.ToString() + "'", "Tmp");

            if (rOrder == null)
            {
                ID = "0";
                return false;
            }

            this.Clear();

            this.LoadHeader(rOrder);
            return true;
        }
        
        public int OrdersPacked
        {
            get     
            {
                return oMySql.exec_sql_no(String.Format("SELECT count(*) FROM Orders o Left Join  OrderByLine ol On o.ID=ol.OrderID  Where o.CompanyID='{0}' And CustomerID='{1}' And ol.PackID='{2}'  And ol.Packed = '1'  And o.Teacher NOT Like '%A INTERNET%'", Global.CurrrentCompany, this.CustomerID, Global.CurrrentLine));
            }
        }
        public int OrdersScanned
        {
            get
            {
                return oMySql.exec_sql_no(String.Format("SELECT count(*) FROM Orders o Left Join  OrderByLine ol On o.ID=ol.OrderID  Where o.CompanyID='{0}' And CustomerID='{1}' And ol.PackID='{2}'  And ol.Scanned = '1'  And o.Teacher NOT Like '%A INTERNET%'", Global.CurrrentCompany, this.CustomerID, Global.CurrrentLine));
            }
        }
        
        public new int OrdersEntered
        {
            get
            {
                return oMySql.exec_sql_no(String.Format("SELECT count(*) FROM Orders o Left Join  OrderByLine ol On o.ID=ol.OrderID  Where o.CompanyID='{0}' And CustomerID='{1}' And ol.PackID='{2}'  And o.Teacher NOT Like '%A INTERNET%'", Global.CurrrentCompany, this.CustomerID, Global.CurrrentLine));
            }
        }

        public  class ScanItem               //Single instance of detail
        {
            public String _OrderID;
            public String CompanyID;
            public String CustomerID;
            public String _Teacher;
            public String _Student;
            //private Int32 _Boxes;
            private Int32 _Packed;
            private Int32 _Scanned;

            Signature.Data.MySQL oMySql = Global.oMySql;

            public ScanItem()
            {
                CompanyID = "";
                CustomerID = "";
                Teacher = "";
                Student = "";
              //  _Boxes = 0;
                _Scanned = 0;
                _Packed = 0;
             
            
            }
            public void Save()
            {
                if (if_exist())
                    Update();
                else
                    Insert();

            }
            public void Update()
            {

          /*      String Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID={5}" + " Where CompanyID=\"" + this.CompanyID + "\"" + " And CustomerID=\"" + this.CustomerID + "\"" + " And OrderID=\"" + this.OrderID + "\"" + " And ProductID=\"" + this.ProductID + "\"",
                    this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.OrderID);
                oMySql.exec_sql_afected(Sql);
                */
            }
            public void Insert()
            {
                /*

                String Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID, Reserved, OrderID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','0',{9})",
                    this.Teacher, this.Student, this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.CustomerID, this.CompanyID, this.OrderID);
                oMySql.exec_sql_afected(Sql);
                */
            }
            public void Delete()
            {
            /*    String Sql = "Delete from OrderDetail where CompanyID='" + CompanyID + "' And CustomerID = '" + CustomerID + "' And ProductID = '" + ProductID + "'";
                oMySql.exec_sql(Sql);*/
            }
            public bool if_exist()
            {
              /*  if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where OrderID=" + this.OrderID + " And ProductID='" + this.ProductID + "'") == 0)
                {
                    return false;
                }*/
                return true;
            }
            
            public int Packed
            {
                get { return _Packed; }


                set
                {
                    _Packed = value;
                }
            }
            public Int32 Scanned
            {
                get { return _Scanned; }


                set
                {
                    _Scanned = value;
                }
            }
            public String Teacher
            {
                get { return _Teacher; }


                set
                {
                    _Teacher = value;
                }
            }
            public String Student
            {
                get { return _Student; }


                set
                {
                    _Student = value;
                }
            }
            public String OrderID
            {
                get { return _OrderID; }


                set
                {
                    _OrderID = value;
                }
            }
            
        }
        public class _ScanItems : Hashlist //, IList
        {
            /* Hash List Support */
            public new ScanItem this[string Key]
            {
                get { return (ScanItem)base[Key]; }

            }
            public new ScanItem this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (ScanItem)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new ScanItemsEnumerator(this);
            }
        }
        public class ScanItemsEnumerator : IEnumerator
        {
            public ScanItemsEnumerator(_ScanItems ar)
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
            protected _ScanItems _ar;


        }

    }

    

    
}
