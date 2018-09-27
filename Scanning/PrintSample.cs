using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

//Need Printing namespace
using System.Drawing.Printing;


namespace Signature
{

    public class PrintSample
    {

        public void RunSample()
        {
            Console.WriteLine("Printing to the default printer...");
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
                pd.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error printing -- " + ex.ToString());
            }

            //Read input - to delay the closing of the DOS shell
            Console.ReadLine();
        }

        //Event fired for each page to print
        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            string strHello = "Hello Printer!";
            Font oFont = new Font("Arial", 10);
            Rectangle marginRect = ev.MarginBounds;

            ev.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Black), marginRect);
            ev.Graphics.DrawString(strHello, oFont, new SolidBrush(System.Drawing.Color.Blue),
                (ev.PageBounds.Right / 2), ev.PageBounds.Bottom / 2);
        }
    }
}