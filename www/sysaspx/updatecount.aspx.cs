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

public partial class sysaspx_updatecount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = string.Empty;
        string TableName = IRequest.GetQueryString("t").ToLower();
        int Id = 0;
        switch (TableName)
        {
            case "news":
                Id = IRequest.GetQueryInt("newsid", 0);
                sql = "update [Dcms_News] set [News_Count]=[News_Count]+1 where [News_Id]=" + Id;
                break;
            case "products":
                Id = IRequest.GetQueryInt("productsid", 0);
                sql = "update [Dcms_Products] set [Products_Count]=[Products_Count]+1 where [Products_ID]=" + Id;
                break;
            case "position":
                Id = IRequest.GetQueryInt("positionId", 0);
                sql = "update [Dcms_Position] set [Position_Count]=[Position_Count]+1 where [Position_Id]=" + Id;
                break;
        }
        if ((sql.Length > 10) && (Id > 0))
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                session.simple(sql);
            }
        }
        Response.Clear();
        Response.Write("//更新成功");
    }
}
