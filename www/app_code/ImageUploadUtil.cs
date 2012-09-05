using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;


public class ImageUploadUtil : UploadPageBase
{
    #region ImageUpload[上传文件]
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="Path">上传路径</param>
    /// <param name="filName">上传控件名</param>
    /// <param name="Type">上传类型，1图片，2视频</param>
    /// <returns></returns>
    public String ImageUpload(String Path, string filName, int Type)
    {
        try
        {
            //Path = @"upload/image";
            //设置不允许上传的文件扩展名
            FileExtension[] fe = { FileExtension.ASP, FileExtension.ASPX, FileExtension.DLL,FileExtension.EXE,FileExtension.HTM,FileExtension.HTML,FileExtension.JS,FileExtension.SQL,FileExtension.BAT,FileExtension.CMD};
            String Pakeage = DateTime.Now.ToString("yyyy-MM-dd");

            //判断路径是否存在,不存在则创建
            CheckUpDirectory(Server.MapPath(Path));
            //实例文件读取方法，对传入客户端的文件进行解析
            System.Web.HttpFileCollection Files = System.Web.HttpContext.Current.Request.Files;
            HttpPostedFile file = Files[filName];
            //解析所得文件名
            String FileName = System.IO.Path.GetFileNameWithoutExtension(file.FileName).Replace("-", "").Replace(" ", "").Replace(".", "").Replace("/", "").Replace("/0", "").Replace("#", "").Replace("%", "") + "-" + CreateFileName();
            String ExtensionName = System.IO.Path.GetExtension(file.FileName);
            if (ExtensionName != String.Empty)
            {
                //解析所得路径
                Stream MyStream = file.InputStream;
               // file.SaveAs(Server.MapPath("/temp/" + FileName + ExtensionName));
                
              //  System.Web.HttpContext.Current.Response.Write(CheckFileIsImage(MyStream, ExtensionName) + "<br>");

                if (CheckFileIsVirus(MyStream, ExtensionName))//不读取字节码判断不允许上传的文件
                {
                    return "##error##500##";
                }
                if (IsAllowedExtension(file,fe))//读取字节码判断不允许上传的文件
                {
                   
                    return "##error##500##";
                }
             
                file.SaveAs(Server.MapPath(Path + FileName + ExtensionName));
                return FileName;
            }
            return "##error##500##";
        }
        catch
        {
            return "##error##500##";
        }
    }
    #endregion
    #region CheckFileIsImage [对上传的文件，进行判断图片真假]
    private bool CheckFileIsImage(Stream FileStramInfo, String Extension)
    {

            System.Drawing.Image img;
            switch (Extension.ToLower())
            {
                case ".gif":
                    img = System.Drawing.Image.FromStream(FileStramInfo);
                    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                    {
                        return true;
                    }
                    break;
                case ".jpg":
                    img = System.Drawing.Image.FromStream(FileStramInfo);
                    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        return true;
                    }
                    break;
                case ".jpeg":
                    img = System.Drawing.Image.FromStream(FileStramInfo);
                    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        return true;
                    }
                    break;
                case ".png":
                    img = System.Drawing.Image.FromStream(FileStramInfo);
                    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                    {
                        return true;
                    }
                    break;
                case ".bmp":
                    img = System.Drawing.Image.FromStream(FileStramInfo);
                    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                    {
                        return true;
                    }
                    break;
            }
            return false;
            
    }
    #endregion
    #region CheckFileIsVirus [对上传的文件，进行判断图片真假]
    private bool CheckFileIsVirus(Stream FileStramInfo, String Extension)
    {
        string files = ".asp,.aspx,.php,.js,.bat,.chm,.com,.exe,.pif,.dll,.ashx,.shtml,.jsp";
        if(files.Contains(Extension))
        {
            return true;
        }
        return false;

    }
    #endregion
    #region AntiVirusFile[对上传的内容进行查毒，没有并毒在进行存储]
    /// <summary>
    /// 对上传的内容进行查毒，没有并毒在进行存储
    /// </summary>
    /// <param name="FileStream"></param>
    /// <returns></returns>
    private bool AntiVirusFileAgain(Stream FileStream,int FileLen) {
        bool isVirus = false;
        //byte[] input = new byte[FileLen];
        //FileStream.Read(input, 0, FileLen);
        //String FileString = Encoding.Default.GetString(input, 0, FileLen);   
        //Regex reg = new Regex(@"<\%.*?\%>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //isVirus = reg.IsMatch(FileString);
        return isVirus;
        //return false;
    }
    private bool AntiVirusFile(Stream FileStream,int FileLen) {
        bool isVirus = false;
        //byte[] input = new byte[FileLen];
        //FileStream.Read(input, 0, FileLen);
        //String FileString = Encoding.Default.GetString(input, 0, FileLen);
        //Regex reg = new Regex(@"request|script|\.getfolder|\.createfolder|\.deletefolder|\.createdirectory|\.deletedirectory|\.saveas|wscript\.shell|script\.encode|server\.|\.createobject|execute|activexobject|language=", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //isVirus = reg.IsMatch(FileString);
        return isVirus;
        //return false;
    }

    #endregion

    #region CheckUpDirectory[判断路径是否存在，不存在则创建]
    /// <summary>
    /// 判断路径是否存在，不存在则创建
    /// </summary>
    /// <param name="uploadDirectory"></param>
    private void CheckUpDirectory(String uploadDirectory)
    {
        try
        {
            if (Directory.Exists(uploadDirectory))
            {
                return;
            }

            Directory.CreateDirectory(uploadDirectory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    private string CreateFileName()
    {
        string strR = "";
        strR += DateTime.Now.ToString("HH");
        strR += DateTime.Now.ToString("mm");
        strR += DateTime.Now.ToString("sss");
        Random roo = new Random();
        strR += roo.Next(11111, 99999);
        return strR;
    }
    private enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        BMP = 6677,
        PNG = 13780,
        DOC = 208207,//xls.doc.ppt
        XLS = 208207,
        PPT = 208207,
        DOCX = 8075,
        XLSX = 8075,
        SWF = 6787,
        TXT = 7067,
        MP3 = 7368,
        WMA = 4838,
        MID = 7784,
        RAR = 8297,
        ZIP = 8075,
        XML = 6063,

        JS = 4742,
        ASPX = 239187,//,aspx,asp,sql
        ASP = 239187,
        SQL = 239187,
        HTM = 6033,//htm,html
        HTML = 6033,
        EXE = 7790,//exe dll
        DLL = 7790,
        CMD=10199,
        BAT=64101
        /*文件扩展名说明
         *4946/104116 txt
         *7173        gif 
         *255216      jpg
         *13780       png
         *6677        bmp
         *239187      txt,aspx,asp,sql
         *208207      xls.doc.ppt
         *6063        xml
         *6033        htm,html
         *4742        js
         *8075        xlsx,zip,pptx,mmap,zip
         *8297        rar   
         *01          accdb,mdb
         *7790        exe,dll           
         *5666        psd 
         *255254      rdp 
         *10056       bt种子 
         *64101       bat 
         *4059        sgf
         */
    }
    private bool IsAllowedExtension(HttpPostedFile file, FileExtension[] fileEx)     
     {     
         int fileLen = file.ContentLength;     
         byte[] imgArray = new byte[fileLen];     
         file.InputStream.Read(imgArray, 0, fileLen);     
         MemoryStream ms = new MemoryStream(imgArray);     
         System.IO.BinaryReader br = new System.IO.BinaryReader(ms);     
         string fileclass = "";     
         byte buffer;     
         try    
         {     
             buffer = br.ReadByte();     
             fileclass = buffer.ToString();     
             buffer = br.ReadByte();     
             fileclass += buffer.ToString();     
         }     
        catch    
        {
           
        }     
        br.Close();     
        ms.Close();     
       foreach (FileExtension fe in fileEx)     
        {     
            if (Int32.Parse(fileclass) == (int)fe)     
                return true;     
        }     
        return false;     
     }     
}
