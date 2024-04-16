using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyGovernmentRulesClasses
{
    /// <summary>
    /// Interface IGovernmentrules implemented in Company class
    /// </summary>
    public class Company : IGovernmentRules
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
        public double OriginalSalary { get; set; }
        public double ServiceYear { get; set; }
        public string CompanyName { get; set; }
        public double EmployeePFAmount {  get; set; }
        public double FundPF { get; set; }
        public double GratuityAmount { get; set; }
        public double LeaveCount { get; set; }
        public double AmountDeductedDueToExtraLeave { get; set; }

        public Company()
        {
            EmpId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            Salary = 0;
            ServiceYear = 0;
            LeaveCount = 0;
        }
        public Company(int empId, string name, string dept, string designation, double salary, int serviceYear)
        {
            this.EmpId = empId;
            Name = name;
            this.Department = dept;
            this.Designation = designation;
            Salary = salary;
            ServiceYear = serviceYear;
        }

        /// <summary>
        /// Getting employee details from teh console
        /// </summary>
        public void GetEmployeeDetailsFromTheConsole()
        {
            Console.WriteLine("Enter your Name : ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your Department : ");
            Department = Console.ReadLine();
            Console.WriteLine("Enter your Designation : ");
            Designation = Console.ReadLine();
            Console.WriteLine("Enter your Salary : ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your service Year : ");
            ServiceYear = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Number of Leave Taken : ");
            LeaveCount = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Extra leave Calculation and deducting original salary based on leaves
        /// </summary>
        public void ExtraLeaveSalaryDeduct()
        {
            if(LeaveCount > 2)
            {
                AmountDeductedDueToExtraLeave = OriginalSalary * (LeaveCount - 2) / 30;
                OriginalSalary = OriginalSalary - AmountDeductedDueToExtraLeave;
            }
        }


        /// <summary>
        /// Printing the Employee Details
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Company Name : "+CompanyName);
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Department : " + Department);
            Console.WriteLine("Designation : " + Designation);
            Console.WriteLine("Original Salary after Deductions : " + OriginalSalary);
            Console.WriteLine("Salary : " + Salary);
            Console.WriteLine("Experience : " + ServiceYear);
            Console.WriteLine("Employee PF : "+EmployeePFAmount);
            Console.WriteLine("Fund PF : " + FundPF);
            Console.WriteLine("Gratuity : " + GratuityAmount);
            Console.WriteLine("Total Leave Count : " + LeaveCount);
            Console.WriteLine("Salary Deducted due to Extra leave : " + AmountDeductedDueToExtraLeave);
            Console.WriteLine("Allowed Leave Details : ");
            Console.WriteLine(LeaveDetails());
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");

        }
        public virtual double EmployeePF(double basicSalary)
        {
            throw new NotImplementedException();
        }

        public virtual double Gratuity(double serviceCompleted, double basicSalary)
        {
            throw new NotImplementedException();
        }

        public virtual string LeaveDetails()
        {
            throw new NotImplementedException();
        }
    }
}
