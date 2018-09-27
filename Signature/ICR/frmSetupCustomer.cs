using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;

namespace Signature.TwainGui
{
    public partial class frmSetupCustomer : Form
    {

        
        Company oCompany = new Company();
        Customer oCustomer;
        Batch oBatch = new Batch();
        Teacher oTeacher;

        

        public frmSetupCustomer()
        {
            InitializeComponent();
            oCustomer = new Customer(oCompany.ID);
            oTeacher = new Teacher(oCompany.ID);

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
                   /* if (oTeacher.View(txtCompanyID.Text, txtCustomerID.Text))
                    {
                        txtTeacher.Text = oTeacher.Name;
                        
                        //return;
                    }*/
                    if (oBatch.View(this.txtCompanyID.Text, this.txtCustomerID.Text))
                    {
                        txtTeacher.Text = oBatch.Teacher;
                        txtBatchID.Text = oBatch._ID.ToString();
                        
                        return;
                    }


                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oBatch.Find(txtCompanyID.Text,txtCustomerID.Text,txtTeacher.Text))
                    {
                        this.txtTeacher.Focus();
                        return;
                    }
                    else
                    {
                        txtTeacher.Text = oBatch.Teacher;
                        txtBatchID.Text = oBatch._ID.ToString();
                        
                        
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
                    if (oBatch.View(this.txtCompanyID.Text, this.txtCustomerID.Text))
                    {
                        txtBatchID.Text = oBatch._ID.ToString();
                        return;
                    }

                }
                if (e.KeyCode.ToString() == "Return" || e.KeyCode.ToString() == "Tab")
                {
                    if (!oBatch.Find(txtBatchID.Text))
                    {
                        this.txtBatchID.Focus();
                        return;
                    }
                    else
                    {
                        txtBatchID.Text = oBatch._ID.ToString();

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
                Batch oBatch = new Batch();
                if (oBatch.Find(txtCompanyID.Text, txtCustomerID.Text, txtTeacher.Text))
                {
                    txtTeacher.Text = oBatch.Teacher;
                    txtBatchID.Text = oBatch._ID.ToString();
                    this.SaveGlobalParameters();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please create o select a Teacher");
                    txtTeacher.Focus();
                }

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

        

        
    }
}