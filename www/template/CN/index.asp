<!-- #include file="_header.asp" -->

<div id="top" style="background-color:#fff">
<div class="kbdf"><img src="images/kb.JPG" /></div>
<style type="text/css">
* {margin:0; padding:0;}
.clearfix:after {content: "."; display: block; height: 0; clear: both; visibility: hidden;}
.clearfix {zoom:1;}
ul,li {list-style:none;}
img {border:0;}

.wrapper {width:600px; margin:0 auto; padding-bottom:50px;}

h1 {height:50px; line-height:50px; font-size:22px; font-weight:normal; font-family:"Microsoft YaHei",SimHei;}

.shuoming {margin-top:20px; border:1px solid #ccc; padding-bottom:10px;}
.shuoming dt {height:30px; line-height:30px; font-weight:bold; text-indent:10px;}
.shuoming dd {line-height:20px; padding:5px 20px;}

/* qqshop focus */
#focus {width:600px; height:340px; overflow:hidden; position:relative;}
#focus ul {height:380px; position:absolute;}
#focus ul li {float:left; width:600px; height:340px; overflow:hidden; position:relative; background:#000;}
#focus ul li div {position:absolute; overflow:hidden;}
#focus .btnBg {position:absolute; width:600px; height:20px; left:0; bottom:0; background:#000;}
#focus .btn {position:absolute; width:780px; height:10px; padding:5px 10px; right:0; bottom:0; text-align:right;}
#focus .btn span {display:inline-block; _display:inline; _zoom:1; width:25px; height:10px; _font-size:0; margin-left:5px; cursor:pointer; background:#fff;}
#focus .btn span.on {background:#fff;}
#focus .preNext {width:45px; height:100px; position:absolute; top:90px; background:url(img/sprite.png) no-repeat 0 0; cursor:pointer;}
#focus .pre {left:0;}
#focus .next {right:0; background-position:right top;}
</style>

<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript">
$(function() {
	var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
	var len = $("#focus ul li").length; //获取焦点图个数
	var index = 0;
	var picTimer;
	
	//以下代码添加数字按钮和按钮后的半透明条，还有上一页、下一页两个按钮
	var btn = "<div class='btnBg'></div><div class='btn'>";
	for(var i=0; i < len; i++) {
		btn += "<span></span>";
	}
	btn += "</div><div class='preNext pre'></div><div class='preNext next'></div>";
	$("#focus").append(btn);
	$("#focus .btnBg").css("opacity",0.5);

	//为小按钮添加鼠标滑入事件，以显示相应的内容
	$("#focus .btn span").css("opacity",0.4).mouseenter(function() {
		index = $("#focus .btn span").index(this);
		showPics(index);
	}).eq(0).trigger("mouseenter");

	//上一页、下一页按钮透明度处理
	$("#focus .preNext").css("opacity",0.2).hover(function() {
		$(this).stop(true,false).animate({"opacity":"0.5"},300);
	},function() {
		$(this).stop(true,false).animate({"opacity":"0.2"},300);
	});

	//上一页按钮
	$("#focus .pre").click(function() {
		index -= 1;
		if(index == -1) {index = len - 1;}
		showPics(index);
	});

	//下一页按钮
	$("#focus .next").click(function() {
		index += 1;
		if(index == len) {index = 0;}
		showPics(index);
	});

	//本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
	$("#focus ul").css("width",sWidth * (len));
	
	//鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
	$("#focus").hover(function() {
		clearInterval(picTimer);
	},function() {
		picTimer = setInterval(function() {
			showPics(index);
			index++;
			if(index == len) {index = 0;}
		},4000); //此4000代表自动播放的间隔，单位：毫秒
	}).trigger("mouseleave");
	
	//显示图片函数，根据接收的index值显示相应的内容
	function showPics(index) { //普通切换
		var nowLeft = -index*sWidth; //根据index值计算ul元素的left值
		$("#focus ul").stop(true,false).animate({"left":nowLeft},300); //通过animate()调整ul元素滚动到计算出的position
		//$("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
		$("#focus .btn span").stop(true,false).animate({"opacity":"0.4"},300).eq(index).stop(true,false).animate({"opacity":"1"},300); //为当前的按钮切换到选中的效果
	}
});

</script>

<div class="banner">
<div class="wrapper" >
  <div id="focus">
   <ul><!--Repeater TableName="Dcms_BaseInfo" Where="BaseInfo_State='1' and #BaseInfo_CateId=banner# " OrderBy="BaseInfo_Id Desc" SqlType="select" PrimaryKey="BaseInfo_Id" SelectDir="this" PageSize="10" IsPage="False"-->
<!--Item-->
   
      <li><a href="{Dcms_BaseInfo.BaseInfo_Content}" target="_blank"><img src="{Dcms_BaseInfo.BaseInfo_Image}" width="600" height="340" /></a></li>
      
    
    <!--/Item-->
<!--/Repeater-->
</ul>
  </div>
</div>



</div>

<div class="right">

<div class="rig1"><a href="about.aspx?BaseinfoCateid=6&amp;Baseinfoid=6&amp;CateID=6"><img src="images/index_08.gif" / border="0"></a></div>
<div class="rig2">
<div class="rig01"><img src="images/ab.JPG" /></div>
<div class="rig02">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;大连富甲蓝莓有限公司的种植基地选址在水源充沛、无任何工业污染的大连市保税区亮甲店街道岔山村，距大连市中心50公里，是一家台湾、日本、中国大陆合资的集蓝莓种植...</div>

</div>


</div>

<div class="right" style="margin-top:17px;">

<div class="rig1"><a href="about.aspx?BaseinfoCateid=18&amp;Baseinfoid=18&amp;CateID=18"><img src="images/index_11.gif" / border="0"></a></div>
<div class="rig2">
<div class="rig03" style="padding-left:6px;">基地占地1000余亩，其中露地栽培面积/500亩；温室100栋、占地200亩；冷棚100栋、占地100亩。为满足不同客户对蓝莓产品的需求，我公司园区现栽种品种有10余种</div>

</div>
<div class="rig03"><img src="images/index_13.gif" /></div>

</div>

</div>

<div id="mainn" style="clear:both; padding-top:12px; padding-left:12px;">
<div id="main">
<div class="maina"><img src="images/index_21.gif" /></div>
<div class="mainb" style="padding-top:12px;">
  <script language="JavaScript" type="text/javascript">
function message_OnSubmit() {
var err=0;
var Uname=get("User_Name").value;
if(Uname.length<1){get("ReqUname").innerHTML="*请输入账号";err=err+1;}else{get("ReqUname").innerHTML="*"}var ValidCode=get("ValidCode").value;
if(ValidCode.length<1){get("ReqValidCode").innerHTML="*请输入验证码";err=err+1;}else{get("ReqValidCode").innerHTML="*"}
var Password1=get("User_Password").value;
if(Password1.length<1){get("ReqPassword1").innerHTML="*请输入密码";err=err+1;}else{get("ReqPassword1").innerHTML="*"}
if(err>0){return false;}
}
  </script>
  <form name="messageForm" method="post" action="/sysaspx/chkLogin.aspx" onsubmit="javascript:return message_OnSubmit(this);" id="messageForm">
    <input type="hidden" name="successMessage" id="successMessage" value="登录成功！" />
    <input type="hidden" name="successUrl" id="successUrl" value="/EditUser.aspx" />
    <input type="hidden" name="errorMessage" id="errorMessage" value="对不起，提交失败，请重试！" />
    <input type="hidden" name="errorCodeMessage" id="errorCodeMessage" value="对不起，您输入的验证码值不对，请重试！" />
    <table width="257" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="257" height="116" background="images/11.JPG"><table width="91%" height="108" border="0" align="center" cellpadding="0" cellspacing="1">
          <tr >
            <td align="left" width="57">用户名：</td>
            <td align="left" width="178" height="20">&nbsp;
                <input name="User_Name" type="text" id="User_Name" style="width:120px;" /></td>
          </tr>
          <tr >
            <td align="left" height="23">密码：</td>
            <td align="left" height="23">&nbsp;
                <input name="User_Password" type="password" id="User_Password" style="width:100px;" /></td>
          </tr>
          <tr>
            <td align="left" height="29">验证码：</td>
            <td align="left"><div style="width:88px;height:29px;float:left;padding-left:6px;">
                <input name="ValidCode" type="text" id="ValidCode" style="width:80px;margin-top:3px;" />
              </div>
                <div style="width:68px;height:29px;float:left;padding-left:3px;cursor:pointer;"><img src="/sysaspx/ValidCodeImage.aspx" onclick="this.src='/sysaspx/ValidCodeImage.aspx?code=1' + Math.random();" title="点击刷新验证码" height="29" width="66" /></div>
              </td>
          </tr>
          <tr >
            <td colspan="2" align="center"  ><input type="submit" class="qd" value=" 登录 " />
              &nbsp;&nbsp;&nbsp;&nbsp;
              <input type="reset" value=" 重填 "class="qd" /></td>
          </tr>
        </table></td>
      </tr>
    </table>
    </form>
</div>
</div>
<div id="tup"><img src="images/index_16.gif" /></div>


<div id="main1">
<div class="mainc"><a href="news.aspx?newsCateID=8&amp;CateID=8"><img src="images/index_17.gif" / border="0"></a></div>
<div class="maind"><ul class="hnews " >
            <!--Repeater TableName="Dcms_News" Where="News_State='1' and #News_CateId={Get.NewsCateId,news}# " OrderBy="News_AddTime Desc" SqlType="select" PrimaryKey="News_Id" SelectDir="thisandallsub" PageSize="5" IsPage="True"-->
                    <!--Item-->
                     <li style="line-height:25px; text-align:left" ><a class="home2"  href="newsde.aspx?newsCateID={Dcms_News.News_CateId}&CateID={Dcms_News.News_CateId}&NewsID={Dcms_News.News_Id}">{Dcms_News.News_Title,36}<span style="font-size:11px">{Dcms_News.News_AddTime,yyyy-MM-dd}</span></a></li>
                    <!--/Item-->
                    <!--/Repeater--> 
        </ul></div>
</div>
<div id="tup"><img src="images/index_18.gif" /></div>
<div id="main2"><a href="products.aspx?ProductsCateID=10&amp;CateID=10&amp;CurrCateID=10"><img src="images/33.JPG" / border="0"></a></div>

<div id="main3"></div>
</div>


<!-- #include file="_footer.asp" -->