var forminuse = !1;

function page_click() {
    $("#tbody").on("click", ".btn-upload-doc", function (e) {
        e.preventDefault();
        var a = $(this),
            r = a.attr("data-id"),
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
        var nametext = a.parent().parent().parent().find("td:eq(0)").text();
        nametext = nametext.replace('(Upload all mark sheets/transcripts till last exam cycle)','');
        c.append("id", r), c.append("name", nametext), c.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]', t).val()), $.ajax({
            method: "POST",
            url: $("#hdfBaseUrl").val() + "Admin/Upload/UploadDocs",
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
    $("#btnSave").on("click", function (e) {
        e.preventDefault();
        var a = $(this),
            r = a.text();
        form_save($(this), function () {
            a.text(r), a.removeAttr("disabled"), a.removeClass("disabled")
        })
    });
}

function form_save(e, a) {
    var r = $("#frm"),
        s = $('input[name="__RequestVerificationToken"]', r).val();
    if (r.parsley().validate(), !r.parsley().isValid()) return !1;
    if (forminuse) return !1;
    var t = e.text();
    if (e.hasClass("disabled")) return !1;
    var i = !0,
        o = [];
    if ($("#tbody").find("tr").each(function (e) {
        var a = $(this),
            r = a.find(".doc_path").val(),
            s = a.attr("data-id"),
            t = a.find("td:eq(0)").text(),
            l = a.find(".btn-upload-doc").attr("data-for");
        "" == r && (i = !1), o.push({
            EQ_AE_Name: t,
            EQ_AE_ID: s,
            Path: r,
            EQ_AE_For: l
        })
    }), !i) return ErrorMessage("Kindly upload all documents."), !1;
    e.text("Processing....."), e.attr("disabled", !0), e.addClass("disabled"), forminuse = !0, $.ajax({
        method: "POST",
        url: $("#hdfBaseUrl").val() + "Admin/Upload/SaveUploadDocs",
        data: {
            __RequestVerificationToken: s,
            Docs: JSON.stringify(o)
        }
    }).done(function (r) {
        "success" == r.c ? SuccessMessageCallBack(r.m, a, function () {
            e.text(t), e.removeAttr("disabled"), e.removeClass("disabled")
        }) : "alreadyexists" == r.c ? (ErrorMessage(r.m), e.text(t), e.removeAttr("disabled"), e.removeClass("disabled")) : "sessionexpired" == r.c ? (ErrorMessage(r.m), e.text(t), e.removeAttr("disabled"), e.removeClass("disabled")) : "servererror" == r.c ? (ErrorMessage(r.m), e.text(t), e.removeAttr("disabled"), e.removeClass("disabled")) : "ChoiceFillingClosed" == r.c && ErrorMessageCallBack(r.m, function () {
            window.location.href = $("#hdfBaseUrl").val() + "Admin/Upload/Closed"
        }), forminuse = !1
    }).error(function () {
        ErrorMessage("Processing error. Kindly refresh page and try again!"), e.text(t), e.removeAttr("disabled"), e.removeClass("disabled"), forminuse = !1
    })
}
$(document).ready(function () {
    page_click()
});