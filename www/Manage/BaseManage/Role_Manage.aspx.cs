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
    public partial class Manage_BaseManage_Role_Manage : Dcms.BasePage.ManagePage
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
                    string Sql = "DELETE FROM [Dcms_Role] WHERE [Role_Id] IN(" + id + ")";
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
                    SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                    IQuery query = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp(id));
                    List<SqlDb.Dcms_Role> roleList = query.GetList<SqlDb.Dcms_Role>();
                    if (roleList.Count > 0)
                    {
                        oneRecord = "[{\"Role_Name\":\"" + roleList[0].Role_Name + "\",\"Role_Order\":\"" + roleList[0].Role_Order + "\",\"Role_Id\":\"" + roleList[0].Role_Id.ToString() + "\"}]";
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
                int id = IRequest.GetFormInt("Role_Id", 0);
                if (id > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                        IQuery query = session.GetQuery(role).Where(SqlDb.Dcms_Role._ROLE_ID_.EqulesExp(id));
                        List<SqlDb.Dcms_Role> roleList = query.GetList<SqlDb.Dcms_Role>();
                        if (roleList.Count > 0)
                        {
                            role = roleList[0];
                            role.Role_Name = IRequest.GetFormString("Role_Name");
                            role.Role_Order = IRequest.GetFormInt("Role_Order", 0);
                            //提交编辑
                            session.Update(role);
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
                    SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                    role.Role_AddTime = DateTime.Now;
                    role.Role_Name = IRequest.GetFormString("Role_Name");
                    role.Role_Order = IRequest.GetFormInt("Role_Order", 0);
                    session.Create(role);
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
                //创建查询
                IQuery query = session.GetQuery(role);
                if (keyword.Length > 0)
                {
                    query.Where(SqlDb.Dcms_Role._ROLE_NAME_.Like('%', keyword, '%')).OrderBy(SqlDb.Dcms_Role._ROLE_ID_, Direction.DESC);
                }
                else
                {
                    query.OrderBy(SqlDb.Dcms_Role._ROLE_ID_, Direction.DESC);
                }
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_Role> roleList = query.GetList<SqlDb.Dcms_Role>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < roleList.Count; i++)
                {
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", roleList[i].Role_Id.ToString(), roleList[i].Role_Id.ToString(), roleList[i].Role_Name, roleList[i].Role_Order.ToString(), roleList[i].Role_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == roleList.Count)
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
    }
    
}
