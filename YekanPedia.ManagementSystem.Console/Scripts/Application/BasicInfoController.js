﻿/// <reference path="../JQuery/jquery-1.10.2.min.js" /> $().ready(function () {
    $(".EnableCheckbox").on("click", function () {
        var $el = $(this);         $.ajax({
            type: "POST",             url: $el.attr('data-url'),             data: "id=" + $el.attr('data-Id') + "&status=" + $el[0].checked,             dataType: "json",             success: function (response) {
                if (!response.IsSuccessfull) {
                    $el[0].checked = !$el[0].checked;                     swal("", response.Message, "error");
                }
            },             error: function () {
                $el[0].checked = !$el[0].checked;
            }
        });
    });     $("#courseSaveBtn").click(function () {
        addItem($("#courseBody"), $("#courseName").val(), $(this).attr('data-url'), $(this).attr('data-updateUrl'))
    });     $("#classTypeSaveBtn").click(function () {
        addItem($("#classTypeBody"), $("#classType").val(), $(this).attr('data-url'), $(this).attr('data-updateUrl'))
    });     $("#BookSaveBtn").click(function () {
        addItem($("#bookBody"), $("#book").val(), $(this).attr('data-url'), $(this).attr('data-updateUrl'))
    });     $("#ExamTypeSaveBtn").click(function () {
        addItem($("#examTypeBody"), $("#examType").val(), $(this).attr('data-url'), $(this).attr('data-updateUrl'))
    });     function addItem($el, text, url, updateUrl) {
        $.ajax({
            type: "POST",             url: url,             data: "text=" + text,             dataType: "json",             success: function (response) {
                if (response.IsSuccessfull) {
                    $el.append("<div class='checkbox media'>" +                                "    <div class='media-body'>" +                                "        <label>" +                                "            <input type='checkbox' checked='true' data-url='" + updateUrl + "' class='EnableCheckbox' data-id='" + response.Result + "'>" +                                "            <i class='input-helper'></i>" +                                "            <span>" + text + "</span>" +                                "        </label>" +                                "    </div>" +                                "</div>");
                }
            },             error: function () {
             }
        });
     }
});