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
	public sealed class frmGAOrder : System.Windows.Forms.Form
	{
		#region declarations		

        
		#endregion
        Signature.Data.MySQL oMySql = Global.oMySql;
        String CompanyID = null;

        Customer oCustomer;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label9;
        private Infragistics.Win.Misc.UltraLabel txtName;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid gKits;
        private Button bCancel;
        private Button bSubmit;
        private Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDeliveryDate;
        private CheckBox cbKit;
        private Label label2;
        private Label label1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtShipDate;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private CheckBox cbRush;
        private Label label4;
        private Label label5;
        private ComboBox cShipVia;
        private Signature.Windows.Forms.MaskedEdit txtSearch;
        private Label label6;
        GA_Kit oKit;

        public frmGAOrder()
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Price", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeliveryDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cbKit = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShipDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new Signature.Windows.Forms.MaskedEdit();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSubmit = new System.Windows.Forms.Button();
            this.gKits = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cShipVia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRush = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gKits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 20);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(368, 108);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtName
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance1;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(22, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 55);
            this.txtName.TabIndex = 14;
            this.txtName.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.Location = new System.Drawing.Point(88, 11);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(52, 20);
            this.txtCustomerID.TabIndex = 12;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(6, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "School ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Shipping Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.DateTime = new System.DateTime(2007, 11, 28, 0, 0, 0, 0);
            this.txtDeliveryDate.Location = new System.Drawing.Point(120, 36);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(84, 21);
            this.txtDeliveryDate.TabIndex = 25;
            this.txtDeliveryDate.Value = new System.DateTime(2007, 11, 28, 0, 0, 0, 0);
            // 
            // cbKit
            // 
            this.cbKit.AutoSize = true;
            this.cbKit.Location = new System.Drawing.Point(362, 11);
            this.cbKit.Name = "cbKit";
            this.cbKit.Size = new System.Drawing.Size(15, 14);
            this.cbKit.TabIndex = 24;
            this.cbKit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(306, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Kit ?:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Delivery by:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipDate
            // 
            this.txtShipDate.DateTime = new System.DateTime(2007, 11, 28, 0, 0, 0, 0);
            this.txtShipDate.Location = new System.Drawing.Point(120, 11);
            this.txtShipDate.Name = "txtShipDate";
            this.txtShipDate.Size = new System.Drawing.Size(84, 21);
            this.txtShipDate.TabIndex = 21;
            this.txtShipDate.Value = new System.DateTime(2007, 11, 28, 0, 0, 0, 0);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.label6);
            this.ultraGroupBox2.Controls.Add(this.txtSearch);
            this.ultraGroupBox2.Controls.Add(this.bCancel);
            this.ultraGroupBox2.Controls.Add(this.bSubmit);
            this.ultraGroupBox2.Controls.Add(this.gKits);
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 134);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(778, 462);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(19, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 19);
            this.label6.TabIndex = 31;
            this.label6.Text = "Search:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.AllowDrop = true;
            this.txtSearch.Location = new System.Drawing.Point(115, 10);
            this.txtSearch.Name = "txtCustomerID";
            this.txtSearch.Size = new System.Drawing.Size(433, 20);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(196, 412);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(470, 412);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Submit and  Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // gKits
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.gKits.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 107;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 430;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 98;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 107;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.gKits.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gKits.DisplayLayout.GroupByBox.Hidden = true;
            this.gKits.DisplayLayout.MaxColScrollRegions = 1;
            this.gKits.DisplayLayout.MaxRowScrollRegions = 1;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.gKits.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.gKits.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "Arial";
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.gKits.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.gKits.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gKits.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.gKits.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.gKits.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.gKits.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gKits.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gKits.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gKits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gKits.Location = new System.Drawing.Point(9, 36);
            this.gKits.Name = "gKits";
            this.gKits.Size = new System.Drawing.Size(761, 351);
            this.gKits.TabIndex = 29;
            this.gKits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gKits_KeyUp);
            this.gKits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gKits_MouseUp);
            this.gKits.AfterCellActivate += new System.EventHandler(this.gKits_AfterCellActivate);
            this.gKits.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gKits_InitializeLayout);
            this.gKits.Enter += new System.EventHandler(this.gKits_Enter);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.cShipVia);
            this.ultraGroupBox3.Controls.Add(this.label5);
            this.ultraGroupBox3.Controls.Add(this.cbRush);
            this.ultraGroupBox3.Controls.Add(this.label4);
            this.ultraGroupBox3.Controls.Add(this.label3);
            this.ultraGroupBox3.Controls.Add(this.txtDeliveryDate);
            this.ultraGroupBox3.Controls.Add(this.txtShipDate);
            this.ultraGroupBox3.Controls.Add(this.cbKit);
            this.ultraGroupBox3.Controls.Add(this.label1);
            this.ultraGroupBox3.Controls.Add(this.label2);
            this.ultraGroupBox3.Location = new System.Drawing.Point(383, 20);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(404, 108);
            this.ultraGroupBox3.TabIndex = 14;
            this.ultraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cShipVia
            // 
            this.cShipVia.FormattingEnabled = true;
            this.cShipVia.Items.AddRange(new object[] {
            "UPS Next DayAir",
            "UPS 2nd Day Air",
            "UPS Ground"});
            this.cShipVia.Location = new System.Drawing.Point(120, 71);
            this.cShipVia.Name = "cShipVia";
            this.cShipVia.Size = new System.Drawing.Size(111, 21);
            this.cShipVia.TabIndex = 31;
            this.cShipVia.Text = "UPS Ground";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(15, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ship Via:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRush
            // 
            this.cbRush.AutoSize = true;
            this.cbRush.Location = new System.Drawing.Point(362, 71);
            this.cbRush.Name = "cbRush";
            this.cbRush.Size = new System.Drawing.Size(15, 14);
            this.cbRush.TabIndex = 28;
            this.cbRush.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(274, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Hot Rush?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGAOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(795, 603);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmGAOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GA Order";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gKits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
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
            this.txtCustomerID.Focus();
                        
            oCustomer = new Customer(CompanyID);
            oKit = new GA_Kit(CompanyID);

            oCustomer.ReOrders.SetColumns();
            //gKits.DataSource = oCustomer.ReOrders.GetDataTable();

            txtDeliveryDate.Value = DateTime.Now;
            txtShipDate.Value = DateTime.Now;
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{

            if (sender == txtSearch)
            {
             
                if (e.KeyCode == Keys.Tab)
                {

                    gKits.Focus();
                    return;
                }
            }
            #region gKits
            if (sender == gKits)
            {
                return;
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
                        if (!oCustomer.Find(txtCustomerID.Text))
                        {

                            this.txtCustomerID.Focus();
                            return;
                        }
                        this.txtName.Text = oCustomer.Name;

                        gKits.DataSource = oCustomer.ReOrders.GetDataTable(oCustomer);
                        gKits.Focus();
                        return;
                        
                     }
                    this.txtName.Text = oCustomer.Name;
                    
                    
				}
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    
                    if (!oCustomer.Find(txtCustomerID.Text))
					{
                        
                        this.txtCustomerID.Focus();
						return;
					}
                    this.txtName.Text = oCustomer.Name;
                    
                    gKits.DataSource = oCustomer.ReOrders.GetDataTable(oCustomer);
                    gKits.Focus();
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
        private void bPrint_Click(object sender, EventArgs e)
        {

            frmViewReport oViewReport = new frmViewReport();
            oViewReport.SetReport((int)Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtCustomerID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
           
            oCustomer.ReOrders._ShipDate = (DateTime)txtShipDate.Value;
            oCustomer.ReOrders._DeliveryDate = (DateTime)txtDeliveryDate.Value;
            oCustomer.ReOrders.Rush = cbRush.Checked ? "Y" : "N";
            oCustomer.ReOrders.ShipVia = cShipVia.Text;

            
            oCustomer.ReOrders.Save(oCustomer);
            
            oCustomer.ReOrders.SubmitOrder(oCustomer); //Create GiftCo File
            
            oCustomer.ReOrders.SendFTPFile(oCustomer);
            
            if (cbKit.Checked)
            {
                oCustomer.ReOrders.SaveAsKits(oCustomer);
            }
            Close();
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void gKits_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (sender == gKits)
            {
                if (e.KeyCode == Keys.Tab)
                {
                    txtSearch.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = gKits.ActiveRow;
                    gridRow.Appearance = gKits.DisplayLayout.Appearances["Normal"];
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                    if (gridRow != null)
                    {
                        gridRow.Activate();
                        //' set ActiveCell
                        gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                        gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                        gridRow.Appearance = gKits.DisplayLayout.Appearances["Credit"];
                    }

                    //SendKeys.Send("{TAB}");
                }
                if (e.KeyCode == Keys.Down)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = gKits.ActiveRow;
                    gridRow.Appearance = gKits.DisplayLayout.Appearances["Normal"];
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
                    if (gridRow != null)
                    {
                        gridRow.Activate();
                        //' set ActiveCell
                        gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                        gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                        gridRow.Appearance = gKits.DisplayLayout.Appearances["Credit"];
                    }

                    //SendKeys.Send("{TAB}");
                }
                if (e.KeyCode == Keys.Up)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                    gridRow = gKits.ActiveRow;
                    gridRow.Appearance = gKits.DisplayLayout.Appearances["Normal"];
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous);
                    if (gridRow != null)
                    {

                        gridRow.Activate();
                        //' set ActiveCell
                        gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                        gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                        gridRow.Appearance = gKits.DisplayLayout.Appearances["Credit"];
                    }

                    //SendKeys.Send("{TAB}");
                }
            }
        }

        #endregion

        #region  Methods
        
        public void Clear()
        {
            //frm.txtCustomerID.Clear();
            //frm.txtTeacher.Clear();
            //frm.txtStudent.Clear();
            //frm.listView.Clear();

            
            
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
            
            return Exist;
        }
        public void Save()
        {

            
            //CompanyID    = CompanyID;
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
        private void ActiveRow(String Text)
        {
            UltraGridRow Row= gKits.ActiveRow;
            
            bool Flag = false;
            foreach (UltraGridRow aUGRow in gKits.Rows)
            {
                if ((aUGRow.Cells["Description"].Text.ToUpper().IndexOf(Text.ToUpper()) >= 0 || aUGRow.Cells["ProductID"].Text.ToUpper().IndexOf(Text.ToUpper()) >= 0) && Text.Length > 0  && !Flag)
                {
                   if (!Flag)
                   {
                       Flag = true;
                       Row = aUGRow;
                   }
                    // break;
                }else
                    aUGRow.Appearance.BackColor = System.Drawing.Color.White;
                    //aUGRow = aUGRow.GetSibling(SiblingRow.Next);
                }

            if (Flag)
            {
                gKits.Rows[Row.Index].Activate();

                //gKits.ActiveRow = Row;
                //gKits.ActiveRow.Activate();
                gKits.ActiveRow.Appearance.BackColor = System.Drawing.Color.LightBlue;
                
            }
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

        private void gKits_MouseUp(object sender, MouseEventArgs e)
        {
            //' declare and retrieve a reference to the UIElement
            Infragistics.Win.UIElement aUIElement;

               aUIElement = gKits.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));

            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;

            if (aUIElement != null)
            {
                gridRow = aUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow)) as Infragistics.Win.UltraWinGrid.UltraGridRow;


                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                    gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }

        }
        private void gKits_AfterCellActivate(object sender, EventArgs e)
        {
            
            //' declare and retrieve a reference to the Row
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = gKits.ActiveRow;

            if (gridRow != null)
            {
                //gridRow.Activate();
                //' set ActiveCell
                gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
            }
        }
        private void gKits_Enter(object sender, EventArgs e)
        {
            if (gKits.Rows.Count > 0)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
                if (gKits.ActiveRow == null)
                {
                    gridRow = gKits.Rows[0];
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
                }
                else
                {
                    gridRow = gKits.ActiveRow;
                }

                if (gridRow != null)
                {
                    gridRow.Activate();
                    //' set ActiveCell
                    gKits.ActiveCell = gKits.ActiveRow.Cells["Quantity"];
                    gKits.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                }
            }
            else
                txtCustomerID.Focus();
        }

        private void gKits_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //' add and configure "Credit" Appearance
            e.Layout.Appearances.Add("Credit");
            e.Layout.Appearances["Credit"].ForeColor = Color.Red;
            e.Layout.Appearances["Credit"].BackColor = Color.LightBlue;
            e.Layout.Appearances["Credit"].FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //e.Layout.Appearances["Credit"].TextHAlign = Infragistics.Win.HAlign.Right;
    
            e.Layout.Appearances.Add("Normal");
            e.Layout.Appearances["Normal"].ForeColor = Color.Black;
            e.Layout.Appearances["Normal"].BackColor = Color.White;
            e.Layout.Appearances["Normal"].FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            //e.Layout.Appearances["Normal"].TextHAlign = Infragistics.Win.HAlign.Right;
            
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ActiveRow(txtSearch.Text);
        }

	}
}
