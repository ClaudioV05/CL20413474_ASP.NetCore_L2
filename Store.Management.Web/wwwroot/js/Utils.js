$(document).ready(function () {

});

function enabledComponent($) {
    $.prop("disabled", false);
}

function disabledComponent($) {
    $.prop("disabled", true);
}

function hideComponent($) {
    $.addClass('d-none');
}

function showComponent($) {
    $.removeClass('d-none');
}

function redirectToAnotherWebPage(url) {
    $(location).prop('href', url)
}