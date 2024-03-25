$(document).ready(() => {
    initializeView();
});

$('#dpdCategoryName').on("change", () => {

    if ($("#dpdCategoryName option:selected").val() == "0") {
        initializeView();
    }
    else {
        let urlBase = `StoreManagement/GetSubCategory?categoryID=${$("#dpdCategoryName option:selected").val()}`;

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
    let urlBase = `StoreManagement/GetProducts?subCategoryID=${$("#dpdSubCategoryName option:selected").val()}`;

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

$('#dpdProduct').on("change", () => {
    enabledComponent($('#btnSaveNewItem'));
});

$('#btnSaveNewItem').on("click", () => {
    let message = "";

    if ($("#dpdCategoryName option:selected").val() == null || $("#dpdCategoryName option:selected").val() == undefined || $("#dpdCategoryName option:selected").val() == "0") {
        message = "Category not informed."
    }
    else if ($("#dpdSubCategoryName option:selected").val() == null || $("#dpdSubCategoryName option:selected").val() == undefined || $("#dpdSubCategoryName option:selected").val() == "0") {
        message = "Sub Category not informed."
    }
    else if ($("#dpdProduct option:selected").val() == null || $("#dpdProduct option:selected").val() == undefined || $("#dpdProduct option:selected").val() == "0") {
        message = "Product not informed."
    }

    if (message == "") {
        let urlBase = `StoreManagement/Save?value1=${23}`;

        $.ajax({
            url: urlBase,
            method: "POST",
            contentType: "application/json; charset=utf-8",
            traditional: true,
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
        modalMessage(message);
    }

});

function initializeView() {
    $("#dpdSubCategoryName").empty();
    $("#dpdProduct").empty();

    $("#dpdProduct").append($('<option>', { value: "0", text: "Select" }));
    $("#dpdSubCategoryName").append($('<option>', { value: "0", text: "Select" }));

    disabledComponent($("#dpdSubCategoryName"));
    disabledComponent($("#dpdProduct"));
    disabledComponent($("#btnSaveNewItem"));
}