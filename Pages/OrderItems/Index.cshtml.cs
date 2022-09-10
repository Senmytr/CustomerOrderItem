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
    public class IndexModel : PageModel
    {
        private readonly CustomerOrderItem.Data.OrderItemContext _context;

        public IndexModel(CustomerOrderItem.Data.OrderItemContext context)
        {
            _context = context;
        }

        public IList<CustomerOrderItem1> CustomerOrderItem1 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.COIs != null)
            {
                CustomerOrderItem1 = await _context.COIs
                .Include(c => c.Order).ToListAsync();
            }
        }
    }
}
