using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zedx.Models.DTO
{
    public class BillProduct
    {
       
        public long BillDetailId { get; set; }
        public long AllProductId { get; set; }
        public int AluminumColorId { get; set; }
        public int AluminumGageId { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string GageName { get; set; }
        public float Rate { get; set; }
        public int Discount { get; set; }
        public float Feet { get; set; }
        public float Quantity { get; set; }
        public float TotalFeet { get; set; }
        public float NetAmount { get; set; }
        public float DiscountedAmount { get; set; }
        public float AmountToBePaid { get; set; }
        public float SheetHeight { get; set; }
        public float SheetWidth { get; set; }
   
    }
}
