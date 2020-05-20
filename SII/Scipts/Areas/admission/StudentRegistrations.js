function page_change() {
    //$(".datetimepicker").datepicker({
    //    orientation: "left",
    //    autoclose: !0,
    //    dateFormat: "dd-mm-yy",
    //    yearRange: "1960:" + ((new Date).getFullYear() - 14),
    //    todayHighlight: !1,
    //    changeMonth: !0,
    //    changeYear: !0,
    //    onSelect: function (e) {
    //        var t = e.split("-"),
    //            a = t[1] + "-" + t[0] + "-" + t[2],
    //            r = new Date("2018-01-01"),
    //            n = (new Date(r.getYear(), r.getMonth(), r.getDate()), r.getYear()),
    //            i = r.getMonth(),
    //            o = r.getDate(),
    //            s = new Date(a.substring(6, 10), a.substring(0, 2) - 1, a.substring(3, 5)),
    //            l = s.getYear(),
    //            g = s.getMonth(),
    //            c = s.getDate();
    //        if (yearAge = n - l, i >= g) var d = i - g;
    //        else {
    //            yearAge--;
    //            d = 12 + i - g
    //        }
    //        if (o >= c) var u = o - c;
    //        else {
    //            u = 31 + o - c;
    //            --d < 0 && (d = 11, yearAge--)
    //        }
    //        yearAge, $("#txtYear").val(yearAge)
    //    }
    //})
}

function page_click_events() {
    $("#btnRefreshCaptcha").on("click", function (e) {
        e.preventDefault(), $("#imgLoginCaptcha").removeAttr("src"), $("#imgLoginCaptcha").removeAttr("value"), $("#imgLoginCaptcha").attr("src", $("#hdfBaseUrl").val() + "Captcha/GetCaptchaImage?" + (new Date).getTime()), $("#imgLoginCaptcha").attr("value", "")
    });
    $('#IAccept').on('click', function () {
        if (!$(this).is(':checked')) {
            $('#btnRegister').addClass('disabled').attr('disabled');
        } else {
            $('#btnRegister').removeClass('disabled').removeAttr('disabled');
        }
    });
    $("#btnRegister").on("click", function (e) {
        e.preventDefault();
        if (!$('#IAccept').is(':checked')) {
            swal("Error", "Please accept the privacy policy to finish registration.")
            return false;
        }
        var t = $("#frmRegistration");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        if (parseInt($("#txtYear").val()) < 15) return swal("Error", "Age should be more than 15 years.", "error"), !1;
        var a = $(this);
        
        var whatsapp_consent = 0;
        if ($('#whatsapp_consent').is(':checked')) {
            whatsapp_consent = 1;
        }
        a.text("Processing..."), a.addClass("disabled"), a.attr('disabled', true), $.ajax({
            method: "POST",
            url: "/admission/Registrations/RegistationUser",
            data: t.serialize() + '&whatsapp_consent=' + whatsapp_consent,
            success: function (e) { }
        }).done(function (e) {
            "true" == e.flagCaptcha.toString().toLowerCase() ? "true" != e.flagDOB.toString().toLowerCase() ? (swal("Warning!", "Invalid Date Of Birth"), a.text("Register"), a.removeClass("disabled"), a.removeAttr('disabled')) : "true" == e.flagValidID.toString().toLowerCase() ? (a.text("Register"), a.removeClass("disabled"), a.removeAttr('disabled'), swal({
                title: "Registration Successfully.",
                text: "Thank you for registering at Study in India portal. You will receive an email at <b>" + $("#txtemailreg").val() + "</b> with your credentials ",
                type: "success",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                window.location.href = "/admission/Registrations/ThankYou"
            })) : (swal("Warning!", "Email/Mobile already registered"), a.text("Register"), a.removeClass("disabled"), a.removeAttr('disabled')) : (a.text("Register"), a.removeClass("disabled"), swal("Invalid captcha", "Invalid captcha entered.", "error"))
        }).error(function () {
            a.text("Sign Up"), a.removeClass("disabled"), a.removeAttr('disabled'), swal("", "Somthing went wrong. Please try again.", "error")
        })
    })
}

$(document).ready(function () {
    page_change(), page_click_events();
    $(".collapse.in").each(function () {
        $(this)
            .siblings(".panel-heading")
            .find(".fa")
            .addClass("rotate");
    });
    $(".collapse")
        .on("show.bs.collapse", function () {
            $(this)
                .parent()
                .find(".fa")
                .addClass("rotate");
        })
        .on("hide.bs.collapse", function () {
            $(this)
                .parent()
                .find(".fa")
                .removeClass("rotate");
        });
});