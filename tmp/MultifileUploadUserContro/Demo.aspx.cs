using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MultipleFileUpload1_Click(object sender, FileCollectionEventArgs e)
    {
        HttpFileCollection oHttpFileCollection = e.PostedFiles;
        HttpPostedFile oHttpPostedFile = null;
        if (e.HasFiles)
        {
            for (int n = 0; n < e.Count; n++)
            {
                oHttpPostedFile = oHttpFileCollection[n];
                if (oHttpPostedFile.ContentLength <= 0)
                    continue;
                else
                    oHttpPostedFile.SaveAs(Server.MapPath("Files") + "\\" + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
            }
        }
    }
}
