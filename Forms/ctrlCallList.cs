using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
    public partial class CallList : UserControl
    {
        Timer oTimer = new Timer();
        String CustomerID = "";
        DataTable dt;


        public CallList()
        {
            InitializeComponent();
            
            if (!InDesignMode())
            {
                oTimer.Tick += new EventHandler(oTimer_Tick);
                oTimer.Interval = 5000;
                oTimer.Start();

                oTimer_Tick(null, null);
            }
        }

        void oTimer_Tick(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            oTimer.Stop();
            // MessageBox.Show("Hey!!");
            if (!InDesignMode())
            {
                if (Grid.ActiveRow != null)
                {
                    this.CustomerID = Grid.ActiveRow.Cells["CustomerID"].Value.ToString();
                }

                rbEndCalls_CheckedChanged(rbEndCalls, null);
                rbPickUpCalls_CheckedChanged(rbPickUpCalls, null);
            }
            // Global.Message = InDesignMode().ToString();
            oTimer.Start();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            oTimer.Stop();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            oTimer.Start();
        }

        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        private void Grid_MouseHover(object sender, EventArgs e)
        {
            oTimer.Stop();
        }

        private void Grid_MouseLeave(object sender, EventArgs e)
        {
            oTimer.Start();
        }

        private void Grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //' declare objects to get value from cell and display
            Infragistics.Win.UIElement mouseupUIElement;
            Infragistics.Win.UltraWinGrid.UltraGridCell mouseupCell;

            //' retrieve the UIElement from the location of the MouseUp
            mouseupUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
            if (mouseupUIElement == null)
                return;

            //' retrieve the Cell from the UIElement
            mouseupCell = mouseupUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell))
                as Infragistics.Win.UltraWinGrid.UltraGridCell; ;

            //' if there is a cell object reference, set to active cell and edit
            if ((mouseupCell == null))
                return;

            if (Grid.ActiveRow != null)
            {
                //  sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
                frmCalls ofrm = new frmCalls(Grid.ActiveRow.Cells["CustomerID"].Text);
                ofrm.MdiParent = Signature.Forms.frmMain.ActiveForm;
                ofrm.Show();

            }

            
        }

        private void ActiveRow()
        {
            if (this.CustomerID != "")
            {
                foreach (UltraGridRow aUGRow in Grid.Rows)
                {
                    if (aUGRow.Cells["CustomerID"].Value.ToString() == this.CustomerID)
                    {
                        Grid.ActiveRow = aUGRow;
                        break;
                    }
                    
                }
            }
        }

        private void rbEndCalls_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DateTime CurDate = DateTime.Now;
              //  CurDate = CurDate.AddDays(80);
                //dt = Global.oMySql.GetDataTable("SELECT  CustomerID, Name, EndDate, PickUpDate,  TO_DAYS(EndDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "')) as Days FROM Customer Where (TO_DAYS(EndDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) < 15 And (TO_DAYS(EndDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) > 0 And CompanyID='" + Global.CurrrentCompany + "'");
                dt = Global.oMySql.GetDataTable("SELECT  c.CustomerID, Name, EndDate, PickUpDate,  TO_DAYS(EndDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))  as Days, cc.UserID, cc.EndCompleted as Completed FROM Customer c LEFT JOIN CustomerCalls cc ON c.CompanyID=cc.CompanyID And c.CustomerID = cc.CustomerID  Where (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) < 15 And (TO_DAYS(EndDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) > 0 And c.CompanyID='" + Global.CurrrentCompany + "' And cc.UserID='"+Global.CurrentUser+"'");
                Grid.DataSource = dt;
                Grid.DataBind();
                ActiveRow();
            }
        }

        private void rbPickUpCalls_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DateTime CurDate = DateTime.Now;
            //    CurDate = CurDate.AddDays(80);
                //dt = Global.oMySql.GetDataTable("SELECT  CustomerID, Name, EndDate, PickUpDate,  TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))  as Days  FROM Customer Where (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) < 15 And (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) > 0 And CompanyID='" + Global.CurrrentCompany + "'");
                dt = Global.oMySql.GetDataTable("SELECT  c.CustomerID, Name, EndDate, PickUpDate,  TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))  as Days, cc.UserID, cc.PickUpCompleted as Completed FROM Customer c LEFT JOIN CustomerCalls cc ON c.CompanyID=cc.CompanyID And c.CustomerID = cc.CustomerID  Where (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) < 15 And (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) > 0 And c.CompanyID='" + Global.CurrrentCompany + "' And cc.UserID='" + Global.CurrentUser + "'");
                Grid.DataSource = dt;
                Grid.DataBind();
                ActiveRow();
            }
        }
        

    }
}
