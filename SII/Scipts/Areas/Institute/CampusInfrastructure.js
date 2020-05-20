function page_init_infrastructure() {
    fill_campus_infrastructure()
}

function page_click_infrastructure() {
    $("#btnSaveInfrastructure").on("click", function (t) {
        t.preventDefault();
        var e = $("#frmInfrastructure");
        if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        var r = $(this);
        r.addClass("disabled"), r.text("Processing...");
        $("#chkNIRFRanking").is(":checked");
        $("#chkNBANAACAccreditation").is(":checked");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Institute/Campus/Save_Campus_Infrastructure",
            data: e.serialize() + '&AccommodationWifi=' + $('input[name=AccommodationWifi]').val() + '&elibrary=' + $('input[name=elibrary]').val() + '&ITInfrastructureWifiFacility=' + $('input[name=ITInfrastructureWifiFacility]').val(),
            async: !1
        }).done(function (t) {
            "false" == t.flag.toString().toLowerCase() ? (swal("Oops...!", "Something went wrong! Please try again."), r.text("Save"), r.removeClass("disabled")) : swal("Success!", "Data saved successfully."), r.removeClass("disabled"), r.text("Save")
        }).error(function () {
            swal("Oops...!", "Please try after some time"), r.text("Save"), r.removeClass("disabled")
        }), r.removeClass("disabled"), r.text("Save")
    })
}

function fill_campus_infrastructure() {
    $.ajax({
        method: "GET",
        url: $("#hdfBaseUrl").val() + "Institute/Campus/Select_Campus_Infrastructure"
    }).done(function (t) {
        $.each(t.List, function (t, e) {
            $("#hdfID").val(e.ID), $("#txtInfrastructureArea").val(e.Area), $("#txtInfrastructureITInfrastructure").val(e.ITInfrastructure), "Yes" == e.ITInfrastructureWifiFacility.toString() ? $("#rdbInfrastructureITInfrastructureWifiYes").attr("checked", !0) : $("#rdbInfrastructureITInfrastructureWifiNo").attr("checked", !0), $("#txtInfrastructureAcademicFacilities").val(e.AcademicFacilities), $("#txtInfrastructureDatabase").val(e.Database), "Yes" == e.elibrary.toString() ? $("#rdbInfrastructureElibraryYes").attr("checked", !0) : $("#rdbInfrastructureElibraryNo").attr("checked", !0), $("#txtInfrastructureResearchFacilitiesLabs").val(e.ResearchFacilitiesLabs), $("#txtInfrastructureAccommodation").val(e.Accommodation), "on" == e.AccommodationWifi.toString().toLowerCase() ? $("#rbdInfrastructureAccommodationWifiYes").attr("checked", !0) : $("#rdbInfrastructureAccommodationWifiNo").attr("checked", !0), "Veg." == e.CuisineServedInMess.toString() ? $("#rbdInfrastructureCuisineServedInMessVeg").attr("checked", !0) : "Non Veg." == e.CuisineServedInMess.toString() ? $("#rbdInfrastructureCuisineServedInMessNonVeg").attr("checked", !0) : $("#rbdInfrastructureCuisineServedInMessBoth").attr("checked", !0), $("#txtInfrastructureCuisinesOfFoodServed").val(e.CuisinesOfFoodServed), $("#txtInfrastructureDoctors").val(e.Doctors), $("#txtInfrastructurePharmacy").val(e.Pharmacy)
        })
    }).error(function () {
        swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled")
    })
}

function fill_state() {
    $("#drpstate").html(""), $("#drpstate").html("Loading..."), $.ajax({
        method: "POST",
        url: "/Master/State/Select_State",
        async: !1,
        data: {
            country_id: 1
        }
    }).done(function (t) {
        $("#drpstate").html(""), $("#drpstate").prepend('<option value="">--Select--</option>'), $.each(t.List, function (t, e) {
            $("#drpstate").append('<option value="' + e.state_id + '">' + e.state_name + "</option>")
        })
    }).error(function () {
        $("#drpstate").html(""), $("#drpstate").append('<option value="">-Select-</option>')
    })
}
$(document).ready(function () {
    page_click_infrastructure(), page_init_infrastructure()
});