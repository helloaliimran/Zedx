using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class AluminumGage
    {   [Key]
        public int AluminumGageId {get;set;}
        [DisplayName("Gage Name")]
        public string Name { get; set; }

    }

}