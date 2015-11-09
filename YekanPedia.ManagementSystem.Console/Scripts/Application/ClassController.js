$().ready(function () {

    $('#classDataGrid').bootgrid({
        css: {
            icon: 'zmdi icon',
            iconColumns: 'zmdi-view-module',
            iconDown: 'zmdi-expand-more',
            iconRefresh: 'zmdi-refresh',
            iconUp: 'zmdi-expand-less'
        },
        formatters: {
            "commands": function (column, row) {
                return "<button type=\"button\" class=\"btn btn-icon command-edit\" data-row-id=\"" + row.SessionCount + "\"><span class=\"zmdi zmdi-edit\"></span></button> " +
                    "<button type=\"button\" class=\"btn btn-icon command-delete\" data-row-id=\"" + row.SessionCount + "\"><span class=\"zmdi zmdi-delete\"></span></button>";
            }
        }
    });

    (function () {
        $('.event-tag > span').click(function () {
            $('.event-tag > span').removeClass('selected');
            $(this).addClass('selected');
            $("#Color").val($(this).attr('data-color'));
        });
    })();
});

