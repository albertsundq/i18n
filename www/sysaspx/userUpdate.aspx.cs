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

public partial class sysaspx_userUpdate : Dcms.BasePage.FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string successMessage = IRequest.GetFormString("successMessage");
        string successUrl = IRequest.GetFormString("successUrl");
        string errorMessage = IRequest.GetFormString("errorMessage");
        int UId = Utils.StrToInt(SessionHelper.Get("UserId"), 0);
        if (UId <= 0)
        {
            Jscript.AlertAndBack("登录超时");
            Response.End();
        }
        try
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                int UserId = Utils.StrToInt(SessionHelper.Get("UserId"), 0);
                user.User_Id = UserId;
                IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_ID_.EqulesExp());
                List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>();
                if (userList.Count == 1)
                {
                    user = userList[0];
                    UpdateModelByForm(user, Request.Form);
					user.User_PassWord=IRequest.GetFormString("Password2");
                    session.Update(user);
                    Jscript.AlertAndRedirect(successMessage, successUrl);
                }
              }
        }
            catch
            {
                Jscript.AlertAndBack(errorMessage);
            }
        }
    }

