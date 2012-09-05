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
using Dcms.Orm;
using Dcms.Utility;

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Popedom_Set : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //操作方式
            string action = IRequest.GetQueryString("action").ToLower();
            switch (action)
            {
                case "select":
                    doSelect();
                    break;
                case "update":
                    Response.Clear();
                    Response.Write(doUpdate());
                    Response.End();
                    break;
            }
        }
        /// <summary>
        /// 做初始化
        /// </summary>
        private void doSelect()
        {
            int roleId = Dcms.Utility.IRequest.GetQueryInt("roleId", 0);
            lit_cateTree.Text = getCateTree();
            hid_roleId.Value = roleId.ToString();
            //取出对应的权限
            lit_delete.Text = getPopedom("delete", roleId);
            lit_select.Text = getPopedom("select", roleId);
            lit_update.Text = getPopedom("update", roleId);
            lit_insert.Text = getPopedom("insert", roleId);
            //取出角色版本
            lit_catelang.Text = getRoleCateLang(roleId);
            //取系统功能权限
            lit_syscate_1.Text = getsysCate(1);
            //取扩展功能权限
            lit_syscate_2.Text = getsysCate(2);
        }
        private string getsysCate(int typeId)
        {
            StringBuilder sb = new StringBuilder();
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_SysCate scate = new SqlDb.Dcms_SysCate();
                List<int> rangeId = new List<int>(new int[] { 1, 4, 7, 8 });
                IQuery Query = session.GetQuery(scate).Where(SqlDb.Dcms_SysCate._SYSCATE_TYPE_.EqulesExp(typeId).AND(SqlDb.Dcms_SysCate._SYSCATE_ID_.NotIn(rangeId))).OrderBy(SqlDb.Dcms_SysCate._SYSCATE_ORDER_, Direction.ASC);
                List<SqlDb.Dcms_SysCate> scateList = Query.GetList<SqlDb.Dcms_SysCate>();
                for (int i = 0; i < scateList.Count; i++)
                {
                    sb.Append("<tr class='trlinebg'>\n<td height='25'>&nbsp;</td>\n");
                    sb.Append(string.Format("<td>{0}</td>\n", scateList[i].SysCate_Name));
                    sb.Append("<td>&nbsp;</td>\n");
                    sb.Append(string.Format("<td><input type='checkbox' value='-{0}' class='chkbox' name='select' /></td>\n", scateList[i].SysCate_Id));
                    sb.Append(string.Format("<td><input type='checkbox' value='-{0}' class='chkbox' name='insert' /></td>\n", scateList[i].SysCate_Id));
                    sb.Append(string.Format("<td><input type='checkbox' value='-{0}' class='chkbox' name='update' /></td>\n", scateList[i].SysCate_Id));
                    sb.Append(string.Format("<td><input type='checkbox' value='-{0}' class='chkbox' name='delete' /></td>\n", scateList[i].SysCate_Id));
                    sb.Append("<td>&nbsp;</td>\n</tr>\n");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doUpdate()
        {
            try
            {
                string selectvalue = IRequest.GetFormString("selectvalue").TrimStart(new char[] { ',' });
                string[] selectCateId = selectvalue.Split(',');
                if (selectCateId.Length > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        int roleId = Dcms.Utility.IRequest.GetFormInt("roleId", 0);
                        if (roleId > 0)
                        {
                            //处理select权限
                            session.simple("delete from [Dcms_Permissions] where [Permissions_RoleId]=" + roleId);
                            for (int i = 0; i < selectCateId.Length; i++)
                            {
                                SqlDb.Dcms_Permissions perm = new SqlDb.Dcms_Permissions();
                                perm.Permissions_AdminId = 0;
                                perm.Permissions_CateId = Utils.StrToInt(selectCateId[i], 0);
                                perm.Permissions_Delete = 0;
                                perm.Permissions_Insert = 0;
                                perm.Permissions_RoleId = roleId;
                                perm.Permissions_Select = 1;
                                perm.Permissions_Update = 0;
                                session.Create(perm);
                            }
                            string Sql = string.Empty;
                            //处理insert权限
                            string insertvalue = IRequest.GetFormString("insertvalue").TrimStart(new char[] { ',' });
                            if (insertvalue.Length > 0)
                            {
                                Sql = "update [Dcms_Permissions] set Permissions_Insert=1 where [Permissions_CateId] in(" + insertvalue + ") and [Permissions_RoleId]=" + roleId;
                                session.simple(Sql);
                            }
                            //处理update权限
                            string updatevalue = IRequest.GetFormString("updatevalue").TrimStart(new char[] { ',' });
                            if (updatevalue.Length > 0)
                            {
                                Sql = "update [Dcms_Permissions] set Permissions_Update=1 where [Permissions_CateId] in(" + updatevalue + ") and [Permissions_RoleId]=" + roleId;
                                session.simple(Sql);
                            }
                            //处理delete权限
                            string deletevalue = IRequest.GetFormString("deletevalue").TrimStart(new char[] { ',' });
                            if (deletevalue.Length > 0)
                            {
                                Sql = "update [Dcms_Permissions] set Permissions_Delete=1 where [Permissions_CateId] in(" + deletevalue + ") and [Permissions_RoleId]=" + roleId;
                                session.simple(Sql);
                            }
                            //处理角色语言版本权限
                            string catelang = IRequest.GetFormString("catelang").TrimStart(new char[] { ',' });
                            SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                            role.Role_Id = roleId;
                            IQuery query = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp());
                            List<SqlDb.Dcms_Role> rList = query.GetList<SqlDb.Dcms_Role>();
                            if (rList.Count > 0)
                            {
                                role = rList[0];
                                role.Role_CateLang = catelang.ToUpper();
                                role.Update();
                            }
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
        /// 输出权限树
        /// </summary>
        /// <returns></returns>
        private string getCateTree()
        {
            string treeStr = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
                String[] str = System.IO.Directory.GetDirectories(aspxpath);
                foreach (string pagestr in str)
                {
                    string CateLang = string.Empty;
                    CateLang = pagestr.Substring(pagestr.LastIndexOf('\\') + 1).ToUpper();
                    string Sql = "select * from [Dcms_Cate] where Cate_Lang='" + CateLang + "' order by [Cate_Order] asc";
                    DataTable cateDt = session.GetTable(Sql);
                    if (cateDt.Rows.Count > 0)
                    {
                        popedomTree Tree = new popedomTree();
                        treeStr = treeStr + Tree.CreateTree(cateDt, CateLang);
                    }
                }
            }
            return treeStr;
        }

        /// <summary>
        /// 取对应的权限
        /// </summary>
        /// <param name="popedomString">select/update/delete/insert</param>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        private string getPopedom(string popedomString, int roleId)
        {
            string popedom = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string Sql = "select [Permissions_CateId] from [Dcms_Permissions] where [Permissions_RoleId]=" + roleId.ToString() + " and [Permissions_" + popedomString + "]=1";
                DataTable cateDt = session.GetTable(Sql);
                if (cateDt.Rows.Count > 0)
                {
                    for (int i = 0; i < cateDt.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            popedom = cateDt.Rows[i][0].ToString();
                        }
                        else
                        {
                            popedom = popedom + "," + cateDt.Rows[i][0].ToString();
                        }
                    }
                }
            }
            return popedom;
        }

        /// <summary>
        /// 取对应的权限
        /// </summary>
        /// <param name="popedomString">select/update/delete/insert</param>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        private string getRoleCateLang(int roleId)
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                role.Role_Id = roleId;
                IQuery query = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp());
                List<SqlDb.Dcms_Role> rList = query.GetList<SqlDb.Dcms_Role>();
                if (rList.Count > 0)
                {
                    return rList[0].Role_CateLang;
                }
            }
            return "";
        }

    }
}
