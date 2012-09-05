<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Manage.BaseManage.Manage_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title id="Title_CPLogin">DesignCMS@35后台管理系统登录</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<script type="text/javascript" src="Green/Js/jquery.js"></script>
    <link rel="Stylesheet" href="Green/Css/common.css" />
	<link rel="Stylesheet" href="Green/Css/dcmsjs.css" />
	<link rel="stylesheet" href="Green/Css/module.css" type="text/css" media="all" />
	<!--调用对话框样式开始-->
	<script type="text/javascript" src="Green/jmodal/jmodal.js"></script>
	<link rel="stylesheet" href="Green/jmodal/jmodal.css" type="text/css" media="all" />
	<!--调用对话框样式结束-->
</head>
<body>
<form runat="server" id="form1">
<table width="100%" height="571" class="loginbg" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>
		<table width="100%" height="571" border="0" cellspacing="0" cellpadding="0">
		  <tr>
			<td width="60%" align="right" valign="top">
					<table width="220" style="margin-right:20px;margin-top:208px;" border="0" cellspacing="0" cellpadding="0">
					  <tr>
						<td><img src="Green/Images/login-logo.gif" width="297" height="78" /></td>
					  </tr>
					  <tr>
						<td>
							<ul style="margin-left:70px;color:#7A7B7B;"> 
							  <li style="height:20px;">采用安全稳定的ASP.NET应用开发</li> 
							  <li style="height:20px;">最高效的基于.NET 2.0 Framework</li> 
							  <li style="height:20px;">功能强大的网站后台管理系统</li> 
							</ul> 
						</td>
					  </tr>
					  <tr>
						<td height="28">
													</td>
					  </tr>
					</table>
			</td>
			<td class="loginsplit" width="3"></td>
			<td valign="top">
			<table width="100%" style="margin-top:232px;" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="33" style="font-size:14px;font-weight:bold;">&nbsp;&nbsp;&nbsp;登录DesignCMS@35后台管理系统</td>
              </tr>
              <tr>
                <td><table width="100%" height="78" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="80" height="39" align="right">用户名：&nbsp;</td>
                    <td>&nbsp;<asp:TextBox ID="txb_adminzh" CssClass="logintxtbox" runat="server"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td height="39" align="right">密&nbsp;&nbsp;&nbsp;码：&nbsp;</td>
                    <td>&nbsp;<asp:TextBox ID="txb_adminmm" CssClass="logintxtbox" runat="server" TextMode="Password"></asp:TextBox></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td height="35">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btn_login" runat="server" CssClass="loginbtn" Text="登 录" 
                        onclick="btn_login_Click" /></td>
              </tr>
              <tr>
                <td height="35"><asp:Literal ID="lit_ErrorInfo" runat="server"></asp:Literal></td>
              </tr>
            </table></td>
		  </tr>
		</table>
	</td>
    <td width="260" valign="bottom"><img src="Green/Images/login-wel.gif" width="238" height="77" style="margin-bottom:60px;margin-right:20px;" /></td>
  </tr>
</table>

<div class="bottom">
    <div class="bottomtext">Copyright &copy; 2004-2010 35 Technology Co., Ltd. All Rights Reserved.</div>
    <div class="power"></div>
</div>
</form>
</body>
</html>
