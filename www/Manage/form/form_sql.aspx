<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form_sql.aspx.cs" Inherits="Manage.form.Manage_form_form_sql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>在线执行sql</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />

<script type="text/javascript" src="../Green/Js/jquery.js"></script>

<!--表单验证开始-->
<script src="../Green/Js/jquery.validate.pack.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function() {
    $("#area_sql").focus();
	changetab(1);
});
</script>
<style type="text/css">
#updateForm label.error {margin-left: 5px;color:red;font-weight:normal;}
</style>
<!--表单验证结束-->
<script type="text/javascript">
//定义Tab切换
function changetab(tabid){
    
	for(var i=1;i<=3;i++)
	{
		$("#tab_"+i).removeClass("titleactive");
		
	}
	$("#tab_"+tabid).addClass("titleactive");
	
}
//ajax数据提交
function ajaxSubmi(){
     if($.trim($("#area_sql").val())=="")
     {
        alert('请输入SQL查询语句！');
        $("#area_sql").val("");
        $("#area_sql").focus();
        return;
     }
	 $.ajax({
	   type: "post",
	   url: "form_manage.aspx?action=esql",
	   data: "areasql="+$.trim($("#area_sql").val()),
	   success: function(data, textStatus){
			//请求成功处理;
		    $("#result").empty();
		    $("#result").html(data);
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","信息更新处理失败!");
	   }
	 });
 };
 //ajax查看sql帮助
function viewsqlhelp(id){
    
	     $.ajax({
	       type: "post",
	       url: "form_manage.aspx?action=viewsqlhelp",
	       data:"id="+id,
	       success: function(data, textStatus){
			    //请求成功处理;
		        $("#result").empty();
		        $("#result").html(data);
	       },
	       error: function(){
			    //请求失败处理
			    parent.dcmsDialog("处理失败","信息处理失败!");
	       }
	     });
	
	
 };
//清空表单数据
function clearInputData(){
	$("#area_sql").val("");
}
</script>
</head>
<body>
<input type="hidden" id="iframeid" value='<%=iframeid%>' />
<div style="width:100%;clear:both;" id="contentBorder">

  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：表单管理>在线执行sql><span style="color:red">(操作前请先备份数据库，非专业人员请勿尝试！)</span></td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  <table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="26" class="tdtitle"><div class="titleactive" id="tab_1"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:changetab(1)">执行sql</div><div class="linesplit"></div></div><div class="titleactive" id="tab_2"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:viewsqlhelp(2);changetab(2);">查看mssql帮助</div></div><div class="titleactive" id="tab_3"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:viewsqlhelp(3);changetab(3)">查看sqlite帮助</div></div></td>
                </tr>
                <tr>
                  <td>
					
                   
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
                      <tr>
                        <td></td>
                        <td><textarea name="area_sql" id="area_sql" rows="5" wrap="OFF" style="width:100%;"></textarea></td>
                      </tr>
					   
                    </table>
					
                    <table width="100%" height="50" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="padding-left:50px;"><input type="button" class="button" value="确认提交" onclick="ajaxSubmi()" />
                          &nbsp;
                          <input type="reset" onclick="javascript:clearInputData();" class="button" value="清空重写" /></td>
                      </tr>
                    </table></td>
                </tr>
              </table>
              <div id="result">
              
              

              </div>
</div>
<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-20);
//如果是编辑的话取值并初始化
</script>
</body>
</html>
