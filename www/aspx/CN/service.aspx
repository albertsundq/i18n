<%@ Page Language="C#" AutoEventWireup="true" CodeFile="service.aspx.cs" Inherits="_service_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_footer.ascx" TagName="_footer" TagPrefix="Dcms" %>

<Dcms:_header ID="_header_0" runat="server" />

<div id="bannerabout" style="background:url(images/0011.jpg)">
  <div align="center">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="973" height="217">
  <param name="movie" value="images/lx.swf" />
  <param name="quality" value="high" />
  <param name="wmode" value="transparent" />
  <embed src="images/lx.swf" width="993" height="217" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
</object></div>
</div>




<div id="about">
<div class="ab">
<div id="tup1"><img src="images/service.GIF" /></div>
<ul class="slink" style=" background:url(images/about_24.gif)" >
<Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="sub" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Id,Cate_Title" FieldValue="" Children="0" PageSize="30" IsPage="False" Where="Cate_State='1' and #Cate_Id=xmsh# " OrderBy="Cate_ID asc">
                                          	<ItemTemplate0>      <li><a style="font-size: 14px" href="service.aspx?BaseinfoCateid={Dcms_Cate.Cate_Id}&Baseinfoid={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}"id="{Dcms_Cate.Cate_Id}" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/about_14.gif" / border="0">&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a> </li>      <div ><img src="images/about_18.gif" /></div>      </ItemTemplate0>
                                          </Dcms:Drepeater>

    </ul>
             
         

             
             
                                          
<div id="tup"><img src="images/about_25.gif" /></div>
<div id="tup" style="padding-top:13px;"><a href="join.aspx"><img src="images/hr.JPG" / border="0"></a></div>

<div id="tup" style="padding-top:13px;"><a href="Contact.aspx?BaseinfoCateid=31&amp;Baseinfoid=31&amp;CateID=31"><img src="images/contact.JPG" / border="0" /></a></a></div>
</div>


<div class="abo" style="line-height:23px">

<div id="abou">



<div id="dqwz"><Dcms:Drepeater ID="Repeater1" runat="server" SqlType="select|select" SelectDir="thisandallsub|this" SwitchDb="|" PrimaryKey="Cate_Id|Cate_Id" TotalLayer="2" TableName="Dcms_Cate|Dcms_Cate" FieldName="Cate_IdPath,Cate_Id,Cate_Title|Cate_IdPath,Cate_Id,Cate_Title" FieldValue="|" Children="1|0" PageSize="10|10" IsPage="False|False" Where="Cate_State='1' and Cate_Id={get.cateid,8} |Cate_State='1' and Cate_Id in(0{Dcms_Cate.Cate_IdPath}{Dcms_Cate.Cate_Id})" OrderBy="Cate_IdPath asc|Cate_IdPath asc">
	<ItemTemplate0>{ItemTemplate_1}</ItemTemplate0>
	<HeadTemplate1></HeadTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}</ItemTemplate1>
</Dcms:Drepeater>
</div>

</div>
<Dcms:Drepeater ID="Repeater2" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="BaseInfo_Id" TotalLayer="1" TableName="Dcms_BaseInfo" FieldName="BaseInfo_Content" FieldValue="" Children="0" PageSize="1" IsPage="False" Where="BaseInfo_State='1' and #BaseInfo_CateId={Get.BaseInfoCateId,xmsh}# " OrderBy="BaseInfo_Id Desc">
                          	<ItemTemplate0>                        <div id="1231" style="padding-left:16px">{Dcms_BaseInfo.BaseInfo_Content}</div>                        </ItemTemplate0>
                        </Dcms:Drepeater>
</div>
</div>

<Dcms:_footer ID="_footer_1" runat="server" />

