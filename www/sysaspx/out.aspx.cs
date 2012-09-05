using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dcms.Orm;
using Dcms.Utility;

public partial class sysaspx_out : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionHelper.Clear();
        Jscript.JsRedirect("/login.aspx");
    }
}
