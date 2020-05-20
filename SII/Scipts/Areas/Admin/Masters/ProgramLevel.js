$(document).ready(function () {
    $("#tbl").DataTable();
    page_click();
});

function page_click() {
    $("#btnSave").on("click", function (e) {
        e.preventDefault();
        var t = $("#frm");
        if (t.parsley().validate() && !t.parsley().isValid()) return !1;
        var a = $(this);
        var oldText = a.text();
        if (a.hasClass("disabled")) return !1;
        a.text("Processing...");
        a.addClass("disabled");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/SaveData",
            data: t.serialize()
        }).done(function (e) {
            if ("success" == e.c.toString().toLowerCase()) {
                swal("success", e.m, "success").then(function () {
                    window.location.href = window.location.href;
                })
            } else {

                if ("already" == e.c.toString().toLowerCase()) {
                    swal("warning", e.m, "warning")
                } else {
                    swal("error", e.m, "error");
                }

                btn.text(oldText);
                btn.removeClass("disabled");
            }

        }).error(function () {
            btn.text(a);
            btn.removeClass("disabled");
            swal("error", "Somthing went wrong. Please try again.", "error")
        });
    });

    $("#tbody").on("click", ".btnEdit", function (e) {
        e.preventDefault();
        var t = $(this).attr("data-id");
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/SelectData",
            data: { ProgramLevel_Id: t, isNicheCourse: $('#isNicheCourse').val() }
        }).done(function (e) {
            $.each(e.List, function (e, t) {
                $("#hdfProgramLevel_Id").val(t.ProgramLevel_Id);
                $("#txtProgrameLevel").val(t.ProgramLevel);
            })
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
                url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/DeleteData",
                data: { ProgramLevel_Id: dataid, isNicheCourse: $('#isNicheCourse').val() }
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



    //e.preventDefault();
    //var t = $(this).attr("data-id");
    //swal({
    //    title: "Are you sure?",
    //    text: "You will not be able to recover this data!",
    //    icon: "warning",
    //    showCancelButton: !0,
    //    confirmButtonColor: "#3085d6",
    //    cancelButtonColor: "#d33",
    //    confirmButtonText: "Yes, delete it!"
    //}).then(function (e) {
    //    e && swal({ title: "Success!", text: "Record is deleted!", icon: "success" }).then(function () {
    //        $.ajax({
    //            method: "POST",
    //            url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/DeleteData",
    //            data: { ProgramLevel_Id: t }
    //        }).done(function (e) {
    //            window.location.href = window.location.href
    //            }).error(function () {
    //                swal("error", "Somthing went wrong. Please try again.", "error")
    //            })
    //    })
    //})
    //});
}

function fillGrid() {
    $("#tbody").html("");
    $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "Admin/ProgrammeLevelMaster/SelectData",
        data: { isNicheCourse: $('#isNicheCourse').val() }
    }).done(function (e) {
        $.each(e.List, function (e, t) {
            var a = $("<tr></tr>");
            a.append("<td>" + (e + 1) + "</td>");
            a.append("<td>" + t.ProgramLevel + "</td>");
            a.append('<td><a class="btn btn-sm btn-warning">Edit</a><a class="btn btn-sm btn-delete">Delete</a></td>');
            $("#tbody").append(a)
        })
    }).error(function () { swal("error", "Somthing went wrong. Please try again.", "error") })
};
