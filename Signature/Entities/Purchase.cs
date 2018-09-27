using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature;
using Signature.Data;
using Signature.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Signature.Classes
{
    public class Purchase:Company
    {
      // Properties
        public new String ID;
        public String VendID;
        public int NumberItems;
        public Double _Total;
        public String Updated;
        public DateTime LeavingDate;
        public DateTime LandedDate;
        public String Notes;

        public _Items Items;
       
        //Methods

        public Purchase(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            Items = new _Items(CompanyID);
        } //Constructor

        public String  PrintPDF()
        {
            frmViewReport oViewReport = new frmViewReport();
            PurchaseOrder oRpt = new PurchaseOrder();
            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable("Select * From Vendor Where CompanyID='" + CompanyID + "'", "Vendor"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Purchase Where CompanyID='" + CompanyID + "' And PurchaseID='" + ID + "'", "Purchase"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From PurchaseDetail Where CompanyID='" + CompanyID + "' And PurchaseID='" + ID + "'", "PurchaseDetail"));

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);
            
            PDF oPDF = new PDF();
            oPDF.FileName = Application.StartupPath + "\\" + this.ID + ".pdf";
            oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.ID);
            oRpt.Dispose();
            return oPDF.FileName;
        }

        public void Print(PrinterDevice Printo, String PrinterName)
        {
            
            frmViewReport oViewReport = new frmViewReport();
            PurchaseOrder oRpt = new PurchaseOrder();
            DataSet ds = new DataSet();

            
            ds.Tables.Add(oMySql.GetDataTable("Select * From Vendor Where CompanyID='"+CompanyID+"'","Vendor"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Purchase Where CompanyID='" + CompanyID + "' And PurchaseID='"+ID+"'", "Purchase"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From Product Where CompanyID='" + CompanyID + "'", "Product"));
            ds.Tables.Add(oMySql.GetDataTable("Select * From PurchaseDetail Where CompanyID='" + CompanyID + "' And PurchaseID='" + ID + "'", "PurchaseDetail"));

           // ds.WriteXml("Purchase11.xml", XmlWriteMode.WriteSchema);

            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", base.Name);
            

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
            else if (Printo == PrinterDevice.PDF)
            {
                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\" + this.ID + ".pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.ID);

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = "Purchase Order : " + this.ID + "   " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();
                oSmtp.To = "<" + "russ@sigfund.com" + ">"; //this.eMail + ">";
                oSmtp.From = "\"Signature Fundraising Customer Service\" <support@sigfund.com>";

                String strTitle = "Purchase Order\n\r";

                oSmtp.Body = strTitle;
                oSmtp.Attachment = oPDF.FileName;
                if (!oSmtp.Send())
                    return;
            }

        }
        public new bool Find(String PurchaseID)
        {
            this.ID = "";
            
            
            if (PurchaseID == "")
                return false;

            DataRow row = this.oMySql.GetDataRow("Select * From Purchase Where CompanyID='"+CompanyID+"' And  PurchaseID='" + PurchaseID + "'", "Brochure");
            

            if (row == null)
            {
                this.ID = "";
                return false;
            }

            this.ID             = row["PurchaseID"].ToString();
            this.VendID         = row["VendorID"].ToString();
            this.NumberItems    = (int)row["Items"];
            this.Total          = (Double)row["Total"];
            this.Updated        = row["Updated"].ToString();
            this.LeavingDate    = (row["LeavingDate"] == DBNull.Value) ? Global.DNull : (DateTime)row["LeavingDate"];
            this.LandedDate     = (row["LandedDate"] == DBNull.Value) ? Global.DNull : (DateTime)row["LandedDate"];
            this.Notes          = row["Notes"].ToString();
            this.Items.Load(CompanyID,ID);

            return true;
        
        }
        public new bool View()
        {
            return View(false);
        }
        public bool View(Boolean Pending)
        {
            frmPOrdersView oView = new frmPOrdersView(this.CompanyID);
            oView.IsPending = Pending;
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                Find(ID);
                return true;

            }
            return false;

        }
        public new void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
            Items.Save(CompanyID,ID);

            this.Total = GetTotal();
            this.Update();

            //UpdateInventory();
        }
        public new void Update()
        {

            String Sql = String.Format("Update Purchase Set PurchaseID='{0}', Total=\"{1}\", Items=\"{2}\",CompanyID=\"{3}\", VendorID=\"{4}\", Date=NOW(), LeavingDate='{5}', LandedDate='{6}', Notes=\"{7}\"  Where PurchaseID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.ID, this.Total, this.NumberItems, this.CompanyID, this.VendID, Global.oMySql.SqlTimeDate(this.LeavingDate), Global.oMySql.SqlTimeDate(this.LandedDate),this.Notes);
            
            oMySql.exec_sql(Sql);
            
        }
        public new void Insert()
        {
            String Sql = String.Format("Insert into Purchase (CompanyID, PurchaseID, Total, Items, VendorID, Date, LeavingDate, LandedDate, Notes)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}', NOW(),'{5}','{6}',\"{7}\")",
                        this.CompanyID, this.ID, this.Total, this.NumberItems, this.VendID, Global.oMySql.SqlTimeDate(this.LeavingDate), Global.oMySql.SqlTimeDate(this.LandedDate),this.Notes);
            oMySql.exec_sql(Sql);
        }
        public bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from Purchase Where PurchaseID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        
        public new void Delete()
        {
            String Sql = "Delete From Purchase Where PurchaseID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
            this.Items.BackToInventory(CompanyID);
            this.Items.Delete(CompanyID, ID);
            
        }

        public void Clear()
        {
            ID = "";
            Notes = "";
            Items.Clear();

        }

        public String GetNextNumber()
        {
            DataRow row = oMySql.GetDataRow("SELECT MAX(LPAD(CONV(PurchaseID,10,10)+1,10,'0')) as Next FROM Purchase Where CompanyID='"+CompanyID+"'","tmp");
            if (row == null)
                return "1".PadLeft(10, '0');
            else
            {
                //byte[] byteBLOBData = (Byte[])(row["Next"]);

                //return System.Text.Encoding.UTF8.GetString(byteBLOBData);
                if (row["Next"] == DBNull.Value)
                    return "0000000001";
                else
                    return Global.ByteToString((Byte[])row["Next"]);
            }
        }

        public void UpdateInventory()
        {
            Inventory oInventory = new Inventory(CompanyID);
            oInventory.Update(this, Inventory.InventoryType.Commit);
            
        }
        public void UpdateReceiveInventory()
        {
            Inventory oInventory = new Inventory(CompanyID);
            oInventory.Update(this, Inventory.InventoryType.RollBack);
        }

        public Double Total
        {
            set
            {
                _Total = value;
            }

            get
            {
                if (_Total == 0)
                    _Total = this.GetTotal();
                return _Total;
            }
        }

        public Double GetTotal()
        {
                DataRow rTotal = oMySql.GetDataRow(String.Format("SELECT sum((pd.Cases*p.Size + pd.Units)*p.Cost) as Total FROM PurchaseDetail pd Left Join Product p On p.CompanyID=pd.CompanyID And p.ProductID=pd.ProductID Where PurchaseID='{0}' And pd.CompanyID='{1}' Group By pd.PurchaseID",  this.ID,this.CompanyID), "Tmp");
                if (rTotal == null)
                {
                    return 0;
                }
                else
                {
                    return rTotal["Total"] == DBNull.Value ? 0 : (Double)rTotal["Total"];
                }
            
        }
        public Double GetPayments()
        {
            DataRow rPayment = oMySql.GetDataRow(String.Format("SELECT sum(Amount) as Payments FROM PaymentProvider P Where CompanyID='{0}' And PurchaseID='{1}' ", this.CompanyID, this.ID), "Tmp");

            if (rPayment == null)
            {
                return 0;
            }
            else
            {
                return rPayment["Payments"] == DBNull.Value ? 0 : (Double)rPayment["Payments"];
            }
        }
        public DataTable  GetRange(Int32 POFrom, Int32 POTo)
        {
            String Sql = "";
            
                if (POFrom > 0)
                    Sql = String.Format(" And PurchaseID  >= {0}", POFrom);

                if (POTo > 0)
                    Sql += String.Format(" And PurchaseID <= {0}", POTo);

            Sql = String.Format("Select PurchaseID From Purchase  Where CompanyID='{0}' {1} ", CompanyID, Sql);
           // MessageBox.Show(Sql);
            return oMySql.GetDataTable(Sql, "Tmp");

        }
        public Boolean PrintStatement(String PrinterName, PrinterDevice Device)
        {

            if (_Total == 0)
            {
                Total = GetTotal();
                Update();
            }
            
            frmViewReport oViewReport = new frmViewReport();
            //DataSet ds1 = oMySql.GetCustomerStatement(CompanyID, ID);

            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Vendor Where CompanyID='{0}' And VendorID='{1}'", CompanyID, this.VendID), "Vendor"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Purchase Where CompanyID='{0}' And PurchaseID='{1}'", CompanyID, this.ID), "Purchase"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From PaymentProvider  Where CompanyID='{0}' And PurchaseID='{1}' Order by Date", CompanyID, ID), "Statement"));

            PurchaseStatement oRpt = new PurchaseStatement();
         //   ds.WriteXml("PrintStatement1.xml", XmlWriteMode.WriteSchema);
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", base.Name);


            if (Device == PrinterDevice.Printer)
            {
                oRpt.PrintOptions.PrinterName = PrinterName;
                oRpt.PrintToPrinter(1, true, 1, 100);
            }
            else if (Device == PrinterDevice.eMail)
            {

                PDF oPDF = new PDF();
                oPDF.FileName = Application.StartupPath + "\\" + this.ID + ".pdf";
                oPDF.ExportReport(oRpt, "pdf", Application.StartupPath + "\\", this.ID);

                Smtp oSmtp = new Smtp();
                oSmtp.Subject = base.ID + " - Statement " + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString() + "(" + this.ID + " - " + this.Name + ")";


                if (PrinterName != "")
                    oSmtp.To = "\"" + this.Name + "\" <" + PrinterName + ">"; //this.eMail + ">";
                /*
            else if (this.isEmail(this.eMail) && File.Exists(oPDF.FileName))
            {
                    
                oSmtp.To = "\"" + this.Chairperson + "\" <" + this.eMail + ">";
                if (this.isEmail(this.oCustomerExtra.eMail))
                {
                    oSmtp.To = "\"" + this.Chairperson + "\" <" + this.oCustomerExtra.eMail + ">";
                }
                    
                oSmtp.To = "\"" + "Scott Elsbree" + "\" <" + "scotte@sigfund.com" + ">"; //this.eMail + ">";
            }
                */
                else
                {
                    oSmtp.To = "\"" + "Scott Elsbree" + "\" <" + "scotte@sigfund.com" + ">"; //this.eMail + ">";

                }

                oSmtp.From = "\"Signature Fundraising Customer Service\" <info@signaturefundraising.com>";

                String strTitle = "\n\r";



                strTitle += "Thank you for choosing Signature Fundraising.  As of today we have not received complete payment for your account.\n\r";
                strTitle += "We have attached a copy of your most recent statement showing the balance due.  Please remember that  according to\n\r";
                strTitle += "the agreement we have with your organization interest will accrue on any unpaid balance after 20 days of delivery.\n\r";
                strTitle += "We have also attached a check by fax form that will enable you to send payment to us right away.  If you have any \n\r";
                strTitle += "questions, you may reply to this e-mail or call us at 1-800-645-3863.\n\r";

                strTitle += "\n\nThank you.\n\r";
                strTitle += "Signature Fundraising\n\r";


                //String strTitle = "This statement amount due is for a total of :\n\r  $ " + this.StatementAmountDue.ToString() + " \n\r" ;
                //This invoice is for a total of ::invoice amount::, of which ::payment amount:: has already been received.
                /*
                if (PrinterName == "" && !this.isEmail(this.eMail))
                    strTitle += " WRONG EMAIL ADDRESS: " + this.eMail + " of " + this.ID + " : " + this.Name;

                if (PrinterName == "" && !File.Exists(oPDF.FileName))
                    strTitle += " NO PDF FILE : " + this.eMail + " of " + this.ID + " : " + this.Name;
                else
                    oSmtp.Attachment = oPDF.FileName;
                */
                oSmtp.Body = strTitle;
                oSmtp.Attachment = "Check by Fax Form.pdf";
                oSmtp.Credentials = new System.Net.NetworkCredential("info@signaturefundraising.com", "sigfund");
                // oSmtp.BCC = "scotte@sigfund.com";

                if (!oSmtp.Send())
                {
                    Console.WriteLine(oSmtp.Error);
                    oRpt.Dispose();
                    oViewReport.Dispose();
                    return false;
                }
                //while (File.GetAttributes(oPDF.FileName) == FileAttributes.ReadOnly) ;
                /*
                ReadFile:
                try
                {
                    if (File.Exists(oPDF.FileName))
                        File.Delete(oPDF.FileName);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto ReadFile;
                }
                */

            }
            else
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.ShowDialog();
            }

            oRpt.Dispose();
            oViewReport.Dispose();

            return true;
        }
        #region Classes & Enumerators
        public class _Items : Hashlist 
        {
            public DataTable dtItems = new DataTable("Detail");
            DataView CurrentDetail;

            public _Items(String CompanyID):base(CompanyID)
            {
                SetColumns();
            }
            public void AddEmpty1()
            {
                Item _Item = new Item();
                _Item.Description = "";
                _Item.ProductID = "";
                _Item.Cases = 0;
                _Item.Units = 0;
                _Item.Price = 0;
                _Item.Size = 0;
                _Item.Seq = 9999;
                

                this.Add("ZZZZZ", _Item);
            }
            public void AddEmpty()
            {
                DataRow Detail = dtItems.NewRow();

                Detail["Description"] = "";
                Detail["ProductID"] = "";
                Detail["InvCode"] = "";
                Detail["Cases"] = 0;
                Detail["Units"] = 0;
                Detail["Size"] = 0;
                Detail["Price"] = 0;


                dtItems.Rows.Add(Detail);  
            }
            public void Delete(String CompanyID, String PurchaseID)
            {
                String Sql = "Delete from PurchaseDetail where CompanyID='" + CompanyID + "' And PurchaseID = '" + PurchaseID+"'";
                oMySql.exec_sql(Sql);
            }
            public void Save(String CompanyID, String PurchaseID)
            {
                Product oProduct = new Product(CompanyID);
                this.BackToInventory(CompanyID);
                this.Delete(CompanyID,PurchaseID);
                foreach (DataRow _Row in dtItems.Rows)
                {
                    Item _Item = new Item();
                    if (_Row["ProductID"].ToString().Trim() == "")
                        continue;
                    _Item.PurchaseID    = PurchaseID;
                    _Item.CompanyID     = CompanyID;
                    _Item.ProductID     = _Row["ProductID"].ToString();
                    _Item.Units         = (Int32) _Row["Units"];
                    _Item.Cases         = (Int32) _Row["Cases"];
                    _Item.Note          = _Row["Note"].ToString();
                    if (oProduct.Find(_Row["ProductID"].ToString()))
                    {
                        oProduct.ONPO += (Int32)_Row["Units"] + (Int32)_Row["Cases"] * oProduct.Size;
                        oProduct.UpdateInventory();
                    }
                    _Item.Insert();

                }
                dtItems.Rows.Clear();
            }
            public void BackToInventory(String CompanyID)
            {
                Product oProduct = new Product(CompanyID);
                if (CurrentDetail != null)
                {
                    foreach (DataRowView row in CurrentDetail)
                    {
                        //MessageBox.Show(row["ProductID"].ToString()+"--"+row["Quantity"].ToString());
                        oProduct.Find(row["ProductID"].ToString());
                        oProduct.ONPO -= (Int32)row["Cases"] * oProduct.Size + (Int32)row["Units"];
                        oProduct.UpdateInventory();
                    }
                }
                return;
            }
            public void Load1(String CompanyID, String PurchaseID)
            {
                
                 Clear();


                DataView tDetail;
                tDetail = oMySql.GetDataView(String.Format("SELECT pd.CompanyID, pd.ProductID, p.Description, p.InvCode, p.Size, p.Cost as Price, pd.Cases, pd.Units FROM PurchaseDetail pd left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='{0}' And PurchaseID='{1}'",CompanyID,PurchaseID), "Tmp");
          
                foreach (DataRow Row in tDetail.Table.Rows)
                    {

                    Item Detail = new Item();

                    Detail.Description = Row["Description"].ToString();
                    Detail.ProductID = Row["ProductID"].ToString();
                    Detail.InvCode = Row["InvCode"].ToString();
                    Detail.Cases = (int)Row["Cases"];
                    Detail.Units = (int)Row["Units"];
                    Detail.Size = (int)Row["Size"];
                    Detail.Price = (Double)Row["Price"];

                    Add(Row["ProductID"].ToString(), Detail);

                    }
                
                AddEmpty();
            }
            public void Load(String CompanyID, String PurchaseID)
            {

                Clear();

                CurrentDetail = oMySql.GetDataView(String.Format("SELECT pd.CompanyID, pd.ProductID, p.Description, p.InvCode, p.Size,  p.Cost as Price, pd.Cases, pd.Units, pd.Note FROM PurchaseDetail pd left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Where pd.CompanyID='{0}' And PurchaseID='{1}'", CompanyID, PurchaseID), "Tmp");

                int i = 0;
                foreach (DataRow Row in CurrentDetail.Table.Rows)
                {

                    DataRow Detail = dtItems.NewRow();
                    
                    
                    Detail["Description"] = Row["Description"].ToString();
                    Detail["ProductID"] = Row["ProductID"].ToString();
                    Detail["InvCode"] = Row["InvCode"].ToString();
                    Detail["Cases"] = (int)Row["Cases"];
                    Detail["Units"] = (int)Row["Units"];
                    Detail["Size"] = Convert.ToInt32(Row["Size"].ToString().PadLeft(3, '0'));
                    Detail["Note"] = Row["Note"].ToString();

                    Detail["Price"] = Row["Price"] == null || Row["Price"].ToString().Trim() == "" ? 0.00 : (Double)Row["Price"];
                    Detail["Seq"] = i++;

                    dtItems.Rows.Add(Detail);

                }

                AddEmpty();
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

                colWork = new DataColumn("Cases", Type.GetType("System.Int32"));
                colWork.ReadOnly = false;
                //  colWork.MaxLength = 10;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Units", Type.GetType("System.Int32"));
                //  colWork.MaxLength = 10;
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("InvCode", Type.GetType("System.String"));
                //  colWork.MaxLength = 10;
                //colWork.ReadOnly = true;
                dtItems.Columns.Add(colWork);


                colWork = new DataColumn("Size", Type.GetType("System.Int32"));
                //  colWork.MaxLength = 10;
                colWork.ReadOnly = false;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Seq", Type.GetType("System.Int16"));
                
                //  colWork.MaxLength = 10;
                dtItems.Columns.Add(colWork);

                colWork = new DataColumn("Note", Type.GetType("System.String"));
                //  colWork.MaxLength = 10;
                //colWork.ReadOnly = true;
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
            private int _Cases;
            private int _Units;
            private int _Size;
            private Double _Price;
            public int _Seq;
            public string _Note;

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
                String Sql = String.Format("Insert into PurchaseDetail (CompanyID, PurchaseID, ProductID, Cases, Units, Note)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}',\"{5}\")",
                    this.CompanyID, this.PurchaseID, this.ProductID, this.Cases, this.Units,this.Note);
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
            public int Cases
            {
                get { return _Cases; }


                set
                {
                    _Cases = value;
                }
            }
            public int Units
            {
                get { return _Units; }


                set
                {
                    _Units = value;
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
            public int Seq
            {
                get { return _Seq; }


                set
                {
                    _Seq = value;
                }
            }
            public String Note
            {
                get { return _Note; }

                set
                {
                    _Note = value;
                }
            }
            public int Size
            {
                get { return _Size; }


                set
                {
                    _Size = value;
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
