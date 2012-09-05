using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using System.Collections.Generic;
using Dcms.Orm;
using Dcms.Utility;
using System.Xml;
using System.Text;

namespace Manage.BaseManage
{
    public partial class Manage_AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ErrorInfo = Utils.RemoveHtml(IRequest.GetQueryString("ErrorInfo"));
            if (ErrorInfo.Length > 0)
            {
                lit_ErrorInfo.Text = "<div class='errorinfo'>" + ErrorInfo + "</div>";
            }
            SessionHelper.Clear();
            Utils.WriteCookie("Admin_Id", "");
            Utils.WriteCookie("AuthId", "");
            Utils.WriteCookie("LangFlag", "");
            Utils.WriteCookie("LangName", "");
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string Admin_Name = this.txb_adminzh.Text.Trim();
            string Admin_Pwd = this.txb_adminmm.Text.Trim();

            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                admin.Admin_Name = Admin_Name;
                admin.Admin_Pwd = Utils.MD5(Utils.SHA256(Admin_Pwd));
                IQuery query = session.GetQuery(admin).Where(SqlDb.Dcms_Admin._ADMIN_NAME_.EqulesExp().AND(SqlDb.Dcms_Admin._ADMIN_PWD_.EqulesExp()));
                List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>();
                if (adminList.Count == 1)
                {
                    SessionHelper.Add("adminInfo", adminList[0]);
                    Utils.WriteCookie("Admin_Id", adminList[0].Admin_Id.ToString(), 60);
                    Utils.WriteCookie("AuthId", Utils.MD5(Utils.SHA256(adminList[0].Admin_Pwd + adminList[0].Admin_Name)), 60);
                    admin.Admin_LoginTimes = adminList[0].Admin_LoginTimes + 1;
                    admin.Admin_LastIp = IRequest.GetIP();
                    admin.Admin_LastTime = DateTime.Now;
                    admin.Admin_Id = adminList[0].Admin_Id;
                    admin.Admin_RoleId = adminList[0].Admin_RoleId;
                    //更新记录
                    session.Update(admin);
                    //取默认语言版本开始
                    string langFlag = "CN";
                    string langName = "中文版";
                    getDefaultLangFlag(ref langFlag, ref langName);
                    //超级用户跳过验证
                    string[] superUser = ConfigurationManager.AppSettings["superUser"].ToUpper().Split(new char[] { ',' });
                    bool isSuper = false;
                    for (int i = 0; i < superUser.Length; i++)
                    {
                        if (superUser[i].Equals(admin.Admin_Name.ToUpper()))
                        {
                            SessionHelper.Add("LangFlag", langFlag.ToUpper());
                            SessionHelper.Add("LangName", langName);
                            Utils.WriteCookie("LangFlag", Utils.UrlEncode(langFlag.ToUpper()), 60);
                            Utils.WriteCookie("LangName", Utils.UrlEncode(langName), 60);
                            isSuper=true;
                            break;
                        }
                    }
                    if (!isSuper)//组别用户验证
                    {
                        SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                        role.Role_Id = admin.Admin_RoleId;
                        IQuery Rolequery = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp());
                        List<SqlDb.Dcms_Role> rList = Rolequery.GetList<SqlDb.Dcms_Role>();
                        string thisRoleCateLang = string.Empty;
                        if (rList.Count > 0)
                        {
                            if (String.IsNullOrEmpty(rList[0].Role_CateLang))
                            {
                                lit_ErrorInfo.Text = "<div class='errorinfo'>此用户还没有任何权限，请联系管理员设置权限！</div>";
                                return;
                            }
                            thisRoleCateLang = Convert.ToString(rList[0].Role_CateLang).ToUpper();
                            if (thisRoleCateLang.IndexOf(langFlag.ToUpper()) >= 0)
                            {
                                SessionHelper.Add("LangFlag", langFlag.ToUpper());
                                SessionHelper.Add("LangName", langName);
                                Utils.WriteCookie("LangFlag", Utils.UrlEncode(langFlag.ToUpper()), 60);
                                Utils.WriteCookie("LangName", Utils.UrlEncode(langName), 60);
                            }
                            else
                            {
                                string thisCateLangFlag = Utils.SplitString(thisRoleCateLang, ",")[0].ToUpper();
                                SessionHelper.Add("LangFlag", thisCateLangFlag);
                                SessionHelper.Add("LangName", getRoleLangName(thisCateLangFlag));
                                Utils.WriteCookie("LangFlag", Utils.UrlEncode(langFlag.ToUpper()), 60);
                                Utils.WriteCookie("LangName", Utils.UrlEncode(langName), 60);
                            }
                        }
                        else
                        {
                            lit_ErrorInfo.Text = "<div class='errorinfo'>此用户还没有任何权限，请联系管理员设置权限！</div>";
                            return;
                        }
                    }
                    //取默认语言版本结束
                    Response.Redirect("BaseManage/MainFrame.aspx");
                }
                else
                {
                    lit_ErrorInfo.Text = "<div class='errorinfo'>登录失败，用户名或密码出错，请重试！</div>";
                }
            }
        }
        /// <summary>
        /// 取出默认语言版
        /// </summary>
        /// <param name="defaultlangflag">标记</param>
        /// <param name="defaultlangname">名称</param>
        protected void getDefaultLangFlag(ref string defaultlangflag,ref string defaultlangname)
        {
            string xmlpath = System.Web.HttpContext.Current.Server.MapPath("../sysconfig/urls.config");
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlpath);
            XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
            foreach (XmlNode xn in objNode.ChildNodes)
            {
                if (xn.Attributes["page"].Value.ToUpper().Equals(xn.Attributes["defaultpage"].Value.ToUpper()))
                {
                    defaultlangflag=xn.Attributes["langflag"].Value;
                    defaultlangname = xn.Attributes["name"].Value;
                    break;
                }
            }
        }
        
        protected string getRoleLangName(string defaultlangflag)
        {

            string xmlpath = System.Web.HttpContext.Current.Server.MapPath("../sysconfig/urls.config");
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlpath);
            XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
            foreach (XmlNode xn in objNode.ChildNodes)
            {
                if (xn.Attributes["langflag"].Value.ToUpper()==defaultlangflag)
                {
                    return xn.Attributes["name"].Value;
                }
            }
            return "未知版本";
        }
    }
}