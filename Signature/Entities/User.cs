using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;
using Signature.Reports;
using Signature.Data;



namespace Signature.Classes
{
    public class User
    {
        private Signature.Data.MySQL oMySql = Global.oMySql;
        internal SqlBuilder oBuild; //Reuqired
        internal String TableName = "user";
        
        // Properties
        public Int32 ID;
        public String UserID;
        public String Password;
        public Int32 RepID;
        public DateTime dateTime;
        public String ComputerName;
        public String IP;
        
        //Methods
        public User()
        {
            
        } //Constructor

        public bool Find(Int32 ID)
        {
            if (ID == 0)
            {
                this.Password = "";

                this.ID = 0;
                return false;
            }

            DataRow rProduct = this.oMySql.GetDataRow("Select * From user Where ID='" + ID.ToString() + "'", "user");

            if (rProduct == null)
            {
                this.ID = 0;
                return false;
            }

            this.ID         = (Int32) rProduct["ID"];
            this.UserID     = rProduct["User"].ToString();
            this.Password   = rProduct["Password"].ToString();
            this.RepID      = (Int32)rProduct["Rep_ID"];
            this.IP         = rProduct["IP"].ToString();
            this.dateTime   = (rProduct["DateTime"] == DBNull.Value) ? Global.DNull : (DateTime)rProduct["DateTime"];
            this.ComputerName = rProduct["ComputerName"].ToString();

            return true;

        }
        public bool Find(String UserID, String Password)
        {
   
            if (UserID == "" || UserID == null)
            {
                this.Password = "";
                this.ID = 0;
                return false;
            }

            DataRow rProduct = this.oMySql.GetDataRow("Select * From user Where User=\""+UserID+"\" And  Password=\"" + Password + "\"", "user");
            
            if (rProduct == null)
            {
                this.ID = 0;
                
                return false;
            }

            this.ID = (Int32) rProduct["ID"];
            this.Find(this.ID);

            return true;
        
        }
        public bool Find(String UserID)
        {



            if (UserID == "" || UserID == null)
            {
                
                this.ID = 0;
                return false;
            }

            DataRow rProduct = this.oMySql.GetDataRow("Select * From user Where User=\"" + UserID + "\" ", "user");

            if (rProduct == null)
            {
                this.ID = 0;

                return false;
            }

            this.ID = (Int32)rProduct["ID"];
            this.Find(this.ID);
            
            return true;

        }
        public bool ExistUser()
        {
          //  if ((oMySql.exec_sql_no("Select count(*) from Brochure Where UserID='" + this.ID + "' And CompanyID='" + this.CompanyID + "'")) == 0)
            if ((oMySql.exec_sql_no("Select count(*) from user Where User='" + this.ID + "'")) == 0)
                return false;
            else
                return true;
        }
        
        public  void Save()
        {
            
            if (Exists() && this.ID != 0)
                Update();
            else
                Insert();

            
        }
        public  void Update()
        {
            FillFields();
            oMySql.exec_sql(oBuild.Update(String.Format("Where ID='"+this.ID + "'")));
        }
        public  void Insert()
        {
            FillFields();
            this.ID = Global.oMySql.exec_sql_id(oBuild.Insert());

        }
        internal void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                "User",
                "Rep_ID",
                "Password", 
                "DateTime",
                "ComputerName",
                "Ip"
                },
                new Object[] {
                    this.UserID,
                    this.RepID,
                    this.Password,
                    this.dateTime,
                    this.ComputerName,
                    this.IP
                    });
        }
        public bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where ID='{1}'",TableName,this.ID)) == 0))
                return false;
            else
                return true;
        }
        public  void Delete()
        {
            String Sql = String.Format("Delete From {0} Where ID='{1}'",this.TableName,this.ID);
            oMySql.exec_sql(Sql);
        }

        public void DeleteBy(Int32 RepID)
        {
            String Sql = "Delete From OrderTicket Where RepID='" + RepID + "'";
            oMySql.exec_sql(Sql);
        }

        public bool View()
        {
            frmViewUsers oView = new frmViewUsers();
            oView.ShowDialog();
            if (oView.sSelectedID != 0)
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }

        public DataTable GetActiveUsers()
        {
            return oMySql.GetDataTable("SELECT User,  DateTime, Now(), (TIME_TO_SEC(NOW()) - TIME_TO_SEC(DateTime))/60 FROM `user` Where DateTime is not null and (TIME_TO_SEC(NOW()) - TIME_TO_SEC(DateTime))/60 <10");
        }
        
    }
}
