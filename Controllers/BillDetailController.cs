using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;
using Zedx.Models.Common;
using Zedx.Models.ViewModel;

namespace Zedx.Controllers
{
    public class BillDetailController : Controller
    {
        private readonly ZedxContext _context;

        public BillDetailController(ZedxContext context)
        {
            _context = context;
        }

        // GET: BillDetail
        public async Task<IActionResult> Index()
        {
            var zedxContext = _context.BillDetail.Include(b => b.AluminumColor).Include(b => b.AluminumGage).Include(b => b.Bill);
            return View(await zedxContext.ToListAsync());
        }

        // GET: BillDetail/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billDetail = await _context.BillDetail
                .Include(b => b.AluminumColor)
                .Include(b => b.AluminumGage)
                .Include(b => b.Bill)
                .FirstOrDefaultAsync(m => m.BillDetailId == id);
            if (billDetail == null)
            {
                return NotFound();
            }

            return View(billDetail);
        }

        // GET: BillDetail/Create
        public IActionResult Create()
        {
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId");
            ViewData["BillId"] = new SelectList(_context.Bill, "BillId", "BillId");
            return View();
        }
        public IActionResult Creates(long? billId)
        {
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["BillId"] = new SelectList(_context.Bill, "BillId", "BillId");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            BillandBillDetail billandBillDetail = new BillandBillDetail();
            BillDetail billDetail = new BillDetail();
            if (billId == null)
            {
                billDetail.BillId = 0;
                billandBillDetail.BillDetail = billDetail;
                return View(billandBillDetail);
            }
            billDetail.BillId = (long)billId;
            billandBillDetail.BillDetail = billDetail;
            billandBillDetail.Bill = _context.Bill.Where(x => x.BillId == billId).FirstOrDefault();
            billandBillDetail.lbillDetail = _context.BillDetail.Include(x => x.AllProduct).Where(x => x.BillId == billId).ToList();
            return View(billandBillDetail);
        }

        // POST: BillDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillDetailId,ProductId,AluminumColorId,AluminumGageId,Rate,Discount,Feet,Quantity,TotalFeet,NetAmount,DiscountedAmount,AmountToBePaid,BillId,SheetHeight,SheetWidth,CreatedById,ModifiedById,CreatedDate,ModifiedDate,Deleted")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", billDetail.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", billDetail.AluminumGageId);
            ViewData["BillId"] = new SelectList(_context.Bill, "BillId", "BillId", billDetail.BillId);
            return View(billDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creates([Bind("BillDetailId,AluminumColorId,AluminumGageId,Rate,Discount,Feet,Quantity,TotalFeet,NetAmount,DiscountedAmount,AmountToBePaid,BillId,SheetHeight,SheetWidth")] BillDetail billDetail)
        {
           
                if (ModelState.IsValid)
            {
               
                try
                {
                    BillandBillDetail billandBillDetail = new BillandBillDetail();
                    if (billDetail.BillId == 0)
                    {
                        Bill bill = new Bill();
                        bill.BillId = MaintenanceCounterRepository.GetId(_context, "BillId", "Bill");
                        bill.CustomerId = 1;
                        bill.TotalDiscount = 0;
                        bill.NetAmount = 0;
                        bill.Total = 0;
                        bill.CreatedById = 100;
                        bill.CreatedDate = DateTime.Now;
                        _context.Add(bill);
                        await _context.SaveChangesAsync();
                        billDetail.BillId = bill.BillId;
                    }
                    billDetail.BillDetailId = MaintenanceCounterRepository.GetId(_context, "BillId", "Bill");
                    billDetail.CreatedById = 100;
                    billDetail.CreatedDate = DateTime.Now;
                    _context.Add(billDetail);
                    await _context.SaveChangesAsync();
                    billandBillDetail.BillDetail = billDetail;
                    billandBillDetail.Bill = _context.Bill.Where(x => x.BillId == billDetail.BillId).FirstOrDefault();
                    billandBillDetail.lbillDetail =
                        _context.BillDetail.Include(x => x.AllProduct).Include(x => x.AluminumColor).Include(x => x.AluminumGage).
                        Where(x => x.BillId == billDetail.BillId).ToList();
                    return PartialView("_BillDetails", billandBillDetail);
                }
                catch (Exception e) { }
            }


            return View();
        }

        // GET: BillDetail/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billDetail = await _context.BillDetail.FindAsync(id);
            if (billDetail == null)
            {
                return NotFound();
            }
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", billDetail.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", billDetail.AluminumGageId);
            ViewData["BillId"] = new SelectList(_context.Bill, "BillId", "BillId", billDetail.BillId);
            return View(billDetail);
        }

        // POST: BillDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BillDetailId,ProductId,AluminumColorId,AluminumGageId,Rate,Discount,Feet,Quantity,TotalFeet,NetAmount,DiscountedAmount,AmountToBePaid,BillId,SheetHeight,SheetWidth,CreatedById,ModifiedById,CreatedDate,ModifiedDate,Deleted")] BillDetail billDetail)
        {
            if (id != billDetail.BillDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillDetailExists(billDetail.BillDetailId))
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
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "AluminumColorId", billDetail.AluminumColorId);
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "AluminumGageId", billDetail.AluminumGageId);
            ViewData["BillId"] = new SelectList(_context.Bill, "BillId", "BillId", billDetail.BillId);
            return View(billDetail);
        }

        // GET: BillDetail/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billDetail = await _context.BillDetail
                .Include(b => b.AluminumColor)
                .Include(b => b.AluminumGage)
                .Include(b => b.Bill)
                .FirstOrDefaultAsync(m => m.BillDetailId == id);
            if (billDetail == null)
            {
                return NotFound();
            }

            return View(billDetail);
        }

        // POST: BillDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var billDetail = await _context.BillDetail.FindAsync(id);
            _context.BillDetail.Remove(billDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillDetailExists(long id)
        {
            return _context.BillDetail.Any(e => e.BillDetailId == id);
        }

        public IActionResult ProductSerach() {
            string pName = Request.Query["productName"];
            int pType =int.Parse(Request.Query["productType"]);
            int pColor =int.Parse(Request.Query["aluminumColor"]);
            int pGage =int.Parse(Request.Query["aluminumGage"]);
            List<AllProduct> result;
            if (pType == 1)
            {
                 result = _context.AllProducts
                                                .Include(x =>x.AluminumGage)
                                                .Include(x=>x.AluminumColor)
                                                .Where(x => (x.Name == pName && x.AluminumColorId == pColor && x.AluminumGageId == pGage)).ToList();
            }
            else
            {
                result = _context.AllProducts
                                             .Include(x => x.ProductType)
                                             .Where(x => x.Name == pName ).ToList();
            }
            return PartialView("_ProductSearchResult", result);
        }
    }
}
