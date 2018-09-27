using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;


namespace Signature.Forms
{
    public partial class frmShortage_: Form
    {
        public frmShortage_()
        {
            InitializeComponent();
        }

        public frmShortage_(Customer oCustomer)
        {
            InitializeComponent();
            frmShortage oShortage = new frmShortage();
            oShortage.txtName.Text = oCustomer.Name;
            oShortage.txtCustomerID.Text = oCustomer.ID;
            oShortage.txteMail.Text = oCustomer.eMail;
            oShortage.txtAddress.Text = oCustomer.Address;
            oShortage.txtCity.Text = oCustomer.City;
            oShortage.txtState.Text = oCustomer.State;
            oShortage.txtZipCode.Text = oCustomer.ZipCode;
            oShortage.txtChild.Text = oCustomer.Chairperson;
            oShortage.txtParent.Enabled = false;
            oShortage.txtTeacher.Enabled = false;
            oShortage.txtDayPhone.Value = oCustomer.HeadPhone;
            
            this.Height = oShortage.Height;
            
            pShortage.Controls.Add(oShortage.ultraGroupBox1);

            


        }
    }
}

