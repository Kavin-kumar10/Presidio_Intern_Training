using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentModals
{
    public class Borrow : IEquatable<Borrow>
    {
        public int Id { get; set; }
        public int CustomerName { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status {  get; set; }

        public Borrow(int id) {
            Id = id;
        }
        public Borrow(int id, int customerName, int bookId, DateTime borrowedDate, DateTime returnDate, string status) : this(id)
        {
            CustomerName = customerName;
            BookId = bookId;
            BorrowedDate = borrowedDate;
            ReturnDate = returnDate;
            Status = status;
        }

        public bool Equals(Borrow? other)
        {
            return Id.Equals(other.Id);
        }
    }
}
