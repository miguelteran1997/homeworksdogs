using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dogs1.Data;

namespace Dogs1.Pages.Pets
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
            return Page();
        }

        [BindProperty]
        public Petstores Petstores { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Petstores.Add(Petstores);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}