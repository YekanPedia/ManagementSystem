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
function onRecoveryPasswordComplete(result) {
    result = JSON.parse(result.responseText);
    if (result.IsSuccessfull === true) {
        $("#recoveryPassword").removeClass('has-error');
        $("#recoveryPasswordError").html('');

        $('#l-forget-password').removeClass('toggled');
        $('#l-recoveryPasswordComplete').addClass('toggled');

        return;
    }
    $("#recoveryPasswordError").html(result.Message);
    $("#recoveryPassword").addClass('has-error');

}

$().ready(function () {
    localStorage.setItem('ma-menu-Id', 1);
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