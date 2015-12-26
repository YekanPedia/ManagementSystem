/// <reference path="../JQuery/jquery-1.10.2.min.js" />  function addworkComplete(data) {
    var result = JSON.parse(data.responseText);
    if (result.IsSuccessfull && result.IsSuccessfull == true) {
        var clas = $("#workInfo #IsPublic").val() == "true" ? "zmdi-globe c-green" : "zmdi-globe-lock c-gray";
        $("#workList").append('<a class="lv-item z-depth-1" id="workFragment_' + result.Result + '" href="#">' +
                         '     <div class="media">' +
                         '         <div class="pull-right">' +
                         '         </div>' +
                         '         <div class="pull-left">' +
                           '         <span data-Id=' + result.Result + ' class="closework">' +
                         '              <i class="zmdi zmdi-close c-red f-s-17 p-l-5"></i>' +
                         '          </span>' +
                         '          <span data-Id=' + result.Result + ' data-public=' + $("#workInfo #IsPublic").val() + ' class="publicwork">' +
                         '             <i class="zmdi ' + clas + ' f-s-17"></i>' +
                         '          </span>' +

                         '         </div>' +
                         '         <div class="media-body p-r-0 ">' +
                         '             <div class="lv-title">' + $("#workInfo #Company").val() + ' - ' + $("#workInfo #Position").val() + '</div>' +
                         '             <small class="lv-small">' +
                                           $("#workInfo #WorkStartYear").val() + ' - ' + $("#workInfo #WorkFinishYear").val() +
                         '             </small>' +
                         '         </div>' +
                         '     </div>' +
                         ' </a>');
        $phoenix.core.clearForm("addworkFrm");
        $("#workInfo").removeClass('toggled');
    }
};

$(document).ready(function () {
    $(document.body).on("click", ".closework", function () {
        console.log(1);
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/Work/Remove",
            data: "workId=" + $el.attr('data-Id'),
            dataType: "json",
            success: function (response) {
                console.log(response);
                console.log($("#workFragment_" + $el.attr('data-Id')));
                $("#workFragment_" + $el.attr('data-Id')).fadeOut();
            }
        });
    });
    $(document.body).on("click", ".publicwork", function () {
        var $el = $(this);
        $.ajax({
            type: "POST",
            url: "/Work/ChangePublicState",
            data: "workId=" + $el.attr('data-Id'),
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