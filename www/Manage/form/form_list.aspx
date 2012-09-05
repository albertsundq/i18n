<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form_list.aspx.cs" Inherits="Manage.form.Manage_form_form_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>数据库管理</title>
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
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：网站内容管理><asp:Literal ID="lit_Title" runat="server"></asp:Literal></td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right"><script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
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
                var tableid=oRow.cells[1].childNodes[0].innerHTML;
               FieldShow(colId,tableid);
            }
            function FieldShow(idstr,tablenamestr) {
                var oDialog = parent.dcmsDialogJson({
                    title: '查看'+tablenamestr+"字段列表",
                    content: function(body) {
                        body.html($("#DivDialog").html());

                     $.get("form_Manage.aspx?action=fieldshow&tableid="+idstr+"&tablename="+tablenamestr+"&time="+Math.random()+"", function(data){

		                   $("#showcontent",body).empty().html(data);
		                     
	                    });
                       
                    },
                    data: "",
                    okEvent: function() {
                        
                    }
                });
            }
			$("#flex1").flexigrid
			(
			{
			url: 'form_manage.aspx?action=select&cateid='+$("#Cate_Id").val(),
			dataType: 'json',
			colModel : [
				{display: 'ID编号', name : 'id', width : 100, sortable : false, align: 'center'},
				{display: '表名', name : 'name', width : $("#contentBorder").width()-560, sortable : false, align: 'center'},
				{display: '创建时间', name : 'crdate', width : 200, sortable : false, align: 'center'}
				],
			buttons : [
			    {name: '查看字段', bclass: 'add', onpress : test},
				{name: '执行sql', bclass: 'delete', onpress : test},
				{name: '生成代码', bclass: 'add', onpress : test},
				{name: '数据库备份与还原', bclass: 'delete', onpress : test}
				],
			searchitems : [
				{display: '表名', name : 'name', isdefault: true}
				],
			sortname: "id",
			sortorder: "desc",
			usepager: true,
			title: '数据表名',
			useRp: true,
			rp: 10,
			singleSelect: true,
			procmsg:'正在请求数据，请稍候...',
			showTableToggleBtn: true,
			width: $("#contentBorder").width()-1
			}
			);
			function test(com,grid)
			{
				if (com=='查看字段')
				{
					
				        var IdStr="";
				        var tablestr="";
				        $('.trSelected',grid).each(function (index, domEle)
				        {
				            IdStr=$(domEle).children().eq(0).text();
				            tablestr=$(domEle).children().eq(1).text();
				         });
				         if(IdStr.length>0)
				         {
				             FieldShow(IdStr,tablestr);
				        }
			      
				}
				else if (com=='生成代码')
					{
					   if(confirm('生成后需要重新登录,你确定要生成代码吗？'))
					   {
					         $.get("form_Manage.aspx?action=makecode&time="+Math.random()+"", function(data){

		                         if(data=="true")
		                         {
		                            alert("生成成功！");
		                            top.location.href="../adminlogin.aspx";
		                         }
		                     
	                        });
					   }
					}		
				else if (com=='执行sql')
					{
                        $("#setUrl").html("<span id='urlA' dataType='iframe' dataLink='../form/form_sql.aspx?action=exsql&catename=执行sql&permcateid=0&cateid=0'>在线执行sql</span>");
		                parent.dcmstab.buildChildTab(document.getElementById("urlA"));
			            $("#setUrl").html("");
					}
					else if (com=='数据库备份与还原')
					{
                         $("#setUrl").html("<span id='urlA' dataType='iframe' dataLink='../form/form_backup.aspx?action=backup&catename=备份数据库&permcateid=0&cateid=0'>备份数据库</span>");
		                parent.dcmstab.buildChildTab(document.getElementById("urlA"));
			            $("#setUrl").html("");

					}	
					else if (com=='执行sql')
					{
                        $("#setUrl").html("<span id='urlA' dataType='iframe' dataLink='../form/form_sql.aspx?action=exsql&catename=执行sql&permcateid=0&cateid=0'>在线执行sql</span>");
		                parent.dcmstab.buildChildTab(document.getElementById("urlA"));
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
<div id="DivDialog" style="display: none;">
            
         <div id="showcontent" style="height:200px;overflow-y:auto;scrollbar-face-color: #EDFAED; scrollbar-shadow-color: #EDFAED; scrollbar-highlight-color:#EDFAED; scrollbar-3dlight-color: #DBEBFE; scrollbar-darkshadow-color:#458CE4; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #458CE4">
         
                </div>
            
        </div>
</div>
</body>
<script type="text/javascript">
//批量删除
function deleteCheck(IdStr){
	$.get("user_manage.aspx?action=delete&id="+IdStr, function(data){
	    if(data=="true"){
	    parent.dcmsDialog("删除成功","数据删除成功!");
	    $(".pReload").click();}});
}
</script>
</html>
