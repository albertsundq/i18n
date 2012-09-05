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
using System.Net.Mail;
using Dcms.Orm;
using Dcms.Utility;

namespace Dcms.BasePage
{
    /// <summary>
    ///ManagePage 的摘要说明
    /// </summary>
    public class ManagePage : System.Web.UI.Page
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
                        break;
                    }
                }
            }
            else
            {
                int Admin_Id = Utils.StrToInt(Utils.GetCookie("Admin_Id"), 0);
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
                            if (Utils.MD5(Utils.SHA256(adminList[0].Admin_Pwd + adminList[0].Admin_Name)).Equals(AuthId))
                            {
                                SessionHelper.Add("adminInfo", adminList[0]);
                                SessionHelper.Add("LangFlag", Utils.UrlDecode(Utils.GetCookie("LangFlag")));
                                SessionHelper.Add("LangName", Utils.UrlDecode(Utils.GetCookie("LangName")));

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
                                Response.Redirect("../adminlogin.aspx?ErrorInfo=未登录或登录超时，请登录！");
                                return;
                            }
                        }
                        else
                        {
                            Response.Redirect("../adminlogin.aspx?ErrorInfo=你的操作已经记录在案，请放弃偿试！");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Redirect("../adminlogin.aspx?ErrorInfo=未登录或登录超时，请登录！");
                    return;
                }
            }
            if ((adminInfo.Admin_RoleId > 0) && (PermCateId>0))
            {
                int checkActionRight = 0;
                switch (Action.ToLower())
                {
                    case "select":
                        checkActionRight = chkRight(adminInfo.Admin_RoleId, PermCateId, "select");
                        break;
                    case "insert":
                        checkActionRight = chkRight(adminInfo.Admin_RoleId, PermCateId, "insert");
                        break;
                    case "update":
                        checkActionRight = chkRight(adminInfo.Admin_RoleId, PermCateId, "update");
                        break;
                    case "delete":
                        checkActionRight = chkRight(adminInfo.Admin_RoleId, PermCateId, "delete");
                        break;
                }
                if (checkActionRight <= 0)
                {
                    Response.Redirect("../Error.aspx?ErrorInfo=你没有进行此操作的权限，请联系管理员申请相关权限再进行操作！");
                    return;
                }
            }
            //Response.Write(PermCateId.ToString());
            base.OnInit(e);
        }

        /// <summary>
        /// 检测Action的权限 
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="cateid"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public int chkRight(int roleid, int cateid, string action)
        {
            int hasRight = 0;
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string sql = "select Permissions_" + action + " from Dcms_Permissions where Permissions_RoleId=" + roleid.ToString() + " and Permissions_CateId=" + cateid.ToString() + "";
                hasRight = Utils.StrToInt(session.ExecuteScalar(sql), 0);
            }
            return hasRight;
        }

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
        /// 通过反射给Model实体赋值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fm"></param>
        public void UpdateModelByForm(object model, NameValueCollection fm)
        {
            System.Reflection.PropertyInfo[] arrProperty = model.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in arrProperty)
            {
                string colName = property.Name;
                if ((colName.Length > 0))// && (!string.IsNullOrEmpty(fm[colName])))
                {
                    //数据转化
                    switch (property.PropertyType.ToString())
                    {
                        case "System.DateTime":
                            property.SetValue(model, Convert.ToDateTime(fm[colName]), null);
                            break;
                        case "System.Int32":
                            if(colName!="Cate_HasChild")
                            {
                                property.SetValue(model, Utils.StrToInt(fm[colName], 0), null);
                            }
                           
                            break;
                        default:
                            property.SetValue(model, fm[colName], null);
                            break;
                    }
                }
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