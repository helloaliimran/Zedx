using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;

namespace Zedx.Controllers
{ [Route("api/Aluminum")]
        public class AluminumController : Controller
    {
        [HttpGet("{id}")]
        public ProductAluminum Get(int id){
            ProductAluminum productAluminum = new ProductAluminum();
            productAluminum.ProductAluminumName="DC26C";
            productAluminum.ProductAluminumId=1;
            productAluminum.RatePerFeet=2;
            productAluminum.AluminumColorID=1;
            productAluminum.AluminumGageID=2;
            
            return productAluminum;
        }

    }
}