using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Signature.Communications;
using Signature.Data;
using System.Data;
using Signature.Classes;


namespace Signature.Classes
{
    public class BlueRibbon
    {
        public _Header Header;
        public _Detail Detail;
        private String CustomerID;
        private String CompanyID;
        private String FileName;

        private FileInfo t;
        private StreamWriter tw;

        private List<string> Page;

        public List<_Field> H_Fields;
        public List<_Field> D_Fields;


        public BlueRibbon()
        {
        }
        public BlueRibbon(String CompanyID, String CustomerID)
        {
            
            H_Fields = new List<_Field>();
            H_Fields.Add(new _Field("RecordType", 1, 1, 1));
            H_Fields.Add(new _Field("SchoolID", 20, 2, 21));
            H_Fields.Add(new _Field("StudentName", 20, 22, 41));
            H_Fields.Add(new _Field("CustomerName", 32, 42, 73));
            H_Fields.Add(new _Field("Address1", 50, 74, 123));
            H_Fields.Add(new _Field("Address2", 30, 124, 153));
            H_Fields.Add(new _Field("City", 30, 154, 183));
            H_Fields.Add(new _Field("State", 30, 184, 213));
            H_Fields.Add(new _Field("ZipCode", 10, 214, 223));
            H_Fields.Add(new _Field("Phone", 15, 224, 238));
            H_Fields.Add(new _Field("CustomerE-mail", 64, 239, 302));
            H_Fields.Add(new _Field("Homeroom", 20, 303, 322));
            H_Fields.Add(new _Field("OrderCode", 20, 323, 342));
            H_Fields.Add(new _Field("E-mailAddress", 64, 343, 406));

            D_Fields = new List<_Field>();
            D_Fields.Add(new _Field("RecordType",1,1,1));
            D_Fields.Add(new _Field("ProductID",20,2,21));
            D_Fields.Add(new _Field("Quantity",	10,22,31));
            D_Fields.Add(new _Field("UnitPrice",10,	32,	41));


            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;

            Header = new _Header();
            Detail = new _Detail();

            //Header.CustomerPO = "PO" + CustomerID;
            //Detail.CustomerPO = "PO" + CustomerID;

            //Open();
        }
        public void Open(String _FileName)
        {
            this.FileName = _FileName;
            
            t = new FileInfo(FileName);
            tw = t.CreateText();
            Header.tw = tw;
            Detail.tw = tw;


        }
        public void Close()
        {
            tw.Close();
        }
        
        public void SendFTPFile()
        {


            FTP.FTPPlumbing.Timeout = 50000;
            FTP.FTPPlumbing.PassiveMode = false;


            FTP oFTP = new FTP();
            oFTP.Connect("ftp.pinevalleyfoods.com", "PPS489", "sigfund"); //mail.giftcoinc.com
            
            Global.Message = "Connected...";
            oFTP.Files.Upload(FileName);
            Global.Message = "Uploading ... "+FileName;
            while (!oFTP.Files.UploadComplete)
            {
                //Console.WriteLine("Uploading: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());
                Global.Message = "Uploading...";

            }

            //Console.WriteLine("Upload Complete: TotalBytes: " + oFTP.Files.TotalBytes.ToString() + ", : PercentComplete: " + oFTP.Files.PercentComplete.ToString());


            oFTP.Disconnect();
            Global.Message = "Done!";

        }
        public void AddLine(String Line)
        {
            tw.WriteLine(Line);
        }

        #region Labels

        /// <summary>
        /// Reads in a .csv file.
        /// </summary>
        /// <param name="fileName">File path.</param>
        /// <param name="encoding">Encoding in which the file is written.</param>
        /// <param name="separator">The separator used to separate the fields</param>
        /// <returns></returns>
        public static DataTable ReadFromCsv(string fileName, Encoding encoding, char separator)
    {
        DataTable table = null;

        if (fileName != null &&
        !fileName.Equals(string.Empty) &&
        File.Exists(fileName))
        {
        try
        {
            // If required, you can collect some useful info from the file
            FileInfo info = new FileInfo(fileName);
            string tableName = info.Name;

            // Prepare for the data to be processed into a DataTable
            // We don't know how many records there are in the .csv, so we
            // use a List<string> to store the records in it temporarily.
            // We also prepare a DataTable;
            List<string> rows = new List<string>();

            // Then we read in the raw data
            StreamReader reader = new StreamReader(fileName, encoding);
            string record = reader.ReadLine();
            while (record != null)
            {
            rows.Add(record);
            record = reader.ReadLine();
            }

            // And we split it into chuncks.
            // Note that we keep track of the number of columns
            // in case the file has been tampered with, or has been made
            // in a weird kind of way (believe me: this does happen)

            // Here we will store the converted rows
            List<string[]> rowObjects = new List<string[]>();

            int maxColsCount = 0;
            foreach (string s in rows)
            {
            string[] convertedRow = s.Split(new char[] { separator });
            if (convertedRow.Length > maxColsCount)
                maxColsCount = convertedRow.Length;
            rowObjects.Add(convertedRow);
            }

            // Then we build the table
            table = new DataTable(tableName);
            for (int i = 0; i < maxColsCount; i++)
            {
            // Change this if you want other datatypes
            // make sure you also convert the string[] to
            // the corect datataype
            table.Columns.Add(new DataColumn());
            }

            foreach (string[] rowArray in rowObjects)
            {
            table.Rows.Add(rowArray);
            }
            table.AcceptChanges();
        }
        catch
        {
            throw new Exception("Error in ReadFromCsv: IO error.");
        }
        }
        else
        {
        throw new FileNotFoundException("Error in ReadFromCsv: the file path could not be found.");
        }
        return table;
    }

        public Boolean PrintXMLLabels()
        {
            // create and show an open file dialog
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.CheckFileExists = true;
            dlgOpen.Filter = "XML Files (*.xml)|*.XML";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                // Console.Write(dlgOpen.FileName);

                try
                {

                    DataSet table = new DataSet();
                    table.ReadXml(dlgOpen.FileName);



                    if (table.Tables["ecoupon"].Rows.Count == 0)
                    {
                        MessageBox.Show("No Labels to Print");
                        return false;
                    }

                    
                    Int32 Index = 1;
                    Int32 CurPage = 0;

                    int NumPages = (int)((table.Tables["ecoupon"].Rows.Count - 1) / 30) + 1;
                    
                    MessageBox.Show(table.Tables["ecoupon"].Rows.Count.ToString() + " label(s) to print");

                    Page = new List<string>();
                    foreach (DataRow row in table.Tables["ecoupon"].Rows)
                    {
                        int Result = 0;
                        Math.DivRem(Index, 30, out Result);
                        if (Result == 0)
                        {
                            if (NumPages > 1)
                            {
                                //MessageBox.Show("Printing Page " +CurPage.ToString());
                                CurPage++;
                                this.PrintPage();
                            }
                        }
                        Index++;
                        Page.Add(row["e_coupon"].ToString());
                    }
                    if (Page.Count > 0)
                    {
                        CurPage++;
                        Global.Message = "Printing Page " + CurPage.ToString();
                        this.PrintPage();
                    }
                    
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect XML File: " + ex.Message);
                    return false;
                }
            }
            return false;
        }
        public Boolean PrintXMLLabels1()
        {
            // create and show an open file dialog
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.CheckFileExists = true;
            dlgOpen.Filter = "XML Files (*.xml)|*.XML";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
               // Console.Write(dlgOpen.FileName);

                try
                {

                    DataSet table = new DataSet();
                    table.ReadXml(dlgOpen.FileName);



                    if (table.Tables["ecoupon"].Rows.Count == 0)
                    {
                        MessageBox.Show("No Labels to Print");
                        return false;
                    }

                    ParseWordDocument oDoc;
                    oDoc = new ParseWordDocument();
                    if (!oDoc.Open("CDL.dot"))
                        return false;
                    //oDoc.Open("ABC.dot");
                    Int32 nLabel = 1;
                    Int32 Index = 1;
                    Int32 CurPage = 0;

                    int NumPages = (int)((table.Tables["ecoupon"].Rows.Count-1) / 30) + 1;

                    MessageBox.Show(table.Tables["ecoupon"].Rows.Count.ToString()+" label(s) to print");

                    Hashlist list = new Hashlist();
                    foreach (DataRow row in table.Tables["ecoupon"].Rows)
                    {
                     //   MessageBox.Show(row["e_coupon"].ToString());
                        oDoc.SetField("Label" + nLabel, "\n" + row["e_coupon"].ToString());
                        
                        int Result = 0;
                        Math.DivRem(Index, 30, out Result);
                        if (Result == 0)
                        {
                            if (NumPages > 1)
                            {
                                //MessageBox.Show("Printing Page " +CurPage.ToString());
                                CurPage++;
                                Global.Message = "Printing Page " + CurPage.ToString();
                               
                                
                                nLabel = 0;
                                oDoc.Print();
                                oDoc.SaveAs("_temp"+DateTime.Now.Ticks.ToString()+".doc");
                               // oDoc.Clear();
                                oDoc.Close();

                                MessageBox.Show("Printing Page " + CurPage.ToString());
                                oDoc = new ParseWordDocument();
                                oDoc.Open("CDL.dot");
                            }
                        }
                        Index++;
                        nLabel++;
                    }
                    if (nLabel > 1)
                    {
                        CurPage++;
                        Global.Message = "Printing Page " + CurPage.ToString();

                        for (; nLabel <= 30; nLabel++)
                            oDoc.SetField("Label" + nLabel, " ");
                        oDoc.Print();
                        oDoc.SaveAs("_temp" + DateTime.Now.Ticks.ToString() + ".doc");
                    }
                    oDoc.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect XML File: "+ex.Message);
                    return false;
                }
            }
            return false;
        }
        private void PrintPage()
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
           // CreateUPC();
            
            float x = (float)0.5;
            float y = (float)0.5;
            
            Int32 curLabel = 0;

            for (int i = 0; i < 10; i++)
            {

                for (float z = 0; z <= 5.0; z += (float)2.5)
                {
                    DrawString(ev.Graphics, new System.Drawing.PointF((float)(0 + x + z),(float)( i + y)), Page[curLabel]);
                    curLabel++;
                    if (curLabel == Page.Count)
                        break;

                }
            }
            


            // Add Code here to print other information.

            ev.Graphics.Dispose();
        }
        public void DrawString(System.Drawing.Graphics g, System.Drawing.PointF pt, String _label)
        {

            // Save the GraphicsState.
            System.Drawing.Drawing2D.GraphicsState gs = g.Save();

            // Set the PageUnit to Inch because all of our measurements are in inches.
            g.PageUnit = System.Drawing.GraphicsUnit.Inch;

            // Set the PageScale to 1, so an inch will represent a true inch.
            g.PageScale = 1;


            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            float xPosition = pt.X;
            float xStart = pt.X;
            float yStart = pt.Y;
            

            System.Drawing.Font font = new System.Drawing.Font("Arial", 10);


            
            float yPosition = yStart ;
            // Draw Product Type.
            g.DrawString(_label, font, brush, new System.Drawing.PointF(xPosition, yPosition));

            // Restore the GraphicsState.
            g.Restore(gs);

        }
        #endregion

        public class _Header
        {
            public StreamWriter tw;
            
            public String RecordType = "H";
            public String SchoolID;
            public String StudentName;
            public String CustomerName="";
            public String Address1; // = DateTime.Now.ToString("MM/dd/yyyy");
            public String Address2;
            public String City;
            public String State;
            public String ZipCode;
            public String Phone;
            public String CustomerEmail;
            public String HomeRoom;
            public String OrderCode;
            public String eMail;
            

            public String GetString()
            {
                SetFields();
               
                
                String Header = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}",
                RecordType,
                SchoolID.PadLeft(20).Substring(0, 20),
                StudentName.PadRight(20).Substring(0, 20),
                CustomerName.PadRight(32).Substring(0, 32),
                Address1.PadRight(50).Substring(0, 50),
                Address2.PadRight(30).Substring(0, 30),
                City.PadRight(30).Substring(0, 30),
                State.PadRight(30).Substring(0, 30),
                ZipCode.PadRight(10).Substring(0, 10),
                Phone.PadRight(15).Substring(0, 15),
                CustomerEmail.PadRight(64).Substring(0, 64),
                HomeRoom.PadRight(20).Substring(0, 20),
                OrderCode.PadRight(20).Substring(0, 20),
                eMail.PadRight(64).Substring(0, 64)
                );
                
                return Header;
                
            }

            public void  AddLine()
            {
                tw.WriteLine(GetString());
            }
            
            public void SetFields()
            {
                
                /*CustomerPO="PO"+"CustomerID";
                
                ShipToID="PO"+"CustomerID";
                ShipToName="SCHOOL NAME";
                ShipToAttention = "CHAIRPERSON";
                ShipToAddress1 = "SCHOOL ADDRESS";
                ShipToAddress2 = "";
                ShipToCity = "SCHOOL CITY";
                ShipToState = "SCHOOL STATE";
                ShipToZip = "SCHOOL ZIP";
                ShipToPhone = "SCHOOL PHONE";
                */

            }

        }
        public class _Detail
        {
            private Char Sufix = ' ';
            private String Prefix = "";
            
            
            public String RecordType =   "D";
            public String ProductID;
            public String Quantity;
            public String UnitPrice;

            public StreamWriter tw;

            
            
            
            public void SetFields()
            {
            }
            public String GetString()
            {
                
                String Detail =  String.Format("{0}{1}{2}{3}",
                RecordType,
                ProductID.PadRight(20, ' ').Substring(0, 20),
                Quantity.ToString().PadLeft(10).Substring(0,10),
                UnitPrice.ToString().PadLeft(10).Substring(0, 10)
                );
            
                return Detail;
            }
            private String GetNextTeacher()
            {
                if (Sufix == 'Z')
                {
                    this.Prefix += "Z";
                    this.Sufix = 'A';
                }
                else if (Sufix == ' ')
                {
                    Sufix = 'A';
                }
                else
                {
                    this.Sufix++;
                }
                return Prefix + Sufix.ToString();
            }
            public void  AddLine()
            {
                tw.WriteLine(GetString());
            }
            
        }
        public class _Field
        {
            public String Name;
            public String Description;
            public Int32 Length;
            public Int32 Start;
            public Int32 End;
            public String Comments;


            public _Field(String Name,  Int32 Length, Int32 Start, Int32 End)
            {
                this.Name = Name;
                //this.Description = Description;
                this.Length = Length;
                this.Start = Start;
                this.End=End;
                //this.Comments = Comments;
            }
        }
    }
}
