using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;
using Signature.Forms;


namespace Signature
{
    /// <summary>
    /// Summary description for CustomerView.
    /// </summary>
    public class frmViewTicketsByOrder : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.Label Label1;
        private System.ComponentModel.IContainer components;

        private DataView dt;
        public String sSelectedID = "";
        private String sCompanyID = "";
        public String CustomerID="";
        private Panel panel1;
        internal Label Label23;
        internal ProgressBar pbar;
        internal Signature.Windows.Forms.GroupBox GroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtSearch;
        internal Signature.Windows.Forms.Button btnClose;
        private UltraGrid Grid;
        private Int32 OrderID=0;
        private String ProductID = "";
        private Order oOrder;
        public Boolean Modified = false;

        System.Windows.Forms.ContextMenu contextMenu1;

        public OrderProcess Type = OrderProcess.Ticket;

        
        public frmViewTicketsByOrder(Order oOrder, String ProductID)
        {
            this.oOrder = oOrder;
            this.OrderID = Convert.ToInt32(oOrder.ID);
            this.ProductID = ProductID;
            InitializeComponent();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OrderID", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lines", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsWebCustomer", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsGiftAvenue", 3);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(504);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-7);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.GroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtSearch = new Signature.Windows.Forms.MaskedEdit();
            this.btnClose = new Signature.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(15, 15);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(528, 6);
            this.Label1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Grid);
            this.panel1.Controls.Add(this.GroupBox1);
            this.panel1.Controls.Add(this.Label23);
            this.panel1.Controls.Add(this.pbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 615);
            this.panel1.TabIndex = 1;
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 351;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Order ID";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 114;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 361;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.Location = new System.Drawing.Point(9, 77);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(506, 524);
            this.Grid.TabIndex = 86;
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            // 
            // GroupBox1
            // 
            this.GroupBox1.AllowDrop = true;
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Appearance = appearance1;
            this.GroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.btnClose);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(0, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(523, 42);
            this.GroupBox1.TabIndex = 83;
            this.GroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtSearch
            // 
            this.txtSearch.AllowDrop = true;
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(14, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(407, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.AllowDrop = true;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(442, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 24);
            this.btnClose.TabIndex = 67;
            this.btnClose.Tag = "";
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label23
            // 
            this.Label23.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label23.Location = new System.Drawing.Point(0, 0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(526, 10);
            this.Label23.TabIndex = 84;
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(-4, 59);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(527, 10);
            this.pbar.TabIndex = 85;
            // 
            // frmViewTicketsByOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label1);
            this.Name = "frmViewTicketsByOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tickets View";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        private void frmCustomerView_Load(object sender, System.EventArgs e)
        {

            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();

            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2, menuItem3 });

            menuItem1.Index = 0;
            menuItem1.Text = "Add";
            menuItem2.Index = 0;
            menuItem2.Text = "Edit";
            menuItem3.Index = 1;
            menuItem3.Text = "Delete";
            
            menuItem2.Click += new EventHandler(this.menuitem1_Click);
            menuItem3.Click += new EventHandler(this.menuitem3_Click);
            menuItem1.Click += new EventHandler(this.menuitem2_Click);

            //textBox1.ContextMenu = contextMenu1;

            //txtSearch.ContextMenu = contextMenu1;
            Grid.ContextMenu = contextMenu1;
            //
            
            
            
            this.Text += " - " + sCompanyID;
            LoadTickets();
         
        }
        private void LoadTickets()
        {

            this.txtSearch.Focus();
            Grid.DataSource = oOrder.Items[this.ProductID].Tickets;
            Grid.DataBind();
        }

        private void txtControl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            #region txtSearch
            if (sender == txtSearch)
            {
                if (e.KeyCode == Keys.Tab)
                {

                    Grid.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {

                    if (Grid.Rows.Count > 0)
                    {
                        UltraGridRow aUGRow = Grid.Rows[0];
                        Grid.ActiveRow = aUGRow;
                        if (Grid.ActiveRow != null)
                            sSelectedID = Grid.ActiveRow.Cells["TicketID"].Text;
                        this.Close();

                    }
                    else
                        this.Close();

                    return;
                }


            }
            #endregion

            #region Grid
            if (sender == Grid)
            {

                if (e.KeyCode == Keys.Tab)
                {
                    txtSearch.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {

                    if (Grid.Rows.Count > 0)
                    {
                        if (Grid.ActiveRow != null)
                            sSelectedID = Grid.ActiveRow.Cells["TicketID"].Text;
                        this.Close();

                    }

                    return;
                }

            }
            #endregion

            #region Default Option
            //Default option
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Grid.Focused)
                        if (Grid.Rows.Count == 0)
                        {
                        }
                        else if (Grid.ActiveRow == Grid.Rows[0])
                        {
                            txtSearch.Focus();
                        }
                        else
                            Grid.PerformAction(UltraGridAction.AboveCell, false, false);
                    e.Handled = true;
                    break;
                case Keys.Down:
                    if (txtSearch.Focused && Grid.Rows.Count > 0)
                        Grid.Focus();
                    Grid.PerformAction(UltraGridAction.BelowCell, false, false);
                    e.Handled = true;

                    break;
                case Keys.Right:
                    //UltraGrid1.PerformAction(ExitEditMode, False, False)
                    Grid.PerformAction(UltraGridAction.NextCellByTab, false, false);
                    e.Handled = true;
                    //UltraGrid1.PerformAction(EnterEditMode, False, False)
                    break;
                case Keys.Left:
                    //UltraGrid1.PerformAction(ExitEditMode, False, False)
                    Grid.PerformAction(UltraGridAction.PrevCellByTab, false, false);
                    e.Handled = true;
                    //UltraGrid1.PerformAction(EnterEditMode, False, False)
                    break;
                case Keys.Enter:
                    DataGrid_MouseUp(null, null);
                    e.Handled = true;
                    break;

            }
            #endregion

        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void txtSearch_TextChanged_1(object sender, System.EventArgs e)
        {

            
            String fld = "TicketID";
            String fld1 = "Student";
            String fld2 = "CustomerID";
            String fld3 = "ID";


            dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or " + fld1 + " like '*" + txtSearch.Text + "*' or " + fld2 + " like '*" + txtSearch.Text + "*' or " + fld3 + " like '*" + txtSearch.Text + "*'";
            Grid.DataSource = dt;


        }
        private void DataGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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
            Grid.ActiveCell = mouseupCell;
            if (e.Button == MouseButtons.Left)
            {
                if (this.Type == OrderProcess.CustomOrder)
                {
                    menuitem1_Click(null, null);
                    return;
                }

                if (Grid.ActiveRow != null)
                {
                    sSelectedID = Grid.ActiveRow.Cells["TicketID"].Text;
                    //  sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
                    this.Close();
                }
            }
            else
            {

                
            }
        }
        private void menuitem1_Click(object sender, System.EventArgs e)
        {
            if (Grid.ActiveRow != null)
            {

                try
                {
                 
                        sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
                 
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (Convert.ToInt32(Grid.ActiveRow.Cells["ID"].Text) > 0)
                {
                    //MessageBox.Show(sSelectedID);
                    //Ticket oTicket = new Ticket(Global.CurrrentCompany);
                    //oTicket.Find(Convert.ToInt32(Grid.ActiveRow.Cells["ID"].Text));

                    Ticket oTicket = oOrder.Items[ProductID].Tickets[Grid.ActiveRow.Cells["ID"].Text];
                    frmTicket frm = new frmTicket(oTicket);
                    frm.ticketProcess = frmTicket.TicketProcess.OrderEdit;
                    frm.gEnvelope.Visible = oTicket.IsBussines;
                    frm.TopMost = true;
                    frm.txtQuantity.Visible = true;
                    frm.ShowDialog();
                    if (frm.isModified)
                        oOrder.Items[ProductID].Tickets.Load(oOrder, ProductID);
                    LoadTickets();
                }
            }
        }
        private void menuitem3_Click(object sender, System.EventArgs e)
        {
            if (Grid.ActiveRow != null)
            {
                sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
                //MessageBox.Show(sSelectedID);
                //Ticket oTicket = new Ticket(Global.CurrrentCompany);
                //oTicket.Find(Convert.ToInt32(Grid.ActiveRow.Cells["TicketID"].Text));
                //oTicket.Delete();
                Int32 _Ticket = Convert.ToInt32(Grid.ActiveRow.Cells["ID"].Text);


                if (oOrder != null && _Ticket > 0)
                {
                    for (int i = 0; i < oOrder.Items[ProductID].Tickets.Count; i++)
                    {
                        if (oOrder.Items[ProductID].Tickets[i].ID == _Ticket)
                        {
                            oOrder.Items[ProductID].Tickets[i].Delete();
                            oOrder.Items[ProductID].Tickets.Remove(i);
                        }
                    }
                }
                LoadTickets();

            }
        }
        private void menuitem2_Click(object sender, System.EventArgs e)
        {   
                    //MessageBox.Show(sSelectedID);
                    //Ticket oTicket = new Ticket(Global.CurrrentCompany);
                    //oTicket.Find(Convert.ToInt32(Grid.ActiveRow.Cells["ID"].Text));

                    Ticket oTicket = new Ticket(Global.CurrrentCompany);
                    oTicket.OrderID = Convert.ToInt32(oOrder.ID);
                    oTicket.Quantity = 1;
                    oTicket.ProductID = ProductID;
                    frmTicket frm = new frmTicket(oTicket);
                    frm.ticketProcess = frmTicket.TicketProcess.OrderEdit;
                    frm.gEnvelope.Visible = false;
                    frm.TopMost = true;
                    frm.txtQuantity.Visible = true;
                    frm.ShowDialog();
                    if (oTicket.ID != 0)
                    {
                        oTicket.Find(oTicket.ID);
                        oOrder.Items[this.ProductID].Tickets.Add(oTicket.ID.ToString(), oTicket);
                    }
                    LoadTickets();
        }
    }
}
