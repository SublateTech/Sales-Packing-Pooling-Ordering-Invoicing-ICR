using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maf.Windows.Forms.DWM
{
    public partial class TransparentForm : Form
    {
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x80000;
        //        return base.CreateParams;
        //    }
        //}

        public TransparentForm()
        {
            InitializeComponent();

            if (Environment.OSVersion.Version.Major >= 6 && !this.DesignMode)
            {
                this.isBlurEnabled = DWMNativeMethods.IsCompositionEnable();

            }
        }

        private BlurMode blurMode = BlurMode.ExtendFrameIntoClientArea;

        [DefaultValue(BlurMode.ExtendFrameIntoClientArea)]
        [Category("Layout")]
        public BlurMode Blur
        {
            get { return blurMode; }
            set { blurMode = value; }
        }
	

        private Maf.Windows.Forms.DWM.Margin margin = Maf.Windows.Forms.DWM.Margin.None;
        [DefaultValue("-1;-1;-1;-1")]
        [Category("Layout")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Margin BlurMargin
        {
            get { return margin; }
            set { 
                margin = value;
                RecreateHandle();
            }
        }

        private bool isBlurEnabled;
        public bool IsBlurEnabled
        {
            get { return isBlurEnabled; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (isBlurEnabled)
            {
                this.BackColor = Color.Black;
                //this.TransparencyKey = Color.FromArgb(200, 201, 202);
                //this.BackColor = Color.FromArgb(200, 201, 202);
                switch (this.blurMode)
                {
                    default:
                    case BlurMode.ExtendFrameIntoClientArea:
                        DWMNativeMethods.ExtendFrameIntoClientArea(this, ref this.margin);
                        break;
                    case BlurMode.BlurBehindWindow:
                        DWMNativeMethods.EnableBlurBehindWindow(this);
                        break;
                }
            }
        }
    }
}