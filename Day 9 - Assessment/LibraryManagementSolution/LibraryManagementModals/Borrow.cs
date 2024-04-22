using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentModals
{
    public class Borrow : IEquatable<Borrow>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status {  get; set; }


        public Borrow()
        {
            Id = 0;
            CustomerId = 0;
            BookId = 0;
            BorrowedDate = DateTime.MinValue;
            ReturnDate = DateTime.MinValue;
            Status = "Borrowed";
        }
        public Borrow(int id) {
            Id = id;
        }
        public Borrow(int id, int customerId, int bookId, string status) : this(id)
        {
            CustomerId = customerId;
            BookId = bookId;
            BorrowedDate = new DateTime();
            Status = status;
        }

        public void BorrowDetailsFromTheConsole()
        {
            Console.WriteLine("Enter your Customer Id: ");
            CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your BookId");
            BookId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1. Return 2. Borrow ");
            int response = Convert.ToInt32(Console.ReadLine());
            if(response == 1) { 
                Status = "Returned";
                ReturnDate = DateTime.Now;
            }
            else if(response == 2) { 
                Status = "Borrowed";
                BorrowedDate = DateTime.Now;
            }
            else Console.WriteLine("Invalid Response");
        }

        public bool Equals(Borrow? other)
        {
            return Id.Equals(other.Id);
        }
    }
}
