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
namespace Manage.TemplatePath
{
    public partial class Manage_TemplatePath_TemplatePath_Update : Dcms.BasePage.ManagePage
    {
        protected string iframeid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            iframeid = IRequest.GetQueryString("iframeid");
            int Id = IRequest.GetQueryInt("id", -1);
            langflag.Value= IRequest.GetQueryString("langflag");
           
            if (Id == 0)
            {
                this.Page.Title = "新建模板文件";
                this.lit_Title.Text = "新建模板文件";
                
            }
            else if (Id > 0)
            {
                string filename = IRequest.GetQueryString("filename");
                this.Page.Title = "编辑" + filename;
                this.lit_Title.Text = "编辑" + filename;
                lit_filename.Text =filename;
                
            }
           
              
            
        }
    }
}