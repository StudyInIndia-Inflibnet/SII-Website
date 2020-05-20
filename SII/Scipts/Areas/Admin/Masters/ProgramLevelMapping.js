$(document).ready(function () {
    $("#tbl").DataTable();
    page_click()
});

function page_click() {
    $("#btnSave").on("click", function (e) {
        e.preventDefault();
        var t = $("#frm");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var btn = $(this);
        var r = btn.text();
        if (btn.hasClass("disabled")) return !1;
        btn.text("Processing...");
        btn.addClass("disabled");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/MappingSaveData",
            data: t.serialize()
        }).done(function (e) {
            if (e.c.toString().toLowerCase() == 'success') {
                swal("success", e.m, "success").then(function () {
                    window.location.href = window.location.href
                });
            } else if (e.c.toString().toLowerCase() == 'already') {
                swal("warning", e.m, "warning")
            } else {
                swal("error", e.m, "error");
            }
            a.text(r);
            a.removeClass("disabled");
        }).error(function () {
            a.text(r);
            a.removeClass("disabled");
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#tbody").on("click", ".btnEdit", function (e) {
        e.preventDefault();
        var t = $(this).attr("data-id");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/MappingSelectData",
            data: { ProgramLevel_Id: t, isNicheCourse: $('#isNicheCourse').val() }
        }).done(function (e) {
            $.each(e.List, function (e, t) { $("#hdfMpng_ID").val(t.Mpng_ID), $("#drpProgramLevel_Id").val(t.ProgramLevel_Id), $("#drpDiscipline_ID").val(t.Discipline_ID) })
        }).error(function () { swal("error", "Somthing went wrong. Please try again.", "error") })
    });
    $("#tbody").on("click", ".btnDelete", function (e) {
        var btn = $(this);
        var dataid = btn.attr("data-id");
        e.preventDefault();
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (e) {
            $.ajax({
                method: "POST",
                url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/MappingDeleteData",
                data: { Mpng_ID: dataid, isNicheCourse: $('#isNicheCourse').val() }
            }).done(function (data) {
                if (data['c'] == 'success') {
                    swal({ title: "Success!", text: data['m'], icon: "success" });
                    btn.parent().parent().remove();
                }
            }).error(function () {
                swal("error", "Somthing went wrong. Please try again.", "error")
            });

        });
    });
}

function fillGrid() {
    $("#tbody").html(""),
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/MappingSelectData",
            data: { isNicheCourse: $('#isNicheCourse').val() }
        }).done(function (e) {
            $.each(e.List, function (e, t) {
                var tr = $("<tr></tr>");
                tr.append("<td>" + (e + 1) + "</td>");
                tr.append("<td>" + t.ProgramLevel + "</td>");
                tr.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>');
                $("#tbody").append(tr);
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
};
