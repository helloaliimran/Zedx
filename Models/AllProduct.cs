using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Zedx.Models.ViewModel;

namespace Zedx.Models
{
    public class AllProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductId { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public  long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
        //one to many relationship [one product has only one type but product type has many products]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        //one to many relationship [one product has one color but color has many product]
        public int? AluminumColorId { get; set; }
        public AluminumColor AluminumColor { get; set; }
        //one to many relationship [one product has one Gage but Gage has many product]
        public int? AluminumGageId { get; set; }
        public AluminumGage AluminumGage { get; set; }
    }
}
