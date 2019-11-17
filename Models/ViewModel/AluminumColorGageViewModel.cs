using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zedx.Models.ViewModel
{
    public class AluminumColorGageViewModel   
    {
        public ProductAluminum productAluminum {get;set;}
        public IEnumerable<SelectListItem> listaluminumColor { get; set; }
        public IEnumerable<SelectListItem> listaluminumGage { get; set; }

    }
}