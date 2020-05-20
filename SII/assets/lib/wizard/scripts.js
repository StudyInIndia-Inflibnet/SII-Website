function scroll_to_class(element_class, removed_height) {
    var scroll_to = $(element_class).offset().top - removed_height;
    if ($(window).scrollTop() != scroll_to) {
        $('html, body').stop().animate({ scrollTop: scroll_to }, 0);
    }
}

function bar_progress(progress_line_object, direction) {
    var number_of_steps = progress_line_object.data('number-of-steps');
    var now_value = progress_line_object.data('now-value');
    var new_value = 0;
    if (direction == 'right') {
        new_value = now_value + (100 / number_of_steps);
    } else if (direction == 'left') {
        new_value = now_value - (100 / number_of_steps);
    }
    progress_line_object.attr('style', 'width: ' + new_value + '%;').data('now-value', new_value);
}

jQuery(document).ready(function () {
    $('.f1 fieldset:first').fadeIn('slow');

    $('.btn-next').on('click', function () {
        NextStep($(this))
    });

    $('.f1 .btn-previous').on('click', function () {
        PrevStep($(this));
    });
});

function NextStep(btn) {
    var p = btn.parents('fieldset');
    var c = btn.parents('.f1').find('.f1-step.active');
    var l = btn.parents('.f1').find('.f1-progress-line');
    p.fadeOut(400, function () {
        c.removeClass('active').addClass('activated').next().addClass('active');
        bar_progress(l, 'right');
        $(this).next().fadeIn();
        scroll_to_class($('.f1'), 20);
    });
}
function PrevStep(btn) {
    var c = btn.parents('.f1').find('.f1-step.active');
    var l = btn.parents('.f1').find('.f1-progress-line');

    btn.parents('fieldset').fadeOut(400, function () {
        c.removeClass('active').prev().removeClass('activated').addClass('active');
        bar_progress(l, 'left');
        $(this).prev().fadeIn();
        scroll_to_class($('.f1'), 20);
    });
}