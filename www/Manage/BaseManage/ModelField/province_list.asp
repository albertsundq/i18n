<%@ Page Language="C#" AutoEventWireup="true" CodeFile="province_list.aspx.cs" Inherits="Manage.Province.Manage_province_province_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>{0}列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<!--调用表格样式开始-->
<script type="text/javascript" src="../Green/grid/flexigrid.js"></script>
<link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />
</head>
<body>
<input type="hidden" id="Cate_Id" runat="server" value="0" />
<input type="hidden" id="Cate_Name" runat="server" value="0" />
   <div style="width:100%; margin-left:auto; margin-right:auto; clear:both" id="contentBorder">

  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理>{0}管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right"><script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  
  <table id="flex1" style="display:none;"></table>
<script type="text/javascript">
    var contentW=$("#contentBorder").width();
	$("#contentBorder").width(contentW-20);
</script>
<script type="text/javascript">
            function griddblclick(oRow) {
                //colId:用户ID号
                var colId = oRow.cells[0].childNodes[0].innerHTML;
                var cateId=$("#Cate_Id").val();
                var cateName=$("#Cate_Name").val();
				var iframeid=$(".curholder",window.parent.document).find("iframe[name^='jerichotabiframe']").attr("id");
                $("#setUrl").html("<span id='baseinfourl"+colId+"' dataType='iframe' dataLink='../province/{1}province_update.aspx?iframeid="+iframeid+"&action=update&catename="+cateName+"&permcateid="+cateId+"&cateid="+cateId+"&id="+colId+"'>编辑"+cateName+"</span>");
				parent.dcmstab.buildChildTab(document.getElementById("baseinfourl"+colId));
				$("#setUrl").html("");
            }
			$("#flex1").flexigrid
			(
			{
			url: 'province_manage.aspx?action=select&cateid='+$("#Cate_Id").val(),
			dataType: 'json',
			colModel : [
				{display: 'ID编号', name : 'Province_Id', width : 80, sortable : false, align: 'center'},
				{display: '省份名称', name : 'Province_Title', width : $("#contentBorder").width()-360, sortable : false, align: 'center'},
				{display: '是否中心', name : 'Province_IsCenter', width : 100, sortable : false, align: 'center'}				
				],
			buttons : [
				{name: '新增省份', bclass: 'add', onpress : test},
				{name: '批量删除', bclass: 'delete', onpress : test}
				],
			searchitems : [
				{display: '省份名称', name : 'Link_Title', isdefault: true}
				],
			sortname: "Province_Id",
			sortorder: "desc",
			usepager: true,
			title: '{0}列表',
			useRp: true,
			rp: 10,
			procmsg:'正在请求数据，请稍候...',
			showTableToggleBtn: true,
			width: $("#contentBorder").width()-1
			}
			);
			function test(com,grid)
			{
				if (com=='批量删除')
					{
						parent.dcmsDialog("确认删除","确认删除选中的数据?一旦删除将无法恢复!",function(){
						    var IdStr="";
						    $('.trSelected',grid).each(function (index, domEle){IdStr=IdStr+","+$(domEle).children().eq(0).text();});
						    deleteCheck(IdStr);
						});
					}
				else if (com=='新增省份')
					{
					    var cateId=$("#Cate_Id").val();
                        var cateName=$("#Cate_Name").val();
						var iframeid=$(".curholder",window.parent.document).find("iframe[name^='jerichotabiframe']").attr("id");
                        $("#setUrl").html("<span id='url0' dataType='iframe' dataLink='../province/{1}province_update.aspx?iframeid="+iframeid+"&action=insert&catename="+cateName+"&permcateid="+cateId+"&cateid="+cateId+"&id=0'>新建"+cateName+"</span>");
			            parent.dcmstab.buildChildTab(document.getElementById("url0"));
				        $("#setUrl").html("");
					}
			}

		$('b.top').click
		(
			function ()
				{
					$(this).parent().toggleClass('fh');
				}
		);
</script>


<div id="setUrl" style="display:none"></div>

</div>
</body>
<script type="text/javascript">
//批量删除
function deleteCheck(IdStr){
	$.get("province_manage.aspx?action=delete&id="+IdStr, function(data){
	    if(data=="true"){
	    parent.dcmsDialog("删除成功","数据删除成功!");
	    $(".pReload").click();}});
}
</script>
</html>
