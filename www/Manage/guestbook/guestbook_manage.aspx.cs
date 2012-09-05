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
using Dcms.Orm;
using Dcms.Utility;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace Manage.GuestBook
{
    public partial class Manage_guestbook_guestbook_manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_GuestBook guestbook = new SqlDb.Dcms_GuestBook();
                //创建查询
                if (keyword.Length > 0)
                {
                    guestbook.GuestBook_Title = keyword;
                }
                IQuery query = session.GetQuery(guestbook);

                if (keyword.Length > 0)
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_GuestBook._GUESTBOOK_TITLE_.Like('%', keyword, '%').AND(SqlDb.Dcms_GuestBook._GUESTBOOK_CATEID_.EqulesExp(cateid)));
                    }
                    else
                    {
                        query.Where(SqlDb.Dcms_GuestBook._GUESTBOOK_TITLE_.Like('%', keyword, '%'));
                    }
                }
                else
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_GuestBook._GUESTBOOK_CATEID_.EqulesExp(cateid));
                    }
                }
                query.OrderBy(SqlDb.Dcms_GuestBook._GUESTBOOK_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_GuestBook> guestbookList = query.GetList<SqlDb.Dcms_GuestBook>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < guestbookList.Count; i++)
                {
                    string state = (guestbookList[i].GuestBook_State == "1") ? "显示" : "关闭";
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", guestbookList[i].GuestBook_Id.ToString(), guestbookList[i].GuestBook_Id.ToString(), FormatJsonData(guestbookList[i].GuestBook_Title.ToString()), state, guestbookList[i].GuestBook_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == guestbookList.Count)
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
                    string Sql = "select * from [Dcms_GuestBook] where GuestBook_Id=" + id;
                    DataTable guestbookDt = session.GetTable(Sql);

                    if (guestbookDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in guestbookDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(guestbookDt.Rows[0][column.ColumnName].ToString())));
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
                    SqlDb.Dcms_GuestBook guestbook = new SqlDb.Dcms_GuestBook();
                    guestbook.GuestBook_AddTime = DateTime.Now;
                    UpdateModelByForm(guestbook, Request.Form);
                    session.Create(guestbook);
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
                //int newsid = IRequest.GetQueryInt("newsid", 0);
                int guestbookid = IRequest.GetFormInt("GuestBook_Id", 0);
                if (guestbookid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_GuestBook guestbook = new SqlDb.Dcms_GuestBook();
                        IQuery query = session.GetQuery(guestbook).Where(SqlDb.Dcms_GuestBook._GUESTBOOK_ID_.EqulesExp(guestbookid));
                        IList<SqlDb.Dcms_GuestBook> guestbooklist = query.GetList<SqlDb.Dcms_GuestBook>();
                        if (guestbooklist.Count > 0)
                        {
                            guestbook = guestbooklist[0];
                            UpdateModelByForm(guestbook, Request.Form);

                            session.Update(guestbook);
                            return "true";
                        }

                    }
                }
                return "false";
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
                    string Sql = "DELETE FROM [Dcms_GuestBook] WHERE [GuestBook_Id] IN(" + id + ")";
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
