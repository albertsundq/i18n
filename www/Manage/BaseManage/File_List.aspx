<%@ Page Language="C#" AutoEventWireup="true" CodeFile="File_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_File_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>网站栏目管理</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<script type="text/javascript" src="../Green/Js/dcmsmain.js"></script>
<script type="text/javascript" src="../Green/Js/imgpreview.min.0.22.jquery.js"></script>
<!--调用表格样式开始-->
<script type="text/javascript" src="../Green/grid/flexigrid.js"></script>
<link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />
<!--调用表格样式结束-->
</head>
<body>
<div style="width:100%; margin-left:auto; margin-right:auto; clear:both;" id="contentBorder">
  <table width="100%" align="center" border="0" style="margin-bottom:5px;" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;</td>
      <td style="background:url(../Green/Images/content_title_bg02.gif) repeat-x;color:#437572;font-size:12px; font-weight:bold;">您现在的位置是：系统管理>文件管理</td>
      <td style="background:url(../Green/Images/content_title_bg01.gif) repeat-x;width:158px;color:#ff6633" align="right">
	  <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;</td>
    </tr>
  </table>
  <table width="100%" height="350" border="0" cellpadding="0" cellspacing="0" style="margin-bottom:5px;">
    <tr>
      <td style="height:25px;"><div class="contentitle_left">文件管理</div><div class="contentitle_right"></div></td>
    </tr>
    <tr>
      <td style="border:1px solid #cccccc;padding:10px;" valign="top"><table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="173" width="300" valign="top"><table width="280" border="0" style="border:1px solid #b4dedc;" align="right" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="25" class="left_cate"><div class="cate_title">文件管理</div><div class="root_cate"></div></td>
                </tr>
                <tr>
                  <td style="padding:10px 10px 15px 20px;" id="LeftCate">
				  
				  </td>
                </tr>
              </table></td>
            <td valign="top" style="padding-left:20px;"><table width="100%" border="0" style="border:1px solid #b4dedc;" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="26" class="tdtitle"><div class="titleactive" id="tab_1"><div class="linesplit"></div><div class="tabtitle" style="font-size:12px" onclick="javascript:changetab(1);">增加目录</div><div class="linesplit"></div></div><div id="tab_2"><div class="linesplit"></div><div style="font-size:12px" class="tabtitle" onclick="javascript:changetab(2);">上传文件</div><div class="linesplit"></div></div><%--<div id="tab_3"><div class="linesplit"></div><div style="font-size:12px" class="tabtitle" onclick="javascript:changetab(3);">文件同步</div><div class="linesplit"></div></div>--%><div id="tab_4"><div class="linesplit"></div><div style="font-size:12px" class="tabtitle" onclick="javascript:changetab(4);">文件列表</div><div class="linesplit"></div></div></td>
                </tr>
                <tr>
                  <td style="padding:10px 10px 15px 20px;">
                  <input type="hidden" id="File_UploadPath" value="" />
				  	<input type="hidden" id="Upload_Id" value="48" />
					<input type="hidden" id="Upload_ParentId" value="0" />
                    <input type="hidden" id="action" value="insertPath" />
                  
					<table width="100%" id="tabcontent_1" border="0" style="margin-bottom:5px;font-size:12px;font-weight:bold;" cellspacing="0" cellpadding="0">
					  <tr>
                        <td width="120" height="30" align="center">当前目录：</td>
                        <td id="cur_path">根目录</td>
                      </tr>
                      <tr>
                        <td width="120" height="30" align="center">目录名称：</td>
                        <td><input type="text" size="20" style="width:200px" id="Upload_PathName" /></td>
                      </tr>
					  
                    </table>
					
					<table width="100%" id="tabcontent_2" border="0" style="margin-bottom:5px;font-size:12px;display:none;font-weight:bold;" cellspacing="10" cellpadding="10">
                     <tr>
                        <td>当前目录：<span id="upload_curPath">根目录</span></td>
                        
                      </tr>
					  
					  <tr>
                        <%--<td colspan=2>文件：<input type="file" size="20" style="width:200px" id="file1" /></td>--%>
                            <td  width="500" height="500"><iframe id="ifrm_upload" src="../../dceditor/JqueryUpload/Default.aspx" width="100%" height="500" frameborder=0 scrolling=auto ></iframe></td>
                      </tr>
					  
                      
                    </table>
					
					<table width="100%" id="tabcontent_3" border="0" style="margin-bottom:5px;font-size:12px;display:none;font-weight:bold;" cellspacing="0" cellpadding="0">
                     <%-- <tr>
                        <td width="120" height="30" align="center">扩展信息1：</td>
                        <td><input type="text" size="20" style="width:200px" id="Cate_ExField1" /></td>
                      </tr>--%>
					  
					  
                    </table>
                    <div id="filelist">
                        <table width="100%" id="Table1" border="0" style="margin-bottom:5px;font-size:12px;font-weight:bold;" cellspacing="10" cellpadding="10">
                     <tr>
                        <td>当前目录：<span id="fileList_curPath">根目录</span></td>
                        
                      </tr>
                      </table>
                        <table id="flex1" style="display:none;"></table>
                    </div>
                    
                    <table id="tableSubmit" width="100%" height="50" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="padding-left:50px;"><input type="submit" class="button" onclick="javascript:ajaxSubmi();" value="确认提交" />
                          &nbsp;
                          <input type="reset" onclick="javascript:clearInputData();" class="button" value="清空重写" /></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table width="100%" style="margin-top:5px;margin-bottom:10px;" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td style="background:url(../Green/Images/bg_help03.gif) no-repeat" width="41" height="34">&nbsp;</td>
      <td style="background:url(../Green/Images/bg_help01.gif) repeat-x;color:#b4773e;font-size:14px; font-weight:bold;" id="adminTitle">帮助说明和其它</td>
      <td style="background:url(../Green/Images/bg_help02.gif) no-repeat" width="10" height="34">&nbsp;</td>
    </tr>
  </table>
</div>
</body>

<script type="text/javascript">
var contentW=$("#contentBorder").width();
$("#contentBorder").width(contentW-20);
//创建主目录
$(".root_cate").click(function(){
	$(":text").val("");
	$("textarea").val("");
	$("#Upload_Id").val("0");
	$("#Upload_ParentId").val("0");
	$("#cur_path").html("根目录");
	$("#upload_curPath").html("根目录");
	$("#fileList_curPath").html("根目录");
	$("#flex1").flexOptions({url: 'File_Manage.aspx?action=select&id='+$("#Upload_Id").val()});
	$("#flex1").flexReload({});
	var flex_a=$("#flex1 a");
	        //alert(flex_a.length);
    if(flex_a.length>0)
    {
          //alert(flex_a.length);
         $("table#flex1 a").imgPreview();
    }
     else{
    // alert(flex_a);
     }
	$("#action").val("insertPath");
})

//定义Tab切换
function changetab(tabid){
    if(tabid==2)
	{
	   if($("#upload_curPath").text()=="根目录")
       {
            alert("当前目录是根目录，不能上传到根目录，请在右边选择一个目录后再上传！");
            return;
       }
	    $("#tableSubmit").css("display","none");
	}
	for(var i=1;i<=4;i++)
	{
		$("#tab_"+i).removeClass("titleactive");
		$("#tabcontent_"+i).css("display","none");
		$("#tab_FileName").hide();
	}
	$("#tableSubmit").css("display","block");
	$("#tab_"+tabid).addClass("titleactive");
	$("#tabcontent_"+tabid).css("display","block");
	$("#filelist").hide();
	if(tabid==4)
	{
//	    showGrid($("#Upload_Id").val());
        $("#flex1").flexReload({});
	    $("#filelist").show();
	   
	    $("#tableSubmit").css("display","none");
	}
	
//	if(tabid==3)
//	{
//	    $("#action").val("fileSyn");//同步文件
//	}
}
//简单的树形菜单
function buildTree() {
	$('.functree li').each(function() {
		var uploadid=$(this).children('span').attr('thisid');
		$(this).children('span').after("&nbsp;<a onclick='delPath("+uploadid+")' class='catedel'>&nbsp; &nbsp;</a>");
		if ($(this).is(':has(ul)'))
			$(this).addClass('collapse');
		if ($(this).next().is('li') || $(this).next().is('ul'))
			$(this).css({ borderLeft: 'dashed 1px #dedede' });
	})
	$('li.collapse>span').click(function() {
	   $("#Upload_Id").val($(this).attr('thisid'));
	  addPath($(this).attr('thisid'));
	  $("#cur_path").html($(this).text());
	  $("#upload_curPath").html($(this).text());
	  $("#fileList_curPath").html($(this).text());
	   updateFlex();

		$(this).parent().children('ul').slideToggle('fast', function() {
			if ($(this).parent().hasClass('collapse'))
			{
			   
				$(this).parent().removeClass('collapse').addClass('expand');
			}
			else
			{
			    
				$(this).parent().removeClass('expand').addClass('collapse');
			}
		})
	})
   
	$('span.func').css({ 'cursor': 'pointer' }).hover(function() {
		$(this).css({ 'color': '#3de', 'text-decoration': 'underline' });
	}, function() {
		$(this).css({ 'color': '#000', 'text-decoration': 'none' });
	}).bind("click",function(event) {
		$("#Upload_Id").val($(this).attr('thisid'));
		  addPath($(this).attr('thisid'));
		  $("#cur_path").html($(this).text());
		  $("#upload_curPath").html($(this).text());
		  $("#fileList_curPath").html($(this).text());
		   updateFlex();
          
	});
};
function killErrors() {
    return true;
}
window.onerror = killErrors;
//取左边类别树
function getUploadRefresh(){
	$.get("File_Manage.aspx?action=selectpath&time="+Math.random()+"", function(data){
	    //alert(data);
  		$("#LeftCate").html(data);
		buildTree();
	});
}
$().ready(function() {
	getUploadRefresh();
	
	 
//	$('#flex1 a').imgPreview();
});

//添加栏目
function addPath(uploadid){
	clearInputData();
	$("#Upload_ParentId").val(uploadid);
	//alert($('#Upload_ParentId').val());
	$("#action").val("insertPath");
}
//栏目编辑
function editPath(uploadid){
	//getOneRecord(cateid);
}
//删除栏目
function delPath(uploadid){
	parent.dcmsDialog("确认删除该目录","你确定要删除该目录及该目录下的所有文件吗?",function(){
	    $.get("File_Manage.aspx?action=deletePath&id="+uploadid, function(data){
	    //alert(data);
	    if(data=="subpathexist")
	    {
	        alert("当前目录还存在子目录，无法删除！");
	        return;
	    }
	    if(data=="true")
	    {
	        parent.dcmsDialog("提示","删除成功！");
	        getUploadRefresh();
	        return;
	    }
	    parent.dcmsDialog("提示","删除失败！");
	        });
	    });
}
//ajax请求单条数据修改
function getOneRecord(id){
	 $.getJSON("File_Manage.aspx?action=getone&time="+Math.random()+"&id="+id,function(json){
		$.each(json,function(i){
		$(":input[id]").each(function (index, domEle) {
		var idname=$(domEle).attr("id");
		if(idname.indexOf("_")!=-1)
		{
			$(domEle).val(json[i][idname]);
			
		}
 		});
		$("#action").val("update");
		})});
}
//ajax数据提交
function ajaxSubmi(){

	 $.ajax({
	   type: "Post",
	   url: "File_Manage.aspx?action="+$("#action").val(),
	   data: "Upload_PathName="+$("#Upload_PathName").val()+"&Upload_ParentId="+$("#Upload_ParentId").val(),
	   dataType:"html",
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
	   },
	   success: function(data, textStatus){
	  
	        // alert(data);  
			//请求出错处理;
			if(data=="true"){
			
			parent.dcmsDialog("处理成功","栏目处理成功!");
			getUploadRefresh();
			if($(".flexigrid").hasClass("hideBody"))
			{
				$(".flexigrid").toggleClass('hideBody');
			}
			$(".pReload pButton").children('span').click();
			clearInputData();}
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
	   },
	   error: function(){
			//请求出错处理
			parent.dcmsDialog("处理失败","栏目处理失败!");
	   }
	 });
 };

//清空表单数据
function clearInputData(){
	$(":text").val("");
	$("textarea").val("");
}
</script>
<script type="text/javascript">
    
    var contentW=$("#contentBorder").width();
	$("#contentBorder").width(contentW-20);
	//批量删除
function deleteCheck(IdStr){
	$.get("File_Manage.aspx?action=delete&id="+IdStr, function(data){
	    //alert(data);
	    if(data=="true"){
	    parent.dcmsDialog("删除成功","数据删除成功!");
	    $(".pReload").click();}});
}
</script>

<script type="text/javascript">

     $("#flex1").flexigrid
			(
			{
			url: 'File_Manage.aspx?action=select&id='+$("#Upload_Id").val(),
			dataType: 'json',
			colModel : [
				{display: 'ID编号', name : 'File_Id', width :100, sortable : false, align: 'center'},
				{display: '文件名称', name : 'File_OlderFileName', width : 120, sortable : false, align: 'center'},
				{display: '大小', name : 'File_FileSize', width : 120, sortable : false, align: 'center'},
				{display: '时间', name : 'File_AddDateTime', width : 120, sortable : false, align: 'center'}
				],
			buttons : [
				{name: '重命名', bclass: 'add', onpress : test},
				{name: '删除', bclass: 'delete', onpress : test},
//				{name: '选择', bclass: 'add', onpress : test},
				{name: '缩略图', bclass: 'add', onpress : test}
				],
			searchitems : [
				{display: '文件名称', name : 'File_OlderFileName', isdefault: true}
				],
			sortname: "File_Id",
			sortorder: "desc",
			usepager: true,
			title: '系统文件列表',
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
				if (com=='删除')
					{
						parent.dcmsDialog("确认删除","确认删除选中的数据?一旦删除将无法恢复!",function(){
						    var IdStr="";
						    $('.trSelected',grid).each(function (index, domEle){IdStr=IdStr+","+$(domEle).children().eq(0).text();});
						   // alert(IdStr);
						    deleteCheck(IdStr);
						});
					}
				else if (com=='重命名')
					{

                        parent.dcmsDialog("文件重命名","<table width='100%' id='tab_FileName' border='0' style='margin-bottom:5px;font-size:12px; font-weight:bold;' height='25' cellspacing='0' cellpadding='0'><tr><td width='100'>文件名称：</td><td><input type='text' size='20' style='width:200px' id='ipt_OlderFileName' value='"+$('.trSelected td:eq(1)',grid).text()+"' /></td></tr></table>",function(){                       
                            renewFileName($('.trSelected td:eq(0)',grid).text(),$('#ipt_OlderFileName', window.parent.document).val());
						    
						});
					}	
//				else if (com=='选择')
//					{
//					    $("#File_UploadPath").val($('.trSelected td:eq(1) a',grid).attr('href').substring(16));
//					}		
				else if (com=='缩略图')
					{
					    
					    var flex_a=$("#flex1 a");
	                 
                        if(flex_a.length>0)
                        {
                              //alert(flex_a.length);
                             $("table#flex1 a").imgPreview();
                        }
                         else{
                       
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
//}
		$("#filelist").hide();
 function renewFileName(id,newfilename)//文件重命名
 {
     $.ajax({
	   type: "Post",
	   url: "File_Manage.aspx?action=renew",
	   data: "fileId="+id+"&newFileName="+newfilename,
	   dataType:"html",
	   beforeSend: function(XMLHttpRequest){
			//ShowLoading();
	   },
	   success: function(data, textStatus){
	  
	         //alert(data);  
			//请求出错处理;
			if(data=="true"){
			
			parent.dcmsDialog("处理成功","栏目处理成功!");
			getUploadRefresh();
			if($(".flexigrid").hasClass("hideBody"))
			{
				$(".flexigrid").toggleClass('hideBody');
			}
//			$(".pReload pButton").children('span').click();
            $("#flex1").flexOptions({url: 'File_Manage.aspx?action=select&id='+$("#Upload_Id").val()});
	        $("#flex1").flexReload({});
			clearInputData();}
	   },
	   complete: function(XMLHttpRequest, textStatus){
			//HideLoading();
	   },
	   error: function(){
			//请求出错处理
			parent.dcmsDialog("处理失败","栏目处理失败!");
	   }
	 });
 }			
	function updateFlex()
	{
	     
		  $("#flex1").flexOptions({url: 'File_Manage.aspx?action=select&id='+$("#Upload_Id").val()});
		  $("#flex1").flexReload({});
		  
	}
</script>

</html>
