using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.OSAS;
using Signature.Classes;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Signature
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmKitSetup : System.Windows.Forms.Form
	{
		#region declarations		

        private Signature.Windows.Forms.ColumnSetting columnSetting1;
		private Signature.Windows.Forms.ColumnSetting columnSetting2;
		private Signature.Windows.Forms.ColumnSetting columnSetting3;
        private Signature.Windows.Forms.ColumnSetting columnSetting4;
		private System.ComponentModel.IContainer components;
		#endregion
        Signature.Data.MySQL oMySql = new Signature.Data.MySQL();
        private Signature.Windows.Forms.ColumnSetting ProductID;
        private Signature.Windows.Forms.ColumnSetting Description;
        private Signature.Windows.Forms.ColumnSetting Price;
        private Signature.Windows.Forms.ColumnSetting Quantity;
        String CompanyID = null;

        Customer oCustomer;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private Signature.Windows.Forms.MaskedEdit txtKitID;
        private Label label1;
        private Signature.Windows.Forms.MaskedEdit txtQuantity;
        private Label label2;
        private Infragistics.Win.Misc.UltraButton txtPrint;
        private Infragistics.Win.Misc.UltraLabel txtKitName;
        private Infragistics.Win.Misc.UltraButton btSave;
        private Infragistics.Win.Misc.UltraButton btDelete;
        private UltraGrid gKits;
        GA_Kit oKit;

        public frmKitSetup()
		{
			InitializeComponent();
            
            this.CompanyID = Global.GetParameter("CurrentCompany");
		}

	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kit ID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKitSetup));
            this.ProductID = new Signature.Windows.Forms.ColumnSetting();
            this.Description = new Signature.Windows.Forms.ColumnSetting();
            this.Price = new Signature.Windows.Forms.ColumnSetting();
            this.Quantity = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting1 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting2 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting3 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting4 = new Signature.Windows.Forms.ColumnSetting();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btDelete = new Infragistics.Win.Misc.UltraButton();
            this.btSave = new Infragistics.Win.Misc.UltraButton();
            this.txtKitName = new Infragistics.Win.Misc.UltraLabel();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrint = new Infragistics.Win.Misc.UltraButton();
            this.txtKitID = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gKits = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gKits)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductID
            // 
            this.ProductID.ButtonWidth = 25;
            this.ProductID.IsEditable = false;
            // 
            // Description
            // 
            this.Description.ButtonWidth = 25;
            this.Description.IsEditable = false;
            // 
            // Price
            // 
            this.Price.ButtonWidth = 25;
            this.Price.IsEditable = false;
            // 
            // Quantity
            // 
            this.Quantity.ButtonWidth = 25;
            // 
            // columnSetting1
            // 
            this.columnSetting1.ButtonWidth = 25;
            // 
            // columnSetting2
            // 
            this.columnSetting2.ButtonWidth = 25;
            // 
            // columnSetting3
            // 
            this.columnSetting3.ButtonWidth = 25;
            // 
            // columnSetting4
            // 
            this.columnSetting4.ButtonWidth = 25;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 20);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(436, 69);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance1;
            this.txtName.Location = new System.Drawing.Point(158, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(261, 20);
            this.txtName.TabIndex = 14;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(88, 28);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 12;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(18, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "School ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.gKits);
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 103);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(298, 280);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.btDelete);
            this.ultraGroupBox3.Controls.Add(this.btSave);
            this.ultraGroupBox3.Controls.Add(this.txtKitName);
            this.ultraGroupBox3.Controls.Add(this.txtQuantity);
            this.ultraGroupBox3.Controls.Add(this.label2);
            this.ultraGroupBox3.Controls.Add(this.txtPrint);
            this.ultraGroupBox3.Controls.Add(this.txtKitID);
            this.ultraGroupBox3.Controls.Add(this.label1);
            this.ultraGroupBox3.Location = new System.Drawing.Point(316, 103);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(129, 280);
            this.ultraGroupBox3.TabIndex = 14;
            this.ultraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(6, 196);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(114, 22);
            this.btDelete.TabIndex = 21;
            this.btDelete.Text = "Delete Row";
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(6, 224);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(114, 22);
            this.btSave.TabIndex = 20;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // txtKitName
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.BackColor2 = System.Drawing.Color.Black;
            this.txtKitName.Appearance = appearance16;
            this.txtKitName.Location = new System.Drawing.Point(18, 115);
            this.txtKitName.Name = "txtKitName";
            this.txtKitName.Size = new System.Drawing.Size(93, 52);
            this.txtKitName.TabIndex = 19;
            this.txtKitName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            this.txtQuantity.Location = new System.Drawing.Point(75, 79);
            this.txtQuantity.Name = "txtCustomerID";
            this.txtQuantity.Size = new System.Drawing.Size(36, 20);
            this.txtQuantity.TabIndex = 17;
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(57, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Qty:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrint
            // 
            this.txtPrint.Location = new System.Drawing.Point(6, 252);
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(114, 22);
            this.txtPrint.TabIndex = 16;
            this.txtPrint.Text = "Print Sheets";
            this.txtPrint.Click += new System.EventHandler(this.txtPrint_Click);
            // 
            // txtKitID
            // 
            this.txtKitID.AllowDrop = true;
            this.txtKitID.Location = new System.Drawing.Point(18, 79);
            this.txtKitID.Name = "txtCustomerID";
            this.txtKitID.Size = new System.Drawing.Size(51, 20);
            this.txtKitID.TabIndex = 14;
            this.txtKitID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gKits
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.gKits.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn1.Header.Caption = "KitID";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.gKits.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gKits.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.gKits.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.gKits.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gKits.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.gKits.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gKits.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gKits.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.gKits.DisplayLayout.InterBandSpacing = 10;
            this.gKits.DisplayLayout.MaxColScrollRegions = 1;
            this.gKits.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gKits.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gKits.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.gKits.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gKits.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.gKits.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gKits.DisplayLayout.Override.CellAppearance = appearance9;
            this.gKits.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gKits.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.gKits.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Left";
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gKits.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.gKits.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gKits.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.gKits.DisplayLayout.Override.RowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gKits.DisplayLayout.Override.RowSelectorAppearance = appearance13;
            this.gKits.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.gKits.DisplayLayout.Override.RowSelectorWidth = 12;
            this.gKits.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(169)))), ((int)(((byte)(226)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.gKits.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gKits.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.gKits.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.gKits.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.gKits.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gKits.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gKits.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gKits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gKits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gKits.Location = new System.Drawing.Point(3, 15);
            this.gKits.Name = "gKits";
            this.gKits.Size = new System.Drawing.Size(292, 262);
            this.gKits.TabIndex = 30;
            this.gKits.Text = "nm,n,n";
            this.gKits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.gKits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gKits_MouseUp);
            this.gKits.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gKits_InitializeLayout);
            // 
            // frmKitSetup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(454, 398);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKitSetup";
            this.ShowInTaskbar = false;
            this.Text = "Kit Setup";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gKits)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
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
            this.txtCustomerID.Focus();
                        
            oCustomer = new Customer(CompanyID);
            oKit = new GA_Kit(CompanyID);

            oCustomer.Kits.SetColumns(1);
            gKits.DataSource = oCustomer.Kits.dtKits;

            
		}
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{

            #region gKits

            if (sender == gKits)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    //foreach(UltraGridRow rowSelected in gKits.Rows)
                       // MessageBox.Show(rowSelected.Index.ToString());

                    //MessageBox.Show("Delete");
                    
                    //oCustomer.Kits.dtKits.Rows
                    
                   // oCustomer.Kits.RemoveAt(0);
                }
                

            }
            #endregion
            #region txtCustomerID
                        
            if (sender==txtCustomerID)	
			{
				if (e.KeyCode.ToString()=="F2")
				{
                    if (oCustomer.View())
                    {
                        this.txtCustomerID.Text = oCustomer.ID;
                        SendKeys.Send("{ENTER}");
                        return;
                     }

                    this.txtName.Text = oCustomer.Name;
                    //txtKitID.Focus();
                    return;
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!oCustomer.Find(txtCustomerID.Text))
					{
                        
                        this.txtCustomerID.Focus();
						return;
					}
                    this.txtName.Text = oCustomer.Name;
                    gKits.DataSource = oCustomer.Kits.GetDataTable(oCustomer);

                    
                    txtKitID.Focus();
                    return;
				}

            }
            #endregion
            #region txtKitID
            if (sender == txtKitID)
            {
                
                if (e.KeyCode.ToString() == "F8")
                {
                    //this.lbKits.Focus();
                }

                if (e.KeyCode.ToString() == "F2")
                {

                    if (oKit.View())
                    {
                        this.txtKitID.Text = oKit.ID;
                        this.txtKitName.Text = oKit.Description;
                        this.txtQuantity.Clear();
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (oKit.Find(txtKitID.Text))
                    {
                        this.txtKitID.Text = oKit.ID;
                        this.txtKitName.Text = oKit.Description;
                        this.txtQuantity.Clear();
                        this.txtQuantity.Focus();
                        return;

                    }
                    else
                    {
                        
                        this.txtKitID.Clear();
                        this.txtKitID.Focus();
                        return;
                    }
                }
                return;
            }
            #endregion
            #region txtQuantity
            if (sender == this.txtQuantity)
            {
                //MessageBox.Show(e.KeyCode.ToString());
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {

                    if (this.txtQuantity.Text != "")
                    {
                        //this.AddItem();

                         
                        try
                            {
                                DataRow rowNew = oCustomer.Kits.dtKits.NewRow();
                                rowNew["KitID"] = txtKitID.Text;
                                rowNew["Name"] = oKit.Description;
                                rowNew["Quantity"] = txtQuantity.Text;
                                oCustomer.Kits.dtKits.Rows.Add(rowNew);
                            }
                        catch (Exception ex)
                            { 
                                MessageBox.Show(ex.Message); //"Unable to add new customer for given ID");
                            }

                            this.txtQuantity.Text = "";
                            this.txtKitID.Text = "";
                            this.txtKitID.Focus();
                        return;
                    }
                    else
                    {
                        this.txtQuantity.Focus();
                        return;
                    }
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
                    deleteOrder();
                    break;
                case Keys.PageDown:
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            #endregion

        }
        #endregion

        #region  Methods
        
        public void Clear()
        {
            //frm.txtCustomerID.Clear();
            //frm.txtTeacher.Clear();
            //frm.txtStudent.Clear();
            //frm.listView.Clear();

            int i = 0;
            
            //txtStudent.Clear();
            
        }
        private bool get_header(String Teacher, String Student)
        {
            //Header
            this.Clear();

            
            return true;
        }
        public bool get(String Teacher, String Student)
        {
            if (!this.get_header(Teacher, Student))
                return false;
            this.get_detail();

            

            return true;
        }
        private bool get_detail()
        {
            this.Clear();
            return true;
        }
        public void DeleteItem()
        {
            return;
        }
        private bool IfExist()
        {
            bool Exist = false;
            int i = 0;
            return Exist;
        }
        public void Save()
        {

            
            CompanyID    = CompanyID;
            //CustomerID   = txtCustomerID.Text;
            
            
            //oCustomer.Kits.Save(OrderType.Regular);
            Clear();
            

            
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

	
		#endregion

		

		// The focusedControl holds the control in focus in the current
		// control collections.
		private Control focusedControl = null;

		// This recursive call finds the control that has the focus.
		// Note: the recursion is necessary since the controls on the
		private void GetFocusedControl(Control control) 
		{
			if (control.Focused) 
			{
				focusedControl = control;
			} 
			else 
			{
				foreach (Control c in control.Controls) 
				{
					GetFocusedControl(c);
				}
			}
		}

        private void bPrint_Click(object sender, EventArgs e)
        {

            frmViewReport oViewReport = new frmViewReport();
            oViewReport.SetReport( (int) Signature.Report.BoxInventory , Global.GetParameter("CurrentCompany"),txtCustomerID.Text, true);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            oCustomer.Kits.Save(oCustomer);
            Clear();
            gKits.Rows.Dispose();
            txtCustomerID.Focus();
        }

        private void gKits_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitColumns = true;
            /*e.Layout.Bands(0).Columns("CurrencyValue").Format = "$#,##0.00"
            e.Layout.Bands(0).Columns("DateValue1").Format = "d" ' this line works
            e.Layout.Bands(0).Columns("DateValue2").Format = "hh:mm:ss"*/
        }

        private void gKits_MouseUp(object sender, MouseEventArgs e)
        {
             //' declare objects to get value from cell and display
            Infragistics.Win.UIElement mouseupUIElement;
            Infragistics.Win.UltraWinGrid.UltraGridCell mouseupCell;

                if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) 
                    {
                        
                    //' retrieve the UIElement from the location of the MouseUp
                    mouseupUIElement = gKits.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

                      //' retrieve the Cell from the UIElement
                    mouseupCell = mouseupUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.UltraGridCell))
                        as Infragistics.Win.UltraWinGrid.UltraGridCell; ;

                      //' if there is a cell object reference, set to active cell and edit
                    if (!(mouseupCell == null ))
                            {
                                UltraGridRow aUGRow;
                                gKits.ActiveCell = mouseupCell;
                                
                                aUGRow = gKits.ActiveCell.Row;
                                gKits.ActiveRow = aUGRow;
                                gKits.ActiveCell = aUGRow.Cells["Quantity"];
                        
                                
                                gKits.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }
      
        }

     }

        private void btDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow aUGRow;
            if (gKits.ActiveCell != null)
            {
                aUGRow = gKits.ActiveCell.Row;
                gKits.ActiveCell.Row.Delete();
            }

        }

        private void txtPrint_Click(object sender, EventArgs e)
        {
            frmViewReport oViewReport = new frmViewReport();
            oViewReport.SetReport((int)Report.BoxInventory, oKit.CompanyID, txtCustomerID.Text, true);
            frmViewReport oViewReport1 = new frmViewReport();
            oViewReport1.SetReport((int)Report.FinalBillTally, oKit.CompanyID, txtCustomerID.Text, true);


        }

        
        

	}
}
