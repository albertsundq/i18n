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

public partial class sysaspx_chkLogin : Dcms.BasePage.FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string successMessage = IRequest.GetFormString("successMessage");
        string successUrl = IRequest.GetFormString("successUrl");
        string errorMessage = IRequest.GetFormString("errorMessage");
        string errorCodeMessage = IRequest.GetFormString("errorCodeMessage");
        bool hasValidCode = false;
        string ValidCode = string.Empty;
        for (int i = 0; i < Request.Form.Keys.Count; i++)
        {
            if (Request.Form.Keys[i].ToLower() == "validcode")
            {
                hasValidCode = true;
                ValidCode = IRequest.GetFormString("ValidCode");
                break;
            }
        }

        if ((hasValidCode) && (ValidCode != Convert.ToString(SessionHelper.Get("ValidCode"))))
        {
            Jscript.AlertAndBack("验证码出错");
            Response.End();
        }
        try
         {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                    UpdateModelByForm(user, Request.Form);
                    if (string.IsNullOrEmpty(user.User_Name) || string.IsNullOrEmpty(user.User_PassWord))
                    {
                        Jscript.AlertAndBack("用户名或密码不能为空.");
                        return;
                    }
                    else
                    {
                        IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_NAME_.EqulesExp().AND(SqlDb.Dcms_User._USER_PASSWORD_.EqulesExp()));
                        List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>();
                        if (userList.Count == 1)
                        {
                           // string str=(userList[0].User_InVisible==0)?"fd":"f";
                            if (userList[0].User_InVisible.Equals("0"))
                            {
                                Jscript.AlertAndBack("你还没有审核通过.");
                                return;
                            }
                            else
                            {
                                SessionHelper.Add("UserLevelKey", userList[0].User_LevelKey);
                                SessionHelper.Add("UserName", userList[0].User_Name);
                                SessionHelper.Add("UserId", userList[0].User_Id.ToString());
                                Utils.WriteCookie("UserId", userList[0].User_Id.ToString());
                                string urlRef = Utils.GetCookie("urlRef");
                                if ((urlRef.Length > 0))
                                {
                                    Response.Redirect(urlRef);
                                }
                                else
                                {
                                    Jscript.AlertAndRedirect(successMessage, successUrl);
                                }
                                return;
                            }
                        }
                        else
                        {
                            Jscript.AlertAndBack("用户名或密码错误.");
                            return;
                        }
                    }
                }
         }
        catch(Exception ex)
        {
            Jscript.AlertAndBack(ex.Message);
        }
    }
}
