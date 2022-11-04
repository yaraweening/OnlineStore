using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Context
{
    public class OnlineStoreContext : DbContext
    {
        readonly string QUERYSTRING = Environment.GetEnvironmentVariable("SQLQUERYSTRING");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(QUERYSTRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
