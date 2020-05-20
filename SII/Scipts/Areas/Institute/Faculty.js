

function page_init_faculty() {
    $("#txtFacultyName").SetAlphabetOnly(), fill_grid_faculty()
}

function page_click_faculty() {
    $("#btnSaveCancelFaculty").on("click", function (t) {
        t.preventDefault(), $("#hdfFacultyID").val("0"), $("#txtFacultyName").val(""), $("#drpFacultyDesignation").val(""), $("#drpFacultyQualification").val(""), $("#txtAreaofExcellence").val("")
    }), $("#btnNewFaculty").on("click", function (t) {
        t.preventDefault(), $("#hdfFacultyID").val("0"), $("#txtFacultyName").val(""), $("#drpFacultyDesignation").val(""), $("#drpFacultyQualification").val(""), $("#txtAreaofExcellence").val("")
    }), $("#btnSaveFaculty").on("click", function (t) {
        t.preventDefault();
        var a = $("#frmFaculty");
        if (a.parsley().validate(), !a.parsley().isValid()) return !1;
        var e = $(this);
        e.addClass("disabled"), e.text("Processing...");
        var l = $("#fuFacultyPhoto").get(0);
        if (void 0 !== window.FormData && $("#fuFacultyPhoto").get(0).files.length > 0) {
            var n = $("#fuFacultyPhoto").get(0).files[0].size,
                i = ["png", "jpg", "jpeg"];
            if (-1 == $.inArray($("#fuFacultyPhoto").val().split(".").pop().toLowerCase(), i)) return swal("", "Only formats are allowed : " + i.join(", "), "error"), e.text("Save"), void e.removeClass("disabled");
            if (!("1048576" >= n)) return swal("", "1 Mb file size allow", "warning"), e.text("Save"), void e.removeClass("disabled")
        }
        for (var o = l.files, c = new FormData, s = 0; s < o.length; s++) c.append(o[s].name, o[s]);
        c.append("ID", $("#hdfFacultyID").val()), c.append("flag_faculty", $("#hdftype").val()), c.append("FacultyName", $("#txtFacultyName").val()), c.append("Designation", $("#drpFacultyDesignation").val()), c.append("Qualification", $("#drpFacultyQualification").val()), c.append("AreaofExcellence", $("#txtAreaofExcellence").val()), c.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]', a).val()), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Institute/FacultyAlumni/Save_Institute_Faculty",
            data: c,
            async: !1,
            cache: !1,
            contentType: !1,
            processData: !1,
            success: function (t) { }
        }).done(function (t) {
            "true" == t.flagExists.toString().toLowerCase() ? swal("Oops...!", "Faculty already exists with same data!") : "true" == t.flaglimit.toString().toLowerCase() ? swal("STOP!!", "You can Add Maximun 10 Records Only.") : "false" == t.flag.toString().toLowerCase() ? swal("Oops...!", "Something went wrong! Please try again.") : swal({
                title: "Success!",
                text: "Data saved successfully",
                type: "",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                $("#btnSaveCancelFaculty").trigger("click"), fill_grid_faculty()
            }), e.removeClass("disabled"), e.text("Save")
        }).error(function () {
            swal("Oops...!", "Please try after some time"), e.text("Save"), e.removeClass("disabled")
        }), e.removeClass("disabled"), e.text("Save")
    }), $("#tbodyFaculty").on("click", ".btnEdit", function (t) {
        t.preventDefault();
        var a = $(this).attr("data-id");
        $.ajax({
            method: "GET",
            url: $("#hdfBaseUrl").val() + "Institute/FacultyAlumni/Select_Institute_Faculty",
            data: {
                ID: a,
                flag_faculty: $("#hdftype").val()
            }
        }).done(function (t) {
            $.each(t.List, function (t, a) {
                $("#hdfFacultyID").val(a.ID), $("#txtFacultyName").val(a.FacultyName), $("#drpFacultyDesignation").val(a.Designation), $("#drpFacultyQualification").val(a.Qualification), $("#txtAreaofExcellence").val(a.AreaofExcellence)
            })
        }).error(function () {
            swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled")
        })
    }), $("#tbodyFaculty").on("click", ".btnDelete", function (t) {
        t.preventDefault();
        var a = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            type: "",
            closeOnConfirm: !0,
            showCancelButton: !0,
            confirmButtonText: "Yes, delete it!",
            confirmButtonClass: "btn-warning",
            showLoaderOnConfirm: !0
        }).then(function () {
            $.ajax({
                method: "POST",
                url: $("#hdfBaseUrl").val() + "Institute/FacultyAlumni/Delete_Institute_faculty",
                data: {
                    ID: a
                },
                success: function (t) { }
            }).done(function (t) {
                fill_grid_faculty(), swal("Success!", "Your data has been deleted.")
            }).error(function () {
                swal("Oops...!", "Something went wrong from our side.")
            })
        })
    })
}

function fill_grid_faculty() {
    $.ajax({
        method: "GET",
        url: $("#hdfBaseUrl").val() + "Institute/FacultyAlumni/Select_Institute_Faculty",
        data: {
            flag_faculty: $("#hdftype").val()
        }
    }).done(function (t) {
        $("#tbodyFaculty").html("");
        var a = 1;
        if (t.List.length > 0) $.each(t.List, function (t, e) {
            var l = $("<tr></tr>");
            l.append("<td>" + a++ + "</td>"), l.append('<td><img style="height:55px;" src="' + $("#hdfBaseUrl").val() + e.Photo.toString() + '" alt="No Image" /></td>'), l.append("<td>" + e.FacultyName.toString() + "</td>"), l.append("<td>" + e.Designation_name.toString() + "</td>"), l.append("<td>" + e.Qualification_Name.toString() + "</td>");
            var n = '<a class="btn btn-success btnEdit" data-id="' + e.ID + '"><i class="glyphicon glyphicon-pencil"></i></a>',
                i = '<a class="btn btn-danger btnDelete" data-id="' + e.ID + '"><i class="glyphicon glyphicon-trash"></i></a>';
            l.append("<td>" + n + " " + i + "</td>"), $("#tbodyFaculty").append(l)
        });
        else {
            var e = $("<tr></tr>");
            e.append('<td colspan="7">No data available.</td>'), $("#tbodyFaculty").append(e)
        }
    }).error(function () {
        swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled")
    })
}
$(document).ready(function () {
    page_click_faculty(), page_init_faculty()
});

