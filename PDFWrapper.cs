using System;
using System.Collections;
using System.ComponentModel;


using System.Web;
using System.Web.SessionState;

using System.Text;

using System.Data;
using System.Data.OracleClient;


using CrystalDecisions.Shared;
using CrystalDecisions.Web.Services.Enterprise;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;


using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Signature.Classes
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class PDF
    {
        public PDF()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Export report to file
        /// </summary>
        /// <param name="crReportDocument">ReportDocument</param>
        /// <param name="ExpType">Export Type (pdf, xls, doc, rpt, htm)</param>
        /// <param name="ExportPath">Export Path (physical path on the disk were exported document will be stored on)</param>
        /// <param name="filename">File name (file name without extension f.e. "MyReport1")</param>
        /// <returns>returns true if export was succesfull</returns>
        public static bool ExportReport(ReportDocument crReportDocument, string ExpType, string ExportPath, string filename)
        {
            //creating full report file name for example if the filename was "MyReport1"
            //and ExpType was "pdf", full file name will be "MyReport1.pdf"
            filename = filename + "." + ExpType;

            //creating storage directory if not exists
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);

            //creating new instance representing disk file destination options such as filename, export type etc.
            DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            ExportOptions crExportOptions = crReportDocument.ExportOptions;


            switch (ExpType)
            {
                case "rtf":
                    {
                        //setting disk file name 
                        crDiskFileDestinationOptions.DiskFileName = ExportPath + filename;
                        //setting destination type in our case disk file
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        //setuing export format type
                        crExportOptions.ExportFormatType = ExportFormatType.RichText;
                        //setting previously defined destination opions to our input report document
                        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                        break;
                    }
                //NOTE following code is similar to previous, so I want comment it again
                case "pdf":
                    {
                        crDiskFileDestinationOptions.DiskFileName = ExportPath + filename;
                        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;
                    }
                case "doc":
                    {
                        crDiskFileDestinationOptions.DiskFileName = ExportPath + filename;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
                        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                        break;
                    }
                case "xls":
                    {
                        crDiskFileDestinationOptions.DiskFileName = ExportPath + filename;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.Excel;
                        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                        break;
                    }
                case "rpt":
                    {
                        crDiskFileDestinationOptions.DiskFileName = ExportPath + filename;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.CrystalReport;
                        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                        break;
                    }
                case "htm":
                    {
                        HTMLFormatOptions HTML40Formatopts = new HTMLFormatOptions();
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.HTML40;
                        HTML40Formatopts.HTMLBaseFolderName = ExportPath + filename;
                        HTML40Formatopts.HTMLFileName = "HTML40.html";
                        HTML40Formatopts.HTMLEnableSeparatedPages = true;
                        HTML40Formatopts.HTMLHasPageNavigator = true;
                        HTML40Formatopts.FirstPageNumber = 1;
                        HTML40Formatopts.LastPageNumber = 3;
                        crExportOptions.FormatOptions = HTML40Formatopts;
                        break;
                    }

            }
            try
            {
                //trying to export input report document, and if success returns true
                crReportDocument.Export();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Export report to byte array
        /// </summary>
        /// <param name="crReportDocument">ReportDocument</param>
        /// <param name="exptype">CrystalDecisions.Shared.ExportFormatType</param>
        /// <returns>byte array representing current report</returns>
        public static byte[] ExportReportToStream(ReportDocument crReportDocument, ExportFormatType exptype)
        {//this code exports input report document into stream, and returns array of bytes

            Stream st;
            st = crReportDocument.ExportToStream(exptype);

            byte[] arr = new byte[st.Length];
            st.Read(arr, 0, (int)st.Length);

            return arr;

        }

        /// <summary>
        /// Export report to string
        /// </summary>
        /// <param name="crReportDocument">ReportDocument</param>
        /// <returns>byte unicode string representing current report</returns>
        public static string ExportReportToString(ReportDocument crReportDocument)
        {
            Stream st;
            st = crReportDocument.ExportToStream(ExportFormatType.PortableDocFormat);

            byte[] arr = new byte[st.Length];
            st.Read(arr, 0, (int)st.Length);

            string rep = new UnicodeEncoding().GetString(arr);

            return rep;
        }

    }
}
