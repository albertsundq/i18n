$.extend($.fn, {
    initJerichoTab: function(setting) {
        var opts = $.fn.extend({
            renderTo: null,
            uniqueId: null,
            tabs: [],
            activeTabIndex: 0,
            contentCss: {
                'height': '500px'
            },
            loadOnce: true,
            tabWidth: 150,
            loader: 'righttag'
        }, setting);
        function createJerichoTab() {
            if (opts.renderTo == null) { alert('you must set the \'renderTo\' property\r\t--JeirchoTab'); return; }
            if (opts.uniqueId == null) { alert('you must set the \'uniqueId\' property\r\t--JeirchoTab'); return; }
            if ($('#' + opts.uniqueId).length > 0) { alert('you must set the \'uniqueId\' property as unique\r\t--JeirchoTab'); return; }
            var jerichotab = $('<div class="jericho_tab"><div class="tab_pages"><div class="tabs" style="width:' + ($('.divRight').width() - 38) + 'px;float:left;"><ul/></div></div><div class="tab_content"><div class="contentleft" /><div id="jerichotab_contentholder" class="content" /><div class="contentright" /></div></div>')
                                            .appendTo($(opts.renderTo));
            $('.tab_content>.content', jerichotab)
                                    .css(opts.contentCss);
            $.fn.jerichoTab = {
                master: jerichotab,
                tabWidth: opts.tabWidth,
                tabPageWidth: $('.tab_pages', jerichotab).width(),
                loader: opts.loader,
                loadOnce: opts.loadOnce,
                tabpage: $('.tab_pages>.tabs>ul', jerichotab),
                addTab: function(tabsetting) {
                    var ps = $.fn.extend({
                        tabFirer: null,
                        title: 'Jericho Tab',
                        data: { dataType: '', dataLink: '' },
                        iconImg: '/Manage/Green/Images/folder.gif',
                        closeable: true,
                        onLoadCompleted: null
                    }, tabsetting);
                    tagGuid = (typeof tagGuid == 'undefined' ? 0 : tagGuid + 1);
                    var curIndex = tagGuid;
                    if (ps.tabFirer != null) {
                        var jerichotabindex = ps.tabFirer.attr('jerichotabindex');
                        if (typeof jerichotabindex != 'undefined' && $('#jerichotab_' + jerichotabindex).length > 0)
                            return $.fn.setTabActive(jerichotabindex).adaptSlider().loadData();
                        ps.tabFirer.attr('jerichotabindex', curIndex);
                    }
                    var newTab = $('<li class="jericho_tabs tab_selected" style="width:0px;"  id="jerichotab_' + curIndex + '" dataType="' + ps.data.dataType + '" dataLink="' + ps.data.dataLink + '"><div class="tab_left"  style="width:' + (opts.tabWidth - 5) + 'px"><div class="tab_icon" style="' + (ps.iconImg == '' ? 'backrground:none' : 'background-image:url(' + ps.iconImg + ')') + '">&nbsp;</div><div class="tab_text" title="' + ps.title + '"  style="width:' + (opts.tabWidth - 50) + 'px">' + ps.title.cut(opts.tabWidth / 10 - 1) + '</div><div class="tab_close">' + (ps.closeable ? '<a href="javascript:void(0)" title="Close">&nbsp;</a>' : '') + '</div></div><div class="tab_right"></div></li>')
                                                    .appendTo($.fn.jerichoTab.tabpage)
                                                        .css('opacity', '0')
                                                            .applyHover()
                                                                .applyCloseEvent()
                                                                        .animate({ 'opacity': '1', width: opts.tabWidth }, function() {
                                                                            $.fn.setTabActive(curIndex);
                                                                        });
                    tabHash = (typeof tabHash == 'undefined' ? [] : tabHash);
                    tabHash.push({
                        index: curIndex,
                        tabFirer: ps.tabFirer,
                        tabId: 'jerichotab_' + curIndex,
                        holderId: 'jerichotabholder_' + curIndex,
                        iframeId: 'jerichotabiframe_' + curIndex,
                        onCompleted: ps.onLoadCompleted
                    });
                    $('.tab_content').width($('.divRight').width());
                    $('#jerichotab_contentholder').width($('.divRight').width() - 26);
                    $('#jerichotab_contentholder').height($(opts.renderTo).height() - 50);
                    $('.contentleft').height($(opts.renderTo).height() - 30);
                    $('.contentright').height($(opts.renderTo).height() - 30);

                    return newTab.applySlider();
                }
            };
            $.each(opts.tabs, function(i, n) {
                $.fn.jerichoTab.addTab(n);
            });
            if (tabHash.length == 0)
                jerichotab.css({ 'display': 'none' });
        }
        createJerichoTab();
        $.fn.setTabActive(opts.activeTabIndex).loadData();
        $.fn.jerichoTab.closeTab=function(curTab){
            //关闭tab扩展
            $('#' + curTab).trigger("dblclick");
           
        };
        $.fn.jerichoTab.resize = function() {
            $.fn.jerichoTab.tabPageWidth = $(".tab_pages", $.fn.jerichoTab.master).width() - (($(".jericho_slider").length > 0) ? 38 : 0);
            $(".tabs", $.fn.jerichoTab.master).width($.fn.jerichoTab.tabPageWidth).applySlider().adaptSlider();
            $('#jerichotab_contentholder').width($(opts.renderTo).width() - 26);
            $('#jerichotab_contentholder').height($(opts.renderTo).height() - 50);
            $('.contentleft').height($(opts.renderTo).height() - 30);
            $('.contentright').height($(opts.renderTo).height() - 30);
        };
        $(window).resize(function() {
            //$.fn.jerichoTab.resize();
        })
    },
    setTabActiveByOrder: function(orderKey) {
        var lastTab = $.fn.jerichoTab.tabpage.children('li').filter('.tab_selected');
        if (lastTab.length > 0) lastTab.swapTabEnable();
        return $('#jericho_tabs').filter(':nth-child(' + orderKey + ')').swapTabEnable();
    },
    setTabActive: function(orderKey) {
        var lastTab = $.fn.jerichoTab.tabpage.children('li').filter('.tab_selected');
        if (lastTab.length > 0) lastTab.swapTabEnable();
        return $('#jerichotab_' + orderKey).swapTabEnable();
    },
    addEvent: function(e, h) {
        var target = this.get(0);
        if (target.addEventListener) {
            target.addEventListener(e, h, false);
        } else if (target.attachEvent) {
            target.attachEvent('on' + e, h);
        }
    },
    buildIFrame: function(src) {
        return this.each(function() {
            var onComleted = null, jerichotabiframe = '';
            for (var tab in tabHash) {
                if (tabHash[tab].holderId == $(this).attr('id')) {
                    onComleted = tabHash[tab].onCompleted;
                    jerichotabiframe = tabHash[tab].iframeId;
                    break;
                }
            }
            var iframe = $('<iframe id="' + jerichotabiframe + '" name="' + jerichotabiframe + '" src="' + src + '" frameborder="0" scrolling="auto" />')
                                        .css({ width: '100%', height: $(this).parent().height(), border: 0 })
                                            .appendTo($(this));
            $('#' + jerichotabiframe).addEvent('load', function() {
                !!onComleted ? onComleted(arguments[1]) : true;
                $.fn.removeLoader();
            });
        });
    },
    loadData: function() {
        return this.each(function() {
            $('#jerichotab_contentholder').showLoader();
            var onComleted = null, holderId = '', tabId = '';
            for (var tab in tabHash) {
                if (tabHash[tab].tabId == $(this).attr('id')) {
                    onComleted = tabHash[tab].onCompleted;
                    holderId = '#' + tabHash[tab].holderId;
                    tabId = '#' + tabHash[tab].tabId;
                    break;
                }
            }
            var dataType = $(this).attr('dataType');
            var dataLink = $(this).attr('dataLink');
            if (typeof dataType == 'undefined' || dataType == '' || dataType == 'undefined') { removeLoading(); return; }
            $('#jerichotab_contentholder').children('div[class=curholder]').attr('class', 'holder').css({ 'display': 'none' });
            var holder = $(holderId);
            if (holder.length == 0) {
                holder = $('<div class="curholder" id="' + holderId.replace('#', '') + '" />').appendTo($('#jerichotab_contentholder'));
                load(holder);
            }
            else {
                holder.attr('class', 'curholder').css({ 'display': 'block' });
                if ($.fn.jerichoTab.loadOnce)
                    removeLoading();
                else {
                    holder.html('');
                    load(holder);
                }
            }

            function load(c) {
                switch (dataType) {
                    case 'formtag':
                        $(dataLink).css('display', 'none');
                        var clone = $(dataLink)
                                                    .clone(true)
                                                        .appendTo(c)
                                                            .css('display', 'block');
                        removeLoading(holder);
                        break;
                    case 'html':
                        holder.load(dataLink + '?t=' + Math.floor(Math.random()), function() {
                            removeLoading(holder);
                        });
                        break;
                    case 'iframe':
                        holder.buildIFrame(dataLink, holder);
                        break;
                    case 'ajax':
                        $.ajax({
                            url: dataLink,
                            data: { t: Math.floor(Math.random()) },
                            error: function(r) {
                                holder.html('error! can\'t load data by ajax');
                                removeLoading(holder);
                            },
                            success: function(r) {
                                holder.html(r);
                                removeLoading(holder);
                            }
                        });
                        break;
                }
            }
            function removeLoading(h) {
                !!onComleted ? onComleted(h) : true;
                $.fn.removeLoader();
            }
        });
    },
    attachSliderEvent: function() {
        return this.each(function() {
            var me = this;
            $(me).hover(function() {
                $(me).swapClass('jericho_slider' + $(me).attr('pos') + '_enable', 'jericho_slider' + $(me).attr('pos') + '_hover');
            }, function() {
                $(me).swapClass('jericho_slider' + $(me).attr('pos') + '_hover', 'jericho_slider' + $(me).attr('pos') + '_enable');
            }).mouseup(function() {
                if ($(me).is('[slide=no]')) return;
                var offLeft = parseInt($.fn.jerichoTab.tabpage.css('left'));
                var maxLeft = tabHash.length * $.fn.jerichoTab.tabWidth - $.fn.jerichoTab.tabPageWidth + 38;
                switch ($(me).attr('pos')) {
                    case 'left':
                        if (offLeft + $.fn.jerichoTab.tabWidth < 0)
                            $.fn.jerichoTab.tabpage.animate({ left: offLeft + $.fn.jerichoTab.tabWidth });
                        else
                            $.fn.jerichoTab.tabpage.animate({ left: 0 }, function() {
                                $(me).attr({ 'slide': 'no', 'class': 'jericho_sliders jericho_sliderleft_disable' });
                            });
                        $('.jericho_sliders[pos=right]').attr({ 'slide': 'yes', 'class': 'jericho_sliders jericho_sliderright_enable' });
                        break;
                    case 'right':
                        if (offLeft - $.fn.jerichoTab.tabWidth > -maxLeft)
                            $.fn.jerichoTab.tabpage.animate({ left: offLeft - $.fn.jerichoTab.tabWidth });
                        else
                            $.fn.jerichoTab.tabpage.animate({ left: -maxLeft }, function() {
                                $(me).attr({ 'slide': 'no', 'class': 'jericho_sliders jericho_sliderright_disable' });
                            });
                        $('.jericho_sliders[pos=left]').attr({ 'slide': 'yes', 'class': 'jericho_sliders jericho_sliderleft_enable' });
                        break;
                }
            });
        });
    },
    applySlider: function() {
        return this.each(function() {

            if (typeof tabHash == 'undefined' || tabHash.length == 0) return;
            var offWidth = tabHash.length * $.fn.jerichoTab.tabWidth - $.fn.jerichoTab.tabPageWidth + 38;
            if (tabHash.length > 0 && offWidth > 0) {
                $.fn.jerichoTab.tabpage.parent().css({ width: $.fn.jerichoTab.tabPageWidth - 38 });
                $.fn.jerichoTab.tabpage.css({ width: offWidth + $.fn.jerichoTab.tabPageWidth - 38 }).animate({ left: -offWidth }, function() {
                    if ($('.jericho_sliders').length <= 0) {
                        $('.jericho_nosliders').remove();
                        $.fn.jerichoTab.tabpage.parent()
                            .before($('<div class="jericho_sliders jericho_sliderleft_enable" slide="yes" pos="left" />'));
                        $.fn.jerichoTab.tabpage.parent()
                            .after($('<div class="jericho_sliders jericho_sliderright_disable" pos="right" slide="yes" />'));
                        $('.jericho_sliders').attachSliderEvent();
                    }
                });
            }
            else if (tabHash.length > 0 && offWidth <= 0) {
                $('.jericho_sliders').remove();
                if (($.fn.jerichoTab.tabpage.parent().next(".jericho_nosliders").length <= 0)&&($('.jericho_sliderright_no').length<=0)&&($('.jericho_sliderleft_no').length<=0)) {
                    $.fn.jerichoTab.tabpage.parent()
                            .before($('<div class="jericho_nosliders jericho_sliderleft_no" />'));
                    $.fn.jerichoTab.tabpage.parent()
                            .after($('<div class="jericho_nosliders jericho_sliderright_no" />'));
                }
                $.fn.jerichoTab.tabpage.css({ width: -offWidth + $.fn.jerichoTab.tabPageWidth }).animate({ left: 0 });
            }
        });
    },
    adaptSlider: function() {
        return this.each(function() {
            if ($('.jericho_sliders').length > 0) {
                var offLeft = parseInt($.fn.jerichoTab.tabpage.css('left'));
                var curtag = '#', index = 0;
                for (var t in tabHash) {
                    if (tabHash[t].tabId == $(this).attr('id')) {
                        curtag += tabHash[t].tabId;
                        index = parseInt(t);
                        break;
                    }
                }
                var tabWidth = $.fn.jerichoTab.tabPageWidth - 38;
                var space_l = $.fn.jerichoTab.tabWidth * index + offLeft;
                var space_r = $.fn.jerichoTab.tabWidth * (index + 1) + offLeft;
                function setSlider(pos, enable) {
                    $('.jericho_sliders[pos=' + pos + ']').attr({ 'slide': (enable ? 'yes' : 'no'), 'class': 'jericho_sliders jericho_slider' + pos + '_' + (enable ? 'enable' : 'disable') });
                }
                if ((space_l < 0 && space_l > -$.fn.jerichoTab.tabWidth) && (space_r > 0 && space_r < $.fn.jerichoTab.tabWidth)) {
                    $.fn.jerichoTab.tabpage.animate({ left: -$.fn.jerichoTab.tabWidth * index }, function() {
                        if (index == 0) setSlider('left', false);
                        else setSlider('left', true);
                        setSlider('right', true);
                    });
                }
                if ((space_l < tabWidth && space_l > tabWidth - $.fn.jerichoTab.tabWidth) && (space_r > tabWidth && space_r < tabWidth + $.fn.jerichoTab.tabWidth)) {
                    $.fn.jerichoTab.tabpage.animate({ left: -$.fn.jerichoTab.tabWidth * (index + 1) + tabWidth }, function() {
                        if (index == tabHash.length - 1) setSlider('right', false);
                        else setSlider('left', true);
                        setSlider('left', true);
                    });
                }
            }
        });
    },
    applyCloseEvent: function() {
        return this.each(function() {
            var me = this;
            $('.tab_close>a', this).mouseup(function(e) {
                e.stopPropagation();
                if ($(this).length == 0) return;
                $(me).animate({ 'opacity': '0', width: '0px' }, function() {
                    var lastTab = $.fn.jerichoTab.tabpage.children('li').filter('.tab_selected');
                    if (lastTab.attr('id') == $(this).attr('id')) {
                        $(this).prev().swapTabEnable().loadData();
                    }
                    for (var t in tabHash) {
                        if (tabHash[t].tabId == $(me).attr('id')) {
                            if (tabHash[t].tabFirer != null)
                                tabHash[t].tabFirer.removeAttr('jerichotabindex');
                            tabHash.splice(t, 1);
                        }
                    }
                    $(me).applySlider().remove();
                    $('#jerichotabholder_' + $(me).attr('id').replace('jerichotab_', '')).remove();
                })
            })

            $(this).dblclick(function(e) {
                //e = $('.tab_close>a', this);
                e.stopPropagation();
                if ($(this).length == 0) return;
                $(me).animate({ 'opacity': '0', width: '0px' }, function() {
                    var lastTab = $.fn.jerichoTab.tabpage.children('li').filter('.tab_selected');
                    if (lastTab.attr('id') == $(this).attr('id')) {
                        $(this).prev().swapTabEnable().loadData();
                    }
                    for (var t in tabHash) {
                        if (tabHash[t].tabId == $(me).attr('id')) {
                            if (tabHash[t].tabFirer != null)
                                tabHash[t].tabFirer.removeAttr('jerichotabindex');
                            tabHash.splice(t, 1);
                        }
                    }
                    $(me).applySlider().remove();
                    $('#jerichotabholder_' + $(me).attr('id').replace('jerichotab_', '')).remove();
                })
            })
        });
    },
    applyHover: function() {
        return this.each(function() {
            $(this).hover(function() {
                if ($(this).hasClass('tab_unselect')) $(this).addClass('tab_unselect_h');
            }, function() {
                if ($(this).hasClass('tab_unselect_h')) $(this).removeClass('tab_unselect_h');
            }).mouseup(function() {
                if ($(this).hasClass('tab_selected')) return;
                var lastTab = $.fn.jerichoTab.tabpage.children('li').filter('.tab_selected');
                lastTab.attr('class', 'jericho_tabs tab_unselect');
                if (lastTab.attr('id')) {
                    $('#jerichotabholder_' + lastTab.attr('id').replace('jerichotab_', '')).css({ 'display': 'none' });
                }
                $(this).attr('class', 'jericho_tabs tab_selected').loadData().adaptSlider();
            });
        });
    },
    swapTabEnable: function() {
        return this.each(function() {
            if ($(this).hasClass('tab_selected'))
                $(this).swapClass('tab_selected', 'tab_unselect');
            else if ($(this).hasClass('tab_unselect'))
                $(this).swapClass('tab_unselect', 'tab_selected');
        });
    },
    swapClass: function(css1, css2) {
        return this.each(function() {
            $(this).removeClass(css1).addClass(css2);
        })
    },
    showLoader: function() {
        return this.each(function() {
            switch ($.fn.jerichoTab.loader) {
                case 'usebg':
                    $(this).addClass('loading');
                    break;
                case 'righttag':
                    if ($('#jerichotab_contentholder>.righttag').length == 0)
                        $('<div class="righttag">&nbsp;</div>').appendTo($(this));
                    else
                        $('#jerichotab_contentholder>.righttag').css({ display: 'block' });
                    break;
            }
        });
    },
    removeLoader: function() {
        switch ($.fn.jerichoTab.loader) {
            case 'usebg':
                $('#jerichotab_contentholder').removeClass('loading');
                break;
            case 'righttag':
                $('#jerichotab_contentholder>.righttag').css({ display: 'none' });
                break;
        }
    }
});

$.fn.extend({
Scroll:function(opt,callback){
if(!opt) var opt={};
var _btnUp = $("#"+ opt.up);
var _btnDown = $("#"+ opt.down);
var timerID;
var _this=this.eq(0).find("ul:first");
var     lineH=_this.find("li:first").height(), 
line=opt.line?parseInt(opt.line,10):parseInt(this.height()/lineH,10),
speed=opt.speed?parseInt(opt.speed,10):500;
timer=opt.timer
if(line==0) line=1;
var upHeight=0-line*lineH;
var scrollUp=function(){
_btnUp.unbind("click",scrollUp);
_this.animate({
marginTop:upHeight
},speed,function(){
for(i=1;i<=line;i++){
_this.find("li:first").appendTo(_this);
}
_this.css({marginTop:0});
_btnUp.bind("click",scrollUp);
});

}
var scrollDown=function(){
_btnDown.unbind("click",scrollDown);
for(i=1;i<=line;i++){
_this.find("li:last").show().prependTo(_this);
}
_this.css({marginTop:upHeight});
_this.animate({
marginTop:0
},speed,function(){
_btnDown.bind("click",scrollDown);
});
}
var autoStop = function(){
if(timer)window.clearInterval(timerID);
};
_btnUp.css("cursor","pointer").click( scrollUp );
_btnDown.css("cursor","pointer").click( scrollDown );

}     
});

String.prototype.cut = function(len) {
    var position = 0;
    var result = [];
    var tale = '';
    for (var i = 0; i < this.length; i++) {
        if (position >= len) {
            tale = '...';
            break;
        }
        if (this.charCodeAt(i) > 255) {
            position += 2;
            result.push(this.substr(i, 1));
        }
        else {
            position++;
            result.push(this.substr(i, 1));
        }
    }
    return result.join("") + tale;
}