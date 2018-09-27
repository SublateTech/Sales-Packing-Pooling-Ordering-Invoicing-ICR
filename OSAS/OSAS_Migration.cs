using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using dSERVE2;
using Signature.Data;

namespace Signature.OSAS
{
	
	public class Migration
	{
		private String dServe="192.168.254.02";
		
		public void copy_rep_charges(String CompanyID)
		{
			//MySql oMySql_d = new  MySQL("192.168.254.56", "signatv9_OSAS") ; // Sql Open Target
			MySQL oMySql_d = new  MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open Target
			MySQL oMySql_s = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open Source

			DataTable db_reps_s = new DataTable();
			db_reps_s = oMySql_s.get_rep_charges(CompanyID,"").Tables[0];
			
			//Deleting the whole company
			String Sql = new string(' ',200);
			Sql= "Delete from rep_charges  Where CompanyID='"+CompanyID+"'";	
			oMySql_d.exec_sql(Sql);
			
			foreach (DataRow row_s in db_reps_s.Rows)
			{
				String Date =row_s["Date"].ToString()==""?"null":"'"+row_s["Date"]+"'";
				String Charge =row_s["Charge"].ToString()==""?"null":"'"+row_s["Charge"]+"'";

				Sql = String.Format("Insert into rep_charges (CompanyID,RepID, Date, Description, Description_1, Description_2, Charged)  Values ('{0}','{1}',{2},\"{3}\",\"{4}\",\"{5}\",{6})",
					CompanyID,row_s["RepID"],Date,row_s["Description"],row_s["Description_1"],row_s["Description_2"],Charge );
				oMySql_d.exec_sql(Sql);

			}

		}
		public void migrate_prizes(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
				MessageBox.Show("Not Connected!!");
			
			
			if (oCustomer.dsOpen("INPMAST."+sCompanyID,ref channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(channel,"id:c(10),name:c(30),type_break:c(10*),level:n(10*)");

			
			//Deleting our file from SQL
            
			String Sql = new string(' ',200);
			Sql= "Delete from Prizes Where CompanyID='"+sCompanyID+"'";
			oMySql.exec_sql(Sql);
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			while (oCustomer.dsReadFldNext(channel, "id,name,type_break,level", ref sKey, ref arrValues)!=2 )
			{
				//INSERT INTO %s (customer, order_date) VALUES (%d, NOW())
				//MessageBox.Show(arrValues.GetValue(0).ToString());
				
				Sql = String.Format("Insert into Prizes (PrizeID, Description, Prize_Break , Levels, CompanyID)  Values ('{0}','{1}','{2}','{3}','{4}')",
					arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),sCompanyID);

				
				
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
		public void migrate_taxes_by_product(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
				MessageBox.Show("Not Connected!!");
			
			
			if (oCustomer.dsOpen("INTAX."+sCompanyID,ref channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(channel,"id:c(10),space:c(10),state:c(2),space_1:c(8),taxable:c(1)");

			
			//Deleting our file from SQL
            
			String Sql = new string(' ',200);
			Sql= "Delete from tax_by_product Where CompanyID='"+sCompanyID+"'";
			oMySql.exec_sql(Sql);
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			while (oCustomer.dsReadFldNext(channel, "id,state,taxable", ref sKey, ref arrValues)!=2 )
			{
				
				Sql = String.Format("Insert into tax_by_product (CompanyID, ProductID, StateID,Taxable)  Values ('{0}','{1}','{2}','{3}')",
					sCompanyID,arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2));

								
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void migrate_customers(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[100];
			int err = 0;
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVEClass oCustomer = new dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}
			
			
			if ((err=oCustomer.dsOpen("ARMAST."+sCompanyID,ref channel))== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			if (err==13 || err==12  || err==11)
			{
				MessageBox.Show("Couldn't open files,Please Contact to the server administrator error:"+err.ToString());
				return;
			}


			
			String strTemp = new string(' ',500);

			strTemp = "id:c(10),name:c(30),Address1:c(30),Short:c(30),";
			strTemp += "City:c(15),State:c(2),Zip:c(12),Page:c(10),Grid:c(10),";
			strTemp += "ChairP:c(30),Phone:c(10),Fax:c(10),Rep:c(10),SignedNote:c(30),";
			strTemp += "StartNote:c(30),EndNote:c(30),PickUpNote:c(30),DeliveryNote:c(30),";
			strTemp += "Brochure:c(10),Prize:c(10),Reserved_1:c(20),Tax:c(1),HeadPhone:c(10),";
			strTemp += "Reserved_2:c(29),County:c(6),Reserved_3:c(54),ShipNote:c(30),Reserved_4:c(15),";
			strTemp += "Reserved_5:c(5),Brochure_2:c(10),Space_1:c(90*),AmountDue:n(10*),d_signed:n(10*):date=jul:,"; //n_0 - n_1
			strTemp += "d_start:n(10*):date=jul:,d_end:n(10*):date=jul:,d_pickup:n(10*):date=jul:,d_delivery:n(10*):date=jul:,Signed:n(10*),n_units:n(10*),"; //n_2 - n_7
			strTemp += "n_sellers_1:n(10*),Retail_1:n(10*),Profit:n(10*),CODE1:n(10*),CODE2:n(10*),SalesTaxAmount:n(10*),"; //n_8 - n_13
			strTemp += "Payments:n(10*),n_15:n(10*),n_16:n(10*),n_17:n(10*),n_sellers:n(10*),n_items:n(10*),"; //n_14 - n_19
			strTemp += "Retail:n(10*),d_ship:n(10*):date=jul:,Pallets:n(10*),n_23:n(10*),LastInvoice:n(10*),PreviusRetail:n(10*)"; //n_20

			//Attach fields template
			oCustomer.dsTmpl(channel, strTemp);
	

			strTemp = "id,name,Address1,Short,";
			strTemp += "City,State,Zip,Page,Grid,";
			strTemp += "ChairP,Phone,Fax,Rep,SignedNote,";
			strTemp += "StartNote,EndNote,PickUpNote,DeliveryNote,";
			strTemp += "Brochure,Prize,Reserved_1,Tax,HeadPhone,";
			strTemp += "Reserved_2,County,Reserved_3,ShipNote,Reserved_4,";
			strTemp += "Reserved_5,Brochure_2";



			
			//Deleting our file from SQL
            String Sql = new string(' ',500);
			//Sql = new String(' ',200);
			Sql= "Delete from Customer Where CompanyID='"+sCompanyID+"'";
			oMySql.exec_sql(Sql);
			
			
			//Exporting Process
			//String  ExportID= new string(' ',20); 
			//String sLastKey=new string(' ',10);
			//String sFirstKey=new string(' ',10);
			//oCustomer.dsGetKeyFirst(channel,ref sFirstKey);
			//oCustomer.dsGetKeyLast(channel,ref sLastKey);
			//MessageBox.Show(sFirstKey+" "+sLastKey);
			
			//oCustomer.dsExportStart(channel,"XML",0,sFirstKey,sLastKey,"id,Name,Address1,City,State,Zip,ChairP,SignedNote,StartNote,Rep,Brochure,Profit,Signed,Brochure_2,Phone,Fax,d_start,d_end,d_signed,d_pickup,d_delivery,d_ship",ref ExportID);

		/*	oCustomer.dsExport(channel,
								ExportFormatEnum.efXML,
								0,
								sFirstKey,
								sLastKey,
								"id,Name,Address1,City,State,Zip,ChairP,SignedNote,StartNote,Rep,Brochure,Profit,Signed,Brochure_2,Phone,Fax,d_start,d_end,d_signed,d_pickup,d_delivery,d_ship",
								"OSAS.xml",
								false);

			return;
		*/	
			/*String code =" ";
			String Message = new string(' ',100);
			int MaxRecs = 0, ReadRecs=0;*/
			
			/*while (code!="9" && code!="e")
			{
				oCustomer.dsExportStatus(ExportID,ref code,ref Message,ref MaxRecs,ref ReadRecs);
				MessageBox.Show(Message);
			}*/
			
			
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			
			while ((err=oCustomer.dsReadFldNext(channel,"id,Name,Address1,City,State,Zip,ChairP,SignedNote,StartNote,Rep,Brochure,Profit,Signed,Brochure_2,Phone,Fax,d_start,d_end,d_signed,d_pickup,d_delivery,d_ship,n_items,n_sellers,Retail,AmountDue,Payments,n_units,HeadPhone,Prize", ref sKey, ref arrValues))!=2 )
			{
				
				
				if (err==0)
				{					
					
					//this.oReps.st.Text = "The record next to "+sKey+" is in use.";
					continue;
				}
				else if (err==13 || err==12  || err==11)
				{
					MessageBox.Show("Please Contact to the server administrator error:"+err.ToString());
					return;
				}
				else 
				{
					//this.oReps.st.Text = sKey;
				}
							
				
				//MessageBox.Show(arrValues.GetValue(16).ToString()+"   "+d_start.ToShortDateString());
				Sql = String.Format("Insert into Customer (CustomerID, Name, Address , City, State, ZipCode,ChairPerson, eMail,RepID,BrochureID,ProfitPercent, Signed,BrochureID_2,PhoneNumber,FaxNumber,CompanyID,StartDate,EndDate,SignedDate,PickUpDate,DeliveryDate,ShipDate,NoItems,NoSellers,Retail,AmountDue,Payments,NoUnits,HeadPhone,PrizeID)  Values ('{0}',\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}{8}\",'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17},{18},{19},{20},{21},{22},{23},{24},'{25}','{26}','{27}','{28}','{29}','{30}')",
					arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),arrValues.GetValue(7),arrValues.GetValue(8),arrValues.GetValue(9),arrValues.GetValue(10),arrValues.GetValue(11),arrValues.GetValue(12),arrValues.GetValue(13),arrValues.GetValue(14),arrValues.GetValue(15),sCompanyID,this.cv_date(arrValues.GetValue(16).ToString()),this.cv_date(arrValues.GetValue(17).ToString()),this.cv_date(arrValues.GetValue(18).ToString()),this.cv_date(arrValues.GetValue(19).ToString()),this.cv_date(arrValues.GetValue(20).ToString()),this.cv_date(arrValues.GetValue(21).ToString()),arrValues.GetValue(22),arrValues.GetValue(23),arrValues.GetValue(24),arrValues.GetValue(25),arrValues.GetValue(26),arrValues.GetValue(27),arrValues.GetValue(28),arrValues.GetValue(29));
				
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        
        public void migrate_products(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[30];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			
			if (oCustomer.dsOpen("INMAST."+sCompanyID,ref channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(channel,"id:c(10),InvCode:c(10),name:c(30),Vendor:c(10),Broch_Item:c(1),BarCode:c(12),Reserved_1:c(15),QtyOnHand:n(10*),QtyCommited:n(10*),QtySold:n(10*),QtySold1:n(10*),Cost:n(10*),Price:n(10*),Fin:n(10)");

			
			//Deleting our file from SQL
            
			String Sql = new string(' ',200);
			Sql= "Delete from Product Where CompanyID='"+sCompanyID+"'";
			oMySql.exec_sql(Sql);
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			int err=0;
			while ((err=oCustomer.dsReadFldNext(channel, "id,name,InvCode,QtyOnHand,Price,Cost", ref sKey, ref arrValues))!=2 )
			{
				//this.oReps.Focus();
				if (err==0)
				{					
					//this.oReps.st.Update();
					//this.oReps.st.Text = "The record next to "+sKey+" is in use.";
					
					continue;
				}
				else 
				{	//this.oReps.st.Update();
					//this.oReps.st.Text = sKey;
					
				
				}
				
				try
				{
					arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);
				}
				catch ( System.Exception  ex) 
				{
				
					MessageBox.Show(ex.Message);
				
				}


				
				Sql = String.Format("Insert into Product (ProductID, Description, InvCode, QtyStock, Price, Cost, CompanyID)  Values (\"{0}\",\"{1}\",'{2}','{3}','{4}','{5}','{6}')",
					arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),sCompanyID);

				//MessageBox.Show(arrValues.GetValue(0).ToString());
				
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void migrate_orders(String sCompanyID, String sCustomerID)
		{
			short channel=10;
			string sKey=new string(' ',100);
			string sKey1=new string(' ',100);
			System.Array arrValues= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			
			
			DataTable db_cust = new DataTable();
			db_cust = oMySql.get_customers(sCompanyID,sCustomerID);
			String Sql = "";

			if (sCustomerID=="*")
			{
				Sql= "Delete from Orders  Where CompanyID='"+sCompanyID+"'";	// where CustomerID = '"+sFile+"'";
				oMySql.exec_sql(Sql);

				Sql= "Delete from OrderDetail Where CompanyID='"+sCompanyID+"'";	// where CustomerID = '"+sFile+"'";
				oMySql.exec_sql(Sql);
			} 
			else
			{
				Sql= "Delete from Orders where CompanyID='"+sCompanyID+"' And CustomerID = '"+sCustomerID+"'";
				oMySql.exec_sql(Sql);

				Sql= "Delete from OrderDetail where CompanyID='"+sCompanyID+"' And CustomerID = '"+sCustomerID+"'";
				oMySql.exec_sql(Sql);
			}
			

			frmOrderStatus oStatus =new frmOrderStatus();
			oStatus.Show();
			

			String sFile= new string(' ',8);
			foreach (DataRow row in db_cust.Rows)
			{
				//MessageBox.Show(row[0].ToString());
				sFile = row[0].ToString();
				
				//if (sFile!="1053")
				//	continue;
				
				if (oCustomer.dsOpen(sFile,ref channel)== 10)  //Open our file to migrate
					MessageBox.Show("This file wasn't open!!!");
				else
				{
					//Start at first record
					oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
					int err=0;
            		
					do 
					{
						oCustomer.dsGetKey(channel,ref sKey);
						if (sKey == null)
							break;

						
						
						//MessageBox.Show(sKey.Length.ToString());

						if (sKey.Length==63 && sKey.Substring(60,3)=="000")
						{		
							
							//Attach Detail fields template
							oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),nro_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:,phone:c(10*)");
							err = oCustomer.dsReadFldNext(channel, "teacher,student,type,prize,nro_items,retail,collected,tax,printed,entry_date,phone", ref sKey, ref arrValues);
							
							if (err==0)
							{					
								oStatus.st.Text = "The record next to "+sKey+" is in use.";
								oStatus.st.Update();
								continue;
							}
							
							arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);
							arrValues.SetValue(cv_string( arrValues.GetValue(2).ToString()),2);				
							
							Sql = String.Format("Insert into Orders (CustomerID, Teacher, Student, Prize, Nro_Items, Retail,Collected, Tax, Printed,Date,Phone,CompanyID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}')",sFile,
								arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),arrValues.GetValue(7),arrValues.GetValue(8),this.cv_date(arrValues.GetValue(9).ToString()),arrValues.GetValue(10),sCompanyID);
							
							oMySql.exec_sql(Sql);	
													
							

							sKey1 = sKey;
							
						
							while (sKey.Substring(0,59) == sKey1.Substring(0,59))
							{
								
								
								//ORDER$,DETAIL$,ITEM$,QTY,LINETAX,INVOICED,LINEBRO$
								//MessageBox.Show(sKey+Convert.ToString(sKey.Length));
								
								//Attach header fields template
								oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10*)");
								//Read record
								err = oCustomer.dsReadFldNext(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);
								
								if (err==0)
								{					
					
									oStatus.st.Text = "The record next to "+sKey1+" is in use.";
									oStatus.st.Update();
									continue;
								}
								oStatus.txtCompanyID.Text = sCompanyID;
								oStatus.txtCustomerID.Text = sFile;
								oStatus.txtTeacher.Text = arrValues.GetValue(0).ToString();
								oStatus.txtStudent.Text = arrValues.GetValue(1).ToString();
								oStatus.txtProduct.Text = arrValues.GetValue(3).ToString();
								oStatus.Update();
																
								//Sql String 
								arrValues.SetValue(cv_string( arrValues.GetValue(0).ToString()),0);
								arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);				

								Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}')",
									arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),sFile,sCompanyID);
								oMySql.exec_sql(Sql);	
								oCustomer.dsGetKey(channel,ref sKey1);

							
								if (sKey1 == null)
									break;

								

							}
						}
						else
						{
							
							//Attach header fields template
							oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10*)");
							//Read record
							err = oCustomer.dsReadFldNext(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);
							
							if (err==0)
							{					
					
								oStatus.st.Text = "The record next to "+sKey1+" is in use.";
								oStatus.st.Update();
								continue;
							}
							
							//Sql String 
							Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID,Comment )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
								arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),sFile,sCompanyID,"Detail Without Header");							
							oMySql.exec_sql(Sql);	
							
						}
			
					}while (err!=2);

					oCustomer.dsClose(channel);
				}

			}
			oStatus.Dispose();
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void migrate_reps(String sCompanyID, bool Update)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			
			if (oCustomer.dsOpen("ARREP."+sCompanyID,ref channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(channel,"id:c(10),name:c(30),address:c(30),reserved:c(129),phone:c(10),fax:c(10)");

			
			//Deleting our file from SQL
            String Sql = new string(' ',200);

			if (!Update)
			{
				Sql= "Delete from Rep Where CompanyID='"+sCompanyID+"'";
				oMySql.exec_sql(Sql);
			}
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			int err=0;
			while ((err=oCustomer.dsReadFldNext(channel, "id,name,address,phone,fax", ref sKey, ref arrValues))!=2 )

			{
				if (arrValues.GetValue(0).ToString().Trim() == "348")
				{
					//MessageBox.Show("Ok");
					continue;
				}
				
				//this.oReps.Focus();
				if (err==0)
				{					
					
				//	this.oReps.st.Text = "The record next to "+sKey+" is in use.";
				//	this.oReps.st.Update();
					continue;
				}
				else 
				{
				//	this.oReps.st.Text = sKey;
				//	this.oReps.st.Update();
				}
				//INSERT INTO %s (customer, order_date) VALUES (%d, NOW())
				
				int i=0;
				if ((i=oMySql.exec_sql_no("Select count(*) from Rep Where RepID='"+arrValues.GetValue(0)+"' And CompanyID='"+sCompanyID+"'"))==0)
				{
					Sql = String.Format("Insert into Rep (RepID, Name,PhoneNumber,FaxNumber,CompanyID)  Values ('{0}','{1}','{2}','{3}','{4}')",
						arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),sCompanyID);
				}
				else
				{
					Sql = String.Format("Update Rep Set RepID='{0}', Name='{1}',PhoneNumber='{2}',FaxNumber='{3}',CompanyID='{4}' Where RepID='{5}' And CompanyID='{6}'",
						arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),sCompanyID,arrValues.GetValue(0),sCompanyID);
				}

					
					oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void migrate_companies()
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			
			if (oCustomer.dsOpen("OSCOMP",ref channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(channel,"id:c(3*),name:c(30*),address1:c(30*),address2:c(30*)");

			
			//Deleting our file from SQL
            
			String Sql= "Delete from Company" ;
			oMySql.exec_sql(Sql);
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			while (oCustomer.dsReadFldNext(channel, "id,name,address1,address2", ref sKey, ref arrValues)!=2 )
			{
				//INSERT INTO %s (customer, order_date) VALUES (%d, NOW())
				
				Sql = String.Format("Insert into Company (CompanyID, Name, Address, Address_2)  Values ('{0}','{1}','{2}','{3}')",
					arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3));

				//MessageBox.Show(arrValues.GetValue(0).ToString()+arrValues.GetValue(1).ToString());
				
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void migrate_boxes()
        {
            

            MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open


            File oFile = new File();

            String Sql = "Delete from boxsize";
            oMySql.exec_sql(Sql);

                       
            oFile.Open("INBOXSZ","");
            
            while (!oFile.isEOF())
            {
                oFile.ReadNext("BoxNumber,Length,Width,Height");
                MessageBox.Show(oFile.GetValue(0) + "--" + oFile.GetValue(1) + "--" + oFile.GetValue(2) + "--" + oFile.GetValue(3) );
                Sql = String.Format("Insert into boxsize (BoxID, Length, Width, Height)  Values ('{0}','{1}','{2}','{3}')",
                oFile.GetValue(0), oFile.GetValue(1), oFile.GetValue(2), oFile.GetValue(3));
                oMySql.exec_sql(Sql);

            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void migrate_prize_detail(String sCompanyID)
        {

            MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open


            File oFile = new File();

            String Sql = "Delete from PrizeDetail Where CompanyID='"+sCompanyID+"'";
            oMySql.exec_sql(Sql);


            oFile.Open("INPRIZ", sCompanyID);

            while (!oFile.isEOF())
            {
                oFile.ReadNext("brochure_id,product_id,break_level,break_level_d");
                //MessageBox.Show(oFile.GetValue(0) + "--" + oFile.GetValue(1) + "--" + oFile.GetValue(2) + "--" + oFile.GetValue(3));
                if (oFile.GetValue(1) != "      HEAD")
                {
                    Sql = String.Format("Insert into PrizeDetail (PrizeID, ProductID, BreakLevel, BreakLevelDollars,CompanyID)  Values ('{0}','{1}','{2}','{3}','{4}')",
                    oFile.GetValue(0), oFile.GetValue(1), oFile.GetValue(2), oFile.GetValue(3), sCompanyID);
                    oMySql.exec_sql(Sql);
                }

            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void migrate_everything(String sCompanyID)
		{
		    			
		 	migrate_prizes(sCompanyID);
			migrate_customers(sCompanyID);
			migrate_brochures(sCompanyID); 
			migrate_products(sCompanyID);
			migrate_orders(sCompanyID,"*");
			migrate_reps(sCompanyID,true); 
			migrate_companies();
			
		

		}
        
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
		
        public void migrate_OSAS_orders()
		{
			String sCustomerID="";  
			String sCompanyID="";
			String Sql = "";
			
			short channel=10;
			short cust_channel=20;
			string sKey=new string(' ',100);
			string sKey1=new string(' ',100);
			string cust_sKey=new string(' ',100);
			System.Array arrValues= new System.String[20];
			System.Array arrCustomers= new System.String[20];
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			if (oCustomer.dsOpen("WSCUST",ref cust_channel)== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			
			
			//Attach fields template
			oCustomer.dsTmpl(cust_channel,"id:c(10*),flag:c(1*),company_id:c(3*)");

			//Start at first record
			oCustomer.dsReadFld(cust_channel,"", 0,"",ref arrCustomers);
            	
			String sFile= new string(' ',8);

			frmOrderStatus oStatus =new frmOrderStatus();
			

			
			
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			int err=0;
			while ((err=oCustomer.dsReadFldNext(cust_channel, "id,flag,company_id", ref cust_sKey, ref arrCustomers))!=2 )
			{	            
				if (err==0)
				{					
					oStatus.st.Text = "The record next to "+cust_sKey+" is in use.";
					oStatus.st.Update();
					continue;
				}
					
				
				if(arrCustomers.GetValue(1).ToString()=="1")
				{
					oStatus.Show();
					sCustomerID=arrCustomers.GetValue(0).ToString();
					sCompanyID=arrCustomers.GetValue(2).ToString();
					//	MessageBox.Show(arrCustomers.GetValue(1).ToString());

					//Delete Customer Orders
					Sql= "Delete from Orders where CompanyID='"+sCompanyID+"' And CustomerID = '"+sCustomerID+"'";
					oMySql.exec_sql(Sql);
					Sql= "Delete from OrderDetail where CompanyID='"+sCompanyID+"' And CustomerID = '"+sCustomerID+"'";
					oMySql.exec_sql(Sql);
					
					//Start Migrating
				
					//MessageBox.Show(row[0].ToString());
					sFile = sCustomerID;
				
					//if (sFile!="1053")
					//	continue;
				
					if (oCustomer.dsOpen(sFile,ref channel)== 10)  //Open our file to migrate
						MessageBox.Show("This file wasn't open!!!");
					else
					{
						//Start at first record
						oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
						err=0;
            		
						do 
						{
							oCustomer.dsGetKey(channel,ref sKey);
							if (sKey == null)
								break;

						
						
							//MessageBox.Show(sKey.Length.ToString());

							if (sKey.Length==63 && sKey.Substring(60,3)=="000")
							{		
							
								//Attach Detail fields template
								oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),nro_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:,phone:c(10*)");
								err = oCustomer.dsReadFldNext(channel, "teacher,student,type,prize,nro_items,retail,collected,tax,printed,entry_date,phone", ref sKey, ref arrValues);
							
								if (err==0)
								{					
									oStatus.st.Text = "The record next to "+sKey+" is in use.";
									oStatus.st.Update();
									continue;
								}
							
							
								arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);
								arrValues.SetValue(cv_string( arrValues.GetValue(2).ToString()),2);				
							
								Sql = String.Format("Insert into Orders (CustomerID, Teacher, Student, Prize, Nro_Items, Retail,Collected, Tax, Printed,Date,Phone,CompanyID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}')",sFile,
									arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),arrValues.GetValue(7),arrValues.GetValue(8),this.cv_date(arrValues.GetValue(9).ToString()),arrValues.GetValue(10),sCompanyID);
								oMySql.exec_sql(Sql);	
													

								sKey1 = sKey;
								while (sKey.Substring(0,59) == sKey1.Substring(0,59))
								{
																
									//ORDER$,DETAIL$,ITEM$,QTY,LINETAX,INVOICED,LINEBRO$
									//MessageBox.Show(sKey+Convert.ToString(sKey.Length));
								
									//Attach header fields template
									oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10*)");
									//Read record
									err = oCustomer.dsReadFldNext(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);
								
									if (err==0)
									{					
					
										oStatus.st.Text = "The record next to "+sKey1+" is in use.";
										oStatus.st.Update();
										continue;
									}
									oStatus.txtCompanyID.Text = sCompanyID;
									oStatus.txtCustomerID.Text = sFile;
									oStatus.txtTeacher.Text = arrValues.GetValue(0).ToString();
									oStatus.txtStudent.Text = arrValues.GetValue(1).ToString();
									oStatus.txtProduct.Text = arrValues.GetValue(3).ToString();
									oStatus.Update();
																
									//Sql String 
									arrValues.SetValue(cv_string( arrValues.GetValue(0).ToString()),0);
									arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);				

									Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}')",
										arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),sFile,sCompanyID);
									oMySql.exec_sql(Sql);	
									oCustomer.dsGetKey(channel,ref sKey1);

							
									if (sKey1 == null)
										break;

								

								}
							}
							else
							{
							
								//Attach header fields template
								oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10*)");
								//Read record
								err = oCustomer.dsReadFldNext(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);
							
								if (err==0)
								{					
					
									oStatus.st.Text = "The record next to "+sKey1+" is in use.";
									oStatus.st.Update();
									continue;
								}
							
								//Sql String 
								Sql = String.Format("Insert into OrderDetail (Teacher, Student, Seq, ProductID, Quantity, Tax, QuantityInvoiced, CustomerID, CompanyID,Comment )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
									arrValues.GetValue(0),arrValues.GetValue(1),arrValues.GetValue(2),arrValues.GetValue(3),arrValues.GetValue(4),arrValues.GetValue(5),arrValues.GetValue(6),sFile,sCompanyID,"Detail Without Header");							
								oMySql.exec_sql(Sql);	
							
							}
			
						}while (err!=2);

						oCustomer.dsClose(channel);
					}
			
				
					
					String Record = new string(' ',200);
					//oCustomer.dsReadFld(cust_channel,cust_sKey,0,"id,flag,company_id",ref arrCustomers);
					arrCustomers.SetValue("3",1);
					
					oCustomer.dsExtractRec(cust_channel,cust_sKey,0,ref Record);
					//oCustomer.dsExtractFld(cust_channel,cust_sKey,0,"id,flag,company_id",ref arrCustomers);
				
					int Update = oCustomer.dsWriteFld(cust_channel,cust_sKey,Record,"id,flag,company_id",ref arrCustomers);
					if (Update==13)
						MessageBox.Show("You need permissions to write a file");
				}
			}
			
			// Closing connections
			oCustomer.dsClose(cust_channel);
			oCustomer.dsDisconnect();
			oStatus.Dispose();
			// Closing connections
			
			oMySql.Close();

			return ;

		}
		public void update_products(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[30];
			//Deleting our file from SQL
			String Sql = new string(' ',500);
			int err=0;
		
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open

			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2

			
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			
			if ((err=oCustomer.dsOpen("INMAST."+sCompanyID,ref channel))== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			if (err==13 || err==12  || err==11)
			{
				MessageBox.Show("Couldn't open files,Please Contact to the server administrator error:"+err.ToString());
				return;
			}

			
			//Attach fields template
			oCustomer.dsTmpl(channel,FileTemplate.INMAST);
			
			
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			err=0;
            while ((err = oCustomer.dsReadFldNext(channel, "id,name,InvCode,Price,Cost,Length,Width,Height,BarCode,Taxable,QtyOnHand,QtyCommited,QtySold,QtyONPO,Vendor,VendorItem,Size", ref sKey, ref arrValues)) != 2)
			{
				//this.oReps.Focus();
				if (err==0)
				{					
					//this.oReps.st.Update();
					//this.oReps.st.Text = "The record next to "+sKey+" is in use.";
					
					continue;
				}
				
				
				try
				{
					arrValues.SetValue(cv_string( arrValues.GetValue(1).ToString()),1);
				}
				catch ( System.Exception  ex) 
				{
				
					MessageBox.Show(ex.Message);
				
				}

				int i=0;	
				
				if ((i=oMySql.exec_sql_no("Select count(*) from Product Where ProductID='"+arrValues.GetValue(0)+"' And CompanyID='"+sCompanyID+"'"))==0)

                    Sql = String.Format("Insert into Product (CompanyID, ProductID, Description, InvCode, Price, Cost, Length, Width, Height, BarCode, Taxable, OnHand,Commited,Sold,ONPO,VendorID,VendorItem, Size )  Values (\"{0}\",\"{1}\",\"{2}\",'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}', '{16}', '{17}')",
                        sCompanyID, arrValues.GetValue(0), arrValues.GetValue(1), arrValues.GetValue(2), arrValues.GetValue(3), arrValues.GetValue(4), arrValues.GetValue(5), arrValues.GetValue(6), arrValues.GetValue(7), arrValues.GetValue(8), arrValues.GetValue(9), arrValues.GetValue(10), arrValues.GetValue(11), arrValues.GetValue(12), arrValues.GetValue(13), arrValues.GetValue(14), arrValues.GetValue(15), arrValues.GetValue(16));
				else
                    Sql = String.Format("Update Product Set CompanyID='{0}', ProductID=\"{1}\", Description=\"{2}\", InvCode='{3}', Price='{4}', Cost='{5}',  Length='{6}', Width='{7}', Height='{8}', BarCode='{9}', Taxable='{10}', OnHand='{11}', Commited='{12}',Sold='{13}',ONPO='{14}',VendorID='{15}',VendorItem='{16}',Size='{17}'   Where ProductID='" + arrValues.GetValue(0) + "' And CompanyID='" + sCompanyID + "'",
                        sCompanyID, arrValues.GetValue(0), arrValues.GetValue(1), arrValues.GetValue(2), arrValues.GetValue(3), arrValues.GetValue(4), arrValues.GetValue(5), arrValues.GetValue(6), arrValues.GetValue(7), arrValues.GetValue(8), arrValues.GetValue(9), arrValues.GetValue(10), arrValues.GetValue(11), arrValues.GetValue(12), arrValues.GetValue(13), arrValues.GetValue(14), arrValues.GetValue(15), arrValues.GetValue(16));

				//MessageBox.Show(arrValues.GetValue(0).ToString());
				
				oMySql.exec_sql(Sql);	
							
			}
			
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void update_customers(String sCompanyID)
		{
			short channel=10;
			string sKey=new string(' ',10);
			System.Array arrValues= new System.String[100];
			int err = 0;
			
			MySQL oMySql = new  MySQL("192.168.254.66", "signatv9_OSAS") ; // Sql Open
           // MySQL oMySql = new MySQL("localhost", "signatv9_OSAS"); // Sql Open
			
			dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2
					
			if (oCustomer.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}
			
			
			if ((err=oCustomer.dsOpen("ARMAST."+sCompanyID,ref channel))== 10)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");

			if (err==13 || err==12  || err==11)
			{
			    MessageBox.Show("Couldn't open files,Please Contact to the server administrator error:"+err.ToString());
				return;
			}

			
			String strTemp = new string(' ',500);

            strTemp = FileTemplate.ARMAST;

            //Attach fields template
			oCustomer.dsTmpl(channel, strTemp);
	
					
			//Deleting our file from SQL
			String Sql = new string(' ',500);
		
						
			//Start at first record
			oCustomer.dsReadFld(channel,"", 0,"",ref arrValues);
            	
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop

            while ((err = oCustomer.dsReadFldNext(channel, "id,Name,Address1,City,State,Zip,ChairP,SignedNote,StartNote,Rep,Brochure,Profit,Signed,Brochure_2,Phone,Fax,d_start,d_end,d_signed,d_pickup,d_delivery,d_ship,n_items,n_sellers,Retail,AmountDue,Payments,n_units,HeadPhone,Prize,ApplyTax,SalesTax,CollectedTax,CODE1,CODE2,LastInvoiceAmount,PreviousInvoiced,Profit_2,Retail_1,n_sellers_1,TaxInvoiced,Pallets", ref sKey, ref arrValues)) != 2)
			{
			
				
				if (err==0)
				{					
					
					//this.oReps.st.Text = "The record next to "+sKey+" is in use.";
					continue;
				}
				else if (err==13 || err==12  || err==11)
				{
					MessageBox.Show("Please Contact to the server administrator error:"+err.ToString());
					return;
				}
							
				int i=0;
                arrValues.SetValue(arrValues.GetValue(1).ToString().Replace('\"', ' '), 1);
                arrValues.SetValue(arrValues.GetValue(1).ToString().Replace('\\', ' '), 1);
                arrValues.SetValue(arrValues.GetValue(2).ToString().Replace('\"', ' '), 2);
                arrValues.SetValue(arrValues.GetValue(6).ToString().Replace('\"', ' '), 6);
                arrValues.SetValue(arrValues.GetValue(7).ToString().Replace('\"', ' '), 7);
                arrValues.SetValue(arrValues.GetValue(8).ToString().Replace('\"', ' '), 8);
				if ((i=oMySql.exec_sql_no("Select count(*) from Customer Where CustomerID='"+arrValues.GetValue(0)+"' And CompanyID='"+sCompanyID+"'"))==0)
				{
                    Sql = String.Format("Insert into Customer (CustomerID, Name, Address , City, State, ZipCode,ChairPerson, eMail,RepID,BrochureID,ProfitPercent, Signed,BrochureID_2,PhoneNumber,FaxNumber,CompanyID,StartDate,EndDate,SignedDate,PickUpDate,DeliveryDate,ShipDate,NoItems,NoSellers,Retail,AmountDue,Payments,NoUnits,HeadPhone,PrizeID,ApplyTax, SalesTax,CollectTax,CODE1,CODE2, LastInvoiceAmount, PreviousInvoiced, ProfitBrochure_2,RetailNoInet, SellersNoInet, TaxInvoiced, NumberPallets)  Values ('{0}',\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}{8}\",'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17},{18},{19},{20},{21},{22},{23},{24},'{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}')",
                        arrValues.GetValue(0), arrValues.GetValue(1), arrValues.GetValue(2), arrValues.GetValue(3), arrValues.GetValue(4), arrValues.GetValue(5), arrValues.GetValue(6), arrValues.GetValue(7), arrValues.GetValue(8), arrValues.GetValue(9), arrValues.GetValue(10), arrValues.GetValue(11), arrValues.GetValue(12), arrValues.GetValue(13), arrValues.GetValue(14), arrValues.GetValue(15), sCompanyID, this.cv_date(arrValues.GetValue(16).ToString()), this.cv_date(arrValues.GetValue(17).ToString()), this.cv_date(arrValues.GetValue(18).ToString()), this.cv_date(arrValues.GetValue(19).ToString()), this.cv_date(arrValues.GetValue(20).ToString()), this.cv_date(arrValues.GetValue(21).ToString()), arrValues.GetValue(22), arrValues.GetValue(23), arrValues.GetValue(24), arrValues.GetValue(25), arrValues.GetValue(26), arrValues.GetValue(27), arrValues.GetValue(28), arrValues.GetValue(29), arrValues.GetValue(30), arrValues.GetValue(31), arrValues.GetValue(32), arrValues.GetValue(33), arrValues.GetValue(34), arrValues.GetValue(35), arrValues.GetValue(36), arrValues.GetValue(37), arrValues.GetValue(38), arrValues.GetValue(39), arrValues.GetValue(40), arrValues.GetValue(41));
					oMySql.exec_sql(Sql);	
				}
				else 
				{

                    Sql = String.Format("Update Customer Set CustomerID='{0}', Name=\"{1}\", Address=\"{2}\", City=\"{3}\", State=\"{4}\", ZipCode=\"{5}\",ChairPerson=\"{6}\", eMail=\"{7}{8}\",RepID='{9}',BrochureID='{10}',ProfitPercent='{11}', Signed='{12}',BrochureID_2='{13}',PhoneNumber='{14}',FaxNumber='{15}',CompanyID='{16}',StartDate={17},EndDate={18},SignedDate={19},PickUpDate={20},DeliveryDate={21},ShipDate={22},NoItems={23},NoSellers={24},Retail='{25}',AmountDue='{26}',Payments='{27}',NoUnits='{28}',HeadPhone='{29}',PrizeID='{30}', ApplyTax='{31}', SalesTax='{32}',CollectTax='{33}',CODE1='{34}', CODE2='{35}', LastInvoiceAmount='{36}', PreviousInvoiced='{37}',ProfitBrochure_2='{38}',RetailNoInet='{39}',SellersNoInet='{40}',TaxInvoiced='{41}',NumberPallets='{42}'  Where CompanyID='" + sCompanyID + "' And CustomerID='" + arrValues.GetValue(0) + "'",
                        arrValues.GetValue(0), arrValues.GetValue(1), arrValues.GetValue(2), arrValues.GetValue(3), arrValues.GetValue(4), arrValues.GetValue(5), arrValues.GetValue(6), arrValues.GetValue(7), arrValues.GetValue(8), arrValues.GetValue(9), arrValues.GetValue(10), arrValues.GetValue(11), arrValues.GetValue(12), arrValues.GetValue(13), arrValues.GetValue(14), arrValues.GetValue(15), sCompanyID, this.cv_date(arrValues.GetValue(16).ToString()), this.cv_date(arrValues.GetValue(17).ToString()), this.cv_date(arrValues.GetValue(18).ToString()), this.cv_date(arrValues.GetValue(19).ToString()), this.cv_date(arrValues.GetValue(20).ToString()), this.cv_date(arrValues.GetValue(21).ToString()), arrValues.GetValue(22), arrValues.GetValue(23), arrValues.GetValue(24), arrValues.GetValue(25), arrValues.GetValue(26), arrValues.GetValue(27), arrValues.GetValue(28), arrValues.GetValue(29), arrValues.GetValue(30), arrValues.GetValue(31), arrValues.GetValue(32), arrValues.GetValue(33), arrValues.GetValue(34), arrValues.GetValue(35), arrValues.GetValue(36), arrValues.GetValue(37), arrValues.GetValue(38), arrValues.GetValue(39), arrValues.GetValue(40), arrValues.GetValue(41));
					oMySql.exec_sql(Sql);
							
				}
			}
			// Closing connections
			
			oCustomer.dsClose(channel);
			oCustomer.dsDisconnect();
			oMySql.Close();

			return ;

		}
        public void update_OSAS_orders(String CustomerID)
		{
			
			frmOrderStatus oStatus =new frmOrderStatus();
			Orders oOrders = new Orders();

            
			oOrders.open_OSAS_log();
			
			//Loop through teh file, getting for names fields
			//An error, such as end-of-file(error 2), will return False, terminating the while loop
			int err=0;
			while ((err=oOrders.next_OSAS_log())!=2 )
			{
                
                
                if (err==0)
				{					
					oStatus.st.Text = "The record next to "+"cust_sKey"+" is in use.";
					oStatus.st.Update();
					continue;
				}
				
				if (CustomerID != "*")
					if (oOrders.sLog.CustomerID!=CustomerID)
						 continue;
				
				String AllowedCompanies = "F07,S07,T07";
				if (AllowedCompanies.IndexOf(oOrders.sLog.CompanyID.Trim(),0)==-1)
					continue;
					//MessageBox.Show(AllowedCompanies.IndexOf(oOrders.sLog.CompanyID.Trim(),0).ToString()+"-->"+oOrders.sLog.CompanyID);

                if (oOrders.sLog.CustomerID.Trim()=="00012" && DateTime.Now.Hour < 19)
                    continue;

                if (oOrders.sLog.CustomerID.Trim() == "3438" || oOrders.sLog.CustomerID.Trim() == "4623" || oOrders.sLog.CustomerID.Trim() == "91314")
                    continue;
				
				if(oOrders.sLog.Flag=="1")
				{
					oStatus.Show();
					//MessageBox.Show(oOrders.sLog.CustomerID);	
					if (oOrders.open_OSAS_orders())
					{	
						oOrders.set_on_order_flag();
						oOrders.set_on_detail_flag();

						err=0;
						do
						{
							if (oOrders.isEOF())
								break;
							
							if (oOrders.isHeader())			
							{
								
								oOrders.read_header_order();
					            oOrders.save_header_sql();
								while (oOrders.same_order())
								{
									
									oStatus.txtCompanyID.Text = oOrders.Detail.CompanyID;
									oStatus.txtCustomerID.Text = oOrders.Detail.CustomerID;
									oStatus.txtTeacher.Text = oOrders.Detail.Teacher;
									oStatus.txtStudent.Text = oOrders.Detail.Student;
									oStatus.txtProduct.Text = oOrders.Detail.Item;
									oStatus.txtUpdated.Text = oOrders.updated_rows.ToString();
									oStatus.txtInserted.Text=oOrders.inserted_rows.ToString();
									oStatus.txtDeleted.Text=oOrders.deleted_rows.ToString();
									oStatus.Update();
									
									
									oOrders.read_detail_order();
                                    oOrders.save_detail_sql();
                                 }
								
							}
							else
							{
								oOrders.read_detail_order();

							}
							
						
						}while (err!=2);

						oOrders.close_orders();							
						oOrders.delete_order_flag_on();
						oOrders.delete_detail_flag_on();
						

					}

                    oOrders.delete_log();	
										
				}
                
				
			}
			oStatus.Dispose();
			oOrders.Close();
			return ;

		}
		public void update_OSAS_orders(String CompanyID, String CustomerID)
		{
			
			frmOrderStatus oStatus =new frmOrderStatus();
			Orders oOrders = new Orders(CompanyID, CustomerID);
							
			oStatus.Show();
			//MessageBox.Show(oOrders.sLog.CustomerID);	
			if (oOrders.open_OSAS_orders())
			{	
				oOrders.set_on_order_flag();
				oOrders.set_on_detail_flag();

				int err=0;
				do
				{
					if (oOrders.isEOF())
						break;
							
					if (oOrders.isHeader())			
					{
								
						oOrders.read_header_order();
                        oOrders.save_header_sql();
								
						while (oOrders.same_order())
						{
									
							oStatus.txtCompanyID.Text = oOrders.Detail.CompanyID;
							oStatus.txtCustomerID.Text = oOrders.Detail.CustomerID;
							oStatus.txtTeacher.Text = oOrders.Detail.Teacher;
							oStatus.txtStudent.Text = oOrders.Detail.Student;
							oStatus.txtProduct.Text = oOrders.Detail.Item;
							oStatus.txtUpdated.Text = oOrders.updated_rows.ToString();
							oStatus.txtInserted.Text=oOrders.inserted_rows.ToString();
							oStatus.txtDeleted.Text=oOrders.deleted_rows.ToString();
							oStatus.Update();
									
							oOrders.read_detail_order();

                            oOrders.save_detail_sql();
									
						}
								
					}
					else
					{
						oOrders.read_detail_order();

					}
							
						
				}while (err!=2);

				oOrders.close_orders();							
				oOrders.delete_order_flag_on();
				oOrders.delete_detail_flag_on();
						

			}
			oStatus.Dispose();
			oOrders.Close();
			return ;

		}
        public void delete_OSAS_orders()
        {
            String CustomerID = "1165";
            String CompanyID = "F07";

            frmOrderStatus oStatus = new frmOrderStatus();
            Orders oOrders = new Orders(CompanyID, CustomerID);

            oStatus.Show();
            //MessageBox.Show(oOrders.sLog.CustomerID);	
            if (oOrders.open_OSAS_orders())
            {
                
                int err = 0;
                do
                {
                    if (oOrders.isEOF())
                        break;

                    if (oOrders.isHeader())
                    {

                        oOrders.read_header_order();
                        //if (oOrders.Header.Date != "'2007-04-10'")
                        //    continue;
                        MessageBox.Show(oOrders.Header.Date);
                        //continue;

                        while (oOrders.same_order())
                        {

                            oStatus.txtCompanyID.Text = oOrders.Detail.CompanyID;
                            oStatus.txtCustomerID.Text = oOrders.Detail.CustomerID;
                            oStatus.txtTeacher.Text = oOrders.Detail.Teacher;
                            oStatus.txtStudent.Text = oOrders.Detail.Student;
                            oStatus.txtProduct.Text = oOrders.Detail.Item;
                            oStatus.txtUpdated.Text = oOrders.updated_rows.ToString();
                            oStatus.txtInserted.Text = oOrders.inserted_rows.ToString();
                            oStatus.txtDeleted.Text = oOrders.deleted_rows.ToString();
                            oStatus.Update();


                            oOrders.read_detail_order();
                            if (oOrders.Header.Date == "'2007-04-10'")
                                oOrders.RemoveRecord(oOrders.Detail.Seq);

                        }
                        if (oOrders.Header.Date == "'2007-04-10'")
                            oOrders.RemoveRecord("000");
                    }
                    else
                    {
                        oOrders.read_detail_order();
                        //oOrders.RemoveRecord(oOrders.Detail.Seq);

                    }


                } while (err != 2);

                oOrders.close_orders();
                
            }
            oStatus.Dispose();
            oOrders.Close();
            return;

        }
        public void migrate_vendors(String sCompanyID)
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            String Sql = "Delete from Vendor Where CompanyID='" + sCompanyID + "'";
            oMySql.exec_sql(Sql);


            oFile.Open("INVEND", sCompanyID);

            while (!oFile.isEOF())
            {
                oFile.ReadNext("ID,Name,Address_1,Address_2,Address_3,City,State,ZipCode,Contact,Phone,Fax");
                Sql = String.Format("Insert into Vendor (VendorID, Name, Address_1, Address_2,Address_3,City,State,ZipCode,Contact,Phone,Fax,CompanyID)  Values ('{0}',\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",'{10}','{11}')",
                    oFile.GetValue(0), oFile.GetValue(1), oFile.GetValue(2), oFile.GetValue(3), oFile.GetValue(4), oFile.GetValue(5), oFile.GetValue(6), oFile.GetValue(7), oFile.GetValue(8), oFile.GetValue(9), oFile.GetValue(10), sCompanyID);
                    oMySql.exec_sql(Sql);
                

            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void update_customer_extra(String sCompanyID)
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            oFile.Open("ARCUSTEX", sCompanyID);

            
            while (oFile.ReadNext("CustomerID,Detail,CODE3,Retail"))
            {
                if (oMySql.exec_sql_no(String.Format("Select count(*) From Customer Where CustomerID='{0}' And CompanyID='{1}'", oFile.GetValue(0), sCompanyID))>0)
                {
                    String Sql = String.Format("Update Customer Set CODE3='{0}', RetailBrochure_2 = '{1}' Where CustomerID='{2}' And CompanyID='{3}'",
                    oFile.GetValue(2), oFile.GetValue(3), oFile.GetValue(0), sCompanyID);
                    oMySql.exec_sql(Sql);
                }
            }
            
            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
		public void test_header_order()
		{
			int err=0;
			short t_channel=10;
			System.Array arrTest= new System.String[5];
			String Record = new string(' ',200);
			string t_sKey=new string(' ',100);

			t_sKey="TEACHER 001                   "+"STUDENT 001                   "+"000";

			dSERVEClass oTest = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oTest.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}
			
			if (oTest.dsOpen("TORDER",ref t_channel)== 30)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");
			
						
			//oCustomer.dsTmpl(channel,"teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),nro_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:"); //,phone:c(10*)");		
			
			oTest.dsTmpl(t_channel,"teacher:c(30),student:c(30*),type:c(3*),prize:c(10*),no_items:n(10*),retail:n(10*),collected:n(10*),tax:n(10*),printed:n(1*),disc_printed:n(1*),box:c(10*),entry_date:n(10*):date=jul:,phone:c(10*)"); //final field ascterisc relevant
			
			
			//MessageBox.Show(t_sKey);
			
		/*	err = oTest.dsReadRec(t_channel,t_sKey,0,ref Record);
			if (err==11)
				MessageBox.Show("Record didn't find");
		*/	
			//oTest.dsReadFld(t_channel,t_sKey,0,"teacher,student,type,prize,no_items,retail,collected,tax,printed,disc_printed,box,entry_date",ref arrTest);
			//oTest.dsReadFld(t_channel,t_sKey,0,"teacher,student,type,prize,no_items",ref arrTest);
			
			err = oTest.dsExtractRec(t_channel,t_sKey,0,ref Record);
			if (err!=-1)
			{
				MessageBox.Show(err.ToString()); 
				Record = "";
			}
			
			MessageBox.Show(Record);
			//MessageBox.Show(Record.Length.ToString());
			
			//		oCustomer.dsExtractFld(channel,sKey,0,"teacher,student",ref arrValues);
			
			//Console.WriteLine(Record);
			//		MessageBox.Show(arrValues.GetValue(0).ToString());

				
			
			
			arrTest.SetValue("TEACHER 001                   ",0);
			arrTest.SetValue("STUDENT 001                   ",1);
			arrTest.SetValue("000",2);
			arrTest.SetValue("0123456789",3);
			arrTest.SetValue("10.20",4);/*
			arrTest.SetValue("10.30",5);
			arrTest.SetValue("10.40",6);
			arrTest.SetValue("10.50",7);
			arrTest.SetValue("1",8);
			arrTest.SetValue("2",9);
			arrTest.SetValue("5",10);
			arrTest.SetValue("2454291",11);*/



			
			//err = oTest.dsWriteFld(t_channel,t_sKey,Record,"teacher,student,type,prize,no_items,retail,collected,tax,printed,disc_printed,box,entry_date",ref arrTest);
			err = oTest.dsWriteFld(t_channel,t_sKey,Record,"teacher,student,type,prize,no_items",ref arrTest);

			//int Update = oCustomer.dsWriteRec(channel,sKey,Record);
			//if (err==13)
			//	MessageBox.Show("It couldn't update the file (Order)");

			if (err!=-1)
				MessageBox.Show(err.ToString()+ Record.Length.ToString()); 	

			

			// Closing connections
			oTest.dsClose(t_channel);
			oTest.dsDisconnect();
			return;	

		}
		public void test_detail_order()
		{
			int err=0;
			short t_channel=10;
			System.Array arrTest= new System.String[8];
			String Record = new string(' ',200);
			string t_sKey=new string(' ',100);

			t_sKey="TEACHER 001                   "+"STUDENT 001                   "+"002";

			dSERVEClass oTest = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oTest.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}
			
			if (oTest.dsOpen("TORDER",ref t_channel)== 30)  //Open our file to migrate
				MessageBox.Show("This file wasn't open!!!");
			
						
			//Attach header fields template
			oTest.dsTmpl(t_channel,"teacher:c(30),student:c(30*),type:c(3*),item:c(10*),nro_items:n(10*),tax:n(10*),nro_invoiced:n(10)");
			
			
			//Read record
			//err = oTest.dsReadFld(channel, "teacher,student,type,item,nro_items,tax,nro_invoiced", ref sKey1, ref arrValues);

			err = oTest.dsExtractRec(t_channel,t_sKey,0,ref Record);
			if (err!=-1)
			{
				MessageBox.Show(err.ToString()); 
				Record = "";
			}
			
			MessageBox.Show(Record);
			
			
			arrTest.SetValue("TEACHER 001                   ",0);
			arrTest.SetValue("STUDENT 001                   ",1);
			arrTest.SetValue("002",2);
			arrTest.SetValue("20",3);
			arrTest.SetValue("10.20",4);
			arrTest.SetValue("10.30",5);
			arrTest.SetValue("20",6);
			
					
			err = oTest.dsWriteFld(t_channel,t_sKey,Record,"teacher,student,type,item,nro_items,tax,nro_invoiced",ref arrTest);

			//int Update = oCustomer.dsWriteRec(channel,sKey,Record);
			//if (err==13)
			//	MessageBox.Show("It couldn't update the file (Order)");

			if (err!=-1)
				MessageBox.Show(err.ToString()+ Record.Length.ToString()); 	


			// Closing connections
			oTest.dsClose(t_channel);
			oTest.dsDisconnect();
			return;	

		}
		public void create_keyed_file()
		{
			int err=0;
			
			dSERVEClass oTest = new dSERVE2.dSERVEClass(); // Open dServe2
			
			if (oTest.dsConnect(dServe,8227,50000)!=-1) //Connecting
			{
				MessageBox.Show("Not Connected!!");
				return;
			}

			err = oTest.dsCreateKeyed("G:/OSAS/orders/TORDER.001","[1:1:60]+[2:1:3],[1:31:30]+[1:1:30]+[2:1:3]",130);
			if (err!=-1)
				MessageBox.Show(err.ToString()); 	

			oTest.dsDisconnect();
						
		}
        public void update_payments(String sCompanyID)
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            
            oFile.Open("ARINV", sCompanyID);
            String CustomerID = "";
            while (!oFile.isEOF())
            {
                oFile.ReadNext("Id,Amount,Type,Comment,Date,Seq");
                if (CustomerID == "3438")
                    continue;
                
                if (CustomerID != oFile.GetValue(0))
                {
                    CustomerID = oFile.GetValue(0);
                    oMySql.exec_sql(String.Format("Delete from Payment Where CompanyID='{0}' And CustomerID='{1}'", sCompanyID, CustomerID));
                }

                Double Amount  = Convert.ToDouble(oFile.GetValue(1));
                if (oFile.GetValue(2) == "P")
                    Amount = Amount*-1;

                
              //  if (oMySql.exec_sql_no(String.Format("Select count(*) from Payment Where CustomerID='{0}' And CompanyID='{1}' And Seq='{2}'", oFile.GetValue(0),sCompanyID, oFile.GetValue(5))) == 0)
              //  {
                //MessageBox.Show(String.Format("Insert into Payment (CustomerID, Amount, Type, Comment, Date, Seq, CompanyID)  Values ('{0}','{1}',\"{2}\",\"{3}\",{4},\"{5}\",\"{6}\")",
                //oFile.GetValue(0), Amount, oFile.GetValue(2), oFile.GetValue(3), this.cv_date(oFile.GetValue(4)), oFile.GetValue(5), sCompanyID));
                    oMySql.exec_sql(String.Format("Insert into Payment (CustomerID, Amount, Type, Comment, Date, Seq, CompanyID)  Values ('{0}','{1}',\"{2}\",\"{3}\",{4},\"{5}\",\"{6}\")",
                    oFile.GetValue(0), Amount, oFile.GetValue(2), oFile.GetValue(3), this.cv_date(oFile.GetValue(4)), oFile.GetValue(5), sCompanyID));
              /*  }
                else
                {

                    oMySql.exec_sql(String.Format("Update Payment Set  Amount=\"{0}\", Type=\"{1}\", Comment=\"{2}\", Date={3}  Where CompanyID='" + sCompanyID + "' And CustomerID='" + oFile.GetValue(0) + "' And Seq='" + oFile.GetValue(5) + "'",
                         Amount, oFile.GetValue(2), oFile.GetValue(3), this.cv_date(oFile.GetValue(4))));

                }*/

                

                
            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void migrate_brochures(String sCompanyID)
        {
            //MessageBox.Show("Ok");
            short channel = 10;
            //short channel_1 = 11;
            string sKey = new string(' ', 10);
            System.Array arrValues = new System.String[20];

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open


            dSERVE2.dSERVEClass oCustomer = new dSERVE2.dSERVEClass(); // Open dServe2


            if (oCustomer.dsConnect(dServe, 8227, 50000) != -1) //Connecting
            {
                MessageBox.Show("Not Connected!!");
                return;
            }
            if (oCustomer.dsOpen("INBMAST." + sCompanyID, ref channel) == 10)  //Open our file to migrate
                MessageBox.Show("This file wasn't open!!!");
            
            //Attach fields template
            oCustomer.dsTmpl(channel, "id:c(10),short_name:c(10),name:c(30*),n_items:n(10*)");


            //Deleting our file from SQL
            String Sql = new string(' ', 100);
            Sql = "Delete from Brochure Where CompanyID='" + sCompanyID + "'";
            oMySql.exec_sql(Sql);
            
            //Start at first record
            oCustomer.dsReadFld(channel, "", 0, "", ref arrValues);

            //Loop through teh file, getting for names fields
            //An error, such as end-of-file(error 2), will return False, terminating the while loop
            int err = 0;
            while ((err = oCustomer.dsReadFldNext(channel, "id,name,n_items", ref sKey, ref arrValues)) != 2)
            {
                //this.oReps.Focus();
                if (err == 0)
                {
                    //this.oReps.st.Text = "The record next to "+sKey+" is in use.";
                    //this.oReps.st.Update();
                    continue;
                }
                else
                {
                    //this.oReps.st.Text = sKey;
                    //this.oReps.st.Update();
                }
                //INSERT INTO %s (customer, order_date) VALUES (%d, NOW())
                arrValues.SetValue(cv_string(arrValues.GetValue(1).ToString()), 1);

                Sql = String.Format("Insert into Brochure (BrochureID, Description, N_Items,CompanyID)  Values ('{0}',\"{1}\",'{2}','{3}')",
                    arrValues.GetValue(0), arrValues.GetValue(1), arrValues.GetValue(2), sCompanyID);

                oMySql.exec_sql(Sql);

            }

            // Closing connections

            oCustomer.dsClose(channel);
            oCustomer.dsDisconnect();
            oMySql.Close();

            return;

        }
        public void update_brochures(String sCompanyID)
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            oFile.Open("INBROCH", sCompanyID);
            String BrochureID = "";
            while (!oFile.isEOF())
            {
                oFile.ReadNext("Id,ProductID");

               // MessageBox.Show(oFile.GetValue(0) + "--" + oFile.GetValue(1) );


                if (BrochureID != oFile.GetValue(0))
                {
                    BrochureID = oFile.GetValue(0);
                    //     oMySql.exec_sql(String.Format("Delete from Payment Where CompanyID='{0}' And CustomerID='{1}'", sCompanyID, CustomerID));
                }

                if (oFile.GetValue(1) == "HEAD".PadLeft(10))
                    continue;

                if (oMySql.exec_sql_no(String.Format("Select count(*) from BrochureDetail Where BrochureID='{0}' And CompanyID='{1}' And ProductID='{2}'", oFile.GetValue(0), sCompanyID, oFile.GetValue(1))) == 0)
                {
                    oMySql.exec_sql(String.Format("Insert into BrochureDetail (BrochureID, ProductID, CompanyID)  Values ('{0}',\"{1}\",\"{2}\")",
                    oFile.GetValue(0), oFile.GetValue(1), sCompanyID));
                }
                else
                {

                    oMySql.exec_sql(String.Format("Update BrochureDetail Set  ProductID=\"{0}\"  Where CompanyID='" + sCompanyID + "' And BrochureID='" + oFile.GetValue(0) + "' And BrochureID='" + oFile.GetValue(1) + "'",
                         oFile.GetValue(1)));

                }
    
            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void migrate_states()    
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            oFile.Open("OSST", "");

            oMySql.exec_sql(String.Format("Delete from States "));
            while (!oFile.isEOF())
            {
                oFile.ReadNext("Id,Name,Country");

                // MessageBox.Show(oFile.GetValue(0) + "--" + oFile.GetValue(1) );
                
                oMySql.exec_sql(String.Format("Insert into States (StateID, Name, Country)  Values ('{0}',\"{1}\",\"{2}\")",
                oFile.GetValue(0), oFile.GetValue(1), oFile.GetValue(2)));
            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
        public void migrate_taxes_by_states(String CompanyID)
        {

            MySQL oMySql = new MySQL("192.168.254.66", "signatv9_OSAS"); // Sql Open

            File oFile = new File();

            oFile.Open("INTAX", CompanyID);

            oMySql.exec_sql(String.Format("Delete from Tax_By_State Where CompanyID='{0}'",CompanyID));
            while (!oFile.isEOF())
            {
                oFile.ReadNext("ProductId,StateID,Taxable");

                // MessageBox.Show(oFile.GetValue(0) + "--" + oFile.GetValue(1) );

                oMySql.exec_sql(String.Format("Insert into Tax_By_State (ProductID, StateID, Taxable,CompanyID)  Values ('{0}','{1}','{2}','{3}')",
                oFile.GetValue(0), oFile.GetValue(1), oFile.GetValue(2),CompanyID));
            }

            // Closing connections
            oFile.Close();
            oFile.Disconnect();
            oMySql.Close();

            return;

        }
       

	}
}
