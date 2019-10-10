using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dogs1.Data;

namespace Dogs1.Pages.Dog
{
    public class DetailsModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public DetailsModel(Dogs1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dogs Dogs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dogs = await _context.Dogs
                .Include(d => d.Petss).FirstOrDefaultAsync(m => m.DID == id);

            if (Dogs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
