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

namespace Manage.position
{
    public partial class Manage_position_position_manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_UserLevel position = new SqlDb.Dcms_UserLevel();
                //创建查询
                IQuery query = session.GetQuery(position);

                if (keyword.Length > 0)
                {
                    query.Where(SqlDb.Dcms_UserLevel._USERLEVEL_TITLE_.Like('%', keyword, '%'));
                }
                query.OrderBy(SqlDb.Dcms_UserLevel._USERLEVEL_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_UserLevel> userlevelList = query.GetList<SqlDb.Dcms_UserLevel>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < userlevelList.Count; i++)
                {
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", userlevelList[i].UserLevel_Id.ToString(), userlevelList[i].UserLevel_Id.ToString(), FormatJsonData(userlevelList[i].UserLevel_Title.ToString()), FormatJsonData(userlevelList[i].UserLevel_Key), userlevelList[i].UserLevel_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == userlevelList.Count)
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
                    string Sql = "select * from [Dcms_UserLevel] where UserLevel_Id=" + id;
                    DataTable userlevelDt = session.GetTable(Sql);

                    if (userlevelDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in userlevelDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(userlevelDt.Rows[0][column.ColumnName].ToString())));
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
                    SqlDb.Dcms_UserLevel userlevel = new SqlDb.Dcms_UserLevel();
                    userlevel.UserLevel_AddTime = DateTime.Now;
                    UpdateModelByForm(userlevel, Request.Form);
                    session.Create(userlevel);
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
                int userlevelid = IRequest.GetFormInt("UserLevel_Id", 0);
                if (userlevelid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_UserLevel userlevel = new SqlDb.Dcms_UserLevel();
                        userlevel.UserLevel_Id = userlevelid;
                        IQuery query = session.GetQuery(userlevel).Where(SqlDb.Dcms_UserLevel._USERLEVEL_ID_.EqulesExp());
                        IList<SqlDb.Dcms_UserLevel> userlevellist = query.GetList<SqlDb.Dcms_UserLevel>();
                        if (userlevellist.Count > 0)
                        {
                            userlevel = userlevellist[0];
                            UpdateModelByForm(userlevel, Request.Form);
                            session.Update(userlevel);
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
                    string Sql = "DELETE FROM [Dcms_UserLevel] WHERE [UserLevel_Id] IN(" + id + ")";
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

