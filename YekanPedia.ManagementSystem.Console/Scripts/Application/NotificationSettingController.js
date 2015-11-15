/// <reference path="../JQuery/jquery-1.10.2.min.js" />
function onEditNotificationSettingComplete(result) {
    response = JSON.parse(result.responseText);
    if (response.IsSuccessfull == true) {
        var $el = $("#notification_" + response.Result);
        console.log($el);
        $el.removeClass('toggled');
        console.log($el.find('.pmbb-edit #Sms').val());
        $el.find('.view_Sms')[0].checked = $el.find('.pmbb-edit #Edit_Sms')[0].checked;
        $el.find('.view_Email')[0].checked = $el.find('.pmbb-edit #Edit_Email')[0].checked;
        $el.find('.view_Telegram')[0].checked = $el.find('.pmbb-edit #Edit_Telegram')[0].checked;
        $el.find('.view_Website')[0].checked = $el.find('.pmbb-edit #Edit_Website')[0].checked;
        return;
    }
    //show error
}
function onEditNotificationSettingComplete_1(result) {
    onEditNotificationSettingComplete(result);
}
function onEditNotificationSettingComplete_2(result) {

    onEditNotificationSettingComplete(result);
}
function onEditNotificationSettingComplete_3(result) {
    onEditNotificationSettingComplete(result);
}
function onEditNotificationSettingComplete_4(result) {
    onEditNotificationSettingComplete(result);
}
function onEditNotificationSettingComplete_5(result) {
    onEditNotificationSettingComplete(result);
}