using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Signature.Vista;

namespace Signature.Forms
{
    
    public partial class frmCallsAssignUser : TransparentForm
    {
        public String PressedButton="";
        public String UserSelected = "";

        public frmCallsAssignUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PressedButton = "Apply";
            UserSelected = cbUsers.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PressedButton = "Cancel";
            Close();
        }
    }
}