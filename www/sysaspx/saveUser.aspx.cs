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
using System.Text;
using Dcms.Orm;
using Dcms.Utility;

public partial class sysaspx_saveUser : Dcms.BasePage.FrontPage
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
            Jscript.AlertAndBack(errorCodeMessage);
            Response.End();
        }
        if ((IRequest.GetFormString("User_Name").Trim().Length <= 1) || (IRequest.GetFormString("Password1").Trim().Length <6) || (IRequest.GetFormString("Password1")!=IRequest.GetFormString("Password2")))
        {
            Jscript.AlertAndBack(errorMessage);
        }
        else
        {
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                    UpdateModelByForm(user, Request.Form);
                    user.User_RegTime = DateTime.Now;
                    user.User_InVisible = 1;
                    user.User_PassWord = IRequest.GetFormString("Password1").Trim();
                    user.User_Gender = IRequest.GetFormString("User_Gender").Trim();
                    user.User_RegIp = Utility.GetIPAddress();
                    user.User_LastIp = Utility.GetIPAddress();
                    user.User_LastTime = DateTime.Now;
                    user.User_BirthDay = DateTime.Now;
                    session.Create(user);
                    SessionHelper.Add("UserId",session.ExecuteScalar("select max(user_id) from dcms_user"));
                    Utils.WriteCookie("UserId", session.ExecuteScalar("select max(user_id) from dcms_user"));
                    SessionHelper.Add("UserName", IRequest.GetFormString("User_Name").Trim());
                    Utils.WriteCookie("UserNmae", IRequest.GetFormString("User_Name").Trim());
                }
                Jscript.AlertAndRedirect(successMessage, successUrl);
            }
            catch
            {
                Jscript.AlertAndBack(errorMessage);
            }
        }
    }
}
