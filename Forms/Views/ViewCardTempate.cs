using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;


namespace Signature
{
    /// <summary>
    /// Summary description for CustomerView.
    /// </summary>
    public class frmViewTemplates : System.Windows.Forms.Form
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

        System.Windows.Forms.ContextMenu contextMenu1;

        public frmViewTemplates()
        {
            //
            // Required for Windows Form Designer support
            //

            

            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call


            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();

            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2, menuItem3 });
            menuItem1.Index = 0;
            menuItem1.Text = "MenuItem1";
            menuItem2.Index = 1;
            menuItem2.Text = "MenuItem2";
            menuItem3.Index = 2;
            menuItem3.Text = "MenuItem3";
            menuItem1.Click += new EventHandler(this.menuitem1_Click);

            //textBox1.ContextMenu = contextMenu1;

            //txtSearch.ContextMenu = contextMenu1;
            Grid.ContextMenu = contextMenu1;
            //
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
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
            this.Label1.Size = new System.Drawing.Size(700, 6);
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
            this.panel1.Size = new System.Drawing.Size(700, 614);
            this.panel1.TabIndex = 1;
            // 
            // Grid
            // 
            ultraGridColumn1.AutoEdit = false;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 33;
            ultraGridColumn2.AutoEdit = false;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 207;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.Location = new System.Drawing.Point(9, 77);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(678, 524);
            this.Grid.TabIndex = 86;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.Grid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
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
            this.GroupBox1.Size = new System.Drawing.Size(695, 42);
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
            this.txtSearch.Size = new System.Drawing.Size(579, 20);
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
            this.btnClose.Location = new System.Drawing.Point(614, 11);
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
            this.Label23.Size = new System.Drawing.Size(698, 10);
            this.Label23.TabIndex = 84;
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(-4, 59);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(699, 10);
            this.pbar.TabIndex = 85;
            // 
            // frmViewTemplates
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(700, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label1);
            this.Name = "frmViewTemplates";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teacher View";
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

            this.Text += " - " + sCompanyID;
            Signature.Data.MySQL oMySql = Global.oMySql;


            dt = oMySql.GetDataView(String.Format("SELECT * FROM CardTemplate"), "CardTemplate");
            
            this.txtSearch.Focus();
            Grid.DataSource = dt;
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
                            sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
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
                            sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
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

            String fld = new string(' ', 100);
            String fld1 = new string(' ', 100);
            fld = "Description";
            fld1 = "FontName";
            dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or " + fld1 + " like '*" + txtSearch.Text + "*'";
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

                if (Grid.ActiveRow != null)
                {
                    sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
                    //  sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
                    this.Close();
                }
            }
            else
            {

                //contextMenu1.Show(Grid, new Point(e.X, e.Y));
            }
        }
        private void menuitem1_Click(object sender, System.EventArgs e)
        {
            if (Grid.ActiveRow != null)
            {
                sSelectedID = Grid.ActiveRow.Cells["ID"].Text;
                MessageBox.Show(sSelectedID);
            }
        }
    }
}
