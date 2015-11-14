$().ready(function () {

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

    $(".deleteClassTime").click(function () {
        var $el = $(this);
        swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "classTimeId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام حذف اطلاعات", "اطلاعات ذخیره شده حذف شد", "success");
                        $("#ClassTime_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }
            });

        });
    });
});

