function page_event() {
    page_change(), page_click(), EditSelectData()
}

function page_validation() { }

function page_change() {
    $(".datetimepicker").datepicker({
        orientation: "left",
        autoclose: !0,
        dateFormat: "dd-mm-yy",
        yearRange: "1900:" + ((new Date).getFullYear() - 14),
        todayHighlight: !1,
        changeMonth: !0,
        changeYear: !0,
        onSelect: function (e) {
            var t = e.split("-"),
                a = t[1] + "-" + t[0] + "-" + t[2],
                n = new Date("2018-01-01"),
                r = (new Date(n.getYear(), n.getMonth(), n.getDate()), n.getYear()),
                i = n.getMonth(),
                s = n.getDate(),
                d = new Date(a.substring(6, 10), a.substring(0, 2) - 1, a.substring(3, 5)),
                l = d.getYear(),
                o = d.getMonth(),
                c = d.getDate();
            if (yearAge = r - l, i >= o) var p = i - o;
            else {
                yearAge--;
                p = 12 + i - o
            }
            if (s >= c) var u = s - c;
            else {
                u = 31 + s - c;
                --p < 0 && (p = 11, yearAge--)
            }
            yearAge, $("#txtYear").val(yearAge)
        }
    });
    $('#TestCountry').on('change', function (e) {
        e.preventDefault();
        var id = $(this).val();
        $('.hide-option').hide();
        $('#TestCity').find('option').each(function () {
            var option = $(this);
            if (option.hasClass(id)) {
                option.show();
            }
        });
    });
}

function page_click() {
    $("#btnStudentBasicSave").on("click", function (e) {
        e.preventDefault();
        var t = $("#frmStudentBasic");
        if (t.parsley().validate(), !t.parsley().isValid()) return !1;
        var a = $(this);
        a.text("Processing..."), a.addClass("disabled");
        if (!$('#iagree').is(':checked')) {
            ErrorMessage('Please agree the form detail.'), a.text("Submit"), a.removeClass("disabled")
            return false;
        }
        ConfirmCallBack('Are you sure you want to submit the data? After submisison you will not be able to edit the data.', function () {
            $.ajax({
                method: "POST",
                url: "/admission/IndSATSelection/SaveStudentBasic",
                data: {
                    'Country': $('#drpCountry').val(),
                    'ApplyingForCourse': $('#ApplyingForCourse').val(),
                    'TestCountry': $('#TestCountry').val(),
                    'TestCity': $('#TestCity').val(),
                    'FatherName': $('#FatherName').val()
                },
                success: function (e) { }
            }).done(function (e) {
                "true" == e.flag.toString().toLowerCase() ?
                    SuccessMessageCallBack('Data saved successfully.', function () {
                        window.location.href = "/admission/Dashboard";
                    }) :
                    ErrorMessage('Data has not been saved. Please try again.'), a.text("Submit"), a.removeClass("disabled")
            }).error(function () {
                ErrorMessage("Something went wrong! Please try again."), a.text("Submit"), a.removeClass("disabled")
            })
        });
        a.text("Submit"), a.removeClass("disabled")

    })
}

function EditSelectData() {
    $.ajax({
        method: "POST",
        url: "/admission/IndSATSelection/SelectStudentBasic"
    }).done(function (e) {
        $.each(e.List, function (e, t) {
            $("#hdnstudentid").val(t.studentid),
                $("#txtFname").removeAttr('disabled').val(t.FirstName).attr('disabled', true),
                $("#txtMname").removeAttr('disabled').val(t.MiddleName).attr('disabled', true),
                $("#txtLname").removeAttr('disabled').val(t.LastName).attr('disabled', true),
                $("#txtdateofbirth").removeAttr('disabled').val(t.DateOfBirth).attr('disabled', true),
                $("#drpGender").removeAttr('disabled').val(t.Gender).attr('disabled', true),
                $("#txtemail").removeAttr('disabled').val(t.Email).attr('disabled', true),
                $("#txtMobile").removeAttr('disabled').val(t.Mobile).attr('disabled', true),
                $("#drpcountrycode").removeAttr('disabled').val(t.CountryCode).attr('disabled', true),
                $("#drpNationality").removeAttr('disabled').val(t.Nationality).attr('disabled', true),
                $("#drpCountry").removeAttr('disabled').val(t.Country).attr('disabled', true)
                //$("#ApplyingForCourse").removeAttr('disabled').val(t.ApplyingForCourse)
        });
        if (e.List1.length > 0) {
            $.each(e.List1, function (e, t) {
                $('#TestCountry').removeAttr('disabled').val(t.TestCountry).attr('disabled', true);
                $('#TestCity').removeAttr('disabled').val(t.TestCity).attr('disabled', true);
                $('#FatherName').removeAttr('disabled').val(t.FatherName).attr('disabled', true);
                $('#ApplyingForCourse').removeAttr('disabled').val(t.ApplyingForCourse).attr('disabled', true);
                $("#btnStudentBasicSave").remove();
            });
        } else {
            $('#frmStudentBasic').find('input').removeAttr('name');
            $('#frmStudentBasic').find('select').removeAttr('name');
        }
    }).error(function () { })
}

$(document).ready(function () {
    page_event()
});