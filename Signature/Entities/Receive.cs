using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Data;
using Signature.Reports;



namespace Signature.Classes
{
    public class Receive:Company
    {
        
        
        // Properties
        public new String ID;
        
        public String VendID;
        public int NumberItems;
        public Double Total;
        public String PurchaseID;
        public String Reference;


        public _Items RItems;
        public _Items Items;
       
        //Methods
        public Receive()
        {
            this.CompanyID = base.ID;
            RItems = new _Items();
            Items = new _Items();
        }
        public Receive(String CompanyID)
        {
            this.CompanyID = CompanyID;
            RItems = new _Items();
            Items = new _Items();
        } //Constructor

        public new bool Find(String ReceiveID)
        {
            this.ID = "";


            if (ReceiveID == "")
                return false;

            DataRow row = this.oMySql.GetDataRow("Select * From Receive Where CompanyID='" + CompanyID + "' And  ReceiveID='" + ReceiveID + "'", "Receive");


            if (row == null)
            {
                this.ID = "";
                return false;
            }

            this.ID = row["ReceiveID"].ToString();
            this.Reference = row["Reference"].ToString();
            this.PurchaseID = row["PurchaseID"].ToString();
            
            return true;

        }
        public bool FindPurchase(String PurchaseID)
        {
            this.ID = "";
            
            
            if (PurchaseID == "")
                return false;

            DataRow row = this.oMySql.GetDataRow("Select * From Purchase Where CompanyID='"+CompanyID+"' And  PurchaseID='" + PurchaseID + "'", "Tmp");
            

            if (row == null)
            {

                this.ID = "";
                
                return false;
            }

            this.ID             = row["PurchaseID"].ToString();
            this.VendID         = row["VendorID"].ToString();
            this.NumberItems    = (int)row["Items"];
            this.Total          = (Double)row["Total"];

            this.RItems.RLoad(CompanyID,ID);

            return true;
        
        }
        public override bool View()
        {
            frmReceivesView oView = new frmReceivesView(this.CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                Find(ID);
                return true;

            }
            return false;

        }
        public override void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
            
            RItems.CompanyID = CompanyID;
            RItems.ReceiveID = ID;
            RItems.PurchaseID = PurchaseID;
            if (!RItems.Save())
                Delete();
            Purchase oPurchase = new Purchase(CompanyID);
            oPurchase.Find(PurchaseID);
            oPurchase.UpdateReceiveInventory();
        }
        public override void Update()
        {

            String Sql = String.Format("Update Receive Set Reference='{0}', PurchaseID=\"{1}\", Date=NOW(),CompanyID=\"{2}\"   Where ReceiveID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.Reference, this.PurchaseID, this.CompanyID);
            
            oMySql.exec_sql(Sql);
            
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Receive (CompanyID, PurchaseID, Reference, Date)  Values (\"{0}\",\"{1}\",\"{2}\",NOW())",
                        this.CompanyID, this.PurchaseID, this.Reference);
            this.ID = oMySql.exec_sql_id(Sql).ToString();
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Receive Where ReceiveID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Delete()
        {
            String Sql = "Delete From Receive Where ReceiveID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
        }
        public void Clear()
        {
            ID = "";
            RItems.Clear();

        }
        public void PrintLog()
        {

            frmViewReport oViewReport = new frmViewReport();
            //ReportDocument oRpt=null;
            POReceiptLog oRpt = new POReceiptLog();
            DataSet ds = new DataSet();


            ds.Tables.Add(oMySql.GetDataTable("Select * From Vendor Where CompanyID='" + CompanyID + "'", "Vendor"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Purchase Where CompanyID='" + CompanyID + "' And PurchaseID='" + PurchaseID + "'", "Purchase"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("SELECT pd.PurchaseID, pd.ProductID, p.Description, p.Cost as Price, p.InvCode, pd.cases*p.size+pd.units as Ordered, sum(rd.Quantity) as Received FROM PurchaseDetail pd  Left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Left Join ReceiveDetail rd on pd.CompanyID=rd.CompanyID and pd.ProductID=rd.ProductID and pd.PurchaseID=rd.PurchaseID Where pd.CompanyID = '{0}' And pd.PurchaseID='{1}' Group by pd.ProductID, rd.ProductID", CompanyID, PurchaseID), "Receipt"));
            
            
            foreach (DataRow row in ds.Tables["Receipt"].Rows)
            {
                if (row["Received"] == DBNull.Value)
                    row["Received"] = 0;
            }

            oRpt.SetDataSource(ds);

            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.ShowDialog();
            oRpt.PrintToPrinter(1, true, 1, 100);

            POReceipts oRpt_1 = new POReceipts();
            
            ds.Tables.Remove("Product");
            ds.Tables.Remove("Receipt");
            ds.Tables.Add(oMySql.GetDataTable("Select * From Receive Where CompanyID='" + CompanyID + "' And PurchaseID='" + PurchaseID + "'", "Receipts"));
            //ds.WriteXml("dataset46.xml", XmlWriteMode.WriteSchema);
            oRpt_1.SetDataSource(ds);
            //oViewReport.cReport.ReportSource = oRpt_1;
            //oViewReport.ShowDialog();
            oRpt_1.PrintToPrinter(1, true, 1, 100);
            
            
        }
        public void Print(PrinterDevice Printo,  String PrinterName)
        {
            DataSet ds = this.GetPOReceive(this.CompanyID, this.ID);
            POReceive oRpt = new POReceive();
            frmViewReport oViewReport = new frmViewReport();

            oRpt.SetDataSource(ds);

            //oViewReport.cReport.ReportSource = oRpt;
            //oViewReport.Show();
           //     oRpt.PrintToPrinter(1, true, 1, 100);
            if (Printo == PrinterDevice.Viewer)
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }
            else if (Printo == PrinterDevice.Printer)
            {
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
            }
        }
        public DataTable GetRange(Int32 POFrom, Int32 POTo)
        {
            String Sql = "";

            if (POFrom > 0)
                Sql = String.Format(" And PurchaseID  >= {0}", POFrom);

            if (POTo > 0)
                Sql += String.Format(" And PurchaseID <= {0}", POTo);

            Sql = String.Format("Select ReceiveID From Receive  Where CompanyID='{0}' {1} Order By PurchaseID ", CompanyID, Sql);
            // MessageBox.Show(Sql);
            return oMySql.GetDataTable(Sql, "Tmp");

        }
        public DataSet GetPOReceive(String CompanyID, String ReceiveID)
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * from ReceiveDetail rd Left join Product pr on rd.ProductID=pr.ProductID And rd.CompanyID=pr.CompanyID Left join Receive r on rd.PurchaseID=r.PurchaseID And rd.CompanyID=r.CompanyID And rd.ReceiveID=r.ReceiveID Left join Purchase p on rd.PurchaseID=p.PurchaseID And rd.CompanyID=p.CompanyID Left join Vendor v on p.VendorID=v.VendorID And p.CompanyID=v.CompanyID Where p.CompanyID='{0}' and rd.ReceiveID='{1}'", CompanyID, ReceiveID), "Receive"));
            
            return ds;
        }
        
        #region Classes & Enumerators
        public class _Items : Hashlist 
        {
            
            
            public String PurchaseID;
            public String ReceiveID;
            private DataView CurrentDetail;

            
            public new void Delete()
            {
                String Sql = "Delete from ReceiveDetail where CompanyID='" + CompanyID + "' And ReceiveID = '" + PurchaseID+"' And Updated = 'N'";
                oMySql.exec_sql(Sql);
            }
            public new bool Save()
            {
               // this.BackToInventory(CompanyID);
                bool Flag = false;
                this.Delete();
                foreach (Item _Item in this)
                {
                    if (_Item.ProductID.Trim() == "" || _Item.Received == 0)
                        continue;
                    _Item.PurchaseID = PurchaseID;
                    _Item.CompanyID = CompanyID;
                    _Item.ReceiveID = ReceiveID;
                    _Item.Insert();
                    Flag = true;
                }
                return Flag;
            }
            private void BackToInventory(String CompanyID)
            {
                Product oProduct = new Product(CompanyID);
                if (CurrentDetail != null)
                {
                    foreach (DataRowView row in CurrentDetail)
                    {
                        
                        if (Convert.ToInt32(row["Received"].ToString()) > 0)
                        {
                        oProduct.Find(row["ProductID"].ToString());
                        oProduct.ONPO += Convert.ToInt32(row["Received"].ToString());
                        oProduct.Received -= Convert.ToInt32(row["Received"].ToString());
                        oProduct.UpdateInventory();
                        }
                    }
                }
                return;
            }
            public void RLoad(String CompanyID, String PurchaseID)
            {
                
                Clear();

                
                //tDetail = oMySql.GetDataView(String.Format("SELECT pd.CompanyID, pd.ProductID, p.Description, p.InvCode, p.Cost as Price, p.Size, pd.Cases, pd.Units FROM PurchaseDetail pd left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='{0}' And PurchaseID='{1}'",CompanyID,PurchaseID), "Tmp");

                CurrentDetail = oMySql.GetDataView(String.Format("SELECT pd.PurchaseID, pd.ProductID, p.Description, p.Cost as Price, p.InvCode, pd.cases*p.size+pd.units as Ordered, sum(rd.Quantity) as Received FROM PurchaseDetail pd  Left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Left Join ReceiveDetail rd on pd.CompanyID=rd.CompanyID and pd.ProductID=rd.ProductID and pd.PurchaseID=rd.PurchaseID Where pd.CompanyID = '{0}' And pd.PurchaseID='{1}' Group by pd.ProductID, rd.ProductID", CompanyID, PurchaseID), "Tmp");

          
                foreach (DataRow Row in CurrentDetail.Table.Rows)
                    {

                    Item Detail = new Item();

                    Detail.Description = Row["Description"].ToString();
                    Detail.ProductID = Row["ProductID"].ToString();
                    Detail.InvCode = Row["InvCode"].ToString();
                    //Detail.Cases = (int)Row["Cases"];
                    //MessageBox.Show(Row["Ordered"].ToString());

                    Row["Ordered"] = Row["Ordered"] == DBNull.Value ? 0 : Row["Ordered"];
                    Row["Received"] = Row["Received"] == DBNull.Value ? 0 : Row["Received"];
                    Detail.Ordered = Convert.ToInt32(Row["Ordered"].ToString()) - Convert.ToInt32(Row["Received"].ToString());
                    Detail.Price = (Double)Row["Price"];
                    if (Detail.Ordered > 0)
                        Add(Row["ProductID"].ToString(), Detail);

                    }
                
                
            }

            /* Hash List Support */
            public new Item this[string Key]
            {
                get { return (Item)base[Key]; }

            }
            public new Item this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Item)oTemp;
                }
            }


            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new ItemsEnumerator(this);
            }
        }
        public class Item               //Single instance of detail
        {
            
            public String CompanyID;
            public String CustomerID;
            public String PurchaseID;
            private String _Description;
            private String _ProductID;
            private String _InvCode;
            private Double _Price;
            private int _Ordered;
            private int _Received;
            public String ReceiveID;




            Signature.Data.MySQL oMySql = Global.oMySql;

            public Item()
            {
                CompanyID = "";
                CustomerID = "";
                Description = "";
                ProductID = "";
                
                
                
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

              /*  String Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID={5}" + " Where CompanyID=\"" + this.CompanyID + "\"" + " And CustomerID=\"" + this.CustomerID + "\"" + " And ProductID=\"" + this.ProductID + "\"",
                    this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.OrderID);
                oMySql.exec_sql_afected(Sql);
                */
            }
            public void Insert()
            {
                
                String Sql = String.Format("Insert into ReceiveDetail (CompanyID, ReceiveID, PurchaseID, ProductID, Quantity)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}')",
                    this.CompanyID, this.ReceiveID, this.PurchaseID, this.ProductID, this.Received);
                oMySql.exec_sql_afected(Sql);
                
            }
            public void Delete()
            {
                String Sql = "Delete from OrderDetail where CompanyID='" + CompanyID + "' And CustomerID = '" + CustomerID + "' And ProductID = '" + ProductID + "'";
                oMySql.exec_sql(Sql);
            }
            public bool if_exist()
            {
               /* if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where OrderID=" + this.OrderID + " And ProductID='" + this.ProductID + "'") == 0)
                {
                    return false;
                }*/
                return true;
            }


            public String ProductID
            {
                get { return _ProductID; }


                set
                {
                    _ProductID = value;
                }
            }
            public String Description
            {
                get { return _Description; }

                set
                {
                    _Description = value;
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
            public int Received
            {
                get { return _Received; }


                set
                {
                    _Received = value;
                }
            }
            public int Ordered
            {
                get { return _Ordered; }


                set
                {
                    _Ordered = value;
                }
            }
            public Double Price
            {
                get { return _Price; }


                set
                {
                    _Price = value;
                }
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
