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
using System.Text.RegularExpressions;
using Dcms.Orm;

public partial class System_CheckSN : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            labhost.Text = GetWebUrl();
            if (CheckWeb.Check())
            {
                Response.Redirect("http://"+HttpContext.Current.Request.Url.Host.ToString());
            }
        }
    }

    public static string GetWebUrl()
    {
        return HttpContext.Current.Request.Url.Host.ToUpper();
    }
}
