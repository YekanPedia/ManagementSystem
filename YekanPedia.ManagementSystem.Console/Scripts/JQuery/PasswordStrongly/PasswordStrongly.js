//http://jsfiddle.net/aleem/KE3RB/8/
$().ready(function () {
    $('.PasswordStrongly').keyup(function (e) {
        var strongRegex = new RegExp("^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
        //var mediumRegex = new RegExp("^(?=.{7,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))).*$", "g");
        //var enoughRegex = new RegExp("(?=.{6,}).*", "g");
        if (strongRegex.test($(this).val())) {
            $('.has-passwordStrongly').removeClass('has-warning');
            $(".has-passwordStrongly .help-block").html('');
            $(".has-passwordStrongly .form-control-feedback").removeClass('zmdi-alert-triangle');

        } else {
            $('.has-passwordStrongly').addClass('has-warning');
            $(".has-passwordStrongly .help-block").html('امنیت کلمه عبورانتخابی پایین است');
            $(".has-passwordStrongly .form-control-feedback").addClass('zmdi-alert-triangle');
        }
        return true;
    });
});