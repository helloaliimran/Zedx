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
using Zedx.Models.DTO;
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
        public void OpenNewForm(BillandBillDetail billandBillDetail)
        {
            BillDetail billDetail = new BillDetail();
            billDetail.BillId = 0;
            billandBillDetail.BillDetail = billDetail;
            Bill bill = new Bill();
            bill.BillId = 0;
            billandBillDetail.Bill = bill;
        }
        public void OpenOldBill(long billId, BillRequest billRequest)
        {
            billRequest.BillId = billId;
            LoadBillProduct(billRequest);
        }
        public async Task<IActionResult> Creates(long? billId)
        {
            ViewData["AluminumColorId"] = new SelectList(_context.AluminumColor, "AluminumColorId", "Name");
            ViewData["AluminumGageId"] = new SelectList(_context.AluminumGage, "AluminumGageId", "Name");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "ProductTypeId", "name");
            ViewData["Bill"] = new SelectList(_context.Bill.Where(x => x.Deleted == false).OrderByDescending(x => x.BillId), "BillId", "BillId");


            BillandBillDetail billandBillDetail = new BillandBillDetail();
            BillDetail billDetail = new BillDetail();

            if (billId == null)
            {
                BillRequest billRequest = new BillRequest();
                return View(billRequest);
            }
            else
            {
                BillRequest billRequest = new BillRequest();
                OpenOldBill((long)billId, billRequest);
                return View(billRequest);
                
                //return PartialView("_BillDetails", billRequest);
            }


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creates(BillRequest billrequest)
        {
            if (ModelState.IsValid)
            {
                bool IsNew = false;
                try
                {

                    #region First Entry New Bill Creation

                    if (billrequest.BillId == 0)
                    {
                        IsNew = true;
                        Bill bill = new Bill();
                        bill.BillId = MaintenanceCounterRepository.GetId(_context, "BillId", "Bill");
                        bill.CustomerId = billrequest.CustomerId;
                        bill.TotalDiscount = billrequest.DiscountedAmount;
                        bill.NetAmount = billrequest.NetAmount;
                        bill.Total = billrequest.AmountToBePaid;
                        bill.CreatedById = 100;
                        bill.CreatedDate = DateTime.Now;
                        _context.Add(bill);
                        await _context.SaveChangesAsync();
                        billrequest.BillId = bill.BillId;
                    }

                    #endregion

                    #region New Product Entry In Bill Detail
                    if (billrequest.BillDetailId == 0)
                    {
                        BillDetail billDetail = new BillDetail();
                        billDetail.BillDetailId = MaintenanceCounterRepository.GetId(_context, "BillDetailId", "BillDetail");
                        billDetail.CreatedById = 100;
                        billDetail.CreatedDate = DateTime.Now;
                        billDetail.BillId = billrequest.BillId;
                        billDetail.AluminumColorId = billrequest.AluminumColorId;
                        billDetail.AluminumGageId = billrequest.AluminumGageId;
                        billDetail.AllProductId = billrequest.AllProductId;
                        billDetail.Rate = billrequest.Rate;
                        billDetail.Discount = billrequest.Discount;
                        billDetail.Feet = billrequest.Feet;
                        billDetail.Quantity = billrequest.Quantity;
                        billDetail.TotalFeet = billrequest.TotalFeet;
                        billDetail.NetAmount = billrequest.NetAmount;
                        billDetail.DiscountedAmount = billrequest.DiscountedAmount;
                        billDetail.AmountToBePaid = billrequest.AmountToBePaid;
                        billDetail.SheetHeight = billrequest.SheetHeight;
                        billDetail.SheetWidth = billrequest.SheetWidth;

                        _context.Add(billDetail);
                        await _context.SaveChangesAsync();

                    }
                    #endregion

                    #region Update Existing bill Product 
                    else
                    {
                        BillDetail billDetail = new BillDetail();
                        billDetail.BillDetailId = billrequest.BillDetailId;
                        billDetail.ModifiedById = 100;
                        billDetail.ModifiedDate = DateTime.Now;
                        billDetail.BillId = billrequest.BillId;
                        billDetail.AluminumColorId = billrequest.AluminumColorId;
                        billDetail.AluminumGageId = billrequest.AluminumGageId;
                        billDetail.AllProductId = billrequest.AllProductId;
                        billDetail.Rate = billrequest.Rate;
                        billDetail.Discount = billrequest.Discount;
                        billDetail.Feet = billrequest.Feet;
                        billDetail.Quantity = billrequest.Quantity;
                        billDetail.TotalFeet = billrequest.TotalFeet;
                        billDetail.NetAmount = billrequest.NetAmount;
                        billDetail.DiscountedAmount = billrequest.DiscountedAmount;
                        billDetail.AmountToBePaid = billrequest.AmountToBePaid;
                        billDetail.SheetHeight = billrequest.SheetHeight;
                        billDetail.SheetWidth = billrequest.SheetWidth;

                        _context.Update(billDetail);
                        await _context.SaveChangesAsync();

                    }
                    #endregion

                    #region  Bill update
                    if (!IsNew)
                    {
                        Bill bill = new Bill();
                        bill = CalculateBill(billrequest.BillId);
                        bill.CustomerId = billrequest.CustomerId;
                        bill.ModifiedDate = DateTime.Now;
                        bill.ModifiedById = 100;
                        _context.Update(bill);
                        await _context.SaveChangesAsync();
                    }

                    #endregion

                    LoadBillProduct(billrequest);

                    #region Load Bill Product List

                   // billrequest.BillProducts = new List<BillProduct>();

                   // var billProducts =
                   //_context.BillDetail
                   //.Include(x => x.AllProduct)
                   //.Include(x => x.AluminumColor)
                   //.Include(x => x.AluminumGage)
                   //.Where(x => x.BillId == billrequest.BillId && x.Deleted == false)
                   //.ToList();

                   // foreach (var item in billProducts)
                   // {
                   //     BillProduct billProduct = new BillProduct();
                   //     billProduct.BillDetailId = item.BillDetailId;
                   //     billProduct.AllProductId = item.AllProductId;
                   //     billProduct.ProductName = item.AllProduct.Name;
                   //     billProduct.GageName = item.AluminumGage.Name;
                   //     billProduct.ColorName = item.AluminumColor.Name;
                   //     billProduct.AluminumGageId = (int)item.AluminumGageId;
                   //     billProduct.AluminumColorId = (int)item.AluminumColorId;
                   //     billProduct.Rate = item.Rate;
                   //     billProduct.Discount = item.Discount;
                   //     billProduct.Feet = item.Feet;
                   //     billProduct.Quantity = item.Quantity;
                   //     billProduct.TotalFeet = item.TotalFeet;
                   //     billProduct.NetAmount = item.NetAmount;
                   //     billProduct.DiscountedAmount = item.DiscountedAmount;
                   //     billProduct.AmountToBePaid = item.AmountToBePaid;
                   //     billProduct.SheetHeight = item.SheetHeight;
                   //     billProduct.SheetWidth = item.SheetWidth;
                   //     billrequest.BillProducts.Add(billProduct);
                   // }
                    #endregion

                    #region get bill latest value 

                  //  var getbill =
                  //_context.Bill
                  //.Where(x => x.BillId == billrequest.BillId && x.Deleted == false)
                  //.FirstOrDefault();

                  //  billrequest.BillId = getbill.BillId;
                  //  billrequest.TotalDiscount = getbill.TotalDiscount;
                  //  billrequest.Total = getbill.Total;
                  //  billrequest.NetAmount = getbill.NetAmount;

                    #endregion

                   return PartialView("_BillDetails", billrequest);

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

        public IActionResult ProductSerach()
        {
            string pName = Request.Query["productName"];
            int pType = int.Parse(Request.Query["productType"]);
            int pColor = int.Parse(Request.Query["aluminumColor"]);
            int pGage = int.Parse(Request.Query["aluminumGage"]);

            #region color logic except Dull all color have same rate
            if (pColor != 1)
            {
                pColor = 2;
            }
            #endregion

            #region gage logic 1.2mm and N gage have same rate
            if (pGage == 1)
            {
                pGage = 2;
            }
            #endregion

            List<AllProduct> result;
            if (pType == 1)
            {
                result = _context.AllProducts
                                               .Include(x => x.AluminumGage)
                                               .Include(x => x.AluminumColor)
                                               .Where(x => (x.Name==pName && x.AluminumColorId == pColor && x.AluminumGageId == pGage)).ToList();
            }
            else
            {
                result = _context.AllProducts
                                             .Include(x => x.ProductType)
                                             .Where(x => x.Name == pName).ToList();
            }
            return PartialView("_ProductSearchResult", result);
        }

        public Bill CalculateBill(long billId)
        {
            Bill bill = _context.Bill.Where(x => x.BillId == billId).FirstOrDefault();
            var result = (from x in _context.BillDetail
                          where x.BillId == bill.BillId && x.Deleted == false
                          group x by 1 into g
                          select new
                          {
                              sumNetAmount = g.Sum(x => x.NetAmount),
                              sumDistcounted = g.Sum(x => x.DiscountedAmount),
                              sumAmountToBePaid = g.Sum(x => x.AmountToBePaid)
                          }).FirstOrDefault();
            bill.NetAmount = result.sumNetAmount;
            bill.TotalDiscount = result.sumDistcounted;
            bill.Total = result.sumAmountToBePaid;
            return bill;
        }

        public async Task<IActionResult> RemoveProduct()
        {
            long id = int.Parse(Request.Query["BillDetailId"]);
            long billId = int.Parse(Request.Query["BillId"]);
            var billDetail = await _context.BillDetail.FindAsync(id);
            billDetail.Deleted = true;
            billDetail.ModifiedById = 100;
            billDetail.ModifiedDate = DateTime.Now;
            _context.BillDetail.Update(billDetail);
            await _context.SaveChangesAsync();
            Bill bill = new Bill();
            bill = CalculateBill(billId);
            _context.Update(bill);
            await _context.SaveChangesAsync();
            BillRequest billrequest = new BillRequest();
            billrequest.BillId = billId;
            LoadBillProduct(billrequest);

            //BillandBillDetail billandBillDetail = new BillandBillDetail();
            //billandBillDetail.Bill = bill;
            //billandBillDetail.BillDetail = billDetail;
            //billandBillDetail.lbillDetail = _context.BillDetail
            //       .Include(x => x.AllProduct)
            //       .Include(x => x.AluminumColor)
            //       .Include(x => x.AluminumGage)
            //       .Where(x => x.BillId == billDetail.BillId && x.Deleted == false)
            //       .ToList();
            return PartialView("_BillDetails", billrequest);
        }

        public void LoadBillProduct(BillRequest billrequest)
        {
            #region Load Bill Product List
            billrequest.BillProducts = new List<BillProduct>();

            var billProducts =
           _context.BillDetail
           .Include(x => x.AllProduct)
           .Include(x => x.AluminumColor)
           .Include(x => x.AluminumGage)
           .Where(x => x.BillId == billrequest.BillId && x.Deleted == false)
           .ToList();

            foreach (var item in billProducts)
            {
                BillProduct billProduct = new BillProduct();
                billProduct.BillDetailId = item.BillDetailId;
                billProduct.AllProductId = item.AllProductId;
                billProduct.ProductName = item.AllProduct.Name;
                billProduct.GageName = item.AluminumGage.Name;
                billProduct.ColorName = item.AluminumColor.Name;
                billProduct.AluminumGageId = (int)item.AluminumGageId;
                billProduct.AluminumColorId = (int)item.AluminumColorId;
                billProduct.Rate = item.Rate;
                billProduct.Discount = item.Discount;
                billProduct.Feet = item.Feet;
                billProduct.Quantity = item.Quantity;
                billProduct.TotalFeet = item.TotalFeet;
                billProduct.NetAmount = item.NetAmount;
                billProduct.DiscountedAmount = item.DiscountedAmount;
                billProduct.AmountToBePaid = item.AmountToBePaid;
                billProduct.SheetHeight = item.SheetHeight;
                billProduct.SheetWidth = item.SheetWidth;
                billrequest.BillProducts.Add(billProduct);
            }
            #endregion

            var getbill =
               _context.Bill
               .Where(x => x.BillId == billrequest.BillId && x.Deleted == false)
               .FirstOrDefault();

            billrequest.BillId = getbill.BillId;
            billrequest.TotalDiscount = getbill.TotalDiscount;
            billrequest.Total = getbill.Total;
            billrequest.NetAmount = getbill.NetAmount;
            billrequest.CustomerId = getbill.CustomerId;
            billrequest.BillDate = getbill.CreatedDate.ToShortDateString();

            var customer= _context.Customers.Where(x => x.CustomerId == getbill.CustomerId).FirstOrDefault();
            billrequest.CustomerName = customer.CustomerName;
            billrequest.Address = customer.Address;
            billrequest.Number = customer.Number;

        }

        public IActionResult Print(long id)
        {
            BillRequest billRequest = new BillRequest();
            billRequest.BillId = id;
            LoadBillProduct(billRequest);
            return View(billRequest);
        }
    }
}
