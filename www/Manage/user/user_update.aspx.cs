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

namespace Manage.user
{
    public partial class Manage_user_user_update : Dcms.BasePage.ManagePage
    {
        protected string iframeid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            iframeid = IRequest.GetQueryString("iframeid");
            int CateId = IRequest.GetQueryInt("cateid", 0);
            int Id = IRequest.GetQueryInt("id", -1);
            string cateName = IRequest.GetQueryString("catename");
            StringBuilder sb = new StringBuilder();
            sb.Append("<select name=\"User_LevelKey\" id=\"User_LevelKey\" style=\"width:200px\">\n");
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_UserLevel userlevel = new SqlDb.Dcms_UserLevel();
                IQuery query = session.GetQuery(userlevel);
                List<SqlDb.Dcms_UserLevel> userlevelList = query.GetList<SqlDb.Dcms_UserLevel>();
                for (int i = 0; i < userlevelList.Count; i++)
                {
                    sb.Append(string.Format("<option value=\"{0}\">{1}</option>\n", Convert.ToString(userlevelList[i].UserLevel_Key), Convert.ToString(userlevelList[i].UserLevel_Title)));
                }

            }
            sb.Append("</select>");
            lit_UserLevel.Text = sb.ToString();
            if (Id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                    user.User_Id = Id;
                    IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_ID_.EqulesExp());
                    List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>();
                    if (userList.Count > 0)
                    {
                        cateName = userList[0].User_Name;
                    }
                }
            }
            if (Id == 0)
            {
                this.Page.Title = "新建" + cateName;
                this.lit_Title.Text = "新建" + cateName;
                User_Id.Value = "0";
            }
            else if (Id > 0)
            {

                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = Id.ToString();
                User_Id.Value = Id.ToString();
            }
            else
            {
                int thisId = 0;
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_User user = new SqlDb.Dcms_User();
                    user.User_Id = Id;
                    IQuery query = session.GetQuery(user).Where(SqlDb.Dcms_User._USER_ID_.EqulesExp());
                    List<SqlDb.Dcms_User> userList = query.GetList<SqlDb.Dcms_User>();
                    if (userList.Count > 0)
                    {
                        thisId = userList[0].User_Id;
                    }
                }
                this.Page.Title = "编辑" + cateName;
                this.lit_Title.Text = "编辑" + cateName;
                lit_id.Text = thisId.ToString();
                User_Id.Value = thisId.ToString();
            }
        }
    }
}
