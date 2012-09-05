
$.extend($.fn, {
    hideJmodal: function() {
        $('#jmodal-overlay').animate({ opacity: 0 }, function() { $(this).css('display', 'none') });
        $('#jquery-jmodal').animate({ opacity: 0 }, function() { $(this).css('display', 'none') });

    },
    getCss: function(key) {
        var v = parseInt(this.css(key));
        if (isNaN(v))
            return false;
        return v;
    },
    jmodal: function(setting) {
        var ps = $.fn.extend({
            data: {},
            marginTop: 180,
            buttonText: { ok: 'Ok', cancel: 'Cancel' },
            okEvent: function(e) { },
            initWidth: 400,
            fixed: false,
            title: 'JModal Dialog',
            content: 'This is a jquery plugin!',
            zIndex: 20,
            opacity: .7,
            handler: '.jmodal-title',
            onMove: function() { },
            onDrop: function() { }
        }, setting);

        ps.docWidth = $(document).width();
        ps.docHeight = $(document).height();

        if ($('#jquery-jmodal').length == 0) {
            $('<div id="jmodal-overlay" class="jmodal-overlay"/>' +
                '<div class="jmodal-main" id="jquery-jmodal" >' +
                    '<table cellpadding="0" cellspacing="0">' +
                        '<tr>' +
                            '<td class="jmodal-top-left jmodal-png-fiexed">&nbsp;</td>' +
                            '<td class="jmodal-border-top jmodal-png-fiexed">&nbsp;</td>' +
                            '<td class="jmodal-top-right jmodal-png-fiexed">&nbsp;</td>' +
                        '</tr>' +
                    '<tr>' +
                        '<td class="jmodal-border-left jmodal-png-fiexed">&nbsp;</td>' +
                        '<td >' +
                            '<div class="jmodal-title" />' +
                            '<div class="jmodal-content" id="jmodal-container-content" />' +
                            '<div class="jmodal-bottom">' +
                                '<input type="button" value="' + ps.buttonText.ok + '" />&nbsp;&nbsp;<input type="button" value="' + ps.buttonText.cancel + '" />' +
                            '</div>' +
                        '</td>' +
                        '<td class="jmodal-border-right jmodal-png-fiexed">&nbsp;</td>' +
                    '</tr>' +
                    '<tr>' +
                        '<td class="jmodal-bottom-left jmodal-png-fiexed">&nbsp;</td>' +
                        '<td class="jmodal-border-bottom jmodal-png-fiexed">&nbsp;</td>' +
                        '<td class="jmodal-bottom-right jmodal-png-fiexed">&nbsp;</td>' +
                    '</tr>' +
                    '</table>' +
                '</div>').appendTo($(document.body));
        }
        else {
            $('#jmodal-overlay').css({ opacity: 0, 'display': 'block' });
            $('#jquery-jmodal').css({ opacity: 0, 'display': 'block' });
        }
        $('#jmodal-overlay').css({
            height: ps.docHeight,
            opacity: 0
        }).animate({ opacity: 0.5 });

        $('#jquery-jmodal').css({
            position: (ps.fixed ? 'fixed' : 'absolute'),
            width: ps.initWidth,
            left: (ps.docWidth - ps.initWidth) / 2,
            
            top: (ps.marginTop + document.documentElement.scrollTop)
        }).animate({ opacity: 1 });

        $('#jquery-jmodal')
            .find('.jmodal-title')
                .html(ps.title)
                    .next()
                        .next()
                            .children('input:first-child')
                                .attr('value', ps.buttonText.ok)
                                    .unbind('click')
                                        .bind('click', function(e) {
                                            var eContent = $('#jmodal-container-content');
                                            eContent.holder = $('#jquery-jmodal');
                                            var args = { complete: $.fn.hideJmodal,body:eContent };
                                            var okEventReturnValue = ps.okEvent(ps.data, args);
                                            //var okEventReturnValue = ps.okEvent(eContent);
											
                                            if (!okEventReturnValue) {
                                                //{Title:不关闭窗口,Author:Colin,Date:2010-4-20,Remark:应用层自由控制窗口是否关闭}
                                                $.fn.hideJmodal();
                                            }
                                            else {
                                                $.fn.hideJmodal();
                                            }
											
                                        })
                                            .next()
                                                .attr('value', ps.buttonText.cancel)
                                                    .one('click', function() {
                                                        $.fn.hideJmodal();
                                                    });
        if (typeof ps.content == 'string') {
            $('#jmodal-container-content').html(ps.content);
        }
        if (typeof ps.content == 'function') {
            var e = $('#jmodal-container-content');
            e.holder = $('#jquery-jmodal');
            ps.content(e);
        }

        var dragndrop = {
            drag: function(e) {
                var dragData = e.data.dragData;
                dragData.target.css({
                    left: dragData.left + e.pageX - dragData.offLeft,
                    top: dragData.top + e.pageY - dragData.offTop
                });
                dragData.handler.css({ cursor: 'move' });
                dragData.onMove(e);
            },
            drop: function(e) {
                var dragData = e.data.dragData;
                dragData.target.css(dragData.oldCss); //.css({ 'opacity': '' });
                dragData.handler.css('cursor', 'move');
                dragData.onDrop(e);
                $(document).unbind('mousemove', dragndrop.drag)
                    .unbind('mouseup', dragndrop.drop);
            }
        }
        return $('#jquery-jmodal').each(function() {
            var me = this;
            var handler = null;
            if (typeof ps.handler == 'undefined' || ps.handler == null)
                handler = $(me);
            else
                handler = (typeof ps.handler == 'string' ? $(ps.handler, this) : ps.handle);
            handler.bind('mousedown', { e: me }, function(s) {
                var target = $(s.data.e);
                var oldCss = {};
                if (target.css('position') != 'absolute') {
                    try {
                        target.position(oldCss);
                    } catch (ex) { }
                    target.css('position', 'absolute');
                }
                oldCss.cursor = target.css('cursor') || 'default';
                oldCss.opacity = target.getCss('opacity') || 1;
                var dragData = {
                    left: oldCss.left || target.getCss('left') || 0,
                    top: oldCss.top || target.getCss('top') || 0,
                    width: target.width() || target.getCss('width'),
                    height: target.height() || target.getCss('height'),
                    offLeft: s.pageX,
                    offTop: s.pageY,
                    oldCss: oldCss,
                    onMove: ps.onMove,
                    onDrop: ps.onDrop,
                    handler: handler,
                    target: target
                }
                target.css('opacity', ps.opacity);
                $(document).bind('mousemove', { dragData: dragData }, dragndrop.drag)
                    .bind('mouseup', { dragData: dragData }, dragndrop.drop);
            });
        });
    }
})