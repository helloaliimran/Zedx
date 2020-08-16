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
    $("#BillDetail_BillDetailId").val(0);
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

function RemoveProduct(elem) {
    var row = $(elem).closest('tr');
    
    $.ajax({
        url: '/BillDetail/RemoveProduct',
        data: {
            BillDetailId: row.find("#item_BillDetailId").val(),
            BillId: row.find("#item_Bill_BillId").val()
        },
        success: function (data) {
                row.remove();
                $("#divAddProducts").html(data);
                alert("item delete successfully!")
            
            
        }
    })
  
}

function EditProduct(elem) {
    FillFormForEdit(elem);
}

function FillFormForEdit(elem) {
    var row= $(elem).closest('tr');
    var objBillDetail =  {
        BillDetailId: row.find("#item_BillDetailId").val(),
        AllProductId:row.find("#item_AllProductId").val(),
        AluminumColorId:row.find("#item_AluminumColorId").val(),
        AluminumGageId:row.find("#item_AluminumGageId").val(),
        Rate:$.trim(row.find(".rate").text()),
        Discount: $.trim(row.find(".discount").text()),
        Feet: $.trim(row.find(".feet").text()),
        Quantity: $.trim(row.find(".quantity").text()),
        TotalFeet: $.trim(row.find(".totalfeet").text()),
        NetAmount: $.trim(row.find(".NetAmount").text()),
        DiscountedAmount: $.trim(row.find(".discountAmount").text()),
        AmountToBePaid: $.trim(row.find(".AmountTobePaid").text()),
        SheetHeight: $.trim(row.find(".sheetHeight").text()),
        SheetWidth: $.trim(row.find(".sheetWidth").text()),
        ProductName: $.trim(row.find(".pName").text()),
    }
    $("#BillDetail_BillDetailId").val(objBillDetail.BillDetailId);
    $("#BillDetail_AluminumColorId").val(objBillDetail.AluminumColorId);
    $("#BillDetail_AluminumGageId").val(objBillDetail.AluminumGageId);
    $("#BillDetail_AllProductId").val(objBillDetail.AllProductId);
    $("#BillDetail_AllProduct_Name").val(objBillDetail.ProductName);
    $("#BillDetail_Rate").val(objBillDetail.Rate);
    $("#BillDetail_Discount").val(objBillDetail.Discount);
    $("#BillDetail_Feet").val(objBillDetail.Feet);
    $("#BillDetail_Quantity").val(objBillDetail.Quantity);
    $("#BillDetail_TotalFeet").val(objBillDetail.TotalFeet);
    $("#BillDetail_NetAmount").val(objBillDetail.NetAmount);
    $("#BillDetail_DiscountedAmount").val(objBillDetail.DiscountedAmount);
    $("#BillDetail_AmountToBePaid").val(objBillDetail.AmountToBePaid);
    $("#BillDetail_SheetHeight").val(objBillDetail.SheetHeight);
    $("#BillDetail_SheetWidth").val(objBillDetail.SheetWidth);
    row.remove();
    
}