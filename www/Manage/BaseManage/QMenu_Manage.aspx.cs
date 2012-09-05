using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Text;
using System.Text.RegularExpressions;
using Dcms.Orm;
using Dcms.Utility;

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_QMenu_Manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //操作方式
            string action = IRequest.GetQueryString("action").ToLower();
            switch (action)
            {
                case "select":
                    Response.Clear();
                    Response.Write(doSelect());
                    break;
                case "insert":
                    Response.Clear();
                    Response.Write(doInsert());
                    break;
                case "update":
                    Response.Clear();
                    Response.Write(doUpdate());
                    break;
                case "delete":
                    Response.Clear();
                    Response.Write(doDelete());
                    break;
            }

        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <returns></returns>
        private string doDelete()
        {
            try
            {
                int id = IRequest.GetFormInt("QM_Id", 0);
                if (id > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_QMenu qmenu = new SqlDb.Dcms_QMenu();
                        qmenu.QMenu_Id = id;
                        IQuery query = session.GetQuery(qmenu).Where(SqlDb.Dcms_QMenu._QMENU_ID_.EqulesExp());
                        query.Delete();
                    }
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }

        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doUpdate()
        {
            try
            {
                int id = IRequest.GetFormInt("QM_Id", 0);
                string du = IRequest.GetFormString("du").ToLower();
                int adminId = adminInfo.Admin_Id;
                if (id > 0 && adminId > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_QMenu qmenu = new SqlDb.Dcms_QMenu();
                        qmenu.QMenu_AdminId = adminId;
                        IQuery query = session.GetQuery(qmenu).Where(SqlDb.Dcms_QMenu._QMENU_ADMINID_.EqulesExp()).OrderBy(SqlDb.Dcms_QMenu._QMENU_ORDER_, Direction.ASC);
                        List<SqlDb.Dcms_QMenu> qmenuList = query.GetList<SqlDb.Dcms_QMenu>();
                        int currentI = 0;
                        if (qmenuList.Count > 0)
                        {

                            for (int i = 0; i < qmenuList.Count; i++)
                            {
                                if (qmenuList[i].QMenu_Id == id)
                                {
                                    currentI = i;
                                    break;
                                }
                            }
                        }
                        if (du == "up")
                        {
                            qmenu = qmenuList[currentI - 1];
                            int currentOrder = qmenu.QMenu_Order;
                            qmenu.QMenu_Order = qmenuList[currentI].QMenu_Order;
                            //编辑上一条的记录
                            session.Update(qmenu);
                            qmenu = qmenuList[currentI];
                            qmenu.QMenu_Order = currentOrder;
                            //编辑当前的记录
                            session.Update(qmenu);
                        }
                        else
                        {
                            qmenu = qmenuList[currentI + 1];
                            int currentOrder = qmenu.QMenu_Order;
                            qmenu.QMenu_Order = qmenuList[currentI].QMenu_Order;
                            //编辑上一条的记录
                            session.Update(qmenu);
                            qmenu = qmenuList[currentI];
                            qmenu.QMenu_Order = currentOrder;
                            //编辑当前的记录
                            session.Update(qmenu);
                        }

                    }
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsert()
        {
            try
            {
                int adminId = adminInfo.Admin_Id;
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
  SqlDb.Dcms_QMenu qmenu = new SqlDb.Dcms_QMenu();
                    qmenu.QMenu_AdminId = adminId;
                    string qmenuUrl = IRequest.GetFormString("QMenu_Url").Replace("|", "&");
                    qmenu.QMenu_Url = Regex.Replace(qmenuUrl, @"\:(\d)+\/", "/", RegexOptions.IgnoreCase);
                    qmenu.QMenu_Title = IRequest.GetFormString("QMenu_Title");
                    DataTable existdt = session.GetTable("select * from dcms_qmenu where qmenu_adminid=" + adminId + " and qmenu_url='" + qmenu.QMenu_Url + "'");
                    //IQuery query = session.GetQuery(qmenu).Where(SqlDb.Dcms_QMenu._QMENU_ADMINID_.EqulesExp().AND(SqlDb.Dcms_QMenu._QMENU_URL_.EqulesExp()));
                  //  List<SqlDb.Dcms_QMenu> list = query.GetList<SqlDb.Dcms_QMenu>();
                    if (existdt.Rows.Count > 0)
                    {
                        existdt.Dispose();
                        return "false";
                    }
                    DataTable dt=session.GetTable("select  * from dcms_qmenu where Qmenu_adminid="+adminId+"  order by qmenu_order desc");
                    

                    if (dt.Rows.Count > 0)
                    {
                        qmenu.QMenu_Order = Utils.StrToInt(dt.Rows[0]["QMenu_Order"], 1) + 1;
                    }
                    else
                    {
                        qmenu.QMenu_Order = 1;
                    }
                    dt.Dispose();
                    //提交插入
                    session.Create(qmenu);

                

                }
                return "true";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
        private string doSelect()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" id=\"QMenuListTable\" cellpadding=\"0\">\n");
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_QMenu QMenu = new SqlDb.Dcms_QMenu();
                    QMenu.QMenu_AdminId = adminInfo.Admin_Id;
                    IQuery query = session.GetQuery(QMenu).Where(SqlDb.Dcms_QMenu._QMENU_ADMINID_.EqulesExp()).OrderBy(SqlDb.Dcms_QMenu._QMENU_ORDER_, Direction.ASC);
                    List<SqlDb.Dcms_QMenu> QMenuList = query.GetList<SqlDb.Dcms_QMenu>();
                    if (QMenuList.Count > 0)
                    {
                        for (int i = 0; i < QMenuList.Count; i++)
                        {
                            string bgstr = string.Empty;
                            if ((i + 1) % 2 == 0)
                            {
                                bgstr = "style=\"background-color:#F8FEF5;\"";
                            }
                            if ((i == 0) && (QMenuList.Count > 1))
                            {
                                sb.Append(string.Format("<tr {0}><td height=\"25\">&nbsp;&nbsp;&nbsp;{1}</td>", bgstr, QMenuList[i].QMenu_Title));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"toporder\"></div><div class=\"downorder\" onclick=\"ajaxSubmi({0},'update','down')\"></div></td>", QMenuList[i].QMenu_Id));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"delqmenu\" onclick=\"ajaxSubmi({0},'delete','ud')\"></div></td></tr>\n", QMenuList[i].QMenu_Id));
                            }
                            else if ((i == (QMenuList.Count - 1)) && (QMenuList.Count > 1))
                            {
                                sb.Append(string.Format("<tr {0}><td height=\"25\">&nbsp;&nbsp;&nbsp;{1}</td>", bgstr, QMenuList[i].QMenu_Title));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"uporder\" onclick=\"ajaxSubmi({0},'update','up')\"></div><div class=\"bottomorder\"></div></td>", QMenuList[i].QMenu_Id));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"delqmenu\" onclick=\"ajaxSubmi({0},'delete','ud')\"></div></td></tr>\n", QMenuList[i].QMenu_Id));
                            }
                            else if ((i == 0) && (i == (QMenuList.Count - 1)))
                            {
                                sb.Append(string.Format("<tr {0}><td height=\"25\">&nbsp;&nbsp;&nbsp;{1}</td>", bgstr, QMenuList[i].QMenu_Title));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"toporder\"></div><div class=\"bottomorder\"></div></td>", QMenuList[i].QMenu_Id));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"delqmenu\" onclick=\"ajaxSubmi({0},'delete','ud')\"></div></td></tr>\n", QMenuList[i].QMenu_Id));
                            }
                            else
                            {
                                sb.Append(string.Format("<tr {0}><td height=\"25\">&nbsp;&nbsp;&nbsp;{1}</td>", bgstr, QMenuList[i].QMenu_Title));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"uporder\" onclick=\"ajaxSubmi({0},'update','up')\"></div><div class=\"downorder\" onclick=\"ajaxSubmi({0},'update','down')\"></div></td>", QMenuList[i].QMenu_Id));
                                sb.Append(string.Format("<td width=\"70\" ><div class=\"delqmenu\" onclick=\"ajaxSubmi({0},'delete','ud')\"></div></td></tr>\n", QMenuList[i].QMenu_Id));
                            }
                        }
                    }
                }
                sb.Append("</table>\n");
                return sb.ToString();
            }
            catch
            {
                return "false";
            }
        }
    }
}
