using ConsoleBoilerplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace ConsoleBoilerplate.Data
{
    public class AppDbContext : DbContext
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
    }
}
