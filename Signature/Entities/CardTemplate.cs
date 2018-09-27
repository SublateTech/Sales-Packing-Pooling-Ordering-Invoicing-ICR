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
    public class CardTemplate
    {
        protected SqlBuilder oBuild; //Reuqired
        protected String TableName = "CardTemplate";
        
        public String ID;
        public String Description;
        public Double PointX;
        public Double PointY;
        public String FontName;
        public Int32 FontSize;
        public Boolean Bold;
        public Int32 Rotation;
        public Double PaperSizeWidth;
        public Double PaperSizeHeight;
        public Double Width;
        public Double Height;

        public System.Drawing.Printing.PaperSize PaperSize;
        public System.Drawing.PointF Point;
        


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
        
        public CardTemplate()
        {
            
        }

        private void Clear()
        {
            ID="";
            Description="";
            PointX=0.00;
            PointY=0.00;
            FontName="";
            FontSize=0;
            Bold=false;
            Rotation = 0;
            PaperSize   = new System.Drawing.Printing.PaperSize();
            Point       = new System.Drawing.PointF();
                    
        }
        public  bool Find(Int32 ID)
        {
            //this.CallID = String.Empty;

            if (ID == 0)
            {
                Clear();
                return false;
            }

            DataRow Row = Global.oMySql.GetDataRow(String.Format("Select * From {0} Where ID='{1}'",TableName,ID), TableName);
            
            if (Row == null)
            {
                Clear();
                return false;
            }
            
            this.ID                 = Row["ID"].ToString();
            this.Description        = Row["Description"].ToString();
            this.PointX             = (Double) Row["PointX"];
            this.PointY             = (Double) Row["PointY"];
            this.PaperSizeWidth     = (Double)Row["PaperSizeWidth"];
            this.PaperSizeHeight    = (Double)Row["PaperSizeHeight"];
            this.FontName           = Row["FontName"].ToString();
            this.FontSize           = (Int32)Row["FontSize"];
            this.Bold               = (Boolean)Row["Bold"];
            this.Rotation           = (Int32)Row["Rotation"];

            this.PaperSize          = new System.Drawing.Printing.PaperSize("General",(int)(PaperSizeWidth*100), (int)(PaperSizeHeight*100));
            this.Point              = new System.Drawing.PointF((float)(PointX*100), (float)(PointY*100));
            return true;

        }
        public  void Save()
        {
            FillFields();
            if (Exists())
                Update();
            else
                Insert();
        }
        public  void Update()
        {  
            Global.oMySql.exec_sql(oBuild.Update("Where ID='"+this.ID+"'"));
        }
        public  void Insert()
        {
            Global.oMySql.exec_sql(oBuild.Insert());

        }
        internal void FillFields()
        {
            oBuild = new SqlBuilder();
            oBuild.AddRange(TableName, new String[] { 
                
                "ID",
                "Description",
                "PointX",
                "PointY",
                "FontName",
                "FontSize",
                "Bold",
                "Rotation",
                "PaperSizeWidth",
                "PaperSizeHeight"                
                },
                new Object[] {
                
                    this.ID,
                    this.Description,
                    this.PointX,
                    this.PointY,
                    this.FontName,
                    this.FontSize,
                    this.Bold?"1":"0",
                    this.Rotation,
                    this.PaperSizeWidth,
                    this.PaperSizeHeight
                    });
        }
        public bool Exists()
        {
            if ((Global.oMySql.exec_sql_no(String.Format("Select count(*) from {0} Where ID='{1}'",this.TableName,this.ID))) == 0)
                return false;
            else
                return true;
        }
        public void Delete()
        {
            String Sql = String.Format("Delete From {0} Where ID='{1}'",TableName,this.ID);
            Global.oMySql.exec_sql(Sql);
        }
        public virtual bool View()
        {   
            //frmProductTypesView oView = new frmProductTypesView(CompanyID);
            frmViewTemplates oView = new frmViewTemplates();
            oView.ShowDialog();
            if (oView.sSelectedID != "")
            {
                this.Find(Convert.ToInt32(oView.sSelectedID));
                return true;
            }
            return false;
        }
    }
}
