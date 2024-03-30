$(document).ready(() => {
    initializeView();

    $('#btnSaveNewItem').on("click", () => {
        if (validateData()) {

        }
    });
  
});

function initializeView() {
    $("#edtCategory").empty();
    $("#edtSubCategory").empty();
    $("#edtProduct").empty();
}

function validateData() {
    let mensagem = "";

    let xxx = $("#edtCategory").text();

    if ($("#edtCategory").val() == null || $("#edtCategory").val() == undefined || $("#edtCategory").val() == "") {
        mensagem = "The category must be informed.";
    }
    else if ($("#edtSubCategory").val() == null || $("#edtSubCategory").val() == undefined || $("#edtSubCategory").val() == "") {
        mensagem = "The sub category must be informed.";
    }
    else if ($("#edtProduct").val() == null || $("#edtProduct").val() == undefined || $("#edtProduct").val() == "") {
        mensagem = "The product must be informed.";
    }

    if (mensagem != "") {
        modalShow();
        modalMessage(mensagem);
        return false
    }

    return true;
}