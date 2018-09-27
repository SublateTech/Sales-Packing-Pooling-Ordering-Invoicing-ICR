using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Signature.Data;
using Signature;
using Signature.Reports;
using Signature.Card;

namespace Signature.Classes
{
    public class Ticket:Company
    {
        public enum ImprintType
        {
            Card   = 0,
            Envelope = 1
        }
        
        internal new SqlBuilder oBuild; //Reuqired
        
        private Int32  _ID;
        public Int32  _OrderID;
        public String ProductID;
        public Int32  Quantity;
        public _Lines _lines;
        public _Lines _linesEnvelope;
        public Boolean IsPrinted;
        public DateTime DatePrinted;
        public String User;
        public Boolean IsBussines;
        public Double ImprintFee;
        public String PictureFileName;
        

        public new Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
        
        public _Lines Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }

        public _Lines LinesEnvelope
        {
            get { return _linesEnvelope; }
            set { _linesEnvelope = value; }
        }

        public Ticket(String CompanyID):base(CompanyID)
        {
            Lines = new _Lines(CompanyID, ImprintType.Card);
            LinesEnvelope =  new _Lines(CompanyID, ImprintType.Envelope);
        }

        private void Clear()
        {
            ID=0;
            OrderID=0;
            ProductID=  "";
            Quantity=0;
            Lines.Clear();
            IsPrinted = false;
            User    = "";
            IsBussines = false;
            ImprintFee = 0;
            PictureFileName = String.Empty;
            CompanyID = base.ID;
        }

        public bool Find(Int32  TicketID)
        {
            //this.CallID = String.Empty;

            if (TicketID == 0)
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From OrderTicket Where ID='" + TicketID +"'", "Ticket");

            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.ID             = (Int32) Row["ID"];
            this.OrderID        = (Int32) Row["OrderID"];
            this.Quantity       = (Int32)Row["Quantity"];
            this.IsPrinted      = (Boolean)Row["Printed"];
            this.ProductID      = Row["ProductID"].ToString();
            this.User           = Row["User"].ToString();
            this.IsBussines     = (Boolean)Row["IsBussines"];
            this.ImprintFee     = (Double)Row["ImprintFee"];
            this.PictureFileName = Row["PictureFileName"].ToString();
            this.CompanyID      = Row["CompanyID"].ToString();

            this.Lines.Load(this);
            this.LinesEnvelope.Load(this);
            return true;

        }

        public bool Find(Int32 OrderID, String ProductID)
        {
            //this.CallID = String.Empty;

            if (OrderID == 0)
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From OrderTicket Where OrderID='" + OrderID.ToString() + "' And ProductID='" + ProductID +"'", "Ticket");

            if (Row == null)
            {
                Clear();
                return false;
            }

            return this.Find((Int32)Row["ID"]);
        }
        public bool FindNext(Int32 OrderID, String ProductID)
        {
            //this.CallID = String.Empty;

            if (OrderID == 0)
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From OrderTicket Where OrderID='" + OrderID.ToString() + "' And ProductID='" + ProductID + "' And Printed='0'", "Ticket");

            if (Row == null)
            {
                Clear();
                return false;
            }

            return this.Find((Int32)Row["ID"]);
        }

        public new void Save()
        {
            if (Exists() && this.ID != 0)
                Update();
            else
                Insert();

            this.Lines.Save(this);
            this.LinesEnvelope.Save(this);
        }
        public new void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update("Where ID='"+this.ID.ToString()+"'"));
        }
        public  void UpdatePrinted()
        {
            oMySql.exec_sql(String.Format("Update OrderTicket Set Printed='{0}',DatePrinted=NOW() Where ID='{1}'",IsPrinted?"1":"0",this.ID));
        }
        public new void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert());

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("OrderTicket", new String[] { 
                "OrderID",
                "ProductID", 
                "Quantity",
                "Printed",
                "DatePrinted",
                "User",
                "IsBussines",
                "ImprintFee",
                "PictureFileName",
                "CompanyID"
                
                },
                new Object[] {
                    this.OrderID,
                    this.ProductID,
                    this.Quantity,
                    this.IsPrinted?"1":"0",
                    Global.oMySql.SqlTimeDate(DateTime.Now),
                    Global.CurrentUser,
                    this.IsBussines?"1":"0",
                    this.ImprintFee,
                    this.PictureFileName,
                    this.CompanyID
                    });
        }
        public new bool Exists()
        {
            if ((oMySql.exec_sql_no("Select count(*) from OrderTicket Where ID='" + this.ID + "'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From OrderTicket Where ID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
            this.Lines.Delete(this);
        }

        public void DeleteByOrder(Int32 OrderID)
        {
            String Sql = "Delete From OrderTicket Where OrderID='" + OrderID + "'";
            oMySql.exec_sql(Sql);
        }

        public new virtual bool View()
        {
            frmViewTickets oView = new frmViewTickets(CompanyID,"");
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(Convert.ToInt32(oView.sSelectedID));
                return true;
            }
            return false;
        }

        public void Print()
        {
            frmViewReport oViewReport = new frmViewReport();

            DataSet ds = new DataSet();
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Customer c Left Join Orders o On c.CustomerID=o.CustomerID And c.CompanyID=o.CompanyID  Where o.ID='{0}'", this.OrderID), "Customer"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From OrderTicket Where ID='{0}'", ID), "Ticket"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From OrderTicketDetail Where TicketID='{0}'", ID), "TicketDetail"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Orders Where ID='{0}'", this.OrderID), "Orders"));
            ds.Tables.Add(oMySql.GetDataTable(String.Format("Select * From Product Where ProductID='{0}'", this.ProductID), "Product"));


            TicketReport oRpt = new TicketReport();
            //ds.WriteXml("PrintTicket1.xml", XmlWriteMode.WriteSchema);
            
            oRpt.SetDataSource(ds);
            oRpt.SetParameterValue("CompanyName", "Signature Fundraising, Inc.");

            oViewReport.cReport.ReportSource = oRpt;
            oViewReport.Show();
            //oViewReport.cReport.PrintReport();
        }

        public void SaveFileName(String FullFileName, System.Drawing.Image image)
        {
            if (FullFileName != "")
            {
                Int32 IdTicket = this.ID;
                System.IO.FileInfo FullName = new System.IO.FileInfo(FullFileName);
                String SourceFileName = FullName.Name;
                String FileName = "Ticket" + IdTicket.ToString().PadLeft(6, '0') + ".Jpg";
                String Directory = @Global.ImageDirectory;

                if (System.IO.File.Exists(Directory + FileName))
                {
                    System.IO.File.Delete(Directory + FileName);
                }
                String test = Directory + FileName;
                image.Save(Directory + FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                this.PictureFileName = FileName;
                this.Save();
            }
            else
                this.PictureFileName = "";
        }

        public Boolean Print(Boolean isTest)
        {
            Boolean _Printed = false;
            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (this.Lines.Count > 0)
            {
                String PrinterName = Global.OpenPrintDialog();
                if (PrinterName != "")
                {

                    CardTemplate oCardTemplate = new CardTemplate();
                    Card oCard = new Card(this.CompanyID);
                    oCard.Find(this.ProductID);
                    if (!oCardTemplate.Find(oCard.CardTemplateID))
                    {
                        MessageBox.Show("No template found: " + oCard.CardTemplateID.ToString());
                        return false;
                    }

                    CardPrinter CardPrinter = new CardPrinter();
                    
                    CardPrinter.PrinterSettings.PrinterName = PrinterName;

                    CardPrinter.Clear();
                    foreach (Line oLine in this.Lines)
                    {
                        CardPrinter.Add(oLine.Text);
                    }

                    if (oCard.AsTemplate)
                        CardPrinter.Point = oCardTemplate.Point;
                    else
                        CardPrinter.Point = new PointF((float)(oCard.PointX * 100), (float)(oCard.PointY * 100));

                    CardPrinter.PaperSize = oCardTemplate.PaperSize;
                    CardPrinter.Copies = 24;
                    CardPrinter.UpperCase = false;

                    CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                    CardPrinter.TestMode = false;

                    if (this.PictureFileName != "")
                    {
                        CardPrinter.PrintType = CardPrintType.Image;
                        CardPrinter.FileName = Global.ImageDirectory + this.PictureFileName;
                    }
                    CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                    //  CardPrinter.Settings();
                    CardPrinter.Print();
                    _Printed = true;
                }
            }
            return _Printed;

        }
        public Boolean PrintEnvelope(Boolean isTest)
        {
            Boolean _Printed = false;
            //CardPrinterPrinterSettings.PrinterName = "IS700C";
            //CardPrinter.PrinterSettings.PrinterName = "RISO RZ 9 Series";
            // CardPrinter.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS"; 
            //CardPrinter.PrinterSettings.PrinterName = "RISO RN2550(ADVANCE)";
            //CardPrinter.PrinterSettings.PrinterName = "Send To OneNote 2007";
            if (this.Lines.Count > 0)
            {
                String PrinterName = Global.OpenPrintDialog();
                if (PrinterName != "")
                {

                    CardTemplate oCardTemplate = new CardTemplate();
                    Card oCard = new Card(this.CompanyID);
                    oCard.Find(this.ProductID);
                    if (!oCardTemplate.Find(oCard.EnvTemplateID))
                    {
                        MessageBox.Show("No template found for the envelope: " + oCard.EnvTemplateID.ToString());
                        return false;
                    }

                    CardPrinter CardPrinter = new CardPrinter();

                    CardPrinter.PrinterSettings.PrinterName = PrinterName;

                    CardPrinter.Clear();
                    foreach (Line oLine in this.LinesEnvelope)
                    {
                        CardPrinter.Add(oLine.Text);
                    }

                    
                    CardPrinter.Point = oCardTemplate.Point;
                    
                    CardPrinter.PaperSize = oCardTemplate.PaperSize;
                    CardPrinter.Copies = 24;
                    CardPrinter.UpperCase = false;

                    CardPrinter.Rotation = (short)oCardTemplate.Rotation;
                    CardPrinter.TestMode = false;

                    CardPrinter.Font = new Font(oCardTemplate.FontName, oCardTemplate.FontSize, oCardTemplate.Bold ? FontStyle.Bold : FontStyle.Regular);
                    //  CardPrinter.Settings();
                    CardPrinter.Print();
                    _Printed = true;
                }
            }
            return _Printed;

        }
        public class Line  
        {
            protected SqlBuilder oBuild;

            public Int32 ID = 0;
            public Int32 TicketID = 0;
            private String _Text = "";
            public ImprintType Type = ImprintType.Card;


            public String Text
            {
                get { return _Text; }
                set { _Text = value; }
            }


            private void Clear()
            {
                TicketID = 0;
                Text = "";
            }
            public bool Find(Int32 ID)
            {
                DataRow rRow = Global.oMySql.GetDataRow("Select * From OrderTicketDetail Where ID='" + ID.ToString() + "'", "Tmp");

                if (rRow == null)
                {
                    Clear();
                    return false;
                }

                this.ID         = (Int32)rRow["ID"]; 
                this.TicketID   = (Int32)rRow["TicketID"];
                this.Text       = rRow["Text"].ToString();
                return true;

            }
            public void DeleteAll(Int32 OrderID)
            {
                String Sql = "Delete from OrderByLine Where OrderID='" + OrderID + "' And Packed='0'";
                Global.oMySql.exec_sql(Sql);
            }

            public  void Save()
            {

                if (Exists())
                    Update();
                else
                    Insert();
            }
            public  void Update()
            {
                this.Text = MySQL.PrepareSql(this.Text);
                FillFields();
                Global.oMySql.exec_sql(oBuild.Update("Where ID='" + this.ID + "'"));
            }
            public  void Insert()
            {
                //   MessageBox.Show(oBuild.Insert());
                this.Text = MySQL.PrepareSql(this.Text);
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
                    this.TicketID,
                    this.Text,
                    (Int32) this.Type
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
                String Sql = "Delete From OrderByBrochure Where OrderID='" + this.TicketID + "'";
                Global.oMySql.exec_sql(Sql);
            }
        }
        public class _Lines : Hashlist
        {
            public ImprintType Type;
            
            public _Lines(String CompanyID, ImprintType impType) : base(CompanyID) 
            {
                Type = impType;
            }
            public void Load(Ticket oTicket)
            {
                
                this.Clear();
                DataTable dt = oMySql.GetDataTable(String.Format("SELECT ID FROM OrderTicketDetail Where TicketID='{0}' And Type='{1}'", oTicket.ID, (Int32)this.Type));
                if (dt == null)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Line LO = new Line();
                        LO.Find((Int32) row["ID"]);
                        this.Add(row["ID"].ToString(), LO);
                    }
                }
            }
            public void Save(Ticket oTicket)
            {
                this.Delete(oTicket);
                foreach(Line oLine in this)
                {
                    oLine.TicketID = oTicket.ID;
                    oLine.Type = this.Type;
                    oLine.Insert();
                }
            }

            public void Delete(Ticket oTicket)
            {
                String Sql = "Delete From OrderTicketDetail Where TicketID='" + oTicket.ID + "' And Type='"+ (Int32)this.Type+"'";
                oMySql.exec_sql(Sql);
            }

            /* Hash List Support */
            public new Line this[string Key]
            {
                get { return (Line)base[Key]; }

            }
            public new Line this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (Line)oTemp;
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
            public _LinesEnumerator(_Lines ar)
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
            protected _Lines _ar;


        }

    }
}
