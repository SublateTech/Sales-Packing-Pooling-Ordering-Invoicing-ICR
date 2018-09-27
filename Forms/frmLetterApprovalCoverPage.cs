using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;

namespace Signature.Forms
{
    public partial class frmLetterApprovalCoverPage : Form
    {
        public frmLetterApprovalCoverPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LoadWordDocument("D:\\Signature.com\\SigData\\PACSheet.Doc");
            ParseWordDocument oDoc = new ParseWordDocument();
            oDoc.Open("ABC.dot");

            oDoc.AddRange(      new String[,] { { "CODE", "1234" }, 
                                { "REP", "KIRK LINAHAN" }, 
                                { "SCHOOL", "MI CASAS ES TU CASA" }, 
                                { "CHAIRPERSON", "JUSTIN COPELAND" }, 
                                { "FAX", "(661) 9461674" }, 
                                { "SCHOOLNAME", "LA LOMITA ELEM" },
                                { "EMAIL","ALVARO@SIGFUND.COM"},
                                { "ENDDATE","END DATE"},
                                { "STARTDATE","START DATE"}
                                });
            oDoc.Parse();
            oDoc.Print();
            oDoc.SaveAs("tmp0001.doc");
            oDoc.Close();
            
        }

       
     /*   private void Print(_Document wordDoc, string printerName)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = printerName;
            pd.DocumentName = "...Wints' Test Print...";
            PaperSource tray1 = null;

            foreach (PaperSource source in pd.PrinterSettings.PaperSources)
            {
                if (source.SourceName.Trim().Equals("Tray 1"))
                {
                    tray1 = source;
                    break;
                }
            }

            if (tray1 == null)
                return;

            int rawKind = Convert.ToInt32(tray1.GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(tray1));
            wordDoc.PageSetup.FirstPageTray = (WdPaperTray)rawKind;
            _wrdApp.ActivePrinter = printerName;
            _wrdApp.Visible = false;
            _wrdApp.PrintOut(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

        }
 
        */

    }


   
}