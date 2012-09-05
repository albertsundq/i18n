<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news_update.aspx.cs" Inherits="Manage.news.Manage_news_news_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>新闻管理</title>
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
	    $.get("news_manage.aspx?action=delete&id="+cateid, function(data){getCateRefresh();});
	    parent.$.fn.hideJmodal();
	    });
}
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("news_manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
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
	   url: "news_manage.aspx?action="+$("#action").val()+"&permcateid="+$("#News_CateId").val(),
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
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>新闻管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
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
				  	<input type="hidden" id="News_CateId" runat="server" value="0" />
					<input type="hidden" id="News_Id" runat="server" value="0" />
                    <input type="hidden" id="action" value="insert" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
					    <tr>
                        <td width="120" height="30" align="center">父级栏目：</td>
                        <td><input type="text" size="20" style="width:200px" value="父级栏目" readonly="true" runat="server" id="News_CateName" name="News_CateName" /></td>
                      </tr>  <tr>
                        <td width="120" height="30" align="center">新闻标题：</td>
                        <td><input type="text" size="20" style="width:300px" class="{required:true}" id="News_Title" name="News_Title" /></td>
                      </tr> <tr>
                        <td width="120" height="30" align="center">新闻作者：</td>
                        <td><input type="text" size="20" style="width:300px" value="互联网" id="News_Author" name="News_Author" /></td>
                      </tr>  <tr>
                        <td align="center" height="30">阅读次数：</td>
                        <td><input type="text" size="20" style="width:180px" class="{digits:true}" value="1" id="News_Count" name="News_Count" /></td>
                      </tr> <tr>
                        <td align="center" height="30">新闻图片：</td>
                        <td><input type="text" size="20" style="width:260px" id="News_Image" name="News_Image" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('News_Image')" /></td>
                      </tr><tr>
                        <td width="120" height="30" align="center">新闻视频：</td>
                        <td><input type="text" size="20" style="width:260px" id="News_Video" name="News_Video" /> <input type="button" value="浏览" onclick="parent.ShowImageDialog('News_Video')" /></td>
                      </tr> <tr>
                        <td align="center" height="30">发布时间：</td>
                        <td><input type="text" size="20" style="width:200px" id="News_AddTime" name="News_AddTime" class="{required:true,dateISO:true}" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" />&nbsp;
                                    <img style="CURSOR: hand" onclick="setday(document.getElementById('News_AddTime'))" src="../Green/Images/calendar.gif" /></td>
                      </tr> <tr>
                        <td align="center" height="30">显示状态：</td>
                        <td style="font-weight:normal;"><select id="News_State" name="News_State" style="width:100px">
							<option value="1">显示</option>
							<option value="0">关闭</option>
						</select></td>
                      </tr>  <tr>
                        <td align="center" height="30">首页推荐：</td>
                        <td style="font-weight:normal;"><select id="News_IsIndex" name="News_IsIndex" style="width:160px">
							<option value="0">不首页推荐</option>
							<option value="1">首页推荐</option>
						</select></td>
                      </tr><tr>
                        <td align="center" height="30">链接新闻：</td>
                        <td style="font-weight:normal;"><select id="News_IsUrl" name="News_IsUrl" style="width:100px">
							<option value="0">不是</option>
							<option value="1">是</option>
						</select></td>
                      </tr> <tr>
                        <td width="120" height="30" align="center">链接地址：</td>
                        <td><input type="text" size="20" style="width:300px" value="http://" id="News_Url" name="News_Url" /></td>
                      </tr> <tr>
                        <td align="center" height="30">打开方式：</td>
                        <td style="font-weight:normal;"><select id="News_Target" name="News_Target" style="width:200px">
							<option value="_self">当前窗口打开</option>
							<option value="_blank">弹出新页面</option>
						</select></td>
                      </tr>  <tr>
                        <td align="center" height="30">新闻内容：</td>
                        <td style="padding-top:5px;"><textarea id="News_Content" name="News_Content" class="xheditor" style="width:90%" rows="10"></textarea></td>
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
