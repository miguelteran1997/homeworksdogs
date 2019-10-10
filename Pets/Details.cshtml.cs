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
    public class DetailsModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public DetailsModel(Dogs1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
