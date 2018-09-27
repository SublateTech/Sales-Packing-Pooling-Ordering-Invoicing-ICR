using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing.Design;

//syntax: [assembly: WebResource("{namespace}.{filename}", "{content-type}")]

[assembly: WebResource("Signature.Web.Controls.css.signature.css", "text/css" )]
[assembly: WebResource("Signature.Web.Controls.css.tn-sub.css", "text/css")]

namespace Signature.Web.Controls
{
    [DefaultProperty("AutoCompleteEnabled")]
    [ToolboxData("<{0}:Head runat=server></{0}:Head>")]
    [Description("HTML Select list derived from the DropDownList control which enables auto-complete selection of items in the DropDownList as the user types in the control")]
    public class Head : WebControl
    {
        
        #region Overridden Events
        protected override void  OnInit(EventArgs e)
        {
            base.OnInit(e);

                // create the style sheet control and put it in the document header
                string csslink = "<link rel='stylesheet' type='text/css' href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Signature.Web.Controls.css.signature.css") + "' />";
                LiteralControl include = new LiteralControl(csslink);
                csslink = "<link rel='stylesheet' type='text/css' href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Signature.Web.Controls.css.tn-sub.css") + "' />";
                LiteralControl include1 = new LiteralControl(csslink);
            

                // add to header if possible; current control if not 
                // note: control includes must be prior to any html element that references them or client script error will result
                if (Page.Header != null)
                {
                    Page.Header.Controls.Add(include);
                    Page.Header.Controls.Add(include1);
                }
                else
                {
                    if (Controls != null)
                    {
                        Controls.Add(include);
                        Controls.Add(include1);
                    }
                }


        }

        #endregion

    }
}
