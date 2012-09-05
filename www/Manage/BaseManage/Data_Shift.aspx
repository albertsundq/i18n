<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Data_Shift.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Data_Shift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据移动</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
</head>
<body>
<div style="width:100%; margin-left:5; margin-right:5; clear:both;" id="contentBorder">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>数据导入导出</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  
<table width="100%" align="center" border="0"  style="border:1px solid #b4dedc;margin-bottom:5px;" cellspacing="0" cellpadding="0">
  <tr><td height="26" class="tdtitle"><div class="titleactive">
  <div class="linesplit"></div><div class="tabtitle">数据导入导出</div><div class="linesplit"></div>
  </div></td></tr>
  <tr>
    <td>
	<br />

<table width="100%" id="data_table" border="0" style="margin-bottom:5px;font-size:12px;font-weight:bold;" cellspacing="20" cellpadding="15" cellpadding="0">
                       <tr>
                        <td style="width:150px">转换方式:</td>
                        <td><select id="ShiftWay" onchange="setShiftWay()"><option value="0" selected>版本转移</option><option value="1">栏目转移</option></select></td>
                       </tr>
                      <tr>
                        <td style="width:150px">从栏目：</td>
                        <td>版本<div id="cate_lang_from" style="display:inline;"></div><div id="cate_from" style="display:none"></div>
                     
                        </td>
                      </tr>
					  <tr>
                        <td style="width:150px">转移到：</td>
                        <td>版本<div id="cate_lang_to" style="display:inline"></div><div id="cate_to" style="display:none">
                      
                        </div>
                        </td>
                      </tr>
					  <tr>
                        <td style="width:150px">转移类型：</td>
                        <td id="shift_type">
                            
	  	                    <select name="ShiftType" id="ShiftType">
	                            
	                            <option value="Channel">仅转移栏目</option>
	                            <option value="All">转移栏目及内容</option>

                             </select>
	  
                          
                        </td>
                      </tr>
					  <tr>
                        <td style="width:150px">转移后删除</td>
                        <td><input type="radio" name="is_delete" value="0"  checked  />否&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" name="is_delete" value="1"   />是</td>
                      </tr>
                      
					  
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding-left:50px;" height="50"><input type="button" id="btnSubmit" class="button" onclick="javascript:ajaxSubmi();" value="确认提交" /> &nbsp;</td>
  </tr>
</table>
	</td>
  </tr>
</table>

<input type="hidden" id="action" value="shift" />

</div>
<div style="background:blue;width:200px;height:100px;position:absolute;top:400px;left:200px;visibility:hidden" id="loading">正在转移...</div>
</body>
<script type="text/javascript">

function getCateLangFrom(){
	$.get("Data_Manage.aspx?action=getCateLangFrom&time="+Math.random()+"", function(data){
	   //alert(data);
		$("#cate_lang_from").empty().html(data);
	});
	getCateFrom();
}
function getCateLangTo(){
	$.get("Data_Manage.aspx?action=getCateLangTo&time="+Math.random()+"", function(data){
	   //alert(data);
		$("#cate_lang_to").empty().html(data);
	});
	getCateTo();
}
function getCateFrom(){
     
	$.get("Data_Manage.aspx?action=getCateFrom&catelang="+$('#CateLangFrom').find('option:selected').text()+"&time="+Math.random()+"", function(data){
	   //alert(data);
		$("#cate_from").empty().html("栏目"+data);
	});
	
}
function getCateTo(){
     
	$.get("Data_Manage.aspx?action=getCateTo&catelang="+$('#CateLangTo').find('option:selected').text()+"&catefrom="+$("#cate_from").find("select:eq(0)").val()+"&time="+Math.random()+"", function(data){
	   //alert(data);
		$("#cate_to").empty().html("栏目"+data);
	});
}
function setShiftWay()
{
    if($('#ShiftWay').val()=="0")
    {
         $("#cate_from").css("display","none");
         $("#cate_to").css("display","none");
         $("#ShiftType").find("option").empty().remove();
         $("<option value='Channel'>仅转移栏目</option>").appendTo($('#ShiftType'));
         $("<option value='All'>转移栏目及内容</option>").appendTo($('#ShiftType'));
         $(":radio").attr("disabled",'true');
    }
    else
    {
         $("#cate_from").css("display","inline");
         $("#cate_to").css("display","inline");
         $("#ShiftType").find("option").empty().remove();
         $("<option selected='selected' value='Content'>仅转移内容</option>").appendTo($('#ShiftType'));
          $(":radio").removeAttr("disabled");
    }
}
 //$("#cate_from").find("select:eq(0)").live("change",function(){
    //    getCateTo();
  //  });
jQuery(function($){
	getCateLangFrom();
	getCateLangTo();
    $(":radio").attr("disabled",'true');
});

//ajax数据提交
function ajaxSubmi(){
    //alert(getFormData());
   // return;
if($('#ShiftWay').val()=="1" && ($('#cate_from').find('select:eq(0)').val()=="0" || $('#cate_to').find('select:eq(0)').val()=="0"))
{
    alert("请从根目录下选择一个栏目");
    return;
}

  if(confirm("你确定要转移吗?"))
  {
	 $.ajax({
	   type: "post",
	   url: "Data_Manage.aspx?action=shift",
	   data: getFormData(),
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
			$("#loading").show();
	   },
	   success: function(data,text){
	        alert(data);
	        return;

			
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
			$("#loading").show();
	   },
	   error: function(){
			//请求出错处理
			//parent.dcmsDialog("处理失败","权限设定失败!");
			//alert("error");
	   }
	 });
    }
 };
function getFormData(){
 
//	var dataStr="Rad_Domain="+$("input[name='Rad_Domain']:checked").val()+"&Url_Domain="+$("#Url_Domain").val()+"&Url_Page="+decodeURI($('#Url_Page').val())+"&Url_Name="+$("#Url_Name").val()+"&Url_Default="+$("#Url_Default").val();
//	dataStr=$("form").serialize();
//	dataStr=dataStr+"&Url_Page="+decodeURI($('#UrlPage').val());
var dataStr="";
if($('#ShiftWay').val()=="0")
{
    dataStr="ShiftWay="+$("#ShiftWay").val()+"&CateLangFrom="+$("#CateLangFrom").val()+"&CateLangTo="+$("#CateLangTo").val()+"&ShiftType="+$("#ShiftType").val()+"&IsDelete="+$(":radio[name='is_delete'][checked]").val();
}
else
{
    dataStr="ShiftWay="+$("#ShiftWay").val()+"&CateLangFrom="+$("#CateLangFrom").val()+"&CateFrom="+$("#cate_from").find("select:eq(0)").val()+"&CateTo="+$("#cate_to").find("select:eq(0)").val()+"&CateToName="+$("#cate_to").find("select:eq(0)").find("option:selected").text().substring($('#cate_to').find('select:eq(0)').find("option:selected").text().lastIndexOf('┠')+1)+"&CateLangTo="+$("#CateLangTo").val()+"&ShiftType="+$("#ShiftType").val()+"&IsDelete="+$(":radio[name='is_delete'][checked]").val();
}
return dataStr;	
}
</script>
</html>
