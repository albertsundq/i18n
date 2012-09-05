var EzWeb = function(){
    
    //变量------------------------------------------------------------------------------
    //窗体列表
    this.WinList = new Array();
    //事件
    this.Evt = null;
    //计时器
    this.Interval =null;
    //数据加载完成
    this.Complete = false;
    //蒙版对象
    this.MarkWin = null;
    //数据加载条
    this.DataLoadingBar = null;
    
    
    
    
    //系统初始化------------------------------------------------------------------------------
    this.Loaded = 0;
    this.SystemLoading = function(){   
        this.Complete = false;
        this.Mark(true);
        var conWin = this.GetWinBox();
        conWin.id = "SystemLoadingID";
        
        var curr = document.createElement("div");
        curr.className = "inDiv";
        curr.innerHTML = "<div class=\"loadCon\">"
                        +"<div class=\"progress\">"
                        +"<div class=\"line\" style=\"width:1%\" id=\"loadingBar\"></div>"
                        +"</div>"
                        +"<div class=\"percent\" id=\"loadingText\">1%</div>"
                        +"<div class=\"refresh\">[<a href=\"javascript:void(0);\" onclick=\"window.location.reload()\">刷新</a>]</div>"
                        +"</div>";
        
        //alert(conWin.firstChild.className);
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        document.body.appendChild(conWin);
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;        
         //设置进度信息
         this.Interval = setInterval("win.SetLoadingBar()",50);
    }
    //系统加载完成
    this.SystemLoaded = function(){
        this.SetLoadingInfo(90);
        window.clearInterval(this.Interval);
        this.Interval = null;
        this.Interval = setInterval("top.win.SetLoadingBar()",1);            
    }
    //系统重新加载
    this.ResetSystemLoading = function(){
        window.clearInterval(this.Interval);
        this.Interval = null;
        this.Loaded = 0;
    }
    //设置进度条
    this.SetLoadingInfo = function(percent){
        var objBar = $("loadingBar");
        var objText = $("loadingText");
        if(objBar != null && objText != null){
            objBar.style.width = percent + "%";
            objText.innerHTML = percent + "%";
        }
    }
    this.pageIsLoad = false;
    this.SetLoadingBar = function(){
        if(this.Complete==false && this.Loaded<90)
            this.Loaded += 1;
        if(this.Complete)
            this.Loaded += 8;
          
        if(!this.pageIsLoad&&this.Complete){            
            this.SystemLoaded();  
            this.pageIsLoad = true;
        }
        if(this.Loaded%8==0)
            this.SetLoadingInfo(this.Loaded);
        if(this.Loaded>100)
        {      
            this.SetLoadingInfo(100);    
            defaultPage = false;  
            //加载完毕
            window.clearInterval(this.Interval);
            this.Interval = null;
            this.Loaded = 0;
            this.Close();             
        }        
    }
    
    
    
    
    
    //页面加载------------------------------------------------------------------------------
    this.Goto = function(url){  
        //this.Mark(true);
               
        win.Complete = false;        
        var urlID = url.substring(0,url.indexOf('.'));
        
        if($("framePage")==null||$("framePage").contentWindow==null||$("framePage").contentWindow=="undefined") top.window.location = url;
        else{
            if(ChkFeature(urlID)){
                if(!defaultPage) this.DataLoading("页面加载中..."); 
                $("framePage").style.height = $("inBody").style.height = "500px";
                try{
                    divHeight();
                }catch(e){}
                $("framePage").src = url;
            }        
        }
    }
    this.pageHeight = 0;
    this.PageLoaded = function(h){
        if(h!=null) this.pageHeight = h;
        this.CloseDataLoading();        
    }
    
    
    
    
    
    //监测页面数据更新------------------------------------------------------------------------------
    this.loadingDiv = null;
    this.SubPageResize = function(item){    
        if(this.Interval!=null) window.clearInterval(this.Interval);
        this.pageHeight = 0;
        if(item!=null&&item!="undefined"){
            this.DataLoading();
            this.loadingDiv = item;
            top.Edited = true;
            this.Interval = setInterval("win.SetPageWH()",300);
        }
    }
    this.SetPageWH =function(){
        if(this.loadingDiv!=null&&this.loadingDiv.style.display == "none"){
            var iframe = null;
            try{
                iframe = this.WinList[this.WinList.length-1].firstChild.firstChild.nextSibling.firstChild.firstChild.firstChild;
            }catch(e){}
            if(iframe!=null&&iframe!="undefined"&&iframe.contentWindow.$!=null&&iframe.contentWindow.$!="undefined"&&iframe.contentWindow.$(this.loadingDiv.id)!=null&&iframe.contentWindow.$(this.loadingDiv.id)!="undefined"){
                var cls = iframe.contentWindow.$(this.loadingDiv.id).className;
                if(cls == "erro_ok"|| cls == "erro"){
                      window.clearInterval(this.Interval);
                     this.CloseDataLoading();
                     this.SetWinWH();
                 }else{
                    window.clearInterval(this.Interval);            
                    this.Interval = null;  
                    this.loadingDiv = null;
                    if(this.WinList.length==0||(this.WinList.length>0&&this.WinList[this.WinList.length-1].id!="editiframeId"))
                        this.Close();
                 }
            }else{
                window.clearInterval(this.Interval);            
                this.Interval = null;  
                this.loadingDiv = null;
                if(this.WinList.length==0||(this.WinList.length>0&&this.WinList[this.WinList.length-1].id!="editiframeId"))
                    this.Close();
            }
            try{
                ListenMemo();
            }catch(e){}
        }
    }
    
    
    
    
    
    //数据加载条------------------------------------------------------------------------------    
    this.DataLoading = function(tx){
        if(tx == null) tx = "数据处理中...";        
        if(this.DataLoadingBar == null){
            this.DataLoadingBar = document.createElement("div");
            this.DataLoadingBar.className = "loadding";
            this.DataLoadingBar.innerHTML = "<div><span></span><p>"+tx+"</p></div>";
            this.DataLoadingBar.id = this.winId;
            this.DataLoadingBar.style.right = "50px";
            this.DataLoadingBar.style.top = "50px";
            this.DataLoadingBar.style.position = "absolute";
            this.DataLoadingBar.style.zIndex = 10000;
            document.body.appendChild(this.DataLoadingBar);
        }
    }
    
    
    //蒙版------------------------------------------------------------------------------    
    this.Mark = function(display){
        if(display){
            this.SetDropList(false);
            if(this.MarkWin!=null){
                if($("editiframeId")!=null){
                    this.MarkWin.style.zIndex = parseInt($("editiframeId").style.zIndex) + 1;            
                }
                return;
            }
            var m=document.createElement("Div");            
            m.className = "mark";           
            m.style.position = "absolute"; 
            m.style.left = "0px";
            m.style.top = "0px";
            m.style.width = "100%";
            m.style.height = getPageSize()[1] + "px";
            m.style.zIndex = "1000";
            m.style.backgroundColor = "#000";
            m.style.opacity = 0.2;
            m.style.filter = "Alpha(Opacity=20)";
            document.body.appendChild(m);
            var h = getPageSize()[1];
            if(h>m.offsetHeight)
                m.style.height = h + "px";
            this.MarkWin = m;
        }else if(this.MarkWin!=null){
            if($("editiframeId")!=null){
                try{
                    this.MarkWin.style.zIndex = parseInt($("editiframeId").style.zIndex) - 1;
                }catch(e){
                    document.body.removeChild(this.MarkWin);
                    this.MarkWin = null;
                }
            }else{
                document.body.removeChild(this.MarkWin);
                this.MarkWin = null;
                this.SetDropList(true);
            }
        }
    }
    this.SetDropList = function(display){
        if($("framePage")==null)return;
        var list = $("framePage").contentWindow.document.getElementsByTagName("select");
        for(var i=0;i<list.length;i++){
            list[i].style.display = display?"":"none";
        }
    }
    
    
    //获取窗体框------------------------------------------------------------------------------
    this.GetWinBoxFrame = function(){
        var conWin = document.createElement("div");
        conWin.style.zIndex = parseInt(this.MarkWin.style.zIndex)+1;
        conWin.className = "load";
        var inLoad = document.createElement("div");
        inLoad.className = "inLoad";
        conWin.appendChild(inLoad);
        return conWin;
    }
    this.GetWinBox = function(){
        var conWin = this.GetWinBoxFrame();
        conWin.firstChild.innerHTML = "<div class=\"loadHead\"><div><div><div class=\"loadLogo\"></div><div class=\"close\" title=\"关闭\" style=\"display:none;\" onclick=\"win.Close()\" ></div></div></div></div><div class=\"outCon\"><div class=\"outConLeft\"><div class=\"outConRight\"></div></div></div><div class=\"loadFoot\"><div><div></div></div></div>";
        return conWin;
    }
    
    
    
    
    //退出窗体------------------------------------------------------------------------------
    this.Quit = function(){
        this.Mark(true);
        var conWin = this.GetWinBox();
        
        var curr = document.createElement("div");
        curr.className = "inDiv";
        curr.innerHTML = " 您要退出35互联刺猬建站系统吗？"
                        +"<div class=\"btnLoad\">"
                        +"<input type=\"button\" value=\"确定\" id=\"btnSure\" onclick=\"win.Close();win.Goto('Exit.aspx');\" class=\"btn\" />　"
                        +"<input type=\"button\" value=\"取消\" id=\"btnCancel\" onclick=\"win.Close()\" class=\"btnCancel\" />"
                        +"</div>";
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        document.body.appendChild(conWin);
        
        //绑定退出事件
        $("btnSure").focus();
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;
    }
    
    
    
    
    //提示窗体------------------------------------------------------------------------------
    this.Alert = function(tl,tx,fun){
        this.Mark(true);
        var conWin = this.GetWinBox();
        var winTitle = conWin.firstChild.firstChild.firstChild.firstChild.firstChild;
        winTitle.className = "loadTitle";
        winTitle.innerHTML = "<img src=\"images/提醒.gif\" />"+tl;
        winTitle.nextSibling.style.display = "";
        var curr = document.createElement("div");
        curr.className = "Con";
        curr.innerHTML = " "+tx
                        +"<div class=\"btnLoad\">"
                        +"<input type=\"button\" value=\"确定\" id=\"btnSure\" onclick=\"win.Close();win.Goto('Exit.aspx');\" class=\"btn\" />　"
                        +"</div>";
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        
        document.body.appendChild(conWin);
        this.SetMove();
               
        //绑定退出事件
        $("btnSure").onclick = function(){
            win.Close();
            if(fun != null) fun();
        }              
        $("btnSure").focus();
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;
        this.SetMove();
    }
    
    
    
    //确认窗体------------------------------------------------------------------------------
    this.isStop = true;
    this.Confirm = function(tl,tx,item,type){
        if(!this.isStop)
            return true;
            
        var icon = "提醒.gif";
        if(type!=null&&type!="undefined") icon = "警告.gif";
            
        this.Mark(true);
        var conWin = this.GetWinBox();
        var winTitle = conWin.firstChild.firstChild.firstChild.firstChild.firstChild;
        winTitle.className = "loadTitle";
        winTitle.innerHTML = "<img src=\"images/"+icon+"\" />"+tl;
        winTitle.nextSibling.style.display = "";
        
        var curr = document.createElement("div");
        curr.className = "Con";
        curr.innerHTML = " "+tx
                        +"<div class=\"btnLoad\">"
                        +"<input type=\"button\" value=\"确定\" id=\"btnSure\" onclick=\"win.Close();win.Goto('Exit.aspx');\" class=\"btn\" />　"
                        +"<input type=\"button\" value=\"取消\" id=\"btnCancel\" onclick=\"win.Close()\" class=\"btnCancel\" />"
                        +"</div>";
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        
        document.body.appendChild(conWin);
                
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;
        this.SetMove();
        
        //绑定退出事件
        $("btnSure").focus();
        $("btnSure").onclick = function(){
            win.Close();
            win.isStop = false;
            if(typeof(item)=="function"){
                item();
            }else{
                item.click();
                if(win.Evt == null) 
                    win.SubPageResize($("framePage").contentWindow.document.getElementById("UpdateProgress1"));
                else
                    win.Evt();  
                win.isStop = true;    
            }      
        }
        $("btnCancel").onclick = function(){
            win.Close();
        }
        
        return false;
    }
    
    //超时信息框------------------------------------------------------------------------------
    this.OutTimer = function(url){
        if(!this.isStop)
            return true;
            
        this.Mark(true);
        var conWin = this.GetWinBox();
        var winTitle = conWin.firstChild.firstChild.firstChild.firstChild.firstChild;
        winTitle.style.display = "none";
        
        var curr = document.createElement("div");
        curr.className = "Con";
        curr.innerHTML ="<div class=\"reLogin\"><span></span>"
	                        +"<h3>您好，登录已超时。</h3>"
	                        +"<p>由于您长时间没有进行页面操作，为了您的系统安全，请<a href=\"#\" onclick=\"top.window.location.href='"+url+"'\">重新登录</a>。</p>"
	                        +"<div class=\"clear\"></div>"
	                        +"</div>";
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        
        document.body.appendChild(conWin);
        conWin.firstChild.style.width = 500 + "px";
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;
        return false;
    }
    
    
    //信息确认框------------------------------------------------------------------------------
    this.WinViewer = function(tl,html,item,btnSureName,btnCancelName){
        if(!this.isStop)
            return true;
            
        this.Mark(true);
        var conWin = this.GetWinBox();
        var winTitle = conWin.firstChild.firstChild.firstChild.firstChild.firstChild;
        winTitle.className = "loadTitle";
        winTitle.innerHTML = "<img src=\"images/提醒.gif\" />"+tl;
        winTitle.nextSibling.style.display = "";
        
        var curr = document.createElement("div");
        curr.className = "Con";
        curr.innerHTML = html
                        +"<div class=\"btnLoad\" style='padding-bottom:1px;'>"
                        +"<input type=\"button\" value=\"确定\" id=\"btnSure\" onclick=\"win.Close();win.Goto('Exit.aspx');\" class=\"btnThree\" />　"
                        +"<input type=\"button\" value=\"取消\" id=\"btnCancel\" onclick=\"win.Close()\" class=\"cancel\" />"
                        +"</div>";
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(curr);
        
        document.body.appendChild(conWin);
        conWin.firstChild.style.width = 500 + "px";
        this.Resize(conWin);   
        this.WinList[this.WinList.length] = conWin;
        this.SetMove();
        
        //绑定退出事件
        $("btnSure").focus();
        if(btnSureName!=null&&btnSureName!="undefined")
        {
            $("btnSure").value=btnSureName;
        }
        if(btnCancelName!=null&&btnCancelName!="undefined")
        {
            $("btnCancel").value=btnCancelName;
        }
        $("btnSure").onclick = function(){            
            win.isStop = false;
            if(typeof(item)=="function"){
                item();
            }else{
                win.Close();
                try{
                    item.onclick = function(){return true;}
                    item.click();                    
                }catch(e){
                    $("framePage").contentWindow.__doPostBack(item.id,'');
                }
                if(win.Evt == null) 
                    win.SubPageResize($("framePage").contentWindow.document.getElementById("UpdateProgress1"));
                else
                    win.Evt();  
            }
            win.isStop = true;          
        }
        $("btnCancel").onclick = function(){
            win.Close();
        }
        
        return false;
    }
    
    
    
    
    //编辑框------------------------------------------------------------------------------
    this.winPageId = "SetWindowID";
    this.WinEditor = function(tl,w,h,url,fun,type){
        if(fun!=null) this.Evt = fun;
        this.Mark(true);
        this.DataLoading("页面加载中...");        
        var conWin = this.GetWinBox();
        var winTitle = conWin.firstChild.firstChild.firstChild.firstChild.firstChild;
        winTitle.className = "loadTitle";
        winTitle.innerHTML = "<img src=\"images/"+this.SetWinIcon(url,type)+"\" />"+tl;
        winTitle.nextSibling.style.display = "";
        //帧页面
        var newIframe = document.createElement("iframe");
        newIframe.scrolling = this.SetWinIcon(url,type)=="通知.gif"?"auto":"no";   
        newIframe.frameBorder  = "0";
        newIframe.src = url;
        newIframe.style.width = "100%"; 
        
        conWin.firstChild.firstChild.nextSibling.firstChild.firstChild.appendChild(newIframe);
        
        document.body.appendChild(conWin);           
        this.WinList[this.WinList.length] = conWin;
        if(w<300) w=300;
        if(h<100) h=50;
        this.SetWinWH(w,h);
        
        this.Resize(conWin);
        this.DataLoadingBar.style.right = "50%";
        this.DataLoadingBar.style.top = parseInt(conWin.style.top)+conWin.offsetHeight/2+"px";
        //this.SetMove();        
    }
    this.SetWinWH = function(w,h){
        if(this.WinList.length==0||this.WinList[this.WinList.length - 1].id == "editiframeId") return;        
        var currWin = this.WinList[this.WinList.length - 1]; 
        var iframe = currWin.firstChild.firstChild.nextSibling.firstChild.firstChild.firstChild;
        if(iframe==null||iframe=="undefined"||iframe.tagName.toLowerCase()!="iframe")
            return;
        
        try{
            if(w!=null&&w!="undefined")
                currWin.firstChild.style.width = w + "px";
            if(h==null||h=="undefined"){            
                h = iframe.contentWindow.document.forms[0].offsetHeight;
                iframe.contentWindow.document.body.scrolling = "no";
                if(h<150) 
                    h = 150;
                else
                    h += 50;
            }
        }catch(e){h=200}
        iframe.style.height = h + "px";
    }
    
    
    
    
    
    //设置窗体图标------------------------------------------------------------------------------
    this.SetWinIcon = function(url,type){
        var urlID = url.substring(0,url.indexOf('.')).toLowerCase();
        var icon = "";
        switch(urlID){
            case "recordinfo":
                icon = "备案.gif";
                break;
            case "editpage":
                icon = "页面属性.gif";
                break;
            case "copypage":
                icon = "复制页面.gif";
                break;
            case "editpassword":
                icon = "密码修改.gif";
                break;
            case "notice":
            case "noticelist":
                icon = "通知.gif";
                break;
            case "listenmusic":
                icon = "音乐.gif";
                break;
            default:
                break;
        }
        if(icon==""){
            if(type=="0") 
                icon = "添加模块.gif";
            else
                icon = "编辑模块.gif";
        }
        return icon;
    }
    
    
    
    
    
    //窗体定位------------------------------------------------------------------------------
    this.Resize = function(objWin){
        var scrollPosTop; 
        var scrollPosLeft; 
        if (typeof window.pageYOffset != 'undefined') { 
           scrollPosTop = window.pageYOffset; 
           scrollPosLeft = window.pageXOffset; 
        } 
        else if (typeof document.compatMode != 'undefined' && 
             document.compatMode != 'BackCompat') { 
           scrollPosTop = document.documentElement.scrollTop; 
           scrollPosLeft = document.documentElement.scrollLeft; 
        } 
        else if (typeof document.body != 'undefined') { 
           scrollPosTop = document.body.scrollTop; 
           scrollPosLeft = document.body.scrollLeft;
        }
            
        var winSize = getDimensions().split(':');
        var winWidth = winSize[0];
        var winHeight = winSize[1];
        
        try{
            objWin.style.top = (scrollPosTop + (winHeight - objWin.offsetHeight)/2) + "px";
            objWin.style.left = (scrollPosLeft + (winWidth - objWin.offsetWidth)/2) + "px";
            
            var temp = parseInt(objWin.style.top) + objWin.offsetHeight - scrollPosTop - winHeight;
            if(temp>0)
                objWin.style.top = scrollPosTop + 20 + "px";
            
            if(parseInt(objWin.style.top)<scrollPosTop)
                objWin.style.top = (scrollPosTop + 20) + "px";
        }catch(e){}
    }
    
    
    
    //窗体管理------------------------------------------------------------------------------
    this.SetMove = function(){
        if(this.WinList.length==0) return;
        var conWin = this.WinList[this.WinList.length-1];
        if(conWin&&conWin.firstChild&&conWin.firstChild.firstChild){
            loadHead = conWin.firstChild.firstChild;
            loadHead.onmousedown = function(){fDragging(conWin, event, true);}
            loadHead.onmouseover = function(){loadHead.style.cursor = "move";}
            loadHead.onmouseup = function(){loadHead.style.cursor = "default";}
        }
    }
    this.Close = function(){        
        this.Complete = true;
        try{
            if(defaultPage) this.SetLoadingInfo(100);
        }catch(e){}
        this.SetWinWH();
        if(this.WinList.length>0)
            document.body.removeChild(this.WinList[this.WinList.length-1]);
        try{
            $("form1").style.display = "";
            $("footer").style.display = "";
        }catch(e){}
        if(this.WinList.length==1){
            this.WinList = new Array();
        }else{                
            var temp = new Array();
            for(var i=0;i<this.WinList.length-1;i++){
                temp[i] = this.WinList[i];
            }
            this.WinList = temp;                
        }
        this.CloseDataLoading();
        this.ExecEv();
        if(this.WinList.length==0||this.WinList[this.WinList.length - 1].id == "editiframeId")
            this.Mark(false);
        
        var objChk = $("35EzWebCheckWindow");
        if(objChk!=null)
            document.body.removeChild(objChk);
    }
    this.CloseDataLoading = function(){         
        this.Complete = true;
        this.isStop = true;        
        if(this.DataLoadingBar){
            document.body.removeChild(this.DataLoadingBar);
            this.DataLoadingBar = null;            
        }                
        this.SetIframeHeight(); 
        this.SetMove();       
    }
    this.ExecEv = function(){
        if(this.Evt!=null){
            if(top.Edited)
            {
                this.Evt();
                top.Edited = false;
            }
            this.Evt = null;
        }
    }
    this.SetIframeHeight = function(){
        //判断是否打开编辑窗体
        var stanH = 500;
        if(this.WinList.length == 0)
            this.Mark(false);
        
        //设置高度
        this.SetDocHeight();
    }
    this.SetDocHeight = function(){
        //设置系统高度
        var objFrame = $("framePage");    
        
        if(objFrame==null||objFrame.id=="undefined"||objFrame.id==null) return;
        
        try{
            if(objFrame.contentWindow.document.forms.length==0)
                this.pageHeight = objFrame.contentWindow.getPageSize()[1];
            else
                this.pageHeight = objFrame.contentWindow.document.forms[0].offsetHeight + 30;
        }catch(e){}
            
        if(this.pageHeight<550) this.pageHeight = 550;
        objFrame.style.width = "100%";
	    objFrame.style.height = $("inBody").style.height = this.pageHeight + "px";
	    try{	        
            divHeight();
        }catch(e){}        
    }
    
}


/// <summary>
/// 模块编号：fDragging
/// 作用：窗口移动控制
/// 作者：黄碧辉
/// 邮箱：huangbh@35.cn
/// 编写时间：2008-08-26
/// </summary>
function fDragging(obj, e, limit){ 
        if(!e) e=window.event; 
        var x=parseInt(obj.style.left); 
        var y=parseInt(obj.style.top); 
         
        var x_=e.clientX-x; 
        var y_=e.clientY-y; 
         
        if(document.addEventListener){ 
            document.addEventListener('mousemove', inFmove, true); 
            document.addEventListener('mouseup', inFup, true); 
        } else if(document.attachEvent){ 
            document.attachEvent('onmousemove', inFmove); 
            document.attachEvent('onmouseup', inFup); 
        } 
         
        inFstop(e);     
        inFabort(e) 
         
        function inFmove(e){ 
            var evt; 
            if(!e)e=window.event;  
            if(false){            
                //横向拖拉限制
                if((e.clientX-x_-obj.offsetWidth/2)<=0)
                    return false;
                if((e.clientX-x_+obj.offsetWidth/2+1)>=document.body.scrollWidth)
                    return false;
                //纵向拖拉限制
                if((e.clientY-y_-obj.offsetHeight-document.documentElement.scrollTop)<=0)
                    return false;
                if((e.clientY-y_ -document.documentElement.scrollTop) >= document.body.clientHeight)
                    return false;
            } 
             
            obj.style.left=(e.clientX-x_)+'px'; 
            obj.style.top=(e.clientY-y_)+'px';
            inFstop(e); 
        } // shawl.qiu script 
        function inFup(e){ 
            var evt; 
            if(!e)e=window.event; 
             
            if(document.removeEventListener){ 
                document.removeEventListener('mousemove', inFmove, true); 
                document.removeEventListener('mouseup', inFup, true); 
            } else if(document.detachEvent){ 
                document.detachEvent('onmousemove', inFmove); 
                document.detachEvent('onmouseup', inFup); 
            } 
             
            inFstop(e); 
        } // shawl.qiu script 
  
        function inFstop(e){ 
            if(e.stopPropagation) return e.stopPropagation(); 
            else return e.cancelBubble=true;             
        } // shawl.qiu script 
        function inFabort(e){ 
            if(e.preventDefault) return e.preventDefault(); 
            else return e.returnValue=false; 
        } // shawl.qiu script 
    }