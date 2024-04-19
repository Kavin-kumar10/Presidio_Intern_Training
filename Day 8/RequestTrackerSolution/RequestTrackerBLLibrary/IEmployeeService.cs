using RequestTrackerModalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee UpdateEmployeeName(string OldName, string NewName);
        int DeleteEmployee(int Id);
        Employee GetEmployeeById(int Id);
        List<Employee> GetAllEmployee();
    }
}
