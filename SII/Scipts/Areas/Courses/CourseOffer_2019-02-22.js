$(document).ready(function () {
    page_event();
    page_change();
    FillConditionalDropdown();
    //validation();
});

function page_event() {
    page_click();
    Select_Course();
    fillPercentage();
    $('#drpAnnualBoardingFeesCurrency').attr('readonly');
    $('#drpSAARCFeesCurrency').attr('readonly');
    $('#drpNonSAARCCurrency').attr('readonly');
}

function page_change() {
    $('#drpQ1Qualification').on('change', function (e) {
        e.preventDefault();
        $('.Q1_TXT').val('');
        $('.Q1_TXT').attr('readonly', true);
        $('.Q1_TXT').removeAttr('required');
        $('.Q1_TXT.drpPercentage').attr('disabled', true);
        if ($(this).val() == "10_2") {
            $('.Q1_10_2').removeAttr('readonly');
            $('.Q1_10_2').attr('required', true);
            $('.Q1_10_2.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "Diploma") {
            $('.Q1_Diploma').removeAttr('readonly');
            $('.Q1_Diploma').attr('required', true);
            $('.Q1_Diploma.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "Either") {
            $('.Q1_TXT').removeAttr('readonly');
            $('.Q1_TXT').attr('required', true);
            $('.Q1_TXT.drpPercentage').removeAttr('disabled');
        }
    });
    $('#drpQ2Qualification').on('change', function (e) {
        e.preventDefault();
        $('.Q2_TXT').val('');
        $('.Q2_TXT').attr('readonly', true);
        $('.Q2_TXT').removeAttr('required');
        $('.Q2_TXT.drpPercentage').attr('disabled', true);
        if ($(this).val() == "UG") {
            $('.Q2_UG').removeAttr('readonly');
            $('.Q2_UG').attr('required', true);
            $('.Q2_UG.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "PG") {
            $('.Q2_PG').removeAttr('readonly');
            $('.Q2_PG').attr('required', true);
            $('.Q2_PG.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "Either") {
            $('.Q2_TXT').removeAttr('readonly');
            $('.Q2_TXT').attr('required', true);
            $('.Q2_TXT.drpPercentage').removeAttr('disabled');
        }
    });
    $('#drpQ3Qualification').on('change', function (e) {
        e.preventDefault();
        $('.Q3_TXT').val('');
        $('.Q3_TXT').attr('readonly', true);
        $('.Q3_TXT').removeAttr('required');
        $('.Q2_TXT.drpPercentage').attr('disabled', true);
        if ($(this).val() == "PG") {
            $('.Q3_PG').removeAttr('readonly');
            $('.Q3_PG').attr('required', true);
            $('.Q3_PG.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "Mphil") {
            $('.Q3_Mphil').removeAttr('readonly');
            $('.Q3_Mphil').attr('required', true);
            $('.Q3_Mphil.drpPercentage').removeAttr('disabled');
        } else if ($(this).val() == "Either") {
            $('.Q3_TXT').removeAttr('readonly');
            $('.Q3_TXT').attr('required', true);
            $('.Q3_TXT.drpPercentage').removeAttr('disabled');
        }
    });

    $('#rbtJEEMainReqNo').change(function () {
        $('#tx_JEEMainscoreReq').removeAttr('required');
        $('#tx_JEEMainscoreReq').prop('disabled', true);
        $('#tx_JEEMainscoreReq').val('');
    });
    $('#rbtJEEAdvanceReqNo').change(function () {
        $('#tx_JEEAdvanceScoreReq').removeAttr('required');
        $('#tx_JEEAdvanceScoreReq').prop('disabled', true);
        $('#tx_JEEAdvanceScoreReq').val('');
    });
    $('#rbtIELTSReqNo').change(function () {
        $('#tx_IELTSscoreReq').removeAttr('required');
        $('#tx_IELTSscoreReq').prop('disabled', true);
        $('#tx_IELTSscoreReq').val('');
    });
    $('#rbtGMATReqNo').change(function () {
        $('#tx_GMATScoreReq').removeAttr('required');
        $('#tx_GMATScoreReq').prop('disabled', true);
        $('#tx_GMATScoreReq').val('');
    });
    $('#rbtTOFELReqNo').change(function () {
        $('#tx_TOFELScoreReq').removeAttr('required');
        $('#tx_TOFELScoreReq').prop('disabled', true);
        $('#tx_TOFELScoreReq').val('');
    });
    $('#rbtSATReqNo').change(function () {
        $('#tx_SATScoreReq').removeAttr('required');
        $('#tx_SATScoreReq').prop('disabled', true);
        $('#tx_SATScoreReq').val('');
    });
    $('#rbtGATEReqNo').change(function () {
        $('#tx_GATEScoreReq').removeAttr('required');
        $('#tx_GATEScoreReq').prop('disabled', true);
        $('#tx_GATEScoreReq').val('');
    });
    $('#rbtJEEMainReqYes').change(function () {
        $('#tx_JEEMainscoreReq').attr('required', true);
        $('#tx_JEEMainscoreReq').prop('disabled', false);
    });
    $('#rbtJEEAdvanceReqYes').change(function () {
        $('#tx_JEEAdvanceScoreReq').attr('required', true);
        $('#tx_JEEAdvanceScoreReq').prop('disabled', false);
    });
    $('#rbtIELTSReqYes').change(function () {
        $('#tx_IELTSscoreReq').attr('required', true);
        $('#tx_IELTSscoreReq').prop('disabled', false);
    });
    $('#rbtGMATReqYes').change(function () {
        $('#tx_GMATScoreReq').attr('required', true);
        $('#tx_GMATScoreReq').prop('disabled', false);
    });
    $('#rbtTOFELReqYes').change(function () {
        $('#tx_TOFELScoreReq').attr('required', true);
        $('#tx_TOFELScoreReq').prop('disabled', false);
    });
    $('#rbtSATReqYes').change(function () {
        $('#tx_SATScoreReq').attr('required', true);
        $('#tx_SATScoreReq').prop('disabled', false);
    });
    $('#rbtGATEReqYes').change(function () {
        $('#tx_GATEScoreReq').attr('required', true);
        $('#tx_GATEScoreReq').prop('disabled', false);
    });

    $('#drpAnnualFeesCurrency').on('change', function () {
        var value = $(this).val();
        if (value == '') {
            $('.txt-fee-currency').val('--Select--');
        } else {
            $('.txt-fee-currency').val(value);
        }
    });

    $('#tbodyAE').on('change', '.drpAEAditionalExam', function () {
        var drp = $(this);
        var tr = drp.parent().parent();
        var AEFor = drp.find('option:selected').attr('data-for');
        if (AEFor == 'date') {
            tr.find('td:eq(1)').html('<input type="text" placeholder="dd-mm-yyyy" readonly="" class="form-control txtAECutOff datepicker">');
            var newCurYear = new Date().getFullYear();
            $(".datepicker").datepicker({
                orientation: "left",
                autoclose: !0,
                yearRange: '1950:' + newCurYear,
                dateFormat: "dd-mm-yy",
                todayHighlight: false,
                changeMonth: true,
                changeYear: true
            });
        } else {
            //tr.find('td:eq(1)').html('<input type="text" placeholder="Cutt-off marks" pattern="^\[0-9]{1,4}+(\.[0-9][0-9])?$" class="form-control txtAECutOff">')
            //tr.find('td:eq(1)').html('<input type="text" placeholder="Cutt-off marks" class="form-control txtAECutOff">');
            var id = drp.val();
            var strOption = '';
            $.ajax({
                method: 'POST',
                async: false,
                url: $('#hdfBaseUrl').val() + 'Institute/Courses/SelectAES',
                data: { 'id': id }
            }).done(function (data) {
                $.each(data['List'], function (index, value) {
                    strOption = strOption + '<option value="' + value['AditionalExamScore'] + '">' + value['AditionalExamSocreDisplay'] + '</option>';
                });
            }).error(function () {
                swal('error', 'Somthing went wrong. Please try again.', 'error');
            });
            tr.find('td:eq(1)').html('<select class="form-control txtAECutOff"><option value="">--Select Cut-off marks--</option>' + strOption + '</select>');
        }
    });

    $('#tbodyEC').on('change', '.drpECOperator', function () {
        var drp = $(this);
        var selectedText = drp.find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            $('#btnAddMoreCondition').show();
        } else {
            $('#tbodySubjectPercentage').find('tr.newSPTr').remove();
            $('#btnAddMoreCondition').hide();
        }
    });



}

function FillConditionalDropdown() {
    //$('.CourseChange').on('change', function () {
    //    $.ajax({
    //        method: 'POST',
    //        url: '/Institute/Courses/SelectNatureofcourse',
    //        async: false,
    //        data: { Discipline_ID: $('#drpDiscipline').val(), ProgramLevel_Id: $('#drpProgramLevel').val() }
    //    }).done(function (data) {
    //        $('#drpNatureofcourse').html('');
    //        $('#drpNatureofcourse').prepend('<option value="">--Select--</option>');
    //        $.each(data["List"], function (index, item) {
    //            $('#drpNatureofcourse').append('<option value="' + item['Natureofcourse_Id'] + '">' + item['NatureOfCourse'] + '</option>');
    //        });
    //    }).error(function () {
    //        $('#drpNatureofcourse').html('');
    //        $('#drpNatureofcourse').append('<option value="">-Select-</option>');
    //    });
    //});
    //$('#drpNatureofcourse').on('change', function () {
    //    var id = $(this).val();
    //    $.ajax({
    //        method: 'POST',
    //        url: '/Institute/Courses/SelectBranch',
    //        async: false,
    //        data: { Natureofcourse_Id: id }
    //    }).done(function (data) {
    //        $('#drpBranch').html('');
    //        $('#drpBranch').prepend('<option value="">--Select--</option>');

    //        $.each(data["List"], function (index, item) {
    //            $('#drpBranch').append('<option value="' + item['Branch_Id'] + '">' + item['Branchname'] + '</option>');
    //        });
    //        $('#drpBranch').append('<option value="AddBranch">Other (Add Branch/Subject)</option>');
    //    }).error(function () {
    //        $('#drpBranch').html('');
    //        $('#drpBranch').append('<option value="">-Select-</option>');
    //    });
    //});
    //$('#drpBranch').on('change', function () {
    //    if ($('#drpBranch').val() == "AddBranch") {
    //        $('#Divother').show();
    //        $('#txtbranchnamesubject').attr('required', true);
    //    } else {
    //        $('#Divother').hide();
    //        $('#txtbranchnamesubject').removeAttr('required');
    //    }
    //});

    $('#drpDiscipline').on('change', function (e) {
        $('#drpProgramLevel').html('');
        $('#drpProgramLevel').append('<option value="">--Select--</option>');
        var id = $(this).val();
        $.ajax({
            method: 'POST',
            async: false,
            url: $('#hdfBaseUrl').val() + 'Institute/Courses/SelectPL',
            data: { 'Discipline_ID': id }
        }).done(function (data) {
            $.each(data['List'], function (index, value) {
                $('#drpProgramLevel').append('<option value="' + value['ProgramLevel_Id'] + '">' + value['ProgramLevel'] + '</option>');
            });
        }).error(function () {
            swal('error', 'Somthing went wrong. Please try again.', 'error');
        });
    });
    $('#drpProgramLevel').on('change', function (e) {
        $('#drpNatureofcourse').html('');
        $('#drpNatureofcourse').append('<option value="">--Select--</option>');
        var ProgramLevel_Id = $(this).val();
        var Discipline_ID = ($('#drpDiscipline').val() == "" ? '0' : $('#drpDiscipline').val());
        $.ajax({
            method: 'POST',
            async: false,
            url: $('#hdfBaseUrl').val() + 'Institute/Courses/SelectQ',
            data: { 'Discipline_ID': $('#drpDiscipline').val(), 'ProgramLevel_Id': ProgramLevel_Id }
        }).done(function (data) {
            $.each(data['List'], function (index, value) {
                $('#drpNatureofcourse').append('<option value="' + value['Qualification_ID'] + '">' + value['Qualification'] + '</option>');
            });
        }).error(function () {
            swal('error', 'Somthing went wrong. Please try again.', 'error');
        });
    });
    $('#drpNatureofcourse').on('change', function () {
        var id = $(this).val();
        $.ajax({
            method: 'POST',
            url: '/Institute/Courses/SelectCS',
            async: false,
            data: { Discipline_ID: $('#drpDiscipline').val(), ProgramLevel_Id: $('#drpProgramLevel').val(), Qualification_ID: $('#drpNatureofcourse').val() }
        }).done(function (data) {
            $('#drpBranch').html('');
            $('#drpBranch').prepend('<option value="">--Select--</option>');
            $.each(data["List"], function (index, item) {
                $('#drpBranch').append('<option value="' + item['CourseOfStudy_ID'] + '">' + item['CourseOfStudy'] + '</option>');
            });
        }).error(function () {
            $('#drpBranch').html('');
            $('#drpBranch').append('<option value="">-Select-</option>');
        });
    });
    $('#tbodyEC').on('change', '.drpECQualification', function () {
        var id = $(this).val();
        var drpECSubject = $(this).parent().parent().find('.drpECSubject');
        drpECSubject.html('');
        drpECSubject.append('<option value="">-Select-</option>');
        $.ajax({
            method: 'POST',
            url: '/Institute/Courses/SelectECS',
            async: false,
            data: { id: id }
        }).done(function (data) {
            $.each(data["List"], function (index, item) {
                drpECSubject.append('<option value="' + item['EduSubject_Id'] + '">' + item['EduSubject'] + '</option>');
            });
        }).error(function () {

        });
    });
}

function validation() {
    //$('#txttotalseats').SetNumericOnly();
    //$('.totalseat').SetNumericOnly();
    $('.totalseat').on('change', function () {
        alert();
        var g1 = $('#txtfeeswaiverg1').val()
        var g2 = $('#txtfeeswaiverg2').val()
        var g3 = $('#txtfeeswaiverg3').val()
        var g4 = $('#txtfeeswaiverg4').val()

        var totalseat = parseInt(g1) + parseInt(g2) + parseInt(g3) + parseInt(g4)

        if (parseInt($('#txttotalseats').val()) != parseInt(totalseat)) {
            swal("Warning.!", "Sum of Tuition Fee Waiver seat can't greater than total seat offer by institue");
        }
        return;
    });
}

function page_click() {
    var Q0Req = 0, Q1Req = 0, Q2Req = 0, Q3Req = 0;
    var Q1Qualification = '', Q1Subject = '', Q1Percentage = '';
    var Q2Qualification = '', Q2Subject = '', Q2Percentage = '';
    var Q3Qualification = '', Q3Subject = '', Q3Percentage = '';

    $('#btnNewCost').on('click', function (e) {
        Clear();
    });

    $('#btnSaveCourse').on('click', function (e) {
        e.preventDefault();

        var frm = $('#frmCoursesOffer');
        var frmParsley = frm.parsley();
        frmParsley.validate();
        if (!frm.parsley().isValid()) {
            return false;
        }
        var flagEC = false;
        $('#tbodyEC').find('tr.newtr').each(function () {
            flagEC = true;
        });
        if (!flagEC) {
            swal("Warning.!", "Atleast one Educational Qualification is required.");
            return false;
        }

        //if ($('#drpQ1Qualification').val() == "10_2") {
        //    Q1Qualification = encodeURI($('#txtQ1Qualification_10_2').val());
        //    Q1Subject = $('#txtQ1Subject_10_2').val();
        //    Q1Percentage = $('#txtQ1Percentage_10_2').val();
        //} else if ($('#drpQ1Qualification').val() == "Diploma") {
        //    Q1Qualification = encodeURI($('#txtQ1Qualification_Diploma').val());
        //    Q1Subject = $('#txtQ1Subject_Diploma').val();
        //    Q1Percentage = $('#txtQ1Percentage_Diploma').val();
        //} else if ($('#drpQ1Qualification').val() == "Either") {
        //    Q1Qualification = encodeURI($('#txtQ1Qualification_10_2').val() + '/' + $('#txtQ1Qualification_Diploma').val());
        //    Q1Subject = $('#txtQ1Subject_10_2').val() + '/' + $('#txtQ1Subject_Diploma').val();
        //    Q1Percentage = $('#txtQ1Percentage_10_2').val() + '/' + $('#txtQ1Percentage_Diploma').val();
        //}
        //Q1Qualification = Q1Qualification.replace('+', '%2B');

        //if ($('#drpQ2Qualification').val() == "UG") {
        //    Q2Qualification = $('#txtQ2Qualification_UG').val();
        //    Q2Subject = $('#txtQ2Subject_UG').val();
        //    Q2Percentage = $('#txtQ2Percentage_UG').val();
        //} else if ($('#drpQ2Qualification').val() == "PG") {
        //    Q2Qualification = $('#txtQ2Qualification_PG').val();
        //    Q2Subject = $('#txtQ2Subject_PG').val();
        //    Q2Percentage = $('#txtQ2Percentage_PG').val();
        //} else if ($('#drpQ2Qualification').val() == "Either") {
        //    Q2Qualification = $('#txtQ2Qualification_UG').val() + '/' + $('#txtQ2Qualification_PG').val();
        //    Q2Subject = $('#txtQ2Subject_UG').val() + '/' + $('#txtQ2Subject_PG').val();
        //    Q2Percentage = $('#txtQ2Percentage_UG').val() + '/' + $('#txtQ2Percentage_PG').val();
        //}


        //if ($('#drpQ3Qualification').val() == "PG") {
        //    Q3Qualification = $('#txtQ3Qualification_PG').val();
        //    Q3Subject = $('#txtQ3Subject_PG').val();
        //    Q3Percentage = $('#txtQ3Percentage_PG').val();
        //} else if ($('#drpQ3Qualification').val() == "Mphil") {
        //    Q3Qualification = $('#txtQ3Qualification_Mphil').val();
        //    Q3Subject = $('#txtQ3Subject_Mphil').val();
        //    Q3Percentage = $('#txtQ3Percentage_Mphil').val();
        //} else if ($('#drpQ3Qualification').val() == "Either") {
        //    Q3Qualification = $('#txtQ3Qualification_PG').val() + '/' + $('#txtQ3Qualification_Mphil').val();
        //    Q3Subject = $('#txtQ3Subject_PG').val() + '/' + $('#txtQ3Subject_Mphil').val();
        //    Q3Percentage = $('#txtQ3Percentage_PG').val() + '/' + $('#txtQ3Percentage_Mphil').val();
        //}

        var g1 = $('#txtfeeswaiverg1').val()
        var g2 = $('#txtfeeswaiverg2').val()
        var g3 = $('#txtfeeswaiverg3').val()
        var g4 = $('#txtfeeswaiverg4').val()

        var totalseat = parseInt(g1) + parseInt(g2) + parseInt(g3) + parseInt(g4);
        if (parseInt($('#txttotalseats').val()) > parseInt(totalseat)) {
            swal("Warning.!", "Sum of G1, G2, G3 and G4 should be equal to total number of seats for this course.");
            return false;
        }
        if (parseInt($('#txttotalseats').val()) < parseInt(totalseat)) {
            swal("Warning.!", "Sum of G1, G2, G3 and G4 should be equal to total number of seats for this course.");
            return false;
        }
        //if ($('#hdfIsGivenFromInstitute').val() == '1') {
        //    if (parseInt(g1) == 0 && parseInt(g2) == 0 && parseInt(g3) == 0 && parseInt(g4) == 0) {
        //        swal("Warning.!", "All fee waivers cannot be zero(0).");
        //        return false;
        //    }
        //}
        if (parseInt(g1) == 0 && parseInt(g2) == 0 && parseInt(g3) == 0 && parseInt(g4) == 0) {
            swal("Warning.!", "All fee waivers cannot be zero(0).");
            return false;
        }
        var btn = $(this);
        btn.text('Processing...');
        btn.addClass('disabled');

        $("#drpDiscipline").prop("disabled", false);
        $("#drpProgramLevel").prop("disabled", false);
        $("#drpNatureofcourse").prop("disabled", false);
        $("#drpBranch").prop("disabled", false);
        $('#drpAnnualFeesCurrency').prop("disabled", false);
        $('#drpAnnualBoardingFeesCurrency').prop("disabled", false);
        $.ajax({
            method: 'POST',
            url: '/Institute/Courses/SaveCourseOffers',
            data: frm.serialize() + '&Q0Req=' + Q0Req + '&Q1Req=' + Q1Req + '&Q2Req=' + Q2Req + '&Q3Req=' + Q3Req
                + '&Q1Qualification=' + Q1Qualification + '&Q1Subject=' + Q1Subject + '&Q1Percentage=' + Q1Percentage
                + '&Q2Qualification=' + Q2Qualification + '&Q2Subject=' + Q2Subject + '&Q2Percentage=' + Q2Percentage
                + '&Q3Qualification=' + Q3Qualification + '&Q3Subject=' + Q3Subject + '&Q3Percentage=' + Q3Percentage
                + '&EduQualifications=' + GET_EC() + '&AdditionalExams=' + GET_AE(),
            async: false,
            success: function (data) {
            }
        }).done(function (data) {
            if (data['flag'].toString().toLowerCase() == 'false') {
                swal({
                    title: "Course Already Exist",
                    text: "Record Already Exist!",
                    type: "warning",
                });
                btn.text('Save');
                btn.removeClass('disabled');
            }
            else if (data['flag'].toString().toLowerCase() == 'true') {
                swal({
                    title: "Saved",
                    text: "Courses has been saved successfully",
                    type: "success",
                    closeOnConfirm: true,
                    confirmButtonText: "OK",
                    confirmButtonClass: 'btn-primary',
                    showLoaderOnConfirm: true,
                }).then(function () {
                    Clear();
                    Select_Course();
                    $('#divhideshow').hide();
                });
                btn.text('Save');
                btn.removeClass('disabled');
            }
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.");
            btn.text('Save');
            btn.removeClass('disabled');
        });
    });

    $('#tbodyCourse').on('click', '.btnGridEdit', function () {
        var btnGridEdit = $(this);
        $.ajax({
            method: 'get',
            async: false,
            url: '/Institute/Courses/SelectCourseOffers',
            data: { ID: btnGridEdit.attr('data-id') },
            success: function (data) {
            }
        }).done(function (data) {
            document.body.scrollTop = 0; // For Safari
            document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
            var array = data['List'][0];
            $('#divhideshow').show();
            $('#hdfID').val(array['ID']);
            $('#drpDiscipline').val(array['Discipline_ID']).trigger('change');
            $('#drpProgramLevel').val(array['ProgramLevel_Id']).trigger('change');
            // $('.CourseChange').trigger('change');
            $('#drpNatureofcourse').val(array['Natureofcourse_Id']).trigger('change');
            //$('#drpNatureofcourse').trigger('change');
            $('#drpBranch').val(array['Branch_Id']);
            $('#txtEligibilityCriteria').val(array['EligibilityCriteria']);
            $('#txttotalseats').val(array['SeatForForeignStudent']);
            $('#txtAnnualFees').val(array['AnnualTutionFees']);
            $('#txttotalBoarding').val(array['AnnualBoardingFees']);
            $('#drpAnnualFeesCurrency').val(array['AnnualTutionFeesCurrency']).trigger('change');
            $('#drpAnnualBoardingFeesCurrency').val(array['AnnualBoardingFeesCurrency']);
            $('#txtfeeswaiverg1').val(array['G1SeatWaiver']);
            $('#txtfeeswaiverg2').val(array['G2SeatWaiver']);
            $('#txtfeeswaiverg3').val(array['G3SeatWaiver']);
            $('#txtfeeswaiverg4').val(array['G4SeatWaiver']);
            $('#txtCredits').val(array['Credits']);
            $('#txtcourseduration').val(array['CourseDurations']);
            $('#txtClassrooms').val(array['ClassRoomHours']);
            $('#drpCoursePattern').val(array['CoursePatterns']);
            $('#txtCourseDescription').val(array['CourseDesc']);
            $('#txtAdmission').val(array['AdmissionReq']);
            $('#txtSAARC').val(array['FeesForSAARCCountry']);
            $('#txtNonSAARC').val(array['FeesForNonSAARCCountry']);
            $('#drpSAARCFeesCurrency').val(array['FeesForSAARCCountryCurrency']);
            $('#drpNonSAARCCurrency').val(array['FeesForNonSAARCCountryCurrency']);
            if (array['Q0Req'].toString().toLowerCase() == "true") {
                $('#cbQ0Req').trigger('click');
                if (array['Q0Qualification'].toString().toLowerCase() == '10') {
                    $('#txtQ0Subject').val(array['Q0Subject']);
                    $('#txtQ0Percentage').val(array['Q0Percentage']);
                }
            }
            if (array['Q1Req'].toString().toLowerCase() == "true") {
                $('#cbQ1Req').trigger('click');
                $('#drpQ1Qualification').val((array['Q1Qualification'].toString().toLowerCase() == '10+2/diploma' ? 'Either' : ('10+2' ? '10_2' : array['Q1Qualification'])));
                $('#drpQ1Qualification').trigger('change');
                var arrayQ1Qualification = array['Q1Qualification'].split('/');
                $.each(array['Q1Subject'].split('/'), function (index, value) {
                    $('#txtQ1Subject_' + (arrayQ1Qualification[index]).replace('+', '_')).val(value);
                });
                $.each(array['Q1Percentage'].split('/'), function (index, value) {
                    $('#txtQ1Percentage_' + (arrayQ1Qualification[index]).replace('+', '_')).val(value);
                });
            }
            if (array['Q2Req'].toString().toLowerCase() == "true") {
                $('#cbQ2Req').trigger('click');
                $('#drpQ2Qualification').val((array['Q2Qualification'].toString().toLowerCase() == 'ug/pg' ? 'Either' : array['Q2Qualification']));
                $('#drpQ2Qualification').trigger('change');
                var arrayQ2Qualification = array['Q2Qualification'].split('/');
                $.each(array['Q2Subject'].split('/'), function (index, value) {
                    $('#txtQ2Subject_' + arrayQ2Qualification[index]).val(value);
                });
                $.each(array['Q2Percentage'].split('/'), function (index, value) {
                    $('#txtQ2Percentage_' + arrayQ2Qualification[index]).val(value);
                });
            }
            if (array['Q3Req'].toString().toLowerCase() == "true") {
                $('#cbQ3Req').trigger('click');
                $('#drpQ3Qualification').val((array['Q3Qualification'].toString().toLowerCase() == 'pg/mphil' ? 'Either' : array['Q3Qualification']));
                $('#drpQ3Qualification').trigger('change');
                var arrayQ3Qualification = array['Q3Qualification'].split('/');
                $.each(array['Q3Subject'].split('/'), function (index, value) {
                    $('#txtQ3Subject_' + arrayQ3Qualification[index]).val(value);
                });
                $.each(array['Q3Percentage'].split('/'), function (index, value) {
                    $('#txtQ3Percentage_' + arrayQ3Qualification[index]).val(value);
                });
            }
            $('Q2Req').val(array['Q2Req']);
            $('Q3Req').val(array['Q3Req']);
            $('Q1Qualification').val(array['Q1Qualification']);
            $('Q1Subject').val(array['Q1Subject']);
            $('Q1Percentage').val(array['Q1Percentage']);
            $('Q2Qualification').val(array['Q2Qualification']);
            $('Q2Subject').val(array['Q2Subject']);
            $('Q2Percentage').val(array['Q2Percentage']);
            $('Q3Qualification').val(array['Q3Qualification']);
            $('Q3Subject').val(array['Q3Subject']);
            $('Q3Percentage').val(array['Q3Percentage']);
            $('').val(array['JEEMainReq']);
            if (array['JEEMainReq'].toString().toLowerCase() == "true") {
                $('#rbtJEEMainReqYes').trigger('click');
                $('#tx_JEEMainscoreReq').val(array['JEEMainscoreReq']);
            }
            else {
                $('#rbtJEEMainReqNo').trigger('click');
            };
            if (array['JEEAdvanceReq'].toString().toLowerCase() == "true") {
                $('#rbtJEEAdvanceReqYes').trigger('click');
                $('#tx_JEEAdvanceScoreReq').val(array['JEEAdvanceScoreReq']);
            }
            else {
                $('#rbtJEEAdvanceReqNo').trigger('click');
            };
            if (array['IELTSReq'].toString().toLowerCase() == "true") {
                $('#rbtIELTSReqYes').trigger('click');
                $('#tx_IELTSscoreReq').val(array['IELTSscoreReq']);
            }
            else {
                $('#rbtIELTSReqNo').trigger('click');
            };
            if (array['GMATReq'].toString().toLowerCase() == "true") {
                $('#rbtGMATReqYes').trigger('click');
                $('#tx_GMATScoreReq').val(array['GMATScoreReq']);
            }
            else {
                $('#rbtGMATReqNo').trigger('click');
            };
            if (array['TOFELReq'].toString().toLowerCase() == "true") {
                $('#rbtTOFELReqYes').trigger('click');
                $('#tx_TOFELScoreReq').val(array['TOFELScoreReq']);
            }
            else {
                $('#rbtTOFELReqNo').trigger('click');
            };
            if (array['SATReq'].toString().toLowerCase() == "true") {
                $('#rbtSATReqYes').trigger('click');
                $('#tx_SATScoreReq').val(array['SATScoreReq']);
            }
            else {
                $('#rbtSATReqNo').trigger('click');
            };
            if (array['GATEReq'].toString().toLowerCase() == "true") {
                $('#rbtGATEReqYes').trigger('click');
                $('#tx_GATEScoreReq').val(array['GATEScoreReq']);
            }
            else {
                $('#rbtGATEReqNo').trigger('click');
            };
            if (array['IsGivenFromInstitute'].toString().toLowerCase() == 'true') {
                //$("#drpDiscipline").prop("disabled", true);
                //$("#drpProgramLevel").prop("disabled", true);
                //$("#drpNatureofcourse").prop("disabled", true);
                //$("#drpBranch").prop("disabled", true);
                //$('#txtfeeswaiverg1').attr('readonly', true);
                //$('#txtfeeswaiverg2').attr('readonly', true);
                //$('#txtfeeswaiverg3').attr('readonly', true);
                //$('#txtfeeswaiverg4').attr('readonly', true);
                $('#txttotalseats').attr('readonly', true);
                //$('#txtAnnualFees').attr('readonly', true);
                //$('#txttotalBoarding').attr('readonly', true);
                //$('#drpAnnualFeesCurrency').prop("disabled", true);
                //$('#drpAnnualBoardingFeesCurrency').prop("disabled", true);
                //$('#txtAdmission').attr('readonly', true);

                $('#hdfIsGivenFromInstitute').val('1');
            } else {
                $("#drpDiscipline").prop("disabled", false);
                $("#drpProgramLevel").prop("disabled", false);
                $("#drpNatureofcourse").prop("disabled", false);
                $("#drpBranch").prop("disabled", false);
                $('#txtfeeswaiverg1').attr('readonly', false);
                $('#txtfeeswaiverg2').attr('readonly', false);
                $('#txtfeeswaiverg3').attr('readonly', false);
                $('#txtfeeswaiverg4').attr('readonly', false);
                $('#txttotalseats').attr('readonly', false);
                $('#txtAnnualFees').attr('readonly', false);
                $('#txttotalBoarding').attr('readonly', false);
                $('#txtAdmission').attr('readonly', false);
                $('#drpAnnualFeesCurrency').prop("disabled", false);
                $('#drpAnnualBoardingFeesCurrency').prop("disabled", false);

                $('#hdfIsGivenFromInstitute').val('0');
            }
            $('#tbodyEC').find('tr.newtr').remove();
            $.each(data["ListEC"], function (index, item) {
                var tr = $('<tr class="newtr"></tr>');
                tr.append('<td data-id="' + item['EduQualifications_Id'] + '" data-for="' + item['EduQualificationsFor'] + '">' + item['EduQualifications'] + '</td>');

                var td = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
                var snArray = item['EduSubject'].split('|');
                var sArray = item['EduSubject_Id'].split('|');
                var pArray = item['PercentageID'].split('|');
                for (var i = 0; i < sArray.length; i++) {
                    var txtTr = '<tr>';
                    txtTr = txtTr + '<td data-id="' + sArray[i] + '">' + snArray[i] + '</td>';
                    txtTr = txtTr + '<td data-id="' + pArray[i] + '">' + pArray[i] + '</td>';
                    txtTr = txtTr + '</tr>';
                    td = td + txtTr;
                }
                td = td + '</tbody></table></td>';
                tr.append(td);
                //tr.append('<td data-id="' + item['EduSubject_Id'] + '">' + item['EduSubject'] + '</td>');
                //tr.append('<td data-id="' + item['PercentageID'] + '">' + item['PercentageID'] + '</td>');
                tr.append('<td class="tdECOperator" data-id="' + item['Operator'] + '">' + item['OperatorDisplay'] + '</td>');
                tr.append('<td><a class="btn btn-danger btnECDelete">X</a></td>');
                tr.insertBefore($('#defaultECTR'));
            });
            $('#tbodyAE').find('tr.newtr').remove();
            $.each(data["ListAE"], function (index, item) {
                var tr = $('<tr class="newtr"></tr>');
                tr.append('<td data-id="' + item['AditionalExams_Id'] + '" data-for="' + item['AditionalExamsFor'] + '">' + item['AditionalExams'] + '</td>');
                if (item['AditionalExams_Id'] == '10') {
                    tr.append('<td data-id="' + item['CriteriaDate'] + '">' + item['CriteriaDate'] + '</td>');
                } else {
                    tr.append('<td data-id="' + item['CutOff'] + '">' + (item['CutOff'] == '0' ? 'No Minimum Score' : item['CutOff']) + '</td>');
                }

                tr.append('<td data-id="' + item['Operator'] + '">' + item['Operator'] + '</td>');
                tr.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>');
                tr.insertBefore($('#defaultAETR'));
            });
            Check_EC();
            Check_AE();
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.");
        });
    });

    $('#tbodyCourse').on('click', '.btnDelete', function () {
        var btn = $(this);
        var ID = btn.attr('data-id')
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            type: "",
            closeOnConfirm: true,
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            confirmButtonClass: 'btn-warning',
            showLoaderOnConfirm: true,
        }).then(function () {
            $.ajax({
                method: 'POST',
                url: '/Institute/Courses/DeleteCourseOffers',
                data: { ID: ID },
                success: function (data) {
                }
            }).done(function (data) {
                Select_Course();
                swal("Success!", "Your data has been deleted.");
            }).error(function () {
                swal("Oops...!", "Something went wrong from our side.");
            });
        });
    });

    $('#cbQ0Req').on('click', function () {
        if ($(this).is(':checked')) {
            Q0Req = 1;
            $('#txtQ0Subject').prop('required', true);
            $('#txtQ0Subject').removeAttr('readonly');
            $('#txtQ0Percentage').prop('required', true);
            //$('#txtQ0Percentage').removeAttr('readonly');
            $('#txtQ0Percentage').removeAttr('disabled');
        } else {
            $('#txtQ0Subject').removeProp('required', true);
            $('#txtQ0Subject').attr('readonly', true);
            $('#txtQ0Subject').val('');
            $('#txtQ0Percentage').removeProp('required', true);
            //$('#txtQ0Percentage').attr('readonly', true);
            $('#txtQ0Percentage').attr('disabled', true);
            $('#txtQ0Percentage').val('');
        }
    });
    $('#cbQ1Req').on('click', function () {
        if ($(this).is(':checked')) {
            Q1Req = 1;
            $('#drpQ1Qualification').prop('required', true);
            $('#drpQ1Qualification').removeProp('disabled');
        } else {
            $('#drpQ1Qualification').removeProp('required', true);
            $('#drpQ1Qualification').prop('disabled', true);
            $('#drpQ1Qualification').val('');
            $('#drpQ1Qualification').trigger('change');
            $('.Q1_TXT').attr('readonly', true);
            $('.Q1_TXT').attr('readonly', true);
            $('.Q1_TXT').val('');

        }
    });
    $('#cbQ2Req').on('click', function () {
        if ($(this).is(':checked')) {
            Q2Req = 1;
            $('#drpQ2Qualification').prop('required', true);
            $('#drpQ2Qualification').removeProp('disabled');
        }
        else {
            $('#drpQ2Qualification').removeProp('required', true);
            $('#drpQ2Qualification').prop('disabled', true);
            $('#drpQ2Qualification').val('');
            $('#drpQ2Qualification').trigger('change');
            $('.Q2_TXT').attr('readonly', true);
            $('.Q2_TXT').attr('readonly', true);
            $('.Q2_TXT').val('');
        }
    });
    $('#cbQ3Req').on('click', function () {
        if ($(this).is(':checked')) {
            Q3Req = 1;
            $('#drpQ3Qualification').prop('required', true);
            $('#drpQ3Qualification').removeProp('disabled');
        }
        else {
            $('#drpQ3Qualification').removeProp('required', true);
            $('#drpQ3Qualification').prop('disabled', true);
            $('#drpQ3Qualification').val('');
            $('#drpQ3Qualification').trigger('change');
            $('.Q3_TXT').attr('readonly', true);
            $('.Q3_TXT').attr('readonly', true);
            $('.Q3_TXT').val('');
        }
    });

    $('#btnECAdd').on('click', function (e) {
        e.preventDefault();
        var flagECSubject = true;
        var flagECSubjectDuplicate = true;
        var arrayECSubject = [];
        $('.drpECSubject').each(function () {
            var drp = $(this);
            if (drp.val() == '') {
                flagECSubject = false;
            }
            if ($.inArray(drp.val(), arrayECSubject) != -1) {
                flagECSubjectDuplicate = false;
            } else {
                arrayECSubject.push(drp.val());
            }
        });
        if (!flagECSubjectDuplicate) {
            swal('warning', 'Same subject are selected.', 'warning');
            return false;
        }
        var flagECPercentageID = true;
        $('.drpECPercentageID').each(function () {
            var drp = $(this);
            if (drp.val() == '') {
                flagECPercentageID = false;
            }
        });
        if ($('.drpECQualification').val() == '') {
            swal('warning', 'Please select Qualification.', 'warning');
            return false;
        } else if (!flagECSubject) {
            swal('warning', 'Please select subject.', 'warning');
            return false;
        } else if (!flagECPercentageID) {
            swal('warning', 'Please select percentage.', 'warning');
            return false;
        } else if ($('.drpECOperator').val() == '') {
            swal('warning', 'Please select operator.', 'warning');
            return false;
        }
        var flagEC = true;
        var dataFor = '', dataForQ = '';
        $('#tbodyEC').find('tr.newtr').each(function () {
            var checkTR = $(this);
            var tbody = checkTR.find('td:eq(1)').find('tbody');
            var EduSubject_Id = '', EduSubject = '', PercentageID = '';
            tbody.find('tr').each(function (i, item) {
                var subTr = $(this);
                $('.drpECSubject').each(function () {
                    var drp = $(this);
                    if (drp.val() == subTr.find('td:eq(0)').attr('data-id')) {
                        flagEC = false;
                    }
                });
            });
            dataFor = checkTR.find('td:eq(0)').attr('data-for');
            dataForQ = checkTR.find('td:eq(0)').text();
        });
        if (dataFor == '') {
            dataFor = 'Q-1';
        }
        if (!(parseInt(dataFor.replace('Q', '')) <= parseInt($('.drpECQualification').find('option:selected').attr('data-for').replace('Q', '')))) {
            swal('warning', 'Please add qualification in sequence.', 'warning');
            return false;
        } else {
            if ($('.drpECQualification').find('option:selected').attr('data-for') == 'Q0') {
                if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == '10th') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == '10th') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualification').find('option:selected').attr('data-for') == 'Q1') {
                if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == '10+2' && $('.drpECQualification').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '10+2' && $('.drpECQualification').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualification').find('option:selected').text() == 'Diploma') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualification').find('option:selected').attr('data-for') == 'Q2') {
                if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else if (dataForQ == '10+2' && $('.drpECQualification').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '10+2' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualification').find('option:selected').text() == 'UG') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'UG' && $('.drpECQualification').find('option:selected').text() == 'UG') {

                } else if (dataForQ == 'UG' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'PG' && $('.drpECQualification').find('option:selected').text() == 'PG') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualification').find('option:selected').attr('data-for') == 'Q3') {
                if (dataForQ == '' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == '10th' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == '10+2' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'UG' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'PG' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'M.Phil.' && $('.drpECQualification').find('option:selected').text() == 'M.Phil.') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            }
        }
        if (!flagEC) {
            swal('warning', 'Already selected same qualification and subject.', 'warning');
            return false;
        }
        var btn = $(this);

        var selectedText = $('.drpECOperator').find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            var tr = $('<tr class="newtr AndWithOr"></tr>');
            tr.append('<td data-id="' + $('.drpECQualification').val() + '" data-for="' + $('.drpECQualification').find('option:selected').attr('data-for') + '">' + $('.drpECQualification').find('option:selected').text() + '</td>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $('#tbodySubjectPercentage').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECSubject').val() + '">' + currentTr.find('.drpECSubject').find('option:selected').text() + '</td>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECPercentageID').val() + '">' + currentTr.find('.drpECPercentageID').find('option:selected').text() + '</td>';
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.append('<td class="tdECOperator" data-id="' + $('.drpECOperator').val() + '">' + $('.drpECOperator').find('option:selected').text() + '</td>');
            tr.append('<td><a class="btn btn-danger btnECDelete">X</a></td>');
            tr.insertBefore(btn.parent().parent());
        } else {
            var tr = $('<tr class="newtr "></tr>');
            tr.append('<td data-id="' + $('.drpECQualification').val() + '" data-for="' + $('.drpECQualification').find('option:selected').attr('data-for') + '">' + $('.drpECQualification').find('option:selected').text() + '</td>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $('#tbodySubjectPercentage').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECSubject').val() + '">' + currentTr.find('.drpECSubject').find('option:selected').text() + '</td>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECPercentageID').val() + '">' + currentTr.find('.drpECPercentageID').find('option:selected').text() + '</td>';
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.append('<td class="tdECOperator" data-id="' + $('.drpECOperator').val() + '">' + $('.drpECOperator').find('option:selected').text() + '</td>');
            tr.append('<td><a class="btn btn-danger btnECDelete">X</a></td>');
            tr.insertBefore(btn.parent().parent());
        }
        $('.drpECQualification').val('').trigger('change');
        $('.drpECSubject').val('').trigger('change');
        $('.drpECPercentageID').val('').trigger('change');
        $('.drpECOperator').val('').trigger('change');
        Check_EC();
    });
    $('#tbodyEC').on('click', '.btnECDelete', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_EC();
    });
    $('#tbodyEC').on('click', '#btnAddMoreCondition', function (e) {
        e.preventDefault();
        var newTr = $('.currentSPTr').clone();
        newTr.find('td:last-child').html('<a class="btn btn-sm btn-danger btnSPDelete">X</a>');
        $('#tbodySubjectPercentage').append('<tr class="newSPTr">' + newTr.html() + '</tr>');
    });
    $('#tbodyEC').on('click', '.btnSPDelete', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_EC();
    });

    $('#btnAEAdd').on('click', function (e) {
        e.preventDefault();
        if ($('.drpAEAditionalExam').val() == '') {
            swal('warning', 'Please select exam name.', 'warning');
            return false;
        } else if ($('.txtAECutOff').val() == '') {
            swal('warning', 'Please select cut-off.', 'warning');
            return false;
        } else if ($('.drpAEOperator').val() == '') {
            swal('warning', 'Please select operator.', 'warning');
            return false;
        }

        var flagAE = true;
        $('#tbodyAE').find('tr.newtr').each(function () {
            var checkTR = $(this);
            if (checkTR.find('td:eq(0)').attr('data-id') == $('.drpAEAditionalExam').val()) {
                flagAE = false;
            }
        });
        if (!flagAE) {
            swal('warning', 'Already selected same exam / criteria.', 'warning');
            return false;
        }
        var btn = $(this);
        var tr = $('<tr class="newtr"></tr>');
        tr.append('<td data-id="' + $('.drpAEAditionalExam').val() + '" data-for="' + $('.drpAEAditionalExam').find('option:selected').attr('data-aefor') + '">' + $('.drpAEAditionalExam').find('option:selected').text() + '</td>');
        if ($('.drpAEAditionalExam').val() == '10') {
            tr.append('<td data-id="' + $('.txtAECutOff').val() + '">' + $('.txtAECutOff').val() + '</td>');
        } else {
            tr.append('<td data-id="' + $('.txtAECutOff').val() + '">' + $('.txtAECutOff').find('option:selected').text() + '</td>');
        }

        tr.append('<td data-id="' + $('.drpAEOperator').val() + '">' + $('.drpAEOperator').find('option:selected').text() + '</td>');
        tr.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>');
        tr.insertBefore(btn.parent().parent());
        $('.drpAEAditionalExam').val('').trigger('change');
        $('.txtAECutOff').val('');
        $('.drpAEOperator').val('').trigger('change');
        Check_AE();
    });
    $('#tbodyAE').on('click', '.btnAEDelete', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_AE();
    });

    $(document).on('click', '.btnECAddMore', function (e) {
        e.preventDefault();
        $('#tbodyECNew').find('.defaultECTR_2:last-child').show();
        var newTr = $('#tbodyECNew').find('#defaultECTR').clone();
        newTr.find('td.lastTDAction').append('<a class="btn btn-sm btn-danger btnSPDelete">X</a>');
        //$('#tbodySubjectPercentage').append('<tr class="newSPTr">' + newTr.html() + '</tr>');
        
        $('#tbodyECNew').append('<tr>' + newTr.html() + '</tr>');
        $('#tbodyECNew').append('<tr class="defaultECTR_2" style="display:none;"><td colspan="3"><div class="col-md-3 col-md-offset-4"><select class="form-control drpECOperator"><option value="">--Select--</option><option value="And">And</option><option value="Or">Or</option><option value="And">Multiple OR</option></select></div></td></tr>');

    });

}

function Clear() {
    $('#frmCoursesOffer').trigger("reset");
    $('#divhideshow').show();
    $('#hdfID').val(0);
    $('#drpBranch').trigger('change')
    $("#drpDiscipline").prop("disabled", false);
    $("#drpProgramLevel").prop("disabled", false);
    $("#drpNatureofcourse").prop("disabled", false);
    $("#drpBranch").prop("disabled", false);
    $('#txtfeeswaiverg1').attr('readonly', false);
    $('#txtfeeswaiverg2').attr('readonly', false);
    $('#txtfeeswaiverg3').attr('readonly', false);
    $('#txtfeeswaiverg4').attr('readonly', false);
    $('#txttotalseats').attr('readonly', false);
    $('#txtAnnualFees').attr('readonly', false);
    $('#txttotalBoarding').attr('readonly', false);
    $('#txtAdmission').attr('readonly', false);
    $('#hdfIsGivenFromInstitute').val('0');
    $('#tbodyEC').find('tr.newtr').remove();
    $('#tbodyAE').find('tr.newtr').remove();
    $('#tdECCondition').text('');
    $('#tbodySubjectPercentage').find('tr.newSPTr').remove();
}

function Select_Course() {
    $('#tbodyCourse').html('');
    $.ajax({
        method: 'GET',
        async: false,
        url: '/Institute/Courses/SelectCourseOffers',
        success: function (data) {
        }
    }).done(function (data) {
        var i = 1;
        $.each(data["List"], function (index, item) {
            var tr = $('<tr></tr>');
            tr.append('<td>' + (i++) + '</td>');
            tr.append('<td>' + item['ProgramLevel'] + '</td>');
            tr.append('<td>' + item['Natureofcourse'] + '</td>');
            tr.append('<td>' + item['BranchName'] + '</td>');
            tr.append('<td>' + item['SeatForForeignStudent'] + '</td>');
            editbtn = '<button class="btn btn-success btnGridEdit" title="Edit" data-toggle="tooltip" type="button" data-id="' + item['ID'] + '" ><i class="glyphicon glyphicon-pencil"></i></button>';
            if (item['IsGivenFromInstitute'].toString().toLowerCase() == 'true') {
                deletebtn = '';
            }
            else {
                deletebtn = '<a class="btn btn-danger btnDelete" title="Delete" data-toggle="tooltip" data-id="' + item['ID'] + '"><i class="glyphicon glyphicon-trash"></i></a>';
            }
            tr.append('<td>' + editbtn + '&nbsp;&nbsp;' + deletebtn + '</td>');
            $('#tbodyCourse').append(tr);
        });
    }).error(function () {
        swal("Oops...!", "Something went wrong! Please try again.");
    });
}

function fillPercentage() {
    for (var i = 99; i >= 35; i--) {
        $('.drpPercentage').append('<option>' + i + '</option>');
    }
}

function ConvertDateToSQLDate(value) {
    var cDate = value;
    var newdate = '';
    var newarray = new Array();
    if (cDate != '') {
        newdate = cDate.split("-").reverse().join("-");
    }
    return newdate;
}

function GET_EC() {
    var _listEC = [];
    $('#tbodyEC').find('tr.newtr').each(function () {
        var tr = $(this);
        var EduSubject_Id = '', PercentageID = '', EduQualifications_Id = '', Operator = '', OperatorDisplay = '';
        EduQualifications_Id = tr.find('td:eq(0)').attr('data-id');
        Operator = tr.find('td.tdECOperator').attr('data-id');
        OperatorDisplay = tr.find('td.tdECOperator').text();
        var tbody = tr.find('td:eq(1)').find('tbody')
        tbody.find('tr').each(function (i, item) {
            var subTr = $(this);
            if (i == 0) {
                EduSubject_Id = subTr.find('td:eq(0)').attr('data-id');
                PercentageID = subTr.find('td:eq(1)').attr('data-id');
            } else {
                EduSubject_Id = EduSubject_Id + '|' + subTr.find('td:eq(0)').attr('data-id');
                PercentageID = PercentageID + '|' + subTr.find('td:eq(1)').attr('data-id');
            }
        });
        _listEC.push({
            'EduQualifications_Id': EduQualifications_Id,
            'EduSubject_Id': EduSubject_Id,
            'PercentageID': PercentageID,
            'Operator': Operator,
            'OperatorDisplay': OperatorDisplay
        });
        //_listEC.push({
        //    'EduQualifications_Id': tr.find('.drpECQualification').val(),
        //    'EduSubject_Id': tr.find('.drpECSubject').val(),
        //    'PercentageID': tr.find('.drpECPercentageID').val(),
        //    'Operator': tr.find('.drpECOperator').val()
        //});
    });
    return JSON.stringify(_listEC);
}

function GET_AE() {
    var _listAE = [];
    $('#tbodyAE').find('tr.newtr').each(function () {
        var tr = $(this);
        _listAE.push({
            'AditionalExams_Id': tr.find('td:eq(0)').attr('data-id'),
            'CutOff': (tr.find('td:eq(0)').attr('data-id') != '10' ? tr.find('td:eq(1)').attr('data-id') : '0'),
            'CriteriaDate': (tr.find('td:eq(0)').attr('data-id') == '10' ? ConvertDateToSQLDate(tr.find('td:eq(1)').attr('data-id')) : ''),
            'Operator': tr.find('td:eq(2)').attr('data-id')
        });
    });
    return JSON.stringify(_listAE);
}

function Check_EC() {
    var _Q0 = [];
    var _Q1 = [];
    var _Q2 = [];
    var _Q3 = [];
    $('#tbodyEC').find('tr.newtr').each(function () {
        var tr = $(this);
        var ECFor = tr.find('td:eq(0)').attr('data-for');
        var tbody = tr.find('td:eq(1)').find('tbody');
        var EduSubject_Id = '', EduSubject = '', PercentageID = '';
        tbody.find('tr').each(function (i, item) {
            var subTr = $(this);
            if (i == 0) {
                EduSubject_Id = subTr.find('td:eq(0)').attr('data-id');
                EduSubject = subTr.find('td:eq(0)').text();
                PercentageID = subTr.find('td:eq(1)').attr('data-id');
            } else {
                EduSubject_Id = EduSubject_Id + '|' + subTr.find('td:eq(0)').attr('data-id');
                EduSubject = EduSubject + '|' + subTr.find('td:eq(0)').text();
                PercentageID = PercentageID + '|' + subTr.find('td:eq(1)').attr('data-id');
            }
        });
        if (ECFor == 'Q0') {
            _Q0.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperator').attr('data-id'),
                'od': tr.find('td.tdECOperator').text()
            });
        } else if (ECFor == 'Q1') {
            _Q1.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperator').attr('data-id'),
                'od': tr.find('td.tdECOperator').text()
            });
        } else if (ECFor == 'Q2') {
            _Q2.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperator').attr('data-id'),
                'od': tr.find('td.tdECOperator').text()
            });
        } else if (ECFor == 'Q3') {
            _Q3.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperator').attr('data-id'),
                'od': tr.find('td.tdECOperator').text()
            });
        }
    });
    var strQ0 = '';
    var strQ1 = '';
    var strQ2 = '';
    var strQ3 = '';
    if (_Q0.length > 0) {
        strQ0 = '( ';
        $.each(_Q0, function (i, item) {
            if ((i + 1) == _Q0.length) {
                strQ0 = strQ0 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            } else {
                strQ0 = strQ0 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
        });
        strQ0 = strQ0 + ' )';
    }

    if (_Q1.length > 0) {
        strQ1 = '( ';
        var _q11 = [];
        var _q12 = [];
        var strQ11 = '', strQ12 = '';
        var lastO = '';
        $.each(_Q1, function (i, item) {
            if (item['q'] == '10+2') {
                _q11.push({
                    'q': item['q'],
                    's': item['s'],
                    'sn': item['sn'],
                    'p': item['p'],
                    'o': item['o'],
                    'od': item['od']
                });
            } else {
                _q12.push({
                    'q': item['q'],
                    's': item['s'],
                    'sn': item['sn'],
                    'p': item['p'],
                    'o': item['o'],
                    'od': item['od']
                });
            }
        });
        $.each(_q11, function (i, item) {
            if ((i + 1) == _q11.length) {
                strQ11 = strQ11 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            } else {
                strQ11 = strQ11 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
            lastO = item['o'];
        });
        $.each(_q12, function (i, item) {
            if ((i + 1) == _q12.length) {
                strQ12 = strQ12 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            } else {
                strQ12 = strQ12 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
        });
        strQ1 = strQ1 + strQ11 + (_q11.length > 0 && _q12.length > 0 ? ' ' + lastO + ' ' : '') + strQ12;
        strQ1 = strQ1 + ' )';
    }

    if (_Q2.length > 0) {
        strQ2 = '( ';
        var _q21 = [];
        var _q22 = [];
        var strQ21 = '', strQ22 = '', lastQ2o = '';
        var lastO = '';
        $.each(_Q2, function (i, item) {
            if (item['q'] == 'UG') {
                _q21.push({
                    'q': item['q'],
                    's': item['s'],
                    'sn': item['sn'],
                    'p': item['p'],
                    'o': item['o'],
                    'od': item['od']
                });
            } else {
                _q22.push({
                    'q': item['q'],
                    's': item['s'],
                    'sn': item['sn'],
                    'p': item['p'],
                    'o': item['o'],
                    'od': item['od']
                });
            }
        });
        $.each(_q21, function (i, item) {
            if ((i + 1) == _q21.length) {
                strQ21 = strQ21 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
                lastQ2o = item['o'];
            } else {
                strQ21 = strQ21 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
            lastO = item['o'];
        });
        $.each(_q22, function (i, item) {
            if ((i + 1) == _q22.length) {
                strQ22 = strQ22 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            } else {
                strQ22 = strQ22 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
        });
        strQ2 = strQ2 + strQ21 + (_q21.length > 0 && _q22.length > 0 ? ' ' + lastO + ' ' : '') + strQ22;
        strQ2 = strQ2 + ' )';
    }

    if (_Q3.length > 0) {
        strQ3 = '( ';
        $.each(_Q3, function (i, item) {
            if ((i + 1) == _Q3.length) {
                strQ3 = strQ3 + ' ' + fill_text(true, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            } else {
                strQ3 = strQ3 + ' ' + fill_text(false, item['q'], item['s'], item['sn'], item['p'], item['o'], item['od']);
            }
        });
        strQ3 = strQ3 + ' )';
    }
    var strFinal = '';
    if (strQ0.length > 0) {
        strFinal = strFinal + strQ0;
    }
    if (strQ1.length > 0) {
        strFinal = strFinal + (strQ0.length > 0 ? ' And ' : '') + strQ1;
    }
    if (strQ2.length > 0) {
        strFinal = strFinal + (strQ1.length > 0 ? ' And ' : '') + strQ2;
    }
    if (strQ3.length > 0) {
        strFinal = strFinal + (strQ2.length > 0 ? ' And ' : '') + strQ3;
    }

    $('#tdECCondition').text(strFinal);
}

function Check_AE() {
    var _E1 = [];
    var _E2 = [];
    var _E3 = [];
    $('#tbodyAE').find('tr.newtr').each(function () {
        var tr = $(this);
        var AEFor = tr.find('td:eq(0)').attr('data-for');
        var tbody = tr.find('td:eq(1)').find('tbody');
        if (AEFor == 'E1') {
            _E1.push({
                'e': tr.find('td:eq(0)').text(),
                'c': tr.find('td:eq(1)').text(),
                'o': tr.find('td:eq(2)').text(),
            });
        } else if (AEFor == 'E2') {
            _E2.push({
                'e': tr.find('td:eq(0)').text(),
                'c': tr.find('td:eq(1)').text(),
                'o': tr.find('td:eq(2)').text(),
            });
        }
    });
    var strE1 = '';
    var strE2 = '';
    var strE3 = '';
    if (_E1.length > 0) {
        strE1 = '( ';
        $.each(_E1, function (i, item) {
            if ((i + 1) == _E1.length) {
                strE1 = strE1 + ' ' + fill_text_ae(true, item['e'], item['c'], item['o']);
            } else {
                strE1 = strE1 + ' ' + fill_text_ae(false, item['e'], item['c'], item['o']);
            }
        });
        strE1 = strE1 + ' )';
    }
    if (_E2.length > 0) {
        strE2 = '( ';
        $.each(_E2, function (i, item) {
            if ((i + 1) == _E2.length) {
                strE2 = strE2 + ' ' + fill_text_ae(true, item['e'], item['c'], item['o']);
            } else {
                strE2 = strE2 + ' ' + fill_text_ae(false, item['e'], item['c'], item['o']);
            }
        });
        strE2 = strE2 + ' )';
    }

    var strFinal = '';
    if (strE1.length > 0) {
        strFinal = strFinal + strE1;
    }
    if (strE2.length > 0) {
        strFinal = strFinal + (strE1.length > 0 ? ' And ' : '') + strE2;
    }

    $('#tdAECondition').text(strFinal);
}

function fill_text(isLast, q, s, sn, p, o, od) {
    var str = '';
    if (od == 'Multiple OR') {
        str = str + '( ';
        var snArray = sn.split('|');
        var sArray = s.split('|');
        var pArray = p.split('|');
        for (var i = 0; i < sArray.length; i++) {
            if (i < sArray.length - 1) {
                str = str + q + ' in ' + snArray[i] + ' with ' + pArray[i] + '% OR ';
            } else {
                str = str + q + ' in ' + snArray[i] + ' with ' + pArray[i] + '%';
            }
        }
        if (isLast) {
            str = str + ' ) ';
        } else {
            str = str + ' ) ' + o + '';
        }
    } else {
        if (isLast) {
            str = q + ' in ' + sn + ' with ' + p + '%';
        } else {
            str = q + ' in ' + sn + ' with ' + p + '% ' + o + '';
        }
    }
    return str;
}

function fill_text_ae(isLast, e, c, o) {
    var str = '';
    if (e == 'Age Limit Date') {
        if (isLast) {
            str = ' Date of Birth must be after ' + c;
        } else {
            str = ' Date of Birth must be after ' + c + ' ' + o + '';
        }
    } else {
        if (isLast) {
            str = e + ' with ' + c + ' score ';
        } else {
            str = e + ' with ' + c + ' score ' + o + '';
        }
    }
    return str;
}

function SortECOperator(x, y) {
    return ((x.o == y.o) ? 0 : ((x.o > y.o) ? 1 : -1));
}