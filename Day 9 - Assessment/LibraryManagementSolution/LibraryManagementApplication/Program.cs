using LibraryManagementBLLibrary;
using LibraryManagmentModals;

namespace LibraryManagementApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(123, "Them Empire", "Rajan", "History",new DateTime(1999,11,10), 10, "Available");
            BookBL bookBL = new BookBL();
            bookBL.AddBook(book);
            List<Book> myBook = bookBL.GetAllBooks();
            for(int ind = 0;ind < myBook.Count; ind++)
            {
                Console.WriteLine(myBook[ind].Id);
            }

        }
    }
}
