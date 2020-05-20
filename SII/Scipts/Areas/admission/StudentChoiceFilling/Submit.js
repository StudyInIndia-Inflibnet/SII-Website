function page_click() {
    $(document).on("click", "#btnSave", function (e) {
        e.preventDefault();
        var a = $("#frm"),
            i = $('input[name="__RequestVerificationToken"]', a).val(),
            o = $(this);
        if (!$("#iATC").is(":checked")) return ErrorMessage("Kindly agree declaration."), !1;
        ConfirmCallBack("Once you submit your choices, you will not able to edit anymore", function () {
            $.ajax({
                method: "POST",
                url: $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/SubmitChoices",
                data: {
                    __RequestVerificationToken: i
                },
                async: !1
            }).done(function (e) {
                "success" == e.c ? SuccessMessageCallBack(e.m, function () {
                    window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/Submitted"
                }) : "alreadyexists" == e.c ? (ErrorMessage(e.m), o.text(oldText), o.removeAttr("disabled"), o.removeClass("disabled")) : "sessionexpired" == e.c ? (ErrorMessage(e.m), o.text(oldText), o.removeAttr("disabled"), o.removeClass("disabled")) : "servererror" == e.c ? (ErrorMessage(e.m), o.text(oldText), o.removeAttr("disabled"), o.removeClass("disabled")) : "ChoiceFillingClosed" == e.c && ErrorMessageCallBack(e.m, function () {
                    window.location.href = $("#hdfBaseUrl").val() + "admission/StudentChoiceFilling/Closed"
                })
            }).error(function () {
                ErrorMessage("Something went wrong! Please try again."), o.text("Save"), o.removeClass("disabled")
            })
        })
    })
}
function page_change() {
    $('.fuUploadImage').on('change', function () {
        var fu = $(this);
        var id = fu.attr('data-value');
        upload_doc(fu, $('#lbl' + id), $('#img' + id), id)
    });
}
function upload_doc(fileControl, p, imgView, id) {
    fileUpload = fileControl.get(0);

    if (window.FormData !== undefined) {
        if (fileControl.get(0).files.length > 0) {
            var FileSize = fileControl.get(0).files[0].size;
            var fileExtension = ['jpeg', 'jpg', 'png'];
            //var fileExtension = ['pdf', 'doc', 'jpeg', 'jpg', 'png'];
            if ($.inArray(fileControl.val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                ErrorMessageCallBack("Only formats are allowed : " + fileExtension.join(', '), function () {
                    fileControl.val('');
                });
                return;
            }
            if ("1048576" >= FileSize) {

            } else {
                ErrorMessageCallBack("Only 1 Mb file size allow!", function () {
                    fileControl.val('');
                });
                return;
            }
        } else {
            ErrorMessageCallBack("Please Upload Proper File!", function () {
                fileControl.val('');
            });
            return;
        }
    } else {
        ErrorMessageCallBack("Please Upload Proper File!", function () {
            fileControl.val('');
        });
        return;
    }

    var files = fileUpload.files;
    // Create FormData object  
    var fileData = new FormData();
    // Looping over all files and add it to FormData object  
    fileData.append('id', id);
    fileData.append('__RequestVerificationToken', $('input[name="__RequestVerificationToken"]', $('#frmUpload')).val());
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    }
    $.ajax({
        method: 'POST',
        url: $('#hdfBaseUrl').val() + 'admission/StudentChoiceFilling/UploadDoc',
        data: fileData,
        async: true,
        cache: false,
        contentType: false, // Not to set any content header  
        processData: false,
        xhr: function () {
            var xhr = $.ajaxSettings.xhr();
            xhr.upload.onprogress = function (e) {
                var percentComplete = Math.round(e.loaded / e.total * 100);
                if (percentComplete < 100)
                    p.show().text('' + percentComplete + '% Completed');
                else
                    p.text('Saving file...');
            };
            return xhr;
        }
    }).done(function (data) {
        p.text('').hide();
        if (data['c'] == 'success') {
            imgView.show().attr('src', 'data:image/jpeg;base64,' + data['p']);
            $('#' + id).val(data['p']);
            if (data['f'].toString().toLowerCase() == 'true') {
                $('#btnSaveDisabled').hide();
                $("#btnSave").show();
            } 
        } else if (data['c'] == 'alreadyexists') {
            PopupMessage('Error!', data['m']);
        } else if (data['c'] == 'sessionexpired') {
            PopupMessage('Error!', data['m']);
        } else if (data['c'] == 'servererror') {
            PopupMessage('Error!', data['m']);
        }
        fileControl.val('');
    }).error(function () {
        ErrorMessage('Processing error. Kindly refresh page and try again!');
    });
}


$(document).ready(function () {
    page_click();
    page_change();
});


