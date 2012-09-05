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

namespace Manage.position
{
    public partial class Manage_position_position_update : Dcms.BasePage.ManagePage
    {
        protected string iframeid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            iframeid = IRequest.GetQueryString("iframeid");
            int CateId = IRequest.GetQueryInt("cateid", 0);
            int Id = IRequest.GetQueryInt("id", -1);
            string cateName = IRequest.GetQueryString("catename");
            if (Id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_UserLevel userlevel = new SqlDb.Dcms_UserLevel();
                    userlevel.UserLevel_Id = Id;
                    IQuery query = session.GetQuery(userlevel).Where(SqlDb.Dcms_UserLevel._USERLEVEL_ID_.EqulesExp());
                    List<SqlDb.Dcms_UserLevel> userlevelList = query.GetList<SqlDb.Dcms_UserLevel>();
                    if (userlevelList.Count > 0)
                    {
                        cateName = userlevelList[0].UserLevel_Title;
                    }
                }
            }
            if (Id == 0)
            {
                this.Page.Title = "新建" + cateName;
                this.lit_Title.Text = "新建" + cateName;
                UserLevel_Id.Value = "0";
            }
            else if (Id > 0)
            {

                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = Id.ToString();
                UserLevel_Id.Value = Id.ToString();
            }
            else
            {
                int thisId = 0;
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_UserLevel userlevel = new SqlDb.Dcms_UserLevel();
                    userlevel.UserLevel_Id = Id;
                    IQuery query = session.GetQuery(userlevel).Where(SqlDb.Dcms_UserLevel._USERLEVEL_ID_.EqulesExp());
                    List<SqlDb.Dcms_UserLevel> userlevelList = query.GetList<SqlDb.Dcms_UserLevel>();
                    if (userlevelList.Count > 0)
                    {
                        thisId = userlevelList[0].UserLevel_Id;
                    }
                }
                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = thisId.ToString();
                UserLevel_Id.Value = thisId.ToString();
            }
        }
    }
}
