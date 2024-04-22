using LibraryManagementBLLibrary;
using LibraryManagementModals;
using LibraryManagmentModals;
using System.Net;

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
                    BorrowBookByCustomer();
                    break;
                case 3:
                    ReturnBookByCustomer();
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
            Console.WriteLine("3. Get All the Customers.");
            Console.WriteLine("0  Exit");

            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 0:
                    MenuSelector();
                    break;
                case 1:
                    PrintAllbooks();
                    AdminMenu();
                    break;
                case 2:
                    Book newBook = Book.GetBookDataFromTheConsole();
                    var result = bookBL.AddBook(newBook);
                    Console.WriteLine();
                    Console.WriteLine(result.ToString());
                    AdminMenu();
                    break;
                case 3:
                    PrintAllCustomers();
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
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(book.ToString());
                Console.WriteLine("--------------------------------------------------------------");
            }
        }

        // Customer Related Methods
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = customerBL.GetAllCustomers();
            return customers;
        }

        public void PrintAllCustomers()
        {
            List<Customer> AllCustomers = GetAllCustomers();
            foreach (Customer Customer in AllCustomers)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(Customer.ToString());
                Console.WriteLine("--------------------------------------------------------------");
            }
        }

        public void CreateNewCustomer()
        {
            Customer customer = GetCustomerFromTheConsole();
            customer.Id = 1;
            customerBL.AddCustomer(customer);
            Console.WriteLine(customer.ToString());
            CustomerMenu();
        }

        public Customer GetCustomerFromTheConsole()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Your Name : ");
            customer.Name = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Your Date of Birth (YYYY-MM-DD): ");
                    customer.Dob = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid date format. Please try again:");
                }
            }
            customer.BooksTaken = new List<int>();
            return customer;
        }

        //Borrow related

        public Borrow BorrowDetailsFromTheConsole(int customerId, int bookId)
        {
            Borrow borrow = new Borrow();
            borrow.CustomerId = customerId;
            borrow.BookId = bookId;
            borrow.Status = "Borrowed";
            borrow.BorrowedDate = DateTime.Now;
            return borrow;
        }

        public void BorrowBookByCustomer()
        {
            Borrow borrow = new Borrow(); Console.WriteLine("Enter your Customer Id: ");
            int CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your BookId");
            int BookId = Convert.ToInt32(Console.ReadLine());
            borrow.BorrowDetailsFromTheConsole(CustomerId,BookId);
            borrowBL.AddBorrow(borrow);
            Customer customer = customerBL.AddBookToCustomer(CustomerId,BookId);
            Console.WriteLine(customer.ToString());
            CustomerMenu();
        }

        public void ReturnBookByCustomer()
        {
            Borrow borrowTemp = new Borrow();
            Console.WriteLine("Enter Customer Id : ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            borrowTemp.CustomerId = customerId;
            Console.WriteLine("Enter Book Id : ");
            int bookId = Convert.ToInt32(Console.ReadLine());
            borrowTemp.BookId = bookId;
            Borrow borrow = borrowBL.GetBorrowWithIds(borrowTemp.CustomerId, borrowTemp.BookId);
            borrow.ReturnDate = DateTime.Now;
            borrow.Status = "Returned";
            borrowBL.UpdateBorrow(borrow);
            borrow.ToString();
            Customer customer = customerBL.RemoveBookToCustomer(customerId, bookId);
            Console.WriteLine(customer.ToString());
            CustomerMenu();
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
