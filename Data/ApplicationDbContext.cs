using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dogs1.Data;

namespace Dogs1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dogs1.Data.Dogs> Dogs { get; set; }
        public DbSet<Dogs1.Data.Petstores> Petstores { get; set; }
    }
}
