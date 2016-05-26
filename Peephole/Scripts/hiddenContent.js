// Author: Ole-Martin


$(document).ready(function () {
    if ($.cookie('cookie') === "true") {
        $('#checkbox1').prop('checked', true);
        $('#hidden-content').show();
        console.log("show")
    } else {
        $('#hidden-content').hide();
    }


    $("#checkbox1").change(function () {
        $.cookie('cookie', $(this).prop('checked'), {
            path: '/',
            expires: 365
        });
        $('#hidden-content').fadeToggle();
    });
});

