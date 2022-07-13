using ConsoleBoilerplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsoleBoilerplate.Data
{
    internal class AppDbContext : DbContext, IDesignTimeDbContextFactory<AppDbContext>
    {
        private bool _isMigration;
        private IConfiguration _configuration;

        public DbSet<ParentItem> ParentItems;

        public AppDbContext()
        { }

        public AppDbContext(IConfiguration configuration)
        {
            _isMigration = true;
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = _configuration.GetConnectionString("DefaultConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(conn ?? "ConsoleBoilerplate.db");
            }
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // pass your design time connection string here
            string conn = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(conn ?? "ConsoleBoilerplate.db");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
