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
using System.Collections.Specialized;
using System.IO;
using SQLDMO;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Manage.form
{
    public partial class Manage_form_form_manage : Dcms.BasePage.ManagePage
    {
        private static string dbname;
        private static string dbuser;
        private static string dbpwd;
        private static string conn;
        private static string dbtype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDbType();
            }
            string action = IRequest.GetQueryString("action").ToString().ToLower();
            switch (action)
            {
                case "select":
                    Response.Clear();
                    Response.Write(doSelect());
                    break;
                case "esql":
                    Response.Clear();
                    Response.Write(doESql());
                    break;
                case "viewsqlhelp":
                    Response.Clear();
                    Response.Write(doViewSqlHelp());
                    break;
                case "fieldshow":
                    Response.Clear();
                    Response.Write(doFieldShow());
                    break;
                case "makecode":
                    Response.Clear();
                    Response.Write(doMakeCode());
                    break;
                case "backup":
                    Response.Clear();
                    Response.Write(doBackUp());
                    break;
                case "restore":
                    Response.Clear();
                    Response.Write(doRestore());
                    break;
                case "getbaklist":
                    Response.Clear();
                    Response.Write(doGetBakList());
                    break;
                case "delbak":
                    Response.Clear();
                    Response.Write(doDelBak());
                    break;
            }
        }
        /// <summary>
        /// 按页取数据
        /// </summary>
        /// <returns>json</returns>
        private string doSelect()
        {
            if (dbtype.ToLower() != "dcsqlite")
            {
                StringBuilder sb = new StringBuilder();
                int rp = IRequest.GetFormInt("rp", 10);
                int page = IRequest.GetFormInt("page", 1);
                string keyword = Utils.chkSQL(IRequest.GetFormString("query"));
                string sql = "select distinct top " + rp + " sysobjects.id,sysobjects.name,sysobjects.crdate from sysobjects,syscolumns where sysobjects.id = syscolumns.id and sysobjects.type='u' and sysobjects.status>0";
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    if (keyword.Length > 0)
                    {

                        sql = sql + " and sysobjects.name like '%" + keyword + "%'";
                    }
                    sql = sql + " and sysobjects.id not in ( select distinct top " + rp * (page - 1) + " sysobjects.id from sysobjects,syscolumns where sysobjects.id = syscolumns.id and sysobjects.type='u' and sysobjects.status>0 order by sysobjects.id desc) order by sysobjects.id desc";
                    //sql = sql + " order by sysobjects.id desc";
                    int totalcount = int.Parse(session.ExecuteScalar("select count(id) from sysobjects where sysobjects.type='u' and sysobjects.status>0"));
                    sb.Append("{\n");
                    sb.Append("\"page\":" + page.ToString() + ",\n");
                    sb.Append("\"total\":" + totalcount.ToString() + ",\n");
                    sb.Append("\"rows\": [\n");
                    DataTable formdt = session.GetTable(sql);
                    for (int i = 0; i < formdt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\"]", formdt.Rows[i]["id"].ToString(), formdt.Rows[i]["id"].ToString(), FormatJsonData(formdt.Rows[i]["name"].ToString()), formdt.Rows[i]["crdate"].ToString()));
                        if ((i + 1) == formdt.Rows.Count)
                        {
                            sb.Append("}\n");
                        }
                        else
                        {
                            sb.Append("},\n");
                        }
                    }
                    formdt.Dispose();
                    sb.Append("]\n");
                    sb.Append("}");
                }
                return sb.ToString();
            }
            else if(dbtype.ToLower() == "dcsqlite")
            {
                StringBuilder sb = new StringBuilder();
                int rp = IRequest.GetFormInt("rp", 10);
                int page = IRequest.GetFormInt("page", 1);
                string keyword = Utils.chkSQL(IRequest.GetFormString("query"));
               // string sql = "select distinct top " + rp + " sysobjects.id,sysobjects.name,sysobjects.crdate from sysobjects,syscolumns where sysobjects.id = syscolumns.id and sysobjects.type='u' and sysobjects.status>0";
                string sql = "SELECT name FROM sqlite_master WHERE type='table' and name!='sqlite_sequence'";
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    if (keyword.Length > 0)
                    {

                        sql = sql + " and name like '%" + keyword + "%'";
                    }
                   // sql = sql + " and sysobjects.id not in ( select distinct top " + rp * (page - 1) + " sysobjects.id from sysobjects,syscolumns where sysobjects.id = syscolumns.id and sysobjects.type='u' and sysobjects.status>0 order by sysobjects.id desc) order by sysobjects.id desc";
                    //sql = sql + " order by sysobjects.id desc";
                    sql = sql + " order by name asc limit " + (page - 1) * rp + "," + rp;
                    int totalcount = int.Parse(session.ExecuteScalar("select count(name) from sqlite_master WHERE type='table' and name!='sqlite_sequence'"));
                    sb.Append("{\n");
                    sb.Append("\"page\":" + page.ToString() + ",\n");
                    sb.Append("\"total\":" + totalcount.ToString() + ",\n");
                    sb.Append("\"rows\": [\n");
                    DataTable formdt = session.GetTable(sql);
                    for (int i = 0; i < formdt.Rows.Count; i++)
                    {
                        sb.Append("{");
                        sb.Append(string.Format("\"id\":\"{0}\",\"cell\":[\"{1}\",\"{2}\",\"{3}\"]", ((page - 1) * rp + i + 1).ToString(), ((page - 1) * rp + i + 1).ToString(), FormatJsonData(formdt.Rows[i]["name"].ToString()), DateTime.Now.ToShortDateString()));
                        if ((i + 1) == formdt.Rows.Count)
                        {
                            sb.Append("}\n");
                        }
                        else
                        {
                            sb.Append("},\n");
                        }
                    }
                    formdt.Dispose();
                    sb.Append("]\n");
                    sb.Append("}");
                }
                return sb.ToString();
            }
            string str="{\"page\":1,\"total\":1,\"rows\": [{\"id\":\"1\",\"cell\":[\"1\",\"表不存在\",\"2012-3-21\"]}]}";
            return str;
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <returns>string</returns>
        private string doESql()
        {

            string strsql = IRequest.GetFormString("areasql");
            StringBuilder sb=new StringBuilder();
            try
            {
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    if (strsql.Substring(0, 6).ToLower() == "select")//执行查询语句
                    {
                        DataTable formdt = session.GetTable(strsql);
                        if (formdt.Rows.Count > 0)
                        {
                            sb.Append("<table border='0' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC'>");
                            sb.Append("<tr>");
                            for (int i = 0; i < formdt.Columns.Count; i++)
                            {
                                sb.Append("<td nowrap bgcolor='F4F4EA' height='26'><div align='center'>");
                                sb.Append(formdt.Columns[i].ToString());
                                sb.Append("</div></td>");
                            }
                            sb.Append(" </tr>");

                            for (int j = 0; j < formdt.Rows.Count; j++)
                            {

                                sb.Append("<tr height='20' nowrap bgcolor='#ffffff' onMouseOver=\"this.style.background='#F5f5f5'\" onMouseOut=\"this.style.background='#FFFFFF'\">");
                                for (int c = 0; c < formdt.Columns.Count; c++)
                                {
                                    sb.Append("<td><div align='center'>");
                                    sb.Append(Convert.ToString(formdt.Rows[j][c]));
                                    sb.Append("</div></td>");
                                }
                                sb.Append("</tr>");
                            }
                            sb.Append("</table>");
                        }
                        formdt.Dispose();
                        return sb.ToString();
                    }
                    else
                    {
                        session.simple(strsql);
                        Random rnd=new Random();
                        return "<table border='0' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC'><tr><td nowrap bgcolor='F4F4EA' height='26'><div align='center' style='color:green'>语句成功执行("+rnd.Next(100)+")[数字有变说明有更新不是表示更新的行数]</div></td></tr></table>";
                    }
                   
                }
            }
            catch(Exception ex)
            {
                return "<table border='0' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC'><tr width='100%'><td  bgcolor='F4F4EA'><div align='center' style='color:red'>" + ex.Message + "</div></td></tr></table>";
            }

            

        }
          /// <summary>
        /// 查看sql帮助
        /// </summary>
        /// <returns>string</returns>
        private string doViewSqlHelp()
        {
            if (IRequest.GetFormString("id")=="2")
            {
                if (Utils.FileExists(Request.MapPath("help.htm")))
                {
                    return FileManage.ReadTextFile(Request.MapPath("help.htm"), "utf8");
                }
            }
            else if (IRequest.GetFormString("id") == "3")
            {
                if (Utils.FileExists(Request.MapPath("sqlitehelp.html")))
                {
                    return FileManage.ReadTextFile(Request.MapPath("sqlitehelp.html"), "utf8");
                }
            }
            
                return "文档不存在。";
        }
        /// <summary>
        /// 查看表字段
        /// </summary>
        /// <returns>string</returns>
        private string doFieldShow()
        {
            if (dbtype.ToLower() != "dcsqlite")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table width='100%' border='1' style='margin-bottom: 5px; font-size: 12px; font-weight: bold;'  height='80' cellspacing='0' cellpadding='0'>");
                int tableid = IRequest.GetQueryInt("tableid");
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    string sql = "select  syscolumns.name,systypes.name from sysobjects,syscolumns,systypes where sysobjects.id = syscolumns.id and sysobjects.type='u' and sysobjects.status>0 and systypes.xtype=syscolumns.xtype and systypes.name!='sysname' and sysobjects.id=" + tableid;
                    DataTable dt = session.GetTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        sb.Append("<tr><td style='height:25px;' width='120' align='center'>字段名称</td><td width='220'align='center'>字段类型</td></tr>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            sb.Append("<tr><td style='height:25px;' width='120' align='center'>");
                            sb.Append(dt.Rows[i][0].ToString());
                            sb.Append("</td>");
                            sb.Append("<td width='220'align='center'>");
                            sb.Append(dt.Rows[i][1].ToString());
                            sb.Append("</td></tr>");
                        }
                        sb.Append("</table>");
                        dt.Dispose();
                        return sb.ToString();
                    }
                    else
                    {
                        dt.Dispose();
                        return "还没有创建字段。";
                    }
                }
            }
            else if (dbtype.ToLower() == "dcsqlite")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table width='100%' border='1' style='margin-bottom: 5px; font-size: 12px; font-weight: bold;'  height='80' cellspacing='0' cellpadding='0'>");
                string tablename = IRequest.GetQueryString("tablename");
                sb.Append("<tr><td style='height:25px;' width='220' align='center'>字段名称</td></tr>");
                using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
                {
                    string sql = "select * from " + tablename;
                    DataTable dt = session.GetTable(sql);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append("<tr><td style='height:25px;' width='220' align='center'>");
                        sb.Append(dt.Columns[i].ColumnName);
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    dt.Dispose();
                    return sb.ToString();
                }
            }
            return "表不存在。";

        }
        ///<summary>
        ///获取数据库类型
        ///</summary>
        ///<param name="qdbtype"></param>
        ///<return>string</return>
        private void GetDbType()
        {
            try
            {
                DataBaseSection sec = (DataBaseSection)ConfigurationManager.GetSection("Dcms.Orm/DataBase");
                string connstr = "";
                foreach (ConnectionItem item in sec.Items)
                {
                    dbtype = item.dbtype;
                    if (dbtype.ToLower() != "dcsqlite")
                    {
                        connstr = item.connectionstring;
                        string[] strar = connstr.Split(';');
                        for (int i = 0; i < strar.Length; i++)
                        {
                            if (i == 2)
                            {
                                continue;
                            }
                            if (i == 0)
                            {
                                conn = strar[i].Split('=')[1];
                                continue;
                            }
                            if (i == 1)
                            {
                                dbname = strar[i].Split('=')[1];
                                continue;
                            }
                            if (i == 3)
                            {
                                dbuser = strar[i].Split('=')[1];
                                continue;
                            }
                            if (i == 4)
                            {
                                dbpwd = strar[i].Split('=')[1];
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            
        }
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns>string</returns>
        private string doMakeCode()
        {

            try
            {
                StringBuilder code = new StringBuilder();
                code.Append(GetCode().ToString());
                string SavePath = Request.MapPath("~/App_Code");
                string Ns = dbtype + "_SqlDb";
                if (SavePath.EndsWith("\\"))
                {
                    SavePath += Ns + "_Entitys.cs";
                }
                else
                {
                    SavePath += "\\" + Ns + "_Entitys.cs";
                }
                using (StreamWriter sw = new StreamWriter(SavePath, false, UTF8Encoding.UTF8))
                {
                    sw.Write(code.ToString());
                    sw.Flush();
                    sw.Close();
                }
                return "true";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
           

        }
        private StringBuilder GetCode()
        {
            
            StringBuilder uss = new StringBuilder();
            List<string> usings = new List<string>();
            usings.Add("using System;");
            usings.Add("using System.Configuration;");
            usings.Add("using System.Collections.Generic;");
            usings.Add("using System.Data;");
            usings.Add("using System.Text;");
            usings.Add("using Dcms.Orm;");
            StringBuilder code = new StringBuilder();
            using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
            {
               code.Append(session.Context.TableSchema().PrintCode("SqlDb"));
                
                ;
                foreach (string us in session.Context.TableSchema().SpecialUsing)
                {
                    if (!usings.Contains(us))
                    {
                        usings.Add(us);
                    }
                }

                foreach (string us in usings)
                {
                    uss.Append(us).Append("\r\n");
                }
                code.Append("public class DateSettings\r\n");
                code.Append("{\r\n");
                code.Append("\tpublic const string ").Append("SqlDb").Append(" = \"").Append("SqlDb").Append("\";\r\n");
                code.Append("}\r\n");
                code = uss.Append(code);
            }
            return code;
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <returns>string</returns>
        private string doBackUp()
        {
           // return conn + "|" + dbname + "|" + dbuser + "|" + dbpwd;
            if (dbtype.ToLower() != "dcsqlite")
            {
                SQLDMO.Backup oBackup = new SQLDMO.BackupClass();
                SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
                try
                {

                    string bakname = IRequest.GetFormString("BackUp_Name");
                    string bakpath = "";
                    if (bakname.Contains(".bak"))
                    {
                        bakpath = Request.MapPath("~/app_data") + "\\" + bakname;
                    }
                    else
                    {
                        bakpath = Request.MapPath("~/app_data") + "\\" + bakname + ".bak";
                    }
                    oSQLServer.LoginSecure = false;
                    oSQLServer.Connect(conn, dbuser, dbpwd);
                    oBackup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
                    oBackup.Database = dbname;
                    oBackup.Files = bakpath;
                    oBackup.BackupSetName = bakname;
                    oBackup.BackupSetDescription = "数据库备份";
                    oBackup.Initialize = true;
                    oBackup.SQLBackup(oSQLServer);
                    return "备份成功！";

                }

                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    oSQLServer.DisConnect();
                }
            }
            else if(dbtype.ToLower()=="dcsqlite")
            {
                try
                {
                    string sourcename=Request.MapPath("~/app_data")+"\\DcmsDataBase.db";
                    string bakname = IRequest.GetFormString("BackUp_Name");
                    string bakpath = "";
                    if (bakname.Contains(".db"))
                    {
                        bakpath = Request.MapPath("~/app_data") + "\\" + bakname;
                    }
                    else
                    {
                        bakpath = Request.MapPath("~/app_data") + "\\" + bakname + ".db";
                    }
                   // DirectoryInfo di = new DirectoryInfo(Request.MapPath("~/app_data"));
                    if(File.Exists(bakpath))//备份文件已存在
                    {
                        return "该备份文件已存在，请换个名称。";
                    }
                    File.Copy(sourcename, bakpath,false);
                    return "备份成功！";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "找不到源数据库文件，备份失败！";
        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <returns>string</returns>
        private string doRestore()
        {
            string bakname = IRequest.GetFormString("BackUp_File");
            string bakpath = Request.MapPath("~\\App_Data") + "\\" + bakname;
            if (dbtype.ToLower() != "dcsqlite")
            {
                SQLDMO.Restore oRestore = new SQLDMO.RestoreClass();
                SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
                try
                {
                    oSQLServer.LoginSecure = false;
                    oSQLServer.Connect(conn, dbuser, dbpwd);
                    oRestore.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                    oRestore.Database = dbname;
                    oRestore.Files = bakpath;
                    oRestore.FileNumber = 1;
                    oRestore.ReplaceDatabase = true;
                    oRestore.SQLRestore(oSQLServer);
                    return "还原成功！";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    oSQLServer.DisConnect();
                }

            }
            else if (dbtype.ToLower() == "dcsqlite")
            {
                try
                {
                   string sourcename=Request.MapPath("~/app_data")+"\\DcmsDataBase.db";
                   File.Copy(bakpath, sourcename, true);
                   return "还原成功！";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "找不到源文件";
        }
        /// <summary>
        /// 获取备份文件列表
        /// </summary>
        /// <returns>string</returns>
        private string doGetBakList()
        {
            
            StringBuilder sb = new StringBuilder();
            if (dbtype.ToLower() != "dcsqlite")
            {
                DirectoryInfo di = new DirectoryInfo(Request.MapPath("/app_data"));
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {

                    if (file.Name.Contains(".bak"))
                    {
                        sb.Append("<a href='###' onclick=\"secbak('" + file.Name + "')\">" + file.Name + "</a>&nbsp;&nbsp;" + Convert.ToString(file.Length / 1024) + "kb" + "&nbsp;&nbsp;<a onclick=\"delbak('" + file.Name + "')\" href='###'>删除</a><br />");
                    }
                }
            }
            else if (dbtype.ToLower() == "dcsqlite")
            {
                DirectoryInfo di = new DirectoryInfo(Request.MapPath("/app_data"));
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {

                    if (file.Name.Contains(".db"))
                    {
                        sb.Append("<a href='###' onclick=\"secbak('" + file.Name + "')\">" + file.Name + "</a>&nbsp;&nbsp;" + Convert.ToString(file.Length / 1024) + "kb" + "&nbsp;&nbsp;<a onclick=\"delbak('" + file.Name + "')\" href='###'>删除</a><br />");
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 删除备份文件
        /// </summary>
        /// <returns>string</returns>
        private string doDelBak()
        {
            try
            {

                string bakname = IRequest.GetFormString("bakname");
                string baknamepath = Request.MapPath("~/app_data") + "\\" + bakname;
                if (File.Exists(baknamepath))
                {
                    File.Delete(baknamepath);
                    return "删除成功！";
                }
                return "该文件不存在";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}