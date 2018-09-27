using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Signature.Web.Controls;


namespace Signature.Web
{
    public partial class PatternClass : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Ok";
            
        }
        protected override void OnInit(EventArgs e)
        {
            LiteralControl include = new LiteralControl("ssssssssssssssssssssss");
            this.Box2.Controls.Add(include);
            include = new LiteralControl("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            this.Box3.Controls.Add(include);
            base.OnInit(e);
        }
    }
}
