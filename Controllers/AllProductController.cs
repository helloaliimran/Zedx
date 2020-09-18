using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;
using Zedx.Models.Common;

namespace Zedx.Controllers
{
    public class AllProductController : Controller
    {
        private readonly ZedxContext _context;

        public AllProductController(ZedxContext context)
        {
            _context = context;
        }

        // GET: AllProduct
        public async Task<IActionResult> Index()
        {
            var zedxContext = _context.AllProducts.Include(a => a.AluminumColor).Include(a => a.AluminumGage).Include(a => a.ProductType);
            return View(await zedxContext.ToListAsync());
        }

        // GET: AllProduct/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProduct = await _context.AllProducts
                .Where(a => a.Deleted == false)
                .Include(a => a.AluminumColor)
                .Include(a => a.AluminumGage)
                .Include(a => a.ProductType)
                .FirstOrDefaultAsync(m => m.AllProductId == id);
            if (allProduct == null)
            {
                return NotFound();
            }

            return View(allProduct);
        }

        // GET: AllProduct/Create
        public IActionResult Create()
        {
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            return View();
        }

        // POST: AllProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Rate,ProductTypeId,AluminumColorId,AluminumGageId")] AllProduct allProduct)
        {
            if (ModelState.IsValid)
            {
                allProduct.AllProductId = MaintenanceCounterRepository.GetId(_context, "AllProductId", "AllProduct");
                allProduct.Deleted = false;
                allProduct.CreatedDate = DateTime.Now;
                allProduct.CreatedById = 100;
                _context.Add(allProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            return View(allProduct);
        }

        // GET: AllProduct/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProduct = await _context.AllProducts.FindAsync(id);
            if (allProduct == null)
            {
                return NotFound();
            }
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            return View(allProduct);
        }


        // POST: AllProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AllProductId,Name,Rate,ProductTypeId,AluminumColorId,AluminumGageId")] AllProduct allProduct)
        {
            if (id != allProduct.AllProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    allProduct.ModifiedById = 100;
                    allProduct.ModifiedDate = DateTime.Now;
                    _context.Update(allProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllProductExists(allProduct.AllProductId))
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
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            return View(allProduct);
        }
        [HttpGet]
        public async Task<IActionResult> EditOnlyPrice(long id, float rate)
        {
            AllProduct allProduct = new AllProduct();
            try
            {
                allProduct = _context.AllProducts.Find(id);
                allProduct.Rate = rate;
                allProduct.ModifiedById = 100;
                allProduct.ModifiedDate = DateTime.Now;
                _context.Update(allProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { }
            return RedirectToAction(nameof(Index));
        }


        // GET: AllProduct/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProduct = await _context.AllProducts
                .Include(a => a.AluminumColor)
                .Include(a => a.AluminumGage)
                .Include(a => a.ProductType)
                .FirstOrDefaultAsync(m => m.AllProductId == id);
            if (allProduct == null)
            {
                return NotFound();
            }

            return View(allProduct);
        }

        // POST: AllProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var allProduct = await _context.AllProducts.FindAsync(id);
            allProduct.Deleted = true;
            allProduct.ModifiedById = 100;
            allProduct.ModifiedDate = DateTime.Now;
            _context.AllProducts.Update(allProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllProductExists(long id)
        {
            return _context.AllProducts.Any(e => e.AllProductId == id);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string category, string query)
        {

            if (category == "name")
            {
                var zedxContext = _context.AllProducts.Where(a => a.Name == query && a.Deleted == false)
                      .Include(a => a.AluminumColor)
                      .Include(a => a.AluminumGage)
                      .Include(a => a.ProductType);
                return View(await zedxContext.ToListAsync());
            }
            else if (category == "Aluminum")
            {
                var zedxContext = _context.AllProducts.Where(a =>  a.Deleted == false)
                  .Include(a => a.AluminumColor)
                  .Include(a => a.AluminumGage)
                  .Include(a => a.ProductType).Where(a => a.Name == "Aluminum");
                return View(await zedxContext.ToListAsync());
            }
            else if (category == "Thickness")
            {
                var zedxContext = _context.AllProducts.Where(a =>  a.Deleted == false)
                  .Include(a => a.AluminumColor)
                  .Include(a => a.AluminumGage).Where(a => a.Name == query)
                  .Include(a => a.ProductType);
                return View(await zedxContext.ToListAsync());
            }
            else if (category == "Color")
            {
                var zedxContext = _context.AllProducts.Where( a =>  a.Deleted == false)
                  .Include(a => a.AluminumColor).Where(a => a.Name == query)
                  .Include(a => a.AluminumGage)
                  .Include(a => a.ProductType);
                return View(await zedxContext.ToListAsync());
            }
            else if (category == "Glass")
            {
                var zedxContext = _context.AllProducts.Where(a => a.Deleted == false)
                  .Include(a => a.AluminumColor)
                  .Include(a => a.AluminumGage)
                  .Include(a => a.ProductType).Where(a => a.Name == "Glass");
                return View(await zedxContext.ToListAsync());
            }

            else if (category == "Hardware")
            {
                var zedxContext = _context.AllProducts.Where(a =>  a.Deleted == false)
                  .Include(a => a.AluminumColor)
                  .Include(a => a.AluminumGage)
                  .Include(a => a.ProductType).Where(a => a.Name == "Hardware");
                return View(await zedxContext.ToListAsync());
            }
            else
            {
                var zedxContext = _context.AllProducts.Include(a => a.AluminumColor).Include(a => a.AluminumGage).Include(a => a.ProductType);
                return View(await zedxContext.ToListAsync());

            }




        }
    }
}
