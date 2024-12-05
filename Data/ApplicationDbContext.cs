using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zadacha05._12._2024.Data.Models;

namespace Zadacha05._12._2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Products> Products { get; set; }
    }
}
