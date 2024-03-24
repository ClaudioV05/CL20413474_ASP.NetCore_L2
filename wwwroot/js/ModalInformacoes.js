$(document).ready(function () {

    $('#modal-information-ok').click(function () {
        modalHide();
    });

    $('#modal-information-close').click(function () {
        modalHide();
    })

});

function modalShow() {
    $("#modal-information").modal("show");
}

function modalHide() {
    $("#modal-information").modal("hide");
}

function modalMessage(message) {
    $("#modal-information").find("#modal-information-message").text("");
    $("#modal-information").find("#modal-information-message").text(message);
}