$(document).ready(function () {
        page_event(),
        page_change(),
        FillConditionalDropdown()


});


function page_event() {
    page_click();
    Select_Course();
    fillPercentage();
    page_load_niche();
    $("#drpAnnualBoardingFeesCurrency").attr("readonly");
    $("#drpSAARCFeesCurrency").attr("readonly");
    $("#drpNonSAARCCurrency").attr("readonly");


}

function page_load_niche() {
    setStartEndDate();
}

function setStartEndDate() {
    var newCurDOB = new Date(1960, 01, 01, 00, 00, 00, 00);
    var newCurYear = new Date().getFullYear();
    $("#MinimumAgeRequirement").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: '1960:2005',
        todayHighlight: true,
        changeMonth: true,
        changeYear: true,
        minDate: newCurDOB
    });
    $("#txtStartDate").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: '2019:2025',
        todayHighlight: true,
        changeMonth: true,
        changeYear: true,
        minDate: new Date(2019, 08, 01, 00, 00, 00, 00),
        //maxDate: addDays(new Date(), 0),
        onSelect: function (selected) {
            var splitDate = selected.split("-");
            var newCurDate = new Date(splitDate[2], splitDate[1] - 1, splitDate[0]);
            //$("#txtEndDate").datepicker("option", "minDate", addDays(newCurDate, 1));
            $("#txtEndDate").datepicker("option", "minDate", newCurDate);
            if ($("#txtEndDate").val() != '') {
                var splitEndDate1 = $('#txtEndDate').val().split("-");
                var EndDate1 = new Date(splitEndDate1[2], splitEndDate1[1] - 1, splitEndDate1[0]);
                $('#CourseDurations').val(CalculateDuration(newCurDate, EndDate1));

                var a = moment([splitDate[2], splitDate[1] - 1, splitDate[0]]);
                var b = moment([splitEndDate1[2], splitEndDate1[1] - 1, splitEndDate1[0]]);

                var today = new Date(),
                    newYear = new Date(today.getFullYear(), 0, 1),
                    y2k = new Date(2000, 0, 1);
                $('#CourseDurations').val(Date.getFormattedDateDiff(a, b));
            }
        }
    });
    $("#txtEndDate").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: '2019:2025',
        todayHighlight: true,
        changeMonth: true,
        changeYear: true,
        minDate: new Date(2019, 08, 01, 00, 00, 00, 00),
        maxDate: addDays(new Date(2025, 12, 31, 00, 00, 00, 00), 0),
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
                    $('#CourseDurations').val(CalculateDuration(StartDate1, newCurDate));
                    var a = moment([splitStartDate1[2], splitStartDate1[1] - 1, splitStartDate1[0]]);
                    var b = moment([splitDate[2], splitDate[1] - 1, splitDate[0]]);

                    var today = new Date(),
                    newYear = new Date(today.getFullYear(), 0, 1),
                    y2k = new Date(2000, 0, 1);
                    $('#CourseDurations').val(Date.getFormattedDateDiff(a, b));
                }
            }
        }
    });
    Date.getFormattedDateDiff = function (date1, date2) {
        var b = moment(date1),
            a = moment(date2),
            intervals = ['years', 'months', 'weeks', 'days'],
            out = [];

        for (var i = 0; i < intervals.length; i++) {
            var diff = a.diff(b, intervals[i]);
            b.add(diff, intervals[i]);
            if (diff != 0) {
                out.push(diff + ' ' + intervals[i]);
            }
        }
        return out.join(', ');
    };

    
}
function page_change() { 
    $("#NoEligibilitycriteria").on("change", function (t) {
        if ($(this).is(':checked')) {
            $('#tbodyEC').find('tr.newtr').remove();
            $(".drpECQualification").val('').attr('disabled', 1).trigger('change');
            $(".drpECSubject").val('').attr('disabled', 1).trigger('change');
            $(".drpECPercentageID").val('').attr('disabled', 1).trigger('change');
            $(".drpECOperator").val('').attr('disabled', 1).trigger('change');
            $("#btnECAdd").val('').attr('disabled', 1).trigger('change');
        } else {
            $(".drpECQualification").removeAttr('disabled');
            $(".drpECSubject").removeAttr('disabled');
            $(".drpECPercentageID").removeAttr('disabled');
            $(".drpECOperator").removeAttr('disabled');
            $("#btnECAdd").removeAttr('disabled');
        }
    }); 
    $("#drpQ1Qualification").on("change", function (t) {
        t.preventDefault();
        $(".Q1_TXT").val("");
        $(".Q1_TXT").attr("readonly", !0);
        $(".Q1_TXT").removeAttr("required");
        $(".Q1_TXT.drpPercentage").attr("disabled", !0), "10_2" == $(this).val() ? ($(".Q1_10_2").removeAttr("readonly"), $(".Q1_10_2").attr("required", !0), $(".Q1_10_2.drpPercentage").removeAttr("disabled")) : "Diploma" == $(this).val() ? ($(".Q1_Diploma").removeAttr("readonly"), $(".Q1_Diploma").attr("required", !0), $(".Q1_Diploma.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q1_TXT").removeAttr("readonly"), $(".Q1_TXT").attr("required", !0), $(".Q1_TXT.drpPercentage").removeAttr("disabled"))
    });
    $("#drpQ2Qualification").on("change", function (t) {
        t.preventDefault(), $(".Q2_TXT").val(""), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").removeAttr("required"), $(".Q2_TXT.drpPercentage").attr("disabled", !0), "UG" == $(this).val() ? ($(".Q2_UG").removeAttr("readonly"), $(".Q2_UG").attr("required", !0), $(".Q2_UG.drpPercentage").removeAttr("disabled")) : "PG" == $(this).val() ? ($(".Q2_PG").removeAttr("readonly"), $(".Q2_PG").attr("required", !0), $(".Q2_PG.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q2_TXT").removeAttr("readonly"), $(".Q2_TXT").attr("required", !0), $(".Q2_TXT.drpPercentage").removeAttr("disabled"))
    });
    $("#drpQ3Qualification").on("change", function (t) {
        t.preventDefault(), $(".Q3_TXT").val(""), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").removeAttr("required"), $(".Q2_TXT.drpPercentage").attr("disabled", !0), "PG" == $(this).val() ? ($(".Q3_PG").removeAttr("readonly"), $(".Q3_PG").attr("required", !0), $(".Q3_PG.drpPercentage").removeAttr("disabled")) : "Mphil" == $(this).val() ? ($(".Q3_Mphil").removeAttr("readonly"), $(".Q3_Mphil").attr("required", !0), $(".Q3_Mphil.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q3_TXT").removeAttr("readonly"), $(".Q3_TXT").attr("required", !0), $(".Q3_TXT.drpPercentage").removeAttr("disabled"))
    });

    $("#drpTutionFeesCurrency").on("change", function () {
        var t = $(this).val();
        "" == t ? $(".txt-fee-currency").val("--Select--") : $(".txt-fee-currency").val(t)
    });
    $("#tbodyAE").on("change", ".drpAEAditionalExam", function () {
        var t = $(this),
            e = t.parent().parent();
        if ("date" == t.find("option:selected").attr("data-for")) {
            e.find("td:eq(1)").html('<input type="text" placeholder="dd-mm-yyyy" readonly="" class="form-control txtAECutOff datepicker">');
            var a = (new Date).getFullYear();
            $(".datepicker").datepicker({
                orientation: "left",
                autoclose: !0,
                yearRange: "1950:" + a,
                dateFormat: "dd-mm-yy",
                todayHighlight: !1,
                changeMonth: !0,
                changeYear: !0
            })
        } else {
            var r = t.val(),
                i = "";
            $.ajax({
                method: "POST",
                async: !1,
                url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectAES",
                data: {
                    id: r
                }
            }).done(function (t) {
                $.each(t.List, function (t, e) {
                    i = i + '<option value="' + e.AditionalExamScore + '">' + e.AditionalExamSocreDisplay + "</option>"
                })
            }).error(function () {
                swal("error", "Somthing went wrong. Please try again.", "error")
            }), e.find("td:eq(1)").html('<select class="form-control txtAECutOff"><option value="">--Select Cut-off marks--</option>' + i + "</select>")
        }
    });
    $("#tbodyEC").on("change", ".drpECOperator", function () {
        "Multiple OR" == $(this).find("option:selected").text() ? $("#btnAddMoreCondition").show() : ($("#tbodySubjectPercentage").find("tr.newSPTr").remove(), $("#btnAddMoreCondition").hide())
    });
    $("#tbodyAE").on("change", ".drpAEOperator", function () {
        "Multiple OR" == $(this).find("option:selected").text() ? $("#btnAddMoreConditionAE").show() : ($("#tbodyAEScore").find("tr.newAESTr").remove(), $("#btnAddMoreConditionAE").hide())
    })
}
function FillConditionalDropdown() {
    $("#drpDiscipline").on("change", function (t) {
        $("#drpProgramLevel").html(""), $("#drpProgramLevel").append('<option value="">--Select--</option>');
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
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
                $("#drpProgramLevel").append('<option value="' + e.ProgramLevel_Id + '">' + e.ProgramLevel + "</option>")
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#drpProgramLevel").on("change", function (t) {
        $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
        $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
        var e = $(this).val();
        "" == $("#drpDiscipline").val() || $("#drpDiscipline").val();
        $.ajax({
            method: "POST",
            async: !1,
            url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectQNiche",
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: e
            }
        }).done(function (t) {
            $.each(t.List, function (t, e) {
                $("#drpNatureofcourse").append('<option value="' + e.Qualification_ID + '">' + e.Qualification + "</option>")
            })
        }).error(function () {
            swal("error", "Somthing went wrong. Please try again.", "error")
        })
    });
    $("#drpNatureofcourse").on("change", function () {
        $(this).val();
        $.ajax({
            method: "POST",
            url: "/Institute/Courses/SelectCSNiche",
            async: !1,
            data: {
                Discipline_ID: $("#drpDiscipline").val(),
                ProgramLevel_Id: $("#drpProgramLevel").val(),
                Qualification_ID: $("#drpNatureofcourse").val()
            }
        }).done(function (t) {
            $("#drpBranch").html(""), $("#drpBranch").prepend('<option value="">--Select--</option>'), $.each(t.List, function (t, e) {
                $("#drpBranch").append('<option value="' + e.CourseOfStudy_ID + '">' + e.CourseOfStudy + "</option>")
            })
        }).error(function () {
            $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>')
        })
    });
    $("#tbodyEC").on("change", ".drpECQualification", function () {
        var t = $(this).val(),
            e = $(this).parent().parent().find(".drpECSubject");
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
    });
}

function validation() {
    $(".totalseat").on("change", function () {
        alert();
        var t = $("#txtfeeswaiverg1").val(),
            e = $("#txtfeeswaiverg2").val(),
            a = $("#txtfeeswaiverg3").val(),
            r = $("#txtfeeswaiverg4").val(),
            i = parseInt(t) + parseInt(e) + parseInt(a) + parseInt(r);
        parseInt($("#txttotalseats").val()) != parseInt(i) && swal("Warning.!", "Sum of Tuition Fee Waiver seat can't greater than total seat offer by institue")
    })
}

function page_click() {
    var t = 0,
        e = 0,
        a = 0,
        r = 0;
    $("#btnNewCost").on("click", function (t) {
        Clear()
    });
    $("#btnSaveCourse").on("click", function (i) {
        i.preventDefault();

        var n = $("#frmCoursesOffer");
        if (n.parsley().validate(), !n.parsley().isValid()) return !1;
        var o = !1;
        if (!$('#NoEligibilitycriteria').is(':checked')) {
            if ($("#tbodyEC").find("tr.newtr").each(function () {
                o = !0
            }), !o) return swal("Warning.!", "Atleast one Educational Qualification is required."), !1;
        }
        var f = $(this);
        f.text("Processing...");
        f.addClass("disabled");
        $("#drpDiscipline").prop("disabled", !1);
        $("#drpProgramLevel").prop("disabled", !1);
        $("#drpNatureofcourse").prop("disabled", !1);
        $("#drpBranch").prop("disabled", !1);
        $("#drpTutionFeesCurrency").prop("disabled", !1);
        $("#drpAnnualBoardingFeesCurrency").prop("disabled", !1);
        $("#CourseDurations").prop("disabled", !1);
        var earray = [];
        $(".AdditionalFacilities").each(function () {
            var chk = $(this);
            if (chk.is(':checked')) {
                earray.push(chk.val());
            }
        });

        var NoEligibilitycriteria = 0;
        if ($('#NoEligibilitycriteria').is(':checked')) {
            NoEligibilitycriteria = 1
        }

        $.ajax({
            method: "POST",
            url: "/Institute/Courses/SaveNicheCourse",
            data: n.serialize() + "&Q0Req=" + t + "&Q1Req=" + e + "&Q2Req=" + a + "&Q3Req=" + r + "&Q1Qualification=&Q1Subject=&Q1Percentage=&Q2Qualification=&Q2Subject=&Q2Percentage=&Q3Qualification=&Q3Subject=&Q3Percentage=&EduQualifications=" + GET_EC() + "&AdditionalExams=" + GET_AE() + '&AdditionalFacilities=' + earray.join(',') + '&NoEligibilitycriteria=' + NoEligibilitycriteria,
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
    $("#tbodyCourse").on("click", ".btnGridEdit", function () {
        var t = $(this);
        $.ajax({
            method: "get",
            async: !1,
            url: "/Institute/Courses/SelectNicheCourse",
            data: {
                ID: t.attr("data-id")
            },
            success: function (t) { }
        }).done(function (t) {
            document.body.scrollTop = 0, document.documentElement.scrollTop = 0;
            var e = t.List[0];
            $("#divhideshow").show();
            $("#hdfID").val(e.ID);
            $("#drpCoursetype").val(e.CourseType).trigger('change');
            $("#drpDiscipline").val(e.Discipline_ID).trigger("change");
            $("#drpProgramLevel").val(e.ProgramLevel_Id).trigger("change");
            $("#drpNatureofcourse").val(e.Natureofcourse_Id).trigger("change");
            $("#drpBranch").val(e.Branch_Id);
            $("#NoEligibilitycriteria").val(e.NoEligibilitycriteria).trigger("change") ;
            $("#txtEligibilityCriteria").val(e.EligibilityCriteria);
            $("#GenderRestrictions").val(e.GenderRestrictions);
            $("#drpTutionFeesCurrency").val(e.TutionFeesCurrency).trigger("change");
            $("#txtAnnualFees").val(e.TutionFees);
            $("#TotalFees").val(e.TotalFees);
            $("#TutionFeesForSAARCCountry").val(e.TutionFeesForSAARCCountry);
            $("#TutionFeesForNonSAARCCountry").val(e.TutionFeesForNonSAARCCountry);
            $("#Credits").val(e.Credits);
            $("#CourseDurations").val(e.CourseDurations);
            $("#ClassRoomHours").val(e.ClassRoomHours);
            $("#CoursePatterns").val(e.CoursePatterns);
            $("#txtStartDate").val(e.StartDate);
            $("#txtEndDate").val(e.EndDate);
            $("#chktobedecided").attr('checked', (e.tobedecided == 'False' ? false : true));
            $("#CourseDesc").val(e.CourseDesc);
            $("#AdmissionReq").val(e.AdmissionReq);
            $("#CourseDurationsType").val(e.CourseDurationsType);
            $("#MinimumBatchSize").val(e.MinimumBatchSize).trigger("change");

            $("#MedicalFitness").val(e.MedicalFitness);
            $("#MandatoryMedicalExamination").val(e.MandatoryMedicalExamination);
            $("#MedicalFitnessDocuments").val(e.MedicalFitnessDocuments).trigger('change');
            $("#MedicalFitnessDocumentsOther").val(e.MedicalFitnessDocumentsOther);

            $("#HostelAccommodation").val(e.HostelAccommodation);

            $("#MinimumAgeRequirement").val(e.MinimumAgeRequirement);
            if (e.NoEligibilitycriteria == 'True') {
                $('#NoEligibilitycriteria').attr('checked', true).trigger('change');
            }
            $("#MinimumBatchSize").val(e.MinimumBatchSize);
            $("#InternationalBatchSize").val(e.InternationalBatchSize);
            $("#Food").val(e.Food);
            $("#AC").val(e.AC);
            var earray = e.AdditionalFacilities.split(',');
            $(".AdditionalFacilities").each(function () {
                var chk = $(this);
                if (earray.indexOf(chk.val()) >= 0) {
                    chk.attr('checked', true);
                    if (chk.attr('id') == 'chkaccommodation') {
                        if (chk.is(":checked")) {
                            $('#Additionalaccommodation').show()
                        } else {
                            $('#Additionalaccommodation').hide();
                            $('#chkSharedroom').removeAttr("checked");
                            $('#chkIndependentroom').removeAttr("checked");
                        }
                    }
                }
            });
            $("#tbodyEC").find("tr.newtr").remove();
            $.each(t.ListEC, function (t, e) {
                var a = $('<tr class="newtr"></tr>');
                a.append('<td data-id="' + e.EduQualifications_Id + '" data-for="' + e.EduQualificationsFor + '">' + e.EduQualifications + "</td>");
                for (var r = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>', i = e.EduSubject.split("|"), n = e.EduSubject_Id.split("|"), o = e.PercentageID.split("|"), d = 0; d < n.length; d++) {
                    var l = "<tr>";
                    l = (l = l + '<td data-id="' + n[d] + '">' + i[d] + "</td>") + '<td data-id="' + o[d] + '">' + o[d] + "</td>", r += l += "</tr>"
                }
                r += "</tbody></table></td>", a.append(r), a.append('<td class="tdECOperator" data-id="' + e.Operator + '">' + e.OperatorDisplay + "</td>"), a.append('<td><a class="btn btn-danger btnECDelete">X</a></td>'), a.insertBefore($("#defaultECTR"))
            });
            $("#tbodyAE").find("tr.newtr").remove();
            $.each(t.ListAE, function (t, e) {
                for (var a = $('<tr class="newtr"></tr>'), r = '<td data-for="' + e.AditionalExamsFor + '"><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>', i = e.AditionalExams_Id.split("|"), n = e.AditionalExams.split("|"), o = (e.AditionalExamsFor.split("|"), e.CutOff.split("|")), d = 0; d < i.length; d++) {
                    var l = "<tr>";
                    l = (l = l + '<td data-id="' + i[d] + '">' + n[d] + "</td>") + '<td data-id="' + o[d] + '">' + ("0" == o[d] && "10" != i[d] ? "No Minimum Score" : o[d]) + "</td>", r += l += "</tr>"
                }
                r += "</tbody></table></td>", a.append(r), a.append('<td class="tdAEOperator" data-id="' + e.Operator + '">' + e.OperatorDisplay + "</td>"), a.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>'), a.insertBefore($("#defaultAETR"))
            });
            Check_EC();
            Check_AE();
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.")
        })
    });
    $("#tbodyCourse").on("click", ".btnDelete", function () {
        var t = $(this).attr("data-id");
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
                url: "/Institute/Courses/DeleteNicheCourse",
                data: {
                    ID: t
                },
                success: function (t) { }
            }).done(function (t) {
                Select_Course(), swal("Success!", "Your data has been deleted.")
            }).error(function () {
                swal("Oops...!", "Something went wrong from our side.")
            })
        })
    });
    $("#cbQ0Req").on("click", function () {
        $(this).is(":checked") ? (t = 1, $("#txtQ0Subject").prop("required", !0), $("#txtQ0Subject").removeAttr("readonly"), $("#txtQ0Percentage").prop("required", !0), $("#txtQ0Percentage").removeAttr("disabled")) : ($("#txtQ0Subject").removeProp("required", !0), $("#txtQ0Subject").attr("readonly", !0), $("#txtQ0Subject").val(""), $("#txtQ0Percentage").removeProp("required", !0), $("#txtQ0Percentage").attr("disabled", !0), $("#txtQ0Percentage").val(""))
    });
    $("#cbQ1Req").on("click", function () {
        $(this).is(":checked") ? (e = 1, $("#drpQ1Qualification").prop("required", !0), $("#drpQ1Qualification").removeProp("disabled")) : ($("#drpQ1Qualification").removeProp("required", !0), $("#drpQ1Qualification").prop("disabled", !0), $("#drpQ1Qualification").val(""), $("#drpQ1Qualification").trigger("change"), $(".Q1_TXT").attr("readonly", !0), $(".Q1_TXT").attr("readonly", !0), $(".Q1_TXT").val(""))
    });
    $("#cbQ2Req").on("click", function () {
        $(this).is(":checked") ? (a = 1, $("#drpQ2Qualification").prop("required", !0), $("#drpQ2Qualification").removeProp("disabled")) : ($("#drpQ2Qualification").removeProp("required", !0), $("#drpQ2Qualification").prop("disabled", !0), $("#drpQ2Qualification").val(""), $("#drpQ2Qualification").trigger("change"), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").val(""))
    });
    $("#cbQ3Req").on("click", function () {
        $(this).is(":checked") ? (r = 1, $("#drpQ3Qualification").prop("required", !0), $("#drpQ3Qualification").removeProp("disabled")) : ($("#drpQ3Qualification").removeProp("required", !0), $("#drpQ3Qualification").prop("disabled", !0), $("#drpQ3Qualification").val(""), $("#drpQ3Qualification").trigger("change"), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").val(""))
    });
    $("#btnECAdd").on("click", function (t) {

        t.preventDefault();
        var e = !0,
            a = !0,
            r = [];
        if ($(".drpECSubject").each(function () {
            var t = $(this);
            "" == t.val() && (e = !1), -1 != $.inArray(t.val(), r) ? a = !1 : r.push(t.val())
        }), !a) return swal("warning", "Same subject are selected.", "warning"), !1;
        var i = !0;
        if ($(".drpECPercentageID").each(function () {
            "" == $(this).val() && (i = !1)
        }), "" == $(".drpECQualification").val()) return swal("warning", "Please select Qualification.", "warning"), !1;
        if (!e) return swal("warning", "Please select subject.", "warning"), !1;
        if (!i) return swal("warning", "Please select percentage.", "warning"), !1;
        if ("" == $(".drpECOperator").val()) return swal("warning", "Please select operator.", "warning"), !1;
        var n = !0,
            o = "",
            d = "";
        if ($("#tbodyEC").find("tr.newtr").each(function () {
            var t = $(this);
            t.find("td:eq(1)").find("tbody").find("tr").each(function (t, e) {
                var a = $(this);
                $(".drpECSubject").each(function () {
                    $(this).val() == a.find("td:eq(0)").attr("data-id") && (n = !1)
                })
            }), o = t.find("td:eq(0)").attr("data-for"), d = t.find("td:eq(0)").text()
        }), "" == o && (o = "Q-1"), !(parseInt(o.replace("Q", "")) <= parseInt($(".drpECQualification").find("option:selected").attr("data-for").replace("Q", "")))) return swal("warning", "Please add qualification in sequence.", "warning"), !1;
        if ("Q0" == $(".drpECQualification").find("option:selected").attr("data-for")) {
            if ("" == d && "10th" == $(".drpECQualification").find("option:selected").text());
            else if ("10th" != d || "10th" != $(".drpECQualification").find("option:selected").text()) return swal("warning", "Please add qualification in sequence.", "warning"), !1
        } else if ("Q1" == $(".drpECQualification").find("option:selected").attr("data-for")) {
            if ("" == d && "10+2" == $(".drpECQualification").find("option:selected").text());
            else if ("" == d && "Diploma" == $(".drpECQualification").find("option:selected").text());
            else if ("10th" == d && "10+2" == $(".drpECQualification").find("option:selected").text());
            else if ("10th" == d && "Diploma" == $(".drpECQualification").find("option:selected").text());
            else if ("10+2" == d && "10+2" == $(".drpECQualification").find("option:selected").text());
            else if ("10+2" == d && "Diploma" == $(".drpECQualification").find("option:selected").text());
            else if ("Diploma" != d || "Diploma" != $(".drpECQualification").find("option:selected").text()) return swal("warning", "Please add qualification in sequence.", "warning"), !1
        } else if ("Q2" == $(".drpECQualification").find("option:selected").attr("data-for")) {
            if ("" == d && "UG" == $(".drpECQualification").find("option:selected").text());
            else if ("" == d && "PG" == $(".drpECQualification").find("option:selected").text());
            else if ("10th" == d && "UG" == $(".drpECQualification").find("option:selected").text());
            else if ("10th" == d && "PG" == $(".drpECQualification").find("option:selected").text());
            else if ("10+2" == d && "UG" == $(".drpECQualification").find("option:selected").text());
            else if ("10+2" == d && "PG" == $(".drpECQualification").find("option:selected").text());
            else if ("Diploma" == d && "UG" == $(".drpECQualification").find("option:selected").text());
            else if ("Diploma" == d && "PG" == $(".drpECQualification").find("option:selected").text());
            else if ("UG" == d && "UG" == $(".drpECQualification").find("option:selected").text());
            else if ("UG" == d && "PG" == $(".drpECQualification").find("option:selected").text());
            else if ("PG" != d || "PG" != $(".drpECQualification").find("option:selected").text()) return swal("warning", "Please add qualification in sequence.", "warning"), !1
        } else if ("Q3" == $(".drpECQualification").find("option:selected").attr("data-for"))
            if ("" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("10th" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("10+2" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("Diploma" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("UG" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("PG" == d && "M.Phil." == $(".drpECQualification").find("option:selected").text());
            else if ("M.Phil." != d || "M.Phil." != $(".drpECQualification").find("option:selected").text()) return swal("warning", "Please add qualification in sequence.", "warning"), !1;
        if (!n) return swal("warning", "Already selected same qualification and subject.", "warning"), !1;
        var l = $(this);
        if ("Multiple OR" == $(".drpECOperator").find("option:selected").text()) {
            (s = $('<tr class="newtr AndWithOr"></tr>')).append('<td data-id="' + $(".drpECQualification").val() + '" data-for="' + $(".drpECQualification").find("option:selected").attr("data-for") + '">' + $(".drpECQualification").find("option:selected").text() + "</td>");
            var c = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $("#tbodySubjectPercentage").find("tr").each(function () {
                var t = $(this),
                    e = "<tr>";
                e = (e = e + '<td data-id="' + t.find(".drpECSubject").val() + '">' + t.find(".drpECSubject").find("option:selected").text() + "</td>") + '<td data-id="' + t.find(".drpECPercentageID").val() + '">' + t.find(".drpECPercentageID").find("option:selected").text() + "</td>", c += e += "</tr>"
            }), c += "</tbody></table></td>", s.append(c), s.append('<td class="tdECOperator" data-id="' + $(".drpECOperator").val() + '">' + $(".drpECOperator").find("option:selected").text() + "</td>"), s.append('<td><a class="btn btn-danger btnECDelete">X</a></td>'), s.insertBefore(l.parent().parent())
        } else {
            var s;
            (s = $('<tr class="newtr "></tr>')).append('<td data-id="' + $(".drpECQualification").val() + '" data-for="' + $(".drpECQualification").find("option:selected").attr("data-for") + '">' + $(".drpECQualification").find("option:selected").text() + "</td>");
            c = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>';
            $("#tbodySubjectPercentage").find("tr").each(function () {
                var t = $(this),
                    e = "<tr>";
                e = (e = e + '<td data-id="' + t.find(".drpECSubject").val() + '">' + t.find(".drpECSubject").find("option:selected").text() + "</td>") + '<td data-id="' + t.find(".drpECPercentageID").val() + '">' + t.find(".drpECPercentageID").find("option:selected").text() + "</td>", c += e += "</tr>"
            }), c += "</tbody></table></td>", s.append(c), s.append('<td class="tdECOperator" data-id="' + $(".drpECOperator").val() + '">' + $(".drpECOperator").find("option:selected").text() + "</td>"), s.append('<td><a class="btn btn-danger btnECDelete">X</a></td>'), s.insertBefore(l.parent().parent())
        }
        $(".drpECQualification").val("").trigger("change");
        $(".drpECSubject").val("").trigger("change");
        $(".drpECPercentageID").val("").trigger("change");
        $(".drpECOperator").val("").trigger("change");

        Check_EC();
    });
    $("#tbodyEC").on("click", ".btnECDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_EC()
    });
    $("#tbodyEC").on("click", "#btnAddMoreCondition", function (t) {
        t.preventDefault();
        var e = $(".currentSPTr").clone();
        e.find("td:last-child").html('<a class="btn btn-sm btn-danger btnSPDelete">X</a>'), $("#tbodySubjectPercentage").append('<tr class="newSPTr">' + e.html() + "</tr>")
    });
    $("#tbodyEC").on("click", ".btnSPDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_EC()
    });
    $("#btnAEAdd").on("click", function (t) {
        
        t.preventDefault();
        var e = !0,
            a = !0,
            r = [];
        if ($(".drpAEAditionalExam").each(function () {
            var t = $(this);
            "" == t.val() && (e = !1), -1 != $.inArray(t.val(), r) ? a = !1 : r.push(t.val())
        }), !a) return swal("warning", "Same Exam are selected.", "warning"), !1;
        var i = !0;
        if ($(".txtAECutOff").each(function () {
            "" == $(this).val() && (i = !1)
        }), !e) return swal("warning", "Please select exam.", "warning"), !1;
        if (!i) return swal("warning", "Please select Score.", "warning"), !1;
        if ("" == $(".drpAEOperator").val()) return swal("warning", "Please select operator.", "warning"), !1;
        var n = !0;
        if ($("#tbodyAE").find("tr.newtr").each(function () {
            $(this).find("td:eq(0)").attr("data-id") == $(".drpAEAditionalExam").val() && (n = !1)
        }), !n) return swal("warning", "Already selected same exam / criteria.", "warning"), !1;
        var o = $(this);
        if ("Multiple OR" == $(".drpAEOperator").find("option:selected").text()) {
            var d = $('<tr class="newtr AndWithOr"></tr>'),
                l = '<td data-for="' + $(".drpAEAditionalExam").find("option:selected").attr('data-aefor') + '"><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>';
            $("#tbodyAEScore").find("tr").each(function () {
                var t = $(this),
                    e = "<tr>";
                e = e + '<td data-id="' + t.find(".drpAEAditionalExam").val() + '">' + t.find(".drpAEAditionalExam").find("option:selected").text() + "</td>", e = "10" == $(".drpAEAditionalExam").val() ? e + '<td data-id="' + t.find(".txtAECutOff").val() + '">' + t.find(".txtAECutOff").val() + "</td>" : e + '<td data-id="' + t.find(".txtAECutOff").val() + '">' + t.find(".txtAECutOff").find("option:selected").text() + "</td>", l += e += "</tr>"
            }), l += "</tbody></table></td>", d.append(l), d.insertBefore(o.parent().parent())
        } else {
            d = $('<tr class="newtr "></tr>'), l = '<td><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>';
            $("#tbodyAEScore").find("tr").each(function () {
                var t = $(this),
                    e = "<tr>";
                e = e + '<td data-id="' + t.find(".drpAEAditionalExam").val() + '">' + t.find(".drpAEAditionalExam").find("option:selected").text() + "</td>", e = "10" == $(".drpAEAditionalExam").val() ? e + '<td data-id="' + t.find(".txtAECutOff").val() + '">' + t.find(".txtAECutOff").val() + "</td>" : e + '<td data-id="' + t.find(".txtAECutOff").val() + '">' + t.find(".txtAECutOff").find("option:selected").text() + "</td>", l += e += "</tr>"
            }), l += "</tbody></table></td>", d.append(l), d.insertBefore(o.parent().parent())
        }
        d.append('<td class="tdAEOperator" data-id="' + $(".drpAEOperator").val() + '">' + $(".drpAEOperator").find("option:selected").text() + "</td>");
        d.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>');
        d.insertBefore(o.parent().parent());
        $(".drpAEAditionalExam").val("").trigger("change");
        $(".txtAECutOff").val("");
        $(".drpAEOperator").val("").trigger("change");
        Check_AE();
    });
    $("#tbodyAE").on("click", ".btnAEDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_AE()
    });
    $("#tbodyAE").on("click", "#btnAddMoreConditionAE", function (t) {
        t.preventDefault();
        var e = $(".currentAEPTr").clone();
        e.find("td:last-child").html('<a class="btn btn-sm btn-danger btnAESDelete">X</a>'), $("#tbodyAEScore").append('<tr class="newAESTr">' + e.html() + "</tr>")
    });
    $("#tbodyAE").on("click", ".btnAESDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_AE()
    })
    $('#chkaccommodation').on("click", function () {
        $(this).is(":checked") ? ($('#Additionalaccommodation').show()) : ($('#Additionalaccommodation').hide(), $('#chkSharedroom').removeAttr("checked"), $('#chkIndependentroom').removeAttr("checked"))
    });
    //$('#drpCoursetype').on("change", function (e) {
    //    e.preventDefault();
    //    var t = "Total Fees", a = "Tuition Fees per seat for Course", b = "Total Fees per seat for Course", c = " Tuition Fees (SAARC Country)", d = "Tuition Fees (NonSAARC Country)";
    //    $(this).val() == '1' ? ($('#txtLabelfee').text('Annual ' + t), $('#F1').text('Annual ' + a), $('#F2').text('Annual ' + b), $('#F3').text('Annual ' + c), $('#F4').text('Annual ' + d)) : ($('#txtLabelfee').text(t), $('#F1').text(a), $('#F2').text(b), $('#F3').text(c), $('#F4').text(d)),
    //    $(this).val() == '2' ? ($('#divdateshrt').show(), $('#CourseDurations').val('').attr('disabled', true)) : ($('#divdateshrt').hide(), $('#CourseDurations').val('').attr('disabled', false))
    //});
    $('#chktobedecided').on("click", function () {
        $(this).is(":checked") ? ($('.datepicker').val('').attr('disabled', true).css('background', '#808080'), $('#CourseDurations').val('').attr('disabled', false)) : ($('.datepicker').attr('readonly', true).attr('disabled', false).css('background', '#FFF'), $('#CourseDurations').val('').attr('disabled', true))
    });
}

function Clear() {
    $("#frmCoursesOffer").trigger("reset");
    $("#frmCoursesOffer").find('input').val('');
    $("#frmCoursesOffer").find('select').val('').trigger('change');
    $("#MinimumAgeRequirement").datepicker("destroy");
    $("#txtStartDate").datepicker('destroy');
    $("#txtEndDate").datepicker('destroy');
    setStartEndDate();
    $("#divhideshow").show();
    $("#hdfID").val(0);
    $("#drpBranch").trigger("change");
    $("#drpDiscipline").prop("disabled", !1);
    $("#drpProgramLevel").prop("disabled", !1);
    $("#drpNatureofcourse").prop("disabled", !1);
    $("#drpBranch").prop("disabled", !1);
    $("#txtfeeswaiverg1").attr("readonly", !1);
    $("#txtfeeswaiverg2").attr("readonly", !1);
    $("#txtfeeswaiverg3").attr("readonly", !1);
    $("#txtfeeswaiverg4").attr("readonly", !1);
    $("#txttotalseats").attr("readonly", !1);
    $("#txtAnnualFees").attr("readonly", !1);
    $("#txttotalBoarding").attr("readonly", !1);
    $("#txtAdmission").attr("readonly", !1);
    $("#hdfIsGivenFromInstitute").val("0");
    $("#tbodyEC").find("tr.newtr").remove();
    $("#tbodyAE").find("tr.newtr").remove();
    $("#tdECCondition").text("");
    $("#tbodySubjectPercentage").find("tr.newSPTr").remove();
    $("#tbodyAEScore").find("tr.newAESTr").remove()
}

function Select_Course() {
    $("#tbodyCourse").html("");
    $.ajax({
        method: "GET",
        async: !1,
        url: "/Institute/Courses/SelectNicheCourse",
        success: function (t) { }
    }).done(function (t) {
        var e = 1;
        $.each(t.List, function (t, a) {
            var r = $("<tr></tr>");
            r.append("<td>" + e++ + "</td>");
            r.append("<td>" + a.ProgramLevel + "</td>");
            //r.append("<td>" + a.Qualification + "</td>");
            //r.append("<td>" + a.CourseOfStudy + "</td>");
            r.append("<td>" + a.Natureofcourse + "</td>");
            r.append("<td>" + a.BranchName + "</td>");
            //r.append("<td>" + a.SeatForForeignStudent + "</td>");
            editbtn = '<button class="btn btn-success btnGridEdit" title="Edit" data-toggle="tooltip" type="button" data-id="' + a.ID + '" ><i class="glyphicon glyphicon-pencil"></i></button>';
            deletebtn = '<a class="btn btn-danger btnDelete" title="Delete" data-toggle="tooltip" data-id="' + a.ID + '"><i class="glyphicon glyphicon-trash"></i></a>';

            r.append("<td>" + editbtn + "&nbsp;&nbsp;" + deletebtn + "</td>");
            $("#tbodyCourse").append(r);
        })
    }).error(function () {
        swal("Oops...!", "Something went wrong! Please try again.")
    })
}

function fillPercentage() {
    for (var t = 99; t >= 35; t--) $(".drpPercentage").append("<option>" + t + "</option>")
}

function ConvertDateToSQLDate(t) {
    var e = t,
        a = "";
    new Array;
    return "" != e && (a = e.split("-").reverse().join("-")), a
}

function GET_EC() {
    var t = [];
    return $("#tbodyEC").find("tr.newtr").each(function () {
        var e, a, r, i = $(this),
            n = "",
            o = "";
        e = i.find("td:eq(0)").attr("data-id"), a = i.find("td.tdECOperator").attr("data-id"), r = i.find("td.tdECOperator").text(), i.find("td:eq(1)").find("tbody").find("tr").each(function (t, e) {
            var a = $(this);
            0 == t ? (n = a.find("td:eq(0)").attr("data-id"), o = a.find("td:eq(1)").attr("data-id")) : (n = n + "|" + a.find("td:eq(0)").attr("data-id"), o = o + "|" + a.find("td:eq(1)").attr("data-id"))
        }), t.push({
            EduQualifications_Id: e,
            EduSubject_Id: n,
            PercentageID: o,
            Operator: a,
            OperatorDisplay: r
        })
    }), JSON.stringify(t)
}

function GET_AE() {
    var t = [];
    return $("#tbodyAE").find("tr.newtr").each(function () {
        var e, a = $(this),
            r = "",
            i = "";
        e = a.find("td.tdAEOperator").attr("data-id"), OperatorDisplay = a.find("td.tdAEOperator").text(), a.find("td:eq(0)").find("tbody").find("tr").each(function (t, e) {
            var a = $(this);
            0 == t ? (r = a.find("td:eq(0)").attr("data-id"), i = "10" == r ? ConvertDateToSQLDate(a.find("td:eq(1)").attr("data-id")) : a.find("td:eq(1)").attr("data-id")) : (r = r + "|" + a.find("td:eq(0)").attr("data-id"), i = "10" == r ? i + "|" + ConvertDateToSQLDate(a.find("td:eq(1)").attr("data-id")) : i + "|" + a.find("td:eq(1)").attr("data-id"))
        }), t.push({
            AditionalExams_Id: r,
            CutOff: i,
            Operator: e,
            OperatorDisplay: OperatorDisplay
        })
    }), JSON.stringify(t)
}

function Check_EC() {

    var t = [],
        e = [],
        a = [],
        r = [];
    $("#tbodyEC").find("tr.newtr").each(function () {
        var i = $(this),
            n = i.find("td:eq(0)").attr("data-for"),
            o = i.find("td:eq(1)").find("tbody"),
            d = "",
            l = "",
            c = "";
        o.find("tr").each(function (t, e) {
            var a = $(this);
            0 == t ? (d = a.find("td:eq(0)").attr("data-id"), l = a.find("td:eq(0)").text(), c = a.find("td:eq(1)").attr("data-id")) : (d = d + "|" + a.find("td:eq(0)").attr("data-id"), l = l + "|" + a.find("td:eq(0)").text(), c = c + "|" + a.find("td:eq(1)").attr("data-id"))
        }), "Q0" == n ? t.push({
            q: i.find("td:eq(0)").text(),
            s: d,
            sn: l,
            p: c,
            o: i.find("td.tdECOperator").attr("data-id"),
            od: i.find("td.tdECOperator").text()
        }) : "Q1" == n ? e.push({
            q: i.find("td:eq(0)").text(),
            s: d,
            sn: l,
            p: c,
            o: i.find("td.tdECOperator").attr("data-id"),
            od: i.find("td.tdECOperator").text()
        }) : "Q2" == n ? a.push({
            q: i.find("td:eq(0)").text(),
            s: d,
            sn: l,
            p: c,
            o: i.find("td.tdECOperator").attr("data-id"),
            od: i.find("td.tdECOperator").text()
        }) : "Q3" == n && r.push({
            q: i.find("td:eq(0)").text(),
            s: d,
            sn: l,
            p: c,
            o: i.find("td.tdECOperator").attr("data-id"),
            od: i.find("td.tdECOperator").text()
        })
    });
    var i = "",
        n = "",
        o = "",
        d = "";
    if (t.length > 0 && (i = "( ", $.each(t, function (e, a) {
        i = e + 1 == t.length ? i + " " + fill_text(!0, a.q, a.s, a.sn, a.p, a.o, a.od) : i + " " + fill_text(!1, a.q, a.s, a.sn, a.p, a.o, a.od)
    }), i += " )"), e.length > 0) {
        n = "( ";
        var l = [],
            c = [],
            s = "",
            p = "",
            f = "";
        $.each(e, function (t, e) {
            "10+2" == e.q ? l.push({
                q: e.q,
                s: e.s,
                sn: e.sn,
                p: e.p,
                o: e.o,
                od: e.od
            }) : c.push({
                q: e.q,
                s: e.s,
                sn: e.sn,
                p: e.p,
                o: e.o,
                od: e.od
            })
        }), $.each(l, function (t, e) {
            s = t + 1 == l.length ? s + " " + fill_text(!0, e.q, e.s, e.sn, e.p, e.o, e.od) : s + " " + fill_text(!1, e.q, e.s, e.sn, e.p, e.o, e.od), f = e.o
        }), $.each(c, function (t, e) {
            p = t + 1 == c.length ? p + " " + fill_text(!0, e.q, e.s, e.sn, e.p, e.o, e.od) : p + " " + fill_text(!1, e.q, e.s, e.sn, e.p, e.o, e.od)
        }), n = n + s + (l.length > 0 && c.length > 0 ? " " + f + " " : "") + p, n += " )"
    }
    if (a.length > 0) {
        o = "( ";
        var u = [],
            v = [],
            g = "",
            h = "";
        f = "";
        $.each(a, function (t, e) {
            "UG" == e.q ? u.push({
                q: e.q,
                s: e.s,
                sn: e.sn,
                p: e.p,
                o: e.o,
                od: e.od
            }) : v.push({
                q: e.q,
                s: e.s,
                sn: e.sn,
                p: e.p,
                o: e.o,
                od: e.od
            })
        }), $.each(u, function (t, e) {
            t + 1 == u.length ? (g = g + " " + fill_text(!0, e.q, e.s, e.sn, e.p, e.o, e.od), e.o) : g = g + " " + fill_text(!1, e.q, e.s, e.sn, e.p, e.o, e.od), f = e.o
        }), $.each(v, function (t, e) {
            h = t + 1 == v.length ? h + " " + fill_text(!0, e.q, e.s, e.sn, e.p, e.o, e.od) : h + " " + fill_text(!1, e.q, e.s, e.sn, e.p, e.o, e.od)
        }), o = o + g + (u.length > 0 && v.length > 0 ? " " + f + " " : "") + h, o += " )"
    }
    r.length > 0 && (d = "( ", $.each(r, function (t, e) {
        d = t + 1 == r.length ? d + " " + fill_text(!0, e.q, e.s, e.sn, e.p, e.o, e.od) : d + " " + fill_text(!1, e.q, e.s, e.sn, e.p, e.o, e.od)
    }), d += " )");
    var E = "";
    i.length > 0 && (E += i), n.length > 0 && (E = E + (i.length > 0 ? " And " : "") + n), o.length > 0 && (E = E + (n.length > 0 ? " And " : "") + o), d.length > 0 && (E = E + (o.length > 0 ? " And " : "") + d);
    $("#tdECCondition").text(E)
}

function Check_AE() {
    var t = [],
        e = [];
    $("#tbodyAE").find("tr.newtr").each(function () {
        
        var a = $(this),
            r = a.find("td:eq(0)").attr("data-for");
        var subtr = a.find("td:eq(0)").find("tbody");
        "E1" == r ? t.push({
            e: subtr.find("td:eq(0)").text(),
            c: subtr.find("td:eq(1)").text(),
            o: subtr.find("td:eq(2)").text()
        }) : "E2" == r && e.push({
            e: subtr.find("td:eq(0)").text(),
            c: subtr.find("td:eq(1)").text(),
            o: subtr.find("td:eq(2)").text()
        })
    });
    var a = "",
        r = "";

    t.length > 0 && (a = "( ", $.each(t, function (e, r) {
        a = e + 1 == t.length ? a + " " + fill_text_ae(!0, r.e, r.c, r.o) : a + " " + fill_text_ae(!1, r.e, r.c, r.o)
    }), a += " )"), e.length > 0 && (r = "( ", $.each(e, function (t, a) {
        r = t + 1 == e.length ? r + " " + fill_text_ae(!0, a.e, a.c, a.o) : r + " " + fill_text_ae(!1, a.e, a.c, a.o)
    }), r += " )");
    var i = "";
    a.length > 0 && (i += a), r.length > 0 && (i = i + (a.length > 0 ? " And " : "") + r)

    $("#tdAECondition").text(i)
}

function fill_text(t, e, a, r, i, n, o) {
    var d = "";
    if ("Multiple OR" == o) {
        d += "( ";
        for (var l = r.split("|"), c = a.split("|"), s = i.split("|"), p = 0; p < c.length; p++) d = p < c.length - 1 ? d + e + " in " + l[p] + " with " + s[p] + "% OR " : d + e + " in " + l[p] + " with " + s[p] + "%";
        t ? d += " ) " : d = d + " ) " + n
    } else d = t ? e + " in " + r + " with " + i + "%" : e + " in " + r + " with " + i + "% " + n;
    return d
}

function fill_text_ae(t, e, a, r) {
    //    alert(t + ' --- ' + e + ' --- ' + a + ' --- ' +   r)
    return "Age Limit Date" == e ? t ? " Date of Birth must be after " + a : " Date of Birth must be after " + a + " " + r : t ? e + " with " + a + " score " : e + " with " + a + " score " + r
}

function SortECOperator(t, e) {
    return t.o == e.o ? 0 : t.o > e.o ? 1 : -1
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