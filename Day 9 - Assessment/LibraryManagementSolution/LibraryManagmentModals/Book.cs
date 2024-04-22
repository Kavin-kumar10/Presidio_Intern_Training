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
    }
}
