$(document).ready(function () {
    ActiveProductSearch();
});

$("#BillDetail_AllProduct_Name").on('keyup', function (e) {
    var code = e.key;
    if (code === "Enter")
        LoadProductsddl();
    else {
        e.preventDefault();
    }

});

$("#BillDetail_Quantity, #BillDetail_Feet, #BillDetail_Rate, #BillDetail_Discount").on('keyup', function () {
    Calculations()
});

$("#product_type").on('change', function () {
    var pType = $(this).val();
    if (pType == 1) {
        $(".pAlum").prop("disabled", "");
        $(".pGlass").prop("disabled", "true");
        $(".pHardware").prop("disabled", "true");
        $(".pGlass, .pHardware").val("")
    }
    if (pType == 2) {
        $(".pAlum").prop("disabled", "true");
        $(".pGlass").prop("disabled", "");
        $(".pHardware").prop("disabled", "true");
        $(".pHardware, .pAlum").val("")
    }
    if (pType == 3) {
        $(".pAlum").prop("disabled", "true");
        $(".pGlass").prop("disabled", "true");
        $(".pHardware").prop("disabled", "");
        $(".pGlass,.pAlum").val("")
    }
});

$("#BillDetail_AluminumColorId, #BillDetail_AluminumGageId, #product_type").on("change", function () {
    ActiveProductSearch();
});

function ActiveProductSearch() {
    if ($("#product_type").val() == 1) {
        if ($("#BillDetail_AluminumColorId").val() != "" && $("#BillDetail_AluminumGageId").val() != "") {
            $("#BillDetail_AllProduct_Name").prop("disabled", "");
        }
        else {
            $("#BillDetail_AllProduct_Name").prop("disabled", "true");
            $("#BillDetail_AllProduct_Name").val("");
            $("#BillDetail_Rate").val("");
        }
    }
    else if ($("#product_type").val() == "") {
        $("#BillDetail_AllProduct_Name").prop("disabled", "true");
        $("#BillDetail_AllProduct_Name").val("");
        $("#BillDetail_Rate").val("");
    }
    else {
        $("#BillDetail_AllProduct_Name").prop("disabled", "");
        $("#BillDetail_AllProduct_Name").val("");
        $("#BillDetail_Rate").val("");
    }
}

function clearProductInfo() {
    $("#BillDetail_AllProduct_Name").val("");
    $("#BillDetail_AllProductId").val("");
    $("#BillDetail_Rate").val("");
    $("#BillDetail_Discount").val("");
    $("#BillDetail_Feet").val("");
    $("#BillDetail_Quantity").val("");
    $("#BillDetail_TotalFeet").val("");
    $("#BillDetail_NetAmount").val("");
    $("#BillDetail_DiscountedAmount").val("");
    $("#BillDetail_AmountToBePaid").val("");
    $("#BillDetail_SheetHeight").val("");
    $("#BillDetail_SheetWidth").val("");
}

function onSuccess() {
    $("#lblBillId").text($("#BillDetail_BillId").val());
    if ($("#Bill_BillId").val() == 0) {
        $("#Bill_BillId").val($("#BillDetail_BillId").val())
    }
    clearProductInfo();
}

function Calculations() {
    var quantity = $("#BillDetail_Quantity").val() || 0;
    var size = $("#BillDetail_Feet").val() || 0;
    $("#BillDetail_TotalFeet").val((quantity * size).toFixed(2));
    var rate = $("#BillDetail_Rate").val() || 0;
    var totalfeet = $("#BillDetail_TotalFeet").val() || 0;
    $("#BillDetail_NetAmount").val((rate * totalfeet).toFixed(2));
    var netAmount = $("#BillDetail_NetAmount").val() || 0;
    var discount = $("#BillDetail_Discount").val() || 0;
    var amtToBePaid = netAmount - (netAmount / 100) * discount;
    var discountedAmount = netAmount - amtToBePaid;
    $("#BillDetail_DiscountedAmount").val(discountedAmount.toFixed(2));
    $("#BillDetail_AmountToBePaid").val(amtToBePaid.toFixed(2));
}

function LoadProductsddl() {
    var productName = $("#BillDetail_AllProduct_Name").val();
    var color = $("#BillDetail_AluminumColorId").val() || 0;
    var gage = $("#BillDetail_AluminumGageId").val() || 0;
    var type = $("#product_type").val() || 0;
    $.ajax({
        url: '/BillDetail/ProductSerach',
        data: {
            productName: productName,
            productType: type,
            aluminumColor: color,
            aluminumGage: gage

        },
        success: function (data) {
            $("#divProductsSerachResults").html(data);
            $("#divProductsSerachResults").show();
        }
    })
}

function OnProductSelect(elem) {
    var pId = $(elem).find(".productId").val();
    var pRate = $.trim($(elem).find(".pRate").text());
    $("#BillDetail_AllProductId").val(pId);
    $("#BillDetail_Rate").val(pRate);
    $("#divProductsSerachResults").hide();
}

function BillDetailSubmit() {
    var selectedProduct = $("#BillDetail_AllProductId").val() || 0;
    if (selectedProduct == 0) {
        alert("Product is not selected properly");
        $("#BillDetail_AllProduct_Name").val("");
        return;
    }
    $("#BillDetailForm").submit();
}
