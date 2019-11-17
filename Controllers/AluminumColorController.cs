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
    public class AluminumColorController : Controller
    {
        private readonly ZedxContext _context;

        public AluminumColorController(ZedxContext context)
        {
            _context = context;
        }

        // GET: AluminumColor
        public async Task<IActionResult> Index()
        {
            return View(await _context.AluminumColor.ToListAsync());
        }

        // GET: AluminumColor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumColor = await _context.AluminumColor
                .FirstOrDefaultAsync(m => m.AluminumColorId == id);
            if (aluminumColor == null)
            {
                return NotFound();
            }

            return View(aluminumColor);
        }

        // GET: AluminumColor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AluminumColor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AluminumColorId,Name")] AluminumColor aluminumColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluminumColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluminumColor);
        }

        // GET: AluminumColor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumColor = await _context.AluminumColor.FindAsync(id);
            if (aluminumColor == null)
            {
                return NotFound();
            }
            return View(aluminumColor);
        }

        // POST: AluminumColor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AluminumColorId,Name")] AluminumColor aluminumColor)
        {
            if (id != aluminumColor.AluminumColorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluminumColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluminumColorExists(aluminumColor.AluminumColorId))
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
            return View(aluminumColor);
        }

        // GET: AluminumColor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluminumColor = await _context.AluminumColor
                .FirstOrDefaultAsync(m => m.AluminumColorId == id);
            if (aluminumColor == null)
            {
                return NotFound();
            }

            return View(aluminumColor);
        }

        // POST: AluminumColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluminumColor = await _context.AluminumColor.FindAsync(id);
            _context.AluminumColor.Remove(aluminumColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluminumColorExists(int id)
        {
            return _context.AluminumColor.Any(e => e.AluminumColorId == id);
        }
    }
}
