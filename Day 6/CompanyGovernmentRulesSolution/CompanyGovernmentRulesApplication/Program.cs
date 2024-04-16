using CompanyGovernmentRulesClasses;

namespace CompanyGovernmentRulesApplication
{
    internal class Program 
    {
        /// <summary>
        /// Creating New Employee to specific company with choice 
        /// </summary>
        public static void CreateEmployee()
        {
            Console.WriteLine("Select Your Company : \n 1. CTS \n 2. Accenture");
            int Type = Convert.ToInt32(Console.ReadLine()); 
            switch (Type)
            {
                case 1:
                    CTS CtsEmployee = new CTS();
                    CtsEmployee.GetEmployeeDetailsFromTheConsole();
                    CtsEmployee.EmployeePF(CtsEmployee.Salary);
                    CtsEmployee.LeaveDetails();
                    CtsEmployee.Gratuity(CtsEmployee.ServiceYear,CtsEmployee.Salary);
                    CtsEmployee.OriginalSalary = CtsEmployee.Salary - CtsEmployee.EmployeePFAmount;
                    CtsEmployee.ExtraLeaveSalaryDeduct();
                    CtsEmployee.PrintEmployeeDetails();
                    break;
                case 2: 
                    Accenture AccentureEmployee = new Accenture();
                    AccentureEmployee.GetEmployeeDetailsFromTheConsole();
                    AccentureEmployee.EmployeePF(AccentureEmployee.Salary);
                    AccentureEmployee.LeaveDetails();
                    AccentureEmployee.Gratuity(AccentureEmployee.ServiceYear, AccentureEmployee.Salary);
                    AccentureEmployee.OriginalSalary = AccentureEmployee.Salary - AccentureEmployee.EmployeePFAmount;
                    AccentureEmployee.ExtraLeaveSalaryDeduct();
                    AccentureEmployee.PrintEmployeeDetails();
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    break;
            }
        }

        static void Main(string[] args)
        {
            CreateEmployee();
        }
    }
}
