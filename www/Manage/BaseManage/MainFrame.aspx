<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainFrame.aspx.cs" Inherits="Manage.BaseManage.Manage_MainFrame" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>企业网站内容管理系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript" src="../Green/Js/jquery.js"></script>
<script type="text/javascript" src="../Green/Js/dcmsmain.js"></script>
<link rel="Stylesheet" href="../Green/Css/common.css" />
<link rel="Stylesheet" href="../Green/Css/dcmsjs.css" />
<link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />
<!--调用对话框样式开始-->
<script type="text/javascript" src="../Green/jmodal/jmodal.js"></script>
<script type="text/javascript" src="../Green/Js/dtree.js"></script>
<link rel="stylesheet" href="../Green/jmodal/jmodal.css" type="text/css" media="all" />
<!--调用对话框样式结束-->
<!--调用新的上传组件-->
<script type="text/javascript" src="../../dceditor/FlashTool/js/jquery.bgiframe.js"></script>
<script type="text/javascript" src="../../dceditor/FlashTool/js/jquery.weebox.js"></script>
<link rel="Stylesheet" href="../../dceditor/FlashTool/css/weebox.css" />
<script type="text/javascript">  
jQuery.DcTool = {     
         
	show:function(inputName,width,height) {           
				$.weeboxs.open('../../dceditor/FlashTool/ToolMain.html?inputName='+inputName, {
					 title:'DCTool v3.0 文件管理器',
					 contentType:'iframe',
					 width:width,
					 height:height,
					 showButton:false,
					 showOk:false,
					 showCancel:false
				 });
	},           
	close:function(inputName,value){
					//$("#"+inputName).val(value);
					$(".curholder").find("iframe[name^='jerichotabiframe']").contents().find('#'+inputName).val(value);
					$.weeboxs.close();
	}     
}; 
var dcmstab = {
	showLoader: function() {
		$('#divMainLoader').css('display', 'block');
	},
	removeLoader: function() {
		$('#divMainLoader').css('display', 'none');
	},
	initLeftMenu: function() {
	 	var pNodeId=0;
		var nodeId=0;
		var subStr="";
		$("ul#Node"+nodeId).clone().appendTo($("#nowstr"));
		$("div#nowstr>ul#Node"+nodeId+">li").each(function (index, domEle) { 
			if($(domEle).children().is("ul"))
			{
				$(domEle).children("ul").remove();
				subStr=subStr+"<li>"+$(domEle).html()+"</li>";
			}
			else
			{
				subStr=subStr+"<li>"+$(domEle).html()+"</li>";
			}
		});
		subStr="<ul class='LC LC1' style='position:absolute;left:0px;width:179px;'>"+subStr+"</ul>";
		$(subStr).appendTo($(".LMcontentDT"));
		$("#getParent").attr("pNodeId", pNodeId);
		$("#getParent").attr("nodeId", nodeId);
		setTimeout("initData()",500);  
	},
	getSub: function(obj) {
	 	var pNodeId=$(obj).attr("pNodeId");
		var nodeId=$(obj).attr("nodeId");
		var subStr="";
		$("ul#Node"+nodeId).clone().appendTo($("#nowstr"));
		$("div#nowstr>ul#Node"+nodeId+">li").each(function (index, domEle) { 
			if($(domEle).children().is("ul"))
			{
				$(domEle).children("ul").remove();
				subStr=subStr+"<li>"+$(domEle).html()+"</li>";
			}
			else
			{
				subStr=subStr+"<li>"+$(domEle).html()+"</li>";
			}
		});
		subStr="<ul class='LC'>"+subStr+"</ul>";
		$("#nowstr").children().remove();
		$(subStr).css({"position":"absolute","left":"179px","width":"179px"}).appendTo($(".LMcontentDT"));
		$(".LC1").animate({left:"-178px"});	
		$(".LC1").addClass("removeNode");
		$(".LC1").removeClass("LC");
		$(".LC").addClass("LC2");		
		$(".LC2").animate({left:"1px"});
		$(".LC").removeClass("LC2");
		$(".LC").addClass("LC1");
		//赋新值
		$("#getParent").attr("pNodeId", pNodeId);
		$("#getParent").attr("nodeId", nodeId);
		setTimeout("initData()",500);  
	},
	getParent: function(obj) {
	 	var pNodeId=$(obj).attr("pNodeId");
		var nodeId=$(obj).attr("nodeId");
		
		var str="";
		if(pNodeId>=0&&nodeId!=0){
			$("ul#Node"+pNodeId).clone().appendTo($("#nowstr"));
			$("div#nowstr>ul#Node"+pNodeId+">li").each(function (index, domEle) { 
				if($(domEle).children().is("ul"))
				{
					$(domEle).children("ul").remove();
					str=str+"<li>"+$(domEle).html()+"</li>";
				}
				else
				{
					str=str+"<li>"+$(domEle).html()+"</li>";
				}
			});
			str="<ul class='LC'>"+str+"</ul>";
			$("#nowstr").children().remove();
			$(str).css({"position":"absolute","left":"-179px","width":"179px"}).appendTo($(".LMcontentDT"));
			$(".LC1").animate({left:"179px"});	
			$(".LC1").removeClass("LC");
			$(".LC1").addClass("removeNode");
			$(".LC1").removeClass("LC1");
			$(".LC").addClass("LC2");		
			$(".LC2").animate({left:"1px"});
			$(".LC").removeClass("LC2");
			$(".LC").addClass("LC1");
			//赋新值
			var vpNodeId=$("#Node"+pNodeId).attr("pNodeId");
			var vnodeId=$("#Node"+pNodeId).attr("nodeId");
			
			$("#getParent").attr("pNodeId", vpNodeId);
			$("#getParent").attr("nodeId", vnodeId);
			setTimeout("initData()",500); 
		}
	},
	buildChildTab: function(obj) {
		$.fn.jerichoTab.addTab({
				tabFirer: $(obj),
				title: $(obj).text(),
				closeable: true,
				data: {
					dataType: $(obj).attr('dataType'),
					dataLink: $(obj).attr('dataLink')
				}
			}).showLoader().loadData();
	},
	closeTab:function(curTab){//关闭tab扩展
	    $.fn.jerichoTab.closeTab(curTab);
	},
	buildTabpanel: function() {
		$.fn.initJerichoTab({
			renderTo: '.divRight',
			uniqueId: 'myJerichoTab',
			contentCss: { 'height': $('.divRight').height() - 50 },
			tabs: [{
					title: '默认主页',
					closeable: false,
					iconImg: '../Green/Images/home.gif',
					data: { dataType: 'formtag', dataLink: '#tbNews' }
				}],
				activeTabIndex: 0,
				loadOnce: true
			});
		}
	}
$().ready(function() {
	$("#LMcontentDT").Scroll({line:2,speed:500,timer:1000,up:"getNext",down:"getPrev"});
	d1 = new Date().getTime();
	dcmstab.showLoader();
	var w = $(document).width();
	var h = $(document).height();
	$('.allcontent').css({ width: w - 3, 'display': 'block' });
	$('.divLeft').css({ width: 190, height: h - 145, 'display': 'block' });
	$('.divRight').css({ width: w - 208, height: h - 145, 'display': 'block', 'margin-left': 7 });
	$(".LMcontentDT li").mouseover( function () {$(this).css("background","url(../Green/Images/LMline.gif) 0px -25px no-repeat"); });
	$(".LMcontentDT li").mouseout( function () {$(this).css("background","url(../Green/Images/LMline.gif) no-repeat"); });
	$("span").click( function () {
	    var dtype=String($(this).attr('dataType'));
	    var dlink=String($(this).attr('dataLink'));
		if((dtype!="undefined")&&(dlink!="undefined"))
		{
			$.fn.jerichoTab.addTab({
						tabFirer: $(this),
						title: $(this).text(),
						closeable: true,
						data: {
							dataType: $(this).attr('dataType'),
							dataLink: $(this).attr('dataLink')
						}
					}).showLoader().loadData();
		  }
	 });
	dcmstab.buildTabpanel();
	dcmstab.removeLoader();
	changeViewClass();
	if(($("#span_testdata").html()=="生成测试数据"))
	{
	    $("#span_testdata").bind("click",function(event)
	    {
	        TestData();
    	
        });
	}
	if(($("#span_testdata").html()=="清空测试数据"))
	{
	    $("#span_testdata").bind("click",function(event)
	    {
	        ClearTestData();
    	
        });
	}
	
})
$(window).resize(function() {
           //top.location.href="mainframe.aspx";
})
</script>
<script type="text/javascript">
function initData(){
	$(".LMcontentDT li").mouseover( function () {$(this).css("background","url(../Green/Images/LMline.gif) 0px -25px no-repeat"); });
	$(".LMcontentDT li").mouseout( function () {$(this).css("background","url(../Green/Images/LMline.gif) no-repeat"); });
	$("span").click( function () {
	    var dtype=String($(this).attr('dataType'));
	    var dlink=String($(this).attr('dataLink'));
		if((dtype!="undefined")&&(dlink!="undefined"))
		{
			$.fn.jerichoTab.addTab({
						tabFirer: $(this),
						title: $(this).text(),
						closeable: true,
						data: {
							dataType: $(this).attr('dataType'),
							dataLink: $(this).attr('dataLink')
						}
					}).showLoader().loadData();
		  }
	 });
	$(".removeNode").remove();
	$("#LMcontentDT").Scroll({line:2,speed:500,timer:1000,up:"getNext",down:"getPrev"});
}
//调用左边树状菜单栏目
function getLeftTreeCate(linkUrl,cateid,cateName)
{
    $.fn.jerichoTab.addTab({
				tabFirer: $("cateurl"+cateid),
				title:cateName,
				closeable: true,
				data: {
					dataType:"iframe",
					dataLink: linkUrl
				}
	}).showLoader().loadData();
}
//调用左边滚动菜单
function getNewScroll()
{
    
    $.ajax({
	   type: "post",
	   url: "MainFrame.aspx?action=getscrolltree",
	   success: function(data, textStatus){
	        $("#scroll_LeftTree").html("");
			$("#scroll_LeftTree").html(data);
			$("#nowstr").html("");
			$("#LMcontentDT").html("");
			dcmstab.initLeftMenu();
	   }
	 });
}
//调用顶部快捷菜单
function getTopQMenu()
{
    $.ajax({
	   type: "post",
	   url: "MainFrame.aspx?action=getqmenu",
	   success: function(data, textStatus){
	        $("#topM2_1").html("");
			$("#topM2_1").html("<ul>"+data+"</ul>");
			$("span").click( function () {$.fn.jerichoTab.addTab({
				tabFirer: $(this),
				title: $(this).text(),
				closeable: true,
				iconImg: '../Green/images/folder.gif',
				data: {
					dataType: $(this).attr('dataType'),
					dataLink: $(this).attr('dataLink')
				}
			    }).showLoader().loadData();
	        });
	   }
	 });
}
//调用对话框
function dcmsDialog(title,content,fun)
{
	$.fn.jmodal({
		title: title,
		content: content,
		buttonText: { ok: '确定', cancel: '取消' },
		okEvent: fun
	});
}


//调用对话框未定参数
function dcmsDialogJson(argeJson) {
    var rv2 = $.fn.jmodal({
        title: argeJson.title,
        content: argeJson.content,
		initWidth:argeJson.initWidth,
        data: argeJson.data,
        buttonText: { ok: '确定', cancel: '取消' },
        okEvent: argeJson.okEvent
    });
}
//定义头部栏目切换
function chageTopMenu(tabid){
	for(var i=1;i<5;i++)
	{
		$("#topM1_"+i).removeClass("TopM1active");
		$("#topM2_"+i).css("display","none");
	}
	$("#topM1_"+tabid).addClass("TopM1active");
	$("#topM2_"+tabid).css("display","block");
}
//二级栏目选中状态
function checkState(obj){
	$(obj).siblings().removeClass("TopM2active");
	$(obj).addClass("TopM2active");
}

//调用产品选择对话框
function ShowImageDialog(id)
{
     if(screen.width>1024)
     {
       $.DcTool.show(id,750,450);
     }
     else
     {
        $.DcTool.show(id,650,350);
     }
}
//调用iframe刷新
function refleshIframe(id)
{   
    var  ie=navigator.appName=="Microsoft Internet Explorer"? true  :  false;
    if(ie)
    {
        $("#"+id).contents().find(".pDiv").find(".pReload").click();
    }
    else
    {
        var  jpReload=document.createEvent("MouseEvents");
        jpReload.initEvent("click",  true,  true);
        var dpReload=$("#"+id).contents().find(".pDiv").find(".pReload")[0];
        dpReload.dispatchEvent(jpReload);
    }
  
    //window.frames["jerichotabiframe_"+id].reloadGrid();$("#jerichotabholder_"+id).find("#jerichotabiframe_"+id)
}
</script>
</head>
<body>
<div id="cateUrl" style="display:none"></div>
<div class="allcontent">
  <div class="divTop">
    <div class="baseTop">
      <div class="logo"></div>
      <div class="topInfo">
        
        <div class="loginInfo"><asp:Literal ID="lit_adminName" runat="server"></asp:Literal>，欢迎您！[当前正在管理 “<font color="#FF0000"><asp:Literal ID="lit_webSiteId" runat="server"></asp:Literal></font>” 站点内容]&nbsp;&nbsp;[<asp:Literal ID="lit_index" runat="server"></asp:Literal>]&nbsp;&nbsp;</div>
        
        <div id="logout" onclick="top.location.href='../adminlogin.aspx'">&nbsp;&nbsp;&nbsp;退&nbsp;&nbsp;出</div>
      </div>
    </div>
    <div class="topM1">
      <ul>
        <li id="topM1_1" class="TopM1active">
          <div class="TopM1l"> </div>
          <div class="TopM1text" onclick="javascript:chageTopMenu(1);"> &nbsp; &nbsp; 快捷菜单 &nbsp; &nbsp; </div>
          <div class="TopM1r"> </div>
        </li>

        <li id="topM1_2">
          <div class="TopM1l"> </div>
          <div class="TopM1text" onclick="javascript:chageTopMenu(2);"> &nbsp; &nbsp; 系统管理 &nbsp; &nbsp; </div>
          <div class="TopM1r"> </div>
        </li>
        <li id="topM1_3">
          <div class="TopM1l"> </div>
          <div class="TopM1text" onclick="javascript:chageTopMenu(3);"> &nbsp; &nbsp; 扩展模块 &nbsp; &nbsp; </div>
          <div class="TopM1r"> </div>
        </li>
		<li id="topM1_4">
          <div class="TopM1l"> </div>
          <div class="TopM1text" onclick="javascript:chageTopMenu(4);"> &nbsp; &nbsp; 版本切换 &nbsp; &nbsp; </div>
          <div class="TopM1r"> </div>
        </li>
      </ul>
    </div>
    <div class="topM2" id="topM2_1">
      <ul>
        <asp:Literal ID="lit_QMenu" runat="server"></asp:Literal>
      </ul>
    </div>
	<div class="topM2" id="topM2_2" style="display:none;">
      <ul>
        <asp:Literal ID="lit_SysCate_1" runat="server"></asp:Literal>
      </ul>
    </div>
	<div class="topM2" id="topM2_3" style="display:none;">
      <ul>
        <asp:Literal ID="lit_SysCate_2" runat="server"></asp:Literal>
       <asp:Literal ID="lit_testdata" runat="server"></asp:Literal>
      </ul>
    </div>
	<div class="topM2" id="topM2_4" style="display:none;">
      <ul>
        <asp:Literal ID="lit_SysCate_3" runat="server"></asp:Literal>
      </ul>
    </div>
  </div>
   <!--树形类别菜单开始-->
    <div id="treeLeft" style="display:none;top:110px;width:190px;height:100%;background-color:#edfaed;z-index:100;position:absolute;overflow-x:hidden;overflow-y:auto;scrollbar-face-color: #EDFAED; scrollbar-shadow-color: #EDFAED; scrollbar-highlight-color:#EDFAED; scrollbar-3dlight-color: #DBEBFE; scrollbar-darkshadow-color:#458CE4; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #458CE4">
        <%--<div id="LMtop" style="background:url('../Green/Images/LM.gif') repeat-x;width:
        81px;height:30px;position:absolute;left:10px"><div id="LMtitle" style="font-size:14px;top:8px;position:absolute;left:60px;z-index:1;font-weight:bold">网站栏目</div></div>--%>
        <div id="treeLeftContent" style="position:absolute;top:10px;left:5px;height:100%;width:100%"><%--<asp:Literal ID="litMenu" runat="server" />--%></div>
    </div><!--树形菜单类别结束-->
  <div class="divMain">
    <div class="divLeft">
      <div class="LeftMenu">
        <div class="LMtop"><div class="LMtitle" id="secondMenuTitle">网站栏目</div><div class="getPrev" id="getPrev"></div></div>
        <div class="LMcontent">
			<div class="LMcontentDT" id="LMcontentDT">
			</div>
			<div class="LMback"><div id="getParent" nodeId="0" pNodeId="0" class="getParent" onclick="javascript:dcmstab.getParent(this);">返回上一级</div><div class="getNext" id="getNext"></div></div>
        </div>
        <div class="LMbottom"></div>
      </div>
      <br />
      <div class="serviceol" onclick="location.href='mailto:webdesign@35.cn'"></div>
    </div>
   
    <div class="divRight"></div>
  </div>
  <div class="bottom">
    <div class="bottomtext">Copyright &copy; 2004-2010 35 Technology Co., Ltd. All Rights Reserved.</div>
    <div class="power"></div>
  </div>
</div>
<div id="divMainLoader">Loading...</div>

<div id="tbNews" style="display:none">
  <div class="comeTitle">欢迎您使用</div>
  <div class="comeInfo">尊敬的用户：<strong><asp:Literal ID="lit_userName" runat="server"></asp:Literal></strong>您好！<br />
    <p>欢迎您使用！</p>
    <p>您此次登录是第<strong><asp:Literal ID="lit_Times" runat="server"></asp:Literal></strong>次</p>
    <p>您上次登录的时间是：<strong><asp:Literal ID="lit_LastTime" runat="server"></asp:Literal></strong></p>
    <p>登录IP：<strong><asp:Literal ID="lit_LastIp" runat="server"></asp:Literal></strong></p>
  </div>
</div>
<div style="display:none;">
    <div id="scroll_LeftTree"><asp:Literal ID="lit_cateTree" runat="server"></asp:Literal></div>
    <div id="nowstr"></div>
</div>
</body>
<script type="text/javascript">
dcmstab.initLeftMenu();
function changeViewClass()//切换左边类别视图
{
    if(document.getElementById("treeLeft").style.display=="none")
    {
        document.getElementById("treeLeft").style.display="block";
        $('#treeLeft').height($('.divRight').height());
        return;
    } 
    else
    document.getElementById("treeLeft").style.display="none";
     
}
function getTreeLeftMenu()//获取左边树状类别视图
{
    $.get("TreeCate.aspx?action=gettreecate&time="+Math.random()+"", function(data){        
        $("#treeLeftContent").empty().append(data);
        var html=window.dtree.toString();
        $("#treeLeftContent").html(html);
		//excTreeCate();
	});
}

getTreeLeftMenu();//获取左边树状类别视图
function TestData()//导入测试数据
{
    if(confirm("如果有录入正式数据请慎用此功能！确定要导入测试数据吗？"))
    {
       $.ajax({
	   type: "post",
	   url: "cate_manage.aspx?action=testdata",
	   success: function(data, textStatus){
	        if(data=="false")
	        {
	            alert("没有类别可导！");
	            return false;
	        }
	        alert(data);
	        $("#span_testdata").unbind();
	        $("#span_testdata").html("清空测试数据");
	       $("#span_testdata").bind("click",function()	       {	            ClearTestData();	       }	       );
	   }
	 });
    }
//var e=(evt)?evt:window.event; //判断浏览器的类型，在基于ie内核的浏览器中的使用cancelBubble
//if (window.event) { 
//e.cancelBubble=true; 
//} else { 
//e.preventDefault(); //在基于firefox内核的浏览器中支持做法stopPropagation
//e.stopPropagation(); 
//} 
     
}

function ClearTestData()//清空测试数据
{
    if(confirm("确认要清空网站所有的测试数据吗？"))
    {
       $.ajax({
	   type: "post",
	   url: "cate_manage.aspx?action=cleartestdata",
	   success: function(data, textStatus){	        
	        alert(data);
	        $("#span_testdata").unbind();
	        $("#span_testdata").html("生成测试数据");
	        $("#span_testdata").bind("click",function()
	        {
	            TestData();
	        }
	        )
	   }
	 });
    }     
}
</script>
</html>
