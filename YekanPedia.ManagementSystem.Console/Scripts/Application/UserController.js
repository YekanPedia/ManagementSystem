/// <reference path="../JQuery/jquery-1.10.2.min.js" />
$().ready(function () {

    $(document.body).on('click', '.deactiveUser', function (event) {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: $el.attr('data-url'),
            data: "userId=" + $el.attr('data-userId') + "&status=false",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull) {
                    $el.fadeOut();
                    setTimeout(function () { $el.next().fadeIn() }, 400);
                    $("#" + $el.attr('data-userId')).find($(".activeUserChecked"))[0].checked = false;
                }
            }
        });
    });

    $(document.body).on('click', ".activeUser", function () {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: $el.attr('data-url'),
            data: "userId=" + $el.attr('data-userId') + "&status=true",
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull) {
                    $el.fadeOut();
                    setTimeout(function () { $el.prev().fadeIn() }, 400);
                    $("#" + $el.attr('data-userId')).find($(".activeUserChecked"))[0].checked = true;
                }
            }
        });
    });

    $(document.body).on('click', ".sendPrivateMessageModal", function () {
  
        $("#UserId_PrivateMessage").val($(this).attr('data-userId'));
    });

    
});
function onSendPrivateNotificationComplete(result) {
        response = JSON.parse(result.responseText);
        if (response.IsSuccessfull == true) {
            $("#message_PrivateMessage").val('');
            $('#sendPrivateMessageModal').modal('toggle');
            return;
        }
        //show Error
    }