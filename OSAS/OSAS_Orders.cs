using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using dSERVE2;


namespace Signature.OSAS
{
	/// <summary>
	/// Summary description for OSAS_Orders.
	/// </summary>
	public class Orders 
	{ 
		public String sCustomerID="";  
		public String sCompanyID="";
		String Sql = "";
			
		short channel=10;
		short cust_channel=20;
		string sKey=new string(' ',100);
		string sKey1=new string(' ',100);
		string cust_sKey=new string(' ',100);
		System.Array arrValues= new System.String[20];
		System.Array arrCustomers= new System.String[20];
		MySQL oMySql;
		dSERVEClass oCustomer;
		String sFile= new string(' ',8);
		private String dServe="192.168.254.02";
        public String Error = null;

		public int inserted_rows =0;
		public int deleted_rows = 0;
		public int updated_rows = 0;

        public Int32 OrderID = 0;

		public struct Log
		{
			public String CustomerID;
			public String Flag;
			public String CompanyID;
		};
		public struct OrderDetail
		{
            public String CustomerID;
			public String CompanyID;
			public String Teacher;
			public String Student;
			public String Seq;
			public String Item;
			public String No_Items;
			public String Tax;
			public String No_Invoiced;
		};
		public struct OrderHeader
		{						
			public String CustomerID;
			public String CompanyID;
			public String Teacher;
			public String Student;
			public String Type;
			public String Prize;
			public String No_Items;
			public String Retail;
			public String Collected;
			public String Tax;
			public String Printed;
			public String Disc_Printed;
			public String Box;
			public String Date;
			public String Phone;

		};

		public OrderHeader Header = new OrderHeader();
		public OrderDetail Detail = new OrderDetail();
		public Log sLog= new Log();
		public Orders()
		{
            
            
            oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open
			oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				this.Error = "Not Connected!!";
				return;
			}
		}
		public Orders(String CompanyID, String CustomerID)
		{
			this.sCompanyID = CompanyID;
			this.sCustomerID = CustomerID;

            //MySQL = new  MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open
            oMySql = new  MySQL();
			oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

        }

#region OSAS Related Methods
        public bool isEOF()
        {
            oCustomer.dsGetKey(channel, ref sKey);
            if (sKey == null)
                return true;
            return false;
        }
        public void open_OSAS_log()
		{
			if (oCustomer.dsOpen("WSCUST",ref cust_channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(cust_channel,"id:c(10*),flag:c(1*),company_id:c(3*)");

			//Start at first record
			oCustomer.dsReadFld(cust_channel,"", 0,"",ref arrCustomers);


		}
		public int next_OSAS_log()
		{
			int err=0;
			err=oCustomer.dsReadFldNext(cust_channel, "id,flag,company_id", ref cust_sKey, ref arrCustomers);
			if (err!=2 && err!=0)
			{
				//MessageBox.Show(err.ToString());
				
				sLog.CompanyID = this.arrCustomers.GetValue(2).ToString();
				sLog.CustomerID = this.arrCustomers.GetValue(0).ToString();
				sLog.Flag = this.arrCustomers.GetValue(1).ToString();

				this.sCustomerID = sLog.CustomerID;
				this.sCompanyID = sLog.CompanyID;
			}
			return err;

		}
		public bool open_OSAS_orders()
		{
			if (oCustomer.dsOpen(this.sCustomerID,ref channel)== 10)  //Open our file to migrate
			{
				MessageBox.Show("This file wasn't open!!!");
				return false;
			}
			else
			{
				//Start at first record
				oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
				return true;
			}
		}
		public bool isHeader()
		{
			if (sKey.Length==63 && sKey.Substring(60,3)=="000")
				return true;
			else
				return false;

		}
        public void goStart()
        {
            this.oCustomer.dsReadFld(this.channel, "", 0, "", ref arrValues);
        }
        public bool RemoveRecord(String Seq)
        {
            if (Seq == "000")
                this.sKey = this.Header.Teacher.PadRight(30, ' ') + this.Header.Student.PadRight(30, ' ') + "000";
            else
                this.sKey = this.Detail.Teacher.PadRight(30, ' ') + this.Detail.Student.PadRight(30, ' ') + Seq;

            int err = oCustomer.dsRemoveRec(this.channel, this.sKey);
            if (err == 11)
                return false;
            else
                return true;

        }
        public bool delete_log()
        {


            String Record = new string(' ', 200);
            //oCustomer.dsReadFld(cust_channel,cust_sKey,0,"id,flag,company_id",ref arrCustomers);
            arrCustomers.SetValue("3", 1);

            oCustomer.dsExtractRec(cust_channel, cust_sKey, 0, ref Record);
            //oCustomer.dsExtractFld(cust_channel,cust_sKey,0,"id,flag,company_id",ref arrCustomers);

            /*int Update = oCustomer.dsWriteFld(cust_channel,cust_sKey,Record,"id,flag,company_id",ref arrCustomers);
            if (Update==13)
                MessageBox.Show("It couldn't update the file (log)");
            */
            int err = oCustomer.dsRemoveRec(cust_channel, cust_sKey);

            if (err != -1)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
            else
                return true;

        }
        public void Close()
        {
            // Closing connections
            oCustomer.dsClose(cust_channel);
            oCustomer.dsDisconnect();
            // Closing connections

            oMySql.Close();
            return;

        }
        public bool same_order()
        {
            oCustomer.dsGetKey(channel, ref sKey1);
            if (sKey1 == null)
                return false;

            if (sKey.Substring(0, 59) == sKey1.Substring(0, 59))
                return true;
            else
                return false;
        }
        public void close_orders()
        {
            oCustomer.dsClose(channel);
        }
        public void SetKey(String str)
        {
            this.sKey = str;
            return;
        }
        public bool write_header_order()
        {

            int err = 0;
            String Record = new string(' ', 200);
            System.Array arrDetail = new System.String[13];

            oCustomer.dsTmpl(channel, "teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),no_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:,phone:c(10)"); //final field ascterisc relevant

            this.Header.CustomerID = this.sCustomerID;
            this.Header.CompanyID = this.sCompanyID;

            arrDetail.SetValue(this.Header.Teacher.PadRight(30, ' '), 0);
            arrDetail.SetValue(this.Header.Student.PadRight(30, ' '), 1);
            arrDetail.SetValue(this.Header.Type, 2);
            arrDetail.SetValue(this.Header.Prize, 3);
            arrDetail.SetValue(this.Header.No_Items, 4);
            arrDetail.SetValue(this.Header.Retail, 5);
            arrDetail.SetValue(this.Header.Collected, 6);
            arrDetail.SetValue(this.Header.Tax, 7);
            arrDetail.SetValue(this.Header.Printed, 8);
            arrDetail.SetValue(this.Header.Disc_Printed, 9);
            arrDetail.SetValue(this.Header.Box, 10);
            arrDetail.SetValue(this.Header.Date, 11);
            arrDetail.SetValue(this.Header.Phone, 12);

            this.sKey = arrDetail.GetValue(0).ToString() + arrDetail.GetValue(1).ToString() + "000";
            err = oCustomer.dsExtractRec(this.channel, this.sKey, 0, ref Record);
            if (err != -1)
            {
                if (err == 11)
                    Record = "";
                else
                {
                    MessageBox.Show(err.ToString());
                    return false;
                }

            }

            err = oCustomer.dsWriteFld(this.channel, this.sKey, Record, "teacher,student,type,prize,no_items,retail,collected,tax,printed,disc_printed,box,entry_date,phone", ref arrDetail);
            if (err != -1)
            {
                MessageBox.Show("err=" + err.ToString() + "  Lenght: " + Record.Length.ToString());
                return false;
            }
            return true;
        }
        public void read_header_order()
        {
            int err = 0;
            do
            {
                //Attach Detail fields template
                oCustomer.dsTmpl(channel, "teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),nro_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:,phone:c(10*)");
                err = oCustomer.dsReadFldNext(channel, "teacher,student,type,prize,nro_items,retail,collected,tax,printed,entry_date,phone", ref sKey, ref arrValues);
            }
            while (err == 0);

            arrValues.SetValue(cv_string(arrValues.GetValue(1).ToString()), 1);
            arrValues.SetValue(cv_string(arrValues.GetValue(2).ToString()), 2);

            this.Header.CustomerID = this.sCustomerID;
            this.Header.CompanyID = this.sCompanyID;
            this.Header.Teacher = arrValues.GetValue(0).ToString();
            this.Header.Student = arrValues.GetValue(1).ToString();
            this.Header.Type = arrValues.GetValue(2).ToString();
            this.Header.Prize = arrValues.GetValue(3).ToString();
            this.Header.No_Items = arrValues.GetValue(4).ToString();
            this.Header.Retail = arrValues.GetValue(5).ToString();
            this.Header.Collected = arrValues.GetValue(6).ToString();
            this.Header.Tax = arrValues.GetValue(7).ToString();
            this.Header.Printed = arrValues.GetValue(8).ToString();
            //	this.Header.Disc_Printed = arrValues.GetValue(9).ToString();
            //	this.Header.Box = arrValues.GetValue(10).ToString();
            this.Header.Date = this.cv_date(arrValues.GetValue(9).ToString());
            this.Header.Phone = arrValues.GetValue(10).ToString();


            //sKey1 = sKey;
            return;
        }
        public bool write_detail_order()
        {
            String Record = new string(' ', 200);
            System.Array arrDetail = new System.String[7];

            //Attach header fields template
            oCustomer.dsTmpl(channel, "teacher:c(30),student:c(30*),type:c(3*),item:c(10*),no_items:n(10*),tax:n(10*),no_invoiced:n(10)");

            arrDetail.SetValue(this.Detail.Teacher.PadRight(30, ' '), 0);
            arrDetail.SetValue(this.Detail.Student.PadRight(30, ' '), 1);
            arrDetail.SetValue(this.Detail.Seq, 2);
            arrDetail.SetValue(this.Detail.Item, 3);
            arrDetail.SetValue(this.Detail.No_Items, 4);
            arrDetail.SetValue(this.Detail.Tax, 5);
            arrDetail.SetValue(this.Detail.No_Invoiced, 6);

            this.sKey = arrDetail.GetValue(0).ToString() + arrDetail.GetValue(1).ToString() + arrDetail.GetValue(2).ToString();
            int err = oCustomer.dsExtractRec(channel, sKey, 0, ref Record);
            if (err != -1)
            {
                if (err == 11)
                    Record = "";
                else
                {
                    MessageBox.Show(err.ToString());
                    return false;
                }

            }
            
            err = oCustomer.dsWriteFld(channel, sKey, Record, "teacher,student,type,item,no_items,tax,no_invoiced", ref arrDetail);
            if (err != -1)
            {
                MessageBox.Show("err=" + err.ToString() + "  Lenght: " + Record.Length.ToString());
                return false;
            }


            return true;
        }
        public void read_detail_order()
        {
            int err = 0;
            do
            {
                //Attach header fields template
                oCustomer.dsTmpl(channel, "teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10*)");
                err = oCustomer.dsReadFldNext(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);

            }
            while (err == 0);

            arrValues.SetValue(cv_string(arrValues.GetValue(1).ToString()), 1);
            arrValues.SetValue(cv_string(arrValues.GetValue(2).ToString()), 2);

            this.Detail.CustomerID = this.sCustomerID;
            this.Detail.CompanyID = this.sCompanyID;
            this.Detail.Teacher = arrValues.GetValue(0).ToString();
            this.Detail.Student = arrValues.GetValue(1).ToString();
            this.Detail.Seq = arrValues.GetValue(2).ToString();
            this.Detail.Item = arrValues.GetValue(3).ToString();
            this.Detail.No_Items = arrValues.GetValue(4).ToString();
            this.Detail.Tax = arrValues.GetValue(5).ToString();
            this.Detail.No_Invoiced = arrValues.GetValue(6).ToString();
            return;
        }
        public String read_record()
        {
            String Record = new string(' ', 200);
            int err = oCustomer.dsReadRec(channel, sKey, 0, ref Record);
            if (err != -1)
            {
                if (err == 11)
                    return "";
                else
                {
                    MessageBox.Show(err.ToString());
                    return "";
                }
            }
            return Record;
        }
#endregion
#region Sql Related Functions
        public void ConnectSql()
        {

        }
        public void delete_from_sql()
        {
            //Delete Customer Orders
            Sql = "Delete from Orders where CompanyID='" + sCompanyID + "' And CustomerID = '" + sCustomerID + "'";
            oMySql.exec_sql(Sql);
            Sql = "Delete from OrderDetail where CompanyID='" + sCompanyID + "' And CustomerID = '" + sCustomerID + "'";
            oMySql.exec_sql(Sql);
            return;
        }
        public void insert_header_sql()
		{
			Sql = String.Format("Insert into Orders (CustomerID, Teacher, Student, Prize, Nro_Items, Retail,Collected, Tax, Printed,Date,Phone,CompanyID,Reserved )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','0')",this.Header.CustomerID,
				this.Header.Teacher,this.Header.Student,this.Header.Prize,this.Header.No_Items,this.Header.Retail,this.Header.Collected,this.Header.Tax,this.Header.Printed,this.Header.Date,this.Header.Phone,this.Header.CompanyID);
			OrderID = oMySql.exec_sql_id(Sql);	
			return;
			
		}
		public void insert_detail_sql()
		{
			Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID, Reserved, OrderID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','0','{9}')",
				this.Detail.Teacher,this.Detail.Student,this.Detail.Seq,this.Detail.Item,this.Detail.No_Items,this.Detail.Tax,this.Detail.No_Invoiced,this.Detail.CustomerID,this.Detail.CompanyID,OrderID);
			this.inserted_rows += oMySql.exec_sql_afected(Sql);	
			//	oCustomer.dsGetKey(channel,ref sKey1);
		}
		public bool if_exist_header_sql()
		{
			
            DataRow row = oMySql.GetDataRow("Select count(*),ID from Orders Where CustomerID='"+this.Header.CustomerID+"' And CompanyID='"+this.Header.CompanyID+"' And Teacher=\""+this.Header.Teacher+"\" And Student=\""+this.Header.Student+"\" Group By ID","Header");
            if (row == null)
                return false;
            else
            {
                OrderID = (Int32) row["ID"];
                return true;
            }

            
          /*  if (oMySql.exec_sql_no("Select count(*) from Orders Where CustomerID='"+this.Header.CustomerID+"' And CompanyID='"+this.Header.CompanyID+"' And Teacher=\""+this.Header.Teacher+"\" And Student=\""+this.Header.Student+"\"")==0)
			{
				return false;
			}
			return true;*/
		}
		public bool if_exist_detail_sql()
		{
		//	if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where CustomerID='"+this.Detail.CustomerID+"' And CompanyID='"+this.Detail.CompanyID+"' And Teacher=\""+this.Detail.Teacher+"\" And Student=\""+this.Detail.Student+"\" And ProductID=\""+this.Detail.Item+"\"")==0)

            if (oMySql.exec_sql_no("Select count(*) from OrderDetail Where OrderID='" + this.OrderID + "' And ProductID=\"" + this.Detail.Item + "\"") == 0)
			{
				return false;
			}
			return true;
		}
		public void update_header_sql()
		{
			Sql = String.Format("Update Orders Set Prize='{0}', Nro_Items='{1}', Retail='{2}',Collected='{3}', Tax='{4}', Printed='{5}',Date={6},Phone='{7}',Reserved='0'"+" Where CompanyID=\""+this.Header.CompanyID+"\""+" And CustomerID=\""+this.Header.CustomerID+"\""+" And Teacher=\""+this.Header.Teacher+"\""+" And Student=\""+this.Header.Student+"\"",
				this.Header.Prize,this.Header.No_Items,this.Header.Retail,this.Header.Collected,this.Header.Tax,this.Header.Printed,this.Header.Date,this.Header.Phone);
			oMySql.exec_sql(Sql);	
			return;

		}
        public void save_detail_sql()
        {
            if (if_exist_detail_sql())
                update_detail_sql();
            else
                insert_detail_sql();
        }
        public void save_header_sql()
        {
            if (if_exist_header_sql())
                update_header_sql();
            else
                insert_header_sql();
        }
		public void set_on_order_flag()
		{
			Sql = String.Format("Update Orders Set Reserved='1'"+" Where CompanyID=\""+this.sCompanyID+"\""+" And CustomerID=\""+this.sCustomerID+"\"");
			oMySql.exec_sql(Sql);	
			return;
		}
		public void set_on_detail_flag()
		{
			Sql = String.Format("Update OrderDetail Set Reserved='1'"+" Where CompanyID=\""+this.sCompanyID+"\""+" And CustomerID=\""+this.sCustomerID+"\"");
			oMySql.exec_sql(Sql);	
			return;
		}
		public void update_detail_sql()
		{
			//Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID='{5}' Where CompanyID=\""+this.Header.CompanyID+"\""+" And CustomerID=\""+this.Header.CustomerID+"\""+" And Teacher=\""+this.Header.Teacher+"\""+" And Student=\""+this.Header.Student+"\" And ProductID=\""+this.Detail.Item+"\"",
			//	this.Detail.Seq,this.Detail.Item,this.Detail.No_Items,this.Detail.Tax,this.Detail.No_Invoiced,this.OrderID);
            
            Sql = String.Format("Update OrderDetail  Set  Seq=\"{0}\", ProductID='{1}', Quantity='{2}', Tax='{3}', QuantityInvoiced='{4}', Reserved='0', OrderID='{5}' Where OrderID=\""+this.OrderID+"\" And ProductID=\""+this.Detail.Item+"\"",
            	this.Detail.Seq,this.Detail.Item,this.Detail.No_Items,this.Detail.Tax,this.Detail.No_Invoiced,this.OrderID);
            //MessageBox.Show(Sql);
			this.updated_rows +=oMySql.exec_sql_afected(Sql);	

			//oCustomer.dsGetKey(channel,ref sKey1);
		}
		public void delete_detail_flag_on()
		{
			Sql = String.Format("Delete from OrderDetail Where Reserved='1'"+" And  CompanyID=\""+this.sLog.CompanyID+"\""+" And CustomerID=\""+this.sLog.CustomerID+"\""); //+" And Teacher=\""+this.Header.Teacher+"\""+" And Student=\""+this.Header.Student+"\"");
			this.deleted_rows += oMySql.exec_sql_afected(Sql);	
			return;
		}
		public void delete_order_flag_on()
		{
			Sql = String.Format("Delete from Orders Where Reserved='1'"+" And  CompanyID=\""+this.sLog.CompanyID+"\""+" And CustomerID=\""+this.sLog.CustomerID+"\"");
			oMySql.exec_sql(Sql);	
			return;
		}
#endregion

#region General Functions

        private String cv_string(String sStr)
		{
		
			//sStr = sStr.Replace("'","\'");
			sStr = sStr.Replace("\"","'");
			sStr = sStr.Replace("\\","\\\\");
			return(sStr);
		}

		private String cv_date(String sStr)
		{
			
			if (sStr.Length > 5)
			{	
				DateTime d_ship;
				d_ship =new DateTime(2000+Convert.ToInt16(sStr.Substring(6,2)),Convert.ToInt16(sStr.Substring(0,2)),Convert.ToInt16(sStr.Substring(3,2)));
				sStr = "'"+d_ship.ToString("yyyy-MM-dd")+"'";
			}
			else
				sStr = "null";
			
			return sStr;

        }

#endregion

    }

}
