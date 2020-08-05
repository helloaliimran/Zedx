using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zedx.Models
{
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BillDetailId { get; set; }
        public long AllProductId { get; set; }
        public AllProduct AllProduct { get; set; }
        [Display(Name = "Color")]
        public int? AluminumColorId { get; set; }
        public AluminumColor AluminumColor { get; set; }
        [Display(Name ="Thickness")]
        public int? AluminumGageId { get; set; }
        public AluminumGage AluminumGage { get; set; }
        public float Rate { get; set; }
        public int Discount { get; set; }
        public float Feet { get; set; }
        public float Quantity { get; set; }
        public float TotalFeet { get; set; }
        public float NetAmount { get; set; }
        public float DiscountedAmount { get; set; }
        public float AmountToBePaid { get; set; }
        public Bill Bill { get; set; }
        public long BillId { get; set; }
        public float SheetHeight { get; set; }
        public float SheetWidth { get; set; }
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
