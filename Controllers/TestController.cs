using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;

namespace Zedx.Controllers
{
    public class TestController : Controller
    {
        private readonly ZedxContext _context;
        public TestController(ZedxContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
           var zedxContext= _context.AllProducts
                                .Include(a => a.AluminumColor)
                                .Include(a => a.AluminumGage)
                                .Include(a => a.ProductType);
           return View(await zedxContext.ToListAsync());
        }
    }
}
