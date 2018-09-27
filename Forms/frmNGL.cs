using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using MySql.Data.MySqlClient;

namespace Signature.Forms
{
    public partial class frmNGL : Form
    {
        //DataTable ds = Global.oMySql.GetDataTable("Select * from NGL_Pastors","NGL");
        private MySqlConnection conn = null;
        private MySqlDataAdapter da;
        private MySqlCommandBuilder cb;
        private DataTable dt;

        public frmNGL()
        {
            InitializeComponent();
        }

        private void frmNGL_Load(object sender, EventArgs e)
        {

            Refresh();

        }

        private void Grid_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {

            this.Update();
            //Grid.DataBind();
            //MoveLast();
        }

        private void Grid_AfterRowsDeleted(object sender, EventArgs e)
        {
            
            this.Update();
            Grid.DataBind();
            MoveLast();
        }

        private void Grid_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.Update();

        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                Grid.UpdateData();
                this.Update();
            }
        }

        new void  Update()
        {
            
            DataTable gridDataTable = (DataTable)Grid.DataSource;

            //' send changes to database 
            da.InsertCommand.Connection = conn;
            da.DeleteCommand.Connection = conn;
            da.UpdateCommand.Connection = conn;
            da.Update(gridDataTable);
            
        }
        public void MoveLast()
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.Rows[0];
            gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Last);
            if (gridRow != null)
            {
                gridRow.Activate();
                Grid.ActiveCell = Grid.ActiveRow.Cells["ChurchName"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow, false, false);
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }


        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            Refresh();

        }

        new void Refresh()
        {
            string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                "lserver", "SigData", "SigData009", "SigData");

            conn = new MySqlConnection(connStr);
            // To emulate a long-running query, wait for a few seconds before retrieving the real data.
            MySqlCommand command = null;


            DataTable s = new DataTable(); ;
            command = new MySqlCommand();

            command.CommandText = "Select * from NGL_Pastors";

            command.Connection = conn;
            conn.Open();


            dt = new DataTable();
            da = new  MySqlDataAdapter(command.CommandText, conn);

            cb = new  MySqlCommandBuilder(da);
            //da.SelectCommand = command;
            da.InsertCommand = cb.GetInsertCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.UpdateCommand = cb.GetUpdateCommand();

            this.da.Fill(dt);

            Grid.DataSource = dt;
            Grid.DataBind();
            MoveLast();
        }


    }
}
