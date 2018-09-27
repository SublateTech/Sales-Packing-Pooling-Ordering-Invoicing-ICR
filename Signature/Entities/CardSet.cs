using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature;

namespace Signature.Classes
{
    public class CardSet:BaseObject
    {
        protected SqlBuilder oBuild; //Reuqired
        protected String TableName;

        public _Cards Items;

        public Int32    ID;
        public String   CompanyID;
        public String   CardsetID;
        public Int32    RangeStart;
        public Int32    RangeEnd;
        public Boolean  Status;
        public Double   TotalCredit;
        
        public CardSet(String CompanyID)
        {

            this.DataBase = "WLOT";
            this.TableName = "WLOT.cart_cardsets";

            Items = new _Cards(this.CompanyID);
        }

        private void Clear()
        {
            //CompanyID="";
            CardsetID="";
                    
        }
        public  bool Find(String CardsetID)
        {
            //this.CallID = String.Empty;

            if (CardsetID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From "+this.TableName + " Where CardSetID='" + CardsetID +"'", "CardSet");
            
            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.CardsetID          = Row["CardsetID"].ToString();
            this.RangeStart         = (Int32) Row["Start"];
            this.RangeEnd           = (Int32)Row["End"];
            this.Status             = (Boolean)Row["Status"];
            this.TotalCredit        = (Double)Row["TotalCredit"];

            this.Items.Load(this);
            return true;

        }
        public  void Save()
        {
            FillFields();
            if (Exists())
                Update();
            else
                Insert();
        }
        public  void Update()
        {  
            oMySql.exec_sql(oBuild.Update("Where CardsetID='"+this.CardsetID+"' And CompanyID='"+this.DataBase+"'"));
        }
        public  void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());

        }
        internal  void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "ID",
                "CardSetID",
                "RangeStart",
                "RangeEnd",
                "TotalCredit",
                "Status"
                },
                new Object[] {
                    this.ID,
                    this.CardsetID,
                    this.RangeStart,
                    this.RangeEnd,
                    this.TotalCredit,
                    this.Status
                    });
        }
        public  bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where CardsetID='{1}' And CompanyID='{2}'",this.TableName,this.CardsetID,this.DataBase))) == 0)
                return false;
            else
                return true;
        }
        public  void Delete()
        {
            String Sql = String.Format("Delete From {0} Where CardsetID='{1}' And CompanyID='{2}'",TableName,this.CardsetID,this.DataBase);
            oMySql.exec_sql(Sql);
        }
        public  virtual bool View()
        {
            frmViewCardSets oView = new frmViewCardSets();
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }

        public class Card
        {
            protected SqlBuilder oBuild;

            public Int32 ID;
            public Int32  _CardNumber = 0;
            public Double _UsedCredit = 0;
            public Double _OverAmount = 0;


            public Int32 CardNumber
            {
                get { return _CardNumber; }
                set {_CardNumber = value; }
            }

            public Double UsedCredit
            {
                get { return _UsedCredit; }
                set { _UsedCredit = value; }
            }

            public Double OverAmount
            {
                get { return _OverAmount; }
                set {_OverAmount = value; }
            }


            private void Clear()
            {
                
            }
            public bool Find(Int32 CardNumber)
            {
                DataRow rRow = Global.oMySql.GetDataRow("Select * From WLOT.cart_cards Where CardNumber='" + CardNumber.ToString() + "'", "Tmp");

                if (rRow == null)
                {
                    Clear();
                    return false;
                }

                this.CardNumber = (Int32) rRow["CardNumber"];
                this.OverAmount = (Double)rRow["OverAmount"];
                this.UsedCredit = (Double)rRow["UsedCredit"];
                
                return true;

            }
            public void DeleteAll(Int32 OrderID)
            {
                String Sql = "Delete from OrderByLine Where OrderID='" + OrderID + "' And Packed='0'";
                Global.oMySql.exec_sql(Sql);
            }

            public void Save()
            {

                if (Exists())
                    Update();
                else
                    Insert();
            }
            public void Update()
            {
                
                FillFields();
                Global.oMySql.exec_sql(oBuild.Update("Where CardNumber='" + this.CardNumber + "'"));
            }
            public void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                
                FillFields();
                this.ID = Global.oMySql.exec_sql_id(oBuild.Insert());

            }

            private void FillFields()
            {
                oBuild = new SqlBuilder();

                oBuild.AddRange("OrderTicketDetail", new String[] { 
                    "TicketID",
                    "Text",
                    "Type"
                    
                },
                new Object[] {
                    this.CardNumber
                    
                });

            }
            public bool Exists()
            {
                if ((Global.oMySql.exec_sql_no("Select count(*) from OrderTicketDetail Where ID='" + this.ID + "'")) == 0)
                    return false;
                else
                    return true;
            }
            public void Delete()
            {
                String Sql = "Delete From OrderByBrochure Where CardNumber='" + this.CardNumber + "'";
                Global.oMySql.exec_sql(Sql);
            }
        }
        public class _Cards : Hashlist
        {
           // public ImprintType Type;

            public _Cards(String CompanyID)
                : base(CompanyID)
            {
                
            }
            public void Load(CardSet oCardSet)
            {

                this.Clear();
                DataTable dt = oMySql.GetDataTable(String.Format("SELECT * FROM WLOT.cart_cards Where CardNumber>={0} And CardNumber<={1} And UsedCredit > 0 Order By CardNumber", oCardSet.RangeStart, oCardSet.RangeEnd));
                if (dt == null)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Card LO = new Card();
                        LO.Find((Int32)row["CardNumber"]);
                        this.Add(row["CardNumber"].ToString(), LO);
                    }
                }
            }
            public void Save(Ticket oTicket)
            {
                this.Delete(oTicket);
                foreach (Card oLine in this)
                {
                    oLine.CardNumber = oTicket.ID;
                    oLine.Insert();
                }
            }

            public void Delete(Ticket oTicket)
            {
                String Sql = "Delete From OrderTicketDetail Where TicketID='" + oTicket.ID + "' And Type='" + "'";
                oMySql.exec_sql(Sql);
            }

            /* Hash List Support */
            public new Card this[string Key]
            {
                get { return (Card)base[Key]; }

            }
            public new Card this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Card)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new _LinesEnumerator(this);
            }

        }
        public class _LinesEnumerator : IEnumerator
        {
            public _LinesEnumerator(_Cards ar)
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
            protected _Cards _ar;


        }
    }
}
