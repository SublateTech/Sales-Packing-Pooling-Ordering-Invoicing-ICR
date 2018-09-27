using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Signature.Classes;
using Signature.Data;
using Signature.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Signature.Classes
{
    [Serializable()] 
    public class Shortage:Company
    {
        #region Properties
        // Properties
        private String _ID;
        public String CustomerID;
        public String OrderID="";
        public String SchoolName;
        public String ParentName;
        public String TeacherName;
        public DateTime Date;
        public String Detail;
        public String DayPhone;
        public String EvePhone;
        public String QVNOption;
        public new String Address;
        public String Address_2;
        public String Attention;
        public new String City;
        public new String State;
        public new String ZipCode;
        public String eMail;
        public String StudentName="";
        public String User = "";

        public String Type;

        public Customer oCustomer;
        public Order oOrder;

        public _Items Items;

        public DataTable currentDetail;

        //Properties
        public String TrakingNumber
        {
            get
            {
                oMySql.exec_sql("Delete From UPS_TrakingNumber Where ShortageID='0'");
                DataRow rShortage = oMySql.GetDataRow(String.Format("Select * From UPS_TrakingNumber Where ShortageID='{0}'", ID), "Tmp");

                if (rShortage == null)
                    rShortage = oMySql.GetDataRow(String.Format("Select * From FED_TrackingNumber Where ShortageID='{0}'", ID), "Tmp");
                
                if (rShortage == null)
                        return "";
                else
                    return rShortage["TrackingNumber"].ToString();
            }
            set 
            {
                TrakingNumber = value;
            }
        }

        public ArrayList TrakingNumbers
        {
            get
            {
                DataTable rShortage = oMySql.GetDataTable(String.Format("Select * From UPS_TrakingNumber Where ShortageID='{0}' Group By TrackingNumber", ID), "Tmp");

                if (rShortage == null)
                    rShortage = oMySql.GetDataTable(String.Format("Select * From FED_TrackingNumber Where ShortageID='{0}' Group By TrackingNumber", ID), "Tmp");
                if (rShortage == null)
                        return new ArrayList();
                else
                {
                    ArrayList _TrackingNumbers = new ArrayList();
                    foreach (DataRow row in rShortage.Rows)
                    {
                        _TrackingNumbers.Add(row["TrackingNumber"].ToString());
                    }
                    return _TrackingNumbers;
                }
                    
            }
        }

        #endregion
        //Methods
        public Shortage()
        {
            this.CompanyID = base.ID;
            oCustomer = new Customer();
            Items = new _Items();
        } //Constructor
        public Shortage(Shortage oShortage)
        {
            this.ID = oShortage.ID;

            this.CompanyID = oShortage.CompanyID;
            this.CustomerID=oShortage.CustomerID;
            this.OrderID=oShortage.OrderID;
            this.SchoolName=oShortage.SchoolName;
            this.ParentName=oShortage.ParentName;
            this.TeacherName=oShortage.Name;
            this.Name = oShortage.Name;
            this.Date=oShortage.Date;
            this.Detail=oShortage.Detail;
            this.DayPhone=oShortage.DayPhone;
            this.EvePhone=oShortage.EvePhone;
            this.QVNOption=oShortage.QVNOption;
            this.Address=oShortage.Address;
            this.Address_2 = oShortage.Address_2;
            this.Attention=oShortage.Attention;
            this.City=oShortage.City;
            this.State=oShortage.State;
            this.ZipCode=oShortage.ZipCode;
            this.eMail=oShortage.ZipCode;
            this.Type=oShortage.Type;
            this.StudentName = oShortage.StudentName;
          //  this.oCustomer=oShortage.oCustomer;
            this.Items =  new _Items(oShortage.Items);
            //this.TrakingNumber = oShortage.TrakingNumber;
            
        }
        public Shortage(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            oCustomer = new Customer(CompanyID);
            Items = new _Items();

        } //Constructor
        public override bool Find(String ShortageID)
        {
            if (ShortageID == String.Empty)
                return false;

            DataRow row = oMySql.GetDataRow("Select * From Shortage Where ShortageID='" + ShortageID + "'", "Shortage");
            if (row == null)
            {
                ID = String.Empty;
                return false;
            }
            

            ID = row["ShortageID"].ToString();
            this.SchoolName = row["Name"].ToString();
            this.TeacherName = row["TeacherName"].ToString();
            this.Detail = row["Detail"] == DBNull.Value ? "" : Global.ByteToString((byte[])row["Detail"]);
            this.DayPhone = row["DayPhone"].ToString();
            this.EvePhone = row["EvePhone"].ToString();
            this.QVNOption = row["QVNOption"].ToString();
            this.Address = row["Address"].ToString() + " " +row["Address_2"].ToString();
            this.Address_2 = "";
            this.Attention = row["Attention"].ToString();
            this.City = row["City"].ToString();
            this.State = row["State"].ToString();
            this.ZipCode = row["ZipCode"].ToString();
            this.eMail = row["eMail"].ToString();
            this.ParentName = row["ParentName"].ToString();
            this.StudentName = row["StudentName"].ToString();
            this.CompanyID = row["CompanyID"].ToString();
            this.CustomerID = row["CustomerID"].ToString();
            this.Type = row["Type"].ToString();
            this.OrderID = row["OrderID"].ToString() == "0" ? "" : row["OrderID"].ToString();
            this.Date = row["Detail"] == DBNull.Value ? Global.DNull : (DateTime) row["Date"];
            this.User = row["User"].ToString();

            Items.Load(this);
            this.currentDetail = Items.Detail;
            return true;

        }
        public bool FindByCustomer(String CustomerID, String Type)
        {
            if (CustomerID == String.Empty)
                return false;

            DataRow row = oMySql.GetDataRow("Select * From Shortage Where CustomerID='" + CustomerID + "' And CompanyID='"+CompanyID+"' And Type='"+Type+"'", "Shortage");
            if (row == null)
            {
                return false;
            }
            this.Find(row["ShortageID"].ToString());
            return true;
        }
        public override bool View()
        {
            frmShortagesView oView = new frmShortagesView(this.CompanyID, this.CustomerID, this.OrderID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                Find(ID);
                return true;

            }
            return false;
        }
        public override void Update()
        {
            this.SplitAddress();

            this.Detail = MySQL.PrepareSql(this.Detail);
            this.TeacherName = MySQL.PrepareSql(this.TeacherName);
            this.Attention = MySQL.PrepareSql(this.Attention);
            this.Address = MySQL.PrepareSql(this.Address);
            this.Address_2 = MySQL.PrepareSql(this.Address_2);
            this.ParentName = MySQL.PrepareSql(this.ParentName);
            this.StudentName = MySQL.PrepareSql(this.StudentName);
            this.Name = MySQL.PrepareSql(this.Name);
            this.City = MySQL.PrepareSql(this.City);

            String Sql = String.Format("Update Shortage Set Name=\"{0}\",Address=\"{1}\",Attention=\"{2}\",City=\"{3}\",State='{4}',ZipCode='{5}',eMail='{6}',QVNOption='{7}',CompanyID='{8}',CustomerID='{9}',OrderID='{10}',Detail=\"{11}\",Date=NOW(),ParentName='{12}',TeacherName=\"{13}\",DayPhone='{14}',EvePhone='{15}',Type='{16}',StudentName=\"{17}\",Address_2=\"{18}\"   Where ShortageID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
            this.SchoolName, this.Address, this.Attention, this.City, this.State, this.ZipCode, this.eMail, this.QVNOption,
            this.CompanyID, this.CustomerID, this.OrderID, this.Detail, this.ParentName, this.TeacherName, this.DayPhone, this.EvePhone,this.Type,this.StudentName, this.Address_2);

            oMySql.exec_sql(Sql);

        }
        public override void Insert()
        {
            this.SplitAddress();
            
            this.Detail         = MySQL.PrepareSql(this.Detail);
            this.TeacherName    = MySQL.PrepareSql(this.TeacherName);
            this.Attention      = MySQL.PrepareSql(this.Attention);
            this.Address        = MySQL.PrepareSql(this.Address);
            this.Address_2      = MySQL.PrepareSql(this.Address_2);
            this.ParentName     = MySQL.PrepareSql(this.ParentName);
            this.StudentName    = MySQL.PrepareSql(this.StudentName);
            this.Name           = MySQL.PrepareSql(this.Name);
            this.City           = MySQL.PrepareSql(this.City);
            this.DayPhone       = (this.DayPhone.Length > 10) ? this.DayPhone.Substring(0, 10) : this.DayPhone;

            String Sql = String.Format("Insert into Shortage (Name,Address,Attention,City,State,ZipCode,eMail,QVNOption,CompanyID,CustomerID,OrderID,Detail,Date,ParentName,TeacherName,DayPhone,EvePhone,Type,StudentName,User,Address_2)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',\"{11}\",NOW(),\"{12}\",\"{13}\",'{14}','{15}','{16}',\"{17}\",'{18}',\"{19}\")",
                        this.SchoolName, this.Address, this.Attention, this.City, this.State, this.ZipCode, this.eMail, this.QVNOption,
                        this.CompanyID, this.CustomerID, this.OrderID, this.Detail,
                        this.ParentName, this.TeacherName, this.DayPhone, this.EvePhone,this.Type,this.StudentName,Global.CurrentUser,this.Address_2);
            ID = oMySql.exec_sql_id(Sql).ToString();
        }

        private void SplitAddress()
        {
            String[] Addresses = this.SplitStringIntoLines(this.Address, 35);

            if (Addresses.Length > 1)
            {
                this.Address = Addresses[0];
                this.Address_2 = Addresses[1];
            }
        }
        public  bool IfExist()
        {
            
            if ((oMySql.exec_sql_no("Select count(*) from Shortage Where ShortageID='" + this.ID + "'")) == 0)
                return false;
            else
                return true;
        }
        public override void Save()
        {
            

            Inventory oInventory = new Inventory(CompanyID);
            oInventory.Update(this, Inventory.InventoryType.RollBack);
            if (IfExist())
                Update();
            else
                Insert();
            Items.Save(this);
            oInventory.Update(this, Inventory.InventoryType.Commit);
            
        }
        public void Save(Shortage oCurrentShortage)
        {
            Inventory oInventory = new Inventory(CompanyID);
            oInventory.Update(this, Inventory.InventoryType.RollBack);
            if (IfExist())
                Update();
            else
                Insert();
            Items.Save(this);
            oInventory.Update(this, Inventory.InventoryType.Commit);

        }
        public override void Delete()
        {
            String Sql = "Delete From Shortage Where ShortageID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }

        public new String ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
   
        public void Print(Boolean LocalPrint)
        {
            
            DataSet ds = new DataSet();

            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select *,'Text'  From Shortage Where ShortageID='{0}'", ID), "Shortage"));

            Product oProduct = new Product(this.CompanyID);
            String SchoolName = "";
            foreach (DataRow row in ds.Tables["Shortage"].Rows)
            {
                row["Text"] = Global.ByteToString((Byte[])(row["Detail"]));
                row["Address"] = row["Address"].ToString() + row["Address_2"].ToString();
                foreach (DataRow drow in Items.Detail.Rows)
                {
                    oProduct.Find(drow["ProductID"].ToString());
                    row["Text"] += "\n" + oProduct.InvCode+ " - " +  drow["ProductID"].ToString() + " - " + drow["Description"].ToString() + " - " + drow["Quantity"].ToString();
                    
                }

                if (row["CustomerID"].ToString().Trim() !="")
                {
                    if (oCustomer.Find(row["CustomerID"].ToString()))
                        SchoolName = oCustomer.Name;
                }

            }

            
            frmViewReport oViewReport = new frmViewReport();

            //ds.WriteXml("dataset72.xml", XmlWriteMode.WriteSchema);
            ShortageReport oRpt = new ShortageReport();
            oRpt.SetDataSource(ds);

            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");
            oRpt.SetParameterValue("SchoolName", SchoolName);
            oRpt.SetParameterValue("User", Global.CurrentUser);
            
            oRpt.SetParameterValue("Dates", "");
            oRpt.SetParameterValue("Chairperson", "");
            oRpt.SetParameterValue("StudentName", "");

            String sType="Not specified";

            switch (Type)
            {
                case "A":
                    sType = "Add";
                    break;
                case "O":
                    sType = "0verage";
                    break;
                case "X":
                    sType ="Delete";
                    break;
                case "M":
                    sType ="Miscellaneous";
                    break;
                case "R":
                    sType ="Refund" ;
                    break;
                case "D":
                    sType ="Damaged" ;
                    break;
                case "B":
                    sType = "Missing";
                    break;
                case "I":
                    sType = "Internet";
                    break;
                case "E":
                    sType = "Missing Entire Order";
                    break;
                case "Y":
                    sType = "Discrepancy";
                    break;


            }
            oRpt.SetParameterValue("Type", sType);
            
            oRpt.SetParameterValue("BarCode",(sType!="Add")? "*" + ID + "*":"");


            if (OrderID.Trim() != "")
            {
                if (oCustomer.ShipDate != Global.DNull || oCustomer.DeliveryDate != Global.DNull)
                {
                    String ShipDate = oCustomer.ShipDate == Global.DNull ? "          " : oCustomer.ShipDate.ToString("MM/dd/yyyy");
                    String DeliveryDate = oCustomer.DeliveryDate == Global.DNull ? "          " : oCustomer.DeliveryDate.ToString("MM/dd/yyyy");
                    oRpt.SetParameterValue("Dates", "Ship Date: " + ShipDate + "   " + "Delivery Date:" + DeliveryDate);
                }
                if (oCustomer.Chairperson.Trim() != "")
                    oRpt.SetParameterValue("Chairperson", "Chairperson:"+oCustomer.Chairperson);

                oOrder = new Order(CompanyID);
                oOrder.Find(Convert.ToInt32(OrderID));
                oRpt.SetParameterValue("StudentName", "Student:      " + oOrder.Student);
            }

            if (Global.CurrentUser == "JOYCE" || Global.CurrentUser == "ALVARO" || LocalPrint || Type == "R")
            {
                oViewReport.cReport.ReportSource = oRpt;
                oViewReport.cReport.PrintReport();
                //oViewReport.ShowDialog();

            }
            else
            {
                oRpt.PrintOptions.PrinterName = "\\\\srv1\\Shortage";
                oRpt.PrintToPrinter(1, false, 1, 100);

            }

            ds.Dispose();
            oRpt.Dispose();
            oViewReport.Dispose();
        }

        public string[] SplitStringIntoLines(string input, int maxCharsPerLine)
        {
            string[] words = input.Split(" ".ToCharArray());
            ArrayList lines = new ArrayList();
            string curLine = "";
            foreach (string w in words)
            {
                if ((w.Length + curLine.Length + 1) <= maxCharsPerLine)
                {
                    curLine += " " + w;
                }
                else
                {
                    if (curLine.Trim() != string.Empty)
                        lines.Add(curLine.Trim());

                    curLine = w;
                }
            }
            lines.Add(curLine.Trim());
            return (string[])lines.ToArray(typeof(string));
        }
        [Serializable()]
        public class _Items
        {

            public Double Retail = 0;
            public event EventHandler SubTotalChanged;

            protected virtual void OnSubTotalChanged()
            {
                if (SubTotalChanged != null)
                {
                    OnSubTotalChanged();
                }
            }

            public void Add(DataRow Row)
            {
                Detail.Rows.Add(Row);
                CalculateRetail();
                
            }

            public void CalculateRetail()
            {
                //Detail.AcceptChanges();
                Retail = 0;
                foreach (DataRow row in Detail.Rows)
                        Retail += (Double)row["SubTotal"];
                SubTotalChanged(this, EventArgs.Empty);
            }

            protected MySQL oMySql = Global.oMySql;
            public DataTable Detail = new DataTable("Detail");

            public _Items()
            {
                this.SetColumns();
            }
            public _Items(_Items oItems)
            {
                this.Detail = oItems.Detail;
            }

            public DataTable GetDataTable(Shortage oShortage)
            {
                Detail.Clear();
                Detail = oMySql.GetDataTable("SELECT ks.KitID, k.Name,  Quantity FROM ga_kitbyschool ks Left Join ga_kit k on ks.KitID=k.ID And ks.CompanyID=k.CompanyID  Where CustomerID='" + oShortage.ID + "'", "Kits");
                return Detail;
            }
            public void RemoveAt(int Index)
            {
                if (Detail.Rows.Count > Index)
                    Detail.Rows.RemoveAt(Index);
            }
            public void Save(Shortage oShortage)
            {

                if (oShortage.ID != String.Empty)
                {
                    String Sql = String.Format("Delete From ShortageDetail Where ShortageID = '{0}'",
                                                        oShortage.ID);
                    oMySql.exec_sql(Sql);

                    Detail.AcceptChanges();
                    foreach (DataRow drow in Detail.Rows)
                    {
                        int Qty = 0;
                        if (drow["Quantity"] == DBNull.Value)
                            Qty = 0;
                        else
                            Qty = Convert.ToInt16(drow["Quantity"].ToString());

                        if (Qty > 0)
                        {
                            oMySql.exec_sql(String.Format("Insert Into ShortageDetail (ShortageID,CompanyID, ProductID, Quantity) Values ('{0}','{1}','{2}','{3}')",
                                                       oShortage.ID, oShortage.CompanyID, drow["ProductID"].ToString(), drow["Quantity"].ToString()));

                        }

                    }
                    
                }
            }
            public void Load(Shortage oShortage)
            {
                Detail = oMySql.GetDataTable(String.Format("SELECT p.ProductID,p.Description,s.Quantity FROM ShortageDetail s Left Join Product p On s.CompanyID=p.CompanyID And s.ProductID=p.ProductID Where ShortageID='"+oShortage.ID+"'"),"ShortageDetail");
                DataColumn colWork = new DataColumn("SubTotal", System.Type.GetType("System.Double"));
                Detail.Columns.Add(colWork);
            }

            protected void SetColumns()
            {

                // create and add a CustomerID column
                DataColumn colWork = new DataColumn("ProductID", System.Type.GetType("System.String"));
                colWork.Unique = true;
                colWork.MaxLength = 20;
                colWork.Caption = "Item #";
                colWork.ReadOnly = true;
                this.Detail.Columns.Add(colWork);

                
                colWork = new DataColumn("Description", System.Type.GetType("System.String"));
                colWork.Caption = "Description";
                colWork.ReadOnly = true;
                Detail.Columns.Add(colWork);
                
                colWork = new DataColumn("Quantity", System.Type.GetType("System.Int16"));
                //  colWork.MaxLength = 10;
                Detail.Columns.Add(colWork);

                colWork = new DataColumn("SubTotal", System.Type.GetType("System.Double"));
                Detail.Columns.Add(colWork);



                DataColumn[] Keys = new DataColumn[1];
                Keys[0] = Detail.Columns["ProductID"]; //colWork;
                Detail.PrimaryKey = Keys;



                /*  // add a row
                DataRow row = Detail.NewRow();
                row["CustomerID"] = "2268";
                row["KitID"] = "KT7022";

                Detail.Rows.Add(row);
                */
                return;
            }
        }
    }
}