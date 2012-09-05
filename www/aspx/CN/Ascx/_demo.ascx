<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_demo.ascx.cs" Inherits="_demo_ascx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/jquery.innerfade.js"></script>
<script type="text/javascript">
	   $(document).ready(
				function(){
					$('#news').innerfade({
						animationtype: 'slide',
						speed: 748,
						timeout: 2000,
						type: 'random',
						containerheight: '1em'
					});
					
					$('ul#portfolio').innerfade({
						speed: 1000,
						timeout: 5000,
						type: 'sequence',
						containerheight: '220px'
					});
					
					$('.fade').innerfade({
						speed: 1000,
						timeout: 6000,
						type: 'random_start',
						containerheight: '1.5em'
					});
					
					$('.adi').innerfade({
						speed: 'slow',
						timeout: 5000,
						type: 'random',
						containerheight: '150px'
					});

			});
  	</script>
<style>
	ul#portfolio li img{
}
	</style>
<ul id="portfolio" style="position:absolute;">
<Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="BaseInfo_Id" TotalLayer="1" TableName="Dcms_BaseInfo" FieldName="BaseInfo_Image" FieldValue="" Children="0" PageSize="5" IsPage="False" Where="BaseInfo_State='1' and #BaseInfo_CateId={Get.BaseInfoCateId,banner}# " OrderBy="BaseInfo_Id Desc">
	<ItemTemplate0>  <li><img src="{Dcms_BaseInfo.BaseInfo_Image}" width="748" height="453" /></li> </ItemTemplate0>
</Dcms:Drepeater>

</ul>
