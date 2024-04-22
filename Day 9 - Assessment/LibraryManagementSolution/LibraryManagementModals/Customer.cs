using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModals
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public DateTime Dob {  get; set; }
        public List<int> BooksTaken { get; set; }

        public Customer() {
            Id = 0;
            Name = string.Empty;
            Dob = DateTime.Now;
            BooksTaken = new List<int>();
        }

        public Customer(int id)
        {
            Id = id;
        }

        public Customer(int id, string name, DateTime dob, List<int> booksTaken)
        {
            Id = id;
            Name = name;
            Dob = dob;
            BooksTaken = booksTaken;
        }

        public Customer GetCustomerFromTheConsole()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Your Name : ");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Enter Your Date of Birth : ");
            customer.Dob = DateTime.Parse(Console.ReadLine());
            customer.BooksTaken = new List<int>();
            return customer;
        }

        public override string ToString()
        {
            return $"Customer ID: {Id}\n" +
                   $"Customer Name: {Name}\n" +
                   $"Date of Birth: {Dob:yyyy-MM-dd}\n" + 
                   $"Books Taken Count: {BooksTaken.Count} \n"+
                   $"Books taken: \n"+
                   $"{string.Join(",",BooksTaken)}";
        }
    }
}
