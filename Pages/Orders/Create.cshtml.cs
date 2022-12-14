using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerOrderItem.Data;
using CustomerOrderItem.Models;

namespace CustomerOrderItem.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly CustomerOrderItem.Data.ORDContext _context;

        public CreateModel(CustomerOrderItem.Data.ORDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ProductName");
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
