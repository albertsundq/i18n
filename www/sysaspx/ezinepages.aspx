<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ezinepages.aspx.cs" Inherits="_ezinepages_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<?xml version="1.0" encoding="UTF-8"?>
<content width="368" height="450" bgcolor="cccccc" loadercolor="ffffff" panelcolor="5d5d61" buttoncolor="5d5d61" textcolor="ffffff">
<Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="thisandallsub" SwitchDb="" PrimaryKey="Ezine_Id" TotalLayer="1" TableName="Dcms_Ezine" FieldName="Ezine_BigImage" FieldValue="" Children="0" PageSize="100" IsPage="False" Where="Ezine_State='1' and #Ezine_CateId={Get.CateId,1}# " OrderBy="Ezine_Order Desc">
	<ItemTemplate0><page src="{Dcms_Ezine.Ezine_BigImage}"/></ItemTemplate0>
</Dcms:Drepeater>

</content>