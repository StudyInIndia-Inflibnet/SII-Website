$(document).ready(function () {
    $("#tbl").DataTable();
    page_click();
    page_change();
});

function page_change() {
    $("#drpDiscipline_ID").on("change", function (e) {
        $("#drpProgramLevel_Id").html("")
        $("#drpProgramLevel_Id").append('<option value="">--Select--</option>');
        var a = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectPL",
            data: { Discipline_ID: a, IsNicheCourse: $('#isNicheCourse').val() }
        }).done(function (e) {
            $.each(e.List, function (e, a) {
                $("#drpProgramLevel_Id").append('<option value="' + a.ProgramLevel_Id + '">' + a.ProgramLevel + "</option>");
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        });
    });

    $("#drpProgramLevel_Id").on("change", function (e) {
        $("#drpQualification_ID").html("");
        $("#drpQualification_ID").append('<option value="">--Select--</option>');
        var a = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectQ",
            data: { ProgramLevel_Id: a, IsNicheCourse: $('#isNicheCourse').val()  }
        }).done(function (e) {
            $.each(e.List, function (e, a) {
                $("#drpQualification_ID").append('<option value="' + a.Qualification_ID + '">' + a.Qualification + "</option>")
            })
        }).error(function () { swal("error", "Somthing went wrong. Please try again.", "error") });
    });
}

function page_click() {
    $("#btnSave").on("click", function (e) {
        e.preventDefault();
        var a = $("#frm");
        if (a.parsley().validate(), !a.parsley().isValid()) return !1;
        var t = $(this);
        n = t.text();
        if (t.hasClass("disabled")) return !1;
        t.text("Processing...");
        t.addClass("disabled");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/MappingSaveData",
            data: a.serialize()
        }).done(function (e) {
            "success" == e.c.toString().toLowerCase()
                ? swal("success", e.m, "success").then(function () { window.location.href = window.location.href })
                : "already" == e.c.toString().toLowerCase()
                    ? swal("warning", e.m, "warning")
                    : swal("error", e.m, "error");
            t.text(n);
            t.removeClass("disabled");
        }).error(function () {
            t.text(n);
            t.removeClass("disabled");
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
    });

    $("#tbody").on("click", ".btnEdit", function (e) {
        e.preventDefault();
        var a = $(this).attr("data-id");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/MappingSelectData",
            data: { Natureofcourse_Id: a, IsNicheCourse: $('#isNicheCourse').val() }
        }).done(function (e) {
            $.each(e.List, function (e, a) {
                $("#hdfNatureofcourse_Id").val(a.Natureofcourse_Id);
                $("#drpDiscipline_ID").val(a.Discipline_ID).trigger("change");
                $("#drpProgramLevel_Id").val(a.ProgramLevel_Id).trigger("change");
                $("#drpQualification_ID").val(a.Qualification_ID)
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
    });

    $("#tbody").on("click", ".btnDelete", function (e) {
        e.preventDefault();
        var a = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (e) {
            e && swal({ title: "Success!", text: "Record is deleted!", icon: "success" }).then(function () {
                $.ajax({
                    method: "POST",
                    url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/MappingDeleteData",
                    data: { Natureofcourse_Id: a, IsNicheCourse: $('#isNicheCourse').val()  }
                }).done(function (e) {
                    window.location.href = window.location.href
                }).error(function () {
                    swal("error", "Somthing went wrong. Please try again.", "error")
                });
            });
        });
    });

}

function fillGrid() {

    $("#tbody").html("");
    $.ajax({
        method: "GET",
        url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/MappingSelectData",
        data: { IsNicheCourse: $('#isNicheCourse').val() }
    }).done(function (e) {   
        $.each(e.List, function (e, a) { 
                console.log(e);
                var tr = $("<tr></tr>");
                tr.append("<td>" + (e + 1) + "</td>");
                tr.append("<td>" + a.ProgramLevel + "</td>");
                tr.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>');

                $("#tbody").append(tr);
            });
        }).error(function () {
        swal("error", "Somthing went wrong. Please try again.", "error");
    });
}

