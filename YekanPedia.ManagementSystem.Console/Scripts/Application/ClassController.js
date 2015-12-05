﻿/// <reference path="../JQuery/jquery-1.10.2.min.js" />
 function sendClassPrivateMessageModal(classId) {
    $("#ClassId_PrivateMessage").val(classId);     $("#message_PrivateMessage").val('');     $('#sendClassPrivateMessageModal').modal('toggle');
}; function onSendClassPrivateNotificationComplete(result) {
    response = JSON.parse(result.responseText);     if (response.IsSuccessfull == true) {
        $("#message_PrivateMessage").val('');         $('#sendClassPrivateMessageModal').modal('toggle');         return;
    }     //show Error } $().ready(function () {
    $('#classDataGrid').bootgrid({
        css: {
            icon: 'zmdi icon',             iconColumns: 'zmdi zmdi-view-module',             iconDown: 'zmdi zmdi-chevron-down',             iconRefresh: 'zmdi zmdi-refresh',             iconUp: 'zmdi zmdi-expand-less'
        },         formatters: {
            'commands': function (column, row) {
                return "<div class='btn-group'>" +                        "<a class='btn btn-info  waves-effect'  href='/Class/EditClass?classId=" + row.ClassId + "'><i class='zmdi zmdi-edit f-s-17'></i></a>" +                        "<a class='btn btn-info  waves-effect' href='/Session/Add?classId=" + row.ClassId + "'><i class='zmdi zmdi-attachment-alt f-s-17'></i></a>" +                        "<a class='btn btn-info  waves-effect' href='/Class/AddClassTime?classId=" + row.ClassId + "'><i class='zmdi zmdi-calendar f-s-17'></i></a>" +                        "<a class='btn btn-info  waves-effect sendClassPrivateMessageModal' onclick=sendClassPrivateMessageModal('" + row.ClassId + "') href='#sendClassPrivateMessageModal' data-classId='" + row.ClassId + "' ><i class='zmdi zmdi-notifications f-s-17'></i></a>" +                     "</div>";
            }
        }
    });      (function () {
        if ($("#Color").val() != '') {
            $('.event-tag > span').removeClass('selected');             $('.event-tag > span[data-color=' + $("#Color").val() + ']').addClass('selected');
        } else {
            $("#Color").val($('.selected').attr('data-color'));
        }          $('.event-tag > span').click(function () {
            $('.event-tag > span').removeClass('selected');             $(this).addClass('selected');             $('#Color').val($(this).attr('data-color'));
        });
    })();      $(".deleteClassTime").click(function () {
        var $el = $(this);         swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "classTimeId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام حذف اطلاعات", "اطلاعات ذخیره شده حذف شد", "success");                         $("#ClassTime_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }
            });
         });
    });      $("#SessionCount").blur(function () {
        var sessionCount = $(this).val();
        var date = $("#StartDateSh").val();
        if (date == "" || sessionCount == "")
            return;         addDayToStartDateSh($("#FinishDateSh"), date, ((parseInt(sessionCount) / 2) * 7) - 7);     });     $("#StartDateSh").blur(function () {
        var date = $(this).val();
        var sessionCount = $("#SessionCount").val();
        if (date == "" || sessionCount == "")
            return;         addDayToStartDateSh($("#JustificationDateSh"), date, -7);         addDayToStartDateSh($("#FinishDateSh"),date, ((parseInt(sessionCount) / 2) * 7) - 7);
    });
    function addDayToStartDateSh($el,date,addDate) {
        var persianDate = date.split('/');         var jd = persian_to_jd(parseInt(persianDate[0]), parseInt(persianDate[1]), parseInt(persianDate[2]));
        var gre = jd_to_gregorian(jd);
        var greDate = new Date();
        greDate.setFullYear(gre[0], gre[1], gre[2]);
        greDate.setDate(greDate.getDate() +addDate );
        jd = gregorian_to_jd(greDate.getFullYear(), greDate.getMonth(), greDate.getDate());
        date = jd_to_persian(jd);
        $el.val(date[0] + "/" + (date[1] < 10 ? "0" + date[1] : date[1]) + "/" + (date[2] < 10 ? "0" + date[2] : date[2]));
    }
});  