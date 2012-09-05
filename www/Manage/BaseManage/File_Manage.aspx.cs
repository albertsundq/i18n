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
using System.Collections.Specialized;
using System.Text;
using Dcms.Orm;
using Dcms.Utility;
using System.IO;
namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_File_Manage : Dcms.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //操作方式
            //string action = Request.QueryString["action"].ToString();

            string action = IRequest.GetQueryString("action").ToString().ToLower();
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
                //case "update":
                //    Response.Clear();
                //    Response.Write(doUpdate());
                //    break;
                case "fileSyn":
                    Response.Clear();
                    Response.Write("fileSyn");
                    break;
                case "renew":
                    Response.Clear();
                    Response.Write(doRenew());
                    break;
                case "delete":
                    Response.Clear();
                    Response.Write(doDelete());
                    break;
                case "insertpath":
                    Response.Clear();
                    Response.Write(doInsertPath());
                    break;
                case "deletepath":
                    Response.Clear();
                    Response.Write(doDeletePath());
                    break;
                case "selectpath":
                    Response.Clear();
                    Response.Write(doSelectPath());
                    break;
                default:
                    Response.Clear();
                    Response.Write(fileSyn());
                    break;
            }
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsert()
        {
            //return "<script>alert('" + "upload.Upload_PathName" + "')</script>)";
            string uploadPath = "";
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Upload upload = new SqlDb.Dcms_Upload();
                    upload.Upload_DateTime = DateTime.Now;
                    upload.Upload_UserId = 1;
                    upload.Upload_PathName = IRequest.GetFormString("Upload_PathName").ToString();
                    //UpdateModelByForm(upload, Request.Form);
                    uploadPath = HttpContext.Current.Server.MapPath(@"~/UploadFile") + "\\" + upload.Upload_PathName;
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);

                    }
                    //提交插入
                    session.Create(upload);


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
            string oneRecord = "";
            if (id > 0)
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Upload upload = new SqlDb.Dcms_Upload();
                    IQuery query = session.GetQuery(upload).Where(SqlDb.Dcms_Upload._UPLOAD_ID_.EqulesExp(id));
                    List<SqlDb.Dcms_Upload> uploadList = query.GetList<SqlDb.Dcms_Upload>();
                    if (uploadList.Count > 0)
                    {
                        //if(roleList[0]
                        // oneRecord = "[{Role_Name:\"" + roleList[0].Role_Name + "\",Role_Order:\"" + roleList[0].Role_Order + "\",Role_Id:\"" + roleList[0].Role_Id.ToString() + "\"}]";
                    }
                }
            }
            return oneRecord;
        }
        /// <summary>
        /// 重命名文件操作
        /// </summary>
        /// <returns></returns>
        private string doRenew()
        {
            try
            {
                int fileId = IRequest.GetFormInt("fileId", 0);
                string newFileName = IRequest.GetFormString("newFileName");
                string path = HttpContext.Current.Server.MapPath(@"~/UploadFile");
                //string[] files = Directory.GetFiles(path);
                //string delfiles = "";
                //string delfile = "reflector.zip";
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_File file = new SqlDb.Dcms_File();
                    IQuery query = session.GetQuery(file).Where(SqlDb.Dcms_File._FILE_ID_.EqulesExp(fileId));
                    List<SqlDb.Dcms_File> fileList = query.GetList<SqlDb.Dcms_File>();
                    if (fileList.Count > 0)
                    {
                        string olderFileName = fileList[0].File_OlderFileName;
                        string olderNewFileName = fileList[0].File_NewFileName;
                        path = path + @getUploadPathByUploadId(fileList[0].File_UploadId);
                        file = fileList[0];
                        file.File_AddDateTime = DateTime.Now;
                        file.File_OlderFileName = newFileName;
                        file.File_NewFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "") + "-" + newFileName;
                        if (File.Exists(path + @"/" + olderNewFileName))
                        {
                            File.Copy(path + @"/" + olderNewFileName, path + @"/" + file.File_NewFileName, false);
                            File.Delete(path + @"/" + olderNewFileName);
                            session.Update(file);
                        }

                    }
                    //  System.IO.File.Delete(path + @getUploadPathByUploadId(fileList[0].File_UploadId) + @"/" + fileList[0].File_OlderFileName);



                    // string Sql = "DELETE FROM [Dcms_Upload] WHERE [Upload_Id] IN(" + id + ")";
                    // session.simple(Sql);


                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        ///<summary>
        ///文件同步
        /// </summary>
        ///<returns></returns>
        private string fileSyn()
        {
            string rootPath = HttpContext.Current.Server.MapPath(@"~/UploadFile");
            string[] subPathArray = Directory.GetDirectories(rootPath);
            string subPathStr = "";

            foreach (string subPath in subPathArray)
            {
                if (subPath != "")
                {

                }
                subPathStr += subPath + ":";
            }
            if (subPathStr == "")
            {
                return subPathArray.Length.ToString();
            }
            return subPathStr;
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
                string path = HttpContext.Current.Server.MapPath(@"~/UploadFile");
                //string[] files = Directory.GetFiles(path);
                //string delfiles = "";
                //string delfile = "reflector.zip";
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_File file = new SqlDb.Dcms_File();
                    string[] ids = id.Split(new char[] { ',' });
                    foreach (string fileid in ids)
                    {
                        IQuery query = session.GetQuery(file).Where(SqlDb.Dcms_File._FILE_ID_.EqulesExp(fileid));
                        List<SqlDb.Dcms_File> fileList = query.GetList<SqlDb.Dcms_File>();
                        //if (uploadList[0].Upload_PathName != null)
                        //{
                        //    continue;
                        //}
                        //  foreach (string delfile in files)
                        // {
                        // System.IO.File.Delete(delfile);
                        // delfiles += delfile;
                        //if (delfile == path + @"\"+uploadList[0].Upload_OlderFileName)
                        //{
                        //    System.IO.File.Delete(delfile);
                        //    //Response.Write(delfile);
                        //}
                        //Response.Write(delfiles);
                        //   }
                        string Sql = "DELETE FROM [Dcms_File] WHERE [File_Id] ='" + fileid + "'";
                        session.simple(Sql);

                        System.IO.File.Delete(path + @getUploadPathByUploadId(fileList[0].File_UploadId) + @"/" + fileList[0].File_NewFileName);


                    }
                    // string Sql = "DELETE FROM [Dcms_Upload] WHERE [Upload_Id] IN(" + id + ")";
                    // session.simple(Sql);


                }
                return "true";
            }
            catch
            {
                return "false";
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
            int uploadId = IRequest.GetQueryInt("id", 0);
            int rp = IRequest.GetFormInt("rp", 10);
            int page = IRequest.GetFormInt("page", 1);
            string keyword = IRequest.GetFormString("query");
            string qtype = IRequest.GetFormString("qtype");

            string path = getUploadPathByUploadId(uploadId).Replace("\\", "/");
            //取Grid提交来的数据结束
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                SqlDb.Dcms_File file = new SqlDb.Dcms_File();
                //创建查询
                IQuery query = session.GetQuery(file);
                if (keyword.Length > 0)
                {
                    query.Where(SqlDb.Dcms_File._FILE_OLDERFILENAME_.Like('%', keyword, '%')).OrderBy(SqlDb.Dcms_File._FILE_ID_, Direction.DESC);
                }
                else
                {
                    query.Where(SqlDb.Dcms_File._FILE_UPLOADID_.EqulesExp(uploadId)).OrderBy(SqlDb.Dcms_File._FILE_ID_, Direction.DESC);
                }
                //取总记录
                int totalCount = query.Count();
                List<SqlDb.Dcms_File> fileList = query.GetList<SqlDb.Dcms_File>(page, rp);
                //Json格式
                sb.Append("{\n");
                sb.Append("\"page\":" + page.ToString() + ",\n");
                sb.Append("\"total\":" + totalCount.ToString() + ",\n");
                sb.Append("\"rows\": [\n");
                for (int i = 0; i < fileList.Count; i++)
                {
                    sb.Append("{");
                    
                    sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", fileList[i].File_Id.ToString(), fileList[i].File_Id.ToString(), "<a onclick='javascript:void()' target='_blank' href='" + "../../UploadFile" + path + "/" + fileList[i].File_NewFileName.ToString() + "'>" + fileList[i].File_OlderFileName.ToString() + "</a>", fileList[i].File_FileSize.ToString(), fileList[i].File_AddDateTime.ToString("yyyy/MM/dd")));
                    

                    if ((i + 1) == fileList.Count)
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
        /// 插入一条目录数据
        /// </summary>
        /// <returns>"true"/"false"</returns>
        private string doInsertPath()
        {
            //return "<script>alert('" + "upload.Upload_PathName" + "')</script>)";
            string uploadPath = "";
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Upload upload = new SqlDb.Dcms_Upload();
                    upload.Upload_DateTime = DateTime.Now;
                    upload.Upload_UserId = 1;
                    //upload.Upload_FileSize = "20kb";
                    upload.Upload_PathName = IRequest.GetFormString("Upload_PathName").ToString();
                    int parentId = IRequest.GetFormInt("Upload_ParentId", 0);
                    if (parentId > 0)
                    {
                        SqlDb.Dcms_Upload upload1 = new SqlDb.Dcms_Upload();
                        IQuery query = session.GetQuery(upload1).Where(SqlDb.Dcms_Upload._UPLOAD_ID_.EqulesExp(parentId));
                        List<SqlDb.Dcms_Upload> uploadList = query.GetList<SqlDb.Dcms_Upload>();
                        if (uploadList.Count > 0)
                        {

                            upload.Upload_IdPath = uploadList[0].Upload_IdPath + "\\" + upload.Upload_PathName;
                            uploadPath = HttpContext.Current.Server.MapPath(@"~/UploadFile") + upload.Upload_IdPath;
                            //更新是否有子目录
                            if (uploadList[0].Upload_HasChild == 0)
                            {
                                session.simple("update [Dcms_Upload] set [Upload_HasChild]=1 where [Upload_Id]=" + parentId.ToString());
                            }
                        }
                    }
                    else
                    {
                        //uploadPath = HttpContext.Current.Server.MapPath(@"~/UploadFile") + "\\" + upload.Upload_PathName;
                        upload.Upload_IdPath = "\\" + upload.Upload_PathName;
                        uploadPath = HttpContext.Current.Server.MapPath(@"~/UploadFile") + upload.Upload_IdPath;
                    }
                    upload.Upload_ParentId = parentId;
                    //UpdateModelByForm(upload, Request.Form);

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);

                    }
                    //提交插入
                    session.Create(upload);


                }
                return "true";
            }
            catch
            {
                return "false";
            }


        }
        /// <summary>
        /// 删除目录操作
        /// </summary>
        /// <returns></returns>
        private string doDeletePath()
        {
            try
            {
                int id = Convert.ToInt32(IRequest.GetQueryString("id"));
                string path = HttpContext.Current.Server.MapPath(@"~/UploadFile");
                //string[] files = Directory.GetFiles(path);
                //string delfiles = "";
                //string delfile = "reflector.zip";
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    SqlDb.Dcms_Upload upload = new SqlDb.Dcms_Upload();

                    IQuery uploadQuery = session.GetQuery(upload);
                    List<SqlDb.Dcms_Upload> uploadSubList = uploadQuery.Where(SqlDb.Dcms_Upload._UPLOAD_PARENTID_.EqulesExp(id)).GetList<SqlDb.Dcms_Upload>();
                    if (uploadSubList.Count > 0)//当前目录还有子目录
                    {
                        return "subpathexist";
                    }
                    List<SqlDb.Dcms_Upload> uploadList = uploadQuery.Where(SqlDb.Dcms_Upload._UPLOAD_ID_.EqulesExp(id)).GetList<SqlDb.Dcms_Upload>();
                    path = path + @uploadList[0].Upload_IdPath;

                    string[] delfiles = Directory.GetFiles(path);
                    if (delfiles.Length > 0)
                    {
                        foreach (string delfile in delfiles)//删除该目录下的所有文件
                        {
                            File.Delete(delfile);
                        }
                        string delfilesql = "Delete from [Dcms_File] where [File_UploadId]='" + id + "'";
                        session.simple(delfilesql);//删除表里文件记录
                    }

                    Directory.Delete(path);//删除硬盘上的目录
                    String delPathSql = "Delete from [Dcms_Upload] where [Upload_Id]='" + id + "'";
                    session.simple(delPathSql);//删除目录表里的记录


                }
                return "true";
            }
            catch
            {
                return "false";
            }
        }
        ///<summary>
        ///取目录路径
        /// </summary>
        /// <return>
        /// 目录路径字符串
        /// </return>
        private string getUploadPathByUploadId(int uploadId)
        {

            string pathstr = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {

                SqlDb.Dcms_Upload upload = new SqlDb.Dcms_Upload();
                IQuery query = session.GetQuery(upload).Where(SqlDb.Dcms_Upload._UPLOAD_ID_.EqulesExp(uploadId));
                List<SqlDb.Dcms_Upload> uploadList = query.GetList<SqlDb.Dcms_Upload>();
                if (uploadList.Count > 0)
                {
                    pathstr = uploadList[0].Upload_IdPath;
                }
                return pathstr;


            }
        }


        /// <summary>
        /// 取左栏目录树
        /// </summary>
        /// <returns>json</returns>
        private string doSelectPath()
        {
            string treeStr = "";
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
                string Sql = "select * from [Dcms_Upload] order by [Upload_Order] asc";
                DataTable uploadDt = session.GetTable(Sql);
                if (uploadDt.Rows.Count > 0)
                {
                    UploadJqueryTree jTree = new UploadJqueryTree();
                    treeStr = jTree.CreateTree(uploadDt);
                }
            }
            return treeStr;
        }
    }
}

