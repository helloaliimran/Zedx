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
    public class MaintenanceCounterController : Controller
    {
        private readonly ZedxContext _context;

        public MaintenanceCounterController(ZedxContext context)
        {
            _context = context;
        }

        // GET: MaintenanceCounter
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaintenanceCounter.ToListAsync());
        }

        // GET: MaintenanceCounter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceCounter = await _context.MaintenanceCounter
                .FirstOrDefaultAsync(m => m.MaintenanceCounterId == id);
            if (maintenanceCounter == null)
            {
                return NotFound();
            }

            return View(maintenanceCounter);
        }

        // GET: MaintenanceCounter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceCounter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintenanceCounterId,ColumnName,TableName,Counter")] MaintenanceCounter maintenanceCounter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceCounter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceCounter);
        }

        // GET: MaintenanceCounter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceCounter = await _context.MaintenanceCounter.FindAsync(id);
            if (maintenanceCounter == null)
            {
                return NotFound();
            }
            return View(maintenanceCounter);
        }

        // POST: MaintenanceCounter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaintenanceCounterId,ColumnName,TableName,Counter")] MaintenanceCounter maintenanceCounter)
        {
            if (id != maintenanceCounter.MaintenanceCounterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceCounter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceCounterExists(maintenanceCounter.MaintenanceCounterId))
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
            return View(maintenanceCounter);
        }

        // GET: MaintenanceCounter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceCounter = await _context.MaintenanceCounter
                .FirstOrDefaultAsync(m => m.MaintenanceCounterId == id);
            if (maintenanceCounter == null)
            {
                return NotFound();
            }

            return View(maintenanceCounter);
        }

        // POST: MaintenanceCounter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceCounter = await _context.MaintenanceCounter.FindAsync(id);
            _context.MaintenanceCounter.Remove(maintenanceCounter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceCounterExists(int id)
        {
            return _context.MaintenanceCounter.Any(e => e.MaintenanceCounterId == id);
        }
    }
}
