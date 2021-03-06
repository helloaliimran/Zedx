using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zedx.Models;
using Zedx.Models.ViewModel;

namespace Zedx.Data
{
    public class ZedxContext : IdentityDbContext
    {
        public ZedxContext (DbContextOptions<ZedxContext> options)
            : base(options)
        {
        }
        public  DbSet<MaintenanceCounter> MaintenanceCounter { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<ProductAluminum> ProductAluminum { get; set; }
        public DbSet<AluminumGage> AluminumGage{get;set;}
        public DbSet<AluminumColor> AluminumColor{get;set;}
        public DbSet<AluminumStock> AluminumStock { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<AllProduct> AllProducts { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
        public DbSet<Bill> Bill { get; set; }
    }
}