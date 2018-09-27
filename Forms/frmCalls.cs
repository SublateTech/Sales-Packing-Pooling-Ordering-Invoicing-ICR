using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Forms;
using Signature.Windows.Forms;
using Signature.Classes;

namespace Signature.Forms
{
    public partial class frmCalls : frmBase
    {
        CustomerCall oCustomer;
        
        public frmCalls(String CustomerID)
        {
            InitializeComponent();
            oCustomer = new CustomerCall(base.CompanyID);

            oCustomer.Find(CustomerID);
            this.txtCustomerID.Text = oCustomer.ID;
            this.txtName.Text = oCustomer.Name;
            this.txtPickUpDate.Value = oCustomer.PickUpDate;
            this.txtEndDate.Value = oCustomer.EndDate;

            this.txtChairperson.Text = oCustomer.Chairperson;
            this.txtPhone_1.Text = oCustomer.PhoneNumber;
            this.txtPhone_2.Text = oCustomer.HeadPhone;

            this.txtCustomerID.Enabled = false;
            this.txtName.Enabled = false;
            this.txtPickUpDate.Enabled = false;
            this.txtEndDate.Enabled = false;

            oCustomer.FindCall(CustomerID);

            m_hb.Title = "Call Instruction";
            m_hb.TitleIcon = TooltipIcon.Info;
            //m_hb.SetToolTip(cbEnd1, "Write each student’s total money collected on the order form in the box marked “School Use Only” (see example #3 on pg. 7). You do not need to check the order; however we cannot verify the order for you if you do not enter an amount in this box.");
        }

        private void cbEnd3_MouseHover(object sender, EventArgs e)
        {
            String Text;

            if (cbEnd1 == sender)
                    Text = "Write each student’s total money collected on the order form in the box marked “School Use Only” (see example #3 on pg. 7). You do not need to check the order; however we cannot verify the order for you if you do not enter an amount in this box.";
                else if (cbEnd2 == sender)
                    Text = "Turn in the white copy only. Keep the yellow copy and student envelope for your records (see example #2 on pg. 6).";
                else if (cbEnd3 == sender)
                    Text = "Make sure the student, teacher & school name are written on the order form.";
                else if (cbEnd4 == sender)
                    Text = "If a student has more than one order form, staple them together & enter the total dollar amount for all pages on the last page.";
                else if (cbEnd5 == sender)
                    Text = "Place each student’s order form in one of the large, white envelopes assigned to his/her class. Please make sure that the order forms are placed unfolded inside the large envelope.";
                else if (cbEnd6 == sender)
                    Text = "You will find it very helpful to write the student’s and teacher’s names on each check so that you have a way to trace it if it bounces.";
                else if (cbEnd7 == sender)
                    Text = "In order for each student’s order to be separated by class, each teacher must be assigned one of these large, white envelopes with their classes’ order forms placed inside. We cannot separate the order forms for you.";
                else if (cbPU1 == sender)
                    Text = "Your representative has a limited time in which to collect the orders from each school, so it is important that you have them ready in the large, white envelopes in the school office by 8:00am on the scheduled day.";
                else if (cbPU2 == sender)
                    Text = "We will accept late orders.  We don’t guarantee a delivery date for late orders; however, we strive to process them as quickly as possible.";
                else if (cbPU3 == sender)
                    Text = "We cannot check these late orders for discrepancies, so you must make sure the order matches the dollar amount.  Remember to mail the original and keep the yellow copy; however if you have 10 pages or less, you are welcome to fax them. Our fax number is 1-800-898-7702.  Please include a cover sheet with the number of pages you are transmitting.   Always call us to verify that we have received your late orders, whether you mail or fax them.";
            else
                    Text = sender.ToString();
            
            
            
            m_hb.SetToolTip((System.Windows.Forms.CheckBox) sender, Text);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            oCustomer.Save();
            this.Close();
        }

        private void frmCalls_Load(object sender, EventArgs e)
        {
            cbEndCompleted.DataBindings.Add("Checked", oCustomer, "EndCompleted");
            cbPickUpCompleted.DataBindings.Add("Checked", oCustomer, "PickUpCompleted");
            txtEndCompletedDate.DataBindings.Add("Value", oCustomer, "EndDateCompleted");
            txtPUCompletedDate.DataBindings.Add("Value", oCustomer, "PickUpDateCompleted");

            
            cbEnd1.DataBindings.Add("Checked", oCustomer, "End1");
            cbEnd2.DataBindings.Add("Checked", oCustomer, "End2");
            cbEnd3.DataBindings.Add("Checked", oCustomer, "End3");
            cbEnd4.DataBindings.Add("Checked", oCustomer, "End4");
            cbEnd5.DataBindings.Add("Checked", oCustomer, "End5");
            cbEnd6.DataBindings.Add("Checked", oCustomer, "End6");
            cbEnd7.DataBindings.Add("Checked", oCustomer, "End7");

            cbPU1.DataBindings.Add("Checked", oCustomer, "PickUp1");
            cbPU2.DataBindings.Add("Checked", oCustomer, "PickUp2");
            cbPU3.DataBindings.Add("Checked", oCustomer, "PickUp3");

            txtNotes.DataBindings.Add("Text", oCustomer, "Notes");

            cbEndAttempt1.DataBindings.Add("SelectedIndex", oCustomer, "EndAttempt1");
            cbEndAttempt2.DataBindings.Add("SelectedIndex", oCustomer, "EndAttempt2");
            cbEndAttempt3.DataBindings.Add("SelectedIndex", oCustomer, "EndAttempt3");
            cbEndAttempt4.DataBindings.Add("SelectedIndex", oCustomer, "EndAttempt4");

            cbPUAttempt1.DataBindings.Add("SelectedIndex", oCustomer, "PUAttempt1");
            cbPUAttempt2.DataBindings.Add("SelectedIndex", oCustomer, "PUAttempt2");
            cbPUAttempt3.DataBindings.Add("SelectedIndex", oCustomer, "PUAttempt3");
            cbPUAttempt4.DataBindings.Add("SelectedIndex", oCustomer, "PUAttempt4");

            cbEmailRep.DataBindings.Add("Checked", oCustomer, "eMailRep");
        }

    }
}