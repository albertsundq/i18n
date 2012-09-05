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
using System.Collections.Specialized;

namespace Manage.user
{
    public partial class Manage_user_user_manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = IRequest.GetQueryString("action").ToString().ToLower();
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
        /// 按页取数据
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            StringBuilder sb = new StringBuilder();
            //取Grid提交来的数据开始
            //int uploadId = IRequest.GetQueryInt("id", 0);
            int rp = IRequest.GetFormInt("rp", 10);
            int page = IRequest.GetFormInt("page", 1);
            string keyword = Utils.chkSQL(IRequest.GetFormString("query"));
            string qtype = IRequest.GetFormString("qtype");
            int cateid = IRequest.GetQueryInt("cateid", 0);
            //string path = getUploadPathByUploadId(uploadId).Replace("\\", "/");
            //取Grid提交来的数据结束
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                //创建查询
                IQuery query = session.GetQuery(user);

                if (keyword.Length > 0)
                {
                    query.Where(SqlDb.Dcms_User._USER_NAME_.Like('%', keyword, '%'));
                }
                query.OrderBy(SqlDb.Dcms_User._USER_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < userList.Count; i++)
                {
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", userList[i].User_Id.ToString(), userList[i].User_Id.ToString(), FormatJsonData(userList[i].User_Name.ToString()), FormatJsonData(userList[i].User_Email), userList[i].User_RegTime.ToString("yyyy-MM-dd")));
                    if ((i + 1) == userList.Count)
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
        /// <summary>
        /// 取单条编辑数据
        /// </summary>
        /// <returns>json</returns>
        private string doGetOne()
        {
            int id = IRequest.GetQueryInt("id", 0);
            StringBuilder sb = new StringBuilder();
            if (id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    string Sql = "select * from [Dcms_User] where User_Id=" + id;
                    DataTable userDt = session.GetTable(Sql);

                    if (userDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in userDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(userDt.Rows[0][column.ColumnName].ToString())));
                        }
                    }
                }
            }
            return sb.ToString().TrimEnd(new char[] { ',' }) + "}]";
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
                    SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                    user.User_RegTime = DateTime.Now;
                    UpdateModelByForm(user, Request.Form);
                    session.Create(user);
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
                //int productsid = IRequest.GetQueryInt("productsid", 0);
                int userid = IRequest.GetFormInt("User_Id", 0);
                if (userid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                        user.User_Id = userid;
                        IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_ID_.EqulesExp());
                        IList<SqlDb.Dcms_User> userlist = query.GetList<SqlDb.Dcms_User>();
                        if (userlist.Count > 0)
                        {
                            user = userlist[0];
                            UpdateModelByForm(user, Request.Form);
                            session.Update(user);
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
                    string Sql = "DELETE FROM [Dcms_User] WHERE [User_Id] IN(" + id + ")";
                    session.simple(Sql);
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
}

