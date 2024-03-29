$(document).ready(function () {

});

function enabledComponent($) {
    $.prop("disabled", false);
}

function disabledComponent($) {
    $.prop("disabled", true);
}

function redirectToAnotherWebPage(url) {
    $(location).prop('href', url)
}