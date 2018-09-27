using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class frmPresentation : Form
    {
        public frmPresentation()
        {
            InitializeComponent();
        }

        private void frmPresentation_Load(object sender, EventArgs e)
        {
            Picture.Update();
        }
    }
}