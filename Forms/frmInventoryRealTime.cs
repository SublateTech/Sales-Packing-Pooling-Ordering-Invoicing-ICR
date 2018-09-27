using System;
using System.Collections;
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
    public partial class frmInventoryRealTime : frmBase

    {
        DataRow row;
       // String CustomerID = "";
        Customer oCustomer = new Customer();
        public ArrayList Products = new ArrayList();

        public Int32 _Top = 0;
        public Int32 _Left = 0;

        System.Windows.Forms.ContextMenu contextMenu1;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();



        public frmInventoryRealTime(String CompanyID)
        {
            InitializeComponent();
            this.CompanyID = CompanyID;
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
            CustomerIDColumn.Text = "Product ID";
            CustomerIDColumn.ToolTipText = "";
            CustomerIDColumn.Width = 85;
            CustomerIDColumn.Editable = false;

            TextColumn NameColumn = new TextColumn();
            NameColumn.Text = "Description";
            NameColumn.ToolTipText = "";
            NameColumn.Width = 220;
            NameColumn.Editable = false;


            NumberColumn dateColumn = new NumberColumn();
            dateColumn.Text = "Assigned";
            dateColumn.ToolTipText = "";
            dateColumn.Width = 80;
            dateColumn.Editable = false;
            dateColumn.Alignment = ColumnAlignment.Right;
            dateColumn.Format = "###.##";
            
            
            TextColumn dateColumn1 = new TextColumn();
            dateColumn1.Text = "Available";
            dateColumn1.ToolTipText = "";
            dateColumn1.Width = 80;
            dateColumn1.Editable = false;

            
            
            TextColumn UserIDColumn = new TextColumn();
            UserIDColumn.Text = "Total";
            UserIDColumn.ToolTipText = "";
            UserIDColumn.Width = 80;
            UserIDColumn.Editable =false;
            //UserIDColumn.Editor = GetActiveUsers();

            /*
            CheckBoxColumn protectedColumn = new CheckBoxColumn();
            protectedColumn.Alignment = XPTable.Models.ColumnAlignment.Center;
            protectedColumn.DrawText = false;
            protectedColumn.Text = "Completed";
            protectedColumn.ToolTipText = "Completed Call";
            protectedColumn.Width = 80;
            protectedColumn.Editable = false;
            */
            this.table.ColumnModel = new ColumnModel(new Column[] {CustomerIDColumn,
																	  NameColumn,
                                                                      dateColumn,
																	  dateColumn1,
																	  UserIDColumn
																	  });

            
            
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
            TimerEventProcessor(null, null);
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 2 * 1000;
            myTimer.Start();
            if (_Left > 0 && _Top > 0)
            {
                this.Left = _Left;
                this.Top = _Top;
            }
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
                myTimer.Stop();
                row = Global.oMySql.GetDataRow(String.Format(@"SELECT sum(SFull) as 'S2 FULL', sum(SHalf) as 'S2 HALF', sum(SLow) AS 'S2 LOW',sum(S1Full) as 'S1 FULL', 
                sum(S1Half) as 'S1 HALF',sum(TBin) AS TBIN,sum(LE1) AS LE1,sum(LE2) AS LE2,sum(LE3) AS LE3,sum(LE4) AS LE4,sum(LE5) AS LE5,sum(LETX) AS LETX,sum(DS) AS DS, 
                sum(BBL) as BBL, sum(BBS) as BBS,sum(MUG) as MUG, sum(LEMUG) as 'LE MUG', sum(PROREG) as 'PROREG',
                sum(LowKit1) as LKIT1
                FROM CustomerGA Where CompanyID='{0}' Group By CompanyID", this.CompanyID), "tmp");

                Console.WriteLine(String.Format(@"SELECT sum(SFull) as 'S2 FULL', sum(SHalf) as 'S2 HALF', sum(SLow) AS 'S2 LOW',sum(S1Full) as 'S1 FULL', 
                sum(S1Half) as 'S1 HALF',sum(TBin) AS TBIN,sum(LE1) AS LE1,sum(LE2) AS LE2,sum(LE3) AS LE3,sum(LE4) AS LE4,sum(LE5) AS LE5,sum(LETX) AS LETX,sum(DS) AS DS, 
                sum(BBL) as BBL, sum(BBS) as BBS,sum(MUG) as MUG, sum(LEMUG) as 'LE MUG', sum(PROREG) as 'PROREG',
                sum(LowKit1) as LKIT1
                FROM CustomerGA Where CompanyID='{0}' Group By CompanyID", this.CompanyID));
                this.LoadCalls();

                myTimer.Enabled = true;
            //    myTimer.Start();
            
        }
        private void LoadCalls()
        {
            this.table.TableModel = new TableModel();
            this.table.TableModel.Rows.Clear();

            if (CompanyID == "GA10")
            {
                AddRecord("S1 FULL", "FKIT1");
                AddRecord("S2 FULL", "KIT 2");
                AddRecord("S2 HALF", "TBKIT2");
                AddRecord("S2 LOW", "TBLKIT1");
                AddRecord("S1 FULL", "FKIT1");
                AddRecord("S1 HALF", "HKIT1");
                AddRecord("LKIT1");
                AddRecord("LOW");
                AddRecord("TBIN", "TBFKIT1");
                AddRecord("LE1");
                AddRecord("LE2");
                AddRecord("LE3");
                AddRecord("LE4", "BAGBOX 2");
                AddRecord("LE5");
                //AddRecord("LETX");
                AddRecord("DS", "TBHKIT1");
                AddRecord("BBL", "BAGBOX 1");
                AddRecord("BBS");
                AddRecord("MUG");
                AddRecord("LE MUG");
                AddRecord("PROREG");

                AddRecord("SREG0");
                AddRecord("SREG10");
                AddRecord("SREG20");
                AddRecord("SREG30");
                AddRecord("TREG0");
                AddRecord("TREG10");
                AddRecord("TREG20");
                AddRecord("TREG30");
                AddRecord("CHEST");
                AddRecord("KIT 2 LOW");
                AddRecord("TBKIT1");

            }
            else if (CompanyID == "GA11")
            {
                
                AddRecord("S2 FULL", "F KIT 1");
                AddRecord("S2 HALF", "TB KIT 1");

                AddRecord("S1 FULL", "F KIT 2");
                AddRecord("S1 HALF", "H KIT 2");
                AddRecord("TBIN"   , "L KIT 2");
                
                
                AddRecord("DS", "TB F KIT 2");
                AddRecord("LKIT1", "TB H KIT 2");
                AddRecord("S2 LOW", "TB L KIT 2");
                
                AddRecord("LE1");
                AddRecord("LE2");
                
                AddRecord("LE3");
                AddRecord("LE4","MUG 2");
                AddRecord("LE5");

                AddRecord("LOW");
                //AddRecord("LETX");
                
                AddRecord("BBL", "BB");
                AddRecord("BBS");
                AddRecord("MUG","MUG 1");
                AddRecord("LE MUG");
                AddRecord("PROREG");

                AddRecord("SREG0");
                AddRecord("SREG10");
                AddRecord("SREG20");
                AddRecord("SREG30");
                AddRecord("TREG0");
                AddRecord("TREG10");
                AddRecord("TREG20");
                AddRecord("TREG30");
                AddRecord("CHEST");
                AddRecord("KIT 2 LOW");
                AddRecord("TBKIT1");

            }
            else
            {
                AddRecord("S2 FULL");
                AddRecord("S2 HALF");
                AddRecord("S2 LOW");
                AddRecord("S1 FULL");
                AddRecord("S1 HALF");
                AddRecord("LOW");
                AddRecord("TBIN");
                AddRecord("LE1");
                AddRecord("LE2");
                AddRecord("LE3");
                AddRecord("LE4");
                AddRecord("LE5");
                //AddRecord("LETX");
                AddRecord("DS");
                AddRecord("BBL");
                AddRecord("BBS");
                AddRecord("MUG");
                AddRecord("LE MUG");
                AddRecord("PROREG");

                AddRecord("SREG0");
                AddRecord("SREG10");
                AddRecord("SREG20");
                AddRecord("SREG30");
                AddRecord("TREG0");
                AddRecord("TREG10");
                AddRecord("TREG20");
                AddRecord("TREG30");
                AddRecord("CHEST");
            }
            
            
            
            



            /*
            AddRecord("BAGBOX");
            AddRecord("FKIT1");
            AddRecord("HKIT1");
            AddRecord("KIT 2");
            AddRecord("LE1");
            AddRecord("LKIT1");
            AddRecord("MUG");
            AddRecord("REG");
            AddRecord("STOCK");
            AddRecord("TBKIT1");
            AddRecord("TBKIT2");
            AddRecord("TC");
            AddRecord("TBLKIT1");
            AddRecord("TBHKIT1");
        */

            //this.table.TableModel.RowHeight += 3;
        }

        private void AddRecord(String ProductID)
        {
            AddRecord(ProductID, ProductID);
        }
        
        private void AddRecord(String ProductID, String Alias)
        {
            //XPListViewItem itm;
            Product oProduct = new Product(this.CompanyID);
            
            if (oProduct.Find(Alias))
            {
                Int32 Used = 0;
                if (",S2 FULL,S2 HALF,S2 LOW,TBIN,LE1,LE2,LE3,LE4,LE5,LETX,DSK,S1 FULL,S1 HALF,BBL,BBS,MUG,LE MUG,PROREG,LKIT1,".Contains(","+ProductID+","))
                {
                    Used = Convert.ToInt32(row[ProductID].ToString());
                }else
                    Used = oProduct.Sold + oProduct.Committed;
                
                this.table.TableModel.Rows.Add(new Row(new Cell[] {new Cell(oProduct.ID),
																   new Cell(oProduct.Description),
                                                                   new Cell(Used),       
                                                                   new Cell((oProduct.Received - Used).ToString()),
                                                                   new Cell(oProduct.Received.ToString())
																  })
                                                                   );
            }
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
        private void frmInventoryRealTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            myTimer.Dispose();
        }
        private void frmInventoryRealTime_Shown(object sender, EventArgs e)
        {
            
        }
    }
}