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
namespace Manage.BaseInfo
{
    public partial class Manage_baseinfo_baseinfo_manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_BaseInfo baseinfo = new SqlDb.Dcms_BaseInfo();
                //创建查询
                if (keyword.Length > 0)
                {
                    baseinfo.BaseInfo_Title = keyword;
                }
                IQuery query = session.GetQuery(baseinfo);

                if (keyword.Length > 0)
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_BaseInfo._BASEINFO_TITLE_.Like('%', keyword, '%').AND(SqlDb.Dcms_BaseInfo._BASEINFO_CATEID_.EqulesExp(cateid)));
                    }
                    else
                    {
                        query.Where(SqlDb.Dcms_BaseInfo._BASEINFO_TITLE_.Like('%', keyword, '%'));
                    }
                }
                else
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_BaseInfo._BASEINFO_CATEID_.EqulesExp(cateid));
                    }
                }
                query.OrderBy(SqlDb.Dcms_BaseInfo._BASEINFO_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_BaseInfo> baseinfoList = query.GetList<SqlDb.Dcms_BaseInfo>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < baseinfoList.Count; i++)
                {
                    string state = (baseinfoList[i].BaseInfo_State == "1") ? "显示" : "关闭";
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", baseinfoList[i].BaseInfo_Id.ToString(), baseinfoList[i].BaseInfo_Id.ToString(), FormatJsonData(baseinfoList[i].BaseInfo_Title.ToString()), state, baseinfoList[i].BaseInfo_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == baseinfoList.Count)
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
                    string Sql = "select * from [Dcms_BaseInfo] where BaseInfo_Id=" + id;
                    DataTable baseinfoDt = session.GetTable(Sql);

                    if (baseinfoDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in baseinfoDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(baseinfoDt.Rows[0][column.ColumnName].ToString())));
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
                    SqlDb.Dcms_BaseInfo baseinfo = new SqlDb.Dcms_BaseInfo();
                    baseinfo.BaseInfo_AddTime = DateTime.Now;
                    UpdateModelByForm(baseinfo, Request.Form);
                 
                    session.Create(baseinfo);
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
                int baseinfoid = IRequest.GetFormInt("BaseInfo_Id", 0);
                if (baseinfoid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_BaseInfo baseinfo = new SqlDb.Dcms_BaseInfo();
                        baseinfo.BaseInfo_Id = baseinfoid;
                        IQuery query = session.GetQuery(baseinfo).Where(SqlDb.Dcms_BaseInfo._BASEINFO_ID_.EqulesExp());
                        IList<SqlDb.Dcms_BaseInfo> baseinfolist = query.GetList<SqlDb.Dcms_BaseInfo>();
                        if (baseinfolist.Count > 0)
                        {
                            baseinfo = baseinfolist[0];
                            UpdateModelByForm(baseinfo, Request.Form);
                            session.Update(baseinfo);
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
                    string Sql = "DELETE FROM [Dcms_BaseInfo] WHERE [BaseInfo_Id] IN(" + id + ")";
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
