using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Signature.Reports;


namespace Signature.Classes
{
    public class Inventory : Product 
    {

        public enum InventoryType
        {
            RollBack        = 0,
            Commit          = 1
        }

        //Methods
        public Inventory(String CompanyID):base(CompanyID)
        {            
            this.CompanyID = CompanyID;
        } //Constructor

        public Inventory() : base()
        {
            this.CompanyID = base.CompanyID;
        } //Constructor

        public void Update(Order oOrder, InventoryType Type)
        {
            #region Rollback
            if (Type == InventoryType.RollBack)
            {
                if (oOrder != null && !oOrder.oCustomer.oCustomerExtra.isPineValley)
                {
                    if (oOrder.CurrentDetail != null)
                    {
                        foreach (DataRow row in oOrder.CurrentDetail.Rows)
                        {
                            if (this.Find(row["ProductID"].ToString()))
                            {
                                this.Committed -= (Int32)row["Quantity"];
                                this.UpdateInventory();

                            }
                        }
                        //RollBack Prizes
                        DataView oPrizes = oOrder.oPrize.GetItems(oOrder.oCustomer.PrizeID, oOrder.NoItems);
                        foreach (DataRowView drow in oPrizes)
                        {
                            if (this.Find(drow["ProductID"].ToString()))
                            {
                                this.Committed--;
                                this.UpdateInventory();
                            }
                        }

                        
                        //Rolling Back Boxes
                        if (!oOrder.Packed)
                        {
                            DataView CurrentBoxes = oMySql.GetDataView(String.Format("Select * From OrderBoxes Where OrderID='{0}'", oOrder.ID), "Boxes");
                            foreach (DataRowView row in CurrentBoxes)
                            {
                                if (this.Find(row["ProductID"].ToString()))
                                {
                                    this.Committed -= (Int32)row["Quantity"];
                                    this.UpdateInventory();

                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Commit  
            else if (Type == InventoryType.Commit)
            {
                if (!oOrder.oCustomer.oCustomerExtra.isPineValley)
                {
                    foreach (Order.Item Row in oOrder.Items)
                    {
                        if (Row.Quantity > 0)
                        {
                            if (this.Find(Row.ProductID))
                            {
                                this.Committed += Row.Quantity;
                                this.UpdateInventory();
                            }
                        }
                    }
                    //Commit Prizes
                    DataView oPrizes = oOrder.oPrize.GetItems(oOrder.oCustomer.PrizeID, oOrder.NoItems);
                    foreach (DataRowView drow in oPrizes)
                    {
                        if (this.Find(drow["ProductID"].ToString()))
                        {
                            this.Committed++;
                            this.UpdateInventory();
                        }
                    }

                    //Saving Boxes
                    foreach (Order.OrderBox Row in oOrder.Boxes)
                    {
                        if (Row.Quantity > 0)
                        {
                            if (this.Find(Row.ProductID))
                            {
                                this.Committed += Row.Quantity;
                                this.UpdateInventory();
                            }
                        }
                    }
                }
            }
            #endregion
        }

        public void Update(Shortage oShortage, InventoryType Type)
        {
            if (oShortage != null)
            {
                #region Commit
                if (Type == InventoryType.Commit)
                {
                    //MessageBox.Show("Commiting...");
                    foreach (DataRow drow in oShortage.Items.Detail.Rows)
                    {
                        if (base.Find(drow["ProductID"].ToString()))
                        {
                            //MessageBox.Show(drow["Quantity"].ToString());
                            this.Sold += Convert.ToInt32(drow["Quantity"].ToString());
                            this.UpdateInventory();
                        }
                    }
                }
                #endregion
                #region Rollback
                if (Type == InventoryType.RollBack)
                {
                    if (oShortage != null)
                    {
                        
                        if (oShortage.currentDetail != null)
                        {
                            foreach (DataRow drow in oShortage.currentDetail.Rows)
                            {
                                if (base.Find(drow["ProductID"].ToString()))
                                {
                                    //MessageBox.Show(drow["Quantity"].ToString());
                                    this.Sold -= (Int32)drow["Quantity"];
                                    this.UpdateInventory();
                                }
                            }
                        }
                    }
                }
                #endregion
            }   
        }

        public void Update(Purchase oPurchase, InventoryType Type)
        {
            #region Commit  
            if (Type == InventoryType.Commit) //Update Purchases
            {
                if (oPurchase.Items.dtItems.Rows.Count > 0)
                {
                    foreach (DataRow _Row in oPurchase.Items.dtItems.Rows)
                    {
                        if (_Row["ProductID"].ToString() == "")
                            continue;
                        if (this.Find(_Row["ProductID"].ToString()))
                        {
                            this.ONPO += (Int32)_Row["Cases"] * this.Size + (Int32)_Row["Units"];
                            this.UpdateInventory();
                        }
                    }
                    oMySql.exec_sql(String.Format("Update Purchase Set Updated = 'Y' Where CompanyID='{0}' And PurchaseID='{1}' ", this.CompanyID, oPurchase.ID));
                }
                else
                    MessageBox.Show("Nothing to process...");
            }
            #endregion
            #region RollBack
            if (Type == InventoryType.RollBack) //Update Receive Documents
            {
                DataTable dtInv = oMySql.GetDataTable(String.Format("Select * from ReceiveDetail Where CompanyID='{0}' And PurchaseID='{1}' And Updated='N'", this.CompanyID, oPurchase.ID), "Inv");

                foreach (DataRow _Item in dtInv.Rows)
                {
                    if (this.Find(_Item["ProductID"].ToString()))
                    {
                        //MessageBox.Show("Product:"+_Item["ProductID"].ToString());
                        this.ONPO -= (Int32)_Item["Quantity"];
                        this.Received += (Int32)_Item["Quantity"];
                        this.UpdateInventory();

                        //This put Update on Receive Detail
                        oMySql.exec_sql(String.Format("Update ReceiveDetail Set Updated = 'Y' Where CompanyID='{0}' And ReceiveID='{1}' And ProductID='{2}'", this.CompanyID, _Item["ReceiveID"].ToString(), _Item["ProductID"].ToString()));

                    }

                }
            }
            #endregion
        }

        public void Update(Invoice oInvoice, InventoryType Type)
        {
            #region Commit  
            if (Type == InventoryType.Commit)
            {
               if (!oInvoice.Invoiced && !oInvoice.oCustomerExtra.isPineValley)
                {
                    //Update Quantity Invoiced
                    oMySql.exec_sql(String.Format("Update Orders Set Invoiced='1' Where CompanyID='{0}' And CustomerID='{1}'", oInvoice.CompanyID, oInvoice.ID));
                    oMySql.exec_sql(String.Format("Update OrderDetail od, Customer c Set od.QuantityInvoiced = od.Quantity   Where od.CompanyID='{0}' And od.CustomerID='{1}'  And od.CompanyID=c.CompanyID And od.CustomerID=c.CustomerID", oInvoice.CompanyID, oInvoice.ID));

                    DataSet ds = new DataSet();
                    ds.Tables.Add(oMySql.GetDataTable("SELECT distinct(pd.ProductID),sum(QuantityInvoiced) as Quantity FROM OrderDetail pd Where pd.CompanyID='" + oInvoice.CompanyID + "' And CustomerID='" + oInvoice.ID + "' And QuantityInvoiced=0 Group By pd.ProductID", "Invoice"));
                    ds.Tables.Add(oMySql.GetDataTable("SELECT c.PrizeID, Prize as ProductID, if(pd.BreakLevel is null,1,pd.BreakLevel) as BreakLevel, count(Prize) as Quantity, o.Invoiced FROM Orders o Left Join Customer c On o.CompanyID=c.CompanyID And o.CustomerID=c.CustomerID Left Join PrizeDetail pd On o.CompanyID=pd.CompanyID and c.PrizeID=pd.PrizeID and o.Prize=pd.ProductID Where o.CompanyID='" + oInvoice.CompanyID + "' And o.CustomerID='" + oInvoice.ID + "' And Prize != '' And c.PrizeID is not null Group By c.PrizeID, Prize", "OrderPrize"));
                    Product oProduct = new Product(this.CompanyID);

                    //Invoiced Product
                    foreach (DataRow row in ds.Tables["Invoice"].Rows)
                    {
                        if (oProduct.Find(row["ProductID"].ToString()))
                        {

                            oProduct.Committed -= Convert.ToInt32(row["Quantity"].ToString());
                            if (oProduct.Committed < 0)
                                oProduct.Committed = 0;
                            oProduct.Sold += Convert.ToInt32(row["Quantity"].ToString());
                            oProduct.UpdateInventory();
                        }

                    }

                   //Invoice Prices
                    Prize oPrize = new Prize(oInvoice.CompanyID);
                    foreach (DataRow row in ds.Tables["OrderPrize"].Rows)
                    {
                            DataView oPrizes = oPrize.GetItems(row["PrizeID"].ToString(), Convert.ToInt32(row["BreakLevel"].ToString()));
                                foreach (DataRowView drow in oPrizes)
                                {
                                    if (oProduct.Find(drow["ProductID"].ToString()))
                                    {
                                        //MessageBox.Show(drow["ProductID"].ToString() + "--" + row["Quantity"].ToString());
                                        oProduct.Committed -= Convert.ToInt32(row["Quantity"].ToString()); // *Convert.ToInt32(drow["Quantity"].ToString());
                                        if (oProduct.Committed < 0)
                                            oProduct.Committed = 0;
                                        oProduct.Sold += Convert.ToInt32(row["Quantity"].ToString()); // * Convert.ToInt32(drow["Quantity"].ToString());
                                        oProduct.UpdateInventory();
                                    }
                                }
                     
                    }
                }
            }
            #endregion
        }

        public void Update(CoverSheet oCover, InventoryType Type) //Brochure
        {
            Product oProduct = new Product(CompanyID);
            Brochure oBrochure = new Brochure(CompanyID);
            Customer oCustomer = new Customer(CompanyID);
            oCustomer.Find(oCover.CustomerID);
            oCustomer.Brochures.Load(CompanyID, oCover.CustomerID);
            foreach (BrochureByCustomer oBC in oCustomer.Brochures)
            {
                if (oBrochure.Find(oBC.BrochureID))
                {
                    if (oProduct.Find(oBrochure.ProductID))
                    {

                        if (Type == InventoryType.RollBack)
                        {
                            oProduct.OnHand += (Int32)(oCover.PreviousNoLetters * 1.15);
                            oProduct.Sold -= (Int32)(oCover.PreviousNoLetters * 1.15);
                            oProduct.UpdateInventory();
                        }
                        else
                        {
                            oProduct.OnHand -= (Int32)(oCover.N_Letters * 1.15);
                            oProduct.Sold += (Int32)(oCover.N_Letters * 1.15);
                            oProduct.UpdateInventory();
                        }
                    }
                }
            }
        }       

    }
}
