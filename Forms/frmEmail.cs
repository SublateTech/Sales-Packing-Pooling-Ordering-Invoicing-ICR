

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
	public sealed class frmeMail : frmBase
	{
		#region declarations		
        private Signature.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEdit txtAccountID;
        private Signature.Windows.Forms.GroupBox groupBox3;
        private UltraGrid Grid;
        private Signature.Windows.Forms.MaskedEdit txtRepID;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        #endregion


        eMail oeMail;
        
        private Signature.Windows.Forms.ComboBox txtDomains;
        private Label label4;
        
        private Signature.Windows.Forms.MaskedEdit txtPassword;
        Rep oRep;
        private Label label1;
        Int32 DomainID = 0;


        
        public frmeMail()
		{
			InitializeComponent();
            Global.ShowNotifier("To Delete an item please \r\n"+
                                "press Ctl+Delete keys");

            oRep = new Rep();
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("destination");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("source", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("domain_id", 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmeMail));
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new Signature.Windows.Forms.MaskedEdit();
            this.txtDomains = new Signature.Windows.Forms.ComboBox();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtRepID = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountID = new Signature.Windows.Forms.MaskedEdit();
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
            this.txtStatus.Location = new System.Drawing.Point(0, 407);
            this.txtStatus.Size = new System.Drawing.Size(511, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtDomains);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.txtRepID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAccountID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(7, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 142);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.AllowDrop = true;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(117, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 20);
            this.txtPassword.TabIndex = 46;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtDomains
            // 
            this.txtDomains.AllowDrop = true;
            this.txtDomains.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtDomains.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomains.Location = new System.Drawing.Point(203, 28);
            this.txtDomains.Name = "txtCollect";
            this.txtDomains.Size = new System.Drawing.Size(283, 21);
            this.txtDomains.TabIndex = 44;
            this.txtDomains.SelectedIndexChanged += new System.EventHandler(this.txtDomains_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Appearance = appearance2;
            this.txtDescription.Location = new System.Drawing.Point(213, 95);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(267, 23);
            this.txtDescription.TabIndex = 41;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtRepID
            // 
            this.txtRepID.AllowDrop = true;
            this.txtRepID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtRepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRepID.Location = new System.Drawing.Point(117, 95);
            this.txtRepID.Name = "txtCustomerID";
            this.txtRepID.Size = new System.Drawing.Size(80, 20);
            this.txtRepID.TabIndex = 30;
            this.txtRepID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Rep ID:";
            // 
            // txtAccountID
            // 
            this.txtAccountID.AllowDrop = true;
            this.txtAccountID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountID.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtAccountID.Location = new System.Drawing.Point(117, 28);
            this.txtAccountID.Name = "txtCustomerID";
            this.txtAccountID.Size = new System.Drawing.Size(80, 20);
            this.txtAccountID.TabIndex = 0;
            this.txtAccountID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "eMail Account : ";
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
            this.groupBox3.Location = new System.Drawing.Point(7, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 250);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.Text = "Destination Accounts";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000;
            // 
            // Grid
            // 
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 361;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            ultraGridBand1.Header.Caption = "";
            ultraGridBand1.Header.Enabled = false;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.Grid.Location = new System.Drawing.Point(7, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(479, 222);
            this.Grid.TabIndex = 31;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // frmeMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(511, 432);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmeMail";
            this.ShowInTaskbar = false;
            this.Text = "eMail Maintenance";
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
            
            oeMail = new eMail();
            
            this.txtAccountID.Focus();

            DataTable dt = Global.oMySql.GetDataTable("SELECT * FROM mailserver.virtual_domains Where active='1'");
            foreach (DataRow row in dt.Rows)
            {   
                txtDomains.Items.Add(row["name"].ToString());
            }

           
		}
     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region txtAccountID
            if (sender==txtAccountID)	
			{

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }


				if (e.KeyCode.ToString()=="F2")
				{
                    if (oeMail.View(this.DomainID))
                    {
                        txtAccountID.Text = oeMail.User;
                        ShowVendor();
                    }

                    if (txtAccountID.Text == "")
                        return;
                    
                    txtDescription.Focus();
                    Grid.DataSource = oeMail.Items.dt;
                    Grid.DataBind();
                        Grid.Focus();
                        oeMail.Items.AddEmpty();
                        MoveLast();
                        return;
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtAccountID.Text.Trim().Length == 0)
                    {
                        Clear();
                        txtAccountID.Focus();
                    }

                    if (oeMail.Find(txtAccountID.Text))
                    {
                        txtAccountID.Text = oeMail.User;
                        ShowVendor();
                        
                        Grid.DataSource = oeMail.Items.dt;
                        Grid.DataBind();
                        Grid.Focus();
                        oeMail.Items.AddEmpty();
                        MoveLast();

                    }
                    else
                    {
                        Clear();
                        oeMail.Items.AddEmpty();
                        Grid.DataSource = oeMail.Items.dt;
                        Grid.DataBind();
                        txtPassword.Focus();
                    }
                    
                        
                        return;
                    
                    

                }					

            }
            #endregion
            #region txtDescription
            if (sender==txtDescription)	
			{
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    //oeMail..Description = txtDescription.Text;
                    Grid.Focus();
                    MoveLast();
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
                        if (Grid.ActiveRow.Cells["destination"] == Grid.ActiveCell)
                        {/*
                            if (oRep.View())
                            {
                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                {

                                    Grid.ActiveRow.Cells["ProductID"].Value = oRep.ID;
                                    Grid.ActiveRow.Cells["InvCode"].Value = oRep.InvCode;
                                    Grid.ActiveRow.Cells["Description"].Value = oRep.Description;
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
                            */
                        }
                    }
                }
                
                
                if (e.KeyCode == Keys.Delete)
                {
                }


                if (e.KeyCode == Keys.Enter)
                {

                    if (Grid.ActiveRow != null)
                    {
                        if (Grid.ActiveRow.Cells["destination"].Text != "" && !Contain(Grid.ActiveRow.Cells["destination"].Text))
                        {
                            if (Grid.ActiveRow.Cells["destination"] == Grid.ActiveCell)
                            {/*
                                            if (oRep.Find(Grid.ActiveRow.Cells["ProductID"].Text))
                                            {
                                                if (!Contain(Grid.ActiveRow.Cells["ProductID"].Text))
                                                {

                                                    Grid.ActiveRow.Cells["ProductID"].Value = oRep.ID;
                                                    Grid.ActiveRow.Cells["InvCode"].Value = oRep.InvCode;
                                                    Grid.ActiveRow.Cells["Description"].Value = oRep.Description;
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
                                         */
                            }

                            if (Grid.GetRow(ChildRow.Last) == Grid.ActiveRow)
                            {

                                oeMail.Items.AddEmpty();
                                Grid.DataBind();
                                MoveLast();
                                //Grid.PerformAction(UltraGridAction.LastRowInBand, false, false);
                            }
                            else
                            {
                                Grid.PerformAction(UltraGridAction.NextRowByTab, false, false);
                                Grid.ActiveRow.Cells["destination"].Activate();
                                Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);
                            }



                        }
                        else
                        {
                            Grid.ActiveRow.Cells["destination"].Activate();
                            Grid.PerformAction(UltraGridAction.EnterEditMode, false, false);

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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["destination"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }
                    return;
                    //SendKeys.Send("{TAB}");
                }
                

            }
            #endregion
            #region txtProductID
            if (sender == txtRepID)
            {

                if (e.KeyCode.ToString() == "F2")
                {
                    if (oRep.ViewByID())
                    {
                        txtRepID.Text = oRep.ID.ToString();
                        txtDescription.Text = oRep.Name;
                        
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtRepID.Text.Trim().Length == 0)
                    {
                        txtRepID.Focus();
                    }

                    if (oRep.Find(txtRepID.Text))
                    {
                        txtRepID.Text = oRep.ID.ToString();
                        txtDescription.Text = oRep.Name;
                        
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
                    this.Delete();
                    txtAccountID.Focus();
                    break;
                case Keys.PageDown:
                    this.Save();
                    Grid.DataBind();
                    Clear();
                    txtAccountID.Clear();
                    txtAccountID.Focus();
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
                        Grid.ActiveCell = Grid.ActiveRow.Cells["destination"];
                        Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                    }


        }
        public void Save()
        {
            this.MoveLast();
            oeMail.DomainID = DomainID;
            oeMail.User = txtAccountID.Text;
            oeMail.Password = txtPassword.Text;

            try
            {
                oeMail.RepID = Convert.ToInt32(txtRepID.Text);
            }
            catch
            {
                oeMail.RepID = 0;
            }

            oeMail.Save();
            Clear();
            txtAccountID.Clear();
            oeMail.Items.dt.Rows.Clear();
            Grid.DataBind();


        }

        public void Delete()
        {
            
            oeMail.DomainID = DomainID;
            oeMail.User = txtAccountID.Text;
            oeMail.Password = txtPassword.Text;

            oeMail.Delete();
            Clear();
            txtAccountID.Clear();
            oeMail.Items.dt.Rows.Clear();
            Grid.DataBind();


        }
        public bool ShowVendor()
        {
            Clear();
            txtPassword.Text = oeMail.Password;
            txtRepID.Text = oeMail.RepID.ToString();
            if (oeMail.RepID != 0)
            {
                oRep.Find(oeMail.RepID);
                txtDescription.Text = oRep.Name;
             }
            return true;
        }
        public void Clear()
        {
            //Grid.Rows.Dispose();
            txtDescription.Clear();
            txtRepID.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtPassword.Text = "";
            txtRepID.Text = "";

           
        }
        public void MoveLast()
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow;
            gridRow = Grid.Rows[0];
            gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Last);
            if (gridRow != null)
            {

                gridRow.Activate();
                Grid.ActiveCell = Grid.ActiveRow.Cells["destination"];
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
                if (aUGRow.Cells["destination"].Text == Text)
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

        private void txtDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show(oeMail.GetDomainID(txtDomains.Items[txtDomains.SelectedIndex].ToString()).ToString());
            
            this.DomainID = oeMail.GetDomainID(txtDomains.Items[txtDomains.SelectedIndex].ToString());
            oeMail.DomainID = this.DomainID;
        }

	}
}
