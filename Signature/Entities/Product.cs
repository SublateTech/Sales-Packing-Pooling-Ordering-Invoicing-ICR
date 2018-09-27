using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Signature.Reports;
using Signature.Data;


namespace Signature.Classes
{
    public class Product:Company 
    {
        // Properties
        public new String ID;
        
        private String _Description;
        private Double _Price = 0;
        

        public String InvCode;
        
        public Double Length;
        public Double Width;
        public Double Height;
        public String Taxable;

        public Int32 OnHand;
        public Int32 Committed;
        public Int32 ONPO;
        public Int32 Sold;
        public Int32 Received;
        public Int32 Available;

        public Int32 Code; //Gift Avenue
        public Double Cost;
        public Double UnitCost;
        public int Size;            //#Items by box

        public String BarCode = null;
        public String BarCode_2 = null;
        public String BarCode_3 = null;

        public String VendorID;
        public String VendorItem;
        public Double AdjustProfitPercent;
        public Double AbsoluteProfitPercent;

        public Boolean IsCompound = false;
        public Double Profit_10;
        public Double Profit_20;
        public Double Profit_00;

        public Int32 BoxCount;

        public String Packaging;

        public Double UpperRange;

        public Double ImprintingFee;

        public Boolean IsLandedCost = false;

        public Int32 Section;

        
       // public String DescriptionEnglish;
      //  public String DescriptionSpanish;


        public ProductCollection Items;

        
        public Boolean IsCustomized
        {
            get
            {
                if (oMySql.exec_sql_no(String.Format("SELECT count(*) FROM Card Where CompanyID='{0}' And ProductID='{1}'", this.CompanyID, this.ID)) > 0)
                    return true;
                else
                    return false;

            }
        }

        //Methods
        public Product()
        {
            this.CompanyID = base.ID;
            this.Items = new ProductCollection(this.CompanyID);
        } //Constructor
        public Product(String CompanyID):base(CompanyID)
        {            
            this.CompanyID = CompanyID;
            this.Items = new ProductCollection(this.CompanyID);
        } //Constructor

        public Boolean FindByBarcode(String Barcode)
        {
            if (Barcode == String.Empty)
                return false;

            DataRow row = this.oMySql.GetDataRow(String.Format("Select ProductID From Product Where (Barcode='{0}' Or Barcode_2='{1}' Or Barcode_3='{2}') And CompanyID='{3}'",Barcode,Barcode,Barcode,this.CompanyID), "Product");
            if (row == null)
            {
                return false;
            }
            else
            {
                return this.Find(row["ProductID"].ToString());
            }
        }
        public override bool Find(String ProductID)
        {
            this.ID = "";
            this.Description = "";
            this.Price = 0;
            this.InvCode = "";
            
            this.Committed=0;
            this.ONPO=0;
            this.Sold=0;
            this.Received = 0;
            this.Available = 0;
            this.OnHand = 0;
            this.BoxCount = 0;
            this.UpperRange = 0;
            this.ImprintingFee = 0;
            this.IsLandedCost = false;

            if (ProductID == String.Empty)
                return false;
            

            DataRow rProduct = this.oMySql.GetDataRow("Select * From Product Where ProductID='" + ProductID + "' And CompanyID='"+CompanyID+"'", "Product");
   
            if (rProduct == null)
            {
                Clear();
                return false;
            }

            this.ID             = rProduct["ProductID"].ToString();
            this._Price         = (rProduct["Price"] == DBNull.Value)?0:(Double) rProduct["Price"];
            
            this._Description   = rProduct["Description"].ToString();
            this.InvCode        = rProduct["InvCode"].ToString();
            this.Length         = (rProduct["Length"] == DBNull.Value)?0:(Double)rProduct["Length"];
            this.Width          = (rProduct["Width"] == DBNull.Value)?0:(Double)rProduct["Width"];
            this.Height         = (rProduct["Height"] == DBNull.Value)?0:(Double)rProduct["Height"];
            this.Taxable        = rProduct["Taxable"].ToString();
            this.BarCode        = rProduct["BarCode"].ToString();
            this.BarCode_2      = rProduct["BarCode_2"].ToString();
            this.BarCode_3      = rProduct["BarCode_3"].ToString();
            this.Cost           = (rProduct["Cost"] == DBNull.Value) ? 0 : (Double)rProduct["Cost"];
            this.UnitCost       = (rProduct["UnitCost"] == DBNull.Value) ? 0 : (Double)rProduct["UnitCost"];
            this.Committed      = (rProduct["Commited"] == DBNull.Value) ? 0 : (int)rProduct["Commited"];
            this.ONPO           = (rProduct["ONPO"] == DBNull.Value) ? 0 : (int)rProduct["ONPO"];
            this.Received       = (rProduct["Received"] == DBNull.Value) ? 0 : (int)rProduct["Received"];
            this.Sold           = (rProduct["Sold"] == DBNull.Value) ? 0 : (int)rProduct["Sold"];
            this.Size           = (rProduct["Size"] == DBNull.Value) ? 0 : (int)rProduct["Size"];
            this.VendorID       = rProduct["VendorID"].ToString();
            this.VendorItem     = rProduct["VendorItem"].ToString();
            this.OnHand                 = this.Received - this.Sold;
            this.Available              = this.OnHand - this.Committed;
            this.AdjustProfitPercent    = (Double)rProduct["AdjProfitPercent"];
            this.AbsoluteProfitPercent  = (Double)rProduct["ProfitPercent"];
            this.IsCompound             = (Boolean) rProduct["IsCompound"];

            this.Code           = (Int32)rProduct["Code"];
            this.Profit_10      = (Double)rProduct["Profit_10"];
            this.Profit_20      = (Double)rProduct["Profit_20"];
            this.Profit_00      = (Double)rProduct["Profit_00"];
            this.Items.CProductID = this.ID;
            this.Items.CompanyID = this.CompanyID;
            this.BoxCount       = (Int32)rProduct["BoxCount"];
            this.Packaging      = rProduct["Packaging"].ToString();
            this.UpperRange     = (rProduct["UpperRange"] == DBNull.Value) ? 0 : (Double)rProduct["UpperRange"];
            this.ImprintingFee  = (rProduct["Fee"] == DBNull.Value) ? 0 : (Double)rProduct["Fee"];
            this.IsLandedCost   = (Boolean)rProduct["IsLandedCost"];
            this.Section = (Int32)rProduct["SectionID"];
            return true;
        
        }
        public  void Clear()
        {
            ID = null;
            _Price = 0;
            
            _Description = null;
            InvCode = null;
            Length = 0;
            Width = 0;
            Height = 0;
            Taxable = null;
            BarCode = null;
            BarCode_2 = null;
            BarCode_3 = null;
            Cost = 0;
            UnitCost = 0;
            OnHand = 0;
            ONPO = 0;
            Sold = 0;
            Size = 0;
            Code = 0;
            AdjustProfitPercent = 0.00;
            this.AbsoluteProfitPercent = 0.00;
            this.IsCompound = false;
            Profit_10 = 0.00;
            Profit_20 = 0.00;
            Profit_00 = 0.00;
            this.BoxCount = 0;
            this.Packaging = "";
            UpperRange = 0.00;
            ImprintingFee = 0.00;
            IsLandedCost = false;
            this.Section = 0;
            return;
        }
        public bool View(Customer oCustomer)
        {
            frmProductView oView = new frmProductView(oCustomer);
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				ID =  oView.sSelectedID;
                Find(ID);
                return true;
				
			}
            return false;
        }
        public override bool View()
        {
        	frmProductView oView = new frmProductView(this.CompanyID);
			oView.ShowDialog();
			if (oView.sSelectedID!="")
			{
				ID =  oView.sSelectedID;
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
        }
        public override void Update()
        {
            this.Description = MySQL.PrepareSql(this.Description);

            String Sql = String.Format("Update Product Set CompanyID='{0}', ProductID=\"{1}\", Description=\"{2}\", InvCode='{3}', Price='{4}', Cost='{5}',  Length='{6}', Width='{7}', Height='{8}', BarCode='{9}', Taxable='{10}', Received='{11}', Commited='{12}',Sold='{13}',ONPO='{14}',VendorID='{15}',VendorItem='{16}',Size='{17}',BarCode_2='{18}',BarCode_3='{19}',OnHand='{20}',AdjProfitPercent='{21}',IsCompound='{22}', Code='{23}', Profit_10='{24}', Profit_20='{25}', Profit_00='{26}', ProfitPercent='{27}', UnitCost=\"{28}\", BoxCount = '{29}', Packaging = '{30}', UpperRange = '{31}', Fee = '{32}', IsLandedCost = '{33}', SectionID='{34}'   Where ProductID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
                this.CompanyID, this.ID, this.Description, this.InvCode, this.Price, this.Cost, this.Length, this.Width, this.Height, this.BarCode, this.Taxable, this.Received, this.Committed, this.Sold, this.ONPO, this.VendorID, this.VendorItem, this.Size, this.BarCode_2, this.BarCode_3, this.OnHand, this.AdjustProfitPercent, this.IsCompound ? "1" : "0", this.Code, this.Profit_10, this.Profit_20, this.Profit_00, this.AbsoluteProfitPercent,  this.UnitCost,this.BoxCount,this.Packaging, this.UpperRange,this.ImprintingFee,this.IsLandedCost? "1" : "0",this.Section);
            oMySql.exec_sql(Sql);	

        }
        public void UpdateInventory()
        {
            /*
            if (ID == "0001")
            {
                OnHand = 0;
                Committed = 0;
                Sold = 0;
                ONPO = 0;
                Received = 0;
                Available = 0;
            }
            */
            this.OnHand = this.Received - this.Sold;
            this.Available = this.OnHand - this.Committed;
            
            String Sql = String.Format("Update Product Set  Received='{0}', Commited='{1}',Sold='{2}',ONPO='{3}',OnHand='{4}'   Where ProductID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.Received, this.Committed, this.Sold, this.ONPO,this.OnHand);
            //MessageBox.Show(Sql);
            oMySql.exec_sql(Sql);

        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Product (CompanyID, ProductID, Description, InvCode, Price, Cost, Length, Width, Height, BarCode, Taxable, Received, Commited,Sold,ONPO,VendorID,VendorItem, Size,BarCode_2,BarCode_3,AdjProfitPercent,IsCompound,Code,Profit_10,Profit_20,Profit_00,ProfitPercent,  UnitCost, BoxCount, Packaging, UpperRange, Fee, IsLandedCost, SectionID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}', '{16}', '{17}', '{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}',\"{27}\",'{28}','{29}','{30}','{31}','{32}','{33}')",
                this.CompanyID, this.ID, this.Description, this.InvCode, this.Price, this.Cost, this.Length, this.Width, this.Height, this.BarCode, this.Taxable, this.Received, this.Committed, this.Sold, this.ONPO, this.VendorID, this.VendorItem, this.Size, this.BarCode_2, this.BarCode_3, this.AdjustProfitPercent, this.IsCompound ? "1" : "0", this.Code, this.Profit_10, this.Profit_20, this.Profit_00, this.AbsoluteProfitPercent, this.UnitCost, this.BoxCount, this.Packaging, this.UpperRange, this.ImprintingFee, this.IsLandedCost ? "1" : "0",this.Section);
            oMySql.exec_sql(Sql);	
        }
        public  bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Product Where ProductID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override string ToString()
        {
            return Price.ToString();
        }
        public override void Delete()
        {
            Global.ShowNotifier("Deleted Item : (" + ID + ") " + this.Description);
            String Sql = "Delete From Product Where ProductID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
            Sql = "Delete From BrochureDetail Where ProductID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
        }
        public void Print(String ProductID, String ProductID_2, Boolean isLanded) // Product Listing Report
        {
            String Sql = "";

            if (ProductID.Trim().Length > 0 && ProductID_2.Trim().Length > 0)
                Sql = String.Format(" And ProductID >='{0}' And ProductID<='{1}' ",ProductID,ProductID_2);
            
            if (ProductID.Trim().Length > 0 && ProductID_2.Trim().Length == 0)
                Sql = String.Format(" And ProductID ='{0}'", ProductID);
            
            
            frmViewReport oViewReport = new frmViewReport();
            
            ItemListing oRpt = new ItemListing();
            ItemListingLandedCost oRpt_1 = new ItemListingLandedCost();

            DataSet ds = new DataSet();

            if (isLanded)
                ds.Tables.Add(oMySql.GetDataTable("Select ProductID, Description, Size,VendorItem,ONPO,Commited,Sold,Received,p.UnitCost as Cost  From Product p Where CompanyID='" + CompanyID + "'" + Sql, "Product"));
            else
                ds.Tables.Add(oMySql.GetDataTable("Select p.*,p.Cost as FinalCost  From Product p Where CompanyID='" + CompanyID + "'" + Sql, "Product"));

            
            
          //  ds.WriteXml("dataset1002.xml", XmlWriteMode.WriteSchema);

            oRpt.SetDataSource(ds);
            

            //oRpt.PrintToPrinter(1, true, 1, 100);
            if (isLanded)
            {
                oRpt.SetParameterValue("Title", "ITEM LISTING LANDED COST");
                oViewReport.cReport.ReportSource = oRpt;
            }
            else
            {
                oRpt.SetParameterValue("Title", "ITEM LISTING");
                oViewReport.cReport.ReportSource = oRpt;
            }
            oViewReport.ShowDialog();
        
        }
        public void PrintLandedChecked()
        {


            frmViewReport oViewReport = new frmViewReport();
            ItemLandedCostCheckedListing oRpt = new ItemLandedCostCheckedListing();
            

            DataSet ds = new DataSet();

            
            ds.Tables.Add(oMySql.GetDataTable("Select p.*  From Product p Where CompanyID='" + CompanyID + "' And IsLandedCost='0'" , "Product"));



//            ds.WriteXml("PrintLandedChecked.xml", XmlWriteMode.WriteSchema);

            oRpt.SetDataSource(ds);

            //oRpt.PrintToPrinter(1, true, 1, 100);
            
            oRpt.SetParameterValue("Title", "ITEM LANDED COST CHECKED LISTING");
            oViewReport.cReport.ReportSource = oRpt;
            
            oViewReport.ShowDialog();
        }

        public String Description
        {
            get { return _Description; }
            set { _Description = value;  }
        }
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public Double ExtendedPrice(Customer oCustomer)
        {
          //if (!base.IsBrochureControl)
          //    return Price;
            
            DataRow row = this.oMySql.GetDataRow(String.Format("SELECT p.ProductID, p.Price as Price , p.Price_2, bd.Price as Brochure_Price  FROM Product p " +
            "Left Join BrochureDetail bd On bd.CompanyID=p.CompanyID And bd.ProductID=p.ProductID " +
            "Left join Brochure b On bd.CompanyID=b.CompanyID And bd.BrochureID=b.BrochureID " +
            "Left Join BrochureByCustomer bc On bc.CompanyID=b.CompanyID And bc.BrochureID=b.BrochureID " +
            "Where p.CompanyID='{0}' And p.ProductID='{1}' And bc.CustomerID='{2}'",CompanyID,this.ID,oCustomer.ID),"Tmp");
           

            if (row == null)
                return 0.00;
            else if ((Double)row["Brochure_Price"] > 0.00)
                return (Double)row["Brochure_Price"];
            else if (oCustomer.PriceListID=="1")
                return (Double)row["Price_2"];
            else
                return (Double)row["Price"];
        }
        public String PackID(Customer oCustomer)
        {
            DataRow row = this.oMySql.GetDataRow(String.Format("SELECT p.ProductID, b.PackID  FROM Product p " +
            "Left Join BrochureDetail bd On bd.CompanyID=p.CompanyID And bd.ProductID=p.ProductID " +
            "Left join Brochure b On bd.CompanyID=b.CompanyID And bd.BrochureID=b.BrochureID " +
            "Left Join BrochureByCustomer bc On bc.CompanyID=b.CompanyID And bc.BrochureID=b.BrochureID " +
            "Where p.CompanyID='{0}' And p.ProductID='{1}' And bc.CustomerID='{2}'", CompanyID, this.ID, oCustomer.ID), "Tmp");
            

            if (row == null)
                return "";
            else
                return row["PackID"].ToString();
        }
        public Boolean IsInBrochure(String _BrochureID)
        {
            Int32 row = this.oMySql.exec_sql_no("Select count(*) From BrochureDetail Where CompanyID='" + CompanyID + "' And  ProductID='" + ID + "' And  BrochureID='" + _BrochureID +"'");

            if (row == 0)
            {
                return false;
            }
            else
            {
                return true; ;
            }
        }
        public void InsertMisc(Int32 Quantity, String Concept, String Type)
        {
            String Sql = String.Format("Insert into ProductMisc (CompanyID, ProductID, Type, Quantity, Description, Date )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}',\"{4}\",'{5}')",
                        this.CompanyID, this.ID, Type, Quantity,Concept, oMySql.SqlTimeDate(DateTime.Now));
            oMySql.exec_sql(Sql);
        }

        public String GetBrochure(String CustomerID)
        {
            DataRow rProduct = this.oMySql.GetDataRow(String.Format("Select bd.BrochureID, bd.ProductID from BrochureDetail bd Left Join BrochureByCustomer bc On bc.CompanyID=bd.CompanyID And bc.BrochureID=bd.BrochureID Where bd.CompanyID='{0}' And bc.CustomerID='{1}' And bd.ProductID='{2}'",this.CompanyID,CustomerID,this.ID),"tmp");
            if (rProduct == null)
            {
                return "";
            }
            return rProduct["BrochureID"].ToString();
        }
        public void GA_CalculatePorcentages1()
        {
            DataTable table =  oMySql.GetDataTable(String.Format("Select * From Product Where CompanyID='{0}' And Price>0 And Price <100",this.CompanyID));
            foreach (DataRow row in table.Rows)
            {
                if (this.Find(row["ProductID"].ToString()))
                {
                    //10 Percent
                    //MessageBox.Show(GetPercentage(10).ToString());
                    //MessageBox.Show(GetPercentage(20).ToString());
                    this.Profit_10 = GetPercentage(10);
                    this.Profit_20 = GetPercentage(20);
                    this.Profit_00 = GetPercentage(00);
                    this.Save();
                }
            }
        }

        private Double GetPercentage(Double Percentage)
        {
                    long Rest = 0;
                    Double Result = 0.00;
                    Double _Percentage = 1 + Percentage / 100;
                    Double Number =  Math.DivRem((long)(this.Price * _Percentage * 100),(long) 25, out Rest);
                    if (Rest > 0)
                    {
                        Result= Number * 0.25 + 0.25;
                    }
                    else
                    {
                        Result = Price * _Percentage; //Convert.ToInt32(Price * _Percentage / 0.25) * 0.25;

                    }
                    return Result;
        }
        public class ProductCompoundItem
        {
            public String CProductID;
            public String ProductID;
            public Int32 Quantity;
            public Double Price = 0;
            public String Description = "";
            public String CompanyID = "";

            public ProductCompoundItem(String CompanyID)
            {
                this.CompanyID = CompanyID;
                ProductID = "";
                Quantity = 0;
            }
            public void Insert()
            {
                String Sql = String.Format("Insert into ProductCompound (CompanyID, CProductID, ProductID, Quantity)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}')",
                    this.CompanyID, this.CProductID, this.ProductID, this.Quantity);
                Global.oMySql.exec_sql_afected(Sql);

            }
        }
        public class ProductCollection : Hashlist
        {

            public String CProductID = "";
            public DataTable dtItems = new DataTable("Detail");
            

            public ProductCollection(String CompanyID) : base(CompanyID) 
            {
                SetColumns();
            }

            public DataView GetTable(String ProductID)
            {
                this.CProductID = ProductID;
                return oMySql.GetDataView("select p.Description, pc.ProductID, pc.Quantity, p.BarCode, p.BarCode_2,p.BarCode_3, p.InvCode from ProductCompound pc Left join Product p  on pc.CompanyID=p.CompanyID And pc.ProductID=p.ProductID Where pc.CompanyID='" + CompanyID + "' And CProductID='" + this.CProductID + "'", "ProductCompound"); ;
            }
            
            public void Load()
            {
                Clear();
                Product oProduct = new Product(CompanyID);
                dtItems = oMySql.GetDataTable("select p.Description, pc.ProductID, pc.Quantity, p.Price from ProductCompound pc Left join Product p  on pc.CompanyID=p.CompanyID And pc.ProductID=p.ProductID Where pc.CompanyID='" + CompanyID + "' And CProductID='" + this.CProductID + "'", "ProductCompound");
                foreach (DataRow row in dtItems.Rows)
                {
                    oProduct.Find(row["ProductID"].ToString());
                    ProductCompoundItem oBC = new ProductCompoundItem(this.CompanyID);
                    oBC.Description = oProduct.Description;
                    oBC.Price = oProduct.Price;
                    oBC.Quantity = (Int32)row["Quantity"];

                     Add(row["ProductID"].ToString(), oBC);
                   
                    
                }
                AddEmpty();
            }
            public void AddEmpty()
            {
                DataRow Detail = dtItems.NewRow();

                Detail["Description"] = "";
                Detail["ProductID"] = "";
                Detail["Quantity"] = 0;
                Detail["Price"] = 0;


                dtItems.Rows.Add(Detail);
            }
            public void Delete(String CompanyID, String ProductID)
            {
                String Sql = "Delete from ProductCompound where CompanyID='" + CompanyID + "' And CProductID = '" + ProductID + "'";
                oMySql.exec_sql(Sql);
            }
            public void Save(String CompanyID, String ProductID)
            {
                Product oProduct = new Product(CompanyID);
                this.Delete(CompanyID, ProductID);
                foreach (DataRow _Row in dtItems.Rows)
                {
                    ProductCompoundItem _Item = new ProductCompoundItem(CompanyID);
                    if (_Row["ProductID"].ToString().Trim() == "")
                        continue;
                    _Item.CProductID = ProductID;
                    _Item.CompanyID = CompanyID;
                    _Item.ProductID = _Row["ProductID"].ToString();
                    _Item.Quantity = (Int32)_Row["Quantity"];
                    _Item.Insert();
                    
                }
                dtItems.Rows.Clear();
            }
            public void SetColumns()
            {
                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("ProductID", Type.GetType("System.String"));
                // colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Item ID";
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
                colWork = new DataColumn("Price", Type.GetType("System.Double"));
                colWork.Caption = "Price";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                
                colWork = new DataColumn("Quantity", Type.GetType("System.Int32"));
                //  colWork.MaxLength = 10;
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                
                colWork = new DataColumn("Seq", Type.GetType("System.Int16"));

                //  colWork.MaxLength = 10;
                dtItems.Columns.Add(colWork);

                /*  // add a row
                  DataRow row = dtKits.NewRow();
                  row["CustomerID"] = "2268";
                  row["KitID"] = "KT7022";

                  dtKits.Rows.Add(row);
                  */
                return;
            }
            /* Hash List Support */
            public new Product this[string Key]
            {
                get { return (Product)base[Key]; }

            }
            public new Product this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Product)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new ProductCollectionEnumerator(this);
            }

        }
        public class ProductCollectionEnumerator : IEnumerator
        {
            public ProductCollectionEnumerator(ProductCollection ar)
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
            protected ProductCollection _ar;


        }
    }
}
