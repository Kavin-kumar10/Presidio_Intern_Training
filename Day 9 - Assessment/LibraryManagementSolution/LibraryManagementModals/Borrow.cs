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

        public Borrow BorrowDetailsFromTheConsole(int customerId,int bookId)
        {
            Borrow borrow = new Borrow();
            borrow.CustomerId = customerId;
            borrow.BookId = bookId;
            borrow.Status = "Borrowed";
            borrow.BorrowedDate = DateTime.Now;
            return borrow;
        }

        public override string ToString()
        {
            return $"The Customer Id : {CustomerId}" +
                   $"The Book Id : {BookId}" +
                   $"The Borrowed Date : {BorrowedDate}" +
                   $"Status:{Status}" +
                   $"The Return Date : {ReturnDate}";
        }

        public bool Equals(Borrow? other)
        {
            return Id.Equals(other.Id);
        }
    }
}
