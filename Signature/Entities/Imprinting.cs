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
    public class Imprinting : Order
    {
  
        new public DateTime Date;
      
        public _ImprintItems ImprintItems = new _ImprintItems();

        public String PackID;
        public Int32 LocalItems = 0;
        
       
        public Imprinting(String CompanyID) : base(CompanyID)
        {
            this.CompanyID = CompanyID;
            oPrize = new Prize(this.CompanyID);
        }

        public override bool Find(int OrderID, string PackID)
        {
            //Header
            if (!FindHeader(OrderID))
                return false;

            ImprintItems.Clear();
            LocalItems = 0;

            DataView tDetail = new DataView();
            if (PackID != "0" && PackID != "")
            {   
                tDetail = oMySql.GetDataView(String.Format("SELECT ot.OrderID as ID, ot.ID as TicketID, o.CustomerID, ot.Quantity,ot.ProductID, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode,ot.Printed   FROM OrderTicket ot  Left Join Orders o On o.ID=ot.OrderID Left Join Product p On p.ProductID=ot.ProductID And p.CompanyID=o.CompanyID Where ot.OrderID='{0}' ", this.ID), "Detail");
            }
   
            foreach (DataRow Row in tDetail.Table.Rows)
            {   
                ImprintItem Item  = new ImprintItem();

                Item.Description  = Row["Description"].ToString();

                Item.TicketID     = (int)Row["TicketID"];
                Item.ProductID    = Row["ProductID"].ToString();
                Item.Quantity     = (int)Row["Quantity"];
                Item.Description  = Row["Description"].ToString();
                Item.InvCode      = Row["InvCode"].ToString();
                Item.BarCode      = Row["BarCode"].ToString(); //Row["ProductID"].ToString();
                Item.BarCode2     = Row["BarCode_2"].ToString();
                Item.BarCode3     = Row["BarCode_3"].ToString();
                Item.Printed      = (Boolean) Row["Printed"]; ;
                if (Item.BarCode.Trim() == "")
                {
                    Global.ShowNotifier("This Product doesn't have BarCode : " + Row["ProductID"].ToString());
                }
                ImprintItems.Add(Row["TicketID"].ToString(), Item);

                LocalItems ++;

            }
          
            return true;
        }

        public bool IfDone()
        {
            bool Done=true;
            foreach (ImprintItem Row in ImprintItems)
            {
                if (!Row.Printed)
                {
                    Done = false;
                    break;
                }

            }
            return Done;
        }

        public ImprintItem GetItem(String ProductID)
        {
            foreach (ImprintItem Row in ImprintItems)
            {
                if ((Row.TicketID.ToString() == ProductID || Row.ProductID == ProductID || ProductID == Row.BarCode || ProductID == Row.BarCode2 || ProductID == Row.BarCode3) && !Row.Printed)
                {
                    return Row;
                }

            }
            return null;
        }

        public ImprintItem GetItemTicket(String TicketID)
        {
            foreach (ImprintItem Row in ImprintItems)
            {
                if ((Row.TicketID.ToString() == TicketID))
                {
                    return Row;
                }

            }
            return null;
        }
        
        public bool isImprinted()
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

        public void UpdateImprinted(Boolean IsPacked)
        {
            oMySql.exec_sql(String.Format("Update Orders Set Imprinted={0} Where ID='{1}'", IsPacked?1:0,this.ID));
            String LastPacker = this.Imprinter;
            if (LastPacker == "")
                InsertOrderActivity(OrderProcess.Packing);
            else
                InsertOrderActivity(OrderProcess.Packing,LastPacker);

        }

        public void UpdateImprinted(Boolean IsImprinted, String PackID)
        {
            
            Order.PackByOrder oOB = new PackByOrder();
            oOB.CompanyID = this.CompanyID;
            oOB.OrderID     = Convert.ToInt32(ID);
            oOB.PackID      = PackID;
            //oOB.BoxesPacked = this.BoxesPacked;
            //oOB.Items       = this.LocalItems;
            oOB.Imprinted     = IsImprinted;
            oOB.Imprinter     = Global.CurrentUser;
            oOB.Save();
            if (Lines.Count == 1)
            {

                UpdateImprinted(IsImprinted);
                return;
            }
            else
            {
                Lines.Load(this);
                this.BoxesPacked = 0;
                foreach (Order.PackByOrder oOB_1 in Lines)
                {
                    this.BoxesPacked += oOB_1.BoxesPacked;
                    if (!oOB_1.Imprinted)
                        IsImprinted = false;
                }
                UpdateImprinted(IsImprinted);
                return;
                
            }
           
        }

        public String Imprinter
        {
             get
            {
                DataRow rPayment = oMySql.GetDataRow(String.Format("Select User FROM OrderActivity  Where CompanyID='{0}' And OrderID='{1}' And Process='Imprinting'", this.CompanyID, this.ID), "Tmp");
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

        new public void Clear()
        {
            
            this.Teacher = null;
            this.Student = null;
            this.Date = DateTime.Now;
            this.PackID = "";
        }
        
        public  bool IfExist()
        {
            if (oMySql.exec_sql_no(String.Format("Select count(*) from Disc_Letter Where OrderID={0}",this.ID)) == 0)
            {
                return false;
            }
            return true;
        }
        
        
        
        public  class ImprintItem               //Single instance of Item
        {
            public Int32 _TicketID;
            public String OrderID;
            public String _Description;
            public String _ProductID;
            public int _Quantity;
            public int Seq;
            public String BarCode;
            public String BarCode2;
            public String BarCode3;
            public String _InvCode;
            public Boolean _Printed;

            Signature.Data.MySQL oMySql = Global.oMySql;

            public ImprintItem()
            {
                Description = "";
                ProductID = "";
                _Quantity = 0;
                Seq = 0;

            }
            public void Save()
            {
                if (if_exist())
                    Update();

            }
            public void Update()
            {

             //   String Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID={5}" + " Where CompanyID=\"" + this.CompanyID + "\"" + " And CustomerID=\"" + this.CustomerID + "\"" + " And OrderID=\"" + this.OrderID + "\"" + " And ProductID=\"" + this.ProductID + "\"",
             //       this.Seq, this.ProductID, this.Quantity, this.Tax, this.No_Invoiced, this.OrderID);
             //   oMySql.exec_sql_afected(Sql);

            }
            public void Delete()
            {
              //  String Sql = "Delete from OrderDetail where CompanyID='" + CompanyID + "' And CustomerID = '" + CustomerID + "' And ProductID = '" + ProductID + "'";
              //  oMySql.exec_sql(Sql);
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
            public Boolean Printed
            {
                get { return _Printed; }


                set
                {
                    _Printed = value;
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
            public Int32 TicketID
            {
                get { return _TicketID; }


                set
                {
                    _TicketID = value;
                }
            }

            

        }
        public class _ImprintItems : Hashlist //, IList
        {
            /* Hash List Support */
            public new ImprintItem this[string Key]
            {
                get { return (ImprintItem)base[Key]; }

            }
            public new ImprintItem this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (ImprintItem)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new ImprintItemsEnumerator(this);
            }
        }
        public class ImprintItemsEnumerator : IEnumerator
        {
            public ImprintItemsEnumerator(_ImprintItems ar)
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
            protected _ImprintItems _ar;


        }

    }
    
}
