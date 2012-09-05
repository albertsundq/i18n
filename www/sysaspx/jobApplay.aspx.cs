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

public partial class sysaspx_jobApplay : Dcms.BasePage.FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string successMessage = IRequest.GetFormString("successMessage");
        string successUrl = IRequest.GetFormString("successUrl");
        string errorMessage = IRequest.GetFormString("errorMessage");
        if ((IRequest.GetFormString("Js_RealName").Length <= 1) || (IRequest.GetFormString("Js_Tel").Length <= 1) || (IRequest.GetFormString("Js_Email").Length <= 1))
        {
            Jscript.AlertAndBack(errorMessage);
        }
        else
        {
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_JobSeeker jobSeeker = new SqlDb.Dcms_JobSeeker();
                    jobSeeker.Js_AddTime = DateTime.Now;
                    UpdateModelByForm(jobSeeker, Request.Form);
                    session.Create(jobSeeker);
                }
                Jscript.AlertAndRedirect(successMessage, successUrl);
            }
            catch
            {
                Jscript.AlertAndBack(errorMessage);
            }
        }
    }
}
