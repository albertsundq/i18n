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
using Dcms.Orm;
using Dcms.Utility;

namespace Manage.form
{
    public partial class Manage_form_form_list : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cateName = "数据库管理";
            this.Page.Title = cateName;
            this.lit_Title.Text = cateName;
            Cate_Id.Value = "0";
            Cate_Name.Value = cateName;
        }
    }
}
