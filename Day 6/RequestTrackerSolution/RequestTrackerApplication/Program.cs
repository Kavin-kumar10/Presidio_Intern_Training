using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;

        /// <summary>
        /// Empty constructor for program to initialize array of employees
        /// </summary>
        public Program()
        {
            employees = new Employee[3];
        }

        /// <summary>
        /// Menu bar to select the operation among the crud 
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update an Employee Detail");
            Console.WriteLine("5. Delete an Employee Detail");
            Console.WriteLine("0. Exit");
        }

        /// <summary>
        /// Navigating function based on menu bar selection through switch case
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SelectAndUpdateEmployeeName();
                        break;
                    case 5:
                        SelectAndDeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Adding new Employee to the array of employees
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Type of Employee :");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Contract Employee");
                    Console.WriteLine("3. Permanent Employee");
                    employees[i] = CreateEmployee(i);
                }
            }

        }
            

        /// <summary>
        /// Update an existing employee from the employees array
        /// </summary>
        void SelectAndUpdateEmployeeName()
        {
            int id = SearchAndPrintEmployee();
            for(int ind = 0;ind< employees.Length; ind++)
            {
                if (employees[ind].Id == id)
                {
                    Console.WriteLine("Enter your updated Name for above user : ");
                    employees[ind].Name = Console.ReadLine();
                    PrintEmployee(employees[ind]);
                }
            }
        }

        /// <summary>
        /// Deleting the employee data from the array of employees
        /// </summary>
        void SelectAndDeleteEmployee()
        {
            int id = SearchAndPrintEmployee();
            for (int ind = 0; ind < employees.Length; ind++)
            {
                if (employees[ind].Id == id)
                {
                    Console.WriteLine("The Employee deleted is : ");
                    PrintEmployee(employees[ind]);
                    for(int i = ind;i< employees.Length-1;i++)
                    {
                        employees[i] = employees[i + 1];
                    }
                }
            }
            employees[employees.Length - 1] = null;
        }


        /// <summary>
        /// Printing every employees available in the array of employees
        /// </summary>
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }

        /// <summary>
        /// Creating a new employee using id as parameter 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee CreateEmployee(int id)
        {
            Employee employee;
            int EmployeeTypeNumber = Convert.ToInt32(Console.ReadLine());
            switch (EmployeeTypeNumber) {
                case 1:
                    employee = new Employee();
                    break;
                case 2:
                    employee = new ContractEmployee();
                    break;
                case 3:
                    employee = new PermanentEmployee();
                    break;
                default:
                    employee = new Employee();
                    break;

            }
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        /// <summary>
        /// Function to call print the Employee function
        /// </summary>
        /// <param name="employee"></param>
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Get employee id from the console to select the accurate employee to update or delete from. 
        /// </summary>
        /// <returns></returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        /// <summary>
        /// To Search and print the employee details 
        /// </summary>
        /// <returns></returns>
        int SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return id;
            }
            PrintEmployee(employee);
            return id;
        }

        /// <summary>
        /// Searching Employee from the id got through console 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                // if ( employees[i].Id == id && employees[i] != null)//Will lead to exception
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
            ContractEmployee employee = new ContractEmployee(1,"kavin",DateTime.Now,101010);
            employee.PrintEmployeeDetails();
        }
    }
}
