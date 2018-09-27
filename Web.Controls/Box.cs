using System;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace Signature.Web.Controls
{
	/// <summary>
	/// Summary description for AdvancedPageInheritanceBase.
	/// </summary>
	public class Box : Panel
	{
        private string _Title= String.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
		protected override void OnInit(System.EventArgs e)
		{   
			base.OnInit(e);
		}

        protected override void OnLoad(EventArgs e)
        {  
            //this.Controls.Add(BuildPage(GenerateHtmlForm()));
            
            base.OnLoad(e);
            this.BuildPage(this);
        }

        protected virtual void BuildHeader(Panel form, String Title)
        {
                form.Controls.AddAt(0, new LiteralControl(@"<div id='extra'>
				<table  align='center' style='background-color:White'  cellpadding='0'  cellspacing='0' width='100%' border='0'> 
					<tr>
						<td>
					        <div id='sb-article' class='sb-article box ' >
					             <div id='s' style=' width:100%;'>
					                <table  align='center' border='0'  width='100%'  cellpadding='0' cellspacing='0'>
						                <tr>
						                    <td   align='left' width='100%'>
                					            <table  height='200px' valign='top'  border='0' width='100%' > " + (this.Title.Trim()==""?"": @"
							                            <tr>
					                                        <td height='60'  colspan='3'>
					                                        <div id='center_title'>
					                                        <font size='+1'>  "
                                                                +this.Title+ @"</font>
					                                        </div>
					                                        <a name='top'></a>
				  	                                        </td>
					                                    </tr>") + @"

							                            <tr>
                                                         <td> </td>
								                            <td align='Center'>
						   		                             
		"));
            
        }

        protected virtual void BuildFooter(Panel form)
        {
            form.Controls.Add(new LiteralControl(@"     </td>
						                               </tr>
                					            </table>
                					            
                					            
                					            
						                    </td>
				                        </tr>
					                </table>
					                
						        </div>
						        <b class='cn tl'></b>
	  					        <b class='cn tr'></b>
    					        <b class='cn bl'></b>
    					        <b class='cn br'></b>
				            </div>
						</td>
					</tr>	
				</table> 
		</div>
        "));
        }

        protected virtual Panel BuildPage(Panel form)
		{	
            BuildHeader(form, "");
            //AddControlsFromDerivedPage(form);
            BuildFooter(form);
            return form;
		}

		protected virtual Panel GenerateHtmlForm()
		{
			
            
            Panel form = new Panel();
            form.ID = "_frmBox";
            return form;
		}

		protected virtual void AddControlsFromDerivedPage(Panel form)
		{
			int count = this.Controls.Count;
			for( int i = 0; i<count; ++i )
			{
				System.Web.UI.Control ctrl  = this.Controls[0];
				form.Controls.Add( ctrl );
				this.Controls.Remove( ctrl );
			}
		}
	}
}
