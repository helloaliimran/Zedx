using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zedx.Controllers
{
    public class AluminumStockController : Controller
    {
        private readonly ZedxContext _context;

        public AluminumStockController(ZedxContext context)
        {
            _context = context;
        }

        // GET: AluminumStock
        public async Task<IActionResult> Index()
        {
            var zedxContext = _context.AluminumStock.Include(a => a.ProductAluminum)
                                                    .ThenInclude(b=>b.AluminumColor)
                                                    .Include(a => a.ProductAluminum)
                                                    .ThenInclude(b=>b.AluminumGage);
                                                    
                                                    

            return View(await zedxContext.ToListAsync());
        }

        // GET: AluminumStock/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumStock = await _context.AluminumStock
                .Include(a => a.ProductAluminum)
                .FirstOrDefaultAsync(m => m.AluminumStockId == id);
            if (aluminumStock == null)
            {
                return NotFound();
            }

            return View(aluminumStock);
        }

        // GET: AluminumStock/Create
        public IActionResult Create()
        {
            
            ViewData["ProductAluminumId"] = new SelectList(_context.ProductAluminum, "ProductAluminumId", "ProductAluminumName");
            ViewData["AluminumColorID"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
             ViewData["AluminumGageID"] = new SelectList(_context.AluminumGage.ToList(), "AluminumGageId", "Name");
              string s =   getProducts(1,1);
            return View();
        }
             public string getProducts(int ColorId, int GageId)
        {
            // var target=  _context.ProductAluminum.Where(a=>a.AluminumColorID==ColorId && a.AluminumGageID==GageId);
            // return  JsonSerializer.Serialize(productAluminumlist); 

            List<ProductAluminum> aluminumList = new List<ProductAluminum>();
            aluminumList = _context.ProductAluminum.Where(a=>a.AluminumColorID==ColorId && a.AluminumGageID==GageId).ToList();
            SelectList obgcity = new SelectList(aluminumList, "", "CityName", 0);
            return "";
        }
        // POST: AluminumStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AluminumStockId,Length,Quantity,ProductAluminumId")] AluminumStock aluminumStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluminumStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductAluminumId"] = new SelectList(_context.ProductAluminum, "ProductAluminumId", "ProductAluminumId", aluminumStock.ProductAluminumId);
            return View(aluminumStock);
        }

        // GET: AluminumStock/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumStock = await _context.AluminumStock.FindAsync(id);
            if (aluminumStock == null)
            {
                return NotFound();
            }
            ViewData["ProductAluminumId"] = new SelectList(_context.ProductAluminum, "ProductAluminumId", "ProductAluminumId", aluminumStock.ProductAluminumId);
            return View(aluminumStock);
        }

        // POST: AluminumStock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AluminumStockId,Length,Quantity,ProductAluminumId")] AluminumStock aluminumStock)
        {
            if (id != aluminumStock.AluminumStockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluminumStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluminumStockExists(aluminumStock.AluminumStockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductAluminumId"] = new SelectList(_context.ProductAluminum, "ProductAluminumId", "ProductAluminumId", aluminumStock.ProductAluminumId);
            return View(aluminumStock);
        }

        // GET: AluminumStock/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumStock = await _context.AluminumStock
                .Include(a => a.ProductAluminum)
                .FirstOrDefaultAsync(m => m.AluminumStockId == id);
            if (aluminumStock == null)
            {
                return NotFound();
            }

            return View(aluminumStock);
        }

        // POST: AluminumStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var aluminumStock = await _context.AluminumStock.FindAsync(id);
            _context.AluminumStock.Remove(aluminumStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluminumStockExists(long id)
        {
            return _context.AluminumStock.Any(e => e.AluminumStockId == id);
        }
    }
}
