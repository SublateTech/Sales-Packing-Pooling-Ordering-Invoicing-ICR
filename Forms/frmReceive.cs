using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Signature.Reports;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmReceive : frmBase
	{
		#region declarations		

        
        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtVendorID;
        private Label label9;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Button bCancel;
        private Button bSubmit;
        private Signature.Windows.Forms.MaskedEdit txtOrderID;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtReference;
        private Label label2;
        private UltraGrid Grid;
		#endregion
        
        Vendor      oVendor;
        Receive     oReceive;
        Purchase    oPurchase;
        Product     oProduct;

        public frmReceive()
		{
			InitializeComponent();
            
		}

	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ordered", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Received", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InvCode", 4);
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtReference = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtVendorID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtReference);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtOrderID);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtVendorID);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 20);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(781, 95);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtReference
            // 
            this.txtReference.AllowDrop = true;
            this.txtReference.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReference.Location = new System.Drawing.Point(554, 19);
            this.txtReference.Name = "txtCustomerID";
            this.txtReference.Size = new System.Drawing.Size(102, 20);
            this.txtReference.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(442, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Reference Doc :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            this.txtOrderID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.Location = new System.Drawing.Point(129, 18);
            this.txtOrderID.Name = "txtCustomerID";
            this.txtOrderID.Size = new System.Drawing.Size(102, 20);
            this.txtOrderID.TabIndex = 0;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Purchase Order #:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance1;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(259, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(500, 20);
            this.txtName.TabIndex = 14;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtVendorID
            // 
            this.txtVendorID.AllowDrop = true;
            this.txtVendorID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendorID.Location = new System.Drawing.Point(129, 60);
            this.txtVendorID.Name = "txtCustomerID";
            this.txtVendorID.Size = new System.Drawing.Size(102, 20);
            this.txtVendorID.TabIndex = 1;
            this.txtVendorID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(49, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Vendor ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.Grid);
            this.ultraGroupBox2.Controls.Add(this.bSubmit);
            this.ultraGroupBox2.Controls.Add(this.bCancel);
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 128);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(778, 496);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            ultraGridColumn1.Header.Caption = "ItemID";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 82;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 5;
            ultraGridColumn2.Width = 336;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Format = "";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nn";
            ultraGridColumn3.Width = 77;
            ultraGridColumn4.Header.Caption = "QtyOrd";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 71;
            ultraGridColumn5.Header.Caption = "QtyRcvd";
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.MaskInput = "";
            ultraGridColumn5.Width = 79;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Width = 84;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(6, 12);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(761, 391);
            this.Grid.TabIndex = 16;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.Grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Grid_MouseUp);
            this.Grid.Enter += new System.EventHandler(this.Grid_Enter);
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(494, 455);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(147, 455);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frmReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(795, 664);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmReceive";
            this.ShowInTaskbar = false;
            this.Text = "Receive Purchase Order";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.ultraGroupBox1, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		private void SelectNextControl(object sender, System.Windows.Forms.KeyEventArgs e) 
		{
            switch (e.KeyCode) 
			{ 
				case Keys.Return: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 

					//case Keys.<some key>: 
					// ......; 
					// break; 
			} 
		}
		private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            
            this.Text += " - " + this.CompanyID;
            this.txtOrderID.Text = "";
            this.txtOrderID.Focus();
                        
            oVendor = new Vendor();
            oReceive = new Receive();
            oProduct = new Product();
            oPurchase = new Purchase(CompanyID);
            txtVendorID.Enabled = false;

            //oVendor.ReOrders.SetColumns();
            //Grid.DataSource = oVendor.ReOrders.GetDataTable();
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region Grid
            if (sender == Grid )
            {
                if (Grid.ActiveCell != null)
                {

                    switch (Grid.ActiveCell.Column.Key)
                    {
                        
                        case "Received":

                            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                            {
                                Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Up)
                            {
                                Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            
                            break;
                       
                    }
                }
                return;
            }
            #endregion

            #region txtOrderID
            if (sender == txtOrderID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    
                    if (oPurchase.View(true))
                    {

                        oReceive.FindPurchase(oPurchase.ID);
                        txtOrderID.Text = oReceive.ID;
                        txtVendorID.Text = oReceive.VendID;
                        oVendor.Find(oReceive.VendID);
                        txtName.Text = oVendor.Name;


                        if (oReceive.RItems.Count > 0)
                        {
                            Grid.DataSource = oReceive.RItems;
                            Grid.DataBind();
                            MoveFirst();
                            txtOrderID.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("This PO was already received...");
                        }
                        return;
                        

                    }
                    this.txtName.Text = oVendor.Name;
                    return;

                }
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtOrderID.Text.Trim() == "")
                    {
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }

                    if (oReceive.FindPurchase(txtOrderID.Text))
                    {
                        txtVendorID.Enabled = true;
                        
                        txtVendorID.Text = oReceive.VendID;
                        oVendor.Find(oReceive.VendID);
                        txtName.Text = oVendor.Name;

                        Grid.DataSource = oReceive.Items;
                        MoveFirst();

                        txtOrderID.Enabled = false;
                        return;
                    }
                    else
                    {
                        txtVendorID.Enabled = true;
                        txtVendorID.Focus();
                        
                        return;
                    }

                }

            }
            #endregion

            #region txtVendorID
            if (sender==txtVendorID)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    if (oVendor.View())
                    {
                        this.txtVendorID.Text = oVendor.ID;
                        if (!oVendor.Find(txtVendorID.Text))
                        {

                            this.txtVendorID.Focus();
                            return;
                        }
                        this.txtName.Text = oVendor.Name;
                        Grid.Focus();
                        return;
                        
                     }
                    this.txtName.Text = oVendor.Name;
                    
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!oVendor.Find(txtVendorID.Text))
					{
                        
                        this.txtVendorID.Focus();
						return;
					}
                    this.txtName.Text = oVendor.Name;
                    
                    //Grid.DataSource = oVendor.ReOrders.GetDataTable(oVendor);
                    Grid.Focus();
                    return;
				}

            }
            #endregion
             
            #region Default Option
            //Default option
			switch (e.KeyCode) 
			{
                case Keys.Tab:
                    if (!e.Shift)
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break; 
                case Keys.Enter: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break; 
				case Keys.Down: 
					this.SelectNextControl(this.ActiveControl,true,true,true,true); 
					break;
				case Keys.Up:
                    this.SelectNextControl(this.ActiveControl,false,true,true,true); 
					break;
                case Keys.F3:
                    Delete();
                    break;
                case Keys.PageDown:
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        private void bPrint_Click(object sender, EventArgs e)
        {

            frmViewReport oViewReport = new frmViewReport();
            oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtVendorID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
            oReceive.Reference = txtReference.Text;
            oReceive.VendID = txtVendorID.Text;
            oReceive.PurchaseID = txtOrderID.Text;
            oReceive.Save();
            Clear();
            Grid.DataSource = null;
            Grid.DataBind();
            txtOrderID.Enabled = true;
            txtOrderID.Focus();
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
                
                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }

                //SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Up)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.ActiveRow;
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }

                //SendKeys.Send("{TAB}");
            }
        }

        private void Grid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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


            //MessageBox.Show();
            if (Grid.ActiveRow != null)
            {
                mouseupCell.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
            }
          
        }
        private void Grid_MouseUp1(object sender, MouseEventArgs e)
        {


            //' declare and retrieve a reference to the UIElement
            Infragistics.Win.UIElement aUIElement;

            aUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = aUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow)) as Infragistics.Win.UltraWinGrid.UltraGridRow;


            if (gridRow != null)
            {
                gridRow.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
            }


        }
        private void Grid_AfterCellActivate(object sender, EventArgs e)
        {
            //' declare and retrieve a reference to the UIElement
            

            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.ActiveRow;

            if (gridRow != null)
            {
                //gridRow.Activate();
                //' set ActiveCell
                Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }
        }
        private void Grid_Enter(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.Rows[0];
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }
            else
                txtVendorID.Focus();
        }
        #endregion

        #region  Methods
        
        public void Clear()
        {
            txtOrderID.Clear();
            txtVendorID.Clear();
         //   Grid.Rows.Dispose();
            
            
        }
        public void Delete()
        {

            if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Operation Cancelled");
                return;
            }
            return;
        }
        public void MoveFirst()
        {
            if (Grid.Rows.Count > 0)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                gridRow = Grid.Rows[0];
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
                if (gridRow != null)
                {

                    gridRow.Activate();
                    Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }

        }

	
		#endregion

		

		

        

	}
}
