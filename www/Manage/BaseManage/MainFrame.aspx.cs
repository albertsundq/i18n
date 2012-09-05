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
using Dcms.Orm;
using Dcms.Utility;
using System.IO;
using System.Xml;
namespace Manage.BaseManage
{
    public partial class Manage_MainFrame : Dcms.BasePage.ManagePage
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
                if (adminInfo != null)
                {
                    lit_adminName.Text = adminInfo.Admin_Name;
                    //取当前语言版本开始
                    string langFlag = string.Empty;
                    string langName = string.Empty;
                    if (SessionHelper.Get("DefaultLang") == null)
                    {
                        SessionHelper.Add("DefaultLang", SessionHelper.Get("LangFlag"));
                       
                    }
                    if (IRequest.GetQueryString("langflag").Trim().Length > 0)
                    {
                        langFlag = IRequest.GetQueryString("langflag").Trim();
                        langName = IRequest.GetQueryString("langname").Trim();
                        if (langFlag.ToUpper() == SessionHelper.Get("DefaultLang").ToString().ToUpper())
                        {
                            lit_index.Text = "<a href='../../' target='_blank' style='color:red'>首页预览</a>";
                        }
                        else
                        {
                            lit_index.Text = "<a href=../../" + langFlag + "/ target='_blank' style='color:red'>首页预览</a>";
                        }
                        SessionHelper.Add("LangFlag", langFlag.ToUpper());
                        SessionHelper.Add("LangName", langName);
                        Utils.WriteCookie("LangFlag", langFlag.ToUpper(), 60);
                        Utils.WriteCookie("LangName", Utils.UrlEncode(langName), 60);
                       
                        
                    }
                  
                    langFlag = Convert.ToString(SessionHelper.Get("LangFlag"));
                    Dcms.BasePage.ManagePage.mflangflag = langFlag;
                    langName = Convert.ToString(SessionHelper.Get("LangName"));
                    lit_webSiteId.Text = langName;

                    if (lit_index.Text.Length==0)
                    {
                        lit_index.Text = "<a href='../../' target='_blank' style='color:red'>首页预览</a>";
                    }
                    
                    //取语当前言版本结束

                    //供ajax调用的接口开始
                    int roleId = adminInfo.Admin_RoleId;
                    Dcms.BasePage.ManagePage.mfroleid= roleId;
                   // getTreeCate(roleId, langFlag);
                    string action = IRequest.GetQueryString("action").ToLower();
                    if (action.Equals("getscrolltree"))
                    {
                        Response.Clear();
                        Response.Write(getCateTree(roleId, langFlag));
                        Response.End();
                        return;
                    }
                  
                    if (action.Equals("getqmenu"))
                    {
                        Response.Clear();
                        Response.Write(getQMenu());
                        Response.End();
                        return;
                    }
                    //供ajax调用的接口结束
                    lit_LastIp.Text = adminInfo.Admin_LastIp;
                    lit_userName.Text = adminInfo.Admin_Name;
                    lit_LastTime.Text = adminInfo.Admin_LastTime.ToString("yyyy年MM月dd日HH时mm分ss秒");
                    lit_Times.Text = adminInfo.Admin_LoginTimes.ToString();


                    //左栏内容栏目树
                    lit_cateTree.Text = getCateTree(roleId, langFlag);
                    //快捷菜单
                    lit_QMenu.Text = getQMenu();
                    //系统模块
                    lit_SysCate_1.Text = getSysCate(1, roleId);
                    //扩展模块
                    lit_SysCate_2.Text = getSysCate(2, roleId);
                    //版本设置
                    lit_SysCate_3.Text = getSysDomain(roleId);

                //}
            }
        }
        private string getQMenu()
        {
            StringBuilder QMenuStr = new StringBuilder();
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_QMenu qmenu = new SqlDb.Dcms_QMenu();
                qmenu.QMenu_AdminId = adminInfo.Admin_Id;
                IQuery query = session.GetQuery(qmenu).Where(SqlDb.Dcms_QMenu._QMENU_ADMINID_.EqulesExp()).OrderBy(SqlDb.Dcms_QMenu._QMENU_ORDER_, Direction.ASC);
                List<SqlDb.Dcms_QMenu> QMenuList = query.GetList<SqlDb.Dcms_QMenu>();
                QMenuStr.Append(string.Format("<li onclick='javascript:changeViewClass();'> &nbsp; 切换栏目视图 &nbsp; </li>\n"));
                for (int i = 0; i < QMenuList.Count; i++)
                {
                    QMenuStr.Append(string.Format("<li onclick='javascript:checkState(this);'> &nbsp; <span dataType='iframe' dataLink='{0}'>{1}</span> &nbsp; </li>\n", QMenuList[i].QMenu_Url, QMenuList[i].QMenu_Title));
                }
            }
            return QMenuStr.ToString();
        }
        /// <summary>
        /// 取出有读权限的栏目
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="langFlag">版本标识</param>
        /// <returns></returns>
        private string getCateTree(int roleId, string langFlag)
        {
            string treeStr = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                if (roleId == 0)
                {
                    string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_ModelKeyId,Cate_IsMenu from Dcms_Cate where Cate_Lang='" + langFlag + "' order by Cate_Order asc";
                    DataTable cateDt = session.GetTable(Sql);
                    if (cateDt.Rows.Count > 0)
                    {
                        ScrollTree Tree = new ScrollTree();
                        treeStr = Tree.CreateTree(cateDt);
                    }
                }
                else
                {
                    string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_ModelKeyId,Cate_IsMenu from Dcms_Cate where Cate_Id in (select Permissions_CateId from Dcms_Permissions where Cate_Lang='" + langFlag + "' and Permissions_Select=1 and Permissions_RoleId=" + roleId + ") order by Cate_Order asc";
                    DataTable cateDt = session.GetTable(Sql);
                    if (cateDt.Rows.Count > 0)
                    {
                        ScrollTree Tree = new ScrollTree();
                        treeStr = Tree.CreateTree(cateDt);
                    }
                }
            }
            return treeStr;
        }

        ///<summary>
        ///是否存在测试数据
        ///</summary>
        ///<returns>"true"/"false"</returns>
        private bool beExistsTestData()
        {
            bool res = false;
            string xmlPathTestData = HttpContext.Current.Server.MapPath(@"~/sysconfig/TestRecord.xml");
            XmlDocument objXmlDocTestData = new XmlDocument();
            objXmlDocTestData.Load(xmlPathTestData);
            XmlNode rootNode = objXmlDocTestData.SelectSingleNode("root");

            if (rootNode != null && rootNode.ChildNodes.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        /// <summary>
        /// 系统模块、扩展模块
        /// </summary>
        /// <param name="typeId">1:系统模块;2:扩展模块</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        private string getSysCate(int typeId, int roleId)
        {
            StringBuilder SysCate = new StringBuilder();
            lit_testdata.Text = "<li style='display:none;'> &nbsp; <span class='span_testdata' id='span_testdata'></span> &nbsp; </li>";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                if (roleId == 0)
                {
                    string Sql = string.Empty;
                    //如果是dcms账号，去除一个网站栏目
                    if (superUser[0].Equals(adminInfo.Admin_Name.ToUpper()))
                    {
                       Sql = "select SysCate_Url,SysCate_Id,SysCate_Name from Dcms_SysCate where SysCate_Id<>10 and SysCate_Type=" + typeId + " order by SysCate_Order asc";
                       if (beExistsTestData())
                       {
                           lit_testdata.Text = @"<li> &nbsp; <span  class='span_testdata'  id='span_testdata'>清空测试数据</span> &nbsp; </li>";
                       }
                       else
                       {
                           lit_testdata.Text = @"<li> &nbsp; <span  class='span_testdata'  id='span_testdata'>生成测试数据</span> &nbsp; </li>";
                       }
                       
                    }
                    
                    //如果是企业主，一些高级权限将去掉
                    if (superUser[1].Equals(adminInfo.Admin_Name.ToUpper()))
                    {
                        Sql = "select SysCate_Url,SysCate_Id,SysCate_Name from Dcms_SysCate where SysCate_Id not in(1,4,7,8,11) and SysCate_Type=" + typeId + " order by SysCate_Order asc";
                    }
                    DataTable cateDt = session.GetTable(Sql);
                    for (int i = 0; i < cateDt.Rows.Count; i++)
                    {
                        SysCate.Append(string.Format("<li onclick='javascript:checkState(this);'> &nbsp; <span dataType='iframe' dataLink='../{0}?syspermcateId={1}&action=select'>{2}</span> &nbsp; </li>\n", cateDt.Rows[i][0], cateDt.Rows[i][1], cateDt.Rows[i][2]));
                    }
                }
                else
                {
                    string Sql = "select SysCate_Url,SysCate_Id,SysCate_Name from Dcms_SysCate where SysCate_Type=" + typeId + " and SysCate_Id in (select abs(Permissions_CateId) from Dcms_Permissions where Permissions_CateId<0 and Permissions_Select=1 and Permissions_RoleId=" + roleId + ") order by SysCate_Order asc";
                    DataTable cateDt = session.GetTable(Sql);
                    for (int i = 0; i < cateDt.Rows.Count; i++)
                    {
                        SysCate.Append(string.Format("<li onclick='javascript:checkState(this);'> &nbsp; <span dataType='iframe' dataLink='../{0}?syspermcateId={1}&action=select'>{2}</span> &nbsp; </li>\n", cateDt.Rows[i][0], cateDt.Rows[i][1], cateDt.Rows[i][2]));
                    }
                }
            }
            return SysCate.ToString();
        }
        /// <summary>
        /// 系统版本设置
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private string getSysDomain(int roleId)
        {
            StringBuilder SysDomain = new StringBuilder();
            string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlpath);
            XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
            if (roleId == 0)
            {
                foreach (XmlNode xn in objNode.ChildNodes)
                {
                    SysDomain.Append(string.Format("<li onclick='javascript:checkState(this);'> &nbsp; <a href='MainFrame.aspx?langflag={0}&langname={2}'>{1}</a> &nbsp; </li>\n", xn.Attributes["langflag"].Value, xn.Attributes["name"].Value, Server.UrlEncode(xn.Attributes["name"].Value)));
                }
            }
            else
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                    role.Role_Id = roleId;
                    IQuery query = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp());
                    List<SqlDb.Dcms_Role> rList = query.GetList<SqlDb.Dcms_Role>();
                    if (rList.Count > 0)
                    {
                        string roleCateFlag = rList[0].Role_CateLang;
                        foreach (XmlNode xn in objNode.ChildNodes)
                        {
                            if (roleCateFlag.ToUpper().IndexOf(xn.Attributes["langflag"].Value.ToUpper()) >= 0)
                            {
                                SysDomain.Append(string.Format("<li onclick='javascript:checkState(this);'> &nbsp; <a href='MainFrame.aspx?langflag={0}&langname={2}'>{1}</a> &nbsp; </li>\n", xn.Attributes["langflag"].Value, xn.Attributes["name"].Value, Server.UrlEncode(xn.Attributes["name"].Value)));
                            }
                        }
                    }
                }
            }
            return SysDomain.ToString();
        }       
    }
}