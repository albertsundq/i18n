<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cate_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Cate_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>网站栏目</title>
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
</head>
<body>
<div style="width:100%;clear:both;" id="contentBorder">
<form id="updateForm" method="post" action="">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>网站栏目管理</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  
  <table width="100%" height="350" border="0" cellpadding="0" cellspacing="0" style="margin-bottom:5px;">
    <tr>
      <td style="height:25px;"><div class="contentitle_left">网站栏目管理</div><div class="contentitle_right"></div></td>
    </tr>
    <tr>
      <td style="border:1px solid #cccccc;padding:10px;" valign="top"><table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="173" width="300" valign="top"><table width="280" border="0" style="border:1px solid #c8dcc4;" align="right" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="25" class="left_cate"><div class="cate_title">网站栏目管理</div><div class="root_cate"></div></td>
                </tr>
                <tr>
                  <td style="padding:10px 10px 15px 20px;" id="LeftCate">
				  
				  </td>
                </tr>
              </table></td>
            <td valign="top" style="padding-left:20px;"><table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="26" class="tdtitle"><div class="titleactive" id="tab_1"><div class="linesplit"></div><div class="tabtitle" onclick="javascript:changetab(1);">栏目基本信息</div><div class="linesplit"></div></div></td>
                </tr>
                <tr>
                  <td style="padding:10px 10px 15px 20px;">
				  	<input type="hidden" id="Cate_Id" name="Cate_Id" value="0" />
                    <input type="hidden" id="action" name="action" value="insert" />
                    <input type="hidden" id="Cate_ModelKeyId" name="Cate_ModelKeyId" value="0" />
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px; font-weight:bold;" cellspacing="0" cellpadding="0">
					  <tr>
                        <td width="120" height="30" align="center">父级栏目：</td>
                        <td id="parentIdHtml"></td>
                      </tr>
                      <tr>
                        <td width="120" height="30" align="center">栏目名称：</td>
                        <td><input type="text" size="20" onblur="javascript:getPyString();" name="Cate_Title" class="{required:true}" style="width:200px" id="Cate_Title" /></td>
                      </tr>
					  <tr>
                        <td align="center" height="30">栏目标识：</td>
                        <td><input type="text" size="20" style="width:200px" id="Cate_Key" name="Cate_Key" /></td>
                      </tr>
					  <tr>
                        <td align="center" height="30">栏目排序：</td>
                        <td><input type="text" size="20" style="width:200px" class="{digits:true}" name="Cate_Order" id="Cate_Order" /></td>
                      </tr>
					  <tr>
                        <td align="center" height="30">内容模型：</td>
                        <td>
                            <asp:Literal ID="lit_Module"  runat="server"></asp:Literal></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">展式方式：</td>
                        <td style="font-weight:normal;"><input id="radioUnique" style="border:0px;" type="radio" name="radioManageUrl" value="0" />
                        单条内容&nbsp;&nbsp;<input id="radioMultiple" style="border:0px;" checked="checked" type="radio" name="radioManageUrl" value="1" />
                        多条内容</td>
                      </tr>
                      <tr>
                        <td align="center" height="30">后台链接：</td>
                        <td><input type="text" size="20" style="width:200px" value="baseinfo_list.aspx" readonly="true" name="Cate_ManageUrl" id="Cate_ManageUrl" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">栏目特性：</td>
                        <td style="font-weight:normal;"><select id="Cate_IsMenu" name="Cate_IsMenu" style="width:205px">
							<option value="1" selected>允许在此栏目添加内容</option>
							<option value="0">不允许在此栏目添加内容</option>
						</select></td>
                      </tr>
					  <tr>
                        <td align="center" height="30">前台链接：</td>
                        <td><input type="text" size="20" style="width:200px" id="Cate_Url" name="Cate_Url" /></td>
                      </tr>
                      <tr>
                        <td align="center" height="30">发布时间：</td>
                        <td><input type="text" size="20" style="width:200px" id="Cate_AddTime" class="{required:true,dateISO:true}" name="Cate_AddTime" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" />&nbsp;
                                    <img style="CURSOR: hand" onclick="setday(document.getElementById('Cate_AddTime'))" src="../Green/Images/calendar.gif" />
									<input type="hidden" id="caddtime" name="caddtime" value="<%=System.DateTime.Now.ToString("yyyy-MM-dd") %>" />
									</td>
                      </tr>
                      <tr>
                        <td align="center" height="30">显示状态：</td>
                        <td style="font-weight:normal;"><select id="Cate_State" name="Cate_State" style="width:100px">
							<option value="1" selected>显示</option>
							<option value="0">关闭</option>
						</select></td>
                      </tr>
					  <tr>
					  	<td width="120" height="30" align="center">栏目图片：</td>
                        <td><input type="text" name="Cate_Image" size="20" style="width:200px" id="Cate_Image" /> <input type="button" value="浏览" name="button1" onclick="parent.ShowImageDialog('Cate_Image')" /></td>
					  </tr>
                      <tr>
                        <td align="center" height="30">栏目说明：</td>
                        <td><textarea name="Cate_Intro" id="Cate_Intro" class="xheditor-mini" style="width:100%" rows="12"></textarea></td>
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
              </table></td>
          </tr>
        </table></td>
    </tr>
  </table>
</form></div>
</body>
<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-10);
//初始化控件值
var Module=$("#Cate_Module option:selected").val();
if($("#radioUnique").attr("checked"))
{
	$("#Cate_ManageUrl").val(Module+"_update.aspx");
}
else
{
	$("#Cate_ManageUrl").val(Module+"_list.aspx");
}
//创建主目录
$(".root_cate").click(function(){
	$(":text").val("");
	$("#Cate_Id").val("0");
	$("#Cate_ParentID").val("0");
	$("#action").val("insert");
	$("#Cate_ModelKeyId").val("0");
	$("#radioMultiple").attr("checked",true);
	$("#Cate_ManageUrl").val("baseinfo_list.aspx");
	$("#Cate_Module").val("baseinfo");
	$("#Cate_AddTime").val($("#caddtime").val());
})
//切换内容模型radioUnique//radioMultiple
$("#Cate_Module").change(function(){
	var Module=$("#Cate_Module option:selected").val();
	var ModelKeyId=$("#Cate_Module option:selected").attr("keyid");
	$("#Cate_ModelKeyId").val(ModelKeyId);
	if($("#radioUnique").attr("checked"))
	{
		$("#Cate_ManageUrl").val(Module+"_update.aspx");
	}
	else
	{
		$("#Cate_ManageUrl").val(Module+"_list.aspx");
	}
})
$("#radioUnique").click(function(){
	var Module=$("#Cate_Module option:selected").val();
	$("#Cate_ManageUrl").val(Module+"_update.aspx");
})
$("#radioMultiple").click(function(){
	var Module=$("#Cate_Module option:selected").val();
	$("#Cate_ManageUrl").val(Module+"_list.aspx");
})
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
//简单的左则树形菜单
function buildTree() {
	$('.functree li').each(function() {
		var cateid=$(this).children('span').attr('thisid');
		$(this).children('span').after("&nbsp;<a Title='增加子栏目' onclick='addcate("+cateid+")' class='cateadd'>&nbsp; &nbsp;</a>&nbsp;<a Title='编辑栏目' onclick='editcate("+cateid+")' class='cateedit'>&nbsp; &nbsp;</a>&nbsp;<a Title='删除栏目' onclick='delcate("+cateid+")' class='catedel'>&nbsp; &nbsp;</a>");
		if ($(this).is(':has(ul)'))
			$(this).addClass('collapse');
		if ($(this).next().is('li') || $(this).next().is('ul'))
			$(this).css({ borderLeft: 'dashed 1px #dedede' });
	})
	$('li.collapse>span').click(function() {
		$(this).parent().children('ul').slideToggle('fast', function() {
			if ($(this).parent().hasClass('collapse'))
				$(this).parent().removeClass('collapse').addClass('expand');
			else
				$(this).parent().removeClass('expand').addClass('collapse');
		})
	})

	$('span.func').css({ 'cursor': 'pointer' }).hover(function() {
		$(this).css({ 'color': '#3de', 'text-decoration': 'underline' });
	}, function() {
		$(this).css({ 'color': '#000', 'text-decoration': 'none' });
	}).click(function() {
		getOneRecord($(this).attr('thisid'));
	});
};
//简单的选取父类树形菜单
function buildParentSelectTree(checkedId) {
	
};
//取名称的拼音首字母
function getPyString(){
    if($("#Cate_Key").val()!="")
    {
        return false;
    }
	$.get("Cate_Manage.aspx?action=getpy&hanzi="+encodeURIComponent($("#Cate_Title").val())+"", function(data){
	    $("#Cate_Key").val(data);
	});
}
//取左边类别树
function getCateRefresh(){
	$.get("Cate_Manage.aspx?action=select&time="+Math.random()+"", function(data){
	    var cateTree=data.split("$|&|$");
  		$("#LeftCate").html(cateTree[0]);
		buildTree();
		$("#parentIdHtml").html(cateTree[1]);
	});
}
//取左边类别树
getCateRefresh();

//添加栏目
function addcate(cateid){
	clearInputData();
	$("#Cate_ParentID").val(cateid);
	$("#Cate_AddTime").val($("#caddtime").val());
	$("#Cate_IsMenu").val("1");
	$("#action").val("insert");
	getOne(cateid);
}
//栏目编辑
function editcate(cateid){
	getOneRecord(cateid);
}
//删除栏目
function delcate(cateid){
	parent.dcmsDialog("确认删除栏目","你确定要删除栏目吗?",function(){
	    $.get("Cate_Manage.aspx?action=delete&id="+cateid, function(data){
	   if(data=="no")
	    {
	        alert("第一大类不能删！");
	        return;
	    }
		getCateRefresh();});
	    parent.$.fn.hideJmodal();
	    parent.getNewScroll();
	    parent.getTreeLeftMenu();
	    });
}
//ajax请求单条数据修改设置子类继承父类
function getOne(id){
	 $.getJSON("Cate_Manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		var Cate_ModelKeyId=json[i]["Cate_ModelKeyId"].toString();
		var Cate_Module=json[i]["Cate_Module"].toString();
		$("#Cate_ModelKeyId").val(Cate_ModelKeyId);
		$("#Cate_Module option:[value='"+Cate_Module+"'][keyid='"+Cate_ModelKeyId+"']").attr("selected","true");
		
	    if(json[i]["Cate_ManageUrl"].indexOf("update")!=-1)
		{
		    $("#radioUnique").attr("checked",true);
		    $("#Cate_ManageUrl").val(json[i]["Cate_Module"]+"_update.aspx");
		}
		if(json[i]["Cate_ManageUrl"].indexOf("list")!=-1)
		{
		   $("#radioMultiple").attr("checked",true);
		   $("#Cate_ManageUrl").val(json[i]["Cate_Module"]+"_list.aspx");
		}
		})});
}
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("Cate_Manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		$(":input[id]").each(function (index, domEle) {
		var idname=$(domEle).attr("id");
		var Cate_ModelKeyId=json[i]["Cate_ModelKeyId"].toString();
		var Cate_Module=json[i]["Cate_Module"].toString();
		$("#Cate_Module option:[value='"+Cate_Module+"'][keyid='"+Cate_ModelKeyId+"']").attr("selected","true");
		
		if(idname.indexOf("_")!=-1)
		{
			$(domEle).val(json[i][idname]);
		}
	    if(json[i]["Cate_ManageUrl"].indexOf("update")!=-1)
		{
		    $("#radioUnique").attr("checked",true);
		}
		if(json[i]["Cate_ManageUrl"].indexOf("list")!=-1)
		{
		   $("#radioMultiple").attr("checked",true);
		}
 		});
		$("#action").val("update");
		})});
}
//ajax数据提交
function ajaxSubmi(){
 
	 $.ajax({
	   type: "post",
	   url: "Cate_Manage.aspx?action="+$("#action").val(),
	   data: getFormData(),
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
	   },
	   success: function(data, textStatus){
			//请求成功处理;
			if(data=="true"){
			parent.dcmsDialog("处理成功","栏目处理成功!");
			getCateRefresh();
			parent.getNewScroll();
			parent.getTreeLeftMenu();
			var pid=$("#Cate_ParentID").val();
			clearInputData();
			$("#Cate_ParentID").val(pid);}
			else
			{
			    alert(data);
			}
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","栏目处理失败!");
	   }
	 });
 };
 //取表单数据
function getFormData()
{
        var ModelKeyId=$("#Cate_Module option:selected").attr("keyid");
        $("#Cate_ModelKeyId").val(ModelKeyId);
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
	$("textarea").val("");
}
</script>
</html>
