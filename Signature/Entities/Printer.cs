using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;


[StructLayout(LayoutKind.Sequential)]
public struct DOCINFO
{
    [MarshalAs(UnmanagedType.LPWStr)]
    public string pDocName;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string pOutputFile;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string pDataType;
}


namespace Signature.Classes
{

    public enum PrinterDevice
    {
        None     = 0,
        Printer  = 1,
        File     = 2,
        Console  = 3,
        Screen   = 4,
        eMail    = 5,
        PDF      = 6,
        Viewer   = 7
     }
    public class PrintDirect
{
            [ DllImport( "winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=false,
            CallingConvention=CallingConvention.StdCall )]public static extern bool OpenPrinter (string pPrinterName,ref IntPtr phPrinter, int pDefault);
            [ DllImport( "winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=false,
            CallingConvention=CallingConvention.StdCall )]
            public static extern bool StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO
            pDocInfo);
            [ DllImport("winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);
            [ DllImport( "winspool.drv",CharSet=CharSet.Ansi,ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]public static extern bool WritePrinter(
            IntPtr hPrinter,string data, int buf,ref int pcWritten);
            [ DllImport( "winspool.drv" ,CharSet=CharSet.Unicode,ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]
            public static extern long EndPagePrinter(IntPtr hPrinter);
            [ DllImport( "winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]
            public static extern long EndDocPrinter(IntPtr hPrinter);
            [ DllImport("winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall )]
            public static extern long ClosePrinter(IntPtr hPrinter);
            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            
            [DllImport("winspool.drv")]
            public static extern bool AddPrinterConnection(string pName);

            [DllImport("winspool.drv", EntryPoint = "DeletePrinterConnection")]
            public static extern int DeletePrinterConnectionA(string pName);
}
    public class LinePrint
    {
        private System.IntPtr lhPrinter = new System.IntPtr();
        private DOCINFO di = new DOCINFO();
        private int CharsWritten = 0;
        private String _DocName = "Default Signature Fundraising Document";
        private String _PrinterName = null;
        public int _CurrentLine = 0;
        //int MaxLines =60;
        public String _curStrLine = null;
        public int _LineSize = 80;
        public String _FileName = "tmp.txt"; // Path.GetTempFileName();
        public int _PrintDevice = (int)PrinterDevice.Printer;
        private FileStream fs;


        public LinePrint(String PrinterName)
        {
            _PrinterName = PrinterName;

        }
        public LinePrint()
        {
            _PrinterName = "\\\\Alvaro\\hp";
        }

        public void Open()
        {
            if (_PrintDevice == (int)PrinterDevice.Printer)
            {
                di.pDocName = _DocName;
                di.pDataType = "RAW";

                PrintDirect.OpenPrinter(_PrinterName, ref lhPrinter, 0);
                PrintDirect.StartDocPrinter(lhPrinter, 1, ref di);
                PrintDirect.StartPagePrinter(lhPrinter);
            }
            else if ((_PrintDevice == (int)PrinterDevice.File))
            {
                fs = File.Open(_FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            }


        }
        public void Close()
        {
            if (_PrintDevice == (int)PrinterDevice.Printer)
            {
                PrintDirect.EndPagePrinter(lhPrinter);
                PrintDirect.EndDocPrinter(lhPrinter);
                PrintDirect.ClosePrinter(lhPrinter);
            }
            else if ((_PrintDevice == (int)PrinterDevice.File))
            {
                fs.Close();
            }
        }
        public String SetLine(int X, String Str)
        {

            String Line = null;

            int Pos = X - 1;

            if (_curStrLine == null)
                _curStrLine = new string(' ', _LineSize);


            if (_curStrLine.Length < _LineSize)
                Line = new string(' ', _LineSize);
            else
                Line = _curStrLine;

            if (Pos > _LineSize - 1 || Pos == -1)
                Str = null;
            else if (Pos + Str.Length > _LineSize)
                Str = Str.Substring(0, _LineSize - Pos);

            if (Str != null)
                Line = Line.Substring(0, Pos) + Str + Line.Substring(Pos + Str.Length, Line.Length - (Pos + Str.Length));

            _curStrLine = Line;

            // MessageBox.Show(Line);

            return _curStrLine;
        }
        public void LPrintLine(int Y)
        {
            LPrint(_curStrLine.TrimEnd(' '), Y);
            _curStrLine = null;
        }
        public void LPrintLine()
        {
            LPrint(_curStrLine.TrimEnd(' '));
            _curStrLine = null;
        }
        public void LPrint(String Line, int Y)
        {
            if (Y == _CurrentLine)
            {
                LPrint(Line);
            }

            else if (Y > _CurrentLine)
            {

                for (; _CurrentLine < Y; )
                {
                    Print(Control.CRLF);
                }
                LPrint(Line);
            }
            else
            {
                _CurrentLine = 0;
                /*Print(Control.FF);
                LPrint(Line);*/
            }
        }
        public bool Print(String Line)
        {
            try
            {
                if (_PrintDevice == (int)PrinterDevice.Printer)
                {
                    PrintDirect.WritePrinter(lhPrinter, Line, Line.Length, ref CharsWritten);
                }
                else if ((_PrintDevice == (int)PrinterDevice.File))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Line);

                    fs.Write(info, 0, info.Length);
                }
                else
                    Console.WriteLine(Line);

                if (Line.IndexOf(Control.CRLF) >= 0)
                {
                    _CurrentLine++;

                }
                if (Line.IndexOf(Control.FF) >= 0)
                {
                    _CurrentLine = 0;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public bool LPrint(String Line)
        {
            return Print(Line + Control.CRLF);
        }
        public void ResetLines()
        {
            _CurrentLine = 0;
        }
        public String DocName
        {
            get { return _DocName; }


            set
            {
                di.pDocName = DocName;
                _DocName = value;
            }
        }
        public String PrinterName
        {
            get { return _PrinterName; }


            set
            {
                _PrinterName = value;
            }
        }

        public static class Control
        {
            static public int _PrinterType = 0; //0=Printronix, 1=Epson/IBMProprinter
            static private String LF = "\x0A";
            static public String FF = "\x0C"; //'\t'
            static private String CR = "\x0D";
            static public String ESC = "\x1B";
            static public String CP = "\x0F";
            static public String Condensed = "\x0F";
            static public String CancelCondensed = "\x12";
            static public String SO = "\x0E";                   // Select Double-Width Printing (One Line)
            static private String SCC = "\x01";                 //Default for  Printronix
            static private String SSCC = (_PrinterType == 0) ? SCC + "\x7C\x7D\x3B" : "";  //"| } ;";
            static public String EP_On = (_PrinterType == 0) ? SCC + "\x57" + "\x31" : "";
            static public String EP_Off = (_PrinterType == 0) ? SCC + "\x57" + "\x30" : "";
            static public String SP_1_6 = (_PrinterType == 0) ? SCC + "\x32" : "";
            static public String SP_n_72_6 = (_PrinterType == 0) ? SCC + "\x32" : "";
            static public String Font = (_PrinterType == 0) ? SSCC + "S93779;1;0;xxx;0048;0096" : "";
            static public String CRLF = CR + LF;

            static public String SP_n_72(int LineSpacing)
            {
                return SSCC + "\x41" + Convert.ToChar(LineSpacing).ToString();

            }


        }
        public static bool SendBytesToPrinter(string szPrinterName, String pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr();
            DOCINFO di = new DOCINFO();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (PrintDirect.OpenPrinter(szPrinterName, ref hPrinter, 0))
            {
                // Start a document.
                if (PrintDirect.StartDocPrinter(hPrinter, 1, ref di))
                {
                    // Start a page.
                    if (PrintDirect.StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = PrintDirect.WritePrinter(hPrinter, pBytes, dwCount, ref dwWritten);
                        PrintDirect.EndPagePrinter(hPrinter);
                    }
                    PrintDirect.EndDocPrinter(hPrinter);
                }
                PrintDirect.ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }
        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            //   bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            //SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
        public void GetPrinter()
        {
            //  private void button1_Click(object sender, System.EventArgs e)
            //{
            /*
                // Allow the user to select a file.
            OpenFileDialog ofd = new OpenFileDialog();
            if( DialogResult.OK == ofd.ShowDialog(this) )
                {
                // Allow the user to select a printer.
                PrintDialog pd  = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if( DialogResult.OK == pd.ShowDialog(this) )
                    {
                        // Print the file to the printer.
                        RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName);
                    }
            }*/
            /*
            private void button2_Click(object sender, System.EventArgs e)
            {
            string s = "Hello"; // device-dependent string, need a FormFeed?
    
            // Allow the user to select a printer.
            PrintDialog pd  = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if( DialogResult.OK == pd.ShowDialog(this) )
                {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }*/


        }

        
    }

    public class Printer
    {
        public Boolean PrintronixsExist
        {
            get { return true; }
        }

        public void CkeckPrintronixs()
        {
         //   Global.Message = System.Environment.UserDomainName.ToUpper();
          //  if (System.Environment.UserDomainName.ToUpper() == "SIGFUND.COM")
            if (Global.CurrentUser != "ALVARO")
            {
                CheckAndDelete(@"\\srv1\PACKING");
                CheckOrCreate(@"\\srv1\Packing_1");
                CheckOrCreate(@"\\srv1\Packing_2");
                CheckOrCreate(@"\\srv1\Packing_3");
                CheckOrCreate(@"\\srv1\Packing_4");
                CheckOrCreate(@"\\srv1\Packing_5");
                CheckOrCreate(@"\\srv1\Invoice");
                CheckOrCreate(@"\\srv1\Plain");
                CheckOrCreate(@"\\srv1\Letters_1");
                CheckOrCreate(@"\\srv1\Letters_2");
                CheckOrCreate(@"\\srv1\Letters_3");
                CheckOrCreate(@"\\srv1\LINE1");
                CheckOrCreate(@"\\srv1\BillOfLading");
                CheckOrCreate(@"\\srv1\Shortage");
                CheckOrCreate(@"\\srv1\WH_P5205");
                CheckOrCreate(@"\\srv1\Imprinting_1");
                CheckOrCreate(@"\\srv1\Imprinting_2");
                CheckOrCreate(@"\\srv1\Imprinting_3");
                CheckOrCreate(@"\\srv1\Imprinting_4");
            }
        }

        public void CheckOrCreate(String Name)
        {
            
            if (!Exist(Name))
            {
                this.AddPrinterConnection(Name);
            }
        }
        public void CheckAndDelete(String Name)
        {

            if (!Exist(Name))
            {
                this.DeletePrinterConnection(Name);
            }
        }

        public bool DeletePrinterConnection(String Printer)
        {
            int result;
            Global.ShowNotifier("Deleting printer : " + Printer);
            try
            {
                result = PrintDirect.DeletePrinterConnectionA(Printer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
                return false;
            }
            //Console.Read();
            return true;
        }

        public  bool AddPrinterConnection(String Printer)
        {
            bool result;
            Global.ShowNotifier("Adding printer : " + Printer);
            try
            {
                //result = PrintDirect.AddPrinterConnection("\\\\sha-prn-01\\2017hp8100");
                //Console.WriteLine("result:" + result);
                result = PrintDirect.AddPrinterConnection(Printer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
                return false;
            }
            //Console.Read();
            return true;
        }


        public bool Exist(String Name)
        {
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {

                if (printer.ToUpper() == Name.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

