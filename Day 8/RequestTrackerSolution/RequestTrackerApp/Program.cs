using RequestTrackerBLLibrary;
using RequestTrackerModalClasses;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department(123,"IT","kavin");
            DepartmentBL departmentBL = new DepartmentBL();
            Console.WriteLine(departmentBL.AddDepartment(department));
            Employee emp1 = new Employee(123, "kavin", new DateTime(2002, 11, 10), "Employee");
            Employee emp2 = new Employee(123, "kavin", new DateTime(2002, 11, 10), "Employee");
            if (emp1 == emp2) Console.WriteLine("Both Same");
            else Console.WriteLine("Not Equal");
        }
    }
}
