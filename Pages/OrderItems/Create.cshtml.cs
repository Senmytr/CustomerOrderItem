using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerOrderItem.Data;
using CustomerOrderItem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderItem.Pages.OrderItems
{
    public class CreateModel : PageModel
    {
        private readonly CustomerOrderItem.Data.OrderItemContext _context;

        public CreateModel(CustomerOrderItem.Data.OrderItemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
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
            ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public CustomerOrderItem1 CustomerOrderItem1 { get; set; }
        public IList<Order> Order { get; set; } = default!;
        public IList<Customer> Customer { get; set; } = default!;
        public IList<Product> Product { get; set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    if (_context.Orders != null)
        //    {
        //        Order = await _context.Orders.ToListAsync();
        //    }
        //    if (_context.Customers != null)
        //    {
        //        Customer = await _context.Customers.ToListAsync();
        //    }
        //    if (_context.Products != null)
        //    {
        //        Product = await _context.Products.ToListAsync();
        //    }
        //}


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.COIs.Add(CustomerOrderItem1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
