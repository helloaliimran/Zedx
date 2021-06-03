$(document).ready(function () {
    ActiveProductSearch();
    
});

$("#ProductName").on('keyup', function (e) {
    
    var code = e.key;
    if (code === "Enter") {
        LoadProductsddl();
        
    }
    else {
        e.preventDefault();
    }

});

$("#Quantity, #Feet, #Rate, #Discount").on('keyup', function () {
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

$("#AluminumColorId, #AluminumGageId, #product_type").on("change", function () {
    ActiveProductSearch();
});




function ProductTableNavigate() {

    var rows = document.getElementById("ProductSearch").children[1].children;
    var selectedRow = 0;
    document.body.onkeydown = function (e) {
        if (!$("#ProductSearch").is(":visible")) {
            return;
        }
        //Prevent page scrolling on keypress
        //e.preventDefault();
        //Clear out old row's color
        rows[selectedRow].style.backgroundColor = "#FFFFFF";
        //Calculate new row
        if (e.keyCode == 38) {
            selectedRow--;
        } else if (e.keyCode == 40) {
            selectedRow++;
        }
        else if (e.keyCode == 13) {

            OnProductSelect(rows[selectedRow]);
        }
        if (selectedRow >= rows.length) {
            selectedRow = 0;
        } else if (selectedRow < 0) {
            selectedRow = rows.length - 1;
        }
        //Set new row's color
        rows[selectedRow].style.backgroundColor = "#8888FF";

    };
    //Set the first row to selected color
    rows[0].style.backgroundColor = "#8888FF";
}

function ActiveProductSearch() {
    if ($("#product_type").val() == 1) {
        if ($("#AluminumColorId").val() != "" && $("#AluminumGageId").val() != "") {
            $("#ProductName").prop("disabled", "");
        }
        else {
            $("#ProductName").prop("disabled", "true");
            $("#ProductName").val("");
            $("#Rate").val("");
        }
    }
    else if ($("#product_type").val() == "") {
        $("#ProductName").prop("disabled", "true");
        $("#ProductName").val("");
        $("#Rate").val("");
    }
    else {
        $("#ProductName").prop("disabled", "");
        $("#ProductName").val("");
        $("#Rate").val("");
    }
}

function clearProductInfo() {
    $("#ProductName").val("");
    $("#AllProductId").val("");
    $("#Rate").val("");
    $("#Discount").val("");
    $("#Feet").val("");
    $("#Quantity").val("");
    $("#TotalFeet").val("");
    $("#NetAmount").val("");
    $("#DiscountedAmount").val("");
    $("#AmountToBePaid").val("");
    $("#SheetHeight").val("");
    $("#SheetWidth").val("");
    $("#BillDetailId").val(0);
}

function onSuccess() {
    $("#lblBillId").text($("#BillId").val());
    clearProductInfo();
}

function Calculations() {
    var quantity = $("#Quantity").val() || 0;
    var size = $("#Feet").val() || 0;
    $("#TotalFeet").val((quantity * size).toFixed(2));
    var rate = $("#Rate").val() || 0;
    var totalfeet = $("#TotalFeet").val() || 0;
    $("#NetAmount").val((rate * totalfeet).toFixed(2));
    var netAmount = $("#NetAmount").val() || 0;
    var discount = $("#Discount").val() || 0;
    var amtToBePaid = netAmount - (netAmount / 100) * discount;
    var discountedAmount = netAmount - amtToBePaid;
    $("#DiscountedAmount").val(discountedAmount.toFixed(2));
    $("#AmountToBePaid").val(amtToBePaid.toFixed(2));
}

function LoadProductsddl() {
    var productName = $("#ProductName").val();
    var color = $("#AluminumColorId").val() || 0;
    var gage = $("#AluminumGageId").val() || 0;
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
            var countrows = $("#ProductSearch").find('tbody').find('tr').length;
            if (countrows > 0) {
                ProductTableNavigate();
                $("#Rate").focus();
            }
            
        }
    })
}

function OnProductSelect(elem) {
    var pId = $(elem).find(".productId").val();
    var pRate = $.trim($(elem).find(".pRate").text());
    $("#AllProductId").val(pId);
    $("#Rate").val(pRate);
    $("#divProductsSerachResults").hide();
}

function BillDetailSubmit() {
    var selectedProduct = $("#AllProductId").val() || 0;
    if (selectedProduct == 0) {
        alert("Product is not selected properly");
        $("#ProductName").val("");
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
            BillId: $("#BillId").val()
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
    $("#BillDetailId").val(objBillDetail.BillDetailId);
    $("#AluminumColorId").val(objBillDetail.AluminumColorId);
    $("#AluminumGageId").val(objBillDetail.AluminumGageId);
    $("#AllProductId").val(objBillDetail.AllProductId);
    $("#ProductName").val(objBillDetail.ProductName);
    $("#Rate").val(objBillDetail.Rate);
    $("#Discount").val(objBillDetail.Discount);
    $("#Feet").val(objBillDetail.Feet);
    $("#Quantity").val(objBillDetail.Quantity);
    $("#TotalFeet").val(objBillDetail.TotalFeet);
    $("#NetAmount").val(objBillDetail.NetAmount);
    $("#DiscountedAmount").val(objBillDetail.DiscountedAmount);
    $("#AmountToBePaid").val(objBillDetail.AmountToBePaid);
    $("#SheetHeight").val(objBillDetail.SheetHeight);
    $("#SheetWidth").val(objBillDetail.SheetWidth);
    row.remove();
    
}

function BillPrint(Printtype) {
    debugger;
    var billId = $("#BillId").val();
    var url = "";
    if (Printtype == "A5") 
        url = "/BillDetail/Print/" + billId;
    else
        //url = "/BillPrint/index/" + billId;
        url = "/BillDetail/Print/" + billId;

    window.open(url, "_blank");
}