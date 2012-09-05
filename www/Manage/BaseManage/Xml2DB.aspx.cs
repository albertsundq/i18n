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
using System.Xml;

public partial class Manage_BaseManage_Xml2DB : System.Web.UI.Page
{


   // string xmppath = @"C:\Documents and Settings\hurm\桌面\20100521DcmsV3.0\WebSiteTest\webmenu.xml";
    string xmppath = "";
    XmlDocument doc;
    XmlDocument modxml;
    DataTable CateDs = new DataTable();
    string language = "cn";
    ISession session = dbContext.Current().GetContext("SqlDb").GetSession();
    ArrayList CateAl = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        //using (ISession session = dbContext.Current().GetContext("SqlDb").GetSession())
        //{
        //    //session.simple("insert into  Dcms_Cate (Cate_Title) values('关于我们')");
        //    SqlDb.Dcms_Catedown = new SqlDb.Dcms_Cate;
        
        //}
        xmppath = Server.MapPath("~/sysconfig/webmenu.xml");
       
        ToDB(); 

    }

       //读取xml数据并储存到数据库
    private void ToDB()
    {
        loadXMl();
        if (doc != null)
        {

            //delModel();
            XmlNode root = doc.GetElementsByTagName("root")[0];
            language = root.FirstChild.Attributes["language"].Value;

            CateDs = session.GetTable("select * from Dcms_Cate");
            //int MaxId = 0;
            //try
            //{
            //     MaxId = int.Parse(session.ExecuteScalar("select max(Cate_Id) from Dcms_Cate").ToString());
            //}
            //catch
            //{
            //    MaxId = 0;
            //}
            //forXML(root.FirstChild, MaxId);

            forXML(root.FirstChild, 0);
            foreach (DataRow dr in CateDs.Rows)
            {
                int drint = 0;
                foreach (object o in CateAl)
                {
                    if (dr["Cate_Guid"].ToString() == o.ToString())
                    {
                        drint = 1;
                    }
                }
                if (drint == 0)
                {
                    session.simple("delete  from Dcms_Cate where Cate_Guid='" + dr["Cate_Guid"].ToString()+"'");
                }
            }
        }

    }
    //加载xml
    private void loadXMl()
    {
        try
        {
            doc = new XmlDocument();

            doc.Load(xmppath);

        }
        catch
        {
            return;
        }

    }


    //递归遍历
    private void forXML(XmlNode xn, int ParentID)
    {
    
        foreach (XmlNode node in xn.ChildNodes)
        {
             SqlDb.Dcms_Cate newcate= new SqlDb.Dcms_Cate();
             SqlDb.Dcms_Cate parent = new SqlDb.Dcms_Cate();
          
            ///循环 NewCate list判断guid是否存在，不存在的话就添加，存在的话，修改
            int forint = 0;
            foreach (DataRow dr in CateDs.Rows)
            {
                if (dr["Cate_Guid"].ToString() == node.Attributes["Guid"].Value)
                {
                    forint = 1;
                }
            }
            if (forint == 1)
            {
                newcate = getmodel("select * from Dcms_Cate where Cate_Guid='" + node.Attributes["Guid"].Value + "'");                
                
            }

            parent = getmodel("select * from Dcms_Cate where Cate_Id=" + ParentID);
            newcate.Cate_Key = node.Attributes["ModelKey"].Value;
            newcate.Cate_Title = node.Attributes["name"].Value;

            
            string type = node.Attributes["type"].Value;        
            //是否为新建分类
            if (type.Split('|')[1].Split('#').Length < 2)
            {


                switch (type.Split('|')[1])
                {
                    case "Down":
                        newcate.Cate_Module = "down";
                       
                        break;
                    case "GuestBook":
                        newcate.Cate_Module = "guestbook";
                        break;
                    case "Introduction":
                        newcate.Cate_Module = "baseinfo";
                        break;
                    case "Link":
                        newcate.Cate_Module = "link";
                        break;
                    case "News":
                        newcate.Cate_Module = "news";
                        break;
                    case "Position":
                        newcate.Cate_Module = "position";
                        break;
                    case "Product":
                        newcate.Cate_Module = "products";
                        break;                


                }
              
               // newcate.Cate_ModelKeyId = 0;
               

            }
            else
            {
                switch (type.Split('|')[1].Split('#')[0])
                {
                    case "Down":
                        newcate.Cate_Module = "down";
                        break;
                    case "GuestBook":
                        newcate.Cate_Module = "guestbook";
                        break;
                    case "Introduction":
                        newcate.Cate_Module = "baseinfo";
                        break;
                    case "Link":
                        newcate.Cate_Module = "link";
                        break;
                    case "News":
                        newcate.Cate_Module = "news";
                        break;
                    case "Position":
                        newcate.Cate_Module = "position";
                        break;
                    case "Product":
                        newcate.Cate_Module = "products";
                        break;


                }

              
    


            }
            newcate.Cate_ModelKeyId = selectmodule(type).ToString();
            if (node.Attributes["showtype"].Value == "1")
            {
                newcate.Cate_ManageUrl = newcate.Cate_Module + "_list.aspx";
            }
            else
            {
                newcate.Cate_ManageUrl = newcate.Cate_Module + "_update.aspx";
            }
            newcate.Cate_Lang = language;



            newcate.Cate_Guid = node.Attributes["Guid"].Value;





            newcate.Cate_HasChild = 0;
            ///如果guid存在修改，如果不存在就添加;
            if (forint == 1)
            {
                session.Update(newcate);
                

            }
            else
            {
                                
               
                if (parent != null)
                {
                    newcate.Cate_IdPath = parent.Cate_IdPath+ParentID+",";
                    parent.Cate_HasChild=1;
                    session.Update(parent);
                }
                else
                {
                    newcate.Cate_IdPath = ",0,";
                }
                newcate.Cate_AddTime=DateTime.Now;
                newcate.Cate_State = "1";              
                newcate.Cate_ParentID = ParentID;
                session.Create(newcate);
            }
            //把XML中的GUID保存到arraylis中
            CateAl.Add(node.Attributes["Guid"].Value);

            int MaxId = int.Parse(session.ExecuteScalar("select max(Cate_Id) from Dcms_Cate").ToString());
            forXML(node, MaxId);
          
        }
    }



    private SqlDb.Dcms_Cate getmodel(string where)
    {
                DataTable newtab = session.GetTable(where);
                if (newtab.Rows.Count < 1)
                {
                    return null;
                }
                SqlDb.Dcms_Cate recate = new SqlDb.Dcms_Cate();
                if (newtab.Rows[0]["Cate_AddTime"].ToString()!="")
                recate.Cate_AddTime = DateTime.Parse(newtab.Rows[0]["Cate_AddTime"].ToString());
                recate.Cate_ExField1 = newtab.Rows[0]["Cate_ExField1"].ToString();
                recate.Cate_ExField10 = newtab.Rows[0]["Cate_ExField10"].ToString();
                recate.Cate_ExField2 = newtab.Rows[0]["Cate_ExField2"].ToString();
                recate.Cate_ExField3 = newtab.Rows[0]["Cate_ExField3"].ToString();
                recate.Cate_ExField4 = newtab.Rows[0]["Cate_ExField4"].ToString();
                recate.Cate_ExField5 = newtab.Rows[0]["Cate_ExField5"].ToString();
                recate.Cate_ExField6 = newtab.Rows[0]["Cate_ExField6"].ToString();
                recate.Cate_ExField7 = newtab.Rows[0]["Cate_ExField7"].ToString();
                recate.Cate_ExField8 = newtab.Rows[0]["Cate_ExField8"].ToString();
                recate.Cate_ExField9 = newtab.Rows[0]["Cate_ExField9"].ToString();
                recate.Cate_Guid = newtab.Rows[0]["Cate_Guid"].ToString();
                if (newtab.Rows[0]["Cate_HasChild"].ToString()!="")
                recate.Cate_HasChild = int.Parse(newtab.Rows[0]["Cate_HasChild"].ToString());
                if(newtab.Rows[0]["Cate_Id"].ToString()!="")
                recate.Cate_Id = int.Parse(newtab.Rows[0]["Cate_Id"].ToString());
                recate.Cate_IdPath = newtab.Rows[0]["Cate_IdPath"].ToString();
                recate.Cate_Image = newtab.Rows[0]["Cate_Image"].ToString();
                recate.Cate_Intro = newtab.Rows[0]["Cate_Intro"].ToString();
                recate.Cate_Key = newtab.Rows[0]["Cate_Key"].ToString();
                recate.Cate_Lang = newtab.Rows[0]["Cate_Lang"].ToString();
                recate.Cate_ManageName = newtab.Rows[0]["Cate_ManageName"].ToString();
                recate.Cate_ManageUrl = newtab.Rows[0]["Cate_ManageUrl"].ToString();
                if (newtab.Rows[0]["Cate_ModelKeyId"].ToString()!="")
                recate.Cate_ModelKeyId = newtab.Rows[0]["Cate_ModelKeyId"].ToString();
                recate.Cate_Module = newtab.Rows[0]["Cate_Module"].ToString();
                if(newtab.Rows[0]["Cate_Order"].ToString()!="")
                recate.Cate_Order = int.Parse(newtab.Rows[0]["Cate_Order"].ToString());
                if (newtab.Rows[0]["Cate_ParentID"].ToString()!="")
                recate.Cate_ParentID = int.Parse(newtab.Rows[0]["Cate_ParentID"].ToString());
                recate.Cate_SEODescription = newtab.Rows[0]["Cate_SEODescription"].ToString();
                recate.Cate_SEOKeyWord = newtab.Rows[0]["Cate_SEOKeyWord"].ToString();
                recate.Cate_SEOTitle = newtab.Rows[0]["Cate_SEOTitle"].ToString();
                recate.Cate_State = newtab.Rows[0]["Cate_State"].ToString();
                recate.Cate_Title = newtab.Rows[0]["Cate_Title"].ToString();
                recate.Cate_Url = newtab.Rows[0]["Cate_Url"].ToString();


                return recate;
    }

    /// <summary>
    /// 取到模块索引
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private int selectmodule(string type)
    {

        loadmodXml();
        XmlNode root = modxml.GetElementsByTagName("root")[0];
        string Catestr = root.Attributes["allcate"].Value;
        foreach (XmlNode node in root.ChildNodes)
        {
            if (type == node.Attributes["type"].Value)
            {
                return int.Parse(node.Attributes["order"].Value);
            }
        }
        int modoredr=0;

        if (type != "" && type.Split('|').Length > 1)
        {
            XmlElement el = modxml.CreateElement("node");
            el.SetAttribute("modelName", type.Split('|')[0]);
            el.SetAttribute("type", type);
            if (type.Split('|')[1].Split('#').Length > 1)
            {
                el.SetAttribute("model", type.Split('|')[1].Split('#')[0]);
                string model = "|" + type.Split('|')[1].Split('#')[0] + "#";
                int cateindex = Catestr.Replace(type, "*").Split('*')[0].Replace(model, "&").Split('&').Length;



                el.SetAttribute("order", cateindex.ToString());
                modoredr = int.Parse(cateindex.ToString());
            }
            else
            {
                el.SetAttribute("model", type.Split('|')[1]);
                el.SetAttribute("order", "0");
            }

            root.AppendChild(el);
           // string xmppath = @"C:\Documents and Settings\hurm\桌面\20100521DcmsV3.0\WebSiteTest\Module.xml";
            string xmppath = Server.MapPath("~/sysconfig/Module.xml");
            modxml.Save(xmppath);
            //modxml.Save(Server.MapPath("/") + @"\Module.xml");
            return modoredr;
        }
        return 0;
      
    }


    ///
    /// <summary>
    /// 取得url列表
    /// </summary>
    private void loadmodXml()
    {
        try
        {
            modxml = new XmlDocument();
           // string xmppath = @"C:\Documents and Settings\hurm\桌面\20100521DcmsV3.0\WebSiteTest\Module.xml";
            string xmppath = Server.MapPath("~/sysconfig/Module.xml");
            modxml.Load(xmppath);
            //modxml.Load(Server.MapPath("/") + @"\Module.xml");
        }
        catch
        {
            return;
        }
    }

}
