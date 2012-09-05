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
using Dcms.Utility;

public partial class Manage_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_ErrorInfo.Text = Utils.RemoveHtml(IRequest.GetQueryString("ErrorInfo"));
        lit_Time.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒");
        lit_Ip.Text = IRequest.GetIP();
    }
}
