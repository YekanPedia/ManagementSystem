/// <reference path="../JQuery/jquery-1.10.2.min.js" />  function addworkComplete(data) {
    var data = JSON.parse(data.responseText);
    if (data.IsSuccessfull && data.IsSuccessfull == true) {
        var clas = $("#workInfo #IsPublic").val() == "true" ? "zmdi-globe c-green" : "zmdi-globe-lock c-red";
        $("#workList").append('<a class="lv-item z-depth-1" href="">' +
                         '     <div class="media">' +
                         '         <div class="pull-right">' +
                         '         </div>' +
                         '         <div class="pull-left">' +
                         '             <i class="zmdi ' + clas + ' ) f-s-17"></i>' +
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