using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerOrderItem.Data;
using CustomerOrderItem.Models;

namespace CustomerOrderItem.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly CustomerOrderItem.Data.ORDContext _context;

        public IndexModel(CustomerOrderItem.Data.ORDContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;
        public IList<Customer> Customer { get; set; } = default!;
        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders.ToListAsync();
            }
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
