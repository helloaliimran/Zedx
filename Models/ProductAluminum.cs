using System;
using System.Collections.Generic;
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
        public int AluminumColorID { get; set; }
        [DisplayName("Gage")]
        public int AluminumGageID { get; set; }

        public AluminumColor AluminumColor{get;set;}
        public AluminumGage AluminumGage{get;set;}
    }
    
}