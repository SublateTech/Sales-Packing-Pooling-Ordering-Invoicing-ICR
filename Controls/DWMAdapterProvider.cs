using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Drawing;

namespace Signature.Windows.Forms 
{
    [ProvideProperty("DWMRender", typeof(Control))]
    [ProvideProperty("BlurColor", typeof(System.Windows.Forms.Label))]
    [ProvideProperty("BlurSize", typeof(System.Windows.Forms.Label))]
    [TypeConverter(typeof(DWMAdapterProviderConverter))]
    public partial class DWMAdapterProvider : Component, IExtenderProvider, ISupportInitialize
    {
        private Dictionary<Control, DWMAdapterNativeWindow> attachedControls;
        private ContainerControl parentControl;

        public ContainerControl ParentControl {
            get { return this.parentControl; }
            set { 
                this.parentControl = value;
                if (value != null && this.parentControl.Controls.Count > 0) {
                    AddControls(this.parentControl.Controls);
                }
            }
        }

        public DWMAdapterProvider()
        {
          // InitializeComponent();
            InitializeMembers();
        }

        public DWMAdapterProvider(IContainer container)
        {
            container.Add(this);
           // InitializeComponent();
            InitializeMembers();
        }

        public DWMAdapterProvider(ContainerControl parentControl) : this() {
            this.parentControl = parentControl;
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            attachedControls = new Dictionary<Control, DWMAdapterNativeWindow>();
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        #endregion

        #region Label Properties
        public Color GetBlurColor(Control c) {
            if (c is System.Windows.Forms.Label && attachedControls.ContainsKey(c) && attachedControls[c].Properties.ContainsKey("BlurColor")) {
                return (Color)attachedControls[c].Properties["BlurColor"];
            }
            return Color.Empty;
        }

        public void SetBlurColor(Control c, Color color) {
            if (c != null && c is System.Windows.Forms.Label)
            {

                if (!attachedControls.ContainsKey(c))
                {
                    this.SetDWMRender(c, true);
                }

                if (!attachedControls[c].Properties.ContainsKey("BlurColor"))
                {
                    attachedControls[c].Properties.Add("BlurColor", Color.Empty);
                }
                attachedControls[c].Properties["BlurColor"] = color;

            }
        }

        public Size GetBlurSize(Control c) {
            if (c is System.Windows.Forms.Label && attachedControls.ContainsKey(c) && attachedControls[c].Properties.ContainsKey("BlurSize"))
            {
                return (Size)attachedControls[c].Properties["BlurSize"];
            }
            return Size.Empty;
        }

        public void SetBlurSize(Control c, Size size) {
            if (c != null && c is System.Windows.Forms.Label)
            {
                if (!attachedControls.ContainsKey(c))
                {
                    this.SetDWMRender(c, true);
                }

                if (!attachedControls[c].Properties.ContainsKey("BlurSize"))
                {
                    attachedControls[c].Properties.Add("BlurSize", Size.Empty);
                }
                attachedControls[c].Properties["BlurSize"] = size;

            }
        }
        #endregion

        public void SetDWMRender(Control c, bool enabled) {
            if (enabled)
            {
                if (!attachedControls.ContainsKey(c))
                {
                    DWMAdapterNativeWindow dnw = new DWMAdapterNativeWindow(c);
                    attachedControls.Add(c, dnw);
                }
            }
            else {
                if (attachedControls.ContainsKey(c)) {
                    attachedControls.Remove(c);
                }
            }
        }

        public bool GetDWMRender(Control c)
        {
            return attachedControls.ContainsKey(c);
        }

        #region ISupportInitialize Members

        public void BeginInit()
        {
            //throw new Exception("The method or operation is not implemented.");
            Console.WriteLine("Start initialisation...");

        }

        public void EndInit()
        {
            //throw new Exception("The method or operation is not implemented.");
            if (this.parentControl == null && this.DesignMode) {
                this.parentControl = GetContainerControl();
            }

            if (this.parentControl != null) {
                this.AddControls(this.parentControl.Controls); 
            }
            Console.WriteLine("Initialisation done");
        }

        #endregion

        private ContainerControl GetContainerControl() {
            ContainerControl cc = null;
            IDesignerHost host = this.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (host != null) {
                IComponent c = host.RootComponent;
                cc = c as ContainerControl;
            }

            return cc;
        }

        private void AddControls(Control.ControlCollection cc) {
            if (!this.DesignMode) {
                return;
            }
            if (cc.Count > 0) {
                for (int i = 0; i < cc.Count; i++) {
                    this.SetDWMRender(cc[i], true);
                    AddControls(cc[i].Controls);
                }
            }
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
                if (value != null) {
                    this.parentControl = GetContainerControl();
                }

                //if (this.parentControl != null)
                //{
                //    MessageBox.Show(this.parentControl.GetType().ToString());
                //}
            }
        }

        #region Form Adapter
        private BlurMode blurMode;

        public BlurMode BlurMode
        {
            get { return blurMode; }
            set { blurMode = value; }
        }

        #endregion
    }

}
