using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{
    public class PermanentEmployee:Employee
    {
        public double Salary {  get; set; }
        public PermanentEmployee() { 
             Salary = 0;
                type = "Permanent";
        }
        public PermanentEmployee(int id,string name,DateTime dateOfBirth,double Salary) : base(id, name, dateOfBirth)
        {
            this.Salary = Salary;
            type = "Permanent";

        }

        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Enter the Salary of Employee : ");
            Salary = Convert.ToInt16((double)Salary);
        }

        public override void PrintEmployeeDetails()
        {
            Console.WriteLine("Permanent employee detail : ");
            base.PrintEmployeeDetails();
            Console.WriteLine("The salary of the Employee is  : "+Salary);
        }

        public override string ToString()
        {
            return base.ToString() + "\nThe salary of the Employee is  : " + Salary;
        }
    }
}
