<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestingPageCurrentLocation.aspx.cs" Inherits="RainMaker.NRF.TestingPageCurrentLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<style>
      html, body {
        height: 370px;
        padding: 0;
        margin: 0;
        }
      #map {
       height:500px;
       width: 500px;
       overflow: hidden;
       float: left;
       border: thin solid #333;
       }
      #capture {
       height: 360px;
       width: 480px;
       overflow: hidden;
       float: left;
       background-color: #ECECFB;
       border: thin solid #333;
       border-left: none;
       }
    </style>

    <div id="map"></div>
  

<script>
    var map, infoWindow, lat1, lon1, lat2, lon2;
    var src = 'https://sites.google.com/site/mpplinframaps/islamabad-map/ISB.kml';

    function initMap() {


        directionsDisplay = new google.maps.DirectionsRenderer();
        //        map = new google.maps.Map(document.getElementById('map'), {
        //            mapTypeId: google.maps.MapTypeId.ROADMAP,
        //            center: new google.maps.LatLng(-19.257753, 146.823688),
        //            zoom: 13
        //        });
        //        directionsDisplay.setMap(map);


        var chicago = new google.maps.LatLng(-19.257753, 146.823688);
        var mapOptions = {
            zoom: 4,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: chicago
        }
        map = new google.maps.Map(document.getElementById('map'), mapOptions);
        directionsDisplay.setMap(map);



        var kmlLayer = new google.maps.KmlLayer(src, {
            suppressInfoWindows: true,
            preserveViewport: false,
            map: map
        });

        infoWindow = new google.maps.InfoWindow;
        geocoder = new google.maps.Geocoder();

        // Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };

                infoWindow.setPosition(pos);
                infoWindow.setContent('Current location.');
                start = pos.lat + ',' + pos.lng;
                lat1 = pos.lat;
                lon1 = pos.lng;

                
                //var url = "MapNRF.aspx?Lat=" + lat1 + "&Lon=" + lon1;
               // window.location.href = url;

                //                end = coordinateb;
                //                calcRouteOnLoad();

                infoWindow.open(map);
                map.setCenter(pos);
                map.setZoom(16);
            }, function () {
                handleLocationError(true, infoWindow, map.getCenter());
            });
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
        }
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
                                  'Error: The Geolocation service failed.' :
                                  'Error: Your browser doesn\'t support geolocation.');
        infoWindow.open(map);
    }

    function successFunction(position) {
        var lat = position.coords.latitude;
        var lng = position.coords.longitude;
        codeLatLng(lat, lng)
    }

    function errorFunction() {
        alert("Geocoder failed");
    }

    function codeLatLng(lat, lng) {

        var latlng = new google.maps.LatLng(lat, lng);
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                //console.log(results);
                if (results[1]) {
                    var indice = 0;
                    for (var j = 0; j < results.length; j++) {
                        if (results[j].types[0] == 'locality') {
                            indice = j;
                            break;
                        }
                    }
                    //alert('The good number is: ' + j);
                    console.log(results[j]);
                    for (var i = 0; i < results[j].address_components.length; i++) {
                        if (results[j].address_components[i].types[0] == "locality") {
                            //this is the object you are looking for
                            city = results[j].address_components[i];

                        }
                        if (results[j].address_components[i].types[0] == "administrative_area_level_1") {
                            //this is the object you are looking for
                            region = results[j].address_components[i];

                        }
                        if (results[j].address_components[i].types[0] == "country") {
                            //this is the object you are looking for
                            country = results[j].address_components[i];

                        }
                    }

                    //city data
                    //alert(city.long_name + " || " + region.long_name + " || " + country.short_name)
                    //document.getElementById("txt_city").value = city.long_name;
                    alert(city.long_name);

                    if (city.long_name == "karachi") {
                        var url = "MapNRF.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                        window.location.href = url;
                    }

                    if (city.long_name == "islamabad") {
                        var url = "TestingISL.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                        window.location.href = url;
                    }

                    if (city.long_name == "lahore") {
                        var url = "MapNRF.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                        window.location.href = url;
                    }

                    else {

                        var url = "MapNRF.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                        window.location.href = url;
                    }



                } else {
                    alert("No results found");
                }
                //}
            } else {
                alert("Geocoder failed due to: " + status);
            }
        });
    }

    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDmpTBj6EXLoqqxbPyMcivCxCMiBmMlWzk&callback=initMap">
    </script>

    


</asp:Content>
