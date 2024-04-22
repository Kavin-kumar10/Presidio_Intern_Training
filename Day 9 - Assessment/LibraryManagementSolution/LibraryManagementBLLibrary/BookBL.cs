using LibraryManagementDALLibrary;
using LibraryManagmentModals;

namespace LibraryManagementBLLibrary
{
    public class BookBL : IBookServices
    {
        readonly IRepository<int,Book> _bookRepository;
        public BookBL()
        {
            _bookRepository = new BookRepository();
        }
        public Book AddBook(Book item)
        {
            var result = _bookRepository.Add(item); 
            if(result != null)
            {
                Console.WriteLine(result);
                return result;
            }
            return null;
            throw new NotImplementedException();
        }

        public Book DeleteBook(int id)
        {
         
            var book = _bookRepository.Get(id);
            if(book != null) { _bookRepository.Delete(id); }
            return null;
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            var result = _bookRepository.GetAll();
            if(result != null) { return result; }
            return null;
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.Get(id);
            if(result != null) { return result;}
            return null;
            throw new NotImplementedException();
        }

        public Book UpdateBook(Book item)
        {
            var book = _bookRepository.Get(item.Id);
            if(book != null) { book = item ; }
            return book;
            throw new NotImplementedException();
        }

        public Book Borrowing(Book item)
        {
            var book = _bookRepository.Get(item.Id) ;
            if(book != null)
            {
                book.Count--;
                _bookRepository.Update(book);
            }
            return null;
        }

        public Book Returning(Book item)
        {
            var book = _bookRepository.Get(item.Id);
            if( book != null )
            {
                book.Count++;
                _bookRepository.Update(book);
            }
            return null;
        }
    }
}
