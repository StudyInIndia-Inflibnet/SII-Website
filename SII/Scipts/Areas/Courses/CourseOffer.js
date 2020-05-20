function page_event() {
    page_click(), Select_Course(), fillPercentage(), $("#drpAnnualBoardingFeesCurrency").attr("readonly"), $("#drpSAARCFeesCurrency").attr("readonly"), $("#drpNonSAARCCurrency").attr("readonly")
}

function page_change() {
    $("#drpQ1Qualification").on("change", function (t) {
        t.preventDefault(), $(".Q1_TXT").val(""), $(".Q1_TXT").attr("readonly", !0), $(".Q1_TXT").removeAttr("required"), $(".Q1_TXT.drpPercentage").attr("disabled", !0), "10_2" == $(this).val() ? ($(".Q1_10_2").removeAttr("readonly"), $(".Q1_10_2").attr("required", !0), $(".Q1_10_2.drpPercentage").removeAttr("disabled")) : "Diploma" == $(this).val() ? ($(".Q1_Diploma").removeAttr("readonly"), $(".Q1_Diploma").attr("required", !0), $(".Q1_Diploma.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q1_TXT").removeAttr("readonly"), $(".Q1_TXT").attr("required", !0), $(".Q1_TXT.drpPercentage").removeAttr("disabled"))
    }), $("#drpQ2Qualification").on("change", function (t) {
        t.preventDefault(), $(".Q2_TXT").val(""), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").removeAttr("required"), $(".Q2_TXT.drpPercentage").attr("disabled", !0), "UG" == $(this).val() ? ($(".Q2_UG").removeAttr("readonly"), $(".Q2_UG").attr("required", !0), $(".Q2_UG.drpPercentage").removeAttr("disabled")) : "PG" == $(this).val() ? ($(".Q2_PG").removeAttr("readonly"), $(".Q2_PG").attr("required", !0), $(".Q2_PG.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q2_TXT").removeAttr("readonly"), $(".Q2_TXT").attr("required", !0), $(".Q2_TXT.drpPercentage").removeAttr("disabled"))
    }), $("#drpQ3Qualification").on("change", function (t) {
        t.preventDefault(), $(".Q3_TXT").val(""), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").removeAttr("required"), $(".Q2_TXT.drpPercentage").attr("disabled", !0), "PG" == $(this).val() ? ($(".Q3_PG").removeAttr("readonly"), $(".Q3_PG").attr("required", !0), $(".Q3_PG.drpPercentage").removeAttr("disabled")) : "Mphil" == $(this).val() ? ($(".Q3_Mphil").removeAttr("readonly"), $(".Q3_Mphil").attr("required", !0), $(".Q3_Mphil.drpPercentage").removeAttr("disabled")) : "Either" == $(this).val() && ($(".Q3_TXT").removeAttr("readonly"), $(".Q3_TXT").attr("required", !0), $(".Q3_TXT.drpPercentage").removeAttr("disabled"))
    }), $("#rbtJEEMainReqNo").change(function () {
        $("#tx_JEEMainscoreReq").removeAttr("required"), $("#tx_JEEMainscoreReq").prop("disabled", !0), $("#tx_JEEMainscoreReq").val("")
    }), $("#rbtJEEAdvanceReqNo").change(function () {
        $("#tx_JEEAdvanceScoreReq").removeAttr("required"), $("#tx_JEEAdvanceScoreReq").prop("disabled", !0), $("#tx_JEEAdvanceScoreReq").val("")
    }), $("#rbtIELTSReqNo").change(function () {
        $("#tx_IELTSscoreReq").removeAttr("required"), $("#tx_IELTSscoreReq").prop("disabled", !0), $("#tx_IELTSscoreReq").val("")
    }), $("#rbtGMATReqNo").change(function () {
        $("#tx_GMATScoreReq").removeAttr("required"), $("#tx_GMATScoreReq").prop("disabled", !0), $("#tx_GMATScoreReq").val("")
    }), $("#rbtTOFELReqNo").change(function () {
        $("#tx_TOFELScoreReq").removeAttr("required"), $("#tx_TOFELScoreReq").prop("disabled", !0), $("#tx_TOFELScoreReq").val("")
    }), $("#rbtSATReqNo").change(function () {
        $("#tx_SATScoreReq").removeAttr("required"), $("#tx_SATScoreReq").prop("disabled", !0), $("#tx_SATScoreReq").val("")
    }), $("#rbtGATEReqNo").change(function () {
        $("#tx_GATEScoreReq").removeAttr("required"), $("#tx_GATEScoreReq").prop("disabled", !0), $("#tx_GATEScoreReq").val("")
    }), $("#rbtJEEMainReqYes").change(function () {
        $("#tx_JEEMainscoreReq").attr("required", !0), $("#tx_JEEMainscoreReq").prop("disabled", !1)
    }), $("#rbtJEEAdvanceReqYes").change(function () {
        $("#tx_JEEAdvanceScoreReq").attr("required", !0), $("#tx_JEEAdvanceScoreReq").prop("disabled", !1)
    }), $("#rbtIELTSReqYes").change(function () {
        $("#tx_IELTSscoreReq").attr("required", !0), $("#tx_IELTSscoreReq").prop("disabled", !1)
    }), $("#rbtGMATReqYes").change(function () {
        $("#tx_GMATScoreReq").attr("required", !0), $("#tx_GMATScoreReq").prop("disabled", !1)
    }), $("#rbtTOFELReqYes").change(function () {
        $("#tx_TOFELScoreReq").attr("required", !0), $("#tx_TOFELScoreReq").prop("disabled", !1)
    }), $("#rbtSATReqYes").change(function () {
        $("#tx_SATScoreReq").attr("required", !0), $("#tx_SATScoreReq").prop("disabled", !1)
    }), $("#rbtGATEReqYes").change(function () {
        $("#tx_GATEScoreReq").attr("required", !0), $("#tx_GATEScoreReq").prop("disabled", !1)
    }), $("#drpAnnualFeesCurrency").on("change", function () {
        var t = $(this).val();
        "" == t ? $(".txt-fee-currency").val("--Select--") : $(".txt-fee-currency").val(t)
    }), $("#tbodyAE").on("change", ".drpAEAditionalExam", function () {
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
    }), $("#tbodyEC").on("change", ".drpECOperator", function () {
        "Multiple OR" == $(this).find("option:selected").text() ? $("#btnAddMoreCondition").show() : ($("#tbodySubjectPercentage").find("tr.newSPTr").remove(), $("#btnAddMoreCondition").hide())
    }), $("#tbodyAE").on("change", ".drpAEOperator", function () {
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
            url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectPL",
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
    }),
        $("#drpProgramLevel").on("change", function (t) {
            $("#drpNatureofcourse").html(""), $("#drpNatureofcourse").append('<option value="">--Select--</option>');
            $("#drpBranch").html(""), $("#drpBranch").append('<option value="">-Select-</option>');
            var e = $(this).val();
            "" == $("#drpDiscipline").val() || $("#drpDiscipline").val();
            $.ajax({
                method: "POST",
                async: !1,
                url: $("#hdfBaseUrl").val() + "Institute/Courses/SelectQ",
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
        }),
        $("#drpNatureofcourse").on("change", function () {
            $(this).val();
            $.ajax({
                method: "POST",
                url: "/Institute/Courses/SelectCS",
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
        }),
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
        })
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
    }), $("#btnSaveCourse").on("click", function (i) {
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
    }), $("#tbodyCourse").on("click", ".btnGridEdit", function () {
        var t = $(this);
        $.ajax({
            method: "get",
            async: !1,
            url: "/Institute/Courses/SelectCourseOffers",
            data: {
                ID: t.attr("data-id")
            },
            success: function (t) { }
        }).done(function (t) {
            document.body.scrollTop = 0, document.documentElement.scrollTop = 0;
            var e = t.List[0];
            if ($("#divhideshow").show(), $("#hdfID").val(e.ID), $("#drpDiscipline").val(e.Discipline_ID).trigger("change"), $("#drpProgramLevel").val(e.ProgramLevel_Id).trigger("change"), $("#drpNatureofcourse").val(e.Natureofcourse_Id).trigger("change"), $("#drpBranch").val(e.Branch_Id), $("#txtEligibilityCriteria").val(e.EligibilityCriteria), $("#txttotalseats").val(e.SeatForForeignStudent), $("#txtAnnualFees").val(e.AnnualTutionFees), $("#txttotalBoarding").val(e.AnnualBoardingFees), $("#drpAnnualFeesCurrency").val(e.AnnualTutionFeesCurrency).trigger("change"), $("#drpAnnualBoardingFeesCurrency").val(e.AnnualBoardingFeesCurrency), $("#txtfeeswaiverg1").val(e.G1SeatWaiver), $("#txtfeeswaiverg2").val(e.G2SeatWaiver), $("#txtfeeswaiverg3").val(e.G3SeatWaiver), $("#txtfeeswaiverg4").val(e.G4SeatWaiver), $("#txtCredits").val(e.Credits), $("#txtcourseduration").val(e.CourseDurations), $("#txtClassrooms").val(e.ClassRoomHours), $("#drpCoursePattern").val(e.CoursePatterns), $("#txtCourseDescription").val(e.CourseDesc), $("#txtAdmission").val(e.AdmissionReq), $("#txtSAARC").val(e.FeesForSAARCCountry), $("#txtNonSAARC").val(e.FeesForNonSAARCCountry), $("#drpSAARCFeesCurrency").val(e.FeesForSAARCCountryCurrency), $("#drpNonSAARCCurrency").val(e.FeesForNonSAARCCountryCurrency), "true" == e.Q0Req.toString().toLowerCase() && ($("#cbQ0Req").trigger("click"), "10" == e.Q0Qualification.toString().toLowerCase() && ($("#txtQ0Subject").val(e.Q0Subject), $("#txtQ0Percentage").val(e.Q0Percentage))), "true" == e.Q1Req.toString().toLowerCase()) {
                $("#cbQ1Req").trigger("click"), $("#drpQ1Qualification").val("10+2/diploma" == e.Q1Qualification.toString().toLowerCase() ? "Either" : "10_2"), $("#drpQ1Qualification").trigger("change");
                var a = e.Q1Qualification.split("/");
                $.each(e.Q1Subject.split("/"), function (t, e) {
                    $("#txtQ1Subject_" + a[t].replace("+", "_")).val(e)
                }), $.each(e.Q1Percentage.split("/"), function (t, e) {
                    $("#txtQ1Percentage_" + a[t].replace("+", "_")).val(e)
                })
            }
            if ("true" == e.Q2Req.toString().toLowerCase()) {
                $("#cbQ2Req").trigger("click"), $("#drpQ2Qualification").val("ug/pg" == e.Q2Qualification.toString().toLowerCase() ? "Either" : e.Q2Qualification), $("#drpQ2Qualification").trigger("change");
                var r = e.Q2Qualification.split("/");
                $.each(e.Q2Subject.split("/"), function (t, e) {
                    $("#txtQ2Subject_" + r[t]).val(e)
                }), $.each(e.Q2Percentage.split("/"), function (t, e) {
                    $("#txtQ2Percentage_" + r[t]).val(e)
                })
            }
            if ("true" == e.Q3Req.toString().toLowerCase()) {
                $("#cbQ3Req").trigger("click"), $("#drpQ3Qualification").val("pg/mphil" == e.Q3Qualification.toString().toLowerCase() ? "Either" : e.Q3Qualification), $("#drpQ3Qualification").trigger("change");
                var i = e.Q3Qualification.split("/");
                $.each(e.Q3Subject.split("/"), function (t, e) {
                    $("#txtQ3Subject_" + i[t]).val(e)
                }), $.each(e.Q3Percentage.split("/"), function (t, e) {
                    $("#txtQ3Percentage_" + i[t]).val(e)
                })
            }
            $("Q2Req").val(e.Q2Req), $("Q3Req").val(e.Q3Req), $("Q1Qualification").val(e.Q1Qualification), $("Q1Subject").val(e.Q1Subject), $("Q1Percentage").val(e.Q1Percentage), $("Q2Qualification").val(e.Q2Qualification), $("Q2Subject").val(e.Q2Subject), $("Q2Percentage").val(e.Q2Percentage), $("Q3Qualification").val(e.Q3Qualification), $("Q3Subject").val(e.Q3Subject), $("Q3Percentage").val(e.Q3Percentage), $("").val(e.JEEMainReq), "true" == e.JEEMainReq.toString().toLowerCase() ? ($("#rbtJEEMainReqYes").trigger("click"), $("#tx_JEEMainscoreReq").val(e.JEEMainscoreReq)) : $("#rbtJEEMainReqNo").trigger("click"), "true" == e.JEEAdvanceReq.toString().toLowerCase() ? ($("#rbtJEEAdvanceReqYes").trigger("click"), $("#tx_JEEAdvanceScoreReq").val(e.JEEAdvanceScoreReq)) : $("#rbtJEEAdvanceReqNo").trigger("click"), "true" == e.IELTSReq.toString().toLowerCase() ? ($("#rbtIELTSReqYes").trigger("click"), $("#tx_IELTSscoreReq").val(e.IELTSscoreReq)) : $("#rbtIELTSReqNo").trigger("click"), "true" == e.GMATReq.toString().toLowerCase() ? ($("#rbtGMATReqYes").trigger("click"), $("#tx_GMATScoreReq").val(e.GMATScoreReq)) : $("#rbtGMATReqNo").trigger("click"), "true" == e.TOFELReq.toString().toLowerCase() ? ($("#rbtTOFELReqYes").trigger("click"), $("#tx_TOFELScoreReq").val(e.TOFELScoreReq)) : $("#rbtTOFELReqNo").trigger("click"), "true" == e.SATReq.toString().toLowerCase() ? ($("#rbtSATReqYes").trigger("click"), $("#tx_SATScoreReq").val(e.SATScoreReq)) : $("#rbtSATReqNo").trigger("click"), "true" == e.GATEReq.toString().toLowerCase() ? ($("#rbtGATEReqYes").trigger("click"), $("#tx_GATEScoreReq").val(e.GATEScoreReq)) : $("#rbtGATEReqNo").trigger("click"), "true" == e.IsGivenFromInstitute.toString().toLowerCase() ? ($("#txttotalseats").attr("readonly", !0), $("#hdfIsGivenFromInstitute").val("1")) : ($("#drpDiscipline").prop("disabled", !1), $("#drpProgramLevel").prop("disabled", !1), $("#drpNatureofcourse").prop("disabled", !1), $("#drpBranch").prop("disabled", !1), $("#txtfeeswaiverg1").attr("readonly", !1), $("#txtfeeswaiverg2").attr("readonly", !1), $("#txtfeeswaiverg3").attr("readonly", !1), $("#txtfeeswaiverg4").attr("readonly", !1), $("#txttotalseats").attr("readonly", !1), $("#txtAnnualFees").attr("readonly", !1), $("#txttotalBoarding").attr("readonly", !1), $("#txtAdmission").attr("readonly", !1), $("#drpAnnualFeesCurrency").prop("disabled", !1), $("#drpAnnualBoardingFeesCurrency").prop("disabled", !1), $("#hdfIsGivenFromInstitute").val("0")), $("#tbodyEC").find("tr.newtr").remove(), $.each(t.ListEC, function (t, e) {
                var a = $('<tr class="newtr"></tr>');
                a.append('<td data-id="' + e.EduQualifications_Id + '" data-for="' + e.EduQualificationsFor + '">' + e.EduQualifications + "</td>");
                for (var r = '<td><table class="table table-bordered"><thead><tr><th>Subject</th><th>Percentage</th></tr></thead><tbody>', i = e.EduSubject.split("|"), n = e.EduSubject_Id.split("|"), o = e.PercentageID.split("|"), d = 0; d < n.length; d++) {
                    var l = "<tr>";
                    l = (l = l + '<td data-id="' + n[d] + '">' + i[d] + "</td>") + '<td data-id="' + o[d] + '">' + o[d] + "</td>", r += l += "</tr>"
                }
                r += "</tbody></table></td>", a.append(r), a.append('<td class="tdECOperator" data-id="' + e.Operator + '">' + e.OperatorDisplay + "</td>"), a.append('<td><a class="btn btn-danger btnECDelete">X</a></td>'), a.insertBefore($("#defaultECTR"))
            }), $("#tbodyAE").find("tr.newtr").remove(), $.each(t.ListAE, function (t, e) {
                for (var a = $('<tr class="newtr"></tr>'), r = '<td><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>', i = e.AditionalExams_Id.split("|"), n = e.AditionalExams.split("|"), o = (e.AditionalExamsFor.split("|"), e.CutOff.split("|")), d = 0; d < i.length; d++) {
                    var l = "<tr>";
                    l = (l = l + '<td data-id="' + i[d] + '">' + n[d] + "</td>") + '<td data-id="' + o[d] + '">' + ("0" == o[d] && "10" != i[d] ? "No Minimum Score" : o[d]) + "</td>", r += l += "</tr>"
                }
                r += "</tbody></table></td>", a.append(r), a.append('<td class="tdAEOperator" data-id="' + e.Operator + '">' + e.OperatorDisplay + "</td>"), a.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>'), a.insertBefore($("#defaultAETR"))
            }), Check_EC(), Check_AE()
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.")
        })
    }), $("#tbodyCourse").on("click", ".btnDelete", function () {
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
                url: "/Institute/Courses/DeleteCourseOffers",
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
    }), $("#cbQ0Req").on("click", function () {
        $(this).is(":checked") ? (t = 1, $("#txtQ0Subject").prop("required", !0), $("#txtQ0Subject").removeAttr("readonly"), $("#txtQ0Percentage").prop("required", !0), $("#txtQ0Percentage").removeAttr("disabled")) : ($("#txtQ0Subject").removeProp("required", !0), $("#txtQ0Subject").attr("readonly", !0), $("#txtQ0Subject").val(""), $("#txtQ0Percentage").removeProp("required", !0), $("#txtQ0Percentage").attr("disabled", !0), $("#txtQ0Percentage").val(""))
    }), $("#cbQ1Req").on("click", function () {
        $(this).is(":checked") ? (e = 1, $("#drpQ1Qualification").prop("required", !0), $("#drpQ1Qualification").removeProp("disabled")) : ($("#drpQ1Qualification").removeProp("required", !0), $("#drpQ1Qualification").prop("disabled", !0), $("#drpQ1Qualification").val(""), $("#drpQ1Qualification").trigger("change"), $(".Q1_TXT").attr("readonly", !0), $(".Q1_TXT").attr("readonly", !0), $(".Q1_TXT").val(""))
    }), $("#cbQ2Req").on("click", function () {
        $(this).is(":checked") ? (a = 1, $("#drpQ2Qualification").prop("required", !0), $("#drpQ2Qualification").removeProp("disabled")) : ($("#drpQ2Qualification").removeProp("required", !0), $("#drpQ2Qualification").prop("disabled", !0), $("#drpQ2Qualification").val(""), $("#drpQ2Qualification").trigger("change"), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").attr("readonly", !0), $(".Q2_TXT").val(""))
    }), $("#cbQ3Req").on("click", function () {
        $(this).is(":checked") ? (r = 1, $("#drpQ3Qualification").prop("required", !0), $("#drpQ3Qualification").removeProp("disabled")) : ($("#drpQ3Qualification").removeProp("required", !0), $("#drpQ3Qualification").prop("disabled", !0), $("#drpQ3Qualification").val(""), $("#drpQ3Qualification").trigger("change"), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").attr("readonly", !0), $(".Q3_TXT").val(""))
    }), $("#btnECAdd").on("click", function (t) {
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
        $(".drpECQualification").val("").trigger("change"), $(".drpECSubject").val("").trigger("change"), $(".drpECPercentageID").val("").trigger("change"), $(".drpECOperator").val("").trigger("change"), Check_EC()
    }), $("#tbodyEC").on("click", ".btnECDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_EC()
    }), $("#tbodyEC").on("click", "#btnAddMoreCondition", function (t) {
        t.preventDefault();
        var e = $(".currentSPTr").clone();
        e.find("td:last-child").html('<a class="btn btn-sm btn-danger btnSPDelete">X</a>'), $("#tbodySubjectPercentage").append('<tr class="newSPTr">' + e.html() + "</tr>")
    }), $("#tbodyEC").on("click", ".btnSPDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_EC()
    }), $("#btnAEAdd").on("click", function (t) {
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
                l = '<td><table class="table table-bordered"><thead><tr><th>Exam</th><th>Score</th></tr></thead><tbody>';
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
        d.append('<td class="tdAEOperator" data-id="' + $(".drpAEOperator").val() + '">' + $(".drpAEOperator").find("option:selected").text() + "</td>"), d.append('<td><a class="btn btn-danger btnAEDelete">X</a></td>'), d.insertBefore(o.parent().parent()), $(".drpAEAditionalExam").val("").trigger("change"), $(".txtAECutOff").val(""), $(".drpAEOperator").val("").trigger("change"), Check_AE()
    }), $("#tbodyAE").on("click", ".btnAEDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_AE()
    }), $("#tbodyAE").on("click", "#btnAddMoreConditionAE", function (t) {
        t.preventDefault();
        var e = $(".currentAEPTr").clone();
        e.find("td:last-child").html('<a class="btn btn-sm btn-danger btnAESDelete">X</a>'), $("#tbodyAEScore").append('<tr class="newAESTr">' + e.html() + "</tr>")
    }), $("#tbodyAE").on("click", ".btnAESDelete", function (t) {
        t.preventDefault(), $(this).parent().parent().remove(), Check_AE()
    })
}

function Clear() {
    $("#frmCoursesOffer").trigger("reset"), $("#divhideshow").show(), $("#hdfID").val(0), $("#drpBranch").trigger("change"), $("#drpDiscipline").prop("disabled", !1), $("#drpProgramLevel").prop("disabled", !1), $("#drpNatureofcourse").prop("disabled", !1), $("#drpBranch").prop("disabled", !1), $("#txtfeeswaiverg1").attr("readonly", !1), $("#txtfeeswaiverg2").attr("readonly", !1), $("#txtfeeswaiverg3").attr("readonly", !1), $("#txtfeeswaiverg4").attr("readonly", !1), $("#txttotalseats").attr("readonly", !1), $("#txtAnnualFees").attr("readonly", !1), $("#txttotalBoarding").attr("readonly", !1), $("#txtAdmission").attr("readonly", !1), $("#hdfIsGivenFromInstitute").val("0"), $("#tbodyEC").find("tr.newtr").remove(), $("#tbodyAE").find("tr.newtr").remove(), $("#tdECCondition").text(""), $("#tbodySubjectPercentage").find("tr.newSPTr").remove(), $("#tbodyAEScore").find("tr.newAESTr").remove()
}

function Select_Course() {
    $("#tbodyCourse").html(""), $.ajax({
        method: "GET",
        async: !1,
        url: "/Institute/Courses/SelectCourseOffers",
        success: function (t) { }
    }).done(function (t) {
        var e = 1;
        $.each(t.List, function (t, a) {
            var r = $("<tr></tr>");
            r.append("<td>" + e++ + "</td>"), r.append("<td>" + a.ProgramLevel + "</td>"), r.append("<td>" + a.Natureofcourse + "</td>"), r.append("<td>" + a.BranchName + "</td>"), r.append("<td>" + a.SeatForForeignStudent + "</td>"), editbtn = '<button class="btn btn-success btnGridEdit" title="Edit" data-toggle="tooltip" type="button" data-id="' + a.ID + '" ><i class="glyphicon glyphicon-pencil"></i></button>', "true" == a.IsGivenFromInstitute.toString().toLowerCase() ? deletebtn = "" : deletebtn = '<a class="btn btn-danger btnDelete" title="Delete" data-toggle="tooltip" data-id="' + a.ID + '"><i class="glyphicon glyphicon-trash"></i></a>', r.append("<td>" + editbtn + "&nbsp;&nbsp;" + deletebtn + "</td>"), $("#tbodyCourse").append(r)
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
    i.length > 0 && (E += i), n.length > 0 && (E = E + (i.length > 0 ? " And " : "") + n), o.length > 0 && (E = E + (n.length > 0 ? " And " : "") + o), d.length > 0 && (E = E + (o.length > 0 ? " And " : "") + d), $("#tdECCondition").text(E)
}

function Check_AE() {
    var t = [],
        e = [];
    $("#tbodyAE").find("tr.newtr").each(function () {
        var a = $(this),
            r = a.find("td:eq(0)").attr("data-for");
        a.find("td:eq(1)").find("tbody");
        "E1" == r ? t.push({
            e: a.find("td:eq(0)").text(),
            c: a.find("td:eq(1)").text(),
            o: a.find("td:eq(2)").text()
        }) : "E2" == r && e.push({
            e: a.find("td:eq(0)").text(),
            c: a.find("td:eq(1)").text(),
            o: a.find("td:eq(2)").text()
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
    a.length > 0 && (i += a), r.length > 0 && (i = i + (a.length > 0 ? " And " : "") + r), $("#tdAECondition").text(i)
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
    return "Age Limit Date" == e ? t ? " Date of Birth must be after " + a : " Date of Birth must be after " + a + " " + r : t ? e + " with " + a + " score " : e + " with " + a + " score " + r
}

function SortECOperator(t, e) {
    return t.o == e.o ? 0 : t.o > e.o ? 1 : -1
}
$(document).ready(function () {
    page_event(), page_change(), FillConditionalDropdown()
});