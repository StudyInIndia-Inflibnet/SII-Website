function page_click() {
    $("#btnSave").on("click", function (t) {
        t.preventDefault();
        var e = $("#frm");
        if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        var a = $(this),
            r = a.text();
        if (a.hasClass("disabled")) return !1;
        a.text("Processing..."), a.addClass("disabled"), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/SaveData",
            data: e.serialize()
        }).done(function (t) {
            "success" == t.c.toString().toLowerCase() ? swal("success", t.m, "success").then(function () {
                window.location.href = window.location.href
            }) : "already" == t.c.toString().toLowerCase() ? swal("warning", t.m, "warning") : swal("error", t.m, "error"), a.text(r), a.removeClass("disabled")
        }).error(function () {
            a.text(r), a.removeClass("disabled"), swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#tbody").on("click", ".btnEdit", function (t) {
        t.preventDefault();
        var e = $(this).attr("data-id");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/SelectData",
            data: {
                CourseOfStudy_ID: e, IsNicheCourse: $('#IsNicheCourse').val()
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#hdfCourseOfStudy_ID").val(e.CourseOfStudy_ID), $("#txtCourseOfStudy").val(e.CourseOfStudy)
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#tbody").on("click", ".btnDelete", function (t) {
        t.preventDefault();
        var e = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (t) {
            t && swal({
                title: "Success!",
                text: "Record is deleted!",
                icon: "success"
            }).then(function () {
                $.ajax({
                    method: "POST",
                    url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/DeleteData",
                    data: {
                        CourseOfStudy_ID: e, IsNicheCourse: $('#IsNicheCourse').val()
                    }
                }).done(function (t) {
                    window.location.href = window.location.href
                }).error(function () {
                    swal("error", "Somthing went wrong. Please try again.", "error")
                })
            })
        })
    })
}

function fillGrid() {
    $("#tbody").html(""), $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/SelectData",
        data: { IsNicheCourse: $('#IsNicheCourse').val()}
    }).done(function (t) {
        $.each(t.List, function (t, e) {
            var a = $("<tr></tr>");
            a.append("<td>" + (t + 1) + "</td>"), a.append("<td>" + e.CourseOfStudy + "</td>");
            a.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>'), $("#tbody").append(a)
        })
    }).error(function () {
        swal("error", "Somthing went wrong. Please try again.", "error")
    })
}
$(document).ready(function () {
    $("#tbl").DataTable(), page_click()
});