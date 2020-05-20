
$(document).ready(function () {
    $("#tbl").DataTable();
    page_click();
});

function page_click() {
    $("#btnSave").on("click", function (t) {
        t.preventDefault();
        var a = $("#frm");
        if (a.parsley().validate(), !a.parsley().isValid()) return !1;
        var e = $(this);
        var n = e.text();

        if (e.hasClass("disabled")) return !1;
        e.text("Processing...");
        e.addClass("disabled");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SaveData",
            data: a.serialize()
        }).done(function (t) {
            "success" == t.c.toString().toLowerCase()
                ? swal("success", t.m, "success").then(function () { window.location.href = window.location.href })
                : "already" == t.c.toString().toLowerCase()
                    ? swal("warning", t.m, "warning")
                    : swal("error", t.m, "error");
            e.text(n);
            e.removeClass("disabled");
        }).error(function () {
            e.text(n), e.removeClass("disabled"), swal("error", "Somthing went wrong. Please try again.", "error")
        });
    });

    $("#tbody").on("click", ".btnEdit", function (t) {
        t.preventDefault();
        var a = $(this).attr("data-id");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectData",
            data: { Qualification_ID: a, isNicheCourse: $('#isNicheCourse').val() }
        }).done(function (t) {
            $.each(t.List, function (t, a) {
                $("#hdfQualification_ID").val(a.Qualification_ID);
                $("#drpProgramLevel_Id").val(a.ProgramLevel_Id);
                $("#txtQualification").val(a.Qualification);
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });

    $("#tbody").on("click", ".btnDelete", function (t) {
        t.preventDefault();
        var a = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (t) {

            $.ajax({
                method: "POST",
                url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/DeleteData",
                data: {
                    Qualification_ID: a, isNicheCourse: $('#isNicheCourse').val()
                }
            }).done(function (t) {
                window.location.href = window.location.href
            }).error(function () {
                swal("error", "Somthing went wrong. Please try again.", "error");
            });


            swal({
                title: "Success!",
                text: "Record is deleted!",
                icon: "success"
            }).then(function () { });
        })
    })
}

function fillGrid() {
    $("#tbody").html(""), $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectData",
        data: { isNicheCourse: $('#isNicheCourse').val() }
    }).done(function (t) {
        $.each(t.List, function (t, a) {
            var tr = $("<tr></tr>");
            tr.append("<td>" + (t + 1) + "</td>");
            tr.append("<td>" + a.ProgramLevel + "</td>");
            tr.append("<td>" + a.Qualification + "</td>");
            tr.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>');
            $("#tbody").append(tr);
        })
    }).error(function () {
        swal("error", "Somthing went wrong. Please try again.", "error")
    })
}