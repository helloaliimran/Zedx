using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;
using Zedx.Models.ViewModel;

namespace Zedx.Controllers
{
    public class ProductAluminumController : Controller
    {
        private readonly ZedxContext _context;

        public ProductAluminumController(ZedxContext context)
        {
            _context = context;
        }

        // GET: ProductAluminum
        public async Task<IActionResult> Index()
        {


            return View(await _context.ProductAluminum.ToListAsync());
        }

        // GET: ProductAluminum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAluminum = await _context.ProductAluminum
                .FirstOrDefaultAsync(m => m.ProductAluminumId == id);
            if (productAluminum == null)
            {
                return NotFound();
            }

            return View(productAluminum);
        }

        // GET: ProductAluminum/Create
        public IActionResult Create()
        {
            AluminumColorGageViewModel aluminumColorGageViewModel = new AluminumColorGageViewModel();
           
            aluminumColorGageViewModel.listaluminumColor = 
            (from aluminumColor in _context.AluminumColor select aluminumColor).ToList()
            .Select(u=> new SelectListItem{
                Text=u.Name,
                Value=u.AluminumColorId.ToString()
            });

            aluminumColorGageViewModel.listaluminumGage =
            (from aluminumGage in _context.AluminumGage select aluminumGage).ToList()
            .Select(u=> new SelectListItem{
                Text=u.Name,
                Value=u.AluminumGageId.ToString()
            });
            
            return View(aluminumColorGageViewModel);
        }

        // POST: ProductAluminum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductAluminumId,ProductAluminumName,RatePerFeet,colorId,GageId")] ProductAluminum productAluminum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAluminum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productAluminum);
        }

        // GET: ProductAluminum/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAluminum = await _context.ProductAluminum.FindAsync(id);
            if (productAluminum == null)
            {
                return NotFound();
            }
            return View(productAluminum);
        }

        // POST: ProductAluminum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProductAluminumId,ProductAluminumName,RatePerFeet,colorId,GageId")] ProductAluminum productAluminum)
        {
            if (id != productAluminum.ProductAluminumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAluminum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAluminumExists(productAluminum.ProductAluminumId))
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
            return View(productAluminum);
        }

        // GET: ProductAluminum/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAluminum = await _context.ProductAluminum
                .FirstOrDefaultAsync(m => m.ProductAluminumId == id);
            if (productAluminum == null)
            {
                return NotFound();
            }

            return View(productAluminum);
        }

        // POST: ProductAluminum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productAluminum = await _context.ProductAluminum.FindAsync(id);
            _context.ProductAluminum.Remove(productAluminum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductAluminumExists(long id)
        {
            return _context.ProductAluminum.Any(e => e.ProductAluminumId == id);
        }
    }
}
