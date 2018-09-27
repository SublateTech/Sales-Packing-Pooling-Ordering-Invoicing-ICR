using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.OSAS;
using Signature.Classes;

namespace Signature
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmGAOrder : System.Windows.Forms.Form
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
        private Infragistics.Win.UltraWinGrid.UltraGrid gKits;
        private Button bCancel;
        private Button bSubmit;
        private Label label1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtShipDate;
        private CheckBox cbKit;
        private Label label2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGAOrder));
            this.ProductID = new Signature.Windows.Forms.ColumnSetting();
            this.Description = new Signature.Windows.Forms.ColumnSetting();
            this.Price = new Signature.Windows.Forms.ColumnSetting();
            this.Quantity = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting1 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting2 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting3 = new Signature.Windows.Forms.ColumnSetting();
            this.columnSetting4 = new Signature.Windows.Forms.ColumnSetting();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShipDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtName = new Infragistics.Win.Misc.UltraLabel();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.gKits = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
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
            this.ultraGroupBox1.Controls.Add(this.cbKit);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtShipDate);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 20);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(436, 69);
            this.ultraGroupBox1.TabIndex = 12;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(230, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Delivery Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipDate
            // 
            this.txtShipDate.Location = new System.Drawing.Point(335, 11);
            this.txtShipDate.Name = "txtShipDate";
            this.txtShipDate.Size = new System.Drawing.Size(84, 21);
            this.txtShipDate.TabIndex = 15;
            this.txtShipDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtName
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Black;
            this.txtName.Appearance = appearance1;
            this.txtName.Location = new System.Drawing.Point(22, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(261, 20);
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
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.gKits);
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 103);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(433, 245);
            this.ultraGroupBox2.TabIndex = 13;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // gKits
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.gKits.DisplayLayout.Appearance = appearance2;
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
            this.gKits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gKits.Location = new System.Drawing.Point(15, 22);
            this.gKits.Name = "gKits";
            this.gKits.Size = new System.Drawing.Size(401, 209);
            this.gKits.TabIndex = 29;
            this.gKits.Text = "nm,n,n";
            this.gKits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gKits_KeyUp);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(47, 360);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(124, 26);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(288, 360);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(124, 26);
            this.bSubmit.TabIndex = 15;
            this.bSubmit.Text = "Submit and  Save";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(199, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Kit ?:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKit
            // 
            this.cbKit.AutoSize = true;
            this.cbKit.Location = new System.Drawing.Point(335, 39);
            this.cbKit.Name = "cbKit";
            this.cbKit.Size = new System.Drawing.Size(15, 14);
            this.cbKit.TabIndex = 18;
            this.cbKit.UseVisualStyleBackColor = true;
            // 
            // frmGAOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(454, 398);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGAOrder";
            this.ShowInTaskbar = false;
            this.Text = "GA Order";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOrder_Closing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
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

            oCustomer.ReOrders.SetColumns();
            //gKits.DataSource = oCustomer.ReOrders.GetDataTable();
            
		}
        private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
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
            oViewReport.SetReport((int)Signature.Report.BoxInventory, Global.GetParameter("CurrentCompany"), txtCustomerID.Text, true);
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
           
            oCustomer.ReOrders._ShipDate = (DateTime)txtShipDate.Value;
            
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
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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

        
        

	}
}
