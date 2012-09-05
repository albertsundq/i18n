<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestbook_update.aspx.cs" Inherits="Manage.guestbook.Manage_guestbook_guestbook_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>订单管理系统管理</title>
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
#updateForm label.error {
	margin-left: 5px;
	color:red;
	font-weight:normal;
}
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
//删除栏目
function delcate(id){
	parent.dcmsDialog("确认删除","你确定要删除您所选定的信息吗?",function(){
	    $.get("guestbook_manage.aspx?action=delete&id="+cateid, function(data){getCateRefresh();});
	    parent.$.fn.hideJmodal();
	    });
}
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("guestbook_manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		$(":input[id]").each(function (index, domEle) {
		var idname=$(domEle).attr("id");
		if((idname.indexOf("_")!=-1)&&(idname.toLowerCase().indexOf("_catename")==-1))
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
	   url: "guestbook_manage.aspx?action="+$("#action").val()+"&permcateid="+$("#GuestBook_CateId").val(),
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
		else
	   {
	      alert("你没有进行此操作的权限，请联系管理员申请相关权限再进行操作！");
	   }
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
        <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>订单管理系统管理>
          <asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
        <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right"><script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>
          &nbsp;</td>
      </tr>
    </table>
    <table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
      <tr>
        <td height="26" class="tdtitle"><div class="titleactive" id="tab_1">
            <div class="linesplit"></div>
            <div class="tabtitle" onclick="javascript:changetab(1);">基本属性</div>
            <div class="linesplit"></div>
          </div></td>
      </tr>
      <tr>
        <td><input type="hidden" id="GuestBook_CateId" runat="server" value="0" />
          <input type="hidden" id="GuestBook_Id" runat="server" value="0" />
          <input type="hidden" id="action" value="insert" />
          <table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
            <tr>
              <td width="120" height="30" align="center">父级栏目：</td>
              <td><input type="text" size="20" style="width:200px" value="父级栏目" readonly="true" runat="server" id="GuestBook_CateName" name="GuestBook_CateName" /></td>
            </tr>
            <tr>
              <td width="120" height="30" align="center">订单产品：</td>
              <td><input type="text" size="20" style="width:300px" class="{required:true}" id="GuestBook_Title" name="GuestBook_Title" readonly="readonly" /></td>
            </tr>
            <tr>
              <td width="120" height="30" align="center">订单产品编号：</td>
              <td><input type="text" size="20" style="width:200px" class="{required:true}" id="GuestBook_ExFlag3" name="GuestBook_ExFlag3" readonly="readonly" /></td>
            </tr>
            <tr>
              <td width="120" height="30" align="center">订单数量：</td>
              <td><input type="text" size="20" style="width:100px" class="{required:true}" id="GuestBook_ExFlag1" name="GuestBook_ExFlag1" readonly="readonly" /></td>
            </tr>
            <tr>
              <td width="120" height="30" align="center">姓名：</td>
              <td><input type="text" size="20" style="width:300px" id="GuestBook_UserName" name="GuestBook_UserName" /></td>
            </tr>
            <tr>
              <td align="center" height="30">电子邮箱：</td>
              <td><input type="text" size="20" style="width:300px" id="GuestBook_UserEmail" name="GuestBook_UserEmail" /></td>
            </tr>
            <tr>
              <td align="center" height="30">移动电话：</td>
              <td><input type="text" size="20" style="width:200px" id="GuestBook_UserTel" name="GuestBook_UserTel" /></td>
            </tr>
            
            <tr>
              <td align="center" height="30">固定电话：</td>
              <td><input type="text" size="20" style="width:300px" id="GuestBook_UserIM" name="GuestBook_UserIM" /></td>
            </tr>
             <tr>
              <td align="center" height="30">联系地址：</td>
              <td><input type="text" size="20" style="width:300px" id="GuestBook_ExFlag2" name="GuestBook_ExFlag2" /></td>
            </tr>
            <tr>
              <td align="center" height="30">用户IP：</td>
              <td><input type="text" size="20" style="width:200px" id="GuestBook_UserIp" name="GuestBook_UserIp" /></td>
            </tr>
            
            <tr>
              <td align="center" height="30">发布时间：</td>
              <td><input type="text" size="20" style="width:200px" class="{required:true,dateISO:true}" id="GuestBook_AddTime" name="GuestBook_AddTime" />
                &nbsp; <img style="CURSOR: hand" onclick="setday(document.getElementById('GuestBook_AddTime'))" src="../Green/Images/calendar.gif" /></td>
            </tr>
            <tr>
              <td align="center" height="30">显示状态：</td>
              <td style="font-weight:normal;"><select id="GuestBook_State" name="GuestBook_State" style="width:100px">
                  <option value="1">显示</option>
                  <option value="0">关闭</option>
                </select></td>
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
  </form>
</div>
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
