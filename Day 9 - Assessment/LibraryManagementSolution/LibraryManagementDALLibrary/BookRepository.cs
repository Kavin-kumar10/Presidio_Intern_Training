using LibraryManagmentModals;

namespace LibraryManagementDALLibrary
{
    public class BookRepository : IRepository<int, Book>
    {
        readonly Dictionary<int, Book> _books;

        public BookRepository()
        {
            _books = new Dictionary<int, Book>();
        }

        public int GenerateId()
        {
            if (_books.Count == 0) return 1;
            int max = _books.Keys.Max();
            return ++max;
        }

        public Book Add(Book item)
        {
            if (_books.ContainsKey(item.Id)) return null;
            item.Id = GenerateId();
            _books.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }

        public Book Delete(int Key)
        {
            if (_books.ContainsKey(Key))
                _books.Remove(Key);
            else
                return null;
            throw new NotImplementedException();
        }

        public Book Get(int Key)
        {
            if(_books.ContainsKey(Key))
                return _books[Key];
            return null;
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _books.Values.ToList();
            throw new NotImplementedException();
        }

        public Book Update(Book item)
        {
            if (_books.ContainsKey(item.Id))
            {
                _books[item.Id] = item;
            }
            throw new NotImplementedException();
        }
    }
}
