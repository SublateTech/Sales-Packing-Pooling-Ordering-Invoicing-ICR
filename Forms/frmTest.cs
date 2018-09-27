using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Vista;
using Signature.Classes;
using Signature.Data;
using System.Collections;

namespace Signature.Forms
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            SqlBuilder oBuild = new SqlBuilder();

            oBuild.AddRange("CustomerCalls", new String[] {"CustomerID" , "CompanyID","UserID"}, new Object[] { "1119" ,  "F07", "Alvaro"});
            //oBuild.ListFields();
            //MessageBox.Show(oBuild.Insert());
            //MessageBox.Show(oBuild.Update());

            //Global.oMySql.exec_sql(oBuild.Insert());
            Global.oMySql.exec_sql(oBuild.Update("Where CallId='2'"));
            return;
            
            //Global.ShowNotifier("Hey this a test");
            Smtp oSmtp = new Smtp();
            oSmtp.To = "\"Alvaro Medina\" <alvaro@sigfund.com>";
            oSmtp.From = "\"Alvaro Medina\" <alvaro@sigfund.com>";
            oSmtp.Subject = "Testing ";
            oSmtp.Body = "Body testings....";
            oSmtp.Attachment = @"D:\tmp.xls";
            oSmtp.Attachment = @"D:\TEST.TXT";
            if (oSmtp.Send())
                MessageBox.Show("Mail Sent");
            */

            ZonalSignature oIcr = new ZonalSignature("F08");
            oIcr.Test();

            /*
            ScannedImage oImage = new ScannedImage();
            oImage.FileType = "TIFF";
            oImage.ImagePath = @"I:\Images\";
            oImage.ID = 153;

            oIcr.ProcessImage(oImage);
            */
            
            //MessageBox.Show(oImage.FilePath);

            
            oIcr.ProcessFields();
        }

        private void live5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Got Clicked");
        }

        private void live5_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("Hey!");
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            DataTable db_charges = Global.oMySql.GetDataTable("SELECT r.Name, rc.CompanyID, r.ID, rc.RepID, rc.Ext, sum(Charge) as Charge FROM RepCharges rc Left Join Reps r On rc.RepID=r.ID And  rc.CompanyID='S07' Where r.Name is not Null Group By rc.Ext Order By r.Name");

            foreach (DataRow row in db_charges.Rows)
            {
                RepCharge oCharge   = new RepCharge("S09");
                oCharge.Amount      = (Double)row["Charge"];
                oCharge.RepID       = (Int32)row["RepID"];
                oCharge.CompanyID   = "S09";
                oCharge.Date        = DateTime.Now;
                oCharge.Description = "Comming from Fall 08";
                oCharge.Insert();
            }
            Global.ShowNotifier("Done!");
        }

        

       
    }
}