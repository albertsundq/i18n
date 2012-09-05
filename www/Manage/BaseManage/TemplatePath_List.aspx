<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplatePath_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_TemplatePath_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模板列表</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>


<!--调用表格样式开始-->
<script type="text/javascript" src="../Green/grid/flexigrid.js"></script>
<link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />

<!--调用表格样式结束-->
</head>
<body>
<div style="width:100%;clear:both;" id="contentBorder">
<input id="langflag" type="hidden" value="<%Response.Write(Request.QueryString["path"]); %>" />
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>模板文件管理</td>
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
            function griddblclick(oRow){
              
              var colId = oRow.cells[0].childNodes[0].innerHTML;
               
                var iframeid=$(".curholder",window.parent.document).find("iframe[name^='jerichotabiframe']").attr("id");
                $("#setUrl").html("<span id='templatepathurl"+colId+"' dataType='iframe' dataLink='../basemanage/templatepath_update.aspx?iframeid="+iframeid+"&filename="+colId+"&action=update&langflag="+$("#langflag").val()+"&id=1'>编辑"+colId+"模板文件</span>");
				parent.dcmstab.buildChildTab(document.getElementById("templatepathurl"+colId));
				$("#setUrl").html("");
            }

            function UpdateShow(colId){
               
                var oDialog = parent.dcmsDialogJson({
                    title: (typeof (colId) != 'undefined') ? '模板文件 - 编辑' : '模板文件 - 创建',
                    initWidth:800,
                    content: function(body) {
                        body.html($("#DivDialog").html());
                        if (typeof (colId) != 'undefined') {
                            //返回Json格式数据记录
                            $.getJSON("TemplatePath_Manage.aspx?action=getone&time="+Math.random()+"&filename="+colId+"&langflag="+$("#langflag").val(),function(json){
								$.each(json,function(i){
								
								$("#File_Name", body).val(json[i].File_Name);
								$("#File_Content", body).val(json[i].File_Content.replace(/&quot;/g,"\""));
								$("#File_Name", body).attr("disabled",'true');
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
                        if ($('#File_Name', body).val() == '') {
                            alert('请填写文件名称！');
                            $('#File_Name', body).focus();
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
                    url: "TemplatePath_Manage.aspx?action="+$("#action", body).val(),
                    data: 'File_Name=' + $("#File_Name", body).val() + '&File_Content=' + $("#File_Content", body).val()+"&langflag="+$("#langflag").val(),
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
			url: 'TemplatePath_Manage.aspx?action=select&langflag='+$("#langflag").val(),
			dataType: 'json',
			colModel : [
				{display: '文件名称', name : 'File_Name', width : '300', sortable : false, align: 'center'},
				{display: '文件大小', name : 'File_Size', width : $("#contentBorder").width()-955, sortable : false, align: 'center'},
				{display: '创建时间', name : 'File_AddTime', width : '300', sortable : false, align: 'center'},
				{display: '修改时间', name : 'File_UpdateTime', width : '300', sortable : false, align: 'center'}
				],
			buttons : [
				{name: '新建文件', bclass: 'add', onpress : test},
				
				{name: '批量删除', bclass: 'delete', onpress : test},
				
				
				],
			searchitems : [
				{display: '文件名称', name : 'File_Name', isdefault: true}
				],
			sortname: "File_Name",
			sortorder: "desc",
			usepager: true,
			title: '模板文件列表',
			useRp: true,
			rp: 10,
			procmsg:'正在请求数据，请稍候...',
			showTableToggleBtn: true,
			singleSelect: false,
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
				else if (com=='新建文件')
					{
					    //UpdateShow();
					     
                         var iframeid=$(".curholder",window.parent.document).find("iframe[name^='jerichotabiframe']").attr("id");
                        $("#setUrl").html("<span id='templatepathurl0' dataType='iframe' dataLink='../basemanage/templatepath_update.aspx?iframeid="+iframeid+"&action=insert&langflag="+$("#langflag").val()+"&id=0'>新建模板文件</span>");
			            parent.dcmstab.buildChildTab(document.getElementById("templatepathurl0"));
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
<div id="DivDialog" style="display: none;width:600">
<!--编辑器调用开始-->

	<input type="hidden" id="Lang_Flag" value="cn" />
	<input type="hidden" id="action" value="insert" />
	<table width="100%" border="0" style="margin-bottom: 5px; font-size: 12px; font-weight: bold;" cellspacing="0" cellpadding="0">
		<tr>
			<td style="height:25px;" width="120" align="center">
				文件名称：
			</td>
			<td width="220">
				<input type="text" size="20" style="width:200px" id="File_Name" />
			</td>
		</tr>
		<tr>
			<td style="height:25px;" align="center">
				文件内容：
			</td>
			<td width="600">
			    <textarea  id="File_Content" cols="60" rows="25"   style="overflow:scroll"></textarea>
				
			</td>
		</tr>
	</table>
</div>
</div>
</body>
<script type="text/javascript">
$("#btnReset").click(function(){clearInputData()});


//批量删除
function deleteCheck(IdStr){
	$.get("TemplatePath_Manage.aspx?action=delete&files="+IdStr+"&langflag="+$("#langflag").val(), function(data){
	    if(data=="true"){
	    //parent.dcmsDialog("删除成功","数据删除成功!");
	    parent.$.fn.hideJmodal();
	    $(".pReload").click();}});
}


</script>
</html>
