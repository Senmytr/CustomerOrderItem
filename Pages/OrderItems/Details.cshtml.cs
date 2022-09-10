using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerOrderItem.Data;
using CustomerOrderItem.Models;

namespace CustomerOrderItem.Pages.OrderItems
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerOrderItem.Data.OrderItemContext _context;

        public DetailsModel(CustomerOrderItem.Data.OrderItemContext context)
        {
            _context = context;
        }

      public CustomerOrderItem1 CustomerOrderItem1 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.COIs == null)
            {
                return NotFound();
            }

            var customerorderitem1 = await _context.COIs.FirstOrDefaultAsync(m => m.ID == id);
            if (customerorderitem1 == null)
            {
                return NotFound();
            }
            else 
            {
                CustomerOrderItem1 = customerorderitem1;
            }
            return Page();
        }
    }
}
