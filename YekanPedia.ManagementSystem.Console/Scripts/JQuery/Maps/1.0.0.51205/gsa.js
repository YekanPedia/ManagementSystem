/// <reference path="google.maps.d.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var gsa;
(function (gsa) {
    var bcl;
    (function (bcl) {
        var MinError = (function () {
            function MinError(code, name) {
                this.code = code;
                this.name = name;
            }
            MinError.prototype.displayError = function (message) {
                var prefix = '[' + (name ? name + ':' : '') + this.code + '] ', finalmessage;
                finalmessage = prefix + message.replace(/\{\d+\}/g, function (match) {
                    return match;
                });
                finalmessage = finalmessage + '\nhttp://cms.yekanPedia.org/map/51205/' + (this.name ? this.name + '/' : '') + this.code;
                return finalmessage;
            };
            return MinError;
        })();
        var MapOptionException = (function (_super) {
            __extends(MapOptionException, _super);
            function MapOptionException(code, message) {
                if (message === void 0) { message = ''; }
                _super.call(this, code, name);
                this.code = code;
                this.message = message;
                this.name = 'MapOption';
            }
            MapOptionException.prototype.toString = function () {
                if (this.message == '') {
                    switch (this.code) {
                        case 40401: {
                            this.message = "mapElement not found !";
                            break;
                        }
                        case 40405: {
                            this.message = "the posiotion field parameter is not set !";
                            break;
                        }
                        case 50001: {
                            this.message = "the posiotion field of MarkersOptions parameter is not set !";
                            break;
                        }
                        default: {
                            this.message = "unhandled Exception!";
                            break;
                        }
                    }
                }
                return _super.prototype.displayError.call(this, this.message);
            };
            return MapOptionException;
        })(MinError);
        bcl.MapOptionException = MapOptionException;
        var RemoteServiceException = (function (_super) {
            __extends(RemoteServiceException, _super);
            function RemoteServiceException(code, message) {
                if (message === void 0) { message = ''; }
                _super.call(this, code, name);
                this.code = code;
                this.message = message;
                this.name = 'RemoteService';
            }
            RemoteServiceException.prototype.toString = function () {
                return _super.prototype.displayError.call(this, this.message);
            };
            return RemoteServiceException;
        })(MinError);
        bcl.RemoteServiceException = RemoteServiceException;
    })(bcl = gsa.bcl || (gsa.bcl = {}));
})(gsa || (gsa = {}));
var gsa;
(function (gsa) {
    var util;
    (function (util) {
        var TypeCasting = (function () {
            function TypeCasting() {
            }
            TypeCasting.toGoogleMapsZoomControlStyle = function (zoomControlStyle) {
                switch (zoomControlStyle) {
                    case gsa.maps.ZoomControlStyle.DEFAULT: {
                        return google.maps.ZoomControlStyle.DEFAULT;
                    }
                    case gsa.maps.ZoomControlStyle.LARGE: {
                        return google.maps.ZoomControlStyle.LARGE;
                    }
                    case gsa.maps.ZoomControlStyle.SMALL: {
                        return google.maps.ZoomControlStyle.SMALL;
                    }
                    default: {
                        return google.maps.ZoomControlStyle.DEFAULT;
                    }
                }
            };
            TypeCasting.toGoogleMapsControlPosition = function (controlPosition) {
                switch (controlPosition) {
                    case gsa.maps.ControlPosition.BOTTOM_CENTER: {
                        return google.maps.ControlPosition.BOTTOM_CENTER;
                    }
                    case gsa.maps.ControlPosition.BOTTOM_LEFT: {
                        return google.maps.ControlPosition.BOTTOM_LEFT;
                    }
                    case gsa.maps.ControlPosition.BOTTOM_RIGHT: {
                        return google.maps.ControlPosition.BOTTOM_RIGHT;
                    }
                    case gsa.maps.ControlPosition.LEFT_BOTTOM: {
                        return google.maps.ControlPosition.LEFT_BOTTOM;
                    }
                    case gsa.maps.ControlPosition.LEFT_CENTER: {
                        return google.maps.ControlPosition.LEFT_CENTER;
                    }
                    case gsa.maps.ControlPosition.LEFT_TOP: {
                        return google.maps.ControlPosition.LEFT_TOP;
                    }
                    case gsa.maps.ControlPosition.RIGHT_BOTTOM: {
                        return google.maps.ControlPosition.RIGHT_BOTTOM;
                    }
                    case gsa.maps.ControlPosition.RIGHT_CENTER: {
                        return google.maps.ControlPosition.RIGHT_CENTER;
                    }
                    case gsa.maps.ControlPosition.RIGHT_TOP: {
                        return google.maps.ControlPosition.RIGHT_TOP;
                    }
                    case gsa.maps.ControlPosition.TOP_CENTER: {
                        return google.maps.ControlPosition.TOP_CENTER;
                    }
                    case gsa.maps.ControlPosition.TOP_LEFT: {
                        return google.maps.ControlPosition.TOP_LEFT;
                    }
                    case gsa.maps.ControlPosition.TOP_RIGHT: {
                        return google.maps.ControlPosition.TOP_RIGHT;
                    }
                    default: {
                        return google.maps.ControlPosition.BOTTOM_LEFT;
                    }
                }
            };
            TypeCasting.toGoogleMapsMapTypeId = function (mapTypeId) {
                switch (mapTypeId) {
                    case gsa.maps.MapTypeId.HYBRID: {
                        return google.maps.MapTypeId.HYBRID;
                    }
                    case gsa.maps.MapTypeId.ROADMAP: {
                        return google.maps.MapTypeId.ROADMAP;
                    }
                    case gsa.maps.MapTypeId.SATELLITE: {
                        return google.maps.MapTypeId.SATELLITE;
                    }
                    case gsa.maps.MapTypeId.TERRAIN: {
                        return google.maps.MapTypeId.TERRAIN;
                    }
                    default: {
                        return google.maps.MapTypeId.ROADMAP;
                    }
                }
            };
            TypeCasting.toGoogleMapsLatLngObject = function (point) {
                return new google.maps.LatLng(point.lat, point.lng);
            };
            return TypeCasting;
        })();
        util.TypeCasting = TypeCasting;
        var FunctionUtility = (function () {
            function FunctionUtility() {
            }
            FunctionUtility.isFunction = function (fn) {
                var getType = {};
                return fn && getType.toString.call(fn) === '[object Function]';
            };
            return FunctionUtility;
        })();
        util.FunctionUtility = FunctionUtility; /**
        * String Interpolation for Templates Info Window
        */
        var StringInterpolation = (function () {
            function StringInterpolation(template) {
                this.template = template;
            }
            StringInterpolation.prototype.render = function (data) {
                var delimiter = "{{}}", regex, lDel, rDel, delLen, lDelLen, regexEscape = "/([$\^\\\/()|?+*\[\]{}.\-])/g";
                delLen = delimiter.length;
                lDelLen = Math.ceil(delLen / 2);
                lDel = delimiter.substr(0, lDelLen).replace(regexEscape, "\\$1");
                rDel = delimiter.substr(lDelLen, delLen).replace(regexEscape, "\\$1") || lDel;
                regex = new RegExp(lDel + "[^" + lDel + rDel + "]+" + rDel, "g");
                return this.template.replace(regex, function (placeholder) {
                    var key = placeholder.slice(lDelLen, -lDelLen), keyParts = key.split("."), val, i = 0, len = keyParts.length;
                    if (key in data) {
                        val = data[key];
                    }
                    else {
                        val = data;
                        for (; i < len; i++) {
                            if (keyParts[i] in val) {
                                val = val[keyParts[i]];
                            }
                            else {
                                return placeholder;
                            }
                        }
                    }
                    return val;
                });
            };
            StringInterpolation.prototype.getTemplate = function () { return this.template; };
            return StringInterpolation;
        })();
        util.StringInterpolation = StringInterpolation; /**
        * singletone class for Url Helper
        */
        var UrlHelper = (function () {
            function UrlHelper() {
                if (UrlHelper._instance) {
                    throw new Error("Error: Instantiation failed: Use UrlHelper.getInstance() instead of new.");
                }
                UrlHelper._instance = this;
            }
            UrlHelper.getInstance = function () {
                return UrlHelper._instance;
            };
            UrlHelper.prototype.getMyLocationMarkerIcon = function () {
                return "http://cms.yekanPedia.org/Content/Images/Map/MyLocationMarkerIcon.png";
            };
            UrlHelper.prototype.getMarkers = function (queryString) {
                return "http://cms.yekanPedia.org/Content/Images/Map/" + queryString;
            };
            UrlHelper._instance = new UrlHelper();
            return UrlHelper;
        })();
        util.UrlHelper = UrlHelper;
    })(util = gsa.util || (gsa.util = {}));
})(gsa || (gsa = {}));
var gsa;
(function (gsa) {
    var net;
    (function (net) {
        var RemoteService = (function () {
            function RemoteService() {
            }
            RemoteService.FailureProxyCallback = function (context, arg) {
                throw new gsa.bcl.MapOptionException(60001, arg);
            };
            RemoteService.SendRequest = function (requestArgs) {
                var self = this;
                requestArgs.error = function (arg) {
                    self.FailureProxyCallback(this, arg);
                };
                return $.ajax(requestArgs);
            };
            ;
            return RemoteService;
        })();
        net.RemoteService = RemoteService;
    })(net = gsa.net || (gsa.net = {}));
})(gsa || (gsa = {}));
var gsa;
(function (gsa) {
    var maps;
    (function (maps) {
        var bcl = gsa.bcl; /**
          * MapTypeId enum defiend all available type map
          */
        (function (MapTypeId) {
            MapTypeId[MapTypeId["HYBRID"] = 0] = "HYBRID";
            MapTypeId[MapTypeId["ROADMAP"] = 1] = "ROADMAP";
            MapTypeId[MapTypeId["SATELLITE"] = 2] = "SATELLITE";
            MapTypeId[MapTypeId["TERRAIN"] = 3] = "TERRAIN";
        })(maps.MapTypeId || (maps.MapTypeId = {}));
        var MapTypeId = maps.MapTypeId; /**
         * ControlPosition enum defiend position of all element on map such as textsearch,zoom control
         */
        (function (ControlPosition) {
            ControlPosition[ControlPosition["BOTTOM_CENTER"] = 0] = "BOTTOM_CENTER";
            ControlPosition[ControlPosition["BOTTOM_LEFT"] = 1] = "BOTTOM_LEFT";
            ControlPosition[ControlPosition["BOTTOM_RIGHT"] = 2] = "BOTTOM_RIGHT";
            ControlPosition[ControlPosition["LEFT_BOTTOM"] = 3] = "LEFT_BOTTOM";
            ControlPosition[ControlPosition["LEFT_CENTER"] = 4] = "LEFT_CENTER";
            ControlPosition[ControlPosition["LEFT_TOP"] = 5] = "LEFT_TOP";
            ControlPosition[ControlPosition["RIGHT_BOTTOM"] = 6] = "RIGHT_BOTTOM";
            ControlPosition[ControlPosition["RIGHT_CENTER"] = 7] = "RIGHT_CENTER";
            ControlPosition[ControlPosition["RIGHT_TOP"] = 8] = "RIGHT_TOP";
            ControlPosition[ControlPosition["TOP_CENTER"] = 9] = "TOP_CENTER";
            ControlPosition[ControlPosition["TOP_LEFT"] = 10] = "TOP_LEFT";
            ControlPosition[ControlPosition["TOP_RIGHT"] = 11] = "TOP_RIGHT";
        })(maps.ControlPosition || (maps.ControlPosition = {}));
        var ControlPosition = maps.ControlPosition;
        (function (ZoomControlStyle) {
            ZoomControlStyle[ZoomControlStyle["DEFAULT"] = 0] = "DEFAULT";
            ZoomControlStyle[ZoomControlStyle["LARGE"] = 1] = "LARGE";
            ZoomControlStyle[ZoomControlStyle["SMALL"] = 2] = "SMALL";
        })(maps.ZoomControlStyle || (maps.ZoomControlStyle = {}));
        var ZoomControlStyle = maps.ZoomControlStyle;
        (function (Animation) {
            Animation[Animation["BOUNCE"] = 0] = "BOUNCE";
            Animation[Animation["DROP"] = 1] = "DROP";
        })(maps.Animation || (maps.Animation = {}));
        var Animation = maps.Animation;
        var KeyStore = (function () {
            function KeyStore() {
            }
            KeyStore.getKey = function (key) {
                if (key == "Namayandegan") {
                    return this.Users;
                }
                return this.Student;
            };
            KeyStore.Users = { key: "Users", template: function () { return TemplateManagment.defaulAgency(); }, className: "blue" };
            KeyStore.Student = { key: "Student", template: function () { return TemplateManagment.defaulAgency(); }, className: "yellow" };
            return KeyStore;
        })();
        maps.KeyStore = KeyStore; /**
         *
         */
        var MapOption = (function () {
            function MapOption() {
                this.mapElement = "mapElement";
                this.centerLatitude = 35.696111; //Center point View Of Map
                this.centerLongitude = 51.423055999999995; //Center point View Of Map
                this.zoom = 14;
                this.mapTypeId = gsa.maps.MapTypeId.ROADMAP;
                this.zoomControl = true;
                this.zoomControlStyle = ZoomControlStyle.DEFAULT;
                this.zoomControlPosition = ControlPosition.LEFT_BOTTOM;
                this.setPointable = false;
                this.setPointTemplate = 'برای بروز رسانی منطقه جغرافیایی خود بر روی دکمه ثبت کلیک نمایید';
            }
            MapOption.prototype.findIndexKey = function (key) {
                for (var item in this.keys) {
                    if (this.keys[item].key == key) {
                        return item;
                    }
                }
                return -1;
            };
            return MapOption;
        })();
        maps.MapOption = MapOption;
        var Map = (function () {
            function Map(_mapOption) {
                if (_mapOption === void 0) { _mapOption = new MapOption(); }
                this._mapOption = _mapOption;
            }
            Map.prototype.load = function () {
                var _this = this;
                try {
                    maps.CacheMarkers.getInstance().resetCache();
                    var $mapElement = document.getElementById(this._mapOption.mapElement);
                    if ($mapElement == null)
                        throw new bcl.MapOptionException(40401, "#" + this._mapOption.mapElement + " element not found !");
                    if (gsa.util.FunctionUtility.isFunction(this._mapOption.onStart)) {
                        this._mapOption.onStart();
                    }
                    this._mapObject = new google.maps.Map($mapElement, {
                        center: new google.maps.LatLng(this._mapOption.centerLatitude, this._mapOption.centerLongitude),
                        zoom: this._mapOption.zoom,
                        mapTypeId: gsa.util.TypeCasting.toGoogleMapsMapTypeId(this._mapOption.mapTypeId),
                        zoomControlOptions: {
                            style: gsa.util.TypeCasting.toGoogleMapsZoomControlStyle(this._mapOption.zoomControlStyle),
                            position: gsa.util.TypeCasting.toGoogleMapsControlPosition(this._mapOption.zoomControlPosition)
                        },
                        mapTypeControl: false,
                        zoomControl: true,
                        panControl: false,
                    }); //clickable for set point
                    if (this._mapOption.setPointable) {
                        var marker = new google.maps.Marker({
                            map: this._mapObject,
                            icon: gsa.util.UrlHelper.getInstance().getMyLocationMarkerIcon(),
                            animation: google.maps.Animation.BOUNCE
                        });
                        var infowindow = new google.maps.InfoWindow({
                            content: this._mapOption.setPointTemplate
                        });
                        google.maps.event.addListener(this._mapObject, 'click', function (event) {
                            marker.setPosition(event.latLng);
                            infowindow.close();
                            infowindow.open(_this._mapObject, marker);
                            _this._mapOption.onSetPoint(new LatLng(event.latLng.lat(), event.latLng.lng()));
                        });
                    }
                    return new Markers(this._mapObject, this._mapOption);
                }
                catch (e) {
                    if (gsa.util.FunctionUtility.isFunction(this._mapOption.onError)) {
                        this._mapOption.onError(e.message);
                    }
                    throw new Error(e.toString());
                }
                finally {
                    google.maps.event.addListener(this._mapObject, 'tilesloaded', function () {
                        if (gsa.util.FunctionUtility.isFunction(_this._mapOption.onComplete)) {
                            _this._mapOption.onComplete();
                        }
                    });
                }
            };
            return Map;
        })();
        maps.Map = Map;
        var Markers = (function () {
            function Markers(_mapObject, _mapOption) {
                var _this = this;
                this._mapObject = _mapObject;
                this._mapOption = _mapOption;
                this._mapMarkers = new Array();
                console.log('Markers.ctor');
                Markers._instance = this; //get all markers with key and call addMarkerToMap()
                for (var item = 0; item < (this._mapOption.keys ? this._mapOption.keys.length : 0); item++) {
                    gsa.net.RemoteService.SendRequest({
                        url: gsa.util.UrlHelper.getInstance().getMarkers(this._mapOption.keys[item].key),
                        type: "get",
                        async: true,
                        dataType: "json",
                        crossDomain: true,
                        cache: true,
                        success: function (response) {
                            _this.addMarkerToMap(response, _this._mapOption.findIndexKey(response.MarkerConfiguration.Key));
                        }
                    });
                }
            }
            Markers.prototype.setCenterPoint = function (point) {
                if (point == null || typeof (point) == 'undefined')
                    throw new bcl.MapOptionException(40405);
                this._mapObject.setCenter(gsa.util.TypeCasting.toGoogleMapsLatLngObject(point));
                return this;
            };
            Markers.prototype.setMyLocation = function (markersOption) {
                var _this = this;
                if (markersOption.position == null)
                    throw new bcl.MapOptionException(50001);
                this._mylocationPoint = markersOption.position;
                var mylocationMarker = new google.maps.Marker({
                    position: gsa.util.TypeCasting.toGoogleMapsLatLngObject(markersOption.position),
                    clickable: markersOption.clickable,
                    icon: markersOption.icon || gsa.util.UrlHelper.getInstance().getMyLocationMarkerIcon(),
                    draggable: markersOption.dragable,
                    raiseOnDrag: markersOption.raiseOnDrag,
                    visible: markersOption.visible,
                });
                if (typeof markersOption != 'undefined' && markersOption.clickable == true) {
                    google.maps.event.addListener(mylocationMarker, 'click', function () {
                        Markers._infoWindow.close();
                        Markers._infoWindow.setContent(markersOption.template ? markersOption.template() : TemplateManagment.myLocationTemplate());
                        Markers._infoWindow.open(_this._mapObject, mylocationMarker);
                    });
                }
                mylocationMarker.setMap(this._mapObject);
                return this;
            };
            Markers.prototype.openInfoWindow = function (point) {
                if (point == null || typeof (point) == "undefined")
                    throw new bcl.MapOptionException(40405);
                var l = this._mapMarkers.length;
                var googlePoint = gsa.util.TypeCasting.toGoogleMapsLatLngObject(point);
                for (var i = 0; i < l - 1; i++)
                    if (this._mapMarkers[i].getPosition().equals(googlePoint)) {
                        var marker = this._mapMarkers[i];
                        Markers._infoWindow.close();
                        Markers._infoWindow.setOptions({ maxWidth: 300 });
                        Markers._infoWindow.setContent(marker.template);
                        Markers._infoWindow.open(this._mapObject, marker);
                    }
                return this;
            };
            Markers.prototype.addMarkerToMap = function (fetchMarkers, index) {
                var compiler = new gsa.util.StringInterpolation(this._mapOption.keys[index].template ? this._mapOption.keys[index].template() : KeyStore.getKey(this._mapOption.keys[index].key).template());
                for (var i = 0; i < fetchMarkers.MarkerData.length; i++) {
                    var item = fetchMarkers.MarkerData[i];
                    var marker = new google.maps.Marker({
                        position: new google.maps.LatLng(item.Latitude, item.Longitude),
                        icon: fetchMarkers.MarkerConfiguration.IconAddress,
                        map: this._mapObject,
                        template: compiler.render(item),
                        key: fetchMarkers.MarkerConfiguration.Key
                    });
                    google.maps.event.addListener(marker, 'click', function () {
                        Markers._infoWindow.close();
                        Markers._infoWindow.setOptions({ maxWidth: 300 });
                        Markers._infoWindow.setContent(this.template);
                        Markers._infoWindow.open(this.map, this);
                    });
                    this._mapMarkers.push(marker);
                }
                CacheMarkers.getInstance().listFetchMarkers.push(fetchMarkers);
            };
            Markers.prototype.changeStateMarkers = function (key, visible) {
                var cacheMarkers = maps.CacheMarkers.getInstance();
                for (var index = 0; index < cacheMarkers.listFetchMarkers.length; index++) {
                    if (cacheMarkers.listFetchMarkers[index].MarkerConfiguration.Key == key) {
                        cacheMarkers.listFetchMarkers[index].MarkerConfiguration.Active = visible;
                    }
                }
                if (visible) {
                    for (var index = 0; index < this._mapMarkers.length; index++) {
                        if (this._mapMarkers[index].getMap() == null && this._mapMarkers[index].key == key)
                            this._mapMarkers[index].setMap(this._mapObject);
                    }
                }
                else {
                    for (var index = 0; index < this._mapMarkers.length; index++) {
                        if (this._mapMarkers[index].key == key)
                            this._mapMarkers[index].setMap(null);
                    }
                }
                return this;
            };
            Markers._infoWindow = new google.maps.InfoWindow();
            return Markers;
        })();
        maps.Markers = Markers;
        var CacheMarkers = (function () {
            function CacheMarkers() {
                this.listFetchMarkers = new Array();
                if (CacheMarkers._instance) {
                    throw new Error("Error: Instantiation failed: Use UrlHelper.getInstance() instead of new.");
                }
                CacheMarkers._instance = this;
            }
            CacheMarkers.prototype.resetCache = function () {
                this.listFetchMarkers = new Array();
            };
            CacheMarkers.getInstance = function () {
                return CacheMarkers._instance;
            };
            CacheMarkers.prototype.getAllKey = function () {
                var keys = [];
                for (var index = 0; index < this.listFetchMarkers.length; index++) {
                    keys.push(this.listFetchMarkers[index].MarkerConfiguration.Key);
                }
                return keys;
            };
            CacheMarkers._instance = new CacheMarkers();
            return CacheMarkers;
        })();
        maps.CacheMarkers = CacheMarkers;
        var FetchMarkers = (function () {
            function FetchMarkers() {
            }
            return FetchMarkers;
        })();
        maps.FetchMarkers = FetchMarkers;
        var MarkerConfiguration = (function () {
            function MarkerConfiguration() {
            }
            return MarkerConfiguration;
        })(); /**
         * Marker data is a data transfer object between layers also transfer between client and server
         */
        var MarkerData = (function () {
            function MarkerData() {
            }
            return MarkerData;
        })();
        maps.MarkerData = MarkerData; //******************************** Map Base Class Library ***************************************//
        var LatLng = (function () {
            function LatLng(lat, lng) {
                this.lat = lat;
                this.lng = lng;
            }
            ;
            LatLng.prototype.toUrlValue = function () {
                return "lat=" + this.lat.toString() + "&lng=" + this.lng.toString();
            };
            ;
            return LatLng;
        })();
        maps.LatLng = LatLng;
        var TemplateManagment = (function () {
            function TemplateManagment() {
            }
            TemplateManagment.myLocationTemplate = function () {
                return "<div class='MarkerContent'>موقعیت فعلی شما</div>";
            };
            ;
            TemplateManagment.defaulAgency = function () {
                return document.getElementById("defaultAgency").innerHTML;
            };
            return TemplateManagment;
        })();
    })(maps = gsa.maps || (gsa.maps = {}));
})(gsa || (gsa = {})); //-------------------------- linq
Array.prototype.where = function (predicate, context) {
    context = context || window;
    var arr = [];
    var l = this.length;
    for (var i = 0; i < l; i++)
        if (predicate.call(context, this[i], i, this) === true)
            arr.push(this[i]);
    return arr;
};
Array.prototype.take = function (count, context) {
    return context.slice(0, count);
};
