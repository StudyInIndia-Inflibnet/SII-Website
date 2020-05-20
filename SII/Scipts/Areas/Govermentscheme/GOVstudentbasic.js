function page_event() {
    page_dropdown(), page_change(), page_click(), "0" != $("#hdnstudentid").val() && EditSelectData()
}

function page_validation() { }

function page_change() {
    $(".datetimepicker").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: "1960:" + ((new Date).getFullYear() - 14),
        todayHighlight: !1,
        changeMonth: !0,
        changeYear: !0,
        onSelect: function (e) {
            var t = e.split("-"),
                a = t[1] + "-" + t[0] + "-" + t[2],
                n = new Date("2018-01-01"),
                r = (new Date(n.getYear(), n.getMonth(), n.getDate()), n.getYear()),
                i = n.getMonth(),
                o = n.getDate(),
                l = new Date(a.substring(6, 10), a.substring(0, 2) - 1, a.substring(3, 5)),
                s = l.getYear(),
                d = l.getMonth(),
                c = l.getDate();
            if (yearAge = r - s, i >= d) var u = i - d;
            else {
                yearAge--;
                u = 12 + i - d
            }
            if (o >= c) var m = o - c;
            else {
                m = 31 + o - c;
                --u < 0 && (u = 11, yearAge--)
            }
            yearAge, $("#txtYear").val(yearAge)
        }
    })
}

function page_dropdown() {
    $.ajax({
        method: "POST",
        url: "/GovernmentSchemeAdmission/Students/SelectAgencyDetail",
        async: !1
    }).done(function (e) {
        e.List.length > 0 && ($("#drpagencyname").html(""), $("#drpagencyname").prepend('<option value="">--Select--</option>'), $.each(e.List, function (e, t) {
            $("#drpagencyname").append('<option value="' + t.id + '">' + t.nameofentitlename + "</option>")
        }))
    }).error(function () { })
}

function page_click() {
    $("#btnStudentBasicSave").on("click", function (e) {
        e.preventDefault();
        var t = $("#frmStudentBasic");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        if (parseInt($("#txtYear").val()) < 15) return swal("Error", "Age should be more than 15 years.", "error"), !1;
        var a = $(this);
        a.text("Processing..."), a.addClass("disabled"), $.ajax({
            method: "POST",
            url: "/GovernmentSchemeAdmission/Students/SaveStudent_Basic",
            data: t.serialize(),
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
                EditSelectData()
            }) : swal({
                title: "Error!",
                text: "Email id already registered.",
                type: "error",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }), a.text("Save"), a.removeClass("disabled")
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again."), a.text("Save"), a.removeClass("disabled")
        })
    }), $("#btnCopyAddress").on("click", function (e) {
        e.preventDefault(), $("#txtPermanent").val($("#txtResidential").val()), $("#drpCountryPermanent").val($("#drpCountryResi").val()), $("#txtStatePermanent").val($("#txtStateResi").val()), $("#txtCityPermanent").val($("#txtCityResi").val()), $("#txtAreaPer").val($("#txtAreaResi").val())
    })
}

function EditSelectData() {
    $.ajax({
        method: "POST",
        url: "/GovernmentSchemeAdmission/Students/SelectStudent_Basic"
    }).done(function (e) {
        $.each(e.List, function (e, t) {
            $("#hdnstudentid").val(t.studentid), $("#drpagencyname").val(t.agency_det_id), $("#txtFname").val(t.FirstName), $("#txtMname").val(t.MiddleName), $("#txtLname").val(t.LastName), $("#txtdateofbirth").val(t.DateOfBirth), $("#drpGender").val(t.Gender), $("#txtemail").val(t.Email), $("#txtMobile").val(t.Mobile), $("#drpcountrycode").val(t.CountryCode), $("#drpNationality").val(t.Nationality), $("#drpCountryofStay").val(t.CountryToStay), $("#spanstudentname").text(t.FirstName + " " + t.MiddleName + " " + t.LastName)
        })
    }).error(function () { })
}
$(document).ready(function () {
    page_event()
});