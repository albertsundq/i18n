<%@ Page Language="C#" AutoEventWireup="true" CodeFile="products_update.aspx.cs" Inherits="Manage.products.Manage_products_products_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>产品管理</title>
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
//删除栏目
function delcate(id){
	parent.dcmsDialog("确认删除","你确定要删除您所选定的信息吗?",function(){
	    $.get("products_manage.aspx?action=delete&id="+cateid, function(data){getCateRefresh();});
	    parent.$.fn.hideJmodal();
	    });
}
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("products_manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
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
	   url: "products_manage.aspx?action="+$("#action").val()+"&permcateid="+$("#Products_CateID").val(),
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
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>产品管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
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
				  	<input type="hidden" id="Products_CateID" runat="server" value="0" />
					<input type="hidden" id="Products_ID" runat="server" value="0" />
                    <input type="hidden" id="action" value="insert" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
					   <tr>
                        <td width="120" height="30" align="center">父级栏目：</td>
                        <td><input type="text" size="20" style="width:200px" value="父级栏目" readonly="true" runat="server" id="Products_CateName" name="Products_CateName" /></td>
                      </tr> <tr>
                        <td width="120" height="30" align="center">产品名称：</td>
                        <td><input type="text" size="20" style="width:300px" class="{required:true}" id="Products_Title" name="Products_Title" /></td>
                      </tr>  <tr>
                        <td width="120" height="30" align="center">产品型号：</td>
                        <td><input type="text" size="20" style="width:300px" id="Products_CodeName" name="Products_CodeName" /></td>
                      </tr>  <tr>
                        <td align="center" height="30">阅读次数：</td>
                        <td><input type="text" size="20" style="width:128px" class="{digits:true}" value="1" id="Products_Count" name="Products_Count" /></td>
					  </tr>  <tr>
                        <td align="center" height="30">产品排序：</td>
                        <td><input type="text" size="20" style="width:128px" class="{digits:true}" value="1" id="Products_Order" name="Products_Order" /></td>
                      </tr> <tr>
                        <td align="center" height="30">产品小图：</td>
                        <td><input type="text" size="20" style="width:260px" id="Products_MinImage" name="Products_MinImage" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('Products_MinImage')" /></td>
                      </tr><tr>
                        <td width="120" height="30" align="center">产品大图：</td>
                        <td><input type="text" size="20" style="width:260px" id="Products_BigImage" name="Products_BigImage" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('Products_BigImage')" /></td>
                      </tr><tr>
                        <td width="120" height="30" align="center">产品文档：</td>
                        <td><input type="text" size="20" style="width:260px" id="Products_FileIntro" name="Products_FileIntro" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('Products_FileIntro')" /></td>
                      </tr> <tr>
                        <td align="center" height="30">发布时间：</td>
                        <td><input type="text" size="20" style="width:200px" id="Products_AddTime" name="Products_AddTime" class="{required:true,dateISO:true}" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" />&nbsp;
                                    <img style="CURSOR: hand" onclick="setday(document.getElementById('Products_AddTime'))" src="../Green/Images/calendar.gif" /></td>
                      </tr> <tr>
                        <td align="center" height="30">显示状态：</td>
                        <td style="font-weight:normal;"><select id="Products_State" name="Products_State" style="width:100px">
							<option value="1">显示</option>
							<option value="0">关闭</option>
						</select></td>
                      </tr>  <tr>
                        <td align="center" height="30">是否新品：</td>
                        <td style="font-weight:normal;"><select id="Products_IsNew" name="Products_IsNew" style="width:128px">
							<option value="0">不是</option>
							<option value="1">是</option>
						</select></td>
                      </tr>  <tr>
                        <td align="center" height="30">是否热销：</td>
                        <td style="font-weight:normal;"><select id="Products_IsHot" name="Products_IsHot" style="width:128px">
							<option value="0">不是</option>
							<option value="1">是</option>
						</select></td>
                      </tr>  <tr>
                        <td width="120" height="30" align="center">产品价格：</td>
                        <td><input type="text" size="20" style="width:200px" value="" id="Products_Prices" name="Products_Prices" /></td>
                      </tr>  <tr>
                        <td align="center" height="30">详细介绍：</td>
                        <td style="padding-top:5px;"><textarea id="Products_Introduction" name="Products_Introduction" class="xheditor" style="width:90%" rows="10"></textarea></td>
                      </tr>  <tr>
                        <td align="center" height="30">其它参数：</td>
                        <td style="padding-top:5px;"><textarea id="Products_OtherInfo" name="Products_OtherInfo" class="xheditor" style="width:90%" rows="10"></textarea></td>
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