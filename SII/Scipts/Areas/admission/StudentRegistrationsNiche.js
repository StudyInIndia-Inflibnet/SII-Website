function page_change() {
    $(".datetimepicker").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: "1960:" + ((new Date).getFullYear() - 14),
        todayHighlight: !1,
        changeMonth: !0,
        changeYear: !0,
        onSelect: function (e) {
            var t = e.split("-"),
                a = t[1] + "-" + t[0] + "-" + t[2],
                r = new Date("2018-01-01"),
                n = (new Date(r.getYear(), r.getMonth(), r.getDate()), r.getYear()),
                i = r.getMonth(),
                o = r.getDate(),
                s = new Date(a.substring(6, 10), a.substring(0, 2) - 1, a.substring(3, 5)),
                l = s.getYear(),
                g = s.getMonth(),
                c = s.getDate();
            if (yearAge = n - l, i >= g) var d = i - g;
            else {
                yearAge--;
                d = 12 + i - g
            }
            if (o >= c) var u = o - c;
            else {
                u = 31 + o - c;
                --d < 0 && (d = 11, yearAge--)
            }
            yearAge, $("#txtYear").val(yearAge)
        }
    })
}

function page_click_events() {
    $("#btnRefreshCaptcha").on("click", function (e) {
        e.preventDefault(), $("#imgLoginCaptcha").removeAttr("src"), $("#imgLoginCaptcha").removeAttr("value"), $("#imgLoginCaptcha").attr("src", $("#hdfBaseUrl").val() + "Captcha/GetCaptchaImage?" + (new Date).getTime()), $("#imgLoginCaptcha").attr("value", "")
    }),
        $("#btnRegister").on("click", function (e) {
            e.preventDefault();
            var t = $("#frmRegistration");
            var id = t.find(("#NicheCourseID")).val();
            var instituteid = t.find(("#instituteid")).val();
            if (t.parsley().validate(), !t.parsley().isValid()) return !1;
            if (parseInt($("#txtYear").val()) < 15) return swal("Error", "Age should be more than 15 years.", "error"), !1;
            var a = $(this);
            a.text("Processing..."), a.addClass("disabled"), $.ajax({
                method: "POST",
                url: "/admission/RegistrationsNiche/RegistationUser",
                data: t.serialize(),
                success: function (e) { }
            }).done(function (e) {
                "true" == e.flagCaptcha.toString().toLowerCase() ? "true" != e.flagDOB.toString().toLowerCase() ? (swal("Warning!", "Invalid Date Of Birth"), a.text("Sign Up"), a.removeClass("disabled")) : "true" == e.flagValidID.toString().toLowerCase() ? (a.text("Sign Up"), a.removeClass("disabled"), swal({
                    title: "Registration Successfully.",
                    html: "Your Registration is successfully done.</br><br>  Your Student id is <strong> " + e.Studentid.toString() + " </strong>. </br></br> <br><br>Now onwards you can use student-Id and Mobile for applying to any NICHE courses.</br></br>  ",
                    type: "success",
                    closeOnConfirm: !0,
                    confirmButtonText: "OK",
                    confirmButtonClass: "btn-primary",
                    showLoaderOnConfirm: !0
                }).then(function () {
                    window.location.href = "/admission/RegistrationsNiche/ThankYou?NicheCourseId=" + id + "&instituteid=" + instituteid + "";
                }), clear()) : (swal("Warning!", "Email/Mobile already registered"), a.text("Sign Up"), a.removeClass("disabled")) : (a.text("Sign Up"), a.removeClass("disabled"), swal("Invalid captcha", "Invalid captcha entered.", "error"))
            }).error(function () {
                a.text("Sign Up"), a.removeClass("disabled"), swal("", "Somthing went wrong. Please try again.", "error")
            })
        })

    $("#btnlogin").on("click", function (e) {
        e.preventDefault();
        var t = $("#frmLogin");
        var id = t.find(("#NicheCourseID")).val();
        var instituteid = t.find(("#instituteid")).val();
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var a = $(this);
        a.text("Processing..."), a.addClass("disabled"), $.ajax({
            method: "POST",
            url: "/admission/RegistrationsNiche/RegistationUserForCourse",
            data: t.serialize(),
            success: function (e) { }
        }).done(function (e) {
            //"true" == e.flagCaptcha.toString().toLowerCase() ? "true" != e.flagDOB.toString().toLowerCase() ?
            //    (swal("Warning!", "Invalid Date Of Birth"), a.text("Sign Up"), a.removeClass("disabled")) : "true" == e.flagValidID.toString().toLowerCase() ? (a.text("Sign Up"), a.removeClass("disabled"),
            if (e.flagValidID.toString().toLowerCase() == "true") {
                if (e.flagValidCourse.toString().toLowerCase() == "true") {
                    swal({
                        title: "Applied Successfully.",
                        html: "You successfully applied for the  <strong>" + e.CourseType.toString() + "</strong> Course, in <strong>  " + e.Institute.toString() + " . </strong>",
                        type: "success",
                        closeOnConfirm: !0,
                        confirmButtonText: "OK",
                        confirmButtonClass: "btn-primary",
                        showLoaderOnConfirm: !0,
                    }).then(function () {
                        a.text("Login and Apply");
                        a.removeClass("disabled");
                        $("#txtStdid").val("");
                        $("#txtmobile").val("");
                        window.location.href = "/admission/RegistrationsNiche/ThankYou?NicheCourseId=" + id + "&instituteid=" + instituteid + "";
                    }),
                        clear();
                }
                else {
                    swal("Warning!", "Alredy Applied for this Course.");
                    a.text("Login and Apply");
                    a.removeClass("disabled");
                }
            }
            else {
                swal("Warning!", "Please enter valid Student-Id and Mobile number.");
                a.text("Login and Apply");
                a.removeClass("disabled");
            }

        })
    });
}

$(document).ready(function () {
    page_change(), page_click_events()
});