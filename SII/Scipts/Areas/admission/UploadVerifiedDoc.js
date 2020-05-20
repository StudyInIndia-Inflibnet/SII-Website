$(document).ready(function () {
    page_click();
    FillPercentage();
});
function FillPercentage() {
    $(".drpPercentage").html(""), $(".drpPercentage").append('<option value="">XX</option>');
    for (var e = 35; e <= 99; e++) e < 10 ? $(".drpPercentageMainPart").append('<option value="0' + e + '">0' + e + "</option>") : $(".drpPercentageMainPart").append('<option value="' + e + '">' + e + "</option>");
    for (e = 0; e <= 99; e++) e < 10 ? $(".drpPercentageDeciamlPart").append('<option value="0' + e + '">0' + e + "</option>") : $(".drpPercentageDeciamlPart").append('<option value="' + e + '">' + e + "</option>")
}

function page_click() {
    $("#tbody").on("click", ".btn-upload-doc", function (e) {
        e.preventDefault();
        var a = $(this),
            r = a.attr("data-id"),
            docid = a.attr("data-docid"),
            s = a.attr("data-for"),
            t = $("#frm" + s + "_" + r);
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var i = a.html();
        if (a.hasClass("disabled")) return !1;
        a.text("Processing....."), a.attr("disabled", !0), a.addClass("disabled");
        var o = $("#fuDoc" + s + "_" + r).get(0);
        if (void 0 !== window.FormData && $("#fuDoc" + s + "_" + r).get(0).files.length > 0) {
            var l = $("#fuDoc" + s + "_" + r).get(0).files[0].size,
                d = ["pdf", "jpeg", "jpg"];
            if (-1 == $.inArray($("#fuDoc" + s + "_" + r).val().split(".").pop().toLowerCase(), d)) return void ErrorMessageCallBack("Only formats are allowed : " + d.join(", "), function () {
                a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")
            });
            if (!("2097152" >= l)) return void ErrorMessageCallBack("Only 2 Mb file size allow!", function () {
                a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")
            })
        }
        for (var n = o.files, c = new FormData, f = 0; f < n.length; f++) c.append(n[f].name, n[f]);
        c.append("id", r);
        c.append('docid', docid);
        c.append("name", a.parent().parent().parent().find("td:eq(0)").find('.lblFileName').text());
        c.append("MainPart", a.parent().parent().parent().find("td:eq(0)").find('.drpPercentageMainPart').text());
        c.append("DeciamlPart", a.parent().parent().parent().find("td:eq(0)").find('.drpPercentageDeciamlPart').text());
        c.append("Score", a.parent().parent().parent().find("td:eq(0)").find('.drpAEScore').text());
        c.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]', t).val());
        $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "admission/Dashboard/UploadDocs",
            data: c,
            async: !1,
            cache: !1,
            contentType: !1,
            processData: !1
        }).done(function (e) {
            "success" == e.c ? SuccessMessageCallBack(e.m, function () {
                $("#td" + s + "_" + r).html('<a class="label label-success" href="' + $("#hdfBaseUrl").val() + e.p + '" target="_blank"><i class="fa fa-download"></i> View</a>'), $("#hdf" + s + "_" + r).val(e.p), a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")
            }, function () {
                a.text(i), a.removeAttr("disabled"), a.removeClass("disabled")
            }) : "alreadyexists" == e.c ? (ErrorMessage(e.m), a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")) : "sessionexpired" == e.c ? (ErrorMessage(e.m), a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")) : "servererror" == e.c ? (ErrorMessage(e.m), a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")) : "DSPClosed" == e.c && ErrorMessageCallBack(e.m, function () {
                window.location.href = $("#hdfBaseUrl").val() + "admission/Dashboard"
            })
        }).error(function () {
            ErrorMessage("Processing error. Kindly refresh page and try again!"), a.html(i), a.removeAttr("disabled"), a.removeClass("disabled")
        })
    });
}