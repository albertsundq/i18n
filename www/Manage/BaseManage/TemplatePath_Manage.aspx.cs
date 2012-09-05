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
using System.IO;
using System.Collections.Generic;

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_TemplatePath_Manage : Dcms.BasePage.ManagePage
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
            }
        }
        /// <summary>
        /// 按页取数据
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            StringBuilder sb = new StringBuilder();
            //取Grid提交来的数据开始
            int rp = IRequest.GetFormInt("rp", 1);
            int page = IRequest.GetFormInt("page", 1);
            string keyword = IRequest.GetFormString("query");
            string qtype = IRequest.GetFormString("qtype");
            string langflag = IRequest.GetQueryString("langflag");
            string TemplatePathStr = Utils.GetMapPath(ConfigurationManager.AppSettings["TempLatePath"] + langflag);
            DirectoryInfo dirinfo = new DirectoryInfo(TemplatePathStr);
            if (keyword.Length > 0)
            {
                int totalCount = 0;
                FileInfo[] files = dirinfo.GetFiles();
                Dictionary<int, ArrayList> dic = new Dictionary<int, ArrayList>();
                ArrayList fileList = new ArrayList();
                foreach (FileInfo tempfile in files)
                {
                    if (tempfile.Name.Contains(keyword))
                    {
                        fileList.Add(tempfile.Name.ToString());
                        fileList.Add(Convert.ToString(tempfile.Length));
                        fileList.Add(tempfile.CreationTime.ToString());
                        fileList.Add(tempfile.LastWriteTime.ToString());

                        dic.Add(totalCount, fileList);
                        totalCount += 1;

                    }
                }
                //json格式
                sb.Append("{\n");
                sb.Append("\"page\":\"" + page.ToString() + "\",\n");
                sb.Append("\"total\":\"" + totalCount.ToString() + "\",\n");
                sb.Append("\"rows\": [\n");

                if (totalCount > 0)
                {
                    int loopCount = 0;
                    if (totalCount < page * rp)
                    {
                        loopCount = totalCount;
                    }
                    else
                    {
                        loopCount = page * rp;
                    }
                    for (int i = (page - 1) * rp; i < loopCount; i++)
                    {

                        sb.Append("{");
                        sb.Append(string.Format("\"文件名称\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", dic[i][i * 4].ToString(), dic[i][i * 4].ToString(), dic[i][i * 4 + 1].ToString(), dic[i][i * 4 + 2].ToString(), dic[i][i * 4 + 3].ToString()));

                        if ((i + 1) == loopCount)
                        {
                            sb.Append("}\n");
                        }
                        else
                        {
                            sb.Append("},\n");
                        }

                    }
                }
                sb.Append("]\n");
                sb.Append("}");
            }
            else
            {
                //取总记录
                int totalCount = dirinfo.GetFiles().Length;
                FileInfo[] files = dirinfo.GetFiles();

                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":\"" + page.ToString() + "\",\n");
                sb.Append("\"total\":\"" + totalCount.ToString() + "\",\n");
                sb.Append("\"rows\": [\n");
                int loopCount = 0;
                if (totalCount < page * rp)
                {
                    loopCount = totalCount;
                }
                else
                {
                    loopCount = page * rp;
                }
                for (int i = (page - 1) * rp; i < loopCount; i++)
                {
                    sb.Append("{");
                    sb.Append(string.Format("\"文件名称\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", files[i].Name, files[i].Name, Convert.ToString(files[i].Length), files[i].CreationTime.ToString(), files[i].LastWriteTime.ToString()));
                    if ((i + 1) == loopCount)
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
        /// 取单条编辑数据
        /// </summary>
        /// <returns>json</returns>
        private string doGetOne()
        {
            string langflag = IRequest.GetQueryString("langflag");
            string filename = IRequest.GetQueryString("filename");
            string TemplatePathStr = Utils.GetMapPath(ConfigurationManager.AppSettings["TempLatePath"] + langflag);
            DirectoryInfo dirinfo = new DirectoryInfo(TemplatePathStr);
            FileInfo[] files = dirinfo.GetFiles();
            StringBuilder oneRecord = new StringBuilder();
            foreach (FileInfo tempfile in files)
            {
                if (tempfile.Name.Equals(filename))
                {
                    string TempFileContent = FormatJsonData(FileManage.ReadTextFile(tempfile.FullName));
                    //FileManage.SaveTextFile(TempFile.FullName, TempFileContent, "utf-8");
                    oneRecord.Append("[{\"File_Name\":\"" + tempfile.Name + "\",\"File_Content\":\"" + TempFileContent + "\"}]");
                    break;
                }
            }

            return oneRecord.ToString();
        }
        /// <summary>
        /// 编辑一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doUpdate()
        {
            try
            {
                string filename = IRequest.GetFormString("File_Name");
                string filecontent = Server.UrlDecode(IRequest.GetFormString("File_Content"));
                string langflag = IRequest.GetFormString("langflag");
                string TemplatePathStr = Utils.GetMapPath(ConfigurationManager.AppSettings["TempLatePath"] + langflag);
                DirectoryInfo dirinfo = new DirectoryInfo(TemplatePathStr);
                FileInfo[] files = dirinfo.GetFiles();
                foreach (FileInfo tempfile in files)
                {
                    if (tempfile.Name.Equals(filename))
                    {
                        string TempFileContent = FileManage.ReadTextFile(tempfile.FullName);//.Replace("\"", "&quot;").Replace(Environment.NewLine, "");
                        FileManage.SaveTextFile(tempfile.FullName, filecontent, "utf-8");
                      //  FileUtil.WriteText(tempfile.FullName, filecontent);
                        break;
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
        /// 批量删除操作
        /// </summary>
        /// <returns></returns>
        private string doDelete()
        {
            try
            {
                string[] filenames = IRequest.GetQueryString("files").TrimStart(new char[] { ',' }).Split(new char[] { ',' });
                string langflag = IRequest.GetQueryString("langflag");
                string TemplatePathStr = Utils.GetMapPath(ConfigurationManager.AppSettings["TempLatePath"] + langflag);
                DirectoryInfo dirinfo = new DirectoryInfo(TemplatePathStr);
                FileInfo[] files = dirinfo.GetFiles();
                foreach (FileInfo tempfile in files)
                {
                    foreach (string filename in filenames)
                    {

                        if (tempfile.Name.Equals(filename))
                        {
                            FileManage.DeleteFileFolder(tempfile.FullName);
                            break;
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
        /// 插入一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsert()
        {
            try
            {
                string filename = IRequest.GetFormString("File_Name");
                
                string filecontent = Server.UrlDecode(IRequest.GetFormString("File_Content"));//.Replace(" ", "&nbsp;").Replace("\r\n", "<br/>"));//Replace("&lt;", "<").Replace("&quot;", "\"").Replace("&gt;", ">").
                string langflag = IRequest.GetFormString("langflag");
                string TemplatePathStr = Utils.GetMapPath(ConfigurationManager.AppSettings["TempLatePath"] + langflag);
                DirectoryInfo dirinfo = new DirectoryInfo(TemplatePathStr);
                FileInfo[] files = dirinfo.GetFiles();
                foreach (FileInfo tempfile in files)
                {
                    if (tempfile.Name.Split('.')[0].Equals(filename.Split('.')[0]))
                    {
                      //  Jscript.Alert("当前目录存在同名的文件!");
                        return "false";

                    }
                }

                FileStream fs = File.Create(TemplatePathStr + "\\" + filename);
                fs.Close();
                FileManage.SaveTextFile(TemplatePathStr + "\\" + filename, filecontent, "utf-8");
             //   FileUtil.WriteText(TemplatePathStr + "\\" + filename, filecontent);
                
                return "true";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
