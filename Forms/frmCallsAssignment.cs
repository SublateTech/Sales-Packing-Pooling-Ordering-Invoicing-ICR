using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

using System.Resources;

using XPTable;
using XPTable.Editors;
using XPTable.Models;


namespace Signature.Forms
{
    public partial class frmCallsAssignment : frmBase

    {
        DataTable dt;
       // String CustomerID = "";
        Customer oCustomer = new Customer();

        System.Windows.Forms.ContextMenu contextMenu1;

        public frmCallsAssignment()
        {
            InitializeComponent();
            LoadCSV();
            LoadTable();
            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            

            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1 });
            menuItem1.Index = 0;
            menuItem1.Text = "Assign to :";
            
            menuItem1.Click += new EventHandler(menuItem1_Click);

            //textBox1.ContextMenu = contextMenu1;

            //txtSearch.ContextMenu = contextMenu1;
            table.ContextMenu = contextMenu1;
        }

        void menuItem1_Click(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            frmCallsAssignUser oFrm = new frmCallsAssignUser();

            User oUser = new User();
            DataTable dt = oUser.GetActiveUsers();
            foreach (DataRow row in dt.Rows)
            {
                oFrm.cbUsers.Items.Add(row["User"].ToString());
            }
            oFrm.ShowDialog();

            if (oFrm.PressedButton == "Apply" && oFrm.UserSelected.Trim() != "")
            {
                CustomerCall oCall = new CustomerCall(this.CompanyID);
                foreach (Row row in this.table.TableModel.Selections.SelectedItems)
                {
                    //MessageBox.Show(row.Cells[0].Text);

                    if (oCall.Find(row.Cells[0].Text))
                    {
                        oCall.FindCall(row.Cells[0].Text);
                        oCall.UserID = oFrm.UserSelected;
                        oCall.Save();

                    }
                }
                frmCallsAssignment_Load(null, null);
            }
        }



        private void LoadCSV()
        {
            //XPListViewItem itm;

            Application.DoEvents();
            this.SuspendLayout();
            this.ResumeLayout();
        }

        private void LoadTable()
        {
            // get the sample images resource
            System.Reflection.Assembly myAssembly;
            myAssembly = this.GetType().Assembly;
            //ResourceManager myManager = new ResourceManager("MediaPlayerStyle.Images", myAssembly);

            this.table.BeginUpdate();

            

            TextColumn CustomerIDColumn = new TextColumn();
            CustomerIDColumn.Text = "Customer ID";
            CustomerIDColumn.ToolTipText = "Customer Contract Number";
            CustomerIDColumn.Width = 85;
            CustomerIDColumn.Editable = false;

            TextColumn NameColumn = new TextColumn();
            NameColumn.Text = "Name";
            NameColumn.ToolTipText = "School Name";
            NameColumn.Width = 220;
            NameColumn.Editable = false;

            TextColumn dateColumn1 = new TextColumn();
            dateColumn1.Text = "EndDate";
            dateColumn1.ToolTipText = "End Date";
            dateColumn1.Width = 100;
            dateColumn1.Editable = false;

            TextColumn dateColumn = new TextColumn();
            dateColumn.Text = "PickUp Date";
            dateColumn.ToolTipText = "PickUpDate";
            dateColumn.Width = 100;
            dateColumn.Editable = false;
            
            ComboBoxColumn UserIDColumn = new ComboBoxColumn();
            UserIDColumn.Text = "User ID";
            UserIDColumn.ToolTipText = "User ID";
            UserIDColumn.Width = 100;
            UserIDColumn.Editable = true;
            UserIDColumn.Editor = GetActiveUsers();


            CheckBoxColumn protectedColumn = new CheckBoxColumn();
            protectedColumn.Alignment = XPTable.Models.ColumnAlignment.Center;
            protectedColumn.DrawText = false;
            protectedColumn.Text = "Completed";
            protectedColumn.ToolTipText = "Completed Call";
            protectedColumn.Width = 80;
            protectedColumn.Editable = false;

            this.table.ColumnModel = new ColumnModel(new Column[] {CustomerIDColumn,
																	  NameColumn,
																	  dateColumn1,
																	  dateColumn,
																	  UserIDColumn,
																	  protectedColumn});

            
            
            this.table.HeaderRenderer = new XPTable.Renderers.GradientHeaderRenderer();
            
            this.table.FullRowSelect = true;

            this.table.EndUpdate();

        }

        private ComboBoxCellEditor GetActiveUsers()
        {
            ComboBoxCellEditor genreEditor = new ComboBoxCellEditor();
            genreEditor.DropDownStyle = DropDownStyle.DropDownList;
            //genreEditor.Items.AddRange(new string[] { "ANGELA", "TERI", "JULIE", "TYFANNY", "MYRNA" });
            User oUser = new User();
            DataTable dt = oUser.GetActiveUsers();
            foreach (DataRow row in dt.Rows)
            {
                genreEditor.Items.Add(row["User"].ToString());
            }
            genreEditor.EndEdit += new XPTable.Events.CellEditEventHandler(genreEditor_EndEdit);
            return genreEditor;
        }

        void genreEditor_EndEdit(object sender, XPTable.Events.CellEditEventArgs e)
        {
            CustomerCall oCall = new CustomerCall(this.CompanyID);
            Row row = this.table.TableModel.Rows[e.Row];
            if (oCall.Find(row.Cells[0].Text))
                {
                    oCall.FindCall(row.Cells[0].Text);
                    oCall.UserID = ((ComboBoxCellEditor)e.Editor).SelectedItem.ToString();
                    oCall.Save();
                    //MessageBox.Show(row.Cells[4].Text);
                }
                //throw new Exception("The method or operation is not implemented.");
        }

        

        private void LoadCalls1()
        {

          
            /*
             this.table.TableModel = new TableModel(new Row[] {new Row(new Cell[] {new Cell("1QQQ20"),
																						new Cell("VISTA ELEMENTARY"),
                                                                                        new Cell(new DateTime(2005, 5, 5, 11, 49, 1, 0)),
                                                                                        new Cell(new DateTime(2005, 5, 5, 11, 49, 1, 0)),
																						new Cell("ANGELA"),
																						new Cell(null, true),
																						})
                                                                                        }
                                                                                        );

            */

            this.table.TableModel = new TableModel();
            //XPListViewItem itm;
            foreach (DataRow row in dt.Rows)
            {
                this.table.TableModel.Rows.Add(new Row(new Cell[] {new Cell(row["CustomerID"].ToString()),
																						new Cell(row["Name"].ToString()),
                                                                                        new Cell(row["EndDate"].ToString().Substring(0,10)),
                                                                                        new Cell(row["PickUpDate"].ToString().Substring(0,10)),
																						new Cell(row["UserID"].ToString()),
																						new Cell(null, row["Completed"]==DBNull.Value? false: (Boolean) row["Completed"]),
																						})
                                                                                        );
            
            }
            //this.table.TableModel.RowHeight += 3;
        }
        private void SaveCalls()
        {
            CustomerCall oCall = new CustomerCall(this.CompanyID);
            foreach (Row row in this.table.TableModel.Rows)
            {
                if (oCall.Find(row.Cells[0].Text))
                {
                    oCall.FindCall(row.Cells[0].Text);
                    oCall.UserID = row.Cells[4].Text;
                    oCall.Save();
                    //MessageBox.Show(row.Cells[4].Text);
                }
            }
        }
        private void frmCallsAssignment_Load(object sender, EventArgs e)
        {
            rbEndCalls_CheckedChanged(rbEndCalls, null);
            rbPickUpCalls_CheckedChanged(rbPickUpCalls, null);
           

        }
        private void rbEndCalls_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                
            }
        }

        private void rbPickUpCalls_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DateTime CurDate = DateTime.Now;
                CurDate = CurDate.AddDays(80);
                dt = Global.oMySql.GetDataTable("SELECT  c.CustomerID, Name, EndDate, PickUpDate,  TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))  as Days, cc.UserID, cc.PickUpCompleted as Completed FROM Customer c LEFT JOIN CustomerCalls cc ON c.CompanyID=cc.CompanyID And c.CustomerID = cc.CustomerID  Where (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) < 15 And (TO_DAYS(PickUpDate) - TO_DAYS(date('" + Global.oMySql.SqlDate(CurDate) + "'))) > 0 And c.CompanyID='" + Global.CurrrentCompany + "'");
                LoadCalls();
            }
        }
 
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveCalls();
            Dispose();
        }

        private void txtDateTo_ValueChanged(object sender, EventArgs e)
        {
            Customer oCustomer = new Customer(CompanyID);

            dt = oCustomer.GetCustomerRange(txtDateFrom.Value, txtDateTo.Value, ( rbEndCalls.Checked ? "End" : "PickUp"));
            LoadCalls();
        }

        private void LoadCalls()
        {
            CustomerCall oCustCall = new CustomerCall(oCustomer.CompanyID);
            
            this.table.TableModel = new TableModel();
            //XPListViewItem itm;
            
            foreach (DataRow row in dt.Rows)
            {
                oCustomer.Find(row["CustomerID"].ToString());
                oCustCall.FindCall(oCustomer.ID);
                this.table.TableModel.Rows.Add(new Row(new Cell[] {new Cell(row["CustomerID"].ToString()),
																   new Cell(oCustomer.Name),
                                                                   new Cell(oMySql.SqlDate(oCustomer.EndDate)),
                                                                   new Cell(oMySql.SqlDate(oCustomer.PickUpDate)),
																   new Cell(oCustCall.UserID),
																   new Cell(false),
																  })
                                                                   );

            }
            //this.table.TableModel.RowHeight += 3;
        }

        private void table_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender == table)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    CustomerCall oCall = new CustomerCall(this.CompanyID);
                    Row row = this.table.TableModel.Selections.SelectedItems[0];
                    if (oCall.Find(row.Cells[0].Text))
                    {
                        oCall.FindCall(row.Cells[0].Text);
                        oCall.UserID = "";
                        oCall.Delete();
                        row.Cells[4].Text = "";
                        //MessageBox.Show(row.Cells[4].Text);
                    }
                }
            }
        }
    }
}