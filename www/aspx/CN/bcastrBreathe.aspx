<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bcastrBreathe.aspx.cs" Inherits="_bcastrBreathe_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<?xml version="1.0" encoding="utf-8"?>
<data>
	<channel>
      <Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="BaseInfo_Id" TotalLayer="1" TableName="Dcms_BaseInfo" FieldName="BaseInfo_ExFlag1,BaseInfo_Image,BaseInfo_Title" FieldValue="" Children="0" PageSize="3" IsPage="False" Where="BaseInfo_State='1' and #BaseInfo_CateId=sytpxw# " OrderBy="BaseInfo_Id Desc">
    	<ItemTemplate0> <item><link>{Dcms_BaseInfo.BaseInfo_ExFlag1}</link><image>{Dcms_BaseInfo.BaseInfo_Image}</image><title>{Dcms_BaseInfo.BaseInfo_Title}</title></item> </ItemTemplate0>
</Dcms:Drepeater>
  
<item>
			<link>{Dcms_BaseInfo.BaseInfo_ExFlag1}</link>
			<image>images/npic.jpg</image>
			<title>{Dcms_BaseInfo.BaseInfo_Title}</title>
		</item>      
	</channel>
	<config>
		<autoPlayTime>8</autoPlayTime>
		<transform>breathe</transform>
	</config>
</data>