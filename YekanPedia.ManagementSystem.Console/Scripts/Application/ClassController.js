﻿$().ready(function () {

    $('#classDataGrid').bootgrid({
        css: {
            icon: 'zmdi icon',
            iconColumns: 'zmdi zmdi-view-module',
            iconDown: 'zmdi zmdi-chevron-down',
            iconRefresh: 'zmdi zmdi-refresh',
            iconUp: 'zmdi zmdi-expand-less'
        },
        formatters: {
            'commands': function (column, row) {
                return "<div class='btn-group'>" +
                       "<a class='btn btn-default  waves-effect'  href='/Class/EditClass?classId=" + row.ClassId + "'><i class='zmdi zmdi-edit'></i></a>" +
                       "<a class='btn btn-default  waves-effect' href=''><i class='zmdi zmdi-plus'></i></a>" +
                       "<a class='btn btn-default  waves-effect' href='/Class/AddClassTime?classId=" + row.ClassId + "'><i class='zmdi zmdi-calendar'></i></a>" +
                    "</div>";

            }
        }
    });

    (function () {
        if ($("#Color").val() != '') {
            $('.event-tag > span').removeClass('selected');
            $('.event-tag > span[data-color=' + $("#Color").val() + ']').addClass('selected');
        } else {
            $("#Color").val($('.selected').attr('data-color'));
        }

        $('.event-tag > span').click(function () {
            $('.event-tag > span').removeClass('selected');
            $(this).addClass('selected');
            $('#Color').val($(this).attr('data-color'));
        });
    })();
});

