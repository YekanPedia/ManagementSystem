var $phoenix = {};
(function ($) {
    $phoenix.core = {
        // Clear All Elements From el Form
        clearForm: function (el) {
            $("#" + el).find("input[type=text], textarea, input[type=password]").val('');
        },
        // Display Model Error in Ajax Call
        displayValidatioError: function (data) {
            if (data.IsSuccessfull || data.IsSuccessfull == true) {
                return;
            }
            $.each(JSON.parse(data.Message), function (key, value) {
                if (value !== null) {
                    ShowError($('input[id="' + key + '"]'), value[0].ErrorMessage);
                }
            });
        }, reload: function () {
            window.location.reload();
        }, ajaxLoaderBegin: function () {
            $(document).ajaxStart(function (event, request) {
                if (loadingbarShow==false) {
                    return;                 }
                NProgress.inc();
                NProgress.inc();
            });
        },
        ajaxLoaderComplete: function () {
            $(document).ajaxComplete(function (event, request, settings) {
                loadingbarShow = true;
                NProgress.done();
            }).ajaxError(function (event, request) {
                NProgress.done();
            });
        }
    };
})(jQuery)

$(document).ready(function () {
    $phoenix.core.ajaxLoaderBegin();
    $phoenix.core.ajaxLoaderComplete();
});