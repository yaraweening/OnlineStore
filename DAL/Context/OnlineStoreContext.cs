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
                optionsBuilder.UseSqlServer("Server=project-yara.database.windows.net;Database=OnlineStoreDB;User Id=yara-admin;Password=Y@r@.123@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Forum> Forums { get; set; }
    }
}
