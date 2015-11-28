/// <reference path="../JQuery/jquery-1.10.2.min.js" /> $().ready(function () {
     $(".completeSessionRequestWrite").click(function () {
         var $el = $(this);         swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "sessionRequestId=" + $el.attr('data-Id'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام", "عملیات با موفقیت انجام شد", "success");                         $("#sessionRequest_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }, error: function () {
                    swal("لغو حذف اطلاعات", response.Message, "error");
                }
            });
        });
    });
});