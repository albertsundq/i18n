<!-- #include file="_header.asp" -->
<div class="aboutus">
<div class="bannerabout">
<div class="abouttop">

<div class="abouttop1"style="padding-top:10px;"><!--Repeater TableName="Dcms_Cate" Where="Cate_State='1' and #Cate_Id=gywm#" OrderBy="Cate_IdPath asc" SqlType="select" PrimaryKey="Cate_Id" SelectDir="this" PageSize="1" IsPage="False"-->
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
<div class="dqwz1"><li style="padding-top:24px; padding-left:46px; color:#FFFFFF"><div class="sidebar2"><div class="abou">您当前位置: 客服中心  >   在线留言 </div></div>
</div>
<div class="cright">
                    
<div class="scontent" style="padding:0;">
      <div style="padding:0 20px;">
        <script language="javascript" type="text/javascript">
function message_OnSubmit() {
var err=0;
var Content=get("GuestBook_Title").value;
if(Content.length<1){get("ReqTitle").innerHTML="*必填";err=err+1;}else{get("ReqTitle").innerHTML="*"}
var Content=get("GuestBook_Content").value;
if(Content.length<1){get("ReqContent").innerHTML="*必填";err=err+1;}else{get("ReqContent").innerHTML="*"}
if(err>0){return false;}
}
</script>
        <form name="messageForm" method="post" action="/sysaspx/saveMessage.aspx" onSubmit="javascript:return message_OnSubmit(this);" id="messageForm">
          <input type="hidden" name="GuestBook_CateId" id="GuestBook_CateId" value="14" />
          <input type="hidden" name="successMessage" id="successMessage" value="感谢您的参与！" />
          <input type="hidden" name="successUrl" id="successUrl" value="/guestbook.aspx" />
          <input type="hidden" name="errorMessage" id="errorMessage" value="对不起，提交失败，请重试！" />
          <input type="hidden" name="errorCodeMessage" id="errorCodeMessage" value="对不起，您输入的验证码值不对，请重试！" />
          <!--Repeater TableName="Dcms_User" Where="User_Id={session.UserId,0}" OrderBy="User_Id Desc" SqlType="select" PrimaryKey="User_Id" SelectDir="this" PageSize="1" IsPage="False"-->
          <!--Item-->
          <input type="hidden" name="GuestBook_ExFlag1" id="GuestBook_ExFlag1" value="{Dcms_User.User_Id}" />
          <input type="hidden" name="GuestBook_UserName" id="GuestBook_UserName" value="{Dcms_User.User_Name}" />
          <input type="hidden" name="GuestBook_UserTel" id="GuestBook_UserTel" value="{Dcms_User.User_Tel}" />
          <input type="hidden" name="GuestBook_UserEmail" id="GuestBook_UserEmail" value="{Dcms_User.User_Email}" />
          <!--/Item-->
          <!--/Repeater-->
          <table cellspacing="0" cellpadding="0" class="systable" style="margin-top:0;">
            <tr>
              <td>标题</td>
              <td style="padding-left:15px;"><input type="text" class="fbinput" size="40" maxlength="20" name="GuestBook_Title" id="GuestBook_Title" value=""></td>
            </tr>
            <tr>
              <td>内容</td>
              <td style="padding-left:15px;">
                  <textarea name="GuestBook_Content" rows="4" cols="60" id="GuestBook_Content" class="tntextarea"></textarea>
                </td>
            </tr>
            <tr style=" display:none;">
              <td></td>
              <td><input type="hidden" class="fbinput" size="40" maxlength="20" name="GuestBook_UserName" id="GuestBook_UserName" value="__"></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td style="padding-left:20px;"><input type="submit"  class="button" value="确定" style="margin-top:5px;"/></td>
            </tr>
          </table>
        </form>
       <!--Repeater TableName="Dcms_GuestBook" Where="GuestBook_State='1' and #GuestBook_CateId=14# " OrderBy="GuestBook_Id Desc" SqlType="select" PrimaryKey="GuestBook_Id" SelectDir="this" PageSize="10" IsPage="True"-->
<!--Item-->
            <dl class="topic">
            	<dt>{Dcms_GuestBook.GuestBook_AddTime}</dt>
                <dd class="question">咨询内容：{Dcms_GuestBook.GuestBook_Content} </dd>
                <dd class="answer">{Dcms_GuestBook.GuestBook_ReplyContent} </dd>
            </dl>
   <!--/Item-->
<!--/Repeater-->   
<!-- #include file="_page.asp" --> 
      </div>
        	
        </div>
                  </div></div>

<!-- #include file="_footer.asp" -->