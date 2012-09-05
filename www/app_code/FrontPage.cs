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
using System.Net.Mail;
using System.Web.UI.WebControls.WebParts;
using Dcms.Orm;
using Dcms.Utility;

namespace Dcms.BasePage
{
    /// <summary>
    ///FrontPage 的摘要说明
    /// </summary>
    public class FrontPage : System.Web.UI.Page
    {
        #region 通过反射给Model实体赋值
        /// <summary>
        /// 通过反射给Model实体赋值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fm"></param>
        public void UpdateModelByForm(object model, NameValueCollection fm)
        {
            System.Reflection.PropertyInfo[] arrProperty = model.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in arrProperty)
            {
                for (int i = 0; i < fm.Count; i++)
                {
                    string colName = fm.GetKey(i);
                    if ((colName.Length > 0) && (fm.GetValues(i)[0].Length > 0))
                    {
                        if (string.Compare(colName, property.Name, true) == 0)
                        {
                            //数据转化
                            switch (property.PropertyType.ToString())
                            {
                                case "System.DateTime":
                                    property.SetValue(model, Convert.ToDateTime(fm.GetValues(i)[0]), null);
                                    break;
                                case "System.Int32":
                                    property.SetValue(model, Utils.StrToInt(fm.GetValues(i)[0], 0), null);
                                    break;
                                default:
                                    property.SetValue(model, Utils.RemoveHtml(fm.GetValues(i)[0]), null);
                                    break;
                            }
                        }
                    }
                }
            }
        }
        #endregion 通过反射给Model实体赋值
        /// <summary>
        /// 格式化Json数据
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public string FormatJsonData(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\b");
            sourceStr = sourceStr.Replace("\t", "\\t");
            sourceStr = sourceStr.Replace("\n", "\\n");
            sourceStr = sourceStr.Replace("\n", "\\n");
            sourceStr = sourceStr.Replace("\f", "\\f");
            sourceStr = sourceStr.Replace("\r", "\\r");
            return sourceStr.Replace("\"", "\\\"");
        }
        /// <summary>
        /// 初使化控件(为控件赋值)
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="Controls">控件集合</param>
        public void InitControl(object model, ControlCollection Controls)
        {
            //取得model的所有属性
            System.Reflection.PropertyInfo[] arrProperty = model.GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo property in arrProperty)
            {
                foreach (Control ctl in Controls)
                {
                    string strControlID = ctl.ID == null ? "" : ctl.ID;
                    //将控件的名称去除前三个字母(例如：txtPro_Name  --> Pro_Name这个将以数据库中的字段一致)
                    if (strControlID != "" && strControlID.ToLower().IndexOf("js_") >= 0)
                    {
                        string strFieldID = strControlID;
                        //是否有存在此属性(不区分大小写)
                        if (string.Compare(strFieldID, property.Name, true) == 0)
                        {
                            aInitSetValue(ctl, property.GetValue(model, null));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 为不同的控件赋值
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="oValue">值</param>
        public void aInitSetValue(Control ctl, object oValue)
        {
            string thisValue = string.Empty;
            if (oValue != null)
            {
                thisValue = oValue.ToString();
            }
            else
            {
                thisValue = "null";
            }
            switch (ctl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.Literal":
                    Literal lit = (Literal)ctl;
                    lit.Text = thisValue;
                    break;
                case "System.Web.UI.WebControls.TextBox":
                    TextBox txt = (TextBox)ctl;
                    txt.Text = thisValue;
                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    RadioButtonList rbl = (RadioButtonList)ctl;
                    rbl.SelectedValue = thisValue;
                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    break;
            }
        }
        /// <summary>
        /// 邮件发送程序
        /// </summary>
        /// <param name="to">接收者</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="strFrom">发送者</param>
        /// <param name="strAccount">帐号</param>
        /// <param name="strPwd">密码码</param>
        /// <param name="strHost">smtp服务器</param>
        /// <returns></returns>
        public bool sendMail(string to, string title, string content, string strFrom, string strAccount, string strPwd, string strHost)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = strHost; //指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(strAccount, strPwd);//用户名和密码

            MailMessage _mailMessage = new MailMessage(strFrom, to);
            _mailMessage.Subject = title;//主题
            _mailMessage.Body = content;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级

            try
            {
                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}