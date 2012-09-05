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
using Dcms.Utility;
using System.IO;
using Dcms.Orm;
using System.Collections.Generic;
using System.Text;
namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Data_Manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //操作方式
                string action = IRequest.GetQueryString("action").ToLower();
                switch (action)
                {
                    case "getcatelangfrom":
                        Response.Clear();
                        Response.Write(getCateLangFrom());
                        break;
                    case "getcatelangto":
                        Response.Clear();
                        Response.Write(getCateLangTo());
                        break;
                    case "getcatefrom":
                        Response.Clear();
                        Response.Write(getCateFrom());
                        break;
                    case "getcateto":
                        Response.Clear();
                        Response.Write(getCateTo());
                        break;
                    case "getsomeshiftcateto":
                        Response.Clear();
                        Response.Write(getSomeShiftCateTo());
                        break;
                    case "shift":
                        Response.Clear();
                        Response.Write(shift());
                        break;
                    case "someshift":
                        Response.Clear();
                        Response.Write(doSomeShift());
                        break;
                    //case "delete":
                    //    Response.Clear();
                    //    Response.Write(doDelete());
                    //    break;
                }
            }
        }
        /// <summary>
        /// 取from文件目录
        /// </summary>
        /// <returns>json</returns>
        private string getCateLangFrom()
        {
            System.Text.StringBuilder secstr = new System.Text.StringBuilder();
            secstr.Append("<select id='CateLangFrom' name='CateLangFrom' onchange='getCateFrom()'>");
            string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
            String[] str = System.IO.Directory.GetDirectories(aspxpath);
            foreach (string pagestr in str)
            {
                secstr.Append(@"<option value='" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "'>" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "</option>");
            }
            secstr.Append("</select>");
            return secstr.ToString();
        }
        /// <summary>
        /// 取to文件目录
        /// </summary>
        /// <returns>json</returns>
        private string getCateLangTo()
        {
            System.Text.StringBuilder secstr = new System.Text.StringBuilder();
            secstr.Append("<select id='CateLangTo' name='CateLangTo' onchange='getCateTo()'>");
            string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
            String[] str = System.IO.Directory.GetDirectories(aspxpath);
            foreach (string pagestr in str)
            {
                secstr.Append(@"<option value='" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "'>" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "</option>");
            }
            secstr.Append("</select>");
            return secstr.ToString();
        }
        /// <summary>
        /// 取catefrom类别树
        /// </summary>
        /// <returns>json</returns>
        private string getCateFrom()
        {
           
            string treeStr = "";
            string catelang = IRequest.GetQueryString("catelang");
            if (catelang == string.Empty)
            {
                catelang = "cn";
            }
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {

                string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_HasChild from [Dcms_Cate] where Cate_Lang='"+catelang+"' order by [Cate_Order] asc";
                DataTable cateDt = session.GetTable(Sql);
                if (cateDt.Rows.Count > 0)
                {
                    parentSelectTree pTree = new parentSelectTree();
                    treeStr =pTree.CreateTree(cateDt);
                }
            }
            return treeStr;
        }
        /// <summary>
        /// 取cateto类别树
        /// </summary>
        /// <returns>json</returns>
        private string getCateTo()
        {
            string treeStr = "";
            string catelang = IRequest.GetQueryString("catelang");
            int catefrom = IRequest.GetQueryInt("catefrom", 0);

            if (catelang == string.Empty)
            {
                catelang = "cn";
            }
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string fromSql = "select  Cate_Module from [dcms_cate] where cate_id=" + catefrom;
                DataTable fromDt = session.GetTable(fromSql);
                string Sql = "";
                if (fromDt.Rows.Count > 0)
                {
                    Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_HasChild from [Dcms_Cate] where Cate_Lang='" + catelang + "' and cate_module='" + fromDt.Rows[0]["Cate_Module"].ToString() + "' order by [Cate_Order] asc";

                }
                else
                {
                    Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_HasChild from [Dcms_Cate] where Cate_Lang='" + catelang + "' order by [Cate_Order] asc";
                }
                DataTable cateDt = session.GetTable(Sql);
                if (cateDt.Rows.Count > 0)
                {
                    parentSelectTree pTree = new parentSelectTree();
                    treeStr = pTree.CreateTree(cateDt);
                }
            }
            return treeStr;
        }
        /// <summary>
        /// 取批量转移cateto类别树
        /// </summary>
        /// <returns>json</returns>
        private string getSomeShiftCateTo()
        {
            //string treeStr = "";
          //  string catelang = IRequest.GetQueryString("catelang");
           // string moduleflag = IRequest.GetQueryString("moduleflag");


            //using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            //{
               
            //    string  Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_HasChild from [Dcms_Cate] where Cate_Lang='" + catelang + "' order by [Cate_Order] asc";
           
            //    DataTable cateDt = session.GetTable(Sql);
            //    if (cateDt.Rows.Count > 0)
            //    {
            //        parentSelectTree pTree = new parentSelectTree();
            //        treeStr = pTree.CreateTree(cateDt);
            //    }
            //}
            //return treeStr;
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string moduleflag = IRequest.GetQueryString("moduleflag");
                string sql = "";
                DataTable catedt = null;
                StringBuilder sb = new StringBuilder();
                sb.Append("<select id='Cate_ParentId'>");
               
                    string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
                    String[] str = System.IO.Directory.GetDirectories(aspxpath);
                    foreach (string pagestr in str)
                    {
                        string CateLang = string.Empty;
                        CateLang = pagestr.Substring(pagestr.LastIndexOf('\\') + 1).ToUpper();
                        sb.Append("<option value='");
                        sb.Append(CateLang + "'>--" + CateLang + "--</option>");
                        sql = "select cate_id,cate_title from dcms_cate where cate_lang='" + CateLang + "'and cate_module='"+moduleflag+"' order by cate_order asc";
                        catedt = session.GetTable(sql);
                        if (catedt.Rows.Count > 0)
                        {
                            for(int i=0;i<catedt.Rows.Count;i++)
                            {
                                sb.Append("<option value='" + Convert.ToString(catedt.Rows[i]["cate_id"]) + "'>" + Convert.ToString(catedt.Rows[i]["cate_title"]) + "</option>");
                            }
                        }
                        
                    }
                sb.Append("</select>");
                catedt.Dispose();
                return sb.ToString();
            }
        }
        /// <summary>
        /// 转移数据
        /// </summary>
        /// <returns></returns>
        /// <summary>
        private string doSomeShift()
        {
            string idstr = IRequest.GetFormString("id");
            string cateto = IRequest.GetFormString("cateto");
            string isdelete = IRequest.GetFormString("isdelete");
            string moduleflag = IRequest.GetFormString("moduleflag");
            string catetoname = IRequest.GetFormString("catetoname");
            //return idstr+"cateto:" + cateto.ToString() + "isdelete:" + isdelete+"catetoname="+catetoname+"modulef:"+moduleflag;
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                try
                {
                    session.BeginTrans();
                    string[] catefromid = idstr.Split(',');
                    DataTable catefromdt = null;
                    string catefromsql = string.Empty;
                    string columns =string.Empty;
                    string maxtoid = string.Empty;//插入后取最大值编号
                  //  string upstr = string.Empty;

                    
                    for (int i = 1; i < catefromid.Length; i++)
                    {
                      
                        //if (moduleflag.Equals("products"))
                       // {
                            catefromsql = "select * from dcms_"+moduleflag+" where "+moduleflag+"_id=" + catefromid[i];
                            catefromdt = session.GetTable(catefromsql);
                           
                            for (int j = 1; j < catefromdt.Columns.Count; j++)
                            {
                                columns += catefromdt.Columns[j].ColumnName + ",";
                            }
                            columns = columns.Substring(0, columns.LastIndexOf(','));
                            session.simple("insert into [dcms_" + moduleflag + "] (" + columns + ") select " + columns + " from [dcms_" + moduleflag + "] where " + moduleflag + "_id=" + catefromid[i]);
                            maxtoid = session.ExecuteScalar("select Max(" + moduleflag + "_id) from [dcms_" + moduleflag + "]");
                            string upstr = "update [dcms_" + moduleflag + "] set " + moduleflag + "_CateName=" + "'" + catetoname + "'" + "," + moduleflag + "_cateid=" + cateto + " where " + moduleflag + "_id=" + maxtoid;
                            session.simple(upstr);
                            
                            if (isdelete == "1")//转移内容后删除原来内容
                            {
                                session.simple("delete from [dcms_" + moduleflag + "] where " + moduleflag + "_id=" + catefromid[i]);
                            }
                            columns = string.Empty;
                        }
                    //s}
                    
                    session.CommitTrans();
                    return "转移成功！";
                }
                catch
                {
                    session.RollbackTrans();
                    return "转移失败！";
                }
            }
        }

        /// 转移数据
        /// </summary>
        /// <returns></returns>
        private string shift()
        {
            string shiftway=IRequest.GetFormString("ShiftWay");
            string catelangfrom = IRequest.GetFormString("CateLangFrom");
            string catelangto = IRequest.GetFormString("CateLangTo");
            int catefrom =IRequest.GetFormInt("CateFrom", 0);
            int cateto = IRequest.GetFormInt("CateTo",0);
            string shifttype = IRequest.GetFormString("ShiftType");
            string isdelete = IRequest.GetFormString("IsDelete");
            string catelang = IRequest.GetFormString("catelang");
            string catetoname=IRequest.GetFormString("CateToName");
         
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                try
                {

                    if (shiftway == "0")//版本转移
                    {
                        session.BeginTrans();
                        string Sql = "select * from [Dcms_Cate] where Cate_Lang='" + catelangfrom + "' order by [Cate_Id] asc";
                        DataTable cateFromDt = session.GetTable(Sql);

                        if (cateFromDt.Rows.Count > 0)
                        {
                            SqlDb.Dcms_Cate cate = new SqlDb.Dcms_Cate();
                            Dictionary<int, int> dic = new Dictionary<int, int>();
                            session.Create(cate);//先插入一条获取max cateid
                            int maxcateid = session.ExecuteCount("select Max(Cate_Id) from [Dcms_Cate]", cate);
                            session.simple("delete from [Dcms_Cate] where Cate_Id='" + maxcateid.ToString() + "'");
                            foreach (DataRow dr in cateFromDt.Rows)
                            {
                                if (shifttype.Equals("All"))//如果是转移栏目和内容
                                {
                                    UpdateModelByDt(cate, dr);
                                    if (session.ExecuteCount("select Max(Cate_Id) from [Dcms_Cate]", cate) < maxcateid)
                                    {
                                        dic.Add(Convert.ToInt32(dr["Cate_Id"].ToString()), maxcateid + 1);
                                    }
                                    else
                                    {
                                        dic.Add(Convert.ToInt32(dr["Cate_Id"].ToString()), session.ExecuteCount("select Max(Cate_Id) from [Dcms_Cate]", cate) + 1);
                                    }
                                    cate.Cate_Lang = catelangto;
                                    cate.Cate_IdPath = ",0,";
                                    foreach (KeyValuePair<int, int> kv in dic)
                                    {
                                        foreach (string key in dr["Cate_IdPath"].ToString().Split(new char[] { ',' }))
                                        {
                                            if (kv.Key.ToString().Equals(key))
                                            {
                                                cate.Cate_IdPath = cate.Cate_IdPath + kv.Value.ToString() + ",";
                                            }
                                        }
                                        if (int.Parse(dr["Cate_ParentID"].ToString()) == kv.Key)
                                        {
                                            cate.Cate_ParentID = kv.Value;
                                        }
                                    }
                                    session.Create(cate);//插入栏目

                                    string csql = "select * from [dcms_" + dr["Cate_Module"].ToString() + "] where " + dr["Cate_Module"].ToString() + "_cateid=" + dr["Cate_Id"].ToString() + " order by [" + dr["Cate_Module"].ToString() + "_id] asc";
                                    DataTable contentFromDt = session.GetTable(csql);
                                    if (contentFromDt.Rows.Count > 0)
                                    {
                                        Dictionary<int, int> cdic = new Dictionary<int, int>();
                                        session.simple("insert into [dcms_" + dr["Cate_Module"].ToString() + "] (" + dr["Cate_Module"].ToString() + "_cateid) values(0)");
                                        int maxcid = Convert.ToInt32(session.ExecuteScalar("select Max(" + dr["Cate_Module"].ToString() + "_id) from [dcms_" + dr["Cate_Module"].ToString() + "]"));
                                        session.simple("delete from [Dcms_" + dr["Cate_Module"].ToString() + "] where " + dr["Cate_Module"].ToString() + "_Id='" + maxcid.ToString() + "'");
                                        foreach (DataRow cdr in contentFromDt.Rows)
                                        {
                                            if (Convert.ToInt32(session.ExecuteScalar("select Max(" + dr["Cate_Module"].ToString() + "_id) from [dcms_" + dr["Cate_Module"].ToString() + "]")) < maxcid)
                                            {
                                                cdic.Add(Convert.ToInt32(cdr[dr["Cate_Module"].ToString() + "_id"].ToString()), maxcid + 1);
                                            }
                                            else
                                            {
                                                cdic.Add(Convert.ToInt32(cdr[dr["Cate_Module"].ToString() + "_id"].ToString()), Convert.ToInt32(session.ExecuteScalar("select Max(" + dr["Cate_Module"].ToString() + "_id) from [dcms_" + dr["Cate_Module"].ToString() + "]")) + 1);
                                            }
                                            string columns = "";
                                            for (int i = 1; i < contentFromDt.Columns.Count; i++)
                                            {
                                                columns += contentFromDt.Columns[i].ColumnName + ",";
                                            }
                                            columns = columns.Substring(0, columns.LastIndexOf(','));
                                            session.simple("insert into [dcms_" + dr["Cate_Module"].ToString() + "] (" + columns + ") select " + columns + " from [dcms_" + dr["Cate_Module"].ToString() + "] where " + dr["Cate_Module"].ToString() + "_id=" + cdr[dr["Cate_Module"].ToString() + "_id"].ToString());
                                            session.simple("update [dcms_" + dr["Cate_Module"].ToString() + "] set " + dr["Cate_Module"].ToString() + "_cateid=" + dic[Convert.ToInt32(dr["Cate_Id"].ToString())].ToString() + " where " + dr["Cate_Module"].ToString() + "_id=" + cdic[Convert.ToInt32(cdr[dr["Cate_Module"].ToString() + "_id"].ToString())].ToString());
                                        }

                                    }
                                }
                                if (shifttype.Equals("Channel"))//如果是只转移栏目
                                {
                                    UpdateModelByDt(cate, dr);
                                    if (session.ExecuteCount("select Max(Cate_Id) from [Dcms_Cate]", cate) < maxcateid)
                                    {
                                        dic.Add(Convert.ToInt32(dr["Cate_Id"].ToString()), maxcateid + 1);
                                    }
                                    else
                                    {
                                        dic.Add(Convert.ToInt32(dr["Cate_Id"].ToString()), session.ExecuteCount("select Max(Cate_Id) from [Dcms_Cate]", cate) + 1);
                                    }
                                    cate.Cate_Lang = catelangto;
                                    cate.Cate_IdPath = ",0,";
                                    foreach (KeyValuePair<int, int> kv in dic)
                                    {
                                        foreach (string key in dr["Cate_IdPath"].ToString().Split(new char[] { ',' }))
                                        {
                                            if (kv.Key.ToString().Equals(key))
                                            {
                                                cate.Cate_IdPath = cate.Cate_IdPath + kv.Value.ToString() + ",";
                                            }
                                        }
                                        if (int.Parse(dr["Cate_ParentID"].ToString()) == kv.Key)
                                        {
                                            cate.Cate_ParentID = kv.Value;
                                        }
                                    }
                                    session.Create(cate);//插入栏目
                                }

                            }
                        }
                        

                    }
                    if (shiftway == "1")//栏目转移下只转移内容
                    {
                        session.BeginTrans();
                        string Sql = "select * from [Dcms_Cate] where Cate_Id='" + catefrom + "' order by [Cate_Id] asc";
                        DataTable cateFromDt = session.GetTable(Sql);
                        string moduleStr = cateFromDt.Rows[0]["Cate_Module"].ToString();

                        string csql = "select * from [dcms_" + moduleStr + "] where " + moduleStr + "_cateid=" + cateFromDt.Rows[0]["Cate_Id"].ToString() + " order by [" + moduleStr + "_id] asc";
                        DataTable contentFromDt = session.GetTable(csql);
                       
                        if (contentFromDt.Rows.Count > 0)
                        {
                            Dictionary<int, int> cdic = new Dictionary<int, int>();
                            session.simple("insert into [dcms_" + moduleStr + "] (" + moduleStr + "_cateid) values(0)");
                            int maxcid = Convert.ToInt32(session.ExecuteScalar("select Max(" + moduleStr + "_id) from [dcms_" + moduleStr + "]"));
                            session.simple("delete from [Dcms_" + moduleStr + "] where " + moduleStr + "_Id='" + maxcid.ToString() + "'");
                            foreach (DataRow cdr in contentFromDt.Rows)
                            {
                                if (Convert.ToInt32(session.ExecuteScalar("select Max(" + moduleStr + "_id) from [dcms_" + moduleStr + "]")) < maxcid)
                                {
                                    cdic.Add(Convert.ToInt32(cdr[moduleStr + "_id"].ToString()), maxcid + 1);
                                }
                                else
                                {
                                    cdic.Add(Convert.ToInt32(cdr[moduleStr + "_id"].ToString()), Convert.ToInt32(session.ExecuteScalar("select Max(" + moduleStr + "_id) from [dcms_" + moduleStr + "]")) + 1);
                                }
                                string columns = "";
                                for (int i = 1; i < contentFromDt.Columns.Count; i++)
                                {
                                    columns += contentFromDt.Columns[i].ColumnName + ",";
                                }
                                columns = columns.Substring(0, columns.LastIndexOf(','));
                                session.simple("insert into [dcms_" + moduleStr + "] (" + columns + ") select " + columns + " from [dcms_" + moduleStr + "] where " + moduleStr + "_id=" + cdr[moduleStr + "_id"].ToString());
                                string upstr = "update [dcms_" + moduleStr + "] set " + moduleStr + "_CateName=" + "'" + catetoname + "'" + "," + moduleStr + "_cateid=" + cateto + " where " + moduleStr + "_id=" + cdic[Convert.ToInt32(cdr[moduleStr + "_id"].ToString())].ToString();
                                session.simple(upstr);
                               // session.simple("update [dcms_" + moduleStr + "] set " +moduleStr+"_CateName=" + catetoname + "," + moduleStr + "_cateid=" + cateto + " where " + moduleStr + "_id=" + cdic[Convert.ToInt32(cdr[moduleStr + "_id"].ToString())].ToString());
                                if (isdelete == "1")//转移内容后删除原来内容
                                {
                                    session.simple("delete from [dcms_" + moduleStr + "] where " + moduleStr + "_id=" + cdr[moduleStr + "_id"].ToString());
                                }
                            }

                        }
                    }
                    session.CommitTrans();
                    return "转移成功！";
                    
                    
                }
                catch
                {
                    session.RollbackTrans();
                    return "转移失败！";
                    
                   
                }
            }
        }

        private void UpdateModelByDt(object model, DataRow dr)
        {
            System.Reflection.PropertyInfo[] arrProperty = model.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in arrProperty)
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    string colName = dr.Table.Columns[i].ColumnName;
                    if ((colName.Length > 0))// && (Convert.ToString(dr[i]).Length > 0)
                    {
                        if (string.Compare(colName, property.Name, true) == 0)
                        {
                            //数据转化
                            switch (property.PropertyType.ToString())
                            {
                                case "System.DateTime":
                                    property.SetValue(model, Convert.ToDateTime(dr[i]), null);
                                    break;
                                case "System.Int32":
                                    property.SetValue(model, Utils.StrToInt(dr[i], 0), null);
                                    break;
                                default:
                                    property.SetValue(model, Convert.ToString(dr[i]), null);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
     