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
using System.IO;
using System.Text;
using System.Xml;

public partial class Manage_BaseManage_CreateModelField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DealXmlModel();
        CreateFile();

    }



    /// <summary>
    ///创建文件
    /// </summary>
    private void CreateFile()
    {

        ///字段配置xml
        string strFileXmlPath = Server.MapPath("~/sysconfig/Dcw_WebModelFile.xml");
        XmlDocument objFileXmlDoc = new XmlDocument();
        objFileXmlDoc.Load(strFileXmlPath);
        XmlNodeList FilexmlNodeList = objFileXmlDoc.SelectNodes("root/node");

        ///模块xml
        string strModuleXmlPath = Server.MapPath("~/sysconfig/Module.xml");
        XmlDocument objModuleXmlDoc = new XmlDocument();
        objModuleXmlDoc.Load(strModuleXmlPath);
        XmlNodeList ModulexmlNodeList = objModuleXmlDoc.SelectNodes("root/node");



        string strallcate = objFileXmlDoc.GetElementsByTagName("root")[0].Attributes["allcate"].Value;



        foreach (XmlNode ModulexmlNode in ModulexmlNodeList)
        {
            XmlElement Modulexe = (XmlElement)ModulexmlNode;
            string strModelName = Modulexe.GetAttribute("modelName");
            string strModelType = Modulexe.GetAttribute("model");
            string strModelOrder = Modulexe.GetAttribute("order");
            int state = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("typeName", typeof(string)));
            dt.Columns.Add(new DataColumn("DefaultValue", typeof(string)));
            dt.Columns.Add(new DataColumn("HelpInfo", typeof(string)));
            dt.Columns.Add(new DataColumn("IsCheck", typeof(string)));
            dt.Columns.Add(new DataColumn("IsHide", typeof(string)));
            dt.Columns.Add(new DataColumn("Label", typeof(string)));
            dt.Columns.Add(new DataColumn("Label1", typeof(string)));
            dt.Columns.Add(new DataColumn("MustField", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Order", typeof(string)));
            dt.Columns.Add(new DataColumn("Reg", typeof(string)));
            dt.Columns.Add(new DataColumn("RegMsg", typeof(string)));
            dt.Columns.Add(new DataColumn("RequiredField", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("WebId", typeof(string)));
            dt.Columns.Add(new DataColumn("FileconControl", typeof(string)));
            dt.Columns.Add(new DataColumn("rbl", typeof(string)));
            dt.Columns.Add(new DataColumn("FieldInfo", typeof(string)));
            foreach (XmlNode FilexmlNode in FilexmlNodeList)
            {
                XmlElement Filexe = (XmlElement)FilexmlNode;
                string strModelName1 = Filexe.GetAttribute("typeName");
                string strModelType1 = Filexe.GetAttribute("Type");
                
                if (strModelName == strModelName1 && strModelType == strModelType1)
                {

                    string typename = strModelType;

                    switch (strModelType)
                    {
                        case "Down":
                            typename = "down";
                            break;
                        case "GuestBook":
                            typename = "guestbook";
                            break;
                        case "Introduction":
                            typename = "baseinfo";
                            break;
                        case "Link":
                            typename = "link";
                            break;
                        case "News":
                            typename = "news";
                            break;
                        case "Position":
                            typename = "position";
                            break;
                        case "Product":
                            typename = "products";
                            break;
			case "Province":
                            typename = "province";
                            break;
			case "SaleNet":
                            typename = "SaleNet";
                            break;
			case "Ezine":
                            typename = "Ezine";
                            break;

			case "User":
                            typename = "user";
                            break;

                    }
                    if (state == 0)
                    {
                        CreateListFile(typename, strModelName, strModelOrder);
                        state = 1;

                    }
                        ////把xml里的数据转入dr
                    string strFieldInfo = FilexmlNode.InnerText;
                    if (strFieldInfo != "" && Filexe.GetAttribute("IsHide") != "1")
                     {
                         DataRow dr = dt.NewRow();
                         dr["typeName"] = Filexe.GetAttribute("typeName");
                         dr["DefaultValue"] = Filexe.GetAttribute("DefaultValue");
                         dr["HelpInfo"] = Filexe.GetAttribute("HelpInfo");
                         dr["IsCheck"] = Filexe.GetAttribute("IsCheck");
                         dr["IsHide"] = Filexe.GetAttribute("IsHide");
                         dr["Label"] = Filexe.GetAttribute("Label");
                         dr["Label1"] = Filexe.GetAttribute("Label1");
                         dr["MustField"] = Filexe.GetAttribute("MustField");
                         dr["Name"] = Filexe.GetAttribute("Name");
                         dr["Order"] = Filexe.GetAttribute("Order");
                         dr["Reg"] = Filexe.GetAttribute("Reg");
                         dr["RegMsg"] = Filexe.GetAttribute("RegMsg");
                         dr["RequiredField"] = Filexe.GetAttribute("RequiredField");
                         dr["Type"] = Filexe.GetAttribute("Type");
                         dr["WebId"] = Filexe.GetAttribute("WebId");
                         dr["FileconControl"] = Filexe.GetAttribute("FileconControl");
                         dr["rbl"] = Filexe.GetAttribute("rbl");
                         dr["FieldInfo"] = strFieldInfo;
                         dt.Rows.Add(dr);
                     }

                        //CreateUpdataFile();
                  
                }
            }
            if (dt.Rows.Count > 0)
            {
                string typename = strModelType;
                switch (strModelType)
                {
                    case "Down":
                        typename = "down";
                        break;
                    case "GuestBook":
                        typename = "guestbook";
                        break;
                    case "Introduction":
                        typename = "baseinfo";
                        break;
                    case "Link":
                        typename = "link";
                        break;
                    case "News":
                        typename = "news";
                        break;
                    case "Position":
                        typename = "position";
                        break;
                    case "Product":
                        typename = "products";
                        break;
		    case "Province":
                        typename = "province";
                        break;
		    case "SaleNet":
                        typename = "SaleNet";
                        break;
		    case "Ezine":
                        typename = "Ezine";
                        break;
			case "User":
                        typename = "user";
                        break;

                }
                CreateUpdateFile(dt,typename, strModelName, strModelOrder);
            }
        }

        RegisterStartupScript(this.ToString(), "<script language='javascript'>alert('生成完成！');</script>");
    }

    /// <summary>
    /// 同步模块xml
    /// </summary>
    private void DealXmlModel()
    {


        ///字段配置xml
        string strFileXmlPath = Server.MapPath("~/sysconfig/Dcw_WebModelFile.xml");
        XmlDocument objFileXmlDoc = new XmlDocument();
        objFileXmlDoc.Load(strFileXmlPath);
        XmlNodeList FilexmlNodeList = objFileXmlDoc.SelectNodes("root/node");

        XmlDocument objModuleXmlDoc = new XmlDocument();
        string strModuleXmlPath = Server.MapPath("~/sysconfig/Module.xml");
        objModuleXmlDoc.Load(strModuleXmlPath);
      
        string strallcate = objFileXmlDoc.GetElementsByTagName("root")[0].Attributes["allcate"].Value;
        XmlNodeList ModulexmlNodeList = objModuleXmlDoc.SelectNodes("root/node");
        foreach (XmlNode FilexmlNode in FilexmlNodeList)
        {
            XmlElement Filexe = (XmlElement)FilexmlNode;
            string strModelName = Filexe.GetAttribute("typeName");
            string strModelType = Filexe.GetAttribute("Type");
            int modelstate = 0;
            ///模块xml
       
           
          
           
            foreach (XmlNode ModulexmlNode in ModulexmlNodeList)
            {
                XmlElement Modulexe = (XmlElement)ModulexmlNode;
                string strModelName1 = Modulexe.GetAttribute("modelName");
                string strModelType1 = Modulexe.GetAttribute("model");
                if (strModelName == strModelName1 && strModelType == strModelType1)
                {
                    modelstate = 1;
                    break;
                }
            }
            if (modelstate == 0)
            {
                ///清加到模块xml
                addModuleXml(strModelName, strModelType, strallcate);
                objModuleXmlDoc = new XmlDocument();
                objModuleXmlDoc.Load(strModuleXmlPath);
                ModulexmlNodeList = objModuleXmlDoc.SelectNodes("root/node");
               
            }

           
        }
    }
    /// <summary>
    /// 清加模块xml数据
    /// </summary>
    /// <param name="strModelName"></param>
    /// <param name="strModelType"></param>
    /// <param name="strallcate"></param>
    private void addModuleXml(string strModelName, string strModelType, string strallcate)
    {
       

        foreach(string s in strallcate.Split(','))
        {
            if (s != "" && s != null)
            {
                if (s.Split('|').Length > 1)
                {
                    if(s.Split('|')[0]==strModelName)
                    {

                        XmlDocument modxml = new XmlDocument();
                        string xmppath = Server.MapPath("~/sysconfig/Module.xml");

                        modxml.Load(xmppath);

                        XmlNode root = modxml.GetElementsByTagName("root")[0];
     


                        XmlElement el = modxml.CreateElement("node");
                        el.SetAttribute("modelName", s.Split('|')[0]);
                        el.SetAttribute("type", s);
                        if (s.Split('|')[1].Split('#').Length > 1)
                        {
                            el.SetAttribute("model", s.Split('|')[1].Split('#')[0]);
                            string model = "|" + s.Split('|')[1].Split('#')[0] + "#";
                            int cateindex = strallcate.Replace(s, "*").Split('*')[0].Replace(model, "&").Split('&').Length;



                            el.SetAttribute("order", cateindex.ToString());
                           
                        }
                        else
                        {
                            el.SetAttribute("model", s.Split('|')[1]);
                            el.SetAttribute("order", "0");
                        }
                        root.AppendChild(el);
                        modxml.Save(xmppath);
                      
                    }
                }
            }
        }


         
    
   
  
        
    }



    /// <summary>
    /// 取得模板内容
    /// </summary>
    private string GetTemplate(string strFilePath)
    {
        string strTemplateText = "";

        //如果指定风格的模板文件不存在...
        if (System.IO.File.Exists(strFilePath))
        {
            using (System.IO.StreamReader objReader = new System.IO.StreamReader(strFilePath, Encoding.UTF8))
            {
                //读取开始
                StringBuilder textOutput = new StringBuilder();
                textOutput.Append(objReader.ReadToEnd());
                objReader.Close();
                strTemplateText = textOutput.ToString();
            }
        }
        return strTemplateText;
    }


    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="strFileName"></param>
    /// <param name="strFileContent"></param>
    /// <returns></returns>
    private void SaveFile(string strFileName, string strFileContent)
    {
        using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            try
            {
                Byte[] info = System.Text.Encoding.UTF8.GetBytes(strFileContent);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            catch 
            {

            }
        }
    }
 /// <summary>
 /// 生成list页面
 /// </summary>
 /// <param name="modeltype">模块类型</param>
 /// <param name="modelname">模块名</param>
 /// <param name="modelorder">模块排序</param>
    private void CreateListFile(string modeltype,string modelname,string modelorder)
    {
        string modelfilesrc = Server.MapPath("~/Manage/BaseManage/ModelField/" + modeltype + "_list.asp");
        string savefilescr = Server.MapPath("~/Manage/" + modeltype + "/" + modelorder + modeltype + "_list.aspx");
        SaveFile(savefilescr, GetTemplate(modelfilesrc).Replace("{0}", modelname));
        SaveFile(savefilescr, GetTemplate(savefilescr).Replace("{1}", modelorder));
    }
    /// <summary>
    /// 生成updata页面
    /// </summary>
    /// <param name="data">字段数据</param>
    /// <param name="modeltype">模块类型</param>
    /// <param name="modelname">模块名</param>
    /// <param name="modelorder">模块排序</param>
    private void CreateUpdateFile(DataTable data, string modeltype, string modelname, string modelorder)
    {


        DataView dv = data.DefaultView;
        dv.Sort = "Order asc";
        string pagdata = "";
        foreach (DataRowView drv in dv)
        {
            pagdata = pagdata+drv["FieldInfo"].ToString();
        }
        string modelfilesrc = Server.MapPath("~/Manage/BaseManage/ModelField/" + modeltype + "_update.asp");
        string savefilescr = Server.MapPath("~/Manage/" + modeltype + "/" + modelorder + modeltype + "_update.aspx");
        SaveFile(savefilescr, GetTemplate(modelfilesrc).Replace("{1}", pagdata));    
        SaveFile(savefilescr, GetTemplate(savefilescr).Replace("{0}", modelname));



    }
}
