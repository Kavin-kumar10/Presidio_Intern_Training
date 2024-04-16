using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{
    public class ContractEmployee:Employee
    {
        public double wagesPerDay { get; set; }
        public ContractEmployee()
        {
            wagesPerDay = 0;
            type = "Contract";
        }
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double wagesPerDay):base(id,name,dateOfBirth)
        {
            type = "Contract";
            this.wagesPerDay = wagesPerDay;
        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the per day Salary");
            wagesPerDay = Convert.ToDouble(Console.ReadLine());
        }
        public override void PrintEmployeeDetails()
        {
            Console.WriteLine("Contract employee Detail");
            base.PrintEmployeeDetails();
            Console.WriteLine("Wages/Day of employee : "+wagesPerDay);
        }
        public override string ToString()
        {
            return  base.ToString()+"\nWages per day of employee : "+wagesPerDay;
        }
    }
}
