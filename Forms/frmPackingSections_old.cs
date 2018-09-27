using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Signature.Data;
using Signature.Classes;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinStatusBar;


namespace Signature.Forms
{
	/// <summary>
	/// Summary description for frmOrder.
	/// </summary>
	public sealed class frmPackingSections_Old
        : frmBase
	{
		#region declarations		

        private Signature.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Signature.Windows.Forms.GroupBox groupBox3;
        private Signature.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Label label10;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtBoxes;
        private UltraGrid Grid;
		#endregion
			
        PackingSection oPacking;
        private Order.Item IDetail;
        private String Title = "";
        private Signature.Windows.Forms.MaskedEdit txtOrderID;
        private frmTimerMessage ofrmMessage;
        private String SectionID;

        public frmPackingSections_Old()
        {
            InitializeComponent();
            oPacking = new PackingSection(base.CompanyID);
        }
        public frmPackingSections_Old(String CustomerID, String Teacher, String Student)
        {
            InitializeComponent();
            
            oPacking = new PackingSection(Global.GetParameter("CurrentCompany"));
            this.CompanyID = Global.GetParameter("CurrentCompany");
            txtOrderID.Text = CustomerID;
            txtOrderID.Enabled = false;
            txtTeacher.Text = Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = Student;
            txtStudent.Enabled = false;
            //if (!ShowOrder())
            //    MessageBox.Show("This Order doen't exist...");
            this.txtProductID.Focus();
            
        }
        public frmPackingSections_Old(PackingSection _oOrder)
        {
            InitializeComponent();
            oPacking = _oOrder;
            this.CompanyID = Global.GetParameter("CurrentCompany");
            txtOrderID.Text = oPacking.CustomerID;
            txtOrderID.Enabled = false;
            txtTeacher.Text = oPacking.Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = oPacking.Student;
            txtStudent.Enabled = false;

            /*if (!ShowOrder(_oPacking.ID))
            {
                MessageBox.Show("This Order doen't exist...");
                this.Dispose();
            } */  
            this.txtProductID.Focus();

        }
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InvCode", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 1);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Scanned", 3);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packed", 4);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.groupBox2 = new Signature.Windows.Forms.GroupBox();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEdit();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new Signature.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox4 = new Signature.Windows.Forms.GroupBox();
            this.txtBoxes = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 696);
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.BorderColor3DBase = System.Drawing.Color.Silver;
            ultraStatusPanel1.Appearance = appearance18;
            this.txtStatus.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.txtStatus.Size = new System.Drawing.Size(845, 29);
            this.txtStatus.PanelClick += new Infragistics.Win.UltraWinStatusBar.PanelClickEventHandler(this.txtStatus_PanelClick);
            // 
            // groupBox2
            // 
            this.groupBox2.AllowDrop = true;
            appearance1.AlphaLevel = ((short)(95));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Appearance = appearance1;
            this.groupBox2.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtOrderID);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtStudent);
            this.groupBox2.Controls.Add(this.txtTeacher);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(835, 98);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.Text = " Order Header ";
            this.groupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            this.txtOrderID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderID.Location = new System.Drawing.Point(92, 17);
            this.txtOrderID.MaxLength = 15;
            this.txtOrderID.Name = "txtCustomerID";
            this.txtOrderID.Size = new System.Drawing.Size(123, 20);
            this.txtOrderID.TabIndex = 32;
            this.txtOrderID.WordWrap = false;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.SizeInPoints = 15F;
            this.txtName.Appearance = appearance2;
            this.txtName.Location = new System.Drawing.Point(221, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(447, 22);
            this.txtName.TabIndex = 12;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
            this.txtStudent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtStudent.Location = new System.Drawing.Point(92, 70);
            this.txtStudent.Name = "txtCustomerID";
            this.txtStudent.Size = new System.Drawing.Size(390, 21);
            this.txtStudent.TabIndex = 3;
            this.txtStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(92, 46);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(390, 21);
            this.txtTeacher.TabIndex = 2;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(30, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Order ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox3.Location = new System.Drawing.Point(5, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 580);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.Text = " Order Detail ";
            this.groupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance5.FontData.SizeInPoints = 12F;
            ultraGridColumn1.CellAppearance = appearance5;
            ultraGridColumn1.Header.VisiblePosition = 4;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(71, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance6.FontData.SizeInPoints = 12F;
            ultraGridColumn2.CellAppearance = appearance6;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.MaskInput = "";
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Width = 60;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance7.FontData.SizeInPoints = 12F;
            ultraGridColumn3.CellAppearance = appearance7;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.MaskInput = "";
            ultraGridColumn3.MaxLength = 30;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(387, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Width = 190;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance8.FontData.SizeInPoints = 12F;
            ultraGridColumn4.CellAppearance = appearance8;
            ultraGridColumn4.DataType = typeof(short);
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.MaskInput = "nnn";
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(60, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 50;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance9.FontData.SizeInPoints = 12F;
            ultraGridColumn5.CellAppearance = appearance9;
            ultraGridColumn5.DataType = typeof(short);
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.MaskInput = "nnn";
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(54, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 54;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            appearance10.FontData.SizeInPoints = 20F;
            ultraGridBand1.Header.Appearance = appearance10;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance11;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 3;
            appearance12.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance13.BorderColor = System.Drawing.Color.LightGray;
            appearance13.TextVAlignAsString = "Middle";
            this.Grid.DisplayLayout.Override.RowAppearance = appearance13;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance14.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance14.BorderColor = System.Drawing.Color.RoyalBlue;
            appearance14.ForeColor = System.Drawing.Color.Blue;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            this.Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid.Location = new System.Drawing.Point(8, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(688, 553);
            this.Grid.TabIndex = 7;
            this.Grid.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.Grid_BeforeRowsDeleted);
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.AllowDrop = true;
            appearance15.AlphaLevel = ((short)(95));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Appearance = appearance15;
            this.groupBox4.BackColorInternal = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.txtBoxes);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.txtProductID);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtEntryDate);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(712, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 580);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txtBoxes
            // 
            this.txtBoxes.AllowDrop = true;
            this.txtBoxes.BackColor = System.Drawing.Color.White;
            this.txtBoxes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxes.Location = new System.Drawing.Point(23, 332);
            this.txtBoxes.Name = "txtCustomerID";
            this.txtBoxes.Size = new System.Drawing.Size(92, 30);
            this.txtBoxes.TabIndex = 1;
            this.txtBoxes.Leave += new System.EventHandler(this.txtBoxes_Leave);
            this.txtBoxes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.txtBoxes.Enter += new System.EventHandler(this.txtBoxes_Enter);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(40, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "No Boxes:";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(28, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Scanned Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            appearance16.FontData.SizeInPoints = 12F;
            this.txtDescription.Appearance = appearance16;
            this.txtDescription.Location = new System.Drawing.Point(9, 68);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(112, 179);
            this.txtDescription.TabIndex = 24;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(6, 42);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(116, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Item:";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance17.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance17;
            this.txtEntryDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(19, 410);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 28;
            this.txtEntryDate.Text = "//";
            this.txtEntryDate.Visible = false;
            // 
            // frmPackingSections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(845, 725);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPackingSections";
            this.ShowInTaskbar = false;
            this.Text = "Packing Orders By Sections";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox4)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        private void frmOrder_Load(object sender, System.EventArgs e)
		{
            
            this.Text += " - " + this.CompanyID;
            this.Title = this.Text;
           
            this.txtStudent.Enabled = false;
            this.txtTeacher.Enabled = false;
            this.txtOrderID.Focus();

            IDetail = new Order.Item();

            if (!Global.InDesignMode())
            {
                this.txtStatus.Panels[5].Text = "Packing [" + Global.CurrrentLine + "]";
                Pack oPack = new Pack(this.CompanyID);
                if (oPack.Find(Global.CurrrentLine))
                    this.txtStatus.Panels[5].Text = "Packing [" + oPack.Description + "]";

                this.txtStatus.Panels[6].Text = "Section [" + Global.CurrrentSection + "]";
            }
            
            
         /*   Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            
            rc.SetCustomizedString("DeleteSingleRowPrompt", "");
            Grid.EventManager.AllEventsEnabled = false;
            Grid.EventManager.SetEnabled(EventGroups.AllEvents, false);*/

            //PrintTitle();
		}
        private void bPrint_Click(object sender, EventArgs e)
        {
            oPacking.OpenPrinter(1);
            oPacking.Print();
            oPacking.ClosePrinter();
        }
		private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            #region txtOrderID
            if (sender==txtOrderID)	
			{
				
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
				{
                    if (txtOrderID.Text.Trim() == "")
                    {
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }
                    
                    int split = txtOrderID.Text.IndexOf('.');
                    if (split > -1)
                    {
                        txtOrderID.Text = txtOrderID.Text.Substring(0, split).Trim();
                    }
                    
                    Int32 OrderID;
                    try
                    {
                        OrderID = Convert.ToInt32(txtOrderID.Text);
                    }
                    catch (Exception ex)
                    {
                        Global.ShowNotifier(ex.Message);
                        Global.playSimpleSound(3);
                        Clear();
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }

                    this.SectionID = Global.CurrrentSection;

                    
                    if (oPacking.Find(OrderID,Global.CurrrentLine,this.SectionID, false))
                    {   
                        /*
                        if (oPacking.ScanItems.Count == 0 && oPacking.NoItems == 0)
                        {
                            ShowMessage("This order does exist but has no items with this product type: " + Global.CurrrentLine + " or Section:" + Global.CurrrentSection, Color.Green);

                            txtOrderID.Clear();
                            txtOrderID.Focus();
                            return;
                        }
                         */
                        txtTeacher.Text = oPacking.Teacher;
                        txtStudent.Text = oPacking.Student;

                        Order.PackByOrder oOB = new Order.PackByOrder();
                        if (oOB.Find(Convert.ToInt32(txtOrderID.Text), Global.CurrrentLine))
                        {
                            if (oOB.Packed) //  (oPacking.Packed)
                            {
                                ShowMessage("Order already packed by " + oOB.Packer + "   " + oOB.BoxesPacked.ToString() + " boxes",Color.Red);
                                txtBoxes.Enabled = true;
                                txtBoxes.Text = oOB.BoxesPacked.ToString();
                                txtBoxes.Focus();
                                return;
                            }
                        }

                        if (CompanyID != oPacking.CompanyID)
                        {
                            
                            MessageBox.Show("Different Order's Company/Season");
                            Clear();
                            txtOrderID.Clear();
                            txtOrderID.Focus();
                            return;
                        }



                        oPacking.CreateSections();
                        oPacking.SectionID = this.SectionID;
                        


                        if (oPacking.Find())
                        {
                            if (oPacking.PackedScanned)
                            {

                                ShowMessage("This order section: " + Global.CurrrentSection + " was already packed ", Color.Red);
                                Clear();
                                txtOrderID.Clear();
                                txtOrderID.Focus();
                                return;
                            }
                            
                            if (oPacking.Quantity == 0 && oPacking.ScanItems.Count == 0)
                            {
                                if (oPacking.GetOrderCloserSection() == oPacking.SectionID)
                                {
                                    Global.playSimpleSound();
                                    ShowMessage("No Items In This Section, Please Proceed To Close The Order", Color.Green);
                                    DoneProcess();
                                    return;
                                }
                                ShowMessage("No Items In This Section, Please Proceed To The Next Section", Color.Red);
                                Clear();
                                txtOrderID.Clear();
                                txtOrderID.Focus();
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("No Section Found!, Please Contact IT", Color.Red);
                            Clear();
                            txtOrderID.Clear();
                            txtOrderID.Focus();
                            return;
                        }
                        

                        /*
                        if (oPacking.Packed)
                        {
                            MessageBox.Show("Order already packed by " + oPacking.Packer + "   " + oPacking.BoxesPacked.ToString()+" boxes");
                            txtBoxes.Enabled = true;
                            txtBoxes.Text = oPacking.BoxesPacked.ToString();
                            txtBoxes.Focus();
  
                            return;
                        }
                        */
                        this.ShowOrder();
                        txtOrderID.Enabled = false;
                        txtBoxes.Enabled = false;
                        txtProductID.BackColor = Color.White;
                        txtProductID.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Order not found...");
                        txtOrderID.Clear();
                        txtOrderID.Focus();
                        return;
                    }
                    
				}

            }
            #endregion
            #region txtProductID
            if (sender==txtProductID)	
			{
				
				if (e.KeyCode.ToString()=="F8")
				{
					this.Grid.Focus();
				}

                
                if (e.KeyCode.ToString()=="F2")
				{

					if (oPacking.oProduct.View())
                    {
                        this.txtProductID.Text = oPacking.oProduct.ID;
                        return;
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    txtDescription.Clear();
                    if (txtProductID.Text.ToUpper() == "DONE")
                    {
                        if (oPacking.GetOrderCloserSection() == this.SectionID)
                        {
                            DoneProcess();
                            return;
                        }
                        return;
                    
                    }

                    if (txtProductID.Text.ToUpper() == "ABORT")
                        {
                            Clear();
                            groupBox2.Focus();
                            txtOrderID.Enabled = true;
                            txtOrderID.Focus();
                            return;
                        }
                    BarCode_2:
                        if (txtProductID.Text.Length < 12)
                        {
                            if (!oPacking.ScanItems.Contains(txtProductID.Text))
                            {
                                txtProductID.Text = oPacking.GetItem(txtProductID.Text);
                                if (txtProductID.Text == "")
                                {
                                    Global.playSimpleSound(2);
                                    txtDescription.Text = "PRODUCT NOT IN ORDER";
                                    this.txtProductID.Clear();
                                    this.txtProductID.Focus();
                                    return;
                                }
                            }

                        }
                        //Check by Code

                    
                
                    
                    if (oPacking.ScanItems.Contains(txtProductID.Text))
                    {


                        if (oPacking.ScanItems[txtProductID.Text].Quantity < (oPacking.ScanItems[txtProductID.Text].Scanned + 1))
                        {
                            Global.playSimpleSound(3);
                            txtDescription.Text = "EXTRA PRODUCT !!!";
                            txtProductID.Clear();
                            return;
                        }

                        oPacking.ScanItems[txtProductID.Text].Scanned += 1;
                        //if (oPacking.ScanItems[txtProductID.Text].Scanned == oPacking.ScanItems[txtProductID.Text].Quantity)
                        //    DeleteRow();

                        this.txtDescription.Text = oPacking.ScanItems[txtProductID.Text].Description;
                        //this.ScannedItems.Text = oPacking.ScanItems[txtProductID.Text].ProductID + " - " + oPacking.ScanItems[txtProductID.Text].Description;
                        //this.ScannedItems.Items.Add(oPacking.ScanItems[txtProductID.Text].ProductID + " - " + oPacking.ScanItems[txtProductID.Text].Description);
                        if (oPacking.ScanItems[txtProductID.Text].Scanned == oPacking.ScanItems[txtProductID.Text].Quantity)
                        {
                            //oPacking.ScanItems[txtProductID.Text].Packed = "";
                            this.ActiveRow(true);
                            if (oPacking.ScanItems.Count == 0)
                            {
                                oPacking.PackedScanned = true;
                                oPacking.Update();

                                if (oPacking.GetOrderCloserSection() == this.SectionID)
                                {
                                    Global.playSimpleSound();
                                    DoneProcess();
                                    return;
                                }
                               
                                ShowMessage("This order section: " + this.SectionID + " has no more items, next order... ", Color.Green);
                                Clear();
                                groupBox2.Focus();
                                txtOrderID.Enabled = true;
                                txtOrderID.Focus();
                                return;
                            }
                        }
                        else
                            this.ActiveRow(false);

                       // Grid.DataBind();
                        
                        this.txtProductID.Clear();
                        //this.txtDescription.Text = ""; // 
                        
                        
                        return;

                    }
                    else
                    {
                        String Barcode2 = oPacking.GetSecondaryBarcode(txtProductID.Text);
                        if (Barcode2 != "")
                        {
                            txtProductID.Text = Barcode2;
                            goto BarCode_2;
                        }
    
                        Global.playSimpleSound(5);
                        txtDescription.Text = "PRODUCT NOT IN ORDER";
                        this.txtProductID.Clear();
                        this.txtProductID.Focus();
                        return;
                    }
                }					

            }
            #endregion
            #region txtBoxes
            if (sender==txtBoxes)	
			{
				
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (txtBoxes.Text == "")
                    {
                        txtBoxes.Focus();
                        return;
                    }
                    if (txtBoxes.Text.ToUpper() == "DONE" || txtBoxes.Text.ToUpper() == "ONE")
                        txtBoxes.Text = "1";

                    try
                    {
                        oPacking.BoxesPacked = Convert.ToInt16(txtBoxes.Text);
                        //oPacking.Lines[Global.CurrrentLine].BoxesPacked = Convert.ToInt16(txtBoxes.Text);
                    }
                    catch
                    {
                        txtBoxes.Text = "";
                        txtBoxes.Focus();
                        return;
                    }

                    oPacking.UpdatePacked(true,Global.CurrrentLine);

                    oPacking.DeleteRecords();
                    
                    Clear();
                    txtBoxes.Enabled = false;
                    txtOrderID.Enabled = true;
                    txtOrderID.Focus();

                    return;
                }					

            }
            #endregion
            #region txtGrid
             if (sender==this.Grid)
             {
                 //MessageBox.Show(e.KeyData.ToString());
                 if (Char.IsDigit(Convert.ToChar(e.KeyValue)))
                 {   
                     txtProductID.Focus();
                     txtProductID.Text += Convert.ToChar(e.KeyValue).ToString();
                     SendKeys.Send("{END}");
                     return;
                 }
                
                 if (e.KeyCode.ToString()=="F8")
				{
					this.txtProductID.Focus();
					return;
				}
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                {
                    
                    //return;
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
                case Keys.F8:
                    this.Grid.Focus();
                    break;
                case Keys.F3:
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
        private void ShowMessage(String Message, Color _Color)
        {
            if (_Color == Color.Green)
                Global.playSimpleSound(6);

            ofrmMessage = new frmTimerMessage();
            ofrmMessage.FontMessage = new Font("Microsoft Sans Serif", 30);
            ofrmMessage.Message = Message;
            ofrmMessage.MsgColor = _Color;
            ofrmMessage.TopLevel = true;
            ofrmMessage.TimeLapse = 1500;
            ofrmMessage.ShowDialog();

        }
        private void DoneProcess()
        {
            if (ArePendingSections())
            {
                Clear();
                txtOrderID.Clear();
                txtOrderID.Focus();
                return;
            }
            if (!oPacking.IfDone() || oPacking.ScanItems.Count > 0)
                {

                    Global.playSimpleSound(1);
                    txtDescription.Text = "You have products left";
                    ActiveLeft();
                    txtProductID.Clear();
                    txtProductID.Focus();
                    return;
                }
            
            txtBoxes.Clear();
            txtBoxes.Enabled = true;
            txtBoxes.Focus();
        }

        private Boolean LoadPendingSections()
        {
            return false;
        }
        
        private Boolean ArePendingSections()
        {
            DataTable oData = oPacking.GetPendingSections();
            if (oData.Rows.Count > 0)
            {
                ShowMessage("At least you have " + oData.Rows[0]["Description"].ToString() + " Section Pending...", Color.Red);
                return true;
            }
            else
                return false;
        }
        private void PrintTitle()
        {
            oPacking.GetRankingByUser();
            //this.Text = Title + String.Format("                     Orders: {0}    Boxes: {1}    Items: {2}", oPacking.PackedOrders, oPacking.PackedBoxes, oPacking.PackedItems);
        }
        private void ActiveRow(bool DeleteIt)
        {

             
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach ( UltraGridRow aUGRow in Grid.Rows)
                {
                    if (aUGRow.Cells["ProductID"].Value.ToString() == oPacking.ScanItems[txtProductID.Text].ProductID)
                    {
                        Grid.ActiveRow = aUGRow;
                        Grid.ActiveRow.Refresh();
                        Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.LightBlue;
                        if (DeleteIt)
                        {
                            Grid.ActiveRow.Delete();
                            //Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.Gray;
                            Grid.DataBind();
                        }
                        break;
                    }
                   // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
                }
        }
        private void DeleteRow()
        {

            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                if (aUGRow.Cells["ProductID"].Value.ToString() == oPacking.ScanItems[txtProductID.Text].ProductID)
                {
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveRow.Delete();
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    //Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.White;
                    break;
                }

                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }
        private void ActiveLeft()
        {


            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                if ((int) aUGRow.Cells["Quantity"].Value > (int) aUGRow.Cells["Scanned"].Value)
                {
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.Red;
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    
                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
        }

        #region  Methods

        public bool ShowOrder()
        {
            this.ShowHeader();
       //     if (!oPacking.Packed)
                this.ShowDetail();
            return true;
        }
        public void Clear()
        {
            txtName.Clear();
            txtOrderID.Clear();
            txtTeacher.Clear();
            txtStudent.Clear();
            oPacking.ScanItems.Clear();
            txtProductID.Clear();
            txtBoxes.Clear();
            this.SectionID = "";
            oPacking.Clear();
            //ScannedItems.Items.Clear();
            txtEntryDate.Text = DateTime.Now.Date.ToString();
            Grid.DataBind();
            
        }
        private bool ShowHeader()
        {
            txtName.Text = oPacking.oCustomer.Name;
            txtEntryDate.Text = oPacking.Date.ToString();
            txtBoxes.Text = oPacking.BoxesPacked.ToString();
            
            
            return true;
        }
        private bool ShowDetail()
        {
            Grid.Rows.Dispose();
           
            Grid.DataSource = oPacking.ScanItems;
            Grid.DataBind();
            //lbTest.DisplayMember = "Description";
            return true;
        }
        private bool IfExist()
        {
            bool Exist = false;
            if (oPacking.ScanItems.ContainsKey(this.IDetail.ProductID))
                  Exist = true;
            return Exist;
        }
    
		#endregion

        private void Grid_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;

        }

        private void txtBoxes_Enter(object sender, EventArgs e)
        {
            txtBoxes.BackColor = Color.Yellow;
        }

        private void txtBoxes_Leave(object sender, EventArgs e)
        {
            txtBoxes.BackColor = Color.White;
        }

        private void txtStatus_PanelClick(object sender, PanelClickEventArgs e)
        {
            
            
            
            switch(e.Panel.Index)
            
            {
                case 5:
                    {

                        // frmLine ofrm = new frmLine();
                        // ofrm.ShowDialog();
                        Pack oPack = new Pack(this.CompanyID);
                        if (oPack.View())
                        {
                            Global.SetParameter("CurrentLine", oPack.ID);
                            //if (oPack.Find(Global.CurrrentLine))
                            this.txtStatus.Panels[5].Text = "Packing [" + oPack.Description + "]";
                        }
                    }
                    break;

                case 6:
                    {
                        String Op = this.txtStatus.Panels[6].Text.Replace("Section", "").Replace("[", "").Replace("]", "").Trim();
                        switch (Op)
                        {
                            case "1":
                                Global.SetParameter("CurrentSection", "2");
                                break;
                            case "2":
                                Global.SetParameter("CurrentSection", "3");
                                break;
                            case "3":
                                Global.SetParameter("CurrentSection", "4");
                                break;
                            case "4":
                                Global.SetParameter("CurrentSection", "5");
                                break;
                            case "5":
                                Global.SetParameter("CurrentSection", "6");
                                break;
                            case "6":
                                Global.SetParameter("CurrentSection", "7");
                                break;
                            case "7":
                                Global.SetParameter("CurrentSection", "1");
                                break;

                        }
                        this.txtStatus.Panels[6].Text = "Section [" + Global.CurrrentSection + "]";                      

                    }
                    break;
            }
        }

	}
}
