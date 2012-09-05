<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Role_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Role_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>系统角色</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<!--调用表格样式开始-->
<script type="text/javascript" src="../Green/grid/flexigrid.js"></script>
<link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />
<!--调用表格样式结束-->
</head>
<body>
<div style="width:100%;clear:both;;" id="contentBorder">

  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>系统角色管理</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
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
                UpdateShow(colId);
            }

            function UpdateShow(colId) {
                var oDialog = parent.dcmsDialogJson({
                    title: (typeof (colId) != 'undefined') ? '系统角色 - 编辑' : '系统角色 - 创建',
                    content: function(body) {
                        body.html($("#DivDialog").html());
                        if (typeof (colId) != 'undefined') {
                            //返回Json格式数据记录
                            $.getJSON("Role_Manage.aspx?action=getone&time="+Math.random()+"&id="+colId,function(json){
								$.each(json,function(i){
								//alert($("#Role_Name"));
								$("#Role_Name", body).val(json[i].Role_Name);
								$("#Role_Order", body).val(json[i].Role_Order);
								$("#Role_Id", body).val(json[i].Role_Id);
								$("#action", body).val("update");
								})});
                        }
                        else {
                            $("#action", body).val("insert");
                        }

                    },
                    data: "",
                    okEvent: function() {
                        var body = arguments[1].body;
                        if ($('#Role_Name', body).val() == '') {
                            alert('请填写角色名！');
                            $('#Role_Name', body).focus();
                            return false;
                        }
                        return UpdateSubmit(body);
                    }
                });
            }
			//ajax数据提交
            function UpdateSubmit(body) {
                $.ajax({
                    type: "post",
                    url: "Role_Manage.aspx?action="+$("#action", body).val(),
                    data: 'Role_Name=' + $("#Role_Name", body).val() + '&Role_Order=' + $("#Role_Order", body).val() + '&Role_Id=' + $("#Role_Id", body).val() + '',
                    beforeSend: function(XMLHttpRequest) {
                        //ShowLoading();
                    },
                    success: function(data, textStatus) {
                        if (data == "true") {
                            $(".pReload").click();
                            parent.$.fn.hideJmodal();
                        }
                    },
                    complete: function(XMLHttpRequest, textStatus) {
                        //HideLoading();
                    },
                    error: function() {
                        //parent.dcmsDialog("处理失败", "你提交的数据处理失败，请检查数据是否合法！");
                    }
                });
            }
			$("#flex1").flexigrid
			(
			{
			url: 'Role_Manage.aspx?action=select',
			dataType: 'json',
			colModel : [
				{display: 'ID编号', name : 'Role_Id', width : '100', sortable : false, align: 'center'},
				{display: '角色名称', name : 'Role_Name', width : $("#contentBorder").width()-455, sortable : false, align: 'center'},
				{display: '排序', name : 'Role_Order', width : '100', sortable : false, align: 'center'},
				{display: '创建时间', name : 'Role_AddTime', width : '200', sortable : false, align: 'center'}
				],
			buttons : [
				{name: '创建角色', bclass: 'add', onpress : test},
				{name: '批量删除', bclass: 'delete', onpress : test},
				{name: '编辑角色', bclass: 'add', onpress : test},
				{name: '权限设置', bclass: 'add', onpress : test}
				],
			searchitems : [
				{display: '角色名称', name : 'Role_Name', isdefault: true}
				],
			sortname: "Role_Id",
			sortorder: "desc",
			usepager: true,
			title: '系统角色列表',
			useRp: true,
			rp: 10,
			procmsg:'正在请求数据，请稍候...',
			showTableToggleBtn: true,
			singleSelect: true,
			width: $("#contentBorder").width()-2,
			height: 265
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
				else if (com=='创建角色')
					{
					    UpdateShow();
					}	
				else if (com=='编辑角色')
					{
						$(".flexigrid").toggleClass('hideBody');
						getOneRecord($('.trSelected td:eq(0)',grid).text());
					}		
				else if (com=='权限设置')
					{
					    var roleId=$('.trSelected td:eq(0)',grid).text();
					    var roleName=$('.trSelected td:eq(1)',grid).text();
					    if(roleId.length>0)
					    {
					        $("#setPopedomUrl").html("<span id='popedomurl"+roleId+"' dataType='iframe' dataLink='../BaseManage/Popedom_Set.aspx?action=select&roleId="+roleId+"'>"+roleName+"权限设置</span>");
						    parent.dcmstab.buildChildTab(document.getElementById("popedomurl"+roleId));
							$("#setPopedomUrl").html("");
						}
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

<div id="setPopedomUrl" style="display:none;"></div>
<div id="DivDialog" style="display: none;">
	<input type="hidden" id="Role_Id" value="0" />
	<input type="hidden" id="action" value="insert" />
	<table width="100%" border="0" style="margin-bottom: 5px; font-size: 12px; font-weight: bold;"
		height="80" cellspacing="0" cellpadding="0">
		<tr>
			<td style="height:25px;" width="120" align="center">
				角色名称：
			</td>
			<td width="220">
				<input type="text" size="20" style="width:200px" id="Role_Name" />
			</td>
		</tr>
		<tr>
			<td style="height:25px;" align="center">
				角色排序：
			</td>
			<td>
				<input type="text" size="20" style="width: 200px" id="Role_Order" />
			</td>
		</tr>
	</table>
</div>
</div>
</body>
<script type="text/javascript">
$("#btnReset").click(function(){clearInputData()});
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("Role_Manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		$("#Role_Name").val(json[i].Role_Name);
		$("#Role_Order").val(json[i].Role_Order);
		$("#Role_Id").val(json[i].Role_Id);
		$("#action").val("update");
		$("#adminTitle").html("编辑角色\""+json[i].Role_Name+"\"信息");
		})});
}
//批量删除
function deleteCheck(IdStr){
	$.get("Role_Manage.aspx?action=delete&id="+IdStr, function(data){
	    if(data=="true"){
	    //parent.dcmsDialog("删除成功","数据删除成功!");
	    parent.$.fn.hideJmodal();
	    $(".pReload").click();}});
}
//ajax数据提交
$("#btnSubmit").click(function(){
	 $.ajax({
	   type: "post",
	   url: "Role_Manage.aspx?action="+$("#action").val(),
	   data: 'Role_Name=' + $("#Role_Name").val() + '&Role_Order=' + $("#Role_Order").val() + '&Role_Id=' + $("#Role_Id").val() + '',
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
	   },
	   success: function(data, textStatus){
			if(data=="true"){
			parent.dcmsDialog("处理成功","数据处理成功!");
			if($(".flexigrid").hasClass("hideBody"))
			{
				$(".flexigrid").toggleClass('hideBody');
			}
			$(".pReload").click();
			clearInputData();}
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
	   },
	   error: function(){
			parent.dcmsDialog("处理失败","数据处理失败!");
	   }
	 });
 });
 function clearInputData(){
 	$("#Role_Name").val("");
	$("#Role_Order").val("");
	$("#Role_Id").val("0");
	$("#action").val("insert");
 }
</script>
</html>
