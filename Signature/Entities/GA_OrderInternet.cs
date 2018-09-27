using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Signature.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Signature.Classes
{
    public class GA_OrderInternet:Order
    {
        
        public GA_OrderInternet(String CompanyID)
            : base(CompanyID)
        {
        }
        
        public bool UpdateStatus(GA_InternetOrderStatus Status)
        {
            oMySql.exec_sql(String.Format("Update ga_order  Set Status='{0}' Where OrderID='{1}'", (int)GA_InternetOrderStatus.Processed, this.IOrderID));
            return true;
        }
        public void UpdateOrderID(Int32 OrderID)
        {
            this.IOrderID = OrderID;
            oMySql.exec_sql(String.Format("Update Orders Set IOrderID='{0}' Where ID='{1}'", OrderID, ID));

        }
    }

    public class GA_InternetOrders:Company
    {
        
        public GA_OrderInternet oOrder;

        public String Teacher;

        public String CustomerID;

        public GA_InternetOrders(String CompanyID)  : base(CompanyID)
        {
        }
        
        public Boolean CreateOrder()
        {
            Boolean ProcessOk = true;

            //Saving Order to SQL Server
            oOrder.Clear();

            oOrder.CompanyID = CompanyID;
            oOrder.CustomerID = CustomerID;

            oOrder.Teacher = this.Teacher;
            oOrder.Type = OrderType.Scanned;

            //oOrder.Student = (oOrder.Fields["LastName"].Result + ", " + oOrder.Fields["FirstName"].Result).ToUpper();

            if (oOrder.Find(oOrder.Teacher, oOrder.Student))
            {
                return false;
            }

            //oOrder.Collected = Convert.ToDouble(Digit + "." + nDecimal);
            //oOrder.oCustomer.Find(CustomerID);

            String Code, Quantity;
            for (int i = 1; i <= 30; i++)
            {
                Code = "ABC";
                Quantity = "1";

                Code = Code.Trim();
                Quantity = Quantity.Trim();
                //oOrder.oProduct.CompanyID = _CompanyID;


                if (Code != "" && Code.Length >= 3)
                {
                    if (!oOrder.oProduct.Find(Code))
                    {
                        ProcessOk = false;
                        continue;
                    }
                    if (Quantity == "")
                    {
                        Quantity = "1";
                    }

                    Order.Item Item = new Order.Item();
                    Item.ProductID = oOrder.oProduct.ID;
                    Item.Quantity = Convert.ToInt32(Quantity.Trim().Replace(" ", ""));
                    Item.Description = oOrder.oProduct.Description;
                    Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);

                    if (oOrder.Items.Contains(oOrder.oProduct.ID))
                        oOrder.Items[oOrder.oProduct.ID].Quantity += Item.Quantity;
                    else
                        oOrder.Items.Add(oOrder.oProduct.ID, Item);

                }

            }
            oOrder.GetTotals();

            if (Math.Abs(oOrder.Diff) > 0)
            {
                ProcessOk = false;

            }
            return ProcessOk;
        }

        public void ImportOrders()
        {

            
            DataSet dsTables = new DataSet();
            
            dsTables.Tables.Add(this.oMySql.GetDataTable("Select * from ga_order Where Status='0'","Order"));
         //   dsTables.Tables.Add(this.oMySql.GetDataTable("Select * from ga_order Where Status='0'","OrderDetail"));


            Customer oCustomer = new Customer(this.CompanyID);
            GA_OrderInternet oOrder = new GA_OrderInternet(this.CompanyID);
            

            String strBody = "";
            if (dsTables.Tables["Order"].Rows.Count > 0)
            {
                oOrder.OpenPrinter(1);

            }
            
            
            foreach (DataRow row in dsTables.Tables["Order"].Rows)
            {

                if (!oOrder.Exist((Int32)row["OrderID"],ShoppingType.GA))
                {
                    oOrder.Clear();
                    oOrder.IOrderID = (Int32)row["OrderID"];
                    oOrder.UpdateStatus(GA_InternetOrderStatus.Processing);

                    oOrder.CustomerID = row["CustomerID"].ToString();
                    oOrder.Teacher = "RE-ORDER";
                    oOrder.Student = "RE-ORDER " + ((DateTime)row["Date"]).Month.ToString() + "/" + ((DateTime)row["Date"]).Day.ToString();

                    if (oOrder.Exist(oOrder.Teacher, oOrder.Student))
                    {
                        oOrder.Student += "(" + row["OrderID"].ToString() + ")";
                    }

                    
                    oOrder.oCustomer.Find(oOrder.CustomerID);
                    oOrder.oCustomer.Brochures.Load(this.CompanyID, oOrder.CustomerID);


                    oOrder.Type = OrderType.GA_Internet;
                    oOrder.Process = OrderProcess.Internet;

                    
                    oOrder.Items.Clear();

                    //    Console.Out.WriteLine(oOrder.Student);

                    DataTable dsDetail = oMySql.GetDataTable(String.Format("Select * from ga_order_detail Where OrderID='{0}'", row["OrderID"].ToString()), "Detail");

                    foreach (DataRow detailRow in dsDetail.Rows)
                    {

                        String ProductID = detailRow["ProductID"].ToString();

                        if (oOrder.oProduct.Find(ProductID))
                        {
                            Order.Item Item = new Order.Item();
                            Item.ProductID = oOrder.oProduct.ID;
                            Item.Quantity = (Int32)detailRow["Quantity"];
                            Item.Description = oOrder.oProduct.Description;
                            Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                            Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                            if (oOrder.Items.Contains(oOrder.oProduct.ID))
                                oOrder.Items[oOrder.oProduct.ID].Quantity += Item.Quantity;
                            else
                                oOrder.Items.Add(oOrder.oProduct.ID, Item);
                        }
                        else
                        {
                            this.SendErrorEmail("Item Error  " + oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student);
                        }

                    }
                    oOrder.GetTotals();
                    oOrder.Collected = 0.00; // oOrder.Retail;
                    oOrder.Save(OrderType.GA_Internet);

                    //Printing Packing Slips
                    if (oOrder.Find(Convert.ToInt32(oOrder.ID)))
                    {

                        oOrder.UpdateOrderID((Int32)row["OrderID"]);


                        //Create Shortage
                        Shortage oShortage = new Shortage(this.CompanyID);
                        //oShortage.oOrder = oOrder;
                        oShortage.OrderID = oOrder.ID;
                        oShortage.oCustomer = oOrder.oCustomer;
                        oShortage.CustomerID = oOrder.CustomerID;
                        oShortage.SchoolName = oOrder.oCustomer.Name;
                        oShortage.DayPhone = oOrder.oCustomer.PhoneNumber;
                        oShortage.TeacherName = oOrder.Teacher;
                        oShortage.StudentName = oOrder.Student;
                        oShortage.Address = oOrder.oCustomer.Address;
                        oShortage.City = oOrder.oCustomer.City;
                        oShortage.ZipCode = oOrder.oCustomer.ZipCode;
                        oShortage.State = oOrder.oCustomer.State;
                        oShortage.Type = "I";
                        oShortage.Detail = oOrder.NoItems.ToString() + " Item(s)" + "\n\r" + "\n\r";
                        oShortage.Detail += "OrderID      : " + oOrder.ID.ToString() + "\n\r";
                        oShortage.Detail += "Processed On : " + (row["Date"] == null ? "" : ((DateTime)row["Date"]).ToString()) + "\n\r";
                        oShortage.eMail = row["eMail"].ToString();
                        oShortage.Save();
                        // oShortage.Print(false);

                        oOrder.ShortageID = Convert.ToInt32(oShortage.ID);
                        oOrder.Print();

                    }
                    else
                    {
                        this.SendErrorEmail(oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + oOrder.LastError);
                    }

                    strBody += oOrder.ID.ToString() + " " + oOrder.Teacher.PadRight(30) + " " + oOrder.Student.PadRight(30).Substring(0, 30) + " " + oOrder.NoItems.ToString().PadRight(3).Substring(0, 3) + " " + oOrder.oCustomer.City + " " + oOrder.oCustomer.State + "\n\r";
                    Console.Out.WriteLine(DateTime.Now.ToString() + " " + oOrder.ID.ToString() + " " + oOrder.oCustomer.ID + " " + oOrder.oCustomer.Name);

                }
                
                
                if (!oOrder.UpdateStatus(GA_InternetOrderStatus.Processed))
                    {
                        this.SendErrorEmail(oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + oOrder.LastError);
                        return;
                    }
            }
            
            if (dsTables.Tables["Order"].Rows.Count > 0)
            {
                oOrder.ClosePrinter();
            }
             
            /*    //Sending Email
                    Smtp oSmtp = new Smtp();
                    oSmtp.Subject = "Emails processed " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                    if (this.CustomerID == "TEST")
                        oSmtp.To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
                    else
                        oSmtp.To = "\"Daisy Caro\" <daisy@sigfund.com>";
                    oSmtp.From = "\"Signature Server\" <server@sigfund.com>";

                    String  strTitle =  "Order ID             Teacher           Student         Items   City  State Ship/Del Packed\n\r";
                            strTitle += "------------------------------------------------------------------------------------------\n\r";    
                    oSmtp.Body = strTitle + strBody;
                    oSmtp.Send();
            }
            */
            dsTables.Dispose();
        }

        private void SendErrorEmail(String Text)
        {
            Smtp oSmtp = new Smtp();
            oSmtp.Subject = "Error Server... " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
            oSmtp.To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
            oSmtp.From = "\"Signature Server\" <server@sigfund.com>";
            oSmtp.Body = Text;
            oSmtp.Send();
            return;
        }
        
        private void PrintOrder(Int32 OrderID)
        {
            Order oOrder = new Order(this.CompanyID);
            if (oOrder.Find(OrderID))
                oOrder.Print();
        }
        
    }
        public enum GA_InternetOrderStatus
        {
            Pending     =   0,
            Processed   =   1,
            Processing  =   2
        }
}
