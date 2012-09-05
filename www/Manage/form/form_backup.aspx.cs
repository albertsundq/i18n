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
using System.IO;
namespace Manage.form
{

    public partial class Manage_form_form_backup : Dcms.BasePage.ManagePage
    {
        protected string iframeid = "";
        protected string litbakname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            iframeid = IRequest.GetQueryString("iframeid");
            if (GetDbType().ToLower() == "dcsqlite")
            {
                litbakname = DateTime.Now.ToShortDateString().Replace("-", "") + ".db";
            }
            else
            {
                litbakname =DateTime.Now.ToShortDateString().Replace("-", "") + ".bak";
            }
        }
        ///<summary>
        ///获取数据库类型
        ///</summary>
        ///<param name="qdbtype"></param>
        ///<return>string</return>
        private string GetDbType()
        {
            
                DataBaseSection sec = (DataBaseSection)ConfigurationManager.GetSection("Dcms.Orm/DataBase");
                string dbtype = "";
                foreach (ConnectionItem item in sec.Items)
                {
                    dbtype = item.dbtype;
                    return dbtype;
                }
                return "SqlServer2000";
        }
    }
}
