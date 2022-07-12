using ConsoleBoilerplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleBoilerplate.Data
{
    internal class AppDbContext : DbContext
    {
        private bool _isMigration;
        private IConfiguration _configuration;

        public DbSet<ParentItem> ParentItems;

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
            if (_isMigration)
            {
                string conn = _configuration.GetConnectionString("DefaultConnection");
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(conn);
                }
            }
        }
    }
}
