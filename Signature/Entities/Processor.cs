using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Signature.Forms;
using Signature.Data;
using Signature.Zonal;
using System.Data;


using PegasusImaging.WinForms.FormFix3;
using PegasusImaging.WinForms.ImagXpress9;
using PegasusImaging.WinForms.NotateXpress9;
using PegasusImaging.WinForms.SmartZone2;
using PegasusImaging.WinForms.ScanFix5;


namespace Signature.Classes
{
    
    public class ZonalSignature : ZonalProcessor
    {
        public Order    oOrder;
        public String   CompanyID;
        public String   CustomerID;
        public String   Teacher;
        public Boolean  IsProcessAll            = false;

        public ScannedCustomer  oCustomer;
        public ScannedTeacher   oTeacher;
        public ScannedImage     oImage          = new ScannedImage();
        public ScannedImages    oImages         = new ScannedImages();
        
        public ZonalSignature(String CompanyID)
        {
            oTeacher = new ScannedTeacher(CompanyID,CustomerID);
            oOrder = new Order(CompanyID);
            oOrder.CustomerID = CustomerID;
            oOrder.Teacher = Teacher;

            oImage.CompanyID = CompanyID;
            
            this.CompanyID = CompanyID;
            

            this.TemplateFile = @"I:\Templates\Order_Template.tif"; //Application.StartupPath + "\\Templates\\ICRTemplate1.tif";
            this.AddFields();
        }

        public void AddFields()
        {
            int Top;
            int Height;
            int Left;
            int Width;


            #region Header Fields
            this.Fields.Add("LastName", 100, 435, 1600, 142, CharacterSet.AllAlphas, 35);
            this.Fields.Add("FirstName", 1753, 435, 1400, 142, CharacterSet.AllAlphas, 35);
            this.Fields.Add("DayPhone", 3244, 435, 1100, 142, CharacterSet.Digits, 10);

            this.Fields.Add("ParentAddress", 100, 615, 1950, 142, CharacterSet.AlphaNumeric, 30);
            this.Fields.Add("City", 2145, 615, 1200, 142, CharacterSet.AllAlphas, 14);
            this.Fields.Add("State", 3500, 615, 250, 142, CharacterSet.AllAlphas, 2);
            this.Fields.Add("ZipCode", 3795, 615, 550, 142, CharacterSet.Digits, 5);

            this.Fields.Add("Teacher", 100, 795, 1950, 142, CharacterSet.AllAlphas, 20);
            this.Fields.Add("SchoolName", 2340, 795, 2005, 142, CharacterSet.AllAlphas, 32);

            this.Fields.Add("SchoolUse", 2468, 3165, 380, 142, CharacterSet.Digits, 6);
            this.Fields.Add("SUDecimal", 2870, 3165, 231, 142, CharacterSet.Digits, 4);
            #endregion

            #region Detail Fields


            // Codes Fields
            Int16 GenTop = 980;

            Top = GenTop;
            Height = 135 + 1;
            Left = 875;
            Width = 420;

            for (int i = 1; i <= 30; i++)
            {
                if (i == 16)
                {
                    Left += 1570;
                    Top = GenTop;
                }

                this.Fields.Add("Code" + i.ToString(), Left, Top, Width, Height, CharacterSet.Digits, 4);
                Top = Top + Height;
            }


            // Quantities Codes Fields

            Top = GenTop;
            Height = 135 + 1;
            Left = 875 + 420 + 2;
            Width = 190;

            for (int i = 1; i <= 30; i++)
            {
                if (i == 16)
                {
                    Left += 1570;
                    Top = GenTop;
                }

                this.Fields.Add("Quantity" + i.ToString(), Left, Top, Width, Height, CharacterSet.Digits, 4);
                Top = Top + Height;

            }

            #endregion
        }
        
        public  Boolean CreateOrder()
        {
            Boolean ProcessOk = true;
         

            //Saving Order to SQL Server
            oOrder.Clear();

            oOrder.CompanyID    = CompanyID;
            oOrder.CustomerID   = CustomerID;
            
            oOrder.Teacher      = Teacher;
            oOrder.Type         = OrderType.Scanned;

            
            
            SpellWord oWord = new SpellWord();
            if (!oWord.GetResult(this.Fields["FirstName"]))
            {
                this.DrawRectangle(this.Fields["FirstName"]);
                ProcessOk = false;
            }
            String FirstName = oWord.Result;
                
            if (!oWord.GetResult(this.Fields["LastName"]))
            {
                this.DrawRectangle(this.Fields["LastName"]);
                ProcessOk = false;
            }
            String LastName = oWord.Result;

         //   MessageBox.Show(oOrder.Student);
            oOrder.Student      = LastName + ", " + FirstName;

            if (oOrder.Find(oOrder.Teacher, oOrder.Student))
            {
                return false;
            }

            String Digit = this.Fields["SchoolUse"].Result.Trim();
            String nDecimal = this.Fields["SUDecimal"].Result.Trim();

            if (Digit == "8")
                Digit = "00";
            if (nDecimal == "")
                nDecimal = "00";

            oOrder.Collected = Convert.ToDouble(Digit.Replace(" ","") + "." + nDecimal.Replace(" ",""));
            oOrder.oCustomer.Find(CustomerID);
            

            Application.DoEvents();

            String Code, Quantity;

            
            for (int i = 1; i <= 30; i++)
            {
                Code = this.Fields["Code" + i.ToString()].Result;
                Quantity = this.Fields["Quantity" + i.ToString()].Result;

                Code = Code.Trim();
                Quantity = Quantity.Trim();
                //oOrder.oProduct.CompanyID = _CompanyID;


                Boolean bFound = false;
                if (Code != "" && Code.Length >= 3)
                {
                    
                    if (!oOrder.oProduct.Find(Code))
                    {
                        if (!oOrder.oProduct.Find(Code))
                        {
                            SpellWord oCode = new SpellWord();
                            ArrayList oCodes = oCode.getChars(this.Fields["Code" + i.ToString()]);
                            foreach (String sCode in oCodes)
                            {
                                if (oOrder.oProduct.Find(sCode))
                                {
                                    //MessageBox.Show(sCode);
                                    Code = sCode;
                                    bFound = true;
                                    break;
                                }
                            }
                            if (!bFound)
                            {
                             //   MessageBox.Show("Not Found!:" + Field.Result);
                                //this.Fields["Code" + i.ToString()].DrawRectangle(Color.Red);
                                this.DrawRectangle(this.Fields["Code" + i.ToString()]);
                                ProcessOk = false;
                                continue;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Ok:" + Field.Result);
                        }
                        
                    }
                    if (Quantity == "")
                    {
                        //this.Fields["Quantity" + i.ToString()].DrawRectangle(Color.Red);
                        this.DrawRectangle(this.Fields["Quantity" + i.ToString()]);
                        Quantity = "1";
                    }

                    Order.Item Item     = new Order.Item();
                    Item.ProductID      = oOrder.oProduct.ID;
                    Item.Quantity       = Convert.ToInt32(Quantity.Trim().Replace(" ", ""));
                    Item.Description    = oOrder.oProduct.Description;
                    Item.Price          = oOrder.oProduct.ExtendedPrice(oOrder.oCustomer);

                    if (oOrder.Items.Contains(oOrder.oProduct.ID))
                        oOrder.Items[oOrder.oProduct.ID].Quantity += Item.Quantity;
                    else
                        oOrder.Items.Add(oOrder.oProduct.ID, Item);

                }

            }
            oOrder.GetTotals();
            /*
            if (Math.Abs(oOrder.Diff) > 0)
            {
                this.Fields["SchoolUse"].DrawRectangle(Color.Red);
                this.Fields["SUDecimal"].DrawRectangle(Color.Red);
                ProcessOk = false;
                
            }
            */
            return ProcessOk;
        }

        public void LoadImageFiles(String Teacher)
        {
            oImages.CompanyID = CompanyID;
            oImages.CustomerID = CustomerID;
            oImages.Teacher = Teacher;
            oImages.Load(ScannedOrderStatus.JustScanned);

        }

        public bool Run()
        {
            if (oImages.Index != -1)
            {
                ScannedImage oImage = oImages[oImages.Index];
                return this.ProcessImage(oImage.FilePath);
                
            }
            return true;
        }

        public bool ProcessOrder(ScannedImage oImage)
        {
            if (oImage.Status == ScannedOrderStatus.JustScanned)
            {
                if (!this.ProcessImage(oImage.FilePath))
                {
                    /*oImage.OrderID = 0;
                    oImage.Message = this.ErrorMsg;
                    oImage.Status = ScannedOrderStatus.NoProcessedWithErrors;
                    oImage.UpdateStatus();*/
                    return false;
                }
                if (!this.CreateOrder())
                {
                    if (!IsProcessAll)
                    {
                        frmOrder ofrmOrder = new frmOrder(oOrder);
                        ofrmOrder._OrderProcess = OrderProcess.ScanFixing;
                        ofrmOrder.ShowDialog();
                        if (ofrmOrder.IsSaved)
                        {
                            oImage.OrderID = Convert.ToInt32(ofrmOrder.oOrder.ID);
                            oImage.Message = "Saved and Corrected";
                            oImage.Status = ScannedOrderStatus.ProcessedAndCorrected;
                            oImage.UpdateStatus();
                        }
                        ofrmOrder.Dispose();
                    }
                    else
                    {
                        oOrder.Save();
                        oImage.OrderID = Convert.ToInt32(oOrder.ID);
                        oImage.Message = "Processed With Errors";
                        oImage.Status = ScannedOrderStatus.ProcessedWithErrors;
                        oImage.UpdateStatus();


                       
                        PegasusImaging.WinForms.ImagXpress9.SaveOptions so = new PegasusImaging.WinForms.ImagXpress9.SaveOptions();
                        so.Format = PegasusImaging.WinForms.ImagXpress9.ImageXFormat.Jpeg;
                        //so.Tiff.Compression = PegasusImaging.WinForms.ImagXpress9.Compression.Group4;

                        oImage.FileType = "JPEG";
                        OutputImg.Image.Save(oImage.FilePath, so);

                    }


                }
                else
                {
                    oOrder.Save();
                    oImage.OrderID = Convert.ToInt32(oOrder.ID);
                    oImage.Message = "Processed And OK";
                    oImage.Status = ScannedOrderStatus.ProcessedOk;
                    oImage.UpdateStatus();

                }

            }
            else
            {
                return false;
            }
            return true; 
        }

        public bool NextImage()
        {
            if (oImages.Next())
            {
                if (!Run())
                    this.NextImage();
                return true;
            }
            else
                return false;
        }
        public bool BackImage()
        {
            if (oImages.Back())
            {
                Run();
                return true;
            }
            else
                return false;

        }

        public void AllPendingCustomers()
        {
            DataTable dt = oImages.LoadAllCustomers(CompanyID);
            foreach (DataRow row in dt.Rows)
            {
                this.CustomerID = row["CustomerID"].ToString();
                this.Teacher = row["Teacher"].ToString();
                MessageBox.Show(CustomerID + " - " + Teacher);
             //   RunAllCustomer();
            }
        }
    }
    public enum ScannedOrderStatus
    {
        JustScanned = 0,
        ProcessedOk = 1,
        ProcessedWithErrors = 2,
        ProcessedAndCorrected = 3,
        NoProcessedWithErrors = 4
    }
   
}
