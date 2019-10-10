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
    public class IndexModel : PageModel
    {
        private readonly Dogs1.Data.ApplicationDbContext _context;

        public IndexModel(Dogs1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dogs> Dogs { get;set; }

        public async Task OnGetAsync()
        {
            Dogs = await _context.Dogs
                .Include(d => d.Petss).ToListAsync();
        }
    }
}
