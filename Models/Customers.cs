using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class Customers
    {   
        [Key]
        public long CustomerId {get; set;}
        [DisplayName("Name")]
        public string CustomerName { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        
       
    }
}