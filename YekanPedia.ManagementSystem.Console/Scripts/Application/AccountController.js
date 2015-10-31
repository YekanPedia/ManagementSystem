/// <reference path="../JQuery/jquery-1.10.2.min.js" />
function EditAboutMeComplete(result) {
    response = JSON.parse(result.responseText);
    if (response.Result == true) {
        $('#AboutMePanel').removeClass('toggled');
        $('#AboutMePanel').find('.pmbb-view').html($('#AboutMe').val());
        return;
    }
    $phoenix.core.displayValidatioError(result);
}

function EditBasicInfoComplete(result) {
    response = JSON.parse(result.responseText);
    if (response.IsSuccessfull == true) {
        $('#BasicInfoPanel').removeClass('toggled');
        $('#BasicInfoPanel').find('#DetailSex').html($('#Sex').val());
        $('#BasicInfoPanel').find('#DetailFullName').html($('#FullName').val());
        $('#BasicInfoPanel').find('#DetailBirthDate').html($('#BirthDate').val());
        return;
    }
    $phoenix.core.displayValidatioError(response);
}

function EditCallInfoComplete(result) {
    response = JSON.parse(result.responseText);
    console.log(response);
    if (response.IsSuccessfull == true) {
      
        $('#CallInfoPanel').removeClass('toggled');
        $('#CallInfoPanel').find('#DetailMobile').html($('#Mobile').val());
        $('#CallInfoPanel').find('#DetailEmail').html($('#Email').val());
        $('#CallInfoPanel').find('#DetailTwitter').html($('#Twitter').val());
        $('#CallInfoPanel').find('#DetailFacebook').html($('#Facebook').val());
        return;
    }
    $phoenix.core.displayValidatioError(response);
}