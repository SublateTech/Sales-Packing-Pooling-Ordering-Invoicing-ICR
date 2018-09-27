using System;

using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Signature.Classes
{
    public class Pallet : System.Drawing.Printing.PrintDocument
    {
        public enum LineJustify
        {
            None = 0,
            Left = 1,
            Right = 2,
            Center = 3
        }

        
        public class Area
        {
            public RectangleF Rectangle = new RectangleF();
            public String Text = String.Empty;
            public Font Font = new Font("Arial", 100);
            public Int32 ResultLines = 0;
            public Int32 MaxLines = 6;
            public LineJustify Justify = LineJustify.None;

        }

        
        #region Property Variables 
        
        private ArrayList Lines = new ArrayList();
        public ArrayList Areas = new ArrayList();
        
        public long Width = 0;
        public long Height = 0;

        private RectangleF printArea = new RectangleF();
        public Int32 MinWordSize = 2;

        private short _Copies = 0;
        public short Copies
        {
            get { return _Copies; }
            set { _Copies = value; }
        }
        
        #endregion

        #region  Class Constructors 
        public Pallet() : base()
        {
            this.Areas.Clear();  
        }
        #endregion

        #region  OnBeginPrint 
        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            this.Settings();
            // Run base code
            base.OnBeginPrint(e);
        }
        #endregion

        #region  OnPrintPage 
        /// <summary>
        /// Override the default OnPrintPage method of the PrintDocument
        /// </summary>
        /// <param name=e></param>
        /// <remarks>This provides the print logic for our document</remarks>
        protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        { 
            // Run base code
            base.OnPrintPage(e);
           
            
            Double  top;
            Double  left;
           
            Height = (long)base.DefaultPageSettings.PrintableArea.Height ;
            Width = (long)base.DefaultPageSettings.PrintableArea.Width;
            left        = base.DefaultPageSettings.Margins.Left;
            top         = base.DefaultPageSettings.Margins.Top;
           

            //Create a rectangle printing are for our document
            printArea = new RectangleF((float)left, (float)top, (float)Width, (float)Height);

           // e.Graphics.DrawRectangle(new Pen(Brushes.Gray), new Rectangle((int)printArea.X, (int)printArea.Y, (int)printArea.Width, (int)printArea.Height));
            this.PrintAreas(e.Graphics);
           
            //Just One Page
            e.HasMorePages = false;
        }


        #endregion

        public void Add(String Line)
        {
            Lines.Add(Line);
        }

        private void Settings()
        {
           
            
            
            this.DefaultPageSettings.Margins    = new Margins(0, 0, 0, 0);
            this.DefaultPageSettings.Landscape  = false;

            this.PrinterSettings.Copies         = this.Copies;
            this.PrinterSettings.MaximumPage    = 1;
            this.PrinterSettings.ToPage         = 1;

            this.DocumentName = "testing print";

            

        }
        private void PrintAreas(Graphics g)
        {

            foreach (Area _area in Areas)
            {
                if (_area.Rectangle.Width == 0)
                    _area.Rectangle = new RectangleF(_area.Rectangle.Left, _area.Rectangle.Top, this.Width, _area.Rectangle.Height);

                AdjustText(_area, g);
                PrintText(_area, g);
            }
        }

        private void AdjustText(Area _area, Graphics g)
        {
            for (int lines = 1; lines <= 10; lines++)
            {
                _area.ResultLines = lines;
                _area.Font = GetFontBySize((int)_area.Rectangle.Height / lines,_area);
                
                String[] text = GetLines(_area.Text.ToUpper(), lines);
                if (text.Length < lines)
                {
                    _area.MaxLines = text.Length;
                    _area.ResultLines = text.Length;
                    _area.Font = GetFontBySize((int)_area.Rectangle.Height / text.Length, _area);

                }
                if (TestFont(text, g, _area))
                {
                    this.Lines.Clear();
                    foreach (String text_ in text)
                    {
                        this.Lines.Add(text_);
                    }
                    return;
                }
            }
        }
        public Font GetFontBySize(Int32 _Height, Area area)
        {
            int fontSize = 1;
            Font font;
            
            do
            {
                font = new Font(area.Font.Name, fontSize++);
            } while (_Height > font.Height) ;
            
            if (_Height < font.Height)
            {
                do
                {
                    font = new Font(area.Font.Name, fontSize--);
                } while (_Height < font.Height);
            }
            return font;
        }
        private void PrintText(Area area, Graphics g)
        {
           // g.DrawRectangle(new Pen(Brushes.Gray, 0.1f), (float)area.Rectangle.Left, (float)area.Rectangle.Top, (float)area.Rectangle.Width, (float)area.Rectangle.Height);
           
            float top = (float)area.Rectangle.Top  + (float)area.Rectangle.Height / 2 - area.Font.Height * Lines.Count / 2;
            foreach (String _text in Lines)
            {
                float h_pos = 0;
                if (area.Justify == LineJustify.Center)
                {
                    SizeF textSize = g.MeasureString( _text, area.Font);
                    h_pos = area.Rectangle.Width / 2 - (textSize.Width / 2);
                }
                else
                    h_pos = area.Rectangle.Left;

                g.DrawString(_text, area.Font, Brushes.Black, h_pos, top);
                top += (float)area.Font.Height;
            }
            
        }
        public String[] GetLines(String Name, Int32 ResultLines)
        {
            String[] result1;
            Int32 Length = 0;
            do
            {
            again:
                result1 = SplitStringIntoLines(Name, Length);
                Boolean Nop = false;
                foreach (String str in result1)
                {
                    if (str.Trim().Length < this.MinWordSize && result1.Length > 1)
                    {
                        Nop = true;
                    }
                }
                Length++;
                if (Nop)
                    goto again;
            } while (result1.Length > ResultLines);
            return result1;
        }
        public Boolean TestFont(String[] Result, Graphics g, Area area)
        {

            float MaxWidth = area.Rectangle.Width;
            long fontheight = area.Font.Height;
            Font font = area.Font; //GetFontBySize(area.Font.Height,area); 

            Boolean Nop = true;
            do
            {
                Nop = false;
                foreach (String str in Result)
                {
                    SizeF textSize = g.MeasureString(str, font);
                    if (textSize.Width > MaxWidth)
                    {
                        Nop = true;
                        break;
                    }
                }

                if (Nop)
                {
                    if (area.ResultLines == area.MaxLines)
                        font = GetFontBySize((int)fontheight--,area); 
                    else
                        break;
                }
            } while (Nop);
            area.Font = font;
            return !Nop;

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
      

        public void Test()
        {
            //this.PrinterSettings.PrinterName = "Brother HL-5250DN"; 
           // this.PrinterSettings.PrinterName = "RICOH HQ9000 RPCS";
           // this.PrinterSettings.PrinterName = "Send To OneNote 2007";


            Area Area1 = new Area();

            Area1 = new Area();
            Area1.Text = "CustomerID";
            Area1.MaxLines = 1;
            Area1.Justify = LineJustify.Center;
            Area1.Rectangle = new RectangleF(0, 0, 0, 50);
            this.Areas.Add(Area1);


            Area1 = new Area();
            Area1.Rectangle = new RectangleF(0,50, 0, 500);
            //Area1.Text = "ARMINTA ELEMENTARY TRACKS B & D";
            //Area1.Text = "PACO";
            //Area1.Text = "THIS NAME IS TOO BIG WELL";
            Area1.Text = "ALVARO";

            //Area1.Font = new Font("Tahoma", 1);
            //Area1.Font = new Font("Agency FB", 20, FontStyle.Regular);
            Area1.Font = new Font("Bernard MT Condensed", 1);
            //Area1.Font = new Font("Franklin Gothic Medium Cond", 1);
            //Area1.Font = new Font("Times New Roman", 1);
            //Area1.Font = new Font("Stencil", 1);
            //Area1.Font = new Font("Arial Narrow", 1);
            this.Areas.Add(Area1);

            Area1 = new Area();
            Area1.Text = "Otra Linea";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 550, 0, 50);
            this.Areas.Add(Area1);
            
            Area1 = new Area();
            Area1.Text = "Otra Linea";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 600, 0, 50);
            this.Areas.Add(Area1);
            
            Area1 = new Area();
            Area1.Text = "Otra Linea";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 650, 0, 50);
            this.Areas.Add(Area1);
            
            Area1 = new Area();
            Area1.Text = "LIFT GATE & INSIDE DELIVERY. ALL ACCESSORIAL CHARGES TO PREPAID BY SHIPPER.";
            Area1.MaxLines = 2;
            Area1.Rectangle = new RectangleF(0, 700, 0, 80);
            this.Areas.Add(Area1);

            Area1 = new Area();
            Area1.Text = "Otra Linea mas";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 780, 0, 110);
            this.Areas.Add(Area1);

            Area1 = new Area();
            Area1.Text = "Otra Linea mas";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 890, 0, 110);
            this.Areas.Add(Area1);

            Area1 = new Area();
            Area1.Text = "Otra Line";
            Area1.MaxLines = 1;
            Area1.Rectangle = new RectangleF(0, 1010, 0, 50);
            Area1.Justify = LineJustify.Center;
            this.Areas.Add(Area1);

            this.Print();


        }

    }

}
