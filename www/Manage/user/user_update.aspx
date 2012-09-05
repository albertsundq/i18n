<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_update.aspx.cs" Inherits="Manage.user.Manage_user_user_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>会员管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/calendar.js"></script>
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<!--编辑器调用开始-->
<script type="text/javascript" src="../../dceditor/xheditor-zh-cn.src.js?v=1.1.0"></script>
<!--编辑器调用结束-->
<!--表单验证开始-->
<script src="../Green/Js/jquery.validate.pack.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function() {
    $(":text").eq(0).focus();
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
function getOneRecord(id){
	 $.getJSON("user_manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		$(":input[id]").each(function (index, domEle) {
		var idname=$(domEle).attr("id");
		if(idname.indexOf("_")!=-1)
		{
			$(domEle).val(json[i][idname]);
		}
 		});
		$("#action").val("update");
		})});
}
//ajax数据提交
function ajaxSubmi(){
	 $.ajax({
	   type: "post",
	   url: "user_manage.aspx?action="+$("#action").val(),
	   data: getFormData(),
	   success: function(data, textStatus){
			//请求成功处理;
			if(data=="true"){
			parent.dcmsDialog("处理成功","信息更新处理成功!",function(){
			    var s=$(".tabs",window.parent.document).find("li[class='jericho_tabs tab_selected']").attr("id");
			    parent.dcmstab.closeTab(s);
			    if($("#iframeid").val()!="")
                 {
                    parent.refleshIframe($("#iframeid").val());
                 }
			});}
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
</script>
</head>
<body>
<input type="hidden" id="iframeid" value='<%=iframeid%>' />
<div style="width:100%;clear:both;" id="contentBorder">
<form id="updateForm" method="post" action="">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>会员管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
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
					<input type="hidden" id="User_Id" runat="server" value="0" />
                    <input type="hidden" id="action" value="insert" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="120" height="30" align="center">用户名：</td>
                        <td><input type="text" size="20" style="width:200px" class="{required:true}" name="User_Name" id="User_Name" /></td>
                      </tr>
					  <tr>
                        <td width="120" height="30" align="center">姓名：</td>
                        <td><input type="text" size="20" style="width:200px" id="User_RealName" /></td>
                      </tr>
					  <tr>
                        <td align="center" height="30">登录密码：</td>
                        <td><input type="password" size="20" style="width:200px" class="{required:true}" name="User_PassWord" id="User_PassWord" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">电子邮箱：</td>
                        <td><input type="text" size="20" style="width:268px" class="{required:true}" name="User_Email" id="User_Email" /></td>
                      </tr>
                      <tr>
                        <td width="120" height="30" align="center">移动电话：</td>
                        <td><input type="text" size="20" style="width:200px" name="User_Tel" id="User_Tel" /></td>
                      </tr>
                      <tr>
                        <td width="120" height="30" align="center">固定电话：</td>
                        <td><input type="text" size="20" style="width:200px" name="User_IM" id="User_IM" /></td>
                      </tr>
                      <!--<tr>
                        <td align="center" height="30">会员等级：</td>
                        <td style="font-weight:normal;"><asp:Literal ID="lit_UserLevel" runat="server"></asp:Literal></td>
                      </tr>-->
                      <tr>
                        <td align="center" height="30">联系地址：</td>
                        <td><input type="text" size="20" style="width:268px" name="User_Address" id="User_Address" /></td>
                      </tr>
                      <!-- <tr>
                        <td align="center" height="30">邮政编码：</td>
                        <td><input type="text" size="20" style="width:268px" name="User_PostCode" id="User_PostCode" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">从事工作：</td>
                        <td><input type="text" size="20" style="width:168px" name="User_Job" id="User_Job" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">所在公司：</td>
                        <td><input type="text" size="20" style="width:168px" name="User_Company" id="User_Company" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">所在城市：</td>
                        <td><input type="text" size="20" style="width:168px" name="User_City" id="User_City" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">所在国家：</td>
                        <td><input type="text" size="20" style="width:168px" name="User_Country" id="User_Country" /></td>
                      </tr>
                      
					  
                      
					  <tr>
                        <td align="center" height="30">会员性别：</td>
                        <td style="font-weight:normal;"><select id="User_Gender" name="User_Gender" style="width:100px">
							<option value="先生">先生</option>
							<option value="女士">女士</option>
						</select></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">会员生日：</td>
                        <td><input type="text" size="20" style="width:200px" id="User_BirthDay" name="User_BirthDay" readonly="readonly" class="{dateISO:true}" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" />&nbsp;
                                    <img style="CURSOR: hand" onclick="setday(document.getElementById('User_BirthDay'))" src="../Green/Images/calendar.gif" /></td>
                      </tr>
                      <tr>
                        <td width="120" height="30" align="center">会员头像：</td>
                        <td><input type="text" size="20" style="width:260px" id="User_Avatar" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('User_Avatar')" /></td>
                      </tr>-->
                      <tr>
                        <td width="120" height="30" align="center">注册IP：</td>
                        <td><input type="text" size="20" style="width:200px" readonly="readonly" name="User_RegIp" id="User_RegIp" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">注册时间：</td>
                        <td><input type="text" size="20" style="width:200px" name="User_RegTime" id="User_RegTime" readonly="readonly" class="{dateISO:true}" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" /></td>
                      </tr>  
                      <tr>
                        <td align="center" height="30">最后访问时间：</td>
                        <td><input type="text" size="20" style="width:200px" name="User_LastTime" id="User_LastTime" readonly="readonly" class="{dateISO:true}" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" /></td>
                      </tr>   
                      <tr>
                        <td align="center" height="30">最后访问IP：</td>
                        <td><input type="text" size="20" style="width:200px" name="User_LastIp" id="User_LastIp" readonly="readonly" /></td>
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
var id='<asp:Literal ID="lit_id" runat="server"></asp:Literal>';
if(parseInt(id)>0)
{
    getOneRecord(parseInt(id));
}

</script>
</body>
</html>