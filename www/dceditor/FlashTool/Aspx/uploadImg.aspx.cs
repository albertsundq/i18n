using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class FlashTool_Aspx_uploadImg : UploadPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            String fileName = Request.QueryString["fileName"].ToString();
            String Fload = @"../../.."+Request.QueryString["folad"].ToString();
            String FileType = Request.QueryString["fileType"].ToString();
            String ID = Request.QueryString["id"].ToString();
            ImageUploadUtil iuu = new ImageUploadUtil();
            String path = iuu.ImageUpload(Fload, "Filedata", 1);
            if (path == "##error##500##")
            {
                System.Web.HttpContext.Current.Response.Write("ERROR|" + ID);
            }
            else {
                System.Web.HttpContext.Current.Response.Write("SUCCESS|" + ID);
            }
        }
        catch (Exception ex)
        {
            String ID = Request.QueryString["id"].ToString();
            System.Web.HttpContext.Current.Response.Write("ERROR|" + ID);
        }
    }

}
