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
	public sealed class frmProductCompound : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox ultraGroupBox1;
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Button bCancel;
        private Button bSubmit;
        public Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label1;
		#endregion
        
        private     Product     oProduct;
        private UltraGrid Grid;
        private Infragistics.Win.Misc.UltraLabel txtDescription;
       
        

        public frmProductCompound()
		{
			InitializeComponent();
            if (txtProductID.Text.Trim() != "")
                Grid.Focus();
            
		}

	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Seq", 3);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(568);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(57);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion3 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-106);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Signature.Windows.Forms.GroupBox();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new Infragistics.Win.Misc.UltraLabel();
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
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 689);
            this.txtStatus.Size = new System.Drawing.Size(580, 29);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 1);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(563, 95);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(129, 25);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(102, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Compound Item #:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance2;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(237, 25);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(395, 20);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.Grid);
            this.ultraGroupBox2.Controls.Add(this.bSubmit);
            this.ultraGroupBox2.Controls.Add(this.bCancel);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 102);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(563, 583);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            ultraGridColumn1.Header.Caption = "Item#";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 81;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MinLength = 35;
            ultraGridColumn2.MinWidth = 200;
            ultraGridColumn2.Width = 315;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance4;
            ultraGridColumn3.Format = "$####.00";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}nnnnnnn.nn";
            ultraGridColumn3.Width = 57;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance5;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.PromptChar = ' ';
            ultraGridColumn4.Width = 61;
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
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion3);
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid.DisplayLayout.Override.RowAlternateAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.DarkGray;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance7;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(9, 13);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(535, 503);
            this.Grid.TabIndex = 16;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(328, 545);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(116, 545);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frmProductCompound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(580, 718);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmProductCompound";
            this.ShowInTaskbar = false;
            this.Text = "Compound Product";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Controls.SetChildIndex(this.txtStatus, 0);
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
        
	    private void frmOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		//	e.Cancel = true;	

		}
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            oProduct = new Product(CompanyID);
            
            this.Text += " - " + this.CompanyID;
            oProduct.Find(txtProductID.Text);
            txtDescription.Text = oProduct.Description;
            oProduct.Items.Load();
            Grid.DataSource = oProduct.Items.dtItems; //oProduct.Items;
            MoveLast();
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //MessageBox.Show(e.KeyCode.ToString());
            #region Grid
            if (sender == Grid )
            {
                
                if (Grid.ActiveRow != null)
                {
                    if (e.KeyCode == Keys.Delete)
                        if (e.Shift && Grid.GetRow(ChildRow.Last) != Grid.ActiveRow)
                        {
                            Grid.ActiveRow.Delete();
                            MoveLast();
                            return;
                        }
              
                    switch (Grid.ActiveCell.Column.Key)
                    {
                        case "ProductID":
                            {
                                if (e.KeyCode == Keys.F2)
                                {
                                    if (oProduct.View())
                                    {
                                        Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                        Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                        Grid.ActiveRow.Cells["Price"].Value = oProduct.Price;
                                        Grid.ActiveRow.Cells["Quantity"].Value = 1;
                                        Grid.ActiveRow.Cells["Quantity"].Activate();
                                        Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    }

                                }
                                if (e.KeyCode == Keys.Return)
                                {
                                    if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text)) //(!oProduct.Items.Contains(Grid.ActiveRow.Cells["ProductID"].Text))
                                    {

                                        if (oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                                        {
                                            Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                            Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                            Grid.ActiveRow.Cells["Price"].Value = oProduct.Cost;
                                            Grid.ActiveRow.Cells["Quantity"].Value = 1;
                                            Grid.ActiveRow.Cells["Quantity"].Activate();
                                            Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                                            Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                        }

                                    }
                                    else
                                    {
                                        
                                        MessageBox.Show("Item already entered");
                                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                        return;
                                    }
                                }
                                if (e.KeyCode == Keys.Down)
                                {
                                    Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Up)
                                {
                                    
                                    Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Right)
                                {

                                    Grid.PerformAction(UltraGridAction.NextCellByTab, false, false);
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["Cases"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }

                            }

                            break;
                        
                        case "Quantity":
                            if (e.KeyCode == Keys.Return)
                            {
                                if (Grid.ActiveRow.Cells["ProductID"].Text != "" && !Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {
                                                                        
                                    if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                                    {
                                        oProduct.Items.AddEmpty();
                                        Grid.DataBind();
                                        MoveLast();
                                        //Grid.PerformAction(UltraGridAction.LastRowInBand, false, false);
                                    }
                                    else
                                    {
                                        Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                        Grid.ActiveRow.Cells["ProductID"].Activate();
                                        Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    }

                                }
                                else
                                {
                                    Grid.ActiveRow.Cells["ProductID"].Activate();
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                    Grid.ActiveRow.Cells["Quantity"].Value = 1;
                                }
                                return;
                            }
                            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                            {
                                Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            if (e.KeyCode == Keys.Up)
                            {
                                Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                Grid.ActiveCell = Grid.ActiveRow.Cells["Quantity"];
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
                            
                            break;
                        default:
                            {
                                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
                                {
                                    Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                    //Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }
                                if (e.KeyCode == Keys.Up)
                                {
                                    Grid.PerformAction(UltraGridAction.PrevRowByTab, false, false);
                                    //Grid.ActiveCell = Grid.ActiveRow.Cells["Received"];
                                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                                }

                                

                               
                            }
                            break;
                    }
                }
                return;
            }
            #endregion

            #region txtOrderID
            if (sender == txtProductID)
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (oProduct.View())
                    {

                        txtProductID.Text = oProduct.ID;
                       // txtVendorID.Text = oProduct.VendID;
                      //  oVendor.Find(oProduct.VendID);
                      //  txtName.Text = oVendor.Name;

                        Grid.DataSource = oProduct.Items.dtItems; //oProduct.Items;
                        Grid.DataBind();
                        MoveLast();

                        txtProductID.Enabled = false;

                        return;
                        

                    }else
                        Grid.Height = 529;
                    //this.txtDescription.Text = 
                    return;

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (txtProductID.Text.Trim() == "")
                    {
                        txtProductID.Clear();
                        txtProductID.Focus();
                        return;
                    }

                    if (oProduct.Find(txtProductID.Text))
                    {
                        
                        
                       // txtVendorID.Text = oProduct.VendID;
                       // oVendor.Find(oProduct.VendID);
                       // txtName.Text = oVendor.Name;

                        
                        //Grid.DataSource = oProduct.Items;
                        Grid.DataSource = oProduct.Items.dtItems; //oProduct.Items;
                        MoveLast();

                        txtProductID.Enabled = false;
                        return;
                    }
                    else
                    {
                        
                        return;
                    }

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
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    break;
                case Keys.Delete:
                    if (!e.Control)
                        Grid.ActiveRow.Delete();
                    break; 


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
        private void bPrint_Click(object sender, EventArgs e)
        {

           // frmViewReport oViewReport = new frmViewReport();
           // oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtVendorID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
            oProduct.Items.Save(this.CompanyID,this.txtProductID.Text);
            Clear();
            this.Close();
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

        #endregion

        #region  Methods
        public void Clear()
        {
            Grid.Rows.Dispose();
        }
        public DataTable GetDetail()
        {
          return oMySql.GetDataTable(String.Format("SELECT r.Reference, pd.ProductID, p.Description,  rd.Quantity, r.Date FROM ReceiveDetail pd  Left Join Product p on pd.CompanyID=p.CompanyID And pd.ProductID=p.ProductID Left Join ReceiveDetail rd on pd.CompanyID=rd.CompanyID and pd.ProductID=rd.ProductID  Left Join Receive r on rd.CompanyID=r.CompanyID and rd.PurchaseID=r.PurchaseID  and rd.ReceiveID=r.ReceiveID Where pd.CompanyID='"+CompanyID+"' And pd.Quantity is not null and pd.PurchaseID='{0}' Order By  pd.ProductID", txtProductID.Text), "tmp");
        }
        public void deleteOrder()
        {

            if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                MessageBox.Show("Operation Cancelled");
                return;
            }
            return;
        }
        public void MoveLast()
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.Rows[0];
            gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Last);
            if (gridRow != null)
            {

                gridRow.Activate();
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }


        }
		#endregion


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
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
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
                Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
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
                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }
            else
                txtProductID.Focus();
        }

        private Boolean Contain(String Text)
        {

            UltraGridRow Row = Grid.ActiveRow;

            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
          //      MessageBox.Show(aUGRow.Cells["ProductID"].Text + Text);
                if (aUGRow.Cells["ProductID"].Text == Text)
                {

                    if (Row == aUGRow)
                        return false;
                    else
                        return true;
                }     
            }

            return false;
        }

	}
}
