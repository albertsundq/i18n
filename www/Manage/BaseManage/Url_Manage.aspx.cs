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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_Url_Manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //操作方式
                string action = IRequest.GetQueryString("action").ToLower();
                switch (action)
                {
                    case "insert":
                        Response.Clear();
                        Response.Write(doInsert());
                        break;
                    case "selectpage":
                        Response.Clear();
                        Response.Write(doSelectPage());
                        break;
                    case "select":
                        Response.Clear();
                        Response.Write(doSelect());
                        break;
                    case "getone":
                        Response.Clear();
                        Response.Write(doGetOne());
                        break;
                    case "edit":
                        Response.Clear();
                        Response.Write(doEdit());
                        break;
                    case "delete":
                        Response.Clear();
                        Response.Write(doDelete());
                        break;
                }
            }
        }
        /// <summary>
        /// 按页取数据
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            StringBuilder sb = new StringBuilder();
                int page = IRequest.GetFormInt("page", 1);
                string keyword = IRequest.GetFormString("query");
                string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(xmlpath);
                XmlNode objNode = objXmlDoc.SelectSingleNode("urls");

                if (keyword.Length > 0)//搜索
                {
                    int totalCount = 0;
                    XmlNodeList xl = objNode.ChildNodes;
                    foreach (XmlNode xn in xl)
                    {
                        if (xn.Attributes["domain"].Value.Contains(keyword))
                        {
                            totalCount += 1;
                        }
                    }
                    sb.Append("{\n");
                    sb.Append("\"page\":\"" + page.ToString() + "\",\n");
                    sb.Append("\"total\":\"" + totalCount.ToString() + "\",\n");
                    sb.Append("\"rows\": [\n");
                    if (totalCount > 0)
                    {
                        for (int i = 0; i < xl.Count; i++)
                        {
                         
                                if (xl[i].Attributes["domain"].Value.Contains(keyword))
                                {

                                    sb.Append("{");


                                    sb.Append(string.Format("\"domain\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", xl[i].Attributes["domain"].Value, xl[i].Attributes["domain"].Value, xl[i].Attributes["name"].Value, xl[i].Attributes["page"].Value, xl[i].Attributes["defaultpage"].Value));
                                    // }

                                    if ((i + 1) == xl.Count)
                                    {
                                        sb.Append("}\n");
                                    }
                                    else
                                    {
                                        sb.Append("},\n");
                                    }
                               }
                           
                         }
                    }
                    sb.Append("]\n");
                    sb.Append("}");
                }
                else
                {
                    //取总记录
                    int totalCount = objNode.ChildNodes.Count;
                    XmlNodeList xl = objNode.ChildNodes;
                    //List<SqlDb.Dcms_News> newsList = query.GetList<SqlDb.Dcms_News>(page, rp);
                    //Json格式
                    sb.Append("{\n");
                    sb.Append("\"page\":\"" + page.ToString() + "\",\n");
                    sb.Append("\"total\":\"" + totalCount.ToString() + "\",\n");
                    sb.Append("\"rows\": [\n");
                    //foreach (XmlNode xn in objNode.ChildNodes)
                    for (int i = 0; i < totalCount; i++)
                    {

                        sb.Append("{");


                        sb.Append(string.Format("\"domain\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", xl[i].Attributes["domain"].Value, xl[i].Attributes["domain"].Value, xl[i].Attributes["name"].Value, xl[i].Attributes["page"].Value, xl[i].Attributes["defaultpage"].Value));
                        // }

                        if ((i + 1) == xl.Count)
                        {
                            sb.Append("}\n");
                        }
                        else
                        {
                            sb.Append("},\n");
                        }
                    }
                    sb.Append("]\n");
                    sb.Append("}");
                }
            

            return sb.ToString();
        }
        /// <summary>
        /// 取文件目录
        /// </summary>
        /// <returns>json</returns>
        private string doSelectPage()
        {
            System.Text.StringBuilder secstr = new System.Text.StringBuilder();
            secstr.Append("<select id='Url_Page' name='Url_Page'>");
            string aspxpath = HttpContext.Current.Server.MapPath(@"~/Aspx");
            String[] str = System.IO.Directory.GetDirectories(aspxpath);
            foreach (string pagestr in str)
            {
                secstr.Append(@"<option value='Aspx/" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "'>" + pagestr.Substring(pagestr.LastIndexOf('\\') + 1) + "</option>");
            }
            secstr.Append("</select>");
            return secstr.ToString();
        }
        /// <summary>
        /// 增加url规则
        /// </summary>
        /// <returns>json</returns>
        private string doInsert()
        {
            //<rewrite domain="en" name="英文版" path="EN/" value="0"  page="aspx/EN/" langflag="en" defaultpage="aspx/cn/" />
            //<rewrite domain="xx04271.35demo.cn"  name="日文版" path="jp/" value="2" page="aspx/jp/" langflag="jp" defaultpage="aspx/cn/" />
            try
            {
                string raddomain=IRequest.GetFormString("Rad_Domain");
                string domain = IRequest.GetFormString("Url_Domain");
                string page = IRequest.GetFormString("Url_Page");
                string name = IRequest.GetFormString("Url_Name");
                string isdefault = IRequest.GetFormString("Url_Default");
                string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
                string defaultpage = string.Empty;
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(xmlpath);
                XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
                foreach (XmlNode xn in objNode.ChildNodes)//判断域名是否已存在
                {
                    if (xn.Attributes["domain"].Value == domain)
                    {
                        return "2";
                    }
                    defaultpage = xn.Attributes["defaultpage"].Value;
                }
                if(isdefault == "1")//当前版本设为默认版本
                {   

                    foreach (XmlNode xn in objNode.ChildNodes)
                    {
                       XmlElement xe =xn as XmlElement;
                      //  XmlHelper.XmlAttributeEide(xmlpath, n.Name, "defaultpage", page);
                       xe.SetAttribute("defaultpage", page);
                        
                    }
                 
                }
                XmlElement objElement = objXmlDoc.CreateElement("rewrite");
                if(raddomain == "0")//一级域名
                {
                   
                    objElement.SetAttribute("domain", domain);
                    objElement.SetAttribute("name", name);
                    objElement.SetAttribute("path", page.Substring(page.IndexOf('/') + 1) + "/");
                    objElement.SetAttribute("value", "0");
                    objElement.SetAttribute("page", page);
                    objElement.SetAttribute("langflag", page.Substring(page.IndexOf('/') + 1));
                    if (isdefault == "1")
                    {
                        objElement.SetAttribute("defaultpage", page);
                    }
                    if (isdefault =="0")
                    {
                        objElement.SetAttribute("defaultpage", defaultpage);
                    }
                    objNode.AppendChild(objElement);
                    objXmlDoc.Save(xmlpath);
                }
                if (raddomain == "2")//二级域名
                {
                  
                    objElement.SetAttribute("domain", domain);
                    objElement.SetAttribute("name", name);
                    objElement.SetAttribute("path", page.Substring(page.IndexOf('/')+1) + "/");
                    objElement.SetAttribute("value", "2");
                    objElement.SetAttribute("page", page);
                    objElement.SetAttribute("langflag", page.Substring(page.IndexOf('/')+1));
                    if (isdefault == "1")
                    {
                        objElement.SetAttribute("defaultpage", page);
                    }
                    if (isdefault == "0")
                    {
                        objElement.SetAttribute("defaultpage", defaultpage);
                    }

                    objNode.AppendChild(objElement);
                    objXmlDoc.Save(xmlpath);
                }
                //Dcms.Utility.XmlHelper.XmlInsertElement(xmlpath, "urls", "rewrite", "domain", domain, "");

                return "1";
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// 取单条编辑数据
        /// </summary>
        /// <returns>json</returns>
        private string doGetOne()
        {
            string domain = IRequest.GetQueryString("domain");
            StringBuilder sb = new StringBuilder();
            if (domain.Length > 0)
            {
                string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(xmlpath);
                XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
                foreach (XmlNode xn in objNode.ChildNodes)
                {
                    if (xn.Attributes["domain"].Value == domain)
                    {
                        sb.Append("{\"Url_Domain\":\"" + domain + "\",\"Url_Value\":\"" + xn.Attributes["value"].Value + "\",\"Url_Page\":\"" + xn.Attributes["page"].Value + "\",\"Url_Name\":\"" + xn.Attributes["name"].Value + "\",\"Url_DefaultPage\":\"" + xn.Attributes["defaultpage"].Value + "\"}");
                        break;
                    }
                }

            }
            return sb.ToString();
        }
        /// <summary>
        /// 编辑单条数据
        /// </summary>
        /// <returns>json</returns>
        private string doEdit()
        {
            try
            {
                string raddomain = IRequest.GetFormString("Rad_Domain");
                string domain = IRequest.GetFormString("Url_Domain");
                string page = IRequest.GetFormString("Url_Page");
                string name = IRequest.GetFormString("Url_Name");
                string isdefault = IRequest.GetFormString("Url_Default");

                string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(xmlpath);
                XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
               
                if (isdefault == "1")//当前版本设为默认版本
                {

                    foreach (XmlNode xn in objNode.ChildNodes)
                    {
                        XmlElement xe = xn as XmlElement;
                        //  XmlHelper.XmlAttributeEide(xmlpath, n.Name, "defaultpage", page);
                        xe.SetAttribute("defaultpage", page);

                    }

                }
                foreach (XmlNode xn in objNode.ChildNodes)
                {
                    if (xn.Attributes["domain"].Value == domain)
                    {
                        XmlElement xe = xn as XmlElement;
                        if (raddomain == "0")//一级域名
                        {

                            xe.SetAttribute("domain", domain);
                            xe.SetAttribute("name", name);
                            xe.SetAttribute("path", page.Substring(page.IndexOf('/') + 1) + "/");
                            xe.SetAttribute("value", "0");
                            xe.SetAttribute("page", page);
                            xe.SetAttribute("langflag", page.Substring(page.IndexOf('/') + 1));
                            if (isdefault == "1")
                            {
                                xe.SetAttribute("defaultpage", page);
                            }
                            if (isdefault == "0")
                            {
                                xe.SetAttribute("defaultpage", xn.Attributes["defaultpage"].Value);
                            }
                            objNode.AppendChild(xe);
                            objXmlDoc.Save(xmlpath);
                        }
                        if (raddomain == "2")//二级域名
                        {

                            xe.SetAttribute("domain", domain);
                            xe.SetAttribute("name", name);
                            xe.SetAttribute("path", page.Substring(page.IndexOf('/') + 1) + "/");
                            xe.SetAttribute("value", "2");
                            xe.SetAttribute("page", page);
                            xe.SetAttribute("langflag", page.Substring(page.IndexOf('/') + 1));
                            if (isdefault == "1")
                            {
                                xe.SetAttribute("defaultpage", page);
                            }
                            if (isdefault == "0")
                            {
                                xe.SetAttribute("defaultpage", xn.Attributes["defaultpage"].Value);
                            }

                            objXmlDoc.Save(xmlpath);
                        }
                    }
                }
                updateCache();
                return "1";
            }
            catch
            {
                return "0";
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
                string id = IRequest.GetQueryString("id").TrimStart(new char[] { ',' });
                string xmlpath = HttpContext.Current.Server.MapPath(@"~/sysconfig/urls.config");
                XmlDocument objXmlDoc = new XmlDocument();
                objXmlDoc.Load(xmlpath);
                XmlNode objNode = objXmlDoc.SelectSingleNode("urls");
                string[] strlist = id.Split(new char[] { ',' });
                for (int i = 0; i < strlist.Length; i++)
                {
                    foreach (XmlNode xn in objNode.ChildNodes)
                    {
                        if (xn.Attributes["domain"].Value == strlist[i])
                        {
                            objNode.RemoveChild(xn);
                        }
                    }
                }
                objXmlDoc.Save(xmlpath);
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        ///<summary>
        ///更新网站缓存
        ///</summary>
        ///<returns></returns>
        private string updateCache()
        {
            try
            {
                
                string path = HttpContext.Current.Server.MapPath(@"~/");
                string sourceFileName=path+"web.config";
                string newFileName=path+"webbak.config";
                if (File.Exists(sourceFileName))
                {
                    File.Move(sourceFileName, newFileName);
                    File.Move(newFileName, sourceFileName);
                    
                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }
    }
}
