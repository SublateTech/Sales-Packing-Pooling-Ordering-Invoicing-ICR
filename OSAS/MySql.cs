using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Signature.Data
    {
	/// <summary>
	/// Summary description for MySql.
	/// </summary>

    public enum ConnectionType
    {
        Unique = 0,
        NonUnique = 1
    }

    [Serializable()]
	public class MySQL:IDisposable
	{
        
		static public MySqlConnection		connection    = null; //Singular PC
        public MySqlConnection              Connection = null;
        
		public DataTable			        data;
		public DataSet				        ds;
		private MySqlDataAdapter	        da;
		private MySqlCommandBuilder	        cb;
        private String                      Error = null;
        public Boolean                      IsConnected = false;
        static public String                Database;
        public ConnectionType               connectionType = ConnectionType.Unique;
        private MySqlConnection             _conn = null;

        public MySqlConnection conn
        {
            get { _conn = connectionType== ConnectionType.Unique? connection:Connection;
                    return _conn;}
            set { 
                if (connectionType== ConnectionType.Unique)
                      connection = value;
                else
                      Connection = value;
                }
        }
    
        #region MySQL Class Methods
        public MySQL(ConnectionType connectionType)
        {
            this.Close(ConnectionType.Unique);
            connectionType = ConnectionType.NonUnique;
            this.Open();
        }
        public  MySQL()
		{
            this.Open();
		}
        ~  MySQL()
        {
           // ErrorMsg("Close dest");
          //  Close(); 
        }
        public  MySQL(String IP, String DataBase)
		{
            IsConnected = Open(IP, DataBase);
            	
		}
        public MySQL(String IP, String DataBase,String User, String Password)
        {
            IsConnected = Open(IP, DataBase, User, Password);
        }
        public void Open()  
        {
         //   if (!Open("localhost", "SigData","SigData","SigData009"))
            {
     //          if (!Open("127.0.0.1", "SigData"))
                {
                    if (!Open("lserver", "SigData"))
                    {
                        if (!Open("207.104.236.2", "SigData"))
                            MessageBox.Show("This application couldn't find any DataBase");
                    }
                }
            }
        }
        private bool Open(String IP, String dataBase)
		{
			return this.Open(IP,dataBase,"SigData", "SigData009");
		}
        private bool Open(String IP, String DataBase, String User, String Password)
        {
                if (conn == null)
                {
                    string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                    IP, User, Password, DataBase);

                    try
                    {
                        conn = new MySqlConnection(connStr);
                        conn.Open();

                    }
                    catch (MySqlException ex)
                    {
                        conn = null;
                        Error = "Error connecting to the server: " + ex.Message;
                        return false;
                    }
                    finally
                    {
                        Database = IP;
                    }
                }
                return true;
        }

        public void Close(ConnectionType connType)
        {
            this.connectionType = connType;
            if (this.conn != null)
            {
                conn.Close();
                conn = null;
                return;
            }
        }
        
        public void Close()
		{
            if (this.conn != null)
            {
                conn.Close();
                conn = null;
                return;
            }
		}

        public void Dispose()
        {
            this.Close();
        }
        public int exec_sql_no(String my_Sql)
        {
            int count = 0;
            try
            {
                
                MySqlCommand MyCmd = new MySqlCommand(my_Sql, conn);
                //ErrorMsg(my_Sql);
                //MessageBox.Show(my_Sql);
            
                count = Convert.ToInt32(MyCmd.ExecuteScalar().ToString(), 10);
            }
            catch (MySqlException ex)
            {
                ErrorMsg("There was an error in executing the SQL." +
                    "\nError Message:" + ex.Message,"exec_sql_no");
            }
            return count;

        }
		public void exec_sql(String my_Sql)
		{
            try
            {
			    MySqlCommand MyCmd = new MySqlCommand(my_Sql, conn);
	    		MyCmd.ExecuteScalar();
			} 
			catch (MySqlException  ex) 
			{
				ErrorMsg("There was an error in executing the SQL." +
					"\nError Message:" + ex.Message+"-->"+my_Sql,"exec_sql");
			}
            
			return ;
		}
        public Int32 exec_sql_id(String my_Sql)
        {
            MySqlCommand MyCmd = new MySqlCommand();
            try
            {    
                MyCmd = new MySqlCommand(my_Sql, conn);
                MyCmd.CommandType = CommandType.Text;
            
                MyCmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                ErrorMsg("There was an error in executing the SQL." +
                    "\nError Message:" + ex.Message + "-->" + my_Sql,"exec_sql_id");
            }

            return (Int32) MyCmd.LastInsertedId;
        }
		public int exec_sql_afected(String my_Sql)
        {
            int count = 0;
            try
            {
			    MySqlCommand MyCmd = new MySqlCommand(my_Sql, conn);
			    //ErrorMsg(my_Sql);
			    //MessageBox.Show(my_Sql);
				count =  MyCmd.ExecuteNonQuery();
			} 
			catch (MySqlException  ex) 
			{
				ErrorMsg("There was an error in executing the SQL." +
					"\nError Message:" + ex.Message,"exec_sql_afected");
			}
			return count;
        }
        public DataSet GetDataset(String sSql, String Table)
        {
            String sTable = Table;
            DataSet ds = new DataSet();
            try
            {
                this.da = new MySqlDataAdapter(sSql, conn);
                this.da.SelectCommand.CommandTimeout = 120;
                this.da.Fill(ds, sTable);
            }

            catch (Exception ex)
            {
                ErrorMsg(ex.Message,"GetDataset");
            }

            return ds;
        }
        public DataSet GetDataset(String sSql)
        {
            
            DataSet ds = new DataSet();
            try
            {
                this.da = new MySqlDataAdapter(sSql, conn);
                this.da.Fill(ds);
            }

            catch (Exception ex)
            {
                ErrorMsg(ex.Message,"GetDataset");
            }

            return ds;
        }
        public DataTable GetDataTable(String sSql, String stable)
        {
            DataSet ds = new DataSet();
            DataTable t;
            ds = GetDataset(sSql, stable);
            t = ds.Tables[stable];
            ds.Tables.Clear();
            return t;
        }
        public DataTable GetDataTable(String sSql)
        {
            Random n = new Random();
            String sTable = "tmp" + n.ToString();
            return GetDataTable(sSql,sTable);
        }
        public DataView GetDataView(String sSql, String stable)
        {
            //MessageBox.Show(sSql);
            DataSet ds = new DataSet();
            ds = GetDataset(sSql, stable);
            DataView dt = new DataView(ds.Tables[stable]);
            return dt;

        }
        public DataRow GetDataRow(String sSql, String stable)
        {
            try
            {

                DataSet ds = new DataSet();
                DataRow r;
                ds = GetDataset(sSql, stable);

                if (ds.Tables[stable].Rows.Count > 0)
                {
                    r = ds.Tables[stable].Rows[0];
                    return r;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorMsg(ex.Message,"GetDataRow");
                return null;
            }
        }
        public String SqlTimeDate(DateTime Date)
        {
            return Date.ToString("yyyy-MM-dd hh:mm:ss");
        }
        public String SqlDate(DateTime Date)
        {
            return Date.ToString("yyyy-MM-dd");
        }
        public void ChangeDatabase(String DataBase)
        {
            this.exec_sql("USE " + DataBase);
        }

        public bool ChangeDatabase(String IP, String User, String Password, String DataBase)
        {
            conn = null;
            if (!Open(IP, DataBase, User, Password))
            {
                Console.WriteLine("Database: " + Database + " is not open!!");
                return false;
            }

          //  this.exec_sql("USE " + DataBase);
            return true;
        }

        private void ErrorMsg(String _Message, String Module)
        {
            throw new Exception(_Message);
        }
        #endregion

        #region Report Files
        //Reports Files

        public DataSet get_ranking_by_student(String sCompanyID, String sCustomerID, String Selection)
        {
            /*	this.ds = new DataSet();
			
                da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  o.CustomerID='T0001'  And  o.Student = d.Student Group by d.Student Order by o.Retail Desc", this.conn );
                cb = new MySqlCommandBuilder( da );

                da.Fill( this.ds,"tmp" );

                return this.ds;*/


            this.ds = new DataSet();

            da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON r.CompanyID=d.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON c.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN  Brochure b1 ON c.CompanyID=b1.CompanyID And  c.BrochureID_2 = b1.BrochureID Where d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY CustomerID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Customer");

            if (Selection == "Dollars")
                da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  d.CompanyID='" + sCompanyID + "' And    o.CustomerID='" + sCustomerID + "'  And  o.Student = d.Student Group by d.Student Order by o.Retail Desc", conn);
            else
                da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  d.CompanyID='" + sCompanyID + "' And    o.CustomerID='" + sCustomerID + "'  And  o.Student = d.Student Group by d.Student Order by SUM(d.Quantity) Desc", conn);

            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "tmp");
            return this.ds;

        }
        public DataSet get_summary_by_classes(String sCompanyID, String sCustomerID)
        {
            //DataRelation relCustOrder;

            this.ds = new DataSet();

            da = new MySqlDataAdapter("select distinct(o.Teacher), count(distinct o.student) as Sellers, sum(quantity) as Items,  sum(quantity*p.Price_2) as Sale , sum(o.Tax) as Tax,  d.CustomerID from OrderDetail d  left join  Product p  on p.ProductID=d.ProductID And p.CompanyID=d.CompanyID Left Join Orders o On d.OrderID=o.ID where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' and  p.ProductID = d.ProductId  and p.CompanyID=d.CompanyID Group by o.Teacher", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Orders");

            da = new MySqlDataAdapter("select c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.RepID, r.Name as RepName, Signed   from Customer c  LEFT JOIN Reps r ON c.Rep_ID=r.ID  Where c.CompanyID='" + sCompanyID + "' And  CustomerID='" + sCustomerID + "'", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Customer");

            //relCustOrder = new DataRelation("CustomersOrders",  ds.Tables["Orders"].Columns["CustomerID"], ds.Tables["Customer"].Columns["CustomerID"],  false);
            // Add the relation to the DataSet.
            //ds.Relations.Add(relCustOrder);


            return this.ds;

        }
        public DataSet get_summary_of_products_by_brochure(String sCompanyID, String sCustomerID)
        {
            this.ds = new DataSet();

            da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products From OrderDetail as d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID Where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY d.CustomerID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Customer");

            da = new MySqlDataAdapter("SELECT DISTINCT d.CustomerID, pb.BrochureID, d.ProductID, p.Description, SUM(d.quantity) as Qty, SUM(Tax) as Tax, p.Price, p.Price*SUM(d.quantity) as Retail, p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice FROM OrderDetail d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.CompanyID=p.CompanyID And d.ProductID = p.ProductID  LEFT JOIN Product_by_Brochure pb ON d.CompanyID=pb.CompanyID And (c.BrochureID=pb.BrochureID And  d.ProductID = pb.ProductID) or (c.BrochureID_2=pb.BrochureID And  d.ProductID = pb.ProductID)  Where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY d.CustomerID, pb.BrochureID, d.ProductID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Summary");

            da = new MySqlDataAdapter("SELECT * from Brochure Where CompanyID='" + sCompanyID + "'", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Brochure");


            //1. Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products From OrderDetail as d LEFT JOIN Customer c ON c.CustomerID = d.CustomerID LEFT JOIN Rep r ON c.RepID=r.RepID Where d.CustomerID="T0001" GROUP BY d.CustomerID
            //3. SELECT DISTINCT d.CustomerID, pb.BrochureID, d.ProductID, p.Description, SUM(d.quantity) as Qty, SUM(Tax) as Tax, p.Price, p.Price*SUM(d.quantity) as Retail, p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice FROM OrderDetail d LEFT JOIN Customer c ON c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.ProductID = p.ProductID  LEFT JOIN product_by_Brochure pb ON (c.BrochureID=pb.BrochureID And  d.ProductID = pb.ProductID) or (c.BrochureID_2=pb.BrochureID And  d.ProductID = pb.ProductID)  Where d.CustomerID='T0001' GROUP BY d.CustomerID, pb.BrochureID, d.ProductID
            return this.ds;

        }
        public DataSet get_detail_by_student(String sCompanyID, String sCustomerID)
        {

            this.ds = new DataSet();

            da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON d.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN Brochure b1 ON d.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY d.CustomerID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Customer");

            da = new MySqlDataAdapter("SELECT DISTINCT d.CustomerID, d.Teacher, d.Student, d.ProductID, p.Description, o.Prize, p.Price, SUM(d.quantity) as Qty, SUM(d.Tax) as Tax,  sum(p.Price*d.quantity) as Retail, sum(p.Price*d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice, o.Collected FROM OrderDetail d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.CompanyID=p.CompanyID And d.ProductID = p.ProductID  LEFT JOIN Orders o ON d.CompanyID=o.CompanyID And o.Teacher= d.Teacher  And  o.Student = d.Student   Where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY d.CustomerID, d.Teacher, d.Student, d.ProductID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Summary");
            return this.ds;


        }
        public DataSet get_prize_summary_by_student_by_class(String sCompanyID, String sCustomerID)
        {
            this.ds = new DataSet();

            da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON d.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN Brochure b1 ON d.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where  d.CompanyID='" + sCompanyID + "' And  d.CustomerID='" + sCustomerID + "' GROUP BY d.CustomerID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Customer");

            da = new MySqlDataAdapter("SELECT CustomerID, Teacher, Student, Prize as 'Product ID', p.Description, p.Price as Cost, o.Nro_Items  as 'Order Qty' FROM Orders o LEFT JOIN Product p  ON o.CompanyID=p.CompanyID And o.Prize = p.ProductID Where  o.CompanyID='" + sCompanyID + "' And Prize<>'' And CustomerID='" + sCustomerID + "' ORDER BY Teacher, Student", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Summary");
            return this.ds;


        }
        /*public DataSet GetPOReceive(String CompanyID, String ReceiveID)
        {

            this.ds = new DataSet();
            da = new MySqlDataAdapter(String.Format("Select * from ReceiveDetail rd Left join Product pr on rd.ProductID=pr.ProductID And rd.CompanyID=pr.CompanyID Left join Receive r on rd.PurchaseID=r.PurchaseID And rd.CompanyID=r.CompanyID And rd.ReceiveID=r.ReceiveID Left join Purchase p on rd.PurchaseID=p.PurchaseID And rd.CompanyID=p.CompanyID Left join Vendor v on p.VendorID=v.VendorID And p.CompanyID=v.CompanyID Where p.CompanyID='{0}' and rd.ReceiveID='{1}'", CompanyID, ReceiveID), conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Receive");



            return this.ds;
        }*/
        /*
        public DataSet get_summary_reps_sales(String sCompanyID)
        {
            this.ds = new DataSet();

            da = new MySqlDataAdapter("SELECT c.RepID,r.Name, CustomerID, c.Name, c.Address, city, State, ZipCode, c.PhoneNumber, ChairPerson, HeadPhone, c.PrizeID, p.Description as Prize_Description,  SignedDate, StartDate, EndDate, PickUpDate, DeliveryDate, Signed , NoItems, NoSellers,Retail, Retail/NoSellers as Avg_Retail, NoItems/NoSellers as Av_Units, '' as BrochureID, '' as BrochureID_2,'' as Description, '' as Description_2   FROM Customer c LEFT JOIN Prizes p ON c.CompanyId=p.CompanyID and c.PrizeID=p.PrizeID LEFT JOIN Reps r ON c.Rep_ID=r.ID  Where c.CompanyID ='" + sCompanyID + "' ORDER BY c.CompanyID,c.RepID,c.CustomerID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Summary");
            return this.ds;
        }
         */
        public DataSet get_summary_reps_sales()
        {
            //this is for OSAS WEB Information

            this.ds = new DataSet();

            da = new MySqlDataAdapter("Select distinct(r.Name), u.User,u.Password,u.RepID From user u Left Join Rep r On u.RepID=r.RepID", conn);
            cb = new MySqlCommandBuilder(da);

            da.Fill(this.ds, "Summary");
            return this.ds;
        }
        
        #endregion


        public static String PrepareSql(String Sql)
        {
            if (Sql == null)
                return "";
            else
                return Sql.Replace("'", "\\'").Replace("\"", "\\'");
        }
      
	}
    public class SqlBuilder
    {
        private String SqlCommand;
        private ArrayList SqlFields;
        private String Table;

        public SqlBuilder()
        {
            SqlCommand = String.Empty;
            SqlFields = new ArrayList();
        }

        public void AddRange(String Table, String[] Fields, Object[] Values)
        {
            if (Fields.Length != Values.Length)
            {
                Console.Write(String.Format("Fields with different size Fields:{0} and Values:{1}", Fields.Length, Values.Length));
                return;
            }

            this.Table = Table;
            Int32 Count = Fields.Length;
            for (int i = 0; i < Count; i++)
            {
                Field _Field = new Field(Fields[i], Values[i]);
                SqlFields.Add(_Field);
            }
        }
        public void Add(String Field)
        {
            SqlFields.Add(Field);
        }
        public void ListFields()
        {
            foreach (Field _Field in SqlFields)
            {
                Console.WriteLine(_Field.Name + " - " + _Field.Value.ToString());
            }
        }

        public String Insert()
        {
            String InsertStr = "Insert into " + Table + " (";
            String Values = "Values(";
            
            foreach (Field _Field in SqlFields)
            {
                if (_Field.Value == null)
                    continue;
                InsertStr += _Field.Name + ",";
                
                
                if (_Field.Value.GetType() == typeof(System.Boolean))
                    Values += "\"" + Convert.ToByte((Boolean)_Field.Value).ToString() + "\"" + ",";
                else if (_Field.Value.GetType() == typeof(System.DateTime))
                    Values += "'"+((DateTime)_Field.Value).ToString("yyyy-MM-dd hh:mm:ss") + "',";

                else if (_Field.Value.GetType() == typeof(System.String) && _Field.Value.ToString().IndexOf("MD5(") >= 0 )
                    Values +=  _Field.Value.ToString() +  ",";
                else
                    Values += "\"" + _Field.Value.ToString() + "\"" + ",";
                    
            }

            InsertStr = InsertStr.Substring(0, InsertStr.Length - 1) + ")";
            Values = Values.Substring(0, Values.Length - 1) + ")";

            InsertStr += " " + Values;
            return InsertStr;
        }

        public String Update(String Where)
        {
            String Str = "Update " + Table + " Set ";
            String Value = "";

            foreach (Field _Field in SqlFields)
            {
                
                if (_Field.Value == null)
                    continue;
                if (_Field.Value.GetType() == typeof(System.Boolean))
                    Value = "\"" + Convert.ToByte((Boolean)_Field.Value).ToString() + "\"" ;
                else if (_Field.Value.GetType() == typeof(System.DateTime))
                    Value = "Date('" + ((DateTime)_Field.Value).ToString("yyyy-MM-dd hh:mm:ss") + "')";
                else if (_Field.Value.GetType() == typeof(System.String) && _Field.Value.ToString().IndexOf("MD5(") >= 0)
                    Value = _Field.Value.ToString();
                else
                    Value = "\"" + _Field.Value.ToString() + "\"";
                
                Str += _Field.Name + "="+ Value +",";

            }
            Str = Str.Substring(0, Str.Length - 1) + " " + Where;
            
            return Str;
        }

                
        class Field
        {
            public String Name;
            public Object Value;

            public Field(String Name, Object Value)
            {
                this.Name = Name;
                this.Value = Value;
            }
        }
    }
    
}
