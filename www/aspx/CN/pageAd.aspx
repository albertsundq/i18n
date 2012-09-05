<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageAd.aspx.cs" Inherits="_pageAd_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<?xml version='1.0' encoding='utf-8'?>
<imgList>
<pic>

<Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="BaseInfo_Id" TotalLayer="1" TableName="Dcms_BaseInfo" FieldName="BaseInfo_Image,BaseInfo_ExFlag1,BaseInfo_Content" FieldValue="" Children="0" PageSize="10" IsPage="False" Where="BaseInfo_State='1' and #BaseInfo_CateId=banner1# " OrderBy="BaseInfo_Id Desc">
	<ItemTemplate0>  <list path="{Dcms_BaseInfo.BaseInfo_Image}" smallpath="{Dcms_BaseInfo.BaseInfo_ExFlag1}" smallinfo="">{Dcms_BaseInfo.BaseInfo_Content} </list></ItemTemplate0>
</Dcms:Drepeater>




</pic>
<rollTime fade_in="10">4</rollTime>
<text font="黑体" size="12" bold="true" color="0xfffffff"></text>
</imgList>
