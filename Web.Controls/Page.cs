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
    [ToolboxData("<{0}:Page runat=server></{0}:Page>")]
    public class Page : Panel
	{
        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; }
        }
        private TopMenu.MenuType _menu = TopMenu.MenuType.MainMenu;
        public TopMenu.MenuType MenuType
        {
            get { return _menu; }
            set { _menu = value; }
        }


        protected TextBox searchBox;
 
		protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            this.PageTitle = "Signature Fundrasing, Inc.";
            BuildPage(this);
			
		}

        protected virtual void BuildHeader(Panel _form)
        {
            PlaceHolder form = new PlaceHolder();
            
                form.Controls.Add(new LiteralControl(@"
				<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>
				<html>
					<head >"));
    
                form.Controls.Add(new Head());
                form.Controls.Add(new LiteralControl(@"    </head>
					<body>
						<table border='0' align='center'  bgcolor = 'white' width='780px'>
						<tr>
                            <td colspan=3>
                                 <table width='100%' height='100px' border='0'  align='center' cellpadding='0' cellspacing='0'>
 	                                <tr>	
		                                <td> "));

                form.Controls.Add(new Banner());
                form.Controls.Add(new LiteralControl(@"
		                                </td>
	                                </tr>
                                </table>
                            </td>
						</tr>
                        "));

                 BuilMenu(form);

                 _form.Controls.AddAt(0, form);
        }

        protected virtual void BuildFooter(Panel form)
        {

            form.Controls.Add(new Footer());
        }

        protected virtual void BuilMenu(PlaceHolder form)
        {
            form.Controls.Add(new LiteralControl(@"
                <tr> 
						<td  height='15px' width='100%' colspan= '3'> 
                                    "));
         //  form.Controls.Add((TopMenuControl)LoadControl("~/TopMenuControl.ascx"));

            form.Controls.Add(new TopMenu(this.MenuType));
 
           form.Controls.Add(new LiteralControl(@"
                        </td> 		
			    </tr> "));
            
        }

        protected virtual WebControl BuildPage(Panel form)
		{	
            BuildHeader(form);
          //  AddControlsFromDerivedPage(form);
           // AddSearch(form);
            BuildFooter(form);
            return form;
		}

	}
}
