

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
	public sealed class frmProductByRep : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox groupBox2;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private UltraGrid Grid;
        #endregion


        Rep oRep;
        Product oProduct;
        Company oCompany;
        private Signature.Windows.Forms.MaskedEdit txtName;
        private Signature.Windows.Forms.MaskedEdit txtRepID;
        private Label label3;
       

        
        public frmProductByRep()
		{
			InitializeComponent();
            Global.ShowNotifier("To Delete an item please \r\n"+
                                "press Ctl+Delete keys");
        
		}
        
  	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cost", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HTS_Number", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HTS_Rate", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HTS_Price", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Country", 6);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion1 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(1089);
            Infragistics.Win.UltraWinGrid.ColScrollRegion colScrollRegion2 = new Infragistics.Win.UltraWinGrid.ColScrollRegion(-7);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductByRep));
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtName = new Signature.Windows.Forms.MaskedEdit();
            this.txtRepID = new Signature.Windows.Forms.MaskedEdit();
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
            this.txtStatus.Location = new System.Drawing.Point(0, 637);
            this.txtStatus.Size = new System.Drawing.Size(1105, 29);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtRepID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1100, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(263, 45);
            this.txtName.Name = "txtCustomerID";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(356, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            this.txtRepID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtRepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRepID.Location = new System.Drawing.Point(139, 45);
            this.txtRepID.Name = "txtCustomerID";
            this.txtRepID.Size = new System.Drawing.Size(80, 20);
            this.txtRepID.TabIndex = 0;
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(24, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rep ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.AllowDrop = true;
            appearance4.AlphaLevel = ((short)(95));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Appearance = appearance4;
            this.groupBox3.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1100, 512);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.Text = "Rep Detail";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.Grid.DisplayLayout.AddNewBox.Appearance = appearance5;
            this.Grid.DisplayLayout.AddNewBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance6.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            appearance6.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance6.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.AddNewBox.ButtonAppearance = appearance6;
            this.Grid.DisplayLayout.AddNewBox.ButtonConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            this.Grid.DisplayLayout.AddNewBox.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance7.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance7;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 66;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 280;
            ultraGridColumn3.DataType = typeof(double);
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{double:4.3}";
            ultraGridColumn3.Width = 94;
            ultraGridColumn4.DataType = typeof(double);
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "{double:4.3}";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "";
            ultraGridColumn6.DataType = typeof(double);
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.MaskInput = "{double:4.3}";
            ultraGridColumn7.DataType = typeof(double);
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.MaskInput = "{double:4.3}";
            ultraGridColumn8.Header.Caption = "Country Origin";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand1.Header.Caption = "";
            ultraGridBand1.Header.Enabled = false;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance8.FontData.Name = "Trebuchet MS";
            appearance8.FontData.SizeInPoints = 9F;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Right";
            this.Grid.DisplayLayout.CaptionAppearance = appearance8;
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion1);
            this.Grid.DisplayLayout.ColScrollRegions.Add(colScrollRegion2);
            this.Grid.DisplayLayout.FixedHeaderOffImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedHeaderOffImage")));
            this.Grid.DisplayLayout.FixedHeaderOnImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedHeaderOnImage")));
            this.Grid.DisplayLayout.FixedRowOffImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedRowOffImage")));
            this.Grid.DisplayLayout.FixedRowOnImage = ((System.Drawing.Image)(resources.GetObject("Grid.DisplayLayout.FixedRowOnImage")));
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Trebuchet MS";
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(127)))), ((int)(((byte)(177)))));
            appearance9.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 3);
            appearance9.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.GroupByBox.Appearance = appearance9;
            this.Grid.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Transparent;
            appearance11.FontData.Name = "Verdana";
            this.Grid.DisplayLayout.Override.CellAppearance = appearance11;
            appearance12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance12.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            appearance12.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.Override.CellButtonAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.Grid.DisplayLayout.Override.FilterCellAppearance = appearance13;
            appearance14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance14.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3);
            this.Grid.DisplayLayout.Override.FilterClearButtonAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            appearance15.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.Grid.DisplayLayout.Override.FilterRowPromptAppearance = appearance15;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance16.FontData.BoldAsString = "True";
            appearance16.FontData.Name = "Trebuchet MS";
            appearance16.FontData.SizeInPoints = 10F;
            appearance16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance16.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance16.TextHAlignAsString = "Left";
            appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance17.BorderColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            appearance19.BorderColor = System.Drawing.Color.Transparent;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedCellAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Transparent;
            appearance20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(27)))), ((int)(((byte)(85)))));
            appearance20.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4);
            appearance20.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance21.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 4, 2, 4);
            appearance21.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.Appearance = appearance21;
            appearance22.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance22.ImageBackground")));
            appearance22.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(3, 2, 3, 2);
            scrollBarLook1.AppearanceHorizontal = appearance22;
            appearance23.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance23.ImageBackground")));
            appearance23.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 3, 2, 3);
            appearance23.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.AppearanceVertical = appearance23;
            appearance24.ImageBackground = ((System.Drawing.Image)(resources.GetObject("appearance24.ImageBackground")));
            appearance24.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 1);
            scrollBarLook1.TrackAppearanceHorizontal = appearance24;
            appearance25.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(2, 0, 1, 0);
            appearance25.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            scrollBarLook1.TrackAppearanceVertical = appearance25;
            this.Grid.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Grid.Location = new System.Drawing.Point(3, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(1091, 487);
            this.Grid.TabIndex = 31;
            this.Grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // frmProductByRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1105, 666);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductByRep";
            this.ShowInTaskbar = false;
            this.Text = "Product By Rep";
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
            oRep = new Rep(this.CompanyID);
            oProduct = new Product(this.CompanyID);
            oCompany = new Company(this.CompanyID);
            this.txtRepID.Focus();
           
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtRepID
            if (sender==txtRepID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oRep.ViewByID())
                    {
                        ShowVendor();
                    }

                    if (txtRepID.Text == "")
                        return;
                    
                    oRep.Items.Load(this.CompanyID, Convert.ToInt32(txtRepID.Text));
                    Grid.DataSource = oRep.Items.dtItems;
                    Grid.DataBind();
                        Grid.Focus();
                        MoveLast();
                        return;
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtRepID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtRepID.Focus();
                    }

                    if (oRep.Find(Convert.ToInt32(txtRepID.Text)))
                    {
                        ShowVendor();
                        oRep.Items.Load(this.CompanyID, Convert.ToInt32(txtRepID.Text));
                        Grid.DataSource = oRep.Items.dtItems;
                        Grid.DataBind();
                        Grid.Focus();
                        MoveLast();

                    }
                    else
                    {
                        Clear();
                        txtRepID.Focus();
                        /*
                        oRep.ID = Convert.ToInt32(txtRepID.Text);
                        oRep.Items.AddEmpty();
                        Grid.DataSource = oRep.Items.dtItems;
                        Grid.DataBind();
                        Grid.Focus();
                        */
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
                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {

                                    Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                    //Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                    Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                    Grid.ActiveRow.Cells["Price"].Activate();
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
                            if (Grid.ActiveRow.Cells["ProductID"].Text != "" && !Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {
                                     if (Grid.ActiveRow.Cells["ProductID"] == Grid.ActiveCell)
                                        {
                                            if (oProduct.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                                            {
                                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                                {

                                                    Grid.ActiveRow.Cells["ProductID"].Value = oProduct.ID;
                                                    Grid.ActiveRow.Cells["InvCode"].Value = oProduct.InvCode;
                                                    Grid.ActiveRow.Cells["Description"].Value = oProduct.Description;
                                                    Grid.ActiveRow.Cells["Price"].Activate();
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
                                        }else if (Grid.ActiveRow.Cells["Price"] == Grid.ActiveCell)
                                        {
                                            Grid.ActiveRow.Cells["Cost"].Activate();
                                            Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                            return;
                                        }
                                     else if (Grid.ActiveRow.Cells["Cost"] == Grid.ActiveCell)
                                     {
                                         Grid.ActiveRow.Cells["HTS_Number"].Activate();
                                         Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                         return;
                                     }
                                     else if (Grid.ActiveRow.Cells["HTS_Number"] == Grid.ActiveCell)
                                     {
                                         Grid.ActiveRow.Cells["HTS_Rate"].Activate();
                                         Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                         return;
                                     }
                                     else if (Grid.ActiveRow.Cells["HTS_Rate"] == Grid.ActiveCell)
                                     {
                                         Grid.ActiveRow.Cells["HTS_Price"].Activate();
                                         Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                         return;
                                     }
                                     else if (Grid.ActiveRow.Cells["HTS_Price"] == Grid.ActiveCell)
                                     {
                                         Grid.ActiveRow.Cells["Country"].Activate();
                                         Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                                         return;
                                     }
                                                                         
                                        if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                                        {

                                            oRep.Items.AddEmpty();
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
                                    Grid.ActiveRow.Cells["Price"].Value = 0;
                                }
                                return;
                    
                    
                    
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
                    //SendKeys.Send("{TAB}");
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
                    if (MessageBox.Show("Do you really want to Delete this Rep?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        MessageBox.Show("Operation Cancelled");
                        return;
                    }
                  
                    break;
                case Keys.PageDown:
                    this.Save();
                    Grid.DataBind();
                    Clear();
                    txtRepID.Clear();
                    txtRepID.Focus();
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
            oRep.Items.Save(this.CompanyID,oRep.ID);
            Clear();
            txtRepID.Clear();

        }
        public bool ShowVendor()
        {
            Clear();
            txtName.Text = oRep.Name;
            txtRepID.Text = oRep.ID.ToString();
            return true;
        }
        public void Clear()
        {
            //Grid.Rows.Dispose();
            txtName.Clear();
            

            //oRep.Items.dtItems.Rows.Clear();
            //Grid.DataBind();

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
