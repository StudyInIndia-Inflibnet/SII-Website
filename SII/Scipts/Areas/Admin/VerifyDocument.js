$(document).ready(function () {
    page_change();
    trigger_isverified();
    $('#btnSave').on('click', function (e) {
        e.preventDefault();
        var frm = $('#frmDocuments');
        var frmParsley = frm.parsley();
        frmParsley.validate();
        if (!frm.parsley().isValid()) {
            return false;
        }
        var btn = $(this);
        var btnText = btn.text();
        var flag = true;
        $(".listEQ").each(function () {
            var tr = $(this);
            if (tr.find('.IsVerified').val() == "") {
                flag = false;
            }
        });
        $(".listEQ").each(function () {
            var tr = $(this);
            if (tr.find('.IsVerified').val() == "") {
                flag = false;
            }
        });
        if (!flag) {
            ErrorMessage('All verification status should be updated!');
            return false;
        }
        btn.text('Processing...').attr('disabled', true);
        $.ajax({
            method: 'POST',
            url: $('#hdfBaseUrl').val() + 'Admin/VerifyDocuments/SaveStudentData',
            data: { ID: $('#hdfID').val(), Docs: JSON.stringify(GET_Data()) }
        }).done(function (data) {
            SuccessMessageCallBack(data['m'], function () {
                btn.text(btnText).removeAttr('disabled');
            });
        });
    });
});

function GET_Data() {
    var e = [];
    $(".listEQ").each(function () {
        var tr = $(this);
        var v = tr.find('.IsVerified');
        var r = tr.find('.Reason');
        var c = tr.find('.Comment');
        e.push({
            IsVerified: v.val(),
            Reason: r.val(),
            Comment: c.val(),
            ID: tr.find('.IsVerified').attr('data-id')
        });
    })
    $(".listAE").each(function () {
        var tr = $(this);
        var v = tr.find('.IsVerified');
        var r = tr.find('.Reason');
        var c = tr.find('.Comment');
        e.push({
            IsVerified: v.val(),
            Reason: r.val(),
            Comment: c.val(),
            ID: tr.find('.IsVerified').attr('data-id')
        });
    })
    return e
}

function form_save(btn, func) {
    var frm = $('#frm');
    var frmParsley = frm.parsley();
    frmParsley.validate();
    if (!frm.parsley().isValid()) {
        return false;
    }
    var oldText = btn.text();
    if (btn.hasClass('disabled')) {
        return false;
    }
    btn.text('Processing.....');
    btn.attr('disabled', true);
    btn.addClass('disabled');

}

function page_change() {
    $(document).on('change', '.IsVerified', function (e) {
        e.preventDefault();
        var chk = $(this);
        var tr = chk.closest('tr');
        var r = tr.find('.Reason');
        var c = tr.find('.Comment');
        if (chk.val() == 'Rejected') {
            r.removeAttr('disabled').val(r.attr('data-value')).trigger('change');
            r.find('.rejected').show();
            r.find('.verified').hide();
            r.attr('required', true).trigger('change');
            //c.removeAttr('disabled').val(c.attr('data-value'));
        } else if (chk.val() == 'Verified') {
            r.find('.rejected').hide();
            r.find('.verified').show();
            r.removeAttr('required');
            r.attr('disabled', true).val('Verified').trigger('change');
            //c.attr('disabled', true).val('Verified');
        } else {
            r.find('.rejected').hide();
            r.find('.verified').show();
            r.removeAttr('required');
            r.attr('disabled', true).val(r.attr('data-value')).trigger('change');
            //c.attr('disabled', true).val(c.attr('data-value'));
        }
    });
    $(document).on('change', '.Reason', function (e) {
        e.preventDefault();
        var chk = $(this);
        var tr = chk.closest('tr');
        var c = tr.find('.Comment');
        if (chk.val() == 'Other' || chk.val() == 'Percentage Mismatch') {
            c.attr('required', true);
            c.removeAttr('disabled').val(c.attr('data-value'));
        } else {
            c.removeAttr('required');
            c.attr('disabled', true).val(chk.val());
        }
    });
}

function trigger_isverified() {
    $(".listEQ").find('.IsVerified').each(function () {
        $(this).trigger('change');
    });
    $(".listAE").find('.IsVerified').each(function () {
        $(this).trigger('change');
    });
}