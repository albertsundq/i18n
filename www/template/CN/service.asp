
<!-- #include file="_header.asp" -->

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
<!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=xmsh# " OrderBy="Cate_ID asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="sub" PageSize="30" IsPage="False"-->
                                          <!--Item-->
      <li><a style="font-size: 14px" href="service.aspx?BaseinfoCateid={Dcms_Cate.Cate_Id}&Baseinfoid={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}"id="{Dcms_Cate.Cate_Id}" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/about_14.gif" / border="0">&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a> </li>
      <div ><img src="images/about_18.gif" /></div>
      
<!--/Item-->
                                          <!--/Repeater-->
    </ul>
             
         

             
             
                                          
<div id="tup"><img src="images/about_25.gif" /></div>
<div id="tup" style="padding-top:13px;"><a href="join.aspx"><img src="images/hr.JPG" / border="0"></a></div>

<div id="tup" style="padding-top:13px;"><a href="Contact.aspx?BaseinfoCateid=31&amp;Baseinfoid=31&amp;CateID=31"><img src="images/contact.JPG" / border="0" /></a></a></div>
</div>


<div class="abo" style="line-height:23px">

<div id="abou">



<div id="dqwz"><!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and Cate_Id={get.cateid,8} " OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="thisandallsub" PageSize="10" IsPage="False"-->
<!--Item-->
<!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and Cate_Id in(0{Dcms_Cate.Cate_IdPath}{Dcms_Cate.Cate_Id})" OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="this" PageSize="10" IsPage="False"-->
<!--head-->

<!--/head-->
<!--Item-->
{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;
<!--/Item-->
<!--Item-->
{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;
<!--/Item-->
<!--Item-->
{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;
<!--/Item-->
<!--Item-->
{Dcms_Cate.Cate_Title}
<!--/Item-->
<!--/Repeater-->
<!--/Item-->
<!--/Repeater--></div>

</div>
<!--Repeater TableName="Dcms_BaseInfo" Where="BaseInfo_State='1' and #BaseInfo_CateId={Get.BaseInfoCateId,xmsh}# " OrderBy="BaseInfo_Id Desc" SqlType="select" PrimaryKey="BaseInfo_Id" SelectDir="this" PageSize="1" IsPage="False"-->
                          <!--Item-->
                        <div id="1231" style="padding-left:16px">{Dcms_BaseInfo.BaseInfo_Content}</div>
                        <!--/Item-->
                        <!--/Repeater--></div>
</div>

<!-- #include file="_footer.asp" -->

