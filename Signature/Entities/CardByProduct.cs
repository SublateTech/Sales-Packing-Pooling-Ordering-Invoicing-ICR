using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Signature.Data;
using Signature;

namespace Signature.Classes
{
    public class Card:Product
    {
        protected new SqlBuilder oBuild; //Reuqired
        protected new String TableName = "Card";
        
        
        //public String CompanyID;
        public String ProductID;
        public Int32 CardTemplateID;
        public Int32 EnvTemplateID;
        public Double PointX;
        public Double PointY;
        public String FontName;
        public Int32 FontSize;
        public Boolean Bold;
        public Boolean AsTemplate;
        public String FilePath;


        
        // public delegate void EventHandler (object sender, EventArgs e);
        // Define an Event based on the above Delegate
        public event EventHandler AskForPhoneChanged;
        
        // By Default, create an OnXXXX Method, to call the Event
        protected virtual void OnAskForPhoneChange(string message)
        {
            if (AskForPhoneChanged != null)
            {
                EventArgs e = new EventArgs();
                AskForPhoneChanged(this,e);
            }
        }
        
        public Card(String CompanyID):base(CompanyID)
        {
            this.CompanyID = CompanyID;
        }

        private new void Clear()
        {
            //CompanyID="";
            ProductID="";
            CardTemplateID=0;
            PointX=0.00;
            PointY=0.00;
            FontName="";
            FontSize=0;
            Bold=false;
            FilePath = "";
                    
        }
        public new bool Find(String ProductID)
        {
            //this.CallID = String.Empty;

            if (ProductID == "")
            {
                Clear();
                return false;
            }

            DataRow Row = oMySql.GetDataRow("Select * From Card Where ProductID='" + ProductID +"' And CompanyID='"+this.CompanyID+"'", "Card");
            
            if (Row == null)
            {
                Clear();
                return false;
            }
            
            
            this.CompanyID          = Row["CompanyID"].ToString();
            this.ProductID          = Row["ProductID"].ToString();
            this.CardTemplateID     = (Int32) Row["CardTemplateID"];
            this.EnvTemplateID      = (Int32)Row["EnvTemplateID"];
            this.PointX             = (Double) Row["PointX"];
            this.PointY             = (Double) Row["PointY"];
            this.FontName           = Row["FontName"].ToString();
            this.FontSize           = (Int32)Row["FontSize"];
            this.Bold               = (Boolean)Row["Bold"];
            this.AsTemplate         = (Boolean)Row["AsTemplate"];
            this.FilePath           = Row["FilePath"].ToString();
            return true;

        }
        public new void Save()
        {
            FillFields();
            if (Exists())
                Update();
            else
                Insert();
        }
        public new void Update()
        {  
            oMySql.exec_sql(oBuild.Update("Where ProductID='"+this.ProductID+"' And CompanyID='"+this.CompanyID+"'"));
        }
        public new void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());

        }
        internal new void FillFields()
        {
            oBuild = new SqlBuilder();

            if (this.FilePath != null)
                this.FilePath = FilePath.Replace("\\","\\\\");
            oBuild.AddRange(TableName, new String[] { 
                "CompanyID",
                "ProductID",
                "CardTemplateID",
                "EnvTemplateID",
                "PointX",
                "PointY",
                "FontName",
                "FontSize",
                "Bold",
                "AsTemplate",
                "FilePath"
                },
                new Object[] {
                    this.CompanyID,
                    this.ProductID,
                    this.CardTemplateID,
                    this.EnvTemplateID,
                    this.PointX,
                    this.PointY,
                    this.FontName,
                    this.FontSize,
                    this.Bold?"1":"0",
                    this.AsTemplate?"1":"0",
                    this.FilePath
                    });
        }
        public new bool Exists()
        {
            if ((oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where ProductID='{1}' And CompanyID='{2}'",this.TableName,this.ProductID,this.CompanyID))) == 0)
                return false;
            else
                return true;
        }
        public new void Delete()
        {
            String Sql = String.Format("Delete From {0} Where ProductID='{1}' And CompanyID='{2}'",TableName,this.ProductID,this.CompanyID);
            oMySql.exec_sql(Sql);
        }
        public new virtual bool View()
        {   
            frmProductTypesView oView = new frmProductTypesView(CompanyID);
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(oView.sSelectedID);
                return true;
            }
            return false;
        }
    }
}
