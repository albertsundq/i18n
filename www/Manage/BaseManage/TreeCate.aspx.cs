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
    public partial class Manage_BaseManage_TreeCate : Dcms.BasePage.ManagePage
    {
        private StringBuilder divsb = new StringBuilder();
        private int TreeCount = 0;
        DataTable TreeDt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
             //操作方式
            string action = IRequest.GetQueryString("action").ToLower();
            //Response.Write(getTreeCate(Dcms.BasePage.ManagePage.mfroleid, Dcms.BasePage.ManagePage.mflangflag));
            getTreeCate(Dcms.BasePage.ManagePage.mfroleid, Dcms.BasePage.ManagePage.mflangflag);
        }
        private void getTreeCate(int roleId, string langFlag)
        {
            divsb.AppendLine("<div class='dtree'>");

            divsb.AppendLine("<script type='text/javascript'>");
            divsb.AppendLine("//<!--");
           // divsb.AppendLine("function excTreeCate(){");
            divsb.AppendLine("window.dtree = new dTree('dtree');");


            divsb.AppendLine("window.dtree.add(0,-1,'栏目管理','#');");
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                if (roleId == 0)
                {
                    string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_HasChild,Cate_ManageUrl,Cate_ParentID,Cate_ModelKeyId,Cate_IsMenu from Dcms_Cate where Cate_Lang='" + langFlag + "' order by Cate_Order asc";
                    TreeDt = session.GetTable(Sql);
                    if (TreeDt != null)
                    {

                        forTree(0, 0);

                    }
                }
                else
                {
                    string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_ModelKeyId,Cate_IsMenu from Dcms_Cate where Cate_Id in (select Permissions_CateId from Dcms_Permissions where Cate_Lang='" + langFlag + "' and Permissions_Select=1 and Permissions_RoleId=" + roleId + ") order by Cate_Order asc";
                    TreeDt = session.GetTable(Sql);
                    if (TreeDt != null)
                    {

                        forTree(0, 0);

                    }
                }
            }
            //divsb.AppendLine("d.add(100,-1,'系统管理','#');");
            //divsb.AppendLine("document.write(window.d);");
            //divsb.AppendLine("alert('hellowold')");
            //divsb.AppendLine(" d.openAll();");
            //divsb.AppendLine("}");
            //divsb.AppendLine("excTreeCate();");
            divsb.AppendLine("//-->");
            divsb.AppendLine("</script>");
            divsb.AppendLine("</div>");
            //return divsb.ToString();
            this.litMenu.Text = divsb.ToString();
        }
        /// <summary>
        /// 递归添加树节点
        /// </summary>
        private void forTree(int ParentID, int TreeParent)
        {
            foreach (DataRow dr in TreeDt.Rows)
            {

                if (dr["Cate_ParentID"].ToString() == ParentID.ToString())
                {
                    
                    TreeCount = TreeCount + 1;
                    if (dr["Cate_IsMenu"].ToString().Equals("0"))
                    {
                        divsb.AppendLine("window.dtree.add(" + TreeCount + "," + TreeParent + ",\"" + dr["Cate_Title"].ToString() + "\",\"" + "" + "\");");
                    }
                    else
                    {
                        string url = "'../" + dr["Cate_Module"] + "/" + dr["Cate_ModelKeyId"] + dr["Cate_ManageUrl"] + "?action=select&PermCateId=" + dr["Cate_Id"].ToString() + "&CateId=" + dr["Cate_Id"].ToString() + "'";
                        //BUG修复--后台树形管理有'会使得点击栏目没反应
                        url = "javascript:getLeftTreeCate(" + url + ",'" + dr["Cate_Id"] + "'" + ",'" + dr["Cate_Title"].ToString().Replace("'", "") + "')";
                        //
                        divsb.AppendLine("window.dtree.add(" + TreeCount + "," + TreeParent + ",\"" + dr["Cate_Title"].ToString() + "\",\"" + url + "\");");
                    }

                    forTree(int.Parse(dr["Cate_ID"].ToString()), TreeCount);
                    //}
                }

            }
            return;
        }
    }
}
