using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PizzahutApiApplication.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string type { get; set; }
        public int count { get; set; }
    }
}
