using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing.Design;


namespace Signature.Web.Controls
{
    [DefaultProperty("AutoCompleteEnabled")]
    [ToolboxData("<{0}:Footer runat=server></{0}:Footer>")]
    [Description("HTML Select list derived from the DropDownList control which enables auto-complete selection of items in the DropDownList as the user types in the control")]
    public class Footer : WebControl
    {
        
        #region Overridden Events
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);


            writer.Write(@"<tr>
							<td colspan=3>
                    
                            <table width='100%' border='0'  cellpadding='0' cellspacing='0' bordercolor='#FFFFFF' bgcolor='#FBFBFB'>
	                            <tr> 
                                 <td  style=' padding:0' width='100%' height='30' bordercolor='#FBFBFB'>
	                             <table width='100%' border='0' cellpadding='0' cellspacing='0' background='images/SigBottom.gif'>
                                    
		                            <tr> 
		  		                            <td width='5%' height='30' align='left'> </td>		
				                            <td width='70%' align='left'> 
			                                <a class='white' href='db_main.aspx'>  Main Page |</a>
				                            <a class='white' href='db_main_about_us.php'> About Us |</a>
				                            <a class='white' href='db_main_contact_us.php'>Contact Us |</a>
				                            <a class='white' href='db_cart_main.php'>Shop Online |</a>
				                            <a class='white' href='db_main_privacy.php'>Privacy Policy |</a>
				                            <a class='white' href='db_main_privacy.php?refund'>Return & Refund Policy</a></td>

				                            <td width='5%' align='left' height='30' align='left' color='3B405E' > 
						                            <IMG  SRC='images/Phone.gif'> 
				                            </td>
				                            <td width='15%' align='left' height='30' align='left' color='3B405E' > 
					                            <div  class='white'>1.800.645.3863</div>
				                            </td>		
                            				  
                                      </tr> 
  	                             </table>
	                            </td>
                              </tr>
                              <tr>
  	                             <td width='100%' height='30' align='center' valign='center' bgcolor = '#3B405E'>
	 		                            <div class='Copyright' > &nbsp;Copyright Signature Fundraising Inc. 2000-2009 www.sigfund.com. All Right Reserved &nbsp; </div>
	                             </td>
                              </tr>
                            </table>
                            </td>
						</tr>
						</table>	
					</body>
				</html>");

        }
        #endregion

    }
}
