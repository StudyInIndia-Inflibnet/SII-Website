function page_change() {
    $("#drpDiscipline_ID").on("change", function (a) {
        $("#drpProgramLevel_Id").html(""), $("#drpProgramLevel_Id").append('<option value="">--Select--</option>');
        var t = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectPL",
            data: {
                Discipline_ID: t, IsNicheCourse: $('#IsNicheCourse').val()
            }
        }).done(function (a) {
            $.each(a.List, function (a, t) {
                $("#drpProgramLevel_Id").append('<option value="' + t.ProgramLevel_Id + '">' + t.ProgramLevel + "</option>")
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
    });
    $("#drpProgramLevel_Id").on("change", function (a) {
        $("#drpQualification_ID").html(""), $("#drpQualification_ID").append('<option value="">--Select--</option>');
        var t = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Admin/QualificationMaster/SelectQ",
            data: {
                ProgramLevel_Id: t, IsNicheCourse: $('#IsNicheCourse').val()
            }
        }).done(function (a) {
            $.each(a.List, function (a, t) {
                $("#drpQualification_ID").append('<option value="' + t.Qualification_ID + '">' + t.Qualification + "</option>")
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
    });
}

function page_click() {
    $("#btnSave").on("click", function (a) {
        a.preventDefault();
        var t = $("#frm");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var e = $(this),
            n = e.text();
        if (e.hasClass("disabled")) return !1;
        e.text("Processing..."), e.addClass("disabled"), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/MappingSaveData",
            data: t.serialize()
        }).done(function (a) {
            "success" == a.c.toString().toLowerCase() ? swal("success", a.m, "success").then(function () {
                window.location.href = window.location.href
            }) : "already" == a.c.toString().toLowerCase() ? swal("warning", a.m, "warning") : swal("error", a.m, "error"), e.text(n), e.removeClass("disabled")
        }).error(function () {
            e.text(n), e.removeClass("disabled"), swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#tbody").on("click", ".btnEdit", function (a) {
        a.preventDefault();
        var t = $(this).attr("data-id"),
            e = $(this).attr("data-Discipline_ID"),
            n = $(this).attr("data-ProgramLevel_Id"),
            r = ($(this).attr("data-Natureofcourse_Id"), $(this).attr("data-Qualification_ID")),
            o = $(this).attr("data-CourseOfStudy_ID");
        $("#hdfBranch_Id").val(t), $("#drpDiscipline_ID").val(e).trigger("change"), $("#drpProgramLevel_Id").val(n).trigger("change"), $("#drpQualification_ID").val(r), $("#drpCourseOfStudy_ID").val(o)
    });
    $("#tbody").on("click", ".btnDelete", function (a) {
        a.preventDefault();
        var t = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (a) {
            a && swal({
                title: "Success!",
                text: "Record is deleted!",
                icon: "success"
            }).then(function () {
                $.ajax({
                    method: "POST",
                    url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/MappingDeleteData",
                    data: {
                        Branch_Id: t, IsNicheCourse: $('#IsNicheCourse').val()
                    }
                }).done(function (a) {
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
        url: $("#hdfBaseUrl").val() + "Admin/CourseOfStudyMaster/MappingSelectData",
        data: {
            IsNicheCourse: $('#IsNicheCourse').val()
        }
    }).done(function (a) {
        $.each(a.List, function (a, t) {
            var e = $("<tr></tr>");
            e.append("<td>" + (a + 1) + "</td>"), e.append("<td>" + t.ProgramLevel + "</td>");
            e.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>'), $("#tbody").append(e)
        })
    }).error(function () {
        swal("error", "Somthing went wrong. Please try again.", "error")
    })
}

$(document).ready(function () {
    $("#tbl").DataTable(), page_click(), page_change()
});