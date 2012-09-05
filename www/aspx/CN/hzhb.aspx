<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hzhb.aspx.cs" Inherits="_hzhb_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_page.ascx" TagName="_page" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_footer.ascx" TagName="_footer" TagPrefix="Dcms" %>
<Dcms:_header ID="_header_0" runat="server" />
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><Dcms:Drepeater ID="Repeater0" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Title" FieldValue="" Children="0" PageSize="1" IsPage="False" Where="Cate_State='1' and #Cate_Id=hzhb#" OrderBy="Cate_IdPath asc">
	<ItemTemplate0><b>{Dcms_Cate.Cate_Title}</b></ItemTemplate0>
</Dcms:Drepeater>
</div>

<div class="aboutleft"><ul class="slink" >

<Dcms:Drepeater ID="Repeater1" runat="server" SqlType="select" SelectDir="sub" SwitchDb="" PrimaryKey="Cate_Id" TotalLayer="1" TableName="Dcms_Cate" FieldName="Cate_Id,Cate_Title" FieldValue="" Children="0" PageSize="10" IsPage="False" Where="Cate_State='1' and #Cate_Id=hzhb# " OrderBy="Cate_Id asc">
  	<ItemTemplate0>               <li style="line-height:24px; padding-top:3px;"><a  href="hzhb.aspx?newsCateID={Dcms_Cate.Cate_Id}&CateID={Dcms_Cate.Cate_Id}" id="{Dcms_Cate.Cate_Id}">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Dcms_Cate.Cate_Title}</a> </li>          </ItemTemplate0>
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
<ul class="news" style="padding-top:12px">
                        
  <Dcms:Drepeater ID="Repeater3" runat="server" SqlType="select" SelectDir="this" SwitchDb="" PrimaryKey="News_Id" TotalLayer="1" TableName="Dcms_News" FieldName="News_AddTime,News_CateId,News_Id,News_Title" FieldValue="" Children="0" PageSize="12" IsPage="True" Where="News_State='1' and #News_CateId={Get.NewsCateId,news}# " OrderBy="News_AddTime Desc">
                        	<ItemTemplate0>                        <li><span>{Dcms_News.News_AddTime,yyyy-MM-dd}</span><a class="home2"  href="hzhbde.aspx?newsCateID={Dcms_News.News_CateId}&CateID={Dcms_News.News_CateId}&NewsID={Dcms_News.News_Id}">{Dcms_News.News_Title}</a></li>                      </ItemTemplate0>
                        </Dcms:Drepeater>
 


        </ul>
         <Dcms:_page ID="_page_1" runat="server" />     </div>

<Dcms:_footer ID="_footer_2" runat="server" />



