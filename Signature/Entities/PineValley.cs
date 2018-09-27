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
    public class PineValley
    {
        public _Header Header;
        public _Detail Detail;
        private String CustomerID;
        private String CompanyID;
        private String FileName;

        private FileInfo t;
        private StreamWriter tw;

        private List<string> Page;


        public PineValley()
        {
        }
        public PineValley(String CompanyID, String CustomerID)
        {
            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;
            
            Header = new _Header();
            Detail = new _Detail();

            Header.CustomerPO = "PO" + CustomerID;
            Detail.CustomerPO = "PO" + CustomerID;

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
                if (curLabel == Page.Count)
                    break;
            }
            Page.Clear();


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
            
            String Type="H";
            String OrderType="1";

            public String CustomerNumber="0000489";
            public String CustomerPO;
            public String OrderNumber="";
            public String ArrivalWeek = DateTime.Now.ToString("MM/dd/yyyy");
            public String ShipToID;
            public String ShipToName;
            public String ShipToAttention;
            public String ShipToAddress1;
            public String ShipToAddress2;
            public String ShipToCity;
            public String ShipToState;
            public String ShipToZip;
            public String ShipToPhone;
            public String OrderNotes="";
            public String ConfirmEmail1="scott@sigfund.com";
            public String ConfirmEmail2="";
            public String LiftGate="1";
            public String ResidencialDelivery="0";
            public String InsideDelivery="1";
            public String FUTUREUSE="";
            public String TimeCritical="0";
            

            public String GetString()
            {
                SetFields();
               /* String Header = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},",
                Type,
                OrderType,
                CustomerNumber,
                CustomerPO,
                OrderNumber,
                ArrivalWeek,
                ShipToID,
                ShipToName,
                ShipToAttention,
                ShipToAddress1,
                ShipToAddress2,
                ShipToCity,
                ShipToState,
                ShipToZip,
                ShipToPhone,
                OrderNotes,
                ConfirmEmail1,
                ConfirmEmail2,
                LiftGate,
                ResidencialDelivery,
                InsideDelivery,
                FUTUREUSE,
                TimeCritical
                );*/
                String Header = String.Format("{0},{1},,,,,,,{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}",
                Type,
                OrderType,
                CustomerNumber,
                CustomerPO,
                OrderNumber,
                ArrivalWeek,
                ShipToID,
                ShipToName,
                ShipToAttention,
                ShipToAddress1,
                ShipToAddress2,
                ShipToCity,
                ShipToState,
                ShipToZip,
                ShipToPhone,
                OrderNotes,
                ConfirmEmail1,
                ConfirmEmail2,
                LiftGate,
                ResidencialDelivery,
                InsideDelivery,
                FUTUREUSE,
                TimeCritical
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
            private Int32 StudentSeq=0;
            
            String Type =   "D";
            String OrderType    =   "1";
            
            public String TeacherID;
            public String TeacherName;
            public String StudentID;
            public String StudentName;
            public String ItemNumber;
            public String Quantity;
            public String CustomerPO;

            public StreamWriter tw;

            private String LastTeacher = "";
            private String LastStudent = "";

            
            
            public void SetFields()
            {
                TeacherID = "A";                //A,B,C...for each tecaher
                TeacherName = "TEACHER, NAME".Replace(',',' ');
                StudentID = "001";              //001,002,003...for each student
                StudentName = "STUDENT, NAME".Replace(',', ' ');
                ItemNumber = "ITEM NUMBER";
                Quantity = "Quantity";
                CustomerPO = "PO" + "CustomerID";
            }
            public String GetString()
            {
                if (LastTeacher != TeacherName)
                {
                    LastTeacher = TeacherName;
                    TeacherID = GetNextTeacher();
                    StudentSeq = 0;
                }
                
                if (LastStudent != StudentName)
                {
                    LastStudent = StudentName;
                    StudentSeq++;
                }
                
                StudentID = StudentSeq.ToString("000");
                
             //   this.SetFields();
                String Detail = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},,{8}",
                Type,
                OrderType,
                TeacherID,
                TeacherName.Replace(",", "").Replace("'", "").PadRight(20, ' ').Substring(0, 20).Trim(),
                StudentID,
                StudentName.Replace(",", "").Replace("'", "").PadRight(20, ' ').Substring(0, 20).Trim(),
                ItemNumber,
                Quantity,
                CustomerPO
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

    }
}
