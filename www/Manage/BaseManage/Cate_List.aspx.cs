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
    public partial class Manage_BaseManage_Cate_List : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = XmlHelper.GetXmlData(Utils.GetMapPath("../../sysconfig/Module.xml"), "root");
            DataTable dt = ds.Tables[1];
            StringBuilder sb = new StringBuilder();
            sb.Append("<select name=\"Cate_Module\" id=\"Cate_Module\" style=\"width:200px\">\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string model = Convert.ToString(dt.Rows[i]["model"]).ToLower();
                if(model=="introduction")
                {
                    model = "baseinfo";
                }
                if (model == "product")
                {
                    model = "products";
                }
                sb.Append(string.Format("<option value=\"{0}\" keyid=\"{1}\">{2}</option>\n", model, Convert.ToString(dt.Rows[i]["order"]), Convert.ToString(dt.Rows[i]["modelName"])));
            }
            sb.Append("</select>");
            lit_Module.Text = sb.ToString();
        }

    }
}
