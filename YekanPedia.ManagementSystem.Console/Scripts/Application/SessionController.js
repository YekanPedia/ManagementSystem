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
         var $el = $(this);         swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "sessionId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام حذف اطلاعات", "اطلاعات ذخیره شده حذف شد", "success");                         $("#session_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }
            });
        });
    });     $(".fileAddress").click(function () {
        $.ajax({
            type: "POST",             url: $(this).attr('data-url'),             data: "sessionId=" + $(this).attr('data-Id'),             dataType: "json",             success: function (response) {
                console.log(response);                 $("#directoryAddress").html(response);                 $("#directoryAddressModal").modal('toggle');
            }
        });
    });     $(".syncMaterial").click(function () {
        $.ajax({
            type: "POST",             url: $(this).attr('data-url'),             data: "sessionId=" + $(this).attr('data-Id'),             dataType: "json",             success: function (response) {
                if (response.IsSuccessfull) {
                    swal("بروز رسانی فایل ها", "بروز رسانی فایل ها با موفقیت انجام شد", "success");
                } else {
                    swal("بروز رسانی فایل ها", "بروز رسانی فایل ها با خطا مواجه شد", "error");
                }
            },             error: function () {
                swal("بروز رسانی فایل ها", "بروز رسانی فایل ها با خطا مواجه شد", "error");
            }
        });
    });     $(".sessionMaterialRequest").click(function (e) {
        e.preventDefault();         $.ajax({
            type: "POST",             url: $(this).attr('data-url'),             data: "ClassSessionId=" + $(this).attr('data-Id'),             dataType: "json",             success: function (response) {
                 if (response.IsSuccessfull) {
                    swal("درخواست بارگذاری فایل", response.Message, "success");
                } else {
                    swal("درخواست بارگذاری فایل", response.Message, "error");
                }
            }, error: function () {
                swal("درخواست بارگذاری فایل", "درخواست با خطا مواجه شد", "error");
            }
        });
    });     $(".classDetailMore").click(function () {
        if ($(this).find('i').hasClass('zmdi-chevron-down')) {
            $("#classDetailsMore").fadeIn();             $(this).find('i').removeClass('zmdi-chevron-down').addClass('zmdi-chevron-up');         } else {
            $("#classDetailsMore").fadeOut();
            $(this).find('i').removeClass('zmdi-chevron-up').addClass('zmdi-chevron-down');
        }     });
    $("#listView").click(function () {
        $("#timelineView").removeClass('active');
        $("#listView").addClass('active');
        $("#sessionTimeline").fadeOut();
        setTimeout(function () {  $("#sessionBlock").fadeIn();}, 400);
    });
    $("#timelineView").click(function () {
        $("#listView").removeClass('active');
        $("#timelineView").addClass('active');

        $("#sessionBlock").fadeOut();
        setTimeout(function () { $("#sessionTimeline").fadeIn(); }, 400);
    });
    
    
});