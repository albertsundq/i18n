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

namespace Manage.products
{
    public partial class Manage_products_products_Manage : Dcms.BasePage.ManagePage
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
                SqlDb.Dcms_Products products = new SqlDb.Dcms_Products();
                //创建查询
                IQuery query = session.GetQuery(products);

                if (keyword.Length > 0)
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_Products._PRODUCTS_TITLE_.Like('%', keyword, '%').AND(SqlDb.Dcms_Products._PRODUCTS_CATEID_.EqulesExp(cateid)));
                    }
                    else
                    {
                        query.Where(SqlDb.Dcms_Products._PRODUCTS_TITLE_.Like('%', keyword, '%'));
                    }
                }
                else
                {
                    if (cateid > 0)
                    {
                        query.Where(SqlDb.Dcms_Products._PRODUCTS_CATEID_.EqulesExp(cateid));
                    }
                }
                query.OrderBy(SqlDb.Dcms_Products._PRODUCTS_ID_, Direction.DESC);
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_Products> productsList = query.GetList<SqlDb.Dcms_Products>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < productsList.Count; i++)
                {
                    string state = (productsList[i].Products_State == "1") ? "显示" : "关闭";
                    sb.Append("{");
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", productsList[i].Products_ID.ToString(), productsList[i].Products_ID.ToString(), FormatJsonData(productsList[i].Products_Title.ToString()), state, productsList[i].Products_AddTime.ToString("yyyy/MM/dd")));
                    if ((i + 1) == productsList.Count)
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
                    string Sql = "select * from [Dcms_Products] where Products_ID=" + id;
                    DataTable productsDt = session.GetTable(Sql);

                    if (productsDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in productsDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(productsDt.Rows[0][column.ColumnName].ToString())));
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
                    SqlDb.Dcms_Products products = new SqlDb.Dcms_Products();
                    products.Products_AddTime = DateTime.Now;
                    UpdateModelByForm(products, Request.Form);
                  
                    session.Create(products);
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
                int productsid = IRequest.GetFormInt("Products_ID", 0);
                if (productsid > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_Products products = new SqlDb.Dcms_Products();
                        IQuery query = session.GetQuery(products).Where(SqlDb.Dcms_Products._PRODUCTS_ID_.EqulesExp(productsid));
                        IList<SqlDb.Dcms_Products> productslist = query.GetList<SqlDb.Dcms_Products>();
                        if (productslist.Count > 0)
                        {
                            products = productslist[0];
                            UpdateModelByForm(products, Request.Form);
                           
                            session.Update(products);
                            
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
                    string Sql = "DELETE FROM [Dcms_Products] WHERE [Products_Id] IN(" + id + ")";
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

