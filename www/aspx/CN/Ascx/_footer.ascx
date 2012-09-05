<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_footer.ascx.cs" Inherits="_footer_ascx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>

<div class="henx"></div>

<div class="ifoot">
  <div class="foot" style=" text-align:center"><a style="color:#606060" href="about.aspx?BaseinfoCateid=6&amp;Baseinfoid=6&amp;CateID=6">关于我们</a>&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;<a  style="color:#606060" href="link.aspx">友情链接</a>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;<a style="color:#606060" href="hzhb.aspx?newsCateID=26&amp;CateID=26">合作伙伴</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;<a style="color:#606060"  href="Contact.aspx">联系我们</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
  
  
<div id="bq" style=" text-align:center; color:#606060; padding-top:6px;"><Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Intro" FieldValue="" Children="0" PageSize="10" IsPage="False" Where="Cate_State='1' and #Cate_Id=gywm# " OrderBy="Cate_ID Desc">
	<ItemTemplate0><div style="width:1003px; text-align:center">{Dcms_Cate.Cate_Intro}</div></ItemTemplate0>
</Dcms:Drepeater>
</div></div>
  </div>
<div class="bjys"></div>
</BODY></HTML>