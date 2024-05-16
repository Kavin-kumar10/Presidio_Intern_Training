using Microsoft.EntityFrameworkCore;
using PizzahutApiApplication.Models;

namespace PizzahutApiApplication.Context
{
    public class PizzahutContext:DbContext
    {
        public PizzahutContext(DbContextOptions options):base(options) { }
        public DbSet<Pizza> Pizzas {  get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaId = 101,Name = "American",Description="Spicy,Hot and Salty", count = 10,type = "Non veg"},
                new Pizza() { PizzaId = 102, Name = "Asian Manjurian", Description = "Asian Style Chicken", count = 9, type = "Non veg" },
                new Pizza() { PizzaId = 103, Name = "Veg Pizza", Description = "Chilly Spicy Pizza", count = 12, type = "Veg" }
            );
        }

    }
}
