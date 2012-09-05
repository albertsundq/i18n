using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Dcms.Orm;
using Dcms.Utility;

namespace Manage.BaseManage
{
    public partial class Manage_BaseManage_TempLateList : Dcms.BasePage.ManagePage
    {
        protected string TemplatePathStr = ConfigurationManager.AppSettings["TempLatePath"];
        protected string AspxPathStr = ConfigurationManager.AppSettings["AspxPath"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReBinder();
            }
        }
        protected void ReBinder()
        {
            this.repAdmin.DataSource = GetAllTemplateList();
            this.repAdmin.DataBind();
        }
        protected List<SqlDb.Dcms_TempLate> GetAllTemplateList()
        {
            List<SqlDb.Dcms_TempLate> tempList = new List<SqlDb.Dcms_TempLate>();
            string templatePath = Utils.GetMapPath(TemplatePathStr);
            DirectoryInfo dirinfo = new DirectoryInfo(templatePath);
            foreach (DirectoryInfo dir in dirinfo.GetDirectories())
            {
                SqlDb.Dcms_TempLate temp = new SqlDb.Dcms_TempLate();
                temp.Template_Author = "Dcms开发团队";
                temp.Template_Copyright = "三五互联";
                temp.Template_CreateTime = dir.CreationTime.ToString();
                temp.Template_Directory = dir.FullName;
                temp.Template_Fordntver = "NET Framework2.0以上";
                temp.Template_Name = dir.Name;
                temp.Template_State = 0;
                temp.Template_UpdateTime = "从未生成过";
                temp.Template_Ver = "Dcms 3.0";
                tempList.Add(temp);
            }
            return tempList;
        }

        protected void repAdmin_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int SucceedCount = 0, FailCount = 0, TemplateId = 0;
            string AlertStrInfo = "";
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (e.CommandName == "Create" || e.CommandName == "CreateAll")
                {
                    Label LabTempLateName = (Label)e.Item.FindControl("LabTempName");
                    FailCount = CreateTemplateByDirectory(e.CommandArgument.ToString(), e.CommandName, ref SucceedCount);
                    AlertStrInfo = "成功生成" + SucceedCount + "个模板,失败" + FailCount + "个模板！！！";
                    lit_CheckInfo.Text = "<div style=\"background-color:#EBFFE1;border:1px solid #65D229;height:23px;padding-left:20px;line-height:23px;\">" + AlertStrInfo + "</div>";
                    //Jscript.Alert(AlertStrInfo);

                }
                if (e.CommandName == "ChangeWebCode")
                {
                    FailCount = ChangeFileCode(e.CommandArgument.ToString(), ref SucceedCount);
                    AlertStrInfo = "成功转换" + SucceedCount + "个模板,失败" + FailCount + "个模板！！！";
                    lit_CheckInfo.Text = "<div style=\"background-color:#EBFFE1;border:1px solid #65D229;height:23px;padding-left:20px;line-height:23px;\">" + AlertStrInfo + "</div>";
                    //Jscript.Alert(AlertStrInfo);
                }
                if (e.CommandName == "From2To3")
                {
                    FailCount = From2To3(e.CommandArgument.ToString(), ref SucceedCount);
                    AlertStrInfo = "成功升级" + SucceedCount + "个模板,失败" + FailCount + "个模板！！！";
                    lit_CheckInfo.Text = "<div style=\"background-color:#EBFFE1;border:1px solid #65D229;height:23px;padding-left:20px;line-height:23px;\">" + AlertStrInfo + "</div>";
                    //Jscript.Alert(AlertStrInfo);
                }
            }
        }
        /// <summary>
        /// 模板升级转换
        /// </summary>
        /// <param name="TempName"></param>
        /// <param name="SucceedCount"></param>
        /// <returns></returns>
        protected int From2To3(string TempName, ref int SucceedCount)
        {
            int FailCount = 0;
            string templatePath = Utils.GetMapPath(TemplatePathStr) + "/" + TempName + "";
            DirectoryInfo myDirInfo = new DirectoryInfo(templatePath);
            foreach (FileInfo TempFile in myDirInfo.GetFiles())
            {
                string extname = TempFile.Extension.ToLower();
                if (extname.Equals(".htm") || extname.Equals(".html") || extname.Equals(".asp") || extname.Equals(".aspx") || extname.Equals(".ascx") || extname.Equals(".shtml"))
                {
                    if (File.Exists(TempFile.FullName))
                    {
                        try
                        {
                            //读出模板字符
                            //string TempFileContent = FileManage.ReadTextFile(TempFile.FullName);
                            string TempFileContent = string.Empty;
                            using (System.IO.StreamReader objReader = new System.IO.StreamReader(TempFile.FullName, Encoding.UTF8))
                            {
                                //读取开始
                                StringBuilder textOutput = new StringBuilder();
                                textOutput.Append(objReader.ReadToEnd());
                                objReader.Close();
                                TempFileContent = textOutput.ToString();
                            }

                            //IndexId替换
                            TempFileContent = TempFileContent.Replace("{Dcms.IndexId}", "{%#@@#%}");

                            StringBuilder pageSb = new StringBuilder();
                            pageSb.Append("<style>\n<!--\n");
                            pageSb.Append("#dcms_pager .pages {border:none;text-transform:uppercase;font-size:12px;margin:10px 0 10px 0;padding:0;height:20px;clear:both;text-align:center;}\n");
                            pageSb.Append("#dcms_pager .pages a {border:1px solid #ccc;text-decoration:none;margin:0 5px 0 0;padding:0 3px 0 3px;font-size:12px;height:16px;line-height:16px;}\n");
                            pageSb.Append("#dcms_pager .pages a:hover {border:1px solid #aeaeae;}\n");
                            pageSb.Append("#dcms_pager .pages .pgEmpty {border:1px solid #eee;color:#eee;}\n");
                            pageSb.Append("#dcms_pager .pages .pgCurrent {border:1px solid #aeaeae;color:#000;font-weight:bold;background-color:#eee;}\n");
                            pageSb.Append("-->\n</style>\n");
                            pageSb.Append("<div id=\"dcms_pager\">\n<div class=pages>\n");
                            pageSb.Append("<a class=pgnext>first</a><a class=pgnext>prev</a><a>1</a><a>2</a><a>3</a><a>4</a><a class=\"page-number pgcurrent\">5</a>\n");
                            pageSb.Append("<a>6</a><a>7</a><a>8</a><a>9</a><a class=pgnext>next</a><a class=pgnext>last</a>\n");
                            pageSb.Append("</div>\n</div>\n<script>renderDcmsPager('|<','<<','>>','>|');</script>");
                            //分页替换
                            TempFileContent = Regex.Replace(TempFileContent, "{System.Controls,[MynetPageListDefault|MynetPageList]*}", pageSb.ToString(), RegexOptions.IgnoreCase);
                            //字段替换
                            TempFileContent = Replace2FieldNormal(TempFileContent);
                            TempFileContent = Replace2FieldSpecial(TempFileContent);
                            
                            IList<string> RepeaterPropertyTags = RegexGetTempTag("<!--Repeater[^>]*-->", TempFileContent);
                            foreach (string RepProTag in RepeaterPropertyTags)
                            {
                                string Module = RegexGetRepProperty("<!--Repeater[^>]*Module(\\s)*=(\\s)*(\"){1}(?<Module>(\\w+)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "Module");
                                if (Module.ToLower().Equals("intro"))
                                {
                                    Module = "BaseInfo";
                                }
                                string Where = " " + Module + "_State='1' ";
                                string Condition = RegexGetRepProperty("<!--Repeater[^>]*Condition(\\s)*=(\\s)*(\"){1}(?<Condition>([\\w|.|,]*)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "Condition");
                                if (Condition.Trim().Length > 0)
                                {
                                    string[] ConditionArr = Utils.SplitString(Condition, ",");
                                    foreach (string conditionstr in ConditionArr)
                                    {
                                        Where = Where + "and " + conditionstr.Replace(".", "_") + "='1' ";
                                    }
                                }

                                string ParaName = RegexGetRepProperty("<!--Repeater[^>]*ParaName(\\s)*=(\\s)*(\"){1}(?<ParaName>([\\w|,]*)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "ParaName");
                                string[] ParaNameArr = Utils.SplitString(ParaName, ",");

                                string ParaType = RegexGetRepProperty("<!--Repeater[^>]*ParaType(\\s)*=(\\s)*(\"){1}(?<ParaName>([\\w|,]*)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "ParaType");
                                string[] ParaTypeArr = Utils.SplitString(ParaType, ",");

                                string DefaultValue = RegexGetRepProperty("<!--Repeater[^>]*DefaultValue(\\s)*=(\\s)*(\"){1}(?<DefaultValue>([\\w|,]*)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "DefaultValue");
                                string[] DefaultValueArr = Utils.SplitString(DefaultValue, ",");

                                for (int i = 0; i < ParaNameArr.Length; i++)
                                {
                                    if (i < ParaTypeArr.Length)
                                    {
                                        ParaType = ParaTypeArr[i].ToLower();
                                    }
                                    else
                                    {
                                        ParaType = "query";
                                    }
                                    if (i < DefaultValueArr.Length)
                                    {
                                        DefaultValue = DefaultValueArr[i];
                                    }
                                    else
                                    {
                                        DefaultValue = "1";
                                    }
                                    ParaName = ParaNameArr[i].ToLower();
                                    if (ParaName.EndsWith("cateid"))
                                    {
                                        ParaName = Module + "_CateId";
                                        if (ParaType.Equals("query"))
                                        {
                                            Where = Where + "and #" + ParaName + "={Get." + ParaNameArr[i] + "," + DefaultValue + "}# ";
                                        }
                                        else
                                        {
                                            Where = Where + "and #" + ParaName + "=" + DefaultValue + "# ";
                                        }
                                    }
                                    else if (ParaName.EndsWith("id"))
                                    {
                                        ParaName = Module + "_Id";
                                        if (ParaType.Equals("query"))
                                        {
                                            Where = Where + "and " + ParaName + "={Get." + ParaNameArr[i] + "," + DefaultValue + "} ";
                                        }
                                        else
                                        {
                                            Where = Where + "and " + ParaName + "=" + DefaultValue + " ";
                                        }
                                    }
                                    else
                                    {
                                        ParaName = Module + "_Title";
                                        Where = Where + "and " + ParaName + " like '%{Get.KeyWord," + DefaultValue + "}%' ";
                                    }
                                }

                                string SelectDir = RegexGetRepProperty("<!--Repeater[^>]*SelectDir(\\s)*=(\\s)*(\"){1}(?<SelectDir>(\\w+)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "SelectDir");
                                string Num = RegexGetRepProperty("<!--Repeater[^>]*Num(\\s)*=(\\s)*(\"){1}(?<Num>(\\w+)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "Num");
                                string IsPage = RegexGetRepProperty("<!--Repeater[^>]*IsPage(\\s)*=(\\s)*(\"){1}(?<IsPage>(\\w+)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "IsPage");
                                string Order = RegexGetRepProperty("<!--Repeater[^>]*Order(\\s)*=(\\s)*(\"){1}(?<Order>([\\w|.]*)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "Order");
                                if (Order.Trim().Length > 0)
                                {
                                    Order = Order.Replace(".", "_");
                                    if (Order.ToLower().StartsWith("intro"))
                                    {
                                        Order = Order.ToLower().Replace("intro", "BaseInfo");
                                    }
                                }
                                else
                                {
                                    Order = Module + "_Id";
                                }
                                string Sort = RegexGetRepProperty("<!--Repeater[^>]*Sort(\\s)*=(\\s)*(\"){1}(?<Sort>(\\w+)?)(\"){1}(\\s)*[^>]*-->", RepProTag, "Sort");

                                string NewRepProTag = "<!--Repeater TableName=\"Dcms_" + Module + "\" Where=\"" + Where + "\" OrderBy=\"" + Order + " " + Sort + "\" SqlType=\"select\" PrimaryKey=\"" + Module + "_Id\" SelectDir=\"" + SelectDir + "\" PageSize=\"" + Num + "\" IsPage=\"" + IsPage + "\"-->";
                                TempFileContent = TempFileContent.Replace(RepProTag, NewRepProTag);
                            }
                            //IndexId还原
                            TempFileContent = TempFileContent.Replace("{%#@@#%}", "{Dcms.IndexId}");
                            TempFileContent = TempFileContent.Replace("Cate_CateId=", "Cate_Id=");
                            //FileManage.SaveTextFile(TempFile.FullName, TempFileContent, "utf-8");

                            //生成aspx.cs/ascx.cs
                            

                            using (FileStream fs = new FileStream(TempFile.FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                Byte[] info = System.Text.Encoding.UTF8.GetBytes(TempFileContent);
                                fs.Write(info, 0, info.Length);
                                fs.Close();
                            }

                            SucceedCount++;
                        }
                        catch
                        {
                            FailCount++;
                        }
                    }
                }
            }
            return FailCount;
        }
        /// <summary>
        /// 匹配2.0特殊的字段
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string Replace2FieldSpecial(string template)
        {
            Regex regex = new Regex("{(?<Table>(\\w+)?)\\.(?<Field>(\\w+)?),(?<Format>([\\w|-]+)?)}", RegexOptions.IgnoreCase);
            return regex.Replace(template, new MatchEvaluator(this.MatchReplace2FieldSpecial));
        }
        /// <summary>
        /// 正则匹配中的委托定义
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string MatchReplace2FieldSpecial(Match m)
        {
            string Table = m.Groups["Table"].Captures[0].Value;
            if (Table.ToLower().Equals("intro"))
            {
                Table = "BaseInfo";
            }
            string Field = m.Groups["Field"].Captures[0].Value;
            if (Field.ToLower().Equals("name"))
            {
                Field = "Title";
            }
            string Format = m.Groups["Format"].Captures[0].Value;
            return "{Dcms_" + Table + "." + Table + "_" + Field + "," + Format + "}";
        }
        /// <summary>
        /// 匹配2.0常规的字段
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private string Replace2FieldNormal(string template)
        {
            Regex regex = new Regex("{(?<Table>(\\w+)?)\\.(?<Field>(\\w+)?)}", RegexOptions.IgnoreCase);
            return regex.Replace(template, new MatchEvaluator(this.MatchReplace2FieldNormal));
        }
        /// <summary>
        /// 正则匹配中的委托定义
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string MatchReplace2FieldNormal(Match m)
        {
            string Table = m.Groups["Table"].Captures[0].Value;
            if (Table.ToLower().Equals("intro"))
            {
                Table = "BaseInfo";
            }
            string Field = m.Groups["Field"].Captures[0].Value;
            if (Field.ToLower().Equals("name"))
            {
                Field = "Title";
            }
            return "{Dcms_" + Table + "." + Table + "_" + Field + "}";
        }
        /// <summary>
        /// 生成模板
        /// </summary>
        /// <param name="TempName"></param>
        /// <param name="CreateType"></param>
        /// <param name="SucceedCount"></param>
        /// <returns></returns>
        private int CreateTemplateByDirectory(string TempName, string CreateType, ref int SucceedCount)
        {
            #region 生成模板
            int FailCount = 0, ReturnFlag = 0;
            //TemplatePathStr = Server.MapPath(TemplatePathStr);
            string templatePath = Utils.GetMapPath(TemplatePathStr) + "/" + TempName + "";
            string aspxPath = Utils.GetMapPath(AspxPathStr) + "/" + TempName + "";
            DirectoryInfo myDirInfo = new DirectoryInfo(templatePath);
            foreach (FileInfo TempFile in myDirInfo.GetFiles())
            {
                string extname = TempFile.Extension.ToLower();
                if (extname.Equals(".htm") || extname.Equals(".html") || extname.Equals(".asp") || extname.Equals(".aspx") || extname.Equals(".ascx") || extname.Equals(".shtml"))
                {
                    if (CreateType == "Create")
                    {
                        if (Utils.GetDiffDate(TempFile.LastWriteTime, DateTime.Now, 3) < 4)
                        {
                            ReturnFlag = CreateTempLate(extname, TempFile.Name, aspxPath, templatePath);
                            if (ReturnFlag == 0)
                            {
                                SucceedCount++;
                            }
                            else
                            {
                                FailCount++;
                            }
                        }
                    }
                    else
                    {
                        ReturnFlag = CreateTempLate(extname, TempFile.Name, aspxPath, templatePath);
                        if (ReturnFlag == 0)
                        {
                            SucceedCount++;
                        }
                        else
                        {
                            FailCount++;
                        }
                    }
                }
            }
            return FailCount;
            #endregion
        }
        /// <summary>
        /// 统一编码
        /// </summary>
        /// <param name="TempName"></param>
        /// <param name="SucceedCount"></param>
        /// <returns></returns>
        protected int ChangeFileCode(string TempName, ref int SucceedCount)
        {
            int FailCount = 0;
            string templatePath = Utils.GetMapPath(TemplatePathStr) + "/" + TempName + "";
            DirectoryInfo myDirInfo = new DirectoryInfo(templatePath);
            foreach (FileInfo TempFile in myDirInfo.GetFiles())
            {
                string extname = TempFile.Extension.ToLower();
                if (extname.Equals(".htm") || extname.Equals(".html") || extname.Equals(".asp") || extname.Equals(".aspx") || extname.Equals(".ascx") || extname.Equals(".shtml"))
                {
                    if (File.Exists(TempFile.FullName))
                    {
                        try
                        {
                            string TempFileContent = FileManage.ReadTextFile(TempFile.FullName);

                            FileManage.SaveTextFile(TempFile.FullName, TempFileContent, "utf-8");
                            SucceedCount++;
                        }
                        catch (Exception ex)
                        {
                            FailCount++;
                        }
                    }
                }
            }
            return FailCount;
        }
        public string ValidCreateState(string valid)
        {
            #region 生成状态图标
            if (valid == "1")
            {
                return "<img src=../../images/state2.gif />";
            }
            else
            {
                return "<img src=../../images/state3.gif />";
            }
            #endregion
        }
        protected string ValidTempFilePath(string PathInfo)
        {
            string WebSitePath = Request.ServerVariables["APPL_PHYSICAL_PATH"];
            PathInfo = PathInfo.Substring(WebSitePath.Length, PathInfo.Length - WebSitePath.Length);
            PathInfo = PathInfo.Replace('\\', '/');
            return PathInfo;
        }

        /// <summary>
        /// 生成aspx页面或是ascx页面
        /// </summary>
        /// <param name="extName">扩展名</param>
        /// <param name="fileFullName">文件命名</param>
        /// <param name="aspxFolderName">保存的aspx路径</param>
        /// <param name="tempFolderName">模板文件路径</param>
        /// <returns></returns>
        public int CreateTempLate(string extname, string filefullname, string aspxFolderName, string tempFolderName)
        {
            int ReturnFlage = 0;
            try
            {
                //检测是否要进行编译的文件类型
                if (extname.Equals(".htm") || extname.Equals(".html") || extname.Equals(".asp") || extname.Equals(".aspx"))
                {
                    string filename = filefullname.Split('.')[0];
                    //检查是否共用文件
                    if (filefullname.StartsWith("_"))
                    {
                        ReadHtmlAndDoAscx(filename, extname, aspxFolderName, tempFolderName);
                    }
                    else
                    {
                        ReadHtmlAndDoAspx(filename, extname, aspxFolderName, tempFolderName);
                    }
                }
                ReturnFlage = 0;
            }
            catch
            {
                ReturnFlage = 1;
            }
            return ReturnFlage;
        }
        /// <summary>
        /// 读取模板并并生成aspx
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="DirectoryName"></param>
        /// <param name="ExtName"></param>
        private void ReadHtmlAndDoAspx(string FileName, string ExtName, string aspxFolderName, string tempFolderName)
        {
            string headString = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + FileName + ".aspx.cs\" Inherits=\"_" + FileName + "_aspx\" EnableViewState=\"false\" %>\n<%@ Register Assembly=\"Dcms.Controls\" Namespace=\"Dcms.Controls\" TagPrefix=\"Dcms\" %>\n";
            string fileDir = aspxFolderName + "/";
            string inputPath = tempFolderName + "/" + FileName + ExtName;
            string subFolder = "";
            StringBuilder csSb = new StringBuilder();
            csSb.Append("using System;\n");
            csSb.Append("using System.Collections;\n");
            csSb.Append("using System.Configuration;\n");
            csSb.Append("using System.Data;\n");
            csSb.Append("using System.Web;\n");
            csSb.Append("using System.Web.Security;\n");
            csSb.Append("using System.Web.UI;\n");
            csSb.Append("using System.Web.UI.HtmlControls;\n");
            csSb.Append("using System.Web.UI.WebControls;\n");
            csSb.Append("using System.Web.UI.WebControls.WebParts;\n\n");
            csSb.Append("public partial class _" + FileName + "_aspx : System.Web.UI.Page\n{\n");
            csSb.Append("\tprotected void Page_Load(object sender, EventArgs e)\n\t{}\n}");
            MakeCore(inputPath, FileName, "aspx", headString, subFolder, fileDir, csSb.ToString());
        }
        /// <summary>
        /// 读取模板并并生成ascx
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="DirectoryName"></param>
        /// <param name="ExtName"></param>
        private void ReadHtmlAndDoAscx(string FileName, string ExtName, string aspxFolderName, string tempFolderName)
        {
            string headString = "<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + FileName + ".ascx.cs\" Inherits=\"" + FileName + "_ascx\" EnableViewState=\"false\" %>\n<%@ Register Assembly=\"Dcms.Controls\" Namespace=\"Dcms.Controls\" TagPrefix=\"Dcms\" %>\n";
            string fileDir = aspxFolderName + "/";
            string inputPath = tempFolderName + "/" + FileName + ExtName;
            string subFolder = "Ascx";
            StringBuilder csSb = new StringBuilder();
            csSb.Append("using System;\n");
            csSb.Append("using System.Collections;\n");
            csSb.Append("using System.Configuration;\n");
            csSb.Append("using System.Data;\n");
            csSb.Append("using System.Web;\n");
            csSb.Append("using System.Web.Security;\n");
            csSb.Append("using System.Web.UI;\n");
            csSb.Append("using System.Web.UI.HtmlControls;\n");
            csSb.Append("using System.Web.UI.WebControls;\n");
            csSb.Append("using System.Web.UI.WebControls.WebParts;\n\n");
            csSb.Append("public partial class " + FileName + "_ascx : System.Web.UI.UserControl\n{\n");
            csSb.Append("\tprotected void Page_Load(object sender, EventArgs e)\n\t{}\n}");
            MakeCore(inputPath, FileName, "ascx", headString, subFolder, fileDir, csSb.ToString());
        }
        /// <summary>
        /// 模板解析生成核心
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="toFileExt"></param>
        /// <param name="headString"></param>
        /// <param name="subFolder"></param>
        private void MakeCore(string inputPath, string toFileName, string toFileExt, string headString, string subFolder, string fileDir, string csSb)
        {
            //如果指定风格的模板文件不存在...
            if (System.IO.File.Exists(inputPath))
            {
                using (System.IO.StreamReader objReader = new System.IO.StreamReader(inputPath, Encoding.UTF8))
                {
                    //读取开始
                    StringBuilder textOutput = new StringBuilder();
                    textOutput.Append(objReader.ReadToEnd());
                    objReader.Close();
                    string Temp = textOutput.ToString();
                    //处理形如{@Session.Key,DefaultValue}开始
                    Regex regG = new Regex("{@(?<TypeName>\\w+).(?<Key>.*?),(?<DefaultValue>.*?)}", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    MatchCollection matchesG = regG.Matches(Temp);
                    for (int i = 0; i < matchesG.Count; i++)
                    {
                        string TypeName = matchesG[i].Groups["TypeName"].Value.ToLower();
                        string Key = matchesG[i].Groups["Key"].Value;
                        string DefaultValue = matchesG[i].Groups["DefaultValue"].Value;
                        Temp = Temp.Replace(matchesG[i].Value.ToString(), "<%=Dcms.Controls.Utility.G" + TypeName + "(\"" + Key + "\",\"" + DefaultValue + "\")%>");
                    }
                    //处理形如{@Session.Key,DefaultValue}结束

                    Temp = Regex.Replace(Temp, "</head>", "<script src=\"/sysaspx/common.js\" type=\"text/javascript\"></script>\n</head>", RegexOptions.IgnoreCase);
                    //读取结束
                    //处理<!--#include file="***.***"-->开始
                    Regex reg = new Regex("<!--[^>]*File(\\s)*=(\\s)*(\")*(\\s)*(?<InFile>([^>]+)?)\\.\\w+(\\s)*(\")*(\\s)*[^>]*-->", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    MatchCollection matches = reg.Matches(Temp);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        string inFileName = matches[i].Groups["InFile"].Value;
                        if (toFileExt.Equals("ascx"))
                        {
                            //对于相同的用户组件不重复引用
                            if (!(headString.IndexOf("<%@ Register Src=\"" + inFileName + ".ascx\" TagName=\"" + inFileName + "\" TagPrefix=\"Dcms\" %>",StringComparison.CurrentCultureIgnoreCase) >= 0))
                            {
                                headString = headString + "<%@ Register Src=\"" + inFileName + ".ascx\" TagName=\"" + inFileName + "\" TagPrefix=\"Dcms\" %>\n";
                            }
                        }
                        else
                        {
                            //对于相同的用户组件不重复引用
                            if (!(headString.IndexOf("<%@ Register Src=\"Ascx/" + inFileName + ".ascx\" TagName=\"" + inFileName + "\" TagPrefix=\"Dcms\" %>", StringComparison.CurrentCultureIgnoreCase) >= 0))
                            {
                                headString = headString + "<%@ Register Src=\"Ascx/" + inFileName + ".ascx\" TagName=\"" + inFileName + "\" TagPrefix=\"Dcms\" %>\n";
                            }
                        }
                        
                        Temp = Temp.Replace(matches[i].Value.ToString(), "<Dcms:" + inFileName + " ID=\"" + inFileName + "_" + i + "\" runat=\"server\" />");
                    }
                    //处理<!--#include file="***.***"-->结束

                    //处理{System.Controls,(?<SysAscxName>([^}]*)?)}开始
                    Regex regSysAscx = new Regex("{System.Controls,(?<SysAscxName>([^}]*)?)}", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    MatchCollection matchesSysAscx = regSysAscx.Matches(Temp);
                    for (int i = 0; i < matchesSysAscx.Count; i++)
                    {
                        string SysAscxName = matchesSysAscx[i].Groups["SysAscxName"].Value;
                        headString = headString + "<%@ Register Src=\"/sysaspx/" + SysAscxName + ".ascx\" TagName=\"" + SysAscxName + "\" TagPrefix=\"Dcms\" %>\n";
                        Temp = Temp.Replace(matchesSysAscx[i].Value.ToString(), "<Dcms:" + SysAscxName + " ID=\"" + SysAscxName + "_" + i + "\" runat=\"server\" />");
                    }
                    //处理{System.Controls,(?<SysAscxName>([^}]*)?)}结束

                    string RegexStr = "<!--(.*?)Repeater(.*?)-->";
                    IList<string> TempTag = new List<string>();
                    TempTag = RegexGetTempTag(RegexStr, Temp);

                    IList<int> TempTagPosition = new List<int>();
                    TempTagPosition = RegexGetTempTagPosition(RegexStr, Temp);

                    int RegexNmu = 0;
                    int PreNum = 0;
                    //用来存完整的Repeater字符串
                    IList<string> RepeaterTemps = new List<string>();

                    for (int i = 0; i < TempTag.Count; i++)
                    {
                        if (new Regex(@"^<!--Repeater(.*?)-->$").IsMatch(TempTag[i].ToString()))
                        {
                            RegexNmu = RegexNmu + 1;
                        }
                        else
                        {
                            RegexNmu = RegexNmu - 1;
                        }
                        if (RegexNmu == 0)
                        {
                            int star = TempTagPosition[PreNum];
                            int len = TempTagPosition[i] + TempTag[i].Length - star;
                            RepeaterTemps.Add(Temp.Substring(star, len));
                            PreNum = i + 1;
                        }
                    }
                    //输出独立的Repeater
                    for (int i = 0; i < RepeaterTemps.Count; i++)
                    {
                        IList<string> ItemTag = GetRepeaterSplit(RepeaterTemps[i]);
                        string temp2 = string.Empty;
                        string tempRepeaterStyle = string.Empty;
                        //参数定义
                        string TableName = string.Empty;
                        string PageSize = string.Empty;
                        string IsPage = string.Empty;
                        string SqlType = string.Empty;
                        string Where = string.Empty;
                        string PrimaryKey = string.Empty;
                        string FieldName = string.Empty;
                        string FieldValue = string.Empty;
                        string OrderBy = string.Empty;
                        string Children = string.Empty;
                        string SelectDir = string.Empty;
                        string SwitchDb = string.Empty;
                        for (int b = 0; b < ItemTag.Count; b++)
                        {
                            if (b == 0)
                            {
                                TableName = RegexGetRepProperty("<!--Repeater.*?TableName(\\s)*=(\\s)*(\"){1}(?<TableName>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "TableName");
                                PageSize = RegexGetRepProperty("<!--Repeater.*?PageSize(\\s)*=(\\s)*(\"){1}(?<PageSize>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "PageSize");
                                OrderBy = RegexGetRepProperty("<!--Repeater.*?OrderBy(\\s)*=(\\s)*(\"){1}(?<OrderBy>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "OrderBy");
                                IsPage = RegexGetRepProperty("<!--Repeater.*?IsPage(\\s)*=(\\s)*(\"){1}(?<IsPage>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "IsPage");
                                SqlType = RegexGetRepProperty("<!--Repeater.*?SqlType(\\s)*=(\\s)*(\"){1}(?<SqlType>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SqlType");
                                Where = RegexGetRepProperty("<!--Repeater.*?Where(\\s)*=(\\s)*(\"){1}(?<Where>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "Where");
                                FieldName = RegexGetRepProperty("<!--Repeater.*?FieldName(\\s)*=(\\s)*(\"){1}(?<FieldName>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "FieldName");
                                FieldValue = RegexGetRepProperty("<!--Repeater.*?FieldValue(\\s)*=(\\s)*(\"){1}(?<FieldValue>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "FieldValue");
                                Children = RegexGetRepProperty("<!--Repeater.*?Children(\\s)*=(\\s)*(\"){1}(?<Children>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "Children");
                                SelectDir = RegexGetRepProperty("<!--Repeater.*?SelectDir(\\s)*=(\\s)*(\"){1}(?<SelectDir>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SelectDir");
                                PrimaryKey = RegexGetRepProperty("<!--Repeater.*?PrimaryKey(\\s)*=(\\s)*(\"){1}(?<PrimaryKey>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "PrimaryKey");
                                SwitchDb = RegexGetRepProperty("<!--Repeater.*?SwitchDb(\\s)*=(\\s)*(\"){1}(?<SwitchDb>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SwitchDb");
                            }
                            else
                            {
                                TableName = TableName + "|" + RegexGetRepProperty("<!--Repeater.*?TableName(\\s)*=(\\s)*(\"){1}(?<TableName>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "TableName");
                                PageSize = PageSize + "|" + RegexGetRepProperty("<!--Repeater.*?PageSize(\\s)*=(\\s)*(\"){1}(?<PageSize>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "PageSize");
                                OrderBy = OrderBy + "|" + RegexGetRepProperty("<!--Repeater.*?OrderBy(\\s)*=(\\s)*(\"){1}(?<OrderBy>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "OrderBy");
                                IsPage = IsPage + "|" + RegexGetRepProperty("<!--Repeater.*?IsPage(\\s)*=(\\s)*(\"){1}(?<IsPage>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "IsPage");
                                SqlType = SqlType + "|" + RegexGetRepProperty("<!--Repeater.*?SqlType(\\s)*=(\\s)*(\"){1}(?<SqlType>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SqlType");
                                Where = Where + "|" + RegexGetRepProperty("<!--Repeater.*?Where(\\s)*=(\\s)*(\"){1}(?<Where>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "Where");
                                FieldName = FieldName + "|" + RegexGetRepProperty("<!--Repeater.*?FieldName(\\s)*=(\\s)*(\"){1}(?<FieldName>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "FieldName");
                                FieldValue = FieldValue + "|" + RegexGetRepProperty("<!--Repeater.*?FieldValue(\\s)*=(\\s)*(\"){1}(?<FieldValue>.*?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "FieldValue");
                                Children = Children + "|" + RegexGetRepProperty("<!--Repeater.*?Children(\\s)*=(\\s)*(\"){1}(?<Children>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "Children");
                                SelectDir = SelectDir + "|" + RegexGetRepProperty("<!--Repeater.*?SelectDir(\\s)*=(\\s)*(\"){1}(?<SelectDir>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SelectDir");
                                PrimaryKey = PrimaryKey + "|" + RegexGetRepProperty("<!--Repeater.*?PrimaryKey(\\s)*=(\\s)*(\"){1}(?<PrimaryKey>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "PrimaryKey");
                                SwitchDb = SwitchDb + "|" + RegexGetRepProperty("<!--Repeater.*?SwitchDb(\\s)*=(\\s)*(\"){1}(?<SwitchDb>(\\w+)?)(\"){1}(\\s)*(.*?)-->", ItemTag[b], "SwitchDb");
                            }
                            temp2 = temp2 + formatString(ItemTag[b], b);
                        }
                        temp2 = "<Dcms:Drepeater ID=\"Repeater" + i + "\" runat=\"server\" SqlType=\"" + SqlType + "\" SelectDir=\"" + SelectDir + "\" SwitchDb=\"" + SwitchDb + "\" PrimaryKey=\"" + PrimaryKey + "\" TotalLayer=\"" + ItemTag.Count + "\" TableName=\"" + TableName + "\" FieldName=\"" + FieldName + "\" FieldValue=\"" + FieldValue + "\" Children=\"" + Children + "\" PageSize=\"" + PageSize + "\" IsPage=\"" + IsPage + "\" Where=\"" + Where + "\" OrderBy=\"" + OrderBy + "\"" + ">\n" + temp2 + "</Dcms:Drepeater>\n";
                        Temp = Temp.Replace(RepeaterTemps[i], temp2);
                    }
                    //确定输出路径
                    string outputPath = fileDir;
                    if (subFolder.Length > 0)
                    {
                        outputPath = fileDir + subFolder + "/";
                    }
                    if (!Directory.Exists(outputPath))
                    {
                        FileManage.CreateFolder(outputPath);
                    }
                    //生成aspx/ascx
                    outputPath = outputPath + toFileName + "." + toFileExt;
                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        Byte[] info = System.Text.Encoding.UTF8.GetBytes(headString + Temp);
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                    }
                    //生成aspx.cs/ascx.cs
                    outputPath = outputPath + ".cs";

                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        Byte[] info = System.Text.Encoding.UTF8.GetBytes(csSb);
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 格式化模板样式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="layerNum"></param>
        /// <returns></returns>
        private string formatString(string str, int layerNum)
        {
            str = Regex.Replace(str, "<!--(.*?)Repeater(.*?)-->", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "\n|\t|\r", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--Head-->", "\t<HeadTemplate" + layerNum + ">", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--/Head-->", "</HeadTemplate" + layerNum + ">\n", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--Item-->", "\t<ItemTemplate" + layerNum + ">", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--/Item-->", "</ItemTemplate" + layerNum + ">\n", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--NoItem-->", "\t<NoItmeTemplate" + layerNum + ">", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--/NoItem-->", "</NoItmeTemplate" + layerNum + ">\n", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--Foot-->", "\t<FootTemplate" + layerNum + ">", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = Regex.Replace(str, "<!--/Foot-->", "</FootTemplate" + layerNum + ">\n", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return str;
        }
        /// <summary>
        /// 取出独立的Repeater
        /// </summary>
        /// <param name="repString"></param>
        /// <returns></returns>
        private IList<string> GetRepeaterSplit(string repString)
        {
            Regex reg = new Regex("<!--(.*?)Repeater(.*?)-->", RegexOptions.IgnoreCase);

            //配对成功-1，不成功+1
            int hasMatch = 0;
            //匹配@"^<!--Repeater[^>]*-->$"的位置
            IList<int> ItemBeginTagPosition = new List<int>();
            //匹配<!--/Repeater-->的位置
            IList<int> ItemEndTagPosition = new List<int>();
            //匹配@"^<!--Repeater[^>]*-->$"的hasMatch的值
            IList<int> BeginhasMatch = new List<int>();
            //匹配<!--/Repeater-->的hasMatch的值
            IList<int> EndhasMatch = new List<int>();
            //一一配对的位置二维坐标形式:x,y
            Hashtable ItemPosition = new Hashtable();
            ItemPosition.Clear();

            MatchCollection matches = reg.Matches(repString);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    if (new Regex(@"^<!--Repeater(.*?)-->$", RegexOptions.IgnoreCase).IsMatch(m.Value))
                    {
                        hasMatch = hasMatch + 1;
                        ItemBeginTagPosition.Add(m.Index);
                        BeginhasMatch.Add(hasMatch);
                    }
                    else
                    {
                        hasMatch = hasMatch - 1;
                        ItemEndTagPosition.Add(m.Index);
                        EndhasMatch.Add(hasMatch);
                    }
                }
            }
            //对HashTable的键/值附值(x,y)分别表示一个完整的Repeater的开始与结束
            for (int a = 0; a < BeginhasMatch.Count; a++)
            {
                int matchNum = (BeginhasMatch[a] - 1);
                int hasOk = 0;
                for (int b = 0; b < EndhasMatch.Count; b++)
                {
                    if ((ItemEndTagPosition[b] > ItemBeginTagPosition[a]) && (EndhasMatch[b] == matchNum) && (hasOk == 0))
                    {
                        ItemPosition.Add(ItemBeginTagPosition[a], ItemEndTagPosition[b]);
                        hasOk = hasOk + 1;
                    }
                }
            }
            //排序
            ArrayList akeys = new ArrayList(ItemPosition.Keys);
            akeys.Sort();
            IList<string> TempRepeaterArray = new List<string>();
            //按HashTable键/值取出Repeater
            foreach (int skey in akeys)
            {
                int len = Convert.ToInt32(ItemPosition[skey]) + 16 - skey;
                TempRepeaterArray.Add(repString.Substring(skey, len));
            }
            string TempRe = string.Empty;
            //独立出Repeater并补充LayerNum
            for (int i = 0; i < TempRepeaterArray.Count; i++)
            {
                TempRe = TempRepeaterArray[i];
                //含有几个Repeater
                int RepeaterNum = RegexGetTempTag("<!--Repeater(.*?)-->", TempRe).Count - 1;
                int RepeaterEnd = RepeaterNum + i + 1;
                if (RepeaterNum > 0)
                {
                    //替换掉多余的Repeater
                    for (int c = (i + 1); c < RepeaterEnd; c++)
                    {
                        TempRe = TempRe.Replace(TempRepeaterArray[c], "{ItemTemplate_" + c + "}");
                    }
                }

                //补充属性Children
                TempRe = TempRe.Replace("<!--Repeater", "<!--Repeater Children=\"" + RepeaterNum + "\"");
                //取表名
                string TableName = RegexGetRepProperty("<!--Repeater(.*?)TableName(\\s)*=(\\s)*(\")*(?<TableName>(\\w+)?)(\")*(\\s)*(.*?)-->", TempRe, "TableName");
                string FieldList = RegexGetRepField(TempRepeaterArray[i], TableName);
                //补充属性Field
                TempRe = TempRe.Replace("<!--Repeater", "<!--Repeater FieldName=\"" + FieldList + "\"");
                //再修改数组值
                TempRepeaterArray[i] = TempRe;
            }
            return TempRepeaterArray;
        }
        /// <summary>
        /// 取匹配的字串
        /// </summary>
        /// <param name="RegexStr"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        private IList<string> RegexGetTempTag(string RegexStr, string Temp)
        {
            IList<string> TempTag = new List<string>();
            Regex reg = new Regex(RegexStr, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(Temp);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    TempTag.Add(m.Value);
                }
            }
            return TempTag;
        }
        /// <summary>
        /// 取对应正则匹配的位置
        /// </summary>
        /// <param name="RegexStr"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        private IList<int> RegexGetTempTagPosition(string RegexStr, string Temp)
        {
            IList<int> TempTagPosition = new List<int>();
            Regex reg = new Regex(RegexStr, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(Temp);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    TempTagPosition.Add(m.Index);
                }
            }
            return TempTagPosition;
        }
        /// <summary>
        /// 取不重复的字段
        /// </summary>
        /// <param name="Temp"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private string RegexGetRepField(string Temp, string TableName)
        {
            string FieldList = string.Empty;
            ArrayList alField = new ArrayList();
            Regex reg = new Regex("{" + TableName + "\\.(?<Field>(\\w+)?)([^}]*?)}", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(Temp);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    if (!alField.Contains(m.Groups["Field"].Value))
                    {
                        alField.Add(m.Groups["Field"].Value.Split(',')[0]);
                    }
                }
            }
            //取出不重复的字段
            foreach (string al in alField)
            {
                FieldList = FieldList + "," + al.ToString();
            }
            return FieldList.TrimStart(new char[] { ',' });
        }
        /// <summary>
        /// 取Repeater的属性值
        /// </summary>
        /// <param name="RegexStr"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        private string RegexGetRepProperty(string RegexStr, string Temp, string PropertyName)
        {
            string Property = string.Empty;
            Regex reg = new Regex(RegexStr, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(Temp);
            if (matches.Count > 0)
            {
                Property = matches[0].Groups[PropertyName].Value;
            }
            return Property;
        }

        /// <summary>
        /// 取多个匹配与此正则的值
        /// </summary>
        /// <param name="RegexStr"></param>
        /// <param name="Temp"></param>
        /// <returns></returns>
        private IList<string> RegexGetMuValue(string RegexStr, string Temp, string PropertyName)
        {
            IList<string> MuProperty = new List<string>();
            Regex reg = new Regex(RegexStr, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matches = reg.Matches(Temp);
            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    MuProperty.Add(m.Groups[PropertyName].Value);
                }
            }
            return MuProperty;
        }
    }
}
