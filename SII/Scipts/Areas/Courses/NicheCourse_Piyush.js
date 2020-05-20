$(document).ready(function () {
    page_Click_niche(),
        page_load_niche(),
        page_change_niche(),
        FillConditionalDropdown_niche()
});

function FillConditionalDropdown_niche() {
    $("#drpDisciplineNiche").on("change", function (t) {
            $("#drpNatureofcourseNiche").html(""),
            $("#drpBranchNiche").html(""),
            $("#drpBranchNiche").append('<option value="">-Select-</option>'),
            $("#drpNatureofcourseNiche").append('<option value="">--Select--</option>');
            $("#drpProgramLevelNiche").html(""),
            $("#drpProgramLevelNiche").append('<option value="">--Select--</option>');
        var e = $(this).val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectPLNiche",
            data: {
                Discipline_ID: e
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpProgramLevelNiche").append('<option value="' + e.ProgramLevel_Id + '">' + e.ProgramLevel + "</option>")
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    }),
        $("#drpProgramLevelNiche").on("change", function (t) {
                $("#drpNatureofcourseNiche").html(""),
                $("#drpBranchNiche").html(""),
                $("#drpBranchNiche").append('<option value="">-Select-</option>'),
                $("#drpNatureofcourseNiche").append('<option value="">--Select--</option>');
            var e = $(this).val();
            "" == $("#drpDisciplineNiche").val() || $("#drpDisciplineNiche").val();
            $.ajax({
                method: "POST",
                async: !1,
                url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectQNiche",
                data: {
                    Discipline_ID: $("#drpDisciplineNiche").val(),
                    ProgramLevel_Id: e
                }
            }).done(function (t) {
                $.each(t.List, function (t, e) {
                    $("#drpNatureofcourseNiche").append('<option value="' + e.Qualification_ID + '">' + e.Qualification + "</option>")
                })
            }).error(function () {
                swal("error", "Somthing went wrong. Please try again.", "error")
            })
        }),
        $("#drpNatureofcourseNiche").on("change", function () {
            $(this).val();
            $.ajax({
                method: "POST",
                url: "/Institute/Courses/SelectCSNiche",
                async: !1,
                data: {
                    Discipline_ID: $("#drpDisciplineNiche").val(),
                    ProgramLevel_Id: $("#drpProgramLevelNiche").val(),
                    Qualification_ID: $("#drpNatureofcourseNiche").val()
                }
            }).done(function (t) {
                $("#drpBranchNiche").html(""), $("#drpBranchNiche").prepend('<option value="">--Select--</option>'), $.each(t.List, function (t, e) {
                    $("#drpBranchNiche").append('<option value="' + e.CourseOfStudy_ID + '">' + e.CourseOfStudy + "</option>")
                })
            }).error(function () {
                $("#drpBranchNiche").html(""), $("#drpBranchNiche").append('<option value="">-Select-</option>')
            })
        }),
        $("#tbodyECNiche").on("change", ".drpECQualificationNiche", function () {
            var t = $(this).val(),
                e = $(this).parent().parent().find(".drpECSubjectNiche");
            e.html(""), e.append('<option value="">-Select-</option>'), $.ajax({
                method: "POST",
                url: "/Institute/Courses/SelectECS",
                async: !1,
                data: {
                    id: t
                }
            }).done(function (t) {
                $.each(t.List, function (t, a) {
                    e.append('<option value="' + a.EduSubject_Id + '">' + a.EduSubject + "</option>")
                })
            }).error(function () { })
        })
}
function page_load_niche() {
    var newCurDOB = new Date(1960, 01, 01, 00, 00, 00, 00);
    var newCurYear = new Date().getFullYear();
    $("#txtStartDate").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: '1960:' + newCurYear,
        todayHighlight: true,
        changeMonth: true,
        changeYear: true,
        minDate: newCurDOB,
        //maxDate: addDays(new Date(), 0),
        onSelect: function (selected) {
            var splitDate = selected.split("-");
            var newCurDate = new Date(splitDate[2], splitDate[1] - 1, splitDate[0]);
            //$("#txtEndDate").datepicker("option", "minDate", addDays(newCurDate, 1));
            $("#txtEndDate").datepicker("option", "minDate", newCurDate);
            if ($("#txtEndDate").val() != '') {
                var splitEndDate1 = $('#txtEndDate').val().split("-");
                var EndDate1 = new Date(splitEndDate1[2], splitEndDate1[1] - 1, splitEndDate1[0]);
                $('#txtnicheduration').val(CalculateDuration(newCurDate, EndDate1));
            }
        }
    });
    $("#txtEndDate").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: '1966:' + newCurYear,
        todayHighlight: true,
        changeMonth: true,
        changeYear: true,
        //maxDate: addDays(new Date(), 0),
        onSelect: function (selected) {
            if ($("#txtStartDate").val() == '') {
                swal('warning', 'Please select program start date.', 'warning');
                $("#txtEndDate").val('');
                $("#txtStartDate").focus();
            } else {
                var splitDate = selected.split("-");
                var newCurDate = new Date(splitDate[2], splitDate[1] - 1, splitDate[0]);
                //$("#txtStartDate").datepicker("option", "maxDate", subDays(newCurDate, 1));
                $("#txtStartDate").datepicker("option", "maxDate", newCurDate);
                if ($("#txtStartDate").val() != '') {
                    var splitStartDate1 = $('#txtStartDate').val().split("-");
                    var StartDate1 = new Date(splitStartDate1[2], splitStartDate1[1] - 1, splitStartDate1[0]);
                    $('#txtnicheduration').val(CalculateDuration(StartDate1, newCurDate));
                }
            }
        }
    });
}

function page_Click_niche() {
    $("#btnNewNicheCourse").on("click", function (e) {
        e.preventDefault();
        $("#frmNicheCourses").trigger("reset"),
            $("#divhideshowNicheCourses").show(),
            $("#hdfNIcheID").val(0), ClearBridge()
    });
    $('#chkaccommodation').on("click", function () {
        $(this).is(":checked") ? ($('#Additionalaccommodation').show()) : ($('#Additionalaccommodation').hide(), $('#chkSharedroom').removeAttr("checked"), $('#chkIndependentroom').removeAttr("checked"))
    });
    $('#chktobedecided').on("click", function () {
        $(this).is(":checked") ? ($('.datepicker').val('').attr('disabled', true).css('background', '#808080'), $('#txtnicheduration').val('')) : ($('.datepicker').attr('readonly', true).attr('disabled', false).css('background', '#FFF'))
    });
    $('#drpCoursetype').on("change", function (e) {
        e.preventDefault();
        var t = "Total Fees", a = "Tuition Fees per seat", b = "Total Fees per seat", c = " Tuition Fees (SAARC Country)", d = "Tuition Fees (NonSAARC Country)";
        $(this).val() == '1' ? ($('#txtLabelfee').text('Annual ' + t), $('#F1').text('Annual ' + a), $('#F2').text('Annual ' + b), $('#F3').text('Annual ' + c), $('#F4').text('Annual ' + d)) : ($('#txtLabelfee').text(t), $('#F1').text(a), $('#F2').text(b), $('#F3').text(c), $('#F4').text(d)),
            $(this).val() == '2' ? ($('#divdateshrt').show()) : ($('#divdateshrt').hide())
    });
    $('#drpAnnualFeesCurrency1').on("change", function () {
        var t = $(this).val();
        t == "" ? $(".txt-fee-currency1").val("--Select--") : $(".txt-fee-currency1").val(t)
    });
    $("#btnECAddNiche").on("click", function (t) {
        t.preventDefault();
        var flagECSubject = true;
        var flagECSubjectDuplicate = true;
        var arrayECSubject = [];
        $('.drpECSubjectNiche').each(function () {
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
        $('.drpECPercentageIDNiche').each(function () {
            var drp = $(this);
            if (drp.val() == '') {
                flagECPercentageID = false;
            }
        });
        if ($('.drpECQualificationNiche').val() == '') {
            swal('warning', 'Please select Qualification.', 'warning');
            return false;
        } else if (!flagECSubject) {
            swal('warning', 'Please select subject.', 'warning');
            return false;
        } else if (!flagECPercentageID) {
            swal('warning', 'Please select percentage.', 'warning');
            return false;
        } else if ($('.drpECOperatorNiche').val() == '') {
            swal('warning', 'Please select operator.', 'warning');
            return false;
        }
        var flagEC = true;
        var dataFor = '', dataForQ = '';
        $('#tbodyECNiche').find('tr.newtr').each(function () {
            var checkTR = $(this);
            var tbody = checkTR.find('td:eq(1)').find('tbody');
            var EduSubject_Id = '', EduSubject = '', PercentageID = '';
            tbody.find('tr').each(function (i, item) {
                var subTr = $(this);
                $('.drpECSubjectNiche').each(function () {
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
        if (!(parseInt(dataFor.replace('Q', '')) <= parseInt($('.drpECQualificationNiche').find('option:selected').attr('data-for').replace('Q', '')))) {
            swal('warning', 'Please add qualification in sequence.', 'warning');
            return false;
        } else {
            if ($('.drpECQualificationNiche').find('option:selected').attr('data-for') == 'Q0') {
                if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == '10th') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == '10th') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualificationNiche').find('option:selected').attr('data-for') == 'Q1') {
                if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == '10+2' && $('.drpECQualificationNiche').find('option:selected').text() == '10+2') {

                } else if (dataForQ == '10+2' && $('.drpECQualificationNiche').find('option:selected').text() == 'Diploma') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualificationNiche').find('option:selected').text() == 'Diploma') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualificationNiche').find('option:selected').attr('data-for') == 'Q2') {
                if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else if (dataForQ == '10+2' && $('.drpECQualificationNiche').find('option:selected').text() == 'UG') {

                } else if (dataForQ == '10+2' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualificationNiche').find('option:selected').text() == 'UG') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'UG' && $('.drpECQualificationNiche').find('option:selected').text() == 'UG') {

                } else if (dataForQ == 'UG' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else if (dataForQ == 'PG' && $('.drpECQualificationNiche').find('option:selected').text() == 'PG') {

                } else {
                    swal('warning', 'Please add qualification in sequence.', 'warning');
                    return false;
                }
            } else if ($('.drpECQualificationNiche').find('option:selected').attr('data-for') == 'Q3') {
                if (dataForQ == '' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == '10th' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == '10+2' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'Diploma' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'UG' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'PG' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

                } else if (dataForQ == 'M.Phil.' && $('.drpECQualificationNiche').find('option:selected').text() == 'M.Phil.') {

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

        var selectedText = $('.drpECOperatorNiche').find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            var tr = $('<tr class="newtr AndWithOr"></tr>');
            tr.append('<td data-id="' + $('.drpECQualificationNiche').val() + '" data-for="' + $('.drpECQualificationNiche').find('option:selected').attr('data-for') + '">' + $('.drpECQualificationNiche').find('option:selected').text() + '</td>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $('#tbodySubjectPercentageNiche').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECSubjectNiche').val() + '">' + currentTr.find('.drpECSubjectNiche').find('option:selected').text() + '</td>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECPercentageIDNiche').val() + '">' + currentTr.find('.drpECPercentageIDNiche').find('option:selected').text() + '</td>';
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.append('<td class="tdECOperatorNiche" data-id="' + $('.drpECOperatorNiche').val() + '">' + $('.drpECOperatorNiche').find('option:selected').text() + '</td>');
            tr.append('<td><a class="btn btn-danger btnECDeleteNiche">X</a></td>');
            tr.insertBefore(btn.parent().parent());
        } else {
            var tr = $('<tr class="newtr "></tr>');
            tr.append('<td data-id="' + $('.drpECQualificationNiche').val() + '" data-for="' + $('.drpECQualificationNiche').find('option:selected').attr('data-for') + '">' + $('.drpECQualificationNiche').find('option:selected').text() + '</td>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $('#tbodySubjectPercentageNiche').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECSubjectNiche').val() + '">' + currentTr.find('.drpECSubjectNiche').find('option:selected').text() + '</td>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpECPercentageIDNiche').val() + '">' + currentTr.find('.drpECPercentageIDNiche').find('option:selected').text() + '</td>';
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.append('<td class="tdECOperatorNiche" data-id="' + $('.drpECOperatorNiche').val() + '">' + $('.drpECOperatorNiche').find('option:selected').text() + '</td>');
            tr.append('<td><a class="btn btn-danger btnECDeleteNiche">X</a></td>');
            tr.insertBefore(btn.parent().parent());
        }
        $('.drpECQualificationNiche').val('').trigger('change');
        $('.drpECSubjectNiche').val('').trigger('change');
        $('.drpECPercentageIDNiche').val('').trigger('change');
        $('.drpECOperatorNiche').val('').trigger('change');
        Check_EC_Niche();
    });
    $('#tbodyECNiche').on('click', '.btnECDeleteNiche', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_EC_Niche();
    });
    $('#tbodyECNiche').on('click', '#btnAddMoreConditionNiche', function (e) {
        e.preventDefault();
        var newTr = $('.currentSPTrNiche').clone();
        newTr.find('td:last-child').html('<a class="btn btn-sm btn-danger btnSPDeleteNiche">X</a>');
        $('#tbodySubjectPercentageNiche').append('<tr class="newSPTrNiche">' + newTr.html() + '</tr>');
    });
    $('#tbodyECNiche').on('click', '.btnSPDeleteNiche', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_EC_Niche();
    });
    $('#btnAEAddNiche').on('click', function (e) {
        e.preventDefault();
        var flagAESubject = true;
        var flagAESubjectDuplicate = true;
        var arrayAESubject = [];
        $('.drpAEAditionalExamNiche').each(function () {
            var drp = $(this);
            if (drp.val() == '') {
                flagAESubject = false;
            }
            if ($.inArray(drp.val(), arrayAESubject) != -1) {
                flagAESubjectDuplicate = false;
            } else {
                arrayAESubject.push(drp.val());
            }
        });
        if (!flagAESubjectDuplicate) {
            swal('warning', 'Same Exam are selected.', 'warning');
            return false;
        }
        var flagAEPercentageID = true;
        $('.txtAECutOffNiche').each(function () {
            var drp = $(this);
            if (drp.val() == '') {
                flagAEPercentageID = false;
            }
        });
        if (!flagAESubject) {
            swal('warning', 'Please select exam.', 'warning');
            return false;
        } else if (!flagAEPercentageID) {
            swal('warning', 'Please select Score.', 'warning');
            return false;
        } else if ($('.drpAEOperatorNiche').val() == '') {
            swal('warning', 'Please select operator.', 'warning');
            return false;
        }
        var flagAE = true;
        $('#tbodyAENiche').find('tr.newtr').each(function () {
            var checkTR = $(this);
            if (checkTR.find('td:eq(0)').attr('data-id') == $('.drpAEAditionalExamNiche').val()) {
                flagAE = false;
            }
        });
        if (!flagAE) {
            swal('warning', 'Already selected same exam / criteria.', 'warning');
            return false;
        }
        var btn = $(this);
        var selectedText = $('.drpAEOperatorNiche').find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            var tr = $('<tr class="newtr AndWithOr"></tr>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>';
            $('#tbodyAEScoreNiche').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpAEAditionalExamNiche').val() + '">' + currentTr.find('.drpAEAditionalExamNiche').find('option:selected').text() + '</td>';
                if ($('.drpAEAditionalExamNiche').val() == '10') {
                    txtTr = txtTr + '<td data-id="' + currentTr.find('.txtAECutOffNiche').val() + '">' + currentTr.find('.txtAECutOffNiche').val() + '</td>';
                } else {
                    txtTr = txtTr + '<td data-id="' + currentTr.find('.txtAECutOffNiche').val() + '">' + currentTr.find('.txtAECutOffNiche').find('option:selected').text() + '</td>';
                }
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.insertBefore(btn.parent().parent());
        } else {
            var tr = $('<tr class="newtr "></tr>');
            var td = '<td><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>';
            $('#tbodyAEScoreNiche').find('tr').each(function () {
                var currentTr = $(this);
                var txtTr = '<tr>';
                txtTr = txtTr + '<td data-id="' + currentTr.find('.drpAEAditionalExamNiche').val() + '">' + currentTr.find('.drpAEAditionalExamNiche').find('option:selected').text() + '</td>';
                if ($('.drpAEAditionalExamNiche').val() == '10') {
                    txtTr = txtTr + '<td data-id="' + currentTr.find('.txtAECutOffNiche').val() + '">' + currentTr.find('.txtAECutOffNiche').val() + '</td>';
                } else {
                    txtTr = txtTr + '<td data-id="' + currentTr.find('.txtAECutOffNiche').val() + '">' + currentTr.find('.txtAECutOffNiche').find('option:selected').text() + '</td>';
                }
                txtTr = txtTr + '</tr>';
                td = td + txtTr;
            });
            td = td + '</tbody></table></td>';
            tr.append(td);
            tr.insertBefore(btn.parent().parent());
        }
        tr.append('<td class="tdAEOperatorNiche" data-id="' + $('.drpAEOperatorNiche').val() + '">' + $('.drpAEOperatorNiche').find('option:selected').text() + '</td>');
        tr.append('<td><a class="btn btn-danger btnAEDeleteNiche">X</a></td>');
        tr.insertBefore(btn.parent().parent());
        $('.drpAEAditionalExamNiche').val('').trigger('change');
        $('.txtAECutOffNiche').val('');
        $('.drpAEOperatorNiche').val('').trigger('change');
        Check_AE_Niche();
    });
    $('#tbodyAENiche').on('click', '.btnAEDeleteNiche', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_AE_Niche();
    });
    $('#tbodyAENiche').on('click', '#btnAddMoreConditionAENiche', function (e) {
        e.preventDefault();
        var newTr = $('.currentAEPTrNiche').clone();
        newTr.find('td:last-child').html('<a class="btn btn-sm btn-danger btnAESDeleteNiche">X</a>');
        $('#tbodyAEScoreNiche').append('<tr class="newAESTr">' + newTr.html() + '</tr>');
    });
    $('#tbodyAENiche').on('click', '.btnAESDeleteNiche', function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
        Check_AE_Niche();
    });
    $("#btnSaveNicheCourse").on("click", function (i) {
        i.preventDefault();
        var n = $("#frmCoursesOffer");
        if (n.parsley().validate(), !n.parsley().isValid()) return !1;
        var o = !1;
        if ($("#tbodyEC").find("tr.newtr").each(function () {
            o = !0
        }), !o) return swal("Warning.!", "Atleast one Educational Qualification is required."), !1;
        var d = $("#txtfeeswaiverg1").val(),
            l = $("#txtfeeswaiverg2").val(),
            c = $("#txtfeeswaiverg3").val(),
            s = $("#txtfeeswaiverg4").val(),
            p = parseInt(d) + parseInt(l) + parseInt(c) + parseInt(s);
        if (parseInt($("#txttotalseats").val()) > parseInt(p)) return swal("Warning.!", "Sum of G1, G2, G3 and G4 should be equal to total number of seats for this course."), !1;
        if (parseInt($("#txttotalseats").val()) < parseInt(p)) return swal("Warning.!", "Sum of G1, G2, G3 and G4 should be equal to total number of seats for this course."), !1;
        if (0 == parseInt(d) && 0 == parseInt(l) && 0 == parseInt(c) && 0 == parseInt(s)) return swal("Warning.!", "All fee waivers cannot be zero(0)."), !1;
        var f = $(this);
        f.text("Processing..."), f.addClass("disabled"), $("#drpDiscipline").prop("disabled", !1), $("#drpProgramLevel").prop("disabled", !1), $("#drpNatureofcourse").prop("disabled", !1), $("#drpBranch").prop("disabled", !1), $("#drpAnnualFeesCurrency").prop("disabled", !1), $("#drpAnnualBoardingFeesCurrency").prop("disabled", !1), $.ajax({
            method: "POST",
            url: "/Institute/Courses/SaveCourseOffers",
            data: n.serialize() + "&Q0Req=" + t + "&Q1Req=" + e + "&Q2Req=" + a + "&Q3Req=" + r + "&Q1Qualification=&Q1Subject=&Q1Percentage=&Q2Qualification=&Q2Subject=&Q2Percentage=&Q3Qualification=&Q3Subject=&Q3Percentage=&EduQualifications=" + GET_EC() + "&AdditionalExams=" + GET_AE(),
            async: !1,
            success: function (t) { }
        }).done(function (t) {
            "false" == t.flag.toString().toLowerCase() ? (swal({
                title: "Course Already Exist",
                text: "Record Already Exist!",
                type: "warning"
            }), f.text("Save"), f.removeClass("disabled")) : "true" == t.flag.toString().toLowerCase() && (swal({
                title: "Saved",
                text: "Courses has been saved successfully",
                type: "success",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                Clear(), Select_Course(), $("#divhideshow").hide()
            }), f.text("Save"), f.removeClass("disabled"))
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again."), f.text("Save"), f.removeClass("disabled")
        })
    });
}

function page_change_niche() {

    $('#tbodyAENiche').on('change', '.drpAEAditionalExamNiche', function () {
        var drp = $(this);
        var tr = drp.parent().parent();
        var AEFor = drp.find('option:selected').attr('data-for');
        if (AEFor == 'date') {
            tr.find('td:eq(1)').html('<input type="text" placeholder="dd-mm-yyyy" readonly="" class="form-control txtAECutOffNiche datepicker">');
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
            //tr.find('td:eq(1)').html('<input type="text" placeholder="Cutt-off marks" pattern="^\[0-9]{1,4}+(\.[0-9][0-9])?$" class="form-control txtAECutOffNiche">')
            //tr.find('td:eq(1)').html('<input type="text" placeholder="Cutt-off marks" class="form-control txtAECutOffNiche">');
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
            tr.find('td:eq(1)').html('<select class="form-control txtAECutOffNiche"><option value="">--Select Cut-off marks--</option>' + strOption + '</select>');
        }
    });
    $('#tbodyECNiche').on('change', '.drpECOperatorNiche', function () {
        var drp = $(this);
        var selectedText = drp.find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            $('#btnAddMoreConditionNiche').show();
        } else {
            $('#tbodySubjectPercentageNiche').find('tr.newSPTr').remove();
            $('#btnAddMoreConditionNiche').hide();
        }
    });
    $('#tbodyAENiche').on('change', '.drpAEOperatorNiche', function () {
        var drp = $(this);
        var selectedText = drp.find('option:selected').text();
        if (selectedText == 'Multiple OR') {
            $('#btnAddMoreConditionAENiche').show();
        } else {
            $('#tbodyAEScoreNiche').find('tr.newAESTr').remove();
            $('#btnAddMoreConditionAENiche').hide();
        }
    });


}

function Check_EC_Niche() {
    var _Q0 = [];
    var _Q1 = [];
    var _Q2 = [];
    var _Q3 = [];
    $('#tbodyECNiche').find('tr.newtr').each(function () {
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
                'o': tr.find('td.tdECOperatorNiche').attr('data-id'),
                'od': tr.find('td.tdECOperatorNiche').text()
            });
        } else if (ECFor == 'Q1') {
            _Q1.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperatorNiche').attr('data-id'),
                'od': tr.find('td.tdECOperatorNiche').text()
            });
        } else if (ECFor == 'Q2') {
            _Q2.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperatorNiche').attr('data-id'),
                'od': tr.find('td.tdECOperatorNiche').text()
            });
        } else if (ECFor == 'Q3') {
            _Q3.push({
                'q': tr.find('td:eq(0)').text(),
                's': EduSubject_Id,
                'sn': EduSubject,
                'p': PercentageID,
                'o': tr.find('td.tdECOperatorNiche').attr('data-id'),
                'od': tr.find('td.tdECOperatorNiche').text()
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

    $('#tdECConditionNiche').text(strFinal);
}

function Check_AE_Niche() {
    var _E1 = [];
    var _E2 = [];
    var _E3 = [];
    $('#tbodyAENiche').find('tr.newtr').each(function () {
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

    $('#tdAEConditionNiche').text(strFinal);
}

function CalculateDuration(date1, date2) {
    var diff = Math.floor(date2.getTime() - date1.getTime());
    var day = 1000 * 60 * 60 * 24 * 30;
    return (Math.floor(diff / day) + 1);
}

function addDays(theDate, days) {
    return new Date(theDate.getTime() + days * 24 * 60 * 60 * 1000);
}

function subDays(theDate, days) {
    return new Date(theDate.getTime() - days * 24 * 60 * 60 * 1000);
}