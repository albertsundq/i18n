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

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Admin_Manage : Dcms.BasePage.ManagePage
    {
        protected SortedDictionary<int, string> roleName = new SortedDictionary<int, string>();
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
                case "getone":
                    Response.Clear();
                    Response.Write(doGetOne());
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
        /// 批量删除操作
        /// </summary>
        /// <returns></returns>
        private string doDelete()
        {
            try
            {
                string id = IRequest.GetQueryString("id").TrimStart(new char[] { ',' });

                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    string Sql = "DELETE FROM [Dcms_Admin] WHERE [Admin_Id] IN(" + id + ")";
                    session.simple(Sql);
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        /// <summary>
        /// 取单条编辑数据
        /// </summary>
        /// <returns>json</returns>
        private string doGetOne()
        {
            int id = IRequest.GetQueryInt("id", 0);
            string oneRecord = "";
            if (id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                    IQuery query = session.GetQuery(admin).Where(SqlDb.Dcms_Admin._ADMIN_ID_.EqulesExp(id));
                    List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>();
                    if (adminList.Count > 0)
                    {
                        oneRecord = "[{\"Admin_Name\":\"" + adminList[0].Admin_Name + "\",\"Admin_Email\":\"" + adminList[0].Admin_Email + "\",\"Admin_RoleId\":\"" + adminList[0].Admin_RoleId.ToString() + "\",\"Admin_Id\":\"" + adminList[0].Admin_Id.ToString() + "\"}]";
                    }
                }   
            }
            return oneRecord;
        }

        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doUpdate()
        {
            try
            {
                int id = IRequest.GetFormInt("Admin_Id", 0);
                if (id > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                        IQuery query = session.GetQuery(admin).Where(SqlDb.Dcms_Admin._ADMIN_ID_.EqulesExp(id));
                        List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>();
                        if (adminList.Count > 0)
                        {
                            admin = adminList[0];
                            //检测是否需要修改密码
                            string Admin_Pwd = IRequest.GetFormString("Admin_Pwd").Trim();
                            if (Admin_Pwd.Length > 0)
                            {
                                admin.Admin_Pwd = Utils.MD5(Utils.SHA256(Admin_Pwd));
                            }
                            admin.Admin_Name = IRequest.GetFormString("Admin_Name");
                            admin.Admin_Email = IRequest.GetFormString("Admin_Email");
                            admin.Admin_RoleId = IRequest.GetFormInt("Admin_RoleId", 0);
                            //提交编辑
                            session.Update(admin);
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
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                    string adminname = IRequest.GetFormString("Admin_Name").Trim();
                    string adminsql = "select admin_id from dcms_admin where admin_name='" + adminname + "'";
                    if (session.GetTable(adminsql).Rows.Count > 0)
                    {
                        return "userexist";
                    }
                   
                    admin.Admin_Name = IRequest.GetFormString("Admin_Name");
                    admin.Admin_Pwd = Utils.MD5(Utils.SHA256(IRequest.GetFormString("Admin_Pwd")));
                    admin.Admin_Email = IRequest.GetFormString("Admin_Email");
                    admin.Admin_AddTime = DateTime.Now;
                    admin.Admin_RoleId = IRequest.GetFormInt("Admin_RoleId", 0);
                    session.Create(admin);
                }
                return "true";
            }
            catch
            {
                return "false";
            }
            
        }
        /// <summary>
        /// 按页取数据
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            StringBuilder sb = new StringBuilder();
            //取Grid提交来的数据开始
            int rp = IRequest.GetFormInt("rp", 1);
            int page = IRequest.GetFormInt("page", 1);
            string keyword = IRequest.GetFormString("query");
            string qtype = IRequest.GetFormString("qtype");
            //取Grid提交来的数据结束
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                IQuery rQuery = session.GetQuery(role).OrderBy(SqlDb.Dcms_Role._ROLE_ID_, Direction.DESC);
                List<SqlDb.Dcms_Role> roleList = rQuery.GetList<SqlDb.Dcms_Role>();
                
                
                for (int a = 0; a < roleList.Count; a++)
                {
                    roleName.Add(roleList[a].Role_Id, roleList[a].Role_Name);
                }
                SqlDb.Dcms_Admin admin = new SqlDb.Dcms_Admin();
                //创建查询
                if (keyword.Length > 0)
                {
                    admin.Admin_Name = keyword;
                }
                IQuery query = session.GetQuery(admin);

                if (keyword.Length > 0)
                {
                    query.Where(SqlDb.Dcms_Admin._ADMIN_NAME_.Like().AND(SqlDb.Dcms_Admin._ADMIN_NAME_.NotEquls("dcms")));
                }
                else
                {
                    query.Where(SqlDb.Dcms_Admin._ADMIN_NAME_.NotEquls("dcms"));
                }
                query.OrderBy(SqlDb.Dcms_Admin._ADMIN_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_Admin> adminList = query.GetList<SqlDb.Dcms_Admin>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < adminList.Count; i++)
                {
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"]", adminList[i].Admin_Id.ToString(), adminList[i].Admin_Id.ToString(), adminList[i].Admin_Name, adminList[i].Admin_Email, adminList[i].Admin_LoginTimes.ToString(), adminList[i].Admin_LastTime.ToString("yyyy/MM/dd"), adminList[i].Admin_LastIp, getRoleName(adminList[i].Admin_RoleId)));
                    if ((i + 1) == adminList.Count)
                    {
                        sb.Append("}\n");
                    }
                    else
                    {
                        sb.Append("},\n");
                    }
                }
                sb.Append("]\n");
                sb.Append("}");
            }
            return sb.ToString();
        }

        private string getRoleName(int roleId)
        {
            if (roleName.ContainsKey(roleId))
            {
                return roleName[roleId];
            }
            else
            {
                return "<font color='red'>用户组缺失</font>";
            }
        }
    }
    
}
