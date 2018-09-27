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
	/// Summary description for Shortage.
	/// </summary>
	public sealed class frmShortage : frmBase
	{
		#region declarations		
        private SplitContainer splitContainer1;
        public Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor txtLocalPrint;
        private Label label21;
        private Signature.Windows.Forms.MaskedEditNumeric txtQuantity;
        private Label label20;
        private Label label19;
        private UltraGrid Grid;
        private Signature.Windows.Forms.Button btTracking;
        private Label label18;
        private Signature.Windows.Forms.Button txtCancel;
        private ComboBox cbType;
        private Signature.Windows.Forms.Button txtSave;
        private Signature.Windows.Forms.Button txtPrint;
        private Label label17;
        private Signature.Windows.Forms.MaskedLabel txtDescription;
        private Signature.Windows.Forms.MaskedEdit txtProductID;
        private Label label16;
        public Signature.Windows.Forms.MaskedEdit txtZipCode;
        private Label label14;
        public Signature.Windows.Forms.MaskedEdit txtState;
        private Label label2;
        public Signature.Windows.Forms.MaskedEdit txtCity;
        private Label label1;
        public Signature.Windows.Forms.MaskedEdit txtAddress;
        public Signature.Windows.Forms.MaskedEdit txtOrderID;
        private Label label13;
        private Signature.Windows.Forms.MaskedEditNumeric txtEvePhone;
        internal Label label12;
        public Signature.Windows.Forms.MaskedEditNumeric txtDayPhone;
        internal Label Label15;
        public Signature.Windows.Forms.MaskedEdit txteMail;
        private Label label11;
        private Label label10;
        public Signature.Windows.Forms.MaskedEdit txtTeacher;
        private Label label9;
        public Signature.Windows.Forms.MaskedEdit txtChild;
        private Label label8;
        private Label txtStudentName;
        public Signature.Windows.Forms.MaskedEdit txtName;
        private Label label6;
        public Signature.Windows.Forms.MaskedEdit txtShortageID;
        private Label label5;
        private Label label4;
        private Signature.Windows.Forms.MaskedEdit txtDetail;
        public Signature.Windows.Forms.MaskedEdit txtCustomerID;
        private Label label3;
        public Signature.Windows.Forms.MaskedEdit txtParent;
        private TreeView tvShortages;
        private Label label7;
        private Signature.Windows.Forms.MaskedEditNumeric txtRetail;
        private Signature.Windows.Forms.Button bViewOrder;
        internal Label txtDateTime;
        internal Label txtUser;
        #endregion
        
        private  Customer    oCustomer;
        private  Product     oProduct        = new Product();
        private  Shortage    oShortage;
        private Signature.Windows.Forms.ComboBox txtTrackingNumber;
        private Signature.Windows.Forms.Button btTrackingFedex;
        private  Shortage    oCurrentShortage= new Shortage();

        public frmShortage()
		{
			InitializeComponent();
           
            oCustomer = new Customer(this.CompanyID);

            //txtCustomerID.Enabled = false;
            txtOrderID.Enabled = false;
            Collapse();
            ultraGroupBox1.Focus();
            txtName.Focus();
            
		}

        public frmShortage(Customer oCustomer)
        {
            InitializeComponent();

            txtName.Text = oCustomer.Name;
            txtCustomerID.Text = oCustomer.ID;
            txteMail.Text = oCustomer.eMail;
            txtAddress.Text = oCustomer.Address;
            txtCity.Text = oCustomer.City;
            txtState.Text = oCustomer.State;
            txtZipCode.Text = oCustomer.ZipCode;
            txtChild.Text = oCustomer.Chairperson;
            txtParent.Enabled = false;
            txtTeacher.Enabled = false;
            txtDayPhone.Value = oCustomer.HeadPhone;


            this.oCustomer = oCustomer;
            //this.oCustomer.Find(CustomerID);

            txtCustomerID.Enabled = false;
            txtOrderID.Enabled = false;
            txtCustomerID.Text = oCustomer.ID;

            // Get Shortages

            String Current = "";
            Int32 Count = 0;
            TreeNode node = new TreeNode();
            DataTable dtShortages;
            if (this.CompanyID.Substring(0,2)!="GA")
                dtShortages = oMySql.GetDataTable(String.Format("Select * from Shortage Where CompanyID='{0}' And CustomerID='{1}' And OrderID=0 Order By Date",CompanyID,oCustomer.ID),"Shortages");
            else
                dtShortages = oMySql.GetDataTable(String.Format("Select * from Shortage Where CompanyID='{0}' And CustomerID='{1}' Order By Date", CompanyID, oCustomer.ID), "Shortages");

            foreach(DataRow row in dtShortages.Rows)
            {

                if (Current != row["Name"].ToString())
                {
                    node.Text += "(" + node.Nodes.Count.ToString() + ")";
                    //Node
                    node = new TreeNode(row["Name"].ToString() );
                    node.Tag = "";
                    tvShortages.Nodes.Add(node);
                    TreeNode ChildNode = new TreeNode("Classification: " + GetClassification(row["Type"].ToString()) + "\n  " + Global.ByteToString((byte[])row["Detail"]));
                    ChildNode.Tag = row["ShortageID"].ToString();
                    node.Nodes.Add(ChildNode);
                    Count = 1;
                }else 
                {   
                    //Child
                    TreeNode ChildNode = new TreeNode("Classification: " + GetClassification(row["Type"].ToString()) + "\n  " + Global.ByteToString((byte[])row["Detail"]));
                    ChildNode.Tag = row["ShortageID"].ToString();
                    
                    
                    node.Nodes.Add(ChildNode);
                    Count++;
                    continue;
                }
                
                Current = row["Name"].ToString();
                
            }
            tvShortages.ExpandAll();
            txtName.Focus();
        }

        public frmShortage(Order oOrder)
        {
            InitializeComponent();
            this.CompanyID = oOrder.CompanyID;
            this.txtOrderID.Text = oOrder.ID.ToString();
            this.txtCustomerID.Text = oOrder.oCustomer.ID;
            this.txtChild.Text = oOrder.Student;
            this.txtParent.Text = "";
            this.txtTeacher.Text = oOrder.Teacher;
            //frm.txtName.Text = oOrder.oCustomer.Name;
            //frm.txtAddress.Text = oOrder.oCustomer.Address;
            //frm.txtCity.Text = oOrder.oCustomer.City;
            //frm.txtZipCode.Text = oOrder.oCustomer.ZipCode;
            //frm.txtState.Text = oOrder.oCustomer.State;
            // frm.txtName.Enabled = false;
            this.oCustomer = oOrder.oCustomer;
            this.LoadBrochures();

            // Get Shortages

            String Key = "";
            String Current = "";
            Int32 Count = 0;
            TreeNode node = new TreeNode();
            DataTable dtShortages = oMySql.GetDataTable(String.Format("Select * from Shortage Where CompanyID='{0}' And OrderID='{1}' Order By Name", CompanyID, oOrder.ID), "Shortages");
            foreach (DataRow row in dtShortages.Rows)
            {

                if (row["Name"].ToString() == "")
                    Key = "NO NAME";
                else
                    Key = row["Name"].ToString();

                
                if (Current != Key)
                {
                    node.Text += "(" + node.Nodes.Count.ToString() + ")";
                    //Node
                    node = new TreeNode(Key);
                    node.Tag = "";
                    tvShortages.Nodes.Add(node);
                    TreeNode ChildNode = new TreeNode("Classification: " + GetClassification(row["Type"].ToString()) + "\n  " + Global.ByteToString((byte[])row["Detail"]));
                    ChildNode.Tag = row["ShortageID"].ToString();
                    node.Nodes.Add(ChildNode);
                    Count = 1;
                }
                else
                {
                    //Child
                    TreeNode ChildNode = new TreeNode("Classification: " + GetClassification(row["Type"].ToString()) + "\n  " + Global.ByteToString((byte[])row["Detail"]));
                    ChildNode.Tag = row["ShortageID"].ToString();


                    node.Nodes.Add(ChildNode);
                    Count++;
                    continue;
                }

                Current = Key; //row["Name"].ToString();

            }
            tvShortages.ExpandAll();
            if (tvShortages.Nodes.Count == 0)
                Collapse();
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Quantity", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 2);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvShortages = new System.Windows.Forms.TreeView();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btTrackingFedex = new Signature.Windows.Forms.Button();
            this.txtTrackingNumber = new Signature.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.Label();
            this.bViewOrder = new Signature.Windows.Forms.Button();
            this.txtRetail = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocalPrint = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label21 = new System.Windows.Forms.Label();
            this.txtQuantity = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btTracking = new Signature.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCancel = new Signature.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtSave = new Signature.Windows.Forms.Button();
            this.txtPrint = new Signature.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDescription = new Signature.Windows.Forms.MaskedLabel();
            this.txtProductID = new Signature.Windows.Forms.MaskedEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.txtZipCode = new Signature.Windows.Forms.MaskedEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtState = new Signature.Windows.Forms.MaskedEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCity = new Signature.Windows.Forms.MaskedEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new Signature.Windows.Forms.MaskedEdit();
            this.txtOrderID = new Signature.Windows.Forms.MaskedEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEvePhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDayPhone = new Signature.Windows.Forms.MaskedEditNumeric();
            this.Label15 = new System.Windows.Forms.Label();
            this.txteMail = new Signature.Windows.Forms.MaskedEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTeacher = new Signature.Windows.Forms.MaskedEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChild = new Signature.Windows.Forms.MaskedEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.Label();
            this.txtName = new Signature.Windows.Forms.MaskedEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShortageID = new Signature.Windows.Forms.MaskedEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetail = new Signature.Windows.Forms.MaskedEdit();
            this.txtCustomerID = new Signature.Windows.Forms.MaskedEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParent = new Signature.Windows.Forms.MaskedEdit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, 615);
            this.txtStatus.Size = new System.Drawing.Size(1085, 29);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvShortages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ultraGroupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1085, 615);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // tvShortages
            // 
            this.tvShortages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvShortages.Location = new System.Drawing.Point(0, 0);
            this.tvShortages.Name = "tvShortages";
            this.tvShortages.Size = new System.Drawing.Size(272, 615);
            this.tvShortages.TabIndex = 0;
            this.tvShortages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            this.tvShortages.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvShortages_NodeMouseClick);
            // 
            // ultraGroupBox1
            // 
            appearance1.AlphaLevel = ((short)(50));
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.btTrackingFedex);
            this.ultraGroupBox1.Controls.Add(this.txtTrackingNumber);
            this.ultraGroupBox1.Controls.Add(this.txtUser);
            this.ultraGroupBox1.Controls.Add(this.txtDateTime);
            this.ultraGroupBox1.Controls.Add(this.bViewOrder);
            this.ultraGroupBox1.Controls.Add(this.txtRetail);
            this.ultraGroupBox1.Controls.Add(this.label7);
            this.ultraGroupBox1.Controls.Add(this.txtLocalPrint);
            this.ultraGroupBox1.Controls.Add(this.label21);
            this.ultraGroupBox1.Controls.Add(this.txtQuantity);
            this.ultraGroupBox1.Controls.Add(this.label20);
            this.ultraGroupBox1.Controls.Add(this.label19);
            this.ultraGroupBox1.Controls.Add(this.Grid);
            this.ultraGroupBox1.Controls.Add(this.btTracking);
            this.ultraGroupBox1.Controls.Add(this.label18);
            this.ultraGroupBox1.Controls.Add(this.txtCancel);
            this.ultraGroupBox1.Controls.Add(this.cbType);
            this.ultraGroupBox1.Controls.Add(this.txtSave);
            this.ultraGroupBox1.Controls.Add(this.txtPrint);
            this.ultraGroupBox1.Controls.Add(this.label17);
            this.ultraGroupBox1.Controls.Add(this.txtDescription);
            this.ultraGroupBox1.Controls.Add(this.txtProductID);
            this.ultraGroupBox1.Controls.Add(this.label16);
            this.ultraGroupBox1.Controls.Add(this.txtZipCode);
            this.ultraGroupBox1.Controls.Add(this.label14);
            this.ultraGroupBox1.Controls.Add(this.txtState);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.txtCity);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.txtAddress);
            this.ultraGroupBox1.Controls.Add(this.txtOrderID);
            this.ultraGroupBox1.Controls.Add(this.label13);
            this.ultraGroupBox1.Controls.Add(this.txtEvePhone);
            this.ultraGroupBox1.Controls.Add(this.label12);
            this.ultraGroupBox1.Controls.Add(this.txtDayPhone);
            this.ultraGroupBox1.Controls.Add(this.Label15);
            this.ultraGroupBox1.Controls.Add(this.txteMail);
            this.ultraGroupBox1.Controls.Add(this.label11);
            this.ultraGroupBox1.Controls.Add(this.label10);
            this.ultraGroupBox1.Controls.Add(this.txtTeacher);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Controls.Add(this.txtChild);
            this.ultraGroupBox1.Controls.Add(this.label8);
            this.ultraGroupBox1.Controls.Add(this.txtStudentName);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.label6);
            this.ultraGroupBox1.Controls.Add(this.txtShortageID);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.txtDetail);
            this.ultraGroupBox1.Controls.Add(this.txtCustomerID);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtParent);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(809, 615);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btTrackingFedex
            // 
            this.btTrackingFedex.AllowDrop = true;
            this.btTrackingFedex.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btTrackingFedex.ForeColor = System.Drawing.Color.Black;
            this.btTrackingFedex.Location = new System.Drawing.Point(28, 567);
            this.btTrackingFedex.Name = "btTracking";
            this.btTrackingFedex.Size = new System.Drawing.Size(119, 28);
            this.btTrackingFedex.TabIndex = 312;
            this.btTrackingFedex.Text = "Tracking &Fedex";
            this.btTrackingFedex.Click += new System.EventHandler(this.btTrackingFedex_Click);
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.AllowDrop = true;
            this.txtTrackingNumber.DropDownHeight = 200;
            this.txtTrackingNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtTrackingNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtTrackingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackingNumber.IntegralHeight = false;
            this.txtTrackingNumber.Location = new System.Drawing.Point(108, 334);
            this.txtTrackingNumber.Name = "txtCollect";
            this.txtTrackingNumber.Size = new System.Drawing.Size(318, 20);
            this.txtTrackingNumber.TabIndex = 311;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(243, 388);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(183, 18);
            this.txtUser.TabIndex = 310;
            this.txtUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDateTime
            // 
            this.txtDateTime.BackColor = System.Drawing.Color.Transparent;
            this.txtDateTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTime.Location = new System.Drawing.Point(243, 362);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(183, 18);
            this.txtDateTime.TabIndex = 309;
            this.txtDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bViewOrder
            // 
            this.bViewOrder.AllowDrop = true;
            this.bViewOrder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bViewOrder.ForeColor = System.Drawing.Color.Black;
            this.bViewOrder.Location = new System.Drawing.Point(222, 87);
            this.bViewOrder.Name = "txtSave";
            this.bViewOrder.Size = new System.Drawing.Size(76, 25);
            this.bViewOrder.TabIndex = 21;
            this.bViewOrder.Text = "&ViewOrder";
            this.bViewOrder.Click += new System.EventHandler(this.bViewOrder_Click);
            // 
            // txtRetail
            // 
            this.txtRetail.AllowDrop = true;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Right";
            this.txtRetail.Appearance = appearance2;
            this.txtRetail.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRetail.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtRetail.FormatString = "###,###.##";
            this.txtRetail.InputMask = "{LOC}nnnnnnn.nn";
            this.txtRetail.Location = new System.Drawing.Point(729, 411);
            this.txtRetail.Name = "txtAmountDue";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Size = new System.Drawing.Size(64, 20);
            this.txtRetail.TabIndex = 308;
            this.txtRetail.Text = "0";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(690, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 307;
            this.label7.Text = "Total:";
            // 
            // txtLocalPrint
            // 
            this.txtLocalPrint.BackColor = System.Drawing.Color.Transparent;
            this.txtLocalPrint.BackColorInternal = System.Drawing.Color.Transparent;
            this.txtLocalPrint.Location = new System.Drawing.Point(663, 31);
            this.txtLocalPrint.Name = "txtLocalPrint";
            this.txtLocalPrint.Size = new System.Drawing.Size(17, 20);
            this.txtLocalPrint.TabIndex = 306;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(442, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(238, 19);
            this.label21.TabIndex = 305;
            this.label21.Text = "Use local printer:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowDrop = true;
            appearance3.ForeColorDisabled = System.Drawing.Color.White;
            this.txtQuantity.Appearance = appearance3;
            this.txtQuantity.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtQuantity.Location = new System.Drawing.Point(745, 159);
            this.txtQuantity.Name = "txtSigned";
            this.txtQuantity.PromptChar = ' ';
            this.txtQuantity.Size = new System.Drawing.Size(48, 20);
            this.txtQuantity.TabIndex = 17;
            this.txtQuantity.Text = "0";
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(442, 143);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 16);
            this.label20.TabIndex = 303;
            this.label20.Text = "Item:";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(742, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 16);
            this.label19.TabIndex = 302;
            this.label19.Text = "Quantity:";
            // 
            // Grid
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.Grid.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "ItemID";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 54;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 210;
            ultraGridColumn3.Header.Caption = "Qty";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.MaskInput = "nnn";
            ultraGridColumn3.Width = 31;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.DataType = typeof(double);
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "{double:7.2}";
            ultraGridColumn4.Width = 48;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.Grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.Grid.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.Grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.Grid.DisplayLayout.Override.CardAreaAppearance = appearance5;
            this.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Grid.DisplayLayout.Override.CellPadding = 3;
            appearance6.TextHAlignAsString = "Left";
            this.Grid.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance7.BorderColor = System.Drawing.Color.LightGray;
            appearance7.TextVAlignAsString = "Middle";
            this.Grid.DisplayLayout.Override.RowAppearance = appearance7;
            this.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.Grid.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Grid.Location = new System.Drawing.Point(443, 185);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(351, 221);
            this.Grid.TabIndex = 18;
            this.Grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // btTracking
            // 
            this.btTracking.AllowDrop = true;
            this.btTracking.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btTracking.ForeColor = System.Drawing.Color.Black;
            this.btTracking.Location = new System.Drawing.Point(190, 567);
            this.btTracking.Name = "btTracking";
            this.btTracking.Size = new System.Drawing.Size(119, 28);
            this.btTracking.TabIndex = 18;
            this.btTracking.Text = "&Tracking UPS";
            this.btTracking.Click += new System.EventHandler(this.btTracking_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(442, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 13);
            this.label18.TabIndex = 299;
            this.label18.Text = "Classificacion:";
            // 
            // txtCancel
            // 
            this.txtCancel.AllowDrop = true;
            this.txtCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCancel.ForeColor = System.Drawing.Color.Black;
            this.txtCancel.Location = new System.Drawing.Point(355, 567);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(119, 28);
            this.txtCancel.TabIndex = 19;
            this.txtCancel.Text = "&Cancel";
            this.txtCancel.Click += new System.EventHandler(this.txtCancel_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Add",
            "Overage",
            "Delete",
            "Miscellaneous",
            "Refund",
            "Damaged",
            "Missing",
            "Internet",
            "Missing Entire Order"});
            this.cbType.Location = new System.Drawing.Point(445, 94);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(276, 21);
            this.cbType.TabIndex = 15;
            this.cbType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtSave
            // 
            this.txtSave.AllowDrop = true;
            this.txtSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSave.ForeColor = System.Drawing.Color.Black;
            this.txtSave.Location = new System.Drawing.Point(516, 567);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(119, 28);
            this.txtSave.TabIndex = 20;
            this.txtSave.Text = "&Save";
            this.txtSave.Click += new System.EventHandler(this.txtSave_Click);
            // 
            // txtPrint
            // 
            this.txtPrint.AllowDrop = true;
            this.txtPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPrint.ForeColor = System.Drawing.Color.Black;
            this.txtPrint.Location = new System.Drawing.Point(678, 567);
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(115, 28);
            this.txtPrint.TabIndex = 21;
            this.txtPrint.Text = "&Print && Save";
            this.txtPrint.Click += new System.EventHandler(this.txtPrint_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(234, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 20);
            this.label17.TabIndex = 297;
            this.label17.Text = "(*) Fields required.";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowDrop = true;
            this.txtDescription.Location = new System.Drawing.Point(501, 159);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(238, 20);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.TabStop = true;
            this.txtDescription.Value = null;
            // 
            // txtProductID
            // 
            this.txtProductID.AllowDrop = true;
            this.txtProductID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Location = new System.Drawing.Point(443, 159);
            this.txtProductID.Name = "txtCustomerID";
            this.txtProductID.Size = new System.Drawing.Size(52, 20);
            this.txtProductID.TabIndex = 16;
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(25, 328);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 26);
            this.label16.TabIndex = 294;
            this.label16.Text = "Tracking Number:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.AllowDrop = true;
            this.txtZipCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.Location = new System.Drawing.Point(370, 282);
            this.txtZipCode.Name = "maskedEdit1";
            this.txtZipCode.Size = new System.Drawing.Size(56, 20);
            this.txtZipCode.TabIndex = 9;
            this.txtZipCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(317, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 18);
            this.label14.TabIndex = 292;
            this.label14.Text = "*ZipCode:";
            // 
            // txtState
            // 
            this.txtState.AllowDrop = true;
            this.txtState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Location = new System.Drawing.Point(270, 282);
            this.txtState.Name = "maskedEdit1";
            this.txtState.Size = new System.Drawing.Size(28, 20);
            this.txtState.TabIndex = 8;
            this.txtState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(234, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 290;
            this.label2.Text = "*State:";
            // 
            // txtCity
            // 
            this.txtCity.AllowDrop = true;
            this.txtCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(108, 282);
            this.txtCity.Name = "maskedEdit1";
            this.txtCity.Size = new System.Drawing.Size(110, 20);
            this.txtCity.TabIndex = 7;
            this.txtCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(25, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 288;
            this.label1.Text = "*City:";
            // 
            // txtAddress
            // 
            this.txtAddress.AllowDrop = true;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(108, 237);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "maskedEdit1";
            this.txtAddress.Size = new System.Drawing.Size(318, 39);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtOrderID
            // 
            this.txtOrderID.AllowDrop = true;
            this.txtOrderID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderID.Location = new System.Drawing.Point(108, 92);
            this.txtOrderID.Name = "txtCustomerID";
            this.txtOrderID.Size = new System.Drawing.Size(80, 20);
            this.txtOrderID.TabIndex = 22;
            this.txtOrderID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(25, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 20);
            this.label13.TabIndex = 287;
            this.label13.Text = "Order ID:";
            // 
            // txtEvePhone
            // 
            this.txtEvePhone.AllowDrop = true;
            appearance9.TextHAlignAsString = "Right";
            this.txtEvePhone.Appearance = appearance9;
            this.txtEvePhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEvePhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtEvePhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtEvePhone.InputMask = "(###) ###-####";
            this.txtEvePhone.Location = new System.Drawing.Point(108, 386);
            this.txtEvePhone.Name = "txtRetail";
            this.txtEvePhone.Size = new System.Drawing.Size(80, 20);
            this.txtEvePhone.TabIndex = 13;
            this.txtEvePhone.Text = "() -";
            this.txtEvePhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 386);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 18);
            this.label12.TabIndex = 230;
            this.label12.Text = "Eve Phone :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDayPhone
            // 
            this.txtDayPhone.AllowDrop = true;
            appearance10.TextHAlignAsString = "Right";
            this.txtDayPhone.Appearance = appearance10;
            this.txtDayPhone.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDayPhone.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDayPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtDayPhone.InputMask = "(###) ###-####";
            this.txtDayPhone.Location = new System.Drawing.Point(108, 360);
            this.txtDayPhone.Name = "txtRetail";
            this.txtDayPhone.Size = new System.Drawing.Size(80, 20);
            this.txtDayPhone.TabIndex = 12;
            this.txtDayPhone.Text = "() -";
            this.txtDayPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(12, 362);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(79, 18);
            this.Label15.TabIndex = 285;
            this.Label15.Text = "Day Phone :";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txteMail
            // 
            this.txteMail.AllowDrop = true;
            this.txteMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txteMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txteMail.Location = new System.Drawing.Point(108, 308);
            this.txteMail.Name = "maskedEdit1";
            this.txteMail.Size = new System.Drawing.Size(318, 20);
            this.txteMail.TabIndex = 10;
            this.txteMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(25, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 282;
            this.label11.Text = "eMail:";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(25, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 281;
            this.label10.Text = "*Address:";
            // 
            // txtTeacher
            // 
            this.txtTeacher.AllowDrop = true;
            this.txtTeacher.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeacher.Location = new System.Drawing.Point(108, 211);
            this.txtTeacher.Name = "maskedEdit1";
            this.txtTeacher.Size = new System.Drawing.Size(318, 20);
            this.txtTeacher.TabIndex = 5;
            this.txtTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(25, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 278;
            this.label9.Text = "Teacher:";
            // 
            // txtChild
            // 
            this.txtChild.AllowDrop = true;
            this.txtChild.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtChild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChild.Location = new System.Drawing.Point(108, 185);
            this.txtChild.Name = "maskedEdit1";
            this.txtChild.Size = new System.Drawing.Size(318, 20);
            this.txtChild.TabIndex = 4;
            this.txtChild.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(25, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 276;
            this.label8.Text = "*ATT/Child:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.BackColor = System.Drawing.Color.Transparent;
            this.txtStudentName.Location = new System.Drawing.Point(25, 159);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(401, 20);
            this.txtStudentName.TabIndex = 274;
            this.txtStudentName.Text = "Parent:";
            this.txtStudentName.Visible = false;
            // 
            // txtName
            // 
            this.txtName.AllowDrop = true;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(108, 133);
            this.txtName.Name = "maskedEdit1";
            this.txtName.Size = new System.Drawing.Size(318, 20);
            this.txtName.TabIndex = 3;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(25, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 272;
            this.label6.Text = "*Name:";
            // 
            // txtShortageID
            // 
            this.txtShortageID.AllowDrop = true;
            this.txtShortageID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtShortageID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortageID.Location = new System.Drawing.Point(108, 17);
            this.txtShortageID.Name = "txtCustomerID";
            this.txtShortageID.Size = new System.Drawing.Size(85, 20);
            this.txtShortageID.TabIndex = 20;
            this.txtShortageID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(25, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 269;
            this.label5.Text = "Shortage ID:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(27, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 267;
            this.label4.Text = "Notes:";
            // 
            // txtDetail
            // 
            this.txtDetail.AllowDrop = true;
            this.txtDetail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Location = new System.Drawing.Point(28, 434);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(766, 117);
            this.txtDetail.TabIndex = 14;
            this.txtDetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AllowDrop = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomerID.Location = new System.Drawing.Point(108, 66);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(80, 20);
            this.txtCustomerID.TabIndex = 21;
            this.txtCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(25, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Customer ID:";
            // 
            // txtParent
            // 
            this.txtParent.AllowDrop = true;
            this.txtParent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParent.Location = new System.Drawing.Point(108, 159);
            this.txtParent.Name = "maskedEdit1";
            this.txtParent.Size = new System.Drawing.Size(318, 20);
            this.txtParent.TabIndex = 5;
            this.txtParent.Visible = false;
            // 
            // frmShortage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1085, 644);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShortage";
            this.ShowInTaskbar = false;
            this.Text = "Shortage";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Shown += new System.EventHandler(this.frmShortage_Shown);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region  Events	
		
		private void frmOrder_Load(object sender, System.EventArgs e)
		{
            this.bViewOrder.Enabled = false;
            
            this.Text += " - " + this.CompanyID;
            oShortage = new Shortage(this.CompanyID);

            this.Grid.DataSource = oShortage.Items.Detail;
            this.Grid.DataBind();

            oShortage.Items.SubTotalChanged += new EventHandler(Items_SubTotalChanged);

            if (Global.CurrentUser == "UPS" || Global.CurrentUser == "ANNIE" || Global.CurrentUser == "JOYCE")
                cbType.SelectedIndex = 3;

            ultraGroupBox1.Focus();
            if (Global.CurrentUser == "ANNIE")
                txtDetail.Focus();
            else            
                txtName.Focus();
		}

        void Items_SubTotalChanged(object sender, EventArgs e)
        {
            txtRetail.Text = oShortage.Items.Retail.ToString();
        }
        public void Collapse()
        {
            this.Width = this.ultraGroupBox1.Width + 20;
            splitContainer1.Panel1Collapsed = true;
            
        }

     	private void txtCustomerID_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            
            #region tvShortages
            if (sender == tvShortages)
            {
                if (e.KeyCode == Keys.Return)
                {
                    TreeNode node = tvShortages.SelectedNode;
                    if (node.Tag != null)
                    {
                        if (oShortage.Find(node.Tag.ToString()))
                        {
                            if (CompanyID != oShortage.CompanyID)
                            {
                                MessageBox.Show("This Shortage belongs to : " + oShortage.CompanyID);
                                return;
                            }
                            oCurrentShortage = new Shortage(oShortage);
                            Display();
                            txtShortageID.Text = oShortage.ID;
                        }

                    }
                }
                return;
            }
            #endregion
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
                        oShortage.CustomerID = oCustomer.ID;
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        oCustomer.Brochures.Load(CompanyID, oShortage.CustomerID);
                        
                        
                    }
                    return; 
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
                        oShortage.CustomerID = oCustomer.ID;
                        txtCustomerID.Text = oCustomer.ID;
                        txtName.Text = oCustomer.Name;
                        oCustomer.Brochures.Load(CompanyID, oShortage.CustomerID);
                      
                    } else
                    {
                        Clear();
                        
                    }


                    
                }					

            }
            #endregion
            #region txtShortageID
            if (sender == txtShortageID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    oShortage.CustomerID = txtCustomerID.Text;
                    oShortage.OrderID = txtOrderID.Text;

                    if (oShortage.View())
                    {
                        if (CompanyID != oShortage.CompanyID)
                        {
                            MessageBox.Show("This Shortage belongs to : " + oShortage.CompanyID);
                            return;
                        }
                        
                        oCurrentShortage = new Shortage(oShortage);
                        Display();
                        txtShortageID.Text = oShortage.ID;
                     }
                    
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (oShortage.Find(txtShortageID.Text))
                    {
                        if (CompanyID != oShortage.CompanyID)
                        {
                            MessageBox.Show("This Shortage belongs to : " + oShortage.CompanyID);
                            return;
                        }
                        oCurrentShortage = new Shortage(oShortage);
                        Display();
                        txtShortageID.Text = oShortage.ID;
                    }
                    
                    return;
                }
            }

            #endregion
            #region txtAmount
            if (sender == txtOrderID)
            {

                if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.F3)
                {
                    return;
                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    

                    return;
                }

            }
            #endregion
            #region txtProductID
            if (sender == txtProductID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    oCustomer.Brochures.Load(CompanyID, oCustomer.ID);
                    
                    if (oProduct.View(oCustomer))
                    {
                        this.txtProductID.Text = oProduct.ID;
                        this.txtDescription.Text = oProduct.Description;

                        Boolean HasBrochure = false;
                        

                        foreach (BrochureByCustomer bc in oCustomer.Brochures)
                        {
                            
                            if (oProduct.IsInBrochure(bc.BrochureID))
                            {
                                HasBrochure = true;
                                break;
                            }

                        }
                        if (!HasBrochure)
                        {
                            Global.playSimpleSound();
                            MessageBox.Show("This Product Belongs to Other Brochure");
                            return;
                        }
                        //txtDetail.Text += oProduct.ID + "-" + oProduct.Description + "\x0D" + "\x0A";
                        txtQuantity.Text = "1";
                        txtQuantity.Focus();
                        return;
                    }
                    else
                    {
                        this.txtProductID.Clear();
                        this.txtProductID.Focus();
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return)
                {
                    if (oProduct.Find(txtProductID.Text))
                    {
                        this.txtProductID.Text = oProduct.ID;
                        this.txtDescription.Text = oProduct.Description;

                        oCustomer.Brochures.Load(CompanyID, oCustomer.ID);
                        Boolean HasBrochure = false;
                        foreach (BrochureByCustomer bc in oCustomer.Brochures)
                        {
                            if (oProduct.IsInBrochure(bc.BrochureID))
                            {
                                HasBrochure = true;
                                break;
                            }

                        }
                        if (!HasBrochure)
                        {
                            Global.playSimpleSound();
                            MessageBox.Show("This Product Belongs to Other Brochure");
                            return;
                        }



                       // txtDetail.Text += oProduct.ID + "-" + oProduct.Description + "\x0D" + "\x0A";
                        txtQuantity.Focus();
                        return;

                    }
                    else
                    {
                        this.txtProductID.Clear();
                        this.txtProductID.Focus();
                        return;
                    }
                }
            }
            #endregion
            #region txtQuantity
            if (sender == txtQuantity)
            {
                if (e.KeyCode == Keys.Return)
                {
                    if ((Int32)txtQuantity.Number > 0)
                    {
                        this.AddItem();
                    }
                    txtProductID.Clear();
                    txtProductID.Focus();
                    return;
                }

            }
            #endregion
            #region Grid
            if (sender == Grid)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    Grid.ActiveRow.Delete();
                    txtProductID.Focus();
                    oShortage.Items.CalculateRetail();
                    return;
                }
            }
            #endregion
            #region txtName
            if (sender == txtName)
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (txtName.Text.Trim().ToUpper() == "SCHOOL")
                    {
                        txtName.Text = oCustomer.Name;
                        txtAddress.Text = oCustomer.Address;
                        txtCity.Text = oCustomer.City;
                        txtZipCode.Text = oCustomer.ZipCode;
                        txtState.Text = oCustomer.State;
                        txtDayPhone.Value = oCustomer.HeadPhone;
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
                        this.SelectNextControl(this.splitContainer1.ActiveControl, true, true, true, true);
                    break; 
                case Keys.Enter:
				case Keys.Down:
                    if (sender == txtDetail || sender==txtAddress)
                        return;
                    this.SelectNextControl(this.splitContainer1.ActiveControl, true, true, true, true); 
					break;
				case Keys.Up:
                    if (sender == txtDetail || sender == txtAddress)
                        return;
                    this.SelectNextControl(this.splitContainer1.ActiveControl, false, true, true, true); 
					break;
                case Keys.F8:
                    break;
                case Keys.F3:
                    {
                        if (MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            MessageBox.Show("Operation Cancelled");
                            return;
                        }
                        else
                        {
                            oShortage.Delete();
                            Clear();
                            txtCustomerID.Focus();
                        }
                    }
                    break;
                case Keys.F7:
                    this.Close();
                    break;
                case Keys.F5:
                    Clear();
                    txtShortageID.Focus();
                    break;
                case Keys.PageDown:
                    Save();
                    oShortage.Print(txtLocalPrint.Checked);
                    if (Global.CurrentUser != "ANNIE")
                        this.Close();
                    else
                    {
                        Clear();
                        txtShortageID.Focus();
                    }
                    break;


					//case Keys.<some key>: 
					// ......; 
					// break; 
            }
            e.Handled =true;
            #endregion

        }
        private void txtPrint_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a classification type");
                return;
            }
            Save();
            oShortage.Print(txtLocalPrint.Checked);
            oShortage.Items.Detail.Rows.Clear();
            Grid.DataBind();

            if (Global.CurrentUser != "ANNIE")
                this.Close();
            else
            {
                Clear();
                txtShortageID.Focus();
            }
        }
        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSave_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a classification type");
                return;
            }
            Save();
            oShortage.Items.Detail.Rows.Clear();
            Grid.DataBind();
            if (Global.CurrentUser != "ANNIE")
                this.Close();
            else
            {
                Clear();
                txtShortageID.Focus();
            }
        }
        private void btTracking_Click(object sender, EventArgs e)
        {
            if (txtTrackingNumber.Text.Substring(0, 2) != "1Z")
            {
                MessageBox.Show("Fedex´s Tracking Number");
                return;
            }
            if (txtTrackingNumber.Text.Trim() != "")
            {
                frmTracking ofrm = new frmTracking(true);
                ofrm.txtTrackingNumber.Text = txtTrackingNumber.Text;
                ofrm.ShowDialog();
            }
        }

        #endregion
        
        #region  Methods
        public void Save()
        {
            String Type = "";
            switch (cbType.SelectedIndex)
            {
                case 0:
                    Type = "A";
                    break;
                case 1:
                    Type = "O";
                    break;
                case 2:
                    Type = "X";
                    break;
                case 3:
                    Type = "M";
                    break;
                case 4:
                    Type = "R";
                    break;
                case 5:
                    Type = "D";
                    break;
                case 6:
                    Type = "B";
                    break;
                case 7:
                    Type = "I";
                    break;
                case 8:
                    Type = "E";
                    break;

            }

            oShortage.Type = Type;
            oShortage.SchoolName = txtName.Text;
            oShortage.Address = txtAddress.Text.Replace("\n", " ").Replace("\r", " ");
            oShortage.Attention = txtChild.Text;
            oShortage.City = txtCity.Text;
            oShortage.ZipCode = txtZipCode.Text;
            oShortage.State = txtState.Text;
            oShortage.eMail = txteMail.Text;
            oShortage.QVNOption = txteMail.Text.IndexOf("@") > 0 ? "Y" : "N";
            oShortage.CustomerID = txtCustomerID.Text;
            oShortage.OrderID = txtOrderID.Text;
            oShortage.Detail = txtDetail.Text;
            oShortage.Date = DateTime.Now;
            oShortage.ParentName = txtParent.Text;
            oShortage.TeacherName = txtTeacher.Text;
            oShortage.StudentName = txtStudentName.Text;
            oShortage.DayPhone = txtDayPhone.Value.ToString();
            oShortage.EvePhone = txtEvePhone.Value.ToString();

            if (txtOrderID.Text.Trim() != "" && !oShortage.Detail.Contains("OrderID"))
            {
                oShortage.Detail += ("\r\n\r\n" + "OrderID: " + txtOrderID.Text);
            }

            if (txtOrderID.Text.Trim() != "" && !oShortage.Detail.Contains("Packer"))
            {   
                Packing oOrder = new Packing(this.CompanyID);
                if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
                {
                    oShortage.Detail += ("\r\n" + "Packer: " + oOrder.Packer);
                }
            }



            
           /* if (txtShortageID.Text == "")
                oShortage.Insert();
            else*/
            
            oShortage.Save(oCurrentShortage);

            //If Its Entire Order
            if (cbType.SelectedIndex == 8 && txtOrderID.Text.Trim() != String.Empty)
            {
                Order oOrder = new Order(this.CompanyID);
                if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
                {
                    oOrder.OpenPrinter(0);
                    oOrder.Print();
                    oOrder.ClosePrinter();
                }
                else
                    Global.ShowNotifier("Order " + txtOrderID.Text + "doesn't exist");
            }
            
            txtCustomerID.Clear();
            txtCustomerID.Focus();

            Clear();
        }
        public bool Display()
        {
            Clear();
            
            txtCustomerID.Text = oShortage.CustomerID;
            if (oCustomer.Find(oShortage.CustomerID))
                oCustomer.Brochures.Load(CompanyID, oShortage.CustomerID);
            txtDetail.Text    = oShortage.Detail;
            txtAddress.Text = oShortage.Address;
            txtChild.Text = oShortage.Attention;
            txtCity.Text = oShortage.City;
            txtState.Text = oShortage.State;
            txtZipCode.Text = oShortage.ZipCode;
            txteMail.Text = oShortage.eMail;
            txtParent.Text = oShortage.ParentName;
            txtTeacher.Text = oShortage.TeacherName;
            txtDayPhone.Text = oShortage.DayPhone;
            txtEvePhone.Text = oShortage.EvePhone;
            txtOrderID.Text = oShortage.OrderID;
            if (txtOrderID.Text != "")
                this.bViewOrder.Enabled = true;
            else
                this.bViewOrder.Enabled = false;

            txtCustomerID.Text = oShortage.CustomerID;
            txtName.Text = oShortage.SchoolName;
            txtTrackingNumber.Text = oShortage.TrakingNumber;
            if (oShortage.TrakingNumbers.Count > 1)
            {
                txtTrackingNumber.Items.Clear();
                txtTrackingNumber.DropDownStyle = ComboBoxStyle.DropDown;
                foreach(String elem in oShortage.TrakingNumbers)
                {
                    txtTrackingNumber.Items.Add(elem);
                }
            }
            else
            {
                txtTrackingNumber.DropDownStyle = ComboBoxStyle.Simple;
                txtTrackingNumber.Items.Clear();
            }

            txtStudentName.Text = oShortage.StudentName;
            txtDateTime.Text = "Date: " + oShortage.Date.ToString();
            txtUser.Text = "User: " + oShortage.User.ToString();

            int Index=-1;

            switch (oShortage.Type)
            {
                case "A":
                    Index = 0;
                    break;
                case "O":
                    Index = 1;
                    break;
                case "X":
                    Index =2 ;
                    break;
                case "M":
                    Index =3 ;
                    break;
                case "R":
                    Index =4 ;
                    break;
                case "D":
                    Index =5 ;
                    break;
                case "B":
                    Index = 6;
                    break;
                case "I":
                    Index = 7;
                    break;
                case "E":
                    Index = 8;
                    break;


            }
            cbType.SelectedIndex = Index;

            oShortage.Items.Load(oShortage);
            this.Grid.DataSource = oShortage.Items.Detail;
            this.Grid.DataBind();

            return true;
        }
        public void Clear()
        {
            txtCustomerID.Clear();
            txtDetail.Clear();
            txtAddress.Clear();
            txtChild.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZipCode.Clear();
            txteMail.Clear();
            txtParent.Clear();
            txtTeacher.Clear();
            txtDayPhone.Clear();
            txtEvePhone.Clear();
            txtOrderID.Clear();
            txtCustomerID.Clear();
            txtName.Clear();
            txtTrackingNumber.Text = "";
            txtStudentName.Text = "";
            txtDateTime.Text = "";
            txtUser.Text = "";
            
            
        }
        public void LoadBrochures()
        {
            oCustomer.Find(txtCustomerID.Text);
            oCustomer.Brochures.Load(CompanyID, txtCustomerID.Text);
        }
        private void AddItem()
        {
            try
            {
                DataRow rowNew = oShortage.Items.Detail.NewRow();
                rowNew["ProductID"] = txtProductID.Text;
                rowNew["Description"] = txtDescription.Text;
                rowNew["Quantity"] = txtQuantity.Text;
                rowNew["SubTotal"] = oProduct.ExtendedPrice(oCustomer) * Convert.ToInt32(txtQuantity.Text);
                oShortage.Items.Add(rowNew);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //"Unable to add new customer for given ID");
            }

            this.txtQuantity.Text = "";
            this.txtDescription.Text = "";
            this.txtProductID.Focus();
            return;
        }
        private String GetClassification(String Letter)
        {
            int Index = -1;

            switch (Letter)
            {
                case "A":
                    Index = 0;
                    break;
                case "O":
                    Index = 1;
                    break;
                case "X":
                    Index = 2;
                    break;
                case "M":
                    Index = 3;
                    break;
                case "R":
                    Index = 4;
                    break;
                case "D":
                    Index = 5;
                    break;
                case "B":
                    Index = 6;
                    break;
                case "I":
                    Index = 7;
                    break;


            }
            String[] Class = { "Add", "Overage", "Delete", "Miscellaneous", "Refund", "Damaged", "Missing", "Internet" };
            return (Index > -1)?Class[Index]:"Unkown";
        }
  		#endregion

        private void tvShortages_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (oShortage.Find(e.Node.Tag.ToString()))
                {
                    if (CompanyID != oShortage.CompanyID)
                    {
                        MessageBox.Show("This Shortage belongs to : " + oShortage.CompanyID);
                        return;
                    }
                    oCurrentShortage = new Shortage(oShortage);
                    Display();
                    txtShortageID.Text = oShortage.ID;
                }

            }
        }
        private void frmShortage_Shown(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Focus();
            txtName.Focus();
        }

        private void bViewOrder_Click(object sender, EventArgs e)
        {
            Order oOrder = new Order(this.CompanyID);
            if (oOrder.Find(Convert.ToInt32(txtOrderID.Text)))
            {
                frmOrder ofrmOrder = new frmOrder(oOrder);
                ofrmOrder._OrderProcess = OrderProcess.Enter;
                ofrmOrder.ShowDialog();
                ofrmOrder.Dispose();
            }
        }

        private void btTrackingFedex_Click(object sender, EventArgs e)
        {
            String myTargetURL = "";

            if (txtTrackingNumber.Text.Substring(0, 2) == "1Z")
            {
                MessageBox.Show("UPS´s Tracking Number");
                return;
            }   
                //    myTargetURL = "http://www.sigfund.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
            
            //else if (this.oOrder.ShoppingCart == ShoppingType.ChristianCollection)
                myTargetURL = "http://www.fedex.com/Tracking/Detail?trackNum=" + txtTrackingNumber.Text;
           /* else
                myTargetURL = "http://www.sigfund.com/db_cart_email.php?order=" + oOrder.IOrderID.ToString();
            */
            System.Diagnostics.Process.Start(myTargetURL);
        }
	}
}
