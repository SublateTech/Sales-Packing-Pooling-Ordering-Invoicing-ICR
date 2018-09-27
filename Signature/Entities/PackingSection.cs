using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Forms;
using Signature.Data;



namespace Signature.Classes
{
    public class PackingSection:Packing
    {
        internal new SqlBuilder oBuild; //Reuqired
        internal new String TableName = "OrderSection";
        
        // Properties
        public String _ID;
        
        public new String ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        
        public String SectionID;
        public Boolean PackedScanned;
        public Int32 Quantity;
        public Int32 Seq;
        public Boolean ItHasPendingSections = false;



        //Methods

        public PackingSection(String CompanyID, String CustomerID):base(CompanyID)
        {
            this.CompanyID  = CompanyID;
            this.CustomerID = CustomerID;
        } //Constructor

        public PackingSection(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        
        public new bool View()
        {
            frmViewStudent oView = new frmViewStudent(this.CompanyID,this.CustomerID, this.Teacher);
            oView.ShowDialog();
            if (oView.SelectedID != "")
            {
                ID = oView.SelectedID;
                CustomerID = oView.CustomerID;
                CompanyID = oView.CompanyID;
                Teacher = oView.Teacher;
                return true;
            }
            ID = "";
            return false;
        }

        public bool Find(int OrderID, string PackID, String SectionID, Boolean IncludePendingSections)
        {
            //Header

            this.ItHasPendingSections = false;
            if (!FindHeader(OrderID))
                 return false;

            this.PackID = PackID;
            this.SectionID = SectionID;
            
            if (IncludePendingSections)
             {
                 DataTable oData = this.GetPendingSections();
                 if (oData.Rows.Count > 0)
                 {
                     this.ItHasPendingSections = true;
                     foreach (DataRow row in oData.Rows)
                     {
                         Find(OrderID, PackID, SectionID);
                     }
                 }

             }


             return Find(OrderID, PackID, SectionID);
        }

       public void ClosePendingSections()
        {
            DataTable oData = this.GetPendingSections();
            if (oData.Rows.Count > 0)
            {
                this.ItHasPendingSections = true;
                foreach (DataRow row in oData.Rows)
                {
                    this.SectionID = row["SectionID"].ToString();
                    if (Find())
                    {
                        this.PackedScanned = true;
                        this.Update();
                    }
                }
            }
        }

        public  bool Find(int OrderID, string PackID, String SectionID)
        {
            String Sql = "";
            
            //Detail
            //Detail.Clear();
            //Items.Clear();
            LocalItems = 0;

            DataView tDetail = new DataView();
            if (PackID != "0" && PackID != "")
            {
                Sql = "Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Where OrderID='" + base.OrderID + "' And PackID='" + PackID + "' And p.SectionID='"+SectionID+"'";
                tDetail = oMySql.GetDataView(Sql, "Detail");
                //tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Left Join Card c On d.CompanyID=c.CompanyID And d.ProductID=c.ProductID  Where OrderID='" + ID + "' And PackID='" + PackID + "' And c.ProductID is null", "Detail");
            }
            else
            {
                
                tDetail = oMySql.GetDataView("Select d.ProductID,d.Quantity, p.Description,p.BarCode,p.BarCode_2,p.BarCode_3,p.InvCode  From OrderDetail as d Left Join Product as p On d.ProductID=p.ProductID And d.CompanyID=p.CompanyID Where OrderID='" + ID + "'", "Detail");
            }

            
            ///Adding Prizes
            oPrize.Find(oCustomer.PrizeID);
            if (oPrize.PackID != PackID)
                return true;

            
            DataView dvPrizes = oPrize.GetItems(oCustomer.PrizeID, NoItems,SectionID);

            foreach (DataRow Row in dvPrizes.Table.Rows)
            {
                DataRow row = tDetail.Table.NewRow();
                row["ProductID"] = Row["ProductID"];
                row["InvCode"] = Row["InvCode"];
                
                row["Quantity"] = 1;
                row["BarCode"] = Row["BarCode"];
                row["BarCode_2"] = Row["BarCode_2"];
                row["BarCode_3"] = Row["BarCode_3"];
                row["Description"] = Row["Description"];
                tDetail.Table.Rows.Add(row);
            }

            foreach (DataRow Row in tDetail.Table.Rows)
            {

                ScanItem Detail = new ScanItem();

                

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
                    Global.ShowNotifier("This same BarCode is already in this order: " + Row["ProductID"].ToString());
                    ScanItems.Add(Row["ProductID"].ToString(), Detail);
                }
                else
                    ScanItems.Add(Row["BarCode"].ToString(), Detail);

                LocalItems += Detail.Quantity;

            }
            oPrize.Find(oCustomer.PrizeID);
            //if (oPrize.PackID != PackID)
            //    return true;

            /*
            if (SectionID == "X")
            {

                DataView dvPrizes = oPrize.GetItems(oCustomer.PrizeID, base.NoItems, SectionID);

                foreach (DataRow Row in dvPrizes.Table.Rows)
                {
                    if (!((Boolean)Row["IsCompound"]))
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
            }*/
            return true;
            
        }


        private Boolean LoadPendingSections()
        {
            DataTable oData = this.GetPendingSections();
            if (oData.Rows.Count > 0)
            {
                
                return true;
            }
            else
                return false;
            
        }
        
        public virtual bool CreateSections()
        {
            if (!RecordsExist())
            {

                String Sql = String.Format("Insert {0} Select 0,{1},'{2}','{3}',SectionID,0,0,Seq from Sections Where CompanyID='{4}'", this.TableName, base.OrderID, base.CompanyID, this.PackID,this.CompanyID);
                oMySql.exec_sql(Sql);

                Sql = String.Format("SELECT od.OrderID, p.SectionID, count(*) as NoItems, s.Seq FROM OrderDetail od Left Join Product p On od.CompanyID=p.CompanyID And od.ProductID=p.ProductID Left Join Sections s On s.CompanyID=p.CompanyID And s.SectionID=p.SectionID Where OrderID={0} And PackID='{1}' Group by p.SectionID", this.OrderID,this.PackID);
                DataTable rProduct = this.oMySql.GetDataTable(Sql, "Sections");

                if (rProduct == null)
                {
                    return false;
                }

                foreach (DataRow row in rProduct.Rows)
                {
                    this.OrderID = Convert.ToInt32(row["OrderID"].ToString());
                    //this.PackID = this.PackID;
                    this.SectionID = row["SectionID"].ToString();
                    //this.Find();
                    this.Quantity = Convert.ToInt32(row["NoItems"].ToString());
                    if (this.Quantity == 0 && this.SectionID == "1" && this.PrizeID !="")
                    {
                        this.Quantity = 1;
                    }
                                   

                    this.Seq = Convert.ToInt32(row["Seq"].ToString());
                    this.PackedScanned = false;
                    this.Update();
                }
            }
            return true;
        }
        
        public new bool Find(Int32 OrderID)
        {
            this.ID = "";
         
            if (StudentID == 0)
                return false;

            //MessageBox.Show("Select * From Product Where ProductID='" + ProductID + "'");
            DataRow rProduct = this.oMySql.GetDataRow("Select * From Student Where StudentID='" + StudentID.ToString() + "'", "Student");

            if (rProduct == null)
            {
                
                return false;
            }

            this.ID = rProduct["CompanyID"].ToString();
            this.TeacherID = (Int32)rProduct["TeacherID"];
            return true;
        }

        public virtual bool Find()
        {
            DataRow rProduct = this.oMySql.GetDataRow("Select * From OrderSection Where OrderID='" + this.OrderID.ToString() + "' And SectionID='"+this.SectionID+"'  And PackID='"+this.PackID+"'", "Section");
            if (rProduct == null)
            {
                this.SectionID = "";
                return false;
            }

            this.PackID = rProduct["PackID"].ToString();
            this.SectionID = rProduct["SectionID"].ToString();
            this.Seq = (Int32)rProduct["Seq"];
            this.Quantity = (Int32)rProduct["NoItems"];
            this.PackedScanned = (Boolean)rProduct["PackedScanned"];
            return true;
        }

        public virtual String  GetOrderCloserSection()
        {
            DataRow rProduct = this.oMySql.GetDataRow("SELECT s.SectionID, s.CloseOrder FROM OrderSection o Left Join Sections s On o.CompanyID=s.CompanyID and o.SectionID=s.SectionID Where CloseOrder = 1 And OrderID=" + this.OrderID + " And PackID='" + this.PackID+"'", "Section");
            if (rProduct == null)
            {
                return "";
            }
            return rProduct["SectionID"].ToString(); 
        }

        public virtual DataTable GetPendingSections()
        {
            //String Sql = "SELECT s.SectionID, s.Description, o.PackedScanned, o.NoItems FROM OrderSection o Left Join Sections s On o.CompanyID=s.CompanyID and o.SectionID=s.SectionID Where o.PackedScanned = 0 and o.NoItems >0 And s.Seq < " + this.Seq;
            DataTable rProduct = this.oMySql.GetDataTable("SELECT s.SectionID, s.Description, o.PackID, o.PackedScanned, o.NoItems FROM OrderSection o Left Join Sections s On o.CompanyID=s.CompanyID and o.SectionID=s.SectionID Where o.OrderID="+this.OrderID.ToString()+" And  o.PackID = '"+this.PackID+"' And  o.PackedScanned = 0 and o.NoItems >0 And s.Seq < " + this.Seq, "Section");
            if (rProduct == null)
            {
                return null;
            }
            return rProduct;
        }

        public override void Clear()
        {
            base.Clear();
            this.SectionID = "";
            this.Quantity = 0;
            this.PackedScanned = false;
        }
        
        public new virtual void Save()
        {

            if (Exists() && this.StudentID != 0)
                Update();
            else
                Insert();


        }
        public new virtual void Update()
        {
            FillFields();
            String Sql = oBuild.Update(String.Format("Where OrderID='{0}' And SectionID='{1}' And PackID='{2}'", this.OrderID, this.SectionID, this.PackID));
            oMySql.exec_sql(Sql);
        }
        public new virtual void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert()).ToString();

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "SectionID",
                "CompanyID",
                "PackID",
                "OrderID",
                "NoItems",
                "PackedScanned",
                "Seq"
                
                },
                new Object[] {
                    this.SectionID,
                    this.CompanyID,
                    this.PackID,
                    this.OrderID,
                    this.Quantity,
                    this.PackedScanned,
                    this.Seq
                    });
        }

        public bool RecordsExist()
        {
            String Sql = String.Format("Select count(*) from {0} Where OrderID='{1}' And PackID='{2}'", TableName, this.OrderID,this.PackID);
            if ((oMySql.exec_sql_no(Sql) == 0))
                return false;
            else
                return true;
        }
        public void DeleteRecords()
        {
            String Sql = String.Format("Delete from {0} Where OrderID='{1}' And PackID='{2}'", TableName, this.OrderID,this.PackID);
            oMySql.exec_sql(Sql);
        }

        public new bool Exists()
        {
            String Sql = String.Format("Select count(*) from {0} Where OrderID='{1}' And Section='{2}'  And PackID='{3}'", TableName, this.OrderID, this.SectionID,this.PackID);
            if ((oMySql.exec_sql_no(Sql) == 0))
                return false;
            else
                return true;
        }
        public new virtual void Delete()
        {
              String Sql = String.Format("Delete From {0} Where StudentID='{1}'", this.TableName, this.StudentID);
             // MessageBox.Show(Sql);  
            oMySql.exec_sql(Sql);
            
            
        }
    }
}
