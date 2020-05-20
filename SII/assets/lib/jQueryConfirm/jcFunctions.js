function SuccessMessageCallBackWithClose(msg, callBack, closeCallBack) {
    $.confirm({
        title: 'Alert!',
        content: msg,
        type: 'green',
        useBootstrap: false,
        boxWidth: '400px',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary',
                action: callBack
            },
            close: {
                btnClass: 'btn-primary',
                action: closeCallBack
            }
        }
    });
}
function SuccessMessageCallBack(msg, callBack) {
    $.confirm({
        title: 'Alert!',
        content: msg,
        type: 'green',
        useBootstrap: false,
        boxWidth: '400px',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary',
                action: callBack
            }
        }
    });
}

function SuccessMessage(msg) {
    $.alert({
        title: 'Alert!',
        content: msg,
        useBootstrap: false,
        boxWidth: '400px',
        type: 'green',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary'
            }
        }
    });
}

function ErrorMessage(msg) {
    $.alert({
        title: 'Error!',
        content: msg,
        type: 'red',
        useBootstrap: false,
        boxWidth: '400px',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary'
            }
        }
    });
}

function ErrorMessageCallBack(msg, callBack) {
    $.confirm({
        title: 'Error!',
        content: msg,
        type: 'red',
        useBootstrap: false,
        boxWidth: '500px',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary',
                action: callBack
            }
        }
    });
}

function ConfirmCallBack(msg, callBack) {
    $.confirm({
        title: 'Confirm!',
        content: msg,
        backgroundDismiss: false,
        boxWidth: '500px',
        useBootstrap: false,
        backgroundDismissAnimation: 'shake',
        type: 'gray',
        buttons: {
            yes: {
                btnClass: 'btn-primary',
                action: callBack
            },
            cancel: {
                btnClass: 'btn-primary',
            }
        }
    });
}

function SuccessCallBackMedium(msg, callBack) {
    $.confirm({
        title: 'Success!',
        content: msg,
        autoClose: 'ok|8000',
        boxWidth: '500px',
        useBootstrap: false,

        type: 'green',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary',
                action: callBack
            }
        }
    });
}

function AlertMessage(msg) {
    $.alert({
        title: 'Alert!',
        content: msg,
        type: 'blue',
        useBootstrap: false,
        boxWidth: '400px',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary'
            }
        }
    });
}

function PopupMessage(title, msg) {
    $.alert({
        title: '<span style="color:#337ab7;">' + title + ' <i class="fa fa-exclamation "></i></span>',
        type: 'blue',
        content: msg,
        useBootstrap: false,
        boxWidth: '80%',
        backgroundDismiss: false,
        backgroundDismissAnimation: 'shake',
        buttons: {
            ok: {
                btnClass: 'btn-primary'
            }
        }
    });
}

function PromtMessage(title, label, callBack) {
    $.confirm({
        title: '' + title + '!',
        content: '' +
            '<form action="" class="formName">' +
            '<div class="form-group">' +
            '<label>' + label+'</label>' +
            '<textarea placeholder="' + label+'" class="textarea form-control" required ></textarea>' +
            '</div>' +
            '</form>',
        buttons: {
            formSubmit: {
                text: title,
                btnClass: (title == 'Approve' ? 'btn-green' : 'btn-red'),
                action: callBack
            },
            cancel: function () {
                //close
            },
        },
        onContentReady: function () {
            // bind to events
            var jc = this;
            this.$content.find('form').on('submit', function (e) {
                // if the user submits the form by pressing enter in the field.
                e.preventDefault();
                jc.$$formSubmit.trigger('click'); // reference the button and click it
            });
        }
    });
}

function ConfirmCallBack(msg, callBack, cancelCallback) {
    $.confirm({
        title: 'Confirm!',
        content: msg,
        backgroundDismiss: false,
        boxWidth: '500px',
        useBootstrap: false,
        backgroundDismissAnimation: 'shake',
        type: 'gray',
        buttons: {
            yes: {
                btnClass: 'btn-primary',
                action: callBack
            },
            cancel: {
                btnClass: 'btn-primary',
                action: cancelCallback
            }
        }
    });
}