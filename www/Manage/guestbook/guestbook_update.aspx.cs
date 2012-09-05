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

namespace Manage.guestbook
{
    public partial class Manage_guestbook_guestbook_update : Dcms.BasePage.ManagePage
    {
        protected string iframeid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            iframeid = IRequest.GetQueryString("iframeid");
            int CateId = IRequest.GetQueryInt("cateid", 0);
            int Id = IRequest.GetQueryInt("id", -1);
            string cateName = IRequest.GetQueryString("catename");
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
                        cateName = cateList[0].Cate_Title;
                        GuestBook_CateName.Value = cateName;
                        GuestBook_CateId.Value = CateId.ToString();
                        GuestBook_CateName.Value = cateName;
                    }
                }
            }
            if (Id == 0)
            {
                this.Page.Title = "新建" + cateName;
                this.lit_Title.Text = "新建" + cateName;
                GuestBook_Id.Value = "0";
            }
            else if (Id > 0)
            {

                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = Id.ToString();
                GuestBook_Id.Value = Id.ToString();
            }
            else
            {
                int thisId = 0;
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_GuestBook modle = new SqlDb.Dcms_GuestBook();
                    modle.GuestBook_CateId = CateId;
                    IQuery query = session.GetQuery(modle).Where(SqlDb.Dcms_GuestBook._GUESTBOOK_CATEID_.EqulesExp());
                    IList<SqlDb.Dcms_GuestBook> datalist = query.GetList<SqlDb.Dcms_GuestBook>();
                    if (datalist.Count > 0)
                    {
                        thisId = datalist[0].GuestBook_Id;
                    }
                }
                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = thisId.ToString();
                GuestBook_Id.Value = thisId.ToString();
            }
        }
    }
}
