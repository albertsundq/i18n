<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Manage_Error" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>错误提示页</title>
<link rel="Stylesheet" href="Green/Css/common.css" />
<link rel="Stylesheet" href="Green/Css/dcmsjs.css" />
<link rel="stylesheet" href="Green/Css/module.css" type="text/css" media="all" />
</head>
<body>
<div id="tbNews">
  <div class="comeTitle">错误提示</div>
  <div class="comeInfo">尊敬的用户：<strong><asp:Literal ID="lit_userName" runat="server"></asp:Literal></strong>您好！
    <p>错误信息：<strong><asp:Literal ID="lit_ErrorInfo" runat="server"></asp:Literal></strong></p>
    <p>操作时间：<strong><asp:Literal ID="lit_Time" runat="server"></asp:Literal></strong></p>
    <p>操作IP：<strong><asp:Literal ID="lit_Ip" runat="server"></asp:Literal></strong></p>
  </div>
</div>
</body>
</html>
