$(document).ready(function () {
    App.init();
    $('.allow_only_number').keypress(function (e) {
        return isNumber(e, this);
    });
    $('.allow_only_decimal').keypress(function (e) {
        return isNumberWithDot(e, this);
    });
    $('.allow_only_alphabet').keypress(function (e) {
        return isAlphabet(e, this);
    });
    $('.allow_only_alphanumeric').keypress(function (e) {
        return isAlphaNumeric(e, this);
    });
    $('#btnRefreshCaptcha').on('click', function (e) {
        e.preventDefault();
        $('#imgLoginCaptcha').removeAttr('src');
        $('#imgLoginCaptcha').removeAttr('value');
        $('#imgLoginCaptcha').attr('src', '@Url.Content("~/")Captcha/GetCaptchaImage?' + new Date().getTime());
        $('#imgLoginCaptcha').attr('value', '');
    });
});
function isNumber(evt, element) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (
        //(charCode != 45 || $(element).val().indexOf('-') != -1) &&      // &#8220;-&#8221; CHECK MINUS, AND ONLY ONE.
        //(charCode != 46 || $(element).val().indexOf('.') != -1) &&  && charCode == 9 && charCode == 13    // &#8220;.&#8221; CHECK DOT, AND ONLY ONE.
        ((charCode < 48 || charCode > 57) && charCode != 8 && charCode != 9 && charCode != 13))
        return false;
    return true;
}

function isNumberWithDot(evt, element) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (
        //(charCode != 45 || $(element).val().indexOf('-') != -1) &&      // &#8220;-&#8221; CHECK MINUS, AND ONLY ONE.
        (charCode != 46 || $(element).val().indexOf('.') != -1) && ((charCode < 48 || charCode > 57) && charCode != 8 && charCode != 9 && charCode != 13))
        return false;
    return true;
}

function isAlphabet(evt, element) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (
        //(charCode != 45 || $(element).val().indexOf('-') != -1) &&      // &#8220;-&#8221; CHECK MINUS, AND ONLY ONE.
        //(charCode != 46 || $(element).val().indexOf('.') != -1) &&  && charCode == 9 && charCode == 13    // &#8220;.&#8221; CHECK DOT, AND ONLY ONE.
        (((charCode < 65 || charCode > 122)) && charCode != 8 && charCode != 32))
        return false;
    return true;
}
function isAlphaNumeric(evt, element) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (
        //(charCode != 45 || $(element).val().indexOf('-') != -1) &&      // &#8220;-&#8221; CHECK MINUS, AND ONLY ONE.
        //(charCode != 46 || $(element).val().indexOf('.') != -1) &&  && charCode == 9 && charCode == 13    // &#8220;.&#8221; CHECK DOT, AND ONLY ONE.
        (((charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 122)) && charCode != 8 && charCode != 32 && charCode != 9 && charCode != 13))
        return false;
    return true;
}