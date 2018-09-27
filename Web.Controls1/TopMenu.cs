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
[assembly: WebResource("Signature.Web.Controls.css.chrome.js", "text/javascript")]
[assembly: WebResource("Signature.Web.Controls.css.chromestyle.css", "text/css" )]

namespace Signature.Web.Controls
{
    [DefaultProperty("AutoCompleteEnabled")]
    [ToolboxData("<{0}:TopMenu runat=server></{0}:TopMenu>")]
    public class TopMenu : WebControl
    {
        Boolean isPopUp = false;

        private MenuType _Menu;
        [DefaultValue(MenuType.MainMenu)]
        public MenuType Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }

        public TopMenu(MenuType menu)
        {
            this.Menu = menu;
        }


        #region Overridden Events
        protected override void  OnInit(EventArgs e)
        {
            base.OnInit(e);

                this.Page.ClientScript.RegisterClientScriptInclude("chrome", this.Page.ClientScript.GetWebResourceUrl(typeof(TopMenu),
               "Signature.Web.Controls.css.chrome.js"));
            
                
            
                // create the style sheet control and put it in the document header
                string csslink = "<link rel='stylesheet' type='text/css' href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Signature.Web.Controls.css.chromestyle.css") + "' />";
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

        protected void Open(HtmlTextWriter writer)
        {
            writer.Write("<table height='20px' width='100%'><tr><td><div id='chromemenu'><ul>");
        }

        protected void OpenMenu(HtmlTextWriter writer, String name, String m_submenu, String href, Int32 width, String target)
        {

            target = (target == "" ? "" : " target='" + target + "'");

            isPopUp = false;
            if (href == "")
                href = "#";

            if (m_submenu != "")
            {
                writer.Write("<li><a href = '" + href + "'  onmouseover = \"cssdropdown.dropit(this,event,'" + m_submenu + "')\"" + target + " >" + name + "</a></li>");
                writer.Write("<div id='" + m_submenu + "' class='dropmenudiv' style='width:" + width.ToString() + "px; '>");
                isPopUp = true;
            }
            else
            {
                writer.Write("<li><a href='" + href + "'" + target + " >" + name + "</a></li>");
            }
        }

        protected void OpenMenu(HtmlTextWriter writer, String name, String m_submenu, String href, Int32 width)
        {
            OpenMenu(writer, name, m_submenu, href, width, "");
        }

        protected void Close(HtmlTextWriter writer)
        {
            writer.Write("</ul></div></td></tr></table>");
        }

        protected void CloseMenu(HtmlTextWriter writer)
        {
            if (isPopUp)
            {
                writer.Write("</div>");
                isPopUp = true;
            }
        }

        protected void AddItem(HtmlTextWriter writer, String name, String href, String target)
        {
            target = target == "" ? "" : " target='" + target + "'";
            writer.Write("<a href='" + href + "'" + target + " >" + name + "</a>");
        }

        protected void AddItem(HtmlTextWriter writer, String name, String href)
        {
            AddItem(writer, name, href, "");
        }

        protected void MainMenu(HtmlTextWriter writer)
        {
            Open(writer);

            //OpenMenu(writer,strtoupper('HOME'),'','db_main.php');
            OpenMenu(writer, "Fundraising Solutions".ToUpper(), "t_menu1", "", 200);
            AddItem(writer, "Available Programs", "db_main_programs.aspx");
            AddItem(writer, "Catalog/Brochure Sale", "db_main_fall_catalog.aspx");
            AddItem(writer, "Cookie Dough Sale", "db_main_cookie.aspx");
            AddItem(writer, "Holiday Shop", "db_main_holiday.aspx");
            AddItem(writer, "Magazine Sale", "db_main_magazine.aspx");
            AddItem(writer, "Dollar Bar Sale", "db_main_dollar.aspx");
            CloseMenu(writer);

            OpenMenu(writer, "Information".ToUpper(), "t_menu2", "", 200);
            AddItem(writer, "Total Service Program", "db_main_service.aspx");
            AddItem(writer, "Educational Assemblies", "db_main_assemblies.aspx");
            AddItem(writer, "Promotional Media", "db_main_videos.aspx");
            AddItem(writer, "Privacy Policy", "db_main_privacy.aspx");
            AddItem(writer, "Return & Refund Policy", "db_main_privacy.aspx?refund=1");
            AddItem(writer, "About Us", "db_main_about_us.aspx");
            //AddItem(writer,"Site Map", "db_cart_main.php?category=6");
            CloseMenu(writer);

            OpenMenu(writer, "Customer Care".ToUpper(), "t_menu3", "", 200);
            AddItem(writer, "Frequently Asked Questions", "db_main_faq.aspx");
            //AddItem(writer,"Extra Order Forms","db_cart_main.php?range=15");
            AddItem(writer, "Contact Us", "db_main_contact_us.php");
            AddItem(writer, "Career Center", "SigFund/index_career.htm", "_new");
            AddItem(writer, "Chairperson Area", "db_chair_main.php");
            CloseMenu(writer);

            OpenMenu(writer, "Career Center".ToUpper(), "", "SigFund/index_career.htm", 0, "_new");

            OpenMenu(writer, "Fun Zone".ToUpper(), "t_menu4", "", 200);
            AddItem(writer, "Appreciation Gifts", "db_main_prizes.php");
            AddItem(writer, "Treasure Chest", "db_main_treasure.php");
            AddItem(writer, "Sig\"s Secret", "db_main_sig_secret.php");
            CloseMenu(writer);

            OpenMenu(writer, "Shop Online Now!".ToUpper(), "", "db_cart_main.php?Home", 200);

            OpenMenu(writer, "Rep's Area", "", "db_reps_main.php", 200);


            //OpenMenu(writer,strtoupper("Premium Chocolates"));

            Close(writer);
        }

        protected void CampaignMenu(HtmlTextWriter writer)
        {
            Open(writer);

            //OpenMenu(writer,strtoupper('HOME'),'','db_main.php');
            OpenMenu(writer, "Data Entry".ToUpper(), "t_menu1", "", 200);
            AddItem(writer, "Input Information", "main_info.aspx");
            AddItem(writer, "Enter Orders", "main_orders.aspx");
            
            CloseMenu(writer);

            OpenMenu(writer, "Reports".ToUpper(), "t_menu2", "", 200);
            AddItem(writer, "Goal Percentage", "db_main_service.aspx");
            AddItem(writer, "Teacher Student Goal", "db_main_assemblies.aspx");
            AddItem(writer, "Wacky Wearables Report", "db_main_videos.aspx");
            AddItem(writer, "Early Bird Report", "db_main_privacy.aspx");
            AddItem(writer, "School And Class Totals Report", "db_main_privacy.aspx?refund=1");
            AddItem(writer, "Daily Student Entries Report", "db_main_about_us.aspx");
            AddItem(writer, "Students Entries Report", "db_main_about_us.aspx");
            AddItem(writer, "10 to win", "db_main_about_us.aspx");
            AddItem(writer, "Top Selllers", "db_main_about_us.aspx");
            AddItem(writer, "Teacher Bonus", "db_main_about_us.aspx");
            AddItem(writer, "Collection Report", "db_main_about_us.aspx");
            AddItem(writer, "Daily Deposits", "db_main_about_us.aspx");
            AddItem(writer, "Donation Totals", "db_main_about_us.aspx");
            CloseMenu(writer);

            OpenMenu(writer, "Letters".ToUpper(), "", "SigFund/index_career.htm", 0, "_new");

            OpenMenu(writer, "Rep's Area", "", "db_reps_main.php", 200);

            Close(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (this.Menu == MenuType.MainMenu)
                MainMenu(writer);
            else
                CampaignMenu(writer);
        }

        #endregion

        public enum MenuType
        {
            MainMenu = 0,
            CampaigneMenu = 1
        }
    }
}
