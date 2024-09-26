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
    }
}
