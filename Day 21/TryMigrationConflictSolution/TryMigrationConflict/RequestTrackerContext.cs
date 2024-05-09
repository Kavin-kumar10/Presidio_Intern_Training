using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMigrationConflict
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=CB66JX3\DEMOINSTANCE;Initial Catalog=dbRequestDemo;Integrated Security=true;");
        }
        public DbSet<Request> Requests { get; set;}
        public DbSet<Employee> Employees { get; set;}
    }
}
