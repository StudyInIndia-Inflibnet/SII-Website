function page_event() {
    page_change(), page_click(), EditSelectData()
}

function page_validation() { }

function page_change() {
    $(".datetimepicker").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: "1900:" + ((new Date).getFullYear() - 14),
        todayHighlight: !1,
        changeMonth: !0,
        changeYear: !0,
        onSelect: function (e) {
            var t = e.split("-"),
                a = t[1] + "-" + t[0] + "-" + t[2],
                n = new Date("2018-01-01"),
                r = (new Date(n.getYear(), n.getMonth(), n.getDate()), n.getYear()),
                i = n.getMonth(),
                s = n.getDate(),
                d = new Date(a.substring(6, 10), a.substring(0, 2) - 1, a.substring(3, 5)),
                l = d.getYear(),
                o = d.getMonth(),
                c = d.getDate();
            if (yearAge = r - l, i >= o) var p = i - o;
            else {
                yearAge--;
                p = 12 + i - o
            }
            if (s >= c) var u = s - c;
            else {
                u = 31 + s - c;
                --p < 0 && (p = 11, yearAge--)
            }
            yearAge, $("#txtYear").val(yearAge)
        }
    })
}

function page_click() {
    $("#btnStudentBasicSave").on("click", function (e) {
        e.preventDefault();
        var t = $("#frmStudentBasic");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        if (parseInt($("#txtYear").val()) < 15) return swal("Error", "Age should be more than 15 years.", "error"), !1;
        btnCopyAddress.checked;
        var a = $(this);
        a.text("Processing..."), a.addClass("disabled");
        var n = [];
        n.push({
            studentid: $("#hdnstudentid").val(),
            AddressType: "Residential",
            Addressline1: $("#txtResidential").val().replace(/\&/g, "%26"),
            Country: $("#drpCountryResi").val(),
            State: "0",
            City: "0",
            Area: $("#txtAreaResi").val().replace(/\&/g, "%26"),
            State_name: $("#txtStateResi").val().replace(/\&/g, "%26"),
            City_name: $("#txtCityResi").val().replace(/\&/g, "%26")
        }), n.push({
            studentid: $("#hdnstudentid").val(),
            AddressType: "Permanent",
            Addressline1: $("#txtPermanent").val().replace(/\&/g, "%26"),
            Country: $("#drpCountryPermanent").val().replace(/\&/g, "%26"),
            State: "0",
            City: "0",
            Area: $("#txtAreaPer").val().replace(/\&/g, "%26"),
            State_name: $("#txtStatePermanent").val().replace(/\&/g, "%26"),
            City_name: $("#txtCityPermanent").val().replace(/\&/g, "%26")
        }), $.ajax({
            method: "POST",
            url: "/admission/StudentBasicInformation/SaveStudentBasic",
            data: t.serialize() + "&bCopyAddress=" + ($("#btnCopyAddress").is(":checked") ? 1 : 0) + "&StrJson=" + JSON.stringify(n),
            async: !1,
            success: function (e) { }
        }).done(function (e) {
            "true" == e.flag.toString().toLowerCase() ? swal({
                title: "Success!",
                text: "Data saved successfully.",
                type: "success",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                // EditSelectData()
                window.location.href = window.location.href ;
            }) : swal({
                title: "Error!",
                text: "Data has not been saved. Please try again.",
                type: "error",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }), a.text("Save"), a.removeClass("disabled")
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again."), a.text("Save"), a.removeClass("disabled")
        })
    })
}

function Checkdata(e) {
    1 == e.btnCopyAddress.checked ? ($("#txtPermanent").val($("#txtResidential").val()).prop("disabled", !0), $("#drpCountryPermanent").val($("#drpCountryResi").val()).prop("disabled", !0), $("#txtStatePermanent").val($("#txtStateResi").val()).prop("disabled", !0), $("#txtCityPermanent").val($("#txtCityResi").val()).prop("disabled", !0), $("#txtAreaPer").val($("#txtAreaResi").val()).prop("disabled", !0)) : ($("#txtPermanent").val("").prop("disabled", !1), $("#drpCountryPermanent").val("").prop("disabled", !1), $("#txtStatePermanent").val("").prop("disabled", !1), $("#txtCityPermanent").val("").prop("disabled", !1), $("#txtAreaPer").val("").prop("disabled", !1))
}

function EditSelectData() {
    $.ajax({
        method: "POST",
        url: "/admission/StudentBasicInformation/SelectStudentBasic"
    }).done(function (e) {
        $.each(e.List, function (e, t) {
            $("#hdnstudentid").val(t.studentid), $("#txtFname").val(t.FirstName), $("#txtMname").val(t.MiddleName), $("#txtLname").val(t.LastName), $("#txtdateofbirth").val(t.DateOfBirth), $("#drpGender").val(t.Gender), $("#txtemail").val(t.Email), $("#txtMobile").val(t.Mobile), $("#drpcountrycode").val(t.CountryCode), $("#drpNationality").val(t.Nationality), $("#drpCountry").val(t.Country), $("#drpCountryofStay").val(t.CountryToStay), $("#btnCopyAddress").removeAttr("checked"), "True" == t.bCopyAddress && $("#btnCopyAddress").trigger("click"), $("#spanstudentname").text(t.FirstName + " " + t.MiddleName + " " + t.LastName), $("#ApplyingForCourse").val(t.ApplyingForCourse)
        }), $.each(e.ListAdd, function (e, t) {
            "Residential" == t.AddressType ? ($("#txtResidential").val(t.Addressline1), $("#drpCountryResi").val(t.Country), $("#txtStateResi").val(t.State_name), $("#txtCityResi").val(t.City_name), $("#txtAreaResi").val(t.Area)) : "Permanent" == t.AddressType && ($("#txtPermanent").val(t.Addressline1), $("#drpCountryPermanent").val(t.Country), $("#txtStatePermanent").val(t.State_name), $("#txtCityPermanent").val(t.City_name), $("#txtAreaPer").val(t.Area))
        });
    }).error(function () { })
}
$(document).ready(function () {
    page_event()
});