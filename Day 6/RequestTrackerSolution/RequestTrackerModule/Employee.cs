using RequestTrackerModule;

namespace RequestTrackerModelLibrary
{

    /// <summary>
    /// Employee class with required age,dob,id,name setters and getters
    /// </summary>
    public class Employee
    {
        public Department Department { get; set; }
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string type { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }


        /// <summary>
        /// Empty constructor for Employee class
        /// </summary>
        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            DateOfBirth = new DateTime();
            type = string.Empty;
        }

        /// <summary>
        /// Constructor with parameters for employee class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="dateOfBirth"></param>
        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Building new Employee using console data 
        /// </summary>
        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        /// <summary>
        /// Printing the required employee details in the console
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
        }

        public override string ToString()
        {
            return "Employee id : "+Id +"\n Employee Name : "+Name+"\n Date of Birth : "+DateOfBirth+"\n Employee Age : "+Age;
        }
    }
}
