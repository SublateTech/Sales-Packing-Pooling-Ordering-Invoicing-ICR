using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Maf.Windows.Forms.DWM.Providers
{
    /// <summary>
    /// Define a common base class for all RendererProvider
    /// </summary>
    public abstract class BaseRendererProvider : IDisposable
    {
        /// <summary>
        /// Name of the RendererProvider
        /// </summary>
        public abstract string Name {get ;}

        /// <summary>
        /// Associate control type 
        /// </summary>
        public abstract Type Type {get ;}

        /// <summary>
        /// Attached control
        /// </summary>
        public abstract Control AttachedControl { get; set;}

        private DWMAdapterNativeWindow nativeWindow;
        public virtual DWMAdapterNativeWindow NativeWindow {
            get { return this.nativeWindow; }
            set { this.nativeWindow = value; }
        }

        public virtual void WndProc(ref Message m) { 
        
        }

        public abstract void Dispose();
    }
}
