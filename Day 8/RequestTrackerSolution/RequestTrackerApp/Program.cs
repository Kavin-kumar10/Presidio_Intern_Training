using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModalClasses;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("IT","kavin");
            Department departmentBL = new DepartmentBL(new DepartmentRepository());
            Console.WriteLine(departmentBL.AddDepartment(department));
            Employee emp1 = new Employee(123, "kavin", new DateTime(2002, 11, 10), "Employee");
            Employee emp2 = new Employee(123, "kavin", new DateTime(2002, 11, 10), "Employee");
            if (emp1 == emp2) Console.WriteLine("Both Same");
            else Console.WriteLine("Not Equal");
        }
    }
}
