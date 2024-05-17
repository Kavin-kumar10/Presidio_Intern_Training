using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzahutApiApplication.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public virtual IEnumerable<Pizza> OrderList { get; set; }
    }
}
