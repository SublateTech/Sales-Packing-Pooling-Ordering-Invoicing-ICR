using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
namespace Signature.Classes
{
    public class CoverSheet:Company
    {
        

        // Properties
        private String _ID;
        public String CustomerID;
        public String OrderID;
        public Int32 N_TeacherEnvelopes;
        public Int32 N_Letters;
        public String Spanish;
        public String AdditionalPiece1;
        public String AdditionalPiece2;
        public String SigDirectBooklet;
        public String SalesRepBooklet;
        public String eScooterSample;
        public String UPSReturnBox;
        public Int32 KickOffVideos;
        public Int32 TeacherGifts;
        public String Posters;
        public String DisplayKit;
        public DateTime ReadyDate;
        public String IsReady;
        public String Notes;
        public Boolean Found = false;
        public Int32 PreviousNoLetters = 0;
        public String SigProduct;


        public Boolean B15ItemFlier;
        public Boolean PriceADay;
        public Boolean CustomUPSRS;


        //Methods

        public CoverSheet(String CompanyID)
        {
            this.CompanyID = CompanyID;

        } //Constructor
        public bool FindByCustomer(String CustomerID)
        {
            if (CustomerID == "")
                return false;

            DataRow row = oMySql.GetDataRow("Select * From Coversheet Where CustomerID='" + CustomerID + "'", "Coversheet");
            if (row == null)
            {
                ID = CustomerID;
                return false;
            }
            ID = row["CoversheetID"].ToString();
            this.Find(ID);
            return true;

        }
        public new bool Find(String CustomerID)
        {
            if (CustomerID == "")
            {
                this.Found = false;
                return false;
            }
            DataRow row = oMySql.GetDataRow("Select * From Coversheet Where CustomerID='" + CustomerID + "' And CompanyID='"+base.ID+"'", "Coversheet");
            if (row == null)
            {
                ID = CustomerID;
                this.Found = false;
                return false;
            }
            ID = row["CoversheetID"].ToString();
            this.N_Letters = row["NoLetters"]==DBNull.Value ? 0 : (Int32) row["NoLetters"];
            this.N_TeacherEnvelopes = row["NoTeacherEnvelopes"]==DBNull.Value ? 0 : (Int32) row["NoTeacherEnvelopes"];
            this.Spanish = row["Spanish"].ToString();
            this.AdditionalPiece1 = row["AdditionalPiece1"].ToString();
            this.AdditionalPiece2 = row["AdditionalPiece2"].ToString();
            this.SigDirectBooklet = row["SigDirectBooklet"].ToString();
            this.SalesRepBooklet = row["SalesPersonBooklet"].ToString();
            this.UPSReturnBox = row["UPSReturnBox"].ToString();
            this.KickOffVideos =  (Int32)  row["KickOffVideos"];
            this.Posters = row["Posters"].ToString();
            this.TeacherGifts = (Int32)  row["TeacherGifts"];
            this.ReadyDate = (DateTime)row["ReadyDate"];
            this.Notes = row["Notes"].ToString();
            this.IsReady = row["IsReady"].ToString();
            this.DisplayKit = row["DisplayKit"].ToString();
            this.PreviousNoLetters = N_Letters;
            this.SigProduct = row["SigProduct"].ToString();
            this.eScooterSample = row["EScooterSample"].ToString();

            this.B15ItemFlier = (Boolean)row["B15ItemFlier"];
            this.PriceADay = (Boolean)row["PriceADay"];
            this.CustomUPSRS = (Boolean)row["CustomUPSRS"];

            this.Found = true;
            return true;

        }
        
        public new void Update()
        {

            String Sql = String.Format("Update Coversheet Set NoLetters='{0}',NoTeacherEnvelopes='{1}',Spanish='{2}',AdditionalPiece1='{3}',AdditionalPiece2='{4}',SigDirectBooklet='{5}',SalesPersonBooklet='{6}',UPSReturnBox='{7}',KickOffVideos='{8}',Posters='{9}',TeacherGifts='{10}',CompanyID='{11}',CustomerID='{12}',Notes='{13}',IsReady='{14}',ReadyDate={15},DisplayKit={16},SigProduct={17},EScooterSample='{18}',B15ItemFlier='{19}',PriceADay='{20}',CustomUPSRS='{21}'  Where CustomerID='" + this.CustomerID + "' And CompanyID='" + this.CompanyID + "'",
            this.N_Letters, this.N_TeacherEnvelopes, this.Spanish, this.AdditionalPiece1, this.AdditionalPiece2, this.SigDirectBooklet, this.SalesRepBooklet, this.UPSReturnBox,
            this.KickOffVideos,this.Posters,this.TeacherGifts,this.CompanyID, this.CustomerID,this.Notes,this.IsReady,cv_date(this.ReadyDate),this.DisplayKit,this.SigProduct,this.eScooterSample,
            B15ItemFlier?'1':'0',PriceADay?'1':'0',CustomUPSRS?'1':'0');
           
            oMySql.exec_sql(Sql);
   

        }
        public new void Insert()
        {
            String Sql = String.Format("Insert into Coversheet (NoLetters,NoTeacherEnvelopes,Spanish,AdditionalPiece1,AdditionalPiece2,SigDirectBooklet,SalesPersonBooklet,UPSReturnBox,KickOffVideos,Posters,TeacherGifts,CompanyID,CustomerID,Notes,IsReady,ReadyDate,DisplayKit,SigProduct,EScooterSample,B15ItemFlier,PriceADay,CustomUPSRS)  Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',{15},{16},{17},'{18}','{19}','{20}','{21}')",
                        this.N_Letters, this.N_TeacherEnvelopes, this.Spanish, this.AdditionalPiece1, this.AdditionalPiece2, this.SigDirectBooklet, this.SalesRepBooklet, this.UPSReturnBox,
                        this.KickOffVideos, this.Posters, this.TeacherGifts, this.CompanyID, this.CustomerID,this.Notes,this.IsReady,cv_date(this.ReadyDate),this.DisplayKit,this.SigProduct,this.eScooterSample,
                        B15ItemFlier ? '1' : '0', PriceADay ? '1' : '0', CustomUPSRS ? '1' : '0');
            /// Console.WriteLine(Sql);
            //oMySql.exec_sql(Sql);
            ID = oMySql.exec_sql_id(Sql).ToString();
     
        }
        public bool IfExist()
        {
           
            if (oMySql.exec_sql_no("Select count(*) from Coversheet Where CustomerID='" + this.CustomerID + "' And CompanyID='"+base.CompanyID+"'") == 0)
                return false;
            else
                return true;
        }
        public new void Save()
        {
            if (IfExist())
            {
                Update();
             
            }
            else
                Insert();

        }
        public new void Delete()
        {
            String Sql = "Delete From Coversheet Where CoversheetID='" + this.ID + "'";
            oMySql.exec_sql(Sql);
        }
        public new String ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private String cv_date(DateTime Date)
        {
            DateTime DNull = new DateTime(1900, 01, 01);
            String sStr = null;
            if (Date != DNull)
            {
                sStr = "'" + Date.ToString("yyyy-MM-dd") + "'";
            }
            else
                sStr = "null";

            return sStr;

        }


    }
}