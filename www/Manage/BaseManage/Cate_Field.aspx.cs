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
using System.Text;
using Dcms.Orm;
using Dcms.Utility;
namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Cate_Field : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string treeStr = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
                String[] str = System.IO.Directory.GetDirectories(aspxpath);
                foreach (string pagestr in str)
                {
                    string CateLang = string.Empty;
                    CateLang = pagestr.Substring(pagestr.LastIndexOf('\\') + 1).ToUpper();
                    string Sql = "select * from [Dcms_Cate] where Cate_Lang='" + CateLang + "' order by [Cate_Order] asc";
                    DataTable cateDt = session.GetTable(Sql);
                    if (cateDt.Rows.Count > 0)
                    {
                        CateField Tree = new CateField();
                        treeStr = treeStr + Tree.CreateTree(cateDt, "<tr class=\"trlinetitlebg\"><td><strong>" + CateLang + "版本</strong></td><td>&nbsp;</td><td>版本标识</td><td>分类ID</td><td>分类标识</td><td>功能模块</td><td>&nbsp;</td></tr>\n");
                    }
                }
            }
            lit_cateTree.Text = treeStr;
        }
    }
}
