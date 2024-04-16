using System.Dynamic;

namespace CompanyGovernmentRulesClasses
{
    public class CTS : Company
    {

        /// <summary>
        /// Empty constructor provides the company name
        /// </summary>
        public CTS() {
            CompanyName = "CTS";
        }


        /// <summary>
        /// Overriding Interface method EmployeePF from parent class
        /// </summary>
        /// <param name="basicSalary"></param>
        /// <returns></returns>
        public override double EmployeePF(double basicSalary)
        {
            EmployeePFAmount = basicSalary*8.33/100;
            FundPF = basicSalary * 3.67 / 100;
            return EmployeePFAmount+FundPF;
        }

        /// <summary>
        /// Overriding interface method Gratuity from parent class 
        /// </summary>
        /// <param name="serviceCompleted"></param>
        /// <param name="basicSalary"></param>
        /// <returns></returns>
        public override double Gratuity(double serviceCompleted, double basicSalary)
        {
            if (serviceCompleted <= 5) { return GratuityAmount; };
            if (serviceCompleted > 5)
            {
                GratuityAmount = basicSalary;
            }
            else if (serviceCompleted > 10)
            {
                GratuityAmount = basicSalary * 2;
            }
            else if (serviceCompleted > 20)
            {
                GratuityAmount = basicSalary * 3;
            }
            return GratuityAmount;
        }

        /// <summary>
        /// Overriding interface method LeaveDetails from parent class
        /// </summary>
        /// <returns></returns>
        public override string LeaveDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year";
        }
    }
}
