using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Xml;
namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Cate_Manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //操作方式
            string action = IRequest.GetQueryString("action").ToLower();
            switch (action)
            {
                case "select":
                    Response.Clear();
                    Response.Write(doSelect());
                    break;
                case "insert":
                    Response.Clear();
                    Response.Write(doInsert());
                    break;
                case "getone":
                    Response.Clear();
                    Response.Write(doGetOne());
                    break;
                case "update":
                    Response.Clear();
                    Response.Write(doUpdate());
                    break;
                case "delete":
                    Response.Clear();
                    Response.Write(doDelete());
                    break;
                case "getpy":
                    string hanzi = IRequest.GetQueryString("hanzi");
                    Response.Clear();
                    Response.Write(GetPYString(hanzi));
                    break;
                case "testdata":
                    Response.Clear();
                    Response.Write(testData());
                    break;
                case "cleartestdata":
                    Response.Clear();
                    Response.Write(clearTestData());
                    break;
            }
        }
        /// <summary>
        /// 批量删除操作
        /// </summary>
        /// <returns></returns>
        private string doDelete()
        {
            try
            {
                int id = IRequest.GetQueryInt("id", 0);
                
                if (id > 0)
                {
                    using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                    {
                        SqlDb.Dcms_Cate Cate = new SqlDb.Dcms_Cate();
                        IQuery query = session.GetQuery(Cate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp(id));
                        List<SqlDb.Dcms_Cate> cateList = query.GetList<SqlDb.Dcms_Cate>();
                        if (cateList.Count > 0)
                        {
			    if (cateList[0].Cate_ParentID == 0 && adminInfo.Admin_Id != 1)
                            {
                                return "no";
                            }
                            string Sql = "DELETE FROM [Dcms_Cate] WHERE [Cate_Id] =" + id.ToString() + "";
                            session.simple(Sql);
                            //同时删除子一级
                            if (cateList[0].Cate_HasChild > 0)
                            {
                                //string Sql2 = "DELETE FROM [Dcms_Cate] WHERE [Cate_ParentID] =" + id.ToString() + "";
                                string Sql2 = "Delete From [Dcms_Cate] where Cate_IdPath like '%," + id.ToString() + ",%'";
                                session.simple(Sql2);
                            }
                            //更新父级的部分数据
                            int pId = cateList[0].Cate_ParentID;
                            string pSql = "select [Cate_Id] from [Dcms_Cate] where [Cate_ParentID]=" + pId.ToString();
                            DataTable dt = session.GetTable(pSql);
                            if (dt.Rows.Count <= 0)
                            {
                                session.simple("update [Dcms_Cate] set [Cate_HasChild]=0 where [Cate_Id]=" + pId.ToString());
                            }
                        }
                    }
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }

        /// <summary>
        /// 取单条编辑数据
        /// </summary>
        /// <returns>json</returns>
        private string doGetOne()
        {
            int id = IRequest.GetQueryInt("id", 0);
         //   string oneRecord = "";
            StringBuilder sb = new StringBuilder();
            if (id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    string Sql = "select * from [Dcms_Cate] where Cate_Id=" + id;
                    DataTable cateDt = session.GetTable(Sql);

                    if (cateDt.Rows.Count > 0)
                    {
                        sb.Append("[{");
                        foreach (DataColumn column in cateDt.Columns)
                        {
                            sb.Append(string.Format("\"{0}\":\"{1}\",", column.ColumnName, FormatJsonData(cateDt.Rows[0][column.ColumnName].ToString())));
                        }
                    }
                }
            }
            return sb.ToString().TrimEnd(new char[] { ',' }) + "}]";
        }

        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doUpdate()
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                try
                {
                    string newcatetitle = IRequest.GetFormString("Cate_Title");
                    string oldercatetitle = string.Empty;
                    string cateid = IRequest.GetFormString("Cate_Id");
                    string catemodule = IRequest.GetFormString("Cate_Module");
                    int id = IRequest.GetFormInt("Cate_Id", 0);
                    if (id > 0)
                    {
                        session.BeginTrans();
                        int cateParentId = IRequest.GetFormInt("Cate_ParentID", 0);
                        int olderParentId = 0;
                        SqlDb.Dcms_Cate cate = new SqlDb.Dcms_Cate();
                        IQuery query = session.GetQuery(cate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp(id));
                        List<SqlDb.Dcms_Cate> cateList = query.GetList<SqlDb.Dcms_Cate>();
                        if (cateList.Count > 0)
                        {
                            cate = cateList[0];
                            olderParentId = cate.Cate_ParentID;
                            oldercatetitle = cate.Cate_Title;
                            string Cate_str_idpath = cate.Cate_IdPath;
                            string catenewidpath = cate.Cate_IdPath;
                           
                            if (cate.Cate_ParentID != cateParentId)//父栏目改变,修改当前新的父栏目
                            {
                                
                                if (cateParentId == 0)//如果新的父结点是根目录 
                                {
                                    
                                    cate.Cate_IdPath = ",0,";
                                    catenewidpath = cate.Cate_IdPath;
                                    SqlDb.Dcms_Cate subCate = new SqlDb.Dcms_Cate();
                                    if (Cate_str_idpath == ",0,")//如果是根目录，修改该目录下所有的子栏目
                                    {
                                        IQuery subCateQuery = session.GetQuery(subCate).Where(SqlDb.Dcms_Cate._CATE_IDPATH_.Like('%', "," + cate.Cate_Id.ToString() + ",", '%'));
                                        List<SqlDb.Dcms_Cate> subCateList = subCateQuery.GetList<SqlDb.Dcms_Cate>();
                                        for (int i = 0; i < subCateList.Count; i++)
                                        {
                                            string sql3 = "update [Dcms_Cate] set Cate_IdPath='" + subCateList[i].Cate_IdPath.Replace(Cate_str_idpath, cate.Cate_IdPath) + "' where cate_id=" + subCateList[i].Cate_Id.ToString();
                                            session.simple(sql3);
                                        }
                                    }
                                    else//如果不是根目录
                                    {
                                        
                                        IQuery subCateQuery = session.GetQuery(subCate).Where(SqlDb.Dcms_Cate._CATE_IDPATH_.Like('%', Cate_str_idpath, '%'));
                                        List<SqlDb.Dcms_Cate> subCateList = subCateQuery.GetList<SqlDb.Dcms_Cate>();
                                        for (int i = 0; i < subCateList.Count; i++)
                                        {
                                            if (subCateList[i].Cate_Id == cate.Cate_Id || subCateList[i].Cate_IdPath == Cate_str_idpath || (!subCateList[i].Cate_IdPath.Contains(cate.Cate_Id.ToString())))//排除自身和兄弟结点及兄弟结点下的子结点
                                            {
                                                continue;
                                            }
                                            string sql3 = "update [Dcms_Cate] set Cate_IdPath='" + subCateList[i].Cate_IdPath.Replace(Cate_str_idpath, cate.Cate_IdPath) + "' where cate_id=" + subCateList[i].Cate_Id.ToString();
                                            session.simple(sql3);
                                        }
                                    }
                                }
                                else//如果新的父结点不是根目录
                                {
                                   
                                    SqlDb.Dcms_Cate newParentCate = new SqlDb.Dcms_Cate();
                                    IQuery newParentQuery = session.GetQuery(newParentCate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp(cateParentId));
                                    List<SqlDb.Dcms_Cate> newParentCateList = newParentQuery.GetList<SqlDb.Dcms_Cate>();
                                    if (newParentCateList[0].Cate_IdPath.Contains(cate.Cate_IdPath) && newParentCateList[0].Cate_IdPath != cate.Cate_IdPath && cate.Cate_IdPath != ",0,")
                                    {
                                        return "父级栏目不能为该栏目下的子栏目！";
                                    }
                                    cate.Cate_IdPath = newParentCateList[0].Cate_IdPath + cateParentId.ToString() + ",";
                                    catenewidpath = cate.Cate_IdPath;
                                    if (newParentCateList[0].Cate_HasChild == 0)
                                    {
                                        
                                        SqlDb.Dcms_Cate subCate = new SqlDb.Dcms_Cate();
                                        if (Cate_str_idpath == ",0,")//如果是根目录,修改该目录下所有的子栏目
                                        {
                                            IQuery subCateQuery = session.GetQuery(subCate).Where(SqlDb.Dcms_Cate._CATE_IDPATH_.Like('%', "," + cate.Cate_Id.ToString() + ",", '%'));
                                            List<SqlDb.Dcms_Cate> subCateList = subCateQuery.GetList<SqlDb.Dcms_Cate>();
                                            for (int i = 0; i < subCateList.Count; i++)
                                            {
                                                string sql3 = "update [Dcms_Cate] set Cate_IdPath='" + subCateList[i].Cate_IdPath.Replace(Cate_str_idpath, cate.Cate_IdPath) + "' where cate_id=" + subCateList[i].Cate_Id.ToString();
                                                session.simple(sql3);
                                            }
                                        }
                                        else//如果不是根目录
                                        {
                                         
                                            IQuery subCateQuery = session.GetQuery(subCate).Where(SqlDb.Dcms_Cate._CATE_IDPATH_.Like('%', Cate_str_idpath, '%'));
                                            List<SqlDb.Dcms_Cate> subCateList = subCateQuery.GetList<SqlDb.Dcms_Cate>();
                                            for (int i = 0; i < subCateList.Count; i++)
                                            {
                                                if (subCateList[i].Cate_Id == cate.Cate_Id || subCateList[i].Cate_IdPath == Cate_str_idpath || (!subCateList[i].Cate_IdPath.Contains(cate.Cate_Id.ToString())))//排除自身和兄弟结点及兄弟结点下的子结点
                                                {
                                                    continue;
                                                }
                                                string sql3 = "update [Dcms_Cate] set Cate_IdPath='" + subCateList[i].Cate_IdPath.Replace(Cate_str_idpath, cate.Cate_IdPath) + "' where cate_id=" + subCateList[i].Cate_Id.ToString();
                                                session.simple(sql3);
                                            }
                                        }
                                        newParentCate = newParentCateList[0];
                                        newParentCate.Cate_HasChild = 1;
                                        session.Update(newParentCate);
                                    }
                                }
                            }
                            UpdateModelByForm(cate, Request.Form);
                            //提交编辑
                       
                            cate.Cate_IdPath = catenewidpath;

                           
                            session.Update(cate);

                            DataTable subcatedt = session.GetTable("select * from dcms_cate where cate_idpath like '%," + id + ",%'");//取该类别下的所有子类别
                            if (subcatedt.Rows.Count > 0)
                            {
                                string oldcateidpath_1="";
                                oldcateidpath_1 = cate.Cate_IdPath.Substring(0, cate.Cate_IdPath.IndexOf("," + cateParentId.ToString() + ",") + 1);
                                for (int c = 0; c < subcatedt.Rows.Count; c++)
                                {
                                   
                                 
                                    oldcateidpath_1 = cate.Cate_IdPath + id + "," + subcatedt.Rows[c]["cate_idpath"].ToString().Substring(subcatedt.Rows[c]["cate_idpath"].ToString().IndexOf("," + id + ",")+id.ToString().Length+2);
                                    session.simple("update dcms_cate set cate_idpath='" + oldcateidpath_1 + "' where cate_id=" + subcatedt.Rows[c]["cate_id"].ToString());
                                }
                            }
                            subcatedt.Dispose();
                            if (olderParentId != cateParentId)//父栏目改变，修改旧的父栏目
                            {
                                SqlDb.Dcms_Cate olderParentCate = new SqlDb.Dcms_Cate();
                                IQuery olderParentQuery = session.GetQuery(olderParentCate).Where(SqlDb.Dcms_Cate._CATE_PARENTID_.EqulesExp(olderParentId));
                                List<SqlDb.Dcms_Cate> olderParentCateList = olderParentQuery.GetList<SqlDb.Dcms_Cate>();
                                if (olderParentCateList.Count == 0)//原有的父栏目已没有子栏目更新haschild值
                                {
                                    IQuery tempParentQuery = session.GetQuery(olderParentCate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp(olderParentId));
                                    List<SqlDb.Dcms_Cate> tempParentCateList = tempParentQuery.GetList<SqlDb.Dcms_Cate>();
                                    olderParentCate = tempParentCateList[0];
                                    olderParentCate.Cate_HasChild = 0;
                                    session.Update(olderParentCate);
                                }
                            }
                        }
                    }
                    if(!newcatetitle.Equals(oldercatetitle))//是否更改了栏目名称
                    {
                        string updatectsql = "update dcms_" + catemodule + " set " + catemodule + "_CateName='" + newcatetitle + "' where " + catemodule + "_CateId=" + cateid;
                        session.simple(updatectsql);
                    }
                    session.CommitTrans();
                    return "true";
                }
                catch
                {
                    session.RollbackTrans();
                    return "false";
                }
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsert()
        {
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Cate cate = new SqlDb.Dcms_Cate();
                    cate.Cate_AddTime = DateTime.Now;
                    UpdateModelByForm(cate, Request.Form);
                    int parentId = IRequest.GetFormInt("Cate_ParentID", 0);
                    if (parentId > 0)
                    {
                        SqlDb.Dcms_Cate pCate = new SqlDb.Dcms_Cate();
                        IQuery query = session.GetQuery(pCate).Where(SqlDb.Dcms_Cate._CATE_ID_.EqulesExp(parentId));
                        List<SqlDb.Dcms_Cate> cateList = query.GetList<SqlDb.Dcms_Cate>();
                        if (cateList.Count > 0)
                        {
                            cate.Cate_IdPath = cateList[0].Cate_IdPath + parentId.ToString() + ",";
                            //更新是否含有子类
                            if (cateList[0].Cate_HasChild == 0)
                            {
                                session.simple("update [Dcms_Cate] set [Cate_HasChild]=1 where [Cate_Id]=" + parentId.ToString());
                            }
                        }

                    }
                    else
                    {
                        cate.Cate_IdPath = ",0,";
                    }
                    cate.Cate_Lang = Convert.ToString(Utils.GetCookie("LangFlag"));
                    if (cate.Cate_Lang.Length<1)
                    {
                        return "false";
                    }
                    else
                    {
                        cate.Cate_Guid = Guid.NewGuid().ToString("N");
                        //提交插入
                        session.Create(cate);
                    }
                }
                return "true";
            }
            catch
            {
                return "false";
            }

        }
        /// <summary>
        /// 取左栏类别树
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            string treeStr = "";
            string langFlag = Convert.ToString(Utils.GetCookie("LangFlag"));
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string Sql = "select Cate_Id,Cate_Title,Cate_Module,Cate_ManageUrl,Cate_ParentID,Cate_HasChild from [Dcms_Cate] where Cate_Lang='" + langFlag + "' order by [Cate_Order] asc";
                DataTable cateDt = session.GetTable(Sql);
                //if (cateDt.Rows.Count > 0)
                //{
                cateMangeTree jTree = new cateMangeTree();
                treeStr = jTree.CreateTree(cateDt);
                parentSelectTree pTree = new parentSelectTree();
                treeStr = treeStr + "$|&|$" + pTree.CreateTree(cateDt);
                //}
            }
            return treeStr;
        }
        #region 汉字转拼音缩写
        /// <summary>
        /// 汉字转拼音缩写
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        private string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留           
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母     
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        /// <summary>
        /// 取单个字符的拼音声母
        /// </summary>
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        private string GetPYChar(string c)
        {
            try
            {
                byte[] array = new byte[2];
                array = System.Text.Encoding.Default.GetBytes(c);
                int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
                if (i < 0xB0A1) return "v";// "*"
                if (i < 0xB0C5) return "a";
                if (i < 0xB2C1) return "b";
                if (i < 0xB4EE) return "c";
                if (i < 0xB6EA) return "d";
                if (i < 0xB7A2) return "e";
                if (i < 0xB8C1) return "f";
                if (i < 0xB9FE) return "g";
                if (i < 0xBBF7) return "h";
                if (i < 0xBFA6) return "g";
                if (i < 0xC0AC) return "k";
                if (i < 0xC2E8) return "l";
                if (i < 0xC4C3) return "m";
                if (i < 0xC5B6) return "n";
                if (i < 0xC5BE) return "o";
                if (i < 0xC6DA) return "p";
                if (i < 0xC8BB) return "q";
                if (i < 0xC8F6) return "r";
                if (i < 0xCBFA) return "s";
                if (i < 0xCDDA) return "t";
                if (i < 0xCEF4) return "w";
                if (i < 0xD1B9) return "x";
                if (i < 0xD4D1) return "y";
                if (i < 0xD7FA) return "z";
                return "v";// "*"
            }
            catch
            {
                return "";
            }
        }

        ///<summary>
        ///是否存在测试数据
        ///</summary>
        ///<returns>"true"/"false"</returns>
        private bool beExistsTestData()
        {
            bool res = false;
            string xmlPathTestData = HttpContext.Current.Server.MapPath(@"~/sysconfig/TestRecord.xml");
            XmlDocument objXmlDocTestData = new XmlDocument();
            objXmlDocTestData.Load(xmlPathTestData);
            XmlNode rootNode = objXmlDocTestData.SelectSingleNode("root");

            if (rootNode != null && rootNode.ChildNodes.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        ///<summary>
        ///清空测试数据
        ///</summary>
        ///<returns>"true"/"false"</returns>
        private string clearTestData()
        {
            string xmlPathTestData = HttpContext.Current.Server.MapPath(@"~/sysconfig/TestRecord.xml");
            XmlDocument objXmlDocTestData = new XmlDocument();
            objXmlDocTestData.Load(xmlPathTestData);
            XmlNode rootNode = objXmlDocTestData.SelectSingleNode("root");

            if (rootNode != null && rootNode.ChildNodes.Count > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    try
                    {                        
                        foreach (XmlNode xn in rootNode.ChildNodes)
                        {
                            string tableName = xn.Attributes["table"].Value;
                            string keyColumn = xn.Attributes["keyColumn"].Value;
                            string id = xn.Attributes["id"].Value;

                            string cmd = string.Format("Delete from [{0}] where [{1}] in ({2}) ", tableName, keyColumn, id);
                            session.simple(cmd);
                        }
                        
                        rootNode.RemoveAll();
                        objXmlDocTestData.Save(xmlPathTestData);
                        return "清空成功！";
                    }
                    catch
                    {
                        
                        return "清空失败！";
                    }

                }
            }
            else
            {
                return "无测试数据！";
            }

            
        }

        ///<summary>
        ///导入测试数据
        ///</summary>
        ///<returns>"true"/"false"</returns>
        private string testData()
        {
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                try
                {
                    string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/TestData.xml");                    
                    XmlDocument objXmlDoc = new XmlDocument();
                    objXmlDoc.Load(xmlpath);
                    XmlNode rootNode = objXmlDoc.SelectSingleNode("root");

                    //记录测试数据
                    string xmlPathTestData = HttpContext.Current.Server.MapPath(@"~/sysconfig/TestRecord.xml");
                    XmlDocument objXmlDocTestData = new XmlDocument();
                    objXmlDocTestData.Load(xmlPathTestData);
                    XmlNode rootTestData = objXmlDocTestData.DocumentElement;
                    

                    SqlDb.Dcms_Cate cate = new SqlDb.Dcms_Cate();
                    IQuery query = session.GetQuery(cate).Where(SqlDb.Dcms_Cate._CATE_MODULE_.NotEquls("guestbook").AND(SqlDb.Dcms_Cate._CATE_MANAGEURL_.NotNull()));
                    List<SqlDb.Dcms_Cate> catelist = query.GetList<SqlDb.Dcms_Cate>();
                    
                    if (catelist.Count > 0)
                    {
                        session.BeginTrans();
                        for (int i = 0; i < catelist.Count; i++)
                        {
                            if (catelist[i].Cate_ManageUrl.Equals("baseinfo_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[0];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_BaseInfo baseinfo = new SqlDb.Dcms_BaseInfo();
                                session.simple("DELETE FROM [Dcms_BaseInfo] WHERE [BaseInfo_CateId] IN(" + catelist[i].Cate_Id + ")");
                                baseinfo.BaseInfo_CateId = catelist[i].Cate_Id;
                                baseinfo.BaseInfo_CateName = catelist[i].Cate_Title;
                                baseinfo.BaseInfo_Title = catelist[i].Cate_Title;
                                baseinfo.BaseInfo_Content = "<p>" + xn.Attributes["title"].Value + "测试内容</p>" + xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                baseinfo.BaseInfo_AddTime = DateTime.Now;
                                baseinfo.BaseInfo_State = "1";
                                session.Create(baseinfo);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("baseinfo_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[0];
                                XmlNode xn = objNode.ChildNodes[0];

                                SqlDb.Dcms_BaseInfo baseinfo = new SqlDb.Dcms_BaseInfo();
                                baseinfo.BaseInfo_CateId = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    baseinfo.BaseInfo_CateName = catelist[i].Cate_Title;
                                    baseinfo.BaseInfo_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    baseinfo.BaseInfo_Content = "<p>" + xn.Attributes["title"].Value + "测试内容" + j.ToString() + "</p>" + xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                    baseinfo.BaseInfo_AddTime = DateTime.Now;
                                    baseinfo.BaseInfo_State = "1";
                                    session.Create(baseinfo);

                                    //记录测试数据                                    
                                    string addID = session.ExecuteScalar("select max(BaseInfo_Id) from Dcms_BaseInfo");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_BaseInfo");
                                        element.SetAttribute("keyColumn", "BaseInfo_Id");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }                                   
                                    
                                }


                            }
                            if (catelist[i].Cate_ManageUrl.Equals("news_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[1];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_News news = new SqlDb.Dcms_News();
                                session.simple("DELETE FROM [Dcms_News] WHERE [News_CateId] IN(" + catelist[i].Cate_Id + ")");
                                news.News_CateId = catelist[i].Cate_Id;
                                news.News_CateName = catelist[i].Cate_Title;
                                news.News_Title = catelist[i].Cate_Title;
                                news.News_Content = "<p>" + catelist[i].Cate_Title + "测试内容</p>" + xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                news.News_AddTime = DateTime.Now;
                                news.News_State = "1";
                                session.Create(news);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("news_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[1];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_News news = new SqlDb.Dcms_News();
                                news.News_CateId = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    news.News_CateName = catelist[i].Cate_Title;
                                    news.News_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    news.News_Content = "<p>" + catelist[i].Cate_Title + "测试内容" + j.ToString() + "</p>" + xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                    news.News_AddTime = DateTime.Now;
                                    news.News_State = "1";
                                    session.Create(news);

                                    //记录测试数据
                                    string addID = session.ExecuteScalar("select max(News_Id) from Dcms_News");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_News");
                                        element.SetAttribute("keyColumn", "News_Id");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }
                                    
                                }
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("products_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[2];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Products products = new SqlDb.Dcms_Products();
                                session.simple("DELETE FROM [Dcms_Products] WHERE [Products_CateID] IN(" + catelist[i].Cate_Id + ")");
                                products.Products_CateID = catelist[i].Cate_Id;
                                products.Products_CateName = catelist[i].Cate_Title;
                                products.Products_Title = catelist[i].Cate_Title;
                                products.Products_MinImage = xn.Attributes["minimage"].Value;
                                products.Products_BigImage = xn.Attributes["bigimage"].Value;
                                products.Products_Introduction = xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                products.Products_AddTime = DateTime.Now;
                                products.Products_State = "1";
                                products.Products_CodeName = "00001";
                                products.Products_IsHot = "1";
                                products.Products_IsNew = "1";
                                session.Create(products);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("products_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[2];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Products products = new SqlDb.Dcms_Products();
                                products.Products_CateID = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    products.Products_CateName = catelist[i].Cate_Title;
                                    products.Products_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    products.Products_MinImage = xn.Attributes["minimage"].Value;
                                    products.Products_BigImage = xn.Attributes["bigimage"].Value;
                                    products.Products_Introduction = "<p>测试内容" + j.ToString() + "</p>" + xn.Attributes["content"].Value.Replace("[BR]", "<br /><br />");
                                    products.Products_AddTime = DateTime.Now;
                                    products.Products_State = "1";
                                    products.Products_CodeName = "0000" + j.ToString();
                                    products.Products_IsHot = "1";
                                    products.Products_IsNew = "1";
                                    session.Create(products);

                                    //记录测试数据
                                    string addID = session.ExecuteScalar("select max(Products_Id) from Dcms_Products");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_Products");
                                        element.SetAttribute("keyColumn", "Products_Id");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }
                                }
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("link_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[3];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Link link = new SqlDb.Dcms_Link();
                                session.simple("DELETE FROM [Dcms_Link] WHERE [Link_CateId] IN(" + catelist[i].Cate_Id + ")");
                                link.Link_CateId = catelist[i].Cate_Id;
                                link.Link_CateName = catelist[i].Cate_Title;
                                link.Link_Title = catelist[i].Cate_Title;
                                link.Link_Url = xn.Attributes["linkurl"].Value;
                                link.Link_AddTime = DateTime.Now;
                                link.Link_State = "1";
                                session.Create(link);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("link_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[3];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Link link = new SqlDb.Dcms_Link();
                                link.Link_CateId = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    link.Link_CateName = catelist[i].Cate_Title;
                                    link.Link_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    link.Link_Url = xn.Attributes["linkurl"].Value;
                                    link.Link_AddTime = DateTime.Now;
                                    link.Link_State = "1";
                                    session.Create(link);

                                    //记录测试数据
                                    string addID = session.ExecuteScalar("select max(link_Id) from Dcms_Link");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_Link");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }
                                }
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("down_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[4];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Down down = new SqlDb.Dcms_Down();
                                session.simple("DELETE FROM [Dcms_Down] WHERE [Down_CateID] IN(" + catelist[i].Cate_Id + ")");
                                down.Down_CateID = catelist[i].Cate_Id;
                                down.Down_CateName = catelist[i].Cate_Title;
                                down.Down_Title = catelist[i].Cate_Title;
                                down.Down_FileType = xn.Attributes["filetype"].Value;
                                down.Down_LocalPath = xn.Attributes["localpath"].Value;
                                down.Down_AddTime = DateTime.Now;
                                down.Down_State = "1";
                                session.Create(down);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("down_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[4];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Down down = new SqlDb.Dcms_Down();
                                down.Down_CateID = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    down.Down_CateName = catelist[i].Cate_Title;
                                    down.Down_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    down.Down_FileType = xn.Attributes["filetype"].Value;
                                    down.Down_LocalPath = xn.Attributes["localpath"].Value;
                                    down.Down_AddTime = DateTime.Now;
                                    down.Down_State = "1";
                                    session.Create(down);

                                    //记录测试数据
                                    string addID = session.ExecuteScalar("select max(Down_Id) from Dcms_Down");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_Down");
                                        element.SetAttribute("keyColumn", "Down_Id");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }
                                }
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("position_update.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[5];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Position position = new SqlDb.Dcms_Position();
                                session.simple("DELETE FROM [Dcms_Position] WHERE [Position_CateId] IN(" + catelist[i].Cate_Id + ")");
                                position.Position_CateId = catelist[i].Cate_Id;
                                position.Position_CateName = catelist[i].Cate_Title;
                                position.Position_Title = xn.Attributes["title"].Value;
                                position.Position_Num = xn.Attributes["num"].Value;
                                position.Position_Departments = xn.Attributes["departments"].Value;
                                position.Position_Area = xn.Attributes["area"].Value;
                                position.Position_AddTime = DateTime.Now;
                                position.Position_ValidTime = Convert.ToDateTime(xn.Attributes["validtime"].Value);
                                position.Position_Conditions = xn.Attributes["conditions"].Value.Replace("[BR]", "<br /><br />");
                                position.Position_Description = xn.Attributes["description"].Value.Replace("[BR]", "<br /><br />");
                                position.Position_Contact = xn.Attributes["contact"].Value.Replace("[BR]", "<br /><br />");
                                position.Position_State = "1";
                                session.Create(position);
                            }
                            if (catelist[i].Cate_ManageUrl.Equals("position_list.aspx"))
                            {
                                XmlNode objNode = rootNode.ChildNodes[5];
                                XmlNode xn = objNode.ChildNodes[0];
                                SqlDb.Dcms_Position position = new SqlDb.Dcms_Position();
                                position.Position_CateId = catelist[i].Cate_Id;
                                for (int j = 1; j < 6; j++)
                                {
                                    position.Position_CateName = catelist[i].Cate_Title;
                                    position.Position_Title = xn.Attributes["title"].Value + "(" + j.ToString() + ")";
                                    position.Position_Num =xn.Attributes["num"].Value;
                                    position.Position_Departments = xn.Attributes["departments"].Value + "(" + j.ToString() + ")";
                                    position.Position_Area = xn.Attributes["area"].Value + "(" + j.ToString() + ")";
                                    position.Position_AddTime = DateTime.Now;
                                    position.Position_ValidTime = Convert.ToDateTime(xn.Attributes["validtime"].Value);
                                    position.Position_Conditions = "<p>测试内容" + j.ToString() + "</p>" + xn.Attributes["conditions"].Value.Replace("[BR]", "<br /><br />");
                                    position.Position_Description = "<p>测试内容" + j.ToString() + "</p>" + xn.Attributes["description"].Value.Replace("[BR]", "<br /><br />");
                                    position.Position_Contact = "<p>测试内容" + j.ToString() + "</p>" + xn.Attributes["contact"].Value.Replace("[BR]", "<br /><br />");
                                    position.Position_State = "1";
                                    session.Create(position);

                                    //记录测试数据
                                    string addID = session.ExecuteScalar("select max(Position_Id) from Dcms_Position");
                                    if (!string.IsNullOrEmpty(addID))
                                    {
                                        XmlElement element = objXmlDocTestData.CreateElement("data");
                                        element.SetAttribute("table", "Dcms_Position");
                                        element.SetAttribute("keyColumn", "Position_Id");
                                        element.SetAttribute("id", addID);
                                        rootTestData.AppendChild(element);
                                    }
                                }
                            }
                        }
                        session.CommitTrans();
                        //记录测试数据
                        objXmlDocTestData.Save(xmlPathTestData);
                        return "生成成功！";
                    }

                    return "false";
                }

                catch(Exception ex)
                {
                    session.RollbackTrans();
                    return "生成失败！"+ex.Message;
                }
            }
        }
        #endregion
    }
}
