/// <reference path="../JQuery/jquery-1.10.2.min.js" />  $().ready(function () {
     $(".sendNotification").click(function () {
        var $el = $(this);         swal({
            title: $el.attr('data-message'),             text: '',             type: "info",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "sessionId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام ارسال پیام ها", "پیام ها با موفقیت برای کاربران ارسال شد", "success");
                    } else {
                        swal("درخواست با خطا مواجه شد", response.Message, "error");
                    }
                },                 error: function () {
                    swal("درخواست با خطا مواجه شد", response.Message, "error");
                }
            });
        });
    });     $(".deleteSession").click(function () {

        var $el = $(this);
        swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "sessionId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام حذف اطلاعات", "اطلاعات ذخیره شده حذف شد", "success");
                        $("#session_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }
            });

        });
    });     $(".fileAddress").click(function () {
        $.ajax({
            type: "POST",             url: $(this).attr('data-url'),             data: "sessionId=" + $(this).attr('data-Id'),             dataType: "json",             success: function (response) {
                console.log(response);
                $("#directoryAddress").html(response);
                $("#directoryAddressModal").modal('toggle');
            }
        });
    });
    $(".syncMaterial").click(function () {
        $.ajax({
            type: "POST",             url: $(this).attr('data-url'),             data: "sessionId=" + $(this).attr('data-Id'),             dataType: "json",             success: function (response) {
                console.log(response);
                swal("بروز رسانی فایل ها", "بروز رسانی فایل ها با موفقیت انجام شد", "success");             }, error: function () {
                swal("بروز رسانی فایل ها", "بروز رسانی فایل ها با خطا مواجه شد", "error");
            }
        });
    });
});