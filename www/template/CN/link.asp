<!-- #include file="_header.asp" -->
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=yqlg#" OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="this" PageSize="1" IsPage="False"-->
<!--Item-->
<b>{Dcms_Cate.Cate_Title}</b>
<!--/Item-->
<!--/Repeater--></div>

<div class="aboutleft"><ul class="slink" >
 <!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=gywm# " OrderBy="Cate_Order Desc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="sub" PageSize="100" IsPage="False"-->
          <!--Item-->
          <li style="line-height:24px; padding-top:3px;"><a href="about.aspx?BaseinfoCateid={Dcms_Cate.Cate_Id}&Baseinfoid={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}"id="{Dcms_Cate.Cate_Id}" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a></li>
          

          <!--/Item-->
          <!--/Repeater-->	
          <li style="line-height:24px; padding-top:3px;"><a href="link.aspx?BaseinfoCateid={Dcms_Cate.Cate_Id}&Baseinfoid={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}"id="{Dcms_Cate.Cate_Id}" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;友情链接</a></li>
 
    </ul></div><div class="mess" style="clear:both;"><a href="guestbook.aspx"><img src="images/about_18.gif" / border="0"></a></div>
    
</div>




</div>

<div class="aboutright"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="693" height="238">
    <param name="movie" value="flash/banner.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="transparent" />
    <embed src="flash/banner.swf" width="693" height="238" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
  </object>
  
  </div>

</div>
<div class="dqwz">
<div class="dqwz1"><li style="padding-top:24px; padding-left:46px; color:#FFFFFF">您当前位置：友情链接  -  详细信息  -   
</li></div>
<div class="gywm" style="line-height:26px;"><!--Repeater TableName="Dcms_Link" Where="Link_State='1' and #Link_CateId={Get.LinkCateId,yqlg}# " OrderBy="Link_Id Desc" SqlType="select" PrimaryKey="Link_Id" SelectDir="this" PageSize="25" IsPage="False"-->
<!--Item-->
<li style="width:126px; padding-top:4px; padding-left:12px;; color: #FFFFFF"><a style="color:#000000" href="{Dcms_Link.Link_Url}"  target="_blank">{Dcms_Link.Link_Title}</a></li>

<!--/Item-->
<!--/Repeater-->
</div></div>

<!-- #include file="_footer.asp" -->

