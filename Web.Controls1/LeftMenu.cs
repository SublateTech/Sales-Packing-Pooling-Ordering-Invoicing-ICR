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
[assembly: WebResource("Signature.Web.Controls.css.leftmenu.js", "text/javascript")]
[assembly: WebResource("Signature.Web.Controls.css.leftmenu.css", "text/css" )]

namespace Signature.Web.Controls
{
    [DefaultProperty("AutoCompleteEnabled")]
    [ToolboxData("<{0}:LeftMenu runat=server></{0}:LeftMenu>")]
    [Description("HTML Select list derived from the DropDownList control which enables auto-complete selection of items in the DropDownList as the user types in the control")]
    public class LeftMenu : WebControl
    {
        

        #region Overridden Events
        protected override void  OnInit(EventArgs e)
        {
            base.OnInit(e);

                this.Page.ClientScript.RegisterClientScriptInclude("leftmenu", this.Page.ClientScript.GetWebResourceUrl(typeof(TopMenu),
               "Signature.Web.Controls.css.leftmenu.js"));
            
                
            
                // create the style sheet control and put it in the document header
                string csslink = "<link rel='stylesheet' type='text/css' href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Signature.Web.Controls.css.leftmenu.css") + "' />";
                LiteralControl include = new LiteralControl(csslink);
                //this.Page.Header.Controls.Add(include);
            

                // add to header if possible; current control if not 
                // note: control includes must be prior to any html element that references them or client script error will result
                if (Page.Header != null)
                {
                    Page.Header.Controls.Add(include);
                }
                else
                {
                    if (Controls != null)
                    {
                        Controls.Add(include);
                    }
                }


        }

        protected void Open(HtmlTextWriter writer, String Title)
        {
            writer.Write(@"<table width='120px' border='0'>");
            writer.Write(@"<tr><td ><div id='extra'> 
				<div  id='sb-module' class='box sb-module'>
					<h1><b>");
            writer.Write(Title);
            writer.Write(@"</b></h1>					
					<b class='cn tl'></b>
    				<b class='cn tr'></b>
				    </div>
		        </div>
                <div id='masterdiv'>");
        }

        protected void Title(HtmlTextWriter writer, String Title)
        {
            writer.Write("<div class='menu' style=\"text-align:left; background-color: '#EBECF0' \">"+Title+"</div>");
        }

        protected void OpenMenu(HtmlTextWriter writer,String name, String m_submenu, String href, Boolean open)
		{
			if (m_submenu!="" && m_submenu!="")
				{
				if (open) {
					writer.Write("<div class='menu'  onMouseOver=\"this.style.background='#EBECF0'\" onMouseOut=\"this.style.background='#ffffff'\" onClick=\"SwitchMenu('"+m_submenu+"')\">"+name);
                    writer.Write("</div>");
					writer.Write("<span  style=\"display:block\";  class='options'  id='"+m_submenu+"'>");
						}
				else {
					writer.Write("<div class='menu' onMouseOver=\"this.style.background='#EBECF0'\" onMouseOut=\"this.style.background='#ffffff'\" onClick=\"SwitchMenu('"+m_submenu+"')\">"+name+"</div>");	
					writer.Write("<span class='Options'  id='"+m_submenu+"'>");
					
					}
				}
			else if (href != "")
				{
				writer.Write("<div class='menu' onMouseOver=\"this.style.background='#EBECF0'\" onMouseOut=\"this.style.background='#ffffff'\" style='text-align:left; '>");
				writer.Write("<a href="+href+" >");
				writer.Write(name+"</a>"+"</div>");
				}
				
			else
				writer.Write("<div class='menu' onMouseOver=\"this.style.background='#EBECF0'\" onMouseOut=\"this.style.background='#ffffff'\" style='text-align:left; '>"+name+"</div>");	
		}

        
        protected void CloseMenu(HtmlTextWriter writer)
        {
            writer.Write("</span>");
            
        }

        protected void Close(HtmlTextWriter writer)
        {
            writer.Write("</div></td></tr></table>");

        }

        protected void AddItem(HtmlTextWriter writer, String name, String href)
        {
            
            writer.Write("<div class='Option' onMouseOver=\"this.style.background='#EBECF0'\" onMouseOut=\"this.style.background='#ffffff'\"><a href='"+href+"'>"+name+"</a></div>");
        }

        protected void MainMenu(HtmlTextWriter writer)
        {
            Open(writer, "PROGRAMS");

            OpenMenu(writer,"Catalog/Brochure", "menu2","",true);
			AddItem(writer,"Spring Brochure","db_main_spring_catalog.aspx");
			AddItem(writer,"Fall Brochure","db_main_fall_catalog.aspx");
			CloseMenu(writer);

            OpenMenu(writer, "Cookie Dough", "", "db_main_cookie.aspx",false);

            OpenMenu(writer, "Magazines", "", "db_main_magazine.aspx",false);

            OpenMenu(writer, "Holiday Shop", "", "db_main_holiday.aspx",false);
            OpenMenu(writer, "Dollar Bar", "", "db_main_dollar.aspx",false);

            
            Close(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            MainMenu(writer);
        }

        #endregion

    }
}
