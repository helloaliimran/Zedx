using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zedx.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BillId { get; set; }
        public float NetAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float Total { get; set; }
        public long CustomerId { get; set; }
        public  Customers Customers { get; set; }
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
