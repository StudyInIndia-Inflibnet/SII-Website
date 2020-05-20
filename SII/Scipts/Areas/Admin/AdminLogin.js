function page_click_events() {
    $("#btnLogin").on("click", function (e) {
        e.preventDefault();
        var a = $("#frmLogin");
        if (a.parsley().validate(), !a.parsley().isValid()) return !1;
        var r = $(this);
        r.text("Processing..."), r.addClass("disabled"), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/Login/CheckLogin",
            data: a.serialize()
        }).done(function (e) {
            "true" == e.flagCaptcha.toString().toLowerCase() ? "true" == e.flagValidID.toString().toLowerCase() ? "true" == e.flagLogin.toString().toLowerCase() ? (r.text("Redirecting..."), window.location.href = $("#hdfBaseUrl").val() + "Admin/ParticipationYears") : (swal("", "Invalid Password.", "error"), r.text("Login"), r.removeClass("disabled")) : (swal("", "Invalid Username.", "error"), r.text("Login"), r.removeClass("disabled")) : (swal("", "Invalid captcha entered.", "error"), $("#btnRefreshCaptcha").trigger("click"), $("#txtCaptcha").val(""))
        }).error(function () {
            r.text("Login"), r.removeClass("disabled"), swal("", "Somthing went wrong. Please try again.", "error")
        })
    })
}
$(document).ready(function () {
    page_click_events()
});