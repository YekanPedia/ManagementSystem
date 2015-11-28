/// <reference path="../JQuery/jquery-1.10.2.min.js" />
$().ready(function () {

    $(document.body).on('click', '.changeSchedulerState', function (event) {
        var $el = $(this);
        var id = $el.attr('data-Id');
        $.ajax({
            type: "POST",
            url: $el.attr('data-url'),
            dataType: "json",
            success: function (response) {
                if (response==true) {
                    $el.fadeOut();
                    if (id == "1") {
                        setTimeout(function () { $el.next().fadeIn() }, 400);
                        $("#" + $el.attr('data-name')).find($(".schedulerPausable"))[0].checked = true;
                    } else {
                        setTimeout(function () { $el.prev().fadeIn() }, 400);
                        $("#" + $el.attr('data-name')).find($(".schedulerPausable"))[0].checked = false;
                    }
                }
            }
        });
    });
});