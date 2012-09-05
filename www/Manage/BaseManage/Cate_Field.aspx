<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cate_Field.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Cate_Field" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目视图</title>
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
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>栏目视图</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right"><script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
<table width="100%" align="center" border="0"  style="border:1px solid #c8dcc4;margin-bottom:5px;" cellspacing="0" cellpadding="0">
  <tr><td height="26" class="tdtitle"><div class="titleactive">
  <div class="linesplit"></div><div class="tabtitle">栏目视图</div><div class="linesplit"></div>
  </div></td></tr>
  <tr>
    <td>
<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0" style="border-top:1px solid #c8dcc4;margin-top:8px;margin-bottom:8px;" class="example" id="dnd-example">
 <%-- <tr class="trlinetitlebg">
	<td>分类名称</td>
	<td>&nbsp;</td>
    <td>语言版本</td>
    <td>分类ID</td>
    <td>分类标识</td>
    <td>类别</td>
	<td>&nbsp;</td>
  </tr>--%>
  <tbody>
  <asp:Literal ID="lit_cateTree" runat="server"></asp:Literal>
  </tbody>
</table>

	</td>
  </tr>
  
    
</table>
</div>
</body>
</html>
