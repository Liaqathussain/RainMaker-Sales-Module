<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MapNRFWithOpportunity.aspx.cs" Inherits="RainMaker.NRF.MapNRFWithOpportunity" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="page-wrapper">
        <div class="row">
           <div class="col-lg-12" style="background-color: #f66519; border-left: thick solid #03828a;
                margin-left: 0.2em; height: 30px;  margin-top: -3.6em"">
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
                    <input type="text" name="distance" id="distance" style="width: 199px;" runat="server" clientidmode="Static" readonly="true" />
                    <asp:Label ID="lblInfraType" runat="server" Text="Infra Type" />
                    <select id="cmbInfraType" name="infra[cmbInfraType]" runat="server" clientidmode="Static">
                        <option value="1" selected="selected">Aerial</option>
                        <option value="2">Burried</option>
                    </select>
                    <label for="city">
                        City:
                    </label>
                    <input type="text" name="city" id="txt_city" style="width: 199px;" readonly="true" />
                    <%--<input id="Button2" type="button" value="Estimate" runat="server" onclick="Estimate_Click()" />--%>

                    
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


                 


                 <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
             <asp:UpdatePanel ID="UPPanel1" runat="server">
                <ContentTemplate>

                <%--<table class="nav-justified">
                    <tr>
                <td bgcolor="#03828A" style="font-family: Calibri;  font-weight: bold; color: #FFFFFF">
                   Customer Details
                </td>
            </tr>
                    </table>--%>
                    <telerik:RadButton ID="btnEstimate" Text="Estimate" runat="server" onclick="btnEstimate_Click">
                </telerik:RadButton>
                <table width="100%" cellpadding="2" style="border: thin solid #C9DAEE; padding: inherit;
                        margin: auto;">
                        
                    </table>

                    <table class="nav-justified">
                        <tr>
                            <td>
                                <table class="nav-justified">
                                    <tr>
                                        <td>
                                            Customer Name
                                        </td>
                                        <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbCustomerName"
                                                Display="None" ErrorMessage="Customer Name Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>
                                            <telerik:RadComboBox ID="cmbCustomerName" runat="server">
                                            </telerik:RadComboBox>
                                            <%--<asp:Label ID="lblCustomerNameMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />--%>
                                        </td>
                                        <td>
                                            Circuit Name
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCircuitName" runat="server">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCircuitName"
                                                ErrorMessage="Circuit Name Required" Display="None"></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblCircuitNameMandatory" runat="server" CssClass="lbl" Text="*" ForeColor="Red" />--%>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Site Address
                                        </td>
                                        <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSiteAddress"
                                                ErrorMessage="Site Address Required" Display="None"></asp:RequiredFieldValidator>
                                            <telerik:RadTextBox ID="txtSiteAddress" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            City
                                        </td>
                                        <td>
                                            <%--<telerik:RadTextBox ID="txtCity" ReadOnly="true" runat="server">
                                            </telerik:RadTextBox>--%>

                                            <telerik:RadComboBox ID="cmbcity" runat="server">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            Building
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbBuilding" runat="server">
                                            </telerik:RadComboBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbBuilding"
                                                Display="None" ErrorMessage="Building Required" InitialValue="Please Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            Area
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbArea"
                                                Display="None" ErrorMessage="Area Required" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                            <telerik:RadComboBox ID="cmbArea" AutoPostBack="true" runat="server" >
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Line of Business
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbLOB" runat="server">
                                            </telerik:RadComboBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cmbLOB"
                                                Display="None" ErrorMessage="LOB Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            Infra
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbInfra" runat="server" >
                                            </telerik:RadComboBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbInfra"
                                                Display="None" ErrorMessage="Infra Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            Service
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbService" runat="server" >
                                            </telerik:RadComboBox>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cmbService"
                                                Display="None" ErrorMessage="Service Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            POC Name:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCName" runat="server">
                                            </telerik:RadTextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPOCName"
                                                ErrorMessage="POC Name Required" Display="None"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            POC Contact:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCContact" runat="server">
                                                <ClientEvents OnKeyPress="keyPressPocContact" />
                                            </telerik:RadTextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPOCContact"
                                                ErrorMessage="POC Contact Required" Display="None"></asp:RequiredFieldValidator>--%>
                                            <%--<telerik:RadNumericTextBox ID="txtPOCContact" runat="server">
                                    </telerik:RadNumericTextBox>--%>
                                        </td>
                                        <td>
                                            POC Email:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPOCEmail" runat="server">
                                            </telerik:RadTextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPOCEmail"
                                                ErrorMessage="POC Email Address Required" Display="None"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Bandwidth
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbBandwidth" runat="server" >
                                            </telerik:RadComboBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cmbCapacity"
                                                Display="None" ErrorMessage="Capacity Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            BusinessType
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="cmbBusinessType" runat="server" >
                                            </telerik:RadComboBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cmbIndustry"
                                                Display="None" ErrorMessage="Industry Required" InitialValue="Please-Select"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            Infra Type
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtInfraType" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Region
                                        </td>
                                        <td>
                                            <%--<telerik:RadTextBox ID="txtRegion" runat="server">
                                            </telerik:RadTextBox>--%>

                                            <telerik:RadComboBox ID="cmbRegion" runat="server" >
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:Label ID="lblNRFTypeError" runat="server" Style="color: Red;" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnAreaID" runat="server" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="ItemPanel">
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManagerProxy>
                    <telerik:RadAjaxPanel ID="ItemPanel" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                        Width="100%">
                        <telerik:RadGrid runat="server" ID="grid_ItemDetail" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" ShowFooter="True" OnNeedDataSource="grid_ItemDetail_NeedDataSource"
                            OnUpdateCommand="grid_ItemDetail_UpdateCommand" OnInsertCommand="grid_ItemDetail_InsertCommand"
                            OnDeleteCommand="grid_ItemDetail_DeleteCommand" OnItemCreated="grid_ItemDetail_ItemCreated">
                            <MasterTableView CommandItemDisplay="Top" AutoGenerateColumns="false" EditMode="InPlace">
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" FooterText="Total" HeaderStyle-Width="7%"
                                        ItemStyle-BackColor="White" ItemStyle-Width="7%" UniqueName="EditCommandColumn1">
                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#000066" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" Width="7%" />
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridTemplateColumn DataField="ItemCode" HeaderStyle-Width="15%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="15%" UniqueName="ItemCode">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrItemCode" runat="server" Text="Item Code"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox ID="tbItemCode" runat="server" AutoPostBack="true" ClientEvents-OnButtonClick="ItemLookup"
                                                ShowButton="true" Text='<%# Bind("ItemCode") %>' Width="100%">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="15%" />
                                        <ItemStyle BackColor="White" Width="15%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ItemName" HeaderStyle-Width="19%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="19%" UniqueName="ItemName">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrItemDescription" runat="server" Text="Item Name"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbItemName" runat="server" Text='<%# Eval("ItemName") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="19%" />
                                        <ItemStyle BackColor="White" Width="19%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Unit" HeaderStyle-Width="17%" ItemStyle-BackColor="White"
                                        ItemStyle-Width="17%" UniqueName="Unit">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrUnit" runat="server" Text="Unit"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbUnit" runat="server" Text='<%# Eval("Unit") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="17%" />
                                        <ItemStyle BackColor="White" Width="17%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="UnitCost" DataType="System.Double" HeaderStyle-Width="7%"
                                        ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="7%"
                                        UniqueName="UnitCost">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrUnitCost" runat="server" Text="Unit Cost"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbUnitCost" runat="server" Text='<%# Eval("UnitCost") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="7%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Quantity" DataType="System.Double" DefaultInsertValue="0"
                                        HeaderStyle-Width="5%" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="5%" UniqueName="Quantity">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrQuantity" runat="server" Text="Qty."> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity","{0:0,0}") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="tbQuantity" runat="server" EnabledStyle-HorizontalAlign="Right"
                                                FocusedStyle-HorizontalAlign="Right" oncopy="return false" oncut="return false"
                                                onpaste="return false" Text='<%# Bind("Quantity","{0:0,0}") %>' Width="30px">
                                                <NumberFormat AllowRounding="true" DecimalDigits="0" />
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="5%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn Aggregate="Sum" DataField="Amount" DataType="System.Decimal"
                                        DefaultInsertValue="0.00" FooterAggregateFormatString="{0:0,0.00}" FooterStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="7%" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="7%" UniqueName="Amount">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrAmount" runat="server" Text="Amount"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount","{0:0,0.00}") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="tbAmount" runat="server" EnabledStyle-HorizontalAlign="Right"
                                                FocusedStyle-HorizontalAlign="Right" oncopy="return false" oncut="return false"
                                                onpaste="return false" Text='<%# Bind("Amount","{0:0,0.00}") %>' Width="50px">
                                                <NumberFormat AllowRounding="true" DecimalDigits="2" />
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#000066" HorizontalAlign="Right" />
                                        <HeaderStyle Width="7%" />
                                        <ItemStyle BackColor="White" HorizontalAlign="Right" Width="7%" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Edit" UniqueName="Edit" Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="hdrEdit" runat="server" Text="Edit"> </asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="tbEdit" runat="server" Text='<%# Eval("Edit") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BackColor="White" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogHeight="150px"
                                        ConfirmDialogType="RadWindow" ConfirmDialogWidth="275px " ConfirmText="&lt;br\&gt; Are you sure to delete this line? &lt;br\&gt; "
                                        ConfirmTitle="Delete" HeaderStyle-Width="3%" ItemStyle-BackColor="White" ItemStyle-Width="3%"
                                        Text="Delete" UniqueName="DeleteColumn">
                                        <FooterStyle BackColor="White" />
                                        <HeaderStyle Width="3%" />
                                        <ItemStyle BackColor="White" Width="3%" />
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                            <HeaderContextMenu EnableAutoScroll="True">
                            </HeaderContextMenu>
                        </telerik:RadGrid>
                        <asp:HiddenField ID="hdnItemLookup" runat="server" />
                    </telerik:RadAjaxPanel>
                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
                        Modal="true" ShowContentDuringLoad="false" VisibleStatusbar="false" Behavior="Default"
                        InitialBehavior="None" Skin="Office2007">
                        <Windows>
                            <telerik:RadWindow ID="Win_Lookup" runat="server" Width="600px" Height="450px" Behaviors="Default"
                                Modal="true" OnClientClose="GetLookupValue" NavigateUrl="Lookup.aspx">
                            </telerik:RadWindow>
                        </Windows>
                    </telerik:RadWindowManager>
                    
                    <br />
                    <div>
                    </div>
                    <div id="test" style="border: 1px solid #ccc; background-color: #03828a;">
                        <p>
                            ROI and MRC
                        </p>
                    </div>
                    <table width="100%" cellpadding="2" style="border: thin solid #C9DAEE; padding: inherit;
                        margin: auto;">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblMRC" runat="server" CssClass="lbl" Text="MRC" Width="44px" />
                            </td>
                            <td class="style3">
                                <telerik:RadTextBox ID="txtMRC" runat="server" >
                                </telerik:RadTextBox>
                            </td>
                            <td class="style2">
                                <asp:Label ID="lblROI" runat="server" CssClass="lbl" Text="ROI" Width="36px" />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtROI" runat="server" >
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
            
            <telerik:RadButton ID="btSave" Text="Save" runat="server" 
                OnClick="btSave_Click">
            </telerik:RadButton>
            </div>
              <table>
                <tr>
                    <td>
                    </td>
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                        GroupTreeImagesFolderUrl="" Height="1269px" ReportSourceID="CrystalReportSource1"
                        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Visible="False" Width="1082px" />
                </tr>
            </table>

        </div>
    </div>

      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function ItemLookup(sender, args) {

                document.getElementById('<%= hdnItemLookup.ClientID  %>').Text = sender.get_id();
                var oWnd = radopen("Lookup.aspx?Lookup=Item&Year1=" + "05/01/2017", "Win_Lookup");
                oWnd.Show();

            }

            function keyPress(sender, args) {
                var separatorPos = sender._textBoxElement.value.indexOf(sender.get_numberFormat().DecimalSeparator);
                if (args.get_keyCharacter().match(/[0-9]/) && separatorPos != -1 && sender.get_caretPosition() > separatorPos + sender.get_numberFormat().DecimalDigits)
                { args.set_cancel(true); }
            }

            function RefreshMe() {
                window.location.reload();
            }


            function GetLookupValue(oWindow, oArg) {

                var ctrl;
                var oArg = oArg.get_argument();
                if (oArg) {
                    switch (oArg.LookupName) {

                        case "Requisition":


                            break;
                        case "Vendor":

                            break;
                        case "Site":

                            break;
                        case "Customer":

                            break;
                        case "Project":

                            break;
                        case "Circuit":

                            break;


                        case "Item":

                            ctrl = document.getElementById("<%= hdnItemLookup.ClientID  %>").Text;
                            ctrl = $find(ctrl);
                            break;
                    }
                    ctrl.set_value(oArg.ReturnValue);
                    //                    alert(ctrl.set_value(oArg.ReturnValue));
                }
            }

            function keyPressPocContact(sender, args) {
                var text = sender.get_value() + args.get_keyCharacter();
                if (!text.match('^[0-9]+$'))
                    args.set_cancel(true);
            }


            function EmailFormat(sender, args) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (!re.test(sender.get_value()))
                    alert("Please enter a valid email address");
            }

            function NumberFormat(sender, args) {
                alert("umair test");
                var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
                if ((sender.get_value() == (phoneno))) {
                    return true;
                }
                else {
                    alert("message");
                    return false;
                }
            }

            function OnClientButtonClicked(sender, args) {


                var CircuitName = document.getElementById('<%=txtCircuitName.ClientID %>').value;
                var CustomerName = document.getElementById('<%=cmbCustomerName.ClientID %>').value;
                var Area = document.getElementById('<%=cmbArea.ClientID %>').value;

                if (CircuitName == "") {
                    alert("Circuit Name cannot be empty");
                    args.set_cancel(false);

                }

                if (CustomerName == 'Please Select') {

                    alert("Please Select customer name");
                    args.set_cancel(true);
                }

                if (Area == 'Please Select') {
                    alert("Please Select Area");
                    args.set_cancel(false);
                }



            }

        </script>
    </telerik:RadCodeBlock>

</asp:Content>
