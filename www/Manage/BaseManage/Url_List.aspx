<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Url_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Url_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>url列表</title>
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<!--调用表格样式开始-->
<script type="text/javascript" src="../Green/grid/flexigrid.js"></script>
<link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />
<!--调用表格样式结束-->
</head>
<body>
  <div style="width:100%; margin-left:auto; margin-right:auto; clear:both" id="contentBorder">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>url管理</td>
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
                //colId:用户ID号
                var colId = oRow.cells[0].childNodes[0].innerHTML;
                UpdateShow(colId);
            }
            function UpdateShow(colId){
               
                var oDialog = parent.dcmsDialogJson({
                    title: (typeof (colId) != 'undefined') ? '域名 - 编辑' : '域名 - 创建',
                    initWidth:400,
                    content: function(body) {
                        body.html($("#DivDialog").html());
                        
                        if (typeof (colId) != 'undefined') {
                             $("#Url_Domain",body).attr("disabled",true);  
                             $(":radio",body).attr("disabled",'true');
                            //返回Json格式数据记录
                            $.getJSON("Url_Manage.aspx?action=getone&time="+Math.random()+"&domain="+colId,function(json){
								$.each(json,function(i){
								$("#Url_Page",body).val(json.Url_Page);
	                            $("#Url_Name",body).val(json.Url_Name);
	                            $("#Url_Domain",body).val(json.Url_Domain);
	                            if(json.Url_Value=="0")
		                        {
		                            $("input[@name='Rad_Domain'][value='0']",body).attr("checked",true);
		                        }
		                        if(json.Url_Value=="2")
		                        {
		                            $("input[@name='Rad_Domain'][value='2']",body).attr("checked",true);
		                        }
                        		
		                        if(json.Url_DefaultPage.toLowerCase()==json.Url_Page.toLowerCase())
		                        {
                                     $(":checkbox",body).attr("checked",'true');
		                        }
		                        if(json.Url_DefaultPage.toLowerCase()!=json.Url_Page.toLowerCase())
		                        {
                                    $(":checkbox",body).attr("checked",'');
		                        }
		                        $("#action", body).val("edit");

								})});
                        }
                        else {
                            $("#action", body).val("insert");
                        }

                    },
                    data: "",
                    okEvent: function() {
                        var body = arguments[1].body;
                       
                        if ($.trim($('#Url_Domain',body).val())=="" || ($.trim($('#Url_Name',body).val())=="")) {
                            alert('请填写完整！');
                            $('#Url_Domain', body).focus();
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
	               url: "Url_Manage.aspx?action="+$("#action",body).val(),
	               data: getFormData(body),
	               beforeSend: function(XMLHttpRequest){
	               },
	               success: function(data,text){
			            if($.trim(data)=="1"){
			               top.location.href="../adminlogin.aspx";
			            }
			            if(data=="2")
			            {
			                alert("处理失败","该域名已配置过!");
			            }
	               },
	               complete: function(XMLHttpRequest, textStatus){
	               },
	               error: function(){
			            alert("处理失败,请检查是否有权处理!");
	               }
	             });
            }
            function getFormData(body){
 
	            var dataStr="Rad_Domain="+$("input[name='Rad_Domain']:checked",body).val()+"&Url_Domain="+$("#Url_Domain",body).val()+"&Url_Page="+decodeURI($('#Url_Page',body).val())+"&Url_Name="+$("#Url_Name",body).val()+"&Url_Default="+SetUrlDefault(body);

	            return dataStr;
            }
            function getDomainPage(){
	            $.get("Url_Manage.aspx?action=selectpage&time="+Math.random()+"", function(data){
	               //alert(data);
		            $("#Domain_Page").empty().html(data);
	            });
            }
			$("#flex1").flexigrid
			(
			{
			url: 'Url_Manage.aspx?action=select',
			dataType: 'json',
			colModel : [
				{display: '域名', name : 'domain', width : '300', sortable : false, align: 'center'},
				{display: '名称', name : 'name', width :  $("#contentBorder").width()-755, sortable : false, align: 'center'},
				{display: 'page', name : 'page', width : '200', sortable : false, align: 'center'},
				{display: 'defaultpage', name : 'defaultpage', width : '200', sortable : false, align: 'center'}
				],
			buttons : [
				{name: '新增域名', bclass: 'add', onpress : test},
				{name: '批量删除', bclass: 'delete', onpress : test},
				
				],
			searchitems : [
				{display: '域名名称', name : 'domain', isdefault: true}
				],
			sortname: "domain",
			sortorder: "desc",
			usepager: true,
			title: '系统url列表',
			useRp: true,
			rp: 10,
			procmsg:'正在请求数据，请稍候...',
			showTableToggleBtn: true,
			width: $("#contentBorder").width()-1,
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
				else if (com=='新增域名')
					{   
                         UpdateShow();
					}	
					
				
			}

		$('b.top').click
		(
			function ()
				{
					$(this).parent().toggleClass('fh');
				}
		);
		jQuery(function($){
	        getDomainPage();
	      
        });
        function SetUrlDefault(body)
        {
            if($(":checkbox",body).attr("checked")==true)
            {   
                return "1";
            }
            else
            {
                return "0";
            }
        }
</script>
<div id="DivDialog" style="display: none;width:600">

	<input type="hidden" id="action" value="insert" />
    
	<table width="100%" id="url_table" border="0" style="margin-bottom:5px;font-size:12px;font-weight:bold;" cellspacing="2" cellpadding="0">
                      <tr>
                        <td style="width:150px">域名选择：</td>
                        <td><input type="radio" name="Rad_Domain" value="0"   checked />一级域名&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" name="Rad_Domain" value="2"  />二级域名</td>
                      </tr>
					  <tr>
                        <td style="width:150px">域名：</td>
                        <td><input type="text" id="Url_Domain" name="Url_Domain" value="" /></td>
                      </tr>
					  <tr>
                        <td style="width:150px">域名转向：</td>
                        <td id="Domain_Page">
                      
                          
                        </td>
                      </tr>
					  <tr>
                        <td style="width:150px">版本名称</td>
                        <td><input type="text" id="Url_Name" name="Url_Name" /></td>
                      </tr>
                       <tr>
                        <td style="width:150px">默认版本</td>
                        <td><input type="checkbox" id="Url_Default" name="Url_Default" value="0" /></td>
                      </tr>
					  
    </table>
</div>
</div>
</body>
<script type="text/javascript">
//批量删除
function deleteCheck(IdStr){
	$.get("Url_Manage.aspx?action=delete&id="+IdStr, function(data){
	    if(data=="true"){
	    parent.dcmsDialog("删除成功","数据删除成功!");
	    $(".pReload").click();}});
}
</script>
</html>
