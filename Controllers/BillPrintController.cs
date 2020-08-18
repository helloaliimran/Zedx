using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zedx.Data;
using Zedx.Models;
using Zedx.Models.ViewModel;

namespace Zedx.Controllers
{
    public class BillPrintController : Controller
    {
        private readonly ZedxContext _context;

        public BillPrintController(ZedxContext context)
        {
            _context = context;
        }
        public IActionResult Index(long id)
        {
            BillandBillDetail billandBillDetail = new BillandBillDetail();
            billandBillDetail.BillDetail = new BillDetail();
            billandBillDetail.BillDetail.BillDetailId = 0;
            billandBillDetail.Bill = _context.Bill
                .FirstOrDefault(x => x.BillId == id);
            billandBillDetail.Bill.Customers=_context.Customers.FirstOrDefault(x => x.CustomerId == billandBillDetail.Bill.CustomerId);
            
            billandBillDetail.lbillDetail =
                    _context.BillDetail
                   .Include(x => x.AllProduct)
                   .Include(x => x.AluminumColor)
                   .Include(x => x.AluminumGage)
                   .Where(x => x.BillId == id && x.Deleted == false)
                   .ToList();
            return View(billandBillDetail);
        }
    }
}
