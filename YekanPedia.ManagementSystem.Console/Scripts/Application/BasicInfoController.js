/// <reference path="../JQuery/jquery-1.10.2.min.js" />


$().ready(function () {
    $("#courseSaveBtn").click(function () {
        console.log($("#courseName").val());
        addItem($("#courseBody"), $("#courseName").val(), $(this).attr('data-url'))
    });

    function addItem($el, text, url) {
        $.ajax({
            type: "POST",             url: url,             data: "text=" + text,             dataType: "json",             success: function (response) {
                if (response.IsSuccessfull) {
                    $el.append("<div class='checkbox media'>" +
                               "    <div class='media-body'>" +
                               "        <label>" +
                               "            <input type='checkbox' checked='true' data-url='/Course/ChangeCourseStatus' class='EnableCheckbox' data-id='" + response.Result + "'>" +
                               "            <i class='input-helper'></i>" +
                               "            <span>" + text + "</span>" +
                               "        </label>" +
                               "    </div>" +
                               "</div>");
                }
            },
            error: function () {

            }
        });

    }
});