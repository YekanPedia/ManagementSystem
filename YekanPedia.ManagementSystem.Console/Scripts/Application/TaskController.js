/// <reference path="../JQuery/jquery-1.10.2.min.js" />
$().ready(function () {

    $(document.body).on('click', '.taskDone', function (event) {
        var $el = $(this);
        var url = "";
        $.ajax({
            type: "POST",
            url: $el.attr('data-url'),
            data: "taskId=" + $el.attr('data-id'),
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull == true) {
                    $(".task_" + $el.attr('data-id')).remove();
                    $(".taskCount").html(parseInt($(".taskCount").html()) - 1);
                }
            }
        });
    });

    $(document.body).on('click', '#addTask', function (event) {
        var $el = $(this);
        var url = "";
        if ($("#classId").val() != "") {
            url = $el.attr('data-addTaskToClass');
        } else {
            url = $el.attr('data-addTaskToUser');
        }
        $.ajax({
            type: "POST",
            url: url,
            data: "userId=" + $("#UserId").val() + "&message=" + $("#Subject").val() + "&classId=" + $("#classId").val(),
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull == true & $("#classId").val() == "") {
                    $("#tasksList").append("<div class='checkbox media m-r-20'>" +                                "    <div class='media-body'>" +                                "        <div>" +                                "            <input type='checkbox'     class='EnableCheckbox' data-id='" + response.Result + "'>" +                                "            <i class='input-helper'></i>" +                                "            <div>" + $("#Subject").val() + "</div>" +                                "        </div>" +                                "    </div>" +                                "</div>");
                }
            }
        });
    });
    $(document.body).on('click', '.checkbox-taskDone', function (event) {
        var $el = $(this);
        var url = "";
        $.ajax({
            type: "POST",
            url: $el.attr('data-url'),
            data: "taskId=" + $el.attr('data-id'),
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull == true) {
                    $(".task_" + $el.attr('data-id')).remove();
                    $(".taskCount").html(parseInt($(".taskCount").html()) - 1);
                }
            }
        });
    });
});