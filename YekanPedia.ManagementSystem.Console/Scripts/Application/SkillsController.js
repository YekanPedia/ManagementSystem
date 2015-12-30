/// <reference path="../JQuery/jquery-1.10.2.min.js" />  function addskillComplete(data) {
    var result = JSON.parse(data.responseText);
    if (result.IsSuccessfull && result.IsSuccessfull == true) {
        var clas = $("#skillInfo #IsPublic").val() == "true" ? "zmdi-globe c-green" : "zmdi-globe-lock c-gray";
        $("#skillList").append('<a class="lv-item z-depth-1" id="skillFragment_' + result.Result + '" href="#">' +
                         '     <div class="media">' +
                         '         <div class="pull-right">' +
                         '         </div>' +
                         '         <div class="pull-left">' +
                           '         <span data-Id=' + result.Result + ' class="closeskill">' +
                         '              <i class="zmdi zmdi-close c-red f-s-17 p-l-5"></i>' +
                         '          </span>' +
                         '          <span data-Id=' + result.Result + ' data-public=' + $("#skillInfo #IsPublic").val() + ' class="publicskill">' +
                         '             <i class="zmdi ' + clas + ' f-s-17"></i>' +
                         '          </span>' +

                         '         </div>' +
                         '         <div class="media-body p-r-0 ">' +
                         '             <div class="lv-title">' + $("#skillInfo #Topic").val() + ' - ' + $("#skillInfo #Percent").val() + '</div>' +
                         '         </div>' +
                         '     </div>' +
                         ' </a>');
        $phoenix.core.clearForm("addskillFrm");
        $("#skillInfo").removeClass('toggled');
    }
};

$(document).ready(function () {
    $(document.body).on("click", ".closeskill", function () {
        console.log(1);
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/skills/Remove",
            data: "skillsId=" + $el.attr('data-Id'),
            dataType: "json",
            success: function (response) {
                console.log(response);
                console.log($("#skillFragment_" + $el.attr('data-Id')));
                $("#skillFragment_" + $el.attr('data-Id')).fadeOut();
            }
        });
    });
    $(document.body).on("click", ".publicskill", function () {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/skills/ChangePublicState",
            data: "skillsId=" + $el.attr('data-Id'),
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