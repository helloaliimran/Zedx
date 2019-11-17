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
    public class AluminumGageController : Controller
    {
        private readonly ZedxContext _context;

        public AluminumGageController(ZedxContext context)
        {
            _context = context;
        }

        // GET: AluminumGage
        public async Task<IActionResult> Index()
        {
            return View(await _context.AluminumGage.ToListAsync());
        }

        // GET: AluminumGage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumGage = await _context.AluminumGage
                .FirstOrDefaultAsync(m => m.AluminumGageId == id);
            if (aluminumGage == null)
            {
                return NotFound();
            }

            return View(aluminumGage);
        }

        // GET: AluminumGage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AluminumGage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AluminumGageId,Name")] AluminumGage aluminumGage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluminumGage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluminumGage);
        }

        // GET: AluminumGage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumGage = await _context.AluminumGage.FindAsync(id);
            if (aluminumGage == null)
            {
                return NotFound();
            }
            return View(aluminumGage);
        }

        // POST: AluminumGage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AluminumGageId,Name")] AluminumGage aluminumGage)
        {
            if (id != aluminumGage.AluminumGageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluminumGage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluminumGageExists(aluminumGage.AluminumGageId))
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
            return View(aluminumGage);
        }

        // GET: AluminumGage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumGage = await _context.AluminumGage
                .FirstOrDefaultAsync(m => m.AluminumGageId == id);
            if (aluminumGage == null)
            {
                return NotFound();
            }

            return View(aluminumGage);
        }

        // POST: AluminumGage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluminumGage = await _context.AluminumGage.FindAsync(id);
            _context.AluminumGage.Remove(aluminumGage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluminumGageExists(int id)
        {
            return _context.AluminumGage.Any(e => e.AluminumGageId == id);
        }
    }
}
