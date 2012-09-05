using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dcms.Orm;
using Dcms.Utility;


/// <summary>
/// PageBase 的摘要说明
/// </summary>
public class UploadPageBase: System.Web.UI.Page
{
    public SqlDb.Dcms_Admin adminInfo = null;
    public string[] superUser = ConfigurationManager.AppSettings["superUser"].ToUpper().Split(new char[] { ',' });
    static string _mflangflag;
    public static string mflangflag
    {
        get { return _mflangflag; }
        set { _mflangflag = value; }
    }
    static int _mfroleid;
    public static int mfroleid
    {
        get { return _mfroleid; }
        set { _mfroleid = value; }
    }
    protected override void OnInit(EventArgs e)
    {
        //进行的操作select,getone,insert,update,delete
        string Action = IRequest.GetQueryString("action");
        //权限栏目Id
        int PermCateId = IRequest.GetQueryInt("PermCateId", 0);
        //权限栏目Id
        int SysPermCateId = IRequest.GetQueryInt("SysPermCateId", 0);
        //文件名
        string FileName = IRequest.GetPageName();


        if (SessionHelper.Exists("adminInfo"))
        {
            adminInfo = (SqlDb.Dcms_Admin)SessionHelper.Get("adminInfo");
            //如果是超级用户登录，把角色定义为0，拥有超级权限
            for (int i = 0; i < superUser.Length; i++)
            {
                if (superUser[i].Equals(adminInfo.Admin_Name.ToUpper()))
                {
                    adminInfo.Admin_RoleId = 0;
                    //Utils.WriteCookie("Admin_Id", adminInfo.Admin_Id.ToString(), 60);
                    break;
                }
            }
        }
        else
        {
            int Admin_Id = Utils.StrToInt(Utils.GetCookie("Admin_Id"), 0);
            if (Admin_Id == 0)
            {
                if (IRequest.GetQueryInt("Admin_Id", 0) > 0)
                {
                    Admin_Id = IRequest.GetQueryInt("Admin_Id", 0);
                }
            }
            if (Admin_Id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                    admin.Admin_Id = Admin_Id;
                    IQuery query = session.GetQuery(admin).Where(SqlDb.Dcms_Admin._ADMIN_ID_.EqulesExp());
                    List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>();
                    if (adminList.Count == 1)
                    {
                        string AuthId = Utils.GetCookie("AuthId");
                        if (AuthId == string.Empty)
                        {
                            AuthId = IRequest.GetQueryString("AuthId");
                        }
                        if (Utils.MD5(Utils.SHA256(adminList[0].Admin_Pwd + adminList[0].Admin_Name)).Equals(AuthId))
                        {
                            SessionHelper.Add("adminInfo", adminList[0]);
                            SessionHelper.Add("LangFlag", Utils.UrlDecode(Utils.GetCookie("LangFlag")));
                            SessionHelper.Add("LangName", Utils.UrlDecode(Utils.GetCookie("LangName")));
                           // Utils.WriteCookie("Admin_Id", adminList[0].Admin_Id.ToString(), 60);
                            adminInfo = (SqlDb.Dcms_Admin)SessionHelper.Get("adminInfo");
                            //如果是超级用户登录，把角色定义为0，拥有超级权限
                            for (int i = 0; i < superUser.Length; i++)
                            {
                                if (superUser[i].Equals(adminInfo.Admin_Name.ToUpper()))
                                {
                                    adminInfo.Admin_RoleId = 0;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Response.Write("##error##500##");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("##error##500##");
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Write("##error##500##");
                Response.End();
            }
        }
        //Response.Write(PermCateId.ToString());
        base.OnInit(e);
    }
}
