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
function onSendPrivateNotificationComplete(result) {
    response = JSON.parse(result.responseText);
    if (response.IsSuccessfull == true) {
        $("#message").val('');
        return;
    }
    //show Error
}
var $image;
$().ready(function () {
    bindCropper(true);
    $("#uploadImage").click(function () {
        var origin = $image.cropper('getCanvasData');
        var cropped = $image.cropper('getCropBoxData');

        var widthPercent = (cropped.width * 100) / origin.width;
        var heightPercent = (cropped.height * 100) / origin.height;
        var width = (widthPercent * origin.naturalWidth) / 100;
        var height = (heightPercent * origin.naturalHeight) / 100;
        var xPercent = ((cropped.left - origin.left) * 100) / origin.width;
        var yPercent = ((cropped.top - origin.top) * 100) / origin.height;

        var x = (xPercent * origin.naturalWidth) / 100;
        var y = (yPercent * origin.naturalHeight) / 100;
        $("#x").val(x);
        $("#y").val(y);
        $("#width").val(width);
        $("#height").val(height);
        $("#uploadFileFrm").submit();
    });
});

function bindCropper(init) {
    if (init != true) {
        $("#uploadImage").fadeIn();
    }

    if ($(".cropper-image")[0]) {
        $image = $(".cropper-image");
        $image.cropper({
            aspectRatio: 1 / 1,
            movable: false,
            zoomable: false,
            rotatable: false,
            scalable: false,
        });
    }
}