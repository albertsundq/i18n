<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forget.aspx.cs" Inherits="_forget_aspx" EnableViewState="false" %>
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
.STYLE5 {color: #FFFFFF}
-->
</style>
<script src="/sysaspx/common.js" type="text/javascript"></script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0"><Dcms:_header ID="_header_0" runat="server" />
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
                    <td>
                    <Dcms:_member_left ID="_member_left_1" runat="server" />                    </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="center"><img src="images/about_18.gif" width="182" height="84" /></td>
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
                        <td width="644"><div class="STYLE5">您当前位置: 会员中心 &gt;找回密码 </div></td>
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
                        <td style="padding-top:36px;padding-left:66px;">
                        
                        <form action="sysaspx/getpwdcs.aspx" method="post">
                        <table width="312" class="retable" style="margin:5px auto;">
                          <tr>
                            <td>用户名：</td>
                            <td><input type="text"  class="inputb" name="User_Name" id="User_Name" />
                                <span>*</span><strong style=" font-weight:normal; color:#3f87d1;">请填写用户名</strong></td>
                          </tr>
                          <tr>
                            <td>邮箱：</td>
                            <td><input type="text"  class="inputb" name="User_Email" id="User_Email" />
                                <span>*</span></td>
                          </tr>
                          <tr>
                            <td>&nbsp;</td>
                            <td><input type="submit"  value="下一步" class="button" class="button" name="input" /></td>
                          </tr>
                        </table>
                        </form>                        </td>
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
