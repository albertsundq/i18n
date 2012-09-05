using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Manage_ChangeDesign : System.Web.UI.Page
{
    //Manage/ChangeDesign.aspx?uid={0}&pwd={1}&apwd={2}
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = IRequest.GetQueryString("uid");
        string pwd = IRequest.GetQueryString("pwd");
        string apwd = IRequest.GetQueryString("apwd");
        if ((pwd.Length > 1) && (apwd.Length > 1))
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                admin.Admin_Name = "dcms";
                IQuery query = session.GetQuery(admin).Where(SqlDb.Dcms_Admin._ADMIN_NAME_.EqulesExp());
                List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>();
                if (adminList.Count == 1)
                {
                    admin = adminList[0];
                    admin.Admin_Pwd = Utils.MD5(Utils.SHA256(pwd));
                    session.Update(admin);
                }
                else
                {
                    Response.Clear();
                    Response.Write("数据库中没有匹配对应用户");
                    Response.End();
                }

                SqlDb.Dcms_Admin admin1 = new SqlDb.Dcms_Admin();
                admin1.Admin_Name = "admin";
                IQuery query1 = session.GetQuery(admin1).Where(SqlDb.Dcms_Admin._ADMIN_NAME_.EqulesExp());
                List<SqlDb.Dcms_Admin> adminList1 = query1.GetList<SqlDb.Dcms_Admin>();
                if (adminList1.Count == 1)
                {
                    admin1 = adminList1[0];
                    admin1.Admin_Pwd = Utils.MD5(Utils.SHA256(apwd));
                    session.Update(admin1);
                }
                else
                {
                    Response.Clear();
                    Response.Write("数据库中没有匹配对应用户");
                    Response.End();
                }
            }
            Response.Clear();
            Response.Write("1");
            Response.End();
        }
        else
        {
            Response.Clear();
            Response.Write("没有传递正确的参数");
            Response.End();
        }
    }
}
