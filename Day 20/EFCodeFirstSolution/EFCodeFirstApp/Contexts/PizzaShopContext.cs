using EFCodeFirstApp.Modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstApp.Contexts
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=CB66JX3\\DEMOINSTANCE;Initial Catalog=dbPizzaShop;Integrated Security=true;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
