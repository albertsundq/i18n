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

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Admin_List : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_Role role = new SqlDb.Dcms_Role();
                IQuery query = session.GetQuery(role).OrderBy(SqlDb.Dcms_Role._ROLE_ORDER_, Direction.ASC);
                Admin_RoleId.DataSource = query.GetList<SqlDb.Dcms_Role>();
                Admin_RoleId.DataTextField = "Role_Name";
                Admin_RoleId.DataValueField = "Role_Id";
                Admin_RoleId.DataBind();
            }
        }
    }
}
