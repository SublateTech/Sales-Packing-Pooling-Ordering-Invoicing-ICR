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
	public sealed class frmPrize : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
		private Signature.Windows.Forms.MaskedEdit txtPrizeID;
        private Signature.Windows.Forms.MaskedEdit txtDescription;
        private Label label1;
        
        #endregion

        private Signature.Windows.Forms.GroupBox groupBox3;
        private UltraGrid Grid;
        Prize  oPrize;
        private Signature.Windows.Forms.MaskedLabel txtPTDescription;
        private Signature.Windows.Forms.MaskedEdit txtProductTypeID;
        private Label label2;
        Product oProduct;
        Pack oPack;

        
        public frmPrize()
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BreakLevel", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 3);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtPTDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductTypeID = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrizeID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 585);
            this.txtStatus.Size = new System.Drawing.Size(688, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtPTDescription);
            this.groupBox2.Controls.Add(this.txtProductTypeID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPrizeID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 130);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtPTDescription
            // 
            this.txtPTDescription.AllowDrop = true;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.txtPTDescription.Appearance = appearance2;
            this.txtPTDescription.Location = new System.Drawing.Point(234, 86);
            this.txtPTDescription.Name = "txtDescription";
            this.txtPTDescription.Size = new System.Drawing.Size(315, 23);
            this.txtPTDescription.TabIndex = 45;
            this.txtPTDescription.TabStop = true;
            this.txtPTDescription.Value = null;
            // 
            // txtProductTypeID
            // 
            this.txtProductTypeID.AllowDrop = true;
            this.txtProductTypeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductTypeID.Location = new System.Drawing.Point(140, 87);
            this.txtProductTypeID.Name = "txtCustomerID";
            this.txtProductTypeID.Size = new System.Drawing.Size(80, 20);
            this.txtProductTypeID.TabIndex = 44;
            this.txtProductTypeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Product Type ID:";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Location = new System.Drawing.Point(140, 61);
            this.txtDescription.Name = "txtCustomerID";
            this.txtDescription.Size = new System.Drawing.Size(325, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(48, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Description:";
            // 
            // txtPrizeID
            // 
            this.txtPrizeID.AllowDrop = true;
            this.txtPrizeID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPrizeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrizeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrizeID.Location = new System.Drawing.Point(140, 29);
            this.txtPrizeID.Name = "txtCustomerID";
            this.txtPrizeID.Size = new System.Drawing.Size(80, 20);
            this.txtPrizeID.TabIndex = 0;
            this.txtPrizeID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(48, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Prize ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance3.AlphaLevel = ((short)(95));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance3;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(671, 443);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.Text = "Prize Detail";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Caption = "Prize";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 86;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Level";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 89;
            ultraGridColumn3.Header.Caption = "$";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 106;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 278;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "nn";
            ultraGridColumn5.Width = 70;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "Arial";
            appearance6.FontData.SizeInPoints = 10F;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance7;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(6, 16);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(659, 421);
            this.Grid.TabIndex = 31;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // frmPrize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(688, 614);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPrize";
            this.ShowInTaskbar = false;
            this.Text = "Prize Maintenance";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            oPrize = new Prize(this.CompanyID);
            oProduct = new Product(this.CompanyID);
            oPack = new Pack(this.CompanyID);
            this.txtPrizeID.Focus();
           
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtPrizeID
            if (sender==txtPrizeID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oPrize.View())
                    {
                        ShowPrize();
                        txtDescription.Focus();
                        Grid.DataSource = oPrize.Items.dtItems;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();
                        return;
                    }
                    
				}

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtPrizeID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtPrizeID.Focus();
                    }

                    if (oPrize.Find(txtPrizeID.Text))
                    {
                        txtDescription.Text = oPrize.Description;
                        Grid.DataSource = oPrize.Items.dtItems;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();

                    }
                    else
                    {
                        Clear();
                        oPrize.Items.dtItems.Rows.Clear();
                        oPrize.ID = txtPrizeID.Text;
                        oPrize.Items.AddEmpty();
                        Grid.DataSource = oPrize.Items.dtItems;
                        Grid.DataBind();
                        txtDescription.Focus();
                        
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
                        if (Grid.ActiveRow.Cells["ProductID"] == Grid.ActiveCell)
                        {
                            if (oProduct.View())
                            {
                                 if (!oPrize.Items.Contains(Grid.ActiveRow.Cells["ProductID"].Text))
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
                          if (Grid.ActiveRow.Cells["ProductID"] == Grid.ActiveCell )
                          {
                              if (oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                              {
                                  if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                  {

                                      Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                      Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                      Grid.ActiveRow.Cells["BreakLevel"].Activate();
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
                              return; 
                          }
                          if (Grid.ActiveRow.Cells["Amount"] == Grid.ActiveCell)
                          {
                              gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                              if (gridRow != null)
                              {
                                  MoveDown();
                                  return;
                              }
                              else //if (Grid.ActiveRow.Cells["ProductID"].Text && Grid.ActiveRow.Cells["0"].Text)
                              {
                                  if (Grid.ActiveRow.Cells["ProductID"].Text != "" && !Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                  {

                                      if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                                      {
                                          oPrize.Items.AddEmpty();
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
                                      Grid.ActiveRow.Cells["BreakLevel"].Value = 0;
                                      Grid.ActiveRow.Cells["Amount"].Value = 0;
                                  }
                                  return;

                              }
                              
                          }

                          if (Grid.ActiveRow.Cells["BreakLevel"] == Grid.ActiveCell)
                          {
                              Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                              Grid.ActiveRow.Cells["Amount"].Activate();
                              Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                              return;
                          }

                          if (Grid.ActiveRow.Cells["Quantity"] == Grid.ActiveCell)
                          {
                              Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                              Grid.ActiveRow.Cells["ProductID"].Activate();
                              Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                              return;
                          }
                    
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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                }
                

            }
            #endregion
            #region txtDescription
            if (sender == txtDescription)
            {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    oPrize.Description = txtDescription.Text;
                    txtProductTypeID.Focus();
                    MoveLast();
                    return;
                }
            }
             #endregion
            #region txtProductTypeID
            if (sender == txtProductTypeID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oPack.View())
                    {
                        txtProductTypeID.Text = oPack.ID;
                        txtPTDescription.Text = oPack.Description;

                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtProductTypeID.Text.Trim().Length == 0)
                    {
                        txtProductTypeID.Focus();
                    }

                    if (oPack.Find(txtProductTypeID.Text))
                    {
                        txtProductTypeID.Text = oPack.ID;
                        txtPTDescription.Text = oPack.Description;

                    }
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
                    oPrize.Delete();
                    Clear();
                    oPrize.Items.dtItems.Rows.Clear();
                    Grid.DataBind();
                    txtPrizeID.Clear();
                    txtPrizeID.Focus();
                    break;
                case Keys.PageDown:
                    this.Save();
                    //oPrize.Description = txtDescription.Text;
                    //oPrize.Save();
                    Grid.DataBind();
                    Clear();
                    txtPrizeID.Clear();
                    txtPrizeID.Focus();
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
                    Grid.ActiveCell = aUGRow.Cells["Quantity"];


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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["ProductID"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }


        }
        public void Save()
        {
            oPrize.ID           = txtPrizeID.Text;
            oPrize.Description  = txtDescription.Text;
            oPrize.PackID       = txtProductTypeID.Text;
            

            oPrize.Save();
            Clear();
            txtPrizeID.Clear();

        }
        public bool ShowPrize()
        {
            Clear();
            txtDescription.Text = oPrize.Description;
            txtPrizeID.Text = oPrize.ID;
            txtProductTypeID.Text = oPrize.PackID;
            if (oPack.Find(oPrize.PackID))
                txtPTDescription.Text = oPack.Description;

            return true;
        }
        public void Clear()
        {
            txtDescription.Text = "";
            txtProductTypeID.Text = "";
            
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
        private void DeleteItem()
        {
            UltraGridRow aUGRow;
            if (Grid.ActiveCell != null)
            {
                aUGRow = Grid.ActiveCell.Row;
                Grid.ActiveCell.Row.Delete();
            }

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
		#endregion

	}
}
