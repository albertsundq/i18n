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
using System.Text;
using System.Net.Mail;
using Dcms.Orm;
using Dcms.Utility;

public partial class sysaspx_getpwdcs : Dcms.BasePage.FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
        {
            SqlDb.Dcms_User user = new SqlDb.Dcms_User();
            UpdateModelByForm(user, Request.Form);
            IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_NAME_.EqulesExp(Request.Form["User_Name"]));
            List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>();
            if (userList.Count == 1)
            {
                //if (userList[0].User_Email != "")
//                {
//                    SendeMail(userList[0].User_PassWord);
//                    Jscript.AlertAndBack("邮件已发送，请及时查收.");
//                }
				if(userList[0].User_Name==user.User_Name&&userList[0].User_Email==user.User_Email)
				{
				 Jscript.AlertAndBack("您的密码是: "+userList[0].User_PassWord+" 请妥善保管!");
				}
				else
				{
				 Jscript.AlertAndBack("身份验证错误!");
				}
            }
            else
            {
                Jscript.AlertAndBack("用户名不存在.");
            }
        }
    }

    public void SendeMail(string newpwd)
    {

        StringBuilder content = new StringBuilder("<table cellpadding=\"0\" cellspacing=\"0\" width=\"600\">");
        content.AppendFormat("<tr><td width=\"192\">您的福建四海投资网的账号密码为：</td><td width=\"106\">{0}</td></tr>", newpwd);
        //   content.AppendFormat("<tr><td width=\"92\">{0}</td><td width=\"506\">{0}</td></tr>", newpwd);
        content.Append("</table>");


        string fromadd = System.Configuration.ConfigurationManager.AppSettings["sendmail"];
        string user = System.Configuration.ConfigurationManager.AppSettings["sendmail_user"]; ;
        string pwd = System.Configuration.ConfigurationManager.AppSettings["sendmail_pwd"];
        string tomail = System.Configuration.ConfigurationManager.AppSettings["receivemail"];
        string host = System.Configuration.ConfigurationManager.AppSettings["smtpserver"];

        string title = "福建四海投资网站密码取回";

        this.UtilSendmail(title, content.ToString(), user, pwd, fromadd, tomail, host);

    }

    /// <summary>
    ///发送邮件
    /// </summary>
    /// <param name="msgSubject">邮件标题</param>
    /// <param name="msgBody">邮件内容</param>
    /// <param name="senderUID">发送方账号(e.g:test@35.cn),注意用全称</param>
    /// <param name="senderPWD">发送账号的密码</param>
    /// <param name="fromAdd">与发送账号相同(e.g:test@35.cn),注意用全称</param>
    /// <param name="toEmail">接收方邮箱地址</param>
    /// <param name="host">发送的pop服务器</param>
    public void UtilSendmail(string msgSubject, string msgBody, string senderUID, string senderPWD, string fromAdd, string toEmail, string host)
    {
        try
        {
            SmtpClient smtp;
            MailMessage mm = new MailMessage(fromAdd, toEmail);
            mm.Subject = msgSubject;
            mm.Body = msgBody;
            mm.Priority = MailPriority.High;
            mm.IsBodyHtml = true;
            smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = host;
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential(senderUID, senderPWD);
            smtp.Send(mm);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
