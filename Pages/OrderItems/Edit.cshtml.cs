using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerOrderItem.Data;
using CustomerOrderItem.Models;

namespace CustomerOrderItem.Pages.OrderItems
{
    public class EditModel : PageModel
    {
        private readonly CustomerOrderItem.Data.OrderItemContext _context;

        public EditModel(CustomerOrderItem.Data.OrderItemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerOrderItem1 CustomerOrderItem1 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.COIs == null)
            {
                return NotFound();
            }

            var customerorderitem1 =  await _context.COIs.FirstOrDefaultAsync(m => m.ID == id);
            if (customerorderitem1 == null)
            {
                return NotFound();
            }
            CustomerOrderItem1 = customerorderitem1;
           ViewData["OrderID"] = new SelectList(_context.Set<Order>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerOrderItem1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOrderItem1Exists(CustomerOrderItem1.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerOrderItem1Exists(int id)
        {
          return _context.COIs.Any(e => e.ID == id);
        }
    }
}
