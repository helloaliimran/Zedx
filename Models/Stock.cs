using System;
using System.ComponentModel.DataAnnotations;

namespace Zedx.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int quantity{get; set;}
        public decimal Price { get; set; }

    }
}