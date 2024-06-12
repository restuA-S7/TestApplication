using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

    }
}
