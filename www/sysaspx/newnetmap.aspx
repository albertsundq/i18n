<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newnetmap.aspx.cs" Inherits="_newnetmap_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<?xml version="1.0" encoding="utf-8"?>
<root>
<Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select|select" SelectDir="this|this" SwitchDb="|" PrimaryKey="Province_Id|SaleNet_Id" TotalLayer="2" TableName="Dcms_Province|Dcms_SaleNet" FieldName="Province_Title,Province_IsCenter|SaleNet_Title,SaleNet_Content" FieldValue="|" Children="1|0" PageSize="1000|1000" IsPage="False|False" Where="|SaleNet_State='1' and SaleNet_CateId={get.cateid,2} and SaleNet_Province='{Dcms_Province.Province_Title}'" OrderBy="Province_Id Desc|SaleNet_Id Desc">
	<ItemTemplate0><provinces pname="{Dcms_Province.Province_Title}" isCenter="{Dcms_Province.Province_IsCenter}">{ItemTemplate_1}</provinces></ItemTemplate0>
	<ItemTemplate1><city cname="{Dcms_SaleNet.SaleNet_Title}"><![CDATA[{Dcms_SaleNet.SaleNet_Content}]]></city></ItemTemplate1>
</Dcms:Drepeater>
</root>