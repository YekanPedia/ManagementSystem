﻿/// <reference path="../JQuery/jquery-1.10.2.min.js" /> $().ready(function () {
     $(".deleteMaterial").click(function () {
        var $el = $(this);         swal({
            title: $el.attr('data-message'),             text: '',             type: "warning",             showCancelButton: true,             confirmButtonColor: "#4285F4",             confirmButtonText: "بلی",             cancelButtonText: "انصراف",             closeOnConfirm: false
        }, function () {
            $.ajax({
                type: "POST",                 url: $el.attr('data-url'),                 data: "ieltsMaterialId=" + $el.attr('data-Id') + "&path=" + $el.attr('data-path'),                 dataType: "json",                 success: function (response) {
                    if (response.IsSuccessfull) {
                        swal("اتمام حذف اطلاعات", "اطلاعات ذخیره شده حذف شد", "success");                         $("#ieltsMaterialId_" + $el.attr('data-id')).remove();
                    } else {
                        swal("لغو حذف اطلاعات", response.Message, "error");
                    }
                }
            });
         });
    });     $("#TopicId").change(function () {
        $.ajax({
            type: "Get",             url: "/IELTS/GetTopic?topicId=" + $(this).val(),             dataType: "json",             success: function (response) {
                console.log(response);
                $(".topicDetail").html(response);
            }
        });
    });
});