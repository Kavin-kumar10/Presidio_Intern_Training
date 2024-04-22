using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface IBookServices 
    {
        List<Book> GetAllBooks();
        Book AddBook(Book item);
        Book DeleteBook(int id);
        Book GetBookById(int id);
        Book UpdateBook(Book item);
        Book Borrowing(Book item);
        Book Returning(Book item);
    }
}
