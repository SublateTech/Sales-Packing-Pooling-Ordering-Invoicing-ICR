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


namespace Signature.Classes
{
    public class Prize:Company
    {
        
        
        // Properties
        public new String ID;
        private String _Description;
        public String InvCode;
        public _Items Items;
       // public Boolean IsCookieDough;
        public String  _PackID;
  
        //Methods

        public Prize(String CompanyID)
        {
            this.CompanyID = CompanyID;
            this.Items = new _Items();
           // this.IsCookieDough = false;
            this.PackID = "";
        } //Constructor

        public override bool Find(String PrizeID)
        {
            this.ID = "";
            this.Description = "";
          //  this.IsCookieDough = false;
         
            if (PrizeID == "")
                return false;

                        
            DataRow rPrize = oMySql.GetDataRow("Select * From Prizes Where CompanyID='"+CompanyID+"' And PrizeID='" + PrizeID + "'", "Prize");
           
            if (rPrize == null)
            {

                this._Description = "";
                return false;
            }

            this.ID = (String)rPrize["PrizeID"];
            this._Description   = rPrize["Description"].ToString();
            //this.IsCookieDough = (Boolean)rPrize["IsCookieDough"];
            this.PackID = rPrize["PackID"].ToString();

            Items.Load(CompanyID,PrizeID);
            return true;
        
        }
        public override bool View()
        {
            frmPrizesView oView = new frmPrizesView(CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
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
            Items.Save(CompanyID,ID);
        }
        public override void Update()
        {
            String Sql = String.Format("Update Prizes Set PrizeID='{0}', Description=\"{1}\", CompanyID=\"{2}\", PackID='{3}'    Where PrizeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
             this.ID, this.Description, this.CompanyID,this.PackID);

            oMySql.exec_sql(Sql);
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Prizes (CompanyID, PrizeID, Description, PackID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}')",
                         this.CompanyID, this.ID, this.Description,this.PackID);
            oMySql.exec_sql(Sql);
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Prizes Where PrizeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Delete()
        {
            String Sql = "Delete From Prizes Where PrizeID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
            Items.Delete(CompanyID, ID);
        }

        public String GetLevel(String PrizeProgram, int NumberItems)
        {
            DataRow rPrize = oMySql.GetDataRow(String.Format("Select pz.ProductID, p.Description, p.BarCode, p.InvCode FROM PrizeDetail pz left JOIN Product p on pz.CompanyID=p.CompanyID And pz.ProductID=p.ProductID Where PrizeID='" + PrizeProgram + "' And pz.CompanyID='" + CompanyID + "' And BreakLevel <= {0} order by BreakLevel DESC LIMIT 1 ", NumberItems), "Prize");
            if (rPrize != null)
            {
                return rPrize["ProductID"].ToString();
            }
            else
                return "";
        }

        public DataView  GetItems(String PrizeProgram, int NumberItems)
        {
            return (oMySql.GetDataView(String.Format("Select pz.ProductID, p.Description, p.BarCode, p.BarCode_2,p.BarCode_3, p.InvCode, p.IsCompound, pz.Quantity, p.SectionID FROM PrizeDetail pz left JOIN Product p on pz.CompanyID=p.CompanyID And pz.ProductID=p.ProductID Where PrizeID='" + PrizeProgram + "' And pz.CompanyID='" + CompanyID + "' And BreakLevel <= {0} order by BreakLevel DESC", NumberItems), "Prize"));
        }

        public DataView GetItems(String PrizeProgram, int NumberItems, String SectionID)
        {
            return (oMySql.GetDataView(String.Format("Select pz.ProductID, p.Description, p.BarCode, p.BarCode_2,p.BarCode_3, p.InvCode, p.IsCompound, pz.Quantity, p.SectionID FROM PrizeDetail pz left JOIN Product p on pz.CompanyID=p.CompanyID And pz.ProductID=p.ProductID Where PrizeID='" + PrizeProgram + "' And pz.CompanyID='" + CompanyID + "' And p.SectionID='"+SectionID+ "' And BreakLevel <= {0} order by BreakLevel DESC", NumberItems), "Prize"));
        }


        public String Description
        {
            get { return _Description; }
            set { _Description = value;  }
        }
        public String PackID
        {
            get { return _PackID; }
            set { _PackID = value; }
        }

        #region Classes & Enumerators
        public class _Items : Hashlist //, IList
        {
            
            public DataTable dtItems = new DataTable("Detail");


            public _Items()
            {
                SetColumns();
            }
            public void AddEmpty1()
            {
                Item _Item = new Item();
                _Item.Description = "";
                _Item.ProductID = "";

                this.Add("ZZZZZ", _Item);
            }
            public void AddEmpty()
            {
                DataRow Detail = dtItems.NewRow();

                Detail["Description"] = "";
                Detail["ProductID"] = "";
                Detail["BreakLevel"] = 0;
                Detail["Amount"] = 0;
                Detail["Quantity"] = 1;


                dtItems.Rows.Add(Detail);
            }
            public void Load(String CompanyID, String PrizeID)
            {
                if (dtItems.Rows.Count > 0)
                    dtItems.Rows.Clear();

                DataView tDetail;
                tDetail = oMySql.GetDataView(String.Format("SELECT pb.PrizeID, pb.ProductID, p.Description,pb.BreakLevel,pb.BreakLevelDollars,pb.Quantity  FROM PrizeDetail pb left join Product p on pb.CompanyID=p.CompanyID And pb.ProductID=p.ProductID Where pb.CompanyID='{0}' And PrizeID='{1}'", CompanyID, PrizeID), "PB");

                
                foreach (DataRow Row in tDetail.Table.Rows)
                {
                    DataRow Detail = dtItems.NewRow();


                    Detail["Description"]   = Row["Description"].ToString();
                    Detail["ProductID"]     = Row["ProductID"].ToString();
                    Detail["BreakLevel"]    = Row["BreakLevel"] == DBNull.Value ? 0.0 : (Int32)Row["BreakLevel"];
                    Detail["Amount"]        = Row["BreakLevelDollars"] == DBNull.Value ? 0.0 : (Double)Row["BreakLevelDollars"];
                    Detail["Quantity"]      = (Int32)Row["Quantity"];

                    dtItems.Rows.Add(Detail);

                }

                AddEmpty();
            }
            public void Save(String CompanyID, String PrizeID)
            {

                this.Delete(CompanyID, PrizeID);
                foreach (DataRow _Row in dtItems.Rows)
                {
                    Item _Item = new Item();
                    if (_Row["ProductID"].ToString() == "")
                        continue;
                    _Item.PrizeID = PrizeID;
                    _Item.CompanyID = CompanyID;
                    _Item.ProductID = _Row["ProductID"].ToString();
                    _Item.BreakLevel = _Row["BreakLevel"] == DBNull.Value ? 0 : (Int32)_Row["BreakLevel"];
                    _Item.Amount    = _Row["Amount"] == DBNull.Value ? 0 : (Double)_Row["Amount"];
                    _Item.Quantity = _Row["Quantity"] == DBNull.Value ? 0 : (Int32)_Row["Quantity"];

                    _Item.Insert();
                }
                dtItems.Rows.Clear();
            }
            public void Delete(String CompanyID, String PrizeID)
            {
                String Sql = "Delete from PrizeDetail where CompanyID='" + CompanyID + "' And PrizeID = '" + PrizeID + "'";
                oMySql.exec_sql(Sql);
            }
            public void SetColumns()
            {
                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
                // colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Prize";
                colWork.ReadOnly = false;
                this.dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Description", Type.GetType("System.String"));
                colWork.Caption = "Description";
                colWork.MaxLength = 200;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);

                /*      //' add CustomerID column to key array and bind to DataTable
                      DataColumn[] Keys = new DataColumn[1];
                      Keys[0] = dtItems.Columns["ProductID"]; //colWork;
                      dtItems.PrimaryKey = Keys;
                      */

                colWork = new DataColumn("BreakLevel", Type.GetType("System.Int32"));
                //  colWork.MaxLength = 10;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Amount", Type.GetType("System.Double"));
                colWork.Caption = "Amount";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Quantity", Type.GetType("System.Int32"));
                //  colWork.MaxLength = 10;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);

                return;
            }

            public void Load1(String CompanyID, String PrizeID)
            {

                Clear();

                DataView tDetail;
                tDetail = oMySql.GetDataView(String.Format("SELECT pb.PrizeID, pb.ProductID, p.Description,pb.BreakLevel,pb.BreakLevelDollars  FROM PrizeDetail pb left join Product p on pb.CompanyID=p.CompanyID And pb.ProductID=p.ProductID Where pb.CompanyID='{0}' And PrizeID='{1}'", CompanyID, PrizeID), "PB");
                //Console.WriteLine(String.Format("SELECT pb.PrizeID, pb.ProductID, p.Description,pb.BreakLevel,pb.BreakLevelDollars  FROM PrizeDetail pb left join Product p on pb.CompanyID=p.CompanyID And pb.ProductID=p.ProductID Where pb.CompanyID='{0}' And PrizeID='{1}'", CompanyID, PrizeID));
                foreach (DataRow Row in tDetail.Table.Rows)
                {

                    Item Detail = new Item();

                    Detail.Description  = Row["Description"].ToString();
                    Detail.ProductID    = Row["ProductID"].ToString();
                    Detail.BreakLevel   = (int) Row["BreakLevel"];
                    Detail.Amount       = (Double)Row["BreakLevelDollars"];
                    Detail.Quantity = (Int32)Row["Quantity"];

                    if (!Contains(Row["ProductID"].ToString()))
                        Add(Row["ProductID"].ToString(), Detail);

                }

                //AddEmpty();
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
            public new IEnumerator GetEnumerator()
            {
                return new ItemsEnumerator(this);
            }
        }
        public class Item               //Single instance of detail
        {

            public String CompanyID;
            public String PrizeID;
            private String _Description;
            private String _ProductID;
            private int _BreakLevel;
            private Double _Amount;
            private Int32 _Quantity;


            Signature.Data.MySQL oMySql = Global.oMySql;

            public Item()
            {
                Description = "";
                ProductID = "";



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
            public int BreakLevel
            {
                get { return _BreakLevel; }


                set
                {
                    _BreakLevel = value;
                }
            }
            public Double Amount
            {
                get { return _Amount; }


                set
                {
                    _Amount = value;
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
            public void Insert()
            {
                String Sql = String.Format("Insert into PrizeDetail (CompanyID, PrizeID, ProductID, BreakLevel, BreakLevelDollars, Quantity)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}')",
                    this.CompanyID, this.PrizeID, this.ProductID, this.BreakLevel,this.Amount,this.Quantity);
                //MessageBox.Show(Sql);
                oMySql.exec_sql_afected(Sql);

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
