using Microsoft.EntityFrameworkCore;
using Zedx.Models;

namespace Zedx.Data
{
    public class ZedxContext : DbContext
    {
        public ZedxContext (DbContextOptions<ZedxContext> options)
            : base(options)
        {
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<ProductAluminum> ProductAluminum { get; set; }
        public DbSet<AluminumGage> AluminumGage{get;set;}
        public DbSet<AluminumColor> AluminumColor{get;set;}

    }
}