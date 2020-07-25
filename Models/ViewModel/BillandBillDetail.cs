using System.Collections.Generic;

namespace Zedx.Models.ViewModel
{
    public class BillandBillDetail
    {
        public Bill Bill { get; set; }
        public BillDetail BillDetail { get; set; }
        public List<BillDetail> lbillDetail { get; set; }
    }
}
