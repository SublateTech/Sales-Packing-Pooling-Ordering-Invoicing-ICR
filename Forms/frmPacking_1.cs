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
	public sealed class frmPacking_1 : frmBase
	{
		#region declarations		
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Signature.Windows.Forms.MaskedEdit txtStudent;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Label label10;
        private Signature.Windows.Forms.MaskedEditNumeric txtEntryDate;
        private Label lbCompany;
        private Label label11;
        private Signature.Windows.Forms.MaskedLabel txtName;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtBoxes;
        private Signature.Windows.Forms.MaskedEditNumeric txtOrderID;
        private UltraGrid Grid;
		#endregion


        Packing oOrder;
        private Order.Item IDetail;


        public frmPacking_1()
        {
            InitializeComponent();
            oOrder = new Packing(base.CompanyID);
        }
        public frmPacking_1(String CustomerID, String Teacher, String Student)
        {
            InitializeComponent();
            
            oOrder = new Packing(Global.GetParameter("CurrentCompany"));
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
        public frmPacking_1(Packing _oOrder)
        {
            InitializeComponent();
            oOrder = _oOrder;
            this.CompanyID = Global.GetParameter("CurrentCompany");
            txtOrderID.Text = oOrder.CustomerID;
            txtOrderID.Enabled = false;
            txtTeacher.Text = oOrder.Teacher;
            txtTeacher.Enabled = false;
            txtStudent.Text = oOrder.Student;
            txtStudent.Enabled = false;

            /*if (!ShowOrder(_oOrder.ID))
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("InvCode", 0);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 1);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 2);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Scanned", 3);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCompany = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEditNumeric();
            this.txtName = new Signature.Windows.Forms.MaskedLabel();
            this.txtStudent = new Signature.Windows.Forms.MaskedEdit();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBoxes = new Signature.Windows.Forms.MaskedEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntryDate = new Signature.Windows.Forms.MaskedEditNumeric();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.lbCompany);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(656, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 98);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lbCompany
            // 
            this.lbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCompany.Location = new System.Drawing.Point(78, 22);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(33, 19);
            this.lbCompany.TabIndex = 13;
            this.lbCompany.Text = "F07";
            this.lbCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "Company:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.groupBox2.Size = new System.Drawing.Size(645, 98);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Order Header ";
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtOrderID.Appearance = appearance1;
            this.txtOrderID.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtOrderID.InputMask = "nnnnnnnnn";
            this.txtOrderID.Location = new System.Drawing.Point(91, 16);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.PromptChar = ' ';
            this.txtOrderID.Size = new System.Drawing.Size(119, 20);
            this.txtOrderID.TabIndex = 0;
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
            this.txtName.Size = new System.Drawing.Size(412, 22);
            this.txtName.TabIndex = 12;
            this.txtName.TabStop = true;
            this.txtName.Value = null;
            // 
            // txtStudent
            // 
            this.txtStudent.AllowDrop = true;
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
            this.txtTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTeacher.Location = new System.Drawing.Point(92, 46);
            this.txtTeacher.Name = "txtCustomerID";
            this.txtTeacher.Size = new System.Drawing.Size(390, 21);
            this.txtTeacher.TabIndex = 2;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(30, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Order ID:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student/Seller:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teacher/Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.Grid);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(5, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 580);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Order Detail ";
            // 
            // Grid
            // 
            this.Grid.AllowDrop = true;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.Grid.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance4.FontData.SizeInPoints = 12F;
            ultraGridColumn1.CellAppearance = appearance4;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(71, 0);
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance5.FontData.SizeInPoints = 12F;
            ultraGridColumn2.CellAppearance = appearance5;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MaskInput = "";
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Width = 60;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance6.FontData.SizeInPoints = 12F;
            ultraGridColumn3.CellAppearance = appearance6;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "";
            ultraGridColumn3.MaxLength = 30;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(348, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Width = 190;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance7.FontData.SizeInPoints = 12F;
            ultraGridColumn4.CellAppearance = appearance7;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 7;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(71, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Width = 50;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance8.FontData.SizeInPoints = 12F;
            ultraGridColumn5.CellAppearance = appearance8;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "nnnnnnnnn";
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 9;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(76, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 54;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            appearance9.FontData.SizeInPoints = 20F;
            ultraGridBand1.Header.Appearance = appearance9;
            ultraGridBand1.UseRowLayout = true;
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.Grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Grid.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.Grid.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Grid.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Highlight;
            appearance14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grid.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.Grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Grid.DisplayLayout.Override.CellAppearance = appearance16;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 0;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.Grid.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.Grid.DisplayLayout.Override.RowAppearance = appearance19;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(8, 19);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(625, 540);
            this.Grid.TabIndex = 7;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Controls.Add(this.txtBoxes);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.txtProductID);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtEntryDate);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(656, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 580);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // txtBoxes
            // 
            this.txtBoxes.AllowDrop = true;
            this.txtBoxes.Location = new System.Drawing.Point(23, 332);
            this.txtBoxes.Name = "txtCustomerID";
            this.txtBoxes.Size = new System.Drawing.Size(92, 20);
            this.txtBoxes.TabIndex = 1;
            this.txtBoxes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "No Boxes:";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            appearance21.FontData.SizeInPoints = 12F;
            this.txtDescription.Appearance = appearance21;
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
            this.txtProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductID.Location = new System.Drawing.Point(6, 42);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(116, 20);
            this.txtProductID.TabIndex = 0;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Item:";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.AllowDrop = true;
            appearance22.TextHAlignAsString = "Right";
            this.txtEntryDate.Appearance = appearance22;
            this.txtEntryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.txtEntryDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date;
            this.txtEntryDate.InputMask = "{LOC}mm/dd/yyyy";
            this.txtEntryDate.Location = new System.Drawing.Point(35, 418);
            this.txtEntryDate.Name = "txtRetail";
            this.txtEntryDate.ReadOnly = true;
            this.txtEntryDate.Size = new System.Drawing.Size(73, 20);
            this.txtEntryDate.TabIndex = 28;
            this.txtEntryDate.Text = "//";
            // 
            // frmPacking_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 916);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPacking_1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing Orders";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
        
		
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.Text += " - " + this.CompanyID;
            this.lbCompany.Text = this.CompanyID;
            this.txtStudent.Enabled = false;
            this.txtTeacher.Enabled = false;
            this.txtOrderID.Focus();

            IDetail = new Order.Item();
            
         /*   Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            
            rc.SetCustomizedString("DeleteSingleRowPrompt", "");
            Grid.EventManager.AllEventsEnabled = false;
            Grid.EventManager.SetEnabled(EventGroups.AllEvents, false);*/
            
           
		}
        private void bPrint_Click(object sender, EventArgs e)
        {
            oOrder.OpenPrinter(1);
            oOrder.Print();
            oOrder.ClosePrinter();
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
                    
                    if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
                    {
                        if (CompanyID != oOrder.CompanyID)
                        {
                            MessageBox.Show("Different Order's Company/Season");
                            txtOrderID.Clear();
                            txtOrderID.Focus();
                            return;
                        }
                        
                        txtTeacher.Text = oOrder.Teacher;
                        txtStudent.Text = oOrder.Student;
                        this.ShowOrder(Convert.ToInt32(txtOrderID.Text));

                        if (oOrder.Packed)
                        {
                            MessageBox.Show("Order already packed " + oOrder.BoxesPacked.ToString()+" boxes");
                            txtBoxes.Enabled = true;
                            txtBoxes.Text = oOrder.BoxesPacked.ToString();
                            txtBoxes.Focus();

                            /* Clear();
                            txtOrderID.Clear();
                            txtOrderID.Focus();*/
                            return;
                        }
                        

                        txtOrderID.Enabled = false;
                        txtBoxes.Enabled = false;
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

					if (oOrder.oProduct.View())
                    {
                        this.txtProductID.Text = oOrder.oProduct.ID;
                        return;
                    }
                    
				}
                
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    txtDescription.Clear();
                    if (txtProductID.Text.ToUpper() == "DONE")
                    {
                        if (!oOrder.IfDone())
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
                        //txtOrderID.Enabled = true;
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
                            txtProductID.Text = oOrder.GetItem(txtProductID.Text);
                            if (txtProductID.Text == "")
                            {
                                Global.playSimpleSound(2);
                                txtDescription.Text = "PRODUCT NOT IN ORDER";
                                this.txtProductID.Clear();
                                this.txtProductID.Focus();
                                return;
                            }

                        }
                        //Check by Code

                    
                
                    
                    if (oOrder.ScanItems.Contains(txtProductID.Text))
                    {


                        if (oOrder.ScanItems[txtProductID.Text].Quantity < (oOrder.ScanItems[txtProductID.Text].Scanned + 1))
                        {
                            Global.playSimpleSound(3);
                            txtDescription.Text = "EXTRA PRODUCT !!!";
                            txtProductID.Clear();
                            return;
                        }

                        oOrder.ScanItems[txtProductID.Text].Scanned += 1;
                        //if (oOrder.ScanItems[txtProductID.Text].Scanned == oOrder.ScanItems[txtProductID.Text].Quantity)
                        //    DeleteRow();

                        this.txtDescription.Text = oOrder.ScanItems[txtProductID.Text].Description;
                        //this.ScannedItems.Text = oOrder.ScanItems[txtProductID.Text].ProductID + " - " + oOrder.ScanItems[txtProductID.Text].Description;
                        //this.ScannedItems.Items.Add(oOrder.ScanItems[txtProductID.Text].ProductID + " - " + oOrder.ScanItems[txtProductID.Text].Description);
                        if (oOrder.ScanItems[txtProductID.Text].Scanned == oOrder.ScanItems[txtProductID.Text].Quantity)
                        {
                            //oOrder.ScanItems[txtProductID.Text].Packed = "";
                            this.ActiveRow(true);
                            
                        }
                        else
                            this.ActiveRow(false);

                        Grid.DataBind();
                        
                        this.txtProductID.Clear();
                        //this.txtDescription.Text = ""; // 
                        
                        
                        return;

                    }
                    else
                    {
                        String Barcode2 = oOrder.GetSecondaryBarcode(txtProductID.Text);
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

                    oOrder.BoxesPacked = Convert.ToInt16(txtBoxes.Text);
                    oOrder.UpdatePacked(true);
                    
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
        

        private void ActiveRow(bool DeleteIt)
        {

             
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach ( UltraGridRow aUGRow in Grid.Rows)
                {
                    if (aUGRow.Cells["ProductID"].Value.ToString() == oOrder.ScanItems[txtProductID.Text].ProductID)
                        {
                        Grid.ActiveRow = aUGRow;
                        if (DeleteIt)
                        {
                            //Grid.ActiveRow.Delete();
                            Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.Gray;
                            Grid.DataBind();
                        }
                        //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                        if (!DeleteIt)
                            Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.White;
                        
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
                if (aUGRow.Cells["ProductID"].Value.ToString() == oOrder.ScanItems[txtProductID.Text].ProductID)
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

        public bool ShowOrder(Int32 OrderID)
        {
            this.ShowHeader();
            if (!oOrder.Packed)
                this.ShowDetail();
            return true;
        }
        public void Clear()
        {
            txtName.Clear();
            txtOrderID.Clear();
            txtTeacher.Clear();
            txtStudent.Clear();
            oOrder.ScanItems.Clear();
            txtProductID.Clear();
            txtBoxes.Clear();
            //ScannedItems.Items.Clear();
            txtEntryDate.Text = DateTime.Now.Date.ToString();
            Grid.DataBind();
            
        }
        private bool ShowHeader()
        {
            txtName.Text = oOrder.oCustomer.Name;
            txtEntryDate.Text = oOrder.Date.ToString();
            txtBoxes.Text = oOrder.BoxesPacked.ToString();
            lbCompany.Text = oOrder.CompanyID;
            
            return true;
        }
        private bool ShowDetail()
        {
            Grid.Rows.Dispose();
           
            Grid.DataSource = oOrder.ScanItems;
            Grid.DataBind();
            //lbTest.DisplayMember = "Description";
            return true;
        }
        private bool IfExist()
        {
            bool Exist = false;
            if (oOrder.ScanItems.ContainsKey(this.IDetail.ProductID))
                  Exist = true;
            return Exist;
        }
        public void Save()
        {

            
            oOrder.CompanyID    = CompanyID;
            oOrder.CustomerID   = txtOrderID.Text;
            oOrder.Teacher      = txtTeacher.Text;
            oOrder.Student      = txtStudent.Text;
            
            oOrder.Save(OrderType.Regular);
            Clear();
            txtStudent.Clear();

            
        }
        
	
		#endregion

        private void Grid_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;

        }

        private void txtBoxes_Enter(object sender, EventArgs e)
        {
            if (txtBoxes.Text == "")
                txtBoxes.Text = "1";
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {

        }
	}
}
