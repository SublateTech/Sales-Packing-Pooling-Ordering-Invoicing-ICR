using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace OSAS{
	/// <summary>
	/// Summary description for MySql.
	/// </summary>
	
	
	public class MySql
	{
		private String				Host=new string(' ',20);
		private MySqlConnection		conn;
		public DataTable			data;
		public DataSet				ds;
		private MySqlDataAdapter	da;
		private MySqlCommandBuilder	cb;

		
		public MySql()
		{
			Open("192.168.254.66", "signatv9_OSAS");
            	
		}
		public MySql(String IP, String DataBase)
		{
			Open(IP,DataBase);
            	
		}

		private void Open(String IP, String DataBase)
		{
			//this.Host = "localhost";
			this.Host = "www.sigfund.com";
			if (conn != null)
				conn.Close();
	
			
			string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
				IP, "signatv9_sa", "sa", DataBase );

		
			try 
			{
				conn = new MySqlConnection( connStr );
				conn.Open();
		
				//				GetDatabases();
			}
			catch (MySqlException ex) 
			{
				MessageBox.Show( "Error connecting to the server: " + ex.Message );
			}
			
		}
		public int exec_sql_no(string my_Sql)
		{
			
			int count=0;
			MySqlCommand MyCmd = new MySqlCommand(my_Sql, this.conn);
			//MessageBox.Show(my_Sql);
			//Console.WriteLine(my_Sql);
			try 
			{
				count = Convert.ToInt16(MyCmd.ExecuteScalar().ToString(),10);
			} 
			catch (MySqlException  ex) 
			{
				MessageBox.Show("There was an error in executing the SQL." +
					"\nError Message:" + ex.Message, "SQL");
			}
			return count;
			
		}

		public void close()
		{
			conn.Close();
			return;
		}		

		public void exec_sql(String my_Sql)
		{
			
			
			MySqlCommand MyCmd = new MySqlCommand(my_Sql, this.conn);
			//MessageBox.Show(my_Sql);
			//Console.WriteLine(my_Sql);
			try 
			{
				MyCmd.ExecuteScalar();
			} 
			catch (MySqlException  ex) 
			{
				MessageBox.Show("There was an error in executing the SQL." +
					"\nError Message:" + ex.Message+"-->"+my_Sql, "SQL");
			}
			return ;
		}
		public int exec_sql_afected(string my_Sql) 
		{

			int count=0;
			MySqlCommand MyCmd = new MySqlCommand(my_Sql, this.conn);
			//MessageBox.Show(my_Sql);
			//Console.WriteLine(my_Sql);
			try 
			{
				count =  MyCmd.ExecuteNonQuery();
			} 
			catch (MySqlException  ex) 
			{
				MessageBox.Show("There was an error in executing the SQL." +
					"\nError Message:" + ex.Message, "SQL");
			}
			return count;
		
		}
		
		public DataSet get_rep_charges(String sCompanyID, String sRepID)
		{
			this.ds = new DataSet();
			
			//da = new MySqlDataAdapter("Select ChargeID, DATE_FORMAT(Date,'%m/%d/%Y') as Date, Description, Description_1, Description_2, Charge  from rep_charges Where CompanyID ='"+sCompanyID+"' And RepId='"+sRepID+"' ORDER BY CompanyID,RepID,ChargeID", this.conn );
			if (sRepID=="")	
				da = new MySqlDataAdapter("Select ch.RepID, r.Name, ChargeID, DATE_FORMAT(Date,'%Y-%m-%d') as Date, Description, Description_1, Description_2, Charge  from rep_charges ch LEFT JOIN Rep r On ch.RepID=r.RepID And ch.CompanyID=r.CompanyID Where ch.CompanyID ='"+sCompanyID+"'  ORDER BY ch.CompanyID,ch.RepID,ChargeID", this.conn );	
			else
				da = new MySqlDataAdapter("Select ch.RepID, r.Name, ChargeID, DATE_FORMAT(Date,'%m/%d/%Y') as Date, Description, Description_1, Description_2, Charge  from rep_charges ch LEFT JOIN Rep r On ch.RepID=r.RepID And ch.CompanyID=r.CompanyID Where ch.CompanyID ='"+sCompanyID+"' And ch.RepId='"+sRepID+"' ORDER BY ch.CompanyID,ch.RepID,ChargeID", this.conn );	
			
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"tmp" );

			return this.ds;

		}
		public DataTable get_customers(String sCompanyID, String sCustomerID)
		{
			this.data = new DataTable();
			
			if (sCustomerID=="*")
				da = new MySqlDataAdapter("Select CustomerID from Customer Where CompanyID='"+sCompanyID+"'", this.conn );
			else
				da = new MySqlDataAdapter("Select CustomerID from Customer Where CompanyID='"+sCompanyID+"' And CustomerID='"+sCustomerID+"'", this.conn );
			
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.data );

			return this.data;

		}

		public int get_last_number()
		{
			this.ds = new DataSet();
			
			da = new MySqlDataAdapter("SELECT COUNT(*) as total  FROM cart_Orders WHERE open='n'", this.conn );
			
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.data );

			return int.Parse(this.data.Rows[0]["total"].ToString());
		}

		public DataView get_customer_dataview(String sCompanyID)
		{
			DataSet ds = new DataSet();
			
			da = new MySqlDataAdapter("SELECT CustomerId, Name, Address from Customer Where CompanyID='"+sCompanyID+"'", this.conn );
			
			cb = new MySqlCommandBuilder( da );
			
			da.Fill( ds,"Customers");

			DataView dt = new DataView(ds.Tables["Customers"]);
			
			return dt;
		}

		public DataTable  get_orders()
		{
			this.data = new DataTable();
			
			da = new MySqlDataAdapter("SELECT DISTINCT DATE_FORMAT(processed_on,'%m/%d/%Y') as date, SUM(subtotal) as subtotal, SUM(discount) as discount, SUM(shipping) as shipping , SUM(total) as total, COUNT(*) as count  FROM cart_Orders WHERE open='n' GROUP BY DATE_FORMAT(processed_on,'%m/%d/%Y')", this.conn );
			//da = new MySqlDataAdapter("SELECT DISTINCT DATE(processed_on) as date,  SUM(subtotal) as subtotal, SUM(discount) as discount, SUM(shipping) as shipping , SUM(total) as total, COUNT(*) as count  FROM cart_Orders WHERE open='n' GROUP BY DATE(processed_on)", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.data );

			return this.data;
		}

		public void get_users()
		{
		
			//SELECT User, r.Name, Password, u.RepID FROM `user` u LEFT JOIN Rep r On u.RepID=r.RepID And r.CompanyID="S07"
		}


		
		//Reports Files
		
		public DataSet get_ranking_by_student(String sCompanyID, String sCustomerID, String Selection)
		{
			/*	this.ds = new DataSet();
			
				da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  o.CustomerID='T0001'  And  o.Student = d.Student Group by d.Student Order by o.Retail Desc", this.conn );
				cb = new MySqlCommandBuilder( da );

				da.Fill( this.ds,"tmp" );

				return this.ds;*/


			this.ds = new DataSet();
                        
			da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON r.CompanyID=d.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON c.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN  Brochure b1 ON c.CompanyID=b1.CompanyID And  c.BrochureID_2 = b1.BrochureID Where d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );

			if (Selection=="Dollars")
				da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  d.CompanyID='"+sCompanyID+"' And    o.CustomerID='"+sCustomerID+"'  And  o.Student = d.Student Group by d.Student Order by o.Retail Desc", this.conn );
			else
				da = new MySqlDataAdapter("SELECT distinct  o.Student, SUM(d.Quantity), o.retail, o.Teacher FROM Orders o, OrderDetail d Where  d.CompanyID='"+sCompanyID+"' And    o.CustomerID='"+sCustomerID+"'  And  o.Student = d.Student Group by d.Student Order by SUM(d.Quantity) Desc", this.conn );
			
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"tmp" );
			return this.ds;

		}

		public DataSet get_summary_by_classes(String sCompanyID, String sCustomerID)
		{
			//DataRelation relCustOrder;

			this.ds = new DataSet();
			
			da = new MySqlDataAdapter("select distinct(Teacher), count(distinct student) as Sellers, sum(quantity) as Items,  sum(quantity*p.Price) as Sale , sum(Tax) as Tax,  d.CustomerID from OrderDetail d, Product p where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' and  p.ProductID = d.ProductId  and p.CompanyID=d.CompanyID Group by Teacher", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Orders" );

			da = new MySqlDataAdapter("select c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.RepID, r.Name as RepName, Signed, ProfitPercent, b.Description as BrochureName, b1.Description as BrochureName_2  from Customer c  LEFT JOIN Rep r ON c.CompanyID=r.CompanyID And  c.RepID=r.RepID  LEFT JOIN Brochure b ON c.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID  LEFT JOIN Brochure b1 ON c.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where c.CompanyID='"+sCompanyID+"' And  CustomerID='"+sCustomerID+"'", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );
			
			//relCustOrder = new DataRelation("CustomersOrders",  ds.Tables["Orders"].Columns["CustomerID"], ds.Tables["Customer"].Columns["CustomerID"],  false);
			// Add the relation to the DataSet.
			//ds.Relations.Add(relCustOrder);

			
			return this.ds;

		}
		
		public DataSet get_summary_of_products_by_brochure(String sCompanyID, String sCustomerID)
		{
			this.ds = new DataSet();
			
			da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products From OrderDetail as d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );

			da = new MySqlDataAdapter("SELECT DISTINCT d.CustomerID, pb.BrochureID, d.ProductID, p.Description, SUM(d.quantity) as Qty, SUM(Tax) as Tax, p.Price, p.Price*SUM(d.quantity) as Retail, p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice FROM OrderDetail d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.CompanyID=p.CompanyID And d.ProductID = p.ProductID  LEFT JOIN Product_by_Brochure pb ON d.CompanyID=pb.CompanyID And (c.BrochureID=pb.BrochureID And  d.ProductID = pb.ProductID) or (c.BrochureID_2=pb.BrochureID And  d.ProductID = pb.ProductID)  Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID, pb.BrochureID, d.ProductID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );

			da = new MySqlDataAdapter("SELECT * from Brochure Where CompanyID='"+sCompanyID+"'", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Brochure" );

	
			//1. Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products From OrderDetail as d LEFT JOIN Customer c ON c.CustomerID = d.CustomerID LEFT JOIN Rep r ON c.RepID=r.RepID Where d.CustomerID="T0001" GROUP BY d.CustomerID
			//3. SELECT DISTINCT d.CustomerID, pb.BrochureID, d.ProductID, p.Description, SUM(d.quantity) as Qty, SUM(Tax) as Tax, p.Price, p.Price*SUM(d.quantity) as Retail, p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice FROM OrderDetail d LEFT JOIN Customer c ON c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.ProductID = p.ProductID  LEFT JOIN product_by_Brochure pb ON (c.BrochureID=pb.BrochureID And  d.ProductID = pb.ProductID) or (c.BrochureID_2=pb.BrochureID And  d.ProductID = pb.ProductID)  Where d.CustomerID='T0001' GROUP BY d.CustomerID, pb.BrochureID, d.ProductID
			return this.ds;

		}
		
		public DataSet get_detail_by_student_by_class(String sCompanyID, String sCustomerID)
		{
						
			this.ds = new DataSet();
                        
			da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON c.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN Brochure b1 ON c.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );

			da = new MySqlDataAdapter("SELECT DISTINCT d.CustomerID, d.Teacher, d.Student, o.Prize, SUM(d.quantity) as Qty, SUM(d.Tax) as Tax,  sum(p.Price*d.quantity) as Retail, sum(p.Price*d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice, o.Collected FROM OrderDetail d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.CompanyID=p.CompanyID And d.ProductID = p.ProductID  LEFT JOIN Orders o ON d.CompanyID=o.CompanyID And o.Teacher= d.Teacher  And  o.Student = d.Student   Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID, d.Teacher, d.Student", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );
			return this.ds;
	

		}

		public DataSet get_detail_by_student(String sCompanyID, String sCustomerID)
		{
				
			this.ds = new DataSet();
                        
			da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON c.CompanyID=d.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON d.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN Brochure b1 ON d.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );

			da = new MySqlDataAdapter("SELECT DISTINCT d.CustomerID, d.Teacher, d.Student, d.ProductID, p.Description, o.Prize, p.Price, SUM(d.quantity) as Qty, SUM(d.Tax) as Tax,  sum(p.Price*d.quantity) as Retail, sum(p.Price*d.quantity)*c.ProfitPercent/100 as Profit, p.Price*SUM(d.quantity)- p.Price*SUM(d.quantity)*c.ProfitPercent/100 as Invoice, o.Collected FROM OrderDetail d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Product p ON d.CompanyID=p.CompanyID And d.ProductID = p.ProductID  LEFT JOIN Orders o ON d.CompanyID=o.CompanyID And o.Teacher= d.Teacher  And  o.Student = d.Student   Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID, d.Teacher, d.Student, d.ProductID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );
			return this.ds;

	
			return(this.ds);
				
		}

		public DataSet get_prize_summary_by_student_by_class(String sCompanyID, String sCustomerID)
		{
			this.ds = new DataSet();
                        
			da = new MySqlDataAdapter("Select  c.CustomerID, c.Name, c.Address, c.City, c.State, c.ZipCode, c.PhoneNumber, c.FaxNumber, c.RepID, r.Name as Rep_Name, r.PhoneNumber as R_PhoneNumber, Signed, count(distinct d.Teacher) as n_teachers, count(distinct d.Student) as n_sellers, Sum(d.Quantity) as n_items, count(distinct ProductID) as n_products, c.BrochureID, b.Description as Brochure_Description, c.BrochureID_2, b1.Description as Brochure_Description_2 From OrderDetail as d LEFT JOIN Customer c ON d.CompanyID=c.CompanyID And c.CustomerID = d.CustomerID LEFT JOIN Rep r ON d.CompanyID=r.CompanyID And c.RepID=r.RepID LEFT JOIN Brochure b ON d.CompanyID=b.CompanyID And c.BrochureID = b.BrochureID LEFT JOIN Brochure b1 ON d.CompanyID=b1.CompanyID And c.BrochureID_2 = b1.BrochureID Where  d.CompanyID='"+sCompanyID+"' And  d.CustomerID='"+sCustomerID+"' GROUP BY d.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Customer" );

			da = new MySqlDataAdapter("SELECT CustomerID, Teacher, Student, Prize as 'Product ID', p.Description, p.Price as Cost, o.Nro_Items  as 'Order Qty' FROM Orders o LEFT JOIN Product p  ON o.CompanyID=p.CompanyID And o.Prize = p.ProductID Where  o.CompanyID='"+sCompanyID+"' And Prize<>'' And CustomerID='"+sCustomerID+"' ORDER BY Teacher, Student", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );
			return this.ds;

	
			return(this.ds);

		}
		
		public DataSet get_summary_reps_sales(String sCompanyID)
		{
			this.ds = new DataSet();
            			
			da = new MySqlDataAdapter("SELECT c.RepID,r.Name, CustomerID, c.Name, Address, city, State, ZipCode, c.PhoneNumber, ChairPerson, HeadPhone, c.PrizeID, p.Description as Prize_Description, c.BrochureID, b.Description, BrochureID_2, b1.Description as Description_2, SignedDate, StartDate, EndDate, PickUpDate, DeliveryDate, NoUnits, Signed , NoItems, NoSellers,Retail, Retail/NoSellers as Avg_Retail, NoItems/NoSellers as Av_Units  FROM Customer c LEFT JOIN Prizes p ON c.CompanyId=p.CompanyID and c.PrizeID=p.PrizeID LEFT JOIN Rep r ON c.CompanyId=r.CompanyID and  c.RepID=r.RepID LEFT JOIN Brochure b ON c.CompanyId=b.CompanyID and  c.BrochureID=b.BrochureID LEFT JOIN Brochure b1 ON c.CompanyId=b1.CompanyID and  c.BrochureID_2=b1.BrochureID Where c.CompanyID ='"+sCompanyID+"' ORDER BY c.CompanyID,c.RepID,c.CustomerID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );
			return this.ds;
		}
		
		public DataSet get_summary_reps_sales()
		{
			//this is for OSAS WEB Information
			
			this.ds = new DataSet();
            			
			da = new MySqlDataAdapter("Select distinct(r.Name), u.User,u.Password,u.RepID From user u Left Join Rep r On u.RepID=r.RepID", this.conn );
			cb = new MySqlCommandBuilder( da );

			da.Fill( this.ds,"Summary" );
			return this.ds;
		}
		
		
		public DataSet GetDataset(String sSql, String Table ) 
		{
			String sTable=Table;
			DataSet ds = new DataSet();
			try
			{
				this.da = new MySqlDataAdapter(sSql, this.conn);
				this.da.Fill(ds, sTable);
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
			return ds;
		}
		
		public DataTable GetDataTable(String  sSql, String stable) 
		{
			DataSet  ds = new  DataSet();
			DataTable t;
			ds = GetDataset(sSql, stable);
			t = ds.Tables[stable];
			return t;
		
		}
		
		public DataView GetDataView(String  sSql, String stable) 
		{
			DataSet  ds = new  DataSet();
			ds = GetDataset(sSql, stable);
			DataView dt = new DataView(ds.Tables[stable]);
			return dt;
		
		}

		public DataRow GetDataRow(String sSql , String stable ) 
		{
			DataSet  ds = new  DataSet();
			DataRow r;
			ds = GetDataset(sSql, stable);
			if (ds.Tables[stable].Rows.Count > 0) 
			{
				r = ds.Tables[stable].Rows[0];
				return r;
			}else
			{
				return null;
			}
		}																																																	  
																																																			
	}
}
