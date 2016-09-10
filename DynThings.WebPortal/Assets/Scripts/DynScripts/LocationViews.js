﻿//Vars
var selectedLocationView = 0;
var map = null;
var viewchangeend;


//Attach : Pager
function AttachEventLocationViewsListPager() {
    $(document).on("click", "#LocationViewsListPager a[href]", function () {
        var loadingpart = LoadDivLoading();
        $("#divLocationViewsList").html(loadingpart);
        $.ajax({
            url: $(this).attr("href") + "&searchfor=" + $(txtLocationViewSearch).val() + '&recordsperpage=0',
            type: 'GET',
            cache: false,
            success: function (result) {
                $("#divLocationViewsList").html(result);
                return false;
            }
        });
        return false;
    });
}

//Attach : Add Form Submit
function AttachEventLocationViewAddForm() {
    $("#LocationViewAddForm").on("submit", function (event) {
        event.preventDefault();
        var url = $(this).attr("action");
        var formData = $(this).serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (resp) {
            }
        })

        LoadPart_LocationViewListDiv();
        $('#mdl').modal('hide');
    });
}

//Attach : Edit Form Submit : Main
function AttachEventLocationViewEditForm(locationViewID) {
    $("#LocationViewEditForm").on("submit", function (event) {
        event.preventDefault();
        var url = $(this).attr("action");
        var formData = $(this).serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (resp) {
                ServerResponse(resp);
            },
            error: function () {
                ServerResponse(resp);
            }
        })
        LoadPart_DialogLocationViewEditMain(locationViewID);
    });
};

//Attach : Edit Form Submit : Map
function AttachEventLocationViewMapEditForm(locationViewID) {
    $("#LocationViewMapEditForm").on("submit", function (event) {
        event.preventDefault();
        var url = $(this).attr("action");
        var formData = $(this).serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (resp) {
            }
        })

    });
}

//Get List
function LoadPart_LocationViewListDiv() {
    var loadingpart = LoadDivLoading();
    $("#divLocationViewsList").html(loadingpart);
    $.ajax({
        url: getRootURL() + 'LocationViews/ListCardsPV?searchfor=' + $(txtLocationViewSearch).val() + '&recordsperpage=0',
        //page=" + $("#DynConfigCurrentPage").html,
        type: "GET",
    })
        .done(function (partialViewResult) {
            $("#divLocationViewsList").html(partialViewResult);
        });
    return false;
};

//Get Details
//TODO

//Get Add
function LoadPart_DialogLocationViewAdd() {
    var loadingpart = LoadDivLoading();
    $("#modal").html(loadingpart);
    $.ajax({
        url: getRootURL() + '/LocationViews/addpv',
        type: "GET",
    })
    .done(function (partialViewResult) {
        $("#modal").html(partialViewResult);
    });
}

//Get Edit
function LoadPart_DialogLocationViewEditMain(id) {
    var loadingpart = LoadDivLoading();
    $("#divLocationViewMain").html(loadingpart);
    $.ajax({
        url: getRootURL() + '/LocationViews/EditMainPV?id=' + id,
        type: "GET",
    })
    .success(function (partialViewResult) {
        $("#divLocationViewMain").html(partialViewResult);
    });
}

//Get Delete
function LoadPart_DialogLocationViewDelete(id) {
    var loadingpart = LoadDivLoading();
    $("#modal").html(loadingpart);
    $.ajax({
        url: getRootURL() + '/LocationViews/DeletePV?id=' + id,
        //page=" + $("#DynConfigCurrentPage").html,
        type: "GET",
    })
    .done(function (partialViewResult) {
        $("#modal").html(partialViewResult);
    });
}


//Get Locations List
function LoadPart_LocationsListByLocationViewIDDiv(locationViewID) {
    var loadingpart = LoadDivLoading();
    $("#divLocationsList").html(loadingpart);
    $.ajax({
        url: getRootURL() + '/locationviews/LocationsByLocationViewIDListGridPV?searchfor=' + $(txtLocationsSearch).val() + '&locationViewID=' + locationViewID + '&recordsperpage=0',
        //page=" + $("#DynConfigCurrentPage").html,
        type: "GET",
    })
        .done(function (partialViewResult) {
            $("#divLocationsList").html(partialViewResult);
            AttachEventLocationsListPager();
        });
    return false;
};


function getEditLocationViewMap(x, y, z) {
    map = new Microsoft.Maps.Map(document.getElementById('myMap')
       , {
           credentials: 'Aq96lGpMhTmC6x18TL2-qS4ccUYLNnc9IW6FSN5E1MW5O1td3LMyiYzEBi3w6S7f'
            , enableClickableLogo: false
            , enableSearchLogo: false
            , showDashboard: true
            , showMapTypeSelector: true
            , useInertia: true
           // ,disablePanning: true
           //, disableZooming: true
            , mapTypeId: Microsoft.Maps.MapTypeId.birdseye
            , center: new Microsoft.Maps.Location(x, y), zoom: z
       });

    var viewchangeend = Microsoft.Maps.Events.addHandler(map, 'viewchangeend', function (e) {
        onViewChangeEnd(e);
    });
}

function onViewChangeEnd(e) {
    var latlon = map.getCenter();
    $("#X").val(latlon.latitude);
    $("#Y").val(latlon.longitude);
    $("#Z").val(map.getZoom());
}


function AttachLocationToLocationView(locationViewID,LocationID) {
    $.ajax({
        url: getRootURL() + '/LocationViews/AttachLocation?locationViewID=' + locationViewID + '&locationID=' + LocationID + '&userID=0',
        type: "POST",
    })
    HideModal();
    LoadPart_LocationsListByLocationViewIDDiv(locationViewID);
}

function DeattachLocationFromLocationView(locationViewID, LocationID) {
    $.ajax({
        url: getRootURL() + '/LocationViews/DeAttachLocation?locationViewID=' + locationViewID + '&locationID=' + LocationID + '&userID=0',
        type: "POST",
    })
    LoadPart_LocationsListByLocationViewIDDiv(locationViewID);
}