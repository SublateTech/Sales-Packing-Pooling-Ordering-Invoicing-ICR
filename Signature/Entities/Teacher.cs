using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using MySql.Data.MySqlClient;


namespace Signature.Classes
{
    public class Teacher
    {
        public  Signature.Data.MySQL oMySql = Global.oMySql;
        internal SqlBuilder oBuild; //Reuqired
        internal String TableName = "Teacher";
        
        // Properties
        public String ID;
        private String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public String CompanyID;
        public String CustomerID;
        public Int32 _ID;
        public Int32 NoStudents;
        public Int32 Seq;

        //Methods

        public Teacher(String CompanyID, String CustomerID)
        {
            this.CompanyID  = CompanyID;
            this.CustomerID = CustomerID;
        } //Constructor

        public Teacher(String CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        public bool Find(String _CustomerID, String Name)
        {
            this.CustomerID = _CustomerID;
            return Find(Name);
        }
        public bool Find(String Name)
        {
            if (Name == "")
                return false;

            
            DataRow r = oMySql.GetDataRow("Select * From Orders Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "' And Teacher=\"" + Name + "\"", "Teacher");
            if (r == null)
            {
                /*if ((MessageBox.Show("Is this a new teacher?", "Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                {
                    ID = "";
                    _Name = "";
                    return false;
                }*/
                ID = Name;
                _Name = Name;
                return false;
            }
            ID = Name;
            _Name = Name;
            return true;
            
        
        }
        public bool FindByName(String Name)
        {
            if (Name == "")
                return false;


            DataRow r = oMySql.GetDataRow("Select * From Teacher Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "' And Name=\"" + Name + "\"", "Teacher");
            if (r == null)
            {
                _ID = 0;
                Name = String.Empty;
                return false;
            }
            _ID = (Int32)r["TeacherID"];
            _Name = Name;
            this.Find(_ID);
            return true;
        }
        public bool Find(Int32 TeacherID)
        {
            if (TeacherID == 0)
                return false;

            DataRow r = oMySql.GetDataRow(String.Format("Select * From Teacher Where TeacherID='{0}'", TeacherID), "Teacher");
            if (r == null)
            {
                _ID = 0;
                Name = String.Empty;
                return false;
            }
            _ID = (Int32)r["TeacherID"];
            _Name = r["Name"].ToString();
            NoStudents = (Int32)r["NoStudents"];
            Seq = (Int32)r["Seq"];
            return true;

        }
        public bool View(String _CompanyID, String _CustomerID)
        {
            this.CustomerID = _CustomerID;
            this.CompanyID  = _CompanyID;
            return View();
        }
        public bool View(String _CustomerID)
        {
            this.CustomerID = _CustomerID;
            return View();
        }
        public bool View()
        {
            
            frmViewTeacher oView = new frmViewTeacher(this.CompanyID, this.CustomerID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                ID = oView.sSelectedID;
                CustomerID = oView.CustomerID;
                _Name = oView.sSelectedID;
                return true;
            }
            return false;
        }


        public void Clear()
        {
            _ID = 0;
            Name = "";
            Seq = 0;
            NoStudents = 0;
        }
        public DataTable GetAll()
        {
            return oMySql.GetDataTable(String.Format("Select * from Teacher Where CompanyID='{0}' And CustomerID='{1}'", this.CompanyID, this.CustomerID));
        }
       
        public DataView Orders(String CompanyID, String CustomerID, String Name, OrderType Type)
        {
            DataView _Orders = oMySql.GetDataView("SELECT * FROM signatv9_osas.orders Where CompanyID=\""+CompanyID+"\" And CustomerID=\""+CustomerID+"\" And Teacher=\""+Name+"\" And OrderType="+((int)Type).ToString(), "Orders");

            return _Orders;
        }

        public virtual void Save()
        {

            if (Exists() && this.ID != "")
                Update();
            else
                Insert();


        }
        public virtual void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update(String.Format("Where TeacherID='{0}'", this._ID)));
        }
        public virtual void Insert()
        {
            FillFields();
            this._ID = Convert.ToInt32(Global.oMySql.exec_sql_id(oBuild.Insert()).ToString());

        }
        internal void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "TeacherID",
                "Name",
                "CompanyID",
                "CustomerID",
                "NoStudents",
                "Seq"
                },
                new Object[] {
                    this._ID,
                    MySQL.PrepareSql(this.Name),
                    this.CompanyID,
                    this.CustomerID,
                    this.NoStudents,
                    this.Seq
                    });
        }

        public bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where TeacherID='{1}'", TableName, this._ID)) == 0))
                return false;
            else
                return true;
        }
        public virtual void Delete()
        {
            String Sql = String.Format("Delete From {0} Where TeacherID='{1}'", this.TableName, this._ID);
            oMySql.exec_sql(Sql);
            
            //for Students
            Sql = String.Format("Delete From Student Where TeacherID='{0}'", this._ID);
            oMySql.exec_sql(Sql);

        }


        //New Changes
        public bool FindStudent(String Name)
        {
            if (Name == "")
                return false;


            DataRow r = oMySql.GetDataRow("Select * From Teacher Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "' And Name=\"" + Name + "\"", "Teacher");
            if (r == null)
            {
                _ID = 0;
                _Name = Name;
                return false;
            }
            _ID = (Int32)r["TeacherID"];
            //_Name = Name;
            this.Find(_ID);
            return true;


        }
        public Int32 FindOrCreate(String Name)
        {
            if (!this.FindStudent(Name))
            {
                this.Name = Name;
                this.Seq = GetMaxTeacherSeq() + 1;
                this.Insert();

            }
            return this._ID;
        }
        private Int32 GetMaxTeacherSeq()
        {
            DataRow row = oMySql.GetDataRow(String.Format("SELECT if(Max(Seq)is null,0,Max(Seq)) as MaxTeacher FROM Teacher Where CompanyID='{0}' And CustomerID='{1}'", CompanyID, CustomerID), "tmp");
            if (row == null)
            {

                return 0;
            }
            else
            {
                return Convert.ToInt32(row["MaxTeacher"].ToString());
            }
        }

        public void AssignSequence(String CustomerID)
        {
            DataTable dtCustomers = oMySql.GetDataTable(String.Format("SELECT * FROM Teacher t Where t.CompanyID='{0}' And t.CustomerID='{1}' Order By Name", this.CompanyID,CustomerID), "Teacher");
            int x = 1;
            foreach (DataRow row in dtCustomers.Rows)
            {
                if (this.Find((Int32)row["TeacherID"]))
                {
                    this.Seq = x;
                    this.Update();
                    x++;
                    //if (x == 2)
                    //    break;
                }
            }
        }
    }
}
