<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplatePath_Update.aspx.cs" Inherits="Manage.TemplatePath.Manage_TemplatePath_TemplatePath_Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>模板文件编辑</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />

<script type="text/javascript" src="../Green/Js/jquery.js"></script>

<!--表单验证开始-->
<script src="../Green/Js/jquery.validate.pack.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function() {
    $(":text").eq(1).focus();
	$("#updateForm").validate({
         debug:true,
         submitHandler:function() { ajaxSubmi(); }
    })
});
</script>
<style type="text/css">
#updateForm label.error {margin-left: 5px;color:red;font-weight:normal;}
</style>
<!--表单验证结束-->
<script type="text/javascript">
//定义Tab切换
function changetab(tabid){
	for(var i=1;i<=2;i++)
	{
		$("#tab_"+i).removeClass("titleactive");
		$("#tabcontent_"+i).css("display","none");
	}
	$("#tab_"+tabid).addClass("titleactive");
	$("#tabcontent_"+tabid).css("display","block");
}

//ajax请求单条数据修改
function getOneRecord(filename){
		
		  $.getJSON("TemplatePath_Manage.aspx?action=getone&time="+Math.random()+"&filename="+filename+"&langflag="+$("#langflag").val(),function(json){
								$.each(json,function(i){
								
								$("#File_Name").val(json[i].File_Name);
								$("#File_Content").val(json[i].File_Content);//.replace(/&quot;/g,"\""));
								$("#File_Name").attr("disabled",'true');
								$("#action").val("update");
								})});
		
}
//ajax数据提交
function ajaxSubmi(){

    $.ajax({
                    type: "post",
                    url: "TemplatePath_Manage.aspx?action="+$("#action").val(),
                    data: 'File_Name=' + $("#File_Name").val() + '&File_Content=' +encodeURIComponent($("#File_Content").val())+"&langflag="+$("#langflag").val()+"&action="+$("#action").val(),
                    beforeSend: function(XMLHttpRequest) {
                        //ShowLoading();
                    },
                    success: function(data, textStatus) {
                       if(data=="false")
                       {
                          alert("当前目录存在同名文件!");
                          return false;
                       }
                        if (data == "true") {
                        parent.dcmsDialog("处理成功","信息更新成功!",function(){
			            var s=$(".tabs",window.parent.document).find("li[class='jericho_tabs tab_selected']").attr("id");
			             parent.dcmstab.closeTab(s);
			            if($("#iframeid").val()!="")
                        {
                            parent.refleshIframe($("#iframeid").val());
                        }
			        });}
                        
                    },
                    complete: function(XMLHttpRequest, textStatus) {
                        //HideLoading();
                    },
                    error: function() {
                        //parent.dcmsDialog("处理失败", "你提交的数据处理失败，请检查数据是否合法！");
                    }
                });
 };

//清空表单数据
function clearInputData(){
	$(":text").val("");
}
</script>
</head>
<body>
<input type="hidden" id="iframeid" value='<%=iframeid%>' />
<div style="width:100%;clear:both;" id="contentBorder">
<form id="updateForm" method="post" action="">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>模板文件编辑管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  <table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="26" class="tdtitle"><div class="titleactive" id="tab_1"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:changetab(1);">基本属性</div><div class="linesplit"></div></div></td>
                </tr>
                <tr>
                  <td>
				  	
					<input type="hidden" id="langflag" runat="server" value="cn" />
                    <input type="hidden" id="action" value="insert" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
					
                      <tr>
                        <td width="120" height="30" align="center">文件名称：</td>
                        <td><input type="text" size="20" style="width:300px" class="{required:true}" name="File_Name" id="File_Name" /></td>
                      </tr>
					  
                     
                      <tr>
                        <td align="center" height="30">文件内容：</td>
                        <td style="padding-top:5px;"><textarea name="File_Content" id="File_Content"  style="width:90%;" rows="16"></textarea></td>
                      </tr>
                    </table>
					
                    <table width="100%" height="50" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="padding-left:50px;"><input type="submit" class="button" value="确认提交" />
                          &nbsp;
                          <input type="reset" onclick="javascript:clearInputData();" class="button" value="清空重写" /></td>
                      </tr>
                    </table></td>
                </tr>
              </table>
</form></div>
<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-20);
//如果是编辑的话取值并初始化
var filename='<asp:Literal ID="lit_filename" runat="server"></asp:Literal>';
if(filename!='')
{
    getOneRecord(filename);
}
</script>
</body>
</html>
