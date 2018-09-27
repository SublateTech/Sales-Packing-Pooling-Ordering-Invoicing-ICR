using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Signature.Communications;
using Signature.Data;
using System.Data;
using Signature.Classes;


namespace Signature.Classes
{
    public class Dictionary
    {
        private String FileName;
        private FileInfo t;
        private StreamWriter tw;

        public Dictionary()
        {   
        }
        public void Open(String _FileName)
        {
            this.FileName = _FileName;
            
            t = new FileInfo(FileName);
            tw = t.CreateText();
            

        }
        public void Close()
        {
            tw.Close();
        }
       
        public void AddLine(String Line)
        {
            tw.WriteLine(Line);
        }

        public void Generate(String FileName, String TableName)
        {
            Open(FileName);
            AddLine("[Copyright]");
            AddLine("Signature Fundraising, Inc.");
            AddLine("");

            AddLine("[Try]");
            AddLine("esianrtolcdugmphbyfvkwESIANRTOLCDUGMPHBYFVKW");
            AddLine("");

            AddLine("[Replace]");
            AddLine("D O");
            AddLine("O D");
            AddLine("I J");
            AddLine("J I");
            AddLine("K X");
            AddLine("X K");
            AddLine("U V");
            AddLine("V U");


            AddLine("");

            AddLine("[Words]");

            DataView dv = Global.oMySql.GetDataView(String.Format("Select Name From {0} Where Status='1' Order By Name",TableName), "Tmp");
            foreach (DataRow row in dv.Table.Rows)
            {
                AddLine(row["Name"].ToString());
            }
            AddLine("");
            Close();
        }


    }
}
