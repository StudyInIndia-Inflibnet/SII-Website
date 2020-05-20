var forminuse = !1;

function page_init() {
    FillPercentage(), fill_form(), page_click(), page_change()
}

function page_change() {
    $(".drpPercentage").on("change", function () {
        var e = $(this).parent().parent().parent().attr("data-id");
        $("#lblEC" + e).text(("" == $("#drpMain" + e).val() ? "00" : $("#drpMain" + e).val()) + "." + ("" == $("#drpDecimal" + e).val() ? "00" : $("#drpDecimal" + e).val()) + " %")
    })
}

function page_click() {
    $(".chkYesEQ").on("click", function (e) {
        var val = $(this).val();
        var name = $(this).prop("name");
        var a = name.replace("Is", "drp"),
            r = $("." + a);
        r.removeAttr("disabled"), r.attr("required", !0), $("#lbl11th").hide()
        if (val == '2') {
            $('#' + name.replace("Is", "lblResultAwaited")).show();
        } else {
            $('#' + name.replace("Is", "lblResultAwaited")).hide();
        }
    }),
        $(".chkNoEQ").on("click", function (e) {
            var a = $(this).prop("name").replace("Is", "drp"),
                r = $("." + a);
            r.val("").trigger("change"), r.removeAttr("required"), r.attr("disabled", !0), $("#lbl11th").hide();
            $('#' + $(this).prop("name").replace("Is", "lblResultAwaited")).hide();
        }),
        $("#rbRAEQ2").on("click", function (e) {
            $("#lbl11th").show()
        }),
        $(".chkYes").on("click", function (e) {
            var val = $(this).val();
            var name = $(this).prop("name");
            var a = $(this).prop("name").replace("Is", "txt"),
                r = $("#" + a);
            r.removeAttr("disabled"), r.attr("required", !0)
            if (val == '2') {
                $('#' + name.replace("Is", "lblResultAwaited")).show();
            } else {
                $('#' + name.replace("Is", "lblResultAwaited")).hide();
            }
        }),
        $(".chkNo").on("click", function (e) {
            var a = $(this).prop("name").replace("Is", "txt"),
                r = $("#" + a);
            r.val("").trigger("change"), r.removeAttr("required"), r.attr("disabled", !0);
            $('#' + $(this).prop("name").replace("Is", "lblResultAwaited")).hide();
        }),
        $("#btnSave").on("click", function (e) {
            e.preventDefault();
            var a = $(this),
                r = a.text();
            form_save($(this), function () {
                a.text(r), a.removeAttr("disabled"), a.removeClass("disabled")
            })
        }),
        $("#btnSaveAndContinue").on("click", function (e) {
            e.preventDefault();
            var a = $(this);
            form_save($(this), function () {
                a.text("Redirecting..."), window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectDisciplines"
            })
        })
}

function form_save(e, a) {
    var r = $("#frm"),
        t = $('input[name="__RequestVerificationToken"]', r).val();
    if (r.parsley().validate(), !r.parsley().isValid()) return !1;
    if (forminuse) return !1;
    var i = e.text();
    if (e.hasClass("disabled")) return !1;
    var EQ = GET_EQ();
    var aEQ = [];
    $.each(EQ, function (i, item) {
        aEQ.push(item['EQID']);
    });
    var flag = true;
    $.each(EQ, function (i, item) {
        if (item['EQID'] != '') {
            var a1 = item['EQD'].split(',');
            $.each(a1, function (i2, item2) {
                if (item2 != '') {
                    var flag2 = false;
                    var a2 = item2.split('|');
                    $.each(a2, function (i3, item3) {
                        if (aEQ.indexOf(item3) >= 0) {
                            flag2 = true;
                        }
                    });
                    if (!flag2) {
                        flag = false;
                    }
                }
            });
        }
    });
    if (!flag) {
        ErrorMessage('Kinldy add all relevant qualification\'s score first.');
        e.text(i), e.removeAttr("disabled"), e.removeClass("disabled");
        return !1;
    }
    e.text("Processing....."); e.attr("disabled", !0); e.addClass("disabled"); forminuse = !0;
    $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/CheckBasic",
        data: {
            __RequestVerificationToken: t,
            EduQualifications: JSON.stringify(GET_EQ()),
            AdditionalExams: GET_AE()
        }
    }).done(function (r) {
        if ("success" == r.c) {
            save_form(e, a);
        } else if ("changes" == r.c) {
            ConfirmCallBack(r.m, function () {
                $.ajax({
                    method: "POST",
                    async: false,
                    url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/ResetChoiceFilling",
                    data: {
                        __RequestVerificationToken: t,
                        EduQualifications: JSON.stringify(GET_EQ()),
                        AdditionalExams: GET_AE()
                    }
                }).done(function (data) {
                    if (data['c'] == 'success') {
                        save_form(e, a);
                    }
                }).error(function () {
                    ErrorMessage("Processing error. Kindly refresh page and try again!"), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"), forminuse = !1
                });
            });
            e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"), forminuse = !1
        } else {
            ErrorMessage(r.m), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled")
        }
    }).error(function () {
        -("Processing error. Kindly refresh page and try again!"), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"), forminuse = !1
    });

}

function save_form(e, a) {
    var r = $("#frm"),
        t = $('input[name="__RequestVerificationToken"]', r).val();
    var i = e.text();
    var EQ = GET_EQ();
    var aEQ = [];
    $.each(EQ, function (i, item) {
        aEQ.push(item['EQID']);
    });
    var flag = true;
    $.each(EQ, function (i, item) {
        if (item['EQID'] != '') {
            var a1 = item['EQD'].split(',');
            $.each(a1, function (i2, item2) {
                if (item2 != '') {
                    var flag2 = false;
                    var a2 = item2.split('|');
                    $.each(a2, function (i3, item3) {
                        if (aEQ.indexOf(item3) >= 0) {
                            flag2 = true;
                        }
                    });
                    if (!flag2) {
                        flag = false;
                    }
                }
            });
        }
    });
    if (!flag) {
        ErrorMessage('Kinldy add all relevant qualification\'s score first.');
        e.text(i), e.removeAttr("disabled"), e.removeClass("disabled");
        return !1;
    }
    $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SaveBasic",
        data: {
            __RequestVerificationToken: t,
            EduQualifications: JSON.stringify(EQ),
            AdditionalExams: GET_AE()
        }
    }).done(function (r) {
        "success" == r.c ?
            SuccessMessageCallBackWithClose(r.m, a, function () {
                e.text(i), e.removeAttr("disabled"), e.removeClass("disabled")
            })
            :
            "alreadyexists" == r.c ?
                (ErrorMessage(r.m), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"))
                :
                "sessionexpired" == r.c ?
                    (ErrorMessage(r.m), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"))
                    :
                    "servererror" == r.c ?
                        (ErrorMessage(r.m), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"))
                        :
                        "ChoiceFillingClosed" == r.c && ErrorMessageCallBack(r.m, function () {
                            window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/Closed"
                        }), forminuse = !1
    }).error(function () {
        ErrorMessage("Processing error. Kindly refresh page and try again!"), e.text(i), e.removeAttr("disabled"), e.removeClass("disabled"), forminuse = !1
    });
}

function FillPercentage() {
    $(".drpPercentage").html(""), $(".drpPercentage").append('<option value="">XX</option>');
    for (var e = 35; e <= 99; e++) e < 10 ? $(".drpPercentageMainPart").append('<option value="0' + e + '">0' + e + "</option>") : $(".drpPercentageMainPart").append('<option value="' + e + '">' + e + "</option>");
    for (e = 0; e <= 99; e++) e < 10 ? $(".drpPercentageDeciamlPart").append('<option value="0' + e + '">0' + e + "</option>") : $(".drpPercentageDeciamlPart").append('<option value="' + e + '">' + e + "</option>")
}

function fill_form() {
    $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SelectBasic"
    }).done(function (e) {
        $.each(e.List, function (e, a) { }), $.each(e.ListEC, function (e, a) {
            "1" == a.IsGiven ? ($("#rbYesEQ" + a.EQID).trigger("click"), $("#drpMain" + a.EQID).val(a.MainPart).trigger("change"), $("#drpDecimal" + a.EQID).val(a.DeciamlPart).trigger("change")) : "2" == a.IsGiven ? ($("#rbRAEQ" + a.EQID).trigger("click"), $("#drpMain" + a.EQID).val("0" != a.MainPart ? a.MainPart : "").trigger("change"), $("#drpDecimal" + a.EQID).val("0" != a.DeciamlPart ? a.DeciamlPart : "").trigger("change")) : ($("#rbNoEQ" + a.EQID).trigger("click"), $("#drpMain" + a.EQID).val("").trigger("change"), $("#drpDecimal" + a.EQID).val("").trigger("change"))
        }), $.each(e.ListAE, function (e, a) {
            if ("1" == a.IsGiven)
                $("#rbYesAE" + a.AEID).trigger("click"), $("#txtAE" + a.AEID).val(a.Score)
            else if ("2" == a.IsGiven)
                $("#rbRAAE" + a.AEID).trigger("click"), $("#txtAE" + a.AEID).val(a.Score)
            else
                $("#rbNoAE" + a.AEID).trigger("click"), $("#txtAE" + a.AEID).val(a.Score)
        })
    }).error(function () {
        ErrorMessage("Processing error. Kindly refresh page and try again!"), btn.text(oldText), btn.removeAttr("disabled"), btn.removeClass("disabled")
    })
}

function GET_EQ() {
    var e = [];
    return $(".listEQ").each(function () {
        var a = $(this);
        if ("10th" == a.attr("data-for")) e.push({
            EQName: a.attr("data-for"),
            EQID: a.attr("data-id"),
            IsGiven: "1",
            MainPart: a.find(".drpPercentageMainPart").val(),
            DeciamlPart: a.find(".drpPercentageDeciamlPart").val(),
            EQD: '',
        });
        else {
            var r = a.find(".chkYesEQ").attr("name"),
                t = $("input[name='" + r + "']:checked").val(),
                i = a.find(".drpPercentageMainPart").val(),
                n = a.find(".drpPercentageDeciamlPart").val();
            if ("1" == t) e.push({
                EQName: a.attr("data-for"),
                EQID: a.attr("data-id"),
                IsGiven: t,
                MainPart: i,
                DeciamlPart: n,
                EQD: a.attr('data-EQD')
            });
            else if ("2" == t) {
                var l = a.attr("data-for");
                //"10+2" == l && (l = "11th"),
                e.push({
                    EQName: l,
                    EQID: a.attr("data-id"),
                    IsGiven: t,
                    MainPart: "" == i ? "0" : i,
                    DeciamlPart: "" == n ? "0" : n,
                    EQD: a.attr('data-EQD')
                })
            }
        }
    }), e
}

function GET_AE() {
    var e = [];
    return $(".listAE").each(function () {
        var a = $(this),
            r = a.find(".chkYes").attr("name"),
            t = $("input[name='" + r + "']:checked").val(),
            i = a.find(".drpAEScore").val();
        if ("1" == t) e.push({
            AEName: a.attr("data-for"),
            AEID: a.attr("data-id"),
            IsGiven: t,
            Score: i
        });
        else if ("2" == t) e.push({
            AEName: a.attr("data-for"),
            AEID: a.attr("data-id"),
            IsGiven: t,
            Score: i
        });
    }), JSON.stringify(e)
}

$(document).ready(function () {
    page_init()
});