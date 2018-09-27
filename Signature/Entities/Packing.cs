using System;
using System.Collections;
using System.Text;
using Signature.Data;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Signature.Forms;


namespace Signature.Classes
{
    public class Packing : Order
    {
  
        new public DateTime Date;
        //public Int32 OrderID;
        public LinePrint oPrint;
        public int CurPage = 0;
        public _ScanItems ScanItems = new _ScanItems();

        public Int32 PackedItems = 0;
        public Int32 PackedOrders = 0;
        public Int32 PackedBoxes = 0;
        public String PackID;
        public Int32 LocalItems = 0;
        
        public new Int32 BoxesPacked = 0;

       
        public Packing(String CompanyID) : base(CompanyID)
        {
            this.CompanyID = CompanyID;
            oPrize = new Prize(this.CompanyID);
        }

        public override bool Find(int OrderID, string PackID)
        {
            //Header
            if (!FindHeader(OrderID))
                return false;

            //Detail
            //Detail.Clear();
            Items.Clear();
            LocalItems = 0;

            DataView tDetail = new DataView();
            if (PackID != "0" && PackID != "")
            {   
                tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Where OrderID='" + ID + "' And PackID='"+PackID+"'", "Detail");
                //tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Left Join Card c On d.CompanyID=c.CompanyID And d.ProductID=c.ProductID  Where OrderID='" + ID + "' And PackID='" + PackID + "' And c.ProductID is null", "Detail");
            }else
            {
                tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Where OrderID='" + ID + "'", "Detail");
            }
            

            foreach (DataRow Row in tDetail.Table.Rows)
            {

                ScanItem Detail = new ScanItem();

                Detail.Description = Row["Description"].ToString();

                Detail.CompanyID = CompanyID;
                Detail.CustomerID = CustomerID;
                Detail.ProductID = Row["ProductID"].ToString();
                Detail.Packed = Row["ProductID"].ToString();
                Detail.Quantity = (int)Row["Quantity"];
                Detail.Description = Row["Description"].ToString();
                Detail.BarCode = Row["BarCode"].ToString(); //Row["ProductID"].ToString();
                Detail.Scanned = 0;
                Detail.InvCode = Row["InvCode"].ToString();
                Detail.BarCode2 = Row["BarCode_2"].ToString();
                Detail.BarCode3 = Row["BarCode_3"].ToString();

                if (Detail.BarCode.Trim() == "")
                {
                    Global.ShowNotifier("This Product doesn't have BarCode : " + Row["ProductID"].ToString());
                    ScanItems.Add(Row["ProductID"].ToString(), Detail);
                }
                else if (ScanItems.Contains(Detail.BarCode))
                {
                    Global.ShowNotifier("This BarCode is already in this order: " + Row["ProductID"].ToString());
                    ScanItems.Add(Row["ProductID"].ToString(), Detail);
                }
                else
                    ScanItems.Add(Row["BarCode"].ToString(), Detail);

                LocalItems += Detail.Quantity;

            }
            oPrize.Find(oCustomer.PrizeID);
            if (oPrize.PackID != PackID)
                return true;

            
                DataView dvPrizes = oPrize.GetItems(oCustomer.PrizeID, NoItems);

                foreach (DataRow Row in dvPrizes.Table.Rows)
                {
                    if (!((Boolean) Row["IsCompound"]))
                    {
                        ScanItem Detail = new ScanItem();

                        Detail.Description = Row["Description"].ToString();
                        Detail.CompanyID = CompanyID;
                        Detail.CustomerID = CustomerID;
                        Detail.ProductID = Row["ProductID"].ToString();
                        //Detail.Packed = Row["ProductID"].ToString();
                        Detail.Quantity = Convert.ToInt32(Row["Quantity"].ToString());
                        Detail.BarCode = Row["BarCode"].ToString(); //Row["ProductID"].ToString();
                        Detail.BarCode2 = Row["BarCode_2"].ToString();
                        Detail.BarCode3 = Row["BarCode_3"].ToString();
                        Detail.InvCode = Row["InvCode"].ToString();
                        Detail.Scanned = 0;
                        if (Detail.BarCode.Trim() == "")
                        {
                            Global.ShowNotifier("This Product doesn't have BarCode : " + Row["ProductID"].ToString());
                            ScanItems.Add(Row["ProductID"].ToString(), Detail);
                        }
                        else if (ScanItems.Contains(Detail.BarCode))
                        {
                            Global.ShowNotifier("This BarCode is already in this order: " + Row["ProductID"].ToString());
                            ScanItems.Add(Row["ProductID"].ToString(), Detail);
                        }
                        else
                            ScanItems.Add(Row["BarCode"].ToString(), Detail);

                        LocalItems += Detail.Quantity;
                    }
                    else
                    {
                        //Prizes compound products
                        
                        DataView dvCompoundPrizes = this.oProduct.Items.GetTable(Row["ProductID"].ToString());
                        foreach (DataRow row in dvCompoundPrizes.Table.Rows)
                        {

                            ScanItem _Detail = new ScanItem();

                            _Detail.Description = row["Description"].ToString();
                            _Detail.CompanyID = CompanyID;
                            _Detail.CustomerID = CustomerID;
                            _Detail.ProductID = row["ProductID"].ToString();
                            //Detail.Packed = Row["ProductID"].ToString();
                            _Detail.Quantity = 1;
                            _Detail.BarCode = row["BarCode"].ToString(); //Row["ProductID"].ToString();
                            _Detail.BarCode2 = row["BarCode_2"].ToString();
                            _Detail.BarCode3 = row["BarCode_3"].ToString();
                            _Detail.InvCode = row["InvCode"].ToString();
                            _Detail.Scanned = 0;
                            if (_Detail.BarCode.Trim() == "")
                            {
                                Global.ShowNotifier("This Product doesn't have BarCode : " + row["ProductID"].ToString());
                                ScanItems.Add(row["ProductID"].ToString(), _Detail);
                            }
                            else if (ScanItems.Contains(_Detail.BarCode))
                            {
                                Global.ShowNotifier("This BarCode is already in this order: " + row["ProductID"].ToString());
                                ScanItems.Add(row["ProductID"].ToString(), _Detail);
                            }
                            else
                                ScanItems.Add(row["BarCode"].ToString(), _Detail);

                            LocalItems += _Detail.Quantity;
                        }
                    }
                }
            return true;
        }

        public override bool Find(Int32 OrderID)
        {
            return Find(OrderID, ""); 
        }

        public bool IfDone()
        {
            bool Done=true;
            foreach (ScanItem Row in ScanItems)
            {
                if (Row.Quantity > Row.Scanned)
                {
                    Done = false;
                    break;
                }

            }
            return Done;
        }
        public String GetItem(String ProductID)
        {
            foreach (ScanItem Row in ScanItems)
            {
                if (Row.ProductID == ProductID)
                {
                    if (Row.BarCode == "")
                        return Row.ProductID;
                    else
                        return Row.BarCode;
                    
                }

            }
            return "";
        }
        public String GetSecondaryBarcode(String Barcode)
        {
            foreach (ScanItem _Item in ScanItems)
            {
                if (Barcode == _Item.BarCode2 || Barcode == _Item.BarCode3)
                {
                    return _Item.BarCode;
                }
            }
            return "";
        }
        public bool IfPacked()
        {
            /*
            if (this.BrochureID == "")
            {
                if (oMySql.exec_sql_no("Select count(*) from Orders Where ID='" + this.ID.ToString() + "' And Packed='1'") == 0)
                {
                    return false;
                }
            }
            else
            {
                if (oMySql.exec_sql_no("Select count(*) from OrderByBrochure Where OrderID='" + this.ID.ToString() + "' And BrochureID='"+this.BrochureID+"' And Packed ='1'") == 0)
                {
                    return false;
                }
            }
            */
            return true;
        }

        public void UpdatePacked(Boolean IsPacked)
        {
            oMySql.exec_sql(String.Format("Update Orders Set Packed={0},BoxesPacked='{1}',PackedDate=NOW() Where ID='{2}'", IsPacked?1:0,BoxesPacked, ID.ToString()));
            String LastPacker = this.Packer;
            if (LastPacker == "")
                InsertOrderActivity(OrderProcess.Packing);
            else
                InsertOrderActivity(OrderProcess.Packing,LastPacker);

        }

        public void UpdatePacked(Boolean IsPacked, String PackID)
        {
            
            Order.PackByOrder oOB = new PackByOrder();
            oOB.CompanyID = this.CompanyID;
            oOB.OrderID     = Convert.ToInt32(ID);
            oOB.PackID      = PackID;
            oOB.BoxesPacked = this.BoxesPacked;
            oOB.Items       = this.LocalItems;
            oOB.Packed      = IsPacked;
            oOB.Packer      = Global.CurrentUser;
            oOB.Save();
            if (Lines.Count == 1)
            {
                
                UpdatePacked(IsPacked);
                return;
            }
            else
            {
                Lines.Load(this);
                this.BoxesPacked = 0;
                foreach (Order.PackByOrder oOB_1 in Lines)
                {
                    this.BoxesPacked += oOB_1.BoxesPacked;
                    if (!oOB_1.Packed)
                        IsPacked = false;
                }
                UpdatePacked(IsPacked);
                return;
                
            }
           
        }

        public String Packer
        {
             get
            {
                DataRow rPayment = oMySql.GetDataRow(String.Format("Select User FROM OrderActivity  Where CompanyID='{0}' And OrderID='{1}' And Process='Packing'", this.CompanyID, this.ID), "Tmp");
                if (rPayment == null)
                {
                    return "";
                }
                else
                {
                    return rPayment["User"] == DBNull.Value ? "" : rPayment["User"].ToString();
                }
            }
        }

        new virtual public void Clear()
        {
            
            this.Teacher = null;
            this.Student = null;
            this.Date = DateTime.Now;
            this.PackID = "";
        }
        new public void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
        }
        public  bool IfExist()
        {
            if (oMySql.exec_sql_no(String.Format("Select count(*) from Disc_Letter Where OrderID={0}",this.ID)) == 0)
            {
                return false;
            }
            return true;
        }
        new private void Update()
        {
            String Sql = String.Format("Update Disc_Letter  Set  Student=\"{0}\", Teacher=\"{1}\", Date=NOW(), Text=\"{2}\", OrderID={3} Where OrderID={3}",
                   this.Student, this.Teacher, this.BoxesScanned,ID.ToString());
            oMySql.exec_sql_afected(Sql);
        }
        public Boolean GetRankingByUser()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT User, Count(OrderID) as Orders, Sum(Items) as Items, sum(Boxes) as Boxes FROM OrderActivity Where Date(Date)=Date(NOW()) And Process='Packing' And CompanyID='{0}' And User='{1}' Group By User", this.CompanyID, Global.CurrentUser), "Tmp");
            if (row == null)
                return false;
            else
            {
                 this.PackedItems = row["Items"] == DBNull.Value ? 0 : Convert.ToInt32(row["Items"].ToString());
                 this.PackedOrders = row["Orders"] == DBNull.Value ? 0 : Convert.ToInt32(row["Orders"].ToString());
                 this.PackedBoxes = row["Boxes"] == DBNull.Value ? 0 : Convert.ToInt32(row["Boxes"].ToString());
            }
            return true;
        }
        
        public  class ScanItem               //Single instance of detail
        {
            public String OrderID;
            public String CompanyID;
            public String CustomerID;
            public String Teacher;
            public String Student;
            public String _Description;
            public String _ProductID;
            public int _Quantity;
            public int _Scanned;
            public Double Tax;
            public Double _Price;
            public int Seq;
            public int No_Invoiced;
            public Double Length;
            public Double Width;
            public Double Height;
            public String BarCode;
            public String BarCode2;
            public String BarCode3;
            public String _InvCode;
            public String _Packed;

            Signature.Data.MySQL oMySql = Global.oMySql;

            public ScanItem()
            {
                CompanyID = "";
                CustomerID = "";
                Teacher = "";
                Student = "";
                Description = "";
                ProductID = "";
                _Quantity = 0;
                Tax = 0;
                Seq = 0;
                No_Invoiced = 0;
                Length = 0;
                Width = 0;
                Height = 0;
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

                String Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID={5}" + " Where CompanyID=\"" + this.CompanyID + "\"" + " And CustomerID=\"" + this.CustomerID + "\"" + " And OrderID=\"" + this.OrderID + "\"" + " And ProductID=\"" + this.ProductID + "\"",
                    this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.OrderID);
                oMySql.exec_sql_afected(Sql);

            }
            public void Insert()
            {


                String Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID, Reserved, OrderID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','0',{9})",
                    this.Teacher, this.Student, this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.CustomerID, this.CompanyID, this.OrderID);
                oMySql.exec_sql_afected(Sql);

            }
            public void Delete()
            {
                String Sql = "Delete from OrderDetail where CompanyID='" + CompanyID + "' And CustomerID = '" + CustomerID + "' And ProductID = '" + ProductID + "'";
                oMySql.exec_sql(Sql);
            }
            public bool if_exist()
            {
                if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where OrderID=" + this.OrderID + " And ProductID='" + this.ProductID + "'") == 0)
                {
                    return false;
                }
                return true;
            }
            public String Description
            {
                get { return _Description; }


                set
                {
                    _Description = value;
                }
            }
            public String ProductID
            {
                get { return _ProductID; }


                set
                {
                    _ProductID = value;
                }
            }
            public int Quantity
            {
                get { return _Quantity; }


                set
                {
                    _Quantity = value;
                }
            }
            public int Scanned
            {
                get { return _Scanned; }


                set
                {
                    _Scanned = value;
                }
            }
            public String InvCode
            {
                get { return _InvCode; }


                set
                {
                    _InvCode = value;
                }
            }
            public String Packed
            {
                get { return _Packed; }


                set
                {
                    _Packed = value;
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
