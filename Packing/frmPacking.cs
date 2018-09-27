using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;


namespace Signature
{
    public partial class frmPacking : frmBase
    {
        
        Packing oOrder;
        private Order.Item IDetail;
        
         public frmPacking()
        {
            InitializeComponent();
            oOrder = new Packing(base.CompanyID);
        }
        public frmPacking(String CustomerID, String Teacher, String Student)
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
        public frmPacking(Packing _oOrder)
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

        private void frmPacking_Load(object sender, EventArgs e)
        {
            this.Text += " - " + this.CompanyID;
            this.lbCompany.Text = this.CompanyID;
            this.txtStudent.Enabled = false;
            this.txtTeacher.Enabled = false;
            this.txtOrderID.Focus();

            IDetail = new Order.Item();
        }

        private void txtOrderID_KeyUp(object sender, KeyEventArgs e)
        {

            #region txtOrderID
            if (sender == txtOrderID)
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
                            MessageBox.Show("Order already packed " + oOrder.BoxesPacked.ToString() + " boxes");
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
            if (sender == txtProductID)
            {

                if (e.KeyCode.ToString() == "F8")
                {
                    this.listView.Focus();
                }


                if (e.KeyCode.ToString() == "F2")
                {

                    if (oOrder.oProduct.View())
                    {
                        this.txtProductID.Text = oOrder.oProduct.ID;
                        return;
                    }

                }

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    txtDescription.Text="";
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
                        this.txtDescription.Text = oOrder.ScanItems[txtProductID.Text].Description;

                        //this.listView.DataBind();
                        if (oOrder.ScanItems[txtProductID.Text].Scanned == oOrder.ScanItems[txtProductID.Text].Quantity)
                        {
                            //oOrder.ScanItems[txtProductID.Text].Packed = "";
                           this.ActiveRow(true);

                        }
                        else
                            this.ActiveRow(false);

                        this.txtProductID.Clear();
                        
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
            if (sender == txtBoxes)
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
           /* if (sender == this.Grid)
            {
                if (e.KeyCode.ToString() == "F8")
                {
                    this.txtProductID.Focus();
                    return;
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                {

                    //return;
                }
            }*/

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
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    break;
                case Keys.F8:
                    this.listView.Focus();
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
        private void ActiveRow(bool DeleteIt)
        {
            
            listView.Select();
            
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (ListViewItem item in listView.Items )
            {
                if (item.Text  == oOrder.ScanItems[txtProductID.Text].ProductID)
                {
                    //Grid.ActiveRow = aUGRow;
                    item.SubItems[4].Text = oOrder.ScanItems[txtProductID.Text].Scanned.ToString();
                    
                    if (DeleteIt)
                    {
                        //Grid.ActiveRow.Delete();
                        item.BackColor = System.Drawing.Color.Gray;
                        
                        
                        //listView.DataBind();

                    }
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")
                    if (!DeleteIt)
                    {
                      //  item.BackColor = System.Drawing.Color.WhiteSmoke;
                        
                    }
                    item.Focused = true;
                    item.Selected = true;
                    break;
                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
            txtProductID.Focus();
        }
        private void ActiveLeft()
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (Convert.ToInt32(item.SubItems[3].Text) > Convert.ToInt32(item.SubItems[4].Text))
                {
                        item.BackColor = System.Drawing.Color.Red;

                }
            }
            
            /*
            //UltraGridRow aUGRow =  Grid.GetRow(ChildRow.First);
            foreach (UltraGridRow aUGRow in Grid.Rows)
            {
                if ((int)aUGRow.Cells["Quantity"].Value > (int)aUGRow.Cells["Scanned"].Value)
                {
                    Grid.ActiveRow = aUGRow;
                    Grid.ActiveRow.Appearance.BackColor = System.Drawing.Color.Red;
                    //UltraGrid1.ActiveCell = aUGRow.Cells("DateValue1")

                }
                // aUGRow = aUGRow.GetSibling(SiblingRow.Next);
            }
            */
        }
        public void Clear()
        {
            txtName.Text="";
            txtOrderID.Clear();
            txtTeacher.Clear();
            txtStudent.Clear();
            oOrder.ScanItems.Clear();
            txtProductID.Clear();
            txtBoxes.Clear();
            
            txtEntryDate.Text = DateTime.Now.Date.ToString();
           oOrder.ScanItems.Clear();
           listView.DataBind();

        }
        public bool ShowOrder(Int32 OrderID)
        {
            this.ShowHeader();
            if (!oOrder.Packed)
                this.ShowDetail();
            return true;
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
            
            listView.DataSource = oOrder.ScanItems;
            listView.DataBind();
            
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
            oOrder.CompanyID = CompanyID;
            oOrder.CustomerID = txtOrderID.Text;
            oOrder.Teacher = txtTeacher.Text;
            oOrder.Student = txtStudent.Text;

            oOrder.Save(OrderType.Regular);
            Clear();
            txtStudent.Clear();
        }
    }
}