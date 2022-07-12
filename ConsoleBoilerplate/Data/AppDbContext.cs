using ConsoleBoilerplate.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleBoilerplate.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<ParentItem> ParentItems;
    }
}
