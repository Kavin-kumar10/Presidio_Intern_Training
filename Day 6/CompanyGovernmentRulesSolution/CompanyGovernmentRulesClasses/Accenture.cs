using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyGovernmentRulesClasses
{
    public class Accenture:Company
    {
        /// <summary>
        /// Empty constructor provides the company name
        /// </summary>
        public Accenture() {
            CompanyName = "Accenture";
        }

        /// <summary>
        /// Overriding Interface method EmployeePF from parent class
        /// </summary>
        /// <param name="basicSalary"></param>
        /// <returns></returns>
        public override double EmployeePF(double basicSalary)
        {
            EmployeePFAmount = basicSalary * 12/100;
            return EmployeePFAmount;
        }

        /// <summary>
        /// Overriding interface method Gratuity from parent class 
        /// </summary>
        /// <param name="serviceCompleted"></param>
        /// <param name="basicSalary"></param>
        /// <returns></returns>
        public override double Gratuity(double serviceCompleted, double basicSalary)
        {
            return 0;
        }

        /// <summary>
        /// Overriding interface method LeaveDetails from parent class
        /// </summary>
        /// <returns></returns>
        public override string LeaveDetails()
        {
            return ("2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year");
        }
    }
}
