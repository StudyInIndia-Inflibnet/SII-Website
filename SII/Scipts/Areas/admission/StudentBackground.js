function page_event() {
    page_change(), page_click(), EditSelectBackData()
}

function page_change() {
    $(".datetimepicker").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: (new Date).getFullYear() + ":" + ((new Date).getFullYear() + 10),
        todayHighlight: !1,
        changeMonth: !0,
        minDate: new Date,
        changeYear: !0
    }), $("#rad7").on("click", function () {
        $("#divpassportno").show(), $("#divpassport").hide(), $("#txtpassportname").removeAttr("required"), $("#txtpassspoernumber").removeAttr("required"), $("#txtpasssportexpirydate").removeAttr("required"), $("#drpCountryBackground").removeAttr("required"), $("#txtpassportname").val(""), $("#txtpassspoernumber").val(""), $("#txtIssuingAuthority").val(""), $("#txtpasssportexpirydate").val(""), $("#drpCountryBackground").val("")
    }), $("#rad6").on("click", function () {
        $("#divpassportno").hide(), $("#divpassport").show(), $("#txtpassportname").attr("required", !0), $("#txtpassspoernumber").attr("required", !0), $("#txtpasssportexpirydate").attr("required", !0), $("#drpCountryBackground").attr("required", !0)
    }), $("#rad8").on("click", function () {
        $("#divPassportFileReferenceNumber").show(), $("#txtPassportFileReferenceNumber").attr("required", !0)
    }), $("#rad9").on("click", function () {
        $("#divPassportFileReferenceNumber").hide(), $("#txtPassportFileReferenceNumber").removeAttr("required"), $("#txtPassportFileReferenceNumber").val("")
    }), $("#CitizenshipNumberYes").on("click", function () {
        $("#divCitizenshipNumber").show(), $("#txtCitizenshipnumber").attr("required")
    }), $("#CitizenshipNumberNo").on("click", function () {
        $("#divCitizenshipNumber").hide(), $("#txtCitizenshipnumber").removeAttr("required")
    })
}

function page_click() {
    $("#btnSubmitBackground").on("click", function (t) {
        t.preventDefault();
        var e = $("#frmpassport");
        if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        var r = $(this);
        r.text("Processing..."), r.addClass("disabled");
        var a = [];
        $("#tbodyRefrence  > tr").each(function () {
            var t = $(this),
                e = t.find(".txtname").val(),
                r = t.find(".txtEmail").val(),
                i = t.find(".txtContact").val(),
                n = t.find(".txtAddress").val().replace(/\&/g, "%26"),
                s = t.find(".drpRefCountry").val(),
                o = t.find(".txtState").val(),
                d = t.find(".txtCity").val(),
                c = t.find(".txtArea").val();
            "" != e && "" != r && "" != i && "" != n && "" != s && "" != o && "" != d && "" != c && a.push({
                Name: e,
                Email: r,
                ContactNo: i,
                Address: n,
                Country: s,
                State: o,
                City: d,
                Area: c
            })
        }), $.ajax({
            method: "POST",
            url: "/admission/StudentBackgroundInformation/SaveStudentBackgraound",
            data: e.serialize() + "&StrJson=" + JSON.stringify(a),
            async: !1,
            success: function (t) { }
        }).done(function (t) {
            "true" == t.flag.toString().toLowerCase() ? (swal({
                title: "Success!",
                text: "Data saved successfully.",
                type: "success",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                EditSelectBackData()
            }), r.text("Save"), r.removeClass("disabled")) : (swal({
                title: "Error!",
                text: "Passport Number or Citizenship number Already Exist",
                type: "error",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () { }), r.text("Save"), r.removeClass("disabled"))
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again."), r.text("Save"), r.removeClass("disabled")
        })
    })
}

function EditSelectBackData() {
    $.ajax({
        method: "POST",
        url: "/admission/StudentBackgroundInformation/SelectStudentBackgraound"
    }).done(function (t) {
        $.each(t.List, function (t, e) {
            $("#hdnstudentid").val(e.studentid), "true" == e.IsvalidPassport.toString().toLowerCase() ? ($("#rad6").attr("checked", "checked"), $("#rad6").trigger("click"), $("#txtpassportname").val(e.NameasperPassport), $("#txtpassspoernumber").val(e.PassportNo), $("#txtIssuingAuthority").val(e.IssuingAuthority), $("#txtpasssportexpirydate").val(e.PassportExpDate), $("#drpCountryBackground").val(e.PassportIssueCountry)) : ($("#rad7").attr("checked", "checked"), $("#rad7").trigger("click"), "true" == e.ApplyForPassport.toString().toLowerCase() ? ($("#rad8").attr("checked", "checked"), $("#rad8").trigger("click"), $("#txtPassportFileReferenceNumber").val(e.PassportFileReferenceNumber)) : ($("#rad9").attr("checked", "checked"), $("#rad9").trigger("click"))), "true" == e.HaveCitizenshipNumber.toString().toLowerCase() ? ($("#CitizenshipNumberYes").attr("checked", "checked"), $("#CitizenshipNumberYes").trigger("click"), $("#txtCitizenshipnumber").val(e.CitizenshipNumber)) : ($("#CitizenshipNumberNo").attr("checked", "checked"), $("#CitizenshipNumberNo").trigger("click"), $("#txtCitizenshipnumber").val(""))
        });
        var e = 1;
        $.each(t.List1, function (t, r) {
            var a = $("#tbodyRefrence").find('tr[id="' + e++ + '"]'),
                i = a.find(".txtname"),
                n = a.find(".txtEmail"),
                s = a.find(".txtContact"),
                o = a.find(".txtAddress"),
                d = a.find(".drpRefCountry"),
                c = a.find(".txtState"),
                u = a.find(".txtCity"),
                l = a.find(".txtArea");
            i.val(r.Name), n.val(r.Email), s.val(r.ContactNo), o.val(r.RefAddress), d.val(r.RefCountry), c.val(r.RefState), u.val(r.RefCity), l.val(r.RefArea)
        })
    }).error(function () { })
}
$(document).ready(function () {
    window.Parsley.addValidator("notequalto", {
        requirementType: "string",
        validateString: function (t, e) {
            return t !== $(e).val()
        }
    }), page_event()
});