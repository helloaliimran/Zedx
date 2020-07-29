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
        public async Task<IActionResult> Create([Bind("AllProductId,Name,Rate,CreatedById,ModifiedById,CreatedDate,ModifiedDate,Deleted,ProductTypeId,AluminumColorId,AluminumGageId")] AllProduct allProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", allProduct.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", allProduct.AluminumGageId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "ProductTypeId", allProduct.ProductTypeId);
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
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", allProduct.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", allProduct.AluminumGageId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "ProductTypeId", allProduct.ProductTypeId);
            return View(allProduct);
        }

        // POST: AllProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProductId,Name,Rate,CreatedById,ModifiedById,CreatedDate,ModifiedDate,Deleted,ProductTypeId,AluminumColorId,AluminumGageId")] AllProduct allProduct)
        {
            if (id != allProduct.AllProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", allProduct.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", allProduct.AluminumGageId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "ProductTypeId", allProduct.ProductTypeId);
            return View(allProduct);
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
            _context.AllProducts.Remove(allProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllProductExists(long id)
        {
            return _context.AllProducts.Any(e => e.AllProductId == id);
        }
    }
}
