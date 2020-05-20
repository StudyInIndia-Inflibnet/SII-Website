function page_init() {
    fill_state(), fill_details()
}

function page_click() {
    $("#btnCancel").on("click", function (t) {
        t.preventDefault(), $("#txtInstituteName").val(""), $("#txtEmail").val(""), $("#txtAddress").val(""), $("#txtState").val(""), $("#txtCity").val(""), $("#txtPin").val(""), $("#txtYOE").val(""), $("#txtDescription").val("")
    }), $("#btnSave").on("click", function (t) {
        t.preventDefault();
        var e = $("#frmInstituteDetails");
        if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        var a = $(this);
        a.addClass("disabled"), a.text("Processing...");
        var i = !1;
        $("#chkNIRFRanking").is(":checked") && (i = !0);
        var s = !1;
        $("#chkNBANAACAccreditation").is(":checked") && (s = !0), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Institute/Details/Save_Institute_Details",
            data: e.serialize() + "&NIRFRanking=" + i + "&NBANAACAccreditation=" + s,
            async: !1
        }).done(function (t) {
            "true" == t.flagExists.toString().toLowerCase() ? (swal("Oops...!", "Institute name and/or email already exists."), a.text("Save"), a.removeClass("disabled")) : "false" == t.flag.toString().toLowerCase() ? (swal("Oops...!", "Something went wrong! Please try again."), a.text("Save"), a.removeClass("disabled")) : swal({
                title: "Success!",
                text: "Data saved successfully",
                type: "",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                fill_details()
            }), a.removeClass("disabled"), a.text("Save")
        }).error(function () {
            swal("Oops...!", "Please try after some time"), a.text("Save"), a.removeClass("disabled")
        }), a.removeClass("disabled"), a.text("Save")
    })
}

function fill_details() {
    $.ajax({
        method: "GET",
        url: $("#hdfBaseUrl").val() + "Institute/Details/Select_Institute_Details"
    }).done(function (t) {
        $.each(t.List, function (t, e) {
            $("#hdfID").val(e.ID), $("#txtInstituteName").val(e.InstituteName), $("#txtEmail").val(e.Email), $("#txtAddress").val(e.Address), $("#drpstate").val(e.State), $("#txtCity").val(e.City), $("#txtPin").val(e.Pin), $("#txtYOE").val(e.YOE), $("#txtDescription").val(e.Description), $("#txtAcademicCourses").val(e.AcademicCourses), $("#txtAreaOfExcellence").val(e.AreaOfExcellence), $("#txtResearchCapability").val(e.ResearchCapability), $("#txtNotableResearchPublication").val(e.NotableResearchPublication), "true" == e.NIRFRanking.toString().toLowerCase() && $("#chkNIRFRanking").attr("checked", !0), "true" == e.NBANAACAccreditation.toString().toLowerCase() && $("#chkNBANAACAccreditation").attr("checked", !0), $("#txtURL").val(e.instituteweburl)
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
    page_click(), page_init(), page_change()
});

function page_change() {
    $('.word-limits-check').on('keyup', function () {
        var txt = $(this);
        var totalCounts = parseInt(txt.attr('data-parsley-word-limit'));
        var label = txt.parent().find('.word-counts');
        var counts = WordCount(txt.val());
        if (counts == 0) {
            label.text('').hide();
        } else {
            var remainingWords = totalCounts - counts;
            if (remainingWords == 0) {
                label.text('Maximum word limit reached.').show();
            } else if (remainingWords < 0) {
                label.text('Maximum word limit crossed.').show();
            } else {
                label.text(remainingWords + ' words remain.').show();
            }
        }
    });
}

function WordCount(str) {
    return str.split(/\b[\s,\.-:;]*/)
        .filter(function (n) { return n != '' })
        .length;
}
