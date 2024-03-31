$(document).ready(function () {
    var storeManagementLoginUserController = "Home/";
    var storeManagementRegisterController = "Register/";
    var actionStoreManagementLoginUser = "StoreManagementLoginUser";
    var actionStoreManagementLoginUserIndex = "Index";

    $('#btnRegister').on("click", () => {
        redirectToAnotherWebPage(`${storeManagementRegisterController}${actionStoreManagementLoginUserIndex}`);
    });

    $('#btnLogin').on("click", () => {
        let mensagem = validateLogin();

        if (mensagem == "") {

            let urlBase = `${storeManagementLoginUserController}${actionStoreManagementLoginUser}`;

            let storeManagementLoginUser = JSON.stringify({
                Email: $('#edtEmail').val(),
                Password: $('#edtPassword').val(),
                RememberMe: $('#chkRememberMe').val()
            });

            $.ajax({
                url: urlBase,
                method: "POST",
                contentType: "application/json; charset=utf-8",
                traditional: true,
                data: storeManagementLoginUser,
                datatype: "JSON",
                success: (data) => {
                    console.log(data);
                },
                error: (xhr, ajaxOptions, thrownError) => {
                    modalShow();
                    modalMessage("Occurred erro!");
                }
            });
        }
        else {
            modalShow();
            modalMessage(mensagem);
        }
    });
});

function validateLogin() {
    let mensagem = "";

    if ($('#edtEmail').val() == null || $('#edtEmail').val() == undefined || $('#edtEmail').val() == "") {
        mensagem = "The email don't informed.";
    } else if ($('#edtPassword').val() == null || $('#edtPassword').val() == undefined || $('#edtPassword').val() == "") {
        mensagem = "The password don't informed.";
    }

    return mensagem;
}