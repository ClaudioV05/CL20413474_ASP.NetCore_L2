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
            contentType: "application/json",
            traditional: true,
            success: (data) => {
                $("#dpdSubCategoryName").empty();
                enabledComponent($("#dpdSubCategoryName"));
                $("#dpdSubCategoryName").append($('<option>', { value: "0", text: "Select" }));

                if (data != null && data != undefined && data.length > 0) {
                    $.each(data, (i, subcategory) => {
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
        contentType: "application/json",
        traditional: true,
        success: (data) => {
            $("#dpdProduct").empty();
            enabledComponent($("#dpdProduct"));
            $("#dpdProduct").append($('<option>', { value: "0", text: "Select" }));

            if (data != null && data != undefined && data.length > 0) {
                $.each(data, (i, product) => {
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
    let urlBase = `StoreManagement/GetProducts?subCategoryID=${$("#dpdSubCategoryName option:selected").val()}`;

    $.ajax({
        url: urlBase,
        method: "GET",
        contentType: "application/json",
        traditional: true,
        success: (data) => {
            $("#dpdProduct").empty();

            if (data != null && data != undefined && data.length > 0) {
                $("#dpdProduct").append($('<option>', { value: "0", text: "Select" }));

                $.each(data, (i, product) => {
                    $("#dpdProduct").append($('<option>', { value: product.productID, text: product.productName }));
                });

                $("#dpdProduct").val("0").trigger("change");
            }
        },
        error: (xhr, ajaxOptions, thrownError) => {
            modalShow();
            modalMessage("Occurred erro!");
        }
    });
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