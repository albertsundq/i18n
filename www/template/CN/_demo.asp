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
<!--Repeater TableName="Dcms_BaseInfo" Where="BaseInfo_State='1' and #BaseInfo_CateId={Get.BaseInfoCateId,banner}# " OrderBy="BaseInfo_Id Desc" SqlType="select" PrimaryKey="BaseInfo_Id" SelectDir="this" PageSize="5" IsPage="False"-->
<!--Item-->
  <li><img src="{Dcms_BaseInfo.BaseInfo_Image}" width="748" height="453" /></li>
 <!--/Item-->
<!--/Repeater-->
</ul>
