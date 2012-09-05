<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_List.aspx.cs" Inherits="Manage.BaseManage.Manage_BaseManage_Admin_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统用户</title>
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
                    您现在的位置是：系统管理>系统用户管理
                </td>
                <td style="background: url(../Green/Images/content_title_bg01.gif) repeat-x; width: 158px;color: #ff6633" align="right">
                    <script type="text/javascript" src="../Green/Js/insertqmenu.js"></script>&nbsp;
                </td>
            </tr>
        </table>
        <table id="flex1" style="display: none;">
        </table>

        <script type="text/javascript">
            var contentW = $("#contentBorder").width();
            $("#contentBorder").width(contentW - 20);
        </script>

        <script type="text/javascript">
            function griddblclick(oRow) {
                //colId:用户ID号
                var colId = oRow.cells[0].childNodes[0].innerHTML;
                UpdateShow(colId);
            }

            function UpdateShow(colId) {
                var oDialog = parent.dcmsDialogJson({
                    title: (typeof (colId) != 'undefined') ? '系统用户 - 编辑' : '系统用户 - 创建',
                    content: function(body) {
                        body.html($("#DivDialog").html());
                        if (typeof (colId) != 'undefined') {
                            //返回Json格式数据记录
                            $.getJSON("Admin_Manage.aspx?action=getone&time=" + Math.random() + "&id=" + colId, function(json) {
                                $.each(json, function(i) {
                                    //alert(json[i].Admin_Name);
                                    $("#Admin_Name", body).val(json[i].Admin_Name);
                                    $("#Admin_Email", body).val(json[i].Admin_Email);
                                    $("#Admin_RoleId", body).val(json[i].Admin_RoleId);
                                    $("#Admin_Id", body).val(json[i].Admin_Id);
                                    $("#action", body).val("update");
                                })
                            });
                        }
                        else {
                            $("#action", body).val("insert");
                        }

                    },
                    data: "",
                    okEvent: function() {
                        var body = arguments[1].body;
                        if ($.trim($('#Admin_Name', body).val()) == '') {
                            alert('请填写用户名！');
                            $('#Admin_Name', body).focus();
                            return false;
                        }
                        if ($('#Admin_Email', body).val() == '') {
                            alert('请填写用户邮箱！');
                            $('#Admin_Email', body).focus();
                            return false;
                        }
                        if ($('#Admin_Pwd', body).val() == '' && $('#action', body).val() == 'insert') {
                            alert('请填写用户密码！');
                            $('#Admin_Pwd', body).focus();
                            return false;
                        }
                        if ($('#Admin_RoleId', body).val() == '') {
                            alert('请选择用户组别！');
                            $('#Admin_RoleId', body).focus();
                            return false;
                        }

                        return UpdateSubmit(body);
                    }
                });
            }

            //批量删除
            function deleteCheck(IdStr) {
                var data = $.ajax({
                    url: "Admin_Manage.aspx?action=delete&id=" + IdStr,
                    async: false
                }).responseText;
                //$.get("Admin_Manage.aspx?action=delete&id=" + IdStr, function(data) {
                if (data == "true") {
                    $(".pReload").click();
                    return true;
                }
                else {
                    alert('删除错误！');
                    return false;
                }
                //});
            }
            //ajax数据提交
            function UpdateSubmit(body) {
                $.ajax({
                    type: "post",
                    url: "Admin_Manage.aspx?action=" + $("#action", body).val(),
                    data: 'Admin_Name=' + $("#Admin_Name", body).val() + '&Admin_Pwd=' + $("#Admin_Pwd", body).val() + '&Admin_Email=' + $("#Admin_Email", body).val() + '&Admin_RoleId=' + $("#Admin_RoleId", body).val() + '&Admin_Id=' + $("#Admin_Id", body).val() + '',
                    beforeSend: function(XMLHttpRequest) {
                        //ShowLoading();
                    },
                    success: function(data, textStatus) {
                       
                        if (data == "true") {
                            $(".pReload").click();
                            parent.$.fn.hideJmodal();
                        }
                        if(data=="userexist")
                        {
                            alert("已存在相同用户名！");
                            return false;
                        }
                    },
                    complete: function(XMLHttpRequest, textStatus) {
                        //HideLoading();
                    },
                    error: function() {
                        parent.dcmsDialog("处理失败", "你提交的数据处理失败，请检查数据是否合法！");
                    }
                });
            }

            //列表初始化
            $("#flex1").flexigrid
			(
			{
			    url: 'Admin_Manage.aspx?action=select',
			    dataType: 'json',
			    colModel: [
				{ display: 'ID编号', name: 'Admin_Id', width: '80', sortable: false, align: 'center' },
				{ display: '用户名称', name: 'Admin_Name', width: $("#contentBorder").width()-690, sortable: false, align: 'center' },
				{ display: '用户邮箱', name: 'Admin_Email', width: '120', sortable: false, align: 'center' },
				{ display: '登录次数', name: 'Admin_LoginTimes', width: '80', sortable: false, align: 'center' },
				{ display: '最后登录', name: 'Admin_LastTime', width: '120', sortable: false, align: 'center' },
				{ display: '登录Ip', name: 'Admin_LastIp', width: '100', sortable: false, align: 'center' },
				{ display: '用户组别', name: 'Admin_RoleId', width: '100', sortable: false, align: 'center' }
				],
			    buttons: [
				{ name: '创建用户', bclass: 'add', onpress: test },
				{ name: '批量删除', bclass: 'delete', onpress: test }
				],
			    searchitems: [
				{ display: '用户名称', name: 'Admin_Name', isdefault: true }
				],
			    sortname: "Admin_Id",
			    sortorder: "desc",
			    usepager: true,
			    title: '系统用户列表',
			    useRp: true,
			    rp: 10,
			    procmsg: '正在请求数据，请稍候...',
			    showTableToggleBtn: true,
			    width: $("#contentBorder").width() - 1,
			    nohresize: true,
			    //限定單選
			    singleSelect: true
			}
			);
            function test(com, grid) {
                if (com == '批量删除') {
                    parent.dcmsDialog("确认删除", "确认删除选中的数据?一旦删除将无法恢复!", function() {
                        var IdStr = "";
                        $('.trSelected', grid).each(function(index, domEle) { IdStr = IdStr + "," + $(domEle).children().eq(0).text(); });
                        return deleteCheck(IdStr);
                    })

                }
                else if (com == '创建用户') {
                    UpdateShow();
                }
            }


            $('b.top').click(function() {
                $(this).parent().toggleClass('fh');
            });
         
        </script>

        <div id="DivDialog" style="display: none;">
            <input type="hidden" id="Admin_Id" value="0" />
            <input type="hidden" id="action" value="insert" />
            <table width="100%" border="0" style="margin-bottom: 5px; font-size: 12px; font-weight: bold;"
                height="80" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height:25px;" width="120" align="center">
                        用户名称：
                    </td>
                    <td width="220">
                        <input type="text" size="20" style="width: 200px" id="Admin_Name"  />
                    </td>
                </tr>
                <tr>
                    <td style="height:25px;" align="center">
                        用户邮箱：
                    </td>
                    <td>
                        <input type="text" size="20" style="width: 200px" id="Admin_Email"  />
                    </td>
                </tr>
                <tr>
                    <td style="height:25px;" align="center">
                        用户密码：
                    </td>
                    <td>
                        <input type="password" size="20" style="width: 200px" id="Admin_Pwd" />
                    </td>
                </tr>
                <tr>
                    <td style="height:25px;" align="center">
                        用户组别：
                    </td>
                    <td>
                        <select id="Admin_RoleId" runat="server" style="width: 200px">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
</body>
</html>
