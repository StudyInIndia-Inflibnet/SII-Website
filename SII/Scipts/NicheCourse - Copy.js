$(document).ready(function () {
    page_event(),
    //page_change(),
    FillConditionalDropdown();
    LoadGrid();
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

        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "NICHE/SelectPLNiche",
            data: {
                Discipline_ID: e
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpProgramLevel").append('<option value="' + e.ProgramLevel_Id + '">' + e.ProgramLevel + "</option>")
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });


    });
    $("#drpProgramLevel").on("change", function (t) {
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        var e = $(this).val();
        "" === $("#drpDiscipline").val() || $("#drpDiscipline").val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "NICHE/SelectQNiche",
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: e
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpNatureofcourse").append('<option value="' + e.Qualification_ID + '">' + e.Qualification + "</option>")
            });
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error");
        });
    });
    $("#drpNatureofcourse").on("change", function () {
        $(this).val();
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "NICHE/SelectCSNiche",
            async: !1,
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: $("#drpProgramLevel").val(),
                Qualification_ID: $("#drpNatureofcourse").val()
            }
        }).done(function (t) {
            $("#drpBranch").html(""), $("#drpBranch").prepend('<option value="">--Select--</option>'), $.each(t.List, function (t, e) {
                $("#drpBranch").append('<option value="' + e.CourseOfStudy_ID + '">' + e.CourseOfStudy + "</option>")
            });
        }).error(function () {
            $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        });

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
}

function LoadGrid() {
    var Discipline_ID = $('#drpDiscipline').val() === '' ? 0 : $('#drpDiscipline').val();
    var ProgramLevel_Id = $('#drpProgramLevel').val() === '' ? 0 : $('#drpProgramLevel').val();
    var Qualification_ID = $('#drpNatureofcourse').val() === '' ? 0 : $('#drpNatureofcourse').val();
    var CourseOfStudy_ID = $('#drpBranch').val() === '' ? 0 : $('#drpBranch').val();
    var InstituteType = $('#drpCoursetype').val() === 'All' ? 0 : $('#drpCoursetype').val();
    var GenderRestrictions = $('#GenderRestrictions').val() === '' ? 0 : $('#GenderRestrictions').val();


    FillInstitutes(Discipline_ID, ProgramLevel_Id, Qualification_ID, CourseOfStudy_ID, InstituteType, GenderRestrictions);

}

function FillInstitutes(Discipline_ID, ProgramLevel_Id, Qualification_ID, CourseOfStudy_ID, InstituteType, token = $('input[name="__RequestVerificationToken"]').val(), GenderRestrictions) {
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
            Type: 'InstituteWise',

        },
        async: true
    }).done(function (data) {
        $('#tbody').empty();
        if ($.fn.DataTable.isDataTable("#datatable-grid")) {
            $('#datatable-grid').DataTable().clear().destroy();
        }
        if (data["List"].length > 0) {
            $.each(data["List"], function (index, item) {
                //var tr = $('<tr></tr>');

                var divinstituteSearchBox = $('<div class="instituteSearchBox"></div>');
                //var divLogo = '<div class="col-md-4 col-xs-12"><div class="ncSearchBoxImage" ><img src="' + $('#hdfBaseUrl').val() + item['Photo'] + '" class="img-responsive" /></div></div>';
                var divLogo = '<div class="col-md-4 col-xs-12"><div class="ncSearchBoxImage" ><img src="' + $('#hdfBaseUrl').val() + 'img/noimage.jpg" class="img-responsive" /></div></div>';
                var divName = '<div class="col-md-8 col-xs-12"><div class="" ><p class="mb0">' + item['InstituteName'] + '</p></div></div>';
                var divLocation = '<div class="col-md-5 col-xs-12 mt20 "><center class="location_box"><p><i class="fa fa-map-marker" aria-hidden="true"></i> <strong>Location:</strong> <br/>' + item['City'] + ', ' + item['StateName'] + '</p></center><h5></h5></div>';
                var divCourse = '<div class="col-md-7 col-xs-12 mt20 InstituteCourse"><center class=""><p><i class="fa fa-graduation-cap" aria-hidden="true"></i> No. of Courses Offered:</p><h4><strong>' + item['TotalCourse'] + '</strong></h4></center></div>';
                //var divSeats = '<div class="col-md-2 col-xs-12 InstituteSeats"><center class="location_box"><p><i class="fa fa-users" aria-hidden="true"></i> No. of Seats:</p><h4><strong>' + item['TotalSeats'] + '</strong></h4></center></div>';
                var divMoreDetails = '<div class="col-md-12 col-xs-12 InstituteMoreDetails"><center class="instituteSearchBox-btn"><a href="' + $('#hdfBaseUrl').val() + 'Explore/ViewDetails?instituteid=' + item['InstituteID'].toString() + '&For=Courses' + '">More Details <i class="fa fa-caret-right" aria-hidden="true"></i></a></center></div>';
                //var divDiscipline = '<div style="display:none;">' + item['Discipline'] + '</div>'
                //var divProgramLevel = '<div style="display:none;">' + item['ProgramLevel'] + '</div>'
                //var divQualification = '<div style="display:none;">' + item['Qualification'] + '</div>'
                //var divCourseOfStudy = '<div style="display:none;">' + item['CourseOfStudy'] + '</div>'
                //tr.append('<div class="col-md-4 nicheCoursesSearchBox">' + divName + divLocation + divCourse + divSeats + divMoreDetails + divDiscipline + divProgramLevel + divQualification + divCourseOfStudy + '</div>')
                $('#listCourse').append('<div class="col-md-4 list-div"><div class="panel panel-default"><div class="panel-body panelNicheBody"><div class="row">' + divLogo + divName + '</div><div class="row">' + divLocation + divCourse + '</div>' + divMoreDetails + '</div></div>');
                //$('#divInstitute').append(divinstituteSearchBox);
            });
        } else {
            $('#listCourse').append("<h4 class='text-center'>No data available as per search criteria.</h5>");
        }
        $('.loading').hide();
    }).error(function () {
        $('.loading').hide();
    });
}
