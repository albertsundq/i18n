<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ezine_list.aspx.cs" Inherits="Manage.ezine.Manage_ezine_ezine_list" %>
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
                $("#setUrl").html("<span id='baseinfourl"+colId+"' dataType='iframe' dataLink='../ezine/{1}ezine_update.aspx?iframeid="+iframeid+"&action=update&catename="+cateName+"&permcateid="+cateId+"&cateid="+cateId+"&id="+colId+"'>编辑"+cateName+"</span>");
				parent.dcmstab.buildChildTab(document.getElementById("baseinfourl"+colId));
				$("#setUrl").html("");
            }
			function ShiftShow(idstr) {
                var langflag="<%=Dcms.Utility.SessionHelper.Get("langflag").ToString()%>";
                var oDialog = parent.dcmsDialogJson({
                    title: '类别多条数据转移',
                    content: function(body) {
                        body.html($("#DivDialog").html());

                     $.get("../basemanage/Data_Manage.aspx?action=getSomeShiftCateTo&moduleflag=ezine&catelang="+langflag+"&time="+Math.random()+"", function(data){

		                    $("#cate_to",body).empty().html(data);
		                     $("#action", body).val("SomeShift");
	                    });
                       
                    },
                    data: "",
                    okEvent: function() {
                        var body = arguments[1].body;
                      if($('#cate_to',body).find('select:eq(0)').val()=="0")
                        {
                            alert("请选择要转入的类别！");
                            return false;
                        }
                        return ShiftSubmit(body,idstr);
                    }
                });
            }
             //ajax数据提交
            function ShiftSubmit(body,idstr) {
            
                if(confirm("确定要转移吗？"))
                {
                    $.ajax({
                        type: "post",
                        url: "../basemanage/Data_Manage.aspx?action=" + $("#action", body).val(),
                        data:getFormData(body,idstr),
                        beforeSend: function(XMLHttpRequest) {
                            //ShowLoading();
                        },
                        success: function(data, textStatus) {
                            alert(data);
                           
                                $(".pReload").click();
                                parent.$.fn.hideJmodal();
                            
                        },
                        complete: function(XMLHttpRequest, textStatus) {
                            //HideLoading();
                        },
                        error: function() {
                            parent.dcmsDialog("处理失败", "你提交的数据处理失败，请检查数据是否合法！");
                        }
                    });
                }
            }
            function getFormData(body,idstr){
                var dataStr="";
                 dataStr='id='+idstr+'&cateto='+$('#cate_to',body).find('select:eq(0)').val()+"&CateToName="+$("#cate_to",body).find("select:eq(0)").find("option:selected").text().substring($('#cate_to',body).find('select:eq(0)').find("option:selected").text().lastIndexOf('┠')+1)+"&IsDelete="+$(":radio[name='is_delete'][checked]",body).val()+"&moduleflag=ezine";
                return dataStr;	
            }
			$("#flex1").flexigrid
			(
			{
			url: 'ezine_manage.aspx?action=select&cateid='+$("#Cate_Id").val(),
			dataType: 'json',
			colModel : [
				{display: 'ID编号', name : 'Ezine_ID', width : 80, sortable : false, align: 'center'},
				{display: '电子杂志名称', name : 'Ezine_Title', width : $("#contentBorder").width()-360, sortable : false, align: 'center'},
				{display: '显示状态', name : 'Ezine_State', width : 100, sortable : false, align: 'center'},
				{display: '创建时间', name : 'Ezine_AddTime', width : 120, sortable : false, align: 'center'}
				],
			buttons : [
				{name: '新建电子杂志', bclass: 'add', onpress : test},
				{name: '批量删除', bclass: 'delete', onpress : test},
				{name: '批量转移', bclass: 'add', onpress : test}
				],
			searchitems : [
				{display: '电子杂志名称', name : 'Ezine_Title', isdefault: true}
				],
			sortname: "Ezine_ID",
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
				else if (com=='新建电子杂志')
					{
					    var cateId=$("#Cate_Id").val();
                        var cateName=$("#Cate_Name").val();
                        var iframeid=$(".curholder",window.parent.document).find("iframe[name^='jerichotabiframe']").attr("id");
                        $("#setUrl").html("<span id='url0' dataType='iframe' dataLink='../ezine/{1}ezine_update.aspx?iframeid="+iframeid+"&action=insert&catename="+cateName+"&permcateid="+cateId+"&cateid="+cateId+"&id=0'>新建"+cateName+"</span>");
		                parent.dcmstab.buildChildTab(document.getElementById("url0"));
			            $("#setUrl").html("");
					}
				else if(com=='批量转移')
			    {
				    var IdStr="";
				    $('.trSelected',grid).each(function (index, domEle){IdStr=IdStr+","+$(domEle).children().eq(0).text();});
				    ShiftShow(IdStr);
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
            
            <input type="hidden" id="action" value="insert" />
            <table width="100%" border="0" style="margin-bottom: 5px; font-size: 12px; font-weight: bold;"
                height="80" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height:25px;" width="120" align="center">
                        转移到类别：
                    </td>
                    <td width="220">
                       <div id="cate_to" style="display:block">
                      
                    </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:25px;" width="120" align="center">
                        转移后删除：
                    </td>
                    <td width="220">
                       <input type="radio" name="is_delete" value="0"  checked  />否&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" name="is_delete" value="1"   />是
                    </td>
                </tr>
                </table>
            
  </div>
</div>
</body>
<script type="text/javascript">
//批量删除
function deleteCheck(IdStr){
	$.get("ezine_manage.aspx?permcateid="+$("#Cate_Id").val()+"&action=delete&id="+IdStr, function(data){
	    if(data=="true"){
	    parent.dcmsDialog("删除成功","数据删除成功!");
	    $(".pReload").click();}
           else
	   {
	      alert("你没有进行此操作的权限，请联系管理员申请相关权限再进行操作！");
	   }
	});
}
</script>
</html>
