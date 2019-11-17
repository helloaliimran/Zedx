using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class ProductAluminum
    {   [Key]
        public long ProductAluminumId { get; set; }
        [DisplayName("Name")]
        public string ProductAluminumName { get; set; }
        [DisplayName("Rate")]
        public decimal RatePerFeet { get; set; }
        [DisplayName("Color")]
        public int colorId { get; set; }
        [DisplayName("Gage")]
        public int GageId { get; set; }

    }
}