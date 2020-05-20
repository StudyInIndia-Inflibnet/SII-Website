function page_events() {
    page_click_events()
}

function page_click_events() {
    $("#btnForgotPassword").on("click", function (e) {
        e.preventDefault();
        var t = $("#frmForgotPass");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var a = $(this);
        a.text("Processing..."), a.addClass("disabled"), $.ajax({
            method: "POST",
            url: "/admission/forgotPassword/ForgotPassword",
            data: t.serialize() + "&Captchastr=" + $("#txtCaptcha").val()
        }).done(function (e) {
            "true" == e.flagCaptcha.toString().toLowerCase() ? "1" == e.flag.toString().toLowerCase() ? (swal({
                title: "Password Sent",
                text: "New password has been sent to <b>" + $("#username").val() + "</b> successfully. Please check email.",
                type: "success",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                window.location.href = "/admission/Login"
            }), a.text("Reset"), a.removeClass("disabled")) : "2" == e.flag.toString().toLowerCase() ? (swal({
                title: "Old Registration",
                text: "Please Register again.",
                type: "warning",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                window.location.href = "/admission/Registrations"
            }), a.text("Reset"), a.removeClass("disabled")) :
                    (
                        $.confirm({
                            title: 'Confirm!',
                            content: "Your email id is not registered for current phase. Do you want to register?",
                            backgroundDismiss: false,
                            boxWidth: '500px',
                            useBootstrap: false,
                            backgroundDismissAnimation: 'shake',
                            type: 'gray',
                            buttons: {
                                yes: {
                                    btnClass: 'btn-primary',
                                    action: function () {
                                        window.location.href ='/admission/Registrations';
                                    }
                                },
                                no: {
                                    btnClass: 'btn-primary',
                                    action: function () {
                                        window.location.href = '/';
                                    }
                                }
                            }
                        }), a.text("Reset"), a.removeClass("disabled")
                        //swal("Invalid Username", "Please enter your registered email for Current Phase.", "warning"), a.text("Reset"), a.removeClass("disabled")
                    )
                :
                (swal("Invalid captcha entered", "Please enter valid Captcha.", "error"), a.text("Reset"), a.removeClass("disabled"))
        }).error(function () {
            a.text("Reset"), a.removeClass("disabled"), swal("", "Somthing went wrong. Please try again.", "error"), $("#btnRefreshCaptcha").trigger("click"), $("#txtCaptcha").val("")
        })
    })
}
$(document).ready(function () {
    $("#btnRefreshCaptcha").show(), page_events()
});