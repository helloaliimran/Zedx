using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zedx.Data;
using Microsoft.AspNetCore.Mvc;


namespace Zedx.Models.BL.Bill
{
    public class BillFormLogic
    {
        private readonly ZedxContext _context;
        public BillFormLogic(ZedxContext context)
        {
            _context = context;
        }
        public void loadDDL()
        {
            
        }
        
    }
}
