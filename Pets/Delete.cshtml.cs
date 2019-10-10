using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dogs1.Data;

namespace Dogs1.Pages.Pets
{
    public class DeleteModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public DeleteModel(Dogs1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Petstores Petstores { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Petstores = await _context.Petstores.FirstOrDefaultAsync(m => m.PSID == id);

            if (Petstores == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Petstores = await _context.Petstores.FindAsync(id);

            if (Petstores != null)
            {
                _context.Petstores.Remove(Petstores);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
