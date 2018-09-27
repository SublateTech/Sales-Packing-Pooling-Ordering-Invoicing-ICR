using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Signature.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Signature.Classes
{
    public class OrderInternet:Order
    {
        public Int32 Discount=0;
        public Int32 Shipping=0;
        public String AprovalCode=String.Empty;
        
        public OrderInternet(String CompanyID)
            : base(CompanyID)
        {
        }
        
        public bool UpdateStatus(InternetOrderStatus Status, String Database)
        {
            
            oMySql.ChangeDatabase(Database);
         //   oMySql.ChangeDatabase("69.89.31.153", "signatv9_sa", "sa", "signatv9_SigWeb");
            oMySql.exec_sql(String.Format("Update cart_orders  Set Status='{0}' Where id='{1}'", (int)InternetOrderStatus.Processed, this.IOrderID));
            oMySql.ChangeDatabase("SigData");
          //  oMySql.ChangeDatabase("192.168.254.65", "SigData", "SigData009", "SigData");
            
            return true;
        }
        public void UpdateOrderID(Int32 OrderID, ShoppingType Shoppingcart)
        {
            this.IOrderID = OrderID;
            oMySql.exec_sql(String.Format("Update Orders Set IOrderID='{0}', IShoppID='{1}' Where ID='{2}'", OrderID,(int) Shoppingcart,ID));

        }
    }

    public class InternetOrders:Company
    {
        
        public OrderInternet oOrder;
        public String Teacher;
        public String CustomerID;
        

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

        public void ImportOrders(String Database, ShoppingType ShoppingCart)
        {
            this.CompanyID = Global.Company;
            this.CustomerID = Global.ICustomer;
            ImportOrders(Database, ShoppingCart, this.CompanyID, this.CustomerID);
        }
        
        public void ImportOrders(String Database, ShoppingType ShoppingCart,String CompanyID, String CustomerID)
        {
            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;


            Customer oCustomer = new Customer(this.CompanyID);

            /*
            if (!oMySql.ChangeDatabase("69.89.31.153", "signatv9_sa", "sa", "signatv9_SigWeb"))
            {
                MessageBox.Show("We cannot open this database");
                return;
            }
            */
            oMySql.ChangeDatabase(Database);

                //DataTable dtOrders = oRemoteMysql.GetDataTable("SELECT * FROM cart_orders Where Status='"+(int)InternetOrderStatus.Pending+"' And open='n'","Order");
            DataSet dsTables = oMySql.GetDataset("CALL get_tables();");

            //MessageBox.Show(dsTables.Tables["Table6"].Rows.Count.ToString());
            Console.WriteLine(ShoppingCart.ToString() + " " + dsTables.Tables["Table6"].Rows.Count.ToString()+ " order(s)");

            //return;
            //192.168.254.65
            /*
            if (!oMySql.ChangeDatabase(this.Local, "SigData", "SigData009", "SigData"))
            {
                return;
            }*/

            oMySql.ChangeDatabase("SigData");

            dsTables.Tables["table"].TableName  = "Customer";
            dsTables.Tables["table1"].TableName = "Student";
            dsTables.Tables["table2"].TableName = "CreditCard";
            dsTables.Tables["table3"].TableName = "Shipment";
            dsTables.Tables["table4"].TableName = "Detail";
            dsTables.Tables["table5"].TableName = "Product";
            dsTables.Tables["table6"].TableName = "Order";
            dsTables.Tables["table7"].TableName = "CustomCard";
            //dsTables.Tables.Add(dtOrders);

            
             DataRelation custOrderRel = dsTables.Relations.Add("OrdersCust",
                 dsTables.Tables["Order"].Columns["customer"],   
                 dsTables.Tables["Customer"].Columns["id"],false);
             
             DataRelation studentOrderRel = dsTables.Relations.Add("OrdersStudent",
                 dsTables.Tables["Order"].Columns["id"],
                 dsTables.Tables["Student"].Columns["order_id"]);

             DataRelation detailOrderRel = dsTables.Relations.Add("OrdersDetail",
                  dsTables.Tables["Order"].Columns["id"],
                  dsTables.Tables["Detail"].Columns["order_id"]);

             DataRelation creditcardOrderRel = dsTables.Relations.Add("OrdersCreditcard",
                   dsTables.Tables["Order"].Columns["id"],
                   dsTables.Tables["CreditCard"].Columns["order_id"]);

             DataRelation shipOrderRel = dsTables.Relations.Add("OrdersShip",
                  dsTables.Tables["Order"].Columns["id"],
                  dsTables.Tables["Shipment"].Columns["order_id"]);

            DataRelation productDetailRel = dsTables.Relations.Add("DetailProduct",
                  dsTables.Tables["Detail"].Columns["product_id"],
                  dsTables.Tables["Product"].Columns["ProductID"],false);

                        
            DataRelation productCustomCard = dsTables.Relations.Add("Custom_Card",
                  dsTables.Tables["Detail"].Columns["id"],
                  dsTables.Tables["CustomCard"].Columns["ticket_id"], false);

            

            //MySQL.conn = null;  
            OrderInternet oOrder = new OrderInternet(this.CompanyID);
            
            //int i = 0;

            String strBody = "";
            String strBodyPrizes = "";
            if (dsTables.Tables["Order"].Rows.Count > 0)
            {
                oOrder.OpenPrinter(3);

            }

            

            
            foreach (DataRow row in dsTables.Tables["Order"].Rows)
            {
                oOrder.CustomerID = CustomerID;
                String StudentName = "";
                String TeacherName = "";
                String Customized = "";
                

                
                if (row.GetChildRows(studentOrderRel).Length > 0)
                    TeacherName = row.GetChildRows(studentOrderRel)[0]["school_name"].ToString().ToUpper().Replace("\"", " ").Replace("'", " ");
                
                if (TeacherName.Trim().Length == 0)
                {
                    TeacherName = "GENERAL CUSTOMER";
                    StudentName = ((row.GetChildRows(shipOrderRel)[0]["FirstName"].ToString().Length > 0 ? (row.GetChildRows(shipOrderRel)[0]["FirstName"].ToString().Substring(0, 1)) : "?") + "." + row.GetChildRows(shipOrderRel)[0]["LastName"].ToString()).ToUpper().Replace("\"", " ").Replace("'", " ");
                }
                else
                {

                    String Initial = "";
                    if (row.GetChildRows(shipOrderRel)[0]["FirstName"].ToString() != "")
                        Initial = row.GetChildRows(shipOrderRel)[0]["FirstName"].ToString().Substring(0, 1);
                    
                    StudentName = ( Initial + "." + row.GetChildRows(shipOrderRel)[0]["LastName"].ToString() + "-" +
                                  row.GetChildRows(studentOrderRel)[0]["student_name"].ToString()).ToUpper().Replace("\"", " ").Replace("'", " ");

                    
                    String Result = oCustomer.GetSchool(TeacherName, row.GetChildRows(studentOrderRel)[0]["school_city"].ToString());

                    if (oCustomer.Find(Result))
                        TeacherName = oCustomer.Name.PadRight(30).Substring(0,24)+ " " + oCustomer.ID.Trim();
                    else
                        TeacherName = TeacherName.PadRight(30).Substring(0, 24) + " " + "00000";

                //    Console.Out.WriteLine(TeacherName + " " + Global.getState(row.GetChildRows(studentOrderRel)[0]["school_city"].ToString().ToUpper() ));
                }
                Console.Out.WriteLine(DateTime.Now.ToString() + "-" + TeacherName);
              //  continue;

                
                if (!oOrder.Exist((Int32)row["id"], ShoppingCart ))
                {
                    if (oOrder.Exist((ShoppingCart == ShoppingType.WLOT)? ShoppingType.WLOT.ToString():TeacherName,StudentName))
                    {
                        if (StudentName.Length >= 33)
                            StudentName = StudentName.Substring(0, 33);
                        StudentName += "-"+row["id"].ToString();
                    }

                    oOrder.Clear();

                    oOrder.CustomerID = CustomerID;
                    oOrder.oCustomer.Find(oOrder.CustomerID);
                    oOrder.oCustomer.Brochures.Load(this.CompanyID, oOrder.CustomerID);


                    oOrder.Type = OrderType.Internet;
                    oOrder.Process = OrderProcess.Internet;

                    oOrder.IOrderID = (Int32)row["id"];
                    oOrder.Teacher = (ShoppingCart == ShoppingType.WLOT)? ShoppingType.WLOT.ToString():TeacherName;
                    oOrder.Student = StudentName.Replace("\"", " ").Replace("'", " "); ;
                    


                    oOrder.Items.Clear();

                //    Console.Out.WriteLine(oOrder.Student);

                    foreach (DataRow detailRow in row.GetChildRows(detailOrderRel))
                    {
                        
                       // Console.Out.WriteLine("Product ID: " + detailRow["product_id"]);
                        // Console.Out.WriteLine("Quantity: " + detailRow["quantity"]);

                        //Console.Out.WriteLine("Description: " + oOrder.oProduct.Description);

                        String ProductID = detailRow["product_id"].ToString();

                        if (IsMagazine(ProductID))
                        {
                            if (detailRow.GetChildRows(productDetailRel).Length == 0)
                            {
                                this.SendErrorEmail(ShoppingCart.ToString()+" Item Error  " + oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + " Item:" + ProductID);
                                continue;
                            }
                            else
                                ProductID = GetMagazineCode(ProductID, (Double)detailRow.GetChildRows(productDetailRel)[0]["Price"]);
                        }



                        if (oOrder.oProduct.Find(ProductID))
                        {
                           // Console.Out.WriteLine("Price: " + oOrder.oProduct.Price.ToString());

                            Order.Item Item = new Order.Item();
                            Item.ProductID = oOrder.oProduct.ID;
                            Item.Quantity = (Int32)detailRow["quantity"];
                            Item.Description = oOrder.oProduct.Description;
                            Item.Price = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);
                            Item.PackID = oOrder.oProduct.PackID(oOrder.oCustomer);

                            // Custom Card
                            foreach (DataRow DetailRow in detailRow.GetChildRows(productCustomCard))
                            {

                                
                             Customized = "(Customized)";

                             //   if (Item.ProductID != DetailRow["product_id"].ToString())
                             //       continue;

                                Ticket oTicket = new Ticket(oOrder.CompanyID);
                                oTicket.OrderID = Convert.ToInt32(oOrder.ID);
                                oTicket.Quantity = (Int32)detailRow["quantity"];  //1; Modified on 10/06/2001
                                oTicket.ProductID = DetailRow["product_id"].ToString();

                                //Line 1
                                Ticket.Line oLine = new Ticket.Line();
                                oLine.Text = (DetailRow["Line_1"].ToString().Length > 40 ? DetailRow["Line_1"].ToString().Substring(0, 39) : DetailRow["Line_1"].ToString()).ToUpper();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_1", oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = (DetailRow["Line_2"].ToString().Length > 40 ? DetailRow["Line_2"].ToString().Substring(0, 39) : DetailRow["Line_2"].ToString()).ToUpper();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_2", oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = (DetailRow["Line_3"].ToString().Length > 40 ? DetailRow["Line_3"].ToString().Substring(0, 39) : DetailRow["Line_3"].ToString()).ToUpper();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_3", oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = (DetailRow["Line_4"].ToString().Length > 40 ? DetailRow["Line_4"].ToString().Substring(0, 39) : DetailRow["Line_4"].ToString()).ToUpper();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_4", oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = (DetailRow["Line_5"].ToString().Length > 40 ? DetailRow["Line_5"].ToString().Substring(0, 39) : DetailRow["Line_5"].ToString()).ToUpper();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_5", oLine);

                                // Console.Out.WriteLine("Quantity: " + detailRow["quantity"]);
                                //oTicket.Save();
                                Item.Tickets.Add(Item.ProductID,oTicket);
                            }



                            if (oOrder.Items.Contains(oOrder.oProduct.ID))
                                oOrder.Items[oOrder.oProduct.ID].Quantity += Item.Quantity;
                            else
                                oOrder.Items.Add(oOrder.oProduct.ID, Item);

                            


                        }
                        else
                        {
                            this.SendErrorEmail(ShoppingCart.ToString()+" Item Error  " + oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + " Item:" + ProductID);
                        }

                    }
                    oOrder.GetTotals();
                    oOrder.Collected = oOrder.Retail;
                    oOrder.Save(OrderType.Internet);

                    /*
                    //Custom Cards Detail
                    if (row.GetChildRows(productCustomCard).Length > 0)
                    {
                        if (oOrder.Find(Convert.ToInt32(oOrder.ID)))
                        {
                            foreach (DataRow detailRow in row.GetChildRows(productCustomCard))
                            {

                                Ticket oTicket = new Ticket(oOrder.CompanyID);
                                oTicket.OrderID = Convert.ToInt32(oOrder.ID);
                                oTicket.Quantity = 1;
                                oTicket.ProductID = detailRow["product_id"].ToString();
                                
                                //Line 1
                                Ticket.Line oLine = new Ticket.Line();
                                oLine.Text = detailRow["Line_1"].ToString().Length > 40? detailRow["Line_1"].ToString().Substring(0,39):detailRow["Line_1"].ToString() ;
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_1,",oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = detailRow["Line_2"].ToString().Length > 40 ? detailRow["Line_2"].ToString().Substring(0, 39) : detailRow["Line_2"].ToString();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_2,", oLine);

                                oLine = new Ticket.Line();
                                oLine.Text = detailRow["Line_3"].ToString().Length > 40 ? detailRow["Line_3"].ToString().Substring(0, 39) : detailRow["Line_3"].ToString();
                                oLine.Type = Ticket.ImprintType.Card;
                                oTicket.Lines.Add("Line_3,", oLine);
                                
                                // Console.Out.WriteLine("Quantity: " + detailRow["quantity"]);
                                oTicket.Save();

                    
                            }
                        }
                    }
                    */

                    //Printing Packing Slips
                    if (oOrder.Find(Convert.ToInt32(oOrder.ID)))
                    {
                        
                        oOrder.UpdateOrderID((Int32)row["id"],ShoppingCart);


                        //Create Shortage
                        Shortage oShortage = new Shortage(this.CompanyID);
                        //oShortage.oOrder = oOrder;
                        oShortage.OrderID = oOrder.ID;
                        oShortage.oCustomer = oOrder.oCustomer;
                        oShortage.CustomerID = oOrder.CustomerID;
                        oShortage.SchoolName = (row.GetChildRows(shipOrderRel)[0]["FirstName"].ToString() + " " + row.GetChildRows(shipOrderRel)[0]["LastName"].ToString()).ToUpper();
                        oShortage.DayPhone = row.GetChildRows(shipOrderRel)[0]["phone"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                        oShortage.TeacherName = oOrder.Teacher;
                        oShortage.StudentName = oOrder.Student;
                        oShortage.Address = row.GetChildRows(shipOrderRel)[0]["address"].ToString() + " " + row.GetChildRows(shipOrderRel)[0]["address2"].ToString();
                        oShortage.City = row.GetChildRows(shipOrderRel)[0]["City"].ToString();
                        oShortage.ZipCode = row.GetChildRows(shipOrderRel)[0]["ZipCode"].ToString();
                        oShortage.State = row.GetChildRows(shipOrderRel)[0]["State"].ToString();
                        oShortage.Type = "I";
                        oShortage.Detail = oOrder.NoItems.ToString() + " Item(s)" + "\n\r" + "\n\r";
                        oShortage.Detail += "OrderID      : " + oOrder.ID.ToString() + "\n\r";
                        oShortage.Detail += "Processed On : " + (row["processed_on"] == null? "": ((DateTime) row["processed_on"]).ToString()) + "\n\r";
                        oShortage.eMail = row.GetChildRows(custOrderRel).Length > 0?row.GetChildRows(custOrderRel)[0]["email"].ToString():"";
                        oShortage.Save();
                       // oShortage.Print(false);

                        oOrder.ShortageID = Convert.ToInt32(oShortage.ID);
                        oOrder.Print();

                    }
                    else
                    {
                        this.SendErrorEmail(oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + oOrder.LastError);
                    }

                  

                   if (TeacherName != "GENERAL CUSTOMER")
                   {
                       String DeliveryDate = "  /  "; // : oCustomer.DeliveryDate.ToString("dd/MM/yyyy");
                       String Packed = "   ";

                       if (oCustomer.ID != "")
                       {
                           if (oCustomer.ShipDate != Global.DNull)
                           {
                               DeliveryDate = oCustomer.ShipDate.ToString("MM/dd");
                           }else
                               DeliveryDate = oCustomer.DeliveryDate.ToString("MM/dd");
                           Packed = oCustomer.NumberPallets > 0?"YES":"NO ";
                       }
                       
                       //String Packed = oCustomer.ID == ""? "   ":(oCustomer.ShipDate!=null?)
                       if (oOrder.ID == "0")
                           strBody += "["+oOrder.IOrderID.ToString().PadLeft(5) + "]" + oOrder.Teacher + " " + oOrder.Student.PadRight(30).Substring(0, 30) + " " + oOrder.NoItems.ToString().PadRight(3).Substring(0, 3) + " " + row.GetChildRows(studentOrderRel)[0]["school_city"].ToString().ToUpper() + "  " + Global.getState(row.GetChildRows(studentOrderRel)[0]["school_state"].ToString().ToUpper()) + " " + DeliveryDate + " " + Packed + Customized + "\n\r";
                       else
                           strBody += oOrder.ID.ToString().PadLeft(5) + " " + oOrder.Teacher + " " + oOrder.Student.PadRight(30).Substring(0,30) + " " + oOrder.NoItems.ToString().PadRight(3).Substring(0,3) + " " + row.GetChildRows(studentOrderRel)[0]["school_city"].ToString().ToUpper() + "  " + Global.getState(row.GetChildRows(studentOrderRel)[0]["school_state"].ToString().ToUpper()) + " "+DeliveryDate+" "+  Packed+ Customized+"\n\r";

                       if (ShoppingCart == ShoppingType.SigFund)
                       {
                           strBodyPrizes += row.GetChildRows(custOrderRel)[0]["FirstName"].ToString().ToUpper() + " " +
                           row.GetChildRows(custOrderRel)[0]["LastName"].ToString().ToUpper() + " " +
                           oOrder.Teacher.PadRight(30) + " " +
                           row.GetChildRows(custOrderRel)[0]["City"].ToString().ToUpper() + " " +
                           Global.getState(row.GetChildRows(custOrderRel)[0]["State"].ToString().ToUpper()) + " " +
                           (row.GetChildRows(studentOrderRel)[0]["student_name"].ToString()).ToUpper().Replace("\"", " ").Replace("'", " ") + " " +
                           oOrder.NoItems.ToString().PadRight(3).Substring(0, 3) +
                           "\n\r";
                       }
                       
                   }
                   else
                   {
                       strBody += oOrder.ID.ToString() + "[" + oOrder.IOrderID.ToString() + "]" + oOrder.Teacher.PadRight(30) + " " + oOrder.Student.PadRight(30).Substring(0, 30) + " " + oOrder.NoItems.ToString().PadRight(3).Substring(0, 3) + " " + row.GetChildRows(custOrderRel)[0]["City"].ToString().ToUpper() + " " + Global.getState(row.GetChildRows(custOrderRel)[0]["State"].ToString().ToUpper()) + Customized + "\n\r";
                           
                           
                           //oOrder.ID.ToString() + "[" + oOrder.IOrderID.ToString() + "]" + oOrder.Teacher.PadRight(30) + " " + oOrder.Student.PadRight(30).Substring(0, 30) + " " + oOrder.NoItems.ToString().PadRight(3).Substring(0, 3) + " " + row.GetChildRows(custOrderRel)[0]["City"].ToString().ToUpper() + " " + Global.getState(row.GetChildRows(custOrderRel)[0]["State"].ToString().ToUpper()) + Customized + "\n\r";
                   }
                }
                else
                {
                    /*
                    Console.Out.Write(".");
                   // strBody += "(R)" + oOrder.ID.ToString() + "  " + oOrder.Teacher + "  " + oOrder.Student + "  " + oOrder.NoItems.ToString() + "  " + row.GetChildRows(studentOrderRel)[0]["school_city"].ToString().ToUpper() + "  " + row.GetChildRows(studentOrderRel)[0]["school_state"].ToString().ToUpper() + "\n\r";
                    if (TeacherName != "GENERAL CUSTOMER")
                    {
                        strBody += "(R)" + oOrder.ID.ToString() + "  " + oOrder.Teacher + "  " + oOrder.Student + "  " + oOrder.NoItems.ToString() + "  " + row.GetChildRows(studentOrderRel)[0]["school_city"].ToString().ToUpper() + "  " + row.GetChildRows(studentOrderRel)[0]["school_state"].ToString().ToUpper() + "\n\r";
                    }
                    else
                    {
                        strBody += "(R)" + oOrder.ID.ToString() + "  " + oOrder.Teacher + "  " + oOrder.Student + "  " + oOrder.NoItems.ToString() + "  " + row.GetChildRows(custOrderRel)[0]["City"].ToString().ToUpper() + "  " + row.GetChildRows(custOrderRel)[0]["State"].ToString().ToUpper() + "\n\r";
                    }
                    */

                    //Print Orders When requested

                    oOrder.Print();
                }
                if (!oOrder.UpdateStatus(InternetOrderStatus.Processed,Database))
                    {
                        this.SendErrorEmail(oOrder.IOrderID.ToString() + " " + oOrder.Teacher + " " + oOrder.Student + oOrder.LastError);
                        return;
                    }
            }
            if (dsTables.Tables["Order"].Rows.Count > 0)
            {
                oOrder.ClosePrinter();
                //Sending Email
                    Smtp oSmtp = new Smtp();
                    
                    oSmtp.Subject = "Emails processed " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() + "  " + ShoppingCart.ToString();
                    if (this.CustomerID == "TEST")
                        oSmtp.To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
                    else
                    {
                        oSmtp.To = "\"Scott Elsbree\" <scotte@sigfund.com>";
                        oSmtp.To = "\"Desiree\" <desiree@sigfund.com>";
                        oSmtp.CC = "\"Alvaro Medina\" <alvaro@sigfund.com>";
                        if (ShoppingCart == ShoppingType.SigFund)
                            oSmtp.BCC = "\"signaturefundraising.com \" <sfonlineshop@signaturefundraising.com>";
                        if (ShoppingCart == ShoppingType.ChristianCollection)
                            oSmtp.BCC = "\"abundantfunds.com \" <cconlineshop@abundantfunds.com>";
                    }
                    oSmtp.From = "\"Signature Server\" <shopping@sigfund.com>";

                    String  strTitle =  "Order ID[Internet]   Teacher           Student         Items   City  State Ship/Del Packed\n\r";
                            strTitle += "------------------------------------------------------------------------------------------\n\r";  
                    String strTotal = "------------------------------------------------------------------------------------------\n\r";
                            strTotal+="Total: "  + dsTables.Tables["Order"].Rows.Count.ToString() + " Order(s)";
                    oSmtp.Body = strTitle + strBody + strTotal;
                    oSmtp.Send();

                    //Second Prize Report
                    if (strBodyPrizes != "" && ShoppingCart== ShoppingType.SigFund )
                    {

                        oSmtp.Subject = "Emails processed (Items Update)" + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() + "  " + ShoppingCart.ToString();
                        oSmtp.To = "\"Item Update \" <itemupdate@signaturefundriaing.com>";
                        oSmtp.From = "\"Signature Server\" <shopping@sigfund.com>";
                        oSmtp.BCC = "\"Alvaro Medina\" <alvaro@sigfund.com>";

                        strTitle = "Online Customer   School Name   City  State StudentName Items\n\r";
                        strTitle += "------------------------------------------------------------------------------------------\n\r";
                        strTotal = "------------------------------------------------------------------------------------------\n\r";
                        strTotal += "Total: " + dsTables.Tables["Order"].Rows.Count.ToString() + " Order(s)";
                        oSmtp.Body = strTitle + strBodyPrizes + strTotal;
                        oSmtp.Send();
                    }

            }
            dsTables.Dispose();
        }

        private void SendErrorEmail(String Text)
        {
            Console.WriteLine(Text);
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

        private String SplitName(String Name)
        {
            String[] Names = Name.ToUpper().Split(' ');
            if (Names.Length == 1)
                return Names[0];
            if (Names.Length == 2)
                return Names[0].Substring(0, 1) + "." + Names[1];
            if (Names.Length == 3)
                if (Names[2] == "JR.")
                    return Names[0].Substring(0, 1) + "." + Names[1] + "JR.";
                else
                    return Names[0].Substring(0, 1) + "." + Names[2];
            else
                return "NO NAME";
        }
        
        private Boolean  IsMagazine(String ProductID)
        {
            if (ProductID.Substring(0, 1) == "Z")
                return true;
            else
                return false;
        }
        private String GetMagazineCode(String ProductID, Double Price)
        {
            if (IsMagazine(ProductID))
            {
                if (Price == 30.00)
                    return "5930";
                else if (Price == 20.00)
                    return "5920";
                else if (Price == 15.00)
                    return "5915";
                else
                    return "5910";
            }
            else
                return ProductID;
        }
        
    }
        public enum InternetOrderStatus
        {
            Pending     =   0,
            Processed   =   1
        }
}
