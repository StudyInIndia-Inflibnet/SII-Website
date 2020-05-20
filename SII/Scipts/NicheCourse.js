$(document).ready(function () {
    page_event(),
        //page_change(),
        FillConditionalDropdown();
    LoadGrid();
    DefaultSelect();

});
function page_event() {
    page_click();
    //Select_Course();
    //fillPercentage();
    //page_load_niche();
    //$("#drpAnnualBoardingFeesCurrency").attr("readonly");
    //$("#drpSAARCFeesCurrency").attr("readonly");
    //$("#drpNonSAARCCurrency").attr("readonly");
}
function FillConditionalDropdown() {

    $("#drpDiscipline").on("change", function (t) {
        $("#drpCoursetype").html(""),
            $("#drpProgramLevel").html(""), $("#drpProgramLevel").append('<option value="">--Select--</option>');
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        var e = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "NICHE/SelectDropdown_CourseType",
            data: {
                Discipline_ID: e
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpCoursetype").append('<option value="' + e.Id + '">' + e.Value + "</option>");
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
        LoadGrid();
    });

    $("#drpCoursetype").on("change", function (t) {

        $("#drpProgramLevel").html(""),
            $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        var e = $(this).val();
        var Discipline_ID = $('#drpDiscipline').val() === '' ? 0 : $('#drpDiscipline').val();
        var ProgramLevel_Id = $('#drpProgramLevel').val() === '' ? 0 : $('#drpProgramLevel').val();
        var Qualification_ID = $('#drpNatureofcourse').val() === '' ? 0 : $('#drpNatureofcourse').val();
        var CourseOfStudy_ID = $('#drpBranch').val() === '' ? 0 : $('#drpBranch').val();
        var InstituteType = $('#drpCoursetype').val() === 'All' ? 0 : $('#drpCoursetype').val();
        var GenderRestrictions = $('#GenderRestrictions').val() === '' ? 0 : $('#GenderRestrictions').val();

        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "NICHE/SelectPLNiche",
            data: {
                __RequestVerificationToken: "",
                Discipline_ID: Discipline_ID,
                ProgramLevel_Id: ProgramLevel_Id,
                Qualification_ID: Qualification_ID,
                CourseOfStudy_ID: CourseOfStudy_ID,
                InstituteType: InstituteType,
                Type: 'AllNicheCourse'
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpProgramLevel").append('<option value="' + e.ProgramLevel_Id + '">' + e.ProgramLevel + "</option>");
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
        LoadGrid();

    });

    $("#drpProgramLevel").on("change", function (t) {
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        var e = $(this).val();
        "" === $("#drpDiscipline").val() || $("#drpDiscipline").val();
        var Discipline_ID = $('#drpDiscipline').val() === '' ? 0 : $('#drpDiscipline').val();
        var ProgramLevel_Id = $('#drpProgramLevel').val() === '' ? 0 : $('#drpProgramLevel').val();
        var Qualification_ID = $('#drpNatureofcourse').val() === '' ? 0 : $('#drpNatureofcourse').val();
        var CourseOfStudy_ID = $('#drpBranch').val() === '' ? 0 : $('#drpBranch').val();
        var InstituteType = $('#drpCoursetype').val() === 'All' ? 0 : $('#drpCoursetype').val();
        var GenderRestrictions = $('#GenderRestrictions').val() === '' ? 0 : $('#GenderRestrictions').val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "NICHE/SelectQNiche",
            data: {
                __RequestVerificationToken: "",
                Discipline_ID: Discipline_ID,
                ProgramLevel_Id: ProgramLevel_Id,
                Qualification_ID: Qualification_ID,
                CourseOfStudy_ID: CourseOfStudy_ID,
                InstituteType: InstituteType,
                Type: 'AllNicheCourse'
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpNatureofcourse").append('<option value="' + e.Qualification_ID + '">' + e.Qualification + "</option>")
            });

        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
        LoadGrid();
    });

    $("#drpNatureofcourse").on("change", function () {
        var Discipline_ID = $('#drpDiscipline').val() === '' ? 0 : $('#drpDiscipline').val();
        var ProgramLevel_Id = $('#drpProgramLevel').val() === '' ? 0 : $('#drpProgramLevel').val();
        var Qualification_ID = $('#drpNatureofcourse').val() === '' ? 0 : $('#drpNatureofcourse').val();
        var CourseOfStudy_ID = $('#drpBranch').val() === '' ? 0 : $('#drpBranch').val();
        var InstituteType = $('#drpCoursetype').val() === 'All' ? 0 : $('#drpCoursetype').val();
        var GenderRestrictions = $('#GenderRestrictions').val() === '' ? 0 : $('#GenderRestrictions').val();
        $(this).val();
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "NICHE/SelectCSNiche",
            async: !1,
            data: {
                __RequestVerificationToken: "",
                Discipline_ID: Discipline_ID,
                ProgramLevel_Id: ProgramLevel_Id,
                Qualification_ID: Qualification_ID,
                CourseOfStudy_ID: CourseOfStudy_ID,
                InstituteType: InstituteType,
                Type: 'AllNicheCourse'
            }
        }).done(function (t) {
            $("#drpBranch").html(""), $("#drpBranch").prepend('<option value="">--Select--</option>'), $.each(t.List, function (t, e) {
                $("#drpBranch").append('<option value="' + e.CourseOfStudy_ID + '">' + e.CourseOfStudy + "</option>")
            });
        }).error(function () {
            $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        });
        LoadGrid();
    });

    $("#drpBranch").on("change", function () {
        LoadGrid();
    });
    $("#drpMonth").on("change", function () {
        LoadGrid();
    });
    $("#drpYear").on("change", function () {
        LoadGrid();
    });
}
function page_load_niche() {
    //setStartEndDate();
}
function page_click() {
    $('#btnSearchInstitute').on('click', function (e) {
        e.preventDefault();
        LoadGrid();
    });
    $('#btnReset').on('click', function (e) {
        e.preventDefault();
        DefaultSelect();
    });
}
function LoadGrid() {
    var Discipline_ID = $('#drpDiscipline').val() === '' ? 0 : $('#drpDiscipline').val();
    var ProgramLevel_Id = $('#drpProgramLevel').val() === '' ? 0 : $('#drpProgramLevel').val();
    var Qualification_ID = $('#drpNatureofcourse').val() === '' ? 0 : $('#drpNatureofcourse').val();
    var CourseOfStudy_ID = $('#drpBranch').val() === '' ? 0 : $('#drpBranch').val();
    var InstituteType = $('#drpCoursetype').val() === 'All' ? 0 : $('#drpCoursetype').val();
    var GenderRestrictions = $('#GenderRestrictions').val() === '' ? 0 : $('#GenderRestrictions').val();
    var Year = $('#drpYear').val() === '' ? 0 : $('#drpYear').val();
    var Month = $('#drpMonth').val() === '' ? 0 : $('#drpMonth').val();
    FillInstitutes(Discipline_ID, ProgramLevel_Id, Qualification_ID, CourseOfStudy_ID, InstituteType, '', GenderRestrictions, Month, Year);

}
function DefaultSelect() {

    if ($("#hdfFor").val() === "Yoga") {
        $("#drpDiscipline").val(20);
        $("#drpDiscipline").val(20).trigger('change');
    }
    else if ($("#hdfFor").val() === "Ayurvedic") {
        $("#drpDiscipline").val(57);
        $("#drpDiscipline").val(57).trigger('change');
    }
    else if ($("#hdfFor").val() === "Buddhism") {
        $("#drpDiscipline").val(58);
        $("#drpDiscipline").val(58).trigger('change');
    }
    else if ($("#hdfFor").val() === "Tibetan") {
        $("#drpDiscipline").val(59);
        $("#drpDiscipline").val(59).trigger('change');
    }
    else {
        $("#drpDiscipline").val('');
        $("#drpDiscipline").val('').trigger('change'); }
    $('#drpYear').val('');
    $('#drpMonth').val('');
}

function FillInstitutes(Discipline_ID, ProgramLevel_Id, Qualification_ID, CourseOfStudy_ID, InstituteType, token = $('input[name="__RequestVerificationToken"]').val(), GenderRestrictions, Month, Year) {
    $('#listCourse').html('');
    $('.loading').show();
    $.ajax({
        method: 'POST',
        url: $('#hdfBaseUrl').val() + 'NICHE/SelectNicheCourse',
        data: {
            __RequestVerificationToken: token,
            Discipline_ID: Discipline_ID,
            ProgramLevel_Id: ProgramLevel_Id,
            Qualification_ID: Qualification_ID,
            CourseOfStudy_ID: CourseOfStudy_ID,
            InstituteType: InstituteType,
            Month_id: Month,
            Year_id: Year,
            Type: 'AllNicheCourse',
        },
        async: true
    }).done(function (data) {
        $('#datatable-grid').DataTable().clear().destroy();
        $('#tbodyCourse').empty();
        if ($.fn.DataTable.isDataTable("#datatable-grid")) {
            $('#datatable-grid').DataTable().clear().destroy();
        }
        if (data["List"].length > 0) {
            var e = 1;
            $.each(data["List"], function (index, item) {
                var r = $("<tr></tr>");
                r.append("<td>" + e++ + "</td>");
                r.append("<td>" + item['Discipline'] + "</td>");
                r.append("<td>" + item['CourseOfStudy'] + "</td>");
                r.append("<td>" + item['ProgramLevel'] + "</td>");
                r.append("<td>" + item['InstituteName'] + " ," + item['City'] + " ," + item['StateName'] +  "</td>");
                r.append("<td>" + item['StartDate'] + "</td>");
                r.append("<td>" + item['EndDate'] + "</td>");
                editbtn = '<a class="btn btn-success btnGridEdit" href="/Explore/ViewDetails?instituteid=' + item['InstituteID'] + '&For=NICHECourse&NicheCourseId=' + item['ID'] + '" title="View Course Details" data-toggle="tooltip" type="button" data-id="' + item['ProgramLevel'] + '" ><i class="fa fa-list-ul"></i></a>';
                Applybtn = '<a class="btn btn-danger btnGridApply" href="/admission/RegistrationsNiche?instituteid=' + item['InstituteID'] + '&For=NICHECourse&NicheCourseId=' + item['ID'] + '" title="Apply Now" data-toggle="tooltip" type="button" data-id="' + item['ProgramLevel'] + '" >Apply Now</a>';
                r.append("<td>" + editbtn + "&nbsp;&nbsp;</td>");
                r.append("<td>" + Applybtn + "&nbsp;&nbsp;</td>");
                $("#tbodyCourse").append(r);
            });
        } else {
            $('#tbodyCourse').append("<h12 class='text-center'>No data available as per search criteria.</h5>");
        }
        if (data["ListYear"].length > 0) {
            var Year = $('#drpYear').val();
            $("#drpYear").html(""),
                $("#drpYear").append('<option value="">--Select--</option>');
            $.each(data["ListYear"], function (index, item) {
                $("#drpYear").append('<option value="' + item.Year_id + '">' + item.Year + "</option>");
            });
            $('#drpYear').val(Year);
        }

        if (data["ListMonth"].length > 0) {
            var Month = $('#drpMonth').val();
            $("#drpMonth").html(""),
                $("#drpMonth").append('<option value="">--Select--</option>');
            $.each(data["ListMonth"], function (index, item) {
                $("#drpMonth").append('<option value="' + item.Month_id + '">' + item.Month + "</option>");
            });
            $('#drpMonth').val(Month);
        }
        $('.loading').hide();
    }).error(function () {
        $('.loading').hide();
    });
}
