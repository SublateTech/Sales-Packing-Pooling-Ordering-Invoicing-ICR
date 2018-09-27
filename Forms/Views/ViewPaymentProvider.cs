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
	public class frmViewPaymentProvider : System.Windows.Forms.Form
    {
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.Label Label1;
		internal Signature.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Label Label23;
		internal System.Windows.Forms.ProgressBar pbar;
		private System.ComponentModel.IContainer components;

		private DataView dt;
		public String sSelectedID = "";
        private Infragistics.Win.UltraWinGrid.UltraGrid Grid;
        private Signature.Windows.Forms.MaskedEdit txtSearch;
		private String sCompanyID = "";
        private String PurchaseID = "";

        public frmViewPaymentProvider(String sCompanyID, String PurchaseID)
		{
			//
			// Required for Windows Form Designer support
			//
			
			this.sCompanyID = sCompanyID;
            this.PurchaseID = PurchaseID;

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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChargeID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Date", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Comment", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Type", 3);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtSearch = new Signature.Windows.Forms.MaskedEdit();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
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
            this.Label1.Location = new System.Drawing.Point(0, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(495, 6);
            this.Label1.TabIndex = 79;
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
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(4, 16);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(417, 42);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // txtSearch
            // 
            this.txtSearch.AllowDrop = true;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(3, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(411, 20);
            this.txtSearch.TabIndex = 68;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(431, 28);
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
            this.Label23.Size = new System.Drawing.Size(495, 10);
            this.Label23.TabIndex = 75;
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbar
            // 
            this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar.Location = new System.Drawing.Point(4, 64);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(487, 10);
            this.pbar.TabIndex = 78;
            // 
            // Grid
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "Charge ID";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 90;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 79;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 268;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 86;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 31;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.Grid.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.Grid.DisplayLayout.Override.RowAppearance = appearance5;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance6.BorderColor = System.Drawing.Color.Black;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(3, 75);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(485, 327);
            this.Grid.TabIndex = 82;
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtControl_KeyUp);
            // 
            // frmViewPaymentProvider
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(495, 414);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.pbar);
            this.Name = "frmViewPaymentProvider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payments View";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCustomerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
			
		
		
		private void frmCustomerView_Load(object sender, System.EventArgs e)
		{

            this.Text += " - " + sCompanyID;
            Signature.Data.MySQL oMySql = Global.oMySql;
            if (PurchaseID !="")
                        dt = oMySql.GetDataView(String.Format("Select PaymentID, Comment, Date, Amount,Type  from PaymentProvider  Where CompanyID='{0}' And PurchaseID='{1}' Order By Date",sCompanyID,PurchaseID), "Tmp");
            else
                dt = oMySql.GetDataView(String.Format("Select PaymentID, Comment, Date, Amount,Type  from PaymentProvider  Where CompanyID='{0}' Order By Date", sCompanyID), "Tmp");
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

                    MessageBox.Show("Tab");
                    Grid.Focus();
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
                        }else
                            Grid.PerformAction(UltraGridAction.AboveCell, false, false);
                    e.Handled = true;
                    break;
                case Keys.Down:
                    if (txtSearch.Focused && Grid.Rows.Count > 0 )
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
		
			String  fld= new string(' ',100);
			String  fld1= new string(' ',100);
			fld = "PaymentID";
			fld1 = "Comment";
			dt.RowFilter = fld + " like '*" + txtSearch.Text + "*' or "+fld1 + " like '*" + txtSearch.Text  + "*'";
			Grid.DataSource = dt;

		
		}

		private void DataGrid_DoubleClick(object sender, System.EventArgs e)
		{
				//sSelectedID = Grid[DataGrid.CurrentRowIndex, 0].ToString();
				this.Close();
			
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
                    sSelectedID = Grid.ActiveRow.Cells["PaymentID"].Text;
                    //  sSelectedID = DataGrid[DataGrid.CurrentRowIndex, 0].ToString();
                    this.Close();
                }
            }
            else
            {

                //contextMenu1.Show(Grid, new Point(e.X, e.Y));
            }
        }

	}
}
