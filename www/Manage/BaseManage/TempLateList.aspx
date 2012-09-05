<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TempLateList.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_TempLateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>模板管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Green/Css/module.css" type="text/css" media="all" />

    <script type="text/javascript" src="../Green/Js/jquery.js"></script>

    <!--调用表格样式开始-->

    <script type="text/javascript" src="../Green/grid/flexigrid.js"></script>

    <link rel="stylesheet" href="../Green/grid/flexigrid.css" type="text/css" media="all" />
    <!--调用表格样式结束-->
</head>
<body>
    <div style="width: 100%;clear: both;" id="contentBorder">
        <table width="100%" align="center" border="0" style="margin-bottom: 5px;" cellspacing="0"
            cellpadding="0">
            <tr>
                <td style="background: url(../Green/Images/content_title_bg03.gif) repeat-x;" width="40" height="37">&nbsp;
                    
                </td>
                <td style="background: url(../Green/Images/content_title_bg02.gif) repeat-x; color: #437572;font-size: 12px; font-weight: bold;">
                    您现在的位置是：系统管理>模板管理
                </td>
                <td style="background: url(../Green/Images/content_title_bg01.gif) repeat-x; width: 158px;color: #ff6633" align="right">
                    <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;
                </td>
            </tr>
        </table>
        <form runat="server" style="margin-top:6px;padding:0px;">
        <table width="100%" align="center" border="0"  style="border:1px solid #c8dcc4;margin-bottom:5px;" cellspacing="0" cellpadding="0">
            <tr class="tdtitle">
              <td align="left" height="26" style="padding-left:20px;">模板名称</td>
              <td align="left">技术支持</td>
              <td align="left">创建时间</td>
              <td align="center">操作选项</td>
            </tr>
            <asp:Repeater ID="repAdmin" runat="server" OnItemCommand="repAdmin_ItemCommand">
              <ItemTemplate>
                <tr style="background: #F2F2F2;">
                <%--<td align="left" height="26" style="padding-left:20px;"><asp:Label ID="LabTempName" Visible="false" runat="server" Text='<%#Eval("Template_Name")%>'></asp:Label><a href="#?Path=<%# ValidTempFilePath(Eval("Template_Directory").ToString())%>"><%#Eval("Template_Name")%></a></td>--%>
                  <td align="left" height="26" style="padding-left:20px;"><asp:Label ID="LabTempName" Visible="false" runat="server" Text='<%#Eval("Template_Name")%>'></asp:Label><a href="#" onclick="setTemplate('<%#Eval("Template_Name")%>')"><%#Eval("Template_Name")%></a></td>
                  <%--<td align="left" height="26" style="padding-left:20px;"><asp:Label ID="LabTempName" Visible="false" runat="server" Text='<%#Eval("Template_Name")%>'></asp:Label><a href="#?Path=<%# ValidTempFilePath(Eval("Template_Directory").ToString())%>"><%#Eval("Template_Name")%></a></td>--%>
                  <td align="left"><%#Eval("Template_Author")%></td>
                  <td align="left"><%#Eval("Template_CreateTime")%></td>
                  <td align="center">
                   <asp:LinkButton ID="LinkUpdate" runat="server" CommandName="Create" CommandArgument='<%#Eval("Template_Name")%>'>部分生成</asp:LinkButton>&nbsp;|
                   <asp:LinkButton ID="LinkUpdateAll" runat="server" CommandName="CreateAll" CommandArgument='<%#Eval("Template_Name")%>'>全部生成</asp:LinkButton> |&nbsp;
                  <%-- <asp:LinkButton ID="ChangeCode" runat="server" CommandName="ChangeWebCode" CommandArgument='<%#Eval("Template_Name")%>'>统一编码</asp:LinkButton> |&nbsp;
                   <asp:LinkButton ID="From2To3" runat="server" CommandName="From2To3" CommandArgument='<%#Eval("Template_Name")%>'>2.0转换为3.0</asp:LinkButton>  --%>
                  </td>
                </tr>
              </ItemTemplate>
              <AlternatingItemTemplate>
                 <tr>
                  <td align="left" height="26" style="padding-left:20px;"><asp:Label ID="LabTempName" Visible="false" runat="server" Text='<%#Eval("Template_Name")%>'></asp:Label><a href="#" onclick="setTemplate('<%#Eval("Template_Name")%>')"><%#Eval("Template_Name")%></a></td>
                  <td align="left"><%#Eval("Template_Author")%></td>
                  <td align="left"><%#Eval("Template_CreateTime")%></td>
                  <td align="center">
                   <asp:LinkButton ID="LinkUpdate" runat="server" CommandName="Create" CommandArgument='<%#Eval("Template_Name")%>'>部分生成</asp:LinkButton>&nbsp;|
                   <asp:LinkButton ID="LinkUpdateAll" runat="server" CommandName="CreateAll" CommandArgument='<%#Eval("Template_Name")%>'>全部生成</asp:LinkButton> |&nbsp;
                   <%--<asp:LinkButton ID="ChangeCode" runat="server" CommandName="ChangeWebCode" CommandArgument='<%#Eval("Template_Name")%>'>统一编码</asp:LinkButton> |&nbsp;
                   <asp:LinkButton ID="From2To3" runat="server" CommandName="From2To3" CommandArgument='<%#Eval("Template_Name")%>'>2.0转换为3.0</asp:LinkButton>--%> 
                  </td>
                </tr>   
              </AlternatingItemTemplate>
            </asp:Repeater>
          </table>
          <asp:Literal ID="lit_CheckInfo" runat="server"></asp:Literal>
          </form>
    </div>
    <div id="SetTemplate" style="display:none"></div>
    <script type="text/javascript">
        function setTemplate(path)
        {
            
            $("#SetTemplate").html("<span id='url0' dataType='iframe' dataLink='../BaseManage/TemplatePath_List.aspx?path="+path+"'>"+path+"</span>");
		                    parent.dcmstab.buildChildTab(document.getElementById("url0"));
			                $("#SetTemplate").html("");
	    }
    </script>
</body>
</html>
