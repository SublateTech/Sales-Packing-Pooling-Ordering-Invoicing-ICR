using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;
using System.Net;


namespace Signature.Forms
{
    public partial class frmPackOrder: Form
    {
        
        public frmPackOrder()
        {
            InitializeComponent();
            
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        
        private void bLogin_Click_1(object sender, EventArgs e)
        {
            //Global.SetParameter("CurrentLine", Convert.ToInt32(txtLine.Number).ToString());
            /*
            if (this.oOrder.Lines.Count > 0)
                txtPackedDays.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Order.PackByOrder oPO in oOrder.Lines)
                txtPackedDays.Items.Add(oPO.PackedDate);
            */
            Close();
           
        }

        private void bCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void frmLine_Load(object sender, EventArgs e)
        {
            txtLine.Text = Global.CurrrentLine;
        }
    }
}