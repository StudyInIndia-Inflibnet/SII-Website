window.dataLayer = window.dataLayer || [];
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'UA-118738693-1');
$(document).ready(function () {

});
function SubmitOnEnter(searchBox, event) {
    var keyCode;
    if (window.event) {
        keyCode = window.event.keyCode;
    }
    else if (event) {
        keyCode = event.which;
    }
    else {
        return true;
    }
    if (keyCode == 13) {
        // This is for Enter Key
        SiteSearch();
        return false;
    }
    else {
        return true;
    }
}
function SiteSearch() {
    document.location.href = "/Search/Index?id=" +
        EncodeText(document.getElementById('q').value); // Here we should use url encode for the user input
}
function EncodeText(value) {
    var returnValue = "";
    var x = 0;
    var regex = /(^[a-zA-Z0-9_.]*)/
    while (x < value.toString().length) {
        var match = regex.exec(value.substr(x));
        if (match != null && match.length > 1 && match[1] != '') {
            returnValue += match[1];
            x += match[1].length;
        }
        else {
            if (value[x] == ' ') {
                returnValue += '+';
            }
            else {
                var charCode = value.charCodeAt(x);
                var haxValue = charCode.toString(16);
                returnValue += "%" + (haxValue.length < 2 ? '0' : '') + haxValue.toUpperCase();
            }
            x++;
        }
    }
    return returnValue;
}