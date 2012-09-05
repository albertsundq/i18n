<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popedom_Set.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Popedom_Set" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>权限设置</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<link href="../Green/jQtreeTable/master.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../Green/jQtreeTable/jquery.treeTable.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/jQtreeTable/jquery.treeTable.js"></script>
<script type="text/javascript">
$(document).ready(function() {
    // TODO Fix issue with multiple treeTables on one page, each with different options
    // Moving the #example3 treeeTable call down will break other treeTables that are expandable...
    $(".example").treeTable({
      expandable: true
    });
    // Drag & Drop Example Code
    $("#dnd-example .file, #dnd-example .folder").draggable({
      helper: "clone",
      opacity: .75,
      refreshPositions: true, // Performance?
      revert: "invalid",
      revertDuration: 300,
      scroll: true
    });
    
    $("#dnd-example .folder").each(function() {
      $($(this).parents("tr")[0]).droppable({
        accept: ".file, .folder",
        drop: function(e, ui) { 
          $($(ui.draggable).parents("tr")[0]).appendBranchTo(this);
        },
        hoverClass: "accept",
        over: function(e, ui) {
          if(this.id != $(ui.draggable.parents("tr")[0]).id && !$(this).is(".expanded")) {
            $(this).expand();
          }
        }
      });
    });
    
    // Make visible that a row is clicked
    $("table#dnd-example tbody tr").mousedown(function() {
      $("tr.selected").removeClass("selected"); // Deselect currently selected rows
      $(this).addClass("selected");
    });
    
    // Make sure row is selected when span is clicked
    $("table#dnd-example tbody tr span").mousedown(function() {
      $($(this).parents("tr")[0]).trigger("mousedown");
    });
  }); 
</script>
</head>
<body>
<div style="width:99%;clear:both;" id="contentBorder">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>角色权限管理</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right"><script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
<table width="100%" align="center" border="0"  style="border:1px solid #c8dcc4;margin-bottom:5px;" cellspacing="0" cellpadding="0">
  <tr><td height="26" class="tdtitle"><div class="titleactive">
  <div class="linesplit"></div><div class="tabtitle">网站栏目权限</div><div class="linesplit"></div>
  </div></td></tr>
  <tr>
    <td>
<input id="hid_roleId" runat="server" type="hidden" />
<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0" style="border-top:1px solid #c8dcc4;margin-top:8px;margin-bottom:8px;" class="example" id="dnd-example">
  <tr class="trlinetitlebg">
	<td>网站栏目名称</td>
	<td>&nbsp;</td>
    <td>查询</td>
    <td>新增</td>
    <td>修改</td>
    <td>删除</td>
	<td>&nbsp;</td>
  </tr>
  <tbody>
  <asp:Literal ID="lit_cateTree" runat="server"></asp:Literal>
  </tbody>
</table>

	</td>
  </tr>
  <tr><td height="26" class="tdtitle" style="border-top:1px solid #c8dcc4;"><div class="titleactive">
  <div class="linesplit"></div>
  <div class="tabtitle">系统模块权限</div>
  <div class="linesplit"></div>
  </div></td></tr>
  <tr>
    <td>
<table width="100%" align="center" border="0" style="border-top:1px solid #c8dcc4;margin-top:8px;margin-bottom:8px;" cellspacing="0" cellpadding="0">
  <tr class="trlinetitlebg">
    <td>&nbsp;</td>
	<td>系统功能名称</td>
	<td>&nbsp;</td>
    <td>查询</td>
    <td>新增</td>
    <td>修改</td>
    <td>删除</td>
	<td>&nbsp;</td>
  </tr>
  <asp:Literal ID="lit_syscate_1" runat="server"></asp:Literal>
</table>
	</td>
  </tr>  
  <tr><td height="26" class="tdtitle" style="border-top:1px solid #c8dcc4;"><div class="titleactive">
  <div class="linesplit"></div>
  <div class="tabtitle">扩展模块权限</div>
  <div class="linesplit"></div>
  </div></td></tr>
  <tr>
    <td>
	<table width="100%" align="center" border="0" style="border-top:1px solid #c8dcc4;margin-top:8px;margin-bottom:8px;" cellspacing="0" cellpadding="0">
  <tr class="trlinetitlebg">
    <td>&nbsp;</td>
	<td>扩展模块名称</td>
	<td>&nbsp;</td>
    <td>查询</td>
    <td>新增</td>
    <td>修改</td>
    <td>删除</td>
	<td>&nbsp;</td>
  </tr>
  <asp:Literal ID="lit_syscate_2" runat="server"></asp:Literal>
</table>
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding-left:50px;" height="39"><input type="submit" id="btnSubmit" class="button" onclick="javascript:ajaxSubmi();" value="确认提交" /> &nbsp;<input type="submit" id="Submit2" class="button" onclick="javascript:checkFan();" value="反 &nbsp;选" /> &nbsp;<input type="submit" id="Submit1" class="button" onclick="javascript:checkAll();" value="全 &nbsp;选" /></td>
  </tr>
</table>

	</td>
  </tr>
    
</table>
</div>
</body>
<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-10);

var selectCate='<asp:Literal ID="lit_select" runat="server"></asp:Literal>';
var selectCateId=selectCate.split(",");
for(var i=0;i<selectCateId.length;i++)
{
	$("input[value='"+selectCateId[i]+"'][name='select']").attr("checked", true);
}
var insertCate='<asp:Literal ID="lit_insert" runat="server"></asp:Literal>';
var insertCateId=insertCate.split(",");
for(var i=0;i<insertCateId.length;i++)
{
	$("input[value='"+insertCateId[i]+"'][name='insert']").attr("checked", true);
}
var updateCate='<asp:Literal ID="lit_update" runat="server"></asp:Literal>';
var updateCateId=updateCate.split(",");
for(var i=0;i<updateCateId.length;i++)
{
	$("input[value='"+updateCateId[i]+"'][name='update']").attr("checked", true);
}
var deleteCate='<asp:Literal ID="lit_delete" runat="server"></asp:Literal>';
var deleteCateId=deleteCate.split(",");
for(var i=0;i<deleteCateId.length;i++)
{
	$("input[value='"+deleteCateId[i]+"'][name='delete']").attr("checked", true);
}

var catelang='<asp:Literal ID="lit_catelang" runat="server"></asp:Literal>';
var catelangarr=catelang.split(",");
for(var i=0;i<catelangarr.length;i++)
{
	$("input[value='"+catelangarr[i]+"']").attr("checked", true);
}
//ajax数据提交
function ajaxSubmi(){
	 $.ajax({
	   type: "post",
	   url: "Popedom_Set.aspx?action=update",
	   data: getFormData(),
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
	   },
	   success: function(data, textStatus){
			//请求成功处理;
			if(data=="true"){
			parent.dcmsDialog("处理成功","权限设置成功!",function(){
			    var s=$(".tabs",window.parent.document).find("li[class='jericho_tabs tab_selected']").attr("id");
			    parent.dcmstab.closeTab(s);
			});}
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
	   },
	   error: function(){
			//请求失败处理
			parent.dcmsDialog("处理失败","权限设置失败!");
	   }
	 });
 };
function getFormData(){
    var catelang="";
	$("input[name='CateLangSelect']:checked").each(function (index, domEle) { 
		catelang=catelang+","+$(domEle).val();
    });
	var selectvalue="";
	$("input[name='select']:checked").each(function (index, domEle) { 
		selectvalue=selectvalue+","+$(domEle).val();
    });
	var insertvalue="";
	$("input[name='insert']:checked").each(function (index, domEle) { 
		insertvalue=insertvalue+","+$(domEle).val();
    });
	var updatevalue="";
	$("input[name='update']:checked").each(function (index, domEle) { 
		updatevalue=updatevalue+","+$(domEle).val();
    });
	var deletevalue="";
	$("input[name='delete']:checked").each(function (index, domEle) { 
		deletevalue=deletevalue+","+$(domEle).val();
    });
    var roleId=$("#hid_roleId").val();
	return "roleId="+roleId+"&selectvalue="+selectvalue+"&insertvalue="+insertvalue+"&updatevalue="+updatevalue+"&deletevalue="+deletevalue+"&catelang="+catelang;
}
function CheckCateFlag(catelang,obj,optype)
{
    switch(optype)
   {
       case "select":
         if($(obj).attr("checked")==true)
         {
             $("input."+catelang+"[name='select']").each(function (index, domEle) { 
		        $(domEle).attr("checked", true);
             });   
         }
         else
         {
             $("input."+catelang+"[name='select']").each(function (index, domEle) { 
		        $(domEle).attr("checked", false);
             }); 
         }
         break;
       case "insert":
         if($(obj).attr("checked")==true)
         {
             $("input."+catelang+"[name='insert']").each(function (index, domEle) { 
		        $(domEle).attr("checked", true);
             });   
         }
         else
         {
             $("input."+catelang+"[name='insert']").each(function (index, domEle) { 
		        $(domEle).attr("checked", false);
             }); 
         }
         break;
       case "update":
         if($(obj).attr("checked")==true)
         {
             $("input."+catelang+"[name='update']").each(function (index, domEle) { 
		        $(domEle).attr("checked", true);
             });   
         }
         else
         {
             $("input."+catelang+"[name='update']").each(function (index, domEle) { 
		        $(domEle).attr("checked", false);
             }); 
         }
         break;
       case "delete":
         if($(obj).attr("checked")==true)
         {
             $("input."+catelang+"[name='delete']").each(function (index, domEle) { 
		        $(domEle).attr("checked", true);
             });   
         }
         else
         {
             $("input."+catelang+"[name='delete']").each(function (index, domEle) { 
		        $(domEle).attr("checked", false);
             }); 
         }
         break;
   }
}

function CheckParentFlag(catelang,optype,parid)
{
	var state='t';
	var parentName='';
	if($(":checkbox[value='"+parid+"'][name='"+optype+"']").attr("checked")==true){
		state='t';	
	}
	else{
		state='f';	
	}
	UpdateChildState(parid,optype,state);
	UpdateParentState(parid,optype,state);
    switch(optype)
    {
       case "select":
            parentName='CateLangSelect';
       break;
       case "insert":
            parentName='CateLangInsert';
       break;
       case "update":
            parentName='CateLangUpdate';
       break;
       case "delete":
            parentName='CateLangDelete';
       break;
       
    }
    
    var i=0;
	$("input."+catelang+"[name='"+optype+"']").each(function(){
	    if($(this).attr("checked")==true){
	        i++;
        }
    });
    if(i>0){
        $("input[name='"+parentName+"'][value='"+catelang+"']").attr("checked",true);
    }else{
        $("input[name='"+parentName+"'][value='"+catelang+"']").attr("checked",false);
    }
}

function UpdateChildState(parid,optype,state)
{
	$(":checkbox[name='"+optype+"'][par='"+parid+"']").each(function(){
		if(state=='t'){
			$(this).attr('checked',true);
		}
		else{
			$(this).attr('checked',false);
			
		}
		UpdateChildState($(this).val(),optype,state);
	});
}

function UpdateParentState(parid,optype,state)
{
	if(parid.length>0){
		if(state=='t'){
			$(":checkbox[value='"+parid+"'][name='"+optype+"']").attr('checked',true);
		}
		else{
			var len=0;
			$(":checkbox[name='"+optype+"'][par='"+parid+"']").each(function(){
				if($(this).attr("checked")==true){
					len++;
				}
			});
			if(len==0){
				$(":checkbox[value='"+parid+"'][name='"+optype+"']").attr('checked',false);
			}
		}
		UpdateParentState($(":checkbox[value='"+parid+"']").attr("par"),optype,state);
	}
}

//全选
function checkAll()
{
    $(":checkbox").attr("checked", true);
}
//反选
function checkFan()
{
    $(":checkbox").each(function (index, domEle) { 
		if($(domEle).attr("checked")==true)
		{
		     $(domEle).attr("checked", false);
		}
		else
		{
		    $(domEle).attr("checked", true);
		}
    }); 
}
</script>
</html>
