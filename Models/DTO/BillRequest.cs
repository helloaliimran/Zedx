using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zedx.Models.DTO
{
    public class BillRequest: BillProduct
    {
        public long BillId { get; set; }
        public float NetAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float Total { get; set; }
        public long CustomerId { get; set; }
        public List<BillProduct> BillProducts { get; set; }
        
    }
}
