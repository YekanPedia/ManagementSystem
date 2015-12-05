/// <reference path="../JQuery/Maps/1.0.0.51205/gsa.js" />
/// <reference path="../JQuery/jquery-1.10.2.min.js" />
$().ready(function () {
    var map_option = new gsa.maps.MapOption();
    map_option.zoom = 15;
    map_option.mapElement = "mapElement";
    map_option.setPointTemplate = 'مکان جدید موسسه';
    map_option.setPointable = true;
    map_option.onSetPoint = function (point) {
        $("#Latitude").val(point.lat);
        $("#Longitude").val(point.lng);
    }
    var centerPoint = new gsa.maps.LatLng($("#Latitude").val(), $("#Longitude").val());
    var map_obj = new gsa.maps.Map(map_option).load();
    map_obj.setMyLocation({
        position: centerPoint, clickable: true, template: function () {
            return 'مکان فعلی موسسه';
        }
    }).setCenterPoint(centerPoint);
});