using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
//using System.Reflection;
//using System.Runtime.Remoting;

namespace Signature.Windows.Forms
{
    public class RendererProviderFactory
    {
        private static string configurationFilePath;
        /// <summary>
        /// Get RendererProvider for specified control type
        /// </summary>
        /// <param name="controlType">Control type</param>
        /// <returns>RendererProvider object</returns>
        public static BaseRendererProvider GetRendererProvider(Type controlType) {
            configurationFilePath = Path.Combine(Application.StartupPath, "DWMRendererProvider.config");
            // verify if configuration file exits
            if (!File.Exists(configurationFilePath)) {
                //throw new FileNotFoundException("Configuration File not found !", configurationFilePath);
                return null;
            }

            //System.Diagnostics.Debug.Assert(controlType == typeof(System.Windows.Forms.Label));

            BaseRendererProvider provider = null;
            RendererProviderConfig dataset = new RendererProviderConfig();

            dataset.ReadXml(configurationFilePath);
            RendererProviderConfig.ProvidersRow row = dataset.Providers.FindByAssociatedType(controlType.Name);

            if (row != null) {
                string assembly = row.Assembly;
                string type = row.Type;

                provider = GetRendererProvider( type, assembly);
            }
            return provider;
        }

        /// <summary>
        /// Get the typeName RendererProvider in specified assembly
        /// </summary>
        /// <param name="typeName"><seealso cref="Type"/> of the RendererProvider</see></param>
        /// <param name="assembly">Name of the assembly</param>
        /// <returns>RendererProvider</returns>
        public static BaseRendererProvider GetRendererProvider(string typeName, string assembly) {
            string tName = string.Concat(typeName, ",", assembly);
            Type t = Type.GetType(tName);
            if (t != null)
            {
                return Activator.CreateInstance(t) as BaseRendererProvider;
            }
            else {
                throw new Exception("Can't find provider of type '" + tName + "'");
            }
        }
    }
}
