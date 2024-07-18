using AzureLearnApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureLearnApplication.Context
{
    public class DbProductContext : DbContext
    {
        public DbProductContext(DbContextOptions<DbProductContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
