<!-- #include file="_header.asp" -->
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=cpzs#" OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="this" PageSize="1" IsPage="False"-->
<!--Item-->
<b>{Dcms_Cate.Cate_Title}</b>
<!--/Item-->
<!--/Repeater--></div>

<div class="aboutleft"><ul class="slink" >
 <!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=cpzs# " OrderBy="Cate_ID asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="sub" PageSize="30" IsPage="False"-->
        <!--Item-->
      <li style="line-height:24px; padding-top:3px;"><a  href="Products.aspx?ProductsCateID={Dcms_Cate.Cate_Id}&amp;CateID={Dcms_Cate.Cate_Id}&amp;CurrCateID={Dcms_Cate.Cate_Id}" id="{Dcms_Cate.Cate_Id}">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a> </li>

      
<!--/Item-->
                                          <!--/Repeater-->
          
 
    </ul></div><div class="mess" style="clear:both;"><a href="guestbook.aspx"><img src="images/about_18.gif" / border="0"></a></div>
    
</div>




</div>

<div class="aboutright">
  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="693" height="238">
    <param name="movie" value="flash/banner.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="transparent" />
    <embed src="flash/banner.swf" width="693" height="238" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
  </object>
  </div>

</div>
<div class="dqwz">
<div class="dqwz1"><li style="padding-top:24px; padding-left:46px; color:#FFFFFF"><!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and Cate_Id={get.cateid,8} " OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="thisandallsub" PageSize="10" IsPage="False"-->
<!--Item-->
<!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and Cate_Id in(0{Dcms_Cate.Cate_IdPath}{Dcms_Cate.Cate_Id})" OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="this" PageSize="10" IsPage="False"-->
<!--head-->
您当前位置：
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
<!--/Repeater--></li></div>
<div class="cright" >
        <div class="scontent">
    	<ul class="prolist">
        	<!--Repeater TableName="Dcms_Products" Where="#Products_CateID={Get.ProductsCateID,chanpinzhongxin}#  " OrderBy="Products_AddTime Desc" SqlType="select" PrimaryKey="Products_Id" SelectDir="thisandallsub" PageSize="12" IsPage="True"-->
        <!--Item-->
        <li style="text-align:left;"><a class="home5" href="Productsde.aspx?ProductsCateID={Dcms_Products.Products_CateID}&CateID={Dcms_Products.Products_CateID}&ProductsID={Dcms_Products.Products_ID}" ><img src="{Dcms_Products.Products_MinImage} " width="178" height="166"  border="0"/></a>
         <b  style="width:178px; padding-left:1px;"><font color="#1374BA"> {Dcms_Products.Products_Title} </font></b>
         <a  class="home88" style="margin-top:6px;"href= "Productsde.aspx?ProductsCateID={Dcms_Products.Products_CateID}&CateID={Dcms_Products.Products_CateID}&ProductsID={Dcms_Products.Products_ID}" ><img src="images/gif-0104.gif" width="58" height="19" / border="0"></a>              </li>
         
        <!--/Item-->
        <!--/Repeater-->  
        </ul>
         <!-- #include file="_page.asp" -->     
    </div>
    </div></div>

<!-- #include file="_footer.asp" -->