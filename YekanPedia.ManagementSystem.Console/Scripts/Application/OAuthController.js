/// <reference path="../JQuery/jquery-1.10.2.min.js" />
function onRegisterComplete(result) {
    result = JSON.parse(result.responseText);
    if (result.IsSuccessfull === true) {
        $phoenix.core.clearForm('RegisterFrm');
        $('#l-register').removeClass('toggled');
        $('#l-registerComplete').addClass('toggled');
        return;
    }
    $phoenix.core.displayValidatioError(result);
}

$().ready(function () {
    $('.rememberMe').click(function () {
        $("#rememberMe").val($(this)[0].checked);
    });
    $('.Unique').blur(function () {
        var $el = $(this);
        if ($el.hasClass('valid')) {
            $el.parent().parent().find('.form-control-feedback').addClass('rotate zmdi-refresh');
            $.ajax({
                type: "POST",
                url: $el.attr('data-url'),
                data: "email=" + $el.val(),
                dataType: "json",
                success: function (response) {
                    if (response.Result == true) {
                        $el.removeClass('valid').addClass('input-validation-error');
                        ShowError($el, response.Message);
                        //input-validation-error
                    } else {
                        $(this).addClass('valid').removeClass('input-validation-error');
                        HideError($el);
                    }
                    $el.parent().parent().find('.form-control-feedback').removeClass('rotate zmdi-refresh');
                },
                error: function () {
                    $el.parent().parent().find('.form-control-feedback').removeClass('rotate zmdi-refresh');
                }
            });
        }
    });
});