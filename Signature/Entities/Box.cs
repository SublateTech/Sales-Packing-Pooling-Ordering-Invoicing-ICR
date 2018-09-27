using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Signature.Data;
using Signature.Forms;
using System.Collections;



namespace Signature.Classes
{
    public class Box:Product
    {
        // Properties
        public new String ID;
        public new Double Length;
        public new Double Width;
        public new Double Height;
        private DataView  dvBoxes;
        
        //For normal product
        private Double MaxLength;
        private Double MaxWidth;
        private Double MaxHeight;
        private Double _TotalCube;

        public String ProductID;
        public Boolean IsCookieDough;

        public _Boxes Boxes =  new _Boxes(); 

        
        //Methods

        public Box(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
        } //Constructor

        public new bool Find(String BoxID)
        {
            this.ID = "";
            
            if (BoxID == "")
                return false;

                        
            
            DataRow rRow = oMySql.GetDataRow("Select * From BoxSize Where BoxID='" + BoxID + "' And CompanyID='"+CompanyID+"'", "Boxes");

            // DataRow rRow = oMySql.GetDataRow("Select * From BoxSize Where BoxID='" + BoxID + "'", "Boxes");

         
            if (rRow == null)
            {
                return false;
            }

            this.ID = (String)rRow["BoxID"];
            this.Length = (Double)rRow["Length"];
            this.Width = (Double)rRow["Width"];
            this.Height = (Double)rRow["Height"];
            this.ProductID = rRow["ProductID"].ToString();
            this.IsCookieDough = (Boolean)rRow["IsCookieDough"];
            
            return true;
        
        }
        public new bool View()
        {
            frmBoxsView oView = new frmBoxsView(CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
        public new void Save()
        {
            if (IfExist())
                Update();
            else
                Insert();
        }
        public new void Update()
        {
            String Sql = String.Format("Update BoxSize Set CompanyID='{0}', BoxID=\"{1}\", Length=\"{2}\", Width='{3}', Height=\"{4}\",ProductID='{5}',IsCookieDough='{6}' Where BoxID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'",
                this.CompanyID, this.ID, this.Length.ToString(), this.Width.ToString(), this.Height.ToString(),this.ProductID,this.IsCookieDough?"1":"0");
            oMySql.exec_sql(Sql);
        }
        public new void Insert()
        {
            String Sql = String.Format("Insert into BoxSize (CompanyID, BoxID, Length, Width, Height,ProductID,IsCookieDough)  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}')",
                this.CompanyID, this.ID, this.Length.ToString(), this.Width.ToString(), this.Height.ToString(),this.ProductID,this.IsCookieDough?"1":"0");
            oMySql.exec_sql(Sql);
        }
        public new bool IfExist()
        {
            if ((oMySql.exec_sql_no("Select count(*) from BoxSize Where BoxID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = "Delete From BoxSize Where BoxID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'";
            oMySql.exec_sql(Sql);
        }

        public  Double GetCube()
        {
            return this.Length * this.Width * this.Height;
        }
        public  String GetBoxes()
        {
            int NumBoxes = 0;
            String StrBoxes = null;
            Box oBox = new Box(CompanyID);

            String LargestBox = null;

            LargestBox = GetLargestBox();
            
            String curBox = null;
            while (_TotalCube > 0 && LargestBox != null)
            {
                curBox = LookForBox(NumBoxes);

                if (curBox == null)
                {
                    curBox = LargestBox;

                }
                    
                StrBoxes += ":" + curBox;
                if (!oBox.Find(curBox))
                    MessageBox.Show("Box not found :" + curBox);

                if (!Boxes.Contains(oBox.ID))
                {
                    BoxAssigned _Box = new BoxAssigned();
                    _Box.Quantity = 1;
                    _Box.ProductID = oBox.ProductID;
                    _Box.BoxID = oBox.ID;
                    Boxes.Add(oBox.ID, _Box);
                }
                else
                {
                    Boxes[oBox.ID].Quantity++;
                }

                NumBoxes++;
                _TotalCube -= oBox.GetCube();

            }

            
            return (StrBoxes==null)?"":StrBoxes.Substring(1).Replace("0","");
        }
        private String LookForBox(int NumBoxes)
        {
            LoadBoxes("DESC");
            foreach (DataRowView rBox in dvBoxes)
            {
           //     if (_TotalCube < (Double)rBox["Height"] && MaxLength < (Double)rBox["Length"] && MaxWidth < (Double)rBox["Width"] && MaxHeight < (Double)rBox["Height"])
           //         return rBox["BoxID"].ToString();
                if (NumBoxes == 0)
                {
                    if (_TotalCube < (Double)rBox["Length"] * (Double)rBox["Width"] * (Double)rBox["Height"] && MaxLength < (Double)rBox["Length"] && MaxWidth < (Double)rBox["Width"] && MaxHeight < (Double)rBox["Height"])
                            return rBox["BoxID"].ToString();
                }
                else
                {
                    if (_TotalCube < (Double)rBox["Length"] * (Double)rBox["Width"] * (Double)rBox["Height"] )
                            return rBox["BoxID"].ToString();
                }

            }
            return null;
        }
        private String GetLargestBox()
        {
            LoadBoxes("ASC");
            String LargestBox = null;
            Double HeightestBox = 0;
            foreach (DataRowView rBox in dvBoxes)
            {
                if ((Double)rBox["Height"] > HeightestBox)
                {
                    LargestBox = rBox["BoxID"].ToString();
                    HeightestBox = (Double)rBox["Height"];
                }

            }
            return LargestBox;
        }
        private void   LoadBoxes(String SqlOrder)
        {
                dvBoxes = oMySql.GetDataView("SELECT * FROM BoxSize Where CompanyID='"+CompanyID+"' And IsCookieDough = '0' order by BoxID " + SqlOrder, "Boxes");
        }
        
        public void AddCube(Customer oCustomer, Product oProduct, int Quantity)
        {
            //if (oProduct.IsCookieDoughBrochure(oCustomer))
            //    Global.ShowNotifier("Its a Cookie Dough Product");
            
            MaxWidth = Math.Max(oProduct.Width, MaxWidth);
            MaxLength = Math.Max(oProduct.Length, MaxLength);
            MaxHeight = Math.Max(oProduct.Height, MaxHeight);
            
            _TotalCube += 1.3 * oProduct.Length * oProduct.Width * oProduct.Height * Quantity;


        }
        public new void Clear()
        {
            _TotalCube  = 0;
            MaxLength   = 0;
            MaxWidth    = 0;
            MaxHeight   = 0;
            Boxes.Clear();
        }

       
        public class _Boxes : Hashlist
        {
            public _Boxes():base()
            {
            }

            public void Load()
            {
            }
            
            /* Hash List Support */
            public new BoxAssigned this[string Key]
            {
                get { return (BoxAssigned)base[Key]; }

            }
            public new BoxAssigned this[int index]
            {
                get
                {
                    object oTemp = base[index];
                    return (BoxAssigned)oTemp;
                }
            }

            // Expose the enumerator for the associative array.
            new public IEnumerator GetEnumerator()
            {
                return new _BoxesEnumerator(this);
            }

        }
        public class _BoxesEnumerator : IEnumerator
        {
            public _BoxesEnumerator(_Boxes ar)
            {
                _ar = ar;
                _currIndex = -1;
            }
            public object Current
            {
                get
                {
                    return _ar.m_oValues[_ar.m_oKeys[_currIndex]];

                }
            }
            public bool MoveNext()
            {
                _currIndex++;
                if (_currIndex == _ar.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                _currIndex = -1;
            }

            // The index of the item this enumerator applies to.
            protected int _currIndex;
            // A reference to this enumerator's associative array.
            protected _Boxes _ar;


        }
        public class BoxAssigned
        {
            public String ProductID;
            public Int32 Quantity;
            public String BoxID;
        }

    }
}
