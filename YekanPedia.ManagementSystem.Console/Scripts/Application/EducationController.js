﻿/// <reference path="../JQuery/jquery-1.10.2.min.js" />  function addEducationComplete(data) {
    var result = JSON.parse(data.responseText);
    if (result.IsSuccessfull && result.IsSuccessfull == true) {
        var clas = $("#educationInfo #IsPublic").val() == "true" ? "zmdi-globe c-green" : "zmdi-globe-lock c-red";
        $("#educationList").append('<a class="lv-item z-depth-1" href="">' +
                         '     <div class="media">' +
                         '         <div class="pull-right">' +
                         '         </div>' +
                         '         <div class="pull-left">' +
                         '             <i class="zmdi ' + clas + ' ) f-s-17"></i>' +
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