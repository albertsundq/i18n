using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Dcms.Orm;
using Dcms.Utility;
using System.Text;
using System.Collections.Specialized;
namespace Manage.Link
{
    public partial class Manage_link_link_manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_Link link = new SqlDb.Dcms_Link();
                //创建查询
                if (keyword.Length > 0)
                {
                    link.Link_Title = keyword;
                }
                IQuery query = session.GetQuery(link);

                if (keyword.Length > 0)
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_Link._LINK_TITLE_.Like('%', keyword, '%').AND(SqlDb.Dcms_Link._LINK_CATEID_.EqulesExp(cateid)));
                    }
                    else
                    {
                        query.Where(SqlDb.Dcms_Link._LINK_TITLE_.Like('%', keyword, '%'));
                    }
                }
                else
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_Link._LINK_CATEID_.EqulesExp(cateid));
                    }
                }
                query.OrderBy(SqlDb.Dcms_Link._LINK_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_Link> linkList = query.GetList<SqlDb.Dcms_Link>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < linkList.Count; i++)
                {
                    string state = (linkList[i].Link_State == "1") ? "显示" : "关闭";
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", linkList[i].Link_Id.ToString(), linkList[i].Link_Id.ToString(), FormatJsonData(linkList[i].Link_Title.ToString()), state, linkList[i].Link_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == linkList.Count)
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
                    string Sql = "select * from [Dcms_Link] where Link_Id=" + id;
                    DataTable linkDt = session.GetTable(Sql);

                    if (linkDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in linkDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(linkDt.Rows[0][column.ColumnName].ToString())));
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
                    SqlDb.Dcms_Link link = new SqlDb.Dcms_Link();
                    link.Link_AddTime = DateTime.Now;
                    UpdateModelByForm(link, Request.Form);

                    session.Create(link);
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
                int linkid = IRequest.GetFormInt("Link_Id", 0);
                if (linkid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_Link link = new SqlDb.Dcms_Link();
                        IQuery query = session.GetQuery(link).Where(SqlDb.Dcms_Link._LINK_ID_.EqulesExp(linkid));
                        IList<SqlDb.Dcms_Link> linklist = query.GetList<SqlDb.Dcms_Link>();
                        if (linklist.Count > 0)
                        {
                            link = linklist[0];
                            UpdateModelByForm(link, Request.Form);

                            session.Update(link);

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
                    string Sql = "DELETE FROM [Dcms_Link] WHERE [Link_Id] IN(" + id + ")";
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
