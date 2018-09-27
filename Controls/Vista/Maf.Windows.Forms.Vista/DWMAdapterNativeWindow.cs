using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Maf.Windows.Forms.DWM.Providers;
using System.ComponentModel;

namespace Maf.Windows.Forms.DWM
{
    [ToolboxItem(false)]
    public class DWMAdapterNativeWindow : NativeWindow
    {
        private BaseRendererProvider rendererProvider;
        private Control attachedControl;

        public DWMAdapterNativeWindow(Control c) {
            this.properties = new Dictionary<string, object>();
            this.attachedControl = c;
            this.AssignHandle(c.Handle);

            rendererProvider = RendererProviderFactory.GetRendererProvider(c.GetType());
            if (rendererProvider != null)
            {
                rendererProvider.NativeWindow = this;
                rendererProvider.AttachedControl = c;
            }
        }

        ~DWMAdapterNativeWindow() {
            this.ReleaseHandle();
            if (this.rendererProvider != null)
            {
                this.rendererProvider.Dispose();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (this.rendererProvider != null)
            {
                this.rendererProvider.WndProc(ref m);
            }
        }

        private Dictionary<string, object> properties;
        public Dictionary<string, object> Properties
        {
            get { return properties; }
        }
	
    }
}
