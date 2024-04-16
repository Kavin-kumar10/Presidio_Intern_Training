using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyGovernmentRulesClasses
{
    public interface IGovernmentRules
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double Gratuity(double serviceCompleted, double basicSalary);
    }
}
