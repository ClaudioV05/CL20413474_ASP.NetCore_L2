$(document).ready(function () {
    $('#dpdCategoryName').change(function () {
        //let urlBase = `StoreManagement/GetSubCategory?categoryID=${$("#dpdCategoryName option:selected").val()}`;
        let urlBase = `StoreManagement/GetSubCategddory?categoryID=${$("#dpdCategoryName option:selected").val()}`;

        $.ajax({
            url: urlBase,
            method: "GET",
            contentType: "application/json",
            traditional: true,
            success: function (data) {
                $("#dpdSubCategoryName").empty();

                if (data != null && data != undefined && data.length > 0) {
                    $.each(data, function (i, subcategory) {
                        $("#dpdSubCategoryName").append($('<option>', { value: subcategory.subCategoryID, text: subcategory.subCategoryName }));
                    });

                    $("#dpdSubCategoryName").val("1").change();
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                let modalInformation = $("#modal-information");
                modalInformation.modal("show");
                modalInformation.find("#modal-information-message").text("");
                modalInformation.find("#modal-information-message").text("Erro");
            }
        });

        //var url = '@Url.Content("~/")' + "StoreManagement/GetProducts";
        //var ddlsource = "#SubCategoryID";
        //$.getJSON(url, { SubCategoryID: $(ddlsource).val() }, function (data) {
        //    var items = '';
        //    $('#ProductID').empty();
        //    $.each(data, function (i, product) {
        //        items += "<option value='" + product.value + "'>" + product.text + "</option>";
        //    });
        //    $('#ProductID').html(items);
        //});
    });
});