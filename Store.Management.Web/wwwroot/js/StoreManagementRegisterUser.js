$(document).ready(function () {
    var storeManagementRegisterController = "Register/";
    var actionStoreManagementRegisterNewUser = "StoreManagementRegisterNewUser";
    
    $('#btnRegisterNewUser').on("click", () => {
        let mensagem = validateRegisterNewUser();

        if (mensagem == "") {

            let urlBase = `${storeManagementRegisterController}${actionStoreManagementRegisterNewUser}`;

            let storeManagementRegisterNewUser = JSON.stringify({
                Email: $('#edtEmail').val(),
                Password: $('#edtPassword').val(),
                ConfirmPassword: $('#edtConfirmPassword').val()
            });

            $.ajax({
                url: urlBase,
                method: "POST",
                contentType: "application/json; charset=utf-8",
                traditional: true,
                data: storeManagementRegisterNewUser,
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

function validateRegisterNewUser() {
    let mensagem = "";

    if ($('#edtEmail').val() == null || $('#edtEmail').val() == undefined || $('#edtEmail').val() == "") {
        mensagem = "The email don't informed.";
    } else if ($('#edtPassword').val() == null || $('#edtPassword').val() == undefined || $('#edtPassword').val() == "") {
        mensagem = "The password don't informed.";
    } else if ($('#edtConfirmPassword').val() == null || $('#edtConfirmPassword').val() == undefined || $('#edtConfirmPassword').val() == "") {
        mensagem = "The confirm password don't informed.";
    }

    return mensagem;
}