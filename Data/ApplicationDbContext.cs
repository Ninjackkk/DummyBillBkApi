using BillBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BillBookApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<MyStock> MyStocks { get; set; }

        public DbSet<Inventories> Inventories { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Parties> Parties { get; set; }

        public DbSet<Businesses> Businesses { get; set; }

    }
}
