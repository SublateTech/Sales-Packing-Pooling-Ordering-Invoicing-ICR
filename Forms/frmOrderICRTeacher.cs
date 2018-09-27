using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win.UltraWinGrid;

namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmOrderICRTeacher : frmBase
	{
		#region declarations		

        
        #endregion

        private Signature.Windows.Forms.GroupBox groupBox3;
        private UltraGrid Grid;
        
        private Signature.Windows.Forms.GroupBox ultraGroupBox2;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        

        Customer oCustomer;
        ScannedTeachers oTeachers;


        public frmOrderICRTeacher()
		{
			InitializeComponent();
            oCustomer = new Customer(CompanyID);
            oTeachers = new ScannedTeachers(CompanyID);
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Teacher");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BatchID", 0);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(560);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-7);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 479);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.Text = "Teachers";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance1.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grid.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            ultraGridColumn1.Header.Caption = "Teacher Name";
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 538;
            ultraGridColumn2.AutoEdit = false;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            this.Grid.DisplayLayout.InterBandSpacing = 10;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dashed;
            this.Grid.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Dashed;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.Grid.DisplayLayout.Override.CellAppearance = appearance3;
            this.Grid.DisplayLayout.Override.CellPadding = 2;
            this.Grid.DisplayLayout.Override.CellSpacing = 2;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance4.FontData.ItalicAsString = "True";
            appearance4.TextHAlignAsString = "Left";
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BorderColor = System.Drawing.SystemColors.ControlDark;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.DisplayLayout.Override.RowSpacingAfter = 1;
            this.Grid.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance7.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.Grid.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.Grid.Location = new System.Drawing.Point(6, 16);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(562, 457);
            this.Grid.TabIndex = 0;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.AllowDrop = true;
            this.ultraGroupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ultraGroupBox2.Controls.Add(this.txtName);
            this.ultraGroupBox2.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ultraGroupBox2.Location = new System.Drawing.Point(7, 6);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(573, 70);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.FontData.SizeInPoints = 12F;
            this.txtName.Appearance = appearance8;
            this.txtName.Location = new System.Drawing.Point(177, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(357, 19);
            this.txtName.TabIndex = 19;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(110, 21);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(37, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "School:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmOrderICRTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(586, 593);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmOrderICRTeacher";
            this.ShowIcon = true;
            this.Text = "Enter Teachers";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.ultraGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
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
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            
            this.txtCustomerID.Focus();
           
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtCustomerID
            if (sender==txtCustomerID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oCustomer.View())
                    {
                        ShowCustomer();
                        
                        oTeachers.CustomerID = oCustomer.ID;
                        oTeachers.Load(oCustomer.ID);
                        Grid.DataSource = oTeachers.Table;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();
                        return;
                    }
                    
				}

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtCustomerID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtCustomerID.Focus();
                    }

                    if (oCustomer.Find(txtCustomerID.Text))
                    {
                        ShowCustomer();
                        oTeachers.CustomerID = oCustomer.ID;
                        oTeachers.Load(oCustomer.ID);
                        Grid.DataSource = oTeachers.Table;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();

                    }
                    else
                    {
                        Clear();
                        Grid.DataSource = oTeachers.Table;
                        Grid.DataBind();
                        txtName.Focus();
                        
                    }


                    return;

                }					
					

            }
            #endregion
            #region Grid

            if (sender ==Grid)
            {

                
                if (e.KeyCode == Keys.F2)
                {
                    UltraGridRow gridRow;
                    gridRow = Grid.ActiveRow;
                    if (gridRow != null)
                    {
                        if (Grid.ActiveRow.Cells["Teacher"] == Grid.ActiveCell)
                        {
                            /*
                            if (oProduct.View())
                            {
                                 if (!oImages.Items.Contains(Grid.ActiveRow.Cells["ProductID"].Text))
                                {

                                    Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                    Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                    Grid.ActiveRow.Cells["Amount"].Activate();
                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Item already entered");
                                    Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                                    Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                    return;
                                }
                            }
                            */
                        }
                    }
                }
                
                
                if (e.KeyCode == Keys.Delete)
                {
                }


                if (e.KeyCode == Keys.Enter)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = Grid.ActiveRow;
                    if (gridRow != null)
                      {
                          if (Grid.ActiveCell.Text.Trim()!="" && Grid.ActiveRow.Cells["Teacher"] == Grid.ActiveCell )
                          {
                              if (Contain(Grid.ActiveRow.Cells["Teacher"].Text))
                              {
                                  MessageBox.Show("Item already entered");
                                  Grid.ActiveCell = Grid.ActiveRow.Cells["Teacher"];
                                  Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                  Grid.ActiveRow.Cells["Teacher"].Value = "";
                                 
                              }
                              else
                              {
                                  this.MoveLast();
                                 
                              } 
                                
                          }
                          return;
                    
                    }
                    
                }
                
                if (e.KeyCode == Keys.Down )
                {

                    MoveDown();
                    return;
        
                    
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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["Teacher"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
                

            }
            #endregion
            #region txtName
            if (sender == txtName)
            {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                  //  oImages.Description = txtName.Text;
                    Grid.Focus();
                    MoveLast();
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
                    oTeachers.Delete();
                    Clear();
                   // oImages.Items.dtItems.Rows.Clear();
                    Grid.DataBind();
                    txtCustomerID.Clear();
                    txtCustomerID.Focus();
                    break;
                case Keys.PageDown:
                    MoveLast();
                    oTeachers.Save();
                    Grid.DataBind();
                    Clear();
                    txtCustomerID.Clear();
                    txtCustomerID.Focus();
                    break;
                case Keys.Delete:
                    if (e.Control)
                        DeleteItem();
                    break;

					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion
        }
       
        
        private void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.None;
            /*e.Layout.Bands(0).Columns("CurrencyValue").Format = "$#,##0.00"
            e.Layout.Bands(0).Columns("DateValue1").Format = "d" ' this line works
            e.Layout.Bands(0).Columns("DateValue2").Format = "hh:mm:ss"*/
        }
        private void Grid_MouseUp(object sender, MouseEventArgs e)
        {
            //' declare objects to get value from cell and display
            Infragistics.Win.UIElement mouseupUIElement;
            Infragistics.Win.UltraWinGrid.UltraGridCell mouseupCell;

            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {

                //' retrieve the UIElement from the location of the MouseUp
                mouseupUIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

                //' retrieve the Cell from the UIElement
                mouseupCell = mouseupUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell))
                    as Infragistics.Win.UltraWinGrid.UltraGridCell; ;

                //' if there is a cell object reference, set to active cell and edit
                if (!(mouseupCell == null))
                {
                    UltraGridRow aUGRow;
                    Grid.ActiveCell = mouseupCell;

                    aUGRow = Grid.ActiveCell.Row;
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveCell = aUGRow.Cells["Teacher"];


                    Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                }

            }

        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow aUGRow;
            if (Grid.ActiveCell != null)
            {
                aUGRow = Grid.ActiveCell.Row;
                Grid.ActiveCell.Row.Delete();
            }

        }

        #endregion
        
        #region  Methods
        public void MoveDown()
        {
                   Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = Grid.ActiveRow;
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                    if (gridRow != null)
                    {
                        gridRow.Activate();
                        Grid.ActiveCell = Grid.ActiveRow.Cells["Teacher"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }


        }
        public void Save()
        {
            oTeachers.CustomerID = oCustomer.ID;
            

            oTeachers.Save();
            Clear();
            txtCustomerID.Clear();

        }
        public bool ShowCustomer()
        {
            Clear();
            txtName.Text = oCustomer.Name;
            txtCustomerID.Text = oCustomer.ID;
            

            return true;
        }
        public void Clear()
        {
            txtName.Text = "";
            if (oTeachers.Table != null)
                oTeachers.Table.Rows.Clear();
            
        }
        public void MoveLast()
        {
            Grid.Focus();
            if (Grid.Rows.Count ==0)
                oTeachers.AddEmpty();

            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.Rows[0];
            gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Last);
            if (gridRow != null)
            {
                gridRow.Activate();
                Grid.ActiveCell = Grid.ActiveRow.Cells["Teacher"];
                Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);

                if (gridRow.Cells["Teacher"].Text.Trim() != "")
                {   
                    oTeachers.AddEmpty();
                    Grid.DataBind();
                    MoveLast();
                }
            }
            

        }
        private void DeleteItem()
        {
            UltraGridRow aUGRow;
            if (Grid.ActiveCell != null)
            {
                aUGRow = Grid.ActiveCell.Row;
                Grid.ActiveCell.Row.Delete();
            }
            Grid.Focus();
        }
        private Boolean Contain(String Text)
        {

            UltraGridRow Row = Grid.ActiveRow;

            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                //      MessageBox.Show(aUGRow.Cells["ProductID"].Text + Text);
                if (aUGRow.Cells["Teacher"].Text == Text)
                {

                    if (Row == aUGRow)
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }
		#endregion

	}
}
