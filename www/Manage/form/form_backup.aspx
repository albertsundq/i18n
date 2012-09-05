<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form_backup.aspx.cs" Inherits="Manage.form.Manage_form_form_backup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>会员管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<!--表单验证开始-->
<script src="../Green/Js/jquery.validate.pack.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function() {
    $(":text").eq(0).focus();
    changetab(1);
    getBakList();
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
    if(tabid==1)
    {
        $("#action").val("backup");
       
    }
    if(tabid==2)
    {
        $("#action").val("restore");
    }
	for(var i=1;i<=2;i++)
	{
		$("#tab_"+i).removeClass("titleactive");
		$("#tabcontent_"+i).css("display","none");
	}
	$("#tab_"+tabid).addClass("titleactive");
	$("#tabcontent_"+tabid).css("display","block");
}


//ajax数据提交
function ajaxSubmi(){
    if($("#action").val()=="backup" && $.trim($("#BackUp_Name").val())=="")
    {
        alert("请输入要备份的文件名称");
        $("#BackUp_Name").focus();
        return;
    }
    if($("#action").val()=="restore" && $.trim($("#BackUp_File").val())=="")
    {
        alert("请选择要还原的文件名称");
        $("#BackUp_File").focus();
        return;
    }
	 $.ajax({
	   type: "post",
	   url: "form_manage.aspx?action="+$("#action").val(),
	   data: getFormData(),
	   success: function(data, textStatus){
			//请求成功处理;
			alert(data);
			getBakList();
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","信息更新处理失败!");
	   }
	 });
 };
 //取表单数据
function getFormData()
{
	var dataStr="dcms=dcms";
	$(":input[id]").each(function (index, domEle) {
		var idname=$(domEle).attr("id");
		if(idname.indexOf("_")!=-1)
		{
			dataStr=dataStr+"&"+$(domEle).attr("id")+"="+encodeURIComponent($(domEle).val());
		}
 	});
	return(dataStr);
}
//清空表单数据
function clearInputData(){
	$(":text").val("");
}
//选择数据库备份文件
function secbak(name)
{
    $("#BackUp_File").val(name);
}
//删除数据库备份文件
function delbak(name)
{
if(confirm("删除后不能恢复，确定要删除吗？"))
{
   $.ajax({
	   type: "post",
	   url: "form_manage.aspx?action=delbak",
	   data: "bakname="+name,
	   success: function(data, textStatus){
			//请求成功处理;
			alert(data);
			getBakList();
	   },
	   error: function(){
			//请求失败处理
			alert("信息获取失败!");
	   }
	 });
	}
}
//获取数据库备份文件列表
function getBakList(){
	 $.ajax({
	   type: "post",
	   url: "form_manage.aspx?action=getbaklist",
	   data: getFormData(),
	   success: function(data, textStatus){
			//请求成功处理;
			$("#tdbaklist").html(data);
			if(data=="false")
			{
			    alert(data);
			}
	   },
	   error: function(){
			//请求失败处理
			alert("信息获取失败!");
	   }
	 });
 };
</script>
</head>
<body>
<input type="hidden" id="iframeid" value='<%=iframeid%>' />
<div style="width:100%;clear:both;" id="contentBorder">
<form id="updateForm" method="post" action="">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站数据库管理>数据库备份></td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  <table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="26" class="tdtitle"><div class="titleactive" id="tab_1"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:changetab(1);">数据库备份</div><div class="linesplit"></div></div><div class="titleactive" id="tab_2"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:changetab(2);">数据库还原</div></div></td>
                </tr>
                <tr>
                  <td>
					
                    <input type="hidden" id="action" value="backup" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
					  <tr>
                        <td width="120" height="30" align="center">备份名称：</td>
                        <td><input type="text" size="20" style="width:200px" id="BackUp_Name" name="BackUp_Name" value='<%=litbakname %>' />(备份路径为根目录/app_data) </td>
                      </tr>
					   
                    </table>
					<table width="100%" id="tabcontent_2" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;display:none" cellspacing="0" cellpadding="0">
					  <tr>
                        <td width="120" height="30" align="center">数据库备份文件：</td>
                        <td id="tdbaklist"></td>
                      </tr>
					   <tr>
                        <td width="120" height="30" align="center">请从上面选择一个数据库备份文件：</td>
                        <td><input type="text" size="20" style="width:200px" id="BackUp_File" name="BackUp_File" value='' /></td>
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
</script>
</body>
</html>
