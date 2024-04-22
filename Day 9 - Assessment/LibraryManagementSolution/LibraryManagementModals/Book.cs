namespace LibraryManagmentModals
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }

        public Book()
        {
            Id = 0;
            Title = string.Empty;
            Author = string.Empty;
            Genre = string.Empty;
            PublicationDate = DateTime.MinValue;
            Count = 0;
            Status = string.Empty;
        }

        public Book(int id)
        {
            Id = id;
        }
        public Book(int id, string title, string author, string genre, DateTime publicationDate, int count, string status)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            PublicationDate = publicationDate;
            Count = count;
            Status = status;
        }

        public static Book GetBookDataFromTheConsole()
        {
            var book = new Book();

            Console.WriteLine("Enter Book ID:");
            book.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book Title:");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter Book Author:");
            book.Author = Console.ReadLine();

            Console.WriteLine("Enter Book Genre:");
            book.Genre = Console.ReadLine();

            Console.WriteLine("Enter Book Publication Date:");
            book.PublicationDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book Count:");
            book.Count = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Book Status:");
            book.Status = Console.ReadLine();

            return book;
        }
    }
}
