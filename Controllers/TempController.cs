using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;

namespace Zedx.Controllers
{
    public class TempController : Controller
    {
        private readonly ZedxContext _context;
        public TempController(ZedxContext context)
        {
            _context = context;
        }
        // GET: AluminumColor
        public async Task<IActionResult> Index()
        {
            return View(await _context.AluminumColor.ToListAsync());
        }
    }
}
