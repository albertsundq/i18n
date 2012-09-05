<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_member_left.ascx.cs" Inherits="_member_left_ascx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<ul class="slink" >
  <li style="line-height:24px; padding-top:3px;display:none;" id="mlog"><a href="login.aspx"id="login" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;会员登录</a></li>
  <li style="line-height:24px; padding-top:3px;display:none;" id="mreg"><a href="register.aspx"id="register" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;会员注册</a></li>
  <li style="line-height:24px; padding-top:3px;display:none;" id="mget"><a href="forget.aspx"id="getpwd" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;找回密码</a></li>
  <li style="line-height:24px; padding-top:3px; display:none" id="minfo"><a href="memberinfo.aspx"id="memberinfo" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;个人信息</a></li>
  <li style="line-height:24px; padding-top:3px; display:none" id="morder"><a href="mycart.aspx"id="mycart" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;会员订单</a></li>
  <li style="line-height:24px; padding-top:3px; display:none" id="mout"><a href="sysaspx/out.aspx"id="memberout" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;退出登录</a></li>
</ul>
<script>
  if("<%=System.Convert.ToString(Dcms.Utility.SessionHelper.Get("UserName"))%>"!=''){
   document.getElementById("morder").style.display="block";
   document.getElementById("mout").style.display="block";
   document.getElementById("minfo").style.display="block";
  }else{
   document.getElementById("mlog").style.display="block";
   document.getElementById("mreg").style.display="block";
   document.getElementById("mget").style.display="block";
  }
</script>