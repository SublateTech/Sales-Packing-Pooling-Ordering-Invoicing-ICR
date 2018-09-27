using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using Signature.Data;

namespace Signature
{
    public partial class frmOSASTransfer : Form
    {

        
        Company oCompany = new Company();
        Customer oCustomer;
        ScannedImages oBatches = new ScannedImages();
        Teacher oTeacher;
        Order oOrder;

        

        public frmOSASTransfer()
        {
            InitializeComponent();
            oCustomer = new Customer(oCompany.ID);
            oTeacher = new Teacher(oCompany.ID);
            oOrder = new Order(oCompany.ID);

        }

        private void KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {


            if (sender == txtCustomerID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCustomer.View(txtCompanyID.Text))
                    {
                        txtCustomerID.Text = oCustomer.ID;
                        txtSchoolName.Text = oCustomer.Name;
                        //return;
                    }


                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oCustomer.Find(txtCompanyID.Text))
                    {
                        this.txtCustomerID.Focus();
                        return;
                    }
                    else
                    {
                        txtCustomerID.Text = oCustomer.ID;
                        txtSchoolName.Text = oCustomer.Name;
                    }

                }

            }

            if (sender == txtTeacher)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oTeacher.View(txtCompanyID.Text, txtCustomerID.Text))
                    {
                        txtTeacher.Text = oTeacher.Name;
                        
                        //return;
                    }


                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oTeacher.Find(txtCustomerID.Text,txtTeacher.Text))
                    {
                        this.txtTeacher.Focus();
                        return;
                    }
                    else
                    {
                        txtTeacher.Text = oTeacher.Name;
                        
                    }

                }

            }

            if (sender == txtCompanyID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oCompany.View())
                    {
                        txtCompanyID.Text = oCompany.ID;
                        
                    }

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oCompany.Find(txtCompanyID.Text))
                    {
                        this.txtCompanyID.Focus();
                        return;
                    }
                    else
                    {
                        txtCompanyID.Text = oCompany.ID;
                        
                    }

                }

            }
            if (sender == txtBatchID)
            {
                if (e.KeyCode.ToString() == "F2")
                {
                    if (oBatches.View(this.txtCompanyID.Text, this.txtCustomerID.Text, this.txtTeacher.Text))
                    {
                        txtBatchID.Text = oBatches.ID;
                        return;
                    }

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oBatches.Find(txtBatchID.Text))
                    {
                        this.txtBatchID.Focus();
                        return;
                    }
                    else
                    {
                        txtBatchID.Text = oBatches.ID;

                    }

                }

            }


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
                case Keys.F7:
                    Close();
                    break;
                case Keys.F2:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    break;
                case Keys.PageDown:
                    
                    break;


                //case Keys.<some key>: 
                // ......; 
                // break; 
            }
        }
        
        private void GetGlobalParameters()
        {
            
            txtCompanyID.Text = Global.GetParameter("CurrentCompany");
            txtCustomerID.Text = Global.GetParameter("CurrentCustomer");
            txtBatchID.Text = Global.GetParameter("CurrentBatch");
            txtTeacher.Text = Global.GetParameter("CurrentTeacher");

        }
        private void SaveGlobalParameters()
        {
            
            Global.SetParameter("CurrentCompany", txtCompanyID.Text);
            Global.SetParameter("CurrentCustomer", txtCustomerID.Text);
            Global.SetParameter("CurrentBatch", txtBatchID.Text);
            Global.SetParameter("CurrentTeacher", txtTeacher.Text);
            

        }
        private void btApply_Click(object sender, EventArgs e)
        {
            if (!(txtCompanyID.Text == "" || txtCustomerID.Text == ""  || txtTeacher.Text == ""))
            {
                this.TransferIntoOSAS();
                this.Close();
            }
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSetupCustomer_Load(object sender, EventArgs e)
        {
            GetGlobalParameters();
            if (oCustomer.Find(txtCustomerID.Text))
                txtSchoolName.Text = oCustomer.Name;
        }

        private void TransferIntoOSAS()
        {
            DataView dvOrders = new DataView();

            dvOrders = oTeacher.Orders(txtCompanyID.Text, txtCustomerID.Text, txtTeacher.Text, OrderType.Scanned);
            oOrder.CustomerID = txtCustomerID.Text;
            

            //MessageBox.Show(oOrder.CompanyID + " - " + oOrder.CustomerID);
            Orders oOrders = new Orders(oOrder.CompanyID, oOrder.CustomerID);

            //MessageBox.Show(dvOrders.Count.ToString());
            oOrders.open_OSAS_orders();
            if (dvOrders.Count == 0)
                MessageBox.Show("No Orders to Process...");
            
            foreach (DataRowView _Order in dvOrders)
            {

                if (oOrder.Find(_Order["Teacher"].ToString(), _Order["Student"].ToString()))
                {
                    MessageBox.Show(_Order["Student"].ToString());
                    
                     // Writing Order Headers.
                     oOrders.Header.CompanyID = oOrder.CompanyID;
                     oOrders.Header.CustomerID = oOrder.CustomerID;
                     oOrders.Header.Teacher = oOrder.Teacher;
                     oOrders.Header.Student = oOrder.Student;
                     oOrders.Header.Type = "000";
                     oOrders.Header.Prize = "0123456789";
                     oOrders.Header.No_Items = oOrder.NoItems.ToString();
                     oOrders.Header.Retail = oOrder.Retail.ToString();
                     oOrders.Header.Collected = oOrder.Collected.ToString();
                     oOrders.Header.Tax = "0.00"; // oOrder.Tax.ToString(); ;
                     oOrders.Header.Printed = "0";
                     oOrders.Header.Disc_Printed = "0";
                     oOrders.Header.Box = "1";
                     oOrders.Header.Date = "2454291"; // oOrder.Date.ToString("MMddyy"); //
                     oOrders.Header.Phone = "6619461674";
                    
                     
                    //MessageBox.Show(oOrder.Date.ToString("MMddyyyy"));

                     

                     int Index = 0;
                    foreach (Order.Item Item in oOrder.Items)
                    {
                        Index++;
                        oOrders.Detail.CompanyID = oOrders.Header.CompanyID;
                        oOrders.Detail.CustomerID = oOrders.Header.CustomerID;
                        oOrders.Detail.Teacher = oOrders.Header.Teacher;
                        oOrders.Detail.Student = oOrders.Header.Student;

                        oOrders.Detail.Item = Item.ProductID;
                        oOrders.Detail.No_Items = Item.Quantity.ToString();
                        oOrders.Detail.Seq = Index.ToString().PadLeft(3, '0');
                        oOrders.Detail.No_Invoiced = "0";
                        oOrders.Detail.Tax = Item.Tax.ToString();

                        oOrders.write_detail_order();

                    }

                    oOrders.write_header_order();
                }
            }

        }

    }
}