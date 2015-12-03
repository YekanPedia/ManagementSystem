/// <reference path="../JQuery/jquery-1.10.2.min.js" />
function onEditSettingComplete(result) {
    response = JSON.parse(result.responseText);
    if (response.IsSuccessfull == true) {
        var $el = $("#setting");
        $el.removeClass('toggled');
        $el.find('#BirthDateText_View').html($el.find('.pmbb-edit #BirthDateText').val());
        $el.find('#FilesPersistance_View').html($el.find('.pmbb-edit #FilesPersistance').val());
        return;
    }
    //show error
}