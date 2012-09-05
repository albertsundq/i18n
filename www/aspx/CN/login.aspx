<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_login_aspx" EnableViewState="false" %>
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
<SCRIPT src="js/jquery.js" type=text/javascript></SCRIPT>
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
-->
</style>
<script src="/sysaspx/common.js" type="text/javascript"></script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
<Dcms:_header ID="_header_0" runat="server" />
<table width="1003" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" bgcolor="#FFFFFF"><table width="1003" cellspacing="0" cellpadding="0">
        <tr>
          <td width="1001"><table width="1003" cellspacing="0" cellpadding="0">
              <tr>
                <td width="221" valign="top"><table width="193" align="center" cellpadding="0" cellspacing="0">
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
                      <td align="center"><a href="mycart.html"><img src="images/about_18.gif" width="182" height="84" / border="0"></a></td>
                    </tr>
                  </table></td>
                <td width="780" valign="top"><table width="717" align="right" cellpadding="0" cellspacing="0">
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
                                  <td width="644"><div class="STYLE5">您当前位置: 会员中心 &gt;会员登录 </div></td>
                                </tr>
                              </table></td>
                          </tr>
                        </table></td>
                    </tr>
                    <tr>
                      <td height="27"><table width="427" height="176" align="center" cellpadding="0" cellspacing="0">
                          <tr>
                            <td background="images/lomg.JPG"><table width="365" height="73" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                  <td style="padding-top:36px;padding-left:66px;"><script language="javascript" type="text/javascript">
								  
function message_OnSubmit() {
var User_Name=document.getElementById("User_Name").value;
if(User_Name.length<1){alert("请填写用户名!");return false;}

var User_Password=document.getElementById("User_Password").value;
if(User_Password.length==""){alert("请输入密码!!");return false;}

var ValidCode=document.getElementById("ValidCode").value;
if(ValidCode.length<1){alert("请填写验证码!");return false;}
}
</script>
                                    <div id="loginout" style="display:block">
                                      <form name="messageForm" method="post" action="/sysaspx/chkLogin.aspx" onsubmit="javascript:return message_OnSubmit(this);" id="messageForm">
                                        <input type="hidden" name="successMessage" id="successMessage" value="登录成功！" />
                                        <input type="hidden" name="successUrl" id="successUrl" value="/login.aspx" />
                                        <input type="hidden" name="errorMessage" id="errorMessage" value="对不起，提交失败，请重试！" />
                                        <input type="hidden" name="errorCodeMessage" id="errorCodeMessage" value="对不起，您输入的验证码值不对，请重试！" />
                                        <table class="retable" style="margin-left:0;">
                                          <tr>
                                            <td>用户名：</td>
                                            <td><input type="text"  class="inputb" id="User_Name" name="User_Name" /></td>
                                          </tr>
                                          <tr>
                                            <td>密码：</td>
                                            <td><input type="password"  class="inputb" id="User_Password" name="User_Password" /></td>
                                          </tr>
                                          <tr>
                                            <td>验证码：</td>
                                            <td><div style="float:left;">
                                                <input type="text" id="ValidCode" name="ValidCode" class="inputb" style="width:50px; margin-right:10px;" />
                                              </div>
                                              <div style="width:115px;height:29px;float:left;padding-left:3px;cursor:pointer;"><img src="/sysaspx/ValidCodeImage.aspx" onclick="this.src='/sysaspx/ValidCodeImage.aspx?code=1' + Math.random();" title="点击刷新验证码" height="29" width="112" /></div></td>
                                          </tr>
                                          <tr>
                                            <td>&nbsp;</td>
                                            <td><a href="forget.aspx">忘记密码？</a></td>
                                          </tr>
                                          <tr>
                                            <td>&nbsp;</td>
                                            <td><input type="submit"  value="登 录"  class="button" name="input" />
                                              <a href="register.aspx">还未注册?</a></td>
                                          </tr>
                                        </table>
                                      </form>
                                    </div>
                                    <div id="loginin" style="display:none"> 欢迎您，<%=System.Convert.ToString(Dcms.Utility.SessionHelper.Get("UserName"))%> </div>
                                    <script>
                                    var sessionname='<%=System.Convert.ToString(Dcms.Utility.SessionHelper.Get("UserName"))%>';
                                  if(sessionname!=''){
								   document.getElementById("loginout").style.display="none";
								   document.getElementById("loginin").style.display="block";
								  }else{
								   document.getElementById("loginin").style.display="none";
								   document.getElementById("loginout").style.display="block";
								  }
                                    </script>                                    </td>
                                </tr>
                              </table></td>
                          </tr>
                        </table></td>
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
