<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MapNRFCustomerCoordinates.aspx.cs" Inherits="RainMaker.NRF.MapNRFCustomerCoordinates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--<div style="margin-left: 195px; background-color: White; width: 961px; margin-top: -13px;">-->
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px;">
                <h6 class="center-block" style="text-align: center; color: White;">
                    Map</h6>
            </div>
        </div>
        <div class="container-fluid">
            <div>
                <p style="color: Black;">
                    Note: For successful running of application the location setting of the must be
                    allowed as shown in the following screen. The map will pin point top 5 joints handholes
                    , with 1 2 3 4 5 marker as shown in map.<br />
                    • Customer: Current Location of the use. If the user he can enter the customer coordinate
                    manually.
                    <br />
                    • Joints/Handhole: These are coordinates of Joints/Handhole. This will be changed
                    on clicking anywhere in the map.
                    <br />
                    • After setting both of the coordinates press calculate route in order to see the
                    route map and distance in meters.
                    <br />
                    • Hit on the estimate button for InfraCosting.
                </p>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblCoordinatesUnAvail" runat="server" ForeColor="Red" Text="No Joint/Handhole available"></asp:Label>
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;
                </p>
                <p>
                    <label for="start">
                        Customer:
                    </label>
                    <input type="text" name="start" id="start" runat="server" clientidmode="Static" style="width: 250px;" />
                    <label for="end">
                        Joints/Handhole:
                    </label>
                    <input type="text" name="end" id="txt_end" runat="server" clientidmode="Static" style="width: 250px;" />
                    <label for="FirstCoordinatesLat">
                    </label>
                    <input type="text" id="FirstCoordinatesLat" runat="server" clientidmode="Static"
                        style="width: 250px;" />
                    <input id="Button1" type="button" value="Calculate Route" runat="server" onclick="calcRoute()" />
                    <input id="GetNearestCoordinate" type="button" value="Get Nearest Joints/Handhole"
                        runat="server" onclick="GetCustomerNearestJointsHandhole()" />
                </p>
                <p>
                    <label for="distance">
                        Distance (m):
                    </label>
                    <input type="text" name="distance" id="distance" style="width: 199px;" readonly="true" />
                    <asp:Label ID="lblInfraType" runat="server" Text="Infra Type" />
                    <select id="cmbInfraType" name="infra[cmbInfraType]" runat="server" clientidmode="Static">
                        <option value="1" selected="selected">Aerial</option>
                        <option value="2">Burried</option>
                    </select>
                    <label for="city">
                        City:
                    </label>
                    <input type="text" name="city" id="txt_city" style="width: 199px;" readonly="true" />
                    <input id="Button2" type="button" value="Estimate" runat="server" onclick="Estimate_Click()" />
                </p>
                <p>
                </p>
            </div>
            <style>
                html, body
                {
                    height: 370px;
                    padding: 0;
                    margin: 0;
                }
                #map
                {
                    height: 500px;
                    width: 1100px;
                    overflow: hidden;
                    float: left;
                    border: thin solid #333;
                }
                #capture
                {
                    height: 360px;
                    width: 480px;
                    overflow: hidden;
                    float: left;
                    background-color: #ECECFB;
                    border: thin solid #333;
                    border-left: none;
                }
            </style>
            <div id="map">
            </div>
            <script>
    var map, infoWindow, lat1, lon1, lat2, lon2, marker, start, end, geocoder;
    var src = 'http://api.apps.multinet.com.pk/Maps/KHI_New.kml';
    //var src = 'https://sites.google.com/site/mpplinframaps/islamabad-map/ISB.kml';

    function initMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();

        var karachi = new google.maps.LatLng(24.8615, 67.0099);
        var mapOptions = {
            zoom: 4,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            center: karachi
        }
        map = new google.maps.Map(document.getElementById('map'), mapOptions);
        directionsDisplay.setMap(map);

        var kmlLayer = new google.maps.KmlLayer(src, {
            suppressInfoWindows: true,
            preserveViewport: false,
            map: map
        });
        var coordinateb = document.getElementById("txt_end").value;      
        

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
                //start = pos.lat + ',' + pos.lng;
                
                start = document.getElementById("start").value;          
                              
                lat1 = pos.lat;
                lon1 = pos.lng;

                end = coordinateb;

                calcRouteOnLoad();
                placeMarkeronload();
                infoWindow.open(map);
                map.setCenter(pos);                
                //map.setZoom(10);                
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




        google.maps.event.addListener(map, 'click', function (event) {
            //document.getElementById('end').value = event.latLng;            
            var endcoordinates = event.latLng.toString();
            endcoordinates = endcoordinates.replace(/[()]/g, "");
            document.getElementById('txt_end').value = endcoordinates;
            placeMarker(event.latLng);




        });
    }

    function successFunction(position) {
        var lat = position.coords.latitude;
        var lng = position.coords.longitude;
        
//         CusCor = document.getElementById("start").value;
//                value = CusCor.split(",");
//                count = value.length;
//                Cuslat = value[0];
//                Cuslon = value[1];
//                alert(" non cur lat"+ Cuslat);
//                alert(" non cur lon" +Cuslon);

        //alert("lat" + Cuslat + "lon" + Cuslon);
        //codeLatLngWithoutCurrentLocation(Cuslat, Cuslat)
        codeLatLng(lat, lng)
    }

    function errorFunction() {
        alert("Geocoder failed");
    }

    function codeLatLngWithoutCurrentLocation(lat, lng) {

        var latlng = new google.maps.LatLng(lat, lng);
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        
            //if (status == google.maps.GeocoderStatus.OK) {
            if (status == "OK") {
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
                    alert(city.long_name + " || " + region.long_name + " || " + country.short_name)
                    document.getElementById("txt_city").value = city.long_name;
                  


                } else {
                    alert("No results found");
                }
                //}
            } else {
                alert("Geocoder failed due to: " + status);
            }
        });
    }



    function codeLatLng(lat, lng) {


        var CusCor = document.getElementById("start").value;
        var valuetest = CusCor.split(",");
        var count = valuetest.length;
        var Cuslat = valuetest[0];
        var   Cuslon = valuetest[1];
        var latlng = new google.maps.LatLng(Cuslat, Cuslon);
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
                    document.getElementById("txt_city").value = city.long_name;
                  


                } else {
                    alert("No results found");
                }
                //}
            } else {
                alert("Geocoder failed due to: " + status);
            }
        });
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
                                  'Error: The Geolocation service failed.' :
                                  'Error: Your browser doesn\'t support geolocation.');
        infoWindow.open(map);
    }


    //now

    function placeMarker(location) {
            clearMarker();

            marker = new google.maps.Marker({
                position: location,
                map: map
            });
        }

        function placeMarkeronload() {
            //clearMarker();
            var pinImage = new google.maps.MarkerImage("http://www.googlemapsmarkers.com/v1/009900/");

            var myLatLng;
            var latitudefirst = document.getElementById('FirstCoordinatesLat').value


            document.getElementById("FirstCoordinatesLat").style.display = 'none';
            var points = <% =jsonString %>;
            for (var i = 0; i < 5; i++) {
                myLatLng = points[i];
                marker = new google.maps.Marker({
                    position: myLatLng,
                    icon: "../Images/"+ (i+1) +".png",
                    map: map
                });
            }


        }

        function clearMarker() {
            if (marker)
                marker.setMap(null);
        }

        function calcRouteOnLoad() {

            var directionsService = new google.maps.DirectionsService();
            //        var start = document.getElementById("start").value;
            //        var end = document.getElementById("end").value;
            var distanceInput = document.getElementById("distance");

            var request = {
                origin: start,
                destination: end,
                //travelMode: google.maps.DirectionsTravelMode.DRIVING
                travelMode: google.maps.DirectionsTravelMode.WALKING
            }


            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    //distanceInput.value = response.routes[0].legs[0].distance.value / 1000;
                    distanceInput.value = response.routes[0].legs[0].distance.value;
                    document.getElementById("start").value = start;

                }
            });
        }

        function calcRoute() {
            //var dis = getDistanceFromLatLonInKm('24.829875299999998', '67.09761619999999', '24.833016114199314', '67.1034836769104');

            var directionsService = new google.maps.DirectionsService();
            start = document.getElementById("start").value;
            end = document.getElementById("txt_end").value;
            var distanceInput = document.getElementById("distance");

            var request = {
                origin: start,
                destination: end,
                //travelMode: google.maps.DirectionsTravelMode.DRIVING
                travelMode: google.maps.DirectionsTravelMode.WALKING
            }


            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                    distanceInput.value = response.routes[0].legs[0].distance.value;

                }
            });
        }

        function Estimate_Click() {
            //var url = "InfraCosting.aspx?Distance=" + distance + "&City=" + city + "&InfraType=" + infra_type;
            
            var distance = document.getElementById("distance").value;
            var city = document.getElementById("txt_city").value;
            var infra_type = document.getElementById("cmbInfraType").value;



            if (infra_type == 1) {

                if (distance > 1000) {
                    alert("Sorry! Aerial connection Cannot be provided above 1000 meters");
                }

                else if (city == 'Islamabad') {
                    alert("Sorry! Aerial connection Cannot be provided in this city");
                }
                

                else {                
                    var url = "InfraCosting.aspx?Distance=" + distance + "&City=" + city + "&InfraType=" + infra_type;
                    window.location.href = url;                   
                    
                }

            }

            else {             
                var url = "InfraCosting.aspx?Distance=" + distance + "&City=" + city + "&InfraType=" + infra_type;
                window.location.href = url;
            }
            //        var url = "web forms/InfraCosting.aspx";
            //        window.location.href = url;
        }

        function GetCustomerNearestJointsHandhole() {
            var LatCus = document.getElementById("start").value;
            var value = LatCus.split(",");
            var count = value.length;
            var lat1 = value[0];
            var lon1 = value[1];
            var InfraType = document.getElementById("cmbInfraType").value;
            var url = "MapNRFCustomerCoordinates.aspx?Lat=" + lat1 + "&Lon=" + lon1+ "&CustomerValue=" + LatCus + "&InfraType=" + InfraType;
            window.location.href = url;
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
            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDmpTBj6EXLoqqxbPyMcivCxCMiBmMlWzk&libraries=places&callback=initMap"
                async defer></script>
        </div>
    </div>
</asp:Content>
