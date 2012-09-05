<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="_Contact_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_footer.ascx" TagName="_footer" TagPrefix="Dcms" %>
<Dcms:_header ID="_header_0" runat="server" />
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Title" FieldValue="" Children="0" PageSize="1" IsPage="False" Where="Cate_State='1' and #Cate_Id=Contact#" OrderBy="Cate_IdPath asc">
	<ItemTemplate0><b>{Dcms_Cate.Cate_Title}</b></ItemTemplate0>
</Dcms:Drepeater>
</div>

<div class="aboutleft"><ul class="slink" >
 <Dcms:Drepeater ID="Repeater1" runat="server" SqlType="select" SelectDir="sub" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Id,Cate_Title" FieldValue="" Children="0" PageSize="100" IsPage="False" Where="Cate_State='1' and #Cate_Id=gywm# " OrderBy="Cate_Order Desc">
          	<ItemTemplate0>          <li style="line-height:24px; padding-top:3px;"><a href="about.aspx?BaseinfoCateid={Dcms_Cate.Cate_Id}&Baseinfoid={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}"id="{Dcms_Cate.Cate_Id}" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a></li>                    </ItemTemplate0>
          </Dcms:Drepeater>
	
          
 
    </ul></div><div class="mess" style="clear:both;"><a href="guestbook.aspx"><img src="images/about_18.gif" / border="0"></a></div>
    
</div>




</div>

<div class="aboutright">
  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="693" height="238">
    <param name="movie" value="flash/banner.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="transparent" />
    <embed src="flash/banner.swf" width="693" height="238" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
  </object>
  </div>

</div>
<div class="dqwz">
<div class="dqwz1"><li style="padding-top:24px; padding-left:46px; color:#FFFFFF"><div class="sidebar2"><div class="abou">您当前位置: 客服中心  >   在线留言 </div></div>
</div>
<Dcms:Drepeater ID="Repeater2" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="BaseInfo_Id" TotalLayer="1" TableName="Dcms_BaseInfo" FieldName="BaseInfo_Content" FieldValue="" Children="0" PageSize="1" IsPage="False" Where="BaseInfo_State='1' and #BaseInfo_CateId={Get.BaseInfoCateId,Contact}# " OrderBy="BaseInfo_Id Desc">
                          	<ItemTemplate0>                        <div id="1111" style="padding-right:5px; padding-left:10px; line-height:23px; ">{Dcms_BaseInfo.BaseInfo_Content}</div>                        </ItemTemplate0>
                        </Dcms:Drepeater>
</div>
<div class="baidu" style="float:right; padding-right:18px;">
<style type="text/css">
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>
  <div style="width:677px;height:450px;border:#ccc solid 1px;" id="dituContent"></div><script type="text/javascript">
    //创建和初始化地图函数：
    function initMap(){
        createMap();//创建地图
        setMapEvent();//设置地图事件
        addMapControl();//向地图添加控件
        addMarker();//向地图中添加marker
    }
    
    //创建地图函数：
    function createMap(){
        var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
        var point = new BMap.Point(121.808104,39.067212);//定义一个中心点坐标
        map.centerAndZoom(point,16);//设定地图的中心点和坐标并将地图显示在地图容器中
        window.map = map;//将map变量存储在全局
    }
    
    //地图事件设置函数：
    function setMapEvent(){
        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard();//启用键盘上下左右键移动地图
    }
    
    //地图控件添加函数：
    function addMapControl(){
        //向地图中添加缩放控件
	var ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_LARGE});
	map.addControl(ctrl_nav);
        //向地图中添加缩略图控件
	var ctrl_ove = new BMap.OverviewMapControl({anchor:BMAP_ANCHOR_BOTTOM_RIGHT,isOpen:1});
	map.addControl(ctrl_ove);
        //向地图中添加比例尺控件
	var ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});
	map.addControl(ctrl_sca);
    }
    
    //标注点数组
    var markerArr = [{title:"大连富甲蓝莓有限公司",content:"联系人：李先生：18900996811&nbsp;&nbsp;都先生18900995561&nbsp;&nbsp;&nbsp;联系地址：辽宁&nbsp;大连市保税区亮甲店街道岔山村",point:"121.807978|39.066764",isOpen:1,icon:{w:21,h:21,l:0,t:0,x:6,lb:5}}
		 ];
    //创建marker
    function addMarker(){
        for(var i=0;i<markerArr.length;i++){
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0,p1);
			var iconImg = createIcon(json.icon);
            var marker = new BMap.Marker(point,{icon:iconImg});
			var iw = createInfoWindow(i);
			var label = new BMap.Label(json.title,{"offset":new BMap.Size(json.icon.lb-json.icon.x+10,-20)});
			marker.setLabel(label);
            map.addOverlay(marker);
            label.setStyle({
                        borderColor:"#808080",
                        color:"#333",
                        cursor:"pointer"
            });
			
			(function(){
				var index = i;
				var _iw = createInfoWindow(i);
				var _marker = marker;
				_marker.addEventListener("click",function(){
				    this.openInfoWindow(_iw);
			    });
			    _iw.addEventListener("open",function(){
				    _marker.getLabel().hide();
			    })
			    _iw.addEventListener("close",function(){
				    _marker.getLabel().show();
			    })
				label.addEventListener("click",function(){
				    _marker.openInfoWindow(_iw);
			    })
				if(!!json.isOpen){
					label.hide();
					_marker.openInfoWindow(_iw);
				}
			})()
        }
    }
    //创建InfoWindow
    function createInfoWindow(i){
        var json = markerArr[i];
        var iw = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json.title + "'>" + json.title + "</b><div class='iw_poi_content'>"+json.content+"</div>");
        return iw;
    }
    //创建一个Icon
    function createIcon(json){
        var icon = new BMap.Icon("http://openapi.baidu.com/map/images/us_mk_icon.png", new BMap.Size(json.w,json.h),{imageOffset: new BMap.Size(-json.l,-json.t),infoWindowOffset:new BMap.Size(json.lb+5,1),offset:new BMap.Size(json.x,json.h)})
        return icon;
    }
    
    initMap();//创建和初始化地图
</script>

</div>

<div class="">&nbsp;</div>

<Dcms:_footer ID="_footer_1" runat="server" />