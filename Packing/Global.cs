using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;


namespace Signature
{
    class Global
    {
        private RegistryKey root;
        
        public Global()
        {

            root = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, "");
            //this.SetParameter(root,"CurrentCompany", "F07");
        }

        public void SetParameter(String sKey, String Value)
        {   
            RegistryKey SKey = root.CreateSubKey("Software\\Signature Fundraising\\SigData");
            SKey.SetValue(sKey, Value);
        }

        public String GetParameter(String sKey,String Default)
        {
            
            RegistryKey SKey = root.CreateSubKey("Software\\Signature Fundraising\\SigData");
            return SKey.GetValue(sKey,Default).ToString();
        }

        
    }
}

