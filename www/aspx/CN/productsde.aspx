<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productsde.aspx.cs" Inherits="_productsde_aspx" EnableViewState="false" %>
<%@ Register Assembly="Dcms.Controls" Namespace="Dcms.Controls" TagPrefix="Dcms" %>
<%@ Register Src="Ascx/_header.ascx" TagName="_header" TagPrefix="Dcms" %>
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
<div class="cright">

        <div class="scontent">
    	 <Dcms:Drepeater ID="Repeater3" runat="server" SqlType="select|select" SelectDir="this|this" SwitchDb="|" PrimaryKey="Products_Id|User_Id" TotalLayer="2" TableName="Dcms_Products|Dcms_User" FieldName="Products_BigImage,Products_Title,Products_Introduction,Products_CodeName,Products_ID|User_RealName,User_Email,User_Tel,User_IM,User_Address" FieldValue="|" Children="1|0" PageSize="1|1" IsPage="False|false" Where="Products_State='1' and #Products_ID={Get.ProductsID,products}# |User_Id={session.UserId,0}" OrderBy="Products_Id Desc|">
	<ItemTemplate0>                    <div style=" text-align:center; padding:0px; ">                    <img src="{Dcms_Products.Products_BigImage}" width="658">                    </div>                      <p style="text-align:center; font-size:14px; color:#004892; line-height:0px;">{Dcms_Products.Products_Title} </p>                        <div>{Dcms_Products.Products_Introduction} </div>                        <script language="javascript" type="text/javascript">                         function message_OnSubmit() {  var User_Address=document.getElementById("User_Address").value;                          if(User_Address.length<1){alert("请填写购买数量!");return false;}                         }                        </script><form name="messageForm" method="post" action="/sysaspx/saveMessage.aspx" onsubmit="javascript:return message_OnSubmit(this);" id="messageForm">  <input type="hidden" name="GuestBook_CateId" id="GuestBook_CateId" value="21" />  <input type="hidden" name="successMessage" id="successMessage" value="提交成功！" />  <input type="hidden" name="successUrl" id="successUrl" value="/products.aspx?ProductsCateID=10&CateID=10&CurrCateID=10" />  <input type="hidden" name="errorMessage" id="errorMessage" value="对不起，提交失败，请重试！" />  <input type="hidden" name="errorCodeMessage" id="errorCodeMessage" value="对不起，您输入的验证码值不对，请重试！" />  <input type="hidden" id="GuestBook_Title" name="GuestBook_Title" value="{Dcms_Products.Products_Title}" />  <input type="hidden" id="GuestBook_ExFlag3" name="GuestBook_ExFlag3" value="{Dcms_Products.Products_CodeName}" />  <input type="hidden" id="GuestBook_ExFlag4" name="GuestBook_ExFlag4" value="{Dcms_Products.Products_ID}" />  {ItemTemplate_1}  <table cellspacing=1 cellpadding=0 width="98%" align=center border=0>    <tr >      <td align=center width="20%">购买数量：</td>      <td align=left width="80%" height=25>&nbsp;        <input name="GuestBook_ExFlag1" type="text" id="GuestBook_ExFlag1" style="width:100px;" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />        <span id="ReqTitle" style="color:Red;">*</span></td>    </tr>        <tr >      <td colspan="2" height="30" valign="center" style="padding-left:30px;"><input type="submit" value=" 确定 " id="subs" style="display:none" /><input type="button" value=" 确定 " id="btns" onclick="alert('请先登录！')" style="display:none" />        <input type="reset" value=" 重填 " /></td>    </tr>  </table></form>                    </ItemTemplate0>
	<ItemTemplate1>  <input type="hidden" id="GuestBook_UserName" name="GuestBook_UserName" value="{Dcms_User.User_RealName}" />  <input type="hidden" id="GuestBook_UserEmail" name="GuestBook_UserEmail" value="{Dcms_User.User_Email} " />  <input type="hidden" id="GuestBook_UserTel" name="GuestBook_UserTel" value="{Dcms_User.User_Tel} " />  <input type="hidden" id="GuestBook_UserIM" name="GuestBook_UserIM" value="{Dcms_User.User_IM} " />  <input type="hidden" id="GuestBook_ExFlag2" name="GuestBook_ExFlag2" value="{Dcms_User.User_Address} " /></ItemTemplate1>
</Dcms:Drepeater>

    <script>
    var sessionname='<%=System.Convert.ToString(Dcms.Utility.SessionHelper.Get("UserName"))%>';
    if(sessionname==''){
     document.getElementById("btns").style.display="block";
	}else{
	 document.getElementById("subs").style.display="block";
	}
    </script>
    </div>
    </div></div>

<Dcms:_footer ID="_footer_1" runat="server" />