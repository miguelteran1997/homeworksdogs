using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dogs1.Data;

namespace Dogs1.Pages.Dog
{
    public class CreateModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public CreateModel(Dogs1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PSID"] = new SelectList(_context.Set<Petstores>(), "PSID", "PSID");
            return Page();
        }

        [BindProperty]
        public Dogs Dogs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dogs.Add(Dogs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}