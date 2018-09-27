using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Reports;



namespace Signature.Classes
{
    public class Brochure:Company
    {
        
        // Properties
        public new String ID;
        private String _Description;
        
        public int NumberItems;
        public String ProductID;
        public String PackID;
        public Boolean IsCookieDough = false;

        public _Items Items; // = new _Items();

        public _Detail Detail =  new _Detail();

        //Methods

        public Brochure(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            Items = new _Items();
        } //Constructor

        public  bool Find(String BrochureID)
        {
            
            this.Description = "";

            if (BrochureID == "" || BrochureID == null)
            {
                this._Description = "";
                this.ID = "";
                return false;
            }

            DataRow rProduct = this.oMySql.GetDataRow("Select * From Brochure Where CompanyID='"+CompanyID+"' And  BrochureID='" + BrochureID + "'", "Brochure");
            if (rProduct == null)
            {
                this.ID = "";
                this._Description = "Brochure not found!";
                
                return false;
            }

            this.ID = rProduct["BrochureID"].ToString();
            this._Description   = rProduct["Description"].ToString();
            this.ProductID = rProduct["ProductID"].ToString();
            this.PackID = rProduct["PackID"].ToString();
            this.IsCookieDough = (Boolean)rProduct["CookieDough"];

            this.Items.Load(CompanyID,ID);
            this.Detail.Load();
            return true;
        
        }
        public override bool View()
        {
            frmBrochureView oView = new frmBrochureView(this.CompanyID);
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
            Items.Save(CompanyID, ID);
        }
        public override void Update()
        {

            String Sql = String.Format("Update Brochure Set BrochureID='{0}', Description=\"{1}\", N_Items=\"{2}\",CompanyID=\"{3}\",ProductID='{4}',PackID='{5}',CookieDough='{6}'    Where BrochureID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
                this.ID, this.Description, this.NumberItems, this.CompanyID , this.ProductID,this.PackID, this.IsCookieDough?"1":"0");
            
            oMySql.exec_sql(Sql);
            
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into Brochure (CompanyID, BrochureID, Description, N_Items,ProductID,PackID, CookieDough )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}')",
                this.CompanyID, this.ID, this.Description, this.NumberItems, this.ProductID,this.PackID, this.IsCookieDough?"1":"2");
            oMySql.exec_sql(Sql);
        }
        public bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Brochure Where BrochureID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Delete()
        {
            String Sql = "Delete From Brochure Where BrochureID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
            this.Items.Delete(this.CompanyID, this.ID);
        }
        public void Print()
        {

            frmViewReport oViewReport = new frmViewReport();
            BrochureListing oRpt = new BrochureListing();
            
            DataSet ds = new DataSet();

            
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "Brochure"));
          //  ds.Tables.Add(oMySql.GetDataTable("Select * From Product  Where CompanyID='" + CompanyID + "'", "Product"));
            //ds.Tables.Add(oMySql.GetDataTable("Select distinct(od.ProductID), p.Description, sum(od.Quantity) as Commited, p.InvCode  FROM OrderDetail od Join BrochureDetail bd On od.CompanyID=bd.CompanyID And od.ProductID=bd.ProductID Join Product p On od.CompanyID=p.CompanyID And od.ProductID=p.ProductID Where od.CompanyID='"+CompanyID+"' And bd.BrochureID='"+ID+"' Group By od.ProductID", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("CALL sp_brochure_listing('"+CompanyID+"','"+ID+"')", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "BrochureDetail"));

            //ds.WriteXml("dataset61.xml", XmlWriteMode.WriteSchema);


            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }

                TSold += row["Commited"]==DBNull.Value?0:Convert.ToInt32(row["Commited"].ToString());
                 
            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TSold", TSold);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            /*
            oViewReport.sParameter_1 = ID;
            oViewReport.SetReport((int)Report.PurchaseOrder, CompanyID, "", true);
             */
        }
        public void Print2Brochures(String BrochureID_1, String BrochureID_2)
        {

            frmViewReport oViewReport = new frmViewReport();
            Brochure2Listing oRpt = new Brochure2Listing();

            DataSet ds = new DataSet();


            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' And (BrochureID='" + BrochureID_1 + "')", "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' And (BrochureID='" + BrochureID_2 + "')", "Brochure_2"));
            ds.Tables.Add(oMySql.GetDataTable("CALL sp_brochure_listing('" + CompanyID + "','" + BrochureID_1 + "')", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("CALL sp_brochure_listing('" + CompanyID + "','" + BrochureID_2 + "')", "Product_2"));
            ds.Tables.Add(oMySql.GetDataTable("Select bd.*, p.Description From BrochureDetail bd Left Join Product p On bd.CompanyID=p.CompanyID and bd.ProductID=p.ProductID Where bd.CompanyID='" + CompanyID + "' And (BrochureID='" + BrochureID_1 + "' OR BrochureID='" + BrochureID_2 + "') Group By bd.ProductID Order By bd.ProductID ", "BrochureDetail"));
            //ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And BrochureID='" + BrochureID_2 + "'", "BrochureDetail_2"));

            //Console.WriteLine("Select * From BrochureDetail Where bd.CompanyID='" + CompanyID + "' And (BrochureID='" + BrochureID_1 + "' OR BrochureID='" + BrochureID_2 + "') Group By bd.ProductID");

            //ds.WriteXml("d:\\.Print2Brochures3.xml", XmlWriteMode.WriteSchema);


            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }

                TSold += row["Commited"] == DBNull.Value ? 0 : Convert.ToInt32(row["Commited"].ToString());

            }
            ds.Tables["Product"].AcceptChanges();
            Int32 TSold_2 = 0;
            foreach (DataRow row in ds.Tables["Product_2"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }

                TSold_2 += row["Commited"] == DBNull.Value ? 0 : Convert.ToInt32(row["Commited"].ToString());

            }
            ds.Tables["Product_2"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TSold", TSold);
            oRpt.SetParameterValue("TSold_2", TSold_2);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            /*
            oViewReport.sParameter_1 = ID;
            oViewReport.SetReport((int)Report.PurchaseOrder, CompanyID, "", true);
             */
        }
        public void PrintProductSizes()
        {

            frmViewReport oViewReport = new frmViewReport();
            BrochureListingSizes oRpt = new BrochureListingSizes();

            DataSet ds = new DataSet();


            
            ds.Tables.Add(oMySql.GetDataTable("Select * From Product  Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "BrochureDetail"));

            ds.WriteXml("PrintProductSizes.xml", XmlWriteMode.WriteSchema);


            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }

            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            /*
            oViewReport.sParameter_1 = ID;
            oViewReport.SetReport((int)Report.PurchaseOrder, CompanyID, "", true);
             */
        }
        public void PrintBrochureListingCost()
        {

            frmViewReport oViewReport = new frmViewReport();
            BrochureListingCost oRpt = new BrochureListingCost();

            DataSet ds = new DataSet();


            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "Brochure"));
            //  ds.Tables.Add(oMySql.GetDataTable("Select * From Product  Where CompanyID='" + CompanyID + "'", "Product"));
            //ds.Tables.Add(oMySql.GetDataTable("Select distinct(od.ProductID), p.Description, sum(od.Quantity) as Commited, p.InvCode  FROM OrderDetail od Join BrochureDetail bd On od.CompanyID=bd.CompanyID And od.ProductID=bd.ProductID Join Product p On od.CompanyID=p.CompanyID And od.ProductID=p.ProductID Where od.CompanyID='"+CompanyID+"' And bd.BrochureID='"+ID+"' Group By od.ProductID", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("CALL sp_brochure_listing_cost('" + CompanyID + "','" + ID + "')", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "BrochureDetail"));

           // ds.WriteXml("brochure_listing_cost3.xml", XmlWriteMode.WriteSchema);


            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                /*if (row["ProductID"].ToString() == "0001")
                {
                    row.Delete();
                    continue;
                }*/

                TSold += row["Sold"] == DBNull.Value ? 0 : Convert.ToInt32(row["Sold"].ToString());
                row["Cost"] = row["UnitCost"];

            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TSold", TSold);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            /*
            oViewReport.sParameter_1 = ID;
            oViewReport.SetReport((int)Report.PurchaseOrder, CompanyID, "", true);
             */
        }
        public void PrintSummaryReport()
        {
            Company oCompany = new Company();
            oCompany.CalculateAllCustomerTotalsByBrochure();
            
            frmViewReport oViewReport = new frmViewReport();
            BrochureSummaryReport oRpt = new BrochureSummaryReport();

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable("Select bc.CustomerID,b.Description,bc.BrochureID,sum(c.Signed) as Signed, sum(bc.Retail) as Retail,bc.Code,bc.ProfitPercent, Sum(bc.NoItems) as NoItems, Sum(bc.NoSellers) as NoSellers, count(bc.CustomerID) as Customers FROM BrochureByCustomer bc  Left Join Customer c On bc.CustomerID=c.CustomerID  And bc.CompanyID=c.CompanyID Left Join Brochure b On bc.BrochureID=b.BrochureID And bc.CompanyID=b.CompanyID Where bc.CompanyID='" + CompanyID + "' And b.Description is not null And bc.Retail >0 And Upper(Name) not like '%INTERNET%' Group By bc.BrochureID Order by bc.BrochureID", "Summary"));
            ds.Tables.Add(oMySql.GetDataTable("Select bc.CustomerID,b.Description,bc.BrochureID,sum(c.Signed) as Signed, sum(bc.Retail) as Retail,bc.Code,bc.ProfitPercent, Sum(bc.NoItems) as NoItems, Sum(bc.NoSellers) as NoSellers, count(bc.CustomerID) as Customers FROM BrochureByCustomer bc  Left Join Customer c On bc.CustomerID=c.CustomerID  And bc.CompanyID=c.CompanyID Left Join Brochure b On bc.BrochureID=b.BrochureID And bc.CompanyID=b.CompanyID Where bc.CompanyID='" + CompanyID + "' And b.Description is not null And Upper(Name) not like '%INTERNET%' Group By bc.BrochureID Order by bc.BrochureID", "SummaryTotal"));            
            //Console.Write("Select bc.CustomerID,b.Description,bc.BrochureID,sum(c.Signed) as Signed, sum(bc.Retail) as Retail,bc.Code,bc.ProfitPercent, Sum(bc.NoItems) as NoItems, Sum(bc.NoSellers) as NoSellers FROM BrochureByCustomer bc  Left Join Customer c On bc.CustomerID=c.CustomerID  And bc.CompanyID=c.CompanyID Left Join Brochure b On bc.BrochureID=b.BrochureID And bc.CompanyID=b.CompanyID Where bc.CompanyID='" + CompanyID + "' And b.Description is not null  Group By bc.BrochureID Order by bc.BrochureID");
            //ds.Tables.Add(oMySql.GetDataTable("Select * From Customer Where CompanyID='" + CompanyID + "' And CustomerID='" + ID + "'", "Customer"));           
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "'", "Brochure"));


         //   ds.WriteXml("PrintSummaryReport", XmlWriteMode.WriteSchema);

            oRpt.SetDataSource(ds);

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();

            /*
            oViewReport.sParameter_1 = ID;
            oViewReport.SetReport((int)Report.PurchaseOrder, CompanyID, "", true);
             */
            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }
        public void PrintBrochureProjected(Int32 ProjectedAmount)
        {
            frmViewReport oViewReport = new frmViewReport();

            ItemListingProjected oRpt = new ItemListingProjected();
            DataSet ds = new DataSet();

            
            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "'", "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And BrochureID='" + ID + "' And Excluded='0'", "BrochureDetail"));
            
            

            Product oProduct = new Product(CompanyID);
            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["BrochureDetail"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }
                if (!oProduct.Find(row["ProductID"].ToString()))
                    MessageBox.Show("Item not found " + row["ProductID"].ToString());
                TSold += (oProduct.Committed+oProduct.Sold);
            }
            ds.Tables["BrochureDetail"].AcceptChanges();

            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                row["Length"] = row["Received"];
                    
            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TotalCommited", TSold);
            oRpt.SetParameterValue("TotalProjected", ProjectedAmount);

           // ds.WriteXml("dataset80.xml", XmlWriteMode.WriteSchema);

      
            //oRpt.PrintToPrinter(1, true, 1, 100);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public void PrintBrochureProjected(Int32 ProjectedAmount, String Sql)
        {
            frmViewReport oViewReport = new frmViewReport();

            ItemListingProjected oRpt = new ItemListingProjected();
            DataSet ds = new DataSet();


            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' "  + Sql, "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' "+ Sql + " And Excluded='0' Group by ProductID", "BrochureDetail"));
            

            Product oProduct = new Product(CompanyID);
            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["BrochureDetail"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }
                if (!oProduct.Find(row["ProductID"].ToString()))
                    MessageBox.Show("Item not found " + row["ProductID"].ToString());
                TSold += (oProduct.Committed + oProduct.Sold);
            }
            ds.Tables["BrochureDetail"].AcceptChanges();

            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                row["Length"] = row["Received"];

            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TotalCommited", TSold);
            oRpt.SetParameterValue("TotalProjected", ProjectedAmount);

            // ds.WriteXml("dataset80.xml", XmlWriteMode.WriteSchema);


            //oRpt.PrintToPrinter(1, true, 1, 100);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public void PrintBrochureProjected(Int32 ProjectedAmount,List<string> Brochures)
        {
            
            //Sql Where Sentence
            String Sql = "";
            foreach (String br in Brochures)
            {
                if (Sql == "")
                    Sql += "BrochureID='" + br + "'";
                else
                    Sql += " Or BrochureID='" + br + "'";
            }
            if (Sql != "")
            {
                Sql = "And (" + Sql + ")";
            }


            
            frmViewReport oViewReport = new frmViewReport();

            ItemListingProjected oRpt = new ItemListingProjected();
            DataSet ds = new DataSet();


            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Brochure Where CompanyID='" + CompanyID + "' " + Sql, "Brochure"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' " + Sql + " And Excluded='0' Group by ProductID", "BrochureDetail"));


            Product oProduct = new Product(CompanyID);
            Int32 TSold = 0;
            foreach (DataRow row in ds.Tables["BrochureDetail"].Rows)
            {
                if (row["ProductID"].ToString().Trim() == "0001")
                {
                    row.Delete();
                    continue;
                }
                if (!oProduct.Find(row["ProductID"].ToString()))
                    MessageBox.Show("Item not found " + row["ProductID"].ToString());
                TSold += (oProduct.Committed + oProduct.Sold);
            }
            ds.Tables["BrochureDetail"].AcceptChanges();

            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                row["Length"] = row["Received"];

            }
            ds.Tables["Product"].AcceptChanges();

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("TotalCommited", TSold);
            oRpt.SetParameterValue("TotalProjected", ProjectedAmount);

            // ds.WriteXml("dataset80.xml", XmlWriteMode.WriteSchema);


            //oRpt.PrintToPrinter(1, true, 1, 100);
            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.ShowDialog();
        }
        public String GetBrochureByProduct(String ProductID)
        {
            DataRow rProduct = this.oMySql.GetDataRow("Select * From BrochureDetail Where CompanyID='" + CompanyID + "' And  ProductID='" + ProductID + "'", "BrochureDetail");

            if (rProduct == null)
            {
                return null;
            }
            else
                return rProduct["BrochureID"].ToString();
        }
        
        public String Description
        {
            get { return _Description; }
            set { _Description = value;  }
        }

        #region Classes & Enumerators
        public  class _Items : Hashlist //, IList
        {
            
            public DataTable dtItems = new DataTable("Detail");
            public _Items()
            {
                SetColumns();
            }
            public _Items(String CompanyID):base(CompanyID)
            {
                SetColumns();
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

                colWork = new DataColumn("InvCode", Type.GetType("System.String"));
                //  colWork.MaxLength = 10;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Price", Type.GetType("System.Double"));
                colWork.Caption = "Price";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);
                
                colWork = new DataColumn("PriceDist", Type.GetType("System.Double"));
                colWork.Caption = "PriceDist";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("ForeCast", Type.GetType("System.Double"));
                colWork.Caption = "ForeCast";
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                

                colWork = new DataColumn("Excluded", Type.GetType("System.Boolean"));
                //  colWork.MaxLength = 10;
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                /*  // add a row
                  DataRow row = dtKits.NewRow();
                  row["CustomerID"] = "2268";
                  row["KitID"] = "KT7022";

                  dtKits.Rows.Add(row);
                  */
                return;
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
                Detail["InvCode"] = "";
                Detail["ForeCast"] = 0;
                Detail["Excluded"] = false;
                

                dtItems.Rows.Add(Detail);
            }
            public void Load(String CompanyID, String BrochureID)
            {
                if (dtItems.Rows.Count > 0)
                    dtItems.Rows.Clear();

                DataView tDetail;
                tDetail = oMySql.GetDataView(String.Format("SELECT pb.BrochureID, pb.ProductID, p.Description, p.InvCode, pb.ForeCast, pb.Price, pb.PriceDist, pb.Excluded  FROM BrochureDetail pb left join Product p on pb.CompanyID=p.CompanyID And pb.ProductID=p.ProductID Where pb.CompanyID='{0}' And BrochureID='{1}'", CompanyID, BrochureID), "PB");

                
                foreach (DataRow Row in tDetail.Table.Rows)
                    {
                        DataRow Detail = dtItems.NewRow();


                        Detail["Description"] = Row["Description"].ToString();
                        Detail["ProductID"] = Row["ProductID"].ToString();
                        Detail["InvCode"] = Row["InvCode"].ToString();
                        Detail["ForeCast"] = Row["ForeCast"] == DBNull.Value?0.0:(Double)Row["ForeCast"];
                        Detail["Price"] = Row["Price"] == DBNull.Value ? 0.0 : (Double)Row["Price"];
                        Detail["PriceDist"] = Row["PriceDist"] == DBNull.Value ? 0.0 : (Double)Row["PriceDist"];
                        Detail["Excluded"] = (Boolean)Row["Excluded"];

                        dtItems.Rows.Add(Detail);

                    }
                
                AddEmpty();
            }
            public void Save(String CompanyID, String BrochureID)
            {
                
                this.Delete(CompanyID, BrochureID);
                foreach (DataRow _Row in dtItems.Rows)
                {
                    Item _Item = new Item();
                    if (_Row["ProductID"].ToString() == "")
                        continue;
                    _Item.BrochureID = BrochureID;
                    _Item.CompanyID  = CompanyID;
                    _Item.ProductID  = _Row["ProductID"].ToString();
                    _Item.Forecast   = _Row["ForeCast"]==DBNull.Value?0:(Double)_Row["ForeCast"];
                    _Item.Price      = _Row["Price"] == DBNull.Value ? 0 : (Double)_Row["Price"];
                    _Item.PriceDist = _Row["PriceDist"] == DBNull.Value ? 0 : (Double)_Row["PriceDist"];
                    _Item.Excluded =   (Boolean) _Row["Excluded"];

                    _Item.Insert();
                }
                dtItems.Rows.Clear();
            }
            public void Delete(String CompanyID, String BrochureID)
            {
                String Sql = "Delete from BrochureDetail where CompanyID='" + CompanyID + "' And BrochureID = '" + BrochureID + "'";
                oMySql.exec_sql(Sql);
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
            public String CustomerID;
            private String _Description;
            private String _ProductID;
            private Double _Forecast;
            private String _InvCode;
            public  String BrochureID;
            public Double PriceDist;
            public Double Price;
            public Boolean Excluded;


            Signature.Data.MySQL oMySql = Global.oMySql;

            public Item()
            {
                CompanyID = "";
                CustomerID = "";
                Description = "";
                ProductID = "";
                Price = 0.00;
                PriceDist = 0.00;
                Excluded = false;
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
                String Sql = String.Format("Insert into BrochureDetail (CompanyID, BrochureID, ProductID, ForeCast, Price, PriceDist, Excluded)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}')",
                    this.CompanyID, this.BrochureID, this.ProductID, this.Forecast, this.Price, this.PriceDist, this.Excluded ? '1' : '0');
                oMySql.exec_sql_afected(Sql);

            }
            public void Delete()
            {
                String Sql = "Delete from BrochureDetail where CompanyID='" + CompanyID + "' And  And ProductID = '" + ProductID + "'";
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
            public Double Forecast
            {
                get { return _Forecast; }


                set
                {
                    _Forecast = value;
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

        public class _Detail : List<Item>
        {
            public void Load()
            {
                Item oItem = new Item();
                oItem.BrochureID = "My Brochure";
                Add(oItem);
                Add(oItem);
                Add(oItem);
                Add(oItem);
            }
        }

        #endregion

        

    }
}
