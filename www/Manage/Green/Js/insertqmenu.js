document.write("<span onclick='insertQMenu();' style='cursor:pointer;'>加入到快捷菜单</span>");
//创建快捷菜单
function insertQMenu()
{
	var thisDomain=String(document.domain).toLowerCase();
	var thisUrl=String(document.location).toLowerCase();
	var QMenuUrl=String(thisUrl).split(String(thisDomain))[1].replace(/&/g,"|");
	var QMenuTitle=String(document.title);
	 $.ajax({
	   type: "post",
	   url: "../BaseManage/QMenu_Manage.aspx?action=insert",
	   data: "QMenu_Title="+QMenuTitle+"&QMenu_Url="+QMenuUrl,
	   success: function(data, textStatus){
		   
			//请求成功处理;
			if(data=="true"){
			    parent.dcmsDialog("处理成功","新增快捷菜单成功!");
			    parent.getTopQMenu();
			}
			else if(data=="false"){
			    parent.dcmsDialog("处理失败","该快捷菜单已添加，不能重复添加!");
			    parent.getTopQMenu();
			}
			else
			{
				alert(data);
			}
	   },
	   error: function(){
			//请求出错处理
			parent.dcmsDialog("处理失败","新增快捷菜单失败!");
	   }
	 });
}