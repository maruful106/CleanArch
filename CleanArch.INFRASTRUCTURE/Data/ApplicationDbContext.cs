using CleanArch.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        public DbSet<ProductEntity> Products { get; set; }
    }
}
