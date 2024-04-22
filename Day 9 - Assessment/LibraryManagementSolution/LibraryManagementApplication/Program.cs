using LibraryManagementBLLibrary;
using LibraryManagementModals;
using LibraryManagmentModals;

namespace LibraryManagementApplication
{
    internal class Program
    {
        BookBL bookBL = new BookBL();
        CustomerBL customerBL = new CustomerBL();
        BorrowBL borrowBL = new BorrowBL();

        /// <summary>
        /// Menu Bars 
        /// </summary>
        /// <returns></returns>

        public void MenuSelector()
        {
            Console.WriteLine("Select the Modules : ");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("0 Exit");
            int ModuleResponse = int.Parse(Console.ReadLine());
            if (ModuleResponse == 1)
            {
                CustomerMenu();
            }
            else if (ModuleResponse == 2)
            {
                AdminMenu();
            }
            else if (ModuleResponse == 0) return;
            else
            {
                Console.WriteLine("Invalid Module Selection. Please Try again : ");
                MenuSelector();
            }

        }

        public void CustomerMenu()
        {
            Console.WriteLine("Select the Function Module : ");
            Console.WriteLine("1. Join as new Customer. ");
            Console.WriteLine("2. Borrow a Book.");
            Console.WriteLine("3. Return a Book.");
            Console.WriteLine("4. Get All Book Details.");
            Console.WriteLine("0  Exit");
            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 0:
                    MenuSelector();
                    break;
                case 1:
                    CreateNewCustomer();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    PrintAllbooks();
                    CustomerMenu();
                    break;
            }
        }

        public void AdminMenu()
        {
            Console.WriteLine("Select the Function Module:");
            Console.WriteLine("1. Get All Book Details.");
            Console.WriteLine("2. Add New Books to the Store");
            Console.WriteLine("0  Exit");

            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 0:
                    MenuSelector();
                    break;
                case 1:
                    List<Book> books = GetAllBooks();
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine(books[i].ToString());
                    }
                    AdminMenu();
                    break;
                case 2:
                    Book newBook = Book.GetBookDataFromTheConsole();
                    var result = bookBL.AddBook(newBook);
                    Console.WriteLine();
                    Console.WriteLine("After Added");
                    Console.WriteLine(result.ToString());
                    AdminMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Response. Please Try Again : ");
                    AdminMenu();
                    break;
            }
        }


        /// <summary>
        /// Methods to be utilized
        /// </summary>
        /// <returns></returns>

        public List<Book> GetAllBooks()
        {
            List<Book> AllBooks = bookBL.GetAllBooks();
            return AllBooks;
        }

        public void PrintAllbooks()
        {
            List<Book> AllBooks = GetAllBooks();
            foreach (Book book in AllBooks)
            {
                Console.WriteLine();
                Console.WriteLine(book.ToString());
            }
        }

        public void CreateNewCustomer()
        {
            Customer customer = new Customer();
            customer.GetCustomerFromTheConsole();
            customerBL.AddCustomer(customer);
        }

        public void BorrowBookByCustomer()
        {
            Borrow borrow = new Borrow();
            borrow.BorrowDetailsFromTheConsole();
            borrowBL.AddBorrow(borrow);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            //Adding multiple Books
            Book book1 = new Book(123, "Them Empire", "Rajan", "History", new DateTime(1999, 11, 10), 10, "Available");
            Book book2 = new Book(124, "Harry potter", "Masasi kishimato", "Fictional", new DateTime(1899, 11, 10), 20, "Available");
            program.bookBL.AddBook(book1);
            program.bookBL.AddBook(book2);

            program.MenuSelector();

           
        }
    }
}
