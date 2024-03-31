$(document).ready(() => {
    initializeView();
    var storeManagementController = "StoreManagement/";
    var actionGetTheListOfSubCategoryByCategoryId = "GetTheListOfSubCategoryByCategoryId";
    var actionGetTheListOfProductBySubCategoryId = "GetTheListOfProductBySubCategoryId";

    $('#dpdCategoryName').on("change", () => {

        if ($("#dpdCategoryName option:selected").val() == "0") {
            initializeView();
        }
        else {
            let urlBase = `${actionGetTheListOfSubCategoryByCategoryId}?id=${$("#dpdCategoryName option:selected").val()}`;

            $.ajax({
                url: urlBase,
                method: "GET",
                contentType: "application/json; charset=utf-8",
                traditional: true,
                datatype: "JSON",
                success: (result) => {
                    $("#dpdSubCategoryName").empty();
                    enabledComponent($("#dpdSubCategoryName"));
                    $("#dpdSubCategoryName").append($('<option>', { value: "0", text: "Select" }));

                    if (result != null && result != undefined && result.length > 0) {
                        $.each(result, (i, subcategory) => {
                            $("#dpdSubCategoryName").append($("<option>", { value: subcategory.subCategoryID, text: subcategory.subCategoryName }));
                        });
                    }
                },
                error: (xhr, ajaxOptions, thrownError) => {
                    modalShow();
                    modalMessage("Occurred erro!");
                }
            });
        }
    });

    $('#dpdSubCategoryName').on("change", () => {
        let urlBase = `${actionGetTheListOfProductBySubCategoryId}?id=${$("#dpdSubCategoryName option:selected").val()}`;

        $.ajax({
            url: urlBase,
            method: "GET",
            contentType: "application/json; charset=utf-8",
            traditional: true,
            datatype: "JSON",
            success: (result) => {
                $("#dpdProduct").empty();
                enabledComponent($("#dpdProduct"));
                $("#dpdProduct").append($('<option>', { value: "0", text: "Select" }));

                if (result != null && result != undefined && result.length > 0) {
                    $.each(result, (i, product) => {
                        $("#dpdProduct").append($("<option>", { value: product.productID, text: product.productName }));
                    });
                }
            },
            error: (xhr, ajaxOptions, thrownError) => {
                modalShow();
                modalMessage("Occurred erro!");
            }
        });
    });
});

function initializeView() {
    $("#dpdSubCategoryName").empty();
    $("#dpdProduct").empty();

    $("#dpdProduct").append($('<option>', { value: "0", text: "Select" }));
    $("#dpdSubCategoryName").append($('<option>', { value: "0", text: "Select" }));

    disabledComponent($("#dpdSubCategoryName"));
    disabledComponent($("#dpdProduct"));
    disabledComponent($("#btnStoreManagement"));
}