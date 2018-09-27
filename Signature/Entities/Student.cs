using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Forms;
using Signature.Data;



namespace Signature.Classes
{
    public class Student:Company
    {
        internal new SqlBuilder oBuild; //Reuqired
        internal new String TableName = "Student";
        
        // Properties
        public String _ID;
        private String _Name;
        public new String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public new String ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        
        public String CustomerID;
        public String Teacher;
        public Int32 TeacherID;
        public Int32 StudentID;



        //Methods

        public Student(String CompanyID, String CustomerID)
        {
            this.CompanyID  = CompanyID;
            this.CustomerID = CustomerID;
        } //Constructor

        public Student(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
            
        } //Constructor
        public bool Find(String _CustomerID, String Name)
        {
            this.CustomerID = _CustomerID;
            return Find(Name);
        }
        
        public bool View(String _CustomerID, String _Teacher)
        {
            this.Teacher    = _Teacher;
            this.CustomerID = _CustomerID;
            return View();
        }
        public new bool View()
        {
            frmViewStudent oView = new frmViewStudent(this.CompanyID,this.CustomerID, this.Teacher);
            oView.ShowDialog();
            if (oView.SelectedID != "")
            {
                ID = oView.SelectedID;
                CustomerID = oView.CustomerID;
                CompanyID = oView.CompanyID;
                _Name = oView.SelectedID;
                Teacher = oView.Teacher;
                return true;
            }
            ID = "";
            return false;
        }
        public bool IfExist()
        {
            if (ID == "")
                return false;
            else
                return true;
        }
        

       

        public bool FindByName(String Name, Int32 TeacherID)
        {
            if (Name == "")
                return false;


            DataRow r = oMySql.GetDataRow("Select * From Student Where CompanyID='" + this.CompanyID + "' And CustomerID='" + this.CustomerID + "' And TeacherID='"+TeacherID.ToString()+"' And  Name= \"" + Name + "\"", "Teacher");
            if (r == null)
            {
                StudentID = 0;
                Name = String.Empty;
                return false;
            }
            StudentID = (Int32) r["StudentID"];
            _Name = r["Name"].ToString();
            this.Find(StudentID);
            return true;
        }

        public virtual bool Find(Int32 StudentID)
        {
            this.ID = "";
            this._Name = "";

            if (StudentID == 0)
                return false;

            //MessageBox.Show("Select * From Product Where ProductID='" + ProductID + "'");
            DataRow rProduct = this.oMySql.GetDataRow("Select * From Student Where StudentID='" + StudentID.ToString() + "'", "Student");

            if (rProduct == null)
            {
                this._Name = "No student found!";
                return false;
            }

            this.ID = rProduct["CompanyID"].ToString();
            this.TeacherID = (Int32) rProduct["TeacherID"];
            this._Name = rProduct["Name"].ToString();
            
            

            return true;
        }

        public DataTable GetAll()
        {
            return oMySql.GetDataTable(String.Format("Select * from Student Where CompanyID='{0}' And CustomerID='{1}' And TeacherID='{2}'", this.CompanyID, this.CustomerID,this.TeacherID));
        }
        public DataTable GetOrders()
        {
            // MessageBox.Show(String.Format("Select Date,Nro_Items from Orders Where CompanyID='{0}' And CustomerID='{1}' And Student like '%{2}%'", this.CompanyID, this.CustomerID, this.Name));
            return oMySql.GetDataTable(String.Format("Select ID as OrderID,Date,Nro_Items,Retail,Collected from Orders Where CompanyID='{0}' And CustomerID='{1}' And StudentID='{2}'", this.CompanyID, this.CustomerID,this.StudentID));
        }
        public new virtual void Save()
        {

            if (Exists() && this.StudentID != 0)
                Update();
            else
                Insert();


        }
        public new virtual void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update(String.Format("Where StudentID='{0}'", this.ID)));
        }
        public new virtual void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert()).ToString();

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "StudentID",
                "Name",
                "TeacherID",
                "CustomerID",
                "CompanyID"
                
                },
                new Object[] {
                    this.ID,
                    MySQL.PrepareSql(this.Name),
                    this.TeacherID,
                    this.CustomerID,
                    this.CompanyID

                    });
        }
        public new bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where StudentID='{1}'", TableName,  this.ID)) == 0))
                return false;
            else
                return true;
        }
        public new virtual void Delete()
        {
              String Sql = String.Format("Delete From {0} Where StudentID='{1}'", this.TableName, this.StudentID);
             // MessageBox.Show(Sql);  
            oMySql.exec_sql(Sql);
            
            
        }


        public bool FindName(String Name)
        {
            if (Name == "")
                return true;

            DataRow r = oMySql.GetDataRow("Select * From Names Where Name=\"" + Name + "\"", "Names");
            if (r == null)
            {
                return false;
            }

            return true;
        }

        public bool FindLastName(String Name)
        {
            if (Name == "")
                return true;

            DataRow r = oMySql.GetDataRow("Select * From Names Where Name=\"" + Name + "\"", "Names");
            if (r == null)
            {
                return false;
            }

            return true;
        }

        public void InsertName(String Name)
        {
            String Sql = String.Format("Insert into Names (Name)  Values (\"{0}\")", Name);
            oMySql.exec_sql(Sql);
        }

        public void InsertLastName(String Name)
        {
            String Sql = String.Format("Insert into Names (Name)  Values (\"{0}\")", Name);
            oMySql.exec_sql(Sql);
        }

        public String GetFirstName(String FullName)
        {
            String FirstName = "";
            FullName = FullName.TrimStart().TrimEnd().Replace("  ", " ").Replace("  ", " ").Replace(" ", "").Replace("\\", "");
            String[] Names = FullName.Split(new char[] { ',' });

            if (Names.Length > 1)
                FirstName = Names[1];
            else
                FirstName = "";



            Names = FirstName.Split(new char[] { '-' });
            if (Names.Length > 0)
                FirstName = Names[0];

            Names = FirstName.Split(new char[] { '/' });
            if (Names.Length > 0)
                FirstName = Names[0];


            return FirstName.Replace(".", "").Replace(",", "");
        }


        public String GetLastName(String FullName)
        {
            String FirstName = "";
            FullName = FullName.TrimStart().TrimEnd().Replace("  ", " ").Replace("  ", " ").Replace(" ", "").Replace("\\", "");
            String[] Names = FullName.Split(new char[] { ',' });

            if (Names.Length >= 0)
                FirstName = Names[0];


            Names = FirstName.Split(new char[] { '-' });
            if (Names.Length > 0)
                FirstName = Names[0];

            Names = FirstName.Split(new char[] { '/' });
            if (Names.Length > 0)
                FirstName = Names[0];


            return FirstName.Replace(".", "").Replace(",", "");
        }
    
    }
}
