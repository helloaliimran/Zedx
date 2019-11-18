using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class AluminumColor
    {   
        [Key]
        public int AluminumColorId {get; set;}
        [DisplayName("Color Name")]
        public string Name { get; set; }
        
       
    }
}