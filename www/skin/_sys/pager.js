//取cookies函数   
function getCookie(name)     
{
    var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
     if(arr != null) return unescape(arr[2]); return null;
}
//取对象
function get(id){
	return document.getElementById(id);
}
//取Url参数
function GetQueryString(name)
{    
	var reg=new RegExp("(^|&)"+name+"=([^&]*)(&|$)","i");
	var r=window.location.search.substr(1).match(reg);
	if(r!=null)
	{
		return unescape(r[2])
	}
	return null;     
}
//判断该对象是否存在
function ChkObjectIsExists(id)
{
    try
    {
        var iframeList = document.getElementById(id);
        if(iframeList == null|| iframeList == "undefined")
        {
            return false;
        }
        return true;
    }
    catch(e)
    {
        return false;
    }
}
//实现js版的endWith
String.prototype.endWith=function(str){
    if(str==null||str==""||this.length==0||str.length>this.length){
          return false;
    }
    if(this.substring(this.length-str.length)==str){
          return true;
    }else{
          return false;
    }
    return true;
}
//实现js版的startWith
String.prototype.startWith=function(str){
    if(str==null||str==""||this.length==0||str.length>this.length) {
        return false;
    }
    if(this.substr(0,str.length)==str) {
        return true;
    }else{
        return false;
    }
    return true;
}
//渲染分页
function renderDcmsPager(first,prev,next,last)
{
	var TotalPage=0;
	if(!isNaN(getCookie("TotalPage")))
	{
		TotalPage=parseInt(getCookie("TotalPage"));
	}
	var CurrentPage=1;
	if(isNaN(GetQueryString("page")))
	{
		CurrentPage=1;
	}
	else
	{
		CurrentPage=GetQueryString("page");
	}
	if(CurrentPage>TotalPage)
	{
		CurrentPage=TotalPage;
	}
	if(CurrentPage<=0)
	{
		CurrentPage=1;
	}
	CurrentPage=parseInt(CurrentPage);
	var PageName="/";
	var urlsplitArr=window.location.href.split("/");
	var urlsplitArrLen=urlsplitArr.length;
	if(urlsplitArrLen>3)
	{
		PageName=urlsplitArr[urlsplitArrLen-1];
	}
	PageName=PageName.replace(/page=(-*)(\d+)/i,"");
	if(PageName.indexOf('?')>=0)
	{
		if(PageName.endWith("&")||PageName.endWith("?"))
		{
			PageName=PageName+"page=";
		}
		else
		{
			PageName=PageName+"&page=";
		}
	}
	else
	{
		PageName=PageName+"?page=";
	}
	
	var dcmspager="<div class=pages>\n";
	var startpager="<a class=pgNext href=\""+PageName+"1\">"+first+"</a>\n<a class=pgNext href=\""+PageName+(CurrentPage-1)+"\">"+prev+"</a>\n";
	if(CurrentPage==1)
	{
		startpager="<a class=\"pgnext pgempty\">"+first+"</li>\n<a class=\"pgnext pgempty\">"+prev+"</a>\n";
	}
	dcmspager=dcmspager+startpager;
	var beginI=1;
	if(CurrentPage>5&&TotalPage>9)
	{
		beginI=CurrentPage-4;
	}
	var loopi=0;
	for(var i=beginI;i<=TotalPage;i++)
	{
		if(i==CurrentPage)
		{
			dcmspager=dcmspager+"<a class=\"pgcurrent\">"+i+"</a>";
		}
		else
		{
			dcmspager=dcmspager+"<a href=\""+PageName+i+"\">"+i+"</a>";
		}
		loopi++;
		if(loopi==9) break;
	}
	
	var endpager="<a class=pgNext href=\""+PageName+(CurrentPage+1)+"\">"+next+"</a>\n<a class=pgNext href=\""+PageName+TotalPage+"\">"+last+"</a>\n";
	if(CurrentPage==TotalPage)
	{
		endpager="<a class=\"pgnext pgempty\">"+next+"</a>\n<a class=\"pgnext pgempty\">"+last+"</a>\n";
	}
	dcmspager=dcmspager+endpager;
	dcmspager=dcmspager+"</div>";
	get("dcms_pager").innerHTML=dcmspager;
}