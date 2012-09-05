<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QMenu_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_QMenu_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>快捷菜单</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<script type="text/javascript" src="../Green/Js/dcmsmain.js"></script>
<script type="text/javascript">
//ajax数据提交
function ajaxSubmi(id,action,du){
	 $.ajax({
	   type: "post",
	   url: "QMenu_Manage.aspx?action="+action,
	   data: 'du='+du+'&QM_Id='+id,
	   success: function(data, textStatus){
			//请求成功处理
			getListData();
			parent.getTopQMenu();
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","更新快捷菜失败!");
	   }
	 });
 };
 function getListData(){
	 $.ajax({
	   type: "post",
	   url: "QMenu_Manage.aspx?action=select",
	   success: function(data, textStatus){
			//请求成功处理
			$("#QMenuList").html(data);
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","取快捷菜失败!");
	   }
	 });
 };
$().ready(function() {
	getListData();
})
</script>
</head>
<body>
<div style="width:99%;clear:both;" id="contentBorder">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>快捷菜单管理</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top"><table width="100%" border="0" style="border:1px solid #c8dcc4;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="25" class="left_cate"><div class="cate_title">快捷菜单</div></td>
                </tr>
                <tr>
                  <td>
				  <table width="100%" border="0" cellspacing="0" cellpadding="0">
				  <tr style="background-color:#edfaed;">
				    <td height="25" style="border-top:1px solid #cccccc;">&nbsp;&nbsp;&nbsp;链接名称</td>
				    <td width="70" style="border-top:1px solid #cccccc;">&nbsp;排序</td>
				    <td width="70" style="border-top:1px solid #cccccc;">删除</td>
				    </tr>
				  </table>
				  </td>
                </tr>
				<tr>
                  <td id="QMenuList">
				  </td>
                </tr>
              </table></td>
          </tr>
        </table>

</div>
</body>

<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-10);
</script>
</html>
