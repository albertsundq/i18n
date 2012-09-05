<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckSN.aspx.cs" Inherits="System_CheckSN" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<META>
<title>DMCS3.0@35.com 欢迎您</title>
<style type="text/css">
	html *{ margin:0; padding:0;}
	body{ font-size:12px; font-family:Arial, Helvetica, sans-serif}	
	body{ background:#f2f8fc url(/Skin/_sys/errorbody_bg.png) repeat-x; line-height:150%;}
	/*404页面样式*/	
	.error_cotent{margin-top:88px;margin-left:auto;margin-right:auto;}
	.error_foot{height:105px; padding-top:80px; text-align:center; color:#768CAA; line-height:25px;}
	.error_foot a{color:#768CAA; text-decoration:none;}
	.inputCss{
	background-image: url(/Skin/_sys/input.png);
	background-repeat: no-repeat;
	height: 17px;
	width: 198px;
	border:0px;
	padding:2px;
	}
	.btnCss{
	background-image: url(/Skin/_sys/btn.png);
	background-repeat: no-repeat;
	height: 21px;
	width: 60px;
	border:0px;
	}
</style>
</head>
<body>
<form id="form1" runat="server">
<div class="error_cotent"><a href="http://Design.35.com"></a>
  <table width="682" height="457" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td background="/Skin/_sys/Check_login.png"><table width="100%" height="452" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="33%">&nbsp;</td>
          <td width="67%" valign="top"><table width="89%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="69">&nbsp;</td>
            </tr>
            <tr>
              <td height="146" align="left" valign="top"><p><strong style="font-size:14px;">Design CMS 3.0 安装协议</strong><br />
                版权所有 (c) 2004-2010，厦门三五互联科技股份有限公司<br />
                保留所有权利。</p><br />
                <p>感谢您选择 Design CMS 产品。希望我们的努力能为您提供一个
                  高效快速和功能强大的网站解决方案。<br />
                </p></td>
            </tr>
            <tr>
              <td height="30" align="left">&nbsp;</td>
            </tr>
            <tr>
              <td height="25" align="left">网站域名：
				<asp:TextBox id="labhost" runat="server" CssClass="inputCss"></asp:TextBox>
				</td>
            </tr>            
            <tr>
              <td height="90" align="left"  style="color:#FF4200">您好，请将网站的域名发送到厦门三五互联科技股份有限公司<br />
                设计分中心客服部申请授权认证，并且提供网站所在的服务器IP地址，Ftp账号和密码，谢谢！<br />
                E-mail:dcms@35.cn   Tel:0592-5399552 Fax:0592-5399530</td>
            </tr>
            
          </table></td>
        </tr>
      </table></td>
    </tr>
  </table>
</div>
</form>
</body>
</html>
