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

namespace Manage.news
{
    public partial class Manage_news_news_manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_News news = new SqlDb.Dcms_News();
                //创建查询
                if (keyword.Length > 0)
                {
                    news.News_Title = keyword;
                }
                IQuery query = session.GetQuery(news);

                if (keyword.Length > 0)
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_News._NEWS_TITLE_.Like('%', keyword, '%').AND(SqlDb.Dcms_News._NEWS_CATEID_.EqulesExp(cateid)));
                    }
                    else
                    {
                        query.Where(SqlDb.Dcms_News._NEWS_TITLE_.Like('%', keyword, '%'));
                    }
                }
                else
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_News._NEWS_CATEID_.EqulesExp(cateid));
                    }
                }
                query.OrderBy(SqlDb.Dcms_News._NEWS_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_News> newsList = query.GetList<SqlDb.Dcms_News>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < newsList.Count; i++)
                {
                    string state = (newsList[i].News_State == "1") ? "显示" : "关闭";
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", newsList[i].News_Id.ToString(), newsList[i].News_Id.ToString(), FormatJsonData(newsList[i].News_Title.ToString()), state, newsList[i].News_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == newsList.Count)
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
        /// 插入一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsert()
        {
            //try
            //{
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_News news = new SqlDb.Dcms_News();
                    news.News_AddTime = DateTime.Now;
                    UpdateModelByForm(news, Request.Form);
                  
                    session.Create(news);
                    return "true";
                }
                
            //}
            //catch
            //{
            //    return "false";
            //}
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
                    string Sql = "select * from [Dcms_News] where News_Id=" + id;
                    DataTable newsDt = session.GetTable(Sql);

                    if (newsDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in newsDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(newsDt.Rows[0][column.ColumnName].ToString())));
                        }
                    }
                }
            }
            return sb.ToString().TrimEnd(new char[] { ',' }) + "}]";
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
                int newsid = IRequest.GetFormInt("News_Id", 0);
                if (newsid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_News news = new SqlDb.Dcms_News();
                        IQuery query = session.GetQuery(news).Where(SqlDb.Dcms_News._NEWS_ID_.EqulesExp(newsid));
                        IList<SqlDb.Dcms_News> newslist = query.GetList<SqlDb.Dcms_News>();
                        if (newslist.Count > 0)
                        {
                            news = newslist[0];
                            UpdateModelByForm(news, Request.Form);
                      
                            session.Update(news);
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
                    string Sql = "DELETE FROM [Dcms_News] WHERE [News_Id] IN(" + id + ")";
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

