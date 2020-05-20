var forminuse = !1,
    isFillChoices = !1;

function page_init() {
    page_change(), page_click(), fill_programme_level(), selectchoicefillgrid($("#drpDiscipline").val(), $("#drpProgramLevel").val(), $("#drpNatureofcourse").val(), $("#drpBranch").val(), "FillChoiceGrid"), fill_filled_choices()
}

function page_click() {
    $("#tbodyFillChoices").on("click", ".btn-delete-filled-choice", function (e) {
        e.preventDefault();
        var r = $("#frm"),
            i = $('input[name="__RequestVerificationToken"]', r).val(),
            a = $(this),
            l = a.attr("data-id");
        if (forminuse) return !1;
        ConfirmCallBack("Are you sure you want to delete your choice?", function () {
            forminuse = !0, $.ajax({
                method: "POST",
                async: !1,
                url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/DeleteStdCh",
                data: {
                    __RequestVerificationToken: i,
                    id: l
                }
            }).done(function (e) {
                "success" == e.c ? SuccessMessageCallBack("Choice deleted successfully.", function () {
                    window.location.href = window.location.href, fill_filled_choices()
                }, function () {
                    a.text(oldText), a.removeAttr("disabled"), a.removeClass("disabled")
                }) : "sessionexpired" == e.c ? (ErrorMessage(e.m), a.text(oldText), a.removeAttr("disabled"), a.removeClass("disabled")) : "servererror" == e.c ? (ErrorMessage(e.m), a.text(oldText), a.removeAttr("disabled"), a.removeClass("disabled")) : "ChoiceFillingClosed" == e.c && ErrorMessageCallBack(e.m, function () {
                    window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/Closed"
                }), forminuse = !1
            }).error(function () {
                ErrorMessage("Processing error. Kindly refresh page and try again!"), forminuse = !1
            })
        })
    }), $("#btnSave").on("click", function (e) {
        if (e.preventDefault(), 1 != isFillChoices) return ErrorMessage("Please select at least one course to proceed."), !1;
        window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/Rank"
    })
}

function page_change() {
    $("#drpDiscipline").on("change", function (e) {
        fill_programme_level(), $("#drpProgramLevel").val(""), $("#drpNatureofcourse").val(""), $("#drpBranch").val(""), selectchoicefillgrid($("#drpDiscipline").val(), $("#drpProgramLevel").val(), $("#drpNatureofcourse").val(), $("#drpBranch").val(), "FillChoiceGrid"), $("#drpNatureofcourse").val(""), $("#drpBranch").val("")
    }), $("#drpProgramLevel").on("change", function (e) {
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        var r = $(this).val();
        "" == $("#drpDiscipline").val() || $("#drpDiscipline").val(), $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectQ",
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: r
            }
        }).done(function (e) {
            $.each(e.List, function (e, r) {
                $("#drpNatureofcourse").append('<option value="' + r.Qualification_ID + '">' + r.Qualification + "</option>")
            })
        }).error(function () {
            ErrorMessage("Error from server side, please refresh and try again.!!!")
        }), selectchoicefillgrid($("#drpDiscipline").val(), $("#drpProgramLevel").val(), $("#drpNatureofcourse").val(), $("#drpBranch").val(), "FillChoiceGrid"), $("#drpBranch").val("")
    }), $("#drpNatureofcourse").on("change", function () {
        $(this).val(), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectCS",
            async: !1,
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: $("#drpProgramLevel").val(),
                Qualification_ID: $("#drpNatureofcourse").val()
            }
        }).done(function (e) {
            $("#drpBranch").html(""), $("#drpBranch").prepend('<option value="">--Select--</option>'), $.each(e.List, function (e, r) {
                $("#drpBranch").append('<option value="' + r.CourseOfStudy_ID + '">' + r.CourseOfStudy + "</option>")
            })
        }).error(function () {
            $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>')
        }), selectchoicefillgrid($("#drpDiscipline").val(), $("#drpProgramLevel").val(), $("#drpNatureofcourse").val(), $("#drpBranch").val(), "FillChoiceGrid")
    }), $("#drpBranch").on("change", function () {
        selectchoicefillgrid($("#drpDiscipline").val(), $("#drpProgramLevel").val(), $("#drpNatureofcourse").val(), $("#drpBranch").val(), "FillChoiceGrid")
    })
}

function fill_programme_level() {
    $("#drpProgramLevel").html(""), $("#drpProgramLevel").append('<option value="">--Select--</option>');
    var e = $("#drpDiscipline").val();
    $.ajax({
        method: "POST",
        async: !1,
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectPL",
        data: {
            Discipline_ID: e
        }
    }).done(function (e) {
        $.each(e.List, function (e, r) {
            $("#drpProgramLevel").append('<option value="' + r.ProgramLevel_Id + '">' + r.ProgramLevel + "</option>")
        })
    }).error(function () {
        ErrorMessage("Error from server side, please refresh and try again.!!!")
    })
}

function fill_filled_choices() {
    var e = $(document).find("#tbodyFillChoices");
    e.html(""), $.ajax({
        async: !1,
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectStdCh"
    }).done(function (r) {
        $("#tblFillChoices").DataTable().clear().destroy(), $.each(r.List, function (r, i) {
            isFillChoices = !0;
            var a = $("<tr></tr>");
            a.append("<td>" + i.SequenceNumber + "</td>"), a.append("<td>" + i.InstituteName + "</td>"), a.append("<td>" + i.InstituteType + "</td>"), a.append("<td>" + i.Discipline + "</td>"), a.append("<td>" + i.ProgramLevel + "</td>"), a.append("<td>" + i.Coursename + "</td>"), a.append("<td>" + i.Specialization + "</td>"), a.append('<td><a class="btn btn-sm btn-danger btn-delete-filled-choice" data-id="' + i.id + '"><i class="fa fa-trash" ></i></a></td>'), e.append(a)
        }), $("#tblFillChoices").DataTable({
            ordering: !1,
            paging: !1,
            scrollY: "350px",
            scrollCollapse: !0,
            bDestroy: !0
        })
    }).error(function () {
        ErrorMessage("Error from server side, please refresh and try again.!!!")
    })
}
$(document).ready(function () {
    page_init()
});
var table = $(".datatable-grid").DataTable({
    ordering: !1,
    paging: !1,
    scrollY: "350px",
    scrollCollapse: !0,
    bDestroy: !0
});

function selectchoicefillgrid1(e, r, i, a, l) {
    $(".loading").show(), $.ajax({
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/_FillChoiceGrid",
        type: "GET",
        cache: !1,
        async: !1,
        data: {
            Discipline: e,
            ProgramLevel: r,
            NameofCourse: i,
            Specialization: a
        },
        dataType: "html"
    }).done(function (e) {
        var r = $("#" + l);
        r.html(""), r.html(e), table = $(".datatable-grid").DataTable({
            ordering: !1,
            paging: !1,
            scrollY: "350px",
            scrollCollapse: !0,
            bDestroy: !0
        })
    }), $(".loading").hide()
}
function selectchoicefillgrid(e, r, i, a, l) {
    var table = $('#tbl').DataTable({
        destroy: true,
        //orderCellsTop: true,
        //fixedHeader: true,
        //searching: true,
        //paging: true,
        //info: true,                   // TO DISPLAY THE INFO 'SHOWING 1 TO X OF Y ENTRIES'
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'csvHtml5',
                text: 'Export',
                titleAttr: 'CSV'
            },
        ],
        //columnDefs: [{
        //    "targets": 5,
        //    "orderable": false
        //}],
        ajax: {
            'url': $('#hdfBaseUrl').val() + 'admission/StudentChoiceFilling/FillChoiceGrid',
            'data': {
                Discipline: e,
                ProgramLevel: r,
                NameofCourse: i,
                Specialization: a
            },
            'dataType': 'json',
            'cache': false,
            'contentType': 'application/json; charset=utf-8'
        },
        "aoColumns": [
            { 'mData': 'ID', 'sType': 'num', "bVisible": false, "bSearchable": false },
            { 'mData': 'InstituteID', 'sType': 'string', "bVisible": false, "bSearchable": false },
            { 'mData': 'Srno', 'sType': 'string', 'bVisible': true },
            { 'mData': 'InstituteName', 'sType': 'string', 'bVisible': true },
            { 'mData': 'InstituteType', 'sType': 'string', 'bVisible': true },
            { 'mData': 'Discipline', 'sType': 'string', 'bVisible': true },
            { 'mData': 'ProgramLevel', 'sType': 'string', 'bVisible': true },
            { 'mData': 'Coursename', 'sType': 'string', 'bVisible': true },
            { 'mData': 'Specialization', 'sType': 'string', 'bVisible': true },
            { 'mData': 'Eligibility', 'sType': 'string', 'bVisible': true },
            { 'mData': 'AdditionalEligibility', 'sType': 'string', 'bVisible': false },
            { 'mData': 'ID', 'sType': 'num', "bVisible": true, "bSearchable": false }
        ],
        "columnDefs": [{
            "render": function (data, type, row) {
                return '<button data-id="' + row['ID'] + '" data-instid="' + row["InstituteID"] + '" type="button" class="btn btn-space btn-success btnapply"> Apply</button>'
            },
            "targets": 11
        },
        {
            "render": function (data, type, row) {
                var finalEligibility = row['Eligibility'];
                if (row['AdditionalEligibility'] != '') {
                    finalEligibility = row['Eligibility'] + ' <hr /><strong>Additional Qualification:</strong><br />' + row['AdditionalEligibility'];
                }
                return finalEligibility;
            },
            "targets": 9
            //},
            //{
            //    "render": function (data, type, row) {
            //        return '<span style="width: ' + data + '%" class="progress-bar progress-bar-' + (data == '100' ? 'success' : 'info') + '">' + data + '%</span>'
            //    },
            //    "targets": 8

        }]
    });
    $(".loading").hide();
}