<%@ Page Language="C#" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="_products_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_page.ascx" TagName="_page" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_footer.ascx" TagName="_footer" TagPrefix="Dcms" %>
<Dcms:_header ID="_header_0" runat="server" />
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Title" FieldValue="" Children="0" PageSize="1" IsPage="False" Where="Cate_State='1' and #Cate_Id=cpzs#" OrderBy="Cate_IdPath asc">
	<ItemTemplate0><b>{Dcms_Cate.Cate_Title}</b></ItemTemplate0>
</Dcms:Drepeater>
</div>

<div class="aboutleft"><ul class="slink" >
 <Dcms:Drepeater ID="Repeater1" runat="server" SqlType="select" SelectDir="sub" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Id,Cate_Title" FieldValue="" Children="0" PageSize="30" IsPage="False" Where="Cate_State='1' and #Cate_Id=cpzs# " OrderBy="Cate_ID asc">
        	<ItemTemplate0>      <li style="line-height:24px; padding-top:3px;"><a  href="Products.aspx?ProductsCateID={Dcms_Cate.Cate_Id}&amp;CateID={Dcms_Cate.Cate_Id}&amp;CurrCateID={Dcms_Cate.Cate_Id}" id="{Dcms_Cate.Cate_Id}">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a> </li>      </ItemTemplate0>
                                          </Dcms:Drepeater>

          
 
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
<div class="dqwz1"><li style="padding-top:24px; padding-left:46px; color:#FFFFFF"><Dcms:Drepeater ID="Repeater2" runat="server" SqlType="select|select" SelectDir="thisandallsub|this" SwitchDb="|" PrimaryKey="Cate_Id|Cate_Id" TotalLayer="2" TableName="Dcms_Cate|Dcms_Cate" FieldName="Cate_IdPath,Cate_Id,Cate_Title|Cate_IdPath,Cate_Id,Cate_Title" FieldValue="|" Children="1|0" PageSize="10|10" IsPage="False|False" Where="Cate_State='1' and Cate_Id={get.cateid,8} |Cate_State='1' and Cate_Id in(0{Dcms_Cate.Cate_IdPath}{Dcms_Cate.Cate_Id})" OrderBy="Cate_IdPath asc|Cate_IdPath asc">
	<ItemTemplate0>{ItemTemplate_1}</ItemTemplate0>
	<HeadTemplate1>您当前位置：</HeadTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}&nbsp;&nbsp;-&nbsp;&nbsp;</ItemTemplate1>
	<ItemTemplate1>{Dcms_Cate.Cate_Title}</ItemTemplate1>
</Dcms:Drepeater>
</li></div>
<div class="cright" >
        <div class="scontent">
    	<ul class="prolist">
        	<Dcms:Drepeater ID="Repeater3" runat="server" SqlType="select" SelectDir="thisandallsub" SwitchDb="" PrimaryKey="Products_Id" TotalLayer="1" TableName="Dcms_Products" FieldName="Products_CateID,Products_ID,Products_MinImage,Products_Title" FieldValue="" Children="0" PageSize="12" IsPage="True" Where="#Products_CateID={Get.ProductsCateID,chanpinzhongxin}#  " OrderBy="Products_AddTime Desc">
        	<ItemTemplate0>        <li style="text-align:left;"><a class="home5" href="Productsde.aspx?ProductsCateID={Dcms_Products.Products_CateID}&CateID={Dcms_Products.Products_CateID}&ProductsID={Dcms_Products.Products_ID}" ><img src="{Dcms_Products.Products_MinImage} " width="178" height="166"  border="0"/></a>         <b  style="width:178px; padding-left:1px;"><font color="#1374BA"> {Dcms_Products.Products_Title} </font></b>         <a  class="home88" style="margin-top:6px;"href= "Productsde.aspx?ProductsCateID={Dcms_Products.Products_CateID}&CateID={Dcms_Products.Products_CateID}&ProductsID={Dcms_Products.Products_ID}" ><img src="images/gif-0104.gif" width="58" height="19" / border="0"></a>              </li>                 </ItemTemplate0>
        </Dcms:Drepeater>
  
        </ul>
         <Dcms:_page ID="_page_1" runat="server" />     
    </div>
    </div></div>

<Dcms:_footer ID="_footer_2" runat="server" />