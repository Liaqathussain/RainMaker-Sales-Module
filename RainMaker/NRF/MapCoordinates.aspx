<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MapCoordinates.aspx.cs" Inherits="RainMaker.NRF.MapCoordinates" %>
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
    //var src = 'https://sites.google.com/site/mpplinframaps/islamabad-map/ISB.kml';
    var src = 'http://api.apps.multinet.com.pk/Maps/KHI_New.kml';

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

                //var url = "Map.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                //var url = "MarkingTesting.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                var url = "MapNRF.aspx?Lat=" + lat1 + "&Lon=" + lon1;
                window.location.href = url;

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
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
                                  'Error: The Geolocation service failed.' :
                                  'Error: Your browser doesn\'t support geolocation.');
        infoWindow.open(map);
    }

    function getDistanceFromLatLonInKm(lat1, lon1, lat2, lon2) {
        var R = 6371000; // Radius of the earth in km
        var dLat = deg2rad(lat2 - lat1);  // deg2rad below
        var dLon = deg2rad(lon2 - lon1);
        var a =
              Math.sin(dLat / 2) * Math.sin(dLat / 2) +
              Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
              Math.sin(dLon / 2) * Math.sin(dLon / 2)
            ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c; // Distance in km
        return d;
    }

    function deg2rad(deg) {
        return deg * (Math.PI / 180)
    }

    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDmpTBj6EXLoqqxbPyMcivCxCMiBmMlWzk&callback=initMap">
    </script>


</asp:Content>
