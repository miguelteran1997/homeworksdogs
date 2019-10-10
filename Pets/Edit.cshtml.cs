using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dogs1.Data;

namespace Dogs1.Pages.Pets
{
    public class EditModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public EditModel(Dogs1.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Petstores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetstoresExists(Petstores.PSID))
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

        private bool PetstoresExists(int id)
        {
            return _context.Petstores.Any(e => e.PSID == id);
        }
    }
}
