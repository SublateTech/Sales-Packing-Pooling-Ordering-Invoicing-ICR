using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Data;
using Signature.Forms;


namespace Signature.Classes
{
    public class ScannedCustomer:Customer
    {
        public String CustomerID;
        public ScannedTeachers Teachers;

        public ScannedCustomer(String CompanyID):base(CompanyID)
        {   
            Teachers = new ScannedTeachers(CompanyID, CustomerID);
        }
        public new bool View()
        {
            frmViewScannedCustomers oView = new frmViewScannedCustomers(CompanyID);
            oView.ShowDialog();
            if (oView.SelectedID != "")
            {
                CustomerID = oView.SelectedID;
                this.Find(CustomerID);
                return true;
            }
            return false;
        }
        public  bool Find(string CustomerID)
        {
            DataRow Row = oMySql.GetDataRow("Select * From OrderScanned Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "'", "Customer");

            if (Row == null)
            {
                this.ID = "";
                return false;
            }

            CustomerID = Row["CustomerID"].ToString();
            
            return base.Find(CustomerID);
        }
    }

    public class ScannedTeachers : Hashlist 
    {
        private Int32 _Index = -1;

        public new Int32 ID;
        public String CustomerID;
        public DataTable Table;

        public ScannedTeachers(String CompanyID):base(CompanyID)
        {
            CompanyID = String.Empty;
            CustomerID = String.Empty;
            
            
        }

        public ScannedTeachers(String CompanyID, String CustomerID):base(CompanyID)
            
        {
            this.CompanyID = CompanyID;
            CustomerID = String.Empty;
            
        }

        public new void Save()
        {
            //The DataView (dv) now contains only deleted rows
            DataView dv = new DataView(Table, null, null, DataViewRowState.Deleted);
            //The new DataTable (dt) now contains the original versions of the deleted     rows.
            DataTable dt = dv.ToTable();

            foreach (DataRow row in dt.Rows)
            {
                ScannedTeacher oTeacher = new ScannedTeacher(CompanyID, CustomerID);
                oTeacher.ID = (Int32)row["BatchID"];
                oTeacher.Name = row["Teacher"].ToString();
                oTeacher.Delete();
            }

            Table.AcceptChanges();
            foreach (DataRow row in Table.Rows)
            {
                ScannedTeacher oTeacher = new ScannedTeacher(CompanyID, CustomerID);
                oTeacher.ID = (Int32) row["BatchID"];
                oTeacher.Name = row["Teacher"].ToString();

                if (oTeacher.Name.Trim()!="")
                    oTeacher.Save();
            }

        }

        public bool Add(ScannedTeacher Teacher)
        {
            this.Add(Teacher.Name, Teacher);
            return true;
        }
       
        public DataTable LoadAllCustomers(String CompanyID)
        {
            DataTable table = oMySql.GetDataTable(String.Format("Select distinct(Teacher), CustomerID From OrderScanned Where CompanyID='{0}'  Group By Teacher Order By CustomerID,Teacher", CompanyID));
            if (table == null)
                return null;
            return table;
        }

        public void Load(String CustomerID)
        {
            this.CustomerID = CustomerID;
            this.Index = -1;
            this.Clear();
            Table = oMySql.GetDataTable(String.Format("Select BatchID, Teacher, Scanned, Corrected, Processed From OrderScanned Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, CustomerID));
            if (Table == null)
                return;

            foreach (DataRow row in Table.Rows)
            {
                ScannedTeacher _Teacher = new ScannedTeacher(CompanyID,CustomerID);

                _Teacher.CompanyID = CompanyID;
                _Teacher.CustomerID = CustomerID;
                _Teacher.Name = row["Teacher"].ToString();
                _Teacher.Scanned = (Boolean)row["Scanned"];
                _Teacher.Corrected = (Boolean)row["Corrected"];
                _Teacher.Processed = (Boolean)row["Processed"];
                this.Add(row["Teacher"].ToString(), _Teacher);
            }
        }

        public void AddEmpty()
        {
            DataRow Detail = Table.NewRow();
            Detail["BatchID"] = 0;
            Detail["Teacher"] = "";
            Table.Rows.Add(Detail);
        }

        public bool Next()
        {
            if (_Index == this.Count - 1)
                return false;

            _Index++;
            return true;
        }

        public bool Next(String Current)
        {
            for (int x = 0; x < this.Count - 1; x++ )
            {
                if (((ScannedTeacher)this[x]).Name == "Current")
                {
                    if (x + 1 <= this.Count - 1)
                    {
                        _Index = x;
                        return true;
                    }
                }
                else
                {
                    _Index = 0;
                    return false;
                }
            }
            return false;
        }

        public bool Back()
        {
            if (_Index == -1)
                return false;

            _Index--;
            return true;
        }

        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        public bool First()
        {
            _Index = 0;
            return true;
        }

        public bool Last()
        {
            _Index = this.Count;
            return true;
        }

        public ScannedTeacher GetNext()
        {
            this.Next();
            return (ScannedTeacher)this[_Index];
        }

        #region HasList Support
        public new ScannedTeacher this[string Key]
        {
            get { return (ScannedTeacher)base[Key]; }

        }
        public new ScannedTeacher this[int index]
        {
            get
            {
                object oTemp = base[index];
                return (ScannedTeacher)oTemp;
            }
        }
        new public IEnumerator GetEnumerator()
        {
            return new ScannedTeachersEnumerator(this);
        }
        #endregion

    }
    public class ScannedTeachersEnumerator : IEnumerator
    {
        public ScannedTeachersEnumerator(ScannedTeachers ar)
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
        protected ScannedTeachers _ar;


    }
    public class ScannedTeacher 
    {
        public String CompanyID;
        public String CustomerID;
        public Int32 ID;
        public String Name;
        public ScannedImages Images;
        public Boolean Scanned;
        public Boolean Corrected;
        public Boolean Processed;
        
        private SqlBuilder oBuild;

        public ScannedTeacher(String CompanyID)
        {
            Images = new ScannedImages(CompanyID);
            this.CompanyID = CompanyID;
            this.Scanned = false;
        }
        public ScannedTeacher(String CompanyID, String CustomerID)
        {
            Images = new ScannedImages(CompanyID);
            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;
            this.Scanned = false;
        }
        public bool View()
        {
            frmViewScannedTeachers oView = new frmViewScannedTeachers(CompanyID, CustomerID);
            oView.ShowDialog();
            if (oView.SelectedID != "")
            {
                this.Find(oView.SelectedID);
                return true;
            }
            return false;
        }
        public void Save()
        {
            FillFields();
            if (IfExist())
                Update();
            else
                Insert();
        }
        public void Update()
        {
            Global.oMySql.exec_sql(oBuild.Update("Where BatchID='" + this.ID + "'"));
        }
        public void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());
        }
        public bool IfExist()
        {
            if ((Global.oMySql.exec_sql_no("Select count(*) from OrderScanned Where BatchID='" + this.ID + "'")) == 0)
                return false;
            else
                return true;
        }
        private void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange("OrderScanned", new String[] { 
                "CompanyID", 
                "CustomerID",
                "Teacher"},
                new Object[] {this.CompanyID,
                 this.CustomerID, this.Name
                });
        }
        public void Delete()
        {
            String Sql = "Delete From OrderScanned Where BatchID='" + this.ID + "'";
            Global.oMySql.exec_sql(Sql);
        }
        public bool Find(String CompanyID, String CustomerID, String Teacher)
        {

            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;


            if (CompanyID == "" || CustomerID == "")
                return false;

            DataRow Row = Global.oMySql.GetDataRow("Select * From OrderScanned Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and Teacher='" + Teacher + "'", "scanned");

            if (Row == null)
            {       this.ID = 0;
                    return false;
            }

            ID = (int)Row["BatchID"];
            CompanyID = Row["CompanyID"].ToString();
            CustomerID = Row["CustomerID"].ToString();
            Name = Row["Teacher"].ToString();
            Scanned = (Boolean) Row["Scanned"];

            return true;

        }
        public bool Find(String Teacher)
        {
            return Find(CompanyID, CustomerID, Teacher);
        }
        public void UpdateStatus()
        {
            String Sql = String.Format("Update OrderScanned  Set Scanned='{0}', Date={1}  Where BatchID='" + ID + "'",
                Scanned?"1":"0",  "NOW()");
            Global.oMySql.exec_sql(Sql);
        }
        public void LoadImages(ScannedOrderStatus Status)
        {
            this.Images.Load(this.CompanyID, this.CustomerID, this.Name, Status);
        }
    }
    public class ScannedImages : Hashlist
    {
        
        public String CustomerID;
        public String Teacher;
        private Int32 _Index = -1;
        public Int32 NoImages;
        public new Int32 ID;
        public DataTable TeacherTable;

        public ScannedImages()
        {
            CompanyID = String.Empty;
            CustomerID = String.Empty;
            Teacher = String.Empty;
            NoImages = 0;
        }

        public ScannedImages(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            CustomerID = String.Empty;
            Teacher = String.Empty;
            NoImages = 0;
        }

        public bool View(String CustomerID)
        {
            //frmViewScannedImages oView = new frmViewScannedImages(CompanyID, CustomerID);
            /*
            frmViewTeacher oView = new frmViewTeacher(CompanyID, CustomerID, true);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            */
            return false;

        }

        public bool Find(String CompanyID, String CustomerID, String Teacher)
        {

            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;


            if (CompanyID == "" || CustomerID == "")
                return false;

            DataRow Row = oMySql.GetDataRow("Select * From OrderScannedDetail Where CompanyID='" + CompanyID + "' and CustomerID='" + CustomerID + "' and Teacher='" + Teacher + "'", "scanned");

            if (Row == null)
            {

                if (MessageBox.Show("Is this a new teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {

                    this.ID = 0;
                    return false;
                }
                else
                {
                    /*
                    String Sql = String.Format("Insert into scanned_images (CompanyID, CustomerID, Teacher) Values (\"{0}\",\"{1}\",\"{2}\")",
				            CompanyID,CustomerID,Teacher);
                    
                    _ID = oMySql.exec_sql_id(Sql);
                   */
                    return true;
                }

            }

            ID = (int)Row["ImageID"];
            CompanyID = Row["CompanyID"].ToString();
            CustomerID = Row["CustomerID"].ToString();
            Teacher = Row["Teacher"].ToString();
            NoImages = (Int32) Row["NoImages"];
            return true;

        }

        public void Load(ScannedOrderStatus Status)
        {
            Load(this.CompanyID, this.CustomerID, this.Teacher,Status);
        }
        
        public void Load(String CompanyID, String CustomerID, String Teacher, ScannedOrderStatus Status)
        {
            this.Clear();
            this.Index = -1;
            this.CompanyID = CompanyID;
            this.CustomerID = CustomerID;
            this.Teacher = Teacher;

            DataTable table;
            if (Teacher != "")
                table = oMySql.GetDataTable(String.Format("Select * From OrderScannedDetail Where CompanyID='{0}' And CustomerID='{1}' And Teacher=\"{2}\" And Status='{3}'", CompanyID, CustomerID, Teacher, (int)Status));
            else
                table = oMySql.GetDataTable(String.Format("Select * From OrderScannedDetail Where CompanyID='{0}' And CustomerID='{1}' And Status='{2}'", CompanyID, CustomerID, (int)Status));

            if (table == null)
                return;

            foreach (DataRow row in table.Rows)
            {
                ScannedImage _Image = new ScannedImage();
                _Image.CompanyID = CompanyID;
                _Image.CustomerID = CustomerID;
                _Image.Date = (DateTime)row["Date"];
                _Image.Teacher = row["Teacher"].ToString();
                _Image.ImagePath = row["ImagePath"].ToString();
                _Image.ID = (Int32) row["ImageID"];
                _Image.Status = Global.ToEnum<ScannedOrderStatus>((int)row["Status"]);
                _Image.OrderID = (Int32)row["OrderID"];

                this.Add(row["ImageID"].ToString(), _Image);
            }

        }

        public DataTable LoadAllCustomers(String CompanyID)
        {
            DataTable table = oMySql.GetDataTable(String.Format("Select distinct(Teacher), CustomerID From OrderScannedDetail Where CompanyID='{0}'  Group By Teacher Order By CustomerID,Teacher", CompanyID));
            if (table == null)
                return null;
            return table;
        }

        public bool Next()
        {
            if (_Index == this.Count-1)
                return false;
            
            _Index++;
            return true;
        }
        
        public bool Back()
        {
            if (_Index == -1)
                return false;

            _Index--;
            return true;
        }

        public int Index
        {
            get {return _Index;}
            set {_Index = value;}
        }

        public bool First()
        {
            _Index=0;
            return true;
        }

        public bool Last()
        {
            _Index = this.Count;
            return true;
        }

        #region HasList Support
        public new ScannedImage this[string Key]
        {
            get { return (ScannedImage)base[Key]; }

        }
        public new ScannedImage this[int index]
        {
            get
            {
                object oTemp = base[index];
                return (ScannedImage)oTemp;
            }
        }
        new public IEnumerator GetEnumerator()
        {
            return new ScannedImagesEnumerator(this);
        }
        #endregion

    }
    public class ScannedImagesEnumerator : IEnumerator
    {
        public ScannedImagesEnumerator(ScannedImages ar)
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
        protected ScannedImages _ar;


    }
    public class ScannedImage : Company
    {
        public new int ID;
        public String CustomerID;
        public DateTime Date;
        public String Teacher;
        public String ImagePath;
        public Int32 OrderID;
        public ScannedOrderStatus Status;
        public String Message;
        public Int32 BatchID;
        public String FileType = "TIFF";

        public String FilePath
        {
            get { return this.ImagePath + "Order-" + ID.ToString().PadLeft(10, '0') + "." + this.FileType; }
        }

        public ScannedImage()
        {
            ImagePath = "I:/Images/";
            BatchID = 0;
        }
        public new bool Find(String ImageID)
        {
            this.ID = 0;

            if (CompanyID == "" || CustomerID == "")
                return false;

            DataRow Row = this.oMySql.GetDataRow("Select * From OrderScannedDetail Where ImageID='" + ImageID + "'", "scanned");
            if (Row == null)
            {
                this.ID = 0;
                return false;
            }
            
            
            ID = (int) Row["ImageID"];
            CompanyID = Row["CompanyID"].ToString();
            CustomerID = Row["CustomerID"].ToString();
            Teacher = Row["Teacher"].ToString();
            ImagePath = Row["ImagePath"].ToString();
            Status = Global.ToEnum<ScannedOrderStatus>((int)Row["Status"]);
            OrderID = (Int32)Row["OrderID"];

            return true;

        }
        public  bool Find(Int32 OrderID)
        {
            this.ID = 0;
            if (CompanyID == "" || CustomerID == "")
                return false;

            DataRow Row = this.oMySql.GetDataRow("Select * From OrderScannedDetail Where OrderID='" + OrderID + "'", "scanned");
            if (Row == null)
            {
                this.ID = 0;
                return false;
            }
            ID = (int)Row["ImageID"];
            return this.Find(ID.ToString());
        }

        public new void Save()
        {
            if (Exist())
                Update();
            else
                Insert();
        }
        public override void Insert()
        {
            String Sql = String.Format("Insert into OrderScannedDetail (CompanyID, CustomerID, ImagePath, Date, Teacher,BatchID) Values ('{0}',\"{1}\",\"{2}\",{3},\"{4}\",\"{5}\")",
                CompanyID, CustomerID, this.ImagePath, "NOW()", Teacher, this.BatchID);
            this.ID = oMySql.exec_sql_id(Sql);
        }
        public override void Update()
        {
            String Sql = String.Format("Update OrderScannedDetail  Set CompanyID='{0}', CustomerID='{1}', ImagePath='{2}', Date={3}, Teacher='{4}', OrderID='{5}', Status='{6}' Where CompanyID='" + CompanyID + "' And CustomerID='" + CustomerID + "' And BatchID='" + ID + "'",
                    CompanyID, CustomerID, this.ImagePath,"NOW()", Teacher,OrderID,Status);
            oMySql.exec_sql(Sql);

        }

        public void UpdateStatus()
        {
            String Sql = String.Format("Update OrderScannedDetail  Set Status='{0}', Message=\"{1}\", Date={2}, OrderID='{3}' Where ImageID='" + ID +  "'",
                    (int)Status, this.Message,  "NOW()",OrderID);
            oMySql.exec_sql(Sql);
        }

        public bool Exist()
        {
            int i;
            if ((i = oMySql.exec_sql_no("Select count(*) from OrderScannedDetail Where CustomerID='" + CustomerID + "' And CompanyID='" + CompanyID + "' And BatchID='" + ID + "'")) == 0)
                return false;
            else
                return true;

        }
       
    }


}
