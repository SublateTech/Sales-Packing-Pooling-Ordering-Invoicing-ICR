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
[assembly: WebResource("Signature.Web.Controls.css.ajaxticker.js", "text/javascript")]


namespace Signature.Web.Controls
{
    [DefaultProperty("AutoCompleteEnabled")]
    [ToolboxData("<{0}:Banner runat=server></{0}:Banner>")]
    [Description("Banner List")]
    public class Banner : WebControl
    {
        
        #region Overridden Events
        protected override void  OnInit(EventArgs e)
        {
            base.OnInit(e);

                this.Page.ClientScript.RegisterClientScriptInclude("ajaxticker", this.Page.ClientScript.GetWebResourceUrl(typeof(Banner), "Signature.Web.Controls.css.ajaxticker.js"));
                
         //       Build();
        }
        protected void Build()
        {
            this.Controls.Add(new LiteralControl(@"<table width='100%' height='100px' border='2'  align='center' cellpadding='0' cellspacing='0'>
 	<tr>	
		<td>"));
            /*
            this.Controls.Add(new LiteralControl(@"<div class='message'>
	                    <table>
		                    <tr>
			                    <td height='100px'>
				                    <a href='db_cart_main.php' target='_new'><img    src='images/Signature_1.jpg' border=0></a> 
			                    </td>
		                    </tr>
	                    </table>
                    </div>"));
            */

            this.Controls.Add(new LiteralControl(@"<script type='text/javascript'>"));
	 				/*
						var xmlfile='<?php echo $http ?>'+window.location.hostname+"/cbbanner.php"  //path to ticker txt file on your server.
						//ajax_ticker(xmlfile, divId, divClass, delay, optionalfadeornot)
						new ajax_ticker(xmlfile, "cbbanner1", "", 5000, "fade")
						*/
			this.Controls.Add(new LiteralControl(@"AddTicker('" + "cbbanner.aspx"+"');"));
			this.Controls.Add(new LiteralControl(@"</script>"));

            this.Controls.Add(new LiteralControl(@"</td>
	                                            </tr>
                                            </table>"));


        }

        protected  void Build(HtmlTextWriter writer)
        {
            writer.Write(@"<table width='100%' height='100px' border='0'  align='center' cellpadding='0' cellspacing='0'>	
                <tr>	
		        <td>");
            
            this.Controls.Add(new LiteralControl(@"<div class='message'>
	                    <table>
		                    <tr>
			                    <td height='100px'>
				                    <a href='db_cart_main.php' target='_new'><img    src='images/Signature_1.jpg' border=0></a> 
			                    </td>
		                    </tr>
	                    </table>
                    </div>"));
            

            writer.Write(@"<script type='text/javascript'>");
            /*
                var xmlfile='<?php echo $http ?>'+window.location.hostname+"/cbbanner.php"  //path to ticker txt file on your server.
                //ajax_ticker(xmlfile, divId, divClass, delay, optionalfadeornot)
                new ajax_ticker(xmlfile, "cbbanner1", "", 5000, "fade")
                */
           // writer.Write(@"AddTicker('" + "cbbanner.aspx" + "');");
            writer.Write(@"AddTicker('" + "cbbanner.aspx" + "');");
            writer.Write(@"</script>");
            
            writer.Write(@"</td>
	                                            </tr>
                                            </table>");

        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Build(writer);
            
        }
        #endregion

    }
}
