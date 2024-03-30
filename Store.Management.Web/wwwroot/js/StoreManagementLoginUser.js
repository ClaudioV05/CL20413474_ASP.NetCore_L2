$(document).ready(function () {
    var storeManagementLoginUserController = "Home/";
    var storeManagementRegisterController = "Register/";
    var actionStoreManagementLoginUser = "StoreManagementLoginUser";

    $('#btnRegister').on("click", () => {
        redirectToAnotherWebPage(`${storeManagementRegisterController}Register`);
    });

    $('#btnLogin').on("click", () => {
        let mensagem = validateLogin();

        if (mensagem == "") {

            let urlBase = `${storeManagementLoginUserController}${actionStoreManagementLoginUser}`;

            let storeManagementLoginUser = JSON.stringify({
                Username: $('#edtUserName').val(),
                Password: $('#edtPassword').val()
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

    if ($('#edtUserName').val() == null || $('#edtUserName').val() == undefined || $('#edtUserName').val() == "") {
        mensagem = "The username don't informed.";
    } else if ($('#edtPassword').val() == null || $('#edtPassword').val() == undefined || $('#edtPassword').val() == "") {
        mensagem = "The password don't informed.";
    }

    return mensagem;
}