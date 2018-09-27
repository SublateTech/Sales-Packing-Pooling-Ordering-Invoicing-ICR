using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Forms;


namespace Signature.Classes
{
    public class ParseWordDocument
    {
        private ApplicationClass myWordApp = new ApplicationClass();  // our application
        private Document myWordDoc = new Document();          // our document
        private String[,] _Fields;
      //  private String FileName = "";
      //  private String TemplateFile = "";
        private object missing = System.Reflection.Missing.Value; // our 'void' value
        private object notTrue = false;  // our boolean false
        private object filename;
        public object destination;
        public Int32 nFields = 0;


        public Boolean Open(String TemplateFile)
        {
            object isVisible = false;
            object Readonly = false;
            filename = System.Windows.Forms.Application.StartupPath + "\\" + TemplateFile; // @"D:\Signature.com\SigData\ABC.dot"; // our word template

            //MessageBox.Show(filename.ToString());
            //
            // now we want to load the template and check how many fields there are to replace
            //

            myWordApp.Visible = false;  // tell word not to show itself

            if (!File.Exists(filename.ToString()))
            {
                MessageBox.Show("Doc doesn't exist " + filename.ToString());
                return false;
            }
            /*
            myWordDoc = myWordApp.Documents.Open(ref filename, ref missing, ref Readonly,
                                                   ref missing, ref missing, ref missing,
                                                     ref missing, ref missing, ref missing,
                                                     ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
            
            */
            myWordDoc = myWordApp.Documents.Add( // load the template into a document workspace
                                    ref filename,  // and reference it through our myWordDoc
                                    ref missing,
                                    ref missing,
                                    ref missing);


            myWordDoc.Activate();

            
            // count how many fields we have to update

            return true;
            
        }
        public void Parse()
        {
            //Parse
            int fields = myWordDoc.Fields.Count;

            //
            // now we can simply iterate through the fields collection and update
            //

            foreach (Field myField in myWordDoc.Fields)
            {
                myField.Select();
                myWordApp.Selection.TypeText(GetValue(myWordApp.Selection.Text.Replace("«", "").Replace("»", "").ToUpper()));
            }
            
        }
        public void SetField(String Field , String Text )
        {
            foreach (Field myField in myWordDoc.Fields)
            {
                if (myField.Code.Text.Contains(Field))
                {
                    myField.Select();
                    myWordApp.Selection.TypeText(Text);
                    return;
                }
            }
        }
        public void Clear()
        {
            foreach (Field myField in myWordDoc.Fields)
            {
                
                    myField.Select();
                    myWordApp.Selection.TypeText(" ");
                    
                
            }
        }
        public void AddRange(String[,] Fields)
        {
            _Fields = Fields;
        }
        private String GetValue(String Field)
        {
            for (int i = 0; i < _Fields.Length / 2; i++)
            {
                if (_Fields[i, 0] == Field)
                    return _Fields[i, 1];

            }
            return "";
        }
        public void Close()
        {
            myWordDoc.Close(ref missing, ref missing, ref missing);
            // quit word
            myWordApp.Application.Quit(
                     ref notTrue,
                     ref missing,
                     ref missing);
            
       //     Object False = false;
       //     myWordApp.Documents.Close(ref False, ref missing, ref missing);
            
        }
        public void Save()
        {
            SaveAs(GetValue("CODE") + ".DOC");
        }
        public void SaveAs(String FileName)
        {
            
            
            destination = System.Windows.Forms.Application.StartupPath + "\\" + FileName; //@"D:\Signature.com\SigData\PACSheet100.doc";  // our target filename

            if (File.Exists(destination.ToString()))
                File.Delete(destination.ToString());
            //
            // now the last touch.. save and close
            //
            myWordDoc.SaveAs(
                     ref destination,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing,
                     ref missing);

        }
        public void Print()
        {
            myWordDoc.PrintOut(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                 ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

        }
    }

}
