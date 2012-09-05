<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="_register_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_member_left.ascx" TagName="_member_left" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_footer.ascx" TagName="_footer" TagPrefix="Dcms" %>
<!DOCTYPE html PUBLIC "-//W3C//dtD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/dtD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<TITLE>大连富甲蓝莓有限公司</TITLE>
<link href="css/default.css" rel="stylesheet" type="text/css" />
<link href="styles/default.css" rel="stylesheet" type="text/css" />
<link href="styles/sort.css" rel="stylesheet" type="text/css" />
<script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
<SCRIPT src="js/jquery.js" type=text/javascript></SCRIPT>
<script type="text/javascript" src="js/jquery.min.js"></script>
<style type="text/css">
<!--
.STYLE1 {
	font-size: 18px;
	font-weight: bold;
	color: #FFFFFF;
}
.STYLE5 {
	color: #FFFFFF
}
.STYLE6 {
	color: #FF0000
}
-->
</style>
<script src="/sysaspx/common.js" type="text/javascript"></script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0"><Dcms:_header ID="_header_0" runat="server" />
<table width="1003" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" bgcolor="#FFFFFF"><table width="1003" cellspacing="0" cellpadding="0">
        <tr>
          <td width="1001"><table width="1003" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td width="219" valign="top"><table width="193" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="191" height="41" background="images/about_06.GIF"><table width="100" align="center" cellpadding="0" cellspacing="0">
                          <tr>
                            <td><span class="STYLE1">会员中心 </span></td>
                          </tr>
                        </table></td>
                    </tr>
                    <tr>
                      <td height="230" valign="top" background="images/about_03.gif"><table width="143" align="center" cellpadding="0" cellspacing="0">
                          <tr>
                            <td><Dcms:_member_left ID="_member_left_1" runat="server" />                            </td>
                          </tr>
                        </table></td>
                    </tr>
                    <tr>
                      <td align="center"><img src="images/about_18.gif" width="182" height="84" /></td>
                    </tr>
                  </table></td>
                <td width="782"  valign="top"><table width="717" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                      <td><span class="aboutright">
                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="693" height="238">
                          <param name="movie" value="flash/banner.swf" />
                          <param name="quality" value="high" />
                          <param name="wmode" value="transparent" />
                          <embed src="flash/banner.swf" width="693" height="238" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
                        </object>
                      </span></td>
                    </tr>
                    <tr>
                      <td height="26"><table width="700" cellspacing="0" cellpadding="0">
                          <tr>
                            <td height="51" valign="bottom" background="images/about_15.GIF"><table width="700" height="40" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td width="52" height="35">&nbsp;</td>
                                  <td width="644"><div class="STYLE5">您当前位置: 会员中心 &gt;会员注册 </div></td>
                                </tr>
                              </table></td>
                          </tr>
                        </table></td>
                    </tr>
                    <tr>
                      <td height="27"><div class="wbox">
                          <div class="rebox">
                            <dl class="reinfo">
                              <dt>已是会员？<br />
                                请直接登录<a href="login.aspx" class="lbutton STYLE6">立即登录</a></dt>
                              <dd>绿色、安全<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;健康更放心。</dd>
                            </dl>
                            <script language="javascript" type="text/javascript">
function message_OnSubmit() {
var User_Name=document.getElementById("User_Name").value;
if(User_Name.length<1){alert("请填写用户名!");return false;}

var Password1=document.getElementById("Password1").value;
if(Password1.length<6){alert("密码应为6-12位字符!");return false;}

var Password2=document.getElementById("Password2").value;
if(Password2!=Password1){alert("两次密码不一致!");return false;}

var User_RealName=document.getElementById("User_RealName").value;
if(User_RealName.length<1){alert("请填写姓名!");return false;}

var User_Email=document.getElementById("User_Email").value;
if(User_Email.length<1){alert("请填写电子邮箱!");return false;}

var User_Tel=document.getElementById("User_Tel").value;
if(User_Tel.length<1){alert("请填写移动电话!");return false;}

var User_Address=document.getElementById("User_Address").value;
if(User_Address.length<1){alert("请填写联系地址!");return false;}

var ValidCode=document.getElementById("ValidCode").value;
if(ValidCode.length<1){alert("请填写验证码!");return false;}

}
</script>
                            <form name="messageForm" method="post" action="/sysaspx/saveUser.aspx" onsubmit="javascript:return message_OnSubmit(this);" id="messageForm">
                              <input type="hidden" name="successMessage" id="successMessage" value="感谢您的注册！" />
                              <input type="hidden" name="successUrl" id="successUrl" value="/login.aspx" />
                              <input type="hidden" name="errorMessage" id="errorMessage" value="对不起，提交失败，请重试！" />
                              <input type="hidden" name="errorCodeMessage" id="errorCodeMessage" value="对不起，您输入的验证码值不对，请重试！" />
                              <table class="retable">
                                <tr>
                                  <td>用户名：</td>
                                  <td><input type="text"  class="inputb" id="User_Name" name="User_Name" />
                                    <span>*</span><a href="" style=" color:#3f87d1;"></a></td>
                                </tr>
                                <tr>
                                  <td>密码：</td>
                                  <td><input type="password"  class="inputb" id="Password1" name="Password1"/>
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>确认密码：</td>
                                  <td><input type="password"  class="inputb" id="Password2" name="Password2" />
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>姓名：</td>
                                  <td><input type="text"  class="inputb" id="User_RealName" name="User_RealName" />
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>电子邮箱：</td>
                                  <td><input type="text"  class="inputb" id="User_Email" name="User_Email" />
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>移动电话：</td>
                                  <td><input type="text"  class="inputb" id="User_Tel" name="User_Tel" />
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>固定电话：</td>
                                  <td><input type="text"  class="inputb" id="User_IM" name="User_IM" /></td>
                                </tr>
                                <tr>
                                  <td>联系地址：</td>
                                  <td><input type="text"  class="inputb" id="User_Address" name="User_Address" />
                                    <span>*</span></td>
                                </tr>
                                <tr>
                                  <td>验证码：</td>
                                  <td><input name="ValidCode" type="text" id="ValidCode" style="width:100px; margin-right:10px;" class="inputb"/>
                                    <div style="width:115px;height:29px;float:left;padding-left:3px;cursor:pointer;"><img src="/sysaspx/ValidCodeImage.aspx" onclick="this.src='/sysaspx/ValidCodeImage.aspx?code=1' + Math.random();" title="点击刷新验证码" height="29" width="112" /></div>
                                    <div id="ReqValidCode" style="color:Red;line-height:29px;float:left;">*</div></td>
                                </tr>
                                <tr>
                                  <td>&nbsp;</td>
                                  <td><input type="submit" class="button"  value="注册" name="input" /></td>
                                </tr>
                              </table>
                            </form>
                          </div>
                        </div></td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
    </table></td>
  </tr>
</table>
<Dcms:_footer ID="_footer_2" runat="server" />   

</body>
</html>
