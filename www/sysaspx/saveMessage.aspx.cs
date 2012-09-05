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

public partial class sysaspx_saveMessage : Dcms.BasePage.FrontPage
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

        if ((hasValidCode)&&(ValidCode != Convert.ToString(SessionHelper.Get("ValidCode"))))
        {
            Jscript.AlertAndBack(errorCodeMessage);
            Response.End();
        }
        if ((IRequest.GetFormString("GuestBook_UserName").Length <= 1) || (IRequest.GetFormString("GuestBook_Title").Length <= 1))
        {
            Jscript.AlertAndBack(errorMessage);
        }
        else
        {
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_GuestBook guestbook = new SqlDb.Dcms_GuestBook();
                    guestbook.GuestBook_AddTime = DateTime.Now;
                    guestbook.GuestBook_State = "0";
                    UpdateModelByForm(guestbook, Request.Form);
                    guestbook.GuestBook_UserIp = Utils.GetRealIP();
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append(string.Format("标题：{0}<br />", guestbook.GuestBook_Title));
                    //sb.Append(string.Format("用户名：{0}<br />", guestbook.GuestBook_UserName));
                    //sb.Append(string.Format("邮箱：{0}<br />", guestbook.GuestBook_UserEmail));
                    //sb.Append(string.Format("电话：{0}<br />", guestbook.GuestBook_UserTel));
                    //sb.Append(string.Format("QQ/MSN：{0}<br />", guestbook.GuestBook_UserIM));
                    //sb.Append(string.Format("内容：{0}<br />", guestbook.GuestBook_Content));
                    //sendMail("***@35.cn", title, sb.ToString(), "***@35.cn","***@35.cn","******","mail.35.cn");
                    session.Create(guestbook);
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
