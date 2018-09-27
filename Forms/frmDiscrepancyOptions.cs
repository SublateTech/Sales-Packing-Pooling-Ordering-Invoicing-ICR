using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Infragistics.Win.UltraWinGrid;


namespace Signature.Forms
{
	/// <summary>
	/// Summary description for CustomerView.
	/// </summary>
	public class frmDiscrepancyOptions : frmBase
    {
        internal System.Windows.Forms.ImageList ImageList1;
		private System.ComponentModel.IContainer components;

		private DataTable dt;
        public String sSelectedID = "";
        private Panel panel1;
        private UltraGrid Grid;
		

        public frmDiscrepancyOptions()
		{
			//
			// Required for Windows Form Designer support
			//
			
			
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 385);
            this.txtStatus.Size = new System.Drawing.Size(558, 29);
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(15, 15);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Grid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 385);
            this.panel1.TabIndex = 76;
            // 
            // Grid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 71;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 556;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.Grid.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.Grid.DisplayLayout.Override.RowAppearance = appearance4;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(558, 385);
            this.Grid.TabIndex = 83;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            // 
            // frmDiscrepancyOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(558, 414);
            this.Controls.Add(this.panel1);
            this.Name = "frmDiscrepancyOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Discrepancy Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
			
		
		
		private void frmCustomerView_Load(object sender, System.EventArgs e)
		{

            this.Text += " - " + CompanyID;

            dt = GetDataTable();
			Grid.DataSource = dt;
		}
        
        private void txtControl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            
            #region Grid
            if (sender == Grid)
            {
                
                if (e.KeyCode == Keys.Tab)
                {
                    //txtSearch.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {

                    if (Grid.Rows.Count > 0)
                    {
                        if (Grid.ActiveRow != null)
                            sSelectedID = Grid.ActiveRow.Cells["Description"].Text;
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
                            ;//txtSearch.Focus();
                        }else
                            Grid.PerformAction(UltraGridAction.AboveCell, false, false);
                    e.Handled = true;
                    break;
                case Keys.Down:
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
		
			String  fld= new string(' ',100);
			String  fld1= new string(' ',100);
			fld = "CustomerID";
			fld1 = "Name";
			//dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or "+fld1 + " like '*" + txtSearch.Text  + "*'";
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
            
                 if (Grid.ActiveRow != null)
                 {
                     sSelectedID = Grid.ActiveRow.Cells["Description"].Text;
                     //  sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
                     this.Close();
                 }
		
		}

        private DataTable GetDataTable()
        {
            DataTable dtItems = new DataTable("Descriptions");

            DataColumn colWork = new DataColumn("ID", Type.GetType("System.Int32"));
            dtItems.Columns.Add(colWork);

            colWork = new DataColumn("Description", Type.GetType("System.String"));
            dtItems.Columns.Add(colWork);

            DataRow row;

            row = dtItems.NewRow();
            row["ID"] = 1;
            row["Description"] = "IT APPEARS NOT ENOUGH MONEY WAS TURNED IN WITH ORDER FORM.";
            dtItems.Rows.Add(row);

            row = dtItems.NewRow();
            row["ID"] = 2;
            row["Description"] = "APPARENTLY TOO MUCH MONEY WAS TURNED IN WITH ORDER FORM. PLEASE SEE SCHOOL FOR REFUND.";
            dtItems.Rows.Add(row);

            row = dtItems.NewRow();
            row["ID"] = 3;
            row["Description"] = "APPARENTLY TOO MUCH MONEY WAS TURNED IN WITH ORDER FORM. YOU MAY WISH TO ORDER ADDITIONAL ITEM(S). PLEASE CALL US AS SOON AS POSSIBLE SO WE MAY INCLUDE THEM WITH YOUR ORDER.";
            dtItems.Rows.Add(row);

            row = dtItems.NewRow();
            row["ID"] = 4;
            row["Description"] = "IT APPEARS THE ORDER FORM MAY HAVE BEEN TOTALED INCORRECTLY.";
            dtItems.Rows.Add(row);

            row = dtItems.NewRow();
            row["ID"] = 5;
            row["Description"] = "APPARENTLY NO MONEY WAS TURNED IN WITH THE ORDER FORM OR THE AMOUNT TURNED IN WAS NOT WRITTEN IN THE \"SCHOOL USE ONLY\" BOX.";
            dtItems.Rows.Add(row);
            return dtItems;
        }

	}
}
