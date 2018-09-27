using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Signature.Data;
using System.Data;


namespace Signature.Classes
{
    class Image
    {
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open,
                                                    FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to 

            //supply number of bytes to read from file.
            //In this case we want to read entire file. 

            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        public byte[] getImage(Object _Column  )
        {   
            try
            {
                byte[] buffer = (byte[]) _Column;
                return buffer;
            }
            catch { return null; }
            finally { }
        }

        public Bitmap getImage()
        {
            byte[] buffer = getImage("");
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream(buffer, true);
            stream1.Write(buffer, 0, buffer.Length);
            Bitmap m_bitmap = (Bitmap)Bitmap.FromStream(stream1);
            return m_bitmap;
        }


        private void OpenFileDialog()
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();

            OpenDlg.Filter =
        "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
        "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            OpenDlg.Multiselect = true;
            OpenDlg.Title = "My Image Browser";
            DialogResult dr = OpenDlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Read the files
                foreach (String file in OpenDlg.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        byte[] imagedata = ReadFile(file);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("" + Ex);

                    }


                }
            }

        }

    }
}
