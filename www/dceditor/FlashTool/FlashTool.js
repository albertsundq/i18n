// JavaScript Document
document.write('<script src="/FlashTool/js/jquery.bgiframe.js" type="text/javascript"></script>');
document.write('<script src="/FlashTool/js/jquery.weebox.js" type="text/javascript"></script>');
var DivImage = null;
jQuery.DcTool = {           
	show:function(inputName) {   
				DivImage = null;
				$.weeboxs.open('FlashTool/ToolMain.html?inputName='+inputName, {
					 title:'DCTool v3.0 文件管理器',
					 contentType:'iframe',
					 width:750,
					 height:450,
					 showButton:false,//不显示按钮栏
					 showOk:false,//不显示确定按钮
					 showCancel:false//不显示取消按钮	
				 });        
	},     
	showDiv:function(inputName,div) {     
				DivImage = div;
				$.weeboxs.open('FlashTool/ToolMain.html?inputName='+inputName, {
					 title:'DCTool v3.0 文件管理器',
					 contentType:'iframe',
					 width:750,
					 height:450,
					 showButton:false,//不显示按钮栏
					 showOk:false,//不显示确定按钮
					 showCancel:false//不显示取消按钮	
				 });        
	}, 
	close:function(inputName,value){
					$("#"+inputName).val(value);
					if(DivImage != null){
						$("#"+DivImage).html("<img src=\""+value+"\"/>");
					}
					$.weeboxs.close();
	}     
};   