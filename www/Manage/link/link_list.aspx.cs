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

namespace Manage.Link
{
    public partial class Manage_link_link_list : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CateId = IRequest.GetQueryInt("CateId", 0);
            if (CateId > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Cate cate = new SqlDb.Dcms_Cate();
                    cate.Cate_Id = CateId;
                    IQuery query = session.GetQuery(cate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp());
                    List<SqlDb.Dcms_Cate> cateList = query.GetList<SqlDb.Dcms_Cate>();
                    if (cateList.Count > 0)
                    {
                        string cateName = cateList[0].Cate_Title;
                        this.Page.Title = cateName;
                        this.lit_Title.Text = cateName;
                        Cate_Id.Value = CateId.ToString();
                        Cate_Name.Value = cateName;
                    }
                }
            }
        }
    }
}
