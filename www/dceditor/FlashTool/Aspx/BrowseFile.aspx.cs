using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class FlashTool_Aspx_BrowseFile : UploadPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Request.Form["Operate"] != null)
            {
                String Operate = Request.Form["Operate"].ToString();
                switch(Operate){
                    case "Browse":
                        Response.Write(GetJsonFile());
                        break;
                    case "DELETEFILE":
                        Response.Write(DeleteFile());
                        break;
                    case "NEWFOLDER":
                        Response.Write(NewFolder());
                        break;
                    case "AGAINFOLDER":
                        Response.Write(AgainFolder());
                        break;

                }   
            }
    }
    //文件夹重命名
    private String AgainFolder()
    {
        try
        {
            if (Request.Form["Path"] != null && Request.Form["oldname"] != null && Request.Form["newname"] != null)
            {
                String PathTemp = Request.Form["Path"].ToString();
                String OldName = Request.Form["oldname"].ToString();
                String NewName = Request.Form["newname"].ToString().Replace("-", "").Replace(" ", "").Replace(".", "").Replace("/0", "").Replace("#", "").Replace("%", "");
                String NewPath = "/";
                String[] PathAll = PathTemp.Split('/');
                for (int i = 0; i < PathAll.Length-1; i++) {
                    NewPath += PathAll[i] + "/";
                }
                NewPath += NewName + "/";
                if (Directory.Exists(MapPath("../../../" + PathTemp)))
                {
                    if (!Directory.Exists(MapPath("../../../" + NewPath)))
                    {
                        Directory.Move(MapPath("../../../" + PathTemp), MapPath("../../../" + NewPath));
                        return "{\"Start\":\"TRUE\",\"Message\":\"文件夹重命名成功！\"}";
                    }
                    else {
                        return "{\"Start\":\"TRUE\",\"Message\":\"文件夹名已存在！\"}";
                    }
                    
                }
                else
                {
                    return "{\"Start\":\"FALSE\",\"Message\":\"文件夹名已存在！\"}";
                }
            }
            else
            {
                return "{\"Start\":\"FALSE\",\"Message\":\"文件夹重命名失败！\"}";
            }
        }
        catch
        {
            return "{\"Start\":\"FALSE\",\"Message\":\"空间权限不允许文件夹重命名，请与空间管理员联系！\"}";
        }
    }
    //新建文件夹
    private String NewFolder() {
        try
        {
            if (Request.Form["Path"] != null)
            {
                String PathTemp = Request.Form["Path"].ToString().Replace("-", "").Replace(" ", "").Replace(".", "").Replace("/0", "").Replace("#", "").Replace("%", "");
                if (!Directory.Exists(MapPath("../../../" + PathTemp)))
                {
                    Directory.CreateDirectory(MapPath("../../../" + PathTemp));
                    return "{\"Start\":\"TRUE\",\"Message\":\"文件夹新建成功！\"}";
                }
                else
                {
                    return "{\"Start\":\"FALSE\",\"Message\":\"文件夹已存在！\"}";
                }
            }
            else {
                return "{\"Start\":\"FALSE\",\"Message\":\"新建文件夹失败！\"}";
            }
        }
        catch {
            return "{\"Start\":\"FALSE\",\"Message\":\"空间权限不允许新建文件夹，请与空间管理员联系！\"}";
        }
    }
    //删除文件
    private String DeleteFile() {
        try
        {
            if (Request.Form["Path"] != null)
            {
                String PathTemp = Request.Form["Path"].ToString();
                String[] PathAll = PathTemp.Split('|');
                int Num = 0;
                int FolderNum = 0;
                for (int i = 0; i < PathAll.Length; i++)
                {
                    String[] path = PathAll[i].Split('^');
                    if (path[1] == "File")
                    {
                        String FilePath = MapPath("../../../" + path[0]);
                        if (File.Exists(FilePath))
                        {
                            File.Delete(FilePath);
                            Num += 1;
                        }
                    }
                    else if (path[1] == "Folder")
                    {
                        if(Directory.Exists( MapPath("../../.." + path[0]))){
                            Directory.Delete( MapPath("../../.." + path[0]),true);
                            FolderNum += 1;
                        }
                    }
                }
                String Message = "";
                if (Num > 0)
                {
                    Message = "" + Num + "个文件";
                }
                if(FolderNum>0){
                    if (Message != "") {
                        Message += "和";
                    }
                    Message += ""+FolderNum+"个文件夹";
                }
                return "{\"Start\":\"TRUE\",\"Message\":\"删除文件成功，一共删除"+Message+"！\"}";
            }
            else
            {
                return "{\"Start\":\"FALSE\",\"Message\":\"删除文件失败！\"}";
            }
        }
        catch {
            return "{\"Start\":\"FALSE\",\"Message\":\"空间权限不允许删除文件，请与空间管理员联系！\"}";
        }
    }
    //读取文件，并返回JSON格式数据
    private String GetJsonFile() {
        if (Request.Form["Path"] != null && Request.Form["SortFiled"] != null && Request.Form["SortType"] != null)
        {
            String SortFiled = Request.Form["SortFiled"].ToString();
            String SortType = Request.Form["SortType"].ToString();
            DataTable PathTable = new DataTable();
            PathTable.Columns.Add("name", typeof(System.String));
            PathTable.Columns.Add("extension", typeof(System.String));
            PathTable.Columns.Add("type", typeof(System.String));
            PathTable.Columns.Add("path", typeof(System.String));
            PathTable.Columns.Add("size", typeof(System.Double));
            PathTable.Columns.Add("time", typeof(System.DateTime));
            

            String PathUser = Request.Form["Path"].ToString();
            String FilePath = MapPath("../../../" + PathUser);
            String JsonFile = "";
            if (!Directory.Exists(FilePath)) return "NULL";
            String[] dirAr = Directory.GetDirectories(FilePath, "*", SearchOption.TopDirectoryOnly);
            string[] rootfileArr = Directory.GetFiles(FilePath);
            
            for (int i = 0; i < dirAr.Length; i++)
            {
                String[] p = dirAr[i].ToString().Split('\\');
                DataRow row;
                row = PathTable.NewRow();
                row["name"] = p[p.Length - 1];
                row["extension"] = "";
                row["type"] = "Folder";
                row["path"] = "/" + PathUser + "/" + p[p.Length - 1];
                row["size"] = 0;
                row["time"] = Directory.GetCreationTime(dirAr[i].ToString());
                PathTable.Rows.Add(row);
            }
            //文件直接添加            
            foreach (string var in rootfileArr)
            {
                if (Path.GetFileNameWithoutExtension(var) != "Thumbs")
                {
                    FileInfo fileInfo = new FileInfo(var);
                    DataRow row;
                    row = PathTable.NewRow();
                    row["name"] = Path.GetFileNameWithoutExtension(var);
                    row["extension"] = Path.GetExtension(var);
                    row["type"] = "File";
                    row["path"] = PathUser + Path.GetFileName(var);
                    row["size"] = fileInfo.Length;
                    row["time"] = fileInfo.LastWriteTime;
                    PathTable.Rows.Add(row);
                   
                }
            }
            PathTable.DefaultView.Sort = SortFiled + " " + SortType;
            DataTable tempTable = PathTable.DefaultView.ToTable();
            for(int i=0;i<tempTable.Rows.Count;i++){
                DataRow row = tempTable.Rows[i];
                if (JsonFile != "") {
                    JsonFile += ",";
                }
                JsonFile += "{\"name\":\"" + row["name"] + "\",\"extension\":\"" + row["extension"] + "\",\"type\":\"" + row["type"] + "\",\"path\":\"/" + row["path"] + "\",\"size\":\"/" + row["size"] + "\",\"time\":\"/" + row["time"] + "\"}";
            }
            return JsonFile;
        }
        return "NULL";
    }
}
