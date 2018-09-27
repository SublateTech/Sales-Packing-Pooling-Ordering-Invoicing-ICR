using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Signature.Forms
{
    public partial class frmCallsManager : Form
    {
        public frmCallsManager()
        {
            InitializeComponent();

        }

        private void frmCallsManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}