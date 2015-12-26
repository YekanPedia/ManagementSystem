/// <reference path="../JQuery/jquery-1.10.2.min.js" />  function addEducationComplete(data) {
    var result = JSON.parse(data.responseText);
    if (result.IsSuccessfull && result.IsSuccessfull == true) {
        var clas = $("#educationInfo #IsPublic").val() == "true" ? "zmdi-globe c-green" : "zmdi-globe-lock c-gray";
        $("#educationList").append('<a class="lv-item z-depth-1" id="educationFragment_' + result.Result + '" href="#">' +
                         '     <div class="media">' +
                         '         <div class="pull-right">' +
                         '         </div>' +
                         '         <div class="pull-left">' +
                         '         <span data-Id=' + result.Result + ' class="closeEducation">' +
                         '              <i class="zmdi zmdi-close c-red f-s-17 p-l-5"></i>' +
                         '          </span>' +
                         '          <span data-Id=' + result.Result + ' data-public=' + $("#educationInfo #IsPublic").val() + ' class="publicEducation">' +
                         '             <i class="zmdi ' + clas + ' f-s-17"></i>' +
                         '          </span>' +
                         '         </div>' +
                         '         <div class="media-body p-r-0 ">' +
                         '             <div class="lv-title">' + $("#educationInfo #School").val() + ' - ' + $("#educationInfo #Field").val() + '</div>' +
                         '             <small class="lv-small">' +
                                           $("#educationInfo #EducateStartYear").val() + ' - ' + $("#educationInfo #EducateFinishYear").val() +
                         '             </small>' +
                         '         </div>' +
                         '     </div>' +
                         ' </a>');
        $phoenix.core.clearForm("addEducationFrm");
        $("#educationInfo").removeClass('toggled');
    }
};

$(document).ready(function () {
    $(document.body).on("click", ".closeEducation", function () {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/Education/Remove",
            data: "educationId=" + $el.attr('data-Id'),
            dataType: "json",
            success: function (response) {
                $("#educationFragment_" + $el.attr('data-Id')).fadeOut();
            }
        });
    });
    $(document.body).on("click", ".publicEducation", function () {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/Education/ChangePublicState",
            data: "educationId=" + $el.attr('data-Id'),
            dataType: "json",
            success: function (response) {
                if (response.IsSuccessfull & response.IsSuccessfull != true) {
                    return;
                }
                if ($el.attr('data-public') == 'true') {
                    $el.find('i').removeClass("zmdi-globe c-green").addClass("zmdi-globe-lock c-gray");
                    $el.attr('data-public', 'false');
                    return;
                }
                $el.find('i').removeClass("zmdi-globe-lock c-gray").addClass("zmdi-globe c-green");
                $el.attr('data-public', 'true');
            }
        });
    });
});