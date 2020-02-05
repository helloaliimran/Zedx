using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class AluminumStock
    {   [Key]
        public long AluminumStockId { get; set; }
        public int Length { get; set; }
        public int Quantity { get; set; }
        public long ProductAluminumId { get; set; }
         public ProductAluminum ProductAluminum{get;set;}

    }
    
}